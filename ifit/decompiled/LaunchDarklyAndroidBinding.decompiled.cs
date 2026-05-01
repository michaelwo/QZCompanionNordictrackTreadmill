using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.App;
using Android.Content;
using Android.Net;
using Android.Runtime;
using Com.Launchdarkly.Logging;
using Com.Launchdarkly.Sdk.Android.Integrations;
using Com.Launchdarkly.Sdk.Android.Subsystems;
using Com.Launchdarkly.Sdk.Json;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Net;
using Java.Text;
using Java.Util;
using Java.Util.Concurrent;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("LaunchDarklyAndroidBinding")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: NamespaceMapping(Java = "com.launchdarkly.logging", Managed = "Com.Launchdarkly.Logging")]
[assembly: NamespaceMapping(Java = "com.launchdarkly.sdk", Managed = "Com.Launchdarkly.Sdk")]
[assembly: NamespaceMapping(Java = "com.launchdarkly.sdk.android", Managed = "Com.Launchdarkly.Sdk.Android")]
[assembly: NamespaceMapping(Java = "com.launchdarkly.sdk.android.integrations", Managed = "Com.Launchdarkly.Sdk.Android.Integrations")]
[assembly: NamespaceMapping(Java = "com.launchdarkly.sdk.android.subsystems", Managed = "Com.Launchdarkly.Sdk.Android.Subsystems")]
[assembly: NamespaceMapping(Java = "com.launchdarkly.sdk.json", Managed = "Com.Launchdarkly.Sdk.Json")]
[assembly: TargetFramework("MonoAndroid,Version=v11.0", FrameworkDisplayName = "Xamarin.Android v11.0 Support")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate double _JniMarshal_PP_D(IntPtr jnienv, IntPtr klass);
internal delegate float _JniMarshal_PP_F(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate double _JniMarshal_PPLD_D(IntPtr jnienv, IntPtr klass, IntPtr p0, double p1);
internal delegate IntPtr _JniMarshal_PPLD_L(IntPtr jnienv, IntPtr klass, IntPtr p0, double p1);
internal delegate int _JniMarshal_PPLI_I(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate IntPtr _JniMarshal_PPLI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLD_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, double p2);
internal delegate void _JniMarshal_PPLLIILLLZL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3, IntPtr p4, IntPtr p5, IntPtr p6, bool p7, IntPtr p8);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate IntPtr _JniMarshal_PPLZ_L(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate bool _JniMarshal_PPLZ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate IntPtr _JniMarshal_PPZ_L(IntPtr jnienv, IntPtr klass, bool p0);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
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
		private static string[] package_com_launchdarkly_sdk_android_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "com/launchdarkly/sdk/android" }, new Converter<string, Type>[1] { lookup_com_launchdarkly_sdk_android_package });
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

		private static Type lookup_com_launchdarkly_sdk_android_package(string klass)
		{
			if (package_com_launchdarkly_sdk_android_mappings == null)
			{
				package_com_launchdarkly_sdk_android_mappings = new string[1] { "com/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode:Com.Launchdarkly.Sdk.Android.ConnectionInformationConnectionMode" };
			}
			return Lookup(package_com_launchdarkly_sdk_android_mappings, klass);
		}
	}
}
namespace Com.Launchdarkly.Sdk
{
	[Register("com/launchdarkly/sdk/ArrayBuilder", DoNotGenerateAcw = true)]
	public sealed class ArrayBuilder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/ArrayBuilder", typeof(ArrayBuilder));

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

		internal ArrayBuilder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ArrayBuilder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("add", "(Z)Lcom/launchdarkly/sdk/ArrayBuilder;", "")]
		public unsafe ArrayBuilder Add(bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ArrayBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.(Z)Lcom/launchdarkly/sdk/ArrayBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("add", "(Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/ArrayBuilder;", "")]
		public unsafe ArrayBuilder Add(LDValue value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ArrayBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.(Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/ArrayBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}

		[Register("add", "(D)Lcom/launchdarkly/sdk/ArrayBuilder;", "")]
		public unsafe ArrayBuilder Add(double value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ArrayBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.(D)Lcom/launchdarkly/sdk/ArrayBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("add", "(F)Lcom/launchdarkly/sdk/ArrayBuilder;", "")]
		public unsafe ArrayBuilder Add(float value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ArrayBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.(F)Lcom/launchdarkly/sdk/ArrayBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("add", "(I)Lcom/launchdarkly/sdk/ArrayBuilder;", "")]
		public unsafe ArrayBuilder Add(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ArrayBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.(I)Lcom/launchdarkly/sdk/ArrayBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("add", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/ArrayBuilder;", "")]
		public unsafe ArrayBuilder Add(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ArrayBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/String;)Lcom/launchdarkly/sdk/ArrayBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("add", "(J)Lcom/launchdarkly/sdk/ArrayBuilder;", "")]
		public unsafe ArrayBuilder Add(long value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ArrayBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.(J)Lcom/launchdarkly/sdk/ArrayBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("build", "()Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe LDValue Build()
		{
			return Java.Lang.Object.GetObject<LDValue>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/launchdarkly/sdk/LDValue;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/sdk/EvaluationDetail", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public sealed class EvaluationDetail : Java.Lang.Object, IJsonSerializable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("NO_VARIATION")]
		public const int NoVariation = -1;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/EvaluationDetail", typeof(EvaluationDetail));

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

		public unsafe bool IsDefaultValue
		{
			[Register("isDefaultValue", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isDefaultValue.()Z", this, null);
			}
		}

		public unsafe EvaluationReason Reason
		{
			[Register("getReason", "()Lcom/launchdarkly/sdk/EvaluationReason;", "")]
			get
			{
				return Java.Lang.Object.GetObject<EvaluationReason>(_members.InstanceMethods.InvokeAbstractObjectMethod("getReason.()Lcom/launchdarkly/sdk/EvaluationReason;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Object Value
		{
			[Register("getValue", "()Ljava/lang/Object;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getValue.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int VariationIndex
		{
			[Register("getVariationIndex", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getVariationIndex.()I", this, null);
			}
		}

		internal EvaluationDetail(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("error", "(Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/EvaluationDetail;", "")]
		public unsafe static EvaluationDetail Error(EvaluationReason.ErrorKind errorKind, LDValue defaultValue)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(errorKind?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(defaultValue?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<EvaluationDetail>(_members.StaticMethods.InvokeObjectMethod("error.(Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/EvaluationDetail;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(errorKind);
				GC.KeepAlive(defaultValue);
			}
		}

		[Register("fromValue", "(Ljava/lang/Object;ILcom/launchdarkly/sdk/EvaluationReason;)Lcom/launchdarkly/sdk/EvaluationDetail;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static EvaluationDetail FromValue(Java.Lang.Object value, int variationIndex, EvaluationReason reason)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(variationIndex);
				ptr[2] = new JniArgumentValue(reason?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<EvaluationDetail>(_members.StaticMethods.InvokeObjectMethod("fromValue.(Ljava/lang/Object;ILcom/launchdarkly/sdk/EvaluationReason;)Lcom/launchdarkly/sdk/EvaluationDetail;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
				GC.KeepAlive(reason);
			}
		}
	}
	[Register("com/launchdarkly/sdk/EvaluationReason", DoNotGenerateAcw = true)]
	public sealed class EvaluationReason : Java.Lang.Object, IJsonSerializable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/launchdarkly/sdk/EvaluationReason$ErrorKind", DoNotGenerateAcw = true)]
		public sealed class ErrorKind : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/EvaluationReason$ErrorKind", typeof(ErrorKind));

			[Register("CLIENT_NOT_READY")]
			public static ErrorKind ClientNotReady => Java.Lang.Object.GetObject<ErrorKind>(_members.StaticFields.GetObjectValue("CLIENT_NOT_READY.Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("EXCEPTION")]
			public static ErrorKind Exception => Java.Lang.Object.GetObject<ErrorKind>(_members.StaticFields.GetObjectValue("EXCEPTION.Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("FLAG_NOT_FOUND")]
			public static ErrorKind FlagNotFound => Java.Lang.Object.GetObject<ErrorKind>(_members.StaticFields.GetObjectValue("FLAG_NOT_FOUND.Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MALFORMED_FLAG")]
			public static ErrorKind MalformedFlag => Java.Lang.Object.GetObject<ErrorKind>(_members.StaticFields.GetObjectValue("MALFORMED_FLAG.Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("USER_NOT_SPECIFIED")]
			public static ErrorKind UserNotSpecified => Java.Lang.Object.GetObject<ErrorKind>(_members.StaticFields.GetObjectValue("USER_NOT_SPECIFIED.Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("WRONG_TYPE")]
			public static ErrorKind WrongType => Java.Lang.Object.GetObject<ErrorKind>(_members.StaticFields.GetObjectValue("WRONG_TYPE.Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal ErrorKind(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;", "")]
			public unsafe static ErrorKind ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ErrorKind>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;", "")]
			public unsafe static ErrorKind[] Values()
			{
				return (ErrorKind[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ErrorKind));
			}
		}

		[Register("com/launchdarkly/sdk/EvaluationReason$Kind", DoNotGenerateAcw = true)]
		public sealed class Kind : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/EvaluationReason$Kind", typeof(Kind));

			[Register("ERROR")]
			public static Kind Error => Java.Lang.Object.GetObject<Kind>(_members.StaticFields.GetObjectValue("ERROR.Lcom/launchdarkly/sdk/EvaluationReason$Kind;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("FALLTHROUGH")]
			public static Kind Fallthrough => Java.Lang.Object.GetObject<Kind>(_members.StaticFields.GetObjectValue("FALLTHROUGH.Lcom/launchdarkly/sdk/EvaluationReason$Kind;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("OFF")]
			public static Kind Off => Java.Lang.Object.GetObject<Kind>(_members.StaticFields.GetObjectValue("OFF.Lcom/launchdarkly/sdk/EvaluationReason$Kind;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("PREREQUISITE_FAILED")]
			public static Kind PrerequisiteFailed => Java.Lang.Object.GetObject<Kind>(_members.StaticFields.GetObjectValue("PREREQUISITE_FAILED.Lcom/launchdarkly/sdk/EvaluationReason$Kind;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("RULE_MATCH")]
			public static Kind RuleMatch => Java.Lang.Object.GetObject<Kind>(_members.StaticFields.GetObjectValue("RULE_MATCH.Lcom/launchdarkly/sdk/EvaluationReason$Kind;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("TARGET_MATCH")]
			public static Kind TargetMatch => Java.Lang.Object.GetObject<Kind>(_members.StaticFields.GetObjectValue("TARGET_MATCH.Lcom/launchdarkly/sdk/EvaluationReason$Kind;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal Kind(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/EvaluationReason$Kind;", "")]
			public unsafe static Kind ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Kind>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/launchdarkly/sdk/EvaluationReason$Kind;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/launchdarkly/sdk/EvaluationReason$Kind;", "")]
			public unsafe static Kind[] Values()
			{
				return (Kind[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/launchdarkly/sdk/EvaluationReason$Kind;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Kind));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/EvaluationReason", typeof(EvaluationReason));

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

		public unsafe Java.Lang.Exception Exception
		{
			[Register("getException", "()Ljava/lang/Exception;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Exception>(_members.InstanceMethods.InvokeAbstractObjectMethod("getException.()Ljava/lang/Exception;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsInExperiment
		{
			[Register("isInExperiment", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isInExperiment.()Z", this, null);
			}
		}

		public unsafe string PrerequisiteKey
		{
			[Register("getPrerequisiteKey", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPrerequisiteKey.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string RuleId
		{
			[Register("getRuleId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getRuleId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int RuleIndex
		{
			[Register("getRuleIndex", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getRuleIndex.()I", this, null);
			}
		}

		internal EvaluationReason(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("error", "(Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;)Lcom/launchdarkly/sdk/EvaluationReason;", "")]
		public unsafe static EvaluationReason Error(ErrorKind errorKind)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(errorKind?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<EvaluationReason>(_members.StaticMethods.InvokeObjectMethod("error.(Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;)Lcom/launchdarkly/sdk/EvaluationReason;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(errorKind);
			}
		}

		[Register("exception", "(Ljava/lang/Exception;)Lcom/launchdarkly/sdk/EvaluationReason;", "")]
		public unsafe static EvaluationReason InvokeException(Java.Lang.Exception exception)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(exception?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<EvaluationReason>(_members.StaticMethods.InvokeObjectMethod("exception.(Ljava/lang/Exception;)Lcom/launchdarkly/sdk/EvaluationReason;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(exception);
			}
		}

		[Register("fallthrough", "()Lcom/launchdarkly/sdk/EvaluationReason;", "")]
		public unsafe static EvaluationReason Fallthrough()
		{
			return Java.Lang.Object.GetObject<EvaluationReason>(_members.StaticMethods.InvokeObjectMethod("fallthrough.()Lcom/launchdarkly/sdk/EvaluationReason;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("fallthrough", "(Z)Lcom/launchdarkly/sdk/EvaluationReason;", "")]
		public unsafe static EvaluationReason Fallthrough(bool inExperiment)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(inExperiment);
			return Java.Lang.Object.GetObject<EvaluationReason>(_members.StaticMethods.InvokeObjectMethod("fallthrough.(Z)Lcom/launchdarkly/sdk/EvaluationReason;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getErrorKind", "()Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;", "")]
		public unsafe ErrorKind GetErrorKind()
		{
			return Java.Lang.Object.GetObject<ErrorKind>(_members.InstanceMethods.InvokeAbstractObjectMethod("getErrorKind.()Lcom/launchdarkly/sdk/EvaluationReason$ErrorKind;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getKind", "()Lcom/launchdarkly/sdk/EvaluationReason$Kind;", "")]
		public unsafe Kind GetKind()
		{
			return Java.Lang.Object.GetObject<Kind>(_members.InstanceMethods.InvokeAbstractObjectMethod("getKind.()Lcom/launchdarkly/sdk/EvaluationReason$Kind;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("off", "()Lcom/launchdarkly/sdk/EvaluationReason;", "")]
		public unsafe static EvaluationReason Off()
		{
			return Java.Lang.Object.GetObject<EvaluationReason>(_members.StaticMethods.InvokeObjectMethod("off.()Lcom/launchdarkly/sdk/EvaluationReason;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("prerequisiteFailed", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/EvaluationReason;", "")]
		public unsafe static EvaluationReason PrerequisiteFailed(string prerequisiteKey)
		{
			IntPtr intPtr = JNIEnv.NewString(prerequisiteKey);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<EvaluationReason>(_members.StaticMethods.InvokeObjectMethod("prerequisiteFailed.(Ljava/lang/String;)Lcom/launchdarkly/sdk/EvaluationReason;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("ruleMatch", "(ILjava/lang/String;)Lcom/launchdarkly/sdk/EvaluationReason;", "")]
		public unsafe static EvaluationReason RuleMatch(int ruleIndex, string ruleId)
		{
			IntPtr intPtr = JNIEnv.NewString(ruleId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(ruleIndex);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<EvaluationReason>(_members.StaticMethods.InvokeObjectMethod("ruleMatch.(ILjava/lang/String;)Lcom/launchdarkly/sdk/EvaluationReason;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("ruleMatch", "(ILjava/lang/String;Z)Lcom/launchdarkly/sdk/EvaluationReason;", "")]
		public unsafe static EvaluationReason RuleMatch(int ruleIndex, string ruleId, bool inExperiment)
		{
			IntPtr intPtr = JNIEnv.NewString(ruleId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(ruleIndex);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(inExperiment);
				return Java.Lang.Object.GetObject<EvaluationReason>(_members.StaticMethods.InvokeObjectMethod("ruleMatch.(ILjava/lang/String;Z)Lcom/launchdarkly/sdk/EvaluationReason;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("targetMatch", "()Lcom/launchdarkly/sdk/EvaluationReason;", "")]
		public unsafe static EvaluationReason TargetMatch()
		{
			return Java.Lang.Object.GetObject<EvaluationReason>(_members.StaticMethods.InvokeObjectMethod("targetMatch.()Lcom/launchdarkly/sdk/EvaluationReason;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/sdk/LDUser", DoNotGenerateAcw = true)]
	public class LDUser : Java.Lang.Object, IJsonSerializable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/launchdarkly/sdk/LDUser$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/LDUser$Builder", typeof(Builder));

			private static Delegate cb_anonymous_Z;

			private static Delegate cb_avatar_Ljava_lang_String_;

			private static Delegate cb_build;

			private static Delegate cb_country_Ljava_lang_String_;

			private static Delegate cb_custom_Ljava_lang_String_Z;

			private static Delegate cb_custom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

			private static Delegate cb_custom_Ljava_lang_String_D;

			private static Delegate cb_custom_Ljava_lang_String_I;

			private static Delegate cb_custom_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_email_Ljava_lang_String_;

			private static Delegate cb_firstName_Ljava_lang_String_;

			private static Delegate cb_ip_Ljava_lang_String_;

			private static Delegate cb_key_Ljava_lang_String_;

			private static Delegate cb_lastName_Ljava_lang_String_;

			private static Delegate cb_name_Ljava_lang_String_;

			private static Delegate cb_privateAvatar_Ljava_lang_String_;

			private static Delegate cb_privateCountry_Ljava_lang_String_;

			private static Delegate cb_privateCustom_Ljava_lang_String_Z;

			private static Delegate cb_privateCustom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

			private static Delegate cb_privateCustom_Ljava_lang_String_D;

			private static Delegate cb_privateCustom_Ljava_lang_String_I;

			private static Delegate cb_privateCustom_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_privateEmail_Ljava_lang_String_;

			private static Delegate cb_privateFirstName_Ljava_lang_String_;

			private static Delegate cb_privateIp_Ljava_lang_String_;

			private static Delegate cb_privateLastName_Ljava_lang_String_;

			private static Delegate cb_privateName_Ljava_lang_String_;

			private static Delegate cb_privateSecondary_Ljava_lang_String_;

			private static Delegate cb_secondary_Ljava_lang_String_;

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

			protected Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lcom/launchdarkly/sdk/LDUser;)V", "")]
			public unsafe Builder(LDUser user)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(user?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/launchdarkly/sdk/LDUser;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/launchdarkly/sdk/LDUser;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(user);
				}
			}

			[Register(".ctor", "(Ljava/lang/String;)V", "")]
			public unsafe Builder(string key)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.NewString(key);
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

			private static Delegate GetAnonymous_ZHandler()
			{
				if ((object)cb_anonymous_Z == null)
				{
					cb_anonymous_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_Anonymous_Z));
				}
				return cb_anonymous_Z;
			}

			private static IntPtr n_Anonymous_Z(IntPtr jnienv, IntPtr native__this, bool anonymous)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Anonymous(anonymous));
			}

			[Register("anonymous", "(Z)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetAnonymous_ZHandler")]
			public unsafe virtual Builder Anonymous(bool anonymous)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(anonymous);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("anonymous.(Z)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetAvatar_Ljava_lang_String_Handler()
			{
				if ((object)cb_avatar_Ljava_lang_String_ == null)
				{
					cb_avatar_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Avatar_Ljava_lang_String_));
				}
				return cb_avatar_Ljava_lang_String_;
			}

			private static IntPtr n_Avatar_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_avatar)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string avatar = JNIEnv.GetString(native_avatar, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Avatar(avatar));
			}

			[Register("avatar", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetAvatar_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Avatar(string avatar)
			{
				IntPtr intPtr = JNIEnv.NewString(avatar);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("avatar.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetBuildHandler()
			{
				if ((object)cb_build == null)
				{
					cb_build = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
				}
				return cb_build;
			}

			private static IntPtr n_Build(IntPtr jnienv, IntPtr native__this)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Build());
			}

			[Register("build", "()Lcom/launchdarkly/sdk/LDUser;", "GetBuildHandler")]
			public unsafe virtual LDUser Build()
			{
				return Java.Lang.Object.GetObject<LDUser>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/launchdarkly/sdk/LDUser;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetCountry_Ljava_lang_String_Handler()
			{
				if ((object)cb_country_Ljava_lang_String_ == null)
				{
					cb_country_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Country_Ljava_lang_String_));
				}
				return cb_country_Ljava_lang_String_;
			}

			private static IntPtr n_Country_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_s)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string s = JNIEnv.GetString(native_s, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Country(s));
			}

			[Register("country", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetCountry_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Country(string s)
			{
				IntPtr intPtr = JNIEnv.NewString(s);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("country.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetCustom_Ljava_lang_String_ZHandler()
			{
				if ((object)cb_custom_Ljava_lang_String_Z == null)
				{
					cb_custom_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_Custom_Ljava_lang_String_Z));
				}
				return cb_custom_Ljava_lang_String_Z;
			}

			private static IntPtr n_Custom_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_k, bool b)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string k = JNIEnv.GetString(native_k, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Custom(k, b));
			}

			[Register("custom", "(Ljava/lang/String;Z)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetCustom_Ljava_lang_String_ZHandler")]
			public unsafe virtual Builder Custom(string k, bool b)
			{
				IntPtr intPtr = JNIEnv.NewString(k);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(b);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("custom.(Ljava/lang/String;Z)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetCustom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler()
			{
				if ((object)cb_custom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == null)
				{
					cb_custom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Custom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_));
				}
				return cb_custom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;
			}

			private static IntPtr n_Custom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_(IntPtr jnienv, IntPtr native__this, IntPtr native_k, IntPtr native_v)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string k = JNIEnv.GetString(native_k, JniHandleOwnership.DoNotTransfer);
				LDValue v = Java.Lang.Object.GetObject<LDValue>(native_v, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Custom(k, v));
			}

			[Register("custom", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetCustom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler")]
			public unsafe virtual Builder Custom(string k, LDValue v)
			{
				IntPtr intPtr = JNIEnv.NewString(k);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("custom.(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(v);
				}
			}

			private static Delegate GetCustom_Ljava_lang_String_DHandler()
			{
				if ((object)cb_custom_Ljava_lang_String_D == null)
				{
					cb_custom_Ljava_lang_String_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLD_L(n_Custom_Ljava_lang_String_D));
				}
				return cb_custom_Ljava_lang_String_D;
			}

			private static IntPtr n_Custom_Ljava_lang_String_D(IntPtr jnienv, IntPtr native__this, IntPtr native_k, double n)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string k = JNIEnv.GetString(native_k, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Custom(k, n));
			}

			[Register("custom", "(Ljava/lang/String;D)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetCustom_Ljava_lang_String_DHandler")]
			public unsafe virtual Builder Custom(string k, double n)
			{
				IntPtr intPtr = JNIEnv.NewString(k);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(n);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("custom.(Ljava/lang/String;D)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetCustom_Ljava_lang_String_IHandler()
			{
				if ((object)cb_custom_Ljava_lang_String_I == null)
				{
					cb_custom_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_Custom_Ljava_lang_String_I));
				}
				return cb_custom_Ljava_lang_String_I;
			}

			private static IntPtr n_Custom_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_k, int n)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string k = JNIEnv.GetString(native_k, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Custom(k, n));
			}

			[Register("custom", "(Ljava/lang/String;I)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetCustom_Ljava_lang_String_IHandler")]
			public unsafe virtual Builder Custom(string k, int n)
			{
				IntPtr intPtr = JNIEnv.NewString(k);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(n);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("custom.(Ljava/lang/String;I)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetCustom_Ljava_lang_String_Ljava_lang_String_Handler()
			{
				if ((object)cb_custom_Ljava_lang_String_Ljava_lang_String_ == null)
				{
					cb_custom_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Custom_Ljava_lang_String_Ljava_lang_String_));
				}
				return cb_custom_Ljava_lang_String_Ljava_lang_String_;
			}

			private static IntPtr n_Custom_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_k, IntPtr native_v)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string k = JNIEnv.GetString(native_k, JniHandleOwnership.DoNotTransfer);
				string v = JNIEnv.GetString(native_v, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Custom(k, v));
			}

			[Register("custom", "(Ljava/lang/String;Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetCustom_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Custom(string k, string v)
			{
				IntPtr intPtr = JNIEnv.NewString(k);
				IntPtr intPtr2 = JNIEnv.NewString(v);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("custom.(Ljava/lang/String;Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			private static Delegate GetEmail_Ljava_lang_String_Handler()
			{
				if ((object)cb_email_Ljava_lang_String_ == null)
				{
					cb_email_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Email_Ljava_lang_String_));
				}
				return cb_email_Ljava_lang_String_;
			}

			private static IntPtr n_Email_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_email)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string email = JNIEnv.GetString(native_email, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Email(email));
			}

			[Register("email", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetEmail_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Email(string email)
			{
				IntPtr intPtr = JNIEnv.NewString(email);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("email.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetFirstName_Ljava_lang_String_Handler()
			{
				if ((object)cb_firstName_Ljava_lang_String_ == null)
				{
					cb_firstName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_FirstName_Ljava_lang_String_));
				}
				return cb_firstName_Ljava_lang_String_;
			}

			private static IntPtr n_FirstName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_firstName)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string firstName = JNIEnv.GetString(native_firstName, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.FirstName(firstName));
			}

			[Register("firstName", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetFirstName_Ljava_lang_String_Handler")]
			public unsafe virtual Builder FirstName(string firstName)
			{
				IntPtr intPtr = JNIEnv.NewString(firstName);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("firstName.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetIp_Ljava_lang_String_Handler()
			{
				if ((object)cb_ip_Ljava_lang_String_ == null)
				{
					cb_ip_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Ip_Ljava_lang_String_));
				}
				return cb_ip_Ljava_lang_String_;
			}

			private static IntPtr n_Ip_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_s)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string s = JNIEnv.GetString(native_s, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Ip(s));
			}

			[Register("ip", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetIp_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Ip(string s)
			{
				IntPtr intPtr = JNIEnv.NewString(s);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("ip.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetKey_Ljava_lang_String_Handler()
			{
				if ((object)cb_key_Ljava_lang_String_ == null)
				{
					cb_key_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Key_Ljava_lang_String_));
				}
				return cb_key_Ljava_lang_String_;
			}

			private static IntPtr n_Key_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_s)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string s = JNIEnv.GetString(native_s, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Key(s));
			}

			[Register("key", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetKey_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Key(string s)
			{
				IntPtr intPtr = JNIEnv.NewString(s);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("key.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetLastName_Ljava_lang_String_Handler()
			{
				if ((object)cb_lastName_Ljava_lang_String_ == null)
				{
					cb_lastName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_LastName_Ljava_lang_String_));
				}
				return cb_lastName_Ljava_lang_String_;
			}

			private static IntPtr n_LastName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_lastName)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string lastName = JNIEnv.GetString(native_lastName, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.LastName(lastName));
			}

			[Register("lastName", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetLastName_Ljava_lang_String_Handler")]
			public unsafe virtual Builder LastName(string lastName)
			{
				IntPtr intPtr = JNIEnv.NewString(lastName);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("lastName.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Name(name));
			}

			[Register("name", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetName_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Name(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("name.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateAvatar_Ljava_lang_String_Handler()
			{
				if ((object)cb_privateAvatar_Ljava_lang_String_ == null)
				{
					cb_privateAvatar_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PrivateAvatar_Ljava_lang_String_));
				}
				return cb_privateAvatar_Ljava_lang_String_;
			}

			private static IntPtr n_PrivateAvatar_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_avatar)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string avatar = JNIEnv.GetString(native_avatar, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateAvatar(avatar));
			}

			[Register("privateAvatar", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateAvatar_Ljava_lang_String_Handler")]
			public unsafe virtual Builder PrivateAvatar(string avatar)
			{
				IntPtr intPtr = JNIEnv.NewString(avatar);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateAvatar.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateCountry_Ljava_lang_String_Handler()
			{
				if ((object)cb_privateCountry_Ljava_lang_String_ == null)
				{
					cb_privateCountry_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PrivateCountry_Ljava_lang_String_));
				}
				return cb_privateCountry_Ljava_lang_String_;
			}

			private static IntPtr n_PrivateCountry_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_s)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string s = JNIEnv.GetString(native_s, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateCountry(s));
			}

			[Register("privateCountry", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateCountry_Ljava_lang_String_Handler")]
			public unsafe virtual Builder PrivateCountry(string s)
			{
				IntPtr intPtr = JNIEnv.NewString(s);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateCountry.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateCustom_Ljava_lang_String_ZHandler()
			{
				if ((object)cb_privateCustom_Ljava_lang_String_Z == null)
				{
					cb_privateCustom_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_PrivateCustom_Ljava_lang_String_Z));
				}
				return cb_privateCustom_Ljava_lang_String_Z;
			}

			private static IntPtr n_PrivateCustom_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_k, bool b)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string k = JNIEnv.GetString(native_k, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateCustom(k, b));
			}

			[Register("privateCustom", "(Ljava/lang/String;Z)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateCustom_Ljava_lang_String_ZHandler")]
			public unsafe virtual Builder PrivateCustom(string k, bool b)
			{
				IntPtr intPtr = JNIEnv.NewString(k);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(b);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateCustom.(Ljava/lang/String;Z)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateCustom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler()
			{
				if ((object)cb_privateCustom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == null)
				{
					cb_privateCustom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PrivateCustom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_));
				}
				return cb_privateCustom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;
			}

			private static IntPtr n_PrivateCustom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_(IntPtr jnienv, IntPtr native__this, IntPtr native_k, IntPtr native_v)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string k = JNIEnv.GetString(native_k, JniHandleOwnership.DoNotTransfer);
				LDValue v = Java.Lang.Object.GetObject<LDValue>(native_v, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateCustom(k, v));
			}

			[Register("privateCustom", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateCustom_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler")]
			public unsafe virtual Builder PrivateCustom(string k, LDValue v)
			{
				IntPtr intPtr = JNIEnv.NewString(k);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateCustom.(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(v);
				}
			}

			private static Delegate GetPrivateCustom_Ljava_lang_String_DHandler()
			{
				if ((object)cb_privateCustom_Ljava_lang_String_D == null)
				{
					cb_privateCustom_Ljava_lang_String_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLD_L(n_PrivateCustom_Ljava_lang_String_D));
				}
				return cb_privateCustom_Ljava_lang_String_D;
			}

			private static IntPtr n_PrivateCustom_Ljava_lang_String_D(IntPtr jnienv, IntPtr native__this, IntPtr native_k, double n)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string k = JNIEnv.GetString(native_k, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateCustom(k, n));
			}

			[Register("privateCustom", "(Ljava/lang/String;D)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateCustom_Ljava_lang_String_DHandler")]
			public unsafe virtual Builder PrivateCustom(string k, double n)
			{
				IntPtr intPtr = JNIEnv.NewString(k);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(n);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateCustom.(Ljava/lang/String;D)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateCustom_Ljava_lang_String_IHandler()
			{
				if ((object)cb_privateCustom_Ljava_lang_String_I == null)
				{
					cb_privateCustom_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_PrivateCustom_Ljava_lang_String_I));
				}
				return cb_privateCustom_Ljava_lang_String_I;
			}

			private static IntPtr n_PrivateCustom_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_k, int n)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string k = JNIEnv.GetString(native_k, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateCustom(k, n));
			}

			[Register("privateCustom", "(Ljava/lang/String;I)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateCustom_Ljava_lang_String_IHandler")]
			public unsafe virtual Builder PrivateCustom(string k, int n)
			{
				IntPtr intPtr = JNIEnv.NewString(k);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(n);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateCustom.(Ljava/lang/String;I)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateCustom_Ljava_lang_String_Ljava_lang_String_Handler()
			{
				if ((object)cb_privateCustom_Ljava_lang_String_Ljava_lang_String_ == null)
				{
					cb_privateCustom_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PrivateCustom_Ljava_lang_String_Ljava_lang_String_));
				}
				return cb_privateCustom_Ljava_lang_String_Ljava_lang_String_;
			}

			private static IntPtr n_PrivateCustom_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_k, IntPtr native_v)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string k = JNIEnv.GetString(native_k, JniHandleOwnership.DoNotTransfer);
				string v = JNIEnv.GetString(native_v, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateCustom(k, v));
			}

			[Register("privateCustom", "(Ljava/lang/String;Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateCustom_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe virtual Builder PrivateCustom(string k, string v)
			{
				IntPtr intPtr = JNIEnv.NewString(k);
				IntPtr intPtr2 = JNIEnv.NewString(v);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateCustom.(Ljava/lang/String;Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			private static Delegate GetPrivateEmail_Ljava_lang_String_Handler()
			{
				if ((object)cb_privateEmail_Ljava_lang_String_ == null)
				{
					cb_privateEmail_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PrivateEmail_Ljava_lang_String_));
				}
				return cb_privateEmail_Ljava_lang_String_;
			}

			private static IntPtr n_PrivateEmail_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_email)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string email = JNIEnv.GetString(native_email, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateEmail(email));
			}

			[Register("privateEmail", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateEmail_Ljava_lang_String_Handler")]
			public unsafe virtual Builder PrivateEmail(string email)
			{
				IntPtr intPtr = JNIEnv.NewString(email);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateEmail.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateFirstName_Ljava_lang_String_Handler()
			{
				if ((object)cb_privateFirstName_Ljava_lang_String_ == null)
				{
					cb_privateFirstName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PrivateFirstName_Ljava_lang_String_));
				}
				return cb_privateFirstName_Ljava_lang_String_;
			}

			private static IntPtr n_PrivateFirstName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_firstName)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string firstName = JNIEnv.GetString(native_firstName, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateFirstName(firstName));
			}

			[Register("privateFirstName", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateFirstName_Ljava_lang_String_Handler")]
			public unsafe virtual Builder PrivateFirstName(string firstName)
			{
				IntPtr intPtr = JNIEnv.NewString(firstName);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateFirstName.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateIp_Ljava_lang_String_Handler()
			{
				if ((object)cb_privateIp_Ljava_lang_String_ == null)
				{
					cb_privateIp_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PrivateIp_Ljava_lang_String_));
				}
				return cb_privateIp_Ljava_lang_String_;
			}

			private static IntPtr n_PrivateIp_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_s)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string s = JNIEnv.GetString(native_s, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateIp(s));
			}

			[Register("privateIp", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateIp_Ljava_lang_String_Handler")]
			public unsafe virtual Builder PrivateIp(string s)
			{
				IntPtr intPtr = JNIEnv.NewString(s);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateIp.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateLastName_Ljava_lang_String_Handler()
			{
				if ((object)cb_privateLastName_Ljava_lang_String_ == null)
				{
					cb_privateLastName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PrivateLastName_Ljava_lang_String_));
				}
				return cb_privateLastName_Ljava_lang_String_;
			}

			private static IntPtr n_PrivateLastName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_lastName)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string lastName = JNIEnv.GetString(native_lastName, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateLastName(lastName));
			}

			[Register("privateLastName", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateLastName_Ljava_lang_String_Handler")]
			public unsafe virtual Builder PrivateLastName(string lastName)
			{
				IntPtr intPtr = JNIEnv.NewString(lastName);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateLastName.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateName_Ljava_lang_String_Handler()
			{
				if ((object)cb_privateName_Ljava_lang_String_ == null)
				{
					cb_privateName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PrivateName_Ljava_lang_String_));
				}
				return cb_privateName_Ljava_lang_String_;
			}

			private static IntPtr n_PrivateName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateName(name));
			}

			[Register("privateName", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateName_Ljava_lang_String_Handler")]
			public unsafe virtual Builder PrivateName(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateName.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPrivateSecondary_Ljava_lang_String_Handler()
			{
				if ((object)cb_privateSecondary_Ljava_lang_String_ == null)
				{
					cb_privateSecondary_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PrivateSecondary_Ljava_lang_String_));
				}
				return cb_privateSecondary_Ljava_lang_String_;
			}

			private static IntPtr n_PrivateSecondary_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_s)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string s = JNIEnv.GetString(native_s, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PrivateSecondary(s));
			}

			[Register("privateSecondary", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetPrivateSecondary_Ljava_lang_String_Handler")]
			public unsafe virtual Builder PrivateSecondary(string s)
			{
				IntPtr intPtr = JNIEnv.NewString(s);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateSecondary.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSecondary_Ljava_lang_String_Handler()
			{
				if ((object)cb_secondary_Ljava_lang_String_ == null)
				{
					cb_secondary_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Secondary_Ljava_lang_String_));
				}
				return cb_secondary_Ljava_lang_String_;
			}

			private static IntPtr n_Secondary_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_s)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string s = JNIEnv.GetString(native_s, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Secondary(s));
			}

			[Register("secondary", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", "GetSecondary_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Secondary(string s)
			{
				IntPtr intPtr = JNIEnv.NewString(s);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("secondary.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDUser$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/LDUser", typeof(LDUser));

		private static Delegate cb_getAvatar;

		private static Delegate cb_getCountry;

		private static Delegate cb_getCustomAttributes;

		private static Delegate cb_getEmail;

		private static Delegate cb_getFirstName;

		private static Delegate cb_getIp;

		private static Delegate cb_isAnonymous;

		private static Delegate cb_getKey;

		private static Delegate cb_getLastName;

		private static Delegate cb_getName;

		private static Delegate cb_getPrivateAttributes;

		private static Delegate cb_getSecondary;

		private static Delegate cb_getAttribute_Lcom_launchdarkly_sdk_UserAttribute_;

		private static Delegate cb_isAttributePrivate_Lcom_launchdarkly_sdk_UserAttribute_;

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

		public unsafe virtual string Avatar
		{
			[Register("getAvatar", "()Ljava/lang/String;", "GetGetAvatarHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getAvatar.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Country
		{
			[Register("getCountry", "()Ljava/lang/String;", "GetGetCountryHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getCountry.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IIterable CustomAttributes
		{
			[Register("getCustomAttributes", "()Ljava/lang/Iterable;", "GetGetCustomAttributesHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IIterable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCustomAttributes.()Ljava/lang/Iterable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Email
		{
			[Register("getEmail", "()Ljava/lang/String;", "GetGetEmailHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEmail.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string FirstName
		{
			[Register("getFirstName", "()Ljava/lang/String;", "GetGetFirstNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getFirstName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Ip
		{
			[Register("getIp", "()Ljava/lang/String;", "GetGetIpHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getIp.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsAnonymous
		{
			[Register("isAnonymous", "()Z", "GetIsAnonymousHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAnonymous.()Z", this, null);
			}
		}

		public unsafe virtual string Key
		{
			[Register("getKey", "()Ljava/lang/String;", "GetGetKeyHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getKey.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string LastName
		{
			[Register("getLastName", "()Ljava/lang/String;", "GetGetLastNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getLastName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IIterable PrivateAttributes
		{
			[Register("getPrivateAttributes", "()Ljava/lang/Iterable;", "GetGetPrivateAttributesHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IIterable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrivateAttributes.()Ljava/lang/Iterable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Secondary
		{
			[Register("getSecondary", "()Ljava/lang/String;", "GetGetSecondaryHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSecondary.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LDUser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/launchdarkly/sdk/LDUser$Builder;)V", "")]
		protected unsafe LDUser(Builder builder)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/launchdarkly/sdk/LDUser$Builder;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/launchdarkly/sdk/LDUser$Builder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe LDUser(string key)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(key);
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

		private static Delegate GetGetAvatarHandler()
		{
			if ((object)cb_getAvatar == null)
			{
				cb_getAvatar = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAvatar));
			}
			return cb_getAvatar;
		}

		private static IntPtr n_GetAvatar(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDUser.Avatar);
		}

		private static Delegate GetGetCountryHandler()
		{
			if ((object)cb_getCountry == null)
			{
				cb_getCountry = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCountry));
			}
			return cb_getCountry;
		}

		private static IntPtr n_GetCountry(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDUser.Country);
		}

		private static Delegate GetGetCustomAttributesHandler()
		{
			if ((object)cb_getCustomAttributes == null)
			{
				cb_getCustomAttributes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCustomAttributes));
			}
			return cb_getCustomAttributes;
		}

		private static IntPtr n_GetCustomAttributes(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDUser.CustomAttributes);
		}

		private static Delegate GetGetEmailHandler()
		{
			if ((object)cb_getEmail == null)
			{
				cb_getEmail = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEmail));
			}
			return cb_getEmail;
		}

		private static IntPtr n_GetEmail(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDUser.Email);
		}

		private static Delegate GetGetFirstNameHandler()
		{
			if ((object)cb_getFirstName == null)
			{
				cb_getFirstName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFirstName));
			}
			return cb_getFirstName;
		}

		private static IntPtr n_GetFirstName(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDUser.FirstName);
		}

		private static Delegate GetGetIpHandler()
		{
			if ((object)cb_getIp == null)
			{
				cb_getIp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetIp));
			}
			return cb_getIp;
		}

		private static IntPtr n_GetIp(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDUser.Ip);
		}

		private static Delegate GetIsAnonymousHandler()
		{
			if ((object)cb_isAnonymous == null)
			{
				cb_isAnonymous = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAnonymous));
			}
			return cb_isAnonymous;
		}

		private static bool n_IsAnonymous(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDUser.IsAnonymous;
		}

		private static Delegate GetGetKeyHandler()
		{
			if ((object)cb_getKey == null)
			{
				cb_getKey = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetKey));
			}
			return cb_getKey;
		}

		private static IntPtr n_GetKey(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDUser.Key);
		}

		private static Delegate GetGetLastNameHandler()
		{
			if ((object)cb_getLastName == null)
			{
				cb_getLastName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLastName));
			}
			return cb_getLastName;
		}

		private static IntPtr n_GetLastName(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDUser.LastName);
		}

		private static Delegate GetGetNameHandler()
		{
			if ((object)cb_getName == null)
			{
				cb_getName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetName));
			}
			return cb_getName;
		}

		private static IntPtr n_GetName(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDUser.Name);
		}

		private static Delegate GetGetPrivateAttributesHandler()
		{
			if ((object)cb_getPrivateAttributes == null)
			{
				cb_getPrivateAttributes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPrivateAttributes));
			}
			return cb_getPrivateAttributes;
		}

		private static IntPtr n_GetPrivateAttributes(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDUser.PrivateAttributes);
		}

		private static Delegate GetGetSecondaryHandler()
		{
			if ((object)cb_getSecondary == null)
			{
				cb_getSecondary = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSecondary));
			}
			return cb_getSecondary;
		}

		private static IntPtr n_GetSecondary(IntPtr jnienv, IntPtr native__this)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDUser.Secondary);
		}

		private static Delegate GetGetAttribute_Lcom_launchdarkly_sdk_UserAttribute_Handler()
		{
			if ((object)cb_getAttribute_Lcom_launchdarkly_sdk_UserAttribute_ == null)
			{
				cb_getAttribute_Lcom_launchdarkly_sdk_UserAttribute_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetAttribute_Lcom_launchdarkly_sdk_UserAttribute_));
			}
			return cb_getAttribute_Lcom_launchdarkly_sdk_UserAttribute_;
		}

		private static IntPtr n_GetAttribute_Lcom_launchdarkly_sdk_UserAttribute_(IntPtr jnienv, IntPtr native__this, IntPtr native_attribute)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UserAttribute attribute = Java.Lang.Object.GetObject<UserAttribute>(native_attribute, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDUser.GetAttribute(attribute));
		}

		[Register("getAttribute", "(Lcom/launchdarkly/sdk/UserAttribute;)Lcom/launchdarkly/sdk/LDValue;", "GetGetAttribute_Lcom_launchdarkly_sdk_UserAttribute_Handler")]
		public unsafe virtual LDValue GetAttribute(UserAttribute attribute)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(attribute?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LDValue>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAttribute.(Lcom/launchdarkly/sdk/UserAttribute;)Lcom/launchdarkly/sdk/LDValue;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(attribute);
			}
		}

		private static Delegate GetIsAttributePrivate_Lcom_launchdarkly_sdk_UserAttribute_Handler()
		{
			if ((object)cb_isAttributePrivate_Lcom_launchdarkly_sdk_UserAttribute_ == null)
			{
				cb_isAttributePrivate_Lcom_launchdarkly_sdk_UserAttribute_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsAttributePrivate_Lcom_launchdarkly_sdk_UserAttribute_));
			}
			return cb_isAttributePrivate_Lcom_launchdarkly_sdk_UserAttribute_;
		}

		private static bool n_IsAttributePrivate_Lcom_launchdarkly_sdk_UserAttribute_(IntPtr jnienv, IntPtr native__this, IntPtr native_attribute)
		{
			LDUser lDUser = Java.Lang.Object.GetObject<LDUser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UserAttribute attribute = Java.Lang.Object.GetObject<UserAttribute>(native_attribute, JniHandleOwnership.DoNotTransfer);
			return lDUser.IsAttributePrivate(attribute);
		}

		[Register("isAttributePrivate", "(Lcom/launchdarkly/sdk/UserAttribute;)Z", "GetIsAttributePrivate_Lcom_launchdarkly_sdk_UserAttribute_Handler")]
		public unsafe virtual bool IsAttributePrivate(UserAttribute attribute)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(attribute?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAttributePrivate.(Lcom/launchdarkly/sdk/UserAttribute;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(attribute);
			}
		}
	}
	[Register("com/launchdarkly/sdk/LDValue", DoNotGenerateAcw = true)]
	public abstract class LDValue : Java.Lang.Object, IJsonSerializable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/launchdarkly/sdk/LDValue$Convert", DoNotGenerateAcw = true)]
		public abstract class Convert : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/LDValue$Convert", typeof(Convert));

			[Register("Boolean")]
			public static Converter Boolean => Java.Lang.Object.GetObject<Converter>(_members.StaticFields.GetObjectValue("Boolean.Lcom/launchdarkly/sdk/LDValue$Converter;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("Double")]
			public static Converter Double => Java.Lang.Object.GetObject<Converter>(_members.StaticFields.GetObjectValue("Double.Lcom/launchdarkly/sdk/LDValue$Converter;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("Float")]
			public static Converter Float => Java.Lang.Object.GetObject<Converter>(_members.StaticFields.GetObjectValue("Float.Lcom/launchdarkly/sdk/LDValue$Converter;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("Integer")]
			public static Converter Integer => Java.Lang.Object.GetObject<Converter>(_members.StaticFields.GetObjectValue("Integer.Lcom/launchdarkly/sdk/LDValue$Converter;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("Long")]
			public static Converter Long => Java.Lang.Object.GetObject<Converter>(_members.StaticFields.GetObjectValue("Long.Lcom/launchdarkly/sdk/LDValue$Converter;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("String")]
			public static Converter String => Java.Lang.Object.GetObject<Converter>(_members.StaticFields.GetObjectValue("String.Lcom/launchdarkly/sdk/LDValue$Converter;").Handle, JniHandleOwnership.TransferLocalRef);

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

			protected Convert(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/launchdarkly/sdk/LDValue$Convert", DoNotGenerateAcw = true)]
		internal class ConvertInvoker : Convert
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/LDValue$Convert", typeof(ConvertInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public ConvertInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		[Register("com/launchdarkly/sdk/LDValue$Converter", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "T" })]
		public abstract class Converter : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/LDValue$Converter", typeof(Converter));

			private static Delegate cb_arrayFrom_Ljava_lang_Iterable_;

			private static Delegate cb_arrayOf_arrayLjava_lang_Object_;

			private static Delegate cb_fromType_Ljava_lang_Object_;

			private static Delegate cb_objectFrom_Ljava_util_Map_;

			private static Delegate cb_toType_Lcom_launchdarkly_sdk_LDValue_;

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

			protected Converter(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Converter()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetArrayFrom_Ljava_lang_Iterable_Handler()
			{
				if ((object)cb_arrayFrom_Ljava_lang_Iterable_ == null)
				{
					cb_arrayFrom_Ljava_lang_Iterable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ArrayFrom_Ljava_lang_Iterable_));
				}
				return cb_arrayFrom_Ljava_lang_Iterable_;
			}

			private static IntPtr n_ArrayFrom_Ljava_lang_Iterable_(IntPtr jnienv, IntPtr native__this, IntPtr native_values)
			{
				Converter converter = Java.Lang.Object.GetObject<Converter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IIterable values = Java.Lang.Object.GetObject<IIterable>(native_values, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(converter.ArrayFrom(values));
			}

			[Register("arrayFrom", "(Ljava/lang/Iterable;)Lcom/launchdarkly/sdk/LDValue;", "GetArrayFrom_Ljava_lang_Iterable_Handler")]
			public unsafe virtual LDValue ArrayFrom(IIterable values)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((values == null) ? IntPtr.Zero : ((Java.Lang.Object)values).Handle);
					return Java.Lang.Object.GetObject<LDValue>(_members.InstanceMethods.InvokeVirtualObjectMethod("arrayFrom.(Ljava/lang/Iterable;)Lcom/launchdarkly/sdk/LDValue;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(values);
				}
			}

			private static Delegate GetArrayOf_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_arrayOf_arrayLjava_lang_Object_ == null)
				{
					cb_arrayOf_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ArrayOf_arrayLjava_lang_Object_));
				}
				return cb_arrayOf_arrayLjava_lang_Object_;
			}

			private static IntPtr n_ArrayOf_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_values)
			{
				Converter converter = Java.Lang.Object.GetObject<Converter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_values, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				IntPtr result = JNIEnv.ToLocalJniHandle(converter.ArrayOf(array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_values);
				}
				return result;
			}

			[Register("arrayOf", "([Ljava/lang/Object;)Lcom/launchdarkly/sdk/LDValue;", "GetArrayOf_arrayLjava_lang_Object_Handler")]
			public unsafe virtual LDValue ArrayOf(params Java.Lang.Object[] values)
			{
				IntPtr intPtr = JNIEnv.NewArray(values);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<LDValue>(_members.InstanceMethods.InvokeVirtualObjectMethod("arrayOf.([Ljava/lang/Object;)Lcom/launchdarkly/sdk/LDValue;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (values != null)
					{
						JNIEnv.CopyArray(intPtr, values);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(values);
				}
			}

			private static Delegate GetFromType_Ljava_lang_Object_Handler()
			{
				if ((object)cb_fromType_Ljava_lang_Object_ == null)
				{
					cb_fromType_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_FromType_Ljava_lang_Object_));
				}
				return cb_fromType_Ljava_lang_Object_;
			}

			private static IntPtr n_FromType_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Converter converter = Java.Lang.Object.GetObject<Converter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(converter.FromType(p));
			}

			[Register("fromType", "(Ljava/lang/Object;)Lcom/launchdarkly/sdk/LDValue;", "GetFromType_Ljava_lang_Object_Handler")]
			public abstract LDValue FromType(Java.Lang.Object p0);

			private static Delegate GetObjectFrom_Ljava_util_Map_Handler()
			{
				if ((object)cb_objectFrom_Ljava_util_Map_ == null)
				{
					cb_objectFrom_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ObjectFrom_Ljava_util_Map_));
				}
				return cb_objectFrom_Ljava_util_Map_;
			}

			private static IntPtr n_ObjectFrom_Ljava_util_Map_(IntPtr jnienv, IntPtr native__this, IntPtr native_map)
			{
				Converter converter = Java.Lang.Object.GetObject<Converter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDictionary map = JavaDictionary.FromJniHandle(native_map, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(converter.ObjectFrom(map));
			}

			[Register("objectFrom", "(Ljava/util/Map;)Lcom/launchdarkly/sdk/LDValue;", "GetObjectFrom_Ljava_util_Map_Handler")]
			public unsafe virtual LDValue ObjectFrom(IDictionary map)
			{
				IntPtr intPtr = JavaDictionary.ToLocalJniHandle(map);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<LDValue>(_members.InstanceMethods.InvokeVirtualObjectMethod("objectFrom.(Ljava/util/Map;)Lcom/launchdarkly/sdk/LDValue;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(map);
				}
			}

			private static Delegate GetToType_Lcom_launchdarkly_sdk_LDValue_Handler()
			{
				if ((object)cb_toType_Lcom_launchdarkly_sdk_LDValue_ == null)
				{
					cb_toType_Lcom_launchdarkly_sdk_LDValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ToType_Lcom_launchdarkly_sdk_LDValue_));
				}
				return cb_toType_Lcom_launchdarkly_sdk_LDValue_;
			}

			private static IntPtr n_ToType_Lcom_launchdarkly_sdk_LDValue_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Converter converter = Java.Lang.Object.GetObject<Converter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				LDValue p = Java.Lang.Object.GetObject<LDValue>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(converter.ToType(p));
			}

			[Register("toType", "(Lcom/launchdarkly/sdk/LDValue;)Ljava/lang/Object;", "GetToType_Lcom_launchdarkly_sdk_LDValue_Handler")]
			public abstract Java.Lang.Object ToType(LDValue p0);
		}

		[Register("com/launchdarkly/sdk/LDValue$Converter", DoNotGenerateAcw = true)]
		internal class ConverterInvoker : Converter
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/LDValue$Converter", typeof(ConverterInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public ConverterInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("fromType", "(Ljava/lang/Object;)Lcom/launchdarkly/sdk/LDValue;", "GetFromType_Ljava_lang_Object_Handler")]
			public unsafe override LDValue FromType(Java.Lang.Object p0)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<LDValue>(_members.InstanceMethods.InvokeAbstractObjectMethod("fromType.(Ljava/lang/Object;)Lcom/launchdarkly/sdk/LDValue;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(p0);
				}
			}

			[Register("toType", "(Lcom/launchdarkly/sdk/LDValue;)Ljava/lang/Object;", "GetToType_Lcom_launchdarkly_sdk_LDValue_Handler")]
			public unsafe override Java.Lang.Object ToType(LDValue p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("toType.(Lcom/launchdarkly/sdk/LDValue;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/LDValue", typeof(LDValue));

		private static Delegate cb_isInt;

		private static Delegate cb_isNull;

		private static Delegate cb_isNumber;

		private static Delegate cb_isString;

		private static Delegate cb_getType;

		private static Delegate cb_booleanValue;

		private static Delegate cb_doubleValue;

		private static Delegate cb_floatValue;

		private static Delegate cb_get_I;

		private static Delegate cb_get_Ljava_lang_String_;

		private static Delegate cb_intValue;

		private static Delegate cb_keys;

		private static Delegate cb_longValue;

		private static Delegate cb_size;

		private static Delegate cb_stringValue;

		private static Delegate cb_toJsonString;

		private static Delegate cb_values;

		private static Delegate cb_valuesAs_Lcom_launchdarkly_sdk_LDValue_Converter_;

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

		public unsafe virtual bool IsInt
		{
			[Register("isInt", "()Z", "GetIsIntHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInt.()Z", this, null);
			}
		}

		public unsafe virtual bool IsNull
		{
			[Register("isNull", "()Z", "GetIsNullHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isNull.()Z", this, null);
			}
		}

		public unsafe virtual bool IsNumber
		{
			[Register("isNumber", "()Z", "GetIsNumberHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isNumber.()Z", this, null);
			}
		}

		public unsafe virtual bool IsString
		{
			[Register("isString", "()Z", "GetIsStringHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isString.()Z", this, null);
			}
		}

		public abstract LDValueType Type
		{
			[Register("getType", "()Lcom/launchdarkly/sdk/LDValueType;", "GetGetTypeHandler")]
			get;
		}

		protected LDValue(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LDValue()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsIntHandler()
		{
			if ((object)cb_isInt == null)
			{
				cb_isInt = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInt));
			}
			return cb_isInt;
		}

		private static bool n_IsInt(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDValue.IsInt;
		}

		private static Delegate GetIsNullHandler()
		{
			if ((object)cb_isNull == null)
			{
				cb_isNull = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsNull));
			}
			return cb_isNull;
		}

		private static bool n_IsNull(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDValue.IsNull;
		}

		private static Delegate GetIsNumberHandler()
		{
			if ((object)cb_isNumber == null)
			{
				cb_isNumber = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsNumber));
			}
			return cb_isNumber;
		}

		private static bool n_IsNumber(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDValue.IsNumber;
		}

		private static Delegate GetIsStringHandler()
		{
			if ((object)cb_isString == null)
			{
				cb_isString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsString));
			}
			return cb_isString;
		}

		private static bool n_IsString(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDValue.IsString;
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
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDValue.Type);
		}

		[Register("arrayOf", "([Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe static LDValue ArrayOf(params LDValue[] values)
		{
			IntPtr intPtr = JNIEnv.NewArray(values);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LDValue>(_members.StaticMethods.InvokeObjectMethod("arrayOf.([Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDValue;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (values != null)
				{
					JNIEnv.CopyArray(intPtr, values);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(values);
			}
		}

		private static Delegate GetBooleanValueHandler()
		{
			if ((object)cb_booleanValue == null)
			{
				cb_booleanValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_BooleanValue));
			}
			return cb_booleanValue;
		}

		private static bool n_BooleanValue(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDValue.BooleanValue();
		}

		[Register("booleanValue", "()Z", "GetBooleanValueHandler")]
		public unsafe virtual bool BooleanValue()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("booleanValue.()Z", this, null);
		}

		[Register("buildArray", "()Lcom/launchdarkly/sdk/ArrayBuilder;", "")]
		public unsafe static ArrayBuilder BuildArray()
		{
			return Java.Lang.Object.GetObject<ArrayBuilder>(_members.StaticMethods.InvokeObjectMethod("buildArray.()Lcom/launchdarkly/sdk/ArrayBuilder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("buildObject", "()Lcom/launchdarkly/sdk/ObjectBuilder;", "")]
		public unsafe static ObjectBuilder BuildObject()
		{
			return Java.Lang.Object.GetObject<ObjectBuilder>(_members.StaticMethods.InvokeObjectMethod("buildObject.()Lcom/launchdarkly/sdk/ObjectBuilder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetDoubleValueHandler()
		{
			if ((object)cb_doubleValue == null)
			{
				cb_doubleValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_DoubleValue));
			}
			return cb_doubleValue;
		}

		private static double n_DoubleValue(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDValue.DoubleValue();
		}

		[Register("doubleValue", "()D", "GetDoubleValueHandler")]
		public unsafe virtual double DoubleValue()
		{
			return _members.InstanceMethods.InvokeVirtualDoubleMethod("doubleValue.()D", this, null);
		}

		private static Delegate GetFloatValueHandler()
		{
			if ((object)cb_floatValue == null)
			{
				cb_floatValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_FloatValue));
			}
			return cb_floatValue;
		}

		private static float n_FloatValue(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDValue.FloatValue();
		}

		[Register("floatValue", "()F", "GetFloatValueHandler")]
		public unsafe virtual float FloatValue()
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("floatValue.()F", this, null);
		}

		private static Delegate GetGet_IHandler()
		{
			if ((object)cb_get_I == null)
			{
				cb_get_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_Get_I));
			}
			return cb_get_I;
		}

		private static IntPtr n_Get_I(IntPtr jnienv, IntPtr native__this, int index)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDValue.Get(index));
		}

		[Register("get", "(I)Lcom/launchdarkly/sdk/LDValue;", "GetGet_IHandler")]
		public unsafe virtual LDValue Get(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return Java.Lang.Object.GetObject<LDValue>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(I)Lcom/launchdarkly/sdk/LDValue;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGet_Ljava_lang_String_Handler()
		{
			if ((object)cb_get_Ljava_lang_String_ == null)
			{
				cb_get_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Ljava_lang_String_));
			}
			return cb_get_Ljava_lang_String_;
		}

		private static IntPtr n_Get_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDValue.Get(name));
		}

		[Register("get", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDValue;", "GetGet_Ljava_lang_String_Handler")]
		public unsafe virtual LDValue Get(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LDValue>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDValue;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetIntValueHandler()
		{
			if ((object)cb_intValue == null)
			{
				cb_intValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_IntValue));
			}
			return cb_intValue;
		}

		private static int n_IntValue(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDValue.IntValue();
		}

		[Register("intValue", "()I", "GetIntValueHandler")]
		public unsafe virtual int IntValue()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("intValue.()I", this, null);
		}

		private static Delegate GetKeysHandler()
		{
			if ((object)cb_keys == null)
			{
				cb_keys = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Keys));
			}
			return cb_keys;
		}

		private static IntPtr n_Keys(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDValue.Keys());
		}

		[Register("keys", "()Ljava/lang/Iterable;", "GetKeysHandler")]
		public unsafe virtual IIterable Keys()
		{
			return Java.Lang.Object.GetObject<IIterable>(_members.InstanceMethods.InvokeVirtualObjectMethod("keys.()Ljava/lang/Iterable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetLongValueHandler()
		{
			if ((object)cb_longValue == null)
			{
				cb_longValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_LongValue));
			}
			return cb_longValue;
		}

		private static long n_LongValue(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDValue.LongValue();
		}

		[Register("longValue", "()J", "GetLongValueHandler")]
		public unsafe virtual long LongValue()
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("longValue.()J", this, null);
		}

		[Register("normalize", "(Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe static LDValue Normalize(LDValue value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LDValue>(_members.StaticMethods.InvokeObjectMethod("normalize.(Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDValue;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}

		[Register("of", "(Z)Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe static LDValue Of(bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<LDValue>(_members.StaticMethods.InvokeObjectMethod("of.(Z)Lcom/launchdarkly/sdk/LDValue;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("of", "(D)Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe static LDValue Of(double value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<LDValue>(_members.StaticMethods.InvokeObjectMethod("of.(D)Lcom/launchdarkly/sdk/LDValue;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("of", "(F)Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe static LDValue Of(float value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<LDValue>(_members.StaticMethods.InvokeObjectMethod("of.(F)Lcom/launchdarkly/sdk/LDValue;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("of", "(I)Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe static LDValue Of(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<LDValue>(_members.StaticMethods.InvokeObjectMethod("of.(I)Lcom/launchdarkly/sdk/LDValue;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("of", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe static LDValue Of(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LDValue>(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDValue;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("of", "(J)Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe static LDValue Of(long value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<LDValue>(_members.StaticMethods.InvokeObjectMethod("of.(J)Lcom/launchdarkly/sdk/LDValue;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("ofNull", "()Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe static LDValue OfNull()
		{
			return Java.Lang.Object.GetObject<LDValue>(_members.StaticMethods.InvokeObjectMethod("ofNull.()Lcom/launchdarkly/sdk/LDValue;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("parse", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe static LDValue Parse(string json)
		{
			IntPtr intPtr = JNIEnv.NewString(json);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LDValue>(_members.StaticMethods.InvokeObjectMethod("parse.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDValue;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSizeHandler()
		{
			if ((object)cb_size == null)
			{
				cb_size = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_Size));
			}
			return cb_size;
		}

		private static int n_Size(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDValue.Size();
		}

		[Register("size", "()I", "GetSizeHandler")]
		public unsafe virtual int Size()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("size.()I", this, null);
		}

		private static Delegate GetStringValueHandler()
		{
			if ((object)cb_stringValue == null)
			{
				cb_stringValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_StringValue));
			}
			return cb_stringValue;
		}

		private static IntPtr n_StringValue(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDValue.StringValue());
		}

		[Register("stringValue", "()Ljava/lang/String;", "GetStringValueHandler")]
		public unsafe virtual string StringValue()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("stringValue.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetToJsonStringHandler()
		{
			if ((object)cb_toJsonString == null)
			{
				cb_toJsonString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJsonString));
			}
			return cb_toJsonString;
		}

		private static IntPtr n_ToJsonString(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDValue.ToJsonString());
		}

		[Register("toJsonString", "()Ljava/lang/String;", "GetToJsonStringHandler")]
		public unsafe virtual string ToJsonString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("toJsonString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetValuesHandler()
		{
			if ((object)cb_values == null)
			{
				cb_values = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Values));
			}
			return cb_values;
		}

		private static IntPtr n_Values(IntPtr jnienv, IntPtr native__this)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDValue.Values());
		}

		[Register("values", "()Ljava/lang/Iterable;", "GetValuesHandler")]
		public unsafe virtual IIterable Values()
		{
			return Java.Lang.Object.GetObject<IIterable>(_members.InstanceMethods.InvokeVirtualObjectMethod("values.()Ljava/lang/Iterable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetValuesAs_Lcom_launchdarkly_sdk_LDValue_Converter_Handler()
		{
			if ((object)cb_valuesAs_Lcom_launchdarkly_sdk_LDValue_Converter_ == null)
			{
				cb_valuesAs_Lcom_launchdarkly_sdk_LDValue_Converter_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ValuesAs_Lcom_launchdarkly_sdk_LDValue_Converter_));
			}
			return cb_valuesAs_Lcom_launchdarkly_sdk_LDValue_Converter_;
		}

		private static IntPtr n_ValuesAs_Lcom_launchdarkly_sdk_LDValue_Converter_(IntPtr jnienv, IntPtr native__this, IntPtr native_converter)
		{
			LDValue lDValue = Java.Lang.Object.GetObject<LDValue>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Converter converter = Java.Lang.Object.GetObject<Converter>(native_converter, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDValue.ValuesAs(converter));
		}

		[Register("valuesAs", "(Lcom/launchdarkly/sdk/LDValue$Converter;)Ljava/lang/Iterable;", "GetValuesAs_Lcom_launchdarkly_sdk_LDValue_Converter_Handler")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe virtual IIterable ValuesAs(Converter converter)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(converter?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IIterable>(_members.InstanceMethods.InvokeVirtualObjectMethod("valuesAs.(Lcom/launchdarkly/sdk/LDValue$Converter;)Ljava/lang/Iterable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(converter);
			}
		}
	}
	[Register("com/launchdarkly/sdk/LDValue", DoNotGenerateAcw = true)]
	internal class LDValueInvoker : LDValue
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/LDValue", typeof(LDValueInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override LDValueType Type
		{
			[Register("getType", "()Lcom/launchdarkly/sdk/LDValueType;", "GetGetTypeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LDValueType>(_members.InstanceMethods.InvokeAbstractObjectMethod("getType.()Lcom/launchdarkly/sdk/LDValueType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public LDValueInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/launchdarkly/sdk/LDValueType", DoNotGenerateAcw = true)]
	public sealed class LDValueType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/LDValueType", typeof(LDValueType));

		[Register("ARRAY")]
		public static LDValueType Array => Java.Lang.Object.GetObject<LDValueType>(_members.StaticFields.GetObjectValue("ARRAY.Lcom/launchdarkly/sdk/LDValueType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("BOOLEAN")]
		public static LDValueType Boolean => Java.Lang.Object.GetObject<LDValueType>(_members.StaticFields.GetObjectValue("BOOLEAN.Lcom/launchdarkly/sdk/LDValueType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NULL")]
		public static LDValueType Null => Java.Lang.Object.GetObject<LDValueType>(_members.StaticFields.GetObjectValue("NULL.Lcom/launchdarkly/sdk/LDValueType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NUMBER")]
		public static LDValueType Number => Java.Lang.Object.GetObject<LDValueType>(_members.StaticFields.GetObjectValue("NUMBER.Lcom/launchdarkly/sdk/LDValueType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OBJECT")]
		public static LDValueType Object => Java.Lang.Object.GetObject<LDValueType>(_members.StaticFields.GetObjectValue("OBJECT.Lcom/launchdarkly/sdk/LDValueType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STRING")]
		public static LDValueType String => Java.Lang.Object.GetObject<LDValueType>(_members.StaticFields.GetObjectValue("STRING.Lcom/launchdarkly/sdk/LDValueType;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal LDValueType(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDValueType;", "")]
		public unsafe static LDValueType ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LDValueType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/launchdarkly/sdk/LDValueType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/launchdarkly/sdk/LDValueType;", "")]
		public unsafe static LDValueType[] Values()
		{
			return (LDValueType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/launchdarkly/sdk/LDValueType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(LDValueType));
		}
	}
	[Register("com/launchdarkly/sdk/ObjectBuilder", DoNotGenerateAcw = true)]
	public sealed class ObjectBuilder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/ObjectBuilder", typeof(ObjectBuilder));

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

		internal ObjectBuilder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ObjectBuilder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("build", "()Lcom/launchdarkly/sdk/LDValue;", "")]
		public unsafe LDValue Build()
		{
			return Java.Lang.Object.GetObject<LDValue>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/launchdarkly/sdk/LDValue;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("put", "(Ljava/lang/String;Z)Lcom/launchdarkly/sdk/ObjectBuilder;", "")]
		public unsafe ObjectBuilder Put(string key, bool value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<ObjectBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("put.(Ljava/lang/String;Z)Lcom/launchdarkly/sdk/ObjectBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("put", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/ObjectBuilder;", "")]
		public unsafe ObjectBuilder Put(string key, LDValue value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ObjectBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("put.(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/ObjectBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("put", "(Ljava/lang/String;D)Lcom/launchdarkly/sdk/ObjectBuilder;", "")]
		public unsafe ObjectBuilder Put(string key, double value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<ObjectBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("put.(Ljava/lang/String;D)Lcom/launchdarkly/sdk/ObjectBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("put", "(Ljava/lang/String;F)Lcom/launchdarkly/sdk/ObjectBuilder;", "")]
		public unsafe ObjectBuilder Put(string key, float value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<ObjectBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("put.(Ljava/lang/String;F)Lcom/launchdarkly/sdk/ObjectBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("put", "(Ljava/lang/String;I)Lcom/launchdarkly/sdk/ObjectBuilder;", "")]
		public unsafe ObjectBuilder Put(string key, int value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<ObjectBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("put.(Ljava/lang/String;I)Lcom/launchdarkly/sdk/ObjectBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("put", "(Ljava/lang/String;Ljava/lang/String;)Lcom/launchdarkly/sdk/ObjectBuilder;", "")]
		public unsafe ObjectBuilder Put(string key, string value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			IntPtr intPtr2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<ObjectBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("put.(Ljava/lang/String;Ljava/lang/String;)Lcom/launchdarkly/sdk/ObjectBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("put", "(Ljava/lang/String;J)Lcom/launchdarkly/sdk/ObjectBuilder;", "")]
		public unsafe ObjectBuilder Put(string key, long value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<ObjectBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("put.(Ljava/lang/String;J)Lcom/launchdarkly/sdk/ObjectBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/launchdarkly/sdk/UserAttribute", DoNotGenerateAcw = true)]
	public sealed class UserAttribute : Java.Lang.Object, IJsonSerializable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/UserAttribute", typeof(UserAttribute));

		[Register("ANONYMOUS")]
		public static UserAttribute Anonymous => Java.Lang.Object.GetObject<UserAttribute>(_members.StaticFields.GetObjectValue("ANONYMOUS.Lcom/launchdarkly/sdk/UserAttribute;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("AVATAR")]
		public static UserAttribute Avatar => Java.Lang.Object.GetObject<UserAttribute>(_members.StaticFields.GetObjectValue("AVATAR.Lcom/launchdarkly/sdk/UserAttribute;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("COUNTRY")]
		public static UserAttribute Country => Java.Lang.Object.GetObject<UserAttribute>(_members.StaticFields.GetObjectValue("COUNTRY.Lcom/launchdarkly/sdk/UserAttribute;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EMAIL")]
		public static UserAttribute Email => Java.Lang.Object.GetObject<UserAttribute>(_members.StaticFields.GetObjectValue("EMAIL.Lcom/launchdarkly/sdk/UserAttribute;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FIRST_NAME")]
		public static UserAttribute FirstName => Java.Lang.Object.GetObject<UserAttribute>(_members.StaticFields.GetObjectValue("FIRST_NAME.Lcom/launchdarkly/sdk/UserAttribute;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("IP")]
		public static UserAttribute Ip => Java.Lang.Object.GetObject<UserAttribute>(_members.StaticFields.GetObjectValue("IP.Lcom/launchdarkly/sdk/UserAttribute;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("KEY")]
		public static UserAttribute Key => Java.Lang.Object.GetObject<UserAttribute>(_members.StaticFields.GetObjectValue("KEY.Lcom/launchdarkly/sdk/UserAttribute;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LAST_NAME")]
		public static UserAttribute LastName => Java.Lang.Object.GetObject<UserAttribute>(_members.StaticFields.GetObjectValue("LAST_NAME.Lcom/launchdarkly/sdk/UserAttribute;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SECONDARY_KEY")]
		public static UserAttribute SecondaryKey => Java.Lang.Object.GetObject<UserAttribute>(_members.StaticFields.GetObjectValue("SECONDARY_KEY.Lcom/launchdarkly/sdk/UserAttribute;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe bool IsBuiltIn
		{
			[Register("isBuiltIn", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isBuiltIn.()Z", this, null);
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

		internal UserAttribute(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("forName", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/UserAttribute;", "")]
		public unsafe static UserAttribute ForName(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<UserAttribute>(_members.StaticMethods.InvokeObjectMethod("forName.(Ljava/lang/String;)Lcom/launchdarkly/sdk/UserAttribute;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
}
namespace Com.Launchdarkly.Sdk.Json
{
	[Register("com/launchdarkly/sdk/json/JsonSerializable", "", "Com.Launchdarkly.Sdk.Json.IJsonSerializableInvoker")]
	public interface IJsonSerializable : IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/launchdarkly/sdk/json/JsonSerializable", DoNotGenerateAcw = true)]
	internal class IJsonSerializableInvoker : Java.Lang.Object, IJsonSerializable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/json/JsonSerializable", typeof(IJsonSerializableInvoker));

		private IntPtr class_ref;

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

		public static IJsonSerializable GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IJsonSerializable>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.json.JsonSerializable'.");
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

		public IJsonSerializableInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}
	}
	[Register("com/launchdarkly/sdk/json/JsonSerialization", DoNotGenerateAcw = true)]
	public abstract class JsonSerialization : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/json/JsonSerialization", typeof(JsonSerialization));

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

		protected JsonSerialization(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("deserialize", "(Ljava/lang/String;Ljava/lang/Class;)Lcom/launchdarkly/sdk/json/JsonSerializable;", "")]
		[JavaTypeParameters(new string[] { "T extends com.launchdarkly.sdk.json.JsonSerializable" })]
		public unsafe static Java.Lang.Object Deserialize(string json, Class objectClass)
		{
			IntPtr intPtr = JNIEnv.NewString(json);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(objectClass?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("deserialize.(Ljava/lang/String;Ljava/lang/Class;)Lcom/launchdarkly/sdk/json/JsonSerializable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(objectClass);
			}
		}

		[Register("serialize", "(Lcom/launchdarkly/sdk/json/JsonSerializable;)Ljava/lang/String;", "")]
		[JavaTypeParameters(new string[] { "T extends com.launchdarkly.sdk.json.JsonSerializable" })]
		public unsafe static string Serialize(Java.Lang.Object instance)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(instance);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("serialize.(Lcom/launchdarkly/sdk/json/JsonSerializable;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(instance);
			}
		}
	}
	[Register("com/launchdarkly/sdk/json/JsonSerialization", DoNotGenerateAcw = true)]
	internal class JsonSerializationInvoker : JsonSerialization
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/json/JsonSerialization", typeof(JsonSerializationInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public JsonSerializationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/launchdarkly/sdk/json/LDGson", DoNotGenerateAcw = true)]
	public abstract class LDGson : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/json/LDGson", typeof(LDGson));

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

		protected LDGson(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/launchdarkly/sdk/json/LDGson", DoNotGenerateAcw = true)]
	internal class LDGsonInvoker : LDGson
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/json/LDGson", typeof(LDGsonInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public LDGsonInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/launchdarkly/sdk/json/LDJackson", DoNotGenerateAcw = true)]
	public class LDJackson : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/json/LDJackson", typeof(LDJackson));

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

		protected LDJackson(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/launchdarkly/sdk/json/SerializationException", DoNotGenerateAcw = true)]
	public class SerializationException : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/json/SerializationException", typeof(SerializationException));

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

		protected SerializationException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Throwable;)V", "")]
		public unsafe SerializationException(Throwable cause)
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
}
namespace Com.Launchdarkly.Sdk.Android
{
	[Register("com/launchdarkly/sdk/android/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("LIBRARY_PACKAGE_NAME")]
		public const string LibraryPackageName = "com.launchdarkly.sdk.android";

		[Register("VERSION_NAME")]
		public const string VersionName = "3.6.0";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/BuildConfig", typeof(BuildConfig));

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

		internal BuildConfig(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BuildConfig()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/launchdarkly/sdk/android/Components", DoNotGenerateAcw = true)]
	public abstract class Components : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/Components", typeof(Components));

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

		protected Components(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("applicationInfo", "()Lcom/launchdarkly/sdk/android/integrations/ApplicationInfoBuilder;", "")]
		public unsafe static ApplicationInfoBuilder ApplicationInfo()
		{
			return Java.Lang.Object.GetObject<ApplicationInfoBuilder>(_members.StaticMethods.InvokeObjectMethod("applicationInfo.()Lcom/launchdarkly/sdk/android/integrations/ApplicationInfoBuilder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("noEvents", "()Lcom/launchdarkly/sdk/android/subsystems/ComponentConfigurer;", "")]
		public unsafe static IComponentConfigurer NoEvents()
		{
			return Java.Lang.Object.GetObject<IComponentConfigurer>(_members.StaticMethods.InvokeObjectMethod("noEvents.()Lcom/launchdarkly/sdk/android/subsystems/ComponentConfigurer;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("serviceEndpoints", "()Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "")]
		public unsafe static ServiceEndpointsBuilder ServiceEndpoints()
		{
			return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.StaticMethods.InvokeObjectMethod("serviceEndpoints.()Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/sdk/android/Components", DoNotGenerateAcw = true)]
	internal class ComponentsInvoker : Components
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/Components", typeof(ComponentsInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ComponentsInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/launchdarkly/sdk/android/ConnectivityReceiver", DoNotGenerateAcw = true)]
	public class ConnectivityReceiver : BroadcastReceiver
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/ConnectivityReceiver", typeof(ConnectivityReceiver));

		private static Delegate cb_onReceive_Landroid_content_Context_Landroid_content_Intent_;

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

		protected ConnectivityReceiver(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ConnectivityReceiver()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler()
		{
			if ((object)cb_onReceive_Landroid_content_Context_Landroid_content_Intent_ == null)
			{
				cb_onReceive_Landroid_content_Context_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnReceive_Landroid_content_Context_Landroid_content_Intent_));
			}
			return cb_onReceive_Landroid_content_Context_Landroid_content_Intent_;
		}

		private static void n_OnReceive_Landroid_content_Context_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_intent)
		{
			ConnectivityReceiver connectivityReceiver = Java.Lang.Object.GetObject<ConnectivityReceiver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			connectivityReceiver.OnReceive(context, intent);
		}

		[Register("onReceive", "(Landroid/content/Context;Landroid/content/Intent;)V", "GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler")]
		public unsafe override void OnReceive(Context context, Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onReceive.(Landroid/content/Context;Landroid/content/Intent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode", DoNotGenerateAcw = true)]
	public sealed class ConnectionInformationConnectionMode : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode", typeof(ConnectionInformationConnectionMode));

		[Register("BACKGROUND_DISABLED")]
		public static ConnectionInformationConnectionMode BackgroundDisabled => Java.Lang.Object.GetObject<ConnectionInformationConnectionMode>(_members.StaticFields.GetObjectValue("BACKGROUND_DISABLED.Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("BACKGROUND_POLLING")]
		public static ConnectionInformationConnectionMode BackgroundPolling => Java.Lang.Object.GetObject<ConnectionInformationConnectionMode>(_members.StaticFields.GetObjectValue("BACKGROUND_POLLING.Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OFFLINE")]
		public static ConnectionInformationConnectionMode Offline => Java.Lang.Object.GetObject<ConnectionInformationConnectionMode>(_members.StaticFields.GetObjectValue("OFFLINE.Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("POLLING")]
		public static ConnectionInformationConnectionMode Polling => Java.Lang.Object.GetObject<ConnectionInformationConnectionMode>(_members.StaticFields.GetObjectValue("POLLING.Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SET_OFFLINE")]
		public static ConnectionInformationConnectionMode SetOffline => Java.Lang.Object.GetObject<ConnectionInformationConnectionMode>(_members.StaticFields.GetObjectValue("SET_OFFLINE.Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SHUTDOWN")]
		public static ConnectionInformationConnectionMode Shutdown => Java.Lang.Object.GetObject<ConnectionInformationConnectionMode>(_members.StaticFields.GetObjectValue("SHUTDOWN.Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STREAMING")]
		public static ConnectionInformationConnectionMode Streaming => Java.Lang.Object.GetObject<ConnectionInformationConnectionMode>(_members.StaticFields.GetObjectValue("STREAMING.Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal ConnectionInformationConnectionMode(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;", "")]
		public unsafe static ConnectionInformationConnectionMode ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ConnectionInformationConnectionMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;", "")]
		public unsafe static ConnectionInformationConnectionMode[] Values()
		{
			return (ConnectionInformationConnectionMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ConnectionInformationConnectionMode));
		}
	}
	[Register("com/launchdarkly/sdk/android/ConnectionInformation", "", "Com.Launchdarkly.Sdk.Android.IConnectionInformationInvoker")]
	public interface IConnectionInformation : IJavaObject, IDisposable, IJavaPeerable
	{
		ConnectionInformationConnectionMode ConnectionMode
		{
			[Register("getConnectionMode", "()Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;", "GetGetConnectionModeHandler:Com.Launchdarkly.Sdk.Android.IConnectionInformationInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		Long LastFailedConnection
		{
			[Register("getLastFailedConnection", "()Ljava/lang/Long;", "GetGetLastFailedConnectionHandler:Com.Launchdarkly.Sdk.Android.IConnectionInformationInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		LDFailure LastFailure
		{
			[Register("getLastFailure", "()Lcom/launchdarkly/sdk/android/LDFailure;", "GetGetLastFailureHandler:Com.Launchdarkly.Sdk.Android.IConnectionInformationInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		Long LastSuccessfulConnection
		{
			[Register("getLastSuccessfulConnection", "()Ljava/lang/Long;", "GetGetLastSuccessfulConnectionHandler:Com.Launchdarkly.Sdk.Android.IConnectionInformationInvoker, LaunchDarklyAndroidBinding")]
			get;
		}
	}
	[Register("com/launchdarkly/sdk/android/ConnectionInformation", DoNotGenerateAcw = true)]
	internal class IConnectionInformationInvoker : Java.Lang.Object, IConnectionInformation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/ConnectionInformation", typeof(IConnectionInformationInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getConnectionMode;

		private IntPtr id_getConnectionMode;

		private static Delegate cb_getLastFailedConnection;

		private IntPtr id_getLastFailedConnection;

		private static Delegate cb_getLastFailure;

		private IntPtr id_getLastFailure;

		private static Delegate cb_getLastSuccessfulConnection;

		private IntPtr id_getLastSuccessfulConnection;

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

		public ConnectionInformationConnectionMode ConnectionMode
		{
			get
			{
				if (id_getConnectionMode == IntPtr.Zero)
				{
					id_getConnectionMode = JNIEnv.GetMethodID(class_ref, "getConnectionMode", "()Lcom/launchdarkly/sdk/android/ConnectionInformation$ConnectionMode;");
				}
				return Java.Lang.Object.GetObject<ConnectionInformationConnectionMode>(JNIEnv.CallObjectMethod(base.Handle, id_getConnectionMode), JniHandleOwnership.TransferLocalRef);
			}
		}

		public Long LastFailedConnection
		{
			get
			{
				if (id_getLastFailedConnection == IntPtr.Zero)
				{
					id_getLastFailedConnection = JNIEnv.GetMethodID(class_ref, "getLastFailedConnection", "()Ljava/lang/Long;");
				}
				return Java.Lang.Object.GetObject<Long>(JNIEnv.CallObjectMethod(base.Handle, id_getLastFailedConnection), JniHandleOwnership.TransferLocalRef);
			}
		}

		public LDFailure LastFailure
		{
			get
			{
				if (id_getLastFailure == IntPtr.Zero)
				{
					id_getLastFailure = JNIEnv.GetMethodID(class_ref, "getLastFailure", "()Lcom/launchdarkly/sdk/android/LDFailure;");
				}
				return Java.Lang.Object.GetObject<LDFailure>(JNIEnv.CallObjectMethod(base.Handle, id_getLastFailure), JniHandleOwnership.TransferLocalRef);
			}
		}

		public Long LastSuccessfulConnection
		{
			get
			{
				if (id_getLastSuccessfulConnection == IntPtr.Zero)
				{
					id_getLastSuccessfulConnection = JNIEnv.GetMethodID(class_ref, "getLastSuccessfulConnection", "()Ljava/lang/Long;");
				}
				return Java.Lang.Object.GetObject<Long>(JNIEnv.CallObjectMethod(base.Handle, id_getLastSuccessfulConnection), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IConnectionInformation GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IConnectionInformation>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.android.ConnectionInformation'.");
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

		public IConnectionInformationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetConnectionModeHandler()
		{
			if ((object)cb_getConnectionMode == null)
			{
				cb_getConnectionMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConnectionMode));
			}
			return cb_getConnectionMode;
		}

		private static IntPtr n_GetConnectionMode(IntPtr jnienv, IntPtr native__this)
		{
			IConnectionInformation connectionInformation = Java.Lang.Object.GetObject<IConnectionInformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(connectionInformation.ConnectionMode);
		}

		private static Delegate GetGetLastFailedConnectionHandler()
		{
			if ((object)cb_getLastFailedConnection == null)
			{
				cb_getLastFailedConnection = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLastFailedConnection));
			}
			return cb_getLastFailedConnection;
		}

		private static IntPtr n_GetLastFailedConnection(IntPtr jnienv, IntPtr native__this)
		{
			IConnectionInformation connectionInformation = Java.Lang.Object.GetObject<IConnectionInformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(connectionInformation.LastFailedConnection);
		}

		private static Delegate GetGetLastFailureHandler()
		{
			if ((object)cb_getLastFailure == null)
			{
				cb_getLastFailure = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLastFailure));
			}
			return cb_getLastFailure;
		}

		private static IntPtr n_GetLastFailure(IntPtr jnienv, IntPtr native__this)
		{
			IConnectionInformation connectionInformation = Java.Lang.Object.GetObject<IConnectionInformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(connectionInformation.LastFailure);
		}

		private static Delegate GetGetLastSuccessfulConnectionHandler()
		{
			if ((object)cb_getLastSuccessfulConnection == null)
			{
				cb_getLastSuccessfulConnection = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLastSuccessfulConnection));
			}
			return cb_getLastSuccessfulConnection;
		}

		private static IntPtr n_GetLastSuccessfulConnection(IntPtr jnienv, IntPtr native__this)
		{
			IConnectionInformation connectionInformation = Java.Lang.Object.GetObject<IConnectionInformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(connectionInformation.LastSuccessfulConnection);
		}
	}
	[Register("com/launchdarkly/sdk/android/FeatureFlagChangeListener", "", "Com.Launchdarkly.Sdk.Android.IFeatureFlagChangeListenerInvoker")]
	public interface IFeatureFlagChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onFeatureFlagChange", "(Ljava/lang/String;)V", "GetOnFeatureFlagChange_Ljava_lang_String_Handler:Com.Launchdarkly.Sdk.Android.IFeatureFlagChangeListenerInvoker, LaunchDarklyAndroidBinding")]
		void OnFeatureFlagChange(string p0);
	}
	[Register("com/launchdarkly/sdk/android/FeatureFlagChangeListener", DoNotGenerateAcw = true)]
	internal class IFeatureFlagChangeListenerInvoker : Java.Lang.Object, IFeatureFlagChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/FeatureFlagChangeListener", typeof(IFeatureFlagChangeListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onFeatureFlagChange_Ljava_lang_String_;

		private IntPtr id_onFeatureFlagChange_Ljava_lang_String_;

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

		public static IFeatureFlagChangeListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFeatureFlagChangeListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.android.FeatureFlagChangeListener'.");
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

		public IFeatureFlagChangeListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnFeatureFlagChange_Ljava_lang_String_Handler()
		{
			if ((object)cb_onFeatureFlagChange_Ljava_lang_String_ == null)
			{
				cb_onFeatureFlagChange_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFeatureFlagChange_Ljava_lang_String_));
			}
			return cb_onFeatureFlagChange_Ljava_lang_String_;
		}

		private static void n_OnFeatureFlagChange_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IFeatureFlagChangeListener featureFlagChangeListener = Java.Lang.Object.GetObject<IFeatureFlagChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			featureFlagChangeListener.OnFeatureFlagChange(p);
		}

		public unsafe void OnFeatureFlagChange(string p0)
		{
			if (id_onFeatureFlagChange_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onFeatureFlagChange_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onFeatureFlagChange", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onFeatureFlagChange_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	public class FeatureFlagChangeEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public FeatureFlagChangeEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	[Register("mono/com/launchdarkly/sdk/android/FeatureFlagChangeListenerImplementor")]
	internal sealed class IFeatureFlagChangeListenerImplementor : Java.Lang.Object, IFeatureFlagChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<FeatureFlagChangeEventArgs> Handler;

		public IFeatureFlagChangeListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/launchdarkly/sdk/android/FeatureFlagChangeListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnFeatureFlagChange(string p0)
		{
			Handler?.Invoke(sender, new FeatureFlagChangeEventArgs(p0));
		}

		internal static bool __IsEmpty(IFeatureFlagChangeListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
	[Register("com/launchdarkly/sdk/android/LDAllFlagsListener", "", "Com.Launchdarkly.Sdk.Android.ILDAllFlagsListenerInvoker")]
	public interface ILDAllFlagsListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onChange", "(Ljava/util/List;)V", "GetOnChange_Ljava_util_List_Handler:Com.Launchdarkly.Sdk.Android.ILDAllFlagsListenerInvoker, LaunchDarklyAndroidBinding")]
		void OnChange(IList<string> p0);
	}
	[Register("com/launchdarkly/sdk/android/LDAllFlagsListener", DoNotGenerateAcw = true)]
	internal class ILDAllFlagsListenerInvoker : Java.Lang.Object, ILDAllFlagsListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDAllFlagsListener", typeof(ILDAllFlagsListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onChange_Ljava_util_List_;

		private IntPtr id_onChange_Ljava_util_List_;

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

		public static ILDAllFlagsListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILDAllFlagsListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.android.LDAllFlagsListener'.");
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

		public ILDAllFlagsListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnChange_Ljava_util_List_Handler()
		{
			if ((object)cb_onChange_Ljava_util_List_ == null)
			{
				cb_onChange_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnChange_Ljava_util_List_));
			}
			return cb_onChange_Ljava_util_List_;
		}

		private static void n_OnChange_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDAllFlagsListener iLDAllFlagsListener = Java.Lang.Object.GetObject<ILDAllFlagsListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> p = JavaList<string>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
			iLDAllFlagsListener.OnChange(p);
		}

		public unsafe void OnChange(IList<string> p0)
		{
			if (id_onChange_Ljava_util_List_ == IntPtr.Zero)
			{
				id_onChange_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "onChange", "(Ljava/util/List;)V");
			}
			IntPtr intPtr = JavaList<string>.ToLocalJniHandle(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onChange_Ljava_util_List_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	public class LDAllFlagsEventArgs : EventArgs
	{
		private IList<string> p0;

		public IList<string> P0 => p0;

		public LDAllFlagsEventArgs(IList<string> p0)
		{
			this.p0 = p0;
		}
	}
	[Register("mono/com/launchdarkly/sdk/android/LDAllFlagsListenerImplementor")]
	internal sealed class ILDAllFlagsListenerImplementor : Java.Lang.Object, ILDAllFlagsListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<LDAllFlagsEventArgs> Handler;

		public ILDAllFlagsListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/launchdarkly/sdk/android/LDAllFlagsListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnChange(IList<string> p0)
		{
			Handler?.Invoke(sender, new LDAllFlagsEventArgs(p0));
		}

		internal static bool __IsEmpty(ILDAllFlagsListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
	[Register("com/launchdarkly/sdk/android/LDClientInterface", "", "Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker")]
	public interface ILDClientInterface : ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		IConnectionInformation ConnectionInformation
		{
			[Register("getConnectionInformation", "()Lcom/launchdarkly/sdk/android/ConnectionInformation;", "GetGetConnectionInformationHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		bool IsDisableBackgroundPolling
		{
			[Register("isDisableBackgroundPolling", "()Z", "GetIsDisableBackgroundPollingHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		bool IsInitialized
		{
			[Register("isInitialized", "()Z", "GetIsInitializedHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		bool IsOffline
		{
			[Register("isOffline", "()Z", "GetIsOfflineHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		string Version
		{
			[Register("getVersion", "()Ljava/lang/String;", "GetGetVersionHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		[Register("allFlags", "()Ljava/util/Map;", "GetAllFlagsHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		IDictionary<string, LDValue> AllFlags();

		[Register("boolVariation", "(Ljava/lang/String;Z)Z", "GetBoolVariation_Ljava_lang_String_ZHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		bool BoolVariation(string p0, bool p1);

		[Register("boolVariationDetail", "(Ljava/lang/String;Z)Lcom/launchdarkly/sdk/EvaluationDetail;", "GetBoolVariationDetail_Ljava_lang_String_ZHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		EvaluationDetail BoolVariationDetail(string p0, bool p1);

		[Register("doubleVariation", "(Ljava/lang/String;D)D", "GetDoubleVariation_Ljava_lang_String_DHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		double DoubleVariation(string p0, double p1);

		[Register("doubleVariationDetail", "(Ljava/lang/String;D)Lcom/launchdarkly/sdk/EvaluationDetail;", "GetDoubleVariationDetail_Ljava_lang_String_DHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		EvaluationDetail DoubleVariationDetail(string p0, double p1);

		[Register("flush", "()V", "GetFlushHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void Flush();

		[Register("identify", "(Lcom/launchdarkly/sdk/LDUser;)Ljava/util/concurrent/Future;", "GetIdentify_Lcom_launchdarkly_sdk_LDUser_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		IFuture Identify(LDUser p0);

		[Register("intVariation", "(Ljava/lang/String;I)I", "GetIntVariation_Ljava_lang_String_IHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		int IntVariation(string p0, int p1);

		[Register("intVariationDetail", "(Ljava/lang/String;I)Lcom/launchdarkly/sdk/EvaluationDetail;", "GetIntVariationDetail_Ljava_lang_String_IHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		EvaluationDetail IntVariationDetail(string p0, int p1);

		[Register("jsonValueVariation", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDValue;", "GetJsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		LDValue JsonValueVariation(string p0, LDValue p1);

		[Register("jsonValueVariationDetail", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/EvaluationDetail;", "GetJsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		EvaluationDetail JsonValueVariationDetail(string p0, LDValue p1);

		[Register("registerAllFlagsListener", "(Lcom/launchdarkly/sdk/android/LDAllFlagsListener;)V", "GetRegisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void RegisterAllFlagsListener(ILDAllFlagsListener p0);

		[Register("registerFeatureFlagListener", "(Ljava/lang/String;Lcom/launchdarkly/sdk/android/FeatureFlagChangeListener;)V", "GetRegisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void RegisterFeatureFlagListener(string p0, IFeatureFlagChangeListener p1);

		[Register("registerStatusListener", "(Lcom/launchdarkly/sdk/android/LDStatusListener;)V", "GetRegisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void RegisterStatusListener(ILDStatusListener p0);

		[Register("setOffline", "()V", "GetSetOfflineHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void SetOffline();

		[Register("setOnline", "()V", "GetSetOnlineHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void SetOnline();

		[Register("stringVariation", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "GetStringVariation_Ljava_lang_String_Ljava_lang_String_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		string StringVariation(string p0, string p1);

		[Register("stringVariationDetail", "(Ljava/lang/String;Ljava/lang/String;)Lcom/launchdarkly/sdk/EvaluationDetail;", "GetStringVariationDetail_Ljava_lang_String_Ljava_lang_String_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		EvaluationDetail StringVariationDetail(string p0, string p1);

		[Register("track", "(Ljava/lang/String;)V", "GetTrack_Ljava_lang_String_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void Track(string p0);

		[Register("trackData", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)V", "GetTrackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void TrackData(string p0, LDValue p1);

		[Register("trackMetric", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;D)V", "GetTrackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_DHandler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void TrackMetric(string p0, LDValue p1, double p2);

		[Register("unregisterAllFlagsListener", "(Lcom/launchdarkly/sdk/android/LDAllFlagsListener;)V", "GetUnregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void UnregisterAllFlagsListener(ILDAllFlagsListener p0);

		[Register("unregisterFeatureFlagListener", "(Ljava/lang/String;Lcom/launchdarkly/sdk/android/FeatureFlagChangeListener;)V", "GetUnregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void UnregisterFeatureFlagListener(string p0, IFeatureFlagChangeListener p1);

		[Register("unregisterStatusListener", "(Lcom/launchdarkly/sdk/android/LDStatusListener;)V", "GetUnregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_Handler:Com.Launchdarkly.Sdk.Android.ILDClientInterfaceInvoker, LaunchDarklyAndroidBinding")]
		void UnregisterStatusListener(ILDStatusListener p0);
	}
	[Register("com/launchdarkly/sdk/android/LDClientInterface", DoNotGenerateAcw = true)]
	internal class ILDClientInterfaceInvoker : Java.Lang.Object, ILDClientInterface, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDClientInterface", typeof(ILDClientInterfaceInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getConnectionInformation;

		private IntPtr id_getConnectionInformation;

		private static Delegate cb_isDisableBackgroundPolling;

		private IntPtr id_isDisableBackgroundPolling;

		private static Delegate cb_isInitialized;

		private IntPtr id_isInitialized;

		private static Delegate cb_isOffline;

		private IntPtr id_isOffline;

		private static Delegate cb_getVersion;

		private IntPtr id_getVersion;

		private static Delegate cb_allFlags;

		private IntPtr id_allFlags;

		private static Delegate cb_boolVariation_Ljava_lang_String_Z;

		private IntPtr id_boolVariation_Ljava_lang_String_Z;

		private static Delegate cb_boolVariationDetail_Ljava_lang_String_Z;

		private IntPtr id_boolVariationDetail_Ljava_lang_String_Z;

		private static Delegate cb_doubleVariation_Ljava_lang_String_D;

		private IntPtr id_doubleVariation_Ljava_lang_String_D;

		private static Delegate cb_doubleVariationDetail_Ljava_lang_String_D;

		private IntPtr id_doubleVariationDetail_Ljava_lang_String_D;

		private static Delegate cb_flush;

		private IntPtr id_flush;

		private static Delegate cb_identify_Lcom_launchdarkly_sdk_LDUser_;

		private IntPtr id_identify_Lcom_launchdarkly_sdk_LDUser_;

		private static Delegate cb_intVariation_Ljava_lang_String_I;

		private IntPtr id_intVariation_Ljava_lang_String_I;

		private static Delegate cb_intVariationDetail_Ljava_lang_String_I;

		private IntPtr id_intVariationDetail_Ljava_lang_String_I;

		private static Delegate cb_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

		private IntPtr id_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

		private static Delegate cb_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

		private IntPtr id_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

		private static Delegate cb_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_;

		private IntPtr id_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_;

		private static Delegate cb_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_;

		private IntPtr id_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_;

		private static Delegate cb_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_;

		private IntPtr id_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_;

		private static Delegate cb_setOffline;

		private IntPtr id_setOffline;

		private static Delegate cb_setOnline;

		private IntPtr id_setOnline;

		private static Delegate cb_stringVariation_Ljava_lang_String_Ljava_lang_String_;

		private IntPtr id_stringVariation_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_;

		private IntPtr id_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_track_Ljava_lang_String_;

		private IntPtr id_track_Ljava_lang_String_;

		private static Delegate cb_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

		private IntPtr id_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

		private static Delegate cb_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D;

		private IntPtr id_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D;

		private static Delegate cb_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_;

		private IntPtr id_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_;

		private static Delegate cb_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_;

		private IntPtr id_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_;

		private static Delegate cb_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_;

		private IntPtr id_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_;

		private static Delegate cb_close;

		private IntPtr id_close;

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

		public IConnectionInformation ConnectionInformation
		{
			get
			{
				if (id_getConnectionInformation == IntPtr.Zero)
				{
					id_getConnectionInformation = JNIEnv.GetMethodID(class_ref, "getConnectionInformation", "()Lcom/launchdarkly/sdk/android/ConnectionInformation;");
				}
				return Java.Lang.Object.GetObject<IConnectionInformation>(JNIEnv.CallObjectMethod(base.Handle, id_getConnectionInformation), JniHandleOwnership.TransferLocalRef);
			}
		}

		public bool IsDisableBackgroundPolling
		{
			get
			{
				if (id_isDisableBackgroundPolling == IntPtr.Zero)
				{
					id_isDisableBackgroundPolling = JNIEnv.GetMethodID(class_ref, "isDisableBackgroundPolling", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isDisableBackgroundPolling);
			}
		}

		public bool IsInitialized
		{
			get
			{
				if (id_isInitialized == IntPtr.Zero)
				{
					id_isInitialized = JNIEnv.GetMethodID(class_ref, "isInitialized", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isInitialized);
			}
		}

		public bool IsOffline
		{
			get
			{
				if (id_isOffline == IntPtr.Zero)
				{
					id_isOffline = JNIEnv.GetMethodID(class_ref, "isOffline", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isOffline);
			}
		}

		public string Version
		{
			get
			{
				if (id_getVersion == IntPtr.Zero)
				{
					id_getVersion = JNIEnv.GetMethodID(class_ref, "getVersion", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getVersion), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static ILDClientInterface GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILDClientInterface>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.android.LDClientInterface'.");
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

		public ILDClientInterfaceInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetConnectionInformationHandler()
		{
			if ((object)cb_getConnectionInformation == null)
			{
				cb_getConnectionInformation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConnectionInformation));
			}
			return cb_getConnectionInformation;
		}

		private static IntPtr n_GetConnectionInformation(IntPtr jnienv, IntPtr native__this)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iLDClientInterface.ConnectionInformation);
		}

		private static Delegate GetIsDisableBackgroundPollingHandler()
		{
			if ((object)cb_isDisableBackgroundPolling == null)
			{
				cb_isDisableBackgroundPolling = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDisableBackgroundPolling));
			}
			return cb_isDisableBackgroundPolling;
		}

		private static bool n_IsDisableBackgroundPolling(IntPtr jnienv, IntPtr native__this)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return iLDClientInterface.IsDisableBackgroundPolling;
		}

		private static Delegate GetIsInitializedHandler()
		{
			if ((object)cb_isInitialized == null)
			{
				cb_isInitialized = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInitialized));
			}
			return cb_isInitialized;
		}

		private static bool n_IsInitialized(IntPtr jnienv, IntPtr native__this)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return iLDClientInterface.IsInitialized;
		}

		private static Delegate GetIsOfflineHandler()
		{
			if ((object)cb_isOffline == null)
			{
				cb_isOffline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsOffline));
			}
			return cb_isOffline;
		}

		private static bool n_IsOffline(IntPtr jnienv, IntPtr native__this)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return iLDClientInterface.IsOffline;
		}

		private static Delegate GetGetVersionHandler()
		{
			if ((object)cb_getVersion == null)
			{
				cb_getVersion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVersion));
			}
			return cb_getVersion;
		}

		private static IntPtr n_GetVersion(IntPtr jnienv, IntPtr native__this)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(iLDClientInterface.Version);
		}

		private static Delegate GetAllFlagsHandler()
		{
			if ((object)cb_allFlags == null)
			{
				cb_allFlags = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AllFlags));
			}
			return cb_allFlags;
		}

		private static IntPtr n_AllFlags(IntPtr jnienv, IntPtr native__this)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaDictionary<string, LDValue>.ToLocalJniHandle(iLDClientInterface.AllFlags());
		}

		public IDictionary<string, LDValue> AllFlags()
		{
			if (id_allFlags == IntPtr.Zero)
			{
				id_allFlags = JNIEnv.GetMethodID(class_ref, "allFlags", "()Ljava/util/Map;");
			}
			return JavaDictionary<string, LDValue>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_allFlags), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetBoolVariation_Ljava_lang_String_ZHandler()
		{
			if ((object)cb_boolVariation_Ljava_lang_String_Z == null)
			{
				cb_boolVariation_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_Z(n_BoolVariation_Ljava_lang_String_Z));
			}
			return cb_boolVariation_Ljava_lang_String_Z;
		}

		private static bool n_BoolVariation_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return iLDClientInterface.BoolVariation(p2, p1);
		}

		public unsafe bool BoolVariation(string p0, bool p1)
		{
			if (id_boolVariation_Ljava_lang_String_Z == IntPtr.Zero)
			{
				id_boolVariation_Ljava_lang_String_Z = JNIEnv.GetMethodID(class_ref, "boolVariation", "(Ljava/lang/String;Z)Z");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_boolVariation_Ljava_lang_String_Z, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetBoolVariationDetail_Ljava_lang_String_ZHandler()
		{
			if ((object)cb_boolVariationDetail_Ljava_lang_String_Z == null)
			{
				cb_boolVariationDetail_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_BoolVariationDetail_Ljava_lang_String_Z));
			}
			return cb_boolVariationDetail_Ljava_lang_String_Z;
		}

		private static IntPtr n_BoolVariationDetail_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iLDClientInterface.BoolVariationDetail(p2, p1));
		}

		public unsafe EvaluationDetail BoolVariationDetail(string p0, bool p1)
		{
			if (id_boolVariationDetail_Ljava_lang_String_Z == IntPtr.Zero)
			{
				id_boolVariationDetail_Ljava_lang_String_Z = JNIEnv.GetMethodID(class_ref, "boolVariationDetail", "(Ljava/lang/String;Z)Lcom/launchdarkly/sdk/EvaluationDetail;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			EvaluationDetail result = Java.Lang.Object.GetObject<EvaluationDetail>(JNIEnv.CallObjectMethod(base.Handle, id_boolVariationDetail_Ljava_lang_String_Z, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetDoubleVariation_Ljava_lang_String_DHandler()
		{
			if ((object)cb_doubleVariation_Ljava_lang_String_D == null)
			{
				cb_doubleVariation_Ljava_lang_String_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLD_D(n_DoubleVariation_Ljava_lang_String_D));
			}
			return cb_doubleVariation_Ljava_lang_String_D;
		}

		private static double n_DoubleVariation_Ljava_lang_String_D(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, double p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return iLDClientInterface.DoubleVariation(p2, p1);
		}

		public unsafe double DoubleVariation(string p0, double p1)
		{
			if (id_doubleVariation_Ljava_lang_String_D == IntPtr.Zero)
			{
				id_doubleVariation_Ljava_lang_String_D = JNIEnv.GetMethodID(class_ref, "doubleVariation", "(Ljava/lang/String;D)D");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			double result = JNIEnv.CallDoubleMethod(base.Handle, id_doubleVariation_Ljava_lang_String_D, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetDoubleVariationDetail_Ljava_lang_String_DHandler()
		{
			if ((object)cb_doubleVariationDetail_Ljava_lang_String_D == null)
			{
				cb_doubleVariationDetail_Ljava_lang_String_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLD_L(n_DoubleVariationDetail_Ljava_lang_String_D));
			}
			return cb_doubleVariationDetail_Ljava_lang_String_D;
		}

		private static IntPtr n_DoubleVariationDetail_Ljava_lang_String_D(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, double p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iLDClientInterface.DoubleVariationDetail(p2, p1));
		}

		public unsafe EvaluationDetail DoubleVariationDetail(string p0, double p1)
		{
			if (id_doubleVariationDetail_Ljava_lang_String_D == IntPtr.Zero)
			{
				id_doubleVariationDetail_Ljava_lang_String_D = JNIEnv.GetMethodID(class_ref, "doubleVariationDetail", "(Ljava/lang/String;D)Lcom/launchdarkly/sdk/EvaluationDetail;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			EvaluationDetail result = Java.Lang.Object.GetObject<EvaluationDetail>(JNIEnv.CallObjectMethod(base.Handle, id_doubleVariationDetail_Ljava_lang_String_D, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
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
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.Flush();
		}

		public void Flush()
		{
			if (id_flush == IntPtr.Zero)
			{
				id_flush = JNIEnv.GetMethodID(class_ref, "flush", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_flush);
		}

		private static Delegate GetIdentify_Lcom_launchdarkly_sdk_LDUser_Handler()
		{
			if ((object)cb_identify_Lcom_launchdarkly_sdk_LDUser_ == null)
			{
				cb_identify_Lcom_launchdarkly_sdk_LDUser_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Identify_Lcom_launchdarkly_sdk_LDUser_));
			}
			return cb_identify_Lcom_launchdarkly_sdk_LDUser_;
		}

		private static IntPtr n_Identify_Lcom_launchdarkly_sdk_LDUser_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDUser p = Java.Lang.Object.GetObject<LDUser>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iLDClientInterface.Identify(p));
		}

		public unsafe IFuture Identify(LDUser p0)
		{
			if (id_identify_Lcom_launchdarkly_sdk_LDUser_ == IntPtr.Zero)
			{
				id_identify_Lcom_launchdarkly_sdk_LDUser_ = JNIEnv.GetMethodID(class_ref, "identify", "(Lcom/launchdarkly/sdk/LDUser;)Ljava/util/concurrent/Future;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IFuture>(JNIEnv.CallObjectMethod(base.Handle, id_identify_Lcom_launchdarkly_sdk_LDUser_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetIntVariation_Ljava_lang_String_IHandler()
		{
			if ((object)cb_intVariation_Ljava_lang_String_I == null)
			{
				cb_intVariation_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_I(n_IntVariation_Ljava_lang_String_I));
			}
			return cb_intVariation_Ljava_lang_String_I;
		}

		private static int n_IntVariation_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return iLDClientInterface.IntVariation(p2, p1);
		}

		public unsafe int IntVariation(string p0, int p1)
		{
			if (id_intVariation_Ljava_lang_String_I == IntPtr.Zero)
			{
				id_intVariation_Ljava_lang_String_I = JNIEnv.GetMethodID(class_ref, "intVariation", "(Ljava/lang/String;I)I");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			int result = JNIEnv.CallIntMethod(base.Handle, id_intVariation_Ljava_lang_String_I, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetIntVariationDetail_Ljava_lang_String_IHandler()
		{
			if ((object)cb_intVariationDetail_Ljava_lang_String_I == null)
			{
				cb_intVariationDetail_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_IntVariationDetail_Ljava_lang_String_I));
			}
			return cb_intVariationDetail_Ljava_lang_String_I;
		}

		private static IntPtr n_IntVariationDetail_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iLDClientInterface.IntVariationDetail(p2, p1));
		}

		public unsafe EvaluationDetail IntVariationDetail(string p0, int p1)
		{
			if (id_intVariationDetail_Ljava_lang_String_I == IntPtr.Zero)
			{
				id_intVariationDetail_Ljava_lang_String_I = JNIEnv.GetMethodID(class_ref, "intVariationDetail", "(Ljava/lang/String;I)Lcom/launchdarkly/sdk/EvaluationDetail;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			EvaluationDetail result = Java.Lang.Object.GetObject<EvaluationDetail>(JNIEnv.CallObjectMethod(base.Handle, id_intVariationDetail_Ljava_lang_String_I, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetJsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler()
		{
			if ((object)cb_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == null)
			{
				cb_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_JsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_));
			}
			return cb_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;
		}

		private static IntPtr n_JsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			LDValue p2 = Java.Lang.Object.GetObject<LDValue>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iLDClientInterface.JsonValueVariation(p, p2));
		}

		public unsafe LDValue JsonValueVariation(string p0, LDValue p1)
		{
			if (id_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == IntPtr.Zero)
			{
				id_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNIEnv.GetMethodID(class_ref, "jsonValueVariation", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDValue;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			LDValue result = Java.Lang.Object.GetObject<LDValue>(JNIEnv.CallObjectMethod(base.Handle, id_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetJsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler()
		{
			if ((object)cb_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == null)
			{
				cb_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_JsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_));
			}
			return cb_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;
		}

		private static IntPtr n_JsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			LDValue p2 = Java.Lang.Object.GetObject<LDValue>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iLDClientInterface.JsonValueVariationDetail(p, p2));
		}

		public unsafe EvaluationDetail JsonValueVariationDetail(string p0, LDValue p1)
		{
			if (id_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == IntPtr.Zero)
			{
				id_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNIEnv.GetMethodID(class_ref, "jsonValueVariationDetail", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/EvaluationDetail;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			EvaluationDetail result = Java.Lang.Object.GetObject<EvaluationDetail>(JNIEnv.CallObjectMethod(base.Handle, id_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetRegisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_Handler()
		{
			if ((object)cb_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ == null)
			{
				cb_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RegisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_));
			}
			return cb_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_;
		}

		private static void n_RegisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILDAllFlagsListener p = Java.Lang.Object.GetObject<ILDAllFlagsListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.RegisterAllFlagsListener(p);
		}

		public unsafe void RegisterAllFlagsListener(ILDAllFlagsListener p0)
		{
			if (id_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ == IntPtr.Zero)
			{
				id_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ = JNIEnv.GetMethodID(class_ref, "registerAllFlagsListener", "(Lcom/launchdarkly/sdk/android/LDAllFlagsListener;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_, ptr);
		}

		private static Delegate GetRegisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_Handler()
		{
			if ((object)cb_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ == null)
			{
				cb_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RegisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_));
			}
			return cb_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_;
		}

		private static void n_RegisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			IFeatureFlagChangeListener p2 = Java.Lang.Object.GetObject<IFeatureFlagChangeListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.RegisterFeatureFlagListener(p, p2);
		}

		public unsafe void RegisterFeatureFlagListener(string p0, IFeatureFlagChangeListener p1)
		{
			if (id_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ == IntPtr.Zero)
			{
				id_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ = JNIEnv.GetMethodID(class_ref, "registerFeatureFlagListener", "(Ljava/lang/String;Lcom/launchdarkly/sdk/android/FeatureFlagChangeListener;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetRegisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_Handler()
		{
			if ((object)cb_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ == null)
			{
				cb_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RegisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_));
			}
			return cb_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_;
		}

		private static void n_RegisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILDStatusListener p = Java.Lang.Object.GetObject<ILDStatusListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.RegisterStatusListener(p);
		}

		public unsafe void RegisterStatusListener(ILDStatusListener p0)
		{
			if (id_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ == IntPtr.Zero)
			{
				id_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ = JNIEnv.GetMethodID(class_ref, "registerStatusListener", "(Lcom/launchdarkly/sdk/android/LDStatusListener;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_, ptr);
		}

		private static Delegate GetSetOfflineHandler()
		{
			if ((object)cb_setOffline == null)
			{
				cb_setOffline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SetOffline));
			}
			return cb_setOffline;
		}

		private static void n_SetOffline(IntPtr jnienv, IntPtr native__this)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.SetOffline();
		}

		public void SetOffline()
		{
			if (id_setOffline == IntPtr.Zero)
			{
				id_setOffline = JNIEnv.GetMethodID(class_ref, "setOffline", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_setOffline);
		}

		private static Delegate GetSetOnlineHandler()
		{
			if ((object)cb_setOnline == null)
			{
				cb_setOnline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SetOnline));
			}
			return cb_setOnline;
		}

		private static void n_SetOnline(IntPtr jnienv, IntPtr native__this)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.SetOnline();
		}

		public void SetOnline()
		{
			if (id_setOnline == IntPtr.Zero)
			{
				id_setOnline = JNIEnv.GetMethodID(class_ref, "setOnline", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_setOnline);
		}

		private static Delegate GetStringVariation_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_stringVariation_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_stringVariation_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_StringVariation_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_stringVariation_Ljava_lang_String_Ljava_lang_String_;
		}

		private static IntPtr n_StringVariation_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(iLDClientInterface.StringVariation(p, p2));
		}

		public unsafe string StringVariation(string p0, string p1)
		{
			if (id_stringVariation_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_stringVariation_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "stringVariation", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			string result = JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_stringVariation_Ljava_lang_String_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			return result;
		}

		private static Delegate GetStringVariationDetail_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_StringVariationDetail_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_;
		}

		private static IntPtr n_StringVariationDetail_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iLDClientInterface.StringVariationDetail(p, p2));
		}

		public unsafe EvaluationDetail StringVariationDetail(string p0, string p1)
		{
			if (id_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "stringVariationDetail", "(Ljava/lang/String;Ljava/lang/String;)Lcom/launchdarkly/sdk/EvaluationDetail;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			EvaluationDetail result = Java.Lang.Object.GetObject<EvaluationDetail>(JNIEnv.CallObjectMethod(base.Handle, id_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			return result;
		}

		private static Delegate GetTrack_Ljava_lang_String_Handler()
		{
			if ((object)cb_track_Ljava_lang_String_ == null)
			{
				cb_track_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Track_Ljava_lang_String_));
			}
			return cb_track_Ljava_lang_String_;
		}

		private static void n_Track_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.Track(p);
		}

		public unsafe void Track(string p0)
		{
			if (id_track_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_track_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "track", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_track_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetTrackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler()
		{
			if ((object)cb_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == null)
			{
				cb_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_TrackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_));
			}
			return cb_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;
		}

		private static void n_TrackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			LDValue p2 = Java.Lang.Object.GetObject<LDValue>(native_p1, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.TrackData(p, p2);
		}

		public unsafe void TrackData(string p0, LDValue p1)
		{
			if (id_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == IntPtr.Zero)
			{
				id_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNIEnv.GetMethodID(class_ref, "trackData", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetTrackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_DHandler()
		{
			if ((object)cb_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D == null)
			{
				cb_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLD_V(n_TrackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D));
			}
			return cb_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D;
		}

		private static void n_TrackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, double p2)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			LDValue p4 = Java.Lang.Object.GetObject<LDValue>(native_p1, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.TrackMetric(p3, p4, p2);
		}

		public unsafe void TrackMetric(string p0, LDValue p1, double p2)
		{
			if (id_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D == IntPtr.Zero)
			{
				id_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D = JNIEnv.GetMethodID(class_ref, "trackMetric", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;D)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(p2);
			JNIEnv.CallVoidMethod(base.Handle, id_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetUnregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_Handler()
		{
			if ((object)cb_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ == null)
			{
				cb_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_));
			}
			return cb_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_;
		}

		private static void n_UnregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILDAllFlagsListener p = Java.Lang.Object.GetObject<ILDAllFlagsListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.UnregisterAllFlagsListener(p);
		}

		public unsafe void UnregisterAllFlagsListener(ILDAllFlagsListener p0)
		{
			if (id_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ == IntPtr.Zero)
			{
				id_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ = JNIEnv.GetMethodID(class_ref, "unregisterAllFlagsListener", "(Lcom/launchdarkly/sdk/android/LDAllFlagsListener;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_, ptr);
		}

		private static Delegate GetUnregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_Handler()
		{
			if ((object)cb_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ == null)
			{
				cb_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_UnregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_));
			}
			return cb_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_;
		}

		private static void n_UnregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			IFeatureFlagChangeListener p2 = Java.Lang.Object.GetObject<IFeatureFlagChangeListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.UnregisterFeatureFlagListener(p, p2);
		}

		public unsafe void UnregisterFeatureFlagListener(string p0, IFeatureFlagChangeListener p1)
		{
			if (id_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ == IntPtr.Zero)
			{
				id_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ = JNIEnv.GetMethodID(class_ref, "unregisterFeatureFlagListener", "(Ljava/lang/String;Lcom/launchdarkly/sdk/android/FeatureFlagChangeListener;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetUnregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_Handler()
		{
			if ((object)cb_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ == null)
			{
				cb_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_));
			}
			return cb_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_;
		}

		private static void n_UnregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILDStatusListener p = Java.Lang.Object.GetObject<ILDStatusListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.UnregisterStatusListener(p);
		}

		public unsafe void UnregisterStatusListener(ILDStatusListener p0)
		{
			if (id_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ == IntPtr.Zero)
			{
				id_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ = JNIEnv.GetMethodID(class_ref, "unregisterStatusListener", "(Lcom/launchdarkly/sdk/android/LDStatusListener;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_, ptr);
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
			ILDClientInterface iLDClientInterface = Java.Lang.Object.GetObject<ILDClientInterface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iLDClientInterface.Close();
		}

		public void Close()
		{
			if (id_close == IntPtr.Zero)
			{
				id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_close);
		}
	}
	[Register("com/launchdarkly/sdk/android/LDHeaderUpdater", "", "Com.Launchdarkly.Sdk.Android.ILDHeaderUpdaterInvoker")]
	public interface ILDHeaderUpdater : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("updateHeaders", "(Ljava/util/Map;)V", "GetUpdateHeaders_Ljava_util_Map_Handler:Com.Launchdarkly.Sdk.Android.ILDHeaderUpdaterInvoker, LaunchDarklyAndroidBinding")]
		void UpdateHeaders(IDictionary<string, string> p0);
	}
	[Register("com/launchdarkly/sdk/android/LDHeaderUpdater", DoNotGenerateAcw = true)]
	internal class ILDHeaderUpdaterInvoker : Java.Lang.Object, ILDHeaderUpdater, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDHeaderUpdater", typeof(ILDHeaderUpdaterInvoker));

		private IntPtr class_ref;

		private static Delegate cb_updateHeaders_Ljava_util_Map_;

		private IntPtr id_updateHeaders_Ljava_util_Map_;

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

		public static ILDHeaderUpdater GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILDHeaderUpdater>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.android.LDHeaderUpdater'.");
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

		public ILDHeaderUpdaterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetUpdateHeaders_Ljava_util_Map_Handler()
		{
			if ((object)cb_updateHeaders_Ljava_util_Map_ == null)
			{
				cb_updateHeaders_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateHeaders_Ljava_util_Map_));
			}
			return cb_updateHeaders_Ljava_util_Map_;
		}

		private static void n_UpdateHeaders_Ljava_util_Map_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDHeaderUpdater iLDHeaderUpdater = Java.Lang.Object.GetObject<ILDHeaderUpdater>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, string> p = JavaDictionary<string, string>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
			iLDHeaderUpdater.UpdateHeaders(p);
		}

		public unsafe void UpdateHeaders(IDictionary<string, string> p0)
		{
			if (id_updateHeaders_Ljava_util_Map_ == IntPtr.Zero)
			{
				id_updateHeaders_Ljava_util_Map_ = JNIEnv.GetMethodID(class_ref, "updateHeaders", "(Ljava/util/Map;)V");
			}
			IntPtr intPtr = JavaDictionary<string, string>.ToLocalJniHandle(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_updateHeaders_Ljava_util_Map_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/launchdarkly/sdk/android/LDStatusListener", "", "Com.Launchdarkly.Sdk.Android.ILDStatusListenerInvoker")]
	public interface ILDStatusListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onConnectionModeChanged", "(Lcom/launchdarkly/sdk/android/ConnectionInformation;)V", "GetOnConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_Handler:Com.Launchdarkly.Sdk.Android.ILDStatusListenerInvoker, LaunchDarklyAndroidBinding")]
		void OnConnectionModeChanged(IConnectionInformation p0);

		[Register("onInternalFailure", "(Lcom/launchdarkly/sdk/android/LDFailure;)V", "GetOnInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_Handler:Com.Launchdarkly.Sdk.Android.ILDStatusListenerInvoker, LaunchDarklyAndroidBinding")]
		void OnInternalFailure(LDFailure p0);
	}
	[Register("com/launchdarkly/sdk/android/LDStatusListener", DoNotGenerateAcw = true)]
	internal class ILDStatusListenerInvoker : Java.Lang.Object, ILDStatusListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDStatusListener", typeof(ILDStatusListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_;

		private IntPtr id_onConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_;

		private static Delegate cb_onInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_;

		private IntPtr id_onInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_;

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

		public static ILDStatusListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILDStatusListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.android.LDStatusListener'.");
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

		public ILDStatusListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_Handler()
		{
			if ((object)cb_onConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_ == null)
			{
				cb_onConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_));
			}
			return cb_onConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_;
		}

		private static void n_OnConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDStatusListener iLDStatusListener = Java.Lang.Object.GetObject<ILDStatusListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConnectionInformation p = Java.Lang.Object.GetObject<IConnectionInformation>(native_p0, JniHandleOwnership.DoNotTransfer);
			iLDStatusListener.OnConnectionModeChanged(p);
		}

		public unsafe void OnConnectionModeChanged(IConnectionInformation p0)
		{
			if (id_onConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_ == IntPtr.Zero)
			{
				id_onConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_ = JNIEnv.GetMethodID(class_ref, "onConnectionModeChanged", "(Lcom/launchdarkly/sdk/android/ConnectionInformation;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_onConnectionModeChanged_Lcom_launchdarkly_sdk_android_ConnectionInformation_, ptr);
		}

		private static Delegate GetOnInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_Handler()
		{
			if ((object)cb_onInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_ == null)
			{
				cb_onInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_));
			}
			return cb_onInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_;
		}

		private static void n_OnInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDStatusListener iLDStatusListener = Java.Lang.Object.GetObject<ILDStatusListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDFailure p = Java.Lang.Object.GetObject<LDFailure>(native_p0, JniHandleOwnership.DoNotTransfer);
			iLDStatusListener.OnInternalFailure(p);
		}

		public unsafe void OnInternalFailure(LDFailure p0)
		{
			if (id_onInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_ == IntPtr.Zero)
			{
				id_onInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_ = JNIEnv.GetMethodID(class_ref, "onInternalFailure", "(Lcom/launchdarkly/sdk/android/LDFailure;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onInternalFailure_Lcom_launchdarkly_sdk_android_LDFailure_, ptr);
		}
	}
	public class ConnectionModeChangedEventArgs : EventArgs
	{
		private IConnectionInformation p0;

		public IConnectionInformation P0 => p0;

		public ConnectionModeChangedEventArgs(IConnectionInformation p0)
		{
			this.p0 = p0;
		}
	}
	public class InternalFailureEventArgs : EventArgs
	{
		private LDFailure p0;

		public LDFailure P0 => p0;

		public InternalFailureEventArgs(LDFailure p0)
		{
			this.p0 = p0;
		}
	}
	[Register("mono/com/launchdarkly/sdk/android/LDStatusListenerImplementor")]
	internal sealed class ILDStatusListenerImplementor : Java.Lang.Object, ILDStatusListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<ConnectionModeChangedEventArgs> OnConnectionModeChangedHandler;

		public EventHandler<InternalFailureEventArgs> OnInternalFailureHandler;

		public ILDStatusListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/launchdarkly/sdk/android/LDStatusListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnConnectionModeChanged(IConnectionInformation p0)
		{
			OnConnectionModeChangedHandler?.Invoke(sender, new ConnectionModeChangedEventArgs(p0));
		}

		public void OnInternalFailure(LDFailure p0)
		{
			OnInternalFailureHandler?.Invoke(sender, new InternalFailureEventArgs(p0));
		}

		internal static bool __IsEmpty(ILDStatusListenerImplementor value)
		{
			if (value.OnConnectionModeChangedHandler == null)
			{
				return value.OnInternalFailureHandler == null;
			}
			return false;
		}
	}
	[Register("com/launchdarkly/sdk/android/LaunchDarklyException", DoNotGenerateAcw = true)]
	public class LaunchDarklyException : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LaunchDarklyException", typeof(LaunchDarklyException));

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

		protected LaunchDarklyException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe LaunchDarklyException(string message)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
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
	}
	[Register("com/launchdarkly/sdk/android/LDAndroidLogging", DoNotGenerateAcw = true)]
	public abstract class LDAndroidLogging : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDAndroidLogging", typeof(LDAndroidLogging));

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

		protected LDAndroidLogging(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LDAndroidLogging()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("adapter", "()Lcom/launchdarkly/logging/LDLogAdapter;", "")]
		public unsafe static ILDLogAdapter Adapter()
		{
			return Java.Lang.Object.GetObject<ILDLogAdapter>(_members.StaticMethods.InvokeObjectMethod("adapter.()Lcom/launchdarkly/logging/LDLogAdapter;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/sdk/android/LDAndroidLogging", DoNotGenerateAcw = true)]
	internal class LDAndroidLoggingInvoker : LDAndroidLogging
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDAndroidLogging", typeof(LDAndroidLoggingInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public LDAndroidLoggingInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/launchdarkly/sdk/android/LDClient", DoNotGenerateAcw = true)]
	public class LDClient : Java.Lang.Object, ILDClientInterface, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDClient", typeof(LDClient));

		private static Delegate cb_getConnectionInformation;

		private static Delegate cb_isDisableBackgroundPolling;

		private static Delegate cb_isInitialized;

		private static Delegate cb_isOffline;

		private static Delegate cb_getVersion;

		private static Delegate cb_alias_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_;

		private static Delegate cb_allFlags;

		private static Delegate cb_boolVariation_Ljava_lang_String_Z;

		private static Delegate cb_boolVariationDetail_Ljava_lang_String_Z;

		private static Delegate cb_close;

		private static Delegate cb_doubleVariation_Ljava_lang_String_D;

		private static Delegate cb_doubleVariationDetail_Ljava_lang_String_D;

		private static Delegate cb_flush;

		private static Delegate cb_identify_Lcom_launchdarkly_sdk_LDUser_;

		private static Delegate cb_intVariation_Ljava_lang_String_I;

		private static Delegate cb_intVariationDetail_Ljava_lang_String_I;

		private static Delegate cb_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

		private static Delegate cb_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

		private static Delegate cb_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_;

		private static Delegate cb_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_;

		private static Delegate cb_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_;

		private static Delegate cb_setOffline;

		private static Delegate cb_setOnline;

		private static Delegate cb_stringVariation_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_track_Ljava_lang_String_;

		private static Delegate cb_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;

		private static Delegate cb_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D;

		private static Delegate cb_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_;

		private static Delegate cb_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_;

		private static Delegate cb_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_;

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

		public unsafe virtual IConnectionInformation ConnectionInformation
		{
			[Register("getConnectionInformation", "()Lcom/launchdarkly/sdk/android/ConnectionInformation;", "GetGetConnectionInformationHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IConnectionInformation>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConnectionInformation.()Lcom/launchdarkly/sdk/android/ConnectionInformation;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsDisableBackgroundPolling
		{
			[Register("isDisableBackgroundPolling", "()Z", "GetIsDisableBackgroundPollingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDisableBackgroundPolling.()Z", this, null);
			}
		}

		public unsafe virtual bool IsInitialized
		{
			[Register("isInitialized", "()Z", "GetIsInitializedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInitialized.()Z", this, null);
			}
		}

		public unsafe virtual bool IsOffline
		{
			[Register("isOffline", "()Z", "GetIsOfflineHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOffline.()Z", this, null);
			}
		}

		public unsafe virtual string Version
		{
			[Register("getVersion", "()Ljava/lang/String;", "GetGetVersionHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getVersion.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LDClient(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Application;Lcom/launchdarkly/sdk/android/LDConfig;)V", "")]
		protected unsafe LDClient(Application application, LDConfig config)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(application?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Application;Lcom/launchdarkly/sdk/android/LDConfig;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Application;Lcom/launchdarkly/sdk/android/LDConfig;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(application);
				GC.KeepAlive(config);
			}
		}

		[Register(".ctor", "(Landroid/app/Application;Lcom/launchdarkly/sdk/android/LDConfig;Ljava/lang/String;)V", "")]
		protected unsafe LDClient(Application application, LDConfig config, string environmentName)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(environmentName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(application?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Application;Lcom/launchdarkly/sdk/android/LDConfig;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Application;Lcom/launchdarkly/sdk/android/LDConfig;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(application);
				GC.KeepAlive(config);
			}
		}

		private static Delegate GetGetConnectionInformationHandler()
		{
			if ((object)cb_getConnectionInformation == null)
			{
				cb_getConnectionInformation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConnectionInformation));
			}
			return cb_getConnectionInformation;
		}

		private static IntPtr n_GetConnectionInformation(IntPtr jnienv, IntPtr native__this)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDClient.ConnectionInformation);
		}

		private static Delegate GetIsDisableBackgroundPollingHandler()
		{
			if ((object)cb_isDisableBackgroundPolling == null)
			{
				cb_isDisableBackgroundPolling = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDisableBackgroundPolling));
			}
			return cb_isDisableBackgroundPolling;
		}

		private static bool n_IsDisableBackgroundPolling(IntPtr jnienv, IntPtr native__this)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDClient.IsDisableBackgroundPolling;
		}

		private static Delegate GetIsInitializedHandler()
		{
			if ((object)cb_isInitialized == null)
			{
				cb_isInitialized = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInitialized));
			}
			return cb_isInitialized;
		}

		private static bool n_IsInitialized(IntPtr jnienv, IntPtr native__this)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDClient.IsInitialized;
		}

		private static Delegate GetIsOfflineHandler()
		{
			if ((object)cb_isOffline == null)
			{
				cb_isOffline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsOffline));
			}
			return cb_isOffline;
		}

		private static bool n_IsOffline(IntPtr jnienv, IntPtr native__this)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDClient.IsOffline;
		}

		private static Delegate GetGetVersionHandler()
		{
			if ((object)cb_getVersion == null)
			{
				cb_getVersion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVersion));
			}
			return cb_getVersion;
		}

		private static IntPtr n_GetVersion(IntPtr jnienv, IntPtr native__this)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDClient.Version);
		}

		private static Delegate GetAlias_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_Handler()
		{
			if ((object)cb_alias_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_ == null)
			{
				cb_alias_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Alias_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_));
			}
			return cb_alias_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_;
		}

		private static void n_Alias_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_(IntPtr jnienv, IntPtr native__this, IntPtr native_user, IntPtr native_previousUser)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDUser user = Java.Lang.Object.GetObject<LDUser>(native_user, JniHandleOwnership.DoNotTransfer);
			LDUser previousUser = Java.Lang.Object.GetObject<LDUser>(native_previousUser, JniHandleOwnership.DoNotTransfer);
			lDClient.Alias(user, previousUser);
		}

		[Register("alias", "(Lcom/launchdarkly/sdk/LDUser;Lcom/launchdarkly/sdk/LDUser;)V", "GetAlias_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_Handler")]
		public unsafe virtual void Alias(LDUser user, LDUser previousUser)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(user?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(previousUser?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("alias.(Lcom/launchdarkly/sdk/LDUser;Lcom/launchdarkly/sdk/LDUser;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(user);
				GC.KeepAlive(previousUser);
			}
		}

		private static Delegate GetAllFlagsHandler()
		{
			if ((object)cb_allFlags == null)
			{
				cb_allFlags = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AllFlags));
			}
			return cb_allFlags;
		}

		private static IntPtr n_AllFlags(IntPtr jnienv, IntPtr native__this)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaDictionary<string, LDValue>.ToLocalJniHandle(lDClient.AllFlags());
		}

		[Register("allFlags", "()Ljava/util/Map;", "GetAllFlagsHandler")]
		public unsafe virtual IDictionary<string, LDValue> AllFlags()
		{
			return JavaDictionary<string, LDValue>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("allFlags.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetBoolVariation_Ljava_lang_String_ZHandler()
		{
			if ((object)cb_boolVariation_Ljava_lang_String_Z == null)
			{
				cb_boolVariation_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_Z(n_BoolVariation_Ljava_lang_String_Z));
			}
			return cb_boolVariation_Ljava_lang_String_Z;
		}

		private static bool n_BoolVariation_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_key, bool defaultValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return lDClient.BoolVariation(key, defaultValue);
		}

		[Register("boolVariation", "(Ljava/lang/String;Z)Z", "GetBoolVariation_Ljava_lang_String_ZHandler")]
		public unsafe virtual bool BoolVariation(string key, bool defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("boolVariation.(Ljava/lang/String;Z)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetBoolVariationDetail_Ljava_lang_String_ZHandler()
		{
			if ((object)cb_boolVariationDetail_Ljava_lang_String_Z == null)
			{
				cb_boolVariationDetail_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_BoolVariationDetail_Ljava_lang_String_Z));
			}
			return cb_boolVariationDetail_Ljava_lang_String_Z;
		}

		private static IntPtr n_BoolVariationDetail_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_key, bool defaultValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDClient.BoolVariationDetail(key, defaultValue));
		}

		[Register("boolVariationDetail", "(Ljava/lang/String;Z)Lcom/launchdarkly/sdk/EvaluationDetail;", "GetBoolVariationDetail_Ljava_lang_String_ZHandler")]
		public unsafe virtual EvaluationDetail BoolVariationDetail(string key, bool defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return Java.Lang.Object.GetObject<EvaluationDetail>(_members.InstanceMethods.InvokeVirtualObjectMethod("boolVariationDetail.(Ljava/lang/String;Z)Lcom/launchdarkly/sdk/EvaluationDetail;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
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
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			lDClient.Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}

		private static Delegate GetDoubleVariation_Ljava_lang_String_DHandler()
		{
			if ((object)cb_doubleVariation_Ljava_lang_String_D == null)
			{
				cb_doubleVariation_Ljava_lang_String_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLD_D(n_DoubleVariation_Ljava_lang_String_D));
			}
			return cb_doubleVariation_Ljava_lang_String_D;
		}

		private static double n_DoubleVariation_Ljava_lang_String_D(IntPtr jnienv, IntPtr native__this, IntPtr native_flagKey, double defaultValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string flagKey = JNIEnv.GetString(native_flagKey, JniHandleOwnership.DoNotTransfer);
			return lDClient.DoubleVariation(flagKey, defaultValue);
		}

		[Register("doubleVariation", "(Ljava/lang/String;D)D", "GetDoubleVariation_Ljava_lang_String_DHandler")]
		public unsafe virtual double DoubleVariation(string flagKey, double defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(flagKey);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeVirtualDoubleMethod("doubleVariation.(Ljava/lang/String;D)D", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetDoubleVariationDetail_Ljava_lang_String_DHandler()
		{
			if ((object)cb_doubleVariationDetail_Ljava_lang_String_D == null)
			{
				cb_doubleVariationDetail_Ljava_lang_String_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLD_L(n_DoubleVariationDetail_Ljava_lang_String_D));
			}
			return cb_doubleVariationDetail_Ljava_lang_String_D;
		}

		private static IntPtr n_DoubleVariationDetail_Ljava_lang_String_D(IntPtr jnienv, IntPtr native__this, IntPtr native_flagKey, double defaultValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string flagKey = JNIEnv.GetString(native_flagKey, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDClient.DoubleVariationDetail(flagKey, defaultValue));
		}

		[Register("doubleVariationDetail", "(Ljava/lang/String;D)Lcom/launchdarkly/sdk/EvaluationDetail;", "GetDoubleVariationDetail_Ljava_lang_String_DHandler")]
		public unsafe virtual EvaluationDetail DoubleVariationDetail(string flagKey, double defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(flagKey);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return Java.Lang.Object.GetObject<EvaluationDetail>(_members.InstanceMethods.InvokeVirtualObjectMethod("doubleVariationDetail.(Ljava/lang/String;D)Lcom/launchdarkly/sdk/EvaluationDetail;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
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
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			lDClient.Flush();
		}

		[Register("flush", "()V", "GetFlushHandler")]
		public unsafe virtual void Flush()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("flush.()V", this, null);
		}

		[Register("get", "()Lcom/launchdarkly/sdk/android/LDClient;", "")]
		public unsafe static LDClient Get()
		{
			return Java.Lang.Object.GetObject<LDClient>(_members.StaticMethods.InvokeObjectMethod("get.()Lcom/launchdarkly/sdk/android/LDClient;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getForMobileKey", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDClient;", "")]
		public unsafe static LDClient GetForMobileKey(string keyName)
		{
			IntPtr intPtr = JNIEnv.NewString(keyName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LDClient>(_members.StaticMethods.InvokeObjectMethod("getForMobileKey.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDClient;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetIdentify_Lcom_launchdarkly_sdk_LDUser_Handler()
		{
			if ((object)cb_identify_Lcom_launchdarkly_sdk_LDUser_ == null)
			{
				cb_identify_Lcom_launchdarkly_sdk_LDUser_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Identify_Lcom_launchdarkly_sdk_LDUser_));
			}
			return cb_identify_Lcom_launchdarkly_sdk_LDUser_;
		}

		private static IntPtr n_Identify_Lcom_launchdarkly_sdk_LDUser_(IntPtr jnienv, IntPtr native__this, IntPtr native_user)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDUser user = Java.Lang.Object.GetObject<LDUser>(native_user, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDClient.Identify(user));
		}

		[Register("identify", "(Lcom/launchdarkly/sdk/LDUser;)Ljava/util/concurrent/Future;", "GetIdentify_Lcom_launchdarkly_sdk_LDUser_Handler")]
		public unsafe virtual IFuture Identify(LDUser user)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(user?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("identify.(Lcom/launchdarkly/sdk/LDUser;)Ljava/util/concurrent/Future;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(user);
			}
		}

		[Register("init", "(Landroid/app/Application;Lcom/launchdarkly/sdk/android/LDConfig;Lcom/launchdarkly/sdk/LDUser;)Ljava/util/concurrent/Future;", "")]
		public unsafe static IFuture Init(Application application, LDConfig config, LDUser user)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(application?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(user?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IFuture>(_members.StaticMethods.InvokeObjectMethod("init.(Landroid/app/Application;Lcom/launchdarkly/sdk/android/LDConfig;Lcom/launchdarkly/sdk/LDUser;)Ljava/util/concurrent/Future;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(application);
				GC.KeepAlive(config);
				GC.KeepAlive(user);
			}
		}

		[Register("init", "(Landroid/app/Application;Lcom/launchdarkly/sdk/android/LDConfig;Lcom/launchdarkly/sdk/LDUser;I)Lcom/launchdarkly/sdk/android/LDClient;", "")]
		public unsafe static LDClient Init(Application application, LDConfig config, LDUser user, int startWaitSeconds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(application?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(user?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(startWaitSeconds);
				return Java.Lang.Object.GetObject<LDClient>(_members.StaticMethods.InvokeObjectMethod("init.(Landroid/app/Application;Lcom/launchdarkly/sdk/android/LDConfig;Lcom/launchdarkly/sdk/LDUser;I)Lcom/launchdarkly/sdk/android/LDClient;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(application);
				GC.KeepAlive(config);
				GC.KeepAlive(user);
			}
		}

		private static Delegate GetIntVariation_Ljava_lang_String_IHandler()
		{
			if ((object)cb_intVariation_Ljava_lang_String_I == null)
			{
				cb_intVariation_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_I(n_IntVariation_Ljava_lang_String_I));
			}
			return cb_intVariation_Ljava_lang_String_I;
		}

		private static int n_IntVariation_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_key, int defaultValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return lDClient.IntVariation(key, defaultValue);
		}

		[Register("intVariation", "(Ljava/lang/String;I)I", "GetIntVariation_Ljava_lang_String_IHandler")]
		public unsafe virtual int IntVariation(string key, int defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeVirtualInt32Method("intVariation.(Ljava/lang/String;I)I", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetIntVariationDetail_Ljava_lang_String_IHandler()
		{
			if ((object)cb_intVariationDetail_Ljava_lang_String_I == null)
			{
				cb_intVariationDetail_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_IntVariationDetail_Ljava_lang_String_I));
			}
			return cb_intVariationDetail_Ljava_lang_String_I;
		}

		private static IntPtr n_IntVariationDetail_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_key, int defaultValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDClient.IntVariationDetail(key, defaultValue));
		}

		[Register("intVariationDetail", "(Ljava/lang/String;I)Lcom/launchdarkly/sdk/EvaluationDetail;", "GetIntVariationDetail_Ljava_lang_String_IHandler")]
		public unsafe virtual EvaluationDetail IntVariationDetail(string key, int defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return Java.Lang.Object.GetObject<EvaluationDetail>(_members.InstanceMethods.InvokeVirtualObjectMethod("intVariationDetail.(Ljava/lang/String;I)Lcom/launchdarkly/sdk/EvaluationDetail;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetJsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler()
		{
			if ((object)cb_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == null)
			{
				cb_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_JsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_));
			}
			return cb_jsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;
		}

		private static IntPtr n_JsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_defaultValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			LDValue defaultValue = Java.Lang.Object.GetObject<LDValue>(native_defaultValue, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDClient.JsonValueVariation(key, defaultValue));
		}

		[Register("jsonValueVariation", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDValue;", "GetJsonValueVariation_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler")]
		public unsafe virtual LDValue JsonValueVariation(string key, LDValue defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LDValue>(_members.InstanceMethods.InvokeVirtualObjectMethod("jsonValueVariation.(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/LDValue;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(defaultValue);
			}
		}

		private static Delegate GetJsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler()
		{
			if ((object)cb_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == null)
			{
				cb_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_JsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_));
			}
			return cb_jsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;
		}

		private static IntPtr n_JsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_defaultValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			LDValue defaultValue = Java.Lang.Object.GetObject<LDValue>(native_defaultValue, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDClient.JsonValueVariationDetail(key, defaultValue));
		}

		[Register("jsonValueVariationDetail", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/EvaluationDetail;", "GetJsonValueVariationDetail_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler")]
		public unsafe virtual EvaluationDetail JsonValueVariationDetail(string key, LDValue defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<EvaluationDetail>(_members.InstanceMethods.InvokeVirtualObjectMethod("jsonValueVariationDetail.(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)Lcom/launchdarkly/sdk/EvaluationDetail;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(defaultValue);
			}
		}

		private static Delegate GetRegisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_Handler()
		{
			if ((object)cb_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ == null)
			{
				cb_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RegisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_));
			}
			return cb_registerAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_;
		}

		private static void n_RegisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_allFlagsListener)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILDAllFlagsListener allFlagsListener = Java.Lang.Object.GetObject<ILDAllFlagsListener>(native_allFlagsListener, JniHandleOwnership.DoNotTransfer);
			lDClient.RegisterAllFlagsListener(allFlagsListener);
		}

		[Register("registerAllFlagsListener", "(Lcom/launchdarkly/sdk/android/LDAllFlagsListener;)V", "GetRegisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_Handler")]
		public unsafe virtual void RegisterAllFlagsListener(ILDAllFlagsListener allFlagsListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((allFlagsListener == null) ? IntPtr.Zero : ((Java.Lang.Object)allFlagsListener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerAllFlagsListener.(Lcom/launchdarkly/sdk/android/LDAllFlagsListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(allFlagsListener);
			}
		}

		private static Delegate GetRegisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_Handler()
		{
			if ((object)cb_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ == null)
			{
				cb_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RegisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_));
			}
			return cb_registerFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_;
		}

		private static void n_RegisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_flagKey, IntPtr native_listener)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string flagKey = JNIEnv.GetString(native_flagKey, JniHandleOwnership.DoNotTransfer);
			IFeatureFlagChangeListener listener = Java.Lang.Object.GetObject<IFeatureFlagChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			lDClient.RegisterFeatureFlagListener(flagKey, listener);
		}

		[Register("registerFeatureFlagListener", "(Ljava/lang/String;Lcom/launchdarkly/sdk/android/FeatureFlagChangeListener;)V", "GetRegisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_Handler")]
		public unsafe virtual void RegisterFeatureFlagListener(string flagKey, IFeatureFlagChangeListener listener)
		{
			IntPtr intPtr = JNIEnv.NewString(flagKey);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerFeatureFlagListener.(Ljava/lang/String;Lcom/launchdarkly/sdk/android/FeatureFlagChangeListener;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetRegisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_Handler()
		{
			if ((object)cb_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ == null)
			{
				cb_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RegisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_));
			}
			return cb_registerStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_;
		}

		private static void n_RegisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_LDStatusListener)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILDStatusListener lDStatusListener = Java.Lang.Object.GetObject<ILDStatusListener>(native_LDStatusListener, JniHandleOwnership.DoNotTransfer);
			lDClient.RegisterStatusListener(lDStatusListener);
		}

		[Register("registerStatusListener", "(Lcom/launchdarkly/sdk/android/LDStatusListener;)V", "GetRegisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_Handler")]
		public unsafe virtual void RegisterStatusListener(ILDStatusListener LDStatusListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((LDStatusListener == null) ? IntPtr.Zero : ((Java.Lang.Object)LDStatusListener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerStatusListener.(Lcom/launchdarkly/sdk/android/LDStatusListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(LDStatusListener);
			}
		}

		private static Delegate GetSetOfflineHandler()
		{
			if ((object)cb_setOffline == null)
			{
				cb_setOffline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SetOffline));
			}
			return cb_setOffline;
		}

		private static void n_SetOffline(IntPtr jnienv, IntPtr native__this)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			lDClient.SetOffline();
		}

		[Register("setOffline", "()V", "GetSetOfflineHandler")]
		public unsafe virtual void SetOffline()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOffline.()V", this, null);
		}

		private static Delegate GetSetOnlineHandler()
		{
			if ((object)cb_setOnline == null)
			{
				cb_setOnline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SetOnline));
			}
			return cb_setOnline;
		}

		private static void n_SetOnline(IntPtr jnienv, IntPtr native__this)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			lDClient.SetOnline();
		}

		[Register("setOnline", "()V", "GetSetOnlineHandler")]
		public unsafe virtual void SetOnline()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnline.()V", this, null);
		}

		private static Delegate GetStringVariation_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_stringVariation_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_stringVariation_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_StringVariation_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_stringVariation_Ljava_lang_String_Ljava_lang_String_;
		}

		private static IntPtr n_StringVariation_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_defaultValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string defaultValue = JNIEnv.GetString(native_defaultValue, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDClient.StringVariation(key, defaultValue));
		}

		[Register("stringVariation", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "GetStringVariation_Ljava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual string StringVariation(string key, string defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			IntPtr intPtr2 = JNIEnv.NewString(defaultValue);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("stringVariation.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		private static Delegate GetStringVariationDetail_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_StringVariationDetail_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_stringVariationDetail_Ljava_lang_String_Ljava_lang_String_;
		}

		private static IntPtr n_StringVariationDetail_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_defaultValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string defaultValue = JNIEnv.GetString(native_defaultValue, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDClient.StringVariationDetail(key, defaultValue));
		}

		[Register("stringVariationDetail", "(Ljava/lang/String;Ljava/lang/String;)Lcom/launchdarkly/sdk/EvaluationDetail;", "GetStringVariationDetail_Ljava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual EvaluationDetail StringVariationDetail(string key, string defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			IntPtr intPtr2 = JNIEnv.NewString(defaultValue);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<EvaluationDetail>(_members.InstanceMethods.InvokeVirtualObjectMethod("stringVariationDetail.(Ljava/lang/String;Ljava/lang/String;)Lcom/launchdarkly/sdk/EvaluationDetail;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		private static Delegate GetTrack_Ljava_lang_String_Handler()
		{
			if ((object)cb_track_Ljava_lang_String_ == null)
			{
				cb_track_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Track_Ljava_lang_String_));
			}
			return cb_track_Ljava_lang_String_;
		}

		private static void n_Track_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_eventName)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string eventName = JNIEnv.GetString(native_eventName, JniHandleOwnership.DoNotTransfer);
			lDClient.Track(eventName);
		}

		[Register("track", "(Ljava/lang/String;)V", "GetTrack_Ljava_lang_String_Handler")]
		public unsafe virtual void Track(string eventName)
		{
			IntPtr intPtr = JNIEnv.NewString(eventName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("track.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetTrackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler()
		{
			if ((object)cb_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ == null)
			{
				cb_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_TrackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_));
			}
			return cb_trackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_;
		}

		private static void n_TrackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_(IntPtr jnienv, IntPtr native__this, IntPtr native_eventName, IntPtr native_data)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string eventName = JNIEnv.GetString(native_eventName, JniHandleOwnership.DoNotTransfer);
			LDValue data = Java.Lang.Object.GetObject<LDValue>(native_data, JniHandleOwnership.DoNotTransfer);
			lDClient.TrackData(eventName, data);
		}

		[Register("trackData", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)V", "GetTrackData_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Handler")]
		public unsafe virtual void TrackData(string eventName, LDValue data)
		{
			IntPtr intPtr = JNIEnv.NewString(eventName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("trackData.(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetTrackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_DHandler()
		{
			if ((object)cb_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D == null)
			{
				cb_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLD_V(n_TrackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D));
			}
			return cb_trackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D;
		}

		private static void n_TrackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_D(IntPtr jnienv, IntPtr native__this, IntPtr native_eventName, IntPtr native_data, double metricValue)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string eventName = JNIEnv.GetString(native_eventName, JniHandleOwnership.DoNotTransfer);
			LDValue data = Java.Lang.Object.GetObject<LDValue>(native_data, JniHandleOwnership.DoNotTransfer);
			lDClient.TrackMetric(eventName, data, metricValue);
		}

		[Register("trackMetric", "(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;D)V", "GetTrackMetric_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_DHandler")]
		public unsafe virtual void TrackMetric(string eventName, LDValue data, double metricValue)
		{
			IntPtr intPtr = JNIEnv.NewString(eventName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(metricValue);
				_members.InstanceMethods.InvokeVirtualVoidMethod("trackMetric.(Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;D)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetUnregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_Handler()
		{
			if ((object)cb_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ == null)
			{
				cb_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_));
			}
			return cb_unregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_;
		}

		private static void n_UnregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_allFlagsListener)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILDAllFlagsListener allFlagsListener = Java.Lang.Object.GetObject<ILDAllFlagsListener>(native_allFlagsListener, JniHandleOwnership.DoNotTransfer);
			lDClient.UnregisterAllFlagsListener(allFlagsListener);
		}

		[Register("unregisterAllFlagsListener", "(Lcom/launchdarkly/sdk/android/LDAllFlagsListener;)V", "GetUnregisterAllFlagsListener_Lcom_launchdarkly_sdk_android_LDAllFlagsListener_Handler")]
		public unsafe virtual void UnregisterAllFlagsListener(ILDAllFlagsListener allFlagsListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((allFlagsListener == null) ? IntPtr.Zero : ((Java.Lang.Object)allFlagsListener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterAllFlagsListener.(Lcom/launchdarkly/sdk/android/LDAllFlagsListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(allFlagsListener);
			}
		}

		private static Delegate GetUnregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_Handler()
		{
			if ((object)cb_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ == null)
			{
				cb_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_UnregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_));
			}
			return cb_unregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_;
		}

		private static void n_UnregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_flagKey, IntPtr native_listener)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string flagKey = JNIEnv.GetString(native_flagKey, JniHandleOwnership.DoNotTransfer);
			IFeatureFlagChangeListener listener = Java.Lang.Object.GetObject<IFeatureFlagChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			lDClient.UnregisterFeatureFlagListener(flagKey, listener);
		}

		[Register("unregisterFeatureFlagListener", "(Ljava/lang/String;Lcom/launchdarkly/sdk/android/FeatureFlagChangeListener;)V", "GetUnregisterFeatureFlagListener_Ljava_lang_String_Lcom_launchdarkly_sdk_android_FeatureFlagChangeListener_Handler")]
		public unsafe virtual void UnregisterFeatureFlagListener(string flagKey, IFeatureFlagChangeListener listener)
		{
			IntPtr intPtr = JNIEnv.NewString(flagKey);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterFeatureFlagListener.(Ljava/lang/String;Lcom/launchdarkly/sdk/android/FeatureFlagChangeListener;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetUnregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_Handler()
		{
			if ((object)cb_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ == null)
			{
				cb_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_));
			}
			return cb_unregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_;
		}

		private static void n_UnregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_LDStatusListener)
		{
			LDClient lDClient = Java.Lang.Object.GetObject<LDClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILDStatusListener lDStatusListener = Java.Lang.Object.GetObject<ILDStatusListener>(native_LDStatusListener, JniHandleOwnership.DoNotTransfer);
			lDClient.UnregisterStatusListener(lDStatusListener);
		}

		[Register("unregisterStatusListener", "(Lcom/launchdarkly/sdk/android/LDStatusListener;)V", "GetUnregisterStatusListener_Lcom_launchdarkly_sdk_android_LDStatusListener_Handler")]
		public unsafe virtual void UnregisterStatusListener(ILDStatusListener LDStatusListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((LDStatusListener == null) ? IntPtr.Zero : ((Java.Lang.Object)LDStatusListener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterStatusListener.(Lcom/launchdarkly/sdk/android/LDStatusListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(LDStatusListener);
			}
		}
	}
	[Register("com/launchdarkly/sdk/android/LDConfig", DoNotGenerateAcw = true)]
	public class LDConfig : Java.Lang.Object
	{
		[Register("com/launchdarkly/sdk/android/LDConfig$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDConfig$Builder", typeof(Builder));

			private static Delegate cb_allAttributesPrivate;

			private static Delegate cb_applicationInfo_Lcom_launchdarkly_sdk_android_integrations_ApplicationInfoBuilder_;

			private static Delegate cb_autoAliasingOptOut_Z;

			private static Delegate cb_backgroundPollingIntervalMillis_I;

			private static Delegate cb_build;

			private static Delegate cb_connectionTimeoutMillis_I;

			private static Delegate cb_dataSource_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_;

			private static Delegate cb_diagnosticOptOut_Z;

			private static Delegate cb_diagnosticRecordingIntervalMillis_I;

			private static Delegate cb_disableBackgroundUpdating_Z;

			private static Delegate cb_evaluationReasons_Z;

			private static Delegate cb_events_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_;

			private static Delegate cb_eventsCapacity_I;

			private static Delegate cb_eventsFlushIntervalMillis_I;

			private static Delegate cb_eventsUri_Landroid_net_Uri_;

			private static Delegate cb_headerTransform_Lcom_launchdarkly_sdk_android_LDHeaderUpdater_;

			private static Delegate cb_http_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_;

			private static Delegate cb_inlineUsersInEvents_Z;

			private static Delegate cb_logAdapter_Lcom_launchdarkly_logging_LDLogAdapter_;

			private static Delegate cb_logLevel_Lcom_launchdarkly_logging_LDLogLevel_;

			private static Delegate cb_loggerName_Ljava_lang_String_;

			private static Delegate cb_maxCachedUsers_I;

			private static Delegate cb_mobileKey_Ljava_lang_String_;

			private static Delegate cb_offline_Z;

			private static Delegate cb_pollUri_Landroid_net_Uri_;

			private static Delegate cb_pollingIntervalMillis_I;

			private static Delegate cb_privateAttributes_arrayLcom_launchdarkly_sdk_UserAttribute_;

			private static Delegate cb_secondaryMobileKeys_Ljava_util_Map_;

			private static Delegate cb_serviceEndpoints_Lcom_launchdarkly_sdk_android_integrations_ServiceEndpointsBuilder_;

			private static Delegate cb_stream_Z;

			private static Delegate cb_streamUri_Landroid_net_Uri_;

			private static Delegate cb_useReport_Z;

			private static Delegate cb_wrapperName_Ljava_lang_String_;

			private static Delegate cb_wrapperVersion_Ljava_lang_String_;

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

			protected Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Builder()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			[Obsolete]
			private static Delegate GetAllAttributesPrivateHandler()
			{
				if ((object)cb_allAttributesPrivate == null)
				{
					cb_allAttributesPrivate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AllAttributesPrivate));
				}
				return cb_allAttributesPrivate;
			}

			[Obsolete]
			private static IntPtr n_AllAttributesPrivate(IntPtr jnienv, IntPtr native__this)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AllAttributesPrivate());
			}

			[Obsolete("deprecated")]
			[Register("allAttributesPrivate", "()Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetAllAttributesPrivateHandler")]
			public unsafe virtual Builder AllAttributesPrivate()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("allAttributesPrivate.()Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetApplicationInfo_Lcom_launchdarkly_sdk_android_integrations_ApplicationInfoBuilder_Handler()
			{
				if ((object)cb_applicationInfo_Lcom_launchdarkly_sdk_android_integrations_ApplicationInfoBuilder_ == null)
				{
					cb_applicationInfo_Lcom_launchdarkly_sdk_android_integrations_ApplicationInfoBuilder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ApplicationInfo_Lcom_launchdarkly_sdk_android_integrations_ApplicationInfoBuilder_));
				}
				return cb_applicationInfo_Lcom_launchdarkly_sdk_android_integrations_ApplicationInfoBuilder_;
			}

			private static IntPtr n_ApplicationInfo_Lcom_launchdarkly_sdk_android_integrations_ApplicationInfoBuilder_(IntPtr jnienv, IntPtr native__this, IntPtr native_applicationInfoBuilder)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ApplicationInfoBuilder applicationInfoBuilder = Java.Lang.Object.GetObject<ApplicationInfoBuilder>(native_applicationInfoBuilder, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ApplicationInfo(applicationInfoBuilder));
			}

			[Register("applicationInfo", "(Lcom/launchdarkly/sdk/android/integrations/ApplicationInfoBuilder;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetApplicationInfo_Lcom_launchdarkly_sdk_android_integrations_ApplicationInfoBuilder_Handler")]
			public unsafe virtual Builder ApplicationInfo(ApplicationInfoBuilder applicationInfoBuilder)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(applicationInfoBuilder?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("applicationInfo.(Lcom/launchdarkly/sdk/android/integrations/ApplicationInfoBuilder;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(applicationInfoBuilder);
				}
			}

			private static Delegate GetAutoAliasingOptOut_ZHandler()
			{
				if ((object)cb_autoAliasingOptOut_Z == null)
				{
					cb_autoAliasingOptOut_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_AutoAliasingOptOut_Z));
				}
				return cb_autoAliasingOptOut_Z;
			}

			private static IntPtr n_AutoAliasingOptOut_Z(IntPtr jnienv, IntPtr native__this, bool autoAliasingOptOut)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AutoAliasingOptOut(autoAliasingOptOut));
			}

			[Register("autoAliasingOptOut", "(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetAutoAliasingOptOut_ZHandler")]
			public unsafe virtual Builder AutoAliasingOptOut(bool autoAliasingOptOut)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(autoAliasingOptOut);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("autoAliasingOptOut.(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Obsolete]
			private static Delegate GetBackgroundPollingIntervalMillis_IHandler()
			{
				if ((object)cb_backgroundPollingIntervalMillis_I == null)
				{
					cb_backgroundPollingIntervalMillis_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_BackgroundPollingIntervalMillis_I));
				}
				return cb_backgroundPollingIntervalMillis_I;
			}

			[Obsolete]
			private static IntPtr n_BackgroundPollingIntervalMillis_I(IntPtr jnienv, IntPtr native__this, int backgroundPollingIntervalMillis)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.BackgroundPollingIntervalMillis(backgroundPollingIntervalMillis));
			}

			[Obsolete("deprecated")]
			[Register("backgroundPollingIntervalMillis", "(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetBackgroundPollingIntervalMillis_IHandler")]
			public unsafe virtual Builder BackgroundPollingIntervalMillis(int backgroundPollingIntervalMillis)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(backgroundPollingIntervalMillis);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("backgroundPollingIntervalMillis.(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetBuildHandler()
			{
				if ((object)cb_build == null)
				{
					cb_build = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
				}
				return cb_build;
			}

			private static IntPtr n_Build(IntPtr jnienv, IntPtr native__this)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Build());
			}

			[Register("build", "()Lcom/launchdarkly/sdk/android/LDConfig;", "GetBuildHandler")]
			public unsafe virtual LDConfig Build()
			{
				return Java.Lang.Object.GetObject<LDConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/launchdarkly/sdk/android/LDConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Obsolete]
			private static Delegate GetConnectionTimeoutMillis_IHandler()
			{
				if ((object)cb_connectionTimeoutMillis_I == null)
				{
					cb_connectionTimeoutMillis_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_ConnectionTimeoutMillis_I));
				}
				return cb_connectionTimeoutMillis_I;
			}

			[Obsolete]
			private static IntPtr n_ConnectionTimeoutMillis_I(IntPtr jnienv, IntPtr native__this, int connectionTimeoutMillis)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ConnectionTimeoutMillis(connectionTimeoutMillis));
			}

			[Obsolete("deprecated")]
			[Register("connectionTimeoutMillis", "(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetConnectionTimeoutMillis_IHandler")]
			public unsafe virtual Builder ConnectionTimeoutMillis(int connectionTimeoutMillis)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(connectionTimeoutMillis);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("connectionTimeoutMillis.(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetDataSource_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_Handler()
			{
				if ((object)cb_dataSource_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_ == null)
				{
					cb_dataSource_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DataSource_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_));
				}
				return cb_dataSource_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_;
			}

			private static IntPtr n_DataSource_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_(IntPtr jnienv, IntPtr native__this, IntPtr native_dataSourceConfigurer)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IComponentConfigurer dataSourceConfigurer = Java.Lang.Object.GetObject<IComponentConfigurer>(native_dataSourceConfigurer, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.DataSource(dataSourceConfigurer));
			}

			[Register("dataSource", "(Lcom/launchdarkly/sdk/android/subsystems/ComponentConfigurer;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetDataSource_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_Handler")]
			public unsafe virtual Builder DataSource(IComponentConfigurer dataSourceConfigurer)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((dataSourceConfigurer == null) ? IntPtr.Zero : ((Java.Lang.Object)dataSourceConfigurer).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("dataSource.(Lcom/launchdarkly/sdk/android/subsystems/ComponentConfigurer;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(dataSourceConfigurer);
				}
			}

			private static Delegate GetDiagnosticOptOut_ZHandler()
			{
				if ((object)cb_diagnosticOptOut_Z == null)
				{
					cb_diagnosticOptOut_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_DiagnosticOptOut_Z));
				}
				return cb_diagnosticOptOut_Z;
			}

			private static IntPtr n_DiagnosticOptOut_Z(IntPtr jnienv, IntPtr native__this, bool diagnosticOptOut)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.DiagnosticOptOut(diagnosticOptOut));
			}

			[Register("diagnosticOptOut", "(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetDiagnosticOptOut_ZHandler")]
			public unsafe virtual Builder DiagnosticOptOut(bool diagnosticOptOut)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(diagnosticOptOut);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("diagnosticOptOut.(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Obsolete]
			private static Delegate GetDiagnosticRecordingIntervalMillis_IHandler()
			{
				if ((object)cb_diagnosticRecordingIntervalMillis_I == null)
				{
					cb_diagnosticRecordingIntervalMillis_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_DiagnosticRecordingIntervalMillis_I));
				}
				return cb_diagnosticRecordingIntervalMillis_I;
			}

			[Obsolete]
			private static IntPtr n_DiagnosticRecordingIntervalMillis_I(IntPtr jnienv, IntPtr native__this, int diagnosticRecordingIntervalMillis)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.DiagnosticRecordingIntervalMillis(diagnosticRecordingIntervalMillis));
			}

			[Obsolete("deprecated")]
			[Register("diagnosticRecordingIntervalMillis", "(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetDiagnosticRecordingIntervalMillis_IHandler")]
			public unsafe virtual Builder DiagnosticRecordingIntervalMillis(int diagnosticRecordingIntervalMillis)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(diagnosticRecordingIntervalMillis);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("diagnosticRecordingIntervalMillis.(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetDisableBackgroundUpdating_ZHandler()
			{
				if ((object)cb_disableBackgroundUpdating_Z == null)
				{
					cb_disableBackgroundUpdating_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_DisableBackgroundUpdating_Z));
				}
				return cb_disableBackgroundUpdating_Z;
			}

			private static IntPtr n_DisableBackgroundUpdating_Z(IntPtr jnienv, IntPtr native__this, bool disableBackgroundUpdating)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.DisableBackgroundUpdating(disableBackgroundUpdating));
			}

			[Register("disableBackgroundUpdating", "(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetDisableBackgroundUpdating_ZHandler")]
			public unsafe virtual Builder DisableBackgroundUpdating(bool disableBackgroundUpdating)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(disableBackgroundUpdating);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("disableBackgroundUpdating.(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetEvaluationReasons_ZHandler()
			{
				if ((object)cb_evaluationReasons_Z == null)
				{
					cb_evaluationReasons_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EvaluationReasons_Z));
				}
				return cb_evaluationReasons_Z;
			}

			private static IntPtr n_EvaluationReasons_Z(IntPtr jnienv, IntPtr native__this, bool evaluationReasons)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.EvaluationReasons(evaluationReasons));
			}

			[Register("evaluationReasons", "(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetEvaluationReasons_ZHandler")]
			public unsafe virtual Builder EvaluationReasons(bool evaluationReasons)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(evaluationReasons);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("evaluationReasons.(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetEvents_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_Handler()
			{
				if ((object)cb_events_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_ == null)
				{
					cb_events_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Events_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_));
				}
				return cb_events_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_;
			}

			private static IntPtr n_Events_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_(IntPtr jnienv, IntPtr native__this, IntPtr native_eventsConfigurer)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IComponentConfigurer eventsConfigurer = Java.Lang.Object.GetObject<IComponentConfigurer>(native_eventsConfigurer, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Events(eventsConfigurer));
			}

			[Register("events", "(Lcom/launchdarkly/sdk/android/subsystems/ComponentConfigurer;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetEvents_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_Handler")]
			public unsafe virtual Builder Events(IComponentConfigurer eventsConfigurer)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((eventsConfigurer == null) ? IntPtr.Zero : ((Java.Lang.Object)eventsConfigurer).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("events.(Lcom/launchdarkly/sdk/android/subsystems/ComponentConfigurer;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(eventsConfigurer);
				}
			}

			[Obsolete]
			private static Delegate GetEventsCapacity_IHandler()
			{
				if ((object)cb_eventsCapacity_I == null)
				{
					cb_eventsCapacity_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_EventsCapacity_I));
				}
				return cb_eventsCapacity_I;
			}

			[Obsolete]
			private static IntPtr n_EventsCapacity_I(IntPtr jnienv, IntPtr native__this, int eventsCapacity)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.EventsCapacity(eventsCapacity));
			}

			[Obsolete("deprecated")]
			[Register("eventsCapacity", "(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetEventsCapacity_IHandler")]
			public unsafe virtual Builder EventsCapacity(int eventsCapacity)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(eventsCapacity);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("eventsCapacity.(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Obsolete]
			private static Delegate GetEventsFlushIntervalMillis_IHandler()
			{
				if ((object)cb_eventsFlushIntervalMillis_I == null)
				{
					cb_eventsFlushIntervalMillis_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_EventsFlushIntervalMillis_I));
				}
				return cb_eventsFlushIntervalMillis_I;
			}

			[Obsolete]
			private static IntPtr n_EventsFlushIntervalMillis_I(IntPtr jnienv, IntPtr native__this, int eventsFlushIntervalMillis)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.EventsFlushIntervalMillis(eventsFlushIntervalMillis));
			}

			[Obsolete("deprecated")]
			[Register("eventsFlushIntervalMillis", "(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetEventsFlushIntervalMillis_IHandler")]
			public unsafe virtual Builder EventsFlushIntervalMillis(int eventsFlushIntervalMillis)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(eventsFlushIntervalMillis);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("eventsFlushIntervalMillis.(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Obsolete]
			private static Delegate GetEventsUri_Landroid_net_Uri_Handler()
			{
				if ((object)cb_eventsUri_Landroid_net_Uri_ == null)
				{
					cb_eventsUri_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_EventsUri_Landroid_net_Uri_));
				}
				return cb_eventsUri_Landroid_net_Uri_;
			}

			[Obsolete]
			private static IntPtr n_EventsUri_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_eventsUri)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Android.Net.Uri eventsUri = Java.Lang.Object.GetObject<global::Android.Net.Uri>(native_eventsUri, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.EventsUri(eventsUri));
			}

			[Obsolete("deprecated")]
			[Register("eventsUri", "(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetEventsUri_Landroid_net_Uri_Handler")]
			public unsafe virtual Builder EventsUri(global::Android.Net.Uri eventsUri)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(eventsUri?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("eventsUri.(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(eventsUri);
				}
			}

			[Obsolete]
			private static Delegate GetHeaderTransform_Lcom_launchdarkly_sdk_android_LDHeaderUpdater_Handler()
			{
				if ((object)cb_headerTransform_Lcom_launchdarkly_sdk_android_LDHeaderUpdater_ == null)
				{
					cb_headerTransform_Lcom_launchdarkly_sdk_android_LDHeaderUpdater_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_HeaderTransform_Lcom_launchdarkly_sdk_android_LDHeaderUpdater_));
				}
				return cb_headerTransform_Lcom_launchdarkly_sdk_android_LDHeaderUpdater_;
			}

			[Obsolete]
			private static IntPtr n_HeaderTransform_Lcom_launchdarkly_sdk_android_LDHeaderUpdater_(IntPtr jnienv, IntPtr native__this, IntPtr native_headerTransform)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ILDHeaderUpdater headerTransform = Java.Lang.Object.GetObject<ILDHeaderUpdater>(native_headerTransform, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.HeaderTransform(headerTransform));
			}

			[Obsolete("deprecated")]
			[Register("headerTransform", "(Lcom/launchdarkly/sdk/android/LDHeaderUpdater;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetHeaderTransform_Lcom_launchdarkly_sdk_android_LDHeaderUpdater_Handler")]
			public unsafe virtual Builder HeaderTransform(ILDHeaderUpdater headerTransform)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((headerTransform == null) ? IntPtr.Zero : ((Java.Lang.Object)headerTransform).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("headerTransform.(Lcom/launchdarkly/sdk/android/LDHeaderUpdater;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(headerTransform);
				}
			}

			private static Delegate GetHttp_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_Handler()
			{
				if ((object)cb_http_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_ == null)
				{
					cb_http_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Http_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_));
				}
				return cb_http_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_;
			}

			private static IntPtr n_Http_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_(IntPtr jnienv, IntPtr native__this, IntPtr native_httpConfigurer)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IComponentConfigurer httpConfigurer = Java.Lang.Object.GetObject<IComponentConfigurer>(native_httpConfigurer, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Http(httpConfigurer));
			}

			[Register("http", "(Lcom/launchdarkly/sdk/android/subsystems/ComponentConfigurer;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetHttp_Lcom_launchdarkly_sdk_android_subsystems_ComponentConfigurer_Handler")]
			public unsafe virtual Builder Http(IComponentConfigurer httpConfigurer)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((httpConfigurer == null) ? IntPtr.Zero : ((Java.Lang.Object)httpConfigurer).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("http.(Lcom/launchdarkly/sdk/android/subsystems/ComponentConfigurer;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(httpConfigurer);
				}
			}

			[Obsolete]
			private static Delegate GetInlineUsersInEvents_ZHandler()
			{
				if ((object)cb_inlineUsersInEvents_Z == null)
				{
					cb_inlineUsersInEvents_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_InlineUsersInEvents_Z));
				}
				return cb_inlineUsersInEvents_Z;
			}

			[Obsolete]
			private static IntPtr n_InlineUsersInEvents_Z(IntPtr jnienv, IntPtr native__this, bool inlineUsersInEvents)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.InlineUsersInEvents(inlineUsersInEvents));
			}

			[Obsolete("deprecated")]
			[Register("inlineUsersInEvents", "(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetInlineUsersInEvents_ZHandler")]
			public unsafe virtual Builder InlineUsersInEvents(bool inlineUsersInEvents)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(inlineUsersInEvents);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("inlineUsersInEvents.(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetLogAdapter_Lcom_launchdarkly_logging_LDLogAdapter_Handler()
			{
				if ((object)cb_logAdapter_Lcom_launchdarkly_logging_LDLogAdapter_ == null)
				{
					cb_logAdapter_Lcom_launchdarkly_logging_LDLogAdapter_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_LogAdapter_Lcom_launchdarkly_logging_LDLogAdapter_));
				}
				return cb_logAdapter_Lcom_launchdarkly_logging_LDLogAdapter_;
			}

			private static IntPtr n_LogAdapter_Lcom_launchdarkly_logging_LDLogAdapter_(IntPtr jnienv, IntPtr native__this, IntPtr native_logAdapter)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ILDLogAdapter logAdapter = Java.Lang.Object.GetObject<ILDLogAdapter>(native_logAdapter, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.LogAdapter(logAdapter));
			}

			[Register("logAdapter", "(Lcom/launchdarkly/logging/LDLogAdapter;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetLogAdapter_Lcom_launchdarkly_logging_LDLogAdapter_Handler")]
			public unsafe virtual Builder LogAdapter(ILDLogAdapter logAdapter)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((logAdapter == null) ? IntPtr.Zero : ((Java.Lang.Object)logAdapter).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("logAdapter.(Lcom/launchdarkly/logging/LDLogAdapter;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(logAdapter);
				}
			}

			private static Delegate GetLogLevel_Lcom_launchdarkly_logging_LDLogLevel_Handler()
			{
				if ((object)cb_logLevel_Lcom_launchdarkly_logging_LDLogLevel_ == null)
				{
					cb_logLevel_Lcom_launchdarkly_logging_LDLogLevel_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_LogLevel_Lcom_launchdarkly_logging_LDLogLevel_));
				}
				return cb_logLevel_Lcom_launchdarkly_logging_LDLogLevel_;
			}

			private static IntPtr n_LogLevel_Lcom_launchdarkly_logging_LDLogLevel_(IntPtr jnienv, IntPtr native__this, IntPtr native_logLevel)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				LDLogLevel logLevel = Java.Lang.Object.GetObject<LDLogLevel>(native_logLevel, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.LogLevel(logLevel));
			}

			[Register("logLevel", "(Lcom/launchdarkly/logging/LDLogLevel;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetLogLevel_Lcom_launchdarkly_logging_LDLogLevel_Handler")]
			public unsafe virtual Builder LogLevel(LDLogLevel logLevel)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(logLevel?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("logLevel.(Lcom/launchdarkly/logging/LDLogLevel;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(logLevel);
				}
			}

			private static Delegate GetLoggerName_Ljava_lang_String_Handler()
			{
				if ((object)cb_loggerName_Ljava_lang_String_ == null)
				{
					cb_loggerName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_LoggerName_Ljava_lang_String_));
				}
				return cb_loggerName_Ljava_lang_String_;
			}

			private static IntPtr n_LoggerName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_loggerName)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string loggerName = JNIEnv.GetString(native_loggerName, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.LoggerName(loggerName));
			}

			[Register("loggerName", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetLoggerName_Ljava_lang_String_Handler")]
			public unsafe virtual Builder LoggerName(string loggerName)
			{
				IntPtr intPtr = JNIEnv.NewString(loggerName);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("loggerName.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetMaxCachedUsers_IHandler()
			{
				if ((object)cb_maxCachedUsers_I == null)
				{
					cb_maxCachedUsers_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_MaxCachedUsers_I));
				}
				return cb_maxCachedUsers_I;
			}

			private static IntPtr n_MaxCachedUsers_I(IntPtr jnienv, IntPtr native__this, int maxCachedUsers)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.MaxCachedUsers(maxCachedUsers));
			}

			[Register("maxCachedUsers", "(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetMaxCachedUsers_IHandler")]
			public unsafe virtual Builder MaxCachedUsers(int maxCachedUsers)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(maxCachedUsers);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("maxCachedUsers.(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetMobileKey_Ljava_lang_String_Handler()
			{
				if ((object)cb_mobileKey_Ljava_lang_String_ == null)
				{
					cb_mobileKey_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_MobileKey_Ljava_lang_String_));
				}
				return cb_mobileKey_Ljava_lang_String_;
			}

			private static IntPtr n_MobileKey_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_mobileKey)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string mobileKey = JNIEnv.GetString(native_mobileKey, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.MobileKey(mobileKey));
			}

			[Register("mobileKey", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetMobileKey_Ljava_lang_String_Handler")]
			public unsafe virtual Builder MobileKey(string mobileKey)
			{
				IntPtr intPtr = JNIEnv.NewString(mobileKey);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("mobileKey.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetOffline_ZHandler()
			{
				if ((object)cb_offline_Z == null)
				{
					cb_offline_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_Offline_Z));
				}
				return cb_offline_Z;
			}

			private static IntPtr n_Offline_Z(IntPtr jnienv, IntPtr native__this, bool offline)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Offline(offline));
			}

			[Register("offline", "(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetOffline_ZHandler")]
			public unsafe virtual Builder Offline(bool offline)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(offline);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("offline.(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Obsolete]
			private static Delegate GetPollUri_Landroid_net_Uri_Handler()
			{
				if ((object)cb_pollUri_Landroid_net_Uri_ == null)
				{
					cb_pollUri_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PollUri_Landroid_net_Uri_));
				}
				return cb_pollUri_Landroid_net_Uri_;
			}

			[Obsolete]
			private static IntPtr n_PollUri_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_pollUri)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Android.Net.Uri pollUri = Java.Lang.Object.GetObject<global::Android.Net.Uri>(native_pollUri, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PollUri(pollUri));
			}

			[Obsolete("deprecated")]
			[Register("pollUri", "(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetPollUri_Landroid_net_Uri_Handler")]
			public unsafe virtual Builder PollUri(global::Android.Net.Uri pollUri)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(pollUri?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("pollUri.(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(pollUri);
				}
			}

			[Obsolete]
			private static Delegate GetPollingIntervalMillis_IHandler()
			{
				if ((object)cb_pollingIntervalMillis_I == null)
				{
					cb_pollingIntervalMillis_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_PollingIntervalMillis_I));
				}
				return cb_pollingIntervalMillis_I;
			}

			[Obsolete]
			private static IntPtr n_PollingIntervalMillis_I(IntPtr jnienv, IntPtr native__this, int pollingIntervalMillis)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PollingIntervalMillis(pollingIntervalMillis));
			}

			[Obsolete("deprecated")]
			[Register("pollingIntervalMillis", "(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetPollingIntervalMillis_IHandler")]
			public unsafe virtual Builder PollingIntervalMillis(int pollingIntervalMillis)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(pollingIntervalMillis);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("pollingIntervalMillis.(I)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Obsolete]
			private static Delegate GetPrivateAttributes_arrayLcom_launchdarkly_sdk_UserAttribute_Handler()
			{
				if ((object)cb_privateAttributes_arrayLcom_launchdarkly_sdk_UserAttribute_ == null)
				{
					cb_privateAttributes_arrayLcom_launchdarkly_sdk_UserAttribute_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PrivateAttributes_arrayLcom_launchdarkly_sdk_UserAttribute_));
				}
				return cb_privateAttributes_arrayLcom_launchdarkly_sdk_UserAttribute_;
			}

			[Obsolete]
			private static IntPtr n_PrivateAttributes_arrayLcom_launchdarkly_sdk_UserAttribute_(IntPtr jnienv, IntPtr native__this, IntPtr native_privateAttributes)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				UserAttribute[] array = (UserAttribute[])JNIEnv.GetArray(native_privateAttributes, JniHandleOwnership.DoNotTransfer, typeof(UserAttribute));
				IntPtr result = JNIEnv.ToLocalJniHandle(builder.PrivateAttributes(array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_privateAttributes);
				}
				return result;
			}

			[Obsolete("deprecated")]
			[Register("privateAttributes", "([Lcom/launchdarkly/sdk/UserAttribute;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetPrivateAttributes_arrayLcom_launchdarkly_sdk_UserAttribute_Handler")]
			public unsafe virtual Builder PrivateAttributes(params UserAttribute[] privateAttributes)
			{
				IntPtr intPtr = JNIEnv.NewArray(privateAttributes);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("privateAttributes.([Lcom/launchdarkly/sdk/UserAttribute;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (privateAttributes != null)
					{
						JNIEnv.CopyArray(intPtr, privateAttributes);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(privateAttributes);
				}
			}

			private static Delegate GetSecondaryMobileKeys_Ljava_util_Map_Handler()
			{
				if ((object)cb_secondaryMobileKeys_Ljava_util_Map_ == null)
				{
					cb_secondaryMobileKeys_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SecondaryMobileKeys_Ljava_util_Map_));
				}
				return cb_secondaryMobileKeys_Ljava_util_Map_;
			}

			private static IntPtr n_SecondaryMobileKeys_Ljava_util_Map_(IntPtr jnienv, IntPtr native__this, IntPtr native_secondaryMobileKeys)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDictionary<string, string> secondaryMobileKeys = JavaDictionary<string, string>.FromJniHandle(native_secondaryMobileKeys, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SecondaryMobileKeys(secondaryMobileKeys));
			}

			[Register("secondaryMobileKeys", "(Ljava/util/Map;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetSecondaryMobileKeys_Ljava_util_Map_Handler")]
			public unsafe virtual Builder SecondaryMobileKeys(IDictionary<string, string> secondaryMobileKeys)
			{
				IntPtr intPtr = JavaDictionary<string, string>.ToLocalJniHandle(secondaryMobileKeys);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("secondaryMobileKeys.(Ljava/util/Map;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(secondaryMobileKeys);
				}
			}

			private static Delegate GetServiceEndpoints_Lcom_launchdarkly_sdk_android_integrations_ServiceEndpointsBuilder_Handler()
			{
				if ((object)cb_serviceEndpoints_Lcom_launchdarkly_sdk_android_integrations_ServiceEndpointsBuilder_ == null)
				{
					cb_serviceEndpoints_Lcom_launchdarkly_sdk_android_integrations_ServiceEndpointsBuilder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ServiceEndpoints_Lcom_launchdarkly_sdk_android_integrations_ServiceEndpointsBuilder_));
				}
				return cb_serviceEndpoints_Lcom_launchdarkly_sdk_android_integrations_ServiceEndpointsBuilder_;
			}

			private static IntPtr n_ServiceEndpoints_Lcom_launchdarkly_sdk_android_integrations_ServiceEndpointsBuilder_(IntPtr jnienv, IntPtr native__this, IntPtr native_serviceEndpointsBuilder)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(native_serviceEndpointsBuilder, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ServiceEndpoints(serviceEndpointsBuilder));
			}

			[Register("serviceEndpoints", "(Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetServiceEndpoints_Lcom_launchdarkly_sdk_android_integrations_ServiceEndpointsBuilder_Handler")]
			public unsafe virtual Builder ServiceEndpoints(ServiceEndpointsBuilder serviceEndpointsBuilder)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(serviceEndpointsBuilder?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("serviceEndpoints.(Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(serviceEndpointsBuilder);
				}
			}

			[Obsolete]
			private static Delegate GetStream_ZHandler()
			{
				if ((object)cb_stream_Z == null)
				{
					cb_stream_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_Stream_Z));
				}
				return cb_stream_Z;
			}

			[Obsolete]
			private static IntPtr n_Stream_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Stream(enabled));
			}

			[Obsolete("deprecated")]
			[Register("stream", "(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetStream_ZHandler")]
			public unsafe virtual Builder Stream(bool enabled)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(enabled);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("stream.(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Obsolete]
			private static Delegate GetStreamUri_Landroid_net_Uri_Handler()
			{
				if ((object)cb_streamUri_Landroid_net_Uri_ == null)
				{
					cb_streamUri_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_StreamUri_Landroid_net_Uri_));
				}
				return cb_streamUri_Landroid_net_Uri_;
			}

			[Obsolete]
			private static IntPtr n_StreamUri_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_streamUri)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Android.Net.Uri streamUri = Java.Lang.Object.GetObject<global::Android.Net.Uri>(native_streamUri, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.StreamUri(streamUri));
			}

			[Obsolete("deprecated")]
			[Register("streamUri", "(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetStreamUri_Landroid_net_Uri_Handler")]
			public unsafe virtual Builder StreamUri(global::Android.Net.Uri streamUri)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(streamUri?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("streamUri.(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(streamUri);
				}
			}

			[Obsolete]
			private static Delegate GetUseReport_ZHandler()
			{
				if ((object)cb_useReport_Z == null)
				{
					cb_useReport_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_UseReport_Z));
				}
				return cb_useReport_Z;
			}

			[Obsolete]
			private static IntPtr n_UseReport_Z(IntPtr jnienv, IntPtr native__this, bool useReport)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.UseReport(useReport));
			}

			[Obsolete("deprecated")]
			[Register("useReport", "(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetUseReport_ZHandler")]
			public unsafe virtual Builder UseReport(bool useReport)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(useReport);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("useReport.(Z)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Obsolete]
			private static Delegate GetWrapperName_Ljava_lang_String_Handler()
			{
				if ((object)cb_wrapperName_Ljava_lang_String_ == null)
				{
					cb_wrapperName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WrapperName_Ljava_lang_String_));
				}
				return cb_wrapperName_Ljava_lang_String_;
			}

			[Obsolete]
			private static IntPtr n_WrapperName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_wrapperName)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string wrapperName = JNIEnv.GetString(native_wrapperName, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.WrapperName(wrapperName));
			}

			[Obsolete("deprecated")]
			[Register("wrapperName", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetWrapperName_Ljava_lang_String_Handler")]
			public unsafe virtual Builder WrapperName(string wrapperName)
			{
				IntPtr intPtr = JNIEnv.NewString(wrapperName);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("wrapperName.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Obsolete]
			private static Delegate GetWrapperVersion_Ljava_lang_String_Handler()
			{
				if ((object)cb_wrapperVersion_Ljava_lang_String_ == null)
				{
					cb_wrapperVersion_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WrapperVersion_Ljava_lang_String_));
				}
				return cb_wrapperVersion_Ljava_lang_String_;
			}

			[Obsolete]
			private static IntPtr n_WrapperVersion_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_wrapperVersion)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string wrapperVersion = JNIEnv.GetString(native_wrapperVersion, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.WrapperVersion(wrapperVersion));
			}

			[Obsolete("deprecated")]
			[Register("wrapperVersion", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", "GetWrapperVersion_Ljava_lang_String_Handler")]
			public unsafe virtual Builder WrapperVersion(string wrapperVersion)
			{
				IntPtr intPtr = JNIEnv.NewString(wrapperVersion);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("wrapperVersion.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("DEFAULT_BACKGROUND_POLL_INTERVAL_MILLIS")]
		public const int DefaultBackgroundPollIntervalMillis = 3600000;

		[Register("MIN_BACKGROUND_POLL_INTERVAL_MILLIS")]
		public const int MinBackgroundPollIntervalMillis = 900000;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDConfig", typeof(LDConfig));

		private static Delegate cb_getBackgroundPollingIntervalMillis;

		private static Delegate cb_getConnectionTimeoutMillis;

		private static Delegate cb_getEventsCapacity;

		private static Delegate cb_getEventsFlushIntervalMillis;

		private static Delegate cb_getEventsUri;

		private static Delegate cb_getHeaderTransform;

		private static Delegate cb_isDisableBackgroundPolling;

		private static Delegate cb_isEvaluationReasons;

		private static Delegate cb_isOffline;

		private static Delegate cb_isStream;

		private static Delegate cb_isUseReport;

		private static Delegate cb_getMobileKey;

		private static Delegate cb_getMobileKeys;

		private static Delegate cb_getPollUri;

		private static Delegate cb_getPollingIntervalMillis;

		private static Delegate cb_getPrivateAttributes;

		private static Delegate cb_getStreamUri;

		private static Delegate cb_allAttributesPrivate;

		private static Delegate cb_inlineUsersInEvents;

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

		[Obsolete("deprecated")]
		public unsafe virtual int BackgroundPollingIntervalMillis
		{
			[Register("getBackgroundPollingIntervalMillis", "()I", "GetGetBackgroundPollingIntervalMillisHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBackgroundPollingIntervalMillis.()I", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual int ConnectionTimeoutMillis
		{
			[Register("getConnectionTimeoutMillis", "()I", "GetGetConnectionTimeoutMillisHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getConnectionTimeoutMillis.()I", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual int EventsCapacity
		{
			[Register("getEventsCapacity", "()I", "GetGetEventsCapacityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getEventsCapacity.()I", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual int EventsFlushIntervalMillis
		{
			[Register("getEventsFlushIntervalMillis", "()I", "GetGetEventsFlushIntervalMillisHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getEventsFlushIntervalMillis.()I", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual global::Android.Net.Uri EventsUri
		{
			[Register("getEventsUri", "()Landroid/net/Uri;", "GetGetEventsUriHandler")]
			get
			{
				return Java.Lang.Object.GetObject<global::Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEventsUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual ILDHeaderUpdater HeaderTransform
		{
			[Register("getHeaderTransform", "()Lcom/launchdarkly/sdk/android/LDHeaderUpdater;", "GetGetHeaderTransformHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ILDHeaderUpdater>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHeaderTransform.()Lcom/launchdarkly/sdk/android/LDHeaderUpdater;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsDisableBackgroundPolling
		{
			[Register("isDisableBackgroundPolling", "()Z", "GetIsDisableBackgroundPollingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDisableBackgroundPolling.()Z", this, null);
			}
		}

		public unsafe virtual bool IsEvaluationReasons
		{
			[Register("isEvaluationReasons", "()Z", "GetIsEvaluationReasonsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEvaluationReasons.()Z", this, null);
			}
		}

		public unsafe virtual bool IsOffline
		{
			[Register("isOffline", "()Z", "GetIsOfflineHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOffline.()Z", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual bool IsStream
		{
			[Register("isStream", "()Z", "GetIsStreamHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isStream.()Z", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual bool IsUseReport
		{
			[Register("isUseReport", "()Z", "GetIsUseReportHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUseReport.()Z", this, null);
			}
		}

		public unsafe virtual string MobileKey
		{
			[Register("getMobileKey", "()Ljava/lang/String;", "GetGetMobileKeyHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMobileKey.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IDictionary<string, string> MobileKeys
		{
			[Register("getMobileKeys", "()Ljava/util/Map;", "GetGetMobileKeysHandler")]
			get
			{
				return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getMobileKeys.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual global::Android.Net.Uri PollUri
		{
			[Register("getPollUri", "()Landroid/net/Uri;", "GetGetPollUriHandler")]
			get
			{
				return Java.Lang.Object.GetObject<global::Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPollUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual int PollingIntervalMillis
		{
			[Register("getPollingIntervalMillis", "()I", "GetGetPollingIntervalMillisHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPollingIntervalMillis.()I", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual ICollection<UserAttribute> PrivateAttributes
		{
			[Register("getPrivateAttributes", "()Ljava/util/Set;", "GetGetPrivateAttributesHandler")]
			get
			{
				return JavaSet<UserAttribute>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrivateAttributes.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual global::Android.Net.Uri StreamUri
		{
			[Register("getStreamUri", "()Landroid/net/Uri;", "GetGetStreamUriHandler")]
			get
			{
				return Java.Lang.Object.GetObject<global::Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStreamUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LDConfig(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Obsolete]
		private static Delegate GetGetBackgroundPollingIntervalMillisHandler()
		{
			if ((object)cb_getBackgroundPollingIntervalMillis == null)
			{
				cb_getBackgroundPollingIntervalMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBackgroundPollingIntervalMillis));
			}
			return cb_getBackgroundPollingIntervalMillis;
		}

		[Obsolete]
		private static int n_GetBackgroundPollingIntervalMillis(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.BackgroundPollingIntervalMillis;
		}

		[Obsolete]
		private static Delegate GetGetConnectionTimeoutMillisHandler()
		{
			if ((object)cb_getConnectionTimeoutMillis == null)
			{
				cb_getConnectionTimeoutMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetConnectionTimeoutMillis));
			}
			return cb_getConnectionTimeoutMillis;
		}

		[Obsolete]
		private static int n_GetConnectionTimeoutMillis(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.ConnectionTimeoutMillis;
		}

		[Obsolete]
		private static Delegate GetGetEventsCapacityHandler()
		{
			if ((object)cb_getEventsCapacity == null)
			{
				cb_getEventsCapacity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetEventsCapacity));
			}
			return cb_getEventsCapacity;
		}

		[Obsolete]
		private static int n_GetEventsCapacity(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.EventsCapacity;
		}

		[Obsolete]
		private static Delegate GetGetEventsFlushIntervalMillisHandler()
		{
			if ((object)cb_getEventsFlushIntervalMillis == null)
			{
				cb_getEventsFlushIntervalMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetEventsFlushIntervalMillis));
			}
			return cb_getEventsFlushIntervalMillis;
		}

		[Obsolete]
		private static int n_GetEventsFlushIntervalMillis(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.EventsFlushIntervalMillis;
		}

		[Obsolete]
		private static Delegate GetGetEventsUriHandler()
		{
			if ((object)cb_getEventsUri == null)
			{
				cb_getEventsUri = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEventsUri));
			}
			return cb_getEventsUri;
		}

		[Obsolete]
		private static IntPtr n_GetEventsUri(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDConfig.EventsUri);
		}

		[Obsolete]
		private static Delegate GetGetHeaderTransformHandler()
		{
			if ((object)cb_getHeaderTransform == null)
			{
				cb_getHeaderTransform = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHeaderTransform));
			}
			return cb_getHeaderTransform;
		}

		[Obsolete]
		private static IntPtr n_GetHeaderTransform(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDConfig.HeaderTransform);
		}

		private static Delegate GetIsDisableBackgroundPollingHandler()
		{
			if ((object)cb_isDisableBackgroundPolling == null)
			{
				cb_isDisableBackgroundPolling = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDisableBackgroundPolling));
			}
			return cb_isDisableBackgroundPolling;
		}

		private static bool n_IsDisableBackgroundPolling(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.IsDisableBackgroundPolling;
		}

		private static Delegate GetIsEvaluationReasonsHandler()
		{
			if ((object)cb_isEvaluationReasons == null)
			{
				cb_isEvaluationReasons = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsEvaluationReasons));
			}
			return cb_isEvaluationReasons;
		}

		private static bool n_IsEvaluationReasons(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.IsEvaluationReasons;
		}

		private static Delegate GetIsOfflineHandler()
		{
			if ((object)cb_isOffline == null)
			{
				cb_isOffline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsOffline));
			}
			return cb_isOffline;
		}

		private static bool n_IsOffline(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.IsOffline;
		}

		[Obsolete]
		private static Delegate GetIsStreamHandler()
		{
			if ((object)cb_isStream == null)
			{
				cb_isStream = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsStream));
			}
			return cb_isStream;
		}

		[Obsolete]
		private static bool n_IsStream(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.IsStream;
		}

		[Obsolete]
		private static Delegate GetIsUseReportHandler()
		{
			if ((object)cb_isUseReport == null)
			{
				cb_isUseReport = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsUseReport));
			}
			return cb_isUseReport;
		}

		[Obsolete]
		private static bool n_IsUseReport(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.IsUseReport;
		}

		private static Delegate GetGetMobileKeyHandler()
		{
			if ((object)cb_getMobileKey == null)
			{
				cb_getMobileKey = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMobileKey));
			}
			return cb_getMobileKey;
		}

		private static IntPtr n_GetMobileKey(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(lDConfig.MobileKey);
		}

		private static Delegate GetGetMobileKeysHandler()
		{
			if ((object)cb_getMobileKeys == null)
			{
				cb_getMobileKeys = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMobileKeys));
			}
			return cb_getMobileKeys;
		}

		private static IntPtr n_GetMobileKeys(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaDictionary<string, string>.ToLocalJniHandle(lDConfig.MobileKeys);
		}

		[Obsolete]
		private static Delegate GetGetPollUriHandler()
		{
			if ((object)cb_getPollUri == null)
			{
				cb_getPollUri = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPollUri));
			}
			return cb_getPollUri;
		}

		[Obsolete]
		private static IntPtr n_GetPollUri(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDConfig.PollUri);
		}

		[Obsolete]
		private static Delegate GetGetPollingIntervalMillisHandler()
		{
			if ((object)cb_getPollingIntervalMillis == null)
			{
				cb_getPollingIntervalMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPollingIntervalMillis));
			}
			return cb_getPollingIntervalMillis;
		}

		[Obsolete]
		private static int n_GetPollingIntervalMillis(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.PollingIntervalMillis;
		}

		[Obsolete]
		private static Delegate GetGetPrivateAttributesHandler()
		{
			if ((object)cb_getPrivateAttributes == null)
			{
				cb_getPrivateAttributes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPrivateAttributes));
			}
			return cb_getPrivateAttributes;
		}

		[Obsolete]
		private static IntPtr n_GetPrivateAttributes(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaSet<UserAttribute>.ToLocalJniHandle(lDConfig.PrivateAttributes);
		}

		[Obsolete]
		private static Delegate GetGetStreamUriHandler()
		{
			if ((object)cb_getStreamUri == null)
			{
				cb_getStreamUri = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStreamUri));
			}
			return cb_getStreamUri;
		}

		[Obsolete]
		private static IntPtr n_GetStreamUri(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDConfig.StreamUri);
		}

		[Obsolete]
		private static Delegate GetAllAttributesPrivateHandler()
		{
			if ((object)cb_allAttributesPrivate == null)
			{
				cb_allAttributesPrivate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_AllAttributesPrivate));
			}
			return cb_allAttributesPrivate;
		}

		[Obsolete]
		private static bool n_AllAttributesPrivate(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.AllAttributesPrivate();
		}

		[Obsolete("deprecated")]
		[Register("allAttributesPrivate", "()Z", "GetAllAttributesPrivateHandler")]
		public unsafe virtual bool AllAttributesPrivate()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("allAttributesPrivate.()Z", this, null);
		}

		[Obsolete]
		private static Delegate GetInlineUsersInEventsHandler()
		{
			if ((object)cb_inlineUsersInEvents == null)
			{
				cb_inlineUsersInEvents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_InlineUsersInEvents));
			}
			return cb_inlineUsersInEvents;
		}

		[Obsolete]
		private static bool n_InlineUsersInEvents(IntPtr jnienv, IntPtr native__this)
		{
			LDConfig lDConfig = Java.Lang.Object.GetObject<LDConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDConfig.InlineUsersInEvents();
		}

		[Obsolete("deprecated")]
		[Register("inlineUsersInEvents", "()Z", "GetInlineUsersInEventsHandler")]
		public unsafe virtual bool InlineUsersInEvents()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("inlineUsersInEvents.()Z", this, null);
		}
	}
	[Register("com/launchdarkly/sdk/android/LDFailure", DoNotGenerateAcw = true)]
	public class LDFailure : LaunchDarklyException
	{
		[Register("com/launchdarkly/sdk/android/LDFailure$FailureType", DoNotGenerateAcw = true)]
		public sealed class FailureType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDFailure$FailureType", typeof(FailureType));

			[Register("INVALID_RESPONSE_BODY")]
			public static FailureType InvalidResponseBody => Java.Lang.Object.GetObject<FailureType>(_members.StaticFields.GetObjectValue("INVALID_RESPONSE_BODY.Lcom/launchdarkly/sdk/android/LDFailure$FailureType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NETWORK_FAILURE")]
			public static FailureType NetworkFailure => Java.Lang.Object.GetObject<FailureType>(_members.StaticFields.GetObjectValue("NETWORK_FAILURE.Lcom/launchdarkly/sdk/android/LDFailure$FailureType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("UNEXPECTED_RESPONSE_CODE")]
			public static FailureType UnexpectedResponseCode => Java.Lang.Object.GetObject<FailureType>(_members.StaticFields.GetObjectValue("UNEXPECTED_RESPONSE_CODE.Lcom/launchdarkly/sdk/android/LDFailure$FailureType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("UNEXPECTED_STREAM_ELEMENT_TYPE")]
			public static FailureType UnexpectedStreamElementType => Java.Lang.Object.GetObject<FailureType>(_members.StaticFields.GetObjectValue("UNEXPECTED_STREAM_ELEMENT_TYPE.Lcom/launchdarkly/sdk/android/LDFailure$FailureType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("UNKNOWN_ERROR")]
			public static FailureType UnknownError => Java.Lang.Object.GetObject<FailureType>(_members.StaticFields.GetObjectValue("UNKNOWN_ERROR.Lcom/launchdarkly/sdk/android/LDFailure$FailureType;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal FailureType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDFailure$FailureType;", "")]
			public unsafe static FailureType ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<FailureType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/LDFailure$FailureType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/launchdarkly/sdk/android/LDFailure$FailureType;", "")]
			public unsafe static FailureType[] Values()
			{
				return (FailureType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/launchdarkly/sdk/android/LDFailure$FailureType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(FailureType));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDFailure", typeof(LDFailure));

		private static Delegate cb_getFailureType;

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

		protected LDFailure(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Lcom/launchdarkly/sdk/android/LDFailure$FailureType;)V", "")]
		public unsafe LDFailure(string message, FailureType failureType)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(failureType?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Lcom/launchdarkly/sdk/android/LDFailure$FailureType;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Lcom/launchdarkly/sdk/android/LDFailure$FailureType;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(failureType);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;Lcom/launchdarkly/sdk/android/LDFailure$FailureType;)V", "")]
		public unsafe LDFailure(string message, Throwable cause, FailureType failureType)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(failureType?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;Lcom/launchdarkly/sdk/android/LDFailure$FailureType;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;Lcom/launchdarkly/sdk/android/LDFailure$FailureType;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(cause);
				GC.KeepAlive(failureType);
			}
		}

		private static Delegate GetGetFailureTypeHandler()
		{
			if ((object)cb_getFailureType == null)
			{
				cb_getFailureType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFailureType));
			}
			return cb_getFailureType;
		}

		private static IntPtr n_GetFailureType(IntPtr jnienv, IntPtr native__this)
		{
			LDFailure lDFailure = Java.Lang.Object.GetObject<LDFailure>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lDFailure.GetFailureType());
		}

		[Register("getFailureType", "()Lcom/launchdarkly/sdk/android/LDFailure$FailureType;", "GetGetFailureTypeHandler")]
		public unsafe virtual FailureType GetFailureType()
		{
			return Java.Lang.Object.GetObject<FailureType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFailureType.()Lcom/launchdarkly/sdk/android/LDFailure$FailureType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/sdk/android/LDInvalidResponseCodeFailure", DoNotGenerateAcw = true)]
	public class LDInvalidResponseCodeFailure : LDFailure
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDInvalidResponseCodeFailure", typeof(LDInvalidResponseCodeFailure));

		private static Delegate cb_isRetryable;

		private static Delegate cb_getResponseCode;

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

		public unsafe virtual bool IsRetryable
		{
			[Register("isRetryable", "()Z", "GetIsRetryableHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRetryable.()Z", this, null);
			}
		}

		public unsafe virtual int ResponseCode
		{
			[Register("getResponseCode", "()I", "GetGetResponseCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getResponseCode.()I", this, null);
			}
		}

		protected LDInvalidResponseCodeFailure(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;IZ)V", "")]
		public unsafe LDInvalidResponseCodeFailure(string message, int responseCode, bool retryable)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(responseCode);
				ptr[2] = new JniArgumentValue(retryable);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;IZ)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;IZ)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;IZ)V", "")]
		public unsafe LDInvalidResponseCodeFailure(string message, Throwable cause, int responseCode, bool retryable)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(responseCode);
				ptr[3] = new JniArgumentValue(retryable);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;IZ)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;IZ)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(cause);
			}
		}

		private static Delegate GetIsRetryableHandler()
		{
			if ((object)cb_isRetryable == null)
			{
				cb_isRetryable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRetryable));
			}
			return cb_isRetryable;
		}

		private static bool n_IsRetryable(IntPtr jnienv, IntPtr native__this)
		{
			LDInvalidResponseCodeFailure lDInvalidResponseCodeFailure = Java.Lang.Object.GetObject<LDInvalidResponseCodeFailure>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDInvalidResponseCodeFailure.IsRetryable;
		}

		private static Delegate GetGetResponseCodeHandler()
		{
			if ((object)cb_getResponseCode == null)
			{
				cb_getResponseCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetResponseCode));
			}
			return cb_getResponseCode;
		}

		private static int n_GetResponseCode(IntPtr jnienv, IntPtr native__this)
		{
			LDInvalidResponseCodeFailure lDInvalidResponseCodeFailure = Java.Lang.Object.GetObject<LDInvalidResponseCodeFailure>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return lDInvalidResponseCodeFailure.ResponseCode;
		}
	}
	[Register("com/launchdarkly/sdk/android/LDTimberLogging", DoNotGenerateAcw = true)]
	public abstract class LDTimberLogging : Java.Lang.Object
	{
		[Register("com/launchdarkly/sdk/android/LDTimberLogging$Adapter", DoNotGenerateAcw = true)]
		public sealed class Adapter : Java.Lang.Object, ILDLogAdapter, IJavaObject, IDisposable, IJavaPeerable, ILDLogAdapterIsConfiguredExternally
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDTimberLogging$Adapter", typeof(Adapter));

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

			internal Adapter(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("autoPlantDebugTree", "(Z)Lcom/launchdarkly/sdk/android/LDTimberLogging$Adapter;", "")]
			public unsafe Adapter AutoPlantDebugTree(bool autoPlantDebugTree)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(autoPlantDebugTree);
				return Java.Lang.Object.GetObject<Adapter>(_members.InstanceMethods.InvokeAbstractObjectMethod("autoPlantDebugTree.(Z)Lcom/launchdarkly/sdk/android/LDTimberLogging$Adapter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("newChannel", "(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogAdapter$Channel;", "")]
			public unsafe ILDLogAdapterChannel NewChannel(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ILDLogAdapterChannel>(_members.InstanceMethods.InvokeAbstractObjectMethod("newChannel.(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogAdapter$Channel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDTimberLogging", typeof(LDTimberLogging));

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

		protected LDTimberLogging(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LDTimberLogging()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("adapter", "()Lcom/launchdarkly/logging/LDLogAdapter;", "")]
		public unsafe static ILDLogAdapter InvokeAdapter()
		{
			return Java.Lang.Object.GetObject<ILDLogAdapter>(_members.StaticMethods.InvokeObjectMethod("adapter.()Lcom/launchdarkly/logging/LDLogAdapter;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/sdk/android/LDTimberLogging", DoNotGenerateAcw = true)]
	internal class LDTimberLoggingInvoker : LDTimberLogging
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/LDTimberLogging", typeof(LDTimberLoggingInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public LDTimberLoggingInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/launchdarkly/sdk/android/PollingUpdater", DoNotGenerateAcw = true)]
	public class PollingUpdater : BroadcastReceiver
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/PollingUpdater", typeof(PollingUpdater));

		private static Delegate cb_onReceive_Landroid_content_Context_Landroid_content_Intent_;

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

		protected PollingUpdater(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PollingUpdater()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler()
		{
			if ((object)cb_onReceive_Landroid_content_Context_Landroid_content_Intent_ == null)
			{
				cb_onReceive_Landroid_content_Context_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnReceive_Landroid_content_Context_Landroid_content_Intent_));
			}
			return cb_onReceive_Landroid_content_Context_Landroid_content_Intent_;
		}

		private static void n_OnReceive_Landroid_content_Context_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_intent)
		{
			PollingUpdater pollingUpdater = Java.Lang.Object.GetObject<PollingUpdater>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			pollingUpdater.OnReceive(context, intent);
		}

		[Register("onReceive", "(Landroid/content/Context;Landroid/content/Intent;)V", "GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler")]
		public unsafe override void OnReceive(Context context, Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onReceive.(Landroid/content/Context;Landroid/content/Intent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(intent);
			}
		}
	}
}
namespace Com.Launchdarkly.Sdk.Android.Subsystems
{
	[Register("com/launchdarkly/sdk/android/subsystems/ApplicationInfo", DoNotGenerateAcw = true)]
	public sealed class ApplicationInfo : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/subsystems/ApplicationInfo", typeof(ApplicationInfo));

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

		public unsafe string ApplicationId
		{
			[Register("getApplicationId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getApplicationId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ApplicationVersion
		{
			[Register("getApplicationVersion", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getApplicationVersion.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ApplicationInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe ApplicationInfo(string applicationId, string applicationVersion)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(applicationId);
			IntPtr intPtr2 = JNIEnv.NewString(applicationVersion);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}
	}
	[Register("com/launchdarkly/sdk/android/subsystems/ClientContext", DoNotGenerateAcw = true)]
	public class ClientContext : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/subsystems/ClientContext", typeof(ClientContext));

		private static Delegate cb_getApplication;

		private static Delegate cb_getApplicationInfo;

		private static Delegate cb_getBaseLogger;

		private static Delegate cb_getConfig;

		private static Delegate cb_getEnvironmentName;

		private static Delegate cb_getHttp;

		private static Delegate cb_isEvaluationReasons;

		private static Delegate cb_isInitiallySetOffline;

		private static Delegate cb_getMobileKey;

		private static Delegate cb_getServiceEndpoints;

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

		public unsafe virtual Application Application
		{
			[Register("getApplication", "()Landroid/app/Application;", "GetGetApplicationHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Application>(_members.InstanceMethods.InvokeVirtualObjectMethod("getApplication.()Landroid/app/Application;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ApplicationInfo ApplicationInfo
		{
			[Register("getApplicationInfo", "()Lcom/launchdarkly/sdk/android/subsystems/ApplicationInfo;", "GetGetApplicationInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ApplicationInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getApplicationInfo.()Lcom/launchdarkly/sdk/android/subsystems/ApplicationInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual LDLogger BaseLogger
		{
			[Register("getBaseLogger", "()Lcom/launchdarkly/logging/LDLogger;", "GetGetBaseLoggerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LDLogger>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBaseLogger.()Lcom/launchdarkly/logging/LDLogger;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual LDConfig Config
		{
			[Register("getConfig", "()Lcom/launchdarkly/sdk/android/LDConfig;", "GetGetConfigHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LDConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConfig.()Lcom/launchdarkly/sdk/android/LDConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string EnvironmentName
		{
			[Register("getEnvironmentName", "()Ljava/lang/String;", "GetGetEnvironmentNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEnvironmentName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual HttpConfiguration Http
		{
			[Register("getHttp", "()Lcom/launchdarkly/sdk/android/subsystems/HttpConfiguration;", "GetGetHttpHandler")]
			get
			{
				return Java.Lang.Object.GetObject<HttpConfiguration>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHttp.()Lcom/launchdarkly/sdk/android/subsystems/HttpConfiguration;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsEvaluationReasons
		{
			[Register("isEvaluationReasons", "()Z", "GetIsEvaluationReasonsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEvaluationReasons.()Z", this, null);
			}
		}

		public unsafe virtual bool IsInitiallySetOffline
		{
			[Register("isInitiallySetOffline", "()Z", "GetIsInitiallySetOfflineHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInitiallySetOffline.()Z", this, null);
			}
		}

		public unsafe virtual string MobileKey
		{
			[Register("getMobileKey", "()Ljava/lang/String;", "GetGetMobileKeyHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMobileKey.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ServiceEndpoints ServiceEndpoints
		{
			[Register("getServiceEndpoints", "()Lcom/launchdarkly/sdk/android/subsystems/ServiceEndpoints;", "GetGetServiceEndpointsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ServiceEndpoints>(_members.InstanceMethods.InvokeVirtualObjectMethod("getServiceEndpoints.()Lcom/launchdarkly/sdk/android/subsystems/ServiceEndpoints;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ClientContext(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Application;Lcom/launchdarkly/sdk/android/subsystems/ApplicationInfo;Lcom/launchdarkly/logging/LDLogger;Lcom/launchdarkly/sdk/android/LDConfig;Ljava/lang/String;ZLcom/launchdarkly/sdk/android/subsystems/HttpConfiguration;ZLjava/lang/String;Lcom/launchdarkly/sdk/android/subsystems/ServiceEndpoints;)V", "")]
		public unsafe ClientContext(Application androidApplication, ApplicationInfo applicationInfo, LDLogger baseLogger, LDConfig config, string environmentName, bool evaluationReasons, HttpConfiguration http, bool initiallySetOffline, string mobileKey, ServiceEndpoints serviceEndpoints)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(environmentName);
			IntPtr intPtr2 = JNIEnv.NewString(mobileKey);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
				*ptr = new JniArgumentValue(androidApplication?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(applicationInfo?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(baseLogger?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(intPtr);
				ptr[5] = new JniArgumentValue(evaluationReasons);
				ptr[6] = new JniArgumentValue(http?.Handle ?? IntPtr.Zero);
				ptr[7] = new JniArgumentValue(initiallySetOffline);
				ptr[8] = new JniArgumentValue(intPtr2);
				ptr[9] = new JniArgumentValue(serviceEndpoints?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Application;Lcom/launchdarkly/sdk/android/subsystems/ApplicationInfo;Lcom/launchdarkly/logging/LDLogger;Lcom/launchdarkly/sdk/android/LDConfig;Ljava/lang/String;ZLcom/launchdarkly/sdk/android/subsystems/HttpConfiguration;ZLjava/lang/String;Lcom/launchdarkly/sdk/android/subsystems/ServiceEndpoints;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Application;Lcom/launchdarkly/sdk/android/subsystems/ApplicationInfo;Lcom/launchdarkly/logging/LDLogger;Lcom/launchdarkly/sdk/android/LDConfig;Ljava/lang/String;ZLcom/launchdarkly/sdk/android/subsystems/HttpConfiguration;ZLjava/lang/String;Lcom/launchdarkly/sdk/android/subsystems/ServiceEndpoints;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(androidApplication);
				GC.KeepAlive(applicationInfo);
				GC.KeepAlive(baseLogger);
				GC.KeepAlive(config);
				GC.KeepAlive(http);
				GC.KeepAlive(serviceEndpoints);
			}
		}

		[Register(".ctor", "(Lcom/launchdarkly/sdk/android/subsystems/ClientContext;)V", "")]
		protected unsafe ClientContext(ClientContext copyFrom)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(copyFrom?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/launchdarkly/sdk/android/subsystems/ClientContext;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/launchdarkly/sdk/android/subsystems/ClientContext;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(copyFrom);
			}
		}

		private static Delegate GetGetApplicationHandler()
		{
			if ((object)cb_getApplication == null)
			{
				cb_getApplication = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetApplication));
			}
			return cb_getApplication;
		}

		private static IntPtr n_GetApplication(IntPtr jnienv, IntPtr native__this)
		{
			ClientContext clientContext = Java.Lang.Object.GetObject<ClientContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(clientContext.Application);
		}

		private static Delegate GetGetApplicationInfoHandler()
		{
			if ((object)cb_getApplicationInfo == null)
			{
				cb_getApplicationInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetApplicationInfo));
			}
			return cb_getApplicationInfo;
		}

		private static IntPtr n_GetApplicationInfo(IntPtr jnienv, IntPtr native__this)
		{
			ClientContext clientContext = Java.Lang.Object.GetObject<ClientContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(clientContext.ApplicationInfo);
		}

		private static Delegate GetGetBaseLoggerHandler()
		{
			if ((object)cb_getBaseLogger == null)
			{
				cb_getBaseLogger = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBaseLogger));
			}
			return cb_getBaseLogger;
		}

		private static IntPtr n_GetBaseLogger(IntPtr jnienv, IntPtr native__this)
		{
			ClientContext clientContext = Java.Lang.Object.GetObject<ClientContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(clientContext.BaseLogger);
		}

		private static Delegate GetGetConfigHandler()
		{
			if ((object)cb_getConfig == null)
			{
				cb_getConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConfig));
			}
			return cb_getConfig;
		}

		private static IntPtr n_GetConfig(IntPtr jnienv, IntPtr native__this)
		{
			ClientContext clientContext = Java.Lang.Object.GetObject<ClientContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(clientContext.Config);
		}

		private static Delegate GetGetEnvironmentNameHandler()
		{
			if ((object)cb_getEnvironmentName == null)
			{
				cb_getEnvironmentName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEnvironmentName));
			}
			return cb_getEnvironmentName;
		}

		private static IntPtr n_GetEnvironmentName(IntPtr jnienv, IntPtr native__this)
		{
			ClientContext clientContext = Java.Lang.Object.GetObject<ClientContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(clientContext.EnvironmentName);
		}

		private static Delegate GetGetHttpHandler()
		{
			if ((object)cb_getHttp == null)
			{
				cb_getHttp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHttp));
			}
			return cb_getHttp;
		}

		private static IntPtr n_GetHttp(IntPtr jnienv, IntPtr native__this)
		{
			ClientContext clientContext = Java.Lang.Object.GetObject<ClientContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(clientContext.Http);
		}

		private static Delegate GetIsEvaluationReasonsHandler()
		{
			if ((object)cb_isEvaluationReasons == null)
			{
				cb_isEvaluationReasons = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsEvaluationReasons));
			}
			return cb_isEvaluationReasons;
		}

		private static bool n_IsEvaluationReasons(IntPtr jnienv, IntPtr native__this)
		{
			ClientContext clientContext = Java.Lang.Object.GetObject<ClientContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return clientContext.IsEvaluationReasons;
		}

		private static Delegate GetIsInitiallySetOfflineHandler()
		{
			if ((object)cb_isInitiallySetOffline == null)
			{
				cb_isInitiallySetOffline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInitiallySetOffline));
			}
			return cb_isInitiallySetOffline;
		}

		private static bool n_IsInitiallySetOffline(IntPtr jnienv, IntPtr native__this)
		{
			ClientContext clientContext = Java.Lang.Object.GetObject<ClientContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return clientContext.IsInitiallySetOffline;
		}

		private static Delegate GetGetMobileKeyHandler()
		{
			if ((object)cb_getMobileKey == null)
			{
				cb_getMobileKey = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMobileKey));
			}
			return cb_getMobileKey;
		}

		private static IntPtr n_GetMobileKey(IntPtr jnienv, IntPtr native__this)
		{
			ClientContext clientContext = Java.Lang.Object.GetObject<ClientContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(clientContext.MobileKey);
		}

		private static Delegate GetGetServiceEndpointsHandler()
		{
			if ((object)cb_getServiceEndpoints == null)
			{
				cb_getServiceEndpoints = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetServiceEndpoints));
			}
			return cb_getServiceEndpoints;
		}

		private static IntPtr n_GetServiceEndpoints(IntPtr jnienv, IntPtr native__this)
		{
			ClientContext clientContext = Java.Lang.Object.GetObject<ClientContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(clientContext.ServiceEndpoints);
		}
	}
	[Register("com/launchdarkly/sdk/android/subsystems/HttpConfiguration", DoNotGenerateAcw = true)]
	public sealed class HttpConfiguration : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/subsystems/HttpConfiguration", typeof(HttpConfiguration));

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

		public unsafe int ConnectTimeoutMillis
		{
			[Register("getConnectTimeoutMillis", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getConnectTimeoutMillis.()I", this, null);
			}
		}

		public unsafe IIterable DefaultHeaders
		{
			[Register("getDefaultHeaders", "()Ljava/lang/Iterable;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IIterable>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDefaultHeaders.()Ljava/lang/Iterable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ILDHeaderUpdater HeaderTransform
		{
			[Register("getHeaderTransform", "()Lcom/launchdarkly/sdk/android/LDHeaderUpdater;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ILDHeaderUpdater>(_members.InstanceMethods.InvokeAbstractObjectMethod("getHeaderTransform.()Lcom/launchdarkly/sdk/android/LDHeaderUpdater;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsUseReport
		{
			[Register("isUseReport", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isUseReport.()Z", this, null);
			}
		}

		internal HttpConfiguration(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(ILjava/util/Map;Lcom/launchdarkly/sdk/android/LDHeaderUpdater;Z)V", "")]
		public unsafe HttpConfiguration(int connectTimeoutMillis, IDictionary<string, string> defaultHeaders, ILDHeaderUpdater headerTransform, bool useReport)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaDictionary<string, string>.ToLocalJniHandle(defaultHeaders);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(connectTimeoutMillis);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((headerTransform == null) ? IntPtr.Zero : ((Java.Lang.Object)headerTransform).Handle);
				ptr[3] = new JniArgumentValue(useReport);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/util/Map;Lcom/launchdarkly/sdk/android/LDHeaderUpdater;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILjava/util/Map;Lcom/launchdarkly/sdk/android/LDHeaderUpdater;Z)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(defaultHeaders);
				GC.KeepAlive(headerTransform);
			}
		}
	}
	[Register("com/launchdarkly/sdk/android/subsystems/ComponentConfigurer", "", "Com.Launchdarkly.Sdk.Android.Subsystems.IComponentConfigurerInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IComponentConfigurer : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("build", "(Lcom/launchdarkly/sdk/android/subsystems/ClientContext;)Ljava/lang/Object;", "GetBuild_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_Handler:Com.Launchdarkly.Sdk.Android.Subsystems.IComponentConfigurerInvoker, LaunchDarklyAndroidBinding")]
		Java.Lang.Object Build(ClientContext p0);
	}
	[Register("com/launchdarkly/sdk/android/subsystems/ComponentConfigurer", DoNotGenerateAcw = true)]
	internal class IComponentConfigurerInvoker : Java.Lang.Object, IComponentConfigurer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/subsystems/ComponentConfigurer", typeof(IComponentConfigurerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_build_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_;

		private IntPtr id_build_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_;

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

		public static IComponentConfigurer GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IComponentConfigurer>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.android.subsystems.ComponentConfigurer'.");
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

		public IComponentConfigurerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetBuild_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_Handler()
		{
			if ((object)cb_build_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_ == null)
			{
				cb_build_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Build_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_));
			}
			return cb_build_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_;
		}

		private static IntPtr n_Build_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IComponentConfigurer componentConfigurer = Java.Lang.Object.GetObject<IComponentConfigurer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ClientContext p = Java.Lang.Object.GetObject<ClientContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(componentConfigurer.Build(p));
		}

		public unsafe Java.Lang.Object Build(ClientContext p0)
		{
			if (id_build_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_ == IntPtr.Zero)
			{
				id_build_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_ = JNIEnv.GetMethodID(class_ref, "build", "(Lcom/launchdarkly/sdk/android/subsystems/ClientContext;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_build_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/sdk/android/subsystems/DataSource", "", "Com.Launchdarkly.Sdk.Android.Subsystems.IDataSourceInvoker")]
	public interface IDataSource : IJavaObject, IDisposable, IJavaPeerable
	{
		int BackgroundPollIntervalMillis
		{
			[Register("getBackgroundPollIntervalMillis", "()I", "GetGetBackgroundPollIntervalMillisHandler:Com.Launchdarkly.Sdk.Android.Subsystems.IDataSourceInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		int InitialReconnectDelayMillis
		{
			[Register("getInitialReconnectDelayMillis", "()I", "GetGetInitialReconnectDelayMillisHandler:Com.Launchdarkly.Sdk.Android.Subsystems.IDataSourceInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		bool IsStreamingDisabled
		{
			[Register("isStreamingDisabled", "()Z", "GetIsStreamingDisabledHandler:Com.Launchdarkly.Sdk.Android.Subsystems.IDataSourceInvoker, LaunchDarklyAndroidBinding")]
			get;
		}

		int PollIntervalMillis
		{
			[Register("getPollIntervalMillis", "()I", "GetGetPollIntervalMillisHandler:Com.Launchdarkly.Sdk.Android.Subsystems.IDataSourceInvoker, LaunchDarklyAndroidBinding")]
			get;
		}
	}
	[Register("com/launchdarkly/sdk/android/subsystems/DataSource", DoNotGenerateAcw = true)]
	internal class IDataSourceInvoker : Java.Lang.Object, IDataSource, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/subsystems/DataSource", typeof(IDataSourceInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getBackgroundPollIntervalMillis;

		private IntPtr id_getBackgroundPollIntervalMillis;

		private static Delegate cb_getInitialReconnectDelayMillis;

		private IntPtr id_getInitialReconnectDelayMillis;

		private static Delegate cb_isStreamingDisabled;

		private IntPtr id_isStreamingDisabled;

		private static Delegate cb_getPollIntervalMillis;

		private IntPtr id_getPollIntervalMillis;

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

		public int BackgroundPollIntervalMillis
		{
			get
			{
				if (id_getBackgroundPollIntervalMillis == IntPtr.Zero)
				{
					id_getBackgroundPollIntervalMillis = JNIEnv.GetMethodID(class_ref, "getBackgroundPollIntervalMillis", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_getBackgroundPollIntervalMillis);
			}
		}

		public int InitialReconnectDelayMillis
		{
			get
			{
				if (id_getInitialReconnectDelayMillis == IntPtr.Zero)
				{
					id_getInitialReconnectDelayMillis = JNIEnv.GetMethodID(class_ref, "getInitialReconnectDelayMillis", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_getInitialReconnectDelayMillis);
			}
		}

		public bool IsStreamingDisabled
		{
			get
			{
				if (id_isStreamingDisabled == IntPtr.Zero)
				{
					id_isStreamingDisabled = JNIEnv.GetMethodID(class_ref, "isStreamingDisabled", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isStreamingDisabled);
			}
		}

		public int PollIntervalMillis
		{
			get
			{
				if (id_getPollIntervalMillis == IntPtr.Zero)
				{
					id_getPollIntervalMillis = JNIEnv.GetMethodID(class_ref, "getPollIntervalMillis", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_getPollIntervalMillis);
			}
		}

		public static IDataSource GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDataSource>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.android.subsystems.DataSource'.");
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

		public IDataSourceInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetBackgroundPollIntervalMillisHandler()
		{
			if ((object)cb_getBackgroundPollIntervalMillis == null)
			{
				cb_getBackgroundPollIntervalMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBackgroundPollIntervalMillis));
			}
			return cb_getBackgroundPollIntervalMillis;
		}

		private static int n_GetBackgroundPollIntervalMillis(IntPtr jnienv, IntPtr native__this)
		{
			IDataSource dataSource = Java.Lang.Object.GetObject<IDataSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return dataSource.BackgroundPollIntervalMillis;
		}

		private static Delegate GetGetInitialReconnectDelayMillisHandler()
		{
			if ((object)cb_getInitialReconnectDelayMillis == null)
			{
				cb_getInitialReconnectDelayMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetInitialReconnectDelayMillis));
			}
			return cb_getInitialReconnectDelayMillis;
		}

		private static int n_GetInitialReconnectDelayMillis(IntPtr jnienv, IntPtr native__this)
		{
			IDataSource dataSource = Java.Lang.Object.GetObject<IDataSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return dataSource.InitialReconnectDelayMillis;
		}

		private static Delegate GetIsStreamingDisabledHandler()
		{
			if ((object)cb_isStreamingDisabled == null)
			{
				cb_isStreamingDisabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsStreamingDisabled));
			}
			return cb_isStreamingDisabled;
		}

		private static bool n_IsStreamingDisabled(IntPtr jnienv, IntPtr native__this)
		{
			IDataSource dataSource = Java.Lang.Object.GetObject<IDataSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return dataSource.IsStreamingDisabled;
		}

		private static Delegate GetGetPollIntervalMillisHandler()
		{
			if ((object)cb_getPollIntervalMillis == null)
			{
				cb_getPollIntervalMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPollIntervalMillis));
			}
			return cb_getPollIntervalMillis;
		}

		private static int n_GetPollIntervalMillis(IntPtr jnienv, IntPtr native__this)
		{
			IDataSource dataSource = Java.Lang.Object.GetObject<IDataSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return dataSource.PollIntervalMillis;
		}
	}
	[Register("com/launchdarkly/sdk/android/subsystems/DiagnosticDescription", "", "Com.Launchdarkly.Sdk.Android.Subsystems.IDiagnosticDescriptionInvoker")]
	public interface IDiagnosticDescription : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("describeConfiguration", "(Lcom/launchdarkly/sdk/android/subsystems/ClientContext;)Lcom/launchdarkly/sdk/LDValue;", "GetDescribeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_Handler:Com.Launchdarkly.Sdk.Android.Subsystems.IDiagnosticDescriptionInvoker, LaunchDarklyAndroidBinding")]
		LDValue DescribeConfiguration(ClientContext p0);
	}
	[Register("com/launchdarkly/sdk/android/subsystems/DiagnosticDescription", DoNotGenerateAcw = true)]
	internal class IDiagnosticDescriptionInvoker : Java.Lang.Object, IDiagnosticDescription, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/subsystems/DiagnosticDescription", typeof(IDiagnosticDescriptionInvoker));

		private IntPtr class_ref;

		private static Delegate cb_describeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_;

		private IntPtr id_describeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_;

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

		public static IDiagnosticDescription GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDiagnosticDescription>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.android.subsystems.DiagnosticDescription'.");
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

		public IDiagnosticDescriptionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDescribeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_Handler()
		{
			if ((object)cb_describeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_ == null)
			{
				cb_describeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DescribeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_));
			}
			return cb_describeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_;
		}

		private static IntPtr n_DescribeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDiagnosticDescription diagnosticDescription = Java.Lang.Object.GetObject<IDiagnosticDescription>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ClientContext p = Java.Lang.Object.GetObject<ClientContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(diagnosticDescription.DescribeConfiguration(p));
		}

		public unsafe LDValue DescribeConfiguration(ClientContext p0)
		{
			if (id_describeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_ == IntPtr.Zero)
			{
				id_describeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_ = JNIEnv.GetMethodID(class_ref, "describeConfiguration", "(Lcom/launchdarkly/sdk/android/subsystems/ClientContext;)Lcom/launchdarkly/sdk/LDValue;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LDValue>(JNIEnv.CallObjectMethod(base.Handle, id_describeConfiguration_Lcom_launchdarkly_sdk_android_subsystems_ClientContext_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/sdk/android/subsystems/EventProcessor", DoNotGenerateAcw = true)]
	public abstract class EventProcessor : Java.Lang.Object
	{
		[Register("NO_VERSION")]
		public const int NoVersion = -1;

		internal EventProcessor()
		{
		}
	}
	[Register("com/launchdarkly/sdk/android/subsystems/EventProcessor", DoNotGenerateAcw = true)]
	[Obsolete("Use the 'EventProcessor' type. This type will be removed in a future release.", true)]
	public abstract class EventProcessorConsts : EventProcessor
	{
		private EventProcessorConsts()
		{
		}
	}
	[Register("com/launchdarkly/sdk/android/subsystems/EventProcessor", "", "Com.Launchdarkly.Sdk.Android.Subsystems.IEventProcessorInvoker")]
	public interface IEventProcessor : ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("blockingFlush", "()V", "GetBlockingFlushHandler:Com.Launchdarkly.Sdk.Android.Subsystems.IEventProcessorInvoker, LaunchDarklyAndroidBinding")]
		void BlockingFlush();

		[Register("flush", "()V", "GetFlushHandler:Com.Launchdarkly.Sdk.Android.Subsystems.IEventProcessorInvoker, LaunchDarklyAndroidBinding")]
		void Flush();

		[Register("recordAliasEvent", "(Lcom/launchdarkly/sdk/LDUser;Lcom/launchdarkly/sdk/LDUser;)V", "GetRecordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_Handler:Com.Launchdarkly.Sdk.Android.Subsystems.IEventProcessorInvoker, LaunchDarklyAndroidBinding")]
		void RecordAliasEvent(LDUser p0, LDUser p1);

		[Register("recordCustomEvent", "(Lcom/launchdarkly/sdk/LDUser;Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;Ljava/lang/Double;)V", "GetRecordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_Handler:Com.Launchdarkly.Sdk.Android.Subsystems.IEventProcessorInvoker, LaunchDarklyAndroidBinding")]
		void RecordCustomEvent(LDUser p0, string p1, LDValue p2, Java.Lang.Double p3);

		[Register("recordEvaluationEvent", "(Lcom/launchdarkly/sdk/LDUser;Ljava/lang/String;IILcom/launchdarkly/sdk/LDValue;Lcom/launchdarkly/sdk/EvaluationReason;Lcom/launchdarkly/sdk/LDValue;ZLjava/lang/Long;)V", "GetRecordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_Handler:Com.Launchdarkly.Sdk.Android.Subsystems.IEventProcessorInvoker, LaunchDarklyAndroidBinding")]
		void RecordEvaluationEvent(LDUser p0, string p1, int p2, int p3, LDValue p4, EvaluationReason p5, LDValue p6, bool p7, Long p8);

		[Register("recordIdentifyEvent", "(Lcom/launchdarkly/sdk/LDUser;)V", "GetRecordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_Handler:Com.Launchdarkly.Sdk.Android.Subsystems.IEventProcessorInvoker, LaunchDarklyAndroidBinding")]
		void RecordIdentifyEvent(LDUser p0);

		[Register("setOffline", "(Z)V", "GetSetOffline_ZHandler:Com.Launchdarkly.Sdk.Android.Subsystems.IEventProcessorInvoker, LaunchDarklyAndroidBinding")]
		void SetOffline(bool p0);

		[Register("start", "()V", "GetStartHandler:Com.Launchdarkly.Sdk.Android.Subsystems.IEventProcessorInvoker, LaunchDarklyAndroidBinding")]
		void Start();

		[Register("stop", "()V", "GetStopHandler:Com.Launchdarkly.Sdk.Android.Subsystems.IEventProcessorInvoker, LaunchDarklyAndroidBinding")]
		void Stop();
	}
	[Register("com/launchdarkly/sdk/android/subsystems/EventProcessor", DoNotGenerateAcw = true)]
	internal class IEventProcessorInvoker : Java.Lang.Object, IEventProcessor, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/subsystems/EventProcessor", typeof(IEventProcessorInvoker));

		private IntPtr class_ref;

		private static Delegate cb_blockingFlush;

		private IntPtr id_blockingFlush;

		private static Delegate cb_flush;

		private IntPtr id_flush;

		private static Delegate cb_recordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_;

		private IntPtr id_recordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_;

		private static Delegate cb_recordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_;

		private IntPtr id_recordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_;

		private static Delegate cb_recordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_;

		private IntPtr id_recordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_;

		private static Delegate cb_recordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_;

		private IntPtr id_recordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_;

		private static Delegate cb_setOffline_Z;

		private IntPtr id_setOffline_Z;

		private static Delegate cb_start;

		private IntPtr id_start;

		private static Delegate cb_stop;

		private IntPtr id_stop;

		private static Delegate cb_close;

		private IntPtr id_close;

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

		public static IEventProcessor GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IEventProcessor>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.sdk.android.subsystems.EventProcessor'.");
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

		public IEventProcessorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetBlockingFlushHandler()
		{
			if ((object)cb_blockingFlush == null)
			{
				cb_blockingFlush = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_BlockingFlush));
			}
			return cb_blockingFlush;
		}

		private static void n_BlockingFlush(IntPtr jnienv, IntPtr native__this)
		{
			IEventProcessor eventProcessor = Java.Lang.Object.GetObject<IEventProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			eventProcessor.BlockingFlush();
		}

		public void BlockingFlush()
		{
			if (id_blockingFlush == IntPtr.Zero)
			{
				id_blockingFlush = JNIEnv.GetMethodID(class_ref, "blockingFlush", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_blockingFlush);
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
			IEventProcessor eventProcessor = Java.Lang.Object.GetObject<IEventProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			eventProcessor.Flush();
		}

		public void Flush()
		{
			if (id_flush == IntPtr.Zero)
			{
				id_flush = JNIEnv.GetMethodID(class_ref, "flush", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_flush);
		}

		private static Delegate GetRecordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_Handler()
		{
			if ((object)cb_recordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_ == null)
			{
				cb_recordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RecordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_));
			}
			return cb_recordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_;
		}

		private static void n_RecordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IEventProcessor eventProcessor = Java.Lang.Object.GetObject<IEventProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDUser p = Java.Lang.Object.GetObject<LDUser>(native_p0, JniHandleOwnership.DoNotTransfer);
			LDUser p2 = Java.Lang.Object.GetObject<LDUser>(native_p1, JniHandleOwnership.DoNotTransfer);
			eventProcessor.RecordAliasEvent(p, p2);
		}

		public unsafe void RecordAliasEvent(LDUser p0, LDUser p1)
		{
			if (id_recordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_ == IntPtr.Zero)
			{
				id_recordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_ = JNIEnv.GetMethodID(class_ref, "recordAliasEvent", "(Lcom/launchdarkly/sdk/LDUser;Lcom/launchdarkly/sdk/LDUser;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_recordAliasEvent_Lcom_launchdarkly_sdk_LDUser_Lcom_launchdarkly_sdk_LDUser_, ptr);
		}

		private static Delegate GetRecordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_Handler()
		{
			if ((object)cb_recordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_ == null)
			{
				cb_recordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_RecordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_));
			}
			return cb_recordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_;
		}

		private static void n_RecordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			IEventProcessor eventProcessor = Java.Lang.Object.GetObject<IEventProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDUser p = Java.Lang.Object.GetObject<LDUser>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			LDValue p3 = Java.Lang.Object.GetObject<LDValue>(native_p2, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Double p4 = Java.Lang.Object.GetObject<Java.Lang.Double>(native_p3, JniHandleOwnership.DoNotTransfer);
			eventProcessor.RecordCustomEvent(p, p2, p3, p4);
		}

		public unsafe void RecordCustomEvent(LDUser p0, string p1, LDValue p2, Java.Lang.Double p3)
		{
			if (id_recordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_ == IntPtr.Zero)
			{
				id_recordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_ = JNIEnv.GetMethodID(class_ref, "recordCustomEvent", "(Lcom/launchdarkly/sdk/LDUser;Ljava/lang/String;Lcom/launchdarkly/sdk/LDValue;Ljava/lang/Double;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			ptr[3] = new JValue(p3?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_recordCustomEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_Lcom_launchdarkly_sdk_LDValue_Ljava_lang_Double_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetRecordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_Handler()
		{
			if ((object)cb_recordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_ == null)
			{
				cb_recordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLIILLLZL_V(n_RecordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_));
			}
			return cb_recordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_;
		}

		private static void n_RecordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2, int p3, IntPtr native_p4, IntPtr native_p5, IntPtr native_p6, bool p7, IntPtr native_p8)
		{
			IEventProcessor eventProcessor = Java.Lang.Object.GetObject<IEventProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDUser p8 = Java.Lang.Object.GetObject<LDUser>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p9 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			LDValue p10 = Java.Lang.Object.GetObject<LDValue>(native_p4, JniHandleOwnership.DoNotTransfer);
			EvaluationReason p11 = Java.Lang.Object.GetObject<EvaluationReason>(native_p5, JniHandleOwnership.DoNotTransfer);
			LDValue p12 = Java.Lang.Object.GetObject<LDValue>(native_p6, JniHandleOwnership.DoNotTransfer);
			Long p13 = Java.Lang.Object.GetObject<Long>(native_p8, JniHandleOwnership.DoNotTransfer);
			eventProcessor.RecordEvaluationEvent(p8, p9, p2, p3, p10, p11, p12, p7, p13);
		}

		public unsafe void RecordEvaluationEvent(LDUser p0, string p1, int p2, int p3, LDValue p4, EvaluationReason p5, LDValue p6, bool p7, Long p8)
		{
			if (id_recordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_ == IntPtr.Zero)
			{
				id_recordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_ = JNIEnv.GetMethodID(class_ref, "recordEvaluationEvent", "(Lcom/launchdarkly/sdk/LDUser;Ljava/lang/String;IILcom/launchdarkly/sdk/LDValue;Lcom/launchdarkly/sdk/EvaluationReason;Lcom/launchdarkly/sdk/LDValue;ZLjava/lang/Long;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[9];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			ptr[2] = new JValue(p2);
			ptr[3] = new JValue(p3);
			ptr[4] = new JValue(p4?.Handle ?? IntPtr.Zero);
			ptr[5] = new JValue(p5?.Handle ?? IntPtr.Zero);
			ptr[6] = new JValue(p6?.Handle ?? IntPtr.Zero);
			ptr[7] = new JValue(p7);
			ptr[8] = new JValue(p8?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_recordEvaluationEvent_Lcom_launchdarkly_sdk_LDUser_Ljava_lang_String_IILcom_launchdarkly_sdk_LDValue_Lcom_launchdarkly_sdk_EvaluationReason_Lcom_launchdarkly_sdk_LDValue_ZLjava_lang_Long_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetRecordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_Handler()
		{
			if ((object)cb_recordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_ == null)
			{
				cb_recordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RecordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_));
			}
			return cb_recordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_;
		}

		private static void n_RecordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IEventProcessor eventProcessor = Java.Lang.Object.GetObject<IEventProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDUser p = Java.Lang.Object.GetObject<LDUser>(native_p0, JniHandleOwnership.DoNotTransfer);
			eventProcessor.RecordIdentifyEvent(p);
		}

		public unsafe void RecordIdentifyEvent(LDUser p0)
		{
			if (id_recordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_ == IntPtr.Zero)
			{
				id_recordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_ = JNIEnv.GetMethodID(class_ref, "recordIdentifyEvent", "(Lcom/launchdarkly/sdk/LDUser;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_recordIdentifyEvent_Lcom_launchdarkly_sdk_LDUser_, ptr);
		}

		private static Delegate GetSetOffline_ZHandler()
		{
			if ((object)cb_setOffline_Z == null)
			{
				cb_setOffline_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetOffline_Z));
			}
			return cb_setOffline_Z;
		}

		private static void n_SetOffline_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			IEventProcessor eventProcessor = Java.Lang.Object.GetObject<IEventProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			eventProcessor.SetOffline(p0);
		}

		public unsafe void SetOffline(bool p0)
		{
			if (id_setOffline_Z == IntPtr.Zero)
			{
				id_setOffline_Z = JNIEnv.GetMethodID(class_ref, "setOffline", "(Z)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0);
			JNIEnv.CallVoidMethod(base.Handle, id_setOffline_Z, ptr);
		}

		private static Delegate GetStartHandler()
		{
			if ((object)cb_start == null)
			{
				cb_start = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Start));
			}
			return cb_start;
		}

		private static void n_Start(IntPtr jnienv, IntPtr native__this)
		{
			IEventProcessor eventProcessor = Java.Lang.Object.GetObject<IEventProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			eventProcessor.Start();
		}

		public void Start()
		{
			if (id_start == IntPtr.Zero)
			{
				id_start = JNIEnv.GetMethodID(class_ref, "start", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_start);
		}

		private static Delegate GetStopHandler()
		{
			if ((object)cb_stop == null)
			{
				cb_stop = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Stop));
			}
			return cb_stop;
		}

		private static void n_Stop(IntPtr jnienv, IntPtr native__this)
		{
			IEventProcessor eventProcessor = Java.Lang.Object.GetObject<IEventProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			eventProcessor.Stop();
		}

		public void Stop()
		{
			if (id_stop == IntPtr.Zero)
			{
				id_stop = JNIEnv.GetMethodID(class_ref, "stop", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_stop);
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
			IEventProcessor eventProcessor = Java.Lang.Object.GetObject<IEventProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			eventProcessor.Close();
		}

		public void Close()
		{
			if (id_close == IntPtr.Zero)
			{
				id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_close);
		}
	}
	[Register("com/launchdarkly/sdk/android/subsystems/ServiceEndpoints", DoNotGenerateAcw = true)]
	public sealed class ServiceEndpoints : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/subsystems/ServiceEndpoints", typeof(ServiceEndpoints));

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

		public unsafe URI EventsBaseUri
		{
			[Register("getEventsBaseUri", "()Ljava/net/URI;", "")]
			get
			{
				return Java.Lang.Object.GetObject<URI>(_members.InstanceMethods.InvokeAbstractObjectMethod("getEventsBaseUri.()Ljava/net/URI;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe URI PollingBaseUri
		{
			[Register("getPollingBaseUri", "()Ljava/net/URI;", "")]
			get
			{
				return Java.Lang.Object.GetObject<URI>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPollingBaseUri.()Ljava/net/URI;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe URI StreamingBaseUri
		{
			[Register("getStreamingBaseUri", "()Ljava/net/URI;", "")]
			get
			{
				return Java.Lang.Object.GetObject<URI>(_members.InstanceMethods.InvokeAbstractObjectMethod("getStreamingBaseUri.()Ljava/net/URI;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ServiceEndpoints(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/net/URI;Ljava/net/URI;Ljava/net/URI;)V", "")]
		public unsafe ServiceEndpoints(URI streamingBaseUri, URI pollingBaseUri, URI eventsBaseUri)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(streamingBaseUri?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(pollingBaseUri?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(eventsBaseUri?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/net/URI;Ljava/net/URI;Ljava/net/URI;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/net/URI;Ljava/net/URI;Ljava/net/URI;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(streamingBaseUri);
				GC.KeepAlive(pollingBaseUri);
				GC.KeepAlive(eventsBaseUri);
			}
		}
	}
}
namespace Com.Launchdarkly.Sdk.Android.Integrations
{
	[Register("com/launchdarkly/sdk/android/integrations/ApplicationInfoBuilder", DoNotGenerateAcw = true)]
	public sealed class ApplicationInfoBuilder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/integrations/ApplicationInfoBuilder", typeof(ApplicationInfoBuilder));

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

		internal ApplicationInfoBuilder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ApplicationInfoBuilder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("applicationId", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ApplicationInfoBuilder;", "")]
		public unsafe ApplicationInfoBuilder ApplicationId(string applicationId)
		{
			IntPtr intPtr = JNIEnv.NewString(applicationId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ApplicationInfoBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("applicationId.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ApplicationInfoBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("applicationVersion", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ApplicationInfoBuilder;", "")]
		public unsafe ApplicationInfoBuilder ApplicationVersion(string applicationVersion)
		{
			IntPtr intPtr = JNIEnv.NewString(applicationVersion);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ApplicationInfoBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("applicationVersion.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ApplicationInfoBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("createApplicationInfo", "()Lcom/launchdarkly/sdk/android/subsystems/ApplicationInfo;", "")]
		public unsafe ApplicationInfo CreateApplicationInfo()
		{
			return Java.Lang.Object.GetObject<ApplicationInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("createApplicationInfo.()Lcom/launchdarkly/sdk/android/subsystems/ApplicationInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder", DoNotGenerateAcw = true)]
	public abstract class ServiceEndpointsBuilder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder", typeof(ServiceEndpointsBuilder));

		private static Delegate cb_build;

		private static Delegate cb_events_Landroid_net_Uri_;

		private static Delegate cb_events_Ljava_lang_String_;

		private static Delegate cb_events_Ljava_net_URI_;

		private static Delegate cb_polling_Landroid_net_Uri_;

		private static Delegate cb_polling_Ljava_lang_String_;

		private static Delegate cb_polling_Ljava_net_URI_;

		private static Delegate cb_relayProxy_Landroid_net_Uri_;

		private static Delegate cb_relayProxy_Ljava_lang_String_;

		private static Delegate cb_relayProxy_Ljava_net_URI_;

		private static Delegate cb_streaming_Landroid_net_Uri_;

		private static Delegate cb_streaming_Ljava_lang_String_;

		private static Delegate cb_streaming_Ljava_net_URI_;

		[Register("eventsBaseUri")]
		protected URI EventsBaseUri
		{
			get
			{
				return Java.Lang.Object.GetObject<URI>(_members.InstanceFields.GetObjectValue("eventsBaseUri.Ljava/net/URI;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("eventsBaseUri.Ljava/net/URI;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("pollingBaseUri")]
		protected URI PollingBaseUri
		{
			get
			{
				return Java.Lang.Object.GetObject<URI>(_members.InstanceFields.GetObjectValue("pollingBaseUri.Ljava/net/URI;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("pollingBaseUri.Ljava/net/URI;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("streamingBaseUri")]
		protected URI StreamingBaseUri
		{
			get
			{
				return Java.Lang.Object.GetObject<URI>(_members.InstanceFields.GetObjectValue("streamingBaseUri.Ljava/net/URI;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("streamingBaseUri.Ljava/net/URI;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
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

		protected ServiceEndpointsBuilder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ServiceEndpointsBuilder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetBuildHandler()
		{
			if ((object)cb_build == null)
			{
				cb_build = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
			}
			return cb_build;
		}

		private static IntPtr n_Build(IntPtr jnienv, IntPtr native__this)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.Build());
		}

		[Register("build", "()Lcom/launchdarkly/sdk/android/subsystems/ServiceEndpoints;", "GetBuildHandler")]
		public abstract ServiceEndpoints Build();

		private static Delegate GetEvents_Landroid_net_Uri_Handler()
		{
			if ((object)cb_events_Landroid_net_Uri_ == null)
			{
				cb_events_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Events_Landroid_net_Uri_));
			}
			return cb_events_Landroid_net_Uri_;
		}

		private static IntPtr n_Events_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_eventsBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri eventsBaseUri = Java.Lang.Object.GetObject<global::Android.Net.Uri>(native_eventsBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.Events(eventsBaseUri));
		}

		[Register("events", "(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetEvents_Landroid_net_Uri_Handler")]
		public unsafe virtual ServiceEndpointsBuilder Events(global::Android.Net.Uri eventsBaseUri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(eventsBaseUri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("events.(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(eventsBaseUri);
			}
		}

		private static Delegate GetEvents_Ljava_lang_String_Handler()
		{
			if ((object)cb_events_Ljava_lang_String_ == null)
			{
				cb_events_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Events_Ljava_lang_String_));
			}
			return cb_events_Ljava_lang_String_;
		}

		private static IntPtr n_Events_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_eventsBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string eventsBaseUri = JNIEnv.GetString(native_eventsBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.Events(eventsBaseUri));
		}

		[Register("events", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetEvents_Ljava_lang_String_Handler")]
		public unsafe virtual ServiceEndpointsBuilder Events(string eventsBaseUri)
		{
			IntPtr intPtr = JNIEnv.NewString(eventsBaseUri);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("events.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetEvents_Ljava_net_URI_Handler()
		{
			if ((object)cb_events_Ljava_net_URI_ == null)
			{
				cb_events_Ljava_net_URI_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Events_Ljava_net_URI_));
			}
			return cb_events_Ljava_net_URI_;
		}

		private static IntPtr n_Events_Ljava_net_URI_(IntPtr jnienv, IntPtr native__this, IntPtr native_eventsBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			URI eventsBaseUri = Java.Lang.Object.GetObject<URI>(native_eventsBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.Events(eventsBaseUri));
		}

		[Register("events", "(Ljava/net/URI;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetEvents_Ljava_net_URI_Handler")]
		public unsafe virtual ServiceEndpointsBuilder Events(URI eventsBaseUri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(eventsBaseUri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("events.(Ljava/net/URI;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(eventsBaseUri);
			}
		}

		private static Delegate GetPolling_Landroid_net_Uri_Handler()
		{
			if ((object)cb_polling_Landroid_net_Uri_ == null)
			{
				cb_polling_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Polling_Landroid_net_Uri_));
			}
			return cb_polling_Landroid_net_Uri_;
		}

		private static IntPtr n_Polling_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_pollingBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri pollingBaseUri = Java.Lang.Object.GetObject<global::Android.Net.Uri>(native_pollingBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.Polling(pollingBaseUri));
		}

		[Register("polling", "(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetPolling_Landroid_net_Uri_Handler")]
		public unsafe virtual ServiceEndpointsBuilder Polling(global::Android.Net.Uri pollingBaseUri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(pollingBaseUri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("polling.(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(pollingBaseUri);
			}
		}

		private static Delegate GetPolling_Ljava_lang_String_Handler()
		{
			if ((object)cb_polling_Ljava_lang_String_ == null)
			{
				cb_polling_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Polling_Ljava_lang_String_));
			}
			return cb_polling_Ljava_lang_String_;
		}

		private static IntPtr n_Polling_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_pollingBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string pollingBaseUri = JNIEnv.GetString(native_pollingBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.Polling(pollingBaseUri));
		}

		[Register("polling", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetPolling_Ljava_lang_String_Handler")]
		public unsafe virtual ServiceEndpointsBuilder Polling(string pollingBaseUri)
		{
			IntPtr intPtr = JNIEnv.NewString(pollingBaseUri);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("polling.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetPolling_Ljava_net_URI_Handler()
		{
			if ((object)cb_polling_Ljava_net_URI_ == null)
			{
				cb_polling_Ljava_net_URI_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Polling_Ljava_net_URI_));
			}
			return cb_polling_Ljava_net_URI_;
		}

		private static IntPtr n_Polling_Ljava_net_URI_(IntPtr jnienv, IntPtr native__this, IntPtr native_pollingBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			URI pollingBaseUri = Java.Lang.Object.GetObject<URI>(native_pollingBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.Polling(pollingBaseUri));
		}

		[Register("polling", "(Ljava/net/URI;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetPolling_Ljava_net_URI_Handler")]
		public unsafe virtual ServiceEndpointsBuilder Polling(URI pollingBaseUri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(pollingBaseUri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("polling.(Ljava/net/URI;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(pollingBaseUri);
			}
		}

		private static Delegate GetRelayProxy_Landroid_net_Uri_Handler()
		{
			if ((object)cb_relayProxy_Landroid_net_Uri_ == null)
			{
				cb_relayProxy_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RelayProxy_Landroid_net_Uri_));
			}
			return cb_relayProxy_Landroid_net_Uri_;
		}

		private static IntPtr n_RelayProxy_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_relayProxyBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri relayProxyBaseUri = Java.Lang.Object.GetObject<global::Android.Net.Uri>(native_relayProxyBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.RelayProxy(relayProxyBaseUri));
		}

		[Register("relayProxy", "(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetRelayProxy_Landroid_net_Uri_Handler")]
		public unsafe virtual ServiceEndpointsBuilder RelayProxy(global::Android.Net.Uri relayProxyBaseUri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(relayProxyBaseUri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("relayProxy.(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(relayProxyBaseUri);
			}
		}

		private static Delegate GetRelayProxy_Ljava_lang_String_Handler()
		{
			if ((object)cb_relayProxy_Ljava_lang_String_ == null)
			{
				cb_relayProxy_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RelayProxy_Ljava_lang_String_));
			}
			return cb_relayProxy_Ljava_lang_String_;
		}

		private static IntPtr n_RelayProxy_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_relayProxyBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string relayProxyBaseUri = JNIEnv.GetString(native_relayProxyBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.RelayProxy(relayProxyBaseUri));
		}

		[Register("relayProxy", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetRelayProxy_Ljava_lang_String_Handler")]
		public unsafe virtual ServiceEndpointsBuilder RelayProxy(string relayProxyBaseUri)
		{
			IntPtr intPtr = JNIEnv.NewString(relayProxyBaseUri);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("relayProxy.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetRelayProxy_Ljava_net_URI_Handler()
		{
			if ((object)cb_relayProxy_Ljava_net_URI_ == null)
			{
				cb_relayProxy_Ljava_net_URI_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RelayProxy_Ljava_net_URI_));
			}
			return cb_relayProxy_Ljava_net_URI_;
		}

		private static IntPtr n_RelayProxy_Ljava_net_URI_(IntPtr jnienv, IntPtr native__this, IntPtr native_relayProxyBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			URI relayProxyBaseUri = Java.Lang.Object.GetObject<URI>(native_relayProxyBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.RelayProxy(relayProxyBaseUri));
		}

		[Register("relayProxy", "(Ljava/net/URI;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetRelayProxy_Ljava_net_URI_Handler")]
		public unsafe virtual ServiceEndpointsBuilder RelayProxy(URI relayProxyBaseUri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(relayProxyBaseUri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("relayProxy.(Ljava/net/URI;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(relayProxyBaseUri);
			}
		}

		private static Delegate GetStreaming_Landroid_net_Uri_Handler()
		{
			if ((object)cb_streaming_Landroid_net_Uri_ == null)
			{
				cb_streaming_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Streaming_Landroid_net_Uri_));
			}
			return cb_streaming_Landroid_net_Uri_;
		}

		private static IntPtr n_Streaming_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_streamingBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri streamingBaseUri = Java.Lang.Object.GetObject<global::Android.Net.Uri>(native_streamingBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.Streaming(streamingBaseUri));
		}

		[Register("streaming", "(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetStreaming_Landroid_net_Uri_Handler")]
		public unsafe virtual ServiceEndpointsBuilder Streaming(global::Android.Net.Uri streamingBaseUri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(streamingBaseUri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("streaming.(Landroid/net/Uri;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(streamingBaseUri);
			}
		}

		private static Delegate GetStreaming_Ljava_lang_String_Handler()
		{
			if ((object)cb_streaming_Ljava_lang_String_ == null)
			{
				cb_streaming_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Streaming_Ljava_lang_String_));
			}
			return cb_streaming_Ljava_lang_String_;
		}

		private static IntPtr n_Streaming_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_streamingBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string streamingBaseUri = JNIEnv.GetString(native_streamingBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.Streaming(streamingBaseUri));
		}

		[Register("streaming", "(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetStreaming_Ljava_lang_String_Handler")]
		public unsafe virtual ServiceEndpointsBuilder Streaming(string streamingBaseUri)
		{
			IntPtr intPtr = JNIEnv.NewString(streamingBaseUri);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("streaming.(Ljava/lang/String;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetStreaming_Ljava_net_URI_Handler()
		{
			if ((object)cb_streaming_Ljava_net_URI_ == null)
			{
				cb_streaming_Ljava_net_URI_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Streaming_Ljava_net_URI_));
			}
			return cb_streaming_Ljava_net_URI_;
		}

		private static IntPtr n_Streaming_Ljava_net_URI_(IntPtr jnienv, IntPtr native__this, IntPtr native_streamingBaseUri)
		{
			ServiceEndpointsBuilder serviceEndpointsBuilder = Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			URI streamingBaseUri = Java.Lang.Object.GetObject<URI>(native_streamingBaseUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(serviceEndpointsBuilder.Streaming(streamingBaseUri));
		}

		[Register("streaming", "(Ljava/net/URI;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", "GetStreaming_Ljava_net_URI_Handler")]
		public unsafe virtual ServiceEndpointsBuilder Streaming(URI streamingBaseUri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(streamingBaseUri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ServiceEndpointsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("streaming.(Ljava/net/URI;)Lcom/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(streamingBaseUri);
			}
		}
	}
	[Register("com/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder", DoNotGenerateAcw = true)]
	internal class ServiceEndpointsBuilderInvoker : ServiceEndpointsBuilder
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/sdk/android/integrations/ServiceEndpointsBuilder", typeof(ServiceEndpointsBuilderInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ServiceEndpointsBuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("build", "()Lcom/launchdarkly/sdk/android/subsystems/ServiceEndpoints;", "GetBuildHandler")]
		public unsafe override ServiceEndpoints Build()
		{
			return Java.Lang.Object.GetObject<ServiceEndpoints>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/launchdarkly/sdk/android/subsystems/ServiceEndpoints;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Com.Launchdarkly.Logging
{
	[Register("com/launchdarkly/logging/LDLogAdapter$Channel", "", "Com.Launchdarkly.Logging.ILDLogAdapterChannelInvoker")]
	public interface ILDLogAdapterChannel : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("isEnabled", "(Lcom/launchdarkly/logging/LDLogLevel;)Z", "GetIsEnabled_Lcom_launchdarkly_logging_LDLogLevel_Handler:Com.Launchdarkly.Logging.ILDLogAdapterChannelInvoker, LaunchDarklyAndroidBinding")]
		bool IsEnabled(LDLogLevel p0);

		[Register("log", "(Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/Object;)V", "GetLog_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_Handler:Com.Launchdarkly.Logging.ILDLogAdapterChannelInvoker, LaunchDarklyAndroidBinding")]
		void Log(LDLogLevel p0, Java.Lang.Object p1);

		[Register("log", "(Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/String;Ljava/lang/Object;)V", "GetLog_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Handler:Com.Launchdarkly.Logging.ILDLogAdapterChannelInvoker, LaunchDarklyAndroidBinding")]
		void Log(LDLogLevel p0, string p1, Java.Lang.Object p2);

		[Register("log", "(Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", "GetLog_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_Handler:Com.Launchdarkly.Logging.ILDLogAdapterChannelInvoker, LaunchDarklyAndroidBinding")]
		void Log(LDLogLevel p0, string p1, Java.Lang.Object p2, Java.Lang.Object p3);

		[Register("log", "(Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/String;[Ljava/lang/Object;)V", "GetLog_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_Handler:Com.Launchdarkly.Logging.ILDLogAdapterChannelInvoker, LaunchDarklyAndroidBinding")]
		void Log(LDLogLevel p0, string p1, params Java.Lang.Object[] p2);
	}
	[Register("com/launchdarkly/logging/LDLogAdapter$Channel", DoNotGenerateAcw = true)]
	internal class ILDLogAdapterChannelInvoker : Java.Lang.Object, ILDLogAdapterChannel, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LDLogAdapter$Channel", typeof(ILDLogAdapterChannelInvoker));

		private IntPtr class_ref;

		private static Delegate cb_isEnabled_Lcom_launchdarkly_logging_LDLogLevel_;

		private IntPtr id_isEnabled_Lcom_launchdarkly_logging_LDLogLevel_;

		private static Delegate cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_;

		private IntPtr id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_;

		private static Delegate cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_;

		private IntPtr id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_;

		private static Delegate cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_;

		private IntPtr id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_;

		private static Delegate cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_;

		private IntPtr id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_;

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

		public static ILDLogAdapterChannel GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILDLogAdapterChannel>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.logging.LDLogAdapter.Channel'.");
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

		public ILDLogAdapterChannelInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetIsEnabled_Lcom_launchdarkly_logging_LDLogLevel_Handler()
		{
			if ((object)cb_isEnabled_Lcom_launchdarkly_logging_LDLogLevel_ == null)
			{
				cb_isEnabled_Lcom_launchdarkly_logging_LDLogLevel_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsEnabled_Lcom_launchdarkly_logging_LDLogLevel_));
			}
			return cb_isEnabled_Lcom_launchdarkly_logging_LDLogLevel_;
		}

		private static bool n_IsEnabled_Lcom_launchdarkly_logging_LDLogLevel_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDLogAdapterChannel iLDLogAdapterChannel = Java.Lang.Object.GetObject<ILDLogAdapterChannel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDLogLevel p = Java.Lang.Object.GetObject<LDLogLevel>(native_p0, JniHandleOwnership.DoNotTransfer);
			return iLDLogAdapterChannel.IsEnabled(p);
		}

		public unsafe bool IsEnabled(LDLogLevel p0)
		{
			if (id_isEnabled_Lcom_launchdarkly_logging_LDLogLevel_ == IntPtr.Zero)
			{
				id_isEnabled_Lcom_launchdarkly_logging_LDLogLevel_ = JNIEnv.GetMethodID(class_ref, "isEnabled", "(Lcom/launchdarkly/logging/LDLogLevel;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_isEnabled_Lcom_launchdarkly_logging_LDLogLevel_, ptr);
		}

		private static Delegate GetLog_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_Handler()
		{
			if ((object)cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_ == null)
			{
				cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_));
			}
			return cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_;
		}

		private static void n_Log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ILDLogAdapterChannel iLDLogAdapterChannel = Java.Lang.Object.GetObject<ILDLogAdapterChannel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDLogLevel p = Java.Lang.Object.GetObject<LDLogLevel>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			iLDLogAdapterChannel.Log(p, p2);
		}

		public unsafe void Log(LDLogLevel p0, Java.Lang.Object p1)
		{
			if (id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "log", "(Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/Object;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetLog_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_ == null)
			{
				cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_));
			}
			return cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_;
		}

		private static void n_Log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			ILDLogAdapterChannel iLDLogAdapterChannel = Java.Lang.Object.GetObject<ILDLogAdapterChannel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDLogLevel p = Java.Lang.Object.GetObject<LDLogLevel>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p3 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p2, JniHandleOwnership.DoNotTransfer);
			iLDLogAdapterChannel.Log(p, p2, p3);
		}

		public unsafe void Log(LDLogLevel p0, string p1, Java.Lang.Object p2)
		{
			if (id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "log", "(Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/String;Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetLog_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_Handler()
		{
			if ((object)cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_ == null)
			{
				cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_Log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_));
			}
			return cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_;
		}

		private static void n_Log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			ILDLogAdapterChannel iLDLogAdapterChannel = Java.Lang.Object.GetObject<ILDLogAdapterChannel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDLogLevel p = Java.Lang.Object.GetObject<LDLogLevel>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p3 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p2, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p4 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p3, JniHandleOwnership.DoNotTransfer);
			iLDLogAdapterChannel.Log(p, p2, p3, p4);
		}

		public unsafe void Log(LDLogLevel p0, string p1, Java.Lang.Object p2, Java.Lang.Object p3)
		{
			if (id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "log", "(Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			ptr[3] = new JValue(p3?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_Ljava_lang_Object_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetLog_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_Handler()
		{
			if ((object)cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_ == null)
			{
				cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_));
			}
			return cb_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_;
		}

		private static void n_Log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			ILDLogAdapterChannel iLDLogAdapterChannel = Java.Lang.Object.GetObject<ILDLogAdapterChannel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LDLogLevel p = Java.Lang.Object.GetObject<LDLogLevel>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
			iLDLogAdapterChannel.Log(p, p2, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p2);
			}
		}

		public unsafe void Log(LDLogLevel p0, string p1, params Java.Lang.Object[] p2)
		{
			if (id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_ == IntPtr.Zero)
			{
				id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "log", "(Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/String;[Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p1);
			IntPtr intPtr2 = JNIEnv.NewArray(p2);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			ptr[2] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_log_Lcom_launchdarkly_logging_LDLogLevel_Ljava_lang_String_arrayLjava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			if (p2 != null)
			{
				JNIEnv.CopyArray(intPtr2, p2);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}
	}
	[Register("com/launchdarkly/logging/LDLogAdapter$IsConfiguredExternally", "", "Com.Launchdarkly.Logging.ILDLogAdapterIsConfiguredExternallyInvoker")]
	public interface ILDLogAdapterIsConfiguredExternally : IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/launchdarkly/logging/LDLogAdapter$IsConfiguredExternally", DoNotGenerateAcw = true)]
	internal class ILDLogAdapterIsConfiguredExternallyInvoker : Java.Lang.Object, ILDLogAdapterIsConfiguredExternally, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LDLogAdapter$IsConfiguredExternally", typeof(ILDLogAdapterIsConfiguredExternallyInvoker));

		private IntPtr class_ref;

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

		public static ILDLogAdapterIsConfiguredExternally GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILDLogAdapterIsConfiguredExternally>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.logging.LDLogAdapter.IsConfiguredExternally'.");
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

		public ILDLogAdapterIsConfiguredExternallyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}
	}
	[Register("com/launchdarkly/logging/LDLogAdapter", "", "Com.Launchdarkly.Logging.ILDLogAdapterInvoker")]
	public interface ILDLogAdapter : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("newChannel", "(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogAdapter$Channel;", "GetNewChannel_Ljava_lang_String_Handler:Com.Launchdarkly.Logging.ILDLogAdapterInvoker, LaunchDarklyAndroidBinding")]
		ILDLogAdapterChannel NewChannel(string p0);
	}
	[Register("com/launchdarkly/logging/LDLogAdapter", DoNotGenerateAcw = true)]
	internal class ILDLogAdapterInvoker : Java.Lang.Object, ILDLogAdapter, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LDLogAdapter", typeof(ILDLogAdapterInvoker));

		private IntPtr class_ref;

		private static Delegate cb_newChannel_Ljava_lang_String_;

		private IntPtr id_newChannel_Ljava_lang_String_;

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

		public static ILDLogAdapter GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILDLogAdapter>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.logging.LDLogAdapter'.");
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

		public ILDLogAdapterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetNewChannel_Ljava_lang_String_Handler()
		{
			if ((object)cb_newChannel_Ljava_lang_String_ == null)
			{
				cb_newChannel_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_NewChannel_Ljava_lang_String_));
			}
			return cb_newChannel_Ljava_lang_String_;
		}

		private static IntPtr n_NewChannel_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ILDLogAdapter iLDLogAdapter = Java.Lang.Object.GetObject<ILDLogAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iLDLogAdapter.NewChannel(p));
		}

		public unsafe ILDLogAdapterChannel NewChannel(string p0)
		{
			if (id_newChannel_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_newChannel_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "newChannel", "(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogAdapter$Channel;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			ILDLogAdapterChannel result = Java.Lang.Object.GetObject<ILDLogAdapterChannel>(JNIEnv.CallObjectMethod(base.Handle, id_newChannel_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}
	}
	[Register("com/launchdarkly/logging/LDLogger", DoNotGenerateAcw = true)]
	public sealed class LDLogger : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LDLogger", typeof(LDLogger));

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

		internal LDLogger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("debug", "(Ljava/lang/Object;)V", "")]
		public unsafe void Debug(Java.Lang.Object message)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(message?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("debug.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(message);
			}
		}

		[Register("debug", "(Ljava/lang/String;Ljava/lang/Object;)V", "")]
		public unsafe void Debug(string format, Java.Lang.Object param)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(param?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("debug.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(param);
			}
		}

		[Register("debug", "(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", "")]
		public unsafe void Debug(string format, Java.Lang.Object param1, Java.Lang.Object param2)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(param1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(param2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("debug.(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(param1);
				GC.KeepAlive(param2);
			}
		}

		[Register("debug", "(Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe void Debug(string format, params Java.Lang.Object[] @params)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			IntPtr intPtr2 = JNIEnv.NewArray(@params);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeAbstractVoidMethod("debug.(Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (@params != null)
				{
					JNIEnv.CopyArray(intPtr2, @params);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(@params);
			}
		}

		[Register("error", "(Ljava/lang/Object;)V", "")]
		public unsafe void Error(Java.Lang.Object message)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(message?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("error.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(message);
			}
		}

		[Register("error", "(Ljava/lang/String;Ljava/lang/Object;)V", "")]
		public unsafe void Error(string format, Java.Lang.Object param)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(param?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("error.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(param);
			}
		}

		[Register("error", "(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", "")]
		public unsafe void Error(string format, Java.Lang.Object param1, Java.Lang.Object param2)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(param1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(param2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("error.(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(param1);
				GC.KeepAlive(param2);
			}
		}

		[Register("error", "(Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe void Error(string format, params Java.Lang.Object[] @params)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			IntPtr intPtr2 = JNIEnv.NewArray(@params);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeAbstractVoidMethod("error.(Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (@params != null)
				{
					JNIEnv.CopyArray(intPtr2, @params);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(@params);
			}
		}

		[Register("info", "(Ljava/lang/Object;)V", "")]
		public unsafe void Info(Java.Lang.Object message)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(message?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("info.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(message);
			}
		}

		[Register("info", "(Ljava/lang/String;Ljava/lang/Object;)V", "")]
		public unsafe void Info(string format, Java.Lang.Object param)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(param?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("info.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(param);
			}
		}

		[Register("info", "(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", "")]
		public unsafe void Info(string format, Java.Lang.Object param1, Java.Lang.Object param2)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(param1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(param2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("info.(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(param1);
				GC.KeepAlive(param2);
			}
		}

		[Register("info", "(Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe void Info(string format, params Java.Lang.Object[] @params)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			IntPtr intPtr2 = JNIEnv.NewArray(@params);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeAbstractVoidMethod("info.(Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (@params != null)
				{
					JNIEnv.CopyArray(intPtr2, @params);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(@params);
			}
		}

		[Register("isEnabled", "(Lcom/launchdarkly/logging/LDLogLevel;)Z", "")]
		public unsafe bool IsEnabled(LDLogLevel level)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(level?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isEnabled.(Lcom/launchdarkly/logging/LDLogLevel;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(level);
			}
		}

		[Register("none", "()Lcom/launchdarkly/logging/LDLogger;", "")]
		public unsafe static LDLogger None()
		{
			return Java.Lang.Object.GetObject<LDLogger>(_members.StaticMethods.InvokeObjectMethod("none.()Lcom/launchdarkly/logging/LDLogger;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("subLogger", "(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogger;", "")]
		public unsafe LDLogger SubLogger(string nameSuffix)
		{
			IntPtr intPtr = JNIEnv.NewString(nameSuffix);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LDLogger>(_members.InstanceMethods.InvokeAbstractObjectMethod("subLogger.(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogger;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("warn", "(Ljava/lang/Object;)V", "")]
		public unsafe void Warn(Java.Lang.Object message)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(message?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("warn.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(message);
			}
		}

		[Register("warn", "(Ljava/lang/String;Ljava/lang/Object;)V", "")]
		public unsafe void Warn(string format, Java.Lang.Object param)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(param?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("warn.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(param);
			}
		}

		[Register("warn", "(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", "")]
		public unsafe void Warn(string format, Java.Lang.Object param1, Java.Lang.Object param2)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(param1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(param2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("warn.(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(param1);
				GC.KeepAlive(param2);
			}
		}

		[Register("warn", "(Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe void Warn(string format, params Java.Lang.Object[] @params)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			IntPtr intPtr2 = JNIEnv.NewArray(@params);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeAbstractVoidMethod("warn.(Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (@params != null)
				{
					JNIEnv.CopyArray(intPtr2, @params);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(@params);
			}
		}

		[Register("withAdapter", "(Lcom/launchdarkly/logging/LDLogAdapter;Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogger;", "")]
		public unsafe static LDLogger WithAdapter(ILDLogAdapter adapter, string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((adapter == null) ? IntPtr.Zero : ((Java.Lang.Object)adapter).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LDLogger>(_members.StaticMethods.InvokeObjectMethod("withAdapter.(Lcom/launchdarkly/logging/LDLogAdapter;Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogger;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(adapter);
			}
		}
	}
	[Register("com/launchdarkly/logging/LDLogLevel", DoNotGenerateAcw = true)]
	public sealed class LDLogLevel : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LDLogLevel", typeof(LDLogLevel));

		[Register("DEBUG")]
		public static LDLogLevel Debug => Java.Lang.Object.GetObject<LDLogLevel>(_members.StaticFields.GetObjectValue("DEBUG.Lcom/launchdarkly/logging/LDLogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ERROR")]
		public static LDLogLevel Error => Java.Lang.Object.GetObject<LDLogLevel>(_members.StaticFields.GetObjectValue("ERROR.Lcom/launchdarkly/logging/LDLogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INFO")]
		public static LDLogLevel Info => Java.Lang.Object.GetObject<LDLogLevel>(_members.StaticFields.GetObjectValue("INFO.Lcom/launchdarkly/logging/LDLogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NONE")]
		public static LDLogLevel None => Java.Lang.Object.GetObject<LDLogLevel>(_members.StaticFields.GetObjectValue("NONE.Lcom/launchdarkly/logging/LDLogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("WARN")]
		public static LDLogLevel Warn => Java.Lang.Object.GetObject<LDLogLevel>(_members.StaticFields.GetObjectValue("WARN.Lcom/launchdarkly/logging/LDLogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal LDLogLevel(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogLevel;", "")]
		public unsafe static LDLogLevel ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LDLogLevel>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogLevel;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/launchdarkly/logging/LDLogLevel;", "")]
		public unsafe static LDLogLevel[] Values()
		{
			return (LDLogLevel[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/launchdarkly/logging/LDLogLevel;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(LDLogLevel));
		}
	}
	[Register("com/launchdarkly/logging/LDSLF4J", DoNotGenerateAcw = true)]
	public sealed class LDSLF4J : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LDSLF4J", typeof(LDSLF4J));

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

		internal LDSLF4J(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("adapter", "()Lcom/launchdarkly/logging/LDLogAdapter;", "")]
		public unsafe static ILDLogAdapter Adapter()
		{
			return Java.Lang.Object.GetObject<ILDLogAdapter>(_members.StaticMethods.InvokeObjectMethod("adapter.()Lcom/launchdarkly/logging/LDLogAdapter;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/logging/LogCapture", DoNotGenerateAcw = true)]
	public sealed class LogCapture : Java.Lang.Object, ILDLogAdapter, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/launchdarkly/logging/LogCapture$Message", DoNotGenerateAcw = true)]
		public sealed class Message : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LogCapture$Message", typeof(Message));

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

			public unsafe LDLogLevel Level
			{
				[Register("getLevel", "()Lcom/launchdarkly/logging/LDLogLevel;", "")]
				get
				{
					return Java.Lang.Object.GetObject<LDLogLevel>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLevel.()Lcom/launchdarkly/logging/LDLogLevel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe string LoggerName
			{
				[Register("getLoggerName", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getLoggerName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe string Text
			{
				[Register("getText", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe Date Timestamp
			{
				[Register("getTimestamp", "()Ljava/util/Date;", "")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTimestamp.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Message(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Ljava/util/Date;Ljava/lang/String;Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/String;)V", "")]
			public unsafe Message(Date timestamp, string loggerName, LDLogLevel level, string text)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.NewString(loggerName);
				IntPtr intPtr2 = JNIEnv.NewString(text);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(timestamp?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(level?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(intPtr2);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/Date;Ljava/lang/String;Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Ljava/util/Date;Ljava/lang/String;Lcom/launchdarkly/logging/LDLogLevel;Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(timestamp);
					GC.KeepAlive(level);
				}
			}

			[Register("toStringWithTimestamp", "()Ljava/lang/String;", "")]
			public unsafe string ToStringWithTimestamp()
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toStringWithTimestamp.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LogCapture", typeof(LogCapture));

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

		public unsafe IList<string> MessageStrings
		{
			[Register("getMessageStrings", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getMessageStrings.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<Message> Messages
		{
			[Register("getMessages", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<Message>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getMessages.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal LogCapture(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("awaitMessage", "(Lcom/launchdarkly/logging/LDLogLevel;J)Lcom/launchdarkly/logging/LogCapture$Message;", "")]
		public unsafe Message AwaitMessage(LDLogLevel level, long timeoutMilliseconds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(level?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(timeoutMilliseconds);
				return Java.Lang.Object.GetObject<Message>(_members.InstanceMethods.InvokeAbstractObjectMethod("awaitMessage.(Lcom/launchdarkly/logging/LDLogLevel;J)Lcom/launchdarkly/logging/LogCapture$Message;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(level);
			}
		}

		[Register("awaitMessage", "(J)Lcom/launchdarkly/logging/LogCapture$Message;", "")]
		public unsafe Message AwaitMessage(long timeoutMilliseconds)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(timeoutMilliseconds);
			return Java.Lang.Object.GetObject<Message>(_members.InstanceMethods.InvokeAbstractObjectMethod("awaitMessage.(J)Lcom/launchdarkly/logging/LogCapture$Message;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("newChannel", "(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogAdapter$Channel;", "")]
		public unsafe ILDLogAdapterChannel NewChannel(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ILDLogAdapterChannel>(_members.InstanceMethods.InvokeAbstractObjectMethod("newChannel.(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogAdapter$Channel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("requireMessage", "(Lcom/launchdarkly/logging/LDLogLevel;J)Lcom/launchdarkly/logging/LogCapture$Message;", "")]
		public unsafe Message RequireMessage(LDLogLevel level, long timeoutMilliseconds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(level?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(timeoutMilliseconds);
				return Java.Lang.Object.GetObject<Message>(_members.InstanceMethods.InvokeAbstractObjectMethod("requireMessage.(Lcom/launchdarkly/logging/LDLogLevel;J)Lcom/launchdarkly/logging/LogCapture$Message;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(level);
			}
		}

		[Register("requireMessage", "(J)Lcom/launchdarkly/logging/LogCapture$Message;", "")]
		public unsafe Message RequireMessage(long timeoutMilliseconds)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(timeoutMilliseconds);
			return Java.Lang.Object.GetObject<Message>(_members.InstanceMethods.InvokeAbstractObjectMethod("requireMessage.(J)Lcom/launchdarkly/logging/LogCapture$Message;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/launchdarkly/logging/Logs", DoNotGenerateAcw = true)]
	public abstract class Logs : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/Logs", typeof(Logs));

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

		protected Logs(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("basic", "()Lcom/launchdarkly/logging/LDLogAdapter;", "")]
		public unsafe static ILDLogAdapter Basic()
		{
			return Java.Lang.Object.GetObject<ILDLogAdapter>(_members.StaticMethods.InvokeObjectMethod("basic.()Lcom/launchdarkly/logging/LDLogAdapter;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("capture", "()Lcom/launchdarkly/logging/LogCapture;", "")]
		public unsafe static LogCapture Capture()
		{
			return Java.Lang.Object.GetObject<LogCapture>(_members.StaticMethods.InvokeObjectMethod("capture.()Lcom/launchdarkly/logging/LogCapture;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("level", "(Lcom/launchdarkly/logging/LDLogAdapter;Lcom/launchdarkly/logging/LDLogLevel;)Lcom/launchdarkly/logging/LDLogAdapter;", "")]
		public unsafe static ILDLogAdapter Level(ILDLogAdapter adapter, LDLogLevel minimumLevel)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((adapter == null) ? IntPtr.Zero : ((Java.Lang.Object)adapter).Handle);
				ptr[1] = new JniArgumentValue(minimumLevel?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ILDLogAdapter>(_members.StaticMethods.InvokeObjectMethod("level.(Lcom/launchdarkly/logging/LDLogAdapter;Lcom/launchdarkly/logging/LDLogLevel;)Lcom/launchdarkly/logging/LDLogAdapter;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(adapter);
				GC.KeepAlive(minimumLevel);
			}
		}

		[Register("none", "()Lcom/launchdarkly/logging/LDLogAdapter;", "")]
		public unsafe static ILDLogAdapter None()
		{
			return Java.Lang.Object.GetObject<ILDLogAdapter>(_members.StaticMethods.InvokeObjectMethod("none.()Lcom/launchdarkly/logging/LDLogAdapter;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("toConsole", "()Lcom/launchdarkly/logging/SimpleLogging;", "")]
		public unsafe static SimpleLogging ToConsole()
		{
			return Java.Lang.Object.GetObject<SimpleLogging>(_members.StaticMethods.InvokeObjectMethod("toConsole.()Lcom/launchdarkly/logging/SimpleLogging;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("toJavaUtilLogging", "()Lcom/launchdarkly/logging/LDLogAdapter;", "")]
		public unsafe static ILDLogAdapter ToJavaUtilLogging()
		{
			return Java.Lang.Object.GetObject<ILDLogAdapter>(_members.StaticMethods.InvokeObjectMethod("toJavaUtilLogging.()Lcom/launchdarkly/logging/LDLogAdapter;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("toMethod", "(Lcom/launchdarkly/logging/SimpleLogging$LineWriter;)Lcom/launchdarkly/logging/SimpleLogging;", "")]
		public unsafe static SimpleLogging ToMethod(SimpleLogging.ILineWriter lineWriter)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((lineWriter == null) ? IntPtr.Zero : ((Java.Lang.Object)lineWriter).Handle);
				return Java.Lang.Object.GetObject<SimpleLogging>(_members.StaticMethods.InvokeObjectMethod("toMethod.(Lcom/launchdarkly/logging/SimpleLogging$LineWriter;)Lcom/launchdarkly/logging/SimpleLogging;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(lineWriter);
			}
		}

		[Register("toMultiple", "([Lcom/launchdarkly/logging/LDLogAdapter;)Lcom/launchdarkly/logging/LDLogAdapter;", "")]
		public unsafe static ILDLogAdapter ToMultiple(params ILDLogAdapter[] adapters)
		{
			IntPtr intPtr = JNIEnv.NewArray(adapters);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ILDLogAdapter>(_members.StaticMethods.InvokeObjectMethod("toMultiple.([Lcom/launchdarkly/logging/LDLogAdapter;)Lcom/launchdarkly/logging/LDLogAdapter;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (adapters != null)
				{
					JNIEnv.CopyArray(intPtr, adapters);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(adapters);
			}
		}

		[Register("toStream", "(Ljava/io/PrintStream;)Lcom/launchdarkly/logging/SimpleLogging;", "")]
		public unsafe static SimpleLogging ToStream(PrintStream stream)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(stream?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<SimpleLogging>(_members.StaticMethods.InvokeObjectMethod("toStream.(Ljava/io/PrintStream;)Lcom/launchdarkly/logging/SimpleLogging;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(stream);
			}
		}
	}
	[Register("com/launchdarkly/logging/Logs", DoNotGenerateAcw = true)]
	internal class LogsInvoker : Logs
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/Logs", typeof(LogsInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public LogsInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/launchdarkly/logging/LogValues", DoNotGenerateAcw = true)]
	public abstract class LogValues : Java.Lang.Object
	{
		[Register("com/launchdarkly/logging/LogValues$StringProvider", "", "Com.Launchdarkly.Logging.LogValues/IStringProviderInvoker")]
		public interface IStringProvider : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("get", "()Ljava/lang/String;", "GetGetHandler:Com.Launchdarkly.Logging.LogValues/IStringProviderInvoker, LaunchDarklyAndroidBinding")]
			string Get();
		}

		[Register("com/launchdarkly/logging/LogValues$StringProvider", DoNotGenerateAcw = true)]
		internal class IStringProviderInvoker : Java.Lang.Object, IStringProvider, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LogValues$StringProvider", typeof(IStringProviderInvoker));

			private IntPtr class_ref;

			private static Delegate cb_get;

			private IntPtr id_get;

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

			public static IStringProvider GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IStringProvider>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.logging.LogValues.StringProvider'.");
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

			public IStringProviderInvoker(IntPtr handle, JniHandleOwnership transfer)
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
					cb_get = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Get));
				}
				return cb_get;
			}

			private static IntPtr n_Get(IntPtr jnienv, IntPtr native__this)
			{
				IStringProvider stringProvider = Java.Lang.Object.GetObject<IStringProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(stringProvider.Get());
			}

			public string Get()
			{
				if (id_get == IntPtr.Zero)
				{
					id_get = JNIEnv.GetMethodID(class_ref, "get", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_get), JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LogValues", typeof(LogValues));

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

		protected LogValues(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("defer", "(Lcom/launchdarkly/logging/LogValues$StringProvider;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object Defer(IStringProvider stringProvider)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((stringProvider == null) ? IntPtr.Zero : ((Java.Lang.Object)stringProvider).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("defer.(Lcom/launchdarkly/logging/LogValues$StringProvider;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(stringProvider);
			}
		}

		[Register("exceptionSummary", "(Ljava/lang/Throwable;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object ExceptionSummary(Throwable e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("exceptionSummary.(Ljava/lang/Throwable;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		[Register("exceptionTrace", "(Ljava/lang/Throwable;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object ExceptionTrace(Throwable e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("exceptionTrace.(Ljava/lang/Throwable;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}
	}
	[Register("com/launchdarkly/logging/LogValues", DoNotGenerateAcw = true)]
	internal class LogValuesInvoker : LogValues
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/LogValues", typeof(LogValuesInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public LogValuesInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/launchdarkly/logging/SimpleFormat", DoNotGenerateAcw = true)]
	public abstract class SimpleFormat : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/SimpleFormat", typeof(SimpleFormat));

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

		protected SimpleFormat(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("format", "(Ljava/lang/String;Ljava/lang/Object;)Ljava/lang/String;", "")]
		public unsafe static string Format(string format, Java.Lang.Object param)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(param?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("format.(Ljava/lang/String;Ljava/lang/Object;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(param);
			}
		}

		[Register("format", "(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/String;", "")]
		public unsafe static string Format(string format, Java.Lang.Object param1, Java.Lang.Object param2)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(param1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(param2?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("format.(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(param1);
				GC.KeepAlive(param2);
			}
		}

		[Register("format", "(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;", "")]
		public unsafe static string Format(string format, params Java.Lang.Object[] @params)
		{
			IntPtr intPtr = JNIEnv.NewString(format);
			IntPtr intPtr2 = JNIEnv.NewArray(@params);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("format.(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (@params != null)
				{
					JNIEnv.CopyArray(intPtr2, @params);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(@params);
			}
		}
	}
	[Register("com/launchdarkly/logging/SimpleFormat", DoNotGenerateAcw = true)]
	internal class SimpleFormatInvoker : SimpleFormat
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/SimpleFormat", typeof(SimpleFormatInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public SimpleFormatInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/launchdarkly/logging/SimpleLogging", DoNotGenerateAcw = true)]
	public sealed class SimpleLogging : Java.Lang.Object, ILDLogAdapter, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/launchdarkly/logging/SimpleLogging$LineWriter", "", "Com.Launchdarkly.Logging.SimpleLogging/ILineWriterInvoker")]
		public interface ILineWriter : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("writeLine", "(Ljava/lang/String;)V", "GetWriteLine_Ljava_lang_String_Handler:Com.Launchdarkly.Logging.SimpleLogging/ILineWriterInvoker, LaunchDarklyAndroidBinding")]
			void WriteLine(string p0);
		}

		[Register("com/launchdarkly/logging/SimpleLogging$LineWriter", DoNotGenerateAcw = true)]
		internal class ILineWriterInvoker : Java.Lang.Object, ILineWriter, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/SimpleLogging$LineWriter", typeof(ILineWriterInvoker));

			private IntPtr class_ref;

			private static Delegate cb_writeLine_Ljava_lang_String_;

			private IntPtr id_writeLine_Ljava_lang_String_;

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

			public static ILineWriter GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ILineWriter>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.launchdarkly.logging.SimpleLogging.LineWriter'.");
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

			public ILineWriterInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetWriteLine_Ljava_lang_String_Handler()
			{
				if ((object)cb_writeLine_Ljava_lang_String_ == null)
				{
					cb_writeLine_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_WriteLine_Ljava_lang_String_));
				}
				return cb_writeLine_Ljava_lang_String_;
			}

			private static void n_WriteLine_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				ILineWriter lineWriter = Java.Lang.Object.GetObject<ILineWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				lineWriter.WriteLine(p);
			}

			public unsafe void WriteLine(string p0)
			{
				if (id_writeLine_Ljava_lang_String_ == IntPtr.Zero)
				{
					id_writeLine_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "writeLine", "(Ljava/lang/String;)V");
				}
				IntPtr intPtr = JNIEnv.NewString(p0);
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(intPtr);
				JNIEnv.CallVoidMethod(base.Handle, id_writeLine_Ljava_lang_String_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/launchdarkly/logging/SimpleLogging", typeof(SimpleLogging));

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

		public unsafe static SimpleDateFormat DefaultTimestampFormat
		{
			[Register("getDefaultTimestampFormat", "()Ljava/text/SimpleDateFormat;", "")]
			get
			{
				return Java.Lang.Object.GetObject<SimpleDateFormat>(_members.StaticMethods.InvokeObjectMethod("getDefaultTimestampFormat.()Ljava/text/SimpleDateFormat;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal SimpleLogging(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("newChannel", "(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogAdapter$Channel;", "")]
		public unsafe ILDLogAdapterChannel NewChannel(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ILDLogAdapterChannel>(_members.InstanceMethods.InvokeAbstractObjectMethod("newChannel.(Ljava/lang/String;)Lcom/launchdarkly/logging/LDLogAdapter$Channel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("tag", "(Ljava/lang/String;)Lcom/launchdarkly/logging/SimpleLogging;", "")]
		public unsafe SimpleLogging Tag(string tag)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SimpleLogging>(_members.InstanceMethods.InvokeAbstractObjectMethod("tag.(Ljava/lang/String;)Lcom/launchdarkly/logging/SimpleLogging;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("timestampFormat", "(Ljava/text/DateFormat;)Lcom/launchdarkly/logging/SimpleLogging;", "")]
		public unsafe SimpleLogging TimestampFormat(DateFormat timestampFormat)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(timestampFormat?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<SimpleLogging>(_members.InstanceMethods.InvokeAbstractObjectMethod("timestampFormat.(Ljava/text/DateFormat;)Lcom/launchdarkly/logging/SimpleLogging;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(timestampFormat);
			}
		}
	}
}
