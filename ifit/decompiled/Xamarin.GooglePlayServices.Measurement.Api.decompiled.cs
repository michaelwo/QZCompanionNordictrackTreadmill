using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "7a6d28e6d7c7ef946052e48991adc27680439de3")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20221020.7")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "10/20/2022 6:26:36 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: UsesLibrary("org.apache.http.legacy", Required = false)]
[assembly: NamespaceMapping(Java = "com.google.firebase.analytics.connector", Managed = "Firebase.Analytics.Connector")]
[assembly: NamespaceMapping(Java = "com.google.firebase.analytics", Managed = "Firebase.Analytics")]
[assembly: NamespaceMapping(Java = "com.google.firebase.analytics.connector.internal", Managed = "Firebase.Analytics.Connector.Internal")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("\r\n        Xamarin.Android Bindings for Google Play Services - Measurement.Api 121.1.1 artifact=com.google.android.gms:play-services-measurement-api artifact_versioned=com.google.android.gms:play-services-measurement-api:21.1.1\r\n\r\n        \r\n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.GooglePlayServices.Measurement.Api")]
[assembly: AssemblyTitle("Xamarin.GooglePlayServices.Measurement.Api")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/GooglePlayServicesComponents.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace Firebase.Analytics;

[Register("com/google/firebase/analytics/FirebaseAnalytics", DoNotGenerateAcw = true)]
public sealed class FirebaseAnalytics : Java.Lang.Object
{
	[Register("com/google/firebase/analytics/FirebaseAnalytics$ConsentStatus", DoNotGenerateAcw = true)]
	public sealed class ConsentStatus : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/analytics/FirebaseAnalytics$ConsentStatus", typeof(ConsentStatus));

		[Register("DENIED")]
		public static ConsentStatus Denied => Java.Lang.Object.GetObject<ConsentStatus>(_members.StaticFields.GetObjectValue("DENIED.Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentStatus;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GRANTED")]
		public static ConsentStatus Granted => Java.Lang.Object.GetObject<ConsentStatus>(_members.StaticFields.GetObjectValue("GRANTED.Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentStatus;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal ConsentStatus(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentStatus;", "")]
		public unsafe static ConsentStatus ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ConsentStatus>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentStatus;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentStatus;", "")]
		public unsafe static ConsentStatus[] Values()
		{
			return (ConsentStatus[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentStatus;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ConsentStatus));
		}
	}

	[Register("com/google/firebase/analytics/FirebaseAnalytics$ConsentType", DoNotGenerateAcw = true)]
	public sealed class ConsentType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/analytics/FirebaseAnalytics$ConsentType", typeof(ConsentType));

		[Register("AD_STORAGE")]
		public static ConsentType AdStorage => Java.Lang.Object.GetObject<ConsentType>(_members.StaticFields.GetObjectValue("AD_STORAGE.Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ANALYTICS_STORAGE")]
		public static ConsentType AnalyticsStorage => Java.Lang.Object.GetObject<ConsentType>(_members.StaticFields.GetObjectValue("ANALYTICS_STORAGE.Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentType;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal ConsentType(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentType;", "")]
		public unsafe static ConsentType ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ConsentType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentType;", "")]
		public unsafe static ConsentType[] Values()
		{
			return (ConsentType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/firebase/analytics/FirebaseAnalytics$ConsentType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ConsentType));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/analytics/FirebaseAnalytics", typeof(FirebaseAnalytics));

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

	public unsafe string FirebaseInstanceId
	{
		[Register("getFirebaseInstanceId", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getFirebaseInstanceId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal FirebaseAnalytics(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("getAppInstanceId", "()Lcom/google/android/gms/tasks/Task;", "")]
	public unsafe Task GetAppInstanceId()
	{
		return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAppInstanceId.()Lcom/google/android/gms/tasks/Task;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getInstance", "(Landroid/content/Context;)Lcom/google/firebase/analytics/FirebaseAnalytics;", "")]
	public unsafe static FirebaseAnalytics GetInstance(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FirebaseAnalytics>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Landroid/content/Context;)Lcom/google/firebase/analytics/FirebaseAnalytics;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("logEvent", "(Ljava/lang/String;Landroid/os/Bundle;)V", "")]
	public unsafe void LogEvent(string name, Bundle @params)
	{
		IntPtr intPtr = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("logEvent.(Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(@params);
		}
	}

	[Register("resetAnalyticsData", "()V", "")]
	public unsafe void ResetAnalyticsData()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("resetAnalyticsData.()V", this, null);
	}

	[Register("setAnalyticsCollectionEnabled", "(Z)V", "")]
	public unsafe void SetAnalyticsCollectionEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setAnalyticsCollectionEnabled.(Z)V", this, ptr);
	}

	[Register("setConsent", "(Ljava/util/Map;)V", "")]
	public unsafe void SetConsent(IDictionary<ConsentType, ConsentStatus> consentSettings)
	{
		IntPtr intPtr = JavaDictionary<ConsentType, ConsentStatus>.ToLocalJniHandle(consentSettings);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setConsent.(Ljava/util/Map;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(consentSettings);
		}
	}

	[Register("setCurrentScreen", "(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;)V", "")]
	public unsafe void SetCurrentScreen(Activity activity, string screenName, string screenClassOverride)
	{
		IntPtr intPtr = JNIEnv.NewString(screenName);
		IntPtr intPtr2 = JNIEnv.NewString(screenClassOverride);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			ptr[2] = new JniArgumentValue(intPtr2);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setCurrentScreen.(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			GC.KeepAlive(activity);
		}
	}

	[Register("setDefaultEventParameters", "(Landroid/os/Bundle;)V", "")]
	public unsafe void SetDefaultEventParameters(Bundle parameters)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setDefaultEventParameters.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(parameters);
		}
	}

	[Register("setSessionTimeoutDuration", "(J)V", "")]
	public unsafe void SetSessionTimeoutDuration(long milliseconds)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(milliseconds);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setSessionTimeoutDuration.(J)V", this, ptr);
	}

	[Register("setUserId", "(Ljava/lang/String;)V", "")]
	public unsafe void SetUserId(string id)
	{
		IntPtr intPtr = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setUserId.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	[Register("setUserProperty", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
	public unsafe void SetUserProperty(string name, string value)
	{
		IntPtr intPtr = JNIEnv.NewString(name);
		IntPtr intPtr2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(intPtr2);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setUserProperty.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}
	}
}
