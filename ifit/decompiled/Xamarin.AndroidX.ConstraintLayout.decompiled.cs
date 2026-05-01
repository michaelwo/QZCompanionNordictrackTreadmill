using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Xml;
using Android;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using AndroidX.ConstraintLayout.Motion.Utils;
using AndroidX.ConstraintLayout.Motion.Widget;
using AndroidX.ConstraintLayout.Solver;
using AndroidX.ConstraintLayout.Solver.Widgets;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.View;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "7e7f264778d957d442c28296ca1e0fea70a60529")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20201215.1")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "12/15/2020 3:19:08 PM")]
[assembly: LinkerSafe]
[assembly: NamespaceMapping(Java = "androidx.constraintlayout.helper.widget", Managed = "AndroidX.ConstraintLayout.Helper.Widget")]
[assembly: NamespaceMapping(Java = "androidx.constraintlayout.motion.utils", Managed = "AndroidX.ConstraintLayout.Motion.Utils")]
[assembly: NamespaceMapping(Java = "androidx.constraintlayout.motion.widget", Managed = "AndroidX.ConstraintLayout.Motion.Widget")]
[assembly: NamespaceMapping(Java = "androidx.constraintlayout.utils.widget", Managed = "AndroidX.ConstraintLayout.Utils.Widget")]
[assembly: NamespaceMapping(Java = "androidx.constraintlayout.widget", Managed = "AndroidX.ConstraintLayout.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - constraintlayout")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.ConstraintLayout")]
[assembly: AssemblyTitle("Xamarin.AndroidX.ConstraintLayout")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate float _JniMarshal_PP_F(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate double _JniMarshal_PPDI_D(IntPtr jnienv, IntPtr klass, double p0, int p1);
internal delegate void _JniMarshal_PPDL_V(IntPtr jnienv, IntPtr klass, double p0, IntPtr p1);
internal delegate float _JniMarshal_PPF_F(IntPtr jnienv, IntPtr klass, float p0);
internal delegate void _JniMarshal_PPF_V(IntPtr jnienv, IntPtr klass, float p0);
internal delegate void _JniMarshal_PPFF_V(IntPtr jnienv, IntPtr klass, float p0, float p1);
internal delegate float _JniMarshal_PPI_F(IntPtr jnienv, IntPtr klass, int p0);
internal delegate int _JniMarshal_PPI_I(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate bool _JniMarshal_PPI_Z(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPIF_V(IntPtr jnienv, IntPtr klass, int p0, float p1);
internal delegate void _JniMarshal_PPIFF_V(IntPtr jnienv, IntPtr klass, int p0, float p1, float p2);
internal delegate bool _JniMarshal_PPIFF_Z(IntPtr jnienv, IntPtr klass, int p0, float p1, float p2);
internal delegate IntPtr _JniMarshal_PPIFFL_L(IntPtr jnienv, IntPtr klass, int p0, float p1, float p2, IntPtr p3);
internal delegate void _JniMarshal_PPII_V(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate void _JniMarshal_PPIIFJ_V(IntPtr jnienv, IntPtr klass, int p0, int p1, float p2, long p3);
internal delegate IntPtr _JniMarshal_PPIII_L(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2);
internal delegate void _JniMarshal_PPIII_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2);
internal delegate void _JniMarshal_PPIIIF_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, float p3);
internal delegate void _JniMarshal_PPIIII_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3);
internal delegate void _JniMarshal_PPIIIII_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3, int p4);
internal delegate void _JniMarshal_PPIIIIIIIF_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3, int p4, int p5, int p6, float p7);
internal delegate void _JniMarshal_PPIIIILLI_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3, IntPtr p4, IntPtr p5, int p6);
internal delegate void _JniMarshal_PPIIIIZZ_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3, bool p4, bool p5);
internal delegate void _JniMarshal_PPIIIL_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, IntPtr p3);
internal delegate int _JniMarshal_PPIL_I(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPIL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate void _JniMarshal_PPIL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate void _JniMarshal_PPILF_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, float p2);
internal delegate void _JniMarshal_PPILI_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, int p2);
internal delegate void _JniMarshal_PPILL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPILLL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate int _JniMarshal_PPILLLILI_I(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2, IntPtr p3, int p4, IntPtr p5, int p6);
internal delegate void _JniMarshal_PPIZ_V(IntPtr jnienv, IntPtr klass, int p0, bool p1);
internal delegate void _JniMarshal_PPIZF_V(IntPtr jnienv, IntPtr klass, int p0, bool p1, float p2);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLF_V(IntPtr jnienv, IntPtr klass, IntPtr p0, float p1);
internal delegate IntPtr _JniMarshal_PPLFF_L(IntPtr jnienv, IntPtr klass, IntPtr p0, float p1, float p2);
internal delegate void _JniMarshal_PPLFFLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, float p1, float p2, IntPtr p3, int p4);
internal delegate float _JniMarshal_PPLI_F(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate float _JniMarshal_PPLIFF_F(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, float p2, float p3);
internal delegate IntPtr _JniMarshal_PPLII_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate void _JniMarshal_PPLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate void _JniMarshal_PPLIIF_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, float p3);
internal delegate bool _JniMarshal_PPLIIFF_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, float p3, float p4);
internal delegate void _JniMarshal_PPLIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3);
internal delegate void _JniMarshal_PPLIIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, int p4);
internal delegate void _JniMarshal_PPLIIIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, int p4, int p5);
internal delegate void _JniMarshal_PPLIIIIIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, int p4, int p5, IntPtr p6);
internal delegate void _JniMarshal_PPLIILI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, IntPtr p3, int p4);
internal delegate int _JniMarshal_PPLIL_I(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate void _JniMarshal_PPLIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate void _JniMarshal_PPLILL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2, IntPtr p3);
internal delegate void _JniMarshal_PPLIZF_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, bool p2, float p3);
internal delegate int _JniMarshal_PPLL_I(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLLFFLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, float p2, float p3, IntPtr p4, IntPtr p5);
internal delegate int _JniMarshal_PPLLI_I(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2);
internal delegate void _JniMarshal_PPLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate bool _JniMarshal_PPLLII_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate int _JniMarshal_PPLLL_I(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate void _JniMarshal_PPLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
internal delegate void _JniMarshal_PPZIIII_V(IntPtr jnienv, IntPtr klass, bool p0, int p1, int p2, int p3, int p4);
internal delegate void _JniMarshal_PPZLLLL_V(IntPtr jnienv, IntPtr klass, bool p0, IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4);
namespace AndroidX.ConstraintLayout.Widget
{
	[Register("androidx/constraintlayout/widget/ConstraintAttribute", DoNotGenerateAcw = true)]
	public class ConstraintAttribute : Java.Lang.Object
	{
		[Register("androidx/constraintlayout/widget/ConstraintAttribute$AttributeType", DoNotGenerateAcw = true)]
		public sealed class AttributeType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintAttribute$AttributeType", typeof(AttributeType));

			[Register("BOOLEAN_TYPE")]
			public static AttributeType BooleanType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("BOOLEAN_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("COLOR_DRAWABLE_TYPE")]
			public static AttributeType ColorDrawableType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("COLOR_DRAWABLE_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("COLOR_TYPE")]
			public static AttributeType ColorType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("COLOR_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("DIMENSION_TYPE")]
			public static AttributeType DimensionType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("DIMENSION_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("FLOAT_TYPE")]
			public static AttributeType FloatType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("FLOAT_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("INT_TYPE")]
			public static AttributeType IntType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("INT_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("STRING_TYPE")]
			public static AttributeType StringType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("STRING_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			internal AttributeType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", "")]
			public unsafe static AttributeType ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<AttributeType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", "")]
			public unsafe static AttributeType[] Values()
			{
				return (AttributeType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AttributeType));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintAttribute", typeof(ConstraintAttribute));

		private static Delegate cb_getType;

		private static Delegate cb_getValueToInterpolate;

		private static Delegate cb_diff_Landroidx_constraintlayout_widget_ConstraintAttribute_;

		private static Delegate cb_getValuesToInterpolate_arrayF;

		private static Delegate cb_noOfInterpValues;

		private static Delegate cb_setColorValue_I;

		private static Delegate cb_setFloatValue_F;

		private static Delegate cb_setIntValue_I;

		private static Delegate cb_setInterpolatedValue_Landroid_view_View_arrayF;

		private static Delegate cb_setStringValue_Ljava_lang_String_;

		private static Delegate cb_setValue_arrayF;

		private static Delegate cb_setValue_Ljava_lang_Object_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual AttributeType Type
		{
			[Register("getType", "()Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", "GetGetTypeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<AttributeType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual float ValueToInterpolate
		{
			[Register("getValueToInterpolate", "()F", "GetGetValueToInterpolateHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getValueToInterpolate.()F", this, null);
			}
		}

		protected ConstraintAttribute(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/widget/ConstraintAttribute;Ljava/lang/Object;)V", "")]
		public unsafe ConstraintAttribute(ConstraintAttribute source, Java.Lang.Object value)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/widget/ConstraintAttribute;Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/widget/ConstraintAttribute;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
				GC.KeepAlive(value);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;)V", "")]
		public unsafe ConstraintAttribute(string name, AttributeType attributeType)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(attributeType?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(attributeType);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;Ljava/lang/Object;)V", "")]
		public unsafe ConstraintAttribute(string name, AttributeType attributeType, Java.Lang.Object value)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(attributeType?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(attributeType);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetGetTypeHandler()
		{
			if ((object)cb_getType == null)
			{
				cb_getType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetType));
			}
			return cb_getType;
		}

		private static IntPtr n_GetType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type);
		}

		private static Delegate GetGetValueToInterpolateHandler()
		{
			if ((object)cb_getValueToInterpolate == null)
			{
				cb_getValueToInterpolate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetValueToInterpolate));
			}
			return cb_getValueToInterpolate;
		}

		private static float n_GetValueToInterpolate(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueToInterpolate;
		}

		private static Delegate GetDiff_Landroidx_constraintlayout_widget_ConstraintAttribute_Handler()
		{
			if ((object)cb_diff_Landroidx_constraintlayout_widget_ConstraintAttribute_ == null)
			{
				cb_diff_Landroidx_constraintlayout_widget_ConstraintAttribute_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Diff_Landroidx_constraintlayout_widget_ConstraintAttribute_));
			}
			return cb_diff_Landroidx_constraintlayout_widget_ConstraintAttribute_;
		}

		private static bool n_Diff_Landroidx_constraintlayout_widget_ConstraintAttribute_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraintAttribute)
		{
			ConstraintAttribute constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAttribute constraintAttribute2 = Java.Lang.Object.GetObject<ConstraintAttribute>(native_constraintAttribute, JniHandleOwnership.DoNotTransfer);
			return constraintAttribute.Diff(constraintAttribute2);
		}

		[Register("diff", "(Landroidx/constraintlayout/widget/ConstraintAttribute;)Z", "GetDiff_Landroidx_constraintlayout_widget_ConstraintAttribute_Handler")]
		public unsafe virtual bool Diff(ConstraintAttribute constraintAttribute)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constraintAttribute?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("diff.(Landroidx/constraintlayout/widget/ConstraintAttribute;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintAttribute);
			}
		}

		[Register("extractAttributes", "(Ljava/util/HashMap;Landroid/view/View;)Ljava/util/HashMap;", "")]
		public unsafe static IDictionary<string, ConstraintAttribute> ExtractAttributes(IDictionary<string, ConstraintAttribute> @base, View view)
		{
			IntPtr intPtr = JavaDictionary<string, ConstraintAttribute>.ToLocalJniHandle(@base);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return JavaDictionary<string, ConstraintAttribute>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("extractAttributes.(Ljava/util/HashMap;Landroid/view/View;)Ljava/util/HashMap;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@base);
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetGetValuesToInterpolate_arrayFHandler()
		{
			if ((object)cb_getValuesToInterpolate_arrayF == null)
			{
				cb_getValuesToInterpolate_arrayF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_GetValuesToInterpolate_arrayF));
			}
			return cb_getValuesToInterpolate_arrayF;
		}

		private static void n_GetValuesToInterpolate_arrayF(IntPtr jnienv, IntPtr native__this, IntPtr native_ret)
		{
			ConstraintAttribute constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_ret, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintAttribute.GetValuesToInterpolate(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_ret);
			}
		}

		[Register("getValuesToInterpolate", "([F)V", "GetGetValuesToInterpolate_arrayFHandler")]
		public unsafe virtual void GetValuesToInterpolate(float[] ret)
		{
			IntPtr intPtr = JNIEnv.NewArray(ret);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getValuesToInterpolate.([F)V", this, ptr);
			}
			finally
			{
				if (ret != null)
				{
					JNIEnv.CopyArray(intPtr, ret);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(ret);
			}
		}

		private static Delegate GetNoOfInterpValuesHandler()
		{
			if ((object)cb_noOfInterpValues == null)
			{
				cb_noOfInterpValues = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_NoOfInterpValues));
			}
			return cb_noOfInterpValues;
		}

		private static int n_NoOfInterpValues(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NoOfInterpValues();
		}

		[Register("noOfInterpValues", "()I", "GetNoOfInterpValuesHandler")]
		public unsafe virtual int NoOfInterpValues()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("noOfInterpValues.()I", this, null);
		}

		[Register("parse", "(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;Ljava/util/HashMap;)V", "")]
		public unsafe static void Parse(Context context, XmlReader parser, IDictionary<string, ConstraintAttribute> custom)
		{
			IntPtr intPtr = XmlReaderPullParser.ToLocalJniHandle(parser);
			IntPtr intPtr2 = JavaDictionary<string, ConstraintAttribute>.ToLocalJniHandle(custom);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("parse.(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;Ljava/util/HashMap;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
				GC.KeepAlive(parser);
				GC.KeepAlive(custom);
			}
		}

		[Register("setAttributes", "(Landroid/view/View;Ljava/util/HashMap;)V", "")]
		public unsafe static void SetAttributes(View view, IDictionary<string, ConstraintAttribute> map)
		{
			IntPtr intPtr = JavaDictionary<string, ConstraintAttribute>.ToLocalJniHandle(map);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("setAttributes.(Landroid/view/View;Ljava/util/HashMap;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(view);
				GC.KeepAlive(map);
			}
		}

		private static Delegate GetSetColorValue_IHandler()
		{
			if ((object)cb_setColorValue_I == null)
			{
				cb_setColorValue_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetColorValue_I));
			}
			return cb_setColorValue_I;
		}

		private static void n_SetColorValue_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetColorValue(value);
		}

		[Register("setColorValue", "(I)V", "GetSetColorValue_IHandler")]
		public unsafe virtual void SetColorValue(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColorValue.(I)V", this, ptr);
		}

		private static Delegate GetSetFloatValue_FHandler()
		{
			if ((object)cb_setFloatValue_F == null)
			{
				cb_setFloatValue_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetFloatValue_F));
			}
			return cb_setFloatValue_F;
		}

		private static void n_SetFloatValue_F(IntPtr jnienv, IntPtr native__this, float value)
		{
			Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFloatValue(value);
		}

		[Register("setFloatValue", "(F)V", "GetSetFloatValue_FHandler")]
		public unsafe virtual void SetFloatValue(float value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFloatValue.(F)V", this, ptr);
		}

		private static Delegate GetSetIntValue_IHandler()
		{
			if ((object)cb_setIntValue_I == null)
			{
				cb_setIntValue_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetIntValue_I));
			}
			return cb_setIntValue_I;
		}

		private static void n_SetIntValue_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIntValue(value);
		}

		[Register("setIntValue", "(I)V", "GetSetIntValue_IHandler")]
		public unsafe virtual void SetIntValue(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIntValue.(I)V", this, ptr);
		}

		private static Delegate GetSetInterpolatedValue_Landroid_view_View_arrayFHandler()
		{
			if ((object)cb_setInterpolatedValue_Landroid_view_View_arrayF == null)
			{
				cb_setInterpolatedValue_Landroid_view_View_arrayF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetInterpolatedValue_Landroid_view_View_arrayF));
			}
			return cb_setInterpolatedValue_Landroid_view_View_arrayF;
		}

		private static void n_SetInterpolatedValue_Landroid_view_View_arrayF(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_value)
		{
			ConstraintAttribute constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintAttribute.SetInterpolatedValue(view, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_value);
			}
		}

		[Register("setInterpolatedValue", "(Landroid/view/View;[F)V", "GetSetInterpolatedValue_Landroid_view_View_arrayFHandler")]
		public unsafe virtual void SetInterpolatedValue(View view, float[] value)
		{
			IntPtr intPtr = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolatedValue.(Landroid/view/View;[F)V", this, ptr);
			}
			finally
			{
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr, value);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(view);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetSetStringValue_Ljava_lang_String_Handler()
		{
			if ((object)cb_setStringValue_Ljava_lang_String_ == null)
			{
				cb_setStringValue_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetStringValue_Ljava_lang_String_));
			}
			return cb_setStringValue_Ljava_lang_String_;
		}

		private static void n_SetStringValue_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			ConstraintAttribute constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string stringValue = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			constraintAttribute.SetStringValue(stringValue);
		}

		[Register("setStringValue", "(Ljava/lang/String;)V", "GetSetStringValue_Ljava_lang_String_Handler")]
		public unsafe virtual void SetStringValue(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStringValue.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetValue_arrayFHandler()
		{
			if ((object)cb_setValue_arrayF == null)
			{
				cb_setValue_arrayF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetValue_arrayF));
			}
			return cb_setValue_arrayF;
		}

		private static void n_SetValue_arrayF(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			ConstraintAttribute constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintAttribute.SetValue(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_value);
			}
		}

		[Register("setValue", "([F)V", "GetSetValue_arrayFHandler")]
		public unsafe virtual void SetValue(float[] value)
		{
			IntPtr intPtr = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setValue.([F)V", this, ptr);
			}
			finally
			{
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr, value);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetSetValue_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setValue_Ljava_lang_Object_ == null)
			{
				cb_setValue_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetValue_Ljava_lang_Object_));
			}
			return cb_setValue_Ljava_lang_Object_;
		}

		private static void n_SetValue_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			ConstraintAttribute constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			constraintAttribute.SetValue(value);
		}

		[Register("setValue", "(Ljava/lang/Object;)V", "GetSetValue_Ljava_lang_Object_Handler")]
		public unsafe virtual void SetValue(Java.Lang.Object value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setValue.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}
	[Register("androidx/constraintlayout/widget/ConstraintHelper", DoNotGenerateAcw = true)]
	public abstract class ConstraintHelper : View
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintHelper", typeof(ConstraintHelper));

		private static Delegate cb_addView_Landroid_view_View_;

		private static Delegate cb_applyLayoutFeatures;

		private static Delegate cb_applyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_getReferencedIds;

		private static Delegate cb_getViews_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_init_Landroid_util_AttributeSet_;

		private static Delegate cb_loadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_solver_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_;

		private static Delegate cb_onDraw_Landroid_graphics_Canvas_;

		private static Delegate cb_removeView_Landroid_view_View_;

		private static Delegate cb_resolveRtl_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Z;

		private static Delegate cb_setIds_Ljava_lang_String_;

		private static Delegate cb_setReferenceTags_Ljava_lang_String_;

		private static Delegate cb_setReferencedIds_arrayI;

		private static Delegate cb_updatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_updatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_updatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_updatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_updatePreLayout_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_widgets_Helper_Landroid_util_SparseArray_;

		private static Delegate cb_updatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_validateParams;

		[Register("mCount")]
		protected int MCount
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mCount.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mCount.I", this, value);
			}
		}

		[Register("mHelperWidget")]
		protected IHelper MHelperWidget
		{
			get
			{
				return Java.Lang.Object.GetObject<IHelper>(_members.InstanceFields.GetObjectValue("mHelperWidget.Landroidx/constraintlayout/solver/widgets/Helper;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mHelperWidget.Landroidx/constraintlayout/solver/widgets/Helper;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mIds")]
		protected IList<int> MIds
		{
			get
			{
				return Android.Runtime.JavaArray<int>.FromJniHandle(_members.InstanceFields.GetObjectValue("mIds.[I", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<int>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mIds.[I", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mReferenceIds")]
		protected string MReferenceIds
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mReferenceIds.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("mReferenceIds.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mReferenceTags")]
		protected string MReferenceTags
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mReferenceTags.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("mReferenceTags.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mUseViewMeasure")]
		protected bool MUseViewMeasure
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mUseViewMeasure.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mUseViewMeasure.Z", this, value);
			}
		}

		[Register("myContext")]
		protected Context MyContext
		{
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceFields.GetObjectValue("myContext.Landroid/content/Context;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("myContext.Landroid/content/Context;", this, new JniObjectReference(jobject));
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

		protected ConstraintHelper(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe ConstraintHelper(Context context)
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
		public unsafe ConstraintHelper(Context context, IAttributeSet attrs)
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
		public unsafe ConstraintHelper(Context context, IAttributeSet attrs, int defStyleAttr)
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

		private static Delegate GetAddView_Landroid_view_View_Handler()
		{
			if ((object)cb_addView_Landroid_view_View_ == null)
			{
				cb_addView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddView_Landroid_view_View_));
			}
			return cb_addView_Landroid_view_View_;
		}

		private static void n_AddView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			constraintHelper.AddView(view);
		}

		[Register("addView", "(Landroid/view/View;)V", "GetAddView_Landroid_view_View_Handler")]
		public unsafe virtual void AddView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetApplyLayoutFeaturesHandler()
		{
			if ((object)cb_applyLayoutFeatures == null)
			{
				cb_applyLayoutFeatures = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ApplyLayoutFeatures));
			}
			return cb_applyLayoutFeatures;
		}

		private static void n_ApplyLayoutFeatures(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplyLayoutFeatures();
		}

		[Register("applyLayoutFeatures", "()V", "GetApplyLayoutFeaturesHandler")]
		protected unsafe virtual void ApplyLayoutFeatures()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyLayoutFeatures.()V", this, null);
		}

		private static Delegate GetApplyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_applyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_applyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ApplyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_applyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_ApplyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.ApplyLayoutFeatures(container);
		}

		[Register("applyLayoutFeatures", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetApplyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		protected unsafe virtual void ApplyLayoutFeatures(ConstraintLayout container)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("applyLayoutFeatures.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetGetReferencedIdsHandler()
		{
			if ((object)cb_getReferencedIds == null)
			{
				cb_getReferencedIds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetReferencedIds));
			}
			return cb_getReferencedIds;
		}

		private static IntPtr n_GetReferencedIds(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetReferencedIds());
		}

		[Register("getReferencedIds", "()[I", "GetGetReferencedIdsHandler")]
		public unsafe virtual int[] GetReferencedIds()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getReferencedIds.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		private static Delegate GetGetViews_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_getViews_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_getViews_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetViews_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_getViews_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static IntPtr n_GetViews_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_layout)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout layout = Java.Lang.Object.GetObject<ConstraintLayout>(native_layout, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(constraintHelper.GetViews(layout));
		}

		[Register("getViews", "(Landroidx/constraintlayout/widget/ConstraintLayout;)[Landroid/view/View;", "GetGetViews_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		protected unsafe virtual View[] GetViews(ConstraintLayout layout)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
				return (View[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getViews.(Landroidx/constraintlayout/widget/ConstraintLayout;)[Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(View));
			}
			finally
			{
				GC.KeepAlive(layout);
			}
		}

		private static Delegate GetInit_Landroid_util_AttributeSet_Handler()
		{
			if ((object)cb_init_Landroid_util_AttributeSet_ == null)
			{
				cb_init_Landroid_util_AttributeSet_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Init_Landroid_util_AttributeSet_));
			}
			return cb_init_Landroid_util_AttributeSet_;
		}

		private static void n_Init_Landroid_util_AttributeSet_(IntPtr jnienv, IntPtr native__this, IntPtr native_attrs)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
			constraintHelper.Init(attrs);
		}

		[Register("init", "(Landroid/util/AttributeSet;)V", "GetInit_Landroid_util_AttributeSet_Handler")]
		protected unsafe virtual void Init(IAttributeSet attrs)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("init.(Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetLoadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_solver_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler()
		{
			if ((object)cb_loadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_solver_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_ == null)
			{
				cb_loadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_solver_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_LoadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_solver_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_));
			}
			return cb_loadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_solver_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_;
		}

		private static void n_LoadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_solver_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraint, IntPtr native_child, IntPtr native_layoutParams, IntPtr native_mapIdToWidget)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet.Constraint constraint = Java.Lang.Object.GetObject<ConstraintSet.Constraint>(native_constraint, JniHandleOwnership.DoNotTransfer);
			HelperWidget child = Java.Lang.Object.GetObject<HelperWidget>(native_child, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout.LayoutParams layoutParams = Java.Lang.Object.GetObject<ConstraintLayout.LayoutParams>(native_layoutParams, JniHandleOwnership.DoNotTransfer);
			SparseArray mapIdToWidget = Java.Lang.Object.GetObject<SparseArray>(native_mapIdToWidget, JniHandleOwnership.DoNotTransfer);
			constraintHelper.LoadParameters(constraint, child, layoutParams, mapIdToWidget);
		}

		[Register("loadParameters", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Landroidx/constraintlayout/solver/widgets/HelperWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", "GetLoadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_solver_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler")]
		public unsafe virtual void LoadParameters(ConstraintSet.Constraint constraint, HelperWidget child, ConstraintLayout.LayoutParams layoutParams, SparseArray mapIdToWidget)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(constraint?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(layoutParams?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(mapIdToWidget?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("loadParameters.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Landroidx/constraintlayout/solver/widgets/HelperWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraint);
				GC.KeepAlive(child);
				GC.KeepAlive(layoutParams);
				GC.KeepAlive(mapIdToWidget);
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

		private static void n_OnDraw_Landroid_graphics_Canvas_(IntPtr jnienv, IntPtr native__this, IntPtr native_canvas)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			constraintHelper.OnDraw(canvas);
		}

		[Register("onDraw", "(Landroid/graphics/Canvas;)V", "GetOnDraw_Landroid_graphics_Canvas_Handler")]
		public new unsafe virtual void OnDraw(Canvas canvas)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(canvas);
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

		private static void n_RemoveView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			constraintHelper.RemoveView(view);
		}

		[Register("removeView", "(Landroid/view/View;)V", "GetRemoveView_Landroid_view_View_Handler")]
		public unsafe virtual void RemoveView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetResolveRtl_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ZHandler()
		{
			if ((object)cb_resolveRtl_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Z == null)
			{
				cb_resolveRtl_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_ResolveRtl_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Z));
			}
			return cb_resolveRtl_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Z;
		}

		private static void n_ResolveRtl_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_widget, bool isRtl)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			constraintHelper.ResolveRtl(widget, isRtl);
		}

		[Register("resolveRtl", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Z)V", "GetResolveRtl_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ZHandler")]
		public unsafe virtual void ResolveRtl(ConstraintWidget widget, bool isRtl)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(isRtl);
				_members.InstanceMethods.InvokeVirtualVoidMethod("resolveRtl.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
			}
		}

		private static Delegate GetSetIds_Ljava_lang_String_Handler()
		{
			if ((object)cb_setIds_Ljava_lang_String_ == null)
			{
				cb_setIds_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetIds_Ljava_lang_String_));
			}
			return cb_setIds_Ljava_lang_String_;
		}

		private static void n_SetIds_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_idList)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string ids = JNIEnv.GetString(native_idList, JniHandleOwnership.DoNotTransfer);
			constraintHelper.SetIds(ids);
		}

		[Register("setIds", "(Ljava/lang/String;)V", "GetSetIds_Ljava_lang_String_Handler")]
		protected unsafe virtual void SetIds(string idList)
		{
			IntPtr intPtr = JNIEnv.NewString(idList);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIds.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetReferenceTags_Ljava_lang_String_Handler()
		{
			if ((object)cb_setReferenceTags_Ljava_lang_String_ == null)
			{
				cb_setReferenceTags_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetReferenceTags_Ljava_lang_String_));
			}
			return cb_setReferenceTags_Ljava_lang_String_;
		}

		private static void n_SetReferenceTags_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_tagList)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string referenceTags = JNIEnv.GetString(native_tagList, JniHandleOwnership.DoNotTransfer);
			constraintHelper.SetReferenceTags(referenceTags);
		}

		[Register("setReferenceTags", "(Ljava/lang/String;)V", "GetSetReferenceTags_Ljava_lang_String_Handler")]
		protected unsafe virtual void SetReferenceTags(string tagList)
		{
			IntPtr intPtr = JNIEnv.NewString(tagList);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setReferenceTags.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetReferencedIds_arrayIHandler()
		{
			if ((object)cb_setReferencedIds_arrayI == null)
			{
				cb_setReferencedIds_arrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetReferencedIds_arrayI));
			}
			return cb_setReferencedIds_arrayI;
		}

		private static void n_SetReferencedIds_arrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_ids)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_ids, JniHandleOwnership.DoNotTransfer, typeof(int));
			constraintHelper.SetReferencedIds(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_ids);
			}
		}

		[Register("setReferencedIds", "([I)V", "GetSetReferencedIds_arrayIHandler")]
		public unsafe virtual void SetReferencedIds(int[] ids)
		{
			IntPtr intPtr = JNIEnv.NewArray(ids);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setReferencedIds.([I)V", this, ptr);
			}
			finally
			{
				if (ids != null)
				{
					JNIEnv.CopyArray(intPtr, ids);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(ids);
			}
		}

		private static Delegate GetUpdatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_updatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_updatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_updatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_UpdatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_constainer)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constainer = Java.Lang.Object.GetObject<ConstraintLayout>(native_constainer, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePostConstraints(constainer);
		}

		[Register("updatePostConstraints", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetUpdatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		public unsafe virtual void UpdatePostConstraints(ConstraintLayout constainer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constainer?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updatePostConstraints.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constainer);
			}
		}

		private static Delegate GetUpdatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_updatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_updatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_updatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_UpdatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePostLayout(container);
		}

		[Register("updatePostLayout", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetUpdatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		public unsafe virtual void UpdatePostLayout(ConstraintLayout container)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updatePostLayout.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetUpdatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_updatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_updatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_updatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_UpdatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePostMeasure(container);
		}

		[Register("updatePostMeasure", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetUpdatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		public unsafe virtual void UpdatePostMeasure(ConstraintLayout container)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updatePostMeasure.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetUpdatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_updatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_updatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_updatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_UpdatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePreDraw(container);
		}

		[Register("updatePreDraw", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetUpdatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		public unsafe virtual void UpdatePreDraw(ConstraintLayout container)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updatePreDraw.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetUpdatePreLayout_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_widgets_Helper_Landroid_util_SparseArray_Handler()
		{
			if ((object)cb_updatePreLayout_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_widgets_Helper_Landroid_util_SparseArray_ == null)
			{
				cb_updatePreLayout_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_widgets_Helper_Landroid_util_SparseArray_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_UpdatePreLayout_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_widgets_Helper_Landroid_util_SparseArray_));
			}
			return cb_updatePreLayout_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_widgets_Helper_Landroid_util_SparseArray_;
		}

		private static void n_UpdatePreLayout_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_widgets_Helper_Landroid_util_SparseArray_(IntPtr jnienv, IntPtr native__this, IntPtr native_container, IntPtr native_helper, IntPtr native_map)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer container = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_container, JniHandleOwnership.DoNotTransfer);
			IHelper helper = Java.Lang.Object.GetObject<IHelper>(native_helper, JniHandleOwnership.DoNotTransfer);
			SparseArray map = Java.Lang.Object.GetObject<SparseArray>(native_map, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePreLayout(container, helper, map);
		}

		[Register("updatePreLayout", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;Landroidx/constraintlayout/solver/widgets/Helper;Landroid/util/SparseArray;)V", "GetUpdatePreLayout_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_widgets_Helper_Landroid_util_SparseArray_Handler")]
		public unsafe virtual void UpdatePreLayout(ConstraintWidgetContainer container, IHelper helper, SparseArray map)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((helper == null) ? IntPtr.Zero : ((Java.Lang.Object)helper).Handle);
				ptr[2] = new JniArgumentValue(map?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updatePreLayout.(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;Landroidx/constraintlayout/solver/widgets/Helper;Landroid/util/SparseArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
				GC.KeepAlive(helper);
				GC.KeepAlive(map);
			}
		}

		private static Delegate GetUpdatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_updatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_updatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_updatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_UpdatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			ConstraintHelper constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePreLayout(container);
		}

		[Register("updatePreLayout", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetUpdatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		public unsafe virtual void UpdatePreLayout(ConstraintLayout container)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updatePreLayout.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetValidateParamsHandler()
		{
			if ((object)cb_validateParams == null)
			{
				cb_validateParams = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ValidateParams));
			}
			return cb_validateParams;
		}

		private static void n_ValidateParams(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValidateParams();
		}

		[Register("validateParams", "()V", "GetValidateParamsHandler")]
		public unsafe virtual void ValidateParams()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("validateParams.()V", this, null);
		}
	}
	[Register("androidx/constraintlayout/widget/ConstraintHelper", DoNotGenerateAcw = true)]
	internal class ConstraintHelperInvoker : ConstraintHelper
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintHelper", typeof(ConstraintHelperInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public ConstraintHelperInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("androidx/constraintlayout/widget/ConstraintLayout", DoNotGenerateAcw = true)]
	public class ConstraintLayout : ViewGroup
	{
		[Register("androidx/constraintlayout/widget/ConstraintLayout$LayoutParams", DoNotGenerateAcw = true)]
		public new class LayoutParams : MarginLayoutParams
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintLayout$LayoutParams", typeof(LayoutParams));

			private static Delegate cb_getConstraintTag;

			private static Delegate cb_getConstraintWidget;

			private static Delegate cb_reset;

			private static Delegate cb_setWidgetDebugName_Ljava_lang_String_;

			private static Delegate cb_validate;

			[Register("baselineToBaseline")]
			public int BaselineToBaseline
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("baselineToBaseline.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("baselineToBaseline.I", this, value);
				}
			}

			[Register("bottomToBottom")]
			public int BottomToBottom
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("bottomToBottom.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("bottomToBottom.I", this, value);
				}
			}

			[Register("bottomToTop")]
			public int BottomToTop
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("bottomToTop.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("bottomToTop.I", this, value);
				}
			}

			[Register("circleAngle")]
			public float CircleAngle
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("circleAngle.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("circleAngle.F", this, value);
				}
			}

			[Register("circleConstraint")]
			public int CircleConstraint
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("circleConstraint.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("circleConstraint.I", this, value);
				}
			}

			[Register("circleRadius")]
			public int CircleRadius
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("circleRadius.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("circleRadius.I", this, value);
				}
			}

			[Register("constrainedHeight")]
			public bool ConstrainedHeight
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("constrainedHeight.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("constrainedHeight.Z", this, value);
				}
			}

			[Register("constrainedWidth")]
			public bool ConstrainedWidth
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("constrainedWidth.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("constrainedWidth.Z", this, value);
				}
			}

			[Register("dimensionRatio")]
			public string DimensionRatio
			{
				get
				{
					return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("dimensionRatio.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.NewString(value);
					try
					{
						_members.InstanceFields.SetValue("dimensionRatio.Ljava/lang/String;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("editorAbsoluteX")]
			public int EditorAbsoluteX
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("editorAbsoluteX.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("editorAbsoluteX.I", this, value);
				}
			}

			[Register("editorAbsoluteY")]
			public int EditorAbsoluteY
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("editorAbsoluteY.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("editorAbsoluteY.I", this, value);
				}
			}

			[Register("endToEnd")]
			public int EndToEnd
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("endToEnd.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("endToEnd.I", this, value);
				}
			}

			[Register("endToStart")]
			public int EndToStart
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("endToStart.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("endToStart.I", this, value);
				}
			}

			[Register("goneBottomMargin")]
			public int GoneBottomMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneBottomMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneBottomMargin.I", this, value);
				}
			}

			[Register("goneEndMargin")]
			public int GoneEndMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneEndMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneEndMargin.I", this, value);
				}
			}

			[Register("goneLeftMargin")]
			public int GoneLeftMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneLeftMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneLeftMargin.I", this, value);
				}
			}

			[Register("goneRightMargin")]
			public int GoneRightMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneRightMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneRightMargin.I", this, value);
				}
			}

			[Register("goneStartMargin")]
			public int GoneStartMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneStartMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneStartMargin.I", this, value);
				}
			}

			[Register("goneTopMargin")]
			public int GoneTopMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneTopMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneTopMargin.I", this, value);
				}
			}

			[Register("guideBegin")]
			public int GuideBegin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("guideBegin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("guideBegin.I", this, value);
				}
			}

			[Register("guideEnd")]
			public int GuideEnd
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("guideEnd.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("guideEnd.I", this, value);
				}
			}

			[Register("guidePercent")]
			public float GuidePercent
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("guidePercent.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("guidePercent.F", this, value);
				}
			}

			[Register("helped")]
			public bool Helped
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("helped.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("helped.Z", this, value);
				}
			}

			[Register("horizontalBias")]
			public float HorizontalBias
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("horizontalBias.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("horizontalBias.F", this, value);
				}
			}

			[Register("horizontalChainStyle")]
			public int HorizontalChainStyle
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("horizontalChainStyle.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("horizontalChainStyle.I", this, value);
				}
			}

			[Register("horizontalWeight")]
			public float HorizontalWeight
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("horizontalWeight.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("horizontalWeight.F", this, value);
				}
			}

			[Register("leftToLeft")]
			public int LeftToLeft
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("leftToLeft.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("leftToLeft.I", this, value);
				}
			}

			[Register("leftToRight")]
			public int LeftToRight
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("leftToRight.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("leftToRight.I", this, value);
				}
			}

			[Register("matchConstraintDefaultHeight")]
			public int MatchConstraintDefaultHeight
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("matchConstraintDefaultHeight.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("matchConstraintDefaultHeight.I", this, value);
				}
			}

			[Register("matchConstraintDefaultWidth")]
			public int MatchConstraintDefaultWidth
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("matchConstraintDefaultWidth.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("matchConstraintDefaultWidth.I", this, value);
				}
			}

			[Register("matchConstraintMaxHeight")]
			public int MatchConstraintMaxHeight
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("matchConstraintMaxHeight.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("matchConstraintMaxHeight.I", this, value);
				}
			}

			[Register("matchConstraintMaxWidth")]
			public int MatchConstraintMaxWidth
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("matchConstraintMaxWidth.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("matchConstraintMaxWidth.I", this, value);
				}
			}

			[Register("matchConstraintMinHeight")]
			public int MatchConstraintMinHeight
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("matchConstraintMinHeight.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("matchConstraintMinHeight.I", this, value);
				}
			}

			[Register("matchConstraintMinWidth")]
			public int MatchConstraintMinWidth
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("matchConstraintMinWidth.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("matchConstraintMinWidth.I", this, value);
				}
			}

			[Register("matchConstraintPercentHeight")]
			public float MatchConstraintPercentHeight
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("matchConstraintPercentHeight.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("matchConstraintPercentHeight.F", this, value);
				}
			}

			[Register("matchConstraintPercentWidth")]
			public float MatchConstraintPercentWidth
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("matchConstraintPercentWidth.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("matchConstraintPercentWidth.F", this, value);
				}
			}

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

			[Register("rightToLeft")]
			public int RightToLeft
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("rightToLeft.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("rightToLeft.I", this, value);
				}
			}

			[Register("rightToRight")]
			public int RightToRight
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("rightToRight.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("rightToRight.I", this, value);
				}
			}

			[Register("startToEnd")]
			public int StartToEnd
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("startToEnd.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("startToEnd.I", this, value);
				}
			}

			[Register("startToStart")]
			public int StartToStart
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("startToStart.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("startToStart.I", this, value);
				}
			}

			[Register("topToBottom")]
			public int TopToBottom
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("topToBottom.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("topToBottom.I", this, value);
				}
			}

			[Register("topToTop")]
			public int TopToTop
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("topToTop.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("topToTop.I", this, value);
				}
			}

			[Register("verticalBias")]
			public float VerticalBias
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("verticalBias.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("verticalBias.F", this, value);
				}
			}

			[Register("verticalChainStyle")]
			public int VerticalChainStyle
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("verticalChainStyle.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("verticalChainStyle.I", this, value);
				}
			}

			[Register("verticalWeight")]
			public float VerticalWeight
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("verticalWeight.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("verticalWeight.F", this, value);
				}
			}

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual string ConstraintTag
			{
				[Register("getConstraintTag", "()Ljava/lang/String;", "GetGetConstraintTagHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintTag.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual ConstraintWidget ConstraintWidget
			{
				[Register("getConstraintWidget", "()Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", "GetGetConstraintWidgetHandler")]
				get
				{
					return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintWidget.()Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

			[Register(".ctor", "(Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", "")]
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
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", this, ptr);
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

			private static Delegate GetGetConstraintTagHandler()
			{
				if ((object)cb_getConstraintTag == null)
				{
					cb_getConstraintTag = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConstraintTag));
				}
				return cb_getConstraintTag;
			}

			private static IntPtr n_GetConstraintTag(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstraintTag);
			}

			private static Delegate GetGetConstraintWidgetHandler()
			{
				if ((object)cb_getConstraintWidget == null)
				{
					cb_getConstraintWidget = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConstraintWidget));
				}
				return cb_getConstraintWidget;
			}

			private static IntPtr n_GetConstraintWidget(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstraintWidget);
			}

			private static Delegate GetResetHandler()
			{
				if ((object)cb_reset == null)
				{
					cb_reset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Reset));
				}
				return cb_reset;
			}

			private static void n_Reset(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
			}

			[Register("reset", "()V", "GetResetHandler")]
			public unsafe virtual void Reset()
			{
				_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
			}

			private static Delegate GetSetWidgetDebugName_Ljava_lang_String_Handler()
			{
				if ((object)cb_setWidgetDebugName_Ljava_lang_String_ == null)
				{
					cb_setWidgetDebugName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetWidgetDebugName_Ljava_lang_String_));
				}
				return cb_setWidgetDebugName_Ljava_lang_String_;
			}

			private static void n_SetWidgetDebugName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_text)
			{
				LayoutParams layoutParams = Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string widgetDebugName = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
				layoutParams.SetWidgetDebugName(widgetDebugName);
			}

			[Register("setWidgetDebugName", "(Ljava/lang/String;)V", "GetSetWidgetDebugName_Ljava_lang_String_Handler")]
			public unsafe virtual void SetWidgetDebugName(string text)
			{
				IntPtr intPtr = JNIEnv.NewString(text);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setWidgetDebugName.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetValidateHandler()
			{
				if ((object)cb_validate == null)
				{
					cb_validate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Validate));
				}
				return cb_validate;
			}

			private static void n_Validate(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Validate();
			}

			[Register("validate", "()V", "GetValidateHandler")]
			public unsafe virtual void Validate()
			{
				_members.InstanceMethods.InvokeVirtualVoidMethod("validate.()V", this, null);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintLayout", typeof(ConstraintLayout));

		private static Delegate cb_isRtl;

		private static Delegate cb_getMaxHeight;

		private static Delegate cb_setMaxHeight_I;

		private static Delegate cb_getMaxWidth;

		private static Delegate cb_setMaxWidth_I;

		private static Delegate cb_getMinHeight;

		private static Delegate cb_setMinHeight_I;

		private static Delegate cb_getMinWidth;

		private static Delegate cb_setMinWidth_I;

		private static Delegate cb_getOptimizationLevel;

		private static Delegate cb_setOptimizationLevel_I;

		private static Delegate cb_applyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_;

		private static Delegate cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_;

		private static Delegate cb_getDesignInformation_ILjava_lang_Object_;

		private static Delegate cb_getViewById_I;

		private static Delegate cb_loadLayoutDescription_I;

		private static Delegate cb_onLayout_ZIIII;

		private static Delegate cb_parseLayoutDescription_I;

		private static Delegate cb_resolveMeasuredDimension_IIIIZZ;

		private static Delegate cb_resolveSystem_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_III;

		private static Delegate cb_setConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_;

		private static Delegate cb_setDesignInformation_ILjava_lang_Object_Ljava_lang_Object_;

		private static Delegate cb_setOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_;

		private static Delegate cb_setSelfDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIII;

		private static Delegate cb_setState_III;

		[Register("mConstraintLayoutSpec")]
		protected ConstraintLayoutStates MConstraintLayoutSpec
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintLayoutStates>(_members.InstanceFields.GetObjectValue("mConstraintLayoutSpec.Landroidx/constraintlayout/widget/ConstraintLayoutStates;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mConstraintLayoutSpec.Landroidx/constraintlayout/widget/ConstraintLayoutStates;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mDirtyHierarchy")]
		protected bool MDirtyHierarchy
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mDirtyHierarchy.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mDirtyHierarchy.Z", this, value);
			}
		}

		[Register("mLayoutWidget")]
		protected ConstraintWidgetContainer MLayoutWidget
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(_members.InstanceFields.GetObjectValue("mLayoutWidget.Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mLayoutWidget.Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;", this, new JniObjectReference(jobject));
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

		protected unsafe virtual bool IsRtl
		{
			[Register("isRtl", "()Z", "GetIsRtlHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRtl.()Z", this, null);
			}
		}

		public unsafe virtual int MaxHeight
		{
			[Register("getMaxHeight", "()I", "GetGetMaxHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxHeight.()I", this, null);
			}
			[Register("setMaxHeight", "(I)V", "GetSetMaxHeight_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxHeight.(I)V", this, ptr);
			}
		}

		public unsafe virtual int MaxWidth
		{
			[Register("getMaxWidth", "()I", "GetGetMaxWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxWidth.()I", this, null);
			}
			[Register("setMaxWidth", "(I)V", "GetSetMaxWidth_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxWidth.(I)V", this, ptr);
			}
		}

		public unsafe virtual int MinHeight
		{
			[Register("getMinHeight", "()I", "GetGetMinHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMinHeight.()I", this, null);
			}
			[Register("setMinHeight", "(I)V", "GetSetMinHeight_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMinHeight.(I)V", this, ptr);
			}
		}

		public unsafe virtual int MinWidth
		{
			[Register("getMinWidth", "()I", "GetGetMinWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMinWidth.()I", this, null);
			}
			[Register("setMinWidth", "(I)V", "GetSetMinWidth_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMinWidth.(I)V", this, ptr);
			}
		}

		public unsafe virtual int OptimizationLevel
		{
			[Register("getOptimizationLevel", "()I", "GetGetOptimizationLevelHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getOptimizationLevel.()I", this, null);
			}
			[Register("setOptimizationLevel", "(I)V", "GetSetOptimizationLevel_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOptimizationLevel.(I)V", this, ptr);
			}
		}

		protected ConstraintLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe ConstraintLayout(Context context)
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
		public unsafe ConstraintLayout(Context context, IAttributeSet attrs)
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
		public unsafe ConstraintLayout(Context context, IAttributeSet attrs, int defStyleAttr)
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

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
		public unsafe ConstraintLayout(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
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

		private static Delegate GetIsRtlHandler()
		{
			if ((object)cb_isRtl == null)
			{
				cb_isRtl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRtl));
			}
			return cb_isRtl;
		}

		private static bool n_IsRtl(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRtl;
		}

		private static Delegate GetGetMaxHeightHandler()
		{
			if ((object)cb_getMaxHeight == null)
			{
				cb_getMaxHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMaxHeight));
			}
			return cb_getMaxHeight;
		}

		private static int n_GetMaxHeight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxHeight;
		}

		private static Delegate GetSetMaxHeight_IHandler()
		{
			if ((object)cb_setMaxHeight_I == null)
			{
				cb_setMaxHeight_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMaxHeight_I));
			}
			return cb_setMaxHeight_I;
		}

		private static void n_SetMaxHeight_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxHeight = value;
		}

		private static Delegate GetGetMaxWidthHandler()
		{
			if ((object)cb_getMaxWidth == null)
			{
				cb_getMaxWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMaxWidth));
			}
			return cb_getMaxWidth;
		}

		private static int n_GetMaxWidth(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth;
		}

		private static Delegate GetSetMaxWidth_IHandler()
		{
			if ((object)cb_setMaxWidth_I == null)
			{
				cb_setMaxWidth_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMaxWidth_I));
			}
			return cb_setMaxWidth_I;
		}

		private static void n_SetMaxWidth_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth = value;
		}

		private static Delegate GetGetMinHeightHandler()
		{
			if ((object)cb_getMinHeight == null)
			{
				cb_getMinHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMinHeight));
			}
			return cb_getMinHeight;
		}

		private static int n_GetMinHeight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinHeight;
		}

		private static Delegate GetSetMinHeight_IHandler()
		{
			if ((object)cb_setMinHeight_I == null)
			{
				cb_setMinHeight_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMinHeight_I));
			}
			return cb_setMinHeight_I;
		}

		private static void n_SetMinHeight_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinHeight = value;
		}

		private static Delegate GetGetMinWidthHandler()
		{
			if ((object)cb_getMinWidth == null)
			{
				cb_getMinWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMinWidth));
			}
			return cb_getMinWidth;
		}

		private static int n_GetMinWidth(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinWidth;
		}

		private static Delegate GetSetMinWidth_IHandler()
		{
			if ((object)cb_setMinWidth_I == null)
			{
				cb_setMinWidth_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMinWidth_I));
			}
			return cb_setMinWidth_I;
		}

		private static void n_SetMinWidth_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinWidth = value;
		}

		private static Delegate GetGetOptimizationLevelHandler()
		{
			if ((object)cb_getOptimizationLevel == null)
			{
				cb_getOptimizationLevel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOptimizationLevel));
			}
			return cb_getOptimizationLevel;
		}

		private static int n_GetOptimizationLevel(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizationLevel;
		}

		private static Delegate GetSetOptimizationLevel_IHandler()
		{
			if ((object)cb_setOptimizationLevel_I == null)
			{
				cb_setOptimizationLevel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetOptimizationLevel_I));
			}
			return cb_setOptimizationLevel_I;
		}

		private static void n_SetOptimizationLevel_I(IntPtr jnienv, IntPtr native__this, int level)
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizationLevel = level;
		}

		private static Delegate GetApplyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler()
		{
			if ((object)cb_applyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_ == null)
			{
				cb_applyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZLLLL_V(n_ApplyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_));
			}
			return cb_applyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_;
		}

		private static void n_ApplyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_(IntPtr jnienv, IntPtr native__this, bool isInEditMode, IntPtr native_child, IntPtr native_widget, IntPtr native_layoutParams, IntPtr native_idToWidget)
		{
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			LayoutParams layoutParams = Java.Lang.Object.GetObject<LayoutParams>(native_layoutParams, JniHandleOwnership.DoNotTransfer);
			SparseArray idToWidget = Java.Lang.Object.GetObject<SparseArray>(native_idToWidget, JniHandleOwnership.DoNotTransfer);
			constraintLayout.ApplyConstraintsFromLayoutParams(isInEditMode, child, widget, layoutParams, idToWidget);
		}

		[Register("applyConstraintsFromLayoutParams", "(ZLandroid/view/View;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", "GetApplyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler")]
		protected unsafe virtual void ApplyConstraintsFromLayoutParams(bool isInEditMode, View child, ConstraintWidget widget, LayoutParams layoutParams, SparseArray idToWidget)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(isInEditMode);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(layoutParams?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(idToWidget?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("applyConstraintsFromLayoutParams.(ZLandroid/view/View;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(widget);
				GC.KeepAlive(layoutParams);
				GC.KeepAlive(idToWidget);
			}
		}

		private static Delegate GetFillMetrics_Landroidx_constraintlayout_solver_Metrics_Handler()
		{
			if ((object)cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_ == null)
			{
				cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_FillMetrics_Landroidx_constraintlayout_solver_Metrics_));
			}
			return cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_;
		}

		private static void n_FillMetrics_Landroidx_constraintlayout_solver_Metrics_(IntPtr jnienv, IntPtr native__this, IntPtr native_metrics)
		{
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Metrics metrics = Java.Lang.Object.GetObject<Metrics>(native_metrics, JniHandleOwnership.DoNotTransfer);
			constraintLayout.FillMetrics(metrics);
		}

		[Register("fillMetrics", "(Landroidx/constraintlayout/solver/Metrics;)V", "GetFillMetrics_Landroidx_constraintlayout_solver_Metrics_Handler")]
		public unsafe virtual void FillMetrics(Metrics metrics)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(metrics?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("fillMetrics.(Landroidx/constraintlayout/solver/Metrics;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(metrics);
			}
		}

		private static Delegate GetGetDesignInformation_ILjava_lang_Object_Handler()
		{
			if ((object)cb_getDesignInformation_ILjava_lang_Object_ == null)
			{
				cb_getDesignInformation_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_GetDesignInformation_ILjava_lang_Object_));
			}
			return cb_getDesignInformation_ILjava_lang_Object_;
		}

		private static IntPtr n_GetDesignInformation_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int type, IntPtr native_value)
		{
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(constraintLayout.GetDesignInformation(type, value));
		}

		[Register("getDesignInformation", "(ILjava/lang/Object;)Ljava/lang/Object;", "GetGetDesignInformation_ILjava_lang_Object_Handler")]
		public unsafe virtual Java.Lang.Object GetDesignInformation(int type, Java.Lang.Object value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(type);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDesignInformation.(ILjava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetGetViewById_IHandler()
		{
			if ((object)cb_getViewById_I == null)
			{
				cb_getViewById_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetViewById_I));
			}
			return cb_getViewById_I;
		}

		private static IntPtr n_GetViewById_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetViewById(id));
		}

		[Register("getViewById", "(I)Landroid/view/View;", "GetGetViewById_IHandler")]
		public unsafe virtual View GetViewById(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewById.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getViewWidget", "(Landroid/view/View;)Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", "")]
		public unsafe ConstraintWidget GetViewWidget(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getViewWidget.(Landroid/view/View;)Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetLoadLayoutDescription_IHandler()
		{
			if ((object)cb_loadLayoutDescription_I == null)
			{
				cb_loadLayoutDescription_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_LoadLayoutDescription_I));
			}
			return cb_loadLayoutDescription_I;
		}

		private static void n_LoadLayoutDescription_I(IntPtr jnienv, IntPtr native__this, int layoutDescription)
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoadLayoutDescription(layoutDescription);
		}

		[Register("loadLayoutDescription", "(I)V", "GetLoadLayoutDescription_IHandler")]
		public unsafe virtual void LoadLayoutDescription(int layoutDescription)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layoutDescription);
			_members.InstanceMethods.InvokeVirtualVoidMethod("loadLayoutDescription.(I)V", this, ptr);
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
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayout(changed, left, top, right, bottom);
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

		private static Delegate GetParseLayoutDescription_IHandler()
		{
			if ((object)cb_parseLayoutDescription_I == null)
			{
				cb_parseLayoutDescription_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_ParseLayoutDescription_I));
			}
			return cb_parseLayoutDescription_I;
		}

		private static void n_ParseLayoutDescription_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParseLayoutDescription(id);
		}

		[Register("parseLayoutDescription", "(I)V", "GetParseLayoutDescription_IHandler")]
		protected unsafe virtual void ParseLayoutDescription(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeVirtualVoidMethod("parseLayoutDescription.(I)V", this, ptr);
		}

		private static Delegate GetResolveMeasuredDimension_IIIIZZHandler()
		{
			if ((object)cb_resolveMeasuredDimension_IIIIZZ == null)
			{
				cb_resolveMeasuredDimension_IIIIZZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIIZZ_V(n_ResolveMeasuredDimension_IIIIZZ));
			}
			return cb_resolveMeasuredDimension_IIIIZZ;
		}

		private static void n_ResolveMeasuredDimension_IIIIZZ(IntPtr jnienv, IntPtr native__this, int widthMeasureSpec, int heightMeasureSpec, int measuredWidth, int measuredHeight, bool isWidthMeasuredTooSmall, bool isHeightMeasuredTooSmall)
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResolveMeasuredDimension(widthMeasureSpec, heightMeasureSpec, measuredWidth, measuredHeight, isWidthMeasuredTooSmall, isHeightMeasuredTooSmall);
		}

		[Register("resolveMeasuredDimension", "(IIIIZZ)V", "GetResolveMeasuredDimension_IIIIZZHandler")]
		protected unsafe virtual void ResolveMeasuredDimension(int widthMeasureSpec, int heightMeasureSpec, int measuredWidth, int measuredHeight, bool isWidthMeasuredTooSmall, bool isHeightMeasuredTooSmall)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(widthMeasureSpec);
			ptr[1] = new JniArgumentValue(heightMeasureSpec);
			ptr[2] = new JniArgumentValue(measuredWidth);
			ptr[3] = new JniArgumentValue(measuredHeight);
			ptr[4] = new JniArgumentValue(isWidthMeasuredTooSmall);
			ptr[5] = new JniArgumentValue(isHeightMeasuredTooSmall);
			_members.InstanceMethods.InvokeVirtualVoidMethod("resolveMeasuredDimension.(IIIIZZ)V", this, ptr);
		}

		private static Delegate GetResolveSystem_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIHandler()
		{
			if ((object)cb_resolveSystem_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_III == null)
			{
				cb_resolveSystem_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIII_V(n_ResolveSystem_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_III));
			}
			return cb_resolveSystem_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_III;
		}

		private static void n_ResolveSystem_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_III(IntPtr jnienv, IntPtr native__this, IntPtr native_layout, int optimizationLevel, int widthMeasureSpec, int heightMeasureSpec)
		{
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer layout = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_layout, JniHandleOwnership.DoNotTransfer);
			constraintLayout.ResolveSystem(layout, optimizationLevel, widthMeasureSpec, heightMeasureSpec);
		}

		[Register("resolveSystem", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;III)V", "GetResolveSystem_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIHandler")]
		protected unsafe virtual void ResolveSystem(ConstraintWidgetContainer layout, int optimizationLevel, int widthMeasureSpec, int heightMeasureSpec)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(optimizationLevel);
				ptr[2] = new JniArgumentValue(widthMeasureSpec);
				ptr[3] = new JniArgumentValue(heightMeasureSpec);
				_members.InstanceMethods.InvokeVirtualVoidMethod("resolveSystem.(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;III)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(layout);
			}
		}

		private static Delegate GetSetConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_Handler()
		{
			if ((object)cb_setConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_ == null)
			{
				cb_setConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_));
			}
			return cb_setConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_;
		}

		private static void n_SetConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_(IntPtr jnienv, IntPtr native__this, IntPtr native_set)
		{
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			constraintLayout.SetConstraintSet(constraintSet);
		}

		[Register("setConstraintSet", "(Landroidx/constraintlayout/widget/ConstraintSet;)V", "GetSetConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_Handler")]
		public unsafe virtual void SetConstraintSet(ConstraintSet set)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setConstraintSet.(Landroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(set);
			}
		}

		private static Delegate GetSetDesignInformation_ILjava_lang_Object_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setDesignInformation_ILjava_lang_Object_Ljava_lang_Object_ == null)
			{
				cb_setDesignInformation_ILjava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_V(n_SetDesignInformation_ILjava_lang_Object_Ljava_lang_Object_));
			}
			return cb_setDesignInformation_ILjava_lang_Object_Ljava_lang_Object_;
		}

		private static void n_SetDesignInformation_ILjava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, int type, IntPtr native_value1, IntPtr native_value2)
		{
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value1, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value2, JniHandleOwnership.DoNotTransfer);
			constraintLayout.SetDesignInformation(type, value, value2);
		}

		[Register("setDesignInformation", "(ILjava/lang/Object;Ljava/lang/Object;)V", "GetSetDesignInformation_ILjava_lang_Object_Ljava_lang_Object_Handler")]
		public unsafe virtual void SetDesignInformation(int type, Java.Lang.Object value1, Java.Lang.Object value2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(type);
				ptr[1] = new JniArgumentValue(value1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(value2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDesignInformation.(ILjava/lang/Object;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value1);
				GC.KeepAlive(value2);
			}
		}

		private static Delegate GetSetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_Handler()
		{
			if ((object)cb_setOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_ == null)
			{
				cb_setOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_));
			}
			return cb_setOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_;
		}

		private static void n_SetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraintsChangedListener)
		{
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintsChangedListener onConstraintsChanged = Java.Lang.Object.GetObject<ConstraintsChangedListener>(native_constraintsChangedListener, JniHandleOwnership.DoNotTransfer);
			constraintLayout.SetOnConstraintsChanged(onConstraintsChanged);
		}

		[Register("setOnConstraintsChanged", "(Landroidx/constraintlayout/widget/ConstraintsChangedListener;)V", "GetSetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_Handler")]
		public unsafe virtual void SetOnConstraintsChanged(ConstraintsChangedListener constraintsChangedListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constraintsChangedListener?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnConstraintsChanged.(Landroidx/constraintlayout/widget/ConstraintsChangedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintsChangedListener);
			}
		}

		private static Delegate GetSetSelfDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIIHandler()
		{
			if ((object)cb_setSelfDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIII == null)
			{
				cb_setSelfDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIII_V(n_SetSelfDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIII));
			}
			return cb_setSelfDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIII;
		}

		private static void n_SetSelfDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIII(IntPtr jnienv, IntPtr native__this, IntPtr native_layout, int widthMode, int widthSize, int heightMode, int heightSize)
		{
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer layout = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_layout, JniHandleOwnership.DoNotTransfer);
			constraintLayout.SetSelfDimensionBehaviour(layout, widthMode, widthSize, heightMode, heightSize);
		}

		[Register("setSelfDimensionBehaviour", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;IIII)V", "GetSetSelfDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIIHandler")]
		protected unsafe virtual void SetSelfDimensionBehaviour(ConstraintWidgetContainer layout, int widthMode, int widthSize, int heightMode, int heightSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(widthMode);
				ptr[2] = new JniArgumentValue(widthSize);
				ptr[3] = new JniArgumentValue(heightMode);
				ptr[4] = new JniArgumentValue(heightSize);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSelfDimensionBehaviour.(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;IIII)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(layout);
			}
		}

		private static Delegate GetSetState_IIIHandler()
		{
			if ((object)cb_setState_III == null)
			{
				cb_setState_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_V(n_SetState_III));
			}
			return cb_setState_III;
		}

		private static void n_SetState_III(IntPtr jnienv, IntPtr native__this, int id, int screenWidth, int screenHeight)
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetState(id, screenWidth, screenHeight);
		}

		[Register("setState", "(III)V", "GetSetState_IIIHandler")]
		public unsafe virtual void SetState(int id, int screenWidth, int screenHeight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(screenWidth);
			ptr[2] = new JniArgumentValue(screenHeight);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setState.(III)V", this, ptr);
		}
	}
	[Register("androidx/constraintlayout/widget/ConstraintLayoutStates", DoNotGenerateAcw = true)]
	public class ConstraintLayoutStates : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintLayoutStates", typeof(ConstraintLayoutStates));

		private static Delegate cb_needsToChange_IFF;

		private static Delegate cb_setOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_;

		private static Delegate cb_updateConstraints_IFF;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ConstraintLayoutStates(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetNeedsToChange_IFFHandler()
		{
			if ((object)cb_needsToChange_IFF == null)
			{
				cb_needsToChange_IFF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIFF_Z(n_NeedsToChange_IFF));
			}
			return cb_needsToChange_IFF;
		}

		private static bool n_NeedsToChange_IFF(IntPtr jnienv, IntPtr native__this, int id, float width, float height)
		{
			return Java.Lang.Object.GetObject<ConstraintLayoutStates>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NeedsToChange(id, width, height);
		}

		[Register("needsToChange", "(IFF)Z", "GetNeedsToChange_IFFHandler")]
		public unsafe virtual bool NeedsToChange(int id, float width, float height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(width);
			ptr[2] = new JniArgumentValue(height);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("needsToChange.(IFF)Z", this, ptr);
		}

		private static Delegate GetSetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_Handler()
		{
			if ((object)cb_setOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_ == null)
			{
				cb_setOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_));
			}
			return cb_setOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_;
		}

		private static void n_SetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraintsChangedListener)
		{
			ConstraintLayoutStates constraintLayoutStates = Java.Lang.Object.GetObject<ConstraintLayoutStates>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintsChangedListener onConstraintsChanged = Java.Lang.Object.GetObject<ConstraintsChangedListener>(native_constraintsChangedListener, JniHandleOwnership.DoNotTransfer);
			constraintLayoutStates.SetOnConstraintsChanged(onConstraintsChanged);
		}

		[Register("setOnConstraintsChanged", "(Landroidx/constraintlayout/widget/ConstraintsChangedListener;)V", "GetSetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_Handler")]
		public unsafe virtual void SetOnConstraintsChanged(ConstraintsChangedListener constraintsChangedListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constraintsChangedListener?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnConstraintsChanged.(Landroidx/constraintlayout/widget/ConstraintsChangedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintsChangedListener);
			}
		}

		private static Delegate GetUpdateConstraints_IFFHandler()
		{
			if ((object)cb_updateConstraints_IFF == null)
			{
				cb_updateConstraints_IFF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIFF_V(n_UpdateConstraints_IFF));
			}
			return cb_updateConstraints_IFF;
		}

		private static void n_UpdateConstraints_IFF(IntPtr jnienv, IntPtr native__this, int id, float width, float height)
		{
			Java.Lang.Object.GetObject<ConstraintLayoutStates>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateConstraints(id, width, height);
		}

		[Register("updateConstraints", "(IFF)V", "GetUpdateConstraints_IFFHandler")]
		public unsafe virtual void UpdateConstraints(int id, float width, float height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(width);
			ptr[2] = new JniArgumentValue(height);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateConstraints.(IFF)V", this, ptr);
		}
	}
	[Register("androidx/constraintlayout/widget/Constraints", DoNotGenerateAcw = true)]
	public class Constraints : ViewGroup
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/Constraints", typeof(Constraints));

		private static Delegate cb_getConstraintSet;

		private static Delegate cb_onLayout_ZIIII;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual ConstraintSet ConstraintSet
		{
			[Register("getConstraintSet", "()Landroidx/constraintlayout/widget/ConstraintSet;", "GetGetConstraintSetHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ConstraintSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintSet.()Landroidx/constraintlayout/widget/ConstraintSet;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Constraints(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe Constraints(Context context)
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
		public unsafe Constraints(Context context, IAttributeSet attrs)
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
		public unsafe Constraints(Context context, IAttributeSet attrs, int defStyleAttr)
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

		private static Delegate GetGetConstraintSetHandler()
		{
			if ((object)cb_getConstraintSet == null)
			{
				cb_getConstraintSet = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConstraintSet));
			}
			return cb_getConstraintSet;
		}

		private static IntPtr n_GetConstraintSet(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Constraints>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstraintSet);
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
			Java.Lang.Object.GetObject<Constraints>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayout(changed, l, t, r, b);
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
	}
	[Register("androidx/constraintlayout/widget/ConstraintsChangedListener", DoNotGenerateAcw = true)]
	public abstract class ConstraintsChangedListener : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintsChangedListener", typeof(ConstraintsChangedListener));

		private static Delegate cb_postLayoutChange_II;

		private static Delegate cb_preLayoutChange_II;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ConstraintsChangedListener(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ConstraintsChangedListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetPostLayoutChange_IIHandler()
		{
			if ((object)cb_postLayoutChange_II == null)
			{
				cb_postLayoutChange_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_PostLayoutChange_II));
			}
			return cb_postLayoutChange_II;
		}

		private static void n_PostLayoutChange_II(IntPtr jnienv, IntPtr native__this, int stateId, int constraintId)
		{
			Java.Lang.Object.GetObject<ConstraintsChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PostLayoutChange(stateId, constraintId);
		}

		[Register("postLayoutChange", "(II)V", "GetPostLayoutChange_IIHandler")]
		public unsafe virtual void PostLayoutChange(int stateId, int constraintId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(stateId);
			ptr[1] = new JniArgumentValue(constraintId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("postLayoutChange.(II)V", this, ptr);
		}

		private static Delegate GetPreLayoutChange_IIHandler()
		{
			if ((object)cb_preLayoutChange_II == null)
			{
				cb_preLayoutChange_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_PreLayoutChange_II));
			}
			return cb_preLayoutChange_II;
		}

		private static void n_PreLayoutChange_II(IntPtr jnienv, IntPtr native__this, int stateId, int constraintId)
		{
			Java.Lang.Object.GetObject<ConstraintsChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreLayoutChange(stateId, constraintId);
		}

		[Register("preLayoutChange", "(II)V", "GetPreLayoutChange_IIHandler")]
		public unsafe virtual void PreLayoutChange(int stateId, int constraintId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(stateId);
			ptr[1] = new JniArgumentValue(constraintId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("preLayoutChange.(II)V", this, ptr);
		}
	}
	[Register("androidx/constraintlayout/widget/ConstraintsChangedListener", DoNotGenerateAcw = true)]
	internal class ConstraintsChangedListenerInvoker : ConstraintsChangedListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintsChangedListener", typeof(ConstraintsChangedListenerInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public ConstraintsChangedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("androidx/constraintlayout/widget/ConstraintSet", DoNotGenerateAcw = true)]
	public class ConstraintSet : Java.Lang.Object
	{
		[Register("androidx/constraintlayout/widget/ConstraintSet$Constraint", DoNotGenerateAcw = true)]
		public class Constraint : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet$Constraint", typeof(Constraint));

			private static Delegate cb_applyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_;

			private static Delegate cb_clone;

			[Register("layout")]
			public Layout Layout
			{
				get
				{
					return Java.Lang.Object.GetObject<Layout>(_members.InstanceFields.GetObjectValue("layout.Landroidx/constraintlayout/widget/ConstraintSet$Layout;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("layout.Landroidx/constraintlayout/widget/ConstraintSet$Layout;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("mCustomConstraints")]
			public IDictionary MCustomConstraints
			{
				get
				{
					return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("mCustomConstraints.Ljava/util/HashMap;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JavaDictionary.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("mCustomConstraints.Ljava/util/HashMap;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("motion")]
			public Motion Motion
			{
				get
				{
					return Java.Lang.Object.GetObject<Motion>(_members.InstanceFields.GetObjectValue("motion.Landroidx/constraintlayout/widget/ConstraintSet$Motion;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("motion.Landroidx/constraintlayout/widget/ConstraintSet$Motion;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("propertySet")]
			public PropertySet PropertySet
			{
				get
				{
					return Java.Lang.Object.GetObject<PropertySet>(_members.InstanceFields.GetObjectValue("propertySet.Landroidx/constraintlayout/widget/ConstraintSet$PropertySet;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("propertySet.Landroidx/constraintlayout/widget/ConstraintSet$PropertySet;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("transform")]
			public Transform Transform
			{
				get
				{
					return Java.Lang.Object.GetObject<Transform>(_members.InstanceFields.GetObjectValue("transform.Landroidx/constraintlayout/widget/ConstraintSet$Transform;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("transform.Landroidx/constraintlayout/widget/ConstraintSet$Transform;", this, new JniObjectReference(jobject));
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

			protected Constraint(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Constraint()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Handler()
			{
				if ((object)cb_applyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_ == null)
				{
					cb_applyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_));
				}
				return cb_applyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_;
			}

			private static void n_ApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_param)
			{
				Constraint constraint = Java.Lang.Object.GetObject<Constraint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ConstraintLayout.LayoutParams param = Java.Lang.Object.GetObject<ConstraintLayout.LayoutParams>(native_param, JniHandleOwnership.DoNotTransfer);
				constraint.ApplyTo(param);
			}

			[Register("applyTo", "(Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", "GetApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Handler")]
			public unsafe virtual void ApplyTo(ConstraintLayout.LayoutParams param)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(param?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("applyTo.(Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(param);
				}
			}

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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Constraint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
			}

			[Register("clone", "()Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", "GetCloneHandler")]
			public new unsafe virtual Constraint Clone()
			{
				return Java.Lang.Object.GetObject<Constraint>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("androidx/constraintlayout/widget/ConstraintSet$Layout", DoNotGenerateAcw = true)]
		public class Layout : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet$Layout", typeof(Layout));

			private static Delegate cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_;

			private static Delegate cb_dump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_;

			[Register("baselineToBaseline")]
			public int BaselineToBaseline
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("baselineToBaseline.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("baselineToBaseline.I", this, value);
				}
			}

			[Register("bottomMargin")]
			public int BottomMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("bottomMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("bottomMargin.I", this, value);
				}
			}

			[Register("bottomToBottom")]
			public int BottomToBottom
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("bottomToBottom.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("bottomToBottom.I", this, value);
				}
			}

			[Register("bottomToTop")]
			public int BottomToTop
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("bottomToTop.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("bottomToTop.I", this, value);
				}
			}

			[Register("circleAngle")]
			public float CircleAngle
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("circleAngle.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("circleAngle.F", this, value);
				}
			}

			[Register("circleConstraint")]
			public int CircleConstraint
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("circleConstraint.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("circleConstraint.I", this, value);
				}
			}

			[Register("circleRadius")]
			public int CircleRadius
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("circleRadius.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("circleRadius.I", this, value);
				}
			}

			[Register("constrainedHeight")]
			public bool ConstrainedHeight
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("constrainedHeight.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("constrainedHeight.Z", this, value);
				}
			}

			[Register("constrainedWidth")]
			public bool ConstrainedWidth
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("constrainedWidth.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("constrainedWidth.Z", this, value);
				}
			}

			[Register("dimensionRatio")]
			public string DimensionRatio
			{
				get
				{
					return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("dimensionRatio.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.NewString(value);
					try
					{
						_members.InstanceFields.SetValue("dimensionRatio.Ljava/lang/String;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("editorAbsoluteX")]
			public int EditorAbsoluteX
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("editorAbsoluteX.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("editorAbsoluteX.I", this, value);
				}
			}

			[Register("editorAbsoluteY")]
			public int EditorAbsoluteY
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("editorAbsoluteY.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("editorAbsoluteY.I", this, value);
				}
			}

			[Register("endMargin")]
			public int EndMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("endMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("endMargin.I", this, value);
				}
			}

			[Register("endToEnd")]
			public int EndToEnd
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("endToEnd.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("endToEnd.I", this, value);
				}
			}

			[Register("endToStart")]
			public int EndToStart
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("endToStart.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("endToStart.I", this, value);
				}
			}

			[Register("goneBottomMargin")]
			public int GoneBottomMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneBottomMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneBottomMargin.I", this, value);
				}
			}

			[Register("goneEndMargin")]
			public int GoneEndMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneEndMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneEndMargin.I", this, value);
				}
			}

			[Register("goneLeftMargin")]
			public int GoneLeftMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneLeftMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneLeftMargin.I", this, value);
				}
			}

			[Register("goneRightMargin")]
			public int GoneRightMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneRightMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneRightMargin.I", this, value);
				}
			}

			[Register("goneStartMargin")]
			public int GoneStartMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneStartMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneStartMargin.I", this, value);
				}
			}

			[Register("goneTopMargin")]
			public int GoneTopMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("goneTopMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("goneTopMargin.I", this, value);
				}
			}

			[Register("guideBegin")]
			public int GuideBegin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("guideBegin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("guideBegin.I", this, value);
				}
			}

			[Register("guideEnd")]
			public int GuideEnd
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("guideEnd.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("guideEnd.I", this, value);
				}
			}

			[Register("guidePercent")]
			public float GuidePercent
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("guidePercent.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("guidePercent.F", this, value);
				}
			}

			[Register("heightDefault")]
			public int HeightDefault
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("heightDefault.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("heightDefault.I", this, value);
				}
			}

			[Register("heightMax")]
			public int HeightMax
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("heightMax.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("heightMax.I", this, value);
				}
			}

			[Register("heightMin")]
			public int HeightMin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("heightMin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("heightMin.I", this, value);
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

			[Register("horizontalBias")]
			public float HorizontalBias
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("horizontalBias.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("horizontalBias.F", this, value);
				}
			}

			[Register("horizontalChainStyle")]
			public int HorizontalChainStyle
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("horizontalChainStyle.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("horizontalChainStyle.I", this, value);
				}
			}

			[Register("horizontalWeight")]
			public float HorizontalWeight
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("horizontalWeight.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("horizontalWeight.F", this, value);
				}
			}

			[Register("leftMargin")]
			public int LeftMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("leftMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("leftMargin.I", this, value);
				}
			}

			[Register("leftToLeft")]
			public int LeftToLeft
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("leftToLeft.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("leftToLeft.I", this, value);
				}
			}

			[Register("leftToRight")]
			public int LeftToRight
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("leftToRight.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("leftToRight.I", this, value);
				}
			}

			[Register("mApply")]
			public bool MApply
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("mApply.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mApply.Z", this, value);
				}
			}

			[Register("mBarrierAllowsGoneWidgets")]
			public bool MBarrierAllowsGoneWidgets
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("mBarrierAllowsGoneWidgets.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mBarrierAllowsGoneWidgets.Z", this, value);
				}
			}

			[Register("mBarrierDirection")]
			public int MBarrierDirection
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("mBarrierDirection.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mBarrierDirection.I", this, value);
				}
			}

			[Register("mBarrierMargin")]
			public int MBarrierMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("mBarrierMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mBarrierMargin.I", this, value);
				}
			}

			[Register("mConstraintTag")]
			public string MConstraintTag
			{
				get
				{
					return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mConstraintTag.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.NewString(value);
					try
					{
						_members.InstanceFields.SetValue("mConstraintTag.Ljava/lang/String;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("mHeight")]
			public int MHeight
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("mHeight.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mHeight.I", this, value);
				}
			}

			[Register("mHelperType")]
			public int MHelperType
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("mHelperType.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mHelperType.I", this, value);
				}
			}

			[Register("mIsGuideline")]
			public bool MIsGuideline
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("mIsGuideline.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mIsGuideline.Z", this, value);
				}
			}

			[Register("mReferenceIdString")]
			public string MReferenceIdString
			{
				get
				{
					return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mReferenceIdString.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.NewString(value);
					try
					{
						_members.InstanceFields.SetValue("mReferenceIdString.Ljava/lang/String;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("mReferenceIds")]
			public IList<int> MReferenceIds
			{
				get
				{
					return Android.Runtime.JavaArray<int>.FromJniHandle(_members.InstanceFields.GetObjectValue("mReferenceIds.[I", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = Android.Runtime.JavaArray<int>.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("mReferenceIds.[I", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("mWidth")]
			public int MWidth
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("mWidth.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mWidth.I", this, value);
				}
			}

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

			[Register("rightMargin")]
			public int RightMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("rightMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("rightMargin.I", this, value);
				}
			}

			[Register("rightToLeft")]
			public int RightToLeft
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("rightToLeft.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("rightToLeft.I", this, value);
				}
			}

			[Register("rightToRight")]
			public int RightToRight
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("rightToRight.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("rightToRight.I", this, value);
				}
			}

			[Register("startMargin")]
			public int StartMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("startMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("startMargin.I", this, value);
				}
			}

			[Register("startToEnd")]
			public int StartToEnd
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("startToEnd.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("startToEnd.I", this, value);
				}
			}

			[Register("startToStart")]
			public int StartToStart
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("startToStart.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("startToStart.I", this, value);
				}
			}

			[Register("topMargin")]
			public int TopMargin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("topMargin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("topMargin.I", this, value);
				}
			}

			[Register("topToBottom")]
			public int TopToBottom
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("topToBottom.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("topToBottom.I", this, value);
				}
			}

			[Register("topToTop")]
			public int TopToTop
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("topToTop.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("topToTop.I", this, value);
				}
			}

			[Register("verticalBias")]
			public float VerticalBias
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("verticalBias.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("verticalBias.F", this, value);
				}
			}

			[Register("verticalChainStyle")]
			public int VerticalChainStyle
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("verticalChainStyle.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("verticalChainStyle.I", this, value);
				}
			}

			[Register("verticalWeight")]
			public float VerticalWeight
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("verticalWeight.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("verticalWeight.F", this, value);
				}
			}

			[Register("widthDefault")]
			public int WidthDefault
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("widthDefault.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("widthDefault.I", this, value);
				}
			}

			[Register("widthMax")]
			public int WidthMax
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("widthMax.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("widthMax.I", this, value);
				}
			}

			[Register("widthMin")]
			public int WidthMin
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("widthMin.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("widthMin.I", this, value);
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

			protected Layout(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Layout()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_Handler()
			{
				if ((object)cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_ == null)
				{
					cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_));
				}
				return cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_;
			}

			private static void n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_(IntPtr jnienv, IntPtr native__this, IntPtr native_src)
			{
				Layout layout = Java.Lang.Object.GetObject<Layout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Layout src = Java.Lang.Object.GetObject<Layout>(native_src, JniHandleOwnership.DoNotTransfer);
				layout.CopyFrom(src);
			}

			[Register("copyFrom", "(Landroidx/constraintlayout/widget/ConstraintSet$Layout;)V", "GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_Handler")]
			public unsafe virtual void CopyFrom(Layout src)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("copyFrom.(Landroidx/constraintlayout/widget/ConstraintSet$Layout;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(src);
				}
			}

			private static Delegate GetDump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_Handler()
			{
				if ((object)cb_dump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_ == null)
				{
					cb_dump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Dump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_));
				}
				return cb_dump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_;
			}

			private static void n_Dump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_(IntPtr jnienv, IntPtr native__this, IntPtr native_scene, IntPtr native_stringBuilder)
			{
				Layout layout = Java.Lang.Object.GetObject<Layout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionScene scene = Java.Lang.Object.GetObject<MotionScene>(native_scene, JniHandleOwnership.DoNotTransfer);
				StringBuilder stringBuilder = Java.Lang.Object.GetObject<StringBuilder>(native_stringBuilder, JniHandleOwnership.DoNotTransfer);
				layout.Dump(scene, stringBuilder);
			}

			[Register("dump", "(Landroidx/constraintlayout/motion/widget/MotionScene;Ljava/lang/StringBuilder;)V", "GetDump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_Handler")]
			public unsafe virtual void Dump(MotionScene scene, StringBuilder stringBuilder)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(scene?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(stringBuilder?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("dump.(Landroidx/constraintlayout/motion/widget/MotionScene;Ljava/lang/StringBuilder;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(scene);
					GC.KeepAlive(stringBuilder);
				}
			}
		}

		[Register("androidx/constraintlayout/widget/ConstraintSet$Motion", DoNotGenerateAcw = true)]
		public class Motion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet$Motion", typeof(Motion));

			private static Delegate cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_;

			[Register("mAnimateRelativeTo")]
			public int MAnimateRelativeTo
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("mAnimateRelativeTo.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mAnimateRelativeTo.I", this, value);
				}
			}

			[Register("mApply")]
			public bool MApply
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("mApply.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mApply.Z", this, value);
				}
			}

			[Register("mDrawPath")]
			public int MDrawPath
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("mDrawPath.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mDrawPath.I", this, value);
				}
			}

			[Register("mMotionStagger")]
			public float MMotionStagger
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("mMotionStagger.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mMotionStagger.F", this, value);
				}
			}

			[Register("mPathMotionArc")]
			public int MPathMotionArc
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("mPathMotionArc.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mPathMotionArc.I", this, value);
				}
			}

			[Register("mPathRotate")]
			public float MPathRotate
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("mPathRotate.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mPathRotate.F", this, value);
				}
			}

			[Register("mTransitionEasing")]
			public string MTransitionEasing
			{
				get
				{
					return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mTransitionEasing.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.NewString(value);
					try
					{
						_members.InstanceFields.SetValue("mTransitionEasing.Ljava/lang/String;", this, new JniObjectReference(jobject));
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

			protected Motion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Motion()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_Handler()
			{
				if ((object)cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_ == null)
				{
					cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_));
				}
				return cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_;
			}

			private static void n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_(IntPtr jnienv, IntPtr native__this, IntPtr native_src)
			{
				Motion motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Motion src = Java.Lang.Object.GetObject<Motion>(native_src, JniHandleOwnership.DoNotTransfer);
				motion.CopyFrom(src);
			}

			[Register("copyFrom", "(Landroidx/constraintlayout/widget/ConstraintSet$Motion;)V", "GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_Handler")]
			public unsafe virtual void CopyFrom(Motion src)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("copyFrom.(Landroidx/constraintlayout/widget/ConstraintSet$Motion;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(src);
				}
			}
		}

		[Register("androidx/constraintlayout/widget/ConstraintSet$PropertySet", DoNotGenerateAcw = true)]
		public class PropertySet : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet$PropertySet", typeof(PropertySet));

			private static Delegate cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_;

			[Register("alpha")]
			public float Alpha
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("alpha.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("alpha.F", this, value);
				}
			}

			[Register("mApply")]
			public bool MApply
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("mApply.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mApply.Z", this, value);
				}
			}

			[Register("mProgress")]
			public float MProgress
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("mProgress.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mProgress.F", this, value);
				}
			}

			[Register("mVisibilityMode")]
			public int MVisibilityMode
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("mVisibilityMode.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mVisibilityMode.I", this, value);
				}
			}

			[Register("visibility")]
			public int Visibility
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("visibility.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("visibility.I", this, value);
				}
			}

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected PropertySet(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe PropertySet()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_Handler()
			{
				if ((object)cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_ == null)
				{
					cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_));
				}
				return cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_;
			}

			private static void n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_(IntPtr jnienv, IntPtr native__this, IntPtr native_src)
			{
				PropertySet propertySet = Java.Lang.Object.GetObject<PropertySet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				PropertySet src = Java.Lang.Object.GetObject<PropertySet>(native_src, JniHandleOwnership.DoNotTransfer);
				propertySet.CopyFrom(src);
			}

			[Register("copyFrom", "(Landroidx/constraintlayout/widget/ConstraintSet$PropertySet;)V", "GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_Handler")]
			public unsafe virtual void CopyFrom(PropertySet src)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("copyFrom.(Landroidx/constraintlayout/widget/ConstraintSet$PropertySet;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(src);
				}
			}
		}

		[Register("androidx/constraintlayout/widget/ConstraintSet$Transform", DoNotGenerateAcw = true)]
		public class Transform : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet$Transform", typeof(Transform));

			private static Delegate cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_;

			[Register("applyElevation")]
			public bool ApplyElevation
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("applyElevation.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("applyElevation.Z", this, value);
				}
			}

			[Register("elevation")]
			public float Elevation
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("elevation.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("elevation.F", this, value);
				}
			}

			[Register("mApply")]
			public bool MApply
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("mApply.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("mApply.Z", this, value);
				}
			}

			[Register("rotation")]
			public float Rotation
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("rotation.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("rotation.F", this, value);
				}
			}

			[Register("rotationX")]
			public float RotationX
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("rotationX.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("rotationX.F", this, value);
				}
			}

			[Register("rotationY")]
			public float RotationY
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("rotationY.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("rotationY.F", this, value);
				}
			}

			[Register("scaleX")]
			public float ScaleX
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("scaleX.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("scaleX.F", this, value);
				}
			}

			[Register("scaleY")]
			public float ScaleY
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("scaleY.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("scaleY.F", this, value);
				}
			}

			[Register("transformPivotX")]
			public float TransformPivotX
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("transformPivotX.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("transformPivotX.F", this, value);
				}
			}

			[Register("transformPivotY")]
			public float TransformPivotY
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("transformPivotY.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("transformPivotY.F", this, value);
				}
			}

			[Register("translationX")]
			public float TranslationX
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("translationX.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("translationX.F", this, value);
				}
			}

			[Register("translationY")]
			public float TranslationY
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("translationY.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("translationY.F", this, value);
				}
			}

			[Register("translationZ")]
			public float TranslationZ
			{
				get
				{
					return _members.InstanceFields.GetSingleValue("translationZ.F", this);
				}
				set
				{
					_members.InstanceFields.SetValue("translationZ.F", this, value);
				}
			}

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected Transform(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Transform()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_Handler()
			{
				if ((object)cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_ == null)
				{
					cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_));
				}
				return cb_copyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_;
			}

			private static void n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_(IntPtr jnienv, IntPtr native__this, IntPtr native_src)
			{
				Transform transform = Java.Lang.Object.GetObject<Transform>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Transform src = Java.Lang.Object.GetObject<Transform>(native_src, JniHandleOwnership.DoNotTransfer);
				transform.CopyFrom(src);
			}

			[Register("copyFrom", "(Landroidx/constraintlayout/widget/ConstraintSet$Transform;)V", "GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_Handler")]
			public unsafe virtual void CopyFrom(Transform src)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("copyFrom.(Landroidx/constraintlayout/widget/ConstraintSet$Transform;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(src);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet", typeof(ConstraintSet));

		private static Delegate cb_getCustomAttributeSet;

		private static Delegate cb_isForceId;

		private static Delegate cb_setForceId_Z;

		private static Delegate cb_addColorAttributes_arrayLjava_lang_String_;

		private static Delegate cb_addFloatAttributes_arrayLjava_lang_String_;

		private static Delegate cb_addIntAttributes_arrayLjava_lang_String_;

		private static Delegate cb_addStringAttributes_arrayLjava_lang_String_;

		private static Delegate cb_addToHorizontalChain_III;

		private static Delegate cb_addToHorizontalChainRTL_III;

		private static Delegate cb_addToVerticalChain_III;

		private static Delegate cb_applyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_applyTo_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_applyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_;

		private static Delegate cb_applyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_;

		private static Delegate cb_applyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_center_IIIIIIIF;

		private static Delegate cb_centerHorizontally_II;

		private static Delegate cb_centerHorizontally_IIIIIIIF;

		private static Delegate cb_centerHorizontallyRtl_II;

		private static Delegate cb_centerHorizontallyRtl_IIIIIIIF;

		private static Delegate cb_centerVertically_II;

		private static Delegate cb_centerVertically_IIIIIIIF;

		private static Delegate cb_clear_I;

		private static Delegate cb_clear_II;

		private static Delegate cb_clone_Landroid_content_Context_I;

		private static Delegate cb_clone_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_clone_Landroidx_constraintlayout_widget_Constraints_;

		private static Delegate cb_clone_Landroidx_constraintlayout_widget_ConstraintSet_;

		private static Delegate cb_connect_IIII;

		private static Delegate cb_connect_IIIII;

		private static Delegate cb_constrainCircle_IIIF;

		private static Delegate cb_constrainDefaultHeight_II;

		private static Delegate cb_constrainDefaultWidth_II;

		private static Delegate cb_constrainHeight_II;

		private static Delegate cb_constrainMaxHeight_II;

		private static Delegate cb_constrainMaxWidth_II;

		private static Delegate cb_constrainMinHeight_II;

		private static Delegate cb_constrainMinWidth_II;

		private static Delegate cb_constrainPercentHeight_IF;

		private static Delegate cb_constrainPercentWidth_IF;

		private static Delegate cb_constrainWidth_II;

		private static Delegate cb_constrainedHeight_IZ;

		private static Delegate cb_constrainedWidth_IZ;

		private static Delegate cb_create_II;

		private static Delegate cb_createBarrier_IIIarrayI;

		private static Delegate cb_createHorizontalChain_IIIIarrayIarrayFI;

		private static Delegate cb_createHorizontalChainRtl_IIIIarrayIarrayFI;

		private static Delegate cb_createVerticalChain_IIIIarrayIarrayFI;

		private static Delegate cb_dump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayI;

		private static Delegate cb_getApplyElevation_I;

		private static Delegate cb_getConstraint_I;

		private static Delegate cb_getHeight_I;

		private static Delegate cb_getKnownIds;

		private static Delegate cb_getParameters_I;

		private static Delegate cb_getReferencedIds_I;

		private static Delegate cb_getVisibility_I;

		private static Delegate cb_getVisibilityMode_I;

		private static Delegate cb_getWidth_I;

		private static Delegate cb_load_Landroid_content_Context_I;

		private static Delegate cb_load_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_;

		private static Delegate cb_parseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_;

		private static Delegate cb_parseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_;

		private static Delegate cb_parseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_;

		private static Delegate cb_parseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_;

		private static Delegate cb_readFallback_Landroidx_constraintlayout_widget_ConstraintLayout_;

		private static Delegate cb_readFallback_Landroidx_constraintlayout_widget_ConstraintSet_;

		private static Delegate cb_removeAttribute_Ljava_lang_String_;

		private static Delegate cb_removeFromHorizontalChain_I;

		private static Delegate cb_removeFromVerticalChain_I;

		private static Delegate cb_setAlpha_IF;

		private static Delegate cb_setApplyElevation_IZ;

		private static Delegate cb_setBarrierType_II;

		private static Delegate cb_setColorValue_ILjava_lang_String_I;

		private static Delegate cb_setDimensionRatio_ILjava_lang_String_;

		private static Delegate cb_setEditorAbsoluteX_II;

		private static Delegate cb_setEditorAbsoluteY_II;

		private static Delegate cb_setElevation_IF;

		private static Delegate cb_setFloatValue_ILjava_lang_String_F;

		private static Delegate cb_setGoneMargin_III;

		private static Delegate cb_setGuidelineBegin_II;

		private static Delegate cb_setGuidelineEnd_II;

		private static Delegate cb_setGuidelinePercent_IF;

		private static Delegate cb_setHorizontalBias_IF;

		private static Delegate cb_setHorizontalChainStyle_II;

		private static Delegate cb_setHorizontalWeight_IF;

		private static Delegate cb_setIntValue_ILjava_lang_String_I;

		private static Delegate cb_setMargin_III;

		private static Delegate cb_setReferencedIds_IarrayI;

		private static Delegate cb_setRotation_IF;

		private static Delegate cb_setRotationX_IF;

		private static Delegate cb_setRotationY_IF;

		private static Delegate cb_setScaleX_IF;

		private static Delegate cb_setScaleY_IF;

		private static Delegate cb_setStringValue_ILjava_lang_String_Ljava_lang_String_;

		private static Delegate cb_setTransformPivot_IFF;

		private static Delegate cb_setTransformPivotX_IF;

		private static Delegate cb_setTransformPivotY_IF;

		private static Delegate cb_setTranslation_IFF;

		private static Delegate cb_setTranslationX_IF;

		private static Delegate cb_setTranslationY_IF;

		private static Delegate cb_setTranslationZ_IF;

		private static Delegate cb_setValidateOnParse_Z;

		private static Delegate cb_setVerticalBias_IF;

		private static Delegate cb_setVerticalChainStyle_II;

		private static Delegate cb_setVerticalWeight_IF;

		private static Delegate cb_setVisibility_II;

		private static Delegate cb_setVisibilityMode_II;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IDictionary<string, ConstraintAttribute> CustomAttributeSet
		{
			[Register("getCustomAttributeSet", "()Ljava/util/HashMap;", "GetGetCustomAttributeSetHandler")]
			get
			{
				return JavaDictionary<string, ConstraintAttribute>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getCustomAttributeSet.()Ljava/util/HashMap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool ForceId
		{
			[Register("isForceId", "()Z", "GetIsForceIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isForceId.()Z", this, null);
			}
			[Register("setForceId", "(Z)V", "GetSetForceId_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setForceId.(Z)V", this, ptr);
			}
		}

		protected ConstraintSet(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ConstraintSet()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetCustomAttributeSetHandler()
		{
			if ((object)cb_getCustomAttributeSet == null)
			{
				cb_getCustomAttributeSet = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCustomAttributeSet));
			}
			return cb_getCustomAttributeSet;
		}

		private static IntPtr n_GetCustomAttributeSet(IntPtr jnienv, IntPtr native__this)
		{
			return JavaDictionary<string, ConstraintAttribute>.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomAttributeSet);
		}

		private static Delegate GetIsForceIdHandler()
		{
			if ((object)cb_isForceId == null)
			{
				cb_isForceId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsForceId));
			}
			return cb_isForceId;
		}

		private static bool n_IsForceId(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ForceId;
		}

		private static Delegate GetSetForceId_ZHandler()
		{
			if ((object)cb_setForceId_Z == null)
			{
				cb_setForceId_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetForceId_Z));
			}
			return cb_setForceId_Z;
		}

		private static void n_SetForceId_Z(IntPtr jnienv, IntPtr native__this, bool forceId)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ForceId = forceId;
		}

		private static Delegate GetAddColorAttributes_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_addColorAttributes_arrayLjava_lang_String_ == null)
			{
				cb_addColorAttributes_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddColorAttributes_arrayLjava_lang_String_));
			}
			return cb_addColorAttributes_arrayLjava_lang_String_;
		}

		private static void n_AddColorAttributes_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_attributeName)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attributeName, JniHandleOwnership.DoNotTransfer, typeof(string));
			constraintSet.AddColorAttributes(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attributeName);
			}
		}

		[Register("addColorAttributes", "([Ljava/lang/String;)V", "GetAddColorAttributes_arrayLjava_lang_String_Handler")]
		public unsafe virtual void AddColorAttributes(params string[] attributeName)
		{
			IntPtr intPtr = JNIEnv.NewArray(attributeName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addColorAttributes.([Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				if (attributeName != null)
				{
					JNIEnv.CopyArray(intPtr, attributeName);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(attributeName);
			}
		}

		private static Delegate GetAddFloatAttributes_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_addFloatAttributes_arrayLjava_lang_String_ == null)
			{
				cb_addFloatAttributes_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddFloatAttributes_arrayLjava_lang_String_));
			}
			return cb_addFloatAttributes_arrayLjava_lang_String_;
		}

		private static void n_AddFloatAttributes_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_attributeName)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attributeName, JniHandleOwnership.DoNotTransfer, typeof(string));
			constraintSet.AddFloatAttributes(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attributeName);
			}
		}

		[Register("addFloatAttributes", "([Ljava/lang/String;)V", "GetAddFloatAttributes_arrayLjava_lang_String_Handler")]
		public unsafe virtual void AddFloatAttributes(params string[] attributeName)
		{
			IntPtr intPtr = JNIEnv.NewArray(attributeName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addFloatAttributes.([Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				if (attributeName != null)
				{
					JNIEnv.CopyArray(intPtr, attributeName);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(attributeName);
			}
		}

		private static Delegate GetAddIntAttributes_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_addIntAttributes_arrayLjava_lang_String_ == null)
			{
				cb_addIntAttributes_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddIntAttributes_arrayLjava_lang_String_));
			}
			return cb_addIntAttributes_arrayLjava_lang_String_;
		}

		private static void n_AddIntAttributes_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_attributeName)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attributeName, JniHandleOwnership.DoNotTransfer, typeof(string));
			constraintSet.AddIntAttributes(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attributeName);
			}
		}

		[Register("addIntAttributes", "([Ljava/lang/String;)V", "GetAddIntAttributes_arrayLjava_lang_String_Handler")]
		public unsafe virtual void AddIntAttributes(params string[] attributeName)
		{
			IntPtr intPtr = JNIEnv.NewArray(attributeName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addIntAttributes.([Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				if (attributeName != null)
				{
					JNIEnv.CopyArray(intPtr, attributeName);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(attributeName);
			}
		}

		private static Delegate GetAddStringAttributes_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_addStringAttributes_arrayLjava_lang_String_ == null)
			{
				cb_addStringAttributes_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddStringAttributes_arrayLjava_lang_String_));
			}
			return cb_addStringAttributes_arrayLjava_lang_String_;
		}

		private static void n_AddStringAttributes_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_attributeName)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attributeName, JniHandleOwnership.DoNotTransfer, typeof(string));
			constraintSet.AddStringAttributes(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attributeName);
			}
		}

		[Register("addStringAttributes", "([Ljava/lang/String;)V", "GetAddStringAttributes_arrayLjava_lang_String_Handler")]
		public unsafe virtual void AddStringAttributes(params string[] attributeName)
		{
			IntPtr intPtr = JNIEnv.NewArray(attributeName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addStringAttributes.([Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				if (attributeName != null)
				{
					JNIEnv.CopyArray(intPtr, attributeName);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(attributeName);
			}
		}

		private static Delegate GetAddToHorizontalChain_IIIHandler()
		{
			if ((object)cb_addToHorizontalChain_III == null)
			{
				cb_addToHorizontalChain_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_V(n_AddToHorizontalChain_III));
			}
			return cb_addToHorizontalChain_III;
		}

		private static void n_AddToHorizontalChain_III(IntPtr jnienv, IntPtr native__this, int viewId, int leftId, int rightId)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddToHorizontalChain(viewId, leftId, rightId);
		}

		[Register("addToHorizontalChain", "(III)V", "GetAddToHorizontalChain_IIIHandler")]
		public unsafe virtual void AddToHorizontalChain(int viewId, int leftId, int rightId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(leftId);
			ptr[2] = new JniArgumentValue(rightId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addToHorizontalChain.(III)V", this, ptr);
		}

		private static Delegate GetAddToHorizontalChainRTL_IIIHandler()
		{
			if ((object)cb_addToHorizontalChainRTL_III == null)
			{
				cb_addToHorizontalChainRTL_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_V(n_AddToHorizontalChainRTL_III));
			}
			return cb_addToHorizontalChainRTL_III;
		}

		private static void n_AddToHorizontalChainRTL_III(IntPtr jnienv, IntPtr native__this, int viewId, int leftId, int rightId)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddToHorizontalChainRTL(viewId, leftId, rightId);
		}

		[Register("addToHorizontalChainRTL", "(III)V", "GetAddToHorizontalChainRTL_IIIHandler")]
		public unsafe virtual void AddToHorizontalChainRTL(int viewId, int leftId, int rightId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(leftId);
			ptr[2] = new JniArgumentValue(rightId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addToHorizontalChainRTL.(III)V", this, ptr);
		}

		private static Delegate GetAddToVerticalChain_IIIHandler()
		{
			if ((object)cb_addToVerticalChain_III == null)
			{
				cb_addToVerticalChain_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_V(n_AddToVerticalChain_III));
			}
			return cb_addToVerticalChain_III;
		}

		private static void n_AddToVerticalChain_III(IntPtr jnienv, IntPtr native__this, int viewId, int topId, int bottomId)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddToVerticalChain(viewId, topId, bottomId);
		}

		[Register("addToVerticalChain", "(III)V", "GetAddToVerticalChain_IIIHandler")]
		public unsafe virtual void AddToVerticalChain(int viewId, int topId, int bottomId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(topId);
			ptr[2] = new JniArgumentValue(bottomId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addToVerticalChain.(III)V", this, ptr);
		}

		private static Delegate GetApplyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_applyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_applyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ApplyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_applyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_ApplyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraintLayout)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(native_constraintLayout, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyCustomAttributes(constraintLayout);
		}

		[Register("applyCustomAttributes", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetApplyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		public unsafe virtual void ApplyCustomAttributes(ConstraintLayout constraintLayout)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constraintLayout?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("applyCustomAttributes.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintLayout);
			}
		}

		private static Delegate GetApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_applyTo_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_applyTo_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_applyTo_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_ApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraintLayout)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(native_constraintLayout, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyTo(constraintLayout);
		}

		[Register("applyTo", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		public unsafe virtual void ApplyTo(ConstraintLayout constraintLayout)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constraintLayout?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("applyTo.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintLayout);
			}
		}

		private static Delegate GetApplyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler()
		{
			if ((object)cb_applyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_ == null)
			{
				cb_applyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_ApplyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_));
			}
			return cb_applyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_;
		}

		private static void n_ApplyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_(IntPtr jnienv, IntPtr native__this, IntPtr native_helper, IntPtr native_child, IntPtr native_layoutParams, IntPtr native_mapIdToWidget)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintHelper helper = Java.Lang.Object.GetObject<ConstraintHelper>(native_helper, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget child = Java.Lang.Object.GetObject<ConstraintWidget>(native_child, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout.LayoutParams layoutParams = Java.Lang.Object.GetObject<ConstraintLayout.LayoutParams>(native_layoutParams, JniHandleOwnership.DoNotTransfer);
			SparseArray mapIdToWidget = Java.Lang.Object.GetObject<SparseArray>(native_mapIdToWidget, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyToHelper(helper, child, layoutParams, mapIdToWidget);
		}

		[Register("applyToHelper", "(Landroidx/constraintlayout/widget/ConstraintHelper;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", "GetApplyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler")]
		public unsafe virtual void ApplyToHelper(ConstraintHelper helper, ConstraintWidget child, ConstraintLayout.LayoutParams layoutParams, SparseArray mapIdToWidget)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(helper?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(layoutParams?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(mapIdToWidget?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("applyToHelper.(Landroidx/constraintlayout/widget/ConstraintHelper;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(helper);
				GC.KeepAlive(child);
				GC.KeepAlive(layoutParams);
				GC.KeepAlive(mapIdToWidget);
			}
		}

		private static Delegate GetApplyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Handler()
		{
			if ((object)cb_applyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_ == null)
			{
				cb_applyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_ApplyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_));
			}
			return cb_applyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_;
		}

		private static void n_ApplyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_(IntPtr jnienv, IntPtr native__this, int id, IntPtr native_layoutParams)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout.LayoutParams layoutParams = Java.Lang.Object.GetObject<ConstraintLayout.LayoutParams>(native_layoutParams, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyToLayoutParams(id, layoutParams);
		}

		[Register("applyToLayoutParams", "(ILandroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", "GetApplyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Handler")]
		public unsafe virtual void ApplyToLayoutParams(int id, ConstraintLayout.LayoutParams layoutParams)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(id);
				ptr[1] = new JniArgumentValue(layoutParams?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("applyToLayoutParams.(ILandroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(layoutParams);
			}
		}

		private static Delegate GetApplyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_applyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_applyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ApplyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_applyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_ApplyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraintLayout)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(native_constraintLayout, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyToWithoutCustom(constraintLayout);
		}

		[Register("applyToWithoutCustom", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetApplyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		public unsafe virtual void ApplyToWithoutCustom(ConstraintLayout constraintLayout)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constraintLayout?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("applyToWithoutCustom.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintLayout);
			}
		}

		private static Delegate GetCenter_IIIIIIIFHandler()
		{
			if ((object)cb_center_IIIIIIIF == null)
			{
				cb_center_IIIIIIIF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIIIIIF_V(n_Center_IIIIIIIF));
			}
			return cb_center_IIIIIIIF;
		}

		private static void n_Center_IIIIIIIF(IntPtr jnienv, IntPtr native__this, int centerID, int firstID, int firstSide, int firstMargin, int secondId, int secondSide, int secondMargin, float bias)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Center(centerID, firstID, firstSide, firstMargin, secondId, secondSide, secondMargin, bias);
		}

		[Register("center", "(IIIIIIIF)V", "GetCenter_IIIIIIIFHandler")]
		public unsafe virtual void Center(int centerID, int firstID, int firstSide, int firstMargin, int secondId, int secondSide, int secondMargin, float bias)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(centerID);
			ptr[1] = new JniArgumentValue(firstID);
			ptr[2] = new JniArgumentValue(firstSide);
			ptr[3] = new JniArgumentValue(firstMargin);
			ptr[4] = new JniArgumentValue(secondId);
			ptr[5] = new JniArgumentValue(secondSide);
			ptr[6] = new JniArgumentValue(secondMargin);
			ptr[7] = new JniArgumentValue(bias);
			_members.InstanceMethods.InvokeVirtualVoidMethod("center.(IIIIIIIF)V", this, ptr);
		}

		private static Delegate GetCenterHorizontally_IIHandler()
		{
			if ((object)cb_centerHorizontally_II == null)
			{
				cb_centerHorizontally_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_CenterHorizontally_II));
			}
			return cb_centerHorizontally_II;
		}

		private static void n_CenterHorizontally_II(IntPtr jnienv, IntPtr native__this, int viewId, int toView)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterHorizontally(viewId, toView);
		}

		[Register("centerHorizontally", "(II)V", "GetCenterHorizontally_IIHandler")]
		public unsafe virtual void CenterHorizontally(int viewId, int toView)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(toView);
			_members.InstanceMethods.InvokeVirtualVoidMethod("centerHorizontally.(II)V", this, ptr);
		}

		private static Delegate GetCenterHorizontally_IIIIIIIFHandler()
		{
			if ((object)cb_centerHorizontally_IIIIIIIF == null)
			{
				cb_centerHorizontally_IIIIIIIF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIIIIIF_V(n_CenterHorizontally_IIIIIIIF));
			}
			return cb_centerHorizontally_IIIIIIIF;
		}

		private static void n_CenterHorizontally_IIIIIIIF(IntPtr jnienv, IntPtr native__this, int centerID, int leftId, int leftSide, int leftMargin, int rightId, int rightSide, int rightMargin, float bias)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterHorizontally(centerID, leftId, leftSide, leftMargin, rightId, rightSide, rightMargin, bias);
		}

		[Register("centerHorizontally", "(IIIIIIIF)V", "GetCenterHorizontally_IIIIIIIFHandler")]
		public unsafe virtual void CenterHorizontally(int centerID, int leftId, int leftSide, int leftMargin, int rightId, int rightSide, int rightMargin, float bias)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(centerID);
			ptr[1] = new JniArgumentValue(leftId);
			ptr[2] = new JniArgumentValue(leftSide);
			ptr[3] = new JniArgumentValue(leftMargin);
			ptr[4] = new JniArgumentValue(rightId);
			ptr[5] = new JniArgumentValue(rightSide);
			ptr[6] = new JniArgumentValue(rightMargin);
			ptr[7] = new JniArgumentValue(bias);
			_members.InstanceMethods.InvokeVirtualVoidMethod("centerHorizontally.(IIIIIIIF)V", this, ptr);
		}

		private static Delegate GetCenterHorizontallyRtl_IIHandler()
		{
			if ((object)cb_centerHorizontallyRtl_II == null)
			{
				cb_centerHorizontallyRtl_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_CenterHorizontallyRtl_II));
			}
			return cb_centerHorizontallyRtl_II;
		}

		private static void n_CenterHorizontallyRtl_II(IntPtr jnienv, IntPtr native__this, int viewId, int toView)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterHorizontallyRtl(viewId, toView);
		}

		[Register("centerHorizontallyRtl", "(II)V", "GetCenterHorizontallyRtl_IIHandler")]
		public unsafe virtual void CenterHorizontallyRtl(int viewId, int toView)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(toView);
			_members.InstanceMethods.InvokeVirtualVoidMethod("centerHorizontallyRtl.(II)V", this, ptr);
		}

		private static Delegate GetCenterHorizontallyRtl_IIIIIIIFHandler()
		{
			if ((object)cb_centerHorizontallyRtl_IIIIIIIF == null)
			{
				cb_centerHorizontallyRtl_IIIIIIIF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIIIIIF_V(n_CenterHorizontallyRtl_IIIIIIIF));
			}
			return cb_centerHorizontallyRtl_IIIIIIIF;
		}

		private static void n_CenterHorizontallyRtl_IIIIIIIF(IntPtr jnienv, IntPtr native__this, int centerID, int startId, int startSide, int startMargin, int endId, int endSide, int endMargin, float bias)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterHorizontallyRtl(centerID, startId, startSide, startMargin, endId, endSide, endMargin, bias);
		}

		[Register("centerHorizontallyRtl", "(IIIIIIIF)V", "GetCenterHorizontallyRtl_IIIIIIIFHandler")]
		public unsafe virtual void CenterHorizontallyRtl(int centerID, int startId, int startSide, int startMargin, int endId, int endSide, int endMargin, float bias)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(centerID);
			ptr[1] = new JniArgumentValue(startId);
			ptr[2] = new JniArgumentValue(startSide);
			ptr[3] = new JniArgumentValue(startMargin);
			ptr[4] = new JniArgumentValue(endId);
			ptr[5] = new JniArgumentValue(endSide);
			ptr[6] = new JniArgumentValue(endMargin);
			ptr[7] = new JniArgumentValue(bias);
			_members.InstanceMethods.InvokeVirtualVoidMethod("centerHorizontallyRtl.(IIIIIIIF)V", this, ptr);
		}

		private static Delegate GetCenterVertically_IIHandler()
		{
			if ((object)cb_centerVertically_II == null)
			{
				cb_centerVertically_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_CenterVertically_II));
			}
			return cb_centerVertically_II;
		}

		private static void n_CenterVertically_II(IntPtr jnienv, IntPtr native__this, int viewId, int toView)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterVertically(viewId, toView);
		}

		[Register("centerVertically", "(II)V", "GetCenterVertically_IIHandler")]
		public unsafe virtual void CenterVertically(int viewId, int toView)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(toView);
			_members.InstanceMethods.InvokeVirtualVoidMethod("centerVertically.(II)V", this, ptr);
		}

		private static Delegate GetCenterVertically_IIIIIIIFHandler()
		{
			if ((object)cb_centerVertically_IIIIIIIF == null)
			{
				cb_centerVertically_IIIIIIIF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIIIIIF_V(n_CenterVertically_IIIIIIIF));
			}
			return cb_centerVertically_IIIIIIIF;
		}

		private static void n_CenterVertically_IIIIIIIF(IntPtr jnienv, IntPtr native__this, int centerID, int topId, int topSide, int topMargin, int bottomId, int bottomSide, int bottomMargin, float bias)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterVertically(centerID, topId, topSide, topMargin, bottomId, bottomSide, bottomMargin, bias);
		}

		[Register("centerVertically", "(IIIIIIIF)V", "GetCenterVertically_IIIIIIIFHandler")]
		public unsafe virtual void CenterVertically(int centerID, int topId, int topSide, int topMargin, int bottomId, int bottomSide, int bottomMargin, float bias)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(centerID);
			ptr[1] = new JniArgumentValue(topId);
			ptr[2] = new JniArgumentValue(topSide);
			ptr[3] = new JniArgumentValue(topMargin);
			ptr[4] = new JniArgumentValue(bottomId);
			ptr[5] = new JniArgumentValue(bottomSide);
			ptr[6] = new JniArgumentValue(bottomMargin);
			ptr[7] = new JniArgumentValue(bias);
			_members.InstanceMethods.InvokeVirtualVoidMethod("centerVertically.(IIIIIIIF)V", this, ptr);
		}

		private static Delegate GetClear_IHandler()
		{
			if ((object)cb_clear_I == null)
			{
				cb_clear_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_Clear_I));
			}
			return cb_clear_I;
		}

		private static void n_Clear_I(IntPtr jnienv, IntPtr native__this, int viewId)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear(viewId);
		}

		[Register("clear", "(I)V", "GetClear_IHandler")]
		public unsafe virtual void Clear(int viewId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.(I)V", this, ptr);
		}

		private static Delegate GetClear_IIHandler()
		{
			if ((object)cb_clear_II == null)
			{
				cb_clear_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_Clear_II));
			}
			return cb_clear_II;
		}

		private static void n_Clear_II(IntPtr jnienv, IntPtr native__this, int viewId, int anchor)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear(viewId, anchor);
		}

		[Register("clear", "(II)V", "GetClear_IIHandler")]
		public unsafe virtual void Clear(int viewId, int anchor)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(anchor);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.(II)V", this, ptr);
		}

		private static Delegate GetClone_Landroid_content_Context_IHandler()
		{
			if ((object)cb_clone_Landroid_content_Context_I == null)
			{
				cb_clone_Landroid_content_Context_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_Clone_Landroid_content_Context_I));
			}
			return cb_clone_Landroid_content_Context_I;
		}

		private static void n_Clone_Landroid_content_Context_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, int constraintLayoutId)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			constraintSet.Clone(context, constraintLayoutId);
		}

		[Register("clone", "(Landroid/content/Context;I)V", "GetClone_Landroid_content_Context_IHandler")]
		public unsafe virtual void Clone(Context context, int constraintLayoutId)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(constraintLayoutId);
				_members.InstanceMethods.InvokeVirtualVoidMethod("clone.(Landroid/content/Context;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetClone_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_clone_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_clone_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Clone_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_clone_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_Clone_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraintLayout)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(native_constraintLayout, JniHandleOwnership.DoNotTransfer);
			constraintSet.Clone(constraintLayout);
		}

		[Register("clone", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetClone_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		public unsafe virtual void Clone(ConstraintLayout constraintLayout)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constraintLayout?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("clone.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintLayout);
			}
		}

		private static Delegate GetClone_Landroidx_constraintlayout_widget_Constraints_Handler()
		{
			if ((object)cb_clone_Landroidx_constraintlayout_widget_Constraints_ == null)
			{
				cb_clone_Landroidx_constraintlayout_widget_Constraints_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Clone_Landroidx_constraintlayout_widget_Constraints_));
			}
			return cb_clone_Landroidx_constraintlayout_widget_Constraints_;
		}

		private static void n_Clone_Landroidx_constraintlayout_widget_Constraints_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraints)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Constraints constraints = Java.Lang.Object.GetObject<Constraints>(native_constraints, JniHandleOwnership.DoNotTransfer);
			constraintSet.Clone(constraints);
		}

		[Register("clone", "(Landroidx/constraintlayout/widget/Constraints;)V", "GetClone_Landroidx_constraintlayout_widget_Constraints_Handler")]
		public unsafe virtual void Clone(Constraints constraints)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constraints?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("clone.(Landroidx/constraintlayout/widget/Constraints;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraints);
			}
		}

		private static Delegate GetClone_Landroidx_constraintlayout_widget_ConstraintSet_Handler()
		{
			if ((object)cb_clone_Landroidx_constraintlayout_widget_ConstraintSet_ == null)
			{
				cb_clone_Landroidx_constraintlayout_widget_ConstraintSet_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Clone_Landroidx_constraintlayout_widget_ConstraintSet_));
			}
			return cb_clone_Landroidx_constraintlayout_widget_ConstraintSet_;
		}

		private static void n_Clone_Landroidx_constraintlayout_widget_ConstraintSet_(IntPtr jnienv, IntPtr native__this, IntPtr native_set)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet set = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			constraintSet.Clone(set);
		}

		[Register("clone", "(Landroidx/constraintlayout/widget/ConstraintSet;)V", "GetClone_Landroidx_constraintlayout_widget_ConstraintSet_Handler")]
		public unsafe virtual void Clone(ConstraintSet set)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("clone.(Landroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(set);
			}
		}

		private static Delegate GetConnect_IIIIHandler()
		{
			if ((object)cb_connect_IIII == null)
			{
				cb_connect_IIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIII_V(n_Connect_IIII));
			}
			return cb_connect_IIII;
		}

		private static void n_Connect_IIII(IntPtr jnienv, IntPtr native__this, int startID, int startSide, int endID, int endSide)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Connect(startID, startSide, endID, endSide);
		}

		[Register("connect", "(IIII)V", "GetConnect_IIIIHandler")]
		public unsafe virtual void Connect(int startID, int startSide, int endID, int endSide)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(startID);
			ptr[1] = new JniArgumentValue(startSide);
			ptr[2] = new JniArgumentValue(endID);
			ptr[3] = new JniArgumentValue(endSide);
			_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(IIII)V", this, ptr);
		}

		private static Delegate GetConnect_IIIIIHandler()
		{
			if ((object)cb_connect_IIIII == null)
			{
				cb_connect_IIIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIIII_V(n_Connect_IIIII));
			}
			return cb_connect_IIIII;
		}

		private static void n_Connect_IIIII(IntPtr jnienv, IntPtr native__this, int startID, int startSide, int endID, int endSide, int margin)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Connect(startID, startSide, endID, endSide, margin);
		}

		[Register("connect", "(IIIII)V", "GetConnect_IIIIIHandler")]
		public unsafe virtual void Connect(int startID, int startSide, int endID, int endSide, int margin)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(startID);
			ptr[1] = new JniArgumentValue(startSide);
			ptr[2] = new JniArgumentValue(endID);
			ptr[3] = new JniArgumentValue(endSide);
			ptr[4] = new JniArgumentValue(margin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(IIIII)V", this, ptr);
		}

		private static Delegate GetConstrainCircle_IIIFHandler()
		{
			if ((object)cb_constrainCircle_IIIF == null)
			{
				cb_constrainCircle_IIIF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIIF_V(n_ConstrainCircle_IIIF));
			}
			return cb_constrainCircle_IIIF;
		}

		private static void n_ConstrainCircle_IIIF(IntPtr jnienv, IntPtr native__this, int viewId, int id, int radius, float angle)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainCircle(viewId, id, radius, angle);
		}

		[Register("constrainCircle", "(IIIF)V", "GetConstrainCircle_IIIFHandler")]
		public unsafe virtual void ConstrainCircle(int viewId, int id, int radius, float angle)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(radius);
			ptr[3] = new JniArgumentValue(angle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainCircle.(IIIF)V", this, ptr);
		}

		private static Delegate GetConstrainDefaultHeight_IIHandler()
		{
			if ((object)cb_constrainDefaultHeight_II == null)
			{
				cb_constrainDefaultHeight_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_ConstrainDefaultHeight_II));
			}
			return cb_constrainDefaultHeight_II;
		}

		private static void n_ConstrainDefaultHeight_II(IntPtr jnienv, IntPtr native__this, int viewId, int height)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainDefaultHeight(viewId, height);
		}

		[Register("constrainDefaultHeight", "(II)V", "GetConstrainDefaultHeight_IIHandler")]
		public unsafe virtual void ConstrainDefaultHeight(int viewId, int height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(height);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainDefaultHeight.(II)V", this, ptr);
		}

		private static Delegate GetConstrainDefaultWidth_IIHandler()
		{
			if ((object)cb_constrainDefaultWidth_II == null)
			{
				cb_constrainDefaultWidth_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_ConstrainDefaultWidth_II));
			}
			return cb_constrainDefaultWidth_II;
		}

		private static void n_ConstrainDefaultWidth_II(IntPtr jnienv, IntPtr native__this, int viewId, int width)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainDefaultWidth(viewId, width);
		}

		[Register("constrainDefaultWidth", "(II)V", "GetConstrainDefaultWidth_IIHandler")]
		public unsafe virtual void ConstrainDefaultWidth(int viewId, int width)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(width);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainDefaultWidth.(II)V", this, ptr);
		}

		private static Delegate GetConstrainHeight_IIHandler()
		{
			if ((object)cb_constrainHeight_II == null)
			{
				cb_constrainHeight_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_ConstrainHeight_II));
			}
			return cb_constrainHeight_II;
		}

		private static void n_ConstrainHeight_II(IntPtr jnienv, IntPtr native__this, int viewId, int height)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainHeight(viewId, height);
		}

		[Register("constrainHeight", "(II)V", "GetConstrainHeight_IIHandler")]
		public unsafe virtual void ConstrainHeight(int viewId, int height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(height);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainHeight.(II)V", this, ptr);
		}

		private static Delegate GetConstrainMaxHeight_IIHandler()
		{
			if ((object)cb_constrainMaxHeight_II == null)
			{
				cb_constrainMaxHeight_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_ConstrainMaxHeight_II));
			}
			return cb_constrainMaxHeight_II;
		}

		private static void n_ConstrainMaxHeight_II(IntPtr jnienv, IntPtr native__this, int viewId, int height)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainMaxHeight(viewId, height);
		}

		[Register("constrainMaxHeight", "(II)V", "GetConstrainMaxHeight_IIHandler")]
		public unsafe virtual void ConstrainMaxHeight(int viewId, int height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(height);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainMaxHeight.(II)V", this, ptr);
		}

		private static Delegate GetConstrainMaxWidth_IIHandler()
		{
			if ((object)cb_constrainMaxWidth_II == null)
			{
				cb_constrainMaxWidth_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_ConstrainMaxWidth_II));
			}
			return cb_constrainMaxWidth_II;
		}

		private static void n_ConstrainMaxWidth_II(IntPtr jnienv, IntPtr native__this, int viewId, int width)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainMaxWidth(viewId, width);
		}

		[Register("constrainMaxWidth", "(II)V", "GetConstrainMaxWidth_IIHandler")]
		public unsafe virtual void ConstrainMaxWidth(int viewId, int width)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(width);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainMaxWidth.(II)V", this, ptr);
		}

		private static Delegate GetConstrainMinHeight_IIHandler()
		{
			if ((object)cb_constrainMinHeight_II == null)
			{
				cb_constrainMinHeight_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_ConstrainMinHeight_II));
			}
			return cb_constrainMinHeight_II;
		}

		private static void n_ConstrainMinHeight_II(IntPtr jnienv, IntPtr native__this, int viewId, int height)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainMinHeight(viewId, height);
		}

		[Register("constrainMinHeight", "(II)V", "GetConstrainMinHeight_IIHandler")]
		public unsafe virtual void ConstrainMinHeight(int viewId, int height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(height);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainMinHeight.(II)V", this, ptr);
		}

		private static Delegate GetConstrainMinWidth_IIHandler()
		{
			if ((object)cb_constrainMinWidth_II == null)
			{
				cb_constrainMinWidth_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_ConstrainMinWidth_II));
			}
			return cb_constrainMinWidth_II;
		}

		private static void n_ConstrainMinWidth_II(IntPtr jnienv, IntPtr native__this, int viewId, int width)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainMinWidth(viewId, width);
		}

		[Register("constrainMinWidth", "(II)V", "GetConstrainMinWidth_IIHandler")]
		public unsafe virtual void ConstrainMinWidth(int viewId, int width)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(width);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainMinWidth.(II)V", this, ptr);
		}

		private static Delegate GetConstrainPercentHeight_IFHandler()
		{
			if ((object)cb_constrainPercentHeight_IF == null)
			{
				cb_constrainPercentHeight_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_ConstrainPercentHeight_IF));
			}
			return cb_constrainPercentHeight_IF;
		}

		private static void n_ConstrainPercentHeight_IF(IntPtr jnienv, IntPtr native__this, int viewId, float percent)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainPercentHeight(viewId, percent);
		}

		[Register("constrainPercentHeight", "(IF)V", "GetConstrainPercentHeight_IFHandler")]
		public unsafe virtual void ConstrainPercentHeight(int viewId, float percent)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(percent);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainPercentHeight.(IF)V", this, ptr);
		}

		private static Delegate GetConstrainPercentWidth_IFHandler()
		{
			if ((object)cb_constrainPercentWidth_IF == null)
			{
				cb_constrainPercentWidth_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_ConstrainPercentWidth_IF));
			}
			return cb_constrainPercentWidth_IF;
		}

		private static void n_ConstrainPercentWidth_IF(IntPtr jnienv, IntPtr native__this, int viewId, float percent)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainPercentWidth(viewId, percent);
		}

		[Register("constrainPercentWidth", "(IF)V", "GetConstrainPercentWidth_IFHandler")]
		public unsafe virtual void ConstrainPercentWidth(int viewId, float percent)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(percent);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainPercentWidth.(IF)V", this, ptr);
		}

		private static Delegate GetConstrainWidth_IIHandler()
		{
			if ((object)cb_constrainWidth_II == null)
			{
				cb_constrainWidth_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_ConstrainWidth_II));
			}
			return cb_constrainWidth_II;
		}

		private static void n_ConstrainWidth_II(IntPtr jnienv, IntPtr native__this, int viewId, int width)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainWidth(viewId, width);
		}

		[Register("constrainWidth", "(II)V", "GetConstrainWidth_IIHandler")]
		public unsafe virtual void ConstrainWidth(int viewId, int width)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(width);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainWidth.(II)V", this, ptr);
		}

		private static Delegate GetConstrainedHeight_IZHandler()
		{
			if ((object)cb_constrainedHeight_IZ == null)
			{
				cb_constrainedHeight_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIZ_V(n_ConstrainedHeight_IZ));
			}
			return cb_constrainedHeight_IZ;
		}

		private static void n_ConstrainedHeight_IZ(IntPtr jnienv, IntPtr native__this, int viewId, bool constrained)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainedHeight(viewId, constrained);
		}

		[Register("constrainedHeight", "(IZ)V", "GetConstrainedHeight_IZHandler")]
		public unsafe virtual void ConstrainedHeight(int viewId, bool constrained)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(constrained);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainedHeight.(IZ)V", this, ptr);
		}

		private static Delegate GetConstrainedWidth_IZHandler()
		{
			if ((object)cb_constrainedWidth_IZ == null)
			{
				cb_constrainedWidth_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIZ_V(n_ConstrainedWidth_IZ));
			}
			return cb_constrainedWidth_IZ;
		}

		private static void n_ConstrainedWidth_IZ(IntPtr jnienv, IntPtr native__this, int viewId, bool constrained)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainedWidth(viewId, constrained);
		}

		[Register("constrainedWidth", "(IZ)V", "GetConstrainedWidth_IZHandler")]
		public unsafe virtual void ConstrainedWidth(int viewId, bool constrained)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(constrained);
			_members.InstanceMethods.InvokeVirtualVoidMethod("constrainedWidth.(IZ)V", this, ptr);
		}

		private static Delegate GetCreate_IIHandler()
		{
			if ((object)cb_create_II == null)
			{
				cb_create_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_Create_II));
			}
			return cb_create_II;
		}

		private static void n_Create_II(IntPtr jnienv, IntPtr native__this, int guidelineID, int orientation)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Create(guidelineID, orientation);
		}

		[Register("create", "(II)V", "GetCreate_IIHandler")]
		public unsafe virtual void Create(int guidelineID, int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(guidelineID);
			ptr[1] = new JniArgumentValue(orientation);
			_members.InstanceMethods.InvokeVirtualVoidMethod("create.(II)V", this, ptr);
		}

		private static Delegate GetCreateBarrier_IIIarrayIHandler()
		{
			if ((object)cb_createBarrier_IIIarrayI == null)
			{
				cb_createBarrier_IIIarrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIIL_V(n_CreateBarrier_IIIarrayI));
			}
			return cb_createBarrier_IIIarrayI;
		}

		private static void n_CreateBarrier_IIIarrayI(IntPtr jnienv, IntPtr native__this, int id, int direction, int margin, IntPtr native_referenced)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_referenced, JniHandleOwnership.DoNotTransfer, typeof(int));
			constraintSet.CreateBarrier(id, direction, margin, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_referenced);
			}
		}

		[Register("createBarrier", "(III[I)V", "GetCreateBarrier_IIIarrayIHandler")]
		public unsafe virtual void CreateBarrier(int id, int direction, int margin, params int[] referenced)
		{
			IntPtr intPtr = JNIEnv.NewArray(referenced);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(id);
				ptr[1] = new JniArgumentValue(direction);
				ptr[2] = new JniArgumentValue(margin);
				ptr[3] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("createBarrier.(III[I)V", this, ptr);
			}
			finally
			{
				if (referenced != null)
				{
					JNIEnv.CopyArray(intPtr, referenced);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(referenced);
			}
		}

		private static Delegate GetCreateHorizontalChain_IIIIarrayIarrayFIHandler()
		{
			if ((object)cb_createHorizontalChain_IIIIarrayIarrayFI == null)
			{
				cb_createHorizontalChain_IIIIarrayIarrayFI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIILLI_V(n_CreateHorizontalChain_IIIIarrayIarrayFI));
			}
			return cb_createHorizontalChain_IIIIarrayIarrayFI;
		}

		private static void n_CreateHorizontalChain_IIIIarrayIarrayFI(IntPtr jnienv, IntPtr native__this, int leftId, int leftSide, int rightId, int rightSide, IntPtr native_chainIds, IntPtr native_weights, int style)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_chainIds, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_weights, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintSet.CreateHorizontalChain(leftId, leftSide, rightId, rightSide, array, array2, style);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chainIds);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_weights);
			}
		}

		[Register("createHorizontalChain", "(IIII[I[FI)V", "GetCreateHorizontalChain_IIIIarrayIarrayFIHandler")]
		public unsafe virtual void CreateHorizontalChain(int leftId, int leftSide, int rightId, int rightSide, int[] chainIds, float[] weights, int style)
		{
			IntPtr intPtr = JNIEnv.NewArray(chainIds);
			IntPtr intPtr2 = JNIEnv.NewArray(weights);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(leftId);
				ptr[1] = new JniArgumentValue(leftSide);
				ptr[2] = new JniArgumentValue(rightId);
				ptr[3] = new JniArgumentValue(rightSide);
				ptr[4] = new JniArgumentValue(intPtr);
				ptr[5] = new JniArgumentValue(intPtr2);
				ptr[6] = new JniArgumentValue(style);
				_members.InstanceMethods.InvokeVirtualVoidMethod("createHorizontalChain.(IIII[I[FI)V", this, ptr);
			}
			finally
			{
				if (chainIds != null)
				{
					JNIEnv.CopyArray(intPtr, chainIds);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (weights != null)
				{
					JNIEnv.CopyArray(intPtr2, weights);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(chainIds);
				GC.KeepAlive(weights);
			}
		}

		private static Delegate GetCreateHorizontalChainRtl_IIIIarrayIarrayFIHandler()
		{
			if ((object)cb_createHorizontalChainRtl_IIIIarrayIarrayFI == null)
			{
				cb_createHorizontalChainRtl_IIIIarrayIarrayFI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIILLI_V(n_CreateHorizontalChainRtl_IIIIarrayIarrayFI));
			}
			return cb_createHorizontalChainRtl_IIIIarrayIarrayFI;
		}

		private static void n_CreateHorizontalChainRtl_IIIIarrayIarrayFI(IntPtr jnienv, IntPtr native__this, int startId, int startSide, int endId, int endSide, IntPtr native_chainIds, IntPtr native_weights, int style)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_chainIds, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_weights, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintSet.CreateHorizontalChainRtl(startId, startSide, endId, endSide, array, array2, style);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chainIds);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_weights);
			}
		}

		[Register("createHorizontalChainRtl", "(IIII[I[FI)V", "GetCreateHorizontalChainRtl_IIIIarrayIarrayFIHandler")]
		public unsafe virtual void CreateHorizontalChainRtl(int startId, int startSide, int endId, int endSide, int[] chainIds, float[] weights, int style)
		{
			IntPtr intPtr = JNIEnv.NewArray(chainIds);
			IntPtr intPtr2 = JNIEnv.NewArray(weights);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(startId);
				ptr[1] = new JniArgumentValue(startSide);
				ptr[2] = new JniArgumentValue(endId);
				ptr[3] = new JniArgumentValue(endSide);
				ptr[4] = new JniArgumentValue(intPtr);
				ptr[5] = new JniArgumentValue(intPtr2);
				ptr[6] = new JniArgumentValue(style);
				_members.InstanceMethods.InvokeVirtualVoidMethod("createHorizontalChainRtl.(IIII[I[FI)V", this, ptr);
			}
			finally
			{
				if (chainIds != null)
				{
					JNIEnv.CopyArray(intPtr, chainIds);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (weights != null)
				{
					JNIEnv.CopyArray(intPtr2, weights);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(chainIds);
				GC.KeepAlive(weights);
			}
		}

		private static Delegate GetCreateVerticalChain_IIIIarrayIarrayFIHandler()
		{
			if ((object)cb_createVerticalChain_IIIIarrayIarrayFI == null)
			{
				cb_createVerticalChain_IIIIarrayIarrayFI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIILLI_V(n_CreateVerticalChain_IIIIarrayIarrayFI));
			}
			return cb_createVerticalChain_IIIIarrayIarrayFI;
		}

		private static void n_CreateVerticalChain_IIIIarrayIarrayFI(IntPtr jnienv, IntPtr native__this, int topId, int topSide, int bottomId, int bottomSide, IntPtr native_chainIds, IntPtr native_weights, int style)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_chainIds, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_weights, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintSet.CreateVerticalChain(topId, topSide, bottomId, bottomSide, array, array2, style);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chainIds);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_weights);
			}
		}

		[Register("createVerticalChain", "(IIII[I[FI)V", "GetCreateVerticalChain_IIIIarrayIarrayFIHandler")]
		public unsafe virtual void CreateVerticalChain(int topId, int topSide, int bottomId, int bottomSide, int[] chainIds, float[] weights, int style)
		{
			IntPtr intPtr = JNIEnv.NewArray(chainIds);
			IntPtr intPtr2 = JNIEnv.NewArray(weights);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(topId);
				ptr[1] = new JniArgumentValue(topSide);
				ptr[2] = new JniArgumentValue(bottomId);
				ptr[3] = new JniArgumentValue(bottomSide);
				ptr[4] = new JniArgumentValue(intPtr);
				ptr[5] = new JniArgumentValue(intPtr2);
				ptr[6] = new JniArgumentValue(style);
				_members.InstanceMethods.InvokeVirtualVoidMethod("createVerticalChain.(IIII[I[FI)V", this, ptr);
			}
			finally
			{
				if (chainIds != null)
				{
					JNIEnv.CopyArray(intPtr, chainIds);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (weights != null)
				{
					JNIEnv.CopyArray(intPtr2, weights);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(chainIds);
				GC.KeepAlive(weights);
			}
		}

		private static Delegate GetDump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayIHandler()
		{
			if ((object)cb_dump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayI == null)
			{
				cb_dump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Dump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayI));
			}
			return cb_dump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayI;
		}

		private static void n_Dump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_scene, IntPtr native_ids)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionScene scene = Java.Lang.Object.GetObject<MotionScene>(native_scene, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_ids, JniHandleOwnership.DoNotTransfer, typeof(int));
			constraintSet.Dump(scene, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_ids);
			}
		}

		[Register("dump", "(Landroidx/constraintlayout/motion/widget/MotionScene;[I)V", "GetDump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayIHandler")]
		public unsafe virtual void Dump(MotionScene scene, params int[] ids)
		{
			IntPtr intPtr = JNIEnv.NewArray(ids);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(scene?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("dump.(Landroidx/constraintlayout/motion/widget/MotionScene;[I)V", this, ptr);
			}
			finally
			{
				if (ids != null)
				{
					JNIEnv.CopyArray(intPtr, ids);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(scene);
				GC.KeepAlive(ids);
			}
		}

		private static Delegate GetGetApplyElevation_IHandler()
		{
			if ((object)cb_getApplyElevation_I == null)
			{
				cb_getApplyElevation_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_GetApplyElevation_I));
			}
			return cb_getApplyElevation_I;
		}

		private static bool n_GetApplyElevation_I(IntPtr jnienv, IntPtr native__this, int viewId)
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetApplyElevation(viewId);
		}

		[Register("getApplyElevation", "(I)Z", "GetGetApplyElevation_IHandler")]
		public unsafe virtual bool GetApplyElevation(int viewId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewId);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getApplyElevation.(I)Z", this, ptr);
		}

		private static Delegate GetGetConstraint_IHandler()
		{
			if ((object)cb_getConstraint_I == null)
			{
				cb_getConstraint_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetConstraint_I));
			}
			return cb_getConstraint_I;
		}

		private static IntPtr n_GetConstraint_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetConstraint(id));
		}

		[Register("getConstraint", "(I)Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", "GetGetConstraint_IHandler")]
		public unsafe virtual Constraint GetConstraint(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<Constraint>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraint.(I)Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetHeight_IHandler()
		{
			if ((object)cb_getHeight_I == null)
			{
				cb_getHeight_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetHeight_I));
			}
			return cb_getHeight_I;
		}

		private static int n_GetHeight_I(IntPtr jnienv, IntPtr native__this, int viewId)
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHeight(viewId);
		}

		[Register("getHeight", "(I)I", "GetGetHeight_IHandler")]
		public unsafe virtual int GetHeight(int viewId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewId);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHeight.(I)I", this, ptr);
		}

		private static Delegate GetGetKnownIdsHandler()
		{
			if ((object)cb_getKnownIds == null)
			{
				cb_getKnownIds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetKnownIds));
			}
			return cb_getKnownIds;
		}

		private static IntPtr n_GetKnownIds(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetKnownIds());
		}

		[Register("getKnownIds", "()[I", "GetGetKnownIdsHandler")]
		public unsafe virtual int[] GetKnownIds()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getKnownIds.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		private static Delegate GetGetParameters_IHandler()
		{
			if ((object)cb_getParameters_I == null)
			{
				cb_getParameters_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetParameters_I));
			}
			return cb_getParameters_I;
		}

		private static IntPtr n_GetParameters_I(IntPtr jnienv, IntPtr native__this, int mId)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetParameters(mId));
		}

		[Register("getParameters", "(I)Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", "GetGetParameters_IHandler")]
		public unsafe virtual Constraint GetParameters(int mId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mId);
			return Java.Lang.Object.GetObject<Constraint>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParameters.(I)Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetReferencedIds_IHandler()
		{
			if ((object)cb_getReferencedIds_I == null)
			{
				cb_getReferencedIds_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetReferencedIds_I));
			}
			return cb_getReferencedIds_I;
		}

		private static IntPtr n_GetReferencedIds_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetReferencedIds(id));
		}

		[Register("getReferencedIds", "(I)[I", "GetGetReferencedIds_IHandler")]
		public unsafe virtual int[] GetReferencedIds(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getReferencedIds.(I)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		private static Delegate GetGetVisibility_IHandler()
		{
			if ((object)cb_getVisibility_I == null)
			{
				cb_getVisibility_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetVisibility_I));
			}
			return cb_getVisibility_I;
		}

		private static int n_GetVisibility_I(IntPtr jnienv, IntPtr native__this, int viewId)
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetVisibility(viewId);
		}

		[Register("getVisibility", "(I)I", "GetGetVisibility_IHandler")]
		public unsafe virtual int GetVisibility(int viewId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewId);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVisibility.(I)I", this, ptr);
		}

		private static Delegate GetGetVisibilityMode_IHandler()
		{
			if ((object)cb_getVisibilityMode_I == null)
			{
				cb_getVisibilityMode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetVisibilityMode_I));
			}
			return cb_getVisibilityMode_I;
		}

		private static int n_GetVisibilityMode_I(IntPtr jnienv, IntPtr native__this, int viewId)
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetVisibilityMode(viewId);
		}

		[Register("getVisibilityMode", "(I)I", "GetGetVisibilityMode_IHandler")]
		public unsafe virtual int GetVisibilityMode(int viewId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewId);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVisibilityMode.(I)I", this, ptr);
		}

		private static Delegate GetGetWidth_IHandler()
		{
			if ((object)cb_getWidth_I == null)
			{
				cb_getWidth_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetWidth_I));
			}
			return cb_getWidth_I;
		}

		private static int n_GetWidth_I(IntPtr jnienv, IntPtr native__this, int viewId)
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetWidth(viewId);
		}

		[Register("getWidth", "(I)I", "GetGetWidth_IHandler")]
		public unsafe virtual int GetWidth(int viewId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewId);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getWidth.(I)I", this, ptr);
		}

		private static Delegate GetLoad_Landroid_content_Context_IHandler()
		{
			if ((object)cb_load_Landroid_content_Context_I == null)
			{
				cb_load_Landroid_content_Context_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_Load_Landroid_content_Context_I));
			}
			return cb_load_Landroid_content_Context_I;
		}

		private static void n_Load_Landroid_content_Context_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, int resourceId)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			constraintSet.Load(context, resourceId);
		}

		[Register("load", "(Landroid/content/Context;I)V", "GetLoad_Landroid_content_Context_IHandler")]
		public unsafe virtual void Load(Context context, int resourceId)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(resourceId);
				_members.InstanceMethods.InvokeVirtualVoidMethod("load.(Landroid/content/Context;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetLoad_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_Handler()
		{
			if ((object)cb_load_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_ == null)
			{
				cb_load_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Load_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_));
			}
			return cb_load_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_;
		}

		private static void n_Load_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_parser)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			XmlReader parser = XmlPullParserReader.FromJniHandle(native_parser, JniHandleOwnership.DoNotTransfer);
			constraintSet.Load(context, parser);
		}

		[Register("load", "(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", "GetLoad_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_Handler")]
		public unsafe virtual void Load(Context context, XmlReader parser)
		{
			IntPtr intPtr = XmlReaderPullParser.ToLocalJniHandle(parser);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("load.(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(parser);
			}
		}

		private static Delegate GetParseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler()
		{
			if ((object)cb_parseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_ == null)
			{
				cb_parseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ParseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_));
			}
			return cb_parseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_;
		}

		private static void n_ParseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_set, IntPtr native_attributes)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Constraint set = Java.Lang.Object.GetObject<Constraint>(native_set, JniHandleOwnership.DoNotTransfer);
			string attributes = JNIEnv.GetString(native_attributes, JniHandleOwnership.DoNotTransfer);
			constraintSet.ParseColorAttributes(set, attributes);
		}

		[Register("parseColorAttributes", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", "GetParseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler")]
		public unsafe virtual void ParseColorAttributes(Constraint set, string attributes)
		{
			IntPtr intPtr = JNIEnv.NewString(attributes);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("parseColorAttributes.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(set);
			}
		}

		private static Delegate GetParseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler()
		{
			if ((object)cb_parseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_ == null)
			{
				cb_parseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ParseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_));
			}
			return cb_parseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_;
		}

		private static void n_ParseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_set, IntPtr native_attributes)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Constraint set = Java.Lang.Object.GetObject<Constraint>(native_set, JniHandleOwnership.DoNotTransfer);
			string attributes = JNIEnv.GetString(native_attributes, JniHandleOwnership.DoNotTransfer);
			constraintSet.ParseFloatAttributes(set, attributes);
		}

		[Register("parseFloatAttributes", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", "GetParseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler")]
		public unsafe virtual void ParseFloatAttributes(Constraint set, string attributes)
		{
			IntPtr intPtr = JNIEnv.NewString(attributes);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("parseFloatAttributes.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(set);
			}
		}

		private static Delegate GetParseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler()
		{
			if ((object)cb_parseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_ == null)
			{
				cb_parseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ParseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_));
			}
			return cb_parseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_;
		}

		private static void n_ParseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_set, IntPtr native_attributes)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Constraint set = Java.Lang.Object.GetObject<Constraint>(native_set, JniHandleOwnership.DoNotTransfer);
			string attributes = JNIEnv.GetString(native_attributes, JniHandleOwnership.DoNotTransfer);
			constraintSet.ParseIntAttributes(set, attributes);
		}

		[Register("parseIntAttributes", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", "GetParseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler")]
		public unsafe virtual void ParseIntAttributes(Constraint set, string attributes)
		{
			IntPtr intPtr = JNIEnv.NewString(attributes);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("parseIntAttributes.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(set);
			}
		}

		private static Delegate GetParseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler()
		{
			if ((object)cb_parseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_ == null)
			{
				cb_parseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ParseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_));
			}
			return cb_parseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_;
		}

		private static void n_ParseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_set, IntPtr native_attributes)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Constraint set = Java.Lang.Object.GetObject<Constraint>(native_set, JniHandleOwnership.DoNotTransfer);
			string attributes = JNIEnv.GetString(native_attributes, JniHandleOwnership.DoNotTransfer);
			constraintSet.ParseStringAttributes(set, attributes);
		}

		[Register("parseStringAttributes", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", "GetParseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler")]
		public unsafe virtual void ParseStringAttributes(Constraint set, string attributes)
		{
			IntPtr intPtr = JNIEnv.NewString(attributes);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("parseStringAttributes.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(set);
			}
		}

		private static Delegate GetReadFallback_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
		{
			if ((object)cb_readFallback_Landroidx_constraintlayout_widget_ConstraintLayout_ == null)
			{
				cb_readFallback_Landroidx_constraintlayout_widget_ConstraintLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReadFallback_Landroidx_constraintlayout_widget_ConstraintLayout_));
			}
			return cb_readFallback_Landroidx_constraintlayout_widget_ConstraintLayout_;
		}

		private static void n_ReadFallback_Landroidx_constraintlayout_widget_ConstraintLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraintLayout)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(native_constraintLayout, JniHandleOwnership.DoNotTransfer);
			constraintSet.ReadFallback(constraintLayout);
		}

		[Register("readFallback", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetReadFallback_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
		public unsafe virtual void ReadFallback(ConstraintLayout constraintLayout)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constraintLayout?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("readFallback.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintLayout);
			}
		}

		private static Delegate GetReadFallback_Landroidx_constraintlayout_widget_ConstraintSet_Handler()
		{
			if ((object)cb_readFallback_Landroidx_constraintlayout_widget_ConstraintSet_ == null)
			{
				cb_readFallback_Landroidx_constraintlayout_widget_ConstraintSet_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReadFallback_Landroidx_constraintlayout_widget_ConstraintSet_));
			}
			return cb_readFallback_Landroidx_constraintlayout_widget_ConstraintSet_;
		}

		private static void n_ReadFallback_Landroidx_constraintlayout_widget_ConstraintSet_(IntPtr jnienv, IntPtr native__this, IntPtr native_set)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet set = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			constraintSet.ReadFallback(set);
		}

		[Register("readFallback", "(Landroidx/constraintlayout/widget/ConstraintSet;)V", "GetReadFallback_Landroidx_constraintlayout_widget_ConstraintSet_Handler")]
		public unsafe virtual void ReadFallback(ConstraintSet set)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("readFallback.(Landroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(set);
			}
		}

		private static Delegate GetRemoveAttribute_Ljava_lang_String_Handler()
		{
			if ((object)cb_removeAttribute_Ljava_lang_String_ == null)
			{
				cb_removeAttribute_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveAttribute_Ljava_lang_String_));
			}
			return cb_removeAttribute_Ljava_lang_String_;
		}

		private static void n_RemoveAttribute_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_attributeName)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string attributeName = JNIEnv.GetString(native_attributeName, JniHandleOwnership.DoNotTransfer);
			constraintSet.RemoveAttribute(attributeName);
		}

		[Register("removeAttribute", "(Ljava/lang/String;)V", "GetRemoveAttribute_Ljava_lang_String_Handler")]
		public unsafe virtual void RemoveAttribute(string attributeName)
		{
			IntPtr intPtr = JNIEnv.NewString(attributeName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeAttribute.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetRemoveFromHorizontalChain_IHandler()
		{
			if ((object)cb_removeFromHorizontalChain_I == null)
			{
				cb_removeFromHorizontalChain_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_RemoveFromHorizontalChain_I));
			}
			return cb_removeFromHorizontalChain_I;
		}

		private static void n_RemoveFromHorizontalChain_I(IntPtr jnienv, IntPtr native__this, int viewId)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveFromHorizontalChain(viewId);
		}

		[Register("removeFromHorizontalChain", "(I)V", "GetRemoveFromHorizontalChain_IHandler")]
		public unsafe virtual void RemoveFromHorizontalChain(int viewId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeFromHorizontalChain.(I)V", this, ptr);
		}

		private static Delegate GetRemoveFromVerticalChain_IHandler()
		{
			if ((object)cb_removeFromVerticalChain_I == null)
			{
				cb_removeFromVerticalChain_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_RemoveFromVerticalChain_I));
			}
			return cb_removeFromVerticalChain_I;
		}

		private static void n_RemoveFromVerticalChain_I(IntPtr jnienv, IntPtr native__this, int viewId)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveFromVerticalChain(viewId);
		}

		[Register("removeFromVerticalChain", "(I)V", "GetRemoveFromVerticalChain_IHandler")]
		public unsafe virtual void RemoveFromVerticalChain(int viewId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeFromVerticalChain.(I)V", this, ptr);
		}

		private static Delegate GetSetAlpha_IFHandler()
		{
			if ((object)cb_setAlpha_IF == null)
			{
				cb_setAlpha_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetAlpha_IF));
			}
			return cb_setAlpha_IF;
		}

		private static void n_SetAlpha_IF(IntPtr jnienv, IntPtr native__this, int viewId, float alpha)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAlpha(viewId, alpha);
		}

		[Register("setAlpha", "(IF)V", "GetSetAlpha_IFHandler")]
		public unsafe virtual void SetAlpha(int viewId, float alpha)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(alpha);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAlpha.(IF)V", this, ptr);
		}

		private static Delegate GetSetApplyElevation_IZHandler()
		{
			if ((object)cb_setApplyElevation_IZ == null)
			{
				cb_setApplyElevation_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIZ_V(n_SetApplyElevation_IZ));
			}
			return cb_setApplyElevation_IZ;
		}

		private static void n_SetApplyElevation_IZ(IntPtr jnienv, IntPtr native__this, int viewId, bool apply)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetApplyElevation(viewId, apply);
		}

		[Register("setApplyElevation", "(IZ)V", "GetSetApplyElevation_IZHandler")]
		public unsafe virtual void SetApplyElevation(int viewId, bool apply)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(apply);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setApplyElevation.(IZ)V", this, ptr);
		}

		private static Delegate GetSetBarrierType_IIHandler()
		{
			if ((object)cb_setBarrierType_II == null)
			{
				cb_setBarrierType_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetBarrierType_II));
			}
			return cb_setBarrierType_II;
		}

		private static void n_SetBarrierType_II(IntPtr jnienv, IntPtr native__this, int id, int type)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBarrierType(id, type);
		}

		[Register("setBarrierType", "(II)V", "GetSetBarrierType_IIHandler")]
		public unsafe virtual void SetBarrierType(int id, int type)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBarrierType.(II)V", this, ptr);
		}

		private static Delegate GetSetColorValue_ILjava_lang_String_IHandler()
		{
			if ((object)cb_setColorValue_ILjava_lang_String_I == null)
			{
				cb_setColorValue_ILjava_lang_String_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPILI_V(n_SetColorValue_ILjava_lang_String_I));
			}
			return cb_setColorValue_ILjava_lang_String_I;
		}

		private static void n_SetColorValue_ILjava_lang_String_I(IntPtr jnienv, IntPtr native__this, int viewId, IntPtr native_attributeName, int value)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string attributeName = JNIEnv.GetString(native_attributeName, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetColorValue(viewId, attributeName, value);
		}

		[Register("setColorValue", "(ILjava/lang/String;I)V", "GetSetColorValue_ILjava_lang_String_IHandler")]
		public unsafe virtual void SetColorValue(int viewId, string attributeName, int value)
		{
			IntPtr intPtr = JNIEnv.NewString(attributeName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewId);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setColorValue.(ILjava/lang/String;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetDimensionRatio_ILjava_lang_String_Handler()
		{
			if ((object)cb_setDimensionRatio_ILjava_lang_String_ == null)
			{
				cb_setDimensionRatio_ILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_SetDimensionRatio_ILjava_lang_String_));
			}
			return cb_setDimensionRatio_ILjava_lang_String_;
		}

		private static void n_SetDimensionRatio_ILjava_lang_String_(IntPtr jnienv, IntPtr native__this, int viewId, IntPtr native_ratio)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string ratio = JNIEnv.GetString(native_ratio, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetDimensionRatio(viewId, ratio);
		}

		[Register("setDimensionRatio", "(ILjava/lang/String;)V", "GetSetDimensionRatio_ILjava_lang_String_Handler")]
		public unsafe virtual void SetDimensionRatio(int viewId, string ratio)
		{
			IntPtr intPtr = JNIEnv.NewString(ratio);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(viewId);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDimensionRatio.(ILjava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetEditorAbsoluteX_IIHandler()
		{
			if ((object)cb_setEditorAbsoluteX_II == null)
			{
				cb_setEditorAbsoluteX_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetEditorAbsoluteX_II));
			}
			return cb_setEditorAbsoluteX_II;
		}

		private static void n_SetEditorAbsoluteX_II(IntPtr jnienv, IntPtr native__this, int viewId, int position)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEditorAbsoluteX(viewId, position);
		}

		[Register("setEditorAbsoluteX", "(II)V", "GetSetEditorAbsoluteX_IIHandler")]
		public unsafe virtual void SetEditorAbsoluteX(int viewId, int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEditorAbsoluteX.(II)V", this, ptr);
		}

		private static Delegate GetSetEditorAbsoluteY_IIHandler()
		{
			if ((object)cb_setEditorAbsoluteY_II == null)
			{
				cb_setEditorAbsoluteY_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetEditorAbsoluteY_II));
			}
			return cb_setEditorAbsoluteY_II;
		}

		private static void n_SetEditorAbsoluteY_II(IntPtr jnienv, IntPtr native__this, int viewId, int position)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEditorAbsoluteY(viewId, position);
		}

		[Register("setEditorAbsoluteY", "(II)V", "GetSetEditorAbsoluteY_IIHandler")]
		public unsafe virtual void SetEditorAbsoluteY(int viewId, int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEditorAbsoluteY.(II)V", this, ptr);
		}

		private static Delegate GetSetElevation_IFHandler()
		{
			if ((object)cb_setElevation_IF == null)
			{
				cb_setElevation_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetElevation_IF));
			}
			return cb_setElevation_IF;
		}

		private static void n_SetElevation_IF(IntPtr jnienv, IntPtr native__this, int viewId, float elevation)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetElevation(viewId, elevation);
		}

		[Register("setElevation", "(IF)V", "GetSetElevation_IFHandler")]
		public unsafe virtual void SetElevation(int viewId, float elevation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(elevation);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setElevation.(IF)V", this, ptr);
		}

		private static Delegate GetSetFloatValue_ILjava_lang_String_FHandler()
		{
			if ((object)cb_setFloatValue_ILjava_lang_String_F == null)
			{
				cb_setFloatValue_ILjava_lang_String_F = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPILF_V(n_SetFloatValue_ILjava_lang_String_F));
			}
			return cb_setFloatValue_ILjava_lang_String_F;
		}

		private static void n_SetFloatValue_ILjava_lang_String_F(IntPtr jnienv, IntPtr native__this, int viewId, IntPtr native_attributeName, float value)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string attributeName = JNIEnv.GetString(native_attributeName, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetFloatValue(viewId, attributeName, value);
		}

		[Register("setFloatValue", "(ILjava/lang/String;F)V", "GetSetFloatValue_ILjava_lang_String_FHandler")]
		public unsafe virtual void SetFloatValue(int viewId, string attributeName, float value)
		{
			IntPtr intPtr = JNIEnv.NewString(attributeName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewId);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setFloatValue.(ILjava/lang/String;F)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetGoneMargin_IIIHandler()
		{
			if ((object)cb_setGoneMargin_III == null)
			{
				cb_setGoneMargin_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_V(n_SetGoneMargin_III));
			}
			return cb_setGoneMargin_III;
		}

		private static void n_SetGoneMargin_III(IntPtr jnienv, IntPtr native__this, int viewId, int anchor, int value)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGoneMargin(viewId, anchor, value);
		}

		[Register("setGoneMargin", "(III)V", "GetSetGoneMargin_IIIHandler")]
		public unsafe virtual void SetGoneMargin(int viewId, int anchor, int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(anchor);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGoneMargin.(III)V", this, ptr);
		}

		private static Delegate GetSetGuidelineBegin_IIHandler()
		{
			if ((object)cb_setGuidelineBegin_II == null)
			{
				cb_setGuidelineBegin_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetGuidelineBegin_II));
			}
			return cb_setGuidelineBegin_II;
		}

		private static void n_SetGuidelineBegin_II(IntPtr jnienv, IntPtr native__this, int guidelineID, int margin)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidelineBegin(guidelineID, margin);
		}

		[Register("setGuidelineBegin", "(II)V", "GetSetGuidelineBegin_IIHandler")]
		public unsafe virtual void SetGuidelineBegin(int guidelineID, int margin)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(guidelineID);
			ptr[1] = new JniArgumentValue(margin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidelineBegin.(II)V", this, ptr);
		}

		private static Delegate GetSetGuidelineEnd_IIHandler()
		{
			if ((object)cb_setGuidelineEnd_II == null)
			{
				cb_setGuidelineEnd_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetGuidelineEnd_II));
			}
			return cb_setGuidelineEnd_II;
		}

		private static void n_SetGuidelineEnd_II(IntPtr jnienv, IntPtr native__this, int guidelineID, int margin)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidelineEnd(guidelineID, margin);
		}

		[Register("setGuidelineEnd", "(II)V", "GetSetGuidelineEnd_IIHandler")]
		public unsafe virtual void SetGuidelineEnd(int guidelineID, int margin)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(guidelineID);
			ptr[1] = new JniArgumentValue(margin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidelineEnd.(II)V", this, ptr);
		}

		private static Delegate GetSetGuidelinePercent_IFHandler()
		{
			if ((object)cb_setGuidelinePercent_IF == null)
			{
				cb_setGuidelinePercent_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetGuidelinePercent_IF));
			}
			return cb_setGuidelinePercent_IF;
		}

		private static void n_SetGuidelinePercent_IF(IntPtr jnienv, IntPtr native__this, int guidelineID, float ratio)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidelinePercent(guidelineID, ratio);
		}

		[Register("setGuidelinePercent", "(IF)V", "GetSetGuidelinePercent_IFHandler")]
		public unsafe virtual void SetGuidelinePercent(int guidelineID, float ratio)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(guidelineID);
			ptr[1] = new JniArgumentValue(ratio);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidelinePercent.(IF)V", this, ptr);
		}

		private static Delegate GetSetHorizontalBias_IFHandler()
		{
			if ((object)cb_setHorizontalBias_IF == null)
			{
				cb_setHorizontalBias_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetHorizontalBias_IF));
			}
			return cb_setHorizontalBias_IF;
		}

		private static void n_SetHorizontalBias_IF(IntPtr jnienv, IntPtr native__this, int viewId, float bias)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalBias(viewId, bias);
		}

		[Register("setHorizontalBias", "(IF)V", "GetSetHorizontalBias_IFHandler")]
		public unsafe virtual void SetHorizontalBias(int viewId, float bias)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(bias);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalBias.(IF)V", this, ptr);
		}

		private static Delegate GetSetHorizontalChainStyle_IIHandler()
		{
			if ((object)cb_setHorizontalChainStyle_II == null)
			{
				cb_setHorizontalChainStyle_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetHorizontalChainStyle_II));
			}
			return cb_setHorizontalChainStyle_II;
		}

		private static void n_SetHorizontalChainStyle_II(IntPtr jnienv, IntPtr native__this, int viewId, int chainStyle)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalChainStyle(viewId, chainStyle);
		}

		[Register("setHorizontalChainStyle", "(II)V", "GetSetHorizontalChainStyle_IIHandler")]
		public unsafe virtual void SetHorizontalChainStyle(int viewId, int chainStyle)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(chainStyle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalChainStyle.(II)V", this, ptr);
		}

		private static Delegate GetSetHorizontalWeight_IFHandler()
		{
			if ((object)cb_setHorizontalWeight_IF == null)
			{
				cb_setHorizontalWeight_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetHorizontalWeight_IF));
			}
			return cb_setHorizontalWeight_IF;
		}

		private static void n_SetHorizontalWeight_IF(IntPtr jnienv, IntPtr native__this, int viewId, float weight)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalWeight(viewId, weight);
		}

		[Register("setHorizontalWeight", "(IF)V", "GetSetHorizontalWeight_IFHandler")]
		public unsafe virtual void SetHorizontalWeight(int viewId, float weight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(weight);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalWeight.(IF)V", this, ptr);
		}

		private static Delegate GetSetIntValue_ILjava_lang_String_IHandler()
		{
			if ((object)cb_setIntValue_ILjava_lang_String_I == null)
			{
				cb_setIntValue_ILjava_lang_String_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPILI_V(n_SetIntValue_ILjava_lang_String_I));
			}
			return cb_setIntValue_ILjava_lang_String_I;
		}

		private static void n_SetIntValue_ILjava_lang_String_I(IntPtr jnienv, IntPtr native__this, int viewId, IntPtr native_attributeName, int value)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string attributeName = JNIEnv.GetString(native_attributeName, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetIntValue(viewId, attributeName, value);
		}

		[Register("setIntValue", "(ILjava/lang/String;I)V", "GetSetIntValue_ILjava_lang_String_IHandler")]
		public unsafe virtual void SetIntValue(int viewId, string attributeName, int value)
		{
			IntPtr intPtr = JNIEnv.NewString(attributeName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewId);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIntValue.(ILjava/lang/String;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetMargin_IIIHandler()
		{
			if ((object)cb_setMargin_III == null)
			{
				cb_setMargin_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_V(n_SetMargin_III));
			}
			return cb_setMargin_III;
		}

		private static void n_SetMargin_III(IntPtr jnienv, IntPtr native__this, int viewId, int anchor, int value)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMargin(viewId, anchor, value);
		}

		[Register("setMargin", "(III)V", "GetSetMargin_IIIHandler")]
		public unsafe virtual void SetMargin(int viewId, int anchor, int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(anchor);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMargin.(III)V", this, ptr);
		}

		private static Delegate GetSetReferencedIds_IarrayIHandler()
		{
			if ((object)cb_setReferencedIds_IarrayI == null)
			{
				cb_setReferencedIds_IarrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_SetReferencedIds_IarrayI));
			}
			return cb_setReferencedIds_IarrayI;
		}

		private static void n_SetReferencedIds_IarrayI(IntPtr jnienv, IntPtr native__this, int id, IntPtr native_referenced)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_referenced, JniHandleOwnership.DoNotTransfer, typeof(int));
			constraintSet.SetReferencedIds(id, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_referenced);
			}
		}

		[Register("setReferencedIds", "(I[I)V", "GetSetReferencedIds_IarrayIHandler")]
		public unsafe virtual void SetReferencedIds(int id, params int[] referenced)
		{
			IntPtr intPtr = JNIEnv.NewArray(referenced);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(id);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setReferencedIds.(I[I)V", this, ptr);
			}
			finally
			{
				if (referenced != null)
				{
					JNIEnv.CopyArray(intPtr, referenced);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(referenced);
			}
		}

		private static Delegate GetSetRotation_IFHandler()
		{
			if ((object)cb_setRotation_IF == null)
			{
				cb_setRotation_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetRotation_IF));
			}
			return cb_setRotation_IF;
		}

		private static void n_SetRotation_IF(IntPtr jnienv, IntPtr native__this, int viewId, float rotation)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotation(viewId, rotation);
		}

		[Register("setRotation", "(IF)V", "GetSetRotation_IFHandler")]
		public unsafe virtual void SetRotation(int viewId, float rotation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(rotation);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRotation.(IF)V", this, ptr);
		}

		private static Delegate GetSetRotationX_IFHandler()
		{
			if ((object)cb_setRotationX_IF == null)
			{
				cb_setRotationX_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetRotationX_IF));
			}
			return cb_setRotationX_IF;
		}

		private static void n_SetRotationX_IF(IntPtr jnienv, IntPtr native__this, int viewId, float rotationX)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotationX(viewId, rotationX);
		}

		[Register("setRotationX", "(IF)V", "GetSetRotationX_IFHandler")]
		public unsafe virtual void SetRotationX(int viewId, float rotationX)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(rotationX);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRotationX.(IF)V", this, ptr);
		}

		private static Delegate GetSetRotationY_IFHandler()
		{
			if ((object)cb_setRotationY_IF == null)
			{
				cb_setRotationY_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetRotationY_IF));
			}
			return cb_setRotationY_IF;
		}

		private static void n_SetRotationY_IF(IntPtr jnienv, IntPtr native__this, int viewId, float rotationY)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotationY(viewId, rotationY);
		}

		[Register("setRotationY", "(IF)V", "GetSetRotationY_IFHandler")]
		public unsafe virtual void SetRotationY(int viewId, float rotationY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(rotationY);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRotationY.(IF)V", this, ptr);
		}

		private static Delegate GetSetScaleX_IFHandler()
		{
			if ((object)cb_setScaleX_IF == null)
			{
				cb_setScaleX_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetScaleX_IF));
			}
			return cb_setScaleX_IF;
		}

		private static void n_SetScaleX_IF(IntPtr jnienv, IntPtr native__this, int viewId, float scaleX)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScaleX(viewId, scaleX);
		}

		[Register("setScaleX", "(IF)V", "GetSetScaleX_IFHandler")]
		public unsafe virtual void SetScaleX(int viewId, float scaleX)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(scaleX);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScaleX.(IF)V", this, ptr);
		}

		private static Delegate GetSetScaleY_IFHandler()
		{
			if ((object)cb_setScaleY_IF == null)
			{
				cb_setScaleY_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetScaleY_IF));
			}
			return cb_setScaleY_IF;
		}

		private static void n_SetScaleY_IF(IntPtr jnienv, IntPtr native__this, int viewId, float scaleY)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScaleY(viewId, scaleY);
		}

		[Register("setScaleY", "(IF)V", "GetSetScaleY_IFHandler")]
		public unsafe virtual void SetScaleY(int viewId, float scaleY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(scaleY);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScaleY.(IF)V", this, ptr);
		}

		private static Delegate GetSetStringValue_ILjava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_setStringValue_ILjava_lang_String_Ljava_lang_String_ == null)
			{
				cb_setStringValue_ILjava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_V(n_SetStringValue_ILjava_lang_String_Ljava_lang_String_));
			}
			return cb_setStringValue_ILjava_lang_String_Ljava_lang_String_;
		}

		private static void n_SetStringValue_ILjava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, int viewId, IntPtr native_attributeName, IntPtr native_value)
		{
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string attributeName = JNIEnv.GetString(native_attributeName, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetStringValue(viewId, attributeName, value);
		}

		[Register("setStringValue", "(ILjava/lang/String;Ljava/lang/String;)V", "GetSetStringValue_ILjava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual void SetStringValue(int viewId, string attributeName, string value)
		{
			IntPtr intPtr = JNIEnv.NewString(attributeName);
			IntPtr intPtr2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewId);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStringValue.(ILjava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		private static Delegate GetSetTransformPivot_IFFHandler()
		{
			if ((object)cb_setTransformPivot_IFF == null)
			{
				cb_setTransformPivot_IFF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIFF_V(n_SetTransformPivot_IFF));
			}
			return cb_setTransformPivot_IFF;
		}

		private static void n_SetTransformPivot_IFF(IntPtr jnienv, IntPtr native__this, int viewId, float transformPivotX, float transformPivotY)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransformPivot(viewId, transformPivotX, transformPivotY);
		}

		[Register("setTransformPivot", "(IFF)V", "GetSetTransformPivot_IFFHandler")]
		public unsafe virtual void SetTransformPivot(int viewId, float transformPivotX, float transformPivotY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(transformPivotX);
			ptr[2] = new JniArgumentValue(transformPivotY);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransformPivot.(IFF)V", this, ptr);
		}

		private static Delegate GetSetTransformPivotX_IFHandler()
		{
			if ((object)cb_setTransformPivotX_IF == null)
			{
				cb_setTransformPivotX_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetTransformPivotX_IF));
			}
			return cb_setTransformPivotX_IF;
		}

		private static void n_SetTransformPivotX_IF(IntPtr jnienv, IntPtr native__this, int viewId, float transformPivotX)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransformPivotX(viewId, transformPivotX);
		}

		[Register("setTransformPivotX", "(IF)V", "GetSetTransformPivotX_IFHandler")]
		public unsafe virtual void SetTransformPivotX(int viewId, float transformPivotX)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(transformPivotX);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransformPivotX.(IF)V", this, ptr);
		}

		private static Delegate GetSetTransformPivotY_IFHandler()
		{
			if ((object)cb_setTransformPivotY_IF == null)
			{
				cb_setTransformPivotY_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetTransformPivotY_IF));
			}
			return cb_setTransformPivotY_IF;
		}

		private static void n_SetTransformPivotY_IF(IntPtr jnienv, IntPtr native__this, int viewId, float transformPivotY)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransformPivotY(viewId, transformPivotY);
		}

		[Register("setTransformPivotY", "(IF)V", "GetSetTransformPivotY_IFHandler")]
		public unsafe virtual void SetTransformPivotY(int viewId, float transformPivotY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(transformPivotY);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransformPivotY.(IF)V", this, ptr);
		}

		private static Delegate GetSetTranslation_IFFHandler()
		{
			if ((object)cb_setTranslation_IFF == null)
			{
				cb_setTranslation_IFF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIFF_V(n_SetTranslation_IFF));
			}
			return cb_setTranslation_IFF;
		}

		private static void n_SetTranslation_IFF(IntPtr jnienv, IntPtr native__this, int viewId, float translationX, float translationY)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTranslation(viewId, translationX, translationY);
		}

		[Register("setTranslation", "(IFF)V", "GetSetTranslation_IFFHandler")]
		public unsafe virtual void SetTranslation(int viewId, float translationX, float translationY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(translationX);
			ptr[2] = new JniArgumentValue(translationY);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslation.(IFF)V", this, ptr);
		}

		private static Delegate GetSetTranslationX_IFHandler()
		{
			if ((object)cb_setTranslationX_IF == null)
			{
				cb_setTranslationX_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetTranslationX_IF));
			}
			return cb_setTranslationX_IF;
		}

		private static void n_SetTranslationX_IF(IntPtr jnienv, IntPtr native__this, int viewId, float translationX)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTranslationX(viewId, translationX);
		}

		[Register("setTranslationX", "(IF)V", "GetSetTranslationX_IFHandler")]
		public unsafe virtual void SetTranslationX(int viewId, float translationX)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(translationX);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationX.(IF)V", this, ptr);
		}

		private static Delegate GetSetTranslationY_IFHandler()
		{
			if ((object)cb_setTranslationY_IF == null)
			{
				cb_setTranslationY_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetTranslationY_IF));
			}
			return cb_setTranslationY_IF;
		}

		private static void n_SetTranslationY_IF(IntPtr jnienv, IntPtr native__this, int viewId, float translationY)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTranslationY(viewId, translationY);
		}

		[Register("setTranslationY", "(IF)V", "GetSetTranslationY_IFHandler")]
		public unsafe virtual void SetTranslationY(int viewId, float translationY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(translationY);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationY.(IF)V", this, ptr);
		}

		private static Delegate GetSetTranslationZ_IFHandler()
		{
			if ((object)cb_setTranslationZ_IF == null)
			{
				cb_setTranslationZ_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetTranslationZ_IF));
			}
			return cb_setTranslationZ_IF;
		}

		private static void n_SetTranslationZ_IF(IntPtr jnienv, IntPtr native__this, int viewId, float translationZ)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTranslationZ(viewId, translationZ);
		}

		[Register("setTranslationZ", "(IF)V", "GetSetTranslationZ_IFHandler")]
		public unsafe virtual void SetTranslationZ(int viewId, float translationZ)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(translationZ);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationZ.(IF)V", this, ptr);
		}

		private static Delegate GetSetValidateOnParse_ZHandler()
		{
			if ((object)cb_setValidateOnParse_Z == null)
			{
				cb_setValidateOnParse_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetValidateOnParse_Z));
			}
			return cb_setValidateOnParse_Z;
		}

		private static void n_SetValidateOnParse_Z(IntPtr jnienv, IntPtr native__this, bool validate)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValidateOnParse(validate);
		}

		[Register("setValidateOnParse", "(Z)V", "GetSetValidateOnParse_ZHandler")]
		public unsafe virtual void SetValidateOnParse(bool validate)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(validate);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setValidateOnParse.(Z)V", this, ptr);
		}

		private static Delegate GetSetVerticalBias_IFHandler()
		{
			if ((object)cb_setVerticalBias_IF == null)
			{
				cb_setVerticalBias_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetVerticalBias_IF));
			}
			return cb_setVerticalBias_IF;
		}

		private static void n_SetVerticalBias_IF(IntPtr jnienv, IntPtr native__this, int viewId, float bias)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalBias(viewId, bias);
		}

		[Register("setVerticalBias", "(IF)V", "GetSetVerticalBias_IFHandler")]
		public unsafe virtual void SetVerticalBias(int viewId, float bias)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(bias);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalBias.(IF)V", this, ptr);
		}

		private static Delegate GetSetVerticalChainStyle_IIHandler()
		{
			if ((object)cb_setVerticalChainStyle_II == null)
			{
				cb_setVerticalChainStyle_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetVerticalChainStyle_II));
			}
			return cb_setVerticalChainStyle_II;
		}

		private static void n_SetVerticalChainStyle_II(IntPtr jnienv, IntPtr native__this, int viewId, int chainStyle)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalChainStyle(viewId, chainStyle);
		}

		[Register("setVerticalChainStyle", "(II)V", "GetSetVerticalChainStyle_IIHandler")]
		public unsafe virtual void SetVerticalChainStyle(int viewId, int chainStyle)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(chainStyle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalChainStyle.(II)V", this, ptr);
		}

		private static Delegate GetSetVerticalWeight_IFHandler()
		{
			if ((object)cb_setVerticalWeight_IF == null)
			{
				cb_setVerticalWeight_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetVerticalWeight_IF));
			}
			return cb_setVerticalWeight_IF;
		}

		private static void n_SetVerticalWeight_IF(IntPtr jnienv, IntPtr native__this, int viewId, float weight)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalWeight(viewId, weight);
		}

		[Register("setVerticalWeight", "(IF)V", "GetSetVerticalWeight_IFHandler")]
		public unsafe virtual void SetVerticalWeight(int viewId, float weight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(weight);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalWeight.(IF)V", this, ptr);
		}

		private static Delegate GetSetVisibility_IIHandler()
		{
			if ((object)cb_setVisibility_II == null)
			{
				cb_setVisibility_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetVisibility_II));
			}
			return cb_setVisibility_II;
		}

		private static void n_SetVisibility_II(IntPtr jnienv, IntPtr native__this, int viewId, int visibility)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVisibility(viewId, visibility);
		}

		[Register("setVisibility", "(II)V", "GetSetVisibility_IIHandler")]
		public unsafe virtual void SetVisibility(int viewId, int visibility)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(visibility);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVisibility.(II)V", this, ptr);
		}

		private static Delegate GetSetVisibilityMode_IIHandler()
		{
			if ((object)cb_setVisibilityMode_II == null)
			{
				cb_setVisibilityMode_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetVisibilityMode_II));
			}
			return cb_setVisibilityMode_II;
		}

		private static void n_SetVisibilityMode_II(IntPtr jnienv, IntPtr native__this, int viewId, int visibilityMode)
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVisibilityMode(viewId, visibilityMode);
		}

		[Register("setVisibilityMode", "(II)V", "GetSetVisibilityMode_IIHandler")]
		public unsafe virtual void SetVisibilityMode(int viewId, int visibilityMode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(visibilityMode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVisibilityMode.(II)V", this, ptr);
		}
	}
	[Register("androidx/constraintlayout/widget/Group", DoNotGenerateAcw = true)]
	public class Group : ConstraintHelper
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/Group", typeof(Group));

		private static Delegate cb_onAttachedToWindow;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Group(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe Group(Context context)
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
		public unsafe Group(Context context, IAttributeSet attrs)
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
		public unsafe Group(Context context, IAttributeSet attrs, int defStyleAttr)
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
			Java.Lang.Object.GetObject<Group>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAttachedToWindow();
		}

		[Register("onAttachedToWindow", "()V", "GetOnAttachedToWindowHandler")]
		public new unsafe virtual void OnAttachedToWindow()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToWindow.()V", this, null);
		}
	}
	[Register("androidx/constraintlayout/widget/Guideline", DoNotGenerateAcw = true)]
	public class Guideline : View
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/Guideline", typeof(Guideline));

		private static Delegate cb_setGuidelineBegin_I;

		private static Delegate cb_setGuidelineEnd_I;

		private static Delegate cb_setGuidelinePercent_F;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Guideline(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe Guideline(Context context)
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
		public unsafe Guideline(Context context, IAttributeSet attrs)
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
		public unsafe Guideline(Context context, IAttributeSet attrs, int defStyleAttr)
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

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
		public unsafe Guideline(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
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

		private static Delegate GetSetGuidelineBegin_IHandler()
		{
			if ((object)cb_setGuidelineBegin_I == null)
			{
				cb_setGuidelineBegin_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetGuidelineBegin_I));
			}
			return cb_setGuidelineBegin_I;
		}

		private static void n_SetGuidelineBegin_I(IntPtr jnienv, IntPtr native__this, int margin)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidelineBegin(margin);
		}

		[Register("setGuidelineBegin", "(I)V", "GetSetGuidelineBegin_IHandler")]
		public unsafe virtual void SetGuidelineBegin(int margin)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(margin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidelineBegin.(I)V", this, ptr);
		}

		private static Delegate GetSetGuidelineEnd_IHandler()
		{
			if ((object)cb_setGuidelineEnd_I == null)
			{
				cb_setGuidelineEnd_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetGuidelineEnd_I));
			}
			return cb_setGuidelineEnd_I;
		}

		private static void n_SetGuidelineEnd_I(IntPtr jnienv, IntPtr native__this, int margin)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidelineEnd(margin);
		}

		[Register("setGuidelineEnd", "(I)V", "GetSetGuidelineEnd_IHandler")]
		public unsafe virtual void SetGuidelineEnd(int margin)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(margin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidelineEnd.(I)V", this, ptr);
		}

		private static Delegate GetSetGuidelinePercent_FHandler()
		{
			if ((object)cb_setGuidelinePercent_F == null)
			{
				cb_setGuidelinePercent_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetGuidelinePercent_F));
			}
			return cb_setGuidelinePercent_F;
		}

		private static void n_SetGuidelinePercent_F(IntPtr jnienv, IntPtr native__this, float ratio)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidelinePercent(ratio);
		}

		[Register("setGuidelinePercent", "(F)V", "GetSetGuidelinePercent_FHandler")]
		public unsafe virtual void SetGuidelinePercent(float ratio)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ratio);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidelinePercent.(F)V", this, ptr);
		}
	}
}
namespace AndroidX.ConstraintLayout.Motion.Widget
{
	[Register("androidx/constraintlayout/motion/widget/DesignTool", DoNotGenerateAcw = true)]
	public class DesignTool : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/DesignTool", typeof(DesignTool));

		private static Delegate cb_getEndState;

		private static Delegate cb_isInTransition;

		private static Delegate cb_getProgress;

		private static Delegate cb_getStartState;

		private static Delegate cb_getState;

		private static Delegate cb_setState_Ljava_lang_String_;

		private static Delegate cb_getTransitionTimeMs;

		private static Delegate cb_designAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFI;

		private static Delegate cb_disableAutoTransition_Z;

		private static Delegate cb_dumpConstraintSet_Ljava_lang_String_;

		private static Delegate cb_getAnimationKeyFrames_Ljava_lang_Object_arrayF;

		private static Delegate cb_getAnimationPath_Ljava_lang_Object_arrayFI;

		private static Delegate cb_getAnimationRectangles_Ljava_lang_Object_arrayF;

		private static Delegate cb_getKeyFrameInfo_Ljava_lang_Object_IarrayI;

		private static Delegate cb_getKeyFramePosition_Ljava_lang_Object_IFF;

		private static Delegate cb_getKeyFramePositions_Ljava_lang_Object_arrayIarrayF;

		private static Delegate cb_getKeyframe_III;

		private static Delegate cb_getKeyframe_Ljava_lang_Object_II;

		private static Delegate cb_getKeyframeAtLocation_Ljava_lang_Object_FF;

		private static Delegate cb_getPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayF;

		private static Delegate cb_setAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_;

		private static Delegate cb_setKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_;

		private static Delegate cb_setKeyFramePosition_Ljava_lang_Object_IIFF;

		private static Delegate cb_setKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_;

		private static Delegate cb_setToolPosition_F;

		private static Delegate cb_setTransition_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_setViewDebug_Ljava_lang_Object_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string EndState
		{
			[Register("getEndState", "()Ljava/lang/String;", "GetGetEndStateHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEndState.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsInTransition
		{
			[Register("isInTransition", "()Z", "GetIsInTransitionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInTransition.()Z", this, null);
			}
		}

		public unsafe virtual float Progress
		{
			[Register("getProgress", "()F", "GetGetProgressHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getProgress.()F", this, null);
			}
		}

		public unsafe virtual string StartState
		{
			[Register("getStartState", "()Ljava/lang/String;", "GetGetStartStateHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getStartState.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string State
		{
			[Register("getState", "()Ljava/lang/String;", "GetGetStateHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getState.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setState", "(Ljava/lang/String;)V", "GetSetState_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setState.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe virtual long TransitionTimeMs
		{
			[Register("getTransitionTimeMs", "()J", "GetGetTransitionTimeMsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getTransitionTimeMs.()J", this, null);
			}
		}

		protected DesignTool(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", "")]
		public unsafe DesignTool(MotionLayout motionLayout)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(motionLayout);
			}
		}

		private static Delegate GetGetEndStateHandler()
		{
			if ((object)cb_getEndState == null)
			{
				cb_getEndState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEndState));
			}
			return cb_getEndState;
		}

		private static IntPtr n_GetEndState(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndState);
		}

		private static Delegate GetIsInTransitionHandler()
		{
			if ((object)cb_isInTransition == null)
			{
				cb_isInTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInTransition));
			}
			return cb_isInTransition;
		}

		private static bool n_IsInTransition(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInTransition;
		}

		private static Delegate GetGetProgressHandler()
		{
			if ((object)cb_getProgress == null)
			{
				cb_getProgress = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetProgress));
			}
			return cb_getProgress;
		}

		private static float n_GetProgress(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress;
		}

		private static Delegate GetGetStartStateHandler()
		{
			if ((object)cb_getStartState == null)
			{
				cb_getStartState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStartState));
			}
			return cb_getStartState;
		}

		private static IntPtr n_GetStartState(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartState);
		}

		private static Delegate GetGetStateHandler()
		{
			if ((object)cb_getState == null)
			{
				cb_getState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetState));
			}
			return cb_getState;
		}

		private static IntPtr n_GetState(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).State);
		}

		private static Delegate GetSetState_Ljava_lang_String_Handler()
		{
			if ((object)cb_setState_Ljava_lang_String_ == null)
			{
				cb_setState_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetState_Ljava_lang_String_));
			}
			return cb_setState_Ljava_lang_String_;
		}

		private static void n_SetState_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_id)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string state = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			designTool.State = state;
		}

		private static Delegate GetGetTransitionTimeMsHandler()
		{
			if ((object)cb_getTransitionTimeMs == null)
			{
				cb_getTransitionTimeMs = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTransitionTimeMs));
			}
			return cb_getTransitionTimeMs;
		}

		private static long n_GetTransitionTimeMs(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionTimeMs;
		}

		private static Delegate GetDesignAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFIHandler()
		{
			if ((object)cb_designAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFI == null)
			{
				cb_designAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPILLLILI_I(n_DesignAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFI));
			}
			return cb_designAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFI;
		}

		private static int n_DesignAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFI(IntPtr jnienv, IntPtr native__this, int cmd, IntPtr native_type, IntPtr native_viewObject, IntPtr native__in, int inLength, IntPtr native__out, int outLength)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object viewObject = Java.Lang.Object.GetObject<Java.Lang.Object>(native_viewObject, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native__in, JniHandleOwnership.DoNotTransfer, typeof(float));
			float[] array2 = (float[])JNIEnv.GetArray(native__out, JniHandleOwnership.DoNotTransfer, typeof(float));
			int result = designTool.DesignAccess(cmd, type, viewObject, array, inLength, array2, outLength);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native__in);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native__out);
			}
			return result;
		}

		[Register("designAccess", "(ILjava/lang/String;Ljava/lang/Object;[FI[FI)I", "GetDesignAccess_ILjava_lang_String_Ljava_lang_Object_arrayFIarrayFIHandler")]
		public unsafe virtual int DesignAccess(int cmd, string type, Java.Lang.Object viewObject, float[] @in, int inLength, float[] @out, int outLength)
		{
			IntPtr intPtr = JNIEnv.NewString(type);
			IntPtr intPtr2 = JNIEnv.NewArray(@in);
			IntPtr intPtr3 = JNIEnv.NewArray(@out);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(cmd);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(viewObject?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(intPtr2);
				ptr[4] = new JniArgumentValue(inLength);
				ptr[5] = new JniArgumentValue(intPtr3);
				ptr[6] = new JniArgumentValue(outLength);
				return _members.InstanceMethods.InvokeVirtualInt32Method("designAccess.(ILjava/lang/String;Ljava/lang/Object;[FI[FI)I", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (@in != null)
				{
					JNIEnv.CopyArray(intPtr2, @in);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				if (@out != null)
				{
					JNIEnv.CopyArray(intPtr3, @out);
					JNIEnv.DeleteLocalRef(intPtr3);
				}
				GC.KeepAlive(viewObject);
				GC.KeepAlive(@in);
				GC.KeepAlive(@out);
			}
		}

		private static Delegate GetDisableAutoTransition_ZHandler()
		{
			if ((object)cb_disableAutoTransition_Z == null)
			{
				cb_disableAutoTransition_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_DisableAutoTransition_Z));
			}
			return cb_disableAutoTransition_Z;
		}

		private static void n_DisableAutoTransition_Z(IntPtr jnienv, IntPtr native__this, bool disable)
		{
			Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisableAutoTransition(disable);
		}

		[Register("disableAutoTransition", "(Z)V", "GetDisableAutoTransition_ZHandler")]
		public unsafe virtual void DisableAutoTransition(bool disable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(disable);
			_members.InstanceMethods.InvokeVirtualVoidMethod("disableAutoTransition.(Z)V", this, ptr);
		}

		private static Delegate GetDumpConstraintSet_Ljava_lang_String_Handler()
		{
			if ((object)cb_dumpConstraintSet_Ljava_lang_String_ == null)
			{
				cb_dumpConstraintSet_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_DumpConstraintSet_Ljava_lang_String_));
			}
			return cb_dumpConstraintSet_Ljava_lang_String_;
		}

		private static void n_DumpConstraintSet_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_set)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string set = JNIEnv.GetString(native_set, JniHandleOwnership.DoNotTransfer);
			designTool.DumpConstraintSet(set);
		}

		[Register("dumpConstraintSet", "(Ljava/lang/String;)V", "GetDumpConstraintSet_Ljava_lang_String_Handler")]
		public unsafe virtual void DumpConstraintSet(string set)
		{
			IntPtr intPtr = JNIEnv.NewString(set);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("dumpConstraintSet.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetAnimationKeyFrames_Ljava_lang_Object_arrayFHandler()
		{
			if ((object)cb_getAnimationKeyFrames_Ljava_lang_Object_arrayF == null)
			{
				cb_getAnimationKeyFrames_Ljava_lang_Object_arrayF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_GetAnimationKeyFrames_Ljava_lang_Object_arrayF));
			}
			return cb_getAnimationKeyFrames_Ljava_lang_Object_arrayF;
		}

		private static int n_GetAnimationKeyFrames_Ljava_lang_Object_arrayF(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_key)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_key, JniHandleOwnership.DoNotTransfer, typeof(float));
			int animationKeyFrames = designTool.GetAnimationKeyFrames(view, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_key);
			}
			return animationKeyFrames;
		}

		[Register("getAnimationKeyFrames", "(Ljava/lang/Object;[F)I", "GetGetAnimationKeyFrames_Ljava_lang_Object_arrayFHandler")]
		public unsafe virtual int GetAnimationKeyFrames(Java.Lang.Object view, float[] key)
		{
			IntPtr intPtr = JNIEnv.NewArray(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getAnimationKeyFrames.(Ljava/lang/Object;[F)I", this, ptr);
			}
			finally
			{
				if (key != null)
				{
					JNIEnv.CopyArray(intPtr, key);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(view);
				GC.KeepAlive(key);
			}
		}

		private static Delegate GetGetAnimationPath_Ljava_lang_Object_arrayFIHandler()
		{
			if ((object)cb_getAnimationPath_Ljava_lang_Object_arrayFI == null)
			{
				cb_getAnimationPath_Ljava_lang_Object_arrayFI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_I(n_GetAnimationPath_Ljava_lang_Object_arrayFI));
			}
			return cb_getAnimationPath_Ljava_lang_Object_arrayFI;
		}

		private static int n_GetAnimationPath_Ljava_lang_Object_arrayFI(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_path, int len)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_path, JniHandleOwnership.DoNotTransfer, typeof(float));
			int animationPath = designTool.GetAnimationPath(view, array, len);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_path);
			}
			return animationPath;
		}

		[Register("getAnimationPath", "(Ljava/lang/Object;[FI)I", "GetGetAnimationPath_Ljava_lang_Object_arrayFIHandler")]
		public unsafe virtual int GetAnimationPath(Java.Lang.Object view, float[] path, int len)
		{
			IntPtr intPtr = JNIEnv.NewArray(path);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(len);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getAnimationPath.(Ljava/lang/Object;[FI)I", this, ptr);
			}
			finally
			{
				if (path != null)
				{
					JNIEnv.CopyArray(intPtr, path);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(view);
				GC.KeepAlive(path);
			}
		}

		private static Delegate GetGetAnimationRectangles_Ljava_lang_Object_arrayFHandler()
		{
			if ((object)cb_getAnimationRectangles_Ljava_lang_Object_arrayF == null)
			{
				cb_getAnimationRectangles_Ljava_lang_Object_arrayF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_GetAnimationRectangles_Ljava_lang_Object_arrayF));
			}
			return cb_getAnimationRectangles_Ljava_lang_Object_arrayF;
		}

		private static void n_GetAnimationRectangles_Ljava_lang_Object_arrayF(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_path)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_path, JniHandleOwnership.DoNotTransfer, typeof(float));
			designTool.GetAnimationRectangles(view, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_path);
			}
		}

		[Register("getAnimationRectangles", "(Ljava/lang/Object;[F)V", "GetGetAnimationRectangles_Ljava_lang_Object_arrayFHandler")]
		public unsafe virtual void GetAnimationRectangles(Java.Lang.Object view, float[] path)
		{
			IntPtr intPtr = JNIEnv.NewArray(path);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getAnimationRectangles.(Ljava/lang/Object;[F)V", this, ptr);
			}
			finally
			{
				if (path != null)
				{
					JNIEnv.CopyArray(intPtr, path);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(view);
				GC.KeepAlive(path);
			}
		}

		private static Delegate GetGetKeyFrameInfo_Ljava_lang_Object_IarrayIHandler()
		{
			if ((object)cb_getKeyFrameInfo_Ljava_lang_Object_IarrayI == null)
			{
				cb_getKeyFrameInfo_Ljava_lang_Object_IarrayI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIL_I(n_GetKeyFrameInfo_Ljava_lang_Object_IarrayI));
			}
			return cb_getKeyFrameInfo_Ljava_lang_Object_IarrayI;
		}

		private static int n_GetKeyFrameInfo_Ljava_lang_Object_IarrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int type, IntPtr native_info)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_info, JniHandleOwnership.DoNotTransfer, typeof(int));
			int keyFrameInfo = designTool.GetKeyFrameInfo(view, type, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_info);
			}
			return keyFrameInfo;
		}

		[Register("getKeyFrameInfo", "(Ljava/lang/Object;I[I)I", "GetGetKeyFrameInfo_Ljava_lang_Object_IarrayIHandler")]
		public unsafe virtual int GetKeyFrameInfo(Java.Lang.Object view, int type, int[] info)
		{
			IntPtr intPtr = JNIEnv.NewArray(info);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(type);
				ptr[2] = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getKeyFrameInfo.(Ljava/lang/Object;I[I)I", this, ptr);
			}
			finally
			{
				if (info != null)
				{
					JNIEnv.CopyArray(intPtr, info);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(view);
				GC.KeepAlive(info);
			}
		}

		private static Delegate GetGetKeyFramePosition_Ljava_lang_Object_IFFHandler()
		{
			if ((object)cb_getKeyFramePosition_Ljava_lang_Object_IFF == null)
			{
				cb_getKeyFramePosition_Ljava_lang_Object_IFF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIFF_F(n_GetKeyFramePosition_Ljava_lang_Object_IFF));
			}
			return cb_getKeyFramePosition_Ljava_lang_Object_IFF;
		}

		private static float n_GetKeyFramePosition_Ljava_lang_Object_IFF(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int type, float x, float y)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			return designTool.GetKeyFramePosition(view, type, x, y);
		}

		[Register("getKeyFramePosition", "(Ljava/lang/Object;IFF)F", "GetGetKeyFramePosition_Ljava_lang_Object_IFFHandler")]
		public unsafe virtual float GetKeyFramePosition(Java.Lang.Object view, int type, float x, float y)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(type);
				ptr[2] = new JniArgumentValue(x);
				ptr[3] = new JniArgumentValue(y);
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getKeyFramePosition.(Ljava/lang/Object;IFF)F", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetGetKeyFramePositions_Ljava_lang_Object_arrayIarrayFHandler()
		{
			if ((object)cb_getKeyFramePositions_Ljava_lang_Object_arrayIarrayF == null)
			{
				cb_getKeyFramePositions_Ljava_lang_Object_arrayIarrayF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_I(n_GetKeyFramePositions_Ljava_lang_Object_arrayIarrayF));
			}
			return cb_getKeyFramePositions_Ljava_lang_Object_arrayIarrayF;
		}

		private static int n_GetKeyFramePositions_Ljava_lang_Object_arrayIarrayF(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_type, IntPtr native_pos)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_type, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_pos, JniHandleOwnership.DoNotTransfer, typeof(float));
			int keyFramePositions = designTool.GetKeyFramePositions(view, array, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_type);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_pos);
			}
			return keyFramePositions;
		}

		[Register("getKeyFramePositions", "(Ljava/lang/Object;[I[F)I", "GetGetKeyFramePositions_Ljava_lang_Object_arrayIarrayFHandler")]
		public unsafe virtual int GetKeyFramePositions(Java.Lang.Object view, int[] type, float[] pos)
		{
			IntPtr intPtr = JNIEnv.NewArray(type);
			IntPtr intPtr2 = JNIEnv.NewArray(pos);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getKeyFramePositions.(Ljava/lang/Object;[I[F)I", this, ptr);
			}
			finally
			{
				if (type != null)
				{
					JNIEnv.CopyArray(intPtr, type);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (pos != null)
				{
					JNIEnv.CopyArray(intPtr2, pos);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(view);
				GC.KeepAlive(type);
				GC.KeepAlive(pos);
			}
		}

		private static Delegate GetGetKeyframe_IIIHandler()
		{
			if ((object)cb_getKeyframe_III == null)
			{
				cb_getKeyframe_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_L(n_GetKeyframe_III));
			}
			return cb_getKeyframe_III;
		}

		private static IntPtr n_GetKeyframe_III(IntPtr jnienv, IntPtr native__this, int type, int target, int position)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetKeyframe(type, target, position));
		}

		[Register("getKeyframe", "(III)Ljava/lang/Object;", "GetGetKeyframe_IIIHandler")]
		public unsafe virtual Java.Lang.Object GetKeyframe(int type, int target, int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(type);
			ptr[1] = new JniArgumentValue(target);
			ptr[2] = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyframe.(III)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetKeyframe_Ljava_lang_Object_IIHandler()
		{
			if ((object)cb_getKeyframe_Ljava_lang_Object_II == null)
			{
				cb_getKeyframe_Ljava_lang_Object_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_GetKeyframe_Ljava_lang_Object_II));
			}
			return cb_getKeyframe_Ljava_lang_Object_II;
		}

		private static IntPtr n_GetKeyframe_Ljava_lang_Object_II(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int type, int position)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(designTool.GetKeyframe(view, type, position));
		}

		[Register("getKeyframe", "(Ljava/lang/Object;II)Ljava/lang/Object;", "GetGetKeyframe_Ljava_lang_Object_IIHandler")]
		public unsafe virtual Java.Lang.Object GetKeyframe(Java.Lang.Object view, int type, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(type);
				ptr[2] = new JniArgumentValue(position);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyframe.(Ljava/lang/Object;II)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetGetKeyframeAtLocation_Ljava_lang_Object_FFHandler()
		{
			if ((object)cb_getKeyframeAtLocation_Ljava_lang_Object_FF == null)
			{
				cb_getKeyframeAtLocation_Ljava_lang_Object_FF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLFF_L(n_GetKeyframeAtLocation_Ljava_lang_Object_FF));
			}
			return cb_getKeyframeAtLocation_Ljava_lang_Object_FF;
		}

		private static IntPtr n_GetKeyframeAtLocation_Ljava_lang_Object_FF(IntPtr jnienv, IntPtr native__this, IntPtr native_viewObject, float x, float y)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object viewObject = Java.Lang.Object.GetObject<Java.Lang.Object>(native_viewObject, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(designTool.GetKeyframeAtLocation(viewObject, x, y));
		}

		[Register("getKeyframeAtLocation", "(Ljava/lang/Object;FF)Ljava/lang/Object;", "GetGetKeyframeAtLocation_Ljava_lang_Object_FFHandler")]
		public unsafe virtual Java.Lang.Object GetKeyframeAtLocation(Java.Lang.Object viewObject, float x, float y)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewObject?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(x);
				ptr[2] = new JniArgumentValue(y);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyframeAtLocation.(Ljava/lang/Object;FF)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(viewObject);
			}
		}

		private static Delegate GetGetPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayFHandler()
		{
			if ((object)cb_getPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayF == null)
			{
				cb_getPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLFFLL_L(n_GetPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayF));
			}
			return cb_getPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayF;
		}

		private static IntPtr n_GetPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayF(IntPtr jnienv, IntPtr native__this, IntPtr native_keyFrame, IntPtr native_view, float x, float y, IntPtr native_attribute, IntPtr native_value)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object keyFrame = Java.Lang.Object.GetObject<Java.Lang.Object>(native_keyFrame, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attribute, JniHandleOwnership.DoNotTransfer, typeof(string));
			float[] array2 = (float[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(float));
			IntPtr result = JNIEnv.ToLocalJniHandle(designTool.GetPositionKeyframe(keyFrame, view, x, y, array, array2));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attribute);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_value);
			}
			return result;
		}

		[Register("getPositionKeyframe", "(Ljava/lang/Object;Ljava/lang/Object;FF[Ljava/lang/String;[F)Ljava/lang/Boolean;", "GetGetPositionKeyframe_Ljava_lang_Object_Ljava_lang_Object_FFarrayLjava_lang_String_arrayFHandler")]
		public unsafe virtual Java.Lang.Boolean GetPositionKeyframe(Java.Lang.Object keyFrame, Java.Lang.Object view, float x, float y, string[] attribute, float[] value)
		{
			IntPtr intPtr = JNIEnv.NewArray(attribute);
			IntPtr intPtr2 = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(keyFrame?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(x);
				ptr[3] = new JniArgumentValue(y);
				ptr[4] = new JniArgumentValue(intPtr);
				ptr[5] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPositionKeyframe.(Ljava/lang/Object;Ljava/lang/Object;FF[Ljava/lang/String;[F)Ljava/lang/Boolean;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (attribute != null)
				{
					JNIEnv.CopyArray(intPtr, attribute);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr2, value);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(keyFrame);
				GC.KeepAlive(view);
				GC.KeepAlive(attribute);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetSetAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_ == null)
			{
				cb_setAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILLL_V(n_SetAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_));
			}
			return cb_setAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_;
		}

		private static void n_SetAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, int dpi, IntPtr native_constraintSetId, IntPtr native_opaqueView, IntPtr native_opaqueAttributes)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string constraintSetId = JNIEnv.GetString(native_constraintSetId, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object opaqueView = Java.Lang.Object.GetObject<Java.Lang.Object>(native_opaqueView, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object opaqueAttributes = Java.Lang.Object.GetObject<Java.Lang.Object>(native_opaqueAttributes, JniHandleOwnership.DoNotTransfer);
			designTool.SetAttributes(dpi, constraintSetId, opaqueView, opaqueAttributes);
		}

		[Register("setAttributes", "(ILjava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", "GetSetAttributes_ILjava_lang_String_Ljava_lang_Object_Ljava_lang_Object_Handler")]
		public unsafe virtual void SetAttributes(int dpi, string constraintSetId, Java.Lang.Object opaqueView, Java.Lang.Object opaqueAttributes)
		{
			IntPtr intPtr = JNIEnv.NewString(constraintSetId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(dpi);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(opaqueView?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(opaqueAttributes?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAttributes.(ILjava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(opaqueView);
				GC.KeepAlive(opaqueAttributes);
			}
		}

		private static Delegate GetSetKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_ == null)
			{
				cb_setKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLILL_V(n_SetKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_));
			}
			return cb_setKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_;
		}

		private static void n_SetKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int position, IntPtr native_name, IntPtr native_value)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			designTool.SetKeyFrame(view, position, name, value);
		}

		[Register("setKeyFrame", "(Ljava/lang/Object;ILjava/lang/String;Ljava/lang/Object;)V", "GetSetKeyFrame_Ljava_lang_Object_ILjava_lang_String_Ljava_lang_Object_Handler")]
		public unsafe virtual void SetKeyFrame(Java.Lang.Object view, int position, string name, Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyFrame.(Ljava/lang/Object;ILjava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(view);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetSetKeyFramePosition_Ljava_lang_Object_IIFFHandler()
		{
			if ((object)cb_setKeyFramePosition_Ljava_lang_Object_IIFF == null)
			{
				cb_setKeyFramePosition_Ljava_lang_Object_IIFF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIIFF_Z(n_SetKeyFramePosition_Ljava_lang_Object_IIFF));
			}
			return cb_setKeyFramePosition_Ljava_lang_Object_IIFF;
		}

		private static bool n_SetKeyFramePosition_Ljava_lang_Object_IIFF(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int position, int type, float x, float y)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			return designTool.SetKeyFramePosition(view, position, type, x, y);
		}

		[Register("setKeyFramePosition", "(Ljava/lang/Object;IIFF)Z", "GetSetKeyFramePosition_Ljava_lang_Object_IIFFHandler")]
		public unsafe virtual bool SetKeyFramePosition(Java.Lang.Object view, int position, int type, float x, float y)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(type);
				ptr[3] = new JniArgumentValue(x);
				ptr[4] = new JniArgumentValue(y);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("setKeyFramePosition.(Ljava/lang/Object;IIFF)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetSetKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_ == null)
			{
				cb_setKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SetKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_));
			}
			return cb_setKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_;
		}

		private static void n_SetKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_keyFrame, IntPtr native_tag, IntPtr native_value)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object keyFrame = Java.Lang.Object.GetObject<Java.Lang.Object>(native_keyFrame, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			designTool.SetKeyframe(keyFrame, tag, value);
		}

		[Register("setKeyframe", "(Ljava/lang/Object;Ljava/lang/String;Ljava/lang/Object;)V", "GetSetKeyframe_Ljava_lang_Object_Ljava_lang_String_Ljava_lang_Object_Handler")]
		public unsafe virtual void SetKeyframe(Java.Lang.Object keyFrame, string tag, Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(keyFrame?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyframe.(Ljava/lang/Object;Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(keyFrame);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetSetToolPosition_FHandler()
		{
			if ((object)cb_setToolPosition_F == null)
			{
				cb_setToolPosition_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetToolPosition_F));
			}
			return cb_setToolPosition_F;
		}

		private static void n_SetToolPosition_F(IntPtr jnienv, IntPtr native__this, float position)
		{
			Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetToolPosition(position);
		}

		[Register("setToolPosition", "(F)V", "GetSetToolPosition_FHandler")]
		public unsafe virtual void SetToolPosition(float position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setToolPosition.(F)V", this, ptr);
		}

		private static Delegate GetSetTransition_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_setTransition_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_setTransition_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetTransition_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_setTransition_Ljava_lang_String_Ljava_lang_String_;
		}

		private static void n_SetTransition_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_start, IntPtr native_end)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string start = JNIEnv.GetString(native_start, JniHandleOwnership.DoNotTransfer);
			string end = JNIEnv.GetString(native_end, JniHandleOwnership.DoNotTransfer);
			designTool.SetTransition(start, end);
		}

		[Register("setTransition", "(Ljava/lang/String;Ljava/lang/String;)V", "GetSetTransition_Ljava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual void SetTransition(string start, string end)
		{
			IntPtr intPtr = JNIEnv.NewString(start);
			IntPtr intPtr2 = JNIEnv.NewString(end);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		private static Delegate GetSetViewDebug_Ljava_lang_Object_IHandler()
		{
			if ((object)cb_setViewDebug_Ljava_lang_Object_I == null)
			{
				cb_setViewDebug_Ljava_lang_Object_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_SetViewDebug_Ljava_lang_Object_I));
			}
			return cb_setViewDebug_Ljava_lang_Object_I;
		}

		private static void n_SetViewDebug_Ljava_lang_Object_I(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int debugMode)
		{
			DesignTool designTool = Java.Lang.Object.GetObject<DesignTool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object view = Java.Lang.Object.GetObject<Java.Lang.Object>(native_view, JniHandleOwnership.DoNotTransfer);
			designTool.SetViewDebug(view, debugMode);
		}

		[Register("setViewDebug", "(Ljava/lang/Object;I)V", "GetSetViewDebug_Ljava_lang_Object_IHandler")]
		public unsafe virtual void SetViewDebug(Java.Lang.Object view, int debugMode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(debugMode);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setViewDebug.(Ljava/lang/Object;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}
	}
	[Register("androidx/constraintlayout/motion/widget/Key", DoNotGenerateAcw = true)]
	public abstract class Key : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/Key", typeof(Key));

		private static Delegate cb_addValues_Ljava_util_HashMap_;

		private static Delegate cb_setInterpolation_Ljava_util_HashMap_;

		private static Delegate cb_setValue_Ljava_lang_String_Ljava_lang_Object_;

		[Register("UNSET")]
		public static int Unset
		{
			get
			{
				return _members.StaticFields.GetInt32Value("UNSET.I");
			}
			set
			{
				_members.StaticFields.SetValue("UNSET.I", value);
			}
		}

		[Register("mType")]
		protected int MType
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mType.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mType.I", this, value);
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Key(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Key()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetAddValues_Ljava_util_HashMap_Handler()
		{
			if ((object)cb_addValues_Ljava_util_HashMap_ == null)
			{
				cb_addValues_Ljava_util_HashMap_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddValues_Ljava_util_HashMap_));
			}
			return cb_addValues_Ljava_util_HashMap_;
		}

		private static void n_AddValues_Ljava_util_HashMap_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Key key = Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, SplineSet> p = JavaDictionary<string, SplineSet>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
			key.AddValues(p);
		}

		[Register("addValues", "(Ljava/util/HashMap;)V", "GetAddValues_Ljava_util_HashMap_Handler")]
		public abstract void AddValues(IDictionary<string, SplineSet> p0);

		private static Delegate GetSetInterpolation_Ljava_util_HashMap_Handler()
		{
			if ((object)cb_setInterpolation_Ljava_util_HashMap_ == null)
			{
				cb_setInterpolation_Ljava_util_HashMap_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetInterpolation_Ljava_util_HashMap_));
			}
			return cb_setInterpolation_Ljava_util_HashMap_;
		}

		private static void n_SetInterpolation_Ljava_util_HashMap_(IntPtr jnienv, IntPtr native__this, IntPtr native_interpolation)
		{
			Key key = Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, Integer> interpolation = JavaDictionary<string, Integer>.FromJniHandle(native_interpolation, JniHandleOwnership.DoNotTransfer);
			key.SetInterpolation(interpolation);
		}

		[Register("setInterpolation", "(Ljava/util/HashMap;)V", "GetSetInterpolation_Ljava_util_HashMap_Handler")]
		public unsafe virtual void SetInterpolation(IDictionary<string, Integer> interpolation)
		{
			IntPtr intPtr = JavaDictionary<string, Integer>.ToLocalJniHandle(interpolation);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolation.(Ljava/util/HashMap;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(interpolation);
			}
		}

		private static Delegate GetSetValue_Ljava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setValue_Ljava_lang_String_Ljava_lang_Object_ == null)
			{
				cb_setValue_Ljava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetValue_Ljava_lang_String_Ljava_lang_Object_));
			}
			return cb_setValue_Ljava_lang_String_Ljava_lang_Object_;
		}

		private static void n_SetValue_Ljava_lang_String_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Key key = Java.Lang.Object.GetObject<Key>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			key.SetValue(p, p2);
		}

		[Register("setValue", "(Ljava/lang/String;Ljava/lang/Object;)V", "GetSetValue_Ljava_lang_String_Ljava_lang_Object_Handler")]
		public abstract void SetValue(string p0, Java.Lang.Object p1);
	}
	[Register("androidx/constraintlayout/motion/widget/Key", DoNotGenerateAcw = true)]
	internal class KeyInvoker : Key
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/Key", typeof(KeyInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public KeyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("addValues", "(Ljava/util/HashMap;)V", "GetAddValues_Ljava_util_HashMap_Handler")]
		public unsafe override void AddValues(IDictionary<string, SplineSet> p0)
		{
			IntPtr intPtr = JavaDictionary<string, SplineSet>.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addValues.(Ljava/util/HashMap;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		[Register("setValue", "(Ljava/lang/String;Ljava/lang/Object;)V", "GetSetValue_Ljava_lang_String_Ljava_lang_Object_Handler")]
		public unsafe override void SetValue(string p0, Java.Lang.Object p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setValue.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
			}
		}
	}
	[Register("androidx/constraintlayout/motion/widget/KeyFrames", DoNotGenerateAcw = true)]
	public class KeyFrames : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/KeyFrames", typeof(KeyFrames));

		private static Delegate cb_getKeys;

		private static Delegate cb_addFrames_Landroidx_constraintlayout_motion_widget_MotionController_;

		private static Delegate cb_getKeyFramesForView_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual ICollection<Integer> Keys
		{
			[Register("getKeys", "()Ljava/util/Set;", "GetGetKeysHandler")]
			get
			{
				return JavaSet<Integer>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeys.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected KeyFrames(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", "")]
		public unsafe KeyFrames(Context context, XmlReader parser)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = XmlReaderPullParser.ToLocalJniHandle(parser);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(parser);
			}
		}

		private static Delegate GetGetKeysHandler()
		{
			if ((object)cb_getKeys == null)
			{
				cb_getKeys = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetKeys));
			}
			return cb_getKeys;
		}

		private static IntPtr n_GetKeys(IntPtr jnienv, IntPtr native__this)
		{
			return JavaSet<Integer>.ToLocalJniHandle(Java.Lang.Object.GetObject<KeyFrames>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Keys);
		}

		private static Delegate GetAddFrames_Landroidx_constraintlayout_motion_widget_MotionController_Handler()
		{
			if ((object)cb_addFrames_Landroidx_constraintlayout_motion_widget_MotionController_ == null)
			{
				cb_addFrames_Landroidx_constraintlayout_motion_widget_MotionController_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddFrames_Landroidx_constraintlayout_motion_widget_MotionController_));
			}
			return cb_addFrames_Landroidx_constraintlayout_motion_widget_MotionController_;
		}

		private static void n_AddFrames_Landroidx_constraintlayout_motion_widget_MotionController_(IntPtr jnienv, IntPtr native__this, IntPtr native_motionController)
		{
			KeyFrames keyFrames = Java.Lang.Object.GetObject<KeyFrames>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionController motionController = Java.Lang.Object.GetObject<MotionController>(native_motionController, JniHandleOwnership.DoNotTransfer);
			keyFrames.AddFrames(motionController);
		}

		[Register("addFrames", "(Landroidx/constraintlayout/motion/widget/MotionController;)V", "GetAddFrames_Landroidx_constraintlayout_motion_widget_MotionController_Handler")]
		public unsafe virtual void AddFrames(MotionController motionController)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(motionController?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addFrames.(Landroidx/constraintlayout/motion/widget/MotionController;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(motionController);
			}
		}

		private static Delegate GetGetKeyFramesForView_IHandler()
		{
			if ((object)cb_getKeyFramesForView_I == null)
			{
				cb_getKeyFramesForView_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetKeyFramesForView_I));
			}
			return cb_getKeyFramesForView_I;
		}

		private static IntPtr n_GetKeyFramesForView_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			return JavaList<Key>.ToLocalJniHandle(Java.Lang.Object.GetObject<KeyFrames>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetKeyFramesForView(id));
		}

		[Register("getKeyFramesForView", "(I)Ljava/util/ArrayList;", "GetGetKeyFramesForView_IHandler")]
		public unsafe virtual IList<Key> GetKeyFramesForView(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			return JavaList<Key>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyFramesForView.(I)Ljava/util/ArrayList;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/constraintlayout/motion/widget/MotionController", DoNotGenerateAcw = true)]
	public class MotionController : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionController", typeof(MotionController));

		private static Delegate cb_getDrawPath;

		private static Delegate cb_setDrawPath_I;

		private static Delegate cb_getKeyFrameInfo_IarrayI;

		private static Delegate cb_getkeyFramePositions_arrayIarrayF;

		private static Delegate cb_setPathMotionArc_I;

		private static Delegate cb_setView_Landroid_view_View_;

		private static Delegate cb_setup_IIFJ;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int DrawPath
		{
			[Register("getDrawPath", "()I", "GetGetDrawPathHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDrawPath.()I", this, null);
			}
			[Register("setDrawPath", "(I)V", "GetSetDrawPath_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawPath.(I)V", this, ptr);
			}
		}

		protected MotionController(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetDrawPathHandler()
		{
			if ((object)cb_getDrawPath == null)
			{
				cb_getDrawPath = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetDrawPath));
			}
			return cb_getDrawPath;
		}

		private static int n_GetDrawPath(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawPath;
		}

		private static Delegate GetSetDrawPath_IHandler()
		{
			if ((object)cb_setDrawPath_I == null)
			{
				cb_setDrawPath_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetDrawPath_I));
			}
			return cb_setDrawPath_I;
		}

		private static void n_SetDrawPath_I(IntPtr jnienv, IntPtr native__this, int debugMode)
		{
			Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawPath = debugMode;
		}

		private static Delegate GetGetKeyFrameInfo_IarrayIHandler()
		{
			if ((object)cb_getKeyFrameInfo_IarrayI == null)
			{
				cb_getKeyFrameInfo_IarrayI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIL_I(n_GetKeyFrameInfo_IarrayI));
			}
			return cb_getKeyFrameInfo_IarrayI;
		}

		private static int n_GetKeyFrameInfo_IarrayI(IntPtr jnienv, IntPtr native__this, int type, IntPtr native_info)
		{
			MotionController motionController = Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_info, JniHandleOwnership.DoNotTransfer, typeof(int));
			int keyFrameInfo = motionController.GetKeyFrameInfo(type, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_info);
			}
			return keyFrameInfo;
		}

		[Register("getKeyFrameInfo", "(I[I)I", "GetGetKeyFrameInfo_IarrayIHandler")]
		public unsafe virtual int GetKeyFrameInfo(int type, int[] info)
		{
			IntPtr intPtr = JNIEnv.NewArray(info);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(type);
				ptr[1] = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getKeyFrameInfo.(I[I)I", this, ptr);
			}
			finally
			{
				if (info != null)
				{
					JNIEnv.CopyArray(intPtr, info);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(info);
			}
		}

		private static Delegate GetGetkeyFramePositions_arrayIarrayFHandler()
		{
			if ((object)cb_getkeyFramePositions_arrayIarrayF == null)
			{
				cb_getkeyFramePositions_arrayIarrayF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_GetkeyFramePositions_arrayIarrayF));
			}
			return cb_getkeyFramePositions_arrayIarrayF;
		}

		private static int n_GetkeyFramePositions_arrayIarrayF(IntPtr jnienv, IntPtr native__this, IntPtr native_type, IntPtr native_pos)
		{
			MotionController motionController = Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_type, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_pos, JniHandleOwnership.DoNotTransfer, typeof(float));
			int result = motionController.GetkeyFramePositions(array, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_type);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_pos);
			}
			return result;
		}

		[Register("getkeyFramePositions", "([I[F)I", "GetGetkeyFramePositions_arrayIarrayFHandler")]
		public unsafe virtual int GetkeyFramePositions(int[] type, float[] pos)
		{
			IntPtr intPtr = JNIEnv.NewArray(type);
			IntPtr intPtr2 = JNIEnv.NewArray(pos);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getkeyFramePositions.([I[F)I", this, ptr);
			}
			finally
			{
				if (type != null)
				{
					JNIEnv.CopyArray(intPtr, type);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (pos != null)
				{
					JNIEnv.CopyArray(intPtr2, pos);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(type);
				GC.KeepAlive(pos);
			}
		}

		private static Delegate GetSetPathMotionArc_IHandler()
		{
			if ((object)cb_setPathMotionArc_I == null)
			{
				cb_setPathMotionArc_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetPathMotionArc_I));
			}
			return cb_setPathMotionArc_I;
		}

		private static void n_SetPathMotionArc_I(IntPtr jnienv, IntPtr native__this, int arc)
		{
			Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPathMotionArc(arc);
		}

		[Register("setPathMotionArc", "(I)V", "GetSetPathMotionArc_IHandler")]
		public unsafe virtual void SetPathMotionArc(int arc)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(arc);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPathMotionArc.(I)V", this, ptr);
		}

		private static Delegate GetSetView_Landroid_view_View_Handler()
		{
			if ((object)cb_setView_Landroid_view_View_ == null)
			{
				cb_setView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetView_Landroid_view_View_));
			}
			return cb_setView_Landroid_view_View_;
		}

		private static void n_SetView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			MotionController motionController = Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			motionController.SetView(view);
		}

		[Register("setView", "(Landroid/view/View;)V", "GetSetView_Landroid_view_View_Handler")]
		public unsafe virtual void SetView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetSetup_IIFJHandler()
		{
			if ((object)cb_setup_IIFJ == null)
			{
				cb_setup_IIFJ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIFJ_V(n_Setup_IIFJ));
			}
			return cb_setup_IIFJ;
		}

		private static void n_Setup_IIFJ(IntPtr jnienv, IntPtr native__this, int parentWidth, int parentHeight, float transitionDuration, long currentTime)
		{
			Java.Lang.Object.GetObject<MotionController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Setup(parentWidth, parentHeight, transitionDuration, currentTime);
		}

		[Register("setup", "(IIFJ)V", "GetSetup_IIFJHandler")]
		public unsafe virtual void Setup(int parentWidth, int parentHeight, float transitionDuration, long currentTime)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(parentWidth);
			ptr[1] = new JniArgumentValue(parentHeight);
			ptr[2] = new JniArgumentValue(transitionDuration);
			ptr[3] = new JniArgumentValue(currentTime);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setup.(IIFJ)V", this, ptr);
		}
	}
	[Register("androidx/constraintlayout/motion/widget/MotionLayout", DoNotGenerateAcw = true)]
	public class MotionLayout : AndroidX.ConstraintLayout.Widget.ConstraintLayout, INestedScrollingParent3, INestedScrollingParent2, INestedScrollingParent, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("androidx/constraintlayout/motion/widget/MotionLayout$MotionTracker", "", "AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker")]
		protected internal interface IMotionTracker : IJavaObject, IDisposable, IJavaPeerable
		{
			float XVelocity
			{
				[Register("getXVelocity", "()F", "GetGetXVelocityHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
				get;
			}

			float YVelocity
			{
				[Register("getYVelocity", "()F", "GetGetYVelocityHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
				get;
			}

			[Register("addMovement", "(Landroid/view/MotionEvent;)V", "GetAddMovement_Landroid_view_MotionEvent_Handler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			void AddMovement(MotionEvent p0);

			[Register("clear", "()V", "GetClearHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			void Clear();

			[Register("computeCurrentVelocity", "(I)V", "GetComputeCurrentVelocity_IHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			void ComputeCurrentVelocity(int p0);

			[Register("computeCurrentVelocity", "(IF)V", "GetComputeCurrentVelocity_IFHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			void ComputeCurrentVelocity(int p0, float p1);

			[Register("getXVelocity", "(I)F", "GetGetXVelocity_IHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			float GetXVelocity(int p0);

			[Register("getYVelocity", "(I)F", "GetGetYVelocity_IHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			float GetYVelocity(int p0);

			[Register("recycle", "()V", "GetRecycleHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/IMotionTrackerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			void Recycle();
		}

		[Register("androidx/constraintlayout/motion/widget/MotionLayout$MotionTracker", DoNotGenerateAcw = true)]
		internal class IMotionTrackerInvoker : Java.Lang.Object, IMotionTracker, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionLayout$MotionTracker", typeof(IMotionTrackerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_getXVelocity;

			private IntPtr id_getXVelocity;

			private static Delegate cb_getYVelocity;

			private IntPtr id_getYVelocity;

			private static Delegate cb_addMovement_Landroid_view_MotionEvent_;

			private IntPtr id_addMovement_Landroid_view_MotionEvent_;

			private static Delegate cb_clear;

			private IntPtr id_clear;

			private static Delegate cb_computeCurrentVelocity_I;

			private IntPtr id_computeCurrentVelocity_I;

			private static Delegate cb_computeCurrentVelocity_IF;

			private IntPtr id_computeCurrentVelocity_IF;

			private static Delegate cb_getXVelocity_I;

			private IntPtr id_getXVelocity_I;

			private static Delegate cb_getYVelocity_I;

			private IntPtr id_getYVelocity_I;

			private static Delegate cb_recycle;

			private IntPtr id_recycle;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public float XVelocity
			{
				get
				{
					if (id_getXVelocity == IntPtr.Zero)
					{
						id_getXVelocity = JNIEnv.GetMethodID(class_ref, "getXVelocity", "()F");
					}
					return JNIEnv.CallFloatMethod(base.Handle, id_getXVelocity);
				}
			}

			public float YVelocity
			{
				get
				{
					if (id_getYVelocity == IntPtr.Zero)
					{
						id_getYVelocity = JNIEnv.GetMethodID(class_ref, "getYVelocity", "()F");
					}
					return JNIEnv.CallFloatMethod(base.Handle, id_getYVelocity);
				}
			}

			public static IMotionTracker GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IMotionTracker>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.constraintlayout.motion.widget.MotionLayout.MotionTracker"));
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

			public IMotionTrackerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetGetXVelocityHandler()
			{
				if ((object)cb_getXVelocity == null)
				{
					cb_getXVelocity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetXVelocity));
				}
				return cb_getXVelocity;
			}

			private static float n_GetXVelocity(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).XVelocity;
			}

			private static Delegate GetGetYVelocityHandler()
			{
				if ((object)cb_getYVelocity == null)
				{
					cb_getYVelocity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetYVelocity));
				}
				return cb_getYVelocity;
			}

			private static float n_GetYVelocity(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).YVelocity;
			}

			private static Delegate GetAddMovement_Landroid_view_MotionEvent_Handler()
			{
				if ((object)cb_addMovement_Landroid_view_MotionEvent_ == null)
				{
					cb_addMovement_Landroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddMovement_Landroid_view_MotionEvent_));
				}
				return cb_addMovement_Landroid_view_MotionEvent_;
			}

			private static void n_AddMovement_Landroid_view_MotionEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IMotionTracker motionTracker = Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionEvent p = Java.Lang.Object.GetObject<MotionEvent>(native_p0, JniHandleOwnership.DoNotTransfer);
				motionTracker.AddMovement(p);
			}

			public unsafe void AddMovement(MotionEvent p0)
			{
				if (id_addMovement_Landroid_view_MotionEvent_ == IntPtr.Zero)
				{
					id_addMovement_Landroid_view_MotionEvent_ = JNIEnv.GetMethodID(class_ref, "addMovement", "(Landroid/view/MotionEvent;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_addMovement_Landroid_view_MotionEvent_, ptr);
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
				Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
			}

			public void Clear()
			{
				if (id_clear == IntPtr.Zero)
				{
					id_clear = JNIEnv.GetMethodID(class_ref, "clear", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_clear);
			}

			private static Delegate GetComputeCurrentVelocity_IHandler()
			{
				if ((object)cb_computeCurrentVelocity_I == null)
				{
					cb_computeCurrentVelocity_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_ComputeCurrentVelocity_I));
				}
				return cb_computeCurrentVelocity_I;
			}

			private static void n_ComputeCurrentVelocity_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeCurrentVelocity(p0);
			}

			public unsafe void ComputeCurrentVelocity(int p0)
			{
				if (id_computeCurrentVelocity_I == IntPtr.Zero)
				{
					id_computeCurrentVelocity_I = JNIEnv.GetMethodID(class_ref, "computeCurrentVelocity", "(I)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				JNIEnv.CallVoidMethod(base.Handle, id_computeCurrentVelocity_I, ptr);
			}

			private static Delegate GetComputeCurrentVelocity_IFHandler()
			{
				if ((object)cb_computeCurrentVelocity_IF == null)
				{
					cb_computeCurrentVelocity_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_ComputeCurrentVelocity_IF));
				}
				return cb_computeCurrentVelocity_IF;
			}

			private static void n_ComputeCurrentVelocity_IF(IntPtr jnienv, IntPtr native__this, int p0, float p1)
			{
				Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeCurrentVelocity(p0, p1);
			}

			public unsafe void ComputeCurrentVelocity(int p0, float p1)
			{
				if (id_computeCurrentVelocity_IF == IntPtr.Zero)
				{
					id_computeCurrentVelocity_IF = JNIEnv.GetMethodID(class_ref, "computeCurrentVelocity", "(IF)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(p0);
				ptr[1] = new JValue(p1);
				JNIEnv.CallVoidMethod(base.Handle, id_computeCurrentVelocity_IF, ptr);
			}

			private static Delegate GetGetXVelocity_IHandler()
			{
				if ((object)cb_getXVelocity_I == null)
				{
					cb_getXVelocity_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_F(n_GetXVelocity_I));
				}
				return cb_getXVelocity_I;
			}

			private static float n_GetXVelocity_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				return Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetXVelocity(p0);
			}

			public unsafe float GetXVelocity(int p0)
			{
				if (id_getXVelocity_I == IntPtr.Zero)
				{
					id_getXVelocity_I = JNIEnv.GetMethodID(class_ref, "getXVelocity", "(I)F");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				return JNIEnv.CallFloatMethod(base.Handle, id_getXVelocity_I, ptr);
			}

			private static Delegate GetGetYVelocity_IHandler()
			{
				if ((object)cb_getYVelocity_I == null)
				{
					cb_getYVelocity_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_F(n_GetYVelocity_I));
				}
				return cb_getYVelocity_I;
			}

			private static float n_GetYVelocity_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				return Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetYVelocity(p0);
			}

			public unsafe float GetYVelocity(int p0)
			{
				if (id_getYVelocity_I == IntPtr.Zero)
				{
					id_getYVelocity_I = JNIEnv.GetMethodID(class_ref, "getYVelocity", "(I)F");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				return JNIEnv.CallFloatMethod(base.Handle, id_getYVelocity_I, ptr);
			}

			private static Delegate GetRecycleHandler()
			{
				if ((object)cb_recycle == null)
				{
					cb_recycle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Recycle));
				}
				return cb_recycle;
			}

			private static void n_Recycle(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IMotionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Recycle();
			}

			public void Recycle()
			{
				if (id_recycle == IntPtr.Zero)
				{
					id_recycle = JNIEnv.GetMethodID(class_ref, "recycle", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_recycle);
			}
		}

		[Register("androidx/constraintlayout/motion/widget/MotionLayout$TransitionListener", "", "AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/ITransitionListenerInvoker")]
		public interface ITransitionListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onTransitionChange", "(Landroidx/constraintlayout/motion/widget/MotionLayout;IIF)V", "GetOnTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIFHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/ITransitionListenerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			void OnTransitionChange(MotionLayout motionLayout, int startId, int endId, float progress);

			[Register("onTransitionCompleted", "(Landroidx/constraintlayout/motion/widget/MotionLayout;I)V", "GetOnTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_IHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/ITransitionListenerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			void OnTransitionCompleted(MotionLayout motionLayout, int currentId);

			[Register("onTransitionStarted", "(Landroidx/constraintlayout/motion/widget/MotionLayout;II)V", "GetOnTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_IIHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/ITransitionListenerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			void OnTransitionStarted(MotionLayout motionLayout, int startId, int endId);

			[Register("onTransitionTrigger", "(Landroidx/constraintlayout/motion/widget/MotionLayout;IZF)V", "GetOnTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZFHandler:AndroidX.ConstraintLayout.Motion.Widget.MotionLayout/ITransitionListenerInvoker, Xamarin.AndroidX.ConstraintLayout")]
			void OnTransitionTrigger(MotionLayout motionLayout, int triggerId, bool positive, float progress);
		}

		[Register("androidx/constraintlayout/motion/widget/MotionLayout$TransitionListener", DoNotGenerateAcw = true)]
		internal class ITransitionListenerInvoker : Java.Lang.Object, ITransitionListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionLayout$TransitionListener", typeof(ITransitionListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF;

			private IntPtr id_onTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF;

			private static Delegate cb_onTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I;

			private IntPtr id_onTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I;

			private static Delegate cb_onTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II;

			private IntPtr id_onTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II;

			private static Delegate cb_onTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF;

			private IntPtr id_onTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public static ITransitionListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ITransitionListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.constraintlayout.motion.widget.MotionLayout.TransitionListener"));
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

			private static Delegate GetOnTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIFHandler()
			{
				if ((object)cb_onTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF == null)
				{
					cb_onTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIIF_V(n_OnTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF));
				}
				return cb_onTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF;
			}

			private static void n_OnTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF(IntPtr jnienv, IntPtr native__this, IntPtr native_motionLayout, int startId, int endId, float progress)
			{
				ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionChange(motionLayout, startId, endId, progress);
			}

			public unsafe void OnTransitionChange(MotionLayout motionLayout, int startId, int endId, float progress)
			{
				if (id_onTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF == IntPtr.Zero)
				{
					id_onTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF = JNIEnv.GetMethodID(class_ref, "onTransitionChange", "(Landroidx/constraintlayout/motion/widget/MotionLayout;IIF)V");
				}
				JValue* ptr = stackalloc JValue[4];
				*ptr = new JValue(motionLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(startId);
				ptr[2] = new JValue(endId);
				ptr[3] = new JValue(progress);
				JNIEnv.CallVoidMethod(base.Handle, id_onTransitionChange_Landroidx_constraintlayout_motion_widget_MotionLayout_IIF, ptr);
			}

			private static Delegate GetOnTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_IHandler()
			{
				if ((object)cb_onTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I == null)
				{
					cb_onTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_OnTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I));
				}
				return cb_onTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I;
			}

			private static void n_OnTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I(IntPtr jnienv, IntPtr native__this, IntPtr native_motionLayout, int currentId)
			{
				ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionCompleted(motionLayout, currentId);
			}

			public unsafe void OnTransitionCompleted(MotionLayout motionLayout, int currentId)
			{
				if (id_onTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I == IntPtr.Zero)
				{
					id_onTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I = JNIEnv.GetMethodID(class_ref, "onTransitionCompleted", "(Landroidx/constraintlayout/motion/widget/MotionLayout;I)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(motionLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(currentId);
				JNIEnv.CallVoidMethod(base.Handle, id_onTransitionCompleted_Landroidx_constraintlayout_motion_widget_MotionLayout_I, ptr);
			}

			private static Delegate GetOnTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_IIHandler()
			{
				if ((object)cb_onTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II == null)
				{
					cb_onTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_OnTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II));
				}
				return cb_onTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II;
			}

			private static void n_OnTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II(IntPtr jnienv, IntPtr native__this, IntPtr native_motionLayout, int startId, int endId)
			{
				ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionStarted(motionLayout, startId, endId);
			}

			public unsafe void OnTransitionStarted(MotionLayout motionLayout, int startId, int endId)
			{
				if (id_onTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II == IntPtr.Zero)
				{
					id_onTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II = JNIEnv.GetMethodID(class_ref, "onTransitionStarted", "(Landroidx/constraintlayout/motion/widget/MotionLayout;II)V");
				}
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(motionLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(startId);
				ptr[2] = new JValue(endId);
				JNIEnv.CallVoidMethod(base.Handle, id_onTransitionStarted_Landroidx_constraintlayout_motion_widget_MotionLayout_II, ptr);
			}

			private static Delegate GetOnTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZFHandler()
			{
				if ((object)cb_onTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF == null)
				{
					cb_onTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIZF_V(n_OnTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF));
				}
				return cb_onTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF;
			}

			private static void n_OnTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF(IntPtr jnienv, IntPtr native__this, IntPtr native_motionLayout, int triggerId, bool positive, float progress)
			{
				ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
				transitionListener.OnTransitionTrigger(motionLayout, triggerId, positive, progress);
			}

			public unsafe void OnTransitionTrigger(MotionLayout motionLayout, int triggerId, bool positive, float progress)
			{
				if (id_onTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF == IntPtr.Zero)
				{
					id_onTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF = JNIEnv.GetMethodID(class_ref, "onTransitionTrigger", "(Landroidx/constraintlayout/motion/widget/MotionLayout;IZF)V");
				}
				JValue* ptr = stackalloc JValue[4];
				*ptr = new JValue(motionLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(triggerId);
				ptr[2] = new JValue(positive);
				ptr[3] = new JValue(progress);
				JNIEnv.CallVoidMethod(base.Handle, id_onTransitionTrigger_Landroidx_constraintlayout_motion_widget_MotionLayout_IZF, ptr);
			}
		}

		public class TransitionChangeEventArgs : EventArgs
		{
			private MotionLayout motionLayout;

			private int startId;

			private int endId;

			private float progress;

			public TransitionChangeEventArgs(MotionLayout motionLayout, int startId, int endId, float progress)
			{
				this.motionLayout = motionLayout;
				this.startId = startId;
				this.endId = endId;
				this.progress = progress;
			}
		}

		public class TransitionCompletedEventArgs : EventArgs
		{
			private MotionLayout motionLayout;

			private int currentId;

			public TransitionCompletedEventArgs(MotionLayout motionLayout, int currentId)
			{
				this.motionLayout = motionLayout;
				this.currentId = currentId;
			}
		}

		public class TransitionStartedEventArgs : EventArgs
		{
			private MotionLayout motionLayout;

			private int startId;

			private int endId;

			public TransitionStartedEventArgs(MotionLayout motionLayout, int startId, int endId)
			{
				this.motionLayout = motionLayout;
				this.startId = startId;
				this.endId = endId;
			}
		}

		public class TransitionTriggerEventArgs : EventArgs
		{
			private MotionLayout motionLayout;

			private int triggerId;

			private bool positive;

			private float progress;

			public TransitionTriggerEventArgs(MotionLayout motionLayout, int triggerId, bool positive, float progress)
			{
				this.motionLayout = motionLayout;
				this.triggerId = triggerId;
				this.positive = positive;
				this.progress = progress;
			}
		}

		[Register("mono/androidx/constraintlayout/motion/widget/MotionLayout_TransitionListenerImplementor")]
		internal sealed class ITransitionListenerImplementor : Java.Lang.Object, ITransitionListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<TransitionChangeEventArgs> OnTransitionChangeHandler;

			public EventHandler<TransitionCompletedEventArgs> OnTransitionCompletedHandler;

			public EventHandler<TransitionStartedEventArgs> OnTransitionStartedHandler;

			public EventHandler<TransitionTriggerEventArgs> OnTransitionTriggerHandler;

			public ITransitionListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/androidx/constraintlayout/motion/widget/MotionLayout_TransitionListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnTransitionChange(MotionLayout motionLayout, int startId, int endId, float progress)
			{
				OnTransitionChangeHandler?.Invoke(sender, new TransitionChangeEventArgs(motionLayout, startId, endId, progress));
			}

			public void OnTransitionCompleted(MotionLayout motionLayout, int currentId)
			{
				OnTransitionCompletedHandler?.Invoke(sender, new TransitionCompletedEventArgs(motionLayout, currentId));
			}

			public void OnTransitionStarted(MotionLayout motionLayout, int startId, int endId)
			{
				OnTransitionStartedHandler?.Invoke(sender, new TransitionStartedEventArgs(motionLayout, startId, endId));
			}

			public void OnTransitionTrigger(MotionLayout motionLayout, int triggerId, bool positive, float progress)
			{
				OnTransitionTriggerHandler?.Invoke(sender, new TransitionTriggerEventArgs(motionLayout, triggerId, positive, progress));
			}

			internal static bool __IsEmpty(ITransitionListenerImplementor value)
			{
				if (value.OnTransitionChangeHandler == null && value.OnTransitionCompletedHandler == null && value.OnTransitionStartedHandler == null)
				{
					return value.OnTransitionTriggerHandler == null;
				}
				return false;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionLayout", typeof(MotionLayout));

		private static Delegate cb_getCurrentState;

		private static Delegate cb_getDefinedTransitions;

		private static Delegate cb_getDesignTool;

		private static Delegate cb_getEndState;

		private static Delegate cb_isInteractionEnabled;

		private static Delegate cb_setInteractionEnabled_Z;

		private static Delegate cb_getNanoTime;

		private static Delegate cb_getProgress;

		private static Delegate cb_setProgress_F;

		private static Delegate cb_getStartState;

		private static Delegate cb_getTargetPosition;

		private static Delegate cb_getTransitionState;

		private static Delegate cb_setTransitionState_Landroid_os_Bundle_;

		private static Delegate cb_getTransitionTimeMs;

		private static Delegate cb_getVelocity;

		private static Delegate cb_enableTransition_IZ;

		private static Delegate cb_fireTransitionCompleted;

		private static Delegate cb_fireTrigger_IZF;

		private static Delegate cb_getConstraintSet_I;

		private static Delegate cb_getConstraintSetIds;

		private static Delegate cb_getDebugMode_Z;

		private static Delegate cb_getTransition_I;

		private static Delegate cb_getViewVelocity_Landroid_view_View_FFarrayFI;

		private static Delegate cb_obtainVelocityTracker;

		private static Delegate cb_onNestedPreScroll_Landroid_view_View_IIarrayII;

		private static Delegate cb_onNestedScroll_Landroid_view_View_IIIII;

		private static Delegate cb_onNestedScroll_Landroid_view_View_IIIIIarrayI;

		private static Delegate cb_onNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II;

		private static Delegate cb_onStartNestedScroll_Landroid_view_View_Landroid_view_View_II;

		private static Delegate cb_onStopNestedScroll_Landroid_view_View_I;

		private static Delegate cb_rebuildMotion;

		private static Delegate cb_rebuildScene;

		private static Delegate cb_removeTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_;

		private static Delegate cb_setDebugMode_I;

		private static Delegate cb_setInterpolatedProgress_F;

		private static Delegate cb_setOnHide_F;

		private static Delegate cb_setOnShow_F;

		private static Delegate cb_setProgress_FF;

		private static Delegate cb_setScene_Landroidx_constraintlayout_motion_widget_MotionScene_;

		private static Delegate cb_setTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;

		private static Delegate cb_setTransition_I;

		private static Delegate cb_setTransition_II;

		private static Delegate cb_setTransitionDuration_I;

		private static Delegate cb_setTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_;

		private static Delegate cb_touchAnimateTo_IFF;

		private static Delegate cb_transitionToEnd;

		private static Delegate cb_transitionToStart;

		private static Delegate cb_transitionToState_I;

		private static Delegate cb_transitionToState_III;

		private static Delegate cb_updateState;

		private static Delegate cb_updateState_ILandroidx_constraintlayout_widget_ConstraintSet_;

		private WeakReference weak_implementor_SetTransitionListener;

		[Register("mMeasureDuringTransition")]
		protected bool MMeasureDuringTransition
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mMeasureDuringTransition.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMeasureDuringTransition.Z", this, value);
			}
		}

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int CurrentState
		{
			[Register("getCurrentState", "()I", "GetGetCurrentStateHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getCurrentState.()I", this, null);
			}
		}

		public unsafe virtual IList<MotionScene.Transition> DefinedTransitions
		{
			[Register("getDefinedTransitions", "()Ljava/util/ArrayList;", "GetGetDefinedTransitionsHandler")]
			get
			{
				return JavaList<MotionScene.Transition>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefinedTransitions.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual DesignTool DesignTool
		{
			[Register("getDesignTool", "()Landroidx/constraintlayout/motion/widget/DesignTool;", "GetGetDesignToolHandler")]
			get
			{
				return Java.Lang.Object.GetObject<DesignTool>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDesignTool.()Landroidx/constraintlayout/motion/widget/DesignTool;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int EndState
		{
			[Register("getEndState", "()I", "GetGetEndStateHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getEndState.()I", this, null);
			}
		}

		public unsafe virtual bool InteractionEnabled
		{
			[Register("isInteractionEnabled", "()Z", "GetIsInteractionEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInteractionEnabled.()Z", this, null);
			}
			[Register("setInteractionEnabled", "(Z)V", "GetSetInteractionEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setInteractionEnabled.(Z)V", this, ptr);
			}
		}

		protected unsafe virtual long NanoTime
		{
			[Register("getNanoTime", "()J", "GetGetNanoTimeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getNanoTime.()J", this, null);
			}
		}

		public unsafe virtual float Progress
		{
			[Register("getProgress", "()F", "GetGetProgressHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getProgress.()F", this, null);
			}
			[Register("setProgress", "(F)V", "GetSetProgress_FHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setProgress.(F)V", this, ptr);
			}
		}

		public unsafe virtual int StartState
		{
			[Register("getStartState", "()I", "GetGetStartStateHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getStartState.()I", this, null);
			}
		}

		public unsafe virtual float TargetPosition
		{
			[Register("getTargetPosition", "()F", "GetGetTargetPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getTargetPosition.()F", this, null);
			}
		}

		public unsafe virtual Bundle TransitionState
		{
			[Register("getTransitionState", "()Landroid/os/Bundle;", "GetGetTransitionStateHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransitionState.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTransitionState", "(Landroid/os/Bundle;)V", "GetSetTransitionState_Landroid_os_Bundle_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setTransitionState.(Landroid/os/Bundle;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual long TransitionTimeMs
		{
			[Register("getTransitionTimeMs", "()J", "GetGetTransitionTimeMsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getTransitionTimeMs.()J", this, null);
			}
		}

		public unsafe virtual float Velocity
		{
			[Register("getVelocity", "()F", "GetGetVelocityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getVelocity.()F", this, null);
			}
		}

		public event EventHandler<TransitionChangeEventArgs> TransitionChange
		{
			add
			{
				EventHelper.AddEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, __CreateITransitionListenerImplementor, SetTransitionListener, delegate(ITransitionListenerImplementor __h)
				{
					__h.OnTransitionChangeHandler = (EventHandler<TransitionChangeEventArgs>)Delegate.Combine(__h.OnTransitionChangeHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, ITransitionListenerImplementor.__IsEmpty, delegate
				{
					SetTransitionListener(null);
				}, delegate(ITransitionListenerImplementor __h)
				{
					__h.OnTransitionChangeHandler = (EventHandler<TransitionChangeEventArgs>)Delegate.Remove(__h.OnTransitionChangeHandler, value);
				});
			}
		}

		public event EventHandler<TransitionCompletedEventArgs> TransitionCompleted
		{
			add
			{
				EventHelper.AddEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, __CreateITransitionListenerImplementor, SetTransitionListener, delegate(ITransitionListenerImplementor __h)
				{
					__h.OnTransitionCompletedHandler = (EventHandler<TransitionCompletedEventArgs>)Delegate.Combine(__h.OnTransitionCompletedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, ITransitionListenerImplementor.__IsEmpty, delegate
				{
					SetTransitionListener(null);
				}, delegate(ITransitionListenerImplementor __h)
				{
					__h.OnTransitionCompletedHandler = (EventHandler<TransitionCompletedEventArgs>)Delegate.Remove(__h.OnTransitionCompletedHandler, value);
				});
			}
		}

		public event EventHandler<TransitionStartedEventArgs> TransitionStarted
		{
			add
			{
				EventHelper.AddEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, __CreateITransitionListenerImplementor, SetTransitionListener, delegate(ITransitionListenerImplementor __h)
				{
					__h.OnTransitionStartedHandler = (EventHandler<TransitionStartedEventArgs>)Delegate.Combine(__h.OnTransitionStartedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, ITransitionListenerImplementor.__IsEmpty, delegate
				{
					SetTransitionListener(null);
				}, delegate(ITransitionListenerImplementor __h)
				{
					__h.OnTransitionStartedHandler = (EventHandler<TransitionStartedEventArgs>)Delegate.Remove(__h.OnTransitionStartedHandler, value);
				});
			}
		}

		public event EventHandler<TransitionTriggerEventArgs> TransitionTrigger
		{
			add
			{
				EventHelper.AddEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, __CreateITransitionListenerImplementor, SetTransitionListener, delegate(ITransitionListenerImplementor __h)
				{
					__h.OnTransitionTriggerHandler = (EventHandler<TransitionTriggerEventArgs>)Delegate.Combine(__h.OnTransitionTriggerHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<ITransitionListener, ITransitionListenerImplementor>(ref weak_implementor_SetTransitionListener, ITransitionListenerImplementor.__IsEmpty, delegate
				{
					SetTransitionListener(null);
				}, delegate(ITransitionListenerImplementor __h)
				{
					__h.OnTransitionTriggerHandler = (EventHandler<TransitionTriggerEventArgs>)Delegate.Remove(__h.OnTransitionTriggerHandler, value);
				});
			}
		}

		protected MotionLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe MotionLayout(Context context)
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
		public unsafe MotionLayout(Context context, IAttributeSet attrs)
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
		public unsafe MotionLayout(Context context, IAttributeSet attrs, int defStyleAttr)
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

		private static Delegate GetGetCurrentStateHandler()
		{
			if ((object)cb_getCurrentState == null)
			{
				cb_getCurrentState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCurrentState));
			}
			return cb_getCurrentState;
		}

		private static int n_GetCurrentState(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentState;
		}

		private static Delegate GetGetDefinedTransitionsHandler()
		{
			if ((object)cb_getDefinedTransitions == null)
			{
				cb_getDefinedTransitions = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefinedTransitions));
			}
			return cb_getDefinedTransitions;
		}

		private static IntPtr n_GetDefinedTransitions(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<MotionScene.Transition>.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefinedTransitions);
		}

		private static Delegate GetGetDesignToolHandler()
		{
			if ((object)cb_getDesignTool == null)
			{
				cb_getDesignTool = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDesignTool));
			}
			return cb_getDesignTool;
		}

		private static IntPtr n_GetDesignTool(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DesignTool);
		}

		private static Delegate GetGetEndStateHandler()
		{
			if ((object)cb_getEndState == null)
			{
				cb_getEndState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetEndState));
			}
			return cb_getEndState;
		}

		private static int n_GetEndState(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndState;
		}

		private static Delegate GetIsInteractionEnabledHandler()
		{
			if ((object)cb_isInteractionEnabled == null)
			{
				cb_isInteractionEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInteractionEnabled));
			}
			return cb_isInteractionEnabled;
		}

		private static bool n_IsInteractionEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InteractionEnabled;
		}

		private static Delegate GetSetInteractionEnabled_ZHandler()
		{
			if ((object)cb_setInteractionEnabled_Z == null)
			{
				cb_setInteractionEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetInteractionEnabled_Z));
			}
			return cb_setInteractionEnabled_Z;
		}

		private static void n_SetInteractionEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InteractionEnabled = enabled;
		}

		private static Delegate GetGetNanoTimeHandler()
		{
			if ((object)cb_getNanoTime == null)
			{
				cb_getNanoTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetNanoTime));
			}
			return cb_getNanoTime;
		}

		private static long n_GetNanoTime(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NanoTime;
		}

		private static Delegate GetGetProgressHandler()
		{
			if ((object)cb_getProgress == null)
			{
				cb_getProgress = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetProgress));
			}
			return cb_getProgress;
		}

		private static float n_GetProgress(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress;
		}

		private static Delegate GetSetProgress_FHandler()
		{
			if ((object)cb_setProgress_F == null)
			{
				cb_setProgress_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetProgress_F));
			}
			return cb_setProgress_F;
		}

		private static void n_SetProgress_F(IntPtr jnienv, IntPtr native__this, float pos)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress = pos;
		}

		private static Delegate GetGetStartStateHandler()
		{
			if ((object)cb_getStartState == null)
			{
				cb_getStartState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetStartState));
			}
			return cb_getStartState;
		}

		private static int n_GetStartState(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartState;
		}

		private static Delegate GetGetTargetPositionHandler()
		{
			if ((object)cb_getTargetPosition == null)
			{
				cb_getTargetPosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetTargetPosition));
			}
			return cb_getTargetPosition;
		}

		private static float n_GetTargetPosition(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetPosition;
		}

		private static Delegate GetGetTransitionStateHandler()
		{
			if ((object)cb_getTransitionState == null)
			{
				cb_getTransitionState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTransitionState));
			}
			return cb_getTransitionState;
		}

		private static IntPtr n_GetTransitionState(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionState);
		}

		private static Delegate GetSetTransitionState_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_setTransitionState_Landroid_os_Bundle_ == null)
			{
				cb_setTransitionState_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTransitionState_Landroid_os_Bundle_));
			}
			return cb_setTransitionState_Landroid_os_Bundle_;
		}

		private static void n_SetTransitionState_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_bundle)
		{
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle transitionState = Java.Lang.Object.GetObject<Bundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			motionLayout.TransitionState = transitionState;
		}

		private static Delegate GetGetTransitionTimeMsHandler()
		{
			if ((object)cb_getTransitionTimeMs == null)
			{
				cb_getTransitionTimeMs = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTransitionTimeMs));
			}
			return cb_getTransitionTimeMs;
		}

		private static long n_GetTransitionTimeMs(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionTimeMs;
		}

		private static Delegate GetGetVelocityHandler()
		{
			if ((object)cb_getVelocity == null)
			{
				cb_getVelocity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetVelocity));
			}
			return cb_getVelocity;
		}

		private static float n_GetVelocity(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Velocity;
		}

		private static Delegate GetEnableTransition_IZHandler()
		{
			if ((object)cb_enableTransition_IZ == null)
			{
				cb_enableTransition_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIZ_V(n_EnableTransition_IZ));
			}
			return cb_enableTransition_IZ;
		}

		private static void n_EnableTransition_IZ(IntPtr jnienv, IntPtr native__this, int transitionID, bool enable)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableTransition(transitionID, enable);
		}

		[Register("enableTransition", "(IZ)V", "GetEnableTransition_IZHandler")]
		public unsafe virtual void EnableTransition(int transitionID, bool enable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(transitionID);
			ptr[1] = new JniArgumentValue(enable);
			_members.InstanceMethods.InvokeVirtualVoidMethod("enableTransition.(IZ)V", this, ptr);
		}

		private static Delegate GetFireTransitionCompletedHandler()
		{
			if ((object)cb_fireTransitionCompleted == null)
			{
				cb_fireTransitionCompleted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_FireTransitionCompleted));
			}
			return cb_fireTransitionCompleted;
		}

		private static void n_FireTransitionCompleted(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FireTransitionCompleted();
		}

		[Register("fireTransitionCompleted", "()V", "GetFireTransitionCompletedHandler")]
		protected unsafe virtual void FireTransitionCompleted()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("fireTransitionCompleted.()V", this, null);
		}

		private static Delegate GetFireTrigger_IZFHandler()
		{
			if ((object)cb_fireTrigger_IZF == null)
			{
				cb_fireTrigger_IZF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIZF_V(n_FireTrigger_IZF));
			}
			return cb_fireTrigger_IZF;
		}

		private static void n_FireTrigger_IZF(IntPtr jnienv, IntPtr native__this, int triggerId, bool positive, float progress)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FireTrigger(triggerId, positive, progress);
		}

		[Register("fireTrigger", "(IZF)V", "GetFireTrigger_IZFHandler")]
		public unsafe virtual void FireTrigger(int triggerId, bool positive, float progress)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(triggerId);
			ptr[1] = new JniArgumentValue(positive);
			ptr[2] = new JniArgumentValue(progress);
			_members.InstanceMethods.InvokeVirtualVoidMethod("fireTrigger.(IZF)V", this, ptr);
		}

		private static Delegate GetGetConstraintSet_IHandler()
		{
			if ((object)cb_getConstraintSet_I == null)
			{
				cb_getConstraintSet_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetConstraintSet_I));
			}
			return cb_getConstraintSet_I;
		}

		private static IntPtr n_GetConstraintSet_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetConstraintSet(id));
		}

		[Register("getConstraintSet", "(I)Landroidx/constraintlayout/widget/ConstraintSet;", "GetGetConstraintSet_IHandler")]
		public unsafe virtual ConstraintSet GetConstraintSet(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<ConstraintSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintSet.(I)Landroidx/constraintlayout/widget/ConstraintSet;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetConstraintSetIdsHandler()
		{
			if ((object)cb_getConstraintSetIds == null)
			{
				cb_getConstraintSetIds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConstraintSetIds));
			}
			return cb_getConstraintSetIds;
		}

		private static IntPtr n_GetConstraintSetIds(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetConstraintSetIds());
		}

		[Register("getConstraintSetIds", "()[I", "GetGetConstraintSetIdsHandler")]
		public unsafe virtual int[] GetConstraintSetIds()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintSetIds.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		private static Delegate GetGetDebugMode_ZHandler()
		{
			if ((object)cb_getDebugMode_Z == null)
			{
				cb_getDebugMode_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_GetDebugMode_Z));
			}
			return cb_getDebugMode_Z;
		}

		private static void n_GetDebugMode_Z(IntPtr jnienv, IntPtr native__this, bool showPaths)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDebugMode(showPaths);
		}

		[Register("getDebugMode", "(Z)V", "GetGetDebugMode_ZHandler")]
		public unsafe virtual void GetDebugMode(bool showPaths)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(showPaths);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getDebugMode.(Z)V", this, ptr);
		}

		private static Delegate GetGetTransition_IHandler()
		{
			if ((object)cb_getTransition_I == null)
			{
				cb_getTransition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetTransition_I));
			}
			return cb_getTransition_I;
		}

		private static IntPtr n_GetTransition_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTransition(id));
		}

		[Register("getTransition", "(I)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", "GetGetTransition_IHandler")]
		public unsafe virtual MotionScene.Transition GetTransition(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<MotionScene.Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransition.(I)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetViewVelocity_Landroid_view_View_FFarrayFIHandler()
		{
			if ((object)cb_getViewVelocity_Landroid_view_View_FFarrayFI == null)
			{
				cb_getViewVelocity_Landroid_view_View_FFarrayFI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLFFLI_V(n_GetViewVelocity_Landroid_view_View_FFarrayFI));
			}
			return cb_getViewVelocity_Landroid_view_View_FFarrayFI;
		}

		private static void n_GetViewVelocity_Landroid_view_View_FFarrayFI(IntPtr jnienv, IntPtr native__this, IntPtr native_view, float posOnViewX, float posOnViewY, IntPtr native_returnVelocity, int type)
		{
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_returnVelocity, JniHandleOwnership.DoNotTransfer, typeof(float));
			motionLayout.GetViewVelocity(view, posOnViewX, posOnViewY, array, type);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_returnVelocity);
			}
		}

		[Register("getViewVelocity", "(Landroid/view/View;FF[FI)V", "GetGetViewVelocity_Landroid_view_View_FFarrayFIHandler")]
		public unsafe virtual void GetViewVelocity(View view, float posOnViewX, float posOnViewY, float[] returnVelocity, int type)
		{
			IntPtr intPtr = JNIEnv.NewArray(returnVelocity);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(posOnViewX);
				ptr[2] = new JniArgumentValue(posOnViewY);
				ptr[3] = new JniArgumentValue(intPtr);
				ptr[4] = new JniArgumentValue(type);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getViewVelocity.(Landroid/view/View;FF[FI)V", this, ptr);
			}
			finally
			{
				if (returnVelocity != null)
				{
					JNIEnv.CopyArray(intPtr, returnVelocity);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(view);
				GC.KeepAlive(returnVelocity);
			}
		}

		private static Delegate GetObtainVelocityTrackerHandler()
		{
			if ((object)cb_obtainVelocityTracker == null)
			{
				cb_obtainVelocityTracker = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ObtainVelocityTracker));
			}
			return cb_obtainVelocityTracker;
		}

		private static IntPtr n_ObtainVelocityTracker(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ObtainVelocityTracker());
		}

		[Register("obtainVelocityTracker", "()Landroidx/constraintlayout/motion/widget/MotionLayout$MotionTracker;", "GetObtainVelocityTrackerHandler")]
		protected unsafe virtual IMotionTracker ObtainVelocityTracker()
		{
			return Java.Lang.Object.GetObject<IMotionTracker>(_members.InstanceMethods.InvokeVirtualObjectMethod("obtainVelocityTracker.()Landroidx/constraintlayout/motion/widget/MotionLayout$MotionTracker;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			motionLayout.OnNestedPreScroll(target, dx, dy, array, type);
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
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			motionLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);
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
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			motionLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type, array);
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

		private static void n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_child, IntPtr native_target, int axes, int type)
		{
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			motionLayout.OnNestedScrollAccepted(child, target, axes, type);
		}

		[Register("onNestedScrollAccepted", "(Landroid/view/View;Landroid/view/View;II)V", "GetOnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_IIHandler")]
		public unsafe virtual void OnNestedScrollAccepted(View child, View target, int axes, int type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(axes);
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

		private static bool n_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_child, IntPtr native_target, int axes, int type)
		{
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return motionLayout.OnStartNestedScroll(child, target, axes, type);
		}

		[Register("onStartNestedScroll", "(Landroid/view/View;Landroid/view/View;II)Z", "GetOnStartNestedScroll_Landroid_view_View_Landroid_view_View_IIHandler")]
		public unsafe virtual bool OnStartNestedScroll(View child, View target, int axes, int type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(axes);
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
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			motionLayout.OnStopNestedScroll(target, type);
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

		private static Delegate GetRebuildMotionHandler()
		{
			if ((object)cb_rebuildMotion == null)
			{
				cb_rebuildMotion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RebuildMotion));
			}
			return cb_rebuildMotion;
		}

		private static void n_RebuildMotion(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RebuildMotion();
		}

		[Register("rebuildMotion", "()V", "GetRebuildMotionHandler")]
		public unsafe virtual void RebuildMotion()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("rebuildMotion.()V", this, null);
		}

		private static Delegate GetRebuildSceneHandler()
		{
			if ((object)cb_rebuildScene == null)
			{
				cb_rebuildScene = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RebuildScene));
			}
			return cb_rebuildScene;
		}

		private static void n_RebuildScene(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RebuildScene();
		}

		[Register("rebuildScene", "()V", "GetRebuildSceneHandler")]
		public unsafe virtual void RebuildScene()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("rebuildScene.()V", this, null);
		}

		private static Delegate GetRemoveTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_Handler()
		{
			if ((object)cb_removeTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_ == null)
			{
				cb_removeTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_RemoveTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_));
			}
			return cb_removeTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_;
		}

		private static bool n_RemoveTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransitionListener listener = Java.Lang.Object.GetObject<ITransitionListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			return motionLayout.RemoveTransitionListener(listener);
		}

		[Register("removeTransitionListener", "(Landroidx/constraintlayout/motion/widget/MotionLayout$TransitionListener;)Z", "GetRemoveTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_Handler")]
		public unsafe virtual bool RemoveTransitionListener(ITransitionListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeTransitionListener.(Landroidx/constraintlayout/motion/widget/MotionLayout$TransitionListener;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetDebugMode_IHandler()
		{
			if ((object)cb_setDebugMode_I == null)
			{
				cb_setDebugMode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetDebugMode_I));
			}
			return cb_setDebugMode_I;
		}

		private static void n_SetDebugMode_I(IntPtr jnienv, IntPtr native__this, int debugMode)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDebugMode(debugMode);
		}

		[Register("setDebugMode", "(I)V", "GetSetDebugMode_IHandler")]
		public unsafe virtual void SetDebugMode(int debugMode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(debugMode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDebugMode.(I)V", this, ptr);
		}

		private static Delegate GetSetInterpolatedProgress_FHandler()
		{
			if ((object)cb_setInterpolatedProgress_F == null)
			{
				cb_setInterpolatedProgress_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetInterpolatedProgress_F));
			}
			return cb_setInterpolatedProgress_F;
		}

		private static void n_SetInterpolatedProgress_F(IntPtr jnienv, IntPtr native__this, float pos)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetInterpolatedProgress(pos);
		}

		[Register("setInterpolatedProgress", "(F)V", "GetSetInterpolatedProgress_FHandler")]
		public unsafe virtual void SetInterpolatedProgress(float pos)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(pos);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolatedProgress.(F)V", this, ptr);
		}

		private static Delegate GetSetOnHide_FHandler()
		{
			if ((object)cb_setOnHide_F == null)
			{
				cb_setOnHide_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetOnHide_F));
			}
			return cb_setOnHide_F;
		}

		private static void n_SetOnHide_F(IntPtr jnienv, IntPtr native__this, float progress)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOnHide(progress);
		}

		[Register("setOnHide", "(F)V", "GetSetOnHide_FHandler")]
		public unsafe virtual void SetOnHide(float progress)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(progress);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnHide.(F)V", this, ptr);
		}

		private static Delegate GetSetOnShow_FHandler()
		{
			if ((object)cb_setOnShow_F == null)
			{
				cb_setOnShow_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetOnShow_F));
			}
			return cb_setOnShow_F;
		}

		private static void n_SetOnShow_F(IntPtr jnienv, IntPtr native__this, float progress)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOnShow(progress);
		}

		[Register("setOnShow", "(F)V", "GetSetOnShow_FHandler")]
		public unsafe virtual void SetOnShow(float progress)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(progress);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnShow.(F)V", this, ptr);
		}

		private static Delegate GetSetProgress_FFHandler()
		{
			if ((object)cb_setProgress_FF == null)
			{
				cb_setProgress_FF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPFF_V(n_SetProgress_FF));
			}
			return cb_setProgress_FF;
		}

		private static void n_SetProgress_FF(IntPtr jnienv, IntPtr native__this, float pos, float velocity)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetProgress(pos, velocity);
		}

		[Register("setProgress", "(FF)V", "GetSetProgress_FFHandler")]
		public unsafe virtual void SetProgress(float pos, float velocity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(pos);
			ptr[1] = new JniArgumentValue(velocity);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProgress.(FF)V", this, ptr);
		}

		private static Delegate GetSetScene_Landroidx_constraintlayout_motion_widget_MotionScene_Handler()
		{
			if ((object)cb_setScene_Landroidx_constraintlayout_motion_widget_MotionScene_ == null)
			{
				cb_setScene_Landroidx_constraintlayout_motion_widget_MotionScene_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetScene_Landroidx_constraintlayout_motion_widget_MotionScene_));
			}
			return cb_setScene_Landroidx_constraintlayout_motion_widget_MotionScene_;
		}

		private static void n_SetScene_Landroidx_constraintlayout_motion_widget_MotionScene_(IntPtr jnienv, IntPtr native__this, IntPtr native_scene)
		{
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionScene scene = Java.Lang.Object.GetObject<MotionScene>(native_scene, JniHandleOwnership.DoNotTransfer);
			motionLayout.SetScene(scene);
		}

		[Register("setScene", "(Landroidx/constraintlayout/motion/widget/MotionScene;)V", "GetSetScene_Landroidx_constraintlayout_motion_widget_MotionScene_Handler")]
		public unsafe virtual void SetScene(MotionScene scene)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(scene?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setScene.(Landroidx/constraintlayout/motion/widget/MotionScene;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(scene);
			}
		}

		private static Delegate GetSetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler()
		{
			if ((object)cb_setTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_ == null)
			{
				cb_setTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_));
			}
			return cb_setTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;
		}

		private static void n_SetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
		{
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionScene.Transition transition = Java.Lang.Object.GetObject<MotionScene.Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			motionLayout.SetTransition(transition);
		}

		[Register("setTransition", "(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", "GetSetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler")]
		protected unsafe virtual void SetTransition(MotionScene.Transition transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transition);
			}
		}

		private static Delegate GetSetTransition_IHandler()
		{
			if ((object)cb_setTransition_I == null)
			{
				cb_setTransition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetTransition_I));
			}
			return cb_setTransition_I;
		}

		private static void n_SetTransition_I(IntPtr jnienv, IntPtr native__this, int transitionId)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransition(transitionId);
		}

		[Register("setTransition", "(I)V", "GetSetTransition_IHandler")]
		public unsafe virtual void SetTransition(int transitionId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(transitionId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(I)V", this, ptr);
		}

		private static Delegate GetSetTransition_IIHandler()
		{
			if ((object)cb_setTransition_II == null)
			{
				cb_setTransition_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetTransition_II));
			}
			return cb_setTransition_II;
		}

		private static void n_SetTransition_II(IntPtr jnienv, IntPtr native__this, int beginId, int endId)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransition(beginId, endId);
		}

		[Register("setTransition", "(II)V", "GetSetTransition_IIHandler")]
		public unsafe virtual void SetTransition(int beginId, int endId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(beginId);
			ptr[1] = new JniArgumentValue(endId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(II)V", this, ptr);
		}

		private static Delegate GetSetTransitionDuration_IHandler()
		{
			if ((object)cb_setTransitionDuration_I == null)
			{
				cb_setTransitionDuration_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetTransitionDuration_I));
			}
			return cb_setTransitionDuration_I;
		}

		private static void n_SetTransitionDuration_I(IntPtr jnienv, IntPtr native__this, int milliseconds)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransitionDuration(milliseconds);
		}

		[Register("setTransitionDuration", "(I)V", "GetSetTransitionDuration_IHandler")]
		public unsafe virtual void SetTransitionDuration(int milliseconds)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(milliseconds);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransitionDuration.(I)V", this, ptr);
		}

		private static Delegate GetSetTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_Handler()
		{
			if ((object)cb_setTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_ == null)
			{
				cb_setTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_));
			}
			return cb_setTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_;
		}

		private static void n_SetTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransitionListener transitionListener = Java.Lang.Object.GetObject<ITransitionListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			motionLayout.SetTransitionListener(transitionListener);
		}

		[Register("setTransitionListener", "(Landroidx/constraintlayout/motion/widget/MotionLayout$TransitionListener;)V", "GetSetTransitionListener_Landroidx_constraintlayout_motion_widget_MotionLayout_TransitionListener_Handler")]
		public unsafe virtual void SetTransitionListener(ITransitionListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTransitionListener.(Landroidx/constraintlayout/motion/widget/MotionLayout$TransitionListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetTouchAnimateTo_IFFHandler()
		{
			if ((object)cb_touchAnimateTo_IFF == null)
			{
				cb_touchAnimateTo_IFF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIFF_V(n_TouchAnimateTo_IFF));
			}
			return cb_touchAnimateTo_IFF;
		}

		private static void n_TouchAnimateTo_IFF(IntPtr jnienv, IntPtr native__this, int touchUpMode, float position, float currentVelocity)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TouchAnimateTo(touchUpMode, position, currentVelocity);
		}

		[Register("touchAnimateTo", "(IFF)V", "GetTouchAnimateTo_IFFHandler")]
		public unsafe virtual void TouchAnimateTo(int touchUpMode, float position, float currentVelocity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(touchUpMode);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(currentVelocity);
			_members.InstanceMethods.InvokeVirtualVoidMethod("touchAnimateTo.(IFF)V", this, ptr);
		}

		private static Delegate GetTransitionToEndHandler()
		{
			if ((object)cb_transitionToEnd == null)
			{
				cb_transitionToEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_TransitionToEnd));
			}
			return cb_transitionToEnd;
		}

		private static void n_TransitionToEnd(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionToEnd();
		}

		[Register("transitionToEnd", "()V", "GetTransitionToEndHandler")]
		public unsafe virtual void TransitionToEnd()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToEnd.()V", this, null);
		}

		private static Delegate GetTransitionToStartHandler()
		{
			if ((object)cb_transitionToStart == null)
			{
				cb_transitionToStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_TransitionToStart));
			}
			return cb_transitionToStart;
		}

		private static void n_TransitionToStart(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionToStart();
		}

		[Register("transitionToStart", "()V", "GetTransitionToStartHandler")]
		public unsafe virtual void TransitionToStart()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToStart.()V", this, null);
		}

		private static Delegate GetTransitionToState_IHandler()
		{
			if ((object)cb_transitionToState_I == null)
			{
				cb_transitionToState_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_TransitionToState_I));
			}
			return cb_transitionToState_I;
		}

		private static void n_TransitionToState_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionToState(id);
		}

		[Register("transitionToState", "(I)V", "GetTransitionToState_IHandler")]
		public unsafe virtual void TransitionToState(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToState.(I)V", this, ptr);
		}

		private static Delegate GetTransitionToState_IIIHandler()
		{
			if ((object)cb_transitionToState_III == null)
			{
				cb_transitionToState_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_V(n_TransitionToState_III));
			}
			return cb_transitionToState_III;
		}

		private static void n_TransitionToState_III(IntPtr jnienv, IntPtr native__this, int id, int screenWidth, int screenHeight)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransitionToState(id, screenWidth, screenHeight);
		}

		[Register("transitionToState", "(III)V", "GetTransitionToState_IIIHandler")]
		public unsafe virtual void TransitionToState(int id, int screenWidth, int screenHeight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(screenWidth);
			ptr[2] = new JniArgumentValue(screenHeight);
			_members.InstanceMethods.InvokeVirtualVoidMethod("transitionToState.(III)V", this, ptr);
		}

		private static Delegate GetUpdateStateHandler()
		{
			if ((object)cb_updateState == null)
			{
				cb_updateState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_UpdateState));
			}
			return cb_updateState;
		}

		private static void n_UpdateState(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateState();
		}

		[Register("updateState", "()V", "GetUpdateStateHandler")]
		public unsafe virtual void UpdateState()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateState.()V", this, null);
		}

		private static Delegate GetUpdateState_ILandroidx_constraintlayout_widget_ConstraintSet_Handler()
		{
			if ((object)cb_updateState_ILandroidx_constraintlayout_widget_ConstraintSet_ == null)
			{
				cb_updateState_ILandroidx_constraintlayout_widget_ConstraintSet_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_UpdateState_ILandroidx_constraintlayout_widget_ConstraintSet_));
			}
			return cb_updateState_ILandroidx_constraintlayout_widget_ConstraintSet_;
		}

		private static void n_UpdateState_ILandroidx_constraintlayout_widget_ConstraintSet_(IntPtr jnienv, IntPtr native__this, int stateId, IntPtr native_set)
		{
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet set = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			motionLayout.UpdateState(stateId, set);
		}

		[Register("updateState", "(ILandroidx/constraintlayout/widget/ConstraintSet;)V", "GetUpdateState_ILandroidx_constraintlayout_widget_ConstraintSet_Handler")]
		public unsafe virtual void UpdateState(int stateId, ConstraintSet set)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(stateId);
				ptr[1] = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateState.(ILandroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(set);
			}
		}

		private ITransitionListenerImplementor __CreateITransitionListenerImplementor()
		{
			return new ITransitionListenerImplementor(this);
		}
	}
	[Register("androidx/constraintlayout/motion/widget/MotionScene", DoNotGenerateAcw = true)]
	public class MotionScene : Java.Lang.Object
	{
		[Register("androidx/constraintlayout/motion/widget/MotionScene$Transition", DoNotGenerateAcw = true)]
		public class Transition : Java.Lang.Object
		{
			[Register("androidx/constraintlayout/motion/widget/MotionScene$Transition$TransitionOnClick", DoNotGenerateAcw = true)]
			public class TransitionOnClick : Java.Lang.Object, View.IOnClickListener, IJavaObject, IDisposable, IJavaPeerable
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionScene$Transition$TransitionOnClick", typeof(TransitionOnClick));

				private static Delegate cb_addOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_;

				private static Delegate cb_onClick_Landroid_view_View_;

				private static Delegate cb_removeOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_;

				internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

				public override JniPeerMembers JniPeerMembers => _members;

				protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

				protected override Type ThresholdType => _members.ManagedPeerType;

				protected TransitionOnClick(IntPtr javaReference, JniHandleOwnership transfer)
					: base(javaReference, transfer)
				{
				}

				[Register(".ctor", "(Landroid/content/Context;Landroidx/constraintlayout/motion/widget/MotionScene$Transition;Lorg/xmlpull/v1/XmlPullParser;)V", "")]
				public unsafe TransitionOnClick(Context context, Transition transition, XmlReader parser)
					: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
				{
					if (base.Handle != IntPtr.Zero)
					{
						return;
					}
					IntPtr intPtr = XmlReaderPullParser.ToLocalJniHandle(parser);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
						*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
						ptr[1] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
						ptr[2] = new JniArgumentValue(intPtr);
						SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroidx/constraintlayout/motion/widget/MotionScene$Transition;Lorg/xmlpull/v1/XmlPullParser;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
						_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroidx/constraintlayout/motion/widget/MotionScene$Transition;Lorg/xmlpull/v1/XmlPullParser;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
						GC.KeepAlive(context);
						GC.KeepAlive(transition);
						GC.KeepAlive(parser);
					}
				}

				private static Delegate GetAddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler()
				{
					if ((object)cb_addOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_ == null)
					{
						cb_addOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_AddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_));
					}
					return cb_addOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_;
				}

				private static void n_AddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_motionLayout, int currentState, IntPtr native_transition)
				{
					TransitionOnClick transitionOnClick = Java.Lang.Object.GetObject<TransitionOnClick>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
					Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
					transitionOnClick.AddOnClickListeners(motionLayout, currentState, transition);
				}

				[Register("addOnClickListeners", "(Landroidx/constraintlayout/motion/widget/MotionLayout;ILandroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", "GetAddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler")]
				public unsafe virtual void AddOnClickListeners(MotionLayout motionLayout, int currentState, Transition transition)
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
						*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
						ptr[1] = new JniArgumentValue(currentState);
						ptr[2] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
						_members.InstanceMethods.InvokeVirtualVoidMethod("addOnClickListeners.(Landroidx/constraintlayout/motion/widget/MotionLayout;ILandroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(motionLayout);
						GC.KeepAlive(transition);
					}
				}

				private static Delegate GetOnClick_Landroid_view_View_Handler()
				{
					if ((object)cb_onClick_Landroid_view_View_ == null)
					{
						cb_onClick_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnClick_Landroid_view_View_));
					}
					return cb_onClick_Landroid_view_View_;
				}

				private static void n_OnClick_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
				{
					TransitionOnClick transitionOnClick = Java.Lang.Object.GetObject<TransitionOnClick>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
					transitionOnClick.OnClick(view);
				}

				[Register("onClick", "(Landroid/view/View;)V", "GetOnClick_Landroid_view_View_Handler")]
				public unsafe virtual void OnClick(View view)
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
						_members.InstanceMethods.InvokeVirtualVoidMethod("onClick.(Landroid/view/View;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(view);
					}
				}

				private static Delegate GetRemoveOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_Handler()
				{
					if ((object)cb_removeOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ == null)
					{
						cb_removeOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_));
					}
					return cb_removeOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_;
				}

				private static void n_RemoveOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_motionLayout)
				{
					TransitionOnClick transitionOnClick = Java.Lang.Object.GetObject<TransitionOnClick>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
					transitionOnClick.RemoveOnClickListeners(motionLayout);
				}

				[Register("removeOnClickListeners", "(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", "GetRemoveOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_Handler")]
				public unsafe virtual void RemoveOnClickListeners(MotionLayout motionLayout)
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
						_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnClickListeners.(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(motionLayout);
					}
				}
			}

			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionScene$Transition", typeof(Transition));

			private static Delegate cb_getAutoTransition;

			private static Delegate cb_setAutoTransition_I;

			private static Delegate cb_getDuration;

			private static Delegate cb_setDuration_I;

			private static Delegate cb_getEndConstraintSetId;

			private static Delegate cb_getId;

			private static Delegate cb_isEnabled;

			private static Delegate cb_getKeyFrameList;

			private static Delegate cb_getLayoutDuringTransition;

			private static Delegate cb_getOnClickList;

			private static Delegate cb_getPathMotionArc;

			private static Delegate cb_setPathMotionArc_I;

			private static Delegate cb_getStagger;

			private static Delegate cb_setStagger_F;

			private static Delegate cb_getStartConstraintSetId;

			private static Delegate cb_getTouchResponse;

			private static Delegate cb_addOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_;

			private static Delegate cb_debugString_Landroid_content_Context_;

			private static Delegate cb_isTransitionFlag_I;

			private static Delegate cb_setEnable_Z;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual int AutoTransition
			{
				[Register("getAutoTransition", "()I", "GetGetAutoTransitionHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getAutoTransition.()I", this, null);
				}
				[Register("setAutoTransition", "(I)V", "GetSetAutoTransition_IHandler")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setAutoTransition.(I)V", this, ptr);
				}
			}

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

			public unsafe virtual int EndConstraintSetId
			{
				[Register("getEndConstraintSetId", "()I", "GetGetEndConstraintSetIdHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getEndConstraintSetId.()I", this, null);
				}
			}

			public unsafe virtual int Id
			{
				[Register("getId", "()I", "GetGetIdHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
				}
			}

			public unsafe virtual bool IsEnabled
			{
				[Register("isEnabled", "()Z", "GetIsEnabledHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEnabled.()Z", this, null);
				}
			}

			public unsafe virtual IList<KeyFrames> KeyFrameList
			{
				[Register("getKeyFrameList", "()Ljava/util/List;", "GetGetKeyFrameListHandler")]
				get
				{
					return JavaList<KeyFrames>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyFrameList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual int LayoutDuringTransition
			{
				[Register("getLayoutDuringTransition", "()I", "GetGetLayoutDuringTransitionHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getLayoutDuringTransition.()I", this, null);
				}
			}

			public unsafe virtual IList<TransitionOnClick> OnClickList
			{
				[Register("getOnClickList", "()Ljava/util/List;", "GetGetOnClickListHandler")]
				get
				{
					return JavaList<TransitionOnClick>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOnClickList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual int PathMotionArc
			{
				[Register("getPathMotionArc", "()I", "GetGetPathMotionArcHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getPathMotionArc.()I", this, null);
				}
				[Register("setPathMotionArc", "(I)V", "GetSetPathMotionArc_IHandler")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setPathMotionArc.(I)V", this, ptr);
				}
			}

			public unsafe virtual float Stagger
			{
				[Register("getStagger", "()F", "GetGetStaggerHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualSingleMethod("getStagger.()F", this, null);
				}
				[Register("setStagger", "(F)V", "GetSetStagger_FHandler")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setStagger.(F)V", this, ptr);
				}
			}

			public unsafe virtual int StartConstraintSetId
			{
				[Register("getStartConstraintSetId", "()I", "GetGetStartConstraintSetIdHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getStartConstraintSetId.()I", this, null);
				}
			}

			public unsafe virtual Java.Lang.Object TouchResponse
			{
				[Register("getTouchResponse", "()Ljava/lang/Object;", "GetGetTouchResponseHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTouchResponse.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected Transition(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(ILandroidx/constraintlayout/motion/widget/MotionScene;II)V", "")]
			public unsafe Transition(int id, MotionScene motionScene, int constraintSetStartId, int constraintSetEndId)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(id);
					ptr[1] = new JniArgumentValue(motionScene?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(constraintSetStartId);
					ptr[3] = new JniArgumentValue(constraintSetEndId);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(ILandroidx/constraintlayout/motion/widget/MotionScene;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(ILandroidx/constraintlayout/motion/widget/MotionScene;II)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(motionScene);
				}
			}

			private static Delegate GetGetAutoTransitionHandler()
			{
				if ((object)cb_getAutoTransition == null)
				{
					cb_getAutoTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetAutoTransition));
				}
				return cb_getAutoTransition;
			}

			private static int n_GetAutoTransition(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoTransition;
			}

			private static Delegate GetSetAutoTransition_IHandler()
			{
				if ((object)cb_setAutoTransition_I == null)
				{
					cb_setAutoTransition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetAutoTransition_I));
				}
				return cb_setAutoTransition_I;
			}

			private static void n_SetAutoTransition_I(IntPtr jnienv, IntPtr native__this, int type)
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoTransition = type;
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
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
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
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration = duration;
			}

			private static Delegate GetGetEndConstraintSetIdHandler()
			{
				if ((object)cb_getEndConstraintSetId == null)
				{
					cb_getEndConstraintSetId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetEndConstraintSetId));
				}
				return cb_getEndConstraintSetId;
			}

			private static int n_GetEndConstraintSetId(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndConstraintSetId;
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
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
			}

			private static Delegate GetIsEnabledHandler()
			{
				if ((object)cb_isEnabled == null)
				{
					cb_isEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsEnabled));
				}
				return cb_isEnabled;
			}

			private static bool n_IsEnabled(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEnabled;
			}

			private static Delegate GetGetKeyFrameListHandler()
			{
				if ((object)cb_getKeyFrameList == null)
				{
					cb_getKeyFrameList = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetKeyFrameList));
				}
				return cb_getKeyFrameList;
			}

			private static IntPtr n_GetKeyFrameList(IntPtr jnienv, IntPtr native__this)
			{
				return JavaList<KeyFrames>.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).KeyFrameList);
			}

			private static Delegate GetGetLayoutDuringTransitionHandler()
			{
				if ((object)cb_getLayoutDuringTransition == null)
				{
					cb_getLayoutDuringTransition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLayoutDuringTransition));
				}
				return cb_getLayoutDuringTransition;
			}

			private static int n_GetLayoutDuringTransition(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutDuringTransition;
			}

			private static Delegate GetGetOnClickListHandler()
			{
				if ((object)cb_getOnClickList == null)
				{
					cb_getOnClickList = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOnClickList));
				}
				return cb_getOnClickList;
			}

			private static IntPtr n_GetOnClickList(IntPtr jnienv, IntPtr native__this)
			{
				return JavaList<TransitionOnClick>.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnClickList);
			}

			private static Delegate GetGetPathMotionArcHandler()
			{
				if ((object)cb_getPathMotionArc == null)
				{
					cb_getPathMotionArc = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPathMotionArc));
				}
				return cb_getPathMotionArc;
			}

			private static int n_GetPathMotionArc(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PathMotionArc;
			}

			private static Delegate GetSetPathMotionArc_IHandler()
			{
				if ((object)cb_setPathMotionArc_I == null)
				{
					cb_setPathMotionArc_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetPathMotionArc_I));
				}
				return cb_setPathMotionArc_I;
			}

			private static void n_SetPathMotionArc_I(IntPtr jnienv, IntPtr native__this, int arcMode)
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PathMotionArc = arcMode;
			}

			private static Delegate GetGetStaggerHandler()
			{
				if ((object)cb_getStagger == null)
				{
					cb_getStagger = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetStagger));
				}
				return cb_getStagger;
			}

			private static float n_GetStagger(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Stagger;
			}

			private static Delegate GetSetStagger_FHandler()
			{
				if ((object)cb_setStagger_F == null)
				{
					cb_setStagger_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetStagger_F));
				}
				return cb_setStagger_F;
			}

			private static void n_SetStagger_F(IntPtr jnienv, IntPtr native__this, float stagger)
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Stagger = stagger;
			}

			private static Delegate GetGetStartConstraintSetIdHandler()
			{
				if ((object)cb_getStartConstraintSetId == null)
				{
					cb_getStartConstraintSetId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetStartConstraintSetId));
				}
				return cb_getStartConstraintSetId;
			}

			private static int n_GetStartConstraintSetId(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartConstraintSetId;
			}

			private static Delegate GetGetTouchResponseHandler()
			{
				if ((object)cb_getTouchResponse == null)
				{
					cb_getTouchResponse = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTouchResponse));
				}
				return cb_getTouchResponse;
			}

			private static IntPtr n_GetTouchResponse(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TouchResponse);
			}

			private static Delegate GetAddOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_Handler()
			{
				if ((object)cb_addOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_ == null)
				{
					cb_addOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_AddOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_));
				}
				return cb_addOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_;
			}

			private static void n_AddOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_parser)
			{
				Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
				XmlReader parser = XmlPullParserReader.FromJniHandle(native_parser, JniHandleOwnership.DoNotTransfer);
				transition.AddOnClick(context, parser);
			}

			[Register("addOnClick", "(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", "GetAddOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_Handler")]
			public unsafe virtual void AddOnClick(Context context, XmlReader parser)
			{
				IntPtr intPtr = XmlReaderPullParser.ToLocalJniHandle(parser);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("addOnClick.(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(context);
					GC.KeepAlive(parser);
				}
			}

			private static Delegate GetDebugString_Landroid_content_Context_Handler()
			{
				if ((object)cb_debugString_Landroid_content_Context_ == null)
				{
					cb_debugString_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DebugString_Landroid_content_Context_));
				}
				return cb_debugString_Landroid_content_Context_;
			}

			private static IntPtr n_DebugString_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
			{
				Transition transition = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(transition.DebugString(context));
			}

			[Register("debugString", "(Landroid/content/Context;)Ljava/lang/String;", "GetDebugString_Landroid_content_Context_Handler")]
			public unsafe virtual string DebugString(Context context)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("debugString.(Landroid/content/Context;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(context);
				}
			}

			private static Delegate GetIsTransitionFlag_IHandler()
			{
				if ((object)cb_isTransitionFlag_I == null)
				{
					cb_isTransitionFlag_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_IsTransitionFlag_I));
				}
				return cb_isTransitionFlag_I;
			}

			private static bool n_IsTransitionFlag_I(IntPtr jnienv, IntPtr native__this, int flag)
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTransitionFlag(flag);
			}

			[Register("isTransitionFlag", "(I)Z", "GetIsTransitionFlag_IHandler")]
			public unsafe virtual bool IsTransitionFlag(int flag)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(flag);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTransitionFlag.(I)Z", this, ptr);
			}

			private static Delegate GetSetEnable_ZHandler()
			{
				if ((object)cb_setEnable_Z == null)
				{
					cb_setEnable_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetEnable_Z));
				}
				return cb_setEnable_Z;
			}

			private static void n_SetEnable_Z(IntPtr jnienv, IntPtr native__this, bool enable)
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEnable(enable);
			}

			[Register("setEnable", "(Z)V", "GetSetEnable_ZHandler")]
			public unsafe virtual void SetEnable(bool enable)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(enable);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEnable.(Z)V", this, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionScene", typeof(MotionScene));

		private static Delegate cb_getDefinedTransitions;

		private static Delegate cb_getDuration;

		private static Delegate cb_setDuration_I;

		private static Delegate cb_getInterpolator;

		private static Delegate cb_getStaggered;

		private static Delegate cb_addOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_I;

		private static Delegate cb_addTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;

		private static Delegate cb_bestTransitionFor_IFFLandroid_view_MotionEvent_;

		private static Delegate cb_disableAutoTransition_Z;

		private static Delegate cb_gatPathMotionArc;

		private static Delegate cb_getConstraintSet_Landroid_content_Context_Ljava_lang_String_;

		private static Delegate cb_getConstraintSetIds;

		private static Delegate cb_getKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_;

		private static Delegate cb_getPathPercent_Landroid_view_View_I;

		private static Delegate cb_getTransitionById_I;

		private static Delegate cb_getTransitionsWithState_I;

		private static Delegate cb_lookUpConstraintId_Ljava_lang_String_;

		private static Delegate cb_lookUpConstraintName_I;

		private static Delegate cb_onLayout_ZIIII;

		private static Delegate cb_removeTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;

		private static Delegate cb_setConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_;

		private static Delegate cb_setKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_;

		private static Delegate cb_setRtl_Z;

		private static Delegate cb_setTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;

		private static Delegate cb_validateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<Transition> DefinedTransitions
		{
			[Register("getDefinedTransitions", "()Ljava/util/ArrayList;", "GetGetDefinedTransitionsHandler")]
			get
			{
				return JavaList<Transition>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefinedTransitions.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

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

		public unsafe virtual IInterpolator Interpolator
		{
			[Register("getInterpolator", "()Landroid/view/animation/Interpolator;", "GetGetInterpolatorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IInterpolator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInterpolator.()Landroid/view/animation/Interpolator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual float Staggered
		{
			[Register("getStaggered", "()F", "GetGetStaggeredHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getStaggered.()F", this, null);
			}
		}

		protected MotionScene(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", "")]
		public unsafe MotionScene(MotionLayout layout)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(layout);
			}
		}

		private static Delegate GetGetDefinedTransitionsHandler()
		{
			if ((object)cb_getDefinedTransitions == null)
			{
				cb_getDefinedTransitions = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefinedTransitions));
			}
			return cb_getDefinedTransitions;
		}

		private static IntPtr n_GetDefinedTransitions(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<Transition>.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefinedTransitions);
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
			return Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
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
			Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration = duration;
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolator);
		}

		private static Delegate GetGetStaggeredHandler()
		{
			if ((object)cb_getStaggered == null)
			{
				cb_getStaggered = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetStaggered));
			}
			return cb_getStaggered;
		}

		private static float n_GetStaggered(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Staggered;
		}

		private static Delegate GetAddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_IHandler()
		{
			if ((object)cb_addOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_I == null)
			{
				cb_addOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_AddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_I));
			}
			return cb_addOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_I;
		}

		private static void n_AddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_I(IntPtr jnienv, IntPtr native__this, IntPtr native_motionLayout, int currentState)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
			motionScene.AddOnClickListeners(motionLayout, currentState);
		}

		[Register("addOnClickListeners", "(Landroidx/constraintlayout/motion/widget/MotionLayout;I)V", "GetAddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_IHandler")]
		public unsafe virtual void AddOnClickListeners(MotionLayout motionLayout, int currentState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(currentState);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addOnClickListeners.(Landroidx/constraintlayout/motion/widget/MotionLayout;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(motionLayout);
			}
		}

		private static Delegate GetAddTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler()
		{
			if ((object)cb_addTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_ == null)
			{
				cb_addTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_));
			}
			return cb_addTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;
		}

		private static void n_AddTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			motionScene.AddTransition(transition);
		}

		[Register("addTransition", "(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", "GetAddTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler")]
		public unsafe virtual void AddTransition(Transition transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addTransition.(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transition);
			}
		}

		private static Delegate GetBestTransitionFor_IFFLandroid_view_MotionEvent_Handler()
		{
			if ((object)cb_bestTransitionFor_IFFLandroid_view_MotionEvent_ == null)
			{
				cb_bestTransitionFor_IFFLandroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIFFL_L(n_BestTransitionFor_IFFLandroid_view_MotionEvent_));
			}
			return cb_bestTransitionFor_IFFLandroid_view_MotionEvent_;
		}

		private static IntPtr n_BestTransitionFor_IFFLandroid_view_MotionEvent_(IntPtr jnienv, IntPtr native__this, int currentState, float dx, float dy, IntPtr native_mLastTouchDown)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent mLastTouchDown = Java.Lang.Object.GetObject<MotionEvent>(native_mLastTouchDown, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(motionScene.BestTransitionFor(currentState, dx, dy, mLastTouchDown));
		}

		[Register("bestTransitionFor", "(IFFLandroid/view/MotionEvent;)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", "GetBestTransitionFor_IFFLandroid_view_MotionEvent_Handler")]
		public unsafe virtual Transition BestTransitionFor(int currentState, float dx, float dy, MotionEvent mLastTouchDown)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(currentState);
				ptr[1] = new JniArgumentValue(dx);
				ptr[2] = new JniArgumentValue(dy);
				ptr[3] = new JniArgumentValue(mLastTouchDown?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("bestTransitionFor.(IFFLandroid/view/MotionEvent;)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(mLastTouchDown);
			}
		}

		private static Delegate GetDisableAutoTransition_ZHandler()
		{
			if ((object)cb_disableAutoTransition_Z == null)
			{
				cb_disableAutoTransition_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_DisableAutoTransition_Z));
			}
			return cb_disableAutoTransition_Z;
		}

		private static void n_DisableAutoTransition_Z(IntPtr jnienv, IntPtr native__this, bool disable)
		{
			Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisableAutoTransition(disable);
		}

		[Register("disableAutoTransition", "(Z)V", "GetDisableAutoTransition_ZHandler")]
		public unsafe virtual void DisableAutoTransition(bool disable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(disable);
			_members.InstanceMethods.InvokeVirtualVoidMethod("disableAutoTransition.(Z)V", this, ptr);
		}

		private static Delegate GetGatPathMotionArcHandler()
		{
			if ((object)cb_gatPathMotionArc == null)
			{
				cb_gatPathMotionArc = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GatPathMotionArc));
			}
			return cb_gatPathMotionArc;
		}

		private static int n_GatPathMotionArc(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GatPathMotionArc();
		}

		[Register("gatPathMotionArc", "()I", "GetGatPathMotionArcHandler")]
		public unsafe virtual int GatPathMotionArc()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("gatPathMotionArc.()I", this, null);
		}

		private static Delegate GetGetConstraintSet_Landroid_content_Context_Ljava_lang_String_Handler()
		{
			if ((object)cb_getConstraintSet_Landroid_content_Context_Ljava_lang_String_ == null)
			{
				cb_getConstraintSet_Landroid_content_Context_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_GetConstraintSet_Landroid_content_Context_Ljava_lang_String_));
			}
			return cb_getConstraintSet_Landroid_content_Context_Ljava_lang_String_;
		}

		private static IntPtr n_GetConstraintSet_Landroid_content_Context_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_id)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(motionScene.GetConstraintSet(context, id));
		}

		[Register("getConstraintSet", "(Landroid/content/Context;Ljava/lang/String;)Landroidx/constraintlayout/widget/ConstraintSet;", "GetGetConstraintSet_Landroid_content_Context_Ljava_lang_String_Handler")]
		public unsafe virtual ConstraintSet GetConstraintSet(Context context, string id)
		{
			IntPtr intPtr = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ConstraintSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintSet.(Landroid/content/Context;Ljava/lang/String;)Landroidx/constraintlayout/widget/ConstraintSet;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetGetConstraintSetIdsHandler()
		{
			if ((object)cb_getConstraintSetIds == null)
			{
				cb_getConstraintSetIds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConstraintSetIds));
			}
			return cb_getConstraintSetIds;
		}

		private static IntPtr n_GetConstraintSetIds(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetConstraintSetIds());
		}

		[Register("getConstraintSetIds", "()[I", "GetGetConstraintSetIdsHandler")]
		public unsafe virtual int[] GetConstraintSetIds()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintSetIds.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		private static Delegate GetGetKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_Handler()
		{
			if ((object)cb_getKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_ == null)
			{
				cb_getKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_GetKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_));
			}
			return cb_getKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_;
		}

		private static void n_GetKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_(IntPtr jnienv, IntPtr native__this, IntPtr native_motionController)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionController motionController = Java.Lang.Object.GetObject<MotionController>(native_motionController, JniHandleOwnership.DoNotTransfer);
			motionScene.GetKeyFrames(motionController);
		}

		[Register("getKeyFrames", "(Landroidx/constraintlayout/motion/widget/MotionController;)V", "GetGetKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_Handler")]
		public unsafe virtual void GetKeyFrames(MotionController motionController)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(motionController?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getKeyFrames.(Landroidx/constraintlayout/motion/widget/MotionController;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(motionController);
			}
		}

		private static Delegate GetGetPathPercent_Landroid_view_View_IHandler()
		{
			if ((object)cb_getPathPercent_Landroid_view_View_I == null)
			{
				cb_getPathPercent_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLI_F(n_GetPathPercent_Landroid_view_View_I));
			}
			return cb_getPathPercent_Landroid_view_View_I;
		}

		private static float n_GetPathPercent_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int position)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return motionScene.GetPathPercent(view, position);
		}

		[Register("getPathPercent", "(Landroid/view/View;I)F", "GetGetPathPercent_Landroid_view_View_IHandler")]
		public unsafe virtual float GetPathPercent(View view, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getPathPercent.(Landroid/view/View;I)F", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetGetTransitionById_IHandler()
		{
			if ((object)cb_getTransitionById_I == null)
			{
				cb_getTransitionById_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetTransitionById_I));
			}
			return cb_getTransitionById_I;
		}

		private static IntPtr n_GetTransitionById_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTransitionById(id));
		}

		[Register("getTransitionById", "(I)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", "GetGetTransitionById_IHandler")]
		public unsafe virtual Transition GetTransitionById(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransitionById.(I)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetTransitionsWithState_IHandler()
		{
			if ((object)cb_getTransitionsWithState_I == null)
			{
				cb_getTransitionsWithState_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetTransitionsWithState_I));
			}
			return cb_getTransitionsWithState_I;
		}

		private static IntPtr n_GetTransitionsWithState_I(IntPtr jnienv, IntPtr native__this, int stateid)
		{
			return JavaList<Transition>.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTransitionsWithState(stateid));
		}

		[Register("getTransitionsWithState", "(I)Ljava/util/List;", "GetGetTransitionsWithState_IHandler")]
		public unsafe virtual IList<Transition> GetTransitionsWithState(int stateid)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(stateid);
			return JavaList<Transition>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransitionsWithState.(I)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetLookUpConstraintId_Ljava_lang_String_Handler()
		{
			if ((object)cb_lookUpConstraintId_Ljava_lang_String_ == null)
			{
				cb_lookUpConstraintId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_LookUpConstraintId_Ljava_lang_String_));
			}
			return cb_lookUpConstraintId_Ljava_lang_String_;
		}

		private static int n_LookUpConstraintId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_id)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			return motionScene.LookUpConstraintId(id);
		}

		[Register("lookUpConstraintId", "(Ljava/lang/String;)I", "GetLookUpConstraintId_Ljava_lang_String_Handler")]
		public unsafe virtual int LookUpConstraintId(string id)
		{
			IntPtr intPtr = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualInt32Method("lookUpConstraintId.(Ljava/lang/String;)I", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetLookUpConstraintName_IHandler()
		{
			if ((object)cb_lookUpConstraintName_I == null)
			{
				cb_lookUpConstraintName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_LookUpConstraintName_I));
			}
			return cb_lookUpConstraintName_I;
		}

		private static IntPtr n_LookUpConstraintName_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LookUpConstraintName(id));
		}

		[Register("lookUpConstraintName", "(I)Ljava/lang/String;", "GetLookUpConstraintName_IHandler")]
		public unsafe virtual string LookUpConstraintName(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("lookUpConstraintName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayout(changed, left, top, right, bottom);
		}

		[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
		protected unsafe virtual void OnLayout(bool changed, int left, int top, int right, int bottom)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(changed);
			ptr[1] = new JniArgumentValue(left);
			ptr[2] = new JniArgumentValue(top);
			ptr[3] = new JniArgumentValue(right);
			ptr[4] = new JniArgumentValue(bottom);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
		}

		private static Delegate GetRemoveTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler()
		{
			if ((object)cb_removeTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_ == null)
			{
				cb_removeTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_));
			}
			return cb_removeTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;
		}

		private static void n_RemoveTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			motionScene.RemoveTransition(transition);
		}

		[Register("removeTransition", "(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", "GetRemoveTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler")]
		public unsafe virtual void RemoveTransition(Transition transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeTransition.(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transition);
			}
		}

		private static Delegate GetSetConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_Handler()
		{
			if ((object)cb_setConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_ == null)
			{
				cb_setConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_SetConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_));
			}
			return cb_setConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_;
		}

		private static void n_SetConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_(IntPtr jnienv, IntPtr native__this, int id, IntPtr native_set)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet set = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			motionScene.SetConstraintSet(id, set);
		}

		[Register("setConstraintSet", "(ILandroidx/constraintlayout/widget/ConstraintSet;)V", "GetSetConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_Handler")]
		public unsafe virtual void SetConstraintSet(int id, ConstraintSet set)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(id);
				ptr[1] = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setConstraintSet.(ILandroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(set);
			}
		}

		private static Delegate GetSetKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_ == null)
			{
				cb_setKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLILL_V(n_SetKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_));
			}
			return cb_setKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_;
		}

		private static void n_SetKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int position, IntPtr native_name, IntPtr native_value)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			motionScene.SetKeyframe(view, position, name, value);
		}

		[Register("setKeyframe", "(Landroid/view/View;ILjava/lang/String;Ljava/lang/Object;)V", "GetSetKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_Handler")]
		public unsafe virtual void SetKeyframe(View view, int position, string name, Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyframe.(Landroid/view/View;ILjava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(view);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetSetRtl_ZHandler()
		{
			if ((object)cb_setRtl_Z == null)
			{
				cb_setRtl_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetRtl_Z));
			}
			return cb_setRtl_Z;
		}

		private static void n_SetRtl_Z(IntPtr jnienv, IntPtr native__this, bool rtl)
		{
			Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRtl(rtl);
		}

		[Register("setRtl", "(Z)V", "GetSetRtl_ZHandler")]
		public unsafe virtual void SetRtl(bool rtl)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rtl);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRtl.(Z)V", this, ptr);
		}

		private static Delegate GetSetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler()
		{
			if ((object)cb_setTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_ == null)
			{
				cb_setTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_));
			}
			return cb_setTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;
		}

		private static void n_SetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_(IntPtr jnienv, IntPtr native__this, IntPtr native_transition)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Transition transition = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			motionScene.SetTransition(transition);
		}

		[Register("setTransition", "(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", "GetSetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler")]
		public unsafe virtual void SetTransition(Transition transition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transition);
			}
		}

		[Register("stripID", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe static string StripID(string id)
		{
			IntPtr intPtr = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("stripID.(Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetValidateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_Handler()
		{
			if ((object)cb_validateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_ == null)
			{
				cb_validateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ValidateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_));
			}
			return cb_validateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_;
		}

		private static bool n_ValidateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_layout)
		{
			MotionScene motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionLayout layout = Java.Lang.Object.GetObject<MotionLayout>(native_layout, JniHandleOwnership.DoNotTransfer);
			return motionScene.ValidateLayout(layout);
		}

		[Register("validateLayout", "(Landroidx/constraintlayout/motion/widget/MotionLayout;)Z", "GetValidateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_Handler")]
		public unsafe virtual bool ValidateLayout(MotionLayout layout)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("validateLayout.(Landroidx/constraintlayout/motion/widget/MotionLayout;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(layout);
			}
		}
	}
	[Register("androidx/constraintlayout/motion/widget/SplineSet", DoNotGenerateAcw = true)]
	public abstract class SplineSet : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/SplineSet", typeof(SplineSet));

		private static Delegate cb_getCurveFit;

		private static Delegate cb_get_F;

		private static Delegate cb_getSlope_F;

		private static Delegate cb_setPoint_IF;

		private static Delegate cb_setProperty_Landroid_view_View_F;

		private static Delegate cb_setType_Ljava_lang_String_;

		private static Delegate cb_setup_I;

		[Register("mCurveFit")]
		protected CurveFit MCurveFit
		{
			get
			{
				return Java.Lang.Object.GetObject<CurveFit>(_members.InstanceFields.GetObjectValue("mCurveFit.Landroidx/constraintlayout/motion/utils/CurveFit;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mCurveFit.Landroidx/constraintlayout/motion/utils/CurveFit;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mTimePoints")]
		protected IList<int> MTimePoints
		{
			get
			{
				return Android.Runtime.JavaArray<int>.FromJniHandle(_members.InstanceFields.GetObjectValue("mTimePoints.[I", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<int>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mTimePoints.[I", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mValues")]
		protected IList<float> MValues
		{
			get
			{
				return Android.Runtime.JavaArray<float>.FromJniHandle(_members.InstanceFields.GetObjectValue("mValues.[F", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<float>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mValues.[F", this, new JniObjectReference(jobject));
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

		public unsafe virtual CurveFit CurveFit
		{
			[Register("getCurveFit", "()Landroidx/constraintlayout/motion/utils/CurveFit;", "GetGetCurveFitHandler")]
			get
			{
				return Java.Lang.Object.GetObject<CurveFit>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCurveFit.()Landroidx/constraintlayout/motion/utils/CurveFit;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected SplineSet(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SplineSet()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetCurveFitHandler()
		{
			if ((object)cb_getCurveFit == null)
			{
				cb_getCurveFit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCurveFit));
			}
			return cb_getCurveFit;
		}

		private static IntPtr n_GetCurveFit(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurveFit);
		}

		private static Delegate GetGet_FHandler()
		{
			if ((object)cb_get_F == null)
			{
				cb_get_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_F(n_Get_F));
			}
			return cb_get_F;
		}

		private static float n_Get_F(IntPtr jnienv, IntPtr native__this, float t)
		{
			return Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get(t);
		}

		[Register("get", "(F)F", "GetGet_FHandler")]
		public unsafe virtual float Get(float t)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(t);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("get.(F)F", this, ptr);
		}

		private static Delegate GetGetSlope_FHandler()
		{
			if ((object)cb_getSlope_F == null)
			{
				cb_getSlope_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_F(n_GetSlope_F));
			}
			return cb_getSlope_F;
		}

		private static float n_GetSlope_F(IntPtr jnienv, IntPtr native__this, float t)
		{
			return Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSlope(t);
		}

		[Register("getSlope", "(F)F", "GetGetSlope_FHandler")]
		public unsafe virtual float GetSlope(float t)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(t);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getSlope.(F)F", this, ptr);
		}

		private static Delegate GetSetPoint_IFHandler()
		{
			if ((object)cb_setPoint_IF == null)
			{
				cb_setPoint_IF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIF_V(n_SetPoint_IF));
			}
			return cb_setPoint_IF;
		}

		private static void n_SetPoint_IF(IntPtr jnienv, IntPtr native__this, int position, float value)
		{
			Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPoint(position, value);
		}

		[Register("setPoint", "(IF)V", "GetSetPoint_IFHandler")]
		public unsafe virtual void SetPoint(int position, float value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPoint.(IF)V", this, ptr);
		}

		private static Delegate GetSetProperty_Landroid_view_View_FHandler()
		{
			if ((object)cb_setProperty_Landroid_view_View_F == null)
			{
				cb_setProperty_Landroid_view_View_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLF_V(n_SetProperty_Landroid_view_View_F));
			}
			return cb_setProperty_Landroid_view_View_F;
		}

		private static void n_SetProperty_Landroid_view_View_F(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, float p1)
		{
			SplineSet splineSet = Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View p2 = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
			splineSet.SetProperty(p2, p1);
		}

		[Register("setProperty", "(Landroid/view/View;F)V", "GetSetProperty_Landroid_view_View_FHandler")]
		public abstract void SetProperty(View p0, float p1);

		private static Delegate GetSetType_Ljava_lang_String_Handler()
		{
			if ((object)cb_setType_Ljava_lang_String_ == null)
			{
				cb_setType_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetType_Ljava_lang_String_));
			}
			return cb_setType_Ljava_lang_String_;
		}

		private static void n_SetType_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_type)
		{
			SplineSet splineSet = Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
			splineSet.SetType(type);
		}

		[Register("setType", "(Ljava/lang/String;)V", "GetSetType_Ljava_lang_String_Handler")]
		public unsafe virtual void SetType(string type)
		{
			IntPtr intPtr = JNIEnv.NewString(type);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setType.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetup_IHandler()
		{
			if ((object)cb_setup_I == null)
			{
				cb_setup_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_Setup_I));
			}
			return cb_setup_I;
		}

		private static void n_Setup_I(IntPtr jnienv, IntPtr native__this, int curveType)
		{
			Java.Lang.Object.GetObject<SplineSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Setup(curveType);
		}

		[Register("setup", "(I)V", "GetSetup_IHandler")]
		public unsafe virtual void Setup(int curveType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(curveType);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setup.(I)V", this, ptr);
		}
	}
	[Register("androidx/constraintlayout/motion/widget/SplineSet", DoNotGenerateAcw = true)]
	internal class SplineSetInvoker : SplineSet
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/SplineSet", typeof(SplineSetInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public SplineSetInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("setProperty", "(Landroid/view/View;F)V", "GetSetProperty_Landroid_view_View_FHandler")]
		public unsafe override void SetProperty(View p0, float p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setProperty.(Landroid/view/View;F)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
}
namespace AndroidX.ConstraintLayout.Motion.Utils
{
	[Register("androidx/constraintlayout/motion/utils/CurveFit", DoNotGenerateAcw = true)]
	public abstract class CurveFit : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/utils/CurveFit", typeof(CurveFit));

		private static Delegate cb_getPos_DarrayD;

		private static Delegate cb_getPos_DarrayF;

		private static Delegate cb_getPos_DI;

		private static Delegate cb_getSlope_DarrayD;

		private static Delegate cb_getSlope_DI;

		private static Delegate cb_getTimePoints;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected CurveFit(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CurveFit()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("get", "(I[D[[D)Landroidx/constraintlayout/motion/utils/CurveFit;", "")]
		public unsafe static CurveFit Get(int type, double[] time, double[][] y)
		{
			IntPtr intPtr = JNIEnv.NewArray(time);
			IntPtr intPtr2 = JNIEnv.NewArray(y);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(type);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<CurveFit>(_members.StaticMethods.InvokeObjectMethod("get.(I[D[[D)Landroidx/constraintlayout/motion/utils/CurveFit;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (time != null)
				{
					JNIEnv.CopyArray(intPtr, time);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (y != null)
				{
					JNIEnv.CopyArray(intPtr2, y);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(time);
				GC.KeepAlive(y);
			}
		}

		[Register("getArc", "([I[D[[D)Landroidx/constraintlayout/motion/utils/CurveFit;", "")]
		public unsafe static CurveFit GetArc(int[] arcModes, double[] time, double[][] y)
		{
			IntPtr intPtr = JNIEnv.NewArray(arcModes);
			IntPtr intPtr2 = JNIEnv.NewArray(time);
			IntPtr intPtr3 = JNIEnv.NewArray(y);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				return Java.Lang.Object.GetObject<CurveFit>(_members.StaticMethods.InvokeObjectMethod("getArc.([I[D[[D)Landroidx/constraintlayout/motion/utils/CurveFit;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (arcModes != null)
				{
					JNIEnv.CopyArray(intPtr, arcModes);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (time != null)
				{
					JNIEnv.CopyArray(intPtr2, time);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				if (y != null)
				{
					JNIEnv.CopyArray(intPtr3, y);
					JNIEnv.DeleteLocalRef(intPtr3);
				}
				GC.KeepAlive(arcModes);
				GC.KeepAlive(time);
				GC.KeepAlive(y);
			}
		}

		private static Delegate GetGetPos_DarrayDHandler()
		{
			if ((object)cb_getPos_DarrayD == null)
			{
				cb_getPos_DarrayD = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPDL_V(n_GetPos_DarrayD));
			}
			return cb_getPos_DarrayD;
		}

		private static void n_GetPos_DarrayD(IntPtr jnienv, IntPtr native__this, double p0, IntPtr native_p1)
		{
			CurveFit curveFit = Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] array = (double[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(double));
			curveFit.GetPos(p0, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
		}

		[Register("getPos", "(D[D)V", "GetGetPos_DarrayDHandler")]
		public abstract void GetPos(double p0, double[] p1);

		private static Delegate GetGetPos_DarrayFHandler()
		{
			if ((object)cb_getPos_DarrayF == null)
			{
				cb_getPos_DarrayF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPDL_V(n_GetPos_DarrayF));
			}
			return cb_getPos_DarrayF;
		}

		private static void n_GetPos_DarrayF(IntPtr jnienv, IntPtr native__this, double p0, IntPtr native_p1)
		{
			CurveFit curveFit = Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(float));
			curveFit.GetPos(p0, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
		}

		[Register("getPos", "(D[F)V", "GetGetPos_DarrayFHandler")]
		public abstract void GetPos(double p0, float[] p1);

		private static Delegate GetGetPos_DIHandler()
		{
			if ((object)cb_getPos_DI == null)
			{
				cb_getPos_DI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPDI_D(n_GetPos_DI));
			}
			return cb_getPos_DI;
		}

		private static double n_GetPos_DI(IntPtr jnienv, IntPtr native__this, double p0, int p1)
		{
			return Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPos(p0, p1);
		}

		[Register("getPos", "(DI)D", "GetGetPos_DIHandler")]
		public abstract double GetPos(double p0, int p1);

		private static Delegate GetGetSlope_DarrayDHandler()
		{
			if ((object)cb_getSlope_DarrayD == null)
			{
				cb_getSlope_DarrayD = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPDL_V(n_GetSlope_DarrayD));
			}
			return cb_getSlope_DarrayD;
		}

		private static void n_GetSlope_DarrayD(IntPtr jnienv, IntPtr native__this, double p0, IntPtr native_p1)
		{
			CurveFit curveFit = Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] array = (double[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(double));
			curveFit.GetSlope(p0, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
		}

		[Register("getSlope", "(D[D)V", "GetGetSlope_DarrayDHandler")]
		public abstract void GetSlope(double p0, double[] p1);

		private static Delegate GetGetSlope_DIHandler()
		{
			if ((object)cb_getSlope_DI == null)
			{
				cb_getSlope_DI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPDI_D(n_GetSlope_DI));
			}
			return cb_getSlope_DI;
		}

		private static double n_GetSlope_DI(IntPtr jnienv, IntPtr native__this, double p0, int p1)
		{
			return Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSlope(p0, p1);
		}

		[Register("getSlope", "(DI)D", "GetGetSlope_DIHandler")]
		public abstract double GetSlope(double p0, int p1);

		private static Delegate GetGetTimePointsHandler()
		{
			if ((object)cb_getTimePoints == null)
			{
				cb_getTimePoints = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTimePoints));
			}
			return cb_getTimePoints;
		}

		private static IntPtr n_GetTimePoints(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<CurveFit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTimePoints());
		}

		[Register("getTimePoints", "()[D", "GetGetTimePointsHandler")]
		public abstract double[] GetTimePoints();
	}
	[Register("androidx/constraintlayout/motion/utils/CurveFit", DoNotGenerateAcw = true)]
	internal class CurveFitInvoker : CurveFit
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/utils/CurveFit", typeof(CurveFitInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public CurveFitInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getPos", "(D[D)V", "GetGetPos_DarrayDHandler")]
		public unsafe override void GetPos(double p0, double[] p1)
		{
			IntPtr intPtr = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("getPos.(D[D)V", this, ptr);
			}
			finally
			{
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr, p1);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(p1);
			}
		}

		[Register("getPos", "(D[F)V", "GetGetPos_DarrayFHandler")]
		public unsafe override void GetPos(double p0, float[] p1)
		{
			IntPtr intPtr = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("getPos.(D[F)V", this, ptr);
			}
			finally
			{
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr, p1);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(p1);
			}
		}

		[Register("getPos", "(DI)D", "GetGetPos_DIHandler")]
		public unsafe override double GetPos(double p0, int p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			return _members.InstanceMethods.InvokeAbstractDoubleMethod("getPos.(DI)D", this, ptr);
		}

		[Register("getSlope", "(D[D)V", "GetGetSlope_DarrayDHandler")]
		public unsafe override void GetSlope(double p0, double[] p1)
		{
			IntPtr intPtr = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("getSlope.(D[D)V", this, ptr);
			}
			finally
			{
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr, p1);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(p1);
			}
		}

		[Register("getSlope", "(DI)D", "GetGetSlope_DIHandler")]
		public unsafe override double GetSlope(double p0, int p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			return _members.InstanceMethods.InvokeAbstractDoubleMethod("getSlope.(DI)D", this, ptr);
		}

		[Register("getTimePoints", "()[D", "GetGetTimePointsHandler")]
		public unsafe override double[] GetTimePoints()
		{
			return (double[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getTimePoints.()[D", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(double));
		}
	}
}
