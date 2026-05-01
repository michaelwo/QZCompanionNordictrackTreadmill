using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using AndroidX.Activity;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;
using AndroidX.Core.App;
using AndroidX.Lifecycle;
using AndroidX.Loader.App;
using AndroidX.SavedState;
using AndroidX.ViewPager.Widget;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "97b55712004c3ba90b3da6c878e0043d6ca8218f")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20210218.7")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "2/18/2021 5:00:33 PM")]
[assembly: LinkerSafe]
[assembly: NamespaceMapping(Java = "androidx.fragment.app", Managed = "AndroidX.Fragment.App")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - fragment")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Fragment")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Fragment")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PPI_J(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPII_L(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate void _JniMarshal_PPII_V(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate bool _JniMarshal_PPII_Z(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate IntPtr _JniMarshal_PPIIII_L(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3);
internal delegate void _JniMarshal_PPIIL_V(IntPtr jnienv, IntPtr klass, int p0, int p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPIL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPILL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPILL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPIZI_L(IntPtr jnienv, IntPtr klass, int p0, bool p1, int p2);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate bool _JniMarshal_PPLI_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate void _JniMarshal_PPLILIIIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2, int p3, int p4, int p5, IntPtr p6);
internal delegate int _JniMarshal_PPLL_I(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate bool _JniMarshal_PPLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2);
internal delegate void _JniMarshal_PPLLIJ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, long p3);
internal delegate void _JniMarshal_PPLLIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, IntPtr p3);
internal delegate void _JniMarshal_PPLLILIIIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, IntPtr p3, int p4, int p5, int p6, IntPtr p7);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate void _JniMarshal_PPLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate IntPtr _JniMarshal_PPZ_L(IntPtr jnienv, IntPtr klass, bool p0);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentActivity", DoNotGenerateAcw = true)]
public class FragmentActivity : AndroidX.Activity.ComponentActivity, ActivityCompat.IOnRequestPermissionsResultCallback, IJavaObject, IDisposable, IJavaPeerable, ActivityCompat.IRequestPermissionsRequestCodeValidator
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentActivity", typeof(FragmentActivity));

	private static Delegate cb_getSupportFragmentManager;

	private static Delegate cb_getSupportLoaderManager;

	private static Delegate cb_onAttachFragment_Landroidx_fragment_app_Fragment_;

	private static Delegate cb_onPrepareOptionsPanel_Landroid_view_View_Landroid_view_Menu_;

	private static Delegate cb_onResumeFragments;

	private static Delegate cb_setEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_;

	private static Delegate cb_setExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_;

	private static Delegate cb_startActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I;

	private static Delegate cb_startActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_;

	private static Delegate cb_startIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_;

	private static Delegate cb_supportFinishAfterTransition;

	private static Delegate cb_supportInvalidateOptionsMenu;

	private static Delegate cb_supportPostponeEnterTransition;

	private static Delegate cb_supportStartPostponedEnterTransition;

	public override AndroidX.Lifecycle.Lifecycle Lifecycle => base.Lifecycle;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual FragmentManager SupportFragmentManager
	{
		[Register("getSupportFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "GetGetSupportFragmentManagerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual LoaderManager SupportLoaderManager
	{
		[Register("getSupportLoaderManager", "()Landroidx/loader/app/LoaderManager;", "GetGetSupportLoaderManagerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LoaderManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLoaderManager.()Landroidx/loader/app/LoaderManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected FragmentActivity(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FragmentActivity()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe FragmentActivity(int contentLayoutId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(contentLayoutId);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	private static Delegate GetGetSupportFragmentManagerHandler()
	{
		if ((object)cb_getSupportFragmentManager == null)
		{
			cb_getSupportFragmentManager = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportFragmentManager));
		}
		return cb_getSupportFragmentManager;
	}

	private static IntPtr n_GetSupportFragmentManager(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportFragmentManager);
	}

	private static Delegate GetGetSupportLoaderManagerHandler()
	{
		if ((object)cb_getSupportLoaderManager == null)
		{
			cb_getSupportLoaderManager = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLoaderManager));
		}
		return cb_getSupportLoaderManager;
	}

	private static IntPtr n_GetSupportLoaderManager(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportLoaderManager);
	}

	private static Delegate GetOnAttachFragment_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_onAttachFragment_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_onAttachFragment_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnAttachFragment_Landroidx_fragment_app_Fragment_));
		}
		return cb_onAttachFragment_Landroidx_fragment_app_Fragment_;
	}

	private static void n_OnAttachFragment_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment)
	{
		FragmentActivity fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		fragmentActivity.OnAttachFragment(fragment);
	}

	[Register("onAttachFragment", "(Landroidx/fragment/app/Fragment;)V", "GetOnAttachFragment_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual void OnAttachFragment(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachFragment.(Landroidx/fragment/app/Fragment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetOnPrepareOptionsPanel_Landroid_view_View_Landroid_view_Menu_Handler()
	{
		if ((object)cb_onPrepareOptionsPanel_Landroid_view_View_Landroid_view_Menu_ == null)
		{
			cb_onPrepareOptionsPanel_Landroid_view_View_Landroid_view_Menu_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_OnPrepareOptionsPanel_Landroid_view_View_Landroid_view_Menu_));
		}
		return cb_onPrepareOptionsPanel_Landroid_view_View_Landroid_view_Menu_;
	}

	private static bool n_OnPrepareOptionsPanel_Landroid_view_View_Landroid_view_Menu_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_menu)
	{
		FragmentActivity fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
		return fragmentActivity.OnPrepareOptionsPanel(view, menu);
	}

	[Register("onPrepareOptionsPanel", "(Landroid/view/View;Landroid/view/Menu;)Z", "GetOnPrepareOptionsPanel_Landroid_view_View_Landroid_view_Menu_Handler")]
	protected unsafe virtual bool OnPrepareOptionsPanel(View view, IMenu menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onPrepareOptionsPanel.(Landroid/view/View;Landroid/view/Menu;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnResumeFragmentsHandler()
	{
		if ((object)cb_onResumeFragments == null)
		{
			cb_onResumeFragments = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnResumeFragments));
		}
		return cb_onResumeFragments;
	}

	private static void n_OnResumeFragments(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnResumeFragments();
	}

	[Register("onResumeFragments", "()V", "GetOnResumeFragmentsHandler")]
	protected unsafe virtual void OnResumeFragments()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onResumeFragments.()V", this, null);
	}

	private static Delegate GetSetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler()
	{
		if ((object)cb_setEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_ == null)
		{
			cb_setEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_));
		}
		return cb_setEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_;
	}

	private static void n_SetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native__callback)
	{
		FragmentActivity fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SharedElementCallback enterSharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		fragmentActivity.SetEnterSharedElementCallback(enterSharedElementCallback);
	}

	[Register("setEnterSharedElementCallback", "(Landroidx/core/app/SharedElementCallback;)V", "GetSetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler")]
	public unsafe virtual void SetEnterSharedElementCallback(SharedElementCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEnterSharedElementCallback.(Landroidx/core/app/SharedElementCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler()
	{
		if ((object)cb_setExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_ == null)
		{
			cb_setExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_));
		}
		return cb_setExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_;
	}

	private static void n_SetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		FragmentActivity fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SharedElementCallback exitSharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(native_listener, JniHandleOwnership.DoNotTransfer);
		fragmentActivity.SetExitSharedElementCallback(exitSharedElementCallback);
	}

	[Register("setExitSharedElementCallback", "(Landroidx/core/app/SharedElementCallback;)V", "GetSetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler")]
	public unsafe virtual void SetExitSharedElementCallback(SharedElementCallback listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setExitSharedElementCallback.(Landroidx/core/app/SharedElementCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_IHandler()
	{
		if ((object)cb_startActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I == null)
		{
			cb_startActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_StartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I));
		}
		return cb_startActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I;
	}

	private static void n_StartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment, IntPtr native_intent, int requestCode)
	{
		FragmentActivity fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
		fragmentActivity.StartActivityFromFragment(fragment, intent, requestCode);
	}

	[Register("startActivityFromFragment", "(Landroidx/fragment/app/Fragment;Landroid/content/Intent;I)V", "GetStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_IHandler")]
	public unsafe virtual void StartActivityFromFragment(Fragment fragment, Intent intent, int requestCode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivityFromFragment.(Landroidx/fragment/app/Fragment;Landroid/content/Intent;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(intent);
		}
	}

	private static Delegate GetStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_Handler()
	{
		if ((object)cb_startActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_ == null)
		{
			cb_startActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLIL_V(n_StartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_));
		}
		return cb_startActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_;
	}

	private static void n_StartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment, IntPtr native_intent, int requestCode, IntPtr native_options)
	{
		FragmentActivity fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
		Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
		fragmentActivity.StartActivityFromFragment(fragment, intent, requestCode, options);
	}

	[Register("startActivityFromFragment", "(Landroidx/fragment/app/Fragment;Landroid/content/Intent;ILandroid/os/Bundle;)V", "GetStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_Handler")]
	public unsafe virtual void StartActivityFromFragment(Fragment fragment, Intent intent, int requestCode, Bundle options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			ptr[3] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivityFromFragment.(Landroidx/fragment/app/Fragment;Landroid/content/Intent;ILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(intent);
			GC.KeepAlive(options);
		}
	}

	private static Delegate GetStartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler()
	{
		if ((object)cb_startIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_ == null)
		{
			cb_startIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLILIIIL_V(n_StartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_));
		}
		return cb_startIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_;
	}

	private static void n_StartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment, IntPtr native_intent, int requestCode, IntPtr native_fillInIntent, int flagsMask, int flagsValues, int extraFlags, IntPtr native_options)
	{
		FragmentActivity fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		IntentSender intent = Java.Lang.Object.GetObject<IntentSender>(native_intent, JniHandleOwnership.DoNotTransfer);
		Intent fillInIntent = Java.Lang.Object.GetObject<Intent>(native_fillInIntent, JniHandleOwnership.DoNotTransfer);
		Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
		fragmentActivity.StartIntentSenderFromFragment(fragment, intent, requestCode, fillInIntent, flagsMask, flagsValues, extraFlags, options);
	}

	[Register("startIntentSenderFromFragment", "(Landroidx/fragment/app/Fragment;Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", "GetStartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler")]
	public unsafe virtual void StartIntentSenderFromFragment(Fragment fragment, IntentSender intent, int requestCode, Intent fillInIntent, int flagsMask, int flagsValues, int extraFlags, Bundle options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			ptr[3] = new JniArgumentValue(fillInIntent?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(flagsMask);
			ptr[5] = new JniArgumentValue(flagsValues);
			ptr[6] = new JniArgumentValue(extraFlags);
			ptr[7] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startIntentSenderFromFragment.(Landroidx/fragment/app/Fragment;Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(intent);
			GC.KeepAlive(fillInIntent);
			GC.KeepAlive(options);
		}
	}

	private static Delegate GetSupportFinishAfterTransitionHandler()
	{
		if ((object)cb_supportFinishAfterTransition == null)
		{
			cb_supportFinishAfterTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SupportFinishAfterTransition));
		}
		return cb_supportFinishAfterTransition;
	}

	private static void n_SupportFinishAfterTransition(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportFinishAfterTransition();
	}

	[Register("supportFinishAfterTransition", "()V", "GetSupportFinishAfterTransitionHandler")]
	public unsafe virtual void SupportFinishAfterTransition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("supportFinishAfterTransition.()V", this, null);
	}

	private static Delegate GetSupportInvalidateOptionsMenuHandler()
	{
		if ((object)cb_supportInvalidateOptionsMenu == null)
		{
			cb_supportInvalidateOptionsMenu = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SupportInvalidateOptionsMenu));
		}
		return cb_supportInvalidateOptionsMenu;
	}

	private static void n_SupportInvalidateOptionsMenu(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportInvalidateOptionsMenu();
	}

	[Register("supportInvalidateOptionsMenu", "()V", "GetSupportInvalidateOptionsMenuHandler")]
	public unsafe virtual void SupportInvalidateOptionsMenu()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("supportInvalidateOptionsMenu.()V", this, null);
	}

	private static Delegate GetSupportPostponeEnterTransitionHandler()
	{
		if ((object)cb_supportPostponeEnterTransition == null)
		{
			cb_supportPostponeEnterTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SupportPostponeEnterTransition));
		}
		return cb_supportPostponeEnterTransition;
	}

	private static void n_SupportPostponeEnterTransition(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportPostponeEnterTransition();
	}

	[Register("supportPostponeEnterTransition", "()V", "GetSupportPostponeEnterTransitionHandler")]
	public unsafe virtual void SupportPostponeEnterTransition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("supportPostponeEnterTransition.()V", this, null);
	}

	private static Delegate GetSupportStartPostponedEnterTransitionHandler()
	{
		if ((object)cb_supportStartPostponedEnterTransition == null)
		{
			cb_supportStartPostponedEnterTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SupportStartPostponedEnterTransition));
		}
		return cb_supportStartPostponedEnterTransition;
	}

	private static void n_SupportStartPostponedEnterTransition(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportStartPostponedEnterTransition();
	}

	[Register("supportStartPostponedEnterTransition", "()V", "GetSupportStartPostponedEnterTransitionHandler")]
	public unsafe virtual void SupportStartPostponedEnterTransition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("supportStartPostponedEnterTransition.()V", this, null);
	}

	[Register("validateRequestPermissionsRequestCode", "(I)V", "")]
	public unsafe void ValidateRequestPermissionsRequestCode(int requestCode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(requestCode);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("validateRequestPermissionsRequestCode.(I)V", this, ptr);
	}
}
[Register("androidx/fragment/app/DialogFragment", DoNotGenerateAcw = true)]
public class DialogFragment : Fragment, IDialogInterfaceOnCancelListener, IJavaObject, IDisposable, IJavaPeerable, IDialogInterfaceOnDismissListener
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/DialogFragment", typeof(DialogFragment));

	private static Delegate cb_isCancelable;

	private static Delegate cb_setCancelable_Z;

	private static Delegate cb_getDialog;

	private static Delegate cb_getShowsDialog;

	private static Delegate cb_setShowsDialog_Z;

	private static Delegate cb_getTheme;

	private static Delegate cb_dismiss;

	private static Delegate cb_dismissAllowingStateLoss;

	private static Delegate cb_onCancel_Landroid_content_DialogInterface_;

	private static Delegate cb_onCreateDialog_Landroid_os_Bundle_;

	private static Delegate cb_onDismiss_Landroid_content_DialogInterface_;

	private static Delegate cb_setStyle_II;

	private static Delegate cb_setupDialog_Landroid_app_Dialog_I;

	private static Delegate cb_show_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_;

	private static Delegate cb_show_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_;

	private static Delegate cb_showNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_;

	internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual bool Cancelable
	{
		[Register("isCancelable", "()Z", "GetIsCancelableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCancelable.()Z", this, null);
		}
		[Register("setCancelable", "(Z)V", "GetSetCancelable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCancelable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual Dialog Dialog
	{
		[Register("getDialog", "()Landroid/app/Dialog;", "GetGetDialogHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDialog.()Landroid/app/Dialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool ShowsDialog
	{
		[Register("getShowsDialog", "()Z", "GetGetShowsDialogHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getShowsDialog.()Z", this, null);
		}
		[Register("setShowsDialog", "(Z)V", "GetSetShowsDialog_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShowsDialog.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int Theme
	{
		[Register("getTheme", "()I", "GetGetThemeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTheme.()I", this, null);
		}
	}

	protected DialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe DialogFragment()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe DialogFragment(int contentLayoutId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(contentLayoutId);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	private static Delegate GetIsCancelableHandler()
	{
		if ((object)cb_isCancelable == null)
		{
			cb_isCancelable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCancelable));
		}
		return cb_isCancelable;
	}

	private static bool n_IsCancelable(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancelable;
	}

	private static Delegate GetSetCancelable_ZHandler()
	{
		if ((object)cb_setCancelable_Z == null)
		{
			cb_setCancelable_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetCancelable_Z));
		}
		return cb_setCancelable_Z;
	}

	private static void n_SetCancelable_Z(IntPtr jnienv, IntPtr native__this, bool cancelable)
	{
		Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancelable = cancelable;
	}

	private static Delegate GetGetDialogHandler()
	{
		if ((object)cb_getDialog == null)
		{
			cb_getDialog = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDialog));
		}
		return cb_getDialog;
	}

	private static IntPtr n_GetDialog(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dialog);
	}

	private static Delegate GetGetShowsDialogHandler()
	{
		if ((object)cb_getShowsDialog == null)
		{
			cb_getShowsDialog = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetShowsDialog));
		}
		return cb_getShowsDialog;
	}

	private static bool n_GetShowsDialog(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowsDialog;
	}

	private static Delegate GetSetShowsDialog_ZHandler()
	{
		if ((object)cb_setShowsDialog_Z == null)
		{
			cb_setShowsDialog_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetShowsDialog_Z));
		}
		return cb_setShowsDialog_Z;
	}

	private static void n_SetShowsDialog_Z(IntPtr jnienv, IntPtr native__this, bool showsDialog)
	{
		Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowsDialog = showsDialog;
	}

	private static Delegate GetGetThemeHandler()
	{
		if ((object)cb_getTheme == null)
		{
			cb_getTheme = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTheme));
		}
		return cb_getTheme;
	}

	private static int n_GetTheme(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Theme;
	}

	private static Delegate GetDismissHandler()
	{
		if ((object)cb_dismiss == null)
		{
			cb_dismiss = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Dismiss));
		}
		return cb_dismiss;
	}

	private static void n_Dismiss(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dismiss();
	}

	[Register("dismiss", "()V", "GetDismissHandler")]
	public unsafe virtual void Dismiss()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("dismiss.()V", this, null);
	}

	private static Delegate GetDismissAllowingStateLossHandler()
	{
		if ((object)cb_dismissAllowingStateLoss == null)
		{
			cb_dismissAllowingStateLoss = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DismissAllowingStateLoss));
		}
		return cb_dismissAllowingStateLoss;
	}

	private static void n_DismissAllowingStateLoss(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DismissAllowingStateLoss();
	}

	[Register("dismissAllowingStateLoss", "()V", "GetDismissAllowingStateLossHandler")]
	public unsafe virtual void DismissAllowingStateLoss()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("dismissAllowingStateLoss.()V", this, null);
	}

	private static Delegate GetOnCancel_Landroid_content_DialogInterface_Handler()
	{
		if ((object)cb_onCancel_Landroid_content_DialogInterface_ == null)
		{
			cb_onCancel_Landroid_content_DialogInterface_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCancel_Landroid_content_DialogInterface_));
		}
		return cb_onCancel_Landroid_content_DialogInterface_;
	}

	private static void n_OnCancel_Landroid_content_DialogInterface_(IntPtr jnienv, IntPtr native__this, IntPtr native_dialog)
	{
		DialogFragment dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDialogInterface dialog = Java.Lang.Object.GetObject<IDialogInterface>(native_dialog, JniHandleOwnership.DoNotTransfer);
		dialogFragment.OnCancel(dialog);
	}

	[Register("onCancel", "(Landroid/content/DialogInterface;)V", "GetOnCancel_Landroid_content_DialogInterface_Handler")]
	public unsafe virtual void OnCancel(IDialogInterface dialog)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dialog == null) ? IntPtr.Zero : ((Java.Lang.Object)dialog).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCancel.(Landroid/content/DialogInterface;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dialog);
		}
	}

	private static Delegate GetOnCreateDialog_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onCreateDialog_Landroid_os_Bundle_ == null)
		{
			cb_onCreateDialog_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnCreateDialog_Landroid_os_Bundle_));
		}
		return cb_onCreateDialog_Landroid_os_Bundle_;
	}

	private static IntPtr n_OnCreateDialog_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_savedInstanceState)
	{
		DialogFragment dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(dialogFragment.OnCreateDialog(savedInstanceState));
	}

	[Register("onCreateDialog", "(Landroid/os/Bundle;)Landroid/app/Dialog;", "GetOnCreateDialog_Landroid_os_Bundle_Handler")]
	public unsafe virtual Dialog OnCreateDialog(Bundle savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateDialog.(Landroid/os/Bundle;)Landroid/app/Dialog;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnDismiss_Landroid_content_DialogInterface_Handler()
	{
		if ((object)cb_onDismiss_Landroid_content_DialogInterface_ == null)
		{
			cb_onDismiss_Landroid_content_DialogInterface_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDismiss_Landroid_content_DialogInterface_));
		}
		return cb_onDismiss_Landroid_content_DialogInterface_;
	}

	private static void n_OnDismiss_Landroid_content_DialogInterface_(IntPtr jnienv, IntPtr native__this, IntPtr native_dialog)
	{
		DialogFragment dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDialogInterface dialog = Java.Lang.Object.GetObject<IDialogInterface>(native_dialog, JniHandleOwnership.DoNotTransfer);
		dialogFragment.OnDismiss(dialog);
	}

	[Register("onDismiss", "(Landroid/content/DialogInterface;)V", "GetOnDismiss_Landroid_content_DialogInterface_Handler")]
	public unsafe virtual void OnDismiss(IDialogInterface dialog)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dialog == null) ? IntPtr.Zero : ((Java.Lang.Object)dialog).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDismiss.(Landroid/content/DialogInterface;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dialog);
		}
	}

	[Register("requireDialog", "()Landroid/app/Dialog;", "")]
	public unsafe Dialog RequireDialog()
	{
		return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireDialog.()Landroid/app/Dialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetStyle_IIHandler()
	{
		if ((object)cb_setStyle_II == null)
		{
			cb_setStyle_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetStyle_II));
		}
		return cb_setStyle_II;
	}

	private static void n_SetStyle_II(IntPtr jnienv, IntPtr native__this, int style, int theme)
	{
		Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStyle(style, theme);
	}

	[Register("setStyle", "(II)V", "GetSetStyle_IIHandler")]
	public unsafe virtual void SetStyle(int style, int theme)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(style);
		ptr[1] = new JniArgumentValue(theme);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStyle.(II)V", this, ptr);
	}

	private static Delegate GetSetupDialog_Landroid_app_Dialog_IHandler()
	{
		if ((object)cb_setupDialog_Landroid_app_Dialog_I == null)
		{
			cb_setupDialog_Landroid_app_Dialog_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_SetupDialog_Landroid_app_Dialog_I));
		}
		return cb_setupDialog_Landroid_app_Dialog_I;
	}

	private static void n_SetupDialog_Landroid_app_Dialog_I(IntPtr jnienv, IntPtr native__this, IntPtr native_dialog, int style)
	{
		DialogFragment dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Dialog dialog = Java.Lang.Object.GetObject<Dialog>(native_dialog, JniHandleOwnership.DoNotTransfer);
		dialogFragment.SetupDialog(dialog, style);
	}

	[Register("setupDialog", "(Landroid/app/Dialog;I)V", "GetSetupDialog_Landroid_app_Dialog_IHandler")]
	public unsafe virtual void SetupDialog(Dialog dialog, int style)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dialog?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(style);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setupDialog.(Landroid/app/Dialog;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dialog);
		}
	}

	private static Delegate GetShow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_Handler()
	{
		if ((object)cb_show_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_ == null)
		{
			cb_show_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Show_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_));
		}
		return cb_show_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_;
	}

	private static void n_Show_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_manager, IntPtr native_tag)
	{
		DialogFragment dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FragmentManager manager = Java.Lang.Object.GetObject<FragmentManager>(native_manager, JniHandleOwnership.DoNotTransfer);
		string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
		dialogFragment.Show(manager, tag);
	}

	[Register("show", "(Landroidx/fragment/app/FragmentManager;Ljava/lang/String;)V", "GetShow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_Handler")]
	public unsafe virtual void Show(FragmentManager manager, string tag)
	{
		IntPtr intPtr = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(manager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeVirtualVoidMethod("show.(Landroidx/fragment/app/FragmentManager;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(manager);
		}
	}

	private static Delegate GetShow_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_Handler()
	{
		if ((object)cb_show_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_ == null)
		{
			cb_show_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_Show_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_));
		}
		return cb_show_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_;
	}

	private static int n_Show_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_transaction, IntPtr native_tag)
	{
		DialogFragment dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FragmentTransaction transaction = Java.Lang.Object.GetObject<FragmentTransaction>(native_transaction, JniHandleOwnership.DoNotTransfer);
		string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
		return dialogFragment.Show(transaction, tag);
	}

	[Register("show", "(Landroidx/fragment/app/FragmentTransaction;Ljava/lang/String;)I", "GetShow_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_Handler")]
	public unsafe virtual int Show(FragmentTransaction transaction, string tag)
	{
		IntPtr intPtr = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(transaction?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			return _members.InstanceMethods.InvokeVirtualInt32Method("show.(Landroidx/fragment/app/FragmentTransaction;Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(transaction);
		}
	}

	private static Delegate GetShowNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_Handler()
	{
		if ((object)cb_showNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_ == null)
		{
			cb_showNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ShowNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_));
		}
		return cb_showNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_;
	}

	private static void n_ShowNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_manager, IntPtr native_tag)
	{
		DialogFragment dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FragmentManager manager = Java.Lang.Object.GetObject<FragmentManager>(native_manager, JniHandleOwnership.DoNotTransfer);
		string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
		dialogFragment.ShowNow(manager, tag);
	}

	[Register("showNow", "(Landroidx/fragment/app/FragmentManager;Ljava/lang/String;)V", "GetShowNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_Handler")]
	public unsafe virtual void ShowNow(FragmentManager manager, string tag)
	{
		IntPtr intPtr = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(manager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeVirtualVoidMethod("showNow.(Landroidx/fragment/app/FragmentManager;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(manager);
		}
	}
}
[Register("androidx/fragment/app/Fragment", DoNotGenerateAcw = true)]
public class Fragment : Java.Lang.Object, IComponentCallbacks, IJavaObject, IDisposable, IJavaPeerable, View.IOnCreateContextMenuListener, IActivityResultCaller, IHasDefaultViewModelProviderFactory, ILifecycleOwner, IViewModelStoreOwner, ISavedStateRegistryOwner
{
	[Register("androidx/fragment/app/Fragment$SavedState", DoNotGenerateAcw = true)]
	public class SavedState : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/Fragment$SavedState", typeof(SavedState));

		private static Delegate cb_describeContents;

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected SavedState(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SavedState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe virtual int DescribeContents()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
		}

		private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
		{
			if ((object)cb_writeToParcel_Landroid_os_Parcel_I == null)
			{
				cb_writeToParcel_Landroid_os_Parcel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I));
			}
			return cb_writeToParcel_Landroid_os_Parcel_I;
		}

		private static void n_WriteToParcel_Landroid_os_Parcel_I(IntPtr jnienv, IntPtr native__this, IntPtr native_dest, int native_flags)
		{
			SavedState savedState = Java.Lang.Object.GetObject<SavedState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			savedState.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe virtual void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dest);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/Fragment", typeof(Fragment));

	private static Delegate cb_getAllowEnterTransitionOverlap;

	private static Delegate cb_setAllowEnterTransitionOverlap_Z;

	private static Delegate cb_getAllowReturnTransitionOverlap;

	private static Delegate cb_setAllowReturnTransitionOverlap_Z;

	private static Delegate cb_getContext;

	private static Delegate cb_getDefaultViewModelProviderFactory;

	private static Delegate cb_getEnterTransition;

	private static Delegate cb_setEnterTransition_Ljava_lang_Object_;

	private static Delegate cb_getExitTransition;

	private static Delegate cb_setExitTransition_Ljava_lang_Object_;

	private static Delegate cb_getLifecycle;

	private static Delegate cb_getLoaderManager;

	private static Delegate cb_getReenterTransition;

	private static Delegate cb_setReenterTransition_Ljava_lang_Object_;

	private static Delegate cb_getReturnTransition;

	private static Delegate cb_setReturnTransition_Ljava_lang_Object_;

	private static Delegate cb_getSharedElementEnterTransition;

	private static Delegate cb_setSharedElementEnterTransition_Ljava_lang_Object_;

	private static Delegate cb_getSharedElementReturnTransition;

	private static Delegate cb_setSharedElementReturnTransition_Ljava_lang_Object_;

	private static Delegate cb_getUserVisibleHint;

	private static Delegate cb_setUserVisibleHint_Z;

	private static Delegate cb_getView;

	private static Delegate cb_getViewLifecycleOwner;

	private static Delegate cb_getViewLifecycleOwnerLiveData;

	private static Delegate cb_getViewModelStore;

	private static Delegate cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;

	private static Delegate cb_getLayoutInflater_Landroid_os_Bundle_;

	private static Delegate cb_onActivityCreated_Landroid_os_Bundle_;

	private static Delegate cb_onActivityResult_IILandroid_content_Intent_;

	private static Delegate cb_onAttach_Landroid_app_Activity_;

	private static Delegate cb_onAttach_Landroid_content_Context_;

	private static Delegate cb_onAttachFragment_Landroidx_fragment_app_Fragment_;

	private static Delegate cb_onConfigurationChanged_Landroid_content_res_Configuration_;

	private static Delegate cb_onContextItemSelected_Landroid_view_MenuItem_;

	private static Delegate cb_onCreate_Landroid_os_Bundle_;

	private static Delegate cb_onCreateAnimation_IZI;

	private static Delegate cb_onCreateAnimator_IZI;

	private static Delegate cb_onCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_;

	private static Delegate cb_onCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_;

	private static Delegate cb_onCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_;

	private static Delegate cb_onDestroy;

	private static Delegate cb_onDestroyOptionsMenu;

	private static Delegate cb_onDestroyView;

	private static Delegate cb_onDetach;

	private static Delegate cb_onGetLayoutInflater_Landroid_os_Bundle_;

	private static Delegate cb_onHiddenChanged_Z;

	private static Delegate cb_onInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_;

	private static Delegate cb_onInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_;

	private static Delegate cb_onLowMemory;

	private static Delegate cb_onMultiWindowModeChanged_Z;

	private static Delegate cb_onOptionsItemSelected_Landroid_view_MenuItem_;

	private static Delegate cb_onOptionsMenuClosed_Landroid_view_Menu_;

	private static Delegate cb_onPause;

	private static Delegate cb_onPictureInPictureModeChanged_Z;

	private static Delegate cb_onPrepareOptionsMenu_Landroid_view_Menu_;

	private static Delegate cb_onPrimaryNavigationFragmentChanged_Z;

	private static Delegate cb_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI;

	private static Delegate cb_onResume;

	private static Delegate cb_onSaveInstanceState_Landroid_os_Bundle_;

	private static Delegate cb_onStart;

	private static Delegate cb_onStop;

	private static Delegate cb_onViewCreated_Landroid_view_View_Landroid_os_Bundle_;

	private static Delegate cb_onViewStateRestored_Landroid_os_Bundle_;

	private static Delegate cb_postponeEnterTransition;

	private static Delegate cb_registerForContextMenu_Landroid_view_View_;

	private static Delegate cb_setEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_;

	private static Delegate cb_setExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_;

	private static Delegate cb_setInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_;

	private static Delegate cb_setMenuVisibility_Z;

	private static Delegate cb_setTargetFragment_Landroidx_fragment_app_Fragment_I;

	private static Delegate cb_shouldShowRequestPermissionRationale_Ljava_lang_String_;

	private static Delegate cb_startActivity_Landroid_content_Intent_;

	private static Delegate cb_startActivity_Landroid_content_Intent_Landroid_os_Bundle_;

	private static Delegate cb_startActivityForResult_Landroid_content_Intent_I;

	private static Delegate cb_startActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_;

	private static Delegate cb_startIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_;

	private static Delegate cb_startPostponedEnterTransition;

	private static Delegate cb_unregisterForContextMenu_Landroid_view_View_;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe FragmentActivity Activity
	{
		[Register("getActivity", "()Landroidx/fragment/app/FragmentActivity;", "")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentActivity>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getActivity.()Landroidx/fragment/app/FragmentActivity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool AllowEnterTransitionOverlap
	{
		[Register("getAllowEnterTransitionOverlap", "()Z", "GetGetAllowEnterTransitionOverlapHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getAllowEnterTransitionOverlap.()Z", this, null);
		}
		[Register("setAllowEnterTransitionOverlap", "(Z)V", "GetSetAllowEnterTransitionOverlap_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAllowEnterTransitionOverlap.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool AllowReturnTransitionOverlap
	{
		[Register("getAllowReturnTransitionOverlap", "()Z", "GetGetAllowReturnTransitionOverlapHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getAllowReturnTransitionOverlap.()Z", this, null);
		}
		[Register("setAllowReturnTransitionOverlap", "(Z)V", "GetSetAllowReturnTransitionOverlap_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAllowReturnTransitionOverlap.(Z)V", this, ptr);
		}
	}

	public unsafe Bundle Arguments
	{
		[Register("getArguments", "()Landroid/os/Bundle;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getArguments.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setArguments", "(Landroid/os/Bundle;)V", "GetSetArguments_Landroid_os_Bundle_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setArguments.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe FragmentManager ChildFragmentManager
	{
		[Register("getChildFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getChildFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Context Context
	{
		[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ViewModelProvider.IFactory DefaultViewModelProviderFactory
	{
		[Register("getDefaultViewModelProviderFactory", "()Landroidx/lifecycle/ViewModelProvider$Factory;", "GetGetDefaultViewModelProviderFactoryHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ViewModelProvider.IFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultViewModelProviderFactory.()Landroidx/lifecycle/ViewModelProvider$Factory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Java.Lang.Object EnterTransition
	{
		[Register("getEnterTransition", "()Ljava/lang/Object;", "GetGetEnterTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEnterTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setEnterTransition", "(Ljava/lang/Object;)V", "GetSetEnterTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEnterTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual Java.Lang.Object ExitTransition
	{
		[Register("getExitTransition", "()Ljava/lang/Object;", "GetGetExitTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExitTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setExitTransition", "(Ljava/lang/Object;)V", "GetSetExitTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setExitTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe FragmentManager FragmentManager
	{
		[Register("getFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool HasOptionsMenu
	{
		[Register("hasOptionsMenu", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasOptionsMenu.()Z", this, null);
		}
		[Register("setHasOptionsMenu", "(Z)V", "GetSetHasOptionsMenu_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHasOptionsMenu.(Z)V", this, ptr);
		}
	}

	public unsafe Java.Lang.Object Host
	{
		[Register("getHost", "()Ljava/lang/Object;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getHost.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int Id
	{
		[Register("getId", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getId.()I", this, null);
		}
	}

	public unsafe bool IsAdded
	{
		[Register("isAdded", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isAdded.()Z", this, null);
		}
	}

	public unsafe bool IsDetached
	{
		[Register("isDetached", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isDetached.()Z", this, null);
		}
	}

	public unsafe bool IsHidden
	{
		[Register("isHidden", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isHidden.()Z", this, null);
		}
	}

	public unsafe bool IsInLayout
	{
		[Register("isInLayout", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isInLayout.()Z", this, null);
		}
	}

	public unsafe bool IsMenuVisible
	{
		[Register("isMenuVisible", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isMenuVisible.()Z", this, null);
		}
	}

	public unsafe bool IsRemoving
	{
		[Register("isRemoving", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isRemoving.()Z", this, null);
		}
	}

	public unsafe bool IsResumed
	{
		[Register("isResumed", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isResumed.()Z", this, null);
		}
	}

	public unsafe bool IsStateSaved
	{
		[Register("isStateSaved", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isStateSaved.()Z", this, null);
		}
	}

	public unsafe bool IsVisible
	{
		[Register("isVisible", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isVisible.()Z", this, null);
		}
	}

	public unsafe LayoutInflater LayoutInflater
	{
		[Register("getLayoutInflater", "()Landroid/view/LayoutInflater;", "")]
		get
		{
			return Java.Lang.Object.GetObject<LayoutInflater>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLayoutInflater.()Landroid/view/LayoutInflater;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual AndroidX.Lifecycle.Lifecycle Lifecycle
	{
		[Register("getLifecycle", "()Landroidx/lifecycle/Lifecycle;", "GetGetLifecycleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Lifecycle.Lifecycle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLifecycle.()Landroidx/lifecycle/Lifecycle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual LoaderManager LoaderManager
	{
		[Register("getLoaderManager", "()Landroidx/loader/app/LoaderManager;", "GetGetLoaderManagerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LoaderManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLoaderManager.()Landroidx/loader/app/LoaderManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Fragment ParentFragment
	{
		[Register("getParentFragment", "()Landroidx/fragment/app/Fragment;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getParentFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe FragmentManager ParentFragmentManager
	{
		[Register("getParentFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getParentFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Java.Lang.Object ReenterTransition
	{
		[Register("getReenterTransition", "()Ljava/lang/Object;", "GetGetReenterTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getReenterTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setReenterTransition", "(Ljava/lang/Object;)V", "GetSetReenterTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setReenterTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe Resources Resources
	{
		[Register("getResources", "()Landroid/content/res/Resources;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Resources>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getResources.()Landroid/content/res/Resources;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool RetainInstance
	{
		[Register("getRetainInstance", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getRetainInstance.()Z", this, null);
		}
		[Register("setRetainInstance", "(Z)V", "GetSetRetainInstance_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRetainInstance.(Z)V", this, ptr);
		}
	}

	public unsafe virtual Java.Lang.Object ReturnTransition
	{
		[Register("getReturnTransition", "()Ljava/lang/Object;", "GetGetReturnTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getReturnTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setReturnTransition", "(Ljava/lang/Object;)V", "GetSetReturnTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setReturnTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe SavedStateRegistry SavedStateRegistry
	{
		[Register("getSavedStateRegistry", "()Landroidx/savedstate/SavedStateRegistry;", "")]
		get
		{
			return Java.Lang.Object.GetObject<SavedStateRegistry>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSavedStateRegistry.()Landroidx/savedstate/SavedStateRegistry;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Java.Lang.Object SharedElementEnterTransition
	{
		[Register("getSharedElementEnterTransition", "()Ljava/lang/Object;", "GetGetSharedElementEnterTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSharedElementEnterTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSharedElementEnterTransition", "(Ljava/lang/Object;)V", "GetSetSharedElementEnterTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSharedElementEnterTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual Java.Lang.Object SharedElementReturnTransition
	{
		[Register("getSharedElementReturnTransition", "()Ljava/lang/Object;", "GetGetSharedElementReturnTransitionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSharedElementReturnTransition.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSharedElementReturnTransition", "(Ljava/lang/Object;)V", "GetSetSharedElementReturnTransition_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSharedElementReturnTransition.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe string Tag
	{
		[Register("getTag", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTag.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Fragment TargetFragment
	{
		[Register("getTargetFragment", "()Landroidx/fragment/app/Fragment;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTargetFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int TargetRequestCode
	{
		[Register("getTargetRequestCode", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getTargetRequestCode.()I", this, null);
		}
	}

	public unsafe virtual bool UserVisibleHint
	{
		[Register("getUserVisibleHint", "()Z", "GetGetUserVisibleHintHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getUserVisibleHint.()Z", this, null);
		}
		[Register("setUserVisibleHint", "(Z)V", "GetSetUserVisibleHint_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setUserVisibleHint.(Z)V", this, ptr);
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

	public unsafe virtual ILifecycleOwner ViewLifecycleOwner
	{
		[Register("getViewLifecycleOwner", "()Landroidx/lifecycle/LifecycleOwner;", "GetGetViewLifecycleOwnerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ILifecycleOwner>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewLifecycleOwner.()Landroidx/lifecycle/LifecycleOwner;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual LiveData ViewLifecycleOwnerLiveData
	{
		[Register("getViewLifecycleOwnerLiveData", "()Landroidx/lifecycle/LiveData;", "GetGetViewLifecycleOwnerLiveDataHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewLifecycleOwnerLiveData.()Landroidx/lifecycle/LiveData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ViewModelStore ViewModelStore
	{
		[Register("getViewModelStore", "()Landroidx/lifecycle/ViewModelStore;", "GetGetViewModelStoreHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ViewModelStore>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewModelStore.()Landroidx/lifecycle/ViewModelStore;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Fragment(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Fragment()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe Fragment(int contentLayoutId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(contentLayoutId);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	private static Delegate GetGetAllowEnterTransitionOverlapHandler()
	{
		if ((object)cb_getAllowEnterTransitionOverlap == null)
		{
			cb_getAllowEnterTransitionOverlap = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetAllowEnterTransitionOverlap));
		}
		return cb_getAllowEnterTransitionOverlap;
	}

	private static bool n_GetAllowEnterTransitionOverlap(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowEnterTransitionOverlap;
	}

	private static Delegate GetSetAllowEnterTransitionOverlap_ZHandler()
	{
		if ((object)cb_setAllowEnterTransitionOverlap_Z == null)
		{
			cb_setAllowEnterTransitionOverlap_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetAllowEnterTransitionOverlap_Z));
		}
		return cb_setAllowEnterTransitionOverlap_Z;
	}

	private static void n_SetAllowEnterTransitionOverlap_Z(IntPtr jnienv, IntPtr native__this, bool allow)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowEnterTransitionOverlap = allow;
	}

	private static Delegate GetGetAllowReturnTransitionOverlapHandler()
	{
		if ((object)cb_getAllowReturnTransitionOverlap == null)
		{
			cb_getAllowReturnTransitionOverlap = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetAllowReturnTransitionOverlap));
		}
		return cb_getAllowReturnTransitionOverlap;
	}

	private static bool n_GetAllowReturnTransitionOverlap(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowReturnTransitionOverlap;
	}

	private static Delegate GetSetAllowReturnTransitionOverlap_ZHandler()
	{
		if ((object)cb_setAllowReturnTransitionOverlap_Z == null)
		{
			cb_setAllowReturnTransitionOverlap_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetAllowReturnTransitionOverlap_Z));
		}
		return cb_setAllowReturnTransitionOverlap_Z;
	}

	private static void n_SetAllowReturnTransitionOverlap_Z(IntPtr jnienv, IntPtr native__this, bool allow)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowReturnTransitionOverlap = allow;
	}

	private static Delegate GetGetContextHandler()
	{
		if ((object)cb_getContext == null)
		{
			cb_getContext = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetContext));
		}
		return cb_getContext;
	}

	private static IntPtr n_GetContext(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
	}

	private static Delegate GetGetDefaultViewModelProviderFactoryHandler()
	{
		if ((object)cb_getDefaultViewModelProviderFactory == null)
		{
			cb_getDefaultViewModelProviderFactory = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefaultViewModelProviderFactory));
		}
		return cb_getDefaultViewModelProviderFactory;
	}

	private static IntPtr n_GetDefaultViewModelProviderFactory(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultViewModelProviderFactory);
	}

	private static Delegate GetGetEnterTransitionHandler()
	{
		if ((object)cb_getEnterTransition == null)
		{
			cb_getEnterTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEnterTransition));
		}
		return cb_getEnterTransition;
	}

	private static IntPtr n_GetEnterTransition(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnterTransition);
	}

	private static Delegate GetSetEnterTransition_Ljava_lang_Object_Handler()
	{
		if ((object)cb_setEnterTransition_Ljava_lang_Object_ == null)
		{
			cb_setEnterTransition_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetEnterTransition_Ljava_lang_Object_));
		}
		return cb_setEnterTransition_Ljava_lang_Object_;
	}

	private static void n_SetEnterTransition_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object enterTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
		fragment.EnterTransition = enterTransition;
	}

	private static Delegate GetGetExitTransitionHandler()
	{
		if ((object)cb_getExitTransition == null)
		{
			cb_getExitTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExitTransition));
		}
		return cb_getExitTransition;
	}

	private static IntPtr n_GetExitTransition(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExitTransition);
	}

	private static Delegate GetSetExitTransition_Ljava_lang_Object_Handler()
	{
		if ((object)cb_setExitTransition_Ljava_lang_Object_ == null)
		{
			cb_setExitTransition_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetExitTransition_Ljava_lang_Object_));
		}
		return cb_setExitTransition_Ljava_lang_Object_;
	}

	private static void n_SetExitTransition_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object exitTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
		fragment.ExitTransition = exitTransition;
	}

	private static Delegate GetGetLifecycleHandler()
	{
		if ((object)cb_getLifecycle == null)
		{
			cb_getLifecycle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLifecycle));
		}
		return cb_getLifecycle;
	}

	private static IntPtr n_GetLifecycle(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Lifecycle);
	}

	private static Delegate GetGetLoaderManagerHandler()
	{
		if ((object)cb_getLoaderManager == null)
		{
			cb_getLoaderManager = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLoaderManager));
		}
		return cb_getLoaderManager;
	}

	private static IntPtr n_GetLoaderManager(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoaderManager);
	}

	private static Delegate GetGetReenterTransitionHandler()
	{
		if ((object)cb_getReenterTransition == null)
		{
			cb_getReenterTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetReenterTransition));
		}
		return cb_getReenterTransition;
	}

	private static IntPtr n_GetReenterTransition(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReenterTransition);
	}

	private static Delegate GetSetReenterTransition_Ljava_lang_Object_Handler()
	{
		if ((object)cb_setReenterTransition_Ljava_lang_Object_ == null)
		{
			cb_setReenterTransition_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetReenterTransition_Ljava_lang_Object_));
		}
		return cb_setReenterTransition_Ljava_lang_Object_;
	}

	private static void n_SetReenterTransition_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object reenterTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
		fragment.ReenterTransition = reenterTransition;
	}

	private static Delegate GetGetReturnTransitionHandler()
	{
		if ((object)cb_getReturnTransition == null)
		{
			cb_getReturnTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetReturnTransition));
		}
		return cb_getReturnTransition;
	}

	private static IntPtr n_GetReturnTransition(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReturnTransition);
	}

	private static Delegate GetSetReturnTransition_Ljava_lang_Object_Handler()
	{
		if ((object)cb_setReturnTransition_Ljava_lang_Object_ == null)
		{
			cb_setReturnTransition_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetReturnTransition_Ljava_lang_Object_));
		}
		return cb_setReturnTransition_Ljava_lang_Object_;
	}

	private static void n_SetReturnTransition_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object returnTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
		fragment.ReturnTransition = returnTransition;
	}

	private static Delegate GetGetSharedElementEnterTransitionHandler()
	{
		if ((object)cb_getSharedElementEnterTransition == null)
		{
			cb_getSharedElementEnterTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSharedElementEnterTransition));
		}
		return cb_getSharedElementEnterTransition;
	}

	private static IntPtr n_GetSharedElementEnterTransition(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SharedElementEnterTransition);
	}

	private static Delegate GetSetSharedElementEnterTransition_Ljava_lang_Object_Handler()
	{
		if ((object)cb_setSharedElementEnterTransition_Ljava_lang_Object_ == null)
		{
			cb_setSharedElementEnterTransition_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetSharedElementEnterTransition_Ljava_lang_Object_));
		}
		return cb_setSharedElementEnterTransition_Ljava_lang_Object_;
	}

	private static void n_SetSharedElementEnterTransition_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object sharedElementEnterTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
		fragment.SharedElementEnterTransition = sharedElementEnterTransition;
	}

	private static Delegate GetGetSharedElementReturnTransitionHandler()
	{
		if ((object)cb_getSharedElementReturnTransition == null)
		{
			cb_getSharedElementReturnTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSharedElementReturnTransition));
		}
		return cb_getSharedElementReturnTransition;
	}

	private static IntPtr n_GetSharedElementReturnTransition(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SharedElementReturnTransition);
	}

	private static Delegate GetSetSharedElementReturnTransition_Ljava_lang_Object_Handler()
	{
		if ((object)cb_setSharedElementReturnTransition_Ljava_lang_Object_ == null)
		{
			cb_setSharedElementReturnTransition_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetSharedElementReturnTransition_Ljava_lang_Object_));
		}
		return cb_setSharedElementReturnTransition_Ljava_lang_Object_;
	}

	private static void n_SetSharedElementReturnTransition_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object sharedElementReturnTransition = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transition, JniHandleOwnership.DoNotTransfer);
		fragment.SharedElementReturnTransition = sharedElementReturnTransition;
	}

	private static Delegate GetGetUserVisibleHintHandler()
	{
		if ((object)cb_getUserVisibleHint == null)
		{
			cb_getUserVisibleHint = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetUserVisibleHint));
		}
		return cb_getUserVisibleHint;
	}

	private static bool n_GetUserVisibleHint(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UserVisibleHint;
	}

	private static Delegate GetSetUserVisibleHint_ZHandler()
	{
		if ((object)cb_setUserVisibleHint_Z == null)
		{
			cb_setUserVisibleHint_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetUserVisibleHint_Z));
		}
		return cb_setUserVisibleHint_Z;
	}

	private static void n_SetUserVisibleHint_Z(IntPtr jnienv, IntPtr native__this, bool isVisibleToUser)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UserVisibleHint = isVisibleToUser;
	}

	private static Delegate GetGetViewHandler()
	{
		if ((object)cb_getView == null)
		{
			cb_getView = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetView));
		}
		return cb_getView;
	}

	private static IntPtr n_GetView(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).View);
	}

	private static Delegate GetGetViewLifecycleOwnerHandler()
	{
		if ((object)cb_getViewLifecycleOwner == null)
		{
			cb_getViewLifecycleOwner = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetViewLifecycleOwner));
		}
		return cb_getViewLifecycleOwner;
	}

	private static IntPtr n_GetViewLifecycleOwner(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewLifecycleOwner);
	}

	private static Delegate GetGetViewLifecycleOwnerLiveDataHandler()
	{
		if ((object)cb_getViewLifecycleOwnerLiveData == null)
		{
			cb_getViewLifecycleOwnerLiveData = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetViewLifecycleOwnerLiveData));
		}
		return cb_getViewLifecycleOwnerLiveData;
	}

	private static IntPtr n_GetViewLifecycleOwnerLiveData(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewLifecycleOwnerLiveData);
	}

	private static Delegate GetGetViewModelStoreHandler()
	{
		if ((object)cb_getViewModelStore == null)
		{
			cb_getViewModelStore = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetViewModelStore));
		}
		return cb_getViewModelStore;
	}

	private static IntPtr n_GetViewModelStore(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewModelStore);
	}

	private static Delegate GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
	{
		if ((object)cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ == null)
		{
			cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_));
		}
		return cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;
	}

	private static void n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_prefix, IntPtr native_fd, IntPtr native_writer, IntPtr native_args)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
		FileDescriptor fd = Java.Lang.Object.GetObject<FileDescriptor>(native_fd, JniHandleOwnership.DoNotTransfer);
		PrintWriter writer = Java.Lang.Object.GetObject<PrintWriter>(native_writer, JniHandleOwnership.DoNotTransfer);
		string[] array = (string[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(string));
		fragment.Dump(prefix, fd, writer, array);
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_args);
		}
	}

	[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
	public unsafe virtual void Dump(string prefix, FileDescriptor fd, PrintWriter writer, string[] args)
	{
		IntPtr intPtr = JNIEnv.NewString(prefix);
		IntPtr intPtr2 = JNIEnv.NewArray(args);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(fd?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(writer?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(intPtr2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dump.(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			if (args != null)
			{
				JNIEnv.CopyArray(intPtr2, args);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(fd);
			GC.KeepAlive(writer);
			GC.KeepAlive(args);
		}
	}

	[Register("equals", "(Ljava/lang/Object;)Z", "")]
	public unsafe sealed override bool Equals(Java.Lang.Object o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	private static Delegate GetGetLayoutInflater_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_getLayoutInflater_Landroid_os_Bundle_ == null)
		{
			cb_getLayoutInflater_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetLayoutInflater_Landroid_os_Bundle_));
		}
		return cb_getLayoutInflater_Landroid_os_Bundle_;
	}

	private static IntPtr n_GetLayoutInflater_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_savedFragmentState)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle savedFragmentState = Java.Lang.Object.GetObject<Bundle>(native_savedFragmentState, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragment.GetLayoutInflater(savedFragmentState));
	}

	[Register("getLayoutInflater", "(Landroid/os/Bundle;)Landroid/view/LayoutInflater;", "GetGetLayoutInflater_Landroid_os_Bundle_Handler")]
	public unsafe virtual LayoutInflater GetLayoutInflater(Bundle savedFragmentState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedFragmentState?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LayoutInflater>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLayoutInflater.(Landroid/os/Bundle;)Landroid/view/LayoutInflater;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(savedFragmentState);
		}
	}

	[Register("getString", "(I)Ljava/lang/String;", "")]
	public unsafe string GetString(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getString.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getString", "(I[Ljava/lang/Object;)Ljava/lang/String;", "")]
	public unsafe string GetString(int resId, params Java.Lang.Object[] formatArgs)
	{
		IntPtr intPtr = JNIEnv.NewArray(formatArgs);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resId);
			ptr[1] = new JniArgumentValue(intPtr);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getString.(I[Ljava/lang/Object;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (formatArgs != null)
			{
				JNIEnv.CopyArray(intPtr, formatArgs);
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(formatArgs);
		}
	}

	[Register("getText", "(I)Ljava/lang/CharSequence;", "")]
	public unsafe ICharSequence GetTextFormatted(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getText.(I)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public string GetText(int resId)
	{
		return GetTextFormatted(resId)?.ToString();
	}

	[Register("hashCode", "()I", "")]
	public unsafe sealed override int GetHashCode()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("hashCode.()I", this, null);
	}

	[Register("instantiate", "(Landroid/content/Context;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", "")]
	public unsafe static Fragment Instantiate(Context context, string fname)
	{
		IntPtr intPtr = JNIEnv.NewString(fname);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Fragment>(_members.StaticMethods.InvokeObjectMethod("instantiate.(Landroid/content/Context;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(context);
		}
	}

	[Register("instantiate", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)Landroidx/fragment/app/Fragment;", "")]
	public unsafe static Fragment Instantiate(Context context, string fname, Bundle args)
	{
		IntPtr intPtr = JNIEnv.NewString(fname);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Fragment>(_members.StaticMethods.InvokeObjectMethod("instantiate.(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)Landroidx/fragment/app/Fragment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(context);
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetOnActivityCreated_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onActivityCreated_Landroid_os_Bundle_ == null)
		{
			cb_onActivityCreated_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnActivityCreated_Landroid_os_Bundle_));
		}
		return cb_onActivityCreated_Landroid_os_Bundle_;
	}

	private static void n_OnActivityCreated_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_savedInstanceState)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
		fragment.OnActivityCreated(savedInstanceState);
	}

	[Register("onActivityCreated", "(Landroid/os/Bundle;)V", "GetOnActivityCreated_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnActivityCreated(Bundle savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityCreated.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnActivityResult_IILandroid_content_Intent_Handler()
	{
		if ((object)cb_onActivityResult_IILandroid_content_Intent_ == null)
		{
			cb_onActivityResult_IILandroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIL_V(n_OnActivityResult_IILandroid_content_Intent_));
		}
		return cb_onActivityResult_IILandroid_content_Intent_;
	}

	private static void n_OnActivityResult_IILandroid_content_Intent_(IntPtr jnienv, IntPtr native__this, int requestCode, int resultCode, IntPtr native_data)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Intent data = Java.Lang.Object.GetObject<Intent>(native_data, JniHandleOwnership.DoNotTransfer);
		fragment.OnActivityResult(requestCode, resultCode, data);
	}

	[Register("onActivityResult", "(IILandroid/content/Intent;)V", "GetOnActivityResult_IILandroid_content_Intent_Handler")]
	public unsafe virtual void OnActivityResult(int requestCode, int resultCode, Intent data)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue(resultCode);
			ptr[2] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityResult.(IILandroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(data);
		}
	}

	private static Delegate GetOnAttach_Landroid_app_Activity_Handler()
	{
		if ((object)cb_onAttach_Landroid_app_Activity_ == null)
		{
			cb_onAttach_Landroid_app_Activity_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnAttach_Landroid_app_Activity_));
		}
		return cb_onAttach_Landroid_app_Activity_;
	}

	private static void n_OnAttach_Landroid_app_Activity_(IntPtr jnienv, IntPtr native__this, IntPtr native_activity)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Android.App.Activity activity = Java.Lang.Object.GetObject<Android.App.Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
		fragment.OnAttach(activity);
	}

	[Register("onAttach", "(Landroid/app/Activity;)V", "GetOnAttach_Landroid_app_Activity_Handler")]
	public unsafe virtual void OnAttach(Android.App.Activity activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAttach.(Landroid/app/Activity;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	private static Delegate GetOnAttach_Landroid_content_Context_Handler()
	{
		if ((object)cb_onAttach_Landroid_content_Context_ == null)
		{
			cb_onAttach_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnAttach_Landroid_content_Context_));
		}
		return cb_onAttach_Landroid_content_Context_;
	}

	private static void n_OnAttach_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
		fragment.OnAttach(context);
	}

	[Register("onAttach", "(Landroid/content/Context;)V", "GetOnAttach_Landroid_content_Context_Handler")]
	public unsafe virtual void OnAttach(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAttach.(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetOnAttachFragment_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_onAttachFragment_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_onAttachFragment_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnAttachFragment_Landroidx_fragment_app_Fragment_));
		}
		return cb_onAttachFragment_Landroidx_fragment_app_Fragment_;
	}

	private static void n_OnAttachFragment_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_childFragment)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment childFragment = Java.Lang.Object.GetObject<Fragment>(native_childFragment, JniHandleOwnership.DoNotTransfer);
		fragment.OnAttachFragment(childFragment);
	}

	[Register("onAttachFragment", "(Landroidx/fragment/app/Fragment;)V", "GetOnAttachFragment_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual void OnAttachFragment(Fragment childFragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(childFragment?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachFragment.(Landroidx/fragment/app/Fragment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(childFragment);
		}
	}

	private static Delegate GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler()
	{
		if ((object)cb_onConfigurationChanged_Landroid_content_res_Configuration_ == null)
		{
			cb_onConfigurationChanged_Landroid_content_res_Configuration_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnConfigurationChanged_Landroid_content_res_Configuration_));
		}
		return cb_onConfigurationChanged_Landroid_content_res_Configuration_;
	}

	private static void n_OnConfigurationChanged_Landroid_content_res_Configuration_(IntPtr jnienv, IntPtr native__this, IntPtr native_newConfig)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Configuration newConfig = Java.Lang.Object.GetObject<Configuration>(native_newConfig, JniHandleOwnership.DoNotTransfer);
		fragment.OnConfigurationChanged(newConfig);
	}

	[Register("onConfigurationChanged", "(Landroid/content/res/Configuration;)V", "GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler")]
	public unsafe virtual void OnConfigurationChanged(Configuration newConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(newConfig?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onConfigurationChanged.(Landroid/content/res/Configuration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(newConfig);
		}
	}

	private static Delegate GetOnContextItemSelected_Landroid_view_MenuItem_Handler()
	{
		if ((object)cb_onContextItemSelected_Landroid_view_MenuItem_ == null)
		{
			cb_onContextItemSelected_Landroid_view_MenuItem_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnContextItemSelected_Landroid_view_MenuItem_));
		}
		return cb_onContextItemSelected_Landroid_view_MenuItem_;
	}

	private static bool n_OnContextItemSelected_Landroid_view_MenuItem_(IntPtr jnienv, IntPtr native__this, IntPtr native_item)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
		return fragment.OnContextItemSelected(item);
	}

	[Register("onContextItemSelected", "(Landroid/view/MenuItem;)Z", "GetOnContextItemSelected_Landroid_view_MenuItem_Handler")]
	public unsafe virtual bool OnContextItemSelected(IMenuItem item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onContextItemSelected.(Landroid/view/MenuItem;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetOnCreate_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onCreate_Landroid_os_Bundle_ == null)
		{
			cb_onCreate_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCreate_Landroid_os_Bundle_));
		}
		return cb_onCreate_Landroid_os_Bundle_;
	}

	private static void n_OnCreate_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_savedInstanceState)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
		fragment.OnCreate(savedInstanceState);
	}

	[Register("onCreate", "(Landroid/os/Bundle;)V", "GetOnCreate_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnCreate(Bundle savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCreate.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnCreateAnimation_IZIHandler()
	{
		if ((object)cb_onCreateAnimation_IZI == null)
		{
			cb_onCreateAnimation_IZI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIZI_L(n_OnCreateAnimation_IZI));
		}
		return cb_onCreateAnimation_IZI;
	}

	private static IntPtr n_OnCreateAnimation_IZI(IntPtr jnienv, IntPtr native__this, int transit, bool enter, int nextAnim)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreateAnimation(transit, enter, nextAnim));
	}

	[Register("onCreateAnimation", "(IZI)Landroid/view/animation/Animation;", "GetOnCreateAnimation_IZIHandler")]
	public unsafe virtual Animation OnCreateAnimation(int transit, bool enter, int nextAnim)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(transit);
		ptr[1] = new JniArgumentValue(enter);
		ptr[2] = new JniArgumentValue(nextAnim);
		return Java.Lang.Object.GetObject<Animation>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateAnimation.(IZI)Landroid/view/animation/Animation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnCreateAnimator_IZIHandler()
	{
		if ((object)cb_onCreateAnimator_IZI == null)
		{
			cb_onCreateAnimator_IZI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIZI_L(n_OnCreateAnimator_IZI));
		}
		return cb_onCreateAnimator_IZI;
	}

	private static IntPtr n_OnCreateAnimator_IZI(IntPtr jnienv, IntPtr native__this, int transit, bool enter, int nextAnim)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreateAnimator(transit, enter, nextAnim));
	}

	[Register("onCreateAnimator", "(IZI)Landroid/animation/Animator;", "GetOnCreateAnimator_IZIHandler")]
	public unsafe virtual Animator OnCreateAnimator(int transit, bool enter, int nextAnim)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(transit);
		ptr[1] = new JniArgumentValue(enter);
		ptr[2] = new JniArgumentValue(nextAnim);
		return Java.Lang.Object.GetObject<Animator>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateAnimator.(IZI)Landroid/animation/Animator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_Handler()
	{
		if ((object)cb_onCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_ == null)
		{
			cb_onCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_));
		}
		return cb_onCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_;
	}

	private static void n_OnCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_menu, IntPtr native_v, IntPtr native_menuInfo)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IContextMenu menu = Java.Lang.Object.GetObject<IContextMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
		View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
		IContextMenuContextMenuInfo menuInfo = Java.Lang.Object.GetObject<IContextMenuContextMenuInfo>(native_menuInfo, JniHandleOwnership.DoNotTransfer);
		fragment.OnCreateContextMenu(menu, v, menuInfo);
	}

	[Register("onCreateContextMenu", "(Landroid/view/ContextMenu;Landroid/view/View;Landroid/view/ContextMenu$ContextMenuInfo;)V", "GetOnCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_Handler")]
	public unsafe virtual void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			ptr[1] = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((menuInfo == null) ? IntPtr.Zero : ((Java.Lang.Object)menuInfo).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCreateContextMenu.(Landroid/view/ContextMenu;Landroid/view/View;Landroid/view/ContextMenu$ContextMenuInfo;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
			GC.KeepAlive(v);
			GC.KeepAlive(menuInfo);
		}
	}

	private static Delegate GetOnCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_Handler()
	{
		if ((object)cb_onCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_ == null)
		{
			cb_onCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_));
		}
		return cb_onCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_;
	}

	private static void n_OnCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_(IntPtr jnienv, IntPtr native__this, IntPtr native_menu, IntPtr native_inflater)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
		MenuInflater inflater = Java.Lang.Object.GetObject<MenuInflater>(native_inflater, JniHandleOwnership.DoNotTransfer);
		fragment.OnCreateOptionsMenu(menu, inflater);
	}

	[Register("onCreateOptionsMenu", "(Landroid/view/Menu;Landroid/view/MenuInflater;)V", "GetOnCreateOptionsMenu_Landroid_view_Menu_Landroid_view_MenuInflater_Handler")]
	public unsafe virtual void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			ptr[1] = new JniArgumentValue(inflater?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCreateOptionsMenu.(Landroid/view/Menu;Landroid/view/MenuInflater;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
			GC.KeepAlive(inflater);
		}
	}

	private static Delegate GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_ == null)
		{
			cb_onCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_OnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_));
		}
		return cb_onCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_;
	}

	private static IntPtr n_OnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_inflater, IntPtr native_container, IntPtr native_savedInstanceState)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LayoutInflater inflater = Java.Lang.Object.GetObject<LayoutInflater>(native_inflater, JniHandleOwnership.DoNotTransfer);
		ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
		Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragment.OnCreateView(inflater, container, savedInstanceState));
	}

	[Register("onCreateView", "(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;", "GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler")]
	public unsafe virtual View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(inflater?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateView.(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(inflater);
			GC.KeepAlive(container);
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnDestroyHandler()
	{
		if ((object)cb_onDestroy == null)
		{
			cb_onDestroy = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnDestroy));
		}
		return cb_onDestroy;
	}

	private static void n_OnDestroy(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroy();
	}

	[Register("onDestroy", "()V", "GetOnDestroyHandler")]
	public unsafe virtual void OnDestroy()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroy.()V", this, null);
	}

	private static Delegate GetOnDestroyOptionsMenuHandler()
	{
		if ((object)cb_onDestroyOptionsMenu == null)
		{
			cb_onDestroyOptionsMenu = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnDestroyOptionsMenu));
		}
		return cb_onDestroyOptionsMenu;
	}

	private static void n_OnDestroyOptionsMenu(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroyOptionsMenu();
	}

	[Register("onDestroyOptionsMenu", "()V", "GetOnDestroyOptionsMenuHandler")]
	public unsafe virtual void OnDestroyOptionsMenu()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroyOptionsMenu.()V", this, null);
	}

	private static Delegate GetOnDestroyViewHandler()
	{
		if ((object)cb_onDestroyView == null)
		{
			cb_onDestroyView = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnDestroyView));
		}
		return cb_onDestroyView;
	}

	private static void n_OnDestroyView(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroyView();
	}

	[Register("onDestroyView", "()V", "GetOnDestroyViewHandler")]
	public unsafe virtual void OnDestroyView()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroyView.()V", this, null);
	}

	private static Delegate GetOnDetachHandler()
	{
		if ((object)cb_onDetach == null)
		{
			cb_onDetach = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnDetach));
		}
		return cb_onDetach;
	}

	private static void n_OnDetach(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetach();
	}

	[Register("onDetach", "()V", "GetOnDetachHandler")]
	public unsafe virtual void OnDetach()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDetach.()V", this, null);
	}

	private static Delegate GetOnGetLayoutInflater_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onGetLayoutInflater_Landroid_os_Bundle_ == null)
		{
			cb_onGetLayoutInflater_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnGetLayoutInflater_Landroid_os_Bundle_));
		}
		return cb_onGetLayoutInflater_Landroid_os_Bundle_;
	}

	private static IntPtr n_OnGetLayoutInflater_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_savedInstanceState)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragment.OnGetLayoutInflater(savedInstanceState));
	}

	[Register("onGetLayoutInflater", "(Landroid/os/Bundle;)Landroid/view/LayoutInflater;", "GetOnGetLayoutInflater_Landroid_os_Bundle_Handler")]
	public unsafe virtual LayoutInflater OnGetLayoutInflater(Bundle savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LayoutInflater>(_members.InstanceMethods.InvokeVirtualObjectMethod("onGetLayoutInflater.(Landroid/os/Bundle;)Landroid/view/LayoutInflater;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnHiddenChanged_ZHandler()
	{
		if ((object)cb_onHiddenChanged_Z == null)
		{
			cb_onHiddenChanged_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnHiddenChanged_Z));
		}
		return cb_onHiddenChanged_Z;
	}

	private static void n_OnHiddenChanged_Z(IntPtr jnienv, IntPtr native__this, bool hidden)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnHiddenChanged(hidden);
	}

	[Register("onHiddenChanged", "(Z)V", "GetOnHiddenChanged_ZHandler")]
	public unsafe virtual void OnHiddenChanged(bool hidden)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(hidden);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onHiddenChanged.(Z)V", this, ptr);
	}

	private static Delegate GetOnInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_ == null)
		{
			cb_onInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_));
		}
		return cb_onInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_;
	}

	private static void n_OnInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_activity, IntPtr native_attrs, IntPtr native_savedInstanceState)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Android.App.Activity activity = Java.Lang.Object.GetObject<Android.App.Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
		IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
		Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
		fragment.OnInflate(activity, attrs, savedInstanceState);
	}

	[Register("onInflate", "(Landroid/app/Activity;Landroid/util/AttributeSet;Landroid/os/Bundle;)V", "GetOnInflate_Landroid_app_Activity_Landroid_util_AttributeSet_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnInflate(Android.App.Activity activity, IAttributeSet attrs, Bundle savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onInflate.(Landroid/app/Activity;Landroid/util/AttributeSet;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(attrs);
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_ == null)
		{
			cb_onInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_));
		}
		return cb_onInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_;
	}

	private static void n_OnInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_attrs, IntPtr native_savedInstanceState)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
		IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
		Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
		fragment.OnInflate(context, attrs, savedInstanceState);
	}

	[Register("onInflate", "(Landroid/content/Context;Landroid/util/AttributeSet;Landroid/os/Bundle;)V", "GetOnInflate_Landroid_content_Context_Landroid_util_AttributeSet_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnInflate(Context context, IAttributeSet attrs, Bundle savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onInflate.(Landroid/content/Context;Landroid/util/AttributeSet;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnLowMemoryHandler()
	{
		if ((object)cb_onLowMemory == null)
		{
			cb_onLowMemory = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnLowMemory));
		}
		return cb_onLowMemory;
	}

	private static void n_OnLowMemory(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLowMemory();
	}

	[Register("onLowMemory", "()V", "GetOnLowMemoryHandler")]
	public unsafe virtual void OnLowMemory()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLowMemory.()V", this, null);
	}

	private static Delegate GetOnMultiWindowModeChanged_ZHandler()
	{
		if ((object)cb_onMultiWindowModeChanged_Z == null)
		{
			cb_onMultiWindowModeChanged_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnMultiWindowModeChanged_Z));
		}
		return cb_onMultiWindowModeChanged_Z;
	}

	private static void n_OnMultiWindowModeChanged_Z(IntPtr jnienv, IntPtr native__this, bool isInMultiWindowMode)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnMultiWindowModeChanged(isInMultiWindowMode);
	}

	[Register("onMultiWindowModeChanged", "(Z)V", "GetOnMultiWindowModeChanged_ZHandler")]
	public unsafe virtual void OnMultiWindowModeChanged(bool isInMultiWindowMode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isInMultiWindowMode);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onMultiWindowModeChanged.(Z)V", this, ptr);
	}

	private static Delegate GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler()
	{
		if ((object)cb_onOptionsItemSelected_Landroid_view_MenuItem_ == null)
		{
			cb_onOptionsItemSelected_Landroid_view_MenuItem_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnOptionsItemSelected_Landroid_view_MenuItem_));
		}
		return cb_onOptionsItemSelected_Landroid_view_MenuItem_;
	}

	private static bool n_OnOptionsItemSelected_Landroid_view_MenuItem_(IntPtr jnienv, IntPtr native__this, IntPtr native_item)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
		return fragment.OnOptionsItemSelected(item);
	}

	[Register("onOptionsItemSelected", "(Landroid/view/MenuItem;)Z", "GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler")]
	public unsafe virtual bool OnOptionsItemSelected(IMenuItem item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onOptionsItemSelected.(Landroid/view/MenuItem;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetOnOptionsMenuClosed_Landroid_view_Menu_Handler()
	{
		if ((object)cb_onOptionsMenuClosed_Landroid_view_Menu_ == null)
		{
			cb_onOptionsMenuClosed_Landroid_view_Menu_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnOptionsMenuClosed_Landroid_view_Menu_));
		}
		return cb_onOptionsMenuClosed_Landroid_view_Menu_;
	}

	private static void n_OnOptionsMenuClosed_Landroid_view_Menu_(IntPtr jnienv, IntPtr native__this, IntPtr native_menu)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
		fragment.OnOptionsMenuClosed(menu);
	}

	[Register("onOptionsMenuClosed", "(Landroid/view/Menu;)V", "GetOnOptionsMenuClosed_Landroid_view_Menu_Handler")]
	public unsafe virtual void OnOptionsMenuClosed(IMenu menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onOptionsMenuClosed.(Landroid/view/Menu;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnPauseHandler()
	{
		if ((object)cb_onPause == null)
		{
			cb_onPause = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnPause));
		}
		return cb_onPause;
	}

	private static void n_OnPause(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPause();
	}

	[Register("onPause", "()V", "GetOnPauseHandler")]
	public unsafe virtual void OnPause()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onPause.()V", this, null);
	}

	private static Delegate GetOnPictureInPictureModeChanged_ZHandler()
	{
		if ((object)cb_onPictureInPictureModeChanged_Z == null)
		{
			cb_onPictureInPictureModeChanged_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnPictureInPictureModeChanged_Z));
		}
		return cb_onPictureInPictureModeChanged_Z;
	}

	private static void n_OnPictureInPictureModeChanged_Z(IntPtr jnienv, IntPtr native__this, bool isInPictureInPictureMode)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPictureInPictureModeChanged(isInPictureInPictureMode);
	}

	[Register("onPictureInPictureModeChanged", "(Z)V", "GetOnPictureInPictureModeChanged_ZHandler")]
	public unsafe virtual void OnPictureInPictureModeChanged(bool isInPictureInPictureMode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isInPictureInPictureMode);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onPictureInPictureModeChanged.(Z)V", this, ptr);
	}

	private static Delegate GetOnPrepareOptionsMenu_Landroid_view_Menu_Handler()
	{
		if ((object)cb_onPrepareOptionsMenu_Landroid_view_Menu_ == null)
		{
			cb_onPrepareOptionsMenu_Landroid_view_Menu_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPrepareOptionsMenu_Landroid_view_Menu_));
		}
		return cb_onPrepareOptionsMenu_Landroid_view_Menu_;
	}

	private static void n_OnPrepareOptionsMenu_Landroid_view_Menu_(IntPtr jnienv, IntPtr native__this, IntPtr native_menu)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
		fragment.OnPrepareOptionsMenu(menu);
	}

	[Register("onPrepareOptionsMenu", "(Landroid/view/Menu;)V", "GetOnPrepareOptionsMenu_Landroid_view_Menu_Handler")]
	public unsafe virtual void OnPrepareOptionsMenu(IMenu menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPrepareOptionsMenu.(Landroid/view/Menu;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnPrimaryNavigationFragmentChanged_ZHandler()
	{
		if ((object)cb_onPrimaryNavigationFragmentChanged_Z == null)
		{
			cb_onPrimaryNavigationFragmentChanged_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnPrimaryNavigationFragmentChanged_Z));
		}
		return cb_onPrimaryNavigationFragmentChanged_Z;
	}

	private static void n_OnPrimaryNavigationFragmentChanged_Z(IntPtr jnienv, IntPtr native__this, bool isPrimaryNavigationFragment)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPrimaryNavigationFragmentChanged(isPrimaryNavigationFragment);
	}

	[Register("onPrimaryNavigationFragmentChanged", "(Z)V", "GetOnPrimaryNavigationFragmentChanged_ZHandler")]
	public unsafe virtual void OnPrimaryNavigationFragmentChanged(bool isPrimaryNavigationFragment)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isPrimaryNavigationFragment);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onPrimaryNavigationFragmentChanged.(Z)V", this, ptr);
	}

	private static Delegate GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler()
	{
		if ((object)cb_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI == null)
		{
			cb_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_V(n_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI));
		}
		return cb_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI;
	}

	private static void n_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI(IntPtr jnienv, IntPtr native__this, int requestCode, IntPtr native_permissions, IntPtr native_grantResults)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string[] array = (string[])JNIEnv.GetArray(native_permissions, JniHandleOwnership.DoNotTransfer, typeof(string));
		Permission[] array2 = (Permission[])JNIEnv.GetArray(native_grantResults, JniHandleOwnership.DoNotTransfer, typeof(Permission));
		fragment.OnRequestPermissionsResult(requestCode, array, array2);
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_permissions);
		}
		if (array2 != null)
		{
			JNIEnv.CopyArray(array2, native_grantResults);
		}
	}

	[Register("onRequestPermissionsResult", "(I[Ljava/lang/String;[I)V", "GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler")]
	public unsafe virtual void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
	{
		IntPtr intPtr = JNIEnv.NewArray(permissions);
		IntPtr intPtr2 = JNIEnv.NewArray(grantResults);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue(intPtr);
			ptr[2] = new JniArgumentValue(intPtr2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRequestPermissionsResult.(I[Ljava/lang/String;[I)V", this, ptr);
		}
		finally
		{
			if (permissions != null)
			{
				JNIEnv.CopyArray(intPtr, permissions);
				JNIEnv.DeleteLocalRef(intPtr);
			}
			if (grantResults != null)
			{
				JNIEnv.CopyArray(intPtr2, grantResults);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(permissions);
			GC.KeepAlive(grantResults);
		}
	}

	private static Delegate GetOnResumeHandler()
	{
		if ((object)cb_onResume == null)
		{
			cb_onResume = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnResume));
		}
		return cb_onResume;
	}

	private static void n_OnResume(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnResume();
	}

	[Register("onResume", "()V", "GetOnResumeHandler")]
	public unsafe virtual void OnResume()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onResume.()V", this, null);
	}

	private static Delegate GetOnSaveInstanceState_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onSaveInstanceState_Landroid_os_Bundle_ == null)
		{
			cb_onSaveInstanceState_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSaveInstanceState_Landroid_os_Bundle_));
		}
		return cb_onSaveInstanceState_Landroid_os_Bundle_;
	}

	private static void n_OnSaveInstanceState_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_outState)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle outState = Java.Lang.Object.GetObject<Bundle>(native_outState, JniHandleOwnership.DoNotTransfer);
		fragment.OnSaveInstanceState(outState);
	}

	[Register("onSaveInstanceState", "(Landroid/os/Bundle;)V", "GetOnSaveInstanceState_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnSaveInstanceState(Bundle outState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onSaveInstanceState.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outState);
		}
	}

	private static Delegate GetOnStartHandler()
	{
		if ((object)cb_onStart == null)
		{
			cb_onStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStart));
		}
		return cb_onStart;
	}

	private static void n_OnStart(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
	}

	[Register("onStart", "()V", "GetOnStartHandler")]
	public unsafe virtual void OnStart()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStart.()V", this, null);
	}

	private static Delegate GetOnStopHandler()
	{
		if ((object)cb_onStop == null)
		{
			cb_onStop = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStop));
		}
		return cb_onStop;
	}

	private static void n_OnStop(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
	}

	[Register("onStop", "()V", "GetOnStopHandler")]
	public unsafe virtual void OnStop()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onStop.()V", this, null);
	}

	private static Delegate GetOnViewCreated_Landroid_view_View_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onViewCreated_Landroid_view_View_Landroid_os_Bundle_ == null)
		{
			cb_onViewCreated_Landroid_view_View_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnViewCreated_Landroid_view_View_Landroid_os_Bundle_));
		}
		return cb_onViewCreated_Landroid_view_View_Landroid_os_Bundle_;
	}

	private static void n_OnViewCreated_Landroid_view_View_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_savedInstanceState)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
		fragment.OnViewCreated(view, savedInstanceState);
	}

	[Register("onViewCreated", "(Landroid/view/View;Landroid/os/Bundle;)V", "GetOnViewCreated_Landroid_view_View_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnViewCreated(View view, Bundle savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onViewCreated.(Landroid/view/View;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetOnViewStateRestored_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onViewStateRestored_Landroid_os_Bundle_ == null)
		{
			cb_onViewStateRestored_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnViewStateRestored_Landroid_os_Bundle_));
		}
		return cb_onViewStateRestored_Landroid_os_Bundle_;
	}

	private static void n_OnViewStateRestored_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_savedInstanceState)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
		fragment.OnViewStateRestored(savedInstanceState);
	}

	[Register("onViewStateRestored", "(Landroid/os/Bundle;)V", "GetOnViewStateRestored_Landroid_os_Bundle_Handler")]
	public unsafe virtual void OnViewStateRestored(Bundle savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onViewStateRestored.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	private static Delegate GetPostponeEnterTransitionHandler()
	{
		if ((object)cb_postponeEnterTransition == null)
		{
			cb_postponeEnterTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_PostponeEnterTransition));
		}
		return cb_postponeEnterTransition;
	}

	private static void n_PostponeEnterTransition(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PostponeEnterTransition();
	}

	[Register("postponeEnterTransition", "()V", "GetPostponeEnterTransitionHandler")]
	public unsafe virtual void PostponeEnterTransition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("postponeEnterTransition.()V", this, null);
	}

	[Register("postponeEnterTransition", "(JLjava/util/concurrent/TimeUnit;)V", "")]
	public unsafe void PostponeEnterTransition(long duration, TimeUnit timeUnit)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(duration);
			ptr[1] = new JniArgumentValue(timeUnit?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("postponeEnterTransition.(JLjava/util/concurrent/TimeUnit;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(timeUnit);
		}
	}

	[Register("registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public unsafe ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, IActivityResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("registerForActivityResult.(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(contract);
			GC.KeepAlive(callback);
		}
	}

	[Register("registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultRegistry;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public unsafe ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, ActivityResultRegistry registry, IActivityResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(registry?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("registerForActivityResult.(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultRegistry;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(contract);
			GC.KeepAlive(registry);
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetRegisterForContextMenu_Landroid_view_View_Handler()
	{
		if ((object)cb_registerForContextMenu_Landroid_view_View_ == null)
		{
			cb_registerForContextMenu_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RegisterForContextMenu_Landroid_view_View_));
		}
		return cb_registerForContextMenu_Landroid_view_View_;
	}

	private static void n_RegisterForContextMenu_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		fragment.RegisterForContextMenu(view);
	}

	[Register("registerForContextMenu", "(Landroid/view/View;)V", "GetRegisterForContextMenu_Landroid_view_View_Handler")]
	public unsafe virtual void RegisterForContextMenu(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("registerForContextMenu.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("requestPermissions", "([Ljava/lang/String;I)V", "")]
	public unsafe void RequestPermissions(string[] permissions, int requestCode)
	{
		IntPtr intPtr = JNIEnv.NewArray(permissions);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("requestPermissions.([Ljava/lang/String;I)V", this, ptr);
		}
		finally
		{
			if (permissions != null)
			{
				JNIEnv.CopyArray(intPtr, permissions);
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(permissions);
		}
	}

	[Register("requireActivity", "()Landroidx/fragment/app/FragmentActivity;", "")]
	public unsafe FragmentActivity RequireActivity()
	{
		return Java.Lang.Object.GetObject<FragmentActivity>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireActivity.()Landroidx/fragment/app/FragmentActivity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireArguments", "()Landroid/os/Bundle;", "")]
	public unsafe Bundle RequireArguments()
	{
		return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireArguments.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireContext", "()Landroid/content/Context;", "")]
	public unsafe Context RequireContext()
	{
		return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "")]
	public unsafe FragmentManager RequireFragmentManager()
	{
		return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireHost", "()Ljava/lang/Object;", "")]
	public unsafe Java.Lang.Object RequireHost()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireHost.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireParentFragment", "()Landroidx/fragment/app/Fragment;", "")]
	public unsafe Fragment RequireParentFragment()
	{
		return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireParentFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireView", "()Landroid/view/View;", "")]
	public unsafe View RequireView()
	{
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler()
	{
		if ((object)cb_setEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_ == null)
		{
			cb_setEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_));
		}
		return cb_setEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_;
	}

	private static void n_SetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native__callback)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SharedElementCallback enterSharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		fragment.SetEnterSharedElementCallback(enterSharedElementCallback);
	}

	[Register("setEnterSharedElementCallback", "(Landroidx/core/app/SharedElementCallback;)V", "GetSetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler")]
	public unsafe virtual void SetEnterSharedElementCallback(SharedElementCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEnterSharedElementCallback.(Landroidx/core/app/SharedElementCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler()
	{
		if ((object)cb_setExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_ == null)
		{
			cb_setExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_));
		}
		return cb_setExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_;
	}

	private static void n_SetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native__callback)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SharedElementCallback exitSharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		fragment.SetExitSharedElementCallback(exitSharedElementCallback);
	}

	[Register("setExitSharedElementCallback", "(Landroidx/core/app/SharedElementCallback;)V", "GetSetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler")]
	public unsafe virtual void SetExitSharedElementCallback(SharedElementCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setExitSharedElementCallback.(Landroidx/core/app/SharedElementCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_Handler()
	{
		if ((object)cb_setInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_ == null)
		{
			cb_setInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_));
		}
		return cb_setInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_;
	}

	private static void n_SetInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SavedState initialSavedState = Java.Lang.Object.GetObject<SavedState>(native_state, JniHandleOwnership.DoNotTransfer);
		fragment.SetInitialSavedState(initialSavedState);
	}

	[Register("setInitialSavedState", "(Landroidx/fragment/app/Fragment$SavedState;)V", "GetSetInitialSavedState_Landroidx_fragment_app_Fragment_SavedState_Handler")]
	public unsafe virtual void SetInitialSavedState(SavedState state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInitialSavedState.(Landroidx/fragment/app/Fragment$SavedState;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetSetMenuVisibility_ZHandler()
	{
		if ((object)cb_setMenuVisibility_Z == null)
		{
			cb_setMenuVisibility_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetMenuVisibility_Z));
		}
		return cb_setMenuVisibility_Z;
	}

	private static void n_SetMenuVisibility_Z(IntPtr jnienv, IntPtr native__this, bool menuVisible)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMenuVisibility(menuVisible);
	}

	[Register("setMenuVisibility", "(Z)V", "GetSetMenuVisibility_ZHandler")]
	public unsafe virtual void SetMenuVisibility(bool menuVisible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(menuVisible);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setMenuVisibility.(Z)V", this, ptr);
	}

	private static Delegate GetSetTargetFragment_Landroidx_fragment_app_Fragment_IHandler()
	{
		if ((object)cb_setTargetFragment_Landroidx_fragment_app_Fragment_I == null)
		{
			cb_setTargetFragment_Landroidx_fragment_app_Fragment_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_SetTargetFragment_Landroidx_fragment_app_Fragment_I));
		}
		return cb_setTargetFragment_Landroidx_fragment_app_Fragment_I;
	}

	private static void n_SetTargetFragment_Landroidx_fragment_app_Fragment_I(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment, int requestCode)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment2 = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		fragment.SetTargetFragment(fragment2, requestCode);
	}

	[Register("setTargetFragment", "(Landroidx/fragment/app/Fragment;I)V", "GetSetTargetFragment_Landroidx_fragment_app_Fragment_IHandler")]
	public unsafe virtual void SetTargetFragment(Fragment fragment, int requestCode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTargetFragment.(Landroidx/fragment/app/Fragment;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetShouldShowRequestPermissionRationale_Ljava_lang_String_Handler()
	{
		if ((object)cb_shouldShowRequestPermissionRationale_Ljava_lang_String_ == null)
		{
			cb_shouldShowRequestPermissionRationale_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ShouldShowRequestPermissionRationale_Ljava_lang_String_));
		}
		return cb_shouldShowRequestPermissionRationale_Ljava_lang_String_;
	}

	private static bool n_ShouldShowRequestPermissionRationale_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_permission)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string permission = JNIEnv.GetString(native_permission, JniHandleOwnership.DoNotTransfer);
		return fragment.ShouldShowRequestPermissionRationale(permission);
	}

	[Register("shouldShowRequestPermissionRationale", "(Ljava/lang/String;)Z", "GetShouldShowRequestPermissionRationale_Ljava_lang_String_Handler")]
	public unsafe virtual bool ShouldShowRequestPermissionRationale(string permission)
	{
		IntPtr intPtr = JNIEnv.NewString(permission);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldShowRequestPermissionRationale.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	private static Delegate GetStartActivity_Landroid_content_Intent_Handler()
	{
		if ((object)cb_startActivity_Landroid_content_Intent_ == null)
		{
			cb_startActivity_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StartActivity_Landroid_content_Intent_));
		}
		return cb_startActivity_Landroid_content_Intent_;
	}

	private static void n_StartActivity_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_intent)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
		fragment.StartActivity(intent);
	}

	[Register("startActivity", "(Landroid/content/Intent;)V", "GetStartActivity_Landroid_content_Intent_Handler")]
	public unsafe virtual void StartActivity(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivity.(Landroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	private static Delegate GetStartActivity_Landroid_content_Intent_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_startActivity_Landroid_content_Intent_Landroid_os_Bundle_ == null)
		{
			cb_startActivity_Landroid_content_Intent_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_StartActivity_Landroid_content_Intent_Landroid_os_Bundle_));
		}
		return cb_startActivity_Landroid_content_Intent_Landroid_os_Bundle_;
	}

	private static void n_StartActivity_Landroid_content_Intent_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_intent, IntPtr native_options)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
		Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
		fragment.StartActivity(intent, options);
	}

	[Register("startActivity", "(Landroid/content/Intent;Landroid/os/Bundle;)V", "GetStartActivity_Landroid_content_Intent_Landroid_os_Bundle_Handler")]
	public unsafe virtual void StartActivity(Intent intent, Bundle options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivity.(Landroid/content/Intent;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
			GC.KeepAlive(options);
		}
	}

	private static Delegate GetStartActivityForResult_Landroid_content_Intent_IHandler()
	{
		if ((object)cb_startActivityForResult_Landroid_content_Intent_I == null)
		{
			cb_startActivityForResult_Landroid_content_Intent_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_StartActivityForResult_Landroid_content_Intent_I));
		}
		return cb_startActivityForResult_Landroid_content_Intent_I;
	}

	private static void n_StartActivityForResult_Landroid_content_Intent_I(IntPtr jnienv, IntPtr native__this, IntPtr native_intent, int requestCode)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
		fragment.StartActivityForResult(intent, requestCode);
	}

	[Register("startActivityForResult", "(Landroid/content/Intent;I)V", "GetStartActivityForResult_Landroid_content_Intent_IHandler")]
	public unsafe virtual void StartActivityForResult(Intent intent, int requestCode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivityForResult.(Landroid/content/Intent;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	private static Delegate GetStartActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_Handler()
	{
		if ((object)cb_startActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_ == null)
		{
			cb_startActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_StartActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_));
		}
		return cb_startActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_;
	}

	private static void n_StartActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_intent, int requestCode, IntPtr native_options)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
		Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
		fragment.StartActivityForResult(intent, requestCode, options);
	}

	[Register("startActivityForResult", "(Landroid/content/Intent;ILandroid/os/Bundle;)V", "GetStartActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_Handler")]
	public unsafe virtual void StartActivityForResult(Intent intent, int requestCode, Bundle options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requestCode);
			ptr[2] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivityForResult.(Landroid/content/Intent;ILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
			GC.KeepAlive(options);
		}
	}

	private static Delegate GetStartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler()
	{
		if ((object)cb_startIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_ == null)
		{
			cb_startIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLILIIIL_V(n_StartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_));
		}
		return cb_startIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_;
	}

	private static void n_StartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_intent, int requestCode, IntPtr native_fillInIntent, int flagsMask, int flagsValues, int extraFlags, IntPtr native_options)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IntentSender intent = Java.Lang.Object.GetObject<IntentSender>(native_intent, JniHandleOwnership.DoNotTransfer);
		Intent fillInIntent = Java.Lang.Object.GetObject<Intent>(native_fillInIntent, JniHandleOwnership.DoNotTransfer);
		Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
		fragment.StartIntentSenderForResult(intent, requestCode, fillInIntent, flagsMask, flagsValues, extraFlags, options);
	}

	[Register("startIntentSenderForResult", "(Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", "GetStartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler")]
	public unsafe virtual void StartIntentSenderForResult(IntentSender intent, int requestCode, Intent fillInIntent, int flagsMask, int flagsValues, int extraFlags, Bundle options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(requestCode);
			ptr[2] = new JniArgumentValue(fillInIntent?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(flagsMask);
			ptr[4] = new JniArgumentValue(flagsValues);
			ptr[5] = new JniArgumentValue(extraFlags);
			ptr[6] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startIntentSenderForResult.(Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
			GC.KeepAlive(fillInIntent);
			GC.KeepAlive(options);
		}
	}

	private static Delegate GetStartPostponedEnterTransitionHandler()
	{
		if ((object)cb_startPostponedEnterTransition == null)
		{
			cb_startPostponedEnterTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StartPostponedEnterTransition));
		}
		return cb_startPostponedEnterTransition;
	}

	private static void n_StartPostponedEnterTransition(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartPostponedEnterTransition();
	}

	[Register("startPostponedEnterTransition", "()V", "GetStartPostponedEnterTransitionHandler")]
	public unsafe virtual void StartPostponedEnterTransition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("startPostponedEnterTransition.()V", this, null);
	}

	private static Delegate GetUnregisterForContextMenu_Landroid_view_View_Handler()
	{
		if ((object)cb_unregisterForContextMenu_Landroid_view_View_ == null)
		{
			cb_unregisterForContextMenu_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterForContextMenu_Landroid_view_View_));
		}
		return cb_unregisterForContextMenu_Landroid_view_View_;
	}

	private static void n_UnregisterForContextMenu_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
	{
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		fragment.UnregisterForContextMenu(view);
	}

	[Register("unregisterForContextMenu", "(Landroid/view/View;)V", "GetUnregisterForContextMenu_Landroid_view_View_Handler")]
	public unsafe virtual void UnregisterForContextMenu(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterForContextMenu.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}
}
[Register("androidx/fragment/app/FragmentFactory", DoNotGenerateAcw = true)]
public class FragmentFactory : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentFactory", typeof(FragmentFactory));

	private static Delegate cb_instantiate_Ljava_lang_ClassLoader_Ljava_lang_String_;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected FragmentFactory(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FragmentFactory()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetInstantiate_Ljava_lang_ClassLoader_Ljava_lang_String_Handler()
	{
		if ((object)cb_instantiate_Ljava_lang_ClassLoader_Ljava_lang_String_ == null)
		{
			cb_instantiate_Ljava_lang_ClassLoader_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Instantiate_Ljava_lang_ClassLoader_Ljava_lang_String_));
		}
		return cb_instantiate_Ljava_lang_ClassLoader_Ljava_lang_String_;
	}

	private static IntPtr n_Instantiate_Ljava_lang_ClassLoader_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_classLoader, IntPtr native_className)
	{
		FragmentFactory fragmentFactory = Java.Lang.Object.GetObject<FragmentFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ClassLoader classLoader = Java.Lang.Object.GetObject<ClassLoader>(native_classLoader, JniHandleOwnership.DoNotTransfer);
		string className = JNIEnv.GetString(native_className, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentFactory.Instantiate(classLoader, className));
	}

	[Register("instantiate", "(Ljava/lang/ClassLoader;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", "GetInstantiate_Ljava_lang_ClassLoader_Ljava_lang_String_Handler")]
	public unsafe virtual Fragment Instantiate(ClassLoader classLoader, string className)
	{
		IntPtr intPtr = JNIEnv.NewString(className);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(classLoader?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("instantiate.(Ljava/lang/ClassLoader;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(classLoader);
		}
	}

	[Register("loadFragmentClass", "(Ljava/lang/ClassLoader;Ljava/lang/String;)Ljava/lang/Class;", "")]
	public unsafe static Class LoadFragmentClass(ClassLoader classLoader, string className)
	{
		IntPtr intPtr = JNIEnv.NewString(className);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(classLoader?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Class>(_members.StaticMethods.InvokeObjectMethod("loadFragmentClass.(Ljava/lang/ClassLoader;Ljava/lang/String;)Ljava/lang/Class;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(classLoader);
		}
	}
}
[Register("androidx/fragment/app/FragmentManager", DoNotGenerateAcw = true)]
public abstract class FragmentManager : Java.Lang.Object, IFragmentResultOwner, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/fragment/app/FragmentManager$BackStackEntry", "", "AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker")]
	public interface IBackStackEntry : IJavaObject, IDisposable, IJavaPeerable
	{
		ICharSequence BreadCrumbShortTitleFormatted
		{
			[Register("getBreadCrumbShortTitle", "()Ljava/lang/CharSequence;", "GetGetBreadCrumbShortTitleHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}

		int BreadCrumbShortTitleRes
		{
			[Register("getBreadCrumbShortTitleRes", "()I", "GetGetBreadCrumbShortTitleResHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}

		ICharSequence BreadCrumbTitleFormatted
		{
			[Register("getBreadCrumbTitle", "()Ljava/lang/CharSequence;", "GetGetBreadCrumbTitleHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}

		int BreadCrumbTitleRes
		{
			[Register("getBreadCrumbTitleRes", "()I", "GetGetBreadCrumbTitleResHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}

		int Id
		{
			[Register("getId", "()I", "GetGetIdHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}

		string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler:AndroidX.Fragment.App.FragmentManager/IBackStackEntryInvoker, Xamarin.AndroidX.Fragment")]
			get;
		}
	}

	[Register("androidx/fragment/app/FragmentManager$BackStackEntry", DoNotGenerateAcw = true)]
	internal class IBackStackEntryInvoker : Java.Lang.Object, IBackStackEntry, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager$BackStackEntry", typeof(IBackStackEntryInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getBreadCrumbShortTitle;

		private IntPtr id_getBreadCrumbShortTitle;

		private static Delegate cb_getBreadCrumbShortTitleRes;

		private IntPtr id_getBreadCrumbShortTitleRes;

		private static Delegate cb_getBreadCrumbTitle;

		private IntPtr id_getBreadCrumbTitle;

		private static Delegate cb_getBreadCrumbTitleRes;

		private IntPtr id_getBreadCrumbTitleRes;

		private static Delegate cb_getId;

		private IntPtr id_getId;

		private static Delegate cb_getName;

		private IntPtr id_getName;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public ICharSequence BreadCrumbShortTitleFormatted
		{
			get
			{
				if (id_getBreadCrumbShortTitle == IntPtr.Zero)
				{
					id_getBreadCrumbShortTitle = JNIEnv.GetMethodID(class_ref, "getBreadCrumbShortTitle", "()Ljava/lang/CharSequence;");
				}
				return Java.Lang.Object.GetObject<ICharSequence>(JNIEnv.CallObjectMethod(base.Handle, id_getBreadCrumbShortTitle), JniHandleOwnership.TransferLocalRef);
			}
		}

		public int BreadCrumbShortTitleRes
		{
			get
			{
				if (id_getBreadCrumbShortTitleRes == IntPtr.Zero)
				{
					id_getBreadCrumbShortTitleRes = JNIEnv.GetMethodID(class_ref, "getBreadCrumbShortTitleRes", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_getBreadCrumbShortTitleRes);
			}
		}

		public ICharSequence BreadCrumbTitleFormatted
		{
			get
			{
				if (id_getBreadCrumbTitle == IntPtr.Zero)
				{
					id_getBreadCrumbTitle = JNIEnv.GetMethodID(class_ref, "getBreadCrumbTitle", "()Ljava/lang/CharSequence;");
				}
				return Java.Lang.Object.GetObject<ICharSequence>(JNIEnv.CallObjectMethod(base.Handle, id_getBreadCrumbTitle), JniHandleOwnership.TransferLocalRef);
			}
		}

		public int BreadCrumbTitleRes
		{
			get
			{
				if (id_getBreadCrumbTitleRes == IntPtr.Zero)
				{
					id_getBreadCrumbTitleRes = JNIEnv.GetMethodID(class_ref, "getBreadCrumbTitleRes", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_getBreadCrumbTitleRes);
			}
		}

		public int Id
		{
			get
			{
				if (id_getId == IntPtr.Zero)
				{
					id_getId = JNIEnv.GetMethodID(class_ref, "getId", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_getId);
			}
		}

		public string Name
		{
			get
			{
				if (id_getName == IntPtr.Zero)
				{
					id_getName = JNIEnv.GetMethodID(class_ref, "getName", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getName), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IBackStackEntry GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBackStackEntry>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.fragment.app.FragmentManager.BackStackEntry"));
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

		public IBackStackEntryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetBreadCrumbShortTitleHandler()
		{
			if ((object)cb_getBreadCrumbShortTitle == null)
			{
				cb_getBreadCrumbShortTitle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBreadCrumbShortTitle));
			}
			return cb_getBreadCrumbShortTitle;
		}

		private static IntPtr n_GetBreadCrumbShortTitle(IntPtr jnienv, IntPtr native__this)
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BreadCrumbShortTitleFormatted);
		}

		private static Delegate GetGetBreadCrumbShortTitleResHandler()
		{
			if ((object)cb_getBreadCrumbShortTitleRes == null)
			{
				cb_getBreadCrumbShortTitleRes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBreadCrumbShortTitleRes));
			}
			return cb_getBreadCrumbShortTitleRes;
		}

		private static int n_GetBreadCrumbShortTitleRes(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BreadCrumbShortTitleRes;
		}

		private static Delegate GetGetBreadCrumbTitleHandler()
		{
			if ((object)cb_getBreadCrumbTitle == null)
			{
				cb_getBreadCrumbTitle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBreadCrumbTitle));
			}
			return cb_getBreadCrumbTitle;
		}

		private static IntPtr n_GetBreadCrumbTitle(IntPtr jnienv, IntPtr native__this)
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BreadCrumbTitleFormatted);
		}

		private static Delegate GetGetBreadCrumbTitleResHandler()
		{
			if ((object)cb_getBreadCrumbTitleRes == null)
			{
				cb_getBreadCrumbTitleRes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBreadCrumbTitleRes));
			}
			return cb_getBreadCrumbTitleRes;
		}

		private static int n_GetBreadCrumbTitleRes(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BreadCrumbTitleRes;
		}

		private static Delegate GetGetIdHandler()
		{
			if ((object)cb_getId == null)
			{
				cb_getId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetId));
			}
			return cb_getId;
		}

		private static int n_GetId(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBackStackEntry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
		}
	}

	[Register("androidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks", DoNotGenerateAcw = true)]
	public abstract class FragmentLifecycleCallbacks : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks", typeof(FragmentLifecycleCallbacks));

		private static Delegate cb_onFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_;

		private static Delegate cb_onFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_;

		private static Delegate cb_onFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_;

		private static Delegate cb_onFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;

		private static Delegate cb_onFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;

		private static Delegate cb_onFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;

		private static Delegate cb_onFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_;

		private static Delegate cb_onFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_;

		private static Delegate cb_onFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;

		private static Delegate cb_onFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_;

		private static Delegate cb_onFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;

		private static Delegate cb_onFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;

		private static Delegate cb_onFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_;

		private static Delegate cb_onFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected FragmentLifecycleCallbacks(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FragmentLifecycleCallbacks()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_ == null)
			{
				cb_onFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_));
			}
			return cb_onFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_;
		}

		private static void n_OnFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f, IntPtr native_savedInstanceState)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentActivityCreated(fm, f, savedInstanceState);
		}

		[Register("onFragmentActivityCreated", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", "GetOnFragmentActivityCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnFragmentActivityCreated(FragmentManager fm, Fragment f, Bundle savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentActivityCreated.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(savedInstanceState);
			}
		}

		private static Delegate GetOnFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_Handler()
		{
			if ((object)cb_onFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_ == null)
			{
				cb_onFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_));
			}
			return cb_onFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_;
		}

		private static void n_OnFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f, IntPtr native_context)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentAttached(fm, f, context);
		}

		[Register("onFragmentAttached", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/content/Context;)V", "GetOnFragmentAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_Handler")]
		public unsafe virtual void OnFragmentAttached(FragmentManager fm, Fragment f, Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentAttached.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetOnFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_ == null)
			{
				cb_onFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_));
			}
			return cb_onFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_;
		}

		private static void n_OnFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f, IntPtr native_savedInstanceState)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentCreated(fm, f, savedInstanceState);
		}

		[Register("onFragmentCreated", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", "GetOnFragmentCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnFragmentCreated(FragmentManager fm, Fragment f, Bundle savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentCreated.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(savedInstanceState);
			}
		}

		private static Delegate GetOnFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			if ((object)cb_onFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ == null)
			{
				cb_onFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_));
			}
			return cb_onFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;
		}

		private static void n_OnFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentDestroyed(fm, f);
		}

		[Register("onFragmentDestroyed", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentDestroyed(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentDestroyed.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			if ((object)cb_onFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ == null)
			{
				cb_onFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_));
			}
			return cb_onFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;
		}

		private static void n_OnFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentDetached(fm, f);
		}

		[Register("onFragmentDetached", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentDetached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentDetached(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentDetached.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			if ((object)cb_onFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ == null)
			{
				cb_onFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_));
			}
			return cb_onFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;
		}

		private static void n_OnFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentPaused(fm, f);
		}

		[Register("onFragmentPaused", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentPaused_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentPaused(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentPaused.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_Handler()
		{
			if ((object)cb_onFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_ == null)
			{
				cb_onFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_));
			}
			return cb_onFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_;
		}

		private static void n_OnFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f, IntPtr native_context)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentPreAttached(fm, f, context);
		}

		[Register("onFragmentPreAttached", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/content/Context;)V", "GetOnFragmentPreAttached_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_content_Context_Handler")]
		public unsafe virtual void OnFragmentPreAttached(FragmentManager fm, Fragment f, Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentPreAttached.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetOnFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_ == null)
			{
				cb_onFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_));
			}
			return cb_onFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_;
		}

		private static void n_OnFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f, IntPtr native_savedInstanceState)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentPreCreated(fm, f, savedInstanceState);
		}

		[Register("onFragmentPreCreated", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", "GetOnFragmentPreCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnFragmentPreCreated(FragmentManager fm, Fragment f, Bundle savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentPreCreated.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(savedInstanceState);
			}
		}

		private static Delegate GetOnFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			if ((object)cb_onFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ == null)
			{
				cb_onFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_));
			}
			return cb_onFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;
		}

		private static void n_OnFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentResumed(fm, f);
		}

		[Register("onFragmentResumed", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentResumed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentResumed(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentResumed.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_ == null)
			{
				cb_onFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_));
			}
			return cb_onFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_;
		}

		private static void n_OnFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f, IntPtr native_outState)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			Bundle outState = Java.Lang.Object.GetObject<Bundle>(native_outState, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentSaveInstanceState(fm, f, outState);
		}

		[Register("onFragmentSaveInstanceState", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", "GetOnFragmentSaveInstanceState_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnFragmentSaveInstanceState(FragmentManager fm, Fragment f, Bundle outState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentSaveInstanceState.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(outState);
			}
		}

		private static Delegate GetOnFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			if ((object)cb_onFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ == null)
			{
				cb_onFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_));
			}
			return cb_onFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;
		}

		private static void n_OnFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentStarted(fm, f);
		}

		[Register("onFragmentStarted", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentStarted_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentStarted(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentStarted.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			if ((object)cb_onFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ == null)
			{
				cb_onFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_));
			}
			return cb_onFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;
		}

		private static void n_OnFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentStopped(fm, f);
		}

		[Register("onFragmentStopped", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentStopped_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentStopped(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentStopped.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}

		private static Delegate GetOnFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_ == null)
			{
				cb_onFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_OnFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_));
			}
			return cb_onFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_;
		}

		private static void n_OnFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f, IntPtr native_v, IntPtr native_savedInstanceState)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentViewCreated(fm, f, v, savedInstanceState);
		}

		[Register("onFragmentViewCreated", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/view/View;Landroid/os/Bundle;)V", "GetOnFragmentViewCreated_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Landroid_view_View_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnFragmentViewCreated(FragmentManager fm, Fragment f, View v, Bundle savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentViewCreated.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;Landroid/view/View;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
				GC.KeepAlive(v);
				GC.KeepAlive(savedInstanceState);
			}
		}

		private static Delegate GetOnFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
		{
			if ((object)cb_onFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ == null)
			{
				cb_onFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_));
			}
			return cb_onFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;
		}

		private static void n_OnFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fm, IntPtr native_f)
		{
			FragmentLifecycleCallbacks fragmentLifecycleCallbacks = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager fm = Java.Lang.Object.GetObject<FragmentManager>(native_fm, JniHandleOwnership.DoNotTransfer);
			Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
			fragmentLifecycleCallbacks.OnFragmentViewDestroyed(fm, f);
		}

		[Register("onFragmentViewDestroyed", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnFragmentViewDestroyed_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler")]
		public unsafe virtual void OnFragmentViewDestroyed(FragmentManager fm, Fragment f)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFragmentViewDestroyed.(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fm);
				GC.KeepAlive(f);
			}
		}
	}

	[Register("androidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks", DoNotGenerateAcw = true)]
	internal class FragmentLifecycleCallbacksInvoker : FragmentLifecycleCallbacks
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks", typeof(FragmentLifecycleCallbacksInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public FragmentLifecycleCallbacksInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/fragment/app/FragmentManager$OnBackStackChangedListener", "", "AndroidX.Fragment.App.FragmentManager/IOnBackStackChangedListenerInvoker")]
	public interface IOnBackStackChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onBackStackChanged", "()V", "GetOnBackStackChangedHandler:AndroidX.Fragment.App.FragmentManager/IOnBackStackChangedListenerInvoker, Xamarin.AndroidX.Fragment")]
		void OnBackStackChanged();
	}

	[Register("androidx/fragment/app/FragmentManager$OnBackStackChangedListener", DoNotGenerateAcw = true)]
	internal class IOnBackStackChangedListenerInvoker : Java.Lang.Object, IOnBackStackChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager$OnBackStackChangedListener", typeof(IOnBackStackChangedListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onBackStackChanged;

		private IntPtr id_onBackStackChanged;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOnBackStackChangedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnBackStackChangedListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.fragment.app.FragmentManager.OnBackStackChangedListener"));
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

		public IOnBackStackChangedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnBackStackChangedHandler()
		{
			if ((object)cb_onBackStackChanged == null)
			{
				cb_onBackStackChanged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnBackStackChanged));
			}
			return cb_onBackStackChanged;
		}

		private static void n_OnBackStackChanged(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IOnBackStackChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBackStackChanged();
		}

		public void OnBackStackChanged()
		{
			if (id_onBackStackChanged == IntPtr.Zero)
			{
				id_onBackStackChanged = JNIEnv.GetMethodID(class_ref, "onBackStackChanged", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onBackStackChanged);
		}
	}

	[Register("mono/androidx/fragment/app/FragmentManager_OnBackStackChangedListenerImplementor")]
	internal sealed class IOnBackStackChangedListenerImplementor : Java.Lang.Object, IOnBackStackChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler Handler;

		public IOnBackStackChangedListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/androidx/fragment/app/FragmentManager_OnBackStackChangedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnBackStackChanged()
		{
			Handler?.Invoke(sender, new EventArgs());
		}

		internal static bool __IsEmpty(IOnBackStackChangedListenerImplementor value)
		{
			return value.Handler == null;
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager", typeof(FragmentManager));

	private static Delegate cb_getBackStackEntryCount;

	private static Delegate cb_getFragmentFactory;

	private static Delegate cb_setFragmentFactory_Landroidx_fragment_app_FragmentFactory_;

	private static Delegate cb_getFragments;

	private static Delegate cb_isDestroyed;

	private static Delegate cb_isStateSaved;

	private static Delegate cb_getPrimaryNavigationFragment;

	private static Delegate cb_addFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_;

	private static Delegate cb_addOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_;

	private static Delegate cb_beginTransaction;

	private static Delegate cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;

	private static Delegate cb_executePendingTransactions;

	private static Delegate cb_findFragmentById_I;

	private static Delegate cb_findFragmentByTag_Ljava_lang_String_;

	private static Delegate cb_getBackStackEntryAt_I;

	private static Delegate cb_getFragment_Landroid_os_Bundle_Ljava_lang_String_;

	private static Delegate cb_openTransaction;

	private static Delegate cb_popBackStack;

	private static Delegate cb_popBackStack_II;

	private static Delegate cb_popBackStack_Ljava_lang_String_I;

	private static Delegate cb_popBackStackImmediate;

	private static Delegate cb_popBackStackImmediate_II;

	private static Delegate cb_popBackStackImmediate_Ljava_lang_String_I;

	private static Delegate cb_putFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_;

	private static Delegate cb_registerFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Z;

	private static Delegate cb_removeFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_;

	private static Delegate cb_removeOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_;

	private static Delegate cb_saveFragmentInstanceState_Landroidx_fragment_app_Fragment_;

	private static Delegate cb_unregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_;

	private WeakReference weak_implementor_AddFragmentOnAttachListener;

	private WeakReference weak_implementor_AddOnBackStackChangedListener;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int BackStackEntryCount
	{
		[Register("getBackStackEntryCount", "()I", "GetGetBackStackEntryCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBackStackEntryCount.()I", this, null);
		}
	}

	public unsafe virtual FragmentFactory FragmentFactory
	{
		[Register("getFragmentFactory", "()Landroidx/fragment/app/FragmentFactory;", "GetGetFragmentFactoryHandler")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFragmentFactory.()Landroidx/fragment/app/FragmentFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setFragmentFactory", "(Landroidx/fragment/app/FragmentFactory;)V", "GetSetFragmentFactory_Landroidx_fragment_app_FragmentFactory_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setFragmentFactory.(Landroidx/fragment/app/FragmentFactory;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual IList<Fragment> Fragments
	{
		[Register("getFragments", "()Ljava/util/List;", "GetGetFragmentsHandler")]
		get
		{
			return JavaList<Fragment>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getFragments.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsDestroyed
	{
		[Register("isDestroyed", "()Z", "GetIsDestroyedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDestroyed.()Z", this, null);
		}
	}

	public unsafe virtual bool IsStateSaved
	{
		[Register("isStateSaved", "()Z", "GetIsStateSavedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isStateSaved.()Z", this, null);
		}
	}

	public unsafe virtual Fragment PrimaryNavigationFragment
	{
		[Register("getPrimaryNavigationFragment", "()Landroidx/fragment/app/Fragment;", "GetGetPrimaryNavigationFragmentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrimaryNavigationFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public event EventHandler<FragmentOnAttachEventArgs> FragmentOnAttach
	{
		add
		{
			EventHelper.AddEventHandler<IFragmentOnAttachListener, IFragmentOnAttachListenerImplementor>(ref weak_implementor_AddFragmentOnAttachListener, __CreateIFragmentOnAttachListenerImplementor, AddFragmentOnAttachListener, delegate(IFragmentOnAttachListenerImplementor __h)
			{
				__h.Handler = (EventHandler<FragmentOnAttachEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddFragmentOnAttachListener, IFragmentOnAttachListenerImplementor.__IsEmpty, delegate(IFragmentOnAttachListener __v)
			{
				RemoveFragmentOnAttachListener(__v);
			}, delegate(IFragmentOnAttachListenerImplementor __h)
			{
				__h.Handler = (EventHandler<FragmentOnAttachEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler BackStackChanged
	{
		add
		{
			EventHelper.AddEventHandler<IOnBackStackChangedListener, IOnBackStackChangedListenerImplementor>(ref weak_implementor_AddOnBackStackChangedListener, __CreateIOnBackStackChangedListenerImplementor, AddOnBackStackChangedListener, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnBackStackChangedListener, IOnBackStackChangedListenerImplementor.__IsEmpty, delegate(IOnBackStackChangedListener __v)
			{
				RemoveOnBackStackChangedListener(__v);
			}, delegate(IOnBackStackChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected FragmentManager(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FragmentManager()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetBackStackEntryCountHandler()
	{
		if ((object)cb_getBackStackEntryCount == null)
		{
			cb_getBackStackEntryCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBackStackEntryCount));
		}
		return cb_getBackStackEntryCount;
	}

	private static int n_GetBackStackEntryCount(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BackStackEntryCount;
	}

	private static Delegate GetGetFragmentFactoryHandler()
	{
		if ((object)cb_getFragmentFactory == null)
		{
			cb_getFragmentFactory = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFragmentFactory));
		}
		return cb_getFragmentFactory;
	}

	private static IntPtr n_GetFragmentFactory(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FragmentFactory);
	}

	private static Delegate GetSetFragmentFactory_Landroidx_fragment_app_FragmentFactory_Handler()
	{
		if ((object)cb_setFragmentFactory_Landroidx_fragment_app_FragmentFactory_ == null)
		{
			cb_setFragmentFactory_Landroidx_fragment_app_FragmentFactory_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetFragmentFactory_Landroidx_fragment_app_FragmentFactory_));
		}
		return cb_setFragmentFactory_Landroidx_fragment_app_FragmentFactory_;
	}

	private static void n_SetFragmentFactory_Landroidx_fragment_app_FragmentFactory_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragmentFactory)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FragmentFactory fragmentFactory = Java.Lang.Object.GetObject<FragmentFactory>(native_fragmentFactory, JniHandleOwnership.DoNotTransfer);
		fragmentManager.FragmentFactory = fragmentFactory;
	}

	private static Delegate GetGetFragmentsHandler()
	{
		if ((object)cb_getFragments == null)
		{
			cb_getFragments = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFragments));
		}
		return cb_getFragments;
	}

	private static IntPtr n_GetFragments(IntPtr jnienv, IntPtr native__this)
	{
		return JavaList<Fragment>.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Fragments);
	}

	private static Delegate GetIsDestroyedHandler()
	{
		if ((object)cb_isDestroyed == null)
		{
			cb_isDestroyed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDestroyed));
		}
		return cb_isDestroyed;
	}

	private static bool n_IsDestroyed(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDestroyed;
	}

	private static Delegate GetIsStateSavedHandler()
	{
		if ((object)cb_isStateSaved == null)
		{
			cb_isStateSaved = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsStateSaved));
		}
		return cb_isStateSaved;
	}

	private static bool n_IsStateSaved(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsStateSaved;
	}

	private static Delegate GetGetPrimaryNavigationFragmentHandler()
	{
		if ((object)cb_getPrimaryNavigationFragment == null)
		{
			cb_getPrimaryNavigationFragment = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPrimaryNavigationFragment));
		}
		return cb_getPrimaryNavigationFragment;
	}

	private static IntPtr n_GetPrimaryNavigationFragment(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PrimaryNavigationFragment);
	}

	private static Delegate GetAddFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_Handler()
	{
		if ((object)cb_addFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_ == null)
		{
			cb_addFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_));
		}
		return cb_addFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_;
	}

	private static void n_AddFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IFragmentOnAttachListener listener = Java.Lang.Object.GetObject<IFragmentOnAttachListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		fragmentManager.AddFragmentOnAttachListener(listener);
	}

	[Register("addFragmentOnAttachListener", "(Landroidx/fragment/app/FragmentOnAttachListener;)V", "GetAddFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_Handler")]
	public unsafe virtual void AddFragmentOnAttachListener(IFragmentOnAttachListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFragmentOnAttachListener.(Landroidx/fragment/app/FragmentOnAttachListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_Handler()
	{
		if ((object)cb_addOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_ == null)
		{
			cb_addOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_));
		}
		return cb_addOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_;
	}

	private static void n_AddOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnBackStackChangedListener listener = Java.Lang.Object.GetObject<IOnBackStackChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		fragmentManager.AddOnBackStackChangedListener(listener);
	}

	[Register("addOnBackStackChangedListener", "(Landroidx/fragment/app/FragmentManager$OnBackStackChangedListener;)V", "GetAddOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_Handler")]
	public unsafe virtual void AddOnBackStackChangedListener(IOnBackStackChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnBackStackChangedListener.(Landroidx/fragment/app/FragmentManager$OnBackStackChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetBeginTransactionHandler()
	{
		if ((object)cb_beginTransaction == null)
		{
			cb_beginTransaction = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_BeginTransaction));
		}
		return cb_beginTransaction;
	}

	private static IntPtr n_BeginTransaction(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BeginTransaction());
	}

	[Register("beginTransaction", "()Landroidx/fragment/app/FragmentTransaction;", "GetBeginTransactionHandler")]
	public unsafe virtual FragmentTransaction BeginTransaction()
	{
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("beginTransaction.()Landroidx/fragment/app/FragmentTransaction;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("clearFragmentResult", "(Ljava/lang/String;)V", "")]
	public unsafe void ClearFragmentResult(string requestKey)
	{
		IntPtr intPtr = JNIEnv.NewString(requestKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("clearFragmentResult.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	[Register("clearFragmentResultListener", "(Ljava/lang/String;)V", "")]
	public unsafe void ClearFragmentResultListener(string requestKey)
	{
		IntPtr intPtr = JNIEnv.NewString(requestKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("clearFragmentResultListener.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	private static Delegate GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
	{
		if ((object)cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ == null)
		{
			cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_));
		}
		return cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;
	}

	private static void n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_prefix, IntPtr native_fd, IntPtr native_writer, IntPtr native_args)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
		FileDescriptor fd = Java.Lang.Object.GetObject<FileDescriptor>(native_fd, JniHandleOwnership.DoNotTransfer);
		PrintWriter writer = Java.Lang.Object.GetObject<PrintWriter>(native_writer, JniHandleOwnership.DoNotTransfer);
		string[] array = (string[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(string));
		fragmentManager.Dump(prefix, fd, writer, array);
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_args);
		}
	}

	[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
	public unsafe virtual void Dump(string prefix, FileDescriptor fd, PrintWriter writer, string[] args)
	{
		IntPtr intPtr = JNIEnv.NewString(prefix);
		IntPtr intPtr2 = JNIEnv.NewArray(args);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(fd?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(writer?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(intPtr2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dump.(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			if (args != null)
			{
				JNIEnv.CopyArray(intPtr2, args);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(fd);
			GC.KeepAlive(writer);
			GC.KeepAlive(args);
		}
	}

	[Register("enableDebugLogging", "(Z)V", "")]
	public unsafe static void EnableDebugLogging(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled);
		_members.StaticMethods.InvokeVoidMethod("enableDebugLogging.(Z)V", ptr);
	}

	[Register("enableNewStateManager", "(Z)V", "")]
	public unsafe static void EnableNewStateManager(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled);
		_members.StaticMethods.InvokeVoidMethod("enableNewStateManager.(Z)V", ptr);
	}

	private static Delegate GetExecutePendingTransactionsHandler()
	{
		if ((object)cb_executePendingTransactions == null)
		{
			cb_executePendingTransactions = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_ExecutePendingTransactions));
		}
		return cb_executePendingTransactions;
	}

	private static bool n_ExecutePendingTransactions(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExecutePendingTransactions();
	}

	[Register("executePendingTransactions", "()Z", "GetExecutePendingTransactionsHandler")]
	public unsafe virtual bool ExecutePendingTransactions()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("executePendingTransactions.()Z", this, null);
	}

	[Register("findFragment", "(Landroid/view/View;)Landroidx/fragment/app/Fragment;", "")]
	[JavaTypeParameters(new string[] { "F extends androidx.fragment.app.Fragment" })]
	public unsafe static Java.Lang.Object FindFragment(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("findFragment.(Landroid/view/View;)Landroidx/fragment/app/Fragment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetFindFragmentById_IHandler()
	{
		if ((object)cb_findFragmentById_I == null)
		{
			cb_findFragmentById_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_FindFragmentById_I));
		}
		return cb_findFragmentById_I;
	}

	private static IntPtr n_FindFragmentById_I(IntPtr jnienv, IntPtr native__this, int id)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFragmentById(id));
	}

	[Register("findFragmentById", "(I)Landroidx/fragment/app/Fragment;", "GetFindFragmentById_IHandler")]
	public unsafe virtual Fragment FindFragmentById(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("findFragmentById.(I)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindFragmentByTag_Ljava_lang_String_Handler()
	{
		if ((object)cb_findFragmentByTag_Ljava_lang_String_ == null)
		{
			cb_findFragmentByTag_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_FindFragmentByTag_Ljava_lang_String_));
		}
		return cb_findFragmentByTag_Ljava_lang_String_;
	}

	private static IntPtr n_FindFragmentByTag_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_tag)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentManager.FindFragmentByTag(tag));
	}

	[Register("findFragmentByTag", "(Ljava/lang/String;)Landroidx/fragment/app/Fragment;", "GetFindFragmentByTag_Ljava_lang_String_Handler")]
	public unsafe virtual Fragment FindFragmentByTag(string tag)
	{
		IntPtr intPtr = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("findFragmentByTag.(Ljava/lang/String;)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	private static Delegate GetGetBackStackEntryAt_IHandler()
	{
		if ((object)cb_getBackStackEntryAt_I == null)
		{
			cb_getBackStackEntryAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetBackStackEntryAt_I));
		}
		return cb_getBackStackEntryAt_I;
	}

	private static IntPtr n_GetBackStackEntryAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBackStackEntryAt(index));
	}

	[Register("getBackStackEntryAt", "(I)Landroidx/fragment/app/FragmentManager$BackStackEntry;", "GetGetBackStackEntryAt_IHandler")]
	public unsafe virtual IBackStackEntry GetBackStackEntryAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<IBackStackEntry>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBackStackEntryAt.(I)Landroidx/fragment/app/FragmentManager$BackStackEntry;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetFragment_Landroid_os_Bundle_Ljava_lang_String_Handler()
	{
		if ((object)cb_getFragment_Landroid_os_Bundle_Ljava_lang_String_ == null)
		{
			cb_getFragment_Landroid_os_Bundle_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_GetFragment_Landroid_os_Bundle_Ljava_lang_String_));
		}
		return cb_getFragment_Landroid_os_Bundle_Ljava_lang_String_;
	}

	private static IntPtr n_GetFragment_Landroid_os_Bundle_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_bundle, IntPtr native_key)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle bundle = Java.Lang.Object.GetObject<Bundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
		string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentManager.GetFragment(bundle, key));
	}

	[Register("getFragment", "(Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", "GetGetFragment_Landroid_os_Bundle_Ljava_lang_String_Handler")]
	public unsafe virtual Fragment GetFragment(Bundle bundle, string key)
	{
		IntPtr intPtr = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFragment.(Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(bundle);
		}
	}

	private static Delegate GetOpenTransactionHandler()
	{
		if ((object)cb_openTransaction == null)
		{
			cb_openTransaction = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_OpenTransaction));
		}
		return cb_openTransaction;
	}

	private static IntPtr n_OpenTransaction(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OpenTransaction());
	}

	[Register("openTransaction", "()Landroidx/fragment/app/FragmentTransaction;", "GetOpenTransactionHandler")]
	public unsafe virtual FragmentTransaction OpenTransaction()
	{
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("openTransaction.()Landroidx/fragment/app/FragmentTransaction;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetPopBackStackHandler()
	{
		if ((object)cb_popBackStack == null)
		{
			cb_popBackStack = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_PopBackStack));
		}
		return cb_popBackStack;
	}

	private static void n_PopBackStack(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PopBackStack();
	}

	[Register("popBackStack", "()V", "GetPopBackStackHandler")]
	public unsafe virtual void PopBackStack()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("popBackStack.()V", this, null);
	}

	private static Delegate GetPopBackStack_IIHandler()
	{
		if ((object)cb_popBackStack_II == null)
		{
			cb_popBackStack_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_PopBackStack_II));
		}
		return cb_popBackStack_II;
	}

	private static void n_PopBackStack_II(IntPtr jnienv, IntPtr native__this, int id, int flags)
	{
		Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PopBackStack(id, flags);
	}

	[Register("popBackStack", "(II)V", "GetPopBackStack_IIHandler")]
	public unsafe virtual void PopBackStack(int id, int flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(flags);
		_members.InstanceMethods.InvokeVirtualVoidMethod("popBackStack.(II)V", this, ptr);
	}

	private static Delegate GetPopBackStack_Ljava_lang_String_IHandler()
	{
		if ((object)cb_popBackStack_Ljava_lang_String_I == null)
		{
			cb_popBackStack_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_PopBackStack_Ljava_lang_String_I));
		}
		return cb_popBackStack_Ljava_lang_String_I;
	}

	private static void n_PopBackStack_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_name, int flags)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
		fragmentManager.PopBackStack(name, flags);
	}

	[Register("popBackStack", "(Ljava/lang/String;I)V", "GetPopBackStack_Ljava_lang_String_IHandler")]
	public unsafe virtual void PopBackStack(string name, int flags)
	{
		IntPtr intPtr = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("popBackStack.(Ljava/lang/String;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	private static Delegate GetPopBackStackImmediateHandler()
	{
		if ((object)cb_popBackStackImmediate == null)
		{
			cb_popBackStackImmediate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_PopBackStackImmediate));
		}
		return cb_popBackStackImmediate;
	}

	private static bool n_PopBackStackImmediate(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PopBackStackImmediate();
	}

	[Register("popBackStackImmediate", "()Z", "GetPopBackStackImmediateHandler")]
	public unsafe virtual bool PopBackStackImmediate()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("popBackStackImmediate.()Z", this, null);
	}

	private static Delegate GetPopBackStackImmediate_IIHandler()
	{
		if ((object)cb_popBackStackImmediate_II == null)
		{
			cb_popBackStackImmediate_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_Z(n_PopBackStackImmediate_II));
		}
		return cb_popBackStackImmediate_II;
	}

	private static bool n_PopBackStackImmediate_II(IntPtr jnienv, IntPtr native__this, int id, int flags)
	{
		return Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PopBackStackImmediate(id, flags);
	}

	[Register("popBackStackImmediate", "(II)Z", "GetPopBackStackImmediate_IIHandler")]
	public unsafe virtual bool PopBackStackImmediate(int id, int flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(flags);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("popBackStackImmediate.(II)Z", this, ptr);
	}

	private static Delegate GetPopBackStackImmediate_Ljava_lang_String_IHandler()
	{
		if ((object)cb_popBackStackImmediate_Ljava_lang_String_I == null)
		{
			cb_popBackStackImmediate_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_Z(n_PopBackStackImmediate_Ljava_lang_String_I));
		}
		return cb_popBackStackImmediate_Ljava_lang_String_I;
	}

	private static bool n_PopBackStackImmediate_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_name, int flags)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
		return fragmentManager.PopBackStackImmediate(name, flags);
	}

	[Register("popBackStackImmediate", "(Ljava/lang/String;I)Z", "GetPopBackStackImmediate_Ljava_lang_String_IHandler")]
	public unsafe virtual bool PopBackStackImmediate(string name, int flags)
	{
		IntPtr intPtr = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(flags);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("popBackStackImmediate.(Ljava/lang/String;I)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	private static Delegate GetPutFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_putFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_putFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_PutFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_));
		}
		return cb_putFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_;
	}

	private static void n_PutFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_bundle, IntPtr native_key, IntPtr native_fragment)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle bundle = Java.Lang.Object.GetObject<Bundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
		string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		fragmentManager.PutFragment(bundle, key, fragment);
	}

	[Register("putFragment", "(Landroid/os/Bundle;Ljava/lang/String;Landroidx/fragment/app/Fragment;)V", "GetPutFragment_Landroid_os_Bundle_Ljava_lang_String_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual void PutFragment(Bundle bundle, string key, Fragment fragment)
	{
		IntPtr intPtr = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			ptr[2] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("putFragment.(Landroid/os/Bundle;Ljava/lang/String;Landroidx/fragment/app/Fragment;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(bundle);
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetRegisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_ZHandler()
	{
		if ((object)cb_registerFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Z == null)
		{
			cb_registerFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_RegisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Z));
		}
		return cb_registerFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Z;
	}

	private static void n_RegisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_cb, bool recursive)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FragmentLifecycleCallbacks cb = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(native_cb, JniHandleOwnership.DoNotTransfer);
		fragmentManager.RegisterFragmentLifecycleCallbacks(cb, recursive);
	}

	[Register("registerFragmentLifecycleCallbacks", "(Landroidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks;Z)V", "GetRegisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_ZHandler")]
	public unsafe virtual void RegisterFragmentLifecycleCallbacks(FragmentLifecycleCallbacks cb, bool recursive)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(cb?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(recursive);
			_members.InstanceMethods.InvokeVirtualVoidMethod("registerFragmentLifecycleCallbacks.(Landroidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cb);
		}
	}

	private static Delegate GetRemoveFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_Handler()
	{
		if ((object)cb_removeFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_ == null)
		{
			cb_removeFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_));
		}
		return cb_removeFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_;
	}

	private static void n_RemoveFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IFragmentOnAttachListener listener = Java.Lang.Object.GetObject<IFragmentOnAttachListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		fragmentManager.RemoveFragmentOnAttachListener(listener);
	}

	[Register("removeFragmentOnAttachListener", "(Landroidx/fragment/app/FragmentOnAttachListener;)V", "GetRemoveFragmentOnAttachListener_Landroidx_fragment_app_FragmentOnAttachListener_Handler")]
	public unsafe virtual void RemoveFragmentOnAttachListener(IFragmentOnAttachListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeFragmentOnAttachListener.(Landroidx/fragment/app/FragmentOnAttachListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_Handler()
	{
		if ((object)cb_removeOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_ == null)
		{
			cb_removeOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_));
		}
		return cb_removeOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_;
	}

	private static void n_RemoveOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnBackStackChangedListener listener = Java.Lang.Object.GetObject<IOnBackStackChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		fragmentManager.RemoveOnBackStackChangedListener(listener);
	}

	[Register("removeOnBackStackChangedListener", "(Landroidx/fragment/app/FragmentManager$OnBackStackChangedListener;)V", "GetRemoveOnBackStackChangedListener_Landroidx_fragment_app_FragmentManager_OnBackStackChangedListener_Handler")]
	public unsafe virtual void RemoveOnBackStackChangedListener(IOnBackStackChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnBackStackChangedListener.(Landroidx/fragment/app/FragmentManager$OnBackStackChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSaveFragmentInstanceState_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_saveFragmentInstanceState_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_saveFragmentInstanceState_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SaveFragmentInstanceState_Landroidx_fragment_app_Fragment_));
		}
		return cb_saveFragmentInstanceState_Landroidx_fragment_app_Fragment_;
	}

	private static IntPtr n_SaveFragmentInstanceState_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_f)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment f = Java.Lang.Object.GetObject<Fragment>(native_f, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentManager.SaveFragmentInstanceState(f));
	}

	[Register("saveFragmentInstanceState", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/Fragment$SavedState;", "GetSaveFragmentInstanceState_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual Fragment.SavedState SaveFragmentInstanceState(Fragment f)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Fragment.SavedState>(_members.InstanceMethods.InvokeVirtualObjectMethod("saveFragmentInstanceState.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/Fragment$SavedState;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(f);
		}
	}

	[Register("setFragmentResult", "(Ljava/lang/String;Landroid/os/Bundle;)V", "")]
	public unsafe void SetFragmentResult(string requestKey, Bundle result)
	{
		IntPtr intPtr = JNIEnv.NewString(requestKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setFragmentResult.(Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(result);
		}
	}

	[Register("setFragmentResultListener", "(Ljava/lang/String;Landroidx/lifecycle/LifecycleOwner;Landroidx/fragment/app/FragmentResultListener;)V", "")]
	public unsafe void SetFragmentResultListener(string requestKey, ILifecycleOwner lifecycleOwner, IFragmentResultListener listener)
	{
		IntPtr intPtr = JNIEnv.NewString(requestKey);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue((lifecycleOwner == null) ? IntPtr.Zero : ((Java.Lang.Object)lifecycleOwner).Handle);
			ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setFragmentResultListener.(Ljava/lang/String;Landroidx/lifecycle/LifecycleOwner;Landroidx/fragment/app/FragmentResultListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(lifecycleOwner);
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetUnregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Handler()
	{
		if ((object)cb_unregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_ == null)
		{
			cb_unregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_));
		}
		return cb_unregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_;
	}

	private static void n_UnregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_(IntPtr jnienv, IntPtr native__this, IntPtr native_cb)
	{
		FragmentManager fragmentManager = Java.Lang.Object.GetObject<FragmentManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FragmentLifecycleCallbacks cb = Java.Lang.Object.GetObject<FragmentLifecycleCallbacks>(native_cb, JniHandleOwnership.DoNotTransfer);
		fragmentManager.UnregisterFragmentLifecycleCallbacks(cb);
	}

	[Register("unregisterFragmentLifecycleCallbacks", "(Landroidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks;)V", "GetUnregisterFragmentLifecycleCallbacks_Landroidx_fragment_app_FragmentManager_FragmentLifecycleCallbacks_Handler")]
	public unsafe virtual void UnregisterFragmentLifecycleCallbacks(FragmentLifecycleCallbacks cb)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cb?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterFragmentLifecycleCallbacks.(Landroidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cb);
		}
	}

	private IFragmentOnAttachListenerImplementor __CreateIFragmentOnAttachListenerImplementor()
	{
		return new IFragmentOnAttachListenerImplementor(this);
	}

	private IOnBackStackChangedListenerImplementor __CreateIOnBackStackChangedListenerImplementor()
	{
		return new IOnBackStackChangedListenerImplementor(this);
	}
}
[Register("androidx/fragment/app/FragmentManager", DoNotGenerateAcw = true)]
internal class FragmentManagerInvoker : FragmentManager
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager", typeof(FragmentManagerInvoker));

	public override JniPeerMembers JniPeerMembers => _members;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public FragmentManagerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
[Register("androidx/fragment/app/FragmentPagerAdapter", DoNotGenerateAcw = true)]
public abstract class FragmentPagerAdapter : PagerAdapter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentPagerAdapter", typeof(FragmentPagerAdapter));

	private static Delegate cb_getItem_I;

	private static Delegate cb_getItemId_I;

	private static Delegate cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected FragmentPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/fragment/app/FragmentManager;)V", "")]
	public unsafe FragmentPagerAdapter(FragmentManager fm)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/FragmentManager;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/FragmentManager;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fm);
		}
	}

	[Register(".ctor", "(Landroidx/fragment/app/FragmentManager;I)V", "")]
	public unsafe FragmentPagerAdapter(FragmentManager fm, int behavior)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(behavior);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/FragmentManager;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/FragmentManager;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fm);
		}
	}

	private static Delegate GetGetItem_IHandler()
	{
		if ((object)cb_getItem_I == null)
		{
			cb_getItem_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetItem_I));
		}
		return cb_getItem_I;
	}

	private static IntPtr n_GetItem_I(IntPtr jnienv, IntPtr native__this, int position)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentPagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItem(position));
	}

	[Register("getItem", "(I)Landroidx/fragment/app/Fragment;", "GetGetItem_IHandler")]
	public abstract Fragment GetItem(int position);

	private static Delegate GetGetItemId_IHandler()
	{
		if ((object)cb_getItemId_I == null)
		{
			cb_getItemId_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_J(n_GetItemId_I));
		}
		return cb_getItemId_I;
	}

	private static long n_GetItemId_I(IntPtr jnienv, IntPtr native__this, int position)
	{
		return Java.Lang.Object.GetObject<FragmentPagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemId(position);
	}

	[Register("getItemId", "(I)J", "GetGetItemId_IHandler")]
	public unsafe virtual long GetItemId(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members.InstanceMethods.InvokeVirtualInt64Method("getItemId.(I)J", this, ptr);
	}

	private static Delegate GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler()
	{
		if ((object)cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_ == null)
		{
			cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_IsViewFromObject_Landroid_view_View_Ljava_lang_Object_));
		}
		return cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_;
	}

	private static bool n_IsViewFromObject_Landroid_view_View_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native__object)
	{
		FragmentPagerAdapter fragmentPagerAdapter = Java.Lang.Object.GetObject<FragmentPagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
		return fragmentPagerAdapter.IsViewFromObject(view, obj);
	}

	[Register("isViewFromObject", "(Landroid/view/View;Ljava/lang/Object;)Z", "GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler")]
	public unsafe override bool IsViewFromObject(View view, Java.Lang.Object @object)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isViewFromObject.(Landroid/view/View;Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(@object);
		}
	}
}
[Register("androidx/fragment/app/FragmentPagerAdapter", DoNotGenerateAcw = true)]
internal class FragmentPagerAdapterInvoker : FragmentPagerAdapter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentPagerAdapter", typeof(FragmentPagerAdapterInvoker));

	public override JniPeerMembers JniPeerMembers => _members;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int Count
	{
		[Register("getCount", "()I", "GetGetCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getCount.()I", this, null);
		}
	}

	public FragmentPagerAdapterInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("getItem", "(I)Landroidx/fragment/app/Fragment;", "GetGetItem_IHandler")]
	public unsafe override Fragment GetItem(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeAbstractObjectMethod("getItem.(I)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
[Register("androidx/fragment/app/FragmentStatePagerAdapter", DoNotGenerateAcw = true)]
public abstract class FragmentStatePagerAdapter : PagerAdapter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentStatePagerAdapter", typeof(FragmentStatePagerAdapter));

	private static Delegate cb_getItem_I;

	private static Delegate cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected FragmentStatePagerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/fragment/app/FragmentManager;)V", "")]
	public unsafe FragmentStatePagerAdapter(FragmentManager fm)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/FragmentManager;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/FragmentManager;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fm);
		}
	}

	[Register(".ctor", "(Landroidx/fragment/app/FragmentManager;I)V", "")]
	public unsafe FragmentStatePagerAdapter(FragmentManager fm, int behavior)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fm?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(behavior);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/FragmentManager;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/FragmentManager;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fm);
		}
	}

	private static Delegate GetGetItem_IHandler()
	{
		if ((object)cb_getItem_I == null)
		{
			cb_getItem_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetItem_I));
		}
		return cb_getItem_I;
	}

	private static IntPtr n_GetItem_I(IntPtr jnienv, IntPtr native__this, int position)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentStatePagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItem(position));
	}

	[Register("getItem", "(I)Landroidx/fragment/app/Fragment;", "GetGetItem_IHandler")]
	public abstract Fragment GetItem(int position);

	private static Delegate GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler()
	{
		if ((object)cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_ == null)
		{
			cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_IsViewFromObject_Landroid_view_View_Ljava_lang_Object_));
		}
		return cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_;
	}

	private static bool n_IsViewFromObject_Landroid_view_View_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native__object)
	{
		FragmentStatePagerAdapter fragmentStatePagerAdapter = Java.Lang.Object.GetObject<FragmentStatePagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
		return fragmentStatePagerAdapter.IsViewFromObject(view, obj);
	}

	[Register("isViewFromObject", "(Landroid/view/View;Ljava/lang/Object;)Z", "GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler")]
	public unsafe override bool IsViewFromObject(View view, Java.Lang.Object @object)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isViewFromObject.(Landroid/view/View;Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(@object);
		}
	}
}
[Register("androidx/fragment/app/FragmentStatePagerAdapter", DoNotGenerateAcw = true)]
internal class FragmentStatePagerAdapterInvoker : FragmentStatePagerAdapter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentStatePagerAdapter", typeof(FragmentStatePagerAdapterInvoker));

	public override JniPeerMembers JniPeerMembers => _members;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int Count
	{
		[Register("getCount", "()I", "GetGetCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getCount.()I", this, null);
		}
	}

	public FragmentStatePagerAdapterInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("getItem", "(I)Landroidx/fragment/app/Fragment;", "GetGetItem_IHandler")]
	public unsafe override Fragment GetItem(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeAbstractObjectMethod("getItem.(I)Landroidx/fragment/app/Fragment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
[Register("androidx/fragment/app/FragmentTransaction", DoNotGenerateAcw = true)]
public abstract class FragmentTransaction : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentTransaction", typeof(FragmentTransaction));

	private static Delegate cb_isAddToBackStackAllowed;

	private static Delegate cb_isEmpty;

	private static Delegate cb_add_Landroidx_fragment_app_Fragment_Ljava_lang_String_;

	private static Delegate cb_add_ILandroidx_fragment_app_Fragment_;

	private static Delegate cb_add_ILandroidx_fragment_app_Fragment_Ljava_lang_String_;

	private static Delegate cb_addSharedElement_Landroid_view_View_Ljava_lang_String_;

	private static Delegate cb_addToBackStack_Ljava_lang_String_;

	private static Delegate cb_attach_Landroidx_fragment_app_Fragment_;

	private static Delegate cb_commit;

	private static Delegate cb_commitAllowingStateLoss;

	private static Delegate cb_commitNow;

	private static Delegate cb_commitNowAllowingStateLoss;

	private static Delegate cb_detach_Landroidx_fragment_app_Fragment_;

	private static Delegate cb_disallowAddToBackStack;

	private static Delegate cb_hide_Landroidx_fragment_app_Fragment_;

	private static Delegate cb_remove_Landroidx_fragment_app_Fragment_;

	private static Delegate cb_replace_ILandroidx_fragment_app_Fragment_;

	private static Delegate cb_replace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_;

	private static Delegate cb_runOnCommit_Ljava_lang_Runnable_;

	private static Delegate cb_setAllowOptimization_Z;

	private static Delegate cb_setBreadCrumbShortTitle_I;

	private static Delegate cb_setBreadCrumbShortTitle_Ljava_lang_CharSequence_;

	private static Delegate cb_setBreadCrumbTitle_I;

	private static Delegate cb_setBreadCrumbTitle_Ljava_lang_CharSequence_;

	private static Delegate cb_setCustomAnimations_II;

	private static Delegate cb_setCustomAnimations_IIII;

	private static Delegate cb_setMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_;

	private static Delegate cb_setPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_;

	private static Delegate cb_setReorderingAllowed_Z;

	private static Delegate cb_setTransition_I;

	private static Delegate cb_setTransitionStyle_I;

	private static Delegate cb_show_Landroidx_fragment_app_Fragment_;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual bool IsAddToBackStackAllowed
	{
		[Register("isAddToBackStackAllowed", "()Z", "GetIsAddToBackStackAllowedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAddToBackStackAllowed.()Z", this, null);
		}
	}

	public unsafe virtual bool IsEmpty
	{
		[Register("isEmpty", "()Z", "GetIsEmptyHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEmpty.()Z", this, null);
		}
	}

	protected FragmentTransaction(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FragmentTransaction()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetIsAddToBackStackAllowedHandler()
	{
		if ((object)cb_isAddToBackStackAllowed == null)
		{
			cb_isAddToBackStackAllowed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAddToBackStackAllowed));
		}
		return cb_isAddToBackStackAllowed;
	}

	private static bool n_IsAddToBackStackAllowed(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAddToBackStackAllowed;
	}

	private static Delegate GetIsEmptyHandler()
	{
		if ((object)cb_isEmpty == null)
		{
			cb_isEmpty = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsEmpty));
		}
		return cb_isEmpty;
	}

	private static bool n_IsEmpty(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty;
	}

	private static Delegate GetAdd_Landroidx_fragment_app_Fragment_Ljava_lang_String_Handler()
	{
		if ((object)cb_add_Landroidx_fragment_app_Fragment_Ljava_lang_String_ == null)
		{
			cb_add_Landroidx_fragment_app_Fragment_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Add_Landroidx_fragment_app_Fragment_Ljava_lang_String_));
		}
		return cb_add_Landroidx_fragment_app_Fragment_Ljava_lang_String_;
	}

	private static IntPtr n_Add_Landroidx_fragment_app_Fragment_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment, IntPtr native_tag)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.Add(fragment, tag));
	}

	[Register("add", "(Landroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "GetAdd_Landroidx_fragment_app_Fragment_Ljava_lang_String_Handler")]
	public unsafe virtual FragmentTransaction Add(Fragment fragment, string tag)
	{
		IntPtr intPtr = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("add.(Landroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetAdd_ILandroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_add_ILandroidx_fragment_app_Fragment_ == null)
		{
			cb_add_ILandroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_Add_ILandroidx_fragment_app_Fragment_));
		}
		return cb_add_ILandroidx_fragment_app_Fragment_;
	}

	private static IntPtr n_Add_ILandroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, int containerViewId, IntPtr native_fragment)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.Add(containerViewId, fragment));
	}

	[Register("add", "(ILandroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetAdd_ILandroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Add(int containerViewId, Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("add.(ILandroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetAdd_ILandroidx_fragment_app_Fragment_Ljava_lang_String_Handler()
	{
		if ((object)cb_add_ILandroidx_fragment_app_Fragment_Ljava_lang_String_ == null)
		{
			cb_add_ILandroidx_fragment_app_Fragment_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_L(n_Add_ILandroidx_fragment_app_Fragment_Ljava_lang_String_));
		}
		return cb_add_ILandroidx_fragment_app_Fragment_Ljava_lang_String_;
	}

	private static IntPtr n_Add_ILandroidx_fragment_app_Fragment_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, int containerViewId, IntPtr native_fragment, IntPtr native_tag)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.Add(containerViewId, fragment, tag));
	}

	[Register("add", "(ILandroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "GetAdd_ILandroidx_fragment_app_Fragment_Ljava_lang_String_Handler")]
	public unsafe virtual FragmentTransaction Add(int containerViewId, Fragment fragment, string tag)
	{
		IntPtr intPtr = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("add.(ILandroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(fragment);
		}
	}

	[Register("add", "(ILjava/lang/Class;Landroid/os/Bundle;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Add(int containerViewId, Class fragmentClass, Bundle args)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragmentClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(ILjava/lang/Class;Landroid/os/Bundle;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragmentClass);
			GC.KeepAlive(args);
		}
	}

	[Register("add", "(ILjava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Add(int containerViewId, Class fragmentClass, Bundle args, string tag)
	{
		IntPtr intPtr = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragmentClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(ILjava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(fragmentClass);
			GC.KeepAlive(args);
		}
	}

	[Register("add", "(Ljava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Add(Class fragmentClass, Bundle args, string tag)
	{
		IntPtr intPtr = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(fragmentClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(Ljava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(fragmentClass);
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetAddSharedElement_Landroid_view_View_Ljava_lang_String_Handler()
	{
		if ((object)cb_addSharedElement_Landroid_view_View_Ljava_lang_String_ == null)
		{
			cb_addSharedElement_Landroid_view_View_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddSharedElement_Landroid_view_View_Ljava_lang_String_));
		}
		return cb_addSharedElement_Landroid_view_View_Ljava_lang_String_;
	}

	private static IntPtr n_AddSharedElement_Landroid_view_View_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_sharedElement, IntPtr native_name)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View sharedElement = Java.Lang.Object.GetObject<View>(native_sharedElement, JniHandleOwnership.DoNotTransfer);
		string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.AddSharedElement(sharedElement, name));
	}

	[Register("addSharedElement", "(Landroid/view/View;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "GetAddSharedElement_Landroid_view_View_Ljava_lang_String_Handler")]
	public unsafe virtual FragmentTransaction AddSharedElement(View sharedElement, string name)
	{
		IntPtr intPtr = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(sharedElement?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("addSharedElement.(Landroid/view/View;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(sharedElement);
		}
	}

	private static Delegate GetAddToBackStack_Ljava_lang_String_Handler()
	{
		if ((object)cb_addToBackStack_Ljava_lang_String_ == null)
		{
			cb_addToBackStack_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddToBackStack_Ljava_lang_String_));
		}
		return cb_addToBackStack_Ljava_lang_String_;
	}

	private static IntPtr n_AddToBackStack_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.AddToBackStack(name));
	}

	[Register("addToBackStack", "(Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "GetAddToBackStack_Ljava_lang_String_Handler")]
	public unsafe virtual FragmentTransaction AddToBackStack(string name)
	{
		IntPtr intPtr = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("addToBackStack.(Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	private static Delegate GetAttach_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_attach_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_attach_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Attach_Landroidx_fragment_app_Fragment_));
		}
		return cb_attach_Landroidx_fragment_app_Fragment_;
	}

	private static IntPtr n_Attach_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.Attach(fragment));
	}

	[Register("attach", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetAttach_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Attach(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("attach.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetCommitHandler()
	{
		if ((object)cb_commit == null)
		{
			cb_commit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_Commit));
		}
		return cb_commit;
	}

	private static int n_Commit(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Commit();
	}

	[Register("commit", "()I", "GetCommitHandler")]
	public abstract int Commit();

	private static Delegate GetCommitAllowingStateLossHandler()
	{
		if ((object)cb_commitAllowingStateLoss == null)
		{
			cb_commitAllowingStateLoss = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_CommitAllowingStateLoss));
		}
		return cb_commitAllowingStateLoss;
	}

	private static int n_CommitAllowingStateLoss(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CommitAllowingStateLoss();
	}

	[Register("commitAllowingStateLoss", "()I", "GetCommitAllowingStateLossHandler")]
	public abstract int CommitAllowingStateLoss();

	private static Delegate GetCommitNowHandler()
	{
		if ((object)cb_commitNow == null)
		{
			cb_commitNow = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_CommitNow));
		}
		return cb_commitNow;
	}

	private static void n_CommitNow(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CommitNow();
	}

	[Register("commitNow", "()V", "GetCommitNowHandler")]
	public abstract void CommitNow();

	private static Delegate GetCommitNowAllowingStateLossHandler()
	{
		if ((object)cb_commitNowAllowingStateLoss == null)
		{
			cb_commitNowAllowingStateLoss = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_CommitNowAllowingStateLoss));
		}
		return cb_commitNowAllowingStateLoss;
	}

	private static void n_CommitNowAllowingStateLoss(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CommitNowAllowingStateLoss();
	}

	[Register("commitNowAllowingStateLoss", "()V", "GetCommitNowAllowingStateLossHandler")]
	public abstract void CommitNowAllowingStateLoss();

	private static Delegate GetDetach_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_detach_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_detach_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Detach_Landroidx_fragment_app_Fragment_));
		}
		return cb_detach_Landroidx_fragment_app_Fragment_;
	}

	private static IntPtr n_Detach_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.Detach(fragment));
	}

	[Register("detach", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetDetach_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Detach(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("detach.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetDisallowAddToBackStackHandler()
	{
		if ((object)cb_disallowAddToBackStack == null)
		{
			cb_disallowAddToBackStack = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_DisallowAddToBackStack));
		}
		return cb_disallowAddToBackStack;
	}

	private static IntPtr n_DisallowAddToBackStack(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisallowAddToBackStack());
	}

	[Register("disallowAddToBackStack", "()Landroidx/fragment/app/FragmentTransaction;", "GetDisallowAddToBackStackHandler")]
	public unsafe virtual FragmentTransaction DisallowAddToBackStack()
	{
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("disallowAddToBackStack.()Landroidx/fragment/app/FragmentTransaction;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetHide_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_hide_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_hide_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Hide_Landroidx_fragment_app_Fragment_));
		}
		return cb_hide_Landroidx_fragment_app_Fragment_;
	}

	private static IntPtr n_Hide_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.Hide(fragment));
	}

	[Register("hide", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetHide_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Hide(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("hide.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetRemove_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_remove_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_remove_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Remove_Landroidx_fragment_app_Fragment_));
		}
		return cb_remove_Landroidx_fragment_app_Fragment_;
	}

	private static IntPtr n_Remove_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.Remove(fragment));
	}

	[Register("remove", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetRemove_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Remove(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("remove.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetReplace_ILandroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_replace_ILandroidx_fragment_app_Fragment_ == null)
		{
			cb_replace_ILandroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_Replace_ILandroidx_fragment_app_Fragment_));
		}
		return cb_replace_ILandroidx_fragment_app_Fragment_;
	}

	private static IntPtr n_Replace_ILandroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, int containerViewId, IntPtr native_fragment)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.Replace(containerViewId, fragment));
	}

	[Register("replace", "(ILandroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetReplace_ILandroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Replace(int containerViewId, Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("replace.(ILandroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetReplace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_Handler()
	{
		if ((object)cb_replace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_ == null)
		{
			cb_replace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_L(n_Replace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_));
		}
		return cb_replace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_;
	}

	private static IntPtr n_Replace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, int containerViewId, IntPtr native_fragment, IntPtr native_tag)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.Replace(containerViewId, fragment, tag));
	}

	[Register("replace", "(ILandroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "GetReplace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_Handler")]
	public unsafe virtual FragmentTransaction Replace(int containerViewId, Fragment fragment, string tag)
	{
		IntPtr intPtr = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("replace.(ILandroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(fragment);
		}
	}

	[Register("replace", "(ILjava/lang/Class;Landroid/os/Bundle;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Replace(int containerViewId, Class fragmentClass, Bundle args)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragmentClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("replace.(ILjava/lang/Class;Landroid/os/Bundle;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragmentClass);
			GC.KeepAlive(args);
		}
	}

	[Register("replace", "(ILjava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Replace(int containerViewId, Class fragmentClass, Bundle args, string tag)
	{
		IntPtr intPtr = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragmentClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("replace.(ILjava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(fragmentClass);
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetRunOnCommit_Ljava_lang_Runnable_Handler()
	{
		if ((object)cb_runOnCommit_Ljava_lang_Runnable_ == null)
		{
			cb_runOnCommit_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RunOnCommit_Ljava_lang_Runnable_));
		}
		return cb_runOnCommit_Ljava_lang_Runnable_;
	}

	private static IntPtr n_RunOnCommit_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_runnable)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRunnable runnable = Java.Lang.Object.GetObject<IRunnable>(native_runnable, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.RunOnCommit(runnable));
	}

	[Register("runOnCommit", "(Ljava/lang/Runnable;)Landroidx/fragment/app/FragmentTransaction;", "GetRunOnCommit_Ljava_lang_Runnable_Handler")]
	public unsafe virtual FragmentTransaction RunOnCommit(IRunnable runnable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((runnable == null) ? IntPtr.Zero : ((Java.Lang.Object)runnable).Handle);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("runOnCommit.(Ljava/lang/Runnable;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(runnable);
		}
	}

	private static Delegate GetSetAllowOptimization_ZHandler()
	{
		if ((object)cb_setAllowOptimization_Z == null)
		{
			cb_setAllowOptimization_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetAllowOptimization_Z));
		}
		return cb_setAllowOptimization_Z;
	}

	private static IntPtr n_SetAllowOptimization_Z(IntPtr jnienv, IntPtr native__this, bool allowOptimization)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAllowOptimization(allowOptimization));
	}

	[Register("setAllowOptimization", "(Z)Landroidx/fragment/app/FragmentTransaction;", "GetSetAllowOptimization_ZHandler")]
	public unsafe virtual FragmentTransaction SetAllowOptimization(bool allowOptimization)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(allowOptimization);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAllowOptimization.(Z)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetBreadCrumbShortTitle_IHandler()
	{
		if ((object)cb_setBreadCrumbShortTitle_I == null)
		{
			cb_setBreadCrumbShortTitle_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetBreadCrumbShortTitle_I));
		}
		return cb_setBreadCrumbShortTitle_I;
	}

	private static IntPtr n_SetBreadCrumbShortTitle_I(IntPtr jnienv, IntPtr native__this, int res)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBreadCrumbShortTitle(res));
	}

	[Register("setBreadCrumbShortTitle", "(I)Landroidx/fragment/app/FragmentTransaction;", "GetSetBreadCrumbShortTitle_IHandler")]
	public unsafe virtual FragmentTransaction SetBreadCrumbShortTitle(int res)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(res);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBreadCrumbShortTitle.(I)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetBreadCrumbShortTitle_Ljava_lang_CharSequence_Handler()
	{
		if ((object)cb_setBreadCrumbShortTitle_Ljava_lang_CharSequence_ == null)
		{
			cb_setBreadCrumbShortTitle_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetBreadCrumbShortTitle_Ljava_lang_CharSequence_));
		}
		return cb_setBreadCrumbShortTitle_Ljava_lang_CharSequence_;
	}

	private static IntPtr n_SetBreadCrumbShortTitle_Ljava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, IntPtr native_text)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICharSequence breadCrumbShortTitle = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.SetBreadCrumbShortTitle(breadCrumbShortTitle));
	}

	[Register("setBreadCrumbShortTitle", "(Ljava/lang/CharSequence;)Landroidx/fragment/app/FragmentTransaction;", "GetSetBreadCrumbShortTitle_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual FragmentTransaction SetBreadCrumbShortTitle(ICharSequence text)
	{
		IntPtr intPtr = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBreadCrumbShortTitle.(Ljava/lang/CharSequence;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(text);
		}
	}

	public FragmentTransaction SetBreadCrumbShortTitle(string text)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		FragmentTransaction result = SetBreadCrumbShortTitle(obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetSetBreadCrumbTitle_IHandler()
	{
		if ((object)cb_setBreadCrumbTitle_I == null)
		{
			cb_setBreadCrumbTitle_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetBreadCrumbTitle_I));
		}
		return cb_setBreadCrumbTitle_I;
	}

	private static IntPtr n_SetBreadCrumbTitle_I(IntPtr jnienv, IntPtr native__this, int res)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBreadCrumbTitle(res));
	}

	[Register("setBreadCrumbTitle", "(I)Landroidx/fragment/app/FragmentTransaction;", "GetSetBreadCrumbTitle_IHandler")]
	public unsafe virtual FragmentTransaction SetBreadCrumbTitle(int res)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(res);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBreadCrumbTitle.(I)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetBreadCrumbTitle_Ljava_lang_CharSequence_Handler()
	{
		if ((object)cb_setBreadCrumbTitle_Ljava_lang_CharSequence_ == null)
		{
			cb_setBreadCrumbTitle_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetBreadCrumbTitle_Ljava_lang_CharSequence_));
		}
		return cb_setBreadCrumbTitle_Ljava_lang_CharSequence_;
	}

	private static IntPtr n_SetBreadCrumbTitle_Ljava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, IntPtr native_text)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICharSequence breadCrumbTitle = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.SetBreadCrumbTitle(breadCrumbTitle));
	}

	[Register("setBreadCrumbTitle", "(Ljava/lang/CharSequence;)Landroidx/fragment/app/FragmentTransaction;", "GetSetBreadCrumbTitle_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual FragmentTransaction SetBreadCrumbTitle(ICharSequence text)
	{
		IntPtr intPtr = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBreadCrumbTitle.(Ljava/lang/CharSequence;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(text);
		}
	}

	public FragmentTransaction SetBreadCrumbTitle(string text)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		FragmentTransaction result = SetBreadCrumbTitle(obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetSetCustomAnimations_IIHandler()
	{
		if ((object)cb_setCustomAnimations_II == null)
		{
			cb_setCustomAnimations_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_L(n_SetCustomAnimations_II));
		}
		return cb_setCustomAnimations_II;
	}

	private static IntPtr n_SetCustomAnimations_II(IntPtr jnienv, IntPtr native__this, int enter, int exit)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCustomAnimations(enter, exit));
	}

	[Register("setCustomAnimations", "(II)Landroidx/fragment/app/FragmentTransaction;", "GetSetCustomAnimations_IIHandler")]
	public unsafe virtual FragmentTransaction SetCustomAnimations(int enter, int exit)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(enter);
		ptr[1] = new JniArgumentValue(exit);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCustomAnimations.(II)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetCustomAnimations_IIIIHandler()
	{
		if ((object)cb_setCustomAnimations_IIII == null)
		{
			cb_setCustomAnimations_IIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIII_L(n_SetCustomAnimations_IIII));
		}
		return cb_setCustomAnimations_IIII;
	}

	private static IntPtr n_SetCustomAnimations_IIII(IntPtr jnienv, IntPtr native__this, int enter, int exit, int popEnter, int popExit)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCustomAnimations(enter, exit, popEnter, popExit));
	}

	[Register("setCustomAnimations", "(IIII)Landroidx/fragment/app/FragmentTransaction;", "GetSetCustomAnimations_IIIIHandler")]
	public unsafe virtual FragmentTransaction SetCustomAnimations(int enter, int exit, int popEnter, int popExit)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(enter);
		ptr[1] = new JniArgumentValue(exit);
		ptr[2] = new JniArgumentValue(popEnter);
		ptr[3] = new JniArgumentValue(popExit);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCustomAnimations.(IIII)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_Handler()
	{
		if ((object)cb_setMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_ == null)
		{
			cb_setMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_SetMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_));
		}
		return cb_setMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_;
	}

	private static IntPtr n_SetMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment, IntPtr native_state)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		AndroidX.Lifecycle.Lifecycle.State state = Java.Lang.Object.GetObject<AndroidX.Lifecycle.Lifecycle.State>(native_state, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.SetMaxLifecycle(fragment, state));
	}

	[Register("setMaxLifecycle", "(Landroidx/fragment/app/Fragment;Landroidx/lifecycle/Lifecycle$State;)Landroidx/fragment/app/FragmentTransaction;", "GetSetMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_Handler")]
	public unsafe virtual FragmentTransaction SetMaxLifecycle(Fragment fragment, AndroidX.Lifecycle.Lifecycle.State state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMaxLifecycle.(Landroidx/fragment/app/Fragment;Landroidx/lifecycle/Lifecycle$State;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetSetPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_setPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_setPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_));
		}
		return cb_setPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_;
	}

	private static IntPtr n_SetPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment primaryNavigationFragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.SetPrimaryNavigationFragment(primaryNavigationFragment));
	}

	[Register("setPrimaryNavigationFragment", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetSetPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction SetPrimaryNavigationFragment(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPrimaryNavigationFragment.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetSetReorderingAllowed_ZHandler()
	{
		if ((object)cb_setReorderingAllowed_Z == null)
		{
			cb_setReorderingAllowed_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetReorderingAllowed_Z));
		}
		return cb_setReorderingAllowed_Z;
	}

	private static IntPtr n_SetReorderingAllowed_Z(IntPtr jnienv, IntPtr native__this, bool reorderingAllowed)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetReorderingAllowed(reorderingAllowed));
	}

	[Register("setReorderingAllowed", "(Z)Landroidx/fragment/app/FragmentTransaction;", "GetSetReorderingAllowed_ZHandler")]
	public unsafe virtual FragmentTransaction SetReorderingAllowed(bool reorderingAllowed)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(reorderingAllowed);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setReorderingAllowed.(Z)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTransition_IHandler()
	{
		if ((object)cb_setTransition_I == null)
		{
			cb_setTransition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetTransition_I));
		}
		return cb_setTransition_I;
	}

	private static IntPtr n_SetTransition_I(IntPtr jnienv, IntPtr native__this, int transit)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransition(transit));
	}

	[Register("setTransition", "(I)Landroidx/fragment/app/FragmentTransaction;", "GetSetTransition_IHandler")]
	public unsafe virtual FragmentTransaction SetTransition(int transit)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(transit);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTransition.(I)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTransitionStyle_IHandler()
	{
		if ((object)cb_setTransitionStyle_I == null)
		{
			cb_setTransitionStyle_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetTransitionStyle_I));
		}
		return cb_setTransitionStyle_I;
	}

	private static IntPtr n_SetTransitionStyle_I(IntPtr jnienv, IntPtr native__this, int styleRes)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransitionStyle(styleRes));
	}

	[Register("setTransitionStyle", "(I)Landroidx/fragment/app/FragmentTransaction;", "GetSetTransitionStyle_IHandler")]
	public unsafe virtual FragmentTransaction SetTransitionStyle(int styleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(styleRes);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTransitionStyle.(I)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetShow_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_show_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_show_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Show_Landroidx_fragment_app_Fragment_));
		}
		return cb_show_Landroidx_fragment_app_Fragment_;
	}

	private static IntPtr n_Show_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment)
	{
		FragmentTransaction fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fragmentTransaction.Show(fragment));
	}

	[Register("show", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetShow_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Show(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("show.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}
}
[Register("androidx/fragment/app/FragmentTransaction", DoNotGenerateAcw = true)]
internal class FragmentTransactionInvoker : FragmentTransaction
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentTransaction", typeof(FragmentTransactionInvoker));

	public override JniPeerMembers JniPeerMembers => _members;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public FragmentTransactionInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("commit", "()I", "GetCommitHandler")]
	public unsafe override int Commit()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("commit.()I", this, null);
	}

	[Register("commitAllowingStateLoss", "()I", "GetCommitAllowingStateLossHandler")]
	public unsafe override int CommitAllowingStateLoss()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("commitAllowingStateLoss.()I", this, null);
	}

	[Register("commitNow", "()V", "GetCommitNowHandler")]
	public unsafe override void CommitNow()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("commitNow.()V", this, null);
	}

	[Register("commitNowAllowingStateLoss", "()V", "GetCommitNowAllowingStateLossHandler")]
	public unsafe override void CommitNowAllowingStateLoss()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("commitNowAllowingStateLoss.()V", this, null);
	}
}
[Register("androidx/fragment/app/FragmentOnAttachListener", "", "AndroidX.Fragment.App.IFragmentOnAttachListenerInvoker")]
public interface IFragmentOnAttachListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onAttachFragment", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V", "GetOnAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler:AndroidX.Fragment.App.IFragmentOnAttachListenerInvoker, Xamarin.AndroidX.Fragment")]
	void OnAttachFragment(FragmentManager p0, Fragment p1);
}
[Register("androidx/fragment/app/FragmentOnAttachListener", DoNotGenerateAcw = true)]
internal class IFragmentOnAttachListenerInvoker : Java.Lang.Object, IFragmentOnAttachListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentOnAttachListener", typeof(IFragmentOnAttachListenerInvoker));

	private IntPtr class_ref;

	private static Delegate cb_onAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;

	private IntPtr id_onAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IFragmentOnAttachListener GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IFragmentOnAttachListener>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.fragment.app.FragmentOnAttachListener"));
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

	public IFragmentOnAttachListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetOnAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_Handler()
	{
		if ((object)cb_onAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ == null)
		{
			cb_onAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_));
		}
		return cb_onAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_;
	}

	private static void n_OnAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
	{
		IFragmentOnAttachListener fragmentOnAttachListener = Java.Lang.Object.GetObject<IFragmentOnAttachListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FragmentManager p = Java.Lang.Object.GetObject<FragmentManager>(native_p0, JniHandleOwnership.DoNotTransfer);
		Fragment p2 = Java.Lang.Object.GetObject<Fragment>(native_p1, JniHandleOwnership.DoNotTransfer);
		fragmentOnAttachListener.OnAttachFragment(p, p2);
	}

	public unsafe void OnAttachFragment(FragmentManager p0, Fragment p1)
	{
		if (id_onAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ == IntPtr.Zero)
		{
			id_onAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_ = JNIEnv.GetMethodID(class_ref, "onAttachFragment", "(Landroidx/fragment/app/FragmentManager;Landroidx/fragment/app/Fragment;)V");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onAttachFragment_Landroidx_fragment_app_FragmentManager_Landroidx_fragment_app_Fragment_, ptr);
	}
}
public class FragmentOnAttachEventArgs : EventArgs
{
	private FragmentManager p0;

	private Fragment p1;

	public FragmentOnAttachEventArgs(FragmentManager p0, Fragment p1)
	{
		this.p0 = p0;
		this.p1 = p1;
	}
}
[Register("mono/androidx/fragment/app/FragmentOnAttachListenerImplementor")]
internal sealed class IFragmentOnAttachListenerImplementor : Java.Lang.Object, IFragmentOnAttachListener, IJavaObject, IDisposable, IJavaPeerable
{
	private object sender;

	public EventHandler<FragmentOnAttachEventArgs> Handler;

	public IFragmentOnAttachListenerImplementor(object sender)
		: base(JNIEnv.StartCreateInstance("mono/androidx/fragment/app/FragmentOnAttachListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.sender = sender;
	}

	public void OnAttachFragment(FragmentManager p0, Fragment p1)
	{
		Handler?.Invoke(sender, new FragmentOnAttachEventArgs(p0, p1));
	}

	internal static bool __IsEmpty(IFragmentOnAttachListenerImplementor value)
	{
		return value.Handler == null;
	}
}
[Register("androidx/fragment/app/FragmentResultListener", "", "AndroidX.Fragment.App.IFragmentResultListenerInvoker")]
public interface IFragmentResultListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onFragmentResult", "(Ljava/lang/String;Landroid/os/Bundle;)V", "GetOnFragmentResult_Ljava_lang_String_Landroid_os_Bundle_Handler:AndroidX.Fragment.App.IFragmentResultListenerInvoker, Xamarin.AndroidX.Fragment")]
	void OnFragmentResult(string p0, Bundle p1);
}
[Register("androidx/fragment/app/FragmentResultListener", DoNotGenerateAcw = true)]
internal class IFragmentResultListenerInvoker : Java.Lang.Object, IFragmentResultListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentResultListener", typeof(IFragmentResultListenerInvoker));

	private IntPtr class_ref;

	private static Delegate cb_onFragmentResult_Ljava_lang_String_Landroid_os_Bundle_;

	private IntPtr id_onFragmentResult_Ljava_lang_String_Landroid_os_Bundle_;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IFragmentResultListener GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IFragmentResultListener>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.fragment.app.FragmentResultListener"));
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

	public IFragmentResultListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetOnFragmentResult_Ljava_lang_String_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_onFragmentResult_Ljava_lang_String_Landroid_os_Bundle_ == null)
		{
			cb_onFragmentResult_Ljava_lang_String_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnFragmentResult_Ljava_lang_String_Landroid_os_Bundle_));
		}
		return cb_onFragmentResult_Ljava_lang_String_Landroid_os_Bundle_;
	}

	private static void n_OnFragmentResult_Ljava_lang_String_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
	{
		IFragmentResultListener fragmentResultListener = Java.Lang.Object.GetObject<IFragmentResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		Bundle p2 = Java.Lang.Object.GetObject<Bundle>(native_p1, JniHandleOwnership.DoNotTransfer);
		fragmentResultListener.OnFragmentResult(p, p2);
	}

	public unsafe void OnFragmentResult(string p0, Bundle p1)
	{
		if (id_onFragmentResult_Ljava_lang_String_Landroid_os_Bundle_ == IntPtr.Zero)
		{
			id_onFragmentResult_Ljava_lang_String_Landroid_os_Bundle_ = JNIEnv.GetMethodID(class_ref, "onFragmentResult", "(Ljava/lang/String;Landroid/os/Bundle;)V");
		}
		IntPtr intPtr = JNIEnv.NewString(p0);
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(intPtr);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onFragmentResult_Ljava_lang_String_Landroid_os_Bundle_, ptr);
		JNIEnv.DeleteLocalRef(intPtr);
	}
}
[Register("androidx/fragment/app/FragmentResultOwner", "", "AndroidX.Fragment.App.IFragmentResultOwnerInvoker")]
public interface IFragmentResultOwner : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("clearFragmentResult", "(Ljava/lang/String;)V", "GetClearFragmentResult_Ljava_lang_String_Handler:AndroidX.Fragment.App.IFragmentResultOwnerInvoker, Xamarin.AndroidX.Fragment")]
	void ClearFragmentResult(string p0);

	[Register("clearFragmentResultListener", "(Ljava/lang/String;)V", "GetClearFragmentResultListener_Ljava_lang_String_Handler:AndroidX.Fragment.App.IFragmentResultOwnerInvoker, Xamarin.AndroidX.Fragment")]
	void ClearFragmentResultListener(string p0);

	[Register("setFragmentResult", "(Ljava/lang/String;Landroid/os/Bundle;)V", "GetSetFragmentResult_Ljava_lang_String_Landroid_os_Bundle_Handler:AndroidX.Fragment.App.IFragmentResultOwnerInvoker, Xamarin.AndroidX.Fragment")]
	void SetFragmentResult(string p0, Bundle p1);

	[Register("setFragmentResultListener", "(Ljava/lang/String;Landroidx/lifecycle/LifecycleOwner;Landroidx/fragment/app/FragmentResultListener;)V", "GetSetFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_Handler:AndroidX.Fragment.App.IFragmentResultOwnerInvoker, Xamarin.AndroidX.Fragment")]
	void SetFragmentResultListener(string p0, ILifecycleOwner p1, IFragmentResultListener p2);
}
[Register("androidx/fragment/app/FragmentResultOwner", DoNotGenerateAcw = true)]
internal class IFragmentResultOwnerInvoker : Java.Lang.Object, IFragmentResultOwner, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentResultOwner", typeof(IFragmentResultOwnerInvoker));

	private IntPtr class_ref;

	private static Delegate cb_clearFragmentResult_Ljava_lang_String_;

	private IntPtr id_clearFragmentResult_Ljava_lang_String_;

	private static Delegate cb_clearFragmentResultListener_Ljava_lang_String_;

	private IntPtr id_clearFragmentResultListener_Ljava_lang_String_;

	private static Delegate cb_setFragmentResult_Ljava_lang_String_Landroid_os_Bundle_;

	private IntPtr id_setFragmentResult_Ljava_lang_String_Landroid_os_Bundle_;

	private static Delegate cb_setFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_;

	private IntPtr id_setFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IFragmentResultOwner GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IFragmentResultOwner>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.fragment.app.FragmentResultOwner"));
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

	public IFragmentResultOwnerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetClearFragmentResult_Ljava_lang_String_Handler()
	{
		if ((object)cb_clearFragmentResult_Ljava_lang_String_ == null)
		{
			cb_clearFragmentResult_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ClearFragmentResult_Ljava_lang_String_));
		}
		return cb_clearFragmentResult_Ljava_lang_String_;
	}

	private static void n_ClearFragmentResult_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
	{
		IFragmentResultOwner fragmentResultOwner = Java.Lang.Object.GetObject<IFragmentResultOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		fragmentResultOwner.ClearFragmentResult(p);
	}

	public unsafe void ClearFragmentResult(string p0)
	{
		if (id_clearFragmentResult_Ljava_lang_String_ == IntPtr.Zero)
		{
			id_clearFragmentResult_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "clearFragmentResult", "(Ljava/lang/String;)V");
		}
		IntPtr intPtr = JNIEnv.NewString(p0);
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(intPtr);
		JNIEnv.CallVoidMethod(base.Handle, id_clearFragmentResult_Ljava_lang_String_, ptr);
		JNIEnv.DeleteLocalRef(intPtr);
	}

	private static Delegate GetClearFragmentResultListener_Ljava_lang_String_Handler()
	{
		if ((object)cb_clearFragmentResultListener_Ljava_lang_String_ == null)
		{
			cb_clearFragmentResultListener_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ClearFragmentResultListener_Ljava_lang_String_));
		}
		return cb_clearFragmentResultListener_Ljava_lang_String_;
	}

	private static void n_ClearFragmentResultListener_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
	{
		IFragmentResultOwner fragmentResultOwner = Java.Lang.Object.GetObject<IFragmentResultOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		fragmentResultOwner.ClearFragmentResultListener(p);
	}

	public unsafe void ClearFragmentResultListener(string p0)
	{
		if (id_clearFragmentResultListener_Ljava_lang_String_ == IntPtr.Zero)
		{
			id_clearFragmentResultListener_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "clearFragmentResultListener", "(Ljava/lang/String;)V");
		}
		IntPtr intPtr = JNIEnv.NewString(p0);
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(intPtr);
		JNIEnv.CallVoidMethod(base.Handle, id_clearFragmentResultListener_Ljava_lang_String_, ptr);
		JNIEnv.DeleteLocalRef(intPtr);
	}

	private static Delegate GetSetFragmentResult_Ljava_lang_String_Landroid_os_Bundle_Handler()
	{
		if ((object)cb_setFragmentResult_Ljava_lang_String_Landroid_os_Bundle_ == null)
		{
			cb_setFragmentResult_Ljava_lang_String_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetFragmentResult_Ljava_lang_String_Landroid_os_Bundle_));
		}
		return cb_setFragmentResult_Ljava_lang_String_Landroid_os_Bundle_;
	}

	private static void n_SetFragmentResult_Ljava_lang_String_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
	{
		IFragmentResultOwner fragmentResultOwner = Java.Lang.Object.GetObject<IFragmentResultOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		Bundle p2 = Java.Lang.Object.GetObject<Bundle>(native_p1, JniHandleOwnership.DoNotTransfer);
		fragmentResultOwner.SetFragmentResult(p, p2);
	}

	public unsafe void SetFragmentResult(string p0, Bundle p1)
	{
		if (id_setFragmentResult_Ljava_lang_String_Landroid_os_Bundle_ == IntPtr.Zero)
		{
			id_setFragmentResult_Ljava_lang_String_Landroid_os_Bundle_ = JNIEnv.GetMethodID(class_ref, "setFragmentResult", "(Ljava/lang/String;Landroid/os/Bundle;)V");
		}
		IntPtr intPtr = JNIEnv.NewString(p0);
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(intPtr);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_setFragmentResult_Ljava_lang_String_Landroid_os_Bundle_, ptr);
		JNIEnv.DeleteLocalRef(intPtr);
	}

	private static Delegate GetSetFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_Handler()
	{
		if ((object)cb_setFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_ == null)
		{
			cb_setFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SetFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_));
		}
		return cb_setFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_;
	}

	private static void n_SetFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
	{
		IFragmentResultOwner fragmentResultOwner = Java.Lang.Object.GetObject<IFragmentResultOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		ILifecycleOwner p2 = Java.Lang.Object.GetObject<ILifecycleOwner>(native_p1, JniHandleOwnership.DoNotTransfer);
		IFragmentResultListener p3 = Java.Lang.Object.GetObject<IFragmentResultListener>(native_p2, JniHandleOwnership.DoNotTransfer);
		fragmentResultOwner.SetFragmentResultListener(p, p2, p3);
	}

	public unsafe void SetFragmentResultListener(string p0, ILifecycleOwner p1, IFragmentResultListener p2)
	{
		if (id_setFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_ == IntPtr.Zero)
		{
			id_setFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_ = JNIEnv.GetMethodID(class_ref, "setFragmentResultListener", "(Ljava/lang/String;Landroidx/lifecycle/LifecycleOwner;Landroidx/fragment/app/FragmentResultListener;)V");
		}
		IntPtr intPtr = JNIEnv.NewString(p0);
		JValue* ptr = stackalloc JValue[3];
		*ptr = new JValue(intPtr);
		ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
		ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
		JNIEnv.CallVoidMethod(base.Handle, id_setFragmentResultListener_Ljava_lang_String_Landroidx_lifecycle_LifecycleOwner_Landroidx_fragment_app_FragmentResultListener_, ptr);
		JNIEnv.DeleteLocalRef(intPtr);
	}
}
[Register("androidx/fragment/app/ListFragment", DoNotGenerateAcw = true)]
public class ListFragment : Fragment
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/ListFragment", typeof(ListFragment));

	private static Delegate cb_getListAdapter;

	private static Delegate cb_setListAdapter_Landroid_widget_ListAdapter_;

	private static Delegate cb_getListView;

	private static Delegate cb_getSelectedItemId;

	private static Delegate cb_getSelectedItemPosition;

	private static Delegate cb_onListItemClick_Landroid_widget_ListView_Landroid_view_View_IJ;

	private static Delegate cb_setEmptyText_Ljava_lang_CharSequence_;

	private static Delegate cb_setListShown_Z;

	private static Delegate cb_setListShownNoAnimation_Z;

	private static Delegate cb_setSelection_I;

	internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual IListAdapter ListAdapter
	{
		[Register("getListAdapter", "()Landroid/widget/ListAdapter;", "GetGetListAdapterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IListAdapter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getListAdapter.()Landroid/widget/ListAdapter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setListAdapter", "(Landroid/widget/ListAdapter;)V", "GetSetListAdapter_Landroid_widget_ListAdapter_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setListAdapter.(Landroid/widget/ListAdapter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ListView ListView
	{
		[Register("getListView", "()Landroid/widget/ListView;", "GetGetListViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ListView>(_members.InstanceMethods.InvokeVirtualObjectMethod("getListView.()Landroid/widget/ListView;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual long SelectedItemId
	{
		[Register("getSelectedItemId", "()J", "GetGetSelectedItemIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getSelectedItemId.()J", this, null);
		}
	}

	public unsafe virtual int SelectedItemPosition
	{
		[Register("getSelectedItemPosition", "()I", "GetGetSelectedItemPositionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSelectedItemPosition.()I", this, null);
		}
	}

	protected ListFragment(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ListFragment()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetListAdapterHandler()
	{
		if ((object)cb_getListAdapter == null)
		{
			cb_getListAdapter = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetListAdapter));
		}
		return cb_getListAdapter;
	}

	private static IntPtr n_GetListAdapter(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ListFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListAdapter);
	}

	private static Delegate GetSetListAdapter_Landroid_widget_ListAdapter_Handler()
	{
		if ((object)cb_setListAdapter_Landroid_widget_ListAdapter_ == null)
		{
			cb_setListAdapter_Landroid_widget_ListAdapter_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetListAdapter_Landroid_widget_ListAdapter_));
		}
		return cb_setListAdapter_Landroid_widget_ListAdapter_;
	}

	private static void n_SetListAdapter_Landroid_widget_ListAdapter_(IntPtr jnienv, IntPtr native__this, IntPtr native_adapter)
	{
		ListFragment listFragment = Java.Lang.Object.GetObject<ListFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IListAdapter listAdapter = Java.Lang.Object.GetObject<IListAdapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
		listFragment.ListAdapter = listAdapter;
	}

	private static Delegate GetGetListViewHandler()
	{
		if ((object)cb_getListView == null)
		{
			cb_getListView = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetListView));
		}
		return cb_getListView;
	}

	private static IntPtr n_GetListView(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ListFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListView);
	}

	private static Delegate GetGetSelectedItemIdHandler()
	{
		if ((object)cb_getSelectedItemId == null)
		{
			cb_getSelectedItemId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetSelectedItemId));
		}
		return cb_getSelectedItemId;
	}

	private static long n_GetSelectedItemId(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<ListFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SelectedItemId;
	}

	private static Delegate GetGetSelectedItemPositionHandler()
	{
		if ((object)cb_getSelectedItemPosition == null)
		{
			cb_getSelectedItemPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSelectedItemPosition));
		}
		return cb_getSelectedItemPosition;
	}

	private static int n_GetSelectedItemPosition(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<ListFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SelectedItemPosition;
	}

	private static Delegate GetOnListItemClick_Landroid_widget_ListView_Landroid_view_View_IJHandler()
	{
		if ((object)cb_onListItemClick_Landroid_widget_ListView_Landroid_view_View_IJ == null)
		{
			cb_onListItemClick_Landroid_widget_ListView_Landroid_view_View_IJ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLIJ_V(n_OnListItemClick_Landroid_widget_ListView_Landroid_view_View_IJ));
		}
		return cb_onListItemClick_Landroid_widget_ListView_Landroid_view_View_IJ;
	}

	private static void n_OnListItemClick_Landroid_widget_ListView_Landroid_view_View_IJ(IntPtr jnienv, IntPtr native__this, IntPtr native_l, IntPtr native_v, int position, long id)
	{
		ListFragment listFragment = Java.Lang.Object.GetObject<ListFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ListView l = Java.Lang.Object.GetObject<ListView>(native_l, JniHandleOwnership.DoNotTransfer);
		View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
		listFragment.OnListItemClick(l, v, position, id);
	}

	[Register("onListItemClick", "(Landroid/widget/ListView;Landroid/view/View;IJ)V", "GetOnListItemClick_Landroid_widget_ListView_Landroid_view_View_IJHandler")]
	public unsafe virtual void OnListItemClick(ListView l, View v, int position, long id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(l?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(position);
			ptr[3] = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onListItemClick.(Landroid/widget/ListView;Landroid/view/View;IJ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(l);
			GC.KeepAlive(v);
		}
	}

	[Register("requireListAdapter", "()Landroid/widget/ListAdapter;", "")]
	public unsafe IListAdapter RequireListAdapter()
	{
		return Java.Lang.Object.GetObject<IListAdapter>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireListAdapter.()Landroid/widget/ListAdapter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetEmptyText_Ljava_lang_CharSequence_Handler()
	{
		if ((object)cb_setEmptyText_Ljava_lang_CharSequence_ == null)
		{
			cb_setEmptyText_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetEmptyText_Ljava_lang_CharSequence_));
		}
		return cb_setEmptyText_Ljava_lang_CharSequence_;
	}

	private static void n_SetEmptyText_Ljava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, IntPtr native_text)
	{
		ListFragment listFragment = Java.Lang.Object.GetObject<ListFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICharSequence emptyText = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
		listFragment.SetEmptyText(emptyText);
	}

	[Register("setEmptyText", "(Ljava/lang/CharSequence;)V", "GetSetEmptyText_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual void SetEmptyText(ICharSequence text)
	{
		IntPtr intPtr = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEmptyText.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(text);
		}
	}

	public void SetEmptyText(string text)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		SetEmptyText(obj);
		obj?.Dispose();
	}

	private static Delegate GetSetListShown_ZHandler()
	{
		if ((object)cb_setListShown_Z == null)
		{
			cb_setListShown_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetListShown_Z));
		}
		return cb_setListShown_Z;
	}

	private static void n_SetListShown_Z(IntPtr jnienv, IntPtr native__this, bool shown)
	{
		Java.Lang.Object.GetObject<ListFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetListShown(shown);
	}

	[Register("setListShown", "(Z)V", "GetSetListShown_ZHandler")]
	public unsafe virtual void SetListShown(bool shown)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(shown);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setListShown.(Z)V", this, ptr);
	}

	private static Delegate GetSetListShownNoAnimation_ZHandler()
	{
		if ((object)cb_setListShownNoAnimation_Z == null)
		{
			cb_setListShownNoAnimation_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetListShownNoAnimation_Z));
		}
		return cb_setListShownNoAnimation_Z;
	}

	private static void n_SetListShownNoAnimation_Z(IntPtr jnienv, IntPtr native__this, bool shown)
	{
		Java.Lang.Object.GetObject<ListFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetListShownNoAnimation(shown);
	}

	[Register("setListShownNoAnimation", "(Z)V", "GetSetListShownNoAnimation_ZHandler")]
	public unsafe virtual void SetListShownNoAnimation(bool shown)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(shown);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setListShownNoAnimation.(Z)V", this, ptr);
	}

	private static Delegate GetSetSelection_IHandler()
	{
		if ((object)cb_setSelection_I == null)
		{
			cb_setSelection_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetSelection_I));
		}
		return cb_setSelection_I;
	}

	private static void n_SetSelection_I(IntPtr jnienv, IntPtr native__this, int position)
	{
		Java.Lang.Object.GetObject<ListFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSelection(position);
	}

	[Register("setSelection", "(I)V", "GetSetSelection_IHandler")]
	public unsafe virtual void SetSelection(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSelection.(I)V", this, ptr);
	}
}
