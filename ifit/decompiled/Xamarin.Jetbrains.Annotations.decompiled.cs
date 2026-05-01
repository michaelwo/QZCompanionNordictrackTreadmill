using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "org.intellij.lang.annotations", Managed = "IntelliJ.Lang.Annotations")]
[assembly: NamespaceMapping(Java = "org.jetbrains.annotations", Managed = "JetBrains.Annotations")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) binding for Kotlin Standard Library")]
[assembly: AssemblyFileVersion("23.0.0")]
[assembly: AssemblyInformationalVersion("23.0.0.5")]
[assembly: AssemblyProduct("Xamarin.Jetbrains.Annotations")]
[assembly: AssemblyTitle("Xamarin.Jetbrains.Annotations")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
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

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
}
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
namespace System.Runtime.Versioning
{
	[Conditional("NEVER")]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event, AllowMultiple = true, Inherited = false)]
	internal sealed class SupportedOSPlatformAttribute : Attribute
	{
		public SupportedOSPlatformAttribute(string platformName)
		{
		}
	}
}
namespace JetBrains.Annotations
{
	[Register("org/jetbrains/annotations/ApiStatus", DoNotGenerateAcw = true)]
	public sealed class ApiStatus : Java.Lang.Object
	{
		[Register("org/jetbrains/annotations/ApiStatus$AvailableSince", "", "JetBrains.Annotations.ApiStatus/IAvailableSinceInvoker")]
		public interface IAvailableSince : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("value", "()Ljava/lang/String;", "GetValueHandler:JetBrains.Annotations.ApiStatus/IAvailableSinceInvoker, Xamarin.Jetbrains.Annotations")]
			string? Value();
		}

		[Register("org/jetbrains/annotations/ApiStatus$AvailableSince", DoNotGenerateAcw = true)]
		internal class IAvailableSinceInvoker : Java.Lang.Object, IAvailableSince, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/ApiStatus$AvailableSince", typeof(IAvailableSinceInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_value;

			private IntPtr id_value;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IAvailableSince? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IAvailableSince>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.ApiStatus.AvailableSince'.");
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

			public IAvailableSinceInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetValueHandler()
			{
				if ((object)cb_value == null)
				{
					cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
				}
				return cb_value;
			}

			private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IAvailableSince>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
			}

			public string? Value()
			{
				if (id_value == IntPtr.Zero)
				{
					id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetAnnotationTypeHandler()
			{
				if ((object)cb_annotationType == null)
				{
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IAvailableSince>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IAvailableSince availableSince = Java.Lang.Object.GetObject<IAvailableSince>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return availableSince.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IAvailableSince>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IAvailableSince>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/jetbrains/annotations/ApiStatus$Experimental", "", "JetBrains.Annotations.ApiStatus/IExperimentalInvoker")]
		public interface IExperimental : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/jetbrains/annotations/ApiStatus$Experimental", DoNotGenerateAcw = true)]
		internal class IExperimentalInvoker : Java.Lang.Object, IExperimental, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/ApiStatus$Experimental", typeof(IExperimentalInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IExperimental? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IExperimental>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.ApiStatus.Experimental'.");
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

			public IExperimentalInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IExperimental>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IExperimental experimental = Java.Lang.Object.GetObject<IExperimental>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return experimental.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IExperimental>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IExperimental>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/jetbrains/annotations/ApiStatus$Internal", "", "JetBrains.Annotations.ApiStatus/IInternalInvoker")]
		public interface IInternal : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/jetbrains/annotations/ApiStatus$Internal", DoNotGenerateAcw = true)]
		internal class IInternalInvoker : Java.Lang.Object, IInternal, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/ApiStatus$Internal", typeof(IInternalInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IInternal? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IInternal>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.ApiStatus.Internal'.");
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

			public IInternalInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IInternal obj = Java.Lang.Object.GetObject<IInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return obj.Equals(obj2);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/jetbrains/annotations/ApiStatus$NonExtendable", "", "JetBrains.Annotations.ApiStatus/INonExtendableInvoker")]
		public interface INonExtendable : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/jetbrains/annotations/ApiStatus$NonExtendable", DoNotGenerateAcw = true)]
		internal class INonExtendableInvoker : Java.Lang.Object, INonExtendable, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/ApiStatus$NonExtendable", typeof(INonExtendableInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static INonExtendable? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<INonExtendable>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.ApiStatus.NonExtendable'.");
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

			public INonExtendableInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<INonExtendable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				INonExtendable nonExtendable = Java.Lang.Object.GetObject<INonExtendable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return nonExtendable.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<INonExtendable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<INonExtendable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/jetbrains/annotations/ApiStatus$OverrideOnly", "", "JetBrains.Annotations.ApiStatus/IOverrideOnlyInvoker")]
		public interface IOverrideOnly : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/jetbrains/annotations/ApiStatus$OverrideOnly", DoNotGenerateAcw = true)]
		internal class IOverrideOnlyInvoker : Java.Lang.Object, IOverrideOnly, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/ApiStatus$OverrideOnly", typeof(IOverrideOnlyInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IOverrideOnly? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOverrideOnly>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.ApiStatus.OverrideOnly'.");
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

			public IOverrideOnlyInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IOverrideOnly>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IOverrideOnly overrideOnly = Java.Lang.Object.GetObject<IOverrideOnly>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return overrideOnly.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IOverrideOnly>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IOverrideOnly>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/jetbrains/annotations/ApiStatus$ScheduledForRemoval", "", "JetBrains.Annotations.ApiStatus/IScheduledForRemovalInvoker")]
		public interface IScheduledForRemoval : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("inVersion", "()Ljava/lang/String;", "GetInVersionHandler:JetBrains.Annotations.ApiStatus/IScheduledForRemovalInvoker, Xamarin.Jetbrains.Annotations")]
			string? InVersion();
		}

		[Register("org/jetbrains/annotations/ApiStatus$ScheduledForRemoval", DoNotGenerateAcw = true)]
		internal class IScheduledForRemovalInvoker : Java.Lang.Object, IScheduledForRemoval, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/ApiStatus$ScheduledForRemoval", typeof(IScheduledForRemovalInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_inVersion;

			private IntPtr id_inVersion;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IScheduledForRemoval? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IScheduledForRemoval>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.ApiStatus.ScheduledForRemoval'.");
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

			public IScheduledForRemovalInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetInVersionHandler()
			{
				if ((object)cb_inVersion == null)
				{
					cb_inVersion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_InVersion));
				}
				return cb_inVersion;
			}

			private static IntPtr n_InVersion(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IScheduledForRemoval>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InVersion());
			}

			public string? InVersion()
			{
				if (id_inVersion == IntPtr.Zero)
				{
					id_inVersion = JNIEnv.GetMethodID(class_ref, "inVersion", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_inVersion), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetAnnotationTypeHandler()
			{
				if ((object)cb_annotationType == null)
				{
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IScheduledForRemoval>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IScheduledForRemoval scheduledForRemoval = Java.Lang.Object.GetObject<IScheduledForRemoval>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return scheduledForRemoval.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IScheduledForRemoval>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IScheduledForRemoval>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/ApiStatus", typeof(ApiStatus));

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

		internal ApiStatus(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("org/jetbrains/annotations/Async", DoNotGenerateAcw = true)]
	public sealed class Async : Java.Lang.Object
	{
		[Register("org/jetbrains/annotations/Async$Execute", "", "JetBrains.Annotations.Async/IExecuteInvoker")]
		public interface IExecute : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/jetbrains/annotations/Async$Execute", DoNotGenerateAcw = true)]
		internal class IExecuteInvoker : Java.Lang.Object, IExecute, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Async$Execute", typeof(IExecuteInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IExecute? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IExecute>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.Async.Execute'.");
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

			public IExecuteInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IExecute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IExecute execute = Java.Lang.Object.GetObject<IExecute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return execute.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IExecute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IExecute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/jetbrains/annotations/Async$Schedule", "", "JetBrains.Annotations.Async/IScheduleInvoker")]
		public interface ISchedule : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/jetbrains/annotations/Async$Schedule", DoNotGenerateAcw = true)]
		internal class IScheduleInvoker : Java.Lang.Object, ISchedule, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Async$Schedule", typeof(IScheduleInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static ISchedule? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ISchedule>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.Async.Schedule'.");
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

			public IScheduleInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISchedule>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				ISchedule schedule = Java.Lang.Object.GetObject<ISchedule>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return schedule.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<ISchedule>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<ISchedule>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Async", typeof(Async));

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

		internal Async(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Annotation("org.jetbrains.annotations.Blocking")]
	public class BlockingAttribute : Attribute
	{
	}
	[Annotation("org.jetbrains.annotations.BlockingExecutor")]
	public class BlockingExecutorAttribute : Attribute
	{
	}
	[Annotation("org.jetbrains.annotations.Contract")]
	public class ContractAttribute : Attribute
	{
		[Register("mutates")]
		public string? Mutates { get; set; }

		[Register("pure")]
		public bool Pure { get; set; }

		[Register("value")]
		public string? Value { get; set; }
	}
	[Register("org/jetbrains/annotations/Debug", DoNotGenerateAcw = true)]
	public sealed class Debug : Java.Lang.Object
	{
		[Register("org/jetbrains/annotations/Debug$Renderer", "", "JetBrains.Annotations.Debug/IRendererInvoker")]
		public interface IRenderer : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("childrenArray", "()Ljava/lang/String;", "GetChildrenArrayHandler:JetBrains.Annotations.Debug/IRendererInvoker, Xamarin.Jetbrains.Annotations")]
			string? ChildrenArray();

			[Register("hasChildren", "()Ljava/lang/String;", "GetHasChildrenHandler:JetBrains.Annotations.Debug/IRendererInvoker, Xamarin.Jetbrains.Annotations")]
			string? HasChildren();

			[Register("text", "()Ljava/lang/String;", "GetTextHandler:JetBrains.Annotations.Debug/IRendererInvoker, Xamarin.Jetbrains.Annotations")]
			string? Text();
		}

		[Register("org/jetbrains/annotations/Debug$Renderer", DoNotGenerateAcw = true)]
		internal class IRendererInvoker : Java.Lang.Object, IRenderer, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Debug$Renderer", typeof(IRendererInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_childrenArray;

			private IntPtr id_childrenArray;

			private static Delegate? cb_hasChildren;

			private IntPtr id_hasChildren;

			private static Delegate? cb_text;

			private IntPtr id_text;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IRenderer? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IRenderer>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.Debug.Renderer'.");
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

			public IRendererInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetChildrenArrayHandler()
			{
				if ((object)cb_childrenArray == null)
				{
					cb_childrenArray = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ChildrenArray));
				}
				return cb_childrenArray;
			}

			private static IntPtr n_ChildrenArray(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IRenderer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChildrenArray());
			}

			public string? ChildrenArray()
			{
				if (id_childrenArray == IntPtr.Zero)
				{
					id_childrenArray = JNIEnv.GetMethodID(class_ref, "childrenArray", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_childrenArray), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetHasChildrenHandler()
			{
				if ((object)cb_hasChildren == null)
				{
					cb_hasChildren = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_HasChildren));
				}
				return cb_hasChildren;
			}

			private static IntPtr n_HasChildren(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IRenderer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasChildren());
			}

			public string? HasChildren()
			{
				if (id_hasChildren == IntPtr.Zero)
				{
					id_hasChildren = JNIEnv.GetMethodID(class_ref, "hasChildren", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_hasChildren), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetTextHandler()
			{
				if ((object)cb_text == null)
				{
					cb_text = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Text));
				}
				return cb_text;
			}

			private static IntPtr n_Text(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IRenderer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Text());
			}

			public string? Text()
			{
				if (id_text == IntPtr.Zero)
				{
					id_text = JNIEnv.GetMethodID(class_ref, "text", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_text), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetAnnotationTypeHandler()
			{
				if ((object)cb_annotationType == null)
				{
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IRenderer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IRenderer renderer = Java.Lang.Object.GetObject<IRenderer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return renderer.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IRenderer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IRenderer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Debug", typeof(Debug));

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

		internal Debug(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("org/jetbrains/annotations/Blocking", "", "JetBrains.Annotations.IBlockingInvoker")]
	public interface IBlocking : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/jetbrains/annotations/Blocking", DoNotGenerateAcw = true)]
	internal class IBlockingInvoker : Java.Lang.Object, IBlocking, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Blocking", typeof(IBlockingInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IBlocking? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBlocking>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.Blocking'.");
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

		public IBlockingInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBlocking>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IBlocking blocking = Java.Lang.Object.GetObject<IBlocking>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return blocking.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBlocking>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBlocking>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/BlockingExecutor", "", "JetBrains.Annotations.IBlockingExecutorInvoker")]
	public interface IBlockingExecutor : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/jetbrains/annotations/BlockingExecutor", DoNotGenerateAcw = true)]
	internal class IBlockingExecutorInvoker : Java.Lang.Object, IBlockingExecutor, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/BlockingExecutor", typeof(IBlockingExecutorInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IBlockingExecutor? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBlockingExecutor>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.BlockingExecutor'.");
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

		public IBlockingExecutorInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBlockingExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IBlockingExecutor blockingExecutor = Java.Lang.Object.GetObject<IBlockingExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return blockingExecutor.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBlockingExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBlockingExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/Contract", "", "JetBrains.Annotations.IContractInvoker")]
	public interface IContract : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("mutates", "()Ljava/lang/String;", "GetMutatesHandler:JetBrains.Annotations.IContractInvoker, Xamarin.Jetbrains.Annotations")]
		string? Mutates();

		[Register("pure", "()Z", "GetPureHandler:JetBrains.Annotations.IContractInvoker, Xamarin.Jetbrains.Annotations")]
		bool Pure();

		[Register("value", "()Ljava/lang/String;", "GetValueHandler:JetBrains.Annotations.IContractInvoker, Xamarin.Jetbrains.Annotations")]
		string? Value();
	}
	[Register("org/jetbrains/annotations/Contract", DoNotGenerateAcw = true)]
	internal class IContractInvoker : Java.Lang.Object, IContract, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Contract", typeof(IContractInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_mutates;

		private IntPtr id_mutates;

		private static Delegate? cb_pure;

		private IntPtr id_pure;

		private static Delegate? cb_value;

		private IntPtr id_value;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IContract? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IContract>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.Contract'.");
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

		public IContractInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetMutatesHandler()
		{
			if ((object)cb_mutates == null)
			{
				cb_mutates = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Mutates));
			}
			return cb_mutates;
		}

		private static IntPtr n_Mutates(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Mutates());
		}

		public string? Mutates()
		{
			if (id_mutates == IntPtr.Zero)
			{
				id_mutates = JNIEnv.GetMethodID(class_ref, "mutates", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_mutates), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPureHandler()
		{
			if ((object)cb_pure == null)
			{
				cb_pure = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_Pure));
			}
			return cb_pure;
		}

		private static bool n_Pure(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Pure();
		}

		public bool Pure()
		{
			if (id_pure == IntPtr.Zero)
			{
				id_pure = JNIEnv.GetMethodID(class_ref, "pure", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_pure);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string? Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IContract contract = Java.Lang.Object.GetObject<IContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return contract.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/MustBeInvokedByOverriders", "", "JetBrains.Annotations.IMustBeInvokedByOverridersInvoker")]
	public interface IMustBeInvokedByOverriders : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/jetbrains/annotations/MustBeInvokedByOverriders", DoNotGenerateAcw = true)]
	internal class IMustBeInvokedByOverridersInvoker : Java.Lang.Object, IMustBeInvokedByOverriders, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/MustBeInvokedByOverriders", typeof(IMustBeInvokedByOverridersInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IMustBeInvokedByOverriders? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMustBeInvokedByOverriders>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.MustBeInvokedByOverriders'.");
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

		public IMustBeInvokedByOverridersInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMustBeInvokedByOverriders>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IMustBeInvokedByOverriders mustBeInvokedByOverriders = Java.Lang.Object.GetObject<IMustBeInvokedByOverriders>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return mustBeInvokedByOverriders.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IMustBeInvokedByOverriders>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IMustBeInvokedByOverriders>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/Nls$Capitalization", DoNotGenerateAcw = true)]
	public sealed class NlsCapitalization : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Nls$Capitalization", typeof(NlsCapitalization));

		[Register("NotSpecified")]
		public static NlsCapitalization? NotSpecified => Java.Lang.Object.GetObject<NlsCapitalization>(_members.StaticFields.GetObjectValue("NotSpecified.Lorg/jetbrains/annotations/Nls$Capitalization;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Sentence")]
		public static NlsCapitalization? Sentence => Java.Lang.Object.GetObject<NlsCapitalization>(_members.StaticFields.GetObjectValue("Sentence.Lorg/jetbrains/annotations/Nls$Capitalization;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Title")]
		public static NlsCapitalization? Title => Java.Lang.Object.GetObject<NlsCapitalization>(_members.StaticFields.GetObjectValue("Title.Lorg/jetbrains/annotations/Nls$Capitalization;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal NlsCapitalization(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lorg/jetbrains/annotations/Nls$Capitalization;", "")]
		public unsafe static NlsCapitalization? ValueOf(string? name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<NlsCapitalization>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lorg/jetbrains/annotations/Nls$Capitalization;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lorg/jetbrains/annotations/Nls$Capitalization;", "")]
		public unsafe static NlsCapitalization[]? Values()
		{
			return (NlsCapitalization[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lorg/jetbrains/annotations/Nls$Capitalization;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(NlsCapitalization));
		}
	}
	[Register("org/jetbrains/annotations/Nls", "", "JetBrains.Annotations.INlsInvoker")]
	public interface INls : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("capitalization", "()Lorg/jetbrains/annotations/Nls$Capitalization;", "GetCapitalizationHandler:JetBrains.Annotations.INlsInvoker, Xamarin.Jetbrains.Annotations")]
		NlsCapitalization? Capitalization();
	}
	[Register("org/jetbrains/annotations/Nls", DoNotGenerateAcw = true)]
	internal class INlsInvoker : Java.Lang.Object, INls, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Nls", typeof(INlsInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_capitalization;

		private IntPtr id_capitalization;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static INls? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<INls>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.Nls'.");
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

		public INlsInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCapitalizationHandler()
		{
			if ((object)cb_capitalization == null)
			{
				cb_capitalization = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Capitalization));
			}
			return cb_capitalization;
		}

		private static IntPtr n_Capitalization(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<INls>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Capitalization());
		}

		public NlsCapitalization? Capitalization()
		{
			if (id_capitalization == IntPtr.Zero)
			{
				id_capitalization = JNIEnv.GetMethodID(class_ref, "capitalization", "()Lorg/jetbrains/annotations/Nls$Capitalization;");
			}
			return Java.Lang.Object.GetObject<NlsCapitalization>(JNIEnv.CallObjectMethod(base.Handle, id_capitalization), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<INls>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			INls nls = Java.Lang.Object.GetObject<INls>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return nls.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<INls>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<INls>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/NonBlocking", "", "JetBrains.Annotations.INonBlockingInvoker")]
	public interface INonBlocking : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/jetbrains/annotations/NonBlocking", DoNotGenerateAcw = true)]
	internal class INonBlockingInvoker : Java.Lang.Object, INonBlocking, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/NonBlocking", typeof(INonBlockingInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static INonBlocking? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<INonBlocking>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.NonBlocking'.");
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

		public INonBlockingInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<INonBlocking>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			INonBlocking nonBlocking = Java.Lang.Object.GetObject<INonBlocking>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return nonBlocking.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<INonBlocking>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<INonBlocking>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/NonBlockingExecutor", "", "JetBrains.Annotations.INonBlockingExecutorInvoker")]
	public interface INonBlockingExecutor : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/jetbrains/annotations/NonBlockingExecutor", DoNotGenerateAcw = true)]
	internal class INonBlockingExecutorInvoker : Java.Lang.Object, INonBlockingExecutor, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/NonBlockingExecutor", typeof(INonBlockingExecutorInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static INonBlockingExecutor? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<INonBlockingExecutor>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.NonBlockingExecutor'.");
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

		public INonBlockingExecutorInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<INonBlockingExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			INonBlockingExecutor nonBlockingExecutor = Java.Lang.Object.GetObject<INonBlockingExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return nonBlockingExecutor.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<INonBlockingExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<INonBlockingExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/NonNls", "", "JetBrains.Annotations.INonNlsInvoker")]
	public interface INonNls : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/jetbrains/annotations/NonNls", DoNotGenerateAcw = true)]
	internal class INonNlsInvoker : Java.Lang.Object, INonNls, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/NonNls", typeof(INonNlsInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static INonNls? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<INonNls>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.NonNls'.");
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

		public INonNlsInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<INonNls>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			INonNls nonNls = Java.Lang.Object.GetObject<INonNls>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return nonNls.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<INonNls>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<INonNls>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/NotNull", "", "JetBrains.Annotations.INotNullInvoker")]
	public interface INotNull : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("exception", "()Ljava/lang/Class;", "GetExceptionHandler:JetBrains.Annotations.INotNullInvoker, Xamarin.Jetbrains.Annotations")]
		Class? Exception();

		[Register("value", "()Ljava/lang/String;", "GetValueHandler:JetBrains.Annotations.INotNullInvoker, Xamarin.Jetbrains.Annotations")]
		string? Value();
	}
	[Register("org/jetbrains/annotations/NotNull", DoNotGenerateAcw = true)]
	internal class INotNullInvoker : Java.Lang.Object, INotNull, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/NotNull", typeof(INotNullInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_exception;

		private IntPtr id_exception;

		private static Delegate? cb_value;

		private IntPtr id_value;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static INotNull? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<INotNull>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.NotNull'.");
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

		public INotNullInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetExceptionHandler()
		{
			if ((object)cb_exception == null)
			{
				cb_exception = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Exception));
			}
			return cb_exception;
		}

		private static IntPtr n_Exception(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<INotNull>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Exception());
		}

		public Class? Exception()
		{
			if (id_exception == IntPtr.Zero)
			{
				id_exception = JNIEnv.GetMethodID(class_ref, "exception", "()Ljava/lang/Class;");
			}
			return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_exception), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<INotNull>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string? Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<INotNull>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			INotNull notNull = Java.Lang.Object.GetObject<INotNull>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return notNull.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<INotNull>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<INotNull>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/Nullable", "", "JetBrains.Annotations.INullableInvoker")]
	public interface INullable : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:JetBrains.Annotations.INullableInvoker, Xamarin.Jetbrains.Annotations")]
		string? Value();
	}
	[Register("org/jetbrains/annotations/Nullable", DoNotGenerateAcw = true)]
	internal class INullableInvoker : Java.Lang.Object, INullable, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Nullable", typeof(INullableInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_value;

		private IntPtr id_value;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static INullable? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<INullable>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.Nullable'.");
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

		public INullableInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<INullable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string? Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<INullable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			INullable nullable = Java.Lang.Object.GetObject<INullable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return nullable.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<INullable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<INullable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/PropertyKey", "", "JetBrains.Annotations.IPropertyKeyInvoker")]
	public interface IPropertyKey : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("resourceBundle", "()Ljava/lang/String;", "GetResourceBundleHandler:JetBrains.Annotations.IPropertyKeyInvoker, Xamarin.Jetbrains.Annotations")]
		string? ResourceBundle();
	}
	[Register("org/jetbrains/annotations/PropertyKey", DoNotGenerateAcw = true)]
	internal class IPropertyKeyInvoker : Java.Lang.Object, IPropertyKey, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/PropertyKey", typeof(IPropertyKeyInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_resourceBundle;

		private IntPtr id_resourceBundle;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IPropertyKey? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPropertyKey>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.PropertyKey'.");
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

		public IPropertyKeyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetResourceBundleHandler()
		{
			if ((object)cb_resourceBundle == null)
			{
				cb_resourceBundle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ResourceBundle));
			}
			return cb_resourceBundle;
		}

		private static IntPtr n_ResourceBundle(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPropertyKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResourceBundle());
		}

		public string? ResourceBundle()
		{
			if (id_resourceBundle == IntPtr.Zero)
			{
				id_resourceBundle = JNIEnv.GetMethodID(class_ref, "resourceBundle", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_resourceBundle), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPropertyKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IPropertyKey propertyKey = Java.Lang.Object.GetObject<IPropertyKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return propertyKey.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IPropertyKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPropertyKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/Range", "", "JetBrains.Annotations.IRangeInvoker")]
	public interface IRange : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("from", "()J", "GetFromHandler:JetBrains.Annotations.IRangeInvoker, Xamarin.Jetbrains.Annotations")]
		long From();

		[Register("to", "()J", "GetToHandler:JetBrains.Annotations.IRangeInvoker, Xamarin.Jetbrains.Annotations")]
		long To();
	}
	[Register("org/jetbrains/annotations/Range", DoNotGenerateAcw = true)]
	internal class IRangeInvoker : Java.Lang.Object, IRange, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Range", typeof(IRangeInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_from;

		private IntPtr id_from;

		private static Delegate? cb_to;

		private IntPtr id_to;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IRange? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IRange>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.Range'.");
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

		public IRangeInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetFromHandler()
		{
			if ((object)cb_from == null)
			{
				cb_from = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_From));
			}
			return cb_from;
		}

		private static long n_From(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IRange>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).From();
		}

		public long From()
		{
			if (id_from == IntPtr.Zero)
			{
				id_from = JNIEnv.GetMethodID(class_ref, "from", "()J");
			}
			return JNIEnv.CallLongMethod(base.Handle, id_from);
		}

		private static Delegate GetToHandler()
		{
			if ((object)cb_to == null)
			{
				cb_to = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_To));
			}
			return cb_to;
		}

		private static long n_To(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IRange>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).To();
		}

		public long To()
		{
			if (id_to == IntPtr.Zero)
			{
				id_to = JNIEnv.GetMethodID(class_ref, "to", "()J");
			}
			return JNIEnv.CallLongMethod(base.Handle, id_to);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IRange>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IRange range = Java.Lang.Object.GetObject<IRange>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return range.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IRange>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IRange>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/TestOnly", "", "JetBrains.Annotations.ITestOnlyInvoker")]
	public interface ITestOnly : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/jetbrains/annotations/TestOnly", DoNotGenerateAcw = true)]
	internal class ITestOnlyInvoker : Java.Lang.Object, ITestOnly, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/TestOnly", typeof(ITestOnlyInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static ITestOnly? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITestOnly>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.TestOnly'.");
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

		public ITestOnlyInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITestOnly>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			ITestOnly testOnly = Java.Lang.Object.GetObject<ITestOnly>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return testOnly.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ITestOnly>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ITestOnly>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/UnknownNullability", "", "JetBrains.Annotations.IUnknownNullabilityInvoker")]
	public interface IUnknownNullability : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:JetBrains.Annotations.IUnknownNullabilityInvoker, Xamarin.Jetbrains.Annotations")]
		string? Value();
	}
	[Register("org/jetbrains/annotations/UnknownNullability", DoNotGenerateAcw = true)]
	internal class IUnknownNullabilityInvoker : Java.Lang.Object, IUnknownNullability, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/UnknownNullability", typeof(IUnknownNullabilityInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_value;

		private IntPtr id_value;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IUnknownNullability? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IUnknownNullability>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.UnknownNullability'.");
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

		public IUnknownNullabilityInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IUnknownNullability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string? Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUnknownNullability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IUnknownNullability unknownNullability = Java.Lang.Object.GetObject<IUnknownNullability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return unknownNullability.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IUnknownNullability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IUnknownNullability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/Unmodifiable", "", "JetBrains.Annotations.IUnmodifiableInvoker")]
	public interface IUnmodifiable : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/jetbrains/annotations/Unmodifiable", DoNotGenerateAcw = true)]
	internal class IUnmodifiableInvoker : Java.Lang.Object, IUnmodifiable, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/Unmodifiable", typeof(IUnmodifiableInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IUnmodifiable? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IUnmodifiable>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.Unmodifiable'.");
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

		public IUnmodifiableInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUnmodifiable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IUnmodifiable unmodifiable = Java.Lang.Object.GetObject<IUnmodifiable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return unmodifiable.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IUnmodifiable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IUnmodifiable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/UnmodifiableView", "", "JetBrains.Annotations.IUnmodifiableViewInvoker")]
	public interface IUnmodifiableView : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/jetbrains/annotations/UnmodifiableView", DoNotGenerateAcw = true)]
	internal class IUnmodifiableViewInvoker : Java.Lang.Object, IUnmodifiableView, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/UnmodifiableView", typeof(IUnmodifiableViewInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IUnmodifiableView? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IUnmodifiableView>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.UnmodifiableView'.");
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

		public IUnmodifiableViewInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUnmodifiableView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IUnmodifiableView unmodifiableView = Java.Lang.Object.GetObject<IUnmodifiableView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return unmodifiableView.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IUnmodifiableView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IUnmodifiableView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/jetbrains/annotations/VisibleForTesting", "", "JetBrains.Annotations.IVisibleForTestingInvoker")]
	public interface IVisibleForTesting : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/jetbrains/annotations/VisibleForTesting", DoNotGenerateAcw = true)]
	internal class IVisibleForTestingInvoker : Java.Lang.Object, IVisibleForTesting, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/jetbrains/annotations/VisibleForTesting", typeof(IVisibleForTestingInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IVisibleForTesting? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IVisibleForTesting>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.jetbrains.annotations.VisibleForTesting'.");
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

		public IVisibleForTestingInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IVisibleForTesting>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IVisibleForTesting visibleForTesting = Java.Lang.Object.GetObject<IVisibleForTesting>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return visibleForTesting.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IVisibleForTesting>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IVisibleForTesting>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Annotation("org.jetbrains.annotations.MustBeInvokedByOverriders")]
	public class MustBeInvokedByOverridersAttribute : Attribute
	{
	}
	[Annotation("org.jetbrains.annotations.Nls")]
	public class NlsAttribute : Attribute
	{
	}
	[Annotation("org.jetbrains.annotations.NonBlocking")]
	public class NonBlockingAttribute : Attribute
	{
	}
	[Annotation("org.jetbrains.annotations.NonBlockingExecutor")]
	public class NonBlockingExecutorAttribute : Attribute
	{
	}
	[Annotation("org.jetbrains.annotations.NonNls")]
	public class NonNlsAttribute : Attribute
	{
	}
	[Annotation("org.jetbrains.annotations.NotNull")]
	public class NotNullAttribute : Attribute
	{
		[Register("exception")]
		public Class? Exception { get; set; }

		[Register("value")]
		public string? Value { get; set; }
	}
	[Annotation("org.jetbrains.annotations.Nullable")]
	public class NullableAttribute : Attribute
	{
		[Register("value")]
		public string? Value { get; set; }
	}
	[Annotation("org.jetbrains.annotations.PropertyKey")]
	public class PropertyKeyAttribute : Attribute
	{
		[Register("resourceBundle")]
		public string? ResourceBundle { get; set; }
	}
	[Annotation("org.jetbrains.annotations.Range")]
	public class RangeAttribute : Attribute
	{
		[Register("from")]
		public long From { get; set; }

		[Register("to")]
		public long To { get; set; }
	}
	[Annotation("org.jetbrains.annotations.TestOnly")]
	public class TestOnlyAttribute : Attribute
	{
	}
	[Annotation("org.jetbrains.annotations.UnknownNullability")]
	public class UnknownNullabilityAttribute : Attribute
	{
		[Register("value")]
		public string? Value { get; set; }
	}
	[Annotation("org.jetbrains.annotations.Unmodifiable")]
	public class UnmodifiableAttribute : Attribute
	{
	}
	[Annotation("org.jetbrains.annotations.UnmodifiableView")]
	public class UnmodifiableViewAttribute : Attribute
	{
	}
	[Annotation("org.jetbrains.annotations.VisibleForTesting")]
	public class VisibleForTestingAttribute : Attribute
	{
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[]? package_org_intellij_lang_annotations_mappings;

		private static string[]? package_org_jetbrains_annotations_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[2] { "org/intellij/lang/annotations", "org/jetbrains/annotations" }, new Converter<string, Type>[2] { lookup_org_intellij_lang_annotations_package, lookup_org_jetbrains_annotations_package });
		}

		private static Type? Lookup(string[] mappings, string javaType)
		{
			string text = TypeManager.LookupTypeMapping(mappings, javaType);
			if (text == null)
			{
				return null;
			}
			return Type.GetType(text);
		}

		private static Type? lookup_org_intellij_lang_annotations_package(string klass)
		{
			if (package_org_intellij_lang_annotations_mappings == null)
			{
				package_org_intellij_lang_annotations_mappings = new string[1] { "org/intellij/lang/annotations/JdkConstants:IntelliJ.Lang.Annotations.JdkConstants" };
			}
			return Lookup(package_org_intellij_lang_annotations_mappings, klass);
		}

		private static Type? lookup_org_jetbrains_annotations_package(string klass)
		{
			if (package_org_jetbrains_annotations_mappings == null)
			{
				package_org_jetbrains_annotations_mappings = new string[4] { "org/jetbrains/annotations/ApiStatus:JetBrains.Annotations.ApiStatus", "org/jetbrains/annotations/Async:JetBrains.Annotations.Async", "org/jetbrains/annotations/Debug:JetBrains.Annotations.Debug", "org/jetbrains/annotations/Nls$Capitalization:JetBrains.Annotations.NlsCapitalization" };
			}
			return Lookup(package_org_jetbrains_annotations_mappings, klass);
		}
	}
}
namespace IntelliJ.Lang.Annotations
{
	[Annotation("org.intellij.lang.annotations.Flow")]
	public class FlowAttribute : Attribute
	{
		[Register("source")]
		public string? Source { get; set; }

		[Register("sourceIsContainer")]
		public bool SourceIsContainer { get; set; }

		[Register("target")]
		public string? Target { get; set; }

		[Register("targetIsContainer")]
		public bool TargetIsContainer { get; set; }
	}
	[Annotation("org.intellij.lang.annotations.Identifier")]
	public class IdentifierAttribute : Attribute
	{
	}
	[Register("org/intellij/lang/annotations/Flow", DoNotGenerateAcw = true)]
	public abstract class Flow : Java.Lang.Object
	{
		[Register("DEFAULT_SOURCE")]
		public const string DefaultSource = "The method argument (if parameter was annotated) or this container (if instance method was annotated)";

		[Register("DEFAULT_TARGET")]
		public const string DefaultTarget = "This container (if the parameter was annotated) or the return value (if instance method was annotated)";

		[Register("RETURN_METHOD_TARGET")]
		public const string ReturnMethodTarget = "The return value of this method";

		[Register("THIS_SOURCE")]
		public const string ThisSource = "this";

		[Register("THIS_TARGET")]
		public const string ThisTarget = "this";

		internal Flow()
		{
		}
	}
	[Register("org/intellij/lang/annotations/Flow", DoNotGenerateAcw = true)]
	[Obsolete("Use the 'Flow' type. This type will be removed in a future release.", true)]
	public abstract class FlowConsts : Flow
	{
		private FlowConsts()
		{
		}
	}
	[Register("org/intellij/lang/annotations/Flow", "", "IntelliJ.Lang.Annotations.IFlowInvoker")]
	public interface IFlow : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("source", "()Ljava/lang/String;", "GetSourceHandler:IntelliJ.Lang.Annotations.IFlowInvoker, Xamarin.Jetbrains.Annotations")]
		string? Source();

		[Register("sourceIsContainer", "()Z", "GetSourceIsContainerHandler:IntelliJ.Lang.Annotations.IFlowInvoker, Xamarin.Jetbrains.Annotations")]
		bool SourceIsContainer();

		[Register("target", "()Ljava/lang/String;", "GetTargetHandler:IntelliJ.Lang.Annotations.IFlowInvoker, Xamarin.Jetbrains.Annotations")]
		string? Target();

		[Register("targetIsContainer", "()Z", "GetTargetIsContainerHandler:IntelliJ.Lang.Annotations.IFlowInvoker, Xamarin.Jetbrains.Annotations")]
		bool TargetIsContainer();
	}
	[Register("org/intellij/lang/annotations/Flow", DoNotGenerateAcw = true)]
	internal class IFlowInvoker : Java.Lang.Object, IFlow, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/Flow", typeof(IFlowInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_source;

		private IntPtr id_source;

		private static Delegate? cb_sourceIsContainer;

		private IntPtr id_sourceIsContainer;

		private static Delegate? cb_target;

		private IntPtr id_target;

		private static Delegate? cb_targetIsContainer;

		private IntPtr id_targetIsContainer;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IFlow? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFlow>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.Flow'.");
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

		public IFlowInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetSourceHandler()
		{
			if ((object)cb_source == null)
			{
				cb_source = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Source));
			}
			return cb_source;
		}

		private static IntPtr n_Source(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Source());
		}

		public string? Source()
		{
			if (id_source == IntPtr.Zero)
			{
				id_source = JNIEnv.GetMethodID(class_ref, "source", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_source), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSourceIsContainerHandler()
		{
			if ((object)cb_sourceIsContainer == null)
			{
				cb_sourceIsContainer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_SourceIsContainer));
			}
			return cb_sourceIsContainer;
		}

		private static bool n_SourceIsContainer(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SourceIsContainer();
		}

		public bool SourceIsContainer()
		{
			if (id_sourceIsContainer == IntPtr.Zero)
			{
				id_sourceIsContainer = JNIEnv.GetMethodID(class_ref, "sourceIsContainer", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_sourceIsContainer);
		}

		private static Delegate GetTargetHandler()
		{
			if ((object)cb_target == null)
			{
				cb_target = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Target));
			}
			return cb_target;
		}

		private static IntPtr n_Target(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Target());
		}

		public string? Target()
		{
			if (id_target == IntPtr.Zero)
			{
				id_target = JNIEnv.GetMethodID(class_ref, "target", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_target), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetTargetIsContainerHandler()
		{
			if ((object)cb_targetIsContainer == null)
			{
				cb_targetIsContainer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_TargetIsContainer));
			}
			return cb_targetIsContainer;
		}

		private static bool n_TargetIsContainer(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetIsContainer();
		}

		public bool TargetIsContainer()
		{
			if (id_targetIsContainer == IntPtr.Zero)
			{
				id_targetIsContainer = JNIEnv.GetMethodID(class_ref, "targetIsContainer", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_targetIsContainer);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IFlow flow = Java.Lang.Object.GetObject<IFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return flow.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/intellij/lang/annotations/Identifier", "", "IntelliJ.Lang.Annotations.IIdentifierInvoker")]
	public interface IIdentifier : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/intellij/lang/annotations/Identifier", DoNotGenerateAcw = true)]
	internal class IIdentifierInvoker : Java.Lang.Object, IIdentifier, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/Identifier", typeof(IIdentifierInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IIdentifier? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IIdentifier>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.Identifier'.");
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

		public IIdentifierInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IIdentifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IIdentifier identifier = Java.Lang.Object.GetObject<IIdentifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return identifier.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IIdentifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IIdentifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/intellij/lang/annotations/Language", "", "IntelliJ.Lang.Annotations.ILanguageInvoker")]
	public interface ILanguage : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("prefix", "()Ljava/lang/String;", "GetPrefixHandler:IntelliJ.Lang.Annotations.ILanguageInvoker, Xamarin.Jetbrains.Annotations")]
		string? Prefix();

		[Register("suffix", "()Ljava/lang/String;", "GetSuffixHandler:IntelliJ.Lang.Annotations.ILanguageInvoker, Xamarin.Jetbrains.Annotations")]
		string? Suffix();

		[Register("value", "()Ljava/lang/String;", "GetValueHandler:IntelliJ.Lang.Annotations.ILanguageInvoker, Xamarin.Jetbrains.Annotations")]
		string? Value();
	}
	[Register("org/intellij/lang/annotations/Language", DoNotGenerateAcw = true)]
	internal class ILanguageInvoker : Java.Lang.Object, ILanguage, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/Language", typeof(ILanguageInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_prefix;

		private IntPtr id_prefix;

		private static Delegate? cb_suffix;

		private IntPtr id_suffix;

		private static Delegate? cb_value;

		private IntPtr id_value;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static ILanguage? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILanguage>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.Language'.");
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

		public ILanguageInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetPrefixHandler()
		{
			if ((object)cb_prefix == null)
			{
				cb_prefix = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Prefix));
			}
			return cb_prefix;
		}

		private static IntPtr n_Prefix(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ILanguage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Prefix());
		}

		public string? Prefix()
		{
			if (id_prefix == IntPtr.Zero)
			{
				id_prefix = JNIEnv.GetMethodID(class_ref, "prefix", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_prefix), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSuffixHandler()
		{
			if ((object)cb_suffix == null)
			{
				cb_suffix = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Suffix));
			}
			return cb_suffix;
		}

		private static IntPtr n_Suffix(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ILanguage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Suffix());
		}

		public string? Suffix()
		{
			if (id_suffix == IntPtr.Zero)
			{
				id_suffix = JNIEnv.GetMethodID(class_ref, "suffix", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_suffix), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ILanguage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string? Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ILanguage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			ILanguage language = Java.Lang.Object.GetObject<ILanguage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return language.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ILanguage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ILanguage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/intellij/lang/annotations/MagicConstant", "", "IntelliJ.Lang.Annotations.IMagicConstantInvoker")]
	public interface IMagicConstant : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("flags", "()[J", "GetFlagsHandler:IntelliJ.Lang.Annotations.IMagicConstantInvoker, Xamarin.Jetbrains.Annotations")]
		long[]? Flags();

		[Register("flagsFromClass", "()Ljava/lang/Class;", "GetFlagsFromClassHandler:IntelliJ.Lang.Annotations.IMagicConstantInvoker, Xamarin.Jetbrains.Annotations")]
		Class? FlagsFromClass();

		[Register("intValues", "()[J", "GetIntValuesHandler:IntelliJ.Lang.Annotations.IMagicConstantInvoker, Xamarin.Jetbrains.Annotations")]
		long[]? IntValues();

		[Register("stringValues", "()[Ljava/lang/String;", "GetStringValuesHandler:IntelliJ.Lang.Annotations.IMagicConstantInvoker, Xamarin.Jetbrains.Annotations")]
		string[]? StringValues();

		[Register("valuesFromClass", "()Ljava/lang/Class;", "GetValuesFromClassHandler:IntelliJ.Lang.Annotations.IMagicConstantInvoker, Xamarin.Jetbrains.Annotations")]
		Class? ValuesFromClass();
	}
	[Register("org/intellij/lang/annotations/MagicConstant", DoNotGenerateAcw = true)]
	internal class IMagicConstantInvoker : Java.Lang.Object, IMagicConstant, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/MagicConstant", typeof(IMagicConstantInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_flags;

		private IntPtr id_flags;

		private static Delegate? cb_flagsFromClass;

		private IntPtr id_flagsFromClass;

		private static Delegate? cb_intValues;

		private IntPtr id_intValues;

		private static Delegate? cb_stringValues;

		private IntPtr id_stringValues;

		private static Delegate? cb_valuesFromClass;

		private IntPtr id_valuesFromClass;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IMagicConstant? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMagicConstant>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.MagicConstant'.");
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

		public IMagicConstantInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetFlagsHandler()
		{
			if ((object)cb_flags == null)
			{
				cb_flags = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Flags));
			}
			return cb_flags;
		}

		private static IntPtr n_Flags(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IMagicConstant>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Flags());
		}

		public long[]? Flags()
		{
			if (id_flags == IntPtr.Zero)
			{
				id_flags = JNIEnv.GetMethodID(class_ref, "flags", "()[J");
			}
			return (long[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_flags), JniHandleOwnership.TransferLocalRef, typeof(long));
		}

		private static Delegate GetFlagsFromClassHandler()
		{
			if ((object)cb_flagsFromClass == null)
			{
				cb_flagsFromClass = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_FlagsFromClass));
			}
			return cb_flagsFromClass;
		}

		private static IntPtr n_FlagsFromClass(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMagicConstant>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlagsFromClass());
		}

		public Class? FlagsFromClass()
		{
			if (id_flagsFromClass == IntPtr.Zero)
			{
				id_flagsFromClass = JNIEnv.GetMethodID(class_ref, "flagsFromClass", "()Ljava/lang/Class;");
			}
			return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_flagsFromClass), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetIntValuesHandler()
		{
			if ((object)cb_intValues == null)
			{
				cb_intValues = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_IntValues));
			}
			return cb_intValues;
		}

		private static IntPtr n_IntValues(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IMagicConstant>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntValues());
		}

		public long[]? IntValues()
		{
			if (id_intValues == IntPtr.Zero)
			{
				id_intValues = JNIEnv.GetMethodID(class_ref, "intValues", "()[J");
			}
			return (long[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_intValues), JniHandleOwnership.TransferLocalRef, typeof(long));
		}

		private static Delegate GetStringValuesHandler()
		{
			if ((object)cb_stringValues == null)
			{
				cb_stringValues = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_StringValues));
			}
			return cb_stringValues;
		}

		private static IntPtr n_StringValues(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IMagicConstant>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StringValues());
		}

		public string[]? StringValues()
		{
			if (id_stringValues == IntPtr.Zero)
			{
				id_stringValues = JNIEnv.GetMethodID(class_ref, "stringValues", "()[Ljava/lang/String;");
			}
			return (string[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_stringValues), JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		private static Delegate GetValuesFromClassHandler()
		{
			if ((object)cb_valuesFromClass == null)
			{
				cb_valuesFromClass = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ValuesFromClass));
			}
			return cb_valuesFromClass;
		}

		private static IntPtr n_ValuesFromClass(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMagicConstant>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValuesFromClass());
		}

		public Class? ValuesFromClass()
		{
			if (id_valuesFromClass == IntPtr.Zero)
			{
				id_valuesFromClass = JNIEnv.GetMethodID(class_ref, "valuesFromClass", "()Ljava/lang/Class;");
			}
			return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_valuesFromClass), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMagicConstant>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IMagicConstant magicConstant = Java.Lang.Object.GetObject<IMagicConstant>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return magicConstant.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IMagicConstant>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IMagicConstant>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/intellij/lang/annotations/Pattern", "", "IntelliJ.Lang.Annotations.IPatternInvoker")]
	public interface IPattern : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:IntelliJ.Lang.Annotations.IPatternInvoker, Xamarin.Jetbrains.Annotations")]
		string? Value();
	}
	[Register("org/intellij/lang/annotations/Pattern", DoNotGenerateAcw = true)]
	internal class IPatternInvoker : Java.Lang.Object, IPattern, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/Pattern", typeof(IPatternInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_value;

		private IntPtr id_value;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IPattern? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPattern>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.Pattern'.");
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

		public IPatternInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPattern>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string? Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPattern>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IPattern pattern = Java.Lang.Object.GetObject<IPattern>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return pattern.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IPattern>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPattern>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/intellij/lang/annotations/PrintFormat", "", "IntelliJ.Lang.Annotations.IPrintFormatInvoker")]
	public interface IPrintFormat : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("org/intellij/lang/annotations/PrintFormat", DoNotGenerateAcw = true)]
	internal class IPrintFormatInvoker : Java.Lang.Object, IPrintFormat, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/PrintFormat", typeof(IPrintFormatInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IPrintFormat? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPrintFormat>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.PrintFormat'.");
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

		public IPrintFormatInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPrintFormat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IPrintFormat printFormat = Java.Lang.Object.GetObject<IPrintFormat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return printFormat.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IPrintFormat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPrintFormat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/intellij/lang/annotations/RegExp", "", "IntelliJ.Lang.Annotations.IRegExpInvoker")]
	public interface IRegExp : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("prefix", "()Ljava/lang/String;", "GetPrefixHandler:IntelliJ.Lang.Annotations.IRegExpInvoker, Xamarin.Jetbrains.Annotations")]
		string? Prefix();

		[Register("suffix", "()Ljava/lang/String;", "GetSuffixHandler:IntelliJ.Lang.Annotations.IRegExpInvoker, Xamarin.Jetbrains.Annotations")]
		string? Suffix();
	}
	[Register("org/intellij/lang/annotations/RegExp", DoNotGenerateAcw = true)]
	internal class IRegExpInvoker : Java.Lang.Object, IRegExp, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/RegExp", typeof(IRegExpInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_prefix;

		private IntPtr id_prefix;

		private static Delegate? cb_suffix;

		private IntPtr id_suffix;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static IRegExp? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IRegExp>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.RegExp'.");
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

		public IRegExpInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetPrefixHandler()
		{
			if ((object)cb_prefix == null)
			{
				cb_prefix = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Prefix));
			}
			return cb_prefix;
		}

		private static IntPtr n_Prefix(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IRegExp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Prefix());
		}

		public string? Prefix()
		{
			if (id_prefix == IntPtr.Zero)
			{
				id_prefix = JNIEnv.GetMethodID(class_ref, "prefix", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_prefix), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSuffixHandler()
		{
			if ((object)cb_suffix == null)
			{
				cb_suffix = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Suffix));
			}
			return cb_suffix;
		}

		private static IntPtr n_Suffix(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IRegExp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Suffix());
		}

		public string? Suffix()
		{
			if (id_suffix == IntPtr.Zero)
			{
				id_suffix = JNIEnv.GetMethodID(class_ref, "suffix", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_suffix), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IRegExp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IRegExp regExp = Java.Lang.Object.GetObject<IRegExp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return regExp.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IRegExp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IRegExp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/intellij/lang/annotations/Subst", "", "IntelliJ.Lang.Annotations.ISubstInvoker")]
	public interface ISubst : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:IntelliJ.Lang.Annotations.ISubstInvoker, Xamarin.Jetbrains.Annotations")]
		string? Value();
	}
	[Register("org/intellij/lang/annotations/Subst", DoNotGenerateAcw = true)]
	internal class ISubstInvoker : Java.Lang.Object, ISubst, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/Subst", typeof(ISubstInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_value;

		private IntPtr id_value;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

		private IntPtr id_toString;

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

		public static ISubst? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISubst>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.Subst'.");
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

		public ISubstInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISubst>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string? Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISubst>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			ISubst subst = Java.Lang.Object.GetObject<ISubst>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return subst.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ISubst>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISubst>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("org/intellij/lang/annotations/JdkConstants", DoNotGenerateAcw = true)]
	public sealed class JdkConstants : Java.Lang.Object
	{
		[Register("org/intellij/lang/annotations/JdkConstants$AdjustableOrientation", "", "IntelliJ.Lang.Annotations.JdkConstants/IAdjustableOrientationInvoker")]
		public interface IAdjustableOrientation : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$AdjustableOrientation", DoNotGenerateAcw = true)]
		internal class IAdjustableOrientationInvoker : Java.Lang.Object, IAdjustableOrientation, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$AdjustableOrientation", typeof(IAdjustableOrientationInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IAdjustableOrientation? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IAdjustableOrientation>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.AdjustableOrientation'.");
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

			public IAdjustableOrientationInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IAdjustableOrientation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IAdjustableOrientation adjustableOrientation = Java.Lang.Object.GetObject<IAdjustableOrientation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return adjustableOrientation.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IAdjustableOrientation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IAdjustableOrientation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$BoxLayoutAxis", "", "IntelliJ.Lang.Annotations.JdkConstants/IBoxLayoutAxisInvoker")]
		public interface IBoxLayoutAxis : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$BoxLayoutAxis", DoNotGenerateAcw = true)]
		internal class IBoxLayoutAxisInvoker : Java.Lang.Object, IBoxLayoutAxis, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$BoxLayoutAxis", typeof(IBoxLayoutAxisInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IBoxLayoutAxis? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IBoxLayoutAxis>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.BoxLayoutAxis'.");
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

			public IBoxLayoutAxisInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBoxLayoutAxis>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IBoxLayoutAxis boxLayoutAxis = Java.Lang.Object.GetObject<IBoxLayoutAxis>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return boxLayoutAxis.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IBoxLayoutAxis>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IBoxLayoutAxis>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$CalendarMonth", "", "IntelliJ.Lang.Annotations.JdkConstants/ICalendarMonthInvoker")]
		public interface ICalendarMonth : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$CalendarMonth", DoNotGenerateAcw = true)]
		internal class ICalendarMonthInvoker : Java.Lang.Object, ICalendarMonth, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$CalendarMonth", typeof(ICalendarMonthInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static ICalendarMonth? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ICalendarMonth>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.CalendarMonth'.");
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

			public ICalendarMonthInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICalendarMonth>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				ICalendarMonth calendarMonth = Java.Lang.Object.GetObject<ICalendarMonth>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return calendarMonth.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<ICalendarMonth>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<ICalendarMonth>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$CursorType", "", "IntelliJ.Lang.Annotations.JdkConstants/ICursorTypeInvoker")]
		public interface ICursorType : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$CursorType", DoNotGenerateAcw = true)]
		internal class ICursorTypeInvoker : Java.Lang.Object, ICursorType, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$CursorType", typeof(ICursorTypeInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static ICursorType? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ICursorType>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.CursorType'.");
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

			public ICursorTypeInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICursorType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				ICursorType cursorType = Java.Lang.Object.GetObject<ICursorType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return cursorType.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<ICursorType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<ICursorType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$FlowLayoutAlignment", "", "IntelliJ.Lang.Annotations.JdkConstants/IFlowLayoutAlignmentInvoker")]
		public interface IFlowLayoutAlignment : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$FlowLayoutAlignment", DoNotGenerateAcw = true)]
		internal class IFlowLayoutAlignmentInvoker : Java.Lang.Object, IFlowLayoutAlignment, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$FlowLayoutAlignment", typeof(IFlowLayoutAlignmentInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IFlowLayoutAlignment? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IFlowLayoutAlignment>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.FlowLayoutAlignment'.");
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

			public IFlowLayoutAlignmentInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFlowLayoutAlignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IFlowLayoutAlignment flowLayoutAlignment = Java.Lang.Object.GetObject<IFlowLayoutAlignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return flowLayoutAlignment.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IFlowLayoutAlignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IFlowLayoutAlignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$FontStyle", "", "IntelliJ.Lang.Annotations.JdkConstants/IFontStyleInvoker")]
		public interface IFontStyle : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$FontStyle", DoNotGenerateAcw = true)]
		internal class IFontStyleInvoker : Java.Lang.Object, IFontStyle, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$FontStyle", typeof(IFontStyleInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IFontStyle? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IFontStyle>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.FontStyle'.");
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

			public IFontStyleInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFontStyle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IFontStyle fontStyle = Java.Lang.Object.GetObject<IFontStyle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return fontStyle.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IFontStyle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IFontStyle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$HorizontalAlignment", "", "IntelliJ.Lang.Annotations.JdkConstants/IHorizontalAlignmentInvoker")]
		public interface IHorizontalAlignment : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$HorizontalAlignment", DoNotGenerateAcw = true)]
		internal class IHorizontalAlignmentInvoker : Java.Lang.Object, IHorizontalAlignment, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$HorizontalAlignment", typeof(IHorizontalAlignmentInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IHorizontalAlignment? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IHorizontalAlignment>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.HorizontalAlignment'.");
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

			public IHorizontalAlignmentInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IHorizontalAlignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IHorizontalAlignment horizontalAlignment = Java.Lang.Object.GetObject<IHorizontalAlignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return horizontalAlignment.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IHorizontalAlignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IHorizontalAlignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$HorizontalScrollBarPolicy", "", "IntelliJ.Lang.Annotations.JdkConstants/IHorizontalScrollBarPolicyInvoker")]
		public interface IHorizontalScrollBarPolicy : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$HorizontalScrollBarPolicy", DoNotGenerateAcw = true)]
		internal class IHorizontalScrollBarPolicyInvoker : Java.Lang.Object, IHorizontalScrollBarPolicy, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$HorizontalScrollBarPolicy", typeof(IHorizontalScrollBarPolicyInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IHorizontalScrollBarPolicy? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IHorizontalScrollBarPolicy>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.HorizontalScrollBarPolicy'.");
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

			public IHorizontalScrollBarPolicyInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IHorizontalScrollBarPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IHorizontalScrollBarPolicy horizontalScrollBarPolicy = Java.Lang.Object.GetObject<IHorizontalScrollBarPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return horizontalScrollBarPolicy.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IHorizontalScrollBarPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IHorizontalScrollBarPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$InputEventMask", "", "IntelliJ.Lang.Annotations.JdkConstants/IInputEventMaskInvoker")]
		public interface IInputEventMask : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$InputEventMask", DoNotGenerateAcw = true)]
		internal class IInputEventMaskInvoker : Java.Lang.Object, IInputEventMask, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$InputEventMask", typeof(IInputEventMaskInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IInputEventMask? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IInputEventMask>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.InputEventMask'.");
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

			public IInputEventMaskInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IInputEventMask>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IInputEventMask inputEventMask = Java.Lang.Object.GetObject<IInputEventMask>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return inputEventMask.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IInputEventMask>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IInputEventMask>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$ListSelectionMode", "", "IntelliJ.Lang.Annotations.JdkConstants/IListSelectionModeInvoker")]
		public interface IListSelectionMode : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$ListSelectionMode", DoNotGenerateAcw = true)]
		internal class IListSelectionModeInvoker : Java.Lang.Object, IListSelectionMode, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$ListSelectionMode", typeof(IListSelectionModeInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IListSelectionMode? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IListSelectionMode>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.ListSelectionMode'.");
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

			public IListSelectionModeInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IListSelectionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IListSelectionMode listSelectionMode = Java.Lang.Object.GetObject<IListSelectionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return listSelectionMode.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IListSelectionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IListSelectionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$PatternFlags", "", "IntelliJ.Lang.Annotations.JdkConstants/IPatternFlagsInvoker")]
		public interface IPatternFlags : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$PatternFlags", DoNotGenerateAcw = true)]
		internal class IPatternFlagsInvoker : Java.Lang.Object, IPatternFlags, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$PatternFlags", typeof(IPatternFlagsInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IPatternFlags? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IPatternFlags>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.PatternFlags'.");
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

			public IPatternFlagsInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPatternFlags>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IPatternFlags patternFlags = Java.Lang.Object.GetObject<IPatternFlags>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return patternFlags.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IPatternFlags>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IPatternFlags>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$TabLayoutPolicy", "", "IntelliJ.Lang.Annotations.JdkConstants/ITabLayoutPolicyInvoker")]
		public interface ITabLayoutPolicy : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$TabLayoutPolicy", DoNotGenerateAcw = true)]
		internal class ITabLayoutPolicyInvoker : Java.Lang.Object, ITabLayoutPolicy, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$TabLayoutPolicy", typeof(ITabLayoutPolicyInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static ITabLayoutPolicy? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ITabLayoutPolicy>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.TabLayoutPolicy'.");
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

			public ITabLayoutPolicyInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITabLayoutPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				ITabLayoutPolicy tabLayoutPolicy = Java.Lang.Object.GetObject<ITabLayoutPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return tabLayoutPolicy.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<ITabLayoutPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<ITabLayoutPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$TabPlacement", "", "IntelliJ.Lang.Annotations.JdkConstants/ITabPlacementInvoker")]
		public interface ITabPlacement : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$TabPlacement", DoNotGenerateAcw = true)]
		internal class ITabPlacementInvoker : Java.Lang.Object, ITabPlacement, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$TabPlacement", typeof(ITabPlacementInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static ITabPlacement? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ITabPlacement>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.TabPlacement'.");
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

			public ITabPlacementInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITabPlacement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				ITabPlacement tabPlacement = Java.Lang.Object.GetObject<ITabPlacement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return tabPlacement.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<ITabPlacement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<ITabPlacement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$TitledBorderJustification", "", "IntelliJ.Lang.Annotations.JdkConstants/ITitledBorderJustificationInvoker")]
		public interface ITitledBorderJustification : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$TitledBorderJustification", DoNotGenerateAcw = true)]
		internal class ITitledBorderJustificationInvoker : Java.Lang.Object, ITitledBorderJustification, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$TitledBorderJustification", typeof(ITitledBorderJustificationInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static ITitledBorderJustification? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ITitledBorderJustification>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.TitledBorderJustification'.");
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

			public ITitledBorderJustificationInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITitledBorderJustification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				ITitledBorderJustification titledBorderJustification = Java.Lang.Object.GetObject<ITitledBorderJustification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return titledBorderJustification.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<ITitledBorderJustification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<ITitledBorderJustification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$TitledBorderTitlePosition", "", "IntelliJ.Lang.Annotations.JdkConstants/ITitledBorderTitlePositionInvoker")]
		public interface ITitledBorderTitlePosition : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$TitledBorderTitlePosition", DoNotGenerateAcw = true)]
		internal class ITitledBorderTitlePositionInvoker : Java.Lang.Object, ITitledBorderTitlePosition, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$TitledBorderTitlePosition", typeof(ITitledBorderTitlePositionInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static ITitledBorderTitlePosition? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ITitledBorderTitlePosition>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.TitledBorderTitlePosition'.");
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

			public ITitledBorderTitlePositionInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITitledBorderTitlePosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				ITitledBorderTitlePosition titledBorderTitlePosition = Java.Lang.Object.GetObject<ITitledBorderTitlePosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return titledBorderTitlePosition.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<ITitledBorderTitlePosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<ITitledBorderTitlePosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$TreeSelectionMode", "", "IntelliJ.Lang.Annotations.JdkConstants/ITreeSelectionModeInvoker")]
		public interface ITreeSelectionMode : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$TreeSelectionMode", DoNotGenerateAcw = true)]
		internal class ITreeSelectionModeInvoker : Java.Lang.Object, ITreeSelectionMode, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$TreeSelectionMode", typeof(ITreeSelectionModeInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static ITreeSelectionMode? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ITreeSelectionMode>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.TreeSelectionMode'.");
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

			public ITreeSelectionModeInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITreeSelectionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				ITreeSelectionMode treeSelectionMode = Java.Lang.Object.GetObject<ITreeSelectionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return treeSelectionMode.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<ITreeSelectionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<ITreeSelectionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/intellij/lang/annotations/JdkConstants$VerticalScrollBarPolicy", "", "IntelliJ.Lang.Annotations.JdkConstants/IVerticalScrollBarPolicyInvoker")]
		public interface IVerticalScrollBarPolicy : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("org/intellij/lang/annotations/JdkConstants$VerticalScrollBarPolicy", DoNotGenerateAcw = true)]
		internal class IVerticalScrollBarPolicyInvoker : Java.Lang.Object, IVerticalScrollBarPolicy, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants$VerticalScrollBarPolicy", typeof(IVerticalScrollBarPolicyInvoker));

			private IntPtr class_ref;

			private static Delegate? cb_annotationType;

			private IntPtr id_annotationType;

			private static Delegate? cb_equals_Ljava_lang_Object_;

			private IntPtr id_equals_Ljava_lang_Object_;

			private static Delegate? cb_hashCode;

			private IntPtr id_hashCode;

			private static Delegate? cb_toString;

			private IntPtr id_toString;

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

			public static IVerticalScrollBarPolicy? GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IVerticalScrollBarPolicy>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'org.intellij.lang.annotations.JdkConstants.VerticalScrollBarPolicy'.");
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

			public IVerticalScrollBarPolicyInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
				}
				return cb_annotationType;
			}

			private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IVerticalScrollBarPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
			}

			public Class? AnnotationType()
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
					cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
				}
				return cb_equals_Ljava_lang_Object_;
			}

			private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
			{
				IVerticalScrollBarPolicy verticalScrollBarPolicy = Java.Lang.Object.GetObject<IVerticalScrollBarPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return verticalScrollBarPolicy.Equals(obj);
			}

			public new unsafe bool Equals(Java.Lang.Object? obj)
			{
				if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetGetHashCodeHandler()
			{
				if ((object)cb_hashCode == null)
				{
					cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
				}
				return cb_hashCode;
			}

			private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IVerticalScrollBarPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
					cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
				}
				return cb_toString;
			}

			private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IVerticalScrollBarPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
			}

			public new string? ToString()
			{
				if (id_toString == IntPtr.Zero)
				{
					id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/intellij/lang/annotations/JdkConstants", typeof(JdkConstants));

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

		internal JdkConstants(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Annotation("org.intellij.lang.annotations.Language")]
	public class LanguageAttribute : Attribute
	{
		[Register("prefix")]
		public string? Prefix { get; set; }

		[Register("suffix")]
		public string? Suffix { get; set; }

		[Register("value")]
		public string? Value { get; set; }
	}
	[Annotation("org.intellij.lang.annotations.MagicConstant")]
	public class MagicConstantAttribute : Attribute
	{
		[Register("flags")]
		public long[]? Flags { get; set; }

		[Register("flagsFromClass")]
		public Class? FlagsFromClass { get; set; }

		[Register("intValues")]
		public long[]? IntValues { get; set; }

		[Register("stringValues")]
		public string[]? StringValues { get; set; }

		[Register("valuesFromClass")]
		public Class? ValuesFromClass { get; set; }
	}
	[Annotation("org.intellij.lang.annotations.Pattern")]
	public class PatternAttribute : Attribute
	{
		[Register("value")]
		public string? Value { get; set; }
	}
	[Annotation("org.intellij.lang.annotations.PrintFormat")]
	public class PrintFormatAttribute : Attribute
	{
	}
	[Annotation("org.intellij.lang.annotations.RegExp")]
	public class RegExpAttribute : Attribute
	{
		[Register("prefix")]
		public string? Prefix { get; set; }

		[Register("suffix")]
		public string? Suffix { get; set; }
	}
	[Annotation("org.intellij.lang.annotations.Subst")]
	public class SubstAttribute : Attribute
	{
		[Register("value")]
		public string? Value { get; set; }
	}
}
