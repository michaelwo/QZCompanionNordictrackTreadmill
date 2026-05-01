using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Animation;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
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
[assembly: NamespaceMapping(Java = "androidx.transition", Managed = "AndroidX.Transitions")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.transition:transition'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Transition")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Transition")]
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
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPFFFF_L(IntPtr jnienv, IntPtr klass, float p0, float p1, float p2, float p3);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPIZ_L(IntPtr jnienv, IntPtr klass, int p0, bool p1);
internal delegate IntPtr _JniMarshal_PPJ_L(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate bool _JniMarshal_PPLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate long _JniMarshal_PPLLLL_J(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate IntPtr _JniMarshal_PPLZ_L(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
namespace AndroidX.Transitions
{
	[Register("androidx/transition/AutoTransition", DoNotGenerateAcw = true)]
	public class AutoTransition : TransitionSet
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/AutoTransition", typeof(AutoTransition));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected AutoTransition(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AutoTransition()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe AutoTransition(Context context, IAttributeSet attrs)
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
	}
	[Register("androidx/transition/PathMotion", DoNotGenerateAcw = true)]
	public abstract class PathMotion : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/PathMotion", typeof(PathMotion));

		private static Delegate cb_getPath_FFFF;

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

		protected PathMotion(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PathMotion()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe PathMotion(Context context, IAttributeSet attrs)
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

		private static Delegate GetGetPath_FFFFHandler()
		{
			if ((object)cb_getPath_FFFF == null)
			{
				cb_getPath_FFFF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPFFFF_L(n_GetPath_FFFF));
			}
			return cb_getPath_FFFF;
		}

		private static IntPtr n_GetPath_FFFF(IntPtr jnienv, IntPtr native__this, float startX, float startY, float endX, float endY)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PathMotion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPath(startX, startY, endX, endY));
		}

		[Register("getPath", "(FFFF)Landroid/graphics/Path;", "GetGetPath_FFFFHandler")]
		public abstract Path GetPath(float startX, float startY, float endX, float endY);
	}
	[Register("androidx/transition/PathMotion", DoNotGenerateAcw = true)]
	internal class PathMotionInvoker : PathMotion
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/PathMotion", typeof(PathMotionInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public PathMotionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getPath", "(FFFF)Landroid/graphics/Path;", "GetGetPath_FFFFHandler")]
		public unsafe override Path GetPath(float startX, float startY, float endX, float endY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(startX);
			ptr[1] = new JniArgumentValue(startY);
			ptr[2] = new JniArgumentValue(endX);
			ptr[3] = new JniArgumentValue(endY);
			return Java.Lang.Object.GetObject<Path>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPath.(FFFF)Landroid/graphics/Path;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/transition/Scene", DoNotGenerateAcw = true)]
	public class Scene : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/Scene", typeof(Scene));

		private static Delegate cb_getSceneRoot;

		private static Delegate cb_enter;

		private static Delegate cb_exit;

		private static Delegate cb_setEnterAction_Ljava_lang_Runnable_;

		private static Delegate cb_setExitAction_Ljava_lang_Runnable_;

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

		public unsafe virtual ViewGroup SceneRoot
		{
			[Register("getSceneRoot", "()Landroid/view/ViewGroup;", "GetGetSceneRootHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ViewGroup>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSceneRoot.()Landroid/view/ViewGroup;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Scene(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/view/ViewGroup;)V", "")]
		public unsafe Scene(ViewGroup sceneRoot)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup;Landroid/view/View;)V", "")]
		public unsafe Scene(ViewGroup sceneRoot, View layout)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup;Landroid/view/View;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup;Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
				GC.KeepAlive(layout);
			}
		}

		private static Delegate GetGetSceneRootHandler()
		{
			if ((object)cb_getSceneRoot == null)
			{
				cb_getSceneRoot = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSceneRoot));
			}
			return cb_getSceneRoot;
		}

		private static IntPtr n_GetSceneRoot(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Scene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SceneRoot);
		}

		private static Delegate GetEnterHandler()
		{
			if ((object)cb_enter == null)
			{
				cb_enter = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Enter));
			}
			return cb_enter;
		}

		private static void n_Enter(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Scene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Enter();
		}

		[Register("enter", "()V", "GetEnterHandler")]
		public unsafe virtual void Enter()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("enter.()V", this, null);
		}

		private static Delegate GetExitHandler()
		{
			if ((object)cb_exit == null)
			{
				cb_exit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Exit));
			}
			return cb_exit;
		}

		private static void n_Exit(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Scene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Exit();
		}

		[Register("exit", "()V", "GetExitHandler")]
		public unsafe virtual void Exit()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("exit.()V", this, null);
		}

		[Register("getCurrentScene", "(Landroid/view/ViewGroup;)Landroidx/transition/Scene;", "")]
		public unsafe static Scene GetCurrentScene(ViewGroup sceneRoot)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Scene>(_members.StaticMethods.InvokeObjectMethod("getCurrentScene.(Landroid/view/ViewGroup;)Landroidx/transition/Scene;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
			}
		}

		[Register("getSceneForLayout", "(Landroid/view/ViewGroup;ILandroid/content/Context;)Landroidx/transition/Scene;", "")]
		public unsafe static Scene GetSceneForLayout(ViewGroup sceneRoot, int layoutId, Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(layoutId);
				ptr[2] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Scene>(_members.StaticMethods.InvokeObjectMethod("getSceneForLayout.(Landroid/view/ViewGroup;ILandroid/content/Context;)Landroidx/transition/Scene;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetSetEnterAction_Ljava_lang_Runnable_Handler()
		{
			if ((object)cb_setEnterAction_Ljava_lang_Runnable_ == null)
			{
				cb_setEnterAction_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetEnterAction_Ljava_lang_Runnable_));
			}
			return cb_setEnterAction_Ljava_lang_Runnable_;
		}

		private static void n_SetEnterAction_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_action)
		{
			Scene scene = Java.Lang.Object.GetObject<Scene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable enterAction = Java.Lang.Object.GetObject<IRunnable>(native_action, JniHandleOwnership.DoNotTransfer);
			scene.SetEnterAction(enterAction);
		}

		[Register("setEnterAction", "(Ljava/lang/Runnable;)V", "GetSetEnterAction_Ljava_lang_Runnable_Handler")]
		public unsafe virtual void SetEnterAction(IRunnable action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEnterAction.(Ljava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(action);
			}
		}

		private static Delegate GetSetExitAction_Ljava_lang_Runnable_Handler()
		{
			if ((object)cb_setExitAction_Ljava_lang_Runnable_ == null)
			{
				cb_setExitAction_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetExitAction_Ljava_lang_Runnable_));
			}
			return cb_setExitAction_Ljava_lang_Runnable_;
		}

		private static void n_SetExitAction_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_action)
		{
			Scene scene = Java.Lang.Object.GetObject<Scene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable exitAction = Java.Lang.Object.GetObject<IRunnable>(native_action, JniHandleOwnership.DoNotTransfer);
			scene.SetExitAction(exitAction);
		}

		[Register("setExitAction", "(Ljava/lang/Runnable;)V", "GetSetExitAction_Ljava_lang_Runnable_Handler")]
		public unsafe virtual void SetExitAction(IRunnable action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setExitAction.(Ljava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(action);
			}
		}
	}
	[Register("androidx/transition/Transition", DoNotGenerateAcw = true)]
	public abstract class Transition : Java.Lang.Object
	{
		[Register("androidx/transition/Transition$EpicenterCallback", DoNotGenerateAcw = true)]
		public abstract class EpicenterCallback : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/Transition$EpicenterCallback", typeof(EpicenterCallback));

			private static Delegate cb_onGetEpicenter_Landroidx_transition_Transition_;

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

			protected EpicenterCallback(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe EpicenterCallback()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetOnGetEpicenter_Landroidx_transition_Transition_Handler()
			{
				if ((object)cb_onGetEpicenter_Landroidx_transition_Transition_ == null)
				{
					cb_onGetEpicenter_Landroidx_transition_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnGetEpicenter_Landroidx_transition_Transition_));
				}
				return cb_onGetEpicenter_Landroidx_transition_Transition_;
			}

			private static IntPtr n_OnGetEpicenter_Landroidx_transition_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
			{
				EpicenterCallback epicenterCallback = Java.Lang.Object.GetObject<EpicenterCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(epicenterCallback.OnGetEpicenter(transition));
			}

			[Register("onGetEpicenter", "(Landroidx/transition/Transition;)Landroid/graphics/Rect;", "GetOnGetEpicenter_Landroidx_transition_Transition_Handler")]
			public abstract Rect OnGetEpicenter(Transition transition);
		}

		[Register("androidx/transition/Transition$EpicenterCallback", DoNotGenerateAcw = true)]
		internal class EpicenterCallbackInvoker : EpicenterCallback
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/Transition$EpicenterCallback", typeof(EpicenterCallbackInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public EpicenterCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("onGetEpicenter", "(Landroidx/transition/Transition;)Landroid/graphics/Rect;", "GetOnGetEpicenter_Landroidx_transition_Transition_Handler")]
			public unsafe override Rect OnGetEpicenter(Transition transition)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeAbstractObjectMethod("onGetEpicenter.(Landroidx/transition/Transition;)Landroid/graphics/Rect;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(transition);
				}
			}
		}

		[Register("androidx/transition/Transition$TransitionListener", "", "AndroidX.Transitions.Transition/ITransitionListenerInvoker")]
		public interface ITransitionListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onTransitionCancel", "(Landroidx/transition/Transition;)V", "GetOnTransitionCancel_Landroidx_transition_Transition_Handler:AndroidX.Transitions.Transition/ITransitionListenerInvoker, Xamarin.AndroidX.Transition")]
			void OnTransitionCancel(Transition transition);

			[Register("onTransitionEnd", "(Landroidx/transition/Transition;)V", "GetOnTransitionEnd_Landroidx_transition_Transition_Handler:AndroidX.Transitions.Transition/ITransitionListenerInvoker, Xamarin.AndroidX.Transition")]
			void OnTransitionEnd(Transition transition);

			[Register("onTransitionPause", "(Landroidx/transition/Transition;)V", "GetOnTransitionPause_Landroidx_transition_Transition_Handler:AndroidX.Transitions.Transition/ITransitionListenerInvoker, Xamarin.AndroidX.Transition")]
			void OnTransitionPause(Transition transition);

			[Register("onTransitionResume", "(Landroidx/transition/Transition;)V", "GetOnTransitionResume_Landroidx_transition_Transition_Handler:AndroidX.Transitions.Transition/ITransitionListenerInvoker, Xamarin.AndroidX.Transition")]
			void OnTransitionResume(Transition transition);

			[Register("onTransitionStart", "(Landroidx/transition/Transition;)V", "GetOnTransitionStart_Landroidx_transition_Transition_Handler:AndroidX.Transitions.Transition/ITransitionListenerInvoker, Xamarin.AndroidX.Transition")]
			void OnTransitionStart(Transition transition);
		}

		[Register("androidx/transition/Transition$TransitionListener", DoNotGenerateAcw = true)]
		internal class ITransitionListenerInvoker : Java.Lang.Object, ITransitionListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/Transition$TransitionListener", typeof(ITransitionListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onTransitionCancel_Landroidx_transition_Transition_;

			private IntPtr id_onTransitionCancel_Landroidx_transition_Transition_;

			private static Delegate cb_onTransitionEnd_Landroidx_transition_Transition_;

			private IntPtr id_onTransitionEnd_Landroidx_transition_Transition_;

			private static Delegate cb_onTransitionPause_Landroidx_transition_Transition_;

			private IntPtr id_onTransitionPause_Landroidx_transition_Transition_;

			private static Delegate cb_onTransitionResume_Landroidx_transition_Transition_;

			private IntPtr id_onTransitionResume_Landroidx_transition_Transition_;

			private static Delegate cb_onTransitionStart_Landroidx_transition_Transition_;

			private IntPtr id_onTransitionStart_Landroidx_transition_Transition_;

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

			public static ITransitionListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ITransitionListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.transition.Transition.TransitionListener'.");
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

			public ITransitionListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnTransitionCancel_Landroidx_transition_Transition_Handler()
			{
				if ((object)cb_onTransitionCancel_Landroidx_transition_Transition_ == null)
				{
					cb_onTransitionCancel_Landroidx_transition_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnTransitionCancel_Landroidx_transition_Transition_));
				}
				return cb_onTransitionCancel_Landroidx_transition_Transition_;
			}

			private static void n_OnTransitionCancel_Landroidx_transition_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
			{
				ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionCancel(transition);
			}

			public unsafe void OnTransitionCancel(Transition transition)
			{
				if (id_onTransitionCancel_Landroidx_transition_Transition_ == IntPtr.Zero)
				{
					id_onTransitionCancel_Landroidx_transition_Transition_ = JNIEnv.GetMethodID(class_ref, "onTransitionCancel", "(Landroidx/transition/Transition;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(transition?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onTransitionCancel_Landroidx_transition_Transition_, ptr);
			}

			private static Delegate GetOnTransitionEnd_Landroidx_transition_Transition_Handler()
			{
				if ((object)cb_onTransitionEnd_Landroidx_transition_Transition_ == null)
				{
					cb_onTransitionEnd_Landroidx_transition_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnTransitionEnd_Landroidx_transition_Transition_));
				}
				return cb_onTransitionEnd_Landroidx_transition_Transition_;
			}

			private static void n_OnTransitionEnd_Landroidx_transition_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
			{
				ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionEnd(transition);
			}

			public unsafe void OnTransitionEnd(Transition transition)
			{
				if (id_onTransitionEnd_Landroidx_transition_Transition_ == IntPtr.Zero)
				{
					id_onTransitionEnd_Landroidx_transition_Transition_ = JNIEnv.GetMethodID(class_ref, "onTransitionEnd", "(Landroidx/transition/Transition;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(transition?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onTransitionEnd_Landroidx_transition_Transition_, ptr);
			}

			private static Delegate GetOnTransitionPause_Landroidx_transition_Transition_Handler()
			{
				if ((object)cb_onTransitionPause_Landroidx_transition_Transition_ == null)
				{
					cb_onTransitionPause_Landroidx_transition_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnTransitionPause_Landroidx_transition_Transition_));
				}
				return cb_onTransitionPause_Landroidx_transition_Transition_;
			}

			private static void n_OnTransitionPause_Landroidx_transition_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
			{
				ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionPause(transition);
			}

			public unsafe void OnTransitionPause(Transition transition)
			{
				if (id_onTransitionPause_Landroidx_transition_Transition_ == IntPtr.Zero)
				{
					id_onTransitionPause_Landroidx_transition_Transition_ = JNIEnv.GetMethodID(class_ref, "onTransitionPause", "(Landroidx/transition/Transition;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(transition?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onTransitionPause_Landroidx_transition_Transition_, ptr);
			}

			private static Delegate GetOnTransitionResume_Landroidx_transition_Transition_Handler()
			{
				if ((object)cb_onTransitionResume_Landroidx_transition_Transition_ == null)
				{
					cb_onTransitionResume_Landroidx_transition_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnTransitionResume_Landroidx_transition_Transition_));
				}
				return cb_onTransitionResume_Landroidx_transition_Transition_;
			}

			private static void n_OnTransitionResume_Landroidx_transition_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
			{
				ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionResume(transition);
			}

			public unsafe void OnTransitionResume(Transition transition)
			{
				if (id_onTransitionResume_Landroidx_transition_Transition_ == IntPtr.Zero)
				{
					id_onTransitionResume_Landroidx_transition_Transition_ = JNIEnv.GetMethodID(class_ref, "onTransitionResume", "(Landroidx/transition/Transition;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(transition?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onTransitionResume_Landroidx_transition_Transition_, ptr);
			}

			private static Delegate GetOnTransitionStart_Landroidx_transition_Transition_Handler()
			{
				if ((object)cb_onTransitionStart_Landroidx_transition_Transition_ == null)
				{
					cb_onTransitionStart_Landroidx_transition_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnTransitionStart_Landroidx_transition_Transition_));
				}
				return cb_onTransitionStart_Landroidx_transition_Transition_;
			}

			private static void n_OnTransitionStart_Landroidx_transition_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
			{
				ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionStart(transition);
			}

			public unsafe void OnTransitionStart(Transition transition)
			{
				if (id_onTransitionStart_Landroidx_transition_Transition_ == IntPtr.Zero)
				{
					id_onTransitionStart_Landroidx_transition_Transition_ = JNIEnv.GetMethodID(class_ref, "onTransitionStart", "(Landroidx/transition/Transition;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(transition?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onTransitionStart_Landroidx_transition_Transition_, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/Transition", typeof(Transition));

		private static Delegate cb_getDuration;

		private static Delegate cb_getEpicenter;

		private static Delegate cb_getInterpolator;

		private static Delegate cb_getName;

		private static Delegate cb_getPathMotion;

		private static Delegate cb_setPathMotion_Landroidx_transition_PathMotion_;

		private static Delegate cb_getPropagation;

		private static Delegate cb_setPropagation_Landroidx_transition_TransitionPropagation_;

		private static Delegate cb_getStartDelay;

		private static Delegate cb_getTargetIds;

		private static Delegate cb_getTargetNames;

		private static Delegate cb_getTargetTypes;

		private static Delegate cb_getTargets;

		private static Delegate cb_addListener_Landroidx_transition_Transition_TransitionListener_;

		private static Delegate cb_addTarget_Landroid_view_View_;

		private static Delegate cb_addTarget_I;

		private static Delegate cb_addTarget_Ljava_lang_Class_;

		private static Delegate cb_addTarget_Ljava_lang_String_;

		private static Delegate cb_animate_Landroid_animation_Animator_;

		private static Delegate cb_cancel;

		private static Delegate cb_captureEndValues_Landroidx_transition_TransitionValues_;

		private static Delegate cb_captureStartValues_Landroidx_transition_TransitionValues_;

		private static Delegate cb_clone;

		private static Delegate cb_createAnimator_Landroid_view_ViewGroup_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_;

		private static Delegate cb_end;

		private static Delegate cb_excludeChildren_Landroid_view_View_Z;

		private static Delegate cb_excludeChildren_IZ;

		private static Delegate cb_excludeChildren_Ljava_lang_Class_Z;

		private static Delegate cb_excludeTarget_Landroid_view_View_Z;

		private static Delegate cb_excludeTarget_IZ;

		private static Delegate cb_excludeTarget_Ljava_lang_Class_Z;

		private static Delegate cb_excludeTarget_Ljava_lang_String_Z;

		private static Delegate cb_getEpicenterCallback;

		private static Delegate cb_getTransitionProperties;

		private static Delegate cb_getTransitionValues_Landroid_view_View_Z;

		private static Delegate cb_isTransitionRequired_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_;

		private static Delegate cb_pause_Landroid_view_View_;

		private static Delegate cb_removeListener_Landroidx_transition_Transition_TransitionListener_;

		private static Delegate cb_removeTarget_Landroid_view_View_;

		private static Delegate cb_removeTarget_I;

		private static Delegate cb_removeTarget_Ljava_lang_Class_;

		private static Delegate cb_removeTarget_Ljava_lang_String_;

		private static Delegate cb_resume_Landroid_view_View_;

		private static Delegate cb_runAnimators;

		private static Delegate cb_setDuration_J;

		private static Delegate cb_setEpicenterCallback_Landroidx_transition_Transition_EpicenterCallback_;

		private static Delegate cb_setInterpolator_Landroid_animation_TimeInterpolator_;

		private static Delegate cb_setMatchOrder_arrayI;

		private static Delegate cb_setStartDelay_J;

		private static Delegate cb_start;

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

		public unsafe virtual long Duration
		{
			[Register("getDuration", "()J", "GetGetDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getDuration.()J", this, null);
			}
		}

		public unsafe virtual Rect Epicenter
		{
			[Register("getEpicenter", "()Landroid/graphics/Rect;", "GetGetEpicenterHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEpicenter.()Landroid/graphics/Rect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

		public unsafe virtual string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual PathMotion PathMotion
		{
			[Register("getPathMotion", "()Landroidx/transition/PathMotion;", "GetGetPathMotionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<PathMotion>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPathMotion.()Landroidx/transition/PathMotion;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPathMotion", "(Landroidx/transition/PathMotion;)V", "GetSetPathMotion_Landroidx_transition_PathMotion_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setPathMotion.(Landroidx/transition/PathMotion;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual TransitionPropagation Propagation
		{
			[Register("getPropagation", "()Landroidx/transition/TransitionPropagation;", "GetGetPropagationHandler")]
			get
			{
				return Java.Lang.Object.GetObject<TransitionPropagation>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPropagation.()Landroidx/transition/TransitionPropagation;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPropagation", "(Landroidx/transition/TransitionPropagation;)V", "GetSetPropagation_Landroidx_transition_TransitionPropagation_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setPropagation.(Landroidx/transition/TransitionPropagation;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual long StartDelay
		{
			[Register("getStartDelay", "()J", "GetGetStartDelayHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getStartDelay.()J", this, null);
			}
		}

		public unsafe virtual IList<Integer> TargetIds
		{
			[Register("getTargetIds", "()Ljava/util/List;", "GetGetTargetIdsHandler")]
			get
			{
				return JavaList<Integer>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetIds.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<string> TargetNames
		{
			[Register("getTargetNames", "()Ljava/util/List;", "GetGetTargetNamesHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetNames.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<Class> TargetTypes
		{
			[Register("getTargetTypes", "()Ljava/util/List;", "GetGetTargetTypesHandler")]
			get
			{
				return JavaList<Class>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetTypes.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<View> Targets
		{
			[Register("getTargets", "()Ljava/util/List;", "GetGetTargetsHandler")]
			get
			{
				return JavaList<View>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargets.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Transition(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Transition()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe Transition(Context context, IAttributeSet attrs)
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

		private static Delegate GetGetDurationHandler()
		{
			if ((object)cb_getDuration == null)
			{
				cb_getDuration = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetDuration));
			}
			return cb_getDuration;
		}

		private static long n_GetDuration(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
		}

		private static Delegate GetGetEpicenterHandler()
		{
			if ((object)cb_getEpicenter == null)
			{
				cb_getEpicenter = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEpicenter));
			}
			return cb_getEpicenter;
		}

		private static IntPtr n_GetEpicenter(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Epicenter);
		}

		private static Delegate GetGetInterpolatorHandler()
		{
			if ((object)cb_getInterpolator == null)
			{
				cb_getInterpolator = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInterpolator));
			}
			return cb_getInterpolator;
		}

		private static IntPtr n_GetInterpolator(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolator);
		}

		private static Delegate GetGetNameHandler()
		{
			if ((object)cb_getName == null)
			{
				cb_getName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetName));
			}
			return cb_getName;
		}

		private static IntPtr n_GetName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
		}

		private static Delegate GetGetPathMotionHandler()
		{
			if ((object)cb_getPathMotion == null)
			{
				cb_getPathMotion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPathMotion));
			}
			return cb_getPathMotion;
		}

		private static IntPtr n_GetPathMotion(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PathMotion);
		}

		private static Delegate GetSetPathMotion_Landroidx_transition_PathMotion_Handler()
		{
			if ((object)cb_setPathMotion_Landroidx_transition_PathMotion_ == null)
			{
				cb_setPathMotion_Landroidx_transition_PathMotion_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPathMotion_Landroidx_transition_PathMotion_));
			}
			return cb_setPathMotion_Landroidx_transition_PathMotion_;
		}

		private static void n_SetPathMotion_Landroidx_transition_PathMotion_(IntPtr jnienv, IntPtr native__this, IntPtr native_pathMotion)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PathMotion pathMotion = Java.Lang.Object.GetObject<PathMotion>(native_pathMotion, JniHandleOwnership.DoNotTransfer);
			transition.PathMotion = pathMotion;
		}

		private static Delegate GetGetPropagationHandler()
		{
			if ((object)cb_getPropagation == null)
			{
				cb_getPropagation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPropagation));
			}
			return cb_getPropagation;
		}

		private static IntPtr n_GetPropagation(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Propagation);
		}

		private static Delegate GetSetPropagation_Landroidx_transition_TransitionPropagation_Handler()
		{
			if ((object)cb_setPropagation_Landroidx_transition_TransitionPropagation_ == null)
			{
				cb_setPropagation_Landroidx_transition_TransitionPropagation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPropagation_Landroidx_transition_TransitionPropagation_));
			}
			return cb_setPropagation_Landroidx_transition_TransitionPropagation_;
		}

		private static void n_SetPropagation_Landroidx_transition_TransitionPropagation_(IntPtr jnienv, IntPtr native__this, IntPtr native_transitionPropagation)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransitionPropagation propagation = Java.Lang.Object.GetObject<TransitionPropagation>(native_transitionPropagation, JniHandleOwnership.DoNotTransfer);
			transition.Propagation = propagation;
		}

		private static Delegate GetGetStartDelayHandler()
		{
			if ((object)cb_getStartDelay == null)
			{
				cb_getStartDelay = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetStartDelay));
			}
			return cb_getStartDelay;
		}

		private static long n_GetStartDelay(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartDelay;
		}

		private static Delegate GetGetTargetIdsHandler()
		{
			if ((object)cb_getTargetIds == null)
			{
				cb_getTargetIds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTargetIds));
			}
			return cb_getTargetIds;
		}

		private static IntPtr n_GetTargetIds(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<Integer>.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetIds);
		}

		private static Delegate GetGetTargetNamesHandler()
		{
			if ((object)cb_getTargetNames == null)
			{
				cb_getTargetNames = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTargetNames));
			}
			return cb_getTargetNames;
		}

		private static IntPtr n_GetTargetNames(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetNames);
		}

		private static Delegate GetGetTargetTypesHandler()
		{
			if ((object)cb_getTargetTypes == null)
			{
				cb_getTargetTypes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTargetTypes));
			}
			return cb_getTargetTypes;
		}

		private static IntPtr n_GetTargetTypes(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<Class>.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetTypes);
		}

		private static Delegate GetGetTargetsHandler()
		{
			if ((object)cb_getTargets == null)
			{
				cb_getTargets = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTargets));
			}
			return cb_getTargets;
		}

		private static IntPtr n_GetTargets(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<View>.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Targets);
		}

		private static Delegate GetAddListener_Landroidx_transition_Transition_TransitionListener_Handler()
		{
			if ((object)cb_addListener_Landroidx_transition_Transition_TransitionListener_ == null)
			{
				cb_addListener_Landroidx_transition_Transition_TransitionListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddListener_Landroidx_transition_Transition_TransitionListener_));
			}
			return cb_addListener_Landroidx_transition_Transition_TransitionListener_;
		}

		private static IntPtr n_AddListener_Landroidx_transition_Transition_TransitionListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransitionListener listener = Java.Lang.Object.GetObject<ITransitionListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.AddListener(listener));
		}

		[Register("addListener", "(Landroidx/transition/Transition$TransitionListener;)Landroidx/transition/Transition;", "GetAddListener_Landroidx_transition_Transition_TransitionListener_Handler")]
		public unsafe virtual Transition AddListener(ITransitionListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("addListener.(Landroidx/transition/Transition$TransitionListener;)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetAddTarget_Landroid_view_View_Handler()
		{
			if ((object)cb_addTarget_Landroid_view_View_ == null)
			{
				cb_addTarget_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddTarget_Landroid_view_View_));
			}
			return cb_addTarget_Landroid_view_View_;
		}

		private static IntPtr n_AddTarget_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_target)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.AddTarget(target));
		}

		[Register("addTarget", "(Landroid/view/View;)Landroidx/transition/Transition;", "GetAddTarget_Landroid_view_View_Handler")]
		public unsafe virtual Transition AddTarget(View target)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("addTarget.(Landroid/view/View;)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetAddTarget_IHandler()
		{
			if ((object)cb_addTarget_I == null)
			{
				cb_addTarget_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_AddTarget_I));
			}
			return cb_addTarget_I;
		}

		private static IntPtr n_AddTarget_I(IntPtr jnienv, IntPtr native__this, int targetId)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddTarget(targetId));
		}

		[Register("addTarget", "(I)Landroidx/transition/Transition;", "GetAddTarget_IHandler")]
		public unsafe virtual Transition AddTarget(int targetId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(targetId);
			return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("addTarget.(I)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAddTarget_Ljava_lang_Class_Handler()
		{
			if ((object)cb_addTarget_Ljava_lang_Class_ == null)
			{
				cb_addTarget_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddTarget_Ljava_lang_Class_));
			}
			return cb_addTarget_Ljava_lang_Class_;
		}

		private static IntPtr n_AddTarget_Ljava_lang_Class_(IntPtr jnienv, IntPtr native__this, IntPtr native_targetType)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class targetType = Java.Lang.Object.GetObject<Class>(native_targetType, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.AddTarget(targetType));
		}

		[Register("addTarget", "(Ljava/lang/Class;)Landroidx/transition/Transition;", "GetAddTarget_Ljava_lang_Class_Handler")]
		public unsafe virtual Transition AddTarget(Class targetType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(targetType?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("addTarget.(Ljava/lang/Class;)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(targetType);
			}
		}

		private static Delegate GetAddTarget_Ljava_lang_String_Handler()
		{
			if ((object)cb_addTarget_Ljava_lang_String_ == null)
			{
				cb_addTarget_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddTarget_Ljava_lang_String_));
			}
			return cb_addTarget_Ljava_lang_String_;
		}

		private static IntPtr n_AddTarget_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_targetName)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string targetName = JNIEnv.GetString(native_targetName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.AddTarget(targetName));
		}

		[Register("addTarget", "(Ljava/lang/String;)Landroidx/transition/Transition;", "GetAddTarget_Ljava_lang_String_Handler")]
		public unsafe virtual Transition AddTarget(string targetName)
		{
			IntPtr intPtr = JNIEnv.NewString(targetName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("addTarget.(Ljava/lang/String;)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetAnimate_Landroid_animation_Animator_Handler()
		{
			if ((object)cb_animate_Landroid_animation_Animator_ == null)
			{
				cb_animate_Landroid_animation_Animator_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Animate_Landroid_animation_Animator_));
			}
			return cb_animate_Landroid_animation_Animator_;
		}

		private static void n_Animate_Landroid_animation_Animator_(IntPtr jnienv, IntPtr native__this, IntPtr native_animator)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator animator = Java.Lang.Object.GetObject<Animator>(native_animator, JniHandleOwnership.DoNotTransfer);
			transition.Animate(animator);
		}

		[Register("animate", "(Landroid/animation/Animator;)V", "GetAnimate_Landroid_animation_Animator_Handler")]
		protected unsafe virtual void Animate(Animator animator)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(animator?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("animate.(Landroid/animation/Animator;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(animator);
			}
		}

		private static Delegate GetCancelHandler()
		{
			if ((object)cb_cancel == null)
			{
				cb_cancel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Cancel));
			}
			return cb_cancel;
		}

		private static void n_Cancel(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		protected unsafe virtual void Cancel()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("cancel.()V", this, null);
		}

		private static Delegate GetCaptureEndValues_Landroidx_transition_TransitionValues_Handler()
		{
			if ((object)cb_captureEndValues_Landroidx_transition_TransitionValues_ == null)
			{
				cb_captureEndValues_Landroidx_transition_TransitionValues_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CaptureEndValues_Landroidx_transition_TransitionValues_));
			}
			return cb_captureEndValues_Landroidx_transition_TransitionValues_;
		}

		private static void n_CaptureEndValues_Landroidx_transition_TransitionValues_(IntPtr jnienv, IntPtr native__this, IntPtr native_transitionValues)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransitionValues transitionValues = Java.Lang.Object.GetObject<TransitionValues>(native_transitionValues, JniHandleOwnership.DoNotTransfer);
			transition.CaptureEndValues(transitionValues);
		}

		[Register("captureEndValues", "(Landroidx/transition/TransitionValues;)V", "GetCaptureEndValues_Landroidx_transition_TransitionValues_Handler")]
		public abstract void CaptureEndValues(TransitionValues transitionValues);

		private static Delegate GetCaptureStartValues_Landroidx_transition_TransitionValues_Handler()
		{
			if ((object)cb_captureStartValues_Landroidx_transition_TransitionValues_ == null)
			{
				cb_captureStartValues_Landroidx_transition_TransitionValues_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CaptureStartValues_Landroidx_transition_TransitionValues_));
			}
			return cb_captureStartValues_Landroidx_transition_TransitionValues_;
		}

		private static void n_CaptureStartValues_Landroidx_transition_TransitionValues_(IntPtr jnienv, IntPtr native__this, IntPtr native_transitionValues)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransitionValues transitionValues = Java.Lang.Object.GetObject<TransitionValues>(native_transitionValues, JniHandleOwnership.DoNotTransfer);
			transition.CaptureStartValues(transitionValues);
		}

		[Register("captureStartValues", "(Landroidx/transition/TransitionValues;)V", "GetCaptureStartValues_Landroidx_transition_TransitionValues_Handler")]
		public abstract void CaptureStartValues(TransitionValues transitionValues);

		private static Delegate GetCloneHandler()
		{
			if ((object)cb_clone == null)
			{
				cb_clone = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Clone));
			}
			return cb_clone;
		}

		private static IntPtr n_Clone(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
		}

		[Register("clone", "()Landroidx/transition/Transition;", "GetCloneHandler")]
		public new unsafe virtual Transition Clone()
		{
			return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Landroidx/transition/Transition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetCreateAnimator_Landroid_view_ViewGroup_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_Handler()
		{
			if ((object)cb_createAnimator_Landroid_view_ViewGroup_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_ == null)
			{
				cb_createAnimator_Landroid_view_ViewGroup_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_CreateAnimator_Landroid_view_ViewGroup_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_));
			}
			return cb_createAnimator_Landroid_view_ViewGroup_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_;
		}

		private static IntPtr n_CreateAnimator_Landroid_view_ViewGroup_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_(IntPtr jnienv, IntPtr native__this, IntPtr native_sceneRoot, IntPtr native_startValues, IntPtr native_endValues)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup sceneRoot = Java.Lang.Object.GetObject<ViewGroup>(native_sceneRoot, JniHandleOwnership.DoNotTransfer);
			TransitionValues startValues = Java.Lang.Object.GetObject<TransitionValues>(native_startValues, JniHandleOwnership.DoNotTransfer);
			TransitionValues endValues = Java.Lang.Object.GetObject<TransitionValues>(native_endValues, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.CreateAnimator(sceneRoot, startValues, endValues));
		}

		[Register("createAnimator", "(Landroid/view/ViewGroup;Landroidx/transition/TransitionValues;Landroidx/transition/TransitionValues;)Landroid/animation/Animator;", "GetCreateAnimator_Landroid_view_ViewGroup_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_Handler")]
		public unsafe virtual Animator CreateAnimator(ViewGroup sceneRoot, TransitionValues startValues, TransitionValues endValues)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(startValues?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(endValues?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Animator>(_members.InstanceMethods.InvokeVirtualObjectMethod("createAnimator.(Landroid/view/ViewGroup;Landroidx/transition/TransitionValues;Landroidx/transition/TransitionValues;)Landroid/animation/Animator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
				GC.KeepAlive(startValues);
				GC.KeepAlive(endValues);
			}
		}

		private static Delegate GetEndHandler()
		{
			if ((object)cb_end == null)
			{
				cb_end = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_End));
			}
			return cb_end;
		}

		private static void n_End(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).End();
		}

		[Register("end", "()V", "GetEndHandler")]
		protected unsafe virtual void End()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("end.()V", this, null);
		}

		private static Delegate GetExcludeChildren_Landroid_view_View_ZHandler()
		{
			if ((object)cb_excludeChildren_Landroid_view_View_Z == null)
			{
				cb_excludeChildren_Landroid_view_View_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_ExcludeChildren_Landroid_view_View_Z));
			}
			return cb_excludeChildren_Landroid_view_View_Z;
		}

		private static IntPtr n_ExcludeChildren_Landroid_view_View_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_target, bool exclude)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.ExcludeChildren(target, exclude));
		}

		[Register("excludeChildren", "(Landroid/view/View;Z)Landroidx/transition/Transition;", "GetExcludeChildren_Landroid_view_View_ZHandler")]
		public unsafe virtual Transition ExcludeChildren(View target, bool exclude)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(exclude);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("excludeChildren.(Landroid/view/View;Z)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetExcludeChildren_IZHandler()
		{
			if ((object)cb_excludeChildren_IZ == null)
			{
				cb_excludeChildren_IZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIZ_L(n_ExcludeChildren_IZ));
			}
			return cb_excludeChildren_IZ;
		}

		private static IntPtr n_ExcludeChildren_IZ(IntPtr jnienv, IntPtr native__this, int targetId, bool exclude)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExcludeChildren(targetId, exclude));
		}

		[Register("excludeChildren", "(IZ)Landroidx/transition/Transition;", "GetExcludeChildren_IZHandler")]
		public unsafe virtual Transition ExcludeChildren(int targetId, bool exclude)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(targetId);
			ptr[1] = new JniArgumentValue(exclude);
			return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("excludeChildren.(IZ)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetExcludeChildren_Ljava_lang_Class_ZHandler()
		{
			if ((object)cb_excludeChildren_Ljava_lang_Class_Z == null)
			{
				cb_excludeChildren_Ljava_lang_Class_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_ExcludeChildren_Ljava_lang_Class_Z));
			}
			return cb_excludeChildren_Ljava_lang_Class_Z;
		}

		private static IntPtr n_ExcludeChildren_Ljava_lang_Class_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_type, bool exclude)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class type = Java.Lang.Object.GetObject<Class>(native_type, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.ExcludeChildren(type, exclude));
		}

		[Register("excludeChildren", "(Ljava/lang/Class;Z)Landroidx/transition/Transition;", "GetExcludeChildren_Ljava_lang_Class_ZHandler")]
		public unsafe virtual Transition ExcludeChildren(Class type, bool exclude)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(exclude);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("excludeChildren.(Ljava/lang/Class;Z)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		private static Delegate GetExcludeTarget_Landroid_view_View_ZHandler()
		{
			if ((object)cb_excludeTarget_Landroid_view_View_Z == null)
			{
				cb_excludeTarget_Landroid_view_View_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_ExcludeTarget_Landroid_view_View_Z));
			}
			return cb_excludeTarget_Landroid_view_View_Z;
		}

		private static IntPtr n_ExcludeTarget_Landroid_view_View_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_target, bool exclude)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.ExcludeTarget(target, exclude));
		}

		[Register("excludeTarget", "(Landroid/view/View;Z)Landroidx/transition/Transition;", "GetExcludeTarget_Landroid_view_View_ZHandler")]
		public unsafe virtual Transition ExcludeTarget(View target, bool exclude)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(exclude);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("excludeTarget.(Landroid/view/View;Z)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetExcludeTarget_IZHandler()
		{
			if ((object)cb_excludeTarget_IZ == null)
			{
				cb_excludeTarget_IZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIZ_L(n_ExcludeTarget_IZ));
			}
			return cb_excludeTarget_IZ;
		}

		private static IntPtr n_ExcludeTarget_IZ(IntPtr jnienv, IntPtr native__this, int targetId, bool exclude)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExcludeTarget(targetId, exclude));
		}

		[Register("excludeTarget", "(IZ)Landroidx/transition/Transition;", "GetExcludeTarget_IZHandler")]
		public unsafe virtual Transition ExcludeTarget(int targetId, bool exclude)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(targetId);
			ptr[1] = new JniArgumentValue(exclude);
			return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("excludeTarget.(IZ)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetExcludeTarget_Ljava_lang_Class_ZHandler()
		{
			if ((object)cb_excludeTarget_Ljava_lang_Class_Z == null)
			{
				cb_excludeTarget_Ljava_lang_Class_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_ExcludeTarget_Ljava_lang_Class_Z));
			}
			return cb_excludeTarget_Ljava_lang_Class_Z;
		}

		private static IntPtr n_ExcludeTarget_Ljava_lang_Class_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_type, bool exclude)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class type = Java.Lang.Object.GetObject<Class>(native_type, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.ExcludeTarget(type, exclude));
		}

		[Register("excludeTarget", "(Ljava/lang/Class;Z)Landroidx/transition/Transition;", "GetExcludeTarget_Ljava_lang_Class_ZHandler")]
		public unsafe virtual Transition ExcludeTarget(Class type, bool exclude)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(exclude);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("excludeTarget.(Ljava/lang/Class;Z)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		private static Delegate GetExcludeTarget_Ljava_lang_String_ZHandler()
		{
			if ((object)cb_excludeTarget_Ljava_lang_String_Z == null)
			{
				cb_excludeTarget_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_ExcludeTarget_Ljava_lang_String_Z));
			}
			return cb_excludeTarget_Ljava_lang_String_Z;
		}

		private static IntPtr n_ExcludeTarget_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_targetName, bool exclude)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string targetName = JNIEnv.GetString(native_targetName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.ExcludeTarget(targetName, exclude));
		}

		[Register("excludeTarget", "(Ljava/lang/String;Z)Landroidx/transition/Transition;", "GetExcludeTarget_Ljava_lang_String_ZHandler")]
		public unsafe virtual Transition ExcludeTarget(string targetName, bool exclude)
		{
			IntPtr intPtr = JNIEnv.NewString(targetName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(exclude);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("excludeTarget.(Ljava/lang/String;Z)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetEpicenterCallbackHandler()
		{
			if ((object)cb_getEpicenterCallback == null)
			{
				cb_getEpicenterCallback = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEpicenterCallback));
			}
			return cb_getEpicenterCallback;
		}

		private static IntPtr n_GetEpicenterCallback(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetEpicenterCallback());
		}

		[Register("getEpicenterCallback", "()Landroidx/transition/Transition$EpicenterCallback;", "GetGetEpicenterCallbackHandler")]
		public unsafe virtual EpicenterCallback GetEpicenterCallback()
		{
			return Java.Lang.Object.GetObject<EpicenterCallback>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEpicenterCallback.()Landroidx/transition/Transition$EpicenterCallback;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetTransitionPropertiesHandler()
		{
			if ((object)cb_getTransitionProperties == null)
			{
				cb_getTransitionProperties = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTransitionProperties));
			}
			return cb_getTransitionProperties;
		}

		private static IntPtr n_GetTransitionProperties(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTransitionProperties());
		}

		[Register("getTransitionProperties", "()[Ljava/lang/String;", "GetGetTransitionPropertiesHandler")]
		public unsafe virtual string[] GetTransitionProperties()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransitionProperties.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		private static Delegate GetGetTransitionValues_Landroid_view_View_ZHandler()
		{
			if ((object)cb_getTransitionValues_Landroid_view_View_Z == null)
			{
				cb_getTransitionValues_Landroid_view_View_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_GetTransitionValues_Landroid_view_View_Z));
			}
			return cb_getTransitionValues_Landroid_view_View_Z;
		}

		private static IntPtr n_GetTransitionValues_Landroid_view_View_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_view, bool start)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.GetTransitionValues(view, start));
		}

		[Register("getTransitionValues", "(Landroid/view/View;Z)Landroidx/transition/TransitionValues;", "GetGetTransitionValues_Landroid_view_View_ZHandler")]
		public unsafe virtual TransitionValues GetTransitionValues(View view, bool start)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(start);
				return Java.Lang.Object.GetObject<TransitionValues>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransitionValues.(Landroid/view/View;Z)Landroidx/transition/TransitionValues;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetIsTransitionRequired_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_Handler()
		{
			if ((object)cb_isTransitionRequired_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_ == null)
			{
				cb_isTransitionRequired_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_IsTransitionRequired_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_));
			}
			return cb_isTransitionRequired_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_;
		}

		private static bool n_IsTransitionRequired_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_(IntPtr jnienv, IntPtr native__this, IntPtr native_startValues, IntPtr native_endValues)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransitionValues startValues = Java.Lang.Object.GetObject<TransitionValues>(native_startValues, JniHandleOwnership.DoNotTransfer);
			TransitionValues endValues = Java.Lang.Object.GetObject<TransitionValues>(native_endValues, JniHandleOwnership.DoNotTransfer);
			return transition.IsTransitionRequired(startValues, endValues);
		}

		[Register("isTransitionRequired", "(Landroidx/transition/TransitionValues;Landroidx/transition/TransitionValues;)Z", "GetIsTransitionRequired_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_Handler")]
		public unsafe virtual bool IsTransitionRequired(TransitionValues startValues, TransitionValues endValues)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(startValues?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(endValues?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTransitionRequired.(Landroidx/transition/TransitionValues;Landroidx/transition/TransitionValues;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(startValues);
				GC.KeepAlive(endValues);
			}
		}

		private static Delegate GetPause_Landroid_view_View_Handler()
		{
			if ((object)cb_pause_Landroid_view_View_ == null)
			{
				cb_pause_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Pause_Landroid_view_View_));
			}
			return cb_pause_Landroid_view_View_;
		}

		private static void n_Pause_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_sceneRoot)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View sceneRoot = Java.Lang.Object.GetObject<View>(native_sceneRoot, JniHandleOwnership.DoNotTransfer);
			transition.Pause(sceneRoot);
		}

		[Register("pause", "(Landroid/view/View;)V", "GetPause_Landroid_view_View_Handler")]
		public unsafe virtual void Pause(View sceneRoot)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("pause.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
			}
		}

		private static Delegate GetRemoveListener_Landroidx_transition_Transition_TransitionListener_Handler()
		{
			if ((object)cb_removeListener_Landroidx_transition_Transition_TransitionListener_ == null)
			{
				cb_removeListener_Landroidx_transition_Transition_TransitionListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveListener_Landroidx_transition_Transition_TransitionListener_));
			}
			return cb_removeListener_Landroidx_transition_Transition_TransitionListener_;
		}

		private static IntPtr n_RemoveListener_Landroidx_transition_Transition_TransitionListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransitionListener listener = Java.Lang.Object.GetObject<ITransitionListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.RemoveListener(listener));
		}

		[Register("removeListener", "(Landroidx/transition/Transition$TransitionListener;)Landroidx/transition/Transition;", "GetRemoveListener_Landroidx_transition_Transition_TransitionListener_Handler")]
		public unsafe virtual Transition RemoveListener(ITransitionListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeListener.(Landroidx/transition/Transition$TransitionListener;)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetRemoveTarget_Landroid_view_View_Handler()
		{
			if ((object)cb_removeTarget_Landroid_view_View_ == null)
			{
				cb_removeTarget_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveTarget_Landroid_view_View_));
			}
			return cb_removeTarget_Landroid_view_View_;
		}

		private static IntPtr n_RemoveTarget_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_target)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.RemoveTarget(target));
		}

		[Register("removeTarget", "(Landroid/view/View;)Landroidx/transition/Transition;", "GetRemoveTarget_Landroid_view_View_Handler")]
		public unsafe virtual Transition RemoveTarget(View target)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeTarget.(Landroid/view/View;)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetRemoveTarget_IHandler()
		{
			if ((object)cb_removeTarget_I == null)
			{
				cb_removeTarget_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_RemoveTarget_I));
			}
			return cb_removeTarget_I;
		}

		private static IntPtr n_RemoveTarget_I(IntPtr jnienv, IntPtr native__this, int targetId)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveTarget(targetId));
		}

		[Register("removeTarget", "(I)Landroidx/transition/Transition;", "GetRemoveTarget_IHandler")]
		public unsafe virtual Transition RemoveTarget(int targetId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(targetId);
			return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeTarget.(I)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRemoveTarget_Ljava_lang_Class_Handler()
		{
			if ((object)cb_removeTarget_Ljava_lang_Class_ == null)
			{
				cb_removeTarget_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveTarget_Ljava_lang_Class_));
			}
			return cb_removeTarget_Ljava_lang_Class_;
		}

		private static IntPtr n_RemoveTarget_Ljava_lang_Class_(IntPtr jnienv, IntPtr native__this, IntPtr native_target)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class target = Java.Lang.Object.GetObject<Class>(native_target, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.RemoveTarget(target));
		}

		[Register("removeTarget", "(Ljava/lang/Class;)Landroidx/transition/Transition;", "GetRemoveTarget_Ljava_lang_Class_Handler")]
		public unsafe virtual Transition RemoveTarget(Class target)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeTarget.(Ljava/lang/Class;)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetRemoveTarget_Ljava_lang_String_Handler()
		{
			if ((object)cb_removeTarget_Ljava_lang_String_ == null)
			{
				cb_removeTarget_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveTarget_Ljava_lang_String_));
			}
			return cb_removeTarget_Ljava_lang_String_;
		}

		private static IntPtr n_RemoveTarget_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_targetName)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string targetName = JNIEnv.GetString(native_targetName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.RemoveTarget(targetName));
		}

		[Register("removeTarget", "(Ljava/lang/String;)Landroidx/transition/Transition;", "GetRemoveTarget_Ljava_lang_String_Handler")]
		public unsafe virtual Transition RemoveTarget(string targetName)
		{
			IntPtr intPtr = JNIEnv.NewString(targetName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeTarget.(Ljava/lang/String;)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetResume_Landroid_view_View_Handler()
		{
			if ((object)cb_resume_Landroid_view_View_ == null)
			{
				cb_resume_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Resume_Landroid_view_View_));
			}
			return cb_resume_Landroid_view_View_;
		}

		private static void n_Resume_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_sceneRoot)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View sceneRoot = Java.Lang.Object.GetObject<View>(native_sceneRoot, JniHandleOwnership.DoNotTransfer);
			transition.Resume(sceneRoot);
		}

		[Register("resume", "(Landroid/view/View;)V", "GetResume_Landroid_view_View_Handler")]
		public unsafe virtual void Resume(View sceneRoot)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("resume.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
			}
		}

		private static Delegate GetRunAnimatorsHandler()
		{
			if ((object)cb_runAnimators == null)
			{
				cb_runAnimators = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RunAnimators));
			}
			return cb_runAnimators;
		}

		private static void n_RunAnimators(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RunAnimators();
		}

		[Register("runAnimators", "()V", "GetRunAnimatorsHandler")]
		protected unsafe virtual void RunAnimators()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("runAnimators.()V", this, null);
		}

		private static Delegate GetSetDuration_JHandler()
		{
			if ((object)cb_setDuration_J == null)
			{
				cb_setDuration_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetDuration_J));
			}
			return cb_setDuration_J;
		}

		private static IntPtr n_SetDuration_J(IntPtr jnienv, IntPtr native__this, long duration)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDuration(duration));
		}

		[Register("setDuration", "(J)Landroidx/transition/Transition;", "GetSetDuration_JHandler")]
		public unsafe virtual Transition SetDuration(long duration)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(duration);
			return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDuration.(J)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetEpicenterCallback_Landroidx_transition_Transition_EpicenterCallback_Handler()
		{
			if ((object)cb_setEpicenterCallback_Landroidx_transition_Transition_EpicenterCallback_ == null)
			{
				cb_setEpicenterCallback_Landroidx_transition_Transition_EpicenterCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetEpicenterCallback_Landroidx_transition_Transition_EpicenterCallback_));
			}
			return cb_setEpicenterCallback_Landroidx_transition_Transition_EpicenterCallback_;
		}

		private static void n_SetEpicenterCallback_Landroidx_transition_Transition_EpicenterCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_epicenterCallback)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EpicenterCallback epicenterCallback = Java.Lang.Object.GetObject<EpicenterCallback>(native_epicenterCallback, JniHandleOwnership.DoNotTransfer);
			transition.SetEpicenterCallback(epicenterCallback);
		}

		[Register("setEpicenterCallback", "(Landroidx/transition/Transition$EpicenterCallback;)V", "GetSetEpicenterCallback_Landroidx_transition_Transition_EpicenterCallback_Handler")]
		public unsafe virtual void SetEpicenterCallback(EpicenterCallback epicenterCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(epicenterCallback?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEpicenterCallback.(Landroidx/transition/Transition$EpicenterCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(epicenterCallback);
			}
		}

		private static Delegate GetSetInterpolator_Landroid_animation_TimeInterpolator_Handler()
		{
			if ((object)cb_setInterpolator_Landroid_animation_TimeInterpolator_ == null)
			{
				cb_setInterpolator_Landroid_animation_TimeInterpolator_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetInterpolator_Landroid_animation_TimeInterpolator_));
			}
			return cb_setInterpolator_Landroid_animation_TimeInterpolator_;
		}

		private static IntPtr n_SetInterpolator_Landroid_animation_TimeInterpolator_(IntPtr jnienv, IntPtr native__this, IntPtr native_interpolator)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITimeInterpolator interpolator = Java.Lang.Object.GetObject<ITimeInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transition.SetInterpolator(interpolator));
		}

		[Register("setInterpolator", "(Landroid/animation/TimeInterpolator;)Landroidx/transition/Transition;", "GetSetInterpolator_Landroid_animation_TimeInterpolator_Handler")]
		public unsafe virtual Transition SetInterpolator(ITimeInterpolator interpolator)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("setInterpolator.(Landroid/animation/TimeInterpolator;)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(interpolator);
			}
		}

		private static Delegate GetSetMatchOrder_arrayIHandler()
		{
			if ((object)cb_setMatchOrder_arrayI == null)
			{
				cb_setMatchOrder_arrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetMatchOrder_arrayI));
			}
			return cb_setMatchOrder_arrayI;
		}

		private static void n_SetMatchOrder_arrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_matches)
		{
			Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_matches, JniHandleOwnership.DoNotTransfer, typeof(int));
			transition.SetMatchOrder(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_matches);
			}
		}

		[Register("setMatchOrder", "([I)V", "GetSetMatchOrder_arrayIHandler")]
		public unsafe virtual void SetMatchOrder(params int[] matches)
		{
			IntPtr intPtr = JNIEnv.NewArray(matches);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMatchOrder.([I)V", this, ptr);
			}
			finally
			{
				if (matches != null)
				{
					JNIEnv.CopyArray(intPtr, matches);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(matches);
			}
		}

		private static Delegate GetSetStartDelay_JHandler()
		{
			if ((object)cb_setStartDelay_J == null)
			{
				cb_setStartDelay_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetStartDelay_J));
			}
			return cb_setStartDelay_J;
		}

		private static IntPtr n_SetStartDelay_J(IntPtr jnienv, IntPtr native__this, long startDelay)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStartDelay(startDelay));
		}

		[Register("setStartDelay", "(J)Landroidx/transition/Transition;", "GetSetStartDelay_JHandler")]
		public unsafe virtual Transition SetStartDelay(long startDelay)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(startDelay);
			return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("setStartDelay.(J)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetStartHandler()
		{
			if ((object)cb_start == null)
			{
				cb_start = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Start));
			}
			return cb_start;
		}

		private static void n_Start(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Start();
		}

		[Register("start", "()V", "GetStartHandler")]
		protected unsafe virtual void Start()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("start.()V", this, null);
		}
	}
	[Register("androidx/transition/Transition", DoNotGenerateAcw = true)]
	internal class TransitionInvoker : Transition
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/Transition", typeof(TransitionInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public TransitionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("captureEndValues", "(Landroidx/transition/TransitionValues;)V", "GetCaptureEndValues_Landroidx_transition_TransitionValues_Handler")]
		public unsafe override void CaptureEndValues(TransitionValues transitionValues)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transitionValues?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("captureEndValues.(Landroidx/transition/TransitionValues;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transitionValues);
			}
		}

		[Register("captureStartValues", "(Landroidx/transition/TransitionValues;)V", "GetCaptureStartValues_Landroidx_transition_TransitionValues_Handler")]
		public unsafe override void CaptureStartValues(TransitionValues transitionValues)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transitionValues?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("captureStartValues.(Landroidx/transition/TransitionValues;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transitionValues);
			}
		}
	}
	[Register("androidx/transition/TransitionManager", DoNotGenerateAcw = true)]
	public class TransitionManager : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/TransitionManager", typeof(TransitionManager));

		private static Delegate cb_setTransition_Landroidx_transition_Scene_Landroidx_transition_Scene_Landroidx_transition_Transition_;

		private static Delegate cb_setTransition_Landroidx_transition_Scene_Landroidx_transition_Transition_;

		private static Delegate cb_transitionTo_Landroidx_transition_Scene_;

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

		protected TransitionManager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TransitionManager()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("beginDelayedTransition", "(Landroid/view/ViewGroup;)V", "")]
		public unsafe static void BeginDelayedTransition(ViewGroup sceneRoot)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("beginDelayedTransition.(Landroid/view/ViewGroup;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
			}
		}

		[Register("beginDelayedTransition", "(Landroid/view/ViewGroup;Landroidx/transition/Transition;)V", "")]
		public unsafe static void BeginDelayedTransition(ViewGroup sceneRoot, Transition transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("beginDelayedTransition.(Landroid/view/ViewGroup;Landroidx/transition/Transition;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
				GC.KeepAlive(transition);
			}
		}

		[Register("endTransitions", "(Landroid/view/ViewGroup;)V", "")]
		public unsafe static void EndTransitions(ViewGroup sceneRoot)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("endTransitions.(Landroid/view/ViewGroup;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
			}
		}

		[Register("go", "(Landroidx/transition/Scene;)V", "")]
		public unsafe static void Go(Scene scene)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(scene?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("go.(Landroidx/transition/Scene;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(scene);
			}
		}

		[Register("go", "(Landroidx/transition/Scene;Landroidx/transition/Transition;)V", "")]
		public unsafe static void Go(Scene scene, Transition transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(scene?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("go.(Landroidx/transition/Scene;Landroidx/transition/Transition;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(scene);
				GC.KeepAlive(transition);
			}
		}

		private static Delegate GetSetTransition_Landroidx_transition_Scene_Landroidx_transition_Scene_Landroidx_transition_Transition_Handler()
		{
			if ((object)cb_setTransition_Landroidx_transition_Scene_Landroidx_transition_Scene_Landroidx_transition_Transition_ == null)
			{
				cb_setTransition_Landroidx_transition_Scene_Landroidx_transition_Scene_Landroidx_transition_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SetTransition_Landroidx_transition_Scene_Landroidx_transition_Scene_Landroidx_transition_Transition_));
			}
			return cb_setTransition_Landroidx_transition_Scene_Landroidx_transition_Scene_Landroidx_transition_Transition_;
		}

		private static void n_SetTransition_Landroidx_transition_Scene_Landroidx_transition_Scene_Landroidx_transition_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_fromScene, IntPtr native_toScene, IntPtr native_transition)
		{
			TransitionManager transitionManager = Java.Lang.Object.GetObject<TransitionManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Scene fromScene = Java.Lang.Object.GetObject<Scene>(native_fromScene, JniHandleOwnership.DoNotTransfer);
			Scene toScene = Java.Lang.Object.GetObject<Scene>(native_toScene, JniHandleOwnership.DoNotTransfer);
			Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			transitionManager.SetTransition(fromScene, toScene, transition);
		}

		[Register("setTransition", "(Landroidx/transition/Scene;Landroidx/transition/Scene;Landroidx/transition/Transition;)V", "GetSetTransition_Landroidx_transition_Scene_Landroidx_transition_Scene_Landroidx_transition_Transition_Handler")]
		public unsafe virtual void SetTransition(Scene fromScene, Scene toScene, Transition transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fromScene?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(toScene?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(Landroidx/transition/Scene;Landroidx/transition/Scene;Landroidx/transition/Transition;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fromScene);
				GC.KeepAlive(toScene);
				GC.KeepAlive(transition);
			}
		}

		private static Delegate GetSetTransition_Landroidx_transition_Scene_Landroidx_transition_Transition_Handler()
		{
			if ((object)cb_setTransition_Landroidx_transition_Scene_Landroidx_transition_Transition_ == null)
			{
				cb_setTransition_Landroidx_transition_Scene_Landroidx_transition_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetTransition_Landroidx_transition_Scene_Landroidx_transition_Transition_));
			}
			return cb_setTransition_Landroidx_transition_Scene_Landroidx_transition_Transition_;
		}

		private static void n_SetTransition_Landroidx_transition_Scene_Landroidx_transition_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_scene, IntPtr native_transition)
		{
			TransitionManager transitionManager = Java.Lang.Object.GetObject<TransitionManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Scene scene = Java.Lang.Object.GetObject<Scene>(native_scene, JniHandleOwnership.DoNotTransfer);
			Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			transitionManager.SetTransition(scene, transition);
		}

		[Register("setTransition", "(Landroidx/transition/Scene;Landroidx/transition/Transition;)V", "GetSetTransition_Landroidx_transition_Scene_Landroidx_transition_Transition_Handler")]
		public unsafe virtual void SetTransition(Scene scene, Transition transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(scene?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(Landroidx/transition/Scene;Landroidx/transition/Transition;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(scene);
				GC.KeepAlive(transition);
			}
		}

		private static Delegate GetTransitionTo_Landroidx_transition_Scene_Handler()
		{
			if ((object)cb_transitionTo_Landroidx_transition_Scene_ == null)
			{
				cb_transitionTo_Landroidx_transition_Scene_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_TransitionTo_Landroidx_transition_Scene_));
			}
			return cb_transitionTo_Landroidx_transition_Scene_;
		}

		private static void n_TransitionTo_Landroidx_transition_Scene_(IntPtr jnienv, IntPtr native__this, IntPtr native_scene)
		{
			TransitionManager transitionManager = Java.Lang.Object.GetObject<TransitionManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Scene scene = Java.Lang.Object.GetObject<Scene>(native_scene, JniHandleOwnership.DoNotTransfer);
			transitionManager.TransitionTo(scene);
		}

		[Register("transitionTo", "(Landroidx/transition/Scene;)V", "GetTransitionTo_Landroidx_transition_Scene_Handler")]
		public unsafe virtual void TransitionTo(Scene scene)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(scene?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("transitionTo.(Landroidx/transition/Scene;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(scene);
			}
		}
	}
	[Register("androidx/transition/TransitionPropagation", DoNotGenerateAcw = true)]
	public abstract class TransitionPropagation : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/TransitionPropagation", typeof(TransitionPropagation));

		private static Delegate cb_captureValues_Landroidx_transition_TransitionValues_;

		private static Delegate cb_getPropagationProperties;

		private static Delegate cb_getStartDelay_Landroid_view_ViewGroup_Landroidx_transition_Transition_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_;

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

		protected TransitionPropagation(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TransitionPropagation()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCaptureValues_Landroidx_transition_TransitionValues_Handler()
		{
			if ((object)cb_captureValues_Landroidx_transition_TransitionValues_ == null)
			{
				cb_captureValues_Landroidx_transition_TransitionValues_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CaptureValues_Landroidx_transition_TransitionValues_));
			}
			return cb_captureValues_Landroidx_transition_TransitionValues_;
		}

		private static void n_CaptureValues_Landroidx_transition_TransitionValues_(IntPtr jnienv, IntPtr native__this, IntPtr native_transitionValues)
		{
			TransitionPropagation transitionPropagation = Java.Lang.Object.GetObject<TransitionPropagation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransitionValues transitionValues = Java.Lang.Object.GetObject<TransitionValues>(native_transitionValues, JniHandleOwnership.DoNotTransfer);
			transitionPropagation.CaptureValues(transitionValues);
		}

		[Register("captureValues", "(Landroidx/transition/TransitionValues;)V", "GetCaptureValues_Landroidx_transition_TransitionValues_Handler")]
		public abstract void CaptureValues(TransitionValues transitionValues);

		private static Delegate GetGetPropagationPropertiesHandler()
		{
			if ((object)cb_getPropagationProperties == null)
			{
				cb_getPropagationProperties = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPropagationProperties));
			}
			return cb_getPropagationProperties;
		}

		private static IntPtr n_GetPropagationProperties(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<TransitionPropagation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPropagationProperties());
		}

		[Register("getPropagationProperties", "()[Ljava/lang/String;", "GetGetPropagationPropertiesHandler")]
		public abstract string[] GetPropagationProperties();

		private static Delegate GetGetStartDelay_Landroid_view_ViewGroup_Landroidx_transition_Transition_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_Handler()
		{
			if ((object)cb_getStartDelay_Landroid_view_ViewGroup_Landroidx_transition_Transition_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_ == null)
			{
				cb_getStartDelay_Landroid_view_ViewGroup_Landroidx_transition_Transition_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLL_J(n_GetStartDelay_Landroid_view_ViewGroup_Landroidx_transition_Transition_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_));
			}
			return cb_getStartDelay_Landroid_view_ViewGroup_Landroidx_transition_Transition_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_;
		}

		private static long n_GetStartDelay_Landroid_view_ViewGroup_Landroidx_transition_Transition_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_(IntPtr jnienv, IntPtr native__this, IntPtr native_sceneRoot, IntPtr native_transition, IntPtr native_startValues, IntPtr native_endValues)
		{
			TransitionPropagation transitionPropagation = Java.Lang.Object.GetObject<TransitionPropagation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup sceneRoot = Java.Lang.Object.GetObject<ViewGroup>(native_sceneRoot, JniHandleOwnership.DoNotTransfer);
			Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			TransitionValues startValues = Java.Lang.Object.GetObject<TransitionValues>(native_startValues, JniHandleOwnership.DoNotTransfer);
			TransitionValues endValues = Java.Lang.Object.GetObject<TransitionValues>(native_endValues, JniHandleOwnership.DoNotTransfer);
			return transitionPropagation.GetStartDelay(sceneRoot, transition, startValues, endValues);
		}

		[Register("getStartDelay", "(Landroid/view/ViewGroup;Landroidx/transition/Transition;Landroidx/transition/TransitionValues;Landroidx/transition/TransitionValues;)J", "GetGetStartDelay_Landroid_view_ViewGroup_Landroidx_transition_Transition_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_Handler")]
		public abstract long GetStartDelay(ViewGroup sceneRoot, Transition transition, TransitionValues startValues, TransitionValues endValues);
	}
	[Register("androidx/transition/TransitionPropagation", DoNotGenerateAcw = true)]
	internal class TransitionPropagationInvoker : TransitionPropagation
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/TransitionPropagation", typeof(TransitionPropagationInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public TransitionPropagationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("captureValues", "(Landroidx/transition/TransitionValues;)V", "GetCaptureValues_Landroidx_transition_TransitionValues_Handler")]
		public unsafe override void CaptureValues(TransitionValues transitionValues)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transitionValues?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("captureValues.(Landroidx/transition/TransitionValues;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transitionValues);
			}
		}

		[Register("getPropagationProperties", "()[Ljava/lang/String;", "GetGetPropagationPropertiesHandler")]
		public unsafe override string[] GetPropagationProperties()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getPropagationProperties.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getStartDelay", "(Landroid/view/ViewGroup;Landroidx/transition/Transition;Landroidx/transition/TransitionValues;Landroidx/transition/TransitionValues;)J", "GetGetStartDelay_Landroid_view_ViewGroup_Landroidx_transition_Transition_Landroidx_transition_TransitionValues_Landroidx_transition_TransitionValues_Handler")]
		public unsafe override long GetStartDelay(ViewGroup sceneRoot, Transition transition, TransitionValues startValues, TransitionValues endValues)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(sceneRoot?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(startValues?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(endValues?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt64Method("getStartDelay.(Landroid/view/ViewGroup;Landroidx/transition/Transition;Landroidx/transition/TransitionValues;Landroidx/transition/TransitionValues;)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sceneRoot);
				GC.KeepAlive(transition);
				GC.KeepAlive(startValues);
				GC.KeepAlive(endValues);
			}
		}
	}
	[Register("androidx/transition/TransitionSet", DoNotGenerateAcw = true)]
	public class TransitionSet : Transition
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/TransitionSet", typeof(TransitionSet));

		private static Delegate cb_getOrdering;

		private static Delegate cb_getTransitionCount;

		private static Delegate cb_addTransition_Landroidx_transition_Transition_;

		private static Delegate cb_captureEndValues_Landroidx_transition_TransitionValues_;

		private static Delegate cb_captureStartValues_Landroidx_transition_TransitionValues_;

		private static Delegate cb_getTransitionAt_I;

		private static Delegate cb_removeTransition_Landroidx_transition_Transition_;

		private static Delegate cb_setOrdering_I;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int Ordering
		{
			[Register("getOrdering", "()I", "GetGetOrderingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getOrdering.()I", this, null);
			}
		}

		public unsafe virtual int TransitionCount
		{
			[Register("getTransitionCount", "()I", "GetGetTransitionCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTransitionCount.()I", this, null);
			}
		}

		protected TransitionSet(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TransitionSet()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe TransitionSet(Context context, IAttributeSet attrs)
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

		private static Delegate GetGetOrderingHandler()
		{
			if ((object)cb_getOrdering == null)
			{
				cb_getOrdering = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOrdering));
			}
			return cb_getOrdering;
		}

		private static int n_GetOrdering(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TransitionSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Ordering;
		}

		private static Delegate GetGetTransitionCountHandler()
		{
			if ((object)cb_getTransitionCount == null)
			{
				cb_getTransitionCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTransitionCount));
			}
			return cb_getTransitionCount;
		}

		private static int n_GetTransitionCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TransitionSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionCount;
		}

		private static Delegate GetAddTransition_Landroidx_transition_Transition_Handler()
		{
			if ((object)cb_addTransition_Landroidx_transition_Transition_ == null)
			{
				cb_addTransition_Landroidx_transition_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddTransition_Landroidx_transition_Transition_));
			}
			return cb_addTransition_Landroidx_transition_Transition_;
		}

		private static IntPtr n_AddTransition_Landroidx_transition_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
		{
			TransitionSet transitionSet = Java.Lang.Object.GetObject<TransitionSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transitionSet.AddTransition(transition));
		}

		[Register("addTransition", "(Landroidx/transition/Transition;)Landroidx/transition/TransitionSet;", "GetAddTransition_Landroidx_transition_Transition_Handler")]
		public unsafe virtual TransitionSet AddTransition(Transition transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TransitionSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("addTransition.(Landroidx/transition/Transition;)Landroidx/transition/TransitionSet;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(transition);
			}
		}

		private static Delegate GetCaptureEndValues_Landroidx_transition_TransitionValues_Handler()
		{
			if ((object)cb_captureEndValues_Landroidx_transition_TransitionValues_ == null)
			{
				cb_captureEndValues_Landroidx_transition_TransitionValues_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CaptureEndValues_Landroidx_transition_TransitionValues_));
			}
			return cb_captureEndValues_Landroidx_transition_TransitionValues_;
		}

		private static void n_CaptureEndValues_Landroidx_transition_TransitionValues_(IntPtr jnienv, IntPtr native__this, IntPtr native_transitionValues)
		{
			TransitionSet transitionSet = Java.Lang.Object.GetObject<TransitionSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransitionValues transitionValues = Java.Lang.Object.GetObject<TransitionValues>(native_transitionValues, JniHandleOwnership.DoNotTransfer);
			transitionSet.CaptureEndValues(transitionValues);
		}

		[Register("captureEndValues", "(Landroidx/transition/TransitionValues;)V", "GetCaptureEndValues_Landroidx_transition_TransitionValues_Handler")]
		public unsafe override void CaptureEndValues(TransitionValues transitionValues)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transitionValues?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("captureEndValues.(Landroidx/transition/TransitionValues;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transitionValues);
			}
		}

		private static Delegate GetCaptureStartValues_Landroidx_transition_TransitionValues_Handler()
		{
			if ((object)cb_captureStartValues_Landroidx_transition_TransitionValues_ == null)
			{
				cb_captureStartValues_Landroidx_transition_TransitionValues_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CaptureStartValues_Landroidx_transition_TransitionValues_));
			}
			return cb_captureStartValues_Landroidx_transition_TransitionValues_;
		}

		private static void n_CaptureStartValues_Landroidx_transition_TransitionValues_(IntPtr jnienv, IntPtr native__this, IntPtr native_transitionValues)
		{
			TransitionSet transitionSet = Java.Lang.Object.GetObject<TransitionSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransitionValues transitionValues = Java.Lang.Object.GetObject<TransitionValues>(native_transitionValues, JniHandleOwnership.DoNotTransfer);
			transitionSet.CaptureStartValues(transitionValues);
		}

		[Register("captureStartValues", "(Landroidx/transition/TransitionValues;)V", "GetCaptureStartValues_Landroidx_transition_TransitionValues_Handler")]
		public unsafe override void CaptureStartValues(TransitionValues transitionValues)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transitionValues?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("captureStartValues.(Landroidx/transition/TransitionValues;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transitionValues);
			}
		}

		private static Delegate GetGetTransitionAt_IHandler()
		{
			if ((object)cb_getTransitionAt_I == null)
			{
				cb_getTransitionAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetTransitionAt_I));
			}
			return cb_getTransitionAt_I;
		}

		private static IntPtr n_GetTransitionAt_I(IntPtr jnienv, IntPtr native__this, int index)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TransitionSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTransitionAt(index));
		}

		[Register("getTransitionAt", "(I)Landroidx/transition/Transition;", "GetGetTransitionAt_IHandler")]
		public unsafe virtual Transition GetTransitionAt(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransitionAt.(I)Landroidx/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRemoveTransition_Landroidx_transition_Transition_Handler()
		{
			if ((object)cb_removeTransition_Landroidx_transition_Transition_ == null)
			{
				cb_removeTransition_Landroidx_transition_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveTransition_Landroidx_transition_Transition_));
			}
			return cb_removeTransition_Landroidx_transition_Transition_;
		}

		private static IntPtr n_RemoveTransition_Landroidx_transition_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
		{
			TransitionSet transitionSet = Java.Lang.Object.GetObject<TransitionSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transitionSet.RemoveTransition(transition));
		}

		[Register("removeTransition", "(Landroidx/transition/Transition;)Landroidx/transition/TransitionSet;", "GetRemoveTransition_Landroidx_transition_Transition_Handler")]
		public unsafe virtual TransitionSet RemoveTransition(Transition transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TransitionSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeTransition.(Landroidx/transition/Transition;)Landroidx/transition/TransitionSet;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(transition);
			}
		}

		private static Delegate GetSetOrdering_IHandler()
		{
			if ((object)cb_setOrdering_I == null)
			{
				cb_setOrdering_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetOrdering_I));
			}
			return cb_setOrdering_I;
		}

		private static IntPtr n_SetOrdering_I(IntPtr jnienv, IntPtr native__this, int ordering)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TransitionSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOrdering(ordering));
		}

		[Register("setOrdering", "(I)Landroidx/transition/TransitionSet;", "GetSetOrdering_IHandler")]
		public unsafe virtual TransitionSet SetOrdering(int ordering)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ordering);
			return Java.Lang.Object.GetObject<TransitionSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOrdering.(I)Landroidx/transition/TransitionSet;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/transition/TransitionValues", DoNotGenerateAcw = true)]
	public class TransitionValues : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/transition/TransitionValues", typeof(TransitionValues));

		[Register("values")]
		public IDictionary Values
		{
			get
			{
				return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("values.Ljava/util/Map;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JavaDictionary.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("values.Ljava/util/Map;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("view")]
		public View View
		{
			get
			{
				return Java.Lang.Object.GetObject<View>(_members.InstanceFields.GetObjectValue("view.Landroid/view/View;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("view.Landroid/view/View;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
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

		protected TransitionValues(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TransitionValues()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Landroid/view/View;)V", "")]
		public unsafe TransitionValues(View view)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/View;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}
	}
}
