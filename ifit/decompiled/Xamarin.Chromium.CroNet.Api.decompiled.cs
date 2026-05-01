using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Net;
using Java.Nio;
using Java.Util;
using Java.Util.Concurrent;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "org.chromium.net", Managed = "Xamarin.Chromium.CroNet")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Chromium.CroNet.Api")]
[assembly: AssemblyTitle("Xamarin.Chromium.CroNet.Api")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/lizhangqu/cronet/")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPIJ_L(IntPtr jnienv, IntPtr klass, int p0, long p1);
internal delegate void _JniMarshal_PPIJI_V(IntPtr jnienv, IntPtr klass, int p0, long p1, int p2);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLII_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, bool p3);
internal delegate IntPtr _JniMarshal_PPLLZL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, bool p2, IntPtr p3);
internal delegate void _JniMarshal_PPLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate void _JniMarshal_PPLZI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1, int p2);
internal delegate IntPtr _JniMarshal_PPZ_L(IntPtr jnienv, IntPtr klass, bool p0);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
internal delegate void _JniMarshal_PPZZZ_V(IntPtr jnienv, IntPtr klass, bool p0, bool p1, bool p2);
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
namespace Xamarin.Chromium.CroNet
{
	[Register("org/chromium/net/ApiVersion", DoNotGenerateAcw = true)]
	public class ApiVersion : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ApiVersion", typeof(ApiVersion));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe static int ApiLevel
		{
			[Register("getApiLevel", "()I", "")]
			get
			{
				return _members.StaticMethods.InvokeInt32Method("getApiLevel.()I", null);
			}
		}

		public unsafe static string CronetVersion
		{
			[Register("getCronetVersion", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getCronetVersion.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static string CronetVersionWithLastChange
		{
			[Register("getCronetVersionWithLastChange", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getCronetVersionWithLastChange.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static string LastChange
		{
			[Register("getLastChange", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getLastChange.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static int MaximumAvailableApiLevel
		{
			[Register("getMaximumAvailableApiLevel", "()I", "")]
			get
			{
				return _members.StaticMethods.InvokeInt32Method("getMaximumAvailableApiLevel.()I", null);
			}
		}

		protected ApiVersion(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("org/chromium/net/BidirectionalStream", DoNotGenerateAcw = true)]
	public abstract class BidirectionalStream : Java.Lang.Object
	{
		[Register("org/chromium/net/BidirectionalStream$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			[Register("STREAM_PRIORITY_HIGHEST")]
			public const int StreamPriorityHighest = 4;

			[Register("STREAM_PRIORITY_IDLE")]
			public const int StreamPriorityIdle = 0;

			[Register("STREAM_PRIORITY_LOW")]
			public const int StreamPriorityLow = 2;

			[Register("STREAM_PRIORITY_LOWEST")]
			public const int StreamPriorityLowest = 1;

			[Register("STREAM_PRIORITY_MEDIUM")]
			public const int StreamPriorityMedium = 3;

			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/BidirectionalStream$Builder", typeof(Builder));

			private static Delegate cb_addHeader_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_build;

			private static Delegate cb_delayRequestHeadersUntilFirstFlush_Z;

			private static Delegate cb_setHttpMethod_Ljava_lang_String_;

			private static Delegate cb_setPriority_I;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			private static Delegate GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler()
			{
				if ((object)cb_addHeader_Ljava_lang_String_Ljava_lang_String_ == null)
				{
					cb_addHeader_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddHeader_Ljava_lang_String_Ljava_lang_String_));
				}
				return cb_addHeader_Ljava_lang_String_Ljava_lang_String_;
			}

			private static IntPtr n_AddHeader_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddHeader(p, p2));
			}

			[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/BidirectionalStream$Builder;", "GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public abstract Builder AddHeader(string p0, string p1);

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

			[Register("build", "()Lorg/chromium/net/BidirectionalStream;", "GetBuildHandler")]
			public abstract BidirectionalStream Build();

			private static Delegate GetDelayRequestHeadersUntilFirstFlush_ZHandler()
			{
				if ((object)cb_delayRequestHeadersUntilFirstFlush_Z == null)
				{
					cb_delayRequestHeadersUntilFirstFlush_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_DelayRequestHeadersUntilFirstFlush_Z));
				}
				return cb_delayRequestHeadersUntilFirstFlush_Z;
			}

			private static IntPtr n_DelayRequestHeadersUntilFirstFlush_Z(IntPtr jnienv, IntPtr native__this, bool p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DelayRequestHeadersUntilFirstFlush(p0));
			}

			[Register("delayRequestHeadersUntilFirstFlush", "(Z)Lorg/chromium/net/BidirectionalStream$Builder;", "GetDelayRequestHeadersUntilFirstFlush_ZHandler")]
			public abstract Builder DelayRequestHeadersUntilFirstFlush(bool p0);

			private static Delegate GetSetHttpMethod_Ljava_lang_String_Handler()
			{
				if ((object)cb_setHttpMethod_Ljava_lang_String_ == null)
				{
					cb_setHttpMethod_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetHttpMethod_Ljava_lang_String_));
				}
				return cb_setHttpMethod_Ljava_lang_String_;
			}

			private static IntPtr n_SetHttpMethod_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string httpMethod = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetHttpMethod(httpMethod));
			}

			[Register("setHttpMethod", "(Ljava/lang/String;)Lorg/chromium/net/BidirectionalStream$Builder;", "GetSetHttpMethod_Ljava_lang_String_Handler")]
			public abstract Builder SetHttpMethod(string p0);

			private static Delegate GetSetPriority_IHandler()
			{
				if ((object)cb_setPriority_I == null)
				{
					cb_setPriority_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetPriority_I));
				}
				return cb_setPriority_I;
			}

			private static IntPtr n_SetPriority_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPriority(p0));
			}

			[Register("setPriority", "(I)Lorg/chromium/net/BidirectionalStream$Builder;", "GetSetPriority_IHandler")]
			public abstract Builder SetPriority(int p0);
		}

		[Register("org/chromium/net/BidirectionalStream$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/BidirectionalStream$Builder", typeof(BuilderInvoker));

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

			[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/BidirectionalStream$Builder;", "GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe override Builder AddHeader(string p0, string p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewString(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addHeader.(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/BidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("build", "()Lorg/chromium/net/BidirectionalStream;", "GetBuildHandler")]
			public unsafe override BidirectionalStream Build()
			{
				return Java.Lang.Object.GetObject<BidirectionalStream>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lorg/chromium/net/BidirectionalStream;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("delayRequestHeadersUntilFirstFlush", "(Z)Lorg/chromium/net/BidirectionalStream$Builder;", "GetDelayRequestHeadersUntilFirstFlush_ZHandler")]
			public unsafe override Builder DelayRequestHeadersUntilFirstFlush(bool p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("delayRequestHeadersUntilFirstFlush.(Z)Lorg/chromium/net/BidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setHttpMethod", "(Ljava/lang/String;)Lorg/chromium/net/BidirectionalStream$Builder;", "GetSetHttpMethod_Ljava_lang_String_Handler")]
			public unsafe override Builder SetHttpMethod(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setHttpMethod.(Ljava/lang/String;)Lorg/chromium/net/BidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setPriority", "(I)Lorg/chromium/net/BidirectionalStream$Builder;", "GetSetPriority_IHandler")]
			public unsafe override Builder SetPriority(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPriority.(I)Lorg/chromium/net/BidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/chromium/net/BidirectionalStream$Callback", DoNotGenerateAcw = true)]
		public abstract class Callback : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/BidirectionalStream$Callback", typeof(Callback));

			private static Delegate cb_onCanceled_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_;

			private static Delegate cb_onFailed_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_;

			private static Delegate cb_onReadCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z;

			private static Delegate cb_onResponseHeadersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_;

			private static Delegate cb_onResponseTrailersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_UrlResponseInfo_HeaderBlock_;

			private static Delegate cb_onStreamReady_Lorg_chromium_net_BidirectionalStream_;

			private static Delegate cb_onSucceeded_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_;

			private static Delegate cb_onWriteCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			protected Callback(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Callback()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetOnCanceled_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Handler()
			{
				if ((object)cb_onCanceled_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_ == null)
				{
					cb_onCanceled_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnCanceled_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_));
				}
				return cb_onCanceled_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_;
			}

			private static void n_OnCanceled_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_stream, IntPtr native_info)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				BidirectionalStream stream = Java.Lang.Object.GetObject<BidirectionalStream>(native_stream, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo info = Java.Lang.Object.GetObject<UrlResponseInfo>(native_info, JniHandleOwnership.DoNotTransfer);
				callback.OnCanceled(stream, info);
			}

			[Register("onCanceled", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;)V", "GetOnCanceled_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Handler")]
			public unsafe virtual void OnCanceled(BidirectionalStream stream, UrlResponseInfo info)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(stream?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onCanceled.(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(stream);
					GC.KeepAlive(info);
				}
			}

			private static Delegate GetOnFailed_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_Handler()
			{
				if ((object)cb_onFailed_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_ == null)
				{
					cb_onFailed_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnFailed_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_));
				}
				return cb_onFailed_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_;
			}

			private static void n_OnFailed_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				BidirectionalStream p = Java.Lang.Object.GetObject<BidirectionalStream>(native_p0, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo p2 = Java.Lang.Object.GetObject<UrlResponseInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
				CronetException p3 = Java.Lang.Object.GetObject<CronetException>(native_p2, JniHandleOwnership.DoNotTransfer);
				callback.OnFailed(p, p2, p3);
			}

			[Register("onFailed", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Lorg/chromium/net/CronetException;)V", "GetOnFailed_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_Handler")]
			public abstract void OnFailed(BidirectionalStream p0, UrlResponseInfo p1, CronetException p2);

			private static Delegate GetOnReadCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_ZHandler()
			{
				if ((object)cb_onReadCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z == null)
				{
					cb_onReadCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLZ_V(n_OnReadCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z));
				}
				return cb_onReadCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z;
			}

			private static void n_OnReadCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, bool p3)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				BidirectionalStream p4 = Java.Lang.Object.GetObject<BidirectionalStream>(native_p0, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo p5 = Java.Lang.Object.GetObject<UrlResponseInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
				ByteBuffer p6 = Java.Lang.Object.GetObject<ByteBuffer>(native_p2, JniHandleOwnership.DoNotTransfer);
				callback.OnReadCompleted(p4, p5, p6, p3);
			}

			[Register("onReadCompleted", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Ljava/nio/ByteBuffer;Z)V", "GetOnReadCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_ZHandler")]
			public abstract void OnReadCompleted(BidirectionalStream p0, UrlResponseInfo p1, ByteBuffer p2, bool p3);

			private static Delegate GetOnResponseHeadersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Handler()
			{
				if ((object)cb_onResponseHeadersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_ == null)
				{
					cb_onResponseHeadersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnResponseHeadersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_));
				}
				return cb_onResponseHeadersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_;
			}

			private static void n_OnResponseHeadersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				BidirectionalStream p = Java.Lang.Object.GetObject<BidirectionalStream>(native_p0, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo p2 = Java.Lang.Object.GetObject<UrlResponseInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
				callback.OnResponseHeadersReceived(p, p2);
			}

			[Register("onResponseHeadersReceived", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;)V", "GetOnResponseHeadersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Handler")]
			public abstract void OnResponseHeadersReceived(BidirectionalStream p0, UrlResponseInfo p1);

			private static Delegate GetOnResponseTrailersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_UrlResponseInfo_HeaderBlock_Handler()
			{
				if ((object)cb_onResponseTrailersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_UrlResponseInfo_HeaderBlock_ == null)
				{
					cb_onResponseTrailersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_UrlResponseInfo_HeaderBlock_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnResponseTrailersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_UrlResponseInfo_HeaderBlock_));
				}
				return cb_onResponseTrailersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_UrlResponseInfo_HeaderBlock_;
			}

			private static void n_OnResponseTrailersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_UrlResponseInfo_HeaderBlock_(IntPtr jnienv, IntPtr native__this, IntPtr native_stream, IntPtr native_info, IntPtr native_trailers)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				BidirectionalStream stream = Java.Lang.Object.GetObject<BidirectionalStream>(native_stream, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo info = Java.Lang.Object.GetObject<UrlResponseInfo>(native_info, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo.HeaderBlock trailers = Java.Lang.Object.GetObject<UrlResponseInfo.HeaderBlock>(native_trailers, JniHandleOwnership.DoNotTransfer);
				callback.OnResponseTrailersReceived(stream, info, trailers);
			}

			[Register("onResponseTrailersReceived", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Lorg/chromium/net/UrlResponseInfo$HeaderBlock;)V", "GetOnResponseTrailersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_UrlResponseInfo_HeaderBlock_Handler")]
			public unsafe virtual void OnResponseTrailersReceived(BidirectionalStream stream, UrlResponseInfo info, UrlResponseInfo.HeaderBlock trailers)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(stream?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(trailers?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onResponseTrailersReceived.(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Lorg/chromium/net/UrlResponseInfo$HeaderBlock;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(stream);
					GC.KeepAlive(info);
					GC.KeepAlive(trailers);
				}
			}

			private static Delegate GetOnStreamReady_Lorg_chromium_net_BidirectionalStream_Handler()
			{
				if ((object)cb_onStreamReady_Lorg_chromium_net_BidirectionalStream_ == null)
				{
					cb_onStreamReady_Lorg_chromium_net_BidirectionalStream_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnStreamReady_Lorg_chromium_net_BidirectionalStream_));
				}
				return cb_onStreamReady_Lorg_chromium_net_BidirectionalStream_;
			}

			private static void n_OnStreamReady_Lorg_chromium_net_BidirectionalStream_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				BidirectionalStream p = Java.Lang.Object.GetObject<BidirectionalStream>(native_p0, JniHandleOwnership.DoNotTransfer);
				callback.OnStreamReady(p);
			}

			[Register("onStreamReady", "(Lorg/chromium/net/BidirectionalStream;)V", "GetOnStreamReady_Lorg_chromium_net_BidirectionalStream_Handler")]
			public abstract void OnStreamReady(BidirectionalStream p0);

			private static Delegate GetOnSucceeded_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Handler()
			{
				if ((object)cb_onSucceeded_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_ == null)
				{
					cb_onSucceeded_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnSucceeded_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_));
				}
				return cb_onSucceeded_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_;
			}

			private static void n_OnSucceeded_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				BidirectionalStream p = Java.Lang.Object.GetObject<BidirectionalStream>(native_p0, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo p2 = Java.Lang.Object.GetObject<UrlResponseInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
				callback.OnSucceeded(p, p2);
			}

			[Register("onSucceeded", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;)V", "GetOnSucceeded_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Handler")]
			public abstract void OnSucceeded(BidirectionalStream p0, UrlResponseInfo p1);

			private static Delegate GetOnWriteCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_ZHandler()
			{
				if ((object)cb_onWriteCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z == null)
				{
					cb_onWriteCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLZ_V(n_OnWriteCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z));
				}
				return cb_onWriteCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z;
			}

			private static void n_OnWriteCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, bool p3)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				BidirectionalStream p4 = Java.Lang.Object.GetObject<BidirectionalStream>(native_p0, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo p5 = Java.Lang.Object.GetObject<UrlResponseInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
				ByteBuffer p6 = Java.Lang.Object.GetObject<ByteBuffer>(native_p2, JniHandleOwnership.DoNotTransfer);
				callback.OnWriteCompleted(p4, p5, p6, p3);
			}

			[Register("onWriteCompleted", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Ljava/nio/ByteBuffer;Z)V", "GetOnWriteCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_ZHandler")]
			public abstract void OnWriteCompleted(BidirectionalStream p0, UrlResponseInfo p1, ByteBuffer p2, bool p3);
		}

		[Register("org/chromium/net/BidirectionalStream$Callback", DoNotGenerateAcw = true)]
		internal class CallbackInvoker : Callback
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/BidirectionalStream$Callback", typeof(CallbackInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public CallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("onFailed", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Lorg/chromium/net/CronetException;)V", "GetOnFailed_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_Handler")]
			public unsafe override void OnFailed(BidirectionalStream p0, UrlResponseInfo p1, CronetException p2)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onFailed.(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Lorg/chromium/net/CronetException;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
					GC.KeepAlive(p2);
				}
			}

			[Register("onReadCompleted", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Ljava/nio/ByteBuffer;Z)V", "GetOnReadCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_ZHandler")]
			public unsafe override void OnReadCompleted(BidirectionalStream p0, UrlResponseInfo p1, ByteBuffer p2, bool p3)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(p3);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onReadCompleted.(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Ljava/nio/ByteBuffer;Z)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
					GC.KeepAlive(p2);
				}
			}

			[Register("onResponseHeadersReceived", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;)V", "GetOnResponseHeadersReceived_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Handler")]
			public unsafe override void OnResponseHeadersReceived(BidirectionalStream p0, UrlResponseInfo p1)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onResponseHeadersReceived.(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}

			[Register("onStreamReady", "(Lorg/chromium/net/BidirectionalStream;)V", "GetOnStreamReady_Lorg_chromium_net_BidirectionalStream_Handler")]
			public unsafe override void OnStreamReady(BidirectionalStream p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onStreamReady.(Lorg/chromium/net/BidirectionalStream;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("onSucceeded", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;)V", "GetOnSucceeded_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Handler")]
			public unsafe override void OnSucceeded(BidirectionalStream p0, UrlResponseInfo p1)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onSucceeded.(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}

			[Register("onWriteCompleted", "(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Ljava/nio/ByteBuffer;Z)V", "GetOnWriteCompleted_Lorg_chromium_net_BidirectionalStream_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_ZHandler")]
			public unsafe override void OnWriteCompleted(BidirectionalStream p0, UrlResponseInfo p1, ByteBuffer p2, bool p3)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(p3);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onWriteCompleted.(Lorg/chromium/net/BidirectionalStream;Lorg/chromium/net/UrlResponseInfo;Ljava/nio/ByteBuffer;Z)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
					GC.KeepAlive(p2);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/BidirectionalStream", typeof(BidirectionalStream));

		private static Delegate cb_isDone;

		private static Delegate cb_cancel;

		private static Delegate cb_flush;

		private static Delegate cb_read_Ljava_nio_ByteBuffer_;

		private static Delegate cb_start;

		private static Delegate cb_write_Ljava_nio_ByteBuffer_Z;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract bool IsDone
		{
			[Register("isDone", "()Z", "GetIsDoneHandler")]
			get;
		}

		protected BidirectionalStream(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BidirectionalStream()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsDoneHandler()
		{
			if ((object)cb_isDone == null)
			{
				cb_isDone = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDone));
			}
			return cb_isDone;
		}

		private static bool n_IsDone(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<BidirectionalStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDone;
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
			Java.Lang.Object.GetObject<BidirectionalStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		public abstract void Cancel();

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
			Java.Lang.Object.GetObject<BidirectionalStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Flush();
		}

		[Register("flush", "()V", "GetFlushHandler")]
		public abstract void Flush();

		private static Delegate GetRead_Ljava_nio_ByteBuffer_Handler()
		{
			if ((object)cb_read_Ljava_nio_ByteBuffer_ == null)
			{
				cb_read_Ljava_nio_ByteBuffer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Read_Ljava_nio_ByteBuffer_));
			}
			return cb_read_Ljava_nio_ByteBuffer_;
		}

		private static void n_Read_Ljava_nio_ByteBuffer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			BidirectionalStream bidirectionalStream = Java.Lang.Object.GetObject<BidirectionalStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteBuffer p = Java.Lang.Object.GetObject<ByteBuffer>(native_p0, JniHandleOwnership.DoNotTransfer);
			bidirectionalStream.Read(p);
		}

		[Register("read", "(Ljava/nio/ByteBuffer;)V", "GetRead_Ljava_nio_ByteBuffer_Handler")]
		public abstract void Read(ByteBuffer p0);

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
			Java.Lang.Object.GetObject<BidirectionalStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Start();
		}

		[Register("start", "()V", "GetStartHandler")]
		public abstract void Start();

		private static Delegate GetWrite_Ljava_nio_ByteBuffer_ZHandler()
		{
			if ((object)cb_write_Ljava_nio_ByteBuffer_Z == null)
			{
				cb_write_Ljava_nio_ByteBuffer_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_Write_Ljava_nio_ByteBuffer_Z));
			}
			return cb_write_Ljava_nio_ByteBuffer_Z;
		}

		private static void n_Write_Ljava_nio_ByteBuffer_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			BidirectionalStream bidirectionalStream = Java.Lang.Object.GetObject<BidirectionalStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteBuffer p2 = Java.Lang.Object.GetObject<ByteBuffer>(native_p0, JniHandleOwnership.DoNotTransfer);
			bidirectionalStream.Write(p2, p1);
		}

		[Register("write", "(Ljava/nio/ByteBuffer;Z)V", "GetWrite_Ljava_nio_ByteBuffer_ZHandler")]
		public abstract void Write(ByteBuffer p0, bool p1);
	}
	[Register("org/chromium/net/BidirectionalStream", DoNotGenerateAcw = true)]
	internal class BidirectionalStreamInvoker : BidirectionalStream
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/BidirectionalStream", typeof(BidirectionalStreamInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsDone
		{
			[Register("isDone", "()Z", "GetIsDoneHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isDone.()Z", this, null);
			}
		}

		public BidirectionalStreamInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		public unsafe override void Cancel()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("cancel.()V", this, null);
		}

		[Register("flush", "()V", "GetFlushHandler")]
		public unsafe override void Flush()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("flush.()V", this, null);
		}

		[Register("read", "(Ljava/nio/ByteBuffer;)V", "GetRead_Ljava_nio_ByteBuffer_Handler")]
		public unsafe override void Read(ByteBuffer p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("read.(Ljava/nio/ByteBuffer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("start", "()V", "GetStartHandler")]
		public unsafe override void Start()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("start.()V", this, null);
		}

		[Register("write", "(Ljava/nio/ByteBuffer;Z)V", "GetWrite_Ljava_nio_ByteBuffer_ZHandler")]
		public unsafe override void Write(ByteBuffer p0, bool p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				_members.InstanceMethods.InvokeAbstractVoidMethod("write.(Ljava/nio/ByteBuffer;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("org/chromium/net/CallbackException", DoNotGenerateAcw = true)]
	public abstract class CallbackException : CronetException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CallbackException", typeof(CallbackException));

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

		protected CallbackException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		protected unsafe CallbackException(string message, Throwable cause)
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
	}
	[Register("org/chromium/net/CallbackException", DoNotGenerateAcw = true)]
	internal class CallbackExceptionInvoker : CallbackException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CallbackException", typeof(CallbackExceptionInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public CallbackExceptionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("org/chromium/net/CronetEngine", DoNotGenerateAcw = true)]
	public abstract class CronetEngine : Java.Lang.Object
	{
		[Register("org/chromium/net/CronetEngine$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			[Register("org/chromium/net/CronetEngine$Builder$LibraryLoader", DoNotGenerateAcw = true)]
			public abstract class LibraryLoader : Java.Lang.Object
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CronetEngine$Builder$LibraryLoader", typeof(LibraryLoader));

				private static Delegate cb_loadLibrary_Ljava_lang_String_;

				internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				public override JniPeerMembers JniPeerMembers => _members;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				protected override Type ThresholdType => _members.ManagedPeerType;

				protected LibraryLoader(IntPtr javaReference, JniHandleOwnership transfer)
					: base(javaReference, transfer)
				{
				}

				[Register(".ctor", "()V", "")]
				public unsafe LibraryLoader()
					: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
				{
					if (!(base.Handle != IntPtr.Zero))
					{
						SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
						_members.InstanceMethods.FinishCreateInstance("()V", this, null);
					}
				}

				private static Delegate GetLoadLibrary_Ljava_lang_String_Handler()
				{
					if ((object)cb_loadLibrary_Ljava_lang_String_ == null)
					{
						cb_loadLibrary_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_LoadLibrary_Ljava_lang_String_));
					}
					return cb_loadLibrary_Ljava_lang_String_;
				}

				private static void n_LoadLibrary_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
				{
					LibraryLoader libraryLoader = Java.Lang.Object.GetObject<LibraryLoader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
					libraryLoader.LoadLibrary(p);
				}

				[Register("loadLibrary", "(Ljava/lang/String;)V", "GetLoadLibrary_Ljava_lang_String_Handler")]
				public abstract void LoadLibrary(string p0);
			}

			[Register("org/chromium/net/CronetEngine$Builder$LibraryLoader", DoNotGenerateAcw = true)]
			internal class LibraryLoaderInvoker : LibraryLoader
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CronetEngine$Builder$LibraryLoader", typeof(LibraryLoaderInvoker));

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				public override JniPeerMembers JniPeerMembers => _members;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				[EditorBrowsable(EditorBrowsableState.Never)]
				protected override Type ThresholdType => _members.ManagedPeerType;

				public LibraryLoaderInvoker(IntPtr handle, JniHandleOwnership transfer)
					: base(handle, transfer)
				{
				}

				[Register("loadLibrary", "(Ljava/lang/String;)V", "GetLoadLibrary_Ljava_lang_String_Handler")]
				public unsafe override void LoadLibrary(string p0)
				{
					IntPtr intPtr = JNIEnv.NewString(p0);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						_members.InstanceMethods.InvokeAbstractVoidMethod("loadLibrary.(Ljava/lang/String;)V", this, ptr);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
					}
				}
			}

			[Register("HTTP_CACHE_DISABLED")]
			public const int HttpCacheDisabled = 0;

			[Register("HTTP_CACHE_DISK")]
			public const int HttpCacheDisk = 3;

			[Register("HTTP_CACHE_DISK_NO_HTTP")]
			public const int HttpCacheDiskNoHttp = 2;

			[Register("HTTP_CACHE_IN_MEMORY")]
			public const int HttpCacheInMemory = 1;

			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CronetEngine$Builder", typeof(Builder));

			private static Delegate cb_getDefaultUserAgent;

			private static Delegate cb_addPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_;

			private static Delegate cb_addQuicHint_Ljava_lang_String_II;

			private static Delegate cb_build;

			private static Delegate cb_enableBrotli_Z;

			private static Delegate cb_enableHttp2_Z;

			private static Delegate cb_enableHttpCache_IJ;

			private static Delegate cb_enablePublicKeyPinningBypassForLocalTrustAnchors_Z;

			private static Delegate cb_enableQuic_Z;

			private static Delegate cb_enableSdch_Z;

			private static Delegate cb_setLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_;

			private static Delegate cb_setStoragePath_Ljava_lang_String_;

			private static Delegate cb_setUserAgent_Ljava_lang_String_;

			[Register("mBuilderDelegate")]
			protected ICronetEngineBuilder MBuilderDelegate
			{
				get
				{
					return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceFields.GetObjectValue("mBuilderDelegate.Lorg/chromium/net/ICronetEngineBuilder;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("mBuilderDelegate.Lorg/chromium/net/ICronetEngineBuilder;", this, new JniObjectReference(jobject));
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

			public unsafe virtual string DefaultUserAgent
			{
				[Register("getDefaultUserAgent", "()Ljava/lang/String;", "GetGetDefaultUserAgentHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultUserAgent.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/content/Context;)V", "")]
			public unsafe Builder(Context context)
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

			[Register(".ctor", "(Lorg/chromium/net/ICronetEngineBuilder;)V", "")]
			public unsafe Builder(ICronetEngineBuilder builderDelegate)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(builderDelegate?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lorg/chromium/net/ICronetEngineBuilder;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lorg/chromium/net/ICronetEngineBuilder;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(builderDelegate);
				}
			}

			private static Delegate GetGetDefaultUserAgentHandler()
			{
				if ((object)cb_getDefaultUserAgent == null)
				{
					cb_getDefaultUserAgent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefaultUserAgent));
				}
				return cb_getDefaultUserAgent;
			}

			private static IntPtr n_GetDefaultUserAgent(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultUserAgent);
			}

			private static Delegate GetAddPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_Handler()
			{
				if ((object)cb_addPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_ == null)
				{
					cb_addPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZL_L(n_AddPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_));
				}
				return cb_addPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_;
			}

			private static IntPtr n_AddPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_(IntPtr jnienv, IntPtr native__this, IntPtr native_hostName, IntPtr native_pinsSha256, bool includeSubdomains, IntPtr native_expirationDate)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string hostName = JNIEnv.GetString(native_hostName, JniHandleOwnership.DoNotTransfer);
				ICollection<byte[]> pinsSha = JavaSet<byte[]>.FromJniHandle(native_pinsSha256, JniHandleOwnership.DoNotTransfer);
				Date expirationDate = Java.Lang.Object.GetObject<Date>(native_expirationDate, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddPublicKeyPins(hostName, pinsSha, includeSubdomains, expirationDate));
			}

			[Register("addPublicKeyPins", "(Ljava/lang/String;Ljava/util/Set;ZLjava/util/Date;)Lorg/chromium/net/CronetEngine$Builder;", "GetAddPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_Handler")]
			public unsafe virtual Builder AddPublicKeyPins(string hostName, ICollection<byte[]> pinsSha256, bool includeSubdomains, Date expirationDate)
			{
				IntPtr intPtr = JNIEnv.NewString(hostName);
				IntPtr intPtr2 = JavaSet<byte[]>.ToLocalJniHandle(pinsSha256);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					ptr[2] = new JniArgumentValue(includeSubdomains);
					ptr[3] = new JniArgumentValue(expirationDate?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addPublicKeyPins.(Ljava/lang/String;Ljava/util/Set;ZLjava/util/Date;)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(pinsSha256);
					GC.KeepAlive(expirationDate);
				}
			}

			private static Delegate GetAddQuicHint_Ljava_lang_String_IIHandler()
			{
				if ((object)cb_addQuicHint_Ljava_lang_String_II == null)
				{
					cb_addQuicHint_Ljava_lang_String_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_AddQuicHint_Ljava_lang_String_II));
				}
				return cb_addQuicHint_Ljava_lang_String_II;
			}

			private static IntPtr n_AddQuicHint_Ljava_lang_String_II(IntPtr jnienv, IntPtr native__this, IntPtr native_host, int port, int alternatePort)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string host = JNIEnv.GetString(native_host, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddQuicHint(host, port, alternatePort));
			}

			[Register("addQuicHint", "(Ljava/lang/String;II)Lorg/chromium/net/CronetEngine$Builder;", "GetAddQuicHint_Ljava_lang_String_IIHandler")]
			public unsafe virtual Builder AddQuicHint(string host, int port, int alternatePort)
			{
				IntPtr intPtr = JNIEnv.NewString(host);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(port);
					ptr[2] = new JniArgumentValue(alternatePort);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addQuicHint.(Ljava/lang/String;II)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
			}

			[Register("build", "()Lorg/chromium/net/CronetEngine;", "GetBuildHandler")]
			public unsafe virtual CronetEngine Build()
			{
				return Java.Lang.Object.GetObject<CronetEngine>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lorg/chromium/net/CronetEngine;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetEnableBrotli_ZHandler()
			{
				if ((object)cb_enableBrotli_Z == null)
				{
					cb_enableBrotli_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableBrotli_Z));
				}
				return cb_enableBrotli_Z;
			}

			private static IntPtr n_EnableBrotli_Z(IntPtr jnienv, IntPtr native__this, bool value)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableBrotli(value));
			}

			[Register("enableBrotli", "(Z)Lorg/chromium/net/CronetEngine$Builder;", "GetEnableBrotli_ZHandler")]
			public unsafe virtual Builder EnableBrotli(bool value)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("enableBrotli.(Z)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetEnableHttp2_ZHandler()
			{
				if ((object)cb_enableHttp2_Z == null)
				{
					cb_enableHttp2_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableHttp2_Z));
				}
				return cb_enableHttp2_Z;
			}

			private static IntPtr n_EnableHttp2_Z(IntPtr jnienv, IntPtr native__this, bool value)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableHttp2(value));
			}

			[Register("enableHttp2", "(Z)Lorg/chromium/net/CronetEngine$Builder;", "GetEnableHttp2_ZHandler")]
			public unsafe virtual Builder EnableHttp2(bool value)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("enableHttp2.(Z)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetEnableHttpCache_IJHandler()
			{
				if ((object)cb_enableHttpCache_IJ == null)
				{
					cb_enableHttpCache_IJ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIJ_L(n_EnableHttpCache_IJ));
				}
				return cb_enableHttpCache_IJ;
			}

			private static IntPtr n_EnableHttpCache_IJ(IntPtr jnienv, IntPtr native__this, int cacheMode, long maxSize)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableHttpCache(cacheMode, maxSize));
			}

			[Register("enableHttpCache", "(IJ)Lorg/chromium/net/CronetEngine$Builder;", "GetEnableHttpCache_IJHandler")]
			public unsafe virtual Builder EnableHttpCache(int cacheMode, long maxSize)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(cacheMode);
				ptr[1] = new JniArgumentValue(maxSize);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("enableHttpCache.(IJ)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetEnablePublicKeyPinningBypassForLocalTrustAnchors_ZHandler()
			{
				if ((object)cb_enablePublicKeyPinningBypassForLocalTrustAnchors_Z == null)
				{
					cb_enablePublicKeyPinningBypassForLocalTrustAnchors_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnablePublicKeyPinningBypassForLocalTrustAnchors_Z));
				}
				return cb_enablePublicKeyPinningBypassForLocalTrustAnchors_Z;
			}

			private static IntPtr n_EnablePublicKeyPinningBypassForLocalTrustAnchors_Z(IntPtr jnienv, IntPtr native__this, bool value)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnablePublicKeyPinningBypassForLocalTrustAnchors(value));
			}

			[Register("enablePublicKeyPinningBypassForLocalTrustAnchors", "(Z)Lorg/chromium/net/CronetEngine$Builder;", "GetEnablePublicKeyPinningBypassForLocalTrustAnchors_ZHandler")]
			public unsafe virtual Builder EnablePublicKeyPinningBypassForLocalTrustAnchors(bool value)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("enablePublicKeyPinningBypassForLocalTrustAnchors.(Z)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetEnableQuic_ZHandler()
			{
				if ((object)cb_enableQuic_Z == null)
				{
					cb_enableQuic_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableQuic_Z));
				}
				return cb_enableQuic_Z;
			}

			private static IntPtr n_EnableQuic_Z(IntPtr jnienv, IntPtr native__this, bool value)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableQuic(value));
			}

			[Register("enableQuic", "(Z)Lorg/chromium/net/CronetEngine$Builder;", "GetEnableQuic_ZHandler")]
			public unsafe virtual Builder EnableQuic(bool value)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("enableQuic.(Z)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Obsolete]
			private static Delegate GetEnableSdch_ZHandler()
			{
				if ((object)cb_enableSdch_Z == null)
				{
					cb_enableSdch_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableSdch_Z));
				}
				return cb_enableSdch_Z;
			}

			[Obsolete]
			private static IntPtr n_EnableSdch_Z(IntPtr jnienv, IntPtr native__this, bool value)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableSdch(value));
			}

			[Obsolete("deprecated")]
			[Register("enableSdch", "(Z)Lorg/chromium/net/CronetEngine$Builder;", "GetEnableSdch_ZHandler")]
			public unsafe virtual Builder EnableSdch(bool value)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("enableSdch.(Z)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_Handler()
			{
				if ((object)cb_setLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_ == null)
				{
					cb_setLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_));
				}
				return cb_setLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_;
			}

			private static IntPtr n_SetLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_(IntPtr jnienv, IntPtr native__this, IntPtr native_loader)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				LibraryLoader libraryLoader = Java.Lang.Object.GetObject<LibraryLoader>(native_loader, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetLibraryLoader(libraryLoader));
			}

			[Register("setLibraryLoader", "(Lorg/chromium/net/CronetEngine$Builder$LibraryLoader;)Lorg/chromium/net/CronetEngine$Builder;", "GetSetLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_Handler")]
			public unsafe virtual Builder SetLibraryLoader(LibraryLoader loader)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(loader?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLibraryLoader.(Lorg/chromium/net/CronetEngine$Builder$LibraryLoader;)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(loader);
				}
			}

			private static Delegate GetSetStoragePath_Ljava_lang_String_Handler()
			{
				if ((object)cb_setStoragePath_Ljava_lang_String_ == null)
				{
					cb_setStoragePath_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetStoragePath_Ljava_lang_String_));
				}
				return cb_setStoragePath_Ljava_lang_String_;
			}

			private static IntPtr n_SetStoragePath_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string storagePath = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetStoragePath(storagePath));
			}

			[Register("setStoragePath", "(Ljava/lang/String;)Lorg/chromium/net/CronetEngine$Builder;", "GetSetStoragePath_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetStoragePath(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setStoragePath.(Ljava/lang/String;)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetUserAgent_Ljava_lang_String_Handler()
			{
				if ((object)cb_setUserAgent_Ljava_lang_String_ == null)
				{
					cb_setUserAgent_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetUserAgent_Ljava_lang_String_));
				}
				return cb_setUserAgent_Ljava_lang_String_;
			}

			private static IntPtr n_SetUserAgent_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_userAgent)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string userAgent = JNIEnv.GetString(native_userAgent, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetUserAgent(userAgent));
			}

			[Register("setUserAgent", "(Ljava/lang/String;)Lorg/chromium/net/CronetEngine$Builder;", "GetSetUserAgent_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetUserAgent(string userAgent)
			{
				IntPtr intPtr = JNIEnv.NewString(userAgent);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setUserAgent.(Ljava/lang/String;)Lorg/chromium/net/CronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CronetEngine", typeof(CronetEngine));

		private static Delegate cb_getVersionString;

		private static Delegate cb_createURLStreamHandlerFactory;

		private static Delegate cb_getGlobalMetricsDeltas;

		private static Delegate cb_newUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_;

		private static Delegate cb_openConnection_Ljava_net_URL_;

		private static Delegate cb_shutdown;

		private static Delegate cb_startNetLogToFile_Ljava_lang_String_Z;

		private static Delegate cb_stopNetLog;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract string VersionString
		{
			[Register("getVersionString", "()Ljava/lang/String;", "GetGetVersionStringHandler")]
			get;
		}

		protected CronetEngine(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CronetEngine()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetVersionStringHandler()
		{
			if ((object)cb_getVersionString == null)
			{
				cb_getVersionString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVersionString));
			}
			return cb_getVersionString;
		}

		private static IntPtr n_GetVersionString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VersionString);
		}

		private static Delegate GetCreateURLStreamHandlerFactoryHandler()
		{
			if ((object)cb_createURLStreamHandlerFactory == null)
			{
				cb_createURLStreamHandlerFactory = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateURLStreamHandlerFactory));
			}
			return cb_createURLStreamHandlerFactory;
		}

		private static IntPtr n_CreateURLStreamHandlerFactory(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateURLStreamHandlerFactory());
		}

		[Register("createURLStreamHandlerFactory", "()Ljava/net/URLStreamHandlerFactory;", "GetCreateURLStreamHandlerFactoryHandler")]
		public abstract IURLStreamHandlerFactory CreateURLStreamHandlerFactory();

		private static Delegate GetGetGlobalMetricsDeltasHandler()
		{
			if ((object)cb_getGlobalMetricsDeltas == null)
			{
				cb_getGlobalMetricsDeltas = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGlobalMetricsDeltas));
			}
			return cb_getGlobalMetricsDeltas;
		}

		private static IntPtr n_GetGlobalMetricsDeltas(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<CronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetGlobalMetricsDeltas());
		}

		[Register("getGlobalMetricsDeltas", "()[B", "GetGetGlobalMetricsDeltasHandler")]
		public abstract byte[] GetGlobalMetricsDeltas();

		private static Delegate GetNewUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_Handler()
		{
			if ((object)cb_newUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_ == null)
			{
				cb_newUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_NewUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_));
			}
			return cb_newUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_;
		}

		private static IntPtr n_NewUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			CronetEngine cronetEngine = Java.Lang.Object.GetObject<CronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			UrlRequest.Callback p2 = Java.Lang.Object.GetObject<UrlRequest.Callback>(native_p1, JniHandleOwnership.DoNotTransfer);
			IExecutor p3 = Java.Lang.Object.GetObject<IExecutor>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cronetEngine.NewUrlRequestBuilder(p, p2, p3));
		}

		[Register("newUrlRequestBuilder", "(Ljava/lang/String;Lorg/chromium/net/UrlRequest$Callback;Ljava/util/concurrent/Executor;)Lorg/chromium/net/UrlRequest$Builder;", "GetNewUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_Handler")]
		public abstract UrlRequest.Builder NewUrlRequestBuilder(string p0, UrlRequest.Callback p1, IExecutor p2);

		private static Delegate GetOpenConnection_Ljava_net_URL_Handler()
		{
			if ((object)cb_openConnection_Ljava_net_URL_ == null)
			{
				cb_openConnection_Ljava_net_URL_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OpenConnection_Ljava_net_URL_));
			}
			return cb_openConnection_Ljava_net_URL_;
		}

		private static IntPtr n_OpenConnection_Ljava_net_URL_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			CronetEngine cronetEngine = Java.Lang.Object.GetObject<CronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			URL p = Java.Lang.Object.GetObject<URL>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cronetEngine.OpenConnection(p));
		}

		[Register("openConnection", "(Ljava/net/URL;)Ljava/net/URLConnection;", "GetOpenConnection_Ljava_net_URL_Handler")]
		public abstract URLConnection OpenConnection(URL p0);

		private static Delegate GetShutdownHandler()
		{
			if ((object)cb_shutdown == null)
			{
				cb_shutdown = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Shutdown));
			}
			return cb_shutdown;
		}

		private static void n_Shutdown(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<CronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Shutdown();
		}

		[Register("shutdown", "()V", "GetShutdownHandler")]
		public abstract void Shutdown();

		private static Delegate GetStartNetLogToFile_Ljava_lang_String_ZHandler()
		{
			if ((object)cb_startNetLogToFile_Ljava_lang_String_Z == null)
			{
				cb_startNetLogToFile_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_StartNetLogToFile_Ljava_lang_String_Z));
			}
			return cb_startNetLogToFile_Ljava_lang_String_Z;
		}

		private static void n_StartNetLogToFile_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			CronetEngine cronetEngine = Java.Lang.Object.GetObject<CronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			cronetEngine.StartNetLogToFile(p2, p1);
		}

		[Register("startNetLogToFile", "(Ljava/lang/String;Z)V", "GetStartNetLogToFile_Ljava_lang_String_ZHandler")]
		public abstract void StartNetLogToFile(string p0, bool p1);

		private static Delegate GetStopNetLogHandler()
		{
			if ((object)cb_stopNetLog == null)
			{
				cb_stopNetLog = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StopNetLog));
			}
			return cb_stopNetLog;
		}

		private static void n_StopNetLog(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<CronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopNetLog();
		}

		[Register("stopNetLog", "()V", "GetStopNetLogHandler")]
		public abstract void StopNetLog();
	}
	[Register("org/chromium/net/CronetEngine", DoNotGenerateAcw = true)]
	internal class CronetEngineInvoker : CronetEngine
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CronetEngine", typeof(CronetEngineInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string VersionString
		{
			[Register("getVersionString", "()Ljava/lang/String;", "GetGetVersionStringHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getVersionString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public CronetEngineInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("createURLStreamHandlerFactory", "()Ljava/net/URLStreamHandlerFactory;", "GetCreateURLStreamHandlerFactoryHandler")]
		public unsafe override IURLStreamHandlerFactory CreateURLStreamHandlerFactory()
		{
			return Java.Lang.Object.GetObject<IURLStreamHandlerFactory>(_members.InstanceMethods.InvokeAbstractObjectMethod("createURLStreamHandlerFactory.()Ljava/net/URLStreamHandlerFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getGlobalMetricsDeltas", "()[B", "GetGetGlobalMetricsDeltasHandler")]
		public unsafe override byte[] GetGlobalMetricsDeltas()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getGlobalMetricsDeltas.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("newUrlRequestBuilder", "(Ljava/lang/String;Lorg/chromium/net/UrlRequest$Callback;Ljava/util/concurrent/Executor;)Lorg/chromium/net/UrlRequest$Builder;", "GetNewUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_Handler")]
		public unsafe override UrlRequest.Builder NewUrlRequestBuilder(string p0, UrlRequest.Callback p1, IExecutor p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
				return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("newUrlRequestBuilder.(Ljava/lang/String;Lorg/chromium/net/UrlRequest$Callback;Ljava/util/concurrent/Executor;)Lorg/chromium/net/UrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		[Register("openConnection", "(Ljava/net/URL;)Ljava/net/URLConnection;", "GetOpenConnection_Ljava_net_URL_Handler")]
		public unsafe override URLConnection OpenConnection(URL p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<URLConnection>(_members.InstanceMethods.InvokeAbstractObjectMethod("openConnection.(Ljava/net/URL;)Ljava/net/URLConnection;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("shutdown", "()V", "GetShutdownHandler")]
		public unsafe override void Shutdown()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("shutdown.()V", this, null);
		}

		[Register("startNetLogToFile", "(Ljava/lang/String;Z)V", "GetStartNetLogToFile_Ljava_lang_String_ZHandler")]
		public unsafe override void StartNetLogToFile(string p0, bool p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				_members.InstanceMethods.InvokeAbstractVoidMethod("startNetLogToFile.(Ljava/lang/String;Z)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("stopNetLog", "()V", "GetStopNetLogHandler")]
		public unsafe override void StopNetLog()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("stopNetLog.()V", this, null);
		}
	}
	[Register("org/chromium/net/CronetException", DoNotGenerateAcw = true)]
	public abstract class CronetException : IOException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CronetException", typeof(CronetException));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected CronetException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		protected unsafe CronetException(string message, Throwable cause)
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
	}
	[Register("org/chromium/net/CronetException", DoNotGenerateAcw = true)]
	internal class CronetExceptionInvoker : CronetException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CronetException", typeof(CronetExceptionInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public CronetExceptionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("org/chromium/net/CronetProvider", DoNotGenerateAcw = true)]
	public abstract class CronetProvider : Java.Lang.Object
	{
		[Register("PROVIDER_NAME_APP_PACKAGED")]
		public const string ProviderNameAppPackaged = "App-Packaged-Cronet-Provider";

		[Register("PROVIDER_NAME_FALLBACK")]
		public const string ProviderNameFallback = "Fallback-Cronet-Provider";

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CronetProvider", typeof(CronetProvider));

		private static Delegate cb_isEnabled;

		private static Delegate cb_getName;

		private static Delegate cb_getVersion;

		private static Delegate cb_createBuilder;

		[Register("mContext")]
		protected Context MContext
		{
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceFields.GetObjectValue("mContext.Landroid/content/Context;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mContext.Landroid/content/Context;", this, new JniObjectReference(jobject));
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

		public abstract bool IsEnabled
		{
			[Register("isEnabled", "()Z", "GetIsEnabledHandler")]
			get;
		}

		public abstract string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
			get;
		}

		public abstract string Version
		{
			[Register("getVersion", "()Ljava/lang/String;", "GetGetVersionHandler")]
			get;
		}

		protected CronetProvider(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		protected unsafe CronetProvider(Context context)
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

		private static Delegate GetIsEnabledHandler()
		{
			if ((object)cb_isEnabled == null)
			{
				cb_isEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsEnabled));
			}
			return cb_isEnabled;
		}

		private static bool n_IsEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<CronetProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEnabled;
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CronetProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CronetProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Version);
		}

		private static Delegate GetCreateBuilderHandler()
		{
			if ((object)cb_createBuilder == null)
			{
				cb_createBuilder = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateBuilder));
			}
			return cb_createBuilder;
		}

		private static IntPtr n_CreateBuilder(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CronetProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateBuilder());
		}

		[Register("createBuilder", "()Lorg/chromium/net/CronetEngine$Builder;", "GetCreateBuilderHandler")]
		public abstract CronetEngine.Builder CreateBuilder();

		[Register("getAllProviders", "(Landroid/content/Context;)Ljava/util/List;", "")]
		public unsafe static IList<CronetProvider> GetAllProviders(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return JavaList<CronetProvider>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("getAllProviders.(Landroid/content/Context;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}
	}
	[Register("org/chromium/net/CronetProvider", DoNotGenerateAcw = true)]
	internal class CronetProviderInvoker : CronetProvider
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/CronetProvider", typeof(CronetProviderInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsEnabled
		{
			[Register("isEnabled", "()Z", "GetIsEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isEnabled.()Z", this, null);
			}
		}

		public unsafe override string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string Version
		{
			[Register("getVersion", "()Ljava/lang/String;", "GetGetVersionHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getVersion.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public CronetProviderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("createBuilder", "()Lorg/chromium/net/CronetEngine$Builder;", "GetCreateBuilderHandler")]
		public unsafe override CronetEngine.Builder CreateBuilder()
		{
			return Java.Lang.Object.GetObject<CronetEngine.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("createBuilder.()Lorg/chromium/net/CronetEngine$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/chromium/net/ExperimentalBidirectionalStream", DoNotGenerateAcw = true)]
	public abstract class ExperimentalBidirectionalStream : BidirectionalStream
	{
		[Register("org/chromium/net/ExperimentalBidirectionalStream$Builder", DoNotGenerateAcw = true)]
		public new abstract class Builder : BidirectionalStream.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalBidirectionalStream$Builder", typeof(Builder));

			private static Delegate cb_addHeader_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_addRequestAnnotation_Ljava_lang_Object_;

			private static Delegate cb_build;

			private static Delegate cb_delayRequestHeadersUntilFirstFlush_Z;

			private static Delegate cb_setHttpMethod_Ljava_lang_String_;

			private static Delegate cb_setPriority_I;

			private static Delegate cb_setTrafficStatsTag_I;

			private static Delegate cb_setTrafficStatsUid_I;

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

			private static Delegate GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler()
			{
				if ((object)cb_addHeader_Ljava_lang_String_Ljava_lang_String_ == null)
				{
					cb_addHeader_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddHeader_Ljava_lang_String_Ljava_lang_String_));
				}
				return cb_addHeader_Ljava_lang_String_Ljava_lang_String_;
			}

			private static IntPtr n_AddHeader_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddHeader(p, p2));
			}

			[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", "GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe override BidirectionalStream.Builder AddHeader(string p0, string p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewString(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<BidirectionalStream.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addHeader.(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			private static Delegate GetAddRequestAnnotation_Ljava_lang_Object_Handler()
			{
				if ((object)cb_addRequestAnnotation_Ljava_lang_Object_ == null)
				{
					cb_addRequestAnnotation_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddRequestAnnotation_Ljava_lang_Object_));
				}
				return cb_addRequestAnnotation_Ljava_lang_Object_;
			}

			private static IntPtr n_AddRequestAnnotation_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_annotation)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object annotation = Java.Lang.Object.GetObject<Java.Lang.Object>(native_annotation, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddRequestAnnotation(annotation));
			}

			[Register("addRequestAnnotation", "(Ljava/lang/Object;)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", "GetAddRequestAnnotation_Ljava_lang_Object_Handler")]
			public unsafe virtual Builder AddRequestAnnotation(Java.Lang.Object annotation)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(annotation?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addRequestAnnotation.(Ljava/lang/Object;)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(annotation);
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

			[Register("build", "()Lorg/chromium/net/ExperimentalBidirectionalStream;", "GetBuildHandler")]
			public unsafe override BidirectionalStream Build()
			{
				return Java.Lang.Object.GetObject<BidirectionalStream>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lorg/chromium/net/ExperimentalBidirectionalStream;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetDelayRequestHeadersUntilFirstFlush_ZHandler()
			{
				if ((object)cb_delayRequestHeadersUntilFirstFlush_Z == null)
				{
					cb_delayRequestHeadersUntilFirstFlush_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_DelayRequestHeadersUntilFirstFlush_Z));
				}
				return cb_delayRequestHeadersUntilFirstFlush_Z;
			}

			private static IntPtr n_DelayRequestHeadersUntilFirstFlush_Z(IntPtr jnienv, IntPtr native__this, bool p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DelayRequestHeadersUntilFirstFlush(p0));
			}

			[Register("delayRequestHeadersUntilFirstFlush", "(Z)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", "GetDelayRequestHeadersUntilFirstFlush_ZHandler")]
			public unsafe override BidirectionalStream.Builder DelayRequestHeadersUntilFirstFlush(bool p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<BidirectionalStream.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("delayRequestHeadersUntilFirstFlush.(Z)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetHttpMethod_Ljava_lang_String_Handler()
			{
				if ((object)cb_setHttpMethod_Ljava_lang_String_ == null)
				{
					cb_setHttpMethod_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetHttpMethod_Ljava_lang_String_));
				}
				return cb_setHttpMethod_Ljava_lang_String_;
			}

			private static IntPtr n_SetHttpMethod_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string httpMethod = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetHttpMethod(httpMethod));
			}

			[Register("setHttpMethod", "(Ljava/lang/String;)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", "GetSetHttpMethod_Ljava_lang_String_Handler")]
			public unsafe override BidirectionalStream.Builder SetHttpMethod(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<BidirectionalStream.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHttpMethod.(Ljava/lang/String;)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetPriority_IHandler()
			{
				if ((object)cb_setPriority_I == null)
				{
					cb_setPriority_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetPriority_I));
				}
				return cb_setPriority_I;
			}

			private static IntPtr n_SetPriority_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPriority(p0));
			}

			[Register("setPriority", "(I)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", "GetSetPriority_IHandler")]
			public unsafe override BidirectionalStream.Builder SetPriority(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<BidirectionalStream.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPriority.(I)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetTrafficStatsTag_IHandler()
			{
				if ((object)cb_setTrafficStatsTag_I == null)
				{
					cb_setTrafficStatsTag_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetTrafficStatsTag_I));
				}
				return cb_setTrafficStatsTag_I;
			}

			private static IntPtr n_SetTrafficStatsTag_I(IntPtr jnienv, IntPtr native__this, int tag)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTrafficStatsTag(tag));
			}

			[Register("setTrafficStatsTag", "(I)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", "GetSetTrafficStatsTag_IHandler")]
			public unsafe virtual Builder SetTrafficStatsTag(int tag)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(tag);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTrafficStatsTag.(I)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetTrafficStatsUid_IHandler()
			{
				if ((object)cb_setTrafficStatsUid_I == null)
				{
					cb_setTrafficStatsUid_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetTrafficStatsUid_I));
				}
				return cb_setTrafficStatsUid_I;
			}

			private static IntPtr n_SetTrafficStatsUid_I(IntPtr jnienv, IntPtr native__this, int uid)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTrafficStatsUid(uid));
			}

			[Register("setTrafficStatsUid", "(I)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", "GetSetTrafficStatsUid_IHandler")]
			public unsafe virtual Builder SetTrafficStatsUid(int uid)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(uid);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTrafficStatsUid.(I)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("org/chromium/net/ExperimentalBidirectionalStream$Builder", DoNotGenerateAcw = true)]
		internal new class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalBidirectionalStream$Builder", typeof(BuilderInvoker));

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

			[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/BidirectionalStream$Builder;", "GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe override BidirectionalStream.Builder AddHeader(string p0, string p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewString(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<BidirectionalStream.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addHeader.(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/BidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("build", "()Lorg/chromium/net/BidirectionalStream;", "GetBuildHandler")]
			public unsafe override BidirectionalStream Build()
			{
				return Java.Lang.Object.GetObject<BidirectionalStream>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lorg/chromium/net/BidirectionalStream;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("delayRequestHeadersUntilFirstFlush", "(Z)Lorg/chromium/net/BidirectionalStream$Builder;", "GetDelayRequestHeadersUntilFirstFlush_ZHandler")]
			public unsafe override BidirectionalStream.Builder DelayRequestHeadersUntilFirstFlush(bool p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<BidirectionalStream.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("delayRequestHeadersUntilFirstFlush.(Z)Lorg/chromium/net/BidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setHttpMethod", "(Ljava/lang/String;)Lorg/chromium/net/BidirectionalStream$Builder;", "GetSetHttpMethod_Ljava_lang_String_Handler")]
			public unsafe override BidirectionalStream.Builder SetHttpMethod(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<BidirectionalStream.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setHttpMethod.(Ljava/lang/String;)Lorg/chromium/net/BidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setPriority", "(I)Lorg/chromium/net/BidirectionalStream$Builder;", "GetSetPriority_IHandler")]
			public unsafe override BidirectionalStream.Builder SetPriority(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<BidirectionalStream.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPriority.(I)Lorg/chromium/net/BidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalBidirectionalStream", typeof(ExperimentalBidirectionalStream));

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

		protected ExperimentalBidirectionalStream(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ExperimentalBidirectionalStream()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("org/chromium/net/ExperimentalBidirectionalStream", DoNotGenerateAcw = true)]
	internal class ExperimentalBidirectionalStreamInvoker : ExperimentalBidirectionalStream
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalBidirectionalStream", typeof(ExperimentalBidirectionalStreamInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsDone
		{
			[Register("isDone", "()Z", "GetIsDoneHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isDone.()Z", this, null);
			}
		}

		public ExperimentalBidirectionalStreamInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		public unsafe override void Cancel()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("cancel.()V", this, null);
		}

		[Register("flush", "()V", "GetFlushHandler")]
		public unsafe override void Flush()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("flush.()V", this, null);
		}

		[Register("read", "(Ljava/nio/ByteBuffer;)V", "GetRead_Ljava_nio_ByteBuffer_Handler")]
		public unsafe override void Read(ByteBuffer p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("read.(Ljava/nio/ByteBuffer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("start", "()V", "GetStartHandler")]
		public unsafe override void Start()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("start.()V", this, null);
		}

		[Register("write", "(Ljava/nio/ByteBuffer;Z)V", "GetWrite_Ljava_nio_ByteBuffer_ZHandler")]
		public unsafe override void Write(ByteBuffer p0, bool p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				_members.InstanceMethods.InvokeAbstractVoidMethod("write.(Ljava/nio/ByteBuffer;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("org/chromium/net/ExperimentalCronetEngine", DoNotGenerateAcw = true)]
	public abstract class ExperimentalCronetEngine : CronetEngine
	{
		[Register("org/chromium/net/ExperimentalCronetEngine$Builder", DoNotGenerateAcw = true)]
		public new class Builder : CronetEngine.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalCronetEngine$Builder", typeof(Builder));

			private static Delegate cb_getBuilderDelegate;

			private static Delegate cb_enableNetworkQualityEstimator_Z;

			private static Delegate cb_setExperimentalOptions_Ljava_lang_String_;

			private static Delegate cb_setThreadPriority_I;

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

			public unsafe virtual ICronetEngineBuilder BuilderDelegate
			{
				[Register("getBuilderDelegate", "()Lorg/chromium/net/ICronetEngineBuilder;", "GetGetBuilderDelegateHandler")]
				get
				{
					return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBuilderDelegate.()Lorg/chromium/net/ICronetEngineBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/content/Context;)V", "")]
			public unsafe Builder(Context context)
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

			[Register(".ctor", "(Lorg/chromium/net/ICronetEngineBuilder;)V", "")]
			public unsafe Builder(ICronetEngineBuilder builderDelegate)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(builderDelegate?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lorg/chromium/net/ICronetEngineBuilder;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lorg/chromium/net/ICronetEngineBuilder;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(builderDelegate);
				}
			}

			private static Delegate GetGetBuilderDelegateHandler()
			{
				if ((object)cb_getBuilderDelegate == null)
				{
					cb_getBuilderDelegate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBuilderDelegate));
				}
				return cb_getBuilderDelegate;
			}

			private static IntPtr n_GetBuilderDelegate(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BuilderDelegate);
			}

			private static Delegate GetEnableNetworkQualityEstimator_ZHandler()
			{
				if ((object)cb_enableNetworkQualityEstimator_Z == null)
				{
					cb_enableNetworkQualityEstimator_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableNetworkQualityEstimator_Z));
				}
				return cb_enableNetworkQualityEstimator_Z;
			}

			private static IntPtr n_EnableNetworkQualityEstimator_Z(IntPtr jnienv, IntPtr native__this, bool value)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableNetworkQualityEstimator(value));
			}

			[Register("enableNetworkQualityEstimator", "(Z)Lorg/chromium/net/ExperimentalCronetEngine$Builder;", "GetEnableNetworkQualityEstimator_ZHandler")]
			public unsafe virtual Builder EnableNetworkQualityEstimator(bool value)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("enableNetworkQualityEstimator.(Z)Lorg/chromium/net/ExperimentalCronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetExperimentalOptions_Ljava_lang_String_Handler()
			{
				if ((object)cb_setExperimentalOptions_Ljava_lang_String_ == null)
				{
					cb_setExperimentalOptions_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetExperimentalOptions_Ljava_lang_String_));
				}
				return cb_setExperimentalOptions_Ljava_lang_String_;
			}

			private static IntPtr n_SetExperimentalOptions_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_options)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string experimentalOptions = JNIEnv.GetString(native_options, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetExperimentalOptions(experimentalOptions));
			}

			[Register("setExperimentalOptions", "(Ljava/lang/String;)Lorg/chromium/net/ExperimentalCronetEngine$Builder;", "GetSetExperimentalOptions_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetExperimentalOptions(string options)
			{
				IntPtr intPtr = JNIEnv.NewString(options);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setExperimentalOptions.(Ljava/lang/String;)Lorg/chromium/net/ExperimentalCronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetThreadPriority_IHandler()
			{
				if ((object)cb_setThreadPriority_I == null)
				{
					cb_setThreadPriority_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetThreadPriority_I));
				}
				return cb_setThreadPriority_I;
			}

			private static IntPtr n_SetThreadPriority_I(IntPtr jnienv, IntPtr native__this, int priority)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetThreadPriority(priority));
			}

			[Register("setThreadPriority", "(I)Lorg/chromium/net/ExperimentalCronetEngine$Builder;", "GetSetThreadPriority_IHandler")]
			public unsafe virtual Builder SetThreadPriority(int priority)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(priority);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setThreadPriority.(I)Lorg/chromium/net/ExperimentalCronetEngine$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("CONNECTION_METRIC_UNKNOWN")]
		public const int ConnectionMetricUnknown = -1;

		[Register("EFFECTIVE_CONNECTION_TYPE_2G")]
		public const int EffectiveConnectionType2g = 3;

		[Register("EFFECTIVE_CONNECTION_TYPE_3G")]
		public const int EffectiveConnectionType3g = 4;

		[Register("EFFECTIVE_CONNECTION_TYPE_4G")]
		public const int EffectiveConnectionType4g = 5;

		[Register("EFFECTIVE_CONNECTION_TYPE_OFFLINE")]
		public const int EffectiveConnectionTypeOffline = 1;

		[Register("EFFECTIVE_CONNECTION_TYPE_SLOW_2G")]
		public const int EffectiveConnectionTypeSlow2g = 2;

		[Register("EFFECTIVE_CONNECTION_TYPE_UNKNOWN")]
		public const int EffectiveConnectionTypeUnknown = 0;

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalCronetEngine", typeof(ExperimentalCronetEngine));

		private static Delegate cb_getDownstreamThroughputKbps;

		private static Delegate cb_getEffectiveConnectionType;

		private static Delegate cb_getHttpRttMs;

		private static Delegate cb_getTransportRttMs;

		private static Delegate cb_addRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_;

		private static Delegate cb_addRttListener_Lorg_chromium_net_NetworkQualityRttListener_;

		private static Delegate cb_addThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_;

		private static Delegate cb_configureNetworkQualityEstimatorForTesting_ZZZ;

		private static Delegate cb_newBidirectionalStreamBuilder_Ljava_lang_String_Lorg_chromium_net_BidirectionalStream_Callback_Ljava_util_concurrent_Executor_;

		private static Delegate cb_newUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_;

		private static Delegate cb_openConnection_Ljava_net_URL_Ljava_net_Proxy_;

		private static Delegate cb_removeRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_;

		private static Delegate cb_removeRttListener_Lorg_chromium_net_NetworkQualityRttListener_;

		private static Delegate cb_removeThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_;

		private static Delegate cb_startNetLogToDisk_Ljava_lang_String_ZI;

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

		public unsafe virtual int DownstreamThroughputKbps
		{
			[Register("getDownstreamThroughputKbps", "()I", "GetGetDownstreamThroughputKbpsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDownstreamThroughputKbps.()I", this, null);
			}
		}

		public unsafe virtual int EffectiveConnectionType
		{
			[Register("getEffectiveConnectionType", "()I", "GetGetEffectiveConnectionTypeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getEffectiveConnectionType.()I", this, null);
			}
		}

		public unsafe virtual int HttpRttMs
		{
			[Register("getHttpRttMs", "()I", "GetGetHttpRttMsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getHttpRttMs.()I", this, null);
			}
		}

		public unsafe virtual int TransportRttMs
		{
			[Register("getTransportRttMs", "()I", "GetGetTransportRttMsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTransportRttMs.()I", this, null);
			}
		}

		protected ExperimentalCronetEngine(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ExperimentalCronetEngine()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetDownstreamThroughputKbpsHandler()
		{
			if ((object)cb_getDownstreamThroughputKbps == null)
			{
				cb_getDownstreamThroughputKbps = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetDownstreamThroughputKbps));
			}
			return cb_getDownstreamThroughputKbps;
		}

		private static int n_GetDownstreamThroughputKbps(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DownstreamThroughputKbps;
		}

		private static Delegate GetGetEffectiveConnectionTypeHandler()
		{
			if ((object)cb_getEffectiveConnectionType == null)
			{
				cb_getEffectiveConnectionType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetEffectiveConnectionType));
			}
			return cb_getEffectiveConnectionType;
		}

		private static int n_GetEffectiveConnectionType(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EffectiveConnectionType;
		}

		private static Delegate GetGetHttpRttMsHandler()
		{
			if ((object)cb_getHttpRttMs == null)
			{
				cb_getHttpRttMs = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHttpRttMs));
			}
			return cb_getHttpRttMs;
		}

		private static int n_GetHttpRttMs(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HttpRttMs;
		}

		private static Delegate GetGetTransportRttMsHandler()
		{
			if ((object)cb_getTransportRttMs == null)
			{
				cb_getTransportRttMs = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTransportRttMs));
			}
			return cb_getTransportRttMs;
		}

		private static int n_GetTransportRttMs(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransportRttMs;
		}

		private static Delegate GetAddRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_Handler()
		{
			if ((object)cb_addRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_ == null)
			{
				cb_addRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_));
			}
			return cb_addRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_;
		}

		private static void n_AddRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ExperimentalCronetEngine experimentalCronetEngine = Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RequestFinishedInfo.Listener listener = Java.Lang.Object.GetObject<RequestFinishedInfo.Listener>(native_listener, JniHandleOwnership.DoNotTransfer);
			experimentalCronetEngine.AddRequestFinishedListener(listener);
		}

		[Register("addRequestFinishedListener", "(Lorg/chromium/net/RequestFinishedInfo$Listener;)V", "GetAddRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_Handler")]
		public unsafe virtual void AddRequestFinishedListener(RequestFinishedInfo.Listener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addRequestFinishedListener.(Lorg/chromium/net/RequestFinishedInfo$Listener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetAddRttListener_Lorg_chromium_net_NetworkQualityRttListener_Handler()
		{
			if ((object)cb_addRttListener_Lorg_chromium_net_NetworkQualityRttListener_ == null)
			{
				cb_addRttListener_Lorg_chromium_net_NetworkQualityRttListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddRttListener_Lorg_chromium_net_NetworkQualityRttListener_));
			}
			return cb_addRttListener_Lorg_chromium_net_NetworkQualityRttListener_;
		}

		private static void n_AddRttListener_Lorg_chromium_net_NetworkQualityRttListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ExperimentalCronetEngine experimentalCronetEngine = Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			NetworkQualityRttListener listener = Java.Lang.Object.GetObject<NetworkQualityRttListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			experimentalCronetEngine.AddRttListener(listener);
		}

		[Register("addRttListener", "(Lorg/chromium/net/NetworkQualityRttListener;)V", "GetAddRttListener_Lorg_chromium_net_NetworkQualityRttListener_Handler")]
		public unsafe virtual void AddRttListener(NetworkQualityRttListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addRttListener.(Lorg/chromium/net/NetworkQualityRttListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetAddThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_Handler()
		{
			if ((object)cb_addThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_ == null)
			{
				cb_addThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_));
			}
			return cb_addThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_;
		}

		private static void n_AddThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ExperimentalCronetEngine experimentalCronetEngine = Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			NetworkQualityThroughputListener listener = Java.Lang.Object.GetObject<NetworkQualityThroughputListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			experimentalCronetEngine.AddThroughputListener(listener);
		}

		[Register("addThroughputListener", "(Lorg/chromium/net/NetworkQualityThroughputListener;)V", "GetAddThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_Handler")]
		public unsafe virtual void AddThroughputListener(NetworkQualityThroughputListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addThroughputListener.(Lorg/chromium/net/NetworkQualityThroughputListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetConfigureNetworkQualityEstimatorForTesting_ZZZHandler()
		{
			if ((object)cb_configureNetworkQualityEstimatorForTesting_ZZZ == null)
			{
				cb_configureNetworkQualityEstimatorForTesting_ZZZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZZZ_V(n_ConfigureNetworkQualityEstimatorForTesting_ZZZ));
			}
			return cb_configureNetworkQualityEstimatorForTesting_ZZZ;
		}

		private static void n_ConfigureNetworkQualityEstimatorForTesting_ZZZ(IntPtr jnienv, IntPtr native__this, bool useLocalHostRequests, bool useSmallerResponses, bool disableOfflineCheck)
		{
			Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConfigureNetworkQualityEstimatorForTesting(useLocalHostRequests, useSmallerResponses, disableOfflineCheck);
		}

		[Register("configureNetworkQualityEstimatorForTesting", "(ZZZ)V", "GetConfigureNetworkQualityEstimatorForTesting_ZZZHandler")]
		public unsafe virtual void ConfigureNetworkQualityEstimatorForTesting(bool useLocalHostRequests, bool useSmallerResponses, bool disableOfflineCheck)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(useLocalHostRequests);
			ptr[1] = new JniArgumentValue(useSmallerResponses);
			ptr[2] = new JniArgumentValue(disableOfflineCheck);
			_members.InstanceMethods.InvokeVirtualVoidMethod("configureNetworkQualityEstimatorForTesting.(ZZZ)V", this, ptr);
		}

		private static Delegate GetNewBidirectionalStreamBuilder_Ljava_lang_String_Lorg_chromium_net_BidirectionalStream_Callback_Ljava_util_concurrent_Executor_Handler()
		{
			if ((object)cb_newBidirectionalStreamBuilder_Ljava_lang_String_Lorg_chromium_net_BidirectionalStream_Callback_Ljava_util_concurrent_Executor_ == null)
			{
				cb_newBidirectionalStreamBuilder_Ljava_lang_String_Lorg_chromium_net_BidirectionalStream_Callback_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_NewBidirectionalStreamBuilder_Ljava_lang_String_Lorg_chromium_net_BidirectionalStream_Callback_Ljava_util_concurrent_Executor_));
			}
			return cb_newBidirectionalStreamBuilder_Ljava_lang_String_Lorg_chromium_net_BidirectionalStream_Callback_Ljava_util_concurrent_Executor_;
		}

		private static IntPtr n_NewBidirectionalStreamBuilder_Ljava_lang_String_Lorg_chromium_net_BidirectionalStream_Callback_Ljava_util_concurrent_Executor_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			ExperimentalCronetEngine experimentalCronetEngine = Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			BidirectionalStream.Callback p2 = Java.Lang.Object.GetObject<BidirectionalStream.Callback>(native_p1, JniHandleOwnership.DoNotTransfer);
			IExecutor p3 = Java.Lang.Object.GetObject<IExecutor>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(experimentalCronetEngine.NewBidirectionalStreamBuilder(p, p2, p3));
		}

		[Register("newBidirectionalStreamBuilder", "(Ljava/lang/String;Lorg/chromium/net/BidirectionalStream$Callback;Ljava/util/concurrent/Executor;)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", "GetNewBidirectionalStreamBuilder_Ljava_lang_String_Lorg_chromium_net_BidirectionalStream_Callback_Ljava_util_concurrent_Executor_Handler")]
		public abstract ExperimentalBidirectionalStream.Builder NewBidirectionalStreamBuilder(string p0, BidirectionalStream.Callback p1, IExecutor p2);

		private static Delegate GetNewUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_Handler()
		{
			if ((object)cb_newUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_ == null)
			{
				cb_newUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_NewUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_));
			}
			return cb_newUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_;
		}

		private static IntPtr n_NewUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			ExperimentalCronetEngine experimentalCronetEngine = Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			UrlRequest.Callback p2 = Java.Lang.Object.GetObject<UrlRequest.Callback>(native_p1, JniHandleOwnership.DoNotTransfer);
			IExecutor p3 = Java.Lang.Object.GetObject<IExecutor>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(experimentalCronetEngine.NewUrlRequestBuilder(p, p2, p3));
		}

		[Register("newUrlRequestBuilder", "(Ljava/lang/String;Lorg/chromium/net/UrlRequest$Callback;Ljava/util/concurrent/Executor;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetNewUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_Handler")]
		public unsafe override UrlRequest.Builder NewUrlRequestBuilder(string p0, UrlRequest.Callback p1, IExecutor p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
				return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("newUrlRequestBuilder.(Ljava/lang/String;Lorg/chromium/net/UrlRequest$Callback;Ljava/util/concurrent/Executor;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		private static Delegate GetOpenConnection_Ljava_net_URL_Ljava_net_Proxy_Handler()
		{
			if ((object)cb_openConnection_Ljava_net_URL_Ljava_net_Proxy_ == null)
			{
				cb_openConnection_Ljava_net_URL_Ljava_net_Proxy_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_OpenConnection_Ljava_net_URL_Ljava_net_Proxy_));
			}
			return cb_openConnection_Ljava_net_URL_Ljava_net_Proxy_;
		}

		private static IntPtr n_OpenConnection_Ljava_net_URL_Ljava_net_Proxy_(IntPtr jnienv, IntPtr native__this, IntPtr native_url, IntPtr native_proxy)
		{
			ExperimentalCronetEngine experimentalCronetEngine = Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			URL url = Java.Lang.Object.GetObject<URL>(native_url, JniHandleOwnership.DoNotTransfer);
			Proxy proxy = Java.Lang.Object.GetObject<Proxy>(native_proxy, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(experimentalCronetEngine.OpenConnection(url, proxy));
		}

		[Register("openConnection", "(Ljava/net/URL;Ljava/net/Proxy;)Ljava/net/URLConnection;", "GetOpenConnection_Ljava_net_URL_Ljava_net_Proxy_Handler")]
		public unsafe virtual URLConnection OpenConnection(URL url, Proxy proxy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(proxy?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<URLConnection>(_members.InstanceMethods.InvokeVirtualObjectMethod("openConnection.(Ljava/net/URL;Ljava/net/Proxy;)Ljava/net/URLConnection;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(url);
				GC.KeepAlive(proxy);
			}
		}

		private static Delegate GetRemoveRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_Handler()
		{
			if ((object)cb_removeRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_ == null)
			{
				cb_removeRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_));
			}
			return cb_removeRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_;
		}

		private static void n_RemoveRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ExperimentalCronetEngine experimentalCronetEngine = Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RequestFinishedInfo.Listener listener = Java.Lang.Object.GetObject<RequestFinishedInfo.Listener>(native_listener, JniHandleOwnership.DoNotTransfer);
			experimentalCronetEngine.RemoveRequestFinishedListener(listener);
		}

		[Register("removeRequestFinishedListener", "(Lorg/chromium/net/RequestFinishedInfo$Listener;)V", "GetRemoveRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_Handler")]
		public unsafe virtual void RemoveRequestFinishedListener(RequestFinishedInfo.Listener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeRequestFinishedListener.(Lorg/chromium/net/RequestFinishedInfo$Listener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetRemoveRttListener_Lorg_chromium_net_NetworkQualityRttListener_Handler()
		{
			if ((object)cb_removeRttListener_Lorg_chromium_net_NetworkQualityRttListener_ == null)
			{
				cb_removeRttListener_Lorg_chromium_net_NetworkQualityRttListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveRttListener_Lorg_chromium_net_NetworkQualityRttListener_));
			}
			return cb_removeRttListener_Lorg_chromium_net_NetworkQualityRttListener_;
		}

		private static void n_RemoveRttListener_Lorg_chromium_net_NetworkQualityRttListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ExperimentalCronetEngine experimentalCronetEngine = Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			NetworkQualityRttListener listener = Java.Lang.Object.GetObject<NetworkQualityRttListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			experimentalCronetEngine.RemoveRttListener(listener);
		}

		[Register("removeRttListener", "(Lorg/chromium/net/NetworkQualityRttListener;)V", "GetRemoveRttListener_Lorg_chromium_net_NetworkQualityRttListener_Handler")]
		public unsafe virtual void RemoveRttListener(NetworkQualityRttListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeRttListener.(Lorg/chromium/net/NetworkQualityRttListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetRemoveThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_Handler()
		{
			if ((object)cb_removeThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_ == null)
			{
				cb_removeThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_));
			}
			return cb_removeThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_;
		}

		private static void n_RemoveThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ExperimentalCronetEngine experimentalCronetEngine = Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			NetworkQualityThroughputListener listener = Java.Lang.Object.GetObject<NetworkQualityThroughputListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			experimentalCronetEngine.RemoveThroughputListener(listener);
		}

		[Register("removeThroughputListener", "(Lorg/chromium/net/NetworkQualityThroughputListener;)V", "GetRemoveThroughputListener_Lorg_chromium_net_NetworkQualityThroughputListener_Handler")]
		public unsafe virtual void RemoveThroughputListener(NetworkQualityThroughputListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeThroughputListener.(Lorg/chromium/net/NetworkQualityThroughputListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetStartNetLogToDisk_Ljava_lang_String_ZIHandler()
		{
			if ((object)cb_startNetLogToDisk_Ljava_lang_String_ZI == null)
			{
				cb_startNetLogToDisk_Ljava_lang_String_ZI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZI_V(n_StartNetLogToDisk_Ljava_lang_String_ZI));
			}
			return cb_startNetLogToDisk_Ljava_lang_String_ZI;
		}

		private static void n_StartNetLogToDisk_Ljava_lang_String_ZI(IntPtr jnienv, IntPtr native__this, IntPtr native_dirPath, bool logAll, int maxSize)
		{
			ExperimentalCronetEngine experimentalCronetEngine = Java.Lang.Object.GetObject<ExperimentalCronetEngine>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string dirPath = JNIEnv.GetString(native_dirPath, JniHandleOwnership.DoNotTransfer);
			experimentalCronetEngine.StartNetLogToDisk(dirPath, logAll, maxSize);
		}

		[Register("startNetLogToDisk", "(Ljava/lang/String;ZI)V", "GetStartNetLogToDisk_Ljava_lang_String_ZIHandler")]
		public unsafe virtual void StartNetLogToDisk(string dirPath, bool logAll, int maxSize)
		{
			IntPtr intPtr = JNIEnv.NewString(dirPath);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(logAll);
				ptr[2] = new JniArgumentValue(maxSize);
				_members.InstanceMethods.InvokeVirtualVoidMethod("startNetLogToDisk.(Ljava/lang/String;ZI)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("org/chromium/net/ExperimentalCronetEngine", DoNotGenerateAcw = true)]
	internal class ExperimentalCronetEngineInvoker : ExperimentalCronetEngine
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalCronetEngine", typeof(ExperimentalCronetEngineInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string VersionString
		{
			[Register("getVersionString", "()Ljava/lang/String;", "GetGetVersionStringHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getVersionString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public ExperimentalCronetEngineInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("newBidirectionalStreamBuilder", "(Ljava/lang/String;Lorg/chromium/net/BidirectionalStream$Callback;Ljava/util/concurrent/Executor;)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", "GetNewBidirectionalStreamBuilder_Ljava_lang_String_Lorg_chromium_net_BidirectionalStream_Callback_Ljava_util_concurrent_Executor_Handler")]
		public unsafe override ExperimentalBidirectionalStream.Builder NewBidirectionalStreamBuilder(string p0, BidirectionalStream.Callback p1, IExecutor p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
				return Java.Lang.Object.GetObject<ExperimentalBidirectionalStream.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("newBidirectionalStreamBuilder.(Ljava/lang/String;Lorg/chromium/net/BidirectionalStream$Callback;Ljava/util/concurrent/Executor;)Lorg/chromium/net/ExperimentalBidirectionalStream$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		[Register("createURLStreamHandlerFactory", "()Ljava/net/URLStreamHandlerFactory;", "GetCreateURLStreamHandlerFactoryHandler")]
		public unsafe override IURLStreamHandlerFactory CreateURLStreamHandlerFactory()
		{
			return Java.Lang.Object.GetObject<IURLStreamHandlerFactory>(_members.InstanceMethods.InvokeAbstractObjectMethod("createURLStreamHandlerFactory.()Ljava/net/URLStreamHandlerFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getGlobalMetricsDeltas", "()[B", "GetGetGlobalMetricsDeltasHandler")]
		public unsafe override byte[] GetGlobalMetricsDeltas()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getGlobalMetricsDeltas.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("newUrlRequestBuilder", "(Ljava/lang/String;Lorg/chromium/net/UrlRequest$Callback;Ljava/util/concurrent/Executor;)Lorg/chromium/net/UrlRequest$Builder;", "GetNewUrlRequestBuilder_Ljava_lang_String_Lorg_chromium_net_UrlRequest_Callback_Ljava_util_concurrent_Executor_Handler")]
		public unsafe override UrlRequest.Builder NewUrlRequestBuilder(string p0, UrlRequest.Callback p1, IExecutor p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
				return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("newUrlRequestBuilder.(Ljava/lang/String;Lorg/chromium/net/UrlRequest$Callback;Ljava/util/concurrent/Executor;)Lorg/chromium/net/UrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		[Register("openConnection", "(Ljava/net/URL;)Ljava/net/URLConnection;", "GetOpenConnection_Ljava_net_URL_Handler")]
		public unsafe override URLConnection OpenConnection(URL p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<URLConnection>(_members.InstanceMethods.InvokeAbstractObjectMethod("openConnection.(Ljava/net/URL;)Ljava/net/URLConnection;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("shutdown", "()V", "GetShutdownHandler")]
		public unsafe override void Shutdown()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("shutdown.()V", this, null);
		}

		[Register("startNetLogToFile", "(Ljava/lang/String;Z)V", "GetStartNetLogToFile_Ljava_lang_String_ZHandler")]
		public unsafe override void StartNetLogToFile(string p0, bool p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				_members.InstanceMethods.InvokeAbstractVoidMethod("startNetLogToFile.(Ljava/lang/String;Z)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("stopNetLog", "()V", "GetStopNetLogHandler")]
		public unsafe override void StopNetLog()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("stopNetLog.()V", this, null);
		}
	}
	[Register("org/chromium/net/ExperimentalUrlRequest", DoNotGenerateAcw = true)]
	public abstract class ExperimentalUrlRequest : UrlRequest
	{
		[Register("org/chromium/net/ExperimentalUrlRequest$Builder", DoNotGenerateAcw = true)]
		public new abstract class Builder : UrlRequest.Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalUrlRequest$Builder", typeof(Builder));

			private static Delegate cb_addHeader_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_addRequestAnnotation_Ljava_lang_Object_;

			private static Delegate cb_allowDirectExecutor;

			private static Delegate cb_build;

			private static Delegate cb_disableCache;

			private static Delegate cb_disableConnectionMigration;

			private static Delegate cb_setHttpMethod_Ljava_lang_String_;

			private static Delegate cb_setPriority_I;

			private static Delegate cb_setRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_;

			private static Delegate cb_setTrafficStatsTag_I;

			private static Delegate cb_setTrafficStatsUid_I;

			private static Delegate cb_setUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_;

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

			private static Delegate GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler()
			{
				if ((object)cb_addHeader_Ljava_lang_String_Ljava_lang_String_ == null)
				{
					cb_addHeader_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddHeader_Ljava_lang_String_Ljava_lang_String_));
				}
				return cb_addHeader_Ljava_lang_String_Ljava_lang_String_;
			}

			private static IntPtr n_AddHeader_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddHeader(p, p2));
			}

			[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe override UrlRequest.Builder AddHeader(string p0, string p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewString(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addHeader.(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			private static Delegate GetAddRequestAnnotation_Ljava_lang_Object_Handler()
			{
				if ((object)cb_addRequestAnnotation_Ljava_lang_Object_ == null)
				{
					cb_addRequestAnnotation_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddRequestAnnotation_Ljava_lang_Object_));
				}
				return cb_addRequestAnnotation_Ljava_lang_Object_;
			}

			private static IntPtr n_AddRequestAnnotation_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_annotation)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object annotation = Java.Lang.Object.GetObject<Java.Lang.Object>(native_annotation, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddRequestAnnotation(annotation));
			}

			[Register("addRequestAnnotation", "(Ljava/lang/Object;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetAddRequestAnnotation_Ljava_lang_Object_Handler")]
			public unsafe virtual Builder AddRequestAnnotation(Java.Lang.Object annotation)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(annotation?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addRequestAnnotation.(Ljava/lang/Object;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(annotation);
				}
			}

			private static Delegate GetAllowDirectExecutorHandler()
			{
				if ((object)cb_allowDirectExecutor == null)
				{
					cb_allowDirectExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AllowDirectExecutor));
				}
				return cb_allowDirectExecutor;
			}

			private static IntPtr n_AllowDirectExecutor(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowDirectExecutor());
			}

			[Register("allowDirectExecutor", "()Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetAllowDirectExecutorHandler")]
			public unsafe override UrlRequest.Builder AllowDirectExecutor()
			{
				return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("allowDirectExecutor.()Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

			[Register("build", "()Lorg/chromium/net/ExperimentalUrlRequest;", "GetBuildHandler")]
			public unsafe override UrlRequest Build()
			{
				return Java.Lang.Object.GetObject<UrlRequest>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lorg/chromium/net/ExperimentalUrlRequest;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetDisableCacheHandler()
			{
				if ((object)cb_disableCache == null)
				{
					cb_disableCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_DisableCache));
				}
				return cb_disableCache;
			}

			private static IntPtr n_DisableCache(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisableCache());
			}

			[Register("disableCache", "()Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetDisableCacheHandler")]
			public unsafe override UrlRequest.Builder DisableCache()
			{
				return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("disableCache.()Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetDisableConnectionMigrationHandler()
			{
				if ((object)cb_disableConnectionMigration == null)
				{
					cb_disableConnectionMigration = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_DisableConnectionMigration));
				}
				return cb_disableConnectionMigration;
			}

			private static IntPtr n_DisableConnectionMigration(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisableConnectionMigration());
			}

			[Register("disableConnectionMigration", "()Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetDisableConnectionMigrationHandler")]
			public unsafe virtual Builder DisableConnectionMigration()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("disableConnectionMigration.()Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetHttpMethod_Ljava_lang_String_Handler()
			{
				if ((object)cb_setHttpMethod_Ljava_lang_String_ == null)
				{
					cb_setHttpMethod_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetHttpMethod_Ljava_lang_String_));
				}
				return cb_setHttpMethod_Ljava_lang_String_;
			}

			private static IntPtr n_SetHttpMethod_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string httpMethod = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetHttpMethod(httpMethod));
			}

			[Register("setHttpMethod", "(Ljava/lang/String;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetSetHttpMethod_Ljava_lang_String_Handler")]
			public unsafe override UrlRequest.Builder SetHttpMethod(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHttpMethod.(Ljava/lang/String;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetPriority_IHandler()
			{
				if ((object)cb_setPriority_I == null)
				{
					cb_setPriority_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetPriority_I));
				}
				return cb_setPriority_I;
			}

			private static IntPtr n_SetPriority_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPriority(p0));
			}

			[Register("setPriority", "(I)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetSetPriority_IHandler")]
			public unsafe override UrlRequest.Builder SetPriority(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPriority.(I)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_Handler()
			{
				if ((object)cb_setRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_ == null)
				{
					cb_setRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_));
				}
				return cb_setRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_;
			}

			private static IntPtr n_SetRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RequestFinishedInfo.Listener requestFinishedListener = Java.Lang.Object.GetObject<RequestFinishedInfo.Listener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetRequestFinishedListener(requestFinishedListener));
			}

			[Register("setRequestFinishedListener", "(Lorg/chromium/net/RequestFinishedInfo$Listener;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetSetRequestFinishedListener_Lorg_chromium_net_RequestFinishedInfo_Listener_Handler")]
			public unsafe virtual Builder SetRequestFinishedListener(RequestFinishedInfo.Listener listener)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setRequestFinishedListener.(Lorg/chromium/net/RequestFinishedInfo$Listener;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(listener);
				}
			}

			private static Delegate GetSetTrafficStatsTag_IHandler()
			{
				if ((object)cb_setTrafficStatsTag_I == null)
				{
					cb_setTrafficStatsTag_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetTrafficStatsTag_I));
				}
				return cb_setTrafficStatsTag_I;
			}

			private static IntPtr n_SetTrafficStatsTag_I(IntPtr jnienv, IntPtr native__this, int tag)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTrafficStatsTag(tag));
			}

			[Register("setTrafficStatsTag", "(I)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetSetTrafficStatsTag_IHandler")]
			public unsafe virtual Builder SetTrafficStatsTag(int tag)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(tag);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTrafficStatsTag.(I)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetTrafficStatsUid_IHandler()
			{
				if ((object)cb_setTrafficStatsUid_I == null)
				{
					cb_setTrafficStatsUid_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetTrafficStatsUid_I));
				}
				return cb_setTrafficStatsUid_I;
			}

			private static IntPtr n_SetTrafficStatsUid_I(IntPtr jnienv, IntPtr native__this, int uid)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTrafficStatsUid(uid));
			}

			[Register("setTrafficStatsUid", "(I)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetSetTrafficStatsUid_IHandler")]
			public unsafe virtual Builder SetTrafficStatsUid(int uid)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(uid);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTrafficStatsUid.(I)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_Handler()
			{
				if ((object)cb_setUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_ == null)
				{
					cb_setUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_SetUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_));
				}
				return cb_setUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_;
			}

			private static IntPtr n_SetUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				UploadDataProvider p = Java.Lang.Object.GetObject<UploadDataProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
				IExecutor p2 = Java.Lang.Object.GetObject<IExecutor>(native_p1, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetUploadDataProvider(p, p2));
			}

			[Register("setUploadDataProvider", "(Lorg/chromium/net/UploadDataProvider;Ljava/util/concurrent/Executor;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", "GetSetUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_Handler")]
			public unsafe override UrlRequest.Builder SetUploadDataProvider(UploadDataProvider p0, IExecutor p1)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
					return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setUploadDataProvider.(Lorg/chromium/net/UploadDataProvider;Ljava/util/concurrent/Executor;)Lorg/chromium/net/ExperimentalUrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}
		}

		[Register("org/chromium/net/ExperimentalUrlRequest$Builder", DoNotGenerateAcw = true)]
		internal new class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalUrlRequest$Builder", typeof(BuilderInvoker));

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

			[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/UrlRequest$Builder;", "GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe override UrlRequest.Builder AddHeader(string p0, string p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewString(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addHeader.(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/UrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("allowDirectExecutor", "()Lorg/chromium/net/UrlRequest$Builder;", "GetAllowDirectExecutorHandler")]
			public unsafe override UrlRequest.Builder AllowDirectExecutor()
			{
				return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("allowDirectExecutor.()Lorg/chromium/net/UrlRequest$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("build", "()Lorg/chromium/net/UrlRequest;", "GetBuildHandler")]
			public unsafe override UrlRequest Build()
			{
				return Java.Lang.Object.GetObject<UrlRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lorg/chromium/net/UrlRequest;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("disableCache", "()Lorg/chromium/net/UrlRequest$Builder;", "GetDisableCacheHandler")]
			public unsafe override UrlRequest.Builder DisableCache()
			{
				return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("disableCache.()Lorg/chromium/net/UrlRequest$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setHttpMethod", "(Ljava/lang/String;)Lorg/chromium/net/UrlRequest$Builder;", "GetSetHttpMethod_Ljava_lang_String_Handler")]
			public unsafe override UrlRequest.Builder SetHttpMethod(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setHttpMethod.(Ljava/lang/String;)Lorg/chromium/net/UrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setPriority", "(I)Lorg/chromium/net/UrlRequest$Builder;", "GetSetPriority_IHandler")]
			public unsafe override UrlRequest.Builder SetPriority(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPriority.(I)Lorg/chromium/net/UrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setUploadDataProvider", "(Lorg/chromium/net/UploadDataProvider;Ljava/util/concurrent/Executor;)Lorg/chromium/net/UrlRequest$Builder;", "GetSetUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_Handler")]
			public unsafe override UrlRequest.Builder SetUploadDataProvider(UploadDataProvider p0, IExecutor p1)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
					return Java.Lang.Object.GetObject<UrlRequest.Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setUploadDataProvider.(Lorg/chromium/net/UploadDataProvider;Ljava/util/concurrent/Executor;)Lorg/chromium/net/UrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalUrlRequest", typeof(ExperimentalUrlRequest));

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

		protected ExperimentalUrlRequest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ExperimentalUrlRequest()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("org/chromium/net/ExperimentalUrlRequest", DoNotGenerateAcw = true)]
	internal class ExperimentalUrlRequestInvoker : ExperimentalUrlRequest
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ExperimentalUrlRequest", typeof(ExperimentalUrlRequestInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsDone
		{
			[Register("isDone", "()Z", "GetIsDoneHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isDone.()Z", this, null);
			}
		}

		public ExperimentalUrlRequestInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		public unsafe override void Cancel()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("cancel.()V", this, null);
		}

		[Register("followRedirect", "()V", "GetFollowRedirectHandler")]
		public unsafe override void FollowRedirect()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("followRedirect.()V", this, null);
		}

		[Register("getStatus", "(Lorg/chromium/net/UrlRequest$StatusListener;)V", "GetGetStatus_Lorg_chromium_net_UrlRequest_StatusListener_Handler")]
		public unsafe override void GetStatus(StatusListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("getStatus.(Lorg/chromium/net/UrlRequest$StatusListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("read", "(Ljava/nio/ByteBuffer;)V", "GetRead_Ljava_nio_ByteBuffer_Handler")]
		public unsafe override void Read(ByteBuffer p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("read.(Ljava/nio/ByteBuffer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("start", "()V", "GetStartHandler")]
		public unsafe override void Start()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("start.()V", this, null);
		}
	}
	[Register("org/chromium/net/ICronetEngineBuilder", DoNotGenerateAcw = true)]
	public abstract class ICronetEngineBuilder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ICronetEngineBuilder", typeof(ICronetEngineBuilder));

		private static Delegate cb_getDefaultUserAgent;

		private static Delegate cb_addPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_;

		private static Delegate cb_addQuicHint_Ljava_lang_String_II;

		private static Delegate cb_build;

		private static Delegate cb_enableBrotli_Z;

		private static Delegate cb_enableHttp2_Z;

		private static Delegate cb_enableHttpCache_IJ;

		private static Delegate cb_enableNetworkQualityEstimator_Z;

		private static Delegate cb_enablePublicKeyPinningBypassForLocalTrustAnchors_Z;

		private static Delegate cb_enableQuic_Z;

		private static Delegate cb_enableSdch_Z;

		private static Delegate cb_setExperimentalOptions_Ljava_lang_String_;

		private static Delegate cb_setLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_;

		private static Delegate cb_setStoragePath_Ljava_lang_String_;

		private static Delegate cb_setThreadPriority_I;

		private static Delegate cb_setUserAgent_Ljava_lang_String_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract string DefaultUserAgent
		{
			[Register("getDefaultUserAgent", "()Ljava/lang/String;", "GetGetDefaultUserAgentHandler")]
			get;
		}

		protected ICronetEngineBuilder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ICronetEngineBuilder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetDefaultUserAgentHandler()
		{
			if ((object)cb_getDefaultUserAgent == null)
			{
				cb_getDefaultUserAgent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefaultUserAgent));
			}
			return cb_getDefaultUserAgent;
		}

		private static IntPtr n_GetDefaultUserAgent(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultUserAgent);
		}

		private static Delegate GetAddPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_Handler()
		{
			if ((object)cb_addPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_ == null)
			{
				cb_addPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZL_L(n_AddPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_));
			}
			return cb_addPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_;
		}

		private static IntPtr n_AddPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, bool p2, IntPtr native_p3)
		{
			ICronetEngineBuilder cronetEngineBuilder = Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			ICollection<byte[]> p4 = JavaSet<byte[]>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
			Date p5 = Java.Lang.Object.GetObject<Date>(native_p3, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cronetEngineBuilder.AddPublicKeyPins(p3, p4, p2, p5));
		}

		[Register("addPublicKeyPins", "(Ljava/lang/String;Ljava/util/Set;ZLjava/util/Date;)Lorg/chromium/net/ICronetEngineBuilder;", "GetAddPublicKeyPins_Ljava_lang_String_Ljava_util_Set_ZLjava_util_Date_Handler")]
		public unsafe virtual ICronetEngineBuilder AddPublicKeyPins(string p0, ICollection<byte[]> p1, bool p2, Date p3)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JavaSet<byte[]>.ToLocalJniHandle(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addPublicKeyPins.(Ljava/lang/String;Ljava/util/Set;ZLjava/util/Date;)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(p1);
				GC.KeepAlive(p3);
			}
		}

		private static Delegate GetAddQuicHint_Ljava_lang_String_IIHandler()
		{
			if ((object)cb_addQuicHint_Ljava_lang_String_II == null)
			{
				cb_addQuicHint_Ljava_lang_String_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_AddQuicHint_Ljava_lang_String_II));
			}
			return cb_addQuicHint_Ljava_lang_String_II;
		}

		private static IntPtr n_AddQuicHint_Ljava_lang_String_II(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2)
		{
			ICronetEngineBuilder cronetEngineBuilder = Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cronetEngineBuilder.AddQuicHint(p3, p1, p2));
		}

		[Register("addQuicHint", "(Ljava/lang/String;II)Lorg/chromium/net/ICronetEngineBuilder;", "GetAddQuicHint_Ljava_lang_String_IIHandler")]
		public abstract ICronetEngineBuilder AddQuicHint(string p0, int p1, int p2);

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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Lorg/chromium/net/ExperimentalCronetEngine;", "GetBuildHandler")]
		public abstract ExperimentalCronetEngine Build();

		private static Delegate GetEnableBrotli_ZHandler()
		{
			if ((object)cb_enableBrotli_Z == null)
			{
				cb_enableBrotli_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableBrotli_Z));
			}
			return cb_enableBrotli_Z;
		}

		private static IntPtr n_EnableBrotli_Z(IntPtr jnienv, IntPtr native__this, bool value)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableBrotli(value));
		}

		[Register("enableBrotli", "(Z)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnableBrotli_ZHandler")]
		public unsafe virtual ICronetEngineBuilder EnableBrotli(bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("enableBrotli.(Z)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetEnableHttp2_ZHandler()
		{
			if ((object)cb_enableHttp2_Z == null)
			{
				cb_enableHttp2_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableHttp2_Z));
			}
			return cb_enableHttp2_Z;
		}

		private static IntPtr n_EnableHttp2_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableHttp2(p0));
		}

		[Register("enableHttp2", "(Z)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnableHttp2_ZHandler")]
		public abstract ICronetEngineBuilder EnableHttp2(bool p0);

		private static Delegate GetEnableHttpCache_IJHandler()
		{
			if ((object)cb_enableHttpCache_IJ == null)
			{
				cb_enableHttpCache_IJ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIJ_L(n_EnableHttpCache_IJ));
			}
			return cb_enableHttpCache_IJ;
		}

		private static IntPtr n_EnableHttpCache_IJ(IntPtr jnienv, IntPtr native__this, int p0, long p1)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableHttpCache(p0, p1));
		}

		[Register("enableHttpCache", "(IJ)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnableHttpCache_IJHandler")]
		public abstract ICronetEngineBuilder EnableHttpCache(int p0, long p1);

		private static Delegate GetEnableNetworkQualityEstimator_ZHandler()
		{
			if ((object)cb_enableNetworkQualityEstimator_Z == null)
			{
				cb_enableNetworkQualityEstimator_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableNetworkQualityEstimator_Z));
			}
			return cb_enableNetworkQualityEstimator_Z;
		}

		private static IntPtr n_EnableNetworkQualityEstimator_Z(IntPtr jnienv, IntPtr native__this, bool value)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableNetworkQualityEstimator(value));
		}

		[Register("enableNetworkQualityEstimator", "(Z)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnableNetworkQualityEstimator_ZHandler")]
		public unsafe virtual ICronetEngineBuilder EnableNetworkQualityEstimator(bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("enableNetworkQualityEstimator.(Z)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetEnablePublicKeyPinningBypassForLocalTrustAnchors_ZHandler()
		{
			if ((object)cb_enablePublicKeyPinningBypassForLocalTrustAnchors_Z == null)
			{
				cb_enablePublicKeyPinningBypassForLocalTrustAnchors_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnablePublicKeyPinningBypassForLocalTrustAnchors_Z));
			}
			return cb_enablePublicKeyPinningBypassForLocalTrustAnchors_Z;
		}

		private static IntPtr n_EnablePublicKeyPinningBypassForLocalTrustAnchors_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnablePublicKeyPinningBypassForLocalTrustAnchors(p0));
		}

		[Register("enablePublicKeyPinningBypassForLocalTrustAnchors", "(Z)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnablePublicKeyPinningBypassForLocalTrustAnchors_ZHandler")]
		public abstract ICronetEngineBuilder EnablePublicKeyPinningBypassForLocalTrustAnchors(bool p0);

		private static Delegate GetEnableQuic_ZHandler()
		{
			if ((object)cb_enableQuic_Z == null)
			{
				cb_enableQuic_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableQuic_Z));
			}
			return cb_enableQuic_Z;
		}

		private static IntPtr n_EnableQuic_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableQuic(p0));
		}

		[Register("enableQuic", "(Z)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnableQuic_ZHandler")]
		public abstract ICronetEngineBuilder EnableQuic(bool p0);

		private static Delegate GetEnableSdch_ZHandler()
		{
			if ((object)cb_enableSdch_Z == null)
			{
				cb_enableSdch_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_EnableSdch_Z));
			}
			return cb_enableSdch_Z;
		}

		private static IntPtr n_EnableSdch_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableSdch(p0));
		}

		[Register("enableSdch", "(Z)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnableSdch_ZHandler")]
		public abstract ICronetEngineBuilder EnableSdch(bool p0);

		private static Delegate GetSetExperimentalOptions_Ljava_lang_String_Handler()
		{
			if ((object)cb_setExperimentalOptions_Ljava_lang_String_ == null)
			{
				cb_setExperimentalOptions_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetExperimentalOptions_Ljava_lang_String_));
			}
			return cb_setExperimentalOptions_Ljava_lang_String_;
		}

		private static IntPtr n_SetExperimentalOptions_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ICronetEngineBuilder cronetEngineBuilder = Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string experimentalOptions = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cronetEngineBuilder.SetExperimentalOptions(experimentalOptions));
		}

		[Register("setExperimentalOptions", "(Ljava/lang/String;)Lorg/chromium/net/ICronetEngineBuilder;", "GetSetExperimentalOptions_Ljava_lang_String_Handler")]
		public abstract ICronetEngineBuilder SetExperimentalOptions(string p0);

		private static Delegate GetSetLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_Handler()
		{
			if ((object)cb_setLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_ == null)
			{
				cb_setLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_));
			}
			return cb_setLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_;
		}

		private static IntPtr n_SetLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ICronetEngineBuilder cronetEngineBuilder = Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CronetEngine.Builder.LibraryLoader libraryLoader = Java.Lang.Object.GetObject<CronetEngine.Builder.LibraryLoader>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cronetEngineBuilder.SetLibraryLoader(libraryLoader));
		}

		[Register("setLibraryLoader", "(Lorg/chromium/net/CronetEngine$Builder$LibraryLoader;)Lorg/chromium/net/ICronetEngineBuilder;", "GetSetLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_Handler")]
		public abstract ICronetEngineBuilder SetLibraryLoader(CronetEngine.Builder.LibraryLoader p0);

		private static Delegate GetSetStoragePath_Ljava_lang_String_Handler()
		{
			if ((object)cb_setStoragePath_Ljava_lang_String_ == null)
			{
				cb_setStoragePath_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetStoragePath_Ljava_lang_String_));
			}
			return cb_setStoragePath_Ljava_lang_String_;
		}

		private static IntPtr n_SetStoragePath_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ICronetEngineBuilder cronetEngineBuilder = Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string storagePath = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cronetEngineBuilder.SetStoragePath(storagePath));
		}

		[Register("setStoragePath", "(Ljava/lang/String;)Lorg/chromium/net/ICronetEngineBuilder;", "GetSetStoragePath_Ljava_lang_String_Handler")]
		public abstract ICronetEngineBuilder SetStoragePath(string p0);

		private static Delegate GetSetThreadPriority_IHandler()
		{
			if ((object)cb_setThreadPriority_I == null)
			{
				cb_setThreadPriority_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetThreadPriority_I));
			}
			return cb_setThreadPriority_I;
		}

		private static IntPtr n_SetThreadPriority_I(IntPtr jnienv, IntPtr native__this, int priority)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetThreadPriority(priority));
		}

		[Register("setThreadPriority", "(I)Lorg/chromium/net/ICronetEngineBuilder;", "GetSetThreadPriority_IHandler")]
		public unsafe virtual ICronetEngineBuilder SetThreadPriority(int priority)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(priority);
			return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setThreadPriority.(I)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetUserAgent_Ljava_lang_String_Handler()
		{
			if ((object)cb_setUserAgent_Ljava_lang_String_ == null)
			{
				cb_setUserAgent_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetUserAgent_Ljava_lang_String_));
			}
			return cb_setUserAgent_Ljava_lang_String_;
		}

		private static IntPtr n_SetUserAgent_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ICronetEngineBuilder cronetEngineBuilder = Java.Lang.Object.GetObject<ICronetEngineBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string userAgent = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cronetEngineBuilder.SetUserAgent(userAgent));
		}

		[Register("setUserAgent", "(Ljava/lang/String;)Lorg/chromium/net/ICronetEngineBuilder;", "GetSetUserAgent_Ljava_lang_String_Handler")]
		public abstract ICronetEngineBuilder SetUserAgent(string p0);
	}
	[Register("org/chromium/net/ICronetEngineBuilder", DoNotGenerateAcw = true)]
	internal class ICronetEngineBuilderInvoker : ICronetEngineBuilder
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/ICronetEngineBuilder", typeof(ICronetEngineBuilderInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string DefaultUserAgent
		{
			[Register("getDefaultUserAgent", "()Ljava/lang/String;", "GetGetDefaultUserAgentHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDefaultUserAgent.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public ICronetEngineBuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("addQuicHint", "(Ljava/lang/String;II)Lorg/chromium/net/ICronetEngineBuilder;", "GetAddQuicHint_Ljava_lang_String_IIHandler")]
		public unsafe override ICronetEngineBuilder AddQuicHint(string p0, int p1, int p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addQuicHint.(Ljava/lang/String;II)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("build", "()Lorg/chromium/net/ExperimentalCronetEngine;", "GetBuildHandler")]
		public unsafe override ExperimentalCronetEngine Build()
		{
			return Java.Lang.Object.GetObject<ExperimentalCronetEngine>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lorg/chromium/net/ExperimentalCronetEngine;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("enableHttp2", "(Z)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnableHttp2_ZHandler")]
		public unsafe override ICronetEngineBuilder EnableHttp2(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableHttp2.(Z)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("enableHttpCache", "(IJ)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnableHttpCache_IJHandler")]
		public unsafe override ICronetEngineBuilder EnableHttpCache(int p0, long p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableHttpCache.(IJ)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("enablePublicKeyPinningBypassForLocalTrustAnchors", "(Z)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnablePublicKeyPinningBypassForLocalTrustAnchors_ZHandler")]
		public unsafe override ICronetEngineBuilder EnablePublicKeyPinningBypassForLocalTrustAnchors(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enablePublicKeyPinningBypassForLocalTrustAnchors.(Z)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("enableQuic", "(Z)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnableQuic_ZHandler")]
		public unsafe override ICronetEngineBuilder EnableQuic(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableQuic.(Z)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("enableSdch", "(Z)Lorg/chromium/net/ICronetEngineBuilder;", "GetEnableSdch_ZHandler")]
		public unsafe override ICronetEngineBuilder EnableSdch(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableSdch.(Z)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setExperimentalOptions", "(Ljava/lang/String;)Lorg/chromium/net/ICronetEngineBuilder;", "GetSetExperimentalOptions_Ljava_lang_String_Handler")]
		public unsafe override ICronetEngineBuilder SetExperimentalOptions(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExperimentalOptions.(Ljava/lang/String;)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setLibraryLoader", "(Lorg/chromium/net/CronetEngine$Builder$LibraryLoader;)Lorg/chromium/net/ICronetEngineBuilder;", "GetSetLibraryLoader_Lorg_chromium_net_CronetEngine_Builder_LibraryLoader_Handler")]
		public unsafe override ICronetEngineBuilder SetLibraryLoader(CronetEngine.Builder.LibraryLoader p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLibraryLoader.(Lorg/chromium/net/CronetEngine$Builder$LibraryLoader;)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("setStoragePath", "(Ljava/lang/String;)Lorg/chromium/net/ICronetEngineBuilder;", "GetSetStoragePath_Ljava_lang_String_Handler")]
		public unsafe override ICronetEngineBuilder SetStoragePath(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setStoragePath.(Ljava/lang/String;)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setUserAgent", "(Ljava/lang/String;)Lorg/chromium/net/ICronetEngineBuilder;", "GetSetUserAgent_Ljava_lang_String_Handler")]
		public unsafe override ICronetEngineBuilder SetUserAgent(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ICronetEngineBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setUserAgent.(Ljava/lang/String;)Lorg/chromium/net/ICronetEngineBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("org/chromium/net/InlineExecutionProhibitedException", DoNotGenerateAcw = true)]
	public sealed class InlineExecutionProhibitedException : RejectedExecutionException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/InlineExecutionProhibitedException", typeof(InlineExecutionProhibitedException));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal InlineExecutionProhibitedException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe InlineExecutionProhibitedException()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("org/chromium/net/NetworkException", DoNotGenerateAcw = true)]
	public abstract class NetworkException : CronetException
	{
		[Register("ERROR_ADDRESS_UNREACHABLE")]
		public const int ErrorAddressUnreachable = 9;

		[Register("ERROR_CONNECTION_CLOSED")]
		public const int ErrorConnectionClosed = 5;

		[Register("ERROR_CONNECTION_REFUSED")]
		public const int ErrorConnectionRefused = 7;

		[Register("ERROR_CONNECTION_RESET")]
		public const int ErrorConnectionReset = 8;

		[Register("ERROR_CONNECTION_TIMED_OUT")]
		public const int ErrorConnectionTimedOut = 6;

		[Register("ERROR_HOSTNAME_NOT_RESOLVED")]
		public const int ErrorHostnameNotResolved = 1;

		[Register("ERROR_INTERNET_DISCONNECTED")]
		public const int ErrorInternetDisconnected = 2;

		[Register("ERROR_NETWORK_CHANGED")]
		public const int ErrorNetworkChanged = 3;

		[Register("ERROR_OTHER")]
		public const int ErrorOther = 11;

		[Register("ERROR_QUIC_PROTOCOL_FAILED")]
		public const int ErrorQuicProtocolFailed = 10;

		[Register("ERROR_TIMED_OUT")]
		public const int ErrorTimedOut = 4;

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/NetworkException", typeof(NetworkException));

		private static Delegate cb_getCronetInternalErrorCode;

		private static Delegate cb_getErrorCode;

		private static Delegate cb_immediatelyRetryable;

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

		public abstract int CronetInternalErrorCode
		{
			[Register("getCronetInternalErrorCode", "()I", "GetGetCronetInternalErrorCodeHandler")]
			get;
		}

		public abstract int ErrorCode
		{
			[Register("getErrorCode", "()I", "GetGetErrorCodeHandler")]
			get;
		}

		protected NetworkException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		protected unsafe NetworkException(string message, Throwable cause)
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

		private static Delegate GetGetCronetInternalErrorCodeHandler()
		{
			if ((object)cb_getCronetInternalErrorCode == null)
			{
				cb_getCronetInternalErrorCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCronetInternalErrorCode));
			}
			return cb_getCronetInternalErrorCode;
		}

		private static int n_GetCronetInternalErrorCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<NetworkException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CronetInternalErrorCode;
		}

		private static Delegate GetGetErrorCodeHandler()
		{
			if ((object)cb_getErrorCode == null)
			{
				cb_getErrorCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetErrorCode));
			}
			return cb_getErrorCode;
		}

		private static int n_GetErrorCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<NetworkException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorCode;
		}

		private static Delegate GetImmediatelyRetryableHandler()
		{
			if ((object)cb_immediatelyRetryable == null)
			{
				cb_immediatelyRetryable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_ImmediatelyRetryable));
			}
			return cb_immediatelyRetryable;
		}

		private static bool n_ImmediatelyRetryable(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<NetworkException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImmediatelyRetryable();
		}

		[Register("immediatelyRetryable", "()Z", "GetImmediatelyRetryableHandler")]
		public abstract bool ImmediatelyRetryable();
	}
	[Register("org/chromium/net/NetworkException", DoNotGenerateAcw = true)]
	internal class NetworkExceptionInvoker : NetworkException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/NetworkException", typeof(NetworkExceptionInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override int CronetInternalErrorCode
		{
			[Register("getCronetInternalErrorCode", "()I", "GetGetCronetInternalErrorCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getCronetInternalErrorCode.()I", this, null);
			}
		}

		public unsafe override int ErrorCode
		{
			[Register("getErrorCode", "()I", "GetGetErrorCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getErrorCode.()I", this, null);
			}
		}

		public NetworkExceptionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("immediatelyRetryable", "()Z", "GetImmediatelyRetryableHandler")]
		public unsafe override bool ImmediatelyRetryable()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("immediatelyRetryable.()Z", this, null);
		}
	}
	[Register("org/chromium/net/NetworkQualityRttListener", DoNotGenerateAcw = true)]
	public abstract class NetworkQualityRttListener : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/NetworkQualityRttListener", typeof(NetworkQualityRttListener));

		private static Delegate cb_getExecutor;

		private static Delegate cb_onRttObservation_IJI;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IExecutor Executor
		{
			[Register("getExecutor", "()Ljava/util/concurrent/Executor;", "GetGetExecutorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected NetworkQualityRttListener(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/concurrent/Executor;)V", "")]
		public unsafe NetworkQualityRttListener(IExecutor executor)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/concurrent/Executor;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/concurrent/Executor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(executor);
			}
		}

		private static Delegate GetGetExecutorHandler()
		{
			if ((object)cb_getExecutor == null)
			{
				cb_getExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExecutor));
			}
			return cb_getExecutor;
		}

		private static IntPtr n_GetExecutor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NetworkQualityRttListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Executor);
		}

		private static Delegate GetOnRttObservation_IJIHandler()
		{
			if ((object)cb_onRttObservation_IJI == null)
			{
				cb_onRttObservation_IJI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIJI_V(n_OnRttObservation_IJI));
			}
			return cb_onRttObservation_IJI;
		}

		private static void n_OnRttObservation_IJI(IntPtr jnienv, IntPtr native__this, int p0, long p1, int p2)
		{
			Java.Lang.Object.GetObject<NetworkQualityRttListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnRttObservation(p0, p1, p2);
		}

		[Register("onRttObservation", "(IJI)V", "GetOnRttObservation_IJIHandler")]
		public abstract void OnRttObservation(int p0, long p1, int p2);
	}
	[Register("org/chromium/net/NetworkQualityRttListener", DoNotGenerateAcw = true)]
	internal class NetworkQualityRttListenerInvoker : NetworkQualityRttListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/NetworkQualityRttListener", typeof(NetworkQualityRttListenerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public NetworkQualityRttListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onRttObservation", "(IJI)V", "GetOnRttObservation_IJIHandler")]
		public unsafe override void OnRttObservation(int p0, long p1, int p2)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onRttObservation.(IJI)V", this, ptr);
		}
	}
	[Register("org/chromium/net/NetworkQualityThroughputListener", DoNotGenerateAcw = true)]
	public abstract class NetworkQualityThroughputListener : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/NetworkQualityThroughputListener", typeof(NetworkQualityThroughputListener));

		private static Delegate cb_getExecutor;

		private static Delegate cb_onThroughputObservation_IJI;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IExecutor Executor
		{
			[Register("getExecutor", "()Ljava/util/concurrent/Executor;", "GetGetExecutorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected NetworkQualityThroughputListener(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/concurrent/Executor;)V", "")]
		public unsafe NetworkQualityThroughputListener(IExecutor executor)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/concurrent/Executor;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/concurrent/Executor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(executor);
			}
		}

		private static Delegate GetGetExecutorHandler()
		{
			if ((object)cb_getExecutor == null)
			{
				cb_getExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExecutor));
			}
			return cb_getExecutor;
		}

		private static IntPtr n_GetExecutor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NetworkQualityThroughputListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Executor);
		}

		private static Delegate GetOnThroughputObservation_IJIHandler()
		{
			if ((object)cb_onThroughputObservation_IJI == null)
			{
				cb_onThroughputObservation_IJI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIJI_V(n_OnThroughputObservation_IJI));
			}
			return cb_onThroughputObservation_IJI;
		}

		private static void n_OnThroughputObservation_IJI(IntPtr jnienv, IntPtr native__this, int p0, long p1, int p2)
		{
			Java.Lang.Object.GetObject<NetworkQualityThroughputListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnThroughputObservation(p0, p1, p2);
		}

		[Register("onThroughputObservation", "(IJI)V", "GetOnThroughputObservation_IJIHandler")]
		public abstract void OnThroughputObservation(int p0, long p1, int p2);
	}
	[Register("org/chromium/net/NetworkQualityThroughputListener", DoNotGenerateAcw = true)]
	internal class NetworkQualityThroughputListenerInvoker : NetworkQualityThroughputListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/NetworkQualityThroughputListener", typeof(NetworkQualityThroughputListenerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public NetworkQualityThroughputListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onThroughputObservation", "(IJI)V", "GetOnThroughputObservation_IJIHandler")]
		public unsafe override void OnThroughputObservation(int p0, long p1, int p2)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onThroughputObservation.(IJI)V", this, ptr);
		}
	}
	[Register("org/chromium/net/QuicException", DoNotGenerateAcw = true)]
	public abstract class QuicException : NetworkException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/QuicException", typeof(QuicException));

		private static Delegate cb_getQuicDetailedErrorCode;

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

		public abstract int QuicDetailedErrorCode
		{
			[Register("getQuicDetailedErrorCode", "()I", "GetGetQuicDetailedErrorCodeHandler")]
			get;
		}

		protected QuicException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		protected unsafe QuicException(string message, Throwable cause)
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

		private static Delegate GetGetQuicDetailedErrorCodeHandler()
		{
			if ((object)cb_getQuicDetailedErrorCode == null)
			{
				cb_getQuicDetailedErrorCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetQuicDetailedErrorCode));
			}
			return cb_getQuicDetailedErrorCode;
		}

		private static int n_GetQuicDetailedErrorCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<QuicException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).QuicDetailedErrorCode;
		}
	}
	[Register("org/chromium/net/QuicException", DoNotGenerateAcw = true)]
	internal class QuicExceptionInvoker : QuicException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/QuicException", typeof(QuicExceptionInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override int QuicDetailedErrorCode
		{
			[Register("getQuicDetailedErrorCode", "()I", "GetGetQuicDetailedErrorCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getQuicDetailedErrorCode.()I", this, null);
			}
		}

		public unsafe override int CronetInternalErrorCode
		{
			[Register("getCronetInternalErrorCode", "()I", "GetGetCronetInternalErrorCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getCronetInternalErrorCode.()I", this, null);
			}
		}

		public unsafe override int ErrorCode
		{
			[Register("getErrorCode", "()I", "GetGetErrorCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getErrorCode.()I", this, null);
			}
		}

		public QuicExceptionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("immediatelyRetryable", "()Z", "GetImmediatelyRetryableHandler")]
		public unsafe override bool ImmediatelyRetryable()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("immediatelyRetryable.()Z", this, null);
		}
	}
	[Register("org/chromium/net/RequestFinishedInfo", DoNotGenerateAcw = true)]
	public abstract class RequestFinishedInfo : Java.Lang.Object
	{
		[Register("org/chromium/net/RequestFinishedInfo$Listener", DoNotGenerateAcw = true)]
		public abstract class Listener : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/RequestFinishedInfo$Listener", typeof(Listener));

			private static Delegate cb_getExecutor;

			private static Delegate cb_onRequestFinished_Lorg_chromium_net_RequestFinishedInfo_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual IExecutor Executor
			{
				[Register("getExecutor", "()Ljava/util/concurrent/Executor;", "GetGetExecutorHandler")]
				get
				{
					return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected Listener(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Ljava/util/concurrent/Executor;)V", "")]
			public unsafe Listener(IExecutor executor)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/concurrent/Executor;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Ljava/util/concurrent/Executor;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(executor);
				}
			}

			private static Delegate GetGetExecutorHandler()
			{
				if ((object)cb_getExecutor == null)
				{
					cb_getExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExecutor));
				}
				return cb_getExecutor;
			}

			private static IntPtr n_GetExecutor(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Listener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Executor);
			}

			private static Delegate GetOnRequestFinished_Lorg_chromium_net_RequestFinishedInfo_Handler()
			{
				if ((object)cb_onRequestFinished_Lorg_chromium_net_RequestFinishedInfo_ == null)
				{
					cb_onRequestFinished_Lorg_chromium_net_RequestFinishedInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnRequestFinished_Lorg_chromium_net_RequestFinishedInfo_));
				}
				return cb_onRequestFinished_Lorg_chromium_net_RequestFinishedInfo_;
			}

			private static void n_OnRequestFinished_Lorg_chromium_net_RequestFinishedInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Listener listener = Java.Lang.Object.GetObject<Listener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RequestFinishedInfo p = Java.Lang.Object.GetObject<RequestFinishedInfo>(native_p0, JniHandleOwnership.DoNotTransfer);
				listener.OnRequestFinished(p);
			}

			[Register("onRequestFinished", "(Lorg/chromium/net/RequestFinishedInfo;)V", "GetOnRequestFinished_Lorg_chromium_net_RequestFinishedInfo_Handler")]
			public abstract void OnRequestFinished(RequestFinishedInfo p0);
		}

		[Register("org/chromium/net/RequestFinishedInfo$Listener", DoNotGenerateAcw = true)]
		internal class ListenerInvoker : Listener
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/RequestFinishedInfo$Listener", typeof(ListenerInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public ListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("onRequestFinished", "(Lorg/chromium/net/RequestFinishedInfo;)V", "GetOnRequestFinished_Lorg_chromium_net_RequestFinishedInfo_Handler")]
			public unsafe override void OnRequestFinished(RequestFinishedInfo p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onRequestFinished.(Lorg/chromium/net/RequestFinishedInfo;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}
		}

		[Register("org/chromium/net/RequestFinishedInfo$Metrics", DoNotGenerateAcw = true)]
		public abstract class Metrics : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/RequestFinishedInfo$Metrics", typeof(Metrics));

			private static Delegate cb_getConnectEnd;

			private static Delegate cb_getConnectStart;

			private static Delegate cb_getDnsEnd;

			private static Delegate cb_getDnsStart;

			private static Delegate cb_getPushEnd;

			private static Delegate cb_getPushStart;

			private static Delegate cb_getReceivedByteCount;

			private static Delegate cb_getRequestEnd;

			private static Delegate cb_getRequestStart;

			private static Delegate cb_getResponseStart;

			private static Delegate cb_getSendingEnd;

			private static Delegate cb_getSendingStart;

			private static Delegate cb_getSentByteCount;

			private static Delegate cb_getSocketReused;

			private static Delegate cb_getSslEnd;

			private static Delegate cb_getSslStart;

			private static Delegate cb_getTotalTimeMs;

			private static Delegate cb_getTtfbMs;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public abstract Date ConnectEnd
			{
				[Register("getConnectEnd", "()Ljava/util/Date;", "GetGetConnectEndHandler")]
				get;
			}

			public abstract Date ConnectStart
			{
				[Register("getConnectStart", "()Ljava/util/Date;", "GetGetConnectStartHandler")]
				get;
			}

			public abstract Date DnsEnd
			{
				[Register("getDnsEnd", "()Ljava/util/Date;", "GetGetDnsEndHandler")]
				get;
			}

			public abstract Date DnsStart
			{
				[Register("getDnsStart", "()Ljava/util/Date;", "GetGetDnsStartHandler")]
				get;
			}

			public abstract Date PushEnd
			{
				[Register("getPushEnd", "()Ljava/util/Date;", "GetGetPushEndHandler")]
				get;
			}

			public abstract Date PushStart
			{
				[Register("getPushStart", "()Ljava/util/Date;", "GetGetPushStartHandler")]
				get;
			}

			public abstract Long ReceivedByteCount
			{
				[Register("getReceivedByteCount", "()Ljava/lang/Long;", "GetGetReceivedByteCountHandler")]
				get;
			}

			public abstract Date RequestEnd
			{
				[Register("getRequestEnd", "()Ljava/util/Date;", "GetGetRequestEndHandler")]
				get;
			}

			public abstract Date RequestStart
			{
				[Register("getRequestStart", "()Ljava/util/Date;", "GetGetRequestStartHandler")]
				get;
			}

			public abstract Date ResponseStart
			{
				[Register("getResponseStart", "()Ljava/util/Date;", "GetGetResponseStartHandler")]
				get;
			}

			public abstract Date SendingEnd
			{
				[Register("getSendingEnd", "()Ljava/util/Date;", "GetGetSendingEndHandler")]
				get;
			}

			public abstract Date SendingStart
			{
				[Register("getSendingStart", "()Ljava/util/Date;", "GetGetSendingStartHandler")]
				get;
			}

			public abstract Long SentByteCount
			{
				[Register("getSentByteCount", "()Ljava/lang/Long;", "GetGetSentByteCountHandler")]
				get;
			}

			public abstract bool SocketReused
			{
				[Register("getSocketReused", "()Z", "GetGetSocketReusedHandler")]
				get;
			}

			public abstract Date SslEnd
			{
				[Register("getSslEnd", "()Ljava/util/Date;", "GetGetSslEndHandler")]
				get;
			}

			public abstract Date SslStart
			{
				[Register("getSslStart", "()Ljava/util/Date;", "GetGetSslStartHandler")]
				get;
			}

			public abstract Long TotalTimeMs
			{
				[Register("getTotalTimeMs", "()Ljava/lang/Long;", "GetGetTotalTimeMsHandler")]
				get;
			}

			public abstract Long TtfbMs
			{
				[Register("getTtfbMs", "()Ljava/lang/Long;", "GetGetTtfbMsHandler")]
				get;
			}

			protected Metrics(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Metrics()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetGetConnectEndHandler()
			{
				if ((object)cb_getConnectEnd == null)
				{
					cb_getConnectEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConnectEnd));
				}
				return cb_getConnectEnd;
			}

			private static IntPtr n_GetConnectEnd(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConnectEnd);
			}

			private static Delegate GetGetConnectStartHandler()
			{
				if ((object)cb_getConnectStart == null)
				{
					cb_getConnectStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConnectStart));
				}
				return cb_getConnectStart;
			}

			private static IntPtr n_GetConnectStart(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConnectStart);
			}

			private static Delegate GetGetDnsEndHandler()
			{
				if ((object)cb_getDnsEnd == null)
				{
					cb_getDnsEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDnsEnd));
				}
				return cb_getDnsEnd;
			}

			private static IntPtr n_GetDnsEnd(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DnsEnd);
			}

			private static Delegate GetGetDnsStartHandler()
			{
				if ((object)cb_getDnsStart == null)
				{
					cb_getDnsStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDnsStart));
				}
				return cb_getDnsStart;
			}

			private static IntPtr n_GetDnsStart(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DnsStart);
			}

			private static Delegate GetGetPushEndHandler()
			{
				if ((object)cb_getPushEnd == null)
				{
					cb_getPushEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPushEnd));
				}
				return cb_getPushEnd;
			}

			private static IntPtr n_GetPushEnd(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PushEnd);
			}

			private static Delegate GetGetPushStartHandler()
			{
				if ((object)cb_getPushStart == null)
				{
					cb_getPushStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPushStart));
				}
				return cb_getPushStart;
			}

			private static IntPtr n_GetPushStart(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PushStart);
			}

			private static Delegate GetGetReceivedByteCountHandler()
			{
				if ((object)cb_getReceivedByteCount == null)
				{
					cb_getReceivedByteCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetReceivedByteCount));
				}
				return cb_getReceivedByteCount;
			}

			private static IntPtr n_GetReceivedByteCount(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReceivedByteCount);
			}

			private static Delegate GetGetRequestEndHandler()
			{
				if ((object)cb_getRequestEnd == null)
				{
					cb_getRequestEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRequestEnd));
				}
				return cb_getRequestEnd;
			}

			private static IntPtr n_GetRequestEnd(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestEnd);
			}

			private static Delegate GetGetRequestStartHandler()
			{
				if ((object)cb_getRequestStart == null)
				{
					cb_getRequestStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRequestStart));
				}
				return cb_getRequestStart;
			}

			private static IntPtr n_GetRequestStart(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestStart);
			}

			private static Delegate GetGetResponseStartHandler()
			{
				if ((object)cb_getResponseStart == null)
				{
					cb_getResponseStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetResponseStart));
				}
				return cb_getResponseStart;
			}

			private static IntPtr n_GetResponseStart(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResponseStart);
			}

			private static Delegate GetGetSendingEndHandler()
			{
				if ((object)cb_getSendingEnd == null)
				{
					cb_getSendingEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSendingEnd));
				}
				return cb_getSendingEnd;
			}

			private static IntPtr n_GetSendingEnd(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SendingEnd);
			}

			private static Delegate GetGetSendingStartHandler()
			{
				if ((object)cb_getSendingStart == null)
				{
					cb_getSendingStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSendingStart));
				}
				return cb_getSendingStart;
			}

			private static IntPtr n_GetSendingStart(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SendingStart);
			}

			private static Delegate GetGetSentByteCountHandler()
			{
				if ((object)cb_getSentByteCount == null)
				{
					cb_getSentByteCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSentByteCount));
				}
				return cb_getSentByteCount;
			}

			private static IntPtr n_GetSentByteCount(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SentByteCount);
			}

			private static Delegate GetGetSocketReusedHandler()
			{
				if ((object)cb_getSocketReused == null)
				{
					cb_getSocketReused = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetSocketReused));
				}
				return cb_getSocketReused;
			}

			private static bool n_GetSocketReused(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SocketReused;
			}

			private static Delegate GetGetSslEndHandler()
			{
				if ((object)cb_getSslEnd == null)
				{
					cb_getSslEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSslEnd));
				}
				return cb_getSslEnd;
			}

			private static IntPtr n_GetSslEnd(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SslEnd);
			}

			private static Delegate GetGetSslStartHandler()
			{
				if ((object)cb_getSslStart == null)
				{
					cb_getSslStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSslStart));
				}
				return cb_getSslStart;
			}

			private static IntPtr n_GetSslStart(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SslStart);
			}

			private static Delegate GetGetTotalTimeMsHandler()
			{
				if ((object)cb_getTotalTimeMs == null)
				{
					cb_getTotalTimeMs = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTotalTimeMs));
				}
				return cb_getTotalTimeMs;
			}

			private static IntPtr n_GetTotalTimeMs(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TotalTimeMs);
			}

			private static Delegate GetGetTtfbMsHandler()
			{
				if ((object)cb_getTtfbMs == null)
				{
					cb_getTtfbMs = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTtfbMs));
				}
				return cb_getTtfbMs;
			}

			private static IntPtr n_GetTtfbMs(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TtfbMs);
			}
		}

		[Register("org/chromium/net/RequestFinishedInfo$Metrics", DoNotGenerateAcw = true)]
		internal class MetricsInvoker : Metrics
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/RequestFinishedInfo$Metrics", typeof(MetricsInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe override Date ConnectEnd
			{
				[Register("getConnectEnd", "()Ljava/util/Date;", "GetGetConnectEndHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getConnectEnd.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date ConnectStart
			{
				[Register("getConnectStart", "()Ljava/util/Date;", "GetGetConnectStartHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getConnectStart.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date DnsEnd
			{
				[Register("getDnsEnd", "()Ljava/util/Date;", "GetGetDnsEndHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDnsEnd.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date DnsStart
			{
				[Register("getDnsStart", "()Ljava/util/Date;", "GetGetDnsStartHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDnsStart.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date PushEnd
			{
				[Register("getPushEnd", "()Ljava/util/Date;", "GetGetPushEndHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPushEnd.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date PushStart
			{
				[Register("getPushStart", "()Ljava/util/Date;", "GetGetPushStartHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPushStart.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Long ReceivedByteCount
			{
				[Register("getReceivedByteCount", "()Ljava/lang/Long;", "GetGetReceivedByteCountHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Long>(_members.InstanceMethods.InvokeAbstractObjectMethod("getReceivedByteCount.()Ljava/lang/Long;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date RequestEnd
			{
				[Register("getRequestEnd", "()Ljava/util/Date;", "GetGetRequestEndHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRequestEnd.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date RequestStart
			{
				[Register("getRequestStart", "()Ljava/util/Date;", "GetGetRequestStartHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRequestStart.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date ResponseStart
			{
				[Register("getResponseStart", "()Ljava/util/Date;", "GetGetResponseStartHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResponseStart.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date SendingEnd
			{
				[Register("getSendingEnd", "()Ljava/util/Date;", "GetGetSendingEndHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSendingEnd.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date SendingStart
			{
				[Register("getSendingStart", "()Ljava/util/Date;", "GetGetSendingStartHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSendingStart.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Long SentByteCount
			{
				[Register("getSentByteCount", "()Ljava/lang/Long;", "GetGetSentByteCountHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Long>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSentByteCount.()Ljava/lang/Long;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override bool SocketReused
			{
				[Register("getSocketReused", "()Z", "GetGetSocketReusedHandler")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractBooleanMethod("getSocketReused.()Z", this, null);
				}
			}

			public unsafe override Date SslEnd
			{
				[Register("getSslEnd", "()Ljava/util/Date;", "GetGetSslEndHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSslEnd.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Date SslStart
			{
				[Register("getSslStart", "()Ljava/util/Date;", "GetGetSslStartHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSslStart.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Long TotalTimeMs
			{
				[Register("getTotalTimeMs", "()Ljava/lang/Long;", "GetGetTotalTimeMsHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Long>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTotalTimeMs.()Ljava/lang/Long;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override Long TtfbMs
			{
				[Register("getTtfbMs", "()Ljava/lang/Long;", "GetGetTtfbMsHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Long>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTtfbMs.()Ljava/lang/Long;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public MetricsInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		[Register("CANCELED")]
		public const int Canceled = 2;

		[Register("FAILED")]
		public const int Failed = 1;

		[Register("SUCCEEDED")]
		public const int Succeeded = 0;

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/RequestFinishedInfo", typeof(RequestFinishedInfo));

		private static Delegate cb_getAnnotations;

		private static Delegate cb_getException;

		private static Delegate cb_getFinishedReason;

		private static Delegate cb_getResponseInfo;

		private static Delegate cb_getUrl;

		private static Delegate cb_getMetrics;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract ICollection<Java.Lang.Object> Annotations
		{
			[Register("getAnnotations", "()Ljava/util/Collection;", "GetGetAnnotationsHandler")]
			get;
		}

		public abstract CronetException Exception
		{
			[Register("getException", "()Lorg/chromium/net/CronetException;", "GetGetExceptionHandler")]
			get;
		}

		public abstract int FinishedReason
		{
			[Register("getFinishedReason", "()I", "GetGetFinishedReasonHandler")]
			get;
		}

		public abstract UrlResponseInfo ResponseInfo
		{
			[Register("getResponseInfo", "()Lorg/chromium/net/UrlResponseInfo;", "GetGetResponseInfoHandler")]
			get;
		}

		public abstract string Url
		{
			[Register("getUrl", "()Ljava/lang/String;", "GetGetUrlHandler")]
			get;
		}

		protected RequestFinishedInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe RequestFinishedInfo()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetAnnotationsHandler()
		{
			if ((object)cb_getAnnotations == null)
			{
				cb_getAnnotations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAnnotations));
			}
			return cb_getAnnotations;
		}

		private static IntPtr n_GetAnnotations(IntPtr jnienv, IntPtr native__this)
		{
			return JavaCollection<Java.Lang.Object>.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestFinishedInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Annotations);
		}

		private static Delegate GetGetExceptionHandler()
		{
			if ((object)cb_getException == null)
			{
				cb_getException = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetException));
			}
			return cb_getException;
		}

		private static IntPtr n_GetException(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestFinishedInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Exception);
		}

		private static Delegate GetGetFinishedReasonHandler()
		{
			if ((object)cb_getFinishedReason == null)
			{
				cb_getFinishedReason = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetFinishedReason));
			}
			return cb_getFinishedReason;
		}

		private static int n_GetFinishedReason(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<RequestFinishedInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinishedReason;
		}

		private static Delegate GetGetResponseInfoHandler()
		{
			if ((object)cb_getResponseInfo == null)
			{
				cb_getResponseInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetResponseInfo));
			}
			return cb_getResponseInfo;
		}

		private static IntPtr n_GetResponseInfo(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestFinishedInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResponseInfo);
		}

		private static Delegate GetGetUrlHandler()
		{
			if ((object)cb_getUrl == null)
			{
				cb_getUrl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUrl));
			}
			return cb_getUrl;
		}

		private static IntPtr n_GetUrl(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<RequestFinishedInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Url);
		}

		private static Delegate GetGetMetricsHandler()
		{
			if ((object)cb_getMetrics == null)
			{
				cb_getMetrics = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMetrics));
			}
			return cb_getMetrics;
		}

		private static IntPtr n_GetMetrics(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestFinishedInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetMetrics());
		}

		[Register("getMetrics", "()Lorg/chromium/net/RequestFinishedInfo$Metrics;", "GetGetMetricsHandler")]
		public abstract Metrics GetMetrics();
	}
	[Register("org/chromium/net/RequestFinishedInfo", DoNotGenerateAcw = true)]
	internal class RequestFinishedInfoInvoker : RequestFinishedInfo
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/RequestFinishedInfo", typeof(RequestFinishedInfoInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override ICollection<Java.Lang.Object> Annotations
		{
			[Register("getAnnotations", "()Ljava/util/Collection;", "GetGetAnnotationsHandler")]
			get
			{
				return JavaCollection<Java.Lang.Object>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getAnnotations.()Ljava/util/Collection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override CronetException Exception
		{
			[Register("getException", "()Lorg/chromium/net/CronetException;", "GetGetExceptionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<CronetException>(_members.InstanceMethods.InvokeAbstractObjectMethod("getException.()Lorg/chromium/net/CronetException;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override int FinishedReason
		{
			[Register("getFinishedReason", "()I", "GetGetFinishedReasonHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getFinishedReason.()I", this, null);
			}
		}

		public unsafe override UrlResponseInfo ResponseInfo
		{
			[Register("getResponseInfo", "()Lorg/chromium/net/UrlResponseInfo;", "GetGetResponseInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<UrlResponseInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResponseInfo.()Lorg/chromium/net/UrlResponseInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string Url
		{
			[Register("getUrl", "()Ljava/lang/String;", "GetGetUrlHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public RequestFinishedInfoInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getMetrics", "()Lorg/chromium/net/RequestFinishedInfo$Metrics;", "GetGetMetricsHandler")]
		public unsafe override Metrics GetMetrics()
		{
			return Java.Lang.Object.GetObject<Metrics>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMetrics.()Lorg/chromium/net/RequestFinishedInfo$Metrics;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("org/chromium/net/UploadDataProvider", DoNotGenerateAcw = true)]
	public abstract class UploadDataProvider : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UploadDataProvider", typeof(UploadDataProvider));

		private static Delegate cb_getLength;

		private static Delegate cb_close;

		private static Delegate cb_read_Lorg_chromium_net_UploadDataSink_Ljava_nio_ByteBuffer_;

		private static Delegate cb_rewind_Lorg_chromium_net_UploadDataSink_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract long Length
		{
			[Register("getLength", "()J", "GetGetLengthHandler")]
			get;
		}

		protected UploadDataProvider(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UploadDataProvider()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetLengthHandler()
		{
			if ((object)cb_getLength == null)
			{
				cb_getLength = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetLength));
			}
			return cb_getLength;
		}

		private static long n_GetLength(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<UploadDataProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Length;
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
			Java.Lang.Object.GetObject<UploadDataProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}

		private static Delegate GetRead_Lorg_chromium_net_UploadDataSink_Ljava_nio_ByteBuffer_Handler()
		{
			if ((object)cb_read_Lorg_chromium_net_UploadDataSink_Ljava_nio_ByteBuffer_ == null)
			{
				cb_read_Lorg_chromium_net_UploadDataSink_Ljava_nio_ByteBuffer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Read_Lorg_chromium_net_UploadDataSink_Ljava_nio_ByteBuffer_));
			}
			return cb_read_Lorg_chromium_net_UploadDataSink_Ljava_nio_ByteBuffer_;
		}

		private static void n_Read_Lorg_chromium_net_UploadDataSink_Ljava_nio_ByteBuffer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			UploadDataProvider uploadDataProvider = Java.Lang.Object.GetObject<UploadDataProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UploadDataSink p = Java.Lang.Object.GetObject<UploadDataSink>(native_p0, JniHandleOwnership.DoNotTransfer);
			ByteBuffer p2 = Java.Lang.Object.GetObject<ByteBuffer>(native_p1, JniHandleOwnership.DoNotTransfer);
			uploadDataProvider.Read(p, p2);
		}

		[Register("read", "(Lorg/chromium/net/UploadDataSink;Ljava/nio/ByteBuffer;)V", "GetRead_Lorg_chromium_net_UploadDataSink_Ljava_nio_ByteBuffer_Handler")]
		public abstract void Read(UploadDataSink p0, ByteBuffer p1);

		private static Delegate GetRewind_Lorg_chromium_net_UploadDataSink_Handler()
		{
			if ((object)cb_rewind_Lorg_chromium_net_UploadDataSink_ == null)
			{
				cb_rewind_Lorg_chromium_net_UploadDataSink_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Rewind_Lorg_chromium_net_UploadDataSink_));
			}
			return cb_rewind_Lorg_chromium_net_UploadDataSink_;
		}

		private static void n_Rewind_Lorg_chromium_net_UploadDataSink_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			UploadDataProvider uploadDataProvider = Java.Lang.Object.GetObject<UploadDataProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UploadDataSink p = Java.Lang.Object.GetObject<UploadDataSink>(native_p0, JniHandleOwnership.DoNotTransfer);
			uploadDataProvider.Rewind(p);
		}

		[Register("rewind", "(Lorg/chromium/net/UploadDataSink;)V", "GetRewind_Lorg_chromium_net_UploadDataSink_Handler")]
		public abstract void Rewind(UploadDataSink p0);
	}
	[Register("org/chromium/net/UploadDataProvider", DoNotGenerateAcw = true)]
	internal class UploadDataProviderInvoker : UploadDataProvider
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UploadDataProvider", typeof(UploadDataProviderInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override long Length
		{
			[Register("getLength", "()J", "GetGetLengthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getLength.()J", this, null);
			}
		}

		public UploadDataProviderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("read", "(Lorg/chromium/net/UploadDataSink;Ljava/nio/ByteBuffer;)V", "GetRead_Lorg_chromium_net_UploadDataSink_Ljava_nio_ByteBuffer_Handler")]
		public unsafe override void Read(UploadDataSink p0, ByteBuffer p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("read.(Lorg/chromium/net/UploadDataSink;Ljava/nio/ByteBuffer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("rewind", "(Lorg/chromium/net/UploadDataSink;)V", "GetRewind_Lorg_chromium_net_UploadDataSink_Handler")]
		public unsafe override void Rewind(UploadDataSink p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("rewind.(Lorg/chromium/net/UploadDataSink;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("org/chromium/net/UploadDataProviders", DoNotGenerateAcw = true)]
	public sealed class UploadDataProviders : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UploadDataProviders", typeof(UploadDataProviders));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal UploadDataProviders(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("create", "(Landroid/os/ParcelFileDescriptor;)Lorg/chromium/net/UploadDataProvider;", "")]
		public unsafe static UploadDataProvider Create(ParcelFileDescriptor fd)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fd?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<UploadDataProvider>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/os/ParcelFileDescriptor;)Lorg/chromium/net/UploadDataProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(fd);
			}
		}

		[Register("create", "([B)Lorg/chromium/net/UploadDataProvider;", "")]
		public unsafe static UploadDataProvider Create(byte[] data)
		{
			IntPtr intPtr = JNIEnv.NewArray(data);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<UploadDataProvider>(_members.StaticMethods.InvokeObjectMethod("create.([B)Lorg/chromium/net/UploadDataProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (data != null)
				{
					JNIEnv.CopyArray(intPtr, data);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(data);
			}
		}

		[Register("create", "([BII)Lorg/chromium/net/UploadDataProvider;", "")]
		public unsafe static UploadDataProvider Create(byte[] data, int offset, int length)
		{
			IntPtr intPtr = JNIEnv.NewArray(data);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(offset);
				ptr[2] = new JniArgumentValue(length);
				return Java.Lang.Object.GetObject<UploadDataProvider>(_members.StaticMethods.InvokeObjectMethod("create.([BII)Lorg/chromium/net/UploadDataProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (data != null)
				{
					JNIEnv.CopyArray(intPtr, data);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(data);
			}
		}

		[Register("create", "(Ljava/io/File;)Lorg/chromium/net/UploadDataProvider;", "")]
		public unsafe static UploadDataProvider Create(File file)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<UploadDataProvider>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/io/File;)Lorg/chromium/net/UploadDataProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(file);
			}
		}

		[Register("create", "(Ljava/nio/ByteBuffer;)Lorg/chromium/net/UploadDataProvider;", "")]
		public unsafe static UploadDataProvider Create(ByteBuffer buffer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(buffer?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<UploadDataProvider>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/nio/ByteBuffer;)Lorg/chromium/net/UploadDataProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(buffer);
			}
		}
	}
	[Register("org/chromium/net/UploadDataSink", DoNotGenerateAcw = true)]
	public abstract class UploadDataSink : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UploadDataSink", typeof(UploadDataSink));

		private static Delegate cb_onReadError_Ljava_lang_Exception_;

		private static Delegate cb_onReadSucceeded_Z;

		private static Delegate cb_onRewindError_Ljava_lang_Exception_;

		private static Delegate cb_onRewindSucceeded;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected UploadDataSink(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UploadDataSink()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnReadError_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_onReadError_Ljava_lang_Exception_ == null)
			{
				cb_onReadError_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnReadError_Ljava_lang_Exception_));
			}
			return cb_onReadError_Ljava_lang_Exception_;
		}

		private static void n_OnReadError_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			UploadDataSink uploadDataSink = Java.Lang.Object.GetObject<UploadDataSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception p = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_p0, JniHandleOwnership.DoNotTransfer);
			uploadDataSink.OnReadError(p);
		}

		[Register("onReadError", "(Ljava/lang/Exception;)V", "GetOnReadError_Ljava_lang_Exception_Handler")]
		public abstract void OnReadError(Java.Lang.Exception p0);

		private static Delegate GetOnReadSucceeded_ZHandler()
		{
			if ((object)cb_onReadSucceeded_Z == null)
			{
				cb_onReadSucceeded_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnReadSucceeded_Z));
			}
			return cb_onReadSucceeded_Z;
		}

		private static void n_OnReadSucceeded_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			Java.Lang.Object.GetObject<UploadDataSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnReadSucceeded(p0);
		}

		[Register("onReadSucceeded", "(Z)V", "GetOnReadSucceeded_ZHandler")]
		public abstract void OnReadSucceeded(bool p0);

		private static Delegate GetOnRewindError_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_onRewindError_Ljava_lang_Exception_ == null)
			{
				cb_onRewindError_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnRewindError_Ljava_lang_Exception_));
			}
			return cb_onRewindError_Ljava_lang_Exception_;
		}

		private static void n_OnRewindError_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			UploadDataSink uploadDataSink = Java.Lang.Object.GetObject<UploadDataSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception p = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_p0, JniHandleOwnership.DoNotTransfer);
			uploadDataSink.OnRewindError(p);
		}

		[Register("onRewindError", "(Ljava/lang/Exception;)V", "GetOnRewindError_Ljava_lang_Exception_Handler")]
		public abstract void OnRewindError(Java.Lang.Exception p0);

		private static Delegate GetOnRewindSucceededHandler()
		{
			if ((object)cb_onRewindSucceeded == null)
			{
				cb_onRewindSucceeded = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnRewindSucceeded));
			}
			return cb_onRewindSucceeded;
		}

		private static void n_OnRewindSucceeded(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<UploadDataSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnRewindSucceeded();
		}

		[Register("onRewindSucceeded", "()V", "GetOnRewindSucceededHandler")]
		public abstract void OnRewindSucceeded();
	}
	[Register("org/chromium/net/UploadDataSink", DoNotGenerateAcw = true)]
	internal class UploadDataSinkInvoker : UploadDataSink
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UploadDataSink", typeof(UploadDataSinkInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public UploadDataSinkInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onReadError", "(Ljava/lang/Exception;)V", "GetOnReadError_Ljava_lang_Exception_Handler")]
		public unsafe override void OnReadError(Java.Lang.Exception p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onReadError.(Ljava/lang/Exception;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("onReadSucceeded", "(Z)V", "GetOnReadSucceeded_ZHandler")]
		public unsafe override void OnReadSucceeded(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onReadSucceeded.(Z)V", this, ptr);
		}

		[Register("onRewindError", "(Ljava/lang/Exception;)V", "GetOnRewindError_Ljava_lang_Exception_Handler")]
		public unsafe override void OnRewindError(Java.Lang.Exception p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onRewindError.(Ljava/lang/Exception;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("onRewindSucceeded", "()V", "GetOnRewindSucceededHandler")]
		public unsafe override void OnRewindSucceeded()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("onRewindSucceeded.()V", this, null);
		}
	}
	[Register("org/chromium/net/UrlRequest", DoNotGenerateAcw = true)]
	public abstract class UrlRequest : Java.Lang.Object
	{
		[Register("org/chromium/net/UrlRequest$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			[Register("REQUEST_PRIORITY_HIGHEST")]
			public const int RequestPriorityHighest = 4;

			[Register("REQUEST_PRIORITY_IDLE")]
			public const int RequestPriorityIdle = 0;

			[Register("REQUEST_PRIORITY_LOW")]
			public const int RequestPriorityLow = 2;

			[Register("REQUEST_PRIORITY_LOWEST")]
			public const int RequestPriorityLowest = 1;

			[Register("REQUEST_PRIORITY_MEDIUM")]
			public const int RequestPriorityMedium = 3;

			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlRequest$Builder", typeof(Builder));

			private static Delegate cb_addHeader_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_allowDirectExecutor;

			private static Delegate cb_build;

			private static Delegate cb_disableCache;

			private static Delegate cb_setHttpMethod_Ljava_lang_String_;

			private static Delegate cb_setPriority_I;

			private static Delegate cb_setUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			private static Delegate GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler()
			{
				if ((object)cb_addHeader_Ljava_lang_String_Ljava_lang_String_ == null)
				{
					cb_addHeader_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddHeader_Ljava_lang_String_Ljava_lang_String_));
				}
				return cb_addHeader_Ljava_lang_String_Ljava_lang_String_;
			}

			private static IntPtr n_AddHeader_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddHeader(p, p2));
			}

			[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/UrlRequest$Builder;", "GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public abstract Builder AddHeader(string p0, string p1);

			private static Delegate GetAllowDirectExecutorHandler()
			{
				if ((object)cb_allowDirectExecutor == null)
				{
					cb_allowDirectExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AllowDirectExecutor));
				}
				return cb_allowDirectExecutor;
			}

			private static IntPtr n_AllowDirectExecutor(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowDirectExecutor());
			}

			[Register("allowDirectExecutor", "()Lorg/chromium/net/UrlRequest$Builder;", "GetAllowDirectExecutorHandler")]
			public abstract Builder AllowDirectExecutor();

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

			[Register("build", "()Lorg/chromium/net/UrlRequest;", "GetBuildHandler")]
			public abstract UrlRequest Build();

			private static Delegate GetDisableCacheHandler()
			{
				if ((object)cb_disableCache == null)
				{
					cb_disableCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_DisableCache));
				}
				return cb_disableCache;
			}

			private static IntPtr n_DisableCache(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisableCache());
			}

			[Register("disableCache", "()Lorg/chromium/net/UrlRequest$Builder;", "GetDisableCacheHandler")]
			public abstract Builder DisableCache();

			private static Delegate GetSetHttpMethod_Ljava_lang_String_Handler()
			{
				if ((object)cb_setHttpMethod_Ljava_lang_String_ == null)
				{
					cb_setHttpMethod_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetHttpMethod_Ljava_lang_String_));
				}
				return cb_setHttpMethod_Ljava_lang_String_;
			}

			private static IntPtr n_SetHttpMethod_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string httpMethod = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetHttpMethod(httpMethod));
			}

			[Register("setHttpMethod", "(Ljava/lang/String;)Lorg/chromium/net/UrlRequest$Builder;", "GetSetHttpMethod_Ljava_lang_String_Handler")]
			public abstract Builder SetHttpMethod(string p0);

			private static Delegate GetSetPriority_IHandler()
			{
				if ((object)cb_setPriority_I == null)
				{
					cb_setPriority_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetPriority_I));
				}
				return cb_setPriority_I;
			}

			private static IntPtr n_SetPriority_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPriority(p0));
			}

			[Register("setPriority", "(I)Lorg/chromium/net/UrlRequest$Builder;", "GetSetPriority_IHandler")]
			public abstract Builder SetPriority(int p0);

			private static Delegate GetSetUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_Handler()
			{
				if ((object)cb_setUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_ == null)
				{
					cb_setUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_SetUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_));
				}
				return cb_setUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_;
			}

			private static IntPtr n_SetUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				UploadDataProvider p = Java.Lang.Object.GetObject<UploadDataProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
				IExecutor p2 = Java.Lang.Object.GetObject<IExecutor>(native_p1, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetUploadDataProvider(p, p2));
			}

			[Register("setUploadDataProvider", "(Lorg/chromium/net/UploadDataProvider;Ljava/util/concurrent/Executor;)Lorg/chromium/net/UrlRequest$Builder;", "GetSetUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_Handler")]
			public abstract Builder SetUploadDataProvider(UploadDataProvider p0, IExecutor p1);
		}

		[Register("org/chromium/net/UrlRequest$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlRequest$Builder", typeof(BuilderInvoker));

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

			[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/UrlRequest$Builder;", "GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe override Builder AddHeader(string p0, string p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewString(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addHeader.(Ljava/lang/String;Ljava/lang/String;)Lorg/chromium/net/UrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("allowDirectExecutor", "()Lorg/chromium/net/UrlRequest$Builder;", "GetAllowDirectExecutorHandler")]
			public unsafe override Builder AllowDirectExecutor()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("allowDirectExecutor.()Lorg/chromium/net/UrlRequest$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("build", "()Lorg/chromium/net/UrlRequest;", "GetBuildHandler")]
			public unsafe override UrlRequest Build()
			{
				return Java.Lang.Object.GetObject<UrlRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lorg/chromium/net/UrlRequest;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("disableCache", "()Lorg/chromium/net/UrlRequest$Builder;", "GetDisableCacheHandler")]
			public unsafe override Builder DisableCache()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("disableCache.()Lorg/chromium/net/UrlRequest$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setHttpMethod", "(Ljava/lang/String;)Lorg/chromium/net/UrlRequest$Builder;", "GetSetHttpMethod_Ljava_lang_String_Handler")]
			public unsafe override Builder SetHttpMethod(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setHttpMethod.(Ljava/lang/String;)Lorg/chromium/net/UrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setPriority", "(I)Lorg/chromium/net/UrlRequest$Builder;", "GetSetPriority_IHandler")]
			public unsafe override Builder SetPriority(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPriority.(I)Lorg/chromium/net/UrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setUploadDataProvider", "(Lorg/chromium/net/UploadDataProvider;Ljava/util/concurrent/Executor;)Lorg/chromium/net/UrlRequest$Builder;", "GetSetUploadDataProvider_Lorg_chromium_net_UploadDataProvider_Ljava_util_concurrent_Executor_Handler")]
			public unsafe override Builder SetUploadDataProvider(UploadDataProvider p0, IExecutor p1)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setUploadDataProvider.(Lorg/chromium/net/UploadDataProvider;Ljava/util/concurrent/Executor;)Lorg/chromium/net/UrlRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}
		}

		[Register("org/chromium/net/UrlRequest$Callback", DoNotGenerateAcw = true)]
		public abstract class Callback : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlRequest$Callback", typeof(Callback));

			private static Delegate cb_onCanceled_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_;

			private static Delegate cb_onFailed_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_;

			private static Delegate cb_onReadCompleted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_;

			private static Delegate cb_onRedirectReceived_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_lang_String_;

			private static Delegate cb_onResponseStarted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_;

			private static Delegate cb_onSucceeded_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			protected Callback(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Callback()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetOnCanceled_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Handler()
			{
				if ((object)cb_onCanceled_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_ == null)
				{
					cb_onCanceled_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnCanceled_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_));
				}
				return cb_onCanceled_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_;
			}

			private static void n_OnCanceled_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_request, IntPtr native_info)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				UrlRequest request = Java.Lang.Object.GetObject<UrlRequest>(native_request, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo info = Java.Lang.Object.GetObject<UrlResponseInfo>(native_info, JniHandleOwnership.DoNotTransfer);
				callback.OnCanceled(request, info);
			}

			[Register("onCanceled", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;)V", "GetOnCanceled_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Handler")]
			public unsafe virtual void OnCanceled(UrlRequest request, UrlResponseInfo info)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onCanceled.(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(request);
					GC.KeepAlive(info);
				}
			}

			private static Delegate GetOnFailed_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_Handler()
			{
				if ((object)cb_onFailed_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_ == null)
				{
					cb_onFailed_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnFailed_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_));
				}
				return cb_onFailed_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_;
			}

			private static void n_OnFailed_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				UrlRequest p = Java.Lang.Object.GetObject<UrlRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo p2 = Java.Lang.Object.GetObject<UrlResponseInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
				CronetException p3 = Java.Lang.Object.GetObject<CronetException>(native_p2, JniHandleOwnership.DoNotTransfer);
				callback.OnFailed(p, p2, p3);
			}

			[Register("onFailed", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;Lorg/chromium/net/CronetException;)V", "GetOnFailed_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_Handler")]
			public abstract void OnFailed(UrlRequest p0, UrlResponseInfo p1, CronetException p2);

			private static Delegate GetOnReadCompleted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Handler()
			{
				if ((object)cb_onReadCompleted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_ == null)
				{
					cb_onReadCompleted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnReadCompleted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_));
				}
				return cb_onReadCompleted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_;
			}

			private static void n_OnReadCompleted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				UrlRequest p = Java.Lang.Object.GetObject<UrlRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo p2 = Java.Lang.Object.GetObject<UrlResponseInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
				ByteBuffer p3 = Java.Lang.Object.GetObject<ByteBuffer>(native_p2, JniHandleOwnership.DoNotTransfer);
				callback.OnReadCompleted(p, p2, p3);
			}

			[Register("onReadCompleted", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;Ljava/nio/ByteBuffer;)V", "GetOnReadCompleted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Handler")]
			public abstract void OnReadCompleted(UrlRequest p0, UrlResponseInfo p1, ByteBuffer p2);

			private static Delegate GetOnRedirectReceived_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_lang_String_Handler()
			{
				if ((object)cb_onRedirectReceived_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_lang_String_ == null)
				{
					cb_onRedirectReceived_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnRedirectReceived_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_lang_String_));
				}
				return cb_onRedirectReceived_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_lang_String_;
			}

			private static void n_OnRedirectReceived_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				UrlRequest p = Java.Lang.Object.GetObject<UrlRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo p2 = Java.Lang.Object.GetObject<UrlResponseInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
				string p3 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
				callback.OnRedirectReceived(p, p2, p3);
			}

			[Register("onRedirectReceived", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;Ljava/lang/String;)V", "GetOnRedirectReceived_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_lang_String_Handler")]
			public abstract void OnRedirectReceived(UrlRequest p0, UrlResponseInfo p1, string p2);

			private static Delegate GetOnResponseStarted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Handler()
			{
				if ((object)cb_onResponseStarted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_ == null)
				{
					cb_onResponseStarted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnResponseStarted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_));
				}
				return cb_onResponseStarted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_;
			}

			private static void n_OnResponseStarted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				UrlRequest p = Java.Lang.Object.GetObject<UrlRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo p2 = Java.Lang.Object.GetObject<UrlResponseInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
				callback.OnResponseStarted(p, p2);
			}

			[Register("onResponseStarted", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;)V", "GetOnResponseStarted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Handler")]
			public abstract void OnResponseStarted(UrlRequest p0, UrlResponseInfo p1);

			private static Delegate GetOnSucceeded_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Handler()
			{
				if ((object)cb_onSucceeded_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_ == null)
				{
					cb_onSucceeded_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnSucceeded_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_));
				}
				return cb_onSucceeded_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_;
			}

			private static void n_OnSucceeded_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				UrlRequest p = Java.Lang.Object.GetObject<UrlRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
				UrlResponseInfo p2 = Java.Lang.Object.GetObject<UrlResponseInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
				callback.OnSucceeded(p, p2);
			}

			[Register("onSucceeded", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;)V", "GetOnSucceeded_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Handler")]
			public abstract void OnSucceeded(UrlRequest p0, UrlResponseInfo p1);
		}

		[Register("org/chromium/net/UrlRequest$Callback", DoNotGenerateAcw = true)]
		internal class CallbackInvoker : Callback
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlRequest$Callback", typeof(CallbackInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public CallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("onFailed", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;Lorg/chromium/net/CronetException;)V", "GetOnFailed_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Lorg_chromium_net_CronetException_Handler")]
			public unsafe override void OnFailed(UrlRequest p0, UrlResponseInfo p1, CronetException p2)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onFailed.(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;Lorg/chromium/net/CronetException;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
					GC.KeepAlive(p2);
				}
			}

			[Register("onReadCompleted", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;Ljava/nio/ByteBuffer;)V", "GetOnReadCompleted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_nio_ByteBuffer_Handler")]
			public unsafe override void OnReadCompleted(UrlRequest p0, UrlResponseInfo p1, ByteBuffer p2)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onReadCompleted.(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;Ljava/nio/ByteBuffer;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
					GC.KeepAlive(p2);
				}
			}

			[Register("onRedirectReceived", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;Ljava/lang/String;)V", "GetOnRedirectReceived_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Ljava_lang_String_Handler")]
			public unsafe override void OnRedirectReceived(UrlRequest p0, UrlResponseInfo p1, string p2)
			{
				IntPtr intPtr = JNIEnv.NewString(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onRedirectReceived.(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}

			[Register("onResponseStarted", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;)V", "GetOnResponseStarted_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Handler")]
			public unsafe override void OnResponseStarted(UrlRequest p0, UrlResponseInfo p1)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onResponseStarted.(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}

			[Register("onSucceeded", "(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;)V", "GetOnSucceeded_Lorg_chromium_net_UrlRequest_Lorg_chromium_net_UrlResponseInfo_Handler")]
			public unsafe override void OnSucceeded(UrlRequest p0, UrlResponseInfo p1)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("onSucceeded.(Lorg/chromium/net/UrlRequest;Lorg/chromium/net/UrlResponseInfo;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}
		}

		[Register("org/chromium/net/UrlRequest$Status", DoNotGenerateAcw = true)]
		public class Status : Java.Lang.Object
		{
			[Register("CONNECTING")]
			public const int Connecting = 10;

			[Register("DOWNLOADING_PAC_FILE")]
			public const int DownloadingPacFile = 5;

			[Register("ESTABLISHING_PROXY_TUNNEL")]
			public const int EstablishingProxyTunnel = 8;

			[Register("IDLE")]
			public const int Idle = 0;

			[Register("INVALID")]
			public const int Invalid = -1;

			[Register("READING_RESPONSE")]
			public const int ReadingResponse = 14;

			[Register("RESOLVING_HOST")]
			public const int ResolvingHost = 9;

			[Register("RESOLVING_HOST_IN_PAC_FILE")]
			public const int ResolvingHostInPacFile = 7;

			[Register("RESOLVING_PROXY_FOR_URL")]
			public const int ResolvingProxyForUrl = 6;

			[Register("SENDING_REQUEST")]
			public const int SendingRequest = 12;

			[Register("SSL_HANDSHAKE")]
			public const int SslHandshake = 11;

			[Register("WAITING_FOR_AVAILABLE_SOCKET")]
			public const int WaitingForAvailableSocket = 2;

			[Register("WAITING_FOR_CACHE")]
			public const int WaitingForCache = 4;

			[Register("WAITING_FOR_DELEGATE")]
			public const int WaitingForDelegate = 3;

			[Register("WAITING_FOR_RESPONSE")]
			public const int WaitingForResponse = 13;

			[Register("WAITING_FOR_STALLED_SOCKET_POOL")]
			public const int WaitingForStalledSocketPool = 1;

			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlRequest$Status", typeof(Status));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			protected Status(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("org/chromium/net/UrlRequest$StatusListener", DoNotGenerateAcw = true)]
		public abstract class StatusListener : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlRequest$StatusListener", typeof(StatusListener));

			private static Delegate cb_onStatus_I;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			protected StatusListener(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe StatusListener()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetOnStatus_IHandler()
			{
				if ((object)cb_onStatus_I == null)
				{
					cb_onStatus_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnStatus_I));
				}
				return cb_onStatus_I;
			}

			private static void n_OnStatus_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				Java.Lang.Object.GetObject<StatusListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStatus(p0);
			}

			[Register("onStatus", "(I)V", "GetOnStatus_IHandler")]
			public abstract void OnStatus(int p0);
		}

		[Register("org/chromium/net/UrlRequest$StatusListener", DoNotGenerateAcw = true)]
		internal class StatusListenerInvoker : StatusListener
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlRequest$StatusListener", typeof(StatusListenerInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public StatusListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("onStatus", "(I)V", "GetOnStatus_IHandler")]
			public unsafe override void OnStatus(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onStatus.(I)V", this, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlRequest", typeof(UrlRequest));

		private static Delegate cb_isDone;

		private static Delegate cb_cancel;

		private static Delegate cb_followRedirect;

		private static Delegate cb_getStatus_Lorg_chromium_net_UrlRequest_StatusListener_;

		private static Delegate cb_read_Ljava_nio_ByteBuffer_;

		private static Delegate cb_start;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract bool IsDone
		{
			[Register("isDone", "()Z", "GetIsDoneHandler")]
			get;
		}

		protected UrlRequest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UrlRequest()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsDoneHandler()
		{
			if ((object)cb_isDone == null)
			{
				cb_isDone = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDone));
			}
			return cb_isDone;
		}

		private static bool n_IsDone(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<UrlRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDone;
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
			Java.Lang.Object.GetObject<UrlRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		public abstract void Cancel();

		private static Delegate GetFollowRedirectHandler()
		{
			if ((object)cb_followRedirect == null)
			{
				cb_followRedirect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_FollowRedirect));
			}
			return cb_followRedirect;
		}

		private static void n_FollowRedirect(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<UrlRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FollowRedirect();
		}

		[Register("followRedirect", "()V", "GetFollowRedirectHandler")]
		public abstract void FollowRedirect();

		private static Delegate GetGetStatus_Lorg_chromium_net_UrlRequest_StatusListener_Handler()
		{
			if ((object)cb_getStatus_Lorg_chromium_net_UrlRequest_StatusListener_ == null)
			{
				cb_getStatus_Lorg_chromium_net_UrlRequest_StatusListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_GetStatus_Lorg_chromium_net_UrlRequest_StatusListener_));
			}
			return cb_getStatus_Lorg_chromium_net_UrlRequest_StatusListener_;
		}

		private static void n_GetStatus_Lorg_chromium_net_UrlRequest_StatusListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			UrlRequest urlRequest = Java.Lang.Object.GetObject<UrlRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			StatusListener p = Java.Lang.Object.GetObject<StatusListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			urlRequest.GetStatus(p);
		}

		[Register("getStatus", "(Lorg/chromium/net/UrlRequest$StatusListener;)V", "GetGetStatus_Lorg_chromium_net_UrlRequest_StatusListener_Handler")]
		public abstract void GetStatus(StatusListener p0);

		private static Delegate GetRead_Ljava_nio_ByteBuffer_Handler()
		{
			if ((object)cb_read_Ljava_nio_ByteBuffer_ == null)
			{
				cb_read_Ljava_nio_ByteBuffer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Read_Ljava_nio_ByteBuffer_));
			}
			return cb_read_Ljava_nio_ByteBuffer_;
		}

		private static void n_Read_Ljava_nio_ByteBuffer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			UrlRequest urlRequest = Java.Lang.Object.GetObject<UrlRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteBuffer p = Java.Lang.Object.GetObject<ByteBuffer>(native_p0, JniHandleOwnership.DoNotTransfer);
			urlRequest.Read(p);
		}

		[Register("read", "(Ljava/nio/ByteBuffer;)V", "GetRead_Ljava_nio_ByteBuffer_Handler")]
		public abstract void Read(ByteBuffer p0);

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
			Java.Lang.Object.GetObject<UrlRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Start();
		}

		[Register("start", "()V", "GetStartHandler")]
		public abstract void Start();
	}
	[Register("org/chromium/net/UrlRequest", DoNotGenerateAcw = true)]
	internal class UrlRequestInvoker : UrlRequest
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlRequest", typeof(UrlRequestInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsDone
		{
			[Register("isDone", "()Z", "GetIsDoneHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isDone.()Z", this, null);
			}
		}

		public UrlRequestInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		public unsafe override void Cancel()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("cancel.()V", this, null);
		}

		[Register("followRedirect", "()V", "GetFollowRedirectHandler")]
		public unsafe override void FollowRedirect()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("followRedirect.()V", this, null);
		}

		[Register("getStatus", "(Lorg/chromium/net/UrlRequest$StatusListener;)V", "GetGetStatus_Lorg_chromium_net_UrlRequest_StatusListener_Handler")]
		public unsafe override void GetStatus(StatusListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("getStatus.(Lorg/chromium/net/UrlRequest$StatusListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("read", "(Ljava/nio/ByteBuffer;)V", "GetRead_Ljava_nio_ByteBuffer_Handler")]
		public unsafe override void Read(ByteBuffer p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("read.(Ljava/nio/ByteBuffer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("start", "()V", "GetStartHandler")]
		public unsafe override void Start()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("start.()V", this, null);
		}
	}
	[Register("org/chromium/net/UrlResponseInfo", DoNotGenerateAcw = true)]
	public abstract class UrlResponseInfo : Java.Lang.Object
	{
		[Register("org/chromium/net/UrlResponseInfo$HeaderBlock", DoNotGenerateAcw = true)]
		public abstract class HeaderBlock : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlResponseInfo$HeaderBlock", typeof(HeaderBlock));

			private static Delegate cb_getAsList;

			private static Delegate cb_getAsMap;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public abstract IList<IMapEntry> AsList
			{
				[Register("getAsList", "()Ljava/util/List;", "GetGetAsListHandler")]
				get;
			}

			public abstract IDictionary<string, IList<string>> AsMap
			{
				[Register("getAsMap", "()Ljava/util/Map;", "GetGetAsMapHandler")]
				get;
			}

			protected HeaderBlock(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe HeaderBlock()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetGetAsListHandler()
			{
				if ((object)cb_getAsList == null)
				{
					cb_getAsList = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAsList));
				}
				return cb_getAsList;
			}

			private static IntPtr n_GetAsList(IntPtr jnienv, IntPtr native__this)
			{
				return JavaList<IMapEntry>.ToLocalJniHandle(Java.Lang.Object.GetObject<HeaderBlock>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsList);
			}

			private static Delegate GetGetAsMapHandler()
			{
				if ((object)cb_getAsMap == null)
				{
					cb_getAsMap = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAsMap));
				}
				return cb_getAsMap;
			}

			private static IntPtr n_GetAsMap(IntPtr jnienv, IntPtr native__this)
			{
				return JavaDictionary<string, IList<string>>.ToLocalJniHandle(Java.Lang.Object.GetObject<HeaderBlock>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsMap);
			}
		}

		[Register("org/chromium/net/UrlResponseInfo$HeaderBlock", DoNotGenerateAcw = true)]
		internal class HeaderBlockInvoker : HeaderBlock
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlResponseInfo$HeaderBlock", typeof(HeaderBlockInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe override IList<IMapEntry> AsList
			{
				[Register("getAsList", "()Ljava/util/List;", "GetGetAsListHandler")]
				get
				{
					return JavaList<IMapEntry>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getAsList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe override IDictionary<string, IList<string>> AsMap
			{
				[Register("getAsMap", "()Ljava/util/Map;", "GetGetAsMapHandler")]
				get
				{
					return JavaDictionary<string, IList<string>>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getAsMap.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public HeaderBlockInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlResponseInfo", typeof(UrlResponseInfo));

		private static Delegate cb_getAllHeaders;

		private static Delegate cb_getAllHeadersAsList;

		private static Delegate cb_getHttpStatusCode;

		private static Delegate cb_getHttpStatusText;

		private static Delegate cb_getNegotiatedProtocol;

		private static Delegate cb_getProxyServer;

		private static Delegate cb_getReceivedByteCount;

		private static Delegate cb_getUrl;

		private static Delegate cb_getUrlChain;

		private static Delegate cb_wasCached;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract IDictionary<string, IList<string>> AllHeaders
		{
			[Register("getAllHeaders", "()Ljava/util/Map;", "GetGetAllHeadersHandler")]
			get;
		}

		public abstract IList<IMapEntry> AllHeadersAsList
		{
			[Register("getAllHeadersAsList", "()Ljava/util/List;", "GetGetAllHeadersAsListHandler")]
			get;
		}

		public abstract int HttpStatusCode
		{
			[Register("getHttpStatusCode", "()I", "GetGetHttpStatusCodeHandler")]
			get;
		}

		public abstract string HttpStatusText
		{
			[Register("getHttpStatusText", "()Ljava/lang/String;", "GetGetHttpStatusTextHandler")]
			get;
		}

		public abstract string NegotiatedProtocol
		{
			[Register("getNegotiatedProtocol", "()Ljava/lang/String;", "GetGetNegotiatedProtocolHandler")]
			get;
		}

		public abstract string ProxyServer
		{
			[Register("getProxyServer", "()Ljava/lang/String;", "GetGetProxyServerHandler")]
			get;
		}

		public abstract long ReceivedByteCount
		{
			[Register("getReceivedByteCount", "()J", "GetGetReceivedByteCountHandler")]
			get;
		}

		public abstract string Url
		{
			[Register("getUrl", "()Ljava/lang/String;", "GetGetUrlHandler")]
			get;
		}

		public abstract IList<string> UrlChain
		{
			[Register("getUrlChain", "()Ljava/util/List;", "GetGetUrlChainHandler")]
			get;
		}

		protected UrlResponseInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UrlResponseInfo()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetAllHeadersHandler()
		{
			if ((object)cb_getAllHeaders == null)
			{
				cb_getAllHeaders = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAllHeaders));
			}
			return cb_getAllHeaders;
		}

		private static IntPtr n_GetAllHeaders(IntPtr jnienv, IntPtr native__this)
		{
			return JavaDictionary<string, IList<string>>.ToLocalJniHandle(Java.Lang.Object.GetObject<UrlResponseInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllHeaders);
		}

		private static Delegate GetGetAllHeadersAsListHandler()
		{
			if ((object)cb_getAllHeadersAsList == null)
			{
				cb_getAllHeadersAsList = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAllHeadersAsList));
			}
			return cb_getAllHeadersAsList;
		}

		private static IntPtr n_GetAllHeadersAsList(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<IMapEntry>.ToLocalJniHandle(Java.Lang.Object.GetObject<UrlResponseInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllHeadersAsList);
		}

		private static Delegate GetGetHttpStatusCodeHandler()
		{
			if ((object)cb_getHttpStatusCode == null)
			{
				cb_getHttpStatusCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHttpStatusCode));
			}
			return cb_getHttpStatusCode;
		}

		private static int n_GetHttpStatusCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<UrlResponseInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HttpStatusCode;
		}

		private static Delegate GetGetHttpStatusTextHandler()
		{
			if ((object)cb_getHttpStatusText == null)
			{
				cb_getHttpStatusText = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHttpStatusText));
			}
			return cb_getHttpStatusText;
		}

		private static IntPtr n_GetHttpStatusText(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<UrlResponseInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HttpStatusText);
		}

		private static Delegate GetGetNegotiatedProtocolHandler()
		{
			if ((object)cb_getNegotiatedProtocol == null)
			{
				cb_getNegotiatedProtocol = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNegotiatedProtocol));
			}
			return cb_getNegotiatedProtocol;
		}

		private static IntPtr n_GetNegotiatedProtocol(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<UrlResponseInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NegotiatedProtocol);
		}

		private static Delegate GetGetProxyServerHandler()
		{
			if ((object)cb_getProxyServer == null)
			{
				cb_getProxyServer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetProxyServer));
			}
			return cb_getProxyServer;
		}

		private static IntPtr n_GetProxyServer(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<UrlResponseInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProxyServer);
		}

		private static Delegate GetGetReceivedByteCountHandler()
		{
			if ((object)cb_getReceivedByteCount == null)
			{
				cb_getReceivedByteCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetReceivedByteCount));
			}
			return cb_getReceivedByteCount;
		}

		private static long n_GetReceivedByteCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<UrlResponseInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReceivedByteCount;
		}

		private static Delegate GetGetUrlHandler()
		{
			if ((object)cb_getUrl == null)
			{
				cb_getUrl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUrl));
			}
			return cb_getUrl;
		}

		private static IntPtr n_GetUrl(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<UrlResponseInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Url);
		}

		private static Delegate GetGetUrlChainHandler()
		{
			if ((object)cb_getUrlChain == null)
			{
				cb_getUrlChain = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUrlChain));
			}
			return cb_getUrlChain;
		}

		private static IntPtr n_GetUrlChain(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<UrlResponseInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UrlChain);
		}

		private static Delegate GetWasCachedHandler()
		{
			if ((object)cb_wasCached == null)
			{
				cb_wasCached = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_WasCached));
			}
			return cb_wasCached;
		}

		private static bool n_WasCached(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<UrlResponseInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WasCached();
		}

		[Register("wasCached", "()Z", "GetWasCachedHandler")]
		public abstract bool WasCached();
	}
	[Register("org/chromium/net/UrlResponseInfo", DoNotGenerateAcw = true)]
	internal class UrlResponseInfoInvoker : UrlResponseInfo
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("org/chromium/net/UrlResponseInfo", typeof(UrlResponseInfoInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override IDictionary<string, IList<string>> AllHeaders
		{
			[Register("getAllHeaders", "()Ljava/util/Map;", "GetGetAllHeadersHandler")]
			get
			{
				return JavaDictionary<string, IList<string>>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getAllHeaders.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override IList<IMapEntry> AllHeadersAsList
		{
			[Register("getAllHeadersAsList", "()Ljava/util/List;", "GetGetAllHeadersAsListHandler")]
			get
			{
				return JavaList<IMapEntry>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getAllHeadersAsList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override int HttpStatusCode
		{
			[Register("getHttpStatusCode", "()I", "GetGetHttpStatusCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getHttpStatusCode.()I", this, null);
			}
		}

		public unsafe override string HttpStatusText
		{
			[Register("getHttpStatusText", "()Ljava/lang/String;", "GetGetHttpStatusTextHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getHttpStatusText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string NegotiatedProtocol
		{
			[Register("getNegotiatedProtocol", "()Ljava/lang/String;", "GetGetNegotiatedProtocolHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getNegotiatedProtocol.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string ProxyServer
		{
			[Register("getProxyServer", "()Ljava/lang/String;", "GetGetProxyServerHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getProxyServer.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override long ReceivedByteCount
		{
			[Register("getReceivedByteCount", "()J", "GetGetReceivedByteCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getReceivedByteCount.()J", this, null);
			}
		}

		public unsafe override string Url
		{
			[Register("getUrl", "()Ljava/lang/String;", "GetGetUrlHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override IList<string> UrlChain
		{
			[Register("getUrlChain", "()Ljava/util/List;", "GetGetUrlChainHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getUrlChain.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public UrlResponseInfoInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("wasCached", "()Z", "GetWasCachedHandler")]
		public unsafe override bool WasCached()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("wasCached.()Z", this, null);
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_org_chromium_net_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "org/chromium/net" }, new Converter<string, Type>[1] { lookup_org_chromium_net_package });
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

		private static Type lookup_org_chromium_net_package(string klass)
		{
			if (package_org_chromium_net_mappings == null)
			{
				package_org_chromium_net_mappings = new string[35]
				{
					"org/chromium/net/ApiVersion:Xamarin.Chromium.CroNet.ApiVersion", "org/chromium/net/BidirectionalStream:Xamarin.Chromium.CroNet.BidirectionalStream", "org/chromium/net/BidirectionalStream$Builder:Xamarin.Chromium.CroNet.BidirectionalStream/Builder", "org/chromium/net/BidirectionalStream$Callback:Xamarin.Chromium.CroNet.BidirectionalStream/Callback", "org/chromium/net/CallbackException:Xamarin.Chromium.CroNet.CallbackException", "org/chromium/net/CronetEngine:Xamarin.Chromium.CroNet.CronetEngine", "org/chromium/net/CronetEngine$Builder:Xamarin.Chromium.CroNet.CronetEngine/Builder", "org/chromium/net/CronetEngine$Builder$LibraryLoader:Xamarin.Chromium.CroNet.CronetEngine/Builder/LibraryLoader", "org/chromium/net/CronetException:Xamarin.Chromium.CroNet.CronetException", "org/chromium/net/CronetProvider:Xamarin.Chromium.CroNet.CronetProvider",
					"org/chromium/net/ExperimentalBidirectionalStream:Xamarin.Chromium.CroNet.ExperimentalBidirectionalStream", "org/chromium/net/ExperimentalBidirectionalStream$Builder:Xamarin.Chromium.CroNet.ExperimentalBidirectionalStream/Builder", "org/chromium/net/ExperimentalCronetEngine:Xamarin.Chromium.CroNet.ExperimentalCronetEngine", "org/chromium/net/ExperimentalCronetEngine$Builder:Xamarin.Chromium.CroNet.ExperimentalCronetEngine/Builder", "org/chromium/net/ExperimentalUrlRequest:Xamarin.Chromium.CroNet.ExperimentalUrlRequest", "org/chromium/net/ExperimentalUrlRequest$Builder:Xamarin.Chromium.CroNet.ExperimentalUrlRequest/Builder", "org/chromium/net/ICronetEngineBuilder:Xamarin.Chromium.CroNet.ICronetEngineBuilder", "org/chromium/net/InlineExecutionProhibitedException:Xamarin.Chromium.CroNet.InlineExecutionProhibitedException", "org/chromium/net/NetworkException:Xamarin.Chromium.CroNet.NetworkException", "org/chromium/net/NetworkQualityRttListener:Xamarin.Chromium.CroNet.NetworkQualityRttListener",
					"org/chromium/net/NetworkQualityThroughputListener:Xamarin.Chromium.CroNet.NetworkQualityThroughputListener", "org/chromium/net/QuicException:Xamarin.Chromium.CroNet.QuicException", "org/chromium/net/RequestFinishedInfo:Xamarin.Chromium.CroNet.RequestFinishedInfo", "org/chromium/net/RequestFinishedInfo$Listener:Xamarin.Chromium.CroNet.RequestFinishedInfo/Listener", "org/chromium/net/RequestFinishedInfo$Metrics:Xamarin.Chromium.CroNet.RequestFinishedInfo/Metrics", "org/chromium/net/UploadDataProvider:Xamarin.Chromium.CroNet.UploadDataProvider", "org/chromium/net/UploadDataProviders:Xamarin.Chromium.CroNet.UploadDataProviders", "org/chromium/net/UploadDataSink:Xamarin.Chromium.CroNet.UploadDataSink", "org/chromium/net/UrlRequest:Xamarin.Chromium.CroNet.UrlRequest", "org/chromium/net/UrlRequest$Builder:Xamarin.Chromium.CroNet.UrlRequest/Builder",
					"org/chromium/net/UrlRequest$Callback:Xamarin.Chromium.CroNet.UrlRequest/Callback", "org/chromium/net/UrlRequest$Status:Xamarin.Chromium.CroNet.UrlRequest/Status", "org/chromium/net/UrlRequest$StatusListener:Xamarin.Chromium.CroNet.UrlRequest/StatusListener", "org/chromium/net/UrlResponseInfo:Xamarin.Chromium.CroNet.UrlResponseInfo", "org/chromium/net/UrlResponseInfo$HeaderBlock:Xamarin.Chromium.CroNet.UrlResponseInfo/HeaderBlock"
				};
			}
			return Lookup(package_org_chromium_net_mappings, klass);
		}
	}
}
