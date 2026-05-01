using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "com.android.billingclient", Managed = "Android.BillingClient")]
[assembly: NamespaceMapping(Java = "com.android.billingclient.api", Managed = "Android.BillingClient.Api")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Android.Google.BillingClient")]
[assembly: AssemblyTitle("Xamarin.Android.Google.BillingClient")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPZ_L(IntPtr jnienv, IntPtr klass, bool p0);
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_android_billingclient_api_mappings;

		private static string[] package_com_android_billingclient_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[2] { "com/android/billingclient/api", "com/android/billingclient" }, new Converter<string, Type>[2] { lookup_com_android_billingclient_api_package, lookup_com_android_billingclient_package });
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

		private static Type lookup_com_android_billingclient_api_package(string klass)
		{
			if (package_com_android_billingclient_api_mappings == null)
			{
				package_com_android_billingclient_api_mappings = new string[22]
				{
					"com/android/billingclient/api/AccountIdentifiers:Android.BillingClient.Api.AccountIdentifiers", "com/android/billingclient/api/AcknowledgePurchaseParams:Android.BillingClient.Api.AcknowledgePurchaseParams", "com/android/billingclient/api/AcknowledgePurchaseParams$Builder:Android.BillingClient.Api.AcknowledgePurchaseParams/Builder", "com/android/billingclient/api/BillingClient:Android.BillingClient.Api.BillingClient", "com/android/billingclient/api/BillingClient$Builder:Android.BillingClient.Api.BillingClient/Builder", "com/android/billingclient/api/BillingFlowParams:Android.BillingClient.Api.BillingFlowParams", "com/android/billingclient/api/BillingFlowParams$Builder:Android.BillingClient.Api.BillingFlowParams/Builder", "com/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams:Android.BillingClient.Api.BillingFlowParams/SubscriptionUpdateParams", "com/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams$Builder:Android.BillingClient.Api.BillingFlowParams/SubscriptionUpdateParams/Builder", "com/android/billingclient/api/BillingResult:Android.BillingClient.Api.BillingResult",
					"com/android/billingclient/api/BillingResult$Builder:Android.BillingClient.Api.BillingResult/Builder", "com/android/billingclient/api/ConsumeParams:Android.BillingClient.Api.ConsumeParams", "com/android/billingclient/api/ConsumeParams$Builder:Android.BillingClient.Api.ConsumeParams/Builder", "com/android/billingclient/api/PriceChangeFlowParams:Android.BillingClient.Api.PriceChangeFlowParams", "com/android/billingclient/api/PriceChangeFlowParams$Builder:Android.BillingClient.Api.PriceChangeFlowParams/Builder", "com/android/billingclient/api/ProxyBillingActivity:Android.BillingClient.Api.ProxyBillingActivity", "com/android/billingclient/api/Purchase:Android.BillingClient.Api.Purchase", "com/android/billingclient/api/Purchase$PurchasesResult:Android.BillingClient.Api.Purchase/PurchasesResult", "com/android/billingclient/api/PurchaseHistoryRecord:Android.BillingClient.Api.PurchaseHistoryRecord", "com/android/billingclient/api/SkuDetails:Android.BillingClient.Api.SkuDetails",
					"com/android/billingclient/api/SkuDetailsParams:Android.BillingClient.Api.SkuDetailsParams", "com/android/billingclient/api/SkuDetailsParams$Builder:Android.BillingClient.Api.SkuDetailsParams/Builder"
				};
			}
			return Lookup(package_com_android_billingclient_api_mappings, klass);
		}

		private static Type lookup_com_android_billingclient_package(string klass)
		{
			if (package_com_android_billingclient_mappings == null)
			{
				package_com_android_billingclient_mappings = new string[1] { "com/android/billingclient/BuildConfig:Android.BillingClient.BuildConfig" };
			}
			return Lookup(package_com_android_billingclient_mappings, klass);
		}
	}
}
namespace Android.BillingClient
{
	[Register("com/android/billingclient/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("APPLICATION_ID")]
		public const string ApplicationId = "com.android.billingclient";

		[Register("VERSION_NAME")]
		public const string VersionName = "4.0.0";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/BuildConfig", typeof(BuildConfig));

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
}
namespace Android.BillingClient.Api
{
	public class ConsumeResult
	{
		public BillingResult BillingResult { get; set; }

		public string PurchaseToken { get; set; }
	}
	public class QueryPurchaseHistoryResult
	{
		public BillingResult Result { get; set; }

		public IList<PurchaseHistoryRecord> PurchaseHistoryRecords { get; set; }
	}
	public class QuerySkuDetailsResult
	{
		public BillingResult Result { get; set; }

		public IList<SkuDetails> SkuDetails { get; set; }
	}
	[Register("com/android/billingclient/api/BillingClient", DoNotGenerateAcw = true)]
	public abstract class BillingClient : Java.Lang.Object
	{
		[Register("com/android/billingclient/api/BillingClient$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private InternalPurchasesUpdatedListener purchasesUpdatedListener;

			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingClient$Builder", typeof(Builder));

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

			public void SetListener(Action<BillingResult, IList<Purchase>> handler)
			{
				purchasesUpdatedListener = new InternalPurchasesUpdatedListener
				{
					PurchasesUpdatedHandler = delegate(BillingResult r, IList<Purchase> p)
					{
						handler?.Invoke(r, p);
					}
				};
				SetListener(purchasesUpdatedListener);
			}

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("build", "()Lcom/android/billingclient/api/BillingClient;", "")]
			public unsafe BillingClient Build()
			{
				return Java.Lang.Object.GetObject<BillingClient>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/android/billingclient/api/BillingClient;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("enablePendingPurchases", "()Lcom/android/billingclient/api/BillingClient$Builder;", "")]
			public unsafe Builder EnablePendingPurchases()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enablePendingPurchases.()Lcom/android/billingclient/api/BillingClient$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setListener", "(Lcom/android/billingclient/api/PurchasesUpdatedListener;)Lcom/android/billingclient/api/BillingClient$Builder;", "")]
			public unsafe Builder SetListener(IPurchasesUpdatedListener listener)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setListener.(Lcom/android/billingclient/api/PurchasesUpdatedListener;)Lcom/android/billingclient/api/BillingClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(listener);
				}
			}
		}

		[Register("com/android/billingclient/api/BillingClient$BillingResponseCode", "", "Android.BillingClient.Api.BillingClient/IBillingResponseCodeInvoker")]
		public interface IBillingResponseCode : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/android/billingclient/api/BillingClient$BillingResponseCode", DoNotGenerateAcw = true)]
		internal class IBillingResponseCodeInvoker : Java.Lang.Object, IBillingResponseCode, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingClient$BillingResponseCode", typeof(IBillingResponseCodeInvoker));

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

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IBillingResponseCode GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IBillingResponseCode>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.BillingClient.BillingResponseCode'.");
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

			public IBillingResponseCodeInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBillingResponseCode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				IBillingResponseCode billingResponseCode = Java.Lang.Object.GetObject<IBillingResponseCode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return billingResponseCode.Equals(obj);
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
				return Java.Lang.Object.GetObject<IBillingResponseCode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IBillingResponseCode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

		[Register("com/android/billingclient/api/BillingClient$ConnectionState", DoNotGenerateAcw = true)]
		public abstract class ConnectionState : Java.Lang.Object
		{
			[Register("CLOSED")]
			public const int Closed = 3;

			[Register("CONNECTED")]
			public const int Connected = 2;

			[Register("CONNECTING")]
			public const int Connecting = 1;

			[Register("DISCONNECTED")]
			public const int Disconnected = 0;

			internal ConnectionState()
			{
			}
		}

		[Register("com/android/billingclient/api/BillingClient$ConnectionState", DoNotGenerateAcw = true)]
		[Obsolete("Use the 'ConnectionState' type. This type will be removed in a future release.", true)]
		public abstract class ConnectionStateConsts : ConnectionState
		{
			private ConnectionStateConsts()
			{
			}
		}

		[Register("com/android/billingclient/api/BillingClient$ConnectionState", "", "Android.BillingClient.Api.BillingClient/IConnectionStateInvoker")]
		public interface IConnectionState : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/android/billingclient/api/BillingClient$ConnectionState", DoNotGenerateAcw = true)]
		internal class IConnectionStateInvoker : Java.Lang.Object, IConnectionState, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingClient$ConnectionState", typeof(IConnectionStateInvoker));

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

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IConnectionState GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IConnectionState>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.BillingClient.ConnectionState'.");
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

			public IConnectionStateInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IConnectionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				IConnectionState connectionState = Java.Lang.Object.GetObject<IConnectionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return connectionState.Equals(obj);
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
				return Java.Lang.Object.GetObject<IConnectionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IConnectionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

		[Register("com/android/billingclient/api/BillingClient$FeatureType", DoNotGenerateAcw = true)]
		public abstract class FeatureType : Java.Lang.Object
		{
			[Register("IN_APP_ITEMS_ON_VR")]
			public const string InAppItemsOnVr = "inAppItemsOnVr";

			[Register("PRICE_CHANGE_CONFIRMATION")]
			public const string PriceChangeConfirmation = "priceChangeConfirmation";

			[Register("SUBSCRIPTIONS")]
			public const string Subscriptions = "subscriptions";

			[Register("SUBSCRIPTIONS_ON_VR")]
			public const string SubscriptionsOnVr = "subscriptionsOnVr";

			[Register("SUBSCRIPTIONS_UPDATE")]
			public const string SubscriptionsUpdate = "subscriptionsUpdate";

			internal FeatureType()
			{
			}
		}

		[Register("com/android/billingclient/api/BillingClient$FeatureType", DoNotGenerateAcw = true)]
		[Obsolete("Use the 'FeatureType' type. This type will be removed in a future release.", true)]
		public abstract class FeatureTypeConsts : FeatureType
		{
			private FeatureTypeConsts()
			{
			}
		}

		[Register("com/android/billingclient/api/BillingClient$FeatureType", "", "Android.BillingClient.Api.BillingClient/IFeatureTypeInvoker")]
		public interface IFeatureType : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/android/billingclient/api/BillingClient$FeatureType", DoNotGenerateAcw = true)]
		internal class IFeatureTypeInvoker : Java.Lang.Object, IFeatureType, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingClient$FeatureType", typeof(IFeatureTypeInvoker));

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

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IFeatureType GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IFeatureType>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.BillingClient.FeatureType'.");
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

			public IFeatureTypeInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFeatureType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				IFeatureType featureType = Java.Lang.Object.GetObject<IFeatureType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return featureType.Equals(obj);
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
				return Java.Lang.Object.GetObject<IFeatureType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IFeatureType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

		[Register("com/android/billingclient/api/BillingClient$SkuType", DoNotGenerateAcw = true)]
		public abstract class SkuType : Java.Lang.Object
		{
			[Register("INAPP")]
			public const string Inapp = "inapp";

			[Register("SUBS")]
			public const string Subs = "subs";

			internal SkuType()
			{
			}
		}

		[Register("com/android/billingclient/api/BillingClient$SkuType", DoNotGenerateAcw = true)]
		[Obsolete("Use the 'SkuType' type. This type will be removed in a future release.", true)]
		public abstract class SkuTypeConsts : SkuType
		{
			private SkuTypeConsts()
			{
			}
		}

		[Register("com/android/billingclient/api/BillingClient$SkuType", "", "Android.BillingClient.Api.BillingClient/ISkuTypeInvoker")]
		public interface ISkuType : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/android/billingclient/api/BillingClient$SkuType", DoNotGenerateAcw = true)]
		internal class ISkuTypeInvoker : Java.Lang.Object, ISkuType, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingClient$SkuType", typeof(ISkuTypeInvoker));

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

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static ISkuType GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ISkuType>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.BillingClient.SkuType'.");
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

			public ISkuTypeInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISkuType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				ISkuType skuType = Java.Lang.Object.GetObject<ISkuType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return skuType.Equals(obj);
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
				return Java.Lang.Object.GetObject<ISkuType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				return JNIEnv.NewString(Java.Lang.Object.GetObject<ISkuType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingClient", typeof(BillingClient));

		private static Delegate cb_isReady;

		private static Delegate cb_acknowledgePurchase_Lcom_android_billingclient_api_AcknowledgePurchaseParams_Lcom_android_billingclient_api_AcknowledgePurchaseResponseListener_;

		private static Delegate cb_consumeAsync_Lcom_android_billingclient_api_ConsumeParams_Lcom_android_billingclient_api_ConsumeResponseListener_;

		private static Delegate cb_endConnection;

		private static Delegate cb_isFeatureSupported_Ljava_lang_String_;

		private static Delegate cb_launchBillingFlow_Landroid_app_Activity_Lcom_android_billingclient_api_BillingFlowParams_;

		private static Delegate cb_launchPriceChangeConfirmationFlow_Landroid_app_Activity_Lcom_android_billingclient_api_PriceChangeFlowParams_Lcom_android_billingclient_api_PriceChangeConfirmationListener_;

		private static Delegate cb_queryPurchaseHistoryAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchaseHistoryResponseListener_;

		private static Delegate cb_queryPurchases_Ljava_lang_String_;

		private static Delegate cb_queryPurchasesAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchasesResponseListener_;

		private static Delegate cb_querySkuDetailsAsync_Lcom_android_billingclient_api_SkuDetailsParams_Lcom_android_billingclient_api_SkuDetailsResponseListener_;

		private static Delegate cb_startConnection_Lcom_android_billingclient_api_BillingClientStateListener_;

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

		public abstract bool IsReady
		{
			[Register("isReady", "()Z", "GetIsReadyHandler")]
			get;
		}

		public Task<BillingResult> AcknowledgePurchaseAsync(AcknowledgePurchaseParams acknowledgePurchaseParams)
		{
			TaskCompletionSource<BillingResult> tcs = new TaskCompletionSource<BillingResult>();
			InternalAcknowledgePurchaseResponseListener p = new InternalAcknowledgePurchaseResponseListener
			{
				AcknowledgePurchaseResponseHandler = delegate(BillingResult r)
				{
					tcs.TrySetResult(r);
				}
			};
			AcknowledgePurchase(acknowledgePurchaseParams, p);
			return tcs.Task;
		}

		public Task<ConsumeResult> ConsumeAsync(ConsumeParams consumeParams)
		{
			TaskCompletionSource<ConsumeResult> tcs = new TaskCompletionSource<ConsumeResult>();
			InternalConsumeResponseListener p = new InternalConsumeResponseListener
			{
				ConsumeResponseHandler = delegate(BillingResult r, string s)
				{
					tcs.TrySetResult(new ConsumeResult
					{
						BillingResult = r,
						PurchaseToken = s
					});
				}
			};
			Consume(consumeParams, p);
			return tcs.Task;
		}

		public Task<QueryPurchaseHistoryResult> QueryPurchaseHistoryAsync(string skuType)
		{
			TaskCompletionSource<QueryPurchaseHistoryResult> tcs = new TaskCompletionSource<QueryPurchaseHistoryResult>();
			InternalPurchaseHistoryResponseListener p = new InternalPurchaseHistoryResponseListener
			{
				PurchaseHistoryResponseHandler = delegate(BillingResult r, IList<PurchaseHistoryRecord> h)
				{
					tcs.TrySetResult(new QueryPurchaseHistoryResult
					{
						Result = r,
						PurchaseHistoryRecords = h
					});
				}
			};
			QueryPurchaseHistory(skuType, p);
			return tcs.Task;
		}

		public Task<QuerySkuDetailsResult> QuerySkuDetailsAsync(SkuDetailsParams skuDetailsParams)
		{
			TaskCompletionSource<QuerySkuDetailsResult> tcs = new TaskCompletionSource<QuerySkuDetailsResult>();
			InternalSkuDetailsResponseListener p = new InternalSkuDetailsResponseListener
			{
				SkuDetailsResponseHandler = delegate(BillingResult r, IList<SkuDetails> s)
				{
					tcs.TrySetResult(new QuerySkuDetailsResult
					{
						Result = r,
						SkuDetails = s
					});
				}
			};
			QuerySkuDetails(skuDetailsParams, p);
			return tcs.Task;
		}

		public Task<BillingResult> StartConnectionAsync(Action onDisconnected = null)
		{
			TaskCompletionSource<BillingResult> tcs = new TaskCompletionSource<BillingResult>();
			InternalBillingClientStateListener p = new InternalBillingClientStateListener
			{
				BillingServiceDisconnectedHandler = delegate
				{
					onDisconnected?.Invoke();
					tcs.TrySetResult(null);
				},
				BillingSetupFinishedHandler = delegate(BillingResult r)
				{
					tcs.TrySetResult(r);
				}
			};
			StartConnection(p);
			return tcs.Task;
		}

		public void StartConnection(Action<BillingResult> setupFinished, Action onDisconnected)
		{
			InternalBillingClientStateListener p = new InternalBillingClientStateListener
			{
				BillingServiceDisconnectedHandler = delegate
				{
					onDisconnected?.Invoke();
				},
				BillingSetupFinishedHandler = delegate(BillingResult r)
				{
					setupFinished?.Invoke(r);
				}
			};
			StartConnection(p);
		}

		public Task<BillingResult> LaunchPriceChangeConfirmationFlowAsync(Activity activity, PriceChangeFlowParams priceChangeFlowParams)
		{
			TaskCompletionSource<BillingResult> tcs = new TaskCompletionSource<BillingResult>();
			InternalPriceChangeConfirmationListener p = new InternalPriceChangeConfirmationListener
			{
				PriceChangeConfirmationHandler = delegate(BillingResult r)
				{
					tcs.TrySetResult(r);
				}
			};
			LaunchPriceChangeConfirmationFlow(activity, priceChangeFlowParams, p);
			return tcs.Task;
		}

		protected BillingClient(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BillingClient()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsReadyHandler()
		{
			if ((object)cb_isReady == null)
			{
				cb_isReady = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsReady));
			}
			return cb_isReady;
		}

		private static bool n_IsReady(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsReady;
		}

		private static Delegate GetAcknowledgePurchase_Lcom_android_billingclient_api_AcknowledgePurchaseParams_Lcom_android_billingclient_api_AcknowledgePurchaseResponseListener_Handler()
		{
			if ((object)cb_acknowledgePurchase_Lcom_android_billingclient_api_AcknowledgePurchaseParams_Lcom_android_billingclient_api_AcknowledgePurchaseResponseListener_ == null)
			{
				cb_acknowledgePurchase_Lcom_android_billingclient_api_AcknowledgePurchaseParams_Lcom_android_billingclient_api_AcknowledgePurchaseResponseListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_AcknowledgePurchase_Lcom_android_billingclient_api_AcknowledgePurchaseParams_Lcom_android_billingclient_api_AcknowledgePurchaseResponseListener_));
			}
			return cb_acknowledgePurchase_Lcom_android_billingclient_api_AcknowledgePurchaseParams_Lcom_android_billingclient_api_AcknowledgePurchaseResponseListener_;
		}

		private static void n_AcknowledgePurchase_Lcom_android_billingclient_api_AcknowledgePurchaseParams_Lcom_android_billingclient_api_AcknowledgePurchaseResponseListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			BillingClient billingClient = Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AcknowledgePurchaseParams p = Java.Lang.Object.GetObject<AcknowledgePurchaseParams>(native_p0, JniHandleOwnership.DoNotTransfer);
			IAcknowledgePurchaseResponseListener p2 = Java.Lang.Object.GetObject<IAcknowledgePurchaseResponseListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			billingClient.AcknowledgePurchase(p, p2);
		}

		[Register("acknowledgePurchase", "(Lcom/android/billingclient/api/AcknowledgePurchaseParams;Lcom/android/billingclient/api/AcknowledgePurchaseResponseListener;)V", "GetAcknowledgePurchase_Lcom_android_billingclient_api_AcknowledgePurchaseParams_Lcom_android_billingclient_api_AcknowledgePurchaseResponseListener_Handler")]
		public abstract void AcknowledgePurchase(AcknowledgePurchaseParams p0, IAcknowledgePurchaseResponseListener p1);

		private static Delegate GetConsume_Lcom_android_billingclient_api_ConsumeParams_Lcom_android_billingclient_api_ConsumeResponseListener_Handler()
		{
			if ((object)cb_consumeAsync_Lcom_android_billingclient_api_ConsumeParams_Lcom_android_billingclient_api_ConsumeResponseListener_ == null)
			{
				cb_consumeAsync_Lcom_android_billingclient_api_ConsumeParams_Lcom_android_billingclient_api_ConsumeResponseListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Consume_Lcom_android_billingclient_api_ConsumeParams_Lcom_android_billingclient_api_ConsumeResponseListener_));
			}
			return cb_consumeAsync_Lcom_android_billingclient_api_ConsumeParams_Lcom_android_billingclient_api_ConsumeResponseListener_;
		}

		private static void n_Consume_Lcom_android_billingclient_api_ConsumeParams_Lcom_android_billingclient_api_ConsumeResponseListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			BillingClient billingClient = Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConsumeParams p = Java.Lang.Object.GetObject<ConsumeParams>(native_p0, JniHandleOwnership.DoNotTransfer);
			IConsumeResponseListener p2 = Java.Lang.Object.GetObject<IConsumeResponseListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			billingClient.Consume(p, p2);
		}

		[Register("consumeAsync", "(Lcom/android/billingclient/api/ConsumeParams;Lcom/android/billingclient/api/ConsumeResponseListener;)V", "GetConsume_Lcom_android_billingclient_api_ConsumeParams_Lcom_android_billingclient_api_ConsumeResponseListener_Handler")]
		public abstract void Consume(ConsumeParams p0, IConsumeResponseListener p1);

		private static Delegate GetEndConnectionHandler()
		{
			if ((object)cb_endConnection == null)
			{
				cb_endConnection = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_EndConnection));
			}
			return cb_endConnection;
		}

		private static void n_EndConnection(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndConnection();
		}

		[Register("endConnection", "()V", "GetEndConnectionHandler")]
		public abstract void EndConnection();

		private static Delegate GetIsFeatureSupported_Ljava_lang_String_Handler()
		{
			if ((object)cb_isFeatureSupported_Ljava_lang_String_ == null)
			{
				cb_isFeatureSupported_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_IsFeatureSupported_Ljava_lang_String_));
			}
			return cb_isFeatureSupported_Ljava_lang_String_;
		}

		private static IntPtr n_IsFeatureSupported_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			BillingClient billingClient = Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(billingClient.IsFeatureSupported(p));
		}

		[Register("isFeatureSupported", "(Ljava/lang/String;)Lcom/android/billingclient/api/BillingResult;", "GetIsFeatureSupported_Ljava_lang_String_Handler")]
		public abstract BillingResult IsFeatureSupported(string p0);

		private static Delegate GetLaunchBillingFlow_Landroid_app_Activity_Lcom_android_billingclient_api_BillingFlowParams_Handler()
		{
			if ((object)cb_launchBillingFlow_Landroid_app_Activity_Lcom_android_billingclient_api_BillingFlowParams_ == null)
			{
				cb_launchBillingFlow_Landroid_app_Activity_Lcom_android_billingclient_api_BillingFlowParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_LaunchBillingFlow_Landroid_app_Activity_Lcom_android_billingclient_api_BillingFlowParams_));
			}
			return cb_launchBillingFlow_Landroid_app_Activity_Lcom_android_billingclient_api_BillingFlowParams_;
		}

		private static IntPtr n_LaunchBillingFlow_Landroid_app_Activity_Lcom_android_billingclient_api_BillingFlowParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			BillingClient billingClient = Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
			BillingFlowParams p2 = Java.Lang.Object.GetObject<BillingFlowParams>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(billingClient.LaunchBillingFlow(p, p2));
		}

		[Register("launchBillingFlow", "(Landroid/app/Activity;Lcom/android/billingclient/api/BillingFlowParams;)Lcom/android/billingclient/api/BillingResult;", "GetLaunchBillingFlow_Landroid_app_Activity_Lcom_android_billingclient_api_BillingFlowParams_Handler")]
		public abstract BillingResult LaunchBillingFlow(Activity p0, BillingFlowParams p1);

		private static Delegate GetLaunchPriceChangeConfirmationFlow_Landroid_app_Activity_Lcom_android_billingclient_api_PriceChangeFlowParams_Lcom_android_billingclient_api_PriceChangeConfirmationListener_Handler()
		{
			if ((object)cb_launchPriceChangeConfirmationFlow_Landroid_app_Activity_Lcom_android_billingclient_api_PriceChangeFlowParams_Lcom_android_billingclient_api_PriceChangeConfirmationListener_ == null)
			{
				cb_launchPriceChangeConfirmationFlow_Landroid_app_Activity_Lcom_android_billingclient_api_PriceChangeFlowParams_Lcom_android_billingclient_api_PriceChangeConfirmationListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_LaunchPriceChangeConfirmationFlow_Landroid_app_Activity_Lcom_android_billingclient_api_PriceChangeFlowParams_Lcom_android_billingclient_api_PriceChangeConfirmationListener_));
			}
			return cb_launchPriceChangeConfirmationFlow_Landroid_app_Activity_Lcom_android_billingclient_api_PriceChangeFlowParams_Lcom_android_billingclient_api_PriceChangeConfirmationListener_;
		}

		private static void n_LaunchPriceChangeConfirmationFlow_Landroid_app_Activity_Lcom_android_billingclient_api_PriceChangeFlowParams_Lcom_android_billingclient_api_PriceChangeConfirmationListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			BillingClient billingClient = Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
			PriceChangeFlowParams p2 = Java.Lang.Object.GetObject<PriceChangeFlowParams>(native_p1, JniHandleOwnership.DoNotTransfer);
			IPriceChangeConfirmationListener p3 = Java.Lang.Object.GetObject<IPriceChangeConfirmationListener>(native_p2, JniHandleOwnership.DoNotTransfer);
			billingClient.LaunchPriceChangeConfirmationFlow(p, p2, p3);
		}

		[Register("launchPriceChangeConfirmationFlow", "(Landroid/app/Activity;Lcom/android/billingclient/api/PriceChangeFlowParams;Lcom/android/billingclient/api/PriceChangeConfirmationListener;)V", "GetLaunchPriceChangeConfirmationFlow_Landroid_app_Activity_Lcom_android_billingclient_api_PriceChangeFlowParams_Lcom_android_billingclient_api_PriceChangeConfirmationListener_Handler")]
		public abstract void LaunchPriceChangeConfirmationFlow(Activity p0, PriceChangeFlowParams p1, IPriceChangeConfirmationListener p2);

		[Register("newBuilder", "(Landroid/content/Context;)Lcom/android/billingclient/api/BillingClient$Builder;", "")]
		public unsafe static Builder NewBuilder(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.(Landroid/content/Context;)Lcom/android/billingclient/api/BillingClient$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetQueryPurchaseHistory_Ljava_lang_String_Lcom_android_billingclient_api_PurchaseHistoryResponseListener_Handler()
		{
			if ((object)cb_queryPurchaseHistoryAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchaseHistoryResponseListener_ == null)
			{
				cb_queryPurchaseHistoryAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchaseHistoryResponseListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_QueryPurchaseHistory_Ljava_lang_String_Lcom_android_billingclient_api_PurchaseHistoryResponseListener_));
			}
			return cb_queryPurchaseHistoryAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchaseHistoryResponseListener_;
		}

		private static void n_QueryPurchaseHistory_Ljava_lang_String_Lcom_android_billingclient_api_PurchaseHistoryResponseListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			BillingClient billingClient = Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			IPurchaseHistoryResponseListener p2 = Java.Lang.Object.GetObject<IPurchaseHistoryResponseListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			billingClient.QueryPurchaseHistory(p, p2);
		}

		[Register("queryPurchaseHistoryAsync", "(Ljava/lang/String;Lcom/android/billingclient/api/PurchaseHistoryResponseListener;)V", "GetQueryPurchaseHistory_Ljava_lang_String_Lcom_android_billingclient_api_PurchaseHistoryResponseListener_Handler")]
		public abstract void QueryPurchaseHistory(string p0, IPurchaseHistoryResponseListener p1);

		[Obsolete]
		private static Delegate GetQueryPurchases_Ljava_lang_String_Handler()
		{
			if ((object)cb_queryPurchases_Ljava_lang_String_ == null)
			{
				cb_queryPurchases_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_QueryPurchases_Ljava_lang_String_));
			}
			return cb_queryPurchases_Ljava_lang_String_;
		}

		[Obsolete]
		private static IntPtr n_QueryPurchases_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			BillingClient billingClient = Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(billingClient.QueryPurchases(p));
		}

		[Register("queryPurchases", "(Ljava/lang/String;)Lcom/android/billingclient/api/Purchase$PurchasesResult;", "GetQueryPurchases_Ljava_lang_String_Handler")]
		public abstract Purchase.PurchasesResult QueryPurchases(string p0);

		private static Delegate GetQueryPurchasesAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchasesResponseListener_Handler()
		{
			if ((object)cb_queryPurchasesAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchasesResponseListener_ == null)
			{
				cb_queryPurchasesAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchasesResponseListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_QueryPurchasesAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchasesResponseListener_));
			}
			return cb_queryPurchasesAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchasesResponseListener_;
		}

		private static void n_QueryPurchasesAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchasesResponseListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			BillingClient billingClient = Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			IPurchasesResponseListener p2 = Java.Lang.Object.GetObject<IPurchasesResponseListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			billingClient.QueryPurchasesAsync(p, p2);
		}

		[Register("queryPurchasesAsync", "(Ljava/lang/String;Lcom/android/billingclient/api/PurchasesResponseListener;)V", "GetQueryPurchasesAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchasesResponseListener_Handler")]
		public abstract void QueryPurchasesAsync(string p0, IPurchasesResponseListener p1);

		private static Delegate GetQuerySkuDetails_Lcom_android_billingclient_api_SkuDetailsParams_Lcom_android_billingclient_api_SkuDetailsResponseListener_Handler()
		{
			if ((object)cb_querySkuDetailsAsync_Lcom_android_billingclient_api_SkuDetailsParams_Lcom_android_billingclient_api_SkuDetailsResponseListener_ == null)
			{
				cb_querySkuDetailsAsync_Lcom_android_billingclient_api_SkuDetailsParams_Lcom_android_billingclient_api_SkuDetailsResponseListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_QuerySkuDetails_Lcom_android_billingclient_api_SkuDetailsParams_Lcom_android_billingclient_api_SkuDetailsResponseListener_));
			}
			return cb_querySkuDetailsAsync_Lcom_android_billingclient_api_SkuDetailsParams_Lcom_android_billingclient_api_SkuDetailsResponseListener_;
		}

		private static void n_QuerySkuDetails_Lcom_android_billingclient_api_SkuDetailsParams_Lcom_android_billingclient_api_SkuDetailsResponseListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			BillingClient billingClient = Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SkuDetailsParams p = Java.Lang.Object.GetObject<SkuDetailsParams>(native_p0, JniHandleOwnership.DoNotTransfer);
			ISkuDetailsResponseListener p2 = Java.Lang.Object.GetObject<ISkuDetailsResponseListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			billingClient.QuerySkuDetails(p, p2);
		}

		[Register("querySkuDetailsAsync", "(Lcom/android/billingclient/api/SkuDetailsParams;Lcom/android/billingclient/api/SkuDetailsResponseListener;)V", "GetQuerySkuDetails_Lcom_android_billingclient_api_SkuDetailsParams_Lcom_android_billingclient_api_SkuDetailsResponseListener_Handler")]
		public abstract void QuerySkuDetails(SkuDetailsParams p0, ISkuDetailsResponseListener p1);

		private static Delegate GetStartConnection_Lcom_android_billingclient_api_BillingClientStateListener_Handler()
		{
			if ((object)cb_startConnection_Lcom_android_billingclient_api_BillingClientStateListener_ == null)
			{
				cb_startConnection_Lcom_android_billingclient_api_BillingClientStateListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StartConnection_Lcom_android_billingclient_api_BillingClientStateListener_));
			}
			return cb_startConnection_Lcom_android_billingclient_api_BillingClientStateListener_;
		}

		private static void n_StartConnection_Lcom_android_billingclient_api_BillingClientStateListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			BillingClient billingClient = Java.Lang.Object.GetObject<BillingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IBillingClientStateListener p = Java.Lang.Object.GetObject<IBillingClientStateListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			billingClient.StartConnection(p);
		}

		[Register("startConnection", "(Lcom/android/billingclient/api/BillingClientStateListener;)V", "GetStartConnection_Lcom_android_billingclient_api_BillingClientStateListener_Handler")]
		public abstract void StartConnection(IBillingClientStateListener p0);
	}
	internal class InternalAcknowledgePurchaseResponseListener : Java.Lang.Object, IAcknowledgePurchaseResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public Action<BillingResult> AcknowledgePurchaseResponseHandler { get; set; }

		public void OnAcknowledgePurchaseResponse(BillingResult result)
		{
			AcknowledgePurchaseResponseHandler?.Invoke(result);
		}
	}
	internal class InternalBillingClientStateListener : Java.Lang.Object, IBillingClientStateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public Action BillingServiceDisconnectedHandler { get; set; }

		public Action<BillingResult> BillingSetupFinishedHandler { get; set; }

		public void OnBillingServiceDisconnected()
		{
			BillingServiceDisconnectedHandler?.Invoke();
		}

		public void OnBillingSetupFinished(BillingResult result)
		{
			BillingSetupFinishedHandler?.Invoke(result);
		}
	}
	internal class InternalConsumeResponseListener : Java.Lang.Object, IConsumeResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public Action<BillingResult, string> ConsumeResponseHandler { get; set; }

		public void OnConsumeResponse(BillingResult result, string str)
		{
			ConsumeResponseHandler?.Invoke(result, str);
		}
	}
	internal class InternalPriceChangeConfirmationListener : Java.Lang.Object, IPriceChangeConfirmationListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public Action<BillingResult> PriceChangeConfirmationHandler { get; set; }

		public void OnPriceChangeConfirmationResult(BillingResult result)
		{
			PriceChangeConfirmationHandler?.Invoke(result);
		}
	}
	internal class InternalPurchaseHistoryResponseListener : Java.Lang.Object, IPurchaseHistoryResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public Action<BillingResult, IList<PurchaseHistoryRecord>> PurchaseHistoryResponseHandler { get; set; }

		public void OnPurchaseHistoryResponse(BillingResult result, IList<PurchaseHistoryRecord> history)
		{
			PurchaseHistoryResponseHandler?.Invoke(result, history);
		}
	}
	internal class InternalPurchasesUpdatedListener : Java.Lang.Object, IPurchasesUpdatedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public Action<BillingResult, IList<Purchase>> PurchasesUpdatedHandler { get; set; }

		public void OnPurchasesUpdated(BillingResult result, IList<Purchase> purchases)
		{
			PurchasesUpdatedHandler?.Invoke(result, purchases);
		}
	}
	internal class InternalSkuDetailsResponseListener : Java.Lang.Object, ISkuDetailsResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public Action<BillingResult, IList<SkuDetails>> SkuDetailsResponseHandler { get; set; }

		public void OnSkuDetailsResponse(BillingResult result, IList<SkuDetails> skuDetails)
		{
			SkuDetailsResponseHandler?.Invoke(result, skuDetails);
		}
	}
	public enum BillingResponseCode
	{
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.BILLING_UNAVAILABLE")]
		BillingUnavailable = 3,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.DEVELOPER_ERROR")]
		DeveloperError = 5,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.ERROR")]
		Error = 6,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.FEATURE_NOT_SUPPORTED")]
		FeatureNotSupported = -2,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.ITEM_ALREADY_OWNED")]
		ItemAlreadyOwned = 7,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.ITEM_NOT_OWNED")]
		ItemNotOwned = 8,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.ITEM_UNAVAILABLE")]
		ItemUnavailable = 4,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.OK")]
		Ok = 0,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.SERVICE_DISCONNECTED")]
		ServiceDisconnected = -1,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.SERVICE_TIMEOUT")]
		ServiceTimeout = -3,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.SERVICE_UNAVAILABLE")]
		ServiceUnavailable = 2,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$BillingResponseCode.USER_CANCELED")]
		UserCancelled = 1
	}
	public enum ChildDirectedTypes
	{
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$ChildDirected.CHILD_DIRECTED")]
		Directed = 1,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$ChildDirected.NOT_CHILD_DIRECTED")]
		NotDirected = 2,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$ChildDirected.UNSPECIFIED")]
		Unspecified = 0
	}
	public enum PurchaseState
	{
		[IntDefinition(null, JniField = "com/android/billingclient/api/Purchase$PurchaseState.PENDING")]
		Pending = 2,
		[IntDefinition(null, JniField = "com/android/billingclient/api/Purchase$PurchaseState.PURCHASED")]
		Purchased = 1,
		[IntDefinition(null, JniField = "com/android/billingclient/api/Purchase$PurchaseState.UNSPECIFIED_STATE")]
		Unspecified = 0
	}
	public enum UnderAgeOfConsentTypes
	{
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$UnderAgeOfConsent.NOT_UNDER_AGE_OF_CONSENT")]
		NotUnderAgeOfConsent = 2,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$UnderAgeOfConsent.UNDER_AGE_OF_CONSENT")]
		UnderAgeOfConsent = 1,
		[IntDefinition(null, JniField = "com/android/billingclient/api/BillingClient$UnderAgeOfConsent.UNSPECIFIED")]
		Unspecified = 0
	}
	[Register("com/android/billingclient/api/AccountIdentifiers", DoNotGenerateAcw = true)]
	public sealed class AccountIdentifiers : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/AccountIdentifiers", typeof(AccountIdentifiers));

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

		public unsafe string ObfuscatedAccountId
		{
			[Register("getObfuscatedAccountId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getObfuscatedAccountId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ObfuscatedProfileId
		{
			[Register("getObfuscatedProfileId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getObfuscatedProfileId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal AccountIdentifiers(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/android/billingclient/api/AcknowledgePurchaseParams", DoNotGenerateAcw = true)]
	public sealed class AcknowledgePurchaseParams : Java.Lang.Object
	{
		[Register("com/android/billingclient/api/AcknowledgePurchaseParams$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/AcknowledgePurchaseParams$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("build", "()Lcom/android/billingclient/api/AcknowledgePurchaseParams;", "")]
			public unsafe AcknowledgePurchaseParams Build()
			{
				return Java.Lang.Object.GetObject<AcknowledgePurchaseParams>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/android/billingclient/api/AcknowledgePurchaseParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setPurchaseToken", "(Ljava/lang/String;)Lcom/android/billingclient/api/AcknowledgePurchaseParams$Builder;", "")]
			public unsafe Builder SetPurchaseToken(string purchaseToken)
			{
				IntPtr intPtr = JNIEnv.NewString(purchaseToken);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPurchaseToken.(Ljava/lang/String;)Lcom/android/billingclient/api/AcknowledgePurchaseParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/AcknowledgePurchaseParams", typeof(AcknowledgePurchaseParams));

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

		public unsafe string PurchaseToken
		{
			[Register("getPurchaseToken", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPurchaseToken.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal AcknowledgePurchaseParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("newBuilder", "()Lcom/android/billingclient/api/AcknowledgePurchaseParams$Builder;", "")]
		public unsafe static Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.()Lcom/android/billingclient/api/AcknowledgePurchaseParams$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/android/billingclient/api/BillingClient", DoNotGenerateAcw = true)]
	internal class BillingClientInvoker : BillingClient
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingClient", typeof(BillingClientInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsReady
		{
			[Register("isReady", "()Z", "GetIsReadyHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isReady.()Z", this, null);
			}
		}

		public BillingClientInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("acknowledgePurchase", "(Lcom/android/billingclient/api/AcknowledgePurchaseParams;Lcom/android/billingclient/api/AcknowledgePurchaseResponseListener;)V", "GetAcknowledgePurchase_Lcom_android_billingclient_api_AcknowledgePurchaseParams_Lcom_android_billingclient_api_AcknowledgePurchaseResponseListener_Handler")]
		public unsafe override void AcknowledgePurchase(AcknowledgePurchaseParams p0, IAcknowledgePurchaseResponseListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("acknowledgePurchase.(Lcom/android/billingclient/api/AcknowledgePurchaseParams;Lcom/android/billingclient/api/AcknowledgePurchaseResponseListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("consumeAsync", "(Lcom/android/billingclient/api/ConsumeParams;Lcom/android/billingclient/api/ConsumeResponseListener;)V", "GetConsume_Lcom_android_billingclient_api_ConsumeParams_Lcom_android_billingclient_api_ConsumeResponseListener_Handler")]
		public unsafe override void Consume(ConsumeParams p0, IConsumeResponseListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("consumeAsync.(Lcom/android/billingclient/api/ConsumeParams;Lcom/android/billingclient/api/ConsumeResponseListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("endConnection", "()V", "GetEndConnectionHandler")]
		public unsafe override void EndConnection()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("endConnection.()V", this, null);
		}

		[Register("isFeatureSupported", "(Ljava/lang/String;)Lcom/android/billingclient/api/BillingResult;", "GetIsFeatureSupported_Ljava_lang_String_Handler")]
		public unsafe override BillingResult IsFeatureSupported(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<BillingResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("isFeatureSupported.(Ljava/lang/String;)Lcom/android/billingclient/api/BillingResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("launchBillingFlow", "(Landroid/app/Activity;Lcom/android/billingclient/api/BillingFlowParams;)Lcom/android/billingclient/api/BillingResult;", "GetLaunchBillingFlow_Landroid_app_Activity_Lcom_android_billingclient_api_BillingFlowParams_Handler")]
		public unsafe override BillingResult LaunchBillingFlow(Activity p0, BillingFlowParams p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<BillingResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("launchBillingFlow.(Landroid/app/Activity;Lcom/android/billingclient/api/BillingFlowParams;)Lcom/android/billingclient/api/BillingResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("launchPriceChangeConfirmationFlow", "(Landroid/app/Activity;Lcom/android/billingclient/api/PriceChangeFlowParams;Lcom/android/billingclient/api/PriceChangeConfirmationListener;)V", "GetLaunchPriceChangeConfirmationFlow_Landroid_app_Activity_Lcom_android_billingclient_api_PriceChangeFlowParams_Lcom_android_billingclient_api_PriceChangeConfirmationListener_Handler")]
		public unsafe override void LaunchPriceChangeConfirmationFlow(Activity p0, PriceChangeFlowParams p1, IPriceChangeConfirmationListener p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("launchPriceChangeConfirmationFlow.(Landroid/app/Activity;Lcom/android/billingclient/api/PriceChangeFlowParams;Lcom/android/billingclient/api/PriceChangeConfirmationListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		[Register("queryPurchaseHistoryAsync", "(Ljava/lang/String;Lcom/android/billingclient/api/PurchaseHistoryResponseListener;)V", "GetQueryPurchaseHistory_Ljava_lang_String_Lcom_android_billingclient_api_PurchaseHistoryResponseListener_Handler")]
		public unsafe override void QueryPurchaseHistory(string p0, IPurchaseHistoryResponseListener p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("queryPurchaseHistoryAsync.(Ljava/lang/String;Lcom/android/billingclient/api/PurchaseHistoryResponseListener;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
			}
		}

		[Obsolete("deprecated")]
		[Register("queryPurchases", "(Ljava/lang/String;)Lcom/android/billingclient/api/Purchase$PurchasesResult;", "GetQueryPurchases_Ljava_lang_String_Handler")]
		public unsafe override Purchase.PurchasesResult QueryPurchases(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Purchase.PurchasesResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("queryPurchases.(Ljava/lang/String;)Lcom/android/billingclient/api/Purchase$PurchasesResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("queryPurchasesAsync", "(Ljava/lang/String;Lcom/android/billingclient/api/PurchasesResponseListener;)V", "GetQueryPurchasesAsync_Ljava_lang_String_Lcom_android_billingclient_api_PurchasesResponseListener_Handler")]
		public unsafe override void QueryPurchasesAsync(string p0, IPurchasesResponseListener p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("queryPurchasesAsync.(Ljava/lang/String;Lcom/android/billingclient/api/PurchasesResponseListener;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
			}
		}

		[Register("querySkuDetailsAsync", "(Lcom/android/billingclient/api/SkuDetailsParams;Lcom/android/billingclient/api/SkuDetailsResponseListener;)V", "GetQuerySkuDetails_Lcom_android_billingclient_api_SkuDetailsParams_Lcom_android_billingclient_api_SkuDetailsResponseListener_Handler")]
		public unsafe override void QuerySkuDetails(SkuDetailsParams p0, ISkuDetailsResponseListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("querySkuDetailsAsync.(Lcom/android/billingclient/api/SkuDetailsParams;Lcom/android/billingclient/api/SkuDetailsResponseListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("startConnection", "(Lcom/android/billingclient/api/BillingClientStateListener;)V", "GetStartConnection_Lcom_android_billingclient_api_BillingClientStateListener_Handler")]
		public unsafe override void StartConnection(IBillingClientStateListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("startConnection.(Lcom/android/billingclient/api/BillingClientStateListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/android/billingclient/api/BillingFlowParams", DoNotGenerateAcw = true)]
	public class BillingFlowParams : Java.Lang.Object
	{
		[Register("com/android/billingclient/api/BillingFlowParams$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingFlowParams$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setObfuscatedAccountId_Ljava_lang_String_;

			private static Delegate cb_setObfuscatedProfileId_Ljava_lang_String_;

			private static Delegate cb_setSkuDetails_Lcom_android_billingclient_api_SkuDetails_;

			private static Delegate cb_setSubscriptionUpdateParams_Lcom_android_billingclient_api_BillingFlowParams_SubscriptionUpdateParams_;

			private static Delegate cb_setVrPurchaseFlow_Z;

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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
			}

			[Register("build", "()Lcom/android/billingclient/api/BillingFlowParams;", "GetBuildHandler")]
			public unsafe virtual BillingFlowParams Build()
			{
				return Java.Lang.Object.GetObject<BillingFlowParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/android/billingclient/api/BillingFlowParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetObfuscatedAccountId_Ljava_lang_String_Handler()
			{
				if ((object)cb_setObfuscatedAccountId_Ljava_lang_String_ == null)
				{
					cb_setObfuscatedAccountId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetObfuscatedAccountId_Ljava_lang_String_));
				}
				return cb_setObfuscatedAccountId_Ljava_lang_String_;
			}

			private static IntPtr n_SetObfuscatedAccountId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_obfuscatedAccountid)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string obfuscatedAccountId = JNIEnv.GetString(native_obfuscatedAccountid, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetObfuscatedAccountId(obfuscatedAccountId));
			}

			[Register("setObfuscatedAccountId", "(Ljava/lang/String;)Lcom/android/billingclient/api/BillingFlowParams$Builder;", "GetSetObfuscatedAccountId_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetObfuscatedAccountId(string obfuscatedAccountid)
			{
				IntPtr intPtr = JNIEnv.NewString(obfuscatedAccountid);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setObfuscatedAccountId.(Ljava/lang/String;)Lcom/android/billingclient/api/BillingFlowParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetObfuscatedProfileId_Ljava_lang_String_Handler()
			{
				if ((object)cb_setObfuscatedProfileId_Ljava_lang_String_ == null)
				{
					cb_setObfuscatedProfileId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetObfuscatedProfileId_Ljava_lang_String_));
				}
				return cb_setObfuscatedProfileId_Ljava_lang_String_;
			}

			private static IntPtr n_SetObfuscatedProfileId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_obfuscatedProfileId)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string obfuscatedProfileId = JNIEnv.GetString(native_obfuscatedProfileId, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetObfuscatedProfileId(obfuscatedProfileId));
			}

			[Register("setObfuscatedProfileId", "(Ljava/lang/String;)Lcom/android/billingclient/api/BillingFlowParams$Builder;", "GetSetObfuscatedProfileId_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetObfuscatedProfileId(string obfuscatedProfileId)
			{
				IntPtr intPtr = JNIEnv.NewString(obfuscatedProfileId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setObfuscatedProfileId.(Ljava/lang/String;)Lcom/android/billingclient/api/BillingFlowParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetSkuDetails_Lcom_android_billingclient_api_SkuDetails_Handler()
			{
				if ((object)cb_setSkuDetails_Lcom_android_billingclient_api_SkuDetails_ == null)
				{
					cb_setSkuDetails_Lcom_android_billingclient_api_SkuDetails_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSkuDetails_Lcom_android_billingclient_api_SkuDetails_));
				}
				return cb_setSkuDetails_Lcom_android_billingclient_api_SkuDetails_;
			}

			private static IntPtr n_SetSkuDetails_Lcom_android_billingclient_api_SkuDetails_(IntPtr jnienv, IntPtr native__this, IntPtr native_skuDetails)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SkuDetails skuDetails = Java.Lang.Object.GetObject<SkuDetails>(native_skuDetails, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSkuDetails(skuDetails));
			}

			[Register("setSkuDetails", "(Lcom/android/billingclient/api/SkuDetails;)Lcom/android/billingclient/api/BillingFlowParams$Builder;", "GetSetSkuDetails_Lcom_android_billingclient_api_SkuDetails_Handler")]
			public unsafe virtual Builder SetSkuDetails(SkuDetails skuDetails)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(skuDetails?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSkuDetails.(Lcom/android/billingclient/api/SkuDetails;)Lcom/android/billingclient/api/BillingFlowParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(skuDetails);
				}
			}

			private static Delegate GetSetSubscriptionUpdateParams_Lcom_android_billingclient_api_BillingFlowParams_SubscriptionUpdateParams_Handler()
			{
				if ((object)cb_setSubscriptionUpdateParams_Lcom_android_billingclient_api_BillingFlowParams_SubscriptionUpdateParams_ == null)
				{
					cb_setSubscriptionUpdateParams_Lcom_android_billingclient_api_BillingFlowParams_SubscriptionUpdateParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSubscriptionUpdateParams_Lcom_android_billingclient_api_BillingFlowParams_SubscriptionUpdateParams_));
				}
				return cb_setSubscriptionUpdateParams_Lcom_android_billingclient_api_BillingFlowParams_SubscriptionUpdateParams_;
			}

			private static IntPtr n_SetSubscriptionUpdateParams_Lcom_android_billingclient_api_BillingFlowParams_SubscriptionUpdateParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_subscriptionUpdateParams)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SubscriptionUpdateParams subscriptionUpdateParams = Java.Lang.Object.GetObject<SubscriptionUpdateParams>(native_subscriptionUpdateParams, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSubscriptionUpdateParams(subscriptionUpdateParams));
			}

			[Register("setSubscriptionUpdateParams", "(Lcom/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams;)Lcom/android/billingclient/api/BillingFlowParams$Builder;", "GetSetSubscriptionUpdateParams_Lcom_android_billingclient_api_BillingFlowParams_SubscriptionUpdateParams_Handler")]
			public unsafe virtual Builder SetSubscriptionUpdateParams(SubscriptionUpdateParams subscriptionUpdateParams)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(subscriptionUpdateParams?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSubscriptionUpdateParams.(Lcom/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams;)Lcom/android/billingclient/api/BillingFlowParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(subscriptionUpdateParams);
				}
			}

			private static Delegate GetSetVrPurchaseFlow_ZHandler()
			{
				if ((object)cb_setVrPurchaseFlow_Z == null)
				{
					cb_setVrPurchaseFlow_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetVrPurchaseFlow_Z));
				}
				return cb_setVrPurchaseFlow_Z;
			}

			private static IntPtr n_SetVrPurchaseFlow_Z(IntPtr jnienv, IntPtr native__this, bool isVrPurchaseFlow)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVrPurchaseFlow(isVrPurchaseFlow));
			}

			[Register("setVrPurchaseFlow", "(Z)Lcom/android/billingclient/api/BillingFlowParams$Builder;", "GetSetVrPurchaseFlow_ZHandler")]
			public unsafe virtual Builder SetVrPurchaseFlow(bool isVrPurchaseFlow)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(isVrPurchaseFlow);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setVrPurchaseFlow.(Z)Lcom/android/billingclient/api/BillingFlowParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/android/billingclient/api/BillingFlowParams$ProrationMode", DoNotGenerateAcw = true)]
		public abstract class ProrationMode : Java.Lang.Object
		{
			[Register("DEFERRED")]
			public const int Deferred = 4;

			[Register("IMMEDIATE_AND_CHARGE_FULL_PRICE")]
			public const int ImmediateAndChargeFullPrice = 5;

			[Register("IMMEDIATE_AND_CHARGE_PRORATED_PRICE")]
			public const int ImmediateAndChargeProratedPrice = 2;

			[Register("IMMEDIATE_WITHOUT_PRORATION")]
			public const int ImmediateWithoutProration = 3;

			[Register("IMMEDIATE_WITH_TIME_PRORATION")]
			public const int ImmediateWithTimeProration = 1;

			[Register("UNKNOWN_SUBSCRIPTION_UPGRADE_DOWNGRADE_POLICY")]
			public const int UnknownSubscriptionUpgradeDowngradePolicy = 0;

			internal ProrationMode()
			{
			}
		}

		[Register("com/android/billingclient/api/BillingFlowParams$ProrationMode", DoNotGenerateAcw = true)]
		[Obsolete("Use the 'ProrationMode' type. This type will be removed in a future release.", true)]
		public abstract class ProrationModeConsts : ProrationMode
		{
			private ProrationModeConsts()
			{
			}
		}

		[Register("com/android/billingclient/api/BillingFlowParams$ProrationMode", "", "Android.BillingClient.Api.BillingFlowParams/IProrationModeInvoker")]
		public interface IProrationMode : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/android/billingclient/api/BillingFlowParams$ProrationMode", DoNotGenerateAcw = true)]
		internal class IProrationModeInvoker : Java.Lang.Object, IProrationMode, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingFlowParams$ProrationMode", typeof(IProrationModeInvoker));

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

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IProrationMode GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IProrationMode>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.BillingFlowParams.ProrationMode'.");
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

			public IProrationModeInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IProrationMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				IProrationMode prorationMode = Java.Lang.Object.GetObject<IProrationMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return prorationMode.Equals(obj);
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
				return Java.Lang.Object.GetObject<IProrationMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IProrationMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

		[Register("com/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams", DoNotGenerateAcw = true)]
		public class SubscriptionUpdateParams : Java.Lang.Object
		{
			[Register("com/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams$Builder", DoNotGenerateAcw = true)]
			public class Builder : Java.Lang.Object
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams$Builder", typeof(Builder));

				private static Delegate cb_build;

				private static Delegate cb_setOldSkuPurchaseToken_Ljava_lang_String_;

				private static Delegate cb_setReplaceSkusProrationMode_I;

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
					return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
				}

				[Register("build", "()Lcom/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams;", "GetBuildHandler")]
				public unsafe virtual SubscriptionUpdateParams Build()
				{
					return Java.Lang.Object.GetObject<SubscriptionUpdateParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}

				private static Delegate GetSetOldSkuPurchaseToken_Ljava_lang_String_Handler()
				{
					if ((object)cb_setOldSkuPurchaseToken_Ljava_lang_String_ == null)
					{
						cb_setOldSkuPurchaseToken_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOldSkuPurchaseToken_Ljava_lang_String_));
					}
					return cb_setOldSkuPurchaseToken_Ljava_lang_String_;
				}

				private static IntPtr n_SetOldSkuPurchaseToken_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_purchaseToken)
				{
					Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					string oldSkuPurchaseToken = JNIEnv.GetString(native_purchaseToken, JniHandleOwnership.DoNotTransfer);
					return JNIEnv.ToLocalJniHandle(builder.SetOldSkuPurchaseToken(oldSkuPurchaseToken));
				}

				[Register("setOldSkuPurchaseToken", "(Ljava/lang/String;)Lcom/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams$Builder;", "GetSetOldSkuPurchaseToken_Ljava_lang_String_Handler")]
				public unsafe virtual Builder SetOldSkuPurchaseToken(string purchaseToken)
				{
					IntPtr intPtr = JNIEnv.NewString(purchaseToken);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOldSkuPurchaseToken.(Ljava/lang/String;)Lcom/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}

				private static Delegate GetSetReplaceSkusProrationMode_IHandler()
				{
					if ((object)cb_setReplaceSkusProrationMode_I == null)
					{
						cb_setReplaceSkusProrationMode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetReplaceSkusProrationMode_I));
					}
					return cb_setReplaceSkusProrationMode_I;
				}

				private static IntPtr n_SetReplaceSkusProrationMode_I(IntPtr jnienv, IntPtr native__this, int replaceSkusProrationMode)
				{
					return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetReplaceSkusProrationMode(replaceSkusProrationMode));
				}

				[Register("setReplaceSkusProrationMode", "(I)Lcom/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams$Builder;", "GetSetReplaceSkusProrationMode_IHandler")]
				public unsafe virtual Builder SetReplaceSkusProrationMode(int replaceSkusProrationMode)
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(replaceSkusProrationMode);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setReplaceSkusProrationMode.(I)Lcom/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams", typeof(SubscriptionUpdateParams));

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

			protected SubscriptionUpdateParams(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("newBuilder", "()Lcom/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams$Builder;", "")]
			public unsafe static Builder NewBuilder()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.()Lcom/android/billingclient/api/BillingFlowParams$SubscriptionUpdateParams$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("EXTRA_PARAM_KEY_ACCOUNT_ID")]
		public const string ExtraParamKeyAccountId = "accountId";

		[Register("EXTRA_PARAM_KEY_OLD_SKUS")]
		public const string ExtraParamKeyOldSkus = "skusToReplace";

		[Register("EXTRA_PARAM_KEY_OLD_SKU_PURCHASE_TOKEN")]
		public const string ExtraParamKeyOldSkuPurchaseToken = "oldSkuPurchaseToken";

		[Register("EXTRA_PARAM_KEY_REPLACE_SKUS_PRORATION_MODE")]
		public const string ExtraParamKeyReplaceSkusProrationMode = "prorationMode";

		[Register("EXTRA_PARAM_KEY_VR")]
		public const string ExtraParamKeyVr = "vr";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingFlowParams", typeof(BillingFlowParams));

		private static Delegate cb_getVrPurchaseFlow;

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

		public unsafe virtual bool VrPurchaseFlow
		{
			[Register("getVrPurchaseFlow", "()Z", "GetGetVrPurchaseFlowHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getVrPurchaseFlow.()Z", this, null);
			}
		}

		protected BillingFlowParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetVrPurchaseFlowHandler()
		{
			if ((object)cb_getVrPurchaseFlow == null)
			{
				cb_getVrPurchaseFlow = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetVrPurchaseFlow));
			}
			return cb_getVrPurchaseFlow;
		}

		private static bool n_GetVrPurchaseFlow(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<BillingFlowParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VrPurchaseFlow;
		}

		[Register("newBuilder", "()Lcom/android/billingclient/api/BillingFlowParams$Builder;", "")]
		public unsafe static Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.()Lcom/android/billingclient/api/BillingFlowParams$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zzb", "()I", "")]
		public unsafe int Zzb()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("zzb.()I", this, null);
		}

		[Register("zzf", "()Ljava/lang/String;", "")]
		public unsafe string Zzf()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zzf.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zzg", "()Ljava/lang/String;", "")]
		public unsafe string Zzg()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zzg.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zzh", "()Ljava/lang/String;", "")]
		public unsafe string Zzh()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zzh.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zzj", "()Ljava/util/ArrayList;", "")]
		public unsafe IList<SkuDetails> Zzj()
		{
			return JavaList<SkuDetails>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zzj.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/android/billingclient/api/BillingResult", DoNotGenerateAcw = true)]
	public sealed class BillingResult : Java.Lang.Object
	{
		[Register("com/android/billingclient/api/BillingResult$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingResult$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setDebugMessage_Ljava_lang_String_;

			private static Delegate cb_setResponseCode_I;

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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
			}

			[Register("build", "()Lcom/android/billingclient/api/BillingResult;", "GetBuildHandler")]
			public unsafe virtual BillingResult Build()
			{
				return Java.Lang.Object.GetObject<BillingResult>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/android/billingclient/api/BillingResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetDebugMessage_Ljava_lang_String_Handler()
			{
				if ((object)cb_setDebugMessage_Ljava_lang_String_ == null)
				{
					cb_setDebugMessage_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetDebugMessage_Ljava_lang_String_));
				}
				return cb_setDebugMessage_Ljava_lang_String_;
			}

			private static IntPtr n_SetDebugMessage_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_debugMessage)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string debugMessage = JNIEnv.GetString(native_debugMessage, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetDebugMessage(debugMessage));
			}

			[Register("setDebugMessage", "(Ljava/lang/String;)Lcom/android/billingclient/api/BillingResult$Builder;", "GetSetDebugMessage_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetDebugMessage(string debugMessage)
			{
				IntPtr intPtr = JNIEnv.NewString(debugMessage);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDebugMessage.(Ljava/lang/String;)Lcom/android/billingclient/api/BillingResult$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetResponseCode_IHandler()
			{
				if ((object)cb_setResponseCode_I == null)
				{
					cb_setResponseCode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetResponseCode_I));
				}
				return cb_setResponseCode_I;
			}

			private static IntPtr n_SetResponseCode_I(IntPtr jnienv, IntPtr native__this, int responseCode)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetResponseCode(responseCode));
			}

			[Register("setResponseCode", "(I)Lcom/android/billingclient/api/BillingResult$Builder;", "GetSetResponseCode_IHandler")]
			public unsafe virtual Builder SetResponseCode(int responseCode)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(responseCode);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setResponseCode.(I)Lcom/android/billingclient/api/BillingResult$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingResult", typeof(BillingResult));

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

		public unsafe string DebugMessage
		{
			[Register("getDebugMessage", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDebugMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe BillingResponseCode ResponseCode
		{
			[Register("getResponseCode", "()I", "")]
			get
			{
				return (BillingResponseCode)_members.InstanceMethods.InvokeAbstractInt32Method("getResponseCode.()I", this, null);
			}
		}

		internal BillingResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BillingResult()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("newBuilder", "()Lcom/android/billingclient/api/BillingResult$Builder;", "")]
		public unsafe static Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.()Lcom/android/billingclient/api/BillingResult$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/android/billingclient/api/ConsumeParams", DoNotGenerateAcw = true)]
	public sealed class ConsumeParams : Java.Lang.Object
	{
		[Register("com/android/billingclient/api/ConsumeParams$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/ConsumeParams$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("build", "()Lcom/android/billingclient/api/ConsumeParams;", "")]
			public unsafe ConsumeParams Build()
			{
				return Java.Lang.Object.GetObject<ConsumeParams>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/android/billingclient/api/ConsumeParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setPurchaseToken", "(Ljava/lang/String;)Lcom/android/billingclient/api/ConsumeParams$Builder;", "")]
			public unsafe Builder SetPurchaseToken(string purchaseToken)
			{
				IntPtr intPtr = JNIEnv.NewString(purchaseToken);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPurchaseToken.(Ljava/lang/String;)Lcom/android/billingclient/api/ConsumeParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/ConsumeParams", typeof(ConsumeParams));

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

		public unsafe string PurchaseToken
		{
			[Register("getPurchaseToken", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPurchaseToken.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ConsumeParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("newBuilder", "()Lcom/android/billingclient/api/ConsumeParams$Builder;", "")]
		public unsafe static Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.()Lcom/android/billingclient/api/ConsumeParams$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/android/billingclient/api/AcknowledgePurchaseResponseListener", "", "Android.BillingClient.Api.IAcknowledgePurchaseResponseListenerInvoker")]
	public interface IAcknowledgePurchaseResponseListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onAcknowledgePurchaseResponse", "(Lcom/android/billingclient/api/BillingResult;)V", "GetOnAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_Handler:Android.BillingClient.Api.IAcknowledgePurchaseResponseListenerInvoker, Xamarin.Android.Google.BillingClient")]
		void OnAcknowledgePurchaseResponse(BillingResult p0);
	}
	[Register("com/android/billingclient/api/AcknowledgePurchaseResponseListener", DoNotGenerateAcw = true)]
	internal class IAcknowledgePurchaseResponseListenerInvoker : Java.Lang.Object, IAcknowledgePurchaseResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/AcknowledgePurchaseResponseListener", typeof(IAcknowledgePurchaseResponseListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_;

		private IntPtr id_onAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_;

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

		public static IAcknowledgePurchaseResponseListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IAcknowledgePurchaseResponseListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.AcknowledgePurchaseResponseListener'.");
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

		public IAcknowledgePurchaseResponseListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_Handler()
		{
			if ((object)cb_onAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_ == null)
			{
				cb_onAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_));
			}
			return cb_onAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_;
		}

		private static void n_OnAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IAcknowledgePurchaseResponseListener acknowledgePurchaseResponseListener = Java.Lang.Object.GetObject<IAcknowledgePurchaseResponseListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BillingResult p = Java.Lang.Object.GetObject<BillingResult>(native_p0, JniHandleOwnership.DoNotTransfer);
			acknowledgePurchaseResponseListener.OnAcknowledgePurchaseResponse(p);
		}

		public unsafe void OnAcknowledgePurchaseResponse(BillingResult p0)
		{
			if (id_onAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_ == IntPtr.Zero)
			{
				id_onAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_ = JNIEnv.GetMethodID(class_ref, "onAcknowledgePurchaseResponse", "(Lcom/android/billingclient/api/BillingResult;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onAcknowledgePurchaseResponse_Lcom_android_billingclient_api_BillingResult_, ptr);
		}
	}
	public class AcknowledgePurchaseResponseEventArgs : EventArgs
	{
		private BillingResult p0;

		public BillingResult P0 => p0;

		public AcknowledgePurchaseResponseEventArgs(BillingResult p0)
		{
			this.p0 = p0;
		}
	}
	[Register("mono/com/android/billingclient/api/AcknowledgePurchaseResponseListenerImplementor")]
	internal sealed class IAcknowledgePurchaseResponseListenerImplementor : Java.Lang.Object, IAcknowledgePurchaseResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<AcknowledgePurchaseResponseEventArgs> Handler;

		public IAcknowledgePurchaseResponseListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/android/billingclient/api/AcknowledgePurchaseResponseListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnAcknowledgePurchaseResponse(BillingResult p0)
		{
			Handler?.Invoke(sender, new AcknowledgePurchaseResponseEventArgs(p0));
		}

		internal static bool __IsEmpty(IAcknowledgePurchaseResponseListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
	[Register("com/android/billingclient/api/BillingClientStateListener", "", "Android.BillingClient.Api.IBillingClientStateListenerInvoker")]
	public interface IBillingClientStateListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onBillingServiceDisconnected", "()V", "GetOnBillingServiceDisconnectedHandler:Android.BillingClient.Api.IBillingClientStateListenerInvoker, Xamarin.Android.Google.BillingClient")]
		void OnBillingServiceDisconnected();

		[Register("onBillingSetupFinished", "(Lcom/android/billingclient/api/BillingResult;)V", "GetOnBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_Handler:Android.BillingClient.Api.IBillingClientStateListenerInvoker, Xamarin.Android.Google.BillingClient")]
		void OnBillingSetupFinished(BillingResult p0);
	}
	[Register("com/android/billingclient/api/BillingClientStateListener", DoNotGenerateAcw = true)]
	internal class IBillingClientStateListenerInvoker : Java.Lang.Object, IBillingClientStateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/BillingClientStateListener", typeof(IBillingClientStateListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onBillingServiceDisconnected;

		private IntPtr id_onBillingServiceDisconnected;

		private static Delegate cb_onBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_;

		private IntPtr id_onBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_;

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

		public static IBillingClientStateListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBillingClientStateListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.BillingClientStateListener'.");
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

		public IBillingClientStateListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnBillingServiceDisconnectedHandler()
		{
			if ((object)cb_onBillingServiceDisconnected == null)
			{
				cb_onBillingServiceDisconnected = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnBillingServiceDisconnected));
			}
			return cb_onBillingServiceDisconnected;
		}

		private static void n_OnBillingServiceDisconnected(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IBillingClientStateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBillingServiceDisconnected();
		}

		public void OnBillingServiceDisconnected()
		{
			if (id_onBillingServiceDisconnected == IntPtr.Zero)
			{
				id_onBillingServiceDisconnected = JNIEnv.GetMethodID(class_ref, "onBillingServiceDisconnected", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onBillingServiceDisconnected);
		}

		private static Delegate GetOnBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_Handler()
		{
			if ((object)cb_onBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_ == null)
			{
				cb_onBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_));
			}
			return cb_onBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_;
		}

		private static void n_OnBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IBillingClientStateListener billingClientStateListener = Java.Lang.Object.GetObject<IBillingClientStateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BillingResult p = Java.Lang.Object.GetObject<BillingResult>(native_p0, JniHandleOwnership.DoNotTransfer);
			billingClientStateListener.OnBillingSetupFinished(p);
		}

		public unsafe void OnBillingSetupFinished(BillingResult p0)
		{
			if (id_onBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_ == IntPtr.Zero)
			{
				id_onBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_ = JNIEnv.GetMethodID(class_ref, "onBillingSetupFinished", "(Lcom/android/billingclient/api/BillingResult;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onBillingSetupFinished_Lcom_android_billingclient_api_BillingResult_, ptr);
		}
	}
	public class BillingSetupFinishedEventArgs : EventArgs
	{
		private BillingResult p0;

		public BillingResult P0 => p0;

		public BillingSetupFinishedEventArgs(BillingResult p0)
		{
			this.p0 = p0;
		}
	}
	[Register("mono/com/android/billingclient/api/BillingClientStateListenerImplementor")]
	internal sealed class IBillingClientStateListenerImplementor : Java.Lang.Object, IBillingClientStateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler OnBillingServiceDisconnectedHandler;

		public EventHandler<BillingSetupFinishedEventArgs> OnBillingSetupFinishedHandler;

		public IBillingClientStateListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/android/billingclient/api/BillingClientStateListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnBillingServiceDisconnected()
		{
			OnBillingServiceDisconnectedHandler?.Invoke(sender, new EventArgs());
		}

		public void OnBillingSetupFinished(BillingResult p0)
		{
			OnBillingSetupFinishedHandler?.Invoke(sender, new BillingSetupFinishedEventArgs(p0));
		}

		internal static bool __IsEmpty(IBillingClientStateListenerImplementor value)
		{
			if (value.OnBillingServiceDisconnectedHandler == null)
			{
				return value.OnBillingSetupFinishedHandler == null;
			}
			return false;
		}
	}
	[Register("com/android/billingclient/api/ConsumeResponseListener", "", "Android.BillingClient.Api.IConsumeResponseListenerInvoker")]
	public interface IConsumeResponseListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onConsumeResponse", "(Lcom/android/billingclient/api/BillingResult;Ljava/lang/String;)V", "GetOnConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_Handler:Android.BillingClient.Api.IConsumeResponseListenerInvoker, Xamarin.Android.Google.BillingClient")]
		void OnConsumeResponse(BillingResult p0, string p1);
	}
	[Register("com/android/billingclient/api/ConsumeResponseListener", DoNotGenerateAcw = true)]
	internal class IConsumeResponseListenerInvoker : Java.Lang.Object, IConsumeResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/ConsumeResponseListener", typeof(IConsumeResponseListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_;

		private IntPtr id_onConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_;

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

		public static IConsumeResponseListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IConsumeResponseListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.ConsumeResponseListener'.");
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

		public IConsumeResponseListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_Handler()
		{
			if ((object)cb_onConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_ == null)
			{
				cb_onConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_));
			}
			return cb_onConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_;
		}

		private static void n_OnConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IConsumeResponseListener consumeResponseListener = Java.Lang.Object.GetObject<IConsumeResponseListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BillingResult p = Java.Lang.Object.GetObject<BillingResult>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			consumeResponseListener.OnConsumeResponse(p, p2);
		}

		public unsafe void OnConsumeResponse(BillingResult p0, string p1)
		{
			if (id_onConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onConsumeResponse", "(Lcom/android/billingclient/api/BillingResult;Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onConsumeResponse_Lcom_android_billingclient_api_BillingResult_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	public class ConsumeResponseEventArgs : EventArgs
	{
		private BillingResult p0;

		private string p1;

		public BillingResult P0 => p0;

		public string P1 => p1;

		public ConsumeResponseEventArgs(BillingResult p0, string p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}
	[Register("mono/com/android/billingclient/api/ConsumeResponseListenerImplementor")]
	internal sealed class IConsumeResponseListenerImplementor : Java.Lang.Object, IConsumeResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<ConsumeResponseEventArgs> Handler;

		public IConsumeResponseListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/android/billingclient/api/ConsumeResponseListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnConsumeResponse(BillingResult p0, string p1)
		{
			Handler?.Invoke(sender, new ConsumeResponseEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(IConsumeResponseListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
	[Register("com/android/billingclient/api/PriceChangeConfirmationListener", "", "Android.BillingClient.Api.IPriceChangeConfirmationListenerInvoker")]
	public interface IPriceChangeConfirmationListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onPriceChangeConfirmationResult", "(Lcom/android/billingclient/api/BillingResult;)V", "GetOnPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_Handler:Android.BillingClient.Api.IPriceChangeConfirmationListenerInvoker, Xamarin.Android.Google.BillingClient")]
		void OnPriceChangeConfirmationResult(BillingResult p0);
	}
	[Register("com/android/billingclient/api/PriceChangeConfirmationListener", DoNotGenerateAcw = true)]
	internal class IPriceChangeConfirmationListenerInvoker : Java.Lang.Object, IPriceChangeConfirmationListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/PriceChangeConfirmationListener", typeof(IPriceChangeConfirmationListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_;

		private IntPtr id_onPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_;

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

		public static IPriceChangeConfirmationListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPriceChangeConfirmationListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.PriceChangeConfirmationListener'.");
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

		public IPriceChangeConfirmationListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_Handler()
		{
			if ((object)cb_onPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_ == null)
			{
				cb_onPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_));
			}
			return cb_onPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_;
		}

		private static void n_OnPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IPriceChangeConfirmationListener priceChangeConfirmationListener = Java.Lang.Object.GetObject<IPriceChangeConfirmationListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BillingResult p = Java.Lang.Object.GetObject<BillingResult>(native_p0, JniHandleOwnership.DoNotTransfer);
			priceChangeConfirmationListener.OnPriceChangeConfirmationResult(p);
		}

		public unsafe void OnPriceChangeConfirmationResult(BillingResult p0)
		{
			if (id_onPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_ == IntPtr.Zero)
			{
				id_onPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_ = JNIEnv.GetMethodID(class_ref, "onPriceChangeConfirmationResult", "(Lcom/android/billingclient/api/BillingResult;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPriceChangeConfirmationResult_Lcom_android_billingclient_api_BillingResult_, ptr);
		}
	}
	public class PriceChangeConfirmationEventArgs : EventArgs
	{
		private BillingResult p0;

		public BillingResult P0 => p0;

		public PriceChangeConfirmationEventArgs(BillingResult p0)
		{
			this.p0 = p0;
		}
	}
	[Register("mono/com/android/billingclient/api/PriceChangeConfirmationListenerImplementor")]
	internal sealed class IPriceChangeConfirmationListenerImplementor : Java.Lang.Object, IPriceChangeConfirmationListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<PriceChangeConfirmationEventArgs> Handler;

		public IPriceChangeConfirmationListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/android/billingclient/api/PriceChangeConfirmationListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnPriceChangeConfirmationResult(BillingResult p0)
		{
			Handler?.Invoke(sender, new PriceChangeConfirmationEventArgs(p0));
		}

		internal static bool __IsEmpty(IPriceChangeConfirmationListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
	[Register("com/android/billingclient/api/PurchaseHistoryResponseListener", "", "Android.BillingClient.Api.IPurchaseHistoryResponseListenerInvoker")]
	public interface IPurchaseHistoryResponseListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onPurchaseHistoryResponse", "(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V", "GetOnPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_Handler:Android.BillingClient.Api.IPurchaseHistoryResponseListenerInvoker, Xamarin.Android.Google.BillingClient")]
		void OnPurchaseHistoryResponse(BillingResult p0, IList<PurchaseHistoryRecord> p1);
	}
	[Register("com/android/billingclient/api/PurchaseHistoryResponseListener", DoNotGenerateAcw = true)]
	internal class IPurchaseHistoryResponseListenerInvoker : Java.Lang.Object, IPurchaseHistoryResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/PurchaseHistoryResponseListener", typeof(IPurchaseHistoryResponseListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;

		private IntPtr id_onPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;

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

		public static IPurchaseHistoryResponseListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPurchaseHistoryResponseListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.PurchaseHistoryResponseListener'.");
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

		public IPurchaseHistoryResponseListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_Handler()
		{
			if ((object)cb_onPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ == null)
			{
				cb_onPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_));
			}
			return cb_onPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;
		}

		private static void n_OnPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IPurchaseHistoryResponseListener purchaseHistoryResponseListener = Java.Lang.Object.GetObject<IPurchaseHistoryResponseListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BillingResult p = Java.Lang.Object.GetObject<BillingResult>(native_p0, JniHandleOwnership.DoNotTransfer);
			IList<PurchaseHistoryRecord> p2 = JavaList<PurchaseHistoryRecord>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
			purchaseHistoryResponseListener.OnPurchaseHistoryResponse(p, p2);
		}

		public unsafe void OnPurchaseHistoryResponse(BillingResult p0, IList<PurchaseHistoryRecord> p1)
		{
			if (id_onPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ == IntPtr.Zero)
			{
				id_onPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "onPurchaseHistoryResponse", "(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V");
			}
			IntPtr intPtr = JavaList<PurchaseHistoryRecord>.ToLocalJniHandle(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onPurchaseHistoryResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	public class PurchaseHistoryResponseEventArgs : EventArgs
	{
		private BillingResult p0;

		private IList<PurchaseHistoryRecord> p1;

		public BillingResult P0 => p0;

		public IList<PurchaseHistoryRecord> P1 => p1;

		public PurchaseHistoryResponseEventArgs(BillingResult p0, IList<PurchaseHistoryRecord> p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}
	[Register("mono/com/android/billingclient/api/PurchaseHistoryResponseListenerImplementor")]
	internal sealed class IPurchaseHistoryResponseListenerImplementor : Java.Lang.Object, IPurchaseHistoryResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<PurchaseHistoryResponseEventArgs> Handler;

		public IPurchaseHistoryResponseListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/android/billingclient/api/PurchaseHistoryResponseListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnPurchaseHistoryResponse(BillingResult p0, IList<PurchaseHistoryRecord> p1)
		{
			Handler?.Invoke(sender, new PurchaseHistoryResponseEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(IPurchaseHistoryResponseListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
	[Register("com/android/billingclient/api/PurchasesResponseListener", "", "Android.BillingClient.Api.IPurchasesResponseListenerInvoker")]
	public interface IPurchasesResponseListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onQueryPurchasesResponse", "(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V", "GetOnQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_Handler:Android.BillingClient.Api.IPurchasesResponseListenerInvoker, Xamarin.Android.Google.BillingClient")]
		void OnQueryPurchasesResponse(BillingResult p0, IList<Purchase> p1);
	}
	[Register("com/android/billingclient/api/PurchasesResponseListener", DoNotGenerateAcw = true)]
	internal class IPurchasesResponseListenerInvoker : Java.Lang.Object, IPurchasesResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/PurchasesResponseListener", typeof(IPurchasesResponseListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;

		private IntPtr id_onQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;

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

		public static IPurchasesResponseListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPurchasesResponseListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.PurchasesResponseListener'.");
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

		public IPurchasesResponseListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_Handler()
		{
			if ((object)cb_onQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ == null)
			{
				cb_onQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_));
			}
			return cb_onQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;
		}

		private static void n_OnQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IPurchasesResponseListener purchasesResponseListener = Java.Lang.Object.GetObject<IPurchasesResponseListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BillingResult p = Java.Lang.Object.GetObject<BillingResult>(native_p0, JniHandleOwnership.DoNotTransfer);
			IList<Purchase> p2 = JavaList<Purchase>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
			purchasesResponseListener.OnQueryPurchasesResponse(p, p2);
		}

		public unsafe void OnQueryPurchasesResponse(BillingResult p0, IList<Purchase> p1)
		{
			if (id_onQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ == IntPtr.Zero)
			{
				id_onQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "onQueryPurchasesResponse", "(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V");
			}
			IntPtr intPtr = JavaList<Purchase>.ToLocalJniHandle(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onQueryPurchasesResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	public class PurchasesResponseEventArgs : EventArgs
	{
		private BillingResult p0;

		private IList<Purchase> p1;

		public BillingResult P0 => p0;

		public IList<Purchase> P1 => p1;

		public PurchasesResponseEventArgs(BillingResult p0, IList<Purchase> p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}
	[Register("mono/com/android/billingclient/api/PurchasesResponseListenerImplementor")]
	internal sealed class IPurchasesResponseListenerImplementor : Java.Lang.Object, IPurchasesResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<PurchasesResponseEventArgs> Handler;

		public IPurchasesResponseListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/android/billingclient/api/PurchasesResponseListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnQueryPurchasesResponse(BillingResult p0, IList<Purchase> p1)
		{
			Handler?.Invoke(sender, new PurchasesResponseEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(IPurchasesResponseListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
	[Register("com/android/billingclient/api/PurchasesUpdatedListener", "", "Android.BillingClient.Api.IPurchasesUpdatedListenerInvoker")]
	public interface IPurchasesUpdatedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onPurchasesUpdated", "(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V", "GetOnPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_Handler:Android.BillingClient.Api.IPurchasesUpdatedListenerInvoker, Xamarin.Android.Google.BillingClient")]
		void OnPurchasesUpdated(BillingResult p0, IList<Purchase> p1);
	}
	[Register("com/android/billingclient/api/PurchasesUpdatedListener", DoNotGenerateAcw = true)]
	internal class IPurchasesUpdatedListenerInvoker : Java.Lang.Object, IPurchasesUpdatedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/PurchasesUpdatedListener", typeof(IPurchasesUpdatedListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;

		private IntPtr id_onPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;

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

		public static IPurchasesUpdatedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPurchasesUpdatedListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.PurchasesUpdatedListener'.");
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

		public IPurchasesUpdatedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_Handler()
		{
			if ((object)cb_onPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ == null)
			{
				cb_onPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_));
			}
			return cb_onPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;
		}

		private static void n_OnPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IPurchasesUpdatedListener purchasesUpdatedListener = Java.Lang.Object.GetObject<IPurchasesUpdatedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BillingResult p = Java.Lang.Object.GetObject<BillingResult>(native_p0, JniHandleOwnership.DoNotTransfer);
			IList<Purchase> p2 = JavaList<Purchase>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
			purchasesUpdatedListener.OnPurchasesUpdated(p, p2);
		}

		public unsafe void OnPurchasesUpdated(BillingResult p0, IList<Purchase> p1)
		{
			if (id_onPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ == IntPtr.Zero)
			{
				id_onPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "onPurchasesUpdated", "(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V");
			}
			IntPtr intPtr = JavaList<Purchase>.ToLocalJniHandle(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onPurchasesUpdated_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	public class PurchasesUpdatedEventArgs : EventArgs
	{
		private BillingResult p0;

		private IList<Purchase> p1;

		public BillingResult P0 => p0;

		public IList<Purchase> P1 => p1;

		public PurchasesUpdatedEventArgs(BillingResult p0, IList<Purchase> p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}
	[Register("mono/com/android/billingclient/api/PurchasesUpdatedListenerImplementor")]
	internal sealed class IPurchasesUpdatedListenerImplementor : Java.Lang.Object, IPurchasesUpdatedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<PurchasesUpdatedEventArgs> Handler;

		public IPurchasesUpdatedListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/android/billingclient/api/PurchasesUpdatedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnPurchasesUpdated(BillingResult p0, IList<Purchase> p1)
		{
			Handler?.Invoke(sender, new PurchasesUpdatedEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(IPurchasesUpdatedListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
	[Register("com/android/billingclient/api/SkuDetailsResponseListener", "", "Android.BillingClient.Api.ISkuDetailsResponseListenerInvoker")]
	public interface ISkuDetailsResponseListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onSkuDetailsResponse", "(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V", "GetOnSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_Handler:Android.BillingClient.Api.ISkuDetailsResponseListenerInvoker, Xamarin.Android.Google.BillingClient")]
		void OnSkuDetailsResponse(BillingResult p0, IList<SkuDetails> p1);
	}
	[Register("com/android/billingclient/api/SkuDetailsResponseListener", DoNotGenerateAcw = true)]
	internal class ISkuDetailsResponseListenerInvoker : Java.Lang.Object, ISkuDetailsResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/SkuDetailsResponseListener", typeof(ISkuDetailsResponseListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;

		private IntPtr id_onSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;

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

		public static ISkuDetailsResponseListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISkuDetailsResponseListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.android.billingclient.api.SkuDetailsResponseListener'.");
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

		public ISkuDetailsResponseListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_Handler()
		{
			if ((object)cb_onSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ == null)
			{
				cb_onSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_));
			}
			return cb_onSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_;
		}

		private static void n_OnSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ISkuDetailsResponseListener skuDetailsResponseListener = Java.Lang.Object.GetObject<ISkuDetailsResponseListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BillingResult p = Java.Lang.Object.GetObject<BillingResult>(native_p0, JniHandleOwnership.DoNotTransfer);
			IList<SkuDetails> p2 = JavaList<SkuDetails>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
			skuDetailsResponseListener.OnSkuDetailsResponse(p, p2);
		}

		public unsafe void OnSkuDetailsResponse(BillingResult p0, IList<SkuDetails> p1)
		{
			if (id_onSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ == IntPtr.Zero)
			{
				id_onSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "onSkuDetailsResponse", "(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V");
			}
			IntPtr intPtr = JavaList<SkuDetails>.ToLocalJniHandle(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onSkuDetailsResponse_Lcom_android_billingclient_api_BillingResult_Ljava_util_List_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	public class SkuDetailsResponseEventArgs : EventArgs
	{
		private BillingResult p0;

		private IList<SkuDetails> p1;

		public BillingResult P0 => p0;

		public IList<SkuDetails> P1 => p1;

		public SkuDetailsResponseEventArgs(BillingResult p0, IList<SkuDetails> p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}
	[Register("mono/com/android/billingclient/api/SkuDetailsResponseListenerImplementor")]
	internal sealed class ISkuDetailsResponseListenerImplementor : Java.Lang.Object, ISkuDetailsResponseListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<SkuDetailsResponseEventArgs> Handler;

		public ISkuDetailsResponseListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/android/billingclient/api/SkuDetailsResponseListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnSkuDetailsResponse(BillingResult p0, IList<SkuDetails> p1)
		{
			Handler?.Invoke(sender, new SkuDetailsResponseEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(ISkuDetailsResponseListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
	[Register("com/android/billingclient/api/PriceChangeFlowParams", DoNotGenerateAcw = true)]
	public class PriceChangeFlowParams : Java.Lang.Object
	{
		[Register("com/android/billingclient/api/PriceChangeFlowParams$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/PriceChangeFlowParams$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setSkuDetails_Lcom_android_billingclient_api_SkuDetails_;

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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
			}

			[Register("build", "()Lcom/android/billingclient/api/PriceChangeFlowParams;", "GetBuildHandler")]
			public unsafe virtual PriceChangeFlowParams Build()
			{
				return Java.Lang.Object.GetObject<PriceChangeFlowParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/android/billingclient/api/PriceChangeFlowParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetSkuDetails_Lcom_android_billingclient_api_SkuDetails_Handler()
			{
				if ((object)cb_setSkuDetails_Lcom_android_billingclient_api_SkuDetails_ == null)
				{
					cb_setSkuDetails_Lcom_android_billingclient_api_SkuDetails_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSkuDetails_Lcom_android_billingclient_api_SkuDetails_));
				}
				return cb_setSkuDetails_Lcom_android_billingclient_api_SkuDetails_;
			}

			private static IntPtr n_SetSkuDetails_Lcom_android_billingclient_api_SkuDetails_(IntPtr jnienv, IntPtr native__this, IntPtr native_skuDetails)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SkuDetails skuDetails = Java.Lang.Object.GetObject<SkuDetails>(native_skuDetails, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSkuDetails(skuDetails));
			}

			[Register("setSkuDetails", "(Lcom/android/billingclient/api/SkuDetails;)Lcom/android/billingclient/api/PriceChangeFlowParams$Builder;", "GetSetSkuDetails_Lcom_android_billingclient_api_SkuDetails_Handler")]
			public unsafe virtual Builder SetSkuDetails(SkuDetails skuDetails)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(skuDetails?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSkuDetails.(Lcom/android/billingclient/api/SkuDetails;)Lcom/android/billingclient/api/PriceChangeFlowParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(skuDetails);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/PriceChangeFlowParams", typeof(PriceChangeFlowParams));

		private static Delegate cb_getSkuDetails;

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

		public unsafe virtual SkuDetails SkuDetails
		{
			[Register("getSkuDetails", "()Lcom/android/billingclient/api/SkuDetails;", "GetGetSkuDetailsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<SkuDetails>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSkuDetails.()Lcom/android/billingclient/api/SkuDetails;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected PriceChangeFlowParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PriceChangeFlowParams()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSkuDetailsHandler()
		{
			if ((object)cb_getSkuDetails == null)
			{
				cb_getSkuDetails = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSkuDetails));
			}
			return cb_getSkuDetails;
		}

		private static IntPtr n_GetSkuDetails(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PriceChangeFlowParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SkuDetails);
		}

		[Register("newBuilder", "()Lcom/android/billingclient/api/PriceChangeFlowParams$Builder;", "")]
		public unsafe static Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.()Lcom/android/billingclient/api/PriceChangeFlowParams$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/android/billingclient/api/ProxyBillingActivity", DoNotGenerateAcw = true)]
	public class ProxyBillingActivity : Activity
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/ProxyBillingActivity", typeof(ProxyBillingActivity));

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

		protected ProxyBillingActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ProxyBillingActivity()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/android/billingclient/api/Purchase", DoNotGenerateAcw = true)]
	public class Purchase : Java.Lang.Object
	{
		[Register("com/android/billingclient/api/Purchase$PurchasesResult", DoNotGenerateAcw = true)]
		public class PurchasesResult : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/Purchase$PurchasesResult", typeof(PurchasesResult));

			private static Delegate cb_getBillingResult;

			private static Delegate cb_getPurchasesList;

			private static Delegate cb_getResponseCode;

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

			public unsafe virtual BillingResult BillingResult
			{
				[Register("getBillingResult", "()Lcom/android/billingclient/api/BillingResult;", "GetGetBillingResultHandler")]
				get
				{
					return Java.Lang.Object.GetObject<BillingResult>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBillingResult.()Lcom/android/billingclient/api/BillingResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual IList<Purchase> PurchasesList
			{
				[Register("getPurchasesList", "()Ljava/util/List;", "GetGetPurchasesListHandler")]
				get
				{
					return JavaList<Purchase>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getPurchasesList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

			protected PurchasesResult(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V", "")]
			public unsafe PurchasesResult(BillingResult mBillingResult, IList<Purchase> purchasesList)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JavaList<Purchase>.ToLocalJniHandle(purchasesList);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(mBillingResult?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/android/billingclient/api/BillingResult;Ljava/util/List;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(mBillingResult);
					GC.KeepAlive(purchasesList);
				}
			}

			private static Delegate GetGetBillingResultHandler()
			{
				if ((object)cb_getBillingResult == null)
				{
					cb_getBillingResult = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBillingResult));
				}
				return cb_getBillingResult;
			}

			private static IntPtr n_GetBillingResult(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PurchasesResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BillingResult);
			}

			private static Delegate GetGetPurchasesListHandler()
			{
				if ((object)cb_getPurchasesList == null)
				{
					cb_getPurchasesList = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPurchasesList));
				}
				return cb_getPurchasesList;
			}

			private static IntPtr n_GetPurchasesList(IntPtr jnienv, IntPtr native__this)
			{
				return JavaList<Purchase>.ToLocalJniHandle(Java.Lang.Object.GetObject<PurchasesResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PurchasesList);
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
				return Java.Lang.Object.GetObject<PurchasesResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResponseCode;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/Purchase", typeof(Purchase));

		private static Delegate cb_getAccountIdentifiers;

		private static Delegate cb_getDeveloperPayload;

		private static Delegate cb_isAcknowledged;

		private static Delegate cb_isAutoRenewing;

		private static Delegate cb_getOrderId;

		private static Delegate cb_getOriginalJson;

		private static Delegate cb_getPackageName;

		private static Delegate cb_getPurchaseState;

		private static Delegate cb_getPurchaseTime;

		private static Delegate cb_getPurchaseToken;

		private static Delegate cb_getQuantity;

		private static Delegate cb_getSignature;

		private static Delegate cb_getSkus;

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

		public unsafe virtual AccountIdentifiers AccountIdentifiers
		{
			[Register("getAccountIdentifiers", "()Lcom/android/billingclient/api/AccountIdentifiers;", "GetGetAccountIdentifiersHandler")]
			get
			{
				return Java.Lang.Object.GetObject<AccountIdentifiers>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAccountIdentifiers.()Lcom/android/billingclient/api/AccountIdentifiers;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string DeveloperPayload
		{
			[Register("getDeveloperPayload", "()Ljava/lang/String;", "GetGetDeveloperPayloadHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDeveloperPayload.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsAcknowledged
		{
			[Register("isAcknowledged", "()Z", "GetIsAcknowledgedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAcknowledged.()Z", this, null);
			}
		}

		public unsafe virtual bool IsAutoRenewing
		{
			[Register("isAutoRenewing", "()Z", "GetIsAutoRenewingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAutoRenewing.()Z", this, null);
			}
		}

		public unsafe virtual string OrderId
		{
			[Register("getOrderId", "()Ljava/lang/String;", "GetGetOrderIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrderId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string OriginalJson
		{
			[Register("getOriginalJson", "()Ljava/lang/String;", "GetGetOriginalJsonHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getOriginalJson.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string PackageName
		{
			[Register("getPackageName", "()Ljava/lang/String;", "GetGetPackageNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPackageName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual PurchaseState PurchaseState
		{
			[Register("getPurchaseState", "()I", "GetGetPurchaseStateHandler")]
			get
			{
				return (PurchaseState)_members.InstanceMethods.InvokeVirtualInt32Method("getPurchaseState.()I", this, null);
			}
		}

		public unsafe virtual long PurchaseTime
		{
			[Register("getPurchaseTime", "()J", "GetGetPurchaseTimeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getPurchaseTime.()J", this, null);
			}
		}

		public unsafe virtual string PurchaseToken
		{
			[Register("getPurchaseToken", "()Ljava/lang/String;", "GetGetPurchaseTokenHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPurchaseToken.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int Quantity
		{
			[Register("getQuantity", "()I", "GetGetQuantityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getQuantity.()I", this, null);
			}
		}

		public unsafe virtual string Signature
		{
			[Register("getSignature", "()Ljava/lang/String;", "GetGetSignatureHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSignature.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<string> Skus
		{
			[Register("getSkus", "()Ljava/util/ArrayList;", "GetGetSkusHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSkus.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Purchase(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe Purchase(string jsonPurchaseInfo, string signature)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(jsonPurchaseInfo);
			IntPtr intPtr2 = JNIEnv.NewString(signature);
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

		private static Delegate GetGetAccountIdentifiersHandler()
		{
			if ((object)cb_getAccountIdentifiers == null)
			{
				cb_getAccountIdentifiers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAccountIdentifiers));
			}
			return cb_getAccountIdentifiers;
		}

		private static IntPtr n_GetAccountIdentifiers(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AccountIdentifiers);
		}

		private static Delegate GetGetDeveloperPayloadHandler()
		{
			if ((object)cb_getDeveloperPayload == null)
			{
				cb_getDeveloperPayload = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDeveloperPayload));
			}
			return cb_getDeveloperPayload;
		}

		private static IntPtr n_GetDeveloperPayload(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeveloperPayload);
		}

		private static Delegate GetIsAcknowledgedHandler()
		{
			if ((object)cb_isAcknowledged == null)
			{
				cb_isAcknowledged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAcknowledged));
			}
			return cb_isAcknowledged;
		}

		private static bool n_IsAcknowledged(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAcknowledged;
		}

		private static Delegate GetIsAutoRenewingHandler()
		{
			if ((object)cb_isAutoRenewing == null)
			{
				cb_isAutoRenewing = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAutoRenewing));
			}
			return cb_isAutoRenewing;
		}

		private static bool n_IsAutoRenewing(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAutoRenewing;
		}

		private static Delegate GetGetOrderIdHandler()
		{
			if ((object)cb_getOrderId == null)
			{
				cb_getOrderId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOrderId));
			}
			return cb_getOrderId;
		}

		private static IntPtr n_GetOrderId(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OrderId);
		}

		private static Delegate GetGetOriginalJsonHandler()
		{
			if ((object)cb_getOriginalJson == null)
			{
				cb_getOriginalJson = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOriginalJson));
			}
			return cb_getOriginalJson;
		}

		private static IntPtr n_GetOriginalJson(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OriginalJson);
		}

		private static Delegate GetGetPackageNameHandler()
		{
			if ((object)cb_getPackageName == null)
			{
				cb_getPackageName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPackageName));
			}
			return cb_getPackageName;
		}

		private static IntPtr n_GetPackageName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PackageName);
		}

		private static Delegate GetGetPurchaseStateHandler()
		{
			if ((object)cb_getPurchaseState == null)
			{
				cb_getPurchaseState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPurchaseState));
			}
			return cb_getPurchaseState;
		}

		private static int n_GetPurchaseState(IntPtr jnienv, IntPtr native__this)
		{
			return (int)Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PurchaseState;
		}

		private static Delegate GetGetPurchaseTimeHandler()
		{
			if ((object)cb_getPurchaseTime == null)
			{
				cb_getPurchaseTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetPurchaseTime));
			}
			return cb_getPurchaseTime;
		}

		private static long n_GetPurchaseTime(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PurchaseTime;
		}

		private static Delegate GetGetPurchaseTokenHandler()
		{
			if ((object)cb_getPurchaseToken == null)
			{
				cb_getPurchaseToken = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPurchaseToken));
			}
			return cb_getPurchaseToken;
		}

		private static IntPtr n_GetPurchaseToken(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PurchaseToken);
		}

		private static Delegate GetGetQuantityHandler()
		{
			if ((object)cb_getQuantity == null)
			{
				cb_getQuantity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetQuantity));
			}
			return cb_getQuantity;
		}

		private static int n_GetQuantity(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Quantity;
		}

		private static Delegate GetGetSignatureHandler()
		{
			if ((object)cb_getSignature == null)
			{
				cb_getSignature = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSignature));
			}
			return cb_getSignature;
		}

		private static IntPtr n_GetSignature(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Signature);
		}

		private static Delegate GetGetSkusHandler()
		{
			if ((object)cb_getSkus == null)
			{
				cb_getSkus = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSkus));
			}
			return cb_getSkus;
		}

		private static IntPtr n_GetSkus(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<Purchase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Skus);
		}
	}
	[Register("com/android/billingclient/api/PurchaseHistoryRecord", DoNotGenerateAcw = true)]
	public class PurchaseHistoryRecord : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/PurchaseHistoryRecord", typeof(PurchaseHistoryRecord));

		private static Delegate cb_getDeveloperPayload;

		private static Delegate cb_getOriginalJson;

		private static Delegate cb_getPurchaseTime;

		private static Delegate cb_getPurchaseToken;

		private static Delegate cb_getQuantity;

		private static Delegate cb_getSignature;

		private static Delegate cb_getSkus;

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

		public unsafe virtual string DeveloperPayload
		{
			[Register("getDeveloperPayload", "()Ljava/lang/String;", "GetGetDeveloperPayloadHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDeveloperPayload.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string OriginalJson
		{
			[Register("getOriginalJson", "()Ljava/lang/String;", "GetGetOriginalJsonHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getOriginalJson.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual long PurchaseTime
		{
			[Register("getPurchaseTime", "()J", "GetGetPurchaseTimeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getPurchaseTime.()J", this, null);
			}
		}

		public unsafe virtual string PurchaseToken
		{
			[Register("getPurchaseToken", "()Ljava/lang/String;", "GetGetPurchaseTokenHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPurchaseToken.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int Quantity
		{
			[Register("getQuantity", "()I", "GetGetQuantityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getQuantity.()I", this, null);
			}
		}

		public unsafe virtual string Signature
		{
			[Register("getSignature", "()Ljava/lang/String;", "GetGetSignatureHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSignature.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<string> Skus
		{
			[Register("getSkus", "()Ljava/util/ArrayList;", "GetGetSkusHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSkus.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected PurchaseHistoryRecord(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe PurchaseHistoryRecord(string jsonPurchaseInfo, string signature)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(jsonPurchaseInfo);
			IntPtr intPtr2 = JNIEnv.NewString(signature);
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

		private static Delegate GetGetDeveloperPayloadHandler()
		{
			if ((object)cb_getDeveloperPayload == null)
			{
				cb_getDeveloperPayload = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDeveloperPayload));
			}
			return cb_getDeveloperPayload;
		}

		private static IntPtr n_GetDeveloperPayload(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<PurchaseHistoryRecord>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeveloperPayload);
		}

		private static Delegate GetGetOriginalJsonHandler()
		{
			if ((object)cb_getOriginalJson == null)
			{
				cb_getOriginalJson = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOriginalJson));
			}
			return cb_getOriginalJson;
		}

		private static IntPtr n_GetOriginalJson(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<PurchaseHistoryRecord>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OriginalJson);
		}

		private static Delegate GetGetPurchaseTimeHandler()
		{
			if ((object)cb_getPurchaseTime == null)
			{
				cb_getPurchaseTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetPurchaseTime));
			}
			return cb_getPurchaseTime;
		}

		private static long n_GetPurchaseTime(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<PurchaseHistoryRecord>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PurchaseTime;
		}

		private static Delegate GetGetPurchaseTokenHandler()
		{
			if ((object)cb_getPurchaseToken == null)
			{
				cb_getPurchaseToken = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPurchaseToken));
			}
			return cb_getPurchaseToken;
		}

		private static IntPtr n_GetPurchaseToken(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<PurchaseHistoryRecord>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PurchaseToken);
		}

		private static Delegate GetGetQuantityHandler()
		{
			if ((object)cb_getQuantity == null)
			{
				cb_getQuantity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetQuantity));
			}
			return cb_getQuantity;
		}

		private static int n_GetQuantity(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<PurchaseHistoryRecord>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Quantity;
		}

		private static Delegate GetGetSignatureHandler()
		{
			if ((object)cb_getSignature == null)
			{
				cb_getSignature = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSignature));
			}
			return cb_getSignature;
		}

		private static IntPtr n_GetSignature(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<PurchaseHistoryRecord>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Signature);
		}

		private static Delegate GetGetSkusHandler()
		{
			if ((object)cb_getSkus == null)
			{
				cb_getSkus = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSkus));
			}
			return cb_getSkus;
		}

		private static IntPtr n_GetSkus(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<PurchaseHistoryRecord>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Skus);
		}
	}
	[Register("com/android/billingclient/api/SkuDetails", DoNotGenerateAcw = true)]
	public class SkuDetails : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/SkuDetails", typeof(SkuDetails));

		private static Delegate cb_getDescription;

		private static Delegate cb_getFreeTrialPeriod;

		private static Delegate cb_getIconUrl;

		private static Delegate cb_getIntroductoryPrice;

		private static Delegate cb_getIntroductoryPriceAmountMicros;

		private static Delegate cb_getIntroductoryPriceCycles;

		private static Delegate cb_getIntroductoryPricePeriod;

		private static Delegate cb_getOriginalJson;

		private static Delegate cb_getOriginalPrice;

		private static Delegate cb_getOriginalPriceAmountMicros;

		private static Delegate cb_getPrice;

		private static Delegate cb_getPriceAmountMicros;

		private static Delegate cb_getPriceCurrencyCode;

		private static Delegate cb_getSku;

		private static Delegate cb_getSubscriptionPeriod;

		private static Delegate cb_getTitle;

		private static Delegate cb_getType;

		private static Delegate cb_zza;

		private static Delegate cb_zzb;

		private static Delegate cb_zzd;

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

		public unsafe virtual string Description
		{
			[Register("getDescription", "()Ljava/lang/String;", "GetGetDescriptionHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string FreeTrialPeriod
		{
			[Register("getFreeTrialPeriod", "()Ljava/lang/String;", "GetGetFreeTrialPeriodHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getFreeTrialPeriod.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string IconUrl
		{
			[Register("getIconUrl", "()Ljava/lang/String;", "GetGetIconUrlHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string IntroductoryPrice
		{
			[Register("getIntroductoryPrice", "()Ljava/lang/String;", "GetGetIntroductoryPriceHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getIntroductoryPrice.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual long IntroductoryPriceAmountMicros
		{
			[Register("getIntroductoryPriceAmountMicros", "()J", "GetGetIntroductoryPriceAmountMicrosHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getIntroductoryPriceAmountMicros.()J", this, null);
			}
		}

		public unsafe virtual int IntroductoryPriceCycles
		{
			[Register("getIntroductoryPriceCycles", "()I", "GetGetIntroductoryPriceCyclesHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getIntroductoryPriceCycles.()I", this, null);
			}
		}

		public unsafe virtual string IntroductoryPricePeriod
		{
			[Register("getIntroductoryPricePeriod", "()Ljava/lang/String;", "GetGetIntroductoryPricePeriodHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getIntroductoryPricePeriod.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string OriginalJson
		{
			[Register("getOriginalJson", "()Ljava/lang/String;", "GetGetOriginalJsonHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getOriginalJson.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string OriginalPrice
		{
			[Register("getOriginalPrice", "()Ljava/lang/String;", "GetGetOriginalPriceHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getOriginalPrice.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual long OriginalPriceAmountMicros
		{
			[Register("getOriginalPriceAmountMicros", "()J", "GetGetOriginalPriceAmountMicrosHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getOriginalPriceAmountMicros.()J", this, null);
			}
		}

		public unsafe virtual string Price
		{
			[Register("getPrice", "()Ljava/lang/String;", "GetGetPriceHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrice.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual long PriceAmountMicros
		{
			[Register("getPriceAmountMicros", "()J", "GetGetPriceAmountMicrosHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getPriceAmountMicros.()J", this, null);
			}
		}

		public unsafe virtual string PriceCurrencyCode
		{
			[Register("getPriceCurrencyCode", "()Ljava/lang/String;", "GetGetPriceCurrencyCodeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPriceCurrencyCode.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Sku
		{
			[Register("getSku", "()Ljava/lang/String;", "GetGetSkuHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSku.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string SubscriptionPeriod
		{
			[Register("getSubscriptionPeriod", "()Ljava/lang/String;", "GetGetSubscriptionPeriodHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSubscriptionPeriod.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "GetGetTitleHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Type
		{
			[Register("getType", "()Ljava/lang/String;", "GetGetTypeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected SkuDetails(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe SkuDetails(string jsonSkuDetails)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(jsonSkuDetails);
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

		private static Delegate GetGetDescriptionHandler()
		{
			if ((object)cb_getDescription == null)
			{
				cb_getDescription = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDescription));
			}
			return cb_getDescription;
		}

		private static IntPtr n_GetDescription(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Description);
		}

		private static Delegate GetGetFreeTrialPeriodHandler()
		{
			if ((object)cb_getFreeTrialPeriod == null)
			{
				cb_getFreeTrialPeriod = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFreeTrialPeriod));
			}
			return cb_getFreeTrialPeriod;
		}

		private static IntPtr n_GetFreeTrialPeriod(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FreeTrialPeriod);
		}

		private static Delegate GetGetIconUrlHandler()
		{
			if ((object)cb_getIconUrl == null)
			{
				cb_getIconUrl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetIconUrl));
			}
			return cb_getIconUrl;
		}

		private static IntPtr n_GetIconUrl(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconUrl);
		}

		private static Delegate GetGetIntroductoryPriceHandler()
		{
			if ((object)cb_getIntroductoryPrice == null)
			{
				cb_getIntroductoryPrice = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetIntroductoryPrice));
			}
			return cb_getIntroductoryPrice;
		}

		private static IntPtr n_GetIntroductoryPrice(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntroductoryPrice);
		}

		private static Delegate GetGetIntroductoryPriceAmountMicrosHandler()
		{
			if ((object)cb_getIntroductoryPriceAmountMicros == null)
			{
				cb_getIntroductoryPriceAmountMicros = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetIntroductoryPriceAmountMicros));
			}
			return cb_getIntroductoryPriceAmountMicros;
		}

		private static long n_GetIntroductoryPriceAmountMicros(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntroductoryPriceAmountMicros;
		}

		private static Delegate GetGetIntroductoryPriceCyclesHandler()
		{
			if ((object)cb_getIntroductoryPriceCycles == null)
			{
				cb_getIntroductoryPriceCycles = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetIntroductoryPriceCycles));
			}
			return cb_getIntroductoryPriceCycles;
		}

		private static int n_GetIntroductoryPriceCycles(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntroductoryPriceCycles;
		}

		private static Delegate GetGetIntroductoryPricePeriodHandler()
		{
			if ((object)cb_getIntroductoryPricePeriod == null)
			{
				cb_getIntroductoryPricePeriod = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetIntroductoryPricePeriod));
			}
			return cb_getIntroductoryPricePeriod;
		}

		private static IntPtr n_GetIntroductoryPricePeriod(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntroductoryPricePeriod);
		}

		private static Delegate GetGetOriginalJsonHandler()
		{
			if ((object)cb_getOriginalJson == null)
			{
				cb_getOriginalJson = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOriginalJson));
			}
			return cb_getOriginalJson;
		}

		private static IntPtr n_GetOriginalJson(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OriginalJson);
		}

		private static Delegate GetGetOriginalPriceHandler()
		{
			if ((object)cb_getOriginalPrice == null)
			{
				cb_getOriginalPrice = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOriginalPrice));
			}
			return cb_getOriginalPrice;
		}

		private static IntPtr n_GetOriginalPrice(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OriginalPrice);
		}

		private static Delegate GetGetOriginalPriceAmountMicrosHandler()
		{
			if ((object)cb_getOriginalPriceAmountMicros == null)
			{
				cb_getOriginalPriceAmountMicros = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetOriginalPriceAmountMicros));
			}
			return cb_getOriginalPriceAmountMicros;
		}

		private static long n_GetOriginalPriceAmountMicros(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OriginalPriceAmountMicros;
		}

		private static Delegate GetGetPriceHandler()
		{
			if ((object)cb_getPrice == null)
			{
				cb_getPrice = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPrice));
			}
			return cb_getPrice;
		}

		private static IntPtr n_GetPrice(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Price);
		}

		private static Delegate GetGetPriceAmountMicrosHandler()
		{
			if ((object)cb_getPriceAmountMicros == null)
			{
				cb_getPriceAmountMicros = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetPriceAmountMicros));
			}
			return cb_getPriceAmountMicros;
		}

		private static long n_GetPriceAmountMicros(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PriceAmountMicros;
		}

		private static Delegate GetGetPriceCurrencyCodeHandler()
		{
			if ((object)cb_getPriceCurrencyCode == null)
			{
				cb_getPriceCurrencyCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPriceCurrencyCode));
			}
			return cb_getPriceCurrencyCode;
		}

		private static IntPtr n_GetPriceCurrencyCode(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PriceCurrencyCode);
		}

		private static Delegate GetGetSkuHandler()
		{
			if ((object)cb_getSku == null)
			{
				cb_getSku = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSku));
			}
			return cb_getSku;
		}

		private static IntPtr n_GetSku(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Sku);
		}

		private static Delegate GetGetSubscriptionPeriodHandler()
		{
			if ((object)cb_getSubscriptionPeriod == null)
			{
				cb_getSubscriptionPeriod = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSubscriptionPeriod));
			}
			return cb_getSubscriptionPeriod;
		}

		private static IntPtr n_GetSubscriptionPeriod(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubscriptionPeriod);
		}

		private static Delegate GetGetTitleHandler()
		{
			if ((object)cb_getTitle == null)
			{
				cb_getTitle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTitle));
			}
			return cb_getTitle;
		}

		private static IntPtr n_GetTitle(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Title);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type);
		}

		private static Delegate GetZzaHandler()
		{
			if ((object)cb_zza == null)
			{
				cb_zza = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_Zza));
			}
			return cb_zza;
		}

		private static int n_Zza(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Zza();
		}

		[Register("zza", "()I", "GetZzaHandler")]
		public unsafe virtual int Zza()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("zza.()I", this, null);
		}

		private static Delegate GetZzbHandler()
		{
			if ((object)cb_zzb == null)
			{
				cb_zzb = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Zzb));
			}
			return cb_zzb;
		}

		private static IntPtr n_Zzb(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Zzb());
		}

		[Register("zzb", "()Ljava/lang/String;", "GetZzbHandler")]
		public unsafe virtual string Zzb()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("zzb.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zzc", "()Ljava/lang/String;", "")]
		public unsafe string Zzc()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zzc.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetZzdHandler()
		{
			if ((object)cb_zzd == null)
			{
				cb_zzd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Zzd));
			}
			return cb_zzd;
		}

		private static IntPtr n_Zzd(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Zzd());
		}

		[Register("zzd", "()Ljava/lang/String;", "GetZzdHandler")]
		public unsafe virtual string Zzd()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("zzd.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/android/billingclient/api/SkuDetailsParams", DoNotGenerateAcw = true)]
	public class SkuDetailsParams : Java.Lang.Object
	{
		[Register("com/android/billingclient/api/SkuDetailsParams$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/SkuDetailsParams$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setSkusList_Ljava_util_List_;

			private static Delegate cb_setType_Ljava_lang_String_;

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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
			}

			[Register("build", "()Lcom/android/billingclient/api/SkuDetailsParams;", "GetBuildHandler")]
			public unsafe virtual SkuDetailsParams Build()
			{
				return Java.Lang.Object.GetObject<SkuDetailsParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/android/billingclient/api/SkuDetailsParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetSkusList_Ljava_util_List_Handler()
			{
				if ((object)cb_setSkusList_Ljava_util_List_ == null)
				{
					cb_setSkusList_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSkusList_Ljava_util_List_));
				}
				return cb_setSkusList_Ljava_util_List_;
			}

			private static IntPtr n_SetSkusList_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_skusList)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<string> skusList = JavaList<string>.FromJniHandle(native_skusList, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSkusList(skusList));
			}

			[Register("setSkusList", "(Ljava/util/List;)Lcom/android/billingclient/api/SkuDetailsParams$Builder;", "GetSetSkusList_Ljava_util_List_Handler")]
			public unsafe virtual Builder SetSkusList(IList<string> skusList)
			{
				IntPtr intPtr = JavaList<string>.ToLocalJniHandle(skusList);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSkusList.(Ljava/util/List;)Lcom/android/billingclient/api/SkuDetailsParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(skusList);
				}
			}

			private static Delegate GetSetType_Ljava_lang_String_Handler()
			{
				if ((object)cb_setType_Ljava_lang_String_ == null)
				{
					cb_setType_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetType_Ljava_lang_String_));
				}
				return cb_setType_Ljava_lang_String_;
			}

			private static IntPtr n_SetType_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_type)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetType(type));
			}

			[Register("setType", "(Ljava/lang/String;)Lcom/android/billingclient/api/SkuDetailsParams$Builder;", "GetSetType_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetType(string type)
			{
				IntPtr intPtr = JNIEnv.NewString(type);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setType.(Ljava/lang/String;)Lcom/android/billingclient/api/SkuDetailsParams$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/billingclient/api/SkuDetailsParams", typeof(SkuDetailsParams));

		private static Delegate cb_getSkuType;

		private static Delegate cb_getSkusList;

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

		public unsafe virtual string SkuType
		{
			[Register("getSkuType", "()Ljava/lang/String;", "GetGetSkuTypeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSkuType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<string> SkusList
		{
			[Register("getSkusList", "()Ljava/util/List;", "GetGetSkusListHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSkusList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected SkuDetailsParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SkuDetailsParams()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSkuTypeHandler()
		{
			if ((object)cb_getSkuType == null)
			{
				cb_getSkuType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSkuType));
			}
			return cb_getSkuType;
		}

		private static IntPtr n_GetSkuType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SkuDetailsParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SkuType);
		}

		private static Delegate GetGetSkusListHandler()
		{
			if ((object)cb_getSkusList == null)
			{
				cb_getSkusList = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSkusList));
			}
			return cb_getSkusList;
		}

		private static IntPtr n_GetSkusList(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<SkuDetailsParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SkusList);
		}

		[Register("newBuilder", "()Lcom/android/billingclient/api/SkuDetailsParams$Builder;", "")]
		public unsafe static Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.()Lcom/android/billingclient/api/SkuDetailsParams$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
