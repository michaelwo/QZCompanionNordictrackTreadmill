using System;
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

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "javax.inject", Managed = "JavaX.Inject")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.JavaX.Inject")]
[assembly: AssemblyTitle("Xamarin.JavaX.Inject")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace JavaX.Inject
{
	[Register("javax/inject/Inject", "", "JavaX.Inject.IInjectInvoker")]
	public interface IInject : IAnnotation, IJavaObject, IDisposable
	{
	}
	[Register("javax/inject/Inject", DoNotGenerateAcw = true)]
	internal class IInjectInvoker : Java.Lang.Object, IInject, IAnnotation, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("javax/inject/Inject", typeof(IInjectInvoker));

		private IntPtr class_ref;

		private static Delegate cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate cb_toString;

		private IntPtr id_toString;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IInject GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IInject>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "javax.inject.Inject"));
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

		public IInjectInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IInject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IInject inject = Java.Lang.Object.GetObject<IInject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return inject.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object obj)
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
				cb_hashCode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IInject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IInject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("javax/inject/Named", "", "JavaX.Inject.INamedInvoker")]
	public interface INamed : IAnnotation, IJavaObject, IDisposable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:JavaX.Inject.INamedInvoker, Xamarin.JavaX.Inject")]
		string Value();
	}
	[Register("javax/inject/Named", DoNotGenerateAcw = true)]
	internal class INamedInvoker : Java.Lang.Object, INamed, IAnnotation, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("javax/inject/Named", typeof(INamedInvoker));

		private IntPtr class_ref;

		private static Delegate cb_value;

		private IntPtr id_value;

		private static Delegate cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate cb_toString;

		private IntPtr id_toString;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static INamed GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<INamed>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "javax.inject.Named"));
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

		public INamedInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_value = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<INamed>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string Value()
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<INamed>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			INamed named = Java.Lang.Object.GetObject<INamed>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return named.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object obj)
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
				cb_hashCode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<INamed>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<INamed>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Annotation("javax.inject.Inject")]
	public class InjectAttribute : Attribute
	{
	}
	[Register("javax/inject/Provider", "", "JavaX.Inject.IProviderInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IProvider : IJavaObject, IDisposable
	{
		[Register("get", "()Ljava/lang/Object;", "GetGetHandler:JavaX.Inject.IProviderInvoker, Xamarin.JavaX.Inject")]
		Java.Lang.Object Get();
	}
	[Register("javax/inject/Provider", DoNotGenerateAcw = true)]
	internal class IProviderInvoker : Java.Lang.Object, IProvider, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("javax/inject/Provider", typeof(IProviderInvoker));

		private IntPtr class_ref;

		private static Delegate cb_get;

		private IntPtr id_get;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IProvider GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IProvider>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "javax.inject.Provider"));
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

		public IProviderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetHandler()
		{
			if ((object)cb_get == null)
			{
				cb_get = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_Get));
			}
			return cb_get;
		}

		private static IntPtr n_Get(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get());
		}

		public Java.Lang.Object Get()
		{
			if (id_get == IntPtr.Zero)
			{
				id_get = JNIEnv.GetMethodID(class_ref, "get", "()Ljava/lang/Object;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_get), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("javax/inject/Qualifier", "", "JavaX.Inject.IQualifierInvoker")]
	public interface IQualifier : IAnnotation, IJavaObject, IDisposable
	{
	}
	[Register("javax/inject/Qualifier", DoNotGenerateAcw = true)]
	internal class IQualifierInvoker : Java.Lang.Object, IQualifier, IAnnotation, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("javax/inject/Qualifier", typeof(IQualifierInvoker));

		private IntPtr class_ref;

		private static Delegate cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate cb_toString;

		private IntPtr id_toString;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IQualifier GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IQualifier>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "javax.inject.Qualifier"));
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

		public IQualifierInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IQualifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IQualifier qualifier = Java.Lang.Object.GetObject<IQualifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return qualifier.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object obj)
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
				cb_hashCode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IQualifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IQualifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("javax/inject/Scope", "", "JavaX.Inject.IScopeInvoker")]
	public interface IScope : IAnnotation, IJavaObject, IDisposable
	{
	}
	[Register("javax/inject/Scope", DoNotGenerateAcw = true)]
	internal class IScopeInvoker : Java.Lang.Object, IScope, IAnnotation, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("javax/inject/Scope", typeof(IScopeInvoker));

		private IntPtr class_ref;

		private static Delegate cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate cb_toString;

		private IntPtr id_toString;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IScope GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IScope>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "javax.inject.Scope"));
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

		public IScopeInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IScope>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IScope scope = Java.Lang.Object.GetObject<IScope>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return scope.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object obj)
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
				cb_hashCode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IScope>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IScope>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("javax/inject/Singleton", "", "JavaX.Inject.ISingletonInvoker")]
	public interface ISingleton : IAnnotation, IJavaObject, IDisposable
	{
	}
	[Register("javax/inject/Singleton", DoNotGenerateAcw = true)]
	internal class ISingletonInvoker : Java.Lang.Object, ISingleton, IAnnotation, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("javax/inject/Singleton", typeof(ISingletonInvoker));

		private IntPtr class_ref;

		private static Delegate cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate cb_toString;

		private IntPtr id_toString;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ISingleton GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISingleton>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "javax.inject.Singleton"));
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

		public ISingletonInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISingleton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			ISingleton singleton = Java.Lang.Object.GetObject<ISingleton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return singleton.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object obj)
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
				cb_hashCode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ISingleton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISingleton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Annotation("javax.inject.Named")]
	public class NamedAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("javax.inject.Qualifier")]
	public class QualifierAttribute : Attribute
	{
	}
	[Annotation("javax.inject.Scope")]
	public class ScopeAttribute : Attribute
	{
	}
	[Annotation("javax.inject.Singleton")]
	public class SingletonAttribute : Attribute
	{
	}
}
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
