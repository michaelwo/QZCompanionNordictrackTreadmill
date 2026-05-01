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
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Runtime;
using AndroidX.Fragment.App;
using Com.Facebook.Gamingservices.Model;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Kotlin.Jvm.Internal;
using Org.Json;
using Xamarin.Facebook.GamingServices;
using Xamarin.Facebook.GamingServices.CloudGaming.Internal;
using Xamarin.Facebook.GamingServices.Internal;
using Xamarin.Facebook.Internal;
using Xamarin.Facebook.Share;
using Xamarin.Facebook.Share.Model;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "{BUILD_COMMIT}")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "{BUILD_NUMBER}")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "{BUILD_TIMESTAMP}")]
[assembly: NamespaceMapping(Java = "com.facebook.gamingservices", Managed = "Xamarin.Facebook.GamingServices")]
[assembly: NamespaceMapping(Java = "com.facebook.gamingservices.cloudgaming", Managed = "Xamarin.Facebook.GamingServices.CloudGaming")]
[assembly: NamespaceMapping(Java = "com.facebook.gamingservices.cloudgaming.internal", Managed = "Xamarin.Facebook.GamingServices.CloudGaming.Internal")]
[assembly: NamespaceMapping(Java = "com.facebook.gamingservices.internal", Managed = "Xamarin.Facebook.GamingServices.Internal")]
[assembly: NamespaceMapping(Java = "com.facebook.gamingservices.model", Managed = "Com.Facebook.Gamingservices.Model")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for Facebook Android - Gaming Services")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Facebook.GamingServices.Android")]
[assembly: AssemblyTitle("Xamarin.Facebook.GamingServices.Android")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPJJ_V(IntPtr jnienv, IntPtr klass, long p0, long p1);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, bool p2);
internal delegate void _JniMarshal_PPLLZL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, bool p2, IntPtr p3);
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
		private static string[] package_com_facebook_gamingservices_mappings;

		private static string[] package_com_facebook_gamingservices_cloudgaming_mappings;

		private static string[] package_com_facebook_gamingservices_cloudgaming_internal_mappings;

		private static string[] package_com_facebook_gamingservices_internal_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[4] { "com/facebook/gamingservices", "com/facebook/gamingservices/cloudgaming", "com/facebook/gamingservices/cloudgaming/internal", "com/facebook/gamingservices/internal" }, new Converter<string, Type>[4] { lookup_com_facebook_gamingservices_package, lookup_com_facebook_gamingservices_cloudgaming_package, lookup_com_facebook_gamingservices_cloudgaming_internal_package, lookup_com_facebook_gamingservices_internal_package });
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

		private static Type lookup_com_facebook_gamingservices_package(string klass)
		{
			if (package_com_facebook_gamingservices_mappings == null)
			{
				package_com_facebook_gamingservices_mappings = new string[36]
				{
					"com/facebook/gamingservices/BuildConfig:Xamarin.Facebook.GamingServices.BuildConfig", "com/facebook/gamingservices/ContextChooseDialog:Xamarin.Facebook.GamingServices.ContextChooseDialog", "com/facebook/gamingservices/ContextChooseDialog$Result:Xamarin.Facebook.GamingServices.ContextChooseDialog/Result", "com/facebook/gamingservices/ContextCreateDialog:Xamarin.Facebook.GamingServices.ContextCreateDialog", "com/facebook/gamingservices/ContextCreateDialog$Result:Xamarin.Facebook.GamingServices.ContextCreateDialog/Result", "com/facebook/gamingservices/ContextSwitchDialog:Xamarin.Facebook.GamingServices.ContextSwitchDialog", "com/facebook/gamingservices/ContextSwitchDialog$Result:Xamarin.Facebook.GamingServices.ContextSwitchDialog/Result", "com/facebook/gamingservices/CustomUpdate:Xamarin.Facebook.GamingServices.CustomUpdate", "com/facebook/gamingservices/FriendFinderDialog:Xamarin.Facebook.GamingServices.FriendFinderDialog", "com/facebook/gamingservices/FriendFinderDialog$Result:Xamarin.Facebook.GamingServices.FriendFinderDialog/Result",
					"com/facebook/gamingservices/GameRequestDialog:Xamarin.Facebook.GamingServices.GameRequestDialog", "com/facebook/gamingservices/GameRequestDialog$Result:Xamarin.Facebook.GamingServices.GameRequestDialog/Result", "com/facebook/gamingservices/GamingContext:Xamarin.Facebook.GamingServices.GamingContext", "com/facebook/gamingservices/GamingContext$Companion:Xamarin.Facebook.GamingServices.GamingContext/Companion", "com/facebook/gamingservices/GamingGroupIntegration:Xamarin.Facebook.GamingServices.GamingGroupIntegration", "com/facebook/gamingservices/GamingGroupIntegration$Result:Xamarin.Facebook.GamingServices.GamingGroupIntegration/Result", "com/facebook/gamingservices/GamingImageUploader:Xamarin.Facebook.GamingServices.GamingImageUploader", "com/facebook/gamingservices/GamingPayload:Xamarin.Facebook.GamingServices.GamingPayload", "com/facebook/gamingservices/GamingServices:Xamarin.Facebook.GamingServices.GamingServices", "com/facebook/gamingservices/GamingVideoUploader:Xamarin.Facebook.GamingServices.GamingVideoUploader",
					"com/facebook/gamingservices/GraphAPIException:Xamarin.Facebook.GamingServices.GraphAPIException", "com/facebook/gamingservices/InvalidExpirationDateException:Xamarin.Facebook.GamingServices.InvalidExpirationDateException", "com/facebook/gamingservices/InvalidScoreTypeException:Xamarin.Facebook.GamingServices.InvalidScoreTypeException", "com/facebook/gamingservices/OpenGamingMediaDialog:Xamarin.Facebook.GamingServices.OpenGamingMediaDialog", "com/facebook/gamingservices/Tournament:Xamarin.Facebook.GamingServices.Tournament", "com/facebook/gamingservices/Tournament$CREATOR:Xamarin.Facebook.GamingServices.Tournament/CREATOR", "com/facebook/gamingservices/TournamentConfig:Xamarin.Facebook.GamingServices.TournamentConfig", "com/facebook/gamingservices/TournamentConfig$Builder:Xamarin.Facebook.GamingServices.TournamentConfig/Builder", "com/facebook/gamingservices/TournamentConfig$CREATOR:Xamarin.Facebook.GamingServices.TournamentConfig/CREATOR", "com/facebook/gamingservices/TournamentFetcher:Xamarin.Facebook.GamingServices.TournamentFetcher",
					"com/facebook/gamingservices/TournamentFetcherKt:Xamarin.Facebook.GamingServices.TournamentFetcherKt", "com/facebook/gamingservices/TournamentShareDialog:Xamarin.Facebook.GamingServices.TournamentShareDialog", "com/facebook/gamingservices/TournamentShareDialog$Companion:Xamarin.Facebook.GamingServices.TournamentShareDialog/Companion", "com/facebook/gamingservices/TournamentShareDialog$Result:Xamarin.Facebook.GamingServices.TournamentShareDialog/Result", "com/facebook/gamingservices/TournamentUpdater:Xamarin.Facebook.GamingServices.TournamentUpdater", "com/facebook/gamingservices/TournamentUpdaterKt:Xamarin.Facebook.GamingServices.TournamentUpdaterKt"
				};
			}
			return Lookup(package_com_facebook_gamingservices_mappings, klass);
		}

		private static Type lookup_com_facebook_gamingservices_cloudgaming_package(string klass)
		{
			if (package_com_facebook_gamingservices_cloudgaming_mappings == null)
			{
				package_com_facebook_gamingservices_cloudgaming_mappings = new string[8] { "com/facebook/gamingservices/cloudgaming/AppToUserNotificationSender:Xamarin.Facebook.GamingServices.CloudGaming.AppToUserNotificationSender", "com/facebook/gamingservices/cloudgaming/CloudGameLoginHandler:Xamarin.Facebook.GamingServices.CloudGaming.CloudGameLoginHandler", "com/facebook/gamingservices/cloudgaming/DaemonReceiver:Xamarin.Facebook.GamingServices.CloudGaming.DaemonReceiver", "com/facebook/gamingservices/cloudgaming/DaemonRequest:Xamarin.Facebook.GamingServices.CloudGaming.DaemonRequest", "com/facebook/gamingservices/cloudgaming/GameFeaturesLibrary:Xamarin.Facebook.GamingServices.CloudGaming.GameFeaturesLibrary", "com/facebook/gamingservices/cloudgaming/InAppAdLibrary:Xamarin.Facebook.GamingServices.CloudGaming.InAppAdLibrary", "com/facebook/gamingservices/cloudgaming/InAppPurchaseLibrary:Xamarin.Facebook.GamingServices.CloudGaming.InAppPurchaseLibrary", "com/facebook/gamingservices/cloudgaming/PlayableAdsLibrary:Xamarin.Facebook.GamingServices.CloudGaming.PlayableAdsLibrary" };
			}
			return Lookup(package_com_facebook_gamingservices_cloudgaming_mappings, klass);
		}

		private static Type lookup_com_facebook_gamingservices_cloudgaming_internal_package(string klass)
		{
			if (package_com_facebook_gamingservices_cloudgaming_internal_mappings == null)
			{
				package_com_facebook_gamingservices_cloudgaming_internal_mappings = new string[5] { "com/facebook/gamingservices/cloudgaming/internal/SDKAnalyticsEvents:Xamarin.Facebook.GamingServices.CloudGaming.Internal.SDKAnalyticsEvents", "com/facebook/gamingservices/cloudgaming/internal/SDKConstants:Xamarin.Facebook.GamingServices.CloudGaming.Internal.SDKConstants", "com/facebook/gamingservices/cloudgaming/internal/SDKLogger:Xamarin.Facebook.GamingServices.CloudGaming.Internal.SDKLogger", "com/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum:Xamarin.Facebook.GamingServices.CloudGaming.Internal.SDKMessageEnum", "com/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum:Xamarin.Facebook.GamingServices.CloudGaming.Internal.SDKShareIntentEnum" };
			}
			return Lookup(package_com_facebook_gamingservices_cloudgaming_internal_mappings, klass);
		}

		private static Type lookup_com_facebook_gamingservices_internal_package(string klass)
		{
			if (package_com_facebook_gamingservices_internal_mappings == null)
			{
				package_com_facebook_gamingservices_internal_mappings = new string[3] { "com/facebook/gamingservices/internal/GamingMediaUploader:Xamarin.Facebook.GamingServices.Internal.GamingMediaUploader", "com/facebook/gamingservices/internal/TournamentScoreType:Xamarin.Facebook.GamingServices.Internal.TournamentScoreType", "com/facebook/gamingservices/internal/TournamentSortOrder:Xamarin.Facebook.GamingServices.Internal.TournamentSortOrder" };
			}
			return Lookup(package_com_facebook_gamingservices_internal_mappings, klass);
		}
	}
}
namespace Com.Facebook.Gamingservices.Model
{
	[Register("com/facebook/gamingservices/model/ContextChooseContent", DoNotGenerateAcw = true)]
	public class ContextChooseContent : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/gamingservices/model/ContextChooseContent$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/ContextChooseContent$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_readFrom_Lcom_facebook_gamingservices_model_ContextChooseContent_;

			private static Delegate cb_setFilters_Ljava_util_List_;

			private static Delegate cb_setMaxSize_Ljava_lang_Integer_;

			private static Delegate cb_setMinSize_Ljava_lang_Integer_;

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

			public Java.Lang.Object ReadFrom(Java.Lang.Object model)
			{
				if (model is ContextChooseContent content)
				{
					return ReadFrom(content);
				}
				return null;
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

			[Register("build", "()Lcom/facebook/gamingservices/model/ContextChooseContent;", "GetBuildHandler")]
			public unsafe virtual Java.Lang.Object Build()
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/facebook/gamingservices/model/ContextChooseContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetReadFrom_Lcom_facebook_gamingservices_model_ContextChooseContent_Handler()
			{
				if ((object)cb_readFrom_Lcom_facebook_gamingservices_model_ContextChooseContent_ == null)
				{
					cb_readFrom_Lcom_facebook_gamingservices_model_ContextChooseContent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadFrom_Lcom_facebook_gamingservices_model_ContextChooseContent_));
				}
				return cb_readFrom_Lcom_facebook_gamingservices_model_ContextChooseContent_;
			}

			private static IntPtr n_ReadFrom_Lcom_facebook_gamingservices_model_ContextChooseContent_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ContextChooseContent content = Java.Lang.Object.GetObject<ContextChooseContent>(native_content, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ReadFrom(content));
			}

			[Register("readFrom", "(Lcom/facebook/gamingservices/model/ContextChooseContent;)Lcom/facebook/gamingservices/model/ContextChooseContent$Builder;", "GetReadFrom_Lcom_facebook_gamingservices_model_ContextChooseContent_Handler")]
			public unsafe virtual Builder ReadFrom(ContextChooseContent content)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("readFrom.(Lcom/facebook/gamingservices/model/ContextChooseContent;)Lcom/facebook/gamingservices/model/ContextChooseContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(content);
				}
			}

			private static Delegate GetSetFilters_Ljava_util_List_Handler()
			{
				if ((object)cb_setFilters_Ljava_util_List_ == null)
				{
					cb_setFilters_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetFilters_Ljava_util_List_));
				}
				return cb_setFilters_Ljava_util_List_;
			}

			private static IntPtr n_SetFilters_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_filters)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<string> filters = JavaList<string>.FromJniHandle(native_filters, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetFilters(filters));
			}

			[Register("setFilters", "(Ljava/util/List;)Lcom/facebook/gamingservices/model/ContextChooseContent$Builder;", "GetSetFilters_Ljava_util_List_Handler")]
			public unsafe virtual Builder SetFilters(IList<string> filters)
			{
				IntPtr intPtr = JavaList<string>.ToLocalJniHandle(filters);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFilters.(Ljava/util/List;)Lcom/facebook/gamingservices/model/ContextChooseContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(filters);
				}
			}

			private static Delegate GetSetMaxSize_Ljava_lang_Integer_Handler()
			{
				if ((object)cb_setMaxSize_Ljava_lang_Integer_ == null)
				{
					cb_setMaxSize_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetMaxSize_Ljava_lang_Integer_));
				}
				return cb_setMaxSize_Ljava_lang_Integer_;
			}

			private static IntPtr n_SetMaxSize_Ljava_lang_Integer_(IntPtr jnienv, IntPtr native__this, IntPtr native_maxSize)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Integer maxSize = Java.Lang.Object.GetObject<Integer>(native_maxSize, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetMaxSize(maxSize));
			}

			[Register("setMaxSize", "(Ljava/lang/Integer;)Lcom/facebook/gamingservices/model/ContextChooseContent$Builder;", "GetSetMaxSize_Ljava_lang_Integer_Handler")]
			public unsafe virtual Builder SetMaxSize(Integer maxSize)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(maxSize?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMaxSize.(Ljava/lang/Integer;)Lcom/facebook/gamingservices/model/ContextChooseContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(maxSize);
				}
			}

			private static Delegate GetSetMinSize_Ljava_lang_Integer_Handler()
			{
				if ((object)cb_setMinSize_Ljava_lang_Integer_ == null)
				{
					cb_setMinSize_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetMinSize_Ljava_lang_Integer_));
				}
				return cb_setMinSize_Ljava_lang_Integer_;
			}

			private static IntPtr n_SetMinSize_Ljava_lang_Integer_(IntPtr jnienv, IntPtr native__this, IntPtr native_minSize)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Integer minSize = Java.Lang.Object.GetObject<Integer>(native_minSize, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetMinSize(minSize));
			}

			[Register("setMinSize", "(Ljava/lang/Integer;)Lcom/facebook/gamingservices/model/ContextChooseContent$Builder;", "GetSetMinSize_Ljava_lang_Integer_Handler")]
			public unsafe virtual Builder SetMinSize(Integer minSize)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(minSize?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMinSize.(Ljava/lang/Integer;)Lcom/facebook/gamingservices/model/ContextChooseContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(minSize);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/ContextChooseContent", typeof(ContextChooseContent));

		private static Delegate cb_getFilters;

		private static Delegate cb_getMaxSize;

		private static Delegate cb_getMinSize;

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

		public unsafe virtual IList<string> Filters
		{
			[Register("getFilters", "()Ljava/util/List;", "GetGetFiltersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getFilters.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Integer MaxSize
		{
			[Register("getMaxSize", "()Ljava/lang/Integer;", "GetGetMaxSizeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMaxSize.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Integer MinSize
		{
			[Register("getMinSize", "()Ljava/lang/Integer;", "GetGetMinSizeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMinSize.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ContextChooseContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetFiltersHandler()
		{
			if ((object)cb_getFilters == null)
			{
				cb_getFilters = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFilters));
			}
			return cb_getFilters;
		}

		private static IntPtr n_GetFilters(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextChooseContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Filters);
		}

		private static Delegate GetGetMaxSizeHandler()
		{
			if ((object)cb_getMaxSize == null)
			{
				cb_getMaxSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMaxSize));
			}
			return cb_getMaxSize;
		}

		private static IntPtr n_GetMaxSize(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextChooseContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxSize);
		}

		private static Delegate GetGetMinSizeHandler()
		{
			if ((object)cb_getMinSize == null)
			{
				cb_getMinSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMinSize));
			}
			return cb_getMinSize;
		}

		private static IntPtr n_GetMinSize(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextChooseContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinSize);
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
			return Java.Lang.Object.GetObject<ContextChooseContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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
			ContextChooseContent contextChooseContent = Java.Lang.Object.GetObject<ContextChooseContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel parcel = Java.Lang.Object.GetObject<Parcel>(native__out, JniHandleOwnership.DoNotTransfer);
			contextChooseContent.WriteToParcel(parcel, (ParcelableWriteFlags)native_flags);
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
	[Register("com/facebook/gamingservices/model/ContextSwitchContent", DoNotGenerateAcw = true)]
	public sealed class ContextSwitchContent : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/gamingservices/model/ContextSwitchContent$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/ContextSwitchContent$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_readFrom_Lcom_facebook_gamingservices_model_ContextSwitchContent_;

			private static Delegate cb_setContextID_Ljava_lang_String_;

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

			public Java.Lang.Object ReadFrom(Java.Lang.Object model)
			{
				if (model is ContextSwitchContent content)
				{
					return ReadFrom(content);
				}
				return null;
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

			[Register("build", "()Lcom/facebook/gamingservices/model/ContextSwitchContent;", "GetBuildHandler")]
			public unsafe virtual Java.Lang.Object Build()
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/facebook/gamingservices/model/ContextSwitchContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetReadFrom_Lcom_facebook_gamingservices_model_ContextSwitchContent_Handler()
			{
				if ((object)cb_readFrom_Lcom_facebook_gamingservices_model_ContextSwitchContent_ == null)
				{
					cb_readFrom_Lcom_facebook_gamingservices_model_ContextSwitchContent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadFrom_Lcom_facebook_gamingservices_model_ContextSwitchContent_));
				}
				return cb_readFrom_Lcom_facebook_gamingservices_model_ContextSwitchContent_;
			}

			private static IntPtr n_ReadFrom_Lcom_facebook_gamingservices_model_ContextSwitchContent_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ContextSwitchContent content = Java.Lang.Object.GetObject<ContextSwitchContent>(native_content, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ReadFrom(content));
			}

			[Register("readFrom", "(Lcom/facebook/gamingservices/model/ContextSwitchContent;)Lcom/facebook/gamingservices/model/ContextSwitchContent$Builder;", "GetReadFrom_Lcom_facebook_gamingservices_model_ContextSwitchContent_Handler")]
			public unsafe virtual Builder ReadFrom(ContextSwitchContent content)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("readFrom.(Lcom/facebook/gamingservices/model/ContextSwitchContent;)Lcom/facebook/gamingservices/model/ContextSwitchContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(content);
				}
			}

			private static Delegate GetSetContextID_Ljava_lang_String_Handler()
			{
				if ((object)cb_setContextID_Ljava_lang_String_ == null)
				{
					cb_setContextID_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetContextID_Ljava_lang_String_));
				}
				return cb_setContextID_Ljava_lang_String_;
			}

			private static IntPtr n_SetContextID_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_contextID)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string contextID = JNIEnv.GetString(native_contextID, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetContextID(contextID));
			}

			[Register("setContextID", "(Ljava/lang/String;)Lcom/facebook/gamingservices/model/ContextSwitchContent$Builder;", "GetSetContextID_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetContextID(string contextID)
			{
				IntPtr intPtr = JNIEnv.NewString(contextID);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setContextID.(Ljava/lang/String;)Lcom/facebook/gamingservices/model/ContextSwitchContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/ContextSwitchContent", typeof(ContextSwitchContent));

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

		public unsafe string ContextID
		{
			[Register("getContextID", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getContextID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ContextSwitchContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("describeContents", "()I", "")]
		public unsafe int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
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
	[Register("com/facebook/gamingservices/model/ContextCreateContent", DoNotGenerateAcw = true)]
	public class ContextCreateContent : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/gamingservices/model/ContextCreateContent$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/ContextCreateContent$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_readFrom_Lcom_facebook_gamingservices_model_ContextCreateContent_;

			private static Delegate cb_setSuggestedPlayerID_Ljava_lang_String_;

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

			public Java.Lang.Object ReadFrom(Java.Lang.Object model)
			{
				if (model is ContextCreateContent content)
				{
					return ReadFrom(content);
				}
				return null;
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

			[Register("build", "()Lcom/facebook/gamingservices/model/ContextCreateContent;", "GetBuildHandler")]
			public unsafe virtual Java.Lang.Object Build()
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/facebook/gamingservices/model/ContextCreateContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetReadFrom_Lcom_facebook_gamingservices_model_ContextCreateContent_Handler()
			{
				if ((object)cb_readFrom_Lcom_facebook_gamingservices_model_ContextCreateContent_ == null)
				{
					cb_readFrom_Lcom_facebook_gamingservices_model_ContextCreateContent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadFrom_Lcom_facebook_gamingservices_model_ContextCreateContent_));
				}
				return cb_readFrom_Lcom_facebook_gamingservices_model_ContextCreateContent_;
			}

			private static IntPtr n_ReadFrom_Lcom_facebook_gamingservices_model_ContextCreateContent_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ContextCreateContent content = Java.Lang.Object.GetObject<ContextCreateContent>(native_content, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.ReadFrom(content));
			}

			[Register("readFrom", "(Lcom/facebook/gamingservices/model/ContextCreateContent;)Lcom/facebook/gamingservices/model/ContextCreateContent$Builder;", "GetReadFrom_Lcom_facebook_gamingservices_model_ContextCreateContent_Handler")]
			public unsafe virtual Builder ReadFrom(ContextCreateContent content)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("readFrom.(Lcom/facebook/gamingservices/model/ContextCreateContent;)Lcom/facebook/gamingservices/model/ContextCreateContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(content);
				}
			}

			private static Delegate GetSetSuggestedPlayerID_Ljava_lang_String_Handler()
			{
				if ((object)cb_setSuggestedPlayerID_Ljava_lang_String_ == null)
				{
					cb_setSuggestedPlayerID_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSuggestedPlayerID_Ljava_lang_String_));
				}
				return cb_setSuggestedPlayerID_Ljava_lang_String_;
			}

			private static IntPtr n_SetSuggestedPlayerID_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_suggestedPlayerID)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string suggestedPlayerID = JNIEnv.GetString(native_suggestedPlayerID, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSuggestedPlayerID(suggestedPlayerID));
			}

			[Register("setSuggestedPlayerID", "(Ljava/lang/String;)Lcom/facebook/gamingservices/model/ContextCreateContent$Builder;", "GetSetSuggestedPlayerID_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetSuggestedPlayerID(string suggestedPlayerID)
			{
				IntPtr intPtr = JNIEnv.NewString(suggestedPlayerID);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSuggestedPlayerID.(Ljava/lang/String;)Lcom/facebook/gamingservices/model/ContextCreateContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/ContextCreateContent", typeof(ContextCreateContent));

		private static Delegate cb_getSuggestedPlayerID;

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

		public unsafe virtual string SuggestedPlayerID
		{
			[Register("getSuggestedPlayerID", "()Ljava/lang/String;", "GetGetSuggestedPlayerIDHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSuggestedPlayerID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ContextCreateContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetSuggestedPlayerIDHandler()
		{
			if ((object)cb_getSuggestedPlayerID == null)
			{
				cb_getSuggestedPlayerID = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSuggestedPlayerID));
			}
			return cb_getSuggestedPlayerID;
		}

		private static IntPtr n_GetSuggestedPlayerID(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ContextCreateContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SuggestedPlayerID);
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
			return Java.Lang.Object.GetObject<ContextCreateContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
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
			ContextCreateContent contextCreateContent = Java.Lang.Object.GetObject<ContextCreateContent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel parcel = Java.Lang.Object.GetObject<Parcel>(native__out, JniHandleOwnership.DoNotTransfer);
			contextCreateContent.WriteToParcel(parcel, (ParcelableWriteFlags)native_flags);
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
	[Register("com/facebook/gamingservices/model/CustomUpdateContent", DoNotGenerateAcw = true)]
	public sealed class CustomUpdateContent : Java.Lang.Object
	{
		[Register("com/facebook/gamingservices/model/CustomUpdateContent$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/CustomUpdateContent$Builder", typeof(Builder));

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

			public unsafe CustomUpdateLocalizedText Cta
			{
				[Register("getCta", "()Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;", "")]
				get
				{
					return Java.Lang.Object.GetObject<CustomUpdateLocalizedText>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCta.()Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe string Data
			{
				[Register("getData", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getData.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lcom/facebook/gamingservices/GamingContext;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Landroid/graphics/Bitmap;)V", "")]
			public unsafe Builder(GamingContext contextToken, CustomUpdateLocalizedText text, Bitmap image)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(contextToken?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(text?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/gamingservices/GamingContext;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Landroid/graphics/Bitmap;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/gamingservices/GamingContext;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Landroid/graphics/Bitmap;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(contextToken);
					GC.KeepAlive(text);
					GC.KeepAlive(image);
				}
			}

			[Register(".ctor", "(Lcom/facebook/gamingservices/GamingContext;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Lcom/facebook/gamingservices/model/CustomUpdateMedia;)V", "")]
			public unsafe Builder(GamingContext contextToken, CustomUpdateLocalizedText text, CustomUpdateMedia media)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(contextToken?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(text?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(media?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/gamingservices/GamingContext;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Lcom/facebook/gamingservices/model/CustomUpdateMedia;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/gamingservices/GamingContext;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Lcom/facebook/gamingservices/model/CustomUpdateMedia;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(contextToken);
					GC.KeepAlive(text);
					GC.KeepAlive(media);
				}
			}

			[Register("build", "()Lcom/facebook/gamingservices/model/CustomUpdateContent;", "")]
			public unsafe CustomUpdateContent Build()
			{
				return Java.Lang.Object.GetObject<CustomUpdateContent>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lcom/facebook/gamingservices/model/CustomUpdateContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setCta", "(Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;)Lcom/facebook/gamingservices/model/CustomUpdateContent$Builder;", "")]
			public unsafe Builder SetCta(CustomUpdateLocalizedText cta)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(cta?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setCta.(Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;)Lcom/facebook/gamingservices/model/CustomUpdateContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(cta);
				}
			}

			[Register("setData", "(Ljava/lang/String;)Lcom/facebook/gamingservices/model/CustomUpdateContent$Builder;", "")]
			public unsafe Builder SetData(string data)
			{
				IntPtr intPtr = JNIEnv.NewString(data);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setData.(Ljava/lang/String;)Lcom/facebook/gamingservices/model/CustomUpdateContent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/CustomUpdateContent", typeof(CustomUpdateContent));

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

		public unsafe string ContextTokenId
		{
			[Register("getContextTokenId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContextTokenId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe CustomUpdateLocalizedText Cta
		{
			[Register("getCta", "()Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CustomUpdateLocalizedText>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCta.()Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Data
		{
			[Register("getData", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getData.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Image
		{
			[Register("getImage", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getImage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe CustomUpdateMedia Media
		{
			[Register("getMedia", "()Lcom/facebook/gamingservices/model/CustomUpdateMedia;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CustomUpdateMedia>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getMedia.()Lcom/facebook/gamingservices/model/CustomUpdateMedia;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe CustomUpdateLocalizedText Text
		{
			[Register("getText", "()Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CustomUpdateLocalizedText>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getText.()Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CustomUpdateContent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Ljava/lang/String;Lcom/facebook/gamingservices/model/CustomUpdateMedia;Ljava/lang/String;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe CustomUpdateContent(string contextTokenId, CustomUpdateLocalizedText text, CustomUpdateLocalizedText cta, string image, CustomUpdateMedia media, string data, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(contextTokenId);
			IntPtr intPtr2 = JNIEnv.NewString(image);
			IntPtr intPtr3 = JNIEnv.NewString(data);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(text?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(cta?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(intPtr2);
				ptr[4] = new JniArgumentValue(media?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue(intPtr3);
				ptr[6] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Ljava/lang/String;Lcom/facebook/gamingservices/model/CustomUpdateMedia;Ljava/lang/String;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;Ljava/lang/String;Lcom/facebook/gamingservices/model/CustomUpdateMedia;Ljava/lang/String;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				GC.KeepAlive(text);
				GC.KeepAlive(cta);
				GC.KeepAlive(media);
				GC.KeepAlive(_constructor_marker);
			}
		}

		[Register("toGraphRequestContent", "()Lorg/json/JSONObject;", "")]
		public unsafe JSONObject ToGraphRequestContent()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toGraphRequestContent.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/facebook/gamingservices/model/CustomUpdateContentKt", DoNotGenerateAcw = true)]
	public sealed class CustomUpdateContentKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/CustomUpdateContentKt", typeof(CustomUpdateContentKt));

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

		internal CustomUpdateContentKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/facebook/gamingservices/model/CustomUpdateLocalizedText", DoNotGenerateAcw = true)]
	public sealed class CustomUpdateLocalizedText : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/CustomUpdateLocalizedText", typeof(CustomUpdateLocalizedText));

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

		public unsafe string Default
		{
			[Register("getDefault", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDefault.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IDictionary<string, string> Localizations
		{
			[Register("getLocalizations", "()Ljava/util/HashMap;", "")]
			get
			{
				return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLocalizations.()Ljava/util/HashMap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CustomUpdateLocalizedText(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/util/HashMap;)V", "")]
		public unsafe CustomUpdateLocalizedText(string @default, IDictionary<string, string> localizations)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(@default);
			IntPtr intPtr2 = JavaDictionary<string, string>.ToLocalJniHandle(localizations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/HashMap;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/HashMap;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(localizations);
			}
		}

		[Register("component1", "()Ljava/lang/String;", "")]
		public unsafe string Component1()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Ljava/util/HashMap;", "")]
		public unsafe IDictionary<string, string> Component2()
		{
			return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Ljava/util/HashMap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Ljava/lang/String;Ljava/util/HashMap;)Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;", "")]
		public unsafe CustomUpdateLocalizedText Copy(string @default, IDictionary<string, string> localizations)
		{
			IntPtr intPtr = JNIEnv.NewString(@default);
			IntPtr intPtr2 = JavaDictionary<string, string>.ToLocalJniHandle(localizations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<CustomUpdateLocalizedText>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;Ljava/util/HashMap;)Lcom/facebook/gamingservices/model/CustomUpdateLocalizedText;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(localizations);
			}
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "")]
		public unsafe JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/facebook/gamingservices/model/CustomUpdateMedia", DoNotGenerateAcw = true)]
	public sealed class CustomUpdateMedia : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/CustomUpdateMedia", typeof(CustomUpdateMedia));

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

		public unsafe CustomUpdateMediaInfo Gif
		{
			[Register("getGif", "()Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CustomUpdateMediaInfo>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getGif.()Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe CustomUpdateMediaInfo Video
		{
			[Register("getVideo", "()Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CustomUpdateMediaInfo>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getVideo.()Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CustomUpdateMedia(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CustomUpdateMedia()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;)V", "")]
		public unsafe CustomUpdateMedia(CustomUpdateMediaInfo gif, CustomUpdateMediaInfo video)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(gif?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(video?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(gif);
				GC.KeepAlive(video);
			}
		}

		[Register("component1", "()Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;", "")]
		public unsafe CustomUpdateMediaInfo Component1()
		{
			return Java.Lang.Object.GetObject<CustomUpdateMediaInfo>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;", "")]
		public unsafe CustomUpdateMediaInfo Component2()
		{
			return Java.Lang.Object.GetObject<CustomUpdateMediaInfo>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;)Lcom/facebook/gamingservices/model/CustomUpdateMedia;", "")]
		public unsafe CustomUpdateMedia Copy(CustomUpdateMediaInfo gif, CustomUpdateMediaInfo video)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(gif?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(video?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CustomUpdateMedia>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;)Lcom/facebook/gamingservices/model/CustomUpdateMedia;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(gif);
				GC.KeepAlive(video);
			}
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "")]
		public unsafe JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/facebook/gamingservices/model/CustomUpdateMediaInfo", DoNotGenerateAcw = true)]
	public sealed class CustomUpdateMediaInfo : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/model/CustomUpdateMediaInfo", typeof(CustomUpdateMediaInfo));

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

		public unsafe string Url
		{
			[Register("getUrl", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CustomUpdateMediaInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe CustomUpdateMediaInfo(string url)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(url);
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

		[Register("component1", "()Ljava/lang/String;", "")]
		public unsafe string Component1()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Ljava/lang/String;)Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;", "")]
		public unsafe CustomUpdateMediaInfo Copy(string url)
		{
			IntPtr intPtr = JNIEnv.NewString(url);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<CustomUpdateMediaInfo>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;)Lcom/facebook/gamingservices/model/CustomUpdateMediaInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
}
namespace Xamarin.Facebook.GamingServices
{
	[Register("com/facebook/gamingservices/FriendFinderDialog", DoNotGenerateAcw = true)]
	public class FriendFinderDialog : FacebookDialogBase
	{
		[Register("com/facebook/gamingservices/FriendFinderDialog$Result", DoNotGenerateAcw = true)]
		public class Result : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/FriendFinderDialog$Result", typeof(Result));

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

			protected Result(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Result()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/FriendFinderDialog", typeof(FriendFinderDialog));

		private static Delegate cb_getOrderedModeHandlers;

		private static Delegate cb_createBaseAppCall;

		private static Delegate cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_show;

		private static Delegate cb_show_Ljava_lang_Void_;

		private static Delegate cb_showImpl;

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

		protected unsafe virtual IList<FacebookDialogBase> OrderedModeHandlers
		{
			[Register("getOrderedModeHandlers", "()Ljava/util/List;", "GetGetOrderedModeHandlersHandler")]
			get
			{
				return JavaList<FacebookDialogBase>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrderedModeHandlers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected override IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}

		protected FriendFinderDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe FriendFinderDialog(Activity activity)
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

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe FriendFinderDialog(Android.App.Fragment fragment)
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
		public unsafe FriendFinderDialog(AndroidX.Fragment.App.Fragment fragment)
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
			return JavaList<FacebookDialogBase>.ToLocalJniHandle(Java.Lang.Object.GetObject<FriendFinderDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OrderedModeHandlers);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FriendFinderDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateBaseAppCall());
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
			FriendFinderDialog friendFinderDialog = Java.Lang.Object.GetObject<FriendFinderDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CallbackManagerImpl callbackManager = Java.Lang.Object.GetObject<CallbackManagerImpl>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			friendFinderDialog.RegisterCallbackImpl(callbackManager, callback);
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

		private static Delegate GetShowHandler()
		{
			if ((object)cb_show == null)
			{
				cb_show = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Show));
			}
			return cb_show;
		}

		private static void n_Show(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<FriendFinderDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show();
		}

		[Register("show", "()V", "GetShowHandler")]
		public unsafe virtual void Show()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("show.()V", this, null);
		}

		private static Delegate GetShow_Ljava_lang_Void_Handler()
		{
			if ((object)cb_show_Ljava_lang_Void_ == null)
			{
				cb_show_Ljava_lang_Void_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Show_Ljava_lang_Void_));
			}
			return cb_show_Ljava_lang_Void_;
		}

		private static void n_Show_Ljava_lang_Void_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
		{
			FriendFinderDialog friendFinderDialog = Java.Lang.Object.GetObject<FriendFinderDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Void content = Java.Lang.Object.GetObject<Java.Lang.Void>(native_content, JniHandleOwnership.DoNotTransfer);
			friendFinderDialog.Show(content);
		}

		[Register("show", "(Ljava/lang/Void;)V", "GetShow_Ljava_lang_Void_Handler")]
		public unsafe virtual void Show(Java.Lang.Void content)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("show.(Ljava/lang/Void;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
			}
		}

		private static Delegate GetShowImplHandler()
		{
			if ((object)cb_showImpl == null)
			{
				cb_showImpl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ShowImpl));
			}
			return cb_showImpl;
		}

		private static void n_ShowImpl(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<FriendFinderDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowImpl();
		}

		[Register("showImpl", "()V", "GetShowImplHandler")]
		protected unsafe virtual void ShowImpl()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("showImpl.()V", this, null);
		}
	}
	[Register("com/facebook/gamingservices/GamingGroupIntegration", DoNotGenerateAcw = true)]
	public class GamingGroupIntegration : FacebookDialogBase
	{
		[Register("com/facebook/gamingservices/GamingGroupIntegration$Result", DoNotGenerateAcw = true)]
		public class Result : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GamingGroupIntegration$Result", typeof(Result));

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

			protected Result(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Result()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GamingGroupIntegration", typeof(GamingGroupIntegration));

		private static Delegate cb_getOrderedModeHandlers;

		private static Delegate cb_createBaseAppCall;

		private static Delegate cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_show;

		private static Delegate cb_show_Ljava_lang_Void_;

		private static Delegate cb_showImpl;

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

		protected unsafe virtual IList<FacebookDialogBase> OrderedModeHandlers
		{
			[Register("getOrderedModeHandlers", "()Ljava/util/List;", "GetGetOrderedModeHandlersHandler")]
			get
			{
				return JavaList<FacebookDialogBase>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrderedModeHandlers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected override IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}

		protected GamingGroupIntegration(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe GamingGroupIntegration(Activity activity)
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

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe GamingGroupIntegration(Android.App.Fragment fragment)
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
		public unsafe GamingGroupIntegration(AndroidX.Fragment.App.Fragment fragment)
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
			return JavaList<FacebookDialogBase>.ToLocalJniHandle(Java.Lang.Object.GetObject<GamingGroupIntegration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OrderedModeHandlers);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GamingGroupIntegration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateBaseAppCall());
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
			GamingGroupIntegration gamingGroupIntegration = Java.Lang.Object.GetObject<GamingGroupIntegration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CallbackManagerImpl callbackManager = Java.Lang.Object.GetObject<CallbackManagerImpl>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			gamingGroupIntegration.RegisterCallbackImpl(callbackManager, callback);
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

		private static Delegate GetShowHandler()
		{
			if ((object)cb_show == null)
			{
				cb_show = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Show));
			}
			return cb_show;
		}

		private static void n_Show(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<GamingGroupIntegration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show();
		}

		[Register("show", "()V", "GetShowHandler")]
		public unsafe virtual void Show()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("show.()V", this, null);
		}

		private static Delegate GetShow_Ljava_lang_Void_Handler()
		{
			if ((object)cb_show_Ljava_lang_Void_ == null)
			{
				cb_show_Ljava_lang_Void_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Show_Ljava_lang_Void_));
			}
			return cb_show_Ljava_lang_Void_;
		}

		private static void n_Show_Ljava_lang_Void_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
		{
			GamingGroupIntegration gamingGroupIntegration = Java.Lang.Object.GetObject<GamingGroupIntegration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Void content = Java.Lang.Object.GetObject<Java.Lang.Void>(native_content, JniHandleOwnership.DoNotTransfer);
			gamingGroupIntegration.Show(content);
		}

		[Register("show", "(Ljava/lang/Void;)V", "GetShow_Ljava_lang_Void_Handler")]
		public unsafe virtual void Show(Java.Lang.Void content)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("show.(Ljava/lang/Void;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
			}
		}

		private static Delegate GetShowImplHandler()
		{
			if ((object)cb_showImpl == null)
			{
				cb_showImpl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ShowImpl));
			}
			return cb_showImpl;
		}

		private static void n_ShowImpl(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<GamingGroupIntegration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowImpl();
		}

		[Register("showImpl", "()V", "GetShowImplHandler")]
		protected unsafe virtual void ShowImpl()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("showImpl.()V", this, null);
		}
	}
	[Register("com/facebook/gamingservices/GameRequestDialog", DoNotGenerateAcw = true)]
	public class GameRequestDialog : FacebookDialogBase
	{
		[Register("com/facebook/gamingservices/GameRequestDialog$Result", DoNotGenerateAcw = true)]
		public sealed class Result : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GameRequestDialog$Result", typeof(Result));

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

			public unsafe string RequestId
			{
				[Register("getRequestId", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getRequestId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe IList<string> RequestRecipients
			{
				[Register("getRequestRecipients", "()Ljava/util/List;", "")]
				get
				{
					return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getRequestRecipients.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Result(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GameRequestDialog", typeof(GameRequestDialog));

		private static Delegate cb_getOrderedModeHandlers;

		private static Delegate cb_createBaseAppCall;

		private static Delegate cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_showImpl_Lcom_facebook_share_model_GameRequestContent_Ljava_lang_Object_;

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

		protected unsafe virtual IList<FacebookDialogBase> OrderedModeHandlers
		{
			[Register("getOrderedModeHandlers", "()Ljava/util/List;", "GetGetOrderedModeHandlersHandler")]
			get
			{
				return JavaList<FacebookDialogBase>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrderedModeHandlers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected override IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}

		protected GameRequestDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe GameRequestDialog(Activity activity)
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

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe GameRequestDialog(Android.App.Fragment fragment)
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
		public unsafe GameRequestDialog(AndroidX.Fragment.App.Fragment fragment)
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
			return JavaList<FacebookDialogBase>.ToLocalJniHandle(Java.Lang.Object.GetObject<GameRequestDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OrderedModeHandlers);
		}

		[Register("canShow", "()Z", "")]
		public unsafe static bool CanShow()
		{
			return _members.StaticMethods.InvokeBooleanMethod("canShow.()Z", null);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GameRequestDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateBaseAppCall());
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
			GameRequestDialog gameRequestDialog = Java.Lang.Object.GetObject<GameRequestDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CallbackManagerImpl callbackManager = Java.Lang.Object.GetObject<CallbackManagerImpl>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			gameRequestDialog.RegisterCallbackImpl(callbackManager, callback);
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

		[Register("show", "(Landroid/app/Activity;Lcom/facebook/share/model/GameRequestContent;)V", "")]
		public unsafe static void Show(Activity activity, GameRequestContent gameRequestContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(gameRequestContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroid/app/Activity;Lcom/facebook/share/model/GameRequestContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(gameRequestContent);
			}
		}

		[Register("show", "(Landroid/app/Fragment;Lcom/facebook/share/model/GameRequestContent;)V", "")]
		public unsafe static void Show(Android.App.Fragment fragment, GameRequestContent gameRequestContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(gameRequestContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroid/app/Fragment;Lcom/facebook/share/model/GameRequestContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(gameRequestContent);
			}
		}

		[Register("show", "(Landroidx/fragment/app/Fragment;Lcom/facebook/share/model/GameRequestContent;)V", "")]
		public unsafe static void Show(AndroidX.Fragment.App.Fragment fragment, GameRequestContent gameRequestContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(gameRequestContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroidx/fragment/app/Fragment;Lcom/facebook/share/model/GameRequestContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(gameRequestContent);
			}
		}

		private static Delegate GetShowImpl_Lcom_facebook_share_model_GameRequestContent_Ljava_lang_Object_Handler()
		{
			if ((object)cb_showImpl_Lcom_facebook_share_model_GameRequestContent_Ljava_lang_Object_ == null)
			{
				cb_showImpl_Lcom_facebook_share_model_GameRequestContent_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ShowImpl_Lcom_facebook_share_model_GameRequestContent_Ljava_lang_Object_));
			}
			return cb_showImpl_Lcom_facebook_share_model_GameRequestContent_Ljava_lang_Object_;
		}

		private static void n_ShowImpl_Lcom_facebook_share_model_GameRequestContent_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_content, IntPtr native_mode)
		{
			GameRequestDialog gameRequestDialog = Java.Lang.Object.GetObject<GameRequestDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			GameRequestContent content = Java.Lang.Object.GetObject<GameRequestContent>(native_content, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object mode = Java.Lang.Object.GetObject<Java.Lang.Object>(native_mode, JniHandleOwnership.DoNotTransfer);
			gameRequestDialog.ShowImpl(content, mode);
		}

		[Register("showImpl", "(Lcom/facebook/share/model/GameRequestContent;Ljava/lang/Object;)V", "GetShowImpl_Lcom_facebook_share_model_GameRequestContent_Ljava_lang_Object_Handler")]
		protected unsafe virtual void ShowImpl(GameRequestContent content, Java.Lang.Object mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("showImpl.(Lcom/facebook/share/model/GameRequestContent;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(mode);
			}
		}
	}
	[Register("com/facebook/gamingservices/ContextChooseDialog", DoNotGenerateAcw = true)]
	public class ContextChooseDialog : FacebookDialogBase
	{
		[Register("com/facebook/gamingservices/ContextChooseDialog$Result", DoNotGenerateAcw = true)]
		public sealed class Result : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/ContextChooseDialog$Result", typeof(Result));

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

			public unsafe string ContextID
			{
				[Register("getContextID", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getContextID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Result(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/ContextChooseDialog", typeof(ContextChooseDialog));

		private static Delegate cb_getOrderedModeHandlers;

		private static Delegate cb_canShow_Lcom_facebook_gamingservices_model_ContextChooseContent_;

		private static Delegate cb_createBaseAppCall;

		private static Delegate cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_showImpl_Lcom_facebook_gamingservices_model_ContextChooseContent_Ljava_lang_Object_;

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

		protected unsafe virtual IList<FacebookDialogBase> OrderedModeHandlers
		{
			[Register("getOrderedModeHandlers", "()Ljava/util/List;", "GetGetOrderedModeHandlersHandler")]
			get
			{
				return JavaList<FacebookDialogBase>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrderedModeHandlers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected override IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}

		protected ContextChooseDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe ContextChooseDialog(Activity activity)
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

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe ContextChooseDialog(Android.App.Fragment fragment)
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
		public unsafe ContextChooseDialog(AndroidX.Fragment.App.Fragment fragment)
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
			return JavaList<FacebookDialogBase>.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextChooseDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OrderedModeHandlers);
		}

		private static Delegate GetCanShow_Lcom_facebook_gamingservices_model_ContextChooseContent_Handler()
		{
			if ((object)cb_canShow_Lcom_facebook_gamingservices_model_ContextChooseContent_ == null)
			{
				cb_canShow_Lcom_facebook_gamingservices_model_ContextChooseContent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_CanShow_Lcom_facebook_gamingservices_model_ContextChooseContent_));
			}
			return cb_canShow_Lcom_facebook_gamingservices_model_ContextChooseContent_;
		}

		private static bool n_CanShow_Lcom_facebook_gamingservices_model_ContextChooseContent_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
		{
			ContextChooseDialog contextChooseDialog = Java.Lang.Object.GetObject<ContextChooseDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ContextChooseContent content = Java.Lang.Object.GetObject<ContextChooseContent>(native_content, JniHandleOwnership.DoNotTransfer);
			return contextChooseDialog.CanShow(content);
		}

		[Register("canShow", "(Lcom/facebook/gamingservices/model/ContextChooseContent;)Z", "GetCanShow_Lcom_facebook_gamingservices_model_ContextChooseContent_Handler")]
		public unsafe virtual bool CanShow(ContextChooseContent content)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canShow.(Lcom/facebook/gamingservices/model/ContextChooseContent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextChooseDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateBaseAppCall());
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
			ContextChooseDialog contextChooseDialog = Java.Lang.Object.GetObject<ContextChooseDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CallbackManagerImpl callbackManager = Java.Lang.Object.GetObject<CallbackManagerImpl>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			contextChooseDialog.RegisterCallbackImpl(callbackManager, callback);
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

		private static Delegate GetShowImpl_Lcom_facebook_gamingservices_model_ContextChooseContent_Ljava_lang_Object_Handler()
		{
			if ((object)cb_showImpl_Lcom_facebook_gamingservices_model_ContextChooseContent_Ljava_lang_Object_ == null)
			{
				cb_showImpl_Lcom_facebook_gamingservices_model_ContextChooseContent_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ShowImpl_Lcom_facebook_gamingservices_model_ContextChooseContent_Ljava_lang_Object_));
			}
			return cb_showImpl_Lcom_facebook_gamingservices_model_ContextChooseContent_Ljava_lang_Object_;
		}

		private static void n_ShowImpl_Lcom_facebook_gamingservices_model_ContextChooseContent_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_content, IntPtr native_mode)
		{
			ContextChooseDialog contextChooseDialog = Java.Lang.Object.GetObject<ContextChooseDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ContextChooseContent content = Java.Lang.Object.GetObject<ContextChooseContent>(native_content, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object mode = Java.Lang.Object.GetObject<Java.Lang.Object>(native_mode, JniHandleOwnership.DoNotTransfer);
			contextChooseDialog.ShowImpl(content, mode);
		}

		[Register("showImpl", "(Lcom/facebook/gamingservices/model/ContextChooseContent;Ljava/lang/Object;)V", "GetShowImpl_Lcom_facebook_gamingservices_model_ContextChooseContent_Ljava_lang_Object_Handler")]
		protected unsafe virtual void ShowImpl(ContextChooseContent content, Java.Lang.Object mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("showImpl.(Lcom/facebook/gamingservices/model/ContextChooseContent;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(mode);
			}
		}
	}
	[Register("com/facebook/gamingservices/ContextCreateDialog", DoNotGenerateAcw = true)]
	public class ContextCreateDialog : FacebookDialogBase
	{
		[Register("com/facebook/gamingservices/ContextCreateDialog$Result", DoNotGenerateAcw = true)]
		public sealed class Result : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/ContextCreateDialog$Result", typeof(Result));

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

			public unsafe string ContextID
			{
				[Register("getContextID", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getContextID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Result(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/ContextCreateDialog", typeof(ContextCreateDialog));

		private static Delegate cb_getOrderedModeHandlers;

		private static Delegate cb_canShow_Lcom_facebook_gamingservices_model_ContextCreateContent_;

		private static Delegate cb_createBaseAppCall;

		private static Delegate cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_showImpl_Lcom_facebook_gamingservices_model_ContextCreateContent_Ljava_lang_Object_;

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

		protected unsafe virtual IList<FacebookDialogBase> OrderedModeHandlers
		{
			[Register("getOrderedModeHandlers", "()Ljava/util/List;", "GetGetOrderedModeHandlersHandler")]
			get
			{
				return JavaList<FacebookDialogBase>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrderedModeHandlers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected override IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}

		protected ContextCreateDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe ContextCreateDialog(Activity activity)
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

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe ContextCreateDialog(Android.App.Fragment fragment)
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
		public unsafe ContextCreateDialog(AndroidX.Fragment.App.Fragment fragment)
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
			return JavaList<FacebookDialogBase>.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextCreateDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OrderedModeHandlers);
		}

		private static Delegate GetCanShow_Lcom_facebook_gamingservices_model_ContextCreateContent_Handler()
		{
			if ((object)cb_canShow_Lcom_facebook_gamingservices_model_ContextCreateContent_ == null)
			{
				cb_canShow_Lcom_facebook_gamingservices_model_ContextCreateContent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_CanShow_Lcom_facebook_gamingservices_model_ContextCreateContent_));
			}
			return cb_canShow_Lcom_facebook_gamingservices_model_ContextCreateContent_;
		}

		private static bool n_CanShow_Lcom_facebook_gamingservices_model_ContextCreateContent_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
		{
			ContextCreateDialog contextCreateDialog = Java.Lang.Object.GetObject<ContextCreateDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ContextCreateContent content = Java.Lang.Object.GetObject<ContextCreateContent>(native_content, JniHandleOwnership.DoNotTransfer);
			return contextCreateDialog.CanShow(content);
		}

		[Register("canShow", "(Lcom/facebook/gamingservices/model/ContextCreateContent;)Z", "GetCanShow_Lcom_facebook_gamingservices_model_ContextCreateContent_Handler")]
		public unsafe virtual bool CanShow(ContextCreateContent content)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canShow.(Lcom/facebook/gamingservices/model/ContextCreateContent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextCreateDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateBaseAppCall());
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
			ContextCreateDialog contextCreateDialog = Java.Lang.Object.GetObject<ContextCreateDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CallbackManagerImpl callbackManager = Java.Lang.Object.GetObject<CallbackManagerImpl>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			contextCreateDialog.RegisterCallbackImpl(callbackManager, callback);
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

		private static Delegate GetShowImpl_Lcom_facebook_gamingservices_model_ContextCreateContent_Ljava_lang_Object_Handler()
		{
			if ((object)cb_showImpl_Lcom_facebook_gamingservices_model_ContextCreateContent_Ljava_lang_Object_ == null)
			{
				cb_showImpl_Lcom_facebook_gamingservices_model_ContextCreateContent_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ShowImpl_Lcom_facebook_gamingservices_model_ContextCreateContent_Ljava_lang_Object_));
			}
			return cb_showImpl_Lcom_facebook_gamingservices_model_ContextCreateContent_Ljava_lang_Object_;
		}

		private static void n_ShowImpl_Lcom_facebook_gamingservices_model_ContextCreateContent_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_content, IntPtr native_mode)
		{
			ContextCreateDialog contextCreateDialog = Java.Lang.Object.GetObject<ContextCreateDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ContextCreateContent content = Java.Lang.Object.GetObject<ContextCreateContent>(native_content, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object mode = Java.Lang.Object.GetObject<Java.Lang.Object>(native_mode, JniHandleOwnership.DoNotTransfer);
			contextCreateDialog.ShowImpl(content, mode);
		}

		[Register("showImpl", "(Lcom/facebook/gamingservices/model/ContextCreateContent;Ljava/lang/Object;)V", "GetShowImpl_Lcom_facebook_gamingservices_model_ContextCreateContent_Ljava_lang_Object_Handler")]
		protected unsafe virtual void ShowImpl(ContextCreateContent content, Java.Lang.Object mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("showImpl.(Lcom/facebook/gamingservices/model/ContextCreateContent;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(mode);
			}
		}
	}
	[Register("com/facebook/gamingservices/ContextSwitchDialog", DoNotGenerateAcw = true)]
	public class ContextSwitchDialog : FacebookDialogBase
	{
		[Register("com/facebook/gamingservices/ContextSwitchDialog$Result", DoNotGenerateAcw = true)]
		public sealed class Result : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/ContextSwitchDialog$Result", typeof(Result));

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

			public unsafe string ContextID
			{
				[Register("getContextID", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getContextID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Result(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/ContextSwitchDialog", typeof(ContextSwitchDialog));

		private static Delegate cb_getOrderedModeHandlers;

		private static Delegate cb_canShow_Lcom_facebook_gamingservices_model_ContextSwitchContent_;

		private static Delegate cb_createBaseAppCall;

		private static Delegate cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_showImpl_Lcom_facebook_gamingservices_model_ContextSwitchContent_Ljava_lang_Object_;

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

		protected unsafe virtual IList<FacebookDialogBase> OrderedModeHandlers
		{
			[Register("getOrderedModeHandlers", "()Ljava/util/List;", "GetGetOrderedModeHandlersHandler")]
			get
			{
				return JavaList<FacebookDialogBase>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrderedModeHandlers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected override IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}

		protected ContextSwitchDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe ContextSwitchDialog(Activity activity)
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

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe ContextSwitchDialog(Android.App.Fragment fragment)
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
		public unsafe ContextSwitchDialog(AndroidX.Fragment.App.Fragment fragment)
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
			return JavaList<FacebookDialogBase>.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextSwitchDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OrderedModeHandlers);
		}

		private static Delegate GetCanShow_Lcom_facebook_gamingservices_model_ContextSwitchContent_Handler()
		{
			if ((object)cb_canShow_Lcom_facebook_gamingservices_model_ContextSwitchContent_ == null)
			{
				cb_canShow_Lcom_facebook_gamingservices_model_ContextSwitchContent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_CanShow_Lcom_facebook_gamingservices_model_ContextSwitchContent_));
			}
			return cb_canShow_Lcom_facebook_gamingservices_model_ContextSwitchContent_;
		}

		private static bool n_CanShow_Lcom_facebook_gamingservices_model_ContextSwitchContent_(IntPtr jnienv, IntPtr native__this, IntPtr native_content)
		{
			ContextSwitchDialog contextSwitchDialog = Java.Lang.Object.GetObject<ContextSwitchDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ContextSwitchContent content = Java.Lang.Object.GetObject<ContextSwitchContent>(native_content, JniHandleOwnership.DoNotTransfer);
			return contextSwitchDialog.CanShow(content);
		}

		[Register("canShow", "(Lcom/facebook/gamingservices/model/ContextSwitchContent;)Z", "GetCanShow_Lcom_facebook_gamingservices_model_ContextSwitchContent_Handler")]
		public unsafe virtual bool CanShow(ContextSwitchContent content)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canShow.(Lcom/facebook/gamingservices/model/ContextSwitchContent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ContextSwitchDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateBaseAppCall());
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
			ContextSwitchDialog contextSwitchDialog = Java.Lang.Object.GetObject<ContextSwitchDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CallbackManagerImpl callbackManager = Java.Lang.Object.GetObject<CallbackManagerImpl>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			contextSwitchDialog.RegisterCallbackImpl(callbackManager, callback);
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

		private static Delegate GetShowImpl_Lcom_facebook_gamingservices_model_ContextSwitchContent_Ljava_lang_Object_Handler()
		{
			if ((object)cb_showImpl_Lcom_facebook_gamingservices_model_ContextSwitchContent_Ljava_lang_Object_ == null)
			{
				cb_showImpl_Lcom_facebook_gamingservices_model_ContextSwitchContent_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ShowImpl_Lcom_facebook_gamingservices_model_ContextSwitchContent_Ljava_lang_Object_));
			}
			return cb_showImpl_Lcom_facebook_gamingservices_model_ContextSwitchContent_Ljava_lang_Object_;
		}

		private static void n_ShowImpl_Lcom_facebook_gamingservices_model_ContextSwitchContent_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_content, IntPtr native_mode)
		{
			ContextSwitchDialog contextSwitchDialog = Java.Lang.Object.GetObject<ContextSwitchDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ContextSwitchContent content = Java.Lang.Object.GetObject<ContextSwitchContent>(native_content, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object mode = Java.Lang.Object.GetObject<Java.Lang.Object>(native_mode, JniHandleOwnership.DoNotTransfer);
			contextSwitchDialog.ShowImpl(content, mode);
		}

		[Register("showImpl", "(Lcom/facebook/gamingservices/model/ContextSwitchContent;Ljava/lang/Object;)V", "GetShowImpl_Lcom_facebook_gamingservices_model_ContextSwitchContent_Ljava_lang_Object_Handler")]
		protected unsafe virtual void ShowImpl(ContextSwitchContent content, Java.Lang.Object mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("showImpl.(Lcom/facebook/gamingservices/model/ContextSwitchContent;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(mode);
			}
		}
	}
	[Register("com/facebook/gamingservices/TournamentShareDialog", DoNotGenerateAcw = true)]
	public sealed class TournamentShareDialog : FacebookDialogBase
	{
		[Register("com/facebook/gamingservices/TournamentShareDialog$Companion", DoNotGenerateAcw = true)]
		public new sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/TournamentShareDialog$Companion", typeof(Companion));

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

		[Register("com/facebook/gamingservices/TournamentShareDialog$Result", DoNotGenerateAcw = true)]
		public sealed class Result : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/TournamentShareDialog$Result", typeof(Result));

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

			public unsafe string RequestID
			{
				[Register("getRequestID", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getRequestID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setRequestID", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setRequestID.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			public unsafe string TournamentID
			{
				[Register("getTournamentID", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTournamentID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setTournamentID", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setTournamentID.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			internal Result(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/os/Bundle;)V", "")]
			public unsafe Result(Bundle results)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(results?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Bundle;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Bundle;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(results);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/TournamentShareDialog", typeof(TournamentShareDialog));

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

		protected unsafe IList<FacebookDialogBase> OrderedModeHandlers
		{
			[Register("getOrderedModeHandlers", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<FacebookDialogBase>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getOrderedModeHandlers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Number Score
		{
			[Register("getScore", "()Ljava/lang/Number;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Number>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getScore.()Ljava/lang/Number;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setScore", "(Ljava/lang/Number;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setScore.(Ljava/lang/Number;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Tournament Tournament
		{
			[Register("getTournament", "()Lcom/facebook/gamingservices/Tournament;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Tournament>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTournament.()Lcom/facebook/gamingservices/Tournament;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTournament", "(Lcom/facebook/gamingservices/Tournament;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setTournament.(Lcom/facebook/gamingservices/Tournament;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected override IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}

		internal TournamentShareDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe TournamentShareDialog(Activity activity)
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

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe TournamentShareDialog(Android.App.Fragment fragment)
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
		public unsafe TournamentShareDialog(AndroidX.Fragment.App.Fragment fragment)
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

		[Register("createBaseAppCall", "()Lcom/facebook/internal/AppCall;", "")]
		protected unsafe override AppCall CreateBaseAppCall()
		{
			return Java.Lang.Object.GetObject<AppCall>(_members.InstanceMethods.InvokeAbstractObjectMethod("createBaseAppCall.()Lcom/facebook/internal/AppCall;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("registerCallbackImpl", "(Lcom/facebook/internal/CallbackManagerImpl;Lcom/facebook/FacebookCallback;)V", "")]
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

		[Register("show", "(Ljava/lang/Number;Lcom/facebook/gamingservices/Tournament;)V", "")]
		public unsafe void Show(Number score, Tournament tournament)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(score?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(tournament?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("show.(Ljava/lang/Number;Lcom/facebook/gamingservices/Tournament;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(score);
				GC.KeepAlive(tournament);
			}
		}

		[Register("show", "(Ljava/lang/Number;Lcom/facebook/gamingservices/TournamentConfig;)V", "")]
		public unsafe void Show(Number score, TournamentConfig newTournamentConfig)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(score?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newTournamentConfig?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("show.(Ljava/lang/Number;Lcom/facebook/gamingservices/TournamentConfig;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(score);
				GC.KeepAlive(newTournamentConfig);
			}
		}

		[Register("showImpl", "(Lcom/facebook/gamingservices/TournamentConfig;Ljava/lang/Object;)V", "")]
		private unsafe void ShowImpl(TournamentConfig content, Java.Lang.Object mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("showImpl.(Lcom/facebook/gamingservices/TournamentConfig;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(mode);
			}
		}
	}
	[Register("com/facebook/gamingservices/TournamentConfig", DoNotGenerateAcw = true)]
	public sealed class TournamentConfig : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/gamingservices/TournamentConfig$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object, IShareModelBuilder, IShareBuilder, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/TournamentConfig$Builder", typeof(Builder));

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

			public unsafe Image Image
			{
				[Register("getImage", "()Landroid/media/Image;", "")]
				get
				{
					return Java.Lang.Object.GetObject<Image>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getImage.()Landroid/media/Image;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setImage", "(Landroid/media/Image;)V", "")]
				set
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setImage.(Landroid/media/Image;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(value);
					}
				}
			}

			public unsafe string Payload
			{
				[Register("getPayload", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPayload.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setPayload", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPayload.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			public unsafe TournamentScoreType ScoreType
			{
				[Register("getScoreType", "()Lcom/facebook/gamingservices/internal/TournamentScoreType;", "")]
				get
				{
					return Java.Lang.Object.GetObject<TournamentScoreType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getScoreType.()Lcom/facebook/gamingservices/internal/TournamentScoreType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setScoreType", "(Lcom/facebook/gamingservices/internal/TournamentScoreType;)V", "")]
				set
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setScoreType.(Lcom/facebook/gamingservices/internal/TournamentScoreType;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(value);
					}
				}
			}

			public unsafe TournamentSortOrder SortOrder
			{
				[Register("getSortOrder", "()Lcom/facebook/gamingservices/internal/TournamentSortOrder;", "")]
				get
				{
					return Java.Lang.Object.GetObject<TournamentSortOrder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSortOrder.()Lcom/facebook/gamingservices/internal/TournamentSortOrder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setSortOrder", "(Lcom/facebook/gamingservices/internal/TournamentSortOrder;)V", "")]
				set
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setSortOrder.(Lcom/facebook/gamingservices/internal/TournamentSortOrder;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(value);
					}
				}
			}

			public unsafe string Title
			{
				[Register("getTitle", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setTitle", "(Ljava/lang/String;)V", "")]
				set
				{
					IntPtr intPtr = JNIEnv.NewString(value);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setTitle.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			public Java.Lang.Object ReadFrom(Java.Lang.Object model)
			{
				if (model is TournamentConfig model2)
				{
					return ReadFrom(model2);
				}
				return null;
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

			[Register("build", "()Lcom/facebook/gamingservices/TournamentConfig;", "")]
			public unsafe Java.Lang.Object Build()
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/facebook/gamingservices/TournamentConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("readFrom", "(Lcom/facebook/gamingservices/TournamentConfig;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", "")]
			public unsafe Builder ReadFrom(TournamentConfig model)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(model?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("readFrom.(Lcom/facebook/gamingservices/TournamentConfig;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(model);
				}
			}

			[Register("setTournamentImage", "(Landroid/media/Image;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", "")]
			public unsafe Builder SetTournamentImage(Image image)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setTournamentImage.(Landroid/media/Image;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(image);
				}
			}

			[Register("setTournamentPayload", "(Ljava/lang/String;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", "")]
			public unsafe Builder SetTournamentPayload(string payload)
			{
				IntPtr intPtr = JNIEnv.NewString(payload);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setTournamentPayload.(Ljava/lang/String;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setTournamentScoreType", "(Lcom/facebook/gamingservices/internal/TournamentScoreType;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", "")]
			public unsafe Builder SetTournamentScoreType(TournamentScoreType scoreType)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(scoreType?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setTournamentScoreType.(Lcom/facebook/gamingservices/internal/TournamentScoreType;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(scoreType);
				}
			}

			[Register("setTournamentSortOrder", "(Lcom/facebook/gamingservices/internal/TournamentSortOrder;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", "")]
			public unsafe Builder SetTournamentSortOrder(TournamentSortOrder sortOrder)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(sortOrder?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setTournamentSortOrder.(Lcom/facebook/gamingservices/internal/TournamentSortOrder;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(sortOrder);
				}
			}

			[Register("setTournamentTitle", "(Ljava/lang/String;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", "")]
			public unsafe Builder SetTournamentTitle(string title)
			{
				IntPtr intPtr = JNIEnv.NewString(title);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setTournamentTitle.(Ljava/lang/String;)Lcom/facebook/gamingservices/TournamentConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("com/facebook/gamingservices/TournamentConfig$CREATOR", DoNotGenerateAcw = true)]
		public sealed class CREATOR : Java.Lang.Object, IParcelableCreator, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/TournamentConfig$CREATOR", typeof(CREATOR));

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

			internal CREATOR(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe CREATOR(DefaultConstructorMarker _constructor_marker)
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

			[Register("createFromParcel", "(Landroid/os/Parcel;)Lcom/facebook/gamingservices/TournamentConfig;", "")]
			public unsafe Java.Lang.Object CreateFromParcel(Parcel parcel)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("createFromParcel.(Landroid/os/Parcel;)Lcom/facebook/gamingservices/TournamentConfig;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(parcel);
				}
			}

			[Register("newArray", "(I)[Lcom/facebook/gamingservices/TournamentConfig;", "")]
			public unsafe Java.Lang.Object[] NewArray(int size)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(size);
				return (TournamentConfig[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("newArray.(I)[Lcom/facebook/gamingservices/TournamentConfig;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(TournamentConfig));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/TournamentConfig", typeof(TournamentConfig));

		[Register("CREATOR")]
		public static CREATOR Creator => Java.Lang.Object.GetObject<CREATOR>(_members.StaticFields.GetObjectValue("CREATOR.Lcom/facebook/gamingservices/TournamentConfig$CREATOR;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe Image Image
		{
			[Register("getImage", "()Landroid/media/Image;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Image>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getImage.()Landroid/media/Image;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Payload
		{
			[Register("getPayload", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPayload.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe TournamentScoreType ScoreType
		{
			[Register("getScoreType", "()Lcom/facebook/gamingservices/internal/TournamentScoreType;", "")]
			get
			{
				return Java.Lang.Object.GetObject<TournamentScoreType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getScoreType.()Lcom/facebook/gamingservices/internal/TournamentScoreType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe TournamentSortOrder SortOrder
		{
			[Register("getSortOrder", "()Lcom/facebook/gamingservices/internal/TournamentSortOrder;", "")]
			get
			{
				return Java.Lang.Object.GetObject<TournamentSortOrder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSortOrder.()Lcom/facebook/gamingservices/internal/TournamentSortOrder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal TournamentConfig(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/gamingservices/TournamentConfig$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe TournamentConfig(Builder builder, DefaultConstructorMarker _constructor_marker)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/gamingservices/TournamentConfig$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/gamingservices/TournamentConfig$Builder;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
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
	[Register("com/facebook/gamingservices/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("LIBRARY_PACKAGE_NAME")]
		public const string LibraryPackageName = "com.facebook.gamingservices";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/BuildConfig", typeof(BuildConfig));

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
	[Register("com/facebook/gamingservices/CustomUpdate", DoNotGenerateAcw = true)]
	public sealed class CustomUpdate : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/CustomUpdate", typeof(CustomUpdate));

		[Register("INSTANCE")]
		public static CustomUpdate Instance => Java.Lang.Object.GetObject<CustomUpdate>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/facebook/gamingservices/CustomUpdate;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal CustomUpdate(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("newCustomUpdateRequest", "(Lcom/facebook/gamingservices/model/CustomUpdateContent;Lcom/facebook/GraphRequest$Callback;)Lcom/facebook/GraphRequest;", "")]
		public unsafe static GraphRequest NewCustomUpdateRequest(CustomUpdateContent content, GraphRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				return Java.Lang.Object.GetObject<GraphRequest>(_members.StaticMethods.InvokeObjectMethod("newCustomUpdateRequest.(Lcom/facebook/gamingservices/model/CustomUpdateContent;Lcom/facebook/GraphRequest$Callback;)Lcom/facebook/GraphRequest;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/facebook/gamingservices/GamingContext", DoNotGenerateAcw = true)]
	public sealed class GamingContext : Java.Lang.Object
	{
		[Register("com/facebook/gamingservices/GamingContext$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GamingContext$Companion", typeof(Companion));

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

			public unsafe GamingContext CurrentGamingContext
			{
				[Register("getCurrentGamingContext", "()Lcom/facebook/gamingservices/GamingContext;", "")]
				get
				{
					return Java.Lang.Object.GetObject<GamingContext>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCurrentGamingContext.()Lcom/facebook/gamingservices/GamingContext;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setCurrentGamingContext", "(Lcom/facebook/gamingservices/GamingContext;)V", "")]
				set
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
						_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCurrentGamingContext.(Lcom/facebook/gamingservices/GamingContext;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(value);
					}
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

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GamingContext", typeof(GamingContext));

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

		public unsafe string ContextID
		{
			[Register("getContextID", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContextID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static GamingContext CurrentGamingContext
		{
			[Register("getCurrentGamingContext", "()Lcom/facebook/gamingservices/GamingContext;", "")]
			get
			{
				return Java.Lang.Object.GetObject<GamingContext>(_members.StaticMethods.InvokeObjectMethod("getCurrentGamingContext.()Lcom/facebook/gamingservices/GamingContext;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setCurrentGamingContext", "(Lcom/facebook/gamingservices/GamingContext;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.StaticMethods.InvokeVoidMethod("setCurrentGamingContext.(Lcom/facebook/gamingservices/GamingContext;)V", ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		internal GamingContext(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe GamingContext(string contextID)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(contextID);
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

		[Register("component1", "()Ljava/lang/String;", "")]
		public unsafe string Component1()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Ljava/lang/String;)Lcom/facebook/gamingservices/GamingContext;", "")]
		public unsafe GamingContext Copy(string contextID)
		{
			IntPtr intPtr = JNIEnv.NewString(contextID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<GamingContext>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;)Lcom/facebook/gamingservices/GamingContext;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/facebook/gamingservices/GamingImageUploader", DoNotGenerateAcw = true)]
	public class GamingImageUploader : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GamingImageUploader", typeof(GamingImageUploader));

		private static Delegate cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_Z;

		private static Delegate cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_ZLcom_facebook_GraphRequest_Callback_;

		private static Delegate cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Z;

		private static Delegate cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_Callback_;

		private static Delegate cb_uploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_Z;

		private static Delegate cb_uploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_ZLcom_facebook_GraphRequest_Callback_;

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

		protected GamingImageUploader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe GamingImageUploader(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetUploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_ZHandler()
		{
			if ((object)cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_Z == null)
			{
				cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZ_V(n_UploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_Z));
			}
			return cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_Z;
		}

		private static void n_UploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_caption, IntPtr native_imageBitmap, bool shouldLaunchMediaDialog)
		{
			GamingImageUploader gamingImageUploader = Java.Lang.Object.GetObject<GamingImageUploader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string caption = JNIEnv.GetString(native_caption, JniHandleOwnership.DoNotTransfer);
			Bitmap imageBitmap = Java.Lang.Object.GetObject<Bitmap>(native_imageBitmap, JniHandleOwnership.DoNotTransfer);
			gamingImageUploader.UploadToMediaLibrary(caption, imageBitmap, shouldLaunchMediaDialog);
		}

		[Register("uploadToMediaLibrary", "(Ljava/lang/String;Landroid/graphics/Bitmap;Z)V", "GetUploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_ZHandler")]
		public unsafe virtual void UploadToMediaLibrary(string caption, Bitmap imageBitmap, bool shouldLaunchMediaDialog)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(imageBitmap?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(shouldLaunchMediaDialog);
				_members.InstanceMethods.InvokeVirtualVoidMethod("uploadToMediaLibrary.(Ljava/lang/String;Landroid/graphics/Bitmap;Z)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(imageBitmap);
			}
		}

		private static Delegate GetUploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_ZLcom_facebook_GraphRequest_Callback_Handler()
		{
			if ((object)cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_ZLcom_facebook_GraphRequest_Callback_ == null)
			{
				cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_ZLcom_facebook_GraphRequest_Callback_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZL_V(n_UploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_ZLcom_facebook_GraphRequest_Callback_));
			}
			return cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_ZLcom_facebook_GraphRequest_Callback_;
		}

		private static void n_UploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_ZLcom_facebook_GraphRequest_Callback_(IntPtr jnienv, IntPtr native__this, IntPtr native_caption, IntPtr native_imageBitmap, bool shouldLaunchMediaDialog, IntPtr native__callback)
		{
			GamingImageUploader gamingImageUploader = Java.Lang.Object.GetObject<GamingImageUploader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string caption = JNIEnv.GetString(native_caption, JniHandleOwnership.DoNotTransfer);
			Bitmap imageBitmap = Java.Lang.Object.GetObject<Bitmap>(native_imageBitmap, JniHandleOwnership.DoNotTransfer);
			GraphRequest.ICallback callback = Java.Lang.Object.GetObject<GraphRequest.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			gamingImageUploader.UploadToMediaLibrary(caption, imageBitmap, shouldLaunchMediaDialog, callback);
		}

		[Register("uploadToMediaLibrary", "(Ljava/lang/String;Landroid/graphics/Bitmap;ZLcom/facebook/GraphRequest$Callback;)V", "GetUploadToMediaLibrary_Ljava_lang_String_Landroid_graphics_Bitmap_ZLcom_facebook_GraphRequest_Callback_Handler")]
		public unsafe virtual void UploadToMediaLibrary(string caption, Bitmap imageBitmap, bool shouldLaunchMediaDialog, GraphRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(imageBitmap?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(shouldLaunchMediaDialog);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("uploadToMediaLibrary.(Ljava/lang/String;Landroid/graphics/Bitmap;ZLcom/facebook/GraphRequest$Callback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(imageBitmap);
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetUploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZHandler()
		{
			if ((object)cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Z == null)
			{
				cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZ_V(n_UploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Z));
			}
			return cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Z;
		}

		private static void n_UploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_caption, IntPtr native_imageUri, bool shouldLaunchMediaDialog)
		{
			GamingImageUploader gamingImageUploader = Java.Lang.Object.GetObject<GamingImageUploader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string caption = JNIEnv.GetString(native_caption, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri imageUri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_imageUri, JniHandleOwnership.DoNotTransfer);
			gamingImageUploader.UploadToMediaLibrary(caption, imageUri, shouldLaunchMediaDialog);
		}

		[Register("uploadToMediaLibrary", "(Ljava/lang/String;Landroid/net/Uri;Z)V", "GetUploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZHandler")]
		public unsafe virtual void UploadToMediaLibrary(string caption, Android.Net.Uri imageUri, bool shouldLaunchMediaDialog)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(imageUri?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(shouldLaunchMediaDialog);
				_members.InstanceMethods.InvokeVirtualVoidMethod("uploadToMediaLibrary.(Ljava/lang/String;Landroid/net/Uri;Z)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(imageUri);
			}
		}

		private static Delegate GetUploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_Callback_Handler()
		{
			if ((object)cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_Callback_ == null)
			{
				cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_Callback_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZL_V(n_UploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_Callback_));
			}
			return cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_Callback_;
		}

		private static void n_UploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_Callback_(IntPtr jnienv, IntPtr native__this, IntPtr native_caption, IntPtr native_imageUri, bool shouldLaunchMediaDialog, IntPtr native__callback)
		{
			GamingImageUploader gamingImageUploader = Java.Lang.Object.GetObject<GamingImageUploader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string caption = JNIEnv.GetString(native_caption, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri imageUri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_imageUri, JniHandleOwnership.DoNotTransfer);
			GraphRequest.ICallback callback = Java.Lang.Object.GetObject<GraphRequest.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			gamingImageUploader.UploadToMediaLibrary(caption, imageUri, shouldLaunchMediaDialog, callback);
		}

		[Register("uploadToMediaLibrary", "(Ljava/lang/String;Landroid/net/Uri;ZLcom/facebook/GraphRequest$Callback;)V", "GetUploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_Callback_Handler")]
		public unsafe virtual void UploadToMediaLibrary(string caption, Android.Net.Uri imageUri, bool shouldLaunchMediaDialog, GraphRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(imageUri?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(shouldLaunchMediaDialog);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("uploadToMediaLibrary.(Ljava/lang/String;Landroid/net/Uri;ZLcom/facebook/GraphRequest$Callback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(imageUri);
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetUploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_ZHandler()
		{
			if ((object)cb_uploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_Z == null)
			{
				cb_uploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZ_V(n_UploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_Z));
			}
			return cb_uploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_Z;
		}

		private static void n_UploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_caption, IntPtr native_imageFile, bool shouldLaunchMediaDialog)
		{
			GamingImageUploader gamingImageUploader = Java.Lang.Object.GetObject<GamingImageUploader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string caption = JNIEnv.GetString(native_caption, JniHandleOwnership.DoNotTransfer);
			File imageFile = Java.Lang.Object.GetObject<File>(native_imageFile, JniHandleOwnership.DoNotTransfer);
			gamingImageUploader.UploadToMediaLibrary(caption, imageFile, shouldLaunchMediaDialog);
		}

		[Register("uploadToMediaLibrary", "(Ljava/lang/String;Ljava/io/File;Z)V", "GetUploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_ZHandler")]
		public unsafe virtual void UploadToMediaLibrary(string caption, File imageFile, bool shouldLaunchMediaDialog)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(imageFile?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(shouldLaunchMediaDialog);
				_members.InstanceMethods.InvokeVirtualVoidMethod("uploadToMediaLibrary.(Ljava/lang/String;Ljava/io/File;Z)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(imageFile);
			}
		}

		private static Delegate GetUploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_ZLcom_facebook_GraphRequest_Callback_Handler()
		{
			if ((object)cb_uploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_ZLcom_facebook_GraphRequest_Callback_ == null)
			{
				cb_uploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_ZLcom_facebook_GraphRequest_Callback_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZL_V(n_UploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_ZLcom_facebook_GraphRequest_Callback_));
			}
			return cb_uploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_ZLcom_facebook_GraphRequest_Callback_;
		}

		private static void n_UploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_ZLcom_facebook_GraphRequest_Callback_(IntPtr jnienv, IntPtr native__this, IntPtr native_caption, IntPtr native_imageFile, bool shouldLaunchMediaDialog, IntPtr native__callback)
		{
			GamingImageUploader gamingImageUploader = Java.Lang.Object.GetObject<GamingImageUploader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string caption = JNIEnv.GetString(native_caption, JniHandleOwnership.DoNotTransfer);
			File imageFile = Java.Lang.Object.GetObject<File>(native_imageFile, JniHandleOwnership.DoNotTransfer);
			GraphRequest.ICallback callback = Java.Lang.Object.GetObject<GraphRequest.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			gamingImageUploader.UploadToMediaLibrary(caption, imageFile, shouldLaunchMediaDialog, callback);
		}

		[Register("uploadToMediaLibrary", "(Ljava/lang/String;Ljava/io/File;ZLcom/facebook/GraphRequest$Callback;)V", "GetUploadToMediaLibrary_Ljava_lang_String_Ljava_io_File_ZLcom_facebook_GraphRequest_Callback_Handler")]
		public unsafe virtual void UploadToMediaLibrary(string caption, File imageFile, bool shouldLaunchMediaDialog, GraphRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(imageFile?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(shouldLaunchMediaDialog);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("uploadToMediaLibrary.(Ljava/lang/String;Ljava/io/File;ZLcom/facebook/GraphRequest$Callback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(imageFile);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/facebook/gamingservices/GamingPayload", DoNotGenerateAcw = true)]
	public class GamingPayload : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GamingPayload", typeof(GamingPayload));

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

		public unsafe static string GameRequestID
		{
			[Register("getGameRequestID", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getGameRequestID.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static string Payload
		{
			[Register("getPayload", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getPayload.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static string TournamentId
		{
			[Register("getTournamentId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getTournamentId.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected GamingPayload(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("loadPayloadFromCloudGame", "(Ljava/lang/String;)V", "")]
		public unsafe static void LoadPayloadFromCloudGame(string payloadString)
		{
			IntPtr intPtr = JNIEnv.NewString(payloadString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("loadPayloadFromCloudGame.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("loadPayloadFromIntent", "(Landroid/content/Intent;)V", "")]
		public unsafe static void LoadPayloadFromIntent(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("loadPayloadFromIntent.(Landroid/content/Intent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/facebook/gamingservices/GamingServices", DoNotGenerateAcw = true)]
	public class GamingServices : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GamingServices", typeof(GamingServices));

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

		protected GamingServices(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GamingServices()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/gamingservices/GamingVideoUploader", DoNotGenerateAcw = true)]
	public class GamingVideoUploader : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GamingVideoUploader", typeof(GamingVideoUploader));

		private static Delegate cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_;

		private static Delegate cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_OnProgressCallback_;

		private static Delegate cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Lcom_facebook_GraphRequest_OnProgressCallback_;

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

		protected GamingVideoUploader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe GamingVideoUploader(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetUploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Handler()
		{
			if ((object)cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ == null)
			{
				cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_UploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_));
			}
			return cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_;
		}

		private static void n_UploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_caption, IntPtr native_videoUri)
		{
			GamingVideoUploader gamingVideoUploader = Java.Lang.Object.GetObject<GamingVideoUploader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string caption = JNIEnv.GetString(native_caption, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri videoUri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_videoUri, JniHandleOwnership.DoNotTransfer);
			gamingVideoUploader.UploadToMediaLibrary(caption, videoUri);
		}

		[Register("uploadToMediaLibrary", "(Ljava/lang/String;Landroid/net/Uri;)V", "GetUploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Handler")]
		public unsafe virtual void UploadToMediaLibrary(string caption, Android.Net.Uri videoUri)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(videoUri?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("uploadToMediaLibrary.(Ljava/lang/String;Landroid/net/Uri;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(videoUri);
			}
		}

		private static Delegate GetUploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_OnProgressCallback_Handler()
		{
			if ((object)cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_OnProgressCallback_ == null)
			{
				cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_OnProgressCallback_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZL_V(n_UploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_OnProgressCallback_));
			}
			return cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_OnProgressCallback_;
		}

		private static void n_UploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_OnProgressCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_caption, IntPtr native_videoUri, bool shouldLaunchMediaDialog, IntPtr native__callback)
		{
			GamingVideoUploader gamingVideoUploader = Java.Lang.Object.GetObject<GamingVideoUploader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string caption = JNIEnv.GetString(native_caption, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri videoUri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_videoUri, JniHandleOwnership.DoNotTransfer);
			GraphRequest.IOnProgressCallback callback = Java.Lang.Object.GetObject<GraphRequest.IOnProgressCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			gamingVideoUploader.UploadToMediaLibrary(caption, videoUri, shouldLaunchMediaDialog, callback);
		}

		[Register("uploadToMediaLibrary", "(Ljava/lang/String;Landroid/net/Uri;ZLcom/facebook/GraphRequest$OnProgressCallback;)V", "GetUploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_ZLcom_facebook_GraphRequest_OnProgressCallback_Handler")]
		public unsafe virtual void UploadToMediaLibrary(string caption, Android.Net.Uri videoUri, bool shouldLaunchMediaDialog, GraphRequest.IOnProgressCallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(videoUri?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(shouldLaunchMediaDialog);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("uploadToMediaLibrary.(Ljava/lang/String;Landroid/net/Uri;ZLcom/facebook/GraphRequest$OnProgressCallback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(videoUri);
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetUploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Lcom_facebook_GraphRequest_OnProgressCallback_Handler()
		{
			if ((object)cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Lcom_facebook_GraphRequest_OnProgressCallback_ == null)
			{
				cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Lcom_facebook_GraphRequest_OnProgressCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_UploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Lcom_facebook_GraphRequest_OnProgressCallback_));
			}
			return cb_uploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Lcom_facebook_GraphRequest_OnProgressCallback_;
		}

		private static void n_UploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Lcom_facebook_GraphRequest_OnProgressCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_caption, IntPtr native_videoUri, IntPtr native__callback)
		{
			GamingVideoUploader gamingVideoUploader = Java.Lang.Object.GetObject<GamingVideoUploader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string caption = JNIEnv.GetString(native_caption, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri videoUri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_videoUri, JniHandleOwnership.DoNotTransfer);
			GraphRequest.IOnProgressCallback callback = Java.Lang.Object.GetObject<GraphRequest.IOnProgressCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			gamingVideoUploader.UploadToMediaLibrary(caption, videoUri, callback);
		}

		[Register("uploadToMediaLibrary", "(Ljava/lang/String;Landroid/net/Uri;Lcom/facebook/GraphRequest$OnProgressCallback;)V", "GetUploadToMediaLibrary_Ljava_lang_String_Landroid_net_Uri_Lcom_facebook_GraphRequest_OnProgressCallback_Handler")]
		public unsafe virtual void UploadToMediaLibrary(string caption, Android.Net.Uri videoUri, GraphRequest.IOnProgressCallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(videoUri?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("uploadToMediaLibrary.(Ljava/lang/String;Landroid/net/Uri;Lcom/facebook/GraphRequest$OnProgressCallback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(videoUri);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/facebook/gamingservices/GraphAPIException", DoNotGenerateAcw = true)]
	public sealed class GraphAPIException : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/GraphAPIException", typeof(GraphAPIException));

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

		internal GraphAPIException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe GraphAPIException(string message)
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
	[Register("com/facebook/gamingservices/InvalidExpirationDateException", DoNotGenerateAcw = true)]
	public sealed class InvalidExpirationDateException : IllegalArgumentException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/InvalidExpirationDateException", typeof(InvalidExpirationDateException));

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

		internal InvalidExpirationDateException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe InvalidExpirationDateException()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/gamingservices/InvalidScoreTypeException", DoNotGenerateAcw = true)]
	public sealed class InvalidScoreTypeException : IllegalArgumentException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/InvalidScoreTypeException", typeof(InvalidScoreTypeException));

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

		internal InvalidScoreTypeException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe InvalidScoreTypeException()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/gamingservices/OpenGamingMediaDialog", DoNotGenerateAcw = true)]
	public class OpenGamingMediaDialog : Java.Lang.Object, GraphRequest.IOnProgressCallback, GraphRequest.ICallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/OpenGamingMediaDialog", typeof(OpenGamingMediaDialog));

		private static Delegate cb_onCompleted_Lcom_facebook_GraphResponse_;

		private static Delegate cb_onProgress_JJ;

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

		protected OpenGamingMediaDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe OpenGamingMediaDialog(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Lcom/facebook/GraphRequest$Callback;)V", "")]
		public unsafe OpenGamingMediaDialog(Context context, GraphRequest.ICallback callback)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lcom/facebook/GraphRequest$Callback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lcom/facebook/GraphRequest$Callback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetOnCompleted_Lcom_facebook_GraphResponse_Handler()
		{
			if ((object)cb_onCompleted_Lcom_facebook_GraphResponse_ == null)
			{
				cb_onCompleted_Lcom_facebook_GraphResponse_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCompleted_Lcom_facebook_GraphResponse_));
			}
			return cb_onCompleted_Lcom_facebook_GraphResponse_;
		}

		private static void n_OnCompleted_Lcom_facebook_GraphResponse_(IntPtr jnienv, IntPtr native__this, IntPtr native_response)
		{
			OpenGamingMediaDialog openGamingMediaDialog = Java.Lang.Object.GetObject<OpenGamingMediaDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			GraphResponse response = Java.Lang.Object.GetObject<GraphResponse>(native_response, JniHandleOwnership.DoNotTransfer);
			openGamingMediaDialog.OnCompleted(response);
		}

		[Register("onCompleted", "(Lcom/facebook/GraphResponse;)V", "GetOnCompleted_Lcom_facebook_GraphResponse_Handler")]
		public unsafe virtual void OnCompleted(GraphResponse response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onCompleted.(Lcom/facebook/GraphResponse;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(response);
			}
		}

		private static Delegate GetOnProgress_JJHandler()
		{
			if ((object)cb_onProgress_JJ == null)
			{
				cb_onProgress_JJ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJJ_V(n_OnProgress_JJ));
			}
			return cb_onProgress_JJ;
		}

		private static void n_OnProgress_JJ(IntPtr jnienv, IntPtr native__this, long current, long max)
		{
			Java.Lang.Object.GetObject<OpenGamingMediaDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnProgress(current, max);
		}

		[Register("onProgress", "(JJ)V", "GetOnProgress_JJHandler")]
		public unsafe virtual void OnProgress(long current, long max)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(current);
			ptr[1] = new JniArgumentValue(max);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onProgress.(JJ)V", this, ptr);
		}
	}
	[Register("com/facebook/gamingservices/Tournament", DoNotGenerateAcw = true)]
	public sealed class Tournament : Java.Lang.Object, IShareModel, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/facebook/gamingservices/Tournament$CREATOR", DoNotGenerateAcw = true)]
		public sealed class CREATOR : Java.Lang.Object, IParcelableCreator, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/Tournament$CREATOR", typeof(CREATOR));

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

			internal CREATOR(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe CREATOR(DefaultConstructorMarker _constructor_marker)
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

			[Register("createFromParcel", "(Landroid/os/Parcel;)Lcom/facebook/gamingservices/Tournament;", "")]
			public unsafe Java.Lang.Object CreateFromParcel(Parcel parcel)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("createFromParcel.(Landroid/os/Parcel;)Lcom/facebook/gamingservices/Tournament;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(parcel);
				}
			}

			[Register("newArray", "(I)[Lcom/facebook/gamingservices/Tournament;", "")]
			public unsafe Java.Lang.Object[] NewArray(int size)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(size);
				return (Tournament[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("newArray.(I)[Lcom/facebook/gamingservices/Tournament;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Tournament));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/Tournament", typeof(Tournament));

		[Register("CREATOR")]
		public static CREATOR Creator => Java.Lang.Object.GetObject<CREATOR>(_members.StaticFields.GetObjectValue("CREATOR.Lcom/facebook/gamingservices/Tournament$CREATOR;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string Identifier
		{
			[Register("getIdentifier", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getIdentifier.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Payload
		{
			[Register("getPayload", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPayload.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Tournament(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/os/Parcel;)V", "")]
		public unsafe Tournament(Parcel parcel)
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

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe Tournament(string identifier, string endTime, string title, string payload)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(identifier);
			IntPtr intPtr2 = JNIEnv.NewString(endTime);
			IntPtr intPtr3 = JNIEnv.NewString(title);
			IntPtr intPtr4 = JNIEnv.NewString(payload);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(intPtr4);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				JNIEnv.DeleteLocalRef(intPtr4);
			}
		}

		[Register("describeContents", "()I", "")]
		public unsafe int DescribeContents()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
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
	[Register("com/facebook/gamingservices/TournamentFetcher", DoNotGenerateAcw = true)]
	public sealed class TournamentFetcher : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/TournamentFetcher", typeof(TournamentFetcher));

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

		internal TournamentFetcher(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TournamentFetcher()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/gamingservices/TournamentFetcherKt", DoNotGenerateAcw = true)]
	public sealed class TournamentFetcherKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/TournamentFetcherKt", typeof(TournamentFetcherKt));

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

		internal TournamentFetcherKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/facebook/gamingservices/TournamentUpdater", DoNotGenerateAcw = true)]
	public sealed class TournamentUpdater : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/TournamentUpdater", typeof(TournamentUpdater));

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

		internal TournamentUpdater(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TournamentUpdater()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/gamingservices/TournamentUpdaterKt", DoNotGenerateAcw = true)]
	public sealed class TournamentUpdaterKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/TournamentUpdaterKt", typeof(TournamentUpdaterKt));

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

		internal TournamentUpdaterKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
}
namespace Xamarin.Facebook.GamingServices.Internal
{
	[Register("com/facebook/gamingservices/internal/GamingMediaUploader", DoNotGenerateAcw = true)]
	public abstract class GamingMediaUploader : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/internal/GamingMediaUploader", typeof(GamingMediaUploader));

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

		protected GamingMediaUploader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GamingMediaUploader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("uploadToGamingServices", "(Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/os/Bundle;Lcom/facebook/GraphRequest$Callback;)V", "")]
		public unsafe static void UploadToGamingServices(string caption, Bitmap imageBitmap, Bundle @params, GraphRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(imageBitmap?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("uploadToGamingServices.(Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/os/Bundle;Lcom/facebook/GraphRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(imageBitmap);
				GC.KeepAlive(@params);
				GC.KeepAlive(callback);
			}
		}

		[Register("uploadToGamingServices", "(Ljava/lang/String;Landroid/net/Uri;Landroid/os/Bundle;Lcom/facebook/GraphRequest$Callback;)V", "")]
		public unsafe static void UploadToGamingServices(string caption, Android.Net.Uri imageUri, Bundle @params, GraphRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(imageUri?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("uploadToGamingServices.(Ljava/lang/String;Landroid/net/Uri;Landroid/os/Bundle;Lcom/facebook/GraphRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(imageUri);
				GC.KeepAlive(@params);
				GC.KeepAlive(callback);
			}
		}

		[Register("uploadToGamingServices", "(Ljava/lang/String;Ljava/io/File;Landroid/os/Bundle;Lcom/facebook/GraphRequest$Callback;)V", "")]
		public unsafe static void UploadToGamingServices(string caption, File imageFile, Bundle @params, GraphRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(caption);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(imageFile?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("uploadToGamingServices.(Ljava/lang/String;Ljava/io/File;Landroid/os/Bundle;Lcom/facebook/GraphRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(imageFile);
				GC.KeepAlive(@params);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/facebook/gamingservices/internal/GamingMediaUploader", DoNotGenerateAcw = true)]
	internal class GamingMediaUploaderInvoker : GamingMediaUploader
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/internal/GamingMediaUploader", typeof(GamingMediaUploaderInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public GamingMediaUploaderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/facebook/gamingservices/internal/TournamentScoreType", DoNotGenerateAcw = true)]
	public sealed class TournamentScoreType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/internal/TournamentScoreType", typeof(TournamentScoreType));

		[Register("NUMERIC")]
		public static TournamentScoreType Numeric => Java.Lang.Object.GetObject<TournamentScoreType>(_members.StaticFields.GetObjectValue("NUMERIC.Lcom/facebook/gamingservices/internal/TournamentScoreType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TIME")]
		public static TournamentScoreType Time => Java.Lang.Object.GetObject<TournamentScoreType>(_members.StaticFields.GetObjectValue("TIME.Lcom/facebook/gamingservices/internal/TournamentScoreType;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal TournamentScoreType(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/gamingservices/internal/TournamentScoreType;", "")]
		public unsafe static TournamentScoreType ValueOf(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<TournamentScoreType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/gamingservices/internal/TournamentScoreType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/facebook/gamingservices/internal/TournamentScoreType;", "")]
		public unsafe static TournamentScoreType[] Values()
		{
			return (TournamentScoreType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/gamingservices/internal/TournamentScoreType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(TournamentScoreType));
		}
	}
	[Register("com/facebook/gamingservices/internal/TournamentSortOrder", DoNotGenerateAcw = true)]
	public sealed class TournamentSortOrder : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/internal/TournamentSortOrder", typeof(TournamentSortOrder));

		[Register("HigherIsBetter")]
		public static TournamentSortOrder HigherIsBetter => Java.Lang.Object.GetObject<TournamentSortOrder>(_members.StaticFields.GetObjectValue("HigherIsBetter.Lcom/facebook/gamingservices/internal/TournamentSortOrder;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LowerIsBetter")]
		public static TournamentSortOrder LowerIsBetter => Java.Lang.Object.GetObject<TournamentSortOrder>(_members.StaticFields.GetObjectValue("LowerIsBetter.Lcom/facebook/gamingservices/internal/TournamentSortOrder;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal TournamentSortOrder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/gamingservices/internal/TournamentSortOrder;", "")]
		public unsafe static TournamentSortOrder ValueOf(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<TournamentSortOrder>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/gamingservices/internal/TournamentSortOrder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/facebook/gamingservices/internal/TournamentSortOrder;", "")]
		public unsafe static TournamentSortOrder[] Values()
		{
			return (TournamentSortOrder[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/gamingservices/internal/TournamentSortOrder;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(TournamentSortOrder));
		}
	}
}
namespace Xamarin.Facebook.GamingServices.CloudGaming
{
	[Register("com/facebook/gamingservices/cloudgaming/AppToUserNotificationSender", DoNotGenerateAcw = true)]
	public abstract class AppToUserNotificationSender : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/AppToUserNotificationSender", typeof(AppToUserNotificationSender));

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

		protected AppToUserNotificationSender(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AppToUserNotificationSender()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("scheduleAppToUserNotification", "(Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;ILjava/lang/String;Lcom/facebook/GraphRequest$Callback;)V", "")]
		public unsafe static void ScheduleAppToUserNotification(string title, string body, Bitmap media, int timeInterval, string payload, GraphRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(title);
			IntPtr intPtr2 = JNIEnv.NewString(body);
			IntPtr intPtr3 = JNIEnv.NewString(payload);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(media?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(timeInterval);
				ptr[4] = new JniArgumentValue(intPtr3);
				ptr[5] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("scheduleAppToUserNotification.(Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;ILjava/lang/String;Lcom/facebook/GraphRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				GC.KeepAlive(media);
				GC.KeepAlive(callback);
			}
		}

		[Register("scheduleAppToUserNotification", "(Ljava/lang/String;Ljava/lang/String;Landroid/net/Uri;ILjava/lang/String;Lcom/facebook/GraphRequest$Callback;)V", "")]
		public unsafe static void ScheduleAppToUserNotification(string title, string body, Android.Net.Uri media, int timeInterval, string payload, GraphRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(title);
			IntPtr intPtr2 = JNIEnv.NewString(body);
			IntPtr intPtr3 = JNIEnv.NewString(payload);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(media?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(timeInterval);
				ptr[4] = new JniArgumentValue(intPtr3);
				ptr[5] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("scheduleAppToUserNotification.(Ljava/lang/String;Ljava/lang/String;Landroid/net/Uri;ILjava/lang/String;Lcom/facebook/GraphRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				GC.KeepAlive(media);
				GC.KeepAlive(callback);
			}
		}

		[Register("scheduleAppToUserNotification", "(Ljava/lang/String;Ljava/lang/String;Ljava/io/File;ILjava/lang/String;Lcom/facebook/GraphRequest$Callback;)V", "")]
		public unsafe static void ScheduleAppToUserNotification(string title, string body, File media, int timeInterval, string payload, GraphRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(title);
			IntPtr intPtr2 = JNIEnv.NewString(body);
			IntPtr intPtr3 = JNIEnv.NewString(payload);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(media?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(timeInterval);
				ptr[4] = new JniArgumentValue(intPtr3);
				ptr[5] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("scheduleAppToUserNotification.(Ljava/lang/String;Ljava/lang/String;Ljava/io/File;ILjava/lang/String;Lcom/facebook/GraphRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				GC.KeepAlive(media);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/AppToUserNotificationSender", DoNotGenerateAcw = true)]
	internal class AppToUserNotificationSenderInvoker : AppToUserNotificationSender
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/AppToUserNotificationSender", typeof(AppToUserNotificationSenderInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public AppToUserNotificationSenderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/CloudGameLoginHandler", DoNotGenerateAcw = true)]
	public class CloudGameLoginHandler : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/CloudGameLoginHandler", typeof(CloudGameLoginHandler));

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

		public unsafe static bool IsRunningInCloud
		{
			[Register("isRunningInCloud", "()Z", "")]
			get
			{
				return _members.StaticMethods.InvokeBooleanMethod("isRunningInCloud.()Z", null);
			}
		}

		protected CloudGameLoginHandler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CloudGameLoginHandler()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("gameLoadComplete", "(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void GameLoadComplete(Context context, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("gameLoadComplete.(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("init", "(Landroid/content/Context;)Lcom/facebook/AccessToken;", "")]
		public unsafe static AccessToken Init(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<AccessToken>(_members.StaticMethods.InvokeObjectMethod("init.(Landroid/content/Context;)Lcom/facebook/AccessToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("init", "(Landroid/content/Context;I)Lcom/facebook/AccessToken;", "")]
		public unsafe static AccessToken Init(Context context, int timeoutInSec)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(timeoutInSec);
				return Java.Lang.Object.GetObject<AccessToken>(_members.StaticMethods.InvokeObjectMethod("init.(Landroid/content/Context;I)Lcom/facebook/AccessToken;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/DaemonReceiver", DoNotGenerateAcw = true)]
	public class DaemonReceiver : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/DaemonReceiver", typeof(DaemonReceiver));

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

		protected DaemonReceiver(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/DaemonRequest", DoNotGenerateAcw = true)]
	public class DaemonRequest : Java.Lang.Object
	{
		[Register("com/facebook/gamingservices/cloudgaming/DaemonRequest$Callback", "", "Xamarin.Facebook.GamingServices.CloudGaming.DaemonRequest/ICallbackInvoker")]
		public interface ICallback : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onCompleted", "(Lcom/facebook/GraphResponse;)V", "GetOnCompleted_Lcom_facebook_GraphResponse_Handler:Xamarin.Facebook.GamingServices.CloudGaming.DaemonRequest/ICallbackInvoker, Xamarin.Facebook.GamingServices.Android")]
			void OnCompleted(GraphResponse response);
		}

		[Register("com/facebook/gamingservices/cloudgaming/DaemonRequest$Callback", DoNotGenerateAcw = true)]
		internal class ICallbackInvoker : Java.Lang.Object, ICallback, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/DaemonRequest$Callback", typeof(ICallbackInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onCompleted_Lcom_facebook_GraphResponse_;

			private IntPtr id_onCompleted_Lcom_facebook_GraphResponse_;

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

			public static ICallback GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ICallback>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.gamingservices.cloudgaming.DaemonRequest.Callback'.");
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

			public ICallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCompleted_Lcom_facebook_GraphResponse_Handler()
			{
				if ((object)cb_onCompleted_Lcom_facebook_GraphResponse_ == null)
				{
					cb_onCompleted_Lcom_facebook_GraphResponse_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCompleted_Lcom_facebook_GraphResponse_));
				}
				return cb_onCompleted_Lcom_facebook_GraphResponse_;
			}

			private static void n_OnCompleted_Lcom_facebook_GraphResponse_(IntPtr jnienv, IntPtr native__this, IntPtr native_response)
			{
				ICallback callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				GraphResponse response = Java.Lang.Object.GetObject<GraphResponse>(native_response, JniHandleOwnership.DoNotTransfer);
				callback.OnCompleted(response);
			}

			public unsafe void OnCompleted(GraphResponse response)
			{
				if (id_onCompleted_Lcom_facebook_GraphResponse_ == IntPtr.Zero)
				{
					id_onCompleted_Lcom_facebook_GraphResponse_ = JNIEnv.GetMethodID(class_ref, "onCompleted", "(Lcom/facebook/GraphResponse;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(response?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onCompleted_Lcom_facebook_GraphResponse_, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/DaemonRequest", typeof(DaemonRequest));

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

		protected DaemonRequest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("executeAndWait", "(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;)Lcom/facebook/GraphResponse;", "")]
		public unsafe static GraphResponse ExecuteAndWait(Context context, JSONObject parameters, SDKMessageEnum type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GraphResponse>(_members.StaticMethods.InvokeObjectMethod("executeAndWait.(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;)Lcom/facebook/GraphResponse;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(type);
			}
		}

		[Register("executeAndWait", "(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;I)Lcom/facebook/GraphResponse;", "")]
		public unsafe static GraphResponse ExecuteAndWait(Context context, JSONObject parameters, SDKMessageEnum type, int timeout)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(timeout);
				return Java.Lang.Object.GetObject<GraphResponse>(_members.StaticMethods.InvokeObjectMethod("executeAndWait.(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;I)Lcom/facebook/GraphResponse;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(type);
			}
		}

		[Register("executeAsync", "(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;)V", "")]
		public unsafe static void ExecuteAsync(Context context, JSONObject parameters, ICallback callback, SDKMessageEnum type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				ptr[3] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("executeAsync.(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(callback);
				GC.KeepAlive(type);
			}
		}

		[Register("executeAsync", "(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;Ljava/lang/String;)V", "")]
		public unsafe static void ExecuteAsync(Context context, JSONObject parameters, ICallback callback, string type)
		{
			IntPtr intPtr = JNIEnv.NewString(type);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				ptr[3] = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("executeAsync.(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/GameFeaturesLibrary", DoNotGenerateAcw = true)]
	public class GameFeaturesLibrary : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/GameFeaturesLibrary", typeof(GameFeaturesLibrary));

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

		protected GameFeaturesLibrary(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GameFeaturesLibrary()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("canCreateShortcut", "(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void CanCreateShortcut(Context context, JSONObject parameters, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("canCreateShortcut.(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(callback);
			}
		}

		[Register("createShortcut", "(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void CreateShortcut(Context context, JSONObject parameters, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("createShortcut.(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(callback);
			}
		}

		[Register("createTournamentAsync", "(Landroid/content/Context;ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Integer;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void CreateTournamentAsync(Context context, int score, string title, string image, string sortOrder, string scoreFormat, Integer endTime, JSONObject payload, DaemonRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(title);
			IntPtr intPtr2 = JNIEnv.NewString(image);
			IntPtr intPtr3 = JNIEnv.NewString(sortOrder);
			IntPtr intPtr4 = JNIEnv.NewString(scoreFormat);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(score);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(intPtr2);
				ptr[4] = new JniArgumentValue(intPtr3);
				ptr[5] = new JniArgumentValue(intPtr4);
				ptr[6] = new JniArgumentValue(endTime?.Handle ?? IntPtr.Zero);
				ptr[7] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
				ptr[8] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("createTournamentAsync.(Landroid/content/Context;ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Integer;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				JNIEnv.DeleteLocalRef(intPtr4);
				GC.KeepAlive(context);
				GC.KeepAlive(endTime);
				GC.KeepAlive(payload);
				GC.KeepAlive(callback);
			}
		}

		[Register("getPayload", "(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void GetPayload(Context context, JSONObject parameters, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("getPayload.(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(callback);
			}
		}

		[Register("getTournamentAsync", "(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void GetTournamentAsync(Context context, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("getTournamentAsync.(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("getTournamentsAsync", "(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void GetTournamentsAsync(Context context, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("getTournamentsAsync.(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("joinTournamentAsync", "(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void JoinTournamentAsync(Context context, string tournamentId, DaemonRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(tournamentId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("joinTournamentAsync.(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("performHapticFeedback", "(Landroid/content/Context;)V", "")]
		public unsafe static void PerformHapticFeedback(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("performHapticFeedback.(Landroid/content/Context;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("postSessionScore", "(Landroid/content/Context;ILcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void PostSessionScore(Context context, int score, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(score);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("postSessionScore.(Landroid/content/Context;ILcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("postSessionScoreAsync", "(Landroid/content/Context;ILcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void PostSessionScoreAsync(Context context, int score, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(score);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("postSessionScoreAsync.(Landroid/content/Context;ILcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("postTournamentScoreAsync", "(Landroid/content/Context;ILcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void PostTournamentScoreAsync(Context context, int score, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(score);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("postTournamentScoreAsync.(Landroid/content/Context;ILcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("shareTournamentAsync", "(Landroid/content/Context;Ljava/lang/Integer;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void ShareTournamentAsync(Context context, Integer score, JSONObject payload, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(score?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("shareTournamentAsync.(Landroid/content/Context;Ljava/lang/Integer;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(score);
				GC.KeepAlive(payload);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/InAppAdLibrary", DoNotGenerateAcw = true)]
	public class InAppAdLibrary : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/InAppAdLibrary", typeof(InAppAdLibrary));

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

		protected InAppAdLibrary(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe InAppAdLibrary()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("loadInterstitialAd", "(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void LoadInterstitialAd(Context context, string placementID, DaemonRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(placementID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("loadInterstitialAd.(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("loadRewardedVideo", "(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void LoadRewardedVideo(Context context, string placementID, DaemonRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(placementID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("loadRewardedVideo.(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("showInterstitialAd", "(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void ShowInterstitialAd(Context context, string placementID, DaemonRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(placementID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("showInterstitialAd.(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("showRewardedVideo", "(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void ShowRewardedVideo(Context context, string placementID, DaemonRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(placementID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("showRewardedVideo.(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/InAppPurchaseLibrary", DoNotGenerateAcw = true)]
	public class InAppPurchaseLibrary : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/InAppPurchaseLibrary", typeof(InAppPurchaseLibrary));

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

		protected InAppPurchaseLibrary(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe InAppPurchaseLibrary()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("consumePurchase", "(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void ConsumePurchase(Context context, string purchaseToken, DaemonRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(purchaseToken);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("consumePurchase.(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("getCatalog", "(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void GetCatalog(Context context, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("getCatalog.(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("getPurchases", "(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void GetPurchases(Context context, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("getPurchases.(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("onReady", "(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void OnReady(Context context, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("onReady.(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		[Register("purchase", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void Purchase(Context context, string productID, string developerPayload, DaemonRequest.ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(productID);
			IntPtr intPtr2 = JNIEnv.NewString(developerPayload);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("purchase.(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/PlayableAdsLibrary", DoNotGenerateAcw = true)]
	public class PlayableAdsLibrary : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/PlayableAdsLibrary", typeof(PlayableAdsLibrary));

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

		protected PlayableAdsLibrary(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PlayableAdsLibrary()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("markGameLoaded", "(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void MarkGameLoaded(Context context, JSONObject parameters, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("markGameLoaded.(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(callback);
			}
		}

		[Register("openAppStore", "(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", "")]
		public unsafe static void OpenAppStore(Context context, JSONObject parameters, DaemonRequest.ICallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parameters?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("openAppStore.(Landroid/content/Context;Lorg/json/JSONObject;Lcom/facebook/gamingservices/cloudgaming/DaemonRequest$Callback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(parameters);
				GC.KeepAlive(callback);
			}
		}
	}
}
namespace Xamarin.Facebook.GamingServices.CloudGaming.Internal
{
	[Register("com/facebook/gamingservices/cloudgaming/internal/SDKAnalyticsEvents", DoNotGenerateAcw = true)]
	public class SDKAnalyticsEvents : Java.Lang.Object
	{
		[Register("EVENT_GAME_LOAD_COMPLETE")]
		public const string EventGameLoadComplete = "cloud_games_load_complete";

		[Register("EVENT_INTERNAL_ERROR")]
		public const string EventInternalError = "cloud_games_internal_error";

		[Register("EVENT_LOGIN_SUCCESS")]
		public const string EventLoginSuccess = "cloud_games_login_success";

		[Register("EVENT_PREPARING_REQUEST")]
		public const string EventPreparingRequest = "cloud_games_preparing_request";

		[Register("EVENT_SENDING_ERROR_RESPONSE")]
		public const string EventSendingErrorResponse = "cloud_games_sending_error_response";

		[Register("EVENT_SENDING_SUCCESS_RESPONSE")]
		public const string EventSendingSuccessResponse = "cloud_games_sending_success_response";

		[Register("EVENT_SENT_REQUEST")]
		public const string EventSentRequest = "cloud_games_sent_request";

		[Register("PARAMETER_APP_ID")]
		public const string ParameterAppId = "app_id";

		[Register("PARAMETER_ERROR_CODE")]
		public const string ParameterErrorCode = "error_code";

		[Register("PARAMETER_ERROR_MESSAGE")]
		public const string ParameterErrorMessage = "error_message";

		[Register("PARAMETER_ERROR_TYPE")]
		public const string ParameterErrorType = "error_type";

		[Register("PARAMETER_FUNCTION_TYPE")]
		public const string ParameterFunctionType = "function_type";

		[Register("PARAMETER_PAYLOAD")]
		public const string ParameterPayload = "payload";

		[Register("PARAMETER_REQUEST_ID")]
		public const string ParameterRequestId = "request_id";

		[Register("PARAMETER_SESSION_ID")]
		public const string ParameterSessionId = "session_id";

		[Register("PARAMETER_USER_ID")]
		public const string ParameterUserId = "user_id";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/internal/SDKAnalyticsEvents", typeof(SDKAnalyticsEvents));

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

		protected SDKAnalyticsEvents(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SDKAnalyticsEvents()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/internal/SDKConstants", DoNotGenerateAcw = true)]
	public class SDKConstants : Java.Lang.Object
	{
		[Register("PARAM_A2U_BODY")]
		public const string ParamA2uBody = "body";

		[Register("PARAM_A2U_CAPTION")]
		public const string ParamA2uCaption = "A2U Image";

		[Register("PARAM_A2U_GRAPH_PATH")]
		public const string ParamA2uGraphPath = "me/schedule_gaming_app_to_user_update";

		[Register("PARAM_A2U_MEDIA_ID")]
		public const string ParamA2uMediaId = "media_id";

		[Register("PARAM_A2U_PAYLOAD")]
		public const string ParamA2uPayload = "payload:";

		[Register("PARAM_A2U_RESPONSE_ID")]
		public const string ParamA2uResponseId = "id";

		[Register("PARAM_A2U_TIME_INTERVAL")]
		public const string ParamA2uTimeInterval = "time_interval";

		[Register("PARAM_A2U_TITLE")]
		public const string ParamA2uTitle = "title";

		[Register("PARAM_ACCESS_TOKEN")]
		public const string ParamAccessToken = "accessToken";

		[Register("PARAM_ACCESS_TOKEN_SOURCE")]
		public const string ParamAccessTokenSource = "accessTokenSource";

		[Register("PARAM_APP_ID")]
		public const string ParamAppId = "appID";

		[Register("PARAM_CONTEXT_CONTEXT_ID")]
		public const string ParamContextContextId = "context_id";

		[Register("PARAM_CONTEXT_FILTERS")]
		public const string ParamContextFilters = "filters";

		[Register("PARAM_CONTEXT_ID")]
		public const string ParamContextId = "id";

		[Register("PARAM_CONTEXT_MAX_SIZE")]
		public const string ParamContextMaxSize = "maxSize";

		[Register("PARAM_CONTEXT_MIN_SIZE")]
		public const string ParamContextMinSize = "minSize";

		[Register("PARAM_CONTEXT_TOKEN")]
		public const string ParamContextToken = "contextToken";

		[Register("PARAM_DAEMON_PACKAGE_NAME")]
		public const string ParamDaemonPackageName = "daemonPackageName";

		[Register("PARAM_DATA")]
		public const string ParamData = "data";

		[Register("PARAM_DATA_ACCESS_EXPIRATION_TIME")]
		public const string ParamDataAccessExpirationTime = "dataAccessExpirationTime";

		[Register("PARAM_DEBUG_MESSAGE")]
		public const string ParamDebugMessage = "msg";

		[Register("PARAM_DEBUG_MESSAGE_SEVERITY")]
		public const string ParamDebugMessageSeverity = "severity";

		[Register("PARAM_DEBUG_MESSAGE_TAG")]
		public const string ParamDebugMessageTag = "tag";

		[Register("PARAM_DEBUG_MESSAGE_TIMESTAMP")]
		public const string ParamDebugMessageTimestamp = "timestamp";

		[Register("PARAM_DECLINED_PERMISSIONS")]
		public const string ParamDeclinedPermissions = "declinedPermissions";

		[Register("PARAM_DEEP_LINK")]
		public const string ParamDeepLink = "deepLink";

		[Register("PARAM_DEEP_LINK_ID")]
		public const string ParamDeepLinkId = "id";

		[Register("PARAM_DEVELOPER_PAYLOAD")]
		public const string ParamDeveloperPayload = "developerPayload";

		[Register("PARAM_END_TIME")]
		public const string ParamEndTime = "endTime";

		[Register("PARAM_EXPIRATION_TIME")]
		public const string ParamExpirationTime = "expirationTime";

		[Register("PARAM_EXPIRED_PERMISSIONS")]
		public const string ParamExpiredPermissions = "expiredPermissions";

		[Register("PARAM_GAME_PACKAGE_NAME")]
		public const string ParamGamePackageName = "gamePackageName";

		[Register("PARAM_GAME_REQUESTS_ACTION_TYPE")]
		public const string ParamGameRequestsActionType = "actionType";

		[Register("PARAM_GAME_REQUESTS_CTA")]
		public const string ParamGameRequestsCta = "cta";

		[Register("PARAM_GAME_REQUESTS_DATA")]
		public const string ParamGameRequestsData = "data";

		[Register("PARAM_GAME_REQUESTS_MESSAGE")]
		public const string ParamGameRequestsMessage = "message";

		[Register("PARAM_GAME_REQUESTS_OPTIONS")]
		public const string ParamGameRequestsOptions = "options";

		[Register("PARAM_GAME_REQUESTS_TITLE")]
		public const string ParamGameRequestsTitle = "title";

		[Register("PARAM_GAME_REQUESTS_TO")]
		public const string ParamGameRequestsTo = "to";

		[Register("PARAM_GRAPH_DOMAIN")]
		public const string ParamGraphDomain = "graphDomain";

		[Register("PARAM_IMAGE")]
		public const string ParamImage = "image";

		[Register("PARAM_INITIAL_SCORE")]
		public const string ParamInitialScore = "initialScore";

		[Register("PARAM_INTENT")]
		public const string ParamIntent = "intent";

		[Register("PARAM_KEY")]
		public const string ParamKey = "key";

		[Register("PARAM_LAST_REFRESH_TIME")]
		public const string ParamLastRefreshTime = "lastRefreshTime";

		[Register("PARAM_PAYLOAD")]
		public const string ParamPayload = "payload";

		[Register("PARAM_PERMISSIONS")]
		public const string ParamPermissions = "permissions";

		[Register("PARAM_PLACEMENT_ID")]
		public const string ParamPlacementId = "placementID";

		[Register("PARAM_PRODUCT_ID")]
		public const string ParamProductId = "productID";

		[Register("PARAM_PURCHASE_TOKEN")]
		public const string ParamPurchaseToken = "purchaseToken";

		[Register("PARAM_SCORE")]
		public const string ParamScore = "score";

		[Register("PARAM_SCORE_FORMAT")]
		public const string ParamScoreFormat = "scoreFormat";

		[Register("PARAM_SESSION_ID")]
		public const string ParamSessionId = "sessionID";

		[Register("PARAM_SORT_ORDER")]
		public const string ParamSortOrder = "sortOrder";

		[Register("PARAM_TEXT")]
		public const string ParamText = "text";

		[Register("PARAM_TITLE")]
		public const string ParamTitle = "title";

		[Register("PARAM_TOURNAMENTS")]
		public const string ParamTournaments = "INSTANT_TOURNAMENT";

		[Register("PARAM_TOURNAMENTS_APP_ID")]
		public const string ParamTournamentsAppId = "app_id";

		[Register("PARAM_TOURNAMENTS_DEEPLINK")]
		public const string ParamTournamentsDeeplink = "deeplink";

		[Register("PARAM_TOURNAMENTS_END_TIME")]
		public const string ParamTournamentsEndTime = "end_time";

		[Register("PARAM_TOURNAMENTS_ID")]
		public const string ParamTournamentsId = "tournament_id";

		[Register("PARAM_TOURNAMENTS_PAYLOAD")]
		public const string ParamTournamentsPayload = "tournament_payload";

		[Register("PARAM_TOURNAMENTS_SCORE")]
		public const string ParamTournamentsScore = "score";

		[Register("PARAM_TOURNAMENTS_SCORE_FORMAT")]
		public const string ParamTournamentsScoreFormat = "score_format";

		[Register("PARAM_TOURNAMENTS_SORT_ORDER")]
		public const string ParamTournamentsSortOrder = "sort_order";

		[Register("PARAM_TOURNAMENTS_TITLE")]
		public const string ParamTournamentsTitle = "tournament_title";

		[Register("PARAM_TOURNAMENT_ID")]
		public const string ParamTournamentId = "tournamentId";

		[Register("PARAM_TYPE")]
		public const string ParamType = "type";

		[Register("PARAM_UPDATE_ACTION")]
		public const string ParamUpdateAction = "action";

		[Register("PARAM_UPDATE_IMAGE")]
		public const string ParamUpdateImage = "image";

		[Register("PARAM_UPDATE_TEMPLATE")]
		public const string ParamUpdateTemplate = "template";

		[Register("PARAM_UPDATE_TEXT")]
		public const string ParamUpdateText = "text";

		[Register("PARAM_URL")]
		public const string ParamUrl = "url";

		[Register("PARAM_USER_ID")]
		public const string ParamUserId = "userID";

		[Register("PARAM_VALUE")]
		public const string ParamValue = "value";

		[Register("PREF_DAEMON_PACKAGE_NAME")]
		public const string PrefDaemonPackageName = "com.facebook.gamingservices.cloudgaming:preferences";

		[Register("RECEIVER_HANDLER")]
		public const string ReceiverHandler = "com.facebook.gamingservices.DAEMON_RESPONSE_HANDLER";

		[Register("RECEIVER_INTENT")]
		public const string ReceiverIntent = "com.facebook.gamingservices.DAEMON_RESPONSE";

		[Register("RECEIVER_PAYLOAD")]
		public const string ReceiverPayload = "returnPayload";

		[Register("REQUEST_ACTION")]
		public const string RequestAction = "com.facebook.gamingservices.DAEMON_REQUEST";

		[Register("REQUEST_ID")]
		public const string RequestId = "requestID";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/internal/SDKConstants", typeof(SDKConstants));

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

		protected SDKConstants(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SDKConstants()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/internal/SDKLogger", DoNotGenerateAcw = true)]
	public class SDKLogger : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/internal/SDKLogger", typeof(SDKLogger));

		private static Delegate cb_logGameLoadComplete;

		private static Delegate cb_logInternalError_Lcom_facebook_gamingservices_cloudgaming_internal_SDKMessageEnum_Ljava_lang_Exception_;

		private static Delegate cb_logLoginSuccess;

		private static Delegate cb_logPreparingRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_;

		private static Delegate cb_logSendingErrorResponse_Lcom_facebook_FacebookRequestError_Ljava_lang_String_;

		private static Delegate cb_logSendingSuccessResponse_Ljava_lang_String_;

		private static Delegate cb_logSentRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_;

		private static Delegate cb_setAppID_Ljava_lang_String_;

		private static Delegate cb_setSessionID_Ljava_lang_String_;

		private static Delegate cb_setUserID_Ljava_lang_String_;

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

		protected SDKLogger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getInstance", "(Landroid/content/Context;)Lcom/facebook/gamingservices/cloudgaming/internal/SDKLogger;", "")]
		public unsafe static SDKLogger GetInstance(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<SDKLogger>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Landroid/content/Context;)Lcom/facebook/gamingservices/cloudgaming/internal/SDKLogger;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetLogGameLoadCompleteHandler()
		{
			if ((object)cb_logGameLoadComplete == null)
			{
				cb_logGameLoadComplete = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_LogGameLoadComplete));
			}
			return cb_logGameLoadComplete;
		}

		private static void n_LogGameLoadComplete(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SDKLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LogGameLoadComplete();
		}

		[Register("logGameLoadComplete", "()V", "GetLogGameLoadCompleteHandler")]
		public unsafe virtual void LogGameLoadComplete()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("logGameLoadComplete.()V", this, null);
		}

		[Register("logInternalError", "(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;Ljava/lang/Exception;)V", "")]
		public unsafe static void LogInternalError(Context context, SDKMessageEnum functionType, Java.Lang.Exception e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(functionType?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("logInternalError.(Landroid/content/Context;Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;Ljava/lang/Exception;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(functionType);
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetLogInternalError_Lcom_facebook_gamingservices_cloudgaming_internal_SDKMessageEnum_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_logInternalError_Lcom_facebook_gamingservices_cloudgaming_internal_SDKMessageEnum_Ljava_lang_Exception_ == null)
			{
				cb_logInternalError_Lcom_facebook_gamingservices_cloudgaming_internal_SDKMessageEnum_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_LogInternalError_Lcom_facebook_gamingservices_cloudgaming_internal_SDKMessageEnum_Ljava_lang_Exception_));
			}
			return cb_logInternalError_Lcom_facebook_gamingservices_cloudgaming_internal_SDKMessageEnum_Ljava_lang_Exception_;
		}

		private static void n_LogInternalError_Lcom_facebook_gamingservices_cloudgaming_internal_SDKMessageEnum_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_functionType, IntPtr native_e)
		{
			SDKLogger sDKLogger = Java.Lang.Object.GetObject<SDKLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SDKMessageEnum functionType = Java.Lang.Object.GetObject<SDKMessageEnum>(native_functionType, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception e = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_e, JniHandleOwnership.DoNotTransfer);
			sDKLogger.LogInternalError(functionType, e);
		}

		[Register("logInternalError", "(Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;Ljava/lang/Exception;)V", "GetLogInternalError_Lcom_facebook_gamingservices_cloudgaming_internal_SDKMessageEnum_Ljava_lang_Exception_Handler")]
		public unsafe virtual void LogInternalError(SDKMessageEnum functionType, Java.Lang.Exception e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(functionType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("logInternalError.(Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;Ljava/lang/Exception;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(functionType);
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetLogLoginSuccessHandler()
		{
			if ((object)cb_logLoginSuccess == null)
			{
				cb_logLoginSuccess = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_LogLoginSuccess));
			}
			return cb_logLoginSuccess;
		}

		private static void n_LogLoginSuccess(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SDKLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LogLoginSuccess();
		}

		[Register("logLoginSuccess", "()V", "GetLogLoginSuccessHandler")]
		public unsafe virtual void LogLoginSuccess()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("logLoginSuccess.()V", this, null);
		}

		private static Delegate GetLogPreparingRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_Handler()
		{
			if ((object)cb_logPreparingRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_ == null)
			{
				cb_logPreparingRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_LogPreparingRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_));
			}
			return cb_logPreparingRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_;
		}

		private static void n_LogPreparingRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_functionType, IntPtr native_requestID, IntPtr native_payloads)
		{
			SDKLogger sDKLogger = Java.Lang.Object.GetObject<SDKLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string functionType = JNIEnv.GetString(native_functionType, JniHandleOwnership.DoNotTransfer);
			string requestID = JNIEnv.GetString(native_requestID, JniHandleOwnership.DoNotTransfer);
			JSONObject payloads = Java.Lang.Object.GetObject<JSONObject>(native_payloads, JniHandleOwnership.DoNotTransfer);
			sDKLogger.LogPreparingRequest(functionType, requestID, payloads);
		}

		[Register("logPreparingRequest", "(Ljava/lang/String;Ljava/lang/String;Lorg/json/JSONObject;)V", "GetLogPreparingRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_Handler")]
		public unsafe virtual void LogPreparingRequest(string functionType, string requestID, JSONObject payloads)
		{
			IntPtr intPtr = JNIEnv.NewString(functionType);
			IntPtr intPtr2 = JNIEnv.NewString(requestID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(payloads?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("logPreparingRequest.(Ljava/lang/String;Ljava/lang/String;Lorg/json/JSONObject;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(payloads);
			}
		}

		private static Delegate GetLogSendingErrorResponse_Lcom_facebook_FacebookRequestError_Ljava_lang_String_Handler()
		{
			if ((object)cb_logSendingErrorResponse_Lcom_facebook_FacebookRequestError_Ljava_lang_String_ == null)
			{
				cb_logSendingErrorResponse_Lcom_facebook_FacebookRequestError_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_LogSendingErrorResponse_Lcom_facebook_FacebookRequestError_Ljava_lang_String_));
			}
			return cb_logSendingErrorResponse_Lcom_facebook_FacebookRequestError_Ljava_lang_String_;
		}

		private static void n_LogSendingErrorResponse_Lcom_facebook_FacebookRequestError_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_error, IntPtr native_requestID)
		{
			SDKLogger sDKLogger = Java.Lang.Object.GetObject<SDKLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FacebookRequestError error = Java.Lang.Object.GetObject<FacebookRequestError>(native_error, JniHandleOwnership.DoNotTransfer);
			string requestID = JNIEnv.GetString(native_requestID, JniHandleOwnership.DoNotTransfer);
			sDKLogger.LogSendingErrorResponse(error, requestID);
		}

		[Register("logSendingErrorResponse", "(Lcom/facebook/FacebookRequestError;Ljava/lang/String;)V", "GetLogSendingErrorResponse_Lcom_facebook_FacebookRequestError_Ljava_lang_String_Handler")]
		public unsafe virtual void LogSendingErrorResponse(FacebookRequestError error, string requestID)
		{
			IntPtr intPtr = JNIEnv.NewString(requestID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(error?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("logSendingErrorResponse.(Lcom/facebook/FacebookRequestError;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(error);
			}
		}

		private static Delegate GetLogSendingSuccessResponse_Ljava_lang_String_Handler()
		{
			if ((object)cb_logSendingSuccessResponse_Ljava_lang_String_ == null)
			{
				cb_logSendingSuccessResponse_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_LogSendingSuccessResponse_Ljava_lang_String_));
			}
			return cb_logSendingSuccessResponse_Ljava_lang_String_;
		}

		private static void n_LogSendingSuccessResponse_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_requestID)
		{
			SDKLogger sDKLogger = Java.Lang.Object.GetObject<SDKLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string requestID = JNIEnv.GetString(native_requestID, JniHandleOwnership.DoNotTransfer);
			sDKLogger.LogSendingSuccessResponse(requestID);
		}

		[Register("logSendingSuccessResponse", "(Ljava/lang/String;)V", "GetLogSendingSuccessResponse_Ljava_lang_String_Handler")]
		public unsafe virtual void LogSendingSuccessResponse(string requestID)
		{
			IntPtr intPtr = JNIEnv.NewString(requestID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("logSendingSuccessResponse.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetLogSentRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_Handler()
		{
			if ((object)cb_logSentRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_ == null)
			{
				cb_logSentRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_LogSentRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_));
			}
			return cb_logSentRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_;
		}

		private static void n_LogSentRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_functionType, IntPtr native_requestID, IntPtr native_payloads)
		{
			SDKLogger sDKLogger = Java.Lang.Object.GetObject<SDKLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string functionType = JNIEnv.GetString(native_functionType, JniHandleOwnership.DoNotTransfer);
			string requestID = JNIEnv.GetString(native_requestID, JniHandleOwnership.DoNotTransfer);
			JSONObject payloads = Java.Lang.Object.GetObject<JSONObject>(native_payloads, JniHandleOwnership.DoNotTransfer);
			sDKLogger.LogSentRequest(functionType, requestID, payloads);
		}

		[Register("logSentRequest", "(Ljava/lang/String;Ljava/lang/String;Lorg/json/JSONObject;)V", "GetLogSentRequest_Ljava_lang_String_Ljava_lang_String_Lorg_json_JSONObject_Handler")]
		public unsafe virtual void LogSentRequest(string functionType, string requestID, JSONObject payloads)
		{
			IntPtr intPtr = JNIEnv.NewString(functionType);
			IntPtr intPtr2 = JNIEnv.NewString(requestID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(payloads?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("logSentRequest.(Ljava/lang/String;Ljava/lang/String;Lorg/json/JSONObject;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(payloads);
			}
		}

		private static Delegate GetSetAppID_Ljava_lang_String_Handler()
		{
			if ((object)cb_setAppID_Ljava_lang_String_ == null)
			{
				cb_setAppID_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetAppID_Ljava_lang_String_));
			}
			return cb_setAppID_Ljava_lang_String_;
		}

		private static void n_SetAppID_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_appID)
		{
			SDKLogger sDKLogger = Java.Lang.Object.GetObject<SDKLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string appID = JNIEnv.GetString(native_appID, JniHandleOwnership.DoNotTransfer);
			sDKLogger.SetAppID(appID);
		}

		[Register("setAppID", "(Ljava/lang/String;)V", "GetSetAppID_Ljava_lang_String_Handler")]
		public unsafe virtual void SetAppID(string appID)
		{
			IntPtr intPtr = JNIEnv.NewString(appID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAppID.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetSessionID_Ljava_lang_String_Handler()
		{
			if ((object)cb_setSessionID_Ljava_lang_String_ == null)
			{
				cb_setSessionID_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetSessionID_Ljava_lang_String_));
			}
			return cb_setSessionID_Ljava_lang_String_;
		}

		private static void n_SetSessionID_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_sessionID)
		{
			SDKLogger sDKLogger = Java.Lang.Object.GetObject<SDKLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string sessionID = JNIEnv.GetString(native_sessionID, JniHandleOwnership.DoNotTransfer);
			sDKLogger.SetSessionID(sessionID);
		}

		[Register("setSessionID", "(Ljava/lang/String;)V", "GetSetSessionID_Ljava_lang_String_Handler")]
		public unsafe virtual void SetSessionID(string sessionID)
		{
			IntPtr intPtr = JNIEnv.NewString(sessionID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSessionID.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetUserID_Ljava_lang_String_Handler()
		{
			if ((object)cb_setUserID_Ljava_lang_String_ == null)
			{
				cb_setUserID_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetUserID_Ljava_lang_String_));
			}
			return cb_setUserID_Ljava_lang_String_;
		}

		private static void n_SetUserID_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_userID)
		{
			SDKLogger sDKLogger = Java.Lang.Object.GetObject<SDKLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string userID = JNIEnv.GetString(native_userID, JniHandleOwnership.DoNotTransfer);
			sDKLogger.SetUserID(userID);
		}

		[Register("setUserID", "(Ljava/lang/String;)V", "GetSetUserID_Ljava_lang_String_Handler")]
		public unsafe virtual void SetUserID(string userID)
		{
			IntPtr intPtr = JNIEnv.NewString(userID);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setUserID.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum", DoNotGenerateAcw = true)]
	public sealed class SDKMessageEnum : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum", typeof(SDKMessageEnum));

		[Register("CAN_CREATE_SHORTCUT")]
		public static SDKMessageEnum CanCreateShortcut => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("CAN_CREATE_SHORTCUT.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CONSUME_PURCHASE")]
		public static SDKMessageEnum ConsumePurchase => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("CONSUME_PURCHASE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CONTEXT_CHOOSE")]
		public static SDKMessageEnum ContextChoose => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("CONTEXT_CHOOSE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CONTEXT_CREATE")]
		public static SDKMessageEnum ContextCreate => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("CONTEXT_CREATE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CONTEXT_GET_ID")]
		public static SDKMessageEnum ContextGetId => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("CONTEXT_GET_ID.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CONTEXT_SWITCH")]
		public static SDKMessageEnum ContextSwitch => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("CONTEXT_SWITCH.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CREATE_SHORTCUT")]
		public static SDKMessageEnum CreateShortcut => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("CREATE_SHORTCUT.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DEBUG_PRINT")]
		public static SDKMessageEnum DebugPrint => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("DEBUG_PRINT.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GET_ACCESS_TOKEN")]
		public static SDKMessageEnum GetAccessToken => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("GET_ACCESS_TOKEN.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GET_CATALOG")]
		public static SDKMessageEnum GetCatalog => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("GET_CATALOG.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GET_CONTEXT_TOKEN")]
		public static SDKMessageEnum GetContextToken => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("GET_CONTEXT_TOKEN.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GET_PAYLOAD")]
		public static SDKMessageEnum GetPayload => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("GET_PAYLOAD.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GET_PLAYER_DATA")]
		public static SDKMessageEnum GetPlayerData => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("GET_PLAYER_DATA.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GET_PURCHASES")]
		public static SDKMessageEnum GetPurchases => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("GET_PURCHASES.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GET_TOURNAMENT_ASYNC")]
		public static SDKMessageEnum GetTournamentAsync => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("GET_TOURNAMENT_ASYNC.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("IS_ENV_READY")]
		public static SDKMessageEnum IsEnvReady => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("IS_ENV_READY.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LOAD_INTERSTITIAL_AD")]
		public static SDKMessageEnum LoadInterstitialAd => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("LOAD_INTERSTITIAL_AD.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LOAD_REWARDED_VIDEO")]
		public static SDKMessageEnum LoadRewardedVideo => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("LOAD_REWARDED_VIDEO.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MARK_GAME_LOADED")]
		public static SDKMessageEnum MarkGameLoaded => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("MARK_GAME_LOADED.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ON_READY")]
		public static SDKMessageEnum OnReady => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("ON_READY.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OPEN_APP_STORE")]
		public static SDKMessageEnum OpenAppStore => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("OPEN_APP_STORE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OPEN_GAME_REQUESTS_DIALOG")]
		public static SDKMessageEnum OpenGameRequestsDialog => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("OPEN_GAME_REQUESTS_DIALOG.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OPEN_GAMING_SERVICES_DEEP_LINK")]
		public static SDKMessageEnum OpenGamingServicesDeepLink => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("OPEN_GAMING_SERVICES_DEEP_LINK.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OPEN_LINK")]
		public static SDKMessageEnum OpenLink => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("OPEN_LINK.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OPEN_PLAY_STORE")]
		public static SDKMessageEnum OpenPlayStore => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("OPEN_PLAY_STORE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PERFORM_HAPTIC_FEEDBACK_ASYNC")]
		public static SDKMessageEnum PerformHapticFeedbackAsync => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("PERFORM_HAPTIC_FEEDBACK_ASYNC.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("POST_SESSION_SCORE")]
		public static SDKMessageEnum PostSessionScore => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("POST_SESSION_SCORE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("POST_SESSION_SCORE_ASYNC")]
		public static SDKMessageEnum PostSessionScoreAsync => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("POST_SESSION_SCORE_ASYNC.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PURCHASE")]
		public static SDKMessageEnum Purchase => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("PURCHASE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SET_PLAYER_DATA")]
		public static SDKMessageEnum SetPlayerData => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("SET_PLAYER_DATA.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SHARE")]
		public static SDKMessageEnum Share => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("SHARE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SHOW_INTERSTITIAL_AD")]
		public static SDKMessageEnum ShowInterstitialAd => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("SHOW_INTERSTITIAL_AD.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SHOW_REWARDED_VIDEO")]
		public static SDKMessageEnum ShowRewardedVideo => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("SHOW_REWARDED_VIDEO.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TOURNAMENT_CREATE_ASYNC")]
		public static SDKMessageEnum TournamentCreateAsync => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("TOURNAMENT_CREATE_ASYNC.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TOURNAMENT_GET_TOURNAMENTS_ASYNC")]
		public static SDKMessageEnum TournamentGetTournamentsAsync => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("TOURNAMENT_GET_TOURNAMENTS_ASYNC.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TOURNAMENT_JOIN_ASYNC")]
		public static SDKMessageEnum TournamentJoinAsync => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("TOURNAMENT_JOIN_ASYNC.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TOURNAMENT_POST_SCORE_ASYNC")]
		public static SDKMessageEnum TournamentPostScoreAsync => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("TOURNAMENT_POST_SCORE_ASYNC.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TOURNAMENT_SHARE_ASYNC")]
		public static SDKMessageEnum TournamentShareAsync => Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticFields.GetObjectValue("TOURNAMENT_SHARE_ASYNC.Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal SDKMessageEnum(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("fromString", "(Ljava/lang/String;)Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;", "")]
		public unsafe static SDKMessageEnum FromString(string messageType)
		{
			IntPtr intPtr = JNIEnv.NewString(messageType);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticMethods.InvokeObjectMethod("fromString.(Ljava/lang/String;)Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;", "")]
		public unsafe static SDKMessageEnum ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SDKMessageEnum>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;", "")]
		public unsafe static SDKMessageEnum[] Values()
		{
			return (SDKMessageEnum[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/gamingservices/cloudgaming/internal/SDKMessageEnum;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(SDKMessageEnum));
		}
	}
	[Register("com/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum", DoNotGenerateAcw = true)]
	public sealed class SDKShareIntentEnum : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum", typeof(SDKShareIntentEnum));

		[Register("CHALLENGE")]
		public static SDKShareIntentEnum Challenge => Java.Lang.Object.GetObject<SDKShareIntentEnum>(_members.StaticFields.GetObjectValue("CHALLENGE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INVITE")]
		public static SDKShareIntentEnum Invite => Java.Lang.Object.GetObject<SDKShareIntentEnum>(_members.StaticFields.GetObjectValue("INVITE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("REQUEST")]
		public static SDKShareIntentEnum Request => Java.Lang.Object.GetObject<SDKShareIntentEnum>(_members.StaticFields.GetObjectValue("REQUEST.Lcom/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SHARE")]
		public static SDKShareIntentEnum Share => Java.Lang.Object.GetObject<SDKShareIntentEnum>(_members.StaticFields.GetObjectValue("SHARE.Lcom/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal SDKShareIntentEnum(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("fromString", "(Ljava/lang/String;)Lcom/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum;", "")]
		public unsafe static SDKShareIntentEnum FromString(string intentType)
		{
			IntPtr intPtr = JNIEnv.NewString(intentType);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SDKShareIntentEnum>(_members.StaticMethods.InvokeObjectMethod("fromString.(Ljava/lang/String;)Lcom/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("validate", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe static string Validate(string intentType)
		{
			IntPtr intPtr = JNIEnv.NewString(intentType);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("validate.(Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum;", "")]
		public unsafe static SDKShareIntentEnum ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SDKShareIntentEnum>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum;", "")]
		public unsafe static SDKShareIntentEnum[] Values()
		{
			return (SDKShareIntentEnum[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/gamingservices/cloudgaming/internal/SDKShareIntentEnum;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(SDKShareIntentEnum));
		}
	}
}
