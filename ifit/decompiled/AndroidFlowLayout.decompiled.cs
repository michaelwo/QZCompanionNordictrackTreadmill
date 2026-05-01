using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("AndroidFlowLayout")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AndroidFlowLayout")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("1.9.1.0")]
[assembly: NamespaceMapping(Java = "org.apmem.tools.layouts", Managed = "Apmem")]
[assembly: TargetFramework("MonoAndroid,Version=v4.0.3", FrameworkDisplayName = "Xamarin.Android v4.0.3 Support")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.9.1.0")]
[module: UnverifiableCode]
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_org_apmem_tools_layouts_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "org/apmem/tools/layouts" }, new Converter<string, Type>[1] { lookup_org_apmem_tools_layouts_package });
		}

		private static Type Lookup(string[] mappings, string javaType)
		{
			string text = TypeManager.LookupTypeMapping(mappings, javaType);
			if (text == null)
			{
				return null;
			}
			return Type.GetType(text);
		}

		private static Type lookup_org_apmem_tools_layouts_package(string klass)
		{
			if (package_org_apmem_tools_layouts_mappings == null)
			{
				package_org_apmem_tools_layouts_mappings = new string[3] { "org/apmem/tools/layouts/BuildConfig:Apmem.BuildConfig", "org/apmem/tools/layouts/FlowLayout:Apmem.FlowLayout", "org/apmem/tools/layouts/FlowLayout$LayoutParams:Apmem.FlowLayout/LayoutParams" };
			}
			return Lookup(package_org_apmem_tools_layouts_mappings, klass);
		}
	}
}
namespace Apmem
{
	[Register("org/apmem/tools/layouts/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("APPLICATION_ID")]
		public const string ApplicationId = "org.apmem.tools.layouts";

		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("FLAVOR")]
		public const string Flavor = "";

		[Register("VERSION_CODE")]
		public const int VersionCode = 4;

		[Register("VERSION_NAME")]
		public const string VersionName = "1.9";

		internal static IntPtr java_class_handle;

		private static IntPtr id_ctor;

		internal static IntPtr class_ref => JNIEnv.FindClass("org/apmem/tools/layouts/BuildConfig", ref java_class_handle);

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => typeof(BuildConfig);

		internal BuildConfig(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public BuildConfig()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				if (GetType() != typeof(BuildConfig))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "()V"), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "()V");
					return;
				}
				if (id_ctor == IntPtr.Zero)
				{
					id_ctor = JNIEnv.GetMethodID(class_ref, "<init>", "()V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor);
			}
			finally
			{
			}
		}
	}
	[Register("org/apmem/tools/layouts/FlowLayout", DoNotGenerateAcw = true)]
	public class FlowLayout : ViewGroup
	{
		[Register("org/apmem/tools/layouts/FlowLayout$LayoutParams", DoNotGenerateAcw = true)]
		public new class LayoutParams : MarginLayoutParams
		{
			private static IntPtr gravity_jfieldId;

			private static IntPtr newLine_jfieldId;

			private static IntPtr weight_jfieldId;

			internal static IntPtr java_class_handle;

			private static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_;

			private static IntPtr id_ctor_II;

			private static IntPtr id_ctor_Landroid_view_ViewGroup_LayoutParams_;

			private static Delegate cb_gravitySpecified;

			private static IntPtr id_gravitySpecified;

			private static Delegate cb_weightSpecified;

			private static IntPtr id_weightSpecified;

			[Register("gravity")]
			public int Gravity
			{
				get
				{
					if (gravity_jfieldId == IntPtr.Zero)
					{
						gravity_jfieldId = JNIEnv.GetFieldID(class_ref, "gravity", "I");
					}
					return JNIEnv.GetIntField(base.Handle, gravity_jfieldId);
				}
				set
				{
					if (gravity_jfieldId == IntPtr.Zero)
					{
						gravity_jfieldId = JNIEnv.GetFieldID(class_ref, "gravity", "I");
					}
					try
					{
						JNIEnv.SetField(base.Handle, gravity_jfieldId, value);
					}
					finally
					{
					}
				}
			}

			[Register("newLine")]
			public bool NewLine
			{
				get
				{
					if (newLine_jfieldId == IntPtr.Zero)
					{
						newLine_jfieldId = JNIEnv.GetFieldID(class_ref, "newLine", "Z");
					}
					return JNIEnv.GetBooleanField(base.Handle, newLine_jfieldId);
				}
				set
				{
					if (newLine_jfieldId == IntPtr.Zero)
					{
						newLine_jfieldId = JNIEnv.GetFieldID(class_ref, "newLine", "Z");
					}
					try
					{
						JNIEnv.SetField(base.Handle, newLine_jfieldId, value);
					}
					finally
					{
					}
				}
			}

			[Register("weight")]
			public float Weight
			{
				get
				{
					if (weight_jfieldId == IntPtr.Zero)
					{
						weight_jfieldId = JNIEnv.GetFieldID(class_ref, "weight", "F");
					}
					return JNIEnv.GetFloatField(base.Handle, weight_jfieldId);
				}
				set
				{
					if (weight_jfieldId == IntPtr.Zero)
					{
						weight_jfieldId = JNIEnv.GetFieldID(class_ref, "weight", "F");
					}
					try
					{
						JNIEnv.SetField(base.Handle, weight_jfieldId, value);
					}
					finally
					{
					}
				}
			}

			internal static IntPtr class_ref => JNIEnv.FindClass("org/apmem/tools/layouts/FlowLayout$LayoutParams", ref java_class_handle);

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => typeof(LayoutParams);

			protected LayoutParams(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
			public unsafe LayoutParams(Context p0, IAttributeSet p1)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JValue* ptr = stackalloc JValue[2];
					*ptr = new JValue(p0);
					ptr[1] = new JValue(p1);
					if (GetType() != typeof(LayoutParams))
					{
						SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;)V", ptr), JniHandleOwnership.TransferLocalRef);
						JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;)V", ptr);
						return;
					}
					if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ == IntPtr.Zero)
					{
						id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;)V");
					}
					SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, ptr);
				}
				finally
				{
				}
			}

			[Register(".ctor", "(II)V", "")]
			public unsafe LayoutParams(int p0, int p1)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JValue* ptr = stackalloc JValue[2];
					*ptr = new JValue(p0);
					ptr[1] = new JValue(p1);
					if (GetType() != typeof(LayoutParams))
					{
						SetHandle(JNIEnv.StartCreateInstance(GetType(), "(II)V", ptr), JniHandleOwnership.TransferLocalRef);
						JNIEnv.FinishCreateInstance(base.Handle, "(II)V", ptr);
						return;
					}
					if (id_ctor_II == IntPtr.Zero)
					{
						id_ctor_II = JNIEnv.GetMethodID(class_ref, "<init>", "(II)V");
					}
					SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_II, ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_II, ptr);
				}
				finally
				{
				}
			}

			[Register(".ctor", "(Landroid/view/ViewGroup$LayoutParams;)V", "")]
			public unsafe LayoutParams(ViewGroup.LayoutParams p0)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(p0);
					if (GetType() != typeof(LayoutParams))
					{
						SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/view/ViewGroup$LayoutParams;)V", ptr), JniHandleOwnership.TransferLocalRef);
						JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/view/ViewGroup$LayoutParams;)V", ptr);
						return;
					}
					if (id_ctor_Landroid_view_ViewGroup_LayoutParams_ == IntPtr.Zero)
					{
						id_ctor_Landroid_view_ViewGroup_LayoutParams_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/view/ViewGroup$LayoutParams;)V");
					}
					SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_view_ViewGroup_LayoutParams_, ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_view_ViewGroup_LayoutParams_, ptr);
				}
				finally
				{
				}
			}

			private static Delegate GetGravitySpecifiedHandler()
			{
				if ((object)cb_gravitySpecified == null)
				{
					cb_gravitySpecified = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_GravitySpecified));
				}
				return cb_gravitySpecified;
			}

			private static bool n_GravitySpecified(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GravitySpecified();
			}

			[Register("gravitySpecified", "()Z", "GetGravitySpecifiedHandler")]
			public virtual bool GravitySpecified()
			{
				if (id_gravitySpecified == IntPtr.Zero)
				{
					id_gravitySpecified = JNIEnv.GetMethodID(class_ref, "gravitySpecified", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_gravitySpecified);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "gravitySpecified", "()Z"));
				}
				finally
				{
				}
			}

			private static Delegate GetWeightSpecifiedHandler()
			{
				if ((object)cb_weightSpecified == null)
				{
					cb_weightSpecified = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_WeightSpecified));
				}
				return cb_weightSpecified;
			}

			private static bool n_WeightSpecified(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WeightSpecified();
			}

			[Register("weightSpecified", "()Z", "GetWeightSpecifiedHandler")]
			public virtual bool WeightSpecified()
			{
				if (id_weightSpecified == IntPtr.Zero)
				{
					id_weightSpecified = JNIEnv.GetMethodID(class_ref, "weightSpecified", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_weightSpecified);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "weightSpecified", "()Z"));
				}
				finally
				{
				}
			}
		}

		[Register("LAYOUT_DIRECTION_LTR")]
		public const int LayoutDirectionLtr = 0;

		[Register("LAYOUT_DIRECTION_RTL")]
		public const int LayoutDirectionRtl = 1;

		internal static IntPtr java_class_handle;

		private static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I;

		private static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_;

		private static IntPtr id_ctor_Landroid_content_Context_;

		private static Delegate cb_isDebugDraw;

		private static Delegate cb_setDebugDraw_Z;

		private static IntPtr id_isDebugDraw;

		private static IntPtr id_setDebugDraw_Z;

		private static Delegate cb_getGravity;

		private static Delegate cb_setGravity_I;

		private static IntPtr id_getGravity;

		private static IntPtr id_setGravity_I;

		private static Delegate cb_getLayoutDirection;

		private static Delegate cb_setLayoutDirection_I;

		private static IntPtr id_getLayoutDirection;

		private static IntPtr id_setLayoutDirection_I;

		private static Delegate cb_getOrientation;

		private static Delegate cb_setOrientation_I;

		private static IntPtr id_getOrientation;

		private static IntPtr id_setOrientation_I;

		private static Delegate cb_getWeightDefault;

		private static Delegate cb_setWeightDefault_F;

		private static IntPtr id_getWeightDefault;

		private static IntPtr id_setWeightDefault_F;

		private static Delegate cb_onLayout_ZIIII;

		private static IntPtr id_onLayout_ZIIII;

		internal static IntPtr class_ref => JNIEnv.FindClass("org/apmem/tools/layouts/FlowLayout", ref java_class_handle);

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => typeof(FlowLayout);

		public unsafe virtual bool DebugDraw
		{
			[Register("isDebugDraw", "()Z", "GetIsDebugDrawHandler")]
			get
			{
				if (id_isDebugDraw == IntPtr.Zero)
				{
					id_isDebugDraw = JNIEnv.GetMethodID(class_ref, "isDebugDraw", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_isDebugDraw);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isDebugDraw", "()Z"));
				}
				finally
				{
				}
			}
			[Register("setDebugDraw", "(Z)V", "GetSetDebugDraw_ZHandler")]
			set
			{
				if (id_setDebugDraw_Z == IntPtr.Zero)
				{
					id_setDebugDraw_Z = JNIEnv.GetMethodID(class_ref, "setDebugDraw", "(Z)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setDebugDraw_Z, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setDebugDraw", "(Z)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual GravityFlags Gravity
		{
			[Register("getGravity", "()I", "GetGetGravityHandler")]
			get
			{
				if (id_getGravity == IntPtr.Zero)
				{
					id_getGravity = JNIEnv.GetMethodID(class_ref, "getGravity", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return (GravityFlags)JNIEnv.CallIntMethod(base.Handle, id_getGravity);
					}
					return (GravityFlags)JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getGravity", "()I"));
				}
				finally
				{
				}
			}
			[Register("setGravity", "(I)V", "GetSetGravity_IHandler")]
			set
			{
				if (id_setGravity_I == IntPtr.Zero)
				{
					id_setGravity_I = JNIEnv.GetMethodID(class_ref, "setGravity", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue((int)value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setGravity_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setGravity", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public new unsafe virtual int LayoutDirection
		{
			[Register("getLayoutDirection", "()I", "GetGetLayoutDirectionHandler")]
			get
			{
				if (id_getLayoutDirection == IntPtr.Zero)
				{
					id_getLayoutDirection = JNIEnv.GetMethodID(class_ref, "getLayoutDirection", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getLayoutDirection);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getLayoutDirection", "()I"));
				}
				finally
				{
				}
			}
			[Register("setLayoutDirection", "(I)V", "GetSetLayoutDirection_IHandler")]
			set
			{
				if (id_setLayoutDirection_I == IntPtr.Zero)
				{
					id_setLayoutDirection_I = JNIEnv.GetMethodID(class_ref, "setLayoutDirection", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setLayoutDirection_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setLayoutDirection", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual Orientation Orientation
		{
			[Register("getOrientation", "()I", "GetGetOrientationHandler")]
			get
			{
				if (id_getOrientation == IntPtr.Zero)
				{
					id_getOrientation = JNIEnv.GetMethodID(class_ref, "getOrientation", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return (Orientation)JNIEnv.CallIntMethod(base.Handle, id_getOrientation);
					}
					return (Orientation)JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getOrientation", "()I"));
				}
				finally
				{
				}
			}
			[Register("setOrientation", "(I)V", "GetSetOrientation_IHandler")]
			set
			{
				if (id_setOrientation_I == IntPtr.Zero)
				{
					id_setOrientation_I = JNIEnv.GetMethodID(class_ref, "setOrientation", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue((int)value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setOrientation_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setOrientation", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual float WeightDefault
		{
			[Register("getWeightDefault", "()F", "GetGetWeightDefaultHandler")]
			get
			{
				if (id_getWeightDefault == IntPtr.Zero)
				{
					id_getWeightDefault = JNIEnv.GetMethodID(class_ref, "getWeightDefault", "()F");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallFloatMethod(base.Handle, id_getWeightDefault);
					}
					return JNIEnv.CallNonvirtualFloatMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getWeightDefault", "()F"));
				}
				finally
				{
				}
			}
			[Register("setWeightDefault", "(F)V", "GetSetWeightDefault_FHandler")]
			set
			{
				if (id_setWeightDefault_F == IntPtr.Zero)
				{
					id_setWeightDefault_F = JNIEnv.GetMethodID(class_ref, "setWeightDefault", "(F)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setWeightDefault_F, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setWeightDefault", "(F)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		protected FlowLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe FlowLayout(Context p0, IAttributeSet p1, int p2)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(p0);
				ptr[1] = new JValue(p1);
				ptr[2] = new JValue(p2);
				if (GetType() != typeof(FlowLayout))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, ptr);
			}
			finally
			{
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe FlowLayout(Context p0, IAttributeSet p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(p0);
				ptr[1] = new JValue(p1);
				if (GetType() != typeof(FlowLayout))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, ptr);
			}
			finally
			{
			}
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe FlowLayout(Context p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				if (GetType() != typeof(FlowLayout))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_ == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_, ptr);
			}
			finally
			{
			}
		}

		private static Delegate GetIsDebugDrawHandler()
		{
			if ((object)cb_isDebugDraw == null)
			{
				cb_isDebugDraw = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsDebugDraw));
			}
			return cb_isDebugDraw;
		}

		private static bool n_IsDebugDraw(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DebugDraw;
		}

		private static Delegate GetSetDebugDraw_ZHandler()
		{
			if ((object)cb_setDebugDraw_Z == null)
			{
				cb_setDebugDraw_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetDebugDraw_Z));
			}
			return cb_setDebugDraw_Z;
		}

		private static void n_SetDebugDraw_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DebugDraw = p0;
		}

		private static Delegate GetGetGravityHandler()
		{
			if ((object)cb_getGravity == null)
			{
				cb_getGravity = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetGravity));
			}
			return cb_getGravity;
		}

		private static int n_GetGravity(IntPtr jnienv, IntPtr native__this)
		{
			return (int)Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Gravity;
		}

		private static Delegate GetSetGravity_IHandler()
		{
			if ((object)cb_setGravity_I == null)
			{
				cb_setGravity_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetGravity_I));
			}
			return cb_setGravity_I;
		}

		private static void n_SetGravity_I(IntPtr jnienv, IntPtr native__this, int native_p0)
		{
			Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Gravity = (GravityFlags)native_p0;
		}

		private static Delegate GetGetLayoutDirectionHandler()
		{
			if ((object)cb_getLayoutDirection == null)
			{
				cb_getLayoutDirection = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetLayoutDirection));
			}
			return cb_getLayoutDirection;
		}

		private static int n_GetLayoutDirection(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutDirection;
		}

		private static Delegate GetSetLayoutDirection_IHandler()
		{
			if ((object)cb_setLayoutDirection_I == null)
			{
				cb_setLayoutDirection_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetLayoutDirection_I));
			}
			return cb_setLayoutDirection_I;
		}

		private static void n_SetLayoutDirection_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutDirection = p0;
		}

		private static Delegate GetGetOrientationHandler()
		{
			if ((object)cb_getOrientation == null)
			{
				cb_getOrientation = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetOrientation));
			}
			return cb_getOrientation;
		}

		private static int n_GetOrientation(IntPtr jnienv, IntPtr native__this)
		{
			return (int)Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation;
		}

		private static Delegate GetSetOrientation_IHandler()
		{
			if ((object)cb_setOrientation_I == null)
			{
				cb_setOrientation_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetOrientation_I));
			}
			return cb_setOrientation_I;
		}

		private static void n_SetOrientation_I(IntPtr jnienv, IntPtr native__this, int native_p0)
		{
			Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation = (Orientation)native_p0;
		}

		private static Delegate GetGetWeightDefaultHandler()
		{
			if ((object)cb_getWeightDefault == null)
			{
				cb_getWeightDefault = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetWeightDefault));
			}
			return cb_getWeightDefault;
		}

		private static float n_GetWeightDefault(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WeightDefault;
		}

		private static Delegate GetSetWeightDefault_FHandler()
		{
			if ((object)cb_setWeightDefault_F == null)
			{
				cb_setWeightDefault_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetWeightDefault_F));
			}
			return cb_setWeightDefault_F;
		}

		private static void n_SetWeightDefault_F(IntPtr jnienv, IntPtr native__this, float p0)
		{
			Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WeightDefault = p0;
		}

		private static Delegate GetOnLayout_ZIIIIHandler()
		{
			if ((object)cb_onLayout_ZIIII == null)
			{
				cb_onLayout_ZIIII = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool, int, int, int, int>(n_OnLayout_ZIIII));
			}
			return cb_onLayout_ZIIII;
		}

		private static void n_OnLayout_ZIIII(IntPtr jnienv, IntPtr native__this, bool p0, int p1, int p2, int p3, int p4)
		{
			Java.Lang.Object.GetObject<FlowLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayout(p0, p1, p2, p3, p4);
		}

		[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
		protected unsafe override void OnLayout(bool p0, int p1, int p2, int p3, int p4)
		{
			if (id_onLayout_ZIIII == IntPtr.Zero)
			{
				id_onLayout_ZIIII = JNIEnv.GetMethodID(class_ref, "onLayout", "(ZIIII)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[5];
				*ptr = new JValue(p0);
				ptr[1] = new JValue(p1);
				ptr[2] = new JValue(p2);
				ptr[3] = new JValue(p3);
				ptr[4] = new JValue(p4);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_onLayout_ZIIII, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "onLayout", "(ZIIII)V"), ptr);
				}
			}
			finally
			{
			}
		}
	}
}
