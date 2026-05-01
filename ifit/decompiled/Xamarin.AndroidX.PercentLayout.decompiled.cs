using System;
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
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "e5a6b02d02ddb3e019188abc52afb16fa99eec1f")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20200915.2")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "9/15/2020 5:05:12 PM")]
[assembly: LinkerSafe]
[assembly: NamespaceMapping(Java = "androidx.percentlayout.widget", Managed = "AndroidX.PercentLayout.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - percentlayout")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.PercentLayout")]
[assembly: AssemblyTitle("Xamarin.AndroidX.PercentLayout")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPII_V(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate void _JniMarshal_PPLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
namespace AndroidX.PercentLayout.Widget;

[Register("androidx/percentlayout/widget/PercentLayoutHelper", DoNotGenerateAcw = true)]
public class PercentLayoutHelper : Java.Lang.Object
{
	[Register("androidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutInfo", DoNotGenerateAcw = true)]
	public class PercentLayoutInfo : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutInfo", typeof(PercentLayoutInfo));

		private static Delegate cb_fillLayoutParams_Landroid_view_ViewGroup_LayoutParams_II;

		private static Delegate cb_fillMarginLayoutParams_Landroid_view_View_Landroid_view_ViewGroup_MarginLayoutParams_II;

		private static Delegate cb_fillMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_II;

		private static Delegate cb_restoreLayoutParams_Landroid_view_ViewGroup_LayoutParams_;

		private static Delegate cb_restoreMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_;

		[Register("aspectRatio")]
		public float AspectRatio
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("aspectRatio.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("aspectRatio.F", this, value);
			}
		}

		[Register("bottomMarginPercent")]
		public float BottomMarginPercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("bottomMarginPercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("bottomMarginPercent.F", this, value);
			}
		}

		[Register("endMarginPercent")]
		public float EndMarginPercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("endMarginPercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("endMarginPercent.F", this, value);
			}
		}

		[Register("heightPercent")]
		public float HeightPercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("heightPercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("heightPercent.F", this, value);
			}
		}

		[Register("leftMarginPercent")]
		public float LeftMarginPercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("leftMarginPercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("leftMarginPercent.F", this, value);
			}
		}

		[Register("rightMarginPercent")]
		public float RightMarginPercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("rightMarginPercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("rightMarginPercent.F", this, value);
			}
		}

		[Register("startMarginPercent")]
		public float StartMarginPercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("startMarginPercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("startMarginPercent.F", this, value);
			}
		}

		[Register("topMarginPercent")]
		public float TopMarginPercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("topMarginPercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("topMarginPercent.F", this, value);
			}
		}

		[Register("widthPercent")]
		public float WidthPercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("widthPercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("widthPercent.F", this, value);
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected PercentLayoutInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PercentLayoutInfo()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetFillLayoutParams_Landroid_view_ViewGroup_LayoutParams_IIHandler()
		{
			if ((object)cb_fillLayoutParams_Landroid_view_ViewGroup_LayoutParams_II == null)
			{
				cb_fillLayoutParams_Landroid_view_ViewGroup_LayoutParams_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_FillLayoutParams_Landroid_view_ViewGroup_LayoutParams_II));
			}
			return cb_fillLayoutParams_Landroid_view_ViewGroup_LayoutParams_II;
		}

		private static void n_FillLayoutParams_Landroid_view_ViewGroup_LayoutParams_II(IntPtr jnienv, IntPtr native__this, IntPtr native_parameters, int widthHint, int heightHint)
		{
			PercentLayoutInfo percentLayoutInfo = Java.Lang.Object.GetObject<PercentLayoutInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup.LayoutParams parameters = Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(native_parameters, JniHandleOwnership.DoNotTransfer);
			percentLayoutInfo.FillLayoutParams(parameters, widthHint, heightHint);
		}

		[Register("fillLayoutParams", "(Landroid/view/ViewGroup$LayoutParams;II)V", "GetFillLayoutParams_Landroid_view_ViewGroup_LayoutParams_IIHandler")]
		public unsafe virtual void FillLayoutParams(ViewGroup.LayoutParams parameters, int widthHint, int heightHint)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(widthHint);
			ptr[2] = new JniArgumentValue(heightHint);
			_members.InstanceMethods.InvokeVirtualVoidMethod("fillLayoutParams.(Landroid/view/ViewGroup$LayoutParams;II)V", this, ptr);
			GC.KeepAlive(parameters);
		}

		private static Delegate GetFillMarginLayoutParams_Landroid_view_View_Landroid_view_ViewGroup_MarginLayoutParams_IIHandler()
		{
			if ((object)cb_fillMarginLayoutParams_Landroid_view_View_Landroid_view_ViewGroup_MarginLayoutParams_II == null)
			{
				cb_fillMarginLayoutParams_Landroid_view_View_Landroid_view_ViewGroup_MarginLayoutParams_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLII_V(n_FillMarginLayoutParams_Landroid_view_View_Landroid_view_ViewGroup_MarginLayoutParams_II));
			}
			return cb_fillMarginLayoutParams_Landroid_view_View_Landroid_view_ViewGroup_MarginLayoutParams_II;
		}

		private static void n_FillMarginLayoutParams_Landroid_view_View_Landroid_view_ViewGroup_MarginLayoutParams_II(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_parameters, int widthHint, int heightHint)
		{
			PercentLayoutInfo percentLayoutInfo = Java.Lang.Object.GetObject<PercentLayoutInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			ViewGroup.MarginLayoutParams parameters = Java.Lang.Object.GetObject<ViewGroup.MarginLayoutParams>(native_parameters, JniHandleOwnership.DoNotTransfer);
			percentLayoutInfo.FillMarginLayoutParams(view, parameters, widthHint, heightHint);
		}

		[Register("fillMarginLayoutParams", "(Landroid/view/View;Landroid/view/ViewGroup$MarginLayoutParams;II)V", "GetFillMarginLayoutParams_Landroid_view_View_Landroid_view_ViewGroup_MarginLayoutParams_IIHandler")]
		public unsafe virtual void FillMarginLayoutParams(View view, ViewGroup.MarginLayoutParams parameters, int widthHint, int heightHint)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(widthHint);
			ptr[3] = new JniArgumentValue(heightHint);
			_members.InstanceMethods.InvokeVirtualVoidMethod("fillMarginLayoutParams.(Landroid/view/View;Landroid/view/ViewGroup$MarginLayoutParams;II)V", this, ptr);
			GC.KeepAlive(view);
			GC.KeepAlive(parameters);
		}

		private static Delegate GetFillMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_IIHandler()
		{
			if ((object)cb_fillMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_II == null)
			{
				cb_fillMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_FillMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_II));
			}
			return cb_fillMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_II;
		}

		private static void n_FillMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_II(IntPtr jnienv, IntPtr native__this, IntPtr native_parameters, int widthHint, int heightHint)
		{
			PercentLayoutInfo percentLayoutInfo = Java.Lang.Object.GetObject<PercentLayoutInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup.MarginLayoutParams parameters = Java.Lang.Object.GetObject<ViewGroup.MarginLayoutParams>(native_parameters, JniHandleOwnership.DoNotTransfer);
			percentLayoutInfo.FillMarginLayoutParams(parameters, widthHint, heightHint);
		}

		[Register("fillMarginLayoutParams", "(Landroid/view/ViewGroup$MarginLayoutParams;II)V", "GetFillMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_IIHandler")]
		public unsafe virtual void FillMarginLayoutParams(ViewGroup.MarginLayoutParams parameters, int widthHint, int heightHint)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(widthHint);
			ptr[2] = new JniArgumentValue(heightHint);
			_members.InstanceMethods.InvokeVirtualVoidMethod("fillMarginLayoutParams.(Landroid/view/ViewGroup$MarginLayoutParams;II)V", this, ptr);
			GC.KeepAlive(parameters);
		}

		private static Delegate GetRestoreLayoutParams_Landroid_view_ViewGroup_LayoutParams_Handler()
		{
			if ((object)cb_restoreLayoutParams_Landroid_view_ViewGroup_LayoutParams_ == null)
			{
				cb_restoreLayoutParams_Landroid_view_ViewGroup_LayoutParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RestoreLayoutParams_Landroid_view_ViewGroup_LayoutParams_));
			}
			return cb_restoreLayoutParams_Landroid_view_ViewGroup_LayoutParams_;
		}

		private static void n_RestoreLayoutParams_Landroid_view_ViewGroup_LayoutParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_parameters)
		{
			PercentLayoutInfo percentLayoutInfo = Java.Lang.Object.GetObject<PercentLayoutInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup.LayoutParams parameters = Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(native_parameters, JniHandleOwnership.DoNotTransfer);
			percentLayoutInfo.RestoreLayoutParams(parameters);
		}

		[Register("restoreLayoutParams", "(Landroid/view/ViewGroup$LayoutParams;)V", "GetRestoreLayoutParams_Landroid_view_ViewGroup_LayoutParams_Handler")]
		public unsafe virtual void RestoreLayoutParams(ViewGroup.LayoutParams parameters)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("restoreLayoutParams.(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
			GC.KeepAlive(parameters);
		}

		private static Delegate GetRestoreMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_Handler()
		{
			if ((object)cb_restoreMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_ == null)
			{
				cb_restoreMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RestoreMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_));
			}
			return cb_restoreMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_;
		}

		private static void n_RestoreMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_parameters)
		{
			PercentLayoutInfo percentLayoutInfo = Java.Lang.Object.GetObject<PercentLayoutInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup.MarginLayoutParams parameters = Java.Lang.Object.GetObject<ViewGroup.MarginLayoutParams>(native_parameters, JniHandleOwnership.DoNotTransfer);
			percentLayoutInfo.RestoreMarginLayoutParams(parameters);
		}

		[Register("restoreMarginLayoutParams", "(Landroid/view/ViewGroup$MarginLayoutParams;)V", "GetRestoreMarginLayoutParams_Landroid_view_ViewGroup_MarginLayoutParams_Handler")]
		public unsafe virtual void RestoreMarginLayoutParams(ViewGroup.MarginLayoutParams parameters)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("restoreMarginLayoutParams.(Landroid/view/ViewGroup$MarginLayoutParams;)V", this, ptr);
			GC.KeepAlive(parameters);
		}
	}

	[Register("androidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutParams", "", "AndroidX.PercentLayout.Widget.PercentLayoutHelper/IPercentLayoutParamsInvoker")]
	public interface IPercentLayoutParams : IJavaObject, IDisposable, IJavaPeerable
	{
		PercentLayoutInfo PercentLayoutInfo
		{
			[Register("getPercentLayoutInfo", "()Landroidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutInfo;", "GetGetPercentLayoutInfoHandler:AndroidX.PercentLayout.Widget.PercentLayoutHelper/IPercentLayoutParamsInvoker, Xamarin.AndroidX.PercentLayout")]
			get;
		}
	}

	[Register("androidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutParams", DoNotGenerateAcw = true)]
	internal class IPercentLayoutParamsInvoker : Java.Lang.Object, IPercentLayoutParams, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutParams", typeof(IPercentLayoutParamsInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getPercentLayoutInfo;

		private IntPtr id_getPercentLayoutInfo;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public PercentLayoutInfo PercentLayoutInfo
		{
			get
			{
				if (id_getPercentLayoutInfo == IntPtr.Zero)
				{
					id_getPercentLayoutInfo = JNIEnv.GetMethodID(class_ref, "getPercentLayoutInfo", "()Landroidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutInfo;");
				}
				return Java.Lang.Object.GetObject<PercentLayoutInfo>(JNIEnv.CallObjectMethod(base.Handle, id_getPercentLayoutInfo), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IPercentLayoutParams GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPercentLayoutParams>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.percentlayout.widget.PercentLayoutHelper.PercentLayoutParams"));
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

		public IPercentLayoutParamsInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetPercentLayoutInfoHandler()
		{
			if ((object)cb_getPercentLayoutInfo == null)
			{
				cb_getPercentLayoutInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPercentLayoutInfo));
			}
			return cb_getPercentLayoutInfo;
		}

		private static IntPtr n_GetPercentLayoutInfo(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPercentLayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PercentLayoutInfo);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/percentlayout/widget/PercentLayoutHelper", typeof(PercentLayoutHelper));

	private static Delegate cb_adjustChildren_II;

	private static Delegate cb_handleMeasuredStateTooSmall;

	private static Delegate cb_restoreOriginalParams;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected PercentLayoutHelper(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/view/ViewGroup;)V", "")]
	public unsafe PercentLayoutHelper(ViewGroup host)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup;)V", this, ptr);
			GC.KeepAlive(host);
		}
	}

	private static Delegate GetAdjustChildren_IIHandler()
	{
		if ((object)cb_adjustChildren_II == null)
		{
			cb_adjustChildren_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_AdjustChildren_II));
		}
		return cb_adjustChildren_II;
	}

	private static void n_AdjustChildren_II(IntPtr jnienv, IntPtr native__this, int widthMeasureSpec, int heightMeasureSpec)
	{
		Java.Lang.Object.GetObject<PercentLayoutHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AdjustChildren(widthMeasureSpec, heightMeasureSpec);
	}

	[Register("adjustChildren", "(II)V", "GetAdjustChildren_IIHandler")]
	public unsafe virtual void AdjustChildren(int widthMeasureSpec, int heightMeasureSpec)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(widthMeasureSpec);
		ptr[1] = new JniArgumentValue(heightMeasureSpec);
		_members.InstanceMethods.InvokeVirtualVoidMethod("adjustChildren.(II)V", this, ptr);
	}

	[Register("fetchWidthAndHeight", "(Landroid/view/ViewGroup$LayoutParams;Landroid/content/res/TypedArray;II)V", "")]
	public unsafe static void FetchWidthAndHeight(ViewGroup.LayoutParams parameters, TypedArray array, int widthAttr, int heightAttr)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
		ptr[1] = new JniArgumentValue(array?.Handle ?? IntPtr.Zero);
		ptr[2] = new JniArgumentValue(widthAttr);
		ptr[3] = new JniArgumentValue(heightAttr);
		_members.StaticMethods.InvokeVoidMethod("fetchWidthAndHeight.(Landroid/view/ViewGroup$LayoutParams;Landroid/content/res/TypedArray;II)V", ptr);
		GC.KeepAlive(parameters);
		GC.KeepAlive(array);
	}

	[Register("getPercentLayoutInfo", "(Landroid/content/Context;Landroid/util/AttributeSet;)Landroidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutInfo;", "")]
	public unsafe static PercentLayoutInfo GetPercentLayoutInfo(Context context, IAttributeSet attrs)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
		ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
		PercentLayoutInfo result = Java.Lang.Object.GetObject<PercentLayoutInfo>(_members.StaticMethods.InvokeObjectMethod("getPercentLayoutInfo.(Landroid/content/Context;Landroid/util/AttributeSet;)Landroidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutInfo;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		GC.KeepAlive(context);
		GC.KeepAlive(attrs);
		return result;
	}

	private static Delegate GetHandleMeasuredStateTooSmallHandler()
	{
		if ((object)cb_handleMeasuredStateTooSmall == null)
		{
			cb_handleMeasuredStateTooSmall = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HandleMeasuredStateTooSmall));
		}
		return cb_handleMeasuredStateTooSmall;
	}

	private static bool n_HandleMeasuredStateTooSmall(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<PercentLayoutHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HandleMeasuredStateTooSmall();
	}

	[Register("handleMeasuredStateTooSmall", "()Z", "GetHandleMeasuredStateTooSmallHandler")]
	public unsafe virtual bool HandleMeasuredStateTooSmall()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("handleMeasuredStateTooSmall.()Z", this, null);
	}

	private static Delegate GetRestoreOriginalParamsHandler()
	{
		if ((object)cb_restoreOriginalParams == null)
		{
			cb_restoreOriginalParams = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RestoreOriginalParams));
		}
		return cb_restoreOriginalParams;
	}

	private static void n_RestoreOriginalParams(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<PercentLayoutHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RestoreOriginalParams();
	}

	[Register("restoreOriginalParams", "()V", "GetRestoreOriginalParamsHandler")]
	public unsafe virtual void RestoreOriginalParams()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("restoreOriginalParams.()V", this, null);
	}
}
[Register("androidx/percentlayout/widget/PercentRelativeLayout", DoNotGenerateAcw = true)]
public class PercentRelativeLayout : RelativeLayout
{
	[Register("androidx/percentlayout/widget/PercentRelativeLayout$LayoutParams", DoNotGenerateAcw = true)]
	public new class LayoutParams : RelativeLayout.LayoutParams, PercentLayoutHelper.IPercentLayoutParams, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/percentlayout/widget/PercentRelativeLayout$LayoutParams", typeof(LayoutParams));

		private static Delegate cb_getPercentLayoutInfo;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual PercentLayoutHelper.PercentLayoutInfo PercentLayoutInfo
		{
			[Register("getPercentLayoutInfo", "()Landroidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutInfo;", "GetGetPercentLayoutInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<PercentLayoutHelper.PercentLayoutInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPercentLayoutInfo.()Landroidx/percentlayout/widget/PercentLayoutHelper$PercentLayoutInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LayoutParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe LayoutParams(Context cValue, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(cValue?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
				GC.KeepAlive(cValue);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$LayoutParams;)V", "")]
		public unsafe LayoutParams(ViewGroup.LayoutParams source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$MarginLayoutParams;)V", "")]
		public unsafe LayoutParams(MarginLayoutParams source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", this, ptr);
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

		private static Delegate GetGetPercentLayoutInfoHandler()
		{
			if ((object)cb_getPercentLayoutInfo == null)
			{
				cb_getPercentLayoutInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPercentLayoutInfo));
			}
			return cb_getPercentLayoutInfo;
		}

		private static IntPtr n_GetPercentLayoutInfo(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PercentLayoutInfo);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/percentlayout/widget/PercentRelativeLayout", typeof(PercentRelativeLayout));

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected PercentRelativeLayout(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe PercentRelativeLayout(Context context)
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
	public unsafe PercentRelativeLayout(Context context, IAttributeSet attrs)
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
	public unsafe PercentRelativeLayout(Context context, IAttributeSet attrs, int defStyle)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}
}
