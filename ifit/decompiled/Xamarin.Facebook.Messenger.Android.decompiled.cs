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
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "{BUILD_COMMIT}")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "{BUILD_NUMBER}")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "{BUILD_TIMESTAMP}")]
[assembly: NamespaceMapping(Java = "com.facebook.messenger", Managed = "Xamarin.Facebook.Messenger")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for Facebook Android - Messenger")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Facebook.Messenger.Android")]
[assembly: AssemblyTitle("Xamarin.Facebook.Messenger.Android")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
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
namespace Xamarin.Facebook.Messenger
{
	[Register("com/facebook/messenger/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("LIBRARY_PACKAGE_NAME")]
		public const string LibraryPackageName = "com.facebook.messenger";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/messenger/BuildConfig", typeof(BuildConfig));

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
	[Register("com/facebook/messenger/Messenger", DoNotGenerateAcw = true)]
	public class Messenger : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/messenger/Messenger", typeof(Messenger));

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

		protected Messenger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Messenger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/messenger/MessengerThreadParams", DoNotGenerateAcw = true)]
	public class MessengerThreadParams : Java.Lang.Object
	{
		[Register("com/facebook/messenger/MessengerThreadParams$Origin", DoNotGenerateAcw = true)]
		public sealed class Origin : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/messenger/MessengerThreadParams$Origin", typeof(Origin));

			[Register("COMPOSE_FLOW")]
			public static Origin ComposeFlow => Java.Lang.Object.GetObject<Origin>(_members.StaticFields.GetObjectValue("COMPOSE_FLOW.Lcom/facebook/messenger/MessengerThreadParams$Origin;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("REPLY_FLOW")]
			public static Origin ReplyFlow => Java.Lang.Object.GetObject<Origin>(_members.StaticFields.GetObjectValue("REPLY_FLOW.Lcom/facebook/messenger/MessengerThreadParams$Origin;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("UNKNOWN")]
			public static Origin Unknown => Java.Lang.Object.GetObject<Origin>(_members.StaticFields.GetObjectValue("UNKNOWN.Lcom/facebook/messenger/MessengerThreadParams$Origin;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal Origin(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/messenger/MessengerThreadParams$Origin;", "")]
			public unsafe static Origin ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Origin>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/messenger/MessengerThreadParams$Origin;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/facebook/messenger/MessengerThreadParams$Origin;", "")]
			public unsafe static Origin[] Values()
			{
				return (Origin[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/messenger/MessengerThreadParams$Origin;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Origin));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/messenger/MessengerThreadParams", typeof(MessengerThreadParams));

		[Register("metadata")]
		public string Metadata
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("metadata.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("metadata.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("participants")]
		public IList Participants
		{
			get
			{
				return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("participants.Ljava/util/List;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JavaList.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("participants.Ljava/util/List;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("threadToken")]
		public string ThreadToken
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("threadToken.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("threadToken.Ljava/lang/String;", this, new JniObjectReference(jobject));
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

		protected MessengerThreadParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/messenger/MessengerThreadParams$Origin;Ljava/lang/String;Ljava/lang/String;Ljava/util/List;)V", "")]
		public unsafe MessengerThreadParams(Origin origin, string threadToken, string metadata, IList<string> participants)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(threadToken);
			IntPtr intPtr2 = JNIEnv.NewString(metadata);
			IntPtr intPtr3 = JavaList<string>.ToLocalJniHandle(participants);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(origin?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue(intPtr3);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/messenger/MessengerThreadParams$Origin;Ljava/lang/String;Ljava/lang/String;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/messenger/MessengerThreadParams$Origin;Ljava/lang/String;Ljava/lang/String;Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				GC.KeepAlive(origin);
				GC.KeepAlive(participants);
			}
		}
	}
	[Register("com/facebook/messenger/MessengerUtils", DoNotGenerateAcw = true)]
	public class MessengerUtils : Java.Lang.Object
	{
		[Register("EXTRA_APP_ID")]
		public const string ExtraAppId = "com.facebook.orca.extra.APPLICATION_ID";

		[Register("EXTRA_EXTERNAL_URI")]
		public const string ExtraExternalUri = "com.facebook.orca.extra.EXTERNAL_URI";

		[Register("EXTRA_IS_COMPOSE")]
		public const string ExtraIsCompose = "com.facebook.orca.extra.IS_COMPOSE";

		[Register("EXTRA_IS_REPLY")]
		public const string ExtraIsReply = "com.facebook.orca.extra.IS_REPLY";

		[Register("EXTRA_METADATA")]
		public const string ExtraMetadata = "com.facebook.orca.extra.METADATA";

		[Register("EXTRA_PARTICIPANTS")]
		public const string ExtraParticipants = "com.facebook.orca.extra.PARTICIPANTS";

		[Register("EXTRA_PROTOCOL_VERSION")]
		public const string ExtraProtocolVersion = "com.facebook.orca.extra.PROTOCOL_VERSION";

		[Register("EXTRA_REPLY_TOKEN_KEY")]
		public const string ExtraReplyTokenKey = "com.facebook.orca.extra.REPLY_TOKEN";

		[Register("EXTRA_THREAD_TOKEN_KEY")]
		public const string ExtraThreadTokenKey = "com.facebook.orca.extra.THREAD_TOKEN";

		[Register("ORCA_THREAD_CATEGORY_20150314")]
		public const string OrcaThreadCategory20150314 = "com.facebook.orca.category.PLATFORM_THREAD_20150314";

		[Register("PACKAGE_NAME")]
		public const string PackageName = "com.facebook.orca";

		[Register("PROTOCOL_VERSION_20150314")]
		public const int ProtocolVersion20150314 = 20150314;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/messenger/MessengerUtils", typeof(MessengerUtils));

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

		protected MessengerUtils(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe MessengerUtils()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("finishShareToMessenger", "(Landroid/app/Activity;Lcom/facebook/messenger/ShareToMessengerParams;)V", "")]
		public unsafe static void FinishShareToMessenger(Activity activity, ShareToMessengerParams shareToMessengerParams)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(shareToMessengerParams?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("finishShareToMessenger.(Landroid/app/Activity;Lcom/facebook/messenger/ShareToMessengerParams;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(shareToMessengerParams);
			}
		}

		[Register("getMessengerThreadParamsForIntent", "(Landroid/content/Intent;)Lcom/facebook/messenger/MessengerThreadParams;", "")]
		public unsafe static MessengerThreadParams GetMessengerThreadParamsForIntent(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<MessengerThreadParams>(_members.StaticMethods.InvokeObjectMethod("getMessengerThreadParamsForIntent.(Landroid/content/Intent;)Lcom/facebook/messenger/MessengerThreadParams;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}

		[Register("hasMessengerInstalled", "(Landroid/content/Context;)Z", "")]
		public unsafe static bool HasMessengerInstalled(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("hasMessengerInstalled.(Landroid/content/Context;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("openMessengerInPlayStore", "(Landroid/content/Context;)V", "")]
		public unsafe static void OpenMessengerInPlayStore(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("openMessengerInPlayStore.(Landroid/content/Context;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("shareToMessenger", "(Landroid/app/Activity;ILcom/facebook/messenger/ShareToMessengerParams;)V", "")]
		public unsafe static void ShareToMessenger(Activity activity, int requestCode, ShareToMessengerParams shareToMessengerParams)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				ptr[2] = new JniArgumentValue(shareToMessengerParams?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("shareToMessenger.(Landroid/app/Activity;ILcom/facebook/messenger/ShareToMessengerParams;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(shareToMessengerParams);
			}
		}
	}
	[Register("com/facebook/messenger/ShareToMessengerParams", DoNotGenerateAcw = true)]
	public class ShareToMessengerParams : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/messenger/ShareToMessengerParams", typeof(ShareToMessengerParams));

		[Register("externalUri")]
		public Android.Net.Uri ExternalUri
		{
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceFields.GetObjectValue("externalUri.Landroid/net/Uri;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("externalUri.Landroid/net/Uri;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("metaData")]
		public string MetaData
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("metaData.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("metaData.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mimeType")]
		public string MimeType
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mimeType.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("mimeType.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("uri")]
		public Android.Net.Uri Uri
		{
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceFields.GetObjectValue("uri.Landroid/net/Uri;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("uri.Landroid/net/Uri;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("VALID_EXTERNAL_URI_SCHEMES")]
		public static ICollection ValidExternalUriSchemes => JavaSet.FromJniHandle(_members.StaticFields.GetObjectValue("VALID_EXTERNAL_URI_SCHEMES.Ljava/util/Set;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("VALID_MIME_TYPES")]
		public static ICollection ValidMimeTypes => JavaSet.FromJniHandle(_members.StaticFields.GetObjectValue("VALID_MIME_TYPES.Ljava/util/Set;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("VALID_URI_SCHEMES")]
		public static ICollection ValidUriSchemes => JavaSet.FromJniHandle(_members.StaticFields.GetObjectValue("VALID_URI_SCHEMES.Ljava/util/Set;").Handle, JniHandleOwnership.TransferLocalRef);

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

		protected ShareToMessengerParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("newBuilder", "(Landroid/net/Uri;Ljava/lang/String;)Lcom/facebook/messenger/ShareToMessengerParamsBuilder;", "")]
		public unsafe static ShareToMessengerParamsBuilder NewBuilder(Android.Net.Uri uri, string mimeType)
		{
			IntPtr intPtr = JNIEnv.NewString(mimeType);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ShareToMessengerParamsBuilder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.(Landroid/net/Uri;Ljava/lang/String;)Lcom/facebook/messenger/ShareToMessengerParamsBuilder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(uri);
			}
		}
	}
	[Register("com/facebook/messenger/ShareToMessengerParamsBuilder", DoNotGenerateAcw = true)]
	public class ShareToMessengerParamsBuilder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/messenger/ShareToMessengerParamsBuilder", typeof(ShareToMessengerParamsBuilder));

		private static Delegate cb_getExternalUri;

		private static Delegate cb_getMetaData;

		private static Delegate cb_getMimeType;

		private static Delegate cb_getUri;

		private static Delegate cb_build;

		private static Delegate cb_setExternalUri_Landroid_net_Uri_;

		private static Delegate cb_setMetaData_Ljava_lang_String_;

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

		public unsafe virtual Android.Net.Uri ExternalUri
		{
			[Register("getExternalUri", "()Landroid/net/Uri;", "GetGetExternalUriHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExternalUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string MetaData
		{
			[Register("getMetaData", "()Ljava/lang/String;", "GetGetMetaDataHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMetaData.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string MimeType
		{
			[Register("getMimeType", "()Ljava/lang/String;", "GetGetMimeTypeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMimeType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Android.Net.Uri Uri
		{
			[Register("getUri", "()Landroid/net/Uri;", "GetGetUriHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ShareToMessengerParamsBuilder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetExternalUriHandler()
		{
			if ((object)cb_getExternalUri == null)
			{
				cb_getExternalUri = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExternalUri));
			}
			return cb_getExternalUri;
		}

		private static IntPtr n_GetExternalUri(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareToMessengerParamsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExternalUri);
		}

		private static Delegate GetGetMetaDataHandler()
		{
			if ((object)cb_getMetaData == null)
			{
				cb_getMetaData = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMetaData));
			}
			return cb_getMetaData;
		}

		private static IntPtr n_GetMetaData(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ShareToMessengerParamsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MetaData);
		}

		private static Delegate GetGetMimeTypeHandler()
		{
			if ((object)cb_getMimeType == null)
			{
				cb_getMimeType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMimeType));
			}
			return cb_getMimeType;
		}

		private static IntPtr n_GetMimeType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ShareToMessengerParamsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MimeType);
		}

		private static Delegate GetGetUriHandler()
		{
			if ((object)cb_getUri == null)
			{
				cb_getUri = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUri));
			}
			return cb_getUri;
		}

		private static IntPtr n_GetUri(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareToMessengerParamsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Uri);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareToMessengerParamsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Lcom/facebook/messenger/ShareToMessengerParams;", "GetBuildHandler")]
		public unsafe virtual ShareToMessengerParams Build()
		{
			return Java.Lang.Object.GetObject<ShareToMessengerParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/facebook/messenger/ShareToMessengerParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetExternalUri_Landroid_net_Uri_Handler()
		{
			if ((object)cb_setExternalUri_Landroid_net_Uri_ == null)
			{
				cb_setExternalUri_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetExternalUri_Landroid_net_Uri_));
			}
			return cb_setExternalUri_Landroid_net_Uri_;
		}

		private static IntPtr n_SetExternalUri_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_externalUri)
		{
			ShareToMessengerParamsBuilder shareToMessengerParamsBuilder = Java.Lang.Object.GetObject<ShareToMessengerParamsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri externalUri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_externalUri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(shareToMessengerParamsBuilder.SetExternalUri(externalUri));
		}

		[Register("setExternalUri", "(Landroid/net/Uri;)Lcom/facebook/messenger/ShareToMessengerParamsBuilder;", "GetSetExternalUri_Landroid_net_Uri_Handler")]
		public unsafe virtual ShareToMessengerParamsBuilder SetExternalUri(Android.Net.Uri externalUri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(externalUri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ShareToMessengerParamsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setExternalUri.(Landroid/net/Uri;)Lcom/facebook/messenger/ShareToMessengerParamsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(externalUri);
			}
		}

		private static Delegate GetSetMetaData_Ljava_lang_String_Handler()
		{
			if ((object)cb_setMetaData_Ljava_lang_String_ == null)
			{
				cb_setMetaData_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetMetaData_Ljava_lang_String_));
			}
			return cb_setMetaData_Ljava_lang_String_;
		}

		private static IntPtr n_SetMetaData_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_metaData)
		{
			ShareToMessengerParamsBuilder shareToMessengerParamsBuilder = Java.Lang.Object.GetObject<ShareToMessengerParamsBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string metaData = JNIEnv.GetString(native_metaData, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(shareToMessengerParamsBuilder.SetMetaData(metaData));
		}

		[Register("setMetaData", "(Ljava/lang/String;)Lcom/facebook/messenger/ShareToMessengerParamsBuilder;", "GetSetMetaData_Ljava_lang_String_Handler")]
		public unsafe virtual ShareToMessengerParamsBuilder SetMetaData(string metaData)
		{
			IntPtr intPtr = JNIEnv.NewString(metaData);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ShareToMessengerParamsBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMetaData.(Ljava/lang/String;)Lcom/facebook/messenger/ShareToMessengerParamsBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_facebook_messenger_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "com/facebook/messenger" }, new Converter<string, Type>[1] { lookup_com_facebook_messenger_package });
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

		private static Type lookup_com_facebook_messenger_package(string klass)
		{
			if (package_com_facebook_messenger_mappings == null)
			{
				package_com_facebook_messenger_mappings = new string[7] { "com/facebook/messenger/BuildConfig:Xamarin.Facebook.Messenger.BuildConfig", "com/facebook/messenger/Messenger:Xamarin.Facebook.Messenger.Messenger", "com/facebook/messenger/MessengerThreadParams:Xamarin.Facebook.Messenger.MessengerThreadParams", "com/facebook/messenger/MessengerThreadParams$Origin:Xamarin.Facebook.Messenger.MessengerThreadParams/Origin", "com/facebook/messenger/MessengerUtils:Xamarin.Facebook.Messenger.MessengerUtils", "com/facebook/messenger/ShareToMessengerParams:Xamarin.Facebook.Messenger.ShareToMessengerParams", "com/facebook/messenger/ShareToMessengerParamsBuilder:Xamarin.Facebook.Messenger.ShareToMessengerParamsBuilder" };
			}
			return Lookup(package_com_facebook_messenger_mappings, klass);
		}
	}
}
