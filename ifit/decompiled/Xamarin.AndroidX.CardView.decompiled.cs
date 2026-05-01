using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "088bac3ab11a33da9695fc2b2b4f6d6370d5b8a8")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20211001.5")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "10/1/2021 5:56:45 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: NamespaceMapping(Java = "androidx.cardview.widget", Managed = "AndroidX.CardView.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - cardview  artifact=androidx.cardview:cardview artifact_versioned=androidx.cardview:cardview:1.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.CardView")]
[assembly: AssemblyTitle("Xamarin.AndroidX.CardView")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate float _JniMarshal_PP_F(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPF_V(IntPtr jnienv, IntPtr klass, float p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPIIII_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
namespace AndroidX.CardView.Widget;

[Register("androidx/cardview/widget/CardView", DoNotGenerateAcw = true)]
public class CardView : FrameLayout
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/cardview/widget/CardView", typeof(CardView));

	private static Delegate cb_getCardBackgroundColor;

	private static Delegate cb_setCardBackgroundColor_Landroid_content_res_ColorStateList_;

	private static Delegate cb_getCardElevation;

	private static Delegate cb_setCardElevation_F;

	private static Delegate cb_getContentPaddingBottom;

	private static Delegate cb_getContentPaddingLeft;

	private static Delegate cb_getContentPaddingRight;

	private static Delegate cb_getContentPaddingTop;

	private static Delegate cb_getMaxCardElevation;

	private static Delegate cb_setMaxCardElevation_F;

	private static Delegate cb_getPreventCornerOverlap;

	private static Delegate cb_setPreventCornerOverlap_Z;

	private static Delegate cb_getRadius;

	private static Delegate cb_setRadius_F;

	private static Delegate cb_getUseCompatPadding;

	private static Delegate cb_setUseCompatPadding_Z;

	private static Delegate cb_setCardBackgroundColor_I;

	private static Delegate cb_setContentPadding_IIII;

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

	public unsafe virtual ColorStateList CardBackgroundColor
	{
		[Register("getCardBackgroundColor", "()Landroid/content/res/ColorStateList;", "GetGetCardBackgroundColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCardBackgroundColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCardBackgroundColor", "(Landroid/content/res/ColorStateList;)V", "GetSetCardBackgroundColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCardBackgroundColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual float CardElevation
	{
		[Register("getCardElevation", "()F", "GetGetCardElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getCardElevation.()F", this, null);
		}
		[Register("setCardElevation", "(F)V", "GetSetCardElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCardElevation.(F)V", this, ptr);
		}
	}

	public unsafe virtual int ContentPaddingBottom
	{
		[Register("getContentPaddingBottom", "()I", "GetGetContentPaddingBottomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentPaddingBottom.()I", this, null);
		}
	}

	public unsafe virtual int ContentPaddingLeft
	{
		[Register("getContentPaddingLeft", "()I", "GetGetContentPaddingLeftHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentPaddingLeft.()I", this, null);
		}
	}

	public unsafe virtual int ContentPaddingRight
	{
		[Register("getContentPaddingRight", "()I", "GetGetContentPaddingRightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentPaddingRight.()I", this, null);
		}
	}

	public unsafe virtual int ContentPaddingTop
	{
		[Register("getContentPaddingTop", "()I", "GetGetContentPaddingTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentPaddingTop.()I", this, null);
		}
	}

	public unsafe virtual float MaxCardElevation
	{
		[Register("getMaxCardElevation", "()F", "GetGetMaxCardElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getMaxCardElevation.()F", this, null);
		}
		[Register("setMaxCardElevation", "(F)V", "GetSetMaxCardElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxCardElevation.(F)V", this, ptr);
		}
	}

	public unsafe virtual bool PreventCornerOverlap
	{
		[Register("getPreventCornerOverlap", "()Z", "GetGetPreventCornerOverlapHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getPreventCornerOverlap.()Z", this, null);
		}
		[Register("setPreventCornerOverlap", "(Z)V", "GetSetPreventCornerOverlap_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPreventCornerOverlap.(Z)V", this, ptr);
		}
	}

	public unsafe virtual float Radius
	{
		[Register("getRadius", "()F", "GetGetRadiusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getRadius.()F", this, null);
		}
		[Register("setRadius", "(F)V", "GetSetRadius_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRadius.(F)V", this, ptr);
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

	protected CardView(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe CardView(Context context)
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
	public unsafe CardView(Context context, IAttributeSet attrs)
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
	public unsafe CardView(Context context, IAttributeSet attrs, int defStyleAttr)
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

	private static Delegate GetGetCardBackgroundColorHandler()
	{
		if ((object)cb_getCardBackgroundColor == null)
		{
			cb_getCardBackgroundColor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCardBackgroundColor));
		}
		return cb_getCardBackgroundColor;
	}

	private static IntPtr n_GetCardBackgroundColor(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CardBackgroundColor);
	}

	private static Delegate GetSetCardBackgroundColor_Landroid_content_res_ColorStateList_Handler()
	{
		if ((object)cb_setCardBackgroundColor_Landroid_content_res_ColorStateList_ == null)
		{
			cb_setCardBackgroundColor_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetCardBackgroundColor_Landroid_content_res_ColorStateList_));
		}
		return cb_setCardBackgroundColor_Landroid_content_res_ColorStateList_;
	}

	private static void n_SetCardBackgroundColor_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_color)
	{
		CardView cardView = Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ColorStateList cardBackgroundColor = Java.Lang.Object.GetObject<ColorStateList>(native_color, JniHandleOwnership.DoNotTransfer);
		cardView.CardBackgroundColor = cardBackgroundColor;
	}

	private static Delegate GetGetCardElevationHandler()
	{
		if ((object)cb_getCardElevation == null)
		{
			cb_getCardElevation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetCardElevation));
		}
		return cb_getCardElevation;
	}

	private static float n_GetCardElevation(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CardElevation;
	}

	private static Delegate GetSetCardElevation_FHandler()
	{
		if ((object)cb_setCardElevation_F == null)
		{
			cb_setCardElevation_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetCardElevation_F));
		}
		return cb_setCardElevation_F;
	}

	private static void n_SetCardElevation_F(IntPtr jnienv, IntPtr native__this, float elevation)
	{
		Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CardElevation = elevation;
	}

	private static Delegate GetGetContentPaddingBottomHandler()
	{
		if ((object)cb_getContentPaddingBottom == null)
		{
			cb_getContentPaddingBottom = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetContentPaddingBottom));
		}
		return cb_getContentPaddingBottom;
	}

	private static int n_GetContentPaddingBottom(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentPaddingBottom;
	}

	private static Delegate GetGetContentPaddingLeftHandler()
	{
		if ((object)cb_getContentPaddingLeft == null)
		{
			cb_getContentPaddingLeft = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetContentPaddingLeft));
		}
		return cb_getContentPaddingLeft;
	}

	private static int n_GetContentPaddingLeft(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentPaddingLeft;
	}

	private static Delegate GetGetContentPaddingRightHandler()
	{
		if ((object)cb_getContentPaddingRight == null)
		{
			cb_getContentPaddingRight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetContentPaddingRight));
		}
		return cb_getContentPaddingRight;
	}

	private static int n_GetContentPaddingRight(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentPaddingRight;
	}

	private static Delegate GetGetContentPaddingTopHandler()
	{
		if ((object)cb_getContentPaddingTop == null)
		{
			cb_getContentPaddingTop = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetContentPaddingTop));
		}
		return cb_getContentPaddingTop;
	}

	private static int n_GetContentPaddingTop(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentPaddingTop;
	}

	private static Delegate GetGetMaxCardElevationHandler()
	{
		if ((object)cb_getMaxCardElevation == null)
		{
			cb_getMaxCardElevation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetMaxCardElevation));
		}
		return cb_getMaxCardElevation;
	}

	private static float n_GetMaxCardElevation(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxCardElevation;
	}

	private static Delegate GetSetMaxCardElevation_FHandler()
	{
		if ((object)cb_setMaxCardElevation_F == null)
		{
			cb_setMaxCardElevation_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetMaxCardElevation_F));
		}
		return cb_setMaxCardElevation_F;
	}

	private static void n_SetMaxCardElevation_F(IntPtr jnienv, IntPtr native__this, float maxElevation)
	{
		Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxCardElevation = maxElevation;
	}

	private static Delegate GetGetPreventCornerOverlapHandler()
	{
		if ((object)cb_getPreventCornerOverlap == null)
		{
			cb_getPreventCornerOverlap = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetPreventCornerOverlap));
		}
		return cb_getPreventCornerOverlap;
	}

	private static bool n_GetPreventCornerOverlap(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreventCornerOverlap;
	}

	private static Delegate GetSetPreventCornerOverlap_ZHandler()
	{
		if ((object)cb_setPreventCornerOverlap_Z == null)
		{
			cb_setPreventCornerOverlap_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetPreventCornerOverlap_Z));
		}
		return cb_setPreventCornerOverlap_Z;
	}

	private static void n_SetPreventCornerOverlap_Z(IntPtr jnienv, IntPtr native__this, bool preventCornerOverlap)
	{
		Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreventCornerOverlap = preventCornerOverlap;
	}

	private static Delegate GetGetRadiusHandler()
	{
		if ((object)cb_getRadius == null)
		{
			cb_getRadius = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetRadius));
		}
		return cb_getRadius;
	}

	private static float n_GetRadius(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Radius;
	}

	private static Delegate GetSetRadius_FHandler()
	{
		if ((object)cb_setRadius_F == null)
		{
			cb_setRadius_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetRadius_F));
		}
		return cb_setRadius_F;
	}

	private static void n_SetRadius_F(IntPtr jnienv, IntPtr native__this, float radius)
	{
		Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Radius = radius;
	}

	private static Delegate GetGetUseCompatPaddingHandler()
	{
		if ((object)cb_getUseCompatPadding == null)
		{
			cb_getUseCompatPadding = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetUseCompatPadding));
		}
		return cb_getUseCompatPadding;
	}

	private static bool n_GetUseCompatPadding(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCompatPadding;
	}

	private static Delegate GetSetUseCompatPadding_ZHandler()
	{
		if ((object)cb_setUseCompatPadding_Z == null)
		{
			cb_setUseCompatPadding_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetUseCompatPadding_Z));
		}
		return cb_setUseCompatPadding_Z;
	}

	private static void n_SetUseCompatPadding_Z(IntPtr jnienv, IntPtr native__this, bool useCompatPadding)
	{
		Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCompatPadding = useCompatPadding;
	}

	private static Delegate GetSetCardBackgroundColor_IHandler()
	{
		if ((object)cb_setCardBackgroundColor_I == null)
		{
			cb_setCardBackgroundColor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetCardBackgroundColor_I));
		}
		return cb_setCardBackgroundColor_I;
	}

	private static void n_SetCardBackgroundColor_I(IntPtr jnienv, IntPtr native__this, int color)
	{
		Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCardBackgroundColor(color);
	}

	[Register("setCardBackgroundColor", "(I)V", "GetSetCardBackgroundColor_IHandler")]
	public unsafe virtual void SetCardBackgroundColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCardBackgroundColor.(I)V", this, ptr);
	}

	private static Delegate GetSetContentPadding_IIIIHandler()
	{
		if ((object)cb_setContentPadding_IIII == null)
		{
			cb_setContentPadding_IIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIII_V(n_SetContentPadding_IIII));
		}
		return cb_setContentPadding_IIII;
	}

	private static void n_SetContentPadding_IIII(IntPtr jnienv, IntPtr native__this, int left, int top, int right, int bottom)
	{
		Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentPadding(left, top, right, bottom);
	}

	[Register("setContentPadding", "(IIII)V", "GetSetContentPadding_IIIIHandler")]
	public unsafe virtual void SetContentPadding(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setContentPadding.(IIII)V", this, ptr);
	}
}
