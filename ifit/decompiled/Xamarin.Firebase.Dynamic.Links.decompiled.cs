using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.Gms.Common.Internal.SafeParcel;
using Android.Gms.Tasks;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Firebase.DynamicLinks.Internal;
using Firebase.Inject;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "fb4985bc40adce1eed066f366d7905c21957aac8")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20220414.6")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "4/14/2022 7:04:25 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: UsesLibrary("org.apache.http.legacy", Required = false)]
[assembly: NamespaceMapping(Java = "com.google.firebase.dynamiclinks", Managed = "Firebase.DynamicLinks")]
[assembly: NamespaceMapping(Java = "com.google.firebase.dynamiclinks.internal", Managed = "Firebase.DynamicLinks.Internal")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("\r\n        Xamarin.Android Bindings for Google Play Services - Xamarin.Firebase.Dynamic.Links 120.1.1.5 artifact=com.google.firebase:firebase-dynamic-links artifact_versioned=com.google.firebase:firebase-dynamic-links:20.1.1\r\n\r\n        \r\n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Firebase.Dynamic.Links")]
[assembly: AssemblyTitle("Xamarin.Firebase.Dynamic.Links")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/GooglePlayServicesComponents.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPJ_V(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
namespace Firebase.DynamicLinks
{
	[Register("com/google/firebase/dynamiclinks/DynamicLink", DoNotGenerateAcw = true)]
	public sealed class DynamicLink : Java.Lang.Object
	{
		[Register("com/google/firebase/dynamiclinks/DynamicLink$AndroidParameters", DoNotGenerateAcw = true)]
		public sealed class AndroidParameters : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/DynamicLink$AndroidParameters", typeof(AndroidParameters));

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

			internal AndroidParameters(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/google/firebase/dynamiclinks/DynamicLink$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/DynamicLink$Builder", typeof(Builder));

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

			public unsafe string DomainUriPrefix
			{
				[Register("getDomainUriPrefix", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDomainUriPrefix.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe Android.Net.Uri Link
			{
				[Register("getLink", "()Landroid/net/Uri;", "")]
				get
				{
					return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLink.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe Android.Net.Uri LongLink
			{
				[Register("getLongLink", "()Landroid/net/Uri;", "")]
				get
				{
					return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLongLink.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lcom/google/firebase/dynamiclinks/internal/FirebaseDynamicLinksImpl;)V", "")]
			public unsafe Builder(FirebaseDynamicLinksImpl firebaseDynamicLinks)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(firebaseDynamicLinks?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/firebase/dynamiclinks/internal/FirebaseDynamicLinksImpl;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/google/firebase/dynamiclinks/internal/FirebaseDynamicLinksImpl;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(firebaseDynamicLinks);
				}
			}

			[Register("buildDynamicLink", "()Lcom/google/firebase/dynamiclinks/DynamicLink;", "")]
			public unsafe DynamicLink BuildDynamicLink()
			{
				return Java.Lang.Object.GetObject<DynamicLink>(_members.InstanceMethods.InvokeAbstractObjectMethod("buildDynamicLink.()Lcom/google/firebase/dynamiclinks/DynamicLink;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("buildShortDynamicLink", "()Lcom/google/android/gms/tasks/Task;", "")]
			public unsafe Task BuildShortDynamicLink()
			{
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("buildShortDynamicLink.()Lcom/google/android/gms/tasks/Task;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("buildShortDynamicLink", "(I)Lcom/google/android/gms/tasks/Task;", "")]
			public unsafe Task BuildShortDynamicLink(int suffix)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(suffix);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("buildShortDynamicLink.(I)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setAndroidParameters", "(Lcom/google/firebase/dynamiclinks/DynamicLink$AndroidParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "")]
			public unsafe Builder SetAndroidParameters(AndroidParameters androidParameters)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(androidParameters?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAndroidParameters.(Lcom/google/firebase/dynamiclinks/DynamicLink$AndroidParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(androidParameters);
				}
			}

			[Register("setDomainUriPrefix", "(Ljava/lang/String;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "")]
			public unsafe Builder SetDomainUriPrefix(string domainUriPrefix)
			{
				IntPtr intPtr = JNIEnv.NewString(domainUriPrefix);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDomainUriPrefix.(Ljava/lang/String;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setDynamicLinkDomain", "(Ljava/lang/String;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "")]
			public unsafe Builder SetDynamicLinkDomain(string dynamicLinkDomain)
			{
				IntPtr intPtr = JNIEnv.NewString(dynamicLinkDomain);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDynamicLinkDomain.(Ljava/lang/String;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setGoogleAnalyticsParameters", "(Lcom/google/firebase/dynamiclinks/DynamicLink$GoogleAnalyticsParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "")]
			public unsafe Builder SetGoogleAnalyticsParameters(GoogleAnalyticsParameters googleAnalyticsParameters)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(googleAnalyticsParameters?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setGoogleAnalyticsParameters.(Lcom/google/firebase/dynamiclinks/DynamicLink$GoogleAnalyticsParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(googleAnalyticsParameters);
				}
			}

			[Register("setIosParameters", "(Lcom/google/firebase/dynamiclinks/DynamicLink$IosParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "")]
			public unsafe Builder SetIosParameters(IosParameters iosParameters)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(iosParameters?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIosParameters.(Lcom/google/firebase/dynamiclinks/DynamicLink$IosParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(iosParameters);
				}
			}

			[Register("setItunesConnectAnalyticsParameters", "(Lcom/google/firebase/dynamiclinks/DynamicLink$ItunesConnectAnalyticsParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "")]
			public unsafe Builder SetItunesConnectAnalyticsParameters(ItunesConnectAnalyticsParameters itunesConnectAnalyticsParameters)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(itunesConnectAnalyticsParameters?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setItunesConnectAnalyticsParameters.(Lcom/google/firebase/dynamiclinks/DynamicLink$ItunesConnectAnalyticsParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(itunesConnectAnalyticsParameters);
				}
			}

			[Register("setLink", "(Landroid/net/Uri;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "")]
			public unsafe Builder SetLink(Android.Net.Uri link)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(link?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLink.(Landroid/net/Uri;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(link);
				}
			}

			[Register("setLongLink", "(Landroid/net/Uri;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "")]
			public unsafe Builder SetLongLink(Android.Net.Uri longLink)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(longLink?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLongLink.(Landroid/net/Uri;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(longLink);
				}
			}

			[Register("setNavigationInfoParameters", "(Lcom/google/firebase/dynamiclinks/DynamicLink$NavigationInfoParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "")]
			public unsafe Builder SetNavigationInfoParameters(NavigationInfoParameters navigationInfoParameters)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(navigationInfoParameters?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNavigationInfoParameters.(Lcom/google/firebase/dynamiclinks/DynamicLink$NavigationInfoParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(navigationInfoParameters);
				}
			}

			[Register("setSocialMetaTagParameters", "(Lcom/google/firebase/dynamiclinks/DynamicLink$SocialMetaTagParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "")]
			public unsafe Builder SetSocialMetaTagParameters(SocialMetaTagParameters socialMetaTagParameters)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(socialMetaTagParameters?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSocialMetaTagParameters.(Lcom/google/firebase/dynamiclinks/DynamicLink$SocialMetaTagParameters;)Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(socialMetaTagParameters);
				}
			}
		}

		[Register("com/google/firebase/dynamiclinks/DynamicLink$GoogleAnalyticsParameters", DoNotGenerateAcw = true)]
		public sealed class GoogleAnalyticsParameters : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/DynamicLink$GoogleAnalyticsParameters", typeof(GoogleAnalyticsParameters));

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

			internal GoogleAnalyticsParameters(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/google/firebase/dynamiclinks/DynamicLink$IosParameters", DoNotGenerateAcw = true)]
		public sealed class IosParameters : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/DynamicLink$IosParameters", typeof(IosParameters));

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

			internal IosParameters(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/google/firebase/dynamiclinks/DynamicLink$ItunesConnectAnalyticsParameters", DoNotGenerateAcw = true)]
		public sealed class ItunesConnectAnalyticsParameters : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/DynamicLink$ItunesConnectAnalyticsParameters", typeof(ItunesConnectAnalyticsParameters));

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

			internal ItunesConnectAnalyticsParameters(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/google/firebase/dynamiclinks/DynamicLink$NavigationInfoParameters", DoNotGenerateAcw = true)]
		public sealed class NavigationInfoParameters : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/DynamicLink$NavigationInfoParameters", typeof(NavigationInfoParameters));

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

			internal NavigationInfoParameters(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/google/firebase/dynamiclinks/DynamicLink$SocialMetaTagParameters", DoNotGenerateAcw = true)]
		public sealed class SocialMetaTagParameters : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/DynamicLink$SocialMetaTagParameters", typeof(SocialMetaTagParameters));

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

			internal SocialMetaTagParameters(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/DynamicLink", typeof(DynamicLink));

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

		public unsafe Android.Net.Uri Uri
		{
			[Register("getUri", "()Landroid/net/Uri;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeAbstractObjectMethod("getUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal DynamicLink(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/firebase/dynamiclinks/FirebaseDynamicLinks", DoNotGenerateAcw = true)]
	public abstract class FirebaseDynamicLinks : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/FirebaseDynamicLinks", typeof(FirebaseDynamicLinks));

		private static Delegate cb_createDynamicLink;

		private static Delegate cb_getDynamicLink_Landroid_content_Intent_;

		private static Delegate cb_getDynamicLink_Landroid_net_Uri_;

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

		public unsafe static FirebaseDynamicLinks Instance
		{
			[Register("getInstance", "()Lcom/google/firebase/dynamiclinks/FirebaseDynamicLinks;", "")]
			get
			{
				return Java.Lang.Object.GetObject<FirebaseDynamicLinks>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lcom/google/firebase/dynamiclinks/FirebaseDynamicLinks;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected FirebaseDynamicLinks(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FirebaseDynamicLinks()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCreateDynamicLinkHandler()
		{
			if ((object)cb_createDynamicLink == null)
			{
				cb_createDynamicLink = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateDynamicLink));
			}
			return cb_createDynamicLink;
		}

		private static IntPtr n_CreateDynamicLink(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FirebaseDynamicLinks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateDynamicLink());
		}

		[Register("createDynamicLink", "()Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "GetCreateDynamicLinkHandler")]
		public abstract DynamicLink.Builder CreateDynamicLink();

		private static Delegate GetGetDynamicLink_Landroid_content_Intent_Handler()
		{
			if ((object)cb_getDynamicLink_Landroid_content_Intent_ == null)
			{
				cb_getDynamicLink_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetDynamicLink_Landroid_content_Intent_));
			}
			return cb_getDynamicLink_Landroid_content_Intent_;
		}

		private static IntPtr n_GetDynamicLink_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			FirebaseDynamicLinks firebaseDynamicLinks = Java.Lang.Object.GetObject<FirebaseDynamicLinks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent p = Java.Lang.Object.GetObject<Intent>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(firebaseDynamicLinks.GetDynamicLink(p));
		}

		[Register("getDynamicLink", "(Landroid/content/Intent;)Lcom/google/android/gms/tasks/Task;", "GetGetDynamicLink_Landroid_content_Intent_Handler")]
		public abstract Task GetDynamicLink(Intent p0);

		private static Delegate GetGetDynamicLink_Landroid_net_Uri_Handler()
		{
			if ((object)cb_getDynamicLink_Landroid_net_Uri_ == null)
			{
				cb_getDynamicLink_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetDynamicLink_Landroid_net_Uri_));
			}
			return cb_getDynamicLink_Landroid_net_Uri_;
		}

		private static IntPtr n_GetDynamicLink_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			FirebaseDynamicLinks firebaseDynamicLinks = Java.Lang.Object.GetObject<FirebaseDynamicLinks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri p = Java.Lang.Object.GetObject<Android.Net.Uri>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(firebaseDynamicLinks.GetDynamicLink(p));
		}

		[Register("getDynamicLink", "(Landroid/net/Uri;)Lcom/google/android/gms/tasks/Task;", "GetGetDynamicLink_Landroid_net_Uri_Handler")]
		public abstract Task GetDynamicLink(Android.Net.Uri p0);

		[Register("getInstance", "(Lcom/google/firebase/FirebaseApp;)Lcom/google/firebase/dynamiclinks/FirebaseDynamicLinks;", "")]
		public unsafe static FirebaseDynamicLinks GetInstance(FirebaseApp firebaseApp)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(firebaseApp?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<FirebaseDynamicLinks>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Lcom/google/firebase/FirebaseApp;)Lcom/google/firebase/dynamiclinks/FirebaseDynamicLinks;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(firebaseApp);
			}
		}
	}
	[Register("com/google/firebase/dynamiclinks/FirebaseDynamicLinks", DoNotGenerateAcw = true)]
	internal class FirebaseDynamicLinksInvoker : FirebaseDynamicLinks
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/FirebaseDynamicLinks", typeof(FirebaseDynamicLinksInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public FirebaseDynamicLinksInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("createDynamicLink", "()Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "GetCreateDynamicLinkHandler")]
		public unsafe override DynamicLink.Builder CreateDynamicLink()
		{
			return Java.Lang.Object.GetObject<DynamicLink.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("createDynamicLink.()Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getDynamicLink", "(Landroid/content/Intent;)Lcom/google/android/gms/tasks/Task;", "GetGetDynamicLink_Landroid_content_Intent_Handler")]
		public unsafe override Task GetDynamicLink(Intent p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDynamicLink.(Landroid/content/Intent;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("getDynamicLink", "(Landroid/net/Uri;)Lcom/google/android/gms/tasks/Task;", "GetGetDynamicLink_Landroid_net_Uri_Handler")]
		public unsafe override Task GetDynamicLink(Android.Net.Uri p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDynamicLink.(Landroid/net/Uri;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/firebase/dynamiclinks/PendingDynamicLinkData", DoNotGenerateAcw = true)]
	public class PendingDynamicLinkData : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/PendingDynamicLinkData", typeof(PendingDynamicLinkData));

		private static Delegate cb_getClickTimestamp;

		private static Delegate cb_getExtensions;

		private static Delegate cb_getLink;

		private static Delegate cb_getMinimumAppVersion;

		private static Delegate cb_getRedirectUrl;

		private static Delegate cb_getUtmParameters;

		private static Delegate cb_getUpdateAppIntent_Landroid_content_Context_;

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

		public unsafe virtual long ClickTimestamp
		{
			[Register("getClickTimestamp", "()J", "GetGetClickTimestampHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getClickTimestamp.()J", this, null);
			}
		}

		public unsafe virtual Bundle Extensions
		{
			[Register("getExtensions", "()Landroid/os/Bundle;", "GetGetExtensionsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExtensions.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Android.Net.Uri Link
		{
			[Register("getLink", "()Landroid/net/Uri;", "GetGetLinkHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLink.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int MinimumAppVersion
		{
			[Register("getMinimumAppVersion", "()I", "GetGetMinimumAppVersionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMinimumAppVersion.()I", this, null);
			}
		}

		public unsafe virtual Android.Net.Uri RedirectUrl
		{
			[Register("getRedirectUrl", "()Landroid/net/Uri;", "GetGetRedirectUrlHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRedirectUrl.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Bundle UtmParameters
		{
			[Register("getUtmParameters", "()Landroid/os/Bundle;", "GetGetUtmParametersHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getUtmParameters.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected PendingDynamicLinkData(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/firebase/dynamiclinks/internal/DynamicLinkData;)V", "")]
		public unsafe PendingDynamicLinkData(DynamicLinkData dynamicLinkData)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(dynamicLinkData?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/firebase/dynamiclinks/internal/DynamicLinkData;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/firebase/dynamiclinks/internal/DynamicLinkData;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dynamicLinkData);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;IJLandroid/net/Uri;)V", "")]
		protected unsafe PendingDynamicLinkData(string deepLink, int minVersion, long clickTimestamp, Android.Net.Uri redirectUrl)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(deepLink);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(minVersion);
				ptr[2] = new JniArgumentValue(clickTimestamp);
				ptr[3] = new JniArgumentValue(redirectUrl?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;IJLandroid/net/Uri;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;IJLandroid/net/Uri;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(redirectUrl);
			}
		}

		private static Delegate GetGetClickTimestampHandler()
		{
			if ((object)cb_getClickTimestamp == null)
			{
				cb_getClickTimestamp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetClickTimestamp));
			}
			return cb_getClickTimestamp;
		}

		private static long n_GetClickTimestamp(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<PendingDynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClickTimestamp;
		}

		private static Delegate GetGetExtensionsHandler()
		{
			if ((object)cb_getExtensions == null)
			{
				cb_getExtensions = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExtensions));
			}
			return cb_getExtensions;
		}

		private static IntPtr n_GetExtensions(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PendingDynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Extensions);
		}

		private static Delegate GetGetLinkHandler()
		{
			if ((object)cb_getLink == null)
			{
				cb_getLink = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLink));
			}
			return cb_getLink;
		}

		private static IntPtr n_GetLink(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PendingDynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Link);
		}

		private static Delegate GetGetMinimumAppVersionHandler()
		{
			if ((object)cb_getMinimumAppVersion == null)
			{
				cb_getMinimumAppVersion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMinimumAppVersion));
			}
			return cb_getMinimumAppVersion;
		}

		private static int n_GetMinimumAppVersion(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<PendingDynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumAppVersion;
		}

		private static Delegate GetGetRedirectUrlHandler()
		{
			if ((object)cb_getRedirectUrl == null)
			{
				cb_getRedirectUrl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRedirectUrl));
			}
			return cb_getRedirectUrl;
		}

		private static IntPtr n_GetRedirectUrl(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PendingDynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RedirectUrl);
		}

		private static Delegate GetGetUtmParametersHandler()
		{
			if ((object)cb_getUtmParameters == null)
			{
				cb_getUtmParameters = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUtmParameters));
			}
			return cb_getUtmParameters;
		}

		private static IntPtr n_GetUtmParameters(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PendingDynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UtmParameters);
		}

		private static Delegate GetGetUpdateAppIntent_Landroid_content_Context_Handler()
		{
			if ((object)cb_getUpdateAppIntent_Landroid_content_Context_ == null)
			{
				cb_getUpdateAppIntent_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetUpdateAppIntent_Landroid_content_Context_));
			}
			return cb_getUpdateAppIntent_Landroid_content_Context_;
		}

		private static IntPtr n_GetUpdateAppIntent_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			PendingDynamicLinkData pendingDynamicLinkData = Java.Lang.Object.GetObject<PendingDynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(pendingDynamicLinkData.GetUpdateAppIntent(context));
		}

		[Register("getUpdateAppIntent", "(Landroid/content/Context;)Landroid/content/Intent;", "GetGetUpdateAppIntent_Landroid_content_Context_Handler")]
		public unsafe virtual Intent GetUpdateAppIntent(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getUpdateAppIntent.(Landroid/content/Context;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}
	}
}
namespace Firebase.DynamicLinks.Internal
{
	[Register("com/google/firebase/dynamiclinks/internal/DynamicLinkData", DoNotGenerateAcw = true)]
	public class DynamicLinkData : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/internal/DynamicLinkData", typeof(DynamicLinkData));

		private static Delegate cb_getClickTimestamp;

		private static Delegate cb_setClickTimestamp_J;

		private static Delegate cb_getDeepLink;

		private static Delegate cb_setDeepLink_Ljava_lang_String_;

		private static Delegate cb_getDynamicLink;

		private static Delegate cb_setDynamicLink_Ljava_lang_String_;

		private static Delegate cb_getExtensionBundle;

		private static Delegate cb_getMinVersion;

		private static Delegate cb_setMinVersion_I;

		private static Delegate cb_getRedirectUrl;

		private static Delegate cb_setRedirectUrl_Landroid_net_Uri_;

		private static Delegate cb_setExtensionData_Landroid_os_Bundle_;

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe virtual long ClickTimestamp
		{
			[Register("getClickTimestamp", "()J", "GetGetClickTimestampHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getClickTimestamp.()J", this, null);
			}
			[Register("setClickTimestamp", "(J)V", "GetSetClickTimestamp_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setClickTimestamp.(J)V", this, ptr);
			}
		}

		public unsafe virtual string DeepLink
		{
			[Register("getDeepLink", "()Ljava/lang/String;", "GetGetDeepLinkHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDeepLink.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDeepLink", "(Ljava/lang/String;)V", "GetSetDeepLink_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDeepLink.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe virtual string DynamicLink
		{
			[Register("getDynamicLink", "()Ljava/lang/String;", "GetGetDynamicLinkHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDynamicLink.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDynamicLink", "(Ljava/lang/String;)V", "GetSetDynamicLink_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDynamicLink.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe virtual Bundle ExtensionBundle
		{
			[Register("getExtensionBundle", "()Landroid/os/Bundle;", "GetGetExtensionBundleHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExtensionBundle.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int MinVersion
		{
			[Register("getMinVersion", "()I", "GetGetMinVersionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMinVersion.()I", this, null);
			}
			[Register("setMinVersion", "(I)V", "GetSetMinVersion_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMinVersion.(I)V", this, ptr);
			}
		}

		public unsafe virtual Android.Net.Uri RedirectUrl
		{
			[Register("getRedirectUrl", "()Landroid/net/Uri;", "GetGetRedirectUrlHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRedirectUrl.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setRedirectUrl", "(Landroid/net/Uri;)V", "GetSetRedirectUrl_Landroid_net_Uri_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setRedirectUrl.(Landroid/net/Uri;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected DynamicLinkData(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;IJLandroid/os/Bundle;Landroid/net/Uri;)V", "")]
		public unsafe DynamicLinkData(string dynamicLink, string deepLink, int minVersion, long clickTimestamp, Bundle extensions, Android.Net.Uri redirectUrl)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(dynamicLink);
			IntPtr intPtr2 = JNIEnv.NewString(deepLink);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(minVersion);
				ptr[3] = new JniArgumentValue(clickTimestamp);
				ptr[4] = new JniArgumentValue(extensions?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue(redirectUrl?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;IJLandroid/os/Bundle;Landroid/net/Uri;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;IJLandroid/os/Bundle;Landroid/net/Uri;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(extensions);
				GC.KeepAlive(redirectUrl);
			}
		}

		private static Delegate GetGetClickTimestampHandler()
		{
			if ((object)cb_getClickTimestamp == null)
			{
				cb_getClickTimestamp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetClickTimestamp));
			}
			return cb_getClickTimestamp;
		}

		private static long n_GetClickTimestamp(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClickTimestamp;
		}

		private static Delegate GetSetClickTimestamp_JHandler()
		{
			if ((object)cb_setClickTimestamp_J == null)
			{
				cb_setClickTimestamp_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_SetClickTimestamp_J));
			}
			return cb_setClickTimestamp_J;
		}

		private static void n_SetClickTimestamp_J(IntPtr jnienv, IntPtr native__this, long timestamp)
		{
			Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClickTimestamp = timestamp;
		}

		private static Delegate GetGetDeepLinkHandler()
		{
			if ((object)cb_getDeepLink == null)
			{
				cb_getDeepLink = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDeepLink));
			}
			return cb_getDeepLink;
		}

		private static IntPtr n_GetDeepLink(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeepLink);
		}

		private static Delegate GetSetDeepLink_Ljava_lang_String_Handler()
		{
			if ((object)cb_setDeepLink_Ljava_lang_String_ == null)
			{
				cb_setDeepLink_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDeepLink_Ljava_lang_String_));
			}
			return cb_setDeepLink_Ljava_lang_String_;
		}

		private static void n_SetDeepLink_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_deepLink)
		{
			DynamicLinkData dynamicLinkData = Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string deepLink = JNIEnv.GetString(native_deepLink, JniHandleOwnership.DoNotTransfer);
			dynamicLinkData.DeepLink = deepLink;
		}

		private static Delegate GetGetDynamicLinkHandler()
		{
			if ((object)cb_getDynamicLink == null)
			{
				cb_getDynamicLink = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDynamicLink));
			}
			return cb_getDynamicLink;
		}

		private static IntPtr n_GetDynamicLink(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DynamicLink);
		}

		private static Delegate GetSetDynamicLink_Ljava_lang_String_Handler()
		{
			if ((object)cb_setDynamicLink_Ljava_lang_String_ == null)
			{
				cb_setDynamicLink_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDynamicLink_Ljava_lang_String_));
			}
			return cb_setDynamicLink_Ljava_lang_String_;
		}

		private static void n_SetDynamicLink_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_dynamicLink)
		{
			DynamicLinkData dynamicLinkData = Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string dynamicLink = JNIEnv.GetString(native_dynamicLink, JniHandleOwnership.DoNotTransfer);
			dynamicLinkData.DynamicLink = dynamicLink;
		}

		private static Delegate GetGetExtensionBundleHandler()
		{
			if ((object)cb_getExtensionBundle == null)
			{
				cb_getExtensionBundle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExtensionBundle));
			}
			return cb_getExtensionBundle;
		}

		private static IntPtr n_GetExtensionBundle(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExtensionBundle);
		}

		private static Delegate GetGetMinVersionHandler()
		{
			if ((object)cb_getMinVersion == null)
			{
				cb_getMinVersion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMinVersion));
			}
			return cb_getMinVersion;
		}

		private static int n_GetMinVersion(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinVersion;
		}

		private static Delegate GetSetMinVersion_IHandler()
		{
			if ((object)cb_setMinVersion_I == null)
			{
				cb_setMinVersion_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMinVersion_I));
			}
			return cb_setMinVersion_I;
		}

		private static void n_SetMinVersion_I(IntPtr jnienv, IntPtr native__this, int minVersion)
		{
			Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinVersion = minVersion;
		}

		private static Delegate GetGetRedirectUrlHandler()
		{
			if ((object)cb_getRedirectUrl == null)
			{
				cb_getRedirectUrl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRedirectUrl));
			}
			return cb_getRedirectUrl;
		}

		private static IntPtr n_GetRedirectUrl(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RedirectUrl);
		}

		private static Delegate GetSetRedirectUrl_Landroid_net_Uri_Handler()
		{
			if ((object)cb_setRedirectUrl_Landroid_net_Uri_ == null)
			{
				cb_setRedirectUrl_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetRedirectUrl_Landroid_net_Uri_));
			}
			return cb_setRedirectUrl_Landroid_net_Uri_;
		}

		private static void n_SetRedirectUrl_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_redirectUrl)
		{
			DynamicLinkData dynamicLinkData = Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri redirectUrl = Java.Lang.Object.GetObject<Android.Net.Uri>(native_redirectUrl, JniHandleOwnership.DoNotTransfer);
			dynamicLinkData.RedirectUrl = redirectUrl;
		}

		private static Delegate GetSetExtensionData_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_setExtensionData_Landroid_os_Bundle_ == null)
			{
				cb_setExtensionData_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetExtensionData_Landroid_os_Bundle_));
			}
			return cb_setExtensionData_Landroid_os_Bundle_;
		}

		private static void n_SetExtensionData_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_bundle)
		{
			DynamicLinkData dynamicLinkData = Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle extensionData = Java.Lang.Object.GetObject<Bundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			dynamicLinkData.SetExtensionData(extensionData);
		}

		[Register("setExtensionData", "(Landroid/os/Bundle;)V", "GetSetExtensionData_Landroid_os_Bundle_Handler")]
		public unsafe virtual void SetExtensionData(Bundle bundle)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setExtensionData.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bundle);
			}
		}

		private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
		{
			if ((object)cb_writeToParcel_Landroid_os_Parcel_I == null)
			{
				cb_writeToParcel_Landroid_os_Parcel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I));
			}
			return cb_writeToParcel_Landroid_os_Parcel_I;
		}

		private static void n_WriteToParcel_Landroid_os_Parcel_I(IntPtr jnienv, IntPtr native__this, IntPtr native_dest, int native_flags)
		{
			DynamicLinkData dynamicLinkData = Java.Lang.Object.GetObject<DynamicLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			dynamicLinkData.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dest);
			}
		}
	}
	[Register("com/google/firebase/dynamiclinks/internal/FirebaseDynamicLinksImpl", DoNotGenerateAcw = true)]
	public class FirebaseDynamicLinksImpl : FirebaseDynamicLinks
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/dynamiclinks/internal/FirebaseDynamicLinksImpl", typeof(FirebaseDynamicLinksImpl));

		private static Delegate cb_getFirebaseApp;

		private static Delegate cb_createDynamicLink;

		private static Delegate cb_createShortDynamicLink_Landroid_os_Bundle_;

		private static Delegate cb_getDynamicLink_Landroid_content_Intent_;

		private static Delegate cb_getDynamicLink_Landroid_net_Uri_;

		private static Delegate cb_getPendingDynamicLinkData_Landroid_content_Intent_;

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

		public unsafe virtual FirebaseApp FirebaseApp
		{
			[Register("getFirebaseApp", "()Lcom/google/firebase/FirebaseApp;", "GetGetFirebaseAppHandler")]
			get
			{
				return Java.Lang.Object.GetObject<FirebaseApp>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFirebaseApp.()Lcom/google/firebase/FirebaseApp;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected FirebaseDynamicLinksImpl(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/api/GoogleApi;Lcom/google/firebase/FirebaseApp;Lcom/google/firebase/inject/Provider;)V", "")]
		public unsafe FirebaseDynamicLinksImpl(GoogleApi googleApi, FirebaseApp firebaseApp, IProvider analytics)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(googleApi?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(firebaseApp?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((analytics == null) ? IntPtr.Zero : ((Java.Lang.Object)analytics).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/api/GoogleApi;Lcom/google/firebase/FirebaseApp;Lcom/google/firebase/inject/Provider;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/api/GoogleApi;Lcom/google/firebase/FirebaseApp;Lcom/google/firebase/inject/Provider;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(googleApi);
				GC.KeepAlive(firebaseApp);
				GC.KeepAlive(analytics);
			}
		}

		[Register(".ctor", "(Lcom/google/firebase/FirebaseApp;Lcom/google/firebase/inject/Provider;)V", "")]
		public unsafe FirebaseDynamicLinksImpl(FirebaseApp firebaseApp, IProvider analytics)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(firebaseApp?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((analytics == null) ? IntPtr.Zero : ((Java.Lang.Object)analytics).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/firebase/FirebaseApp;Lcom/google/firebase/inject/Provider;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/firebase/FirebaseApp;Lcom/google/firebase/inject/Provider;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(firebaseApp);
				GC.KeepAlive(analytics);
			}
		}

		private static Delegate GetGetFirebaseAppHandler()
		{
			if ((object)cb_getFirebaseApp == null)
			{
				cb_getFirebaseApp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFirebaseApp));
			}
			return cb_getFirebaseApp;
		}

		private static IntPtr n_GetFirebaseApp(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FirebaseDynamicLinksImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FirebaseApp);
		}

		private static Delegate GetCreateDynamicLinkHandler()
		{
			if ((object)cb_createDynamicLink == null)
			{
				cb_createDynamicLink = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateDynamicLink));
			}
			return cb_createDynamicLink;
		}

		private static IntPtr n_CreateDynamicLink(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FirebaseDynamicLinksImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateDynamicLink());
		}

		[Register("createDynamicLink", "()Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", "GetCreateDynamicLinkHandler")]
		public unsafe override DynamicLink.Builder CreateDynamicLink()
		{
			return Java.Lang.Object.GetObject<DynamicLink.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("createDynamicLink.()Lcom/google/firebase/dynamiclinks/DynamicLink$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("createDynamicLink", "(Landroid/os/Bundle;)Landroid/net/Uri;", "")]
		public unsafe static Android.Net.Uri CreateDynamicLink(Bundle builderParameters)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(builderParameters?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.StaticMethods.InvokeObjectMethod("createDynamicLink.(Landroid/os/Bundle;)Landroid/net/Uri;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(builderParameters);
			}
		}

		private static Delegate GetCreateShortDynamicLink_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_createShortDynamicLink_Landroid_os_Bundle_ == null)
			{
				cb_createShortDynamicLink_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateShortDynamicLink_Landroid_os_Bundle_));
			}
			return cb_createShortDynamicLink_Landroid_os_Bundle_;
		}

		private static IntPtr n_CreateShortDynamicLink_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_builderParameters)
		{
			FirebaseDynamicLinksImpl firebaseDynamicLinksImpl = Java.Lang.Object.GetObject<FirebaseDynamicLinksImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle builderParameters = Java.Lang.Object.GetObject<Bundle>(native_builderParameters, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(firebaseDynamicLinksImpl.CreateShortDynamicLink(builderParameters));
		}

		[Register("createShortDynamicLink", "(Landroid/os/Bundle;)Lcom/google/android/gms/tasks/Task;", "GetCreateShortDynamicLink_Landroid_os_Bundle_Handler")]
		public unsafe virtual Task CreateShortDynamicLink(Bundle builderParameters)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(builderParameters?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("createShortDynamicLink.(Landroid/os/Bundle;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(builderParameters);
			}
		}

		private static Delegate GetGetDynamicLink_Landroid_content_Intent_Handler()
		{
			if ((object)cb_getDynamicLink_Landroid_content_Intent_ == null)
			{
				cb_getDynamicLink_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetDynamicLink_Landroid_content_Intent_));
			}
			return cb_getDynamicLink_Landroid_content_Intent_;
		}

		private static IntPtr n_GetDynamicLink_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_intent)
		{
			FirebaseDynamicLinksImpl firebaseDynamicLinksImpl = Java.Lang.Object.GetObject<FirebaseDynamicLinksImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent p = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(firebaseDynamicLinksImpl.GetDynamicLink(p));
		}

		[Register("getDynamicLink", "(Landroid/content/Intent;)Lcom/google/android/gms/tasks/Task;", "GetGetDynamicLink_Landroid_content_Intent_Handler")]
		public unsafe override Task GetDynamicLink(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDynamicLink.(Landroid/content/Intent;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}

		private static Delegate GetGetDynamicLink_Landroid_net_Uri_Handler()
		{
			if ((object)cb_getDynamicLink_Landroid_net_Uri_ == null)
			{
				cb_getDynamicLink_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetDynamicLink_Landroid_net_Uri_));
			}
			return cb_getDynamicLink_Landroid_net_Uri_;
		}

		private static IntPtr n_GetDynamicLink_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_dynamicLinkUri)
		{
			FirebaseDynamicLinksImpl firebaseDynamicLinksImpl = Java.Lang.Object.GetObject<FirebaseDynamicLinksImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri p = Java.Lang.Object.GetObject<Android.Net.Uri>(native_dynamicLinkUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(firebaseDynamicLinksImpl.GetDynamicLink(p));
		}

		[Register("getDynamicLink", "(Landroid/net/Uri;)Lcom/google/android/gms/tasks/Task;", "GetGetDynamicLink_Landroid_net_Uri_Handler")]
		public unsafe override Task GetDynamicLink(Android.Net.Uri dynamicLinkUri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(dynamicLinkUri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDynamicLink.(Landroid/net/Uri;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(dynamicLinkUri);
			}
		}

		private static Delegate GetGetPendingDynamicLinkData_Landroid_content_Intent_Handler()
		{
			if ((object)cb_getPendingDynamicLinkData_Landroid_content_Intent_ == null)
			{
				cb_getPendingDynamicLinkData_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetPendingDynamicLinkData_Landroid_content_Intent_));
			}
			return cb_getPendingDynamicLinkData_Landroid_content_Intent_;
		}

		private static IntPtr n_GetPendingDynamicLinkData_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_intent)
		{
			FirebaseDynamicLinksImpl firebaseDynamicLinksImpl = Java.Lang.Object.GetObject<FirebaseDynamicLinksImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(firebaseDynamicLinksImpl.GetPendingDynamicLinkData(intent));
		}

		[Register("getPendingDynamicLinkData", "(Landroid/content/Intent;)Lcom/google/firebase/dynamiclinks/PendingDynamicLinkData;", "GetGetPendingDynamicLinkData_Landroid_content_Intent_Handler")]
		public unsafe virtual PendingDynamicLinkData GetPendingDynamicLinkData(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PendingDynamicLinkData>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPendingDynamicLinkData.(Landroid/content/Intent;)Lcom/google/firebase/dynamiclinks/PendingDynamicLinkData;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}

		[Register("verifyDomainUriPrefix", "(Landroid/os/Bundle;)V", "")]
		public unsafe static void VerifyDomainUriPrefix(Bundle builderParameters)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(builderParameters?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("verifyDomainUriPrefix.(Landroid/os/Bundle;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(builderParameters);
			}
		}
	}
}
