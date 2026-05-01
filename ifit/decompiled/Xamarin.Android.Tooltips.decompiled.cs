using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Java.Lang;
using Java.Lang.Annotation;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("Xamarin.Android.Tooltips")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("(c) jzeferino jzeferino")]
[assembly: AssemblyTrademark("")]
[assembly: NamespaceMapping(Java = "com.tomergoldst.tooltips", Managed = "Com.Tomergoldst.Tooltips")]
[assembly: TargetFramework("MonoAndroid,Version=v7.1", FrameworkDisplayName = "")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[0], new Converter<string, Type>[0]);
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
	}
}
namespace Com.Tomergoldst.Tooltips
{
	[Register("com/tomergoldst/tooltips/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("APPLICATION_ID")]
		public const string ApplicationId = "com.tomergoldst.tooltips";

		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("FLAVOR")]
		public const string Flavor = "";

		[Register("VERSION_CODE")]
		public const int VersionCode = 8;

		[Register("VERSION_NAME")]
		public const string VersionName = "1.0.7";

		internal static IntPtr java_class_handle;

		private static IntPtr id_ctor;

		internal static IntPtr class_ref => JNIEnv.FindClass("com/tomergoldst/tooltips/BuildConfig", ref java_class_handle);

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
	}
	[Register("com/tomergoldst/tooltips/ToolTip", DoNotGenerateAcw = true)]
	public class ToolTip : Java.Lang.Object
	{
		[Register("com/tomergoldst/tooltips/ToolTip$Align", "", "Com.Tomergoldst.Tooltips.ToolTip/IAlignInvoker")]
		public interface IAlign : IAnnotation, IJavaObject, IDisposable
		{
		}

		[Register("com/tomergoldst/tooltips/ToolTip$Align", DoNotGenerateAcw = true)]
		internal class IAlignInvoker : Java.Lang.Object, IAlign, IAnnotation, IJavaObject, IDisposable
		{
			private static IntPtr java_class_ref = JNIEnv.FindClass("com/tomergoldst/tooltips/ToolTip$Align");

			private IntPtr class_ref;

			private static Delegate cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate cb_toString;

			private IntPtr id_toString;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => typeof(IAlignInvoker);

			public static IAlign GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IAlign>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.tomergoldst.tooltips.ToolTip.Align"));
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

			public IAlignInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetAnnotationTypeHandler()
			{
				if ((object)cb_annotationType == null)
				{
					cb_annotationType = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IAlign>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class AnnotationType()
			{
				if (id_annotationType == IntPtr.Zero)
				{
					id_annotationType = JNIEnv.GetMethodID(class_ref, "annotationType", "()Ljava/lang/Class;");
				}
				return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_annotationType), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetEquals_Ljava_lang_Object_Handler()
			{
				if ((object)cb_equals_Ljava_lang_Object_ == null)
				{
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IAlign align = Java.Lang.Object.GetObject<IAlign>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return align.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IAlign>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
			}

			public new int GetHashCode()
			{
				if (id_hashCode == IntPtr.Zero)
				{
					id_hashCode = JNIEnv.GetMethodID(class_ref, "hashCode", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_hashCode);
			}

			private static Delegate GetToStringHandler()
			{
				if ((object)cb_toString == null)
				{
					cb_toString = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IAlign>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/tomergoldst/tooltips/ToolTip$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			internal static IntPtr java_class_handle;

			private static IntPtr id_ctor_Landroid_content_Context_Landroid_view_View_Landroid_view_ViewGroup_Landroid_text_Spannable_I;

			private static IntPtr id_ctor_Landroid_content_Context_Landroid_view_View_Landroid_view_ViewGroup_Ljava_lang_String_I;

			private static Delegate cb_build;

			private static IntPtr id_build;

			private static Delegate cb_setAlign_I;

			private static IntPtr id_setAlign_I;

			private static Delegate cb_setBackgroundColor_I;

			private static IntPtr id_setBackgroundColor_I;

			private static Delegate cb_setElevation_F;

			private static IntPtr id_setElevation_F;

			private static Delegate cb_setGravity_I;

			private static IntPtr id_setGravity_I;

			private static Delegate cb_setOffsetX_I;

			private static IntPtr id_setOffsetX_I;

			private static Delegate cb_setOffsetY_I;

			private static IntPtr id_setOffsetY_I;

			private static Delegate cb_setPosition_I;

			private static IntPtr id_setPosition_I;

			private static Delegate cb_setTextColor_I;

			private static IntPtr id_setTextColor_I;

			private static Delegate cb_setTextSize_I;

			private static IntPtr id_setTextSize_I;

			private static Delegate cb_withArrow_Z;

			private static IntPtr id_withArrow_Z;

			internal static IntPtr class_ref => JNIEnv.FindClass("com/tomergoldst/tooltips/ToolTip$Builder", ref java_class_handle);

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => typeof(Builder);

			protected Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/content/Context;Landroid/view/View;Landroid/view/ViewGroup;Landroid/text/Spannable;I)V", "")]
			public unsafe Builder(Context context, View anchorView, ViewGroup root, ISpannable message, int position)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				JValue* ptr = stackalloc JValue[5];
				*ptr = new JValue(context);
				ptr[1] = new JValue(anchorView);
				ptr[2] = new JValue(root);
				ptr[3] = new JValue(message);
				ptr[4] = new JValue(position);
				if (GetType() != typeof(Builder))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/view/View;Landroid/view/ViewGroup;Landroid/text/Spannable;I)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/view/View;Landroid/view/ViewGroup;Landroid/text/Spannable;I)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_Landroid_view_View_Landroid_view_ViewGroup_Landroid_text_Spannable_I == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_Landroid_view_View_Landroid_view_ViewGroup_Landroid_text_Spannable_I = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/view/View;Landroid/view/ViewGroup;Landroid/text/Spannable;I)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_view_View_Landroid_view_ViewGroup_Landroid_text_Spannable_I, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_view_View_Landroid_view_ViewGroup_Landroid_text_Spannable_I, ptr);
				GC.KeepAlive(context);
				GC.KeepAlive(anchorView);
				GC.KeepAlive(root);
				GC.KeepAlive(message);
			}

			[Register(".ctor", "(Landroid/content/Context;Landroid/view/View;Landroid/view/ViewGroup;Ljava/lang/String;I)V", "")]
			public unsafe Builder(Context context, View anchorView, ViewGroup root, string message, int position)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.NewString(message);
				try
				{
					JValue* ptr = stackalloc JValue[5];
					*ptr = new JValue(context);
					ptr[1] = new JValue(anchorView);
					ptr[2] = new JValue(root);
					ptr[3] = new JValue(intPtr);
					ptr[4] = new JValue(position);
					if (GetType() != typeof(Builder))
					{
						SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/view/View;Landroid/view/ViewGroup;Ljava/lang/String;I)V", ptr), JniHandleOwnership.TransferLocalRef);
						JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/view/View;Landroid/view/ViewGroup;Ljava/lang/String;I)V", ptr);
						return;
					}
					if (id_ctor_Landroid_content_Context_Landroid_view_View_Landroid_view_ViewGroup_Ljava_lang_String_I == IntPtr.Zero)
					{
						id_ctor_Landroid_content_Context_Landroid_view_View_Landroid_view_ViewGroup_Ljava_lang_String_I = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/view/View;Landroid/view/ViewGroup;Ljava/lang/String;I)V");
					}
					SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_view_View_Landroid_view_ViewGroup_Ljava_lang_String_I, ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_view_View_Landroid_view_ViewGroup_Ljava_lang_String_I, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(context);
					GC.KeepAlive(anchorView);
					GC.KeepAlive(root);
				}
			}

			private static Delegate GetBuildHandler()
			{
				if ((object)cb_build == null)
				{
					cb_build = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_Build));
				}
				return cb_build;
			}

			private static IntPtr n_Build(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
			}

			[Register("build", "()Lcom/tomergoldst/tooltips/ToolTip;", "GetBuildHandler")]
			public virtual ToolTip Build()
			{
				if (id_build == IntPtr.Zero)
				{
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/tomergoldst/tooltips/ToolTip;");
				}
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<ToolTip>(JNIEnv.CallObjectMethod(base.Handle, id_build), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<ToolTip>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "build", "()Lcom/tomergoldst/tooltips/ToolTip;")), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetAlign_IHandler()
			{
				if ((object)cb_setAlign_I == null)
				{
					cb_setAlign_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetAlign_I));
				}
				return cb_setAlign_I;
			}

			private static IntPtr n_SetAlign_I(IntPtr jnienv, IntPtr native__this, int align)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAlign(align));
			}

			[Register("setAlign", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;", "GetSetAlign_IHandler")]
			public unsafe virtual Builder SetAlign(int align)
			{
				if (id_setAlign_I == IntPtr.Zero)
				{
					id_setAlign_I = JNIEnv.GetMethodID(class_ref, "setAlign", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(align);
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_setAlign_I, ptr), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setAlign", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;"), ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetBackgroundColor_IHandler()
			{
				if ((object)cb_setBackgroundColor_I == null)
				{
					cb_setBackgroundColor_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetBackgroundColor_I));
				}
				return cb_setBackgroundColor_I;
			}

			private static IntPtr n_SetBackgroundColor_I(IntPtr jnienv, IntPtr native__this, int color)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBackgroundColor(color));
			}

			[Register("setBackgroundColor", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;", "GetSetBackgroundColor_IHandler")]
			public unsafe virtual Builder SetBackgroundColor(int color)
			{
				if (id_setBackgroundColor_I == IntPtr.Zero)
				{
					id_setBackgroundColor_I = JNIEnv.GetMethodID(class_ref, "setBackgroundColor", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(color);
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_setBackgroundColor_I, ptr), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setBackgroundColor", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;"), ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetElevation_FHandler()
			{
				if ((object)cb_setElevation_F == null)
				{
					cb_setElevation_F = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float, IntPtr>(n_SetElevation_F));
				}
				return cb_setElevation_F;
			}

			private static IntPtr n_SetElevation_F(IntPtr jnienv, IntPtr native__this, float elevation)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetElevation(elevation));
			}

			[Register("setElevation", "(F)Lcom/tomergoldst/tooltips/ToolTip$Builder;", "GetSetElevation_FHandler")]
			public unsafe virtual Builder SetElevation(float elevation)
			{
				if (id_setElevation_F == IntPtr.Zero)
				{
					id_setElevation_F = JNIEnv.GetMethodID(class_ref, "setElevation", "(F)Lcom/tomergoldst/tooltips/ToolTip$Builder;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(elevation);
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_setElevation_F, ptr), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setElevation", "(F)Lcom/tomergoldst/tooltips/ToolTip$Builder;"), ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetGravity_IHandler()
			{
				if ((object)cb_setGravity_I == null)
				{
					cb_setGravity_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetGravity_I));
				}
				return cb_setGravity_I;
			}

			private static IntPtr n_SetGravity_I(IntPtr jnienv, IntPtr native__this, int gravity)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGravity(gravity));
			}

			[Register("setGravity", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;", "GetSetGravity_IHandler")]
			public unsafe virtual Builder SetGravity(int gravity)
			{
				if (id_setGravity_I == IntPtr.Zero)
				{
					id_setGravity_I = JNIEnv.GetMethodID(class_ref, "setGravity", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(gravity);
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_setGravity_I, ptr), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setGravity", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;"), ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetOffsetX_IHandler()
			{
				if ((object)cb_setOffsetX_I == null)
				{
					cb_setOffsetX_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetOffsetX_I));
				}
				return cb_setOffsetX_I;
			}

			private static IntPtr n_SetOffsetX_I(IntPtr jnienv, IntPtr native__this, int offset)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOffsetX(offset));
			}

			[Register("setOffsetX", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;", "GetSetOffsetX_IHandler")]
			public unsafe virtual Builder SetOffsetX(int offset)
			{
				if (id_setOffsetX_I == IntPtr.Zero)
				{
					id_setOffsetX_I = JNIEnv.GetMethodID(class_ref, "setOffsetX", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(offset);
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_setOffsetX_I, ptr), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setOffsetX", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;"), ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetOffsetY_IHandler()
			{
				if ((object)cb_setOffsetY_I == null)
				{
					cb_setOffsetY_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetOffsetY_I));
				}
				return cb_setOffsetY_I;
			}

			private static IntPtr n_SetOffsetY_I(IntPtr jnienv, IntPtr native__this, int offset)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOffsetY(offset));
			}

			[Register("setOffsetY", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;", "GetSetOffsetY_IHandler")]
			public unsafe virtual Builder SetOffsetY(int offset)
			{
				if (id_setOffsetY_I == IntPtr.Zero)
				{
					id_setOffsetY_I = JNIEnv.GetMethodID(class_ref, "setOffsetY", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(offset);
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_setOffsetY_I, ptr), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setOffsetY", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;"), ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetPosition_IHandler()
			{
				if ((object)cb_setPosition_I == null)
				{
					cb_setPosition_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetPosition_I));
				}
				return cb_setPosition_I;
			}

			private static IntPtr n_SetPosition_I(IntPtr jnienv, IntPtr native__this, int position)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPosition(position));
			}

			[Register("setPosition", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;", "GetSetPosition_IHandler")]
			public unsafe virtual Builder SetPosition(int position)
			{
				if (id_setPosition_I == IntPtr.Zero)
				{
					id_setPosition_I = JNIEnv.GetMethodID(class_ref, "setPosition", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(position);
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_setPosition_I, ptr), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setPosition", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;"), ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetTextColor_IHandler()
			{
				if ((object)cb_setTextColor_I == null)
				{
					cb_setTextColor_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetTextColor_I));
				}
				return cb_setTextColor_I;
			}

			private static IntPtr n_SetTextColor_I(IntPtr jnienv, IntPtr native__this, int color)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTextColor(color));
			}

			[Register("setTextColor", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;", "GetSetTextColor_IHandler")]
			public unsafe virtual Builder SetTextColor(int color)
			{
				if (id_setTextColor_I == IntPtr.Zero)
				{
					id_setTextColor_I = JNIEnv.GetMethodID(class_ref, "setTextColor", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(color);
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_setTextColor_I, ptr), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setTextColor", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;"), ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetTextSize_IHandler()
			{
				if ((object)cb_setTextSize_I == null)
				{
					cb_setTextSize_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetTextSize_I));
				}
				return cb_setTextSize_I;
			}

			private static IntPtr n_SetTextSize_I(IntPtr jnienv, IntPtr native__this, int sizeInSp)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTextSize(sizeInSp));
			}

			[Register("setTextSize", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;", "GetSetTextSize_IHandler")]
			public unsafe virtual Builder SetTextSize(int sizeInSp)
			{
				if (id_setTextSize_I == IntPtr.Zero)
				{
					id_setTextSize_I = JNIEnv.GetMethodID(class_ref, "setTextSize", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(sizeInSp);
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_setTextSize_I, ptr), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setTextSize", "(I)Lcom/tomergoldst/tooltips/ToolTip$Builder;"), ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetWithArrow_ZHandler()
			{
				if ((object)cb_withArrow_Z == null)
				{
					cb_withArrow_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, IntPtr>(n_WithArrow_Z));
				}
				return cb_withArrow_Z;
			}

			private static IntPtr n_WithArrow_Z(IntPtr jnienv, IntPtr native__this, bool value)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithArrow(value));
			}

			[Register("withArrow", "(Z)Lcom/tomergoldst/tooltips/ToolTip$Builder;", "GetWithArrow_ZHandler")]
			public unsafe virtual Builder WithArrow(bool value)
			{
				if (id_withArrow_Z == IntPtr.Zero)
				{
					id_withArrow_Z = JNIEnv.GetMethodID(class_ref, "withArrow", "(Z)Lcom/tomergoldst/tooltips/ToolTip$Builder;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(value);
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_withArrow_Z, ptr), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "withArrow", "(Z)Lcom/tomergoldst/tooltips/ToolTip$Builder;"), ptr), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/tomergoldst/tooltips/ToolTip$Gravity", "", "Com.Tomergoldst.Tooltips.ToolTip/IGravityInvoker")]
		public interface IGravity : IAnnotation, IJavaObject, IDisposable
		{
		}

		[Register("com/tomergoldst/tooltips/ToolTip$Gravity", DoNotGenerateAcw = true)]
		internal class IGravityInvoker : Java.Lang.Object, IGravity, IAnnotation, IJavaObject, IDisposable
		{
			private static IntPtr java_class_ref = JNIEnv.FindClass("com/tomergoldst/tooltips/ToolTip$Gravity");

			private IntPtr class_ref;

			private static Delegate cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate cb_toString;

			private IntPtr id_toString;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => typeof(IGravityInvoker);

			public static IGravity GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IGravity>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.tomergoldst.tooltips.ToolTip.Gravity"));
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

			public IGravityInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetAnnotationTypeHandler()
			{
				if ((object)cb_annotationType == null)
				{
					cb_annotationType = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IGravity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class AnnotationType()
			{
				if (id_annotationType == IntPtr.Zero)
				{
					id_annotationType = JNIEnv.GetMethodID(class_ref, "annotationType", "()Ljava/lang/Class;");
				}
				return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_annotationType), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetEquals_Ljava_lang_Object_Handler()
			{
				if ((object)cb_equals_Ljava_lang_Object_ == null)
				{
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IGravity gravity = Java.Lang.Object.GetObject<IGravity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return gravity.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IGravity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
			}

			public new int GetHashCode()
			{
				if (id_hashCode == IntPtr.Zero)
				{
					id_hashCode = JNIEnv.GetMethodID(class_ref, "hashCode", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_hashCode);
			}

			private static Delegate GetToStringHandler()
			{
				if ((object)cb_toString == null)
				{
					cb_toString = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IGravity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/tomergoldst/tooltips/ToolTip$Position", "", "Com.Tomergoldst.Tooltips.ToolTip/IPositionInvoker")]
		public interface IPosition : IAnnotation, IJavaObject, IDisposable
		{
		}

		[Register("com/tomergoldst/tooltips/ToolTip$Position", DoNotGenerateAcw = true)]
		internal class IPositionInvoker : Java.Lang.Object, IPosition, IAnnotation, IJavaObject, IDisposable
		{
			private static IntPtr java_class_ref = JNIEnv.FindClass("com/tomergoldst/tooltips/ToolTip$Position");

			private IntPtr class_ref;

			private static Delegate cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate cb_toString;

			private IntPtr id_toString;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => typeof(IPositionInvoker);

			public static IPosition GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IPosition>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.tomergoldst.tooltips.ToolTip.Position"));
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

			public IPositionInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetAnnotationTypeHandler()
			{
				if ((object)cb_annotationType == null)
				{
					cb_annotationType = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class AnnotationType()
			{
				if (id_annotationType == IntPtr.Zero)
				{
					id_annotationType = JNIEnv.GetMethodID(class_ref, "annotationType", "()Ljava/lang/Class;");
				}
				return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_annotationType), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetEquals_Ljava_lang_Object_Handler()
			{
				if ((object)cb_equals_Ljava_lang_Object_ == null)
				{
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IPosition position = Java.Lang.Object.GetObject<IPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return position.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
			}

			public new int GetHashCode()
			{
				if (id_hashCode == IntPtr.Zero)
				{
					id_hashCode = JNIEnv.GetMethodID(class_ref, "hashCode", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_hashCode);
			}

			private static Delegate GetToStringHandler()
			{
				if ((object)cb_toString == null)
				{
					cb_toString = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("ALIGN_CENTER")]
		public const int AlignCenter = 0;

		[Register("ALIGN_LEFT")]
		public const int AlignLeft = 1;

		[Register("ALIGN_RIGHT")]
		public const int AlignRight = 2;

		[Register("GRAVITY_CENTER")]
		public const int GravityCenter = 0;

		[Register("GRAVITY_LEFT")]
		public const int GravityLeft = 1;

		[Register("GRAVITY_RIGHT")]
		public const int GravityRight = 2;

		[Register("POSITION_ABOVE")]
		public const int PositionAbove = 0;

		[Register("POSITION_BELOW")]
		public const int PositionBelow = 1;

		[Register("POSITION_LEFT_TO")]
		public const int PositionLeftTo = 3;

		[Register("POSITION_RIGHT_TO")]
		public const int PositionRightTo = 4;

		internal static IntPtr java_class_handle;

		private static IntPtr id_ctor_Lcom_tomergoldst_tooltips_ToolTip_Builder_;

		private static Delegate cb_getAlign;

		private static IntPtr id_getAlign;

		private static Delegate cb_getAnchorView;

		private static IntPtr id_getAnchorView;

		private static Delegate cb_getBackgroundColor;

		private static IntPtr id_getBackgroundColor;

		private static Delegate cb_getContext;

		private static IntPtr id_getContext;

		private static Delegate cb_getElevation;

		private static IntPtr id_getElevation;

		private static Delegate cb_getMessage;

		private static IntPtr id_getMessage;

		private static Delegate cb_getOffsetX;

		private static IntPtr id_getOffsetX;

		private static Delegate cb_getOffsetY;

		private static IntPtr id_getOffsetY;

		private static Delegate cb_getPosition;

		private static Delegate cb_setPosition_I;

		private static IntPtr id_getPosition;

		private static IntPtr id_setPosition_I;

		private static Delegate cb_getRootView;

		private static IntPtr id_getRootView;

		private static Delegate cb_getSpannableMessage;

		private static IntPtr id_getSpannableMessage;

		private static Delegate cb_getTextColor;

		private static IntPtr id_getTextColor;

		private static Delegate cb_getTextGravity;

		private static IntPtr id_getTextGravity;

		private static Delegate cb_getTextSize;

		private static IntPtr id_getTextSize;

		private static Delegate cb_alignedCenter;

		private static IntPtr id_alignedCenter;

		private static Delegate cb_alignedLeft;

		private static IntPtr id_alignedLeft;

		private static Delegate cb_alignedRight;

		private static IntPtr id_alignedRight;

		private static Delegate cb_hideArrow;

		private static IntPtr id_hideArrow;

		private static Delegate cb_positionedAbove;

		private static IntPtr id_positionedAbove;

		private static Delegate cb_positionedBelow;

		private static IntPtr id_positionedBelow;

		private static Delegate cb_positionedLeftTo;

		private static IntPtr id_positionedLeftTo;

		private static Delegate cb_positionedRightTo;

		private static IntPtr id_positionedRightTo;

		internal static IntPtr class_ref => JNIEnv.FindClass("com/tomergoldst/tooltips/ToolTip", ref java_class_handle);

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => typeof(ToolTip);

		public virtual int Align
		{
			[Register("getAlign", "()I", "GetGetAlignHandler")]
			get
			{
				if (id_getAlign == IntPtr.Zero)
				{
					id_getAlign = JNIEnv.GetMethodID(class_ref, "getAlign", "()I");
				}
				if (GetType() == ThresholdType)
				{
					return JNIEnv.CallIntMethod(base.Handle, id_getAlign);
				}
				return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getAlign", "()I"));
			}
		}

		public virtual View AnchorView
		{
			[Register("getAnchorView", "()Landroid/view/View;", "GetGetAnchorViewHandler")]
			get
			{
				if (id_getAnchorView == IntPtr.Zero)
				{
					id_getAnchorView = JNIEnv.GetMethodID(class_ref, "getAnchorView", "()Landroid/view/View;");
				}
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<View>(JNIEnv.CallObjectMethod(base.Handle, id_getAnchorView), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<View>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getAnchorView", "()Landroid/view/View;")), JniHandleOwnership.TransferLocalRef);
			}
		}

		public virtual int BackgroundColor
		{
			[Register("getBackgroundColor", "()I", "GetGetBackgroundColorHandler")]
			get
			{
				if (id_getBackgroundColor == IntPtr.Zero)
				{
					id_getBackgroundColor = JNIEnv.GetMethodID(class_ref, "getBackgroundColor", "()I");
				}
				if (GetType() == ThresholdType)
				{
					return JNIEnv.CallIntMethod(base.Handle, id_getBackgroundColor);
				}
				return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getBackgroundColor", "()I"));
			}
		}

		public virtual Context Context
		{
			[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
			get
			{
				if (id_getContext == IntPtr.Zero)
				{
					id_getContext = JNIEnv.GetMethodID(class_ref, "getContext", "()Landroid/content/Context;");
				}
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<Context>(JNIEnv.CallObjectMethod(base.Handle, id_getContext), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<Context>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getContext", "()Landroid/content/Context;")), JniHandleOwnership.TransferLocalRef);
			}
		}

		public virtual float Elevation
		{
			[Register("getElevation", "()F", "GetGetElevationHandler")]
			get
			{
				if (id_getElevation == IntPtr.Zero)
				{
					id_getElevation = JNIEnv.GetMethodID(class_ref, "getElevation", "()F");
				}
				if (GetType() == ThresholdType)
				{
					return JNIEnv.CallFloatMethod(base.Handle, id_getElevation);
				}
				return JNIEnv.CallNonvirtualFloatMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getElevation", "()F"));
			}
		}

		public virtual string Message
		{
			[Register("getMessage", "()Ljava/lang/String;", "GetGetMessageHandler")]
			get
			{
				if (id_getMessage == IntPtr.Zero)
				{
					id_getMessage = JNIEnv.GetMethodID(class_ref, "getMessage", "()Ljava/lang/String;");
				}
				if (GetType() == ThresholdType)
				{
					return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getMessage), JniHandleOwnership.TransferLocalRef);
				}
				return JNIEnv.GetString(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getMessage", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			}
		}

		public virtual int OffsetX
		{
			[Register("getOffsetX", "()I", "GetGetOffsetXHandler")]
			get
			{
				if (id_getOffsetX == IntPtr.Zero)
				{
					id_getOffsetX = JNIEnv.GetMethodID(class_ref, "getOffsetX", "()I");
				}
				if (GetType() == ThresholdType)
				{
					return JNIEnv.CallIntMethod(base.Handle, id_getOffsetX);
				}
				return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getOffsetX", "()I"));
			}
		}

		public virtual int OffsetY
		{
			[Register("getOffsetY", "()I", "GetGetOffsetYHandler")]
			get
			{
				if (id_getOffsetY == IntPtr.Zero)
				{
					id_getOffsetY = JNIEnv.GetMethodID(class_ref, "getOffsetY", "()I");
				}
				if (GetType() == ThresholdType)
				{
					return JNIEnv.CallIntMethod(base.Handle, id_getOffsetY);
				}
				return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getOffsetY", "()I"));
			}
		}

		public unsafe virtual int Position
		{
			[Register("getPosition", "()I", "GetGetPositionHandler")]
			get
			{
				if (id_getPosition == IntPtr.Zero)
				{
					id_getPosition = JNIEnv.GetMethodID(class_ref, "getPosition", "()I");
				}
				if (GetType() == ThresholdType)
				{
					return JNIEnv.CallIntMethod(base.Handle, id_getPosition);
				}
				return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getPosition", "()I"));
			}
			[Register("setPosition", "(I)V", "GetSetPosition_IHandler")]
			set
			{
				if (id_setPosition_I == IntPtr.Zero)
				{
					id_setPosition_I = JNIEnv.GetMethodID(class_ref, "setPosition", "(I)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(value);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setPosition_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setPosition", "(I)V"), ptr);
				}
			}
		}

		public virtual ViewGroup RootView
		{
			[Register("getRootView", "()Landroid/view/ViewGroup;", "GetGetRootViewHandler")]
			get
			{
				if (id_getRootView == IntPtr.Zero)
				{
					id_getRootView = JNIEnv.GetMethodID(class_ref, "getRootView", "()Landroid/view/ViewGroup;");
				}
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<ViewGroup>(JNIEnv.CallObjectMethod(base.Handle, id_getRootView), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<ViewGroup>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getRootView", "()Landroid/view/ViewGroup;")), JniHandleOwnership.TransferLocalRef);
			}
		}

		public virtual ISpannable SpannableMessage
		{
			[Register("getSpannableMessage", "()Landroid/text/Spannable;", "GetGetSpannableMessageHandler")]
			get
			{
				if (id_getSpannableMessage == IntPtr.Zero)
				{
					id_getSpannableMessage = JNIEnv.GetMethodID(class_ref, "getSpannableMessage", "()Landroid/text/Spannable;");
				}
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<ISpannable>(JNIEnv.CallObjectMethod(base.Handle, id_getSpannableMessage), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<ISpannable>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getSpannableMessage", "()Landroid/text/Spannable;")), JniHandleOwnership.TransferLocalRef);
			}
		}

		public virtual int TextColor
		{
			[Register("getTextColor", "()I", "GetGetTextColorHandler")]
			get
			{
				if (id_getTextColor == IntPtr.Zero)
				{
					id_getTextColor = JNIEnv.GetMethodID(class_ref, "getTextColor", "()I");
				}
				if (GetType() == ThresholdType)
				{
					return JNIEnv.CallIntMethod(base.Handle, id_getTextColor);
				}
				return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getTextColor", "()I"));
			}
		}

		public virtual int TextGravity
		{
			[Register("getTextGravity", "()I", "GetGetTextGravityHandler")]
			get
			{
				if (id_getTextGravity == IntPtr.Zero)
				{
					id_getTextGravity = JNIEnv.GetMethodID(class_ref, "getTextGravity", "()I");
				}
				if (GetType() == ThresholdType)
				{
					return JNIEnv.CallIntMethod(base.Handle, id_getTextGravity);
				}
				return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getTextGravity", "()I"));
			}
		}

		public virtual int TextSize
		{
			[Register("getTextSize", "()I", "GetGetTextSizeHandler")]
			get
			{
				if (id_getTextSize == IntPtr.Zero)
				{
					id_getTextSize = JNIEnv.GetMethodID(class_ref, "getTextSize", "()I");
				}
				if (GetType() == ThresholdType)
				{
					return JNIEnv.CallIntMethod(base.Handle, id_getTextSize);
				}
				return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getTextSize", "()I"));
			}
		}

		protected ToolTip(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/tomergoldst/tooltips/ToolTip$Builder;)V", "")]
		public unsafe ToolTip(Builder builder)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(builder);
			if (GetType() != typeof(ToolTip))
			{
				SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Lcom/tomergoldst/tooltips/ToolTip$Builder;)V", ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, "(Lcom/tomergoldst/tooltips/ToolTip$Builder;)V", ptr);
				return;
			}
			if (id_ctor_Lcom_tomergoldst_tooltips_ToolTip_Builder_ == IntPtr.Zero)
			{
				id_ctor_Lcom_tomergoldst_tooltips_ToolTip_Builder_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Lcom/tomergoldst/tooltips/ToolTip$Builder;)V");
			}
			SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Lcom_tomergoldst_tooltips_ToolTip_Builder_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Lcom_tomergoldst_tooltips_ToolTip_Builder_, ptr);
			GC.KeepAlive(builder);
		}

		private static Delegate GetGetAlignHandler()
		{
			if ((object)cb_getAlign == null)
			{
				cb_getAlign = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetAlign));
			}
			return cb_getAlign;
		}

		private static int n_GetAlign(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Align;
		}

		private static Delegate GetGetAnchorViewHandler()
		{
			if ((object)cb_getAnchorView == null)
			{
				cb_getAnchorView = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetAnchorView));
			}
			return cb_getAnchorView;
		}

		private static IntPtr n_GetAnchorView(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnchorView);
		}

		private static Delegate GetGetBackgroundColorHandler()
		{
			if ((object)cb_getBackgroundColor == null)
			{
				cb_getBackgroundColor = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetBackgroundColor));
			}
			return cb_getBackgroundColor;
		}

		private static int n_GetBackgroundColor(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BackgroundColor;
		}

		private static Delegate GetGetContextHandler()
		{
			if ((object)cb_getContext == null)
			{
				cb_getContext = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetContext));
			}
			return cb_getContext;
		}

		private static IntPtr n_GetContext(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
		}

		private static Delegate GetGetElevationHandler()
		{
			if ((object)cb_getElevation == null)
			{
				cb_getElevation = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetElevation));
			}
			return cb_getElevation;
		}

		private static float n_GetElevation(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Elevation;
		}

		private static Delegate GetGetMessageHandler()
		{
			if ((object)cb_getMessage == null)
			{
				cb_getMessage = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetMessage));
			}
			return cb_getMessage;
		}

		private static IntPtr n_GetMessage(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Message);
		}

		private static Delegate GetGetOffsetXHandler()
		{
			if ((object)cb_getOffsetX == null)
			{
				cb_getOffsetX = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetOffsetX));
			}
			return cb_getOffsetX;
		}

		private static int n_GetOffsetX(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffsetX;
		}

		private static Delegate GetGetOffsetYHandler()
		{
			if ((object)cb_getOffsetY == null)
			{
				cb_getOffsetY = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetOffsetY));
			}
			return cb_getOffsetY;
		}

		private static int n_GetOffsetY(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffsetY;
		}

		private static Delegate GetGetPositionHandler()
		{
			if ((object)cb_getPosition == null)
			{
				cb_getPosition = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetPosition));
			}
			return cb_getPosition;
		}

		private static int n_GetPosition(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Position;
		}

		private static Delegate GetSetPosition_IHandler()
		{
			if ((object)cb_setPosition_I == null)
			{
				cb_setPosition_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetPosition_I));
			}
			return cb_setPosition_I;
		}

		private static void n_SetPosition_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Position = position;
		}

		private static Delegate GetGetRootViewHandler()
		{
			if ((object)cb_getRootView == null)
			{
				cb_getRootView = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetRootView));
			}
			return cb_getRootView;
		}

		private static IntPtr n_GetRootView(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RootView);
		}

		private static Delegate GetGetSpannableMessageHandler()
		{
			if ((object)cb_getSpannableMessage == null)
			{
				cb_getSpannableMessage = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetSpannableMessage));
			}
			return cb_getSpannableMessage;
		}

		private static IntPtr n_GetSpannableMessage(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpannableMessage);
		}

		private static Delegate GetGetTextColorHandler()
		{
			if ((object)cb_getTextColor == null)
			{
				cb_getTextColor = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetTextColor));
			}
			return cb_getTextColor;
		}

		private static int n_GetTextColor(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextColor;
		}

		private static Delegate GetGetTextGravityHandler()
		{
			if ((object)cb_getTextGravity == null)
			{
				cb_getTextGravity = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetTextGravity));
			}
			return cb_getTextGravity;
		}

		private static int n_GetTextGravity(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextGravity;
		}

		private static Delegate GetGetTextSizeHandler()
		{
			if ((object)cb_getTextSize == null)
			{
				cb_getTextSize = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetTextSize));
			}
			return cb_getTextSize;
		}

		private static int n_GetTextSize(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextSize;
		}

		private static Delegate GetAlignedCenterHandler()
		{
			if ((object)cb_alignedCenter == null)
			{
				cb_alignedCenter = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_AlignedCenter));
			}
			return cb_alignedCenter;
		}

		private static bool n_AlignedCenter(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlignedCenter();
		}

		[Register("alignedCenter", "()Z", "GetAlignedCenterHandler")]
		public virtual bool AlignedCenter()
		{
			if (id_alignedCenter == IntPtr.Zero)
			{
				id_alignedCenter = JNIEnv.GetMethodID(class_ref, "alignedCenter", "()Z");
			}
			if (GetType() == ThresholdType)
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_alignedCenter);
			}
			return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "alignedCenter", "()Z"));
		}

		private static Delegate GetAlignedLeftHandler()
		{
			if ((object)cb_alignedLeft == null)
			{
				cb_alignedLeft = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_AlignedLeft));
			}
			return cb_alignedLeft;
		}

		private static bool n_AlignedLeft(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlignedLeft();
		}

		[Register("alignedLeft", "()Z", "GetAlignedLeftHandler")]
		public virtual bool AlignedLeft()
		{
			if (id_alignedLeft == IntPtr.Zero)
			{
				id_alignedLeft = JNIEnv.GetMethodID(class_ref, "alignedLeft", "()Z");
			}
			if (GetType() == ThresholdType)
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_alignedLeft);
			}
			return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "alignedLeft", "()Z"));
		}

		private static Delegate GetAlignedRightHandler()
		{
			if ((object)cb_alignedRight == null)
			{
				cb_alignedRight = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_AlignedRight));
			}
			return cb_alignedRight;
		}

		private static bool n_AlignedRight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlignedRight();
		}

		[Register("alignedRight", "()Z", "GetAlignedRightHandler")]
		public virtual bool AlignedRight()
		{
			if (id_alignedRight == IntPtr.Zero)
			{
				id_alignedRight = JNIEnv.GetMethodID(class_ref, "alignedRight", "()Z");
			}
			if (GetType() == ThresholdType)
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_alignedRight);
			}
			return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "alignedRight", "()Z"));
		}

		private static Delegate GetHideArrowHandler()
		{
			if ((object)cb_hideArrow == null)
			{
				cb_hideArrow = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_HideArrow));
			}
			return cb_hideArrow;
		}

		private static bool n_HideArrow(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HideArrow();
		}

		[Register("hideArrow", "()Z", "GetHideArrowHandler")]
		public virtual bool HideArrow()
		{
			if (id_hideArrow == IntPtr.Zero)
			{
				id_hideArrow = JNIEnv.GetMethodID(class_ref, "hideArrow", "()Z");
			}
			if (GetType() == ThresholdType)
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_hideArrow);
			}
			return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "hideArrow", "()Z"));
		}

		private static Delegate GetPositionedAboveHandler()
		{
			if ((object)cb_positionedAbove == null)
			{
				cb_positionedAbove = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_PositionedAbove));
			}
			return cb_positionedAbove;
		}

		private static bool n_PositionedAbove(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PositionedAbove();
		}

		[Register("positionedAbove", "()Z", "GetPositionedAboveHandler")]
		public virtual bool PositionedAbove()
		{
			if (id_positionedAbove == IntPtr.Zero)
			{
				id_positionedAbove = JNIEnv.GetMethodID(class_ref, "positionedAbove", "()Z");
			}
			if (GetType() == ThresholdType)
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_positionedAbove);
			}
			return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "positionedAbove", "()Z"));
		}

		private static Delegate GetPositionedBelowHandler()
		{
			if ((object)cb_positionedBelow == null)
			{
				cb_positionedBelow = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_PositionedBelow));
			}
			return cb_positionedBelow;
		}

		private static bool n_PositionedBelow(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PositionedBelow();
		}

		[Register("positionedBelow", "()Z", "GetPositionedBelowHandler")]
		public virtual bool PositionedBelow()
		{
			if (id_positionedBelow == IntPtr.Zero)
			{
				id_positionedBelow = JNIEnv.GetMethodID(class_ref, "positionedBelow", "()Z");
			}
			if (GetType() == ThresholdType)
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_positionedBelow);
			}
			return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "positionedBelow", "()Z"));
		}

		private static Delegate GetPositionedLeftToHandler()
		{
			if ((object)cb_positionedLeftTo == null)
			{
				cb_positionedLeftTo = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_PositionedLeftTo));
			}
			return cb_positionedLeftTo;
		}

		private static bool n_PositionedLeftTo(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PositionedLeftTo();
		}

		[Register("positionedLeftTo", "()Z", "GetPositionedLeftToHandler")]
		public virtual bool PositionedLeftTo()
		{
			if (id_positionedLeftTo == IntPtr.Zero)
			{
				id_positionedLeftTo = JNIEnv.GetMethodID(class_ref, "positionedLeftTo", "()Z");
			}
			if (GetType() == ThresholdType)
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_positionedLeftTo);
			}
			return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "positionedLeftTo", "()Z"));
		}

		private static Delegate GetPositionedRightToHandler()
		{
			if ((object)cb_positionedRightTo == null)
			{
				cb_positionedRightTo = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_PositionedRightTo));
			}
			return cb_positionedRightTo;
		}

		private static bool n_PositionedRightTo(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ToolTip>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PositionedRightTo();
		}

		[Register("positionedRightTo", "()Z", "GetPositionedRightToHandler")]
		public virtual bool PositionedRightTo()
		{
			if (id_positionedRightTo == IntPtr.Zero)
			{
				id_positionedRightTo = JNIEnv.GetMethodID(class_ref, "positionedRightTo", "()Z");
			}
			if (GetType() == ThresholdType)
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_positionedRightTo);
			}
			return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "positionedRightTo", "()Z"));
		}
	}
	[Register("com/tomergoldst/tooltips/ToolTipsManager", DoNotGenerateAcw = true)]
	public class ToolTipsManager : Java.Lang.Object
	{
		[Register("com/tomergoldst/tooltips/ToolTipsManager$TipListener", "", "Com.Tomergoldst.Tooltips.ToolTipsManager/ITipListenerInvoker")]
		public interface ITipListener : IJavaObject, IDisposable
		{
			[Register("onTipDismissed", "(Landroid/view/View;IZ)V", "GetOnTipDismissed_Landroid_view_View_IZHandler:Com.Tomergoldst.Tooltips.ToolTipsManager/ITipListenerInvoker, Xamarin.Android.Tooltips")]
			void OnTipDismissed(View p0, int p1, bool p2);
		}

		[Register("com/tomergoldst/tooltips/ToolTipsManager$TipListener", DoNotGenerateAcw = true)]
		internal class ITipListenerInvoker : Java.Lang.Object, ITipListener, IJavaObject, IDisposable
		{
			private static IntPtr java_class_ref = JNIEnv.FindClass("com/tomergoldst/tooltips/ToolTipsManager$TipListener");

			private IntPtr class_ref;

			private static Delegate cb_onTipDismissed_Landroid_view_View_IZ;

			private IntPtr id_onTipDismissed_Landroid_view_View_IZ;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => typeof(ITipListenerInvoker);

			public static ITipListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ITipListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.tomergoldst.tooltips.ToolTipsManager.TipListener"));
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

			public ITipListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnTipDismissed_Landroid_view_View_IZHandler()
			{
				if ((object)cb_onTipDismissed_Landroid_view_View_IZ == null)
				{
					cb_onTipDismissed_Landroid_view_View_IZ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, int, bool>(n_OnTipDismissed_Landroid_view_View_IZ));
				}
				return cb_onTipDismissed_Landroid_view_View_IZ;
			}

			private static void n_OnTipDismissed_Landroid_view_View_IZ(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, bool p2)
			{
				ITipListener tipListener = Java.Lang.Object.GetObject<ITipListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View p3 = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
				tipListener.OnTipDismissed(p3, p1, p2);
			}

			public unsafe void OnTipDismissed(View p0, int p1, bool p2)
			{
				if (id_onTipDismissed_Landroid_view_View_IZ == IntPtr.Zero)
				{
					id_onTipDismissed_Landroid_view_View_IZ = JNIEnv.GetMethodID(class_ref, "onTipDismissed", "(Landroid/view/View;IZ)V");
				}
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(p0);
				ptr[1] = new JValue(p1);
				ptr[2] = new JValue(p2);
				JNIEnv.CallVoidMethod(base.Handle, id_onTipDismissed_Landroid_view_View_IZ, ptr);
			}
		}

		public class TipEventArgs : EventArgs
		{
			private View p0;

			private int p1;

			private bool p2;

			public View P0 => p0;

			public int P1 => p1;

			public bool P2 => p2;

			public TipEventArgs(View p0, int p1, bool p2)
			{
				this.p0 = p0;
				this.p1 = p1;
				this.p2 = p2;
			}
		}

		[Register("mono/com/tomergoldst/tooltips/ToolTipsManager_TipListenerImplementor")]
		internal sealed class ITipListenerImplementor : Java.Lang.Object, ITipListener, IJavaObject, IDisposable
		{
			private object sender;

			public EventHandler<TipEventArgs> Handler;

			public ITipListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/tomergoldst/tooltips/ToolTipsManager_TipListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnTipDismissed(View p0, int p1, bool p2)
			{
				Handler?.Invoke(sender, new TipEventArgs(p0, p1, p2));
			}

			internal static bool __IsEmpty(ITipListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		internal static IntPtr java_class_handle;

		private static IntPtr id_ctor;

		private static IntPtr id_ctor_Lcom_tomergoldst_tooltips_ToolTipsManager_TipListener_;

		private static Delegate cb_clear;

		private static IntPtr id_clear;

		private static Delegate cb_dismiss_Landroid_view_View_Z;

		private static IntPtr id_dismiss_Landroid_view_View_Z;

		private static Delegate cb_dismiss_Ljava_lang_Integer_;

		private static IntPtr id_dismiss_Ljava_lang_Integer_;

		private static Delegate cb_find_Ljava_lang_Integer_;

		private static IntPtr id_find_Ljava_lang_Integer_;

		private static Delegate cb_findAndDismiss_Landroid_view_View_;

		private static IntPtr id_findAndDismiss_Landroid_view_View_;

		private static Delegate cb_isVisible_Landroid_view_View_;

		private static IntPtr id_isVisible_Landroid_view_View_;

		private static Delegate cb_setAnimationDuration_I;

		private static IntPtr id_setAnimationDuration_I;

		private static Delegate cb_show_Lcom_tomergoldst_tooltips_ToolTip_;

		private static IntPtr id_show_Lcom_tomergoldst_tooltips_ToolTip_;

		internal static IntPtr class_ref => JNIEnv.FindClass("com/tomergoldst/tooltips/ToolTipsManager", ref java_class_handle);

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => typeof(ToolTipsManager);

		protected ToolTipsManager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public ToolTipsManager()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			if (GetType() != typeof(ToolTipsManager))
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

		[Register(".ctor", "(Lcom/tomergoldst/tooltips/ToolTipsManager$TipListener;)V", "")]
		public unsafe ToolTipsManager(ITipListener listener)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(listener);
			if (GetType() != typeof(ToolTipsManager))
			{
				SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Lcom/tomergoldst/tooltips/ToolTipsManager$TipListener;)V", ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, "(Lcom/tomergoldst/tooltips/ToolTipsManager$TipListener;)V", ptr);
				return;
			}
			if (id_ctor_Lcom_tomergoldst_tooltips_ToolTipsManager_TipListener_ == IntPtr.Zero)
			{
				id_ctor_Lcom_tomergoldst_tooltips_ToolTipsManager_TipListener_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Lcom/tomergoldst/tooltips/ToolTipsManager$TipListener;)V");
			}
			SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Lcom_tomergoldst_tooltips_ToolTipsManager_TipListener_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Lcom_tomergoldst_tooltips_ToolTipsManager_TipListener_, ptr);
			GC.KeepAlive(listener);
		}

		private static Delegate GetClearHandler()
		{
			if ((object)cb_clear == null)
			{
				cb_clear = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Clear));
			}
			return cb_clear;
		}

		private static void n_Clear(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ToolTipsManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
		}

		[Register("clear", "()V", "GetClearHandler")]
		public virtual void Clear()
		{
			if (id_clear == IntPtr.Zero)
			{
				id_clear = JNIEnv.GetMethodID(class_ref, "clear", "()V");
			}
			if (GetType() == ThresholdType)
			{
				JNIEnv.CallVoidMethod(base.Handle, id_clear);
			}
			else
			{
				JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "clear", "()V"));
			}
		}

		private static Delegate GetDismiss_Landroid_view_View_ZHandler()
		{
			if ((object)cb_dismiss_Landroid_view_View_Z == null)
			{
				cb_dismiss_Landroid_view_View_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool, bool>(n_Dismiss_Landroid_view_View_Z));
			}
			return cb_dismiss_Landroid_view_View_Z;
		}

		private static bool n_Dismiss_Landroid_view_View_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_tipView, bool byUser)
		{
			ToolTipsManager toolTipsManager = Java.Lang.Object.GetObject<ToolTipsManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View tipView = Java.Lang.Object.GetObject<View>(native_tipView, JniHandleOwnership.DoNotTransfer);
			return toolTipsManager.Dismiss(tipView, byUser);
		}

		[Register("dismiss", "(Landroid/view/View;Z)Z", "GetDismiss_Landroid_view_View_ZHandler")]
		public unsafe virtual bool Dismiss(View tipView, bool byUser)
		{
			if (id_dismiss_Landroid_view_View_Z == IntPtr.Zero)
			{
				id_dismiss_Landroid_view_View_Z = JNIEnv.GetMethodID(class_ref, "dismiss", "(Landroid/view/View;Z)Z");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(tipView);
			ptr[1] = new JValue(byUser);
			bool result = ((!(GetType() == ThresholdType)) ? JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "dismiss", "(Landroid/view/View;Z)Z"), ptr) : JNIEnv.CallBooleanMethod(base.Handle, id_dismiss_Landroid_view_View_Z, ptr));
			GC.KeepAlive(tipView);
			return result;
		}

		private static Delegate GetDismiss_Ljava_lang_Integer_Handler()
		{
			if ((object)cb_dismiss_Ljava_lang_Integer_ == null)
			{
				cb_dismiss_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_Dismiss_Ljava_lang_Integer_));
			}
			return cb_dismiss_Ljava_lang_Integer_;
		}

		private static bool n_Dismiss_Ljava_lang_Integer_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ToolTipsManager toolTipsManager = Java.Lang.Object.GetObject<ToolTipsManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Integer key = Java.Lang.Object.GetObject<Integer>(native_key, JniHandleOwnership.DoNotTransfer);
			return toolTipsManager.Dismiss(key);
		}

		[Register("dismiss", "(Ljava/lang/Integer;)Z", "GetDismiss_Ljava_lang_Integer_Handler")]
		public unsafe virtual bool Dismiss(Integer key)
		{
			if (id_dismiss_Ljava_lang_Integer_ == IntPtr.Zero)
			{
				id_dismiss_Ljava_lang_Integer_ = JNIEnv.GetMethodID(class_ref, "dismiss", "(Ljava/lang/Integer;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(key);
			bool result = ((!(GetType() == ThresholdType)) ? JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "dismiss", "(Ljava/lang/Integer;)Z"), ptr) : JNIEnv.CallBooleanMethod(base.Handle, id_dismiss_Ljava_lang_Integer_, ptr));
			GC.KeepAlive(key);
			return result;
		}

		private static Delegate GetFind_Ljava_lang_Integer_Handler()
		{
			if ((object)cb_find_Ljava_lang_Integer_ == null)
			{
				cb_find_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_Find_Ljava_lang_Integer_));
			}
			return cb_find_Ljava_lang_Integer_;
		}

		private static IntPtr n_Find_Ljava_lang_Integer_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ToolTipsManager toolTipsManager = Java.Lang.Object.GetObject<ToolTipsManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Integer key = Java.Lang.Object.GetObject<Integer>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(toolTipsManager.Find(key));
		}

		[Register("find", "(Ljava/lang/Integer;)Landroid/view/View;", "GetFind_Ljava_lang_Integer_Handler")]
		public unsafe virtual View Find(Integer key)
		{
			if (id_find_Ljava_lang_Integer_ == IntPtr.Zero)
			{
				id_find_Ljava_lang_Integer_ = JNIEnv.GetMethodID(class_ref, "find", "(Ljava/lang/Integer;)Landroid/view/View;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(key);
			View result = ((!(GetType() == ThresholdType)) ? Java.Lang.Object.GetObject<View>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "find", "(Ljava/lang/Integer;)Landroid/view/View;"), ptr), JniHandleOwnership.TransferLocalRef) : Java.Lang.Object.GetObject<View>(JNIEnv.CallObjectMethod(base.Handle, id_find_Ljava_lang_Integer_, ptr), JniHandleOwnership.TransferLocalRef));
			GC.KeepAlive(key);
			return result;
		}

		private static Delegate GetFindAndDismiss_Landroid_view_View_Handler()
		{
			if ((object)cb_findAndDismiss_Landroid_view_View_ == null)
			{
				cb_findAndDismiss_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_FindAndDismiss_Landroid_view_View_));
			}
			return cb_findAndDismiss_Landroid_view_View_;
		}

		private static bool n_FindAndDismiss_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_anchorView)
		{
			ToolTipsManager toolTipsManager = Java.Lang.Object.GetObject<ToolTipsManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View anchorView = Java.Lang.Object.GetObject<View>(native_anchorView, JniHandleOwnership.DoNotTransfer);
			return toolTipsManager.FindAndDismiss(anchorView);
		}

		[Register("findAndDismiss", "(Landroid/view/View;)Z", "GetFindAndDismiss_Landroid_view_View_Handler")]
		public unsafe virtual bool FindAndDismiss(View anchorView)
		{
			if (id_findAndDismiss_Landroid_view_View_ == IntPtr.Zero)
			{
				id_findAndDismiss_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "findAndDismiss", "(Landroid/view/View;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(anchorView);
			bool result = ((!(GetType() == ThresholdType)) ? JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "findAndDismiss", "(Landroid/view/View;)Z"), ptr) : JNIEnv.CallBooleanMethod(base.Handle, id_findAndDismiss_Landroid_view_View_, ptr));
			GC.KeepAlive(anchorView);
			return result;
		}

		private static Delegate GetIsVisible_Landroid_view_View_Handler()
		{
			if ((object)cb_isVisible_Landroid_view_View_ == null)
			{
				cb_isVisible_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_IsVisible_Landroid_view_View_));
			}
			return cb_isVisible_Landroid_view_View_;
		}

		private static bool n_IsVisible_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_tipView)
		{
			ToolTipsManager toolTipsManager = Java.Lang.Object.GetObject<ToolTipsManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View tipView = Java.Lang.Object.GetObject<View>(native_tipView, JniHandleOwnership.DoNotTransfer);
			return toolTipsManager.IsVisible(tipView);
		}

		[Register("isVisible", "(Landroid/view/View;)Z", "GetIsVisible_Landroid_view_View_Handler")]
		public unsafe virtual bool IsVisible(View tipView)
		{
			if (id_isVisible_Landroid_view_View_ == IntPtr.Zero)
			{
				id_isVisible_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "isVisible", "(Landroid/view/View;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(tipView);
			bool result = ((!(GetType() == ThresholdType)) ? JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isVisible", "(Landroid/view/View;)Z"), ptr) : JNIEnv.CallBooleanMethod(base.Handle, id_isVisible_Landroid_view_View_, ptr));
			GC.KeepAlive(tipView);
			return result;
		}

		private static Delegate GetSetAnimationDuration_IHandler()
		{
			if ((object)cb_setAnimationDuration_I == null)
			{
				cb_setAnimationDuration_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetAnimationDuration_I));
			}
			return cb_setAnimationDuration_I;
		}

		private static void n_SetAnimationDuration_I(IntPtr jnienv, IntPtr native__this, int duration)
		{
			Java.Lang.Object.GetObject<ToolTipsManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAnimationDuration(duration);
		}

		[Register("setAnimationDuration", "(I)V", "GetSetAnimationDuration_IHandler")]
		public unsafe virtual void SetAnimationDuration(int duration)
		{
			if (id_setAnimationDuration_I == IntPtr.Zero)
			{
				id_setAnimationDuration_I = JNIEnv.GetMethodID(class_ref, "setAnimationDuration", "(I)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(duration);
			if (GetType() == ThresholdType)
			{
				JNIEnv.CallVoidMethod(base.Handle, id_setAnimationDuration_I, ptr);
			}
			else
			{
				JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setAnimationDuration", "(I)V"), ptr);
			}
		}

		private static Delegate GetShow_Lcom_tomergoldst_tooltips_ToolTip_Handler()
		{
			if ((object)cb_show_Lcom_tomergoldst_tooltips_ToolTip_ == null)
			{
				cb_show_Lcom_tomergoldst_tooltips_ToolTip_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_Show_Lcom_tomergoldst_tooltips_ToolTip_));
			}
			return cb_show_Lcom_tomergoldst_tooltips_ToolTip_;
		}

		private static IntPtr n_Show_Lcom_tomergoldst_tooltips_ToolTip_(IntPtr jnienv, IntPtr native__this, IntPtr native_toolTip)
		{
			ToolTipsManager toolTipsManager = Java.Lang.Object.GetObject<ToolTipsManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ToolTip toolTip = Java.Lang.Object.GetObject<ToolTip>(native_toolTip, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(toolTipsManager.Show(toolTip));
		}

		[Register("show", "(Lcom/tomergoldst/tooltips/ToolTip;)Landroid/view/View;", "GetShow_Lcom_tomergoldst_tooltips_ToolTip_Handler")]
		public unsafe virtual View Show(ToolTip toolTip)
		{
			if (id_show_Lcom_tomergoldst_tooltips_ToolTip_ == IntPtr.Zero)
			{
				id_show_Lcom_tomergoldst_tooltips_ToolTip_ = JNIEnv.GetMethodID(class_ref, "show", "(Lcom/tomergoldst/tooltips/ToolTip;)Landroid/view/View;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(toolTip);
			View result = ((!(GetType() == ThresholdType)) ? Java.Lang.Object.GetObject<View>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "show", "(Lcom/tomergoldst/tooltips/ToolTip;)Landroid/view/View;"), ptr), JniHandleOwnership.TransferLocalRef) : Java.Lang.Object.GetObject<View>(JNIEnv.CallObjectMethod(base.Handle, id_show_Lcom_tomergoldst_tooltips_ToolTip_, ptr), JniHandleOwnership.TransferLocalRef));
			GC.KeepAlive(toolTip);
			return result;
		}
	}
}
