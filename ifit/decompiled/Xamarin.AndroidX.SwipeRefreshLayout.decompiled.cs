using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Content;
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
[assembly: NamespaceMapping(Java = "androidx.swiperefreshlayout.widget", Managed = "AndroidX.SwipeRefreshLayout.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.swiperefreshlayout:swiperefreshlayout'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.SwipeRefreshLayout")]
[assembly: AssemblyTitle("Xamarin.AndroidX.SwipeRefreshLayout")]
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
internal delegate bool _JniMarshal_PPI_Z(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPII_V(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate bool _JniMarshal_PPII_Z(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate bool _JniMarshal_PPIIIILI_Z(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3, IntPtr p4, int p5);
internal delegate void _JniMarshal_PPIIIILIL_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3, IntPtr p4, int p5, IntPtr p6);
internal delegate bool _JniMarshal_PPIILLI_Z(IntPtr jnienv, IntPtr klass, int p0, int p1, IntPtr p2, IntPtr p3, int p4);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLIIIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, int p4, int p5);
internal delegate void _JniMarshal_PPLIIIIIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, int p4, int p5, IntPtr p6);
internal delegate void _JniMarshal_PPLIILI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, IntPtr p3, int p4);
internal delegate bool _JniMarshal_PPLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate bool _JniMarshal_PPLLII_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
internal delegate void _JniMarshal_PPZI_V(IntPtr jnienv, IntPtr klass, bool p0, int p1);
internal delegate void _JniMarshal_PPZII_V(IntPtr jnienv, IntPtr klass, bool p0, int p1, int p2);
internal delegate void _JniMarshal_PPZIIII_V(IntPtr jnienv, IntPtr klass, bool p0, int p1, int p2, int p3, int p4);
namespace AndroidX.SwipeRefreshLayout.Widget
{
	[Register("androidx/swiperefreshlayout/widget/SwipeRefreshLayout", DoNotGenerateAcw = true)]
	public class SwipeRefreshLayout : ViewGroup, INestedScrollingChild, IJavaObject, IDisposable, IJavaPeerable, INestedScrollingChild2, INestedScrollingChild3, INestedScrollingParent, INestedScrollingParent2, INestedScrollingParent3
	{
		[Register("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnChildScrollUpCallback", "", "AndroidX.SwipeRefreshLayout.Widget.SwipeRefreshLayout/IOnChildScrollUpCallbackInvoker")]
		public interface IOnChildScrollUpCallback : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("canChildScrollUp", "(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout;Landroid/view/View;)Z", "GetCanChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_Handler:AndroidX.SwipeRefreshLayout.Widget.SwipeRefreshLayout/IOnChildScrollUpCallbackInvoker, Xamarin.AndroidX.SwipeRefreshLayout")]
			bool CanChildScrollUp(SwipeRefreshLayout parent, View child);
		}

		[Register("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnChildScrollUpCallback", DoNotGenerateAcw = true)]
		internal class IOnChildScrollUpCallbackInvoker : Java.Lang.Object, IOnChildScrollUpCallback, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnChildScrollUpCallback", typeof(IOnChildScrollUpCallbackInvoker));

			private IntPtr class_ref;

			private static Delegate cb_canChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_;

			private IntPtr id_canChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_;

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

			public static IOnChildScrollUpCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnChildScrollUpCallback>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.swiperefreshlayout.widget.SwipeRefreshLayout.OnChildScrollUpCallback'.");
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

			public IOnChildScrollUpCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetCanChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_Handler()
			{
				if ((object)cb_canChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_ == null)
				{
					cb_canChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_CanChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_));
				}
				return cb_canChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_;
			}

			private static bool n_CanChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child)
			{
				IOnChildScrollUpCallback onChildScrollUpCallback = Java.Lang.Object.GetObject<IOnChildScrollUpCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SwipeRefreshLayout parent = Java.Lang.Object.GetObject<SwipeRefreshLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return onChildScrollUpCallback.CanChildScrollUp(parent, child);
			}

			public unsafe bool CanChildScrollUp(SwipeRefreshLayout parent, View child)
			{
				if (id_canChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_ == IntPtr.Zero)
				{
					id_canChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "canChildScrollUp", "(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout;Landroid/view/View;)Z");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(child?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_canChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_, ptr);
			}
		}

		[Register("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnRefreshListener", "", "AndroidX.SwipeRefreshLayout.Widget.SwipeRefreshLayout/IOnRefreshListenerInvoker")]
		public interface IOnRefreshListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onRefresh", "()V", "GetOnRefreshHandler:AndroidX.SwipeRefreshLayout.Widget.SwipeRefreshLayout/IOnRefreshListenerInvoker, Xamarin.AndroidX.SwipeRefreshLayout")]
			void OnRefresh();
		}

		[Register("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnRefreshListener", DoNotGenerateAcw = true)]
		internal class IOnRefreshListenerInvoker : Java.Lang.Object, IOnRefreshListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnRefreshListener", typeof(IOnRefreshListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onRefresh;

			private IntPtr id_onRefresh;

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

			public static IOnRefreshListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnRefreshListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.swiperefreshlayout.widget.SwipeRefreshLayout.OnRefreshListener'.");
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

			public IOnRefreshListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnRefreshHandler()
			{
				if ((object)cb_onRefresh == null)
				{
					cb_onRefresh = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnRefresh));
				}
				return cb_onRefresh;
			}

			private static void n_OnRefresh(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IOnRefreshListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnRefresh();
			}

			public void OnRefresh()
			{
				if (id_onRefresh == IntPtr.Zero)
				{
					id_onRefresh = JNIEnv.GetMethodID(class_ref, "onRefresh", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onRefresh);
			}
		}

		[Register("mono/androidx/swiperefreshlayout/widget/SwipeRefreshLayout_OnRefreshListenerImplementor")]
		internal sealed class IOnRefreshListenerImplementor : Java.Lang.Object, IOnRefreshListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler Handler;

			public IOnRefreshListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/androidx/swiperefreshlayout/widget/SwipeRefreshLayout_OnRefreshListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnRefresh()
			{
				Handler?.Invoke(sender, new EventArgs());
			}

			internal static bool __IsEmpty(IOnRefreshListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/swiperefreshlayout/widget/SwipeRefreshLayout", typeof(SwipeRefreshLayout));

		private static Delegate cb_getProgressCircleDiameter;

		private static Delegate cb_getProgressViewEndOffset;

		private static Delegate cb_getProgressViewStartOffset;

		private static Delegate cb_isRefreshing;

		private static Delegate cb_setRefreshing_Z;

		private static Delegate cb_canChildScrollUp;

		private static Delegate cb_dispatchNestedPreScroll_IIarrayIarrayII;

		private static Delegate cb_dispatchNestedScroll_IIIIarrayII;

		private static Delegate cb_dispatchNestedScroll_IIIIarrayIIarrayI;

		private static Delegate cb_hasNestedScrollingParent_I;

		private static Delegate cb_onLayout_ZIIII;

		private static Delegate cb_onMeasure_II;

		private static Delegate cb_onNestedPreScroll_Landroid_view_View_IIarrayII;

		private static Delegate cb_onNestedScroll_Landroid_view_View_IIIII;

		private static Delegate cb_onNestedScroll_Landroid_view_View_IIIIIarrayI;

		private static Delegate cb_onNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II;

		private static Delegate cb_onStartNestedScroll_Landroid_view_View_Landroid_view_View_II;

		private static Delegate cb_onStopNestedScroll_Landroid_view_View_I;

		private static Delegate cb_setColorScheme_arrayI;

		private static Delegate cb_setColorSchemeColors_arrayI;

		private static Delegate cb_setColorSchemeResources_arrayI;

		private static Delegate cb_setDistanceToTriggerSync_I;

		private static Delegate cb_setLegacyRequestDisallowInterceptTouchEventEnabled_Z;

		private static Delegate cb_setOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_;

		private static Delegate cb_setOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_;

		private static Delegate cb_setProgressBackgroundColor_I;

		private static Delegate cb_setProgressBackgroundColorSchemeColor_I;

		private static Delegate cb_setProgressBackgroundColorSchemeResource_I;

		private static Delegate cb_setProgressViewEndTarget_ZI;

		private static Delegate cb_setProgressViewOffset_ZII;

		private static Delegate cb_setSize_I;

		private static Delegate cb_setSlingshotDistance_I;

		private static Delegate cb_startNestedScroll_II;

		private static Delegate cb_stopNestedScroll_I;

		private WeakReference weak_implementor_SetOnRefreshListener;

		[Register("mFrom")]
		protected int MFrom
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mFrom.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mFrom.I", this, value);
			}
		}

		[Register("mOriginalOffsetTop")]
		protected int MOriginalOffsetTop
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mOriginalOffsetTop.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mOriginalOffsetTop.I", this, value);
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

		public unsafe virtual int ProgressCircleDiameter
		{
			[Register("getProgressCircleDiameter", "()I", "GetGetProgressCircleDiameterHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getProgressCircleDiameter.()I", this, null);
			}
		}

		public unsafe virtual int ProgressViewEndOffset
		{
			[Register("getProgressViewEndOffset", "()I", "GetGetProgressViewEndOffsetHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getProgressViewEndOffset.()I", this, null);
			}
		}

		public unsafe virtual int ProgressViewStartOffset
		{
			[Register("getProgressViewStartOffset", "()I", "GetGetProgressViewStartOffsetHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getProgressViewStartOffset.()I", this, null);
			}
		}

		public unsafe virtual bool Refreshing
		{
			[Register("isRefreshing", "()Z", "GetIsRefreshingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRefreshing.()Z", this, null);
			}
			[Register("setRefreshing", "(Z)V", "GetSetRefreshing_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRefreshing.(Z)V", this, ptr);
			}
		}

		public event EventHandler Refresh
		{
			add
			{
				EventHelper.AddEventHandler<IOnRefreshListener, IOnRefreshListenerImplementor>(ref weak_implementor_SetOnRefreshListener, __CreateIOnRefreshListenerImplementor, SetOnRefreshListener, delegate(IOnRefreshListenerImplementor __h)
				{
					__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnRefreshListener, IOnRefreshListenerImplementor>(ref weak_implementor_SetOnRefreshListener, IOnRefreshListenerImplementor.__IsEmpty, delegate
				{
					SetOnRefreshListener(null);
				}, delegate(IOnRefreshListenerImplementor __h)
				{
					__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public virtual void OnNestedScrollAccepted(View child, View target, int axes, int type)
		{
			OnNestedScrollAccepted(child, target, (ScrollAxis)axes, type);
		}

		public virtual bool OnStartNestedScroll(View child, View target, int axes, int type)
		{
			return OnStartNestedScroll(child, target, (ScrollAxis)axes, type);
		}

		protected SwipeRefreshLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe SwipeRefreshLayout(Context context)
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
		public unsafe SwipeRefreshLayout(Context context, IAttributeSet attrs)
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

		private static Delegate GetGetProgressCircleDiameterHandler()
		{
			if ((object)cb_getProgressCircleDiameter == null)
			{
				cb_getProgressCircleDiameter = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetProgressCircleDiameter));
			}
			return cb_getProgressCircleDiameter;
		}

		private static int n_GetProgressCircleDiameter(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProgressCircleDiameter;
		}

		private static Delegate GetGetProgressViewEndOffsetHandler()
		{
			if ((object)cb_getProgressViewEndOffset == null)
			{
				cb_getProgressViewEndOffset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetProgressViewEndOffset));
			}
			return cb_getProgressViewEndOffset;
		}

		private static int n_GetProgressViewEndOffset(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProgressViewEndOffset;
		}

		private static Delegate GetGetProgressViewStartOffsetHandler()
		{
			if ((object)cb_getProgressViewStartOffset == null)
			{
				cb_getProgressViewStartOffset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetProgressViewStartOffset));
			}
			return cb_getProgressViewStartOffset;
		}

		private static int n_GetProgressViewStartOffset(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProgressViewStartOffset;
		}

		private static Delegate GetIsRefreshingHandler()
		{
			if ((object)cb_isRefreshing == null)
			{
				cb_isRefreshing = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRefreshing));
			}
			return cb_isRefreshing;
		}

		private static bool n_IsRefreshing(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Refreshing;
		}

		private static Delegate GetSetRefreshing_ZHandler()
		{
			if ((object)cb_setRefreshing_Z == null)
			{
				cb_setRefreshing_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetRefreshing_Z));
			}
			return cb_setRefreshing_Z;
		}

		private static void n_SetRefreshing_Z(IntPtr jnienv, IntPtr native__this, bool refreshing)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Refreshing = refreshing;
		}

		private static Delegate GetCanChildScrollUpHandler()
		{
			if ((object)cb_canChildScrollUp == null)
			{
				cb_canChildScrollUp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_CanChildScrollUp));
			}
			return cb_canChildScrollUp;
		}

		private static bool n_CanChildScrollUp(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanChildScrollUp();
		}

		[Register("canChildScrollUp", "()Z", "GetCanChildScrollUpHandler")]
		public unsafe virtual bool CanChildScrollUp()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("canChildScrollUp.()Z", this, null);
		}

		private static Delegate GetDispatchNestedPreScroll_IIarrayIarrayIIHandler()
		{
			if ((object)cb_dispatchNestedPreScroll_IIarrayIarrayII == null)
			{
				cb_dispatchNestedPreScroll_IIarrayIarrayII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIILLI_Z(n_DispatchNestedPreScroll_IIarrayIarrayII));
			}
			return cb_dispatchNestedPreScroll_IIarrayIarrayII;
		}

		private static bool n_DispatchNestedPreScroll_IIarrayIarrayII(IntPtr jnienv, IntPtr native__this, int dx, int dy, IntPtr native_consumed, IntPtr native_offsetInWindow, int type)
		{
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			int[] array2 = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			bool result = swipeRefreshLayout.DispatchNestedPreScroll(dx, dy, array, array2, type);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_consumed);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_offsetInWindow);
			}
			return result;
		}

		[Register("dispatchNestedPreScroll", "(II[I[II)Z", "GetDispatchNestedPreScroll_IIarrayIarrayIIHandler")]
		public unsafe virtual bool DispatchNestedPreScroll(int dx, int dy, int[] consumed, int[] offsetInWindow, int type)
		{
			IntPtr intPtr = JNIEnv.NewArray(consumed);
			IntPtr intPtr2 = JNIEnv.NewArray(offsetInWindow);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(dx);
				ptr[1] = new JniArgumentValue(dy);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(intPtr2);
				ptr[4] = new JniArgumentValue(type);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchNestedPreScroll.(II[I[II)Z", this, ptr);
			}
			finally
			{
				if (consumed != null)
				{
					JNIEnv.CopyArray(intPtr, consumed);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (offsetInWindow != null)
				{
					JNIEnv.CopyArray(intPtr2, offsetInWindow);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(consumed);
				GC.KeepAlive(offsetInWindow);
			}
		}

		private static Delegate GetDispatchNestedScroll_IIIIarrayIIHandler()
		{
			if ((object)cb_dispatchNestedScroll_IIIIarrayII == null)
			{
				cb_dispatchNestedScroll_IIIIarrayII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIIILI_Z(n_DispatchNestedScroll_IIIIarrayII));
			}
			return cb_dispatchNestedScroll_IIIIarrayII;
		}

		private static bool n_DispatchNestedScroll_IIIIarrayII(IntPtr jnienv, IntPtr native__this, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, IntPtr native_offsetInWindow, int type)
		{
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			bool result = swipeRefreshLayout.DispatchNestedScroll(dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, array, type);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_offsetInWindow);
			}
			return result;
		}

		[Register("dispatchNestedScroll", "(IIII[II)Z", "GetDispatchNestedScroll_IIIIarrayIIHandler")]
		public unsafe virtual bool DispatchNestedScroll(int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[] offsetInWindow, int type)
		{
			IntPtr intPtr = JNIEnv.NewArray(offsetInWindow);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(dxConsumed);
				ptr[1] = new JniArgumentValue(dyConsumed);
				ptr[2] = new JniArgumentValue(dxUnconsumed);
				ptr[3] = new JniArgumentValue(dyUnconsumed);
				ptr[4] = new JniArgumentValue(intPtr);
				ptr[5] = new JniArgumentValue(type);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchNestedScroll.(IIII[II)Z", this, ptr);
			}
			finally
			{
				if (offsetInWindow != null)
				{
					JNIEnv.CopyArray(intPtr, offsetInWindow);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(offsetInWindow);
			}
		}

		private static Delegate GetDispatchNestedScroll_IIIIarrayIIarrayIHandler()
		{
			if ((object)cb_dispatchNestedScroll_IIIIarrayIIarrayI == null)
			{
				cb_dispatchNestedScroll_IIIIarrayIIarrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIIILIL_V(n_DispatchNestedScroll_IIIIarrayIIarrayI));
			}
			return cb_dispatchNestedScroll_IIIIarrayIIarrayI;
		}

		private static void n_DispatchNestedScroll_IIIIarrayIIarrayI(IntPtr jnienv, IntPtr native__this, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, IntPtr native_offsetInWindow, int type, IntPtr native_consumed)
		{
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			int[] array2 = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.DispatchNestedScroll(dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, array, type, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_offsetInWindow);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_consumed);
			}
		}

		[Register("dispatchNestedScroll", "(IIII[II[I)V", "GetDispatchNestedScroll_IIIIarrayIIarrayIHandler")]
		public unsafe virtual void DispatchNestedScroll(int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[] offsetInWindow, int type, int[] consumed)
		{
			IntPtr intPtr = JNIEnv.NewArray(offsetInWindow);
			IntPtr intPtr2 = JNIEnv.NewArray(consumed);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(dxConsumed);
				ptr[1] = new JniArgumentValue(dyConsumed);
				ptr[2] = new JniArgumentValue(dxUnconsumed);
				ptr[3] = new JniArgumentValue(dyUnconsumed);
				ptr[4] = new JniArgumentValue(intPtr);
				ptr[5] = new JniArgumentValue(type);
				ptr[6] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchNestedScroll.(IIII[II[I)V", this, ptr);
			}
			finally
			{
				if (offsetInWindow != null)
				{
					JNIEnv.CopyArray(intPtr, offsetInWindow);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (consumed != null)
				{
					JNIEnv.CopyArray(intPtr2, consumed);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(offsetInWindow);
				GC.KeepAlive(consumed);
			}
		}

		private static Delegate GetInvokeHasNestedScrollingParent_IHandler()
		{
			if ((object)cb_hasNestedScrollingParent_I == null)
			{
				cb_hasNestedScrollingParent_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_InvokeHasNestedScrollingParent_I));
			}
			return cb_hasNestedScrollingParent_I;
		}

		private static bool n_InvokeHasNestedScrollingParent_I(IntPtr jnienv, IntPtr native__this, int type)
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvokeHasNestedScrollingParent(type);
		}

		[Register("hasNestedScrollingParent", "(I)Z", "GetInvokeHasNestedScrollingParent_IHandler")]
		public unsafe virtual bool InvokeHasNestedScrollingParent(int type)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(type);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasNestedScrollingParent.(I)Z", this, ptr);
		}

		private static Delegate GetOnLayout_ZIIIIHandler()
		{
			if ((object)cb_onLayout_ZIIII == null)
			{
				cb_onLayout_ZIIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZIIII_V(n_OnLayout_ZIIII));
			}
			return cb_onLayout_ZIIII;
		}

		private static void n_OnLayout_ZIIII(IntPtr jnienv, IntPtr native__this, bool changed, int left, int top, int right, int bottom)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayout(changed, left, top, right, bottom);
		}

		[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
		protected unsafe override void OnLayout(bool changed, int left, int top, int right, int bottom)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(changed);
			ptr[1] = new JniArgumentValue(left);
			ptr[2] = new JniArgumentValue(top);
			ptr[3] = new JniArgumentValue(right);
			ptr[4] = new JniArgumentValue(bottom);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
		}

		private static Delegate GetOnMeasure_IIHandler()
		{
			if ((object)cb_onMeasure_II == null)
			{
				cb_onMeasure_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_OnMeasure_II));
			}
			return cb_onMeasure_II;
		}

		private static void n_OnMeasure_II(IntPtr jnienv, IntPtr native__this, int widthMeasureSpec, int heightMeasureSpec)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnMeasure(widthMeasureSpec, heightMeasureSpec);
		}

		[Register("onMeasure", "(II)V", "GetOnMeasure_IIHandler")]
		public new unsafe virtual void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(widthMeasureSpec);
			ptr[1] = new JniArgumentValue(heightMeasureSpec);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onMeasure.(II)V", this, ptr);
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
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.OnNestedPreScroll(target, dx, dy, array, type);
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
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			swipeRefreshLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);
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
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type, array);
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
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			swipeRefreshLayout.OnNestedScrollAccepted(child, target, (ScrollAxis)native_axes, type);
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
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return swipeRefreshLayout.OnStartNestedScroll(child, target, (ScrollAxis)native_axes, type);
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
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			swipeRefreshLayout.OnStopNestedScroll(target, type);
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

		private static Delegate GetSetColorScheme_arrayIHandler()
		{
			if ((object)cb_setColorScheme_arrayI == null)
			{
				cb_setColorScheme_arrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetColorScheme_arrayI));
			}
			return cb_setColorScheme_arrayI;
		}

		private static void n_SetColorScheme_arrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_colors)
		{
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_colors, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.SetColorScheme(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_colors);
			}
		}

		[Register("setColorScheme", "([I)V", "GetSetColorScheme_arrayIHandler")]
		public unsafe virtual void SetColorScheme(params int[] colors)
		{
			IntPtr intPtr = JNIEnv.NewArray(colors);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setColorScheme.([I)V", this, ptr);
			}
			finally
			{
				if (colors != null)
				{
					JNIEnv.CopyArray(intPtr, colors);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(colors);
			}
		}

		private static Delegate GetSetColorSchemeColors_arrayIHandler()
		{
			if ((object)cb_setColorSchemeColors_arrayI == null)
			{
				cb_setColorSchemeColors_arrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetColorSchemeColors_arrayI));
			}
			return cb_setColorSchemeColors_arrayI;
		}

		private static void n_SetColorSchemeColors_arrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_colors)
		{
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_colors, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.SetColorSchemeColors(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_colors);
			}
		}

		[Register("setColorSchemeColors", "([I)V", "GetSetColorSchemeColors_arrayIHandler")]
		public unsafe virtual void SetColorSchemeColors(params int[] colors)
		{
			IntPtr intPtr = JNIEnv.NewArray(colors);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setColorSchemeColors.([I)V", this, ptr);
			}
			finally
			{
				if (colors != null)
				{
					JNIEnv.CopyArray(intPtr, colors);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(colors);
			}
		}

		private static Delegate GetSetColorSchemeResources_arrayIHandler()
		{
			if ((object)cb_setColorSchemeResources_arrayI == null)
			{
				cb_setColorSchemeResources_arrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetColorSchemeResources_arrayI));
			}
			return cb_setColorSchemeResources_arrayI;
		}

		private static void n_SetColorSchemeResources_arrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_colorResIds)
		{
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_colorResIds, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.SetColorSchemeResources(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_colorResIds);
			}
		}

		[Register("setColorSchemeResources", "([I)V", "GetSetColorSchemeResources_arrayIHandler")]
		public unsafe virtual void SetColorSchemeResources(params int[] colorResIds)
		{
			IntPtr intPtr = JNIEnv.NewArray(colorResIds);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setColorSchemeResources.([I)V", this, ptr);
			}
			finally
			{
				if (colorResIds != null)
				{
					JNIEnv.CopyArray(intPtr, colorResIds);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(colorResIds);
			}
		}

		private static Delegate GetSetDistanceToTriggerSync_IHandler()
		{
			if ((object)cb_setDistanceToTriggerSync_I == null)
			{
				cb_setDistanceToTriggerSync_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetDistanceToTriggerSync_I));
			}
			return cb_setDistanceToTriggerSync_I;
		}

		private static void n_SetDistanceToTriggerSync_I(IntPtr jnienv, IntPtr native__this, int distance)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDistanceToTriggerSync(distance);
		}

		[Register("setDistanceToTriggerSync", "(I)V", "GetSetDistanceToTriggerSync_IHandler")]
		public unsafe virtual void SetDistanceToTriggerSync(int distance)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(distance);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDistanceToTriggerSync.(I)V", this, ptr);
		}

		private static Delegate GetSetLegacyRequestDisallowInterceptTouchEventEnabled_ZHandler()
		{
			if ((object)cb_setLegacyRequestDisallowInterceptTouchEventEnabled_Z == null)
			{
				cb_setLegacyRequestDisallowInterceptTouchEventEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetLegacyRequestDisallowInterceptTouchEventEnabled_Z));
			}
			return cb_setLegacyRequestDisallowInterceptTouchEventEnabled_Z;
		}

		private static void n_SetLegacyRequestDisallowInterceptTouchEventEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLegacyRequestDisallowInterceptTouchEventEnabled(enabled);
		}

		[Register("setLegacyRequestDisallowInterceptTouchEventEnabled", "(Z)V", "GetSetLegacyRequestDisallowInterceptTouchEventEnabled_ZHandler")]
		public unsafe virtual void SetLegacyRequestDisallowInterceptTouchEventEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLegacyRequestDisallowInterceptTouchEventEnabled.(Z)V", this, ptr);
		}

		private static Delegate GetSetOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_Handler()
		{
			if ((object)cb_setOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_ == null)
			{
				cb_setOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_));
			}
			return cb_setOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_;
		}

		private static void n_SetOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native__callback)
		{
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnChildScrollUpCallback onChildScrollUpCallback = Java.Lang.Object.GetObject<IOnChildScrollUpCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			swipeRefreshLayout.SetOnChildScrollUpCallback(onChildScrollUpCallback);
		}

		[Register("setOnChildScrollUpCallback", "(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnChildScrollUpCallback;)V", "GetSetOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_Handler")]
		public unsafe virtual void SetOnChildScrollUpCallback(IOnChildScrollUpCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnChildScrollUpCallback.(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnChildScrollUpCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetSetOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_Handler()
		{
			if ((object)cb_setOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_ == null)
			{
				cb_setOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_));
			}
			return cb_setOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_;
		}

		private static void n_SetOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			SwipeRefreshLayout swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnRefreshListener onRefreshListener = Java.Lang.Object.GetObject<IOnRefreshListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			swipeRefreshLayout.SetOnRefreshListener(onRefreshListener);
		}

		[Register("setOnRefreshListener", "(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnRefreshListener;)V", "GetSetOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_Handler")]
		public unsafe virtual void SetOnRefreshListener(IOnRefreshListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnRefreshListener.(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnRefreshListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetProgressBackgroundColor_IHandler()
		{
			if ((object)cb_setProgressBackgroundColor_I == null)
			{
				cb_setProgressBackgroundColor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetProgressBackgroundColor_I));
			}
			return cb_setProgressBackgroundColor_I;
		}

		private static void n_SetProgressBackgroundColor_I(IntPtr jnienv, IntPtr native__this, int colorRes)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetProgressBackgroundColor(colorRes);
		}

		[Register("setProgressBackgroundColor", "(I)V", "GetSetProgressBackgroundColor_IHandler")]
		public unsafe virtual void SetProgressBackgroundColor(int colorRes)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(colorRes);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressBackgroundColor.(I)V", this, ptr);
		}

		private static Delegate GetSetProgressBackgroundColorSchemeColor_IHandler()
		{
			if ((object)cb_setProgressBackgroundColorSchemeColor_I == null)
			{
				cb_setProgressBackgroundColorSchemeColor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetProgressBackgroundColorSchemeColor_I));
			}
			return cb_setProgressBackgroundColorSchemeColor_I;
		}

		private static void n_SetProgressBackgroundColorSchemeColor_I(IntPtr jnienv, IntPtr native__this, int color)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetProgressBackgroundColorSchemeColor(color);
		}

		[Register("setProgressBackgroundColorSchemeColor", "(I)V", "GetSetProgressBackgroundColorSchemeColor_IHandler")]
		public unsafe virtual void SetProgressBackgroundColorSchemeColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressBackgroundColorSchemeColor.(I)V", this, ptr);
		}

		private static Delegate GetSetProgressBackgroundColorSchemeResource_IHandler()
		{
			if ((object)cb_setProgressBackgroundColorSchemeResource_I == null)
			{
				cb_setProgressBackgroundColorSchemeResource_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetProgressBackgroundColorSchemeResource_I));
			}
			return cb_setProgressBackgroundColorSchemeResource_I;
		}

		private static void n_SetProgressBackgroundColorSchemeResource_I(IntPtr jnienv, IntPtr native__this, int colorRes)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetProgressBackgroundColorSchemeResource(colorRes);
		}

		[Register("setProgressBackgroundColorSchemeResource", "(I)V", "GetSetProgressBackgroundColorSchemeResource_IHandler")]
		public unsafe virtual void SetProgressBackgroundColorSchemeResource(int colorRes)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(colorRes);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressBackgroundColorSchemeResource.(I)V", this, ptr);
		}

		private static Delegate GetSetProgressViewEndTarget_ZIHandler()
		{
			if ((object)cb_setProgressViewEndTarget_ZI == null)
			{
				cb_setProgressViewEndTarget_ZI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZI_V(n_SetProgressViewEndTarget_ZI));
			}
			return cb_setProgressViewEndTarget_ZI;
		}

		private static void n_SetProgressViewEndTarget_ZI(IntPtr jnienv, IntPtr native__this, bool scale, int end)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetProgressViewEndTarget(scale, end);
		}

		[Register("setProgressViewEndTarget", "(ZI)V", "GetSetProgressViewEndTarget_ZIHandler")]
		public unsafe virtual void SetProgressViewEndTarget(bool scale, int end)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(scale);
			ptr[1] = new JniArgumentValue(end);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressViewEndTarget.(ZI)V", this, ptr);
		}

		private static Delegate GetSetProgressViewOffset_ZIIHandler()
		{
			if ((object)cb_setProgressViewOffset_ZII == null)
			{
				cb_setProgressViewOffset_ZII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZII_V(n_SetProgressViewOffset_ZII));
			}
			return cb_setProgressViewOffset_ZII;
		}

		private static void n_SetProgressViewOffset_ZII(IntPtr jnienv, IntPtr native__this, bool scale, int start, int end)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetProgressViewOffset(scale, start, end);
		}

		[Register("setProgressViewOffset", "(ZII)V", "GetSetProgressViewOffset_ZIIHandler")]
		public unsafe virtual void SetProgressViewOffset(bool scale, int start, int end)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(scale);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressViewOffset.(ZII)V", this, ptr);
		}

		private static Delegate GetSetSize_IHandler()
		{
			if ((object)cb_setSize_I == null)
			{
				cb_setSize_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetSize_I));
			}
			return cb_setSize_I;
		}

		private static void n_SetSize_I(IntPtr jnienv, IntPtr native__this, int size)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSize(size);
		}

		[Register("setSize", "(I)V", "GetSetSize_IHandler")]
		public unsafe virtual void SetSize(int size)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(size);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSize.(I)V", this, ptr);
		}

		private static Delegate GetSetSlingshotDistance_IHandler()
		{
			if ((object)cb_setSlingshotDistance_I == null)
			{
				cb_setSlingshotDistance_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetSlingshotDistance_I));
			}
			return cb_setSlingshotDistance_I;
		}

		private static void n_SetSlingshotDistance_I(IntPtr jnienv, IntPtr native__this, int slingshotDistance)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSlingshotDistance(slingshotDistance);
		}

		[Register("setSlingshotDistance", "(I)V", "GetSetSlingshotDistance_IHandler")]
		public unsafe virtual void SetSlingshotDistance(int slingshotDistance)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(slingshotDistance);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSlingshotDistance.(I)V", this, ptr);
		}

		private static Delegate GetStartNestedScroll_IIHandler()
		{
			if ((object)cb_startNestedScroll_II == null)
			{
				cb_startNestedScroll_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_Z(n_StartNestedScroll_II));
			}
			return cb_startNestedScroll_II;
		}

		private static bool n_StartNestedScroll_II(IntPtr jnienv, IntPtr native__this, int native_axes, int type)
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartNestedScroll((ScrollAxis)native_axes, type);
		}

		[Register("startNestedScroll", "(II)Z", "GetStartNestedScroll_IIHandler")]
		public unsafe virtual bool StartNestedScroll([GeneratedEnum] ScrollAxis axes, int type)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)axes);
			ptr[1] = new JniArgumentValue(type);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("startNestedScroll.(II)Z", this, ptr);
		}

		private static Delegate GetStopNestedScroll_IHandler()
		{
			if ((object)cb_stopNestedScroll_I == null)
			{
				cb_stopNestedScroll_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_StopNestedScroll_I));
			}
			return cb_stopNestedScroll_I;
		}

		private static void n_StopNestedScroll_I(IntPtr jnienv, IntPtr native__this, int type)
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopNestedScroll(type);
		}

		[Register("stopNestedScroll", "(I)V", "GetStopNestedScroll_IHandler")]
		public unsafe virtual void StopNestedScroll(int type)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("stopNestedScroll.(I)V", this, ptr);
		}

		private IOnRefreshListenerImplementor __CreateIOnRefreshListenerImplementor()
		{
			return new IOnRefreshListenerImplementor(this);
		}
	}
}
