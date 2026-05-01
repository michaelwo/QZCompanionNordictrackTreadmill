using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Net;
using Java.Nio.Charset;
using Java.Security;
using Java.Security.Cert;
using Java.Util;
using Java.Util.Concurrent;
using Javax.Net;
using Javax.Net.Ssl;
using Square.OkIO;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "okhttp3", Managed = "Square.OkHttp3")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("An HTTP+HTTP/2 client for Android and Java applications.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Square.OkHttp3")]
[assembly: AssemblyTitle("Square.OkHttp3")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/XamarinComponents")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPIL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate bool _JniMarshal_PPIL_Z(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPJ_L(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate void _JniMarshal_PPLJ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, long p1);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate void _JniMarshal_PPLLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4);
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
		private static string[] package_okhttp3_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "okhttp3" }, new Converter<string, Type>[1] { lookup_okhttp3_package });
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

		private static Type lookup_okhttp3_package(string klass)
		{
			if (package_okhttp3_mappings == null)
			{
				package_okhttp3_mappings = new string[43]
				{
					"okhttp3/Address:Square.OkHttp3.Address", "okhttp3/Cache:Square.OkHttp3.Cache", "okhttp3/CacheControl:Square.OkHttp3.CacheControl", "okhttp3/CacheControl$Builder:Square.OkHttp3.CacheControl/Builder", "okhttp3/CertificatePinner:Square.OkHttp3.CertificatePinner", "okhttp3/CertificatePinner$Builder:Square.OkHttp3.CertificatePinner/Builder", "okhttp3/CertificatePinner$Pin:Square.OkHttp3.CertificatePinner/Pin", "okhttp3/Challenge:Square.OkHttp3.Challenge", "okhttp3/CipherSuite:Square.OkHttp3.CipherSuite", "okhttp3/ConnectionPool:Square.OkHttp3.ConnectionPool",
					"okhttp3/ConnectionSpec:Square.OkHttp3.ConnectionSpec", "okhttp3/ConnectionSpec$Builder:Square.OkHttp3.ConnectionSpec/Builder", "okhttp3/Cookie:Square.OkHttp3.Cookie", "okhttp3/Cookie$Builder:Square.OkHttp3.Cookie/Builder", "okhttp3/Credentials:Square.OkHttp3.Credentials", "okhttp3/Dispatcher:Square.OkHttp3.Dispatcher", "okhttp3/EventListener:Square.OkHttp3.EventListener", "okhttp3/FormBody:Square.OkHttp3.FormBody", "okhttp3/FormBody$Builder:Square.OkHttp3.FormBody/Builder", "okhttp3/Handshake:Square.OkHttp3.Handshake",
					"okhttp3/Headers:Square.OkHttp3.Headers", "okhttp3/Headers$Builder:Square.OkHttp3.Headers/Builder", "okhttp3/HttpUrl:Square.OkHttp3.HttpUrl", "okhttp3/HttpUrl$Builder:Square.OkHttp3.HttpUrl/Builder", "okhttp3/MediaType:Square.OkHttp3.MediaType", "okhttp3/MultipartBody:Square.OkHttp3.MultipartBody", "okhttp3/MultipartBody$Builder:Square.OkHttp3.MultipartBody/Builder", "okhttp3/MultipartBody$Part:Square.OkHttp3.MultipartBody/Part", "okhttp3/MultipartReader:Square.OkHttp3.MultipartReader", "okhttp3/MultipartReader$Part:Square.OkHttp3.MultipartReader/Part",
					"okhttp3/OkHttp:Square.OkHttp3.OkHttp", "okhttp3/OkHttpClient:Square.OkHttp3.OkHttpClient", "okhttp3/OkHttpClient$Builder:Square.OkHttp3.OkHttpClient/Builder", "okhttp3/Protocol:Square.OkHttp3.Protocol", "okhttp3/Request:Square.OkHttp3.Request", "okhttp3/Request$Builder:Square.OkHttp3.Request/Builder", "okhttp3/RequestBody:Square.OkHttp3.RequestBody", "okhttp3/Response:Square.OkHttp3.Response", "okhttp3/Response$Builder:Square.OkHttp3.Response/Builder", "okhttp3/ResponseBody:Square.OkHttp3.ResponseBody",
					"okhttp3/Route:Square.OkHttp3.Route", "okhttp3/TlsVersion:Square.OkHttp3.TlsVersion", "okhttp3/WebSocketListener:Square.OkHttp3.WebSocketListener"
				};
			}
			return Lookup(package_okhttp3_mappings, klass);
		}
	}
}
namespace Square.OkHttp3
{
	public static class CallExtensions
	{
		private class ActionCallback : Java.Lang.Object, ICallback, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly Action<ICall, Response> onResponse;

			private readonly Action<ICall, Java.IO.IOException> onFailure;

			public ActionCallback(Action<ICall, Response> onResponse, Action<ICall, Java.IO.IOException> onFailure)
			{
				this.onResponse = onResponse;
				this.onFailure = onFailure;
			}

			public void OnResponse(ICall call, Response response)
			{
				if (onResponse != null)
				{
					onResponse(call, response);
				}
			}

			public void OnFailure(ICall call, Java.IO.IOException exception)
			{
				if (onFailure != null)
				{
					onFailure(call, exception);
				}
			}
		}

		public static Task<Response> ExecuteAsync(this ICall call)
		{
			TaskCompletionSource<Response> tcs = new TaskCompletionSource<Response>();
			call.Enqueue(delegate(ICall c, Response response)
			{
				tcs.SetResult(response);
			}, delegate(ICall c, Java.IO.IOException exception)
			{
				if (call.IsCanceled)
				{
					tcs.SetCanceled();
				}
				else
				{
					tcs.SetException(exception);
				}
			});
			return tcs.Task;
		}

		public static void Enqueue(this ICall call, Action<ICall, Response> onResponse, Action<ICall, Java.IO.IOException> onFailure)
		{
			call.Enqueue(new ActionCallback(onResponse, onFailure));
		}
	}
	[Register("okhttp3/Dispatcher", DoNotGenerateAcw = true)]
	public sealed class Dispatcher : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Dispatcher", typeof(Dispatcher));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe IRunnable IdleCallback
		{
			[Register("getIdleCallback", "()Ljava/lang/Runnable;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IRunnable>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getIdleCallback.()Ljava/lang/Runnable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setIdleCallback", "(Ljava/lang/Runnable;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setIdleCallback.(Ljava/lang/Runnable;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe int MaxRequests
		{
			[Register("getMaxRequests", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getMaxRequests.()I", this, null);
			}
			[Register("setMaxRequests", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMaxRequests.(I)V", this, ptr);
			}
		}

		public unsafe int MaxRequestsPerHost
		{
			[Register("getMaxRequestsPerHost", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getMaxRequestsPerHost.()I", this, null);
			}
			[Register("setMaxRequestsPerHost", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMaxRequestsPerHost.(I)V", this, ptr);
			}
		}

		public void SetIdleCallback(IRunnable idleCallback)
		{
			IdleCallback = idleCallback;
		}

		internal Dispatcher(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Dispatcher()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/util/concurrent/ExecutorService;)V", "")]
		public unsafe Dispatcher(IExecutorService executorService)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((executorService == null) ? IntPtr.Zero : ((Java.Lang.Object)executorService).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/concurrent/ExecutorService;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/concurrent/ExecutorService;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(executorService);
			}
		}

		[Register("cancelAll", "()V", "")]
		public unsafe void CancelAll()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("cancelAll.()V", this, null);
		}

		[Register("executorService", "()Ljava/util/concurrent/ExecutorService;", "")]
		public unsafe IExecutorService ExecutorService()
		{
			return Java.Lang.Object.GetObject<IExecutorService>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("executorService.()Ljava/util/concurrent/ExecutorService;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("queuedCalls", "()Ljava/util/List;", "")]
		public unsafe IList<ICall> QueuedCalls()
		{
			return JavaList<ICall>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("queuedCalls.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("queuedCallsCount", "()I", "")]
		public unsafe int QueuedCallsCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("queuedCallsCount.()I", this, null);
		}

		[Register("runningCalls", "()Ljava/util/List;", "")]
		public unsafe IList<ICall> RunningCalls()
		{
			return JavaList<ICall>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("runningCalls.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("runningCallsCount", "()I", "")]
		public unsafe int RunningCallsCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("runningCallsCount.()I", this, null);
		}
	}
	[Register("okhttp3/OkHttpClient", DoNotGenerateAcw = true)]
	public class OkHttpClient : Java.Lang.Object, Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable, ICallFactory, IWebSocketFactory
	{
		[Register("okhttp3/OkHttpClient$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private class AuthenticatorImpl : Java.Lang.Object, IAuthenticator, IJavaObject, IDisposable, IJavaPeerable
			{
				private readonly Func<Route, Response, Request> authenticate;

				public AuthenticatorImpl(Func<Route, Response, Request> authenticate)
				{
					this.authenticate = authenticate;
				}

				public Request Authenticate(Route p0, Response p1)
				{
					return authenticate(p0, p1);
				}
			}

			private class InterceptorImpl : Java.Lang.Object, IInterceptor, IJavaObject, IDisposable, IJavaPeerable
			{
				private readonly Func<IInterceptorChain, Response> interceptor;

				public InterceptorImpl(Func<IInterceptorChain, Response> interceptor)
				{
					this.interceptor = interceptor;
				}

				public Response Intercept(IInterceptorChain p0)
				{
					return interceptor(p0);
				}
			}

			private class DnsImpl : Java.Lang.Object, IDns, IJavaObject, IDisposable, IJavaPeerable
			{
				private readonly Func<string, IList<InetAddress>> lookup;

				public DnsImpl(Func<string, IList<InetAddress>> lookup)
				{
					this.lookup = lookup;
				}

				public IList<InetAddress> Lookup(string p0)
				{
					return lookup(p0);
				}
			}

			private class HostnameVerifierImpl : Java.Lang.Object, IHostnameVerifier, IJavaObject, IDisposable, IJavaPeerable
			{
				private readonly Func<string, ISSLSession, bool> verify;

				public HostnameVerifierImpl(Func<string, ISSLSession, bool> verify)
				{
					this.verify = verify;
				}

				public bool Verify(string hostname, ISSLSession session)
				{
					return verify(hostname, session);
				}
			}

			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/OkHttpClient$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public Builder AddInterceptor(Func<IInterceptorChain, Response> interceptor)
			{
				return AddInterceptor(new InterceptorImpl(interceptor));
			}

			public Builder AddNetworkInterceptor(Func<IInterceptorChain, Response> interceptor)
			{
				return AddNetworkInterceptor(new InterceptorImpl(interceptor));
			}

			public Builder Authenticator(Func<Route, Response, Request> authenticate)
			{
				return Authenticator(new AuthenticatorImpl(authenticate));
			}

			public Builder ProxyAuthenticator(Func<Route, Response, Request> authenticate)
			{
				return ProxyAuthenticator(new AuthenticatorImpl(authenticate));
			}

			public Builder Dns(Func<string, IList<InetAddress>> lookup)
			{
				return Dns(new DnsImpl(lookup));
			}

			public Builder HostnameVerifier(Func<string, ISSLSession, bool> verify)
			{
				return HostnameVerifier(new HostnameVerifierImpl(verify));
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

			[Register("addInterceptor", "(Lokhttp3/Interceptor;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder AddInterceptor(IInterceptor interceptor)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((interceptor == null) ? IntPtr.Zero : ((Java.Lang.Object)interceptor).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addInterceptor.(Lokhttp3/Interceptor;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(interceptor);
				}
			}

			[Register("addNetworkInterceptor", "(Lokhttp3/Interceptor;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder AddNetworkInterceptor(IInterceptor interceptor)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((interceptor == null) ? IntPtr.Zero : ((Java.Lang.Object)interceptor).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addNetworkInterceptor.(Lokhttp3/Interceptor;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(interceptor);
				}
			}

			[Register("authenticator", "(Lokhttp3/Authenticator;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder Authenticator(IAuthenticator authenticator)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((authenticator == null) ? IntPtr.Zero : ((Java.Lang.Object)authenticator).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("authenticator.(Lokhttp3/Authenticator;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(authenticator);
				}
			}

			[Register("build", "()Lokhttp3/OkHttpClient;", "")]
			public unsafe OkHttpClient Build()
			{
				return Java.Lang.Object.GetObject<OkHttpClient>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lokhttp3/OkHttpClient;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("cache", "(Lokhttp3/Cache;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder Cache(Cache cache)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(cache?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cache.(Lokhttp3/Cache;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(cache);
				}
			}

			[Register("callTimeout", "(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder CallTimeout(long timeout, TimeUnit unit)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(timeout);
					ptr[1] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("callTimeout.(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(unit);
				}
			}

			[Register("certificatePinner", "(Lokhttp3/CertificatePinner;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder CertificatePinner(CertificatePinner certificatePinner)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(certificatePinner?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("certificatePinner.(Lokhttp3/CertificatePinner;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(certificatePinner);
				}
			}

			[Register("connectTimeout", "(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder ConnectTimeout(long timeout, TimeUnit unit)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(timeout);
					ptr[1] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("connectTimeout.(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(unit);
				}
			}

			[Register("connectionPool", "(Lokhttp3/ConnectionPool;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder ConnectionPool(ConnectionPool connectionPool)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(connectionPool?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("connectionPool.(Lokhttp3/ConnectionPool;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(connectionPool);
				}
			}

			[Register("connectionSpecs", "(Ljava/util/List;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder ConnectionSpecs(IList<ConnectionSpec> connectionSpecs)
			{
				IntPtr intPtr = JavaList<ConnectionSpec>.ToLocalJniHandle(connectionSpecs);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("connectionSpecs.(Ljava/util/List;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(connectionSpecs);
				}
			}

			[Register("cookieJar", "(Lokhttp3/CookieJar;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder CookieJar(ICookieJar cookieJar)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((cookieJar == null) ? IntPtr.Zero : ((Java.Lang.Object)cookieJar).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cookieJar.(Lokhttp3/CookieJar;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(cookieJar);
				}
			}

			[Register("dispatcher", "(Lokhttp3/Dispatcher;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder Dispatcher(Dispatcher dispatcher)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(dispatcher?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("dispatcher.(Lokhttp3/Dispatcher;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(dispatcher);
				}
			}

			[Register("dns", "(Lokhttp3/Dns;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder Dns(IDns dns)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((dns == null) ? IntPtr.Zero : ((Java.Lang.Object)dns).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("dns.(Lokhttp3/Dns;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(dns);
				}
			}

			[Register("eventListener", "(Lokhttp3/EventListener;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder EventListener(EventListener eventListener)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(eventListener?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("eventListener.(Lokhttp3/EventListener;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(eventListener);
				}
			}

			[Register("eventListenerFactory", "(Lokhttp3/EventListener$Factory;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder EventListenerFactory(EventListener.IFactory eventListenerFactory)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((eventListenerFactory == null) ? IntPtr.Zero : ((Java.Lang.Object)eventListenerFactory).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("eventListenerFactory.(Lokhttp3/EventListener$Factory;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(eventListenerFactory);
				}
			}

			[Register("followRedirects", "(Z)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder FollowRedirects(bool followRedirects)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(followRedirects);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("followRedirects.(Z)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("followSslRedirects", "(Z)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder FollowSslRedirects(bool followProtocolRedirects)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(followProtocolRedirects);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("followSslRedirects.(Z)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("hostnameVerifier", "(Ljavax/net/ssl/HostnameVerifier;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder HostnameVerifier(IHostnameVerifier hostnameVerifier)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((hostnameVerifier == null) ? IntPtr.Zero : ((Java.Lang.Object)hostnameVerifier).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hostnameVerifier.(Ljavax/net/ssl/HostnameVerifier;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(hostnameVerifier);
				}
			}

			[Register("interceptors", "()Ljava/util/List;", "")]
			public unsafe IList<IInterceptor> Interceptors()
			{
				return JavaList<IInterceptor>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("interceptors.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("minWebSocketMessageToCompress", "(J)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder MinWebSocketMessageToCompress(long bytes)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bytes);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("minWebSocketMessageToCompress.(J)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("networkInterceptors", "()Ljava/util/List;", "")]
			public unsafe IList<IInterceptor> NetworkInterceptors()
			{
				return JavaList<IInterceptor>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("networkInterceptors.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("pingInterval", "(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder PingInterval(long interval, TimeUnit unit)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(interval);
					ptr[1] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("pingInterval.(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(unit);
				}
			}

			[Register("protocols", "(Ljava/util/List;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder Protocols(IList<Protocol> protocols)
			{
				IntPtr intPtr = JavaList<Protocol>.ToLocalJniHandle(protocols);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("protocols.(Ljava/util/List;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(protocols);
				}
			}

			[Register("proxy", "(Ljava/net/Proxy;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder Proxy(Proxy proxy)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(proxy?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("proxy.(Ljava/net/Proxy;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(proxy);
				}
			}

			[Register("proxyAuthenticator", "(Lokhttp3/Authenticator;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder ProxyAuthenticator(IAuthenticator proxyAuthenticator)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((proxyAuthenticator == null) ? IntPtr.Zero : ((Java.Lang.Object)proxyAuthenticator).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("proxyAuthenticator.(Lokhttp3/Authenticator;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(proxyAuthenticator);
				}
			}

			[Register("proxySelector", "(Ljava/net/ProxySelector;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder ProxySelector(ProxySelector proxySelector)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(proxySelector?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("proxySelector.(Ljava/net/ProxySelector;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(proxySelector);
				}
			}

			[Register("readTimeout", "(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder ReadTimeout(long timeout, TimeUnit unit)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(timeout);
					ptr[1] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("readTimeout.(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(unit);
				}
			}

			[Register("retryOnConnectionFailure", "(Z)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder RetryOnConnectionFailure(bool retryOnConnectionFailure)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(retryOnConnectionFailure);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("retryOnConnectionFailure.(Z)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("socketFactory", "(Ljavax/net/SocketFactory;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder SocketFactory(SocketFactory socketFactory)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(socketFactory?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("socketFactory.(Ljavax/net/SocketFactory;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(socketFactory);
				}
			}

			[Obsolete("deprecated")]
			[Register("sslSocketFactory", "(Ljavax/net/ssl/SSLSocketFactory;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder SslSocketFactory(SSLSocketFactory sslSocketFactory)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(sslSocketFactory?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sslSocketFactory.(Ljavax/net/ssl/SSLSocketFactory;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(sslSocketFactory);
				}
			}

			[Register("sslSocketFactory", "(Ljavax/net/ssl/SSLSocketFactory;Ljavax/net/ssl/X509TrustManager;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder SslSocketFactory(SSLSocketFactory sslSocketFactory, IX509TrustManager trustManager)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(sslSocketFactory?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue((trustManager == null) ? IntPtr.Zero : ((Java.Lang.Object)trustManager).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sslSocketFactory.(Ljavax/net/ssl/SSLSocketFactory;Ljavax/net/ssl/X509TrustManager;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(sslSocketFactory);
					GC.KeepAlive(trustManager);
				}
			}

			[Register("writeTimeout", "(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;", "")]
			public unsafe Builder WriteTimeout(long timeout, TimeUnit unit)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(timeout);
					ptr[1] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("writeTimeout.(JLjava/util/concurrent/TimeUnit;)Lokhttp3/OkHttpClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(unit);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/OkHttpClient", typeof(OkHttpClient));

		private static Delegate cb_clone;

		private static Delegate cb_newBuilder;

		private static Delegate cb_newCall_Lokhttp3_Request_;

		private static Delegate cb_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OkHttpClient(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OkHttpClient()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("authenticator", "()Lokhttp3/Authenticator;", "")]
		public unsafe IAuthenticator Authenticator()
		{
			return Java.Lang.Object.GetObject<IAuthenticator>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("authenticator.()Lokhttp3/Authenticator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("cache", "()Lokhttp3/Cache;", "")]
		public unsafe Cache Cache()
		{
			return Java.Lang.Object.GetObject<Cache>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cache.()Lokhttp3/Cache;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("callTimeoutMillis", "()I", "")]
		public unsafe int CallTimeoutMillis()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("callTimeoutMillis.()I", this, null);
		}

		[Register("certificatePinner", "()Lokhttp3/CertificatePinner;", "")]
		public unsafe CertificatePinner CertificatePinner()
		{
			return Java.Lang.Object.GetObject<CertificatePinner>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("certificatePinner.()Lokhttp3/CertificatePinner;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetCloneHandler()
		{
			if ((object)cb_clone == null)
			{
				cb_clone = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Clone));
			}
			return cb_clone;
		}

		private static IntPtr n_Clone(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OkHttpClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
		}

		[Register("clone", "()Ljava/lang/Object;", "GetCloneHandler")]
		public new unsafe virtual Java.Lang.Object Clone()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("connectTimeoutMillis", "()I", "")]
		public unsafe int ConnectTimeoutMillis()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("connectTimeoutMillis.()I", this, null);
		}

		[Register("connectionPool", "()Lokhttp3/ConnectionPool;", "")]
		public unsafe ConnectionPool ConnectionPool()
		{
			return Java.Lang.Object.GetObject<ConnectionPool>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("connectionPool.()Lokhttp3/ConnectionPool;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("connectionSpecs", "()Ljava/util/List;", "")]
		public unsafe IList<ConnectionSpec> ConnectionSpecs()
		{
			return JavaList<ConnectionSpec>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("connectionSpecs.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("cookieJar", "()Lokhttp3/CookieJar;", "")]
		public unsafe ICookieJar CookieJar()
		{
			return Java.Lang.Object.GetObject<ICookieJar>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cookieJar.()Lokhttp3/CookieJar;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("dispatcher", "()Lokhttp3/Dispatcher;", "")]
		public unsafe Dispatcher Dispatcher()
		{
			return Java.Lang.Object.GetObject<Dispatcher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("dispatcher.()Lokhttp3/Dispatcher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("dns", "()Lokhttp3/Dns;", "")]
		public unsafe IDns Dns()
		{
			return Java.Lang.Object.GetObject<IDns>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("dns.()Lokhttp3/Dns;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("eventListenerFactory", "()Lokhttp3/EventListener$Factory;", "")]
		public unsafe EventListener.IFactory EventListenerFactory()
		{
			return Java.Lang.Object.GetObject<EventListener.IFactory>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("eventListenerFactory.()Lokhttp3/EventListener$Factory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("followRedirects", "()Z", "")]
		public unsafe bool FollowRedirects()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("followRedirects.()Z", this, null);
		}

		[Register("followSslRedirects", "()Z", "")]
		public unsafe bool FollowSslRedirects()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("followSslRedirects.()Z", this, null);
		}

		[Register("hostnameVerifier", "()Ljavax/net/ssl/HostnameVerifier;", "")]
		public unsafe IHostnameVerifier HostnameVerifier()
		{
			return Java.Lang.Object.GetObject<IHostnameVerifier>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hostnameVerifier.()Ljavax/net/ssl/HostnameVerifier;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("interceptors", "()Ljava/util/List;", "")]
		public unsafe IList<IInterceptor> Interceptors()
		{
			return JavaList<IInterceptor>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("interceptors.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("minWebSocketMessageToCompress", "()J", "")]
		public unsafe long MinWebSocketMessageToCompress()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt64Method("minWebSocketMessageToCompress.()J", this, null);
		}

		[Register("networkInterceptors", "()Ljava/util/List;", "")]
		public unsafe IList<IInterceptor> NetworkInterceptors()
		{
			return JavaList<IInterceptor>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("networkInterceptors.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetNewBuilderHandler()
		{
			if ((object)cb_newBuilder == null)
			{
				cb_newBuilder = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_NewBuilder));
			}
			return cb_newBuilder;
		}

		private static IntPtr n_NewBuilder(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OkHttpClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewBuilder());
		}

		[Register("newBuilder", "()Lokhttp3/OkHttpClient$Builder;", "GetNewBuilderHandler")]
		public unsafe virtual Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("newBuilder.()Lokhttp3/OkHttpClient$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetNewCall_Lokhttp3_Request_Handler()
		{
			if ((object)cb_newCall_Lokhttp3_Request_ == null)
			{
				cb_newCall_Lokhttp3_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_NewCall_Lokhttp3_Request_));
			}
			return cb_newCall_Lokhttp3_Request_;
		}

		private static IntPtr n_NewCall_Lokhttp3_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
		{
			OkHttpClient okHttpClient = Java.Lang.Object.GetObject<OkHttpClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Request request = Java.Lang.Object.GetObject<Request>(native_request, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(okHttpClient.NewCall(request));
		}

		[Register("newCall", "(Lokhttp3/Request;)Lokhttp3/Call;", "GetNewCall_Lokhttp3_Request_Handler")]
		public unsafe virtual ICall NewCall(Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ICall>(_members.InstanceMethods.InvokeVirtualObjectMethod("newCall.(Lokhttp3/Request;)Lokhttp3/Call;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(request);
			}
		}

		private static Delegate GetNewWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_Handler()
		{
			if ((object)cb_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_ == null)
			{
				cb_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_NewWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_));
			}
			return cb_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_;
		}

		private static IntPtr n_NewWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_request, IntPtr native_listener)
		{
			OkHttpClient okHttpClient = Java.Lang.Object.GetObject<OkHttpClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Request request = Java.Lang.Object.GetObject<Request>(native_request, JniHandleOwnership.DoNotTransfer);
			WebSocketListener listener = Java.Lang.Object.GetObject<WebSocketListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(okHttpClient.NewWebSocket(request, listener));
		}

		[Register("newWebSocket", "(Lokhttp3/Request;Lokhttp3/WebSocketListener;)Lokhttp3/WebSocket;", "GetNewWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_Handler")]
		public unsafe virtual IWebSocket NewWebSocket(Request request, WebSocketListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IWebSocket>(_members.InstanceMethods.InvokeVirtualObjectMethod("newWebSocket.(Lokhttp3/Request;Lokhttp3/WebSocketListener;)Lokhttp3/WebSocket;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(request);
				GC.KeepAlive(listener);
			}
		}

		[Register("pingIntervalMillis", "()I", "")]
		public unsafe int PingIntervalMillis()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("pingIntervalMillis.()I", this, null);
		}

		[Register("protocols", "()Ljava/util/List;", "")]
		public unsafe IList<Protocol> Protocols()
		{
			return JavaList<Protocol>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("protocols.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("proxy", "()Ljava/net/Proxy;", "")]
		public unsafe Proxy Proxy()
		{
			return Java.Lang.Object.GetObject<Proxy>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("proxy.()Ljava/net/Proxy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("proxyAuthenticator", "()Lokhttp3/Authenticator;", "")]
		public unsafe IAuthenticator ProxyAuthenticator()
		{
			return Java.Lang.Object.GetObject<IAuthenticator>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("proxyAuthenticator.()Lokhttp3/Authenticator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("proxySelector", "()Ljava/net/ProxySelector;", "")]
		public unsafe ProxySelector ProxySelector()
		{
			return Java.Lang.Object.GetObject<ProxySelector>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("proxySelector.()Ljava/net/ProxySelector;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("readTimeoutMillis", "()I", "")]
		public unsafe int ReadTimeoutMillis()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("readTimeoutMillis.()I", this, null);
		}

		[Register("retryOnConnectionFailure", "()Z", "")]
		public unsafe bool RetryOnConnectionFailure()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("retryOnConnectionFailure.()Z", this, null);
		}

		[Register("socketFactory", "()Ljavax/net/SocketFactory;", "")]
		public unsafe SocketFactory SocketFactory()
		{
			return Java.Lang.Object.GetObject<SocketFactory>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("socketFactory.()Ljavax/net/SocketFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("sslSocketFactory", "()Ljavax/net/ssl/SSLSocketFactory;", "")]
		public unsafe SSLSocketFactory SslSocketFactory()
		{
			return Java.Lang.Object.GetObject<SSLSocketFactory>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sslSocketFactory.()Ljavax/net/ssl/SSLSocketFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeTimeoutMillis", "()I", "")]
		public unsafe int WriteTimeoutMillis()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("writeTimeoutMillis.()I", this, null);
		}

		[Register("x509TrustManager", "()Ljavax/net/ssl/X509TrustManager;", "")]
		public unsafe IX509TrustManager X509TrustManager()
		{
			return Java.Lang.Object.GetObject<IX509TrustManager>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("x509TrustManager.()Ljavax/net/ssl/X509TrustManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/ResponseBody", DoNotGenerateAcw = true)]
	public abstract class ResponseBody : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/ResponseBody", typeof(ResponseBody));

		private static Delegate cb_close;

		private static Delegate cb_contentLength;

		private static Delegate cb_contentType;

		private static Delegate cb_source;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public Task<byte[]> BytesAsync()
		{
			return Task.Run(() => Bytes());
		}

		public Task<string> StringAsync()
		{
			return Task.Run(() => String());
		}

		protected ResponseBody(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ResponseBody()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("byteStream", "()Ljava/io/InputStream;", "")]
		public unsafe Stream ByteStream()
		{
			return InputStreamInvoker.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("byteStream.()Ljava/io/InputStream;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("byteString", "()Lokio/ByteString;", "")]
		public unsafe ByteString ByteString()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("byteString.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("bytes", "()[B", "")]
		public unsafe byte[] Bytes()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("bytes.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("charStream", "()Ljava/io/Reader;", "")]
		public unsafe Reader CharStream()
		{
			return Java.Lang.Object.GetObject<Reader>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("charStream.()Ljava/io/Reader;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
			Java.Lang.Object.GetObject<ResponseBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}

		private static Delegate GetContentLengthHandler()
		{
			if ((object)cb_contentLength == null)
			{
				cb_contentLength = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_ContentLength));
			}
			return cb_contentLength;
		}

		private static long n_ContentLength(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ResponseBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentLength();
		}

		[Register("contentLength", "()J", "GetContentLengthHandler")]
		public abstract long ContentLength();

		private static Delegate GetContentTypeHandler()
		{
			if ((object)cb_contentType == null)
			{
				cb_contentType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ContentType));
			}
			return cb_contentType;
		}

		private static IntPtr n_ContentType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ResponseBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentType());
		}

		[Register("contentType", "()Lokhttp3/MediaType;", "GetContentTypeHandler")]
		public abstract MediaType ContentType();

		[Register("create", "([BLokhttp3/MediaType;)Lokhttp3/ResponseBody;", "")]
		public unsafe static ResponseBody Create(byte[] content, MediaType contentType)
		{
			IntPtr intPtr = JNIEnv.NewArray(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ResponseBody>(_members.StaticMethods.InvokeObjectMethod("create.([BLokhttp3/MediaType;)Lokhttp3/ResponseBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (content != null)
				{
					JNIEnv.CopyArray(intPtr, content);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(content);
				GC.KeepAlive(contentType);
			}
		}

		[Register("create", "(Ljava/lang/String;Lokhttp3/MediaType;)Lokhttp3/ResponseBody;", "")]
		public unsafe static ResponseBody Create(string content, MediaType contentType)
		{
			IntPtr intPtr = JNIEnv.NewString(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ResponseBody>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/lang/String;Lokhttp3/MediaType;)Lokhttp3/ResponseBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(contentType);
			}
		}

		[Obsolete("deprecated")]
		[Register("create", "(Lokhttp3/MediaType;[B)Lokhttp3/ResponseBody;", "")]
		public unsafe static ResponseBody Create(MediaType contentType, byte[] content)
		{
			IntPtr intPtr = JNIEnv.NewArray(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ResponseBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/MediaType;[B)Lokhttp3/ResponseBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (content != null)
				{
					JNIEnv.CopyArray(intPtr, content);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(contentType);
				GC.KeepAlive(content);
			}
		}

		[Obsolete("deprecated")]
		[Register("create", "(Lokhttp3/MediaType;Ljava/lang/String;)Lokhttp3/ResponseBody;", "")]
		public unsafe static ResponseBody Create(MediaType contentType, string content)
		{
			IntPtr intPtr = JNIEnv.NewString(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ResponseBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/MediaType;Ljava/lang/String;)Lokhttp3/ResponseBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(contentType);
			}
		}

		[Obsolete("deprecated")]
		[Register("create", "(Lokhttp3/MediaType;JLokio/BufferedSource;)Lokhttp3/ResponseBody;", "")]
		public unsafe static ResponseBody Create(MediaType contentType, long contentLength, IBufferedSource content)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(contentLength);
				ptr[2] = new JniArgumentValue((content == null) ? IntPtr.Zero : ((Java.Lang.Object)content).Handle);
				return Java.Lang.Object.GetObject<ResponseBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/MediaType;JLokio/BufferedSource;)Lokhttp3/ResponseBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(contentType);
				GC.KeepAlive(content);
			}
		}

		[Obsolete("deprecated")]
		[Register("create", "(Lokhttp3/MediaType;Lokio/ByteString;)Lokhttp3/ResponseBody;", "")]
		public unsafe static ResponseBody Create(MediaType contentType, ByteString content)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ResponseBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/MediaType;Lokio/ByteString;)Lokhttp3/ResponseBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(contentType);
				GC.KeepAlive(content);
			}
		}

		[Register("create", "(Lokio/BufferedSource;Lokhttp3/MediaType;J)Lokhttp3/ResponseBody;", "")]
		public unsafe static ResponseBody Create(IBufferedSource content, MediaType contentType, long contentLength)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((content == null) ? IntPtr.Zero : ((Java.Lang.Object)content).Handle);
				ptr[1] = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(contentLength);
				return Java.Lang.Object.GetObject<ResponseBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokio/BufferedSource;Lokhttp3/MediaType;J)Lokhttp3/ResponseBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(contentType);
			}
		}

		[Register("create", "(Lokio/ByteString;Lokhttp3/MediaType;)Lokhttp3/ResponseBody;", "")]
		public unsafe static ResponseBody Create(ByteString content, MediaType contentType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ResponseBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokio/ByteString;Lokhttp3/MediaType;)Lokhttp3/ResponseBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(contentType);
			}
		}

		private static Delegate GetSourceHandler()
		{
			if ((object)cb_source == null)
			{
				cb_source = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Source));
			}
			return cb_source;
		}

		private static IntPtr n_Source(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ResponseBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Source());
		}

		[Register("source", "()Lokio/BufferedSource;", "GetSourceHandler")]
		public abstract IBufferedSource Source();

		[Register("string", "()Ljava/lang/String;", "")]
		public unsafe string String()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("string.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/Address", DoNotGenerateAcw = true)]
	public sealed class Address : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Address", typeof(Address));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Address(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;ILokhttp3/Dns;Ljavax/net/SocketFactory;Ljavax/net/ssl/SSLSocketFactory;Ljavax/net/ssl/HostnameVerifier;Lokhttp3/CertificatePinner;Lokhttp3/Authenticator;Ljava/net/Proxy;Ljava/util/List;Ljava/util/List;Ljava/net/ProxySelector;)V", "")]
		public unsafe Address(string uriHost, int uriPort, IDns dns, SocketFactory socketFactory, SSLSocketFactory sslSocketFactory, IHostnameVerifier hostnameVerifier, CertificatePinner certificatePinner, IAuthenticator proxyAuthenticator, Proxy proxy, IList<Protocol> protocols, IList<ConnectionSpec> connectionSpecs, ProxySelector proxySelector)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(uriHost);
			IntPtr intPtr2 = JavaList<Protocol>.ToLocalJniHandle(protocols);
			IntPtr intPtr3 = JavaList<ConnectionSpec>.ToLocalJniHandle(connectionSpecs);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[12];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(uriPort);
				ptr[2] = new JniArgumentValue((dns == null) ? IntPtr.Zero : ((Java.Lang.Object)dns).Handle);
				ptr[3] = new JniArgumentValue(socketFactory?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(sslSocketFactory?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue((hostnameVerifier == null) ? IntPtr.Zero : ((Java.Lang.Object)hostnameVerifier).Handle);
				ptr[6] = new JniArgumentValue(certificatePinner?.Handle ?? IntPtr.Zero);
				ptr[7] = new JniArgumentValue((proxyAuthenticator == null) ? IntPtr.Zero : ((Java.Lang.Object)proxyAuthenticator).Handle);
				ptr[8] = new JniArgumentValue(proxy?.Handle ?? IntPtr.Zero);
				ptr[9] = new JniArgumentValue(intPtr2);
				ptr[10] = new JniArgumentValue(intPtr3);
				ptr[11] = new JniArgumentValue(proxySelector?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;ILokhttp3/Dns;Ljavax/net/SocketFactory;Ljavax/net/ssl/SSLSocketFactory;Ljavax/net/ssl/HostnameVerifier;Lokhttp3/CertificatePinner;Lokhttp3/Authenticator;Ljava/net/Proxy;Ljava/util/List;Ljava/util/List;Ljava/net/ProxySelector;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;ILokhttp3/Dns;Ljavax/net/SocketFactory;Ljavax/net/ssl/SSLSocketFactory;Ljavax/net/ssl/HostnameVerifier;Lokhttp3/CertificatePinner;Lokhttp3/Authenticator;Ljava/net/Proxy;Ljava/util/List;Ljava/util/List;Ljava/net/ProxySelector;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				GC.KeepAlive(dns);
				GC.KeepAlive(socketFactory);
				GC.KeepAlive(sslSocketFactory);
				GC.KeepAlive(hostnameVerifier);
				GC.KeepAlive(certificatePinner);
				GC.KeepAlive(proxyAuthenticator);
				GC.KeepAlive(proxy);
				GC.KeepAlive(protocols);
				GC.KeepAlive(connectionSpecs);
				GC.KeepAlive(proxySelector);
			}
		}

		[Register("certificatePinner", "()Lokhttp3/CertificatePinner;", "")]
		public unsafe CertificatePinner CertificatePinner()
		{
			return Java.Lang.Object.GetObject<CertificatePinner>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("certificatePinner.()Lokhttp3/CertificatePinner;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("connectionSpecs", "()Ljava/util/List;", "")]
		public unsafe IList<ConnectionSpec> ConnectionSpecs()
		{
			return JavaList<ConnectionSpec>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("connectionSpecs.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("dns", "()Lokhttp3/Dns;", "")]
		public unsafe IDns Dns()
		{
			return Java.Lang.Object.GetObject<IDns>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("dns.()Lokhttp3/Dns;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("hostnameVerifier", "()Ljavax/net/ssl/HostnameVerifier;", "")]
		public unsafe IHostnameVerifier HostnameVerifier()
		{
			return Java.Lang.Object.GetObject<IHostnameVerifier>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hostnameVerifier.()Ljavax/net/ssl/HostnameVerifier;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("protocols", "()Ljava/util/List;", "")]
		public unsafe IList<Protocol> Protocols()
		{
			return JavaList<Protocol>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("protocols.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("proxy", "()Ljava/net/Proxy;", "")]
		public unsafe Proxy Proxy()
		{
			return Java.Lang.Object.GetObject<Proxy>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("proxy.()Ljava/net/Proxy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("proxyAuthenticator", "()Lokhttp3/Authenticator;", "")]
		public unsafe IAuthenticator ProxyAuthenticator()
		{
			return Java.Lang.Object.GetObject<IAuthenticator>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("proxyAuthenticator.()Lokhttp3/Authenticator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("proxySelector", "()Ljava/net/ProxySelector;", "")]
		public unsafe ProxySelector ProxySelector()
		{
			return Java.Lang.Object.GetObject<ProxySelector>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("proxySelector.()Ljava/net/ProxySelector;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("socketFactory", "()Ljavax/net/SocketFactory;", "")]
		public unsafe SocketFactory SocketFactory()
		{
			return Java.Lang.Object.GetObject<SocketFactory>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("socketFactory.()Ljavax/net/SocketFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("sslSocketFactory", "()Ljavax/net/ssl/SSLSocketFactory;", "")]
		public unsafe SSLSocketFactory SslSocketFactory()
		{
			return Java.Lang.Object.GetObject<SSLSocketFactory>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sslSocketFactory.()Ljavax/net/ssl/SSLSocketFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("url", "()Lokhttp3/HttpUrl;", "")]
		public unsafe HttpUrl Url()
		{
			return Java.Lang.Object.GetObject<HttpUrl>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("url.()Lokhttp3/HttpUrl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/Cache", DoNotGenerateAcw = true)]
	public sealed class Cache : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable, IFlushable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Cache", typeof(Cache));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsClosed
		{
			[Register("isClosed", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isClosed.()Z", this, null);
			}
		}

		internal Cache(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/io/File;J)V", "")]
		public unsafe Cache(Java.IO.File directory, long maxSize)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(directory?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(maxSize);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/io/File;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/io/File;J)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(directory);
			}
		}

		[Register("close", "()V", "")]
		public unsafe void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("delete", "()V", "")]
		public unsafe void Delete()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("delete.()V", this, null);
		}

		[Register("directory", "()Ljava/io/File;", "")]
		public unsafe Java.IO.File Directory()
		{
			return Java.Lang.Object.GetObject<Java.IO.File>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("directory.()Ljava/io/File;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("evictAll", "()V", "")]
		public unsafe void EvictAll()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("evictAll.()V", this, null);
		}

		[Register("flush", "()V", "")]
		public unsafe void Flush()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("flush.()V", this, null);
		}

		[Register("hitCount", "()I", "")]
		public unsafe int HitCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("hitCount.()I", this, null);
		}

		[Register("initialize", "()V", "")]
		public unsafe void Initialize()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("initialize.()V", this, null);
		}

		[Register("key", "(Lokhttp3/HttpUrl;)Ljava/lang/String;", "")]
		public unsafe static string Key(HttpUrl url)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("key.(Lokhttp3/HttpUrl;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(url);
			}
		}

		[Register("maxSize", "()J", "")]
		public unsafe long MaxSize()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt64Method("maxSize.()J", this, null);
		}

		[Register("networkCount", "()I", "")]
		public unsafe int NetworkCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("networkCount.()I", this, null);
		}

		[Register("requestCount", "()I", "")]
		public unsafe int RequestCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("requestCount.()I", this, null);
		}

		[Register("size", "()J", "")]
		public unsafe long Size()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt64Method("size.()J", this, null);
		}

		[Register("urls", "()Ljava/util/Iterator;", "")]
		public unsafe IIterator Urls()
		{
			return Java.Lang.Object.GetObject<IIterator>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("urls.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeAbortCount", "()I", "")]
		public unsafe int WriteAbortCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("writeAbortCount.()I", this, null);
		}

		[Register("writeSuccessCount", "()I", "")]
		public unsafe int WriteSuccessCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("writeSuccessCount.()I", this, null);
		}
	}
	[Register("okhttp3/CacheControl", DoNotGenerateAcw = true)]
	public sealed class CacheControl : Java.Lang.Object
	{
		[Register("okhttp3/CacheControl$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/CacheControl$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			[Register("build", "()Lokhttp3/CacheControl;", "")]
			public unsafe CacheControl Build()
			{
				return Java.Lang.Object.GetObject<CacheControl>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lokhttp3/CacheControl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("immutable", "()Lokhttp3/CacheControl$Builder;", "")]
			public unsafe Builder Immutable()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("immutable.()Lokhttp3/CacheControl$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("maxAge", "(ILjava/util/concurrent/TimeUnit;)Lokhttp3/CacheControl$Builder;", "")]
			public unsafe Builder MaxAge(int maxAge, TimeUnit timeUnit)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(maxAge);
					ptr[1] = new JniArgumentValue(timeUnit?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("maxAge.(ILjava/util/concurrent/TimeUnit;)Lokhttp3/CacheControl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(timeUnit);
				}
			}

			[Register("maxStale", "(ILjava/util/concurrent/TimeUnit;)Lokhttp3/CacheControl$Builder;", "")]
			public unsafe Builder MaxStale(int maxStale, TimeUnit timeUnit)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(maxStale);
					ptr[1] = new JniArgumentValue(timeUnit?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("maxStale.(ILjava/util/concurrent/TimeUnit;)Lokhttp3/CacheControl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(timeUnit);
				}
			}

			[Register("minFresh", "(ILjava/util/concurrent/TimeUnit;)Lokhttp3/CacheControl$Builder;", "")]
			public unsafe Builder MinFresh(int minFresh, TimeUnit timeUnit)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(minFresh);
					ptr[1] = new JniArgumentValue(timeUnit?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("minFresh.(ILjava/util/concurrent/TimeUnit;)Lokhttp3/CacheControl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(timeUnit);
				}
			}

			[Register("noCache", "()Lokhttp3/CacheControl$Builder;", "")]
			public unsafe Builder NoCache()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("noCache.()Lokhttp3/CacheControl$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("noStore", "()Lokhttp3/CacheControl$Builder;", "")]
			public unsafe Builder NoStore()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("noStore.()Lokhttp3/CacheControl$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("noTransform", "()Lokhttp3/CacheControl$Builder;", "")]
			public unsafe Builder NoTransform()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("noTransform.()Lokhttp3/CacheControl$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("onlyIfCached", "()Lokhttp3/CacheControl$Builder;", "")]
			public unsafe Builder OnlyIfCached()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("onlyIfCached.()Lokhttp3/CacheControl$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/CacheControl", typeof(CacheControl));

		[Register("FORCE_CACHE")]
		public static CacheControl ForceCache => Java.Lang.Object.GetObject<CacheControl>(_members.StaticFields.GetObjectValue("FORCE_CACHE.Lokhttp3/CacheControl;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FORCE_NETWORK")]
		public static CacheControl ForceNetwork => Java.Lang.Object.GetObject<CacheControl>(_members.StaticFields.GetObjectValue("FORCE_NETWORK.Lokhttp3/CacheControl;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsPrivate
		{
			[Register("isPrivate", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isPrivate.()Z", this, null);
			}
		}

		public unsafe bool IsPublic
		{
			[Register("isPublic", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isPublic.()Z", this, null);
			}
		}

		internal CacheControl(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("immutable", "()Z", "")]
		public unsafe bool Immutable()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("immutable.()Z", this, null);
		}

		[Register("maxAgeSeconds", "()I", "")]
		public unsafe int MaxAgeSeconds()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("maxAgeSeconds.()I", this, null);
		}

		[Register("maxStaleSeconds", "()I", "")]
		public unsafe int MaxStaleSeconds()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("maxStaleSeconds.()I", this, null);
		}

		[Register("minFreshSeconds", "()I", "")]
		public unsafe int MinFreshSeconds()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("minFreshSeconds.()I", this, null);
		}

		[Register("mustRevalidate", "()Z", "")]
		public unsafe bool MustRevalidate()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("mustRevalidate.()Z", this, null);
		}

		[Register("noCache", "()Z", "")]
		public unsafe bool NoCache()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("noCache.()Z", this, null);
		}

		[Register("noStore", "()Z", "")]
		public unsafe bool NoStore()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("noStore.()Z", this, null);
		}

		[Register("noTransform", "()Z", "")]
		public unsafe bool NoTransform()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("noTransform.()Z", this, null);
		}

		[Register("onlyIfCached", "()Z", "")]
		public unsafe bool OnlyIfCached()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("onlyIfCached.()Z", this, null);
		}

		[Register("parse", "(Lokhttp3/Headers;)Lokhttp3/CacheControl;", "")]
		public unsafe static CacheControl Parse(Headers headers)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(headers?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CacheControl>(_members.StaticMethods.InvokeObjectMethod("parse.(Lokhttp3/Headers;)Lokhttp3/CacheControl;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(headers);
			}
		}

		[Register("sMaxAgeSeconds", "()I", "")]
		public unsafe int SMaxAgeSeconds()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("sMaxAgeSeconds.()I", this, null);
		}
	}
	[Register("okhttp3/CertificatePinner", DoNotGenerateAcw = true)]
	public sealed class CertificatePinner : Java.Lang.Object
	{
		[Register("okhttp3/CertificatePinner$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/CertificatePinner$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe IList<Pin> Pins
			{
				[Register("getPins", "()Ljava/util/List;", "")]
				get
				{
					return JavaList<Pin>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPins.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

			[Register("add", "(Ljava/lang/String;[Ljava/lang/String;)Lokhttp3/CertificatePinner$Builder;", "")]
			public unsafe Builder Add(string pattern, params string[] pins)
			{
				IntPtr intPtr = JNIEnv.NewString(pattern);
				IntPtr intPtr2 = JNIEnv.NewArray(pins);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(Ljava/lang/String;[Ljava/lang/String;)Lokhttp3/CertificatePinner$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (pins != null)
					{
						JNIEnv.CopyArray(intPtr2, pins);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
					GC.KeepAlive(pins);
				}
			}

			[Register("build", "()Lokhttp3/CertificatePinner;", "")]
			public unsafe CertificatePinner Build()
			{
				return Java.Lang.Object.GetObject<CertificatePinner>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lokhttp3/CertificatePinner;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("okhttp3/CertificatePinner$Pin", DoNotGenerateAcw = true)]
		public sealed class Pin : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/CertificatePinner$Pin", typeof(Pin));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe ByteString Hash
			{
				[Register("getHash", "()Lokio/ByteString;", "")]
				get
				{
					return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getHash.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe string HashAlgorithm
			{
				[Register("getHashAlgorithm", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getHashAlgorithm.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe string Pattern
			{
				[Register("getPattern", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPattern.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Pin(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
			public unsafe Pin(string pattern, string pin)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.NewString(pattern);
				IntPtr intPtr2 = JNIEnv.NewString(pin);
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

			[Register("matchesCertificate", "(Ljava/security/cert/X509Certificate;)Z", "")]
			public unsafe bool MatchesCertificate(X509Certificate certificate)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(certificate?.Handle ?? IntPtr.Zero);
					return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("matchesCertificate.(Ljava/security/cert/X509Certificate;)Z", this, ptr);
				}
				finally
				{
					GC.KeepAlive(certificate);
				}
			}

			[Register("matchesHostname", "(Ljava/lang/String;)Z", "")]
			public unsafe bool MatchesHostname(string hostname)
			{
				IntPtr intPtr = JNIEnv.NewString(hostname);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("matchesHostname.(Ljava/lang/String;)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/CertificatePinner", typeof(CertificatePinner));

		[Register("DEFAULT")]
		public static CertificatePinner Default => Java.Lang.Object.GetObject<CertificatePinner>(_members.StaticFields.GetObjectValue("DEFAULT.Lokhttp3/CertificatePinner;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe ICollection<Pin> Pins
		{
			[Register("getPins", "()Ljava/util/Set;", "")]
			get
			{
				return JavaSet<Pin>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPins.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CertificatePinner(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Obsolete("deprecated")]
		[Register("check", "(Ljava/lang/String;[Ljava/security/cert/Certificate;)V", "")]
		public unsafe void Check(string hostname, params Certificate[] peerCertificates)
		{
			IntPtr intPtr = JNIEnv.NewString(hostname);
			IntPtr intPtr2 = JNIEnv.NewArray(peerCertificates);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("check.(Ljava/lang/String;[Ljava/security/cert/Certificate;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (peerCertificates != null)
				{
					JNIEnv.CopyArray(intPtr2, peerCertificates);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(peerCertificates);
			}
		}

		[Register("check", "(Ljava/lang/String;Ljava/util/List;)V", "")]
		public unsafe void Check(string hostname, IList<Certificate> peerCertificates)
		{
			IntPtr intPtr = JNIEnv.NewString(hostname);
			IntPtr intPtr2 = JavaList<Certificate>.ToLocalJniHandle(peerCertificates);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("check.(Ljava/lang/String;Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(peerCertificates);
			}
		}

		[Register("findMatchingPins", "(Ljava/lang/String;)Ljava/util/List;", "")]
		public unsafe IList<Pin> FindMatchingPins(string hostname)
		{
			IntPtr intPtr = JNIEnv.NewString(hostname);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JavaList<Pin>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("findMatchingPins.(Ljava/lang/String;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("pin", "(Ljava/security/cert/Certificate;)Ljava/lang/String;", "")]
		public unsafe static string InvokePin(Certificate certificate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(certificate?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("pin.(Ljava/security/cert/Certificate;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(certificate);
			}
		}

		[Register("sha1Hash", "(Ljava/security/cert/X509Certificate;)Lokio/ByteString;", "")]
		public unsafe static ByteString Sha1Hash(X509Certificate obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ByteString>(_members.StaticMethods.InvokeObjectMethod("sha1Hash.(Ljava/security/cert/X509Certificate;)Lokio/ByteString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Register("sha256Hash", "(Ljava/security/cert/X509Certificate;)Lokio/ByteString;", "")]
		public unsafe static ByteString Sha256Hash(X509Certificate obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ByteString>(_members.StaticMethods.InvokeObjectMethod("sha256Hash.(Ljava/security/cert/X509Certificate;)Lokio/ByteString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}
	}
	[Register("okhttp3/Challenge", DoNotGenerateAcw = true)]
	public sealed class Challenge : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Challenge", typeof(Challenge));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Challenge(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe Challenge(string scheme, string realm)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(scheme);
			IntPtr intPtr2 = JNIEnv.NewString(realm);
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

		[Register(".ctor", "(Ljava/lang/String;Ljava/util/Map;)V", "")]
		public unsafe Challenge(string scheme, IDictionary<string, string> authParams)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(scheme);
			IntPtr intPtr2 = JavaDictionary<string, string>.ToLocalJniHandle(authParams);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/util/Map;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/util/Map;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(authParams);
			}
		}

		[Register("authParams", "()Ljava/util/Map;", "")]
		public unsafe IDictionary<string, string> AuthParams()
		{
			return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("authParams.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("charset", "()Ljava/nio/charset/Charset;", "")]
		public unsafe Charset Charset()
		{
			return Java.Lang.Object.GetObject<Charset>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("charset.()Ljava/nio/charset/Charset;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("realm", "()Ljava/lang/String;", "")]
		public unsafe string Realm()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("realm.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("scheme", "()Ljava/lang/String;", "")]
		public unsafe string Scheme()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("scheme.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("withCharset", "(Ljava/nio/charset/Charset;)Lokhttp3/Challenge;", "")]
		public unsafe Challenge WithCharset(Charset charset)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(charset?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Challenge>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("withCharset.(Ljava/nio/charset/Charset;)Lokhttp3/Challenge;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(charset);
			}
		}
	}
	[Register("okhttp3/CipherSuite", DoNotGenerateAcw = true)]
	public sealed class CipherSuite : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/CipherSuite", typeof(CipherSuite));

		[Register("TLS_AES_128_CCM_8_SHA256")]
		public static CipherSuite TlsAes128Ccm8Sha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_AES_128_CCM_8_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_AES_128_CCM_SHA256")]
		public static CipherSuite TlsAes128CcmSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_AES_128_CCM_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_AES_128_GCM_SHA256")]
		public static CipherSuite TlsAes128GcmSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_AES_128_GCM_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_AES_256_GCM_SHA384")]
		public static CipherSuite TlsAes256GcmSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_AES_256_GCM_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_CHACHA20_POLY1305_SHA256")]
		public static CipherSuite TlsChacha20Poly1305Sha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_CHACHA20_POLY1305_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_EXPORT_WITH_DES40_CBC_SHA")]
		public static CipherSuite TlsDheDssExportWithDes40CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_EXPORT_WITH_DES40_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TlsDheDssWith3desEdeCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TlsDheDssWithAes128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_WITH_AES_128_CBC_SHA256")]
		public static CipherSuite TlsDheDssWithAes128CbcSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_WITH_AES_128_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_WITH_AES_128_GCM_SHA256")]
		public static CipherSuite TlsDheDssWithAes128GcmSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_WITH_AES_128_GCM_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TlsDheDssWithAes256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_WITH_AES_256_CBC_SHA256")]
		public static CipherSuite TlsDheDssWithAes256CbcSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_WITH_AES_256_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_WITH_AES_256_GCM_SHA384")]
		public static CipherSuite TlsDheDssWithAes256GcmSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_WITH_AES_256_GCM_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_WITH_CAMELLIA_128_CBC_SHA")]
		public static CipherSuite TlsDheDssWithCamellia128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_WITH_CAMELLIA_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_WITH_CAMELLIA_256_CBC_SHA")]
		public static CipherSuite TlsDheDssWithCamellia256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_WITH_CAMELLIA_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_DSS_WITH_DES_CBC_SHA")]
		public static CipherSuite TlsDheDssWithDesCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_DSS_WITH_DES_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_EXPORT_WITH_DES40_CBC_SHA")]
		public static CipherSuite TlsDheRsaExportWithDes40CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_EXPORT_WITH_DES40_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TlsDheRsaWith3desEdeCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TlsDheRsaWithAes128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_AES_128_CBC_SHA256")]
		public static CipherSuite TlsDheRsaWithAes128CbcSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_AES_128_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_AES_128_GCM_SHA256")]
		public static CipherSuite TlsDheRsaWithAes128GcmSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_AES_128_GCM_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TlsDheRsaWithAes256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_AES_256_CBC_SHA256")]
		public static CipherSuite TlsDheRsaWithAes256CbcSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_AES_256_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_AES_256_GCM_SHA384")]
		public static CipherSuite TlsDheRsaWithAes256GcmSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_AES_256_GCM_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_CAMELLIA_128_CBC_SHA")]
		public static CipherSuite TlsDheRsaWithCamellia128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_CAMELLIA_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_CAMELLIA_256_CBC_SHA")]
		public static CipherSuite TlsDheRsaWithCamellia256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_CAMELLIA_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_CHACHA20_POLY1305_SHA256")]
		public static CipherSuite TlsDheRsaWithChacha20Poly1305Sha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_CHACHA20_POLY1305_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DHE_RSA_WITH_DES_CBC_SHA")]
		public static CipherSuite TlsDheRsaWithDesCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DHE_RSA_WITH_DES_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_EXPORT_WITH_DES40_CBC_SHA")]
		public static CipherSuite TLSDHAnonEXPORTWITHDES40CBCSHA => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_EXPORT_WITH_DES40_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_EXPORT_WITH_RC4_40_MD5")]
		public static CipherSuite TLSDHAnonEXPORTWITHRC440MD5 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_EXPORT_WITH_RC4_40_MD5.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TLSDHAnonWITH3DESEDECBCSHA => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TLSDHAnonWITHAES128CBCSHA => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_WITH_AES_128_CBC_SHA256")]
		public static CipherSuite TLSDHAnonWITHAES128CBCSHA256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_WITH_AES_128_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_WITH_AES_128_GCM_SHA256")]
		public static CipherSuite TLSDHAnonWITHAES128GCMSHA256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_WITH_AES_128_GCM_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TLSDHAnonWITHAES256CBCSHA => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_WITH_AES_256_CBC_SHA256")]
		public static CipherSuite TLSDHAnonWITHAES256CBCSHA256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_WITH_AES_256_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_WITH_AES_256_GCM_SHA384")]
		public static CipherSuite TLSDHAnonWITHAES256GCMSHA384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_WITH_AES_256_GCM_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_WITH_DES_CBC_SHA")]
		public static CipherSuite TLSDHAnonWITHDESCBCSHA => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_WITH_DES_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_DH_anon_WITH_RC4_128_MD5")]
		public static CipherSuite TLSDHAnonWITHRC4128MD5 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_DH_anon_WITH_RC4_128_MD5.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_ECDSA_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TlsEcdheEcdsaWith3desEdeCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_ECDSA_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TlsEcdheEcdsaWithAes128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256")]
		public static CipherSuite TlsEcdheEcdsaWithAes128CbcSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256")]
		public static CipherSuite TlsEcdheEcdsaWithAes128GcmSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TlsEcdheEcdsaWithAes256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384")]
		public static CipherSuite TlsEcdheEcdsaWithAes256CbcSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384")]
		public static CipherSuite TlsEcdheEcdsaWithAes256GcmSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_ECDSA_WITH_CHACHA20_POLY1305_SHA256")]
		public static CipherSuite TlsEcdheEcdsaWithChacha20Poly1305Sha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_ECDSA_WITH_CHACHA20_POLY1305_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_ECDSA_WITH_NULL_SHA")]
		public static CipherSuite TlsEcdheEcdsaWithNullSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_ECDSA_WITH_NULL_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_ECDSA_WITH_RC4_128_SHA")]
		public static CipherSuite TlsEcdheEcdsaWithRc4128Sha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_ECDSA_WITH_RC4_128_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_PSK_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TlsEcdhePskWithAes128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_PSK_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_PSK_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TlsEcdhePskWithAes256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_PSK_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_PSK_WITH_CHACHA20_POLY1305_SHA256")]
		public static CipherSuite TlsEcdhePskWithChacha20Poly1305Sha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_PSK_WITH_CHACHA20_POLY1305_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_RSA_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TlsEcdheRsaWith3desEdeCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_RSA_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TlsEcdheRsaWithAes128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256")]
		public static CipherSuite TlsEcdheRsaWithAes128CbcSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256")]
		public static CipherSuite TlsEcdheRsaWithAes128GcmSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TlsEcdheRsaWithAes256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384")]
		public static CipherSuite TlsEcdheRsaWithAes256CbcSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384")]
		public static CipherSuite TlsEcdheRsaWithAes256GcmSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_RSA_WITH_CHACHA20_POLY1305_SHA256")]
		public static CipherSuite TlsEcdheRsaWithChacha20Poly1305Sha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_RSA_WITH_CHACHA20_POLY1305_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_RSA_WITH_NULL_SHA")]
		public static CipherSuite TlsEcdheRsaWithNullSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_RSA_WITH_NULL_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDHE_RSA_WITH_RC4_128_SHA")]
		public static CipherSuite TlsEcdheRsaWithRc4128Sha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDHE_RSA_WITH_RC4_128_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_ECDSA_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TlsEcdhEcdsaWith3desEdeCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_ECDSA_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_ECDSA_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TlsEcdhEcdsaWithAes128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_ECDSA_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_ECDSA_WITH_AES_128_CBC_SHA256")]
		public static CipherSuite TlsEcdhEcdsaWithAes128CbcSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_ECDSA_WITH_AES_128_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_ECDSA_WITH_AES_128_GCM_SHA256")]
		public static CipherSuite TlsEcdhEcdsaWithAes128GcmSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_ECDSA_WITH_AES_128_GCM_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_ECDSA_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TlsEcdhEcdsaWithAes256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_ECDSA_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_ECDSA_WITH_AES_256_CBC_SHA384")]
		public static CipherSuite TlsEcdhEcdsaWithAes256CbcSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_ECDSA_WITH_AES_256_CBC_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_ECDSA_WITH_AES_256_GCM_SHA384")]
		public static CipherSuite TlsEcdhEcdsaWithAes256GcmSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_ECDSA_WITH_AES_256_GCM_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_ECDSA_WITH_NULL_SHA")]
		public static CipherSuite TlsEcdhEcdsaWithNullSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_ECDSA_WITH_NULL_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_ECDSA_WITH_RC4_128_SHA")]
		public static CipherSuite TlsEcdhEcdsaWithRc4128Sha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_ECDSA_WITH_RC4_128_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_RSA_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TlsEcdhRsaWith3desEdeCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_RSA_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_RSA_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TlsEcdhRsaWithAes128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_RSA_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_RSA_WITH_AES_128_CBC_SHA256")]
		public static CipherSuite TlsEcdhRsaWithAes128CbcSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_RSA_WITH_AES_128_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_RSA_WITH_AES_128_GCM_SHA256")]
		public static CipherSuite TlsEcdhRsaWithAes128GcmSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_RSA_WITH_AES_128_GCM_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_RSA_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TlsEcdhRsaWithAes256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_RSA_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_RSA_WITH_AES_256_CBC_SHA384")]
		public static CipherSuite TlsEcdhRsaWithAes256CbcSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_RSA_WITH_AES_256_CBC_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_RSA_WITH_AES_256_GCM_SHA384")]
		public static CipherSuite TlsEcdhRsaWithAes256GcmSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_RSA_WITH_AES_256_GCM_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_RSA_WITH_NULL_SHA")]
		public static CipherSuite TlsEcdhRsaWithNullSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_RSA_WITH_NULL_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_RSA_WITH_RC4_128_SHA")]
		public static CipherSuite TlsEcdhRsaWithRc4128Sha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_RSA_WITH_RC4_128_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_anon_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TLSECDHAnonWITH3DESEDECBCSHA => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_anon_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_anon_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TLSECDHAnonWITHAES128CBCSHA => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_anon_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_anon_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TLSECDHAnonWITHAES256CBCSHA => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_anon_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_anon_WITH_NULL_SHA")]
		public static CipherSuite TLSECDHAnonWITHNULLSHA => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_anon_WITH_NULL_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_ECDH_anon_WITH_RC4_128_SHA")]
		public static CipherSuite TLSECDHAnonWITHRC4128SHA => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_ECDH_anon_WITH_RC4_128_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_EMPTY_RENEGOTIATION_INFO_SCSV")]
		public static CipherSuite TlsEmptyRenegotiationInfoScsv => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_EMPTY_RENEGOTIATION_INFO_SCSV.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_FALLBACK_SCSV")]
		public static CipherSuite TlsFallbackScsv => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_FALLBACK_SCSV.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_KRB5_EXPORT_WITH_DES_CBC_40_MD5")]
		public static CipherSuite TlsKrb5ExportWithDesCbc40Md5 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_KRB5_EXPORT_WITH_DES_CBC_40_MD5.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_KRB5_EXPORT_WITH_DES_CBC_40_SHA")]
		public static CipherSuite TlsKrb5ExportWithDesCbc40Sha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_KRB5_EXPORT_WITH_DES_CBC_40_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_KRB5_EXPORT_WITH_RC4_40_MD5")]
		public static CipherSuite TlsKrb5ExportWithRc440Md5 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_KRB5_EXPORT_WITH_RC4_40_MD5.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_KRB5_EXPORT_WITH_RC4_40_SHA")]
		public static CipherSuite TlsKrb5ExportWithRc440Sha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_KRB5_EXPORT_WITH_RC4_40_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_KRB5_WITH_3DES_EDE_CBC_MD5")]
		public static CipherSuite TlsKrb5With3desEdeCbcMd5 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_KRB5_WITH_3DES_EDE_CBC_MD5.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_KRB5_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TlsKrb5With3desEdeCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_KRB5_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_KRB5_WITH_DES_CBC_MD5")]
		public static CipherSuite TlsKrb5WithDesCbcMd5 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_KRB5_WITH_DES_CBC_MD5.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_KRB5_WITH_DES_CBC_SHA")]
		public static CipherSuite TlsKrb5WithDesCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_KRB5_WITH_DES_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_KRB5_WITH_RC4_128_MD5")]
		public static CipherSuite TlsKrb5WithRc4128Md5 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_KRB5_WITH_RC4_128_MD5.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_KRB5_WITH_RC4_128_SHA")]
		public static CipherSuite TlsKrb5WithRc4128Sha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_KRB5_WITH_RC4_128_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_PSK_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TlsPskWith3desEdeCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_PSK_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_PSK_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TlsPskWithAes128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_PSK_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_PSK_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TlsPskWithAes256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_PSK_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_PSK_WITH_RC4_128_SHA")]
		public static CipherSuite TlsPskWithRc4128Sha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_PSK_WITH_RC4_128_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_EXPORT_WITH_DES40_CBC_SHA")]
		public static CipherSuite TlsRsaExportWithDes40CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_EXPORT_WITH_DES40_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_EXPORT_WITH_RC4_40_MD5")]
		public static CipherSuite TlsRsaExportWithRc440Md5 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_EXPORT_WITH_RC4_40_MD5.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_3DES_EDE_CBC_SHA")]
		public static CipherSuite TlsRsaWith3desEdeCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_3DES_EDE_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_AES_128_CBC_SHA")]
		public static CipherSuite TlsRsaWithAes128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_AES_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_AES_128_CBC_SHA256")]
		public static CipherSuite TlsRsaWithAes128CbcSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_AES_128_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_AES_128_GCM_SHA256")]
		public static CipherSuite TlsRsaWithAes128GcmSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_AES_128_GCM_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_AES_256_CBC_SHA")]
		public static CipherSuite TlsRsaWithAes256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_AES_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_AES_256_CBC_SHA256")]
		public static CipherSuite TlsRsaWithAes256CbcSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_AES_256_CBC_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_AES_256_GCM_SHA384")]
		public static CipherSuite TlsRsaWithAes256GcmSha384 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_AES_256_GCM_SHA384.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_CAMELLIA_128_CBC_SHA")]
		public static CipherSuite TlsRsaWithCamellia128CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_CAMELLIA_128_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_CAMELLIA_256_CBC_SHA")]
		public static CipherSuite TlsRsaWithCamellia256CbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_CAMELLIA_256_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_DES_CBC_SHA")]
		public static CipherSuite TlsRsaWithDesCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_DES_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_NULL_MD5")]
		public static CipherSuite TlsRsaWithNullMd5 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_NULL_MD5.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_NULL_SHA")]
		public static CipherSuite TlsRsaWithNullSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_NULL_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_NULL_SHA256")]
		public static CipherSuite TlsRsaWithNullSha256 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_NULL_SHA256.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_RC4_128_MD5")]
		public static CipherSuite TlsRsaWithRc4128Md5 => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_RC4_128_MD5.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_RC4_128_SHA")]
		public static CipherSuite TlsRsaWithRc4128Sha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_RC4_128_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_RSA_WITH_SEED_CBC_SHA")]
		public static CipherSuite TlsRsaWithSeedCbcSha => Java.Lang.Object.GetObject<CipherSuite>(_members.StaticFields.GetObjectValue("TLS_RSA_WITH_SEED_CBC_SHA.Lokhttp3/CipherSuite;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal CipherSuite(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("forJavaName", "(Ljava/lang/String;)Lokhttp3/CipherSuite;", "")]
		public unsafe static CipherSuite ForJavaName(string javaName)
		{
			IntPtr intPtr = JNIEnv.NewString(javaName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<CipherSuite>(_members.StaticMethods.InvokeObjectMethod("forJavaName.(Ljava/lang/String;)Lokhttp3/CipherSuite;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("javaName", "()Ljava/lang/String;", "")]
		public unsafe string JavaName()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("javaName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/ConnectionPool", DoNotGenerateAcw = true)]
	public sealed class ConnectionPool : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/ConnectionPool", typeof(ConnectionPool));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ConnectionPool(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ConnectionPool()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(IJLjava/util/concurrent/TimeUnit;)V", "")]
		public unsafe ConnectionPool(int maxIdleConnections, long keepAliveDuration, TimeUnit timeUnit)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(maxIdleConnections);
				ptr[1] = new JniArgumentValue(keepAliveDuration);
				ptr[2] = new JniArgumentValue(timeUnit?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(IJLjava/util/concurrent/TimeUnit;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(IJLjava/util/concurrent/TimeUnit;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(timeUnit);
			}
		}

		[Register("connectionCount", "()I", "")]
		public unsafe int ConnectionCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("connectionCount.()I", this, null);
		}

		[Register("evictAll", "()V", "")]
		public unsafe void EvictAll()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("evictAll.()V", this, null);
		}

		[Register("idleConnectionCount", "()I", "")]
		public unsafe int IdleConnectionCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("idleConnectionCount.()I", this, null);
		}
	}
	[Register("okhttp3/ConnectionSpec", DoNotGenerateAcw = true)]
	public sealed class ConnectionSpec : Java.Lang.Object
	{
		[Register("okhttp3/ConnectionSpec$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/ConnectionSpec$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			[Register(".ctor", "(Lokhttp3/ConnectionSpec;)V", "")]
			public unsafe Builder(ConnectionSpec connectionSpec)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(connectionSpec?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokhttp3/ConnectionSpec;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lokhttp3/ConnectionSpec;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(connectionSpec);
				}
			}

			[Register("allEnabledCipherSuites", "()Lokhttp3/ConnectionSpec$Builder;", "")]
			public unsafe Builder AllEnabledCipherSuites()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("allEnabledCipherSuites.()Lokhttp3/ConnectionSpec$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("allEnabledTlsVersions", "()Lokhttp3/ConnectionSpec$Builder;", "")]
			public unsafe Builder AllEnabledTlsVersions()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("allEnabledTlsVersions.()Lokhttp3/ConnectionSpec$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("build", "()Lokhttp3/ConnectionSpec;", "")]
			public unsafe ConnectionSpec Build()
			{
				return Java.Lang.Object.GetObject<ConnectionSpec>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lokhttp3/ConnectionSpec;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("cipherSuites", "([Ljava/lang/String;)Lokhttp3/ConnectionSpec$Builder;", "")]
			public unsafe Builder CipherSuites(params string[] cipherSuites)
			{
				IntPtr intPtr = JNIEnv.NewArray(cipherSuites);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cipherSuites.([Ljava/lang/String;)Lokhttp3/ConnectionSpec$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (cipherSuites != null)
					{
						JNIEnv.CopyArray(intPtr, cipherSuites);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(cipherSuites);
				}
			}

			[Register("cipherSuites", "([Lokhttp3/CipherSuite;)Lokhttp3/ConnectionSpec$Builder;", "")]
			public unsafe Builder CipherSuites(params CipherSuite[] cipherSuites)
			{
				IntPtr intPtr = JNIEnv.NewArray(cipherSuites);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cipherSuites.([Lokhttp3/CipherSuite;)Lokhttp3/ConnectionSpec$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (cipherSuites != null)
					{
						JNIEnv.CopyArray(intPtr, cipherSuites);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(cipherSuites);
				}
			}

			[Obsolete("deprecated")]
			[Register("supportsTlsExtensions", "(Z)Lokhttp3/ConnectionSpec$Builder;", "")]
			public unsafe Builder SupportsTlsExtensions(bool supportsTlsExtensions)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(supportsTlsExtensions);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("supportsTlsExtensions.(Z)Lokhttp3/ConnectionSpec$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("tlsVersions", "([Ljava/lang/String;)Lokhttp3/ConnectionSpec$Builder;", "")]
			public unsafe Builder TlsVersions(params string[] tlsVersions)
			{
				IntPtr intPtr = JNIEnv.NewArray(tlsVersions);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("tlsVersions.([Ljava/lang/String;)Lokhttp3/ConnectionSpec$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (tlsVersions != null)
					{
						JNIEnv.CopyArray(intPtr, tlsVersions);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(tlsVersions);
				}
			}

			[Register("tlsVersions", "([Lokhttp3/TlsVersion;)Lokhttp3/ConnectionSpec$Builder;", "")]
			public unsafe Builder TlsVersions(params TlsVersion[] tlsVersions)
			{
				IntPtr intPtr = JNIEnv.NewArray(tlsVersions);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("tlsVersions.([Lokhttp3/TlsVersion;)Lokhttp3/ConnectionSpec$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (tlsVersions != null)
					{
						JNIEnv.CopyArray(intPtr, tlsVersions);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(tlsVersions);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/ConnectionSpec", typeof(ConnectionSpec));

		[Register("CLEARTEXT")]
		public static ConnectionSpec Cleartext => Java.Lang.Object.GetObject<ConnectionSpec>(_members.StaticFields.GetObjectValue("CLEARTEXT.Lokhttp3/ConnectionSpec;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("COMPATIBLE_TLS")]
		public static ConnectionSpec CompatibleTls => Java.Lang.Object.GetObject<ConnectionSpec>(_members.StaticFields.GetObjectValue("COMPATIBLE_TLS.Lokhttp3/ConnectionSpec;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MODERN_TLS")]
		public static ConnectionSpec ModernTls => Java.Lang.Object.GetObject<ConnectionSpec>(_members.StaticFields.GetObjectValue("MODERN_TLS.Lokhttp3/ConnectionSpec;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESTRICTED_TLS")]
		public static ConnectionSpec RestrictedTls => Java.Lang.Object.GetObject<ConnectionSpec>(_members.StaticFields.GetObjectValue("RESTRICTED_TLS.Lokhttp3/ConnectionSpec;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsTls
		{
			[Register("isTls", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isTls.()Z", this, null);
			}
		}

		internal ConnectionSpec(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("cipherSuites", "()Ljava/util/List;", "")]
		public unsafe IList<CipherSuite> CipherSuites()
		{
			return JavaList<CipherSuite>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cipherSuites.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("isCompatible", "(Ljavax/net/ssl/SSLSocket;)Z", "")]
		public unsafe bool IsCompatible(SSLSocket socket)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(socket?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isCompatible.(Ljavax/net/ssl/SSLSocket;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(socket);
			}
		}

		[Register("supportsTlsExtensions", "()Z", "")]
		public unsafe bool SupportsTlsExtensions()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("supportsTlsExtensions.()Z", this, null);
		}

		[Register("tlsVersions", "()Ljava/util/List;", "")]
		public unsafe IList<TlsVersion> TlsVersions()
		{
			return JavaList<TlsVersion>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("tlsVersions.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/Cookie", DoNotGenerateAcw = true)]
	public sealed class Cookie : Java.Lang.Object
	{
		[Register("okhttp3/Cookie$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Cookie$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			[Register("build", "()Lokhttp3/Cookie;", "")]
			public unsafe Cookie Build()
			{
				return Java.Lang.Object.GetObject<Cookie>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lokhttp3/Cookie;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("domain", "(Ljava/lang/String;)Lokhttp3/Cookie$Builder;", "")]
			public unsafe Builder Domain(string domain)
			{
				IntPtr intPtr = JNIEnv.NewString(domain);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("domain.(Ljava/lang/String;)Lokhttp3/Cookie$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("expiresAt", "(J)Lokhttp3/Cookie$Builder;", "")]
			public unsafe Builder ExpiresAt(long expiresAt)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(expiresAt);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("expiresAt.(J)Lokhttp3/Cookie$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("hostOnlyDomain", "(Ljava/lang/String;)Lokhttp3/Cookie$Builder;", "")]
			public unsafe Builder HostOnlyDomain(string domain)
			{
				IntPtr intPtr = JNIEnv.NewString(domain);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hostOnlyDomain.(Ljava/lang/String;)Lokhttp3/Cookie$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("httpOnly", "()Lokhttp3/Cookie$Builder;", "")]
			public unsafe Builder HttpOnly()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("httpOnly.()Lokhttp3/Cookie$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("name", "(Ljava/lang/String;)Lokhttp3/Cookie$Builder;", "")]
			public unsafe Builder Name(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("name.(Ljava/lang/String;)Lokhttp3/Cookie$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("path", "(Ljava/lang/String;)Lokhttp3/Cookie$Builder;", "")]
			public unsafe Builder Path(string path)
			{
				IntPtr intPtr = JNIEnv.NewString(path);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("path.(Ljava/lang/String;)Lokhttp3/Cookie$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("secure", "()Lokhttp3/Cookie$Builder;", "")]
			public unsafe Builder Secure()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("secure.()Lokhttp3/Cookie$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("value", "(Ljava/lang/String;)Lokhttp3/Cookie$Builder;", "")]
			public unsafe Builder Value(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("value.(Ljava/lang/String;)Lokhttp3/Cookie$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Cookie", typeof(Cookie));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Cookie(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("domain", "()Ljava/lang/String;", "")]
		public unsafe string Domain()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("domain.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("expiresAt", "()J", "")]
		public unsafe long ExpiresAt()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt64Method("expiresAt.()J", this, null);
		}

		[Register("hostOnly", "()Z", "")]
		public unsafe bool HostOnly()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hostOnly.()Z", this, null);
		}

		[Register("httpOnly", "()Z", "")]
		public unsafe bool HttpOnly()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("httpOnly.()Z", this, null);
		}

		[Register("matches", "(Lokhttp3/HttpUrl;)Z", "")]
		public unsafe bool Matches(HttpUrl url)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("matches.(Lokhttp3/HttpUrl;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(url);
			}
		}

		[Register("name", "()Ljava/lang/String;", "")]
		public unsafe string Name()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("name.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("parse", "(Lokhttp3/HttpUrl;Ljava/lang/String;)Lokhttp3/Cookie;", "")]
		public unsafe static Cookie Parse(HttpUrl url, string setCookie)
		{
			IntPtr intPtr = JNIEnv.NewString(setCookie);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Cookie>(_members.StaticMethods.InvokeObjectMethod("parse.(Lokhttp3/HttpUrl;Ljava/lang/String;)Lokhttp3/Cookie;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(url);
			}
		}

		[Register("parseAll", "(Lokhttp3/HttpUrl;Lokhttp3/Headers;)Ljava/util/List;", "")]
		public unsafe static IList<Cookie> ParseAll(HttpUrl url, Headers headers)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(headers?.Handle ?? IntPtr.Zero);
				return JavaList<Cookie>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("parseAll.(Lokhttp3/HttpUrl;Lokhttp3/Headers;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(url);
				GC.KeepAlive(headers);
			}
		}

		[Register("path", "()Ljava/lang/String;", "")]
		public unsafe string Path()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("path.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("persistent", "()Z", "")]
		public unsafe bool Persistent()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("persistent.()Z", this, null);
		}

		[Register("secure", "()Z", "")]
		public unsafe bool Secure()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("secure.()Z", this, null);
		}

		[Register("value", "()Ljava/lang/String;", "")]
		public unsafe string Value()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("value.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/Credentials", DoNotGenerateAcw = true)]
	public sealed class Credentials : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Credentials", typeof(Credentials));

		[Register("INSTANCE")]
		public static Credentials Instance => Java.Lang.Object.GetObject<Credentials>(_members.StaticFields.GetObjectValue("INSTANCE.Lokhttp3/Credentials;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Credentials(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("basic", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe static string Basic(string username, string password)
		{
			IntPtr intPtr = JNIEnv.NewString(username);
			IntPtr intPtr2 = JNIEnv.NewString(password);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("basic.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("basic", "(Ljava/lang/String;Ljava/lang/String;Ljava/nio/charset/Charset;)Ljava/lang/String;", "")]
		public unsafe static string Basic(string username, string password, Charset charset)
		{
			IntPtr intPtr = JNIEnv.NewString(username);
			IntPtr intPtr2 = JNIEnv.NewString(password);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(charset?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("basic.(Ljava/lang/String;Ljava/lang/String;Ljava/nio/charset/Charset;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(charset);
			}
		}
	}
	[Register("okhttp3/EventListener", DoNotGenerateAcw = true)]
	public abstract class EventListener : Java.Lang.Object
	{
		[Register("okhttp3/EventListener$Factory", "", "Square.OkHttp3.EventListener/IFactoryInvoker")]
		public interface IFactory : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("create", "(Lokhttp3/Call;)Lokhttp3/EventListener;", "GetCreate_Lokhttp3_Call_Handler:Square.OkHttp3.EventListener/IFactoryInvoker, Square.OkHttp3")]
			EventListener Create(ICall call);
		}

		[Register("okhttp3/EventListener$Factory", DoNotGenerateAcw = true)]
		internal class IFactoryInvoker : Java.Lang.Object, IFactory, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/EventListener$Factory", typeof(IFactoryInvoker));

			private IntPtr class_ref;

			private static Delegate cb_create_Lokhttp3_Call_;

			private IntPtr id_create_Lokhttp3_Call_;

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

			public static IFactory GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IFactory>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.EventListener.Factory'.");
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

			public IFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetCreate_Lokhttp3_Call_Handler()
			{
				if ((object)cb_create_Lokhttp3_Call_ == null)
				{
					cb_create_Lokhttp3_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Create_Lokhttp3_Call_));
				}
				return cb_create_Lokhttp3_Call_;
			}

			private static IntPtr n_Create_Lokhttp3_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_call)
			{
				IFactory factory = Java.Lang.Object.GetObject<IFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(factory.Create(call));
			}

			public unsafe EventListener Create(ICall call)
			{
				if (id_create_Lokhttp3_Call_ == IntPtr.Zero)
				{
					id_create_Lokhttp3_Call_ = JNIEnv.GetMethodID(class_ref, "create", "(Lokhttp3/Call;)Lokhttp3/EventListener;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				return Java.Lang.Object.GetObject<EventListener>(JNIEnv.CallObjectMethod(base.Handle, id_create_Lokhttp3_Call_, ptr), JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/EventListener", typeof(EventListener));

		private static Delegate cb_cacheConditionalHit_Lokhttp3_Call_Lokhttp3_Response_;

		private static Delegate cb_cacheHit_Lokhttp3_Call_Lokhttp3_Response_;

		private static Delegate cb_cacheMiss_Lokhttp3_Call_;

		private static Delegate cb_callEnd_Lokhttp3_Call_;

		private static Delegate cb_callFailed_Lokhttp3_Call_Ljava_io_IOException_;

		private static Delegate cb_callStart_Lokhttp3_Call_;

		private static Delegate cb_canceled_Lokhttp3_Call_;

		private static Delegate cb_connectEnd_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_;

		private static Delegate cb_connectFailed_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_Ljava_io_IOException_;

		private static Delegate cb_connectStart_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_;

		private static Delegate cb_connectionAcquired_Lokhttp3_Call_Lokhttp3_Connection_;

		private static Delegate cb_connectionReleased_Lokhttp3_Call_Lokhttp3_Connection_;

		private static Delegate cb_dnsEnd_Lokhttp3_Call_Ljava_lang_String_Ljava_util_List_;

		private static Delegate cb_dnsStart_Lokhttp3_Call_Ljava_lang_String_;

		private static Delegate cb_proxySelectEnd_Lokhttp3_Call_Lokhttp3_HttpUrl_Ljava_util_List_;

		private static Delegate cb_proxySelectStart_Lokhttp3_Call_Lokhttp3_HttpUrl_;

		private static Delegate cb_requestBodyEnd_Lokhttp3_Call_J;

		private static Delegate cb_requestBodyStart_Lokhttp3_Call_;

		private static Delegate cb_requestFailed_Lokhttp3_Call_Ljava_io_IOException_;

		private static Delegate cb_requestHeadersEnd_Lokhttp3_Call_Lokhttp3_Request_;

		private static Delegate cb_requestHeadersStart_Lokhttp3_Call_;

		private static Delegate cb_responseBodyEnd_Lokhttp3_Call_J;

		private static Delegate cb_responseBodyStart_Lokhttp3_Call_;

		private static Delegate cb_responseFailed_Lokhttp3_Call_Ljava_io_IOException_;

		private static Delegate cb_responseHeadersEnd_Lokhttp3_Call_Lokhttp3_Response_;

		private static Delegate cb_responseHeadersStart_Lokhttp3_Call_;

		private static Delegate cb_satisfactionFailure_Lokhttp3_Call_Lokhttp3_Response_;

		private static Delegate cb_secureConnectEnd_Lokhttp3_Call_Lokhttp3_Handshake_;

		private static Delegate cb_secureConnectStart_Lokhttp3_Call_;

		[Register("NONE")]
		public static EventListener None => Java.Lang.Object.GetObject<EventListener>(_members.StaticFields.GetObjectValue("NONE.Lokhttp3/EventListener;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected EventListener(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EventListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCacheConditionalHit_Lokhttp3_Call_Lokhttp3_Response_Handler()
		{
			if ((object)cb_cacheConditionalHit_Lokhttp3_Call_Lokhttp3_Response_ == null)
			{
				cb_cacheConditionalHit_Lokhttp3_Call_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_CacheConditionalHit_Lokhttp3_Call_Lokhttp3_Response_));
			}
			return cb_cacheConditionalHit_Lokhttp3_Call_Lokhttp3_Response_;
		}

		private static void n_CacheConditionalHit_Lokhttp3_Call_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_cachedResponse)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Response cachedResponse = Java.Lang.Object.GetObject<Response>(native_cachedResponse, JniHandleOwnership.DoNotTransfer);
			eventListener.CacheConditionalHit(call, cachedResponse);
		}

		[Register("cacheConditionalHit", "(Lokhttp3/Call;Lokhttp3/Response;)V", "GetCacheConditionalHit_Lokhttp3_Call_Lokhttp3_Response_Handler")]
		public unsafe virtual void CacheConditionalHit(ICall call, Response cachedResponse)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(cachedResponse?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("cacheConditionalHit.(Lokhttp3/Call;Lokhttp3/Response;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(cachedResponse);
			}
		}

		private static Delegate GetCacheHit_Lokhttp3_Call_Lokhttp3_Response_Handler()
		{
			if ((object)cb_cacheHit_Lokhttp3_Call_Lokhttp3_Response_ == null)
			{
				cb_cacheHit_Lokhttp3_Call_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_CacheHit_Lokhttp3_Call_Lokhttp3_Response_));
			}
			return cb_cacheHit_Lokhttp3_Call_Lokhttp3_Response_;
		}

		private static void n_CacheHit_Lokhttp3_Call_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_response)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Response response = Java.Lang.Object.GetObject<Response>(native_response, JniHandleOwnership.DoNotTransfer);
			eventListener.CacheHit(call, response);
		}

		[Register("cacheHit", "(Lokhttp3/Call;Lokhttp3/Response;)V", "GetCacheHit_Lokhttp3_Call_Lokhttp3_Response_Handler")]
		public unsafe virtual void CacheHit(ICall call, Response response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("cacheHit.(Lokhttp3/Call;Lokhttp3/Response;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(response);
			}
		}

		private static Delegate GetCacheMiss_Lokhttp3_Call_Handler()
		{
			if ((object)cb_cacheMiss_Lokhttp3_Call_ == null)
			{
				cb_cacheMiss_Lokhttp3_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CacheMiss_Lokhttp3_Call_));
			}
			return cb_cacheMiss_Lokhttp3_Call_;
		}

		private static void n_CacheMiss_Lokhttp3_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_call)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.CacheMiss(call);
		}

		[Register("cacheMiss", "(Lokhttp3/Call;)V", "GetCacheMiss_Lokhttp3_Call_Handler")]
		public unsafe virtual void CacheMiss(ICall call)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("cacheMiss.(Lokhttp3/Call;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetCallEnd_Lokhttp3_Call_Handler()
		{
			if ((object)cb_callEnd_Lokhttp3_Call_ == null)
			{
				cb_callEnd_Lokhttp3_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CallEnd_Lokhttp3_Call_));
			}
			return cb_callEnd_Lokhttp3_Call_;
		}

		private static void n_CallEnd_Lokhttp3_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_call)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.CallEnd(call);
		}

		[Register("callEnd", "(Lokhttp3/Call;)V", "GetCallEnd_Lokhttp3_Call_Handler")]
		public unsafe virtual void CallEnd(ICall call)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("callEnd.(Lokhttp3/Call;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetCallFailed_Lokhttp3_Call_Ljava_io_IOException_Handler()
		{
			if ((object)cb_callFailed_Lokhttp3_Call_Ljava_io_IOException_ == null)
			{
				cb_callFailed_Lokhttp3_Call_Ljava_io_IOException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_CallFailed_Lokhttp3_Call_Ljava_io_IOException_));
			}
			return cb_callFailed_Lokhttp3_Call_Ljava_io_IOException_;
		}

		private static void n_CallFailed_Lokhttp3_Call_Ljava_io_IOException_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_ioe)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Java.IO.IOException ioe = Java.Lang.Object.GetObject<Java.IO.IOException>(native_ioe, JniHandleOwnership.DoNotTransfer);
			eventListener.CallFailed(call, ioe);
		}

		[Register("callFailed", "(Lokhttp3/Call;Ljava/io/IOException;)V", "GetCallFailed_Lokhttp3_Call_Ljava_io_IOException_Handler")]
		public unsafe virtual void CallFailed(ICall call, Java.IO.IOException ioe)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(ioe?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("callFailed.(Lokhttp3/Call;Ljava/io/IOException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(ioe);
			}
		}

		private static Delegate GetCallStart_Lokhttp3_Call_Handler()
		{
			if ((object)cb_callStart_Lokhttp3_Call_ == null)
			{
				cb_callStart_Lokhttp3_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CallStart_Lokhttp3_Call_));
			}
			return cb_callStart_Lokhttp3_Call_;
		}

		private static void n_CallStart_Lokhttp3_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_call)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.CallStart(call);
		}

		[Register("callStart", "(Lokhttp3/Call;)V", "GetCallStart_Lokhttp3_Call_Handler")]
		public unsafe virtual void CallStart(ICall call)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("callStart.(Lokhttp3/Call;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetCanceled_Lokhttp3_Call_Handler()
		{
			if ((object)cb_canceled_Lokhttp3_Call_ == null)
			{
				cb_canceled_Lokhttp3_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Canceled_Lokhttp3_Call_));
			}
			return cb_canceled_Lokhttp3_Call_;
		}

		private static void n_Canceled_Lokhttp3_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_call)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.Canceled(call);
		}

		[Register("canceled", "(Lokhttp3/Call;)V", "GetCanceled_Lokhttp3_Call_Handler")]
		public unsafe virtual void Canceled(ICall call)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("canceled.(Lokhttp3/Call;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetConnectEnd_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_Handler()
		{
			if ((object)cb_connectEnd_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_ == null)
			{
				cb_connectEnd_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_ConnectEnd_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_));
			}
			return cb_connectEnd_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_;
		}

		private static void n_ConnectEnd_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_inetSocketAddress, IntPtr native_proxy, IntPtr native_protocol)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			InetSocketAddress inetSocketAddress = Java.Lang.Object.GetObject<InetSocketAddress>(native_inetSocketAddress, JniHandleOwnership.DoNotTransfer);
			Proxy proxy = Java.Lang.Object.GetObject<Proxy>(native_proxy, JniHandleOwnership.DoNotTransfer);
			Protocol protocol = Java.Lang.Object.GetObject<Protocol>(native_protocol, JniHandleOwnership.DoNotTransfer);
			eventListener.ConnectEnd(call, inetSocketAddress, proxy, protocol);
		}

		[Register("connectEnd", "(Lokhttp3/Call;Ljava/net/InetSocketAddress;Ljava/net/Proxy;Lokhttp3/Protocol;)V", "GetConnectEnd_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_Handler")]
		public unsafe virtual void ConnectEnd(ICall call, InetSocketAddress inetSocketAddress, Proxy proxy, Protocol protocol)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(inetSocketAddress?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(proxy?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(protocol?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("connectEnd.(Lokhttp3/Call;Ljava/net/InetSocketAddress;Ljava/net/Proxy;Lokhttp3/Protocol;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(inetSocketAddress);
				GC.KeepAlive(proxy);
				GC.KeepAlive(protocol);
			}
		}

		private static Delegate GetConnectFailed_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_Ljava_io_IOException_Handler()
		{
			if ((object)cb_connectFailed_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_Ljava_io_IOException_ == null)
			{
				cb_connectFailed_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_Ljava_io_IOException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLLL_V(n_ConnectFailed_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_Ljava_io_IOException_));
			}
			return cb_connectFailed_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_Ljava_io_IOException_;
		}

		private static void n_ConnectFailed_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_Ljava_io_IOException_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_inetSocketAddress, IntPtr native_proxy, IntPtr native_protocol, IntPtr native_ioe)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			InetSocketAddress inetSocketAddress = Java.Lang.Object.GetObject<InetSocketAddress>(native_inetSocketAddress, JniHandleOwnership.DoNotTransfer);
			Proxy proxy = Java.Lang.Object.GetObject<Proxy>(native_proxy, JniHandleOwnership.DoNotTransfer);
			Protocol protocol = Java.Lang.Object.GetObject<Protocol>(native_protocol, JniHandleOwnership.DoNotTransfer);
			Java.IO.IOException ioe = Java.Lang.Object.GetObject<Java.IO.IOException>(native_ioe, JniHandleOwnership.DoNotTransfer);
			eventListener.ConnectFailed(call, inetSocketAddress, proxy, protocol, ioe);
		}

		[Register("connectFailed", "(Lokhttp3/Call;Ljava/net/InetSocketAddress;Ljava/net/Proxy;Lokhttp3/Protocol;Ljava/io/IOException;)V", "GetConnectFailed_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Lokhttp3_Protocol_Ljava_io_IOException_Handler")]
		public unsafe virtual void ConnectFailed(ICall call, InetSocketAddress inetSocketAddress, Proxy proxy, Protocol protocol, Java.IO.IOException ioe)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(inetSocketAddress?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(proxy?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(protocol?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(ioe?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("connectFailed.(Lokhttp3/Call;Ljava/net/InetSocketAddress;Ljava/net/Proxy;Lokhttp3/Protocol;Ljava/io/IOException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(inetSocketAddress);
				GC.KeepAlive(proxy);
				GC.KeepAlive(protocol);
				GC.KeepAlive(ioe);
			}
		}

		private static Delegate GetConnectStart_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Handler()
		{
			if ((object)cb_connectStart_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_ == null)
			{
				cb_connectStart_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_ConnectStart_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_));
			}
			return cb_connectStart_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_;
		}

		private static void n_ConnectStart_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_inetSocketAddress, IntPtr native_proxy)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			InetSocketAddress inetSocketAddress = Java.Lang.Object.GetObject<InetSocketAddress>(native_inetSocketAddress, JniHandleOwnership.DoNotTransfer);
			Proxy proxy = Java.Lang.Object.GetObject<Proxy>(native_proxy, JniHandleOwnership.DoNotTransfer);
			eventListener.ConnectStart(call, inetSocketAddress, proxy);
		}

		[Register("connectStart", "(Lokhttp3/Call;Ljava/net/InetSocketAddress;Ljava/net/Proxy;)V", "GetConnectStart_Lokhttp3_Call_Ljava_net_InetSocketAddress_Ljava_net_Proxy_Handler")]
		public unsafe virtual void ConnectStart(ICall call, InetSocketAddress inetSocketAddress, Proxy proxy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(inetSocketAddress?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(proxy?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("connectStart.(Lokhttp3/Call;Ljava/net/InetSocketAddress;Ljava/net/Proxy;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(inetSocketAddress);
				GC.KeepAlive(proxy);
			}
		}

		private static Delegate GetConnectionAcquired_Lokhttp3_Call_Lokhttp3_Connection_Handler()
		{
			if ((object)cb_connectionAcquired_Lokhttp3_Call_Lokhttp3_Connection_ == null)
			{
				cb_connectionAcquired_Lokhttp3_Call_Lokhttp3_Connection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ConnectionAcquired_Lokhttp3_Call_Lokhttp3_Connection_));
			}
			return cb_connectionAcquired_Lokhttp3_Call_Lokhttp3_Connection_;
		}

		private static void n_ConnectionAcquired_Lokhttp3_Call_Lokhttp3_Connection_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_connection)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			IConnection connection = Java.Lang.Object.GetObject<IConnection>(native_connection, JniHandleOwnership.DoNotTransfer);
			eventListener.ConnectionAcquired(call, connection);
		}

		[Register("connectionAcquired", "(Lokhttp3/Call;Lokhttp3/Connection;)V", "GetConnectionAcquired_Lokhttp3_Call_Lokhttp3_Connection_Handler")]
		public unsafe virtual void ConnectionAcquired(ICall call, IConnection connection)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue((connection == null) ? IntPtr.Zero : ((Java.Lang.Object)connection).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("connectionAcquired.(Lokhttp3/Call;Lokhttp3/Connection;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(connection);
			}
		}

		private static Delegate GetConnectionReleased_Lokhttp3_Call_Lokhttp3_Connection_Handler()
		{
			if ((object)cb_connectionReleased_Lokhttp3_Call_Lokhttp3_Connection_ == null)
			{
				cb_connectionReleased_Lokhttp3_Call_Lokhttp3_Connection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ConnectionReleased_Lokhttp3_Call_Lokhttp3_Connection_));
			}
			return cb_connectionReleased_Lokhttp3_Call_Lokhttp3_Connection_;
		}

		private static void n_ConnectionReleased_Lokhttp3_Call_Lokhttp3_Connection_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_connection)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			IConnection connection = Java.Lang.Object.GetObject<IConnection>(native_connection, JniHandleOwnership.DoNotTransfer);
			eventListener.ConnectionReleased(call, connection);
		}

		[Register("connectionReleased", "(Lokhttp3/Call;Lokhttp3/Connection;)V", "GetConnectionReleased_Lokhttp3_Call_Lokhttp3_Connection_Handler")]
		public unsafe virtual void ConnectionReleased(ICall call, IConnection connection)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue((connection == null) ? IntPtr.Zero : ((Java.Lang.Object)connection).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("connectionReleased.(Lokhttp3/Call;Lokhttp3/Connection;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(connection);
			}
		}

		private static Delegate GetDnsEnd_Lokhttp3_Call_Ljava_lang_String_Ljava_util_List_Handler()
		{
			if ((object)cb_dnsEnd_Lokhttp3_Call_Ljava_lang_String_Ljava_util_List_ == null)
			{
				cb_dnsEnd_Lokhttp3_Call_Ljava_lang_String_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_DnsEnd_Lokhttp3_Call_Ljava_lang_String_Ljava_util_List_));
			}
			return cb_dnsEnd_Lokhttp3_Call_Ljava_lang_String_Ljava_util_List_;
		}

		private static void n_DnsEnd_Lokhttp3_Call_Ljava_lang_String_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_domainName, IntPtr native_inetAddressList)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			string domainName = JNIEnv.GetString(native_domainName, JniHandleOwnership.DoNotTransfer);
			IList<InetAddress> inetAddressList = JavaList<InetAddress>.FromJniHandle(native_inetAddressList, JniHandleOwnership.DoNotTransfer);
			eventListener.DnsEnd(call, domainName, inetAddressList);
		}

		[Register("dnsEnd", "(Lokhttp3/Call;Ljava/lang/String;Ljava/util/List;)V", "GetDnsEnd_Lokhttp3_Call_Ljava_lang_String_Ljava_util_List_Handler")]
		public unsafe virtual void DnsEnd(ICall call, string domainName, IList<InetAddress> inetAddressList)
		{
			IntPtr intPtr = JNIEnv.NewString(domainName);
			IntPtr intPtr2 = JavaList<InetAddress>.ToLocalJniHandle(inetAddressList);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("dnsEnd.(Lokhttp3/Call;Ljava/lang/String;Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(call);
				GC.KeepAlive(inetAddressList);
			}
		}

		private static Delegate GetDnsStart_Lokhttp3_Call_Ljava_lang_String_Handler()
		{
			if ((object)cb_dnsStart_Lokhttp3_Call_Ljava_lang_String_ == null)
			{
				cb_dnsStart_Lokhttp3_Call_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_DnsStart_Lokhttp3_Call_Ljava_lang_String_));
			}
			return cb_dnsStart_Lokhttp3_Call_Ljava_lang_String_;
		}

		private static void n_DnsStart_Lokhttp3_Call_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_domainName)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			string domainName = JNIEnv.GetString(native_domainName, JniHandleOwnership.DoNotTransfer);
			eventListener.DnsStart(call, domainName);
		}

		[Register("dnsStart", "(Lokhttp3/Call;Ljava/lang/String;)V", "GetDnsStart_Lokhttp3_Call_Ljava_lang_String_Handler")]
		public unsafe virtual void DnsStart(ICall call, string domainName)
		{
			IntPtr intPtr = JNIEnv.NewString(domainName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("dnsStart.(Lokhttp3/Call;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetProxySelectEnd_Lokhttp3_Call_Lokhttp3_HttpUrl_Ljava_util_List_Handler()
		{
			if ((object)cb_proxySelectEnd_Lokhttp3_Call_Lokhttp3_HttpUrl_Ljava_util_List_ == null)
			{
				cb_proxySelectEnd_Lokhttp3_Call_Lokhttp3_HttpUrl_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_ProxySelectEnd_Lokhttp3_Call_Lokhttp3_HttpUrl_Ljava_util_List_));
			}
			return cb_proxySelectEnd_Lokhttp3_Call_Lokhttp3_HttpUrl_Ljava_util_List_;
		}

		private static void n_ProxySelectEnd_Lokhttp3_Call_Lokhttp3_HttpUrl_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_url, IntPtr native_proxies)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			HttpUrl url = Java.Lang.Object.GetObject<HttpUrl>(native_url, JniHandleOwnership.DoNotTransfer);
			IList<Proxy> proxies = JavaList<Proxy>.FromJniHandle(native_proxies, JniHandleOwnership.DoNotTransfer);
			eventListener.ProxySelectEnd(call, url, proxies);
		}

		[Register("proxySelectEnd", "(Lokhttp3/Call;Lokhttp3/HttpUrl;Ljava/util/List;)V", "GetProxySelectEnd_Lokhttp3_Call_Lokhttp3_HttpUrl_Ljava_util_List_Handler")]
		public unsafe virtual void ProxySelectEnd(ICall call, HttpUrl url, IList<Proxy> proxies)
		{
			IntPtr intPtr = JavaList<Proxy>.ToLocalJniHandle(proxies);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("proxySelectEnd.(Lokhttp3/Call;Lokhttp3/HttpUrl;Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(call);
				GC.KeepAlive(url);
				GC.KeepAlive(proxies);
			}
		}

		private static Delegate GetProxySelectStart_Lokhttp3_Call_Lokhttp3_HttpUrl_Handler()
		{
			if ((object)cb_proxySelectStart_Lokhttp3_Call_Lokhttp3_HttpUrl_ == null)
			{
				cb_proxySelectStart_Lokhttp3_Call_Lokhttp3_HttpUrl_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ProxySelectStart_Lokhttp3_Call_Lokhttp3_HttpUrl_));
			}
			return cb_proxySelectStart_Lokhttp3_Call_Lokhttp3_HttpUrl_;
		}

		private static void n_ProxySelectStart_Lokhttp3_Call_Lokhttp3_HttpUrl_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_url)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			HttpUrl url = Java.Lang.Object.GetObject<HttpUrl>(native_url, JniHandleOwnership.DoNotTransfer);
			eventListener.ProxySelectStart(call, url);
		}

		[Register("proxySelectStart", "(Lokhttp3/Call;Lokhttp3/HttpUrl;)V", "GetProxySelectStart_Lokhttp3_Call_Lokhttp3_HttpUrl_Handler")]
		public unsafe virtual void ProxySelectStart(ICall call, HttpUrl url)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("proxySelectStart.(Lokhttp3/Call;Lokhttp3/HttpUrl;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(url);
			}
		}

		private static Delegate GetRequestBodyEnd_Lokhttp3_Call_JHandler()
		{
			if ((object)cb_requestBodyEnd_Lokhttp3_Call_J == null)
			{
				cb_requestBodyEnd_Lokhttp3_Call_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_V(n_RequestBodyEnd_Lokhttp3_Call_J));
			}
			return cb_requestBodyEnd_Lokhttp3_Call_J;
		}

		private static void n_RequestBodyEnd_Lokhttp3_Call_J(IntPtr jnienv, IntPtr native__this, IntPtr native_call, long byteCount)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.RequestBodyEnd(call, byteCount);
		}

		[Register("requestBodyEnd", "(Lokhttp3/Call;J)V", "GetRequestBodyEnd_Lokhttp3_Call_JHandler")]
		public unsafe virtual void RequestBodyEnd(ICall call, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(byteCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("requestBodyEnd.(Lokhttp3/Call;J)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetRequestBodyStart_Lokhttp3_Call_Handler()
		{
			if ((object)cb_requestBodyStart_Lokhttp3_Call_ == null)
			{
				cb_requestBodyStart_Lokhttp3_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RequestBodyStart_Lokhttp3_Call_));
			}
			return cb_requestBodyStart_Lokhttp3_Call_;
		}

		private static void n_RequestBodyStart_Lokhttp3_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_call)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.RequestBodyStart(call);
		}

		[Register("requestBodyStart", "(Lokhttp3/Call;)V", "GetRequestBodyStart_Lokhttp3_Call_Handler")]
		public unsafe virtual void RequestBodyStart(ICall call)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("requestBodyStart.(Lokhttp3/Call;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetRequestFailed_Lokhttp3_Call_Ljava_io_IOException_Handler()
		{
			if ((object)cb_requestFailed_Lokhttp3_Call_Ljava_io_IOException_ == null)
			{
				cb_requestFailed_Lokhttp3_Call_Ljava_io_IOException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RequestFailed_Lokhttp3_Call_Ljava_io_IOException_));
			}
			return cb_requestFailed_Lokhttp3_Call_Ljava_io_IOException_;
		}

		private static void n_RequestFailed_Lokhttp3_Call_Ljava_io_IOException_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_ioe)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Java.IO.IOException ioe = Java.Lang.Object.GetObject<Java.IO.IOException>(native_ioe, JniHandleOwnership.DoNotTransfer);
			eventListener.RequestFailed(call, ioe);
		}

		[Register("requestFailed", "(Lokhttp3/Call;Ljava/io/IOException;)V", "GetRequestFailed_Lokhttp3_Call_Ljava_io_IOException_Handler")]
		public unsafe virtual void RequestFailed(ICall call, Java.IO.IOException ioe)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(ioe?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("requestFailed.(Lokhttp3/Call;Ljava/io/IOException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(ioe);
			}
		}

		private static Delegate GetRequestHeadersEnd_Lokhttp3_Call_Lokhttp3_Request_Handler()
		{
			if ((object)cb_requestHeadersEnd_Lokhttp3_Call_Lokhttp3_Request_ == null)
			{
				cb_requestHeadersEnd_Lokhttp3_Call_Lokhttp3_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RequestHeadersEnd_Lokhttp3_Call_Lokhttp3_Request_));
			}
			return cb_requestHeadersEnd_Lokhttp3_Call_Lokhttp3_Request_;
		}

		private static void n_RequestHeadersEnd_Lokhttp3_Call_Lokhttp3_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_request)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Request request = Java.Lang.Object.GetObject<Request>(native_request, JniHandleOwnership.DoNotTransfer);
			eventListener.RequestHeadersEnd(call, request);
		}

		[Register("requestHeadersEnd", "(Lokhttp3/Call;Lokhttp3/Request;)V", "GetRequestHeadersEnd_Lokhttp3_Call_Lokhttp3_Request_Handler")]
		public unsafe virtual void RequestHeadersEnd(ICall call, Request request)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("requestHeadersEnd.(Lokhttp3/Call;Lokhttp3/Request;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(request);
			}
		}

		private static Delegate GetRequestHeadersStart_Lokhttp3_Call_Handler()
		{
			if ((object)cb_requestHeadersStart_Lokhttp3_Call_ == null)
			{
				cb_requestHeadersStart_Lokhttp3_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RequestHeadersStart_Lokhttp3_Call_));
			}
			return cb_requestHeadersStart_Lokhttp3_Call_;
		}

		private static void n_RequestHeadersStart_Lokhttp3_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_call)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.RequestHeadersStart(call);
		}

		[Register("requestHeadersStart", "(Lokhttp3/Call;)V", "GetRequestHeadersStart_Lokhttp3_Call_Handler")]
		public unsafe virtual void RequestHeadersStart(ICall call)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("requestHeadersStart.(Lokhttp3/Call;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetResponseBodyEnd_Lokhttp3_Call_JHandler()
		{
			if ((object)cb_responseBodyEnd_Lokhttp3_Call_J == null)
			{
				cb_responseBodyEnd_Lokhttp3_Call_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_V(n_ResponseBodyEnd_Lokhttp3_Call_J));
			}
			return cb_responseBodyEnd_Lokhttp3_Call_J;
		}

		private static void n_ResponseBodyEnd_Lokhttp3_Call_J(IntPtr jnienv, IntPtr native__this, IntPtr native_call, long byteCount)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.ResponseBodyEnd(call, byteCount);
		}

		[Register("responseBodyEnd", "(Lokhttp3/Call;J)V", "GetResponseBodyEnd_Lokhttp3_Call_JHandler")]
		public unsafe virtual void ResponseBodyEnd(ICall call, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(byteCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("responseBodyEnd.(Lokhttp3/Call;J)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetResponseBodyStart_Lokhttp3_Call_Handler()
		{
			if ((object)cb_responseBodyStart_Lokhttp3_Call_ == null)
			{
				cb_responseBodyStart_Lokhttp3_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ResponseBodyStart_Lokhttp3_Call_));
			}
			return cb_responseBodyStart_Lokhttp3_Call_;
		}

		private static void n_ResponseBodyStart_Lokhttp3_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_call)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.ResponseBodyStart(call);
		}

		[Register("responseBodyStart", "(Lokhttp3/Call;)V", "GetResponseBodyStart_Lokhttp3_Call_Handler")]
		public unsafe virtual void ResponseBodyStart(ICall call)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("responseBodyStart.(Lokhttp3/Call;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetResponseFailed_Lokhttp3_Call_Ljava_io_IOException_Handler()
		{
			if ((object)cb_responseFailed_Lokhttp3_Call_Ljava_io_IOException_ == null)
			{
				cb_responseFailed_Lokhttp3_Call_Ljava_io_IOException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ResponseFailed_Lokhttp3_Call_Ljava_io_IOException_));
			}
			return cb_responseFailed_Lokhttp3_Call_Ljava_io_IOException_;
		}

		private static void n_ResponseFailed_Lokhttp3_Call_Ljava_io_IOException_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_ioe)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Java.IO.IOException ioe = Java.Lang.Object.GetObject<Java.IO.IOException>(native_ioe, JniHandleOwnership.DoNotTransfer);
			eventListener.ResponseFailed(call, ioe);
		}

		[Register("responseFailed", "(Lokhttp3/Call;Ljava/io/IOException;)V", "GetResponseFailed_Lokhttp3_Call_Ljava_io_IOException_Handler")]
		public unsafe virtual void ResponseFailed(ICall call, Java.IO.IOException ioe)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(ioe?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("responseFailed.(Lokhttp3/Call;Ljava/io/IOException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(ioe);
			}
		}

		private static Delegate GetResponseHeadersEnd_Lokhttp3_Call_Lokhttp3_Response_Handler()
		{
			if ((object)cb_responseHeadersEnd_Lokhttp3_Call_Lokhttp3_Response_ == null)
			{
				cb_responseHeadersEnd_Lokhttp3_Call_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ResponseHeadersEnd_Lokhttp3_Call_Lokhttp3_Response_));
			}
			return cb_responseHeadersEnd_Lokhttp3_Call_Lokhttp3_Response_;
		}

		private static void n_ResponseHeadersEnd_Lokhttp3_Call_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_response)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Response response = Java.Lang.Object.GetObject<Response>(native_response, JniHandleOwnership.DoNotTransfer);
			eventListener.ResponseHeadersEnd(call, response);
		}

		[Register("responseHeadersEnd", "(Lokhttp3/Call;Lokhttp3/Response;)V", "GetResponseHeadersEnd_Lokhttp3_Call_Lokhttp3_Response_Handler")]
		public unsafe virtual void ResponseHeadersEnd(ICall call, Response response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("responseHeadersEnd.(Lokhttp3/Call;Lokhttp3/Response;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(response);
			}
		}

		private static Delegate GetResponseHeadersStart_Lokhttp3_Call_Handler()
		{
			if ((object)cb_responseHeadersStart_Lokhttp3_Call_ == null)
			{
				cb_responseHeadersStart_Lokhttp3_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ResponseHeadersStart_Lokhttp3_Call_));
			}
			return cb_responseHeadersStart_Lokhttp3_Call_;
		}

		private static void n_ResponseHeadersStart_Lokhttp3_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_call)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.ResponseHeadersStart(call);
		}

		[Register("responseHeadersStart", "(Lokhttp3/Call;)V", "GetResponseHeadersStart_Lokhttp3_Call_Handler")]
		public unsafe virtual void ResponseHeadersStart(ICall call)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("responseHeadersStart.(Lokhttp3/Call;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}

		private static Delegate GetSatisfactionFailure_Lokhttp3_Call_Lokhttp3_Response_Handler()
		{
			if ((object)cb_satisfactionFailure_Lokhttp3_Call_Lokhttp3_Response_ == null)
			{
				cb_satisfactionFailure_Lokhttp3_Call_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SatisfactionFailure_Lokhttp3_Call_Lokhttp3_Response_));
			}
			return cb_satisfactionFailure_Lokhttp3_Call_Lokhttp3_Response_;
		}

		private static void n_SatisfactionFailure_Lokhttp3_Call_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_response)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Response response = Java.Lang.Object.GetObject<Response>(native_response, JniHandleOwnership.DoNotTransfer);
			eventListener.SatisfactionFailure(call, response);
		}

		[Register("satisfactionFailure", "(Lokhttp3/Call;Lokhttp3/Response;)V", "GetSatisfactionFailure_Lokhttp3_Call_Lokhttp3_Response_Handler")]
		public unsafe virtual void SatisfactionFailure(ICall call, Response response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("satisfactionFailure.(Lokhttp3/Call;Lokhttp3/Response;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(response);
			}
		}

		private static Delegate GetSecureConnectEnd_Lokhttp3_Call_Lokhttp3_Handshake_Handler()
		{
			if ((object)cb_secureConnectEnd_Lokhttp3_Call_Lokhttp3_Handshake_ == null)
			{
				cb_secureConnectEnd_Lokhttp3_Call_Lokhttp3_Handshake_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SecureConnectEnd_Lokhttp3_Call_Lokhttp3_Handshake_));
			}
			return cb_secureConnectEnd_Lokhttp3_Call_Lokhttp3_Handshake_;
		}

		private static void n_SecureConnectEnd_Lokhttp3_Call_Lokhttp3_Handshake_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_handshake)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Handshake handshake = Java.Lang.Object.GetObject<Handshake>(native_handshake, JniHandleOwnership.DoNotTransfer);
			eventListener.SecureConnectEnd(call, handshake);
		}

		[Register("secureConnectEnd", "(Lokhttp3/Call;Lokhttp3/Handshake;)V", "GetSecureConnectEnd_Lokhttp3_Call_Lokhttp3_Handshake_Handler")]
		public unsafe virtual void SecureConnectEnd(ICall call, Handshake handshake)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				ptr[1] = new JniArgumentValue(handshake?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("secureConnectEnd.(Lokhttp3/Call;Lokhttp3/Handshake;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
				GC.KeepAlive(handshake);
			}
		}

		private static Delegate GetSecureConnectStart_Lokhttp3_Call_Handler()
		{
			if ((object)cb_secureConnectStart_Lokhttp3_Call_ == null)
			{
				cb_secureConnectStart_Lokhttp3_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SecureConnectStart_Lokhttp3_Call_));
			}
			return cb_secureConnectStart_Lokhttp3_Call_;
		}

		private static void n_SecureConnectStart_Lokhttp3_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_call)
		{
			EventListener eventListener = Java.Lang.Object.GetObject<EventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			eventListener.SecureConnectStart(call);
		}

		[Register("secureConnectStart", "(Lokhttp3/Call;)V", "GetSecureConnectStart_Lokhttp3_Call_Handler")]
		public unsafe virtual void SecureConnectStart(ICall call)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("secureConnectStart.(Lokhttp3/Call;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(call);
			}
		}
	}
	[Register("okhttp3/EventListener", DoNotGenerateAcw = true)]
	internal class EventListenerInvoker : EventListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/EventListener", typeof(EventListenerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public EventListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("okhttp3/FormBody", DoNotGenerateAcw = true)]
	public sealed class FormBody : RequestBody
	{
		[Register("okhttp3/FormBody$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/FormBody$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			[Register(".ctor", "(Ljava/nio/charset/Charset;)V", "")]
			public unsafe Builder(Charset charset)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(charset?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/nio/charset/Charset;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Ljava/nio/charset/Charset;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(charset);
				}
			}

			[Register("add", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/FormBody$Builder;", "")]
			public unsafe Builder Add(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/FormBody$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("addEncoded", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/FormBody$Builder;", "")]
			public unsafe Builder AddEncoded(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addEncoded.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/FormBody$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("build", "()Lokhttp3/FormBody;", "")]
			public unsafe FormBody Build()
			{
				return Java.Lang.Object.GetObject<FormBody>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lokhttp3/FormBody;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/FormBody", typeof(FormBody));

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

		internal FormBody(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("contentType", "()Lokhttp3/MediaType;", "")]
		public unsafe override MediaType ContentType()
		{
			return Java.Lang.Object.GetObject<MediaType>(_members.InstanceMethods.InvokeAbstractObjectMethod("contentType.()Lokhttp3/MediaType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("encodedName", "(I)Ljava/lang/String;", "")]
		public unsafe string EncodedName(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("encodedValue", "(I)Ljava/lang/String;", "")]
		public unsafe string EncodedValue(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedValue.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("name", "(I)Ljava/lang/String;", "")]
		public unsafe string Name(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("name.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("size", "()I", "")]
		public unsafe int Size()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("size.()I", this, null);
		}

		[Register("value", "(I)Ljava/lang/String;", "")]
		public unsafe string Value(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("value.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeTo", "(Lokio/BufferedSink;)V", "")]
		public unsafe override void WriteTo(IBufferedSink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeTo.(Lokio/BufferedSink;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}
	}
	[Register("okhttp3/Handshake", DoNotGenerateAcw = true)]
	public sealed class Handshake : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Handshake", typeof(Handshake));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Handshake(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("cipherSuite", "()Lokhttp3/CipherSuite;", "")]
		public unsafe CipherSuite CipherSuite()
		{
			return Java.Lang.Object.GetObject<CipherSuite>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cipherSuite.()Lokhttp3/CipherSuite;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("get", "(Ljavax/net/ssl/SSLSession;)Lokhttp3/Handshake;", "")]
		public unsafe static Handshake Get(ISSLSession session)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((session == null) ? IntPtr.Zero : ((Java.Lang.Object)session).Handle);
				return Java.Lang.Object.GetObject<Handshake>(_members.StaticMethods.InvokeObjectMethod("get.(Ljavax/net/ssl/SSLSession;)Lokhttp3/Handshake;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(session);
			}
		}

		[Register("get", "(Lokhttp3/TlsVersion;Lokhttp3/CipherSuite;Ljava/util/List;Ljava/util/List;)Lokhttp3/Handshake;", "")]
		public unsafe static Handshake Get(TlsVersion tlsVersion, CipherSuite cipherSuite, IList<Certificate> peerCertificates, IList<Certificate> localCertificates)
		{
			IntPtr intPtr = JavaList<Certificate>.ToLocalJniHandle(peerCertificates);
			IntPtr intPtr2 = JavaList<Certificate>.ToLocalJniHandle(localCertificates);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(tlsVersion?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(cipherSuite?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<Handshake>(_members.StaticMethods.InvokeObjectMethod("get.(Lokhttp3/TlsVersion;Lokhttp3/CipherSuite;Ljava/util/List;Ljava/util/List;)Lokhttp3/Handshake;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(tlsVersion);
				GC.KeepAlive(cipherSuite);
				GC.KeepAlive(peerCertificates);
				GC.KeepAlive(localCertificates);
			}
		}

		[Register("localCertificates", "()Ljava/util/List;", "")]
		public unsafe IList<Certificate> LocalCertificates()
		{
			return JavaList<Certificate>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("localCertificates.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("localPrincipal", "()Ljava/security/Principal;", "")]
		public unsafe IPrincipal LocalPrincipal()
		{
			return Java.Lang.Object.GetObject<IPrincipal>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("localPrincipal.()Ljava/security/Principal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("peerCertificates", "()Ljava/util/List;", "")]
		public unsafe IList<Certificate> PeerCertificates()
		{
			return JavaList<Certificate>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("peerCertificates.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("peerPrincipal", "()Ljava/security/Principal;", "")]
		public unsafe IPrincipal PeerPrincipal()
		{
			return Java.Lang.Object.GetObject<IPrincipal>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("peerPrincipal.()Ljava/security/Principal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("tlsVersion", "()Lokhttp3/TlsVersion;", "")]
		public unsafe TlsVersion TlsVersion()
		{
			return Java.Lang.Object.GetObject<TlsVersion>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("tlsVersion.()Lokhttp3/TlsVersion;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/Headers", DoNotGenerateAcw = true)]
	public sealed class Headers : Java.Lang.Object, IIterable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("okhttp3/Headers$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Headers$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			[Register("add", "(Ljava/lang/String;)Lokhttp3/Headers$Builder;", "")]
			public unsafe Builder Add(string line)
			{
				IntPtr intPtr = JNIEnv.NewString(line);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(Ljava/lang/String;)Lokhttp3/Headers$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("add", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Headers$Builder;", "")]
			public unsafe Builder Add(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Headers$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("add", "(Ljava/lang/String;Ljava/util/Date;)Lokhttp3/Headers$Builder;", "")]
			public unsafe Builder Add(string name, Date value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(Ljava/lang/String;Ljava/util/Date;)Lokhttp3/Headers$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}

			[Register("addAll", "(Lokhttp3/Headers;)Lokhttp3/Headers$Builder;", "")]
			public unsafe Builder AddAll(Headers headers)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(headers?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addAll.(Lokhttp3/Headers;)Lokhttp3/Headers$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(headers);
				}
			}

			[Register("addUnsafeNonAscii", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Headers$Builder;", "")]
			public unsafe Builder AddUnsafeNonAscii(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addUnsafeNonAscii.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Headers$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("build", "()Lokhttp3/Headers;", "")]
			public unsafe Headers Build()
			{
				return Java.Lang.Object.GetObject<Headers>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lokhttp3/Headers;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("get", "(Ljava/lang/String;)Ljava/lang/String;", "")]
			public unsafe string Get(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("get.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("removeAll", "(Ljava/lang/String;)Lokhttp3/Headers$Builder;", "")]
			public unsafe Builder RemoveAll(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("removeAll.(Ljava/lang/String;)Lokhttp3/Headers$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("set", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Headers$Builder;", "")]
			public unsafe Builder Set(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("set.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Headers$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("set", "(Ljava/lang/String;Ljava/util/Date;)Lokhttp3/Headers$Builder;", "")]
			public unsafe Builder Set(string name, Date value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("set.(Ljava/lang/String;Ljava/util/Date;)Lokhttp3/Headers$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Headers", typeof(Headers));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Headers(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("byteCount", "()J", "")]
		public unsafe long ByteCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt64Method("byteCount.()J", this, null);
		}

		[Register("get", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string Get(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("get.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getDate", "(Ljava/lang/String;)Ljava/util/Date;", "")]
		public unsafe Date GetDate(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDate.(Ljava/lang/String;)Ljava/util/Date;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("iterator", "()Ljava/util/Iterator;", "")]
		public unsafe IIterator Iterator()
		{
			return Java.Lang.Object.GetObject<IIterator>(_members.InstanceMethods.InvokeAbstractObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("name", "(I)Ljava/lang/String;", "")]
		public unsafe string Name(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("name.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("names", "()Ljava/util/Set;", "")]
		public unsafe ICollection<string> Names()
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("names.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("newBuilder", "()Lokhttp3/Headers$Builder;", "")]
		public unsafe Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("newBuilder.()Lokhttp3/Headers$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("of", "([Ljava/lang/String;)Lokhttp3/Headers;", "")]
		public unsafe static Headers Of(params string[] namesAndValues)
		{
			IntPtr intPtr = JNIEnv.NewArray(namesAndValues);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Headers>(_members.StaticMethods.InvokeObjectMethod("of.([Ljava/lang/String;)Lokhttp3/Headers;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (namesAndValues != null)
				{
					JNIEnv.CopyArray(intPtr, namesAndValues);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(namesAndValues);
			}
		}

		[Register("of", "(Ljava/util/Map;)Lokhttp3/Headers;", "")]
		public unsafe static Headers Of(IDictionary<string, string> headers)
		{
			IntPtr intPtr = JavaDictionary<string, string>.ToLocalJniHandle(headers);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Headers>(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/util/Map;)Lokhttp3/Headers;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(headers);
			}
		}

		[Register("size", "()I", "")]
		public unsafe int Size()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("size.()I", this, null);
		}

		[Register("toMultimap", "()Ljava/util/Map;", "")]
		public unsafe IDictionary<string, IList<string>> ToMultimap()
		{
			return JavaDictionary<string, IList<string>>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toMultimap.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("value", "(I)Ljava/lang/String;", "")]
		public unsafe string Value(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("value.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("values", "(Ljava/lang/String;)Ljava/util/List;", "")]
		public unsafe IList<string> Values(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("values.(Ljava/lang/String;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("okhttp3/HttpUrl", DoNotGenerateAcw = true)]
	public sealed class HttpUrl : Java.Lang.Object
	{
		[Register("okhttp3/HttpUrl$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			[Register("INVALID_HOST")]
			public const string InvalidHost = "Invalid URL host";

			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/HttpUrl$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			[Register("addEncodedPathSegment", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder AddEncodedPathSegment(string encodedPathSegment)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedPathSegment);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addEncodedPathSegment.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("addEncodedPathSegments", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder AddEncodedPathSegments(string encodedPathSegments)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedPathSegments);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addEncodedPathSegments.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("addEncodedQueryParameter", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder AddEncodedQueryParameter(string encodedName, string encodedValue)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedName);
				IntPtr intPtr2 = JNIEnv.NewString(encodedValue);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addEncodedQueryParameter.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("addPathSegment", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder AddPathSegment(string pathSegment)
			{
				IntPtr intPtr = JNIEnv.NewString(pathSegment);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addPathSegment.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("addPathSegments", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder AddPathSegments(string pathSegments)
			{
				IntPtr intPtr = JNIEnv.NewString(pathSegments);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addPathSegments.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("addQueryParameter", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder AddQueryParameter(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addQueryParameter.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("build", "()Lokhttp3/HttpUrl;", "")]
			public unsafe HttpUrl Build()
			{
				return Java.Lang.Object.GetObject<HttpUrl>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lokhttp3/HttpUrl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("encodedFragment", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder EncodedFragment(string encodedFragment)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedFragment);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedFragment.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("encodedPassword", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder EncodedPassword(string encodedPassword)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedPassword);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedPassword.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("encodedPath", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder EncodedPath(string encodedPath)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedPath);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedPath.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("encodedQuery", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder EncodedQuery(string encodedQuery)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedQuery);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedQuery.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("encodedUsername", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder EncodedUsername(string encodedUsername)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedUsername);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedUsername.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("fragment", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder Fragment(string fragment)
			{
				IntPtr intPtr = JNIEnv.NewString(fragment);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("fragment.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("host", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder Host(string host)
			{
				IntPtr intPtr = JNIEnv.NewString(host);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("host.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("password", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder Password(string password)
			{
				IntPtr intPtr = JNIEnv.NewString(password);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("password.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("port", "(I)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder Port(int port)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(port);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("port.(I)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("query", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder Query(string query)
			{
				IntPtr intPtr = JNIEnv.NewString(query);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("query.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("removeAllEncodedQueryParameters", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder RemoveAllEncodedQueryParameters(string encodedName)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedName);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("removeAllEncodedQueryParameters.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("removeAllQueryParameters", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder RemoveAllQueryParameters(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("removeAllQueryParameters.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("removePathSegment", "(I)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder RemovePathSegment(int index)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(index);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("removePathSegment.(I)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("scheme", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder Scheme(string scheme)
			{
				IntPtr intPtr = JNIEnv.NewString(scheme);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("scheme.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setEncodedPathSegment", "(ILjava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder SetEncodedPathSegment(int index, string encodedPathSegment)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedPathSegment);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(index);
					ptr[1] = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setEncodedPathSegment.(ILjava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setEncodedQueryParameter", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder SetEncodedQueryParameter(string encodedName, string encodedValue)
			{
				IntPtr intPtr = JNIEnv.NewString(encodedName);
				IntPtr intPtr2 = JNIEnv.NewString(encodedValue);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setEncodedQueryParameter.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("setPathSegment", "(ILjava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder SetPathSegment(int index, string pathSegment)
			{
				IntPtr intPtr = JNIEnv.NewString(pathSegment);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(index);
					ptr[1] = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setPathSegment.(ILjava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setQueryParameter", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder SetQueryParameter(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setQueryParameter.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("username", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
			public unsafe Builder Username(string username)
			{
				IntPtr intPtr = JNIEnv.NewString(username);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("username.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("FORM_ENCODE_SET")]
		public const string FormEncodeSet = " \"':;<=>@[]^`{}|/\\?#&!$(),~";

		[Register("FRAGMENT_ENCODE_SET")]
		public const string FragmentEncodeSet = "";

		[Register("FRAGMENT_ENCODE_SET_URI")]
		public const string FragmentEncodeSetUri = " \"#<>\\^`{|}";

		[Register("PASSWORD_ENCODE_SET")]
		public const string PasswordEncodeSet = " \"':;<=>@[]^`{}|/\\?#";

		[Register("PATH_SEGMENT_ENCODE_SET")]
		public const string PathSegmentEncodeSet = " \"<>^`{}|/\\?#";

		[Register("PATH_SEGMENT_ENCODE_SET_URI")]
		public const string PathSegmentEncodeSetUri = "[]";

		[Register("QUERY_COMPONENT_ENCODE_SET")]
		public const string QueryComponentEncodeSet = " !\"#$&'(),/:;<=>?@[]\\^`{|}~";

		[Register("QUERY_COMPONENT_ENCODE_SET_URI")]
		public const string QueryComponentEncodeSetUri = "\\^`{|}";

		[Register("QUERY_COMPONENT_REENCODE_SET")]
		public const string QueryComponentReencodeSet = " \"'<>#&=";

		[Register("QUERY_ENCODE_SET")]
		public const string QueryEncodeSet = " \"'<>#";

		[Register("USERNAME_ENCODE_SET")]
		public const string UsernameEncodeSet = " \"':;<=>@[]^`{}|/\\?#";

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/HttpUrl", typeof(HttpUrl));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsHttps
		{
			[Register("isHttps", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isHttps.()Z", this, null);
			}
		}

		internal HttpUrl(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("defaultPort", "(Ljava/lang/String;)I", "")]
		public unsafe static int DefaultPort(string scheme)
		{
			IntPtr intPtr = JNIEnv.NewString(scheme);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeInt32Method("defaultPort.(Ljava/lang/String;)I", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("encodedFragment", "()Ljava/lang/String;", "")]
		public unsafe string EncodedFragment()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedFragment.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("encodedPassword", "()Ljava/lang/String;", "")]
		public unsafe string EncodedPassword()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedPassword.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("encodedPath", "()Ljava/lang/String;", "")]
		public unsafe string EncodedPath()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedPath.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("encodedPathSegments", "()Ljava/util/List;", "")]
		public unsafe IList<string> EncodedPathSegments()
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedPathSegments.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("encodedQuery", "()Ljava/lang/String;", "")]
		public unsafe string EncodedQuery()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedQuery.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("encodedUsername", "()Ljava/lang/String;", "")]
		public unsafe string EncodedUsername()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodedUsername.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("fragment", "()Ljava/lang/String;", "")]
		public unsafe string Fragment()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("fragment.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("get", "(Ljava/lang/String;)Lokhttp3/HttpUrl;", "")]
		public unsafe static HttpUrl Get(string url)
		{
			IntPtr intPtr = JNIEnv.NewString(url);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<HttpUrl>(_members.StaticMethods.InvokeObjectMethod("get.(Ljava/lang/String;)Lokhttp3/HttpUrl;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("get", "(Ljava/net/URI;)Lokhttp3/HttpUrl;", "")]
		public unsafe static HttpUrl Get(URI uri)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HttpUrl>(_members.StaticMethods.InvokeObjectMethod("get.(Ljava/net/URI;)Lokhttp3/HttpUrl;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(uri);
			}
		}

		[Register("get", "(Ljava/net/URL;)Lokhttp3/HttpUrl;", "")]
		public unsafe static HttpUrl Get(URL url)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HttpUrl>(_members.StaticMethods.InvokeObjectMethod("get.(Ljava/net/URL;)Lokhttp3/HttpUrl;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(url);
			}
		}

		[Register("host", "()Ljava/lang/String;", "")]
		public unsafe string Host()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("host.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("newBuilder", "()Lokhttp3/HttpUrl$Builder;", "")]
		public unsafe Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("newBuilder.()Lokhttp3/HttpUrl$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("newBuilder", "(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", "")]
		public unsafe Builder NewBuilder(string link)
		{
			IntPtr intPtr = JNIEnv.NewString(link);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("newBuilder.(Ljava/lang/String;)Lokhttp3/HttpUrl$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("parse", "(Ljava/lang/String;)Lokhttp3/HttpUrl;", "")]
		public unsafe static HttpUrl Parse(string url)
		{
			IntPtr intPtr = JNIEnv.NewString(url);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<HttpUrl>(_members.StaticMethods.InvokeObjectMethod("parse.(Ljava/lang/String;)Lokhttp3/HttpUrl;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("password", "()Ljava/lang/String;", "")]
		public unsafe string Password()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("password.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("pathSegments", "()Ljava/util/List;", "")]
		public unsafe IList<string> PathSegments()
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("pathSegments.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("pathSize", "()I", "")]
		public unsafe int PathSize()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("pathSize.()I", this, null);
		}

		[Register("port", "()I", "")]
		public unsafe int Port()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("port.()I", this, null);
		}

		[Register("query", "()Ljava/lang/String;", "")]
		public unsafe string Query()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("query.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("queryParameter", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string QueryParameter(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("queryParameter.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("queryParameterName", "(I)Ljava/lang/String;", "")]
		public unsafe string QueryParameterName(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("queryParameterName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("queryParameterNames", "()Ljava/util/Set;", "")]
		public unsafe ICollection<string> QueryParameterNames()
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("queryParameterNames.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("queryParameterValue", "(I)Ljava/lang/String;", "")]
		public unsafe string QueryParameterValue(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("queryParameterValue.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("queryParameterValues", "(Ljava/lang/String;)Ljava/util/List;", "")]
		public unsafe IList<string> QueryParameterValues(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("queryParameterValues.(Ljava/lang/String;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("querySize", "()I", "")]
		public unsafe int QuerySize()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("querySize.()I", this, null);
		}

		[Register("redact", "()Ljava/lang/String;", "")]
		public unsafe string Redact()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("redact.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("resolve", "(Ljava/lang/String;)Lokhttp3/HttpUrl;", "")]
		public unsafe HttpUrl Resolve(string link)
		{
			IntPtr intPtr = JNIEnv.NewString(link);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<HttpUrl>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("resolve.(Ljava/lang/String;)Lokhttp3/HttpUrl;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("scheme", "()Ljava/lang/String;", "")]
		public unsafe string Scheme()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("scheme.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("topPrivateDomain", "()Ljava/lang/String;", "")]
		public unsafe string TopPrivateDomain()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("topPrivateDomain.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("uri", "()Ljava/net/URI;", "")]
		public unsafe URI Uri()
		{
			return Java.Lang.Object.GetObject<URI>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("uri.()Ljava/net/URI;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("url", "()Ljava/net/URL;", "")]
		public unsafe URL Url()
		{
			return Java.Lang.Object.GetObject<URL>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("url.()Ljava/net/URL;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("username", "()Ljava/lang/String;", "")]
		public unsafe string Username()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("username.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/Authenticator", DoNotGenerateAcw = true)]
	public abstract class Authenticator : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Authenticator", typeof(Authenticator));

		[Register("JAVA_NET_AUTHENTICATOR")]
		public static IAuthenticator JavaNetAuthenticator => Java.Lang.Object.GetObject<IAuthenticator>(_members.StaticFields.GetObjectValue("JAVA_NET_AUTHENTICATOR.Lokhttp3/Authenticator;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NONE")]
		public static IAuthenticator None => Java.Lang.Object.GetObject<IAuthenticator>(_members.StaticFields.GetObjectValue("NONE.Lokhttp3/Authenticator;").Handle, JniHandleOwnership.TransferLocalRef);

		internal Authenticator()
		{
		}
	}
	[Register("okhttp3/Authenticator", DoNotGenerateAcw = true)]
	[Obsolete("Use the 'Authenticator' type. This type will be removed in a future release.", true)]
	public abstract class AuthenticatorConsts : Authenticator
	{
		private AuthenticatorConsts()
		{
		}
	}
	[Register("okhttp3/Authenticator", "", "Square.OkHttp3.IAuthenticatorInvoker")]
	public interface IAuthenticator : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("authenticate", "(Lokhttp3/Route;Lokhttp3/Response;)Lokhttp3/Request;", "GetAuthenticate_Lokhttp3_Route_Lokhttp3_Response_Handler:Square.OkHttp3.IAuthenticatorInvoker, Square.OkHttp3")]
		Request Authenticate(Route route, Response response);
	}
	[Register("okhttp3/Authenticator", DoNotGenerateAcw = true)]
	internal class IAuthenticatorInvoker : Java.Lang.Object, IAuthenticator, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Authenticator", typeof(IAuthenticatorInvoker));

		private IntPtr class_ref;

		private static Delegate cb_authenticate_Lokhttp3_Route_Lokhttp3_Response_;

		private IntPtr id_authenticate_Lokhttp3_Route_Lokhttp3_Response_;

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

		public static IAuthenticator GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IAuthenticator>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.Authenticator'.");
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

		public IAuthenticatorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAuthenticate_Lokhttp3_Route_Lokhttp3_Response_Handler()
		{
			if ((object)cb_authenticate_Lokhttp3_Route_Lokhttp3_Response_ == null)
			{
				cb_authenticate_Lokhttp3_Route_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Authenticate_Lokhttp3_Route_Lokhttp3_Response_));
			}
			return cb_authenticate_Lokhttp3_Route_Lokhttp3_Response_;
		}

		private static IntPtr n_Authenticate_Lokhttp3_Route_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_route, IntPtr native_response)
		{
			IAuthenticator authenticator = Java.Lang.Object.GetObject<IAuthenticator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Route route = Java.Lang.Object.GetObject<Route>(native_route, JniHandleOwnership.DoNotTransfer);
			Response response = Java.Lang.Object.GetObject<Response>(native_response, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(authenticator.Authenticate(route, response));
		}

		public unsafe Request Authenticate(Route route, Response response)
		{
			if (id_authenticate_Lokhttp3_Route_Lokhttp3_Response_ == IntPtr.Zero)
			{
				id_authenticate_Lokhttp3_Route_Lokhttp3_Response_ = JNIEnv.GetMethodID(class_ref, "authenticate", "(Lokhttp3/Route;Lokhttp3/Response;)Lokhttp3/Request;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(route?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(response?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Request>(JNIEnv.CallObjectMethod(base.Handle, id_authenticate_Lokhttp3_Route_Lokhttp3_Response_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/Call$Factory", "", "Square.OkHttp3.ICallFactoryInvoker")]
	public interface ICallFactory : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("newCall", "(Lokhttp3/Request;)Lokhttp3/Call;", "GetNewCall_Lokhttp3_Request_Handler:Square.OkHttp3.ICallFactoryInvoker, Square.OkHttp3")]
		ICall NewCall(Request request);
	}
	[Register("okhttp3/Call$Factory", DoNotGenerateAcw = true)]
	internal class ICallFactoryInvoker : Java.Lang.Object, ICallFactory, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Call$Factory", typeof(ICallFactoryInvoker));

		private IntPtr class_ref;

		private static Delegate cb_newCall_Lokhttp3_Request_;

		private IntPtr id_newCall_Lokhttp3_Request_;

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

		public static ICallFactory GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICallFactory>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.Call.Factory'.");
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

		public ICallFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetNewCall_Lokhttp3_Request_Handler()
		{
			if ((object)cb_newCall_Lokhttp3_Request_ == null)
			{
				cb_newCall_Lokhttp3_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_NewCall_Lokhttp3_Request_));
			}
			return cb_newCall_Lokhttp3_Request_;
		}

		private static IntPtr n_NewCall_Lokhttp3_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
		{
			ICallFactory callFactory = Java.Lang.Object.GetObject<ICallFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Request request = Java.Lang.Object.GetObject<Request>(native_request, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(callFactory.NewCall(request));
		}

		public unsafe ICall NewCall(Request request)
		{
			if (id_newCall_Lokhttp3_Request_ == IntPtr.Zero)
			{
				id_newCall_Lokhttp3_Request_ = JNIEnv.GetMethodID(class_ref, "newCall", "(Lokhttp3/Request;)Lokhttp3/Call;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(request?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ICall>(JNIEnv.CallObjectMethod(base.Handle, id_newCall_Lokhttp3_Request_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/Call", "", "Square.OkHttp3.ICallInvoker")]
	public interface ICall : Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable
	{
		bool IsCanceled
		{
			[Register("isCanceled", "()Z", "GetIsCanceledHandler:Square.OkHttp3.ICallInvoker, Square.OkHttp3")]
			get;
		}

		bool IsExecuted
		{
			[Register("isExecuted", "()Z", "GetIsExecutedHandler:Square.OkHttp3.ICallInvoker, Square.OkHttp3")]
			get;
		}

		[Register("cancel", "()V", "GetCancelHandler:Square.OkHttp3.ICallInvoker, Square.OkHttp3")]
		void Cancel();

		[Register("clone", "()Lokhttp3/Call;", "GetCloneHandler:Square.OkHttp3.ICallInvoker, Square.OkHttp3")]
		ICall Clone();

		[Register("enqueue", "(Lokhttp3/Callback;)V", "GetEnqueue_Lokhttp3_Callback_Handler:Square.OkHttp3.ICallInvoker, Square.OkHttp3")]
		void Enqueue(ICallback responseCallback);

		[Register("execute", "()Lokhttp3/Response;", "GetExecuteHandler:Square.OkHttp3.ICallInvoker, Square.OkHttp3")]
		Response Execute();

		[Register("request", "()Lokhttp3/Request;", "GetRequestHandler:Square.OkHttp3.ICallInvoker, Square.OkHttp3")]
		Request Request();

		[Register("timeout", "()Lokio/Timeout;", "GetTimeoutHandler:Square.OkHttp3.ICallInvoker, Square.OkHttp3")]
		Timeout Timeout();
	}
	[Register("okhttp3/Call", DoNotGenerateAcw = true)]
	internal class ICallInvoker : Java.Lang.Object, ICall, Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Call", typeof(ICallInvoker));

		private IntPtr class_ref;

		private static Delegate cb_isCanceled;

		private IntPtr id_isCanceled;

		private static Delegate cb_isExecuted;

		private IntPtr id_isExecuted;

		private static Delegate cb_cancel;

		private IntPtr id_cancel;

		private static Delegate cb_clone;

		private IntPtr id_clone;

		private static Delegate cb_enqueue_Lokhttp3_Callback_;

		private IntPtr id_enqueue_Lokhttp3_Callback_;

		private static Delegate cb_execute;

		private IntPtr id_execute;

		private static Delegate cb_request;

		private IntPtr id_request;

		private static Delegate cb_timeout;

		private IntPtr id_timeout;

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

		public bool IsCanceled
		{
			get
			{
				if (id_isCanceled == IntPtr.Zero)
				{
					id_isCanceled = JNIEnv.GetMethodID(class_ref, "isCanceled", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isCanceled);
			}
		}

		public bool IsExecuted
		{
			get
			{
				if (id_isExecuted == IntPtr.Zero)
				{
					id_isExecuted = JNIEnv.GetMethodID(class_ref, "isExecuted", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isExecuted);
			}
		}

		public static ICall GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICall>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.Call'.");
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

		public ICallInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetIsCanceledHandler()
		{
			if ((object)cb_isCanceled == null)
			{
				cb_isCanceled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCanceled));
			}
			return cb_isCanceled;
		}

		private static bool n_IsCanceled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCanceled;
		}

		private static Delegate GetIsExecutedHandler()
		{
			if ((object)cb_isExecuted == null)
			{
				cb_isExecuted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsExecuted));
			}
			return cb_isExecuted;
		}

		private static bool n_IsExecuted(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsExecuted;
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
			Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
		}

		public void Cancel()
		{
			if (id_cancel == IntPtr.Zero)
			{
				id_cancel = JNIEnv.GetMethodID(class_ref, "cancel", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_cancel);
		}

		private static Delegate GetCloneHandler()
		{
			if ((object)cb_clone == null)
			{
				cb_clone = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Clone));
			}
			return cb_clone;
		}

		private static IntPtr n_Clone(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
		}

		public new ICall Clone()
		{
			if (id_clone == IntPtr.Zero)
			{
				id_clone = JNIEnv.GetMethodID(class_ref, "clone", "()Lokhttp3/Call;");
			}
			return Java.Lang.Object.GetObject<ICall>(JNIEnv.CallObjectMethod(base.Handle, id_clone), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetEnqueue_Lokhttp3_Callback_Handler()
		{
			if ((object)cb_enqueue_Lokhttp3_Callback_ == null)
			{
				cb_enqueue_Lokhttp3_Callback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Enqueue_Lokhttp3_Callback_));
			}
			return cb_enqueue_Lokhttp3_Callback_;
		}

		private static void n_Enqueue_Lokhttp3_Callback_(IntPtr jnienv, IntPtr native__this, IntPtr native_responseCallback)
		{
			ICall call = Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallback responseCallback = Java.Lang.Object.GetObject<ICallback>(native_responseCallback, JniHandleOwnership.DoNotTransfer);
			call.Enqueue(responseCallback);
		}

		public unsafe void Enqueue(ICallback responseCallback)
		{
			if (id_enqueue_Lokhttp3_Callback_ == IntPtr.Zero)
			{
				id_enqueue_Lokhttp3_Callback_ = JNIEnv.GetMethodID(class_ref, "enqueue", "(Lokhttp3/Callback;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((responseCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)responseCallback).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_enqueue_Lokhttp3_Callback_, ptr);
		}

		private static Delegate GetExecuteHandler()
		{
			if ((object)cb_execute == null)
			{
				cb_execute = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Execute));
			}
			return cb_execute;
		}

		private static IntPtr n_Execute(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Execute());
		}

		public Response Execute()
		{
			if (id_execute == IntPtr.Zero)
			{
				id_execute = JNIEnv.GetMethodID(class_ref, "execute", "()Lokhttp3/Response;");
			}
			return Java.Lang.Object.GetObject<Response>(JNIEnv.CallObjectMethod(base.Handle, id_execute), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRequestHandler()
		{
			if ((object)cb_request == null)
			{
				cb_request = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Request));
			}
			return cb_request;
		}

		private static IntPtr n_Request(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Request());
		}

		public Request Request()
		{
			if (id_request == IntPtr.Zero)
			{
				id_request = JNIEnv.GetMethodID(class_ref, "request", "()Lokhttp3/Request;");
			}
			return Java.Lang.Object.GetObject<Request>(JNIEnv.CallObjectMethod(base.Handle, id_request), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetTimeoutHandler()
		{
			if ((object)cb_timeout == null)
			{
				cb_timeout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Timeout));
			}
			return cb_timeout;
		}

		private static IntPtr n_Timeout(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timeout());
		}

		public Timeout Timeout()
		{
			if (id_timeout == IntPtr.Zero)
			{
				id_timeout = JNIEnv.GetMethodID(class_ref, "timeout", "()Lokio/Timeout;");
			}
			return Java.Lang.Object.GetObject<Timeout>(JNIEnv.CallObjectMethod(base.Handle, id_timeout), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/Callback", "", "Square.OkHttp3.ICallbackInvoker")]
	public interface ICallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onFailure", "(Lokhttp3/Call;Ljava/io/IOException;)V", "GetOnFailure_Lokhttp3_Call_Ljava_io_IOException_Handler:Square.OkHttp3.ICallbackInvoker, Square.OkHttp3")]
		void OnFailure(ICall call, Java.IO.IOException exception);

		[Register("onResponse", "(Lokhttp3/Call;Lokhttp3/Response;)V", "GetOnResponse_Lokhttp3_Call_Lokhttp3_Response_Handler:Square.OkHttp3.ICallbackInvoker, Square.OkHttp3")]
		void OnResponse(ICall call, Response response);
	}
	[Register("okhttp3/Callback", DoNotGenerateAcw = true)]
	internal class ICallbackInvoker : Java.Lang.Object, ICallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Callback", typeof(ICallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onFailure_Lokhttp3_Call_Ljava_io_IOException_;

		private IntPtr id_onFailure_Lokhttp3_Call_Ljava_io_IOException_;

		private static Delegate cb_onResponse_Lokhttp3_Call_Lokhttp3_Response_;

		private IntPtr id_onResponse_Lokhttp3_Call_Lokhttp3_Response_;

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
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.Callback'.");
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

		private static Delegate GetOnFailure_Lokhttp3_Call_Ljava_io_IOException_Handler()
		{
			if ((object)cb_onFailure_Lokhttp3_Call_Ljava_io_IOException_ == null)
			{
				cb_onFailure_Lokhttp3_Call_Ljava_io_IOException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnFailure_Lokhttp3_Call_Ljava_io_IOException_));
			}
			return cb_onFailure_Lokhttp3_Call_Ljava_io_IOException_;
		}

		private static void n_OnFailure_Lokhttp3_Call_Ljava_io_IOException_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_exception)
		{
			ICallback callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Java.IO.IOException exception = Java.Lang.Object.GetObject<Java.IO.IOException>(native_exception, JniHandleOwnership.DoNotTransfer);
			callback.OnFailure(call, exception);
		}

		public unsafe void OnFailure(ICall call, Java.IO.IOException exception)
		{
			if (id_onFailure_Lokhttp3_Call_Ljava_io_IOException_ == IntPtr.Zero)
			{
				id_onFailure_Lokhttp3_Call_Ljava_io_IOException_ = JNIEnv.GetMethodID(class_ref, "onFailure", "(Lokhttp3/Call;Ljava/io/IOException;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
			ptr[1] = new JValue(exception?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onFailure_Lokhttp3_Call_Ljava_io_IOException_, ptr);
		}

		private static Delegate GetOnResponse_Lokhttp3_Call_Lokhttp3_Response_Handler()
		{
			if ((object)cb_onResponse_Lokhttp3_Call_Lokhttp3_Response_ == null)
			{
				cb_onResponse_Lokhttp3_Call_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnResponse_Lokhttp3_Call_Lokhttp3_Response_));
			}
			return cb_onResponse_Lokhttp3_Call_Lokhttp3_Response_;
		}

		private static void n_OnResponse_Lokhttp3_Call_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_call, IntPtr native_response)
		{
			ICallback callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall call = Java.Lang.Object.GetObject<ICall>(native_call, JniHandleOwnership.DoNotTransfer);
			Response response = Java.Lang.Object.GetObject<Response>(native_response, JniHandleOwnership.DoNotTransfer);
			callback.OnResponse(call, response);
		}

		public unsafe void OnResponse(ICall call, Response response)
		{
			if (id_onResponse_Lokhttp3_Call_Lokhttp3_Response_ == IntPtr.Zero)
			{
				id_onResponse_Lokhttp3_Call_Lokhttp3_Response_ = JNIEnv.GetMethodID(class_ref, "onResponse", "(Lokhttp3/Call;Lokhttp3/Response;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((call == null) ? IntPtr.Zero : ((Java.Lang.Object)call).Handle);
			ptr[1] = new JValue(response?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onResponse_Lokhttp3_Call_Lokhttp3_Response_, ptr);
		}
	}
	[Register("okhttp3/Connection", "", "Square.OkHttp3.IConnectionInvoker")]
	public interface IConnection : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("handshake", "()Lokhttp3/Handshake;", "GetHandshakeHandler:Square.OkHttp3.IConnectionInvoker, Square.OkHttp3")]
		Handshake Handshake();

		[Register("protocol", "()Lokhttp3/Protocol;", "GetProtocolHandler:Square.OkHttp3.IConnectionInvoker, Square.OkHttp3")]
		Protocol Protocol();

		[Register("route", "()Lokhttp3/Route;", "GetRouteHandler:Square.OkHttp3.IConnectionInvoker, Square.OkHttp3")]
		Route Route();

		[Register("socket", "()Ljava/net/Socket;", "GetSocketHandler:Square.OkHttp3.IConnectionInvoker, Square.OkHttp3")]
		Socket Socket();
	}
	[Register("okhttp3/Connection", DoNotGenerateAcw = true)]
	internal class IConnectionInvoker : Java.Lang.Object, IConnection, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Connection", typeof(IConnectionInvoker));

		private IntPtr class_ref;

		private static Delegate cb_handshake;

		private IntPtr id_handshake;

		private static Delegate cb_protocol;

		private IntPtr id_protocol;

		private static Delegate cb_route;

		private IntPtr id_route;

		private static Delegate cb_socket;

		private IntPtr id_socket;

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

		public static IConnection GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IConnection>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.Connection'.");
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

		public IConnectionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetHandshakeHandler()
		{
			if ((object)cb_handshake == null)
			{
				cb_handshake = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Handshake));
			}
			return cb_handshake;
		}

		private static IntPtr n_Handshake(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Handshake());
		}

		public Handshake Handshake()
		{
			if (id_handshake == IntPtr.Zero)
			{
				id_handshake = JNIEnv.GetMethodID(class_ref, "handshake", "()Lokhttp3/Handshake;");
			}
			return Java.Lang.Object.GetObject<Handshake>(JNIEnv.CallObjectMethod(base.Handle, id_handshake), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetProtocolHandler()
		{
			if ((object)cb_protocol == null)
			{
				cb_protocol = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Protocol));
			}
			return cb_protocol;
		}

		private static IntPtr n_Protocol(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Protocol());
		}

		public Protocol Protocol()
		{
			if (id_protocol == IntPtr.Zero)
			{
				id_protocol = JNIEnv.GetMethodID(class_ref, "protocol", "()Lokhttp3/Protocol;");
			}
			return Java.Lang.Object.GetObject<Protocol>(JNIEnv.CallObjectMethod(base.Handle, id_protocol), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRouteHandler()
		{
			if ((object)cb_route == null)
			{
				cb_route = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Route));
			}
			return cb_route;
		}

		private static IntPtr n_Route(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Route());
		}

		public Route Route()
		{
			if (id_route == IntPtr.Zero)
			{
				id_route = JNIEnv.GetMethodID(class_ref, "route", "()Lokhttp3/Route;");
			}
			return Java.Lang.Object.GetObject<Route>(JNIEnv.CallObjectMethod(base.Handle, id_route), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSocketHandler()
		{
			if ((object)cb_socket == null)
			{
				cb_socket = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Socket));
			}
			return cb_socket;
		}

		private static IntPtr n_Socket(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Socket());
		}

		public Socket Socket()
		{
			if (id_socket == IntPtr.Zero)
			{
				id_socket = JNIEnv.GetMethodID(class_ref, "socket", "()Ljava/net/Socket;");
			}
			return Java.Lang.Object.GetObject<Socket>(JNIEnv.CallObjectMethod(base.Handle, id_socket), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/CookieJar", DoNotGenerateAcw = true)]
	public abstract class CookieJar : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/CookieJar", typeof(CookieJar));

		[Register("NO_COOKIES")]
		public static ICookieJar NoCookies => Java.Lang.Object.GetObject<ICookieJar>(_members.StaticFields.GetObjectValue("NO_COOKIES.Lokhttp3/CookieJar;").Handle, JniHandleOwnership.TransferLocalRef);

		internal CookieJar()
		{
		}
	}
	[Register("okhttp3/CookieJar", DoNotGenerateAcw = true)]
	[Obsolete("Use the 'CookieJar' type. This type will be removed in a future release.", true)]
	public abstract class CookieJarConsts : CookieJar
	{
		private CookieJarConsts()
		{
		}
	}
	[Register("okhttp3/CookieJar", "", "Square.OkHttp3.ICookieJarInvoker")]
	public interface ICookieJar : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("loadForRequest", "(Lokhttp3/HttpUrl;)Ljava/util/List;", "GetLoadForRequest_Lokhttp3_HttpUrl_Handler:Square.OkHttp3.ICookieJarInvoker, Square.OkHttp3")]
		IList<Cookie> LoadForRequest(HttpUrl url);

		[Register("saveFromResponse", "(Lokhttp3/HttpUrl;Ljava/util/List;)V", "GetSaveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_Handler:Square.OkHttp3.ICookieJarInvoker, Square.OkHttp3")]
		void SaveFromResponse(HttpUrl url, IList<Cookie> cookies);
	}
	[Register("okhttp3/CookieJar", DoNotGenerateAcw = true)]
	internal class ICookieJarInvoker : Java.Lang.Object, ICookieJar, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/CookieJar", typeof(ICookieJarInvoker));

		private IntPtr class_ref;

		private static Delegate cb_loadForRequest_Lokhttp3_HttpUrl_;

		private IntPtr id_loadForRequest_Lokhttp3_HttpUrl_;

		private static Delegate cb_saveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_;

		private IntPtr id_saveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_;

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

		public static ICookieJar GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICookieJar>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.CookieJar'.");
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

		public ICookieJarInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetLoadForRequest_Lokhttp3_HttpUrl_Handler()
		{
			if ((object)cb_loadForRequest_Lokhttp3_HttpUrl_ == null)
			{
				cb_loadForRequest_Lokhttp3_HttpUrl_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_LoadForRequest_Lokhttp3_HttpUrl_));
			}
			return cb_loadForRequest_Lokhttp3_HttpUrl_;
		}

		private static IntPtr n_LoadForRequest_Lokhttp3_HttpUrl_(IntPtr jnienv, IntPtr native__this, IntPtr native_url)
		{
			ICookieJar cookieJar = Java.Lang.Object.GetObject<ICookieJar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			HttpUrl url = Java.Lang.Object.GetObject<HttpUrl>(native_url, JniHandleOwnership.DoNotTransfer);
			return JavaList<Cookie>.ToLocalJniHandle(cookieJar.LoadForRequest(url));
		}

		public unsafe IList<Cookie> LoadForRequest(HttpUrl url)
		{
			if (id_loadForRequest_Lokhttp3_HttpUrl_ == IntPtr.Zero)
			{
				id_loadForRequest_Lokhttp3_HttpUrl_ = JNIEnv.GetMethodID(class_ref, "loadForRequest", "(Lokhttp3/HttpUrl;)Ljava/util/List;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(url?.Handle ?? IntPtr.Zero);
			return JavaList<Cookie>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_loadForRequest_Lokhttp3_HttpUrl_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSaveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_Handler()
		{
			if ((object)cb_saveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_ == null)
			{
				cb_saveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SaveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_));
			}
			return cb_saveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_;
		}

		private static void n_SaveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_url, IntPtr native_cookies)
		{
			ICookieJar cookieJar = Java.Lang.Object.GetObject<ICookieJar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			HttpUrl url = Java.Lang.Object.GetObject<HttpUrl>(native_url, JniHandleOwnership.DoNotTransfer);
			IList<Cookie> cookies = JavaList<Cookie>.FromJniHandle(native_cookies, JniHandleOwnership.DoNotTransfer);
			cookieJar.SaveFromResponse(url, cookies);
		}

		public unsafe void SaveFromResponse(HttpUrl url, IList<Cookie> cookies)
		{
			if (id_saveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_ == IntPtr.Zero)
			{
				id_saveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "saveFromResponse", "(Lokhttp3/HttpUrl;Ljava/util/List;)V");
			}
			IntPtr intPtr = JavaList<Cookie>.ToLocalJniHandle(cookies);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(url?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_saveFromResponse_Lokhttp3_HttpUrl_Ljava_util_List_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("okhttp3/Dns", DoNotGenerateAcw = true)]
	public abstract class Dns : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Dns", typeof(Dns));

		[Register("SYSTEM")]
		public static IDns System => Java.Lang.Object.GetObject<IDns>(_members.StaticFields.GetObjectValue("SYSTEM.Lokhttp3/Dns;").Handle, JniHandleOwnership.TransferLocalRef);

		internal Dns()
		{
		}
	}
	[Register("okhttp3/Dns", DoNotGenerateAcw = true)]
	[Obsolete("Use the 'Dns' type. This type will be removed in a future release.", true)]
	public abstract class DnsConsts : Dns
	{
		private DnsConsts()
		{
		}
	}
	[Register("okhttp3/Dns", "", "Square.OkHttp3.IDnsInvoker")]
	public interface IDns : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("lookup", "(Ljava/lang/String;)Ljava/util/List;", "GetLookup_Ljava_lang_String_Handler:Square.OkHttp3.IDnsInvoker, Square.OkHttp3")]
		IList<InetAddress> Lookup(string hostname);
	}
	[Register("okhttp3/Dns", DoNotGenerateAcw = true)]
	internal class IDnsInvoker : Java.Lang.Object, IDns, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Dns", typeof(IDnsInvoker));

		private IntPtr class_ref;

		private static Delegate cb_lookup_Ljava_lang_String_;

		private IntPtr id_lookup_Ljava_lang_String_;

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

		public static IDns GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDns>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.Dns'.");
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

		public IDnsInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetLookup_Ljava_lang_String_Handler()
		{
			if ((object)cb_lookup_Ljava_lang_String_ == null)
			{
				cb_lookup_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Lookup_Ljava_lang_String_));
			}
			return cb_lookup_Ljava_lang_String_;
		}

		private static IntPtr n_Lookup_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_hostname)
		{
			IDns dns = Java.Lang.Object.GetObject<IDns>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string hostname = JNIEnv.GetString(native_hostname, JniHandleOwnership.DoNotTransfer);
			return JavaList<InetAddress>.ToLocalJniHandle(dns.Lookup(hostname));
		}

		public unsafe IList<InetAddress> Lookup(string hostname)
		{
			if (id_lookup_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_lookup_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "lookup", "(Ljava/lang/String;)Ljava/util/List;");
			}
			IntPtr intPtr = JNIEnv.NewString(hostname);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			IList<InetAddress> result = JavaList<InetAddress>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_lookup_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}
	}
	[Register("okhttp3/Interceptor$Chain", "", "Square.OkHttp3.IInterceptorChainInvoker")]
	public interface IInterceptorChain : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("call", "()Lokhttp3/Call;", "GetCallHandler:Square.OkHttp3.IInterceptorChainInvoker, Square.OkHttp3")]
		ICall Call();

		[Register("connectTimeoutMillis", "()I", "GetConnectTimeoutMillisHandler:Square.OkHttp3.IInterceptorChainInvoker, Square.OkHttp3")]
		int ConnectTimeoutMillis();

		[Register("connection", "()Lokhttp3/Connection;", "GetConnectionHandler:Square.OkHttp3.IInterceptorChainInvoker, Square.OkHttp3")]
		IConnection Connection();

		[Register("proceed", "(Lokhttp3/Request;)Lokhttp3/Response;", "GetProceed_Lokhttp3_Request_Handler:Square.OkHttp3.IInterceptorChainInvoker, Square.OkHttp3")]
		Response Proceed(Request request);

		[Register("readTimeoutMillis", "()I", "GetReadTimeoutMillisHandler:Square.OkHttp3.IInterceptorChainInvoker, Square.OkHttp3")]
		int ReadTimeoutMillis();

		[Register("request", "()Lokhttp3/Request;", "GetRequestHandler:Square.OkHttp3.IInterceptorChainInvoker, Square.OkHttp3")]
		Request Request();

		[Register("withConnectTimeout", "(ILjava/util/concurrent/TimeUnit;)Lokhttp3/Interceptor$Chain;", "GetWithConnectTimeout_ILjava_util_concurrent_TimeUnit_Handler:Square.OkHttp3.IInterceptorChainInvoker, Square.OkHttp3")]
		IInterceptorChain WithConnectTimeout(int timeout, TimeUnit unit);

		[Register("withReadTimeout", "(ILjava/util/concurrent/TimeUnit;)Lokhttp3/Interceptor$Chain;", "GetWithReadTimeout_ILjava_util_concurrent_TimeUnit_Handler:Square.OkHttp3.IInterceptorChainInvoker, Square.OkHttp3")]
		IInterceptorChain WithReadTimeout(int timeout, TimeUnit unit);

		[Register("withWriteTimeout", "(ILjava/util/concurrent/TimeUnit;)Lokhttp3/Interceptor$Chain;", "GetWithWriteTimeout_ILjava_util_concurrent_TimeUnit_Handler:Square.OkHttp3.IInterceptorChainInvoker, Square.OkHttp3")]
		IInterceptorChain WithWriteTimeout(int timeout, TimeUnit unit);

		[Register("writeTimeoutMillis", "()I", "GetWriteTimeoutMillisHandler:Square.OkHttp3.IInterceptorChainInvoker, Square.OkHttp3")]
		int WriteTimeoutMillis();
	}
	[Register("okhttp3/Interceptor$Chain", DoNotGenerateAcw = true)]
	internal class IInterceptorChainInvoker : Java.Lang.Object, IInterceptorChain, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Interceptor$Chain", typeof(IInterceptorChainInvoker));

		private IntPtr class_ref;

		private static Delegate cb_call;

		private IntPtr id_call;

		private static Delegate cb_connectTimeoutMillis;

		private IntPtr id_connectTimeoutMillis;

		private static Delegate cb_connection;

		private IntPtr id_connection;

		private static Delegate cb_proceed_Lokhttp3_Request_;

		private IntPtr id_proceed_Lokhttp3_Request_;

		private static Delegate cb_readTimeoutMillis;

		private IntPtr id_readTimeoutMillis;

		private static Delegate cb_request;

		private IntPtr id_request;

		private static Delegate cb_withConnectTimeout_ILjava_util_concurrent_TimeUnit_;

		private IntPtr id_withConnectTimeout_ILjava_util_concurrent_TimeUnit_;

		private static Delegate cb_withReadTimeout_ILjava_util_concurrent_TimeUnit_;

		private IntPtr id_withReadTimeout_ILjava_util_concurrent_TimeUnit_;

		private static Delegate cb_withWriteTimeout_ILjava_util_concurrent_TimeUnit_;

		private IntPtr id_withWriteTimeout_ILjava_util_concurrent_TimeUnit_;

		private static Delegate cb_writeTimeoutMillis;

		private IntPtr id_writeTimeoutMillis;

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

		public static IInterceptorChain GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IInterceptorChain>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.Interceptor.Chain'.");
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

		public IInterceptorChainInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCallHandler()
		{
			if ((object)cb_call == null)
			{
				cb_call = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Call));
			}
			return cb_call;
		}

		private static IntPtr n_Call(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IInterceptorChain>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Call());
		}

		public ICall Call()
		{
			if (id_call == IntPtr.Zero)
			{
				id_call = JNIEnv.GetMethodID(class_ref, "call", "()Lokhttp3/Call;");
			}
			return Java.Lang.Object.GetObject<ICall>(JNIEnv.CallObjectMethod(base.Handle, id_call), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetConnectTimeoutMillisHandler()
		{
			if ((object)cb_connectTimeoutMillis == null)
			{
				cb_connectTimeoutMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ConnectTimeoutMillis));
			}
			return cb_connectTimeoutMillis;
		}

		private static int n_ConnectTimeoutMillis(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IInterceptorChain>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConnectTimeoutMillis();
		}

		public int ConnectTimeoutMillis()
		{
			if (id_connectTimeoutMillis == IntPtr.Zero)
			{
				id_connectTimeoutMillis = JNIEnv.GetMethodID(class_ref, "connectTimeoutMillis", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_connectTimeoutMillis);
		}

		private static Delegate GetConnectionHandler()
		{
			if ((object)cb_connection == null)
			{
				cb_connection = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Connection));
			}
			return cb_connection;
		}

		private static IntPtr n_Connection(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IInterceptorChain>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Connection());
		}

		public IConnection Connection()
		{
			if (id_connection == IntPtr.Zero)
			{
				id_connection = JNIEnv.GetMethodID(class_ref, "connection", "()Lokhttp3/Connection;");
			}
			return Java.Lang.Object.GetObject<IConnection>(JNIEnv.CallObjectMethod(base.Handle, id_connection), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetProceed_Lokhttp3_Request_Handler()
		{
			if ((object)cb_proceed_Lokhttp3_Request_ == null)
			{
				cb_proceed_Lokhttp3_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Proceed_Lokhttp3_Request_));
			}
			return cb_proceed_Lokhttp3_Request_;
		}

		private static IntPtr n_Proceed_Lokhttp3_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
		{
			IInterceptorChain interceptorChain = Java.Lang.Object.GetObject<IInterceptorChain>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Request request = Java.Lang.Object.GetObject<Request>(native_request, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(interceptorChain.Proceed(request));
		}

		public unsafe Response Proceed(Request request)
		{
			if (id_proceed_Lokhttp3_Request_ == IntPtr.Zero)
			{
				id_proceed_Lokhttp3_Request_ = JNIEnv.GetMethodID(class_ref, "proceed", "(Lokhttp3/Request;)Lokhttp3/Response;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(request?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Response>(JNIEnv.CallObjectMethod(base.Handle, id_proceed_Lokhttp3_Request_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetReadTimeoutMillisHandler()
		{
			if ((object)cb_readTimeoutMillis == null)
			{
				cb_readTimeoutMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ReadTimeoutMillis));
			}
			return cb_readTimeoutMillis;
		}

		private static int n_ReadTimeoutMillis(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IInterceptorChain>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadTimeoutMillis();
		}

		public int ReadTimeoutMillis()
		{
			if (id_readTimeoutMillis == IntPtr.Zero)
			{
				id_readTimeoutMillis = JNIEnv.GetMethodID(class_ref, "readTimeoutMillis", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_readTimeoutMillis);
		}

		private static Delegate GetRequestHandler()
		{
			if ((object)cb_request == null)
			{
				cb_request = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Request));
			}
			return cb_request;
		}

		private static IntPtr n_Request(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IInterceptorChain>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Request());
		}

		public Request Request()
		{
			if (id_request == IntPtr.Zero)
			{
				id_request = JNIEnv.GetMethodID(class_ref, "request", "()Lokhttp3/Request;");
			}
			return Java.Lang.Object.GetObject<Request>(JNIEnv.CallObjectMethod(base.Handle, id_request), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithConnectTimeout_ILjava_util_concurrent_TimeUnit_Handler()
		{
			if ((object)cb_withConnectTimeout_ILjava_util_concurrent_TimeUnit_ == null)
			{
				cb_withConnectTimeout_ILjava_util_concurrent_TimeUnit_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_WithConnectTimeout_ILjava_util_concurrent_TimeUnit_));
			}
			return cb_withConnectTimeout_ILjava_util_concurrent_TimeUnit_;
		}

		private static IntPtr n_WithConnectTimeout_ILjava_util_concurrent_TimeUnit_(IntPtr jnienv, IntPtr native__this, int timeout, IntPtr native_unit)
		{
			IInterceptorChain interceptorChain = Java.Lang.Object.GetObject<IInterceptorChain>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TimeUnit unit = Java.Lang.Object.GetObject<TimeUnit>(native_unit, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(interceptorChain.WithConnectTimeout(timeout, unit));
		}

		public unsafe IInterceptorChain WithConnectTimeout(int timeout, TimeUnit unit)
		{
			if (id_withConnectTimeout_ILjava_util_concurrent_TimeUnit_ == IntPtr.Zero)
			{
				id_withConnectTimeout_ILjava_util_concurrent_TimeUnit_ = JNIEnv.GetMethodID(class_ref, "withConnectTimeout", "(ILjava/util/concurrent/TimeUnit;)Lokhttp3/Interceptor$Chain;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(timeout);
			ptr[1] = new JValue(unit?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IInterceptorChain>(JNIEnv.CallObjectMethod(base.Handle, id_withConnectTimeout_ILjava_util_concurrent_TimeUnit_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithReadTimeout_ILjava_util_concurrent_TimeUnit_Handler()
		{
			if ((object)cb_withReadTimeout_ILjava_util_concurrent_TimeUnit_ == null)
			{
				cb_withReadTimeout_ILjava_util_concurrent_TimeUnit_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_WithReadTimeout_ILjava_util_concurrent_TimeUnit_));
			}
			return cb_withReadTimeout_ILjava_util_concurrent_TimeUnit_;
		}

		private static IntPtr n_WithReadTimeout_ILjava_util_concurrent_TimeUnit_(IntPtr jnienv, IntPtr native__this, int timeout, IntPtr native_unit)
		{
			IInterceptorChain interceptorChain = Java.Lang.Object.GetObject<IInterceptorChain>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TimeUnit unit = Java.Lang.Object.GetObject<TimeUnit>(native_unit, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(interceptorChain.WithReadTimeout(timeout, unit));
		}

		public unsafe IInterceptorChain WithReadTimeout(int timeout, TimeUnit unit)
		{
			if (id_withReadTimeout_ILjava_util_concurrent_TimeUnit_ == IntPtr.Zero)
			{
				id_withReadTimeout_ILjava_util_concurrent_TimeUnit_ = JNIEnv.GetMethodID(class_ref, "withReadTimeout", "(ILjava/util/concurrent/TimeUnit;)Lokhttp3/Interceptor$Chain;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(timeout);
			ptr[1] = new JValue(unit?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IInterceptorChain>(JNIEnv.CallObjectMethod(base.Handle, id_withReadTimeout_ILjava_util_concurrent_TimeUnit_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithWriteTimeout_ILjava_util_concurrent_TimeUnit_Handler()
		{
			if ((object)cb_withWriteTimeout_ILjava_util_concurrent_TimeUnit_ == null)
			{
				cb_withWriteTimeout_ILjava_util_concurrent_TimeUnit_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_WithWriteTimeout_ILjava_util_concurrent_TimeUnit_));
			}
			return cb_withWriteTimeout_ILjava_util_concurrent_TimeUnit_;
		}

		private static IntPtr n_WithWriteTimeout_ILjava_util_concurrent_TimeUnit_(IntPtr jnienv, IntPtr native__this, int timeout, IntPtr native_unit)
		{
			IInterceptorChain interceptorChain = Java.Lang.Object.GetObject<IInterceptorChain>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TimeUnit unit = Java.Lang.Object.GetObject<TimeUnit>(native_unit, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(interceptorChain.WithWriteTimeout(timeout, unit));
		}

		public unsafe IInterceptorChain WithWriteTimeout(int timeout, TimeUnit unit)
		{
			if (id_withWriteTimeout_ILjava_util_concurrent_TimeUnit_ == IntPtr.Zero)
			{
				id_withWriteTimeout_ILjava_util_concurrent_TimeUnit_ = JNIEnv.GetMethodID(class_ref, "withWriteTimeout", "(ILjava/util/concurrent/TimeUnit;)Lokhttp3/Interceptor$Chain;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(timeout);
			ptr[1] = new JValue(unit?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IInterceptorChain>(JNIEnv.CallObjectMethod(base.Handle, id_withWriteTimeout_ILjava_util_concurrent_TimeUnit_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteTimeoutMillisHandler()
		{
			if ((object)cb_writeTimeoutMillis == null)
			{
				cb_writeTimeoutMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_WriteTimeoutMillis));
			}
			return cb_writeTimeoutMillis;
		}

		private static int n_WriteTimeoutMillis(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IInterceptorChain>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteTimeoutMillis();
		}

		public int WriteTimeoutMillis()
		{
			if (id_writeTimeoutMillis == IntPtr.Zero)
			{
				id_writeTimeoutMillis = JNIEnv.GetMethodID(class_ref, "writeTimeoutMillis", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_writeTimeoutMillis);
		}
	}
	[Register("okhttp3/Interceptor", "", "Square.OkHttp3.IInterceptorInvoker")]
	public interface IInterceptor : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("intercept", "(Lokhttp3/Interceptor$Chain;)Lokhttp3/Response;", "GetIntercept_Lokhttp3_Interceptor_Chain_Handler:Square.OkHttp3.IInterceptorInvoker, Square.OkHttp3")]
		Response Intercept(IInterceptorChain chain);
	}
	[Register("okhttp3/Interceptor", DoNotGenerateAcw = true)]
	internal class IInterceptorInvoker : Java.Lang.Object, IInterceptor, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Interceptor", typeof(IInterceptorInvoker));

		private IntPtr class_ref;

		private static Delegate cb_intercept_Lokhttp3_Interceptor_Chain_;

		private IntPtr id_intercept_Lokhttp3_Interceptor_Chain_;

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

		public static IInterceptor GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IInterceptor>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.Interceptor'.");
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

		public IInterceptorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetIntercept_Lokhttp3_Interceptor_Chain_Handler()
		{
			if ((object)cb_intercept_Lokhttp3_Interceptor_Chain_ == null)
			{
				cb_intercept_Lokhttp3_Interceptor_Chain_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Intercept_Lokhttp3_Interceptor_Chain_));
			}
			return cb_intercept_Lokhttp3_Interceptor_Chain_;
		}

		private static IntPtr n_Intercept_Lokhttp3_Interceptor_Chain_(IntPtr jnienv, IntPtr native__this, IntPtr native_chain)
		{
			IInterceptor interceptor = Java.Lang.Object.GetObject<IInterceptor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInterceptorChain chain = Java.Lang.Object.GetObject<IInterceptorChain>(native_chain, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(interceptor.Intercept(chain));
		}

		public unsafe Response Intercept(IInterceptorChain chain)
		{
			if (id_intercept_Lokhttp3_Interceptor_Chain_ == IntPtr.Zero)
			{
				id_intercept_Lokhttp3_Interceptor_Chain_ = JNIEnv.GetMethodID(class_ref, "intercept", "(Lokhttp3/Interceptor$Chain;)Lokhttp3/Response;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((chain == null) ? IntPtr.Zero : ((Java.Lang.Object)chain).Handle);
			return Java.Lang.Object.GetObject<Response>(JNIEnv.CallObjectMethod(base.Handle, id_intercept_Lokhttp3_Interceptor_Chain_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/WebSocket$Factory", "", "Square.OkHttp3.IWebSocketFactoryInvoker")]
	public interface IWebSocketFactory : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("newWebSocket", "(Lokhttp3/Request;Lokhttp3/WebSocketListener;)Lokhttp3/WebSocket;", "GetNewWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_Handler:Square.OkHttp3.IWebSocketFactoryInvoker, Square.OkHttp3")]
		IWebSocket NewWebSocket(Request request, WebSocketListener listener);
	}
	[Register("okhttp3/WebSocket$Factory", DoNotGenerateAcw = true)]
	internal class IWebSocketFactoryInvoker : Java.Lang.Object, IWebSocketFactory, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/WebSocket$Factory", typeof(IWebSocketFactoryInvoker));

		private IntPtr class_ref;

		private static Delegate cb_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_;

		private IntPtr id_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_;

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

		public static IWebSocketFactory GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IWebSocketFactory>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.WebSocket.Factory'.");
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

		public IWebSocketFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetNewWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_Handler()
		{
			if ((object)cb_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_ == null)
			{
				cb_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_NewWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_));
			}
			return cb_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_;
		}

		private static IntPtr n_NewWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_request, IntPtr native_listener)
		{
			IWebSocketFactory webSocketFactory = Java.Lang.Object.GetObject<IWebSocketFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Request request = Java.Lang.Object.GetObject<Request>(native_request, JniHandleOwnership.DoNotTransfer);
			WebSocketListener listener = Java.Lang.Object.GetObject<WebSocketListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(webSocketFactory.NewWebSocket(request, listener));
		}

		public unsafe IWebSocket NewWebSocket(Request request, WebSocketListener listener)
		{
			if (id_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_ == IntPtr.Zero)
			{
				id_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_ = JNIEnv.GetMethodID(class_ref, "newWebSocket", "(Lokhttp3/Request;Lokhttp3/WebSocketListener;)Lokhttp3/WebSocket;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(request?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(listener?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IWebSocket>(JNIEnv.CallObjectMethod(base.Handle, id_newWebSocket_Lokhttp3_Request_Lokhttp3_WebSocketListener_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/WebSocket", "", "Square.OkHttp3.IWebSocketInvoker")]
	public interface IWebSocket : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("cancel", "()V", "GetCancelHandler:Square.OkHttp3.IWebSocketInvoker, Square.OkHttp3")]
		void Cancel();

		[Register("close", "(ILjava/lang/String;)Z", "GetClose_ILjava_lang_String_Handler:Square.OkHttp3.IWebSocketInvoker, Square.OkHttp3")]
		bool Close(int code, string reason);

		[Register("queueSize", "()J", "GetQueueSizeHandler:Square.OkHttp3.IWebSocketInvoker, Square.OkHttp3")]
		long QueueSize();

		[Register("request", "()Lokhttp3/Request;", "GetRequestHandler:Square.OkHttp3.IWebSocketInvoker, Square.OkHttp3")]
		Request Request();

		[Register("send", "(Ljava/lang/String;)Z", "GetSend_Ljava_lang_String_Handler:Square.OkHttp3.IWebSocketInvoker, Square.OkHttp3")]
		bool Send(string text);

		[Register("send", "(Lokio/ByteString;)Z", "GetSend_Lokio_ByteString_Handler:Square.OkHttp3.IWebSocketInvoker, Square.OkHttp3")]
		bool Send(ByteString bytes);
	}
	[Register("okhttp3/WebSocket", DoNotGenerateAcw = true)]
	internal class IWebSocketInvoker : Java.Lang.Object, IWebSocket, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/WebSocket", typeof(IWebSocketInvoker));

		private IntPtr class_ref;

		private static Delegate cb_cancel;

		private IntPtr id_cancel;

		private static Delegate cb_close_ILjava_lang_String_;

		private IntPtr id_close_ILjava_lang_String_;

		private static Delegate cb_queueSize;

		private IntPtr id_queueSize;

		private static Delegate cb_request;

		private IntPtr id_request;

		private static Delegate cb_send_Ljava_lang_String_;

		private IntPtr id_send_Ljava_lang_String_;

		private static Delegate cb_send_Lokio_ByteString_;

		private IntPtr id_send_Lokio_ByteString_;

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

		public static IWebSocket GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IWebSocket>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'okhttp3.WebSocket'.");
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

		public IWebSocketInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
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
			Java.Lang.Object.GetObject<IWebSocket>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
		}

		public void Cancel()
		{
			if (id_cancel == IntPtr.Zero)
			{
				id_cancel = JNIEnv.GetMethodID(class_ref, "cancel", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_cancel);
		}

		private static Delegate GetClose_ILjava_lang_String_Handler()
		{
			if ((object)cb_close_ILjava_lang_String_ == null)
			{
				cb_close_ILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_Z(n_Close_ILjava_lang_String_));
			}
			return cb_close_ILjava_lang_String_;
		}

		private static bool n_Close_ILjava_lang_String_(IntPtr jnienv, IntPtr native__this, int code, IntPtr native_reason)
		{
			IWebSocket webSocket = Java.Lang.Object.GetObject<IWebSocket>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string reason = JNIEnv.GetString(native_reason, JniHandleOwnership.DoNotTransfer);
			return webSocket.Close(code, reason);
		}

		public unsafe bool Close(int code, string reason)
		{
			if (id_close_ILjava_lang_String_ == IntPtr.Zero)
			{
				id_close_ILjava_lang_String_ = JNIEnv.GetMethodID(class_ref, "close", "(ILjava/lang/String;)Z");
			}
			IntPtr intPtr = JNIEnv.NewString(reason);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(code);
			ptr[1] = new JValue(intPtr);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_close_ILjava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetQueueSizeHandler()
		{
			if ((object)cb_queueSize == null)
			{
				cb_queueSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_QueueSize));
			}
			return cb_queueSize;
		}

		private static long n_QueueSize(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IWebSocket>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).QueueSize();
		}

		public long QueueSize()
		{
			if (id_queueSize == IntPtr.Zero)
			{
				id_queueSize = JNIEnv.GetMethodID(class_ref, "queueSize", "()J");
			}
			return JNIEnv.CallLongMethod(base.Handle, id_queueSize);
		}

		private static Delegate GetRequestHandler()
		{
			if ((object)cb_request == null)
			{
				cb_request = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Request));
			}
			return cb_request;
		}

		private static IntPtr n_Request(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IWebSocket>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Request());
		}

		public Request Request()
		{
			if (id_request == IntPtr.Zero)
			{
				id_request = JNIEnv.GetMethodID(class_ref, "request", "()Lokhttp3/Request;");
			}
			return Java.Lang.Object.GetObject<Request>(JNIEnv.CallObjectMethod(base.Handle, id_request), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSend_Ljava_lang_String_Handler()
		{
			if ((object)cb_send_Ljava_lang_String_ == null)
			{
				cb_send_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Send_Ljava_lang_String_));
			}
			return cb_send_Ljava_lang_String_;
		}

		private static bool n_Send_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_text)
		{
			IWebSocket webSocket = Java.Lang.Object.GetObject<IWebSocket>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
			return webSocket.Send(text);
		}

		public unsafe bool Send(string text)
		{
			if (id_send_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_send_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "send", "(Ljava/lang/String;)Z");
			}
			IntPtr intPtr = JNIEnv.NewString(text);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_send_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetSend_Lokio_ByteString_Handler()
		{
			if ((object)cb_send_Lokio_ByteString_ == null)
			{
				cb_send_Lokio_ByteString_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Send_Lokio_ByteString_));
			}
			return cb_send_Lokio_ByteString_;
		}

		private static bool n_Send_Lokio_ByteString_(IntPtr jnienv, IntPtr native__this, IntPtr native_bytes)
		{
			IWebSocket webSocket = Java.Lang.Object.GetObject<IWebSocket>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString bytes = Java.Lang.Object.GetObject<ByteString>(native_bytes, JniHandleOwnership.DoNotTransfer);
			return webSocket.Send(bytes);
		}

		public unsafe bool Send(ByteString bytes)
		{
			if (id_send_Lokio_ByteString_ == IntPtr.Zero)
			{
				id_send_Lokio_ByteString_ = JNIEnv.GetMethodID(class_ref, "send", "(Lokio/ByteString;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(bytes?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_send_Lokio_ByteString_, ptr);
		}
	}
	[Register("okhttp3/MediaType", DoNotGenerateAcw = true)]
	public sealed class MediaType : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/MediaType", typeof(MediaType));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MediaType(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("charset", "()Ljava/nio/charset/Charset;", "")]
		public unsafe Charset Charset()
		{
			return Java.Lang.Object.GetObject<Charset>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("charset.()Ljava/nio/charset/Charset;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("charset", "(Ljava/nio/charset/Charset;)Ljava/nio/charset/Charset;", "")]
		public unsafe Charset Charset(Charset defaultValue)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(defaultValue?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Charset>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("charset.(Ljava/nio/charset/Charset;)Ljava/nio/charset/Charset;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(defaultValue);
			}
		}

		[Register("get", "(Ljava/lang/String;)Lokhttp3/MediaType;", "")]
		public unsafe static MediaType Get(string @string)
		{
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<MediaType>(_members.StaticMethods.InvokeObjectMethod("get.(Ljava/lang/String;)Lokhttp3/MediaType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("parameter", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string Parameter(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("parameter.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("parse", "(Ljava/lang/String;)Lokhttp3/MediaType;", "")]
		public unsafe static MediaType Parse(string @string)
		{
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<MediaType>(_members.StaticMethods.InvokeObjectMethod("parse.(Ljava/lang/String;)Lokhttp3/MediaType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("subtype", "()Ljava/lang/String;", "")]
		public unsafe string Subtype()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("subtype.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("type", "()Ljava/lang/String;", "")]
		public unsafe string Type()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("type.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/MultipartBody", DoNotGenerateAcw = true)]
	public sealed class MultipartBody : RequestBody
	{
		[Register("okhttp3/MultipartBody$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/MultipartBody$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			[Register(".ctor", "(Ljava/lang/String;)V", "")]
			public unsafe Builder(string boundary)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.NewString(boundary);
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

			[Register("addFormDataPart", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/MultipartBody$Builder;", "")]
			public unsafe Builder AddFormDataPart(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addFormDataPart.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/MultipartBody$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("addFormDataPart", "(Ljava/lang/String;Ljava/lang/String;Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Builder;", "")]
			public unsafe Builder AddFormDataPart(string name, string filename, RequestBody body)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(filename);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					ptr[2] = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addFormDataPart.(Ljava/lang/String;Ljava/lang/String;Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(body);
				}
			}

			[Register("addPart", "(Lokhttp3/Headers;Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Builder;", "")]
			public unsafe Builder AddPart(Headers headers, RequestBody body)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(headers?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addPart.(Lokhttp3/Headers;Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(headers);
					GC.KeepAlive(body);
				}
			}

			[Register("addPart", "(Lokhttp3/MultipartBody$Part;)Lokhttp3/MultipartBody$Builder;", "")]
			public unsafe Builder AddPart(Part part)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(part?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addPart.(Lokhttp3/MultipartBody$Part;)Lokhttp3/MultipartBody$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(part);
				}
			}

			[Register("addPart", "(Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Builder;", "")]
			public unsafe Builder AddPart(RequestBody body)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addPart.(Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(body);
				}
			}

			[Register("build", "()Lokhttp3/MultipartBody;", "")]
			public unsafe MultipartBody Build()
			{
				return Java.Lang.Object.GetObject<MultipartBody>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lokhttp3/MultipartBody;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setType", "(Lokhttp3/MediaType;)Lokhttp3/MultipartBody$Builder;", "")]
			public unsafe Builder SetType(MediaType type)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setType.(Lokhttp3/MediaType;)Lokhttp3/MultipartBody$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(type);
				}
			}
		}

		[Register("okhttp3/MultipartBody$Part", DoNotGenerateAcw = true)]
		public sealed class Part : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/MultipartBody$Part", typeof(Part));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Part(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("body", "()Lokhttp3/RequestBody;", "")]
			public unsafe RequestBody Body()
			{
				return Java.Lang.Object.GetObject<RequestBody>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("body.()Lokhttp3/RequestBody;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("create", "(Lokhttp3/Headers;Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Part;", "")]
			public unsafe static Part Create(Headers headers, RequestBody body)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(headers?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Part>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/Headers;Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Part;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(headers);
					GC.KeepAlive(body);
				}
			}

			[Register("create", "(Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Part;", "")]
			public unsafe static Part Create(RequestBody body)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Part>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Part;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(body);
				}
			}

			[Register("createFormData", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/MultipartBody$Part;", "")]
			public unsafe static Part CreateFormData(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Part>(_members.StaticMethods.InvokeObjectMethod("createFormData.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/MultipartBody$Part;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("createFormData", "(Ljava/lang/String;Ljava/lang/String;Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Part;", "")]
			public unsafe static Part CreateFormData(string name, string filename, RequestBody body)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(filename);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					ptr[2] = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Part>(_members.StaticMethods.InvokeObjectMethod("createFormData.(Ljava/lang/String;Ljava/lang/String;Lokhttp3/RequestBody;)Lokhttp3/MultipartBody$Part;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(body);
				}
			}

			[Register("headers", "()Lokhttp3/Headers;", "")]
			public unsafe Headers Headers()
			{
				return Java.Lang.Object.GetObject<Headers>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("headers.()Lokhttp3/Headers;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/MultipartBody", typeof(MultipartBody));

		[Register("ALTERNATIVE")]
		public static MediaType Alternative => Java.Lang.Object.GetObject<MediaType>(_members.StaticFields.GetObjectValue("ALTERNATIVE.Lokhttp3/MediaType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DIGEST")]
		public static MediaType Digest => Java.Lang.Object.GetObject<MediaType>(_members.StaticFields.GetObjectValue("DIGEST.Lokhttp3/MediaType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FORM")]
		public static MediaType Form => Java.Lang.Object.GetObject<MediaType>(_members.StaticFields.GetObjectValue("FORM.Lokhttp3/MediaType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MIXED")]
		public static MediaType Mixed => Java.Lang.Object.GetObject<MediaType>(_members.StaticFields.GetObjectValue("MIXED.Lokhttp3/MediaType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PARALLEL")]
		public static MediaType Parallel => Java.Lang.Object.GetObject<MediaType>(_members.StaticFields.GetObjectValue("PARALLEL.Lokhttp3/MediaType;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal MultipartBody(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("boundary", "()Ljava/lang/String;", "")]
		public unsafe string Boundary()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("boundary.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("contentType", "()Lokhttp3/MediaType;", "")]
		public unsafe override MediaType ContentType()
		{
			return Java.Lang.Object.GetObject<MediaType>(_members.InstanceMethods.InvokeAbstractObjectMethod("contentType.()Lokhttp3/MediaType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("part", "(I)Lokhttp3/MultipartBody$Part;", "")]
		public unsafe Part InvokePart(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return Java.Lang.Object.GetObject<Part>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("part.(I)Lokhttp3/MultipartBody$Part;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("parts", "()Ljava/util/List;", "")]
		public unsafe IList<Part> Parts()
		{
			return JavaList<Part>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("parts.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("size", "()I", "")]
		public unsafe int Size()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("size.()I", this, null);
		}

		[Register("type", "()Lokhttp3/MediaType;", "")]
		public unsafe MediaType Type()
		{
			return Java.Lang.Object.GetObject<MediaType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("type.()Lokhttp3/MediaType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeTo", "(Lokio/BufferedSink;)V", "")]
		public unsafe override void WriteTo(IBufferedSink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeTo.(Lokio/BufferedSink;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}
	}
	[Register("okhttp3/MultipartReader", DoNotGenerateAcw = true)]
	public sealed class MultipartReader : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("okhttp3/MultipartReader$Part", DoNotGenerateAcw = true)]
		public sealed class Part : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/MultipartReader$Part", typeof(Part));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Part(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lokhttp3/Headers;Lokio/BufferedSource;)V", "")]
			public unsafe Part(Headers headers, IBufferedSource body)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(headers?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue((body == null) ? IntPtr.Zero : ((Java.Lang.Object)body).Handle);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokhttp3/Headers;Lokio/BufferedSource;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lokhttp3/Headers;Lokio/BufferedSource;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(headers);
					GC.KeepAlive(body);
				}
			}

			[Register("body", "()Lokio/BufferedSource;", "")]
			public unsafe IBufferedSource Body()
			{
				return Java.Lang.Object.GetObject<IBufferedSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("body.()Lokio/BufferedSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("close", "()V", "")]
			public unsafe void Close()
			{
				_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
			}

			[Register("headers", "()Lokhttp3/Headers;", "")]
			public unsafe Headers Headers()
			{
				return Java.Lang.Object.GetObject<Headers>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("headers.()Lokhttp3/Headers;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/MultipartReader", typeof(MultipartReader));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MultipartReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokhttp3/ResponseBody;)V", "")]
		public unsafe MultipartReader(ResponseBody response)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokhttp3/ResponseBody;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokhttp3/ResponseBody;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(response);
			}
		}

		[Register(".ctor", "(Lokio/BufferedSource;Ljava/lang/String;)V", "")]
		public unsafe MultipartReader(IBufferedSource source, string boundary)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(boundary);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokio/BufferedSource;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokio/BufferedSource;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(source);
			}
		}

		[Register("boundary", "()Ljava/lang/String;", "")]
		public unsafe string Boundary()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("boundary.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("close", "()V", "")]
		public unsafe void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("nextPart", "()Lokhttp3/MultipartReader$Part;", "")]
		public unsafe Part NextPart()
		{
			return Java.Lang.Object.GetObject<Part>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("nextPart.()Lokhttp3/MultipartReader$Part;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/OkHttp", DoNotGenerateAcw = true)]
	public sealed class OkHttp : Java.Lang.Object
	{
		[Register("VERSION")]
		public const string Version = "4.9.2";

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/OkHttp", typeof(OkHttp));

		[Register("INSTANCE")]
		public static OkHttp Instance => Java.Lang.Object.GetObject<OkHttp>(_members.StaticFields.GetObjectValue("INSTANCE.Lokhttp3/OkHttp;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal OkHttp(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("okhttp3/Protocol", DoNotGenerateAcw = true)]
	public sealed class Protocol : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Protocol", typeof(Protocol));

		[Register("H2_PRIOR_KNOWLEDGE")]
		public static Protocol H2PriorKnowledge => Java.Lang.Object.GetObject<Protocol>(_members.StaticFields.GetObjectValue("H2_PRIOR_KNOWLEDGE.Lokhttp3/Protocol;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("HTTP_1_0")]
		public static Protocol Http10 => Java.Lang.Object.GetObject<Protocol>(_members.StaticFields.GetObjectValue("HTTP_1_0.Lokhttp3/Protocol;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("HTTP_1_1")]
		public static Protocol Http11 => Java.Lang.Object.GetObject<Protocol>(_members.StaticFields.GetObjectValue("HTTP_1_1.Lokhttp3/Protocol;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("HTTP_2")]
		public static Protocol Http2 => Java.Lang.Object.GetObject<Protocol>(_members.StaticFields.GetObjectValue("HTTP_2.Lokhttp3/Protocol;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("QUIC")]
		public static Protocol Quic => Java.Lang.Object.GetObject<Protocol>(_members.StaticFields.GetObjectValue("QUIC.Lokhttp3/Protocol;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SPDY_3")]
		[Obsolete("deprecated")]
		public static Protocol Spdy3 => Java.Lang.Object.GetObject<Protocol>(_members.StaticFields.GetObjectValue("SPDY_3.Lokhttp3/Protocol;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Protocol(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("get", "(Ljava/lang/String;)Lokhttp3/Protocol;", "")]
		public unsafe static Protocol Get(string protocol)
		{
			IntPtr intPtr = JNIEnv.NewString(protocol);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Protocol>(_members.StaticMethods.InvokeObjectMethod("get.(Ljava/lang/String;)Lokhttp3/Protocol;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("valueOf", "(Ljava/lang/String;)Lokhttp3/Protocol;", "")]
		public unsafe static Protocol ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Protocol>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lokhttp3/Protocol;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lokhttp3/Protocol;", "")]
		public unsafe static Protocol[] Values()
		{
			return (Protocol[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lokhttp3/Protocol;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Protocol));
		}
	}
	[Register("okhttp3/Request", DoNotGenerateAcw = true)]
	public sealed class Request : Java.Lang.Object
	{
		[Register("okhttp3/Request$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Request$Builder", typeof(Builder));

			private static Delegate cb_addHeader_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_build;

			private static Delegate cb_cacheControl_Lokhttp3_CacheControl_;

			private static Delegate cb_delete_Lokhttp3_RequestBody_;

			private static Delegate cb_get;

			private static Delegate cb_head;

			private static Delegate cb_header_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_headers_Lokhttp3_Headers_;

			private static Delegate cb_method_Ljava_lang_String_Lokhttp3_RequestBody_;

			private static Delegate cb_patch_Lokhttp3_RequestBody_;

			private static Delegate cb_post_Lokhttp3_RequestBody_;

			private static Delegate cb_put_Lokhttp3_RequestBody_;

			private static Delegate cb_removeHeader_Ljava_lang_String_;

			private static Delegate cb_tag_Ljava_lang_Class_Ljava_lang_Object_;

			private static Delegate cb_tag_Ljava_lang_Object_;

			private static Delegate cb_url_Ljava_lang_String_;

			private static Delegate cb_url_Ljava_net_URL_;

			private static Delegate cb_url_Lokhttp3_HttpUrl_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			private static IntPtr n_AddHeader_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
				string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddHeader(name, value));
			}

			[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Request$Builder;", "GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe virtual Builder AddHeader(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addHeader.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
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

			[Register("build", "()Lokhttp3/Request;", "GetBuildHandler")]
			public unsafe virtual Request Build()
			{
				return Java.Lang.Object.GetObject<Request>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lokhttp3/Request;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetCacheControl_Lokhttp3_CacheControl_Handler()
			{
				if ((object)cb_cacheControl_Lokhttp3_CacheControl_ == null)
				{
					cb_cacheControl_Lokhttp3_CacheControl_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CacheControl_Lokhttp3_CacheControl_));
				}
				return cb_cacheControl_Lokhttp3_CacheControl_;
			}

			private static IntPtr n_CacheControl_Lokhttp3_CacheControl_(IntPtr jnienv, IntPtr native__this, IntPtr native_cacheControl)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CacheControl cacheControl = Java.Lang.Object.GetObject<CacheControl>(native_cacheControl, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.CacheControl(cacheControl));
			}

			[Register("cacheControl", "(Lokhttp3/CacheControl;)Lokhttp3/Request$Builder;", "GetCacheControl_Lokhttp3_CacheControl_Handler")]
			public unsafe virtual Builder CacheControl(CacheControl cacheControl)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(cacheControl?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("cacheControl.(Lokhttp3/CacheControl;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(cacheControl);
				}
			}

			[Register("delete", "()Lokhttp3/Request$Builder;", "")]
			public unsafe Builder Delete()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("delete.()Lokhttp3/Request$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetDelete_Lokhttp3_RequestBody_Handler()
			{
				if ((object)cb_delete_Lokhttp3_RequestBody_ == null)
				{
					cb_delete_Lokhttp3_RequestBody_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Delete_Lokhttp3_RequestBody_));
				}
				return cb_delete_Lokhttp3_RequestBody_;
			}

			private static IntPtr n_Delete_Lokhttp3_RequestBody_(IntPtr jnienv, IntPtr native__this, IntPtr native_body)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RequestBody body = Java.Lang.Object.GetObject<RequestBody>(native_body, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Delete(body));
			}

			[Register("delete", "(Lokhttp3/RequestBody;)Lokhttp3/Request$Builder;", "GetDelete_Lokhttp3_RequestBody_Handler")]
			public unsafe virtual Builder Delete(RequestBody body)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("delete.(Lokhttp3/RequestBody;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(body);
				}
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get());
			}

			[Register("get", "()Lokhttp3/Request$Builder;", "GetGetHandler")]
			public unsafe virtual Builder Get()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.()Lokhttp3/Request$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetHeadHandler()
			{
				if ((object)cb_head == null)
				{
					cb_head = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Head));
				}
				return cb_head;
			}

			private static IntPtr n_Head(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Head());
			}

			[Register("head", "()Lokhttp3/Request$Builder;", "GetHeadHandler")]
			public unsafe virtual Builder Head()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("head.()Lokhttp3/Request$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetHeader_Ljava_lang_String_Ljava_lang_String_Handler()
			{
				if ((object)cb_header_Ljava_lang_String_Ljava_lang_String_ == null)
				{
					cb_header_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Header_Ljava_lang_String_Ljava_lang_String_));
				}
				return cb_header_Ljava_lang_String_Ljava_lang_String_;
			}

			private static IntPtr n_Header_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
				string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Header(name, value));
			}

			[Register("header", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Request$Builder;", "GetHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Header(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("header.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			private static Delegate GetHeaders_Lokhttp3_Headers_Handler()
			{
				if ((object)cb_headers_Lokhttp3_Headers_ == null)
				{
					cb_headers_Lokhttp3_Headers_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Headers_Lokhttp3_Headers_));
				}
				return cb_headers_Lokhttp3_Headers_;
			}

			private static IntPtr n_Headers_Lokhttp3_Headers_(IntPtr jnienv, IntPtr native__this, IntPtr native_headers)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Headers headers = Java.Lang.Object.GetObject<Headers>(native_headers, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Headers(headers));
			}

			[Register("headers", "(Lokhttp3/Headers;)Lokhttp3/Request$Builder;", "GetHeaders_Lokhttp3_Headers_Handler")]
			public unsafe virtual Builder Headers(Headers headers)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(headers?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("headers.(Lokhttp3/Headers;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(headers);
				}
			}

			private static Delegate GetMethod_Ljava_lang_String_Lokhttp3_RequestBody_Handler()
			{
				if ((object)cb_method_Ljava_lang_String_Lokhttp3_RequestBody_ == null)
				{
					cb_method_Ljava_lang_String_Lokhttp3_RequestBody_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Method_Ljava_lang_String_Lokhttp3_RequestBody_));
				}
				return cb_method_Ljava_lang_String_Lokhttp3_RequestBody_;
			}

			private static IntPtr n_Method_Ljava_lang_String_Lokhttp3_RequestBody_(IntPtr jnienv, IntPtr native__this, IntPtr native_method, IntPtr native_body)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string method = JNIEnv.GetString(native_method, JniHandleOwnership.DoNotTransfer);
				RequestBody body = Java.Lang.Object.GetObject<RequestBody>(native_body, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Method(method, body));
			}

			[Register("method", "(Ljava/lang/String;Lokhttp3/RequestBody;)Lokhttp3/Request$Builder;", "GetMethod_Ljava_lang_String_Lokhttp3_RequestBody_Handler")]
			public unsafe virtual Builder Method(string method, RequestBody body)
			{
				IntPtr intPtr = JNIEnv.NewString(method);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("method.(Ljava/lang/String;Lokhttp3/RequestBody;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(body);
				}
			}

			private static Delegate GetPatch_Lokhttp3_RequestBody_Handler()
			{
				if ((object)cb_patch_Lokhttp3_RequestBody_ == null)
				{
					cb_patch_Lokhttp3_RequestBody_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Patch_Lokhttp3_RequestBody_));
				}
				return cb_patch_Lokhttp3_RequestBody_;
			}

			private static IntPtr n_Patch_Lokhttp3_RequestBody_(IntPtr jnienv, IntPtr native__this, IntPtr native_body)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RequestBody body = Java.Lang.Object.GetObject<RequestBody>(native_body, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Patch(body));
			}

			[Register("patch", "(Lokhttp3/RequestBody;)Lokhttp3/Request$Builder;", "GetPatch_Lokhttp3_RequestBody_Handler")]
			public unsafe virtual Builder Patch(RequestBody body)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("patch.(Lokhttp3/RequestBody;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(body);
				}
			}

			private static Delegate GetPost_Lokhttp3_RequestBody_Handler()
			{
				if ((object)cb_post_Lokhttp3_RequestBody_ == null)
				{
					cb_post_Lokhttp3_RequestBody_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Post_Lokhttp3_RequestBody_));
				}
				return cb_post_Lokhttp3_RequestBody_;
			}

			private static IntPtr n_Post_Lokhttp3_RequestBody_(IntPtr jnienv, IntPtr native__this, IntPtr native_body)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RequestBody body = Java.Lang.Object.GetObject<RequestBody>(native_body, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Post(body));
			}

			[Register("post", "(Lokhttp3/RequestBody;)Lokhttp3/Request$Builder;", "GetPost_Lokhttp3_RequestBody_Handler")]
			public unsafe virtual Builder Post(RequestBody body)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("post.(Lokhttp3/RequestBody;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(body);
				}
			}

			private static Delegate GetPut_Lokhttp3_RequestBody_Handler()
			{
				if ((object)cb_put_Lokhttp3_RequestBody_ == null)
				{
					cb_put_Lokhttp3_RequestBody_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Put_Lokhttp3_RequestBody_));
				}
				return cb_put_Lokhttp3_RequestBody_;
			}

			private static IntPtr n_Put_Lokhttp3_RequestBody_(IntPtr jnienv, IntPtr native__this, IntPtr native_body)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RequestBody body = Java.Lang.Object.GetObject<RequestBody>(native_body, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Put(body));
			}

			[Register("put", "(Lokhttp3/RequestBody;)Lokhttp3/Request$Builder;", "GetPut_Lokhttp3_RequestBody_Handler")]
			public unsafe virtual Builder Put(RequestBody body)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("put.(Lokhttp3/RequestBody;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(body);
				}
			}

			private static Delegate GetRemoveHeader_Ljava_lang_String_Handler()
			{
				if ((object)cb_removeHeader_Ljava_lang_String_ == null)
				{
					cb_removeHeader_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveHeader_Ljava_lang_String_));
				}
				return cb_removeHeader_Ljava_lang_String_;
			}

			private static IntPtr n_RemoveHeader_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.RemoveHeader(name));
			}

			[Register("removeHeader", "(Ljava/lang/String;)Lokhttp3/Request$Builder;", "GetRemoveHeader_Ljava_lang_String_Handler")]
			public unsafe virtual Builder RemoveHeader(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeHeader.(Ljava/lang/String;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetTag_Ljava_lang_Class_Ljava_lang_Object_Handler()
			{
				if ((object)cb_tag_Ljava_lang_Class_Ljava_lang_Object_ == null)
				{
					cb_tag_Ljava_lang_Class_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Tag_Ljava_lang_Class_Ljava_lang_Object_));
				}
				return cb_tag_Ljava_lang_Class_Ljava_lang_Object_;
			}

			private static IntPtr n_Tag_Ljava_lang_Class_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_type, IntPtr native_tag)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Class type = Java.Lang.Object.GetObject<Class>(native_type, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Tag(type, tag));
			}

			[Register("tag", "(Ljava/lang/Class;Ljava/lang/Object;)Lokhttp3/Request$Builder;", "GetTag_Ljava_lang_Class_Ljava_lang_Object_Handler")]
			[JavaTypeParameters(new string[] { "T" })]
			public unsafe virtual Builder Tag(Class type, Java.Lang.Object tag)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(tag);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("tag.(Ljava/lang/Class;Ljava/lang/Object;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(type);
					GC.KeepAlive(tag);
				}
			}

			private static Delegate GetTag_Ljava_lang_Object_Handler()
			{
				if ((object)cb_tag_Ljava_lang_Object_ == null)
				{
					cb_tag_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Tag_Ljava_lang_Object_));
				}
				return cb_tag_Ljava_lang_Object_;
			}

			private static IntPtr n_Tag_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_tag)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Tag(tag));
			}

			[Register("tag", "(Ljava/lang/Object;)Lokhttp3/Request$Builder;", "GetTag_Ljava_lang_Object_Handler")]
			public unsafe virtual Builder Tag(Java.Lang.Object tag)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("tag.(Ljava/lang/Object;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(tag);
				}
			}

			private static Delegate GetUrl_Ljava_lang_String_Handler()
			{
				if ((object)cb_url_Ljava_lang_String_ == null)
				{
					cb_url_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Url_Ljava_lang_String_));
				}
				return cb_url_Ljava_lang_String_;
			}

			private static IntPtr n_Url_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_url)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string url = JNIEnv.GetString(native_url, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Url(url));
			}

			[Register("url", "(Ljava/lang/String;)Lokhttp3/Request$Builder;", "GetUrl_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Url(string url)
			{
				IntPtr intPtr = JNIEnv.NewString(url);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("url.(Ljava/lang/String;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetUrl_Ljava_net_URL_Handler()
			{
				if ((object)cb_url_Ljava_net_URL_ == null)
				{
					cb_url_Ljava_net_URL_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Url_Ljava_net_URL_));
				}
				return cb_url_Ljava_net_URL_;
			}

			private static IntPtr n_Url_Ljava_net_URL_(IntPtr jnienv, IntPtr native__this, IntPtr native_url)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				URL url = Java.Lang.Object.GetObject<URL>(native_url, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Url(url));
			}

			[Register("url", "(Ljava/net/URL;)Lokhttp3/Request$Builder;", "GetUrl_Ljava_net_URL_Handler")]
			public unsafe virtual Builder Url(URL url)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("url.(Ljava/net/URL;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(url);
				}
			}

			private static Delegate GetUrl_Lokhttp3_HttpUrl_Handler()
			{
				if ((object)cb_url_Lokhttp3_HttpUrl_ == null)
				{
					cb_url_Lokhttp3_HttpUrl_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Url_Lokhttp3_HttpUrl_));
				}
				return cb_url_Lokhttp3_HttpUrl_;
			}

			private static IntPtr n_Url_Lokhttp3_HttpUrl_(IntPtr jnienv, IntPtr native__this, IntPtr native_url)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				HttpUrl url = Java.Lang.Object.GetObject<HttpUrl>(native_url, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Url(url));
			}

			[Register("url", "(Lokhttp3/HttpUrl;)Lokhttp3/Request$Builder;", "GetUrl_Lokhttp3_HttpUrl_Handler")]
			public unsafe virtual Builder Url(HttpUrl url)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("url.(Lokhttp3/HttpUrl;)Lokhttp3/Request$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(url);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Request", typeof(Request));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsHttps
		{
			[Register("isHttps", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isHttps.()Z", this, null);
			}
		}

		internal Request(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("body", "()Lokhttp3/RequestBody;", "")]
		public unsafe RequestBody Body()
		{
			return Java.Lang.Object.GetObject<RequestBody>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("body.()Lokhttp3/RequestBody;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("cacheControl", "()Lokhttp3/CacheControl;", "")]
		public unsafe CacheControl CacheControl()
		{
			return Java.Lang.Object.GetObject<CacheControl>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cacheControl.()Lokhttp3/CacheControl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("header", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string Header(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("header.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("headers", "()Lokhttp3/Headers;", "")]
		public unsafe Headers Headers()
		{
			return Java.Lang.Object.GetObject<Headers>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("headers.()Lokhttp3/Headers;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("headers", "(Ljava/lang/String;)Ljava/util/List;", "")]
		public unsafe IList<string> Headers(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("headers.(Ljava/lang/String;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("method", "()Ljava/lang/String;", "")]
		public unsafe string Method()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("method.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("newBuilder", "()Lokhttp3/Request$Builder;", "")]
		public unsafe Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("newBuilder.()Lokhttp3/Request$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("tag", "()Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object Tag()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("tag.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("tag", "(Ljava/lang/Class;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe Java.Lang.Object Tag(Class type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("tag.(Ljava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		[Register("url", "()Lokhttp3/HttpUrl;", "")]
		public unsafe HttpUrl Url()
		{
			return Java.Lang.Object.GetObject<HttpUrl>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("url.()Lokhttp3/HttpUrl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/RequestBody", DoNotGenerateAcw = true)]
	public abstract class RequestBody : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/RequestBody", typeof(RequestBody));

		private static Delegate cb_isDuplex;

		private static Delegate cb_isOneShot;

		private static Delegate cb_contentLength;

		private static Delegate cb_contentType;

		private static Delegate cb_writeTo_Lokio_BufferedSink_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool IsDuplex
		{
			[Register("isDuplex", "()Z", "GetIsDuplexHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDuplex.()Z", this, null);
			}
		}

		public unsafe virtual bool IsOneShot
		{
			[Register("isOneShot", "()Z", "GetIsOneShotHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOneShot.()Z", this, null);
			}
		}

		protected RequestBody(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe RequestBody()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsDuplexHandler()
		{
			if ((object)cb_isDuplex == null)
			{
				cb_isDuplex = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDuplex));
			}
			return cb_isDuplex;
		}

		private static bool n_IsDuplex(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<RequestBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDuplex;
		}

		private static Delegate GetIsOneShotHandler()
		{
			if ((object)cb_isOneShot == null)
			{
				cb_isOneShot = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsOneShot));
			}
			return cb_isOneShot;
		}

		private static bool n_IsOneShot(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<RequestBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOneShot;
		}

		private static Delegate GetContentLengthHandler()
		{
			if ((object)cb_contentLength == null)
			{
				cb_contentLength = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_ContentLength));
			}
			return cb_contentLength;
		}

		private static long n_ContentLength(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<RequestBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentLength();
		}

		[Register("contentLength", "()J", "GetContentLengthHandler")]
		public unsafe virtual long ContentLength()
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("contentLength.()J", this, null);
		}

		private static Delegate GetContentTypeHandler()
		{
			if ((object)cb_contentType == null)
			{
				cb_contentType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ContentType));
			}
			return cb_contentType;
		}

		private static IntPtr n_ContentType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RequestBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentType());
		}

		[Register("contentType", "()Lokhttp3/MediaType;", "GetContentTypeHandler")]
		public abstract MediaType ContentType();

		[Register("create", "([B)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(byte[] content)
		{
			IntPtr intPtr = JNIEnv.NewArray(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.([B)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (content != null)
				{
					JNIEnv.CopyArray(intPtr, content);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(content);
			}
		}

		[Register("create", "([BLokhttp3/MediaType;)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(byte[] content, MediaType contentType)
		{
			IntPtr intPtr = JNIEnv.NewArray(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.([BLokhttp3/MediaType;)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (content != null)
				{
					JNIEnv.CopyArray(intPtr, content);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(content);
				GC.KeepAlive(contentType);
			}
		}

		[Register("create", "([BLokhttp3/MediaType;I)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(byte[] content, MediaType contentType, int offset)
		{
			IntPtr intPtr = JNIEnv.NewArray(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(offset);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.([BLokhttp3/MediaType;I)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (content != null)
				{
					JNIEnv.CopyArray(intPtr, content);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(content);
				GC.KeepAlive(contentType);
			}
		}

		[Register("create", "([BLokhttp3/MediaType;II)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(byte[] content, MediaType contentType, int offset, int byteCount)
		{
			IntPtr intPtr = JNIEnv.NewArray(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(offset);
				ptr[3] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.([BLokhttp3/MediaType;II)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (content != null)
				{
					JNIEnv.CopyArray(intPtr, content);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(content);
				GC.KeepAlive(contentType);
			}
		}

		[Register("create", "(Ljava/io/File;Lokhttp3/MediaType;)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(Java.IO.File file, MediaType contentType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/io/File;Lokhttp3/MediaType;)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(file);
				GC.KeepAlive(contentType);
			}
		}

		[Register("create", "(Ljava/lang/String;Lokhttp3/MediaType;)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(string content, MediaType contentType)
		{
			IntPtr intPtr = JNIEnv.NewString(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/lang/String;Lokhttp3/MediaType;)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(contentType);
			}
		}

		[Obsolete("deprecated")]
		[Register("create", "(Lokhttp3/MediaType;[B)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(MediaType contentType, byte[] content)
		{
			IntPtr intPtr = JNIEnv.NewArray(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/MediaType;[B)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (content != null)
				{
					JNIEnv.CopyArray(intPtr, content);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(contentType);
				GC.KeepAlive(content);
			}
		}

		[Obsolete("deprecated")]
		[Register("create", "(Lokhttp3/MediaType;[BI)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(MediaType contentType, byte[] content, int offset)
		{
			IntPtr intPtr = JNIEnv.NewArray(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(offset);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/MediaType;[BI)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (content != null)
				{
					JNIEnv.CopyArray(intPtr, content);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(contentType);
				GC.KeepAlive(content);
			}
		}

		[Obsolete("deprecated")]
		[Register("create", "(Lokhttp3/MediaType;[BII)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(MediaType contentType, byte[] content, int offset, int byteCount)
		{
			IntPtr intPtr = JNIEnv.NewArray(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(offset);
				ptr[3] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/MediaType;[BII)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (content != null)
				{
					JNIEnv.CopyArray(intPtr, content);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(contentType);
				GC.KeepAlive(content);
			}
		}

		[Obsolete("deprecated")]
		[Register("create", "(Lokhttp3/MediaType;Ljava/io/File;)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(MediaType contentType, Java.IO.File file)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/MediaType;Ljava/io/File;)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(contentType);
				GC.KeepAlive(file);
			}
		}

		[Obsolete("deprecated")]
		[Register("create", "(Lokhttp3/MediaType;Ljava/lang/String;)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(MediaType contentType, string content)
		{
			IntPtr intPtr = JNIEnv.NewString(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/MediaType;Ljava/lang/String;)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(contentType);
			}
		}

		[Obsolete("deprecated")]
		[Register("create", "(Lokhttp3/MediaType;Lokio/ByteString;)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(MediaType contentType, ByteString content)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokhttp3/MediaType;Lokio/ByteString;)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(contentType);
				GC.KeepAlive(content);
			}
		}

		[Register("create", "(Lokio/ByteString;Lokhttp3/MediaType;)Lokhttp3/RequestBody;", "")]
		public unsafe static RequestBody Create(ByteString content, MediaType contentType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<RequestBody>(_members.StaticMethods.InvokeObjectMethod("create.(Lokio/ByteString;Lokhttp3/MediaType;)Lokhttp3/RequestBody;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(content);
				GC.KeepAlive(contentType);
			}
		}

		private static Delegate GetWriteTo_Lokio_BufferedSink_Handler()
		{
			if ((object)cb_writeTo_Lokio_BufferedSink_ == null)
			{
				cb_writeTo_Lokio_BufferedSink_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_WriteTo_Lokio_BufferedSink_));
			}
			return cb_writeTo_Lokio_BufferedSink_;
		}

		private static void n_WriteTo_Lokio_BufferedSink_(IntPtr jnienv, IntPtr native__this, IntPtr native_sink)
		{
			RequestBody requestBody = Java.Lang.Object.GetObject<RequestBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IBufferedSink sink = Java.Lang.Object.GetObject<IBufferedSink>(native_sink, JniHandleOwnership.DoNotTransfer);
			requestBody.WriteTo(sink);
		}

		[Register("writeTo", "(Lokio/BufferedSink;)V", "GetWriteTo_Lokio_BufferedSink_Handler")]
		public abstract void WriteTo(IBufferedSink sink);
	}
	[Register("okhttp3/RequestBody", DoNotGenerateAcw = true)]
	internal class RequestBodyInvoker : RequestBody
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/RequestBody", typeof(RequestBodyInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public RequestBodyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("contentType", "()Lokhttp3/MediaType;", "GetContentTypeHandler")]
		public unsafe override MediaType ContentType()
		{
			return Java.Lang.Object.GetObject<MediaType>(_members.InstanceMethods.InvokeAbstractObjectMethod("contentType.()Lokhttp3/MediaType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeTo", "(Lokio/BufferedSink;)V", "GetWriteTo_Lokio_BufferedSink_Handler")]
		public unsafe override void WriteTo(IBufferedSink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeTo.(Lokio/BufferedSink;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}
	}
	[Register("okhttp3/Response", DoNotGenerateAcw = true)]
	public sealed class Response : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("okhttp3/Response$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Response$Builder", typeof(Builder));

			private static Delegate cb_addHeader_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_body_Lokhttp3_ResponseBody_;

			private static Delegate cb_build;

			private static Delegate cb_cacheResponse_Lokhttp3_Response_;

			private static Delegate cb_code_I;

			private static Delegate cb_handshake_Lokhttp3_Handshake_;

			private static Delegate cb_header_Ljava_lang_String_Ljava_lang_String_;

			private static Delegate cb_headers_Lokhttp3_Headers_;

			private static Delegate cb_message_Ljava_lang_String_;

			private static Delegate cb_networkResponse_Lokhttp3_Response_;

			private static Delegate cb_priorResponse_Lokhttp3_Response_;

			private static Delegate cb_protocol_Lokhttp3_Protocol_;

			private static Delegate cb_receivedResponseAtMillis_J;

			private static Delegate cb_removeHeader_Ljava_lang_String_;

			private static Delegate cb_request_Lokhttp3_Request_;

			private static Delegate cb_sentRequestAtMillis_J;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

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

			private static IntPtr n_AddHeader_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
				string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddHeader(name, value));
			}

			[Register("addHeader", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Response$Builder;", "GetAddHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe virtual Builder AddHeader(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addHeader.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			private static Delegate GetBody_Lokhttp3_ResponseBody_Handler()
			{
				if ((object)cb_body_Lokhttp3_ResponseBody_ == null)
				{
					cb_body_Lokhttp3_ResponseBody_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Body_Lokhttp3_ResponseBody_));
				}
				return cb_body_Lokhttp3_ResponseBody_;
			}

			private static IntPtr n_Body_Lokhttp3_ResponseBody_(IntPtr jnienv, IntPtr native__this, IntPtr native_body)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ResponseBody body = Java.Lang.Object.GetObject<ResponseBody>(native_body, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Body(body));
			}

			[Register("body", "(Lokhttp3/ResponseBody;)Lokhttp3/Response$Builder;", "GetBody_Lokhttp3_ResponseBody_Handler")]
			public unsafe virtual Builder Body(ResponseBody body)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("body.(Lokhttp3/ResponseBody;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(body);
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

			[Register("build", "()Lokhttp3/Response;", "GetBuildHandler")]
			public unsafe virtual Response Build()
			{
				return Java.Lang.Object.GetObject<Response>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lokhttp3/Response;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetCacheResponse_Lokhttp3_Response_Handler()
			{
				if ((object)cb_cacheResponse_Lokhttp3_Response_ == null)
				{
					cb_cacheResponse_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CacheResponse_Lokhttp3_Response_));
				}
				return cb_cacheResponse_Lokhttp3_Response_;
			}

			private static IntPtr n_CacheResponse_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_cacheResponse)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Response cacheResponse = Java.Lang.Object.GetObject<Response>(native_cacheResponse, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.CacheResponse(cacheResponse));
			}

			[Register("cacheResponse", "(Lokhttp3/Response;)Lokhttp3/Response$Builder;", "GetCacheResponse_Lokhttp3_Response_Handler")]
			public unsafe virtual Builder CacheResponse(Response cacheResponse)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(cacheResponse?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("cacheResponse.(Lokhttp3/Response;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(cacheResponse);
				}
			}

			private static Delegate GetCode_IHandler()
			{
				if ((object)cb_code_I == null)
				{
					cb_code_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_Code_I));
				}
				return cb_code_I;
			}

			private static IntPtr n_Code_I(IntPtr jnienv, IntPtr native__this, int code)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Code(code));
			}

			[Register("code", "(I)Lokhttp3/Response$Builder;", "GetCode_IHandler")]
			public unsafe virtual Builder Code(int code)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(code);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("code.(I)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetHandshake_Lokhttp3_Handshake_Handler()
			{
				if ((object)cb_handshake_Lokhttp3_Handshake_ == null)
				{
					cb_handshake_Lokhttp3_Handshake_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Handshake_Lokhttp3_Handshake_));
				}
				return cb_handshake_Lokhttp3_Handshake_;
			}

			private static IntPtr n_Handshake_Lokhttp3_Handshake_(IntPtr jnienv, IntPtr native__this, IntPtr native_handshake)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Handshake handshake = Java.Lang.Object.GetObject<Handshake>(native_handshake, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Handshake(handshake));
			}

			[Register("handshake", "(Lokhttp3/Handshake;)Lokhttp3/Response$Builder;", "GetHandshake_Lokhttp3_Handshake_Handler")]
			public unsafe virtual Builder Handshake(Handshake handshake)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(handshake?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("handshake.(Lokhttp3/Handshake;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(handshake);
				}
			}

			private static Delegate GetHeader_Ljava_lang_String_Ljava_lang_String_Handler()
			{
				if ((object)cb_header_Ljava_lang_String_Ljava_lang_String_ == null)
				{
					cb_header_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Header_Ljava_lang_String_Ljava_lang_String_));
				}
				return cb_header_Ljava_lang_String_Ljava_lang_String_;
			}

			private static IntPtr n_Header_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
				string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Header(name, value));
			}

			[Register("header", "(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Response$Builder;", "GetHeader_Ljava_lang_String_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Header(string name, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("header.(Ljava/lang/String;Ljava/lang/String;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			private static Delegate GetHeaders_Lokhttp3_Headers_Handler()
			{
				if ((object)cb_headers_Lokhttp3_Headers_ == null)
				{
					cb_headers_Lokhttp3_Headers_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Headers_Lokhttp3_Headers_));
				}
				return cb_headers_Lokhttp3_Headers_;
			}

			private static IntPtr n_Headers_Lokhttp3_Headers_(IntPtr jnienv, IntPtr native__this, IntPtr native_headers)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Headers headers = Java.Lang.Object.GetObject<Headers>(native_headers, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Headers(headers));
			}

			[Register("headers", "(Lokhttp3/Headers;)Lokhttp3/Response$Builder;", "GetHeaders_Lokhttp3_Headers_Handler")]
			public unsafe virtual Builder Headers(Headers headers)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(headers?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("headers.(Lokhttp3/Headers;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(headers);
				}
			}

			private static Delegate GetMessage_Ljava_lang_String_Handler()
			{
				if ((object)cb_message_Ljava_lang_String_ == null)
				{
					cb_message_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Message_Ljava_lang_String_));
				}
				return cb_message_Ljava_lang_String_;
			}

			private static IntPtr n_Message_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_message)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string message = JNIEnv.GetString(native_message, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Message(message));
			}

			[Register("message", "(Ljava/lang/String;)Lokhttp3/Response$Builder;", "GetMessage_Ljava_lang_String_Handler")]
			public unsafe virtual Builder Message(string message)
			{
				IntPtr intPtr = JNIEnv.NewString(message);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("message.(Ljava/lang/String;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetNetworkResponse_Lokhttp3_Response_Handler()
			{
				if ((object)cb_networkResponse_Lokhttp3_Response_ == null)
				{
					cb_networkResponse_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_NetworkResponse_Lokhttp3_Response_));
				}
				return cb_networkResponse_Lokhttp3_Response_;
			}

			private static IntPtr n_NetworkResponse_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_networkResponse)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Response networkResponse = Java.Lang.Object.GetObject<Response>(native_networkResponse, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.NetworkResponse(networkResponse));
			}

			[Register("networkResponse", "(Lokhttp3/Response;)Lokhttp3/Response$Builder;", "GetNetworkResponse_Lokhttp3_Response_Handler")]
			public unsafe virtual Builder NetworkResponse(Response networkResponse)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(networkResponse?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("networkResponse.(Lokhttp3/Response;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(networkResponse);
				}
			}

			private static Delegate GetPriorResponse_Lokhttp3_Response_Handler()
			{
				if ((object)cb_priorResponse_Lokhttp3_Response_ == null)
				{
					cb_priorResponse_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PriorResponse_Lokhttp3_Response_));
				}
				return cb_priorResponse_Lokhttp3_Response_;
			}

			private static IntPtr n_PriorResponse_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_priorResponse)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Response priorResponse = Java.Lang.Object.GetObject<Response>(native_priorResponse, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.PriorResponse(priorResponse));
			}

			[Register("priorResponse", "(Lokhttp3/Response;)Lokhttp3/Response$Builder;", "GetPriorResponse_Lokhttp3_Response_Handler")]
			public unsafe virtual Builder PriorResponse(Response priorResponse)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(priorResponse?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("priorResponse.(Lokhttp3/Response;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(priorResponse);
				}
			}

			private static Delegate GetProtocol_Lokhttp3_Protocol_Handler()
			{
				if ((object)cb_protocol_Lokhttp3_Protocol_ == null)
				{
					cb_protocol_Lokhttp3_Protocol_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Protocol_Lokhttp3_Protocol_));
				}
				return cb_protocol_Lokhttp3_Protocol_;
			}

			private static IntPtr n_Protocol_Lokhttp3_Protocol_(IntPtr jnienv, IntPtr native__this, IntPtr native_protocol)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Protocol protocol = Java.Lang.Object.GetObject<Protocol>(native_protocol, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Protocol(protocol));
			}

			[Register("protocol", "(Lokhttp3/Protocol;)Lokhttp3/Response$Builder;", "GetProtocol_Lokhttp3_Protocol_Handler")]
			public unsafe virtual Builder Protocol(Protocol protocol)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(protocol?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("protocol.(Lokhttp3/Protocol;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(protocol);
				}
			}

			private static Delegate GetReceivedResponseAtMillis_JHandler()
			{
				if ((object)cb_receivedResponseAtMillis_J == null)
				{
					cb_receivedResponseAtMillis_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_ReceivedResponseAtMillis_J));
				}
				return cb_receivedResponseAtMillis_J;
			}

			private static IntPtr n_ReceivedResponseAtMillis_J(IntPtr jnienv, IntPtr native__this, long receivedResponseAtMillis)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReceivedResponseAtMillis(receivedResponseAtMillis));
			}

			[Register("receivedResponseAtMillis", "(J)Lokhttp3/Response$Builder;", "GetReceivedResponseAtMillis_JHandler")]
			public unsafe virtual Builder ReceivedResponseAtMillis(long receivedResponseAtMillis)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(receivedResponseAtMillis);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("receivedResponseAtMillis.(J)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetRemoveHeader_Ljava_lang_String_Handler()
			{
				if ((object)cb_removeHeader_Ljava_lang_String_ == null)
				{
					cb_removeHeader_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveHeader_Ljava_lang_String_));
				}
				return cb_removeHeader_Ljava_lang_String_;
			}

			private static IntPtr n_RemoveHeader_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.RemoveHeader(name));
			}

			[Register("removeHeader", "(Ljava/lang/String;)Lokhttp3/Response$Builder;", "GetRemoveHeader_Ljava_lang_String_Handler")]
			public unsafe virtual Builder RemoveHeader(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeHeader.(Ljava/lang/String;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetRequest_Lokhttp3_Request_Handler()
			{
				if ((object)cb_request_Lokhttp3_Request_ == null)
				{
					cb_request_Lokhttp3_Request_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Request_Lokhttp3_Request_));
				}
				return cb_request_Lokhttp3_Request_;
			}

			private static IntPtr n_Request_Lokhttp3_Request_(IntPtr jnienv, IntPtr native__this, IntPtr native_request)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Request request = Java.Lang.Object.GetObject<Request>(native_request, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Request(request));
			}

			[Register("request", "(Lokhttp3/Request;)Lokhttp3/Response$Builder;", "GetRequest_Lokhttp3_Request_Handler")]
			public unsafe virtual Builder Request(Request request)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("request.(Lokhttp3/Request;)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(request);
				}
			}

			private static Delegate GetSentRequestAtMillis_JHandler()
			{
				if ((object)cb_sentRequestAtMillis_J == null)
				{
					cb_sentRequestAtMillis_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SentRequestAtMillis_J));
				}
				return cb_sentRequestAtMillis_J;
			}

			private static IntPtr n_SentRequestAtMillis_J(IntPtr jnienv, IntPtr native__this, long sentRequestAtMillis)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SentRequestAtMillis(sentRequestAtMillis));
			}

			[Register("sentRequestAtMillis", "(J)Lokhttp3/Response$Builder;", "GetSentRequestAtMillis_JHandler")]
			public unsafe virtual Builder SentRequestAtMillis(long sentRequestAtMillis)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sentRequestAtMillis);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("sentRequestAtMillis.(J)Lokhttp3/Response$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Response", typeof(Response));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsRedirect
		{
			[Register("isRedirect", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isRedirect.()Z", this, null);
			}
		}

		public unsafe bool IsSuccessful
		{
			[Register("isSuccessful", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isSuccessful.()Z", this, null);
			}
		}

		internal Response(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("body", "()Lokhttp3/ResponseBody;", "")]
		public unsafe ResponseBody Body()
		{
			return Java.Lang.Object.GetObject<ResponseBody>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("body.()Lokhttp3/ResponseBody;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("cacheControl", "()Lokhttp3/CacheControl;", "")]
		public unsafe CacheControl CacheControl()
		{
			return Java.Lang.Object.GetObject<CacheControl>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cacheControl.()Lokhttp3/CacheControl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("cacheResponse", "()Lokhttp3/Response;", "")]
		public unsafe Response CacheResponse()
		{
			return Java.Lang.Object.GetObject<Response>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("cacheResponse.()Lokhttp3/Response;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("challenges", "()Ljava/util/List;", "")]
		public unsafe IList<Challenge> Challenges()
		{
			return JavaList<Challenge>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("challenges.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("close", "()V", "")]
		public unsafe void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("code", "()I", "")]
		public unsafe int Code()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("code.()I", this, null);
		}

		[Register("handshake", "()Lokhttp3/Handshake;", "")]
		public unsafe Handshake Handshake()
		{
			return Java.Lang.Object.GetObject<Handshake>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("handshake.()Lokhttp3/Handshake;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("header", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string Header(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("header.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("header", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string Header(string name, string defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			IntPtr intPtr2 = JNIEnv.NewString(defaultValue);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("header.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("headers", "()Lokhttp3/Headers;", "")]
		public unsafe Headers Headers()
		{
			return Java.Lang.Object.GetObject<Headers>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("headers.()Lokhttp3/Headers;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("headers", "(Ljava/lang/String;)Ljava/util/List;", "")]
		public unsafe IList<string> Headers(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("headers.(Ljava/lang/String;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("message", "()Ljava/lang/String;", "")]
		public unsafe string Message()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("message.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("networkResponse", "()Lokhttp3/Response;", "")]
		public unsafe Response NetworkResponse()
		{
			return Java.Lang.Object.GetObject<Response>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("networkResponse.()Lokhttp3/Response;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("newBuilder", "()Lokhttp3/Response$Builder;", "")]
		public unsafe Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("newBuilder.()Lokhttp3/Response$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("peekBody", "(J)Lokhttp3/ResponseBody;", "")]
		public unsafe ResponseBody PeekBody(long byteCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(byteCount);
			return Java.Lang.Object.GetObject<ResponseBody>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("peekBody.(J)Lokhttp3/ResponseBody;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("priorResponse", "()Lokhttp3/Response;", "")]
		public unsafe Response PriorResponse()
		{
			return Java.Lang.Object.GetObject<Response>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("priorResponse.()Lokhttp3/Response;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("protocol", "()Lokhttp3/Protocol;", "")]
		public unsafe Protocol Protocol()
		{
			return Java.Lang.Object.GetObject<Protocol>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("protocol.()Lokhttp3/Protocol;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("receivedResponseAtMillis", "()J", "")]
		public unsafe long ReceivedResponseAtMillis()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt64Method("receivedResponseAtMillis.()J", this, null);
		}

		[Register("request", "()Lokhttp3/Request;", "")]
		public unsafe Request Request()
		{
			return Java.Lang.Object.GetObject<Request>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("request.()Lokhttp3/Request;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("sentRequestAtMillis", "()J", "")]
		public unsafe long SentRequestAtMillis()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt64Method("sentRequestAtMillis.()J", this, null);
		}

		[Register("trailers", "()Lokhttp3/Headers;", "")]
		public unsafe Headers Trailers()
		{
			return Java.Lang.Object.GetObject<Headers>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("trailers.()Lokhttp3/Headers;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/ResponseBody", DoNotGenerateAcw = true)]
	internal class ResponseBodyInvoker : ResponseBody
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/ResponseBody", typeof(ResponseBodyInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ResponseBodyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("contentLength", "()J", "GetContentLengthHandler")]
		public unsafe override long ContentLength()
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("contentLength.()J", this, null);
		}

		[Register("contentType", "()Lokhttp3/MediaType;", "GetContentTypeHandler")]
		public unsafe override MediaType ContentType()
		{
			return Java.Lang.Object.GetObject<MediaType>(_members.InstanceMethods.InvokeAbstractObjectMethod("contentType.()Lokhttp3/MediaType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("source", "()Lokio/BufferedSource;", "GetSourceHandler")]
		public unsafe override IBufferedSource Source()
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(_members.InstanceMethods.InvokeAbstractObjectMethod("source.()Lokio/BufferedSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/Route", DoNotGenerateAcw = true)]
	public sealed class Route : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/Route", typeof(Route));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Route(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokhttp3/Address;Ljava/net/Proxy;Ljava/net/InetSocketAddress;)V", "")]
		public unsafe Route(Address address, Proxy proxy, InetSocketAddress inetSocketAddress)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(address?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(proxy?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(inetSocketAddress?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokhttp3/Address;Ljava/net/Proxy;Ljava/net/InetSocketAddress;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokhttp3/Address;Ljava/net/Proxy;Ljava/net/InetSocketAddress;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(address);
				GC.KeepAlive(proxy);
				GC.KeepAlive(inetSocketAddress);
			}
		}

		[Register("address", "()Lokhttp3/Address;", "")]
		public unsafe Address Address()
		{
			return Java.Lang.Object.GetObject<Address>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("address.()Lokhttp3/Address;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("proxy", "()Ljava/net/Proxy;", "")]
		public unsafe Proxy Proxy()
		{
			return Java.Lang.Object.GetObject<Proxy>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("proxy.()Ljava/net/Proxy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("requiresTunnel", "()Z", "")]
		public unsafe bool RequiresTunnel()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("requiresTunnel.()Z", this, null);
		}

		[Register("socketAddress", "()Ljava/net/InetSocketAddress;", "")]
		public unsafe InetSocketAddress SocketAddress()
		{
			return Java.Lang.Object.GetObject<InetSocketAddress>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("socketAddress.()Ljava/net/InetSocketAddress;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okhttp3/TlsVersion", DoNotGenerateAcw = true)]
	public sealed class TlsVersion : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/TlsVersion", typeof(TlsVersion));

		[Register("SSL_3_0")]
		public static TlsVersion Ssl30 => Java.Lang.Object.GetObject<TlsVersion>(_members.StaticFields.GetObjectValue("SSL_3_0.Lokhttp3/TlsVersion;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_1_0")]
		public static TlsVersion Tls10 => Java.Lang.Object.GetObject<TlsVersion>(_members.StaticFields.GetObjectValue("TLS_1_0.Lokhttp3/TlsVersion;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_1_1")]
		public static TlsVersion Tls11 => Java.Lang.Object.GetObject<TlsVersion>(_members.StaticFields.GetObjectValue("TLS_1_1.Lokhttp3/TlsVersion;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_1_2")]
		public static TlsVersion Tls12 => Java.Lang.Object.GetObject<TlsVersion>(_members.StaticFields.GetObjectValue("TLS_1_2.Lokhttp3/TlsVersion;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TLS_1_3")]
		public static TlsVersion Tls13 => Java.Lang.Object.GetObject<TlsVersion>(_members.StaticFields.GetObjectValue("TLS_1_3.Lokhttp3/TlsVersion;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal TlsVersion(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("forJavaName", "(Ljava/lang/String;)Lokhttp3/TlsVersion;", "")]
		public unsafe static TlsVersion ForJavaName(string javaName)
		{
			IntPtr intPtr = JNIEnv.NewString(javaName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<TlsVersion>(_members.StaticMethods.InvokeObjectMethod("forJavaName.(Ljava/lang/String;)Lokhttp3/TlsVersion;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("javaName", "()Ljava/lang/String;", "")]
		public unsafe string JavaName()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("javaName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("valueOf", "(Ljava/lang/String;)Lokhttp3/TlsVersion;", "")]
		public unsafe static TlsVersion ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<TlsVersion>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lokhttp3/TlsVersion;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lokhttp3/TlsVersion;", "")]
		public unsafe static TlsVersion[] Values()
		{
			return (TlsVersion[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lokhttp3/TlsVersion;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(TlsVersion));
		}
	}
	[Register("okhttp3/WebSocketListener", DoNotGenerateAcw = true)]
	public abstract class WebSocketListener : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/WebSocketListener", typeof(WebSocketListener));

		private static Delegate cb_onClosed_Lokhttp3_WebSocket_ILjava_lang_String_;

		private static Delegate cb_onClosing_Lokhttp3_WebSocket_ILjava_lang_String_;

		private static Delegate cb_onFailure_Lokhttp3_WebSocket_Ljava_lang_Throwable_Lokhttp3_Response_;

		private static Delegate cb_onMessage_Lokhttp3_WebSocket_Ljava_lang_String_;

		private static Delegate cb_onMessage_Lokhttp3_WebSocket_Lokio_ByteString_;

		private static Delegate cb_onOpen_Lokhttp3_WebSocket_Lokhttp3_Response_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected WebSocketListener(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe WebSocketListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnClosed_Lokhttp3_WebSocket_ILjava_lang_String_Handler()
		{
			if ((object)cb_onClosed_Lokhttp3_WebSocket_ILjava_lang_String_ == null)
			{
				cb_onClosed_Lokhttp3_WebSocket_ILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_OnClosed_Lokhttp3_WebSocket_ILjava_lang_String_));
			}
			return cb_onClosed_Lokhttp3_WebSocket_ILjava_lang_String_;
		}

		private static void n_OnClosed_Lokhttp3_WebSocket_ILjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_webSocket, int code, IntPtr native_reason)
		{
			WebSocketListener webSocketListener = Java.Lang.Object.GetObject<WebSocketListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWebSocket webSocket = Java.Lang.Object.GetObject<IWebSocket>(native_webSocket, JniHandleOwnership.DoNotTransfer);
			string reason = JNIEnv.GetString(native_reason, JniHandleOwnership.DoNotTransfer);
			webSocketListener.OnClosed(webSocket, code, reason);
		}

		[Register("onClosed", "(Lokhttp3/WebSocket;ILjava/lang/String;)V", "GetOnClosed_Lokhttp3_WebSocket_ILjava_lang_String_Handler")]
		public unsafe virtual void OnClosed(IWebSocket webSocket, int code, string reason)
		{
			IntPtr intPtr = JNIEnv.NewString(reason);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((webSocket == null) ? IntPtr.Zero : ((Java.Lang.Object)webSocket).Handle);
				ptr[1] = new JniArgumentValue(code);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onClosed.(Lokhttp3/WebSocket;ILjava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(webSocket);
			}
		}

		private static Delegate GetOnClosing_Lokhttp3_WebSocket_ILjava_lang_String_Handler()
		{
			if ((object)cb_onClosing_Lokhttp3_WebSocket_ILjava_lang_String_ == null)
			{
				cb_onClosing_Lokhttp3_WebSocket_ILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_OnClosing_Lokhttp3_WebSocket_ILjava_lang_String_));
			}
			return cb_onClosing_Lokhttp3_WebSocket_ILjava_lang_String_;
		}

		private static void n_OnClosing_Lokhttp3_WebSocket_ILjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_webSocket, int code, IntPtr native_reason)
		{
			WebSocketListener webSocketListener = Java.Lang.Object.GetObject<WebSocketListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWebSocket webSocket = Java.Lang.Object.GetObject<IWebSocket>(native_webSocket, JniHandleOwnership.DoNotTransfer);
			string reason = JNIEnv.GetString(native_reason, JniHandleOwnership.DoNotTransfer);
			webSocketListener.OnClosing(webSocket, code, reason);
		}

		[Register("onClosing", "(Lokhttp3/WebSocket;ILjava/lang/String;)V", "GetOnClosing_Lokhttp3_WebSocket_ILjava_lang_String_Handler")]
		public unsafe virtual void OnClosing(IWebSocket webSocket, int code, string reason)
		{
			IntPtr intPtr = JNIEnv.NewString(reason);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((webSocket == null) ? IntPtr.Zero : ((Java.Lang.Object)webSocket).Handle);
				ptr[1] = new JniArgumentValue(code);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onClosing.(Lokhttp3/WebSocket;ILjava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(webSocket);
			}
		}

		private static Delegate GetOnFailure_Lokhttp3_WebSocket_Ljava_lang_Throwable_Lokhttp3_Response_Handler()
		{
			if ((object)cb_onFailure_Lokhttp3_WebSocket_Ljava_lang_Throwable_Lokhttp3_Response_ == null)
			{
				cb_onFailure_Lokhttp3_WebSocket_Ljava_lang_Throwable_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnFailure_Lokhttp3_WebSocket_Ljava_lang_Throwable_Lokhttp3_Response_));
			}
			return cb_onFailure_Lokhttp3_WebSocket_Ljava_lang_Throwable_Lokhttp3_Response_;
		}

		private static void n_OnFailure_Lokhttp3_WebSocket_Ljava_lang_Throwable_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_webSocket, IntPtr native_t, IntPtr native_response)
		{
			WebSocketListener webSocketListener = Java.Lang.Object.GetObject<WebSocketListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWebSocket webSocket = Java.Lang.Object.GetObject<IWebSocket>(native_webSocket, JniHandleOwnership.DoNotTransfer);
			Throwable t = Java.Lang.Object.GetObject<Throwable>(native_t, JniHandleOwnership.DoNotTransfer);
			Response response = Java.Lang.Object.GetObject<Response>(native_response, JniHandleOwnership.DoNotTransfer);
			webSocketListener.OnFailure(webSocket, t, response);
		}

		[Register("onFailure", "(Lokhttp3/WebSocket;Ljava/lang/Throwable;Lokhttp3/Response;)V", "GetOnFailure_Lokhttp3_WebSocket_Ljava_lang_Throwable_Lokhttp3_Response_Handler")]
		public unsafe virtual void OnFailure(IWebSocket webSocket, Throwable t, Response response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((webSocket == null) ? IntPtr.Zero : ((Java.Lang.Object)webSocket).Handle);
				ptr[1] = new JniArgumentValue(t?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFailure.(Lokhttp3/WebSocket;Ljava/lang/Throwable;Lokhttp3/Response;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(webSocket);
				GC.KeepAlive(t);
				GC.KeepAlive(response);
			}
		}

		private static Delegate GetOnMessage_Lokhttp3_WebSocket_Ljava_lang_String_Handler()
		{
			if ((object)cb_onMessage_Lokhttp3_WebSocket_Ljava_lang_String_ == null)
			{
				cb_onMessage_Lokhttp3_WebSocket_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnMessage_Lokhttp3_WebSocket_Ljava_lang_String_));
			}
			return cb_onMessage_Lokhttp3_WebSocket_Ljava_lang_String_;
		}

		private static void n_OnMessage_Lokhttp3_WebSocket_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_webSocket, IntPtr native_text)
		{
			WebSocketListener webSocketListener = Java.Lang.Object.GetObject<WebSocketListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWebSocket webSocket = Java.Lang.Object.GetObject<IWebSocket>(native_webSocket, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
			webSocketListener.OnMessage(webSocket, text);
		}

		[Register("onMessage", "(Lokhttp3/WebSocket;Ljava/lang/String;)V", "GetOnMessage_Lokhttp3_WebSocket_Ljava_lang_String_Handler")]
		public unsafe virtual void OnMessage(IWebSocket webSocket, string text)
		{
			IntPtr intPtr = JNIEnv.NewString(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((webSocket == null) ? IntPtr.Zero : ((Java.Lang.Object)webSocket).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onMessage.(Lokhttp3/WebSocket;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(webSocket);
			}
		}

		private static Delegate GetOnMessage_Lokhttp3_WebSocket_Lokio_ByteString_Handler()
		{
			if ((object)cb_onMessage_Lokhttp3_WebSocket_Lokio_ByteString_ == null)
			{
				cb_onMessage_Lokhttp3_WebSocket_Lokio_ByteString_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnMessage_Lokhttp3_WebSocket_Lokio_ByteString_));
			}
			return cb_onMessage_Lokhttp3_WebSocket_Lokio_ByteString_;
		}

		private static void n_OnMessage_Lokhttp3_WebSocket_Lokio_ByteString_(IntPtr jnienv, IntPtr native__this, IntPtr native_webSocket, IntPtr native_bytes)
		{
			WebSocketListener webSocketListener = Java.Lang.Object.GetObject<WebSocketListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWebSocket webSocket = Java.Lang.Object.GetObject<IWebSocket>(native_webSocket, JniHandleOwnership.DoNotTransfer);
			ByteString bytes = Java.Lang.Object.GetObject<ByteString>(native_bytes, JniHandleOwnership.DoNotTransfer);
			webSocketListener.OnMessage(webSocket, bytes);
		}

		[Register("onMessage", "(Lokhttp3/WebSocket;Lokio/ByteString;)V", "GetOnMessage_Lokhttp3_WebSocket_Lokio_ByteString_Handler")]
		public unsafe virtual void OnMessage(IWebSocket webSocket, ByteString bytes)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((webSocket == null) ? IntPtr.Zero : ((Java.Lang.Object)webSocket).Handle);
				ptr[1] = new JniArgumentValue(bytes?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onMessage.(Lokhttp3/WebSocket;Lokio/ByteString;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(webSocket);
				GC.KeepAlive(bytes);
			}
		}

		private static Delegate GetOnOpen_Lokhttp3_WebSocket_Lokhttp3_Response_Handler()
		{
			if ((object)cb_onOpen_Lokhttp3_WebSocket_Lokhttp3_Response_ == null)
			{
				cb_onOpen_Lokhttp3_WebSocket_Lokhttp3_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnOpen_Lokhttp3_WebSocket_Lokhttp3_Response_));
			}
			return cb_onOpen_Lokhttp3_WebSocket_Lokhttp3_Response_;
		}

		private static void n_OnOpen_Lokhttp3_WebSocket_Lokhttp3_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_webSocket, IntPtr native_response)
		{
			WebSocketListener webSocketListener = Java.Lang.Object.GetObject<WebSocketListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWebSocket webSocket = Java.Lang.Object.GetObject<IWebSocket>(native_webSocket, JniHandleOwnership.DoNotTransfer);
			Response response = Java.Lang.Object.GetObject<Response>(native_response, JniHandleOwnership.DoNotTransfer);
			webSocketListener.OnOpen(webSocket, response);
		}

		[Register("onOpen", "(Lokhttp3/WebSocket;Lokhttp3/Response;)V", "GetOnOpen_Lokhttp3_WebSocket_Lokhttp3_Response_Handler")]
		public unsafe virtual void OnOpen(IWebSocket webSocket, Response response)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((webSocket == null) ? IntPtr.Zero : ((Java.Lang.Object)webSocket).Handle);
				ptr[1] = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onOpen.(Lokhttp3/WebSocket;Lokhttp3/Response;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(webSocket);
				GC.KeepAlive(response);
			}
		}
	}
	[Register("okhttp3/WebSocketListener", DoNotGenerateAcw = true)]
	internal class WebSocketListenerInvoker : WebSocketListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okhttp3/WebSocketListener", typeof(WebSocketListenerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public WebSocketListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
}
