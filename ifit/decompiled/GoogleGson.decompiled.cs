using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Runtime;
using GoogleGson.Reflect;
using GoogleGson.Stream;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;
using Java.Lang.Reflect;
using Java.Math;
using Java.Util;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "com.google.gson", Managed = "GoogleGson")]
[assembly: NamespaceMapping(Java = "com.google.gson.annotations", Managed = "GoogleGson.Annotations")]
[assembly: NamespaceMapping(Java = "com.google.gson.reflect", Managed = "GoogleGson.Reflect")]
[assembly: NamespaceMapping(Java = "com.google.gson.stream", Managed = "GoogleGson.Stream")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("GoogleGson")]
[assembly: AssemblyTitle("GoogleGson")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate sbyte _JniMarshal_PP_B(IntPtr jnienv, IntPtr klass);
internal delegate double _JniMarshal_PP_D(IntPtr jnienv, IntPtr klass);
internal delegate float _JniMarshal_PP_F(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate short _JniMarshal_PP_S(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPD_L(IntPtr jnienv, IntPtr klass, double p0);
internal delegate IntPtr _JniMarshal_PPJ_L(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPZ_L(IntPtr jnienv, IntPtr klass, bool p0);
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
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_google_gson_mappings;

		private static string[] package_com_google_gson_reflect_mappings;

		private static string[] package_com_google_gson_stream_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[3] { "com/google/gson", "com/google/gson/reflect", "com/google/gson/stream" }, new Converter<string, Type>[3] { lookup_com_google_gson_package, lookup_com_google_gson_reflect_package, lookup_com_google_gson_stream_package });
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

		private static Type lookup_com_google_gson_package(string klass)
		{
			if (package_com_google_gson_mappings == null)
			{
				package_com_google_gson_mappings = new string[17]
				{
					"com/google/gson/FieldAttributes:GoogleGson.FieldAttributes", "com/google/gson/FieldNamingPolicy:GoogleGson.FieldNamingPolicy", "com/google/gson/Gson:GoogleGson.Gson", "com/google/gson/GsonBuilder:GoogleGson.GsonBuilder", "com/google/gson/JsonArray:GoogleGson.JsonArray", "com/google/gson/JsonElement:GoogleGson.JsonElement", "com/google/gson/JsonIOException:GoogleGson.JsonIOException", "com/google/gson/JsonNull:GoogleGson.JsonNull", "com/google/gson/JsonObject:GoogleGson.JsonObject", "com/google/gson/JsonParseException:GoogleGson.JsonParseException",
					"com/google/gson/JsonParser:GoogleGson.JsonParser", "com/google/gson/JsonPrimitive:GoogleGson.JsonPrimitive", "com/google/gson/JsonStreamParser:GoogleGson.JsonStreamParser", "com/google/gson/JsonSyntaxException:GoogleGson.JsonSyntaxException", "com/google/gson/LongSerializationPolicy:GoogleGson.LongSerializationPolicy", "com/google/gson/ToNumberPolicy:GoogleGson.ToNumberPolicy", "com/google/gson/TypeAdapter:GoogleGson.TypeAdapter"
				};
			}
			return Lookup(package_com_google_gson_mappings, klass);
		}

		private static Type lookup_com_google_gson_reflect_package(string klass)
		{
			if (package_com_google_gson_reflect_mappings == null)
			{
				package_com_google_gson_reflect_mappings = new string[1] { "com/google/gson/reflect/TypeToken:GoogleGson.Reflect.TypeToken" };
			}
			return Lookup(package_com_google_gson_reflect_mappings, klass);
		}

		private static Type lookup_com_google_gson_stream_package(string klass)
		{
			if (package_com_google_gson_stream_mappings == null)
			{
				package_com_google_gson_stream_mappings = new string[4] { "com/google/gson/stream/JsonReader:GoogleGson.Stream.JsonReader", "com/google/gson/stream/JsonToken:GoogleGson.Stream.JsonToken", "com/google/gson/stream/JsonWriter:GoogleGson.Stream.JsonWriter", "com/google/gson/stream/MalformedJsonException:GoogleGson.Stream.MalformedJsonException" };
			}
			return Lookup(package_com_google_gson_stream_mappings, klass);
		}
	}
}
namespace GoogleGson
{
	[Register("com/google/gson/FieldAttributes", DoNotGenerateAcw = true)]
	public sealed class FieldAttributes : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/FieldAttributes", typeof(FieldAttributes));

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

		public unsafe ICollection<IAnnotation> Annotations
		{
			[Register("getAnnotations", "()Ljava/util/Collection;", "")]
			get
			{
				return JavaCollection<IAnnotation>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getAnnotations.()Ljava/util/Collection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Class DeclaredClass
		{
			[Register("getDeclaredClass", "()Ljava/lang/Class;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Class>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDeclaredClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IType DeclaredType
		{
			[Register("getDeclaredType", "()Ljava/lang/reflect/Type;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IType>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDeclaredType.()Ljava/lang/reflect/Type;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Class DeclaringClass
		{
			[Register("getDeclaringClass", "()Ljava/lang/Class;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Class>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDeclaringClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Name
		{
			[Register("getName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal FieldAttributes(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/reflect/Field;)V", "")]
		public unsafe FieldAttributes(Field f)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/reflect/Field;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/reflect/Field;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(f);
			}
		}

		[Register("getAnnotation", "(Ljava/lang/Class;)Ljava/lang/annotation/Annotation;", "")]
		[JavaTypeParameters(new string[] { "T extends java.lang.annotation.Annotation" })]
		public unsafe Java.Lang.Object GetAnnotation(Class annotation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(annotation?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAnnotation.(Ljava/lang/Class;)Ljava/lang/annotation/Annotation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(annotation);
			}
		}

		[Register("hasModifier", "(I)Z", "")]
		public unsafe bool HasModifier(int modifier)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(modifier);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasModifier.(I)Z", this, ptr);
		}
	}
	[Register("com/google/gson/FieldNamingPolicy", DoNotGenerateAcw = true)]
	public abstract class FieldNamingPolicy : Java.Lang.Enum, IFieldNamingStrategy, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/FieldNamingPolicy", typeof(FieldNamingPolicy));

		private static Delegate cb_translateName_Ljava_lang_reflect_Field_;

		[Register("IDENTITY")]
		public static FieldNamingPolicy Identity => Java.Lang.Object.GetObject<FieldNamingPolicy>(_members.StaticFields.GetObjectValue("IDENTITY.Lcom/google/gson/FieldNamingPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LOWER_CASE_WITH_DASHES")]
		public static FieldNamingPolicy LowerCaseWithDashes => Java.Lang.Object.GetObject<FieldNamingPolicy>(_members.StaticFields.GetObjectValue("LOWER_CASE_WITH_DASHES.Lcom/google/gson/FieldNamingPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LOWER_CASE_WITH_DOTS")]
		public static FieldNamingPolicy LowerCaseWithDots => Java.Lang.Object.GetObject<FieldNamingPolicy>(_members.StaticFields.GetObjectValue("LOWER_CASE_WITH_DOTS.Lcom/google/gson/FieldNamingPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LOWER_CASE_WITH_UNDERSCORES")]
		public static FieldNamingPolicy LowerCaseWithUnderscores => Java.Lang.Object.GetObject<FieldNamingPolicy>(_members.StaticFields.GetObjectValue("LOWER_CASE_WITH_UNDERSCORES.Lcom/google/gson/FieldNamingPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UPPER_CAMEL_CASE")]
		public static FieldNamingPolicy UpperCamelCase => Java.Lang.Object.GetObject<FieldNamingPolicy>(_members.StaticFields.GetObjectValue("UPPER_CAMEL_CASE.Lcom/google/gson/FieldNamingPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UPPER_CAMEL_CASE_WITH_SPACES")]
		public static FieldNamingPolicy UpperCamelCaseWithSpaces => Java.Lang.Object.GetObject<FieldNamingPolicy>(_members.StaticFields.GetObjectValue("UPPER_CAMEL_CASE_WITH_SPACES.Lcom/google/gson/FieldNamingPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

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

		protected FieldNamingPolicy(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/gson/FieldNamingPolicy;", "")]
		public unsafe static FieldNamingPolicy ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<FieldNamingPolicy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/gson/FieldNamingPolicy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/gson/FieldNamingPolicy;", "")]
		public unsafe static FieldNamingPolicy[] Values()
		{
			return (FieldNamingPolicy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/gson/FieldNamingPolicy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(FieldNamingPolicy));
		}

		private static Delegate GetTranslateName_Ljava_lang_reflect_Field_Handler()
		{
			if ((object)cb_translateName_Ljava_lang_reflect_Field_ == null)
			{
				cb_translateName_Ljava_lang_reflect_Field_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_TranslateName_Ljava_lang_reflect_Field_));
			}
			return cb_translateName_Ljava_lang_reflect_Field_;
		}

		private static IntPtr n_TranslateName_Ljava_lang_reflect_Field_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			FieldNamingPolicy fieldNamingPolicy = Java.Lang.Object.GetObject<FieldNamingPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Field p = Java.Lang.Object.GetObject<Field>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(fieldNamingPolicy.TranslateName(p));
		}

		[Register("translateName", "(Ljava/lang/reflect/Field;)Ljava/lang/String;", "GetTranslateName_Ljava_lang_reflect_Field_Handler")]
		public abstract string TranslateName(Field p0);
	}
	[Register("com/google/gson/FieldNamingPolicy", DoNotGenerateAcw = true)]
	internal class FieldNamingPolicyInvoker : FieldNamingPolicy
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/FieldNamingPolicy", typeof(FieldNamingPolicyInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public FieldNamingPolicyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("translateName", "(Ljava/lang/reflect/Field;)Ljava/lang/String;", "GetTranslateName_Ljava_lang_reflect_Field_Handler")]
		public unsafe override string TranslateName(Field p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("translateName.(Ljava/lang/reflect/Field;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/gson/Gson", DoNotGenerateAcw = true)]
	public sealed class Gson : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/Gson", typeof(Gson));

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

		internal Gson(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Gson()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("fieldNamingStrategy", "()Lcom/google/gson/FieldNamingStrategy;", "")]
		public unsafe IFieldNamingStrategy FieldNamingStrategy()
		{
			return Java.Lang.Object.GetObject<IFieldNamingStrategy>(_members.InstanceMethods.InvokeAbstractObjectMethod("fieldNamingStrategy.()Lcom/google/gson/FieldNamingStrategy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("fromJson", "(Lcom/google/gson/JsonElement;Ljava/lang/Class;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe Java.Lang.Object FromJson(JsonElement json, Class classOfT)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(json?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(classOfT?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("fromJson.(Lcom/google/gson/JsonElement;Ljava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(json);
				GC.KeepAlive(classOfT);
			}
		}

		[Register("fromJson", "(Lcom/google/gson/JsonElement;Ljava/lang/reflect/Type;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe Java.Lang.Object FromJson(JsonElement json, IType typeOfT)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(json?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((typeOfT == null) ? IntPtr.Zero : ((Java.Lang.Object)typeOfT).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("fromJson.(Lcom/google/gson/JsonElement;Ljava/lang/reflect/Type;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(json);
				GC.KeepAlive(typeOfT);
			}
		}

		[Register("fromJson", "(Lcom/google/gson/stream/JsonReader;Ljava/lang/reflect/Type;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe Java.Lang.Object FromJson(JsonReader reader, IType typeOfT)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(reader?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((typeOfT == null) ? IntPtr.Zero : ((Java.Lang.Object)typeOfT).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("fromJson.(Lcom/google/gson/stream/JsonReader;Ljava/lang/reflect/Type;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(reader);
				GC.KeepAlive(typeOfT);
			}
		}

		[Register("fromJson", "(Ljava/io/Reader;Ljava/lang/Class;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe Java.Lang.Object FromJson(Reader json, Class classOfT)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(json?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(classOfT?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("fromJson.(Ljava/io/Reader;Ljava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(json);
				GC.KeepAlive(classOfT);
			}
		}

		[Register("fromJson", "(Ljava/io/Reader;Ljava/lang/reflect/Type;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe Java.Lang.Object FromJson(Reader json, IType typeOfT)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(json?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((typeOfT == null) ? IntPtr.Zero : ((Java.Lang.Object)typeOfT).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("fromJson.(Ljava/io/Reader;Ljava/lang/reflect/Type;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(json);
				GC.KeepAlive(typeOfT);
			}
		}

		[Register("fromJson", "(Ljava/lang/String;Ljava/lang/Class;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe Java.Lang.Object FromJson(string json, Class classOfT)
		{
			IntPtr intPtr = JNIEnv.NewString(json);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(classOfT?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("fromJson.(Ljava/lang/String;Ljava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(classOfT);
			}
		}

		[Register("fromJson", "(Ljava/lang/String;Ljava/lang/reflect/Type;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe Java.Lang.Object FromJson(string json, IType typeOfT)
		{
			IntPtr intPtr = JNIEnv.NewString(json);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((typeOfT == null) ? IntPtr.Zero : ((Java.Lang.Object)typeOfT).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("fromJson.(Ljava/lang/String;Ljava/lang/reflect/Type;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(typeOfT);
			}
		}

		[Register("getAdapter", "(Lcom/google/gson/reflect/TypeToken;)Lcom/google/gson/TypeAdapter;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe TypeAdapter GetAdapter(TypeToken type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TypeAdapter>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAdapter.(Lcom/google/gson/reflect/TypeToken;)Lcom/google/gson/TypeAdapter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		[Register("getAdapter", "(Ljava/lang/Class;)Lcom/google/gson/TypeAdapter;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe TypeAdapter GetAdapter(Class type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TypeAdapter>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAdapter.(Ljava/lang/Class;)Lcom/google/gson/TypeAdapter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		[Register("getDelegateAdapter", "(Lcom/google/gson/TypeAdapterFactory;Lcom/google/gson/reflect/TypeToken;)Lcom/google/gson/TypeAdapter;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe TypeAdapter GetDelegateAdapter(ITypeAdapterFactory skipPast, TypeToken type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((skipPast == null) ? IntPtr.Zero : ((Java.Lang.Object)skipPast).Handle);
				ptr[1] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TypeAdapter>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDelegateAdapter.(Lcom/google/gson/TypeAdapterFactory;Lcom/google/gson/reflect/TypeToken;)Lcom/google/gson/TypeAdapter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(skipPast);
				GC.KeepAlive(type);
			}
		}

		[Register("htmlSafe", "()Z", "")]
		public unsafe bool HtmlSafe()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("htmlSafe.()Z", this, null);
		}

		[Register("newBuilder", "()Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder NewBuilder()
		{
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("newBuilder.()Lcom/google/gson/GsonBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("newJsonReader", "(Ljava/io/Reader;)Lcom/google/gson/stream/JsonReader;", "")]
		public unsafe JsonReader NewJsonReader(Reader reader)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reader?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<JsonReader>(_members.InstanceMethods.InvokeAbstractObjectMethod("newJsonReader.(Ljava/io/Reader;)Lcom/google/gson/stream/JsonReader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(reader);
			}
		}

		[Register("newJsonWriter", "(Ljava/io/Writer;)Lcom/google/gson/stream/JsonWriter;", "")]
		public unsafe JsonWriter NewJsonWriter(Writer writer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(writer?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeAbstractObjectMethod("newJsonWriter.(Ljava/io/Writer;)Lcom/google/gson/stream/JsonWriter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(writer);
			}
		}

		[Register("serializeNulls", "()Z", "")]
		public unsafe bool SerializeNulls()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("serializeNulls.()Z", this, null);
		}

		[Register("toJson", "(Lcom/google/gson/JsonElement;)Ljava/lang/String;", "")]
		public unsafe string ToJson(JsonElement jsonElement)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(jsonElement?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toJson.(Lcom/google/gson/JsonElement;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(jsonElement);
			}
		}

		[Register("toJson", "(Lcom/google/gson/JsonElement;Lcom/google/gson/stream/JsonWriter;)V", "")]
		public unsafe void ToJson(JsonElement jsonElement, JsonWriter writer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(jsonElement?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(writer?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("toJson.(Lcom/google/gson/JsonElement;Lcom/google/gson/stream/JsonWriter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(jsonElement);
				GC.KeepAlive(writer);
			}
		}

		[Register("toJson", "(Lcom/google/gson/JsonElement;Ljava/lang/Appendable;)V", "")]
		public unsafe void ToJson(JsonElement jsonElement, IAppendable writer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(jsonElement?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((writer == null) ? IntPtr.Zero : ((Java.Lang.Object)writer).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("toJson.(Lcom/google/gson/JsonElement;Ljava/lang/Appendable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(jsonElement);
				GC.KeepAlive(writer);
			}
		}

		[Register("toJson", "(Ljava/lang/Object;)Ljava/lang/String;", "")]
		public unsafe string ToJson(Java.Lang.Object src)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toJson.(Ljava/lang/Object;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(src);
			}
		}

		[Register("toJson", "(Ljava/lang/Object;Ljava/lang/Appendable;)V", "")]
		public unsafe void ToJson(Java.Lang.Object src, IAppendable writer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((writer == null) ? IntPtr.Zero : ((Java.Lang.Object)writer).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("toJson.(Ljava/lang/Object;Ljava/lang/Appendable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(src);
				GC.KeepAlive(writer);
			}
		}

		[Register("toJson", "(Ljava/lang/Object;Ljava/lang/reflect/Type;)Ljava/lang/String;", "")]
		public unsafe string ToJson(Java.Lang.Object src, IType typeOfSrc)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((typeOfSrc == null) ? IntPtr.Zero : ((Java.Lang.Object)typeOfSrc).Handle);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toJson.(Ljava/lang/Object;Ljava/lang/reflect/Type;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(src);
				GC.KeepAlive(typeOfSrc);
			}
		}

		[Register("toJson", "(Ljava/lang/Object;Ljava/lang/reflect/Type;Lcom/google/gson/stream/JsonWriter;)V", "")]
		public unsafe void ToJson(Java.Lang.Object src, IType typeOfSrc, JsonWriter writer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((typeOfSrc == null) ? IntPtr.Zero : ((Java.Lang.Object)typeOfSrc).Handle);
				ptr[2] = new JniArgumentValue(writer?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("toJson.(Ljava/lang/Object;Ljava/lang/reflect/Type;Lcom/google/gson/stream/JsonWriter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(src);
				GC.KeepAlive(typeOfSrc);
				GC.KeepAlive(writer);
			}
		}

		[Register("toJson", "(Ljava/lang/Object;Ljava/lang/reflect/Type;Ljava/lang/Appendable;)V", "")]
		public unsafe void ToJson(Java.Lang.Object src, IType typeOfSrc, IAppendable writer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((typeOfSrc == null) ? IntPtr.Zero : ((Java.Lang.Object)typeOfSrc).Handle);
				ptr[2] = new JniArgumentValue((writer == null) ? IntPtr.Zero : ((Java.Lang.Object)writer).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("toJson.(Ljava/lang/Object;Ljava/lang/reflect/Type;Ljava/lang/Appendable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(src);
				GC.KeepAlive(typeOfSrc);
				GC.KeepAlive(writer);
			}
		}

		[Register("toJsonTree", "(Ljava/lang/Object;)Lcom/google/gson/JsonElement;", "")]
		public unsafe JsonElement ToJsonTree(Java.Lang.Object src)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("toJsonTree.(Ljava/lang/Object;)Lcom/google/gson/JsonElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(src);
			}
		}

		[Register("toJsonTree", "(Ljava/lang/Object;Ljava/lang/reflect/Type;)Lcom/google/gson/JsonElement;", "")]
		public unsafe JsonElement ToJsonTree(Java.Lang.Object src, IType typeOfSrc)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((typeOfSrc == null) ? IntPtr.Zero : ((Java.Lang.Object)typeOfSrc).Handle);
				return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("toJsonTree.(Ljava/lang/Object;Ljava/lang/reflect/Type;)Lcom/google/gson/JsonElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(src);
				GC.KeepAlive(typeOfSrc);
			}
		}
	}
	[Register("com/google/gson/GsonBuilder", DoNotGenerateAcw = true)]
	public sealed class GsonBuilder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/GsonBuilder", typeof(GsonBuilder));

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

		internal GsonBuilder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GsonBuilder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("addDeserializationExclusionStrategy", "(Lcom/google/gson/ExclusionStrategy;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder AddDeserializationExclusionStrategy(IExclusionStrategy strategy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((strategy == null) ? IntPtr.Zero : ((Java.Lang.Object)strategy).Handle);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addDeserializationExclusionStrategy.(Lcom/google/gson/ExclusionStrategy;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(strategy);
			}
		}

		[Register("addSerializationExclusionStrategy", "(Lcom/google/gson/ExclusionStrategy;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder AddSerializationExclusionStrategy(IExclusionStrategy strategy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((strategy == null) ? IntPtr.Zero : ((Java.Lang.Object)strategy).Handle);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addSerializationExclusionStrategy.(Lcom/google/gson/ExclusionStrategy;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(strategy);
			}
		}

		[Register("create", "()Lcom/google/gson/Gson;", "")]
		public unsafe Gson Create()
		{
			return Java.Lang.Object.GetObject<Gson>(_members.InstanceMethods.InvokeAbstractObjectMethod("create.()Lcom/google/gson/Gson;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("disableHtmlEscaping", "()Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder DisableHtmlEscaping()
		{
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("disableHtmlEscaping.()Lcom/google/gson/GsonBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("disableInnerClassSerialization", "()Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder DisableInnerClassSerialization()
		{
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("disableInnerClassSerialization.()Lcom/google/gson/GsonBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("enableComplexMapKeySerialization", "()Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder EnableComplexMapKeySerialization()
		{
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableComplexMapKeySerialization.()Lcom/google/gson/GsonBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("excludeFieldsWithModifiers", "([I)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder ExcludeFieldsWithModifiers(params int[] modifiers)
		{
			IntPtr intPtr = JNIEnv.NewArray(modifiers);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("excludeFieldsWithModifiers.([I)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (modifiers != null)
				{
					JNIEnv.CopyArray(intPtr, modifiers);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(modifiers);
			}
		}

		[Register("excludeFieldsWithoutExposeAnnotation", "()Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder ExcludeFieldsWithoutExposeAnnotation()
		{
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("excludeFieldsWithoutExposeAnnotation.()Lcom/google/gson/GsonBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("generateNonExecutableJson", "()Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder GenerateNonExecutableJson()
		{
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("generateNonExecutableJson.()Lcom/google/gson/GsonBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("registerTypeAdapter", "(Ljava/lang/reflect/Type;Ljava/lang/Object;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder RegisterTypeAdapter(IType type, Java.Lang.Object typeAdapter)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				ptr[1] = new JniArgumentValue(typeAdapter?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("registerTypeAdapter.(Ljava/lang/reflect/Type;Ljava/lang/Object;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
				GC.KeepAlive(typeAdapter);
			}
		}

		[Register("registerTypeAdapterFactory", "(Lcom/google/gson/TypeAdapterFactory;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder RegisterTypeAdapterFactory(ITypeAdapterFactory factory)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("registerTypeAdapterFactory.(Lcom/google/gson/TypeAdapterFactory;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(factory);
			}
		}

		[Register("registerTypeHierarchyAdapter", "(Ljava/lang/Class;Ljava/lang/Object;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder RegisterTypeHierarchyAdapter(Class baseType, Java.Lang.Object typeAdapter)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(baseType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(typeAdapter?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("registerTypeHierarchyAdapter.(Ljava/lang/Class;Ljava/lang/Object;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(baseType);
				GC.KeepAlive(typeAdapter);
			}
		}

		[Register("serializeNulls", "()Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SerializeNulls()
		{
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("serializeNulls.()Lcom/google/gson/GsonBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("serializeSpecialFloatingPointValues", "()Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SerializeSpecialFloatingPointValues()
		{
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("serializeSpecialFloatingPointValues.()Lcom/google/gson/GsonBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setDateFormat", "(I)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetDateFormat(int style)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(style);
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDateFormat.(I)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setDateFormat", "(II)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetDateFormat(int dateStyle, int timeStyle)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dateStyle);
			ptr[1] = new JniArgumentValue(timeStyle);
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDateFormat.(II)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setDateFormat", "(Ljava/lang/String;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetDateFormat(string pattern)
		{
			IntPtr intPtr = JNIEnv.NewString(pattern);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDateFormat.(Ljava/lang/String;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setExclusionStrategies", "([Lcom/google/gson/ExclusionStrategy;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetExclusionStrategies(params IExclusionStrategy[] strategies)
		{
			IntPtr intPtr = JNIEnv.NewArray(strategies);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExclusionStrategies.([Lcom/google/gson/ExclusionStrategy;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (strategies != null)
				{
					JNIEnv.CopyArray(intPtr, strategies);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(strategies);
			}
		}

		[Register("setFieldNamingPolicy", "(Lcom/google/gson/FieldNamingPolicy;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetFieldNamingPolicy(FieldNamingPolicy namingConvention)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(namingConvention?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setFieldNamingPolicy.(Lcom/google/gson/FieldNamingPolicy;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(namingConvention);
			}
		}

		[Register("setFieldNamingStrategy", "(Lcom/google/gson/FieldNamingStrategy;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetFieldNamingStrategy(IFieldNamingStrategy fieldNamingStrategy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((fieldNamingStrategy == null) ? IntPtr.Zero : ((Java.Lang.Object)fieldNamingStrategy).Handle);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setFieldNamingStrategy.(Lcom/google/gson/FieldNamingStrategy;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(fieldNamingStrategy);
			}
		}

		[Register("setLenient", "()Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetLenient()
		{
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLenient.()Lcom/google/gson/GsonBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setLongSerializationPolicy", "(Lcom/google/gson/LongSerializationPolicy;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetLongSerializationPolicy(LongSerializationPolicy serializationPolicy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(serializationPolicy?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLongSerializationPolicy.(Lcom/google/gson/LongSerializationPolicy;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(serializationPolicy);
			}
		}

		[Register("setNumberToNumberStrategy", "(Lcom/google/gson/ToNumberStrategy;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetNumberToNumberStrategy(IToNumberStrategy numberToNumberStrategy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((numberToNumberStrategy == null) ? IntPtr.Zero : ((Java.Lang.Object)numberToNumberStrategy).Handle);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNumberToNumberStrategy.(Lcom/google/gson/ToNumberStrategy;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(numberToNumberStrategy);
			}
		}

		[Register("setObjectToNumberStrategy", "(Lcom/google/gson/ToNumberStrategy;)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetObjectToNumberStrategy(IToNumberStrategy objectToNumberStrategy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((objectToNumberStrategy == null) ? IntPtr.Zero : ((Java.Lang.Object)objectToNumberStrategy).Handle);
				return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setObjectToNumberStrategy.(Lcom/google/gson/ToNumberStrategy;)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(objectToNumberStrategy);
			}
		}

		[Register("setPrettyPrinting", "()Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetPrettyPrinting()
		{
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPrettyPrinting.()Lcom/google/gson/GsonBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setVersion", "(D)Lcom/google/gson/GsonBuilder;", "")]
		public unsafe GsonBuilder SetVersion(double ignoreVersionsAfter)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ignoreVersionsAfter);
			return Java.Lang.Object.GetObject<GsonBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setVersion.(D)Lcom/google/gson/GsonBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/ExclusionStrategy", "", "GoogleGson.IExclusionStrategyInvoker")]
	public interface IExclusionStrategy : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("shouldSkipClass", "(Ljava/lang/Class;)Z", "GetShouldSkipClass_Ljava_lang_Class_Handler:GoogleGson.IExclusionStrategyInvoker, GoogleGson")]
		bool ShouldSkipClass(Class p0);

		[Register("shouldSkipField", "(Lcom/google/gson/FieldAttributes;)Z", "GetShouldSkipField_Lcom_google_gson_FieldAttributes_Handler:GoogleGson.IExclusionStrategyInvoker, GoogleGson")]
		bool ShouldSkipField(FieldAttributes p0);
	}
	[Register("com/google/gson/ExclusionStrategy", DoNotGenerateAcw = true)]
	internal class IExclusionStrategyInvoker : Java.Lang.Object, IExclusionStrategy, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/ExclusionStrategy", typeof(IExclusionStrategyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_shouldSkipClass_Ljava_lang_Class_;

		private IntPtr id_shouldSkipClass_Ljava_lang_Class_;

		private static Delegate cb_shouldSkipField_Lcom_google_gson_FieldAttributes_;

		private IntPtr id_shouldSkipField_Lcom_google_gson_FieldAttributes_;

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

		public static IExclusionStrategy GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IExclusionStrategy>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.ExclusionStrategy'.");
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

		public IExclusionStrategyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetShouldSkipClass_Ljava_lang_Class_Handler()
		{
			if ((object)cb_shouldSkipClass_Ljava_lang_Class_ == null)
			{
				cb_shouldSkipClass_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ShouldSkipClass_Ljava_lang_Class_));
			}
			return cb_shouldSkipClass_Ljava_lang_Class_;
		}

		private static bool n_ShouldSkipClass_Ljava_lang_Class_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IExclusionStrategy exclusionStrategy = Java.Lang.Object.GetObject<IExclusionStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class p = Java.Lang.Object.GetObject<Class>(native_p0, JniHandleOwnership.DoNotTransfer);
			return exclusionStrategy.ShouldSkipClass(p);
		}

		public unsafe bool ShouldSkipClass(Class p0)
		{
			if (id_shouldSkipClass_Ljava_lang_Class_ == IntPtr.Zero)
			{
				id_shouldSkipClass_Ljava_lang_Class_ = JNIEnv.GetMethodID(class_ref, "shouldSkipClass", "(Ljava/lang/Class;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_shouldSkipClass_Ljava_lang_Class_, ptr);
		}

		private static Delegate GetShouldSkipField_Lcom_google_gson_FieldAttributes_Handler()
		{
			if ((object)cb_shouldSkipField_Lcom_google_gson_FieldAttributes_ == null)
			{
				cb_shouldSkipField_Lcom_google_gson_FieldAttributes_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ShouldSkipField_Lcom_google_gson_FieldAttributes_));
			}
			return cb_shouldSkipField_Lcom_google_gson_FieldAttributes_;
		}

		private static bool n_ShouldSkipField_Lcom_google_gson_FieldAttributes_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IExclusionStrategy exclusionStrategy = Java.Lang.Object.GetObject<IExclusionStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FieldAttributes p = Java.Lang.Object.GetObject<FieldAttributes>(native_p0, JniHandleOwnership.DoNotTransfer);
			return exclusionStrategy.ShouldSkipField(p);
		}

		public unsafe bool ShouldSkipField(FieldAttributes p0)
		{
			if (id_shouldSkipField_Lcom_google_gson_FieldAttributes_ == IntPtr.Zero)
			{
				id_shouldSkipField_Lcom_google_gson_FieldAttributes_ = JNIEnv.GetMethodID(class_ref, "shouldSkipField", "(Lcom/google/gson/FieldAttributes;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_shouldSkipField_Lcom_google_gson_FieldAttributes_, ptr);
		}
	}
	[Register("com/google/gson/FieldNamingStrategy", "", "GoogleGson.IFieldNamingStrategyInvoker")]
	public interface IFieldNamingStrategy : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("translateName", "(Ljava/lang/reflect/Field;)Ljava/lang/String;", "GetTranslateName_Ljava_lang_reflect_Field_Handler:GoogleGson.IFieldNamingStrategyInvoker, GoogleGson")]
		string TranslateName(Field p0);
	}
	[Register("com/google/gson/FieldNamingStrategy", DoNotGenerateAcw = true)]
	internal class IFieldNamingStrategyInvoker : Java.Lang.Object, IFieldNamingStrategy, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/FieldNamingStrategy", typeof(IFieldNamingStrategyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_translateName_Ljava_lang_reflect_Field_;

		private IntPtr id_translateName_Ljava_lang_reflect_Field_;

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

		public static IFieldNamingStrategy GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFieldNamingStrategy>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.FieldNamingStrategy'.");
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

		public IFieldNamingStrategyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetTranslateName_Ljava_lang_reflect_Field_Handler()
		{
			if ((object)cb_translateName_Ljava_lang_reflect_Field_ == null)
			{
				cb_translateName_Ljava_lang_reflect_Field_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_TranslateName_Ljava_lang_reflect_Field_));
			}
			return cb_translateName_Ljava_lang_reflect_Field_;
		}

		private static IntPtr n_TranslateName_Ljava_lang_reflect_Field_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IFieldNamingStrategy fieldNamingStrategy = Java.Lang.Object.GetObject<IFieldNamingStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Field p = Java.Lang.Object.GetObject<Field>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(fieldNamingStrategy.TranslateName(p));
		}

		public unsafe string TranslateName(Field p0)
		{
			if (id_translateName_Ljava_lang_reflect_Field_ == IntPtr.Zero)
			{
				id_translateName_Ljava_lang_reflect_Field_ = JNIEnv.GetMethodID(class_ref, "translateName", "(Ljava/lang/reflect/Field;)Ljava/lang/String;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_translateName_Ljava_lang_reflect_Field_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/InstanceCreator", "", "GoogleGson.IInstanceCreatorInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IInstanceCreator : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("createInstance", "(Ljava/lang/reflect/Type;)Ljava/lang/Object;", "GetCreateInstance_Ljava_lang_reflect_Type_Handler:GoogleGson.IInstanceCreatorInvoker, GoogleGson")]
		Java.Lang.Object CreateInstance(IType p0);
	}
	[Register("com/google/gson/InstanceCreator", DoNotGenerateAcw = true)]
	internal class IInstanceCreatorInvoker : Java.Lang.Object, IInstanceCreator, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/InstanceCreator", typeof(IInstanceCreatorInvoker));

		private IntPtr class_ref;

		private static Delegate cb_createInstance_Ljava_lang_reflect_Type_;

		private IntPtr id_createInstance_Ljava_lang_reflect_Type_;

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

		public static IInstanceCreator GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IInstanceCreator>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.InstanceCreator'.");
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

		public IInstanceCreatorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCreateInstance_Ljava_lang_reflect_Type_Handler()
		{
			if ((object)cb_createInstance_Ljava_lang_reflect_Type_ == null)
			{
				cb_createInstance_Ljava_lang_reflect_Type_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateInstance_Ljava_lang_reflect_Type_));
			}
			return cb_createInstance_Ljava_lang_reflect_Type_;
		}

		private static IntPtr n_CreateInstance_Ljava_lang_reflect_Type_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IInstanceCreator instanceCreator = Java.Lang.Object.GetObject<IInstanceCreator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IType p = Java.Lang.Object.GetObject<IType>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(instanceCreator.CreateInstance(p));
		}

		public unsafe Java.Lang.Object CreateInstance(IType p0)
		{
			if (id_createInstance_Ljava_lang_reflect_Type_ == IntPtr.Zero)
			{
				id_createInstance_Ljava_lang_reflect_Type_ = JNIEnv.GetMethodID(class_ref, "createInstance", "(Ljava/lang/reflect/Type;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_createInstance_Ljava_lang_reflect_Type_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/JsonDeserializationContext", "", "GoogleGson.IJsonDeserializationContextInvoker")]
	public interface IJsonDeserializationContext : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("deserialize", "(Lcom/google/gson/JsonElement;Ljava/lang/reflect/Type;)Ljava/lang/Object;", "GetDeserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Handler:GoogleGson.IJsonDeserializationContextInvoker, GoogleGson")]
		[JavaTypeParameters(new string[] { "T" })]
		Java.Lang.Object Deserialize(JsonElement p0, IType p1);
	}
	[Register("com/google/gson/JsonDeserializationContext", DoNotGenerateAcw = true)]
	internal class IJsonDeserializationContextInvoker : Java.Lang.Object, IJsonDeserializationContext, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonDeserializationContext", typeof(IJsonDeserializationContextInvoker));

		private IntPtr class_ref;

		private static Delegate cb_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_;

		private IntPtr id_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_;

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

		public static IJsonDeserializationContext GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IJsonDeserializationContext>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.JsonDeserializationContext'.");
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

		public IJsonDeserializationContextInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDeserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Handler()
		{
			if ((object)cb_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_ == null)
			{
				cb_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_));
			}
			return cb_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_;
		}

		private static IntPtr n_Deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IJsonDeserializationContext jsonDeserializationContext = Java.Lang.Object.GetObject<IJsonDeserializationContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JsonElement p = Java.Lang.Object.GetObject<JsonElement>(native_p0, JniHandleOwnership.DoNotTransfer);
			IType p2 = Java.Lang.Object.GetObject<IType>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jsonDeserializationContext.Deserialize(p, p2));
		}

		public unsafe Java.Lang.Object Deserialize(JsonElement p0, IType p1)
		{
			if (id_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_ == IntPtr.Zero)
			{
				id_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_ = JNIEnv.GetMethodID(class_ref, "deserialize", "(Lcom/google/gson/JsonElement;Ljava/lang/reflect/Type;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/JsonDeserializer", "", "GoogleGson.IJsonDeserializerInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IJsonDeserializer : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("deserialize", "(Lcom/google/gson/JsonElement;Ljava/lang/reflect/Type;Lcom/google/gson/JsonDeserializationContext;)Ljava/lang/Object;", "GetDeserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_Handler:GoogleGson.IJsonDeserializerInvoker, GoogleGson")]
		Java.Lang.Object Deserialize(JsonElement p0, IType p1, IJsonDeserializationContext p2);
	}
	[Register("com/google/gson/JsonDeserializer", DoNotGenerateAcw = true)]
	internal class IJsonDeserializerInvoker : Java.Lang.Object, IJsonDeserializer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonDeserializer", typeof(IJsonDeserializerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_;

		private IntPtr id_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_;

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

		public static IJsonDeserializer GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IJsonDeserializer>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.JsonDeserializer'.");
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

		public IJsonDeserializerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDeserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_Handler()
		{
			if ((object)cb_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_ == null)
			{
				cb_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_Deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_));
			}
			return cb_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_;
		}

		private static IntPtr n_Deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IJsonDeserializer jsonDeserializer = Java.Lang.Object.GetObject<IJsonDeserializer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JsonElement p = Java.Lang.Object.GetObject<JsonElement>(native_p0, JniHandleOwnership.DoNotTransfer);
			IType p2 = Java.Lang.Object.GetObject<IType>(native_p1, JniHandleOwnership.DoNotTransfer);
			IJsonDeserializationContext p3 = Java.Lang.Object.GetObject<IJsonDeserializationContext>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jsonDeserializer.Deserialize(p, p2, p3));
		}

		public unsafe Java.Lang.Object Deserialize(JsonElement p0, IType p1, IJsonDeserializationContext p2)
		{
			if (id_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_ == IntPtr.Zero)
			{
				id_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_ = JNIEnv.GetMethodID(class_ref, "deserialize", "(Lcom/google/gson/JsonElement;Ljava/lang/reflect/Type;Lcom/google/gson/JsonDeserializationContext;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_deserialize_Lcom_google_gson_JsonElement_Ljava_lang_reflect_Type_Lcom_google_gson_JsonDeserializationContext_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/JsonSerializationContext", "", "GoogleGson.IJsonSerializationContextInvoker")]
	public interface IJsonSerializationContext : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("serialize", "(Ljava/lang/Object;)Lcom/google/gson/JsonElement;", "GetSerialize_Ljava_lang_Object_Handler:GoogleGson.IJsonSerializationContextInvoker, GoogleGson")]
		JsonElement Serialize(Java.Lang.Object p0);

		[Register("serialize", "(Ljava/lang/Object;Ljava/lang/reflect/Type;)Lcom/google/gson/JsonElement;", "GetSerialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Handler:GoogleGson.IJsonSerializationContextInvoker, GoogleGson")]
		JsonElement Serialize(Java.Lang.Object p0, IType p1);
	}
	[Register("com/google/gson/JsonSerializationContext", DoNotGenerateAcw = true)]
	internal class IJsonSerializationContextInvoker : Java.Lang.Object, IJsonSerializationContext, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonSerializationContext", typeof(IJsonSerializationContextInvoker));

		private IntPtr class_ref;

		private static Delegate cb_serialize_Ljava_lang_Object_;

		private IntPtr id_serialize_Ljava_lang_Object_;

		private static Delegate cb_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_;

		private IntPtr id_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_;

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

		public static IJsonSerializationContext GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IJsonSerializationContext>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.JsonSerializationContext'.");
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

		public IJsonSerializationContextInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetSerialize_Ljava_lang_Object_Handler()
		{
			if ((object)cb_serialize_Ljava_lang_Object_ == null)
			{
				cb_serialize_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Serialize_Ljava_lang_Object_));
			}
			return cb_serialize_Ljava_lang_Object_;
		}

		private static IntPtr n_Serialize_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IJsonSerializationContext jsonSerializationContext = Java.Lang.Object.GetObject<IJsonSerializationContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jsonSerializationContext.Serialize(p));
		}

		public unsafe JsonElement Serialize(Java.Lang.Object p0)
		{
			if (id_serialize_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_serialize_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "serialize", "(Ljava/lang/Object;)Lcom/google/gson/JsonElement;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<JsonElement>(JNIEnv.CallObjectMethod(base.Handle, id_serialize_Ljava_lang_Object_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSerialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Handler()
		{
			if ((object)cb_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_ == null)
			{
				cb_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_));
			}
			return cb_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_;
		}

		private static IntPtr n_Serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IJsonSerializationContext jsonSerializationContext = Java.Lang.Object.GetObject<IJsonSerializationContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			IType p2 = Java.Lang.Object.GetObject<IType>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jsonSerializationContext.Serialize(p, p2));
		}

		public unsafe JsonElement Serialize(Java.Lang.Object p0, IType p1)
		{
			if (id_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_ == IntPtr.Zero)
			{
				id_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_ = JNIEnv.GetMethodID(class_ref, "serialize", "(Ljava/lang/Object;Ljava/lang/reflect/Type;)Lcom/google/gson/JsonElement;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<JsonElement>(JNIEnv.CallObjectMethod(base.Handle, id_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/JsonSerializer", "", "GoogleGson.IJsonSerializerInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IJsonSerializer : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("serialize", "(Ljava/lang/Object;Ljava/lang/reflect/Type;Lcom/google/gson/JsonSerializationContext;)Lcom/google/gson/JsonElement;", "GetSerialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_Handler:GoogleGson.IJsonSerializerInvoker, GoogleGson")]
		JsonElement Serialize(Java.Lang.Object p0, IType p1, IJsonSerializationContext p2);
	}
	[Register("com/google/gson/JsonSerializer", DoNotGenerateAcw = true)]
	internal class IJsonSerializerInvoker : Java.Lang.Object, IJsonSerializer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonSerializer", typeof(IJsonSerializerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_;

		private IntPtr id_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_;

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

		public static IJsonSerializer GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IJsonSerializer>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.JsonSerializer'.");
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

		public IJsonSerializerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetSerialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_Handler()
		{
			if ((object)cb_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_ == null)
			{
				cb_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_Serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_));
			}
			return cb_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_;
		}

		private static IntPtr n_Serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IJsonSerializer jsonSerializer = Java.Lang.Object.GetObject<IJsonSerializer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			IType p2 = Java.Lang.Object.GetObject<IType>(native_p1, JniHandleOwnership.DoNotTransfer);
			IJsonSerializationContext p3 = Java.Lang.Object.GetObject<IJsonSerializationContext>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jsonSerializer.Serialize(p, p2, p3));
		}

		public unsafe JsonElement Serialize(Java.Lang.Object p0, IType p1, IJsonSerializationContext p2)
		{
			if (id_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_ == IntPtr.Zero)
			{
				id_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_ = JNIEnv.GetMethodID(class_ref, "serialize", "(Ljava/lang/Object;Ljava/lang/reflect/Type;Lcom/google/gson/JsonSerializationContext;)Lcom/google/gson/JsonElement;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			JsonElement result = Java.Lang.Object.GetObject<JsonElement>(JNIEnv.CallObjectMethod(base.Handle, id_serialize_Ljava_lang_Object_Ljava_lang_reflect_Type_Lcom_google_gson_JsonSerializationContext_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}
	}
	[Register("com/google/gson/ToNumberStrategy", "", "GoogleGson.IToNumberStrategyInvoker")]
	public interface IToNumberStrategy : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("readNumber", "(Lcom/google/gson/stream/JsonReader;)Ljava/lang/Number;", "GetReadNumber_Lcom_google_gson_stream_JsonReader_Handler:GoogleGson.IToNumberStrategyInvoker, GoogleGson")]
		Number ReadNumber(JsonReader p0);
	}
	[Register("com/google/gson/ToNumberStrategy", DoNotGenerateAcw = true)]
	internal class IToNumberStrategyInvoker : Java.Lang.Object, IToNumberStrategy, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/ToNumberStrategy", typeof(IToNumberStrategyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_readNumber_Lcom_google_gson_stream_JsonReader_;

		private IntPtr id_readNumber_Lcom_google_gson_stream_JsonReader_;

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

		public static IToNumberStrategy GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IToNumberStrategy>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.ToNumberStrategy'.");
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

		public IToNumberStrategyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetReadNumber_Lcom_google_gson_stream_JsonReader_Handler()
		{
			if ((object)cb_readNumber_Lcom_google_gson_stream_JsonReader_ == null)
			{
				cb_readNumber_Lcom_google_gson_stream_JsonReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadNumber_Lcom_google_gson_stream_JsonReader_));
			}
			return cb_readNumber_Lcom_google_gson_stream_JsonReader_;
		}

		private static IntPtr n_ReadNumber_Lcom_google_gson_stream_JsonReader_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IToNumberStrategy toNumberStrategy = Java.Lang.Object.GetObject<IToNumberStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JsonReader p = Java.Lang.Object.GetObject<JsonReader>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(toNumberStrategy.ReadNumber(p));
		}

		public unsafe Number ReadNumber(JsonReader p0)
		{
			if (id_readNumber_Lcom_google_gson_stream_JsonReader_ == IntPtr.Zero)
			{
				id_readNumber_Lcom_google_gson_stream_JsonReader_ = JNIEnv.GetMethodID(class_ref, "readNumber", "(Lcom/google/gson/stream/JsonReader;)Ljava/lang/Number;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Number>(JNIEnv.CallObjectMethod(base.Handle, id_readNumber_Lcom_google_gson_stream_JsonReader_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/TypeAdapterFactory", "", "GoogleGson.ITypeAdapterFactoryInvoker")]
	public interface ITypeAdapterFactory : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("create", "(Lcom/google/gson/Gson;Lcom/google/gson/reflect/TypeToken;)Lcom/google/gson/TypeAdapter;", "GetCreate_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_Handler:GoogleGson.ITypeAdapterFactoryInvoker, GoogleGson")]
		[JavaTypeParameters(new string[] { "T" })]
		TypeAdapter Create(Gson p0, TypeToken p1);
	}
	[Register("com/google/gson/TypeAdapterFactory", DoNotGenerateAcw = true)]
	internal class ITypeAdapterFactoryInvoker : Java.Lang.Object, ITypeAdapterFactory, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/TypeAdapterFactory", typeof(ITypeAdapterFactoryInvoker));

		private IntPtr class_ref;

		private static Delegate cb_create_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_;

		private IntPtr id_create_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_;

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

		public static ITypeAdapterFactory GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITypeAdapterFactory>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.TypeAdapterFactory'.");
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

		public ITypeAdapterFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCreate_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_Handler()
		{
			if ((object)cb_create_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_ == null)
			{
				cb_create_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Create_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_));
			}
			return cb_create_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_;
		}

		private static IntPtr n_Create_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ITypeAdapterFactory typeAdapterFactory = Java.Lang.Object.GetObject<ITypeAdapterFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Gson p = Java.Lang.Object.GetObject<Gson>(native_p0, JniHandleOwnership.DoNotTransfer);
			TypeToken p2 = Java.Lang.Object.GetObject<TypeToken>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(typeAdapterFactory.Create(p, p2));
		}

		public unsafe TypeAdapter Create(Gson p0, TypeToken p1)
		{
			if (id_create_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_ == IntPtr.Zero)
			{
				id_create_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_ = JNIEnv.GetMethodID(class_ref, "create", "(Lcom/google/gson/Gson;Lcom/google/gson/reflect/TypeToken;)Lcom/google/gson/TypeAdapter;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<TypeAdapter>(JNIEnv.CallObjectMethod(base.Handle, id_create_Lcom_google_gson_Gson_Lcom_google_gson_reflect_TypeToken_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/JsonArray", DoNotGenerateAcw = true)]
	public sealed class JsonArray : JsonElement, IIterable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonArray", typeof(JsonArray));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsEmpty
		{
			[Register("isEmpty", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);
			}
		}

		internal JsonArray(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe JsonArray()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe JsonArray(int capacity)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(capacity);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		[Register("add", "(Lcom/google/gson/JsonElement;)V", "")]
		public unsafe void Add(JsonElement element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("add.(Lcom/google/gson/JsonElement;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		[Register("add", "(Ljava/lang/Boolean;)V", "")]
		public unsafe void Add(Java.Lang.Boolean @bool)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@bool?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("add.(Ljava/lang/Boolean;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@bool);
			}
		}

		[Register("add", "(Ljava/lang/Character;)V", "")]
		public unsafe void Add(Character character)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(character?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("add.(Ljava/lang/Character;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(character);
			}
		}

		[Register("add", "(Ljava/lang/Number;)V", "")]
		public unsafe void Add(Number number)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(number?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("add.(Ljava/lang/Number;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(number);
			}
		}

		[Register("add", "(Ljava/lang/String;)V", "")]
		public unsafe void Add(string @string)
		{
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("add.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("addAll", "(Lcom/google/gson/JsonArray;)V", "")]
		public unsafe void AddAll(JsonArray array)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(array?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addAll.(Lcom/google/gson/JsonArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(array);
			}
		}

		[Register("contains", "(Lcom/google/gson/JsonElement;)Z", "")]
		public unsafe bool Contains(JsonElement element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("contains.(Lcom/google/gson/JsonElement;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		[Register("deepCopy", "()Lcom/google/gson/JsonArray;", "")]
		public unsafe override JsonElement DeepCopy()
		{
			return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("deepCopy.()Lcom/google/gson/JsonArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("get", "(I)Lcom/google/gson/JsonElement;", "")]
		public unsafe JsonElement Get(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("get.(I)Lcom/google/gson/JsonElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("iterator", "()Ljava/util/Iterator;", "")]
		public unsafe IIterator Iterator()
		{
			return Java.Lang.Object.GetObject<IIterator>(_members.InstanceMethods.InvokeAbstractObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("remove", "(Lcom/google/gson/JsonElement;)Z", "")]
		public unsafe bool Remove(JsonElement element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("remove.(Lcom/google/gson/JsonElement;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		[Register("remove", "(I)Lcom/google/gson/JsonElement;", "")]
		public unsafe JsonElement Remove(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("remove.(I)Lcom/google/gson/JsonElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("set", "(ILcom/google/gson/JsonElement;)Lcom/google/gson/JsonElement;", "")]
		public unsafe JsonElement Set(int index, JsonElement element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(index);
				ptr[1] = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("set.(ILcom/google/gson/JsonElement;)Lcom/google/gson/JsonElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		[Register("size", "()I", "")]
		public unsafe int Size()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);
		}
	}
	[Register("com/google/gson/JsonElement", DoNotGenerateAcw = true)]
	public abstract class JsonElement : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonElement", typeof(JsonElement));

		private static Delegate cb_getAsBigDecimal;

		private static Delegate cb_getAsBigInteger;

		private static Delegate cb_getAsBoolean;

		private static Delegate cb_getAsByte;

		private static Delegate cb_getAsDouble;

		private static Delegate cb_getAsFloat;

		private static Delegate cb_getAsInt;

		private static Delegate cb_getAsJsonArray;

		private static Delegate cb_getAsJsonNull;

		private static Delegate cb_getAsJsonObject;

		private static Delegate cb_getAsJsonPrimitive;

		private static Delegate cb_getAsLong;

		private static Delegate cb_getAsNumber;

		private static Delegate cb_getAsShort;

		private static Delegate cb_getAsString;

		private static Delegate cb_isJsonArray;

		private static Delegate cb_isJsonNull;

		private static Delegate cb_isJsonObject;

		private static Delegate cb_isJsonPrimitive;

		private static Delegate cb_deepCopy;

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

		public unsafe virtual BigDecimal AsBigDecimal
		{
			[Register("getAsBigDecimal", "()Ljava/math/BigDecimal;", "GetGetAsBigDecimalHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BigDecimal>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAsBigDecimal.()Ljava/math/BigDecimal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual BigInteger AsBigInteger
		{
			[Register("getAsBigInteger", "()Ljava/math/BigInteger;", "GetGetAsBigIntegerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BigInteger>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAsBigInteger.()Ljava/math/BigInteger;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool AsBoolean
		{
			[Register("getAsBoolean", "()Z", "GetGetAsBooleanHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getAsBoolean.()Z", this, null);
			}
		}

		public unsafe virtual sbyte AsByte
		{
			[Register("getAsByte", "()B", "GetGetAsByteHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSByteMethod("getAsByte.()B", this, null);
			}
		}

		public unsafe virtual double AsDouble
		{
			[Register("getAsDouble", "()D", "GetGetAsDoubleHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualDoubleMethod("getAsDouble.()D", this, null);
			}
		}

		public unsafe virtual float AsFloat
		{
			[Register("getAsFloat", "()F", "GetGetAsFloatHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getAsFloat.()F", this, null);
			}
		}

		public unsafe virtual int AsInt
		{
			[Register("getAsInt", "()I", "GetGetAsIntHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getAsInt.()I", this, null);
			}
		}

		public unsafe virtual JsonArray AsJsonArray
		{
			[Register("getAsJsonArray", "()Lcom/google/gson/JsonArray;", "GetGetAsJsonArrayHandler")]
			get
			{
				return Java.Lang.Object.GetObject<JsonArray>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAsJsonArray.()Lcom/google/gson/JsonArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual JsonNull AsJsonNull
		{
			[Register("getAsJsonNull", "()Lcom/google/gson/JsonNull;", "GetGetAsJsonNullHandler")]
			get
			{
				return Java.Lang.Object.GetObject<JsonNull>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAsJsonNull.()Lcom/google/gson/JsonNull;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual JsonObject AsJsonObject
		{
			[Register("getAsJsonObject", "()Lcom/google/gson/JsonObject;", "GetGetAsJsonObjectHandler")]
			get
			{
				return Java.Lang.Object.GetObject<JsonObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAsJsonObject.()Lcom/google/gson/JsonObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual JsonPrimitive AsJsonPrimitive
		{
			[Register("getAsJsonPrimitive", "()Lcom/google/gson/JsonPrimitive;", "GetGetAsJsonPrimitiveHandler")]
			get
			{
				return Java.Lang.Object.GetObject<JsonPrimitive>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAsJsonPrimitive.()Lcom/google/gson/JsonPrimitive;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual long AsLong
		{
			[Register("getAsLong", "()J", "GetGetAsLongHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getAsLong.()J", this, null);
			}
		}

		public unsafe virtual Number AsNumber
		{
			[Register("getAsNumber", "()Ljava/lang/Number;", "GetGetAsNumberHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Number>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAsNumber.()Ljava/lang/Number;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual short AsShort
		{
			[Register("getAsShort", "()S", "GetGetAsShortHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt16Method("getAsShort.()S", this, null);
			}
		}

		public unsafe virtual string AsString
		{
			[Register("getAsString", "()Ljava/lang/String;", "GetGetAsStringHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getAsString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsJsonArray
		{
			[Register("isJsonArray", "()Z", "GetIsJsonArrayHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isJsonArray.()Z", this, null);
			}
		}

		public unsafe virtual bool IsJsonNull
		{
			[Register("isJsonNull", "()Z", "GetIsJsonNullHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isJsonNull.()Z", this, null);
			}
		}

		public unsafe virtual bool IsJsonObject
		{
			[Register("isJsonObject", "()Z", "GetIsJsonObjectHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isJsonObject.()Z", this, null);
			}
		}

		public unsafe virtual bool IsJsonPrimitive
		{
			[Register("isJsonPrimitive", "()Z", "GetIsJsonPrimitiveHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isJsonPrimitive.()Z", this, null);
			}
		}

		protected JsonElement(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe JsonElement()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetAsBigDecimalHandler()
		{
			if ((object)cb_getAsBigDecimal == null)
			{
				cb_getAsBigDecimal = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAsBigDecimal));
			}
			return cb_getAsBigDecimal;
		}

		private static IntPtr n_GetAsBigDecimal(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsBigDecimal);
		}

		private static Delegate GetGetAsBigIntegerHandler()
		{
			if ((object)cb_getAsBigInteger == null)
			{
				cb_getAsBigInteger = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAsBigInteger));
			}
			return cb_getAsBigInteger;
		}

		private static IntPtr n_GetAsBigInteger(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsBigInteger);
		}

		private static Delegate GetGetAsBooleanHandler()
		{
			if ((object)cb_getAsBoolean == null)
			{
				cb_getAsBoolean = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetAsBoolean));
			}
			return cb_getAsBoolean;
		}

		private static bool n_GetAsBoolean(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsBoolean;
		}

		private static Delegate GetGetAsByteHandler()
		{
			if ((object)cb_getAsByte == null)
			{
				cb_getAsByte = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_B(n_GetAsByte));
			}
			return cb_getAsByte;
		}

		private static sbyte n_GetAsByte(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsByte;
		}

		private static Delegate GetGetAsDoubleHandler()
		{
			if ((object)cb_getAsDouble == null)
			{
				cb_getAsDouble = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_GetAsDouble));
			}
			return cb_getAsDouble;
		}

		private static double n_GetAsDouble(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsDouble;
		}

		private static Delegate GetGetAsFloatHandler()
		{
			if ((object)cb_getAsFloat == null)
			{
				cb_getAsFloat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetAsFloat));
			}
			return cb_getAsFloat;
		}

		private static float n_GetAsFloat(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsFloat;
		}

		private static Delegate GetGetAsIntHandler()
		{
			if ((object)cb_getAsInt == null)
			{
				cb_getAsInt = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetAsInt));
			}
			return cb_getAsInt;
		}

		private static int n_GetAsInt(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsInt;
		}

		private static Delegate GetGetAsJsonArrayHandler()
		{
			if ((object)cb_getAsJsonArray == null)
			{
				cb_getAsJsonArray = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAsJsonArray));
			}
			return cb_getAsJsonArray;
		}

		private static IntPtr n_GetAsJsonArray(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsJsonArray);
		}

		private static Delegate GetGetAsJsonNullHandler()
		{
			if ((object)cb_getAsJsonNull == null)
			{
				cb_getAsJsonNull = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAsJsonNull));
			}
			return cb_getAsJsonNull;
		}

		private static IntPtr n_GetAsJsonNull(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsJsonNull);
		}

		private static Delegate GetGetAsJsonObjectHandler()
		{
			if ((object)cb_getAsJsonObject == null)
			{
				cb_getAsJsonObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAsJsonObject));
			}
			return cb_getAsJsonObject;
		}

		private static IntPtr n_GetAsJsonObject(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsJsonObject);
		}

		private static Delegate GetGetAsJsonPrimitiveHandler()
		{
			if ((object)cb_getAsJsonPrimitive == null)
			{
				cb_getAsJsonPrimitive = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAsJsonPrimitive));
			}
			return cb_getAsJsonPrimitive;
		}

		private static IntPtr n_GetAsJsonPrimitive(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsJsonPrimitive);
		}

		private static Delegate GetGetAsLongHandler()
		{
			if ((object)cb_getAsLong == null)
			{
				cb_getAsLong = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetAsLong));
			}
			return cb_getAsLong;
		}

		private static long n_GetAsLong(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsLong;
		}

		private static Delegate GetGetAsNumberHandler()
		{
			if ((object)cb_getAsNumber == null)
			{
				cb_getAsNumber = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAsNumber));
			}
			return cb_getAsNumber;
		}

		private static IntPtr n_GetAsNumber(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsNumber);
		}

		private static Delegate GetGetAsShortHandler()
		{
			if ((object)cb_getAsShort == null)
			{
				cb_getAsShort = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_S(n_GetAsShort));
			}
			return cb_getAsShort;
		}

		private static short n_GetAsShort(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsShort;
		}

		private static Delegate GetGetAsStringHandler()
		{
			if ((object)cb_getAsString == null)
			{
				cb_getAsString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAsString));
			}
			return cb_getAsString;
		}

		private static IntPtr n_GetAsString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsString);
		}

		private static Delegate GetIsJsonArrayHandler()
		{
			if ((object)cb_isJsonArray == null)
			{
				cb_isJsonArray = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsJsonArray));
			}
			return cb_isJsonArray;
		}

		private static bool n_IsJsonArray(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsJsonArray;
		}

		private static Delegate GetIsJsonNullHandler()
		{
			if ((object)cb_isJsonNull == null)
			{
				cb_isJsonNull = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsJsonNull));
			}
			return cb_isJsonNull;
		}

		private static bool n_IsJsonNull(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsJsonNull;
		}

		private static Delegate GetIsJsonObjectHandler()
		{
			if ((object)cb_isJsonObject == null)
			{
				cb_isJsonObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsJsonObject));
			}
			return cb_isJsonObject;
		}

		private static bool n_IsJsonObject(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsJsonObject;
		}

		private static Delegate GetIsJsonPrimitiveHandler()
		{
			if ((object)cb_isJsonPrimitive == null)
			{
				cb_isJsonPrimitive = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsJsonPrimitive));
			}
			return cb_isJsonPrimitive;
		}

		private static bool n_IsJsonPrimitive(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsJsonPrimitive;
		}

		private static Delegate GetDeepCopyHandler()
		{
			if ((object)cb_deepCopy == null)
			{
				cb_deepCopy = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_DeepCopy));
			}
			return cb_deepCopy;
		}

		private static IntPtr n_DeepCopy(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeepCopy());
		}

		[Register("deepCopy", "()Lcom/google/gson/JsonElement;", "GetDeepCopyHandler")]
		public abstract JsonElement DeepCopy();
	}
	[Register("com/google/gson/JsonElement", DoNotGenerateAcw = true)]
	internal class JsonElementInvoker : JsonElement
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonElement", typeof(JsonElementInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public JsonElementInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("deepCopy", "()Lcom/google/gson/JsonElement;", "GetDeepCopyHandler")]
		public unsafe override JsonElement DeepCopy()
		{
			return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("deepCopy.()Lcom/google/gson/JsonElement;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/JsonIOException", DoNotGenerateAcw = true)]
	public sealed class JsonIOException : JsonParseException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonIOException", typeof(JsonIOException));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal JsonIOException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe JsonIOException(string msg)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		public unsafe JsonIOException(string msg, Throwable cause)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(cause);
			}
		}

		[Register(".ctor", "(Ljava/lang/Throwable;)V", "")]
		public unsafe JsonIOException(Throwable cause)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}
	}
	[Register("com/google/gson/JsonNull", DoNotGenerateAcw = true)]
	public sealed class JsonNull : JsonElement
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonNull", typeof(JsonNull));

		[Register("INSTANCE")]
		public static JsonNull Instance => Java.Lang.Object.GetObject<JsonNull>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/google/gson/JsonNull;").Handle, JniHandleOwnership.TransferLocalRef);

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal JsonNull(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		[Obsolete("deprecated")]
		public unsafe JsonNull()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("deepCopy", "()Lcom/google/gson/JsonNull;", "")]
		public unsafe override JsonElement DeepCopy()
		{
			return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("deepCopy.()Lcom/google/gson/JsonNull;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/JsonObject", DoNotGenerateAcw = true)]
	public sealed class JsonObject : JsonElement
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonObject", typeof(JsonObject));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal JsonObject(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe JsonObject()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("add", "(Ljava/lang/String;Lcom/google/gson/JsonElement;)V", "")]
		public unsafe void Add(string property, JsonElement value)
		{
			IntPtr intPtr = JNIEnv.NewString(property);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("add.(Ljava/lang/String;Lcom/google/gson/JsonElement;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("addProperty", "(Ljava/lang/String;Ljava/lang/Boolean;)V", "")]
		public unsafe void AddProperty(string property, Java.Lang.Boolean value)
		{
			IntPtr intPtr = JNIEnv.NewString(property);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addProperty.(Ljava/lang/String;Ljava/lang/Boolean;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("addProperty", "(Ljava/lang/String;Ljava/lang/Character;)V", "")]
		public unsafe void AddProperty(string property, Character value)
		{
			IntPtr intPtr = JNIEnv.NewString(property);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addProperty.(Ljava/lang/String;Ljava/lang/Character;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("addProperty", "(Ljava/lang/String;Ljava/lang/Number;)V", "")]
		public unsafe void AddProperty(string property, Number value)
		{
			IntPtr intPtr = JNIEnv.NewString(property);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addProperty.(Ljava/lang/String;Ljava/lang/Number;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("addProperty", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe void AddProperty(string property, string value)
		{
			IntPtr intPtr = JNIEnv.NewString(property);
			IntPtr intPtr2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addProperty.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("deepCopy", "()Lcom/google/gson/JsonObject;", "")]
		public unsafe override JsonElement DeepCopy()
		{
			return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("deepCopy.()Lcom/google/gson/JsonObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("entrySet", "()Ljava/util/Set;", "")]
		public unsafe ICollection<IMapEntry> EntrySet()
		{
			return JavaSet<IMapEntry>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("entrySet.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("get", "(Ljava/lang/String;)Lcom/google/gson/JsonElement;", "")]
		public unsafe JsonElement Get(string memberName)
		{
			IntPtr intPtr = JNIEnv.NewString(memberName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("get.(Ljava/lang/String;)Lcom/google/gson/JsonElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getAsJsonArray", "(Ljava/lang/String;)Lcom/google/gson/JsonArray;", "")]
		public unsafe JsonArray GetAsJsonArray(string memberName)
		{
			IntPtr intPtr = JNIEnv.NewString(memberName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonArray>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAsJsonArray.(Ljava/lang/String;)Lcom/google/gson/JsonArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getAsJsonObject", "(Ljava/lang/String;)Lcom/google/gson/JsonObject;", "")]
		public unsafe JsonObject GetAsJsonObject(string memberName)
		{
			IntPtr intPtr = JNIEnv.NewString(memberName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonObject>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAsJsonObject.(Ljava/lang/String;)Lcom/google/gson/JsonObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getAsJsonPrimitive", "(Ljava/lang/String;)Lcom/google/gson/JsonPrimitive;", "")]
		public unsafe JsonPrimitive GetAsJsonPrimitive(string memberName)
		{
			IntPtr intPtr = JNIEnv.NewString(memberName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonPrimitive>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAsJsonPrimitive.(Ljava/lang/String;)Lcom/google/gson/JsonPrimitive;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("has", "(Ljava/lang/String;)Z", "")]
		public unsafe bool Has(string memberName)
		{
			IntPtr intPtr = JNIEnv.NewString(memberName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("has.(Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("keySet", "()Ljava/util/Set;", "")]
		public unsafe ICollection<string> KeySet()
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("keySet.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("remove", "(Ljava/lang/String;)Lcom/google/gson/JsonElement;", "")]
		public unsafe JsonElement Remove(string property)
		{
			IntPtr intPtr = JNIEnv.NewString(property);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("remove.(Ljava/lang/String;)Lcom/google/gson/JsonElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("size", "()I", "")]
		public unsafe int Size()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);
		}
	}
	[Register("com/google/gson/JsonParseException", DoNotGenerateAcw = true)]
	public class JsonParseException : RuntimeException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonParseException", typeof(JsonParseException));

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

		protected JsonParseException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe JsonParseException(string msg)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		public unsafe JsonParseException(string msg, Throwable cause)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(cause);
			}
		}

		[Register(".ctor", "(Ljava/lang/Throwable;)V", "")]
		public unsafe JsonParseException(Throwable cause)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}
	}
	[Register("com/google/gson/JsonParser", DoNotGenerateAcw = true)]
	public sealed class JsonParser : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonParser", typeof(JsonParser));

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

		internal JsonParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		[Obsolete("deprecated")]
		public unsafe JsonParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parseReader", "(Lcom/google/gson/stream/JsonReader;)Lcom/google/gson/JsonElement;", "")]
		public unsafe static JsonElement ParseReader(JsonReader reader)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reader?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<JsonElement>(_members.StaticMethods.InvokeObjectMethod("parseReader.(Lcom/google/gson/stream/JsonReader;)Lcom/google/gson/JsonElement;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(reader);
			}
		}

		[Register("parseReader", "(Ljava/io/Reader;)Lcom/google/gson/JsonElement;", "")]
		public unsafe static JsonElement ParseReader(Reader reader)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reader?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<JsonElement>(_members.StaticMethods.InvokeObjectMethod("parseReader.(Ljava/io/Reader;)Lcom/google/gson/JsonElement;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(reader);
			}
		}

		[Register("parseString", "(Ljava/lang/String;)Lcom/google/gson/JsonElement;", "")]
		public unsafe static JsonElement ParseString(string json)
		{
			IntPtr intPtr = JNIEnv.NewString(json);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonElement>(_members.StaticMethods.InvokeObjectMethod("parseString.(Ljava/lang/String;)Lcom/google/gson/JsonElement;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/gson/JsonPrimitive", DoNotGenerateAcw = true)]
	public sealed class JsonPrimitive : JsonElement
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonPrimitive", typeof(JsonPrimitive));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsBoolean
		{
			[Register("isBoolean", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isBoolean.()Z", this, null);
			}
		}

		public unsafe bool IsNumber
		{
			[Register("isNumber", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isNumber.()Z", this, null);
			}
		}

		public unsafe bool IsString
		{
			[Register("isString", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isString.()Z", this, null);
			}
		}

		internal JsonPrimitive(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Boolean;)V", "")]
		public unsafe JsonPrimitive(Java.Lang.Boolean @bool)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@bool?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Boolean;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Boolean;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@bool);
			}
		}

		[Register(".ctor", "(Ljava/lang/Character;)V", "")]
		public unsafe JsonPrimitive(Character c)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Character;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Character;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
			}
		}

		[Register(".ctor", "(Ljava/lang/Number;)V", "")]
		public unsafe JsonPrimitive(Number number)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(number?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Number;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Number;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(number);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe JsonPrimitive(string @string)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("deepCopy", "()Lcom/google/gson/JsonPrimitive;", "")]
		public unsafe override JsonElement DeepCopy()
		{
			return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("deepCopy.()Lcom/google/gson/JsonPrimitive;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/JsonStreamParser", DoNotGenerateAcw = true)]
	public sealed class JsonStreamParser : Java.Lang.Object, IIterator, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonStreamParser", typeof(JsonStreamParser));

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

		public unsafe bool HasNext
		{
			[Register("hasNext", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasNext.()Z", this, null);
			}
		}

		internal JsonStreamParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/io/Reader;)V", "")]
		public unsafe JsonStreamParser(Reader reader)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reader?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/io/Reader;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/io/Reader;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(reader);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe JsonStreamParser(string json)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(json);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("next", "()Lcom/google/gson/JsonElement;", "")]
		public unsafe Java.Lang.Object Next()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("next.()Lcom/google/gson/JsonElement;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("remove", "()V", "")]
		public unsafe void Remove()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
		}
	}
	[Register("com/google/gson/JsonSyntaxException", DoNotGenerateAcw = true)]
	public sealed class JsonSyntaxException : JsonParseException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/JsonSyntaxException", typeof(JsonSyntaxException));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal JsonSyntaxException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe JsonSyntaxException(string msg)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		public unsafe JsonSyntaxException(string msg, Throwable cause)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(cause);
			}
		}

		[Register(".ctor", "(Ljava/lang/Throwable;)V", "")]
		public unsafe JsonSyntaxException(Throwable cause)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}
	}
	[Register("com/google/gson/LongSerializationPolicy", DoNotGenerateAcw = true)]
	public abstract class LongSerializationPolicy : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/LongSerializationPolicy", typeof(LongSerializationPolicy));

		private static Delegate cb_serialize_Ljava_lang_Long_;

		[Register("DEFAULT")]
		public static LongSerializationPolicy Default => Java.Lang.Object.GetObject<LongSerializationPolicy>(_members.StaticFields.GetObjectValue("DEFAULT.Lcom/google/gson/LongSerializationPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STRING")]
		public static LongSerializationPolicy String => Java.Lang.Object.GetObject<LongSerializationPolicy>(_members.StaticFields.GetObjectValue("STRING.Lcom/google/gson/LongSerializationPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

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

		protected LongSerializationPolicy(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetSerialize_Ljava_lang_Long_Handler()
		{
			if ((object)cb_serialize_Ljava_lang_Long_ == null)
			{
				cb_serialize_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Serialize_Ljava_lang_Long_));
			}
			return cb_serialize_Ljava_lang_Long_;
		}

		private static IntPtr n_Serialize_Ljava_lang_Long_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			LongSerializationPolicy longSerializationPolicy = Java.Lang.Object.GetObject<LongSerializationPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Long p = Java.Lang.Object.GetObject<Long>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(longSerializationPolicy.Serialize(p));
		}

		[Register("serialize", "(Ljava/lang/Long;)Lcom/google/gson/JsonElement;", "GetSerialize_Ljava_lang_Long_Handler")]
		public abstract JsonElement Serialize(Long p0);

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/gson/LongSerializationPolicy;", "")]
		public unsafe static LongSerializationPolicy ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LongSerializationPolicy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/gson/LongSerializationPolicy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/gson/LongSerializationPolicy;", "")]
		public unsafe static LongSerializationPolicy[] Values()
		{
			return (LongSerializationPolicy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/gson/LongSerializationPolicy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(LongSerializationPolicy));
		}
	}
	[Register("com/google/gson/LongSerializationPolicy", DoNotGenerateAcw = true)]
	internal class LongSerializationPolicyInvoker : LongSerializationPolicy
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/LongSerializationPolicy", typeof(LongSerializationPolicyInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public LongSerializationPolicyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("serialize", "(Ljava/lang/Long;)Lcom/google/gson/JsonElement;", "GetSerialize_Ljava_lang_Long_Handler")]
		public unsafe override JsonElement Serialize(Long p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeAbstractObjectMethod("serialize.(Ljava/lang/Long;)Lcom/google/gson/JsonElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/gson/ToNumberPolicy", DoNotGenerateAcw = true)]
	public abstract class ToNumberPolicy : Java.Lang.Enum, IToNumberStrategy, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/ToNumberPolicy", typeof(ToNumberPolicy));

		private static Delegate cb_readNumber_Lcom_google_gson_stream_JsonReader_;

		[Register("BIG_DECIMAL")]
		public static ToNumberPolicy BigDecimal => Java.Lang.Object.GetObject<ToNumberPolicy>(_members.StaticFields.GetObjectValue("BIG_DECIMAL.Lcom/google/gson/ToNumberPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DOUBLE")]
		public static ToNumberPolicy Double => Java.Lang.Object.GetObject<ToNumberPolicy>(_members.StaticFields.GetObjectValue("DOUBLE.Lcom/google/gson/ToNumberPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LAZILY_PARSED_NUMBER")]
		public static ToNumberPolicy LazilyParsedNumber => Java.Lang.Object.GetObject<ToNumberPolicy>(_members.StaticFields.GetObjectValue("LAZILY_PARSED_NUMBER.Lcom/google/gson/ToNumberPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LONG_OR_DOUBLE")]
		public static ToNumberPolicy LongOrDouble => Java.Lang.Object.GetObject<ToNumberPolicy>(_members.StaticFields.GetObjectValue("LONG_OR_DOUBLE.Lcom/google/gson/ToNumberPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

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

		protected ToNumberPolicy(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/gson/ToNumberPolicy;", "")]
		public unsafe static ToNumberPolicy ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ToNumberPolicy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/gson/ToNumberPolicy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/gson/ToNumberPolicy;", "")]
		public unsafe static ToNumberPolicy[] Values()
		{
			return (ToNumberPolicy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/gson/ToNumberPolicy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ToNumberPolicy));
		}

		private static Delegate GetReadNumber_Lcom_google_gson_stream_JsonReader_Handler()
		{
			if ((object)cb_readNumber_Lcom_google_gson_stream_JsonReader_ == null)
			{
				cb_readNumber_Lcom_google_gson_stream_JsonReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadNumber_Lcom_google_gson_stream_JsonReader_));
			}
			return cb_readNumber_Lcom_google_gson_stream_JsonReader_;
		}

		private static IntPtr n_ReadNumber_Lcom_google_gson_stream_JsonReader_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ToNumberPolicy toNumberPolicy = Java.Lang.Object.GetObject<ToNumberPolicy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JsonReader p = Java.Lang.Object.GetObject<JsonReader>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(toNumberPolicy.ReadNumber(p));
		}

		[Register("readNumber", "(Lcom/google/gson/stream/JsonReader;)Ljava/lang/Number;", "GetReadNumber_Lcom_google_gson_stream_JsonReader_Handler")]
		public abstract Number ReadNumber(JsonReader p0);
	}
	[Register("com/google/gson/ToNumberPolicy", DoNotGenerateAcw = true)]
	internal class ToNumberPolicyInvoker : ToNumberPolicy
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/ToNumberPolicy", typeof(ToNumberPolicyInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ToNumberPolicyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("readNumber", "(Lcom/google/gson/stream/JsonReader;)Ljava/lang/Number;", "GetReadNumber_Lcom_google_gson_stream_JsonReader_Handler")]
		public unsafe override Number ReadNumber(JsonReader p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Number>(_members.InstanceMethods.InvokeAbstractObjectMethod("readNumber.(Lcom/google/gson/stream/JsonReader;)Ljava/lang/Number;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/gson/TypeAdapter", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public abstract class TypeAdapter : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/TypeAdapter", typeof(TypeAdapter));

		private static Delegate cb_read_Lcom_google_gson_stream_JsonReader_;

		private static Delegate cb_write_Lcom_google_gson_stream_JsonWriter_Ljava_lang_Object_;

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

		protected TypeAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TypeAdapter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("fromJson", "(Ljava/io/Reader;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object FromJson(Reader @in)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@in?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("fromJson.(Ljava/io/Reader;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(@in);
			}
		}

		[Register("fromJson", "(Ljava/lang/String;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object FromJson(string json)
		{
			IntPtr intPtr = JNIEnv.NewString(json);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("fromJson.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("fromJsonTree", "(Lcom/google/gson/JsonElement;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object FromJsonTree(JsonElement jsonTree)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(jsonTree?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("fromJsonTree.(Lcom/google/gson/JsonElement;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(jsonTree);
			}
		}

		[Register("nullSafe", "()Lcom/google/gson/TypeAdapter;", "")]
		public unsafe TypeAdapter NullSafe()
		{
			return Java.Lang.Object.GetObject<TypeAdapter>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("nullSafe.()Lcom/google/gson/TypeAdapter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRead_Lcom_google_gson_stream_JsonReader_Handler()
		{
			if ((object)cb_read_Lcom_google_gson_stream_JsonReader_ == null)
			{
				cb_read_Lcom_google_gson_stream_JsonReader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Read_Lcom_google_gson_stream_JsonReader_));
			}
			return cb_read_Lcom_google_gson_stream_JsonReader_;
		}

		private static IntPtr n_Read_Lcom_google_gson_stream_JsonReader_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			TypeAdapter typeAdapter = Java.Lang.Object.GetObject<TypeAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JsonReader p = Java.Lang.Object.GetObject<JsonReader>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(typeAdapter.Read(p));
		}

		[Register("read", "(Lcom/google/gson/stream/JsonReader;)Ljava/lang/Object;", "GetRead_Lcom_google_gson_stream_JsonReader_Handler")]
		public abstract Java.Lang.Object Read(JsonReader p0);

		[Register("toJson", "(Ljava/io/Writer;Ljava/lang/Object;)V", "")]
		public unsafe void ToJson(Writer @out, Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("toJson.(Ljava/io/Writer;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@out);
				GC.KeepAlive(value);
			}
		}

		[Register("toJson", "(Ljava/lang/Object;)Ljava/lang/String;", "")]
		public unsafe string ToJson(Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toJson.(Ljava/lang/Object;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("toJsonTree", "(Ljava/lang/Object;)Lcom/google/gson/JsonElement;", "")]
		public unsafe JsonElement ToJsonTree(Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonElement>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toJsonTree.(Ljava/lang/Object;)Lcom/google/gson/JsonElement;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetWrite_Lcom_google_gson_stream_JsonWriter_Ljava_lang_Object_Handler()
		{
			if ((object)cb_write_Lcom_google_gson_stream_JsonWriter_Ljava_lang_Object_ == null)
			{
				cb_write_Lcom_google_gson_stream_JsonWriter_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Write_Lcom_google_gson_stream_JsonWriter_Ljava_lang_Object_));
			}
			return cb_write_Lcom_google_gson_stream_JsonWriter_Ljava_lang_Object_;
		}

		private static void n_Write_Lcom_google_gson_stream_JsonWriter_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			TypeAdapter typeAdapter = Java.Lang.Object.GetObject<TypeAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JsonWriter p = Java.Lang.Object.GetObject<JsonWriter>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			typeAdapter.Write(p, p2);
		}

		[Register("write", "(Lcom/google/gson/stream/JsonWriter;Ljava/lang/Object;)V", "GetWrite_Lcom_google_gson_stream_JsonWriter_Ljava_lang_Object_Handler")]
		public abstract void Write(JsonWriter p0, Java.Lang.Object p1);
	}
	[Register("com/google/gson/TypeAdapter", DoNotGenerateAcw = true)]
	internal class TypeAdapterInvoker : TypeAdapter
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/TypeAdapter", typeof(TypeAdapterInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public TypeAdapterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("read", "(Lcom/google/gson/stream/JsonReader;)Ljava/lang/Object;", "GetRead_Lcom_google_gson_stream_JsonReader_Handler")]
		public unsafe override Java.Lang.Object Read(JsonReader p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("read.(Lcom/google/gson/stream/JsonReader;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("write", "(Lcom/google/gson/stream/JsonWriter;Ljava/lang/Object;)V", "GetWrite_Lcom_google_gson_stream_JsonWriter_Ljava_lang_Object_Handler")]
		public unsafe override void Write(JsonWriter p0, Java.Lang.Object p1)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("write.(Lcom/google/gson/stream/JsonWriter;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}
	}
}
namespace GoogleGson.Stream
{
	[Register("com/google/gson/stream/JsonReader", DoNotGenerateAcw = true)]
	public class JsonReader : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/stream/JsonReader", typeof(JsonReader));

		private static Delegate cb_hasNext;

		private static Delegate cb_getPath;

		private static Delegate cb_beginArray;

		private static Delegate cb_beginObject;

		private static Delegate cb_close;

		private static Delegate cb_endArray;

		private static Delegate cb_endObject;

		private static Delegate cb_nextBoolean;

		private static Delegate cb_nextDouble;

		private static Delegate cb_nextInt;

		private static Delegate cb_nextLong;

		private static Delegate cb_nextName;

		private static Delegate cb_nextNull;

		private static Delegate cb_nextString;

		private static Delegate cb_peek;

		private static Delegate cb_skipValue;

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

		public unsafe virtual bool HasNext
		{
			[Register("hasNext", "()Z", "GetHasNextHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasNext.()Z", this, null);
			}
		}

		public unsafe bool Lenient
		{
			[Register("isLenient", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isLenient.()Z", this, null);
			}
			[Register("setLenient", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLenient.(Z)V", this, ptr);
			}
		}

		public unsafe virtual string Path
		{
			[Register("getPath", "()Ljava/lang/String;", "GetGetPathHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPath.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected JsonReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/io/Reader;)V", "")]
		public unsafe JsonReader(Reader @in)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@in?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/io/Reader;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/io/Reader;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@in);
			}
		}

		private static Delegate GetHasNextHandler()
		{
			if ((object)cb_hasNext == null)
			{
				cb_hasNext = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasNext));
			}
			return cb_hasNext;
		}

		private static bool n_HasNext(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasNext;
		}

		private static Delegate GetGetPathHandler()
		{
			if ((object)cb_getPath == null)
			{
				cb_getPath = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPath));
			}
			return cb_getPath;
		}

		private static IntPtr n_GetPath(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Path);
		}

		private static Delegate GetBeginArrayHandler()
		{
			if ((object)cb_beginArray == null)
			{
				cb_beginArray = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_BeginArray));
			}
			return cb_beginArray;
		}

		private static void n_BeginArray(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BeginArray();
		}

		[Register("beginArray", "()V", "GetBeginArrayHandler")]
		public unsafe virtual void BeginArray()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("beginArray.()V", this, null);
		}

		private static Delegate GetBeginObjectHandler()
		{
			if ((object)cb_beginObject == null)
			{
				cb_beginObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_BeginObject));
			}
			return cb_beginObject;
		}

		private static void n_BeginObject(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BeginObject();
		}

		[Register("beginObject", "()V", "GetBeginObjectHandler")]
		public unsafe virtual void BeginObject()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("beginObject.()V", this, null);
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}

		private static Delegate GetEndArrayHandler()
		{
			if ((object)cb_endArray == null)
			{
				cb_endArray = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_EndArray));
			}
			return cb_endArray;
		}

		private static void n_EndArray(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndArray();
		}

		[Register("endArray", "()V", "GetEndArrayHandler")]
		public unsafe virtual void EndArray()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("endArray.()V", this, null);
		}

		private static Delegate GetEndObjectHandler()
		{
			if ((object)cb_endObject == null)
			{
				cb_endObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_EndObject));
			}
			return cb_endObject;
		}

		private static void n_EndObject(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndObject();
		}

		[Register("endObject", "()V", "GetEndObjectHandler")]
		public unsafe virtual void EndObject()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("endObject.()V", this, null);
		}

		private static Delegate GetNextBooleanHandler()
		{
			if ((object)cb_nextBoolean == null)
			{
				cb_nextBoolean = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_NextBoolean));
			}
			return cb_nextBoolean;
		}

		private static bool n_NextBoolean(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextBoolean();
		}

		[Register("nextBoolean", "()Z", "GetNextBooleanHandler")]
		public unsafe virtual bool NextBoolean()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("nextBoolean.()Z", this, null);
		}

		private static Delegate GetNextDoubleHandler()
		{
			if ((object)cb_nextDouble == null)
			{
				cb_nextDouble = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_NextDouble));
			}
			return cb_nextDouble;
		}

		private static double n_NextDouble(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextDouble();
		}

		[Register("nextDouble", "()D", "GetNextDoubleHandler")]
		public unsafe virtual double NextDouble()
		{
			return _members.InstanceMethods.InvokeVirtualDoubleMethod("nextDouble.()D", this, null);
		}

		private static Delegate GetNextIntHandler()
		{
			if ((object)cb_nextInt == null)
			{
				cb_nextInt = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_NextInt));
			}
			return cb_nextInt;
		}

		private static int n_NextInt(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextInt();
		}

		[Register("nextInt", "()I", "GetNextIntHandler")]
		public unsafe virtual int NextInt()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("nextInt.()I", this, null);
		}

		private static Delegate GetNextLongHandler()
		{
			if ((object)cb_nextLong == null)
			{
				cb_nextLong = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_NextLong));
			}
			return cb_nextLong;
		}

		private static long n_NextLong(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextLong();
		}

		[Register("nextLong", "()J", "GetNextLongHandler")]
		public unsafe virtual long NextLong()
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("nextLong.()J", this, null);
		}

		private static Delegate GetNextNameHandler()
		{
			if ((object)cb_nextName == null)
			{
				cb_nextName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_NextName));
			}
			return cb_nextName;
		}

		private static IntPtr n_NextName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextName());
		}

		[Register("nextName", "()Ljava/lang/String;", "GetNextNameHandler")]
		public unsafe virtual string NextName()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("nextName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetNextNullHandler()
		{
			if ((object)cb_nextNull == null)
			{
				cb_nextNull = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_NextNull));
			}
			return cb_nextNull;
		}

		private static void n_NextNull(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextNull();
		}

		[Register("nextNull", "()V", "GetNextNullHandler")]
		public unsafe virtual void NextNull()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("nextNull.()V", this, null);
		}

		private static Delegate GetNextStringHandler()
		{
			if ((object)cb_nextString == null)
			{
				cb_nextString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_NextString));
			}
			return cb_nextString;
		}

		private static IntPtr n_NextString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextString());
		}

		[Register("nextString", "()Ljava/lang/String;", "GetNextStringHandler")]
		public unsafe virtual string NextString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("nextString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPeekHandler()
		{
			if ((object)cb_peek == null)
			{
				cb_peek = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Peek));
			}
			return cb_peek;
		}

		private static IntPtr n_Peek(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Peek());
		}

		[Register("peek", "()Lcom/google/gson/stream/JsonToken;", "GetPeekHandler")]
		public unsafe virtual JsonToken Peek()
		{
			return Java.Lang.Object.GetObject<JsonToken>(_members.InstanceMethods.InvokeVirtualObjectMethod("peek.()Lcom/google/gson/stream/JsonToken;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSkipValueHandler()
		{
			if ((object)cb_skipValue == null)
			{
				cb_skipValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SkipValue));
			}
			return cb_skipValue;
		}

		private static void n_SkipValue(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<JsonReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SkipValue();
		}

		[Register("skipValue", "()V", "GetSkipValueHandler")]
		public unsafe virtual void SkipValue()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("skipValue.()V", this, null);
		}
	}
	[Register("com/google/gson/stream/JsonToken", DoNotGenerateAcw = true)]
	public sealed class JsonToken : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/stream/JsonToken", typeof(JsonToken));

		[Register("BEGIN_ARRAY")]
		public static JsonToken BeginArray => Java.Lang.Object.GetObject<JsonToken>(_members.StaticFields.GetObjectValue("BEGIN_ARRAY.Lcom/google/gson/stream/JsonToken;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("BEGIN_OBJECT")]
		public static JsonToken BeginObject => Java.Lang.Object.GetObject<JsonToken>(_members.StaticFields.GetObjectValue("BEGIN_OBJECT.Lcom/google/gson/stream/JsonToken;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("BOOLEAN")]
		public static JsonToken Boolean => Java.Lang.Object.GetObject<JsonToken>(_members.StaticFields.GetObjectValue("BOOLEAN.Lcom/google/gson/stream/JsonToken;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("END_ARRAY")]
		public static JsonToken EndArray => Java.Lang.Object.GetObject<JsonToken>(_members.StaticFields.GetObjectValue("END_ARRAY.Lcom/google/gson/stream/JsonToken;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("END_DOCUMENT")]
		public static JsonToken EndDocument => Java.Lang.Object.GetObject<JsonToken>(_members.StaticFields.GetObjectValue("END_DOCUMENT.Lcom/google/gson/stream/JsonToken;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("END_OBJECT")]
		public static JsonToken EndObject => Java.Lang.Object.GetObject<JsonToken>(_members.StaticFields.GetObjectValue("END_OBJECT.Lcom/google/gson/stream/JsonToken;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NAME")]
		public new static JsonToken Name => Java.Lang.Object.GetObject<JsonToken>(_members.StaticFields.GetObjectValue("NAME.Lcom/google/gson/stream/JsonToken;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NULL")]
		public static JsonToken Null => Java.Lang.Object.GetObject<JsonToken>(_members.StaticFields.GetObjectValue("NULL.Lcom/google/gson/stream/JsonToken;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NUMBER")]
		public static JsonToken Number => Java.Lang.Object.GetObject<JsonToken>(_members.StaticFields.GetObjectValue("NUMBER.Lcom/google/gson/stream/JsonToken;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STRING")]
		public static JsonToken String => Java.Lang.Object.GetObject<JsonToken>(_members.StaticFields.GetObjectValue("STRING.Lcom/google/gson/stream/JsonToken;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal JsonToken(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/gson/stream/JsonToken;", "")]
		public unsafe static JsonToken ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonToken>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/gson/stream/JsonToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/gson/stream/JsonToken;", "")]
		public unsafe static JsonToken[] Values()
		{
			return (JsonToken[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/gson/stream/JsonToken;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(JsonToken));
		}
	}
	[Register("com/google/gson/stream/JsonWriter", DoNotGenerateAcw = true)]
	public class JsonWriter : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable, IFlushable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/stream/JsonWriter", typeof(JsonWriter));

		private static Delegate cb_beginArray;

		private static Delegate cb_beginObject;

		private static Delegate cb_close;

		private static Delegate cb_endArray;

		private static Delegate cb_endObject;

		private static Delegate cb_flush;

		private static Delegate cb_jsonValue_Ljava_lang_String_;

		private static Delegate cb_name_Ljava_lang_String_;

		private static Delegate cb_nullValue;

		private static Delegate cb_value_Z;

		private static Delegate cb_value_D;

		private static Delegate cb_value_Ljava_lang_Boolean_;

		private static Delegate cb_value_Ljava_lang_Number_;

		private static Delegate cb_value_Ljava_lang_String_;

		private static Delegate cb_value_J;

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

		public unsafe bool HtmlSafe
		{
			[Register("isHtmlSafe", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isHtmlSafe.()Z", this, null);
			}
			[Register("setHtmlSafe", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setHtmlSafe.(Z)V", this, ptr);
			}
		}

		public unsafe bool Lenient
		{
			[Register("isLenient", "()Z", "GetIsLenientHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLenient.()Z", this, null);
			}
			[Register("setLenient", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLenient.(Z)V", this, ptr);
			}
		}

		public unsafe bool SerializeNulls
		{
			[Register("getSerializeNulls", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getSerializeNulls.()Z", this, null);
			}
			[Register("setSerializeNulls", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setSerializeNulls.(Z)V", this, ptr);
			}
		}

		protected JsonWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/io/Writer;)V", "")]
		public unsafe JsonWriter(Writer @out)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/io/Writer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/io/Writer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}

		private static Delegate GetBeginArrayHandler()
		{
			if ((object)cb_beginArray == null)
			{
				cb_beginArray = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_BeginArray));
			}
			return cb_beginArray;
		}

		private static IntPtr n_BeginArray(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BeginArray());
		}

		[Register("beginArray", "()Lcom/google/gson/stream/JsonWriter;", "GetBeginArrayHandler")]
		public unsafe virtual JsonWriter BeginArray()
		{
			return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("beginArray.()Lcom/google/gson/stream/JsonWriter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetBeginObjectHandler()
		{
			if ((object)cb_beginObject == null)
			{
				cb_beginObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_BeginObject));
			}
			return cb_beginObject;
		}

		private static IntPtr n_BeginObject(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BeginObject());
		}

		[Register("beginObject", "()Lcom/google/gson/stream/JsonWriter;", "GetBeginObjectHandler")]
		public unsafe virtual JsonWriter BeginObject()
		{
			return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("beginObject.()Lcom/google/gson/stream/JsonWriter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}

		private static Delegate GetEndArrayHandler()
		{
			if ((object)cb_endArray == null)
			{
				cb_endArray = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_EndArray));
			}
			return cb_endArray;
		}

		private static IntPtr n_EndArray(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndArray());
		}

		[Register("endArray", "()Lcom/google/gson/stream/JsonWriter;", "GetEndArrayHandler")]
		public unsafe virtual JsonWriter EndArray()
		{
			return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("endArray.()Lcom/google/gson/stream/JsonWriter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetEndObjectHandler()
		{
			if ((object)cb_endObject == null)
			{
				cb_endObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_EndObject));
			}
			return cb_endObject;
		}

		private static IntPtr n_EndObject(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndObject());
		}

		[Register("endObject", "()Lcom/google/gson/stream/JsonWriter;", "GetEndObjectHandler")]
		public unsafe virtual JsonWriter EndObject()
		{
			return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("endObject.()Lcom/google/gson/stream/JsonWriter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetFlushHandler()
		{
			if ((object)cb_flush == null)
			{
				cb_flush = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Flush));
			}
			return cb_flush;
		}

		private static void n_Flush(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Flush();
		}

		[Register("flush", "()V", "GetFlushHandler")]
		public unsafe virtual void Flush()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("flush.()V", this, null);
		}

		private static Delegate GetJsonValue_Ljava_lang_String_Handler()
		{
			if ((object)cb_jsonValue_Ljava_lang_String_ == null)
			{
				cb_jsonValue_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_JsonValue_Ljava_lang_String_));
			}
			return cb_jsonValue_Ljava_lang_String_;
		}

		private static IntPtr n_JsonValue_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			JsonWriter jsonWriter = Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jsonWriter.JsonValue(value));
		}

		[Register("jsonValue", "(Ljava/lang/String;)Lcom/google/gson/stream/JsonWriter;", "GetJsonValue_Ljava_lang_String_Handler")]
		public unsafe virtual JsonWriter JsonValue(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("jsonValue.(Ljava/lang/String;)Lcom/google/gson/stream/JsonWriter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetName_Ljava_lang_String_Handler()
		{
			if ((object)cb_name_Ljava_lang_String_ == null)
			{
				cb_name_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Name_Ljava_lang_String_));
			}
			return cb_name_Ljava_lang_String_;
		}

		private static IntPtr n_Name_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
		{
			JsonWriter jsonWriter = Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jsonWriter.Name(name));
		}

		[Register("name", "(Ljava/lang/String;)Lcom/google/gson/stream/JsonWriter;", "GetName_Ljava_lang_String_Handler")]
		public unsafe virtual JsonWriter Name(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("name.(Ljava/lang/String;)Lcom/google/gson/stream/JsonWriter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetNullValueHandler()
		{
			if ((object)cb_nullValue == null)
			{
				cb_nullValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_NullValue));
			}
			return cb_nullValue;
		}

		private static IntPtr n_NullValue(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NullValue());
		}

		[Register("nullValue", "()Lcom/google/gson/stream/JsonWriter;", "GetNullValueHandler")]
		public unsafe virtual JsonWriter NullValue()
		{
			return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("nullValue.()Lcom/google/gson/stream/JsonWriter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setIndent", "(Ljava/lang/String;)V", "")]
		public unsafe void SetIndent(string indent)
		{
			IntPtr intPtr = JNIEnv.NewString(indent);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setIndent.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetValue_ZHandler()
		{
			if ((object)cb_value_Z == null)
			{
				cb_value_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_Value_Z));
			}
			return cb_value_Z;
		}

		private static IntPtr n_Value_Z(IntPtr jnienv, IntPtr native__this, bool value)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value(value));
		}

		[Register("value", "(Z)Lcom/google/gson/stream/JsonWriter;", "GetValue_ZHandler")]
		public unsafe virtual JsonWriter Value(bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("value.(Z)Lcom/google/gson/stream/JsonWriter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetValue_DHandler()
		{
			if ((object)cb_value_D == null)
			{
				cb_value_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPD_L(n_Value_D));
			}
			return cb_value_D;
		}

		private static IntPtr n_Value_D(IntPtr jnienv, IntPtr native__this, double value)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value(value));
		}

		[Register("value", "(D)Lcom/google/gson/stream/JsonWriter;", "GetValue_DHandler")]
		public unsafe virtual JsonWriter Value(double value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("value.(D)Lcom/google/gson/stream/JsonWriter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetValue_Ljava_lang_Boolean_Handler()
		{
			if ((object)cb_value_Ljava_lang_Boolean_ == null)
			{
				cb_value_Ljava_lang_Boolean_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Value_Ljava_lang_Boolean_));
			}
			return cb_value_Ljava_lang_Boolean_;
		}

		private static IntPtr n_Value_Ljava_lang_Boolean_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			JsonWriter jsonWriter = Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Boolean value = Java.Lang.Object.GetObject<Java.Lang.Boolean>(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jsonWriter.Value(value));
		}

		[Register("value", "(Ljava/lang/Boolean;)Lcom/google/gson/stream/JsonWriter;", "GetValue_Ljava_lang_Boolean_Handler")]
		public unsafe virtual JsonWriter Value(Java.Lang.Boolean value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("value.(Ljava/lang/Boolean;)Lcom/google/gson/stream/JsonWriter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetValue_Ljava_lang_Number_Handler()
		{
			if ((object)cb_value_Ljava_lang_Number_ == null)
			{
				cb_value_Ljava_lang_Number_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Value_Ljava_lang_Number_));
			}
			return cb_value_Ljava_lang_Number_;
		}

		private static IntPtr n_Value_Ljava_lang_Number_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			JsonWriter jsonWriter = Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Number value = Java.Lang.Object.GetObject<Number>(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jsonWriter.Value(value));
		}

		[Register("value", "(Ljava/lang/Number;)Lcom/google/gson/stream/JsonWriter;", "GetValue_Ljava_lang_Number_Handler")]
		public unsafe virtual JsonWriter Value(Number value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("value.(Ljava/lang/Number;)Lcom/google/gson/stream/JsonWriter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetValue_Ljava_lang_String_Handler()
		{
			if ((object)cb_value_Ljava_lang_String_ == null)
			{
				cb_value_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Value_Ljava_lang_String_));
			}
			return cb_value_Ljava_lang_String_;
		}

		private static IntPtr n_Value_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			JsonWriter jsonWriter = Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jsonWriter.Value(value));
		}

		[Register("value", "(Ljava/lang/String;)Lcom/google/gson/stream/JsonWriter;", "GetValue_Ljava_lang_String_Handler")]
		public unsafe virtual JsonWriter Value(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("value.(Ljava/lang/String;)Lcom/google/gson/stream/JsonWriter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetValue_JHandler()
		{
			if ((object)cb_value_J == null)
			{
				cb_value_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_Value_J));
			}
			return cb_value_J;
		}

		private static IntPtr n_Value_J(IntPtr jnienv, IntPtr native__this, long value)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JsonWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value(value));
		}

		[Register("value", "(J)Lcom/google/gson/stream/JsonWriter;", "GetValue_JHandler")]
		public unsafe virtual JsonWriter Value(long value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<JsonWriter>(_members.InstanceMethods.InvokeVirtualObjectMethod("value.(J)Lcom/google/gson/stream/JsonWriter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/gson/stream/MalformedJsonException", DoNotGenerateAcw = true)]
	public sealed class MalformedJsonException : IOException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/stream/MalformedJsonException", typeof(MalformedJsonException));

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

		internal MalformedJsonException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe MalformedJsonException(string msg)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		public unsafe MalformedJsonException(string msg, Throwable throwable)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(throwable?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(throwable);
			}
		}

		[Register(".ctor", "(Ljava/lang/Throwable;)V", "")]
		public unsafe MalformedJsonException(Throwable throwable)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(throwable?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(throwable);
			}
		}
	}
}
namespace GoogleGson.Reflect
{
	[Register("com/google/gson/reflect/TypeToken", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public class TypeToken : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/reflect/TypeToken", typeof(TypeToken));

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

		public unsafe Class RawType
		{
			[Register("getRawType", "()Ljava/lang/Class;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Class>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getRawType.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IType Type
		{
			[Register("getType", "()Ljava/lang/reflect/Type;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getType.()Ljava/lang/reflect/Type;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected TypeToken(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		protected unsafe TypeToken()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
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

		[Register("get", "(Ljava/lang/Class;)Lcom/google/gson/reflect/TypeToken;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static TypeToken Get(Class type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TypeToken>(_members.StaticMethods.InvokeObjectMethod("get.(Ljava/lang/Class;)Lcom/google/gson/reflect/TypeToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		[Register("get", "(Ljava/lang/reflect/Type;)Lcom/google/gson/reflect/TypeToken;", "")]
		public unsafe static TypeToken Get(IType type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				return Java.Lang.Object.GetObject<TypeToken>(_members.StaticMethods.InvokeObjectMethod("get.(Ljava/lang/reflect/Type;)Lcom/google/gson/reflect/TypeToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		[Register("getArray", "(Ljava/lang/reflect/Type;)Lcom/google/gson/reflect/TypeToken;", "")]
		public unsafe static TypeToken GetArray(IType componentType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((componentType == null) ? IntPtr.Zero : ((Java.Lang.Object)componentType).Handle);
				return Java.Lang.Object.GetObject<TypeToken>(_members.StaticMethods.InvokeObjectMethod("getArray.(Ljava/lang/reflect/Type;)Lcom/google/gson/reflect/TypeToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(componentType);
			}
		}

		[Register("getParameterized", "(Ljava/lang/reflect/Type;[Ljava/lang/reflect/Type;)Lcom/google/gson/reflect/TypeToken;", "")]
		public unsafe static TypeToken GetParameterized(IType rawType, params IType[] typeArguments)
		{
			IntPtr intPtr = JNIEnv.NewArray(typeArguments);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((rawType == null) ? IntPtr.Zero : ((Java.Lang.Object)rawType).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<TypeToken>(_members.StaticMethods.InvokeObjectMethod("getParameterized.(Ljava/lang/reflect/Type;[Ljava/lang/reflect/Type;)Lcom/google/gson/reflect/TypeToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (typeArguments != null)
				{
					JNIEnv.CopyArray(intPtr, typeArguments);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(rawType);
				GC.KeepAlive(typeArguments);
			}
		}

		[Register("hashCode", "()I", "")]
		public unsafe sealed override int GetHashCode()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("hashCode.()I", this, null);
		}

		[Register("toString", "()Ljava/lang/String;", "")]
		public unsafe sealed override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace GoogleGson.Annotations
{
	[Annotation("com.google.gson.annotations.Expose")]
	public class ExposeAttribute : Attribute
	{
		[Register("deserialize")]
		public bool Deserialize { get; set; }

		[Register("serialize")]
		public bool Serialize { get; set; }
	}
	[Register("com/google/gson/annotations/Expose", "", "GoogleGson.Annotations.IExposeInvoker")]
	public interface IExpose : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("deserialize", "()Z", "GetDeserializeHandler:GoogleGson.Annotations.IExposeInvoker, GoogleGson")]
		bool Deserialize();

		[Register("serialize", "()Z", "GetSerializeHandler:GoogleGson.Annotations.IExposeInvoker, GoogleGson")]
		bool Serialize();
	}
	[Register("com/google/gson/annotations/Expose", DoNotGenerateAcw = true)]
	internal class IExposeInvoker : Java.Lang.Object, IExpose, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/annotations/Expose", typeof(IExposeInvoker));

		private IntPtr class_ref;

		private static Delegate cb_deserialize;

		private IntPtr id_deserialize;

		private static Delegate cb_serialize;

		private IntPtr id_serialize;

		private static Delegate cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate cb_toString;

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

		public static IExpose GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IExpose>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.annotations.Expose'.");
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

		public IExposeInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDeserializeHandler()
		{
			if ((object)cb_deserialize == null)
			{
				cb_deserialize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_Deserialize));
			}
			return cb_deserialize;
		}

		private static bool n_Deserialize(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IExpose>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Deserialize();
		}

		public bool Deserialize()
		{
			if (id_deserialize == IntPtr.Zero)
			{
				id_deserialize = JNIEnv.GetMethodID(class_ref, "deserialize", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_deserialize);
		}

		private static Delegate GetSerializeHandler()
		{
			if ((object)cb_serialize == null)
			{
				cb_serialize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_Serialize));
			}
			return cb_serialize;
		}

		private static bool n_Serialize(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IExpose>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Serialize();
		}

		public bool Serialize()
		{
			if (id_serialize == IntPtr.Zero)
			{
				id_serialize = JNIEnv.GetMethodID(class_ref, "serialize", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_serialize);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IExpose>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IExpose expose = Java.Lang.Object.GetObject<IExpose>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return expose.Equals(obj);
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
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IExpose>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IExpose>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/gson/annotations/JsonAdapter", "", "GoogleGson.Annotations.IJsonAdapterInvoker")]
	public interface IJsonAdapter : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("nullSafe", "()Z", "GetNullSafeHandler:GoogleGson.Annotations.IJsonAdapterInvoker, GoogleGson")]
		bool NullSafe();

		[Register("value", "()Ljava/lang/Class;", "GetValueHandler:GoogleGson.Annotations.IJsonAdapterInvoker, GoogleGson")]
		Class Value();
	}
	[Register("com/google/gson/annotations/JsonAdapter", DoNotGenerateAcw = true)]
	internal class IJsonAdapterInvoker : Java.Lang.Object, IJsonAdapter, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/annotations/JsonAdapter", typeof(IJsonAdapterInvoker));

		private IntPtr class_ref;

		private static Delegate cb_nullSafe;

		private IntPtr id_nullSafe;

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

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IJsonAdapter GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IJsonAdapter>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.annotations.JsonAdapter'.");
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

		public IJsonAdapterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetNullSafeHandler()
		{
			if ((object)cb_nullSafe == null)
			{
				cb_nullSafe = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_NullSafe));
			}
			return cb_nullSafe;
		}

		private static bool n_NullSafe(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IJsonAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NullSafe();
		}

		public bool NullSafe()
		{
			if (id_nullSafe == IntPtr.Zero)
			{
				id_nullSafe = JNIEnv.GetMethodID(class_ref, "nullSafe", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_nullSafe);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IJsonAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public Class Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/Class;");
			}
			return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IJsonAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IJsonAdapter jsonAdapter = Java.Lang.Object.GetObject<IJsonAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return jsonAdapter.Equals(obj);
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
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IJsonAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IJsonAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/gson/annotations/SerializedName", "", "GoogleGson.Annotations.ISerializedNameInvoker")]
	public interface ISerializedName : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("alternate", "()[Ljava/lang/String;", "GetAlternateHandler:GoogleGson.Annotations.ISerializedNameInvoker, GoogleGson")]
		string[] Alternate();

		[Register("value", "()Ljava/lang/String;", "GetValueHandler:GoogleGson.Annotations.ISerializedNameInvoker, GoogleGson")]
		string Value();
	}
	[Register("com/google/gson/annotations/SerializedName", DoNotGenerateAcw = true)]
	internal class ISerializedNameInvoker : Java.Lang.Object, ISerializedName, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/annotations/SerializedName", typeof(ISerializedNameInvoker));

		private IntPtr class_ref;

		private static Delegate cb_alternate;

		private IntPtr id_alternate;

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

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ISerializedName GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISerializedName>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.annotations.SerializedName'.");
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

		public ISerializedNameInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAlternateHandler()
		{
			if ((object)cb_alternate == null)
			{
				cb_alternate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Alternate));
			}
			return cb_alternate;
		}

		private static IntPtr n_Alternate(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ISerializedName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Alternate());
		}

		public string[] Alternate()
		{
			if (id_alternate == IntPtr.Zero)
			{
				id_alternate = JNIEnv.GetMethodID(class_ref, "alternate", "()[Ljava/lang/String;");
			}
			return (string[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_alternate), JniHandleOwnership.TransferLocalRef, typeof(string));
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISerializedName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISerializedName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			ISerializedName serializedName = Java.Lang.Object.GetObject<ISerializedName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return serializedName.Equals(obj);
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
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ISerializedName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISerializedName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/gson/annotations/Since", "", "GoogleGson.Annotations.ISinceInvoker")]
	public interface ISince : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()D", "GetValueHandler:GoogleGson.Annotations.ISinceInvoker, GoogleGson")]
		double Value();
	}
	[Register("com/google/gson/annotations/Since", DoNotGenerateAcw = true)]
	internal class ISinceInvoker : Java.Lang.Object, ISince, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/annotations/Since", typeof(ISinceInvoker));

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

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ISince GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISince>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.annotations.Since'.");
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

		public ISinceInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_Value));
			}
			return cb_value;
		}

		private static double n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ISince>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value();
		}

		public double Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()D");
			}
			return JNIEnv.CallDoubleMethod(base.Handle, id_value);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISince>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			ISince since = Java.Lang.Object.GetObject<ISince>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return since.Equals(obj);
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
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ISince>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISince>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/gson/annotations/Until", "", "GoogleGson.Annotations.IUntilInvoker")]
	public interface IUntil : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()D", "GetValueHandler:GoogleGson.Annotations.IUntilInvoker, GoogleGson")]
		double Value();
	}
	[Register("com/google/gson/annotations/Until", DoNotGenerateAcw = true)]
	internal class IUntilInvoker : Java.Lang.Object, IUntil, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/gson/annotations/Until", typeof(IUntilInvoker));

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

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IUntil GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IUntil>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.gson.annotations.Until'.");
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

		public IUntilInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_Value));
			}
			return cb_value;
		}

		private static double n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IUntil>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value();
		}

		public double Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()D");
			}
			return JNIEnv.CallDoubleMethod(base.Handle, id_value);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUntil>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IUntil until = Java.Lang.Object.GetObject<IUntil>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return until.Equals(obj);
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
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IUntil>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IUntil>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Annotation("com.google.gson.annotations.JsonAdapter")]
	public class JsonAdapterAttribute : Attribute
	{
		[Register("nullSafe")]
		public bool NullSafe { get; set; }

		[Register("value")]
		public Class Value { get; set; }
	}
	[Annotation("com.google.gson.annotations.SerializedName")]
	public class SerializedNameAttribute : Attribute
	{
		[Register("alternate")]
		public string[] Alternate { get; set; }

		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("com.google.gson.annotations.Since")]
	public class SinceAttribute : Attribute
	{
		[Register("value")]
		public double Value { get; set; }
	}
	[Annotation("com.google.gson.annotations.Until")]
	public class UntilAttribute : Attribute
	{
		[Register("value")]
		public double Value { get; set; }
	}
}
