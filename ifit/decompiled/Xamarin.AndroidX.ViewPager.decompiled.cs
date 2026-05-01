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
using Android.Database;
using Android.Graphics.Drawables;
using Android.OS;
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
[assembly: NamespaceMapping(Java = "androidx.viewpager.widget", Managed = "AndroidX.ViewPager.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.viewpager:viewpager'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.ViewPager")]
[assembly: AssemblyTitle("Xamarin.AndroidX.ViewPager")]
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
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPF_V(IntPtr jnienv, IntPtr klass, float p0);
internal delegate float _JniMarshal_PPI_F(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate bool _JniMarshal_PPI_Z(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPIFI_V(IntPtr jnienv, IntPtr klass, int p0, float p1, int p2);
internal delegate void _JniMarshal_PPIZ_V(IntPtr jnienv, IntPtr klass, int p0, bool p1);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLF_V(IntPtr jnienv, IntPtr klass, IntPtr p0, float p1);
internal delegate IntPtr _JniMarshal_PPLI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate void _JniMarshal_PPLIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate bool _JniMarshal_PPLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate bool _JniMarshal_PPLZIII_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1, int p2, int p3, int p4);
internal delegate void _JniMarshal_PPZIIII_V(IntPtr jnienv, IntPtr klass, bool p0, int p1, int p2, int p3, int p4);
internal delegate void _JniMarshal_PPZL_V(IntPtr jnienv, IntPtr klass, bool p0, IntPtr p1);
internal delegate void _JniMarshal_PPZLI_V(IntPtr jnienv, IntPtr klass, bool p0, IntPtr p1, int p2);
namespace AndroidX.ViewPager.Widget
{
	[Register("androidx/viewpager/widget/PagerAdapter", DoNotGenerateAcw = true)]
	public abstract class PagerAdapter : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager/widget/PagerAdapter", typeof(PagerAdapter));

		private static Delegate cb_getCount;

		private static Delegate cb_destroyItem_Landroid_view_View_ILjava_lang_Object_;

		private static Delegate cb_destroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_;

		private static Delegate cb_finishUpdate_Landroid_view_View_;

		private static Delegate cb_finishUpdate_Landroid_view_ViewGroup_;

		private static Delegate cb_getItemPosition_Ljava_lang_Object_;

		private static Delegate cb_getPageTitle_I;

		private static Delegate cb_getPageWidth_I;

		private static Delegate cb_instantiateItem_Landroid_view_View_I;

		private static Delegate cb_instantiateItem_Landroid_view_ViewGroup_I;

		private static Delegate cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_;

		private static Delegate cb_notifyDataSetChanged;

		private static Delegate cb_registerDataSetObserver_Landroid_database_DataSetObserver_;

		private static Delegate cb_restoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_;

		private static Delegate cb_saveState;

		private static Delegate cb_setPrimaryItem_Landroid_view_View_ILjava_lang_Object_;

		private static Delegate cb_setPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_;

		private static Delegate cb_startUpdate_Landroid_view_View_;

		private static Delegate cb_startUpdate_Landroid_view_ViewGroup_;

		private static Delegate cb_unregisterDataSetObserver_Landroid_database_DataSetObserver_;

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

		public abstract int Count
		{
			[Register("getCount", "()I", "GetGetCountHandler")]
			get;
		}

		protected PagerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PagerAdapter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetCountHandler()
		{
			if ((object)cb_getCount == null)
			{
				cb_getCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCount));
			}
			return cb_getCount;
		}

		private static int n_GetCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Count;
		}

		private static Delegate GetDestroyItem_Landroid_view_View_ILjava_lang_Object_Handler()
		{
			if ((object)cb_destroyItem_Landroid_view_View_ILjava_lang_Object_ == null)
			{
				cb_destroyItem_Landroid_view_View_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_DestroyItem_Landroid_view_View_ILjava_lang_Object_));
			}
			return cb_destroyItem_Landroid_view_View_ILjava_lang_Object_;
		}

		private static void n_DestroyItem_Landroid_view_View_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_container, int position, IntPtr native__object)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View container = Java.Lang.Object.GetObject<View>(native_container, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.DestroyItem(container, position, obj);
		}

		[Register("destroyItem", "(Landroid/view/View;ILjava/lang/Object;)V", "GetDestroyItem_Landroid_view_View_ILjava_lang_Object_Handler")]
		public unsafe virtual void DestroyItem(View container, int position, Java.Lang.Object @object)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("destroyItem.(Landroid/view/View;ILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
				GC.KeepAlive(@object);
			}
		}

		private static Delegate GetDestroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_Handler()
		{
			if ((object)cb_destroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_ == null)
			{
				cb_destroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_DestroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_));
			}
			return cb_destroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_;
		}

		private static void n_DestroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_container, int position, IntPtr native__object)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.DestroyItem(container, position, obj);
		}

		[Register("destroyItem", "(Landroid/view/ViewGroup;ILjava/lang/Object;)V", "GetDestroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_Handler")]
		public unsafe virtual void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("destroyItem.(Landroid/view/ViewGroup;ILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
				GC.KeepAlive(@object);
			}
		}

		private static Delegate GetFinishUpdate_Landroid_view_View_Handler()
		{
			if ((object)cb_finishUpdate_Landroid_view_View_ == null)
			{
				cb_finishUpdate_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_FinishUpdate_Landroid_view_View_));
			}
			return cb_finishUpdate_Landroid_view_View_;
		}

		private static void n_FinishUpdate_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View container = Java.Lang.Object.GetObject<View>(native_container, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.FinishUpdate(container);
		}

		[Register("finishUpdate", "(Landroid/view/View;)V", "GetFinishUpdate_Landroid_view_View_Handler")]
		public unsafe virtual void FinishUpdate(View container)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("finishUpdate.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetFinishUpdate_Landroid_view_ViewGroup_Handler()
		{
			if ((object)cb_finishUpdate_Landroid_view_ViewGroup_ == null)
			{
				cb_finishUpdate_Landroid_view_ViewGroup_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_FinishUpdate_Landroid_view_ViewGroup_));
			}
			return cb_finishUpdate_Landroid_view_ViewGroup_;
		}

		private static void n_FinishUpdate_Landroid_view_ViewGroup_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.FinishUpdate(container);
		}

		[Register("finishUpdate", "(Landroid/view/ViewGroup;)V", "GetFinishUpdate_Landroid_view_ViewGroup_Handler")]
		public unsafe virtual void FinishUpdate(ViewGroup container)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("finishUpdate.(Landroid/view/ViewGroup;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetGetItemPosition_Ljava_lang_Object_Handler()
		{
			if ((object)cb_getItemPosition_Ljava_lang_Object_ == null)
			{
				cb_getItemPosition_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetItemPosition_Ljava_lang_Object_));
			}
			return cb_getItemPosition_Ljava_lang_Object_;
		}

		private static int n_GetItemPosition_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native__object)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			return pagerAdapter.GetItemPosition(obj);
		}

		[Register("getItemPosition", "(Ljava/lang/Object;)I", "GetGetItemPosition_Ljava_lang_Object_Handler")]
		public unsafe virtual int GetItemPosition(Java.Lang.Object @object)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getItemPosition.(Ljava/lang/Object;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@object);
			}
		}

		private static Delegate GetGetPageTitle_IHandler()
		{
			if ((object)cb_getPageTitle_I == null)
			{
				cb_getPageTitle_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetPageTitle_I));
			}
			return cb_getPageTitle_I;
		}

		private static IntPtr n_GetPageTitle_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPageTitleFormatted(position));
		}

		[Register("getPageTitle", "(I)Ljava/lang/CharSequence;", "GetGetPageTitle_IHandler")]
		public unsafe virtual ICharSequence GetPageTitleFormatted(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPageTitle.(I)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		public string GetPageTitle(int position)
		{
			return GetPageTitleFormatted(position)?.ToString();
		}

		private static Delegate GetGetPageWidth_IHandler()
		{
			if ((object)cb_getPageWidth_I == null)
			{
				cb_getPageWidth_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_F(n_GetPageWidth_I));
			}
			return cb_getPageWidth_I;
		}

		private static float n_GetPageWidth_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			return Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPageWidth(position);
		}

		[Register("getPageWidth", "(I)F", "GetGetPageWidth_IHandler")]
		public unsafe virtual float GetPageWidth(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getPageWidth.(I)F", this, ptr);
		}

		private static Delegate GetInstantiateItem_Landroid_view_View_IHandler()
		{
			if ((object)cb_instantiateItem_Landroid_view_View_I == null)
			{
				cb_instantiateItem_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_InstantiateItem_Landroid_view_View_I));
			}
			return cb_instantiateItem_Landroid_view_View_I;
		}

		private static IntPtr n_InstantiateItem_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_container, int position)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View container = Java.Lang.Object.GetObject<View>(native_container, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(pagerAdapter.InstantiateItem(container, position));
		}

		[Register("instantiateItem", "(Landroid/view/View;I)Ljava/lang/Object;", "GetInstantiateItem_Landroid_view_View_IHandler")]
		public unsafe virtual Java.Lang.Object InstantiateItem(View container, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("instantiateItem.(Landroid/view/View;I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetInstantiateItem_Landroid_view_ViewGroup_IHandler()
		{
			if ((object)cb_instantiateItem_Landroid_view_ViewGroup_I == null)
			{
				cb_instantiateItem_Landroid_view_ViewGroup_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_InstantiateItem_Landroid_view_ViewGroup_I));
			}
			return cb_instantiateItem_Landroid_view_ViewGroup_I;
		}

		private static IntPtr n_InstantiateItem_Landroid_view_ViewGroup_I(IntPtr jnienv, IntPtr native__this, IntPtr native_container, int position)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(pagerAdapter.InstantiateItem(container, position));
		}

		[Register("instantiateItem", "(Landroid/view/ViewGroup;I)Ljava/lang/Object;", "GetInstantiateItem_Landroid_view_ViewGroup_IHandler")]
		public unsafe virtual Java.Lang.Object InstantiateItem(ViewGroup container, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("instantiateItem.(Landroid/view/ViewGroup;I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(container);
			}
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
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			return pagerAdapter.IsViewFromObject(view, obj);
		}

		[Register("isViewFromObject", "(Landroid/view/View;Ljava/lang/Object;)Z", "GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler")]
		public abstract bool IsViewFromObject(View view, Java.Lang.Object @object);

		private static Delegate GetNotifyDataSetChangedHandler()
		{
			if ((object)cb_notifyDataSetChanged == null)
			{
				cb_notifyDataSetChanged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_NotifyDataSetChanged));
			}
			return cb_notifyDataSetChanged;
		}

		private static void n_NotifyDataSetChanged(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NotifyDataSetChanged();
		}

		[Register("notifyDataSetChanged", "()V", "GetNotifyDataSetChangedHandler")]
		public unsafe virtual void NotifyDataSetChanged()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("notifyDataSetChanged.()V", this, null);
		}

		private static Delegate GetRegisterDataSetObserver_Landroid_database_DataSetObserver_Handler()
		{
			if ((object)cb_registerDataSetObserver_Landroid_database_DataSetObserver_ == null)
			{
				cb_registerDataSetObserver_Landroid_database_DataSetObserver_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RegisterDataSetObserver_Landroid_database_DataSetObserver_));
			}
			return cb_registerDataSetObserver_Landroid_database_DataSetObserver_;
		}

		private static void n_RegisterDataSetObserver_Landroid_database_DataSetObserver_(IntPtr jnienv, IntPtr native__this, IntPtr native_observer)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSetObserver observer = Java.Lang.Object.GetObject<DataSetObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.RegisterDataSetObserver(observer);
		}

		[Register("registerDataSetObserver", "(Landroid/database/DataSetObserver;)V", "GetRegisterDataSetObserver_Landroid_database_DataSetObserver_Handler")]
		public unsafe virtual void RegisterDataSetObserver(DataSetObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerDataSetObserver.(Landroid/database/DataSetObserver;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		private static Delegate GetRestoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_Handler()
		{
			if ((object)cb_restoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_ == null)
			{
				cb_restoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RestoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_));
			}
			return cb_restoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_;
		}

		private static void n_RestoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_(IntPtr jnienv, IntPtr native__this, IntPtr native_state, IntPtr native_loader)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			ClassLoader loader = Java.Lang.Object.GetObject<ClassLoader>(native_loader, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.RestoreState(state, loader);
		}

		[Register("restoreState", "(Landroid/os/Parcelable;Ljava/lang/ClassLoader;)V", "GetRestoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_Handler")]
		public unsafe virtual void RestoreState(IParcelable state, ClassLoader loader)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
				ptr[1] = new JniArgumentValue(loader?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("restoreState.(Landroid/os/Parcelable;Ljava/lang/ClassLoader;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
				GC.KeepAlive(loader);
			}
		}

		private static Delegate GetSaveStateHandler()
		{
			if ((object)cb_saveState == null)
			{
				cb_saveState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_SaveState));
			}
			return cb_saveState;
		}

		private static IntPtr n_SaveState(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SaveState());
		}

		[Register("saveState", "()Landroid/os/Parcelable;", "GetSaveStateHandler")]
		public unsafe virtual IParcelable SaveState()
		{
			return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("saveState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetPrimaryItem_Landroid_view_View_ILjava_lang_Object_Handler()
		{
			if ((object)cb_setPrimaryItem_Landroid_view_View_ILjava_lang_Object_ == null)
			{
				cb_setPrimaryItem_Landroid_view_View_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_SetPrimaryItem_Landroid_view_View_ILjava_lang_Object_));
			}
			return cb_setPrimaryItem_Landroid_view_View_ILjava_lang_Object_;
		}

		private static void n_SetPrimaryItem_Landroid_view_View_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_container, int position, IntPtr native__object)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View container = Java.Lang.Object.GetObject<View>(native_container, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.SetPrimaryItem(container, position, obj);
		}

		[Register("setPrimaryItem", "(Landroid/view/View;ILjava/lang/Object;)V", "GetSetPrimaryItem_Landroid_view_View_ILjava_lang_Object_Handler")]
		public unsafe virtual void SetPrimaryItem(View container, int position, Java.Lang.Object @object)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPrimaryItem.(Landroid/view/View;ILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
				GC.KeepAlive(@object);
			}
		}

		private static Delegate GetSetPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_Handler()
		{
			if ((object)cb_setPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_ == null)
			{
				cb_setPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_SetPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_));
			}
			return cb_setPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_;
		}

		private static void n_SetPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_container, int position, IntPtr native__object)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.SetPrimaryItem(container, position, obj);
		}

		[Register("setPrimaryItem", "(Landroid/view/ViewGroup;ILjava/lang/Object;)V", "GetSetPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_Handler")]
		public unsafe virtual void SetPrimaryItem(ViewGroup container, int position, Java.Lang.Object @object)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPrimaryItem.(Landroid/view/ViewGroup;ILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
				GC.KeepAlive(@object);
			}
		}

		private static Delegate GetStartUpdate_Landroid_view_View_Handler()
		{
			if ((object)cb_startUpdate_Landroid_view_View_ == null)
			{
				cb_startUpdate_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StartUpdate_Landroid_view_View_));
			}
			return cb_startUpdate_Landroid_view_View_;
		}

		private static void n_StartUpdate_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View container = Java.Lang.Object.GetObject<View>(native_container, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.StartUpdate(container);
		}

		[Register("startUpdate", "(Landroid/view/View;)V", "GetStartUpdate_Landroid_view_View_Handler")]
		public unsafe virtual void StartUpdate(View container)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("startUpdate.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetStartUpdate_Landroid_view_ViewGroup_Handler()
		{
			if ((object)cb_startUpdate_Landroid_view_ViewGroup_ == null)
			{
				cb_startUpdate_Landroid_view_ViewGroup_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StartUpdate_Landroid_view_ViewGroup_));
			}
			return cb_startUpdate_Landroid_view_ViewGroup_;
		}

		private static void n_StartUpdate_Landroid_view_ViewGroup_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.StartUpdate(container);
		}

		[Register("startUpdate", "(Landroid/view/ViewGroup;)V", "GetStartUpdate_Landroid_view_ViewGroup_Handler")]
		public unsafe virtual void StartUpdate(ViewGroup container)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("startUpdate.(Landroid/view/ViewGroup;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetUnregisterDataSetObserver_Landroid_database_DataSetObserver_Handler()
		{
			if ((object)cb_unregisterDataSetObserver_Landroid_database_DataSetObserver_ == null)
			{
				cb_unregisterDataSetObserver_Landroid_database_DataSetObserver_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterDataSetObserver_Landroid_database_DataSetObserver_));
			}
			return cb_unregisterDataSetObserver_Landroid_database_DataSetObserver_;
		}

		private static void n_UnregisterDataSetObserver_Landroid_database_DataSetObserver_(IntPtr jnienv, IntPtr native__this, IntPtr native_observer)
		{
			PagerAdapter pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSetObserver observer = Java.Lang.Object.GetObject<DataSetObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.UnregisterDataSetObserver(observer);
		}

		[Register("unregisterDataSetObserver", "(Landroid/database/DataSetObserver;)V", "GetUnregisterDataSetObserver_Landroid_database_DataSetObserver_Handler")]
		public unsafe virtual void UnregisterDataSetObserver(DataSetObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterDataSetObserver.(Landroid/database/DataSetObserver;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}
	}
	[Register("androidx/viewpager/widget/PagerAdapter", DoNotGenerateAcw = true)]
	internal class PagerAdapterInvoker : PagerAdapter
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager/widget/PagerAdapter", typeof(PagerAdapterInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override int Count
		{
			[Register("getCount", "()I", "GetGetCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getCount.()I", this, null);
			}
		}

		public PagerAdapterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("isViewFromObject", "(Landroid/view/View;Ljava/lang/Object;)Z", "GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler")]
		public unsafe override bool IsViewFromObject(View view, Java.Lang.Object @object)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isViewFromObject.(Landroid/view/View;Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
				GC.KeepAlive(@object);
			}
		}
	}
	[Register("androidx/viewpager/widget/ViewPager", DoNotGenerateAcw = true)]
	public class ViewPager : ViewGroup
	{
		[Register("androidx/viewpager/widget/ViewPager$LayoutParams", DoNotGenerateAcw = true)]
		public new class LayoutParams : ViewGroup.LayoutParams
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager/widget/ViewPager$LayoutParams", typeof(LayoutParams));

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

			[Register("isDecor")]
			public bool IsDecor
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("isDecor.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("isDecor.Z", this, value);
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

			protected LayoutParams(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe LayoutParams()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
			public unsafe LayoutParams(Context context, IAttributeSet attrs)
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

		[Register("androidx/viewpager/widget/ViewPager$OnAdapterChangeListener", "", "AndroidX.ViewPager.Widget.ViewPager/IOnAdapterChangeListenerInvoker")]
		public interface IOnAdapterChangeListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onAdapterChanged", "(Landroidx/viewpager/widget/ViewPager;Landroidx/viewpager/widget/PagerAdapter;Landroidx/viewpager/widget/PagerAdapter;)V", "GetOnAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_Handler:AndroidX.ViewPager.Widget.ViewPager/IOnAdapterChangeListenerInvoker, Xamarin.AndroidX.ViewPager")]
			void OnAdapterChanged(ViewPager viewPager, PagerAdapter oldAdapter, PagerAdapter newAdapter);
		}

		[Register("androidx/viewpager/widget/ViewPager$OnAdapterChangeListener", DoNotGenerateAcw = true)]
		internal class IOnAdapterChangeListenerInvoker : Java.Lang.Object, IOnAdapterChangeListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager/widget/ViewPager$OnAdapterChangeListener", typeof(IOnAdapterChangeListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_;

			private IntPtr id_onAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_;

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

			public static IOnAdapterChangeListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnAdapterChangeListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.viewpager.widget.ViewPager.OnAdapterChangeListener'.");
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

			public IOnAdapterChangeListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_Handler()
			{
				if ((object)cb_onAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_ == null)
				{
					cb_onAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_));
				}
				return cb_onAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_;
			}

			private static void n_OnAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewPager, IntPtr native_oldAdapter, IntPtr native_newAdapter)
			{
				IOnAdapterChangeListener onAdapterChangeListener = Java.Lang.Object.GetObject<IOnAdapterChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(native_viewPager, JniHandleOwnership.DoNotTransfer);
				PagerAdapter oldAdapter = Java.Lang.Object.GetObject<PagerAdapter>(native_oldAdapter, JniHandleOwnership.DoNotTransfer);
				PagerAdapter newAdapter = Java.Lang.Object.GetObject<PagerAdapter>(native_newAdapter, JniHandleOwnership.DoNotTransfer);
				onAdapterChangeListener.OnAdapterChanged(viewPager, oldAdapter, newAdapter);
			}

			public unsafe void OnAdapterChanged(ViewPager viewPager, PagerAdapter oldAdapter, PagerAdapter newAdapter)
			{
				if (id_onAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_ == IntPtr.Zero)
				{
					id_onAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_ = JNIEnv.GetMethodID(class_ref, "onAdapterChanged", "(Landroidx/viewpager/widget/ViewPager;Landroidx/viewpager/widget/PagerAdapter;Landroidx/viewpager/widget/PagerAdapter;)V");
				}
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(viewPager?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(oldAdapter?.Handle ?? IntPtr.Zero);
				ptr[2] = new JValue(newAdapter?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_, ptr);
			}
		}

		public class AdapterChangeEventArgs : EventArgs
		{
			private ViewPager viewPager;

			private PagerAdapter oldAdapter;

			private PagerAdapter newAdapter;

			public AdapterChangeEventArgs(ViewPager viewPager, PagerAdapter oldAdapter, PagerAdapter newAdapter)
			{
				this.viewPager = viewPager;
				this.oldAdapter = oldAdapter;
				this.newAdapter = newAdapter;
			}
		}

		[Register("mono/androidx/viewpager/widget/ViewPager_OnAdapterChangeListenerImplementor")]
		internal sealed class IOnAdapterChangeListenerImplementor : Java.Lang.Object, IOnAdapterChangeListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<AdapterChangeEventArgs> Handler;

			public IOnAdapterChangeListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/androidx/viewpager/widget/ViewPager_OnAdapterChangeListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnAdapterChanged(ViewPager viewPager, PagerAdapter oldAdapter, PagerAdapter newAdapter)
			{
				Handler?.Invoke(sender, new AdapterChangeEventArgs(viewPager, oldAdapter, newAdapter));
			}

			internal static bool __IsEmpty(IOnAdapterChangeListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("androidx/viewpager/widget/ViewPager$OnPageChangeListener", "", "AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker")]
		public interface IOnPageChangeListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onPageScrollStateChanged", "(I)V", "GetOnPageScrollStateChanged_IHandler:AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker, Xamarin.AndroidX.ViewPager")]
			void OnPageScrollStateChanged(int state);

			[Register("onPageScrolled", "(IFI)V", "GetOnPageScrolled_IFIHandler:AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker, Xamarin.AndroidX.ViewPager")]
			void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels);

			[Register("onPageSelected", "(I)V", "GetOnPageSelected_IHandler:AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker, Xamarin.AndroidX.ViewPager")]
			void OnPageSelected(int position);
		}

		[Register("androidx/viewpager/widget/ViewPager$OnPageChangeListener", DoNotGenerateAcw = true)]
		internal class IOnPageChangeListenerInvoker : Java.Lang.Object, IOnPageChangeListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager/widget/ViewPager$OnPageChangeListener", typeof(IOnPageChangeListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onPageScrollStateChanged_I;

			private IntPtr id_onPageScrollStateChanged_I;

			private static Delegate cb_onPageScrolled_IFI;

			private IntPtr id_onPageScrolled_IFI;

			private static Delegate cb_onPageSelected_I;

			private IntPtr id_onPageSelected_I;

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

			public static IOnPageChangeListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnPageChangeListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.viewpager.widget.ViewPager.OnPageChangeListener'.");
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

			public IOnPageChangeListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnPageScrollStateChanged_IHandler()
			{
				if ((object)cb_onPageScrollStateChanged_I == null)
				{
					cb_onPageScrollStateChanged_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnPageScrollStateChanged_I));
				}
				return cb_onPageScrollStateChanged_I;
			}

			private static void n_OnPageScrollStateChanged_I(IntPtr jnienv, IntPtr native__this, int state)
			{
				Java.Lang.Object.GetObject<IOnPageChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageScrollStateChanged(state);
			}

			public unsafe void OnPageScrollStateChanged(int state)
			{
				if (id_onPageScrollStateChanged_I == IntPtr.Zero)
				{
					id_onPageScrollStateChanged_I = JNIEnv.GetMethodID(class_ref, "onPageScrollStateChanged", "(I)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(state);
				JNIEnv.CallVoidMethod(base.Handle, id_onPageScrollStateChanged_I, ptr);
			}

			private static Delegate GetOnPageScrolled_IFIHandler()
			{
				if ((object)cb_onPageScrolled_IFI == null)
				{
					cb_onPageScrolled_IFI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIFI_V(n_OnPageScrolled_IFI));
				}
				return cb_onPageScrolled_IFI;
			}

			private static void n_OnPageScrolled_IFI(IntPtr jnienv, IntPtr native__this, int position, float positionOffset, int positionOffsetPixels)
			{
				Java.Lang.Object.GetObject<IOnPageChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageScrolled(position, positionOffset, positionOffsetPixels);
			}

			public unsafe void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
			{
				if (id_onPageScrolled_IFI == IntPtr.Zero)
				{
					id_onPageScrolled_IFI = JNIEnv.GetMethodID(class_ref, "onPageScrolled", "(IFI)V");
				}
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(position);
				ptr[1] = new JValue(positionOffset);
				ptr[2] = new JValue(positionOffsetPixels);
				JNIEnv.CallVoidMethod(base.Handle, id_onPageScrolled_IFI, ptr);
			}

			private static Delegate GetOnPageSelected_IHandler()
			{
				if ((object)cb_onPageSelected_I == null)
				{
					cb_onPageSelected_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnPageSelected_I));
				}
				return cb_onPageSelected_I;
			}

			private static void n_OnPageSelected_I(IntPtr jnienv, IntPtr native__this, int position)
			{
				Java.Lang.Object.GetObject<IOnPageChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageSelected(position);
			}

			public unsafe void OnPageSelected(int position)
			{
				if (id_onPageSelected_I == IntPtr.Zero)
				{
					id_onPageSelected_I = JNIEnv.GetMethodID(class_ref, "onPageSelected", "(I)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(position);
				JNIEnv.CallVoidMethod(base.Handle, id_onPageSelected_I, ptr);
			}
		}

		public class PageScrollStateChangedEventArgs : EventArgs
		{
			private int state;

			public PageScrollStateChangedEventArgs(int state)
			{
				this.state = state;
			}
		}

		public class PageScrolledEventArgs : EventArgs
		{
			private int position;

			private float positionOffset;

			private int positionOffsetPixels;

			public int Position => position;

			public PageScrolledEventArgs(int position, float positionOffset, int positionOffsetPixels)
			{
				this.position = position;
				this.positionOffset = positionOffset;
				this.positionOffsetPixels = positionOffsetPixels;
			}
		}

		public class PageSelectedEventArgs : EventArgs
		{
			private int position;

			public int Position => position;

			public PageSelectedEventArgs(int position)
			{
				this.position = position;
			}
		}

		[Register("mono/androidx/viewpager/widget/ViewPager_OnPageChangeListenerImplementor")]
		internal sealed class IOnPageChangeListenerImplementor : Java.Lang.Object, IOnPageChangeListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<PageScrollStateChangedEventArgs> OnPageScrollStateChangedHandler;

			public EventHandler<PageScrolledEventArgs> OnPageScrolledHandler;

			public EventHandler<PageSelectedEventArgs> OnPageSelectedHandler;

			public IOnPageChangeListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/androidx/viewpager/widget/ViewPager_OnPageChangeListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnPageScrollStateChanged(int state)
			{
				OnPageScrollStateChangedHandler?.Invoke(sender, new PageScrollStateChangedEventArgs(state));
			}

			public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
			{
				OnPageScrolledHandler?.Invoke(sender, new PageScrolledEventArgs(position, positionOffset, positionOffsetPixels));
			}

			public void OnPageSelected(int position)
			{
				OnPageSelectedHandler?.Invoke(sender, new PageSelectedEventArgs(position));
			}

			internal static bool __IsEmpty(IOnPageChangeListenerImplementor value)
			{
				if (value.OnPageScrollStateChangedHandler == null && value.OnPageScrolledHandler == null)
				{
					return value.OnPageSelectedHandler == null;
				}
				return false;
			}
		}

		[Register("androidx/viewpager/widget/ViewPager$PageTransformer", "", "AndroidX.ViewPager.Widget.ViewPager/IPageTransformerInvoker")]
		public interface IPageTransformer : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("transformPage", "(Landroid/view/View;F)V", "GetTransformPage_Landroid_view_View_FHandler:AndroidX.ViewPager.Widget.ViewPager/IPageTransformerInvoker, Xamarin.AndroidX.ViewPager")]
			void TransformPage(View page, float position);
		}

		[Register("androidx/viewpager/widget/ViewPager$PageTransformer", DoNotGenerateAcw = true)]
		internal class IPageTransformerInvoker : Java.Lang.Object, IPageTransformer, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager/widget/ViewPager$PageTransformer", typeof(IPageTransformerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_transformPage_Landroid_view_View_F;

			private IntPtr id_transformPage_Landroid_view_View_F;

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

			public static IPageTransformer GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IPageTransformer>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.viewpager.widget.ViewPager.PageTransformer'.");
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

			public IPageTransformerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetTransformPage_Landroid_view_View_FHandler()
			{
				if ((object)cb_transformPage_Landroid_view_View_F == null)
				{
					cb_transformPage_Landroid_view_View_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLF_V(n_TransformPage_Landroid_view_View_F));
				}
				return cb_transformPage_Landroid_view_View_F;
			}

			private static void n_TransformPage_Landroid_view_View_F(IntPtr jnienv, IntPtr native__this, IntPtr native_page, float position)
			{
				IPageTransformer pageTransformer = Java.Lang.Object.GetObject<IPageTransformer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View page = Java.Lang.Object.GetObject<View>(native_page, JniHandleOwnership.DoNotTransfer);
				pageTransformer.TransformPage(page, position);
			}

			public unsafe void TransformPage(View page, float position)
			{
				if (id_transformPage_Landroid_view_View_F == IntPtr.Zero)
				{
					id_transformPage_Landroid_view_View_F = JNIEnv.GetMethodID(class_ref, "transformPage", "(Landroid/view/View;F)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(page?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(position);
				JNIEnv.CallVoidMethod(base.Handle, id_transformPage_Landroid_view_View_F, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager/widget/ViewPager", typeof(ViewPager));

		private static Delegate cb_getAdapter;

		private static Delegate cb_setAdapter_Landroidx_viewpager_widget_PagerAdapter_;

		private static Delegate cb_getCurrentItem;

		private static Delegate cb_setCurrentItem_I;

		private static Delegate cb_isFakeDragging;

		private static Delegate cb_getOffscreenPageLimit;

		private static Delegate cb_setOffscreenPageLimit_I;

		private static Delegate cb_getPageMargin;

		private static Delegate cb_setPageMargin_I;

		private static Delegate cb_addFocusables_Ljava_util_ArrayList_II;

		private static Delegate cb_addOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_;

		private static Delegate cb_addOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_;

		private static Delegate cb_addTouchables_Ljava_util_ArrayList_;

		private static Delegate cb_arrowScroll_I;

		private static Delegate cb_beginFakeDrag;

		private static Delegate cb_canScroll_Landroid_view_View_ZIII;

		private static Delegate cb_clearOnPageChangeListeners;

		private static Delegate cb_endFakeDrag;

		private static Delegate cb_executeKeyEvent_Landroid_view_KeyEvent_;

		private static Delegate cb_fakeDragBy_F;

		private static Delegate cb_onLayout_ZIIII;

		private static Delegate cb_onPageScrolled_IFI;

		private static Delegate cb_onRestoreInstanceState_Landroid_os_Parcelable_;

		private static Delegate cb_onSaveInstanceState;

		private static Delegate cb_removeOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_;

		private static Delegate cb_removeOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_;

		private static Delegate cb_setCurrentItem_IZ;

		private static Delegate cb_setOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_;

		private static Delegate cb_setPageMarginDrawable_Landroid_graphics_drawable_Drawable_;

		private static Delegate cb_setPageMarginDrawable_I;

		private static Delegate cb_setPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_;

		private static Delegate cb_setPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_I;

		private WeakReference weak_implementor_AddOnAdapterChangeListener;

		private WeakReference weak_implementor_AddOnPageChangeListener;

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

		public unsafe virtual PagerAdapter Adapter
		{
			[Register("getAdapter", "()Landroidx/viewpager/widget/PagerAdapter;", "GetGetAdapterHandler")]
			get
			{
				return Java.Lang.Object.GetObject<PagerAdapter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAdapter.()Landroidx/viewpager/widget/PagerAdapter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setAdapter", "(Landroidx/viewpager/widget/PagerAdapter;)V", "GetSetAdapter_Landroidx_viewpager_widget_PagerAdapter_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setAdapter.(Landroidx/viewpager/widget/PagerAdapter;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual int CurrentItem
		{
			[Register("getCurrentItem", "()I", "GetGetCurrentItemHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getCurrentItem.()I", this, null);
			}
			[Register("setCurrentItem", "(I)V", "GetSetCurrentItem_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCurrentItem.(I)V", this, ptr);
			}
		}

		public unsafe virtual bool IsFakeDragging
		{
			[Register("isFakeDragging", "()Z", "GetIsFakeDraggingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFakeDragging.()Z", this, null);
			}
		}

		public unsafe virtual int OffscreenPageLimit
		{
			[Register("getOffscreenPageLimit", "()I", "GetGetOffscreenPageLimitHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getOffscreenPageLimit.()I", this, null);
			}
			[Register("setOffscreenPageLimit", "(I)V", "GetSetOffscreenPageLimit_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOffscreenPageLimit.(I)V", this, ptr);
			}
		}

		public unsafe virtual int PageMargin
		{
			[Register("getPageMargin", "()I", "GetGetPageMarginHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPageMargin.()I", this, null);
			}
			[Register("setPageMargin", "(I)V", "GetSetPageMargin_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPageMargin.(I)V", this, ptr);
			}
		}

		public event EventHandler<AdapterChangeEventArgs> AdapterChange
		{
			add
			{
				EventHelper.AddEventHandler<IOnAdapterChangeListener, IOnAdapterChangeListenerImplementor>(ref weak_implementor_AddOnAdapterChangeListener, __CreateIOnAdapterChangeListenerImplementor, AddOnAdapterChangeListener, delegate(IOnAdapterChangeListenerImplementor __h)
				{
					__h.Handler = (EventHandler<AdapterChangeEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler(ref weak_implementor_AddOnAdapterChangeListener, IOnAdapterChangeListenerImplementor.__IsEmpty, delegate(IOnAdapterChangeListener __v)
				{
					RemoveOnAdapterChangeListener(__v);
				}, delegate(IOnAdapterChangeListenerImplementor __h)
				{
					__h.Handler = (EventHandler<AdapterChangeEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<PageScrollStateChangedEventArgs> PageScrollStateChanged
		{
			add
			{
				EventHelper.AddEventHandler<IOnPageChangeListener, IOnPageChangeListenerImplementor>(ref weak_implementor_AddOnPageChangeListener, __CreateIOnPageChangeListenerImplementor, AddOnPageChangeListener, delegate(IOnPageChangeListenerImplementor __h)
				{
					__h.OnPageScrollStateChangedHandler = (EventHandler<PageScrollStateChangedEventArgs>)Delegate.Combine(__h.OnPageScrollStateChangedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler(ref weak_implementor_AddOnPageChangeListener, IOnPageChangeListenerImplementor.__IsEmpty, delegate(IOnPageChangeListener __v)
				{
					RemoveOnPageChangeListener(__v);
				}, delegate(IOnPageChangeListenerImplementor __h)
				{
					__h.OnPageScrollStateChangedHandler = (EventHandler<PageScrollStateChangedEventArgs>)Delegate.Remove(__h.OnPageScrollStateChangedHandler, value);
				});
			}
		}

		public event EventHandler<PageScrolledEventArgs> PageScrolled
		{
			add
			{
				EventHelper.AddEventHandler<IOnPageChangeListener, IOnPageChangeListenerImplementor>(ref weak_implementor_AddOnPageChangeListener, __CreateIOnPageChangeListenerImplementor, AddOnPageChangeListener, delegate(IOnPageChangeListenerImplementor __h)
				{
					__h.OnPageScrolledHandler = (EventHandler<PageScrolledEventArgs>)Delegate.Combine(__h.OnPageScrolledHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler(ref weak_implementor_AddOnPageChangeListener, IOnPageChangeListenerImplementor.__IsEmpty, delegate(IOnPageChangeListener __v)
				{
					RemoveOnPageChangeListener(__v);
				}, delegate(IOnPageChangeListenerImplementor __h)
				{
					__h.OnPageScrolledHandler = (EventHandler<PageScrolledEventArgs>)Delegate.Remove(__h.OnPageScrolledHandler, value);
				});
			}
		}

		public event EventHandler<PageSelectedEventArgs> PageSelected
		{
			add
			{
				EventHelper.AddEventHandler<IOnPageChangeListener, IOnPageChangeListenerImplementor>(ref weak_implementor_AddOnPageChangeListener, __CreateIOnPageChangeListenerImplementor, AddOnPageChangeListener, delegate(IOnPageChangeListenerImplementor __h)
				{
					__h.OnPageSelectedHandler = (EventHandler<PageSelectedEventArgs>)Delegate.Combine(__h.OnPageSelectedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler(ref weak_implementor_AddOnPageChangeListener, IOnPageChangeListenerImplementor.__IsEmpty, delegate(IOnPageChangeListener __v)
				{
					RemoveOnPageChangeListener(__v);
				}, delegate(IOnPageChangeListenerImplementor __h)
				{
					__h.OnPageSelectedHandler = (EventHandler<PageSelectedEventArgs>)Delegate.Remove(__h.OnPageSelectedHandler, value);
				});
			}
		}

		protected ViewPager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe ViewPager(Context context)
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
		public unsafe ViewPager(Context context, IAttributeSet attrs)
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

		private static Delegate GetGetAdapterHandler()
		{
			if ((object)cb_getAdapter == null)
			{
				cb_getAdapter = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAdapter));
			}
			return cb_getAdapter;
		}

		private static IntPtr n_GetAdapter(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Adapter);
		}

		private static Delegate GetSetAdapter_Landroidx_viewpager_widget_PagerAdapter_Handler()
		{
			if ((object)cb_setAdapter_Landroidx_viewpager_widget_PagerAdapter_ == null)
			{
				cb_setAdapter_Landroidx_viewpager_widget_PagerAdapter_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetAdapter_Landroidx_viewpager_widget_PagerAdapter_));
			}
			return cb_setAdapter_Landroidx_viewpager_widget_PagerAdapter_;
		}

		private static void n_SetAdapter_Landroidx_viewpager_widget_PagerAdapter_(IntPtr jnienv, IntPtr native__this, IntPtr native_adapter)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PagerAdapter adapter = Java.Lang.Object.GetObject<PagerAdapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
			viewPager.Adapter = adapter;
		}

		private static Delegate GetGetCurrentItemHandler()
		{
			if ((object)cb_getCurrentItem == null)
			{
				cb_getCurrentItem = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCurrentItem));
			}
			return cb_getCurrentItem;
		}

		private static int n_GetCurrentItem(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentItem;
		}

		private static Delegate GetSetCurrentItem_IHandler()
		{
			if ((object)cb_setCurrentItem_I == null)
			{
				cb_setCurrentItem_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetCurrentItem_I));
			}
			return cb_setCurrentItem_I;
		}

		private static void n_SetCurrentItem_I(IntPtr jnienv, IntPtr native__this, int item)
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentItem = item;
		}

		private static Delegate GetIsFakeDraggingHandler()
		{
			if ((object)cb_isFakeDragging == null)
			{
				cb_isFakeDragging = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsFakeDragging));
			}
			return cb_isFakeDragging;
		}

		private static bool n_IsFakeDragging(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFakeDragging;
		}

		private static Delegate GetGetOffscreenPageLimitHandler()
		{
			if ((object)cb_getOffscreenPageLimit == null)
			{
				cb_getOffscreenPageLimit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOffscreenPageLimit));
			}
			return cb_getOffscreenPageLimit;
		}

		private static int n_GetOffscreenPageLimit(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffscreenPageLimit;
		}

		private static Delegate GetSetOffscreenPageLimit_IHandler()
		{
			if ((object)cb_setOffscreenPageLimit_I == null)
			{
				cb_setOffscreenPageLimit_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetOffscreenPageLimit_I));
			}
			return cb_setOffscreenPageLimit_I;
		}

		private static void n_SetOffscreenPageLimit_I(IntPtr jnienv, IntPtr native__this, int limit)
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffscreenPageLimit = limit;
		}

		private static Delegate GetGetPageMarginHandler()
		{
			if ((object)cb_getPageMargin == null)
			{
				cb_getPageMargin = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPageMargin));
			}
			return cb_getPageMargin;
		}

		private static int n_GetPageMargin(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PageMargin;
		}

		private static Delegate GetSetPageMargin_IHandler()
		{
			if ((object)cb_setPageMargin_I == null)
			{
				cb_setPageMargin_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetPageMargin_I));
			}
			return cb_setPageMargin_I;
		}

		private static void n_SetPageMargin_I(IntPtr jnienv, IntPtr native__this, int marginPixels)
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PageMargin = marginPixels;
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
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
			viewPager.AddFocusables(views, direction, focusableMode);
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

		private static Delegate GetAddOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_Handler()
		{
			if ((object)cb_addOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_ == null)
			{
				cb_addOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_));
			}
			return cb_addOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_;
		}

		private static void n_AddOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnAdapterChangeListener listener = Java.Lang.Object.GetObject<IOnAdapterChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			viewPager.AddOnAdapterChangeListener(listener);
		}

		[Register("addOnAdapterChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnAdapterChangeListener;)V", "GetAddOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_Handler")]
		public unsafe virtual void AddOnAdapterChangeListener(IOnAdapterChangeListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addOnAdapterChangeListener.(Landroidx/viewpager/widget/ViewPager$OnAdapterChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetAddOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler()
		{
			if ((object)cb_addOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_ == null)
			{
				cb_addOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_));
			}
			return cb_addOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_;
		}

		private static void n_AddOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnPageChangeListener listener = Java.Lang.Object.GetObject<IOnPageChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			viewPager.AddOnPageChangeListener(listener);
		}

		[Register("addOnPageChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", "GetAddOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler")]
		public unsafe virtual void AddOnPageChangeListener(IOnPageChangeListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addOnPageChangeListener.(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetAddTouchables_Ljava_util_ArrayList_Handler()
		{
			if ((object)cb_addTouchables_Ljava_util_ArrayList_ == null)
			{
				cb_addTouchables_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddTouchables_Ljava_util_ArrayList_));
			}
			return cb_addTouchables_Ljava_util_ArrayList_;
		}

		private static void n_AddTouchables_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_views)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
			viewPager.AddTouchables(views);
		}

		[Register("addTouchables", "(Ljava/util/ArrayList;)V", "GetAddTouchables_Ljava_util_ArrayList_Handler")]
		public new unsafe virtual void AddTouchables(IList<View> views)
		{
			IntPtr intPtr = JavaList<View>.ToLocalJniHandle(views);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addTouchables.(Ljava/util/ArrayList;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(views);
			}
		}

		private static Delegate GetArrowScroll_IHandler()
		{
			if ((object)cb_arrowScroll_I == null)
			{
				cb_arrowScroll_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_ArrowScroll_I));
			}
			return cb_arrowScroll_I;
		}

		private static bool n_ArrowScroll_I(IntPtr jnienv, IntPtr native__this, int direction)
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArrowScroll(direction);
		}

		[Register("arrowScroll", "(I)Z", "GetArrowScroll_IHandler")]
		public unsafe virtual bool ArrowScroll(int direction)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(direction);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("arrowScroll.(I)Z", this, ptr);
		}

		private static Delegate GetBeginFakeDragHandler()
		{
			if ((object)cb_beginFakeDrag == null)
			{
				cb_beginFakeDrag = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_BeginFakeDrag));
			}
			return cb_beginFakeDrag;
		}

		private static bool n_BeginFakeDrag(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BeginFakeDrag();
		}

		[Register("beginFakeDrag", "()Z", "GetBeginFakeDragHandler")]
		public unsafe virtual bool BeginFakeDrag()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("beginFakeDrag.()Z", this, null);
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
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
			return viewPager.CanScroll(v, checkV, dx, x, y);
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

		private static Delegate GetClearOnPageChangeListenersHandler()
		{
			if ((object)cb_clearOnPageChangeListeners == null)
			{
				cb_clearOnPageChangeListeners = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearOnPageChangeListeners));
			}
			return cb_clearOnPageChangeListeners;
		}

		private static void n_ClearOnPageChangeListeners(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnPageChangeListeners();
		}

		[Register("clearOnPageChangeListeners", "()V", "GetClearOnPageChangeListenersHandler")]
		public unsafe virtual void ClearOnPageChangeListeners()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnPageChangeListeners.()V", this, null);
		}

		private static Delegate GetEndFakeDragHandler()
		{
			if ((object)cb_endFakeDrag == null)
			{
				cb_endFakeDrag = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_EndFakeDrag));
			}
			return cb_endFakeDrag;
		}

		private static void n_EndFakeDrag(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndFakeDrag();
		}

		[Register("endFakeDrag", "()V", "GetEndFakeDragHandler")]
		public unsafe virtual void EndFakeDrag()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("endFakeDrag.()V", this, null);
		}

		private static Delegate GetExecuteKeyEvent_Landroid_view_KeyEvent_Handler()
		{
			if ((object)cb_executeKeyEvent_Landroid_view_KeyEvent_ == null)
			{
				cb_executeKeyEvent_Landroid_view_KeyEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ExecuteKeyEvent_Landroid_view_KeyEvent_));
			}
			return cb_executeKeyEvent_Landroid_view_KeyEvent_;
		}

		private static bool n_ExecuteKeyEvent_Landroid_view_KeyEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_e)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return viewPager.ExecuteKeyEvent(e);
		}

		[Register("executeKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetExecuteKeyEvent_Landroid_view_KeyEvent_Handler")]
		public unsafe virtual bool ExecuteKeyEvent(KeyEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("executeKeyEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetFakeDragBy_FHandler()
		{
			if ((object)cb_fakeDragBy_F == null)
			{
				cb_fakeDragBy_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_FakeDragBy_F));
			}
			return cb_fakeDragBy_F;
		}

		private static void n_FakeDragBy_F(IntPtr jnienv, IntPtr native__this, float xOffset)
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FakeDragBy(xOffset);
		}

		[Register("fakeDragBy", "(F)V", "GetFakeDragBy_FHandler")]
		public unsafe virtual void FakeDragBy(float xOffset)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(xOffset);
			_members.InstanceMethods.InvokeVirtualVoidMethod("fakeDragBy.(F)V", this, ptr);
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
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayout(changed, l, t, r, b);
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

		private static Delegate GetOnPageScrolled_IFIHandler()
		{
			if ((object)cb_onPageScrolled_IFI == null)
			{
				cb_onPageScrolled_IFI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIFI_V(n_OnPageScrolled_IFI));
			}
			return cb_onPageScrolled_IFI;
		}

		private static void n_OnPageScrolled_IFI(IntPtr jnienv, IntPtr native__this, int position, float offset, int offsetPixels)
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageScrolled(position, offset, offsetPixels);
		}

		[Register("onPageScrolled", "(IFI)V", "GetOnPageScrolled_IFIHandler")]
		protected unsafe virtual void OnPageScrolled(int position, float offset, int offsetPixels)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(offset);
			ptr[2] = new JniArgumentValue(offsetPixels);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPageScrolled.(IFI)V", this, ptr);
		}

		private static Delegate GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler()
		{
			if ((object)cb_onRestoreInstanceState_Landroid_os_Parcelable_ == null)
			{
				cb_onRestoreInstanceState_Landroid_os_Parcelable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnRestoreInstanceState_Landroid_os_Parcelable_));
			}
			return cb_onRestoreInstanceState_Landroid_os_Parcelable_;
		}

		private static void n_OnRestoreInstanceState_Landroid_os_Parcelable_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			viewPager.OnRestoreInstanceState(state);
		}

		[Register("onRestoreInstanceState", "(Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler")]
		public new unsafe virtual void OnRestoreInstanceState(IParcelable state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onRestoreInstanceState.(Landroid/os/Parcelable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnSaveInstanceStateHandler()
		{
			if ((object)cb_onSaveInstanceState == null)
			{
				cb_onSaveInstanceState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_OnSaveInstanceState));
			}
			return cb_onSaveInstanceState;
		}

		private static IntPtr n_OnSaveInstanceState(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
		}

		[Register("onSaveInstanceState", "()Landroid/os/Parcelable;", "GetOnSaveInstanceStateHandler")]
		public new unsafe virtual IParcelable OnSaveInstanceState()
		{
			return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRemoveOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_Handler()
		{
			if ((object)cb_removeOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_ == null)
			{
				cb_removeOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_));
			}
			return cb_removeOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_;
		}

		private static void n_RemoveOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnAdapterChangeListener listener = Java.Lang.Object.GetObject<IOnAdapterChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			viewPager.RemoveOnAdapterChangeListener(listener);
		}

		[Register("removeOnAdapterChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnAdapterChangeListener;)V", "GetRemoveOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_Handler")]
		public unsafe virtual void RemoveOnAdapterChangeListener(IOnAdapterChangeListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnAdapterChangeListener.(Landroidx/viewpager/widget/ViewPager$OnAdapterChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetRemoveOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler()
		{
			if ((object)cb_removeOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_ == null)
			{
				cb_removeOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_));
			}
			return cb_removeOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_;
		}

		private static void n_RemoveOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnPageChangeListener listener = Java.Lang.Object.GetObject<IOnPageChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			viewPager.RemoveOnPageChangeListener(listener);
		}

		[Register("removeOnPageChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", "GetRemoveOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler")]
		public unsafe virtual void RemoveOnPageChangeListener(IOnPageChangeListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnPageChangeListener.(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetCurrentItem_IZHandler()
		{
			if ((object)cb_setCurrentItem_IZ == null)
			{
				cb_setCurrentItem_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIZ_V(n_SetCurrentItem_IZ));
			}
			return cb_setCurrentItem_IZ;
		}

		private static void n_SetCurrentItem_IZ(IntPtr jnienv, IntPtr native__this, int item, bool smoothScroll)
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCurrentItem(item, smoothScroll);
		}

		[Register("setCurrentItem", "(IZ)V", "GetSetCurrentItem_IZHandler")]
		public unsafe virtual void SetCurrentItem(int item, bool smoothScroll)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(item);
			ptr[1] = new JniArgumentValue(smoothScroll);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCurrentItem.(IZ)V", this, ptr);
		}

		private static Delegate GetSetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler()
		{
			if ((object)cb_setOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_ == null)
			{
				cb_setOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_));
			}
			return cb_setOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_;
		}

		private static void n_SetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnPageChangeListener onPageChangeListener = Java.Lang.Object.GetObject<IOnPageChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			viewPager.SetOnPageChangeListener(onPageChangeListener);
		}

		[Register("setOnPageChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", "GetSetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler")]
		public unsafe virtual void SetOnPageChangeListener(IOnPageChangeListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnPageChangeListener.(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetPageMarginDrawable_Landroid_graphics_drawable_Drawable_Handler()
		{
			if ((object)cb_setPageMarginDrawable_Landroid_graphics_drawable_Drawable_ == null)
			{
				cb_setPageMarginDrawable_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPageMarginDrawable_Landroid_graphics_drawable_Drawable_));
			}
			return cb_setPageMarginDrawable_Landroid_graphics_drawable_Drawable_;
		}

		private static void n_SetPageMarginDrawable_Landroid_graphics_drawable_Drawable_(IntPtr jnienv, IntPtr native__this, IntPtr native_d)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable pageMarginDrawable = Java.Lang.Object.GetObject<Drawable>(native_d, JniHandleOwnership.DoNotTransfer);
			viewPager.SetPageMarginDrawable(pageMarginDrawable);
		}

		[Register("setPageMarginDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetPageMarginDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe virtual void SetPageMarginDrawable(Drawable d)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPageMarginDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(d);
			}
		}

		private static Delegate GetSetPageMarginDrawable_IHandler()
		{
			if ((object)cb_setPageMarginDrawable_I == null)
			{
				cb_setPageMarginDrawable_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetPageMarginDrawable_I));
			}
			return cb_setPageMarginDrawable_I;
		}

		private static void n_SetPageMarginDrawable_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPageMarginDrawable(resId);
		}

		[Register("setPageMarginDrawable", "(I)V", "GetSetPageMarginDrawable_IHandler")]
		public unsafe virtual void SetPageMarginDrawable(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPageMarginDrawable.(I)V", this, ptr);
		}

		private static Delegate GetSetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_Handler()
		{
			if ((object)cb_setPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_ == null)
			{
				cb_setPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZL_V(n_SetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_));
			}
			return cb_setPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_;
		}

		private static void n_SetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_(IntPtr jnienv, IntPtr native__this, bool reverseDrawingOrder, IntPtr native_transformer)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IPageTransformer transformer = Java.Lang.Object.GetObject<IPageTransformer>(native_transformer, JniHandleOwnership.DoNotTransfer);
			viewPager.SetPageTransformer(reverseDrawingOrder, transformer);
		}

		[Register("setPageTransformer", "(ZLandroidx/viewpager/widget/ViewPager$PageTransformer;)V", "GetSetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_Handler")]
		public unsafe virtual void SetPageTransformer(bool reverseDrawingOrder, IPageTransformer transformer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(reverseDrawingOrder);
				ptr[1] = new JniArgumentValue((transformer == null) ? IntPtr.Zero : ((Java.Lang.Object)transformer).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPageTransformer.(ZLandroidx/viewpager/widget/ViewPager$PageTransformer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transformer);
			}
		}

		private static Delegate GetSetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_IHandler()
		{
			if ((object)cb_setPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_I == null)
			{
				cb_setPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZLI_V(n_SetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_I));
			}
			return cb_setPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_I;
		}

		private static void n_SetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_I(IntPtr jnienv, IntPtr native__this, bool reverseDrawingOrder, IntPtr native_transformer, int pageLayerType)
		{
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IPageTransformer transformer = Java.Lang.Object.GetObject<IPageTransformer>(native_transformer, JniHandleOwnership.DoNotTransfer);
			viewPager.SetPageTransformer(reverseDrawingOrder, transformer, pageLayerType);
		}

		[Register("setPageTransformer", "(ZLandroidx/viewpager/widget/ViewPager$PageTransformer;I)V", "GetSetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_IHandler")]
		public unsafe virtual void SetPageTransformer(bool reverseDrawingOrder, IPageTransformer transformer, int pageLayerType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(reverseDrawingOrder);
				ptr[1] = new JniArgumentValue((transformer == null) ? IntPtr.Zero : ((Java.Lang.Object)transformer).Handle);
				ptr[2] = new JniArgumentValue(pageLayerType);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPageTransformer.(ZLandroidx/viewpager/widget/ViewPager$PageTransformer;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transformer);
			}
		}

		private IOnAdapterChangeListenerImplementor __CreateIOnAdapterChangeListenerImplementor()
		{
			return new IOnAdapterChangeListenerImplementor(this);
		}

		private IOnPageChangeListenerImplementor __CreateIOnPageChangeListenerImplementor()
		{
			return new IOnPageChangeListenerImplementor(this);
		}
	}
}
