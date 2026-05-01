using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.Activity.Result;
using AndroidX.Browser.CustomTabs;
using AndroidX.Fragment.App;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Util;
using Java.Util.Concurrent;
using Kotlin.Jvm.Internal;
using Org.Json;
using Xamarin.Facebook.Internal;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Share.Model;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "{BUILD_COMMIT}")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "{BUILD_NUMBER}")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "{BUILD_TIMESTAMP}")]
[assembly: NamespaceMapping(Java = "com.facebook", Managed = "Xamarin.Facebook")]
[assembly: NamespaceMapping(Java = "com.facebook.common", Managed = "Xamarin.Facebook.Common")]
[assembly: NamespaceMapping(Java = "com.facebook.devicerequests.internal", Managed = "Xamarin.Facebook.DeviceRequests.Internal")]
[assembly: NamespaceMapping(Java = "com.facebook.internal", Managed = "Xamarin.Facebook.Internal")]
[assembly: NamespaceMapping(Java = "com.facebook.internal.logging.dumpsys", Managed = "Com.Facebook.Internal.Logging.Dumpsys")]
[assembly: NamespaceMapping(Java = "com.facebook.login", Managed = "Xamarin.Facebook.Login")]
[assembly: NamespaceMapping(Java = "com.facebook.share", Managed = "Xamarin.Facebook.Share")]
[assembly: NamespaceMapping(Java = "com.facebook.share.model", Managed = "Xamarin.Facebook.Share.Model")]
[assembly: NamespaceMapping(Java = "com.facebook.share.widget", Managed = "Xamarin.Facebook.Share.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for Facebook Android - Common")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Facebook.Common.Android")]
[assembly: AssemblyTitle("Xamarin.Facebook.Common.Android")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PPIIL_Z(IntPtr jnienv, IntPtr klass, int p0, int p1, IntPtr p2);
internal delegate bool _JniMarshal_PPILL_Z(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate double _JniMarshal_PPLD_D(IntPtr jnienv, IntPtr klass, IntPtr p0, double p1);
internal delegate IntPtr _JniMarshal_PPLD_L(IntPtr jnienv, IntPtr klass, IntPtr p0, double p1);
internal delegate int _JniMarshal_PPLI_I(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate IntPtr _JniMarshal_PPLI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate bool _JniMarshal_PPLI_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate long _JniMarshal_PPLJ_J(IntPtr jnienv, IntPtr klass, IntPtr p0, long p1);
internal delegate IntPtr _JniMarshal_PPLJ_L(IntPtr jnienv, IntPtr klass, IntPtr p0, long p1);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate bool _JniMarshal_PPLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2);
internal delegate void _JniMarshal_PPLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate bool _JniMarshal_PPLLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate void _JniMarshal_PPLLLLLLLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4, IntPtr p5, IntPtr p6, IntPtr p7, IntPtr p8, IntPtr p9);
internal delegate IntPtr _JniMarshal_PPLZ_L(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate bool _JniMarshal_PPLZ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate int _JniMarshal_PPZ_I(IntPtr jnienv, IntPtr klass, bool p0);
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
		private static string[] package_com_facebook_mappings;

		private static string[] package_com_facebook_common_mappings;

		private static string[] package_com_facebook_devicerequests_internal_mappings;

		private static string[] package_com_facebook_internal_mappings;

		private static string[] package_com_facebook_internal_logging_dumpsys_mappings;

		private static string[] package_com_facebook_login_mappings;

		private static string[] package_com_facebook_share_model_mappings;

		private static string[] package_com_facebook_share_mappings;

		private static string[] package_com_facebook_share_widget_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[9] { "com/facebook", "com/facebook/common", "com/facebook/devicerequests/internal", "com/facebook/internal", "com/facebook/internal/logging/dumpsys", "com/facebook/login", "com/facebook/share/model", "com/facebook/share", "com/facebook/share/widget" }, new Converter<string, Type>[9] { lookup_com_facebook_package, lookup_com_facebook_common_package, lookup_com_facebook_devicerequests_internal_package, lookup_com_facebook_internal_package, lookup_com_facebook_internal_logging_dumpsys_package, lookup_com_facebook_login_package, lookup_com_facebook_share_model_package, lookup_com_facebook_share_package, lookup_com_facebook_share_widget_package });
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

		private static Type lookup_com_facebook_package(string klass)
		{
			if (package_com_facebook_mappings == null)
			{
				package_com_facebook_mappings = new string[17]
				{
					"com/facebook/AccessTokenTracker:Xamarin.Facebook.AccessTokenTracker", "com/facebook/AccessTokenTracker$Companion:Xamarin.Facebook.AccessTokenTracker/Companion", "com/facebook/AuthenticationTokenTracker:Xamarin.Facebook.AuthenticationTokenTracker", "com/facebook/AuthenticationTokenTracker$Companion:Xamarin.Facebook.AuthenticationTokenTracker/Companion", "com/facebook/CustomTabActivity:Xamarin.Facebook.CustomTabActivity", "com/facebook/CustomTabActivity$Companion:Xamarin.Facebook.CustomTabActivity/Companion", "com/facebook/CustomTabMainActivity:Xamarin.Facebook.CustomTabMainActivity", "com/facebook/CustomTabMainActivity$Companion:Xamarin.Facebook.CustomTabMainActivity/Companion", "com/facebook/CustomTabMainActivity$WhenMappings:Xamarin.Facebook.CustomTabMainActivity/WhenMappings", "com/facebook/FacebookActivity:Xamarin.Facebook.FacebookActivity",
					"com/facebook/FacebookActivity$Companion:Xamarin.Facebook.FacebookActivity/Companion", "com/facebook/FacebookAuthorizationException:Xamarin.Facebook.FacebookAuthorizationException", "com/facebook/FacebookAuthorizationException$Companion:Xamarin.Facebook.FacebookAuthorizationException/Companion", "com/facebook/FacebookButtonBase:Xamarin.Facebook.FacebookButtonBase", "com/facebook/FacebookDialogException:Xamarin.Facebook.FacebookDialogException", "com/facebook/FacebookDialogException$Companion:Xamarin.Facebook.FacebookDialogException/Companion", "com/facebook/WebDialog:Xamarin.Facebook.WebDialog"
				};
			}
			return Lookup(package_com_facebook_mappings, klass);
		}

		private static Type lookup_com_facebook_common_package(string klass)
		{
			if (package_com_facebook_common_mappings == null)
			{
				package_com_facebook_common_mappings = new string[2] { "com/facebook/common/BuildConfig:Xamarin.Facebook.Common.BuildConfig", "com/facebook/common/Common:Xamarin.Facebook.Common.Common" };
			}
			return Lookup(package_com_facebook_common_mappings, klass);
		}

		private static Type lookup_com_facebook_devicerequests_internal_package(string klass)
		{
			if (package_com_facebook_devicerequests_internal_mappings == null)
			{
				package_com_facebook_devicerequests_internal_mappings = new string[1] { "com/facebook/devicerequests/internal/DeviceRequestsHelper:Xamarin.Facebook.DeviceRequests.Internal.DeviceRequestsHelper" };
			}
			return Lookup(package_com_facebook_devicerequests_internal_mappings, klass);
		}

		private static Type lookup_com_facebook_internal_package(string klass)
		{
			if (package_com_facebook_internal_mappings == null)
			{
				package_com_facebook_internal_mappings = new string[22]
				{
					"com/facebook/internal/AppCall:Xamarin.Facebook.Internal.AppCall", "com/facebook/internal/AppCall$Companion:Xamarin.Facebook.Internal.AppCall/Companion", "com/facebook/internal/CustomTab:Xamarin.Facebook.Internal.CustomTab", "com/facebook/internal/CustomTab$Companion:Xamarin.Facebook.Internal.CustomTab/Companion", "com/facebook/internal/CustomTabUtils:Xamarin.Facebook.Internal.CustomTabUtils", "com/facebook/internal/DialogFeature$DefaultImpls:Xamarin.Facebook.Internal.DialogFeatureDefaultImpls", "com/facebook/internal/DialogPresenter:Xamarin.Facebook.Internal.DialogPresenter", "com/facebook/internal/FacebookDialogBase:Xamarin.Facebook.Internal.FacebookDialogBase", "com/facebook/internal/FacebookDialogBase$Companion:Xamarin.Facebook.Internal.FacebookDialogBase/Companion", "com/facebook/internal/FacebookDialogBase$ModeHandler:Xamarin.Facebook.Internal.FacebookDialogBase/ModeHandler",
					"com/facebook/internal/FacebookDialogFragment:Xamarin.Facebook.Internal.FacebookDialogFragment", "com/facebook/internal/FacebookDialogFragment$Companion:Xamarin.Facebook.Internal.FacebookDialogFragment/Companion", "com/facebook/internal/FacebookWebFallbackDialog:Xamarin.Facebook.Internal.FacebookWebFallbackDialog", "com/facebook/internal/FacebookWebFallbackDialog$Companion:Xamarin.Facebook.Internal.FacebookWebFallbackDialog/Companion", "com/facebook/internal/FragmentWrapper:Xamarin.Facebook.Internal.FragmentWrapper", "com/facebook/internal/InstagramCustomTab:Xamarin.Facebook.Internal.InstagramCustomTab", "com/facebook/internal/InstagramCustomTab$Companion:Xamarin.Facebook.Internal.InstagramCustomTab/Companion", "com/facebook/internal/PlatformServiceClient:Xamarin.Facebook.Internal.PlatformServiceClient", "com/facebook/internal/WebDialog:Xamarin.Facebook.Internal.WebDialog", "com/facebook/internal/WebDialog$Builder:Xamarin.Facebook.Internal.WebDialog/Builder",
					"com/facebook/internal/WebDialog$Companion:Xamarin.Facebook.Internal.WebDialog/Companion", "com/facebook/internal/WebDialog$WhenMappings:Xamarin.Facebook.Internal.WebDialog/WhenMappings"
				};
			}
			return Lookup(package_com_facebook_internal_mappings, klass);
		}

		private static Type lookup_com_facebook_internal_logging_dumpsys_package(string klass)
		{
			if (package_com_facebook_internal_logging_dumpsys_mappings == null)
			{
				package_com_facebook_internal_logging_dumpsys_mappings = new string[1] { "com/facebook/internal/logging/dumpsys/EndToEndDumper$Companion:Com.Facebook.Internal.Logging.Dumpsys.EndToEndDumperCompanion" };
			}
			return Lookup(package_com_facebook_internal_logging_dumpsys_mappings, klass);
		}

		private static Type lookup_com_facebook_login_package(string klass)
		{
			if (package_com_facebook_login_mappings == null)
			{
				package_com_facebook_login_mappings = new string[35]
				{
					"com/facebook/login/CodeChallengeMethod:Xamarin.Facebook.Login.CodeChallengeMethod", "com/facebook/login/CustomTabLoginMethodHandler:Xamarin.Facebook.Login.CustomTabLoginMethodHandler", "com/facebook/login/CustomTabLoginMethodHandler$Companion:Xamarin.Facebook.Login.CustomTabLoginMethodHandler/Companion", "com/facebook/login/CustomTabPrefetchHelper:Xamarin.Facebook.Login.CustomTabPrefetchHelper", "com/facebook/login/CustomTabPrefetchHelper$Companion:Xamarin.Facebook.Login.CustomTabPrefetchHelper/Companion", "com/facebook/login/DeviceAuthDialog:Xamarin.Facebook.Login.DeviceAuthDialog", "com/facebook/login/DeviceAuthDialog$Companion:Xamarin.Facebook.Login.DeviceAuthDialog/Companion", "com/facebook/login/DeviceAuthMethodHandler:Xamarin.Facebook.Login.DeviceAuthMethodHandler", "com/facebook/login/DeviceAuthMethodHandler$Companion:Xamarin.Facebook.Login.DeviceAuthMethodHandler/Companion", "com/facebook/login/KatanaProxyLoginMethodHandler:Xamarin.Facebook.Login.KatanaProxyLoginMethodHandler",
					"com/facebook/login/KatanaProxyLoginMethodHandler$Companion:Xamarin.Facebook.Login.KatanaProxyLoginMethodHandler/Companion", "com/facebook/login/LoginBehavior:Xamarin.Facebook.Login.LoginBehavior", "com/facebook/login/LoginClient:Xamarin.Facebook.Login.LoginClient", "com/facebook/login/LoginClient$Companion:Xamarin.Facebook.Login.LoginClient/Companion", "com/facebook/login/LoginClient$Request:Xamarin.Facebook.Login.LoginClient/Request", "com/facebook/login/LoginClient$Request$Companion:Xamarin.Facebook.Login.LoginClient/Request/Companion", "com/facebook/login/LoginClient$Result:Xamarin.Facebook.Login.LoginClient/Result", "com/facebook/login/LoginClient$Result$Code:Xamarin.Facebook.Login.LoginClient/Result/Code", "com/facebook/login/LoginClient$Result$Companion:Xamarin.Facebook.Login.LoginClient/Result/Companion", "com/facebook/login/LoginConfiguration:Xamarin.Facebook.Login.LoginConfiguration",
					"com/facebook/login/LoginConfiguration$Companion:Xamarin.Facebook.Login.LoginConfiguration/Companion", "com/facebook/login/LoginFragment:Xamarin.Facebook.Login.LoginFragment", "com/facebook/login/LoginFragment$Companion:Xamarin.Facebook.Login.LoginFragment/Companion", "com/facebook/login/LoginManager:Xamarin.Facebook.Login.LoginManager", "com/facebook/login/LoginManager$Companion:Xamarin.Facebook.Login.LoginManager/Companion", "com/facebook/login/LoginMethodHandler:Xamarin.Facebook.Login.LoginMethodHandler", "com/facebook/login/LoginMethodHandler$Companion:Xamarin.Facebook.Login.LoginMethodHandler/Companion", "com/facebook/login/LoginResult:Xamarin.Facebook.Login.LoginResult", "com/facebook/login/NativeAppLoginMethodHandler:Xamarin.Facebook.Login.NativeAppLoginMethodHandler", "com/facebook/login/NonceUtil:Xamarin.Facebook.Login.NonceUtil",
					"com/facebook/login/WebLoginMethodHandler:Xamarin.Facebook.Login.WebLoginMethodHandler", "com/facebook/login/WebLoginMethodHandler$Companion:Xamarin.Facebook.Login.WebLoginMethodHandler/Companion", "com/facebook/login/WebViewLoginMethodHandler:Xamarin.Facebook.Login.WebViewLoginMethodHandler", "com/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder:Xamarin.Facebook.Login.WebViewLoginMethodHandler/AuthDialogBuilder", "com/facebook/login/WebViewLoginMethodHandler$Companion:Xamarin.Facebook.Login.WebViewLoginMethodHandler/Companion"
				};
			}
			return Lookup(package_com_facebook_login_mappings, klass);
		}

		private static Type lookup_com_facebook_share_model_package(string klass)
		{
			if (package_com_facebook_share_model_mappings == null)
			{
				package_com_facebook_share_model_mappings = new string[62]
				{
					"com/facebook/share/model/AppGroupCreationContent:Xamarin.Facebook.Share.Model.AppGroupCreationContent", "com/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy:Xamarin.Facebook.Share.Model.AppGroupCreationContent/AppGroupPrivacy", "com/facebook/share/model/AppGroupCreationContent$Builder:Xamarin.Facebook.Share.Model.AppGroupCreationContent/Builder", "com/facebook/share/model/AppGroupCreationContent$Companion:Xamarin.Facebook.Share.Model.AppGroupCreationContent/Companion", "com/facebook/share/model/CameraEffectArguments:Xamarin.Facebook.Share.Model.CameraEffectArguments", "com/facebook/share/model/CameraEffectArguments$Builder:Xamarin.Facebook.Share.Model.CameraEffectArguments/Builder", "com/facebook/share/model/CameraEffectArguments$Companion:Xamarin.Facebook.Share.Model.CameraEffectArguments/Companion", "com/facebook/share/model/CameraEffectTextures:Xamarin.Facebook.Share.Model.CameraEffectTextures", "com/facebook/share/model/CameraEffectTextures$Builder:Xamarin.Facebook.Share.Model.CameraEffectTextures/Builder", "com/facebook/share/model/CameraEffectTextures$Companion:Xamarin.Facebook.Share.Model.CameraEffectTextures/Companion",
					"com/facebook/share/model/GameRequestContent:Xamarin.Facebook.Share.Model.GameRequestContent", "com/facebook/share/model/GameRequestContent$ActionType:Xamarin.Facebook.Share.Model.GameRequestContent/ActionType", "com/facebook/share/model/GameRequestContent$Builder:Xamarin.Facebook.Share.Model.GameRequestContent/Builder", "com/facebook/share/model/GameRequestContent$Filters:Xamarin.Facebook.Share.Model.GameRequestContent/Filters", "com/facebook/share/model/ShareCameraEffectContent:Xamarin.Facebook.Share.Model.ShareCameraEffectContent", "com/facebook/share/model/ShareCameraEffectContent$Builder:Xamarin.Facebook.Share.Model.ShareCameraEffectContent/Builder", "com/facebook/share/model/ShareContent:Xamarin.Facebook.Share.Model.ShareContent", "com/facebook/share/model/ShareContent$Builder:Xamarin.Facebook.Share.Model.ShareContent/Builder", "com/facebook/share/model/ShareHashtag:Xamarin.Facebook.Share.Model.ShareHashtag", "com/facebook/share/model/ShareHashtag$Builder:Xamarin.Facebook.Share.Model.ShareHashtag/Builder",
					"com/facebook/share/model/ShareHashtag$Companion:Xamarin.Facebook.Share.Model.ShareHashtag/Companion", "com/facebook/share/model/ShareLinkContent:Xamarin.Facebook.Share.Model.ShareLinkContent", "com/facebook/share/model/ShareLinkContent$Builder:Xamarin.Facebook.Share.Model.ShareLinkContent/Builder", "com/facebook/share/model/ShareLinkContent$Companion:Xamarin.Facebook.Share.Model.ShareLinkContent/Companion", "com/facebook/share/model/ShareMedia:Xamarin.Facebook.Share.Model.ShareMedia", "com/facebook/share/model/ShareMedia$Builder:Xamarin.Facebook.Share.Model.ShareMedia/Builder", "com/facebook/share/model/ShareMedia$Builder$Companion:Xamarin.Facebook.Share.Model.ShareMedia/Builder/Companion", "com/facebook/share/model/ShareMedia$Type:Xamarin.Facebook.Share.Model.ShareMedia/Type", "com/facebook/share/model/ShareMediaContent:Xamarin.Facebook.Share.Model.ShareMediaContent", "com/facebook/share/model/ShareMediaContent$Builder:Xamarin.Facebook.Share.Model.ShareMediaContent/Builder",
					"com/facebook/share/model/ShareMediaContent$Companion:Xamarin.Facebook.Share.Model.ShareMediaContent/Companion", "com/facebook/share/model/ShareMessengerActionButton:Xamarin.Facebook.Share.Model.ShareMessengerActionButton", "com/facebook/share/model/ShareMessengerActionButton$Builder:Xamarin.Facebook.Share.Model.ShareMessengerActionButton/Builder", "com/facebook/share/model/ShareMessengerURLActionButton:Xamarin.Facebook.Share.Model.ShareMessengerURLActionButton", "com/facebook/share/model/ShareMessengerURLActionButton$Builder:Xamarin.Facebook.Share.Model.ShareMessengerURLActionButton/Builder", "com/facebook/share/model/ShareMessengerURLActionButton$Companion:Xamarin.Facebook.Share.Model.ShareMessengerURLActionButton/Companion", "com/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio:Xamarin.Facebook.Share.Model.ShareMessengerURLActionButton/WebviewHeightRatio", "com/facebook/share/model/ShareOpenGraphAction:Xamarin.Facebook.Share.Model.ShareOpenGraphAction", "com/facebook/share/model/ShareOpenGraphAction$Builder:Xamarin.Facebook.Share.Model.ShareOpenGraphAction/Builder", "com/facebook/share/model/ShareOpenGraphContent:Xamarin.Facebook.Share.Model.ShareOpenGraphContent",
					"com/facebook/share/model/ShareOpenGraphContent$Builder:Xamarin.Facebook.Share.Model.ShareOpenGraphContent/Builder", "com/facebook/share/model/ShareOpenGraphObject:Xamarin.Facebook.Share.Model.ShareOpenGraphObject", "com/facebook/share/model/ShareOpenGraphObject$Builder:Xamarin.Facebook.Share.Model.ShareOpenGraphObject/Builder", "com/facebook/share/model/ShareOpenGraphObject$Companion:Xamarin.Facebook.Share.Model.ShareOpenGraphObject/Companion", "com/facebook/share/model/ShareOpenGraphValueContainer:Xamarin.Facebook.Share.Model.ShareOpenGraphValueContainer", "com/facebook/share/model/ShareOpenGraphValueContainer$Builder:Xamarin.Facebook.Share.Model.ShareOpenGraphValueContainer/Builder", "com/facebook/share/model/SharePhoto:Xamarin.Facebook.Share.Model.SharePhoto", "com/facebook/share/model/SharePhoto$Builder:Xamarin.Facebook.Share.Model.SharePhoto/Builder", "com/facebook/share/model/SharePhoto$Builder$Companion:Xamarin.Facebook.Share.Model.SharePhoto/Builder/Companion", "com/facebook/share/model/SharePhoto$Companion:Xamarin.Facebook.Share.Model.SharePhoto/Companion",
					"com/facebook/share/model/SharePhotoContent:Xamarin.Facebook.Share.Model.SharePhotoContent", "com/facebook/share/model/SharePhotoContent$Builder:Xamarin.Facebook.Share.Model.SharePhotoContent/Builder", "com/facebook/share/model/SharePhotoContent$Companion:Xamarin.Facebook.Share.Model.SharePhotoContent/Companion", "com/facebook/share/model/ShareStoryContent:Xamarin.Facebook.Share.Model.ShareStoryContent", "com/facebook/share/model/ShareStoryContent$Builder:Xamarin.Facebook.Share.Model.ShareStoryContent/Builder", "com/facebook/share/model/ShareStoryContent$Companion:Xamarin.Facebook.Share.Model.ShareStoryContent/Companion", "com/facebook/share/model/ShareVideo:Xamarin.Facebook.Share.Model.ShareVideo", "com/facebook/share/model/ShareVideo$Builder:Xamarin.Facebook.Share.Model.ShareVideo/Builder", "com/facebook/share/model/ShareVideo$Companion:Xamarin.Facebook.Share.Model.ShareVideo/Companion", "com/facebook/share/model/ShareVideoContent:Xamarin.Facebook.Share.Model.ShareVideoContent",
					"com/facebook/share/model/ShareVideoContent$Builder:Xamarin.Facebook.Share.Model.ShareVideoContent/Builder", "com/facebook/share/model/ShareVideoContent$Companion:Xamarin.Facebook.Share.Model.ShareVideoContent/Companion"
				};
			}
			return Lookup(package_com_facebook_share_model_mappings, klass);
		}

		private static Type lookup_com_facebook_share_package(string klass)
		{
			if (package_com_facebook_share_mappings == null)
			{
				package_com_facebook_share_mappings = new string[1] { "com/facebook/share/Sharer$Result:Xamarin.Facebook.Share.SharerResult" };
			}
			return Lookup(package_com_facebook_share_mappings, klass);
		}

		private static Type lookup_com_facebook_share_widget_package(string klass)
		{
			if (package_com_facebook_share_widget_mappings == null)
			{
				package_com_facebook_share_widget_mappings = new string[4] { "com/facebook/share/widget/ShareDialog:Xamarin.Facebook.Share.Widget.ShareDialog", "com/facebook/share/widget/ShareDialog$Companion:Xamarin.Facebook.Share.Widget.ShareDialog/Companion", "com/facebook/share/widget/ShareDialog$Mode:Xamarin.Facebook.Share.Widget.ShareDialog/Mode", "com/facebook/share/widget/ShareDialog$WhenMappings:Xamarin.Facebook.Share.Widget.ShareDialog/WhenMappings" };
			}
			return Lookup(package_com_facebook_share_widget_mappings, klass);
		}
	}
}
namespace Com.Facebook.Internal.Logging.Dumpsys
{
	[Register("com/facebook/internal/logging/dumpsys/EndToEndDumper$Companion", DoNotGenerateAcw = true)]
	public sealed class EndToEndDumperCompanion : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/logging/dumpsys/EndToEndDumper$Companion", typeof(EndToEndDumperCompanion));

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

		public unsafe IEndToEndDumper Instance
		{
			[Register("getInstance", "()Lcom/facebook/internal/logging/dumpsys/EndToEndDumper;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IEndToEndDumper>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getInstance.()Lcom/facebook/internal/logging/dumpsys/EndToEndDumper;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setInstance", "(Lcom/facebook/internal/logging/dumpsys/EndToEndDumper;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setInstance.(Lcom/facebook/internal/logging/dumpsys/EndToEndDumper;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		internal EndToEndDumperCompanion(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/facebook/internal/logging/dumpsys/EndToEndDumper", DoNotGenerateAcw = true)]
	public abstract class EndToEndDumper : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/logging/dumpsys/EndToEndDumper", typeof(EndToEndDumper));

		[Register("Companion")]
		public static EndToEndDumperCompanion Companion => Java.Lang.Object.GetObject<EndToEndDumperCompanion>(_members.StaticFields.GetObjectValue("Companion.Lcom/facebook/internal/logging/dumpsys/EndToEndDumper$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

		internal EndToEndDumper()
		{
		}
	}
	[Register("com/facebook/internal/logging/dumpsys/EndToEndDumper", DoNotGenerateAcw = true)]
	[Obsolete("Use the 'EndToEndDumper' type. This type will be removed in a future release.", true)]
	public abstract class EndToEndDumperConsts : EndToEndDumper
	{
		private EndToEndDumperConsts()
		{
		}
	}
	[Register("com/facebook/internal/logging/dumpsys/EndToEndDumper", "", "Com.Facebook.Internal.Logging.Dumpsys.IEndToEndDumperInvoker")]
	public interface IEndToEndDumper : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("maybeDump", "(Ljava/lang/String;Ljava/io/PrintWriter;[Ljava/lang/String;)Z", "GetMaybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler:Com.Facebook.Internal.Logging.Dumpsys.IEndToEndDumperInvoker, Xamarin.Facebook.Common.Android")]
		bool MaybeDump(string prefix, PrintWriter writer, string[] args);
	}
	[Register("com/facebook/internal/logging/dumpsys/EndToEndDumper", DoNotGenerateAcw = true)]
	internal class IEndToEndDumperInvoker : Java.Lang.Object, IEndToEndDumper, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/logging/dumpsys/EndToEndDumper", typeof(IEndToEndDumperInvoker));

		private IntPtr class_ref;

		private static Delegate cb_maybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_;

		private IntPtr id_maybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_;

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

		public static IEndToEndDumper GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IEndToEndDumper>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.logging.dumpsys.EndToEndDumper'.");
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

		public IEndToEndDumperInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetMaybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_maybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_ == null)
			{
				cb_maybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_MaybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_));
			}
			return cb_maybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_;
		}

		private static bool n_MaybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_prefix, IntPtr native_writer, IntPtr native_args)
		{
			IEndToEndDumper endToEndDumper = Java.Lang.Object.GetObject<IEndToEndDumper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			PrintWriter writer = Java.Lang.Object.GetObject<PrintWriter>(native_writer, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(string));
			bool result = endToEndDumper.MaybeDump(prefix, writer, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_args);
			}
			return result;
		}

		public unsafe bool MaybeDump(string prefix, PrintWriter writer, string[] args)
		{
			if (id_maybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_ == IntPtr.Zero)
			{
				id_maybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_ = JNIEnv.GetMethodID(class_ref, "maybeDump", "(Ljava/lang/String;Ljava/io/PrintWriter;[Ljava/lang/String;)Z");
			}
			IntPtr intPtr = JNIEnv.NewString(prefix);
			IntPtr intPtr2 = JNIEnv.NewArray(args);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(writer?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(intPtr2);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_maybeDump_Ljava_lang_String_Ljava_io_PrintWriter_arrayLjava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			if (args != null)
			{
				JNIEnv.CopyArray(intPtr2, args);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			return result;
		}
	}
}
namespace Xamarin.Facebook
{
	[Register("com/facebook/AccessTokenTracker", DoNotGenerateAcw = true)]
	public abstract class AccessTokenTracker : Java.Lang.Object
	{
		[Register("com/facebook/AccessTokenTracker$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/AccessTokenTracker$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/AccessTokenTracker", typeof(AccessTokenTracker));

		private static Delegate cb_onCurrentAccessTokenChanged_Lcom_facebook_AccessToken_Lcom_facebook_AccessToken_;

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

		public unsafe bool IsTracking
		{
			[Register("isTracking", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isTracking.()Z", this, null);
			}
		}

		protected AccessTokenTracker(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AccessTokenTracker()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnCurrentAccessTokenChanged_Lcom_facebook_AccessToken_Lcom_facebook_AccessToken_Handler()
		{
			if ((object)cb_onCurrentAccessTokenChanged_Lcom_facebook_AccessToken_Lcom_facebook_AccessToken_ == null)
			{
				cb_onCurrentAccessTokenChanged_Lcom_facebook_AccessToken_Lcom_facebook_AccessToken_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnCurrentAccessTokenChanged_Lcom_facebook_AccessToken_Lcom_facebook_AccessToken_));
			}
			return cb_onCurrentAccessTokenChanged_Lcom_facebook_AccessToken_Lcom_facebook_AccessToken_;
		}

		private static void n_OnCurrentAccessTokenChanged_Lcom_facebook_AccessToken_Lcom_facebook_AccessToken_(IntPtr jnienv, IntPtr native__this, IntPtr native_oldAccessToken, IntPtr native_currentAccessToken)
		{
			AccessTokenTracker accessTokenTracker = Java.Lang.Object.GetObject<AccessTokenTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessToken oldAccessToken = Java.Lang.Object.GetObject<AccessToken>(native_oldAccessToken, JniHandleOwnership.DoNotTransfer);
			AccessToken currentAccessToken = Java.Lang.Object.GetObject<AccessToken>(native_currentAccessToken, JniHandleOwnership.DoNotTransfer);
			accessTokenTracker.OnCurrentAccessTokenChanged(oldAccessToken, currentAccessToken);
		}

		[Register("onCurrentAccessTokenChanged", "(Lcom/facebook/AccessToken;Lcom/facebook/AccessToken;)V", "GetOnCurrentAccessTokenChanged_Lcom_facebook_AccessToken_Lcom_facebook_AccessToken_Handler")]
		protected abstract void OnCurrentAccessTokenChanged(AccessToken oldAccessToken, AccessToken currentAccessToken);

		[Register("startTracking", "()V", "")]
		public unsafe void StartTracking()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("startTracking.()V", this, null);
		}

		[Register("stopTracking", "()V", "")]
		public unsafe void StopTracking()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("stopTracking.()V", this, null);
		}
	}
	[Register("com/facebook/AccessTokenTracker", DoNotGenerateAcw = true)]
	internal class AccessTokenTrackerInvoker : AccessTokenTracker
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/AccessTokenTracker", typeof(AccessTokenTrackerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public AccessTokenTrackerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onCurrentAccessTokenChanged", "(Lcom/facebook/AccessToken;Lcom/facebook/AccessToken;)V", "GetOnCurrentAccessTokenChanged_Lcom_facebook_AccessToken_Lcom_facebook_AccessToken_Handler")]
		protected unsafe override void OnCurrentAccessTokenChanged(AccessToken oldAccessToken, AccessToken currentAccessToken)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(oldAccessToken?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(currentAccessToken?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onCurrentAccessTokenChanged.(Lcom/facebook/AccessToken;Lcom/facebook/AccessToken;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(oldAccessToken);
				GC.KeepAlive(currentAccessToken);
			}
		}
	}
	[Register("com/facebook/AuthenticationTokenTracker", DoNotGenerateAcw = true)]
	public abstract class AuthenticationTokenTracker : Java.Lang.Object
	{
		[Register("com/facebook/AuthenticationTokenTracker$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/AuthenticationTokenTracker$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/AuthenticationTokenTracker", typeof(AuthenticationTokenTracker));

		private static Delegate cb_onCurrentAuthenticationTokenChanged_Lcom_facebook_AuthenticationToken_Lcom_facebook_AuthenticationToken_;

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

		public unsafe bool IsTracking
		{
			[Register("isTracking", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isTracking.()Z", this, null);
			}
		}

		protected AuthenticationTokenTracker(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AuthenticationTokenTracker()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnCurrentAuthenticationTokenChanged_Lcom_facebook_AuthenticationToken_Lcom_facebook_AuthenticationToken_Handler()
		{
			if ((object)cb_onCurrentAuthenticationTokenChanged_Lcom_facebook_AuthenticationToken_Lcom_facebook_AuthenticationToken_ == null)
			{
				cb_onCurrentAuthenticationTokenChanged_Lcom_facebook_AuthenticationToken_Lcom_facebook_AuthenticationToken_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnCurrentAuthenticationTokenChanged_Lcom_facebook_AuthenticationToken_Lcom_facebook_AuthenticationToken_));
			}
			return cb_onCurrentAuthenticationTokenChanged_Lcom_facebook_AuthenticationToken_Lcom_facebook_AuthenticationToken_;
		}

		private static void n_OnCurrentAuthenticationTokenChanged_Lcom_facebook_AuthenticationToken_Lcom_facebook_AuthenticationToken_(IntPtr jnienv, IntPtr native__this, IntPtr native_oldAuthenticationToken, IntPtr native_currentAuthenticationToken)
		{
			AuthenticationTokenTracker authenticationTokenTracker = Java.Lang.Object.GetObject<AuthenticationTokenTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AuthenticationToken oldAuthenticationToken = Java.Lang.Object.GetObject<AuthenticationToken>(native_oldAuthenticationToken, JniHandleOwnership.DoNotTransfer);
			AuthenticationToken currentAuthenticationToken = Java.Lang.Object.GetObject<AuthenticationToken>(native_currentAuthenticationToken, JniHandleOwnership.DoNotTransfer);
			authenticationTokenTracker.OnCurrentAuthenticationTokenChanged(oldAuthenticationToken, currentAuthenticationToken);
		}

		[Register("onCurrentAuthenticationTokenChanged", "(Lcom/facebook/AuthenticationToken;Lcom/facebook/AuthenticationToken;)V", "GetOnCurrentAuthenticationTokenChanged_Lcom_facebook_AuthenticationToken_Lcom_facebook_AuthenticationToken_Handler")]
		protected abstract void OnCurrentAuthenticationTokenChanged(AuthenticationToken oldAuthenticationToken, AuthenticationToken currentAuthenticationToken);

		[Register("startTracking", "()V", "")]
		public unsafe void StartTracking()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("startTracking.()V", this, null);
		}

		[Register("stopTracking", "()V", "")]
		public unsafe void StopTracking()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("stopTracking.()V", this, null);
		}
	}
	[Register("com/facebook/AuthenticationTokenTracker", DoNotGenerateAcw = true)]
	internal class AuthenticationTokenTrackerInvoker : AuthenticationTokenTracker
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/AuthenticationTokenTracker", typeof(AuthenticationTokenTrackerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public AuthenticationTokenTrackerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onCurrentAuthenticationTokenChanged", "(Lcom/facebook/AuthenticationToken;Lcom/facebook/AuthenticationToken;)V", "GetOnCurrentAuthenticationTokenChanged_Lcom_facebook_AuthenticationToken_Lcom_facebook_AuthenticationToken_Handler")]
		protected unsafe override void OnCurrentAuthenticationTokenChanged(AuthenticationToken oldAuthenticationToken, AuthenticationToken currentAuthenticationToken)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(oldAuthenticationToken?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(currentAuthenticationToken?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onCurrentAuthenticationTokenChanged.(Lcom/facebook/AuthenticationToken;Lcom/facebook/AuthenticationToken;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(oldAuthenticationToken);
				GC.KeepAlive(currentAuthenticationToken);
			}
		}
	}
	[Register("com/facebook/CustomTabActivity", DoNotGenerateAcw = true)]
	public sealed class CustomTabActivity : Activity
	{
		[Register("com/facebook/CustomTabActivity$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/CustomTabActivity$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/CustomTabActivity", typeof(CustomTabActivity));

		[Register("CUSTOM_TAB_REDIRECT_ACTION")]
		public static string CustomTabRedirectAction => JNIEnv.GetString(_members.StaticFields.GetObjectValue("CUSTOM_TAB_REDIRECT_ACTION.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DESTROY_ACTION")]
		public static string DestroyAction => JNIEnv.GetString(_members.StaticFields.GetObjectValue("DESTROY_ACTION.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal CustomTabActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CustomTabActivity()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/CustomTabMainActivity", DoNotGenerateAcw = true)]
	public sealed class CustomTabMainActivity : Activity
	{
		[Register("com/facebook/CustomTabMainActivity$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/CustomTabMainActivity$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		[Register("com/facebook/CustomTabMainActivity$WhenMappings", DoNotGenerateAcw = true)]
		public sealed class WhenMappings : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/CustomTabMainActivity$WhenMappings", typeof(WhenMappings));

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

			internal WhenMappings(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/CustomTabMainActivity", typeof(CustomTabMainActivity));

		[Register("EXTRA_ACTION")]
		public static string ExtraAction => JNIEnv.GetString(_members.StaticFields.GetObjectValue("EXTRA_ACTION.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EXTRA_CHROME_PACKAGE")]
		public static string ExtraChromePackage => JNIEnv.GetString(_members.StaticFields.GetObjectValue("EXTRA_CHROME_PACKAGE.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EXTRA_PARAMS")]
		public static string ExtraParams => JNIEnv.GetString(_members.StaticFields.GetObjectValue("EXTRA_PARAMS.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EXTRA_TARGET_APP")]
		public static string ExtraTargetApp => JNIEnv.GetString(_members.StaticFields.GetObjectValue("EXTRA_TARGET_APP.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EXTRA_URL")]
		public static string ExtraUrl => JNIEnv.GetString(_members.StaticFields.GetObjectValue("EXTRA_URL.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NO_ACTIVITY_EXCEPTION")]
		public static string NoActivityException => JNIEnv.GetString(_members.StaticFields.GetObjectValue("NO_ACTIVITY_EXCEPTION.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("REFRESH_ACTION")]
		public static string RefreshAction => JNIEnv.GetString(_members.StaticFields.GetObjectValue("REFRESH_ACTION.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal CustomTabMainActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CustomTabMainActivity()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/FacebookActivity", DoNotGenerateAcw = true)]
	public class FacebookActivity : FragmentActivity
	{
		[Register("com/facebook/FacebookActivity$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/FacebookActivity$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		[Register("PASS_THROUGH_CANCEL_ACTION")]
		public const string PassThroughCancelAction = "PassThrough";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/FacebookActivity", typeof(FacebookActivity));

		private static Delegate cb_getFragment;

		private static Delegate cb_onCreate_Landroid_os_Bundle_;

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

		public unsafe AndroidX.Fragment.App.Fragment CurrentFragment
		{
			[Register("getCurrentFragment", "()Landroidx/fragment/app/Fragment;", "")]
			get
			{
				return Java.Lang.Object.GetObject<AndroidX.Fragment.App.Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCurrentFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe virtual AndroidX.Fragment.App.Fragment Fragment
		{
			[Register("getFragment", "()Landroidx/fragment/app/Fragment;", "GetGetFragmentHandler")]
			get
			{
				return Java.Lang.Object.GetObject<AndroidX.Fragment.App.Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected FacebookActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FacebookActivity()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(((Java.Lang.Object)(object)this).Handle != IntPtr.Zero))
			{
				((Java.Lang.Object)(object)this).SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetFragmentHandler()
		{
			if ((object)cb_getFragment == null)
			{
				cb_getFragment = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFragment));
			}
			return cb_getFragment;
		}

		private static IntPtr n_GetFragment(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FacebookActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Fragment);
		}

		private static Delegate GetOnCreate_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onCreate_Landroid_os_Bundle_ == null)
			{
				cb_onCreate_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCreate_Landroid_os_Bundle_));
			}
			return cb_onCreate_Landroid_os_Bundle_;
		}

		private static void n_OnCreate_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_savedInstanceState)
		{
			FacebookActivity facebookActivity = Java.Lang.Object.GetObject<FacebookActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			facebookActivity.OnCreate(savedInstanceState);
		}

		[Register("onCreate", "(Landroid/os/Bundle;)V", "GetOnCreate_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnCreate(Bundle savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onCreate.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(savedInstanceState);
			}
		}
	}
	[Register("com/facebook/FacebookAuthorizationException", DoNotGenerateAcw = true)]
	public sealed class FacebookAuthorizationException : FacebookException
	{
		[Register("com/facebook/FacebookAuthorizationException$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/FacebookAuthorizationException$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		[Register("serialVersionUID")]
		public new const long SerialVersionUID = 1L;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/FacebookAuthorizationException", typeof(FacebookAuthorizationException));

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

		internal FacebookAuthorizationException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FacebookAuthorizationException()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe FacebookAuthorizationException(string message)
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

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		public unsafe FacebookAuthorizationException(string message, Throwable throwable)
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
		public unsafe FacebookAuthorizationException(Throwable throwable)
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
	[Register("com/facebook/FacebookButtonBase", DoNotGenerateAcw = true)]
	public abstract class FacebookButtonBase : Button
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/FacebookButtonBase", typeof(FacebookButtonBase));

		private static Delegate cb_getActivity;

		private static Delegate cb_getAnalyticsButtonCreatedEventName;

		private static Delegate cb_getAnalyticsButtonTappedEventName;

		private static Delegate cb_getAndroidxActivityResultRegistryOwner;

		private static Delegate cb_getDefaultRequestCode;

		private static Delegate cb_getDefaultStyleResource;

		private static Delegate cb_getFragment;

		private static Delegate cb_setFragment_Landroidx_fragment_app_Fragment_;

		private static Delegate cb_getNativeFragment;

		private static Delegate cb_getRequestCode;

		private static Delegate cb_callExternalOnClickListener_Landroid_view_View_;

		private static Delegate cb_configureButton_Landroid_content_Context_Landroid_util_AttributeSet_II;

		private static Delegate cb_logButtonCreated_Landroid_content_Context_;

		private static Delegate cb_logButtonTapped_Landroid_content_Context_;

		private static Delegate cb_measureTextWidth_Ljava_lang_String_;

		private static Delegate cb_setFragment_Landroid_app_Fragment_;

		private static Delegate cb_setInternalOnClickListener_Landroid_view_View_OnClickListener_;

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

		protected unsafe virtual Activity Activity
		{
			[Register("getActivity", "()Landroid/app/Activity;", "GetGetActivityHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Activity>(_members.InstanceMethods.InvokeVirtualObjectMethod("getActivity.()Landroid/app/Activity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe virtual string AnalyticsButtonCreatedEventName
		{
			[Register("getAnalyticsButtonCreatedEventName", "()Ljava/lang/String;", "GetGetAnalyticsButtonCreatedEventNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnalyticsButtonCreatedEventName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe virtual string AnalyticsButtonTappedEventName
		{
			[Register("getAnalyticsButtonTappedEventName", "()Ljava/lang/String;", "GetGetAnalyticsButtonTappedEventNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnalyticsButtonTappedEventName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IActivityResultRegistryOwner AndroidxActivityResultRegistryOwner
		{
			[Register("getAndroidxActivityResultRegistryOwner", "()Landroidx/activity/result/ActivityResultRegistryOwner;", "GetGetAndroidxActivityResultRegistryOwnerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IActivityResultRegistryOwner>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAndroidxActivityResultRegistryOwner.()Landroidx/activity/result/ActivityResultRegistryOwner;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected abstract int DefaultRequestCode
		{
			[Register("getDefaultRequestCode", "()I", "GetGetDefaultRequestCodeHandler")]
			get;
		}

		protected unsafe virtual int DefaultStyleResource
		{
			[Register("getDefaultStyleResource", "()I", "GetGetDefaultStyleResourceHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDefaultStyleResource.()I", this, null);
			}
		}

		public unsafe virtual AndroidX.Fragment.App.Fragment Fragment
		{
			[Register("getFragment", "()Landroidx/fragment/app/Fragment;", "GetGetFragmentHandler")]
			get
			{
				return Java.Lang.Object.GetObject<AndroidX.Fragment.App.Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setFragment", "(Landroidx/fragment/app/Fragment;)V", "GetSetFragment_Landroidx_fragment_app_Fragment_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setFragment.(Landroidx/fragment/app/Fragment;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual Android.App.Fragment NativeFragment
		{
			[Register("getNativeFragment", "()Landroid/app/Fragment;", "GetGetNativeFragmentHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.App.Fragment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNativeFragment.()Landroid/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int RequestCode
		{
			[Register("getRequestCode", "()I", "GetGetRequestCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRequestCode.()I", this, null);
			}
		}

		protected FacebookButtonBase(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;IILjava/lang/String;Ljava/lang/String;)V", "")]
		protected unsafe FacebookButtonBase(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes, string analyticsButtonCreatedEventName, string analyticsButtonTappedEventName)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(analyticsButtonCreatedEventName);
			IntPtr intPtr2 = JNIEnv.NewString(analyticsButtonTappedEventName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				ptr[3] = new JniArgumentValue(defStyleRes);
				ptr[4] = new JniArgumentValue(intPtr);
				ptr[5] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;IILjava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;IILjava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetActivityHandler()
		{
			if ((object)cb_getActivity == null)
			{
				cb_getActivity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetActivity));
			}
			return cb_getActivity;
		}

		private static IntPtr n_GetActivity(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Activity);
		}

		private static Delegate GetGetAnalyticsButtonCreatedEventNameHandler()
		{
			if ((object)cb_getAnalyticsButtonCreatedEventName == null)
			{
				cb_getAnalyticsButtonCreatedEventName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAnalyticsButtonCreatedEventName));
			}
			return cb_getAnalyticsButtonCreatedEventName;
		}

		private static IntPtr n_GetAnalyticsButtonCreatedEventName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnalyticsButtonCreatedEventName);
		}

		private static Delegate GetGetAnalyticsButtonTappedEventNameHandler()
		{
			if ((object)cb_getAnalyticsButtonTappedEventName == null)
			{
				cb_getAnalyticsButtonTappedEventName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAnalyticsButtonTappedEventName));
			}
			return cb_getAnalyticsButtonTappedEventName;
		}

		private static IntPtr n_GetAnalyticsButtonTappedEventName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnalyticsButtonTappedEventName);
		}

		private static Delegate GetGetAndroidxActivityResultRegistryOwnerHandler()
		{
			if ((object)cb_getAndroidxActivityResultRegistryOwner == null)
			{
				cb_getAndroidxActivityResultRegistryOwner = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAndroidxActivityResultRegistryOwner));
			}
			return cb_getAndroidxActivityResultRegistryOwner;
		}

		private static IntPtr n_GetAndroidxActivityResultRegistryOwner(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AndroidxActivityResultRegistryOwner);
		}

		private static Delegate GetGetDefaultRequestCodeHandler()
		{
			if ((object)cb_getDefaultRequestCode == null)
			{
				cb_getDefaultRequestCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetDefaultRequestCode));
			}
			return cb_getDefaultRequestCode;
		}

		private static int n_GetDefaultRequestCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultRequestCode;
		}

		private static Delegate GetGetDefaultStyleResourceHandler()
		{
			if ((object)cb_getDefaultStyleResource == null)
			{
				cb_getDefaultStyleResource = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetDefaultStyleResource));
			}
			return cb_getDefaultStyleResource;
		}

		private static int n_GetDefaultStyleResource(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultStyleResource;
		}

		private static Delegate GetGetFragmentHandler()
		{
			if ((object)cb_getFragment == null)
			{
				cb_getFragment = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFragment));
			}
			return cb_getFragment;
		}

		private static IntPtr n_GetFragment(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Fragment);
		}

		private static Delegate GetSetFragment_Landroidx_fragment_app_Fragment_Handler()
		{
			if ((object)cb_setFragment_Landroidx_fragment_app_Fragment_ == null)
			{
				cb_setFragment_Landroidx_fragment_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetFragment_Landroidx_fragment_app_Fragment_));
			}
			return cb_setFragment_Landroidx_fragment_app_Fragment_;
		}

		private static void n_SetFragment_Landroidx_fragment_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment)
		{
			FacebookButtonBase facebookButtonBase = Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.Fragment.App.Fragment fragment = Java.Lang.Object.GetObject<AndroidX.Fragment.App.Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			facebookButtonBase.Fragment = fragment;
		}

		private static Delegate GetGetNativeFragmentHandler()
		{
			if ((object)cb_getNativeFragment == null)
			{
				cb_getNativeFragment = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNativeFragment));
			}
			return cb_getNativeFragment;
		}

		private static IntPtr n_GetNativeFragment(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NativeFragment);
		}

		private static Delegate GetGetRequestCodeHandler()
		{
			if ((object)cb_getRequestCode == null)
			{
				cb_getRequestCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRequestCode));
			}
			return cb_getRequestCode;
		}

		private static int n_GetRequestCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestCode;
		}

		private static Delegate GetCallExternalOnClickListener_Landroid_view_View_Handler()
		{
			if ((object)cb_callExternalOnClickListener_Landroid_view_View_ == null)
			{
				cb_callExternalOnClickListener_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CallExternalOnClickListener_Landroid_view_View_));
			}
			return cb_callExternalOnClickListener_Landroid_view_View_;
		}

		private static void n_CallExternalOnClickListener_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_v)
		{
			FacebookButtonBase facebookButtonBase = Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
			facebookButtonBase.CallExternalOnClickListener(v);
		}

		[Register("callExternalOnClickListener", "(Landroid/view/View;)V", "GetCallExternalOnClickListener_Landroid_view_View_Handler")]
		protected unsafe virtual void CallExternalOnClickListener(View v)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("callExternalOnClickListener.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
			}
		}

		private static Delegate GetConfigureButton_Landroid_content_Context_Landroid_util_AttributeSet_IIHandler()
		{
			if ((object)cb_configureButton_Landroid_content_Context_Landroid_util_AttributeSet_II == null)
			{
				cb_configureButton_Landroid_content_Context_Landroid_util_AttributeSet_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLII_V(n_ConfigureButton_Landroid_content_Context_Landroid_util_AttributeSet_II));
			}
			return cb_configureButton_Landroid_content_Context_Landroid_util_AttributeSet_II;
		}

		private static void n_ConfigureButton_Landroid_content_Context_Landroid_util_AttributeSet_II(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_attrs, int defStyleAttr, int defStyleRes)
		{
			FacebookButtonBase facebookButtonBase = Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
			facebookButtonBase.ConfigureButton(context, attrs, defStyleAttr, defStyleRes);
		}

		[Register("configureButton", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "GetConfigureButton_Landroid_content_Context_Landroid_util_AttributeSet_IIHandler")]
		protected unsafe virtual void ConfigureButton(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				ptr[3] = new JniArgumentValue(defStyleRes);
				_members.InstanceMethods.InvokeVirtualVoidMethod("configureButton.(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetLogButtonCreated_Landroid_content_Context_Handler()
		{
			if ((object)cb_logButtonCreated_Landroid_content_Context_ == null)
			{
				cb_logButtonCreated_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_LogButtonCreated_Landroid_content_Context_));
			}
			return cb_logButtonCreated_Landroid_content_Context_;
		}

		private static void n_LogButtonCreated_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			FacebookButtonBase facebookButtonBase = Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			facebookButtonBase.LogButtonCreated(context);
		}

		[Register("logButtonCreated", "(Landroid/content/Context;)V", "GetLogButtonCreated_Landroid_content_Context_Handler")]
		protected unsafe virtual void LogButtonCreated(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("logButtonCreated.(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetLogButtonTapped_Landroid_content_Context_Handler()
		{
			if ((object)cb_logButtonTapped_Landroid_content_Context_ == null)
			{
				cb_logButtonTapped_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_LogButtonTapped_Landroid_content_Context_));
			}
			return cb_logButtonTapped_Landroid_content_Context_;
		}

		private static void n_LogButtonTapped_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			FacebookButtonBase facebookButtonBase = Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			facebookButtonBase.LogButtonTapped(context);
		}

		[Register("logButtonTapped", "(Landroid/content/Context;)V", "GetLogButtonTapped_Landroid_content_Context_Handler")]
		protected unsafe virtual void LogButtonTapped(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("logButtonTapped.(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetMeasureTextWidth_Ljava_lang_String_Handler()
		{
			if ((object)cb_measureTextWidth_Ljava_lang_String_ == null)
			{
				cb_measureTextWidth_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_MeasureTextWidth_Ljava_lang_String_));
			}
			return cb_measureTextWidth_Ljava_lang_String_;
		}

		private static int n_MeasureTextWidth_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_text)
		{
			FacebookButtonBase facebookButtonBase = Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
			return facebookButtonBase.MeasureTextWidth(text);
		}

		[Register("measureTextWidth", "(Ljava/lang/String;)I", "GetMeasureTextWidth_Ljava_lang_String_Handler")]
		protected unsafe virtual int MeasureTextWidth(string text)
		{
			IntPtr intPtr = JNIEnv.NewString(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualInt32Method("measureTextWidth.(Ljava/lang/String;)I", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetFragment_Landroid_app_Fragment_Handler()
		{
			if ((object)cb_setFragment_Landroid_app_Fragment_ == null)
			{
				cb_setFragment_Landroid_app_Fragment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetFragment_Landroid_app_Fragment_));
			}
			return cb_setFragment_Landroid_app_Fragment_;
		}

		private static void n_SetFragment_Landroid_app_Fragment_(IntPtr jnienv, IntPtr native__this, IntPtr native_fragment)
		{
			FacebookButtonBase facebookButtonBase = Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.App.Fragment fragment = Java.Lang.Object.GetObject<Android.App.Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			facebookButtonBase.SetFragment(fragment);
		}

		[Register("setFragment", "(Landroid/app/Fragment;)V", "GetSetFragment_Landroid_app_Fragment_Handler")]
		public unsafe virtual void SetFragment(Android.App.Fragment fragment)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setFragment.(Landroid/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		private static Delegate GetSetInternalOnClickListener_Landroid_view_View_OnClickListener_Handler()
		{
			if ((object)cb_setInternalOnClickListener_Landroid_view_View_OnClickListener_ == null)
			{
				cb_setInternalOnClickListener_Landroid_view_View_OnClickListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetInternalOnClickListener_Landroid_view_View_OnClickListener_));
			}
			return cb_setInternalOnClickListener_Landroid_view_View_OnClickListener_;
		}

		private static void n_SetInternalOnClickListener_Landroid_view_View_OnClickListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_l)
		{
			FacebookButtonBase facebookButtonBase = Java.Lang.Object.GetObject<FacebookButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnClickListener internalOnClickListener = Java.Lang.Object.GetObject<IOnClickListener>(native_l, JniHandleOwnership.DoNotTransfer);
			facebookButtonBase.SetInternalOnClickListener(internalOnClickListener);
		}

		[Register("setInternalOnClickListener", "(Landroid/view/View$OnClickListener;)V", "GetSetInternalOnClickListener_Landroid_view_View_OnClickListener_Handler")]
		protected unsafe virtual void SetInternalOnClickListener(IOnClickListener l)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((l == null) ? IntPtr.Zero : ((Java.Lang.Object)l).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setInternalOnClickListener.(Landroid/view/View$OnClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(l);
			}
		}
	}
	[Register("com/facebook/FacebookButtonBase", DoNotGenerateAcw = true)]
	internal class FacebookButtonBaseInvoker : FacebookButtonBase
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/FacebookButtonBase", typeof(FacebookButtonBaseInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected unsafe override int DefaultRequestCode
		{
			[Register("getDefaultRequestCode", "()I", "GetGetDefaultRequestCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getDefaultRequestCode.()I", this, null);
			}
		}

		public FacebookButtonBaseInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/facebook/FacebookDialogException", DoNotGenerateAcw = true)]
	public sealed class FacebookDialogException : FacebookException
	{
		[Register("com/facebook/FacebookDialogException$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/FacebookDialogException$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		[Register("serialVersionUID")]
		public new const long SerialVersionUID = 1L;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/FacebookDialogException", typeof(FacebookDialogException));

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

		public unsafe int ErrorCode
		{
			[Register("getErrorCode", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getErrorCode.()I", this, null);
			}
		}

		public unsafe string FailingUrl
		{
			[Register("getFailingUrl", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFailingUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal FacebookDialogException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;ILjava/lang/String;)V", "")]
		public unsafe FacebookDialogException(string message, int errorCode, string failingUrl)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			IntPtr intPtr2 = JNIEnv.NewString(failingUrl);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(errorCode);
				ptr[2] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;ILjava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;ILjava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}
	}
	[Register("com/facebook/FacebookCallback", "", "Xamarin.Facebook.IFacebookCallbackInvoker")]
	[JavaTypeParameters(new string[] { "RESULT" })]
	public interface IFacebookCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCancel", "()V", "GetOnCancelHandler:Xamarin.Facebook.IFacebookCallbackInvoker, Xamarin.Facebook.Common.Android")]
		void OnCancel();

		[Register("onError", "(Lcom/facebook/FacebookException;)V", "GetOnError_Lcom_facebook_FacebookException_Handler:Xamarin.Facebook.IFacebookCallbackInvoker, Xamarin.Facebook.Common.Android")]
		void OnError(FacebookException error);

		[Register("onSuccess", "(Ljava/lang/Object;)V", "GetOnSuccess_Ljava_lang_Object_Handler:Xamarin.Facebook.IFacebookCallbackInvoker, Xamarin.Facebook.Common.Android")]
		void OnSuccess(Java.Lang.Object result);
	}
	[Register("com/facebook/FacebookCallback", DoNotGenerateAcw = true)]
	internal class IFacebookCallbackInvoker : Java.Lang.Object, IFacebookCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/FacebookCallback", typeof(IFacebookCallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onCancel;

		private IntPtr id_onCancel;

		private static Delegate cb_onError_Lcom_facebook_FacebookException_;

		private IntPtr id_onError_Lcom_facebook_FacebookException_;

		private static Delegate cb_onSuccess_Ljava_lang_Object_;

		private IntPtr id_onSuccess_Ljava_lang_Object_;

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

		public static IFacebookCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFacebookCallback>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.FacebookCallback'.");
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

		public IFacebookCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnCancelHandler()
		{
			if ((object)cb_onCancel == null)
			{
				cb_onCancel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCancel));
			}
			return cb_onCancel;
		}

		private static void n_OnCancel(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IFacebookCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCancel();
		}

		public void OnCancel()
		{
			if (id_onCancel == IntPtr.Zero)
			{
				id_onCancel = JNIEnv.GetMethodID(class_ref, "onCancel", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onCancel);
		}

		private static Delegate GetOnError_Lcom_facebook_FacebookException_Handler()
		{
			if ((object)cb_onError_Lcom_facebook_FacebookException_ == null)
			{
				cb_onError_Lcom_facebook_FacebookException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Lcom_facebook_FacebookException_));
			}
			return cb_onError_Lcom_facebook_FacebookException_;
		}

		private static void n_OnError_Lcom_facebook_FacebookException_(IntPtr jnienv, IntPtr native__this, IntPtr native_error)
		{
			IFacebookCallback facebookCallback = Java.Lang.Object.GetObject<IFacebookCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FacebookException error = Java.Lang.Object.GetObject<FacebookException>(native_error, JniHandleOwnership.DoNotTransfer);
			facebookCallback.OnError(error);
		}

		public unsafe void OnError(FacebookException error)
		{
			if (id_onError_Lcom_facebook_FacebookException_ == IntPtr.Zero)
			{
				id_onError_Lcom_facebook_FacebookException_ = JNIEnv.GetMethodID(class_ref, "onError", "(Lcom/facebook/FacebookException;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(error?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onError_Lcom_facebook_FacebookException_, ptr);
		}

		private static Delegate GetOnSuccess_Ljava_lang_Object_Handler()
		{
			if ((object)cb_onSuccess_Ljava_lang_Object_ == null)
			{
				cb_onSuccess_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Ljava_lang_Object_));
			}
			return cb_onSuccess_Ljava_lang_Object_;
		}

		private static void n_OnSuccess_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
		{
			IFacebookCallback facebookCallback = Java.Lang.Object.GetObject<IFacebookCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			facebookCallback.OnSuccess(result);
		}

		public unsafe void OnSuccess(Java.Lang.Object result)
		{
			if (id_onSuccess_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_onSuccess_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "onSuccess", "(Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onSuccess_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/facebook/FacebookDialog", "", "Xamarin.Facebook.IFacebookDialogInvoker")]
	[JavaTypeParameters(new string[] { "CONTENT", "RESULT" })]
	public interface IFacebookDialog : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("canShow", "(Ljava/lang/Object;)Z", "GetCanShow_Ljava_lang_Object_Handler:Xamarin.Facebook.IFacebookDialogInvoker, Xamarin.Facebook.Common.Android")]
		bool CanShow(Java.Lang.Object content);

		[Register("registerCallback", "(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V", "GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_Handler:Xamarin.Facebook.IFacebookDialogInvoker, Xamarin.Facebook.Common.Android")]
		void RegisterCallback(ICallbackManager callbackManager, IFacebookCallback callback);

		[Register("registerCallback", "(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;I)V", "GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_IHandler:Xamarin.Facebook.IFacebookDialogInvoker, Xamarin.Facebook.Common.Android")]
		void RegisterCallback(ICallbackManager callbackManager, IFacebookCallback callback, int requestCode);

		[Register("show", "(Ljava/lang/Object;)V", "GetShow_Ljava_lang_Object_Handler:Xamarin.Facebook.IFacebookDialogInvoker, Xamarin.Facebook.Common.Android")]
		void Show(Java.Lang.Object content);
	}
	[Register("com/facebook/FacebookDialog", DoNotGenerateAcw = true)]
	internal class IFacebookDialogInvoker : Java.Lang.Object, IFacebookDialog, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/FacebookDialog", typeof(IFacebookDialogInvoker));

		private IntPtr class_ref;

		private static Delegate cb_canShow_Ljava_lang_Object_;

		private IntPtr id_canShow_Ljava_lang_Object_;

		private static Delegate cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_;

		private IntPtr id_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I;

		private IntPtr id_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I;

		private static Delegate cb_show_Ljava_lang_Object_;

		private IntPtr id_show_Ljava_lang_Object_;

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

		public static IFacebookDialog GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFacebookDialog>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.FacebookDialog'.");
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

		public IFacebookDialogInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCanShow_Ljava_lang_Object_Handler()
		{
			if ((object)cb_canShow_Ljava_lang_Object_ == null)
			{
				cb_canShow_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_CanShow_Ljava_lang_Object_));
			}
			return cb_canShow_Ljava_lang_Object_;
		}

		private static bool n_CanShow_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
		{
			IFacebookDialog facebookDialog = Java.Lang.Object.GetObject<IFacebookDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object content = Java.Lang.Object.GetObject<Java.Lang.Object>(native_content, JniHandleOwnership.DoNotTransfer);
			return facebookDialog.CanShow(content);
		}

		public unsafe bool CanShow(Java.Lang.Object content)
		{
			if (id_canShow_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_canShow_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "canShow", "(Ljava/lang/Object;)Z");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(content);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_canShow_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_Handler()
		{
			if ((object)cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_ == null)
			{
				cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_));
			}
			return cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_;
		}

		private static void n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager, IntPtr native__callback)
		{
			IFacebookDialog facebookDialog = Java.Lang.Object.GetObject<IFacebookDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallbackManager callbackManager = Java.Lang.Object.GetObject<ICallbackManager>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			facebookDialog.RegisterCallback(callbackManager, callback);
		}

		public unsafe void RegisterCallback(ICallbackManager callbackManager, IFacebookCallback callback)
		{
			if (id_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_ == IntPtr.Zero)
			{
				id_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_ = JNIEnv.GetMethodID(class_ref, "registerCallback", "(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
			ptr[1] = new JValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_, ptr);
		}

		private static Delegate GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_IHandler()
		{
			if ((object)cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I == null)
			{
				cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I));
			}
			return cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I;
		}

		private static void n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager, IntPtr native__callback, int requestCode)
		{
			IFacebookDialog facebookDialog = Java.Lang.Object.GetObject<IFacebookDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallbackManager callbackManager = Java.Lang.Object.GetObject<ICallbackManager>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			facebookDialog.RegisterCallback(callbackManager, callback, requestCode);
		}

		public unsafe void RegisterCallback(ICallbackManager callbackManager, IFacebookCallback callback, int requestCode)
		{
			if (id_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I == IntPtr.Zero)
			{
				id_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I = JNIEnv.GetMethodID(class_ref, "registerCallback", "(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;I)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
			ptr[1] = new JValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			ptr[2] = new JValue(requestCode);
			JNIEnv.CallVoidMethod(base.Handle, id_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I, ptr);
		}

		private static Delegate GetShow_Ljava_lang_Object_Handler()
		{
			if ((object)cb_show_Ljava_lang_Object_ == null)
			{
				cb_show_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Show_Ljava_lang_Object_));
			}
			return cb_show_Ljava_lang_Object_;
		}

		private static void n_Show_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
		{
			IFacebookDialog facebookDialog = Java.Lang.Object.GetObject<IFacebookDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object content = Java.Lang.Object.GetObject<Java.Lang.Object>(native_content, JniHandleOwnership.DoNotTransfer);
			facebookDialog.Show(content);
		}

		public unsafe void Show(Java.Lang.Object content)
		{
			if (id_show_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_show_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "show", "(Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(content);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_show_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/facebook/LoginStatusCallback", "", "Xamarin.Facebook.ILoginStatusCallbackInvoker")]
	public interface ILoginStatusCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCompleted", "(Lcom/facebook/AccessToken;)V", "GetOnCompleted_Lcom_facebook_AccessToken_Handler:Xamarin.Facebook.ILoginStatusCallbackInvoker, Xamarin.Facebook.Common.Android")]
		void OnCompleted(AccessToken accessToken);

		[Register("onError", "(Ljava/lang/Exception;)V", "GetOnError_Ljava_lang_Exception_Handler:Xamarin.Facebook.ILoginStatusCallbackInvoker, Xamarin.Facebook.Common.Android")]
		void OnError(Java.Lang.Exception exception);

		[Register("onFailure", "()V", "GetOnFailureHandler:Xamarin.Facebook.ILoginStatusCallbackInvoker, Xamarin.Facebook.Common.Android")]
		void OnFailure();
	}
	[Register("com/facebook/LoginStatusCallback", DoNotGenerateAcw = true)]
	internal class ILoginStatusCallbackInvoker : Java.Lang.Object, ILoginStatusCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/LoginStatusCallback", typeof(ILoginStatusCallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onCompleted_Lcom_facebook_AccessToken_;

		private IntPtr id_onCompleted_Lcom_facebook_AccessToken_;

		private static Delegate cb_onError_Ljava_lang_Exception_;

		private IntPtr id_onError_Ljava_lang_Exception_;

		private static Delegate cb_onFailure;

		private IntPtr id_onFailure;

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

		public static ILoginStatusCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILoginStatusCallback>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.LoginStatusCallback'.");
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

		public ILoginStatusCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnCompleted_Lcom_facebook_AccessToken_Handler()
		{
			if ((object)cb_onCompleted_Lcom_facebook_AccessToken_ == null)
			{
				cb_onCompleted_Lcom_facebook_AccessToken_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCompleted_Lcom_facebook_AccessToken_));
			}
			return cb_onCompleted_Lcom_facebook_AccessToken_;
		}

		private static void n_OnCompleted_Lcom_facebook_AccessToken_(IntPtr jnienv, IntPtr native__this, IntPtr native_accessToken)
		{
			ILoginStatusCallback loginStatusCallback = Java.Lang.Object.GetObject<ILoginStatusCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessToken accessToken = Java.Lang.Object.GetObject<AccessToken>(native_accessToken, JniHandleOwnership.DoNotTransfer);
			loginStatusCallback.OnCompleted(accessToken);
		}

		public unsafe void OnCompleted(AccessToken accessToken)
		{
			if (id_onCompleted_Lcom_facebook_AccessToken_ == IntPtr.Zero)
			{
				id_onCompleted_Lcom_facebook_AccessToken_ = JNIEnv.GetMethodID(class_ref, "onCompleted", "(Lcom/facebook/AccessToken;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(accessToken?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onCompleted_Lcom_facebook_AccessToken_, ptr);
		}

		private static Delegate GetOnError_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_onError_Ljava_lang_Exception_ == null)
			{
				cb_onError_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Ljava_lang_Exception_));
			}
			return cb_onError_Ljava_lang_Exception_;
		}

		private static void n_OnError_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_exception)
		{
			ILoginStatusCallback loginStatusCallback = Java.Lang.Object.GetObject<ILoginStatusCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception exception = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_exception, JniHandleOwnership.DoNotTransfer);
			loginStatusCallback.OnError(exception);
		}

		public unsafe void OnError(Java.Lang.Exception exception)
		{
			if (id_onError_Ljava_lang_Exception_ == IntPtr.Zero)
			{
				id_onError_Ljava_lang_Exception_ = JNIEnv.GetMethodID(class_ref, "onError", "(Ljava/lang/Exception;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(exception?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onError_Ljava_lang_Exception_, ptr);
		}

		private static Delegate GetOnFailureHandler()
		{
			if ((object)cb_onFailure == null)
			{
				cb_onFailure = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnFailure));
			}
			return cb_onFailure;
		}

		private static void n_OnFailure(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ILoginStatusCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFailure();
		}

		public void OnFailure()
		{
			if (id_onFailure == IntPtr.Zero)
			{
				id_onFailure = JNIEnv.GetMethodID(class_ref, "onFailure", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onFailure);
		}
	}
	[Register("com/facebook/WebDialog", DoNotGenerateAcw = true)]
	public sealed class WebDialog : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/WebDialog", typeof(WebDialog));

		[Register("INSTANCE")]
		public static WebDialog Instance => Java.Lang.Object.GetObject<WebDialog>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/facebook/WebDialog;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe static int WebDialogTheme
		{
			[Register("getWebDialogTheme", "()I", "")]
			get
			{
				return _members.StaticMethods.InvokeInt32Method("getWebDialogTheme.()I", null);
			}
			[Register("setWebDialogTheme", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.StaticMethods.InvokeVoidMethod("setWebDialogTheme.(I)V", ptr);
			}
		}

		internal WebDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
}
namespace Xamarin.Facebook.Login
{
	[Register("com/facebook/login/CodeChallengeMethod", DoNotGenerateAcw = true)]
	public sealed class CodeChallengeMethod : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/CodeChallengeMethod", typeof(CodeChallengeMethod));

		[Register("PLAIN")]
		public static CodeChallengeMethod Plain => Java.Lang.Object.GetObject<CodeChallengeMethod>(_members.StaticFields.GetObjectValue("PLAIN.Lcom/facebook/login/CodeChallengeMethod;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("S256")]
		public static CodeChallengeMethod S256 => Java.Lang.Object.GetObject<CodeChallengeMethod>(_members.StaticFields.GetObjectValue("S256.Lcom/facebook/login/CodeChallengeMethod;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal CodeChallengeMethod(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/login/CodeChallengeMethod;", "")]
		public unsafe static CodeChallengeMethod ValueOf(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<CodeChallengeMethod>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/login/CodeChallengeMethod;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/facebook/login/CodeChallengeMethod;", "")]
		public unsafe static CodeChallengeMethod[] Values()
		{
			return (CodeChallengeMethod[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/login/CodeChallengeMethod;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(CodeChallengeMethod));
		}
	}
	[Register("com/facebook/login/CustomTabLoginMethodHandler", DoNotGenerateAcw = true)]
	public sealed class CustomTabLoginMethodHandler : WebLoginMethodHandler
	{
		[Register("com/facebook/login/CustomTabLoginMethodHandler$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/CustomTabLoginMethodHandler$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		[Register("OAUTH_DIALOG")]
		public const string OauthDialog = "oauth";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/CustomTabLoginMethodHandler", typeof(CustomTabLoginMethodHandler));

		[Register("calledThroughLoggedOutAppSwitch")]
		public static bool CalledThroughLoggedOutAppSwitch
		{
			get
			{
				return _members.StaticFields.GetBooleanValue("calledThroughLoggedOutAppSwitch.Z");
			}
			set
			{
				_members.StaticFields.SetValue("calledThroughLoggedOutAppSwitch.Z", value);
			}
		}

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe override string NameForLogging
		{
			[Register("getNameForLogging", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getNameForLogging.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override AccessTokenSource TokenSource
		{
			[Register("getTokenSource", "()Lcom/facebook/AccessTokenSource;", "")]
			get
			{
				return Java.Lang.Object.GetObject<AccessTokenSource>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTokenSource.()Lcom/facebook/AccessTokenSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CustomTabLoginMethodHandler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("describeContents", "()I", "")]
		public unsafe override int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}

		[Register("tryAuthorize", "(Lcom/facebook/login/LoginClient$Request;)I", "")]
		public unsafe override int TryAuthorize(LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("tryAuthorize.(Lcom/facebook/login/LoginClient$Request;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}
	}
	[Register("com/facebook/login/CustomTabPrefetchHelper", DoNotGenerateAcw = true)]
	public sealed class CustomTabPrefetchHelper : CustomTabsServiceConnection
	{
		[Register("com/facebook/login/CustomTabPrefetchHelper$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/CustomTabPrefetchHelper$Companion", typeof(Companion));

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

			public unsafe CustomTabsSession PreparedSessionOnce
			{
				[Register("getPreparedSessionOnce", "()Landroidx/browser/customtabs/CustomTabsSession;", "")]
				get
				{
					return Java.Lang.Object.GetObject<CustomTabsSession>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPreparedSessionOnce.()Landroidx/browser/customtabs/CustomTabsSession;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("mayLaunchUrl", "(Landroid/net/Uri;)V", "")]
			public unsafe void MayLaunchUrl(Android.Net.Uri url)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("mayLaunchUrl.(Landroid/net/Uri;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(url);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/CustomTabPrefetchHelper", typeof(CustomTabPrefetchHelper));

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

		public unsafe static CustomTabsSession PreparedSessionOnce
		{
			[Register("getPreparedSessionOnce", "()Landroidx/browser/customtabs/CustomTabsSession;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CustomTabsSession>(_members.StaticMethods.InvokeObjectMethod("getPreparedSessionOnce.()Landroidx/browser/customtabs/CustomTabsSession;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CustomTabPrefetchHelper(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CustomTabPrefetchHelper()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("mayLaunchUrl", "(Landroid/net/Uri;)V", "")]
		public unsafe static void MayLaunchUrl(Android.Net.Uri url)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("mayLaunchUrl.(Landroid/net/Uri;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(url);
			}
		}

		[Register("onCustomTabsServiceConnected", "(Landroid/content/ComponentName;Landroidx/browser/customtabs/CustomTabsClient;)V", "")]
		public unsafe override void OnCustomTabsServiceConnected(ComponentName name, CustomTabsClient newClient)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(name?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newClient?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onCustomTabsServiceConnected.(Landroid/content/ComponentName;Landroidx/browser/customtabs/CustomTabsClient;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(name);
				GC.KeepAlive(newClient);
			}
		}

		[Register("onServiceDisconnected", "(Landroid/content/ComponentName;)V", "")]
		public unsafe override void OnServiceDisconnected(ComponentName componentName)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onServiceDisconnected.(Landroid/content/ComponentName;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/facebook/login/DeviceAuthDialog", DoNotGenerateAcw = true)]
	public class DeviceAuthDialog : AndroidX.Fragment.App.DialogFragment
	{
		[Register("com/facebook/login/DeviceAuthDialog$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/DeviceAuthDialog$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/DeviceAuthDialog", typeof(DeviceAuthDialog));

		private static Delegate cb_additionalDeviceInfo;

		private static Delegate cb_getLayoutResId_Z;

		private static Delegate cb_initializeContentView_Z;

		private static Delegate cb_onBackButtonPressed;

		private static Delegate cb_onCancel;

		private static Delegate cb_onError_Lcom_facebook_FacebookException_;

		private static Delegate cb_startLogin_Lcom_facebook_login_LoginClient_Request_;

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

		protected DeviceAuthDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DeviceAuthDialog()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetAdditionalDeviceInfoHandler()
		{
			if ((object)cb_additionalDeviceInfo == null)
			{
				cb_additionalDeviceInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AdditionalDeviceInfo));
			}
			return cb_additionalDeviceInfo;
		}

		private static IntPtr n_AdditionalDeviceInfo(IntPtr jnienv, IntPtr native__this)
		{
			return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<DeviceAuthDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AdditionalDeviceInfo());
		}

		[Register("additionalDeviceInfo", "()Ljava/util/Map;", "GetAdditionalDeviceInfoHandler")]
		public unsafe virtual IDictionary<string, string> AdditionalDeviceInfo()
		{
			return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("additionalDeviceInfo.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetLayoutResId_ZHandler()
		{
			if ((object)cb_getLayoutResId_Z == null)
			{
				cb_getLayoutResId_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_I(n_GetLayoutResId_Z));
			}
			return cb_getLayoutResId_Z;
		}

		private static int n_GetLayoutResId_Z(IntPtr jnienv, IntPtr native__this, bool isSmartLogin)
		{
			return Java.Lang.Object.GetObject<DeviceAuthDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLayoutResId(isSmartLogin);
		}

		[Register("getLayoutResId", "(Z)I", "GetGetLayoutResId_ZHandler")]
		protected unsafe virtual int GetLayoutResId(bool isSmartLogin)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isSmartLogin);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLayoutResId.(Z)I", this, ptr);
		}

		private static Delegate GetInitializeContentView_ZHandler()
		{
			if ((object)cb_initializeContentView_Z == null)
			{
				cb_initializeContentView_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_InitializeContentView_Z));
			}
			return cb_initializeContentView_Z;
		}

		private static IntPtr n_InitializeContentView_Z(IntPtr jnienv, IntPtr native__this, bool isSmartLogin)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DeviceAuthDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitializeContentView(isSmartLogin));
		}

		[Register("initializeContentView", "(Z)Landroid/view/View;", "GetInitializeContentView_ZHandler")]
		protected unsafe virtual View InitializeContentView(bool isSmartLogin)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isSmartLogin);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("initializeContentView.(Z)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetOnBackButtonPressedHandler()
		{
			if ((object)cb_onBackButtonPressed == null)
			{
				cb_onBackButtonPressed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnBackButtonPressed));
			}
			return cb_onBackButtonPressed;
		}

		private static void n_OnBackButtonPressed(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<DeviceAuthDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBackButtonPressed();
		}

		[Register("onBackButtonPressed", "()V", "GetOnBackButtonPressedHandler")]
		protected unsafe virtual void OnBackButtonPressed()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onBackButtonPressed.()V", this, null);
		}

		private static Delegate GetOnCancelHandler()
		{
			if ((object)cb_onCancel == null)
			{
				cb_onCancel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCancel));
			}
			return cb_onCancel;
		}

		private static void n_OnCancel(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<DeviceAuthDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCancel();
		}

		[Register("onCancel", "()V", "GetOnCancelHandler")]
		protected unsafe virtual void OnCancel()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCancel.()V", this, null);
		}

		private static Delegate GetOnError_Lcom_facebook_FacebookException_Handler()
		{
			if ((object)cb_onError_Lcom_facebook_FacebookException_ == null)
			{
				cb_onError_Lcom_facebook_FacebookException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Lcom_facebook_FacebookException_));
			}
			return cb_onError_Lcom_facebook_FacebookException_;
		}

		private static void n_OnError_Lcom_facebook_FacebookException_(IntPtr jnienv, IntPtr native__this, IntPtr native_ex)
		{
			DeviceAuthDialog deviceAuthDialog = Java.Lang.Object.GetObject<DeviceAuthDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FacebookException ex = Java.Lang.Object.GetObject<FacebookException>(native_ex, JniHandleOwnership.DoNotTransfer);
			deviceAuthDialog.OnError(ex);
		}

		[Register("onError", "(Lcom/facebook/FacebookException;)V", "GetOnError_Lcom_facebook_FacebookException_Handler")]
		protected unsafe virtual void OnError(FacebookException ex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(ex?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onError.(Lcom/facebook/FacebookException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(ex);
			}
		}

		private static Delegate GetStartLogin_Lcom_facebook_login_LoginClient_Request_Handler()
		{
			if ((object)cb_startLogin_Lcom_facebook_login_LoginClient_Request_ == null)
			{
				cb_startLogin_Lcom_facebook_login_LoginClient_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StartLogin_Lcom_facebook_login_LoginClient_Request_));
			}
			return cb_startLogin_Lcom_facebook_login_LoginClient_Request_;
		}

		private static void n_StartLogin_Lcom_facebook_login_LoginClient_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
		{
			DeviceAuthDialog deviceAuthDialog = Java.Lang.Object.GetObject<DeviceAuthDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			deviceAuthDialog.StartLogin(request);
		}

		[Register("startLogin", "(Lcom/facebook/login/LoginClient$Request;)V", "GetStartLogin_Lcom_facebook_login_LoginClient_Request_Handler")]
		public unsafe virtual void StartLogin(LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("startLogin.(Lcom/facebook/login/LoginClient$Request;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}
	}
	[Register("com/facebook/login/DeviceAuthMethodHandler", DoNotGenerateAcw = true)]
	public class DeviceAuthMethodHandler : LoginMethodHandler
	{
		[Register("com/facebook/login/DeviceAuthMethodHandler$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/DeviceAuthMethodHandler$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/DeviceAuthMethodHandler", typeof(DeviceAuthMethodHandler));

		private static Delegate cb_getNameForLogging;

		private static Delegate cb_createDeviceAuthDialog;

		private static Delegate cb_describeContents;

		private static Delegate cb_onCancel;

		private static Delegate cb_onError_Ljava_lang_Exception_;

		private static Delegate cb_onSuccess_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_util_Collection_Ljava_util_Collection_Ljava_util_Collection_Lcom_facebook_AccessTokenSource_Ljava_util_Date_Ljava_util_Date_Ljava_util_Date_;

		private static Delegate cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_;

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe static ScheduledThreadPoolExecutor BackgroundExecutor
		{
			[Register("getBackgroundExecutor", "()Ljava/util/concurrent/ScheduledThreadPoolExecutor;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ScheduledThreadPoolExecutor>(_members.StaticMethods.InvokeObjectMethod("getBackgroundExecutor.()Ljava/util/concurrent/ScheduledThreadPoolExecutor;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string NameForLogging
		{
			[Register("getNameForLogging", "()Ljava/lang/String;", "GetGetNameForLoggingHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getNameForLogging.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected DeviceAuthMethodHandler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/os/Parcel;)V", "")]
		protected unsafe DeviceAuthMethodHandler(Parcel parcel)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Parcel;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Parcel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parcel);
			}
		}

		[Register(".ctor", "(Lcom/facebook/login/LoginClient;)V", "")]
		public unsafe DeviceAuthMethodHandler(LoginClient loginClient)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(loginClient?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/login/LoginClient;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/login/LoginClient;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(loginClient);
			}
		}

		private static Delegate GetGetNameForLoggingHandler()
		{
			if ((object)cb_getNameForLogging == null)
			{
				cb_getNameForLogging = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNameForLogging));
			}
			return cb_getNameForLogging;
		}

		private static IntPtr n_GetNameForLogging(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DeviceAuthMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NameForLogging);
		}

		private static Delegate GetCreateDeviceAuthDialogHandler()
		{
			if ((object)cb_createDeviceAuthDialog == null)
			{
				cb_createDeviceAuthDialog = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateDeviceAuthDialog));
			}
			return cb_createDeviceAuthDialog;
		}

		private static IntPtr n_CreateDeviceAuthDialog(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DeviceAuthMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateDeviceAuthDialog());
		}

		[Register("createDeviceAuthDialog", "()Lcom/facebook/login/DeviceAuthDialog;", "GetCreateDeviceAuthDialogHandler")]
		protected unsafe virtual DeviceAuthDialog CreateDeviceAuthDialog()
		{
			return Java.Lang.Object.GetObject<DeviceAuthDialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("createDeviceAuthDialog.()Lcom/facebook/login/DeviceAuthDialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<DeviceAuthMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe override int DescribeContents()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
		}

		private static Delegate GetOnCancelHandler()
		{
			if ((object)cb_onCancel == null)
			{
				cb_onCancel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCancel));
			}
			return cb_onCancel;
		}

		private static void n_OnCancel(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<DeviceAuthMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCancel();
		}

		[Register("onCancel", "()V", "GetOnCancelHandler")]
		public unsafe virtual void OnCancel()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCancel.()V", this, null);
		}

		private static Delegate GetOnError_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_onError_Ljava_lang_Exception_ == null)
			{
				cb_onError_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Ljava_lang_Exception_));
			}
			return cb_onError_Ljava_lang_Exception_;
		}

		private static void n_OnError_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_ex)
		{
			DeviceAuthMethodHandler deviceAuthMethodHandler = Java.Lang.Object.GetObject<DeviceAuthMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception ex = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_ex, JniHandleOwnership.DoNotTransfer);
			deviceAuthMethodHandler.OnError(ex);
		}

		[Register("onError", "(Ljava/lang/Exception;)V", "GetOnError_Ljava_lang_Exception_Handler")]
		public unsafe virtual void OnError(Java.Lang.Exception ex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(ex?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onError.(Ljava/lang/Exception;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(ex);
			}
		}

		private static Delegate GetOnSuccess_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_util_Collection_Ljava_util_Collection_Ljava_util_Collection_Lcom_facebook_AccessTokenSource_Ljava_util_Date_Ljava_util_Date_Ljava_util_Date_Handler()
		{
			if ((object)cb_onSuccess_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_util_Collection_Ljava_util_Collection_Ljava_util_Collection_Lcom_facebook_AccessTokenSource_Ljava_util_Date_Ljava_util_Date_Ljava_util_Date_ == null)
			{
				cb_onSuccess_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_util_Collection_Ljava_util_Collection_Ljava_util_Collection_Lcom_facebook_AccessTokenSource_Ljava_util_Date_Ljava_util_Date_Ljava_util_Date_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLLLLLLLL_V(n_OnSuccess_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_util_Collection_Ljava_util_Collection_Ljava_util_Collection_Lcom_facebook_AccessTokenSource_Ljava_util_Date_Ljava_util_Date_Ljava_util_Date_));
			}
			return cb_onSuccess_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_util_Collection_Ljava_util_Collection_Ljava_util_Collection_Lcom_facebook_AccessTokenSource_Ljava_util_Date_Ljava_util_Date_Ljava_util_Date_;
		}

		private static void n_OnSuccess_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_util_Collection_Ljava_util_Collection_Ljava_util_Collection_Lcom_facebook_AccessTokenSource_Ljava_util_Date_Ljava_util_Date_Ljava_util_Date_(IntPtr jnienv, IntPtr native__this, IntPtr native_accessToken, IntPtr native_applicationId, IntPtr native_userId, IntPtr native_permissions, IntPtr native_declinedPermissions, IntPtr native_expiredPermissions, IntPtr native_accessTokenSource, IntPtr native_expirationTime, IntPtr native_lastRefreshTime, IntPtr native_dataAccessExpirationTime)
		{
			DeviceAuthMethodHandler deviceAuthMethodHandler = Java.Lang.Object.GetObject<DeviceAuthMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string accessToken = JNIEnv.GetString(native_accessToken, JniHandleOwnership.DoNotTransfer);
			string applicationId = JNIEnv.GetString(native_applicationId, JniHandleOwnership.DoNotTransfer);
			string userId = JNIEnv.GetString(native_userId, JniHandleOwnership.DoNotTransfer);
			ICollection<string> permissions = JavaCollection<string>.FromJniHandle(native_permissions, JniHandleOwnership.DoNotTransfer);
			ICollection<string> declinedPermissions = JavaCollection<string>.FromJniHandle(native_declinedPermissions, JniHandleOwnership.DoNotTransfer);
			ICollection<string> expiredPermissions = JavaCollection<string>.FromJniHandle(native_expiredPermissions, JniHandleOwnership.DoNotTransfer);
			AccessTokenSource accessTokenSource = Java.Lang.Object.GetObject<AccessTokenSource>(native_accessTokenSource, JniHandleOwnership.DoNotTransfer);
			Date expirationTime = Java.Lang.Object.GetObject<Date>(native_expirationTime, JniHandleOwnership.DoNotTransfer);
			Date lastRefreshTime = Java.Lang.Object.GetObject<Date>(native_lastRefreshTime, JniHandleOwnership.DoNotTransfer);
			Date dataAccessExpirationTime = Java.Lang.Object.GetObject<Date>(native_dataAccessExpirationTime, JniHandleOwnership.DoNotTransfer);
			deviceAuthMethodHandler.OnSuccess(accessToken, applicationId, userId, permissions, declinedPermissions, expiredPermissions, accessTokenSource, expirationTime, lastRefreshTime, dataAccessExpirationTime);
		}

		[Register("onSuccess", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/Collection;Ljava/util/Collection;Ljava/util/Collection;Lcom/facebook/AccessTokenSource;Ljava/util/Date;Ljava/util/Date;Ljava/util/Date;)V", "GetOnSuccess_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_util_Collection_Ljava_util_Collection_Ljava_util_Collection_Lcom_facebook_AccessTokenSource_Ljava_util_Date_Ljava_util_Date_Ljava_util_Date_Handler")]
		public unsafe virtual void OnSuccess(string accessToken, string applicationId, string userId, ICollection<string> permissions, ICollection<string> declinedPermissions, ICollection<string> expiredPermissions, AccessTokenSource accessTokenSource, Date expirationTime, Date lastRefreshTime, Date dataAccessExpirationTime)
		{
			IntPtr intPtr = JNIEnv.NewString(accessToken);
			IntPtr intPtr2 = JNIEnv.NewString(applicationId);
			IntPtr intPtr3 = JNIEnv.NewString(userId);
			IntPtr intPtr4 = JavaCollection<string>.ToLocalJniHandle(permissions);
			IntPtr intPtr5 = JavaCollection<string>.ToLocalJniHandle(declinedPermissions);
			IntPtr intPtr6 = JavaCollection<string>.ToLocalJniHandle(expiredPermissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(intPtr4);
				ptr[4] = new JniArgumentValue(intPtr5);
				ptr[5] = new JniArgumentValue(intPtr6);
				ptr[6] = new JniArgumentValue(accessTokenSource?.Handle ?? IntPtr.Zero);
				ptr[7] = new JniArgumentValue(expirationTime?.Handle ?? IntPtr.Zero);
				ptr[8] = new JniArgumentValue(lastRefreshTime?.Handle ?? IntPtr.Zero);
				ptr[9] = new JniArgumentValue(dataAccessExpirationTime?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onSuccess.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/Collection;Ljava/util/Collection;Ljava/util/Collection;Lcom/facebook/AccessTokenSource;Ljava/util/Date;Ljava/util/Date;Ljava/util/Date;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				JNIEnv.DeleteLocalRef(intPtr4);
				JNIEnv.DeleteLocalRef(intPtr5);
				JNIEnv.DeleteLocalRef(intPtr6);
				GC.KeepAlive(permissions);
				GC.KeepAlive(declinedPermissions);
				GC.KeepAlive(expiredPermissions);
				GC.KeepAlive(accessTokenSource);
				GC.KeepAlive(expirationTime);
				GC.KeepAlive(lastRefreshTime);
				GC.KeepAlive(dataAccessExpirationTime);
			}
		}

		private static Delegate GetTryAuthorize_Lcom_facebook_login_LoginClient_Request_Handler()
		{
			if ((object)cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_ == null)
			{
				cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_TryAuthorize_Lcom_facebook_login_LoginClient_Request_));
			}
			return cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_;
		}

		private static int n_TryAuthorize_Lcom_facebook_login_LoginClient_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
		{
			DeviceAuthMethodHandler deviceAuthMethodHandler = Java.Lang.Object.GetObject<DeviceAuthMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			return deviceAuthMethodHandler.TryAuthorize(request);
		}

		[Register("tryAuthorize", "(Lcom/facebook/login/LoginClient$Request;)I", "GetTryAuthorize_Lcom_facebook_login_LoginClient_Request_Handler")]
		public unsafe override int TryAuthorize(LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("tryAuthorize.(Lcom/facebook/login/LoginClient$Request;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}
	}
	[Register("com/facebook/login/KatanaProxyLoginMethodHandler", DoNotGenerateAcw = true)]
	public sealed class KatanaProxyLoginMethodHandler : NativeAppLoginMethodHandler
	{
		[Register("com/facebook/login/KatanaProxyLoginMethodHandler$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/KatanaProxyLoginMethodHandler$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/KatanaProxyLoginMethodHandler", typeof(KatanaProxyLoginMethodHandler));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe override string NameForLogging
		{
			[Register("getNameForLogging", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getNameForLogging.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal KatanaProxyLoginMethodHandler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/os/Parcel;)V", "")]
		public unsafe KatanaProxyLoginMethodHandler(Parcel source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Parcel;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Parcel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Lcom/facebook/login/LoginClient;)V", "")]
		public unsafe KatanaProxyLoginMethodHandler(LoginClient loginClient)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(loginClient?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/login/LoginClient;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/login/LoginClient;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(loginClient);
			}
		}

		[Register("describeContents", "()I", "")]
		public unsafe override int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}

		[Register("tryAuthorize", "(Lcom/facebook/login/LoginClient$Request;)I", "")]
		public unsafe override int TryAuthorize(LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("tryAuthorize.(Lcom/facebook/login/LoginClient$Request;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}
	}
	[Register("com/facebook/login/LoginBehavior", DoNotGenerateAcw = true)]
	public sealed class LoginBehavior : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginBehavior", typeof(LoginBehavior));

		[Register("DEVICE_AUTH")]
		public static LoginBehavior DeviceAuth => Java.Lang.Object.GetObject<LoginBehavior>(_members.StaticFields.GetObjectValue("DEVICE_AUTH.Lcom/facebook/login/LoginBehavior;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DIALOG_ONLY")]
		public static LoginBehavior DialogOnly => Java.Lang.Object.GetObject<LoginBehavior>(_members.StaticFields.GetObjectValue("DIALOG_ONLY.Lcom/facebook/login/LoginBehavior;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("KATANA_ONLY")]
		public static LoginBehavior KatanaOnly => Java.Lang.Object.GetObject<LoginBehavior>(_members.StaticFields.GetObjectValue("KATANA_ONLY.Lcom/facebook/login/LoginBehavior;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NATIVE_ONLY")]
		public static LoginBehavior NativeOnly => Java.Lang.Object.GetObject<LoginBehavior>(_members.StaticFields.GetObjectValue("NATIVE_ONLY.Lcom/facebook/login/LoginBehavior;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NATIVE_WITH_FALLBACK")]
		public static LoginBehavior NativeWithFallback => Java.Lang.Object.GetObject<LoginBehavior>(_members.StaticFields.GetObjectValue("NATIVE_WITH_FALLBACK.Lcom/facebook/login/LoginBehavior;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("WEB_ONLY")]
		public static LoginBehavior WebOnly => Java.Lang.Object.GetObject<LoginBehavior>(_members.StaticFields.GetObjectValue("WEB_ONLY.Lcom/facebook/login/LoginBehavior;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("WEB_VIEW_ONLY")]
		[Obsolete("deprecated")]
		public static LoginBehavior WebViewOnly => Java.Lang.Object.GetObject<LoginBehavior>(_members.StaticFields.GetObjectValue("WEB_VIEW_ONLY.Lcom/facebook/login/LoginBehavior;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal LoginBehavior(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("allowsCustomTabAuth", "()Z", "")]
		public unsafe bool AllowsCustomTabAuth()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("allowsCustomTabAuth.()Z", this, null);
		}

		[Register("allowsDeviceAuth", "()Z", "")]
		public unsafe bool AllowsDeviceAuth()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("allowsDeviceAuth.()Z", this, null);
		}

		[Register("allowsFacebookLiteAuth", "()Z", "")]
		public unsafe bool AllowsFacebookLiteAuth()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("allowsFacebookLiteAuth.()Z", this, null);
		}

		[Register("allowsGetTokenAuth", "()Z", "")]
		public unsafe bool AllowsGetTokenAuth()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("allowsGetTokenAuth.()Z", this, null);
		}

		[Register("allowsInstagramAppAuth", "()Z", "")]
		public unsafe bool AllowsInstagramAppAuth()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("allowsInstagramAppAuth.()Z", this, null);
		}

		[Register("allowsKatanaAuth", "()Z", "")]
		public unsafe bool AllowsKatanaAuth()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("allowsKatanaAuth.()Z", this, null);
		}

		[Register("allowsWebViewAuth", "()Z", "")]
		public unsafe bool AllowsWebViewAuth()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("allowsWebViewAuth.()Z", this, null);
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/login/LoginBehavior;", "")]
		public unsafe static LoginBehavior ValueOf(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LoginBehavior>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/login/LoginBehavior;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/facebook/login/LoginBehavior;", "")]
		public unsafe static LoginBehavior[] Values()
		{
			return (LoginBehavior[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/login/LoginBehavior;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(LoginBehavior));
		}
	}
	[Register("com/facebook/login/LoginClient", DoNotGenerateAcw = true)]
	public class LoginClient : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/login/LoginClient$BackgroundProcessingListener", "", "Xamarin.Facebook.Login.LoginClient/IBackgroundProcessingListenerInvoker")]
		public interface IBackgroundProcessingListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onBackgroundProcessingStarted", "()V", "GetOnBackgroundProcessingStartedHandler:Xamarin.Facebook.Login.LoginClient/IBackgroundProcessingListenerInvoker, Xamarin.Facebook.Common.Android")]
			void OnBackgroundProcessingStarted();

			[Register("onBackgroundProcessingStopped", "()V", "GetOnBackgroundProcessingStoppedHandler:Xamarin.Facebook.Login.LoginClient/IBackgroundProcessingListenerInvoker, Xamarin.Facebook.Common.Android")]
			void OnBackgroundProcessingStopped();
		}

		[Register("com/facebook/login/LoginClient$BackgroundProcessingListener", DoNotGenerateAcw = true)]
		internal class IBackgroundProcessingListenerInvoker : Java.Lang.Object, IBackgroundProcessingListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginClient$BackgroundProcessingListener", typeof(IBackgroundProcessingListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onBackgroundProcessingStarted;

			private IntPtr id_onBackgroundProcessingStarted;

			private static Delegate cb_onBackgroundProcessingStopped;

			private IntPtr id_onBackgroundProcessingStopped;

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

			public static IBackgroundProcessingListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IBackgroundProcessingListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.login.LoginClient.BackgroundProcessingListener'.");
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

			public IBackgroundProcessingListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnBackgroundProcessingStartedHandler()
			{
				if ((object)cb_onBackgroundProcessingStarted == null)
				{
					cb_onBackgroundProcessingStarted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnBackgroundProcessingStarted));
				}
				return cb_onBackgroundProcessingStarted;
			}

			private static void n_OnBackgroundProcessingStarted(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IBackgroundProcessingListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBackgroundProcessingStarted();
			}

			public void OnBackgroundProcessingStarted()
			{
				if (id_onBackgroundProcessingStarted == IntPtr.Zero)
				{
					id_onBackgroundProcessingStarted = JNIEnv.GetMethodID(class_ref, "onBackgroundProcessingStarted", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onBackgroundProcessingStarted);
			}

			private static Delegate GetOnBackgroundProcessingStoppedHandler()
			{
				if ((object)cb_onBackgroundProcessingStopped == null)
				{
					cb_onBackgroundProcessingStopped = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnBackgroundProcessingStopped));
				}
				return cb_onBackgroundProcessingStopped;
			}

			private static void n_OnBackgroundProcessingStopped(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IBackgroundProcessingListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBackgroundProcessingStopped();
			}

			public void OnBackgroundProcessingStopped()
			{
				if (id_onBackgroundProcessingStopped == IntPtr.Zero)
				{
					id_onBackgroundProcessingStopped = JNIEnv.GetMethodID(class_ref, "onBackgroundProcessingStopped", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onBackgroundProcessingStopped);
			}
		}

		[Register("mono/com/facebook/login/LoginClient_BackgroundProcessingListenerImplementor")]
		internal sealed class IBackgroundProcessingListenerImplementor : Java.Lang.Object, IBackgroundProcessingListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler OnBackgroundProcessingStartedHandler;

			public EventHandler OnBackgroundProcessingStoppedHandler;

			public IBackgroundProcessingListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/facebook/login/LoginClient_BackgroundProcessingListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnBackgroundProcessingStarted()
			{
				OnBackgroundProcessingStartedHandler?.Invoke(sender, new EventArgs());
			}

			public void OnBackgroundProcessingStopped()
			{
				OnBackgroundProcessingStoppedHandler?.Invoke(sender, new EventArgs());
			}

			internal static bool __IsEmpty(IBackgroundProcessingListenerImplementor value)
			{
				if (value.OnBackgroundProcessingStartedHandler == null)
				{
					return value.OnBackgroundProcessingStoppedHandler == null;
				}
				return false;
			}
		}

		[Register("com/facebook/login/LoginClient$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginClient$Companion", typeof(Companion));

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

			public unsafe string E2E
			{
				[Register("getE2E", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getE2E.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe int LoginRequestCode
			{
				[Register("getLoginRequestCode", "()I", "")]
				get
				{
					return _members.InstanceMethods.InvokeNonvirtualInt32Method("getLoginRequestCode.()I", this, null);
				}
			}

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		[Register("com/facebook/login/LoginClient$OnCompletedListener", "", "Xamarin.Facebook.Login.LoginClient/IOnCompletedListenerInvoker")]
		public interface IOnCompletedListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onCompleted", "(Lcom/facebook/login/LoginClient$Result;)V", "GetOnCompleted_Lcom_facebook_login_LoginClient_Result_Handler:Xamarin.Facebook.Login.LoginClient/IOnCompletedListenerInvoker, Xamarin.Facebook.Common.Android")]
			void OnCompleted(Result result);
		}

		[Register("com/facebook/login/LoginClient$OnCompletedListener", DoNotGenerateAcw = true)]
		internal class IOnCompletedListenerInvoker : Java.Lang.Object, IOnCompletedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginClient$OnCompletedListener", typeof(IOnCompletedListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onCompleted_Lcom_facebook_login_LoginClient_Result_;

			private IntPtr id_onCompleted_Lcom_facebook_login_LoginClient_Result_;

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

			public static IOnCompletedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnCompletedListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.login.LoginClient.OnCompletedListener'.");
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

			public IOnCompletedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCompleted_Lcom_facebook_login_LoginClient_Result_Handler()
			{
				if ((object)cb_onCompleted_Lcom_facebook_login_LoginClient_Result_ == null)
				{
					cb_onCompleted_Lcom_facebook_login_LoginClient_Result_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCompleted_Lcom_facebook_login_LoginClient_Result_));
				}
				return cb_onCompleted_Lcom_facebook_login_LoginClient_Result_;
			}

			private static void n_OnCompleted_Lcom_facebook_login_LoginClient_Result_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
			{
				IOnCompletedListener onCompletedListener = Java.Lang.Object.GetObject<IOnCompletedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Result result = Java.Lang.Object.GetObject<Result>(native_result, JniHandleOwnership.DoNotTransfer);
				onCompletedListener.OnCompleted(result);
			}

			public unsafe void OnCompleted(Result result)
			{
				if (id_onCompleted_Lcom_facebook_login_LoginClient_Result_ == IntPtr.Zero)
				{
					id_onCompleted_Lcom_facebook_login_LoginClient_Result_ = JNIEnv.GetMethodID(class_ref, "onCompleted", "(Lcom/facebook/login/LoginClient$Result;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(result?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onCompleted_Lcom_facebook_login_LoginClient_Result_, ptr);
			}
		}

		public class CompletedEventArgs : EventArgs
		{
			private Result result;

			public Result Result => result;

			public CompletedEventArgs(Result result)
			{
				this.result = result;
			}
		}

		[Register("mono/com/facebook/login/LoginClient_OnCompletedListenerImplementor")]
		internal sealed class IOnCompletedListenerImplementor : Java.Lang.Object, IOnCompletedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<CompletedEventArgs> Handler;

			public IOnCompletedListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/facebook/login/LoginClient_OnCompletedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnCompleted(Result result)
			{
				Handler?.Invoke(sender, new CompletedEventArgs(result));
			}

			internal static bool __IsEmpty(IOnCompletedListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/facebook/login/LoginClient$Request", DoNotGenerateAcw = true)]
		public sealed class Request : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("com/facebook/login/LoginClient$Request$Companion", DoNotGenerateAcw = true)]
			public sealed class Companion : Java.Lang.Object
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginClient$Request$Companion", typeof(Companion));

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

				internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
					: base(javaReference, transfer)
				{
				}

				[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
				public unsafe Companion(DefaultConstructorMarker _constructor_marker)
					: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
				{
					if (base.Handle != IntPtr.Zero)
					{
						return;
					}
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
						SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
						_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(_constructor_marker);
					}
				}
			}

			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginClient$Request", typeof(Request));

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

			public unsafe string ApplicationId
			{
				[Register("getApplicationId", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getApplicationId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe string AuthId
			{
				[Register("getAuthId", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAuthId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setAuthId", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setAuthId.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			public unsafe string AuthType
			{
				[Register("getAuthType", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAuthType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setAuthType", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setAuthType.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			public unsafe string CodeChallenge
			{
				[Register("getCodeChallenge", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCodeChallenge.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe CodeChallengeMethod CodeChallengeMethod
			{
				[Register("getCodeChallengeMethod", "()Lcom/facebook/login/CodeChallengeMethod;", "")]
				get
				{
					return Java.Lang.Object.GetObject<CodeChallengeMethod>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCodeChallengeMethod.()Lcom/facebook/login/CodeChallengeMethod;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe string CodeVerifier
			{
				[Register("getCodeVerifier", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCodeVerifier.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe DefaultAudience DefaultAudience
			{
				[Register("getDefaultAudience", "()Lcom/facebook/login/DefaultAudience;", "")]
				get
				{
					return Java.Lang.Object.GetObject<DefaultAudience>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDefaultAudience.()Lcom/facebook/login/DefaultAudience;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe string DeviceAuthTargetUserId
			{
				[Register("getDeviceAuthTargetUserId", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDeviceAuthTargetUserId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setDeviceAuthTargetUserId", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDeviceAuthTargetUserId.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			public unsafe string DeviceRedirectUriString
			{
				[Register("getDeviceRedirectUriString", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDeviceRedirectUriString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setDeviceRedirectUriString", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDeviceRedirectUriString.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			public unsafe bool FamilyLogin
			{
				[Register("isFamilyLogin", "()Z", "")]
				get
				{
					return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isFamilyLogin.()Z", this, null);
				}
				[Register("setFamilyLogin", "(Z)V", "")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setFamilyLogin.(Z)V", this, ptr);
				}
			}

			public unsafe bool HasPublishPermission
			{
				[Register("hasPublishPermission", "()Z", "")]
				get
				{
					return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasPublishPermission.()Z", this, null);
				}
			}

			public unsafe bool IsInstagramLogin
			{
				[Register("isInstagramLogin", "()Z", "")]
				get
				{
					return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isInstagramLogin.()Z", this, null);
				}
			}

			public unsafe LoginBehavior LoginBehavior
			{
				[Register("getLoginBehavior", "()Lcom/facebook/login/LoginBehavior;", "")]
				get
				{
					return Java.Lang.Object.GetObject<LoginBehavior>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLoginBehavior.()Lcom/facebook/login/LoginBehavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe LoginTargetApp LoginTargetApp
			{
				[Register("getLoginTargetApp", "()Lcom/facebook/login/LoginTargetApp;", "")]
				get
				{
					return Java.Lang.Object.GetObject<LoginTargetApp>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLoginTargetApp.()Lcom/facebook/login/LoginTargetApp;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe string MessengerPageId
			{
				[Register("getMessengerPageId", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getMessengerPageId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setMessengerPageId", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMessengerPageId.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			public unsafe string Nonce
			{
				[Register("getNonce", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNonce.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe ICollection<string> Permissions
			{
				[Register("getPermissions", "()Ljava/util/Set;", "")]
				get
				{
					return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPermissions.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setPermissions", "(Ljava/util/Set;)V", "")]
				set
				{
					IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPermissions.(Ljava/util/Set;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
						GC.KeepAlive(value);
					}
				}
			}

			public unsafe bool Rerequest
			{
				[Register("isRerequest", "()Z", "")]
				get
				{
					return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isRerequest.()Z", this, null);
				}
				[Register("setRerequest", "(Z)V", "")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setRerequest.(Z)V", this, ptr);
				}
			}

			public unsafe bool ResetMessengerState
			{
				[Register("getResetMessengerState", "()Z", "")]
				get
				{
					return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getResetMessengerState.()Z", this, null);
				}
				[Register("setResetMessengerState", "(Z)V", "")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setResetMessengerState.(Z)V", this, ptr);
				}
			}

			internal Request(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/os/Parcel;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Request(Parcel parcel, DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Parcel;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Parcel;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(parcel);
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register(".ctor", "(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
			public unsafe Request(LoginBehavior loginBehavior, ICollection<string> permissions, DefaultAudience defaultAudience, string authType, string applicationId, string authId)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(permissions);
				IntPtr intPtr2 = JNIEnv.NewString(authType);
				IntPtr intPtr3 = JNIEnv.NewString(applicationId);
				IntPtr intPtr4 = JNIEnv.NewString(authId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
					*ptr = new JniArgumentValue(loginBehavior?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(defaultAudience?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(intPtr2);
					ptr[4] = new JniArgumentValue(intPtr3);
					ptr[5] = new JniArgumentValue(intPtr4);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					JNIEnv.DeleteLocalRef(intPtr3);
					JNIEnv.DeleteLocalRef(intPtr4);
					GC.KeepAlive(loginBehavior);
					GC.KeepAlive(permissions);
					GC.KeepAlive(defaultAudience);
				}
			}

			[Register(".ctor", "(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;)V", "")]
			public unsafe Request(LoginBehavior loginBehavior, ICollection<string> permissions, DefaultAudience defaultAudience, string authType, string applicationId, string authId, LoginTargetApp targetApp)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(permissions);
				IntPtr intPtr2 = JNIEnv.NewString(authType);
				IntPtr intPtr3 = JNIEnv.NewString(applicationId);
				IntPtr intPtr4 = JNIEnv.NewString(authId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
					*ptr = new JniArgumentValue(loginBehavior?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(defaultAudience?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(intPtr2);
					ptr[4] = new JniArgumentValue(intPtr3);
					ptr[5] = new JniArgumentValue(intPtr4);
					ptr[6] = new JniArgumentValue(targetApp?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					JNIEnv.DeleteLocalRef(intPtr3);
					JNIEnv.DeleteLocalRef(intPtr4);
					GC.KeepAlive(loginBehavior);
					GC.KeepAlive(permissions);
					GC.KeepAlive(defaultAudience);
					GC.KeepAlive(targetApp);
				}
			}

			[Register(".ctor", "(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;Ljava/lang/String;)V", "")]
			public unsafe Request(LoginBehavior loginBehavior, ICollection<string> permissions, DefaultAudience defaultAudience, string authType, string applicationId, string authId, LoginTargetApp targetApp, string nonce)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(permissions);
				IntPtr intPtr2 = JNIEnv.NewString(authType);
				IntPtr intPtr3 = JNIEnv.NewString(applicationId);
				IntPtr intPtr4 = JNIEnv.NewString(authId);
				IntPtr intPtr5 = JNIEnv.NewString(nonce);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
					*ptr = new JniArgumentValue(loginBehavior?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(defaultAudience?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(intPtr2);
					ptr[4] = new JniArgumentValue(intPtr3);
					ptr[5] = new JniArgumentValue(intPtr4);
					ptr[6] = new JniArgumentValue(targetApp?.Handle ?? IntPtr.Zero);
					ptr[7] = new JniArgumentValue(intPtr5);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					JNIEnv.DeleteLocalRef(intPtr3);
					JNIEnv.DeleteLocalRef(intPtr4);
					JNIEnv.DeleteLocalRef(intPtr5);
					GC.KeepAlive(loginBehavior);
					GC.KeepAlive(permissions);
					GC.KeepAlive(defaultAudience);
					GC.KeepAlive(targetApp);
				}
			}

			[Register(".ctor", "(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;Ljava/lang/String;Ljava/lang/String;)V", "")]
			public unsafe Request(LoginBehavior loginBehavior, ICollection<string> permissions, DefaultAudience defaultAudience, string authType, string applicationId, string authId, LoginTargetApp targetApp, string nonce, string codeVerifier)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(permissions);
				IntPtr intPtr2 = JNIEnv.NewString(authType);
				IntPtr intPtr3 = JNIEnv.NewString(applicationId);
				IntPtr intPtr4 = JNIEnv.NewString(authId);
				IntPtr intPtr5 = JNIEnv.NewString(nonce);
				IntPtr intPtr6 = JNIEnv.NewString(codeVerifier);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
					*ptr = new JniArgumentValue(loginBehavior?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(defaultAudience?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(intPtr2);
					ptr[4] = new JniArgumentValue(intPtr3);
					ptr[5] = new JniArgumentValue(intPtr4);
					ptr[6] = new JniArgumentValue(targetApp?.Handle ?? IntPtr.Zero);
					ptr[7] = new JniArgumentValue(intPtr5);
					ptr[8] = new JniArgumentValue(intPtr6);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					JNIEnv.DeleteLocalRef(intPtr3);
					JNIEnv.DeleteLocalRef(intPtr4);
					JNIEnv.DeleteLocalRef(intPtr5);
					JNIEnv.DeleteLocalRef(intPtr6);
					GC.KeepAlive(loginBehavior);
					GC.KeepAlive(permissions);
					GC.KeepAlive(defaultAudience);
					GC.KeepAlive(targetApp);
				}
			}

			[Register(".ctor", "(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
			public unsafe Request(LoginBehavior loginBehavior, ICollection<string> permissions, DefaultAudience defaultAudience, string authType, string applicationId, string authId, LoginTargetApp targetApp, string nonce, string codeVerifier, string codeChallenge)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(permissions);
				IntPtr intPtr2 = JNIEnv.NewString(authType);
				IntPtr intPtr3 = JNIEnv.NewString(applicationId);
				IntPtr intPtr4 = JNIEnv.NewString(authId);
				IntPtr intPtr5 = JNIEnv.NewString(nonce);
				IntPtr intPtr6 = JNIEnv.NewString(codeVerifier);
				IntPtr intPtr7 = JNIEnv.NewString(codeChallenge);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
					*ptr = new JniArgumentValue(loginBehavior?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(defaultAudience?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(intPtr2);
					ptr[4] = new JniArgumentValue(intPtr3);
					ptr[5] = new JniArgumentValue(intPtr4);
					ptr[6] = new JniArgumentValue(targetApp?.Handle ?? IntPtr.Zero);
					ptr[7] = new JniArgumentValue(intPtr5);
					ptr[8] = new JniArgumentValue(intPtr6);
					ptr[9] = new JniArgumentValue(intPtr7);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/login/LoginBehavior;Ljava/util/Set;Lcom/facebook/login/DefaultAudience;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/login/LoginTargetApp;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					JNIEnv.DeleteLocalRef(intPtr3);
					JNIEnv.DeleteLocalRef(intPtr4);
					JNIEnv.DeleteLocalRef(intPtr5);
					JNIEnv.DeleteLocalRef(intPtr6);
					JNIEnv.DeleteLocalRef(intPtr7);
					GC.KeepAlive(loginBehavior);
					GC.KeepAlive(permissions);
					GC.KeepAlive(defaultAudience);
					GC.KeepAlive(targetApp);
				}
			}

			[Register("describeContents", "()I", "")]
			public unsafe int DescribeContents()
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
			}

			[Register("shouldSkipAccountDeduplication", "()Z", "")]
			public unsafe bool ShouldSkipAccountDeduplication()
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("shouldSkipAccountDeduplication.()Z", this, null);
			}

			[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
			public unsafe void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue((int)flags);
					_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(dest);
				}
			}
		}

		[Register("com/facebook/login/LoginClient$Result", DoNotGenerateAcw = true)]
		public sealed class Result : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("com/facebook/login/LoginClient$Result$Code", DoNotGenerateAcw = true)]
			public sealed class Code : Java.Lang.Enum
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginClient$Result$Code", typeof(Code));

				[Register("CANCEL")]
				public static Code Cancel => Java.Lang.Object.GetObject<Code>(_members.StaticFields.GetObjectValue("CANCEL.Lcom/facebook/login/LoginClient$Result$Code;").Handle, JniHandleOwnership.TransferLocalRef);

				[Register("ERROR")]
				public static Code Error => Java.Lang.Object.GetObject<Code>(_members.StaticFields.GetObjectValue("ERROR.Lcom/facebook/login/LoginClient$Result$Code;").Handle, JniHandleOwnership.TransferLocalRef);

				[Register("SUCCESS")]
				public static Code Success => Java.Lang.Object.GetObject<Code>(_members.StaticFields.GetObjectValue("SUCCESS.Lcom/facebook/login/LoginClient$Result$Code;").Handle, JniHandleOwnership.TransferLocalRef);

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

				public unsafe string LoggingValue
				{
					[Register("getLoggingValue", "()Ljava/lang/String;", "")]
					get
					{
						return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLoggingValue.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
					}
				}

				internal Code(IntPtr javaReference, JniHandleOwnership transfer)
					: base(javaReference, transfer)
				{
				}

				[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result$Code;", "")]
				public unsafe static Code ValueOf(string value)
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						return Java.Lang.Object.GetObject<Code>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result$Code;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}

				[Register("values", "()[Lcom/facebook/login/LoginClient$Result$Code;", "")]
				public unsafe static Code[] Values()
				{
					return (Code[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/login/LoginClient$Result$Code;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Code));
				}
			}

			[Register("com/facebook/login/LoginClient$Result$Companion", DoNotGenerateAcw = true)]
			public sealed class Companion : Java.Lang.Object
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginClient$Result$Companion", typeof(Companion));

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

				internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
					: base(javaReference, transfer)
				{
				}

				[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
				public unsafe Companion(DefaultConstructorMarker _constructor_marker)
					: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
				{
					if (base.Handle != IntPtr.Zero)
					{
						return;
					}
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
						SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
						_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(_constructor_marker);
					}
				}

				[Register("createCancelResult", "(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", "")]
				public unsafe Result CreateCancelResult(Request request, string message)
				{
					IntPtr intPtr = JNIEnv.NewString(message);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
						*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
						ptr[1] = new JniArgumentValue(intPtr);
						return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createCancelResult.(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
						GC.KeepAlive(request);
					}
				}

				[Register("createCompositeTokenResult", "(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;)Lcom/facebook/login/LoginClient$Result;", "")]
				public unsafe Result CreateCompositeTokenResult(Request request, AccessToken accessToken, AuthenticationToken authenticationToken)
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
						*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
						ptr[1] = new JniArgumentValue(accessToken?.Handle ?? IntPtr.Zero);
						ptr[2] = new JniArgumentValue(authenticationToken?.Handle ?? IntPtr.Zero);
						return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createCompositeTokenResult.(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;)Lcom/facebook/login/LoginClient$Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
						GC.KeepAlive(request);
						GC.KeepAlive(accessToken);
						GC.KeepAlive(authenticationToken);
					}
				}

				[Register("createErrorResult", "(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", "")]
				public unsafe Result CreateErrorResult(Request request, string errorType, string errorDescription)
				{
					IntPtr intPtr = JNIEnv.NewString(errorType);
					IntPtr intPtr2 = JNIEnv.NewString(errorDescription);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
						*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
						ptr[1] = new JniArgumentValue(intPtr);
						ptr[2] = new JniArgumentValue(intPtr2);
						return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createErrorResult.(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
						JNIEnv.DeleteLocalRef(intPtr2);
						GC.KeepAlive(request);
					}
				}

				[Register("createErrorResult", "(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", "")]
				public unsafe Result CreateErrorResult(Request request, string errorType, string errorDescription, string errorCode)
				{
					IntPtr intPtr = JNIEnv.NewString(errorType);
					IntPtr intPtr2 = JNIEnv.NewString(errorDescription);
					IntPtr intPtr3 = JNIEnv.NewString(errorCode);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
						*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
						ptr[1] = new JniArgumentValue(intPtr);
						ptr[2] = new JniArgumentValue(intPtr2);
						ptr[3] = new JniArgumentValue(intPtr3);
						return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createErrorResult.(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
						JNIEnv.DeleteLocalRef(intPtr2);
						JNIEnv.DeleteLocalRef(intPtr3);
						GC.KeepAlive(request);
					}
				}

				[Register("createTokenResult", "(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;)Lcom/facebook/login/LoginClient$Result;", "")]
				public unsafe Result CreateTokenResult(Request request, AccessToken token)
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
						*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
						ptr[1] = new JniArgumentValue(token?.Handle ?? IntPtr.Zero);
						return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createTokenResult.(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;)Lcom/facebook/login/LoginClient$Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
						GC.KeepAlive(request);
						GC.KeepAlive(token);
					}
				}
			}

			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginClient$Result", typeof(Result));

			[Register("authenticationToken")]
			public AuthenticationToken AuthenticationToken
			{
				get
				{
					return Java.Lang.Object.GetObject<AuthenticationToken>(_members.InstanceFields.GetObjectValue("authenticationToken.Lcom/facebook/AuthenticationToken;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("authenticationToken.Lcom/facebook/AuthenticationToken;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("CREATOR")]
			public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("errorCode")]
			public string ErrorCode
			{
				get
				{
					return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("errorCode.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.NewString(value);
					try
					{
						_members.InstanceFields.SetValue("errorCode.Ljava/lang/String;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("errorMessage")]
			public string ErrorMessage
			{
				get
				{
					return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("errorMessage.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.NewString(value);
					try
					{
						_members.InstanceFields.SetValue("errorMessage.Ljava/lang/String;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("extraData")]
			public IDictionary ExtraData
			{
				get
				{
					return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("extraData.Ljava/util/Map;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JavaDictionary.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("extraData.Ljava/util/Map;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("loggingExtras")]
			public IDictionary LoggingExtras
			{
				get
				{
					return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("loggingExtras.Ljava/util/Map;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JavaDictionary.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("loggingExtras.Ljava/util/Map;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("request")]
			public Request Request
			{
				get
				{
					return Java.Lang.Object.GetObject<Request>(_members.InstanceFields.GetObjectValue("request.Lcom/facebook/login/LoginClient$Request;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("request.Lcom/facebook/login/LoginClient$Request;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("token")]
			public AccessToken Token
			{
				get
				{
					return Java.Lang.Object.GetObject<AccessToken>(_members.InstanceFields.GetObjectValue("token.Lcom/facebook/AccessToken;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("token.Lcom/facebook/AccessToken;", this, new JniObjectReference(jobject));
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

			internal Result(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/os/Parcel;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Result(Parcel parcel, DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Parcel;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Parcel;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(parcel);
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("createCancelResult", "(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", "")]
			public unsafe static Result CreateCancelResult(Request request, string message)
			{
				IntPtr intPtr = JNIEnv.NewString(message);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Result>(_members.StaticMethods.InvokeObjectMethod("createCancelResult.(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(request);
				}
			}

			[Register("createCompositeTokenResult", "(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;)Lcom/facebook/login/LoginClient$Result;", "")]
			public unsafe static Result CreateCompositeTokenResult(Request request, AccessToken accessToken, AuthenticationToken authenticationToken)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(accessToken?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(authenticationToken?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Result>(_members.StaticMethods.InvokeObjectMethod("createCompositeTokenResult.(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;)Lcom/facebook/login/LoginClient$Result;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(request);
					GC.KeepAlive(accessToken);
					GC.KeepAlive(authenticationToken);
				}
			}

			[Register("createErrorResult", "(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", "")]
			public unsafe static Result CreateErrorResult(Request request, string errorType, string errorDescription)
			{
				IntPtr intPtr = JNIEnv.NewString(errorType);
				IntPtr intPtr2 = JNIEnv.NewString(errorDescription);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Result>(_members.StaticMethods.InvokeObjectMethod("createErrorResult.(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(request);
				}
			}

			[Register("createErrorResult", "(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", "")]
			public unsafe static Result CreateErrorResult(Request request, string errorType, string errorDescription, string errorCode)
			{
				IntPtr intPtr = JNIEnv.NewString(errorType);
				IntPtr intPtr2 = JNIEnv.NewString(errorDescription);
				IntPtr intPtr3 = JNIEnv.NewString(errorCode);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					ptr[3] = new JniArgumentValue(intPtr3);
					return Java.Lang.Object.GetObject<Result>(_members.StaticMethods.InvokeObjectMethod("createErrorResult.(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/login/LoginClient$Result;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					JNIEnv.DeleteLocalRef(intPtr3);
					GC.KeepAlive(request);
				}
			}

			[Register("createTokenResult", "(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;)Lcom/facebook/login/LoginClient$Result;", "")]
			public unsafe static Result CreateTokenResult(Request request, AccessToken token)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(token?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Result>(_members.StaticMethods.InvokeObjectMethod("createTokenResult.(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;)Lcom/facebook/login/LoginClient$Result;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(request);
					GC.KeepAlive(token);
				}
			}

			[Register("describeContents", "()I", "")]
			public unsafe int DescribeContents()
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
			}

			[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
			public unsafe void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue((int)flags);
					_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(dest);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginClient", typeof(LoginClient));

		private static Delegate cb_describeContents;

		private static Delegate cb_getHandlersToTry_Lcom_facebook_login_LoginClient_Request_;

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

		private WeakReference weak_implementor___SetBackgroundProcessingListener;

		private WeakReference weak_implementor___SetOnCompletedListener;

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

		public unsafe FragmentActivity Activity
		{
			[Register("getActivity", "()Landroidx/fragment/app/FragmentActivity;", "")]
			get
			{
				return Java.Lang.Object.GetObject<FragmentActivity>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getActivity.()Landroidx/fragment/app/FragmentActivity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IBackgroundProcessingListener BackgroundProcessingListener
		{
			[Register("getBackgroundProcessingListener", "()Lcom/facebook/login/LoginClient$BackgroundProcessingListener;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IBackgroundProcessingListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBackgroundProcessingListener.()Lcom/facebook/login/LoginClient$BackgroundProcessingListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setBackgroundProcessingListener", "(Lcom/facebook/login/LoginClient$BackgroundProcessingListener;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setBackgroundProcessingListener.(Lcom/facebook/login/LoginClient$BackgroundProcessingListener;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe bool CheckedInternetPermission
		{
			[Register("getCheckedInternetPermission", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getCheckedInternetPermission.()Z", this, null);
			}
			[Register("setCheckedInternetPermission", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCheckedInternetPermission.(Z)V", this, ptr);
			}
		}

		public unsafe LoginMethodHandler CurrentHandler
		{
			[Register("getCurrentHandler", "()Lcom/facebook/login/LoginMethodHandler;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LoginMethodHandler>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCurrentHandler.()Lcom/facebook/login/LoginMethodHandler;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static string E2E
		{
			[Register("getE2E", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getE2E.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IDictionary<string, string> ExtraData
		{
			[Register("getExtraData", "()Ljava/util/Map;", "")]
			get
			{
				return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getExtraData.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setExtraData", "(Ljava/util/Map;)V", "")]
			set
			{
				IntPtr intPtr = JavaDictionary<string, string>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setExtraData.(Ljava/util/Map;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe AndroidX.Fragment.App.Fragment Fragment
		{
			[Register("getFragment", "()Landroidx/fragment/app/Fragment;", "")]
			get
			{
				return Java.Lang.Object.GetObject<AndroidX.Fragment.App.Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setFragment", "(Landroidx/fragment/app/Fragment;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setFragment.(Landroidx/fragment/app/Fragment;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe bool InProgress
		{
			[Register("getInProgress", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getInProgress.()Z", this, null);
			}
		}

		public unsafe IDictionary<string, string> LoggingExtras
		{
			[Register("getLoggingExtras", "()Ljava/util/Map;", "")]
			get
			{
				return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLoggingExtras.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLoggingExtras", "(Ljava/util/Map;)V", "")]
			set
			{
				IntPtr intPtr = JavaDictionary<string, string>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLoggingExtras.(Ljava/util/Map;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe static int LoginRequestCode
		{
			[Register("getLoginRequestCode", "()I", "")]
			get
			{
				return _members.StaticMethods.InvokeInt32Method("getLoginRequestCode.()I", null);
			}
		}

		public unsafe IOnCompletedListener OnCompletedListener
		{
			[Register("getOnCompletedListener", "()Lcom/facebook/login/LoginClient$OnCompletedListener;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IOnCompletedListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOnCompletedListener.()Lcom/facebook/login/LoginClient$OnCompletedListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setOnCompletedListener", "(Lcom/facebook/login/LoginClient$OnCompletedListener;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnCompletedListener.(Lcom/facebook/login/LoginClient$OnCompletedListener;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Request PendingRequest
		{
			[Register("getPendingRequest", "()Lcom/facebook/login/LoginClient$Request;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Request>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPendingRequest.()Lcom/facebook/login/LoginClient$Request;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPendingRequest", "(Lcom/facebook/login/LoginClient$Request;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPendingRequest.(Lcom/facebook/login/LoginClient$Request;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public event EventHandler BackgroundProcessingStarted
		{
			add
			{
				EventHelper.AddEventHandler(ref weak_implementor___SetBackgroundProcessingListener, __CreateIBackgroundProcessingListenerImplementor, delegate(IBackgroundProcessingListener __v)
				{
					BackgroundProcessingListener = __v;
				}, delegate(IBackgroundProcessingListenerImplementor __h)
				{
					__h.OnBackgroundProcessingStartedHandler = (EventHandler)Delegate.Combine(__h.OnBackgroundProcessingStartedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IBackgroundProcessingListener, IBackgroundProcessingListenerImplementor>(ref weak_implementor___SetBackgroundProcessingListener, IBackgroundProcessingListenerImplementor.__IsEmpty, delegate
				{
					BackgroundProcessingListener = null;
				}, delegate(IBackgroundProcessingListenerImplementor __h)
				{
					__h.OnBackgroundProcessingStartedHandler = (EventHandler)Delegate.Remove(__h.OnBackgroundProcessingStartedHandler, value);
				});
			}
		}

		public event EventHandler BackgroundProcessingStopped
		{
			add
			{
				EventHelper.AddEventHandler(ref weak_implementor___SetBackgroundProcessingListener, __CreateIBackgroundProcessingListenerImplementor, delegate(IBackgroundProcessingListener __v)
				{
					BackgroundProcessingListener = __v;
				}, delegate(IBackgroundProcessingListenerImplementor __h)
				{
					__h.OnBackgroundProcessingStoppedHandler = (EventHandler)Delegate.Combine(__h.OnBackgroundProcessingStoppedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IBackgroundProcessingListener, IBackgroundProcessingListenerImplementor>(ref weak_implementor___SetBackgroundProcessingListener, IBackgroundProcessingListenerImplementor.__IsEmpty, delegate
				{
					BackgroundProcessingListener = null;
				}, delegate(IBackgroundProcessingListenerImplementor __h)
				{
					__h.OnBackgroundProcessingStoppedHandler = (EventHandler)Delegate.Remove(__h.OnBackgroundProcessingStoppedHandler, value);
				});
			}
		}

		public event EventHandler<CompletedEventArgs> Completed
		{
			add
			{
				EventHelper.AddEventHandler(ref weak_implementor___SetOnCompletedListener, __CreateIOnCompletedListenerImplementor, delegate(IOnCompletedListener __v)
				{
					OnCompletedListener = __v;
				}, delegate(IOnCompletedListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CompletedEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnCompletedListener, IOnCompletedListenerImplementor>(ref weak_implementor___SetOnCompletedListener, IOnCompletedListenerImplementor.__IsEmpty, delegate
				{
					OnCompletedListener = null;
				}, delegate(IOnCompletedListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CompletedEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		protected LoginClient(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/os/Parcel;)V", "")]
		public unsafe LoginClient(Parcel source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Parcel;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Parcel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Landroidx/fragment/app/Fragment;)V", "")]
		public unsafe LoginClient(AndroidX.Fragment.App.Fragment fragment)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/Fragment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register("addExtraData", "(Ljava/lang/String;Ljava/lang/String;Z)V", "")]
		public unsafe void AddExtraData(string key, string value, bool accumulate)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			IntPtr intPtr2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(accumulate);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addExtraData.(Ljava/lang/String;Ljava/lang/String;Z)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("authorize", "(Lcom/facebook/login/LoginClient$Request;)V", "")]
		public unsafe void Authorize(Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("authorize.(Lcom/facebook/login/LoginClient$Request;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}

		[Register("cancelCurrentHandler", "()V", "")]
		public unsafe void CancelCurrentHandler()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("cancelCurrentHandler.()V", this, null);
		}

		[Register("checkInternetPermission", "()Z", "")]
		public unsafe bool CheckInternetPermission()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("checkInternetPermission.()Z", this, null);
		}

		[Register("checkPermission", "(Ljava/lang/String;)I", "")]
		public unsafe int CheckPermission(string permission)
		{
			IntPtr intPtr = JNIEnv.NewString(permission);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("checkPermission.(Ljava/lang/String;)I", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("complete", "(Lcom/facebook/login/LoginClient$Result;)V", "")]
		public unsafe void Complete(Result outcome)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(outcome?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("complete.(Lcom/facebook/login/LoginClient$Result;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(outcome);
			}
		}

		[Register("completeAndValidate", "(Lcom/facebook/login/LoginClient$Result;)V", "")]
		public unsafe void CompleteAndValidate(Result outcome)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(outcome?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("completeAndValidate.(Lcom/facebook/login/LoginClient$Result;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(outcome);
			}
		}

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoginClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe virtual int DescribeContents()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
		}

		[Register("getHandlersToTry", "()[Lcom/facebook/login/LoginMethodHandler;", "")]
		public unsafe LoginMethodHandler[] GetHandlersToTry()
		{
			return (LoginMethodHandler[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getHandlersToTry.()[Lcom/facebook/login/LoginMethodHandler;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(LoginMethodHandler));
		}

		private static Delegate GetGetHandlersToTry_Lcom_facebook_login_LoginClient_Request_Handler()
		{
			if ((object)cb_getHandlersToTry_Lcom_facebook_login_LoginClient_Request_ == null)
			{
				cb_getHandlersToTry_Lcom_facebook_login_LoginClient_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetHandlersToTry_Lcom_facebook_login_LoginClient_Request_));
			}
			return cb_getHandlersToTry_Lcom_facebook_login_LoginClient_Request_;
		}

		private static IntPtr n_GetHandlersToTry_Lcom_facebook_login_LoginClient_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
		{
			LoginClient loginClient = Java.Lang.Object.GetObject<LoginClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Request request = Java.Lang.Object.GetObject<Request>(native_request, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(loginClient.GetHandlersToTry(request));
		}

		[Register("getHandlersToTry", "(Lcom/facebook/login/LoginClient$Request;)[Lcom/facebook/login/LoginMethodHandler;", "GetGetHandlersToTry_Lcom_facebook_login_LoginClient_Request_Handler")]
		protected unsafe virtual LoginMethodHandler[] GetHandlersToTry(Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return (LoginMethodHandler[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getHandlersToTry.(Lcom/facebook/login/LoginClient$Request;)[Lcom/facebook/login/LoginMethodHandler;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(LoginMethodHandler));
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}

		[Register("notifyBackgroundProcessingStart", "()V", "")]
		public unsafe void NotifyBackgroundProcessingStart()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyBackgroundProcessingStart.()V", this, null);
		}

		[Register("notifyBackgroundProcessingStop", "()V", "")]
		public unsafe void NotifyBackgroundProcessingStop()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyBackgroundProcessingStop.()V", this, null);
		}

		[Register("onActivityResult", "(IILandroid/content/Intent;)Z", "")]
		public unsafe bool OnActivityResult(int requestCode, int resultCode, Intent data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(requestCode);
				ptr[1] = new JniArgumentValue(resultCode);
				ptr[2] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("onActivityResult.(IILandroid/content/Intent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}

		[Register("setCurrentHandlerIndex", "(I)V", "")]
		protected unsafe void SetCurrentHandlerIndex(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCurrentHandlerIndex.(I)V", this, ptr);
		}

		[Register("setHandlersToTry", "([Lcom/facebook/login/LoginMethodHandler;)V", "")]
		public unsafe void SetHandlersToTry(LoginMethodHandler[] value)
		{
			IntPtr intPtr = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setHandlersToTry.([Lcom/facebook/login/LoginMethodHandler;)V", this, ptr);
			}
			finally
			{
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr, value);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(value);
			}
		}

		[Register("startOrContinueAuth", "(Lcom/facebook/login/LoginClient$Request;)V", "")]
		public unsafe void StartOrContinueAuth(Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("startOrContinueAuth.(Lcom/facebook/login/LoginClient$Request;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}

		[Register("tryCurrentHandler", "()Z", "")]
		public unsafe bool TryCurrentHandler()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("tryCurrentHandler.()Z", this, null);
		}

		[Register("tryNextHandler", "()V", "")]
		public unsafe void TryNextHandler()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("tryNextHandler.()V", this, null);
		}

		[Register("validateSameFbidAndFinish", "(Lcom/facebook/login/LoginClient$Result;)V", "")]
		public unsafe void ValidateSameFbidAndFinish(Result pendingResult)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(pendingResult?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("validateSameFbidAndFinish.(Lcom/facebook/login/LoginClient$Result;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(pendingResult);
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
			LoginClient loginClient = Java.Lang.Object.GetObject<LoginClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			loginClient.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe virtual void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
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

		private IBackgroundProcessingListenerImplementor __CreateIBackgroundProcessingListenerImplementor()
		{
			return new IBackgroundProcessingListenerImplementor(this);
		}

		private IOnCompletedListenerImplementor __CreateIOnCompletedListenerImplementor()
		{
			return new IOnCompletedListenerImplementor(this);
		}
	}
	[Register("com/facebook/login/LoginConfiguration", DoNotGenerateAcw = true)]
	public sealed class LoginConfiguration : Java.Lang.Object
	{
		[Register("com/facebook/login/LoginConfiguration$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginConfiguration$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		[Register("OPENID")]
		public const string Openid = "openid";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginConfiguration", typeof(LoginConfiguration));

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

		public unsafe string CodeVerifier
		{
			[Register("getCodeVerifier", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCodeVerifier.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Nonce
		{
			[Register("getNonce", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNonce.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ICollection<string> Permissions
		{
			[Register("getPermissions", "()Ljava/util/Set;", "")]
			get
			{
				return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPermissions.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal LoginConfiguration(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/Collection;)V", "")]
		public unsafe LoginConfiguration(ICollection<string> permissions)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/Collection;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(permissions);
			}
		}

		[Register(".ctor", "(Ljava/util/Collection;Ljava/lang/String;)V", "")]
		public unsafe LoginConfiguration(ICollection<string> permissions, string nonce)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			IntPtr intPtr2 = JNIEnv.NewString(nonce);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/Collection;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/Collection;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(permissions);
			}
		}

		[Register(".ctor", "(Ljava/util/Collection;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe LoginConfiguration(ICollection<string> permissions, string nonce, string codeVerifier)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			IntPtr intPtr2 = JNIEnv.NewString(nonce);
			IntPtr intPtr3 = JNIEnv.NewString(codeVerifier);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/Collection;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/Collection;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				GC.KeepAlive(permissions);
			}
		}
	}
	[Register("com/facebook/login/LoginFragment", DoNotGenerateAcw = true)]
	public class LoginFragment : AndroidX.Fragment.App.Fragment
	{
		[Register("com/facebook/login/LoginFragment$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginFragment$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		[Register("EXTRA_REQUEST")]
		public const string ExtraRequest = "request";

		[Register("REQUEST_KEY")]
		public const string RequestKey = "com.facebook.LoginFragment:Request";

		[Register("RESULT_KEY")]
		public const string ResultKey = "com.facebook.LoginFragment:Result";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginFragment", typeof(LoginFragment));

		private static Delegate cb_getLayoutResId;

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

		protected unsafe virtual int LayoutResId
		{
			[Register("getLayoutResId", "()I", "GetGetLayoutResIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLayoutResId.()I", this, null);
			}
		}

		public unsafe LoginClient LoginClient
		{
			[Register("getLoginClient", "()Lcom/facebook/login/LoginClient;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LoginClient>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLoginClient.()Lcom/facebook/login/LoginClient;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LoginFragment(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LoginFragment()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetLayoutResIdHandler()
		{
			if ((object)cb_getLayoutResId == null)
			{
				cb_getLayoutResId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLayoutResId));
			}
			return cb_getLayoutResId;
		}

		private static int n_GetLayoutResId(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoginFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutResId;
		}
	}
	[Register("com/facebook/login/LoginManager", DoNotGenerateAcw = true)]
	public class LoginManager : Java.Lang.Object
	{
		[Register("com/facebook/login/LoginManager$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginManager$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("computeLoginResult", "(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;)Lcom/facebook/login/LoginResult;", "")]
			public unsafe LoginResult ComputeLoginResult(LoginClient.Request request, AccessToken newToken, AuthenticationToken newIdToken)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(newToken?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(newIdToken?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<LoginResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("computeLoginResult.(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;)Lcom/facebook/login/LoginResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(request);
					GC.KeepAlive(newToken);
					GC.KeepAlive(newIdToken);
				}
			}

			[Register("getExtraDataFromIntent", "(Landroid/content/Intent;)Ljava/util/Map;", "")]
			public unsafe IDictionary<string, string> GetExtraDataFromIntent(Intent intent)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
					return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getExtraDataFromIntent.(Landroid/content/Intent;)Ljava/util/Map;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(intent);
				}
			}

			[Register("isPublishPermission", "(Ljava/lang/String;)Z", "")]
			public unsafe bool IsPublishPermission(string permission)
			{
				IntPtr intPtr = JNIEnv.NewString(permission);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isPublishPermission.(Ljava/lang/String;)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginManager", typeof(LoginManager));

		private static Delegate cb_createLoginRequest_Ljava_util_Collection_;

		private static Delegate cb_createLoginRequestWithConfig_Lcom_facebook_login_LoginConfiguration_;

		private static Delegate cb_createReauthorizeRequest;

		private static Delegate cb_getFacebookActivityIntent_Lcom_facebook_login_LoginClient_Request_;

		private static Delegate cb_logOut;

		private static Delegate cb_onActivityResult_ILandroid_content_Intent_Lcom_facebook_FacebookCallback_;

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

		public unsafe string AuthType
		{
			[Register("getAuthType", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAuthType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe DefaultAudience DefaultAudience
		{
			[Register("getDefaultAudience", "()Lcom/facebook/login/DefaultAudience;", "")]
			get
			{
				return Java.Lang.Object.GetObject<DefaultAudience>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDefaultAudience.()Lcom/facebook/login/DefaultAudience;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static LoginManager Instance
		{
			[Register("getInstance", "()Lcom/facebook/login/LoginManager;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LoginManager>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lcom/facebook/login/LoginManager;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsFamilyLogin
		{
			[Register("isFamilyLogin", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isFamilyLogin.()Z", this, null);
			}
		}

		public unsafe LoginBehavior LoginBehavior
		{
			[Register("getLoginBehavior", "()Lcom/facebook/login/LoginBehavior;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LoginBehavior>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLoginBehavior.()Lcom/facebook/login/LoginBehavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe LoginTargetApp LoginTargetApp
		{
			[Register("getLoginTargetApp", "()Lcom/facebook/login/LoginTargetApp;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LoginTargetApp>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLoginTargetApp.()Lcom/facebook/login/LoginTargetApp;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool ShouldSkipAccountDeduplication
		{
			[Register("getShouldSkipAccountDeduplication", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getShouldSkipAccountDeduplication.()Z", this, null);
			}
		}

		protected LoginManager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("computeLoginResult", "(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;)Lcom/facebook/login/LoginResult;", "")]
		public unsafe static LoginResult ComputeLoginResult(LoginClient.Request request, AccessToken newToken, AuthenticationToken newIdToken)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newToken?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(newIdToken?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LoginResult>(_members.StaticMethods.InvokeObjectMethod("computeLoginResult.(Lcom/facebook/login/LoginClient$Request;Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;)Lcom/facebook/login/LoginResult;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(request);
				GC.KeepAlive(newToken);
				GC.KeepAlive(newIdToken);
			}
		}

		private static Delegate GetCreateLoginRequest_Ljava_util_Collection_Handler()
		{
			if ((object)cb_createLoginRequest_Ljava_util_Collection_ == null)
			{
				cb_createLoginRequest_Ljava_util_Collection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateLoginRequest_Ljava_util_Collection_));
			}
			return cb_createLoginRequest_Ljava_util_Collection_;
		}

		private static IntPtr n_CreateLoginRequest_Ljava_util_Collection_(IntPtr jnienv, IntPtr native__this, IntPtr native_permissions)
		{
			LoginManager loginManager = Java.Lang.Object.GetObject<LoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICollection<string> permissions = JavaCollection<string>.FromJniHandle(native_permissions, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(loginManager.CreateLoginRequest(permissions));
		}

		[Register("createLoginRequest", "(Ljava/util/Collection;)Lcom/facebook/login/LoginClient$Request;", "GetCreateLoginRequest_Ljava_util_Collection_Handler")]
		protected unsafe virtual LoginClient.Request CreateLoginRequest(ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LoginClient.Request>(_members.InstanceMethods.InvokeVirtualObjectMethod("createLoginRequest.(Ljava/util/Collection;)Lcom/facebook/login/LoginClient$Request;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(permissions);
			}
		}

		private static Delegate GetCreateLoginRequestWithConfig_Lcom_facebook_login_LoginConfiguration_Handler()
		{
			if ((object)cb_createLoginRequestWithConfig_Lcom_facebook_login_LoginConfiguration_ == null)
			{
				cb_createLoginRequestWithConfig_Lcom_facebook_login_LoginConfiguration_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateLoginRequestWithConfig_Lcom_facebook_login_LoginConfiguration_));
			}
			return cb_createLoginRequestWithConfig_Lcom_facebook_login_LoginConfiguration_;
		}

		private static IntPtr n_CreateLoginRequestWithConfig_Lcom_facebook_login_LoginConfiguration_(IntPtr jnienv, IntPtr native__this, IntPtr native_loginConfig)
		{
			LoginManager loginManager = Java.Lang.Object.GetObject<LoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginConfiguration loginConfig = Java.Lang.Object.GetObject<LoginConfiguration>(native_loginConfig, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(loginManager.CreateLoginRequestWithConfig(loginConfig));
		}

		[Register("createLoginRequestWithConfig", "(Lcom/facebook/login/LoginConfiguration;)Lcom/facebook/login/LoginClient$Request;", "GetCreateLoginRequestWithConfig_Lcom_facebook_login_LoginConfiguration_Handler")]
		protected unsafe virtual LoginClient.Request CreateLoginRequestWithConfig(LoginConfiguration loginConfig)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(loginConfig?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LoginClient.Request>(_members.InstanceMethods.InvokeVirtualObjectMethod("createLoginRequestWithConfig.(Lcom/facebook/login/LoginConfiguration;)Lcom/facebook/login/LoginClient$Request;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(loginConfig);
			}
		}

		private static Delegate GetCreateReauthorizeRequestHandler()
		{
			if ((object)cb_createReauthorizeRequest == null)
			{
				cb_createReauthorizeRequest = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateReauthorizeRequest));
			}
			return cb_createReauthorizeRequest;
		}

		private static IntPtr n_CreateReauthorizeRequest(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateReauthorizeRequest());
		}

		[Register("createReauthorizeRequest", "()Lcom/facebook/login/LoginClient$Request;", "GetCreateReauthorizeRequestHandler")]
		protected unsafe virtual LoginClient.Request CreateReauthorizeRequest()
		{
			return Java.Lang.Object.GetObject<LoginClient.Request>(_members.InstanceMethods.InvokeVirtualObjectMethod("createReauthorizeRequest.()Lcom/facebook/login/LoginClient$Request;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getExtraDataFromIntent", "(Landroid/content/Intent;)Ljava/util/Map;", "")]
		public unsafe static IDictionary<string, string> GetExtraDataFromIntent(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return JavaDictionary<string, string>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("getExtraDataFromIntent.(Landroid/content/Intent;)Ljava/util/Map;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}

		private static Delegate GetGetFacebookActivityIntent_Lcom_facebook_login_LoginClient_Request_Handler()
		{
			if ((object)cb_getFacebookActivityIntent_Lcom_facebook_login_LoginClient_Request_ == null)
			{
				cb_getFacebookActivityIntent_Lcom_facebook_login_LoginClient_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetFacebookActivityIntent_Lcom_facebook_login_LoginClient_Request_));
			}
			return cb_getFacebookActivityIntent_Lcom_facebook_login_LoginClient_Request_;
		}

		private static IntPtr n_GetFacebookActivityIntent_Lcom_facebook_login_LoginClient_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
		{
			LoginManager loginManager = Java.Lang.Object.GetObject<LoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(loginManager.GetFacebookActivityIntent(request));
		}

		[Register("getFacebookActivityIntent", "(Lcom/facebook/login/LoginClient$Request;)Landroid/content/Intent;", "GetGetFacebookActivityIntent_Lcom_facebook_login_LoginClient_Request_Handler")]
		protected unsafe virtual Intent GetFacebookActivityIntent(LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFacebookActivityIntent.(Lcom/facebook/login/LoginClient$Request;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}

		[Register("isPublishPermission", "(Ljava/lang/String;)Z", "")]
		public unsafe static bool IsPublishPermission(string permission)
		{
			IntPtr intPtr = JNIEnv.NewString(permission);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeBooleanMethod("isPublishPermission.(Ljava/lang/String;)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("logIn", "(Landroid/app/Activity;Lcom/facebook/login/LoginConfiguration;)V", "")]
		public unsafe void LogIn(Activity activity, LoginConfiguration loginConfig)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(loginConfig?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Landroid/app/Activity;Lcom/facebook/login/LoginConfiguration;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(loginConfig);
			}
		}

		[Register("logIn", "(Landroid/app/Activity;Ljava/util/Collection;)V", "")]
		public unsafe void LogIn(Activity activity, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Landroid/app/Activity;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(activity);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logIn", "(Landroid/app/Activity;Ljava/util/Collection;Ljava/lang/String;)V", "")]
		public unsafe void LogIn(Activity activity, ICollection<string> permissions, string loggerID)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			IntPtr intPtr2 = JNIEnv.NewString(loggerID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Landroid/app/Activity;Ljava/util/Collection;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(activity);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logIn", "(Landroid/app/Fragment;Ljava/util/Collection;)V", "")]
		public unsafe void LogIn(Android.App.Fragment fragment, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Landroid/app/Fragment;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(fragment);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logIn", "(Landroid/app/Fragment;Ljava/util/Collection;Ljava/lang/String;)V", "")]
		public unsafe void LogIn(Android.App.Fragment fragment, ICollection<string> permissions, string loggerID)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			IntPtr intPtr2 = JNIEnv.NewString(loggerID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Landroid/app/Fragment;Ljava/util/Collection;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(fragment);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logIn", "(Landroidx/activity/result/ActivityResultRegistryOwner;Lcom/facebook/CallbackManager;Ljava/util/Collection;)V", "")]
		public unsafe void LogIn(IActivityResultRegistryOwner activityResultRegistryOwner, ICallbackManager callbackManager, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((activityResultRegistryOwner == null) ? IntPtr.Zero : ((Java.Lang.Object)activityResultRegistryOwner).Handle);
				ptr[1] = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Landroidx/activity/result/ActivityResultRegistryOwner;Lcom/facebook/CallbackManager;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(activityResultRegistryOwner);
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logIn", "(Landroidx/activity/result/ActivityResultRegistryOwner;Lcom/facebook/CallbackManager;Ljava/util/Collection;Ljava/lang/String;)V", "")]
		public unsafe void LogIn(IActivityResultRegistryOwner activityResultRegistryOwner, ICallbackManager callbackManager, ICollection<string> permissions, string loggerID)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			IntPtr intPtr2 = JNIEnv.NewString(loggerID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((activityResultRegistryOwner == null) ? IntPtr.Zero : ((Java.Lang.Object)activityResultRegistryOwner).Handle);
				ptr[1] = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Landroidx/activity/result/ActivityResultRegistryOwner;Lcom/facebook/CallbackManager;Ljava/util/Collection;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(activityResultRegistryOwner);
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logIn", "(Landroidx/fragment/app/Fragment;Ljava/util/Collection;)V", "")]
		public unsafe void LogIn(AndroidX.Fragment.App.Fragment fragment, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Landroidx/fragment/app/Fragment;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(fragment);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logIn", "(Landroidx/fragment/app/Fragment;Ljava/util/Collection;Ljava/lang/String;)V", "")]
		public unsafe void LogIn(AndroidX.Fragment.App.Fragment fragment, ICollection<string> permissions, string loggerID)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			IntPtr intPtr2 = JNIEnv.NewString(loggerID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Landroidx/fragment/app/Fragment;Ljava/util/Collection;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(fragment);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logIn", "(Lcom/facebook/internal/FragmentWrapper;Lcom/facebook/login/LoginConfiguration;)V", "")]
		public unsafe void LogIn(FragmentWrapper fragment, LoginConfiguration loginConfig)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(loginConfig?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Lcom/facebook/internal/FragmentWrapper;Lcom/facebook/login/LoginConfiguration;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(loginConfig);
			}
		}

		[Register("logIn", "(Lcom/facebook/internal/FragmentWrapper;Ljava/util/Collection;)V", "")]
		public unsafe void LogIn(FragmentWrapper fragment, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Lcom/facebook/internal/FragmentWrapper;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(fragment);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logIn", "(Lcom/facebook/internal/FragmentWrapper;Ljava/util/Collection;Ljava/lang/String;)V", "")]
		public unsafe void LogIn(FragmentWrapper fragment, ICollection<string> permissions, string loggerID)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			IntPtr intPtr2 = JNIEnv.NewString(loggerID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logIn.(Lcom/facebook/internal/FragmentWrapper;Ljava/util/Collection;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(fragment);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logInWithConfiguration", "(Landroidx/fragment/app/Fragment;Lcom/facebook/login/LoginConfiguration;)V", "")]
		public unsafe void LogInWithConfiguration(AndroidX.Fragment.App.Fragment fragment, LoginConfiguration loginConfig)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(loginConfig?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithConfiguration.(Landroidx/fragment/app/Fragment;Lcom/facebook/login/LoginConfiguration;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(loginConfig);
			}
		}

		[Register("logInWithPublishPermissions", "(Landroid/app/Activity;Ljava/util/Collection;)V", "")]
		public unsafe void LogInWithPublishPermissions(Activity activity, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithPublishPermissions.(Landroid/app/Activity;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(activity);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logInWithPublishPermissions", "(Landroid/app/Fragment;Ljava/util/Collection;)V", "")]
		public unsafe void LogInWithPublishPermissions(Android.App.Fragment fragment, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithPublishPermissions.(Landroid/app/Fragment;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(fragment);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logInWithPublishPermissions", "(Landroidx/activity/result/ActivityResultRegistryOwner;Lcom/facebook/CallbackManager;Ljava/util/Collection;)V", "")]
		public unsafe void LogInWithPublishPermissions(IActivityResultRegistryOwner activityResultRegistryOwner, ICallbackManager callbackManager, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((activityResultRegistryOwner == null) ? IntPtr.Zero : ((Java.Lang.Object)activityResultRegistryOwner).Handle);
				ptr[1] = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithPublishPermissions.(Landroidx/activity/result/ActivityResultRegistryOwner;Lcom/facebook/CallbackManager;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(activityResultRegistryOwner);
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logInWithPublishPermissions", "(Landroidx/fragment/app/Fragment;Lcom/facebook/CallbackManager;Ljava/util/Collection;)V", "")]
		public unsafe void LogInWithPublishPermissions(AndroidX.Fragment.App.Fragment fragment, ICallbackManager callbackManager, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithPublishPermissions.(Landroidx/fragment/app/Fragment;Lcom/facebook/CallbackManager;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(fragment);
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(permissions);
			}
		}

		[Obsolete("deprecated")]
		[Register("logInWithPublishPermissions", "(Landroidx/fragment/app/Fragment;Ljava/util/Collection;)V", "")]
		public unsafe void LogInWithPublishPermissions(AndroidX.Fragment.App.Fragment fragment, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithPublishPermissions.(Landroidx/fragment/app/Fragment;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(fragment);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logInWithReadPermissions", "(Landroid/app/Activity;Ljava/util/Collection;)V", "")]
		public unsafe void LogInWithReadPermissions(Activity activity, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithReadPermissions.(Landroid/app/Activity;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(activity);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logInWithReadPermissions", "(Landroid/app/Fragment;Ljava/util/Collection;)V", "")]
		public unsafe void LogInWithReadPermissions(Android.App.Fragment fragment, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithReadPermissions.(Landroid/app/Fragment;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(fragment);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logInWithReadPermissions", "(Landroidx/activity/result/ActivityResultRegistryOwner;Lcom/facebook/CallbackManager;Ljava/util/Collection;)V", "")]
		public unsafe void LogInWithReadPermissions(IActivityResultRegistryOwner activityResultRegistryOwner, ICallbackManager callbackManager, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((activityResultRegistryOwner == null) ? IntPtr.Zero : ((Java.Lang.Object)activityResultRegistryOwner).Handle);
				ptr[1] = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithReadPermissions.(Landroidx/activity/result/ActivityResultRegistryOwner;Lcom/facebook/CallbackManager;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(activityResultRegistryOwner);
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(permissions);
			}
		}

		[Register("logInWithReadPermissions", "(Landroidx/fragment/app/Fragment;Lcom/facebook/CallbackManager;Ljava/util/Collection;)V", "")]
		public unsafe void LogInWithReadPermissions(AndroidX.Fragment.App.Fragment fragment, ICallbackManager callbackManager, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithReadPermissions.(Landroidx/fragment/app/Fragment;Lcom/facebook/CallbackManager;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(fragment);
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(permissions);
			}
		}

		[Obsolete("deprecated")]
		[Register("logInWithReadPermissions", "(Landroidx/fragment/app/Fragment;Ljava/util/Collection;)V", "")]
		public unsafe void LogInWithReadPermissions(AndroidX.Fragment.App.Fragment fragment, ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logInWithReadPermissions.(Landroidx/fragment/app/Fragment;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(fragment);
				GC.KeepAlive(permissions);
			}
		}

		private static Delegate GetLogOutHandler()
		{
			if ((object)cb_logOut == null)
			{
				cb_logOut = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_LogOut));
			}
			return cb_logOut;
		}

		private static void n_LogOut(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LogOut();
		}

		[Register("logOut", "()V", "GetLogOutHandler")]
		public unsafe virtual void LogOut()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("logOut.()V", this, null);
		}

		[Register("loginWithConfiguration", "(Landroid/app/Activity;Lcom/facebook/login/LoginConfiguration;)V", "")]
		public unsafe void LoginWithConfiguration(Activity activity, LoginConfiguration loginConfig)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(loginConfig?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("loginWithConfiguration.(Landroid/app/Activity;Lcom/facebook/login/LoginConfiguration;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(loginConfig);
			}
		}

		[Register("onActivityResult", "(ILandroid/content/Intent;)Z", "")]
		public unsafe bool OnActivityResult(int resultCode, Intent data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(resultCode);
				ptr[1] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("onActivityResult.(ILandroid/content/Intent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetOnActivityResult_ILandroid_content_Intent_Lcom_facebook_FacebookCallback_Handler()
		{
			if ((object)cb_onActivityResult_ILandroid_content_Intent_Lcom_facebook_FacebookCallback_ == null)
			{
				cb_onActivityResult_ILandroid_content_Intent_Lcom_facebook_FacebookCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_Z(n_OnActivityResult_ILandroid_content_Intent_Lcom_facebook_FacebookCallback_));
			}
			return cb_onActivityResult_ILandroid_content_Intent_Lcom_facebook_FacebookCallback_;
		}

		private static bool n_OnActivityResult_ILandroid_content_Intent_Lcom_facebook_FacebookCallback_(IntPtr jnienv, IntPtr native__this, int resultCode, IntPtr native_data, IntPtr native__callback)
		{
			LoginManager loginManager = Java.Lang.Object.GetObject<LoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent data = Java.Lang.Object.GetObject<Intent>(native_data, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return loginManager.OnActivityResult(resultCode, data, callback);
		}

		[Register("onActivityResult", "(ILandroid/content/Intent;Lcom/facebook/FacebookCallback;)Z", "GetOnActivityResult_ILandroid_content_Intent_Lcom_facebook_FacebookCallback_Handler")]
		public unsafe virtual bool OnActivityResult(int resultCode, Intent data, IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(resultCode);
				ptr[1] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onActivityResult.(ILandroid/content/Intent;Lcom/facebook/FacebookCallback;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(data);
				GC.KeepAlive(callback);
			}
		}

		[Register("reauthorizeDataAccess", "(Landroid/app/Activity;)V", "")]
		public unsafe void ReauthorizeDataAccess(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("reauthorizeDataAccess.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[Register("reauthorizeDataAccess", "(Landroidx/fragment/app/Fragment;)V", "")]
		public unsafe void ReauthorizeDataAccess(AndroidX.Fragment.App.Fragment fragment)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("reauthorizeDataAccess.(Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register("registerCallback", "(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V", "")]
		public unsafe void RegisterCallback(ICallbackManager callbackManager, IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("registerCallback.(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(callback);
			}
		}

		[Register("resolveError", "(Landroid/app/Activity;Lcom/facebook/GraphResponse;)V", "")]
		public unsafe void ResolveError(Activity activity, GraphResponse response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("resolveError.(Landroid/app/Activity;Lcom/facebook/GraphResponse;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(response);
			}
		}

		[Register("resolveError", "(Landroid/app/Fragment;Lcom/facebook/GraphResponse;)V", "")]
		public unsafe void ResolveError(Android.App.Fragment fragment, GraphResponse response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("resolveError.(Landroid/app/Fragment;Lcom/facebook/GraphResponse;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(response);
			}
		}

		[Register("resolveError", "(Landroidx/activity/result/ActivityResultRegistryOwner;Lcom/facebook/CallbackManager;Lcom/facebook/GraphResponse;)V", "")]
		public unsafe void ResolveError(IActivityResultRegistryOwner activityResultRegistryOwner, ICallbackManager callbackManager, GraphResponse response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((activityResultRegistryOwner == null) ? IntPtr.Zero : ((Java.Lang.Object)activityResultRegistryOwner).Handle);
				ptr[1] = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[2] = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("resolveError.(Landroidx/activity/result/ActivityResultRegistryOwner;Lcom/facebook/CallbackManager;Lcom/facebook/GraphResponse;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activityResultRegistryOwner);
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(response);
			}
		}

		[Register("resolveError", "(Landroidx/fragment/app/Fragment;Lcom/facebook/CallbackManager;Lcom/facebook/GraphResponse;)V", "")]
		public unsafe void ResolveError(AndroidX.Fragment.App.Fragment fragment, ICallbackManager callbackManager, GraphResponse response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[2] = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("resolveError.(Landroidx/fragment/app/Fragment;Lcom/facebook/CallbackManager;Lcom/facebook/GraphResponse;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(response);
			}
		}

		[Obsolete("deprecated")]
		[Register("resolveError", "(Landroidx/fragment/app/Fragment;Lcom/facebook/GraphResponse;)V", "")]
		public unsafe void ResolveError(AndroidX.Fragment.App.Fragment fragment, GraphResponse response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("resolveError.(Landroidx/fragment/app/Fragment;Lcom/facebook/GraphResponse;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(response);
			}
		}

		[Register("retrieveLoginStatus", "(Landroid/content/Context;Lcom/facebook/LoginStatusCallback;)V", "")]
		public unsafe void RetrieveLoginStatus(Context context, ILoginStatusCallback responseCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((responseCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)responseCallback).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("retrieveLoginStatus.(Landroid/content/Context;Lcom/facebook/LoginStatusCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(responseCallback);
			}
		}

		[Register("retrieveLoginStatus", "(Landroid/content/Context;JLcom/facebook/LoginStatusCallback;)V", "")]
		public unsafe void RetrieveLoginStatus(Context context, long toastDurationMs, ILoginStatusCallback responseCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(toastDurationMs);
				ptr[2] = new JniArgumentValue((responseCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)responseCallback).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("retrieveLoginStatus.(Landroid/content/Context;JLcom/facebook/LoginStatusCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(responseCallback);
			}
		}

		[Register("setAuthType", "(Ljava/lang/String;)Lcom/facebook/login/LoginManager;", "")]
		public unsafe LoginManager SetAuthType(string authType)
		{
			IntPtr intPtr = JNIEnv.NewString(authType);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LoginManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setAuthType.(Ljava/lang/String;)Lcom/facebook/login/LoginManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setDefaultAudience", "(Lcom/facebook/login/DefaultAudience;)Lcom/facebook/login/LoginManager;", "")]
		public unsafe LoginManager SetDefaultAudience(DefaultAudience defaultAudience)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(defaultAudience?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LoginManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setDefaultAudience.(Lcom/facebook/login/DefaultAudience;)Lcom/facebook/login/LoginManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(defaultAudience);
			}
		}

		[Register("setFamilyLogin", "(Z)Lcom/facebook/login/LoginManager;", "")]
		public unsafe LoginManager SetFamilyLogin(bool isFamilyLogin)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isFamilyLogin);
			return Java.Lang.Object.GetObject<LoginManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setFamilyLogin.(Z)Lcom/facebook/login/LoginManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setLoginBehavior", "(Lcom/facebook/login/LoginBehavior;)Lcom/facebook/login/LoginManager;", "")]
		public unsafe LoginManager SetLoginBehavior(LoginBehavior loginBehavior)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(loginBehavior?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LoginManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setLoginBehavior.(Lcom/facebook/login/LoginBehavior;)Lcom/facebook/login/LoginManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(loginBehavior);
			}
		}

		[Register("setLoginTargetApp", "(Lcom/facebook/login/LoginTargetApp;)Lcom/facebook/login/LoginManager;", "")]
		public unsafe LoginManager SetLoginTargetApp(LoginTargetApp targetApp)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(targetApp?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LoginManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setLoginTargetApp.(Lcom/facebook/login/LoginTargetApp;)Lcom/facebook/login/LoginManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(targetApp);
			}
		}

		[Register("setMessengerPageId", "(Ljava/lang/String;)Lcom/facebook/login/LoginManager;", "")]
		public unsafe LoginManager SetMessengerPageId(string messengerPageId)
		{
			IntPtr intPtr = JNIEnv.NewString(messengerPageId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LoginManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setMessengerPageId.(Ljava/lang/String;)Lcom/facebook/login/LoginManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setResetMessengerState", "(Z)Lcom/facebook/login/LoginManager;", "")]
		public unsafe LoginManager SetResetMessengerState(bool resetMessengerState)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resetMessengerState);
			return Java.Lang.Object.GetObject<LoginManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setResetMessengerState.(Z)Lcom/facebook/login/LoginManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setShouldSkipAccountDeduplication", "(Z)Lcom/facebook/login/LoginManager;", "")]
		public unsafe LoginManager SetShouldSkipAccountDeduplication(bool shouldSkipAccountDeduplication)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(shouldSkipAccountDeduplication);
			return Java.Lang.Object.GetObject<LoginManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setShouldSkipAccountDeduplication.(Z)Lcom/facebook/login/LoginManager;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("unregisterCallback", "(Lcom/facebook/CallbackManager;)V", "")]
		public unsafe void UnregisterCallback(ICallbackManager callbackManager)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("unregisterCallback.(Lcom/facebook/CallbackManager;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
			}
		}
	}
	[Register("com/facebook/login/LoginMethodHandler", DoNotGenerateAcw = true)]
	public abstract class LoginMethodHandler : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/login/LoginMethodHandler$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginMethodHandler$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("createAccessTokenFromNativeLogin", "(Landroid/os/Bundle;Lcom/facebook/AccessTokenSource;Ljava/lang/String;)Lcom/facebook/AccessToken;", "")]
			public unsafe AccessToken CreateAccessTokenFromNativeLogin(Bundle bundle, AccessTokenSource source, string applicationId)
			{
				IntPtr intPtr = JNIEnv.NewString(applicationId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<AccessToken>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createAccessTokenFromNativeLogin.(Landroid/os/Bundle;Lcom/facebook/AccessTokenSource;Ljava/lang/String;)Lcom/facebook/AccessToken;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(bundle);
					GC.KeepAlive(source);
				}
			}

			[Register("createAccessTokenFromWebBundle", "(Ljava/util/Collection;Landroid/os/Bundle;Lcom/facebook/AccessTokenSource;Ljava/lang/String;)Lcom/facebook/AccessToken;", "")]
			public unsafe AccessToken CreateAccessTokenFromWebBundle(ICollection<string> requestedPermissions, Bundle bundle, AccessTokenSource source, string applicationId)
			{
				IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(requestedPermissions);
				IntPtr intPtr2 = JNIEnv.NewString(applicationId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<AccessToken>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createAccessTokenFromWebBundle.(Ljava/util/Collection;Landroid/os/Bundle;Lcom/facebook/AccessTokenSource;Ljava/lang/String;)Lcom/facebook/AccessToken;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(requestedPermissions);
					GC.KeepAlive(bundle);
					GC.KeepAlive(source);
				}
			}

			[Register("createAuthenticationTokenFromNativeLogin", "(Landroid/os/Bundle;Ljava/lang/String;)Lcom/facebook/AuthenticationToken;", "")]
			public unsafe AuthenticationToken CreateAuthenticationTokenFromNativeLogin(Bundle bundle, string expectedNonce)
			{
				IntPtr intPtr = JNIEnv.NewString(expectedNonce);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<AuthenticationToken>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createAuthenticationTokenFromNativeLogin.(Landroid/os/Bundle;Ljava/lang/String;)Lcom/facebook/AuthenticationToken;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(bundle);
				}
			}

			[Register("createAuthenticationTokenFromWebBundle", "(Landroid/os/Bundle;Ljava/lang/String;)Lcom/facebook/AuthenticationToken;", "")]
			public unsafe AuthenticationToken CreateAuthenticationTokenFromWebBundle(Bundle bundle, string expectedNonce)
			{
				IntPtr intPtr = JNIEnv.NewString(expectedNonce);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<AuthenticationToken>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createAuthenticationTokenFromWebBundle.(Landroid/os/Bundle;Ljava/lang/String;)Lcom/facebook/AuthenticationToken;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(bundle);
				}
			}

			[Register("getUserIDFromSignedRequest", "(Ljava/lang/String;)Ljava/lang/String;", "")]
			public unsafe string GetUserIDFromSignedRequest(string signedRequest)
			{
				IntPtr intPtr = JNIEnv.NewString(signedRequest);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getUserIDFromSignedRequest.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("NO_SIGNED_REQUEST_ERROR_MESSAGE")]
		public const string NoSignedRequestErrorMessage = "Authorization response does not contain the signed_request";

		[Register("NO_USER_ID_ERROR_MESSAGE")]
		public const string NoUserIdErrorMessage = "Failed to retrieve user_id from signed_request";

		[Register("USER_CANCELED_LOG_IN_ERROR_MESSAGE")]
		public const string UserCanceledLogInErrorMessage = "User canceled log in.";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginMethodHandler", typeof(LoginMethodHandler));

		private static Delegate cb_getNameForLogging;

		private static Delegate cb_getRedirectUrl;

		private static Delegate cb_addLoggingExtra_Ljava_lang_String_Ljava_lang_Object_;

		private static Delegate cb_cancel;

		private static Delegate cb_getClientState_Ljava_lang_String_;

		private static Delegate cb_logWebLoginCompleted_Ljava_lang_String_;

		private static Delegate cb_needsInternetPermission;

		private static Delegate cb_onActivityResult_IILandroid_content_Intent_;

		private static Delegate cb_processCodeExchange_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_;

		private static Delegate cb_putChallengeParam_Lorg_json_JSONObject_;

		private static Delegate cb_shouldKeepTrackOfMultipleIntents;

		private static Delegate cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_;

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

		private static Delegate cb_describeContents;

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

		public unsafe LoginClient LoginClient
		{
			[Register("getLoginClient", "()Lcom/facebook/login/LoginClient;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LoginClient>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLoginClient.()Lcom/facebook/login/LoginClient;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLoginClient", "(Lcom/facebook/login/LoginClient;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLoginClient.(Lcom/facebook/login/LoginClient;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe IDictionary<string, string> MethodLoggingExtras
		{
			[Register("getMethodLoggingExtras", "()Ljava/util/Map;", "")]
			get
			{
				return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getMethodLoggingExtras.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setMethodLoggingExtras", "(Ljava/util/Map;)V", "")]
			set
			{
				IntPtr intPtr = JavaDictionary<string, string>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMethodLoggingExtras.(Ljava/util/Map;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public abstract string NameForLogging
		{
			[Register("getNameForLogging", "()Ljava/lang/String;", "GetGetNameForLoggingHandler")]
			get;
		}

		protected unsafe virtual string RedirectUrl
		{
			[Register("getRedirectUrl", "()Ljava/lang/String;", "GetGetRedirectUrlHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getRedirectUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LoginMethodHandler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/os/Parcel;)V", "")]
		protected unsafe LoginMethodHandler(Parcel source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Parcel;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Parcel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Lcom/facebook/login/LoginClient;)V", "")]
		public unsafe LoginMethodHandler(LoginClient loginClient)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(loginClient?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/login/LoginClient;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/login/LoginClient;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(loginClient);
			}
		}

		private static Delegate GetGetNameForLoggingHandler()
		{
			if ((object)cb_getNameForLogging == null)
			{
				cb_getNameForLogging = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNameForLogging));
			}
			return cb_getNameForLogging;
		}

		private static IntPtr n_GetNameForLogging(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NameForLogging);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RedirectUrl);
		}

		private static Delegate GetAddLoggingExtra_Ljava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_addLoggingExtra_Ljava_lang_String_Ljava_lang_Object_ == null)
			{
				cb_addLoggingExtra_Ljava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_AddLoggingExtra_Ljava_lang_String_Ljava_lang_Object_));
			}
			return cb_addLoggingExtra_Ljava_lang_String_Ljava_lang_Object_;
		}

		private static void n_AddLoggingExtra_Ljava_lang_String_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
		{
			LoginMethodHandler loginMethodHandler = Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			loginMethodHandler.AddLoggingExtra(key, value);
		}

		[Register("addLoggingExtra", "(Ljava/lang/String;Ljava/lang/Object;)V", "GetAddLoggingExtra_Ljava_lang_String_Ljava_lang_Object_Handler")]
		protected unsafe virtual void AddLoggingExtra(string key, Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addLoggingExtra.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetCancelHandler()
		{
			if ((object)cb_cancel == null)
			{
				cb_cancel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Cancel));
			}
			return cb_cancel;
		}

		private static void n_Cancel(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		public unsafe virtual void Cancel()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("cancel.()V", this, null);
		}

		[Register("createAccessTokenFromNativeLogin", "(Landroid/os/Bundle;Lcom/facebook/AccessTokenSource;Ljava/lang/String;)Lcom/facebook/AccessToken;", "")]
		public unsafe static AccessToken CreateAccessTokenFromNativeLogin(Bundle bundle, AccessTokenSource source, string applicationId)
		{
			IntPtr intPtr = JNIEnv.NewString(applicationId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<AccessToken>(_members.StaticMethods.InvokeObjectMethod("createAccessTokenFromNativeLogin.(Landroid/os/Bundle;Lcom/facebook/AccessTokenSource;Ljava/lang/String;)Lcom/facebook/AccessToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(bundle);
				GC.KeepAlive(source);
			}
		}

		[Register("createAccessTokenFromWebBundle", "(Ljava/util/Collection;Landroid/os/Bundle;Lcom/facebook/AccessTokenSource;Ljava/lang/String;)Lcom/facebook/AccessToken;", "")]
		public unsafe static AccessToken CreateAccessTokenFromWebBundle(ICollection<string> requestedPermissions, Bundle bundle, AccessTokenSource source, string applicationId)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(requestedPermissions);
			IntPtr intPtr2 = JNIEnv.NewString(applicationId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<AccessToken>(_members.StaticMethods.InvokeObjectMethod("createAccessTokenFromWebBundle.(Ljava/util/Collection;Landroid/os/Bundle;Lcom/facebook/AccessTokenSource;Ljava/lang/String;)Lcom/facebook/AccessToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(requestedPermissions);
				GC.KeepAlive(bundle);
				GC.KeepAlive(source);
			}
		}

		[Register("createAuthenticationTokenFromNativeLogin", "(Landroid/os/Bundle;Ljava/lang/String;)Lcom/facebook/AuthenticationToken;", "")]
		public unsafe static AuthenticationToken CreateAuthenticationTokenFromNativeLogin(Bundle bundle, string expectedNonce)
		{
			IntPtr intPtr = JNIEnv.NewString(expectedNonce);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<AuthenticationToken>(_members.StaticMethods.InvokeObjectMethod("createAuthenticationTokenFromNativeLogin.(Landroid/os/Bundle;Ljava/lang/String;)Lcom/facebook/AuthenticationToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(bundle);
			}
		}

		[Register("createAuthenticationTokenFromWebBundle", "(Landroid/os/Bundle;Ljava/lang/String;)Lcom/facebook/AuthenticationToken;", "")]
		public unsafe static AuthenticationToken CreateAuthenticationTokenFromWebBundle(Bundle bundle, string expectedNonce)
		{
			IntPtr intPtr = JNIEnv.NewString(expectedNonce);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<AuthenticationToken>(_members.StaticMethods.InvokeObjectMethod("createAuthenticationTokenFromWebBundle.(Landroid/os/Bundle;Ljava/lang/String;)Lcom/facebook/AuthenticationToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(bundle);
			}
		}

		private static Delegate GetGetClientState_Ljava_lang_String_Handler()
		{
			if ((object)cb_getClientState_Ljava_lang_String_ == null)
			{
				cb_getClientState_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetClientState_Ljava_lang_String_));
			}
			return cb_getClientState_Ljava_lang_String_;
		}

		private static IntPtr n_GetClientState_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_authId)
		{
			LoginMethodHandler loginMethodHandler = Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string authId = JNIEnv.GetString(native_authId, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(loginMethodHandler.GetClientState(authId));
		}

		[Register("getClientState", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetClientState_Ljava_lang_String_Handler")]
		protected unsafe virtual string GetClientState(string authId)
		{
			IntPtr intPtr = JNIEnv.NewString(authId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getClientState.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getUserIDFromSignedRequest", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe static string GetUserIDFromSignedRequest(string signedRequest)
		{
			IntPtr intPtr = JNIEnv.NewString(signedRequest);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getUserIDFromSignedRequest.(Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetLogWebLoginCompleted_Ljava_lang_String_Handler()
		{
			if ((object)cb_logWebLoginCompleted_Ljava_lang_String_ == null)
			{
				cb_logWebLoginCompleted_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_LogWebLoginCompleted_Ljava_lang_String_));
			}
			return cb_logWebLoginCompleted_Ljava_lang_String_;
		}

		private static void n_LogWebLoginCompleted_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_e2e)
		{
			LoginMethodHandler loginMethodHandler = Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string e2e = JNIEnv.GetString(native_e2e, JniHandleOwnership.DoNotTransfer);
			loginMethodHandler.LogWebLoginCompleted(e2e);
		}

		[Register("logWebLoginCompleted", "(Ljava/lang/String;)V", "GetLogWebLoginCompleted_Ljava_lang_String_Handler")]
		protected unsafe virtual void LogWebLoginCompleted(string e2e)
		{
			IntPtr intPtr = JNIEnv.NewString(e2e);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("logWebLoginCompleted.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetNeedsInternetPermissionHandler()
		{
			if ((object)cb_needsInternetPermission == null)
			{
				cb_needsInternetPermission = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_NeedsInternetPermission));
			}
			return cb_needsInternetPermission;
		}

		private static bool n_NeedsInternetPermission(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NeedsInternetPermission();
		}

		[Register("needsInternetPermission", "()Z", "GetNeedsInternetPermissionHandler")]
		public unsafe virtual bool NeedsInternetPermission()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("needsInternetPermission.()Z", this, null);
		}

		private static Delegate GetOnActivityResult_IILandroid_content_Intent_Handler()
		{
			if ((object)cb_onActivityResult_IILandroid_content_Intent_ == null)
			{
				cb_onActivityResult_IILandroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIL_Z(n_OnActivityResult_IILandroid_content_Intent_));
			}
			return cb_onActivityResult_IILandroid_content_Intent_;
		}

		private static bool n_OnActivityResult_IILandroid_content_Intent_(IntPtr jnienv, IntPtr native__this, int requestCode, int resultCode, IntPtr native_data)
		{
			LoginMethodHandler loginMethodHandler = Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent data = Java.Lang.Object.GetObject<Intent>(native_data, JniHandleOwnership.DoNotTransfer);
			return loginMethodHandler.OnActivityResult(requestCode, resultCode, data);
		}

		[Register("onActivityResult", "(IILandroid/content/Intent;)Z", "GetOnActivityResult_IILandroid_content_Intent_Handler")]
		public unsafe virtual bool OnActivityResult(int requestCode, int resultCode, Intent data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(requestCode);
				ptr[1] = new JniArgumentValue(resultCode);
				ptr[2] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onActivityResult.(IILandroid/content/Intent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetProcessCodeExchange_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_processCodeExchange_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_ == null)
			{
				cb_processCodeExchange_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_ProcessCodeExchange_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_));
			}
			return cb_processCodeExchange_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_;
		}

		private static IntPtr n_ProcessCodeExchange_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_request, IntPtr native_values)
		{
			LoginMethodHandler loginMethodHandler = Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			Bundle values = Java.Lang.Object.GetObject<Bundle>(native_values, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(loginMethodHandler.ProcessCodeExchange(request, values));
		}

		[Register("processCodeExchange", "(Lcom/facebook/login/LoginClient$Request;Landroid/os/Bundle;)Landroid/os/Bundle;", "GetProcessCodeExchange_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Handler")]
		protected unsafe virtual Bundle ProcessCodeExchange(LoginClient.Request request, Bundle values)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(values?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("processCodeExchange.(Lcom/facebook/login/LoginClient$Request;Landroid/os/Bundle;)Landroid/os/Bundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(request);
				GC.KeepAlive(values);
			}
		}

		private static Delegate GetPutChallengeParam_Lorg_json_JSONObject_Handler()
		{
			if ((object)cb_putChallengeParam_Lorg_json_JSONObject_ == null)
			{
				cb_putChallengeParam_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PutChallengeParam_Lorg_json_JSONObject_));
			}
			return cb_putChallengeParam_Lorg_json_JSONObject_;
		}

		private static void n_PutChallengeParam_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_param)
		{
			LoginMethodHandler loginMethodHandler = Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JSONObject param = Java.Lang.Object.GetObject<JSONObject>(native_param, JniHandleOwnership.DoNotTransfer);
			loginMethodHandler.PutChallengeParam(param);
		}

		[Register("putChallengeParam", "(Lorg/json/JSONObject;)V", "GetPutChallengeParam_Lorg_json_JSONObject_Handler")]
		public unsafe virtual void PutChallengeParam(JSONObject param)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(param?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("putChallengeParam.(Lorg/json/JSONObject;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(param);
			}
		}

		private static Delegate GetShouldKeepTrackOfMultipleIntentsHandler()
		{
			if ((object)cb_shouldKeepTrackOfMultipleIntents == null)
			{
				cb_shouldKeepTrackOfMultipleIntents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_ShouldKeepTrackOfMultipleIntents));
			}
			return cb_shouldKeepTrackOfMultipleIntents;
		}

		private static bool n_ShouldKeepTrackOfMultipleIntents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldKeepTrackOfMultipleIntents();
		}

		[Register("shouldKeepTrackOfMultipleIntents", "()Z", "GetShouldKeepTrackOfMultipleIntentsHandler")]
		public unsafe virtual bool ShouldKeepTrackOfMultipleIntents()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldKeepTrackOfMultipleIntents.()Z", this, null);
		}

		private static Delegate GetTryAuthorize_Lcom_facebook_login_LoginClient_Request_Handler()
		{
			if ((object)cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_ == null)
			{
				cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_TryAuthorize_Lcom_facebook_login_LoginClient_Request_));
			}
			return cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_;
		}

		private static int n_TryAuthorize_Lcom_facebook_login_LoginClient_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
		{
			LoginMethodHandler loginMethodHandler = Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			return loginMethodHandler.TryAuthorize(request);
		}

		[Register("tryAuthorize", "(Lcom/facebook/login/LoginClient$Request;)I", "GetTryAuthorize_Lcom_facebook_login_LoginClient_Request_Handler")]
		public abstract int TryAuthorize(LoginClient.Request request);

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
			LoginMethodHandler loginMethodHandler = Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			loginMethodHandler.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe virtual void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
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

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public abstract int DescribeContents();
	}
	[Register("com/facebook/login/LoginMethodHandler", DoNotGenerateAcw = true)]
	internal class LoginMethodHandlerInvoker : LoginMethodHandler
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginMethodHandler", typeof(LoginMethodHandlerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string NameForLogging
		{
			[Register("getNameForLogging", "()Ljava/lang/String;", "GetGetNameForLoggingHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getNameForLogging.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public LoginMethodHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("tryAuthorize", "(Lcom/facebook/login/LoginClient$Request;)I", "GetTryAuthorize_Lcom_facebook_login_LoginClient_Request_Handler")]
		public unsafe override int TryAuthorize(LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("tryAuthorize.(Lcom/facebook/login/LoginClient$Request;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe override int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}
	}
	[Register("com/facebook/login/LoginResult", DoNotGenerateAcw = true)]
	public sealed class LoginResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/LoginResult", typeof(LoginResult));

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

		public unsafe AccessToken AccessToken
		{
			[Register("getAccessToken", "()Lcom/facebook/AccessToken;", "")]
			get
			{
				return Java.Lang.Object.GetObject<AccessToken>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAccessToken.()Lcom/facebook/AccessToken;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe AuthenticationToken AuthenticationToken
		{
			[Register("getAuthenticationToken", "()Lcom/facebook/AuthenticationToken;", "")]
			get
			{
				return Java.Lang.Object.GetObject<AuthenticationToken>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAuthenticationToken.()Lcom/facebook/AuthenticationToken;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ICollection<string> RecentlyDeniedPermissions
		{
			[Register("getRecentlyDeniedPermissions", "()Ljava/util/Set;", "")]
			get
			{
				return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getRecentlyDeniedPermissions.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ICollection<string> RecentlyGrantedPermissions
		{
			[Register("getRecentlyGrantedPermissions", "()Ljava/util/Set;", "")]
			get
			{
				return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getRecentlyGrantedPermissions.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal LoginResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;Ljava/util/Set;Ljava/util/Set;)V", "")]
		public unsafe LoginResult(AccessToken accessToken, AuthenticationToken authenticationToken, ICollection<string> recentlyGrantedPermissions, ICollection<string> recentlyDeniedPermissions)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(recentlyGrantedPermissions);
			IntPtr intPtr2 = JavaSet<string>.ToLocalJniHandle(recentlyDeniedPermissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(accessToken?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(authenticationToken?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;Ljava/util/Set;Ljava/util/Set;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;Ljava/util/Set;Ljava/util/Set;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(accessToken);
				GC.KeepAlive(authenticationToken);
				GC.KeepAlive(recentlyGrantedPermissions);
				GC.KeepAlive(recentlyDeniedPermissions);
			}
		}

		[Register(".ctor", "(Lcom/facebook/AccessToken;Ljava/util/Set;Ljava/util/Set;)V", "")]
		public unsafe LoginResult(AccessToken accessToken, ICollection<string> recentlyGrantedPermissions, ICollection<string> recentlyDeniedPermissions)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(recentlyGrantedPermissions);
			IntPtr intPtr2 = JavaSet<string>.ToLocalJniHandle(recentlyDeniedPermissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(accessToken?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/AccessToken;Ljava/util/Set;Ljava/util/Set;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/AccessToken;Ljava/util/Set;Ljava/util/Set;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(accessToken);
				GC.KeepAlive(recentlyGrantedPermissions);
				GC.KeepAlive(recentlyDeniedPermissions);
			}
		}

		[Register("component1", "()Lcom/facebook/AccessToken;", "")]
		public unsafe AccessToken Component1()
		{
			return Java.Lang.Object.GetObject<AccessToken>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Lcom/facebook/AccessToken;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Lcom/facebook/AuthenticationToken;", "")]
		public unsafe AuthenticationToken Component2()
		{
			return Java.Lang.Object.GetObject<AuthenticationToken>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Lcom/facebook/AuthenticationToken;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component3", "()Ljava/util/Set;", "")]
		public unsafe ICollection<string> Component3()
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component3.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component4", "()Ljava/util/Set;", "")]
		public unsafe ICollection<string> Component4()
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component4.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;Ljava/util/Set;Ljava/util/Set;)Lcom/facebook/login/LoginResult;", "")]
		public unsafe LoginResult Copy(AccessToken accessToken, AuthenticationToken authenticationToken, ICollection<string> recentlyGrantedPermissions, ICollection<string> recentlyDeniedPermissions)
		{
			IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(recentlyGrantedPermissions);
			IntPtr intPtr2 = JavaSet<string>.ToLocalJniHandle(recentlyDeniedPermissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(accessToken?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(authenticationToken?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<LoginResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Lcom/facebook/AccessToken;Lcom/facebook/AuthenticationToken;Ljava/util/Set;Ljava/util/Set;)Lcom/facebook/login/LoginResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(accessToken);
				GC.KeepAlive(authenticationToken);
				GC.KeepAlive(recentlyGrantedPermissions);
				GC.KeepAlive(recentlyDeniedPermissions);
			}
		}
	}
	[Register("com/facebook/login/NativeAppLoginMethodHandler", DoNotGenerateAcw = true)]
	public abstract class NativeAppLoginMethodHandler : LoginMethodHandler
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/NativeAppLoginMethodHandler", typeof(NativeAppLoginMethodHandler));

		private static Delegate cb_getTokenSource;

		private static Delegate cb_getError_Landroid_os_Bundle_;

		private static Delegate cb_getErrorMessage_Landroid_os_Bundle_;

		private static Delegate cb_handleResultCancel_Lcom_facebook_login_LoginClient_Request_Landroid_content_Intent_;

		private static Delegate cb_handleResultError_Lcom_facebook_login_LoginClient_Request_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_handleResultOk_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_;

		private static Delegate cb_tryIntent_Landroid_content_Intent_I;

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

		public unsafe virtual AccessTokenSource TokenSource
		{
			[Register("getTokenSource", "()Lcom/facebook/AccessTokenSource;", "GetGetTokenSourceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<AccessTokenSource>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTokenSource.()Lcom/facebook/AccessTokenSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected NativeAppLoginMethodHandler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetTokenSourceHandler()
		{
			if ((object)cb_getTokenSource == null)
			{
				cb_getTokenSource = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTokenSource));
			}
			return cb_getTokenSource;
		}

		private static IntPtr n_GetTokenSource(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NativeAppLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TokenSource);
		}

		private static Delegate GetGetError_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_getError_Landroid_os_Bundle_ == null)
			{
				cb_getError_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetError_Landroid_os_Bundle_));
			}
			return cb_getError_Landroid_os_Bundle_;
		}

		private static IntPtr n_GetError_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_extras)
		{
			NativeAppLoginMethodHandler nativeAppLoginMethodHandler = Java.Lang.Object.GetObject<NativeAppLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(nativeAppLoginMethodHandler.GetError(extras));
		}

		[Register("getError", "(Landroid/os/Bundle;)Ljava/lang/String;", "GetGetError_Landroid_os_Bundle_Handler")]
		protected unsafe virtual string GetError(Bundle extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getError.(Landroid/os/Bundle;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(extras);
			}
		}

		private static Delegate GetGetErrorMessage_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_getErrorMessage_Landroid_os_Bundle_ == null)
			{
				cb_getErrorMessage_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetErrorMessage_Landroid_os_Bundle_));
			}
			return cb_getErrorMessage_Landroid_os_Bundle_;
		}

		private static IntPtr n_GetErrorMessage_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_extras)
		{
			NativeAppLoginMethodHandler nativeAppLoginMethodHandler = Java.Lang.Object.GetObject<NativeAppLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(nativeAppLoginMethodHandler.GetErrorMessage(extras));
		}

		[Register("getErrorMessage", "(Landroid/os/Bundle;)Ljava/lang/String;", "GetGetErrorMessage_Landroid_os_Bundle_Handler")]
		protected unsafe virtual string GetErrorMessage(Bundle extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorMessage.(Landroid/os/Bundle;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(extras);
			}
		}

		private static Delegate GetHandleResultCancel_Lcom_facebook_login_LoginClient_Request_Landroid_content_Intent_Handler()
		{
			if ((object)cb_handleResultCancel_Lcom_facebook_login_LoginClient_Request_Landroid_content_Intent_ == null)
			{
				cb_handleResultCancel_Lcom_facebook_login_LoginClient_Request_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_HandleResultCancel_Lcom_facebook_login_LoginClient_Request_Landroid_content_Intent_));
			}
			return cb_handleResultCancel_Lcom_facebook_login_LoginClient_Request_Landroid_content_Intent_;
		}

		private static void n_HandleResultCancel_Lcom_facebook_login_LoginClient_Request_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_request, IntPtr native_data)
		{
			NativeAppLoginMethodHandler nativeAppLoginMethodHandler = Java.Lang.Object.GetObject<NativeAppLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			Intent data = Java.Lang.Object.GetObject<Intent>(native_data, JniHandleOwnership.DoNotTransfer);
			nativeAppLoginMethodHandler.HandleResultCancel(request, data);
		}

		[Register("handleResultCancel", "(Lcom/facebook/login/LoginClient$Request;Landroid/content/Intent;)V", "GetHandleResultCancel_Lcom_facebook_login_LoginClient_Request_Landroid_content_Intent_Handler")]
		protected unsafe virtual void HandleResultCancel(LoginClient.Request request, Intent data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("handleResultCancel.(Lcom/facebook/login/LoginClient$Request;Landroid/content/Intent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetHandleResultError_Lcom_facebook_login_LoginClient_Request_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_handleResultError_Lcom_facebook_login_LoginClient_Request_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_handleResultError_Lcom_facebook_login_LoginClient_Request_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_HandleResultError_Lcom_facebook_login_LoginClient_Request_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_handleResultError_Lcom_facebook_login_LoginClient_Request_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		}

		private static void n_HandleResultError_Lcom_facebook_login_LoginClient_Request_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_request, IntPtr native_error, IntPtr native_errorMessage, IntPtr native_errorCode)
		{
			NativeAppLoginMethodHandler nativeAppLoginMethodHandler = Java.Lang.Object.GetObject<NativeAppLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			string error = JNIEnv.GetString(native_error, JniHandleOwnership.DoNotTransfer);
			string errorMessage = JNIEnv.GetString(native_errorMessage, JniHandleOwnership.DoNotTransfer);
			string errorCode = JNIEnv.GetString(native_errorCode, JniHandleOwnership.DoNotTransfer);
			nativeAppLoginMethodHandler.HandleResultError(request, error, errorMessage, errorCode);
		}

		[Register("handleResultError", "(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "GetHandleResultError_Lcom_facebook_login_LoginClient_Request_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
		protected unsafe virtual void HandleResultError(LoginClient.Request request, string error, string errorMessage, string errorCode)
		{
			IntPtr intPtr = JNIEnv.NewString(error);
			IntPtr intPtr2 = JNIEnv.NewString(errorMessage);
			IntPtr intPtr3 = JNIEnv.NewString(errorCode);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue(intPtr3);
				_members.InstanceMethods.InvokeVirtualVoidMethod("handleResultError.(Lcom/facebook/login/LoginClient$Request;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				GC.KeepAlive(request);
			}
		}

		private static Delegate GetHandleResultOk_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_handleResultOk_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_ == null)
			{
				cb_handleResultOk_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_HandleResultOk_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_));
			}
			return cb_handleResultOk_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_;
		}

		private static void n_HandleResultOk_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_request, IntPtr native_extras)
		{
			NativeAppLoginMethodHandler nativeAppLoginMethodHandler = Java.Lang.Object.GetObject<NativeAppLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			nativeAppLoginMethodHandler.HandleResultOk(request, extras);
		}

		[Register("handleResultOk", "(Lcom/facebook/login/LoginClient$Request;Landroid/os/Bundle;)V", "GetHandleResultOk_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Handler")]
		protected unsafe virtual void HandleResultOk(LoginClient.Request request, Bundle extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("handleResultOk.(Lcom/facebook/login/LoginClient$Request;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
				GC.KeepAlive(extras);
			}
		}

		private static Delegate GetTryIntent_Landroid_content_Intent_IHandler()
		{
			if ((object)cb_tryIntent_Landroid_content_Intent_I == null)
			{
				cb_tryIntent_Landroid_content_Intent_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_Z(n_TryIntent_Landroid_content_Intent_I));
			}
			return cb_tryIntent_Landroid_content_Intent_I;
		}

		private static bool n_TryIntent_Landroid_content_Intent_I(IntPtr jnienv, IntPtr native__this, IntPtr native_intent, int requestCode)
		{
			NativeAppLoginMethodHandler nativeAppLoginMethodHandler = Java.Lang.Object.GetObject<NativeAppLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			return nativeAppLoginMethodHandler.TryIntent(intent, requestCode);
		}

		[Register("tryIntent", "(Landroid/content/Intent;I)Z", "GetTryIntent_Landroid_content_Intent_IHandler")]
		protected unsafe virtual bool TryIntent(Intent intent, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("tryIntent.(Landroid/content/Intent;I)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/facebook/login/NativeAppLoginMethodHandler", DoNotGenerateAcw = true)]
	internal class NativeAppLoginMethodHandlerInvoker : NativeAppLoginMethodHandler
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/NativeAppLoginMethodHandler", typeof(NativeAppLoginMethodHandlerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string NameForLogging
		{
			[Register("getNameForLogging", "()Ljava/lang/String;", "GetGetNameForLoggingHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getNameForLogging.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public NativeAppLoginMethodHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("tryAuthorize", "(Lcom/facebook/login/LoginClient$Request;)I", "GetTryAuthorize_Lcom_facebook_login_LoginClient_Request_Handler")]
		public unsafe override int TryAuthorize(LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("tryAuthorize.(Lcom/facebook/login/LoginClient$Request;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe override int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}
	}
	[Register("com/facebook/login/NonceUtil", DoNotGenerateAcw = true)]
	public sealed class NonceUtil : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/NonceUtil", typeof(NonceUtil));

		[Register("INSTANCE")]
		public static NonceUtil Instance => Java.Lang.Object.GetObject<NonceUtil>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/facebook/login/NonceUtil;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal NonceUtil(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("isValidNonce", "(Ljava/lang/String;)Z", "")]
		public unsafe static bool IsValidNonce(string nonce)
		{
			IntPtr intPtr = JNIEnv.NewString(nonce);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeBooleanMethod("isValidNonce.(Ljava/lang/String;)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/facebook/login/WebLoginMethodHandler", DoNotGenerateAcw = true)]
	public abstract class WebLoginMethodHandler : LoginMethodHandler
	{
		[Register("com/facebook/login/WebLoginMethodHandler$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/WebLoginMethodHandler$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/WebLoginMethodHandler", typeof(WebLoginMethodHandler));

		private static Delegate cb_getSSODevice;

		private static Delegate cb_getTokenSource;

		private static Delegate cb_addExtraParameters_Landroid_os_Bundle_Lcom_facebook_login_LoginClient_Request_;

		private static Delegate cb_getParameters_Lcom_facebook_login_LoginClient_Request_;

		private static Delegate cb_onComplete_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Lcom_facebook_FacebookException_;

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

		protected unsafe virtual string SSODevice
		{
			[Register("getSSODevice", "()Ljava/lang/String;", "GetGetSSODeviceHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSSODevice.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public abstract AccessTokenSource TokenSource
		{
			[Register("getTokenSource", "()Lcom/facebook/AccessTokenSource;", "GetGetTokenSourceHandler")]
			get;
		}

		protected WebLoginMethodHandler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetSSODeviceHandler()
		{
			if ((object)cb_getSSODevice == null)
			{
				cb_getSSODevice = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSSODevice));
			}
			return cb_getSSODevice;
		}

		private static IntPtr n_GetSSODevice(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<WebLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SSODevice);
		}

		private static Delegate GetGetTokenSourceHandler()
		{
			if ((object)cb_getTokenSource == null)
			{
				cb_getTokenSource = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTokenSource));
			}
			return cb_getTokenSource;
		}

		private static IntPtr n_GetTokenSource(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WebLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TokenSource);
		}

		private static Delegate GetAddExtraParameters_Landroid_os_Bundle_Lcom_facebook_login_LoginClient_Request_Handler()
		{
			if ((object)cb_addExtraParameters_Landroid_os_Bundle_Lcom_facebook_login_LoginClient_Request_ == null)
			{
				cb_addExtraParameters_Landroid_os_Bundle_Lcom_facebook_login_LoginClient_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddExtraParameters_Landroid_os_Bundle_Lcom_facebook_login_LoginClient_Request_));
			}
			return cb_addExtraParameters_Landroid_os_Bundle_Lcom_facebook_login_LoginClient_Request_;
		}

		private static IntPtr n_AddExtraParameters_Landroid_os_Bundle_Lcom_facebook_login_LoginClient_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_parameters, IntPtr native_request)
		{
			WebLoginMethodHandler webLoginMethodHandler = Java.Lang.Object.GetObject<WebLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle parameters = Java.Lang.Object.GetObject<Bundle>(native_parameters, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(webLoginMethodHandler.AddExtraParameters(parameters, request));
		}

		[Register("addExtraParameters", "(Landroid/os/Bundle;Lcom/facebook/login/LoginClient$Request;)Landroid/os/Bundle;", "GetAddExtraParameters_Landroid_os_Bundle_Lcom_facebook_login_LoginClient_Request_Handler")]
		protected unsafe virtual Bundle AddExtraParameters(Bundle parameters, LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("addExtraParameters.(Landroid/os/Bundle;Lcom/facebook/login/LoginClient$Request;)Landroid/os/Bundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(parameters);
				GC.KeepAlive(request);
			}
		}

		private static Delegate GetGetParameters_Lcom_facebook_login_LoginClient_Request_Handler()
		{
			if ((object)cb_getParameters_Lcom_facebook_login_LoginClient_Request_ == null)
			{
				cb_getParameters_Lcom_facebook_login_LoginClient_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetParameters_Lcom_facebook_login_LoginClient_Request_));
			}
			return cb_getParameters_Lcom_facebook_login_LoginClient_Request_;
		}

		private static IntPtr n_GetParameters_Lcom_facebook_login_LoginClient_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
		{
			WebLoginMethodHandler webLoginMethodHandler = Java.Lang.Object.GetObject<WebLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(webLoginMethodHandler.GetParameters(request));
		}

		[Register("getParameters", "(Lcom/facebook/login/LoginClient$Request;)Landroid/os/Bundle;", "GetGetParameters_Lcom_facebook_login_LoginClient_Request_Handler")]
		protected unsafe virtual Bundle GetParameters(LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParameters.(Lcom/facebook/login/LoginClient$Request;)Landroid/os/Bundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}

		private static Delegate GetOnComplete_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Lcom_facebook_FacebookException_Handler()
		{
			if ((object)cb_onComplete_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Lcom_facebook_FacebookException_ == null)
			{
				cb_onComplete_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Lcom_facebook_FacebookException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnComplete_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Lcom_facebook_FacebookException_));
			}
			return cb_onComplete_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Lcom_facebook_FacebookException_;
		}

		private static void n_OnComplete_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Lcom_facebook_FacebookException_(IntPtr jnienv, IntPtr native__this, IntPtr native_request, IntPtr native_values, IntPtr native_error)
		{
			WebLoginMethodHandler webLoginMethodHandler = Java.Lang.Object.GetObject<WebLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			Bundle values = Java.Lang.Object.GetObject<Bundle>(native_values, JniHandleOwnership.DoNotTransfer);
			FacebookException error = Java.Lang.Object.GetObject<FacebookException>(native_error, JniHandleOwnership.DoNotTransfer);
			webLoginMethodHandler.OnComplete(request, values, error);
		}

		[Register("onComplete", "(Lcom/facebook/login/LoginClient$Request;Landroid/os/Bundle;Lcom/facebook/FacebookException;)V", "GetOnComplete_Lcom_facebook_login_LoginClient_Request_Landroid_os_Bundle_Lcom_facebook_FacebookException_Handler")]
		public unsafe virtual void OnComplete(LoginClient.Request request, Bundle values, FacebookException error)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(values?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(error?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onComplete.(Lcom/facebook/login/LoginClient$Request;Landroid/os/Bundle;Lcom/facebook/FacebookException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
				GC.KeepAlive(values);
				GC.KeepAlive(error);
			}
		}
	}
	[Register("com/facebook/login/WebLoginMethodHandler", DoNotGenerateAcw = true)]
	internal class WebLoginMethodHandlerInvoker : WebLoginMethodHandler
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/WebLoginMethodHandler", typeof(WebLoginMethodHandlerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override AccessTokenSource TokenSource
		{
			[Register("getTokenSource", "()Lcom/facebook/AccessTokenSource;", "GetGetTokenSourceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<AccessTokenSource>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTokenSource.()Lcom/facebook/AccessTokenSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string NameForLogging
		{
			[Register("getNameForLogging", "()Ljava/lang/String;", "GetGetNameForLoggingHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getNameForLogging.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public WebLoginMethodHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("tryAuthorize", "(Lcom/facebook/login/LoginClient$Request;)I", "GetTryAuthorize_Lcom_facebook_login_LoginClient_Request_Handler")]
		public unsafe override int TryAuthorize(LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("tryAuthorize.(Lcom/facebook/login/LoginClient$Request;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe override int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}
	}
	[Register("com/facebook/login/WebViewLoginMethodHandler", DoNotGenerateAcw = true)]
	public class WebViewLoginMethodHandler : WebLoginMethodHandler
	{
		[Register("com/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder", DoNotGenerateAcw = true)]
		public sealed class AuthDialogBuilder : Xamarin.Facebook.Internal.WebDialog.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder", typeof(AuthDialogBuilder));

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

			public unsafe string AuthType
			{
				[Register("getAuthType", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAuthType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setAuthType", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setAuthType.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			public unsafe string E2e
			{
				[Register("getE2e", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getE2e.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setE2e", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setE2e.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			internal AuthDialogBuilder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lcom/facebook/login/WebViewLoginMethodHandler;Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)V", "")]
			public unsafe AuthDialogBuilder(WebViewLoginMethodHandler __self, Context context, string applicationId, Bundle parameters)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				string constructorSignature = "(L" + JNIEnv.GetJniName(GetType().DeclaringType) + ";Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)V";
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.NewString(applicationId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(__self?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(intPtr);
					ptr[3] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance(constructorSignature, GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance(constructorSignature, this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(__self);
					GC.KeepAlive(context);
					GC.KeepAlive(parameters);
				}
			}

			[Register("setAuthType", "(Ljava/lang/String;)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", "")]
			public unsafe AuthDialogBuilder SetAuthType(string authType)
			{
				IntPtr intPtr = JNIEnv.NewString(authType);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<AuthDialogBuilder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setAuthType.(Ljava/lang/String;)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setE2E", "(Ljava/lang/String;)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", "")]
			public unsafe AuthDialogBuilder SetE2E(string e2e)
			{
				IntPtr intPtr = JNIEnv.NewString(e2e);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<AuthDialogBuilder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setE2E.(Ljava/lang/String;)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setFamilyLogin", "(Z)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", "")]
			public unsafe AuthDialogBuilder SetFamilyLogin(bool isFamilyLogin)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(isFamilyLogin);
				return Java.Lang.Object.GetObject<AuthDialogBuilder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setFamilyLogin.(Z)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setIsChromeOS", "(Z)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", "")]
			public unsafe AuthDialogBuilder SetIsChromeOS(bool isChromeOS)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(isChromeOS);
				return Java.Lang.Object.GetObject<AuthDialogBuilder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setIsChromeOS.(Z)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setIsRerequest", "(Z)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", "")]
			public unsafe AuthDialogBuilder SetIsRerequest(bool isRerequest)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(isRerequest);
				return Java.Lang.Object.GetObject<AuthDialogBuilder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setIsRerequest.(Z)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setLoginBehavior", "(Lcom/facebook/login/LoginBehavior;)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", "")]
			public unsafe AuthDialogBuilder SetLoginBehavior(LoginBehavior loginBehavior)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(loginBehavior?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<AuthDialogBuilder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setLoginBehavior.(Lcom/facebook/login/LoginBehavior;)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(loginBehavior);
				}
			}

			[Register("setLoginTargetApp", "(Lcom/facebook/login/LoginTargetApp;)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", "")]
			public unsafe AuthDialogBuilder SetLoginTargetApp(LoginTargetApp targetApp)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(targetApp?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<AuthDialogBuilder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setLoginTargetApp.(Lcom/facebook/login/LoginTargetApp;)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(targetApp);
				}
			}

			[Register("setShouldSkipDedupe", "(Z)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", "")]
			public unsafe AuthDialogBuilder SetShouldSkipDedupe(bool shouldSkip)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(shouldSkip);
				return Java.Lang.Object.GetObject<AuthDialogBuilder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setShouldSkipDedupe.(Z)Lcom/facebook/login/WebViewLoginMethodHandler$AuthDialogBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/facebook/login/WebViewLoginMethodHandler$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/WebViewLoginMethodHandler$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/WebViewLoginMethodHandler", typeof(WebViewLoginMethodHandler));

		private static Delegate cb_getNameForLogging;

		private static Delegate cb_getTokenSource;

		private static Delegate cb_describeContents;

		private static Delegate cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_;

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string E2e
		{
			[Register("getE2e", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getE2e.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setE2e", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setE2e.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe Xamarin.Facebook.Internal.WebDialog LoginDialog
		{
			[Register("getLoginDialog", "()Lcom/facebook/internal/WebDialog;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Xamarin.Facebook.Internal.WebDialog>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLoginDialog.()Lcom/facebook/internal/WebDialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLoginDialog", "(Lcom/facebook/internal/WebDialog;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLoginDialog.(Lcom/facebook/internal/WebDialog;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe override string NameForLogging
		{
			[Register("getNameForLogging", "()Ljava/lang/String;", "GetGetNameForLoggingHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getNameForLogging.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override AccessTokenSource TokenSource
		{
			[Register("getTokenSource", "()Lcom/facebook/AccessTokenSource;", "GetGetTokenSourceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<AccessTokenSource>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTokenSource.()Lcom/facebook/AccessTokenSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected WebViewLoginMethodHandler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/os/Parcel;)V", "")]
		public unsafe WebViewLoginMethodHandler(Parcel source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Parcel;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Parcel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Lcom/facebook/login/LoginClient;)V", "")]
		public unsafe WebViewLoginMethodHandler(LoginClient loginClient)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(loginClient?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/login/LoginClient;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/login/LoginClient;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(loginClient);
			}
		}

		private static Delegate GetGetNameForLoggingHandler()
		{
			if ((object)cb_getNameForLogging == null)
			{
				cb_getNameForLogging = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNameForLogging));
			}
			return cb_getNameForLogging;
		}

		private static IntPtr n_GetNameForLogging(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<WebViewLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NameForLogging);
		}

		private static Delegate GetGetTokenSourceHandler()
		{
			if ((object)cb_getTokenSource == null)
			{
				cb_getTokenSource = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTokenSource));
			}
			return cb_getTokenSource;
		}

		private static IntPtr n_GetTokenSource(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WebViewLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TokenSource);
		}

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<WebViewLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe override int DescribeContents()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
		}

		[Register("onWebDialogComplete", "(Lcom/facebook/login/LoginClient$Request;Landroid/os/Bundle;Lcom/facebook/FacebookException;)V", "")]
		public unsafe void OnWebDialogComplete(LoginClient.Request request, Bundle values, FacebookException error)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(values?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(error?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onWebDialogComplete.(Lcom/facebook/login/LoginClient$Request;Landroid/os/Bundle;Lcom/facebook/FacebookException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
				GC.KeepAlive(values);
				GC.KeepAlive(error);
			}
		}

		private static Delegate GetTryAuthorize_Lcom_facebook_login_LoginClient_Request_Handler()
		{
			if ((object)cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_ == null)
			{
				cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_TryAuthorize_Lcom_facebook_login_LoginClient_Request_));
			}
			return cb_tryAuthorize_Lcom_facebook_login_LoginClient_Request_;
		}

		private static int n_TryAuthorize_Lcom_facebook_login_LoginClient_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
		{
			WebViewLoginMethodHandler webViewLoginMethodHandler = Java.Lang.Object.GetObject<WebViewLoginMethodHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginClient.Request request = Java.Lang.Object.GetObject<LoginClient.Request>(native_request, JniHandleOwnership.DoNotTransfer);
			return webViewLoginMethodHandler.TryAuthorize(request);
		}

		[Register("tryAuthorize", "(Lcom/facebook/login/LoginClient$Request;)I", "GetTryAuthorize_Lcom_facebook_login_LoginClient_Request_Handler")]
		public unsafe override int TryAuthorize(LoginClient.Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("tryAuthorize.(Lcom/facebook/login/LoginClient$Request;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}
	}
}
namespace Xamarin.Facebook.Internal
{
	[Register("com/facebook/internal/AppCall", DoNotGenerateAcw = true)]
	public sealed class AppCall : Java.Lang.Object
	{
		[Register("com/facebook/internal/AppCall$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/AppCall$Companion", typeof(Companion));

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

			public unsafe AppCall CurrentPendingCall
			{
				[Register("getCurrentPendingCall", "()Lcom/facebook/internal/AppCall;", "")]
				get
				{
					return Java.Lang.Object.GetObject<AppCall>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCurrentPendingCall.()Lcom/facebook/internal/AppCall;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("finishPendingCall", "(Ljava/util/UUID;I)Lcom/facebook/internal/AppCall;", "")]
			public unsafe AppCall FinishPendingCall(UUID callId, int requestCode)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(callId?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(requestCode);
					return Java.Lang.Object.GetObject<AppCall>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("finishPendingCall.(Ljava/util/UUID;I)Lcom/facebook/internal/AppCall;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(callId);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/AppCall", typeof(AppCall));

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

		public unsafe UUID CallId
		{
			[Register("getCallId", "()Ljava/util/UUID;", "")]
			get
			{
				return Java.Lang.Object.GetObject<UUID>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCallId.()Ljava/util/UUID;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int RequestCode
		{
			[Register("getRequestCode", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getRequestCode.()I", this, null);
			}
			[Register("setRequestCode", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setRequestCode.(I)V", this, ptr);
			}
		}

		public unsafe Intent RequestIntent
		{
			[Register("getRequestIntent", "()Landroid/content/Intent;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getRequestIntent.()Landroid/content/Intent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setRequestIntent", "(Landroid/content/Intent;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setRequestIntent.(Landroid/content/Intent;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		internal AppCall(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe AppCall(int requestCode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(requestCode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		[Register(".ctor", "(ILjava/util/UUID;)V", "")]
		public unsafe AppCall(int requestCode, UUID callId)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(requestCode);
				ptr[1] = new JniArgumentValue(callId?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/util/UUID;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILjava/util/UUID;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callId);
			}
		}

		[Register("finishPendingCall", "(Ljava/util/UUID;I)Lcom/facebook/internal/AppCall;", "")]
		public unsafe static AppCall FinishPendingCall(UUID callId, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(callId?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				return Java.Lang.Object.GetObject<AppCall>(_members.StaticMethods.InvokeObjectMethod("finishPendingCall.(Ljava/util/UUID;I)Lcom/facebook/internal/AppCall;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(callId);
			}
		}

		[Register("setPending", "()Z", "")]
		public unsafe bool SetPending()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("setPending.()Z", this, null);
		}
	}
	[Register("com/facebook/internal/CustomTab", DoNotGenerateAcw = true)]
	public class CustomTab : Java.Lang.Object
	{
		[Register("com/facebook/internal/CustomTab$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/CustomTab$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("getURIForAction", "(Ljava/lang/String;Landroid/os/Bundle;)Landroid/net/Uri;", "")]
			public unsafe Android.Net.Uri GetURIForAction(string action, Bundle parameters)
			{
				IntPtr intPtr = JNIEnv.NewString(action);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeAbstractObjectMethod("getURIForAction.(Ljava/lang/String;Landroid/os/Bundle;)Landroid/net/Uri;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parameters);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/CustomTab", typeof(CustomTab));

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

		protected unsafe Android.Net.Uri Uri
		{
			[Register("getUri", "()Landroid/net/Uri;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setUri", "(Landroid/net/Uri;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setUri.(Landroid/net/Uri;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected CustomTab(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Landroid/os/Bundle;)V", "")]
		public unsafe CustomTab(string action, Bundle parameters)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(action);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/os/Bundle;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(parameters);
			}
		}

		[Register("getURIForAction", "(Ljava/lang/String;Landroid/os/Bundle;)Landroid/net/Uri;", "")]
		public unsafe static Android.Net.Uri GetURIForAction(string action, Bundle parameters)
		{
			IntPtr intPtr = JNIEnv.NewString(action);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.StaticMethods.InvokeObjectMethod("getURIForAction.(Ljava/lang/String;Landroid/os/Bundle;)Landroid/net/Uri;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(parameters);
			}
		}

		[Register("openCustomTab", "(Landroid/app/Activity;Ljava/lang/String;)Z", "")]
		public unsafe bool OpenCustomTab(Activity activity, string packageName)
		{
			IntPtr intPtr = JNIEnv.NewString(packageName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("openCustomTab.(Landroid/app/Activity;Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(activity);
			}
		}
	}
	[Register("com/facebook/internal/CustomTabUtils", DoNotGenerateAcw = true)]
	public sealed class CustomTabUtils : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/CustomTabUtils", typeof(CustomTabUtils));

		[Register("INSTANCE")]
		public static CustomTabUtils Instance => Java.Lang.Object.GetObject<CustomTabUtils>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/facebook/internal/CustomTabUtils;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe static string ChromePackage
		{
			[Register("getChromePackage", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getChromePackage.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static string DefaultRedirectURI
		{
			[Register("getDefaultRedirectURI", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getDefaultRedirectURI.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CustomTabUtils(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getValidRedirectURI", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe static string GetValidRedirectURI(string developerDefinedRedirectURI)
		{
			IntPtr intPtr = JNIEnv.NewString(developerDefinedRedirectURI);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getValidRedirectURI.(Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/facebook/internal/DialogPresenter", DoNotGenerateAcw = true)]
	public sealed class DialogPresenter : Java.Lang.Object
	{
		[Register("com/facebook/internal/DialogPresenter$ParameterProvider", "", "Xamarin.Facebook.Internal.DialogPresenter/IParameterProviderInvoker")]
		public interface IParameterProvider : IJavaObject, IDisposable, IJavaPeerable
		{
			Bundle LegacyParameters
			{
				[Register("getLegacyParameters", "()Landroid/os/Bundle;", "GetGetLegacyParametersHandler:Xamarin.Facebook.Internal.DialogPresenter/IParameterProviderInvoker, Xamarin.Facebook.Common.Android")]
				get;
			}

			Bundle Parameters
			{
				[Register("getParameters", "()Landroid/os/Bundle;", "GetGetParametersHandler:Xamarin.Facebook.Internal.DialogPresenter/IParameterProviderInvoker, Xamarin.Facebook.Common.Android")]
				get;
			}
		}

		[Register("com/facebook/internal/DialogPresenter$ParameterProvider", DoNotGenerateAcw = true)]
		internal class IParameterProviderInvoker : Java.Lang.Object, IParameterProvider, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/DialogPresenter$ParameterProvider", typeof(IParameterProviderInvoker));

			private IntPtr class_ref;

			private static Delegate cb_getLegacyParameters;

			private IntPtr id_getLegacyParameters;

			private static Delegate cb_getParameters;

			private IntPtr id_getParameters;

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

			public Bundle LegacyParameters
			{
				get
				{
					if (id_getLegacyParameters == IntPtr.Zero)
					{
						id_getLegacyParameters = JNIEnv.GetMethodID(class_ref, "getLegacyParameters", "()Landroid/os/Bundle;");
					}
					return Java.Lang.Object.GetObject<Bundle>(JNIEnv.CallObjectMethod(base.Handle, id_getLegacyParameters), JniHandleOwnership.TransferLocalRef);
				}
			}

			public Bundle Parameters
			{
				get
				{
					if (id_getParameters == IntPtr.Zero)
					{
						id_getParameters = JNIEnv.GetMethodID(class_ref, "getParameters", "()Landroid/os/Bundle;");
					}
					return Java.Lang.Object.GetObject<Bundle>(JNIEnv.CallObjectMethod(base.Handle, id_getParameters), JniHandleOwnership.TransferLocalRef);
				}
			}

			public static IParameterProvider GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IParameterProvider>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.DialogPresenter.ParameterProvider'.");
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

			public IParameterProviderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetGetLegacyParametersHandler()
			{
				if ((object)cb_getLegacyParameters == null)
				{
					cb_getLegacyParameters = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLegacyParameters));
				}
				return cb_getLegacyParameters;
			}

			private static IntPtr n_GetLegacyParameters(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IParameterProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LegacyParameters);
			}

			private static Delegate GetGetParametersHandler()
			{
				if ((object)cb_getParameters == null)
				{
					cb_getParameters = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetParameters));
				}
				return cb_getParameters;
			}

			private static IntPtr n_GetParameters(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IParameterProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parameters);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/DialogPresenter", typeof(DialogPresenter));

		[Register("INSTANCE")]
		public static DialogPresenter Instance => Java.Lang.Object.GetObject<DialogPresenter>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/facebook/internal/DialogPresenter;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal DialogPresenter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("canPresentNativeDialogWithFeature", "(Lcom/facebook/internal/DialogFeature;)Z", "")]
		public unsafe static bool CanPresentNativeDialogWithFeature(IDialogFeature feature)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((feature == null) ? IntPtr.Zero : ((Java.Lang.Object)feature).Handle);
				return _members.StaticMethods.InvokeBooleanMethod("canPresentNativeDialogWithFeature.(Lcom/facebook/internal/DialogFeature;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(feature);
			}
		}

		[Register("canPresentWebFallbackDialogWithFeature", "(Lcom/facebook/internal/DialogFeature;)Z", "")]
		public unsafe static bool CanPresentWebFallbackDialogWithFeature(IDialogFeature feature)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((feature == null) ? IntPtr.Zero : ((Java.Lang.Object)feature).Handle);
				return _members.StaticMethods.InvokeBooleanMethod("canPresentWebFallbackDialogWithFeature.(Lcom/facebook/internal/DialogFeature;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(feature);
			}
		}

		[Register("getProtocolVersionForNativeDialog", "(Lcom/facebook/internal/DialogFeature;)Lcom/facebook/internal/NativeProtocol$ProtocolVersionQueryResult;", "")]
		public unsafe static NativeProtocol.ProtocolVersionQueryResult GetProtocolVersionForNativeDialog(IDialogFeature feature)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((feature == null) ? IntPtr.Zero : ((Java.Lang.Object)feature).Handle);
				return Java.Lang.Object.GetObject<NativeProtocol.ProtocolVersionQueryResult>(_members.StaticMethods.InvokeObjectMethod("getProtocolVersionForNativeDialog.(Lcom/facebook/internal/DialogFeature;)Lcom/facebook/internal/NativeProtocol$ProtocolVersionQueryResult;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(feature);
			}
		}

		[Register("logDialogActivity", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void LogDialogActivity(Context context, string eventName, string outcome)
		{
			IntPtr intPtr = JNIEnv.NewString(eventName);
			IntPtr intPtr2 = JNIEnv.NewString(outcome);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("logDialogActivity.(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
			}
		}

		[Register("present", "(Lcom/facebook/internal/AppCall;Landroid/app/Activity;)V", "")]
		public unsafe static void Present(AppCall appCall, Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(appCall?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("present.(Lcom/facebook/internal/AppCall;Landroid/app/Activity;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(appCall);
				GC.KeepAlive(activity);
			}
		}

		[Register("present", "(Lcom/facebook/internal/AppCall;Landroidx/activity/result/ActivityResultRegistry;Lcom/facebook/CallbackManager;)V", "")]
		public unsafe static void Present(AppCall appCall, ActivityResultRegistry registry, ICallbackManager callbackManager)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(appCall?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(registry?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				_members.StaticMethods.InvokeVoidMethod("present.(Lcom/facebook/internal/AppCall;Landroidx/activity/result/ActivityResultRegistry;Lcom/facebook/CallbackManager;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(appCall);
				GC.KeepAlive(registry);
				GC.KeepAlive(callbackManager);
			}
		}

		[Register("present", "(Lcom/facebook/internal/AppCall;Lcom/facebook/internal/FragmentWrapper;)V", "")]
		public unsafe static void Present(AppCall appCall, FragmentWrapper fragmentWrapper)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(appCall?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(fragmentWrapper?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("present.(Lcom/facebook/internal/AppCall;Lcom/facebook/internal/FragmentWrapper;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(appCall);
				GC.KeepAlive(fragmentWrapper);
			}
		}

		[Register("setupAppCallForCannotShowError", "(Lcom/facebook/internal/AppCall;)V", "")]
		public unsafe static void SetupAppCallForCannotShowError(AppCall appCall)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(appCall?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("setupAppCallForCannotShowError.(Lcom/facebook/internal/AppCall;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(appCall);
			}
		}

		[Register("setupAppCallForCustomTabDialog", "(Lcom/facebook/internal/AppCall;Ljava/lang/String;Landroid/os/Bundle;)V", "")]
		public unsafe static void SetupAppCallForCustomTabDialog(AppCall appCall, string action, Bundle parameters)
		{
			IntPtr intPtr = JNIEnv.NewString(action);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(appCall?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("setupAppCallForCustomTabDialog.(Lcom/facebook/internal/AppCall;Ljava/lang/String;Landroid/os/Bundle;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(appCall);
				GC.KeepAlive(parameters);
			}
		}

		[Register("setupAppCallForErrorResult", "(Lcom/facebook/internal/AppCall;Lcom/facebook/FacebookException;)V", "")]
		public unsafe static void SetupAppCallForErrorResult(AppCall appCall, FacebookException exception)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(appCall?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(exception?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("setupAppCallForErrorResult.(Lcom/facebook/internal/AppCall;Lcom/facebook/FacebookException;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(appCall);
				GC.KeepAlive(exception);
			}
		}

		[Register("setupAppCallForNativeDialog", "(Lcom/facebook/internal/AppCall;Lcom/facebook/internal/DialogPresenter$ParameterProvider;Lcom/facebook/internal/DialogFeature;)V", "")]
		public unsafe static void SetupAppCallForNativeDialog(AppCall appCall, IParameterProvider parameterProvider, IDialogFeature feature)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(appCall?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((parameterProvider == null) ? IntPtr.Zero : ((Java.Lang.Object)parameterProvider).Handle);
				ptr[2] = new JniArgumentValue((feature == null) ? IntPtr.Zero : ((Java.Lang.Object)feature).Handle);
				_members.StaticMethods.InvokeVoidMethod("setupAppCallForNativeDialog.(Lcom/facebook/internal/AppCall;Lcom/facebook/internal/DialogPresenter$ParameterProvider;Lcom/facebook/internal/DialogFeature;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(appCall);
				GC.KeepAlive(parameterProvider);
				GC.KeepAlive(feature);
			}
		}

		[Register("setupAppCallForValidationError", "(Lcom/facebook/internal/AppCall;Lcom/facebook/FacebookException;)V", "")]
		public unsafe static void SetupAppCallForValidationError(AppCall appCall, FacebookException validationError)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(appCall?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(validationError?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("setupAppCallForValidationError.(Lcom/facebook/internal/AppCall;Lcom/facebook/FacebookException;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(appCall);
				GC.KeepAlive(validationError);
			}
		}

		[Register("setupAppCallForWebDialog", "(Lcom/facebook/internal/AppCall;Ljava/lang/String;Landroid/os/Bundle;)V", "")]
		public unsafe static void SetupAppCallForWebDialog(AppCall appCall, string actionName, Bundle parameters)
		{
			IntPtr intPtr = JNIEnv.NewString(actionName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(appCall?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("setupAppCallForWebDialog.(Lcom/facebook/internal/AppCall;Ljava/lang/String;Landroid/os/Bundle;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(appCall);
				GC.KeepAlive(parameters);
			}
		}

		[Register("setupAppCallForWebFallbackDialog", "(Lcom/facebook/internal/AppCall;Landroid/os/Bundle;Lcom/facebook/internal/DialogFeature;)V", "")]
		public unsafe static void SetupAppCallForWebFallbackDialog(AppCall appCall, Bundle parameters, IDialogFeature feature)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(appCall?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((feature == null) ? IntPtr.Zero : ((Java.Lang.Object)feature).Handle);
				_members.StaticMethods.InvokeVoidMethod("setupAppCallForWebFallbackDialog.(Lcom/facebook/internal/AppCall;Landroid/os/Bundle;Lcom/facebook/internal/DialogFeature;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(appCall);
				GC.KeepAlive(parameters);
				GC.KeepAlive(feature);
			}
		}

		[Register("startActivityForResultWithAndroidX", "(Landroidx/activity/result/ActivityResultRegistry;Lcom/facebook/CallbackManager;Landroid/content/Intent;I)V", "")]
		public unsafe static void StartActivityForResultWithAndroidX(ActivityResultRegistry registry, ICallbackManager callbackManager, Intent intent, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(registry?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[2] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(requestCode);
				_members.StaticMethods.InvokeVoidMethod("startActivityForResultWithAndroidX.(Landroidx/activity/result/ActivityResultRegistry;Lcom/facebook/CallbackManager;Landroid/content/Intent;I)V", ptr);
			}
			finally
			{
				GC.KeepAlive(registry);
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/facebook/internal/FacebookDialogBase", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "CONTENT", "RESULT" })]
	public abstract class FacebookDialogBase : Java.Lang.Object, IFacebookDialog, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/internal/FacebookDialogBase$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/FacebookDialogBase$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		[Register("com/facebook/internal/FacebookDialogBase$ModeHandler", DoNotGenerateAcw = true)]
		protected internal abstract class ModeHandler : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/FacebookDialogBase$ModeHandler", typeof(ModeHandler));

			private static Delegate cb_getMode;

			private static Delegate cb_setMode_Ljava_lang_Object_;

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

			public unsafe virtual Java.Lang.Object Mode
			{
				[Register("getMode", "()Ljava/lang/Object;", "GetGetModeHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMode.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setMode", "(Ljava/lang/Object;)V", "GetSetMode_Ljava_lang_Object_Handler")]
				set
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
						_members.InstanceMethods.InvokeVirtualVoidMethod("setMode.(Ljava/lang/Object;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(value);
					}
				}
			}

			protected ModeHandler(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lcom/facebook/internal/FacebookDialogBase;)V", "")]
			public unsafe ModeHandler(FacebookDialogBase __self)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				string constructorSignature = "(L" + JNIEnv.GetJniName(GetType().DeclaringType) + ";)V";
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(__self?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance(constructorSignature, GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance(constructorSignature, this, ptr);
				}
				finally
				{
					GC.KeepAlive(__self);
				}
			}

			private static Delegate GetGetModeHandler()
			{
				if ((object)cb_getMode == null)
				{
					cb_getMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMode));
				}
				return cb_getMode;
			}

			private static IntPtr n_GetMode(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ModeHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Mode);
			}

			private static Delegate GetSetMode_Ljava_lang_Object_Handler()
			{
				if ((object)cb_setMode_Ljava_lang_Object_ == null)
				{
					cb_setMode_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetMode_Ljava_lang_Object_));
				}
				return cb_setMode_Ljava_lang_Object_;
			}

			private static void n_SetMode_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
			{
				ModeHandler modeHandler = Java.Lang.Object.GetObject<ModeHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object mode = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
				modeHandler.Mode = mode;
			}
		}

		[Register("com/facebook/internal/FacebookDialogBase$ModeHandler", DoNotGenerateAcw = true)]
		internal class ModeHandlerInvoker : ModeHandler
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/FacebookDialogBase$ModeHandler", typeof(ModeHandlerInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public ModeHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/FacebookDialogBase", typeof(FacebookDialogBase));

		private static Delegate cb_canShow_Ljava_lang_Object_;

		private static Delegate cb_canShowImpl_Ljava_lang_Object_Ljava_lang_Object_;

		private static Delegate cb_createBaseAppCall;

		private static Delegate cb_getOrderedModeHandlers;

		private static Delegate cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I;

		private static Delegate cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_show_Ljava_lang_Object_;

		private static Delegate cb_showImpl_Ljava_lang_Object_Ljava_lang_Object_;

		[Register("BASE_AUTOMATIC_MODE")]
		public static Java.Lang.Object BaseAutomaticMode => Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticFields.GetObjectValue("BASE_AUTOMATIC_MODE.Ljava/lang/Object;").Handle, JniHandleOwnership.TransferLocalRef);

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

		protected unsafe Activity ActivityContext
		{
			[Register("getActivityContext", "()Landroid/app/Activity;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Activity>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getActivityContext.()Landroid/app/Activity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int RequestCode
		{
			[Register("getRequestCode", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getRequestCode.()I", this, null);
			}
			[Register("setRequestCode", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setRequestCode.(I)V", this, ptr);
			}
		}

		protected FacebookDialogBase(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;I)V", "")]
		protected unsafe FacebookDialogBase(Activity activity, int requestCode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[Register(".ctor", "(Lcom/facebook/internal/FragmentWrapper;I)V", "")]
		protected unsafe FacebookDialogBase(FragmentWrapper fragmentWrapper, int requestCode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragmentWrapper?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/internal/FragmentWrapper;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/internal/FragmentWrapper;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragmentWrapper);
			}
		}

		private static Delegate GetCanShow_Ljava_lang_Object_Handler()
		{
			if ((object)cb_canShow_Ljava_lang_Object_ == null)
			{
				cb_canShow_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_CanShow_Ljava_lang_Object_));
			}
			return cb_canShow_Ljava_lang_Object_;
		}

		private static bool n_CanShow_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
		{
			FacebookDialogBase facebookDialogBase = Java.Lang.Object.GetObject<FacebookDialogBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object content = Java.Lang.Object.GetObject<Java.Lang.Object>(native_content, JniHandleOwnership.DoNotTransfer);
			return facebookDialogBase.CanShow(content);
		}

		[Register("canShow", "(Ljava/lang/Object;)Z", "GetCanShow_Ljava_lang_Object_Handler")]
		public unsafe virtual bool CanShow(Java.Lang.Object content)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canShow.(Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(content);
			}
		}

		private static Delegate GetCanShowImpl_Ljava_lang_Object_Ljava_lang_Object_Handler()
		{
			if ((object)cb_canShowImpl_Ljava_lang_Object_Ljava_lang_Object_ == null)
			{
				cb_canShowImpl_Ljava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_CanShowImpl_Ljava_lang_Object_Ljava_lang_Object_));
			}
			return cb_canShowImpl_Ljava_lang_Object_Ljava_lang_Object_;
		}

		private static bool n_CanShowImpl_Ljava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_content, IntPtr native_mode)
		{
			FacebookDialogBase facebookDialogBase = Java.Lang.Object.GetObject<FacebookDialogBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object content = Java.Lang.Object.GetObject<Java.Lang.Object>(native_content, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object mode = Java.Lang.Object.GetObject<Java.Lang.Object>(native_mode, JniHandleOwnership.DoNotTransfer);
			return facebookDialogBase.CanShowImpl(content, mode);
		}

		[Register("canShowImpl", "(Ljava/lang/Object;Ljava/lang/Object;)Z", "GetCanShowImpl_Ljava_lang_Object_Ljava_lang_Object_Handler")]
		protected unsafe virtual bool CanShowImpl(Java.Lang.Object content, Java.Lang.Object mode)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canShowImpl.(Ljava/lang/Object;Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(content);
				GC.KeepAlive(mode);
			}
		}

		private static Delegate GetCreateBaseAppCallHandler()
		{
			if ((object)cb_createBaseAppCall == null)
			{
				cb_createBaseAppCall = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateBaseAppCall));
			}
			return cb_createBaseAppCall;
		}

		private static IntPtr n_CreateBaseAppCall(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FacebookDialogBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateBaseAppCall());
		}

		[Register("createBaseAppCall", "()Lcom/facebook/internal/AppCall;", "GetCreateBaseAppCallHandler")]
		protected abstract AppCall CreateBaseAppCall();

		private static Delegate Get_OrderedModeHandlersHandler()
		{
			if ((object)cb_getOrderedModeHandlers == null)
			{
				cb_getOrderedModeHandlers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n__OrderedModeHandlers));
			}
			return cb_getOrderedModeHandlers;
		}

		private static IntPtr n__OrderedModeHandlers(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList.ToLocalJniHandle(Java.Lang.Object.GetObject<FacebookDialogBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer)._OrderedModeHandlers());
		}

		[Register("getOrderedModeHandlers", "()Ljava/util/List;", "Get_OrderedModeHandlersHandler")]
		protected abstract System.Collections.IList _OrderedModeHandlers();

		private static Delegate GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_Handler()
		{
			if ((object)cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_ == null)
			{
				cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_));
			}
			return cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_;
		}

		private static void n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager, IntPtr native__callback)
		{
			FacebookDialogBase facebookDialogBase = Java.Lang.Object.GetObject<FacebookDialogBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallbackManager callbackManager = Java.Lang.Object.GetObject<ICallbackManager>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			facebookDialogBase.RegisterCallback(callbackManager, callback);
		}

		[Register("registerCallback", "(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V", "GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_Handler")]
		public unsafe virtual void RegisterCallback(ICallbackManager callbackManager, IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerCallback.(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_IHandler()
		{
			if ((object)cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I == null)
			{
				cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I));
			}
			return cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I;
		}

		private static void n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager, IntPtr native__callback, int requestCode)
		{
			FacebookDialogBase facebookDialogBase = Java.Lang.Object.GetObject<FacebookDialogBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallbackManager callbackManager = Java.Lang.Object.GetObject<ICallbackManager>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			facebookDialogBase.RegisterCallback(callbackManager, callback, requestCode);
		}

		[Register("registerCallback", "(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;I)V", "GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_IHandler")]
		public unsafe virtual void RegisterCallback(ICallbackManager callbackManager, IFacebookCallback callback, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				ptr[2] = new JniArgumentValue(requestCode);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerCallback.(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetRegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_Handler()
		{
			if ((object)cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_ == null)
			{
				cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_));
			}
			return cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;
		}

		private static void n_RegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager, IntPtr native__callback)
		{
			FacebookDialogBase facebookDialogBase = Java.Lang.Object.GetObject<FacebookDialogBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CallbackManagerImpl callbackManager = Java.Lang.Object.GetObject<CallbackManagerImpl>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			facebookDialogBase.RegisterCallbackImpl(callbackManager, callback);
		}

		[Register("registerCallbackImpl", "(Lcom/facebook/internal/CallbackManagerImpl;Lcom/facebook/FacebookCallback;)V", "GetRegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_Handler")]
		protected abstract void RegisterCallbackImpl(CallbackManagerImpl callbackManager, IFacebookCallback callback);

		[Register("setCallbackManager", "(Lcom/facebook/CallbackManager;)V", "")]
		public unsafe void SetCallbackManager(ICallbackManager callbackManager)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCallbackManager.(Lcom/facebook/CallbackManager;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
			}
		}

		private static Delegate GetShow_Ljava_lang_Object_Handler()
		{
			if ((object)cb_show_Ljava_lang_Object_ == null)
			{
				cb_show_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Show_Ljava_lang_Object_));
			}
			return cb_show_Ljava_lang_Object_;
		}

		private static void n_Show_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
		{
			FacebookDialogBase facebookDialogBase = Java.Lang.Object.GetObject<FacebookDialogBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object content = Java.Lang.Object.GetObject<Java.Lang.Object>(native_content, JniHandleOwnership.DoNotTransfer);
			facebookDialogBase.Show(content);
		}

		[Register("show", "(Ljava/lang/Object;)V", "GetShow_Ljava_lang_Object_Handler")]
		public unsafe virtual void Show(Java.Lang.Object content)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("show.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(content);
			}
		}

		private static Delegate GetShowImpl_Ljava_lang_Object_Ljava_lang_Object_Handler()
		{
			if ((object)cb_showImpl_Ljava_lang_Object_Ljava_lang_Object_ == null)
			{
				cb_showImpl_Ljava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ShowImpl_Ljava_lang_Object_Ljava_lang_Object_));
			}
			return cb_showImpl_Ljava_lang_Object_Ljava_lang_Object_;
		}

		private static void n_ShowImpl_Ljava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_content, IntPtr native_mode)
		{
			FacebookDialogBase facebookDialogBase = Java.Lang.Object.GetObject<FacebookDialogBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object content = Java.Lang.Object.GetObject<Java.Lang.Object>(native_content, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object mode = Java.Lang.Object.GetObject<Java.Lang.Object>(native_mode, JniHandleOwnership.DoNotTransfer);
			facebookDialogBase.ShowImpl(content, mode);
		}

		[Register("showImpl", "(Ljava/lang/Object;Ljava/lang/Object;)V", "GetShowImpl_Ljava_lang_Object_Ljava_lang_Object_Handler")]
		protected unsafe virtual void ShowImpl(Java.Lang.Object content, Java.Lang.Object mode)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("showImpl.(Ljava/lang/Object;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(content);
				GC.KeepAlive(mode);
			}
		}

		[Register("startActivityForResult", "(Landroid/content/Intent;I)V", "")]
		protected unsafe void StartActivityForResult(Intent intent, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("startActivityForResult.(Landroid/content/Intent;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/facebook/internal/FacebookDialogBase", DoNotGenerateAcw = true)]
	internal class FacebookDialogBaseInvoker : FacebookDialogBase, IFacebookDialog, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/FacebookDialogBase", typeof(FacebookDialogBaseInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public FacebookDialogBaseInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("createBaseAppCall", "()Lcom/facebook/internal/AppCall;", "GetCreateBaseAppCallHandler")]
		protected unsafe override AppCall CreateBaseAppCall()
		{
			return Java.Lang.Object.GetObject<AppCall>(_members.InstanceMethods.InvokeAbstractObjectMethod("createBaseAppCall.()Lcom/facebook/internal/AppCall;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getOrderedModeHandlers", "()Ljava/util/List;", "Get_OrderedModeHandlersHandler")]
		protected unsafe override System.Collections.IList _OrderedModeHandlers()
		{
			return JavaList.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getOrderedModeHandlers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("registerCallbackImpl", "(Lcom/facebook/internal/CallbackManagerImpl;Lcom/facebook/FacebookCallback;)V", "GetRegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_Handler")]
		protected unsafe override void RegisterCallbackImpl(CallbackManagerImpl callbackManager, IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(callbackManager?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("registerCallbackImpl.(Lcom/facebook/internal/CallbackManagerImpl;Lcom/facebook/FacebookCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/facebook/internal/FacebookDialogFragment", DoNotGenerateAcw = true)]
	public sealed class FacebookDialogFragment : AndroidX.Fragment.App.DialogFragment
	{
		[Register("com/facebook/internal/FacebookDialogFragment$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/FacebookDialogFragment$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/FacebookDialogFragment", typeof(FacebookDialogFragment));

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

		public unsafe Dialog InnerDialog
		{
			[Register("getInnerDialog", "()Landroid/app/Dialog;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getInnerDialog.()Landroid/app/Dialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setInnerDialog", "(Landroid/app/Dialog;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setInnerDialog.(Landroid/app/Dialog;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		internal FacebookDialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FacebookDialogFragment()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/internal/FacebookWebFallbackDialog", DoNotGenerateAcw = true)]
	public sealed class FacebookWebFallbackDialog : WebDialog
	{
		[Register("com/facebook/internal/FacebookWebFallbackDialog$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/FacebookWebFallbackDialog$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("newInstance", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/internal/FacebookWebFallbackDialog;", "")]
			public unsafe FacebookWebFallbackDialog NewInstance(Context context, string url, string expectedRedirectUrl)
			{
				IntPtr intPtr = JNIEnv.NewString(url);
				IntPtr intPtr2 = JNIEnv.NewString(expectedRedirectUrl);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<FacebookWebFallbackDialog>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("newInstance.(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/internal/FacebookWebFallbackDialog;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(context);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/FacebookWebFallbackDialog", typeof(FacebookWebFallbackDialog));

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

		internal FacebookWebFallbackDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe FacebookWebFallbackDialog(Context context, string url, string expectedRedirectUrl, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(url);
			IntPtr intPtr2 = JNIEnv.NewString(expectedRedirectUrl);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
				GC.KeepAlive(_constructor_marker);
			}
		}

		[Register("newInstance", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/internal/FacebookWebFallbackDialog;", "")]
		public unsafe static FacebookWebFallbackDialog NewInstance(Context context, string url, string expectedRedirectUrl)
		{
			IntPtr intPtr = JNIEnv.NewString(url);
			IntPtr intPtr2 = JNIEnv.NewString(expectedRedirectUrl);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<FacebookWebFallbackDialog>(_members.StaticMethods.InvokeObjectMethod("newInstance.(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/internal/FacebookWebFallbackDialog;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
			}
		}
	}
	[Register("com/facebook/internal/FragmentWrapper", DoNotGenerateAcw = true)]
	public sealed class FragmentWrapper : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/FragmentWrapper", typeof(FragmentWrapper));

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

		public unsafe Activity Activity
		{
			[Register("getActivity", "()Landroid/app/Activity;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Activity>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getActivity.()Landroid/app/Activity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Android.App.Fragment NativeFragment
		{
			[Register("getNativeFragment", "()Landroid/app/Fragment;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Android.App.Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNativeFragment.()Landroid/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe AndroidX.Fragment.App.Fragment SupportFragment
		{
			[Register("getSupportFragment", "()Landroidx/fragment/app/Fragment;", "")]
			get
			{
				return Java.Lang.Object.GetObject<AndroidX.Fragment.App.Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSupportFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal FragmentWrapper(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe FragmentWrapper(Android.App.Fragment fragment)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Fragment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register(".ctor", "(Landroidx/fragment/app/Fragment;)V", "")]
		public unsafe FragmentWrapper(AndroidX.Fragment.App.Fragment fragment)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/Fragment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register("startActivityForResult", "(Landroid/content/Intent;I)V", "")]
		public unsafe void StartActivityForResult(Intent intent, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("startActivityForResult.(Landroid/content/Intent;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/facebook/internal/DialogFeature$DefaultImpls", DoNotGenerateAcw = true)]
	public sealed class DialogFeatureDefaultImpls : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/DialogFeature$DefaultImpls", typeof(DialogFeatureDefaultImpls));

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

		internal DialogFeatureDefaultImpls(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/facebook/internal/DialogFeature", "", "Xamarin.Facebook.Internal.IDialogFeatureInvoker")]
	public interface IDialogFeature : IJavaObject, IDisposable, IJavaPeerable
	{
		string Action
		{
			[Register("getAction", "()Ljava/lang/String;", "GetGetActionHandler:Xamarin.Facebook.Internal.IDialogFeatureInvoker, Xamarin.Facebook.Common.Android")]
			get;
		}

		int MinVersion
		{
			[Register("getMinVersion", "()I", "GetGetMinVersionHandler:Xamarin.Facebook.Internal.IDialogFeatureInvoker, Xamarin.Facebook.Common.Android")]
			get;
		}

		[Register("name", "()Ljava/lang/String;", "GetNameHandler:Xamarin.Facebook.Internal.IDialogFeatureInvoker, Xamarin.Facebook.Common.Android")]
		string Name();
	}
	[Register("com/facebook/internal/DialogFeature", DoNotGenerateAcw = true)]
	internal class IDialogFeatureInvoker : Java.Lang.Object, IDialogFeature, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/DialogFeature", typeof(IDialogFeatureInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getAction;

		private IntPtr id_getAction;

		private static Delegate cb_getMinVersion;

		private IntPtr id_getMinVersion;

		private static Delegate cb_name;

		private IntPtr id_name;

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

		public string Action
		{
			get
			{
				if (id_getAction == IntPtr.Zero)
				{
					id_getAction = JNIEnv.GetMethodID(class_ref, "getAction", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getAction), JniHandleOwnership.TransferLocalRef);
			}
		}

		public int MinVersion
		{
			get
			{
				if (id_getMinVersion == IntPtr.Zero)
				{
					id_getMinVersion = JNIEnv.GetMethodID(class_ref, "getMinVersion", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_getMinVersion);
			}
		}

		public static IDialogFeature GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDialogFeature>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.DialogFeature'.");
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

		public IDialogFeatureInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetActionHandler()
		{
			if ((object)cb_getAction == null)
			{
				cb_getAction = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAction));
			}
			return cb_getAction;
		}

		private static IntPtr n_GetAction(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IDialogFeature>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Action);
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
			return Java.Lang.Object.GetObject<IDialogFeature>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinVersion;
		}

		private static Delegate GetNameHandler()
		{
			if ((object)cb_name == null)
			{
				cb_name = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Name));
			}
			return cb_name;
		}

		private static IntPtr n_Name(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IDialogFeature>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name());
		}

		public string Name()
		{
			if (id_name == IntPtr.Zero)
			{
				id_name = JNIEnv.GetMethodID(class_ref, "name", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_name), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/facebook/internal/InstagramCustomTab", DoNotGenerateAcw = true)]
	public sealed class InstagramCustomTab : CustomTab
	{
		[Register("com/facebook/internal/InstagramCustomTab$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/InstagramCustomTab$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("getURIForAction", "(Ljava/lang/String;Landroid/os/Bundle;)Landroid/net/Uri;", "")]
			public unsafe Android.Net.Uri GetURIForAction(string action, Bundle parameters)
			{
				IntPtr intPtr = JNIEnv.NewString(action);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getURIForAction.(Ljava/lang/String;Landroid/os/Bundle;)Landroid/net/Uri;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parameters);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/InstagramCustomTab", typeof(InstagramCustomTab));

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

		internal InstagramCustomTab(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Landroid/os/Bundle;)V", "")]
		public unsafe InstagramCustomTab(string action, Bundle parameters)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(action);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/os/Bundle;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(parameters);
			}
		}
	}
	[Register("com/facebook/internal/PlatformServiceClient", DoNotGenerateAcw = true)]
	public abstract class PlatformServiceClient : Java.Lang.Object, IServiceConnection, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/internal/PlatformServiceClient$CompletedListener", "", "Xamarin.Facebook.Internal.PlatformServiceClient/ICompletedListenerInvoker")]
		public interface ICompletedListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("completed", "(Landroid/os/Bundle;)V", "GetCompleted_Landroid_os_Bundle_Handler:Xamarin.Facebook.Internal.PlatformServiceClient/ICompletedListenerInvoker, Xamarin.Facebook.Common.Android")]
			void Completed(Bundle result);
		}

		[Register("com/facebook/internal/PlatformServiceClient$CompletedListener", DoNotGenerateAcw = true)]
		internal class ICompletedListenerInvoker : Java.Lang.Object, ICompletedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/PlatformServiceClient$CompletedListener", typeof(ICompletedListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_completed_Landroid_os_Bundle_;

			private IntPtr id_completed_Landroid_os_Bundle_;

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

			public static ICompletedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ICompletedListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.PlatformServiceClient.CompletedListener'.");
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

			public ICompletedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetCompleted_Landroid_os_Bundle_Handler()
			{
				if ((object)cb_completed_Landroid_os_Bundle_ == null)
				{
					cb_completed_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Completed_Landroid_os_Bundle_));
				}
				return cb_completed_Landroid_os_Bundle_;
			}

			private static void n_Completed_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
			{
				ICompletedListener completedListener = Java.Lang.Object.GetObject<ICompletedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Bundle result = Java.Lang.Object.GetObject<Bundle>(native_result, JniHandleOwnership.DoNotTransfer);
				completedListener.Completed(result);
			}

			public unsafe void Completed(Bundle result)
			{
				if (id_completed_Landroid_os_Bundle_ == IntPtr.Zero)
				{
					id_completed_Landroid_os_Bundle_ = JNIEnv.GetMethodID(class_ref, "completed", "(Landroid/os/Bundle;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(result?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_completed_Landroid_os_Bundle_, ptr);
			}
		}

		public class CompletedEventArgs : EventArgs
		{
			private Bundle result;

			public Bundle Result => result;

			public CompletedEventArgs(Bundle result)
			{
				this.result = result;
			}
		}

		[Register("mono/com/facebook/internal/PlatformServiceClient_CompletedListenerImplementor")]
		internal sealed class ICompletedListenerImplementor : Java.Lang.Object, ICompletedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<CompletedEventArgs> Handler;

			public ICompletedListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/facebook/internal/PlatformServiceClient_CompletedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void Completed(Bundle result)
			{
				Handler?.Invoke(sender, new CompletedEventArgs(result));
			}

			internal static bool __IsEmpty(ICompletedListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/PlatformServiceClient", typeof(PlatformServiceClient));

		private static Delegate cb_onServiceConnected_Landroid_content_ComponentName_Landroid_os_IBinder_;

		private static Delegate cb_onServiceDisconnected_Landroid_content_ComponentName_;

		private static Delegate cb_populateRequestBundle_Landroid_os_Bundle_;

		private WeakReference weak_implementor_SetCompletedListener;

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

		protected unsafe Context Context
		{
			[Register("getContext", "()Landroid/content/Context;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Nonce
		{
			[Register("getNonce", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNonce.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public event EventHandler<CompletedEventArgs> Completed
		{
			add
			{
				EventHelper.AddEventHandler<ICompletedListener, ICompletedListenerImplementor>(ref weak_implementor_SetCompletedListener, __CreateICompletedListenerImplementor, SetCompletedListener, delegate(ICompletedListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CompletedEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<ICompletedListener, ICompletedListenerImplementor>(ref weak_implementor_SetCompletedListener, ICompletedListenerImplementor.__IsEmpty, delegate
				{
					SetCompletedListener(null);
				}, delegate(ICompletedListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CompletedEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		protected PlatformServiceClient(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;IIILjava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe PlatformServiceClient(Context context, int requestMessage, int replyMessage, int protocolVersion, string applicationId, string nonce)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(applicationId);
			IntPtr intPtr2 = JNIEnv.NewString(nonce);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestMessage);
				ptr[2] = new JniArgumentValue(replyMessage);
				ptr[3] = new JniArgumentValue(protocolVersion);
				ptr[4] = new JniArgumentValue(intPtr);
				ptr[5] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;IIILjava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;IIILjava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
			}
		}

		[Register("cancel", "()V", "")]
		public unsafe void Cancel()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("cancel.()V", this, null);
		}

		[Register("handleMessage", "(Landroid/os/Message;)V", "")]
		protected unsafe void HandleMessage(Message message)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(message?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("handleMessage.(Landroid/os/Message;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(message);
			}
		}

		private static Delegate GetOnServiceConnected_Landroid_content_ComponentName_Landroid_os_IBinder_Handler()
		{
			if ((object)cb_onServiceConnected_Landroid_content_ComponentName_Landroid_os_IBinder_ == null)
			{
				cb_onServiceConnected_Landroid_content_ComponentName_Landroid_os_IBinder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnServiceConnected_Landroid_content_ComponentName_Landroid_os_IBinder_));
			}
			return cb_onServiceConnected_Landroid_content_ComponentName_Landroid_os_IBinder_;
		}

		private static void n_OnServiceConnected_Landroid_content_ComponentName_Landroid_os_IBinder_(IntPtr jnienv, IntPtr native__this, IntPtr native_name, IntPtr native_service)
		{
			PlatformServiceClient platformServiceClient = Java.Lang.Object.GetObject<PlatformServiceClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ComponentName name = Java.Lang.Object.GetObject<ComponentName>(native_name, JniHandleOwnership.DoNotTransfer);
			IBinder service = Java.Lang.Object.GetObject<IBinder>(native_service, JniHandleOwnership.DoNotTransfer);
			platformServiceClient.OnServiceConnected(name, service);
		}

		[Register("onServiceConnected", "(Landroid/content/ComponentName;Landroid/os/IBinder;)V", "GetOnServiceConnected_Landroid_content_ComponentName_Landroid_os_IBinder_Handler")]
		public unsafe virtual void OnServiceConnected(ComponentName name, IBinder service)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(name?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((service == null) ? IntPtr.Zero : ((Java.Lang.Object)service).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onServiceConnected.(Landroid/content/ComponentName;Landroid/os/IBinder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(name);
				GC.KeepAlive(service);
			}
		}

		private static Delegate GetOnServiceDisconnected_Landroid_content_ComponentName_Handler()
		{
			if ((object)cb_onServiceDisconnected_Landroid_content_ComponentName_ == null)
			{
				cb_onServiceDisconnected_Landroid_content_ComponentName_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnServiceDisconnected_Landroid_content_ComponentName_));
			}
			return cb_onServiceDisconnected_Landroid_content_ComponentName_;
		}

		private static void n_OnServiceDisconnected_Landroid_content_ComponentName_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
		{
			PlatformServiceClient platformServiceClient = Java.Lang.Object.GetObject<PlatformServiceClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ComponentName name = Java.Lang.Object.GetObject<ComponentName>(native_name, JniHandleOwnership.DoNotTransfer);
			platformServiceClient.OnServiceDisconnected(name);
		}

		[Register("onServiceDisconnected", "(Landroid/content/ComponentName;)V", "GetOnServiceDisconnected_Landroid_content_ComponentName_Handler")]
		public unsafe virtual void OnServiceDisconnected(ComponentName name)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(name?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onServiceDisconnected.(Landroid/content/ComponentName;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(name);
			}
		}

		private static Delegate GetPopulateRequestBundle_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_populateRequestBundle_Landroid_os_Bundle_ == null)
			{
				cb_populateRequestBundle_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PopulateRequestBundle_Landroid_os_Bundle_));
			}
			return cb_populateRequestBundle_Landroid_os_Bundle_;
		}

		private static void n_PopulateRequestBundle_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_data)
		{
			PlatformServiceClient platformServiceClient = Java.Lang.Object.GetObject<PlatformServiceClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle data = Java.Lang.Object.GetObject<Bundle>(native_data, JniHandleOwnership.DoNotTransfer);
			platformServiceClient.PopulateRequestBundle(data);
		}

		[Register("populateRequestBundle", "(Landroid/os/Bundle;)V", "GetPopulateRequestBundle_Landroid_os_Bundle_Handler")]
		protected abstract void PopulateRequestBundle(Bundle data);

		[Register("setCompletedListener", "(Lcom/facebook/internal/PlatformServiceClient$CompletedListener;)V", "")]
		public unsafe void SetCompletedListener(ICompletedListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCompletedListener.(Lcom/facebook/internal/PlatformServiceClient$CompletedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("start", "()Z", "")]
		public unsafe bool Start()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("start.()Z", this, null);
		}

		private ICompletedListenerImplementor __CreateICompletedListenerImplementor()
		{
			return new ICompletedListenerImplementor(this);
		}
	}
	[Register("com/facebook/internal/PlatformServiceClient", DoNotGenerateAcw = true)]
	internal class PlatformServiceClientInvoker : PlatformServiceClient
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/PlatformServiceClient", typeof(PlatformServiceClientInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public PlatformServiceClientInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("populateRequestBundle", "(Landroid/os/Bundle;)V", "GetPopulateRequestBundle_Landroid_os_Bundle_Handler")]
		protected unsafe override void PopulateRequestBundle(Bundle data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("populateRequestBundle.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}
	}
	[Register("com/facebook/internal/WebDialog", DoNotGenerateAcw = true)]
	public class WebDialog : Dialog
	{
		[Register("com/facebook/internal/WebDialog$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/WebDialog$Builder", typeof(Builder));

			private static Delegate cb_build;

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
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getApplicationId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe Context Context
			{
				[Register("getContext", "()Landroid/content/Context;", "")]
				get
				{
					return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe IOnCompleteListener Listener
			{
				[Register("getListener", "()Lcom/facebook/internal/WebDialog$OnCompleteListener;", "")]
				get
				{
					return Java.Lang.Object.GetObject<IOnCompleteListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getListener.()Lcom/facebook/internal/WebDialog$OnCompleteListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe Bundle Parameters
			{
				[Register("getParameters", "()Landroid/os/Bundle;", "")]
				get
				{
					return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getParameters.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe int Theme
			{
				[Register("getTheme", "()I", "")]
				get
				{
					return _members.InstanceMethods.InvokeNonvirtualInt32Method("getTheme.()I", this, null);
				}
			}

			protected Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)V", "")]
			public unsafe Builder(Context context, string action, Bundle parameters)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.NewString(action);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(context);
					GC.KeepAlive(parameters);
				}
			}

			[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)V", "")]
			public unsafe Builder(Context context, string applicationId, string action, Bundle parameters)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.NewString(applicationId);
				IntPtr intPtr2 = JNIEnv.NewString(action);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					ptr[3] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(context);
					GC.KeepAlive(parameters);
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

			[Register("build", "()Lcom/facebook/internal/WebDialog;", "GetBuildHandler")]
			public unsafe virtual WebDialog Build()
			{
				return Java.Lang.Object.GetObject<WebDialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/facebook/internal/WebDialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setOnCompleteListener", "(Lcom/facebook/internal/WebDialog$OnCompleteListener;)Lcom/facebook/internal/WebDialog$Builder;", "")]
			public unsafe Builder SetOnCompleteListener(IOnCompleteListener listener)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setOnCompleteListener.(Lcom/facebook/internal/WebDialog$OnCompleteListener;)Lcom/facebook/internal/WebDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(listener);
				}
			}

			[Register("setTheme", "(I)Lcom/facebook/internal/WebDialog$Builder;", "")]
			public unsafe Builder SetTheme(int theme)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(theme);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setTheme.(I)Lcom/facebook/internal/WebDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/facebook/internal/WebDialog$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/WebDialog$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("initDefaultTheme", "(Landroid/content/Context;)V", "")]
			protected unsafe void InitDefaultTheme(Context context)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("initDefaultTheme.(Landroid/content/Context;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(context);
				}
			}

			[Register("newInstance", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/internal/WebDialog$OnCompleteListener;)Lcom/facebook/internal/WebDialog;", "")]
			public unsafe WebDialog NewInstance(Context context, string action, Bundle parameters, int theme, IOnCompleteListener listener)
			{
				IntPtr intPtr = JNIEnv.NewString(action);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(theme);
					ptr[4] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
					return Java.Lang.Object.GetObject<WebDialog>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("newInstance.(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/internal/WebDialog$OnCompleteListener;)Lcom/facebook/internal/WebDialog;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(context);
					GC.KeepAlive(parameters);
					GC.KeepAlive(listener);
				}
			}

			[Register("newInstance", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/login/LoginTargetApp;Lcom/facebook/internal/WebDialog$OnCompleteListener;)Lcom/facebook/internal/WebDialog;", "")]
			public unsafe WebDialog NewInstance(Context context, string action, Bundle parameters, int theme, LoginTargetApp targetApp, IOnCompleteListener listener)
			{
				IntPtr intPtr = JNIEnv.NewString(action);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(theme);
					ptr[4] = new JniArgumentValue(targetApp?.Handle ?? IntPtr.Zero);
					ptr[5] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
					return Java.Lang.Object.GetObject<WebDialog>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("newInstance.(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/login/LoginTargetApp;Lcom/facebook/internal/WebDialog$OnCompleteListener;)Lcom/facebook/internal/WebDialog;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(context);
					GC.KeepAlive(parameters);
					GC.KeepAlive(targetApp);
					GC.KeepAlive(listener);
				}
			}
		}

		[Register("com/facebook/internal/WebDialog$InitCallback", "", "Xamarin.Facebook.Internal.WebDialog/IInitCallbackInvoker")]
		public interface IInitCallback : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onInit", "(Landroid/webkit/WebView;)V", "GetOnInit_Landroid_webkit_WebView_Handler:Xamarin.Facebook.Internal.WebDialog/IInitCallbackInvoker, Xamarin.Facebook.Common.Android")]
			void OnInit(WebView webView);
		}

		[Register("com/facebook/internal/WebDialog$InitCallback", DoNotGenerateAcw = true)]
		internal class IInitCallbackInvoker : Java.Lang.Object, IInitCallback, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/WebDialog$InitCallback", typeof(IInitCallbackInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onInit_Landroid_webkit_WebView_;

			private IntPtr id_onInit_Landroid_webkit_WebView_;

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

			public static IInitCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IInitCallback>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.WebDialog.InitCallback'.");
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

			public IInitCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnInit_Landroid_webkit_WebView_Handler()
			{
				if ((object)cb_onInit_Landroid_webkit_WebView_ == null)
				{
					cb_onInit_Landroid_webkit_WebView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnInit_Landroid_webkit_WebView_));
				}
				return cb_onInit_Landroid_webkit_WebView_;
			}

			private static void n_OnInit_Landroid_webkit_WebView_(IntPtr jnienv, IntPtr native__this, IntPtr native_webView)
			{
				IInitCallback initCallback = Java.Lang.Object.GetObject<IInitCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				WebView webView = Java.Lang.Object.GetObject<WebView>(native_webView, JniHandleOwnership.DoNotTransfer);
				initCallback.OnInit(webView);
			}

			public unsafe void OnInit(WebView webView)
			{
				if (id_onInit_Landroid_webkit_WebView_ == IntPtr.Zero)
				{
					id_onInit_Landroid_webkit_WebView_ = JNIEnv.GetMethodID(class_ref, "onInit", "(Landroid/webkit/WebView;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(webView?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onInit_Landroid_webkit_WebView_, ptr);
			}
		}

		[Register("com/facebook/internal/WebDialog$OnCompleteListener", "", "Xamarin.Facebook.Internal.WebDialog/IOnCompleteListenerInvoker")]
		public interface IOnCompleteListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onComplete", "(Landroid/os/Bundle;Lcom/facebook/FacebookException;)V", "GetOnComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_Handler:Xamarin.Facebook.Internal.WebDialog/IOnCompleteListenerInvoker, Xamarin.Facebook.Common.Android")]
			void OnComplete(Bundle values, FacebookException error);
		}

		[Register("com/facebook/internal/WebDialog$OnCompleteListener", DoNotGenerateAcw = true)]
		internal class IOnCompleteListenerInvoker : Java.Lang.Object, IOnCompleteListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/WebDialog$OnCompleteListener", typeof(IOnCompleteListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_;

			private IntPtr id_onComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_;

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

			public static IOnCompleteListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnCompleteListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.WebDialog.OnCompleteListener'.");
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

			public IOnCompleteListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_Handler()
			{
				if ((object)cb_onComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_ == null)
				{
					cb_onComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_));
				}
				return cb_onComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_;
			}

			private static void n_OnComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_(IntPtr jnienv, IntPtr native__this, IntPtr native_values, IntPtr native_error)
			{
				IOnCompleteListener onCompleteListener = Java.Lang.Object.GetObject<IOnCompleteListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Bundle values = Java.Lang.Object.GetObject<Bundle>(native_values, JniHandleOwnership.DoNotTransfer);
				FacebookException error = Java.Lang.Object.GetObject<FacebookException>(native_error, JniHandleOwnership.DoNotTransfer);
				onCompleteListener.OnComplete(values, error);
			}

			public unsafe void OnComplete(Bundle values, FacebookException error)
			{
				if (id_onComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_ == IntPtr.Zero)
				{
					id_onComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_ = JNIEnv.GetMethodID(class_ref, "onComplete", "(Landroid/os/Bundle;Lcom/facebook/FacebookException;)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(values?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(error?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onComplete_Landroid_os_Bundle_Lcom_facebook_FacebookException_, ptr);
			}
		}

		public class CompleteEventArgs : EventArgs
		{
			private Bundle values;

			private FacebookException error;

			public Bundle Values => values;

			public FacebookException Error => error;

			public CompleteEventArgs(Bundle values, FacebookException error)
			{
				this.values = values;
				this.error = error;
			}
		}

		[Register("mono/com/facebook/internal/WebDialog_OnCompleteListenerImplementor")]
		internal sealed class IOnCompleteListenerImplementor : Java.Lang.Object, IOnCompleteListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<CompleteEventArgs> Handler;

			public IOnCompleteListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/facebook/internal/WebDialog_OnCompleteListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnComplete(Bundle values, FacebookException error)
			{
				Handler?.Invoke(sender, new CompleteEventArgs(values, error));
			}

			internal static bool __IsEmpty(IOnCompleteListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/facebook/internal/WebDialog$WhenMappings", DoNotGenerateAcw = true)]
		public sealed class WhenMappings : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/WebDialog$WhenMappings", typeof(WhenMappings));

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

			internal WhenMappings(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("DISABLE_SSL_CHECK_FOR_TESTING")]
		public const bool DisableSslCheckForTesting = false;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/WebDialog", typeof(WebDialog));

		private static Delegate cb_parseResponseUri_Ljava_lang_String_;

		private WeakReference weak_implementor___SetOnCompleteListener;

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

		protected unsafe bool IsListenerCalled
		{
			[Register("isListenerCalled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isListenerCalled.()Z", this, null);
			}
		}

		protected unsafe bool IsPageFinished
		{
			[Register("isPageFinished", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isPageFinished.()Z", this, null);
			}
		}

		public unsafe IOnCompleteListener OnCompleteListener
		{
			[Register("getOnCompleteListener", "()Lcom/facebook/internal/WebDialog$OnCompleteListener;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IOnCompleteListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOnCompleteListener.()Lcom/facebook/internal/WebDialog$OnCompleteListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setOnCompleteListener", "(Lcom/facebook/internal/WebDialog$OnCompleteListener;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnCompleteListener.(Lcom/facebook/internal/WebDialog$OnCompleteListener;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe static int WebDialogTheme
		{
			[Register("getWebDialogTheme", "()I", "")]
			get
			{
				return _members.StaticMethods.InvokeInt32Method("getWebDialogTheme.()I", null);
			}
			[Register("setWebDialogTheme", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.StaticMethods.InvokeVoidMethod("setWebDialogTheme.(I)V", ptr);
			}
		}

		protected unsafe WebView WebView
		{
			[Register("getWebView", "()Landroid/webkit/WebView;", "")]
			get
			{
				return Java.Lang.Object.GetObject<WebView>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getWebView.()Landroid/webkit/WebView;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public event EventHandler<CompleteEventArgs> Complete
		{
			add
			{
				EventHelper.AddEventHandler(ref weak_implementor___SetOnCompleteListener, __CreateIOnCompleteListenerImplementor, delegate(IOnCompleteListener __v)
				{
					OnCompleteListener = __v;
				}, delegate(IOnCompleteListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CompleteEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnCompleteListener, IOnCompleteListenerImplementor>(ref weak_implementor___SetOnCompleteListener, IOnCompleteListenerImplementor.__IsEmpty, delegate
				{
					OnCompleteListener = null;
				}, delegate(IOnCompleteListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CompleteEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		protected WebDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;)V", "")]
		protected unsafe WebDialog(Context context, string url)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(url);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/login/LoginTargetApp;Lcom/facebook/internal/WebDialog$OnCompleteListener;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe WebDialog(Context context, string action, Bundle parameters, int theme, LoginTargetApp targetApp, IOnCompleteListener listener, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(action);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(theme);
				ptr[4] = new JniArgumentValue(targetApp?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				ptr[6] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/login/LoginTargetApp;Lcom/facebook/internal/WebDialog$OnCompleteListener;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/login/LoginTargetApp;Lcom/facebook/internal/WebDialog$OnCompleteListener;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(targetApp);
				GC.KeepAlive(listener);
				GC.KeepAlive(_constructor_marker);
			}
		}

		[Register("initDefaultTheme", "(Landroid/content/Context;)V", "")]
		protected unsafe static void InitDefaultTheme(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("initDefaultTheme.(Landroid/content/Context;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("newInstance", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/internal/WebDialog$OnCompleteListener;)Lcom/facebook/internal/WebDialog;", "")]
		public unsafe static WebDialog NewInstance(Context context, string action, Bundle parameters, int theme, IOnCompleteListener listener)
		{
			IntPtr intPtr = JNIEnv.NewString(action);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(theme);
				ptr[4] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<WebDialog>(_members.StaticMethods.InvokeObjectMethod("newInstance.(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/internal/WebDialog$OnCompleteListener;)Lcom/facebook/internal/WebDialog;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(listener);
			}
		}

		[Register("newInstance", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/login/LoginTargetApp;Lcom/facebook/internal/WebDialog$OnCompleteListener;)Lcom/facebook/internal/WebDialog;", "")]
		public unsafe static WebDialog NewInstance(Context context, string action, Bundle parameters, int theme, LoginTargetApp targetApp, IOnCompleteListener listener)
		{
			IntPtr intPtr = JNIEnv.NewString(action);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(theme);
				ptr[4] = new JniArgumentValue(targetApp?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<WebDialog>(_members.StaticMethods.InvokeObjectMethod("newInstance.(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;ILcom/facebook/login/LoginTargetApp;Lcom/facebook/internal/WebDialog$OnCompleteListener;)Lcom/facebook/internal/WebDialog;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(targetApp);
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetParseResponseUri_Ljava_lang_String_Handler()
		{
			if ((object)cb_parseResponseUri_Ljava_lang_String_ == null)
			{
				cb_parseResponseUri_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ParseResponseUri_Ljava_lang_String_));
			}
			return cb_parseResponseUri_Ljava_lang_String_;
		}

		private static IntPtr n_ParseResponseUri_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_urlString)
		{
			WebDialog webDialog = Java.Lang.Object.GetObject<WebDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string urlString = JNIEnv.GetString(native_urlString, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(webDialog.ParseResponseUri(urlString));
		}

		[Register("parseResponseUri", "(Ljava/lang/String;)Landroid/os/Bundle;", "GetParseResponseUri_Ljava_lang_String_Handler")]
		public unsafe virtual Bundle ParseResponseUri(string urlString)
		{
			IntPtr intPtr = JNIEnv.NewString(urlString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("parseResponseUri.(Ljava/lang/String;)Landroid/os/Bundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("resize", "()V", "")]
		public unsafe void Resize()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("resize.()V", this, null);
		}

		[Register("sendErrorToListener", "(Ljava/lang/Throwable;)V", "")]
		protected unsafe void SendErrorToListener(Throwable error)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(error?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("sendErrorToListener.(Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(error);
			}
		}

		[Register("sendSuccessToListener", "(Landroid/os/Bundle;)V", "")]
		protected unsafe void SendSuccessToListener(Bundle values)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(values?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("sendSuccessToListener.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(values);
			}
		}

		[Register("setInitCallback", "(Lcom/facebook/internal/WebDialog$InitCallback;)V", "")]
		public unsafe static void SetInitCallback(IInitCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setInitCallback.(Lcom/facebook/internal/WebDialog$InitCallback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		private IOnCompleteListenerImplementor __CreateIOnCompleteListenerImplementor()
		{
			return new IOnCompleteListenerImplementor(this);
		}
	}
}
namespace Xamarin.Facebook.DeviceRequests.Internal
{
	[Register("com/facebook/devicerequests/internal/DeviceRequestsHelper", DoNotGenerateAcw = true)]
	public class DeviceRequestsHelper : Java.Lang.Object
	{
		[Register("DEVICE_INFO_PARAM")]
		public const string DeviceInfoParam = "device_info";

		[Register("DEVICE_TARGET_USER_ID")]
		public const string DeviceTargetUserId = "target_user_id";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/devicerequests/internal/DeviceRequestsHelper", typeof(DeviceRequestsHelper));

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

		public unsafe static string DeviceInfo
		{
			[Register("getDeviceInfo", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getDeviceInfo.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static bool IsAvailable
		{
			[Register("isAvailable", "()Z", "")]
			get
			{
				return _members.StaticMethods.InvokeBooleanMethod("isAvailable.()Z", null);
			}
		}

		protected DeviceRequestsHelper(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DeviceRequestsHelper()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("cleanUpAdvertisementService", "(Ljava/lang/String;)V", "")]
		public unsafe static void CleanUpAdvertisementService(string userCode)
		{
			IntPtr intPtr = JNIEnv.NewString(userCode);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("cleanUpAdvertisementService.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("generateQRCode", "(Ljava/lang/String;)Landroid/graphics/Bitmap;", "")]
		public unsafe static Bitmap GenerateQRCode(string url)
		{
			IntPtr intPtr = JNIEnv.NewString(url);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Bitmap>(_members.StaticMethods.InvokeObjectMethod("generateQRCode.(Ljava/lang/String;)Landroid/graphics/Bitmap;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getDeviceInfo", "(Ljava/util/Map;)Ljava/lang/String;", "")]
		public unsafe static string GetDeviceInfo(IDictionary<string, string> deviceInfo)
		{
			IntPtr intPtr = JavaDictionary<string, string>.ToLocalJniHandle(deviceInfo);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getDeviceInfo.(Ljava/util/Map;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(deviceInfo);
			}
		}

		[Register("startAdvertisementService", "(Ljava/lang/String;)Z", "")]
		public unsafe static bool StartAdvertisementService(string userCode)
		{
			IntPtr intPtr = JNIEnv.NewString(userCode);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeBooleanMethod("startAdvertisementService.(Ljava/lang/String;)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
}
namespace Xamarin.Facebook.Common
{
	[Register("com/facebook/common/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("LIBRARY_PACKAGE_NAME")]
		public const string LibraryPackageName = "com.facebook.common";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/common/BuildConfig", typeof(BuildConfig));

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
	[Register("com/facebook/common/Common", DoNotGenerateAcw = true)]
	public sealed class Common : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/common/Common", typeof(Common));

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

		internal Common(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Common()
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
namespace Xamarin.Facebook.Share
{
	[Register("com/facebook/share/ShareBuilder", "", "Xamarin.Facebook.Share.IShareBuilderInvoker")]
	[JavaTypeParameters(new string[] { "M", "B extends com.facebook.share.ShareBuilder<M, B>" })]
	public interface IShareBuilder : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("build", "()Ljava/lang/Object;", "GetBuildHandler:Xamarin.Facebook.Share.IShareBuilderInvoker, Xamarin.Facebook.Common.Android")]
		Java.Lang.Object Build();
	}
	[Register("com/facebook/share/ShareBuilder", DoNotGenerateAcw = true)]
	internal class IShareBuilderInvoker : Java.Lang.Object, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/ShareBuilder", typeof(IShareBuilderInvoker));

		private IntPtr class_ref;

		private static Delegate cb_build;

		private IntPtr id_build;

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

		public static IShareBuilder GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IShareBuilder>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.share.ShareBuilder'.");
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

		public IShareBuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IShareBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		public Java.Lang.Object Build()
		{
			if (id_build == IntPtr.Zero)
			{
				id_build = JNIEnv.GetMethodID(class_ref, "build", "()Ljava/lang/Object;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_build), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/facebook/share/Sharer$Result", DoNotGenerateAcw = true)]
	public sealed class SharerResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/Sharer$Result", typeof(SharerResult));

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

		public unsafe string PostId
		{
			[Register("getPostId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPostId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal SharerResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe SharerResult(string postId)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(postId);
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
	}
	[Register("com/facebook/share/Sharer", "", "Xamarin.Facebook.Share.ISharerInvoker")]
	public interface ISharer : IJavaObject, IDisposable, IJavaPeerable
	{
		bool ShouldFailOnDataError
		{
			[Register("getShouldFailOnDataError", "()Z", "GetGetShouldFailOnDataErrorHandler:Xamarin.Facebook.Share.ISharerInvoker, Xamarin.Facebook.Common.Android")]
			get;
			[Register("setShouldFailOnDataError", "(Z)V", "GetSetShouldFailOnDataError_ZHandler:Xamarin.Facebook.Share.ISharerInvoker, Xamarin.Facebook.Common.Android")]
			set;
		}
	}
	[Register("com/facebook/share/Sharer", DoNotGenerateAcw = true)]
	internal class ISharerInvoker : Java.Lang.Object, ISharer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/Sharer", typeof(ISharerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getShouldFailOnDataError;

		private static Delegate cb_setShouldFailOnDataError_Z;

		private IntPtr id_getShouldFailOnDataError;

		private IntPtr id_setShouldFailOnDataError_Z;

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

		public unsafe bool ShouldFailOnDataError
		{
			get
			{
				if (id_getShouldFailOnDataError == IntPtr.Zero)
				{
					id_getShouldFailOnDataError = JNIEnv.GetMethodID(class_ref, "getShouldFailOnDataError", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_getShouldFailOnDataError);
			}
			set
			{
				if (id_setShouldFailOnDataError_Z == IntPtr.Zero)
				{
					id_setShouldFailOnDataError_Z = JNIEnv.GetMethodID(class_ref, "setShouldFailOnDataError", "(Z)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(value);
				JNIEnv.CallVoidMethod(base.Handle, id_setShouldFailOnDataError_Z, ptr);
			}
		}

		public static ISharer GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISharer>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.share.Sharer'.");
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

		public ISharerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetShouldFailOnDataErrorHandler()
		{
			if ((object)cb_getShouldFailOnDataError == null)
			{
				cb_getShouldFailOnDataError = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetShouldFailOnDataError));
			}
			return cb_getShouldFailOnDataError;
		}

		private static bool n_GetShouldFailOnDataError(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ISharer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldFailOnDataError;
		}

		private static Delegate GetSetShouldFailOnDataError_ZHandler()
		{
			if ((object)cb_setShouldFailOnDataError_Z == null)
			{
				cb_setShouldFailOnDataError_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetShouldFailOnDataError_Z));
			}
			return cb_setShouldFailOnDataError_Z;
		}

		private static void n_SetShouldFailOnDataError_Z(IntPtr jnienv, IntPtr native__this, bool shouldFailOnDataError)
		{
			Java.Lang.Object.GetObject<ISharer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldFailOnDataError = shouldFailOnDataError;
		}
	}
}
namespace Xamarin.Facebook.Share.Widget
{
	[Register("com/facebook/share/widget/ShareDialog", DoNotGenerateAcw = true)]
	public class ShareDialog : FacebookDialogBase, ISharer, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/widget/ShareDialog$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/ShareDialog$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("canShow", "(Ljava/lang/Class;)Z", "")]
			public unsafe bool CanShow(Class contentType)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
					return _members.InstanceMethods.InvokeAbstractBooleanMethod("canShow.(Ljava/lang/Class;)Z", this, ptr);
				}
				finally
				{
					GC.KeepAlive(contentType);
				}
			}

			[Register("show", "(Landroid/app/Activity;Lcom/facebook/share/model/ShareContent;)V", "")]
			public unsafe void Show(Activity activity, ShareContent shareContent)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("show.(Landroid/app/Activity;Lcom/facebook/share/model/ShareContent;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(activity);
					GC.KeepAlive(shareContent);
				}
			}

			[Register("show", "(Landroid/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", "")]
			public unsafe void Show(Android.App.Fragment fragment, ShareContent shareContent)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("show.(Landroid/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(fragment);
					GC.KeepAlive(shareContent);
				}
			}

			[Register("show", "(Landroidx/fragment/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", "")]
			public unsafe void Show(AndroidX.Fragment.App.Fragment fragment, ShareContent shareContent)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("show.(Landroidx/fragment/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(fragment);
					GC.KeepAlive(shareContent);
				}
			}
		}

		[Register("com/facebook/share/widget/ShareDialog$Mode", DoNotGenerateAcw = true)]
		public sealed class Mode : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/ShareDialog$Mode", typeof(Mode));

			[Register("AUTOMATIC")]
			public static Mode Automatic => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("AUTOMATIC.Lcom/facebook/share/widget/ShareDialog$Mode;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("FEED")]
			public static Mode Feed => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("FEED.Lcom/facebook/share/widget/ShareDialog$Mode;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NATIVE")]
			public static Mode Native => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("NATIVE.Lcom/facebook/share/widget/ShareDialog$Mode;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("WEB")]
			public static Mode Web => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("WEB.Lcom/facebook/share/widget/ShareDialog$Mode;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal Mode(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/share/widget/ShareDialog$Mode;", "")]
			public unsafe static Mode ValueOf(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Mode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/share/widget/ShareDialog$Mode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/facebook/share/widget/ShareDialog$Mode;", "")]
			public unsafe static Mode[] Values()
			{
				return (Mode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/share/widget/ShareDialog$Mode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Mode));
			}
		}

		[Register("com/facebook/share/widget/ShareDialog$WhenMappings", DoNotGenerateAcw = true)]
		public sealed class WhenMappings : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/ShareDialog$WhenMappings", typeof(WhenMappings));

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

			internal WhenMappings(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("WEB_SHARE_DIALOG")]
		public const string WebShareDialog = "share";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/ShareDialog", typeof(ShareDialog));

		private static Delegate cb_getOrderedModeHandlers;

		private static Delegate cb_getShouldFailOnDataError;

		private static Delegate cb_setShouldFailOnDataError_Z;

		private static Delegate cb_canShow_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_;

		private static Delegate cb_createBaseAppCall;

		private static Delegate cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_show_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_;

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

		protected unsafe virtual IList<FacebookDialogBase> OrderedModeHandlers
		{
			[Register("getOrderedModeHandlers", "()Ljava/util/List;", "GetGetOrderedModeHandlersHandler")]
			get
			{
				return JavaList<FacebookDialogBase>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrderedModeHandlers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool ShouldFailOnDataError
		{
			[Register("getShouldFailOnDataError", "()Z", "GetGetShouldFailOnDataErrorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getShouldFailOnDataError.()Z", this, null);
			}
			[Register("setShouldFailOnDataError", "(Z)V", "GetSetShouldFailOnDataError_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShouldFailOnDataError.(Z)V", this, ptr);
			}
		}

		protected override System.Collections.IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}

		protected ShareDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe ShareDialog(Activity activity)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[Register(".ctor", "(Landroid/app/Activity;I)V", "")]
		public unsafe ShareDialog(Activity activity, int requestCode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe ShareDialog(Android.App.Fragment fragment)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Fragment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register(".ctor", "(Landroid/app/Fragment;I)V", "")]
		public unsafe ShareDialog(Android.App.Fragment fragment, int requestCode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Fragment;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Fragment;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register(".ctor", "(Landroidx/fragment/app/Fragment;)V", "")]
		public unsafe ShareDialog(AndroidX.Fragment.App.Fragment fragment)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/Fragment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register(".ctor", "(Landroidx/fragment/app/Fragment;I)V", "")]
		public unsafe ShareDialog(AndroidX.Fragment.App.Fragment fragment, int requestCode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/Fragment;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/Fragment;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register(".ctor", "(Lcom/facebook/internal/FragmentWrapper;I)V", "")]
		public unsafe ShareDialog(FragmentWrapper fragmentWrapper, int requestCode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragmentWrapper?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/internal/FragmentWrapper;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/internal/FragmentWrapper;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragmentWrapper);
			}
		}

		private static Delegate GetGetOrderedModeHandlersHandler()
		{
			if ((object)cb_getOrderedModeHandlers == null)
			{
				cb_getOrderedModeHandlers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOrderedModeHandlers));
			}
			return cb_getOrderedModeHandlers;
		}

		private static IntPtr n_GetOrderedModeHandlers(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<FacebookDialogBase>.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OrderedModeHandlers);
		}

		private static Delegate GetGetShouldFailOnDataErrorHandler()
		{
			if ((object)cb_getShouldFailOnDataError == null)
			{
				cb_getShouldFailOnDataError = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetShouldFailOnDataError));
			}
			return cb_getShouldFailOnDataError;
		}

		private static bool n_GetShouldFailOnDataError(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ShareDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldFailOnDataError;
		}

		private static Delegate GetSetShouldFailOnDataError_ZHandler()
		{
			if ((object)cb_setShouldFailOnDataError_Z == null)
			{
				cb_setShouldFailOnDataError_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetShouldFailOnDataError_Z));
			}
			return cb_setShouldFailOnDataError_Z;
		}

		private static void n_SetShouldFailOnDataError_Z(IntPtr jnienv, IntPtr native__this, bool shouldFailOnDataError)
		{
			Java.Lang.Object.GetObject<ShareDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldFailOnDataError = shouldFailOnDataError;
		}

		private static Delegate GetCanShow_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_Handler()
		{
			if ((object)cb_canShow_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_ == null)
			{
				cb_canShow_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_CanShow_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_));
			}
			return cb_canShow_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_;
		}

		private static bool n_CanShow_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_(IntPtr jnienv, IntPtr native__this, IntPtr native_content, IntPtr native_mode)
		{
			ShareDialog shareDialog = Java.Lang.Object.GetObject<ShareDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShareContent content = Java.Lang.Object.GetObject<ShareContent>(native_content, JniHandleOwnership.DoNotTransfer);
			Mode mode = Java.Lang.Object.GetObject<Mode>(native_mode, JniHandleOwnership.DoNotTransfer);
			return shareDialog.CanShow(content, mode);
		}

		[Register("canShow", "(Lcom/facebook/share/model/ShareContent;Lcom/facebook/share/widget/ShareDialog$Mode;)Z", "GetCanShow_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_Handler")]
		public unsafe virtual bool CanShow(ShareContent content, Mode mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canShow.(Lcom/facebook/share/model/ShareContent;Lcom/facebook/share/widget/ShareDialog$Mode;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(mode);
			}
		}

		[Register("canShow", "(Ljava/lang/Class;)Z", "")]
		public unsafe static bool CanShow(Class contentType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("canShow.(Ljava/lang/Class;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(contentType);
			}
		}

		private static Delegate GetCreateBaseAppCallHandler()
		{
			if ((object)cb_createBaseAppCall == null)
			{
				cb_createBaseAppCall = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateBaseAppCall));
			}
			return cb_createBaseAppCall;
		}

		private static IntPtr n_CreateBaseAppCall(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateBaseAppCall());
		}

		[Register("createBaseAppCall", "()Lcom/facebook/internal/AppCall;", "GetCreateBaseAppCallHandler")]
		protected unsafe override AppCall CreateBaseAppCall()
		{
			return Java.Lang.Object.GetObject<AppCall>(_members.InstanceMethods.InvokeVirtualObjectMethod("createBaseAppCall.()Lcom/facebook/internal/AppCall;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_Handler()
		{
			if ((object)cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_ == null)
			{
				cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_));
			}
			return cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;
		}

		private static void n_RegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager, IntPtr native__callback)
		{
			ShareDialog shareDialog = Java.Lang.Object.GetObject<ShareDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CallbackManagerImpl callbackManager = Java.Lang.Object.GetObject<CallbackManagerImpl>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			shareDialog.RegisterCallbackImpl(callbackManager, callback);
		}

		[Register("registerCallbackImpl", "(Lcom/facebook/internal/CallbackManagerImpl;Lcom/facebook/FacebookCallback;)V", "GetRegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_Handler")]
		protected unsafe override void RegisterCallbackImpl(CallbackManagerImpl callbackManager, IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(callbackManager?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerCallbackImpl.(Lcom/facebook/internal/CallbackManagerImpl;Lcom/facebook/FacebookCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(callback);
			}
		}

		[Register("show", "(Landroid/app/Activity;Lcom/facebook/share/model/ShareContent;)V", "")]
		public unsafe static void Show(Activity activity, ShareContent shareContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroid/app/Activity;Lcom/facebook/share/model/ShareContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(shareContent);
			}
		}

		[Register("show", "(Landroid/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", "")]
		public unsafe static void Show(Android.App.Fragment fragment, ShareContent shareContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroid/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(shareContent);
			}
		}

		[Register("show", "(Landroidx/fragment/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", "")]
		public unsafe static void Show(AndroidX.Fragment.App.Fragment fragment, ShareContent shareContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroidx/fragment/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(shareContent);
			}
		}

		private static Delegate GetShow_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_Handler()
		{
			if ((object)cb_show_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_ == null)
			{
				cb_show_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Show_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_));
			}
			return cb_show_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_;
		}

		private static void n_Show_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_(IntPtr jnienv, IntPtr native__this, IntPtr native_content, IntPtr native_mode)
		{
			ShareDialog shareDialog = Java.Lang.Object.GetObject<ShareDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShareContent content = Java.Lang.Object.GetObject<ShareContent>(native_content, JniHandleOwnership.DoNotTransfer);
			Mode mode = Java.Lang.Object.GetObject<Mode>(native_mode, JniHandleOwnership.DoNotTransfer);
			shareDialog.Show(content, mode);
		}

		[Register("show", "(Lcom/facebook/share/model/ShareContent;Lcom/facebook/share/widget/ShareDialog$Mode;)V", "GetShow_Lcom_facebook_share_model_ShareContent_Lcom_facebook_share_widget_ShareDialog_Mode_Handler")]
		public unsafe virtual void Show(ShareContent content, Mode mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("show.(Lcom/facebook/share/model/ShareContent;Lcom/facebook/share/widget/ShareDialog$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(mode);
			}
		}
	}
}
namespace Xamarin.Facebook.Share.Model
{
	[Register("com/facebook/share/model/ShareContent", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "M extends com.facebook.share.model.ShareContent<M, B>", "B extends com.facebook.share.model.ShareContent.Builder<M, B>" })]
	public abstract class ShareContent : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/model/ShareContent$Builder", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "M extends com.facebook.share.model.ShareContent<M, B>", "B extends com.facebook.share.model.ShareContent.Builder<M, B>" })]
		public abstract class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static IntPtr id_build;

			private static IntPtr id_readFrom_Landroid_os_Parcel_;

			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareContent$Builder", typeof(Builder));

			private static Delegate cb_readFrom_Lcom_facebook_share_model_ShareContent_;

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

			[Register("build", "()Lcom/facebook/share/model/ShareContent;", "")]
			public Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
				{
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareContent;");
				}
				return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareContent$Builder;", "")]
			public Builder ReadFrom(Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
				{
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareContent$Builder;");
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
			}

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

			private static Delegate GetReadFrom_Lcom_facebook_share_model_ShareContent_Handler()
			{
				if ((object)cb_readFrom_Lcom_facebook_share_model_ShareContent_ == null)
				{
					cb_readFrom_Lcom_facebook_share_model_ShareContent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadFrom_Lcom_facebook_share_model_ShareContent_));
				}
				return cb_readFrom_Lcom_facebook_share_model_ShareContent_;
			}

			private static IntPtr n_ReadFrom_Lcom_facebook_share_model_ShareContent_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object content = Java.Lang.Object.GetObject<Java.Lang.Object>(native_content, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ReadFrom(content));
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareContent;)Lcom/facebook/share/model/ShareContent$Builder;", "GetReadFrom_Lcom_facebook_share_model_ShareContent_Handler")]
			public unsafe virtual Java.Lang.Object ReadFrom(Java.Lang.Object content)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(content);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("readFrom.(Lcom/facebook/share/model/ShareContent;)Lcom/facebook/share/model/ShareContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(content);
				}
			}

			[Register("setContentUrl", "(Landroid/net/Uri;)Lcom/facebook/share/model/ShareContent$Builder;", "")]
			public unsafe Java.Lang.Object SetContentUrl(Android.Net.Uri contentUrl)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(contentUrl?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setContentUrl.(Landroid/net/Uri;)Lcom/facebook/share/model/ShareContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(contentUrl);
				}
			}

			[Register("setPageId", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareContent$Builder;", "")]
			public unsafe Java.Lang.Object SetPageId(string pageId)
			{
				IntPtr intPtr = JNIEnv.NewString(pageId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setPageId.(Ljava/lang/String;)Lcom/facebook/share/model/ShareContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setPeopleIds", "(Ljava/util/List;)Lcom/facebook/share/model/ShareContent$Builder;", "")]
			public unsafe Java.Lang.Object SetPeopleIds(IList<string> peopleIds)
			{
				IntPtr intPtr = JavaList<string>.ToLocalJniHandle(peopleIds);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setPeopleIds.(Ljava/util/List;)Lcom/facebook/share/model/ShareContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(peopleIds);
				}
			}

			[Register("setPlaceId", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareContent$Builder;", "")]
			public unsafe Java.Lang.Object SetPlaceId(string placeId)
			{
				IntPtr intPtr = JNIEnv.NewString(placeId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setPlaceId.(Ljava/lang/String;)Lcom/facebook/share/model/ShareContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setRef", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareContent$Builder;", "")]
			public unsafe Java.Lang.Object SetRef(string @ref)
			{
				IntPtr intPtr = JNIEnv.NewString(@ref);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setRef.(Ljava/lang/String;)Lcom/facebook/share/model/ShareContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setShareHashtag", "(Lcom/facebook/share/model/ShareHashtag;)Lcom/facebook/share/model/ShareContent$Builder;", "")]
			public unsafe Java.Lang.Object SetShareHashtag(ShareHashtag shareHashtag)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(shareHashtag?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setShareHashtag.(Lcom/facebook/share/model/ShareHashtag;)Lcom/facebook/share/model/ShareContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(shareHashtag);
				}
			}
		}

		[Register("com/facebook/share/model/ShareContent$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareContent$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareContent", typeof(ShareContent));

		private static Delegate cb_describeContents;

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

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

		public unsafe Android.Net.Uri ContentUrl
		{
			[Register("getContentUrl", "()Landroid/net/Uri;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContentUrl.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string PageId
		{
			[Register("getPageId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPageId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> PeopleIds
		{
			[Register("getPeopleIds", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPeopleIds.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string PlaceId
		{
			[Register("getPlaceId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPlaceId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Ref
		{
			[Register("getRef", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getRef.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ShareHashtag ShareHashtag
		{
			[Register("getShareHashtag", "()Lcom/facebook/share/model/ShareHashtag;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ShareHashtag>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getShareHashtag.()Lcom/facebook/share/model/ShareHashtag;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ShareContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/os/Parcel;)V", "")]
		protected unsafe ShareContent(Parcel @in)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Parcel;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Parcel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@in);
			}
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareContent$Builder;)V", "")]
		protected unsafe ShareContent(Builder builder)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareContent$Builder;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareContent$Builder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
			}
		}

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ShareContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe virtual int DescribeContents()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
		}

		private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
		{
			if ((object)cb_writeToParcel_Landroid_os_Parcel_I == null)
			{
				cb_writeToParcel_Landroid_os_Parcel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I));
			}
			return cb_writeToParcel_Landroid_os_Parcel_I;
		}

		private static void n_WriteToParcel_Landroid_os_Parcel_I(IntPtr jnienv, IntPtr native__this, IntPtr native__out, int native_flags)
		{
			ShareContent shareContent = Java.Lang.Object.GetObject<ShareContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel parcel = Java.Lang.Object.GetObject<Parcel>(native__out, JniHandleOwnership.DoNotTransfer);
			shareContent.WriteToParcel(parcel, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe virtual void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/facebook/share/model/ShareMedia", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "M extends com.facebook.share.model.ShareMedia<M, B>", "B extends com.facebook.share.model.ShareMedia.Builder<M, B>" })]
	public abstract class ShareMedia : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/model/ShareMedia$Builder", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "M extends com.facebook.share.model.ShareMedia<M, B>", "B extends com.facebook.share.model.ShareMedia.Builder<M, B>" })]
		public abstract class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("com/facebook/share/model/ShareMedia$Builder$Companion", DoNotGenerateAcw = true)]
			public sealed class Companion : Java.Lang.Object
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMedia$Builder$Companion", typeof(Companion));

				internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				public override JniPeerMembers JniPeerMembers => _members;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				protected override System.Type ThresholdType => _members.ManagedPeerType;

				internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
					: base(javaReference, transfer)
				{
				}

				[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
				public unsafe Companion(DefaultConstructorMarker _constructor_marker)
					: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
				{
					if (base.Handle != IntPtr.Zero)
					{
						return;
					}
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
						SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
						_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(_constructor_marker);
					}
				}
			}

			private static IntPtr id_build;

			private static IntPtr id_readFrom_Landroid_os_Parcel_;

			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMedia$Builder", typeof(Builder));

			private static Delegate cb_readFrom_Lcom_facebook_share_model_ShareMedia_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override System.Type ThresholdType => _members.ManagedPeerType;

			[Register("build", "()Lcom/facebook/share/model/ShareMedia;", "")]
			public Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
				{
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareMedia;");
				}
				return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;", "")]
			public Builder ReadFrom(Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
				{
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;");
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
			}

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

			private static Delegate GetReadFrom_Lcom_facebook_share_model_ShareMedia_Handler()
			{
				if ((object)cb_readFrom_Lcom_facebook_share_model_ShareMedia_ == null)
				{
					cb_readFrom_Lcom_facebook_share_model_ShareMedia_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadFrom_Lcom_facebook_share_model_ShareMedia_));
				}
				return cb_readFrom_Lcom_facebook_share_model_ShareMedia_;
			}

			private static IntPtr n_ReadFrom_Lcom_facebook_share_model_ShareMedia_(IntPtr jnienv, IntPtr native__this, IntPtr native_model)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object model = Java.Lang.Object.GetObject<Java.Lang.Object>(native_model, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ReadFrom(model));
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareMedia;)Lcom/facebook/share/model/ShareMedia$Builder;", "GetReadFrom_Lcom_facebook_share_model_ShareMedia_Handler")]
			public unsafe virtual Java.Lang.Object ReadFrom(Java.Lang.Object model)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(model);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("readFrom.(Lcom/facebook/share/model/ShareMedia;)Lcom/facebook/share/model/ShareMedia$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(model);
				}
			}

			[Obsolete("deprecated")]
			[Register("setParameter", "(Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/share/model/ShareMedia$Builder;", "")]
			public unsafe Java.Lang.Object SetParameter(string key, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setParameter.(Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/share/model/ShareMedia$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Obsolete("deprecated")]
			[Register("setParameters", "(Landroid/os/Bundle;)Lcom/facebook/share/model/ShareMedia$Builder;", "")]
			public unsafe Java.Lang.Object SetParameters(Bundle parameters)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setParameters.(Landroid/os/Bundle;)Lcom/facebook/share/model/ShareMedia$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(parameters);
				}
			}
		}

		[Register("com/facebook/share/model/ShareMedia$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMedia$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override System.Type ThresholdType => _members.ManagedPeerType;

			public BuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		[Register("com/facebook/share/model/ShareMedia$Type", DoNotGenerateAcw = true)]
		public sealed class Type : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMedia$Type", typeof(Type));

			[Register("PHOTO")]
			public static Type Photo => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("PHOTO.Lcom/facebook/share/model/ShareMedia$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("VIDEO")]
			public static Type Video => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("VIDEO.Lcom/facebook/share/model/ShareMedia$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override System.Type ThresholdType => _members.ManagedPeerType;

			internal Type(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareMedia$Type;", "")]
			public unsafe static Type ValueOf(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Type>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/share/model/ShareMedia$Type;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/facebook/share/model/ShareMedia$Type;", "")]
			public unsafe static Type[] Values()
			{
				return (Type[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/share/model/ShareMedia$Type;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Type));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMedia", typeof(ShareMedia));

		private static Delegate cb_getMediaType;

		private static Delegate cb_describeContents;

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override System.Type ThresholdType => _members.ManagedPeerType;

		public abstract Type MediaType
		{
			[Register("getMediaType", "()Lcom/facebook/share/model/ShareMedia$Type;", "GetGetMediaTypeHandler")]
			get;
		}

		[Obsolete("deprecated")]
		public unsafe Bundle Parameters
		{
			[Register("getParameters", "()Landroid/os/Bundle;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getParameters.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ShareMedia(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareMedia$Builder;)V", "")]
		protected unsafe ShareMedia(Builder builder)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareMedia$Builder;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareMedia$Builder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
			}
		}

		private static Delegate GetGetMediaTypeHandler()
		{
			if ((object)cb_getMediaType == null)
			{
				cb_getMediaType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMediaType));
			}
			return cb_getMediaType;
		}

		private static IntPtr n_GetMediaType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareMedia>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MediaType);
		}

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ShareMedia>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe virtual int DescribeContents()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
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
			ShareMedia shareMedia = Java.Lang.Object.GetObject<ShareMedia>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			shareMedia.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe virtual void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
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
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/facebook/share/model/ShareOpenGraphValueContainer", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "P extends com.facebook.share.model.ShareOpenGraphValueContainer", "E extends com.facebook.share.model.ShareOpenGraphValueContainer.Builder" })]
	public abstract class ShareOpenGraphValueContainer : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/model/ShareOpenGraphValueContainer$Builder", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "M extends com.facebook.share.model.ShareOpenGraphValueContainer", "B extends com.facebook.share.model.ShareOpenGraphValueContainer.Builder<M, B>" })]
		public abstract class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static IntPtr id_build;

			private static IntPtr id_readFrom_Landroid_os_Parcel_;

			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphValueContainer$Builder", typeof(Builder));

			private static Delegate cb_putBoolean_Ljava_lang_String_Z;

			private static Delegate cb_putBooleanArray_Ljava_lang_String_arrayZ;

			private static Delegate cb_putDouble_Ljava_lang_String_D;

			private static Delegate cb_putDoubleArray_Ljava_lang_String_arrayD;

			private static Delegate cb_putInt_Ljava_lang_String_I;

			private static Delegate cb_putIntArray_Ljava_lang_String_arrayI;

			private static Delegate cb_putLong_Ljava_lang_String_J;

			private static Delegate cb_putLongArray_Ljava_lang_String_arrayJ;

			private static Delegate cb_putObject_Ljava_lang_String_Lcom_facebook_share_model_ShareOpenGraphObject_;

			private static Delegate cb_putObjectArrayList_Ljava_lang_String_Ljava_util_ArrayList_;

			private static Delegate cb_putPhoto_Ljava_lang_String_Lcom_facebook_share_model_SharePhoto_;

			private static Delegate cb_putPhotoArrayList_Ljava_lang_String_Ljava_util_ArrayList_;

			private static Delegate cb_putString_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_putStringArrayList_Ljava_lang_String_Ljava_util_ArrayList_;

			private static Delegate cb_readFrom_Lcom_facebook_share_model_ShareOpenGraphValueContainer_;

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

			[Register("build", "()Lcom/facebook/share/model/ShareOpenGraphValueContainer;", "")]
			public Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
				{
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareOpenGraphValueContainer;");
				}
				return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "")]
			public Builder ReadFrom(Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
				{
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;");
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
			}

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

			private static Delegate GetPutBoolean_Ljava_lang_String_ZHandler()
			{
				if ((object)cb_putBoolean_Ljava_lang_String_Z == null)
				{
					cb_putBoolean_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_PutBoolean_Ljava_lang_String_Z));
				}
				return cb_putBoolean_Ljava_lang_String_Z;
			}

			private static IntPtr n_PutBoolean_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_key, bool value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PutBoolean(key, value));
			}

			[Register("putBoolean", "(Ljava/lang/String;Z)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutBoolean_Ljava_lang_String_ZHandler")]
			public unsafe virtual Java.Lang.Object PutBoolean(string key, bool value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(value);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putBoolean.(Ljava/lang/String;Z)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPutBooleanArray_Ljava_lang_String_arrayZHandler()
			{
				if ((object)cb_putBooleanArray_Ljava_lang_String_arrayZ == null)
				{
					cb_putBooleanArray_Ljava_lang_String_arrayZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PutBooleanArray_Ljava_lang_String_arrayZ));
				}
				return cb_putBooleanArray_Ljava_lang_String_arrayZ;
			}

			private static IntPtr n_PutBooleanArray_Ljava_lang_String_arrayZ(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				bool[] array = (bool[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(bool));
				IntPtr result = JNIEnv.ToLocalJniHandle(builder.PutBooleanArray(key, array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_value);
				}
				return result;
			}

			[Register("putBooleanArray", "(Ljava/lang/String;[Z)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutBooleanArray_Ljava_lang_String_arrayZHandler")]
			public unsafe virtual Java.Lang.Object PutBooleanArray(string key, bool[] value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JNIEnv.NewArray(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putBooleanArray.(Ljava/lang/String;[Z)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (value != null)
					{
						JNIEnv.CopyArray(intPtr2, value);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
					GC.KeepAlive(value);
				}
			}

			private static Delegate GetPutDouble_Ljava_lang_String_DHandler()
			{
				if ((object)cb_putDouble_Ljava_lang_String_D == null)
				{
					cb_putDouble_Ljava_lang_String_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLD_L(n_PutDouble_Ljava_lang_String_D));
				}
				return cb_putDouble_Ljava_lang_String_D;
			}

			private static IntPtr n_PutDouble_Ljava_lang_String_D(IntPtr jnienv, IntPtr native__this, IntPtr native_key, double value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PutDouble(key, value));
			}

			[Register("putDouble", "(Ljava/lang/String;D)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutDouble_Ljava_lang_String_DHandler")]
			public unsafe virtual Java.Lang.Object PutDouble(string key, double value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(value);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putDouble.(Ljava/lang/String;D)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPutDoubleArray_Ljava_lang_String_arrayDHandler()
			{
				if ((object)cb_putDoubleArray_Ljava_lang_String_arrayD == null)
				{
					cb_putDoubleArray_Ljava_lang_String_arrayD = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PutDoubleArray_Ljava_lang_String_arrayD));
				}
				return cb_putDoubleArray_Ljava_lang_String_arrayD;
			}

			private static IntPtr n_PutDoubleArray_Ljava_lang_String_arrayD(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				double[] array = (double[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(double));
				IntPtr result = JNIEnv.ToLocalJniHandle(builder.PutDoubleArray(key, array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_value);
				}
				return result;
			}

			[Register("putDoubleArray", "(Ljava/lang/String;[D)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutDoubleArray_Ljava_lang_String_arrayDHandler")]
			public unsafe virtual Java.Lang.Object PutDoubleArray(string key, double[] value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JNIEnv.NewArray(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putDoubleArray.(Ljava/lang/String;[D)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (value != null)
					{
						JNIEnv.CopyArray(intPtr2, value);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
					GC.KeepAlive(value);
				}
			}

			private static Delegate GetPutInt_Ljava_lang_String_IHandler()
			{
				if ((object)cb_putInt_Ljava_lang_String_I == null)
				{
					cb_putInt_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_PutInt_Ljava_lang_String_I));
				}
				return cb_putInt_Ljava_lang_String_I;
			}

			private static IntPtr n_PutInt_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_key, int value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PutInt(key, value));
			}

			[Register("putInt", "(Ljava/lang/String;I)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutInt_Ljava_lang_String_IHandler")]
			public unsafe virtual Java.Lang.Object PutInt(string key, int value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(value);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putInt.(Ljava/lang/String;I)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPutIntArray_Ljava_lang_String_arrayIHandler()
			{
				if ((object)cb_putIntArray_Ljava_lang_String_arrayI == null)
				{
					cb_putIntArray_Ljava_lang_String_arrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PutIntArray_Ljava_lang_String_arrayI));
				}
				return cb_putIntArray_Ljava_lang_String_arrayI;
			}

			private static IntPtr n_PutIntArray_Ljava_lang_String_arrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				int[] array = (int[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(int));
				IntPtr result = JNIEnv.ToLocalJniHandle(builder.PutIntArray(key, array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_value);
				}
				return result;
			}

			[Register("putIntArray", "(Ljava/lang/String;[I)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutIntArray_Ljava_lang_String_arrayIHandler")]
			public unsafe virtual Java.Lang.Object PutIntArray(string key, int[] value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JNIEnv.NewArray(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putIntArray.(Ljava/lang/String;[I)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (value != null)
					{
						JNIEnv.CopyArray(intPtr2, value);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
					GC.KeepAlive(value);
				}
			}

			private static Delegate GetPutLong_Ljava_lang_String_JHandler()
			{
				if ((object)cb_putLong_Ljava_lang_String_J == null)
				{
					cb_putLong_Ljava_lang_String_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_L(n_PutLong_Ljava_lang_String_J));
				}
				return cb_putLong_Ljava_lang_String_J;
			}

			private static IntPtr n_PutLong_Ljava_lang_String_J(IntPtr jnienv, IntPtr native__this, IntPtr native_key, long value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PutLong(key, value));
			}

			[Register("putLong", "(Ljava/lang/String;J)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutLong_Ljava_lang_String_JHandler")]
			public unsafe virtual Java.Lang.Object PutLong(string key, long value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(value);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putLong.(Ljava/lang/String;J)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetPutLongArray_Ljava_lang_String_arrayJHandler()
			{
				if ((object)cb_putLongArray_Ljava_lang_String_arrayJ == null)
				{
					cb_putLongArray_Ljava_lang_String_arrayJ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PutLongArray_Ljava_lang_String_arrayJ));
				}
				return cb_putLongArray_Ljava_lang_String_arrayJ;
			}

			private static IntPtr n_PutLongArray_Ljava_lang_String_arrayJ(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				long[] array = (long[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(long));
				IntPtr result = JNIEnv.ToLocalJniHandle(builder.PutLongArray(key, array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_value);
				}
				return result;
			}

			[Register("putLongArray", "(Ljava/lang/String;[J)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutLongArray_Ljava_lang_String_arrayJHandler")]
			public unsafe virtual Java.Lang.Object PutLongArray(string key, long[] value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JNIEnv.NewArray(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putLongArray.(Ljava/lang/String;[J)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (value != null)
					{
						JNIEnv.CopyArray(intPtr2, value);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
					GC.KeepAlive(value);
				}
			}

			private static Delegate GetPutObject_Ljava_lang_String_Lcom_facebook_share_model_ShareOpenGraphObject_Handler()
			{
				if ((object)cb_putObject_Ljava_lang_String_Lcom_facebook_share_model_ShareOpenGraphObject_ == null)
				{
					cb_putObject_Ljava_lang_String_Lcom_facebook_share_model_ShareOpenGraphObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PutObject_Ljava_lang_String_Lcom_facebook_share_model_ShareOpenGraphObject_));
				}
				return cb_putObject_Ljava_lang_String_Lcom_facebook_share_model_ShareOpenGraphObject_;
			}

			private static IntPtr n_PutObject_Ljava_lang_String_Lcom_facebook_share_model_ShareOpenGraphObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				ShareOpenGraphObject value = Java.Lang.Object.GetObject<ShareOpenGraphObject>(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PutObject(key, value));
			}

			[Register("putObject", "(Ljava/lang/String;Lcom/facebook/share/model/ShareOpenGraphObject;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutObject_Ljava_lang_String_Lcom_facebook_share_model_ShareOpenGraphObject_Handler")]
			public unsafe virtual Java.Lang.Object PutObject(string key, ShareOpenGraphObject value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putObject.(Ljava/lang/String;Lcom/facebook/share/model/ShareOpenGraphObject;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}

			private static Delegate GetPutObjectArrayList_Ljava_lang_String_Ljava_util_ArrayList_Handler()
			{
				if ((object)cb_putObjectArrayList_Ljava_lang_String_Ljava_util_ArrayList_ == null)
				{
					cb_putObjectArrayList_Ljava_lang_String_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PutObjectArrayList_Ljava_lang_String_Ljava_util_ArrayList_));
				}
				return cb_putObjectArrayList_Ljava_lang_String_Ljava_util_ArrayList_;
			}

			private static IntPtr n_PutObjectArrayList_Ljava_lang_String_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				IList<ShareOpenGraphObject> value = JavaList<ShareOpenGraphObject>.FromJniHandle(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PutObjectArrayList(key, value));
			}

			[Register("putObjectArrayList", "(Ljava/lang/String;Ljava/util/ArrayList;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutObjectArrayList_Ljava_lang_String_Ljava_util_ArrayList_Handler")]
			public unsafe virtual Java.Lang.Object PutObjectArrayList(string key, IList<ShareOpenGraphObject> value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JavaList<ShareOpenGraphObject>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putObjectArrayList.(Ljava/lang/String;Ljava/util/ArrayList;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(value);
				}
			}

			private static Delegate GetPutPhoto_Ljava_lang_String_Lcom_facebook_share_model_SharePhoto_Handler()
			{
				if ((object)cb_putPhoto_Ljava_lang_String_Lcom_facebook_share_model_SharePhoto_ == null)
				{
					cb_putPhoto_Ljava_lang_String_Lcom_facebook_share_model_SharePhoto_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PutPhoto_Ljava_lang_String_Lcom_facebook_share_model_SharePhoto_));
				}
				return cb_putPhoto_Ljava_lang_String_Lcom_facebook_share_model_SharePhoto_;
			}

			private static IntPtr n_PutPhoto_Ljava_lang_String_Lcom_facebook_share_model_SharePhoto_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				SharePhoto value = Java.Lang.Object.GetObject<SharePhoto>(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PutPhoto(key, value));
			}

			[Register("putPhoto", "(Ljava/lang/String;Lcom/facebook/share/model/SharePhoto;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutPhoto_Ljava_lang_String_Lcom_facebook_share_model_SharePhoto_Handler")]
			public unsafe virtual Java.Lang.Object PutPhoto(string key, SharePhoto value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putPhoto.(Ljava/lang/String;Lcom/facebook/share/model/SharePhoto;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}

			private static Delegate GetPutPhotoArrayList_Ljava_lang_String_Ljava_util_ArrayList_Handler()
			{
				if ((object)cb_putPhotoArrayList_Ljava_lang_String_Ljava_util_ArrayList_ == null)
				{
					cb_putPhotoArrayList_Ljava_lang_String_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PutPhotoArrayList_Ljava_lang_String_Ljava_util_ArrayList_));
				}
				return cb_putPhotoArrayList_Ljava_lang_String_Ljava_util_ArrayList_;
			}

			private static IntPtr n_PutPhotoArrayList_Ljava_lang_String_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				IList<SharePhoto> value = JavaList<SharePhoto>.FromJniHandle(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PutPhotoArrayList(key, value));
			}

			[Register("putPhotoArrayList", "(Ljava/lang/String;Ljava/util/ArrayList;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutPhotoArrayList_Ljava_lang_String_Ljava_util_ArrayList_Handler")]
			public unsafe virtual Java.Lang.Object PutPhotoArrayList(string key, IList<SharePhoto> value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JavaList<SharePhoto>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putPhotoArrayList.(Ljava/lang/String;Ljava/util/ArrayList;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(value);
				}
			}

			private static Delegate GetPutString_Ljava_lang_String_Ljava_lang_String_Handler()
			{
				if ((object)cb_putString_Ljava_lang_String_Ljava_lang_String_ == null)
				{
					cb_putString_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PutString_Ljava_lang_String_Ljava_lang_String_));
				}
				return cb_putString_Ljava_lang_String_Ljava_lang_String_;
			}

			private static IntPtr n_PutString_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PutString(key, value));
			}

			[Register("putString", "(Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutString_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe virtual Java.Lang.Object PutString(string key, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putString.(Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			private static Delegate GetPutStringArrayList_Ljava_lang_String_Ljava_util_ArrayList_Handler()
			{
				if ((object)cb_putStringArrayList_Ljava_lang_String_Ljava_util_ArrayList_ == null)
				{
					cb_putStringArrayList_Ljava_lang_String_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_PutStringArrayList_Ljava_lang_String_Ljava_util_ArrayList_));
				}
				return cb_putStringArrayList_Ljava_lang_String_Ljava_util_ArrayList_;
			}

			private static IntPtr n_PutStringArrayList_Ljava_lang_String_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
				IList<string> value = JavaList<string>.FromJniHandle(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PutStringArrayList(key, value));
			}

			[Register("putStringArrayList", "(Ljava/lang/String;Ljava/util/ArrayList;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetPutStringArrayList_Ljava_lang_String_Ljava_util_ArrayList_Handler")]
			public unsafe virtual Java.Lang.Object PutStringArrayList(string key, IList<string> value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JavaList<string>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putStringArrayList.(Ljava/lang/String;Ljava/util/ArrayList;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(value);
				}
			}

			private static Delegate GetReadFrom_Lcom_facebook_share_model_ShareOpenGraphValueContainer_Handler()
			{
				if ((object)cb_readFrom_Lcom_facebook_share_model_ShareOpenGraphValueContainer_ == null)
				{
					cb_readFrom_Lcom_facebook_share_model_ShareOpenGraphValueContainer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadFrom_Lcom_facebook_share_model_ShareOpenGraphValueContainer_));
				}
				return cb_readFrom_Lcom_facebook_share_model_ShareOpenGraphValueContainer_;
			}

			private static IntPtr n_ReadFrom_Lcom_facebook_share_model_ShareOpenGraphValueContainer_(IntPtr jnienv, IntPtr native__this, IntPtr native_model)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object model = Java.Lang.Object.GetObject<Java.Lang.Object>(native_model, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ReadFrom(model));
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareOpenGraphValueContainer;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "GetReadFrom_Lcom_facebook_share_model_ShareOpenGraphValueContainer_Handler")]
			public unsafe virtual Java.Lang.Object ReadFrom(Java.Lang.Object model)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(model);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("readFrom.(Lcom/facebook/share/model/ShareOpenGraphValueContainer;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(model);
				}
			}
		}

		[Register("com/facebook/share/model/ShareOpenGraphValueContainer$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphValueContainer$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphValueContainer", typeof(ShareOpenGraphValueContainer));

		private static Delegate cb_getBundle;

		private static Delegate cb_describeContents;

		private static Delegate cb_get_Ljava_lang_String_;

		private static Delegate cb_getBoolean_Ljava_lang_String_Z;

		private static Delegate cb_getBooleanArray_Ljava_lang_String_;

		private static Delegate cb_getDouble_Ljava_lang_String_D;

		private static Delegate cb_getDoubleArray_Ljava_lang_String_;

		private static Delegate cb_getInt_Ljava_lang_String_I;

		private static Delegate cb_getIntArray_Ljava_lang_String_;

		private static Delegate cb_getLong_Ljava_lang_String_J;

		private static Delegate cb_getLongArray_Ljava_lang_String_;

		private static Delegate cb_getObject_Ljava_lang_String_;

		private static Delegate cb_getObjectArrayList_Ljava_lang_String_;

		private static Delegate cb_getPhoto_Ljava_lang_String_;

		private static Delegate cb_getPhotoArrayList_Ljava_lang_String_;

		private static Delegate cb_getString_Ljava_lang_String_;

		private static Delegate cb_getStringArrayList_Ljava_lang_String_;

		private static Delegate cb_keySet;

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

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

		public unsafe virtual Bundle Bundle
		{
			[Register("getBundle", "()Landroid/os/Bundle;", "GetGetBundleHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBundle.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ShareOpenGraphValueContainer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;)V", "")]
		protected unsafe ShareOpenGraphValueContainer(Builder builder)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
			}
		}

		private static Delegate GetGetBundleHandler()
		{
			if ((object)cb_getBundle == null)
			{
				cb_getBundle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBundle));
			}
			return cb_getBundle;
		}

		private static IntPtr n_GetBundle(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Bundle);
		}

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe virtual int DescribeContents()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
		}

		private static Delegate GetGet_Ljava_lang_String_Handler()
		{
			if ((object)cb_get_Ljava_lang_String_ == null)
			{
				cb_get_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Ljava_lang_String_));
			}
			return cb_get_Ljava_lang_String_;
		}

		private static IntPtr n_Get_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(shareOpenGraphValueContainer.Get(key));
		}

		[Register("get", "(Ljava/lang/String;)Ljava/lang/Object;", "GetGet_Ljava_lang_String_Handler")]
		public unsafe virtual Java.Lang.Object Get(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetBoolean_Ljava_lang_String_ZHandler()
		{
			if ((object)cb_getBoolean_Ljava_lang_String_Z == null)
			{
				cb_getBoolean_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_Z(n_GetBoolean_Ljava_lang_String_Z));
			}
			return cb_getBoolean_Ljava_lang_String_Z;
		}

		private static bool n_GetBoolean_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_key, bool defaultValue)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return shareOpenGraphValueContainer.GetBoolean(key, defaultValue);
		}

		[Register("getBoolean", "(Ljava/lang/String;Z)Z", "GetGetBoolean_Ljava_lang_String_ZHandler")]
		public unsafe virtual bool GetBoolean(string key, bool defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getBoolean.(Ljava/lang/String;Z)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetBooleanArray_Ljava_lang_String_Handler()
		{
			if ((object)cb_getBooleanArray_Ljava_lang_String_ == null)
			{
				cb_getBooleanArray_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetBooleanArray_Ljava_lang_String_));
			}
			return cb_getBooleanArray_Ljava_lang_String_;
		}

		private static IntPtr n_GetBooleanArray_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(shareOpenGraphValueContainer.GetBooleanArray(key));
		}

		[Register("getBooleanArray", "(Ljava/lang/String;)[Z", "GetGetBooleanArray_Ljava_lang_String_Handler")]
		public unsafe virtual bool[] GetBooleanArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getBooleanArray.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetDouble_Ljava_lang_String_DHandler()
		{
			if ((object)cb_getDouble_Ljava_lang_String_D == null)
			{
				cb_getDouble_Ljava_lang_String_D = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLD_D(n_GetDouble_Ljava_lang_String_D));
			}
			return cb_getDouble_Ljava_lang_String_D;
		}

		private static double n_GetDouble_Ljava_lang_String_D(IntPtr jnienv, IntPtr native__this, IntPtr native_key, double defaultValue)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return shareOpenGraphValueContainer.GetDouble(key, defaultValue);
		}

		[Register("getDouble", "(Ljava/lang/String;D)D", "GetGetDouble_Ljava_lang_String_DHandler")]
		public unsafe virtual double GetDouble(string key, double defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeVirtualDoubleMethod("getDouble.(Ljava/lang/String;D)D", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetDoubleArray_Ljava_lang_String_Handler()
		{
			if ((object)cb_getDoubleArray_Ljava_lang_String_ == null)
			{
				cb_getDoubleArray_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetDoubleArray_Ljava_lang_String_));
			}
			return cb_getDoubleArray_Ljava_lang_String_;
		}

		private static IntPtr n_GetDoubleArray_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(shareOpenGraphValueContainer.GetDoubleArray(key));
		}

		[Register("getDoubleArray", "(Ljava/lang/String;)[D", "GetGetDoubleArray_Ljava_lang_String_Handler")]
		public unsafe virtual double[] GetDoubleArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (double[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getDoubleArray.(Ljava/lang/String;)[D", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(double));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetInt_Ljava_lang_String_IHandler()
		{
			if ((object)cb_getInt_Ljava_lang_String_I == null)
			{
				cb_getInt_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_I(n_GetInt_Ljava_lang_String_I));
			}
			return cb_getInt_Ljava_lang_String_I;
		}

		private static int n_GetInt_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_key, int defaultValue)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return shareOpenGraphValueContainer.GetInt(key, defaultValue);
		}

		[Register("getInt", "(Ljava/lang/String;I)I", "GetGetInt_Ljava_lang_String_IHandler")]
		public unsafe virtual int GetInt(string key, int defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getInt.(Ljava/lang/String;I)I", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetIntArray_Ljava_lang_String_Handler()
		{
			if ((object)cb_getIntArray_Ljava_lang_String_ == null)
			{
				cb_getIntArray_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetIntArray_Ljava_lang_String_));
			}
			return cb_getIntArray_Ljava_lang_String_;
		}

		private static IntPtr n_GetIntArray_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(shareOpenGraphValueContainer.GetIntArray(key));
		}

		[Register("getIntArray", "(Ljava/lang/String;)[I", "GetGetIntArray_Ljava_lang_String_Handler")]
		public unsafe virtual int[] GetIntArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getIntArray.(Ljava/lang/String;)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetLong_Ljava_lang_String_JHandler()
		{
			if ((object)cb_getLong_Ljava_lang_String_J == null)
			{
				cb_getLong_Ljava_lang_String_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_J(n_GetLong_Ljava_lang_String_J));
			}
			return cb_getLong_Ljava_lang_String_J;
		}

		private static long n_GetLong_Ljava_lang_String_J(IntPtr jnienv, IntPtr native__this, IntPtr native_key, long defaultValue)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return shareOpenGraphValueContainer.GetLong(key, defaultValue);
		}

		[Register("getLong", "(Ljava/lang/String;J)J", "GetGetLong_Ljava_lang_String_JHandler")]
		public unsafe virtual long GetLong(string key, long defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeVirtualInt64Method("getLong.(Ljava/lang/String;J)J", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetLongArray_Ljava_lang_String_Handler()
		{
			if ((object)cb_getLongArray_Ljava_lang_String_ == null)
			{
				cb_getLongArray_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetLongArray_Ljava_lang_String_));
			}
			return cb_getLongArray_Ljava_lang_String_;
		}

		private static IntPtr n_GetLongArray_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(shareOpenGraphValueContainer.GetLongArray(key));
		}

		[Register("getLongArray", "(Ljava/lang/String;)[J", "GetGetLongArray_Ljava_lang_String_Handler")]
		public unsafe virtual long[] GetLongArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (long[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getLongArray.(Ljava/lang/String;)[J", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(long));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetObject_Ljava_lang_String_Handler()
		{
			if ((object)cb_getObject_Ljava_lang_String_ == null)
			{
				cb_getObject_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetObject_Ljava_lang_String_));
			}
			return cb_getObject_Ljava_lang_String_;
		}

		private static IntPtr n_GetObject_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(shareOpenGraphValueContainer.GetObject(key));
		}

		[Register("getObject", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareOpenGraphObject;", "GetGetObject_Ljava_lang_String_Handler")]
		public unsafe virtual ShareOpenGraphObject GetObject(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ShareOpenGraphObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("getObject.(Ljava/lang/String;)Lcom/facebook/share/model/ShareOpenGraphObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetObjectArrayList_Ljava_lang_String_Handler()
		{
			if ((object)cb_getObjectArrayList_Ljava_lang_String_ == null)
			{
				cb_getObjectArrayList_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetObjectArrayList_Ljava_lang_String_));
			}
			return cb_getObjectArrayList_Ljava_lang_String_;
		}

		private static IntPtr n_GetObjectArrayList_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JavaList<ShareOpenGraphObject>.ToLocalJniHandle(shareOpenGraphValueContainer.GetObjectArrayList(key));
		}

		[Register("getObjectArrayList", "(Ljava/lang/String;)Ljava/util/ArrayList;", "GetGetObjectArrayList_Ljava_lang_String_Handler")]
		public unsafe virtual IList<ShareOpenGraphObject> GetObjectArrayList(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JavaList<ShareOpenGraphObject>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getObjectArrayList.(Ljava/lang/String;)Ljava/util/ArrayList;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetPhoto_Ljava_lang_String_Handler()
		{
			if ((object)cb_getPhoto_Ljava_lang_String_ == null)
			{
				cb_getPhoto_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetPhoto_Ljava_lang_String_));
			}
			return cb_getPhoto_Ljava_lang_String_;
		}

		private static IntPtr n_GetPhoto_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(shareOpenGraphValueContainer.GetPhoto(key));
		}

		[Register("getPhoto", "(Ljava/lang/String;)Lcom/facebook/share/model/SharePhoto;", "GetGetPhoto_Ljava_lang_String_Handler")]
		public unsafe virtual SharePhoto GetPhoto(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SharePhoto>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPhoto.(Ljava/lang/String;)Lcom/facebook/share/model/SharePhoto;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetPhotoArrayList_Ljava_lang_String_Handler()
		{
			if ((object)cb_getPhotoArrayList_Ljava_lang_String_ == null)
			{
				cb_getPhotoArrayList_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetPhotoArrayList_Ljava_lang_String_));
			}
			return cb_getPhotoArrayList_Ljava_lang_String_;
		}

		private static IntPtr n_GetPhotoArrayList_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JavaList<SharePhoto>.ToLocalJniHandle(shareOpenGraphValueContainer.GetPhotoArrayList(key));
		}

		[Register("getPhotoArrayList", "(Ljava/lang/String;)Ljava/util/ArrayList;", "GetGetPhotoArrayList_Ljava_lang_String_Handler")]
		public unsafe virtual IList<SharePhoto> GetPhotoArrayList(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JavaList<SharePhoto>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getPhotoArrayList.(Ljava/lang/String;)Ljava/util/ArrayList;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetString_Ljava_lang_String_Handler()
		{
			if ((object)cb_getString_Ljava_lang_String_ == null)
			{
				cb_getString_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetString_Ljava_lang_String_));
			}
			return cb_getString_Ljava_lang_String_;
		}

		private static IntPtr n_GetString_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(shareOpenGraphValueContainer.GetString(key));
		}

		[Register("getString", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetString_Ljava_lang_String_Handler")]
		public unsafe virtual string GetString(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getString.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetStringArrayList_Ljava_lang_String_Handler()
		{
			if ((object)cb_getStringArrayList_Ljava_lang_String_ == null)
			{
				cb_getStringArrayList_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetStringArrayList_Ljava_lang_String_));
			}
			return cb_getStringArrayList_Ljava_lang_String_;
		}

		private static IntPtr n_GetStringArrayList_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(shareOpenGraphValueContainer.GetStringArrayList(key));
		}

		[Register("getStringArrayList", "(Ljava/lang/String;)Ljava/util/ArrayList;", "GetGetStringArrayList_Ljava_lang_String_Handler")]
		public unsafe virtual IList<string> GetStringArrayList(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getStringArrayList.(Ljava/lang/String;)Ljava/util/ArrayList;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetKeySetHandler()
		{
			if ((object)cb_keySet == null)
			{
				cb_keySet = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_KeySet));
			}
			return cb_keySet;
		}

		private static IntPtr n_KeySet(IntPtr jnienv, IntPtr native__this)
		{
			return JavaSet<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).KeySet());
		}

		[Register("keySet", "()Ljava/util/Set;", "GetKeySetHandler")]
		public unsafe virtual ICollection<string> KeySet()
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("keySet.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
		{
			if ((object)cb_writeToParcel_Landroid_os_Parcel_I == null)
			{
				cb_writeToParcel_Landroid_os_Parcel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I));
			}
			return cb_writeToParcel_Landroid_os_Parcel_I;
		}

		private static void n_WriteToParcel_Landroid_os_Parcel_I(IntPtr jnienv, IntPtr native__this, IntPtr native__out, int native_flags)
		{
			ShareOpenGraphValueContainer shareOpenGraphValueContainer = Java.Lang.Object.GetObject<ShareOpenGraphValueContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel parcel = Java.Lang.Object.GetObject<Parcel>(native__out, JniHandleOwnership.DoNotTransfer);
			shareOpenGraphValueContainer.WriteToParcel(parcel, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe virtual void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/facebook/share/model/ShareMessengerActionButton", DoNotGenerateAcw = true)]
	public abstract class ShareMessengerActionButton : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/model/ShareMessengerActionButton$Builder", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "M extends com.facebook.share.model.ShareMessengerActionButton", "B extends com.facebook.share.model.ShareMessengerActionButton.Builder<M, B>" })]
		public abstract class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static IntPtr id_build;

			private static IntPtr id_readFrom_Landroid_os_Parcel_;

			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMessengerActionButton$Builder", typeof(Builder));

			private static Delegate cb_readFrom_Lcom_facebook_share_model_ShareMessengerActionButton_;

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

			[Register("build", "()Lcom/facebook/share/model/ShareMessengerActionButton;", "")]
			public Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
				{
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareMessengerActionButton;");
				}
				return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMessengerActionButton$Builder;", "")]
			public Builder ReadFrom(Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
				{
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;");
				}
				return Java.Lang.Object.GetObject<Builder>(JNIEnv.CallObjectMethod(base.Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
			}

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

			private static Delegate GetReadFrom_Lcom_facebook_share_model_ShareMessengerActionButton_Handler()
			{
				if ((object)cb_readFrom_Lcom_facebook_share_model_ShareMessengerActionButton_ == null)
				{
					cb_readFrom_Lcom_facebook_share_model_ShareMessengerActionButton_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadFrom_Lcom_facebook_share_model_ShareMessengerActionButton_));
				}
				return cb_readFrom_Lcom_facebook_share_model_ShareMessengerActionButton_;
			}

			private static IntPtr n_ReadFrom_Lcom_facebook_share_model_ShareMessengerActionButton_(IntPtr jnienv, IntPtr native__this, IntPtr native_model)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object model = Java.Lang.Object.GetObject<Java.Lang.Object>(native_model, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ReadFrom(model));
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareMessengerActionButton;)Lcom/facebook/share/model/ShareMessengerActionButton$Builder;", "GetReadFrom_Lcom_facebook_share_model_ShareMessengerActionButton_Handler")]
			public unsafe virtual Java.Lang.Object ReadFrom(Java.Lang.Object model)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(model);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("readFrom.(Lcom/facebook/share/model/ShareMessengerActionButton;)Lcom/facebook/share/model/ShareMessengerActionButton$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(model);
				}
			}

			[Register("setTitle", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareMessengerActionButton$Builder;", "")]
			public unsafe Java.Lang.Object SetTitle(string title)
			{
				IntPtr intPtr = JNIEnv.NewString(title);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setTitle.(Ljava/lang/String;)Lcom/facebook/share/model/ShareMessengerActionButton$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("com/facebook/share/model/ShareMessengerActionButton$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMessengerActionButton$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMessengerActionButton", typeof(ShareMessengerActionButton));

		private static Delegate cb_describeContents;

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

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

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ShareMessengerActionButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareMessengerActionButton$Builder;)V", "")]
		protected unsafe ShareMessengerActionButton(Builder builder)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareMessengerActionButton$Builder;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareMessengerActionButton$Builder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
			}
		}

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ShareMessengerActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		[Register("describeContents", "()I", "GetDescribeContentsHandler")]
		public unsafe virtual int DescribeContents()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("describeContents.()I", this, null);
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
			ShareMessengerActionButton shareMessengerActionButton = Java.Lang.Object.GetObject<ShareMessengerActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			shareMessengerActionButton.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe virtual void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
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
	[Register("com/facebook/share/model/AppGroupCreationContent", DoNotGenerateAcw = true)]
	public sealed class AppGroupCreationContent : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy", DoNotGenerateAcw = true)]
		public sealed class AppGroupPrivacy : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy", typeof(AppGroupPrivacy));

			[Register("Closed")]
			public static AppGroupPrivacy Closed => Java.Lang.Object.GetObject<AppGroupPrivacy>(_members.StaticFields.GetObjectValue("Closed.Lcom/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("Open")]
			public static AppGroupPrivacy Open => Java.Lang.Object.GetObject<AppGroupPrivacy>(_members.StaticFields.GetObjectValue("Open.Lcom/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal AppGroupPrivacy(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy;", "")]
			public unsafe static AppGroupPrivacy ValueOf(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<AppGroupPrivacy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy;", "")]
			public unsafe static AppGroupPrivacy[] Values()
			{
				return (AppGroupPrivacy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AppGroupPrivacy));
			}
		}

		[Register("com/facebook/share/model/AppGroupCreationContent$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/AppGroupCreationContent$Builder", typeof(Builder));

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

			[Register("build", "()Lcom/facebook/share/model/AppGroupCreationContent;", "")]
			public unsafe Java.Lang.Object Build()
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/AppGroupCreationContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/AppGroupCreationContent;)Lcom/facebook/share/model/AppGroupCreationContent$Builder;", "")]
			public unsafe Builder ReadFrom(AppGroupCreationContent content)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/AppGroupCreationContent;)Lcom/facebook/share/model/AppGroupCreationContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(content);
				}
			}

			[Register("setAppGroupPrivacy", "(Lcom/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy;)Lcom/facebook/share/model/AppGroupCreationContent$Builder;", "")]
			public unsafe Builder SetAppGroupPrivacy(AppGroupPrivacy privacy)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(privacy?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setAppGroupPrivacy.(Lcom/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy;)Lcom/facebook/share/model/AppGroupCreationContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(privacy);
				}
			}

			[Register("setDescription", "(Ljava/lang/String;)Lcom/facebook/share/model/AppGroupCreationContent$Builder;", "")]
			public unsafe Builder SetDescription(string description)
			{
				IntPtr intPtr = JNIEnv.NewString(description);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setDescription.(Ljava/lang/String;)Lcom/facebook/share/model/AppGroupCreationContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setName", "(Ljava/lang/String;)Lcom/facebook/share/model/AppGroupCreationContent$Builder;", "")]
			public unsafe Builder SetName(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setName.(Ljava/lang/String;)Lcom/facebook/share/model/AppGroupCreationContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			Java.Lang.Object IShareModelBuilder.ReadFrom(Java.Lang.Object model)
			{
				return JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom(JavaObjectExtensions.JavaCast<AppGroupCreationContent>(model)));
			}
		}

		[Register("com/facebook/share/model/AppGroupCreationContent$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/AppGroupCreationContent$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/AppGroupCreationContent", typeof(AppGroupCreationContent));

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

		public unsafe string Description
		{
			[Register("getDescription", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Name
		{
			[Register("getName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal AppGroupCreationContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/AppGroupCreationContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe AppGroupCreationContent(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/AppGroupCreationContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/AppGroupCreationContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}

		[Register("describeContents", "()I", "")]
		public unsafe int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}

		[Register("getAppGroupPrivacy", "()Lcom/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy;", "")]
		public unsafe AppGroupPrivacy GetAppGroupPrivacy()
		{
			return Java.Lang.Object.GetObject<AppGroupPrivacy>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAppGroupPrivacy.()Lcom/facebook/share/model/AppGroupCreationContent$AppGroupPrivacy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/facebook/share/model/CameraEffectArguments", DoNotGenerateAcw = true)]
	public sealed class CameraEffectArguments : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/model/CameraEffectArguments$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/CameraEffectArguments$Builder", typeof(Builder));

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

			[Register("build", "()Lcom/facebook/share/model/CameraEffectArguments;", "")]
			public unsafe Java.Lang.Object Build()
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/CameraEffectArguments;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("putArgument", "(Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/share/model/CameraEffectArguments$Builder;", "")]
			public unsafe Builder PutArgument(string key, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("putArgument.(Ljava/lang/String;Ljava/lang/String;)Lcom/facebook/share/model/CameraEffectArguments$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("putArgument", "(Ljava/lang/String;[Ljava/lang/String;)Lcom/facebook/share/model/CameraEffectArguments$Builder;", "")]
			public unsafe Builder PutArgument(string key, string[] arrayValue)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JNIEnv.NewArray(arrayValue);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("putArgument.(Ljava/lang/String;[Ljava/lang/String;)Lcom/facebook/share/model/CameraEffectArguments$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (arrayValue != null)
					{
						JNIEnv.CopyArray(intPtr2, arrayValue);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
					GC.KeepAlive(arrayValue);
				}
			}

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/CameraEffectArguments$Builder;", "")]
			public unsafe Builder ReadFrom(Parcel parcel)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("readFrom.(Landroid/os/Parcel;)Lcom/facebook/share/model/CameraEffectArguments$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(parcel);
				}
			}

			[Register("readFrom", "(Lcom/facebook/share/model/CameraEffectArguments;)Lcom/facebook/share/model/CameraEffectArguments$Builder;", "")]
			public unsafe Builder ReadFrom(CameraEffectArguments model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/CameraEffectArguments;)Lcom/facebook/share/model/CameraEffectArguments$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			Java.Lang.Object IShareModelBuilder.ReadFrom(Java.Lang.Object model)
			{
				return JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom(JavaObjectExtensions.JavaCast<CameraEffectArguments>(model)));
			}
		}

		[Register("com/facebook/share/model/CameraEffectArguments$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/CameraEffectArguments$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/CameraEffectArguments", typeof(CameraEffectArguments));

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

		internal CameraEffectArguments(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/CameraEffectArguments$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe CameraEffectArguments(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/CameraEffectArguments$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/CameraEffectArguments$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}

		[Register("describeContents", "()I", "")]
		public unsafe int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}

		[Register("get", "(Ljava/lang/String;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object Get(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("get.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getString", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string GetString(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getString.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getStringArray", "(Ljava/lang/String;)[Ljava/lang/String;", "")]
		public unsafe string[] GetStringArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getStringArray.(Ljava/lang/String;)[Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("keySet", "()Ljava/util/Set;", "")]
		public unsafe ICollection<string> KeySet()
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("keySet.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/facebook/share/model/CameraEffectTextures", DoNotGenerateAcw = true)]
	public sealed class CameraEffectTextures : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/model/CameraEffectTextures$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/CameraEffectTextures$Builder", typeof(Builder));

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

			[Register("build", "()Lcom/facebook/share/model/CameraEffectTextures;", "")]
			public unsafe Java.Lang.Object Build()
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/CameraEffectTextures;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("putTexture", "(Ljava/lang/String;Landroid/graphics/Bitmap;)Lcom/facebook/share/model/CameraEffectTextures$Builder;", "")]
			public unsafe Builder PutTexture(string key, Bitmap texture)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(texture?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("putTexture.(Ljava/lang/String;Landroid/graphics/Bitmap;)Lcom/facebook/share/model/CameraEffectTextures$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(texture);
				}
			}

			[Register("putTexture", "(Ljava/lang/String;Landroid/net/Uri;)Lcom/facebook/share/model/CameraEffectTextures$Builder;", "")]
			public unsafe Builder PutTexture(string key, Android.Net.Uri textureUrl)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(textureUrl?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("putTexture.(Ljava/lang/String;Landroid/net/Uri;)Lcom/facebook/share/model/CameraEffectTextures$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(textureUrl);
				}
			}

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/CameraEffectTextures$Builder;", "")]
			public unsafe Builder ReadFrom(Parcel parcel)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("readFrom.(Landroid/os/Parcel;)Lcom/facebook/share/model/CameraEffectTextures$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(parcel);
				}
			}

			[Register("readFrom", "(Lcom/facebook/share/model/CameraEffectTextures;)Lcom/facebook/share/model/CameraEffectTextures$Builder;", "")]
			public unsafe Builder ReadFrom(CameraEffectTextures model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/CameraEffectTextures;)Lcom/facebook/share/model/CameraEffectTextures$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			Java.Lang.Object IShareModelBuilder.ReadFrom(Java.Lang.Object model)
			{
				return JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom(JavaObjectExtensions.JavaCast<CameraEffectTextures>(model)));
			}
		}

		[Register("com/facebook/share/model/CameraEffectTextures$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/CameraEffectTextures$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/CameraEffectTextures", typeof(CameraEffectTextures));

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

		internal CameraEffectTextures(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/CameraEffectTextures$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe CameraEffectTextures(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/CameraEffectTextures$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/CameraEffectTextures$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}

		[Register("describeContents", "()I", "")]
		public unsafe int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}

		[Register("get", "(Ljava/lang/String;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object Get(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("get.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getTextureBitmap", "(Ljava/lang/String;)Landroid/graphics/Bitmap;", "")]
		public unsafe Bitmap GetTextureBitmap(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTextureBitmap.(Ljava/lang/String;)Landroid/graphics/Bitmap;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getTextureUri", "(Ljava/lang/String;)Landroid/net/Uri;", "")]
		public unsafe Android.Net.Uri GetTextureUri(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTextureUri.(Ljava/lang/String;)Landroid/net/Uri;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("keySet", "()Ljava/util/Set;", "")]
		public unsafe ICollection<string> KeySet()
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("keySet.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/facebook/share/model/GameRequestContent", DoNotGenerateAcw = true)]
	public sealed class GameRequestContent : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/model/GameRequestContent$ActionType", DoNotGenerateAcw = true)]
		public sealed class ActionType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/GameRequestContent$ActionType", typeof(ActionType));

			[Register("ASKFOR")]
			public static ActionType Askfor => Java.Lang.Object.GetObject<ActionType>(_members.StaticFields.GetObjectValue("ASKFOR.Lcom/facebook/share/model/GameRequestContent$ActionType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("INVITE")]
			public static ActionType Invite => Java.Lang.Object.GetObject<ActionType>(_members.StaticFields.GetObjectValue("INVITE.Lcom/facebook/share/model/GameRequestContent$ActionType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("SEND")]
			public static ActionType Send => Java.Lang.Object.GetObject<ActionType>(_members.StaticFields.GetObjectValue("SEND.Lcom/facebook/share/model/GameRequestContent$ActionType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("TURN")]
			public static ActionType Turn => Java.Lang.Object.GetObject<ActionType>(_members.StaticFields.GetObjectValue("TURN.Lcom/facebook/share/model/GameRequestContent$ActionType;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal ActionType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$ActionType;", "")]
			public unsafe static ActionType ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ActionType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$ActionType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/facebook/share/model/GameRequestContent$ActionType;", "")]
			public unsafe static ActionType[] Values()
			{
				return (ActionType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/share/model/GameRequestContent$ActionType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ActionType));
			}
		}

		[Register("com/facebook/share/model/GameRequestContent$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/GameRequestContent$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_readFrom_Lcom_facebook_share_model_GameRequestContent_;

			private static Delegate cb_setActionType_Lcom_facebook_share_model_GameRequestContent_ActionType_;

			private static Delegate cb_setCta_Ljava_lang_String_;

			private static Delegate cb_setData_Ljava_lang_String_;

			private static Delegate cb_setFilters_Lcom_facebook_share_model_GameRequestContent_Filters_;

			private static Delegate cb_setMessage_Ljava_lang_String_;

			private static Delegate cb_setObjectId_Ljava_lang_String_;

			private static Delegate cb_setRecipients_Ljava_util_List_;

			private static Delegate cb_setSuggestions_Ljava_util_List_;

			private static Delegate cb_setTitle_Ljava_lang_String_;

			private static Delegate cb_setTo_Ljava_lang_String_;

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

			[Register("build", "()Lcom/facebook/share/model/GameRequestContent;", "GetBuildHandler")]
			public unsafe virtual Java.Lang.Object Build()
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/facebook/share/model/GameRequestContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetReadFrom_Lcom_facebook_share_model_GameRequestContent_Handler()
			{
				if ((object)cb_readFrom_Lcom_facebook_share_model_GameRequestContent_ == null)
				{
					cb_readFrom_Lcom_facebook_share_model_GameRequestContent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadFrom_Lcom_facebook_share_model_GameRequestContent_));
				}
				return cb_readFrom_Lcom_facebook_share_model_GameRequestContent_;
			}

			private static IntPtr n_ReadFrom_Lcom_facebook_share_model_GameRequestContent_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				GameRequestContent content = Java.Lang.Object.GetObject<GameRequestContent>(native_content, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ReadFrom(content));
			}

			[Register("readFrom", "(Lcom/facebook/share/model/GameRequestContent;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetReadFrom_Lcom_facebook_share_model_GameRequestContent_Handler")]
			public unsafe virtual Builder ReadFrom(GameRequestContent content)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("readFrom.(Lcom/facebook/share/model/GameRequestContent;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(content);
				}
			}

			private static Delegate GetSetActionType_Lcom_facebook_share_model_GameRequestContent_ActionType_Handler()
			{
				if ((object)cb_setActionType_Lcom_facebook_share_model_GameRequestContent_ActionType_ == null)
				{
					cb_setActionType_Lcom_facebook_share_model_GameRequestContent_ActionType_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetActionType_Lcom_facebook_share_model_GameRequestContent_ActionType_));
				}
				return cb_setActionType_Lcom_facebook_share_model_GameRequestContent_ActionType_;
			}

			private static IntPtr n_SetActionType_Lcom_facebook_share_model_GameRequestContent_ActionType_(IntPtr jnienv, IntPtr native__this, IntPtr native_actionType)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionType actionType = Java.Lang.Object.GetObject<ActionType>(native_actionType, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetActionType(actionType));
			}

			[Register("setActionType", "(Lcom/facebook/share/model/GameRequestContent$ActionType;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetSetActionType_Lcom_facebook_share_model_GameRequestContent_ActionType_Handler")]
			public unsafe virtual Builder SetActionType(ActionType actionType)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(actionType?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setActionType.(Lcom/facebook/share/model/GameRequestContent$ActionType;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(actionType);
				}
			}

			private static Delegate GetSetCta_Ljava_lang_String_Handler()
			{
				if ((object)cb_setCta_Ljava_lang_String_ == null)
				{
					cb_setCta_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetCta_Ljava_lang_String_));
				}
				return cb_setCta_Ljava_lang_String_;
			}

			private static IntPtr n_SetCta_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_cta)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string cta = JNIEnv.GetString(native_cta, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetCta(cta));
			}

			[Register("setCta", "(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetSetCta_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetCta(string cta)
			{
				IntPtr intPtr = JNIEnv.NewString(cta);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCta.(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetData_Ljava_lang_String_Handler()
			{
				if ((object)cb_setData_Ljava_lang_String_ == null)
				{
					cb_setData_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetData_Ljava_lang_String_));
				}
				return cb_setData_Ljava_lang_String_;
			}

			private static IntPtr n_SetData_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_data)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string data = JNIEnv.GetString(native_data, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetData(data));
			}

			[Register("setData", "(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetSetData_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetData(string data)
			{
				IntPtr intPtr = JNIEnv.NewString(data);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setData.(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetFilters_Lcom_facebook_share_model_GameRequestContent_Filters_Handler()
			{
				if ((object)cb_setFilters_Lcom_facebook_share_model_GameRequestContent_Filters_ == null)
				{
					cb_setFilters_Lcom_facebook_share_model_GameRequestContent_Filters_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetFilters_Lcom_facebook_share_model_GameRequestContent_Filters_));
				}
				return cb_setFilters_Lcom_facebook_share_model_GameRequestContent_Filters_;
			}

			private static IntPtr n_SetFilters_Lcom_facebook_share_model_GameRequestContent_Filters_(IntPtr jnienv, IntPtr native__this, IntPtr native_filters)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Filters filters = Java.Lang.Object.GetObject<Filters>(native_filters, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetFilters(filters));
			}

			[Register("setFilters", "(Lcom/facebook/share/model/GameRequestContent$Filters;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetSetFilters_Lcom_facebook_share_model_GameRequestContent_Filters_Handler")]
			public unsafe virtual Builder SetFilters(Filters filters)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(filters?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFilters.(Lcom/facebook/share/model/GameRequestContent$Filters;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(filters);
				}
			}

			private static Delegate GetSetMessage_Ljava_lang_String_Handler()
			{
				if ((object)cb_setMessage_Ljava_lang_String_ == null)
				{
					cb_setMessage_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetMessage_Ljava_lang_String_));
				}
				return cb_setMessage_Ljava_lang_String_;
			}

			private static IntPtr n_SetMessage_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_message)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string message = JNIEnv.GetString(native_message, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetMessage(message));
			}

			[Register("setMessage", "(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetSetMessage_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetMessage(string message)
			{
				IntPtr intPtr = JNIEnv.NewString(message);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMessage.(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetObjectId_Ljava_lang_String_Handler()
			{
				if ((object)cb_setObjectId_Ljava_lang_String_ == null)
				{
					cb_setObjectId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetObjectId_Ljava_lang_String_));
				}
				return cb_setObjectId_Ljava_lang_String_;
			}

			private static IntPtr n_SetObjectId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_objectId)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string objectId = JNIEnv.GetString(native_objectId, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetObjectId(objectId));
			}

			[Register("setObjectId", "(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetSetObjectId_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetObjectId(string objectId)
			{
				IntPtr intPtr = JNIEnv.NewString(objectId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setObjectId.(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetRecipients_Ljava_util_List_Handler()
			{
				if ((object)cb_setRecipients_Ljava_util_List_ == null)
				{
					cb_setRecipients_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetRecipients_Ljava_util_List_));
				}
				return cb_setRecipients_Ljava_util_List_;
			}

			private static IntPtr n_SetRecipients_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_recipients)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<string> recipients = JavaList<string>.FromJniHandle(native_recipients, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetRecipients(recipients));
			}

			[Register("setRecipients", "(Ljava/util/List;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetSetRecipients_Ljava_util_List_Handler")]
			public unsafe virtual Builder SetRecipients(IList<string> recipients)
			{
				IntPtr intPtr = JavaList<string>.ToLocalJniHandle(recipients);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setRecipients.(Ljava/util/List;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(recipients);
				}
			}

			private static Delegate GetSetSuggestions_Ljava_util_List_Handler()
			{
				if ((object)cb_setSuggestions_Ljava_util_List_ == null)
				{
					cb_setSuggestions_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSuggestions_Ljava_util_List_));
				}
				return cb_setSuggestions_Ljava_util_List_;
			}

			private static IntPtr n_SetSuggestions_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_suggestions)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<string> suggestions = JavaList<string>.FromJniHandle(native_suggestions, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSuggestions(suggestions));
			}

			[Register("setSuggestions", "(Ljava/util/List;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetSetSuggestions_Ljava_util_List_Handler")]
			public unsafe virtual Builder SetSuggestions(IList<string> suggestions)
			{
				IntPtr intPtr = JavaList<string>.ToLocalJniHandle(suggestions);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSuggestions.(Ljava/util/List;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(suggestions);
				}
			}

			private static Delegate GetSetTitle_Ljava_lang_String_Handler()
			{
				if ((object)cb_setTitle_Ljava_lang_String_ == null)
				{
					cb_setTitle_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetTitle_Ljava_lang_String_));
				}
				return cb_setTitle_Ljava_lang_String_;
			}

			private static IntPtr n_SetTitle_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_title)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string title = JNIEnv.GetString(native_title, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetTitle(title));
			}

			[Register("setTitle", "(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetSetTitle_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetTitle(string title)
			{
				IntPtr intPtr = JNIEnv.NewString(title);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTitle.(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Obsolete]
			private static Delegate GetSetTo_Ljava_lang_String_Handler()
			{
				if ((object)cb_setTo_Ljava_lang_String_ == null)
				{
					cb_setTo_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetTo_Ljava_lang_String_));
				}
				return cb_setTo_Ljava_lang_String_;
			}

			[Obsolete]
			private static IntPtr n_SetTo_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_to)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string to = JNIEnv.GetString(native_to, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetTo(to));
			}

			[Obsolete("deprecated")]
			[Register("setTo", "(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", "GetSetTo_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetTo(string to)
			{
				IntPtr intPtr = JNIEnv.NewString(to);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTo.(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			Java.Lang.Object IShareModelBuilder.ReadFrom(Java.Lang.Object model)
			{
				return JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom(JavaObjectExtensions.JavaCast<GameRequestContent>(model)));
			}
		}

		[Register("com/facebook/share/model/GameRequestContent$Filters", DoNotGenerateAcw = true)]
		public sealed class Filters : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/GameRequestContent$Filters", typeof(Filters));

			[Register("APP_NON_USERS")]
			public static Filters AppNonUsers => Java.Lang.Object.GetObject<Filters>(_members.StaticFields.GetObjectValue("APP_NON_USERS.Lcom/facebook/share/model/GameRequestContent$Filters;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("APP_USERS")]
			public static Filters AppUsers => Java.Lang.Object.GetObject<Filters>(_members.StaticFields.GetObjectValue("APP_USERS.Lcom/facebook/share/model/GameRequestContent$Filters;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("EVERYBODY")]
			public static Filters Everybody => Java.Lang.Object.GetObject<Filters>(_members.StaticFields.GetObjectValue("EVERYBODY.Lcom/facebook/share/model/GameRequestContent$Filters;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal Filters(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Filters;", "")]
			public unsafe static Filters ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Filters>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/share/model/GameRequestContent$Filters;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/facebook/share/model/GameRequestContent$Filters;", "")]
			public unsafe static Filters[] Values()
			{
				return (Filters[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/share/model/GameRequestContent$Filters;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Filters));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/GameRequestContent", typeof(GameRequestContent));

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

		public unsafe string Cta
		{
			[Register("getCta", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getCta.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Data
		{
			[Register("getData", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getData.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Message
		{
			[Register("getMessage", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ObjectId
		{
			[Register("getObjectId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getObjectId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> Recipients
		{
			[Register("getRecipients", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getRecipients.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> Suggestions
		{
			[Register("getSuggestions", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getSuggestions.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe string To
		{
			[Register("getTo", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getTo.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal GameRequestContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("describeContents", "()I", "")]
		public unsafe int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}

		[Register("getActionType", "()Lcom/facebook/share/model/GameRequestContent$ActionType;", "")]
		public unsafe ActionType GetActionType()
		{
			return Java.Lang.Object.GetObject<ActionType>(_members.InstanceMethods.InvokeAbstractObjectMethod("getActionType.()Lcom/facebook/share/model/GameRequestContent$ActionType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getFilters", "()Lcom/facebook/share/model/GameRequestContent$Filters;", "")]
		public unsafe Filters GetFilters()
		{
			return Java.Lang.Object.GetObject<Filters>(_members.InstanceMethods.InvokeAbstractObjectMethod("getFilters.()Lcom/facebook/share/model/GameRequestContent$Filters;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/facebook/share/model/ShareModel", "", "Xamarin.Facebook.Share.Model.IShareModelInvoker")]
	public interface IShareModel : IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/facebook/share/model/ShareModel", DoNotGenerateAcw = true)]
	internal class IShareModelInvoker : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareModel", typeof(IShareModelInvoker));

		private IntPtr class_ref;

		private static Delegate cb_describeContents;

		private IntPtr id_describeContents;

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

		private IntPtr id_writeToParcel_Landroid_os_Parcel_I;

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

		public static IShareModel GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IShareModel>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.share.model.ShareModel'.");
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

		public IShareModelInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IShareModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		public int DescribeContents()
		{
			if (id_describeContents == IntPtr.Zero)
			{
				id_describeContents = JNIEnv.GetMethodID(class_ref, "describeContents", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_describeContents);
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
			IShareModel shareModel = Java.Lang.Object.GetObject<IShareModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			shareModel.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		public unsafe void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			if (id_writeToParcel_Landroid_os_Parcel_I == IntPtr.Zero)
			{
				id_writeToParcel_Landroid_os_Parcel_I = JNIEnv.GetMethodID(class_ref, "writeToParcel", "(Landroid/os/Parcel;I)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((int)flags);
			JNIEnv.CallVoidMethod(base.Handle, id_writeToParcel_Landroid_os_Parcel_I, ptr);
		}
	}
	[Register("com/facebook/share/model/ShareModelBuilder", "", "Xamarin.Facebook.Share.Model.IShareModelBuilderInvoker")]
	[JavaTypeParameters(new string[] { "M extends com.facebook.share.model.ShareModel", "B extends com.facebook.share.model.ShareModelBuilder<M, B>" })]
	public interface IShareModelBuilder : IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("readFrom", "(Lcom/facebook/share/model/ShareModel;)Lcom/facebook/share/model/ShareModelBuilder;", "GetReadFrom_Lcom_facebook_share_model_ShareModel_Handler:Xamarin.Facebook.Share.Model.IShareModelBuilderInvoker, Xamarin.Facebook.Common.Android")]
		Java.Lang.Object ReadFrom(Java.Lang.Object model);
	}
	[Register("com/facebook/share/model/ShareModelBuilder", DoNotGenerateAcw = true)]
	internal class IShareModelBuilderInvoker : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareModelBuilder", typeof(IShareModelBuilderInvoker));

		private IntPtr class_ref;

		private static Delegate cb_readFrom_Lcom_facebook_share_model_ShareModel_;

		private IntPtr id_readFrom_Lcom_facebook_share_model_ShareModel_;

		private static Delegate cb_build;

		private IntPtr id_build;

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

		public static IShareModelBuilder GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IShareModelBuilder>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.share.model.ShareModelBuilder'.");
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

		public IShareModelBuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetReadFrom_Lcom_facebook_share_model_ShareModel_Handler()
		{
			if ((object)cb_readFrom_Lcom_facebook_share_model_ShareModel_ == null)
			{
				cb_readFrom_Lcom_facebook_share_model_ShareModel_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadFrom_Lcom_facebook_share_model_ShareModel_));
			}
			return cb_readFrom_Lcom_facebook_share_model_ShareModel_;
		}

		private static IntPtr n_ReadFrom_Lcom_facebook_share_model_ShareModel_(IntPtr jnienv, IntPtr native__this, IntPtr native_model)
		{
			IShareModelBuilder shareModelBuilder = Java.Lang.Object.GetObject<IShareModelBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object model = Java.Lang.Object.GetObject<Java.Lang.Object>(native_model, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(shareModelBuilder.ReadFrom(model));
		}

		public unsafe Java.Lang.Object ReadFrom(Java.Lang.Object model)
		{
			if (id_readFrom_Lcom_facebook_share_model_ShareModel_ == IntPtr.Zero)
			{
				id_readFrom_Lcom_facebook_share_model_ShareModel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Lcom/facebook/share/model/ShareModel;)Lcom/facebook/share/model/ShareModelBuilder;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(model);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_readFrom_Lcom_facebook_share_model_ShareModel_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IShareModelBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		public Java.Lang.Object Build()
		{
			if (id_build == IntPtr.Zero)
			{
				id_build = JNIEnv.GetMethodID(class_ref, "build", "()Ljava/lang/Object;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_build), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/facebook/share/model/ShareCameraEffectContent", DoNotGenerateAcw = true)]
	public class ShareCameraEffectContent : ShareContent
	{
		[Register("com/facebook/share/model/ShareCameraEffectContent$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareContent.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareCameraEffectContent$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/ShareCameraEffectContent;", "")]
			public new unsafe ShareCameraEffectContent Build()
			{
				return Java.Lang.Object.GetObject<ShareCameraEffectContent>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareCameraEffectContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareCameraEffectContent;)Lcom/facebook/share/model/ShareCameraEffectContent$Builder;", "")]
			public unsafe Builder ReadFrom(ShareCameraEffectContent model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/ShareCameraEffectContent;)Lcom/facebook/share/model/ShareCameraEffectContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setArguments", "(Lcom/facebook/share/model/CameraEffectArguments;)Lcom/facebook/share/model/ShareCameraEffectContent$Builder;", "")]
			public unsafe Builder SetArguments(CameraEffectArguments arguments)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(arguments?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setArguments.(Lcom/facebook/share/model/CameraEffectArguments;)Lcom/facebook/share/model/ShareCameraEffectContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(arguments);
				}
			}

			[Register("setEffectId", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareCameraEffectContent$Builder;", "")]
			public unsafe Builder SetEffectId(string effectId)
			{
				IntPtr intPtr = JNIEnv.NewString(effectId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEffectId.(Ljava/lang/String;)Lcom/facebook/share/model/ShareCameraEffectContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setTextures", "(Lcom/facebook/share/model/CameraEffectTextures;)Lcom/facebook/share/model/ShareCameraEffectContent$Builder;", "")]
			public unsafe Builder SetTextures(CameraEffectTextures textures)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(textures?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTextures.(Lcom/facebook/share/model/CameraEffectTextures;)Lcom/facebook/share/model/ShareCameraEffectContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(textures);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareCameraEffectContent", typeof(ShareCameraEffectContent));

		private static Delegate cb_getArguments;

		private static Delegate cb_getEffectId;

		private static Delegate cb_getTextures;

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe virtual CameraEffectArguments Arguments
		{
			[Register("getArguments", "()Lcom/facebook/share/model/CameraEffectArguments;", "GetGetArgumentsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<CameraEffectArguments>(_members.InstanceMethods.InvokeVirtualObjectMethod("getArguments.()Lcom/facebook/share/model/CameraEffectArguments;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string EffectId
		{
			[Register("getEffectId", "()Ljava/lang/String;", "GetGetEffectIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEffectId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual CameraEffectTextures Textures
		{
			[Register("getTextures", "()Lcom/facebook/share/model/CameraEffectTextures;", "GetGetTexturesHandler")]
			get
			{
				return Java.Lang.Object.GetObject<CameraEffectTextures>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTextures.()Lcom/facebook/share/model/CameraEffectTextures;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ShareCameraEffectContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetArgumentsHandler()
		{
			if ((object)cb_getArguments == null)
			{
				cb_getArguments = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetArguments));
			}
			return cb_getArguments;
		}

		private static IntPtr n_GetArguments(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareCameraEffectContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Arguments);
		}

		private static Delegate GetGetEffectIdHandler()
		{
			if ((object)cb_getEffectId == null)
			{
				cb_getEffectId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEffectId));
			}
			return cb_getEffectId;
		}

		private static IntPtr n_GetEffectId(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ShareCameraEffectContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EffectId);
		}

		private static Delegate GetGetTexturesHandler()
		{
			if ((object)cb_getTextures == null)
			{
				cb_getTextures = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTextures));
			}
			return cb_getTextures;
		}

		private static IntPtr n_GetTextures(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareCameraEffectContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Textures);
		}
	}
	[Register("com/facebook/share/model/ShareContent", DoNotGenerateAcw = true)]
	internal class ShareContentInvoker : ShareContent
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareContent", typeof(ShareContentInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ShareContentInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/facebook/share/model/ShareHashtag", DoNotGenerateAcw = true)]
	public sealed class ShareHashtag : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/model/ShareHashtag$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareHashtag$Builder", typeof(Builder));

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

			public unsafe string Hashtag
			{
				[Register("getHashtag", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getHashtag.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/ShareHashtag;", "")]
			public unsafe Java.Lang.Object Build()
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareHashtag;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareHashtag;)Lcom/facebook/share/model/ShareHashtag$Builder;", "")]
			public unsafe Builder ReadFrom(ShareHashtag model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/ShareHashtag;)Lcom/facebook/share/model/ShareHashtag$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setHashtag", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareHashtag$Builder;", "")]
			public unsafe Builder SetHashtag(string hashtag)
			{
				IntPtr intPtr = JNIEnv.NewString(hashtag);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setHashtag.(Ljava/lang/String;)Lcom/facebook/share/model/ShareHashtag$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			Java.Lang.Object IShareModelBuilder.ReadFrom(Java.Lang.Object model)
			{
				return JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom(JavaObjectExtensions.JavaCast<ShareHashtag>(model)));
			}
		}

		[Register("com/facebook/share/model/ShareHashtag$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareHashtag$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareHashtag", typeof(ShareHashtag));

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

		public unsafe string Hashtag
		{
			[Register("getHashtag", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getHashtag.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareHashtag(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareHashtag$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe ShareHashtag(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareHashtag$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareHashtag$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}

		[Register("describeContents", "()I", "")]
		public unsafe int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dest);
			}
		}
	}
	[Register("com/facebook/share/model/ShareLinkContent", DoNotGenerateAcw = true)]
	public sealed class ShareLinkContent : ShareContent
	{
		[Register("com/facebook/share/model/ShareLinkContent$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareContent.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareLinkContent$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/ShareLinkContent;", "")]
			public new unsafe ShareLinkContent Build()
			{
				return Java.Lang.Object.GetObject<ShareLinkContent>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareLinkContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareLinkContent;)Lcom/facebook/share/model/ShareLinkContent$Builder;", "")]
			public unsafe Builder ReadFrom(ShareLinkContent model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/ShareLinkContent;)Lcom/facebook/share/model/ShareLinkContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setQuote", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareLinkContent$Builder;", "")]
			public unsafe Builder SetQuote(string quote)
			{
				IntPtr intPtr = JNIEnv.NewString(quote);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setQuote.(Ljava/lang/String;)Lcom/facebook/share/model/ShareLinkContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("com/facebook/share/model/ShareLinkContent$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareLinkContent$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareLinkContent", typeof(ShareLinkContent));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string Quote
		{
			[Register("getQuote", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getQuote.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareLinkContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareLinkContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe ShareLinkContent(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareLinkContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareLinkContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}
	}
	[Register("com/facebook/share/model/ShareMedia", DoNotGenerateAcw = true)]
	internal class ShareMediaInvoker : ShareMedia
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMedia", typeof(ShareMediaInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override System.Type ThresholdType => _members.ManagedPeerType;

		public unsafe override Type MediaType
		{
			[Register("getMediaType", "()Lcom/facebook/share/model/ShareMedia$Type;", "GetGetMediaTypeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Type>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMediaType.()Lcom/facebook/share/model/ShareMedia$Type;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public ShareMediaInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/facebook/share/model/ShareMediaContent", DoNotGenerateAcw = true)]
	public sealed class ShareMediaContent : ShareContent
	{
		[Register("com/facebook/share/model/ShareMediaContent$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareContent.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMediaContent$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("addMedia", "(Ljava/util/List;)Lcom/facebook/share/model/ShareMediaContent$Builder;", "")]
			public unsafe Builder AddMedia(IList<ShareMedia> media)
			{
				IntPtr intPtr = JavaList<ShareMedia>.ToLocalJniHandle(media);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addMedia.(Ljava/util/List;)Lcom/facebook/share/model/ShareMediaContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(media);
				}
			}

			[Register("addMedium", "(Lcom/facebook/share/model/ShareMedia;)Lcom/facebook/share/model/ShareMediaContent$Builder;", "")]
			public unsafe Builder AddMedium(ShareMedia medium)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(medium?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addMedium.(Lcom/facebook/share/model/ShareMedia;)Lcom/facebook/share/model/ShareMediaContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(medium);
				}
			}

			[Register("build", "()Lcom/facebook/share/model/ShareMediaContent;", "")]
			public new unsafe ShareMediaContent Build()
			{
				return Java.Lang.Object.GetObject<ShareMediaContent>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareMediaContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareMediaContent;)Lcom/facebook/share/model/ShareMediaContent$Builder;", "")]
			public unsafe Builder ReadFrom(ShareMediaContent model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/ShareMediaContent;)Lcom/facebook/share/model/ShareMediaContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setMedia", "(Ljava/util/List;)Lcom/facebook/share/model/ShareMediaContent$Builder;", "")]
			public unsafe Builder SetMedia(IList<ShareMedia> media)
			{
				IntPtr intPtr = JavaList<ShareMedia>.ToLocalJniHandle(media);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setMedia.(Ljava/util/List;)Lcom/facebook/share/model/ShareMediaContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(media);
				}
			}
		}

		[Register("com/facebook/share/model/ShareMediaContent$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMediaContent$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMediaContent", typeof(ShareMediaContent));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe IList<ShareMedia> Media
		{
			[Register("getMedia", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<ShareMedia>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getMedia.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareMediaContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareMediaContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe ShareMediaContent(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareMediaContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareMediaContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}
	}
	[Register("com/facebook/share/model/ShareMessengerActionButton", DoNotGenerateAcw = true)]
	internal class ShareMessengerActionButtonInvoker : ShareMessengerActionButton
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMessengerActionButton", typeof(ShareMessengerActionButtonInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ShareMessengerActionButtonInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/facebook/share/model/ShareMessengerURLActionButton", DoNotGenerateAcw = true)]
	public sealed class ShareMessengerURLActionButton : ShareMessengerActionButton
	{
		[Register("com/facebook/share/model/ShareMessengerURLActionButton$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareMessengerActionButton.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMessengerURLActionButton$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/ShareMessengerURLActionButton;", "")]
			public new unsafe ShareMessengerURLActionButton Build()
			{
				return Java.Lang.Object.GetObject<ShareMessengerURLActionButton>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareMessengerURLActionButton;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareMessengerURLActionButton;)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", "")]
			public unsafe Builder ReadFrom(ShareMessengerURLActionButton content)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/ShareMessengerURLActionButton;)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(content);
				}
			}

			[Register("setFallbackUrl", "(Landroid/net/Uri;)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", "")]
			public unsafe Builder SetFallbackUrl(Android.Net.Uri fallbackUrl)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(fallbackUrl?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setFallbackUrl.(Landroid/net/Uri;)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(fallbackUrl);
				}
			}

			[Register("setIsMessengerExtensionURL", "(Z)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", "")]
			public unsafe Builder SetIsMessengerExtensionURL(bool isMessengerExtensionURL)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(isMessengerExtensionURL);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setIsMessengerExtensionURL.(Z)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setShouldHideWebviewShareButton", "(Z)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", "")]
			public unsafe Builder SetShouldHideWebviewShareButton(bool shouldHideWebviewShareButton)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(shouldHideWebviewShareButton);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setShouldHideWebviewShareButton.(Z)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setUrl", "(Landroid/net/Uri;)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", "")]
			public unsafe Builder SetUrl(Android.Net.Uri url)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setUrl.(Landroid/net/Uri;)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(url);
				}
			}

			[Register("setWebviewHeightRatio", "(Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", "")]
			public unsafe Builder SetWebviewHeightRatio(WebviewHeightRatio webviewHeightRatio)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(webviewHeightRatio?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setWebviewHeightRatio.(Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;)Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(webviewHeightRatio);
				}
			}
		}

		[Register("com/facebook/share/model/ShareMessengerURLActionButton$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMessengerURLActionButton$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		[Register("com/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio", DoNotGenerateAcw = true)]
		public sealed class WebviewHeightRatio : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio", typeof(WebviewHeightRatio));

			[Register("WebviewHeightRatioCompact")]
			public static WebviewHeightRatio WebviewHeightRatioCompact => Java.Lang.Object.GetObject<WebviewHeightRatio>(_members.StaticFields.GetObjectValue("WebviewHeightRatioCompact.Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("WebviewHeightRatioFull")]
			public static WebviewHeightRatio WebviewHeightRatioFull => Java.Lang.Object.GetObject<WebviewHeightRatio>(_members.StaticFields.GetObjectValue("WebviewHeightRatioFull.Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("WebviewHeightRatioTall")]
			public static WebviewHeightRatio WebviewHeightRatioTall => Java.Lang.Object.GetObject<WebviewHeightRatio>(_members.StaticFields.GetObjectValue("WebviewHeightRatioTall.Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal WebviewHeightRatio(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;", "")]
			public unsafe static WebviewHeightRatio ValueOf(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<WebviewHeightRatio>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;", "")]
			public unsafe static WebviewHeightRatio[] Values()
			{
				return (WebviewHeightRatio[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(WebviewHeightRatio));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareMessengerURLActionButton", typeof(ShareMessengerURLActionButton));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe Android.Net.Uri FallbackUrl
		{
			[Register("getFallbackUrl", "()Landroid/net/Uri;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFallbackUrl.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsMessengerExtensionURL
		{
			[Register("isMessengerExtensionURL", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isMessengerExtensionURL.()Z", this, null);
			}
		}

		public unsafe bool ShouldHideWebviewShareButton
		{
			[Register("getShouldHideWebviewShareButton", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getShouldHideWebviewShareButton.()Z", this, null);
			}
		}

		public unsafe Android.Net.Uri Url
		{
			[Register("getUrl", "()Landroid/net/Uri;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getUrl.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareMessengerURLActionButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe ShareMessengerURLActionButton(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareMessengerURLActionButton$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}

		[Register("getWebviewHeightRatio", "()Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;", "")]
		public unsafe WebviewHeightRatio GetWebviewHeightRatio()
		{
			return Java.Lang.Object.GetObject<WebviewHeightRatio>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getWebviewHeightRatio.()Lcom/facebook/share/model/ShareMessengerURLActionButton$WebviewHeightRatio;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("getIsMessengerExtensionURL", "()Z", "")]
		public unsafe bool GetIsMessengerExtensionURL()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getIsMessengerExtensionURL.()Z", this, null);
		}
	}
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/facebook/share/model/ShareOpenGraphAction", DoNotGenerateAcw = true)]
	public sealed class ShareOpenGraphAction : ShareOpenGraphValueContainer
	{
		[Register("com/facebook/share/model/ShareOpenGraphAction$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareOpenGraphValueContainer.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphAction$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/ShareOpenGraphAction;", "")]
			public new unsafe ShareOpenGraphAction Build()
			{
				return Java.Lang.Object.GetObject<ShareOpenGraphAction>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareOpenGraphAction;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareOpenGraphAction;)Lcom/facebook/share/model/ShareOpenGraphAction$Builder;", "")]
			public unsafe Builder ReadFrom(ShareOpenGraphAction model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/ShareOpenGraphAction;)Lcom/facebook/share/model/ShareOpenGraphAction$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setActionType", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareOpenGraphAction$Builder;", "")]
			public unsafe Builder SetActionType(string actionType)
			{
				IntPtr intPtr = JNIEnv.NewString(actionType);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActionType.(Ljava/lang/String;)Lcom/facebook/share/model/ShareOpenGraphAction$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphAction", typeof(ShareOpenGraphAction));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string ActionType
		{
			[Register("getActionType", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getActionType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareOpenGraphAction(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/facebook/share/model/ShareOpenGraphContent", DoNotGenerateAcw = true)]
	public sealed class ShareOpenGraphContent : ShareContent
	{
		[Register("com/facebook/share/model/ShareOpenGraphContent$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareContent.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphContent$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/ShareOpenGraphContent;", "")]
			public new unsafe ShareOpenGraphContent Build()
			{
				return Java.Lang.Object.GetObject<ShareOpenGraphContent>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareOpenGraphContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareOpenGraphContent;)Lcom/facebook/share/model/ShareOpenGraphContent$Builder;", "")]
			public unsafe Builder ReadFrom(ShareOpenGraphContent model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/ShareOpenGraphContent;)Lcom/facebook/share/model/ShareOpenGraphContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setAction", "(Lcom/facebook/share/model/ShareOpenGraphAction;)Lcom/facebook/share/model/ShareOpenGraphContent$Builder;", "")]
			public unsafe Builder SetAction(ShareOpenGraphAction action)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(action?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAction.(Lcom/facebook/share/model/ShareOpenGraphAction;)Lcom/facebook/share/model/ShareOpenGraphContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(action);
				}
			}

			[Register("setPreviewPropertyName", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareOpenGraphContent$Builder;", "")]
			public unsafe Builder SetPreviewPropertyName(string previewPropertyName)
			{
				IntPtr intPtr = JNIEnv.NewString(previewPropertyName);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPreviewPropertyName.(Ljava/lang/String;)Lcom/facebook/share/model/ShareOpenGraphContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphContent", typeof(ShareOpenGraphContent));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe ShareOpenGraphAction Action
		{
			[Register("getAction", "()Lcom/facebook/share/model/ShareOpenGraphAction;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ShareOpenGraphAction>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAction.()Lcom/facebook/share/model/ShareOpenGraphAction;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string PreviewPropertyName
		{
			[Register("getPreviewPropertyName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPreviewPropertyName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareOpenGraphContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/facebook/share/model/ShareOpenGraphObject", DoNotGenerateAcw = true)]
	public sealed class ShareOpenGraphObject : ShareOpenGraphValueContainer
	{
		[Register("com/facebook/share/model/ShareOpenGraphObject$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareOpenGraphValueContainer.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphObject$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/ShareOpenGraphObject;", "")]
			public new unsafe ShareOpenGraphObject Build()
			{
				return Java.Lang.Object.GetObject<ShareOpenGraphObject>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareOpenGraphObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/facebook/share/model/ShareOpenGraphObject$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphObject$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphObject", typeof(ShareOpenGraphObject));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal ShareOpenGraphObject(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareOpenGraphObject$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe ShareOpenGraphObject(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareOpenGraphObject$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareOpenGraphObject$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}
	}
	[Register("com/facebook/share/model/ShareOpenGraphValueContainer", DoNotGenerateAcw = true)]
	internal class ShareOpenGraphValueContainerInvoker : ShareOpenGraphValueContainer
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareOpenGraphValueContainer", typeof(ShareOpenGraphValueContainerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ShareOpenGraphValueContainerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/facebook/share/model/SharePhoto", DoNotGenerateAcw = true)]
	public sealed class SharePhoto : ShareMedia
	{
		[Register("com/facebook/share/model/SharePhoto$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareMedia.Builder
		{
			[Register("com/facebook/share/model/SharePhoto$Builder$Companion", DoNotGenerateAcw = true)]
			public new sealed class Companion : Java.Lang.Object
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/SharePhoto$Builder$Companion", typeof(Companion));

				internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				public override JniPeerMembers JniPeerMembers => _members;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				protected override System.Type ThresholdType => _members.ManagedPeerType;

				internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
					: base(javaReference, transfer)
				{
				}

				[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
				public unsafe Companion(DefaultConstructorMarker _constructor_marker)
					: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
				{
					if (base.Handle != IntPtr.Zero)
					{
						return;
					}
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
						SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
						_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(_constructor_marker);
					}
				}
			}

			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/SharePhoto$Builder", typeof(Builder));

			internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override System.Type ThresholdType => _members.ManagedPeerType;

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/SharePhoto;", "")]
			public new unsafe SharePhoto Build()
			{
				return Java.Lang.Object.GetObject<SharePhoto>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/SharePhoto;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/SharePhoto;)Lcom/facebook/share/model/SharePhoto$Builder;", "")]
			public unsafe Builder ReadFrom(SharePhoto model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/SharePhoto;)Lcom/facebook/share/model/SharePhoto$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setBitmap", "(Landroid/graphics/Bitmap;)Lcom/facebook/share/model/SharePhoto$Builder;", "")]
			public unsafe Builder SetBitmap(Bitmap bitmap)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setBitmap.(Landroid/graphics/Bitmap;)Lcom/facebook/share/model/SharePhoto$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(bitmap);
				}
			}

			[Register("setCaption", "(Ljava/lang/String;)Lcom/facebook/share/model/SharePhoto$Builder;", "")]
			public unsafe Builder SetCaption(string caption)
			{
				IntPtr intPtr = JNIEnv.NewString(caption);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setCaption.(Ljava/lang/String;)Lcom/facebook/share/model/SharePhoto$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setImageUrl", "(Landroid/net/Uri;)Lcom/facebook/share/model/SharePhoto$Builder;", "")]
			public unsafe Builder SetImageUrl(Android.Net.Uri imageUrl)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(imageUrl?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setImageUrl.(Landroid/net/Uri;)Lcom/facebook/share/model/SharePhoto$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(imageUrl);
				}
			}

			[Register("setUserGenerated", "(Z)Lcom/facebook/share/model/SharePhoto$Builder;", "")]
			public unsafe Builder SetUserGenerated(bool userGenerated)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(userGenerated);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setUserGenerated.(Z)Lcom/facebook/share/model/SharePhoto$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/facebook/share/model/SharePhoto$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/SharePhoto$Companion", typeof(Companion));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override System.Type ThresholdType => _members.ManagedPeerType;

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/SharePhoto", typeof(SharePhoto));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override System.Type ThresholdType => _members.ManagedPeerType;

		public unsafe Bitmap Bitmap
		{
			[Register("getBitmap", "()Landroid/graphics/Bitmap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBitmap.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Caption
		{
			[Register("getCaption", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCaption.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Android.Net.Uri ImageUrl
		{
			[Register("getImageUrl", "()Landroid/net/Uri;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getImageUrl.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override Type MediaType
		{
			[Register("getMediaType", "()Lcom/facebook/share/model/ShareMedia$Type;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Type>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMediaType.()Lcom/facebook/share/model/ShareMedia$Type;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool UserGenerated
		{
			[Register("getUserGenerated", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getUserGenerated.()Z", this, null);
			}
		}

		internal SharePhoto(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/SharePhoto$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe SharePhoto(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/SharePhoto$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/SharePhoto$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}
	}
	[Register("com/facebook/share/model/SharePhotoContent", DoNotGenerateAcw = true)]
	public sealed class SharePhotoContent : ShareContent
	{
		[Register("com/facebook/share/model/SharePhotoContent$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareContent.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/SharePhotoContent$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("addPhoto", "(Lcom/facebook/share/model/SharePhoto;)Lcom/facebook/share/model/SharePhotoContent$Builder;", "")]
			public unsafe Builder AddPhoto(SharePhoto photo)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(photo?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addPhoto.(Lcom/facebook/share/model/SharePhoto;)Lcom/facebook/share/model/SharePhotoContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(photo);
				}
			}

			[Register("addPhotos", "(Ljava/util/List;)Lcom/facebook/share/model/SharePhotoContent$Builder;", "")]
			public unsafe Builder AddPhotos(IList<SharePhoto> photos)
			{
				IntPtr intPtr = JavaList<SharePhoto>.ToLocalJniHandle(photos);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addPhotos.(Ljava/util/List;)Lcom/facebook/share/model/SharePhotoContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(photos);
				}
			}

			[Register("build", "()Lcom/facebook/share/model/SharePhotoContent;", "")]
			public new unsafe SharePhotoContent Build()
			{
				return Java.Lang.Object.GetObject<SharePhotoContent>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/SharePhotoContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/SharePhotoContent;)Lcom/facebook/share/model/SharePhotoContent$Builder;", "")]
			public unsafe Builder ReadFrom(SharePhotoContent model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/SharePhotoContent;)Lcom/facebook/share/model/SharePhotoContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setPhotos", "(Ljava/util/List;)Lcom/facebook/share/model/SharePhotoContent$Builder;", "")]
			public unsafe Builder SetPhotos(IList<SharePhoto> photos)
			{
				IntPtr intPtr = JavaList<SharePhoto>.ToLocalJniHandle(photos);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setPhotos.(Ljava/util/List;)Lcom/facebook/share/model/SharePhotoContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(photos);
				}
			}
		}

		[Register("com/facebook/share/model/SharePhotoContent$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/SharePhotoContent$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/SharePhotoContent", typeof(SharePhotoContent));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe IList<SharePhoto> Photos
		{
			[Register("getPhotos", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<SharePhoto>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPhotos.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal SharePhotoContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/SharePhotoContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe SharePhotoContent(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/SharePhotoContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/SharePhotoContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}
	}
	[Register("com/facebook/share/model/ShareStoryContent", DoNotGenerateAcw = true)]
	public sealed class ShareStoryContent : ShareContent
	{
		[Register("com/facebook/share/model/ShareStoryContent$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareContent.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareStoryContent$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/ShareStoryContent;", "")]
			public new unsafe ShareStoryContent Build()
			{
				return Java.Lang.Object.GetObject<ShareStoryContent>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareStoryContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareStoryContent;)Lcom/facebook/share/model/ShareStoryContent$Builder;", "")]
			public unsafe Builder ReadFrom(ShareStoryContent model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/ShareStoryContent;)Lcom/facebook/share/model/ShareStoryContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setAttributionLink", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareStoryContent$Builder;", "")]
			public unsafe Builder SetAttributionLink(string attributionLink)
			{
				IntPtr intPtr = JNIEnv.NewString(attributionLink);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setAttributionLink.(Ljava/lang/String;)Lcom/facebook/share/model/ShareStoryContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setBackgroundAsset", "(Lcom/facebook/share/model/ShareMedia;)Lcom/facebook/share/model/ShareStoryContent$Builder;", "")]
			public unsafe Builder SetBackgroundAsset(ShareMedia backgroundAsset)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(backgroundAsset?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setBackgroundAsset.(Lcom/facebook/share/model/ShareMedia;)Lcom/facebook/share/model/ShareStoryContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(backgroundAsset);
				}
			}

			[Register("setBackgroundColorList", "(Ljava/util/List;)Lcom/facebook/share/model/ShareStoryContent$Builder;", "")]
			public unsafe Builder SetBackgroundColorList(IList<string> backgroundColorList)
			{
				IntPtr intPtr = JavaList<string>.ToLocalJniHandle(backgroundColorList);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setBackgroundColorList.(Ljava/util/List;)Lcom/facebook/share/model/ShareStoryContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(backgroundColorList);
				}
			}

			[Register("setStickerAsset", "(Lcom/facebook/share/model/SharePhoto;)Lcom/facebook/share/model/ShareStoryContent$Builder;", "")]
			public unsafe Builder SetStickerAsset(SharePhoto stickerAsset)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(stickerAsset?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setStickerAsset.(Lcom/facebook/share/model/SharePhoto;)Lcom/facebook/share/model/ShareStoryContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(stickerAsset);
				}
			}
		}

		[Register("com/facebook/share/model/ShareStoryContent$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareStoryContent$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareStoryContent", typeof(ShareStoryContent));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string AttributionLink
		{
			[Register("getAttributionLink", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAttributionLink.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ShareMedia BackgroundAsset
		{
			[Register("getBackgroundAsset", "()Lcom/facebook/share/model/ShareMedia;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ShareMedia>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBackgroundAsset.()Lcom/facebook/share/model/ShareMedia;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> BackgroundColorList
		{
			[Register("getBackgroundColorList", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBackgroundColorList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe SharePhoto StickerAsset
		{
			[Register("getStickerAsset", "()Lcom/facebook/share/model/SharePhoto;", "")]
			get
			{
				return Java.Lang.Object.GetObject<SharePhoto>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getStickerAsset.()Lcom/facebook/share/model/SharePhoto;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareStoryContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareStoryContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe ShareStoryContent(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareStoryContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareStoryContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}
	}
	[Register("com/facebook/share/model/ShareVideo", DoNotGenerateAcw = true)]
	public sealed class ShareVideo : ShareMedia
	{
		[Register("com/facebook/share/model/ShareVideo$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareMedia.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareVideo$Builder", typeof(Builder));

			internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override System.Type ThresholdType => _members.ManagedPeerType;

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/ShareVideo;", "")]
			public new unsafe ShareVideo Build()
			{
				return Java.Lang.Object.GetObject<ShareVideo>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareVideo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareVideo;)Lcom/facebook/share/model/ShareVideo$Builder;", "")]
			public unsafe Builder ReadFrom(ShareVideo model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/ShareVideo;)Lcom/facebook/share/model/ShareVideo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setLocalUrl", "(Landroid/net/Uri;)Lcom/facebook/share/model/ShareVideo$Builder;", "")]
			public unsafe Builder SetLocalUrl(Android.Net.Uri localUrl)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(localUrl?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setLocalUrl.(Landroid/net/Uri;)Lcom/facebook/share/model/ShareVideo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(localUrl);
				}
			}
		}

		[Register("com/facebook/share/model/ShareVideo$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareVideo$Companion", typeof(Companion));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override System.Type ThresholdType => _members.ManagedPeerType;

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareVideo", typeof(ShareVideo));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override System.Type ThresholdType => _members.ManagedPeerType;

		public unsafe Android.Net.Uri LocalUrl
		{
			[Register("getLocalUrl", "()Landroid/net/Uri;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLocalUrl.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override Type MediaType
		{
			[Register("getMediaType", "()Lcom/facebook/share/model/ShareMedia$Type;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Type>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMediaType.()Lcom/facebook/share/model/ShareMedia$Type;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareVideo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareVideo$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe ShareVideo(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareVideo$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareVideo$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}
	}
	[Register("com/facebook/share/model/ShareVideoContent", DoNotGenerateAcw = true)]
	public sealed class ShareVideoContent : ShareContent, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/share/model/ShareVideoContent$Builder", DoNotGenerateAcw = true)]
		public new sealed class Builder : ShareContent.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareVideoContent$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("build", "()Lcom/facebook/share/model/ShareVideoContent;", "")]
			public new unsafe ShareVideoContent Build()
			{
				return Java.Lang.Object.GetObject<ShareVideoContent>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/share/model/ShareVideoContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/share/model/ShareVideoContent;)Lcom/facebook/share/model/ShareVideoContent$Builder;", "")]
			public unsafe Builder ReadFrom(ShareVideoContent model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/share/model/ShareVideoContent;)Lcom/facebook/share/model/ShareVideoContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setContentDescription", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareVideoContent$Builder;", "")]
			public unsafe Builder SetContentDescription(string contentDescription)
			{
				IntPtr intPtr = JNIEnv.NewString(contentDescription);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setContentDescription.(Ljava/lang/String;)Lcom/facebook/share/model/ShareVideoContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setContentTitle", "(Ljava/lang/String;)Lcom/facebook/share/model/ShareVideoContent$Builder;", "")]
			public unsafe Builder SetContentTitle(string contentTitle)
			{
				IntPtr intPtr = JNIEnv.NewString(contentTitle);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setContentTitle.(Ljava/lang/String;)Lcom/facebook/share/model/ShareVideoContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setPreviewPhoto", "(Lcom/facebook/share/model/SharePhoto;)Lcom/facebook/share/model/ShareVideoContent$Builder;", "")]
			public unsafe Builder SetPreviewPhoto(SharePhoto previewPhoto)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(previewPhoto?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setPreviewPhoto.(Lcom/facebook/share/model/SharePhoto;)Lcom/facebook/share/model/ShareVideoContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(previewPhoto);
				}
			}

			[Register("setVideo", "(Lcom/facebook/share/model/ShareVideo;)Lcom/facebook/share/model/ShareVideoContent$Builder;", "")]
			public unsafe Builder SetVideo(ShareVideo video)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(video?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setVideo.(Lcom/facebook/share/model/ShareVideo;)Lcom/facebook/share/model/ShareVideoContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(video);
				}
			}
		}

		[Register("com/facebook/share/model/ShareVideoContent$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareVideoContent$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/model/ShareVideoContent", typeof(ShareVideoContent));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string ContentDescription
		{
			[Register("getContentDescription", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContentDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ContentTitle
		{
			[Register("getContentTitle", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContentTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe SharePhoto PreviewPhoto
		{
			[Register("getPreviewPhoto", "()Lcom/facebook/share/model/SharePhoto;", "")]
			get
			{
				return Java.Lang.Object.GetObject<SharePhoto>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPreviewPhoto.()Lcom/facebook/share/model/SharePhoto;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ShareVideo Video
		{
			[Register("getVideo", "()Lcom/facebook/share/model/ShareVideo;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ShareVideo>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getVideo.()Lcom/facebook/share/model/ShareVideo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareVideoContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareVideoContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe ShareVideoContent(Builder builder, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareVideoContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareVideoContent$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_constructor_marker);
			}
		}
	}
}
