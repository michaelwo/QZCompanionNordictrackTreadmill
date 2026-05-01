using System;
using System.Collections.Generic;
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
using Android.Views.Accessibility;
using Android.Views.Animations;
using Android.Widget;
using AndroidX.Core.View;
using AndroidX.Core.View.Accessibility;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "a0b083e48e5cb48b5f74f95cbf4e400692849c0e")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20210223.1")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "2/23/2021 6:09:48 AM")]
[assembly: LinkerSafe]
[assembly: NamespaceMapping(Java = "androidx.recyclerview.widget", Managed = "AndroidX.RecyclerView.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - recyclerview")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.RecyclerView")]
[assembly: AssemblyTitle("Xamarin.AndroidX.RecyclerView")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate float _JniMarshal_PPF_F(IntPtr jnienv, IntPtr klass, float p0);
internal delegate IntPtr _JniMarshal_PPFF_L(IntPtr jnienv, IntPtr klass, float p0, float p1);
internal delegate int _JniMarshal_PPI_I(IntPtr jnienv, IntPtr klass, int p0);
internal delegate long _JniMarshal_PPI_J(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate bool _JniMarshal_PPI_Z(IntPtr jnienv, IntPtr klass, int p0);
internal delegate int _JniMarshal_PPII_I(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate void _JniMarshal_PPII_V(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate bool _JniMarshal_PPII_Z(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate void _JniMarshal_PPIII_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2);
internal delegate bool _JniMarshal_PPIIIILI_Z(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3, IntPtr p4, int p5);
internal delegate void _JniMarshal_PPIIIL_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, IntPtr p3);
internal delegate void _JniMarshal_PPIIL_V(IntPtr jnienv, IntPtr klass, int p0, int p1, IntPtr p2);
internal delegate void _JniMarshal_PPIILI_V(IntPtr jnienv, IntPtr klass, int p0, int p1, IntPtr p2, int p3);
internal delegate void _JniMarshal_PPIILL_V(IntPtr jnienv, IntPtr klass, int p0, int p1, IntPtr p2, IntPtr p3);
internal delegate bool _JniMarshal_PPIILLI_Z(IntPtr jnienv, IntPtr klass, int p0, int p1, IntPtr p2, IntPtr p3, int p4);
internal delegate void _JniMarshal_PPIL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate int _JniMarshal_PPILL_I(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPJ_L(IntPtr jnienv, IntPtr klass, long p0);
internal delegate void _JniMarshal_PPJ_V(IntPtr jnienv, IntPtr klass, long p0);
internal delegate float _JniMarshal_PPL_F(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate long _JniMarshal_PPL_J(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate long _JniMarshal_PPLIFF_J(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, float p2, float p3);
internal delegate IntPtr _JniMarshal_PPLII_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate void _JniMarshal_PPLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate void _JniMarshal_PPLIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3);
internal delegate void _JniMarshal_PPLIIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, int p4);
internal delegate int _JniMarshal_PPLIIIJ_I(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, long p4);
internal delegate void _JniMarshal_PPLIIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, IntPtr p3);
internal delegate void _JniMarshal_PPLIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPLILL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2, IntPtr p3);
internal delegate int _JniMarshal_PPLL_I(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate bool _JniMarshal_PPLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2);
internal delegate IntPtr _JniMarshal_PPLLII_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate void _JniMarshal_PPLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate bool _JniMarshal_PPLLII_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate IntPtr _JniMarshal_PPLLIL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, IntPtr p3);
internal delegate bool _JniMarshal_PPLLIL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, IntPtr p3);
internal delegate void _JniMarshal_PPLLILIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, IntPtr p3, int p4, int p5, int p6);
internal delegate bool _JniMarshal_PPLLJ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, long p2);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate bool _JniMarshal_PPLLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLLFFIZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, float p3, float p4, int p5, bool p6);
internal delegate bool _JniMarshal_PPLLLIL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3, IntPtr p4);
internal delegate void _JniMarshal_PPLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate bool _JniMarshal_PPLLLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate bool _JniMarshal_PPLLLZ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, bool p3);
internal delegate bool _JniMarshal_PPLLLZZ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, bool p3, bool p4);
internal delegate void _JniMarshal_PPLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate void _JniMarshal_PPLZL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1, IntPtr p2);
internal delegate bool _JniMarshal_PPLZZ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1, bool p2);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
internal delegate void _JniMarshal_PPZIIII_V(IntPtr jnienv, IntPtr klass, bool p0, int p1, int p2, int p3, int p4);
namespace AndroidX.RecyclerView.Widget;

[Register("androidx/recyclerview/widget/DividerItemDecoration", DoNotGenerateAcw = true)]
public class DividerItemDecoration : RecyclerView.ItemDecoration
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/DividerItemDecoration", typeof(DividerItemDecoration));

	private static Delegate cb_getDrawable;

	private static Delegate cb_setDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate cb_setOrientation_I;

	internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual Drawable Drawable
	{
		[Register("getDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected DividerItemDecoration(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;I)V", "")]
	public unsafe DividerItemDecoration(Context context, int orientation)
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
			ptr[1] = new JniArgumentValue(orientation);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetDrawableHandler()
	{
		if ((object)cb_getDrawable == null)
		{
			cb_getDrawable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDrawable));
		}
		return cb_getDrawable;
	}

	private static IntPtr n_GetDrawable(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DividerItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Drawable);
	}

	private static Delegate GetSetDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		if ((object)cb_setDrawable_Landroid_graphics_drawable_Drawable_ == null)
		{
			cb_setDrawable_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDrawable_Landroid_graphics_drawable_Drawable_));
		}
		return cb_setDrawable_Landroid_graphics_drawable_Drawable_;
	}

	private static void n_SetDrawable_Landroid_graphics_drawable_Drawable_(IntPtr jnienv, IntPtr native__this, IntPtr native_drawable)
	{
		DividerItemDecoration dividerItemDecoration = Java.Lang.Object.GetObject<DividerItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Drawable drawable = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
		dividerItemDecoration.Drawable = drawable;
	}

	private static Delegate GetSetOrientation_IHandler()
	{
		if ((object)cb_setOrientation_I == null)
		{
			cb_setOrientation_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetOrientation_I));
		}
		return cb_setOrientation_I;
	}

	private static void n_SetOrientation_I(IntPtr jnienv, IntPtr native__this, int orientation)
	{
		Java.Lang.Object.GetObject<DividerItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOrientation(orientation);
	}

	[Register("setOrientation", "(I)V", "GetSetOrientation_IHandler")]
	public unsafe virtual void SetOrientation(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOrientation.(I)V", this, ptr);
	}
}
[Register("androidx/recyclerview/widget/GridLayoutManager", DoNotGenerateAcw = true)]
public class GridLayoutManager : LinearLayoutManager
{
	[Register("androidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup", DoNotGenerateAcw = true)]
	public abstract class SpanSizeLookup : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup", typeof(SpanSizeLookup));

		private static Delegate cb_isSpanGroupIndexCacheEnabled;

		private static Delegate cb_setSpanGroupIndexCacheEnabled_Z;

		private static Delegate cb_isSpanIndexCacheEnabled;

		private static Delegate cb_setSpanIndexCacheEnabled_Z;

		private static Delegate cb_getSpanGroupIndex_II;

		private static Delegate cb_getSpanIndex_II;

		private static Delegate cb_getSpanSize_I;

		private static Delegate cb_invalidateSpanGroupIndexCache;

		private static Delegate cb_invalidateSpanIndexCache;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool SpanGroupIndexCacheEnabled
		{
			[Register("isSpanGroupIndexCacheEnabled", "()Z", "GetIsSpanGroupIndexCacheEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSpanGroupIndexCacheEnabled.()Z", this, null);
			}
			[Register("setSpanGroupIndexCacheEnabled", "(Z)V", "GetSetSpanGroupIndexCacheEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSpanGroupIndexCacheEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual bool SpanIndexCacheEnabled
		{
			[Register("isSpanIndexCacheEnabled", "()Z", "GetIsSpanIndexCacheEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSpanIndexCacheEnabled.()Z", this, null);
			}
			[Register("setSpanIndexCacheEnabled", "(Z)V", "GetSetSpanIndexCacheEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSpanIndexCacheEnabled.(Z)V", this, ptr);
			}
		}

		protected SpanSizeLookup(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SpanSizeLookup()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsSpanGroupIndexCacheEnabledHandler()
		{
			if ((object)cb_isSpanGroupIndexCacheEnabled == null)
			{
				cb_isSpanGroupIndexCacheEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSpanGroupIndexCacheEnabled));
			}
			return cb_isSpanGroupIndexCacheEnabled;
		}

		private static bool n_IsSpanGroupIndexCacheEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpanGroupIndexCacheEnabled;
		}

		private static Delegate GetSetSpanGroupIndexCacheEnabled_ZHandler()
		{
			if ((object)cb_setSpanGroupIndexCacheEnabled_Z == null)
			{
				cb_setSpanGroupIndexCacheEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetSpanGroupIndexCacheEnabled_Z));
			}
			return cb_setSpanGroupIndexCacheEnabled_Z;
		}

		private static void n_SetSpanGroupIndexCacheEnabled_Z(IntPtr jnienv, IntPtr native__this, bool cacheSpanGroupIndices)
		{
			Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpanGroupIndexCacheEnabled = cacheSpanGroupIndices;
		}

		private static Delegate GetIsSpanIndexCacheEnabledHandler()
		{
			if ((object)cb_isSpanIndexCacheEnabled == null)
			{
				cb_isSpanIndexCacheEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSpanIndexCacheEnabled));
			}
			return cb_isSpanIndexCacheEnabled;
		}

		private static bool n_IsSpanIndexCacheEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpanIndexCacheEnabled;
		}

		private static Delegate GetSetSpanIndexCacheEnabled_ZHandler()
		{
			if ((object)cb_setSpanIndexCacheEnabled_Z == null)
			{
				cb_setSpanIndexCacheEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetSpanIndexCacheEnabled_Z));
			}
			return cb_setSpanIndexCacheEnabled_Z;
		}

		private static void n_SetSpanIndexCacheEnabled_Z(IntPtr jnienv, IntPtr native__this, bool cacheSpanIndices)
		{
			Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpanIndexCacheEnabled = cacheSpanIndices;
		}

		private static Delegate GetGetSpanGroupIndex_IIHandler()
		{
			if ((object)cb_getSpanGroupIndex_II == null)
			{
				cb_getSpanGroupIndex_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_I(n_GetSpanGroupIndex_II));
			}
			return cb_getSpanGroupIndex_II;
		}

		private static int n_GetSpanGroupIndex_II(IntPtr jnienv, IntPtr native__this, int adapterPosition, int spanCount)
		{
			return Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSpanGroupIndex(adapterPosition, spanCount);
		}

		[Register("getSpanGroupIndex", "(II)I", "GetGetSpanGroupIndex_IIHandler")]
		public unsafe virtual int GetSpanGroupIndex(int adapterPosition, int spanCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(adapterPosition);
			ptr[1] = new JniArgumentValue(spanCount);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanGroupIndex.(II)I", this, ptr);
		}

		private static Delegate GetGetSpanIndex_IIHandler()
		{
			if ((object)cb_getSpanIndex_II == null)
			{
				cb_getSpanIndex_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_I(n_GetSpanIndex_II));
			}
			return cb_getSpanIndex_II;
		}

		private static int n_GetSpanIndex_II(IntPtr jnienv, IntPtr native__this, int position, int spanCount)
		{
			return Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSpanIndex(position, spanCount);
		}

		[Register("getSpanIndex", "(II)I", "GetGetSpanIndex_IIHandler")]
		public unsafe virtual int GetSpanIndex(int position, int spanCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(spanCount);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanIndex.(II)I", this, ptr);
		}

		private static Delegate GetGetSpanSize_IHandler()
		{
			if ((object)cb_getSpanSize_I == null)
			{
				cb_getSpanSize_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetSpanSize_I));
			}
			return cb_getSpanSize_I;
		}

		private static int n_GetSpanSize_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			return Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSpanSize(position);
		}

		[Register("getSpanSize", "(I)I", "GetGetSpanSize_IHandler")]
		public abstract int GetSpanSize(int position);

		private static Delegate GetInvalidateSpanGroupIndexCacheHandler()
		{
			if ((object)cb_invalidateSpanGroupIndexCache == null)
			{
				cb_invalidateSpanGroupIndexCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_InvalidateSpanGroupIndexCache));
			}
			return cb_invalidateSpanGroupIndexCache;
		}

		private static void n_InvalidateSpanGroupIndexCache(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateSpanGroupIndexCache();
		}

		[Register("invalidateSpanGroupIndexCache", "()V", "GetInvalidateSpanGroupIndexCacheHandler")]
		public unsafe virtual void InvalidateSpanGroupIndexCache()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateSpanGroupIndexCache.()V", this, null);
		}

		private static Delegate GetInvalidateSpanIndexCacheHandler()
		{
			if ((object)cb_invalidateSpanIndexCache == null)
			{
				cb_invalidateSpanIndexCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_InvalidateSpanIndexCache));
			}
			return cb_invalidateSpanIndexCache;
		}

		private static void n_InvalidateSpanIndexCache(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateSpanIndexCache();
		}

		[Register("invalidateSpanIndexCache", "()V", "GetInvalidateSpanIndexCacheHandler")]
		public unsafe virtual void InvalidateSpanIndexCache()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateSpanIndexCache.()V", this, null);
		}
	}

	[Register("androidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup", DoNotGenerateAcw = true)]
	internal class SpanSizeLookupInvoker : SpanSizeLookup
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup", typeof(SpanSizeLookupInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public SpanSizeLookupInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getSpanSize", "(I)I", "GetGetSpanSize_IHandler")]
		public unsafe override int GetSpanSize(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSpanSize.(I)I", this, ptr);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/GridLayoutManager", typeof(GridLayoutManager));

	private static Delegate cb_getSpanCount;

	private static Delegate cb_setSpanCount_I;

	private static Delegate cb_isUsingSpansToEstimateScrollbarDimensions;

	private static Delegate cb_setUsingSpansToEstimateScrollbarDimensions_Z;

	private static Delegate cb_getSpanSizeLookup;

	private static Delegate cb_setSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_;

	internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int SpanCount
	{
		[Register("getSpanCount", "()I", "GetGetSpanCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanCount.()I", this, null);
		}
		[Register("setSpanCount", "(I)V", "GetSetSpanCount_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSpanCount.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool UsingSpansToEstimateScrollbarDimensions
	{
		[Register("isUsingSpansToEstimateScrollbarDimensions", "()Z", "GetIsUsingSpansToEstimateScrollbarDimensionsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUsingSpansToEstimateScrollbarDimensions.()Z", this, null);
		}
		[Register("setUsingSpansToEstimateScrollbarDimensions", "(Z)V", "GetSetUsingSpansToEstimateScrollbarDimensions_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setUsingSpansToEstimateScrollbarDimensions.(Z)V", this, ptr);
		}
	}

	protected GridLayoutManager(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe GridLayoutManager(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;I)V", "")]
	public unsafe GridLayoutManager(Context context, int spanCount)
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
			ptr[1] = new JniArgumentValue(spanCount);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;IIZ)V", "")]
	public unsafe GridLayoutManager(Context context, int spanCount, int orientation, bool reverseLayout)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(spanCount);
			ptr[2] = new JniArgumentValue(orientation);
			ptr[3] = new JniArgumentValue(reverseLayout);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;IIZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;IIZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetSpanCountHandler()
	{
		if ((object)cb_getSpanCount == null)
		{
			cb_getSpanCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSpanCount));
		}
		return cb_getSpanCount;
	}

	private static int n_GetSpanCount(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpanCount;
	}

	private static Delegate GetSetSpanCount_IHandler()
	{
		if ((object)cb_setSpanCount_I == null)
		{
			cb_setSpanCount_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetSpanCount_I));
		}
		return cb_setSpanCount_I;
	}

	private static void n_SetSpanCount_I(IntPtr jnienv, IntPtr native__this, int spanCount)
	{
		Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpanCount = spanCount;
	}

	private static Delegate GetIsUsingSpansToEstimateScrollbarDimensionsHandler()
	{
		if ((object)cb_isUsingSpansToEstimateScrollbarDimensions == null)
		{
			cb_isUsingSpansToEstimateScrollbarDimensions = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsUsingSpansToEstimateScrollbarDimensions));
		}
		return cb_isUsingSpansToEstimateScrollbarDimensions;
	}

	private static bool n_IsUsingSpansToEstimateScrollbarDimensions(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UsingSpansToEstimateScrollbarDimensions;
	}

	private static Delegate GetSetUsingSpansToEstimateScrollbarDimensions_ZHandler()
	{
		if ((object)cb_setUsingSpansToEstimateScrollbarDimensions_Z == null)
		{
			cb_setUsingSpansToEstimateScrollbarDimensions_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetUsingSpansToEstimateScrollbarDimensions_Z));
		}
		return cb_setUsingSpansToEstimateScrollbarDimensions_Z;
	}

	private static void n_SetUsingSpansToEstimateScrollbarDimensions_Z(IntPtr jnienv, IntPtr native__this, bool useSpansToEstimateScrollBarDimensions)
	{
		Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UsingSpansToEstimateScrollbarDimensions = useSpansToEstimateScrollBarDimensions;
	}

	private static Delegate GetGetSpanSizeLookupHandler()
	{
		if ((object)cb_getSpanSizeLookup == null)
		{
			cb_getSpanSizeLookup = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSpanSizeLookup));
		}
		return cb_getSpanSizeLookup;
	}

	private static IntPtr n_GetSpanSizeLookup(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSpanSizeLookup());
	}

	[Register("getSpanSizeLookup", "()Landroidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup;", "GetGetSpanSizeLookupHandler")]
	public unsafe virtual SpanSizeLookup GetSpanSizeLookup()
	{
		return Java.Lang.Object.GetObject<SpanSizeLookup>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSpanSizeLookup.()Landroidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_Handler()
	{
		if ((object)cb_setSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_ == null)
		{
			cb_setSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_));
		}
		return cb_setSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_;
	}

	private static void n_SetSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_(IntPtr jnienv, IntPtr native__this, IntPtr native_spanSizeLookup)
	{
		GridLayoutManager gridLayoutManager = Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SpanSizeLookup spanSizeLookup = Java.Lang.Object.GetObject<SpanSizeLookup>(native_spanSizeLookup, JniHandleOwnership.DoNotTransfer);
		gridLayoutManager.SetSpanSizeLookup(spanSizeLookup);
	}

	[Register("setSpanSizeLookup", "(Landroidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup;)V", "GetSetSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_Handler")]
	public unsafe virtual void SetSpanSizeLookup(SpanSizeLookup spanSizeLookup)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(spanSizeLookup?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSpanSizeLookup.(Landroidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(spanSizeLookup);
		}
	}
}
[Register("androidx/recyclerview/widget/ItemTouchUIUtil", "", "AndroidX.RecyclerView.Widget.IItemTouchUIUtilInvoker")]
public interface IItemTouchUIUtil : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("clearView", "(Landroid/view/View;)V", "GetClearView_Landroid_view_View_Handler:AndroidX.RecyclerView.Widget.IItemTouchUIUtilInvoker, Xamarin.AndroidX.RecyclerView")]
	void ClearView(View p0);

	[Register("onDraw", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;FFIZ)V", "GetOnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZHandler:AndroidX.RecyclerView.Widget.IItemTouchUIUtilInvoker, Xamarin.AndroidX.RecyclerView")]
	void OnDraw(Canvas p0, RecyclerView p1, View p2, float p3, float p4, int p5, bool p6);

	[Register("onDrawOver", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;FFIZ)V", "GetOnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZHandler:AndroidX.RecyclerView.Widget.IItemTouchUIUtilInvoker, Xamarin.AndroidX.RecyclerView")]
	void OnDrawOver(Canvas p0, RecyclerView p1, View p2, float p3, float p4, int p5, bool p6);

	[Register("onSelected", "(Landroid/view/View;)V", "GetOnSelected_Landroid_view_View_Handler:AndroidX.RecyclerView.Widget.IItemTouchUIUtilInvoker, Xamarin.AndroidX.RecyclerView")]
	void OnSelected(View p0);
}
[Register("androidx/recyclerview/widget/ItemTouchUIUtil", DoNotGenerateAcw = true)]
internal class IItemTouchUIUtilInvoker : Java.Lang.Object, IItemTouchUIUtil, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/ItemTouchUIUtil", typeof(IItemTouchUIUtilInvoker));

	private IntPtr class_ref;

	private static Delegate cb_clearView_Landroid_view_View_;

	private IntPtr id_clearView_Landroid_view_View_;

	private static Delegate cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ;

	private IntPtr id_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ;

	private static Delegate cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ;

	private IntPtr id_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ;

	private static Delegate cb_onSelected_Landroid_view_View_;

	private IntPtr id_onSelected_Landroid_view_View_;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IItemTouchUIUtil GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IItemTouchUIUtil>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.recyclerview.widget.ItemTouchUIUtil"));
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

	public IItemTouchUIUtilInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetClearView_Landroid_view_View_Handler()
	{
		if ((object)cb_clearView_Landroid_view_View_ == null)
		{
			cb_clearView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ClearView_Landroid_view_View_));
		}
		return cb_clearView_Landroid_view_View_;
	}

	private static void n_ClearView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
	{
		IItemTouchUIUtil itemTouchUIUtil = Java.Lang.Object.GetObject<IItemTouchUIUtil>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View p = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
		itemTouchUIUtil.ClearView(p);
	}

	public unsafe void ClearView(View p0)
	{
		if (id_clearView_Landroid_view_View_ == IntPtr.Zero)
		{
			id_clearView_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "clearView", "(Landroid/view/View;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_clearView_Landroid_view_View_, ptr);
	}

	private static Delegate GetOnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZHandler()
	{
		if ((object)cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ == null)
		{
			cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLFFIZ_V(n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ));
		}
		return cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ;
	}

	private static void n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, float p3, float p4, int p5, bool p6)
	{
		IItemTouchUIUtil itemTouchUIUtil = Java.Lang.Object.GetObject<IItemTouchUIUtil>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Canvas p7 = Java.Lang.Object.GetObject<Canvas>(native_p0, JniHandleOwnership.DoNotTransfer);
		RecyclerView p8 = Java.Lang.Object.GetObject<RecyclerView>(native_p1, JniHandleOwnership.DoNotTransfer);
		View p9 = Java.Lang.Object.GetObject<View>(native_p2, JniHandleOwnership.DoNotTransfer);
		itemTouchUIUtil.OnDraw(p7, p8, p9, p3, p4, p5, p6);
	}

	public unsafe void OnDraw(Canvas p0, RecyclerView p1, View p2, float p3, float p4, int p5, bool p6)
	{
		if (id_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ == IntPtr.Zero)
		{
			id_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ = JNIEnv.GetMethodID(class_ref, "onDraw", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;FFIZ)V");
		}
		JValue* ptr = stackalloc JValue[7];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
		ptr[3] = new JValue(p3);
		ptr[4] = new JValue(p4);
		ptr[5] = new JValue(p5);
		ptr[6] = new JValue(p6);
		JNIEnv.CallVoidMethod(base.Handle, id_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ, ptr);
	}

	private static Delegate GetOnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZHandler()
	{
		if ((object)cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ == null)
		{
			cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLFFIZ_V(n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ));
		}
		return cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ;
	}

	private static void n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, float p3, float p4, int p5, bool p6)
	{
		IItemTouchUIUtil itemTouchUIUtil = Java.Lang.Object.GetObject<IItemTouchUIUtil>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Canvas p7 = Java.Lang.Object.GetObject<Canvas>(native_p0, JniHandleOwnership.DoNotTransfer);
		RecyclerView p8 = Java.Lang.Object.GetObject<RecyclerView>(native_p1, JniHandleOwnership.DoNotTransfer);
		View p9 = Java.Lang.Object.GetObject<View>(native_p2, JniHandleOwnership.DoNotTransfer);
		itemTouchUIUtil.OnDrawOver(p7, p8, p9, p3, p4, p5, p6);
	}

	public unsafe void OnDrawOver(Canvas p0, RecyclerView p1, View p2, float p3, float p4, int p5, bool p6)
	{
		if (id_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ == IntPtr.Zero)
		{
			id_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ = JNIEnv.GetMethodID(class_ref, "onDrawOver", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;FFIZ)V");
		}
		JValue* ptr = stackalloc JValue[7];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
		ptr[3] = new JValue(p3);
		ptr[4] = new JValue(p4);
		ptr[5] = new JValue(p5);
		ptr[6] = new JValue(p6);
		JNIEnv.CallVoidMethod(base.Handle, id_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_FFIZ, ptr);
	}

	private static Delegate GetOnSelected_Landroid_view_View_Handler()
	{
		if ((object)cb_onSelected_Landroid_view_View_ == null)
		{
			cb_onSelected_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSelected_Landroid_view_View_));
		}
		return cb_onSelected_Landroid_view_View_;
	}

	private static void n_OnSelected_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
	{
		IItemTouchUIUtil itemTouchUIUtil = Java.Lang.Object.GetObject<IItemTouchUIUtil>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View p = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
		itemTouchUIUtil.OnSelected(p);
	}

	public unsafe void OnSelected(View p0)
	{
		if (id_onSelected_Landroid_view_View_ == IntPtr.Zero)
		{
			id_onSelected_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onSelected", "(Landroid/view/View;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onSelected_Landroid_view_View_, ptr);
	}
}
[Register("androidx/recyclerview/widget/ItemTouchHelper", DoNotGenerateAcw = true)]
public class ItemTouchHelper : RecyclerView.ItemDecoration, RecyclerView.IOnChildAttachStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/recyclerview/widget/ItemTouchHelper$Callback", DoNotGenerateAcw = true)]
	public abstract class Callback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/ItemTouchHelper$Callback", typeof(Callback));

		private static Delegate cb_getBoundingBoxMargin;

		private static Delegate cb_isItemViewSwipeEnabled;

		private static Delegate cb_isLongPressDragEnabled;

		private static Delegate cb_canDropOver_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_chooseDropTarget_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_II;

		private static Delegate cb_clearView_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_convertToAbsoluteDirection_II;

		private static Delegate cb_getAnimationDuration_Landroidx_recyclerview_widget_RecyclerView_IFF;

		private static Delegate cb_getMoveThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_getMovementFlags_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_getSwipeEscapeVelocity_F;

		private static Delegate cb_getSwipeThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_getSwipeVelocityThreshold_F;

		private static Delegate cb_interpolateOutOfBoundsScroll_Landroidx_recyclerview_widget_RecyclerView_IIIJ;

		private static Delegate cb_onChildDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ;

		private static Delegate cb_onChildDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ;

		private static Delegate cb_onMove_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_onMoved_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILandroidx_recyclerview_widget_RecyclerView_ViewHolder_III;

		private static Delegate cb_onSelectedChanged_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I;

		private static Delegate cb_onSwiped_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int BoundingBoxMargin
		{
			[Register("getBoundingBoxMargin", "()I", "GetGetBoundingBoxMarginHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBoundingBoxMargin.()I", this, null);
			}
		}

		public unsafe static IItemTouchUIUtil DefaultUIUtil
		{
			[Register("getDefaultUIUtil", "()Landroidx/recyclerview/widget/ItemTouchUIUtil;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IItemTouchUIUtil>(_members.StaticMethods.InvokeObjectMethod("getDefaultUIUtil.()Landroidx/recyclerview/widget/ItemTouchUIUtil;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsItemViewSwipeEnabled
		{
			[Register("isItemViewSwipeEnabled", "()Z", "GetIsItemViewSwipeEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isItemViewSwipeEnabled.()Z", this, null);
			}
		}

		public unsafe virtual bool IsLongPressDragEnabled
		{
			[Register("isLongPressDragEnabled", "()Z", "GetIsLongPressDragEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLongPressDragEnabled.()Z", this, null);
			}
		}

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

		private static Delegate GetGetBoundingBoxMarginHandler()
		{
			if ((object)cb_getBoundingBoxMargin == null)
			{
				cb_getBoundingBoxMargin = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBoundingBoxMargin));
			}
			return cb_getBoundingBoxMargin;
		}

		private static int n_GetBoundingBoxMargin(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoundingBoxMargin;
		}

		private static Delegate GetIsItemViewSwipeEnabledHandler()
		{
			if ((object)cb_isItemViewSwipeEnabled == null)
			{
				cb_isItemViewSwipeEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsItemViewSwipeEnabled));
			}
			return cb_isItemViewSwipeEnabled;
		}

		private static bool n_IsItemViewSwipeEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsItemViewSwipeEnabled;
		}

		private static Delegate GetIsLongPressDragEnabledHandler()
		{
			if ((object)cb_isLongPressDragEnabled == null)
			{
				cb_isLongPressDragEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsLongPressDragEnabled));
			}
			return cb_isLongPressDragEnabled;
		}

		private static bool n_IsLongPressDragEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLongPressDragEnabled;
		}

		private static Delegate GetCanDropOver_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_canDropOver_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_canDropOver_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_CanDropOver_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_canDropOver_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static bool n_CanDropOver_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, IntPtr native_current, IntPtr native_target)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder current = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_current, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder target = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_target, JniHandleOwnership.DoNotTransfer);
			return callback.CanDropOver(recyclerView, current, target);
		}

		[Register("canDropOver", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", "GetCanDropOver_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual bool CanDropOver(RecyclerView recyclerView, RecyclerView.ViewHolder current, RecyclerView.ViewHolder target)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(current?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canDropOver.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(current);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetChooseDropTarget_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_IIHandler()
		{
			if ((object)cb_chooseDropTarget_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_II == null)
			{
				cb_chooseDropTarget_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLII_L(n_ChooseDropTarget_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_II));
			}
			return cb_chooseDropTarget_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_II;
		}

		private static IntPtr n_ChooseDropTarget_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_II(IntPtr jnienv, IntPtr native__this, IntPtr native_selected, IntPtr native_dropTargets, int curX, int curY)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder selected = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_selected, JniHandleOwnership.DoNotTransfer);
			IList<RecyclerView.ViewHolder> dropTargets = JavaList<RecyclerView.ViewHolder>.FromJniHandle(native_dropTargets, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(callback.ChooseDropTarget(selected, dropTargets, curX, curY));
		}

		[Register("chooseDropTarget", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Ljava/util/List;II)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetChooseDropTarget_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_IIHandler")]
		public unsafe virtual RecyclerView.ViewHolder ChooseDropTarget(RecyclerView.ViewHolder selected, IList<RecyclerView.ViewHolder> dropTargets, int curX, int curY)
		{
			IntPtr intPtr = JavaList<RecyclerView.ViewHolder>.ToLocalJniHandle(dropTargets);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(selected?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(curX);
				ptr[3] = new JniArgumentValue(curY);
				return Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("chooseDropTarget.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Ljava/util/List;II)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(selected);
				GC.KeepAlive(dropTargets);
			}
		}

		private static Delegate GetClearView_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_clearView_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_clearView_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ClearView_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_clearView_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static void n_ClearView_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, IntPtr native_viewHolder)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder viewHolder = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			callback.ClearView(recyclerView, viewHolder);
		}

		[Register("clearView", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetClearView_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void ClearView(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("clearView.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetConvertToAbsoluteDirection_IIHandler()
		{
			if ((object)cb_convertToAbsoluteDirection_II == null)
			{
				cb_convertToAbsoluteDirection_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_I(n_ConvertToAbsoluteDirection_II));
			}
			return cb_convertToAbsoluteDirection_II;
		}

		private static int n_ConvertToAbsoluteDirection_II(IntPtr jnienv, IntPtr native__this, int flags, int layoutDirection)
		{
			return Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConvertToAbsoluteDirection(flags, layoutDirection);
		}

		[Register("convertToAbsoluteDirection", "(II)I", "GetConvertToAbsoluteDirection_IIHandler")]
		public unsafe virtual int ConvertToAbsoluteDirection(int flags, int layoutDirection)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(flags);
			ptr[1] = new JniArgumentValue(layoutDirection);
			return _members.InstanceMethods.InvokeVirtualInt32Method("convertToAbsoluteDirection.(II)I", this, ptr);
		}

		[Register("convertToRelativeDirection", "(II)I", "")]
		public unsafe static int ConvertToRelativeDirection(int flags, int layoutDirection)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(flags);
			ptr[1] = new JniArgumentValue(layoutDirection);
			return _members.StaticMethods.InvokeInt32Method("convertToRelativeDirection.(II)I", ptr);
		}

		private static Delegate GetGetAnimationDuration_Landroidx_recyclerview_widget_RecyclerView_IFFHandler()
		{
			if ((object)cb_getAnimationDuration_Landroidx_recyclerview_widget_RecyclerView_IFF == null)
			{
				cb_getAnimationDuration_Landroidx_recyclerview_widget_RecyclerView_IFF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIFF_J(n_GetAnimationDuration_Landroidx_recyclerview_widget_RecyclerView_IFF));
			}
			return cb_getAnimationDuration_Landroidx_recyclerview_widget_RecyclerView_IFF;
		}

		private static long n_GetAnimationDuration_Landroidx_recyclerview_widget_RecyclerView_IFF(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, int animationType, float animateDx, float animateDy)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			return callback.GetAnimationDuration(recyclerView, animationType, animateDx, animateDy);
		}

		[Register("getAnimationDuration", "(Landroidx/recyclerview/widget/RecyclerView;IFF)J", "GetGetAnimationDuration_Landroidx_recyclerview_widget_RecyclerView_IFFHandler")]
		public unsafe virtual long GetAnimationDuration(RecyclerView recyclerView, int animationType, float animateDx, float animateDy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(animationType);
				ptr[2] = new JniArgumentValue(animateDx);
				ptr[3] = new JniArgumentValue(animateDy);
				return _members.InstanceMethods.InvokeVirtualInt64Method("getAnimationDuration.(Landroidx/recyclerview/widget/RecyclerView;IFF)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetGetMoveThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_getMoveThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_getMoveThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_F(n_GetMoveThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_getMoveThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static float n_GetMoveThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder viewHolder = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			return callback.GetMoveThreshold(viewHolder);
		}

		[Register("getMoveThreshold", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)F", "GetGetMoveThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual float GetMoveThreshold(RecyclerView.ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getMoveThreshold.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)F", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetGetMovementFlags_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_getMovementFlags_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_getMovementFlags_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_GetMovementFlags_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_getMovementFlags_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static int n_GetMovementFlags_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView p = Java.Lang.Object.GetObject<RecyclerView>(native_p0, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder p2 = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_p1, JniHandleOwnership.DoNotTransfer);
			return callback.GetMovementFlags(p, p2);
		}

		[Register("getMovementFlags", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)I", "GetGetMovementFlags_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public abstract int GetMovementFlags(RecyclerView p0, RecyclerView.ViewHolder p1);

		private static Delegate GetGetSwipeEscapeVelocity_FHandler()
		{
			if ((object)cb_getSwipeEscapeVelocity_F == null)
			{
				cb_getSwipeEscapeVelocity_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_F(n_GetSwipeEscapeVelocity_F));
			}
			return cb_getSwipeEscapeVelocity_F;
		}

		private static float n_GetSwipeEscapeVelocity_F(IntPtr jnienv, IntPtr native__this, float defaultValue)
		{
			return Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSwipeEscapeVelocity(defaultValue);
		}

		[Register("getSwipeEscapeVelocity", "(F)F", "GetGetSwipeEscapeVelocity_FHandler")]
		public unsafe virtual float GetSwipeEscapeVelocity(float defaultValue)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(defaultValue);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getSwipeEscapeVelocity.(F)F", this, ptr);
		}

		private static Delegate GetGetSwipeThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_getSwipeThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_getSwipeThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_F(n_GetSwipeThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_getSwipeThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static float n_GetSwipeThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder viewHolder = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			return callback.GetSwipeThreshold(viewHolder);
		}

		[Register("getSwipeThreshold", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)F", "GetGetSwipeThreshold_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual float GetSwipeThreshold(RecyclerView.ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getSwipeThreshold.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)F", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetGetSwipeVelocityThreshold_FHandler()
		{
			if ((object)cb_getSwipeVelocityThreshold_F == null)
			{
				cb_getSwipeVelocityThreshold_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_F(n_GetSwipeVelocityThreshold_F));
			}
			return cb_getSwipeVelocityThreshold_F;
		}

		private static float n_GetSwipeVelocityThreshold_F(IntPtr jnienv, IntPtr native__this, float defaultValue)
		{
			return Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSwipeVelocityThreshold(defaultValue);
		}

		[Register("getSwipeVelocityThreshold", "(F)F", "GetGetSwipeVelocityThreshold_FHandler")]
		public unsafe virtual float GetSwipeVelocityThreshold(float defaultValue)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(defaultValue);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getSwipeVelocityThreshold.(F)F", this, ptr);
		}

		private static Delegate GetInterpolateOutOfBoundsScroll_Landroidx_recyclerview_widget_RecyclerView_IIIJHandler()
		{
			if ((object)cb_interpolateOutOfBoundsScroll_Landroidx_recyclerview_widget_RecyclerView_IIIJ == null)
			{
				cb_interpolateOutOfBoundsScroll_Landroidx_recyclerview_widget_RecyclerView_IIIJ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIIIJ_I(n_InterpolateOutOfBoundsScroll_Landroidx_recyclerview_widget_RecyclerView_IIIJ));
			}
			return cb_interpolateOutOfBoundsScroll_Landroidx_recyclerview_widget_RecyclerView_IIIJ;
		}

		private static int n_InterpolateOutOfBoundsScroll_Landroidx_recyclerview_widget_RecyclerView_IIIJ(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, int viewSize, int viewSizeOutOfBounds, int totalSize, long msSinceStartScroll)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			return callback.InterpolateOutOfBoundsScroll(recyclerView, viewSize, viewSizeOutOfBounds, totalSize, msSinceStartScroll);
		}

		[Register("interpolateOutOfBoundsScroll", "(Landroidx/recyclerview/widget/RecyclerView;IIIJ)I", "GetInterpolateOutOfBoundsScroll_Landroidx_recyclerview_widget_RecyclerView_IIIJHandler")]
		public unsafe virtual int InterpolateOutOfBoundsScroll(RecyclerView recyclerView, int viewSize, int viewSizeOutOfBounds, int totalSize, long msSinceStartScroll)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewSize);
				ptr[2] = new JniArgumentValue(viewSizeOutOfBounds);
				ptr[3] = new JniArgumentValue(totalSize);
				ptr[4] = new JniArgumentValue(msSinceStartScroll);
				return _members.InstanceMethods.InvokeVirtualInt32Method("interpolateOutOfBoundsScroll.(Landroidx/recyclerview/widget/RecyclerView;IIIJ)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		[Register("makeFlag", "(II)I", "")]
		public unsafe static int MakeFlag(int actionState, int directions)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(actionState);
			ptr[1] = new JniArgumentValue(directions);
			return _members.StaticMethods.InvokeInt32Method("makeFlag.(II)I", ptr);
		}

		[Register("makeMovementFlags", "(II)I", "")]
		public unsafe static int MakeMovementFlags(int dragFlags, int swipeFlags)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dragFlags);
			ptr[1] = new JniArgumentValue(swipeFlags);
			return _members.StaticMethods.InvokeInt32Method("makeMovementFlags.(II)I", ptr);
		}

		private static Delegate GetOnChildDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZHandler()
		{
			if ((object)cb_onChildDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ == null)
			{
				cb_onChildDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLFFIZ_V(n_OnChildDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ));
			}
			return cb_onChildDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ;
		}

		private static void n_OnChildDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ(IntPtr jnienv, IntPtr native__this, IntPtr native_c, IntPtr native_recyclerView, IntPtr native_viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder viewHolder = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			callback.OnChildDraw(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
		}

		[Register("onChildDraw", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;FFIZ)V", "GetOnChildDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZHandler")]
		public unsafe virtual void OnChildDraw(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(dX);
				ptr[4] = new JniArgumentValue(dY);
				ptr[5] = new JniArgumentValue(actionState);
				ptr[6] = new JniArgumentValue(isCurrentlyActive);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onChildDraw.(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;FFIZ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetOnChildDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZHandler()
		{
			if ((object)cb_onChildDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ == null)
			{
				cb_onChildDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLFFIZ_V(n_OnChildDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ));
			}
			return cb_onChildDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ;
		}

		private static void n_OnChildDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZ(IntPtr jnienv, IntPtr native__this, IntPtr native_c, IntPtr native_recyclerView, IntPtr native_viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder viewHolder = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			callback.OnChildDrawOver(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
		}

		[Register("onChildDrawOver", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;FFIZ)V", "GetOnChildDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_FFIZHandler")]
		public unsafe virtual void OnChildDrawOver(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(dX);
				ptr[4] = new JniArgumentValue(dY);
				ptr[5] = new JniArgumentValue(actionState);
				ptr[6] = new JniArgumentValue(isCurrentlyActive);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onChildDrawOver.(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;FFIZ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetOnMove_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_onMove_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_onMove_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_OnMove_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_onMove_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static bool n_OnMove_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView p = Java.Lang.Object.GetObject<RecyclerView>(native_p0, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder p2 = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_p1, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder p3 = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_p2, JniHandleOwnership.DoNotTransfer);
			return callback.OnMove(p, p2, p3);
		}

		[Register("onMove", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", "GetOnMove_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public abstract bool OnMove(RecyclerView p0, RecyclerView.ViewHolder p1, RecyclerView.ViewHolder p2);

		private static Delegate GetOnMoved_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILandroidx_recyclerview_widget_RecyclerView_ViewHolder_IIIHandler()
		{
			if ((object)cb_onMoved_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILandroidx_recyclerview_widget_RecyclerView_ViewHolder_III == null)
			{
				cb_onMoved_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILandroidx_recyclerview_widget_RecyclerView_ViewHolder_III = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLILIII_V(n_OnMoved_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILandroidx_recyclerview_widget_RecyclerView_ViewHolder_III));
			}
			return cb_onMoved_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILandroidx_recyclerview_widget_RecyclerView_ViewHolder_III;
		}

		private static void n_OnMoved_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILandroidx_recyclerview_widget_RecyclerView_ViewHolder_III(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, IntPtr native_viewHolder, int fromPos, IntPtr native_target, int toPos, int x, int y)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder viewHolder = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder target = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_target, JniHandleOwnership.DoNotTransfer);
			callback.OnMoved(recyclerView, viewHolder, fromPos, target, toPos, x, y);
		}

		[Register("onMoved", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILandroidx/recyclerview/widget/RecyclerView$ViewHolder;III)V", "GetOnMoved_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILandroidx_recyclerview_widget_RecyclerView_ViewHolder_IIIHandler")]
		public unsafe virtual void OnMoved(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, int fromPos, RecyclerView.ViewHolder target, int toPos, int x, int y)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(fromPos);
				ptr[3] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(toPos);
				ptr[5] = new JniArgumentValue(x);
				ptr[6] = new JniArgumentValue(y);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onMoved.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILandroidx/recyclerview/widget/RecyclerView$ViewHolder;III)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnSelectedChanged_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler()
		{
			if ((object)cb_onSelectedChanged_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I == null)
			{
				cb_onSelectedChanged_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_OnSelectedChanged_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I));
			}
			return cb_onSelectedChanged_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I;
		}

		private static void n_OnSelectedChanged_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder, int actionState)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder viewHolder = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			callback.OnSelectedChanged(viewHolder, actionState);
		}

		[Register("onSelectedChanged", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", "GetOnSelectedChanged_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler")]
		public unsafe virtual void OnSelectedChanged(RecyclerView.ViewHolder viewHolder, int actionState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(actionState);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onSelectedChanged.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetOnSwiped_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler()
		{
			if ((object)cb_onSwiped_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I == null)
			{
				cb_onSwiped_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_OnSwiped_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I));
			}
			return cb_onSwiped_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I;
		}

		private static void n_OnSwiped_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.ViewHolder p2 = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_p0, JniHandleOwnership.DoNotTransfer);
			callback.OnSwiped(p2, p1);
		}

		[Register("onSwiped", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", "GetOnSwiped_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler")]
		public abstract void OnSwiped(RecyclerView.ViewHolder p0, int p1);
	}

	[Register("androidx/recyclerview/widget/ItemTouchHelper$Callback", DoNotGenerateAcw = true)]
	internal class CallbackInvoker : Callback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/ItemTouchHelper$Callback", typeof(CallbackInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public CallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getMovementFlags", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)I", "GetGetMovementFlags_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe override int GetMovementFlags(RecyclerView p0, RecyclerView.ViewHolder p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMovementFlags.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("onMove", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", "GetOnMove_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe override bool OnMove(RecyclerView p0, RecyclerView.ViewHolder p1, RecyclerView.ViewHolder p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("onMove.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		[Register("onSwiped", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", "GetOnSwiped_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler")]
		public unsafe override void OnSwiped(RecyclerView.ViewHolder p0, int p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onSwiped.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}

	[Register("androidx/recyclerview/widget/ItemTouchHelper$ViewDropHandler", "", "AndroidX.RecyclerView.Widget.ItemTouchHelper/IViewDropHandlerInvoker")]
	public interface IViewDropHandler : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("prepareForDrop", "(Landroid/view/View;Landroid/view/View;II)V", "GetPrepareForDrop_Landroid_view_View_Landroid_view_View_IIHandler:AndroidX.RecyclerView.Widget.ItemTouchHelper/IViewDropHandlerInvoker, Xamarin.AndroidX.RecyclerView")]
		void PrepareForDrop(View p0, View p1, int p2, int p3);
	}

	[Register("androidx/recyclerview/widget/ItemTouchHelper$ViewDropHandler", DoNotGenerateAcw = true)]
	internal class IViewDropHandlerInvoker : Java.Lang.Object, IViewDropHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/ItemTouchHelper$ViewDropHandler", typeof(IViewDropHandlerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_prepareForDrop_Landroid_view_View_Landroid_view_View_II;

		private IntPtr id_prepareForDrop_Landroid_view_View_Landroid_view_View_II;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IViewDropHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IViewDropHandler>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.recyclerview.widget.ItemTouchHelper.ViewDropHandler"));
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

		public IViewDropHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetPrepareForDrop_Landroid_view_View_Landroid_view_View_IIHandler()
		{
			if ((object)cb_prepareForDrop_Landroid_view_View_Landroid_view_View_II == null)
			{
				cb_prepareForDrop_Landroid_view_View_Landroid_view_View_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLII_V(n_PrepareForDrop_Landroid_view_View_Landroid_view_View_II));
			}
			return cb_prepareForDrop_Landroid_view_View_Landroid_view_View_II;
		}

		private static void n_PrepareForDrop_Landroid_view_View_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2, int p3)
		{
			IViewDropHandler viewDropHandler = Java.Lang.Object.GetObject<IViewDropHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View p4 = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
			View p5 = Java.Lang.Object.GetObject<View>(native_p1, JniHandleOwnership.DoNotTransfer);
			viewDropHandler.PrepareForDrop(p4, p5, p2, p3);
		}

		public unsafe void PrepareForDrop(View p0, View p1, int p2, int p3)
		{
			if (id_prepareForDrop_Landroid_view_View_Landroid_view_View_II == IntPtr.Zero)
			{
				id_prepareForDrop_Landroid_view_View_Landroid_view_View_II = JNIEnv.GetMethodID(class_ref, "prepareForDrop", "(Landroid/view/View;Landroid/view/View;II)V");
			}
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(p2);
			ptr[3] = new JValue(p3);
			JNIEnv.CallVoidMethod(base.Handle, id_prepareForDrop_Landroid_view_View_Landroid_view_View_II, ptr);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/ItemTouchHelper", typeof(ItemTouchHelper));

	private static Delegate cb_attachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_;

	private static Delegate cb_onChildViewAttachedToWindow_Landroid_view_View_;

	private static Delegate cb_onChildViewDetachedFromWindow_Landroid_view_View_;

	private static Delegate cb_startDrag_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

	private static Delegate cb_startSwipe_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

	internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ItemTouchHelper(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/recyclerview/widget/ItemTouchHelper$Callback;)V", "")]
	public unsafe ItemTouchHelper(Callback callback)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/recyclerview/widget/ItemTouchHelper$Callback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/recyclerview/widget/ItemTouchHelper$Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetAttachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler()
	{
		if ((object)cb_attachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_ == null)
		{
			cb_attachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AttachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_));
		}
		return cb_attachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_;
	}

	private static void n_AttachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView)
	{
		ItemTouchHelper itemTouchHelper = Java.Lang.Object.GetObject<ItemTouchHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
		itemTouchHelper.AttachToRecyclerView(recyclerView);
	}

	[Register("attachToRecyclerView", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetAttachToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler")]
	public unsafe virtual void AttachToRecyclerView(RecyclerView recyclerView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("attachToRecyclerView.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(recyclerView);
		}
	}

	private static Delegate GetOnChildViewAttachedToWindow_Landroid_view_View_Handler()
	{
		if ((object)cb_onChildViewAttachedToWindow_Landroid_view_View_ == null)
		{
			cb_onChildViewAttachedToWindow_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnChildViewAttachedToWindow_Landroid_view_View_));
		}
		return cb_onChildViewAttachedToWindow_Landroid_view_View_;
	}

	private static void n_OnChildViewAttachedToWindow_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
	{
		ItemTouchHelper itemTouchHelper = Java.Lang.Object.GetObject<ItemTouchHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		itemTouchHelper.OnChildViewAttachedToWindow(view);
	}

	[Register("onChildViewAttachedToWindow", "(Landroid/view/View;)V", "GetOnChildViewAttachedToWindow_Landroid_view_View_Handler")]
	public unsafe virtual void OnChildViewAttachedToWindow(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onChildViewAttachedToWindow.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetOnChildViewDetachedFromWindow_Landroid_view_View_Handler()
	{
		if ((object)cb_onChildViewDetachedFromWindow_Landroid_view_View_ == null)
		{
			cb_onChildViewDetachedFromWindow_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnChildViewDetachedFromWindow_Landroid_view_View_));
		}
		return cb_onChildViewDetachedFromWindow_Landroid_view_View_;
	}

	private static void n_OnChildViewDetachedFromWindow_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
	{
		ItemTouchHelper itemTouchHelper = Java.Lang.Object.GetObject<ItemTouchHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		itemTouchHelper.OnChildViewDetachedFromWindow(view);
	}

	[Register("onChildViewDetachedFromWindow", "(Landroid/view/View;)V", "GetOnChildViewDetachedFromWindow_Landroid_view_View_Handler")]
	public unsafe virtual void OnChildViewDetachedFromWindow(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onChildViewDetachedFromWindow.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetStartDrag_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
	{
		if ((object)cb_startDrag_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
		{
			cb_startDrag_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StartDrag_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
		}
		return cb_startDrag_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
	}

	private static void n_StartDrag_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder)
	{
		ItemTouchHelper itemTouchHelper = Java.Lang.Object.GetObject<ItemTouchHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		RecyclerView.ViewHolder viewHolder = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
		itemTouchHelper.StartDrag(viewHolder);
	}

	[Register("startDrag", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetStartDrag_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
	public unsafe virtual void StartDrag(RecyclerView.ViewHolder viewHolder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startDrag.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(viewHolder);
		}
	}

	private static Delegate GetStartSwipe_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
	{
		if ((object)cb_startSwipe_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
		{
			cb_startSwipe_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StartSwipe_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
		}
		return cb_startSwipe_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
	}

	private static void n_StartSwipe_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder)
	{
		ItemTouchHelper itemTouchHelper = Java.Lang.Object.GetObject<ItemTouchHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		RecyclerView.ViewHolder viewHolder = Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
		itemTouchHelper.StartSwipe(viewHolder);
	}

	[Register("startSwipe", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetStartSwipe_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
	public unsafe virtual void StartSwipe(RecyclerView.ViewHolder viewHolder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startSwipe.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(viewHolder);
		}
	}
}
[Register("androidx/recyclerview/widget/LinearLayoutManager", DoNotGenerateAcw = true)]
public class LinearLayoutManager : RecyclerView.LayoutManager, ItemTouchHelper.IViewDropHandler, IJavaObject, IDisposable, IJavaPeerable, RecyclerView.SmoothScroller.IScrollVectorProvider
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/LinearLayoutManager", typeof(LinearLayoutManager));

	private static Delegate cb_getInitialPrefetchItemCount;

	private static Delegate cb_setInitialPrefetchItemCount_I;

	private static Delegate cb_isLayoutRTL;

	private static Delegate cb_getOrientation;

	private static Delegate cb_setOrientation_I;

	private static Delegate cb_getRecycleChildrenOnDetach;

	private static Delegate cb_setRecycleChildrenOnDetach_Z;

	private static Delegate cb_getReverseLayout;

	private static Delegate cb_setReverseLayout_Z;

	private static Delegate cb_isSmoothScrollbarEnabled;

	private static Delegate cb_setSmoothScrollbarEnabled_Z;

	private static Delegate cb_getStackFromEnd;

	private static Delegate cb_setStackFromEnd_Z;

	private static Delegate cb_calculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayI;

	private static Delegate cb_computeScrollVectorForPosition_I;

	private static Delegate cb_findFirstCompletelyVisibleItemPosition;

	private static Delegate cb_findFirstVisibleItemPosition;

	private static Delegate cb_findLastCompletelyVisibleItemPosition;

	private static Delegate cb_findLastVisibleItemPosition;

	private static Delegate cb_generateDefaultLayoutParams;

	private static Delegate cb_getExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_;

	private static Delegate cb_prepareForDrop_Landroid_view_View_Landroid_view_View_II;

	private static Delegate cb_scrollToPositionWithOffset_II;

	internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int InitialPrefetchItemCount
	{
		[Register("getInitialPrefetchItemCount", "()I", "GetGetInitialPrefetchItemCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInitialPrefetchItemCount.()I", this, null);
		}
		[Register("setInitialPrefetchItemCount", "(I)V", "GetSetInitialPrefetchItemCount_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInitialPrefetchItemCount.(I)V", this, ptr);
		}
	}

	protected unsafe virtual bool IsLayoutRTL
	{
		[Register("isLayoutRTL", "()Z", "GetIsLayoutRTLHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLayoutRTL.()Z", this, null);
		}
	}

	public unsafe virtual int Orientation
	{
		[Register("getOrientation", "()I", "GetGetOrientationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOrientation.()I", this, null);
		}
		[Register("setOrientation", "(I)V", "GetSetOrientation_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOrientation.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool RecycleChildrenOnDetach
	{
		[Register("getRecycleChildrenOnDetach", "()Z", "GetGetRecycleChildrenOnDetachHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getRecycleChildrenOnDetach.()Z", this, null);
		}
		[Register("setRecycleChildrenOnDetach", "(Z)V", "GetSetRecycleChildrenOnDetach_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRecycleChildrenOnDetach.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool ReverseLayout
	{
		[Register("getReverseLayout", "()Z", "GetGetReverseLayoutHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getReverseLayout.()Z", this, null);
		}
		[Register("setReverseLayout", "(Z)V", "GetSetReverseLayout_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setReverseLayout.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool SmoothScrollbarEnabled
	{
		[Register("isSmoothScrollbarEnabled", "()Z", "GetIsSmoothScrollbarEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSmoothScrollbarEnabled.()Z", this, null);
		}
		[Register("setSmoothScrollbarEnabled", "(Z)V", "GetSetSmoothScrollbarEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSmoothScrollbarEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool StackFromEnd
	{
		[Register("getStackFromEnd", "()Z", "GetGetStackFromEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getStackFromEnd.()Z", this, null);
		}
		[Register("setStackFromEnd", "(Z)V", "GetSetStackFromEnd_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStackFromEnd.(Z)V", this, ptr);
		}
	}

	protected LinearLayoutManager(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe LinearLayoutManager(Context context)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe LinearLayoutManager(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;IZ)V", "")]
	public unsafe LinearLayoutManager(Context context, int orientation, bool reverseLayout)
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
			ptr[1] = new JniArgumentValue(orientation);
			ptr[2] = new JniArgumentValue(reverseLayout);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;IZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;IZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetInitialPrefetchItemCountHandler()
	{
		if ((object)cb_getInitialPrefetchItemCount == null)
		{
			cb_getInitialPrefetchItemCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetInitialPrefetchItemCount));
		}
		return cb_getInitialPrefetchItemCount;
	}

	private static int n_GetInitialPrefetchItemCount(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitialPrefetchItemCount;
	}

	private static Delegate GetSetInitialPrefetchItemCount_IHandler()
	{
		if ((object)cb_setInitialPrefetchItemCount_I == null)
		{
			cb_setInitialPrefetchItemCount_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetInitialPrefetchItemCount_I));
		}
		return cb_setInitialPrefetchItemCount_I;
	}

	private static void n_SetInitialPrefetchItemCount_I(IntPtr jnienv, IntPtr native__this, int itemCount)
	{
		Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitialPrefetchItemCount = itemCount;
	}

	private static Delegate GetIsLayoutRTLHandler()
	{
		if ((object)cb_isLayoutRTL == null)
		{
			cb_isLayoutRTL = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsLayoutRTL));
		}
		return cb_isLayoutRTL;
	}

	private static bool n_IsLayoutRTL(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLayoutRTL;
	}

	private static Delegate GetGetOrientationHandler()
	{
		if ((object)cb_getOrientation == null)
		{
			cb_getOrientation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOrientation));
		}
		return cb_getOrientation;
	}

	private static int n_GetOrientation(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation;
	}

	private static Delegate GetSetOrientation_IHandler()
	{
		if ((object)cb_setOrientation_I == null)
		{
			cb_setOrientation_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetOrientation_I));
		}
		return cb_setOrientation_I;
	}

	private static void n_SetOrientation_I(IntPtr jnienv, IntPtr native__this, int orientation)
	{
		Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation = orientation;
	}

	private static Delegate GetGetRecycleChildrenOnDetachHandler()
	{
		if ((object)cb_getRecycleChildrenOnDetach == null)
		{
			cb_getRecycleChildrenOnDetach = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetRecycleChildrenOnDetach));
		}
		return cb_getRecycleChildrenOnDetach;
	}

	private static bool n_GetRecycleChildrenOnDetach(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RecycleChildrenOnDetach;
	}

	private static Delegate GetSetRecycleChildrenOnDetach_ZHandler()
	{
		if ((object)cb_setRecycleChildrenOnDetach_Z == null)
		{
			cb_setRecycleChildrenOnDetach_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetRecycleChildrenOnDetach_Z));
		}
		return cb_setRecycleChildrenOnDetach_Z;
	}

	private static void n_SetRecycleChildrenOnDetach_Z(IntPtr jnienv, IntPtr native__this, bool recycleChildrenOnDetach)
	{
		Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RecycleChildrenOnDetach = recycleChildrenOnDetach;
	}

	private static Delegate GetGetReverseLayoutHandler()
	{
		if ((object)cb_getReverseLayout == null)
		{
			cb_getReverseLayout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetReverseLayout));
		}
		return cb_getReverseLayout;
	}

	private static bool n_GetReverseLayout(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReverseLayout;
	}

	private static Delegate GetSetReverseLayout_ZHandler()
	{
		if ((object)cb_setReverseLayout_Z == null)
		{
			cb_setReverseLayout_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetReverseLayout_Z));
		}
		return cb_setReverseLayout_Z;
	}

	private static void n_SetReverseLayout_Z(IntPtr jnienv, IntPtr native__this, bool reverseLayout)
	{
		Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReverseLayout = reverseLayout;
	}

	private static Delegate GetIsSmoothScrollbarEnabledHandler()
	{
		if ((object)cb_isSmoothScrollbarEnabled == null)
		{
			cb_isSmoothScrollbarEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSmoothScrollbarEnabled));
		}
		return cb_isSmoothScrollbarEnabled;
	}

	private static bool n_IsSmoothScrollbarEnabled(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SmoothScrollbarEnabled;
	}

	private static Delegate GetSetSmoothScrollbarEnabled_ZHandler()
	{
		if ((object)cb_setSmoothScrollbarEnabled_Z == null)
		{
			cb_setSmoothScrollbarEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetSmoothScrollbarEnabled_Z));
		}
		return cb_setSmoothScrollbarEnabled_Z;
	}

	private static void n_SetSmoothScrollbarEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
	{
		Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SmoothScrollbarEnabled = enabled;
	}

	private static Delegate GetGetStackFromEndHandler()
	{
		if ((object)cb_getStackFromEnd == null)
		{
			cb_getStackFromEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetStackFromEnd));
		}
		return cb_getStackFromEnd;
	}

	private static bool n_GetStackFromEnd(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StackFromEnd;
	}

	private static Delegate GetSetStackFromEnd_ZHandler()
	{
		if ((object)cb_setStackFromEnd_Z == null)
		{
			cb_setStackFromEnd_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetStackFromEnd_Z));
		}
		return cb_setStackFromEnd_Z;
	}

	private static void n_SetStackFromEnd_Z(IntPtr jnienv, IntPtr native__this, bool stackFromEnd)
	{
		Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StackFromEnd = stackFromEnd;
	}

	private static Delegate GetCalculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayIHandler()
	{
		if ((object)cb_calculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayI == null)
		{
			cb_calculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_CalculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayI));
		}
		return cb_calculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayI;
	}

	private static void n_CalculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_state, IntPtr native_extraLayoutSpace)
	{
		LinearLayoutManager linearLayoutManager = Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		RecyclerView.State state = Java.Lang.Object.GetObject<RecyclerView.State>(native_state, JniHandleOwnership.DoNotTransfer);
		int[] array = (int[])JNIEnv.GetArray(native_extraLayoutSpace, JniHandleOwnership.DoNotTransfer, typeof(int));
		linearLayoutManager.CalculateExtraLayoutSpace(state, array);
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_extraLayoutSpace);
		}
	}

	[Register("calculateExtraLayoutSpace", "(Landroidx/recyclerview/widget/RecyclerView$State;[I)V", "GetCalculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayIHandler")]
	protected unsafe virtual void CalculateExtraLayoutSpace(RecyclerView.State state, int[] extraLayoutSpace)
	{
		IntPtr intPtr = JNIEnv.NewArray(extraLayoutSpace);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeVirtualVoidMethod("calculateExtraLayoutSpace.(Landroidx/recyclerview/widget/RecyclerView$State;[I)V", this, ptr);
		}
		finally
		{
			if (extraLayoutSpace != null)
			{
				JNIEnv.CopyArray(intPtr, extraLayoutSpace);
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(state);
			GC.KeepAlive(extraLayoutSpace);
		}
	}

	private static Delegate GetComputeScrollVectorForPosition_IHandler()
	{
		if ((object)cb_computeScrollVectorForPosition_I == null)
		{
			cb_computeScrollVectorForPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_ComputeScrollVectorForPosition_I));
		}
		return cb_computeScrollVectorForPosition_I;
	}

	private static IntPtr n_ComputeScrollVectorForPosition_I(IntPtr jnienv, IntPtr native__this, int targetPosition)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeScrollVectorForPosition(targetPosition));
	}

	[Register("computeScrollVectorForPosition", "(I)Landroid/graphics/PointF;", "GetComputeScrollVectorForPosition_IHandler")]
	public unsafe virtual PointF ComputeScrollVectorForPosition(int targetPosition)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(targetPosition);
		return Java.Lang.Object.GetObject<PointF>(_members.InstanceMethods.InvokeVirtualObjectMethod("computeScrollVectorForPosition.(I)Landroid/graphics/PointF;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindFirstCompletelyVisibleItemPositionHandler()
	{
		if ((object)cb_findFirstCompletelyVisibleItemPosition == null)
		{
			cb_findFirstCompletelyVisibleItemPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_FindFirstCompletelyVisibleItemPosition));
		}
		return cb_findFirstCompletelyVisibleItemPosition;
	}

	private static int n_FindFirstCompletelyVisibleItemPosition(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFirstCompletelyVisibleItemPosition();
	}

	[Register("findFirstCompletelyVisibleItemPosition", "()I", "GetFindFirstCompletelyVisibleItemPositionHandler")]
	public unsafe virtual int FindFirstCompletelyVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findFirstCompletelyVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetFindFirstVisibleItemPositionHandler()
	{
		if ((object)cb_findFirstVisibleItemPosition == null)
		{
			cb_findFirstVisibleItemPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_FindFirstVisibleItemPosition));
		}
		return cb_findFirstVisibleItemPosition;
	}

	private static int n_FindFirstVisibleItemPosition(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFirstVisibleItemPosition();
	}

	[Register("findFirstVisibleItemPosition", "()I", "GetFindFirstVisibleItemPositionHandler")]
	public unsafe virtual int FindFirstVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findFirstVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetFindLastCompletelyVisibleItemPositionHandler()
	{
		if ((object)cb_findLastCompletelyVisibleItemPosition == null)
		{
			cb_findLastCompletelyVisibleItemPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_FindLastCompletelyVisibleItemPosition));
		}
		return cb_findLastCompletelyVisibleItemPosition;
	}

	private static int n_FindLastCompletelyVisibleItemPosition(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindLastCompletelyVisibleItemPosition();
	}

	[Register("findLastCompletelyVisibleItemPosition", "()I", "GetFindLastCompletelyVisibleItemPositionHandler")]
	public unsafe virtual int FindLastCompletelyVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findLastCompletelyVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetFindLastVisibleItemPositionHandler()
	{
		if ((object)cb_findLastVisibleItemPosition == null)
		{
			cb_findLastVisibleItemPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_FindLastVisibleItemPosition));
		}
		return cb_findLastVisibleItemPosition;
	}

	private static int n_FindLastVisibleItemPosition(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindLastVisibleItemPosition();
	}

	[Register("findLastVisibleItemPosition", "()I", "GetFindLastVisibleItemPositionHandler")]
	public unsafe virtual int FindLastVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findLastVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetGenerateDefaultLayoutParamsHandler()
	{
		if ((object)cb_generateDefaultLayoutParams == null)
		{
			cb_generateDefaultLayoutParams = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GenerateDefaultLayoutParams));
		}
		return cb_generateDefaultLayoutParams;
	}

	private static IntPtr n_GenerateDefaultLayoutParams(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GenerateDefaultLayoutParams());
	}

	[Register("generateDefaultLayoutParams", "()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateDefaultLayoutParamsHandler")]
	public unsafe override RecyclerView.LayoutParams GenerateDefaultLayoutParams()
	{
		return Java.Lang.Object.GetObject<RecyclerView.LayoutParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("generateDefaultLayoutParams.()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
	{
		if ((object)cb_getExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
		{
			cb_getExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_));
		}
		return cb_getExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_;
	}

	private static int n_GetExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
	{
		LinearLayoutManager linearLayoutManager = Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		RecyclerView.State state = Java.Lang.Object.GetObject<RecyclerView.State>(native_state, JniHandleOwnership.DoNotTransfer);
		return linearLayoutManager.GetExtraLayoutSpace(state);
	}

	[Register("getExtraLayoutSpace", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetGetExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
	protected unsafe virtual int GetExtraLayoutSpace(RecyclerView.State state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getExtraLayoutSpace.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetPrepareForDrop_Landroid_view_View_Landroid_view_View_IIHandler()
	{
		if ((object)cb_prepareForDrop_Landroid_view_View_Landroid_view_View_II == null)
		{
			cb_prepareForDrop_Landroid_view_View_Landroid_view_View_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLII_V(n_PrepareForDrop_Landroid_view_View_Landroid_view_View_II));
		}
		return cb_prepareForDrop_Landroid_view_View_Landroid_view_View_II;
	}

	private static void n_PrepareForDrop_Landroid_view_View_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_target, int x, int y)
	{
		LinearLayoutManager linearLayoutManager = Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
		linearLayoutManager.PrepareForDrop(view, target, x, y);
	}

	[Register("prepareForDrop", "(Landroid/view/View;Landroid/view/View;II)V", "GetPrepareForDrop_Landroid_view_View_Landroid_view_View_IIHandler")]
	public unsafe virtual void PrepareForDrop(View view, View target, int x, int y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(x);
			ptr[3] = new JniArgumentValue(y);
			_members.InstanceMethods.InvokeVirtualVoidMethod("prepareForDrop.(Landroid/view/View;Landroid/view/View;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetScrollToPositionWithOffset_IIHandler()
	{
		if ((object)cb_scrollToPositionWithOffset_II == null)
		{
			cb_scrollToPositionWithOffset_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_ScrollToPositionWithOffset_II));
		}
		return cb_scrollToPositionWithOffset_II;
	}

	private static void n_ScrollToPositionWithOffset_II(IntPtr jnienv, IntPtr native__this, int position, int offset)
	{
		Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollToPositionWithOffset(position, offset);
	}

	[Register("scrollToPositionWithOffset", "(II)V", "GetScrollToPositionWithOffset_IIHandler")]
	public unsafe virtual void ScrollToPositionWithOffset(int position, int offset)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(position);
		ptr[1] = new JniArgumentValue(offset);
		_members.InstanceMethods.InvokeVirtualVoidMethod("scrollToPositionWithOffset.(II)V", this, ptr);
	}
}
[Register("androidx/recyclerview/widget/RecyclerView", DoNotGenerateAcw = true)]
public class RecyclerView : ViewGroup, INestedScrollingChild2, INestedScrollingChild, IJavaObject, IDisposable, IJavaPeerable, INestedScrollingChild3, IScrollingView
{
	[Register("androidx/recyclerview/widget/RecyclerView$Adapter", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "VH extends androidx.recyclerview.widget.RecyclerView.ViewHolder" })]
	public abstract class Adapter : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$Adapter", typeof(Adapter));

		private static Delegate cb_getItemCount;

		private static Delegate cb_getItemId_I;

		private static Delegate cb_getItemViewType_I;

		private static Delegate cb_onAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_;

		private static Delegate cb_onBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I;

		private static Delegate cb_onBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_;

		private static Delegate cb_onCreateViewHolder_Landroid_view_ViewGroup_I;

		private static Delegate cb_onDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_;

		private static Delegate cb_onFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_onViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_onViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_registerAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_;

		private static Delegate cb_unregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool HasObservers
		{
			[Register("hasObservers", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasObservers.()Z", this, null);
			}
		}

		public unsafe bool HasStableIds
		{
			[Register("hasStableIds", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasStableIds.()Z", this, null);
			}
			[Register("setHasStableIds", "(Z)V", "GetSetHasStableIds_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHasStableIds.(Z)V", this, ptr);
			}
		}

		public abstract int ItemCount
		{
			[Register("getItemCount", "()I", "GetGetItemCountHandler")]
			get;
		}

		protected Adapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Adapter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetItemCountHandler()
		{
			if ((object)cb_getItemCount == null)
			{
				cb_getItemCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetItemCount));
			}
			return cb_getItemCount;
		}

		private static int n_GetItemCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemCount;
		}

		[Register("bindViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", "")]
		public unsafe void BindViewHolder(ViewHolder holder, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("bindViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(holder);
			}
		}

		[Register("createViewHolder", "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "")]
		public unsafe Java.Lang.Object CreateViewHolder(ViewGroup parent, int viewType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewType);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createViewHolder.(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(parent);
			}
		}

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
			return Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemId(position);
		}

		[Register("getItemId", "(I)J", "GetGetItemId_IHandler")]
		public unsafe virtual long GetItemId(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeVirtualInt64Method("getItemId.(I)J", this, ptr);
		}

		private static Delegate GetGetItemViewType_IHandler()
		{
			if ((object)cb_getItemViewType_I == null)
			{
				cb_getItemViewType_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetItemViewType_I));
			}
			return cb_getItemViewType_I;
		}

		private static int n_GetItemViewType_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			return Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemViewType(position);
		}

		[Register("getItemViewType", "(I)I", "GetGetItemViewType_IHandler")]
		public unsafe virtual int GetItemViewType(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemViewType.(I)I", this, ptr);
		}

		[Register("notifyDataSetChanged", "()V", "")]
		public unsafe void NotifyDataSetChanged()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyDataSetChanged.()V", this, null);
		}

		[Register("notifyItemChanged", "(I)V", "")]
		public unsafe void NotifyItemChanged(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemChanged.(I)V", this, ptr);
		}

		[Register("notifyItemChanged", "(ILjava/lang/Object;)V", "")]
		public unsafe void NotifyItemChanged(int position, Java.Lang.Object payload)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(position);
				ptr[1] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemChanged.(ILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(payload);
			}
		}

		[Register("notifyItemInserted", "(I)V", "")]
		public unsafe void NotifyItemInserted(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemInserted.(I)V", this, ptr);
		}

		[Register("notifyItemMoved", "(II)V", "")]
		public unsafe void NotifyItemMoved(int fromPosition, int toPosition)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fromPosition);
			ptr[1] = new JniArgumentValue(toPosition);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemMoved.(II)V", this, ptr);
		}

		[Register("notifyItemRangeChanged", "(II)V", "")]
		public unsafe void NotifyItemRangeChanged(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemRangeChanged.(II)V", this, ptr);
		}

		[Register("notifyItemRangeChanged", "(IILjava/lang/Object;)V", "")]
		public unsafe void NotifyItemRangeChanged(int positionStart, int itemCount, Java.Lang.Object payload)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(positionStart);
				ptr[1] = new JniArgumentValue(itemCount);
				ptr[2] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemRangeChanged.(IILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(payload);
			}
		}

		[Register("notifyItemRangeInserted", "(II)V", "")]
		public unsafe void NotifyItemRangeInserted(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemRangeInserted.(II)V", this, ptr);
		}

		[Register("notifyItemRangeRemoved", "(II)V", "")]
		public unsafe void NotifyItemRangeRemoved(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemRangeRemoved.(II)V", this, ptr);
		}

		[Register("notifyItemRemoved", "(I)V", "")]
		public unsafe void NotifyItemRemoved(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemRemoved.(I)V", this, ptr);
		}

		private static Delegate GetOnAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			if ((object)cb_onAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_ == null)
			{
				cb_onAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_));
			}
			return cb_onAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_;
		}

		private static void n_OnAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			adapter.OnAttachedToRecyclerView(recyclerView);
		}

		[Register("onAttachedToRecyclerView", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnAttachedToRecyclerView(RecyclerView recyclerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToRecyclerView.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler()
		{
			if ((object)cb_onBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I == null)
			{
				cb_onBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I));
			}
			return cb_onBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I;
		}

		private static void n_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I(IntPtr jnienv, IntPtr native__this, IntPtr native_holder, int position)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder holder = Java.Lang.Object.GetObject<ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
			adapter.OnBindViewHolder(holder, position);
		}

		[Register("onBindViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", "GetOnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler")]
		public abstract void OnBindViewHolder(ViewHolder holder, int position);

		private static Delegate GetOnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_Handler()
		{
			if ((object)cb_onBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_ == null)
			{
				cb_onBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_));
			}
			return cb_onBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_;
		}

		private static void n_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_holder, int position, IntPtr native_payloads)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder holder = Java.Lang.Object.GetObject<ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
			IList<Java.Lang.Object> payloads = JavaList<Java.Lang.Object>.FromJniHandle(native_payloads, JniHandleOwnership.DoNotTransfer);
			adapter.OnBindViewHolder(holder, position, payloads);
		}

		[Register("onBindViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)V", "GetOnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_Handler")]
		public unsafe virtual void OnBindViewHolder(ViewHolder holder, int position, IList<Java.Lang.Object> payloads)
		{
			IntPtr intPtr = JavaList<Java.Lang.Object>.ToLocalJniHandle(payloads);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onBindViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(holder);
				GC.KeepAlive(payloads);
			}
		}

		private static Delegate GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler()
		{
			if ((object)cb_onCreateViewHolder_Landroid_view_ViewGroup_I == null)
			{
				cb_onCreateViewHolder_Landroid_view_ViewGroup_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_OnCreateViewHolder_Landroid_view_ViewGroup_I));
			}
			return cb_onCreateViewHolder_Landroid_view_ViewGroup_I;
		}

		private static IntPtr n_OnCreateViewHolder_Landroid_view_ViewGroup_I(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, int viewType)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(adapter.OnCreateViewHolder(parent, viewType));
		}

		[Register("onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler")]
		public abstract ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType);

		private static Delegate GetOnDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			if ((object)cb_onDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_ == null)
			{
				cb_onDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_));
			}
			return cb_onDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_;
		}

		private static void n_OnDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			adapter.OnDetachedFromRecyclerView(recyclerView);
		}

		[Register("onDetachedFromRecyclerView", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnDetachedFromRecyclerView(RecyclerView recyclerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromRecyclerView.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_onFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_onFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_onFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static bool n_OnFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_holder)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object holder = Java.Lang.Object.GetObject<Java.Lang.Object>(native_holder, JniHandleOwnership.DoNotTransfer);
			return adapter.OnFailedToRecycleView(holder);
		}

		[Register("onFailedToRecycleView", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", "GetOnFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual bool OnFailedToRecycleView(Java.Lang.Object holder)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(holder);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onFailedToRecycleView.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(holder);
			}
		}

		private static Delegate GetOnViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_onViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_onViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_onViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static void n_OnViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_holder)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object holder = Java.Lang.Object.GetObject<Java.Lang.Object>(native_holder, JniHandleOwnership.DoNotTransfer);
			adapter.OnViewAttachedToWindow(holder);
		}

		[Register("onViewAttachedToWindow", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void OnViewAttachedToWindow(Java.Lang.Object holder)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(holder);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onViewAttachedToWindow.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(holder);
			}
		}

		private static Delegate GetOnViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_onViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_onViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_onViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static void n_OnViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_holder)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object holder = Java.Lang.Object.GetObject<Java.Lang.Object>(native_holder, JniHandleOwnership.DoNotTransfer);
			adapter.OnViewDetachedFromWindow(holder);
		}

		[Register("onViewDetachedFromWindow", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void OnViewDetachedFromWindow(Java.Lang.Object holder)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(holder);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onViewDetachedFromWindow.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(holder);
			}
		}

		private static Delegate GetOnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static void n_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_holder)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object holder = Java.Lang.Object.GetObject<Java.Lang.Object>(native_holder, JniHandleOwnership.DoNotTransfer);
			adapter.OnViewRecycled(holder);
		}

		[Register("onViewRecycled", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void OnViewRecycled(Java.Lang.Object holder)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(holder);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onViewRecycled.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(holder);
			}
		}

		private static Delegate GetRegisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_Handler()
		{
			if ((object)cb_registerAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_ == null)
			{
				cb_registerAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RegisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_));
			}
			return cb_registerAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_;
		}

		private static void n_RegisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_(IntPtr jnienv, IntPtr native__this, IntPtr native_observer)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AdapterDataObserver observer = Java.Lang.Object.GetObject<AdapterDataObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			adapter.RegisterAdapterDataObserver(observer);
		}

		[Register("registerAdapterDataObserver", "(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V", "GetRegisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_Handler")]
		public unsafe virtual void RegisterAdapterDataObserver(AdapterDataObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerAdapterDataObserver.(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		private static Delegate GetUnregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_Handler()
		{
			if ((object)cb_unregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_ == null)
			{
				cb_unregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_));
			}
			return cb_unregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_;
		}

		private static void n_UnregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_(IntPtr jnienv, IntPtr native__this, IntPtr native_observer)
		{
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AdapterDataObserver observer = Java.Lang.Object.GetObject<AdapterDataObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			adapter.UnregisterAdapterDataObserver(observer);
		}

		[Register("unregisterAdapterDataObserver", "(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V", "GetUnregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_Handler")]
		public unsafe virtual void UnregisterAdapterDataObserver(AdapterDataObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterAdapterDataObserver.(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$Adapter", DoNotGenerateAcw = true)]
	internal class AdapterInvoker : Adapter
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$Adapter", typeof(AdapterInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override int ItemCount
		{
			[Register("getItemCount", "()I", "GetGetItemCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getItemCount.()I", this, null);
			}
		}

		public AdapterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onBindViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", "GetOnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler")]
		public unsafe override void OnBindViewHolder(ViewHolder holder, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onBindViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(holder);
			}
		}

		[Register("onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler")]
		public unsafe override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewType);
				return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeAbstractObjectMethod("onCreateViewHolder.(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(parent);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$AdapterDataObserver", DoNotGenerateAcw = true)]
	public abstract class AdapterDataObserver : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$AdapterDataObserver", typeof(AdapterDataObserver));

		private static Delegate cb_onChanged;

		private static Delegate cb_onItemRangeChanged_II;

		private static Delegate cb_onItemRangeChanged_IILjava_lang_Object_;

		private static Delegate cb_onItemRangeInserted_II;

		private static Delegate cb_onItemRangeMoved_III;

		private static Delegate cb_onItemRangeRemoved_II;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected AdapterDataObserver(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AdapterDataObserver()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnChangedHandler()
		{
			if ((object)cb_onChanged == null)
			{
				cb_onChanged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnChanged));
			}
			return cb_onChanged;
		}

		private static void n_OnChanged(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnChanged();
		}

		[Register("onChanged", "()V", "GetOnChangedHandler")]
		public unsafe virtual void OnChanged()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onChanged.()V", this, null);
		}

		private static Delegate GetOnItemRangeChanged_IIHandler()
		{
			if ((object)cb_onItemRangeChanged_II == null)
			{
				cb_onItemRangeChanged_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_OnItemRangeChanged_II));
			}
			return cb_onItemRangeChanged_II;
		}

		private static void n_OnItemRangeChanged_II(IntPtr jnienv, IntPtr native__this, int positionStart, int itemCount)
		{
			Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnItemRangeChanged(positionStart, itemCount);
		}

		[Register("onItemRangeChanged", "(II)V", "GetOnItemRangeChanged_IIHandler")]
		public unsafe virtual void OnItemRangeChanged(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onItemRangeChanged.(II)V", this, ptr);
		}

		private static Delegate GetOnItemRangeChanged_IILjava_lang_Object_Handler()
		{
			if ((object)cb_onItemRangeChanged_IILjava_lang_Object_ == null)
			{
				cb_onItemRangeChanged_IILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIL_V(n_OnItemRangeChanged_IILjava_lang_Object_));
			}
			return cb_onItemRangeChanged_IILjava_lang_Object_;
		}

		private static void n_OnItemRangeChanged_IILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int positionStart, int itemCount, IntPtr native_payload)
		{
			AdapterDataObserver adapterDataObserver = Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object payload = Java.Lang.Object.GetObject<Java.Lang.Object>(native_payload, JniHandleOwnership.DoNotTransfer);
			adapterDataObserver.OnItemRangeChanged(positionStart, itemCount, payload);
		}

		[Register("onItemRangeChanged", "(IILjava/lang/Object;)V", "GetOnItemRangeChanged_IILjava_lang_Object_Handler")]
		public unsafe virtual void OnItemRangeChanged(int positionStart, int itemCount, Java.Lang.Object payload)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(positionStart);
				ptr[1] = new JniArgumentValue(itemCount);
				ptr[2] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemRangeChanged.(IILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(payload);
			}
		}

		private static Delegate GetOnItemRangeInserted_IIHandler()
		{
			if ((object)cb_onItemRangeInserted_II == null)
			{
				cb_onItemRangeInserted_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_OnItemRangeInserted_II));
			}
			return cb_onItemRangeInserted_II;
		}

		private static void n_OnItemRangeInserted_II(IntPtr jnienv, IntPtr native__this, int positionStart, int itemCount)
		{
			Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnItemRangeInserted(positionStart, itemCount);
		}

		[Register("onItemRangeInserted", "(II)V", "GetOnItemRangeInserted_IIHandler")]
		public unsafe virtual void OnItemRangeInserted(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onItemRangeInserted.(II)V", this, ptr);
		}

		private static Delegate GetOnItemRangeMoved_IIIHandler()
		{
			if ((object)cb_onItemRangeMoved_III == null)
			{
				cb_onItemRangeMoved_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_V(n_OnItemRangeMoved_III));
			}
			return cb_onItemRangeMoved_III;
		}

		private static void n_OnItemRangeMoved_III(IntPtr jnienv, IntPtr native__this, int fromPosition, int toPosition, int itemCount)
		{
			Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnItemRangeMoved(fromPosition, toPosition, itemCount);
		}

		[Register("onItemRangeMoved", "(III)V", "GetOnItemRangeMoved_IIIHandler")]
		public unsafe virtual void OnItemRangeMoved(int fromPosition, int toPosition, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(fromPosition);
			ptr[1] = new JniArgumentValue(toPosition);
			ptr[2] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onItemRangeMoved.(III)V", this, ptr);
		}

		private static Delegate GetOnItemRangeRemoved_IIHandler()
		{
			if ((object)cb_onItemRangeRemoved_II == null)
			{
				cb_onItemRangeRemoved_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_OnItemRangeRemoved_II));
			}
			return cb_onItemRangeRemoved_II;
		}

		private static void n_OnItemRangeRemoved_II(IntPtr jnienv, IntPtr native__this, int positionStart, int itemCount)
		{
			Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnItemRangeRemoved(positionStart, itemCount);
		}

		[Register("onItemRangeRemoved", "(II)V", "GetOnItemRangeRemoved_IIHandler")]
		public unsafe virtual void OnItemRangeRemoved(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onItemRangeRemoved.(II)V", this, ptr);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$AdapterDataObserver", DoNotGenerateAcw = true)]
	internal class AdapterDataObserverInvoker : AdapterDataObserver
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$AdapterDataObserver", typeof(AdapterDataObserverInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public AdapterDataObserverInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ChildDrawingOrderCallback", "", "AndroidX.RecyclerView.Widget.RecyclerView/IChildDrawingOrderCallbackInvoker")]
	public interface IChildDrawingOrderCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onGetChildDrawingOrder", "(II)I", "GetOnGetChildDrawingOrder_IIHandler:AndroidX.RecyclerView.Widget.RecyclerView/IChildDrawingOrderCallbackInvoker, Xamarin.AndroidX.RecyclerView")]
		int OnGetChildDrawingOrder(int childCount, int i);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ChildDrawingOrderCallback", DoNotGenerateAcw = true)]
	internal class IChildDrawingOrderCallbackInvoker : Java.Lang.Object, IChildDrawingOrderCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ChildDrawingOrderCallback", typeof(IChildDrawingOrderCallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onGetChildDrawingOrder_II;

		private IntPtr id_onGetChildDrawingOrder_II;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IChildDrawingOrderCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IChildDrawingOrderCallback>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.recyclerview.widget.RecyclerView.ChildDrawingOrderCallback"));
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

		public IChildDrawingOrderCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnGetChildDrawingOrder_IIHandler()
		{
			if ((object)cb_onGetChildDrawingOrder_II == null)
			{
				cb_onGetChildDrawingOrder_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_I(n_OnGetChildDrawingOrder_II));
			}
			return cb_onGetChildDrawingOrder_II;
		}

		private static int n_OnGetChildDrawingOrder_II(IntPtr jnienv, IntPtr native__this, int childCount, int i)
		{
			return Java.Lang.Object.GetObject<IChildDrawingOrderCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnGetChildDrawingOrder(childCount, i);
		}

		public unsafe int OnGetChildDrawingOrder(int childCount, int i)
		{
			if (id_onGetChildDrawingOrder_II == IntPtr.Zero)
			{
				id_onGetChildDrawingOrder_II = JNIEnv.GetMethodID(class_ref, "onGetChildDrawingOrder", "(II)I");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(childCount);
			ptr[1] = new JValue(i);
			return JNIEnv.CallIntMethod(base.Handle, id_onGetChildDrawingOrder_II, ptr);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$EdgeEffectFactory", DoNotGenerateAcw = true)]
	public class EdgeEffectFactory : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$EdgeEffectFactory", typeof(EdgeEffectFactory));

		private static Delegate cb_createEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected EdgeEffectFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EdgeEffectFactory()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCreateEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_IHandler()
		{
			if ((object)cb_createEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_I == null)
			{
				cb_createEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_CreateEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_I));
			}
			return cb_createEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_I;
		}

		private static IntPtr n_CreateEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_I(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int direction)
		{
			EdgeEffectFactory edgeEffectFactory = Java.Lang.Object.GetObject<EdgeEffectFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView view = Java.Lang.Object.GetObject<RecyclerView>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(edgeEffectFactory.CreateEdgeEffect(view, direction));
		}

		[Register("createEdgeEffect", "(Landroidx/recyclerview/widget/RecyclerView;I)Landroid/widget/EdgeEffect;", "GetCreateEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_IHandler")]
		protected unsafe virtual EdgeEffect CreateEdgeEffect(RecyclerView view, int direction)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(direction);
				return Java.Lang.Object.GetObject<EdgeEffect>(_members.InstanceMethods.InvokeVirtualObjectMethod("createEdgeEffect.(Landroidx/recyclerview/widget/RecyclerView;I)Landroid/widget/EdgeEffect;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ItemAnimator", DoNotGenerateAcw = true)]
	public abstract class ItemAnimator : Java.Lang.Object
	{
		[Register("androidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener", "", "AndroidX.RecyclerView.Widget.RecyclerView/ItemAnimator/IItemAnimatorFinishedListenerInvoker")]
		public interface IItemAnimatorFinishedListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onAnimationsFinished", "()V", "GetOnAnimationsFinishedHandler:AndroidX.RecyclerView.Widget.RecyclerView/ItemAnimator/IItemAnimatorFinishedListenerInvoker, Xamarin.AndroidX.RecyclerView")]
			void OnAnimationsFinished();
		}

		[Register("androidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener", DoNotGenerateAcw = true)]
		internal class IItemAnimatorFinishedListenerInvoker : Java.Lang.Object, IItemAnimatorFinishedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener", typeof(IItemAnimatorFinishedListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onAnimationsFinished;

			private IntPtr id_onAnimationsFinished;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IItemAnimatorFinishedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IItemAnimatorFinishedListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.recyclerview.widget.RecyclerView.ItemAnimator.ItemAnimatorFinishedListener"));
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

			public IItemAnimatorFinishedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnAnimationsFinishedHandler()
			{
				if ((object)cb_onAnimationsFinished == null)
				{
					cb_onAnimationsFinished = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnAnimationsFinished));
				}
				return cb_onAnimationsFinished;
			}

			private static void n_OnAnimationsFinished(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IItemAnimatorFinishedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAnimationsFinished();
			}

			public void OnAnimationsFinished()
			{
				if (id_onAnimationsFinished == IntPtr.Zero)
				{
					id_onAnimationsFinished = JNIEnv.GetMethodID(class_ref, "onAnimationsFinished", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onAnimationsFinished);
			}
		}

		[Register("androidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo", DoNotGenerateAcw = true)]
		public class ItemHolderInfo : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo", typeof(ItemHolderInfo));

			private static Delegate cb_setFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

			private static Delegate cb_setFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I;

			[Register("bottom")]
			public int Bottom
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("bottom.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("bottom.I", this, value);
				}
			}

			[Register("changeFlags")]
			public int ChangeFlags
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("changeFlags.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("changeFlags.I", this, value);
				}
			}

			[Register("left")]
			public int Left
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("left.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("left.I", this, value);
				}
			}

			[Register("right")]
			public int Right
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("right.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("right.I", this, value);
				}
			}

			[Register("top")]
			public int Top
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("top.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("top.I", this, value);
				}
			}

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected ItemHolderInfo(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe ItemHolderInfo()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetSetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
			{
				if ((object)cb_setFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
				{
					cb_setFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
				}
				return cb_setFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
			}

			private static IntPtr n_SetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_holder)
			{
				ItemHolderInfo itemHolderInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(itemHolderInfo.SetFrom(viewHolder));
			}

			[Register("setFrom", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", "GetSetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
			public unsafe virtual ItemHolderInfo SetFrom(ViewHolder holder)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<ItemHolderInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFrom.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(holder);
				}
			}

			private static Delegate GetSetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler()
			{
				if ((object)cb_setFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I == null)
				{
					cb_setFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_SetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I));
				}
				return cb_setFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I;
			}

			private static IntPtr n_SetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I(IntPtr jnienv, IntPtr native__this, IntPtr native_holder, int flags)
			{
				ItemHolderInfo itemHolderInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder holder = Java.Lang.Object.GetObject<ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(itemHolderInfo.SetFrom(holder, flags));
			}

			[Register("setFrom", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", "GetSetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler")]
			public unsafe virtual ItemHolderInfo SetFrom(ViewHolder holder, int flags)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(flags);
					return Java.Lang.Object.GetObject<ItemHolderInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFrom.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(holder);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemAnimator", typeof(ItemAnimator));

		private static Delegate cb_getAddDuration;

		private static Delegate cb_setAddDuration_J;

		private static Delegate cb_getChangeDuration;

		private static Delegate cb_setChangeDuration_J;

		private static Delegate cb_isRunning;

		private static Delegate cb_getMoveDuration;

		private static Delegate cb_setMoveDuration_J;

		private static Delegate cb_getRemoveDuration;

		private static Delegate cb_setRemoveDuration_J;

		private static Delegate cb_animateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;

		private static Delegate cb_animateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;

		private static Delegate cb_animateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;

		private static Delegate cb_animatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;

		private static Delegate cb_canReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_canReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_;

		private static Delegate cb_endAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_endAnimations;

		private static Delegate cb_obtainHolderInfo;

		private static Delegate cb_onAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_onAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_recordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_recordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_;

		private static Delegate cb_runPendingAnimations;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual long AddDuration
		{
			[Register("getAddDuration", "()J", "GetGetAddDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getAddDuration.()J", this, null);
			}
			[Register("setAddDuration", "(J)V", "GetSetAddDuration_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAddDuration.(J)V", this, ptr);
			}
		}

		public unsafe virtual long ChangeDuration
		{
			[Register("getChangeDuration", "()J", "GetGetChangeDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getChangeDuration.()J", this, null);
			}
			[Register("setChangeDuration", "(J)V", "GetSetChangeDuration_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setChangeDuration.(J)V", this, ptr);
			}
		}

		public abstract bool IsRunning
		{
			[Register("isRunning", "()Z", "GetIsRunningHandler")]
			get;
		}

		public unsafe virtual long MoveDuration
		{
			[Register("getMoveDuration", "()J", "GetGetMoveDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getMoveDuration.()J", this, null);
			}
			[Register("setMoveDuration", "(J)V", "GetSetMoveDuration_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMoveDuration.(J)V", this, ptr);
			}
		}

		public unsafe virtual long RemoveDuration
		{
			[Register("getRemoveDuration", "()J", "GetGetRemoveDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getRemoveDuration.()J", this, null);
			}
			[Register("setRemoveDuration", "(J)V", "GetSetRemoveDuration_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRemoveDuration.(J)V", this, ptr);
			}
		}

		protected ItemAnimator(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ItemAnimator()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetAddDurationHandler()
		{
			if ((object)cb_getAddDuration == null)
			{
				cb_getAddDuration = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetAddDuration));
			}
			return cb_getAddDuration;
		}

		private static long n_GetAddDuration(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddDuration;
		}

		private static Delegate GetSetAddDuration_JHandler()
		{
			if ((object)cb_setAddDuration_J == null)
			{
				cb_setAddDuration_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_SetAddDuration_J));
			}
			return cb_setAddDuration_J;
		}

		private static void n_SetAddDuration_J(IntPtr jnienv, IntPtr native__this, long addDuration)
		{
			Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddDuration = addDuration;
		}

		private static Delegate GetGetChangeDurationHandler()
		{
			if ((object)cb_getChangeDuration == null)
			{
				cb_getChangeDuration = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetChangeDuration));
			}
			return cb_getChangeDuration;
		}

		private static long n_GetChangeDuration(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChangeDuration;
		}

		private static Delegate GetSetChangeDuration_JHandler()
		{
			if ((object)cb_setChangeDuration_J == null)
			{
				cb_setChangeDuration_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_SetChangeDuration_J));
			}
			return cb_setChangeDuration_J;
		}

		private static void n_SetChangeDuration_J(IntPtr jnienv, IntPtr native__this, long changeDuration)
		{
			Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChangeDuration = changeDuration;
		}

		private static Delegate GetIsRunningHandler()
		{
			if ((object)cb_isRunning == null)
			{
				cb_isRunning = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRunning));
			}
			return cb_isRunning;
		}

		private static bool n_IsRunning(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRunning;
		}

		private static Delegate GetGetMoveDurationHandler()
		{
			if ((object)cb_getMoveDuration == null)
			{
				cb_getMoveDuration = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetMoveDuration));
			}
			return cb_getMoveDuration;
		}

		private static long n_GetMoveDuration(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveDuration;
		}

		private static Delegate GetSetMoveDuration_JHandler()
		{
			if ((object)cb_setMoveDuration_J == null)
			{
				cb_setMoveDuration_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_SetMoveDuration_J));
			}
			return cb_setMoveDuration_J;
		}

		private static void n_SetMoveDuration_J(IntPtr jnienv, IntPtr native__this, long moveDuration)
		{
			Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveDuration = moveDuration;
		}

		private static Delegate GetGetRemoveDurationHandler()
		{
			if ((object)cb_getRemoveDuration == null)
			{
				cb_getRemoveDuration = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetRemoveDuration));
			}
			return cb_getRemoveDuration;
		}

		private static long n_GetRemoveDuration(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveDuration;
		}

		private static Delegate GetSetRemoveDuration_JHandler()
		{
			if ((object)cb_setRemoveDuration_J == null)
			{
				cb_setRemoveDuration_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_SetRemoveDuration_J));
			}
			return cb_setRemoveDuration_J;
		}

		private static void n_SetRemoveDuration_J(IntPtr jnienv, IntPtr native__this, long removeDuration)
		{
			Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveDuration = removeDuration;
		}

		private static Delegate GetAnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler()
		{
			if ((object)cb_animateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_ == null)
			{
				cb_animateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_AnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_));
			}
			return cb_animateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;
		}

		private static bool n_AnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder, IntPtr native_preLayoutInfo, IntPtr native_postLayoutInfo)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			ItemHolderInfo preLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_preLayoutInfo, JniHandleOwnership.DoNotTransfer);
			ItemHolderInfo postLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_postLayoutInfo, JniHandleOwnership.DoNotTransfer);
			return itemAnimator.AnimateAppearance(viewHolder, preLayoutInfo, postLayoutInfo);
		}

		[Register("animateAppearance", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public abstract bool AnimateAppearance(ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo);

		private static Delegate GetAnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler()
		{
			if ((object)cb_animateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_ == null)
			{
				cb_animateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLL_Z(n_AnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_));
			}
			return cb_animateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;
		}

		private static bool n_AnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_oldHolder, IntPtr native_newHolder, IntPtr native_preLayoutInfo, IntPtr native_postLayoutInfo)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder oldHolder = Java.Lang.Object.GetObject<ViewHolder>(native_oldHolder, JniHandleOwnership.DoNotTransfer);
			ViewHolder newHolder = Java.Lang.Object.GetObject<ViewHolder>(native_newHolder, JniHandleOwnership.DoNotTransfer);
			ItemHolderInfo preLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_preLayoutInfo, JniHandleOwnership.DoNotTransfer);
			ItemHolderInfo postLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_postLayoutInfo, JniHandleOwnership.DoNotTransfer);
			return itemAnimator.AnimateChange(oldHolder, newHolder, preLayoutInfo, postLayoutInfo);
		}

		[Register("animateChange", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public abstract bool AnimateChange(ViewHolder oldHolder, ViewHolder newHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo);

		private static Delegate GetAnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler()
		{
			if ((object)cb_animateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_ == null)
			{
				cb_animateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_AnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_));
			}
			return cb_animateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;
		}

		private static bool n_AnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder, IntPtr native_preLayoutInfo, IntPtr native_postLayoutInfo)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			ItemHolderInfo preLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_preLayoutInfo, JniHandleOwnership.DoNotTransfer);
			ItemHolderInfo postLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_postLayoutInfo, JniHandleOwnership.DoNotTransfer);
			return itemAnimator.AnimateDisappearance(viewHolder, preLayoutInfo, postLayoutInfo);
		}

		[Register("animateDisappearance", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public abstract bool AnimateDisappearance(ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo);

		private static Delegate GetAnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler()
		{
			if ((object)cb_animatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_ == null)
			{
				cb_animatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_AnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_));
			}
			return cb_animatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;
		}

		private static bool n_AnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder, IntPtr native_preLayoutInfo, IntPtr native_postLayoutInfo)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			ItemHolderInfo preLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_preLayoutInfo, JniHandleOwnership.DoNotTransfer);
			ItemHolderInfo postLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_postLayoutInfo, JniHandleOwnership.DoNotTransfer);
			return itemAnimator.AnimatePersistence(viewHolder, preLayoutInfo, postLayoutInfo);
		}

		[Register("animatePersistence", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public abstract bool AnimatePersistence(ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo);

		private static Delegate GetCanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_canReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_canReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_CanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_canReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static bool n_CanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			return itemAnimator.CanReuseUpdatedViewHolder(viewHolder);
		}

		[Register("canReuseUpdatedViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", "GetCanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual bool CanReuseUpdatedViewHolder(ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canReuseUpdatedViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetCanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_Handler()
		{
			if ((object)cb_canReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_ == null)
			{
				cb_canReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_CanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_));
			}
			return cb_canReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_;
		}

		private static bool n_CanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder, IntPtr native_payloads)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			IList<Java.Lang.Object> payloads = JavaList<Java.Lang.Object>.FromJniHandle(native_payloads, JniHandleOwnership.DoNotTransfer);
			return itemAnimator.CanReuseUpdatedViewHolder(viewHolder, payloads);
		}

		[Register("canReuseUpdatedViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Ljava/util/List;)Z", "GetCanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_Handler")]
		public unsafe virtual bool CanReuseUpdatedViewHolder(ViewHolder viewHolder, IList<Java.Lang.Object> payloads)
		{
			IntPtr intPtr = JavaList<Java.Lang.Object>.ToLocalJniHandle(payloads);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canReuseUpdatedViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Ljava/util/List;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(payloads);
			}
		}

		[Register("dispatchAnimationFinished", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "")]
		public unsafe void DispatchAnimationFinished(ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchAnimationFinished.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		[Register("dispatchAnimationStarted", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "")]
		public unsafe void DispatchAnimationStarted(ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchAnimationStarted.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		[Register("dispatchAnimationsFinished", "()V", "")]
		public unsafe void DispatchAnimationsFinished()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchAnimationsFinished.()V", this, null);
		}

		private static Delegate GetEndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_endAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_endAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_EndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_endAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static void n_EndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_item)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder item = Java.Lang.Object.GetObject<ViewHolder>(native_item, JniHandleOwnership.DoNotTransfer);
			itemAnimator.EndAnimation(item);
		}

		[Register("endAnimation", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetEndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public abstract void EndAnimation(ViewHolder item);

		private static Delegate GetEndAnimationsHandler()
		{
			if ((object)cb_endAnimations == null)
			{
				cb_endAnimations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_EndAnimations));
			}
			return cb_endAnimations;
		}

		private static void n_EndAnimations(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndAnimations();
		}

		[Register("endAnimations", "()V", "GetEndAnimationsHandler")]
		public abstract void EndAnimations();

		[Register("isRunning", "(Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener;)Z", "")]
		public unsafe bool InvokeIsRunning(IItemAnimatorFinishedListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isRunning.(Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetObtainHolderInfoHandler()
		{
			if ((object)cb_obtainHolderInfo == null)
			{
				cb_obtainHolderInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ObtainHolderInfo));
			}
			return cb_obtainHolderInfo;
		}

		private static IntPtr n_ObtainHolderInfo(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ObtainHolderInfo());
		}

		[Register("obtainHolderInfo", "()Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", "GetObtainHolderInfoHandler")]
		public unsafe virtual ItemHolderInfo ObtainHolderInfo()
		{
			return Java.Lang.Object.GetObject<ItemHolderInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("obtainHolderInfo.()Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetOnAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_onAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_onAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_onAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static void n_OnAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			itemAnimator.OnAnimationFinished(viewHolder);
		}

		[Register("onAnimationFinished", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void OnAnimationFinished(ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAnimationFinished.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetOnAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_onAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_onAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_onAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static void n_OnAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewHolder)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			itemAnimator.OnAnimationStarted(viewHolder);
		}

		[Register("onAnimationStarted", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void OnAnimationStarted(ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAnimationStarted.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetRecordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_recordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_recordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RecordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_recordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static IntPtr n_RecordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_state, IntPtr native_viewHolder)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(itemAnimator.RecordPostLayoutInformation(state, viewHolder));
		}

		[Register("recordPostLayoutInformation", "(Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", "GetRecordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual ItemHolderInfo RecordPostLayoutInformation(State state, ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ItemHolderInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("recordPostLayoutInformation.(Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(state);
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetRecordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_Handler()
		{
			if ((object)cb_recordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_ == null)
			{
				cb_recordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLIL_L(n_RecordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_));
			}
			return cb_recordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_;
		}

		private static IntPtr n_RecordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_state, IntPtr native_viewHolder, int changeFlags, IntPtr native_payloads)
		{
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
			IList<Java.Lang.Object> payloads = JavaList<Java.Lang.Object>.FromJniHandle(native_payloads, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(itemAnimator.RecordPreLayoutInformation(state, viewHolder, changeFlags, payloads));
		}

		[Register("recordPreLayoutInformation", "(Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", "GetRecordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_Handler")]
		public unsafe virtual ItemHolderInfo RecordPreLayoutInformation(State state, ViewHolder viewHolder, int changeFlags, IList<Java.Lang.Object> payloads)
		{
			IntPtr intPtr = JavaList<Java.Lang.Object>.ToLocalJniHandle(payloads);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(changeFlags);
				ptr[3] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ItemHolderInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("recordPreLayoutInformation.(Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(state);
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(payloads);
			}
		}

		private static Delegate GetRunPendingAnimationsHandler()
		{
			if ((object)cb_runPendingAnimations == null)
			{
				cb_runPendingAnimations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RunPendingAnimations));
			}
			return cb_runPendingAnimations;
		}

		private static void n_RunPendingAnimations(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RunPendingAnimations();
		}

		[Register("runPendingAnimations", "()V", "GetRunPendingAnimationsHandler")]
		public abstract void RunPendingAnimations();
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ItemAnimator", DoNotGenerateAcw = true)]
	internal class ItemAnimatorInvoker : ItemAnimator
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemAnimator", typeof(ItemAnimatorInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsRunning
		{
			[Register("isRunning", "()Z", "GetIsRunningHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isRunning.()Z", this, null);
			}
		}

		public ItemAnimatorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("animateAppearance", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public unsafe override bool AnimateAppearance(ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(preLayoutInfo?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(postLayoutInfo?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("animateAppearance.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(preLayoutInfo);
				GC.KeepAlive(postLayoutInfo);
			}
		}

		[Register("animateChange", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public unsafe override bool AnimateChange(ViewHolder oldHolder, ViewHolder newHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(oldHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newHolder?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(preLayoutInfo?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(postLayoutInfo?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("animateChange.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(oldHolder);
				GC.KeepAlive(newHolder);
				GC.KeepAlive(preLayoutInfo);
				GC.KeepAlive(postLayoutInfo);
			}
		}

		[Register("animateDisappearance", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public unsafe override bool AnimateDisappearance(ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(preLayoutInfo?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(postLayoutInfo?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("animateDisappearance.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(preLayoutInfo);
				GC.KeepAlive(postLayoutInfo);
			}
		}

		[Register("animatePersistence", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public unsafe override bool AnimatePersistence(ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(preLayoutInfo?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(postLayoutInfo?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("animatePersistence.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(preLayoutInfo);
				GC.KeepAlive(postLayoutInfo);
			}
		}

		[Register("endAnimation", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetEndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe override void EndAnimation(ViewHolder item)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(item?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("endAnimation.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(item);
			}
		}

		[Register("endAnimations", "()V", "GetEndAnimationsHandler")]
		public unsafe override void EndAnimations()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("endAnimations.()V", this, null);
		}

		[Register("runPendingAnimations", "()V", "GetRunPendingAnimationsHandler")]
		public unsafe override void RunPendingAnimations()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("runPendingAnimations.()V", this, null);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ItemDecoration", DoNotGenerateAcw = true)]
	public abstract class ItemDecoration : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemDecoration", typeof(ItemDecoration));

		private static Delegate cb_getItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_getItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_;

		private static Delegate cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_;

		private static Delegate cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_;

		private static Delegate cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ItemDecoration(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ItemDecoration()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_getItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_getItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_GetItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_getItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static void n_GetItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_outRect, IntPtr native_view, IntPtr native_parent, IntPtr native_state)
		{
			ItemDecoration itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect outRect = Java.Lang.Object.GetObject<Rect>(native_outRect, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			itemDecoration.GetItemOffsets(outRect, view, parent, state);
		}

		[Register("getItemOffsets", "(Landroid/graphics/Rect;Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", "GetGetItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual void GetItemOffsets(Rect outRect, View view, RecyclerView parent, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(outRect?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getItemOffsets.(Landroid/graphics/Rect;Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(outRect);
				GC.KeepAlive(view);
				GC.KeepAlive(parent);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetGetItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_Handler()
		{
			if ((object)cb_getItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_ == null)
			{
				cb_getItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_GetItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_));
			}
			return cb_getItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_;
		}

		private static void n_GetItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_(IntPtr jnienv, IntPtr native__this, IntPtr native_outRect, int itemPosition, IntPtr native_parent)
		{
			ItemDecoration itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect outRect = Java.Lang.Object.GetObject<Rect>(native_outRect, JniHandleOwnership.DoNotTransfer);
			RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
			itemDecoration.GetItemOffsets(outRect, itemPosition, parent);
		}

		[Register("getItemOffsets", "(Landroid/graphics/Rect;ILandroidx/recyclerview/widget/RecyclerView;)V", "GetGetItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void GetItemOffsets(Rect outRect, int itemPosition, RecyclerView parent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(outRect?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(itemPosition);
				ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getItemOffsets.(Landroid/graphics/Rect;ILandroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(outRect);
				GC.KeepAlive(parent);
			}
		}

		private static Delegate GetOnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			if ((object)cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_ == null)
			{
				cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_));
			}
			return cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_;
		}

		private static void n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_(IntPtr jnienv, IntPtr native__this, IntPtr native_c, IntPtr native_parent)
		{
			ItemDecoration itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
			itemDecoration.OnDraw(c, parent);
		}

		[Register("onDraw", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnDraw(Canvas c, RecyclerView parent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(parent);
			}
		}

		private static Delegate GetOnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_onDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static void n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_c, IntPtr native_parent, IntPtr native_state)
		{
			ItemDecoration itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			itemDecoration.OnDraw(c, parent, state);
		}

		[Register("onDraw", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", "GetOnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual void OnDraw(Canvas c, RecyclerView parent, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(parent);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			if ((object)cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_ == null)
			{
				cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_));
			}
			return cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_;
		}

		private static void n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_(IntPtr jnienv, IntPtr native__this, IntPtr native_c, IntPtr native_parent)
		{
			ItemDecoration itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
			itemDecoration.OnDrawOver(c, parent);
		}

		[Register("onDrawOver", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnDrawOver(Canvas c, RecyclerView parent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDrawOver.(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(parent);
			}
		}

		private static Delegate GetOnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_onDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static void n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_c, IntPtr native_parent, IntPtr native_state)
		{
			ItemDecoration itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			itemDecoration.OnDrawOver(c, parent, state);
		}

		[Register("onDrawOver", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", "GetOnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual void OnDrawOver(Canvas c, RecyclerView parent, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDrawOver.(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(parent);
				GC.KeepAlive(state);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ItemDecoration", DoNotGenerateAcw = true)]
	internal class ItemDecorationInvoker : ItemDecoration
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemDecoration", typeof(ItemDecorationInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public ItemDecorationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$LayoutManager", DoNotGenerateAcw = true)]
	public abstract class LayoutManager : Java.Lang.Object
	{
		[Register("androidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry", "", "AndroidX.RecyclerView.Widget.RecyclerView/LayoutManager/ILayoutPrefetchRegistryInvoker")]
		public interface ILayoutPrefetchRegistry : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("addPosition", "(II)V", "GetAddPosition_IIHandler:AndroidX.RecyclerView.Widget.RecyclerView/LayoutManager/ILayoutPrefetchRegistryInvoker, Xamarin.AndroidX.RecyclerView")]
			void AddPosition(int layoutPosition, int pixelDistance);
		}

		[Register("androidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry", DoNotGenerateAcw = true)]
		internal class ILayoutPrefetchRegistryInvoker : Java.Lang.Object, ILayoutPrefetchRegistry, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry", typeof(ILayoutPrefetchRegistryInvoker));

			private IntPtr class_ref;

			private static Delegate cb_addPosition_II;

			private IntPtr id_addPosition_II;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public static ILayoutPrefetchRegistry GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ILayoutPrefetchRegistry>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.recyclerview.widget.RecyclerView.LayoutManager.LayoutPrefetchRegistry"));
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

			public ILayoutPrefetchRegistryInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetAddPosition_IIHandler()
			{
				if ((object)cb_addPosition_II == null)
				{
					cb_addPosition_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_AddPosition_II));
				}
				return cb_addPosition_II;
			}

			private static void n_AddPosition_II(IntPtr jnienv, IntPtr native__this, int layoutPosition, int pixelDistance)
			{
				Java.Lang.Object.GetObject<ILayoutPrefetchRegistry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddPosition(layoutPosition, pixelDistance);
			}

			public unsafe void AddPosition(int layoutPosition, int pixelDistance)
			{
				if (id_addPosition_II == IntPtr.Zero)
				{
					id_addPosition_II = JNIEnv.GetMethodID(class_ref, "addPosition", "(II)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(layoutPosition);
				ptr[1] = new JValue(pixelDistance);
				JNIEnv.CallVoidMethod(base.Handle, id_addPosition_II, ptr);
			}
		}

		[Register("androidx/recyclerview/widget/RecyclerView$LayoutManager$Properties", DoNotGenerateAcw = true)]
		public class Properties : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$LayoutManager$Properties", typeof(Properties));

			[Register("orientation")]
			public int Orientation
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("orientation.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("orientation.I", this, value);
				}
			}

			[Register("reverseLayout")]
			public bool ReverseLayout
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("reverseLayout.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("reverseLayout.Z", this, value);
				}
			}

			[Register("spanCount")]
			public int SpanCount
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("spanCount.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("spanCount.I", this, value);
				}
			}

			[Register("stackFromEnd")]
			public bool StackFromEnd
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("stackFromEnd.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("stackFromEnd.Z", this, value);
				}
			}

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected Properties(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Properties()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$LayoutManager", typeof(LayoutManager));

		private static Delegate cb_isAutoMeasureEnabled;

		private static Delegate cb_setAutoMeasureEnabled_Z;

		private static Delegate cb_getBaseline;

		private static Delegate cb_getChildCount;

		private static Delegate cb_getClipToPadding;

		private static Delegate cb_getFocusedChild;

		private static Delegate cb_hasFocus;

		private static Delegate cb_getHeight;

		private static Delegate cb_getHeightMode;

		private static Delegate cb_isAttachedToWindow;

		private static Delegate cb_isFocused;

		private static Delegate cb_isSmoothScrolling;

		private static Delegate cb_getItemCount;

		private static Delegate cb_getLayoutDirection;

		private static Delegate cb_isMeasurementCacheEnabled;

		private static Delegate cb_setMeasurementCacheEnabled_Z;

		private static Delegate cb_getMinimumHeight;

		private static Delegate cb_getMinimumWidth;

		private static Delegate cb_getPaddingBottom;

		private static Delegate cb_getPaddingEnd;

		private static Delegate cb_getPaddingLeft;

		private static Delegate cb_getPaddingRight;

		private static Delegate cb_getPaddingStart;

		private static Delegate cb_getPaddingTop;

		private static Delegate cb_getWidth;

		private static Delegate cb_getWidthMode;

		private static Delegate cb_addDisappearingView_Landroid_view_View_;

		private static Delegate cb_addDisappearingView_Landroid_view_View_I;

		private static Delegate cb_addView_Landroid_view_View_;

		private static Delegate cb_addView_Landroid_view_View_I;

		private static Delegate cb_assertInLayoutOrScroll_Ljava_lang_String_;

		private static Delegate cb_assertNotInLayoutOrScroll_Ljava_lang_String_;

		private static Delegate cb_attachView_Landroid_view_View_;

		private static Delegate cb_attachView_Landroid_view_View_I;

		private static Delegate cb_attachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_;

		private static Delegate cb_calculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_;

		private static Delegate cb_canScrollHorizontally;

		private static Delegate cb_canScrollVertically;

		private static Delegate cb_checkLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_;

		private static Delegate cb_collectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_;

		private static Delegate cb_collectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_;

		private static Delegate cb_computeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_computeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_computeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_computeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_computeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_computeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_detachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_;

		private static Delegate cb_detachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_;

		private static Delegate cb_detachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_;

		private static Delegate cb_detachView_Landroid_view_View_;

		private static Delegate cb_detachViewAt_I;

		private static Delegate cb_endAnimation_Landroid_view_View_;

		private static Delegate cb_findContainingItemView_Landroid_view_View_;

		private static Delegate cb_findViewByPosition_I;

		private static Delegate cb_generateDefaultLayoutParams;

		private static Delegate cb_generateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_;

		private static Delegate cb_generateLayoutParams_Landroid_view_ViewGroup_LayoutParams_;

		private static Delegate cb_getBottomDecorationHeight_Landroid_view_View_;

		private static Delegate cb_getChildAt_I;

		private static Delegate cb_getColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_getDecoratedBottom_Landroid_view_View_;

		private static Delegate cb_getDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_;

		private static Delegate cb_getDecoratedLeft_Landroid_view_View_;

		private static Delegate cb_getDecoratedMeasuredHeight_Landroid_view_View_;

		private static Delegate cb_getDecoratedMeasuredWidth_Landroid_view_View_;

		private static Delegate cb_getDecoratedRight_Landroid_view_View_;

		private static Delegate cb_getDecoratedTop_Landroid_view_View_;

		private static Delegate cb_getItemViewType_Landroid_view_View_;

		private static Delegate cb_getLeftDecorationWidth_Landroid_view_View_;

		private static Delegate cb_getPosition_Landroid_view_View_;

		private static Delegate cb_getRightDecorationWidth_Landroid_view_View_;

		private static Delegate cb_getRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_getSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_getTopDecorationHeight_Landroid_view_View_;

		private static Delegate cb_getTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_;

		private static Delegate cb_ignoreView_Landroid_view_View_;

		private static Delegate cb_isLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_isViewPartiallyVisible_Landroid_view_View_ZZ;

		private static Delegate cb_layoutDecorated_Landroid_view_View_IIII;

		private static Delegate cb_layoutDecoratedWithMargins_Landroid_view_View_IIII;

		private static Delegate cb_measureChild_Landroid_view_View_II;

		private static Delegate cb_measureChildWithMargins_Landroid_view_View_II;

		private static Delegate cb_moveView_II;

		private static Delegate cb_offsetChildrenHorizontal_I;

		private static Delegate cb_offsetChildrenVertical_I;

		private static Delegate cb_onAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_;

		private static Delegate cb_onAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_II;

		private static Delegate cb_onAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_;

		private static Delegate cb_onDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_;

		private static Delegate cb_onDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_;

		private static Delegate cb_onFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_onInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_;

		private static Delegate cb_onInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_;

		private static Delegate cb_onInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

		private static Delegate cb_onInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

		private static Delegate cb_onInterceptFocusSearch_Landroid_view_View_I;

		private static Delegate cb_onItemsAdded_Landroidx_recyclerview_widget_RecyclerView_II;

		private static Delegate cb_onItemsChanged_Landroidx_recyclerview_widget_RecyclerView_;

		private static Delegate cb_onItemsMoved_Landroidx_recyclerview_widget_RecyclerView_III;

		private static Delegate cb_onItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_II;

		private static Delegate cb_onItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_II;

		private static Delegate cb_onItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_;

		private static Delegate cb_onLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_onLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_onMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_II;

		private static Delegate cb_onRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_;

		private static Delegate cb_onRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_;

		private static Delegate cb_onRestoreInstanceState_Landroid_os_Parcelable_;

		private static Delegate cb_onSaveInstanceState;

		private static Delegate cb_onScrollStateChanged_I;

		private static Delegate cb_performAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_;

		private static Delegate cb_performAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_;

		private static Delegate cb_postOnAnimation_Ljava_lang_Runnable_;

		private static Delegate cb_removeAllViews;

		private static Delegate cb_removeAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_;

		private static Delegate cb_removeAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_;

		private static Delegate cb_removeAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_;

		private static Delegate cb_removeCallbacks_Ljava_lang_Runnable_;

		private static Delegate cb_removeDetachedView_Landroid_view_View_;

		private static Delegate cb_removeView_Landroid_view_View_;

		private static Delegate cb_removeViewAt_I;

		private static Delegate cb_requestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_Z;

		private static Delegate cb_requestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZ;

		private static Delegate cb_requestLayout;

		private static Delegate cb_requestSimpleAnimationsInNextLayout;

		private static Delegate cb_scrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_scrollToPosition_I;

		private static Delegate cb_scrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;

		private static Delegate cb_setMeasuredDimension_Landroid_graphics_Rect_II;

		private static Delegate cb_setMeasuredDimension_II;

		private static Delegate cb_smoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_I;

		private static Delegate cb_startSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_;

		private static Delegate cb_stopIgnoringView_Landroid_view_View_;

		private static Delegate cb_supportsPredictiveItemAnimations;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool AutoMeasureEnabled
		{
			[Register("isAutoMeasureEnabled", "()Z", "GetIsAutoMeasureEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAutoMeasureEnabled.()Z", this, null);
			}
			[Register("setAutoMeasureEnabled", "(Z)V", "GetSetAutoMeasureEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAutoMeasureEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual int Baseline
		{
			[Register("getBaseline", "()I", "GetGetBaselineHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBaseline.()I", this, null);
			}
		}

		public unsafe virtual int ChildCount
		{
			[Register("getChildCount", "()I", "GetGetChildCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getChildCount.()I", this, null);
			}
		}

		public unsafe virtual bool ClipToPadding
		{
			[Register("getClipToPadding", "()Z", "GetGetClipToPaddingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getClipToPadding.()Z", this, null);
			}
		}

		public unsafe virtual View FocusedChild
		{
			[Register("getFocusedChild", "()Landroid/view/View;", "GetGetFocusedChildHandler")]
			get
			{
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFocusedChild.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool HasFocus
		{
			[Register("hasFocus", "()Z", "GetHasFocusHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasFocus.()Z", this, null);
			}
		}

		public unsafe virtual int Height
		{
			[Register("getHeight", "()I", "GetGetHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getHeight.()I", this, null);
			}
		}

		public unsafe virtual int HeightMode
		{
			[Register("getHeightMode", "()I", "GetGetHeightModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getHeightMode.()I", this, null);
			}
		}

		public unsafe virtual bool IsAttachedToWindow
		{
			[Register("isAttachedToWindow", "()Z", "GetIsAttachedToWindowHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAttachedToWindow.()Z", this, null);
			}
		}

		public unsafe virtual bool IsFocused
		{
			[Register("isFocused", "()Z", "GetIsFocusedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFocused.()Z", this, null);
			}
		}

		public unsafe virtual bool IsSmoothScrolling
		{
			[Register("isSmoothScrolling", "()Z", "GetIsSmoothScrollingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSmoothScrolling.()Z", this, null);
			}
		}

		public unsafe virtual int ItemCount
		{
			[Register("getItemCount", "()I", "GetGetItemCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getItemCount.()I", this, null);
			}
		}

		public unsafe bool ItemPrefetchEnabled
		{
			[Register("isItemPrefetchEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isItemPrefetchEnabled.()Z", this, null);
			}
			[Register("setItemPrefetchEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setItemPrefetchEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual int LayoutDirection
		{
			[Register("getLayoutDirection", "()I", "GetGetLayoutDirectionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLayoutDirection.()I", this, null);
			}
		}

		public unsafe virtual bool MeasurementCacheEnabled
		{
			[Register("isMeasurementCacheEnabled", "()Z", "GetIsMeasurementCacheEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMeasurementCacheEnabled.()Z", this, null);
			}
			[Register("setMeasurementCacheEnabled", "(Z)V", "GetSetMeasurementCacheEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasurementCacheEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual int MinimumHeight
		{
			[Register("getMinimumHeight", "()I", "GetGetMinimumHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMinimumHeight.()I", this, null);
			}
		}

		public unsafe virtual int MinimumWidth
		{
			[Register("getMinimumWidth", "()I", "GetGetMinimumWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMinimumWidth.()I", this, null);
			}
		}

		public unsafe virtual int PaddingBottom
		{
			[Register("getPaddingBottom", "()I", "GetGetPaddingBottomHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingBottom.()I", this, null);
			}
		}

		public unsafe virtual int PaddingEnd
		{
			[Register("getPaddingEnd", "()I", "GetGetPaddingEndHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingEnd.()I", this, null);
			}
		}

		public unsafe virtual int PaddingLeft
		{
			[Register("getPaddingLeft", "()I", "GetGetPaddingLeftHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingLeft.()I", this, null);
			}
		}

		public unsafe virtual int PaddingRight
		{
			[Register("getPaddingRight", "()I", "GetGetPaddingRightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingRight.()I", this, null);
			}
		}

		public unsafe virtual int PaddingStart
		{
			[Register("getPaddingStart", "()I", "GetGetPaddingStartHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingStart.()I", this, null);
			}
		}

		public unsafe virtual int PaddingTop
		{
			[Register("getPaddingTop", "()I", "GetGetPaddingTopHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingTop.()I", this, null);
			}
		}

		public unsafe virtual int Width
		{
			[Register("getWidth", "()I", "GetGetWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getWidth.()I", this, null);
			}
		}

		public unsafe virtual int WidthMode
		{
			[Register("getWidthMode", "()I", "GetGetWidthModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getWidthMode.()I", this, null);
			}
		}

		protected LayoutManager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LayoutManager()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsAutoMeasureEnabledHandler()
		{
			if ((object)cb_isAutoMeasureEnabled == null)
			{
				cb_isAutoMeasureEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAutoMeasureEnabled));
			}
			return cb_isAutoMeasureEnabled;
		}

		private static bool n_IsAutoMeasureEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoMeasureEnabled;
		}

		private static Delegate GetSetAutoMeasureEnabled_ZHandler()
		{
			if ((object)cb_setAutoMeasureEnabled_Z == null)
			{
				cb_setAutoMeasureEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetAutoMeasureEnabled_Z));
			}
			return cb_setAutoMeasureEnabled_Z;
		}

		private static void n_SetAutoMeasureEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoMeasureEnabled = enabled;
		}

		private static Delegate GetGetBaselineHandler()
		{
			if ((object)cb_getBaseline == null)
			{
				cb_getBaseline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBaseline));
			}
			return cb_getBaseline;
		}

		private static int n_GetBaseline(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Baseline;
		}

		private static Delegate GetGetChildCountHandler()
		{
			if ((object)cb_getChildCount == null)
			{
				cb_getChildCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetChildCount));
			}
			return cb_getChildCount;
		}

		private static int n_GetChildCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChildCount;
		}

		private static Delegate GetGetClipToPaddingHandler()
		{
			if ((object)cb_getClipToPadding == null)
			{
				cb_getClipToPadding = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetClipToPadding));
			}
			return cb_getClipToPadding;
		}

		private static bool n_GetClipToPadding(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClipToPadding;
		}

		private static Delegate GetGetFocusedChildHandler()
		{
			if ((object)cb_getFocusedChild == null)
			{
				cb_getFocusedChild = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFocusedChild));
			}
			return cb_getFocusedChild;
		}

		private static IntPtr n_GetFocusedChild(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FocusedChild);
		}

		private static Delegate GetHasFocusHandler()
		{
			if ((object)cb_hasFocus == null)
			{
				cb_hasFocus = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasFocus));
			}
			return cb_hasFocus;
		}

		private static bool n_HasFocus(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFocus;
		}

		private static Delegate GetGetHeightHandler()
		{
			if ((object)cb_getHeight == null)
			{
				cb_getHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHeight));
			}
			return cb_getHeight;
		}

		private static int n_GetHeight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
		}

		private static Delegate GetGetHeightModeHandler()
		{
			if ((object)cb_getHeightMode == null)
			{
				cb_getHeightMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHeightMode));
			}
			return cb_getHeightMode;
		}

		private static int n_GetHeightMode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeightMode;
		}

		private static Delegate GetIsAttachedToWindowHandler()
		{
			if ((object)cb_isAttachedToWindow == null)
			{
				cb_isAttachedToWindow = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAttachedToWindow));
			}
			return cb_isAttachedToWindow;
		}

		private static bool n_IsAttachedToWindow(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAttachedToWindow;
		}

		private static Delegate GetIsFocusedHandler()
		{
			if ((object)cb_isFocused == null)
			{
				cb_isFocused = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsFocused));
			}
			return cb_isFocused;
		}

		private static bool n_IsFocused(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFocused;
		}

		private static Delegate GetIsSmoothScrollingHandler()
		{
			if ((object)cb_isSmoothScrolling == null)
			{
				cb_isSmoothScrolling = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSmoothScrolling));
			}
			return cb_isSmoothScrolling;
		}

		private static bool n_IsSmoothScrolling(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSmoothScrolling;
		}

		private static Delegate GetGetItemCountHandler()
		{
			if ((object)cb_getItemCount == null)
			{
				cb_getItemCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetItemCount));
			}
			return cb_getItemCount;
		}

		private static int n_GetItemCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemCount;
		}

		private static Delegate GetGetLayoutDirectionHandler()
		{
			if ((object)cb_getLayoutDirection == null)
			{
				cb_getLayoutDirection = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLayoutDirection));
			}
			return cb_getLayoutDirection;
		}

		private static int n_GetLayoutDirection(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutDirection;
		}

		private static Delegate GetIsMeasurementCacheEnabledHandler()
		{
			if ((object)cb_isMeasurementCacheEnabled == null)
			{
				cb_isMeasurementCacheEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsMeasurementCacheEnabled));
			}
			return cb_isMeasurementCacheEnabled;
		}

		private static bool n_IsMeasurementCacheEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MeasurementCacheEnabled;
		}

		private static Delegate GetSetMeasurementCacheEnabled_ZHandler()
		{
			if ((object)cb_setMeasurementCacheEnabled_Z == null)
			{
				cb_setMeasurementCacheEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetMeasurementCacheEnabled_Z));
			}
			return cb_setMeasurementCacheEnabled_Z;
		}

		private static void n_SetMeasurementCacheEnabled_Z(IntPtr jnienv, IntPtr native__this, bool measurementCacheEnabled)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MeasurementCacheEnabled = measurementCacheEnabled;
		}

		private static Delegate GetGetMinimumHeightHandler()
		{
			if ((object)cb_getMinimumHeight == null)
			{
				cb_getMinimumHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMinimumHeight));
			}
			return cb_getMinimumHeight;
		}

		private static int n_GetMinimumHeight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumHeight;
		}

		private static Delegate GetGetMinimumWidthHandler()
		{
			if ((object)cb_getMinimumWidth == null)
			{
				cb_getMinimumWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMinimumWidth));
			}
			return cb_getMinimumWidth;
		}

		private static int n_GetMinimumWidth(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumWidth;
		}

		private static Delegate GetGetPaddingBottomHandler()
		{
			if ((object)cb_getPaddingBottom == null)
			{
				cb_getPaddingBottom = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPaddingBottom));
			}
			return cb_getPaddingBottom;
		}

		private static int n_GetPaddingBottom(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingBottom;
		}

		private static Delegate GetGetPaddingEndHandler()
		{
			if ((object)cb_getPaddingEnd == null)
			{
				cb_getPaddingEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPaddingEnd));
			}
			return cb_getPaddingEnd;
		}

		private static int n_GetPaddingEnd(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingEnd;
		}

		private static Delegate GetGetPaddingLeftHandler()
		{
			if ((object)cb_getPaddingLeft == null)
			{
				cb_getPaddingLeft = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPaddingLeft));
			}
			return cb_getPaddingLeft;
		}

		private static int n_GetPaddingLeft(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingLeft;
		}

		private static Delegate GetGetPaddingRightHandler()
		{
			if ((object)cb_getPaddingRight == null)
			{
				cb_getPaddingRight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPaddingRight));
			}
			return cb_getPaddingRight;
		}

		private static int n_GetPaddingRight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingRight;
		}

		private static Delegate GetGetPaddingStartHandler()
		{
			if ((object)cb_getPaddingStart == null)
			{
				cb_getPaddingStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPaddingStart));
			}
			return cb_getPaddingStart;
		}

		private static int n_GetPaddingStart(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingStart;
		}

		private static Delegate GetGetPaddingTopHandler()
		{
			if ((object)cb_getPaddingTop == null)
			{
				cb_getPaddingTop = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPaddingTop));
			}
			return cb_getPaddingTop;
		}

		private static int n_GetPaddingTop(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingTop;
		}

		private static Delegate GetGetWidthHandler()
		{
			if ((object)cb_getWidth == null)
			{
				cb_getWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetWidth));
			}
			return cb_getWidth;
		}

		private static int n_GetWidth(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width;
		}

		private static Delegate GetGetWidthModeHandler()
		{
			if ((object)cb_getWidthMode == null)
			{
				cb_getWidthMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetWidthMode));
			}
			return cb_getWidthMode;
		}

		private static int n_GetWidthMode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WidthMode;
		}

		private static Delegate GetAddDisappearingView_Landroid_view_View_Handler()
		{
			if ((object)cb_addDisappearingView_Landroid_view_View_ == null)
			{
				cb_addDisappearingView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddDisappearingView_Landroid_view_View_));
			}
			return cb_addDisappearingView_Landroid_view_View_;
		}

		private static void n_AddDisappearingView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.AddDisappearingView(child);
		}

		[Register("addDisappearingView", "(Landroid/view/View;)V", "GetAddDisappearingView_Landroid_view_View_Handler")]
		public unsafe virtual void AddDisappearingView(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addDisappearingView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAddDisappearingView_Landroid_view_View_IHandler()
		{
			if ((object)cb_addDisappearingView_Landroid_view_View_I == null)
			{
				cb_addDisappearingView_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_AddDisappearingView_Landroid_view_View_I));
			}
			return cb_addDisappearingView_Landroid_view_View_I;
		}

		private static void n_AddDisappearingView_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int index)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.AddDisappearingView(child, index);
		}

		[Register("addDisappearingView", "(Landroid/view/View;I)V", "GetAddDisappearingView_Landroid_view_View_IHandler")]
		public unsafe virtual void AddDisappearingView(View child, int index)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(index);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addDisappearingView.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAddView_Landroid_view_View_Handler()
		{
			if ((object)cb_addView_Landroid_view_View_ == null)
			{
				cb_addView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddView_Landroid_view_View_));
			}
			return cb_addView_Landroid_view_View_;
		}

		private static void n_AddView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.AddView(child);
		}

		[Register("addView", "(Landroid/view/View;)V", "GetAddView_Landroid_view_View_Handler")]
		public unsafe virtual void AddView(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAddView_Landroid_view_View_IHandler()
		{
			if ((object)cb_addView_Landroid_view_View_I == null)
			{
				cb_addView_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_AddView_Landroid_view_View_I));
			}
			return cb_addView_Landroid_view_View_I;
		}

		private static void n_AddView_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int index)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.AddView(child, index);
		}

		[Register("addView", "(Landroid/view/View;I)V", "GetAddView_Landroid_view_View_IHandler")]
		public unsafe virtual void AddView(View child, int index)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(index);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addView.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAssertInLayoutOrScroll_Ljava_lang_String_Handler()
		{
			if ((object)cb_assertInLayoutOrScroll_Ljava_lang_String_ == null)
			{
				cb_assertInLayoutOrScroll_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AssertInLayoutOrScroll_Ljava_lang_String_));
			}
			return cb_assertInLayoutOrScroll_Ljava_lang_String_;
		}

		private static void n_AssertInLayoutOrScroll_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_message)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string message = JNIEnv.GetString(native_message, JniHandleOwnership.DoNotTransfer);
			layoutManager.AssertInLayoutOrScroll(message);
		}

		[Register("assertInLayoutOrScroll", "(Ljava/lang/String;)V", "GetAssertInLayoutOrScroll_Ljava_lang_String_Handler")]
		public unsafe virtual void AssertInLayoutOrScroll(string message)
		{
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("assertInLayoutOrScroll.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetAssertNotInLayoutOrScroll_Ljava_lang_String_Handler()
		{
			if ((object)cb_assertNotInLayoutOrScroll_Ljava_lang_String_ == null)
			{
				cb_assertNotInLayoutOrScroll_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AssertNotInLayoutOrScroll_Ljava_lang_String_));
			}
			return cb_assertNotInLayoutOrScroll_Ljava_lang_String_;
		}

		private static void n_AssertNotInLayoutOrScroll_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_message)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string message = JNIEnv.GetString(native_message, JniHandleOwnership.DoNotTransfer);
			layoutManager.AssertNotInLayoutOrScroll(message);
		}

		[Register("assertNotInLayoutOrScroll", "(Ljava/lang/String;)V", "GetAssertNotInLayoutOrScroll_Ljava_lang_String_Handler")]
		public unsafe virtual void AssertNotInLayoutOrScroll(string message)
		{
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("assertNotInLayoutOrScroll.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetAttachView_Landroid_view_View_Handler()
		{
			if ((object)cb_attachView_Landroid_view_View_ == null)
			{
				cb_attachView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AttachView_Landroid_view_View_));
			}
			return cb_attachView_Landroid_view_View_;
		}

		private static void n_AttachView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.AttachView(child);
		}

		[Register("attachView", "(Landroid/view/View;)V", "GetAttachView_Landroid_view_View_Handler")]
		public unsafe virtual void AttachView(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("attachView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAttachView_Landroid_view_View_IHandler()
		{
			if ((object)cb_attachView_Landroid_view_View_I == null)
			{
				cb_attachView_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_AttachView_Landroid_view_View_I));
			}
			return cb_attachView_Landroid_view_View_I;
		}

		private static void n_AttachView_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int index)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.AttachView(child, index);
		}

		[Register("attachView", "(Landroid/view/View;I)V", "GetAttachView_Landroid_view_View_IHandler")]
		public unsafe virtual void AttachView(View child, int index)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(index);
				_members.InstanceMethods.InvokeVirtualVoidMethod("attachView.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAttachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_Handler()
		{
			if ((object)cb_attachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_ == null)
			{
				cb_attachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_AttachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_));
			}
			return cb_attachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_;
		}

		private static void n_AttachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int index, IntPtr native_lp)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			LayoutParams lp = Java.Lang.Object.GetObject<LayoutParams>(native_lp, JniHandleOwnership.DoNotTransfer);
			layoutManager.AttachView(child, index, lp);
		}

		[Register("attachView", "(Landroid/view/View;ILandroidx/recyclerview/widget/RecyclerView$LayoutParams;)V", "GetAttachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_Handler")]
		public unsafe virtual void AttachView(View child, int index, LayoutParams lp)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(index);
				ptr[2] = new JniArgumentValue(lp?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("attachView.(Landroid/view/View;ILandroidx/recyclerview/widget/RecyclerView$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(lp);
			}
		}

		private static Delegate GetCalculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_Handler()
		{
			if ((object)cb_calculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_ == null)
			{
				cb_calculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_CalculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_));
			}
			return cb_calculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_;
		}

		private static void n_CalculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_(IntPtr jnienv, IntPtr native__this, IntPtr native_child, IntPtr native_outRect)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Rect outRect = Java.Lang.Object.GetObject<Rect>(native_outRect, JniHandleOwnership.DoNotTransfer);
			layoutManager.CalculateItemDecorationsForChild(child, outRect);
		}

		[Register("calculateItemDecorationsForChild", "(Landroid/view/View;Landroid/graphics/Rect;)V", "GetCalculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_Handler")]
		public unsafe virtual void CalculateItemDecorationsForChild(View child, Rect outRect)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(outRect?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("calculateItemDecorationsForChild.(Landroid/view/View;Landroid/graphics/Rect;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(outRect);
			}
		}

		private static Delegate GetCanScrollHorizontallyHandler()
		{
			if ((object)cb_canScrollHorizontally == null)
			{
				cb_canScrollHorizontally = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_CanScrollHorizontally));
			}
			return cb_canScrollHorizontally;
		}

		private static bool n_CanScrollHorizontally(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanScrollHorizontally();
		}

		[Register("canScrollHorizontally", "()Z", "GetCanScrollHorizontallyHandler")]
		public unsafe virtual bool CanScrollHorizontally()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("canScrollHorizontally.()Z", this, null);
		}

		private static Delegate GetCanScrollVerticallyHandler()
		{
			if ((object)cb_canScrollVertically == null)
			{
				cb_canScrollVertically = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_CanScrollVertically));
			}
			return cb_canScrollVertically;
		}

		private static bool n_CanScrollVertically(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanScrollVertically();
		}

		[Register("canScrollVertically", "()Z", "GetCanScrollVerticallyHandler")]
		public unsafe virtual bool CanScrollVertically()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("canScrollVertically.()Z", this, null);
		}

		private static Delegate GetCheckLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_Handler()
		{
			if ((object)cb_checkLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_ == null)
			{
				cb_checkLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_CheckLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_));
			}
			return cb_checkLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_;
		}

		private static bool n_CheckLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_lp)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LayoutParams lp = Java.Lang.Object.GetObject<LayoutParams>(native_lp, JniHandleOwnership.DoNotTransfer);
			return layoutManager.CheckLayoutParams(lp);
		}

		[Register("checkLayoutParams", "(Landroidx/recyclerview/widget/RecyclerView$LayoutParams;)Z", "GetCheckLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_Handler")]
		public unsafe virtual bool CheckLayoutParams(LayoutParams lp)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(lp?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("checkLayoutParams.(Landroidx/recyclerview/widget/RecyclerView$LayoutParams;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(lp);
			}
		}

		[Register("chooseSize", "(III)I", "")]
		public unsafe static int ChooseSize(int spec, int desired, int min)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(spec);
			ptr[1] = new JniArgumentValue(desired);
			ptr[2] = new JniArgumentValue(min);
			return _members.StaticMethods.InvokeInt32Method("chooseSize.(III)I", ptr);
		}

		private static Delegate GetCollectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_Handler()
		{
			if ((object)cb_collectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_ == null)
			{
				cb_collectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIILL_V(n_CollectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_));
			}
			return cb_collectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_;
		}

		private static void n_CollectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_(IntPtr jnienv, IntPtr native__this, int dx, int dy, IntPtr native_state, IntPtr native_layoutPrefetchRegistry)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			ILayoutPrefetchRegistry layoutPrefetchRegistry = Java.Lang.Object.GetObject<ILayoutPrefetchRegistry>(native_layoutPrefetchRegistry, JniHandleOwnership.DoNotTransfer);
			layoutManager.CollectAdjacentPrefetchPositions(dx, dy, state, layoutPrefetchRegistry);
		}

		[Register("collectAdjacentPrefetchPositions", "(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry;)V", "GetCollectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_Handler")]
		public unsafe virtual void CollectAdjacentPrefetchPositions(int dx, int dy, State state, ILayoutPrefetchRegistry layoutPrefetchRegistry)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(dx);
				ptr[1] = new JniArgumentValue(dy);
				ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue((layoutPrefetchRegistry == null) ? IntPtr.Zero : ((Java.Lang.Object)layoutPrefetchRegistry).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("collectAdjacentPrefetchPositions.(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
				GC.KeepAlive(layoutPrefetchRegistry);
			}
		}

		private static Delegate GetCollectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_Handler()
		{
			if ((object)cb_collectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_ == null)
			{
				cb_collectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_CollectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_));
			}
			return cb_collectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_;
		}

		private static void n_CollectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_(IntPtr jnienv, IntPtr native__this, int adapterItemCount, IntPtr native_layoutPrefetchRegistry)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILayoutPrefetchRegistry layoutPrefetchRegistry = Java.Lang.Object.GetObject<ILayoutPrefetchRegistry>(native_layoutPrefetchRegistry, JniHandleOwnership.DoNotTransfer);
			layoutManager.CollectInitialPrefetchPositions(adapterItemCount, layoutPrefetchRegistry);
		}

		[Register("collectInitialPrefetchPositions", "(ILandroidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry;)V", "GetCollectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_Handler")]
		public unsafe virtual void CollectInitialPrefetchPositions(int adapterItemCount, ILayoutPrefetchRegistry layoutPrefetchRegistry)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(adapterItemCount);
				ptr[1] = new JniArgumentValue((layoutPrefetchRegistry == null) ? IntPtr.Zero : ((Java.Lang.Object)layoutPrefetchRegistry).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("collectInitialPrefetchPositions.(ILandroidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(layoutPrefetchRegistry);
			}
		}

		private static Delegate GetComputeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_computeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_computeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_ComputeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_computeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_ComputeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.ComputeHorizontalScrollExtent(state);
		}

		[Register("computeHorizontalScrollExtent", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeHorizontalScrollExtent(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollExtent.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetComputeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_computeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_computeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_ComputeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_computeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_ComputeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.ComputeHorizontalScrollOffset(state);
		}

		[Register("computeHorizontalScrollOffset", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeHorizontalScrollOffset(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollOffset.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetComputeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_computeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_computeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_ComputeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_computeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_ComputeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.ComputeHorizontalScrollRange(state);
		}

		[Register("computeHorizontalScrollRange", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeHorizontalScrollRange(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollRange.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetComputeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_computeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_computeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_ComputeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_computeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_ComputeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.ComputeVerticalScrollExtent(state);
		}

		[Register("computeVerticalScrollExtent", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeVerticalScrollExtent(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollExtent.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetComputeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_computeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_computeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_ComputeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_computeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_ComputeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.ComputeVerticalScrollOffset(state);
		}

		[Register("computeVerticalScrollOffset", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeVerticalScrollOffset(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollOffset.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetComputeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_computeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_computeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_ComputeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_computeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_ComputeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.ComputeVerticalScrollRange(state);
		}

		[Register("computeVerticalScrollRange", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeVerticalScrollRange(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollRange.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetDetachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			if ((object)cb_detachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_ == null)
			{
				cb_detachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_DetachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_));
			}
			return cb_detachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_;
		}

		private static void n_DetachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			layoutManager.DetachAndScrapAttachedViews(recycler);
		}

		[Register("detachAndScrapAttachedViews", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetDetachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void DetachAndScrapAttachedViews(Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("detachAndScrapAttachedViews.(Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetDetachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			if ((object)cb_detachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_ == null)
			{
				cb_detachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_DetachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_));
			}
			return cb_detachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_;
		}

		private static void n_DetachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_(IntPtr jnienv, IntPtr native__this, IntPtr native_child, IntPtr native_recycler)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			layoutManager.DetachAndScrapView(child, recycler);
		}

		[Register("detachAndScrapView", "(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetDetachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void DetachAndScrapView(View child, Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("detachAndScrapView.(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetDetachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			if ((object)cb_detachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_ == null)
			{
				cb_detachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_DetachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_));
			}
			return cb_detachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_;
		}

		private static void n_DetachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_(IntPtr jnienv, IntPtr native__this, int index, IntPtr native_recycler)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			layoutManager.DetachAndScrapViewAt(index, recycler);
		}

		[Register("detachAndScrapViewAt", "(ILandroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetDetachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void DetachAndScrapViewAt(int index, Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(index);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("detachAndScrapViewAt.(ILandroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetDetachView_Landroid_view_View_Handler()
		{
			if ((object)cb_detachView_Landroid_view_View_ == null)
			{
				cb_detachView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_DetachView_Landroid_view_View_));
			}
			return cb_detachView_Landroid_view_View_;
		}

		private static void n_DetachView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.DetachView(child);
		}

		[Register("detachView", "(Landroid/view/View;)V", "GetDetachView_Landroid_view_View_Handler")]
		public unsafe virtual void DetachView(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("detachView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetDetachViewAt_IHandler()
		{
			if ((object)cb_detachViewAt_I == null)
			{
				cb_detachViewAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_DetachViewAt_I));
			}
			return cb_detachViewAt_I;
		}

		private static void n_DetachViewAt_I(IntPtr jnienv, IntPtr native__this, int index)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DetachViewAt(index);
		}

		[Register("detachViewAt", "(I)V", "GetDetachViewAt_IHandler")]
		public unsafe virtual void DetachViewAt(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			_members.InstanceMethods.InvokeVirtualVoidMethod("detachViewAt.(I)V", this, ptr);
		}

		private static Delegate GetEndAnimation_Landroid_view_View_Handler()
		{
			if ((object)cb_endAnimation_Landroid_view_View_ == null)
			{
				cb_endAnimation_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_EndAnimation_Landroid_view_View_));
			}
			return cb_endAnimation_Landroid_view_View_;
		}

		private static void n_EndAnimation_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			layoutManager.EndAnimation(view);
		}

		[Register("endAnimation", "(Landroid/view/View;)V", "GetEndAnimation_Landroid_view_View_Handler")]
		public unsafe virtual void EndAnimation(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("endAnimation.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetFindContainingItemView_Landroid_view_View_Handler()
		{
			if ((object)cb_findContainingItemView_Landroid_view_View_ == null)
			{
				cb_findContainingItemView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_FindContainingItemView_Landroid_view_View_));
			}
			return cb_findContainingItemView_Landroid_view_View_;
		}

		private static IntPtr n_FindContainingItemView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(layoutManager.FindContainingItemView(view));
		}

		[Register("findContainingItemView", "(Landroid/view/View;)Landroid/view/View;", "GetFindContainingItemView_Landroid_view_View_Handler")]
		public unsafe virtual View FindContainingItemView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findContainingItemView.(Landroid/view/View;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetFindViewByPosition_IHandler()
		{
			if ((object)cb_findViewByPosition_I == null)
			{
				cb_findViewByPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_FindViewByPosition_I));
			}
			return cb_findViewByPosition_I;
		}

		private static IntPtr n_FindViewByPosition_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewByPosition(position));
		}

		[Register("findViewByPosition", "(I)Landroid/view/View;", "GetFindViewByPosition_IHandler")]
		public unsafe virtual View FindViewByPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewByPosition.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGenerateDefaultLayoutParamsHandler()
		{
			if ((object)cb_generateDefaultLayoutParams == null)
			{
				cb_generateDefaultLayoutParams = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GenerateDefaultLayoutParams));
			}
			return cb_generateDefaultLayoutParams;
		}

		private static IntPtr n_GenerateDefaultLayoutParams(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GenerateDefaultLayoutParams());
		}

		[Register("generateDefaultLayoutParams", "()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateDefaultLayoutParamsHandler")]
		public abstract LayoutParams GenerateDefaultLayoutParams();

		private static Delegate GetGenerateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_Handler()
		{
			if ((object)cb_generateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_ == null)
			{
				cb_generateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_GenerateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_));
			}
			return cb_generateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_;
		}

		private static IntPtr n_GenerateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_(IntPtr jnienv, IntPtr native__this, IntPtr native_c, IntPtr native_attrs)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context c = Java.Lang.Object.GetObject<Context>(native_c, JniHandleOwnership.DoNotTransfer);
			IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(layoutManager.GenerateLayoutParams(c, attrs));
		}

		[Register("generateLayoutParams", "(Landroid/content/Context;Landroid/util/AttributeSet;)Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_Handler")]
		public unsafe virtual LayoutParams GenerateLayoutParams(Context c, IAttributeSet attrs)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				return Java.Lang.Object.GetObject<LayoutParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("generateLayoutParams.(Landroid/content/Context;Landroid/util/AttributeSet;)Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGenerateLayoutParams_Landroid_view_ViewGroup_LayoutParams_Handler()
		{
			if ((object)cb_generateLayoutParams_Landroid_view_ViewGroup_LayoutParams_ == null)
			{
				cb_generateLayoutParams_Landroid_view_ViewGroup_LayoutParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GenerateLayoutParams_Landroid_view_ViewGroup_LayoutParams_));
			}
			return cb_generateLayoutParams_Landroid_view_ViewGroup_LayoutParams_;
		}

		private static IntPtr n_GenerateLayoutParams_Landroid_view_ViewGroup_LayoutParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_lp)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup.LayoutParams lp = Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(native_lp, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(layoutManager.GenerateLayoutParams(lp));
		}

		[Register("generateLayoutParams", "(Landroid/view/ViewGroup$LayoutParams;)Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateLayoutParams_Landroid_view_ViewGroup_LayoutParams_Handler")]
		public unsafe virtual LayoutParams GenerateLayoutParams(ViewGroup.LayoutParams lp)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(lp?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LayoutParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("generateLayoutParams.(Landroid/view/ViewGroup$LayoutParams;)Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(lp);
			}
		}

		private static Delegate GetGetBottomDecorationHeight_Landroid_view_View_Handler()
		{
			if ((object)cb_getBottomDecorationHeight_Landroid_view_View_ == null)
			{
				cb_getBottomDecorationHeight_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetBottomDecorationHeight_Landroid_view_View_));
			}
			return cb_getBottomDecorationHeight_Landroid_view_View_;
		}

		private static int n_GetBottomDecorationHeight_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetBottomDecorationHeight(child);
		}

		[Register("getBottomDecorationHeight", "(Landroid/view/View;)I", "GetGetBottomDecorationHeight_Landroid_view_View_Handler")]
		public unsafe virtual int GetBottomDecorationHeight(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBottomDecorationHeight.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetChildAt_IHandler()
		{
			if ((object)cb_getChildAt_I == null)
			{
				cb_getChildAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetChildAt_I));
			}
			return cb_getChildAt_I;
		}

		private static IntPtr n_GetChildAt_I(IntPtr jnienv, IntPtr native__this, int index)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetChildAt(index));
		}

		[Register("getChildAt", "(I)Landroid/view/View;", "GetGetChildAt_IHandler")]
		public unsafe virtual View GetChildAt(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getChildAt.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getChildMeasureSpec", "(IIIZ)I", "")]
		public unsafe static int GetChildMeasureSpec(int parentSize, int padding, int childDimension, bool canScroll)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(parentSize);
			ptr[1] = new JniArgumentValue(padding);
			ptr[2] = new JniArgumentValue(childDimension);
			ptr[3] = new JniArgumentValue(canScroll);
			return _members.StaticMethods.InvokeInt32Method("getChildMeasureSpec.(IIIZ)I", ptr);
		}

		[Register("getChildMeasureSpec", "(IIIIZ)I", "")]
		public unsafe static int GetChildMeasureSpec(int parentSize, int parentMode, int padding, int childDimension, bool canScroll)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(parentSize);
			ptr[1] = new JniArgumentValue(parentMode);
			ptr[2] = new JniArgumentValue(padding);
			ptr[3] = new JniArgumentValue(childDimension);
			ptr[4] = new JniArgumentValue(canScroll);
			return _members.StaticMethods.InvokeInt32Method("getChildMeasureSpec.(IIIIZ)I", ptr);
		}

		private static Delegate GetGetColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_getColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_getColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_GetColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_getColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_GetColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetColumnCountForAccessibility(recycler, state);
		}

		[Register("getColumnCountForAccessibility", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetGetColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int GetColumnCountForAccessibility(Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getColumnCountForAccessibility.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetGetDecoratedBottom_Landroid_view_View_Handler()
		{
			if ((object)cb_getDecoratedBottom_Landroid_view_View_ == null)
			{
				cb_getDecoratedBottom_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetDecoratedBottom_Landroid_view_View_));
			}
			return cb_getDecoratedBottom_Landroid_view_View_;
		}

		private static int n_GetDecoratedBottom_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetDecoratedBottom(child);
		}

		[Register("getDecoratedBottom", "(Landroid/view/View;)I", "GetGetDecoratedBottom_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedBottom(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedBottom.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_Handler()
		{
			if ((object)cb_getDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_ == null)
			{
				cb_getDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_GetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_));
			}
			return cb_getDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_;
		}

		private static void n_GetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_outBounds)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			Rect outBounds = Java.Lang.Object.GetObject<Rect>(native_outBounds, JniHandleOwnership.DoNotTransfer);
			layoutManager.GetDecoratedBoundsWithMargins(view, outBounds);
		}

		[Register("getDecoratedBoundsWithMargins", "(Landroid/view/View;Landroid/graphics/Rect;)V", "GetGetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_Handler")]
		public unsafe virtual void GetDecoratedBoundsWithMargins(View view, Rect outBounds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(outBounds?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getDecoratedBoundsWithMargins.(Landroid/view/View;Landroid/graphics/Rect;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
				GC.KeepAlive(outBounds);
			}
		}

		private static Delegate GetGetDecoratedLeft_Landroid_view_View_Handler()
		{
			if ((object)cb_getDecoratedLeft_Landroid_view_View_ == null)
			{
				cb_getDecoratedLeft_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetDecoratedLeft_Landroid_view_View_));
			}
			return cb_getDecoratedLeft_Landroid_view_View_;
		}

		private static int n_GetDecoratedLeft_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetDecoratedLeft(child);
		}

		[Register("getDecoratedLeft", "(Landroid/view/View;)I", "GetGetDecoratedLeft_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedLeft(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedLeft.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDecoratedMeasuredHeight_Landroid_view_View_Handler()
		{
			if ((object)cb_getDecoratedMeasuredHeight_Landroid_view_View_ == null)
			{
				cb_getDecoratedMeasuredHeight_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetDecoratedMeasuredHeight_Landroid_view_View_));
			}
			return cb_getDecoratedMeasuredHeight_Landroid_view_View_;
		}

		private static int n_GetDecoratedMeasuredHeight_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetDecoratedMeasuredHeight(child);
		}

		[Register("getDecoratedMeasuredHeight", "(Landroid/view/View;)I", "GetGetDecoratedMeasuredHeight_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedMeasuredHeight(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedMeasuredHeight.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDecoratedMeasuredWidth_Landroid_view_View_Handler()
		{
			if ((object)cb_getDecoratedMeasuredWidth_Landroid_view_View_ == null)
			{
				cb_getDecoratedMeasuredWidth_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetDecoratedMeasuredWidth_Landroid_view_View_));
			}
			return cb_getDecoratedMeasuredWidth_Landroid_view_View_;
		}

		private static int n_GetDecoratedMeasuredWidth_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetDecoratedMeasuredWidth(child);
		}

		[Register("getDecoratedMeasuredWidth", "(Landroid/view/View;)I", "GetGetDecoratedMeasuredWidth_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedMeasuredWidth(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedMeasuredWidth.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDecoratedRight_Landroid_view_View_Handler()
		{
			if ((object)cb_getDecoratedRight_Landroid_view_View_ == null)
			{
				cb_getDecoratedRight_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetDecoratedRight_Landroid_view_View_));
			}
			return cb_getDecoratedRight_Landroid_view_View_;
		}

		private static int n_GetDecoratedRight_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetDecoratedRight(child);
		}

		[Register("getDecoratedRight", "(Landroid/view/View;)I", "GetGetDecoratedRight_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedRight(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedRight.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDecoratedTop_Landroid_view_View_Handler()
		{
			if ((object)cb_getDecoratedTop_Landroid_view_View_ == null)
			{
				cb_getDecoratedTop_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetDecoratedTop_Landroid_view_View_));
			}
			return cb_getDecoratedTop_Landroid_view_View_;
		}

		private static int n_GetDecoratedTop_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetDecoratedTop(child);
		}

		[Register("getDecoratedTop", "(Landroid/view/View;)I", "GetGetDecoratedTop_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedTop(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedTop.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetItemViewType_Landroid_view_View_Handler()
		{
			if ((object)cb_getItemViewType_Landroid_view_View_ == null)
			{
				cb_getItemViewType_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetItemViewType_Landroid_view_View_));
			}
			return cb_getItemViewType_Landroid_view_View_;
		}

		private static int n_GetItemViewType_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetItemViewType(view);
		}

		[Register("getItemViewType", "(Landroid/view/View;)I", "GetGetItemViewType_Landroid_view_View_Handler")]
		public unsafe virtual int GetItemViewType(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getItemViewType.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetGetLeftDecorationWidth_Landroid_view_View_Handler()
		{
			if ((object)cb_getLeftDecorationWidth_Landroid_view_View_ == null)
			{
				cb_getLeftDecorationWidth_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetLeftDecorationWidth_Landroid_view_View_));
			}
			return cb_getLeftDecorationWidth_Landroid_view_View_;
		}

		private static int n_GetLeftDecorationWidth_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetLeftDecorationWidth(child);
		}

		[Register("getLeftDecorationWidth", "(Landroid/view/View;)I", "GetGetLeftDecorationWidth_Landroid_view_View_Handler")]
		public unsafe virtual int GetLeftDecorationWidth(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLeftDecorationWidth.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetPosition_Landroid_view_View_Handler()
		{
			if ((object)cb_getPosition_Landroid_view_View_ == null)
			{
				cb_getPosition_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetPosition_Landroid_view_View_));
			}
			return cb_getPosition_Landroid_view_View_;
		}

		private static int n_GetPosition_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetPosition(view);
		}

		[Register("getPosition", "(Landroid/view/View;)I", "GetGetPosition_Landroid_view_View_Handler")]
		public unsafe virtual int GetPosition(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPosition.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[Register("getProperties", "(Landroid/content/Context;Landroid/util/AttributeSet;II)Landroidx/recyclerview/widget/RecyclerView$LayoutManager$Properties;", "")]
		public unsafe static Properties GetProperties(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				ptr[3] = new JniArgumentValue(defStyleRes);
				return Java.Lang.Object.GetObject<Properties>(_members.StaticMethods.InvokeObjectMethod("getProperties.(Landroid/content/Context;Landroid/util/AttributeSet;II)Landroidx/recyclerview/widget/RecyclerView$LayoutManager$Properties;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetRightDecorationWidth_Landroid_view_View_Handler()
		{
			if ((object)cb_getRightDecorationWidth_Landroid_view_View_ == null)
			{
				cb_getRightDecorationWidth_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetRightDecorationWidth_Landroid_view_View_));
			}
			return cb_getRightDecorationWidth_Landroid_view_View_;
		}

		private static int n_GetRightDecorationWidth_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetRightDecorationWidth(child);
		}

		[Register("getRightDecorationWidth", "(Landroid/view/View;)I", "GetGetRightDecorationWidth_Landroid_view_View_Handler")]
		public unsafe virtual int GetRightDecorationWidth(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRightDecorationWidth.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_getRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_getRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_GetRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_getRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_GetRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetRowCountForAccessibility(recycler, state);
		}

		[Register("getRowCountForAccessibility", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetGetRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int GetRowCountForAccessibility(Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRowCountForAccessibility.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetGetSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_getSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_getSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_GetSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_getSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_GetSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetSelectionModeForAccessibility(recycler, state);
		}

		[Register("getSelectionModeForAccessibility", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetGetSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int GetSelectionModeForAccessibility(Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getSelectionModeForAccessibility.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetGetTopDecorationHeight_Landroid_view_View_Handler()
		{
			if ((object)cb_getTopDecorationHeight_Landroid_view_View_ == null)
			{
				cb_getTopDecorationHeight_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetTopDecorationHeight_Landroid_view_View_));
			}
			return cb_getTopDecorationHeight_Landroid_view_View_;
		}

		private static int n_GetTopDecorationHeight_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.GetTopDecorationHeight(child);
		}

		[Register("getTopDecorationHeight", "(Landroid/view/View;)I", "GetGetTopDecorationHeight_Landroid_view_View_Handler")]
		public unsafe virtual int GetTopDecorationHeight(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTopDecorationHeight.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_Handler()
		{
			if ((object)cb_getTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_ == null)
			{
				cb_getTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZL_V(n_GetTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_));
			}
			return cb_getTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_;
		}

		private static void n_GetTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_(IntPtr jnienv, IntPtr native__this, IntPtr native_child, bool includeDecorInsets, IntPtr native__out)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Rect rect = Java.Lang.Object.GetObject<Rect>(native__out, JniHandleOwnership.DoNotTransfer);
			layoutManager.GetTransformedBoundingBox(child, includeDecorInsets, rect);
		}

		[Register("getTransformedBoundingBox", "(Landroid/view/View;ZLandroid/graphics/Rect;)V", "GetGetTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_Handler")]
		public unsafe virtual void GetTransformedBoundingBox(View child, bool includeDecorInsets, Rect @out)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(includeDecorInsets);
				ptr[2] = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getTransformedBoundingBox.(Landroid/view/View;ZLandroid/graphics/Rect;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(@out);
			}
		}

		private static Delegate GetIgnoreView_Landroid_view_View_Handler()
		{
			if ((object)cb_ignoreView_Landroid_view_View_ == null)
			{
				cb_ignoreView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_IgnoreView_Landroid_view_View_));
			}
			return cb_ignoreView_Landroid_view_View_;
		}

		private static void n_IgnoreView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			layoutManager.IgnoreView(view);
		}

		[Register("ignoreView", "(Landroid/view/View;)V", "GetIgnoreView_Landroid_view_View_Handler")]
		public unsafe virtual void IgnoreView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("ignoreView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetIsLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_isLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_isLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_IsLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_isLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static bool n_IsLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.IsLayoutHierarchical(recycler, state);
		}

		[Register("isLayoutHierarchical", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)Z", "GetIsLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual bool IsLayoutHierarchical(Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLayoutHierarchical.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetIsViewPartiallyVisible_Landroid_view_View_ZZHandler()
		{
			if ((object)cb_isViewPartiallyVisible_Landroid_view_View_ZZ == null)
			{
				cb_isViewPartiallyVisible_Landroid_view_View_ZZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZZ_Z(n_IsViewPartiallyVisible_Landroid_view_View_ZZ));
			}
			return cb_isViewPartiallyVisible_Landroid_view_View_ZZ;
		}

		private static bool n_IsViewPartiallyVisible_Landroid_view_View_ZZ(IntPtr jnienv, IntPtr native__this, IntPtr native_child, bool completelyVisible, bool acceptEndPointInclusion)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return layoutManager.IsViewPartiallyVisible(child, completelyVisible, acceptEndPointInclusion);
		}

		[Register("isViewPartiallyVisible", "(Landroid/view/View;ZZ)Z", "GetIsViewPartiallyVisible_Landroid_view_View_ZZHandler")]
		public unsafe virtual bool IsViewPartiallyVisible(View child, bool completelyVisible, bool acceptEndPointInclusion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(completelyVisible);
				ptr[2] = new JniArgumentValue(acceptEndPointInclusion);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isViewPartiallyVisible.(Landroid/view/View;ZZ)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetLayoutDecorated_Landroid_view_View_IIIIHandler()
		{
			if ((object)cb_layoutDecorated_Landroid_view_View_IIII == null)
			{
				cb_layoutDecorated_Landroid_view_View_IIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIII_V(n_LayoutDecorated_Landroid_view_View_IIII));
			}
			return cb_layoutDecorated_Landroid_view_View_IIII;
		}

		private static void n_LayoutDecorated_Landroid_view_View_IIII(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int left, int top, int right, int bottom)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.LayoutDecorated(child, left, top, right, bottom);
		}

		[Register("layoutDecorated", "(Landroid/view/View;IIII)V", "GetLayoutDecorated_Landroid_view_View_IIIIHandler")]
		public unsafe virtual void LayoutDecorated(View child, int left, int top, int right, int bottom)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(left);
				ptr[2] = new JniArgumentValue(top);
				ptr[3] = new JniArgumentValue(right);
				ptr[4] = new JniArgumentValue(bottom);
				_members.InstanceMethods.InvokeVirtualVoidMethod("layoutDecorated.(Landroid/view/View;IIII)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetLayoutDecoratedWithMargins_Landroid_view_View_IIIIHandler()
		{
			if ((object)cb_layoutDecoratedWithMargins_Landroid_view_View_IIII == null)
			{
				cb_layoutDecoratedWithMargins_Landroid_view_View_IIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIII_V(n_LayoutDecoratedWithMargins_Landroid_view_View_IIII));
			}
			return cb_layoutDecoratedWithMargins_Landroid_view_View_IIII;
		}

		private static void n_LayoutDecoratedWithMargins_Landroid_view_View_IIII(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int left, int top, int right, int bottom)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.LayoutDecoratedWithMargins(child, left, top, right, bottom);
		}

		[Register("layoutDecoratedWithMargins", "(Landroid/view/View;IIII)V", "GetLayoutDecoratedWithMargins_Landroid_view_View_IIIIHandler")]
		public unsafe virtual void LayoutDecoratedWithMargins(View child, int left, int top, int right, int bottom)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(left);
				ptr[2] = new JniArgumentValue(top);
				ptr[3] = new JniArgumentValue(right);
				ptr[4] = new JniArgumentValue(bottom);
				_members.InstanceMethods.InvokeVirtualVoidMethod("layoutDecoratedWithMargins.(Landroid/view/View;IIII)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetMeasureChild_Landroid_view_View_IIHandler()
		{
			if ((object)cb_measureChild_Landroid_view_View_II == null)
			{
				cb_measureChild_Landroid_view_View_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_MeasureChild_Landroid_view_View_II));
			}
			return cb_measureChild_Landroid_view_View_II;
		}

		private static void n_MeasureChild_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int widthUsed, int heightUsed)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.MeasureChild(child, widthUsed, heightUsed);
		}

		[Register("measureChild", "(Landroid/view/View;II)V", "GetMeasureChild_Landroid_view_View_IIHandler")]
		public unsafe virtual void MeasureChild(View child, int widthUsed, int heightUsed)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(widthUsed);
				ptr[2] = new JniArgumentValue(heightUsed);
				_members.InstanceMethods.InvokeVirtualVoidMethod("measureChild.(Landroid/view/View;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetMeasureChildWithMargins_Landroid_view_View_IIHandler()
		{
			if ((object)cb_measureChildWithMargins_Landroid_view_View_II == null)
			{
				cb_measureChildWithMargins_Landroid_view_View_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_MeasureChildWithMargins_Landroid_view_View_II));
			}
			return cb_measureChildWithMargins_Landroid_view_View_II;
		}

		private static void n_MeasureChildWithMargins_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int widthUsed, int heightUsed)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.MeasureChildWithMargins(child, widthUsed, heightUsed);
		}

		[Register("measureChildWithMargins", "(Landroid/view/View;II)V", "GetMeasureChildWithMargins_Landroid_view_View_IIHandler")]
		public unsafe virtual void MeasureChildWithMargins(View child, int widthUsed, int heightUsed)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(widthUsed);
				ptr[2] = new JniArgumentValue(heightUsed);
				_members.InstanceMethods.InvokeVirtualVoidMethod("measureChildWithMargins.(Landroid/view/View;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetMoveView_IIHandler()
		{
			if ((object)cb_moveView_II == null)
			{
				cb_moveView_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_MoveView_II));
			}
			return cb_moveView_II;
		}

		private static void n_MoveView_II(IntPtr jnienv, IntPtr native__this, int fromIndex, int toIndex)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveView(fromIndex, toIndex);
		}

		[Register("moveView", "(II)V", "GetMoveView_IIHandler")]
		public unsafe virtual void MoveView(int fromIndex, int toIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fromIndex);
			ptr[1] = new JniArgumentValue(toIndex);
			_members.InstanceMethods.InvokeVirtualVoidMethod("moveView.(II)V", this, ptr);
		}

		private static Delegate GetOffsetChildrenHorizontal_IHandler()
		{
			if ((object)cb_offsetChildrenHorizontal_I == null)
			{
				cb_offsetChildrenHorizontal_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OffsetChildrenHorizontal_I));
			}
			return cb_offsetChildrenHorizontal_I;
		}

		private static void n_OffsetChildrenHorizontal_I(IntPtr jnienv, IntPtr native__this, int dx)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffsetChildrenHorizontal(dx);
		}

		[Register("offsetChildrenHorizontal", "(I)V", "GetOffsetChildrenHorizontal_IHandler")]
		public unsafe virtual void OffsetChildrenHorizontal(int dx)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dx);
			_members.InstanceMethods.InvokeVirtualVoidMethod("offsetChildrenHorizontal.(I)V", this, ptr);
		}

		private static Delegate GetOffsetChildrenVertical_IHandler()
		{
			if ((object)cb_offsetChildrenVertical_I == null)
			{
				cb_offsetChildrenVertical_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OffsetChildrenVertical_I));
			}
			return cb_offsetChildrenVertical_I;
		}

		private static void n_OffsetChildrenVertical_I(IntPtr jnienv, IntPtr native__this, int dy)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffsetChildrenVertical(dy);
		}

		[Register("offsetChildrenVertical", "(I)V", "GetOffsetChildrenVertical_IHandler")]
		public unsafe virtual void OffsetChildrenVertical(int dy)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dy);
			_members.InstanceMethods.InvokeVirtualVoidMethod("offsetChildrenVertical.(I)V", this, ptr);
		}

		private static Delegate GetOnAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Handler()
		{
			if ((object)cb_onAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_ == null)
			{
				cb_onAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_));
			}
			return cb_onAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_;
		}

		private static void n_OnAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_(IntPtr jnienv, IntPtr native__this, IntPtr native_oldAdapter, IntPtr native_newAdapter)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Adapter oldAdapter = Java.Lang.Object.GetObject<Adapter>(native_oldAdapter, JniHandleOwnership.DoNotTransfer);
			Adapter newAdapter = Java.Lang.Object.GetObject<Adapter>(native_newAdapter, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnAdapterChanged(oldAdapter, newAdapter);
		}

		[Register("onAdapterChanged", "(Landroidx/recyclerview/widget/RecyclerView$Adapter;Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", "GetOnAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Handler")]
		public unsafe virtual void OnAdapterChanged(Adapter oldAdapter, Adapter newAdapter)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(oldAdapter?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newAdapter?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAdapterChanged.(Landroidx/recyclerview/widget/RecyclerView$Adapter;Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(oldAdapter);
				GC.KeepAlive(newAdapter);
			}
		}

		private static Delegate GetOnAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_IIHandler()
		{
			if ((object)cb_onAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_II == null)
			{
				cb_onAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLII_Z(n_OnAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_II));
			}
			return cb_onAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_II;
		}

		private static bool n_OnAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_II(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, IntPtr native_views, int direction, int focusableMode)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
			return layoutManager.OnAddFocusables(recyclerView, views, direction, focusableMode);
		}

		[Register("onAddFocusables", "(Landroidx/recyclerview/widget/RecyclerView;Ljava/util/ArrayList;II)Z", "GetOnAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_IIHandler")]
		public unsafe virtual bool OnAddFocusables(RecyclerView recyclerView, IList<View> views, int direction, int focusableMode)
		{
			IntPtr intPtr = JavaList<View>.ToLocalJniHandle(views);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(direction);
				ptr[3] = new JniArgumentValue(focusableMode);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onAddFocusables.(Landroidx/recyclerview/widget/RecyclerView;Ljava/util/ArrayList;II)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(views);
			}
		}

		private static Delegate GetOnAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			if ((object)cb_onAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ == null)
			{
				cb_onAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_));
			}
			return cb_onAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_;
		}

		private static void n_OnAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView view = Java.Lang.Object.GetObject<RecyclerView>(native_view, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnAttachedToWindow(view);
		}

		[Register("onAttachedToWindow", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnAttachedToWindow(RecyclerView view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToWindow.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetOnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			if ((object)cb_onDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ == null)
			{
				cb_onDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_));
			}
			return cb_onDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_;
		}

		private static void n_OnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView view = Java.Lang.Object.GetObject<RecyclerView>(native_view, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnDetachedFromWindow(view);
		}

		[Register("onDetachedFromWindow", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnDetachedFromWindow(RecyclerView view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromWindow.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetOnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			if ((object)cb_onDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_ == null)
			{
				cb_onDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_));
			}
			return cb_onDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_;
		}

		private static void n_OnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_recycler)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView view = Java.Lang.Object.GetObject<RecyclerView>(native_view, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnDetachedFromWindow(view, recycler);
		}

		[Register("onDetachedFromWindow", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetOnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void OnDetachedFromWindow(RecyclerView view, Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromWindow.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetOnFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_onFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_onFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLILL_L(n_OnFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_onFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static IntPtr n_OnFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_focused, int direction, IntPtr native_recycler, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(layoutManager.OnFocusSearchFailed(focused, direction, recycler, state));
		}

		[Register("onFocusSearchFailed", "(Landroid/view/View;ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)Landroid/view/View;", "GetOnFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual View OnFocusSearchFailed(View focused, int direction, Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(direction);
				ptr[2] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onFocusSearchFailed.(Landroid/view/View;ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(focused);
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_Handler()
		{
			if ((object)cb_onInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_ == null)
			{
				cb_onInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_));
			}
			return cb_onInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_;
		}

		private static void n_OnInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_e)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnInitializeAccessibilityEvent(e);
		}

		[Register("onInitializeAccessibilityEvent", "(Landroid/view/accessibility/AccessibilityEvent;)V", "GetOnInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_Handler")]
		public unsafe virtual void OnInitializeAccessibilityEvent(AccessibilityEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityEvent.(Landroid/view/accessibility/AccessibilityEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_Handler()
		{
			if ((object)cb_onInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_ == null)
			{
				cb_onInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_));
			}
			return cb_onInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_;
		}

		private static void n_OnInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state, IntPtr native_e)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnInitializeAccessibilityEvent(recycler, state, e);
		}

		[Register("onInitializeAccessibilityEvent", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/accessibility/AccessibilityEvent;)V", "GetOnInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_Handler")]
		public unsafe virtual void OnInitializeAccessibilityEvent(Recycler recycler, State state, AccessibilityEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityEvent.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/accessibility/AccessibilityEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler()
		{
			if ((object)cb_onInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_ == null)
			{
				cb_onInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_));
			}
			return cb_onInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;
		}

		private static void n_OnInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state, IntPtr native_info)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			AccessibilityNodeInfoCompat info = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(native_info, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnInitializeAccessibilityNodeInfo(recycler, state, info);
		}

		[Register("onInitializeAccessibilityNodeInfo", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", "GetOnInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler")]
		public unsafe virtual void OnInitializeAccessibilityNodeInfo(Recycler recycler, State state, AccessibilityNodeInfoCompat info)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityNodeInfo.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
				GC.KeepAlive(info);
			}
		}

		private static Delegate GetOnInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler()
		{
			if ((object)cb_onInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_ == null)
			{
				cb_onInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_OnInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_));
			}
			return cb_onInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;
		}

		private static void n_OnInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state, IntPtr native_host, IntPtr native_info)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			View host = Java.Lang.Object.GetObject<View>(native_host, JniHandleOwnership.DoNotTransfer);
			AccessibilityNodeInfoCompat info = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(native_info, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnInitializeAccessibilityNodeInfoForItem(recycler, state, host, info);
		}

		[Register("onInitializeAccessibilityNodeInfoForItem", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", "GetOnInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler")]
		public unsafe virtual void OnInitializeAccessibilityNodeInfoForItem(Recycler recycler, State state, View host, AccessibilityNodeInfoCompat info)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityNodeInfoForItem.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
				GC.KeepAlive(host);
				GC.KeepAlive(info);
			}
		}

		private static Delegate GetOnInterceptFocusSearch_Landroid_view_View_IHandler()
		{
			if ((object)cb_onInterceptFocusSearch_Landroid_view_View_I == null)
			{
				cb_onInterceptFocusSearch_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_OnInterceptFocusSearch_Landroid_view_View_I));
			}
			return cb_onInterceptFocusSearch_Landroid_view_View_I;
		}

		private static IntPtr n_OnInterceptFocusSearch_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_focused, int direction)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(layoutManager.OnInterceptFocusSearch(focused, direction));
		}

		[Register("onInterceptFocusSearch", "(Landroid/view/View;I)Landroid/view/View;", "GetOnInterceptFocusSearch_Landroid_view_View_IHandler")]
		public unsafe virtual View OnInterceptFocusSearch(View focused, int direction)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(direction);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onInterceptFocusSearch.(Landroid/view/View;I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(focused);
			}
		}

		private static Delegate GetOnItemsAdded_Landroidx_recyclerview_widget_RecyclerView_IIHandler()
		{
			if ((object)cb_onItemsAdded_Landroidx_recyclerview_widget_RecyclerView_II == null)
			{
				cb_onItemsAdded_Landroidx_recyclerview_widget_RecyclerView_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_OnItemsAdded_Landroidx_recyclerview_widget_RecyclerView_II));
			}
			return cb_onItemsAdded_Landroidx_recyclerview_widget_RecyclerView_II;
		}

		private static void n_OnItemsAdded_Landroidx_recyclerview_widget_RecyclerView_II(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, int positionStart, int itemCount)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnItemsAdded(recyclerView, positionStart, itemCount);
		}

		[Register("onItemsAdded", "(Landroidx/recyclerview/widget/RecyclerView;II)V", "GetOnItemsAdded_Landroidx_recyclerview_widget_RecyclerView_IIHandler")]
		public unsafe virtual void OnItemsAdded(RecyclerView recyclerView, int positionStart, int itemCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(positionStart);
				ptr[2] = new JniArgumentValue(itemCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsAdded.(Landroidx/recyclerview/widget/RecyclerView;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnItemsChanged_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			if ((object)cb_onItemsChanged_Landroidx_recyclerview_widget_RecyclerView_ == null)
			{
				cb_onItemsChanged_Landroidx_recyclerview_widget_RecyclerView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnItemsChanged_Landroidx_recyclerview_widget_RecyclerView_));
			}
			return cb_onItemsChanged_Landroidx_recyclerview_widget_RecyclerView_;
		}

		private static void n_OnItemsChanged_Landroidx_recyclerview_widget_RecyclerView_(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnItemsChanged(recyclerView);
		}

		[Register("onItemsChanged", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnItemsChanged_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnItemsChanged(RecyclerView recyclerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsChanged.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnItemsMoved_Landroidx_recyclerview_widget_RecyclerView_IIIHandler()
		{
			if ((object)cb_onItemsMoved_Landroidx_recyclerview_widget_RecyclerView_III == null)
			{
				cb_onItemsMoved_Landroidx_recyclerview_widget_RecyclerView_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIII_V(n_OnItemsMoved_Landroidx_recyclerview_widget_RecyclerView_III));
			}
			return cb_onItemsMoved_Landroidx_recyclerview_widget_RecyclerView_III;
		}

		private static void n_OnItemsMoved_Landroidx_recyclerview_widget_RecyclerView_III(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, int from, int to, int itemCount)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnItemsMoved(recyclerView, from, to, itemCount);
		}

		[Register("onItemsMoved", "(Landroidx/recyclerview/widget/RecyclerView;III)V", "GetOnItemsMoved_Landroidx_recyclerview_widget_RecyclerView_IIIHandler")]
		public unsafe virtual void OnItemsMoved(RecyclerView recyclerView, int from, int to, int itemCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(from);
				ptr[2] = new JniArgumentValue(to);
				ptr[3] = new JniArgumentValue(itemCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsMoved.(Landroidx/recyclerview/widget/RecyclerView;III)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_IIHandler()
		{
			if ((object)cb_onItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_II == null)
			{
				cb_onItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_OnItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_II));
			}
			return cb_onItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_II;
		}

		private static void n_OnItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_II(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, int positionStart, int itemCount)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnItemsRemoved(recyclerView, positionStart, itemCount);
		}

		[Register("onItemsRemoved", "(Landroidx/recyclerview/widget/RecyclerView;II)V", "GetOnItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_IIHandler")]
		public unsafe virtual void OnItemsRemoved(RecyclerView recyclerView, int positionStart, int itemCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(positionStart);
				ptr[2] = new JniArgumentValue(itemCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsRemoved.(Landroidx/recyclerview/widget/RecyclerView;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IIHandler()
		{
			if ((object)cb_onItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_II == null)
			{
				cb_onItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_OnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_II));
			}
			return cb_onItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_II;
		}

		private static void n_OnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_II(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, int positionStart, int itemCount)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnItemsUpdated(recyclerView, positionStart, itemCount);
		}

		[Register("onItemsUpdated", "(Landroidx/recyclerview/widget/RecyclerView;II)V", "GetOnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IIHandler")]
		public unsafe virtual void OnItemsUpdated(RecyclerView recyclerView, int positionStart, int itemCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(positionStart);
				ptr[2] = new JniArgumentValue(itemCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsUpdated.(Landroidx/recyclerview/widget/RecyclerView;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_Handler()
		{
			if ((object)cb_onItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_ == null)
			{
				cb_onItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIL_V(n_OnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_));
			}
			return cb_onItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_;
		}

		private static void n_OnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, int positionStart, int itemCount, IntPtr native_payload)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object payload = Java.Lang.Object.GetObject<Java.Lang.Object>(native_payload, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnItemsUpdated(recyclerView, positionStart, itemCount, payload);
		}

		[Register("onItemsUpdated", "(Landroidx/recyclerview/widget/RecyclerView;IILjava/lang/Object;)V", "GetOnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_Handler")]
		public unsafe virtual void OnItemsUpdated(RecyclerView recyclerView, int positionStart, int itemCount, Java.Lang.Object payload)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(positionStart);
				ptr[2] = new JniArgumentValue(itemCount);
				ptr[3] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsUpdated.(Landroidx/recyclerview/widget/RecyclerView;IILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(payload);
			}
		}

		private static Delegate GetOnLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_onLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_onLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_onLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static void n_OnLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnLayoutChildren(recycler, state);
		}

		[Register("onLayoutChildren", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)V", "GetOnLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual void OnLayoutChildren(Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onLayoutChildren.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_onLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_onLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_onLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static void n_OnLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnLayoutCompleted(state);
		}

		[Register("onLayoutCompleted", "(Landroidx/recyclerview/widget/RecyclerView$State;)V", "GetOnLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual void OnLayoutCompleted(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onLayoutCompleted.(Landroidx/recyclerview/widget/RecyclerView$State;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_IIHandler()
		{
			if ((object)cb_onMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_II == null)
			{
				cb_onMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLII_V(n_OnMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_II));
			}
			return cb_onMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_II;
		}

		private static void n_OnMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_II(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state, int widthSpec, int heightSpec)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnMeasure(recycler, state, widthSpec, heightSpec);
		}

		[Register("onMeasure", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;II)V", "GetOnMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_IIHandler")]
		public unsafe virtual void OnMeasure(Recycler recycler, State state, int widthSpec, int heightSpec)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(widthSpec);
				ptr[3] = new JniArgumentValue(heightSpec);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onMeasure.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_Handler()
		{
			if ((object)cb_onRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_ == null)
			{
				cb_onRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_OnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_));
			}
			return cb_onRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_;
		}

		private static bool n_OnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_focused)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
			return layoutManager.OnRequestChildFocus(parent, child, focused);
		}

		[Register("onRequestChildFocus", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/view/View;)Z", "GetOnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_Handler")]
		public unsafe virtual bool OnRequestChildFocus(RecyclerView parent, View child, View focused)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onRequestChildFocus.(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(focused);
			}
		}

		private static Delegate GetOnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_Handler()
		{
			if ((object)cb_onRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_ == null)
			{
				cb_onRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLL_Z(n_OnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_));
			}
			return cb_onRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_;
		}

		private static bool n_OnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_state, IntPtr native_child, IntPtr native_focused)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
			return layoutManager.OnRequestChildFocus(parent, state, child, focused);
		}

		[Register("onRequestChildFocus", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;Landroid/view/View;)Z", "GetOnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_Handler")]
		public unsafe virtual bool OnRequestChildFocus(RecyclerView parent, State state, View child, View focused)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onRequestChildFocus.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(state);
				GC.KeepAlive(child);
				GC.KeepAlive(focused);
			}
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
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			layoutManager.OnRestoreInstanceState(state);
		}

		[Register("onRestoreInstanceState", "(Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler")]
		public unsafe virtual void OnRestoreInstanceState(IParcelable state)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
		}

		[Register("onSaveInstanceState", "()Landroid/os/Parcelable;", "GetOnSaveInstanceStateHandler")]
		public unsafe virtual IParcelable OnSaveInstanceState()
		{
			return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetOnScrollStateChanged_IHandler()
		{
			if ((object)cb_onScrollStateChanged_I == null)
			{
				cb_onScrollStateChanged_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnScrollStateChanged_I));
			}
			return cb_onScrollStateChanged_I;
		}

		private static void n_OnScrollStateChanged_I(IntPtr jnienv, IntPtr native__this, int state)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnScrollStateChanged(state);
		}

		[Register("onScrollStateChanged", "(I)V", "GetOnScrollStateChanged_IHandler")]
		public unsafe virtual void OnScrollStateChanged(int state)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(state);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onScrollStateChanged.(I)V", this, ptr);
		}

		private static Delegate GetPerformAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_Handler()
		{
			if ((object)cb_performAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_ == null)
			{
				cb_performAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLIL_Z(n_PerformAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_));
			}
			return cb_performAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_;
		}

		private static bool n_PerformAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state, int action, IntPtr native_args)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			Bundle args = Java.Lang.Object.GetObject<Bundle>(native_args, JniHandleOwnership.DoNotTransfer);
			return layoutManager.PerformAccessibilityAction(recycler, state, action, args);
		}

		[Register("performAccessibilityAction", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;ILandroid/os/Bundle;)Z", "GetPerformAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_Handler")]
		public unsafe virtual bool PerformAccessibilityAction(Recycler recycler, State state, int action, Bundle args)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(action);
				ptr[3] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("performAccessibilityAction.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;ILandroid/os/Bundle;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
				GC.KeepAlive(args);
			}
		}

		private static Delegate GetPerformAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_Handler()
		{
			if ((object)cb_performAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_ == null)
			{
				cb_performAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLIL_Z(n_PerformAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_));
			}
			return cb_performAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_;
		}

		private static bool n_PerformAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, IntPtr native_state, IntPtr native_view, int action, IntPtr native_args)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			Bundle args = Java.Lang.Object.GetObject<Bundle>(native_args, JniHandleOwnership.DoNotTransfer);
			return layoutManager.PerformAccessibilityActionForItem(recycler, state, view, action, args);
		}

		[Register("performAccessibilityActionForItem", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;ILandroid/os/Bundle;)Z", "GetPerformAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_Handler")]
		public unsafe virtual bool PerformAccessibilityActionForItem(Recycler recycler, State state, View view, int action, Bundle args)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(action);
				ptr[4] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("performAccessibilityActionForItem.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;ILandroid/os/Bundle;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
				GC.KeepAlive(view);
				GC.KeepAlive(args);
			}
		}

		private static Delegate GetPostOnAnimation_Ljava_lang_Runnable_Handler()
		{
			if ((object)cb_postOnAnimation_Ljava_lang_Runnable_ == null)
			{
				cb_postOnAnimation_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PostOnAnimation_Ljava_lang_Runnable_));
			}
			return cb_postOnAnimation_Ljava_lang_Runnable_;
		}

		private static void n_PostOnAnimation_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_action)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable action = Java.Lang.Object.GetObject<IRunnable>(native_action, JniHandleOwnership.DoNotTransfer);
			layoutManager.PostOnAnimation(action);
		}

		[Register("postOnAnimation", "(Ljava/lang/Runnable;)V", "GetPostOnAnimation_Ljava_lang_Runnable_Handler")]
		public unsafe virtual void PostOnAnimation(IRunnable action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("postOnAnimation.(Ljava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(action);
			}
		}

		private static Delegate GetRemoveAllViewsHandler()
		{
			if ((object)cb_removeAllViews == null)
			{
				cb_removeAllViews = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RemoveAllViews));
			}
			return cb_removeAllViews;
		}

		private static void n_RemoveAllViews(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllViews();
		}

		[Register("removeAllViews", "()V", "GetRemoveAllViewsHandler")]
		public unsafe virtual void RemoveAllViews()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeAllViews.()V", this, null);
		}

		private static Delegate GetRemoveAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			if ((object)cb_removeAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_ == null)
			{
				cb_removeAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_));
			}
			return cb_removeAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_;
		}

		private static void n_RemoveAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			layoutManager.RemoveAndRecycleAllViews(recycler);
		}

		[Register("removeAndRecycleAllViews", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetRemoveAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void RemoveAndRecycleAllViews(Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeAndRecycleAllViews.(Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetRemoveAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			if ((object)cb_removeAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_ == null)
			{
				cb_removeAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RemoveAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_));
			}
			return cb_removeAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_;
		}

		private static void n_RemoveAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_(IntPtr jnienv, IntPtr native__this, IntPtr native_child, IntPtr native_recycler)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			layoutManager.RemoveAndRecycleView(child, recycler);
		}

		[Register("removeAndRecycleView", "(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetRemoveAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void RemoveAndRecycleView(View child, Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeAndRecycleView.(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetRemoveAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			if ((object)cb_removeAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_ == null)
			{
				cb_removeAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_RemoveAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_));
			}
			return cb_removeAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_;
		}

		private static void n_RemoveAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_(IntPtr jnienv, IntPtr native__this, int index, IntPtr native_recycler)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			layoutManager.RemoveAndRecycleViewAt(index, recycler);
		}

		[Register("removeAndRecycleViewAt", "(ILandroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetRemoveAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void RemoveAndRecycleViewAt(int index, Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(index);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeAndRecycleViewAt.(ILandroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetRemoveCallbacks_Ljava_lang_Runnable_Handler()
		{
			if ((object)cb_removeCallbacks_Ljava_lang_Runnable_ == null)
			{
				cb_removeCallbacks_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_RemoveCallbacks_Ljava_lang_Runnable_));
			}
			return cb_removeCallbacks_Ljava_lang_Runnable_;
		}

		private static bool n_RemoveCallbacks_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_action)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable action = Java.Lang.Object.GetObject<IRunnable>(native_action, JniHandleOwnership.DoNotTransfer);
			return layoutManager.RemoveCallbacks(action);
		}

		[Register("removeCallbacks", "(Ljava/lang/Runnable;)Z", "GetRemoveCallbacks_Ljava_lang_Runnable_Handler")]
		public unsafe virtual bool RemoveCallbacks(IRunnable action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeCallbacks.(Ljava/lang/Runnable;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(action);
			}
		}

		private static Delegate GetRemoveDetachedView_Landroid_view_View_Handler()
		{
			if ((object)cb_removeDetachedView_Landroid_view_View_ == null)
			{
				cb_removeDetachedView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveDetachedView_Landroid_view_View_));
			}
			return cb_removeDetachedView_Landroid_view_View_;
		}

		private static void n_RemoveDetachedView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.RemoveDetachedView(child);
		}

		[Register("removeDetachedView", "(Landroid/view/View;)V", "GetRemoveDetachedView_Landroid_view_View_Handler")]
		public unsafe virtual void RemoveDetachedView(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeDetachedView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetRemoveView_Landroid_view_View_Handler()
		{
			if ((object)cb_removeView_Landroid_view_View_ == null)
			{
				cb_removeView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveView_Landroid_view_View_));
			}
			return cb_removeView_Landroid_view_View_;
		}

		private static void n_RemoveView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			layoutManager.RemoveView(child);
		}

		[Register("removeView", "(Landroid/view/View;)V", "GetRemoveView_Landroid_view_View_Handler")]
		public unsafe virtual void RemoveView(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetRemoveViewAt_IHandler()
		{
			if ((object)cb_removeViewAt_I == null)
			{
				cb_removeViewAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_RemoveViewAt_I));
			}
			return cb_removeViewAt_I;
		}

		private static void n_RemoveViewAt_I(IntPtr jnienv, IntPtr native__this, int index)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveViewAt(index);
		}

		[Register("removeViewAt", "(I)V", "GetRemoveViewAt_IHandler")]
		public unsafe virtual void RemoveViewAt(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeViewAt.(I)V", this, ptr);
		}

		private static Delegate GetRequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZHandler()
		{
			if ((object)cb_requestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_Z == null)
			{
				cb_requestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLZ_Z(n_RequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_Z));
			}
			return cb_requestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_Z;
		}

		private static bool n_RequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_rect, bool immediate)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
			return layoutManager.RequestChildRectangleOnScreen(parent, child, rect, immediate);
		}

		[Register("requestChildRectangleOnScreen", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/graphics/Rect;Z)Z", "GetRequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZHandler")]
		public unsafe virtual bool RequestChildRectangleOnScreen(RecyclerView parent, View child, Rect rect, bool immediate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(immediate);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("requestChildRectangleOnScreen.(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/graphics/Rect;Z)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(rect);
			}
		}

		private static Delegate GetRequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZHandler()
		{
			if ((object)cb_requestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZ == null)
			{
				cb_requestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLZZ_Z(n_RequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZ));
			}
			return cb_requestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZ;
		}

		private static bool n_RequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZ(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_rect, bool immediate, bool focusedChildVisible)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
			return layoutManager.RequestChildRectangleOnScreen(parent, child, rect, immediate, focusedChildVisible);
		}

		[Register("requestChildRectangleOnScreen", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/graphics/Rect;ZZ)Z", "GetRequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZHandler")]
		public unsafe virtual bool RequestChildRectangleOnScreen(RecyclerView parent, View child, Rect rect, bool immediate, bool focusedChildVisible)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(immediate);
				ptr[4] = new JniArgumentValue(focusedChildVisible);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("requestChildRectangleOnScreen.(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/graphics/Rect;ZZ)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(rect);
			}
		}

		private static Delegate GetRequestLayoutHandler()
		{
			if ((object)cb_requestLayout == null)
			{
				cb_requestLayout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RequestLayout));
			}
			return cb_requestLayout;
		}

		private static void n_RequestLayout(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestLayout();
		}

		[Register("requestLayout", "()V", "GetRequestLayoutHandler")]
		public unsafe virtual void RequestLayout()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("requestLayout.()V", this, null);
		}

		private static Delegate GetRequestSimpleAnimationsInNextLayoutHandler()
		{
			if ((object)cb_requestSimpleAnimationsInNextLayout == null)
			{
				cb_requestSimpleAnimationsInNextLayout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RequestSimpleAnimationsInNextLayout));
			}
			return cb_requestSimpleAnimationsInNextLayout;
		}

		private static void n_RequestSimpleAnimationsInNextLayout(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestSimpleAnimationsInNextLayout();
		}

		[Register("requestSimpleAnimationsInNextLayout", "()V", "GetRequestSimpleAnimationsInNextLayoutHandler")]
		public unsafe virtual void RequestSimpleAnimationsInNextLayout()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("requestSimpleAnimationsInNextLayout.()V", this, null);
		}

		private static Delegate GetScrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_scrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_scrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPILL_I(n_ScrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_scrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_ScrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, int dx, IntPtr native_recycler, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.ScrollHorizontallyBy(dx, recycler, state);
		}

		[Register("scrollHorizontallyBy", "(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetScrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ScrollHorizontallyBy(int dx, Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(dx);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("scrollHorizontallyBy.(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetScrollToPosition_IHandler()
		{
			if ((object)cb_scrollToPosition_I == null)
			{
				cb_scrollToPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_ScrollToPosition_I));
			}
			return cb_scrollToPosition_I;
		}

		private static void n_ScrollToPosition_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollToPosition(position);
		}

		[Register("scrollToPosition", "(I)V", "GetScrollToPosition_IHandler")]
		public unsafe virtual void ScrollToPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("scrollToPosition.(I)V", this, ptr);
		}

		private static Delegate GetScrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			if ((object)cb_scrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ == null)
			{
				cb_scrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPILL_I(n_ScrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_));
			}
			return cb_scrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_;
		}

		private static int n_ScrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(IntPtr jnienv, IntPtr native__this, int dy, IntPtr native_recycler, IntPtr native_state)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			return layoutManager.ScrollVerticallyBy(dy, recycler, state);
		}

		[Register("scrollVerticallyBy", "(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetScrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ScrollVerticallyBy(int dy, Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(dy);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("scrollVerticallyBy.(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetSetMeasuredDimension_Landroid_graphics_Rect_IIHandler()
		{
			if ((object)cb_setMeasuredDimension_Landroid_graphics_Rect_II == null)
			{
				cb_setMeasuredDimension_Landroid_graphics_Rect_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_SetMeasuredDimension_Landroid_graphics_Rect_II));
			}
			return cb_setMeasuredDimension_Landroid_graphics_Rect_II;
		}

		private static void n_SetMeasuredDimension_Landroid_graphics_Rect_II(IntPtr jnienv, IntPtr native__this, IntPtr native_childrenBounds, int wSpec, int hSpec)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect childrenBounds = Java.Lang.Object.GetObject<Rect>(native_childrenBounds, JniHandleOwnership.DoNotTransfer);
			layoutManager.SetMeasuredDimension(childrenBounds, wSpec, hSpec);
		}

		[Register("setMeasuredDimension", "(Landroid/graphics/Rect;II)V", "GetSetMeasuredDimension_Landroid_graphics_Rect_IIHandler")]
		public unsafe virtual void SetMeasuredDimension(Rect childrenBounds, int wSpec, int hSpec)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(childrenBounds?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(wSpec);
				ptr[2] = new JniArgumentValue(hSpec);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasuredDimension.(Landroid/graphics/Rect;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(childrenBounds);
			}
		}

		private static Delegate GetSetMeasuredDimension_IIHandler()
		{
			if ((object)cb_setMeasuredDimension_II == null)
			{
				cb_setMeasuredDimension_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetMeasuredDimension_II));
			}
			return cb_setMeasuredDimension_II;
		}

		private static void n_SetMeasuredDimension_II(IntPtr jnienv, IntPtr native__this, int widthSize, int heightSize)
		{
			Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMeasuredDimension(widthSize, heightSize);
		}

		[Register("setMeasuredDimension", "(II)V", "GetSetMeasuredDimension_IIHandler")]
		public unsafe virtual void SetMeasuredDimension(int widthSize, int heightSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(widthSize);
			ptr[1] = new JniArgumentValue(heightSize);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasuredDimension.(II)V", this, ptr);
		}

		private static Delegate GetSmoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_IHandler()
		{
			if ((object)cb_smoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_I == null)
			{
				cb_smoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_SmoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_I));
			}
			return cb_smoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_I;
		}

		private static void n_SmoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_I(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, IntPtr native_state, int position)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			layoutManager.SmoothScrollToPosition(recyclerView, state, position);
		}

		[Register("smoothScrollToPosition", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;I)V", "GetSmoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_IHandler")]
		public unsafe virtual void SmoothScrollToPosition(RecyclerView recyclerView, State state, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(position);
				_members.InstanceMethods.InvokeVirtualVoidMethod("smoothScrollToPosition.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetStartSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Handler()
		{
			if ((object)cb_startSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_ == null)
			{
				cb_startSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StartSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_));
			}
			return cb_startSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_;
		}

		private static void n_StartSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_(IntPtr jnienv, IntPtr native__this, IntPtr native_smoothScroller)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SmoothScroller smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(native_smoothScroller, JniHandleOwnership.DoNotTransfer);
			layoutManager.StartSmoothScroll(smoothScroller);
		}

		[Register("startSmoothScroll", "(Landroidx/recyclerview/widget/RecyclerView$SmoothScroller;)V", "GetStartSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Handler")]
		public unsafe virtual void StartSmoothScroll(SmoothScroller smoothScroller)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(smoothScroller?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("startSmoothScroll.(Landroidx/recyclerview/widget/RecyclerView$SmoothScroller;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(smoothScroller);
			}
		}

		private static Delegate GetStopIgnoringView_Landroid_view_View_Handler()
		{
			if ((object)cb_stopIgnoringView_Landroid_view_View_ == null)
			{
				cb_stopIgnoringView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StopIgnoringView_Landroid_view_View_));
			}
			return cb_stopIgnoringView_Landroid_view_View_;
		}

		private static void n_StopIgnoringView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			layoutManager.StopIgnoringView(view);
		}

		[Register("stopIgnoringView", "(Landroid/view/View;)V", "GetStopIgnoringView_Landroid_view_View_Handler")]
		public unsafe virtual void StopIgnoringView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("stopIgnoringView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetSupportsPredictiveItemAnimationsHandler()
		{
			if ((object)cb_supportsPredictiveItemAnimations == null)
			{
				cb_supportsPredictiveItemAnimations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_SupportsPredictiveItemAnimations));
			}
			return cb_supportsPredictiveItemAnimations;
		}

		private static bool n_SupportsPredictiveItemAnimations(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportsPredictiveItemAnimations();
		}

		[Register("supportsPredictiveItemAnimations", "()Z", "GetSupportsPredictiveItemAnimationsHandler")]
		public unsafe virtual bool SupportsPredictiveItemAnimations()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("supportsPredictiveItemAnimations.()Z", this, null);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$LayoutManager", DoNotGenerateAcw = true)]
	internal class LayoutManagerInvoker : LayoutManager
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$LayoutManager", typeof(LayoutManagerInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public LayoutManagerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("generateDefaultLayoutParams", "()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateDefaultLayoutParamsHandler")]
		public unsafe override LayoutParams GenerateDefaultLayoutParams()
		{
			return Java.Lang.Object.GetObject<LayoutParams>(_members.InstanceMethods.InvokeAbstractObjectMethod("generateDefaultLayoutParams.()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$LayoutParams", DoNotGenerateAcw = true)]
	public new class LayoutParams : MarginLayoutParams
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$LayoutParams", typeof(LayoutParams));

		private static Delegate cb_isItemChanged;

		private static Delegate cb_isItemRemoved;

		private static Delegate cb_isViewInvalid;

		private static Delegate cb_getViewAdapterPosition;

		private static Delegate cb_getViewLayoutPosition;

		private static Delegate cb_getViewPosition;

		private static Delegate cb_viewNeedsUpdate;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool IsItemChanged
		{
			[Register("isItemChanged", "()Z", "GetIsItemChangedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isItemChanged.()Z", this, null);
			}
		}

		public unsafe virtual bool IsItemRemoved
		{
			[Register("isItemRemoved", "()Z", "GetIsItemRemovedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isItemRemoved.()Z", this, null);
			}
		}

		public unsafe virtual bool IsViewInvalid
		{
			[Register("isViewInvalid", "()Z", "GetIsViewInvalidHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isViewInvalid.()Z", this, null);
			}
		}

		public unsafe virtual int ViewAdapterPosition
		{
			[Register("getViewAdapterPosition", "()I", "GetGetViewAdapterPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getViewAdapterPosition.()I", this, null);
			}
		}

		public unsafe virtual int ViewLayoutPosition
		{
			[Register("getViewLayoutPosition", "()I", "GetGetViewLayoutPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getViewLayoutPosition.()I", this, null);
			}
		}

		public unsafe virtual int ViewPosition
		{
			[Register("getViewPosition", "()I", "GetGetViewPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getViewPosition.()I", this, null);
			}
		}

		protected LayoutParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe LayoutParams(Context c, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$LayoutParams;)V", "")]
		public unsafe LayoutParams(ViewGroup.LayoutParams source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$MarginLayoutParams;)V", "")]
		public unsafe LayoutParams(MarginLayoutParams source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Landroidx/recyclerview/widget/RecyclerView$LayoutParams;)V", "")]
		public unsafe LayoutParams(LayoutParams source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/recyclerview/widget/RecyclerView$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/recyclerview/widget/RecyclerView$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
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

		private static Delegate GetIsItemChangedHandler()
		{
			if ((object)cb_isItemChanged == null)
			{
				cb_isItemChanged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsItemChanged));
			}
			return cb_isItemChanged;
		}

		private static bool n_IsItemChanged(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsItemChanged;
		}

		private static Delegate GetIsItemRemovedHandler()
		{
			if ((object)cb_isItemRemoved == null)
			{
				cb_isItemRemoved = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsItemRemoved));
			}
			return cb_isItemRemoved;
		}

		private static bool n_IsItemRemoved(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsItemRemoved;
		}

		private static Delegate GetIsViewInvalidHandler()
		{
			if ((object)cb_isViewInvalid == null)
			{
				cb_isViewInvalid = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsViewInvalid));
			}
			return cb_isViewInvalid;
		}

		private static bool n_IsViewInvalid(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsViewInvalid;
		}

		private static Delegate GetGetViewAdapterPositionHandler()
		{
			if ((object)cb_getViewAdapterPosition == null)
			{
				cb_getViewAdapterPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetViewAdapterPosition));
			}
			return cb_getViewAdapterPosition;
		}

		private static int n_GetViewAdapterPosition(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewAdapterPosition;
		}

		private static Delegate GetGetViewLayoutPositionHandler()
		{
			if ((object)cb_getViewLayoutPosition == null)
			{
				cb_getViewLayoutPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetViewLayoutPosition));
			}
			return cb_getViewLayoutPosition;
		}

		private static int n_GetViewLayoutPosition(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewLayoutPosition;
		}

		private static Delegate GetGetViewPositionHandler()
		{
			if ((object)cb_getViewPosition == null)
			{
				cb_getViewPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetViewPosition));
			}
			return cb_getViewPosition;
		}

		private static int n_GetViewPosition(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewPosition;
		}

		private static Delegate GetViewNeedsUpdateHandler()
		{
			if ((object)cb_viewNeedsUpdate == null)
			{
				cb_viewNeedsUpdate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_ViewNeedsUpdate));
			}
			return cb_viewNeedsUpdate;
		}

		private static bool n_ViewNeedsUpdate(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewNeedsUpdate();
		}

		[Register("viewNeedsUpdate", "()Z", "GetViewNeedsUpdateHandler")]
		public unsafe virtual bool ViewNeedsUpdate()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("viewNeedsUpdate.()Z", this, null);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener", "", "AndroidX.RecyclerView.Widget.RecyclerView/IOnChildAttachStateChangeListenerInvoker")]
	public interface IOnChildAttachStateChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onChildViewAttachedToWindow", "(Landroid/view/View;)V", "GetOnChildViewAttachedToWindow_Landroid_view_View_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IOnChildAttachStateChangeListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		void OnChildViewAttachedToWindow(View view);

		[Register("onChildViewDetachedFromWindow", "(Landroid/view/View;)V", "GetOnChildViewDetachedFromWindow_Landroid_view_View_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IOnChildAttachStateChangeListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		void OnChildViewDetachedFromWindow(View view);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener", DoNotGenerateAcw = true)]
	internal class IOnChildAttachStateChangeListenerInvoker : Java.Lang.Object, IOnChildAttachStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener", typeof(IOnChildAttachStateChangeListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onChildViewAttachedToWindow_Landroid_view_View_;

		private IntPtr id_onChildViewAttachedToWindow_Landroid_view_View_;

		private static Delegate cb_onChildViewDetachedFromWindow_Landroid_view_View_;

		private IntPtr id_onChildViewDetachedFromWindow_Landroid_view_View_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOnChildAttachStateChangeListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnChildAttachStateChangeListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.recyclerview.widget.RecyclerView.OnChildAttachStateChangeListener"));
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

		public IOnChildAttachStateChangeListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnChildViewAttachedToWindow_Landroid_view_View_Handler()
		{
			if ((object)cb_onChildViewAttachedToWindow_Landroid_view_View_ == null)
			{
				cb_onChildViewAttachedToWindow_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnChildViewAttachedToWindow_Landroid_view_View_));
			}
			return cb_onChildViewAttachedToWindow_Landroid_view_View_;
		}

		private static void n_OnChildViewAttachedToWindow_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			IOnChildAttachStateChangeListener onChildAttachStateChangeListener = Java.Lang.Object.GetObject<IOnChildAttachStateChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			onChildAttachStateChangeListener.OnChildViewAttachedToWindow(view);
		}

		public unsafe void OnChildViewAttachedToWindow(View view)
		{
			if (id_onChildViewAttachedToWindow_Landroid_view_View_ == IntPtr.Zero)
			{
				id_onChildViewAttachedToWindow_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onChildViewAttachedToWindow", "(Landroid/view/View;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(view?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onChildViewAttachedToWindow_Landroid_view_View_, ptr);
		}

		private static Delegate GetOnChildViewDetachedFromWindow_Landroid_view_View_Handler()
		{
			if ((object)cb_onChildViewDetachedFromWindow_Landroid_view_View_ == null)
			{
				cb_onChildViewDetachedFromWindow_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnChildViewDetachedFromWindow_Landroid_view_View_));
			}
			return cb_onChildViewDetachedFromWindow_Landroid_view_View_;
		}

		private static void n_OnChildViewDetachedFromWindow_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			IOnChildAttachStateChangeListener onChildAttachStateChangeListener = Java.Lang.Object.GetObject<IOnChildAttachStateChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			onChildAttachStateChangeListener.OnChildViewDetachedFromWindow(view);
		}

		public unsafe void OnChildViewDetachedFromWindow(View view)
		{
			if (id_onChildViewDetachedFromWindow_Landroid_view_View_ == IntPtr.Zero)
			{
				id_onChildViewDetachedFromWindow_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onChildViewDetachedFromWindow", "(Landroid/view/View;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(view?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onChildViewDetachedFromWindow_Landroid_view_View_, ptr);
		}
	}

	public class ChildViewAttachedToWindowEventArgs : EventArgs
	{
		private View view;

		public ChildViewAttachedToWindowEventArgs(View view)
		{
			this.view = view;
		}
	}

	public class ChildViewDetachedFromWindowEventArgs : EventArgs
	{
		private View view;

		public ChildViewDetachedFromWindowEventArgs(View view)
		{
			this.view = view;
		}
	}

	[Register("mono/androidx/recyclerview/widget/RecyclerView_OnChildAttachStateChangeListenerImplementor")]
	internal sealed class IOnChildAttachStateChangeListenerImplementor : Java.Lang.Object, IOnChildAttachStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<ChildViewAttachedToWindowEventArgs> OnChildViewAttachedToWindowHandler;

		public EventHandler<ChildViewDetachedFromWindowEventArgs> OnChildViewDetachedFromWindowHandler;

		public IOnChildAttachStateChangeListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/androidx/recyclerview/widget/RecyclerView_OnChildAttachStateChangeListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnChildViewAttachedToWindow(View view)
		{
			OnChildViewAttachedToWindowHandler?.Invoke(sender, new ChildViewAttachedToWindowEventArgs(view));
		}

		public void OnChildViewDetachedFromWindow(View view)
		{
			OnChildViewDetachedFromWindowHandler?.Invoke(sender, new ChildViewDetachedFromWindowEventArgs(view));
		}

		internal static bool __IsEmpty(IOnChildAttachStateChangeListenerImplementor value)
		{
			if (value.OnChildViewAttachedToWindowHandler == null)
			{
				return value.OnChildViewDetachedFromWindowHandler == null;
			}
			return false;
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnFlingListener", DoNotGenerateAcw = true)]
	public abstract class OnFlingListener : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnFlingListener", typeof(OnFlingListener));

		private static Delegate cb_onFling_II;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OnFlingListener(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OnFlingListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnFling_IIHandler()
		{
			if ((object)cb_onFling_II == null)
			{
				cb_onFling_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_Z(n_OnFling_II));
			}
			return cb_onFling_II;
		}

		private static bool n_OnFling_II(IntPtr jnienv, IntPtr native__this, int velocityX, int velocityY)
		{
			return Java.Lang.Object.GetObject<OnFlingListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFling(velocityX, velocityY);
		}

		[Register("onFling", "(II)Z", "GetOnFling_IIHandler")]
		public abstract bool OnFling(int velocityX, int velocityY);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnFlingListener", DoNotGenerateAcw = true)]
	internal class OnFlingListenerInvoker : OnFlingListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnFlingListener", typeof(OnFlingListenerInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public OnFlingListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onFling", "(II)Z", "GetOnFling_IIHandler")]
		public unsafe override bool OnFling(int velocityX, int velocityY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(velocityX);
			ptr[1] = new JniArgumentValue(velocityY);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("onFling.(II)Z", this, ptr);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnItemTouchListener", "", "AndroidX.RecyclerView.Widget.RecyclerView/IOnItemTouchListenerInvoker")]
	public interface IOnItemTouchListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onInterceptTouchEvent", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)Z", "GetOnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IOnItemTouchListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		bool OnInterceptTouchEvent(RecyclerView recyclerView, MotionEvent @event);

		[Register("onRequestDisallowInterceptTouchEvent", "(Z)V", "GetOnRequestDisallowInterceptTouchEvent_ZHandler:AndroidX.RecyclerView.Widget.RecyclerView/IOnItemTouchListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		void OnRequestDisallowInterceptTouchEvent(bool disallow);

		[Register("onTouchEvent", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)V", "GetOnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IOnItemTouchListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		void OnTouchEvent(RecyclerView recyclerView, MotionEvent @event);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnItemTouchListener", DoNotGenerateAcw = true)]
	internal class IOnItemTouchListenerInvoker : Java.Lang.Object, IOnItemTouchListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnItemTouchListener", typeof(IOnItemTouchListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_;

		private IntPtr id_onInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_;

		private static Delegate cb_onRequestDisallowInterceptTouchEvent_Z;

		private IntPtr id_onRequestDisallowInterceptTouchEvent_Z;

		private static Delegate cb_onTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_;

		private IntPtr id_onTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOnItemTouchListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnItemTouchListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.recyclerview.widget.RecyclerView.OnItemTouchListener"));
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

		public IOnItemTouchListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler()
		{
			if ((object)cb_onInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_ == null)
			{
				cb_onInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_OnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_));
			}
			return cb_onInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_;
		}

		private static bool n_OnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, IntPtr native__event)
		{
			IOnItemTouchListener onItemTouchListener = Java.Lang.Object.GetObject<IOnItemTouchListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			MotionEvent motionEvent = Java.Lang.Object.GetObject<MotionEvent>(native__event, JniHandleOwnership.DoNotTransfer);
			return onItemTouchListener.OnInterceptTouchEvent(recyclerView, motionEvent);
		}

		public unsafe bool OnInterceptTouchEvent(RecyclerView recyclerView, MotionEvent @event)
		{
			if (id_onInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_ == IntPtr.Zero)
			{
				id_onInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_ = JNIEnv.GetMethodID(class_ref, "onInterceptTouchEvent", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)Z");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(recyclerView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(@event?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_onInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_, ptr);
		}

		private static Delegate GetOnRequestDisallowInterceptTouchEvent_ZHandler()
		{
			if ((object)cb_onRequestDisallowInterceptTouchEvent_Z == null)
			{
				cb_onRequestDisallowInterceptTouchEvent_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnRequestDisallowInterceptTouchEvent_Z));
			}
			return cb_onRequestDisallowInterceptTouchEvent_Z;
		}

		private static void n_OnRequestDisallowInterceptTouchEvent_Z(IntPtr jnienv, IntPtr native__this, bool disallow)
		{
			Java.Lang.Object.GetObject<IOnItemTouchListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnRequestDisallowInterceptTouchEvent(disallow);
		}

		public unsafe void OnRequestDisallowInterceptTouchEvent(bool disallow)
		{
			if (id_onRequestDisallowInterceptTouchEvent_Z == IntPtr.Zero)
			{
				id_onRequestDisallowInterceptTouchEvent_Z = JNIEnv.GetMethodID(class_ref, "onRequestDisallowInterceptTouchEvent", "(Z)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(disallow);
			JNIEnv.CallVoidMethod(base.Handle, id_onRequestDisallowInterceptTouchEvent_Z, ptr);
		}

		private static Delegate GetOnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler()
		{
			if ((object)cb_onTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_ == null)
			{
				cb_onTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_));
			}
			return cb_onTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_;
		}

		private static void n_OnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, IntPtr native__event)
		{
			IOnItemTouchListener onItemTouchListener = Java.Lang.Object.GetObject<IOnItemTouchListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			MotionEvent motionEvent = Java.Lang.Object.GetObject<MotionEvent>(native__event, JniHandleOwnership.DoNotTransfer);
			onItemTouchListener.OnTouchEvent(recyclerView, motionEvent);
		}

		public unsafe void OnTouchEvent(RecyclerView recyclerView, MotionEvent @event)
		{
			if (id_onTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_ == IntPtr.Zero)
			{
				id_onTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_ = JNIEnv.GetMethodID(class_ref, "onTouchEvent", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(recyclerView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(@event?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_, ptr);
		}
	}

	public class InterceptTouchEventEventArgs : EventArgs
	{
		private bool handled;

		private RecyclerView recyclerView;

		private MotionEvent @event;

		public bool Handled => handled;

		public InterceptTouchEventEventArgs(bool handled, RecyclerView recyclerView, MotionEvent @event)
		{
			this.handled = handled;
			this.recyclerView = recyclerView;
			this.@event = @event;
		}
	}

	public class RequestDisallowInterceptTouchEventEventArgs : EventArgs
	{
		private bool disallow;

		public RequestDisallowInterceptTouchEventEventArgs(bool disallow)
		{
			this.disallow = disallow;
		}
	}

	public class TouchEventEventArgs : EventArgs
	{
		private RecyclerView recyclerView;

		private MotionEvent @event;

		public TouchEventEventArgs(RecyclerView recyclerView, MotionEvent @event)
		{
			this.recyclerView = recyclerView;
			this.@event = @event;
		}
	}

	[Register("mono/androidx/recyclerview/widget/RecyclerView_OnItemTouchListenerImplementor")]
	internal sealed class IOnItemTouchListenerImplementor : Java.Lang.Object, IOnItemTouchListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<InterceptTouchEventEventArgs> OnInterceptTouchEventHandler;

		public EventHandler<RequestDisallowInterceptTouchEventEventArgs> OnRequestDisallowInterceptTouchEventHandler;

		public EventHandler<TouchEventEventArgs> OnTouchEventHandler;

		public IOnItemTouchListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/androidx/recyclerview/widget/RecyclerView_OnItemTouchListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public bool OnInterceptTouchEvent(RecyclerView recyclerView, MotionEvent @event)
		{
			EventHandler<InterceptTouchEventEventArgs> onInterceptTouchEventHandler = OnInterceptTouchEventHandler;
			if (onInterceptTouchEventHandler == null)
			{
				return false;
			}
			InterceptTouchEventEventArgs e = new InterceptTouchEventEventArgs(handled: true, recyclerView, @event);
			onInterceptTouchEventHandler(sender, e);
			return e.Handled;
		}

		public void OnRequestDisallowInterceptTouchEvent(bool disallow)
		{
			OnRequestDisallowInterceptTouchEventHandler?.Invoke(sender, new RequestDisallowInterceptTouchEventEventArgs(disallow));
		}

		public void OnTouchEvent(RecyclerView recyclerView, MotionEvent @event)
		{
			OnTouchEventHandler?.Invoke(sender, new TouchEventEventArgs(recyclerView, @event));
		}

		internal static bool __IsEmpty(IOnItemTouchListenerImplementor value)
		{
			if (value.OnInterceptTouchEventHandler == null && value.OnRequestDisallowInterceptTouchEventHandler == null)
			{
				return value.OnTouchEventHandler == null;
			}
			return false;
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnScrollListener", DoNotGenerateAcw = true)]
	public abstract class OnScrollListener : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnScrollListener", typeof(OnScrollListener));

		private static Delegate cb_onScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_I;

		private static Delegate cb_onScrolled_Landroidx_recyclerview_widget_RecyclerView_II;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OnScrollListener(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OnScrollListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_IHandler()
		{
			if ((object)cb_onScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_I == null)
			{
				cb_onScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_OnScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_I));
			}
			return cb_onScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_I;
		}

		private static void n_OnScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_I(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, int newState)
		{
			OnScrollListener onScrollListener = Java.Lang.Object.GetObject<OnScrollListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			onScrollListener.OnScrollStateChanged(recyclerView, newState);
		}

		[Register("onScrollStateChanged", "(Landroidx/recyclerview/widget/RecyclerView;I)V", "GetOnScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_IHandler")]
		public unsafe virtual void OnScrollStateChanged(RecyclerView recyclerView, int newState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newState);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onScrollStateChanged.(Landroidx/recyclerview/widget/RecyclerView;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnScrolled_Landroidx_recyclerview_widget_RecyclerView_IIHandler()
		{
			if ((object)cb_onScrolled_Landroidx_recyclerview_widget_RecyclerView_II == null)
			{
				cb_onScrolled_Landroidx_recyclerview_widget_RecyclerView_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_OnScrolled_Landroidx_recyclerview_widget_RecyclerView_II));
			}
			return cb_onScrolled_Landroidx_recyclerview_widget_RecyclerView_II;
		}

		private static void n_OnScrolled_Landroidx_recyclerview_widget_RecyclerView_II(IntPtr jnienv, IntPtr native__this, IntPtr native_recyclerView, int dx, int dy)
		{
			OnScrollListener onScrollListener = Java.Lang.Object.GetObject<OnScrollListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
			onScrollListener.OnScrolled(recyclerView, dx, dy);
		}

		[Register("onScrolled", "(Landroidx/recyclerview/widget/RecyclerView;II)V", "GetOnScrolled_Landroidx_recyclerview_widget_RecyclerView_IIHandler")]
		public unsafe virtual void OnScrolled(RecyclerView recyclerView, int dx, int dy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(dx);
				ptr[2] = new JniArgumentValue(dy);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onScrolled.(Landroidx/recyclerview/widget/RecyclerView;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnScrollListener", DoNotGenerateAcw = true)]
	internal class OnScrollListenerInvoker : OnScrollListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnScrollListener", typeof(OnScrollListenerInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public OnScrollListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$RecycledViewPool", DoNotGenerateAcw = true)]
	public class RecycledViewPool : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$RecycledViewPool", typeof(RecycledViewPool));

		private static Delegate cb_clear;

		private static Delegate cb_getRecycledView_I;

		private static Delegate cb_getRecycledViewCount_I;

		private static Delegate cb_putRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate cb_setMaxRecycledViews_II;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected RecycledViewPool(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe RecycledViewPool()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetClearHandler()
		{
			if ((object)cb_clear == null)
			{
				cb_clear = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Clear));
			}
			return cb_clear;
		}

		private static void n_Clear(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<RecycledViewPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
		}

		[Register("clear", "()V", "GetClearHandler")]
		public unsafe virtual void Clear()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
		}

		private static Delegate GetGetRecycledView_IHandler()
		{
			if ((object)cb_getRecycledView_I == null)
			{
				cb_getRecycledView_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetRecycledView_I));
			}
			return cb_getRecycledView_I;
		}

		private static IntPtr n_GetRecycledView_I(IntPtr jnienv, IntPtr native__this, int viewType)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecycledViewPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRecycledView(viewType));
		}

		[Register("getRecycledView", "(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetGetRecycledView_IHandler")]
		public unsafe virtual ViewHolder GetRecycledView(int viewType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewType);
			return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRecycledView.(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetRecycledViewCount_IHandler()
		{
			if ((object)cb_getRecycledViewCount_I == null)
			{
				cb_getRecycledViewCount_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetRecycledViewCount_I));
			}
			return cb_getRecycledViewCount_I;
		}

		private static int n_GetRecycledViewCount_I(IntPtr jnienv, IntPtr native__this, int viewType)
		{
			return Java.Lang.Object.GetObject<RecycledViewPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRecycledViewCount(viewType);
		}

		[Register("getRecycledViewCount", "(I)I", "GetGetRecycledViewCount_IHandler")]
		public unsafe virtual int GetRecycledViewCount(int viewType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewType);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRecycledViewCount.(I)I", this, ptr);
		}

		private static Delegate GetPutRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_putRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_putRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PutRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_putRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static void n_PutRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_scrap)
		{
			RecycledViewPool recycledViewPool = Java.Lang.Object.GetObject<RecycledViewPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder scrap = Java.Lang.Object.GetObject<ViewHolder>(native_scrap, JniHandleOwnership.DoNotTransfer);
			recycledViewPool.PutRecycledView(scrap);
		}

		[Register("putRecycledView", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetPutRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void PutRecycledView(ViewHolder scrap)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(scrap?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("putRecycledView.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(scrap);
			}
		}

		private static Delegate GetSetMaxRecycledViews_IIHandler()
		{
			if ((object)cb_setMaxRecycledViews_II == null)
			{
				cb_setMaxRecycledViews_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetMaxRecycledViews_II));
			}
			return cb_setMaxRecycledViews_II;
		}

		private static void n_SetMaxRecycledViews_II(IntPtr jnienv, IntPtr native__this, int viewType, int max)
		{
			Java.Lang.Object.GetObject<RecycledViewPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxRecycledViews(viewType, max);
		}

		[Register("setMaxRecycledViews", "(II)V", "GetSetMaxRecycledViews_IIHandler")]
		public unsafe virtual void SetMaxRecycledViews(int viewType, int max)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewType);
			ptr[1] = new JniArgumentValue(max);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxRecycledViews.(II)V", this, ptr);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$Recycler", DoNotGenerateAcw = true)]
	public sealed class Recycler : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$Recycler", typeof(Recycler));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe IList<ViewHolder> ScrapList
		{
			[Register("getScrapList", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<ViewHolder>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getScrapList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Recycler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/recyclerview/widget/RecyclerView;)V", "")]
		public unsafe Recycler(RecyclerView __self)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			string constructorSignature = "(L" + JNIEnv.GetJniName(GetType().DeclaringType) + ";)V";
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(__self?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance(constructorSignature, GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance(constructorSignature, this, ptr);
			}
			finally
			{
				GC.KeepAlive(__self);
			}
		}

		[Register("bindViewToPosition", "(Landroid/view/View;I)V", "")]
		public unsafe void BindViewToPosition(View view, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				_members.InstanceMethods.InvokeAbstractVoidMethod("bindViewToPosition.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[Register("clear", "()V", "")]
		public unsafe void Clear()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
		}

		[Register("convertPreLayoutPositionToPostLayout", "(I)I", "")]
		public unsafe int ConvertPreLayoutPositionToPostLayout(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeAbstractInt32Method("convertPreLayoutPositionToPostLayout.(I)I", this, ptr);
		}

		[Register("getViewForPosition", "(I)Landroid/view/View;", "")]
		public unsafe View GetViewForPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeAbstractObjectMethod("getViewForPosition.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("recycleView", "(Landroid/view/View;)V", "")]
		public unsafe void RecycleView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("recycleView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[Register("setViewCacheSize", "(I)V", "")]
		public unsafe void SetViewCacheSize(int viewCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewCount);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setViewCacheSize.(I)V", this, ptr);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$RecyclerListener", "", "AndroidX.RecyclerView.Widget.RecyclerView/IRecyclerListenerInvoker")]
	public interface IRecyclerListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onViewRecycled", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IRecyclerListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		void OnViewRecycled(ViewHolder holder);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$RecyclerListener", DoNotGenerateAcw = true)]
	internal class IRecyclerListenerInvoker : Java.Lang.Object, IRecyclerListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$RecyclerListener", typeof(IRecyclerListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private IntPtr id_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IRecyclerListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IRecyclerListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.recyclerview.widget.RecyclerView.RecyclerListener"));
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

		public IRecyclerListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			if ((object)cb_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == null)
			{
				cb_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_));
			}
			return cb_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;
		}

		private static void n_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_holder)
		{
			IRecyclerListener recyclerListener = Java.Lang.Object.GetObject<IRecyclerListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewHolder holder = Java.Lang.Object.GetObject<ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
			recyclerListener.OnViewRecycled(holder);
		}

		public unsafe void OnViewRecycled(ViewHolder holder)
		{
			if (id_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ == IntPtr.Zero)
			{
				id_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ = JNIEnv.GetMethodID(class_ref, "onViewRecycled", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(holder?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_, ptr);
		}
	}

	public class RecyclerEventArgs : EventArgs
	{
		private ViewHolder holder;

		public RecyclerEventArgs(ViewHolder holder)
		{
			this.holder = holder;
		}
	}

	[Register("mono/androidx/recyclerview/widget/RecyclerView_RecyclerListenerImplementor")]
	internal sealed class IRecyclerListenerImplementor : Java.Lang.Object, IRecyclerListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<RecyclerEventArgs> Handler;

		public IRecyclerListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/androidx/recyclerview/widget/RecyclerView_RecyclerListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnViewRecycled(ViewHolder holder)
		{
			Handler?.Invoke(sender, new RecyclerEventArgs(holder));
		}

		internal static bool __IsEmpty(IRecyclerListenerImplementor value)
		{
			return value.Handler == null;
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$SmoothScroller", DoNotGenerateAcw = true)]
	public abstract class SmoothScroller : Java.Lang.Object
	{
		[Register("androidx/recyclerview/widget/RecyclerView$SmoothScroller$Action", DoNotGenerateAcw = true)]
		public class Action : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$SmoothScroller$Action", typeof(Action));

			private static Delegate cb_getDuration;

			private static Delegate cb_setDuration_I;

			private static Delegate cb_getDx;

			private static Delegate cb_setDx_I;

			private static Delegate cb_getDy;

			private static Delegate cb_setDy_I;

			private static Delegate cb_getInterpolator;

			private static Delegate cb_setInterpolator_Landroid_view_animation_Interpolator_;

			private static Delegate cb_jumpTo_I;

			private static Delegate cb_update_IIILandroid_view_animation_Interpolator_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual int Duration
			{
				[Register("getDuration", "()I", "GetGetDurationHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getDuration.()I", this, null);
				}
				[Register("setDuration", "(I)V", "GetSetDuration_IHandler")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDuration.(I)V", this, ptr);
				}
			}

			public unsafe virtual int Dx
			{
				[Register("getDx", "()I", "GetGetDxHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getDx.()I", this, null);
				}
				[Register("setDx", "(I)V", "GetSetDx_IHandler")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDx.(I)V", this, ptr);
				}
			}

			public unsafe virtual int Dy
			{
				[Register("getDy", "()I", "GetGetDyHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getDy.()I", this, null);
				}
				[Register("setDy", "(I)V", "GetSetDy_IHandler")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDy.(I)V", this, ptr);
				}
			}

			public unsafe virtual IInterpolator Interpolator
			{
				[Register("getInterpolator", "()Landroid/view/animation/Interpolator;", "GetGetInterpolatorHandler")]
				get
				{
					return Java.Lang.Object.GetObject<IInterpolator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInterpolator.()Landroid/view/animation/Interpolator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setInterpolator", "(Landroid/view/animation/Interpolator;)V", "GetSetInterpolator_Landroid_view_animation_Interpolator_Handler")]
				set
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
						_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolator.(Landroid/view/animation/Interpolator;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(value);
					}
				}
			}

			protected Action(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(II)V", "")]
			public unsafe Action(int dx, int dy)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(dx);
					ptr[1] = new JniArgumentValue(dy);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
				}
			}

			[Register(".ctor", "(III)V", "")]
			public unsafe Action(int dx, int dy, int duration)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(dx);
					ptr[1] = new JniArgumentValue(dy);
					ptr[2] = new JniArgumentValue(duration);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(III)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(III)V", this, ptr);
				}
			}

			[Register(".ctor", "(IIILandroid/view/animation/Interpolator;)V", "")]
			public unsafe Action(int dx, int dy, int duration, IInterpolator interpolator)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(dx);
					ptr[1] = new JniArgumentValue(dy);
					ptr[2] = new JniArgumentValue(duration);
					ptr[3] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(IIILandroid/view/animation/Interpolator;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(IIILandroid/view/animation/Interpolator;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(interpolator);
				}
			}

			private static Delegate GetGetDurationHandler()
			{
				if ((object)cb_getDuration == null)
				{
					cb_getDuration = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetDuration));
				}
				return cb_getDuration;
			}

			private static int n_GetDuration(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
			}

			private static Delegate GetSetDuration_IHandler()
			{
				if ((object)cb_setDuration_I == null)
				{
					cb_setDuration_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetDuration_I));
				}
				return cb_setDuration_I;
			}

			private static void n_SetDuration_I(IntPtr jnienv, IntPtr native__this, int duration)
			{
				Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration = duration;
			}

			private static Delegate GetGetDxHandler()
			{
				if ((object)cb_getDx == null)
				{
					cb_getDx = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetDx));
				}
				return cb_getDx;
			}

			private static int n_GetDx(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dx;
			}

			private static Delegate GetSetDx_IHandler()
			{
				if ((object)cb_setDx_I == null)
				{
					cb_setDx_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetDx_I));
				}
				return cb_setDx_I;
			}

			private static void n_SetDx_I(IntPtr jnienv, IntPtr native__this, int dx)
			{
				Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dx = dx;
			}

			private static Delegate GetGetDyHandler()
			{
				if ((object)cb_getDy == null)
				{
					cb_getDy = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetDy));
				}
				return cb_getDy;
			}

			private static int n_GetDy(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dy;
			}

			private static Delegate GetSetDy_IHandler()
			{
				if ((object)cb_setDy_I == null)
				{
					cb_setDy_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetDy_I));
				}
				return cb_setDy_I;
			}

			private static void n_SetDy_I(IntPtr jnienv, IntPtr native__this, int dy)
			{
				Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dy = dy;
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolator);
			}

			private static Delegate GetSetInterpolator_Landroid_view_animation_Interpolator_Handler()
			{
				if ((object)cb_setInterpolator_Landroid_view_animation_Interpolator_ == null)
				{
					cb_setInterpolator_Landroid_view_animation_Interpolator_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetInterpolator_Landroid_view_animation_Interpolator_));
				}
				return cb_setInterpolator_Landroid_view_animation_Interpolator_;
			}

			private static void n_SetInterpolator_Landroid_view_animation_Interpolator_(IntPtr jnienv, IntPtr native__this, IntPtr native_interpolator)
			{
				Action action = Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IInterpolator interpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
				action.Interpolator = interpolator;
			}

			private static Delegate GetJumpTo_IHandler()
			{
				if ((object)cb_jumpTo_I == null)
				{
					cb_jumpTo_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_JumpTo_I));
				}
				return cb_jumpTo_I;
			}

			private static void n_JumpTo_I(IntPtr jnienv, IntPtr native__this, int targetPosition)
			{
				Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).JumpTo(targetPosition);
			}

			[Register("jumpTo", "(I)V", "GetJumpTo_IHandler")]
			public unsafe virtual void JumpTo(int targetPosition)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(targetPosition);
				_members.InstanceMethods.InvokeVirtualVoidMethod("jumpTo.(I)V", this, ptr);
			}

			private static Delegate GetUpdate_IIILandroid_view_animation_Interpolator_Handler()
			{
				if ((object)cb_update_IIILandroid_view_animation_Interpolator_ == null)
				{
					cb_update_IIILandroid_view_animation_Interpolator_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIIL_V(n_Update_IIILandroid_view_animation_Interpolator_));
				}
				return cb_update_IIILandroid_view_animation_Interpolator_;
			}

			private static void n_Update_IIILandroid_view_animation_Interpolator_(IntPtr jnienv, IntPtr native__this, int dx, int dy, int duration, IntPtr native_interpolator)
			{
				Action action = Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IInterpolator interpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
				action.Update(dx, dy, duration, interpolator);
			}

			[Register("update", "(IIILandroid/view/animation/Interpolator;)V", "GetUpdate_IIILandroid_view_animation_Interpolator_Handler")]
			public unsafe virtual void Update(int dx, int dy, int duration, IInterpolator interpolator)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(dx);
					ptr[1] = new JniArgumentValue(dy);
					ptr[2] = new JniArgumentValue(duration);
					ptr[3] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
					_members.InstanceMethods.InvokeVirtualVoidMethod("update.(IIILandroid/view/animation/Interpolator;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(interpolator);
				}
			}
		}

		[Register("androidx/recyclerview/widget/RecyclerView$SmoothScroller$ScrollVectorProvider", "", "AndroidX.RecyclerView.Widget.RecyclerView/SmoothScroller/IScrollVectorProviderInvoker")]
		public interface IScrollVectorProvider : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("computeScrollVectorForPosition", "(I)Landroid/graphics/PointF;", "GetComputeScrollVectorForPosition_IHandler:AndroidX.RecyclerView.Widget.RecyclerView/SmoothScroller/IScrollVectorProviderInvoker, Xamarin.AndroidX.RecyclerView")]
			PointF ComputeScrollVectorForPosition(int targetPosition);
		}

		[Register("androidx/recyclerview/widget/RecyclerView$SmoothScroller$ScrollVectorProvider", DoNotGenerateAcw = true)]
		internal class IScrollVectorProviderInvoker : Java.Lang.Object, IScrollVectorProvider, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$SmoothScroller$ScrollVectorProvider", typeof(IScrollVectorProviderInvoker));

			private IntPtr class_ref;

			private static Delegate cb_computeScrollVectorForPosition_I;

			private IntPtr id_computeScrollVectorForPosition_I;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IScrollVectorProvider GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IScrollVectorProvider>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.recyclerview.widget.RecyclerView.SmoothScroller.ScrollVectorProvider"));
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

			public IScrollVectorProviderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetComputeScrollVectorForPosition_IHandler()
			{
				if ((object)cb_computeScrollVectorForPosition_I == null)
				{
					cb_computeScrollVectorForPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_ComputeScrollVectorForPosition_I));
				}
				return cb_computeScrollVectorForPosition_I;
			}

			private static IntPtr n_ComputeScrollVectorForPosition_I(IntPtr jnienv, IntPtr native__this, int targetPosition)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IScrollVectorProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeScrollVectorForPosition(targetPosition));
			}

			public unsafe PointF ComputeScrollVectorForPosition(int targetPosition)
			{
				if (id_computeScrollVectorForPosition_I == IntPtr.Zero)
				{
					id_computeScrollVectorForPosition_I = JNIEnv.GetMethodID(class_ref, "computeScrollVectorForPosition", "(I)Landroid/graphics/PointF;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(targetPosition);
				return Java.Lang.Object.GetObject<PointF>(JNIEnv.CallObjectMethod(base.Handle, id_computeScrollVectorForPosition_I, ptr), JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$SmoothScroller", typeof(SmoothScroller));

		private static Delegate cb_getChildCount;

		private static Delegate cb_isPendingInitialRun;

		private static Delegate cb_isRunning;

		private static Delegate cb_getLayoutManager;

		private static Delegate cb_getTargetPosition;

		private static Delegate cb_setTargetPosition_I;

		private static Delegate cb_computeScrollVectorForPosition_I;

		private static Delegate cb_findViewByPosition_I;

		private static Delegate cb_getChildPosition_Landroid_view_View_;

		private static Delegate cb_instantScrollToPosition_I;

		private static Delegate cb_normalize_Landroid_graphics_PointF_;

		private static Delegate cb_onChildAttachedToWindow_Landroid_view_View_;

		private static Delegate cb_onSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_;

		private static Delegate cb_onStart;

		private static Delegate cb_onStop;

		private static Delegate cb_onTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int ChildCount
		{
			[Register("getChildCount", "()I", "GetGetChildCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getChildCount.()I", this, null);
			}
		}

		public unsafe virtual bool IsPendingInitialRun
		{
			[Register("isPendingInitialRun", "()Z", "GetIsPendingInitialRunHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPendingInitialRun.()Z", this, null);
			}
		}

		public unsafe virtual bool IsRunning
		{
			[Register("isRunning", "()Z", "GetIsRunningHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRunning.()Z", this, null);
			}
		}

		public unsafe virtual LayoutManager LayoutManager
		{
			[Register("getLayoutManager", "()Landroidx/recyclerview/widget/RecyclerView$LayoutManager;", "GetGetLayoutManagerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LayoutManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLayoutManager.()Landroidx/recyclerview/widget/RecyclerView$LayoutManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int TargetPosition
		{
			[Register("getTargetPosition", "()I", "GetGetTargetPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTargetPosition.()I", this, null);
			}
			[Register("setTargetPosition", "(I)V", "GetSetTargetPosition_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTargetPosition.(I)V", this, ptr);
			}
		}

		protected SmoothScroller(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SmoothScroller()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetChildCountHandler()
		{
			if ((object)cb_getChildCount == null)
			{
				cb_getChildCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetChildCount));
			}
			return cb_getChildCount;
		}

		private static int n_GetChildCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChildCount;
		}

		private static Delegate GetIsPendingInitialRunHandler()
		{
			if ((object)cb_isPendingInitialRun == null)
			{
				cb_isPendingInitialRun = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPendingInitialRun));
			}
			return cb_isPendingInitialRun;
		}

		private static bool n_IsPendingInitialRun(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPendingInitialRun;
		}

		private static Delegate GetIsRunningHandler()
		{
			if ((object)cb_isRunning == null)
			{
				cb_isRunning = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRunning));
			}
			return cb_isRunning;
		}

		private static bool n_IsRunning(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRunning;
		}

		private static Delegate GetGetLayoutManagerHandler()
		{
			if ((object)cb_getLayoutManager == null)
			{
				cb_getLayoutManager = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLayoutManager));
			}
			return cb_getLayoutManager;
		}

		private static IntPtr n_GetLayoutManager(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutManager);
		}

		private static Delegate GetGetTargetPositionHandler()
		{
			if ((object)cb_getTargetPosition == null)
			{
				cb_getTargetPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTargetPosition));
			}
			return cb_getTargetPosition;
		}

		private static int n_GetTargetPosition(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetPosition;
		}

		private static Delegate GetSetTargetPosition_IHandler()
		{
			if ((object)cb_setTargetPosition_I == null)
			{
				cb_setTargetPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetTargetPosition_I));
			}
			return cb_setTargetPosition_I;
		}

		private static void n_SetTargetPosition_I(IntPtr jnienv, IntPtr native__this, int targetPosition)
		{
			Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetPosition = targetPosition;
		}

		private static Delegate GetComputeScrollVectorForPosition_IHandler()
		{
			if ((object)cb_computeScrollVectorForPosition_I == null)
			{
				cb_computeScrollVectorForPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_ComputeScrollVectorForPosition_I));
			}
			return cb_computeScrollVectorForPosition_I;
		}

		private static IntPtr n_ComputeScrollVectorForPosition_I(IntPtr jnienv, IntPtr native__this, int targetPosition)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeScrollVectorForPosition(targetPosition));
		}

		[Register("computeScrollVectorForPosition", "(I)Landroid/graphics/PointF;", "GetComputeScrollVectorForPosition_IHandler")]
		public unsafe virtual PointF ComputeScrollVectorForPosition(int targetPosition)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(targetPosition);
			return Java.Lang.Object.GetObject<PointF>(_members.InstanceMethods.InvokeVirtualObjectMethod("computeScrollVectorForPosition.(I)Landroid/graphics/PointF;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetFindViewByPosition_IHandler()
		{
			if ((object)cb_findViewByPosition_I == null)
			{
				cb_findViewByPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_FindViewByPosition_I));
			}
			return cb_findViewByPosition_I;
		}

		private static IntPtr n_FindViewByPosition_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewByPosition(position));
		}

		[Register("findViewByPosition", "(I)Landroid/view/View;", "GetFindViewByPosition_IHandler")]
		public unsafe virtual View FindViewByPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewByPosition.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetChildPosition_Landroid_view_View_Handler()
		{
			if ((object)cb_getChildPosition_Landroid_view_View_ == null)
			{
				cb_getChildPosition_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetChildPosition_Landroid_view_View_));
			}
			return cb_getChildPosition_Landroid_view_View_;
		}

		private static int n_GetChildPosition_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			SmoothScroller smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return smoothScroller.GetChildPosition(view);
		}

		[Register("getChildPosition", "(Landroid/view/View;)I", "GetGetChildPosition_Landroid_view_View_Handler")]
		public unsafe virtual int GetChildPosition(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getChildPosition.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetInstantScrollToPosition_IHandler()
		{
			if ((object)cb_instantScrollToPosition_I == null)
			{
				cb_instantScrollToPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_InstantScrollToPosition_I));
			}
			return cb_instantScrollToPosition_I;
		}

		private static void n_InstantScrollToPosition_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InstantScrollToPosition(position);
		}

		[Register("instantScrollToPosition", "(I)V", "GetInstantScrollToPosition_IHandler")]
		public unsafe virtual void InstantScrollToPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("instantScrollToPosition.(I)V", this, ptr);
		}

		private static Delegate GetNormalize_Landroid_graphics_PointF_Handler()
		{
			if ((object)cb_normalize_Landroid_graphics_PointF_ == null)
			{
				cb_normalize_Landroid_graphics_PointF_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Normalize_Landroid_graphics_PointF_));
			}
			return cb_normalize_Landroid_graphics_PointF_;
		}

		private static void n_Normalize_Landroid_graphics_PointF_(IntPtr jnienv, IntPtr native__this, IntPtr native_scrollVector)
		{
			SmoothScroller smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PointF scrollVector = Java.Lang.Object.GetObject<PointF>(native_scrollVector, JniHandleOwnership.DoNotTransfer);
			smoothScroller.Normalize(scrollVector);
		}

		[Register("normalize", "(Landroid/graphics/PointF;)V", "GetNormalize_Landroid_graphics_PointF_Handler")]
		protected unsafe virtual void Normalize(PointF scrollVector)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(scrollVector?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("normalize.(Landroid/graphics/PointF;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(scrollVector);
			}
		}

		private static Delegate GetOnChildAttachedToWindow_Landroid_view_View_Handler()
		{
			if ((object)cb_onChildAttachedToWindow_Landroid_view_View_ == null)
			{
				cb_onChildAttachedToWindow_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnChildAttachedToWindow_Landroid_view_View_));
			}
			return cb_onChildAttachedToWindow_Landroid_view_View_;
		}

		private static void n_OnChildAttachedToWindow_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			SmoothScroller smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			smoothScroller.OnChildAttachedToWindow(child);
		}

		[Register("onChildAttachedToWindow", "(Landroid/view/View;)V", "GetOnChildAttachedToWindow_Landroid_view_View_Handler")]
		protected unsafe virtual void OnChildAttachedToWindow(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onChildAttachedToWindow.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetOnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler()
		{
			if ((object)cb_onSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_ == null)
			{
				cb_onSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIILL_V(n_OnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_));
			}
			return cb_onSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_;
		}

		private static void n_OnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_(IntPtr jnienv, IntPtr native__this, int p0, int p1, IntPtr native_p2, IntPtr native_p3)
		{
			SmoothScroller smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State p2 = Java.Lang.Object.GetObject<State>(native_p2, JniHandleOwnership.DoNotTransfer);
			Action p3 = Java.Lang.Object.GetObject<Action>(native_p3, JniHandleOwnership.DoNotTransfer);
			smoothScroller.OnSeekTargetStep(p0, p1, p2, p3);
		}

		[Register("onSeekTargetStep", "(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetOnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
		protected abstract void OnSeekTargetStep(int p0, int p1, State p2, Action p3);

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
			Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
		}

		[Register("onStart", "()V", "GetOnStartHandler")]
		protected abstract void OnStart();

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
			Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
		}

		[Register("onStop", "()V", "GetOnStopHandler")]
		protected abstract void OnStop();

		private static Delegate GetOnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler()
		{
			if ((object)cb_onTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_ == null)
			{
				cb_onTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_));
			}
			return cb_onTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_;
		}

		private static void n_OnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			SmoothScroller smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View p = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
			State p2 = Java.Lang.Object.GetObject<State>(native_p1, JniHandleOwnership.DoNotTransfer);
			Action p3 = Java.Lang.Object.GetObject<Action>(native_p2, JniHandleOwnership.DoNotTransfer);
			smoothScroller.OnTargetFound(p, p2, p3);
		}

		[Register("onTargetFound", "(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetOnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
		protected abstract void OnTargetFound(View p0, State p1, Action p2);

		[Register("stop", "()V", "")]
		protected unsafe void Stop()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("stop.()V", this, null);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$SmoothScroller", DoNotGenerateAcw = true)]
	internal class SmoothScrollerInvoker : SmoothScroller
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$SmoothScroller", typeof(SmoothScrollerInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public SmoothScrollerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onSeekTargetStep", "(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetOnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
		protected unsafe override void OnSeekTargetStep(int p0, int p1, State p2, Action p3)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onSeekTargetStep.(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
			}
		}

		[Register("onStart", "()V", "GetOnStartHandler")]
		protected unsafe override void OnStart()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("onStart.()V", this, null);
		}

		[Register("onStop", "()V", "GetOnStopHandler")]
		protected unsafe override void OnStop()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("onStop.()V", this, null);
		}

		[Register("onTargetFound", "(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetOnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
		protected unsafe override void OnTargetFound(View p0, State p1, Action p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onTargetFound.(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$State", DoNotGenerateAcw = true)]
	public class State : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$State", typeof(State));

		private static Delegate cb_hasTargetScrollPosition;

		private static Delegate cb_isMeasuring;

		private static Delegate cb_isPreLayout;

		private static Delegate cb_getItemCount;

		private static Delegate cb_getRemainingScrollHorizontal;

		private static Delegate cb_getRemainingScrollVertical;

		private static Delegate cb_getTargetScrollPosition;

		private static Delegate cb_didStructureChange;

		private static Delegate cb_get_I;

		private static Delegate cb_put_ILjava_lang_Object_;

		private static Delegate cb_remove_I;

		private static Delegate cb_willRunPredictiveAnimations;

		private static Delegate cb_willRunSimpleAnimations;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool HasTargetScrollPosition
		{
			[Register("hasTargetScrollPosition", "()Z", "GetHasTargetScrollPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasTargetScrollPosition.()Z", this, null);
			}
		}

		public unsafe virtual bool IsMeasuring
		{
			[Register("isMeasuring", "()Z", "GetIsMeasuringHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMeasuring.()Z", this, null);
			}
		}

		public unsafe virtual bool IsPreLayout
		{
			[Register("isPreLayout", "()Z", "GetIsPreLayoutHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPreLayout.()Z", this, null);
			}
		}

		public unsafe virtual int ItemCount
		{
			[Register("getItemCount", "()I", "GetGetItemCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getItemCount.()I", this, null);
			}
		}

		public unsafe virtual int RemainingScrollHorizontal
		{
			[Register("getRemainingScrollHorizontal", "()I", "GetGetRemainingScrollHorizontalHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRemainingScrollHorizontal.()I", this, null);
			}
		}

		public unsafe virtual int RemainingScrollVertical
		{
			[Register("getRemainingScrollVertical", "()I", "GetGetRemainingScrollVerticalHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRemainingScrollVertical.()I", this, null);
			}
		}

		public unsafe virtual int TargetScrollPosition
		{
			[Register("getTargetScrollPosition", "()I", "GetGetTargetScrollPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTargetScrollPosition.()I", this, null);
			}
		}

		protected State(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe State()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetHasTargetScrollPositionHandler()
		{
			if ((object)cb_hasTargetScrollPosition == null)
			{
				cb_hasTargetScrollPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasTargetScrollPosition));
			}
			return cb_hasTargetScrollPosition;
		}

		private static bool n_HasTargetScrollPosition(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasTargetScrollPosition;
		}

		private static Delegate GetIsMeasuringHandler()
		{
			if ((object)cb_isMeasuring == null)
			{
				cb_isMeasuring = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsMeasuring));
			}
			return cb_isMeasuring;
		}

		private static bool n_IsMeasuring(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsMeasuring;
		}

		private static Delegate GetIsPreLayoutHandler()
		{
			if ((object)cb_isPreLayout == null)
			{
				cb_isPreLayout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPreLayout));
			}
			return cb_isPreLayout;
		}

		private static bool n_IsPreLayout(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPreLayout;
		}

		private static Delegate GetGetItemCountHandler()
		{
			if ((object)cb_getItemCount == null)
			{
				cb_getItemCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetItemCount));
			}
			return cb_getItemCount;
		}

		private static int n_GetItemCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemCount;
		}

		private static Delegate GetGetRemainingScrollHorizontalHandler()
		{
			if ((object)cb_getRemainingScrollHorizontal == null)
			{
				cb_getRemainingScrollHorizontal = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRemainingScrollHorizontal));
			}
			return cb_getRemainingScrollHorizontal;
		}

		private static int n_GetRemainingScrollHorizontal(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemainingScrollHorizontal;
		}

		private static Delegate GetGetRemainingScrollVerticalHandler()
		{
			if ((object)cb_getRemainingScrollVertical == null)
			{
				cb_getRemainingScrollVertical = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRemainingScrollVertical));
			}
			return cb_getRemainingScrollVertical;
		}

		private static int n_GetRemainingScrollVertical(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemainingScrollVertical;
		}

		private static Delegate GetGetTargetScrollPositionHandler()
		{
			if ((object)cb_getTargetScrollPosition == null)
			{
				cb_getTargetScrollPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTargetScrollPosition));
			}
			return cb_getTargetScrollPosition;
		}

		private static int n_GetTargetScrollPosition(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetScrollPosition;
		}

		private static Delegate GetDidStructureChangeHandler()
		{
			if ((object)cb_didStructureChange == null)
			{
				cb_didStructureChange = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_DidStructureChange));
			}
			return cb_didStructureChange;
		}

		private static bool n_DidStructureChange(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DidStructureChange();
		}

		[Register("didStructureChange", "()Z", "GetDidStructureChangeHandler")]
		public unsafe virtual bool DidStructureChange()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("didStructureChange.()Z", this, null);
		}

		private static Delegate GetGet_IHandler()
		{
			if ((object)cb_get_I == null)
			{
				cb_get_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_Get_I));
			}
			return cb_get_I;
		}

		private static IntPtr n_Get_I(IntPtr jnienv, IntPtr native__this, int resourceId)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get(resourceId));
		}

		[Register("get", "(I)Ljava/lang/Object;", "GetGet_IHandler")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe virtual Java.Lang.Object Get(int resourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resourceId);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPut_ILjava_lang_Object_Handler()
		{
			if ((object)cb_put_ILjava_lang_Object_ == null)
			{
				cb_put_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_Put_ILjava_lang_Object_));
			}
			return cb_put_ILjava_lang_Object_;
		}

		private static void n_Put_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int resourceId, IntPtr native_data)
		{
			State state = Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object data = Java.Lang.Object.GetObject<Java.Lang.Object>(native_data, JniHandleOwnership.DoNotTransfer);
			state.Put(resourceId, data);
		}

		[Register("put", "(ILjava/lang/Object;)V", "GetPut_ILjava_lang_Object_Handler")]
		public unsafe virtual void Put(int resourceId, Java.Lang.Object data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(resourceId);
				ptr[1] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("put.(ILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetRemove_IHandler()
		{
			if ((object)cb_remove_I == null)
			{
				cb_remove_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_Remove_I));
			}
			return cb_remove_I;
		}

		private static void n_Remove_I(IntPtr jnienv, IntPtr native__this, int resourceId)
		{
			Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove(resourceId);
		}

		[Register("remove", "(I)V", "GetRemove_IHandler")]
		public unsafe virtual void Remove(int resourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resourceId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("remove.(I)V", this, ptr);
		}

		private static Delegate GetWillRunPredictiveAnimationsHandler()
		{
			if ((object)cb_willRunPredictiveAnimations == null)
			{
				cb_willRunPredictiveAnimations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_WillRunPredictiveAnimations));
			}
			return cb_willRunPredictiveAnimations;
		}

		private static bool n_WillRunPredictiveAnimations(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WillRunPredictiveAnimations();
		}

		[Register("willRunPredictiveAnimations", "()Z", "GetWillRunPredictiveAnimationsHandler")]
		public unsafe virtual bool WillRunPredictiveAnimations()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("willRunPredictiveAnimations.()Z", this, null);
		}

		private static Delegate GetWillRunSimpleAnimationsHandler()
		{
			if ((object)cb_willRunSimpleAnimations == null)
			{
				cb_willRunSimpleAnimations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_WillRunSimpleAnimations));
			}
			return cb_willRunSimpleAnimations;
		}

		private static bool n_WillRunSimpleAnimations(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WillRunSimpleAnimations();
		}

		[Register("willRunSimpleAnimations", "()Z", "GetWillRunSimpleAnimationsHandler")]
		public unsafe virtual bool WillRunSimpleAnimations()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("willRunSimpleAnimations.()Z", this, null);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ViewCacheExtension", DoNotGenerateAcw = true)]
	public abstract class ViewCacheExtension : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ViewCacheExtension", typeof(ViewCacheExtension));

		private static Delegate cb_getViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_II;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ViewCacheExtension(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ViewCacheExtension()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_IIHandler()
		{
			if ((object)cb_getViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_II == null)
			{
				cb_getViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_GetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_II));
			}
			return cb_getViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_II;
		}

		private static IntPtr n_GetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_II(IntPtr jnienv, IntPtr native__this, IntPtr native_recycler, int position, int type)
		{
			ViewCacheExtension viewCacheExtension = Java.Lang.Object.GetObject<ViewCacheExtension>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewCacheExtension.GetViewForPositionAndType(recycler, position, type));
		}

		[Register("getViewForPositionAndType", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;II)Landroid/view/View;", "GetGetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_IIHandler")]
		public abstract View GetViewForPositionAndType(Recycler recycler, int position, int type);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ViewCacheExtension", DoNotGenerateAcw = true)]
	internal class ViewCacheExtensionInvoker : ViewCacheExtension
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ViewCacheExtension", typeof(ViewCacheExtensionInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public ViewCacheExtensionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getViewForPositionAndType", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;II)Landroid/view/View;", "GetGetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_IIHandler")]
		public unsafe override View GetViewForPositionAndType(Recycler recycler, int position, int type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(type);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeAbstractObjectMethod("getViewForPositionAndType.(Landroidx/recyclerview/widget/RecyclerView$Recycler;II)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(recycler);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ViewHolder", DoNotGenerateAcw = true)]
	public abstract class ViewHolder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ViewHolder", typeof(ViewHolder));

		[Register("itemView")]
		public View ItemView
		{
			get
			{
				return Java.Lang.Object.GetObject<View>(_members.InstanceFields.GetObjectValue("itemView.Landroid/view/View;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("itemView.Landroid/view/View;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int AdapterPosition
		{
			[Register("getAdapterPosition", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getAdapterPosition.()I", this, null);
			}
		}

		public unsafe bool IsRecyclable
		{
			[Register("isRecyclable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isRecyclable.()Z", this, null);
			}
			[Register("setIsRecyclable", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setIsRecyclable.(Z)V", this, ptr);
			}
		}

		public unsafe long ItemId
		{
			[Register("getItemId", "()J", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt64Method("getItemId.()J", this, null);
			}
		}

		public unsafe int ItemViewType
		{
			[Register("getItemViewType", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getItemViewType.()I", this, null);
			}
		}

		public unsafe int LayoutPosition
		{
			[Register("getLayoutPosition", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getLayoutPosition.()I", this, null);
			}
		}

		public unsafe int OldPosition
		{
			[Register("getOldPosition", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getOldPosition.()I", this, null);
			}
		}

		public unsafe int Position
		{
			[Register("getPosition", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getPosition.()I", this, null);
			}
		}

		protected ViewHolder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/view/View;)V", "")]
		public unsafe ViewHolder(View itemView)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(itemView?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/View;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(itemView);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ViewHolder", DoNotGenerateAcw = true)]
	internal class ViewHolderInvoker : ViewHolder
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ViewHolder", typeof(ViewHolderInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public ViewHolderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView", typeof(RecyclerView));

	private static Delegate cb_getCompatAccessibilityDelegate;

	private static Delegate cb_hasFixedSize;

	private static Delegate cb_setHasFixedSize_Z;

	private static Delegate cb_hasPendingAdapterUpdates;

	private static Delegate cb_isAnimating;

	private static Delegate cb_isComputingLayout;

	private static Delegate cb_getItemDecorationCount;

	private static Delegate cb_isLayoutFrozen;

	private static Delegate cb_setLayoutFrozen_Z;

	private static Delegate cb_getMaxFlingVelocity;

	private static Delegate cb_getMinFlingVelocity;

	private static Delegate cb_getPreserveFocusAfterLayout;

	private static Delegate cb_setPreserveFocusAfterLayout_Z;

	private static Delegate cb_getScrollState;

	private static Delegate cb_addFocusables_Ljava_util_ArrayList_II;

	private static Delegate cb_addItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_;

	private static Delegate cb_addItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_I;

	private static Delegate cb_addOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_;

	private static Delegate cb_addOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_;

	private static Delegate cb_addOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_;

	private static Delegate cb_clearOnChildAttachStateChangeListeners;

	private static Delegate cb_clearOnScrollListeners;

	private static Delegate cb_computeHorizontalScrollExtent;

	private static Delegate cb_computeHorizontalScrollOffset;

	private static Delegate cb_computeHorizontalScrollRange;

	private static Delegate cb_computeVerticalScrollExtent;

	private static Delegate cb_computeVerticalScrollOffset;

	private static Delegate cb_computeVerticalScrollRange;

	private static Delegate cb_dispatchNestedPreScroll_IIarrayIarrayII;

	private static Delegate cb_dispatchNestedScroll_IIIIarrayII;

	private static Delegate cb_dispatchRestoreInstanceState_Landroid_util_SparseArray_;

	private static Delegate cb_dispatchSaveInstanceState_Landroid_util_SparseArray_;

	private static Delegate cb_drawChild_Landroid_graphics_Canvas_Landroid_view_View_J;

	private static Delegate cb_findChildViewUnder_FF;

	private static Delegate cb_findContainingItemView_Landroid_view_View_;

	private static Delegate cb_findContainingViewHolder_Landroid_view_View_;

	private static Delegate cb_findViewHolderForAdapterPosition_I;

	private static Delegate cb_findViewHolderForItemId_J;

	private static Delegate cb_findViewHolderForLayoutPosition_I;

	private static Delegate cb_findViewHolderForPosition_I;

	private static Delegate cb_fling_II;

	private static Delegate cb_getAdapter;

	private static Delegate cb_getChildAdapterPosition_Landroid_view_View_;

	private static Delegate cb_getChildItemId_Landroid_view_View_;

	private static Delegate cb_getChildLayoutPosition_Landroid_view_View_;

	private static Delegate cb_getChildPosition_Landroid_view_View_;

	private static Delegate cb_getChildViewHolder_Landroid_view_View_;

	private static Delegate cb_getDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_;

	private static Delegate cb_getEdgeEffectFactory;

	private static Delegate cb_getItemAnimator;

	private static Delegate cb_getItemDecorationAt_I;

	private static Delegate cb_getLayoutManager;

	private static Delegate cb_getOnFlingListener;

	private static Delegate cb_getRecycledViewPool;

	private static Delegate cb_hasNestedScrollingParent_I;

	private static Delegate cb_invalidateItemDecorations;

	private static Delegate cb_offsetChildrenHorizontal_I;

	private static Delegate cb_offsetChildrenVertical_I;

	private static Delegate cb_onChildAttachedToWindow_Landroid_view_View_;

	private static Delegate cb_onChildDetachedFromWindow_Landroid_view_View_;

	private static Delegate cb_onDraw_Landroid_graphics_Canvas_;

	private static Delegate cb_onLayout_ZIIII;

	private static Delegate cb_onScrollStateChanged_I;

	private static Delegate cb_onScrolled_II;

	private static Delegate cb_removeItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_;

	private static Delegate cb_removeItemDecorationAt_I;

	private static Delegate cb_removeOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_;

	private static Delegate cb_removeOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_;

	private static Delegate cb_removeOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_;

	private static Delegate cb_scrollToPosition_I;

	private static Delegate cb_setAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_;

	private static Delegate cb_setAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_;

	private static Delegate cb_setChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_;

	private static Delegate cb_setEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_;

	private static Delegate cb_setItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_;

	private static Delegate cb_setItemViewCacheSize_I;

	private static Delegate cb_setLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_;

	private static Delegate cb_setOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_;

	private static Delegate cb_setOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_;

	private static Delegate cb_setRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_;

	private static Delegate cb_setRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_;

	private static Delegate cb_setScrollingTouchSlop_I;

	private static Delegate cb_setViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_;

	private static Delegate cb_smoothScrollBy_II;

	private static Delegate cb_smoothScrollBy_IILandroid_view_animation_Interpolator_;

	private static Delegate cb_smoothScrollBy_IILandroid_view_animation_Interpolator_I;

	private static Delegate cb_smoothScrollToPosition_I;

	private static Delegate cb_startNestedScroll_II;

	private static Delegate cb_stopNestedScroll_I;

	private static Delegate cb_stopScroll;

	private static Delegate cb_swapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Z;

	private WeakReference weak_implementor_AddOnChildAttachStateChangeListener;

	private WeakReference weak_implementor_AddOnItemTouchListener;

	private WeakReference weak_implementor_SetRecyclerListener;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual RecyclerViewAccessibilityDelegate CompatAccessibilityDelegate
	{
		[Register("getCompatAccessibilityDelegate", "()Landroidx/recyclerview/widget/RecyclerViewAccessibilityDelegate;", "GetGetCompatAccessibilityDelegateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<RecyclerViewAccessibilityDelegate>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCompatAccessibilityDelegate.()Landroidx/recyclerview/widget/RecyclerViewAccessibilityDelegate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool HasFixedSize
	{
		[Register("hasFixedSize", "()Z", "GetHasFixedSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasFixedSize.()Z", this, null);
		}
		[Register("setHasFixedSize", "(Z)V", "GetSetHasFixedSize_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHasFixedSize.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool HasPendingAdapterUpdates
	{
		[Register("hasPendingAdapterUpdates", "()Z", "GetHasPendingAdapterUpdatesHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasPendingAdapterUpdates.()Z", this, null);
		}
	}

	public unsafe virtual bool IsAnimating
	{
		[Register("isAnimating", "()Z", "GetIsAnimatingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAnimating.()Z", this, null);
		}
	}

	public unsafe virtual bool IsComputingLayout
	{
		[Register("isComputingLayout", "()Z", "GetIsComputingLayoutHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isComputingLayout.()Z", this, null);
		}
	}

	public unsafe bool IsLayoutSuppressed
	{
		[Register("isLayoutSuppressed", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isLayoutSuppressed.()Z", this, null);
		}
	}

	public unsafe virtual int ItemDecorationCount
	{
		[Register("getItemDecorationCount", "()I", "GetGetItemDecorationCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemDecorationCount.()I", this, null);
		}
	}

	public unsafe virtual bool LayoutFrozen
	{
		[Register("isLayoutFrozen", "()Z", "GetIsLayoutFrozenHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLayoutFrozen.()Z", this, null);
		}
		[Register("setLayoutFrozen", "(Z)V", "GetSetLayoutFrozen_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLayoutFrozen.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int MaxFlingVelocity
	{
		[Register("getMaxFlingVelocity", "()I", "GetGetMaxFlingVelocityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxFlingVelocity.()I", this, null);
		}
	}

	public unsafe virtual int MinFlingVelocity
	{
		[Register("getMinFlingVelocity", "()I", "GetGetMinFlingVelocityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMinFlingVelocity.()I", this, null);
		}
	}

	public unsafe virtual bool PreserveFocusAfterLayout
	{
		[Register("getPreserveFocusAfterLayout", "()Z", "GetGetPreserveFocusAfterLayoutHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getPreserveFocusAfterLayout.()Z", this, null);
		}
		[Register("setPreserveFocusAfterLayout", "(Z)V", "GetSetPreserveFocusAfterLayout_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPreserveFocusAfterLayout.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int ScrollState
	{
		[Register("getScrollState", "()I", "GetGetScrollStateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getScrollState.()I", this, null);
		}
	}

	public event EventHandler<ChildViewAttachedToWindowEventArgs> ChildViewAttachedToWindow
	{
		add
		{
			EventHelper.AddEventHandler<IOnChildAttachStateChangeListener, IOnChildAttachStateChangeListenerImplementor>(ref weak_implementor_AddOnChildAttachStateChangeListener, __CreateIOnChildAttachStateChangeListenerImplementor, AddOnChildAttachStateChangeListener, delegate(IOnChildAttachStateChangeListenerImplementor __h)
			{
				__h.OnChildViewAttachedToWindowHandler = (EventHandler<ChildViewAttachedToWindowEventArgs>)Delegate.Combine(__h.OnChildViewAttachedToWindowHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnChildAttachStateChangeListener, IOnChildAttachStateChangeListenerImplementor.__IsEmpty, delegate(IOnChildAttachStateChangeListener __v)
			{
				RemoveOnChildAttachStateChangeListener(__v);
			}, delegate(IOnChildAttachStateChangeListenerImplementor __h)
			{
				__h.OnChildViewAttachedToWindowHandler = (EventHandler<ChildViewAttachedToWindowEventArgs>)Delegate.Remove(__h.OnChildViewAttachedToWindowHandler, value);
			});
		}
	}

	public event EventHandler<ChildViewDetachedFromWindowEventArgs> ChildViewDetachedFromWindow
	{
		add
		{
			EventHelper.AddEventHandler<IOnChildAttachStateChangeListener, IOnChildAttachStateChangeListenerImplementor>(ref weak_implementor_AddOnChildAttachStateChangeListener, __CreateIOnChildAttachStateChangeListenerImplementor, AddOnChildAttachStateChangeListener, delegate(IOnChildAttachStateChangeListenerImplementor __h)
			{
				__h.OnChildViewDetachedFromWindowHandler = (EventHandler<ChildViewDetachedFromWindowEventArgs>)Delegate.Combine(__h.OnChildViewDetachedFromWindowHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnChildAttachStateChangeListener, IOnChildAttachStateChangeListenerImplementor.__IsEmpty, delegate(IOnChildAttachStateChangeListener __v)
			{
				RemoveOnChildAttachStateChangeListener(__v);
			}, delegate(IOnChildAttachStateChangeListenerImplementor __h)
			{
				__h.OnChildViewDetachedFromWindowHandler = (EventHandler<ChildViewDetachedFromWindowEventArgs>)Delegate.Remove(__h.OnChildViewDetachedFromWindowHandler, value);
			});
		}
	}

	public event EventHandler<InterceptTouchEventEventArgs> InterceptTouchEvent
	{
		add
		{
			EventHelper.AddEventHandler<IOnItemTouchListener, IOnItemTouchListenerImplementor>(ref weak_implementor_AddOnItemTouchListener, __CreateIOnItemTouchListenerImplementor, AddOnItemTouchListener, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnInterceptTouchEventHandler = (EventHandler<InterceptTouchEventEventArgs>)Delegate.Combine(__h.OnInterceptTouchEventHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnItemTouchListener, IOnItemTouchListenerImplementor.__IsEmpty, delegate(IOnItemTouchListener __v)
			{
				RemoveOnItemTouchListener(__v);
			}, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnInterceptTouchEventHandler = (EventHandler<InterceptTouchEventEventArgs>)Delegate.Remove(__h.OnInterceptTouchEventHandler, value);
			});
		}
	}

	public new event EventHandler<RequestDisallowInterceptTouchEventEventArgs> RequestDisallowInterceptTouchEvent
	{
		add
		{
			EventHelper.AddEventHandler<IOnItemTouchListener, IOnItemTouchListenerImplementor>(ref weak_implementor_AddOnItemTouchListener, __CreateIOnItemTouchListenerImplementor, AddOnItemTouchListener, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnRequestDisallowInterceptTouchEventHandler = (EventHandler<RequestDisallowInterceptTouchEventEventArgs>)Delegate.Combine(__h.OnRequestDisallowInterceptTouchEventHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnItemTouchListener, IOnItemTouchListenerImplementor.__IsEmpty, delegate(IOnItemTouchListener __v)
			{
				RemoveOnItemTouchListener(__v);
			}, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnRequestDisallowInterceptTouchEventHandler = (EventHandler<RequestDisallowInterceptTouchEventEventArgs>)Delegate.Remove(__h.OnRequestDisallowInterceptTouchEventHandler, value);
			});
		}
	}

	public event EventHandler<TouchEventEventArgs> TouchEvent
	{
		add
		{
			EventHelper.AddEventHandler<IOnItemTouchListener, IOnItemTouchListenerImplementor>(ref weak_implementor_AddOnItemTouchListener, __CreateIOnItemTouchListenerImplementor, AddOnItemTouchListener, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnTouchEventHandler = (EventHandler<TouchEventEventArgs>)Delegate.Combine(__h.OnTouchEventHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnItemTouchListener, IOnItemTouchListenerImplementor.__IsEmpty, delegate(IOnItemTouchListener __v)
			{
				RemoveOnItemTouchListener(__v);
			}, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnTouchEventHandler = (EventHandler<TouchEventEventArgs>)Delegate.Remove(__h.OnTouchEventHandler, value);
			});
		}
	}

	public event EventHandler<RecyclerEventArgs> RecyclerEvent
	{
		add
		{
			EventHelper.AddEventHandler<IRecyclerListener, IRecyclerListenerImplementor>(ref weak_implementor_SetRecyclerListener, __CreateIRecyclerListenerImplementor, SetRecyclerListener, delegate(IRecyclerListenerImplementor __h)
			{
				__h.Handler = (EventHandler<RecyclerEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IRecyclerListener, IRecyclerListenerImplementor>(ref weak_implementor_SetRecyclerListener, IRecyclerListenerImplementor.__IsEmpty, delegate
			{
				SetRecyclerListener(null);
			}, delegate(IRecyclerListenerImplementor __h)
			{
				__h.Handler = (EventHandler<RecyclerEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected RecyclerView(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe RecyclerView(Context context)
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
	public unsafe RecyclerView(Context context, IAttributeSet attrs)
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
	public unsafe RecyclerView(Context context, IAttributeSet attrs, int defStyleAttr)
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

	private static Delegate GetGetCompatAccessibilityDelegateHandler()
	{
		if ((object)cb_getCompatAccessibilityDelegate == null)
		{
			cb_getCompatAccessibilityDelegate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCompatAccessibilityDelegate));
		}
		return cb_getCompatAccessibilityDelegate;
	}

	private static IntPtr n_GetCompatAccessibilityDelegate(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatAccessibilityDelegate);
	}

	private static Delegate GetHasFixedSizeHandler()
	{
		if ((object)cb_hasFixedSize == null)
		{
			cb_hasFixedSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasFixedSize));
		}
		return cb_hasFixedSize;
	}

	private static bool n_HasFixedSize(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFixedSize;
	}

	private static Delegate GetSetHasFixedSize_ZHandler()
	{
		if ((object)cb_setHasFixedSize_Z == null)
		{
			cb_setHasFixedSize_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetHasFixedSize_Z));
		}
		return cb_setHasFixedSize_Z;
	}

	private static void n_SetHasFixedSize_Z(IntPtr jnienv, IntPtr native__this, bool hasFixedSize)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFixedSize = hasFixedSize;
	}

	private static Delegate GetHasPendingAdapterUpdatesHandler()
	{
		if ((object)cb_hasPendingAdapterUpdates == null)
		{
			cb_hasPendingAdapterUpdates = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasPendingAdapterUpdates));
		}
		return cb_hasPendingAdapterUpdates;
	}

	private static bool n_HasPendingAdapterUpdates(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasPendingAdapterUpdates;
	}

	private static Delegate GetIsAnimatingHandler()
	{
		if ((object)cb_isAnimating == null)
		{
			cb_isAnimating = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAnimating));
		}
		return cb_isAnimating;
	}

	private static bool n_IsAnimating(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAnimating;
	}

	private static Delegate GetIsComputingLayoutHandler()
	{
		if ((object)cb_isComputingLayout == null)
		{
			cb_isComputingLayout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsComputingLayout));
		}
		return cb_isComputingLayout;
	}

	private static bool n_IsComputingLayout(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsComputingLayout;
	}

	private static Delegate GetGetItemDecorationCountHandler()
	{
		if ((object)cb_getItemDecorationCount == null)
		{
			cb_getItemDecorationCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetItemDecorationCount));
		}
		return cb_getItemDecorationCount;
	}

	private static int n_GetItemDecorationCount(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemDecorationCount;
	}

	private static Delegate GetIsLayoutFrozenHandler()
	{
		if ((object)cb_isLayoutFrozen == null)
		{
			cb_isLayoutFrozen = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsLayoutFrozen));
		}
		return cb_isLayoutFrozen;
	}

	private static bool n_IsLayoutFrozen(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutFrozen;
	}

	private static Delegate GetSetLayoutFrozen_ZHandler()
	{
		if ((object)cb_setLayoutFrozen_Z == null)
		{
			cb_setLayoutFrozen_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetLayoutFrozen_Z));
		}
		return cb_setLayoutFrozen_Z;
	}

	private static void n_SetLayoutFrozen_Z(IntPtr jnienv, IntPtr native__this, bool frozen)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutFrozen = frozen;
	}

	private static Delegate GetGetMaxFlingVelocityHandler()
	{
		if ((object)cb_getMaxFlingVelocity == null)
		{
			cb_getMaxFlingVelocity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMaxFlingVelocity));
		}
		return cb_getMaxFlingVelocity;
	}

	private static int n_GetMaxFlingVelocity(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxFlingVelocity;
	}

	private static Delegate GetGetMinFlingVelocityHandler()
	{
		if ((object)cb_getMinFlingVelocity == null)
		{
			cb_getMinFlingVelocity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMinFlingVelocity));
		}
		return cb_getMinFlingVelocity;
	}

	private static int n_GetMinFlingVelocity(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinFlingVelocity;
	}

	private static Delegate GetGetPreserveFocusAfterLayoutHandler()
	{
		if ((object)cb_getPreserveFocusAfterLayout == null)
		{
			cb_getPreserveFocusAfterLayout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetPreserveFocusAfterLayout));
		}
		return cb_getPreserveFocusAfterLayout;
	}

	private static bool n_GetPreserveFocusAfterLayout(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreserveFocusAfterLayout;
	}

	private static Delegate GetSetPreserveFocusAfterLayout_ZHandler()
	{
		if ((object)cb_setPreserveFocusAfterLayout_Z == null)
		{
			cb_setPreserveFocusAfterLayout_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetPreserveFocusAfterLayout_Z));
		}
		return cb_setPreserveFocusAfterLayout_Z;
	}

	private static void n_SetPreserveFocusAfterLayout_Z(IntPtr jnienv, IntPtr native__this, bool preserveFocusAfterLayout)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreserveFocusAfterLayout = preserveFocusAfterLayout;
	}

	private static Delegate GetGetScrollStateHandler()
	{
		if ((object)cb_getScrollState == null)
		{
			cb_getScrollState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetScrollState));
		}
		return cb_getScrollState;
	}

	private static int n_GetScrollState(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollState;
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
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
		recyclerView.AddFocusables(views, direction, focusableMode);
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

	private static Delegate GetAddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_Handler()
	{
		if ((object)cb_addItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_ == null)
		{
			cb_addItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_));
		}
		return cb_addItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_;
	}

	private static void n_AddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_(IntPtr jnienv, IntPtr native__this, IntPtr native_decor)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ItemDecoration decor = Java.Lang.Object.GetObject<ItemDecoration>(native_decor, JniHandleOwnership.DoNotTransfer);
		recyclerView.AddItemDecoration(decor);
	}

	[Register("addItemDecoration", "(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", "GetAddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_Handler")]
	public unsafe virtual void AddItemDecoration(ItemDecoration decor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(decor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addItemDecoration.(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(decor);
		}
	}

	private static Delegate GetAddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_IHandler()
	{
		if ((object)cb_addItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_I == null)
		{
			cb_addItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_AddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_I));
		}
		return cb_addItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_I;
	}

	private static void n_AddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_I(IntPtr jnienv, IntPtr native__this, IntPtr native_decor, int index)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ItemDecoration decor = Java.Lang.Object.GetObject<ItemDecoration>(native_decor, JniHandleOwnership.DoNotTransfer);
		recyclerView.AddItemDecoration(decor, index);
	}

	[Register("addItemDecoration", "(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;I)V", "GetAddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_IHandler")]
	public unsafe virtual void AddItemDecoration(ItemDecoration decor, int index)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(decor?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(index);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addItemDecoration.(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(decor);
		}
	}

	private static Delegate GetAddOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_Handler()
	{
		if ((object)cb_addOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_ == null)
		{
			cb_addOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_));
		}
		return cb_addOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_;
	}

	private static void n_AddOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnChildAttachStateChangeListener listener = Java.Lang.Object.GetObject<IOnChildAttachStateChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		recyclerView.AddOnChildAttachStateChangeListener(listener);
	}

	[Register("addOnChildAttachStateChangeListener", "(Landroidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener;)V", "GetAddOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_Handler")]
	public unsafe virtual void AddOnChildAttachStateChangeListener(IOnChildAttachStateChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnChildAttachStateChangeListener.(Landroidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_Handler()
	{
		if ((object)cb_addOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_ == null)
		{
			cb_addOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_));
		}
		return cb_addOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_;
	}

	private static void n_AddOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnItemTouchListener listener = Java.Lang.Object.GetObject<IOnItemTouchListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		recyclerView.AddOnItemTouchListener(listener);
	}

	[Register("addOnItemTouchListener", "(Landroidx/recyclerview/widget/RecyclerView$OnItemTouchListener;)V", "GetAddOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_Handler")]
	public unsafe virtual void AddOnItemTouchListener(IOnItemTouchListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnItemTouchListener.(Landroidx/recyclerview/widget/RecyclerView$OnItemTouchListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler()
	{
		if ((object)cb_addOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_ == null)
		{
			cb_addOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_));
		}
		return cb_addOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_;
	}

	private static void n_AddOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		OnScrollListener listener = Java.Lang.Object.GetObject<OnScrollListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		recyclerView.AddOnScrollListener(listener);
	}

	[Register("addOnScrollListener", "(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", "GetAddOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler")]
	public unsafe virtual void AddOnScrollListener(OnScrollListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnScrollListener.(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetClearOnChildAttachStateChangeListenersHandler()
	{
		if ((object)cb_clearOnChildAttachStateChangeListeners == null)
		{
			cb_clearOnChildAttachStateChangeListeners = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearOnChildAttachStateChangeListeners));
		}
		return cb_clearOnChildAttachStateChangeListeners;
	}

	private static void n_ClearOnChildAttachStateChangeListeners(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnChildAttachStateChangeListeners();
	}

	[Register("clearOnChildAttachStateChangeListeners", "()V", "GetClearOnChildAttachStateChangeListenersHandler")]
	public unsafe virtual void ClearOnChildAttachStateChangeListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnChildAttachStateChangeListeners.()V", this, null);
	}

	private static Delegate GetClearOnScrollListenersHandler()
	{
		if ((object)cb_clearOnScrollListeners == null)
		{
			cb_clearOnScrollListeners = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearOnScrollListeners));
		}
		return cb_clearOnScrollListeners;
	}

	private static void n_ClearOnScrollListeners(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnScrollListeners();
	}

	[Register("clearOnScrollListeners", "()V", "GetClearOnScrollListenersHandler")]
	public unsafe virtual void ClearOnScrollListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnScrollListeners.()V", this, null);
	}

	private static Delegate GetComputeHorizontalScrollExtentHandler()
	{
		if ((object)cb_computeHorizontalScrollExtent == null)
		{
			cb_computeHorizontalScrollExtent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ComputeHorizontalScrollExtent));
		}
		return cb_computeHorizontalScrollExtent;
	}

	private static int n_ComputeHorizontalScrollExtent(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollExtent();
	}

	[Register("computeHorizontalScrollExtent", "()I", "GetComputeHorizontalScrollExtentHandler")]
	public new unsafe virtual int ComputeHorizontalScrollExtent()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollExtent.()I", this, null);
	}

	private static Delegate GetComputeHorizontalScrollOffsetHandler()
	{
		if ((object)cb_computeHorizontalScrollOffset == null)
		{
			cb_computeHorizontalScrollOffset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ComputeHorizontalScrollOffset));
		}
		return cb_computeHorizontalScrollOffset;
	}

	private static int n_ComputeHorizontalScrollOffset(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollOffset();
	}

	[Register("computeHorizontalScrollOffset", "()I", "GetComputeHorizontalScrollOffsetHandler")]
	public new unsafe virtual int ComputeHorizontalScrollOffset()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollOffset.()I", this, null);
	}

	private static Delegate GetComputeHorizontalScrollRangeHandler()
	{
		if ((object)cb_computeHorizontalScrollRange == null)
		{
			cb_computeHorizontalScrollRange = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ComputeHorizontalScrollRange));
		}
		return cb_computeHorizontalScrollRange;
	}

	private static int n_ComputeHorizontalScrollRange(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollRange();
	}

	[Register("computeHorizontalScrollRange", "()I", "GetComputeHorizontalScrollRangeHandler")]
	public new unsafe virtual int ComputeHorizontalScrollRange()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollRange.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollExtentHandler()
	{
		if ((object)cb_computeVerticalScrollExtent == null)
		{
			cb_computeVerticalScrollExtent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ComputeVerticalScrollExtent));
		}
		return cb_computeVerticalScrollExtent;
	}

	private static int n_ComputeVerticalScrollExtent(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollExtent();
	}

	[Register("computeVerticalScrollExtent", "()I", "GetComputeVerticalScrollExtentHandler")]
	public new unsafe virtual int ComputeVerticalScrollExtent()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollExtent.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollOffsetHandler()
	{
		if ((object)cb_computeVerticalScrollOffset == null)
		{
			cb_computeVerticalScrollOffset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ComputeVerticalScrollOffset));
		}
		return cb_computeVerticalScrollOffset;
	}

	private static int n_ComputeVerticalScrollOffset(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollOffset();
	}

	[Register("computeVerticalScrollOffset", "()I", "GetComputeVerticalScrollOffsetHandler")]
	public new unsafe virtual int ComputeVerticalScrollOffset()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollOffset.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollRangeHandler()
	{
		if ((object)cb_computeVerticalScrollRange == null)
		{
			cb_computeVerticalScrollRange = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ComputeVerticalScrollRange));
		}
		return cb_computeVerticalScrollRange;
	}

	private static int n_ComputeVerticalScrollRange(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollRange();
	}

	[Register("computeVerticalScrollRange", "()I", "GetComputeVerticalScrollRangeHandler")]
	public new unsafe virtual int ComputeVerticalScrollRange()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollRange.()I", this, null);
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
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
		int[] array2 = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
		bool result = recyclerView.DispatchNestedPreScroll(dx, dy, array, array2, type);
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
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		int[] array = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
		bool result = recyclerView.DispatchNestedScroll(dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, array, type);
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

	[Register("dispatchNestedScroll", "(IIII[II[I)V", "")]
	public unsafe void DispatchNestedScroll(int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[] offsetInWindow, int type, int[] consumed)
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
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchNestedScroll.(IIII[II[I)V", this, ptr);
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

	private static Delegate GetDispatchRestoreInstanceState_Landroid_util_SparseArray_Handler()
	{
		if ((object)cb_dispatchRestoreInstanceState_Landroid_util_SparseArray_ == null)
		{
			cb_dispatchRestoreInstanceState_Landroid_util_SparseArray_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_DispatchRestoreInstanceState_Landroid_util_SparseArray_));
		}
		return cb_dispatchRestoreInstanceState_Landroid_util_SparseArray_;
	}

	private static void n_DispatchRestoreInstanceState_Landroid_util_SparseArray_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SparseArray container = Java.Lang.Object.GetObject<SparseArray>(native_container, JniHandleOwnership.DoNotTransfer);
		recyclerView.DispatchRestoreInstanceState(container);
	}

	[Register("dispatchRestoreInstanceState", "(Landroid/util/SparseArray;)V", "GetDispatchRestoreInstanceState_Landroid_util_SparseArray_Handler")]
	protected unsafe override void DispatchRestoreInstanceState(SparseArray container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchRestoreInstanceState.(Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetDispatchSaveInstanceState_Landroid_util_SparseArray_Handler()
	{
		if ((object)cb_dispatchSaveInstanceState_Landroid_util_SparseArray_ == null)
		{
			cb_dispatchSaveInstanceState_Landroid_util_SparseArray_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_DispatchSaveInstanceState_Landroid_util_SparseArray_));
		}
		return cb_dispatchSaveInstanceState_Landroid_util_SparseArray_;
	}

	private static void n_DispatchSaveInstanceState_Landroid_util_SparseArray_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SparseArray container = Java.Lang.Object.GetObject<SparseArray>(native_container, JniHandleOwnership.DoNotTransfer);
		recyclerView.DispatchSaveInstanceState(container);
	}

	[Register("dispatchSaveInstanceState", "(Landroid/util/SparseArray;)V", "GetDispatchSaveInstanceState_Landroid_util_SparseArray_Handler")]
	protected unsafe override void DispatchSaveInstanceState(SparseArray container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchSaveInstanceState.(Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetDrawChild_Landroid_graphics_Canvas_Landroid_view_View_JHandler()
	{
		if ((object)cb_drawChild_Landroid_graphics_Canvas_Landroid_view_View_J == null)
		{
			cb_drawChild_Landroid_graphics_Canvas_Landroid_view_View_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLJ_Z(n_DrawChild_Landroid_graphics_Canvas_Landroid_view_View_J));
		}
		return cb_drawChild_Landroid_graphics_Canvas_Landroid_view_View_J;
	}

	private static bool n_DrawChild_Landroid_graphics_Canvas_Landroid_view_View_J(IntPtr jnienv, IntPtr native__this, IntPtr native_canvas, IntPtr native_child, long drawingTime)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
		View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
		return recyclerView.DrawChild(canvas, child, drawingTime);
	}

	[Register("drawChild", "(Landroid/graphics/Canvas;Landroid/view/View;J)Z", "GetDrawChild_Landroid_graphics_Canvas_Landroid_view_View_JHandler")]
	public new unsafe virtual bool DrawChild(Canvas canvas, View child, long drawingTime)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(drawingTime);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("drawChild.(Landroid/graphics/Canvas;Landroid/view/View;J)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetFindChildViewUnder_FFHandler()
	{
		if ((object)cb_findChildViewUnder_FF == null)
		{
			cb_findChildViewUnder_FF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPFF_L(n_FindChildViewUnder_FF));
		}
		return cb_findChildViewUnder_FF;
	}

	private static IntPtr n_FindChildViewUnder_FF(IntPtr jnienv, IntPtr native__this, float x, float y)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindChildViewUnder(x, y));
	}

	[Register("findChildViewUnder", "(FF)Landroid/view/View;", "GetFindChildViewUnder_FFHandler")]
	public unsafe virtual View FindChildViewUnder(float x, float y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findChildViewUnder.(FF)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindContainingItemView_Landroid_view_View_Handler()
	{
		if ((object)cb_findContainingItemView_Landroid_view_View_ == null)
		{
			cb_findContainingItemView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_FindContainingItemView_Landroid_view_View_));
		}
		return cb_findContainingItemView_Landroid_view_View_;
	}

	private static IntPtr n_FindContainingItemView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(recyclerView.FindContainingItemView(view));
	}

	[Register("findContainingItemView", "(Landroid/view/View;)Landroid/view/View;", "GetFindContainingItemView_Landroid_view_View_Handler")]
	public unsafe virtual View FindContainingItemView(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findContainingItemView.(Landroid/view/View;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetFindContainingViewHolder_Landroid_view_View_Handler()
	{
		if ((object)cb_findContainingViewHolder_Landroid_view_View_ == null)
		{
			cb_findContainingViewHolder_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_FindContainingViewHolder_Landroid_view_View_));
		}
		return cb_findContainingViewHolder_Landroid_view_View_;
	}

	private static IntPtr n_FindContainingViewHolder_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(recyclerView.FindContainingViewHolder(view));
	}

	[Register("findContainingViewHolder", "(Landroid/view/View;)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetFindContainingViewHolder_Landroid_view_View_Handler")]
	public unsafe virtual ViewHolder FindContainingViewHolder(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("findContainingViewHolder.(Landroid/view/View;)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetFindViewHolderForAdapterPosition_IHandler()
	{
		if ((object)cb_findViewHolderForAdapterPosition_I == null)
		{
			cb_findViewHolderForAdapterPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_FindViewHolderForAdapterPosition_I));
		}
		return cb_findViewHolderForAdapterPosition_I;
	}

	private static IntPtr n_FindViewHolderForAdapterPosition_I(IntPtr jnienv, IntPtr native__this, int position)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewHolderForAdapterPosition(position));
	}

	[Register("findViewHolderForAdapterPosition", "(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetFindViewHolderForAdapterPosition_IHandler")]
	public unsafe virtual ViewHolder FindViewHolderForAdapterPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewHolderForAdapterPosition.(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindViewHolderForItemId_JHandler()
	{
		if ((object)cb_findViewHolderForItemId_J == null)
		{
			cb_findViewHolderForItemId_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_FindViewHolderForItemId_J));
		}
		return cb_findViewHolderForItemId_J;
	}

	private static IntPtr n_FindViewHolderForItemId_J(IntPtr jnienv, IntPtr native__this, long id)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewHolderForItemId(id));
	}

	[Register("findViewHolderForItemId", "(J)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetFindViewHolderForItemId_JHandler")]
	public unsafe virtual ViewHolder FindViewHolderForItemId(long id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewHolderForItemId.(J)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindViewHolderForLayoutPosition_IHandler()
	{
		if ((object)cb_findViewHolderForLayoutPosition_I == null)
		{
			cb_findViewHolderForLayoutPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_FindViewHolderForLayoutPosition_I));
		}
		return cb_findViewHolderForLayoutPosition_I;
	}

	private static IntPtr n_FindViewHolderForLayoutPosition_I(IntPtr jnienv, IntPtr native__this, int position)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewHolderForLayoutPosition(position));
	}

	[Register("findViewHolderForLayoutPosition", "(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetFindViewHolderForLayoutPosition_IHandler")]
	public unsafe virtual ViewHolder FindViewHolderForLayoutPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewHolderForLayoutPosition.(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindViewHolderForPosition_IHandler()
	{
		if ((object)cb_findViewHolderForPosition_I == null)
		{
			cb_findViewHolderForPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_FindViewHolderForPosition_I));
		}
		return cb_findViewHolderForPosition_I;
	}

	private static IntPtr n_FindViewHolderForPosition_I(IntPtr jnienv, IntPtr native__this, int position)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewHolderForPosition(position));
	}

	[Register("findViewHolderForPosition", "(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetFindViewHolderForPosition_IHandler")]
	public unsafe virtual ViewHolder FindViewHolderForPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewHolderForPosition.(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFling_IIHandler()
	{
		if ((object)cb_fling_II == null)
		{
			cb_fling_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_Z(n_Fling_II));
		}
		return cb_fling_II;
	}

	private static bool n_Fling_II(IntPtr jnienv, IntPtr native__this, int velocityX, int velocityY)
	{
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Fling(velocityX, velocityY);
	}

	[Register("fling", "(II)Z", "GetFling_IIHandler")]
	public unsafe virtual bool Fling(int velocityX, int velocityY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(velocityX);
		ptr[1] = new JniArgumentValue(velocityY);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("fling.(II)Z", this, ptr);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAdapter());
	}

	[Register("getAdapter", "()Landroidx/recyclerview/widget/RecyclerView$Adapter;", "GetGetAdapterHandler")]
	public unsafe virtual Adapter GetAdapter()
	{
		return Java.Lang.Object.GetObject<Adapter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAdapter.()Landroidx/recyclerview/widget/RecyclerView$Adapter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetChildAdapterPosition_Landroid_view_View_Handler()
	{
		if ((object)cb_getChildAdapterPosition_Landroid_view_View_ == null)
		{
			cb_getChildAdapterPosition_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetChildAdapterPosition_Landroid_view_View_));
		}
		return cb_getChildAdapterPosition_Landroid_view_View_;
	}

	private static int n_GetChildAdapterPosition_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
		return recyclerView.GetChildAdapterPosition(child);
	}

	[Register("getChildAdapterPosition", "(Landroid/view/View;)I", "GetGetChildAdapterPosition_Landroid_view_View_Handler")]
	public unsafe virtual int GetChildAdapterPosition(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getChildAdapterPosition.(Landroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetChildItemId_Landroid_view_View_Handler()
	{
		if ((object)cb_getChildItemId_Landroid_view_View_ == null)
		{
			cb_getChildItemId_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_J(n_GetChildItemId_Landroid_view_View_));
		}
		return cb_getChildItemId_Landroid_view_View_;
	}

	private static long n_GetChildItemId_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
		return recyclerView.GetChildItemId(child);
	}

	[Register("getChildItemId", "(Landroid/view/View;)J", "GetGetChildItemId_Landroid_view_View_Handler")]
	public unsafe virtual long GetChildItemId(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt64Method("getChildItemId.(Landroid/view/View;)J", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetChildLayoutPosition_Landroid_view_View_Handler()
	{
		if ((object)cb_getChildLayoutPosition_Landroid_view_View_ == null)
		{
			cb_getChildLayoutPosition_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetChildLayoutPosition_Landroid_view_View_));
		}
		return cb_getChildLayoutPosition_Landroid_view_View_;
	}

	private static int n_GetChildLayoutPosition_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
		return recyclerView.GetChildLayoutPosition(child);
	}

	[Register("getChildLayoutPosition", "(Landroid/view/View;)I", "GetGetChildLayoutPosition_Landroid_view_View_Handler")]
	public unsafe virtual int GetChildLayoutPosition(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getChildLayoutPosition.(Landroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetChildPosition_Landroid_view_View_Handler()
	{
		if ((object)cb_getChildPosition_Landroid_view_View_ == null)
		{
			cb_getChildPosition_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetChildPosition_Landroid_view_View_));
		}
		return cb_getChildPosition_Landroid_view_View_;
	}

	private static int n_GetChildPosition_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
		return recyclerView.GetChildPosition(child);
	}

	[Register("getChildPosition", "(Landroid/view/View;)I", "GetGetChildPosition_Landroid_view_View_Handler")]
	public unsafe virtual int GetChildPosition(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getChildPosition.(Landroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetChildViewHolder_Landroid_view_View_Handler()
	{
		if ((object)cb_getChildViewHolder_Landroid_view_View_ == null)
		{
			cb_getChildViewHolder_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetChildViewHolder_Landroid_view_View_));
		}
		return cb_getChildViewHolder_Landroid_view_View_;
	}

	private static IntPtr n_GetChildViewHolder_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(recyclerView.GetChildViewHolder(child));
	}

	[Register("getChildViewHolder", "(Landroid/view/View;)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetGetChildViewHolder_Landroid_view_View_Handler")]
	public unsafe virtual ViewHolder GetChildViewHolder(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getChildViewHolder.(Landroid/view/View;)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_Handler()
	{
		if ((object)cb_getDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_ == null)
		{
			cb_getDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_GetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_));
		}
		return cb_getDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_;
	}

	private static void n_GetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_outBounds)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		Rect outBounds = Java.Lang.Object.GetObject<Rect>(native_outBounds, JniHandleOwnership.DoNotTransfer);
		recyclerView.GetDecoratedBoundsWithMargins(view, outBounds);
	}

	[Register("getDecoratedBoundsWithMargins", "(Landroid/view/View;Landroid/graphics/Rect;)V", "GetGetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void GetDecoratedBoundsWithMargins(View view, Rect outBounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(outBounds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getDecoratedBoundsWithMargins.(Landroid/view/View;Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(outBounds);
		}
	}

	private static Delegate GetGetEdgeEffectFactoryHandler()
	{
		if ((object)cb_getEdgeEffectFactory == null)
		{
			cb_getEdgeEffectFactory = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEdgeEffectFactory));
		}
		return cb_getEdgeEffectFactory;
	}

	private static IntPtr n_GetEdgeEffectFactory(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetEdgeEffectFactory());
	}

	[Register("getEdgeEffectFactory", "()Landroidx/recyclerview/widget/RecyclerView$EdgeEffectFactory;", "GetGetEdgeEffectFactoryHandler")]
	public unsafe virtual EdgeEffectFactory GetEdgeEffectFactory()
	{
		return Java.Lang.Object.GetObject<EdgeEffectFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEdgeEffectFactory.()Landroidx/recyclerview/widget/RecyclerView$EdgeEffectFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetItemAnimatorHandler()
	{
		if ((object)cb_getItemAnimator == null)
		{
			cb_getItemAnimator = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetItemAnimator));
		}
		return cb_getItemAnimator;
	}

	private static IntPtr n_GetItemAnimator(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemAnimator());
	}

	[Register("getItemAnimator", "()Landroidx/recyclerview/widget/RecyclerView$ItemAnimator;", "GetGetItemAnimatorHandler")]
	public unsafe virtual ItemAnimator GetItemAnimator()
	{
		return Java.Lang.Object.GetObject<ItemAnimator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemAnimator.()Landroidx/recyclerview/widget/RecyclerView$ItemAnimator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetItemDecorationAt_IHandler()
	{
		if ((object)cb_getItemDecorationAt_I == null)
		{
			cb_getItemDecorationAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetItemDecorationAt_I));
		}
		return cb_getItemDecorationAt_I;
	}

	private static IntPtr n_GetItemDecorationAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemDecorationAt(index));
	}

	[Register("getItemDecorationAt", "(I)Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;", "GetGetItemDecorationAt_IHandler")]
	public unsafe virtual ItemDecoration GetItemDecorationAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<ItemDecoration>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemDecorationAt.(I)Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetLayoutManagerHandler()
	{
		if ((object)cb_getLayoutManager == null)
		{
			cb_getLayoutManager = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLayoutManager));
		}
		return cb_getLayoutManager;
	}

	private static IntPtr n_GetLayoutManager(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLayoutManager());
	}

	[Register("getLayoutManager", "()Landroidx/recyclerview/widget/RecyclerView$LayoutManager;", "GetGetLayoutManagerHandler")]
	public unsafe virtual LayoutManager GetLayoutManager()
	{
		return Java.Lang.Object.GetObject<LayoutManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLayoutManager.()Landroidx/recyclerview/widget/RecyclerView$LayoutManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetOnFlingListenerHandler()
	{
		if ((object)cb_getOnFlingListener == null)
		{
			cb_getOnFlingListener = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOnFlingListener));
		}
		return cb_getOnFlingListener;
	}

	private static IntPtr n_GetOnFlingListener(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetOnFlingListener());
	}

	[Register("getOnFlingListener", "()Landroidx/recyclerview/widget/RecyclerView$OnFlingListener;", "GetGetOnFlingListenerHandler")]
	public unsafe virtual OnFlingListener GetOnFlingListener()
	{
		return Java.Lang.Object.GetObject<OnFlingListener>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOnFlingListener.()Landroidx/recyclerview/widget/RecyclerView$OnFlingListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetRecycledViewPoolHandler()
	{
		if ((object)cb_getRecycledViewPool == null)
		{
			cb_getRecycledViewPool = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRecycledViewPool));
		}
		return cb_getRecycledViewPool;
	}

	private static IntPtr n_GetRecycledViewPool(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRecycledViewPool());
	}

	[Register("getRecycledViewPool", "()Landroidx/recyclerview/widget/RecyclerView$RecycledViewPool;", "GetGetRecycledViewPoolHandler")]
	public unsafe virtual RecycledViewPool GetRecycledViewPool()
	{
		return Java.Lang.Object.GetObject<RecycledViewPool>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRecycledViewPool.()Landroidx/recyclerview/widget/RecyclerView$RecycledViewPool;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvokeHasNestedScrollingParent(type);
	}

	[Register("hasNestedScrollingParent", "(I)Z", "GetInvokeHasNestedScrollingParent_IHandler")]
	public unsafe virtual bool InvokeHasNestedScrollingParent(int type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(type);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasNestedScrollingParent.(I)Z", this, ptr);
	}

	private static Delegate GetInvalidateItemDecorationsHandler()
	{
		if ((object)cb_invalidateItemDecorations == null)
		{
			cb_invalidateItemDecorations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_InvalidateItemDecorations));
		}
		return cb_invalidateItemDecorations;
	}

	private static void n_InvalidateItemDecorations(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateItemDecorations();
	}

	[Register("invalidateItemDecorations", "()V", "GetInvalidateItemDecorationsHandler")]
	public unsafe virtual void InvalidateItemDecorations()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateItemDecorations.()V", this, null);
	}

	private static Delegate GetOffsetChildrenHorizontal_IHandler()
	{
		if ((object)cb_offsetChildrenHorizontal_I == null)
		{
			cb_offsetChildrenHorizontal_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OffsetChildrenHorizontal_I));
		}
		return cb_offsetChildrenHorizontal_I;
	}

	private static void n_OffsetChildrenHorizontal_I(IntPtr jnienv, IntPtr native__this, int dx)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffsetChildrenHorizontal(dx);
	}

	[Register("offsetChildrenHorizontal", "(I)V", "GetOffsetChildrenHorizontal_IHandler")]
	public unsafe virtual void OffsetChildrenHorizontal(int dx)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dx);
		_members.InstanceMethods.InvokeVirtualVoidMethod("offsetChildrenHorizontal.(I)V", this, ptr);
	}

	private static Delegate GetOffsetChildrenVertical_IHandler()
	{
		if ((object)cb_offsetChildrenVertical_I == null)
		{
			cb_offsetChildrenVertical_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OffsetChildrenVertical_I));
		}
		return cb_offsetChildrenVertical_I;
	}

	private static void n_OffsetChildrenVertical_I(IntPtr jnienv, IntPtr native__this, int dy)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffsetChildrenVertical(dy);
	}

	[Register("offsetChildrenVertical", "(I)V", "GetOffsetChildrenVertical_IHandler")]
	public unsafe virtual void OffsetChildrenVertical(int dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dy);
		_members.InstanceMethods.InvokeVirtualVoidMethod("offsetChildrenVertical.(I)V", this, ptr);
	}

	private static Delegate GetOnChildAttachedToWindow_Landroid_view_View_Handler()
	{
		if ((object)cb_onChildAttachedToWindow_Landroid_view_View_ == null)
		{
			cb_onChildAttachedToWindow_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnChildAttachedToWindow_Landroid_view_View_));
		}
		return cb_onChildAttachedToWindow_Landroid_view_View_;
	}

	private static void n_OnChildAttachedToWindow_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
		recyclerView.OnChildAttachedToWindow(child);
	}

	[Register("onChildAttachedToWindow", "(Landroid/view/View;)V", "GetOnChildAttachedToWindow_Landroid_view_View_Handler")]
	public unsafe virtual void OnChildAttachedToWindow(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onChildAttachedToWindow.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetOnChildDetachedFromWindow_Landroid_view_View_Handler()
	{
		if ((object)cb_onChildDetachedFromWindow_Landroid_view_View_ == null)
		{
			cb_onChildDetachedFromWindow_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnChildDetachedFromWindow_Landroid_view_View_));
		}
		return cb_onChildDetachedFromWindow_Landroid_view_View_;
	}

	private static void n_OnChildDetachedFromWindow_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
		recyclerView.OnChildDetachedFromWindow(child);
	}

	[Register("onChildDetachedFromWindow", "(Landroid/view/View;)V", "GetOnChildDetachedFromWindow_Landroid_view_View_Handler")]
	public unsafe virtual void OnChildDetachedFromWindow(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onChildDetachedFromWindow.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
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
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
		recyclerView.OnDraw(c);
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
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayout(changed, l, t, r, b);
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

	private static Delegate GetOnScrollStateChanged_IHandler()
	{
		if ((object)cb_onScrollStateChanged_I == null)
		{
			cb_onScrollStateChanged_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnScrollStateChanged_I));
		}
		return cb_onScrollStateChanged_I;
	}

	private static void n_OnScrollStateChanged_I(IntPtr jnienv, IntPtr native__this, int state)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnScrollStateChanged(state);
	}

	[Register("onScrollStateChanged", "(I)V", "GetOnScrollStateChanged_IHandler")]
	public unsafe virtual void OnScrollStateChanged(int state)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(state);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onScrollStateChanged.(I)V", this, ptr);
	}

	private static Delegate GetOnScrolled_IIHandler()
	{
		if ((object)cb_onScrolled_II == null)
		{
			cb_onScrolled_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_OnScrolled_II));
		}
		return cb_onScrolled_II;
	}

	private static void n_OnScrolled_II(IntPtr jnienv, IntPtr native__this, int dx, int dy)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnScrolled(dx, dy);
	}

	[Register("onScrolled", "(II)V", "GetOnScrolled_IIHandler")]
	public unsafe virtual void OnScrolled(int dx, int dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(dx);
		ptr[1] = new JniArgumentValue(dy);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onScrolled.(II)V", this, ptr);
	}

	private static Delegate GetRemoveItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_Handler()
	{
		if ((object)cb_removeItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_ == null)
		{
			cb_removeItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_));
		}
		return cb_removeItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_;
	}

	private static void n_RemoveItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_(IntPtr jnienv, IntPtr native__this, IntPtr native_decor)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ItemDecoration decor = Java.Lang.Object.GetObject<ItemDecoration>(native_decor, JniHandleOwnership.DoNotTransfer);
		recyclerView.RemoveItemDecoration(decor);
	}

	[Register("removeItemDecoration", "(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", "GetRemoveItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_Handler")]
	public unsafe virtual void RemoveItemDecoration(ItemDecoration decor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(decor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeItemDecoration.(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(decor);
		}
	}

	private static Delegate GetRemoveItemDecorationAt_IHandler()
	{
		if ((object)cb_removeItemDecorationAt_I == null)
		{
			cb_removeItemDecorationAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_RemoveItemDecorationAt_I));
		}
		return cb_removeItemDecorationAt_I;
	}

	private static void n_RemoveItemDecorationAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveItemDecorationAt(index);
	}

	[Register("removeItemDecorationAt", "(I)V", "GetRemoveItemDecorationAt_IHandler")]
	public unsafe virtual void RemoveItemDecorationAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeItemDecorationAt.(I)V", this, ptr);
	}

	private static Delegate GetRemoveOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_Handler()
	{
		if ((object)cb_removeOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_ == null)
		{
			cb_removeOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_));
		}
		return cb_removeOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_;
	}

	private static void n_RemoveOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnChildAttachStateChangeListener listener = Java.Lang.Object.GetObject<IOnChildAttachStateChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		recyclerView.RemoveOnChildAttachStateChangeListener(listener);
	}

	[Register("removeOnChildAttachStateChangeListener", "(Landroidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener;)V", "GetRemoveOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_Handler")]
	public unsafe virtual void RemoveOnChildAttachStateChangeListener(IOnChildAttachStateChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnChildAttachStateChangeListener.(Landroidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_Handler()
	{
		if ((object)cb_removeOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_ == null)
		{
			cb_removeOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_));
		}
		return cb_removeOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_;
	}

	private static void n_RemoveOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IOnItemTouchListener listener = Java.Lang.Object.GetObject<IOnItemTouchListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		recyclerView.RemoveOnItemTouchListener(listener);
	}

	[Register("removeOnItemTouchListener", "(Landroidx/recyclerview/widget/RecyclerView$OnItemTouchListener;)V", "GetRemoveOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_Handler")]
	public unsafe virtual void RemoveOnItemTouchListener(IOnItemTouchListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnItemTouchListener.(Landroidx/recyclerview/widget/RecyclerView$OnItemTouchListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler()
	{
		if ((object)cb_removeOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_ == null)
		{
			cb_removeOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_));
		}
		return cb_removeOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_;
	}

	private static void n_RemoveOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		OnScrollListener listener = Java.Lang.Object.GetObject<OnScrollListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		recyclerView.RemoveOnScrollListener(listener);
	}

	[Register("removeOnScrollListener", "(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", "GetRemoveOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler")]
	public unsafe virtual void RemoveOnScrollListener(OnScrollListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnScrollListener.(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetScrollToPosition_IHandler()
	{
		if ((object)cb_scrollToPosition_I == null)
		{
			cb_scrollToPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_ScrollToPosition_I));
		}
		return cb_scrollToPosition_I;
	}

	private static void n_ScrollToPosition_I(IntPtr jnienv, IntPtr native__this, int position)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollToPosition(position);
	}

	[Register("scrollToPosition", "(I)V", "GetScrollToPosition_IHandler")]
	public unsafe virtual void ScrollToPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("scrollToPosition.(I)V", this, ptr);
	}

	private static Delegate GetSetAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_Handler()
	{
		if ((object)cb_setAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_ == null)
		{
			cb_setAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_));
		}
		return cb_setAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_;
	}

	private static void n_SetAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_(IntPtr jnienv, IntPtr native__this, IntPtr native_accessibilityDelegate)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		RecyclerViewAccessibilityDelegate accessibilityDelegateCompat = Java.Lang.Object.GetObject<RecyclerViewAccessibilityDelegate>(native_accessibilityDelegate, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetAccessibilityDelegateCompat(accessibilityDelegateCompat);
	}

	[Register("setAccessibilityDelegateCompat", "(Landroidx/recyclerview/widget/RecyclerViewAccessibilityDelegate;)V", "GetSetAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_Handler")]
	public unsafe virtual void SetAccessibilityDelegateCompat(RecyclerViewAccessibilityDelegate accessibilityDelegate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(accessibilityDelegate?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAccessibilityDelegateCompat.(Landroidx/recyclerview/widget/RecyclerViewAccessibilityDelegate;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(accessibilityDelegate);
		}
	}

	private static Delegate GetSetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Handler()
	{
		if ((object)cb_setAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_ == null)
		{
			cb_setAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_));
		}
		return cb_setAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_;
	}

	private static void n_SetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_(IntPtr jnienv, IntPtr native__this, IntPtr native_adapter)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Adapter adapter = Java.Lang.Object.GetObject<Adapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetAdapter(adapter);
	}

	[Register("setAdapter", "(Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", "GetSetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Handler")]
	public unsafe virtual void SetAdapter(Adapter adapter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(adapter?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAdapter.(Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapter);
		}
	}

	private static Delegate GetSetChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_Handler()
	{
		if ((object)cb_setChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_ == null)
		{
			cb_setChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_));
		}
		return cb_setChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_;
	}

	private static void n_SetChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_childDrawingOrderCallback)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IChildDrawingOrderCallback childDrawingOrderCallback = Java.Lang.Object.GetObject<IChildDrawingOrderCallback>(native_childDrawingOrderCallback, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetChildDrawingOrderCallback(childDrawingOrderCallback);
	}

	[Register("setChildDrawingOrderCallback", "(Landroidx/recyclerview/widget/RecyclerView$ChildDrawingOrderCallback;)V", "GetSetChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_Handler")]
	public unsafe virtual void SetChildDrawingOrderCallback(IChildDrawingOrderCallback childDrawingOrderCallback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((childDrawingOrderCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)childDrawingOrderCallback).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setChildDrawingOrderCallback.(Landroidx/recyclerview/widget/RecyclerView$ChildDrawingOrderCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(childDrawingOrderCallback);
		}
	}

	private static Delegate GetSetEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_Handler()
	{
		if ((object)cb_setEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_ == null)
		{
			cb_setEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_));
		}
		return cb_setEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_;
	}

	private static void n_SetEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_(IntPtr jnienv, IntPtr native__this, IntPtr native_edgeEffectFactory)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		EdgeEffectFactory edgeEffectFactory = Java.Lang.Object.GetObject<EdgeEffectFactory>(native_edgeEffectFactory, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetEdgeEffectFactory(edgeEffectFactory);
	}

	[Register("setEdgeEffectFactory", "(Landroidx/recyclerview/widget/RecyclerView$EdgeEffectFactory;)V", "GetSetEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_Handler")]
	public unsafe virtual void SetEdgeEffectFactory(EdgeEffectFactory edgeEffectFactory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(edgeEffectFactory?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEdgeEffectFactory.(Landroidx/recyclerview/widget/RecyclerView$EdgeEffectFactory;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(edgeEffectFactory);
		}
	}

	private static Delegate GetSetItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_Handler()
	{
		if ((object)cb_setItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ == null)
		{
			cb_setItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_));
		}
		return cb_setItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_;
	}

	private static void n_SetItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_(IntPtr jnienv, IntPtr native__this, IntPtr native_animator)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(native_animator, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetItemAnimator(itemAnimator);
	}

	[Register("setItemAnimator", "(Landroidx/recyclerview/widget/RecyclerView$ItemAnimator;)V", "GetSetItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_Handler")]
	public unsafe virtual void SetItemAnimator(ItemAnimator animator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animator?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemAnimator.(Landroidx/recyclerview/widget/RecyclerView$ItemAnimator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(animator);
		}
	}

	private static Delegate GetSetItemViewCacheSize_IHandler()
	{
		if ((object)cb_setItemViewCacheSize_I == null)
		{
			cb_setItemViewCacheSize_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetItemViewCacheSize_I));
		}
		return cb_setItemViewCacheSize_I;
	}

	private static void n_SetItemViewCacheSize_I(IntPtr jnienv, IntPtr native__this, int size)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetItemViewCacheSize(size);
	}

	[Register("setItemViewCacheSize", "(I)V", "GetSetItemViewCacheSize_IHandler")]
	public unsafe virtual void SetItemViewCacheSize(int size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(size);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setItemViewCacheSize.(I)V", this, ptr);
	}

	private static Delegate GetSetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler()
	{
		if ((object)cb_setLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_ == null)
		{
			cb_setLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_));
		}
		return cb_setLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_;
	}

	private static void n_SetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_(IntPtr jnienv, IntPtr native__this, IntPtr native_layout)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(native_layout, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetLayoutManager(layoutManager);
	}

	[Register("setLayoutManager", "(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)V", "GetSetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler")]
	public unsafe virtual void SetLayoutManager(LayoutManager layout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLayoutManager.(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layout);
		}
	}

	private static Delegate GetSetOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_Handler()
	{
		if ((object)cb_setOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_ == null)
		{
			cb_setOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_));
		}
		return cb_setOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_;
	}

	private static void n_SetOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_onFlingListener)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		OnFlingListener onFlingListener = Java.Lang.Object.GetObject<OnFlingListener>(native_onFlingListener, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetOnFlingListener(onFlingListener);
	}

	[Register("setOnFlingListener", "(Landroidx/recyclerview/widget/RecyclerView$OnFlingListener;)V", "GetSetOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_Handler")]
	public unsafe virtual void SetOnFlingListener(OnFlingListener onFlingListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(onFlingListener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnFlingListener.(Landroidx/recyclerview/widget/RecyclerView$OnFlingListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(onFlingListener);
		}
	}

	private static Delegate GetSetOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler()
	{
		if ((object)cb_setOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_ == null)
		{
			cb_setOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_));
		}
		return cb_setOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_;
	}

	private static void n_SetOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		OnScrollListener onScrollListener = Java.Lang.Object.GetObject<OnScrollListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetOnScrollListener(onScrollListener);
	}

	[Register("setOnScrollListener", "(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", "GetSetOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler")]
	public unsafe virtual void SetOnScrollListener(OnScrollListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnScrollListener.(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_Handler()
	{
		if ((object)cb_setRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_ == null)
		{
			cb_setRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_));
		}
		return cb_setRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_;
	}

	private static void n_SetRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_(IntPtr jnienv, IntPtr native__this, IntPtr native_pool)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		RecycledViewPool recycledViewPool = Java.Lang.Object.GetObject<RecycledViewPool>(native_pool, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetRecycledViewPool(recycledViewPool);
	}

	[Register("setRecycledViewPool", "(Landroidx/recyclerview/widget/RecyclerView$RecycledViewPool;)V", "GetSetRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_Handler")]
	public unsafe virtual void SetRecycledViewPool(RecycledViewPool pool)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(pool?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRecycledViewPool.(Landroidx/recyclerview/widget/RecyclerView$RecycledViewPool;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pool);
		}
	}

	private static Delegate GetSetRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_Handler()
	{
		if ((object)cb_setRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_ == null)
		{
			cb_setRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_));
		}
		return cb_setRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_;
	}

	private static void n_SetRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRecyclerListener recyclerListener = Java.Lang.Object.GetObject<IRecyclerListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetRecyclerListener(recyclerListener);
	}

	[Register("setRecyclerListener", "(Landroidx/recyclerview/widget/RecyclerView$RecyclerListener;)V", "GetSetRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_Handler")]
	public unsafe virtual void SetRecyclerListener(IRecyclerListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRecyclerListener.(Landroidx/recyclerview/widget/RecyclerView$RecyclerListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetScrollingTouchSlop_IHandler()
	{
		if ((object)cb_setScrollingTouchSlop_I == null)
		{
			cb_setScrollingTouchSlop_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetScrollingTouchSlop_I));
		}
		return cb_setScrollingTouchSlop_I;
	}

	private static void n_SetScrollingTouchSlop_I(IntPtr jnienv, IntPtr native__this, int slopConstant)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScrollingTouchSlop(slopConstant);
	}

	[Register("setScrollingTouchSlop", "(I)V", "GetSetScrollingTouchSlop_IHandler")]
	public unsafe virtual void SetScrollingTouchSlop(int slopConstant)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(slopConstant);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setScrollingTouchSlop.(I)V", this, ptr);
	}

	private static Delegate GetSetViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_Handler()
	{
		if ((object)cb_setViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_ == null)
		{
			cb_setViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_));
		}
		return cb_setViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_;
	}

	private static void n_SetViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_(IntPtr jnienv, IntPtr native__this, IntPtr native_extension)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewCacheExtension viewCacheExtension = Java.Lang.Object.GetObject<ViewCacheExtension>(native_extension, JniHandleOwnership.DoNotTransfer);
		recyclerView.SetViewCacheExtension(viewCacheExtension);
	}

	[Register("setViewCacheExtension", "(Landroidx/recyclerview/widget/RecyclerView$ViewCacheExtension;)V", "GetSetViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_Handler")]
	public unsafe virtual void SetViewCacheExtension(ViewCacheExtension extension)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(extension?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setViewCacheExtension.(Landroidx/recyclerview/widget/RecyclerView$ViewCacheExtension;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(extension);
		}
	}

	private static Delegate GetSmoothScrollBy_IIHandler()
	{
		if ((object)cb_smoothScrollBy_II == null)
		{
			cb_smoothScrollBy_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SmoothScrollBy_II));
		}
		return cb_smoothScrollBy_II;
	}

	private static void n_SmoothScrollBy_II(IntPtr jnienv, IntPtr native__this, int dx, int dy)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SmoothScrollBy(dx, dy);
	}

	[Register("smoothScrollBy", "(II)V", "GetSmoothScrollBy_IIHandler")]
	public unsafe virtual void SmoothScrollBy(int dx, int dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(dx);
		ptr[1] = new JniArgumentValue(dy);
		_members.InstanceMethods.InvokeVirtualVoidMethod("smoothScrollBy.(II)V", this, ptr);
	}

	private static Delegate GetSmoothScrollBy_IILandroid_view_animation_Interpolator_Handler()
	{
		if ((object)cb_smoothScrollBy_IILandroid_view_animation_Interpolator_ == null)
		{
			cb_smoothScrollBy_IILandroid_view_animation_Interpolator_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIL_V(n_SmoothScrollBy_IILandroid_view_animation_Interpolator_));
		}
		return cb_smoothScrollBy_IILandroid_view_animation_Interpolator_;
	}

	private static void n_SmoothScrollBy_IILandroid_view_animation_Interpolator_(IntPtr jnienv, IntPtr native__this, int dx, int dy, IntPtr native_interpolator)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IInterpolator interpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
		recyclerView.SmoothScrollBy(dx, dy, interpolator);
	}

	[Register("smoothScrollBy", "(IILandroid/view/animation/Interpolator;)V", "GetSmoothScrollBy_IILandroid_view_animation_Interpolator_Handler")]
	public unsafe virtual void SmoothScrollBy(int dx, int dy, IInterpolator interpolator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(dx);
			ptr[1] = new JniArgumentValue(dy);
			ptr[2] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("smoothScrollBy.(IILandroid/view/animation/Interpolator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(interpolator);
		}
	}

	private static Delegate GetSmoothScrollBy_IILandroid_view_animation_Interpolator_IHandler()
	{
		if ((object)cb_smoothScrollBy_IILandroid_view_animation_Interpolator_I == null)
		{
			cb_smoothScrollBy_IILandroid_view_animation_Interpolator_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIILI_V(n_SmoothScrollBy_IILandroid_view_animation_Interpolator_I));
		}
		return cb_smoothScrollBy_IILandroid_view_animation_Interpolator_I;
	}

	private static void n_SmoothScrollBy_IILandroid_view_animation_Interpolator_I(IntPtr jnienv, IntPtr native__this, int dx, int dy, IntPtr native_interpolator, int duration)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IInterpolator interpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
		recyclerView.SmoothScrollBy(dx, dy, interpolator, duration);
	}

	[Register("smoothScrollBy", "(IILandroid/view/animation/Interpolator;I)V", "GetSmoothScrollBy_IILandroid_view_animation_Interpolator_IHandler")]
	public unsafe virtual void SmoothScrollBy(int dx, int dy, IInterpolator interpolator, int duration)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(dx);
			ptr[1] = new JniArgumentValue(dy);
			ptr[2] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
			ptr[3] = new JniArgumentValue(duration);
			_members.InstanceMethods.InvokeVirtualVoidMethod("smoothScrollBy.(IILandroid/view/animation/Interpolator;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(interpolator);
		}
	}

	private static Delegate GetSmoothScrollToPosition_IHandler()
	{
		if ((object)cb_smoothScrollToPosition_I == null)
		{
			cb_smoothScrollToPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SmoothScrollToPosition_I));
		}
		return cb_smoothScrollToPosition_I;
	}

	private static void n_SmoothScrollToPosition_I(IntPtr jnienv, IntPtr native__this, int position)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SmoothScrollToPosition(position);
	}

	[Register("smoothScrollToPosition", "(I)V", "GetSmoothScrollToPosition_IHandler")]
	public unsafe virtual void SmoothScrollToPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("smoothScrollToPosition.(I)V", this, ptr);
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
		return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartNestedScroll((ScrollAxis)native_axes, type);
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
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopNestedScroll(type);
	}

	[Register("stopNestedScroll", "(I)V", "GetStopNestedScroll_IHandler")]
	public unsafe virtual void StopNestedScroll(int type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(type);
		_members.InstanceMethods.InvokeVirtualVoidMethod("stopNestedScroll.(I)V", this, ptr);
	}

	private static Delegate GetStopScrollHandler()
	{
		if ((object)cb_stopScroll == null)
		{
			cb_stopScroll = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StopScroll));
		}
		return cb_stopScroll;
	}

	private static void n_StopScroll(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopScroll();
	}

	[Register("stopScroll", "()V", "GetStopScrollHandler")]
	public unsafe virtual void StopScroll()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("stopScroll.()V", this, null);
	}

	[Register("suppressLayout", "(Z)V", "")]
	public unsafe void SuppressLayout(bool suppress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(suppress);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("suppressLayout.(Z)V", this, ptr);
	}

	private static Delegate GetSwapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_ZHandler()
	{
		if ((object)cb_swapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Z == null)
		{
			cb_swapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_SwapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Z));
		}
		return cb_swapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Z;
	}

	private static void n_SwapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_adapter, bool removeAndRecycleExistingViews)
	{
		RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Adapter adapter = Java.Lang.Object.GetObject<Adapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
		recyclerView.SwapAdapter(adapter, removeAndRecycleExistingViews);
	}

	[Register("swapAdapter", "(Landroidx/recyclerview/widget/RecyclerView$Adapter;Z)V", "GetSwapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_ZHandler")]
	public unsafe virtual void SwapAdapter(Adapter adapter, bool removeAndRecycleExistingViews)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(adapter?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(removeAndRecycleExistingViews);
			_members.InstanceMethods.InvokeVirtualVoidMethod("swapAdapter.(Landroidx/recyclerview/widget/RecyclerView$Adapter;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapter);
		}
	}

	private IOnChildAttachStateChangeListenerImplementor __CreateIOnChildAttachStateChangeListenerImplementor()
	{
		return new IOnChildAttachStateChangeListenerImplementor(this);
	}

	private IOnItemTouchListenerImplementor __CreateIOnItemTouchListenerImplementor()
	{
		return new IOnItemTouchListenerImplementor(this);
	}

	private IRecyclerListenerImplementor __CreateIRecyclerListenerImplementor()
	{
		return new IRecyclerListenerImplementor(this);
	}
}
[Register("androidx/recyclerview/widget/RecyclerViewAccessibilityDelegate", DoNotGenerateAcw = true)]
public class RecyclerViewAccessibilityDelegate : AccessibilityDelegateCompat
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerViewAccessibilityDelegate", typeof(RecyclerViewAccessibilityDelegate));

	private static Delegate cb_getItemDelegate;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected RecyclerViewAccessibilityDelegate(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/recyclerview/widget/RecyclerView;)V", "")]
	public unsafe RecyclerViewAccessibilityDelegate(RecyclerView recyclerView)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/recyclerview/widget/RecyclerView;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(recyclerView);
		}
	}

	private static Delegate GetGetItemDelegateHandler()
	{
		if ((object)cb_getItemDelegate == null)
		{
			cb_getItemDelegate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetItemDelegate));
		}
		return cb_getItemDelegate;
	}

	private static IntPtr n_GetItemDelegate(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerViewAccessibilityDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemDelegate());
	}

	[Register("getItemDelegate", "()Landroidx/core/view/AccessibilityDelegateCompat;", "GetGetItemDelegateHandler")]
	public unsafe virtual AccessibilityDelegateCompat GetItemDelegate()
	{
		return Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemDelegate.()Landroidx/core/view/AccessibilityDelegateCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
