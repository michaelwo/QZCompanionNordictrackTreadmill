using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Security;
using Java.IO;
using Java.Lang;
using Java.Net;
using Java.Security;
using Java.Security.Cert;
using Java.Util.Concurrent;
using Javax.Net.Ssl;
using Javax.Security.Cert;
using Square.OkHttp3;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: ResourceDesigner("ModernHttpClient.Resource", IsApplication = false)]
[assembly: AssemblyTitle("ModernHttpClient.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ModernHttpClient.Android")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: TargetFramework("MonoAndroid,Version=v8.1", FrameworkDisplayName = "Xamarin.Android v8.1 Support")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace ModernHttpClient;

[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
public class Resource
{
	public class Attribute
	{
		static Attribute()
		{
			ResourceIdManager.UpdateIdValues();
		}

		private Attribute()
		{
		}
	}

	public class String
	{
		public static int app_name;

		public static int hello;

		static String()
		{
			app_name = 2130771968;
			hello = 2130771969;
			ResourceIdManager.UpdateIdValues();
		}

		private String()
		{
		}
	}

	static Resource()
	{
		ResourceIdManager.UpdateIdValues();
	}
}
internal class ConcatenatingStream : Stream
{
	private readonly CancellationTokenSource cts = new CancellationTokenSource();

	private readonly Action onDispose;

	private long position;

	private bool closeStreams;

	private int isEnding;

	private Task blockUntil;

	private IEnumerator<Stream> iterator;

	private Stream current;

	private Stream Current
	{
		get
		{
			if (current != null)
			{
				return current;
			}
			if (iterator == null)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			if (iterator.MoveNext())
			{
				current = iterator.Current;
			}
			return current;
		}
	}

	public override bool CanRead => true;

	public override bool CanWrite => false;

	public override bool CanSeek => false;

	public override bool CanTimeout => false;

	public override long Length
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public override long Position
	{
		get
		{
			return position;
		}
		set
		{
			if (value != position)
			{
				throw new NotSupportedException();
			}
		}
	}

	public ConcatenatingStream(IEnumerable<Func<Stream>> source, bool closeStreams, Task blockUntil = null, Action onDispose = null)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		iterator = source.Select((Func<Stream> x) => x()).GetEnumerator();
		this.closeStreams = closeStreams;
		this.blockUntil = blockUntil;
		this.onDispose = onDispose;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException();
	}

	public override void WriteByte(byte value)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void Flush()
	{
	}

	public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		int result = 0;
		if (blockUntil != null)
		{
			await blockUntil.ContinueWith(delegate
			{
			}, cancellationToken);
		}
		while (count > 0)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				throw new System.OperationCanceledException();
			}
			if (cts.IsCancellationRequested)
			{
				throw new System.OperationCanceledException();
			}
			Stream stream = Current;
			if (stream == null)
			{
				break;
			}
			int num = await stream.ReadAsync(buffer, offset, count, cancellationToken);
			result += num;
			count -= num;
			offset += num;
			if (num == 0)
			{
				EndOfStream();
			}
		}
		if (cancellationToken.IsCancellationRequested)
		{
			throw new System.OperationCanceledException();
		}
		if (cts.IsCancellationRequested)
		{
			throw new System.OperationCanceledException();
		}
		position += result;
		return result;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return readInternal(buffer, offset, count);
	}

	private int readInternal(byte[] buffer, int offset, int count, CancellationToken ct = default(CancellationToken))
	{
		int num = 0;
		if (blockUntil != null)
		{
			blockUntil.Wait(cts.Token);
		}
		while (count > 0)
		{
			if (ct.IsCancellationRequested)
			{
				throw new System.OperationCanceledException();
			}
			if (cts.IsCancellationRequested)
			{
				throw new System.OperationCanceledException();
			}
			Stream stream = Current;
			if (stream == null)
			{
				break;
			}
			int num2 = 0;
			num2 = stream.Read(buffer, offset, count);
			num += num2;
			count -= num2;
			offset += num2;
			if (num2 == 0)
			{
				EndOfStream();
			}
		}
		position += num;
		return num;
	}

	protected override void Dispose(bool disposing)
	{
		if (Interlocked.CompareExchange(ref isEnding, 1, 0) == 1)
		{
			return;
		}
		if (disposing)
		{
			cts.Cancel();
			while (Current != null)
			{
				EndOfStream();
			}
			iterator.Dispose();
			iterator = null;
			current = null;
			if (onDispose != null)
			{
				onDispose();
			}
		}
		base.Dispose(disposing);
	}

	private void EndOfStream()
	{
		if (closeStreams && current != null)
		{
			current.Close();
			current.Dispose();
		}
		current = null;
	}
}
public class NativeCookieHandler : CookieManager, ICookieJar, IJavaObject, IDisposable
{
	public List<System.Net.Cookie> Cookies => CookieStore.Cookies.Select(ToNetCookie).ToList();

	public NativeCookieHandler()
	{
		CookieHandler.Default = this;
	}

	public void SetCookies(IEnumerable<System.Net.Cookie> cookies)
	{
		foreach (HttpCookie item in cookies.Select(ToNativeCookie))
		{
			CookieStore.Add(new URI(item.Domain), item);
		}
	}

	public void DeleteCookies()
	{
		CookieStore.RemoveAll();
	}

	public void SetCookie(System.Net.Cookie cookie)
	{
		HttpCookie httpCookie = ToNativeCookie(cookie);
		CookieStore.Add(new URI(httpCookie.Domain), httpCookie);
	}

	public void DeleteCookie(System.Net.Cookie cookie)
	{
		HttpCookie httpCookie = ToNativeCookie(cookie);
		CookieStore.Remove(new URI(httpCookie.Domain), httpCookie);
	}

	private static HttpCookie ToNativeCookie(System.Net.Cookie cookie)
	{
		return new HttpCookie(cookie.Name, cookie.Value)
		{
			Domain = cookie.Domain,
			Path = cookie.Path,
			Secure = cookie.Secure
		};
	}

	private static System.Net.Cookie ToNetCookie(HttpCookie cookie)
	{
		return new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain)
		{
			Secure = cookie.Secure
		};
	}

	public IList<Square.OkHttp3.Cookie> LoadForRequest(HttpUrl p0)
	{
		List<Square.OkHttp3.Cookie> list = new List<Square.OkHttp3.Cookie>();
		foreach (HttpCookie item in CookieStore.Get(p0.Uri()))
		{
			if (Utility.PathMatches(p0.EncodedPath(), item.Path))
			{
				Square.OkHttp3.Cookie.Builder builder = new Square.OkHttp3.Cookie.Builder();
				builder.Name(item.Name).Value(item.Value).Domain(item.Domain)
					.Path(item.Path);
				if (item.Secure)
				{
					builder.Secure();
				}
				list.Add(builder.Build());
			}
		}
		return list;
	}

	public void SaveFromResponse(HttpUrl p0, IList<Square.OkHttp3.Cookie> p1)
	{
		foreach (Square.OkHttp3.Cookie item in p1)
		{
			HttpCookie httpCookie = new HttpCookie(item.Name(), item.Value());
			httpCookie.Domain = item.Domain();
			httpCookie.Path = item.Path();
			httpCookie.Secure = item.Secure();
			CookieStore.Add(p0.Uri(), httpCookie);
		}
	}
}
public class NativeMessageHandler : HttpClientHandler
{
	private OkHttpClient client = new OkHttpClient();

	private readonly CacheControl noCacheCacheControl = new CacheControl.Builder().NoCache().Build();

	private readonly bool throwOnCaptiveNetwork;

	private readonly Dictionary<HttpRequestMessage, WeakReference> registeredProgressCallbacks = new Dictionary<HttpRequestMessage, WeakReference>();

	private readonly Dictionary<string, string> headerSeparators = new Dictionary<string, string> { { "User-Agent", " " } };

	public readonly CertificatePinner CertificatePinner;

	private IKeyManager[] KeyManagers;

	public readonly TLSConfig TLSConfig;

	public readonly string PinningMode = "CertificateOnly";

	public bool DisableCaching { get; set; }

	public TimeSpan? Timeout { get; set; }

	public NativeMessageHandler()
		: this(throwOnCaptiveNetwork: false, new TLSConfig())
	{
	}

	public NativeMessageHandler(bool throwOnCaptiveNetwork, TLSConfig tLSConfig, NativeCookieHandler cookieHandler = null, IWebProxy proxy = null)
	{
		this.throwOnCaptiveNetwork = throwOnCaptiveNetwork;
		OkHttpClient.Builder builder = client.NewBuilder();
		TLSConfig = tLSConfig;
		ConnectionSpec item = new ConnectionSpec.Builder(ConnectionSpec.ModernTls).TlsVersions(TlsVersion.Tls12, TlsVersion.Tls13).Build();
		List<ConnectionSpec> list = new List<ConnectionSpec> { item };
		if (Build.VERSION.SdkInt < BuildVersionCodes.M || NetworkSecurityPolicy.Instance.IsCleartextTrafficPermitted)
		{
			list.Add(ConnectionSpec.Cleartext);
		}
		builder.ConnectionSpecs(list);
		builder.Protocols(new Protocol[2]
		{
			Protocol.Http11,
			Protocol.Http2
		});
		if (!TLSConfig.DangerousAcceptAnyServerCertificateValidator && TLSConfig.Pins != null && TLSConfig.Pins.Count > 0 && TLSConfig.Pins.FirstOrDefault((Pin p) => p.PublicKeys.Count() > 0) != null)
		{
			PinningMode = "PublicKeysOnly";
			CertificatePinner = new CertificatePinner();
			foreach (Pin pin in TLSConfig.Pins)
			{
				CertificatePinner.AddPins(pin.Hostname, pin.PublicKeys);
			}
			builder.CertificatePinner(CertificatePinner.Build());
		}
		SetClientCertificate(TLSConfig.ClientCertificate);
		if (cookieHandler != null)
		{
			builder.CookieJar(cookieHandler);
		}
		if (proxy != null && proxy is WebProxy)
		{
			WebProxy webProxy = proxy as WebProxy;
			Proxy.Type http = Java.Net.Proxy.Type.Http;
			InetSocketAddress sa = new InetSocketAddress(webProxy.Address.Host, webProxy.Address.Port);
			Proxy proxy2 = new Proxy(http, sa);
			builder.Proxy(proxy2);
			if (webProxy.Credentials != null)
			{
				NetworkCredential networkCredential = (NetworkCredential)webProxy.Credentials;
				builder.ProxyAuthenticator(new ProxyAuthenticator(networkCredential.UserName, networkCredential.Password));
			}
		}
		SSLContext instance = SSLContext.GetInstance("TLS");
		if (TLSConfig.DangerousAcceptAnyServerCertificateValidator)
		{
			CustomX509TrustManager customX509TrustManager = new CustomX509TrustManager();
			instance.Init(KeyManagers, new ITrustManager[1] { customX509TrustManager }, new SecureRandom());
			SSLSocketFactory socketFactory = instance.SocketFactory;
			builder.SslSocketFactory(socketFactory, customX509TrustManager);
		}
		else if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
		{
			builder.SslSocketFactory(new TlsSslSocketFactory(), TlsSslSocketFactory.GetSystemDefaultTrustManager());
		}
		else
		{
			instance.Init(KeyManagers, null, null);
			builder.SslSocketFactory(instance.SocketFactory, TlsSslSocketFactory.GetSystemDefaultTrustManager());
		}
		builder.HostnameVerifier(new HostnameVerifier(this));
		client = builder.Build();
	}

	private void SetClientCertificate(ClientCertificate certificate)
	{
		if (certificate != null)
		{
			byte[] buffer;
			try
			{
				buffer = Convert.FromBase64String(certificate.RawData);
			}
			catch (System.Exception inner)
			{
				throw new HttpRequestException("Certificate pinning failure: invalid client certificate raw data base64 string.", inner);
			}
			MemoryStream stream = new MemoryStream(buffer);
			KeyStore instance = KeyStore.GetInstance("PKCS12");
			instance.Load(stream, certificate.Passphrase.ToCharArray());
			KeyManagerFactory instance2 = KeyManagerFactory.GetInstance("X509");
			instance2.Init(instance, certificate.Passphrase.ToCharArray());
			KeyManagers = instance2.GetKeyManagers();
		}
	}

	public void RegisterForProgress(HttpRequestMessage request, ProgressDelegate callback)
	{
		if (callback == null && registeredProgressCallbacks.ContainsKey(request))
		{
			registeredProgressCallbacks.Remove(request);
		}
		else
		{
			registeredProgressCallbacks[request] = new WeakReference(callback);
		}
	}

	private ProgressDelegate getAndRemoveCallbackFromRegister(HttpRequestMessage request)
	{
		ProgressDelegate result = delegate
		{
		};
		lock (registeredProgressCallbacks)
		{
			if (!registeredProgressCallbacks.ContainsKey(request))
			{
				return result;
			}
			WeakReference weakReference = registeredProgressCallbacks[request];
			if (weakReference == null)
			{
				return result;
			}
			if (!(weakReference.Target is ProgressDelegate result2))
			{
				return result;
			}
			registeredProgressCallbacks.Remove(request);
			return result2;
		}
	}

	private string getHeaderSeparator(string name)
	{
		if (headerSeparators.ContainsKey(name))
		{
			return headerSeparators[name];
		}
		return ",";
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		string java_uri = request.RequestUri.GetComponents(UriComponents.AbsoluteUri, UriFormat.UriEscaped);
		URL url = new URL(java_uri);
		RequestBody body = null;
		if (request.Content != null)
		{
			byte[] content = await request.Content.ReadAsByteArrayAsync().ConfigureAwait(continueOnCapturedContext: false);
			string text = "text/plain";
			if (request.Content.Headers.ContentType != null)
			{
				text = string.Join(" ", request.Content.Headers.GetValues("Content-Type"));
			}
			body = RequestBody.Create(MediaType.Parse(text), content);
		}
		Request.Builder builder = new Request.Builder().Method(request.Method.Method.ToUpperInvariant(), body).Url(url);
		if (DisableCaching)
		{
			builder.CacheControl(noCacheCacheControl);
		}
		HttpRequestHeaders headers = request.Headers;
		IEnumerable<KeyValuePair<string, IEnumerable<string>>> second;
		if (request.Content == null)
		{
			second = Enumerable.Empty<KeyValuePair<string, IEnumerable<string>>>();
		}
		else
		{
			IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers2 = request.Content.Headers;
			second = headers2;
		}
		IEnumerable<KeyValuePair<string, IEnumerable<string>>> enumerable = headers.Union(second);
		System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
		if (client.CookieJar() != null)
		{
			foreach (Square.OkHttp3.Cookie item in client.CookieJar().LoadForRequest(HttpUrl.Get(url)))
			{
				stringBuilder.Append(item.Name() + "=" + item.Value() + ";");
			}
		}
		foreach (KeyValuePair<string, IEnumerable<string>> item2 in enumerable)
		{
			if (item2.Key == "Cookie")
			{
				foreach (string item3 in item2.Value)
				{
					stringBuilder.Append(item3 + ";");
				}
			}
			else
			{
				builder.AddHeader(item2.Key, string.Join(getHeaderSeparator(item2.Key), item2.Value));
			}
		}
		if (stringBuilder.Length > 0)
		{
			builder.AddHeader("Cookie", stringBuilder.ToString().TrimEnd(';'));
		}
		if (Timeout.HasValue)
		{
			OkHttpClient.Builder builder2 = client.NewBuilder();
			long timeout = (long)Timeout.Value.TotalSeconds;
			builder2.ConnectTimeout(timeout, TimeUnit.Seconds);
			builder2.WriteTimeout(timeout, TimeUnit.Seconds);
			builder2.ReadTimeout(timeout, TimeUnit.Seconds);
			client = builder2.Build();
		}
		cancellationToken.ThrowIfCancellationRequested();
		Request request2 = builder.Build();
		ICall call = client.NewCall(request2);
		cancellationToken.Register(delegate
		{
			Task.Run(delegate
			{
				call.Cancel();
			});
		});
		Response response;
		try
		{
			response = await call.EnqueueAsync().ConfigureAwait(continueOnCapturedContext: false);
			URI uRI = response.Request()?.Url().Uri();
			request.RequestUri = new Uri(uRI.ToString());
			if (throwOnCaptiveNetwork && uRI != null && url.Host != uRI.Host)
			{
				throw new CaptiveNetworkException(new Uri(java_uri), new Uri(uRI.ToString()));
			}
		}
		catch (Java.IO.IOException ex)
		{
			if (ex.Message.ToLowerInvariant().Contains("canceled"))
			{
				throw new System.OperationCanceledException();
			}
			throw new HttpRequestException(ex.Message, ex);
		}
		ResponseBody responseBody = response.Body();
		cancellationToken.ThrowIfCancellationRequested();
		HttpResponseMessage httpResponseMessage = new HttpResponseMessage((HttpStatusCode)response.Code());
		httpResponseMessage.RequestMessage = request;
		httpResponseMessage.ReasonPhrase = response.Message();
		if (string.IsNullOrEmpty(httpResponseMessage.ReasonPhrase))
		{
			try
			{
				httpResponseMessage.ReasonPhrase = ((ReasonPhrases)response.Code()/*cast due to .constrained prefix*/).ToString().Replace('_', ' ');
			}
			catch (System.Exception)
			{
				httpResponseMessage.ReasonPhrase = "Unassigned";
			}
		}
		if (responseBody != null)
		{
			ProgressStreamContent progressStreamContent = new ProgressStreamContent(responseBody.ByteStream(), CancellationToken.None);
			progressStreamContent.Progress = getAndRemoveCallbackFromRegister(request);
			httpResponseMessage.Content = progressStreamContent;
		}
		else
		{
			httpResponseMessage.Content = new ByteArrayContent(new byte[0]);
		}
		Headers headers3 = response.Headers();
		foreach (string item4 in headers3.Names())
		{
			httpResponseMessage.Headers.TryAddWithoutValidation(item4, headers3.Get(item4));
			httpResponseMessage.Content.Headers.TryAddWithoutValidation(item4, headers3.Get(item4));
		}
		return httpResponseMessage;
	}
}
public static class AwaitableOkHttp
{
	private class OkTaskCallback : Java.Lang.Object, ICallback, IJavaObject, IDisposable
	{
		private readonly TaskCompletionSource<Response> tcs = new TaskCompletionSource<Response>();

		public Task<Response> Task => tcs.Task;

		public void OnFailure(ICall p0, Java.IO.IOException p1)
		{
			if (p1.Message.StartsWith("Hostname " + p0.Request().Url().Host() + " not verified", StringComparison.Ordinal))
			{
				System.OperationCanceledException exception = new System.OperationCanceledException(HostnameVerifier.PinningFailureMessage, p1);
				HostnameVerifier.PinningFailureMessage = null;
				tcs.TrySetException(exception);
			}
			else if (p1.Message.StartsWith("Certificate pinning failure", StringComparison.Ordinal))
			{
				tcs.TrySetException(new System.OperationCanceledException("Certificate pinning failure: pins mismatch.", p1));
			}
			else
			{
				tcs.TrySetException(p1);
			}
		}

		public void OnResponse(ICall p0, Response p1)
		{
			tcs.TrySetResult(p1);
		}
	}

	public static Task<Response> EnqueueAsync(this ICall This)
	{
		OkTaskCallback okTaskCallback = new OkTaskCallback();
		This.Enqueue(okTaskCallback);
		return okTaskCallback.Task;
	}
}
internal class HostnameVerifier : Java.Lang.Object, IHostnameVerifier, IJavaObject, IDisposable
{
	private static readonly Regex cnRegex = new Regex("CN\\s*=\\s*([^,]*)", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.CultureInvariant);

	public static string PinningFailureMessage = null;

	private NativeMessageHandler nativeHandler { get; set; }

	public HostnameVerifier(NativeMessageHandler handler)
	{
		nativeHandler = handler;
	}

	public bool Verify(string hostname, ISSLSession session)
	{
		SslPolicyErrors sslPolicyErrors = SslPolicyErrors.None;
		if (!nativeHandler.TLSConfig.DangerousAcceptAnyServerCertificateValidator)
		{
			Javax.Security.Cert.X509Certificate[] peerCertificateChain = session.GetPeerCertificateChain();
			List<X509Certificate2> list = peerCertificateChain.Select((Javax.Security.Cert.X509Certificate x) => new X509Certificate2(x.GetEncoded())).ToList();
			switch (nativeHandler.PinningMode)
			{
			case "CertificateOnly":
			{
				X509Chain x509Chain = new X509Chain();
				X509Certificate2 x509Certificate = null;
				if (peerCertificateChain == null || peerCertificateChain.Length == 0)
				{
					sslPolicyErrors = SslPolicyErrors.RemoteCertificateNotAvailable;
					PinningFailureMessage = "Certificate pinning failure: no cert at all.";
					break;
				}
				if (peerCertificateChain.Length == 1)
				{
					sslPolicyErrors = SslPolicyErrors.RemoteCertificateChainErrors;
					PinningFailureMessage = "Certificate pinning failure: no root?";
					break;
				}
				for (int num = 1; num < list.Count; num++)
				{
					x509Chain.ChainPolicy.ExtraStore.Add(list[num]);
				}
				x509Chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
				x509Chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
				x509Chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
				x509Chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
				x509Certificate = list[0];
				if (!x509Chain.Build(x509Certificate))
				{
					sslPolicyErrors = SslPolicyErrors.RemoteCertificateChainErrors;
					PinningFailureMessage = "Certificate pinning failure: chain error.";
					break;
				}
				string subject = x509Certificate.Subject;
				string value = cnRegex.Match(subject).Groups[1].Value;
				if ((string.IsNullOrWhiteSpace(value) || !Utility.MatchHostnameToPattern(hostname, value)) && x509Certificate.ParseSubjectAlternativeName().FirstOrDefault((string s) => Utility.MatchHostnameToPattern(hostname, s)) == null)
				{
					sslPolicyErrors = SslPolicyErrors.RemoteCertificateNameMismatch;
					PinningFailureMessage = "Certificate pinning failure: subject name mismatch.";
				}
				break;
			}
			case "PublicKeysOnly":
				if (nativeHandler.CertificatePinner != null && !nativeHandler.CertificatePinner.HasPins(hostname))
				{
					sslPolicyErrors = SslPolicyErrors.RemoteCertificateNameMismatch;
					PinningFailureMessage = "Certificate pinning failure: no pins provided for host " + hostname;
				}
				break;
			}
		}
		return sslPolicyErrors == SslPolicyErrors.None;
	}
}
internal class CustomX509TrustManager : Java.Lang.Object, IX509TrustManager, ITrustManager, IJavaObject, IDisposable
{
	public void CheckClientTrusted(Java.Security.Cert.X509Certificate[] chain, string authType)
	{
	}

	public void CheckServerTrusted(Java.Security.Cert.X509Certificate[] chain, string authType)
	{
	}

	Java.Security.Cert.X509Certificate[] IX509TrustManager.GetAcceptedIssuers()
	{
		return new Java.Security.Cert.X509Certificate[0];
	}
}
public class CaptiveNetworkException : WebException
{
	private const string DefaultCaptiveNetworkErrorMessage = "Hostnames don't match, you are probably on a captive network";

	public Uri SourceUri { get; private set; }

	public Uri DestinationUri { get; private set; }

	public CaptiveNetworkException(Uri sourceUri, Uri destinationUri)
		: base("Hostnames don't match, you are probably on a captive network")
	{
		SourceUri = sourceUri;
		DestinationUri = destinationUri;
	}
}
public delegate void ProgressDelegate(long bytes, long totalBytes, long totalBytesExpected);
public class ProgressStreamContent : StreamContent
{
	private class ProgressStream : Stream
	{
		private CancellationToken token;

		public Action<long> ReadCallback { get; set; }

		public Action<long> WriteCallback { get; set; }

		public Stream ParentStream { get; private set; }

		public override bool CanRead => ParentStream.CanRead;

		public override bool CanSeek => ParentStream.CanSeek;

		public override bool CanWrite => ParentStream.CanWrite;

		public override bool CanTimeout => ParentStream.CanTimeout;

		public override long Length => ParentStream.Length;

		public override long Position
		{
			get
			{
				return ParentStream.Position;
			}
			set
			{
				ParentStream.Position = value;
			}
		}

		public ProgressStream(Stream stream, CancellationToken token)
		{
			ParentStream = stream;
			this.token = token;
			ReadCallback = delegate
			{
			};
			WriteCallback = delegate
			{
			};
		}

		public override void Flush()
		{
			ParentStream.Flush();
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return ParentStream.FlushAsync(cancellationToken);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			token.ThrowIfCancellationRequested();
			int num = ParentStream.Read(buffer, offset, count);
			ReadCallback(num);
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			token.ThrowIfCancellationRequested();
			return ParentStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			token.ThrowIfCancellationRequested();
			ParentStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			token.ThrowIfCancellationRequested();
			ParentStream.Write(buffer, offset, count);
			WriteCallback(count);
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			token.ThrowIfCancellationRequested();
			CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, cancellationToken);
			int num = await ParentStream.ReadAsync(buffer, offset, count, cancellationTokenSource.Token);
			ReadCallback(num);
			return num;
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			token.ThrowIfCancellationRequested();
			CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, cancellationToken);
			Task result = ParentStream.WriteAsync(buffer, offset, count, cancellationTokenSource.Token);
			WriteCallback(count);
			return result;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				ParentStream.Dispose();
			}
		}
	}

	private long _totalBytes;

	private long _totalBytesExpected = -1L;

	private ProgressDelegate _progress;

	public ProgressDelegate Progress
	{
		get
		{
			return _progress;
		}
		set
		{
			if (value == null)
			{
				_progress = delegate
				{
				};
			}
			else
			{
				_progress = value;
			}
		}
	}

	public ProgressStreamContent(Stream stream, CancellationToken token)
		: this(new ProgressStream(stream, token))
	{
	}

	public ProgressStreamContent(Stream stream, int bufferSize)
		: this(new ProgressStream(stream, CancellationToken.None), bufferSize)
	{
	}

	private ProgressStreamContent(ProgressStream stream)
		: base(stream)
	{
		init(stream);
	}

	private ProgressStreamContent(ProgressStream stream, int bufferSize)
		: base(stream, bufferSize)
	{
		init(stream);
	}

	private void init(ProgressStream stream)
	{
		stream.ReadCallback = readBytes;
		Progress = delegate
		{
		};
	}

	private void reset()
	{
		_totalBytes = 0L;
	}

	private void readBytes(long bytes)
	{
		if (_totalBytesExpected == -1)
		{
			_totalBytesExpected = base.Headers.ContentLength ?? (-1);
		}
		if (_totalBytesExpected == -1 && TryComputeLength(out var length))
		{
			_totalBytesExpected = ((length == 0L) ? (-1) : length);
		}
		_totalBytesExpected = System.Math.Max(-1L, _totalBytesExpected);
		_totalBytes += bytes;
		Progress(bytes, _totalBytes, _totalBytesExpected);
	}

	protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
	{
		reset();
		return base.SerializeToStreamAsync(stream, context);
	}

	protected override bool TryComputeLength(out long length)
	{
		bool result = base.TryComputeLength(out length);
		_totalBytesExpected = length;
		return result;
	}
}
public enum ReasonPhrases
{
	Continue = 100,
	Switching_Protocols = 101,
	Processing = 102,
	Early_Hints = 103,
	OK = 200,
	Created = 201,
	Accepted = 202,
	Non_Authoritative_Information = 203,
	No_Content = 204,
	Reset_Content = 205,
	Partial_Content = 206,
	Multi_Status = 207,
	Already_Reported = 208,
	IM_Used = 226,
	Multiple_Choices = 300,
	Moved_Permanently = 301,
	Found = 302,
	See_Other = 303,
	Not_Modified = 304,
	Use_Proxy = 305,
	Unused = 306,
	Temporary_Redirect = 307,
	Permanent_Redirect = 308,
	Bad_Request = 400,
	Unauthorized = 401,
	Payment_Required = 402,
	Forbidden = 403,
	Not_Found = 404,
	Method_Not_Allowed = 405,
	Not_Acceptable = 406,
	Proxy_Authentication_Required = 407,
	Request_Timeout = 408,
	Conflict = 409,
	Gone = 410,
	Length_Required = 411,
	Precondition_Failed = 412,
	Payload_Too_Large = 413,
	URI_Too_Long = 414,
	Unsupported_Media_Type = 415,
	Range_Not_Satisfiable = 416,
	Expectation_Failed = 417,
	Misdirected_Request = 421,
	Unprocessable_Entity = 422,
	Locked = 423,
	Failed_Dependency = 424,
	Upgrade_Required = 426,
	Precondition_Required = 428,
	Too_Many_Requests = 429,
	Request_Header_Fields_Too_Large = 431,
	Unavailable_For_Legal_Reasons = 451,
	Internal_Server_Error = 500,
	Not_Implemented = 501,
	Bad_Gateway = 502,
	Service_Unavailable = 503,
	Gateway_Timeout = 504,
	HTTP_Version_Not_Supported = 505,
	Variant_Also_Negotiates = 506,
	Insufficient_Storage = 507,
	Loop_Detected = 508,
	Not_Extended = 510,
	Network_Authentication_Required = 511
}
public static class FailureMessages
{
	public const string NoCertAtAll = "Certificate pinning failure: no cert at all.";

	public const string NoRoot = "Certificate pinning failure: no root?";

	public const string ChainError = "Certificate pinning failure: chain error.";

	public const string SubjectNameMismatch = "Certificate pinning failure: subject name mismatch.";

	public const string PinMismatch = "Certificate pinning failure: pins mismatch.";

	public const string NoPinsProvided = "Certificate pinning failure: no pins provided for host";

	public const string InvalidPublicKey = "Certificate pinning failure: a public key starts with sha256/ or sha1/, followed by a valid base64 string.";

	public const string InvalidRawData = "Certificate pinning failure: invalid client certificate raw data base64 string.";
}
internal class TlsSslSocketFactory : SSLSocketFactory
{
	private readonly SSLSocketFactory _factory = (SSLSocketFactory)SSLSocketFactory.Default;

	public TlsSslSocketFactory(IKeyManager[] keyManagers = null, ITrustManager[] trustManagers = null)
	{
		if (keyManagers != null || trustManagers != null)
		{
			SSLContext instance = SSLContext.GetInstance("TLS");
			instance.Init(keyManagers, trustManagers, null);
			_factory = instance.SocketFactory;
		}
	}

	public override string[] GetDefaultCipherSuites()
	{
		return _factory.GetDefaultCipherSuites();
	}

	public override string[] GetSupportedCipherSuites()
	{
		return _factory.GetSupportedCipherSuites();
	}

	public override Socket CreateSocket(InetAddress address, int port, InetAddress localAddress, int localPort)
	{
		SSLSocket obj = (SSLSocket)_factory.CreateSocket(address, port, localAddress, localPort);
		obj.SetEnabledProtocols(obj.GetSupportedProtocols());
		obj.SetEnabledCipherSuites(obj.GetSupportedCipherSuites());
		return obj;
	}

	public override Socket CreateSocket(InetAddress host, int port)
	{
		SSLSocket obj = (SSLSocket)_factory.CreateSocket(host, port);
		obj.SetEnabledProtocols(obj.GetSupportedProtocols());
		obj.SetEnabledCipherSuites(obj.GetSupportedCipherSuites());
		return obj;
	}

	public override Socket CreateSocket(string host, int port, InetAddress localHost, int localPort)
	{
		SSLSocket obj = (SSLSocket)_factory.CreateSocket(host, port, localHost, localPort);
		obj.SetEnabledProtocols(obj.GetSupportedProtocols());
		obj.SetEnabledCipherSuites(obj.GetSupportedCipherSuites());
		return obj;
	}

	public override Socket CreateSocket(string host, int port)
	{
		SSLSocket obj = (SSLSocket)_factory.CreateSocket(host, port);
		obj.SetEnabledProtocols(obj.GetSupportedProtocols());
		obj.SetEnabledCipherSuites(obj.GetSupportedCipherSuites());
		return obj;
	}

	public override Socket CreateSocket(Socket s, string host, int port, bool autoClose)
	{
		SSLSocket obj = (SSLSocket)_factory.CreateSocket(s, host, port, autoClose);
		obj.SetEnabledProtocols(obj.GetSupportedProtocols());
		obj.SetEnabledCipherSuites(obj.GetSupportedCipherSuites());
		return obj;
	}

	protected override void Dispose(bool disposing)
	{
		_factory.Dispose();
		base.Dispose(disposing);
	}

	public override Socket CreateSocket()
	{
		SSLSocket obj = (SSLSocket)_factory.CreateSocket();
		obj.SetEnabledProtocols(obj.GetSupportedProtocols());
		obj.SetEnabledCipherSuites(obj.GetSupportedCipherSuites());
		return obj;
	}

	public static IX509TrustManager GetSystemDefaultTrustManager()
	{
		IX509TrustManager result = null;
		try
		{
			TrustManagerFactory instance = TrustManagerFactory.GetInstance(TrustManagerFactory.DefaultAlgorithm);
			instance.Init(null);
			ITrustManager[] trustManagers = instance.GetTrustManagers();
			for (int i = 0; i < trustManagers.Length; i++)
			{
				IX509TrustManager iX509TrustManager = trustManagers[i].JavaCast<IX509TrustManager>();
				if (iX509TrustManager != null)
				{
					result = iX509TrustManager;
					break;
				}
			}
		}
		catch (Java.Lang.Exception ex) when (ex is NoSuchAlgorithmException || ex is KeyStoreException)
		{
		}
		return result;
	}
}
public class CertificatePinner : Java.Lang.Object
{
	private readonly Square.OkHttp3.CertificatePinner.Builder Builder;

	private readonly Dictionary<string, string[]> Pins;

	public CertificatePinner()
	{
		Builder = new Square.OkHttp3.CertificatePinner.Builder();
		Pins = new Dictionary<string, string[]>();
	}

	public Square.OkHttp3.CertificatePinner Build()
	{
		return Builder.Build();
	}

	public bool HasPins(string hostname)
	{
		foreach (KeyValuePair<string, string[]> pin in Pins)
		{
			if (Utility.MatchHostnameToPattern(hostname, pin.Key))
			{
				return true;
			}
		}
		return false;
	}

	public void AddPins(string hostname, string[] pins)
	{
		Utility.VerifyPins(pins);
		Pins[hostname] = pins;
		Builder.Add(hostname, pins);
	}
}
internal static class X509Certificate2Extension
{
	internal static List<string> ParseSubjectAlternativeName(this X509Certificate2 cert)
	{
		List<string> list = new List<string>();
		string text = (from X509Extension n in cert.Extensions
			where n.Oid.Value.Equals("2.5.29.17")
			select new AsnEncodedData(n.Oid, n.RawData) into n
			select n.Format(multiLine: true)).FirstOrDefault();
		if (text != null)
		{
			string[] array = text.Split(new string[3] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
			for (int num = 0; num < array.Length; num++)
			{
				GroupCollection groups = Regex.Match(array[num], "^DNS Name=(.*)").Groups;
				if (groups.Count > 0 && !string.IsNullOrEmpty(groups[1].Value))
				{
					list.Add(groups[1].Value);
				}
			}
		}
		return list;
	}
}
public class TLSConfig
{
	public List<Pin> Pins { get; set; }

	public ClientCertificate ClientCertificate { get; set; }

	public bool DangerousAcceptAnyServerCertificateValidator { get; set; }
}
public class Pin
{
	public string Hostname { get; set; }

	public string[] PublicKeys { get; set; }
}
public class ClientCertificate
{
	public string Passphrase { get; set; }

	public string RawData { get; set; }
}
internal static class Utility
{
	public static bool MatchHostnameToPattern(string hostname, string pattern)
	{
		int num = pattern.IndexOf('*');
		if (num == -1)
		{
			return string.Compare(hostname, pattern, StringComparison.OrdinalIgnoreCase) == 0;
		}
		if (num != pattern.Length - 1 && pattern[num + 1] != '.')
		{
			return false;
		}
		if (pattern.IndexOf('*', num + 1) != -1)
		{
			return false;
		}
		string text = pattern.Substring(num + 1);
		int num2 = hostname.Length - text.Length;
		if (num2 <= 0)
		{
			return false;
		}
		if (string.Compare(hostname, num2, text, 0, text.Length, StringComparison.OrdinalIgnoreCase) != 0)
		{
			return false;
		}
		if (num == 0)
		{
			int num3 = hostname.IndexOf('.');
			if (num3 != -1)
			{
				return num3 >= hostname.Length - text.Length;
			}
			return true;
		}
		string text2 = pattern.Substring(0, num);
		return string.Compare(hostname, 0, text2, 0, text2.Length, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static bool PathMatches(string path, string cookiePath)
	{
		if (path == cookiePath)
		{
			return true;
		}
		if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(cookiePath))
		{
			return false;
		}
		if (path.StartsWith(cookiePath, StringComparison.InvariantCultureIgnoreCase) && cookiePath.EndsWith("/", StringComparison.InvariantCultureIgnoreCase))
		{
			return true;
		}
		if (path.StartsWith(cookiePath, StringComparison.InvariantCultureIgnoreCase) && path.Substring(cookiePath.Length).StartsWith("/", StringComparison.InvariantCultureIgnoreCase))
		{
			return true;
		}
		return false;
	}

	public static void VerifyPins(string[] pins)
	{
		foreach (string text in pins)
		{
			if (!text.StartsWith("sha256/", StringComparison.Ordinal) && !text.StartsWith("sha1/", StringComparison.Ordinal))
			{
				throw new HttpRequestException("Certificate pinning failure: a public key starts with sha256/ or sha1/, followed by a valid base64 string.");
			}
			try
			{
				Convert.FromBase64String(text.Remove(0, text.IndexOf('/') + 1));
			}
			catch (System.Exception inner)
			{
				throw new HttpRequestException("Certificate pinning failure: a public key starts with sha256/ or sha1/, followed by a valid base64 string.", inner);
			}
		}
	}
}
public class ProxyAuthenticator : Java.Lang.Object, IAuthenticator, IJavaObject, IDisposable
{
	private string credentials;

	public ProxyAuthenticator(string username, string password)
	{
		credentials = Credentials.Basic(username, password);
	}

	public Request Authenticate(Route route, Response response)
	{
		return response.Request().NewBuilder().Header("Proxy-Authorization", credentials)
			.Build();
	}
}
