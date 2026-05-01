using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Authentication;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("System.Net.Http.dll")]
[assembly: AssemblyDescription("System.Net.Http.dll")]
[assembly: AssemblyDefaultAlias("System.Net.Http.dll")]
[assembly: AssemblyCompany("Mono development team")]
[assembly: AssemblyProduct("Mono Common Language Infrastructure")]
[assembly: AssemblyCopyright("(c) Various Mono authors")]
[assembly: SatelliteContractVersion("4.0.0.0")]
[assembly: AssemblyInformationalVersion("4.0.50524.0")]
[assembly: AssemblyFileVersion("4.0.50524.0")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyDelaySign(true)]
[assembly: ComVisible(false)]
[assembly: InternalsVisibleTo("System.Net.Http.WebRequest, PublicKey=002400000480000094000000060200000024000052534131000400000100010007d1fa57c4aed9f0a32e84aa0faefd0de9e8fd6aec8f87fb03766c834c99921eb23be79ad9d5dcc1dd9ad236132102900b723cf980957fc4e177108fc607774f29e8320e92ea05ece4e821c0a5efe8f1645c4c0c93c1ab99285d622caa652c1dfad63d745d6f2de5f17e5eaf0fc4963d261c8a12436518206dc093344d5ad293")]
[assembly: AssemblyVersion("4.0.0.0")]
[module: UnverifiableCode]
namespace System
{
	internal static class ByteArrayHelpers
	{
		internal static bool EqualsOrdinalAsciiIgnoreCase(string left, ReadOnlySpan<byte> right)
		{
			if (left.Length != right.Length)
			{
				return false;
			}
			for (int i = 0; i < left.Length; i++)
			{
				uint num = left[i];
				uint num2 = right[i];
				if (num - 97 <= 25)
				{
					num -= 32;
				}
				if (num2 - 97 <= 25)
				{
					num2 -= 32;
				}
				if (num != num2)
				{
					return false;
				}
			}
			return true;
		}
	}
}
namespace System.Net
{
	internal sealed class NetEventSource : EventSource
	{
		public static NetEventSource Log
		{
			get
			{
				throw new PlatformNotSupportedException();
			}
		}

		public new static bool IsEnabled => false;

		public static void Associate(params object[] args)
		{
		}

		[NonEvent]
		public static void Error(params object[] args)
		{
		}

		public static void Enter(params object[] args)
		{
		}

		public static void Exit(params object[] args)
		{
		}

		public static void Info(params object[] args)
		{
		}

		[NonEvent]
		public static void UriBaseAddress(object obj, Uri baseAddress)
		{
		}

		[NonEvent]
		public static void ContentNull(object obj)
		{
		}

		[NonEvent]
		public static void ClientSendCompleted(HttpClient httpClient, HttpResponseMessage response, HttpRequestMessage request)
		{
		}

		public void HeadersInvalidValue(string name, string rawValue)
		{
		}

		public void HandlerMessage(int handlerId, int workerId, int requestId, string memberName, string message)
		{
		}
	}
}
namespace System.Net.Http
{
	internal static class HttpHandlerDefaults
	{
		public static readonly TimeSpan DefaultResponseDrainTimeout = TimeSpan.FromSeconds(2.0);

		public static readonly TimeSpan DefaultPooledConnectionLifetime = Timeout.InfiniteTimeSpan;

		public static readonly TimeSpan DefaultPooledConnectionIdleTimeout = TimeSpan.FromMinutes(2.0);

		public static readonly TimeSpan DefaultExpect100ContinueTimeout = TimeSpan.FromSeconds(1.0);

		public static readonly TimeSpan DefaultConnectTimeout = Timeout.InfiniteTimeSpan;
	}
	public class ByteArrayContent : HttpContent
	{
		private readonly byte[] _content;

		private readonly int _offset;

		private readonly int _count;

		public ByteArrayContent(byte[] content)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			_content = content;
			_offset = 0;
			_count = content.Length;
			SetBuffer(_content, _offset, _count);
		}

		public ByteArrayContent(byte[] content, int offset, int count)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			if (offset < 0 || offset > content.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || count > content.Length - offset)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			_content = content;
			_offset = offset;
			_count = count;
			SetBuffer(_content, _offset, _count);
		}

		protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
		{
			return stream.WriteAsync(_content, _offset, _count);
		}

		protected internal override bool TryComputeLength(out long length)
		{
			length = _count;
			return true;
		}

		protected override Task<Stream> CreateContentReadStreamAsync()
		{
			return Task.FromResult((Stream)CreateMemoryStreamForByteArray());
		}

		internal override Stream TryCreateContentReadStream()
		{
			if (!(GetType() == typeof(ByteArrayContent)))
			{
				return null;
			}
			return CreateMemoryStreamForByteArray();
		}

		internal MemoryStream CreateMemoryStreamForByteArray()
		{
			return new MemoryStream(_content, _offset, _count, writable: false);
		}
	}
	public enum ClientCertificateOption
	{
		Manual,
		Automatic
	}
	public abstract class DelegatingHandler : HttpMessageHandler
	{
		private HttpMessageHandler _innerHandler;

		private volatile bool _operationStarted;

		private volatile bool _disposed;

		public HttpMessageHandler InnerHandler
		{
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				CheckDisposedOrStarted();
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Associate(this, value);
				}
				_innerHandler = value;
			}
		}

		protected DelegatingHandler()
		{
		}

		protected DelegatingHandler(HttpMessageHandler innerHandler)
		{
			InnerHandler = innerHandler;
		}

		protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request", "A request message must be provided. It cannot be null.");
			}
			SetOperationStarted();
			return _innerHandler.SendAsync(request, cancellationToken);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				_disposed = true;
				if (_innerHandler != null)
				{
					_innerHandler.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void CheckDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(GetType().ToString());
			}
		}

		private void CheckDisposedOrStarted()
		{
			CheckDisposed();
			if (_operationStarted)
			{
				throw new InvalidOperationException("This instance has already started one or more requests. Properties can only be modified before sending the first request.");
			}
		}

		private void SetOperationStarted()
		{
			CheckDisposed();
			if (_innerHandler == null)
			{
				throw new InvalidOperationException("The inner handler has not been assigned.");
			}
			if (!_operationStarted)
			{
				_operationStarted = true;
			}
		}
	}
	public class FormUrlEncodedContent : ByteArrayContent
	{
		public FormUrlEncodedContent(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
			: base(GetContentByteArray(nameValueCollection))
		{
			base.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
		}

		private static byte[] GetContentByteArray(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
		{
			if (nameValueCollection == null)
			{
				throw new ArgumentNullException("nameValueCollection");
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in nameValueCollection)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append('&');
				}
				stringBuilder.Append(Encode(item.Key));
				stringBuilder.Append('=');
				stringBuilder.Append(Encode(item.Value));
			}
			return HttpRuleParser.DefaultHttpEncoding.GetBytes(stringBuilder.ToString());
		}

		private static string Encode(string data)
		{
			if (string.IsNullOrEmpty(data))
			{
				return string.Empty;
			}
			return Uri.EscapeDataString(data).Replace("%20", "+");
		}

		internal override Stream TryCreateContentReadStream()
		{
			if (!(GetType() == typeof(FormUrlEncodedContent)))
			{
				return null;
			}
			return CreateMemoryStreamForByteArray();
		}
	}
	public class HttpClient : HttpMessageInvoker
	{
		private static readonly TimeSpan s_defaultTimeout = TimeSpan.FromSeconds(100.0);

		private static readonly TimeSpan s_maxTimeout = TimeSpan.FromMilliseconds(2147483647.0);

		private static readonly TimeSpan s_infiniteTimeout = System.Threading.Timeout.InfiniteTimeSpan;

		private volatile bool _operationStarted;

		private volatile bool _disposed;

		private CancellationTokenSource _pendingRequestsCts;

		private HttpRequestHeaders _defaultRequestHeaders;

		private Uri _baseAddress;

		private TimeSpan _timeout;

		private int _maxResponseContentBufferSize;

		public HttpRequestHeaders DefaultRequestHeaders
		{
			get
			{
				if (_defaultRequestHeaders == null)
				{
					_defaultRequestHeaders = new HttpRequestHeaders();
				}
				return _defaultRequestHeaders;
			}
		}

		public Uri BaseAddress
		{
			get
			{
				return _baseAddress;
			}
			set
			{
				CheckBaseAddress(value, "value");
				CheckDisposedOrStarted();
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.UriBaseAddress(this, value);
				}
				_baseAddress = value;
			}
		}

		public TimeSpan Timeout
		{
			get
			{
				return _timeout;
			}
			set
			{
				if (value != s_infiniteTimeout && (value <= TimeSpan.Zero || value > s_maxTimeout))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				CheckDisposedOrStarted();
				_timeout = value;
			}
		}

		public long MaxResponseContentBufferSize
		{
			get
			{
				return _maxResponseContentBufferSize;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				if (value > 2147483647)
				{
					throw new ArgumentOutOfRangeException("value", value, string.Format(CultureInfo.InvariantCulture, "Buffering more than {0} bytes is not supported.", 2147483647));
				}
				CheckDisposedOrStarted();
				_maxResponseContentBufferSize = (int)value;
			}
		}

		public HttpClient()
			: this(CreateDefaultHandler())
		{
		}

		public HttpClient(HttpMessageHandler handler)
			: this(handler, disposeHandler: true)
		{
		}

		public HttpClient(HttpMessageHandler handler, bool disposeHandler)
			: base(handler, disposeHandler)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Enter(this, handler);
			}
			_timeout = s_defaultTimeout;
			_maxResponseContentBufferSize = 2147483647;
			_pendingRequestsCts = new CancellationTokenSource();
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Exit(this);
			}
		}

		public Task<string> GetStringAsync(string requestUri)
		{
			return GetStringAsync(CreateUri(requestUri));
		}

		public Task<string> GetStringAsync(Uri requestUri)
		{
			return GetStringAsyncCore(GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead));
		}

		private async Task<string> GetStringAsyncCore(Task<HttpResponseMessage> getTask)
		{
			using HttpResponseMessage responseMessage = await getTask.ConfigureAwait(continueOnCapturedContext: false);
			responseMessage.EnsureSuccessStatusCode();
			HttpContent content = responseMessage.Content;
			if (content != null)
			{
				HttpContentHeaders headers = content.Headers;
				Stream stream = content.TryReadAsStream();
				if (stream == null)
				{
					stream = await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				using Stream responseStream = stream;
				using HttpContent.LimitArrayPoolWriteStream buffer = new HttpContent.LimitArrayPoolWriteStream(_maxResponseContentBufferSize, (int)headers.ContentLength.GetValueOrDefault());
				await responseStream.CopyToAsync(buffer).ConfigureAwait(continueOnCapturedContext: false);
				if (buffer.Length > 0)
				{
					return HttpContent.ReadBufferAsString(buffer.GetBuffer(), headers);
				}
			}
			return string.Empty;
		}

		public Task<byte[]> GetByteArrayAsync(string requestUri)
		{
			return GetByteArrayAsync(CreateUri(requestUri));
		}

		public Task<byte[]> GetByteArrayAsync(Uri requestUri)
		{
			return GetByteArrayAsyncCore(GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead));
		}

		private async Task<byte[]> GetByteArrayAsyncCore(Task<HttpResponseMessage> getTask)
		{
			using HttpResponseMessage responseMessage = await getTask.ConfigureAwait(continueOnCapturedContext: false);
			responseMessage.EnsureSuccessStatusCode();
			HttpContent content = responseMessage.Content;
			if (content != null)
			{
				HttpContentHeaders headers = content.Headers;
				Stream stream = content.TryReadAsStream();
				if (stream == null)
				{
					stream = await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				using Stream responseStream = stream;
				long? contentLength = headers.ContentLength;
				if (contentLength.HasValue)
				{
					Stream buffer = new HttpContent.LimitMemoryStream(_maxResponseContentBufferSize, (int)contentLength.GetValueOrDefault());
					await responseStream.CopyToAsync(buffer).ConfigureAwait(continueOnCapturedContext: false);
					if (buffer.Length > 0)
					{
						return ((HttpContent.LimitMemoryStream)buffer).GetSizedBuffer();
					}
				}
				else
				{
					Stream buffer = new HttpContent.LimitArrayPoolWriteStream(_maxResponseContentBufferSize);
					try
					{
						await responseStream.CopyToAsync(buffer).ConfigureAwait(continueOnCapturedContext: false);
						if (buffer.Length > 0)
						{
							return ((HttpContent.LimitArrayPoolWriteStream)buffer).ToArray();
						}
					}
					finally
					{
						buffer.Dispose();
					}
				}
			}
			return Array.Empty<byte>();
		}

		public Task<Stream> GetStreamAsync(string requestUri)
		{
			return GetStreamAsync(CreateUri(requestUri));
		}

		public Task<Stream> GetStreamAsync(Uri requestUri)
		{
			return FinishGetStreamAsync(GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead));
		}

		private async Task<Stream> FinishGetStreamAsync(Task<HttpResponseMessage> getTask)
		{
			HttpResponseMessage obj = await getTask.ConfigureAwait(continueOnCapturedContext: false);
			obj.EnsureSuccessStatusCode();
			HttpContent content = obj.Content;
			Stream result;
			if (content != null)
			{
				Stream stream = content.TryReadAsStream();
				if (stream == null)
				{
					stream = await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				result = stream;
			}
			else
			{
				result = Stream.Null;
			}
			return result;
		}

		public Task<HttpResponseMessage> GetAsync(string requestUri)
		{
			return GetAsync(CreateUri(requestUri));
		}

		public Task<HttpResponseMessage> GetAsync(Uri requestUri)
		{
			return GetAsync(requestUri, HttpCompletionOption.ResponseContentRead);
		}

		public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption)
		{
			return GetAsync(CreateUri(requestUri), completionOption);
		}

		public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption)
		{
			return GetAsync(requestUri, completionOption, CancellationToken.None);
		}

		public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
		{
			return GetAsync(CreateUri(requestUri), cancellationToken);
		}

		public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
		{
			return GetAsync(requestUri, HttpCompletionOption.ResponseContentRead, cancellationToken);
		}

		public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
		{
			return GetAsync(CreateUri(requestUri), completionOption, cancellationToken);
		}

		public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
		{
			return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), completionOption, cancellationToken);
		}

		public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
		{
			return PostAsync(CreateUri(requestUri), content);
		}

		public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
		{
			return PostAsync(requestUri, content, CancellationToken.None);
		}

		public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
			httpRequestMessage.Content = content;
			return SendAsync(httpRequestMessage, cancellationToken);
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
		{
			return SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
		}

		public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			CheckDisposed();
			CheckRequestMessage(request);
			SetOperationStarted();
			PrepareRequestMessage(request);
			bool flag = _timeout != s_infiniteTimeout;
			bool disposeCts;
			CancellationTokenSource cancellationTokenSource;
			if (flag || cancellationToken.CanBeCanceled)
			{
				disposeCts = true;
				cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _pendingRequestsCts.Token);
				if (flag)
				{
					cancellationTokenSource.CancelAfter(_timeout);
				}
			}
			else
			{
				disposeCts = false;
				cancellationTokenSource = _pendingRequestsCts;
			}
			Task<HttpResponseMessage> sendTask;
			try
			{
				sendTask = base.SendAsync(request, cancellationTokenSource.Token);
			}
			catch
			{
				HandleFinishSendAsyncCleanup(cancellationTokenSource, disposeCts);
				throw;
			}
			if (completionOption != HttpCompletionOption.ResponseContentRead || string.Equals(request.Method.Method, "HEAD", StringComparison.OrdinalIgnoreCase))
			{
				return FinishSendAsyncUnbuffered(sendTask, request, cancellationTokenSource, disposeCts);
			}
			return FinishSendAsyncBuffered(sendTask, request, cancellationTokenSource, disposeCts);
		}

		private async Task<HttpResponseMessage> FinishSendAsyncBuffered(Task<HttpResponseMessage> sendTask, HttpRequestMessage request, CancellationTokenSource cts, bool disposeCts)
		{
			HttpResponseMessage response = null;
			try
			{
				response = await sendTask.ConfigureAwait(continueOnCapturedContext: false);
				if (response == null)
				{
					throw new InvalidOperationException("Handler did not return a response message.");
				}
				if (response.Content != null)
				{
					await response.Content.LoadIntoBufferAsync(_maxResponseContentBufferSize, cts.Token).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.ClientSendCompleted(this, response, request);
				}
				return response;
			}
			catch (Exception e)
			{
				response?.Dispose();
				HandleFinishSendAsyncError(e, cts);
				throw;
			}
			finally
			{
				HandleFinishSendAsyncCleanup(cts, disposeCts);
			}
		}

		private async Task<HttpResponseMessage> FinishSendAsyncUnbuffered(Task<HttpResponseMessage> sendTask, HttpRequestMessage request, CancellationTokenSource cts, bool disposeCts)
		{
			try
			{
				HttpResponseMessage httpResponseMessage = await sendTask.ConfigureAwait(continueOnCapturedContext: false);
				if (httpResponseMessage == null)
				{
					throw new InvalidOperationException("Handler did not return a response message.");
				}
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.ClientSendCompleted(this, httpResponseMessage, request);
				}
				return httpResponseMessage;
			}
			catch (Exception e)
			{
				HandleFinishSendAsyncError(e, cts);
				throw;
			}
			finally
			{
				HandleFinishSendAsyncCleanup(cts, disposeCts);
			}
		}

		private void HandleFinishSendAsyncError(Exception e, CancellationTokenSource cts)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Error(this, e);
			}
			if (cts.IsCancellationRequested && e is HttpRequestException)
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(this, "Canceled");
				}
				throw new OperationCanceledException(cts.Token);
			}
		}

		private void HandleFinishSendAsyncCleanup(CancellationTokenSource cts, bool disposeCts)
		{
			if (disposeCts)
			{
				cts.Dispose();
			}
		}

		public void CancelPendingRequests()
		{
			CheckDisposed();
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Enter(this);
			}
			CancellationTokenSource cancellationTokenSource = Interlocked.Exchange(ref _pendingRequestsCts, new CancellationTokenSource());
			cancellationTokenSource.Cancel();
			cancellationTokenSource.Dispose();
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Exit(this);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				_disposed = true;
				_pendingRequestsCts.Cancel();
				_pendingRequestsCts.Dispose();
			}
			base.Dispose(disposing);
		}

		private void SetOperationStarted()
		{
			if (!_operationStarted)
			{
				_operationStarted = true;
			}
		}

		private void CheckDisposedOrStarted()
		{
			CheckDisposed();
			if (_operationStarted)
			{
				throw new InvalidOperationException("This instance has already started one or more requests. Properties can only be modified before sending the first request.");
			}
		}

		private void CheckDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(GetType().ToString());
			}
		}

		private static void CheckRequestMessage(HttpRequestMessage request)
		{
			if (!request.MarkAsSent())
			{
				throw new InvalidOperationException("The request message was already sent. Cannot send the same request message multiple times.");
			}
		}

		private void PrepareRequestMessage(HttpRequestMessage request)
		{
			Uri uri = null;
			if (request.RequestUri == null && _baseAddress == null)
			{
				throw new InvalidOperationException("An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.");
			}
			if (request.RequestUri == null)
			{
				uri = _baseAddress;
			}
			else if (!request.RequestUri.IsAbsoluteUri || (request.RequestUri.Scheme == Uri.UriSchemeFile && request.RequestUri.OriginalString.StartsWith("/", StringComparison.Ordinal)))
			{
				if (_baseAddress == null)
				{
					throw new InvalidOperationException("An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.");
				}
				uri = new Uri(_baseAddress, request.RequestUri);
			}
			if (uri != null)
			{
				request.RequestUri = uri;
			}
			if (_defaultRequestHeaders != null)
			{
				request.Headers.AddHeaders(_defaultRequestHeaders);
			}
		}

		private static void CheckBaseAddress(Uri baseAddress, string parameterName)
		{
			if (!(baseAddress == null))
			{
				if (!baseAddress.IsAbsoluteUri)
				{
					throw new ArgumentException("The base address must be an absolute URI.", parameterName);
				}
				if (!HttpUtilities.IsHttpUri(baseAddress))
				{
					throw new ArgumentException("Only 'http' and 'https' schemes are allowed.", parameterName);
				}
			}
		}

		private Uri CreateUri(string uri)
		{
			if (string.IsNullOrEmpty(uri))
			{
				return null;
			}
			return new Uri(uri, UriKind.RelativeOrAbsolute);
		}

		private static HttpMessageHandler CreateDefaultHandler()
		{
			string text = Environment.GetEnvironmentVariable("XA_HTTP_CLIENT_HANDLER_TYPE")?.Trim();
			if (string.IsNullOrEmpty(text))
			{
				return new HttpClientHandler();
			}
			if (text != null && text.StartsWith("System.Net.Http.MonoWebRequestHandler", StringComparison.InvariantCulture))
			{
				Type type = Type.GetType(text, throwOnError: false);
				if (type != null)
				{
					return new HttpClientHandler((IMonoHttpClientHandler)Activator.CreateInstance(type));
				}
				return new HttpClientHandler();
			}
			Type type2 = Type.GetType(text, throwOnError: false);
			if (type2 == null && !text.Contains(", "))
			{
				type2 = Type.GetType(text + ", Mono.Android", throwOnError: false);
			}
			if (type2 == null)
			{
				return new HttpClientHandler();
			}
			if (Activator.CreateInstance(type2) is HttpMessageHandler result)
			{
				return result;
			}
			return new HttpClientHandler();
		}
	}
	public class HttpClientHandler : HttpMessageHandler
	{
		[CompilerGenerated]
		private static readonly Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> <DangerousAcceptAnyServerCertificateValidator>k__BackingField = (HttpRequestMessage <p0>, X509Certificate2 <p1>, X509Chain <p2>, SslPolicyErrors <p3>) => true;

		private readonly IMonoHttpClientHandler _delegatingHandler;

		private ClientCertificateOption _clientCertificateOptions;

		public ClientCertificateOption ClientCertificateOptions
		{
			get
			{
				return _clientCertificateOptions;
			}
			set
			{
				switch (value)
				{
				case ClientCertificateOption.Manual:
					ThrowForModifiedManagedSslOptionsIfStarted();
					_clientCertificateOptions = value;
					_delegatingHandler.SslOptions.LocalCertificateSelectionCallback = (object sender, string targetHost, X509CertificateCollection localCertificates, X509Certificate remoteCertificate, string[] acceptableIssuers) => CertificateHelper.GetEligibleClientCertificate(ClientCertificates);
					break;
				case ClientCertificateOption.Automatic:
					ThrowForModifiedManagedSslOptionsIfStarted();
					_clientCertificateOptions = value;
					_delegatingHandler.SslOptions.LocalCertificateSelectionCallback = (object sender, string targetHost, X509CertificateCollection localCertificates, X509Certificate remoteCertificate, string[] acceptableIssuers) => CertificateHelper.GetEligibleClientCertificate();
					break;
				default:
					throw new ArgumentOutOfRangeException("value");
				}
			}
		}

		public X509CertificateCollection ClientCertificates
		{
			get
			{
				if (ClientCertificateOptions != ClientCertificateOption.Manual)
				{
					throw new InvalidOperationException(global::SR.Format("The {0} property must be set to '{1}' to use this property.", "ClientCertificateOptions", "Manual"));
				}
				return _delegatingHandler.SslOptions.ClientCertificates ?? (_delegatingHandler.SslOptions.ClientCertificates = new X509CertificateCollection());
			}
		}

		public DecompressionMethods AutomaticDecompression
		{
			set
			{
				_delegatingHandler.AutomaticDecompression = value;
			}
		}

		public bool UseProxy
		{
			set
			{
				_delegatingHandler.UseProxy = value;
			}
		}

		public IWebProxy Proxy
		{
			get
			{
				return _delegatingHandler.Proxy;
			}
			set
			{
				_delegatingHandler.Proxy = value;
			}
		}

		public bool AllowAutoRedirect
		{
			set
			{
				_delegatingHandler.AllowAutoRedirect = value;
			}
		}

		private static IMonoHttpClientHandler CreateDefaultHandler()
		{
			string text = Environment.GetEnvironmentVariable("XA_HTTP_CLIENT_HANDLER_TYPE")?.Trim();
			if (text != null && text.StartsWith("System.Net.Http.MonoWebRequestHandler", StringComparison.InvariantCulture))
			{
				Type type = Type.GetType(text, throwOnError: false);
				if (type != null)
				{
					return (IMonoHttpClientHandler)Activator.CreateInstance(type);
				}
			}
			return new SocketsHttpHandler();
		}

		public HttpClientHandler()
			: this(CreateDefaultHandler())
		{
		}

		internal HttpClientHandler(IMonoHttpClientHandler handler)
		{
			_delegatingHandler = handler;
			ClientCertificateOptions = ClientCertificateOption.Manual;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_delegatingHandler.Dispose();
			}
			base.Dispose(disposing);
		}

		private void ThrowForModifiedManagedSslOptionsIfStarted()
		{
			_delegatingHandler.SslOptions = _delegatingHandler.SslOptions;
		}

		protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return _delegatingHandler.SendAsync(request, cancellationToken);
		}
	}
	public enum HttpCompletionOption
	{
		ResponseContentRead,
		ResponseHeadersRead
	}
	public abstract class HttpContent : IDisposable
	{
		internal sealed class LimitMemoryStream : MemoryStream
		{
			private readonly int _maxSize;

			public LimitMemoryStream(int maxSize, int capacity)
				: base(capacity)
			{
				_maxSize = maxSize;
			}

			public byte[] GetSizedBuffer()
			{
				if (!TryGetBuffer(out var buffer) || buffer.Offset != 0 || buffer.Count != buffer.Array.Length)
				{
					return ToArray();
				}
				return buffer.Array;
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				CheckSize(count);
				base.Write(buffer, offset, count);
			}

			public override void WriteByte(byte value)
			{
				CheckSize(1);
				base.WriteByte(value);
			}

			public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				CheckSize(count);
				return base.WriteAsync(buffer, offset, count, cancellationToken);
			}

			public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken)
			{
				CheckSize(buffer.Length);
				return base.WriteAsync(buffer, cancellationToken);
			}

			public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
			{
				CheckSize(count);
				return base.BeginWrite(buffer, offset, count, callback, state);
			}

			public override void EndWrite(IAsyncResult asyncResult)
			{
				base.EndWrite(asyncResult);
			}

			public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
			{
				if (TryGetBuffer(out var buffer))
				{
					StreamHelpers.ValidateCopyToArgs(this, destination, bufferSize);
					long position = Position;
					long num = (Position = Length);
					long num2 = num - position;
					return destination.WriteAsync(buffer.Array, (int)(buffer.Offset + position), (int)num2, cancellationToken);
				}
				return base.CopyToAsync(destination, bufferSize, cancellationToken);
			}

			private void CheckSize(int countToAdd)
			{
				if (_maxSize - Length < countToAdd)
				{
					throw CreateOverCapacityException(_maxSize);
				}
			}
		}

		internal sealed class LimitArrayPoolWriteStream : Stream
		{
			private readonly int _maxBufferSize;

			private byte[] _buffer;

			private int _length;

			public override long Length => _length;

			public override bool CanWrite => true;

			public override bool CanRead => false;

			public override bool CanSeek => false;

			public override long Position
			{
				get
				{
					throw new NotSupportedException();
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			public LimitArrayPoolWriteStream(int maxBufferSize)
				: this(maxBufferSize, 256L)
			{
			}

			public LimitArrayPoolWriteStream(int maxBufferSize, long capacity)
			{
				if (capacity < 256)
				{
					capacity = 256L;
				}
				else if (capacity > maxBufferSize)
				{
					throw CreateOverCapacityException(maxBufferSize);
				}
				_maxBufferSize = maxBufferSize;
				_buffer = ArrayPool<byte>.Shared.Rent((int)capacity);
			}

			protected override void Dispose(bool disposing)
			{
				ArrayPool<byte>.Shared.Return(_buffer);
				_buffer = null;
				base.Dispose(disposing);
			}

			public ArraySegment<byte> GetBuffer()
			{
				return new ArraySegment<byte>(_buffer, 0, _length);
			}

			public byte[] ToArray()
			{
				byte[] array = new byte[_length];
				Buffer.BlockCopy(_buffer, 0, array, 0, _length);
				return array;
			}

			private void EnsureCapacity(int value)
			{
				if ((uint)value > (uint)_maxBufferSize)
				{
					throw CreateOverCapacityException(_maxBufferSize);
				}
				if (value > _buffer.Length)
				{
					Grow(value);
				}
			}

			private void Grow(int value)
			{
				byte[] buffer = _buffer;
				_buffer = null;
				uint num = (uint)(2 * buffer.Length);
				int minimumLength = ((num <= 2147483591) ? Math.Max(value, (int)num) : ((value > 2147483591) ? value : 2147483591));
				byte[] array = ArrayPool<byte>.Shared.Rent(minimumLength);
				Buffer.BlockCopy(buffer, 0, array, 0, _length);
				ArrayPool<byte>.Shared.Return(buffer);
				_buffer = array;
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				EnsureCapacity(_length + count);
				Buffer.BlockCopy(buffer, offset, _buffer, _length, count);
				_length += count;
			}

			public override void Write(ReadOnlySpan<byte> buffer)
			{
				EnsureCapacity(_length + buffer.Length);
				buffer.CopyTo(new Span<byte>(_buffer, _length, buffer.Length));
				_length += buffer.Length;
			}

			public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				Write(buffer, offset, count);
				return Task.CompletedTask;
			}

			public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
			{
				Write(buffer.Span);
				return default(ValueTask);
			}

			public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback asyncCallback, object asyncState)
			{
				return TaskToApm.Begin(WriteAsync(buffer, offset, count, CancellationToken.None), asyncCallback, asyncState);
			}

			public override void EndWrite(IAsyncResult asyncResult)
			{
				TaskToApm.End(asyncResult);
			}

			public override void WriteByte(byte value)
			{
				int num = _length + 1;
				EnsureCapacity(num);
				_buffer[_length] = value;
				_length = num;
			}

			public override void Flush()
			{
			}

			public override Task FlushAsync(CancellationToken cancellationToken)
			{
				return Task.CompletedTask;
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException();
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				throw new NotSupportedException();
			}

			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}
		}

		private HttpContentHeaders _headers;

		private MemoryStream _bufferedContent;

		private object _contentReadStream;

		private bool _disposed;

		private bool _canCalculateLength;

		internal static readonly Encoding DefaultStringEncoding = Encoding.UTF8;

		public HttpContentHeaders Headers
		{
			get
			{
				if (_headers == null)
				{
					_headers = new HttpContentHeaders(this);
				}
				return _headers;
			}
		}

		private bool IsBuffered => _bufferedContent != null;

		internal void SetBuffer(byte[] buffer, int offset, int count)
		{
			_bufferedContent = new MemoryStream(buffer, offset, count, writable: false, publiclyVisible: true);
		}

		internal bool TryGetBuffer(out ArraySegment<byte> buffer)
		{
			if (_bufferedContent != null)
			{
				return _bufferedContent.TryGetBuffer(out buffer);
			}
			buffer = default(ArraySegment<byte>);
			return false;
		}

		protected HttpContent()
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Enter(this);
			}
			_canCalculateLength = true;
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Exit(this);
			}
		}

		public Task<string> ReadAsStringAsync()
		{
			CheckDisposed();
			return WaitAndReturnAsync(LoadIntoBufferAsync(), this, (HttpContent s) => s.ReadBufferedContentAsString());
		}

		private string ReadBufferedContentAsString()
		{
			if (_bufferedContent.Length == 0L)
			{
				return string.Empty;
			}
			if (!TryGetBuffer(out var buffer))
			{
				buffer = new ArraySegment<byte>(_bufferedContent.ToArray());
			}
			return ReadBufferAsString(buffer, Headers);
		}

		internal static string ReadBufferAsString(ArraySegment<byte> buffer, HttpContentHeaders headers)
		{
			Encoding encoding = null;
			int preambleLength = -1;
			if (headers.ContentType != null && headers.ContentType.CharSet != null)
			{
				try
				{
					encoding = Encoding.GetEncoding(headers.ContentType.CharSet);
					preambleLength = GetPreambleLength(buffer, encoding);
				}
				catch (ArgumentException innerException)
				{
					throw new InvalidOperationException("The character set provided in ContentType is invalid. Cannot read content as string using an invalid character set.", innerException);
				}
			}
			if (encoding == null && !TryDetectEncoding(buffer, out encoding, out preambleLength))
			{
				encoding = DefaultStringEncoding;
				preambleLength = 0;
			}
			return encoding.GetString(buffer.Array, buffer.Offset + preambleLength, buffer.Count - preambleLength);
		}

		public Task<byte[]> ReadAsByteArrayAsync()
		{
			CheckDisposed();
			return WaitAndReturnAsync(LoadIntoBufferAsync(), this, (HttpContent s) => s.ReadBufferedContentAsByteArray());
		}

		internal byte[] ReadBufferedContentAsByteArray()
		{
			return _bufferedContent.ToArray();
		}

		public Task<Stream> ReadAsStreamAsync()
		{
			CheckDisposed();
			ArraySegment<byte> buffer;
			if (_contentReadStream == null)
			{
				return (Task<Stream>)(_contentReadStream = (TryGetBuffer(out buffer) ? Task.FromResult((Stream)new MemoryStream(buffer.Array, buffer.Offset, buffer.Count, writable: false)) : CreateContentReadStreamAsync()));
			}
			if (_contentReadStream is Task<Stream> result)
			{
				return result;
			}
			return (Task<Stream>)(_contentReadStream = Task.FromResult((Stream)_contentReadStream));
		}

		internal Stream TryReadAsStream()
		{
			CheckDisposed();
			ArraySegment<byte> buffer;
			if (_contentReadStream == null)
			{
				return (Stream)(_contentReadStream = (TryGetBuffer(out buffer) ? new MemoryStream(buffer.Array, buffer.Offset, buffer.Count, writable: false) : TryCreateContentReadStream()));
			}
			if (_contentReadStream is Stream result)
			{
				return result;
			}
			Task<Stream> task = (Task<Stream>)_contentReadStream;
			if (task.Status != TaskStatus.RanToCompletion)
			{
				return null;
			}
			return task.Result;
		}

		protected abstract Task SerializeToStreamAsync(Stream stream, TransportContext context);

		internal virtual Task SerializeToStreamAsync(Stream stream, TransportContext context, CancellationToken cancellationToken)
		{
			return SerializeToStreamAsync(stream, context);
		}

		public Task CopyToAsync(Stream stream, TransportContext context)
		{
			return CopyToAsync(stream, context, CancellationToken.None);
		}

		internal Task CopyToAsync(Stream stream, TransportContext context, CancellationToken cancellationToken)
		{
			CheckDisposed();
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			try
			{
				if (TryGetBuffer(out var buffer))
				{
					return CopyToAsyncCore(stream.WriteAsync(new ReadOnlyMemory<byte>(buffer.Array, buffer.Offset, buffer.Count), cancellationToken));
				}
				Task task = SerializeToStreamAsync(stream, context, cancellationToken);
				CheckTaskNotNull(task);
				return CopyToAsyncCore(new ValueTask(task));
			}
			catch (Exception ex) when (StreamCopyExceptionNeedsWrapping(ex))
			{
				return Task.FromException(GetStreamCopyException(ex));
			}
		}

		private static async Task CopyToAsyncCore(ValueTask copyTask)
		{
			try
			{
				await copyTask.ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex) when (StreamCopyExceptionNeedsWrapping(ex))
			{
				throw GetStreamCopyException(ex);
			}
		}

		public Task CopyToAsync(Stream stream)
		{
			return CopyToAsync(stream, null);
		}

		public Task LoadIntoBufferAsync()
		{
			return LoadIntoBufferAsync(2147483647L);
		}

		public Task LoadIntoBufferAsync(long maxBufferSize)
		{
			return LoadIntoBufferAsync(maxBufferSize, CancellationToken.None);
		}

		internal Task LoadIntoBufferAsync(long maxBufferSize, CancellationToken cancellationToken)
		{
			CheckDisposed();
			if (maxBufferSize > 2147483647)
			{
				throw new ArgumentOutOfRangeException("maxBufferSize", maxBufferSize, string.Format(CultureInfo.InvariantCulture, "Buffering more than {0} bytes is not supported.", 2147483647));
			}
			if (IsBuffered)
			{
				return Task.CompletedTask;
			}
			Exception error = null;
			MemoryStream memoryStream = CreateMemoryStream(maxBufferSize, out error);
			if (memoryStream == null)
			{
				return Task.FromException(error);
			}
			try
			{
				Task task = SerializeToStreamAsync(memoryStream, null, cancellationToken);
				CheckTaskNotNull(task);
				return LoadIntoBufferAsyncCore(task, memoryStream);
			}
			catch (Exception ex) when (StreamCopyExceptionNeedsWrapping(ex))
			{
				return Task.FromException(GetStreamCopyException(ex));
			}
		}

		private async Task LoadIntoBufferAsyncCore(Task serializeToStreamTask, MemoryStream tempBuffer)
		{
			try
			{
				await serializeToStreamTask.ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				tempBuffer.Dispose();
				Exception streamCopyException = GetStreamCopyException(ex);
				if (streamCopyException != ex)
				{
					throw streamCopyException;
				}
				throw;
			}
			try
			{
				tempBuffer.Seek(0L, SeekOrigin.Begin);
				_bufferedContent = tempBuffer;
			}
			catch (Exception ex2)
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(this, ex2);
				}
				throw;
			}
		}

		protected virtual Task<Stream> CreateContentReadStreamAsync()
		{
			return WaitAndReturnAsync(LoadIntoBufferAsync(), this, (Func<HttpContent, Stream>)((HttpContent s) => s._bufferedContent));
		}

		internal virtual Stream TryCreateContentReadStream()
		{
			return null;
		}

		protected internal abstract bool TryComputeLength(out long length);

		internal long? GetComputedOrBufferLength()
		{
			CheckDisposed();
			if (IsBuffered)
			{
				return _bufferedContent.Length;
			}
			if (_canCalculateLength)
			{
				long length = 0L;
				if (TryComputeLength(out length))
				{
					return length;
				}
				_canCalculateLength = false;
			}
			return null;
		}

		private MemoryStream CreateMemoryStream(long maxBufferSize, out Exception error)
		{
			error = null;
			long? contentLength = Headers.ContentLength;
			if (contentLength.HasValue)
			{
				if (contentLength > maxBufferSize)
				{
					error = new HttpRequestException(string.Format(CultureInfo.InvariantCulture, "Cannot write more bytes to the buffer than the configured maximum buffer size: {0}.", maxBufferSize));
					return null;
				}
				return new LimitMemoryStream((int)maxBufferSize, (int)contentLength.Value);
			}
			return new LimitMemoryStream((int)maxBufferSize, 0);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				_disposed = true;
				if (_contentReadStream != null)
				{
					((_contentReadStream as Stream) ?? ((_contentReadStream is Task<Stream> { Status: TaskStatus.RanToCompletion } task) ? task.Result : null))?.Dispose();
					_contentReadStream = null;
				}
				if (IsBuffered)
				{
					_bufferedContent.Dispose();
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void CheckDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(GetType().ToString());
			}
		}

		private void CheckTaskNotNull(Task task)
		{
			if (task == null)
			{
				InvalidOperationException ex = new InvalidOperationException("The async operation did not return a System.Threading.Tasks.Task object.");
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(this, ex);
				}
				throw ex;
			}
		}

		private static bool StreamCopyExceptionNeedsWrapping(Exception e)
		{
			if (!(e is IOException))
			{
				return e is ObjectDisposedException;
			}
			return true;
		}

		private static Exception GetStreamCopyException(Exception originalException)
		{
			if (!StreamCopyExceptionNeedsWrapping(originalException))
			{
				return originalException;
			}
			return new HttpRequestException("Error while copying content to a stream.", originalException);
		}

		private static int GetPreambleLength(ArraySegment<byte> buffer, Encoding encoding)
		{
			byte[] array = buffer.Array;
			int offset = buffer.Offset;
			int count = buffer.Count;
			switch (encoding.CodePage)
			{
			case 65001:
				if (count < 3 || array[offset] != 239 || array[offset + 1] != 187 || array[offset + 2] != 191)
				{
					return 0;
				}
				return 3;
			case 12000:
				if (count < 4 || array[offset] != 255 || array[offset + 1] != 254 || array[offset + 2] != 0 || array[offset + 3] != 0)
				{
					return 0;
				}
				return 4;
			case 1200:
				if (count < 2 || array[offset] != 255 || array[offset + 1] != 254)
				{
					return 0;
				}
				return 2;
			case 1201:
				if (count < 2 || array[offset] != 254 || array[offset + 1] != 255)
				{
					return 0;
				}
				return 2;
			default:
			{
				byte[] preamble = encoding.GetPreamble();
				if (!BufferHasPrefix(buffer, preamble))
				{
					return 0;
				}
				return preamble.Length;
			}
			}
		}

		private static bool TryDetectEncoding(ArraySegment<byte> buffer, out Encoding encoding, out int preambleLength)
		{
			byte[] array = buffer.Array;
			int offset = buffer.Offset;
			int count = buffer.Count;
			if (count >= 2)
			{
				switch ((array[offset] << 8) | array[offset + 1])
				{
				case 61371:
					if (count >= 3 && array[offset + 2] == 191)
					{
						encoding = Encoding.UTF8;
						preambleLength = 3;
						return true;
					}
					break;
				case 65534:
					if (count >= 4 && array[offset + 2] == 0 && array[offset + 3] == 0)
					{
						encoding = Encoding.UTF32;
						preambleLength = 4;
					}
					else
					{
						encoding = Encoding.Unicode;
						preambleLength = 2;
					}
					return true;
				case 65279:
					encoding = Encoding.BigEndianUnicode;
					preambleLength = 2;
					return true;
				}
			}
			encoding = null;
			preambleLength = 0;
			return false;
		}

		private static bool BufferHasPrefix(ArraySegment<byte> buffer, byte[] prefix)
		{
			byte[] array = buffer.Array;
			if (prefix == null || array == null || prefix.Length > buffer.Count || prefix.Length == 0)
			{
				return false;
			}
			int num = 0;
			int num2 = buffer.Offset;
			while (num < prefix.Length)
			{
				if (prefix[num] != array[num2])
				{
					return false;
				}
				num++;
				num2++;
			}
			return true;
		}

		private static async Task<TResult> WaitAndReturnAsync<TState, TResult>(Task waitTask, TState state, Func<TState, TResult> returnFunc)
		{
			await waitTask.ConfigureAwait(continueOnCapturedContext: false);
			return returnFunc(state);
		}

		private static Exception CreateOverCapacityException(int maxBufferSize)
		{
			return new HttpRequestException(global::SR.Format("Cannot write more bytes to the buffer than the configured maximum buffer size: {0}.", maxBufferSize));
		}
	}
	public abstract class HttpMessageHandler : IDisposable
	{
		protected HttpMessageHandler()
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Info(this);
			}
		}

		protected internal abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);

		protected virtual void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
	public class HttpMessageInvoker : IDisposable
	{
		private volatile bool _disposed;

		private bool _disposeHandler;

		private HttpMessageHandler _handler;

		public HttpMessageInvoker(HttpMessageHandler handler, bool disposeHandler)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Enter(this, handler);
			}
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Associate(this, handler);
			}
			_handler = handler;
			_disposeHandler = disposeHandler;
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Exit(this);
			}
		}

		public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			CheckDisposed();
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Enter(this, request);
			}
			Task<HttpResponseMessage> task = _handler.SendAsync(request, cancellationToken);
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Exit(this, task);
			}
			return task;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				_disposed = true;
				if (_disposeHandler)
				{
					_handler.Dispose();
				}
			}
		}

		private void CheckDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(GetType().ToString());
			}
		}
	}
	public class HttpMethod : IEquatable<HttpMethod>
	{
		private readonly string _method;

		private int _hashcode;

		private static readonly HttpMethod s_getMethod = new HttpMethod("GET");

		private static readonly HttpMethod s_putMethod = new HttpMethod("PUT");

		private static readonly HttpMethod s_postMethod = new HttpMethod("POST");

		private static readonly HttpMethod s_deleteMethod = new HttpMethod("DELETE");

		private static readonly HttpMethod s_headMethod = new HttpMethod("HEAD");

		private static readonly HttpMethod s_optionsMethod = new HttpMethod("OPTIONS");

		private static readonly HttpMethod s_traceMethod = new HttpMethod("TRACE");

		private static readonly HttpMethod s_patchMethod = new HttpMethod("PATCH");

		private static readonly HttpMethod s_connectMethod = new HttpMethod("CONNECT");

		private static readonly Dictionary<HttpMethod, HttpMethod> s_knownMethods = new Dictionary<HttpMethod, HttpMethod>(9)
		{
			{ s_getMethod, s_getMethod },
			{ s_putMethod, s_putMethod },
			{ s_postMethod, s_postMethod },
			{ s_deleteMethod, s_deleteMethod },
			{ s_headMethod, s_headMethod },
			{ s_optionsMethod, s_optionsMethod },
			{ s_traceMethod, s_traceMethod },
			{ s_patchMethod, s_patchMethod },
			{ s_connectMethod, s_connectMethod }
		};

		public static HttpMethod Get => s_getMethod;

		public static HttpMethod Put => s_putMethod;

		public static HttpMethod Post => s_postMethod;

		public static HttpMethod Delete => s_deleteMethod;

		public static HttpMethod Head => s_headMethod;

		internal static HttpMethod Connect => s_connectMethod;

		public string Method => _method;

		public HttpMethod(string method)
		{
			if (string.IsNullOrEmpty(method))
			{
				throw new ArgumentException("The value cannot be null or empty.", "method");
			}
			if (HttpRuleParser.GetTokenLength(method, 0) != method.Length)
			{
				throw new FormatException("The format of the HTTP method is invalid.");
			}
			_method = method;
		}

		public bool Equals(HttpMethod other)
		{
			if ((object)other == null)
			{
				return false;
			}
			if ((object)_method == other._method)
			{
				return true;
			}
			return string.Equals(_method, other._method, StringComparison.OrdinalIgnoreCase);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as HttpMethod);
		}

		public override int GetHashCode()
		{
			if (_hashcode == 0)
			{
				_hashcode = StringComparer.OrdinalIgnoreCase.GetHashCode(_method);
			}
			return _hashcode;
		}

		public override string ToString()
		{
			return _method;
		}

		public static bool operator ==(HttpMethod left, HttpMethod right)
		{
			if (left != null && right != null)
			{
				return left.Equals(right);
			}
			return (object)left == right;
		}

		internal static HttpMethod Normalize(HttpMethod method)
		{
			if (!s_knownMethods.TryGetValue(method, out var value))
			{
				return method;
			}
			return value;
		}
	}
	internal enum HttpParseResult
	{
		Parsed,
		NotParsed,
		InvalidFormat
	}
	[Serializable]
	public class HttpRequestException : Exception
	{
		public HttpRequestException()
			: this(null, null)
		{
		}

		public HttpRequestException(string message)
			: this(message, null)
		{
		}

		public HttpRequestException(string message, Exception inner)
			: base(message, inner)
		{
			if (inner != null)
			{
				base.HResult = inner.HResult;
			}
		}
	}
	public class HttpRequestMessage : IDisposable
	{
		private int _sendStatus;

		private HttpMethod _method;

		private Uri _requestUri;

		private HttpRequestHeaders _headers;

		private Version _version;

		private HttpContent _content;

		private bool _disposed;

		private IDictionary<string, object> _properties;

		public Version Version
		{
			get
			{
				return _version;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				CheckDisposed();
				_version = value;
			}
		}

		public HttpContent Content
		{
			get
			{
				return _content;
			}
			set
			{
				CheckDisposed();
				if (NetEventSource.IsEnabled)
				{
					if (value == null)
					{
						NetEventSource.ContentNull(this);
					}
					else
					{
						NetEventSource.Associate(this, value);
					}
				}
				_content = value;
			}
		}

		public HttpMethod Method
		{
			get
			{
				return _method;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				CheckDisposed();
				_method = value;
			}
		}

		public Uri RequestUri
		{
			get
			{
				return _requestUri;
			}
			set
			{
				if (value != null && !IsAllowedAbsoluteUri(value))
				{
					throw new ArgumentException("Only 'http' and 'https' schemes are allowed.", "value");
				}
				CheckDisposed();
				_requestUri = value;
			}
		}

		public HttpRequestHeaders Headers
		{
			get
			{
				if (_headers == null)
				{
					_headers = new HttpRequestHeaders();
				}
				return _headers;
			}
		}

		internal bool HasHeaders => _headers != null;

		public IDictionary<string, object> Properties
		{
			get
			{
				if (_properties == null)
				{
					_properties = new Dictionary<string, object>();
				}
				return _properties;
			}
		}

		public HttpRequestMessage()
			: this(HttpMethod.Get, (Uri)null)
		{
		}

		public HttpRequestMessage(HttpMethod method, Uri requestUri)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Enter(this, method, requestUri);
			}
			InitializeValues(method, requestUri);
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Exit(this);
			}
		}

		public HttpRequestMessage(HttpMethod method, string requestUri)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Enter(this, method, requestUri);
			}
			if (string.IsNullOrEmpty(requestUri))
			{
				InitializeValues(method, null);
			}
			else
			{
				InitializeValues(method, new Uri(requestUri, UriKind.RelativeOrAbsolute));
			}
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Exit(this);
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Method: ");
			stringBuilder.Append(_method);
			stringBuilder.Append(", RequestUri: '");
			stringBuilder.Append((_requestUri == null) ? "<null>" : _requestUri.ToString());
			stringBuilder.Append("', Version: ");
			stringBuilder.Append(_version);
			stringBuilder.Append(", Content: ");
			stringBuilder.Append((_content == null) ? "<null>" : _content.GetType().ToString());
			stringBuilder.Append(", Headers:\r\n");
			stringBuilder.Append(HeaderUtilities.DumpHeaders(_headers, (_content == null) ? null : _content.Headers));
			return stringBuilder.ToString();
		}

		private void InitializeValues(HttpMethod method, Uri requestUri)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (requestUri != null && !IsAllowedAbsoluteUri(requestUri))
			{
				throw new ArgumentException("Only 'http' and 'https' schemes are allowed.", "requestUri");
			}
			_method = method;
			_requestUri = requestUri;
			_version = HttpUtilities.DefaultRequestVersion;
		}

		internal bool MarkAsSent()
		{
			return Interlocked.Exchange(ref _sendStatus, 1) == 0;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				_disposed = true;
				if (_content != null)
				{
					_content.Dispose();
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void CheckDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(GetType().ToString());
			}
		}

		private static bool IsAllowedAbsoluteUri(Uri uri)
		{
			if (!uri.IsAbsoluteUri)
			{
				return true;
			}
			if (uri.Scheme == Uri.UriSchemeFile && uri.OriginalString.StartsWith("/", StringComparison.Ordinal))
			{
				return true;
			}
			return HttpUtilities.IsHttpUri(uri);
		}
	}
	public class HttpResponseMessage : IDisposable
	{
		private HttpStatusCode _statusCode;

		private HttpResponseHeaders _headers;

		private string _reasonPhrase;

		private HttpRequestMessage _requestMessage;

		private Version _version;

		private HttpContent _content;

		private bool _disposed;

		public Version Version => _version;

		public HttpContent Content
		{
			get
			{
				return _content;
			}
			set
			{
				CheckDisposed();
				if (NetEventSource.IsEnabled)
				{
					if (value == null)
					{
						NetEventSource.ContentNull(this);
					}
					else
					{
						NetEventSource.Associate(this, value);
					}
				}
				_content = value;
			}
		}

		public HttpStatusCode StatusCode
		{
			get
			{
				return _statusCode;
			}
			set
			{
				if (value < (HttpStatusCode)0 || value > (HttpStatusCode)999)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				CheckDisposed();
				_statusCode = value;
			}
		}

		public string ReasonPhrase
		{
			get
			{
				if (_reasonPhrase != null)
				{
					return _reasonPhrase;
				}
				return HttpStatusDescription.Get(StatusCode);
			}
			set
			{
				if (value != null && ContainsNewLineCharacter(value))
				{
					throw new FormatException("The reason phrase must not contain new-line characters.");
				}
				CheckDisposed();
				_reasonPhrase = value;
			}
		}

		public HttpResponseHeaders Headers
		{
			get
			{
				if (_headers == null)
				{
					_headers = new HttpResponseHeaders();
				}
				return _headers;
			}
		}

		public HttpRequestMessage RequestMessage
		{
			get
			{
				return _requestMessage;
			}
			set
			{
				CheckDisposed();
				if (value != null)
				{
					NetEventSource.Associate(this, value);
				}
				_requestMessage = value;
			}
		}

		public bool IsSuccessStatusCode
		{
			get
			{
				if (_statusCode >= HttpStatusCode.OK)
				{
					return _statusCode <= (HttpStatusCode)299;
				}
				return false;
			}
		}

		internal void SetVersionWithoutValidation(Version value)
		{
			_version = value;
		}

		internal void SetStatusCodeWithoutValidation(HttpStatusCode value)
		{
			_statusCode = value;
		}

		internal void SetReasonPhraseWithoutValidation(string value)
		{
			_reasonPhrase = value;
		}

		public HttpResponseMessage()
			: this(HttpStatusCode.OK)
		{
		}

		public HttpResponseMessage(HttpStatusCode statusCode)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Enter(this, statusCode);
			}
			if (statusCode < (HttpStatusCode)0 || statusCode > (HttpStatusCode)999)
			{
				throw new ArgumentOutOfRangeException("statusCode");
			}
			_statusCode = statusCode;
			_version = HttpUtilities.DefaultResponseVersion;
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Exit(this);
			}
		}

		public HttpResponseMessage EnsureSuccessStatusCode()
		{
			if (!IsSuccessStatusCode)
			{
				if (_content != null)
				{
					_content.Dispose();
				}
				throw new HttpRequestException(string.Format(CultureInfo.InvariantCulture, "Response status code does not indicate success: {0} ({1}).", (int)_statusCode, ReasonPhrase));
			}
			return this;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("StatusCode: ");
			stringBuilder.Append((int)_statusCode);
			stringBuilder.Append(", ReasonPhrase: '");
			stringBuilder.Append(ReasonPhrase ?? "<null>");
			stringBuilder.Append("', Version: ");
			stringBuilder.Append(_version);
			stringBuilder.Append(", Content: ");
			stringBuilder.Append((_content == null) ? "<null>" : _content.GetType().ToString());
			stringBuilder.Append(", Headers:\r\n");
			stringBuilder.Append(HeaderUtilities.DumpHeaders(_headers, (_content == null) ? null : _content.Headers));
			return stringBuilder.ToString();
		}

		private bool ContainsNewLineCharacter(string value)
		{
			foreach (char c in value)
			{
				if (c == '\r' || c == '\n')
				{
					return true;
				}
			}
			return false;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				_disposed = true;
				if (_content != null)
				{
					_content.Dispose();
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void CheckDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(GetType().ToString());
			}
		}
	}
	internal static class HttpRuleParser
	{
		private static readonly bool[] s_tokenChars = CreateTokenChars();

		private static readonly string[] s_dateFormats = new string[15]
		{
			"ddd, d MMM yyyy H:m:s 'GMT'", "ddd, d MMM yyyy H:m:s", "d MMM yyyy H:m:s 'GMT'", "d MMM yyyy H:m:s", "ddd, d MMM yy H:m:s 'GMT'", "ddd, d MMM yy H:m:s", "d MMM yy H:m:s 'GMT'", "d MMM yy H:m:s", "dddd, d'-'MMM'-'yy H:m:s 'GMT'", "dddd, d'-'MMM'-'yy H:m:s",
			"ddd MMM d H:m:s yyyy", "ddd, d MMM yyyy H:m:s zzz", "ddd, d MMM yyyy H:m:s", "d MMM yyyy H:m:s zzz", "d MMM yyyy H:m:s"
		};

		internal static readonly Encoding DefaultHttpEncoding = Encoding.GetEncoding(28591);

		private static bool[] CreateTokenChars()
		{
			bool[] array = new bool[128];
			for (int i = 33; i < 127; i++)
			{
				array[i] = true;
			}
			array[40] = false;
			array[41] = false;
			array[60] = false;
			array[62] = false;
			array[64] = false;
			array[44] = false;
			array[59] = false;
			array[58] = false;
			array[92] = false;
			array[34] = false;
			array[47] = false;
			array[91] = false;
			array[93] = false;
			array[63] = false;
			array[61] = false;
			array[123] = false;
			array[125] = false;
			return array;
		}

		internal static bool IsTokenChar(char character)
		{
			if (character > '\u007f')
			{
				return false;
			}
			return s_tokenChars[(uint)character];
		}

		internal static int GetTokenLength(string input, int startIndex)
		{
			if (startIndex >= input.Length)
			{
				return 0;
			}
			for (int i = startIndex; i < input.Length; i++)
			{
				if (!IsTokenChar(input[i]))
				{
					return i - startIndex;
				}
			}
			return input.Length - startIndex;
		}

		internal static bool IsToken(string input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (!IsTokenChar(input[i]))
				{
					return false;
				}
			}
			return true;
		}

		internal static bool IsToken(ReadOnlySpan<byte> input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (!IsTokenChar((char)input[i]))
				{
					return false;
				}
			}
			return true;
		}

		internal static string GetTokenString(ReadOnlySpan<byte> input)
		{
			return Encoding.ASCII.GetString(input);
		}

		internal static int GetWhitespaceLength(string input, int startIndex)
		{
			if (startIndex >= input.Length)
			{
				return 0;
			}
			int num = startIndex;
			while (num < input.Length)
			{
				switch (input[num])
				{
				case '\t':
				case ' ':
					num++;
					continue;
				case '\r':
					if (num + 2 < input.Length && input[num + 1] == '\n')
					{
						char c = input[num + 2];
						if (c == ' ' || c == '\t')
						{
							num += 3;
							continue;
						}
					}
					break;
				}
				return num - startIndex;
			}
			return input.Length - startIndex;
		}

		internal static bool ContainsInvalidNewLine(string value)
		{
			return ContainsInvalidNewLine(value, 0);
		}

		internal static bool ContainsInvalidNewLine(string value, int startIndex)
		{
			for (int i = startIndex; i < value.Length; i++)
			{
				if (value[i] != '\r')
				{
					continue;
				}
				int num = i + 1;
				if (num < value.Length && value[num] == '\n')
				{
					i = num + 1;
					if (i == value.Length)
					{
						return true;
					}
					char c = value[i];
					if (c != ' ' && c != '\t')
					{
						return true;
					}
				}
			}
			return false;
		}

		internal static int GetNumberLength(string input, int startIndex, bool allowDecimal)
		{
			int num = startIndex;
			bool flag = !allowDecimal;
			if (input[num] == '.')
			{
				return 0;
			}
			while (num < input.Length)
			{
				char c = input[num];
				if (c >= '0' && c <= '9')
				{
					num++;
					continue;
				}
				if (flag || c != '.')
				{
					break;
				}
				flag = true;
				num++;
			}
			return num - startIndex;
		}

		internal static int GetHostLength(string input, int startIndex, bool allowToken, out string host)
		{
			host = null;
			if (startIndex >= input.Length)
			{
				return 0;
			}
			int i = startIndex;
			bool flag;
			bool num;
			for (flag = true; i < input.Length; flag = num, i++)
			{
				char c = input[i];
				switch (c)
				{
				case '/':
					return 0;
				default:
					num = flag && IsTokenChar(c);
					continue;
				case '\t':
				case '\r':
				case ' ':
				case ',':
					break;
				}
				break;
			}
			int num2 = i - startIndex;
			if (num2 == 0)
			{
				return 0;
			}
			string text = input.Substring(startIndex, num2);
			if ((!allowToken || !flag) && !IsValidHostName(text))
			{
				return 0;
			}
			host = text;
			return num2;
		}

		internal static HttpParseResult GetCommentLength(string input, int startIndex, out int length)
		{
			int nestedCount = 0;
			return GetExpressionLength(input, startIndex, '(', ')', supportsNesting: true, ref nestedCount, out length);
		}

		internal static HttpParseResult GetQuotedStringLength(string input, int startIndex, out int length)
		{
			int nestedCount = 0;
			return GetExpressionLength(input, startIndex, '"', '"', supportsNesting: false, ref nestedCount, out length);
		}

		internal static HttpParseResult GetQuotedPairLength(string input, int startIndex, out int length)
		{
			length = 0;
			if (input[startIndex] != '\\')
			{
				return HttpParseResult.NotParsed;
			}
			if (startIndex + 2 > input.Length || input[startIndex + 1] > '\u007f')
			{
				return HttpParseResult.InvalidFormat;
			}
			length = 2;
			return HttpParseResult.Parsed;
		}

		internal static string DateToString(DateTimeOffset dateTime)
		{
			return dateTime.ToUniversalTime().ToString("r", CultureInfo.InvariantCulture);
		}

		internal static bool TryStringToDate(string input, out DateTimeOffset result)
		{
			if (DateTimeOffset.TryParseExact(input, s_dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeUniversal, out result))
			{
				return true;
			}
			return false;
		}

		private static HttpParseResult GetExpressionLength(string input, int startIndex, char openChar, char closeChar, bool supportsNesting, ref int nestedCount, out int length)
		{
			length = 0;
			if (input[startIndex] != openChar)
			{
				return HttpParseResult.NotParsed;
			}
			int num = startIndex + 1;
			while (num < input.Length)
			{
				int length2 = 0;
				if (num + 2 < input.Length && GetQuotedPairLength(input, num, out length2) == HttpParseResult.Parsed)
				{
					num += length2;
					continue;
				}
				if (supportsNesting && input[num] == openChar)
				{
					nestedCount++;
					try
					{
						if (nestedCount > 5)
						{
							return HttpParseResult.InvalidFormat;
						}
						int length3 = 0;
						switch (GetExpressionLength(input, num, openChar, closeChar, supportsNesting, ref nestedCount, out length3))
						{
						case HttpParseResult.Parsed:
							num += length3;
							break;
						case HttpParseResult.InvalidFormat:
							return HttpParseResult.InvalidFormat;
						case HttpParseResult.NotParsed:
							break;
						}
					}
					finally
					{
						nestedCount--;
					}
				}
				if (input[num] == closeChar)
				{
					length = num - startIndex + 1;
					return HttpParseResult.Parsed;
				}
				num++;
			}
			return HttpParseResult.InvalidFormat;
		}

		private static bool IsValidHostName(string host)
		{
			Uri result;
			return Uri.TryCreate("http://u@" + host + "/", UriKind.Absolute, out result);
		}
	}
	internal static class HttpUtilities
	{
		internal static Version DefaultRequestVersion => HttpVersion.Version20;

		internal static Version DefaultResponseVersion => HttpVersion.Version11;

		internal static bool IsHttpUri(Uri uri)
		{
			return IsSupportedScheme(uri.Scheme);
		}

		internal static bool IsSupportedScheme(string scheme)
		{
			if (!IsSupportedNonSecureScheme(scheme))
			{
				return IsSupportedSecureScheme(scheme);
			}
			return true;
		}

		internal static bool IsSupportedNonSecureScheme(string scheme)
		{
			if (!string.Equals(scheme, "http", StringComparison.OrdinalIgnoreCase))
			{
				return IsNonSecureWebSocketScheme(scheme);
			}
			return true;
		}

		internal static bool IsSupportedSecureScheme(string scheme)
		{
			if (!string.Equals(scheme, "https", StringComparison.OrdinalIgnoreCase))
			{
				return IsSecureWebSocketScheme(scheme);
			}
			return true;
		}

		internal static bool IsNonSecureWebSocketScheme(string scheme)
		{
			return string.Equals(scheme, "ws", StringComparison.OrdinalIgnoreCase);
		}

		internal static bool IsSecureWebSocketScheme(string scheme)
		{
			return string.Equals(scheme, "wss", StringComparison.OrdinalIgnoreCase);
		}
	}
	public class MultipartContent : HttpContent, IEnumerable<HttpContent>, IEnumerable
	{
		private sealed class ContentReadStream : Stream
		{
			private readonly Stream[] _streams;

			private readonly long _length;

			private int _next;

			private Stream _current;

			private long _position;

			public override bool CanRead => true;

			public override bool CanSeek => true;

			public override bool CanWrite => false;

			public override long Position
			{
				get
				{
					return _position;
				}
				set
				{
					if (value < 0)
					{
						throw new ArgumentOutOfRangeException("value");
					}
					long num = 0L;
					for (int i = 0; i < _streams.Length; i++)
					{
						Stream stream = _streams[i];
						long length = stream.Length;
						if (value < num + length)
						{
							_current = stream;
							i = (_next = i + 1);
							stream.Position = value - num;
							for (; i < _streams.Length; i++)
							{
								_streams[i].Position = 0L;
							}
							_position = value;
							return;
						}
						num += length;
					}
					_current = null;
					_next = _streams.Length;
					_position = value;
				}
			}

			public override long Length => _length;

			internal ContentReadStream(Stream[] streams)
			{
				_streams = streams;
				foreach (Stream stream in streams)
				{
					_length += stream.Length;
				}
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					Stream[] streams = _streams;
					for (int i = 0; i < streams.Length; i++)
					{
						streams[i].Dispose();
					}
				}
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				ValidateReadArgs(buffer, offset, count);
				if (count == 0)
				{
					return 0;
				}
				while (true)
				{
					if (_current != null)
					{
						int num = _current.Read(buffer, offset, count);
						if (num != 0)
						{
							_position += num;
							return num;
						}
						_current = null;
					}
					if (_next >= _streams.Length)
					{
						break;
					}
					_current = _streams[_next++];
				}
				return 0;
			}

			public override int Read(Span<byte> buffer)
			{
				if (buffer.Length == 0)
				{
					return 0;
				}
				while (true)
				{
					if (_current != null)
					{
						int num = _current.Read(buffer);
						if (num != 0)
						{
							_position += num;
							return num;
						}
						_current = null;
					}
					if (_next >= _streams.Length)
					{
						break;
					}
					_current = _streams[_next++];
				}
				return 0;
			}

			public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				ValidateReadArgs(buffer, offset, count);
				return ReadAsyncPrivate(new Memory<byte>(buffer, offset, count), cancellationToken).AsTask();
			}

			public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
			{
				return ReadAsyncPrivate(buffer, cancellationToken);
			}

			public override IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
			{
				return TaskToApm.Begin(ReadAsync(array, offset, count, CancellationToken.None), asyncCallback, asyncState);
			}

			public override int EndRead(IAsyncResult asyncResult)
			{
				return TaskToApm.End<int>(asyncResult);
			}

			public async ValueTask<int> ReadAsyncPrivate(Memory<byte> buffer, CancellationToken cancellationToken)
			{
				if (buffer.Length == 0)
				{
					return 0;
				}
				while (true)
				{
					if (_current != null)
					{
						int num = await _current.ReadAsync(buffer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						if (num != 0)
						{
							_position += num;
							return num;
						}
						_current = null;
					}
					if (_next >= _streams.Length)
					{
						break;
					}
					_current = _streams[_next++];
				}
				return 0;
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				switch (origin)
				{
				case SeekOrigin.Begin:
					Position = offset;
					break;
				case SeekOrigin.Current:
					Position += offset;
					break;
				case SeekOrigin.End:
					Position = _length + offset;
					break;
				default:
					throw new ArgumentOutOfRangeException("origin");
				}
				return Position;
			}

			private static void ValidateReadArgs(byte[] buffer, int offset, int count)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (offset < 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count < 0)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				if (offset > buffer.Length - count)
				{
					throw new ArgumentException("The buffer was not long enough.", "buffer");
				}
			}

			public override void Flush()
			{
			}

			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException();
			}

			public override void Write(ReadOnlySpan<byte> buffer)
			{
				throw new NotSupportedException();
			}

			public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				throw new NotSupportedException();
			}

			public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
			{
				throw new NotSupportedException();
			}
		}

		private static readonly int s_crlfLength = GetEncodedLength("\r\n");

		private static readonly int s_dashDashLength = GetEncodedLength("--");

		private static readonly int s_colonSpaceLength = GetEncodedLength(": ");

		private static readonly int s_commaSpaceLength = GetEncodedLength(", ");

		private readonly List<HttpContent> _nestedContent;

		private readonly string _boundary;

		public MultipartContent(string subtype, string boundary)
		{
			if (string.IsNullOrWhiteSpace(subtype))
			{
				throw new ArgumentException("The value cannot be null or empty.", "subtype");
			}
			ValidateBoundary(boundary);
			_boundary = boundary;
			string text = boundary;
			if (!text.StartsWith("\"", StringComparison.Ordinal))
			{
				text = "\"" + text + "\"";
			}
			MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("multipart/" + subtype)
			{
				Parameters = 
				{
					new NameValueHeaderValue("boundary", text)
				}
			};
			base.Headers.ContentType = contentType;
			_nestedContent = new List<HttpContent>();
		}

		private static void ValidateBoundary(string boundary)
		{
			if (string.IsNullOrWhiteSpace(boundary))
			{
				throw new ArgumentException("The value cannot be null or empty.", "boundary");
			}
			if (boundary.Length > 70)
			{
				throw new ArgumentOutOfRangeException("boundary", boundary, string.Format(CultureInfo.InvariantCulture, "The field cannot be longer than {0} characters.", 70));
			}
			if (boundary.EndsWith(" ", StringComparison.Ordinal))
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The format of value '{0}' is invalid.", boundary), "boundary");
			}
			foreach (char c in boundary)
			{
				if (('0' > c || c > '9') && ('a' > c || c > 'z') && ('A' > c || c > 'Z') && "'()+_,-./:=? ".IndexOf(c) < 0)
				{
					throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The format of value '{0}' is invalid.", boundary), "boundary");
				}
			}
		}

		public virtual void Add(HttpContent content)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			_nestedContent.Add(content);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				foreach (HttpContent item in _nestedContent)
				{
					item.Dispose();
				}
				_nestedContent.Clear();
			}
			base.Dispose(disposing);
		}

		public IEnumerator<HttpContent> GetEnumerator()
		{
			return _nestedContent.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _nestedContent.GetEnumerator();
		}

		protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
		{
			_ = 3;
			try
			{
				await EncodeStringToStreamAsync(stream, "--" + _boundary + "\r\n").ConfigureAwait(continueOnCapturedContext: false);
				StringBuilder output = new StringBuilder();
				for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
				{
					HttpContent content = _nestedContent[contentIndex];
					await EncodeStringToStreamAsync(stream, SerializeHeadersToString(output, contentIndex, content)).ConfigureAwait(continueOnCapturedContext: false);
					await content.CopyToAsync(stream).ConfigureAwait(continueOnCapturedContext: false);
				}
				await EncodeStringToStreamAsync(stream, "\r\n--" + _boundary + "--\r\n").ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(this, ex);
				}
				throw;
			}
		}

		protected override async Task<Stream> CreateContentReadStreamAsync()
		{
			_ = 1;
			try
			{
				Stream[] streams = new Stream[2 + _nestedContent.Count * 2];
				StringBuilder scratch = new StringBuilder();
				int streamIndex = 0;
				streams[streamIndex++] = EncodeStringToNewStream("--" + _boundary + "\r\n");
				for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
				{
					HttpContent httpContent = _nestedContent[contentIndex];
					streams[streamIndex++] = EncodeStringToNewStream(SerializeHeadersToString(scratch, contentIndex, httpContent));
					Stream stream = (await httpContent.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false)) ?? new MemoryStream();
					if (!stream.CanSeek)
					{
						return await base.CreateContentReadStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
					}
					streams[streamIndex++] = stream;
				}
				streams[streamIndex] = EncodeStringToNewStream("\r\n--" + _boundary + "--\r\n");
				return new ContentReadStream(streams);
			}
			catch (Exception ex)
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(this, ex);
				}
				throw;
			}
		}

		private string SerializeHeadersToString(StringBuilder scratch, int contentIndex, HttpContent content)
		{
			scratch.Clear();
			if (contentIndex != 0)
			{
				scratch.Append("\r\n--");
				scratch.Append(_boundary);
				scratch.Append("\r\n");
			}
			foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
			{
				scratch.Append(header.Key);
				scratch.Append(": ");
				string value = string.Empty;
				foreach (string item in header.Value)
				{
					scratch.Append(value);
					scratch.Append(item);
					value = ", ";
				}
				scratch.Append("\r\n");
			}
			scratch.Append("\r\n");
			return scratch.ToString();
		}

		private static ValueTask EncodeStringToStreamAsync(Stream stream, string input)
		{
			byte[] bytes = HttpRuleParser.DefaultHttpEncoding.GetBytes(input);
			return stream.WriteAsync(new ReadOnlyMemory<byte>(bytes));
		}

		private static Stream EncodeStringToNewStream(string input)
		{
			return new MemoryStream(HttpRuleParser.DefaultHttpEncoding.GetBytes(input), writable: false);
		}

		protected internal override bool TryComputeLength(out long length)
		{
			int encodedLength = GetEncodedLength(_boundary);
			long num = 0L;
			long num2 = s_crlfLength + s_dashDashLength + encodedLength + s_crlfLength;
			num += s_dashDashLength + encodedLength + s_crlfLength;
			bool flag = true;
			foreach (HttpContent item in _nestedContent)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					num += num2;
				}
				foreach (KeyValuePair<string, IEnumerable<string>> header in item.Headers)
				{
					num += GetEncodedLength(header.Key) + s_colonSpaceLength;
					int num3 = 0;
					foreach (string item2 in header.Value)
					{
						num += GetEncodedLength(item2);
						num3++;
					}
					if (num3 > 1)
					{
						num += (num3 - 1) * s_commaSpaceLength;
					}
					num += s_crlfLength;
				}
				num += s_crlfLength;
				long length2 = 0L;
				if (!item.TryComputeLength(out length2))
				{
					length = 0L;
					return false;
				}
				num += length2;
			}
			num += s_crlfLength + s_dashDashLength + encodedLength + s_dashDashLength + s_crlfLength;
			length = num;
			return true;
		}

		private static int GetEncodedLength(string input)
		{
			return HttpRuleParser.DefaultHttpEncoding.GetByteCount(input);
		}
	}
	public class MultipartFormDataContent : MultipartContent
	{
		public MultipartFormDataContent(string boundary)
			: base("form-data", boundary)
		{
		}

		public override void Add(HttpContent content)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			if (content.Headers.ContentDisposition == null)
			{
				content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
			}
			base.Add(content);
		}

		public void Add(HttpContent content, string name)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("The value cannot be null or empty.", "name");
			}
			AddInternal(content, name, null);
		}

		public void Add(HttpContent content, string name, string fileName)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("The value cannot be null or empty.", "name");
			}
			if (string.IsNullOrWhiteSpace(fileName))
			{
				throw new ArgumentException("The value cannot be null or empty.", "fileName");
			}
			AddInternal(content, name, fileName);
		}

		private void AddInternal(HttpContent content, string name, string fileName)
		{
			if (content.Headers.ContentDisposition == null)
			{
				ContentDispositionHeaderValue contentDispositionHeaderValue = new ContentDispositionHeaderValue("form-data");
				contentDispositionHeaderValue.Name = name;
				contentDispositionHeaderValue.FileName = fileName;
				contentDispositionHeaderValue.FileNameStar = fileName;
				content.Headers.ContentDisposition = contentDispositionHeaderValue;
			}
			base.Add(content);
		}
	}
	internal class AuthenticationHelper
	{
		internal class DigestResponse
		{
			internal readonly Dictionary<string, string> Parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			internal DigestResponse(string challenge)
			{
				if (!string.IsNullOrEmpty(challenge))
				{
					Parse(challenge);
				}
			}

			private static bool CharIsSpaceOrTab(char ch)
			{
				if (ch != ' ')
				{
					return ch == '\t';
				}
				return true;
			}

			private static bool MustValueBeQuoted(string key)
			{
				if (!key.Equals("realm", StringComparison.OrdinalIgnoreCase) && !key.Equals("nonce", StringComparison.OrdinalIgnoreCase) && !key.Equals("opaque", StringComparison.OrdinalIgnoreCase))
				{
					return key.Equals("qop", StringComparison.OrdinalIgnoreCase);
				}
				return true;
			}

			private string GetNextKey(string data, int currentIndex, out int parsedIndex)
			{
				while (currentIndex < data.Length && CharIsSpaceOrTab(data[currentIndex]))
				{
					currentIndex++;
				}
				int num = currentIndex;
				while (currentIndex < data.Length && data[currentIndex] != '=' && !CharIsSpaceOrTab(data[currentIndex]))
				{
					currentIndex++;
				}
				if (currentIndex == data.Length)
				{
					parsedIndex = currentIndex;
					return null;
				}
				int length = currentIndex - num;
				if (CharIsSpaceOrTab(data[currentIndex]))
				{
					while (currentIndex < data.Length && CharIsSpaceOrTab(data[currentIndex]))
					{
						currentIndex++;
					}
					if (currentIndex == data.Length || data[currentIndex] != '=')
					{
						parsedIndex = currentIndex;
						return null;
					}
				}
				while (currentIndex < data.Length && (CharIsSpaceOrTab(data[currentIndex]) || data[currentIndex] == '='))
				{
					currentIndex++;
				}
				parsedIndex = currentIndex;
				return data.Substring(num, length);
			}

			private string GetNextValue(string data, int currentIndex, bool expectQuotes, out int parsedIndex)
			{
				bool flag = false;
				if (data[currentIndex] == '"')
				{
					flag = true;
					currentIndex++;
				}
				if (expectQuotes && !flag)
				{
					parsedIndex = currentIndex;
					return null;
				}
				StringBuilder stringBuilder = StringBuilderCache.Acquire();
				while (currentIndex < data.Length && ((flag && data[currentIndex] != '"') || (!flag && data[currentIndex] != ',')))
				{
					stringBuilder.Append(data[currentIndex]);
					currentIndex++;
					if (currentIndex == data.Length || (!flag && CharIsSpaceOrTab(data[currentIndex])))
					{
						break;
					}
					if (flag && data[currentIndex] == '"' && data[currentIndex - 1] == '\\')
					{
						stringBuilder.Append(data[currentIndex]);
						currentIndex++;
					}
				}
				if (flag)
				{
					currentIndex++;
				}
				while (currentIndex < data.Length && CharIsSpaceOrTab(data[currentIndex]))
				{
					currentIndex++;
				}
				if (currentIndex == data.Length)
				{
					parsedIndex = currentIndex;
					return StringBuilderCache.GetStringAndRelease(stringBuilder);
				}
				if (data[currentIndex++] != ',')
				{
					parsedIndex = currentIndex;
					return null;
				}
				while (currentIndex < data.Length && CharIsSpaceOrTab(data[currentIndex]))
				{
					currentIndex++;
				}
				parsedIndex = currentIndex;
				return StringBuilderCache.GetStringAndRelease(stringBuilder);
			}

			private void Parse(string challenge)
			{
				int parsedIndex = 0;
				while (parsedIndex < challenge.Length)
				{
					string nextKey = GetNextKey(challenge, parsedIndex, out parsedIndex);
					if (!string.IsNullOrEmpty(nextKey) && parsedIndex < challenge.Length)
					{
						string nextValue = GetNextValue(challenge, parsedIndex, MustValueBeQuoted(nextKey), out parsedIndex);
						if (!string.IsNullOrEmpty(nextValue))
						{
							Parameters.Add(nextKey, nextValue);
							continue;
						}
						break;
					}
					break;
				}
			}
		}

		private enum AuthenticationType
		{
			Basic,
			Digest,
			Ntlm,
			Negotiate
		}

		private readonly struct AuthenticationChallenge
		{
			public AuthenticationType AuthenticationType { get; }

			public string SchemeName { get; }

			public NetworkCredential Credential { get; }

			public string ChallengeData { get; }

			public AuthenticationChallenge(AuthenticationType authenticationType, string schemeName, NetworkCredential credential, string challenge)
			{
				AuthenticationType = authenticationType;
				SchemeName = schemeName;
				Credential = credential;
				ChallengeData = challenge;
			}
		}

		private static int[] s_alphaNumChooser = new int[3] { 48, 65, 97 };

		public static async Task<string> GetDigestTokenForCredential(NetworkCredential credential, HttpRequestMessage request, DigestResponse digestResponse)
		{
			StringBuilder sb = StringBuilderCache.Acquire();
			if (digestResponse.Parameters.TryGetValue("algorithm", out var algorithm))
			{
				if (!algorithm.Equals("SHA-256", StringComparison.OrdinalIgnoreCase) && !algorithm.Equals("MD5", StringComparison.OrdinalIgnoreCase) && !algorithm.Equals("SHA-256-sess", StringComparison.OrdinalIgnoreCase) && !algorithm.Equals("MD5-sess", StringComparison.OrdinalIgnoreCase))
				{
					if (NetEventSource.IsEnabled)
					{
						NetEventSource.Error(digestResponse, "Algorithm not supported: {algorithm}");
					}
					return null;
				}
			}
			else
			{
				algorithm = "MD5";
			}
			if (!digestResponse.Parameters.TryGetValue("nonce", out var nonce))
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(digestResponse, "Nonce missing");
				}
				return null;
			}
			digestResponse.Parameters.TryGetValue("opaque", out var opaque);
			if (!digestResponse.Parameters.TryGetValue("realm", out var value))
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(digestResponse, "Realm missing");
				}
				return null;
			}
			if (digestResponse.Parameters.TryGetValue("userhash", out var value2) && value2 == "true")
			{
				sb.AppendKeyValue("username", ComputeHash(credential.UserName + ":" + value, algorithm));
				sb.AppendKeyValue("userhash", value2, includeQuotes: false);
			}
			else if (HeaderUtilities.ContainsNonAscii(credential.UserName))
			{
				string value3 = HeaderUtilities.Encode5987(credential.UserName);
				sb.AppendKeyValue("username*", value3, includeQuotes: false);
			}
			else
			{
				sb.AppendKeyValue("username", credential.UserName);
			}
			if (value != string.Empty)
			{
				sb.AppendKeyValue("realm", value);
			}
			sb.AppendKeyValue("nonce", nonce);
			sb.AppendKeyValue("uri", request.RequestUri.PathAndQuery);
			string qop = "auth";
			if (digestResponse.Parameters.ContainsKey("qop"))
			{
				int num = digestResponse.Parameters["qop"].IndexOf("auth-int");
				if (num != -1 && digestResponse.Parameters["qop"].IndexOf("auth") == num && digestResponse.Parameters["qop"].IndexOf("auth", num + "auth-int".Length) == -1)
				{
					qop = "auth-int";
				}
			}
			string cnonce = GetRandomAlphaNumericString();
			string a1 = credential.UserName + ":" + value + ":" + credential.Password;
			if (algorithm.EndsWith("sess", StringComparison.OrdinalIgnoreCase))
			{
				a1 = ComputeHash(a1, algorithm) + ":" + nonce + ":" + cnonce;
			}
			string a2 = request.Method.Method + ":" + request.RequestUri.PathAndQuery;
			if (qop == "auth-int")
			{
				string text = ((request.Content != null) ? (await request.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : string.Empty);
				string data = text;
				a2 = a2 + ":" + ComputeHash(data, algorithm);
			}
			string value4 = ComputeHash(ComputeHash(a1, algorithm) + ":" + nonce + ":00000001:" + cnonce + ":" + qop + ":" + ComputeHash(a2, algorithm), algorithm);
			sb.AppendKeyValue("response", value4);
			sb.AppendKeyValue("algorithm", algorithm, includeQuotes: false);
			if (opaque != null)
			{
				sb.AppendKeyValue("opaque", opaque);
			}
			sb.AppendKeyValue("qop", qop, includeQuotes: false);
			sb.AppendKeyValue("nc", "00000001", includeQuotes: false);
			sb.AppendKeyValue("cnonce", cnonce, includeQuotes: true, includeComma: false);
			return StringBuilderCache.GetStringAndRelease(sb);
		}

		public static bool IsServerNonceStale(DigestResponse digestResponse)
		{
			string value = null;
			if (digestResponse.Parameters.TryGetValue("stale", out value))
			{
				return value == "true";
			}
			return false;
		}

		private static string GetRandomAlphaNumericString()
		{
			Span<byte> data = stackalloc byte[32];
			RandomNumberGenerator.Fill(data);
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			int num = 0;
			while (num < data.Length)
			{
				int num2 = data[num++] % 3;
				int num3 = data[num++] % ((num2 == 0) ? 10 : 26);
				stringBuilder.Append((char)(s_alphaNumChooser[num2] + num3));
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		private static string ComputeHash(string data, string algorithm)
		{
			using HashAlgorithm hashAlgorithm = (algorithm.StartsWith("SHA-256", StringComparison.OrdinalIgnoreCase) ? ((HashAlgorithm)SHA256.Create()) : ((HashAlgorithm)MD5.Create()));
			Span<byte> destination = stackalloc byte[hashAlgorithm.HashSize / 8];
			hashAlgorithm.TryComputeHash(Encoding.UTF8.GetBytes(data), destination, out var _);
			StringBuilder stringBuilder = StringBuilderCache.Acquire(destination.Length * 2);
			Span<char> span = stackalloc char[2];
			for (int i = 0; i < destination.Length; i++)
			{
				destination[i].TryFormat(span, out var _, "x2");
				stringBuilder.Append(span);
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		private static Task<HttpResponseMessage> InnerSendAsync(HttpRequestMessage request, bool isProxyAuth, HttpConnectionPool pool, HttpConnection connection, CancellationToken cancellationToken)
		{
			if (!isProxyAuth)
			{
				return pool.SendWithNtProxyAuthAsync(connection, request, cancellationToken);
			}
			return connection.SendAsyncCore(request, cancellationToken);
		}

		private static bool ProxySupportsConnectionAuth(HttpResponseMessage response)
		{
			if (!response.Headers.TryGetValues(KnownHeaders.ProxySupport.Descriptor, out var values))
			{
				return false;
			}
			foreach (string item in values)
			{
				if (item == "Session-Based-Authentication")
				{
					return true;
				}
			}
			return false;
		}

		private static async Task<HttpResponseMessage> SendWithNtAuthAsync(HttpRequestMessage request, Uri authUri, ICredentials credentials, bool isProxyAuth, HttpConnection connection, HttpConnectionPool connectionPool, CancellationToken cancellationToken)
		{
			HttpResponseMessage response = await InnerSendAsync(request, isProxyAuth, connectionPool, connection, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (!isProxyAuth && connection.Kind == HttpConnectionKind.Proxy && !ProxySupportsConnectionAuth(response))
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(connection, $"Proxy doesn't support connection-based auth, uri={authUri}");
				}
				return response;
			}
			if (TryGetAuthenticationChallenge(response, isProxyAuth, authUri, credentials, out var challenge) && (challenge.AuthenticationType == AuthenticationType.Negotiate || challenge.AuthenticationType == AuthenticationType.Ntlm))
			{
				bool isNewConnection = false;
				bool needDrain = true;
				try
				{
					if (response.Headers.ConnectionClose == true)
					{
						(connection, response) = await connectionPool.CreateConnectionAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						if (response != null)
						{
							return response;
						}
						connectionPool.IncrementConnectionCount();
						connection.Acquire();
						isNewConnection = true;
						needDrain = false;
					}
					string challengeData = challenge.ChallengeData;
					string text;
					if (!isProxyAuth && request.HasHeaders && request.Headers.Host != null)
					{
						text = request.Headers.Host;
						if (NetEventSource.IsEnabled)
						{
							NetEventSource.Info(connection, $"Authentication: {challenge.AuthenticationType}, Host: {text}");
						}
					}
					else
					{
						UriHostNameType hostNameType = authUri.HostNameType;
						text = ((hostNameType != UriHostNameType.IPv6 && hostNameType != UriHostNameType.IPv4) ? (await Dns.GetHostEntryAsync(authUri.IdnHost).ConfigureAwait(continueOnCapturedContext: false)).HostName : authUri.IdnHost);
					}
					string text2 = "HTTP/" + text;
					if (NetEventSource.IsEnabled)
					{
						NetEventSource.Info(connection, $"Authentication: {challenge.AuthenticationType}, SPN: {text2}");
					}
					ChannelBinding channelBinding = connection.TransportContext?.GetChannelBinding(ChannelBindingKind.Endpoint);
					NTAuthentication authContext = new NTAuthentication(isServer: false, challenge.SchemeName, challenge.Credential, text2, ContextFlagsPal.Connection, channelBinding);
					try
					{
						while (true)
						{
							string challengeResponse = authContext.GetOutgoingBlob(challengeData);
							if (challengeResponse != null)
							{
								if (needDrain)
								{
									await connection.DrainResponseAsync(response).ConfigureAwait(continueOnCapturedContext: false);
								}
								SetRequestAuthenticationHeaderValue(request, new AuthenticationHeaderValue(challenge.SchemeName, challengeResponse), isProxyAuth);
								response = await InnerSendAsync(request, isProxyAuth, connectionPool, connection, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
								if (!authContext.IsCompleted && TryGetRepeatedChallenge(response, challenge.SchemeName, isProxyAuth, out challengeData))
								{
									needDrain = true;
									continue;
								}
								break;
							}
							break;
						}
					}
					finally
					{
						authContext.CloseContext();
					}
				}
				finally
				{
					if (isNewConnection)
					{
						connection.Release();
					}
				}
			}
			return response;
		}

		public static Task<HttpResponseMessage> SendWithNtProxyAuthAsync(HttpRequestMessage request, Uri proxyUri, ICredentials proxyCredentials, HttpConnection connection, HttpConnectionPool connectionPool, CancellationToken cancellationToken)
		{
			return SendWithNtAuthAsync(request, proxyUri, proxyCredentials, isProxyAuth: true, connection, connectionPool, cancellationToken);
		}

		public static Task<HttpResponseMessage> SendWithNtConnectionAuthAsync(HttpRequestMessage request, ICredentials credentials, HttpConnection connection, HttpConnectionPool connectionPool, CancellationToken cancellationToken)
		{
			return SendWithNtAuthAsync(request, request.RequestUri, credentials, isProxyAuth: false, connection, connectionPool, cancellationToken);
		}

		private static bool TryGetChallengeDataForScheme(string scheme, HttpHeaderValueCollection<AuthenticationHeaderValue> authenticationHeaderValues, out string challengeData)
		{
			foreach (AuthenticationHeaderValue authenticationHeaderValue in authenticationHeaderValues)
			{
				if (StringComparer.OrdinalIgnoreCase.Equals(scheme, authenticationHeaderValue.Scheme))
				{
					challengeData = authenticationHeaderValue.Parameter;
					return true;
				}
			}
			challengeData = null;
			return false;
		}

		private static bool TryGetValidAuthenticationChallengeForScheme(string scheme, AuthenticationType authenticationType, Uri uri, ICredentials credentials, HttpHeaderValueCollection<AuthenticationHeaderValue> authenticationHeaderValues, out AuthenticationChallenge challenge)
		{
			challenge = default(AuthenticationChallenge);
			if (!TryGetChallengeDataForScheme(scheme, authenticationHeaderValues, out var challengeData))
			{
				return false;
			}
			NetworkCredential credential = credentials.GetCredential(uri, scheme);
			if (credential == null)
			{
				return false;
			}
			challenge = new AuthenticationChallenge(authenticationType, scheme, credential, challengeData);
			return true;
		}

		private static bool TryGetAuthenticationChallenge(HttpResponseMessage response, bool isProxyAuth, Uri authUri, ICredentials credentials, out AuthenticationChallenge challenge)
		{
			if (!IsAuthenticationChallenge(response, isProxyAuth))
			{
				challenge = default(AuthenticationChallenge);
				return false;
			}
			HttpHeaderValueCollection<AuthenticationHeaderValue> responseAuthenticationHeaderValues = GetResponseAuthenticationHeaderValues(response, isProxyAuth);
			if (!TryGetValidAuthenticationChallengeForScheme("Negotiate", AuthenticationType.Negotiate, authUri, credentials, responseAuthenticationHeaderValues, out challenge) && !TryGetValidAuthenticationChallengeForScheme("NTLM", AuthenticationType.Ntlm, authUri, credentials, responseAuthenticationHeaderValues, out challenge) && !TryGetValidAuthenticationChallengeForScheme("Digest", AuthenticationType.Digest, authUri, credentials, responseAuthenticationHeaderValues, out challenge))
			{
				return TryGetValidAuthenticationChallengeForScheme("Basic", AuthenticationType.Basic, authUri, credentials, responseAuthenticationHeaderValues, out challenge);
			}
			return true;
		}

		private static bool TryGetRepeatedChallenge(HttpResponseMessage response, string scheme, bool isProxyAuth, out string challengeData)
		{
			challengeData = null;
			if (!IsAuthenticationChallenge(response, isProxyAuth))
			{
				return false;
			}
			if (!TryGetChallengeDataForScheme(scheme, GetResponseAuthenticationHeaderValues(response, isProxyAuth), out challengeData))
			{
				return false;
			}
			return true;
		}

		private static bool IsAuthenticationChallenge(HttpResponseMessage response, bool isProxyAuth)
		{
			if (!isProxyAuth)
			{
				return response.StatusCode == HttpStatusCode.Unauthorized;
			}
			return response.StatusCode == HttpStatusCode.ProxyAuthenticationRequired;
		}

		private static HttpHeaderValueCollection<AuthenticationHeaderValue> GetResponseAuthenticationHeaderValues(HttpResponseMessage response, bool isProxyAuth)
		{
			if (!isProxyAuth)
			{
				return response.Headers.WwwAuthenticate;
			}
			return response.Headers.ProxyAuthenticate;
		}

		private static void SetRequestAuthenticationHeaderValue(HttpRequestMessage request, AuthenticationHeaderValue headerValue, bool isProxyAuth)
		{
			if (isProxyAuth)
			{
				request.Headers.ProxyAuthorization = headerValue;
			}
			else
			{
				request.Headers.Authorization = headerValue;
			}
		}

		private static void SetBasicAuthToken(HttpRequestMessage request, NetworkCredential credential, bool isProxyAuth)
		{
			string s = ((!string.IsNullOrEmpty(credential.Domain)) ? (credential.Domain + "\\" + credential.UserName + ":" + credential.Password) : (credential.UserName + ":" + credential.Password));
			string parameter = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			SetRequestAuthenticationHeaderValue(request, new AuthenticationHeaderValue("Basic", parameter), isProxyAuth);
		}

		private static async Task<bool> TrySetDigestAuthToken(HttpRequestMessage request, NetworkCredential credential, DigestResponse digestResponse, bool isProxyAuth)
		{
			string text = await GetDigestTokenForCredential(credential, request, digestResponse).ConfigureAwait(continueOnCapturedContext: false);
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			AuthenticationHeaderValue headerValue = new AuthenticationHeaderValue("Digest", text);
			SetRequestAuthenticationHeaderValue(request, headerValue, isProxyAuth);
			return true;
		}

		private static Task<HttpResponseMessage> InnerSendAsync(HttpRequestMessage request, bool isProxyAuth, bool doRequestAuth, HttpConnectionPool pool, CancellationToken cancellationToken)
		{
			if (!isProxyAuth)
			{
				return pool.SendWithProxyAuthAsync(request, doRequestAuth, cancellationToken);
			}
			return pool.SendWithRetryAsync(request, doRequestAuth, cancellationToken);
		}

		private static async Task<HttpResponseMessage> SendWithAuthAsync(HttpRequestMessage request, Uri authUri, ICredentials credentials, bool preAuthenticate, bool isProxyAuth, bool doRequestAuth, HttpConnectionPool pool, CancellationToken cancellationToken)
		{
			bool performedBasicPreauth = false;
			if (preAuthenticate)
			{
				NetworkCredential credential;
				lock (pool.PreAuthCredentials)
				{
					credential = pool.PreAuthCredentials.GetCredential(authUri, "Basic");
				}
				if (credential != null)
				{
					SetBasicAuthToken(request, credential, isProxyAuth);
					performedBasicPreauth = true;
				}
			}
			HttpResponseMessage response = await InnerSendAsync(request, isProxyAuth, doRequestAuth, pool, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (TryGetAuthenticationChallenge(response, isProxyAuth, authUri, credentials, out var challenge))
			{
				switch (challenge.AuthenticationType)
				{
				case AuthenticationType.Digest:
				{
					DigestResponse digestResponse = new DigestResponse(challenge.ChallengeData);
					if (!(await TrySetDigestAuthToken(request, challenge.Credential, digestResponse, isProxyAuth).ConfigureAwait(continueOnCapturedContext: false)))
					{
						break;
					}
					response.Dispose();
					response = await InnerSendAsync(request, isProxyAuth, doRequestAuth, pool, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (TryGetRepeatedChallenge(response, challenge.SchemeName, isProxyAuth, out var challengeData))
					{
						digestResponse = new DigestResponse(challengeData);
						bool flag = IsServerNonceStale(digestResponse);
						if (flag)
						{
							flag = await TrySetDigestAuthToken(request, challenge.Credential, digestResponse, isProxyAuth).ConfigureAwait(continueOnCapturedContext: false);
						}
						if (flag)
						{
							response.Dispose();
							response = await InnerSendAsync(request, isProxyAuth, doRequestAuth, pool, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						}
					}
					break;
				}
				case AuthenticationType.Basic:
				{
					if (performedBasicPreauth)
					{
						break;
					}
					response.Dispose();
					SetBasicAuthToken(request, challenge.Credential, isProxyAuth);
					response = await InnerSendAsync(request, isProxyAuth, doRequestAuth, pool, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (!preAuthenticate)
					{
						break;
					}
					HttpStatusCode statusCode = response.StatusCode;
					if (statusCode == HttpStatusCode.Unauthorized || statusCode == HttpStatusCode.ProxyAuthenticationRequired)
					{
						break;
					}
					lock (pool.PreAuthCredentials)
					{
						try
						{
							if (NetEventSource.IsEnabled)
							{
								NetEventSource.Info(pool.PreAuthCredentials, $"Adding Basic credential to cache, uri={authUri}, username={challenge.Credential.UserName}");
							}
							pool.PreAuthCredentials.Add(authUri, "Basic", challenge.Credential);
						}
						catch (ArgumentException)
						{
							if (NetEventSource.IsEnabled)
							{
								NetEventSource.Info(pool.PreAuthCredentials, $"Basic credential present in cache, uri={authUri}, username={challenge.Credential.UserName}");
							}
						}
					}
					break;
				}
				}
			}
			return response;
		}

		public static Task<HttpResponseMessage> SendWithProxyAuthAsync(HttpRequestMessage request, Uri proxyUri, ICredentials proxyCredentials, bool doRequestAuth, HttpConnectionPool pool, CancellationToken cancellationToken)
		{
			return SendWithAuthAsync(request, proxyUri, proxyCredentials, preAuthenticate: false, isProxyAuth: true, doRequestAuth, pool, cancellationToken);
		}

		public static Task<HttpResponseMessage> SendWithRequestAuthAsync(HttpRequestMessage request, ICredentials credentials, bool preAuthenticate, HttpConnectionPool pool, CancellationToken cancellationToken)
		{
			return SendWithAuthAsync(request, request.RequestUri, credentials, preAuthenticate, isProxyAuth: false, doRequestAuth: true, pool, cancellationToken);
		}
	}
	internal static class StringBuilderExtensions
	{
		private static readonly char[] SpecialCharacters = new char[2] { '"', '\\' };

		public static void AppendKeyValue(this StringBuilder sb, string key, string value, bool includeQuotes = true, bool includeComma = true)
		{
			sb.Append(key);
			sb.Append('=');
			if (includeQuotes)
			{
				sb.Append('"');
				int num = 0;
				while (true)
				{
					int num2 = value.IndexOfAny(SpecialCharacters, num);
					if (num2 < 0)
					{
						break;
					}
					sb.Append(value, num, num2 - num);
					sb.Append('\\');
					sb.Append(value[num2]);
					num = num2 + 1;
				}
				sb.Append(value, num, value.Length - num);
				sb.Append('"');
			}
			else
			{
				sb.Append(value);
			}
			if (includeComma)
			{
				sb.Append(',');
				sb.Append(' ');
			}
		}
	}
	internal static class CancellationHelper
	{
		private static readonly string s_cancellationMessage = new OperationCanceledException().Message;

		internal static bool ShouldWrapInOperationCanceledException(Exception exception, CancellationToken cancellationToken)
		{
			if (!(exception is OperationCanceledException))
			{
				return cancellationToken.IsCancellationRequested;
			}
			return false;
		}

		internal static Exception CreateOperationCanceledException(Exception innerException, CancellationToken cancellationToken)
		{
			return new TaskCanceledException(s_cancellationMessage, innerException, cancellationToken);
		}

		private static void ThrowOperationCanceledException(Exception innerException, CancellationToken cancellationToken)
		{
			throw CreateOperationCanceledException(innerException, cancellationToken);
		}

		internal static void ThrowIfCancellationRequested(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				ThrowOperationCanceledException(null, cancellationToken);
			}
		}
	}
	internal class HttpConnection : IDisposable
	{
		private sealed class ChunkedEncodingReadStream : HttpContentReadStream
		{
			private enum ParsingState : byte
			{
				ExpectChunkHeader,
				ExpectChunkData,
				ExpectChunkTerminator,
				ConsumeTrailers,
				Done
			}

			private ulong _chunkBytesRemaining;

			private ParsingState _state;

			public override bool NeedsDrain => _connection != null;

			public ChunkedEncodingReadStream(HttpConnection connection)
				: base(connection)
			{
			}

			public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return new ValueTask<int>(Task.FromCanceled<int>(cancellationToken));
				}
				if (_connection == null || buffer.Length == 0)
				{
					return new ValueTask<int>(0);
				}
				int num = ReadChunksFromConnectionBuffer(buffer.Span, default(CancellationTokenRegistration));
				if (num > 0)
				{
					return new ValueTask<int>(num);
				}
				if (_connection == null)
				{
					return new ValueTask<int>(0);
				}
				return ReadAsyncCore(buffer, cancellationToken);
			}

			private async ValueTask<int> ReadAsyncCore(Memory<byte> buffer, CancellationToken cancellationToken)
			{
				CancellationTokenRegistration ctr = _connection.RegisterCancellation(cancellationToken);
				try
				{
					int num2;
					do
					{
						if (_connection == null)
						{
							return 0;
						}
						if (_state == ParsingState.ExpectChunkData && buffer.Length >= _connection.ReadBufferSize && _chunkBytesRemaining >= (ulong)_connection.ReadBufferSize)
						{
							int num = await _connection.ReadAsync(buffer.Slice(0, (int)Math.Min((ulong)buffer.Length, _chunkBytesRemaining))).ConfigureAwait(continueOnCapturedContext: false);
							if (num == 0)
							{
								throw new IOException("The server returned an invalid or unrecognized response.");
							}
							_chunkBytesRemaining -= (ulong)num;
							if (_chunkBytesRemaining == 0L)
							{
								_state = ParsingState.ExpectChunkTerminator;
							}
							return num;
						}
						await _connection.FillAsync().ConfigureAwait(continueOnCapturedContext: false);
						num2 = ReadChunksFromConnectionBuffer(buffer.Span, ctr);
					}
					while (num2 <= 0);
					return num2;
				}
				catch (Exception ex) when (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
				{
					throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
				}
				finally
				{
					ctr.Dispose();
				}
			}

			public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
			{
				HttpContentStream.ValidateCopyToArgs(this, destination, bufferSize);
				if (!cancellationToken.IsCancellationRequested)
				{
					if (_connection != null)
					{
						return CopyToAsyncCore(destination, cancellationToken);
					}
					return Task.CompletedTask;
				}
				return Task.FromCanceled(cancellationToken);
			}

			private async Task CopyToAsyncCore(Stream destination, CancellationToken cancellationToken)
			{
				CancellationTokenRegistration ctr = _connection.RegisterCancellation(cancellationToken);
				try
				{
					while (true)
					{
						ReadOnlyMemory<byte> buffer = ReadChunkFromConnectionBuffer(2147483647, ctr);
						if (buffer.Length != 0)
						{
							await destination.WriteAsync(buffer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
							continue;
						}
						if (_connection == null)
						{
							break;
						}
						await _connection.FillAsync().ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				catch (Exception ex) when (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
				{
					throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
				}
				finally
				{
					ctr.Dispose();
				}
			}

			private int ReadChunksFromConnectionBuffer(Span<byte> buffer, CancellationTokenRegistration cancellationRegistration)
			{
				int num = 0;
				while (buffer.Length > 0)
				{
					ReadOnlyMemory<byte> readOnlyMemory = ReadChunkFromConnectionBuffer(buffer.Length, cancellationRegistration);
					if (readOnlyMemory.Length == 0)
					{
						break;
					}
					num += readOnlyMemory.Length;
					readOnlyMemory.Span.CopyTo(buffer);
					buffer = buffer.Slice(readOnlyMemory.Length);
				}
				return num;
			}

			private ReadOnlyMemory<byte> ReadChunkFromConnectionBuffer(int maxBytesToRead, CancellationTokenRegistration cancellationRegistration)
			{
				try
				{
					ReadOnlySpan<byte> line;
					switch (_state)
					{
					case ParsingState.ExpectChunkHeader:
					{
						_connection._allowedReadLineBytes = 16384;
						if (!_connection.TryReadNextLine(out line))
						{
							return default(ReadOnlyMemory<byte>);
						}
						if (!Utf8Parser.TryParse(line, out ulong value, out int bytesConsumed, 'X'))
						{
							throw new IOException("The server returned an invalid or unrecognized response.");
						}
						_chunkBytesRemaining = value;
						if (bytesConsumed != line.Length)
						{
							ValidateChunkExtension(line.Slice(bytesConsumed));
						}
						if (value != 0)
						{
							_state = ParsingState.ExpectChunkData;
							goto case ParsingState.ExpectChunkData;
						}
						_state = ParsingState.ConsumeTrailers;
						_connection._allowedReadLineBytes = _connection.MaxResponseHeadersLength;
						goto case ParsingState.ConsumeTrailers;
					}
					case ParsingState.ExpectChunkData:
					{
						ReadOnlyMemory<byte> remainingBuffer = _connection.RemainingBuffer;
						if (remainingBuffer.Length == 0)
						{
							return default(ReadOnlyMemory<byte>);
						}
						int num = Math.Min(maxBytesToRead, (int)Math.Min((ulong)remainingBuffer.Length, _chunkBytesRemaining));
						_connection.ConsumeFromRemainingBuffer(num);
						_chunkBytesRemaining -= (ulong)num;
						if (_chunkBytesRemaining == 0L)
						{
							_state = ParsingState.ExpectChunkTerminator;
						}
						return remainingBuffer.Slice(0, num);
					}
					case ParsingState.ExpectChunkTerminator:
						_connection._allowedReadLineBytes = 16384;
						if (!_connection.TryReadNextLine(out line))
						{
							return default(ReadOnlyMemory<byte>);
						}
						if (line.Length != 0)
						{
							ThrowInvalidHttpResponse();
						}
						_state = ParsingState.ExpectChunkHeader;
						goto case ParsingState.ExpectChunkHeader;
					case ParsingState.ConsumeTrailers:
						while (_connection.TryReadNextLine(out line))
						{
							if (line.IsEmpty)
							{
								cancellationRegistration.Dispose();
								CancellationHelper.ThrowIfCancellationRequested(cancellationRegistration.Token);
								_state = ParsingState.Done;
								_connection.CompleteResponse();
								_connection = null;
								break;
							}
						}
						return default(ReadOnlyMemory<byte>);
					default:
						if (NetEventSource.IsEnabled)
						{
							NetEventSource.Error(this, $"Unexpected state: {_state}");
						}
						return default(ReadOnlyMemory<byte>);
					}
				}
				catch (Exception)
				{
					_connection.Dispose();
					_connection = null;
					throw;
				}
			}

			private static void ValidateChunkExtension(ReadOnlySpan<byte> lineAfterChunkSize)
			{
				for (int i = 0; i < lineAfterChunkSize.Length; i++)
				{
					switch (lineAfterChunkSize[i])
					{
					case 9:
					case 32:
						continue;
					case 59:
						return;
					}
					throw new IOException("The server returned an invalid or unrecognized response.");
				}
			}

			public override async Task<bool> DrainAsync(int maxDrainBytes)
			{
				CancellationTokenSource cts = null;
				CancellationTokenRegistration ctr = default(CancellationTokenRegistration);
				try
				{
					int drainedBytes = 0;
					while (true)
					{
						drainedBytes += _connection.RemainingBuffer.Length;
						while (ReadChunkFromConnectionBuffer(2147483647, ctr).Length != 0)
						{
						}
						if (_connection == null)
						{
							return true;
						}
						if (drainedBytes >= maxDrainBytes)
						{
							break;
						}
						if (cts == null)
						{
							TimeSpan maxResponseDrainTime = _connection._pool.Settings._maxResponseDrainTime;
							if (maxResponseDrainTime != Timeout.InfiniteTimeSpan)
							{
								cts = new CancellationTokenSource((int)maxResponseDrainTime.TotalMilliseconds);
								ctr = cts.Token.Register(delegate(object s)
								{
									((HttpConnection)s).Dispose();
								}, _connection);
							}
						}
						await _connection.FillAsync().ConfigureAwait(continueOnCapturedContext: false);
					}
					return false;
				}
				finally
				{
					ctr.Dispose();
					cts?.Dispose();
				}
			}
		}

		private sealed class ChunkedEncodingWriteStream : HttpContentWriteStream
		{
			private static readonly byte[] s_finalChunkBytes = new byte[5] { 48, 13, 10, 13, 10 };

			public ChunkedEncodingWriteStream(HttpConnection connection)
				: base(connection)
			{
			}

			public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken ignored)
			{
				if (buffer.Length != 0)
				{
					return new ValueTask(WriteChunkAsync(buffer));
				}
				return _connection.FlushAsync();
			}

			private async Task WriteChunkAsync(ReadOnlyMemory<byte> buffer)
			{
				await _connection.WriteHexInt32Async(buffer.Length).ConfigureAwait(continueOnCapturedContext: false);
				await _connection.WriteTwoBytesAsync(13, 10).ConfigureAwait(continueOnCapturedContext: false);
				await _connection.WriteAsync(buffer).ConfigureAwait(continueOnCapturedContext: false);
				await _connection.WriteTwoBytesAsync(13, 10).ConfigureAwait(continueOnCapturedContext: false);
			}

			public override async Task FinishAsync()
			{
				await _connection.WriteBytesAsync(s_finalChunkBytes).ConfigureAwait(continueOnCapturedContext: false);
				_connection = null;
			}
		}

		private sealed class ConnectionCloseReadStream : HttpContentReadStream
		{
			public ConnectionCloseReadStream(HttpConnection connection)
				: base(connection)
			{
			}

			public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken)
			{
				CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
				if (_connection == null || buffer.Length == 0)
				{
					return 0;
				}
				ValueTask<int> valueTask = _connection.ReadAsync(buffer);
				int num;
				if (valueTask.IsCompletedSuccessfully)
				{
					num = valueTask.Result;
				}
				else
				{
					CancellationTokenRegistration ctr = _connection.RegisterCancellation(cancellationToken);
					try
					{
						num = await valueTask.ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception ex) when (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
					{
						throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
					}
					finally
					{
						ctr.Dispose();
					}
				}
				if (num == 0)
				{
					CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
					_connection.Dispose();
					_connection = null;
					return 0;
				}
				return num;
			}

			public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
			{
				HttpContentStream.ValidateCopyToArgs(this, destination, bufferSize);
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled(cancellationToken);
				}
				if (_connection == null)
				{
					return Task.CompletedTask;
				}
				Task task = _connection.CopyToUntilEofAsync(destination, bufferSize, cancellationToken);
				if (task.IsCompletedSuccessfully)
				{
					Finish();
					return Task.CompletedTask;
				}
				return CompleteCopyToAsync(task, cancellationToken);
			}

			private async Task CompleteCopyToAsync(Task copyTask, CancellationToken cancellationToken)
			{
				CancellationTokenRegistration ctr = _connection.RegisterCancellation(cancellationToken);
				try
				{
					await copyTask.ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception ex) when (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
				{
					throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
				}
				finally
				{
					ctr.Dispose();
				}
				CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
				Finish();
			}

			private void Finish()
			{
				_connection.Dispose();
				_connection = null;
			}
		}

		private sealed class ContentLengthReadStream : HttpContentReadStream
		{
			private ulong _contentBytesRemaining;

			public override bool NeedsDrain => _connection != null;

			public ContentLengthReadStream(HttpConnection connection, ulong contentLength)
				: base(connection)
			{
				_contentBytesRemaining = contentLength;
			}

			public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken)
			{
				CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
				if (_connection == null || buffer.Length == 0)
				{
					return 0;
				}
				if ((ulong)buffer.Length > _contentBytesRemaining)
				{
					buffer = buffer.Slice(0, (int)_contentBytesRemaining);
				}
				ValueTask<int> valueTask = _connection.ReadAsync(buffer);
				int num;
				if (valueTask.IsCompletedSuccessfully)
				{
					num = valueTask.Result;
				}
				else
				{
					CancellationTokenRegistration ctr = _connection.RegisterCancellation(cancellationToken);
					try
					{
						num = await valueTask.ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception ex) when (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
					{
						throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
					}
					finally
					{
						ctr.Dispose();
					}
				}
				if (num <= 0)
				{
					CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
					throw new IOException("The server returned an invalid or unrecognized response.");
				}
				_contentBytesRemaining -= (ulong)num;
				if (_contentBytesRemaining == 0L)
				{
					_connection.CompleteResponse();
					_connection = null;
				}
				return num;
			}

			public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
			{
				HttpContentStream.ValidateCopyToArgs(this, destination, bufferSize);
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled(cancellationToken);
				}
				if (_connection == null)
				{
					return Task.CompletedTask;
				}
				Task task = _connection.CopyToExactLengthAsync(destination, _contentBytesRemaining, cancellationToken);
				if (task.IsCompletedSuccessfully)
				{
					Finish();
					return Task.CompletedTask;
				}
				return CompleteCopyToAsync(task, cancellationToken);
			}

			private async Task CompleteCopyToAsync(Task copyTask, CancellationToken cancellationToken)
			{
				CancellationTokenRegistration ctr = _connection.RegisterCancellation(cancellationToken);
				try
				{
					await copyTask.ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception ex) when (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
				{
					throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
				}
				finally
				{
					ctr.Dispose();
				}
				Finish();
			}

			private void Finish()
			{
				_contentBytesRemaining = 0uL;
				_connection.CompleteResponse();
				_connection = null;
			}

			private ReadOnlyMemory<byte> ReadFromConnectionBuffer(int maxBytesToRead)
			{
				ReadOnlyMemory<byte> remainingBuffer = _connection.RemainingBuffer;
				if (remainingBuffer.Length == 0)
				{
					return default(ReadOnlyMemory<byte>);
				}
				int num = Math.Min(maxBytesToRead, (int)Math.Min((ulong)remainingBuffer.Length, _contentBytesRemaining));
				_connection.ConsumeFromRemainingBuffer(num);
				_contentBytesRemaining -= (ulong)num;
				return remainingBuffer.Slice(0, num);
			}

			public override async Task<bool> DrainAsync(int maxDrainBytes)
			{
				ReadFromConnectionBuffer(2147483647);
				if (_contentBytesRemaining == 0L)
				{
					Finish();
					return true;
				}
				if (_contentBytesRemaining > (ulong)maxDrainBytes)
				{
					return false;
				}
				CancellationTokenSource cts = null;
				CancellationTokenRegistration ctr = default(CancellationTokenRegistration);
				TimeSpan maxResponseDrainTime = _connection._pool.Settings._maxResponseDrainTime;
				if (maxResponseDrainTime != Timeout.InfiniteTimeSpan)
				{
					cts = new CancellationTokenSource((int)maxResponseDrainTime.TotalMilliseconds);
					ctr = cts.Token.Register(delegate(object s)
					{
						((HttpConnection)s).Dispose();
					}, _connection);
				}
				try
				{
					do
					{
						await _connection.FillAsync().ConfigureAwait(continueOnCapturedContext: false);
						ReadFromConnectionBuffer(2147483647);
					}
					while (_contentBytesRemaining != 0L);
					ctr.Dispose();
					CancellationHelper.ThrowIfCancellationRequested(ctr.Token);
					Finish();
					return true;
				}
				finally
				{
					ctr.Dispose();
					cts?.Dispose();
				}
			}
		}

		private sealed class ContentLengthWriteStream : HttpContentWriteStream
		{
			public ContentLengthWriteStream(HttpConnection connection)
				: base(connection)
			{
			}

			public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken ignored)
			{
				return new ValueTask(_connection.WriteAsync(buffer));
			}

			public override Task FinishAsync()
			{
				_connection = null;
				return Task.CompletedTask;
			}
		}

		private sealed class EmptyReadStream : HttpContentReadStream
		{
			private static readonly Task<int> s_zeroTask = Task.FromResult(0);

			internal static EmptyReadStream Instance { get; } = new EmptyReadStream();

			private EmptyReadStream()
				: base(null)
			{
			}

			protected override void Dispose(bool disposing)
			{
			}

			public override void Close()
			{
			}

			public override int ReadByte()
			{
				return -1;
			}

			public override int Read(Span<byte> buffer)
			{
				return 0;
			}

			public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken)
			{
				if (!cancellationToken.IsCancellationRequested)
				{
					return new ValueTask<int>(0);
				}
				return new ValueTask<int>(Task.FromCanceled<int>(cancellationToken));
			}
		}

		private sealed class HttpConnectionResponseContent : HttpContent
		{
			private HttpContentStream _stream;

			private bool _consumedStream;

			public void SetStream(HttpContentStream stream)
			{
				_stream = stream;
			}

			private HttpContentStream ConsumeStream()
			{
				if (_consumedStream || _stream == null)
				{
					throw new InvalidOperationException("The stream was already consumed. It cannot be read again.");
				}
				_consumedStream = true;
				return _stream;
			}

			protected sealed override Task SerializeToStreamAsync(Stream stream, TransportContext context)
			{
				return SerializeToStreamAsync(stream, context, CancellationToken.None);
			}

			internal sealed override async Task SerializeToStreamAsync(Stream stream, TransportContext context, CancellationToken cancellationToken)
			{
				using HttpContentStream contentStream = ConsumeStream();
				await contentStream.CopyToAsync(stream, 8192, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}

			protected internal sealed override bool TryComputeLength(out long length)
			{
				length = 0L;
				return false;
			}

			protected sealed override Task<Stream> CreateContentReadStreamAsync()
			{
				return Task.FromResult((Stream)ConsumeStream());
			}

			internal sealed override Stream TryCreateContentReadStream()
			{
				return ConsumeStream();
			}

			protected sealed override void Dispose(bool disposing)
			{
				if (disposing && _stream != null)
				{
					_stream.Dispose();
					_stream = null;
				}
				base.Dispose(disposing);
			}
		}

		internal abstract class HttpContentReadStream : HttpContentStream
		{
			private int _disposed;

			public sealed override bool CanRead => true;

			public sealed override bool CanWrite => false;

			public virtual bool NeedsDrain => false;

			public HttpContentReadStream(HttpConnection connection)
				: base(connection)
			{
			}

			public sealed override void Flush()
			{
			}

			public sealed override Task FlushAsync(CancellationToken cancellationToken)
			{
				if (!cancellationToken.IsCancellationRequested)
				{
					return Task.CompletedTask;
				}
				return Task.FromCanceled(cancellationToken);
			}

			public sealed override void WriteByte(byte value)
			{
				throw new NotSupportedException();
			}

			public sealed override void Write(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException();
			}

			public sealed override void Write(ReadOnlySpan<byte> source)
			{
				throw new NotSupportedException();
			}

			public sealed override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				throw new NotSupportedException();
			}

			public sealed override ValueTask WriteAsync(ReadOnlyMemory<byte> destination, CancellationToken cancellationToken)
			{
				throw new NotSupportedException();
			}

			public sealed override int Read(byte[] buffer, int offset, int count)
			{
				HttpContentStream.ValidateBufferArgs(buffer, offset, count);
				return ReadAsync(new Memory<byte>(buffer, offset, count), CancellationToken.None).GetAwaiter().GetResult();
			}

			public sealed override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				HttpContentStream.ValidateBufferArgs(buffer, offset, count);
				return ReadAsync(new Memory<byte>(buffer, offset, count), cancellationToken).AsTask();
			}

			public sealed override void CopyTo(Stream destination, int bufferSize)
			{
				CopyToAsync(destination, bufferSize, CancellationToken.None).GetAwaiter().GetResult();
			}

			public virtual Task<bool> DrainAsync(int maxDrainBytes)
			{
				return Task.FromResult(result: false);
			}

			protected override void Dispose(bool disposing)
			{
				if (Interlocked.Exchange(ref _disposed, 1) == 0)
				{
					if (disposing && NeedsDrain)
					{
						DrainOnDisposeAsync();
					}
					else
					{
						base.Dispose(disposing);
					}
				}
			}

			private async Task DrainOnDisposeAsync()
			{
				HttpConnection connection = _connection;
				try
				{
					bool flag = await DrainAsync(connection._pool.Settings._maxResponseDrainSize).ConfigureAwait(continueOnCapturedContext: false);
					if (NetEventSource.IsEnabled)
					{
						connection.Trace(flag ? "Connection drain succeeded" : $"Connection drain failed because MaxResponseDrainSize of {connection._pool.Settings._maxResponseDrainSize} bytes was exceeded", "DrainOnDisposeAsync");
					}
				}
				catch (Exception arg)
				{
					if (NetEventSource.IsEnabled)
					{
						connection.Trace($"Connection drain failed due to exception: {arg}", "DrainOnDisposeAsync");
					}
				}
				base.Dispose(true);
			}
		}

		private abstract class HttpContentWriteStream : HttpContentStream
		{
			public sealed override bool CanRead => false;

			public sealed override bool CanWrite => true;

			public HttpContentWriteStream(HttpConnection connection)
				: base(connection)
			{
			}

			public sealed override void Flush()
			{
				FlushAsync().GetAwaiter().GetResult();
			}

			public sealed override int Read(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException();
			}

			public sealed override void Write(byte[] buffer, int offset, int count)
			{
				WriteAsync(buffer, offset, count, CancellationToken.None).GetAwaiter().GetResult();
			}

			public sealed override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken ignored)
			{
				HttpContentStream.ValidateBufferArgs(buffer, offset, count);
				return WriteAsync(new ReadOnlyMemory<byte>(buffer, offset, count), ignored).AsTask();
			}

			public sealed override Task FlushAsync(CancellationToken ignored)
			{
				return _connection.FlushAsync().AsTask();
			}

			public abstract Task FinishAsync();
		}

		private sealed class RawConnectionStream : HttpContentDuplexStream
		{
			public RawConnectionStream(HttpConnection connection)
				: base(connection)
			{
			}

			public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken)
			{
				CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
				if (_connection == null || buffer.Length == 0)
				{
					return 0;
				}
				ValueTask<int> valueTask = _connection.ReadBufferedAsync(buffer);
				int num;
				if (valueTask.IsCompletedSuccessfully)
				{
					num = valueTask.Result;
				}
				else
				{
					CancellationTokenRegistration ctr = _connection.RegisterCancellation(cancellationToken);
					try
					{
						num = await valueTask.ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception ex) when (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
					{
						throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
					}
					finally
					{
						ctr.Dispose();
					}
				}
				if (num == 0)
				{
					CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
					_connection.Dispose();
					_connection = null;
					return 0;
				}
				return num;
			}

			public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
			{
				HttpContentStream.ValidateCopyToArgs(this, destination, bufferSize);
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled(cancellationToken);
				}
				if (_connection == null)
				{
					return Task.CompletedTask;
				}
				Task task = _connection.CopyToUntilEofAsync(destination, bufferSize, cancellationToken);
				if (task.IsCompletedSuccessfully)
				{
					Finish();
					return Task.CompletedTask;
				}
				return CompleteCopyToAsync(task, cancellationToken);
			}

			private async Task CompleteCopyToAsync(Task copyTask, CancellationToken cancellationToken)
			{
				CancellationTokenRegistration ctr = _connection.RegisterCancellation(cancellationToken);
				try
				{
					await copyTask.ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception ex) when (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
				{
					throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
				}
				finally
				{
					ctr.Dispose();
				}
				CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
				Finish();
			}

			private void Finish()
			{
				_connection.Dispose();
				_connection = null;
			}

			public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return new ValueTask(Task.FromCanceled(cancellationToken));
				}
				if (_connection == null)
				{
					return new ValueTask(Task.FromException(new IOException("The write operation failed, see inner exception.")));
				}
				if (buffer.Length == 0)
				{
					return default(ValueTask);
				}
				ValueTask valueTask = _connection.WriteWithoutBufferingAsync(buffer);
				if (!valueTask.IsCompleted)
				{
					return new ValueTask(WaitWithConnectionCancellationAsync(valueTask, cancellationToken));
				}
				return valueTask;
			}

			public override Task FlushAsync(CancellationToken cancellationToken)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled(cancellationToken);
				}
				if (_connection == null)
				{
					return Task.CompletedTask;
				}
				ValueTask task = _connection.FlushAsync();
				if (!task.IsCompleted)
				{
					return WaitWithConnectionCancellationAsync(task, cancellationToken);
				}
				return task.AsTask();
			}

			private async Task WaitWithConnectionCancellationAsync(ValueTask task, CancellationToken cancellationToken)
			{
				CancellationTokenRegistration ctr = _connection.RegisterCancellation(cancellationToken);
				try
				{
					await task.ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception ex) when (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
				{
					throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
				}
				finally
				{
					ctr.Dispose();
				}
			}
		}

		private static readonly byte[] s_contentLength0NewlineAsciiBytes = Encoding.ASCII.GetBytes("Content-Length: 0\r\n");

		private static readonly byte[] s_spaceHttp10NewlineAsciiBytes = Encoding.ASCII.GetBytes(" HTTP/1.0\r\n");

		private static readonly byte[] s_spaceHttp11NewlineAsciiBytes = Encoding.ASCII.GetBytes(" HTTP/1.1\r\n");

		private static readonly byte[] s_httpSchemeAndDelimiter = Encoding.ASCII.GetBytes(Uri.UriSchemeHttp + Uri.SchemeDelimiter);

		private static readonly byte[] s_http1DotBytes = Encoding.ASCII.GetBytes("HTTP/1.");

		private static readonly ulong s_http10Bytes = BitConverter.ToUInt64(Encoding.ASCII.GetBytes("HTTP/1.0"));

		private static readonly ulong s_http11Bytes = BitConverter.ToUInt64(Encoding.ASCII.GetBytes("HTTP/1.1"));

		private readonly HttpConnectionPool _pool;

		private readonly Socket _socket;

		private readonly Stream _stream;

		private readonly TransportContext _transportContext;

		private readonly WeakReference<HttpConnection> _weakThisRef;

		private HttpRequestMessage _currentRequest;

		private readonly byte[] _writeBuffer;

		private int _writeOffset;

		private int _allowedReadLineBytes;

		private ValueTask<int>? _readAheadTask;

		private int _readAheadTaskLock;

		private byte[] _readBuffer;

		private int _readOffset;

		private int _readLength;

		private bool _inUse;

		private bool _canRetry;

		private bool _connectionClose;

		private int _disposed;

		public bool IsNewConnection => !_readAheadTask.HasValue;

		public bool CanRetry => _canRetry;

		public DateTimeOffset CreationTime { get; } = DateTimeOffset.UtcNow;

		public TransportContext TransportContext => _transportContext;

		public HttpConnectionKind Kind => _pool.Kind;

		private int MaxResponseHeadersLength => (int)Math.Min(2147483647L, (long)_pool.Settings._maxResponseHeadersLength * 1024L);

		private int ReadBufferSize => _readBuffer.Length;

		private ReadOnlyMemory<byte> RemainingBuffer => new ReadOnlyMemory<byte>(_readBuffer, _readOffset, _readLength - _readOffset);

		public HttpConnection(HttpConnectionPool pool, Socket socket, Stream stream, TransportContext transportContext)
		{
			_pool = pool;
			_socket = socket;
			_stream = stream;
			_transportContext = transportContext;
			_writeBuffer = new byte[4096];
			_readBuffer = new byte[4096];
			_weakThisRef = new WeakReference<HttpConnection>(this);
			if (NetEventSource.IsEnabled)
			{
				if (pool.IsSecure)
				{
					SslStream sslStream = (SslStream)_stream;
					Trace($"Secure connection created to {pool}. " + $"SslProtocol:{sslStream.SslProtocol}, " + $"CipherAlgorithm:{sslStream.CipherAlgorithm}, CipherStrength:{sslStream.CipherStrength}, " + $"HashAlgorithm:{sslStream.HashAlgorithm}, HashStrength:{sslStream.HashStrength}, " + $"KeyExchangeAlgorithm:{sslStream.KeyExchangeAlgorithm}, KeyExchangeStrength:{sslStream.KeyExchangeStrength}, " + $"LocalCert:{sslStream.LocalCertificate}, RemoteCert:{sslStream.RemoteCertificate}", ".ctor");
				}
				else
				{
					Trace($"Connection created to {pool}.", ".ctor");
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		protected void Dispose(bool disposing)
		{
			if (Interlocked.Exchange(ref _disposed, 1) != 0)
			{
				return;
			}
			if (NetEventSource.IsEnabled)
			{
				Trace("Connection closing.", "Dispose");
			}
			_pool.DecrementConnectionCount();
			if (disposing)
			{
				GC.SuppressFinalize(this);
				_stream.Dispose();
				ValueTask<int>? valueTask = ConsumeReadAheadTask();
				if (valueTask.HasValue)
				{
					IgnoreExceptionsAsync(valueTask.GetValueOrDefault());
				}
			}
		}

		private static async Task IgnoreExceptionsAsync(ValueTask<int> task)
		{
			try
			{
				await task.ConfigureAwait(continueOnCapturedContext: false);
			}
			catch
			{
			}
		}

		private async Task LogExceptionsAsync(Task task)
		{
			try
			{
				await task.ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception arg)
			{
				if (NetEventSource.IsEnabled)
				{
					Trace($"Exception from asynchronous processing: {arg}", "LogExceptionsAsync");
				}
			}
		}

		public bool PollRead()
		{
			if (_socket != null)
			{
				try
				{
					return _socket.Poll(0, SelectMode.SelectRead);
				}
				catch (Exception ex) when (ex is SocketException || ex is ObjectDisposedException)
				{
					return true;
				}
			}
			return EnsureReadAheadAndPollRead();
		}

		public bool EnsureReadAheadAndPollRead()
		{
			try
			{
				if (!_readAheadTask.HasValue)
				{
					_readAheadTask = _stream.ReadAsync(new Memory<byte>(_readBuffer));
				}
			}
			catch (Exception arg)
			{
				if (NetEventSource.IsEnabled)
				{
					Trace($"Error performing read ahead: {arg}", "EnsureReadAheadAndPollRead");
				}
				Dispose();
				_readAheadTask = new ValueTask<int>(0);
			}
			if (!_readAheadTask.Value.IsCompleted && _socket != null)
			{
				try
				{
					return _socket.Poll(0, SelectMode.SelectRead);
				}
				catch
				{
					return false;
				}
			}
			return _readAheadTask.Value.IsCompleted;
		}

		private ValueTask<int>? ConsumeReadAheadTask()
		{
			if (Interlocked.CompareExchange(ref _readAheadTaskLock, 1, 0) == 0)
			{
				ValueTask<int>? readAheadTask = _readAheadTask;
				_readAheadTask = null;
				Volatile.Write(ref _readAheadTaskLock, 0);
				return readAheadTask;
			}
			return null;
		}

		private void ConsumeFromRemainingBuffer(int bytesToConsume)
		{
			_readOffset += bytesToConsume;
		}

		private async Task WriteHeadersAsync(HttpHeaders headers, string cookiesFromContainer)
		{
			foreach (KeyValuePair<HeaderDescriptor, string[]> header in headers.GetHeaderDescriptorsAndValues())
			{
				if (header.Key.KnownHeader == null)
				{
					await WriteAsciiStringAsync(header.Key.Name).ConfigureAwait(continueOnCapturedContext: false);
					await WriteTwoBytesAsync(58, 32).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					await WriteBytesAsync(header.Key.KnownHeader.AsciiBytesWithColonSpace).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (header.Value.Length != 0)
				{
					await WriteStringAsync(header.Value[0]).ConfigureAwait(continueOnCapturedContext: false);
					if (cookiesFromContainer != null && header.Key.KnownHeader == KnownHeaders.Cookie)
					{
						await WriteTwoBytesAsync(59, 32).ConfigureAwait(continueOnCapturedContext: false);
						await WriteStringAsync(cookiesFromContainer).ConfigureAwait(continueOnCapturedContext: false);
						cookiesFromContainer = null;
					}
					if (header.Value.Length > 1)
					{
						HttpHeaderParser parser = header.Key.Parser;
						string separator = ", ";
						if (parser != null && parser.SupportsMultipleValues)
						{
							separator = parser.Separator;
						}
						for (int i = 1; i < header.Value.Length; i++)
						{
							await WriteAsciiStringAsync(separator).ConfigureAwait(continueOnCapturedContext: false);
							await WriteStringAsync(header.Value[i]).ConfigureAwait(continueOnCapturedContext: false);
						}
					}
				}
				await WriteTwoBytesAsync(13, 10).ConfigureAwait(continueOnCapturedContext: false);
			}
			if (cookiesFromContainer != null)
			{
				await WriteAsciiStringAsync("Cookie").ConfigureAwait(continueOnCapturedContext: false);
				await WriteTwoBytesAsync(58, 32).ConfigureAwait(continueOnCapturedContext: false);
				await WriteStringAsync(cookiesFromContainer).ConfigureAwait(continueOnCapturedContext: false);
				await WriteTwoBytesAsync(13, 10).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private async Task WriteHostHeaderAsync(Uri uri)
		{
			await WriteBytesAsync(KnownHeaders.Host.AsciiBytesWithColonSpace).ConfigureAwait(continueOnCapturedContext: false);
			if (_pool.HostHeaderValueBytes != null)
			{
				await WriteBytesAsync(_pool.HostHeaderValueBytes).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				if (uri.HostNameType != UriHostNameType.IPv6)
				{
					await WriteAsciiStringAsync(uri.IdnHost).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					await WriteByteAsync(91).ConfigureAwait(continueOnCapturedContext: false);
					await WriteAsciiStringAsync(uri.IdnHost).ConfigureAwait(continueOnCapturedContext: false);
					await WriteByteAsync(93).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (!uri.IsDefaultPort)
				{
					await WriteByteAsync(58).ConfigureAwait(continueOnCapturedContext: false);
					await WriteDecimalInt32Async(uri.Port).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			await WriteTwoBytesAsync(13, 10).ConfigureAwait(continueOnCapturedContext: false);
		}

		private Task WriteDecimalInt32Async(int value)
		{
			if (Utf8Formatter.TryFormat(value, new Span<byte>(_writeBuffer, _writeOffset, _writeBuffer.Length - _writeOffset), out var bytesWritten))
			{
				_writeOffset += bytesWritten;
				return Task.CompletedTask;
			}
			return WriteAsciiStringAsync(value.ToString());
		}

		private Task WriteHexInt32Async(int value)
		{
			if (Utf8Formatter.TryFormat(value, new Span<byte>(_writeBuffer, _writeOffset, _writeBuffer.Length - _writeOffset), out var bytesWritten, 'X'))
			{
				_writeOffset += bytesWritten;
				return Task.CompletedTask;
			}
			return WriteAsciiStringAsync(value.ToString("X", CultureInfo.InvariantCulture));
		}

		public async Task<HttpResponseMessage> SendAsyncCore(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			TaskCompletionSource<bool> allowExpect100ToContinue = null;
			Task sendRequestContentTask = null;
			_currentRequest = request;
			HttpMethod normalizedMethod = HttpMethod.Normalize(request.Method);
			bool hasExpectContinueHeader = request.HasHeaders && request.Headers.ExpectContinue == true;
			_canRetry = true;
			if (NetEventSource.IsEnabled)
			{
				Trace($"Sending request: {request}", "SendAsyncCore");
			}
			CancellationTokenRegistration cancellationRegistration = RegisterCancellation(cancellationToken);
			try
			{
				await WriteStringAsync(normalizedMethod.Method).ConfigureAwait(continueOnCapturedContext: false);
				await WriteByteAsync(32).ConfigureAwait(continueOnCapturedContext: false);
				if ((object)normalizedMethod == HttpMethod.Connect)
				{
					if (!request.HasHeaders || request.Headers.Host == null)
					{
						throw new HttpRequestException("CONNECT request must contain Host header.");
					}
					await WriteAsciiStringAsync(request.Headers.Host).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					if (Kind == HttpConnectionKind.Proxy)
					{
						await WriteBytesAsync(s_httpSchemeAndDelimiter).ConfigureAwait(continueOnCapturedContext: false);
						if (request.RequestUri.HostNameType != UriHostNameType.IPv6)
						{
							await WriteAsciiStringAsync(request.RequestUri.IdnHost).ConfigureAwait(continueOnCapturedContext: false);
						}
						else
						{
							await WriteByteAsync(91).ConfigureAwait(continueOnCapturedContext: false);
							await WriteAsciiStringAsync(request.RequestUri.IdnHost).ConfigureAwait(continueOnCapturedContext: false);
							await WriteByteAsync(93).ConfigureAwait(continueOnCapturedContext: false);
						}
						if (!request.RequestUri.IsDefaultPort)
						{
							await WriteByteAsync(58).ConfigureAwait(continueOnCapturedContext: false);
							await WriteDecimalInt32Async(request.RequestUri.Port).ConfigureAwait(continueOnCapturedContext: false);
						}
					}
					await WriteStringAsync(request.RequestUri.GetComponents(UriComponents.PathAndQuery | UriComponents.Fragment, UriFormat.UriEscaped)).ConfigureAwait(continueOnCapturedContext: false);
				}
				bool flag = request.Version.Minor == 0 && request.Version.Major == 1;
				await WriteBytesAsync(flag ? s_spaceHttp10NewlineAsciiBytes : s_spaceHttp11NewlineAsciiBytes).ConfigureAwait(continueOnCapturedContext: false);
				string text = null;
				if (_pool.Settings._useCookies)
				{
					text = _pool.Settings._cookieContainer.GetCookieHeader(request.RequestUri);
					if (text == "")
					{
						text = null;
					}
				}
				if (request.HasHeaders || text != null)
				{
					await WriteHeadersAsync(request.Headers, text).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (request.Content != null)
				{
					await WriteHeadersAsync(request.Content.Headers, null).ConfigureAwait(continueOnCapturedContext: false);
				}
				else if (normalizedMethod != HttpMethod.Get && normalizedMethod != HttpMethod.Head && normalizedMethod != HttpMethod.Connect)
				{
					await WriteBytesAsync(s_contentLength0NewlineAsciiBytes).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (!request.HasHeaders || request.Headers.Host == null)
				{
					await WriteHostHeaderAsync(request.RequestUri).ConfigureAwait(continueOnCapturedContext: false);
				}
				await WriteTwoBytesAsync(13, 10).ConfigureAwait(continueOnCapturedContext: false);
				if (request.Content == null)
				{
					await FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				else if (!hasExpectContinueHeader)
				{
					await SendRequestContentAsync(request, CreateRequestContentStream(request), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					await FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
					allowExpect100ToContinue = new TaskCompletionSource<bool>();
					Timer expect100Timer = new Timer(delegate(object s)
					{
						((TaskCompletionSource<bool>)s).TrySetResult(result: true);
					}, allowExpect100ToContinue, _pool.Settings._expect100ContinueTimeout, Timeout.InfiniteTimeSpan);
					sendRequestContentTask = SendRequestContentWithExpect100ContinueAsync(request, allowExpect100ToContinue.Task, CreateRequestContentStream(request), expect100Timer, cancellationToken);
				}
				_allowedReadLineBytes = MaxResponseHeadersLength;
				ValueTask<int>? valueTask = ConsumeReadAheadTask();
				if (valueTask.HasValue)
				{
					int num = await valueTask.GetValueOrDefault().ConfigureAwait(continueOnCapturedContext: false);
					if (NetEventSource.IsEnabled)
					{
						Trace($"Received {num} bytes.", "SendAsyncCore");
					}
					if (num == 0)
					{
						throw new IOException("The server returned an invalid or unrecognized response.");
					}
					_readOffset = 0;
					_readLength = num;
				}
				_canRetry = false;
				HttpResponseMessage response = new HttpResponseMessage
				{
					RequestMessage = request,
					Content = new HttpConnectionResponseContent()
				};
				ParseStatusLine(await ReadNextResponseHeaderLineAsync().ConfigureAwait(continueOnCapturedContext: false), response);
				if (hasExpectContinueHeader)
				{
					if (response.StatusCode >= HttpStatusCode.MultipleChoices && request.Content != null && (!request.Content.Headers.ContentLength.HasValue || request.Content.Headers.ContentLength.GetValueOrDefault() > 1024))
					{
						allowExpect100ToContinue.TrySetResult(result: false);
						if (!allowExpect100ToContinue.Task.Result)
						{
							_connectionClose = true;
						}
					}
					else
					{
						allowExpect100ToContinue?.TrySetResult(result: true);
						if (response.StatusCode == HttpStatusCode.Continue)
						{
							if (!LineIsEmpty(await ReadNextResponseHeaderLineAsync().ConfigureAwait(continueOnCapturedContext: false)))
							{
								ThrowInvalidHttpResponse();
							}
							ParseStatusLine(await ReadNextResponseHeaderLineAsync().ConfigureAwait(continueOnCapturedContext: false), response);
						}
					}
				}
				if (sendRequestContentTask != null)
				{
					Task task = sendRequestContentTask;
					sendRequestContentTask = null;
					await task.ConfigureAwait(continueOnCapturedContext: false);
				}
				while (true)
				{
					ArraySegment<byte> line = await ReadNextResponseHeaderLineAsync(foldedHeadersAllowed: true).ConfigureAwait(continueOnCapturedContext: false);
					if (LineIsEmpty(line))
					{
						break;
					}
					ParseHeaderNameValue(line, response);
				}
				if (response.Headers.ConnectionClose == true)
				{
					_connectionClose = true;
				}
				cancellationRegistration.Dispose();
				CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
				HttpContentStream stream;
				if ((object)normalizedMethod == HttpMethod.Head || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotModified)
				{
					stream = EmptyReadStream.Instance;
					CompleteResponse();
				}
				else if ((object)normalizedMethod == HttpMethod.Connect && response.StatusCode == HttpStatusCode.OK)
				{
					stream = new RawConnectionStream(this);
					_connectionClose = true;
				}
				else if (response.StatusCode == HttpStatusCode.SwitchingProtocols)
				{
					stream = new RawConnectionStream(this);
				}
				else if (!response.Content.Headers.ContentLength.HasValue)
				{
					stream = ((response.Headers.TransferEncodingChunked != true) ? ((HttpContentReadStream)new ConnectionCloseReadStream(this)) : ((HttpContentReadStream)new ChunkedEncodingReadStream(this)));
				}
				else
				{
					long valueOrDefault = response.Content.Headers.ContentLength.GetValueOrDefault();
					if (valueOrDefault <= 0)
					{
						stream = EmptyReadStream.Instance;
						CompleteResponse();
					}
					else
					{
						stream = new ContentLengthReadStream(this, (ulong)valueOrDefault);
					}
				}
				((HttpConnectionResponseContent)response.Content).SetStream(stream);
				if (NetEventSource.IsEnabled)
				{
					Trace($"Received response: {response}", "SendAsyncCore");
				}
				if (_pool.Settings._useCookies)
				{
					CookieHelper.ProcessReceivedCookies(response, _pool.Settings._cookieContainer);
				}
				return response;
			}
			catch (Exception ex)
			{
				cancellationRegistration.Dispose();
				allowExpect100ToContinue?.TrySetResult(result: false);
				if (NetEventSource.IsEnabled)
				{
					Trace($"Error sending request: {ex}", "SendAsyncCore");
				}
				if (sendRequestContentTask != null && !sendRequestContentTask.IsCompletedSuccessfully)
				{
					LogExceptionsAsync(sendRequestContentTask);
				}
				Dispose();
				if (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
				{
					throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
				}
				if (ex is InvalidOperationException || ex is IOException)
				{
					throw new HttpRequestException("An error occurred while sending the request.", ex);
				}
				throw;
			}
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return SendAsyncCore(request, cancellationToken);
		}

		private HttpContentWriteStream CreateRequestContentStream(HttpRequestMessage request)
		{
			if (!request.HasHeaders || request.Headers.TransferEncodingChunked != true)
			{
				return new ContentLengthWriteStream(this);
			}
			return new ChunkedEncodingWriteStream(this);
		}

		private CancellationTokenRegistration RegisterCancellation(CancellationToken cancellationToken)
		{
			return cancellationToken.Register(delegate(object s)
			{
				if (((WeakReference<HttpConnection>)s).TryGetTarget(out var target))
				{
					if (NetEventSource.IsEnabled)
					{
						target.Trace("Cancellation requested. Disposing of the connection.", "RegisterCancellation");
					}
					target.Dispose();
				}
			}, _weakThisRef);
		}

		private static bool LineIsEmpty(ArraySegment<byte> line)
		{
			return line.Count == 0;
		}

		private async Task SendRequestContentAsync(HttpRequestMessage request, HttpContentWriteStream stream, CancellationToken cancellationToken)
		{
			_canRetry = false;
			await request.Content.CopyToAsync(stream, _transportContext, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await stream.FinishAsync().ConfigureAwait(continueOnCapturedContext: false);
			await FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task SendRequestContentWithExpect100ContinueAsync(HttpRequestMessage request, Task<bool> allowExpect100ToContinueTask, HttpContentWriteStream stream, Timer expect100Timer, CancellationToken cancellationToken)
		{
			bool num = await allowExpect100ToContinueTask.ConfigureAwait(continueOnCapturedContext: false);
			expect100Timer.Dispose();
			if (num)
			{
				if (NetEventSource.IsEnabled)
				{
					Trace("Sending request content for Expect: 100-continue.", "SendRequestContentWithExpect100ContinueAsync");
				}
				await SendRequestContentAsync(request, stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			else if (NetEventSource.IsEnabled)
			{
				Trace("Canceling request content for Expect: 100-continue.", "SendRequestContentWithExpect100ContinueAsync");
			}
		}

		private static void ParseStatusLine(ArraySegment<byte> line, HttpResponseMessage response)
		{
			ParseStatusLine((Span<byte>)line, response);
		}

		private static void ParseStatusLine(Span<byte> line, HttpResponseMessage response)
		{
			if (line.Length < 12 || line[8] != 32)
			{
				ThrowInvalidHttpResponse();
			}
			ulong num = BitConverter.ToUInt64(line);
			if (num == s_http11Bytes)
			{
				response.SetVersionWithoutValidation(HttpVersion.Version11);
			}
			else if (num == s_http10Bytes)
			{
				response.SetVersionWithoutValidation(HttpVersion.Version10);
			}
			else
			{
				byte b = line[7];
				if (IsDigit(b) && line.Slice(0, 7).SequenceEqual(s_http1DotBytes))
				{
					response.SetVersionWithoutValidation(new Version(1, b - 48));
				}
				else
				{
					ThrowInvalidHttpResponse();
				}
			}
			byte b2 = line[9];
			byte b3 = line[10];
			byte b4 = line[11];
			if (!IsDigit(b2) || !IsDigit(b3) || !IsDigit(b4))
			{
				ThrowInvalidHttpResponse();
			}
			response.SetStatusCodeWithoutValidation((HttpStatusCode)(100 * (b2 - 48) + 10 * (b3 - 48) + (b4 - 48)));
			if (line.Length == 12)
			{
				response.SetReasonPhraseWithoutValidation(string.Empty);
			}
			else if (line[12] == 32)
			{
				Span<byte> span = line.Slice(13);
				string text = HttpStatusDescription.Get(response.StatusCode);
				if (text == null || !EqualsOrdinal(text, span))
				{
					try
					{
						response.ReasonPhrase = HttpRuleParser.DefaultHttpEncoding.GetString(span);
						return;
					}
					catch (FormatException innerException)
					{
						ThrowInvalidHttpResponse(innerException);
						return;
					}
				}
				response.SetReasonPhraseWithoutValidation(text);
			}
			else
			{
				ThrowInvalidHttpResponse();
			}
		}

		private static void ParseHeaderNameValue(ArraySegment<byte> line, HttpResponseMessage response)
		{
			ParseHeaderNameValue((Span<byte>)line, response);
		}

		private static void ParseHeaderNameValue(Span<byte> line, HttpResponseMessage response)
		{
			int i = 0;
			while (line[i] != 58 && line[i] != 32)
			{
				i++;
				if (i == line.Length)
				{
					ThrowInvalidHttpResponse();
				}
			}
			if (i == 0)
			{
				ThrowInvalidHttpResponse();
			}
			if (!HeaderDescriptor.TryGet(line.Slice(0, i), out var descriptor))
			{
				ThrowInvalidHttpResponse();
			}
			while (line[i] == 32)
			{
				i++;
				if (i == line.Length)
				{
					ThrowInvalidHttpResponse();
				}
			}
			if (line[i++] != 58)
			{
				ThrowInvalidHttpResponse();
			}
			for (; i < line.Length && (line[i] == 32 || line[i] == 9); i++)
			{
			}
			string headerValue = descriptor.GetHeaderValue(line.Slice(i));
			if (descriptor.HeaderType == HttpHeaderType.Content)
			{
				response.Content.Headers.TryAddWithoutValidation(descriptor, headerValue);
			}
			else
			{
				response.Headers.TryAddWithoutValidation((descriptor.HeaderType == HttpHeaderType.Request) ? descriptor.AsCustomHeader() : descriptor, headerValue);
			}
		}

		private static bool IsDigit(byte c)
		{
			return (uint)(c - 48) <= 9u;
		}

		private void WriteToBuffer(ReadOnlyMemory<byte> source)
		{
			source.Span.CopyTo(new Span<byte>(_writeBuffer, _writeOffset, source.Length));
			_writeOffset += source.Length;
		}

		private async Task WriteAsync(ReadOnlyMemory<byte> source)
		{
			int num = _writeBuffer.Length - _writeOffset;
			if (source.Length <= num)
			{
				WriteToBuffer(source);
				return;
			}
			if (_writeOffset != 0)
			{
				WriteToBuffer(source.Slice(0, num));
				source = source.Slice(num);
				await FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			if (source.Length >= _writeBuffer.Length)
			{
				await WriteToStreamAsync(source).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				WriteToBuffer(source);
			}
		}

		private ValueTask WriteWithoutBufferingAsync(ReadOnlyMemory<byte> source)
		{
			if (_writeOffset == 0)
			{
				return WriteToStreamAsync(source);
			}
			int num = _writeBuffer.Length - _writeOffset;
			if (source.Length <= num)
			{
				WriteToBuffer(source);
				return FlushAsync();
			}
			return new ValueTask(FlushThenWriteWithoutBufferingAsync(source));
		}

		private async Task FlushThenWriteWithoutBufferingAsync(ReadOnlyMemory<byte> source)
		{
			await FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
			await WriteToStreamAsync(source).ConfigureAwait(continueOnCapturedContext: false);
		}

		private Task WriteByteAsync(byte b)
		{
			if (_writeOffset < _writeBuffer.Length)
			{
				_writeBuffer[_writeOffset++] = b;
				return Task.CompletedTask;
			}
			return WriteByteSlowAsync(b);
		}

		private async Task WriteByteSlowAsync(byte b)
		{
			await WriteToStreamAsync(_writeBuffer).ConfigureAwait(continueOnCapturedContext: false);
			_writeBuffer[0] = b;
			_writeOffset = 1;
		}

		private Task WriteTwoBytesAsync(byte b1, byte b2)
		{
			if (_writeOffset <= _writeBuffer.Length - 2)
			{
				byte[] writeBuffer = _writeBuffer;
				writeBuffer[_writeOffset++] = b1;
				writeBuffer[_writeOffset++] = b2;
				return Task.CompletedTask;
			}
			return WriteTwoBytesSlowAsync(b1, b2);
		}

		private async Task WriteTwoBytesSlowAsync(byte b1, byte b2)
		{
			await WriteByteAsync(b1).ConfigureAwait(continueOnCapturedContext: false);
			await WriteByteAsync(b2).ConfigureAwait(continueOnCapturedContext: false);
		}

		private Task WriteBytesAsync(byte[] bytes)
		{
			if (_writeOffset <= _writeBuffer.Length - bytes.Length)
			{
				Buffer.BlockCopy(bytes, 0, _writeBuffer, _writeOffset, bytes.Length);
				_writeOffset += bytes.Length;
				return Task.CompletedTask;
			}
			return WriteBytesSlowAsync(bytes);
		}

		private async Task WriteBytesSlowAsync(byte[] bytes)
		{
			int offset = 0;
			while (true)
			{
				int num = Math.Min(bytes.Length - offset, _writeBuffer.Length - _writeOffset);
				Buffer.BlockCopy(bytes, offset, _writeBuffer, _writeOffset, num);
				_writeOffset += num;
				offset += num;
				if (offset != bytes.Length)
				{
					if (_writeOffset == _writeBuffer.Length)
					{
						await WriteToStreamAsync(_writeBuffer).ConfigureAwait(continueOnCapturedContext: false);
						_writeOffset = 0;
					}
					continue;
				}
				break;
			}
		}

		private Task WriteStringAsync(string s)
		{
			int writeOffset = _writeOffset;
			if (s.Length <= _writeBuffer.Length - writeOffset)
			{
				byte[] writeBuffer = _writeBuffer;
				foreach (char c in s)
				{
					if ((c & 0xFF80) != 0)
					{
						throw new HttpRequestException("Request headers must contain only ASCII characters.");
					}
					writeBuffer[writeOffset++] = (byte)c;
				}
				_writeOffset = writeOffset;
				return Task.CompletedTask;
			}
			return WriteStringAsyncSlow(s);
		}

		private Task WriteAsciiStringAsync(string s)
		{
			int writeOffset = _writeOffset;
			if (s.Length <= _writeBuffer.Length - writeOffset)
			{
				byte[] writeBuffer = _writeBuffer;
				foreach (char c in s)
				{
					writeBuffer[writeOffset++] = (byte)c;
				}
				_writeOffset = writeOffset;
				return Task.CompletedTask;
			}
			return WriteStringAsyncSlow(s);
		}

		private async Task WriteStringAsyncSlow(string s)
		{
			foreach (char c in s)
			{
				if ((c & 0xFF80) != 0)
				{
					throw new HttpRequestException("Request headers must contain only ASCII characters.");
				}
				await WriteByteAsync((byte)c).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private ValueTask FlushAsync()
		{
			if (_writeOffset > 0)
			{
				ValueTask result = WriteToStreamAsync(new ReadOnlyMemory<byte>(_writeBuffer, 0, _writeOffset));
				_writeOffset = 0;
				return result;
			}
			return default(ValueTask);
		}

		private ValueTask WriteToStreamAsync(ReadOnlyMemory<byte> source)
		{
			if (NetEventSource.IsEnabled)
			{
				Trace($"Writing {source.Length} bytes.", "WriteToStreamAsync");
			}
			return _stream.WriteAsync(source);
		}

		private bool TryReadNextLine(out ReadOnlySpan<byte> line)
		{
			ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(_readBuffer, _readOffset, _readLength - _readOffset);
			int num = span.IndexOf((byte)10);
			if (num < 0)
			{
				if (_allowedReadLineBytes < span.Length)
				{
					ThrowInvalidHttpResponse();
				}
				line = default(ReadOnlySpan<byte>);
				return false;
			}
			int num2 = num + 1;
			_readOffset += num2;
			_allowedReadLineBytes -= num2;
			ThrowIfExceededAllowedReadLineBytes();
			line = span.Slice(0, (num > 0 && span[num - 1] == 13) ? (num - 1) : num);
			return true;
		}

		private async ValueTask<ArraySegment<byte>> ReadNextResponseHeaderLineAsync(bool foldedHeadersAllowed = false)
		{
			int previouslyScannedBytes = 0;
			int num;
			int num2;
			int readOffset;
			int num3;
			while (true)
			{
				num = _readOffset + previouslyScannedBytes;
				num2 = Array.IndexOf(_readBuffer, (byte)10, num, _readLength - num);
				if (num2 >= 0)
				{
					readOffset = _readOffset;
					num3 = num2 - readOffset;
					if (num2 > 0 && _readBuffer[num2 - 1] == 13)
					{
						num3--;
					}
					if (!foldedHeadersAllowed || num3 <= 0)
					{
						break;
					}
					if (num2 + 1 == _readLength)
					{
						int num4 = ((_readBuffer[num2 - 1] == 13) ? (num2 - 2) : (num2 - 1));
						previouslyScannedBytes = num4 - _readOffset;
						_allowedReadLineBytes -= num4 - num;
						ThrowIfExceededAllowedReadLineBytes();
						await FillAsync().ConfigureAwait(continueOnCapturedContext: false);
						continue;
					}
					char c = (char)_readBuffer[num2 + 1];
					if (c != ' ' && c != '\t')
					{
						break;
					}
					if (Array.IndexOf(_readBuffer, (byte)58, _readOffset, num2 - _readOffset) == -1)
					{
						ThrowInvalidHttpResponse();
					}
					_readBuffer[num2] = 32;
					if (_readBuffer[num2 - 1] == 13)
					{
						_readBuffer[num2 - 1] = 32;
					}
					previouslyScannedBytes = num2 + 1 - _readOffset;
					_allowedReadLineBytes -= num2 + 1 - num;
					ThrowIfExceededAllowedReadLineBytes();
				}
				else
				{
					previouslyScannedBytes = _readLength - _readOffset;
					_allowedReadLineBytes -= _readLength - num;
					ThrowIfExceededAllowedReadLineBytes();
					await FillAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			_allowedReadLineBytes -= num2 + 1 - num;
			ThrowIfExceededAllowedReadLineBytes();
			_readOffset = num2 + 1;
			return new ArraySegment<byte>(_readBuffer, readOffset, num3);
		}

		private void ThrowIfExceededAllowedReadLineBytes()
		{
			if (_allowedReadLineBytes < 0)
			{
				ThrowInvalidHttpResponse();
			}
		}

		private async Task FillAsync()
		{
			int num = _readLength - _readOffset;
			if (num == 0)
			{
				_readOffset = (_readLength = 0);
			}
			else if (_readOffset > 0)
			{
				Buffer.BlockCopy(_readBuffer, _readOffset, _readBuffer, 0, num);
				_readOffset = 0;
				_readLength = num;
			}
			else if (num == _readBuffer.Length)
			{
				byte[] array = new byte[_readBuffer.Length * 2];
				Buffer.BlockCopy(_readBuffer, 0, array, 0, num);
				_readBuffer = array;
				_readOffset = 0;
				_readLength = num;
			}
			int num2 = await _stream.ReadAsync(new Memory<byte>(_readBuffer, _readLength, _readBuffer.Length - _readLength)).ConfigureAwait(continueOnCapturedContext: false);
			if (NetEventSource.IsEnabled)
			{
				Trace($"Received {num2} bytes.", "FillAsync");
			}
			if (num2 == 0)
			{
				throw new IOException("The server returned an invalid or unrecognized response.");
			}
			_readLength += num2;
		}

		private void ReadFromBuffer(Span<byte> buffer)
		{
			new Span<byte>(_readBuffer, _readOffset, buffer.Length).CopyTo(buffer);
			_readOffset += buffer.Length;
		}

		private async ValueTask<int> ReadAsync(Memory<byte> destination)
		{
			int num = _readLength - _readOffset;
			if (num > 0)
			{
				if (destination.Length <= num)
				{
					ReadFromBuffer(destination.Span);
					return destination.Length;
				}
				ReadFromBuffer(destination.Span.Slice(0, num));
				return num;
			}
			int num2 = await _stream.ReadAsync(destination).ConfigureAwait(continueOnCapturedContext: false);
			if (NetEventSource.IsEnabled)
			{
				Trace($"Received {num2} bytes.", "ReadAsync");
			}
			return num2;
		}

		private ValueTask<int> ReadBufferedAsync(Memory<byte> destination)
		{
			if (destination.Length < _readBuffer.Length)
			{
				return ReadBufferedAsyncCore(destination);
			}
			return ReadAsync(destination);
		}

		private async ValueTask<int> ReadBufferedAsyncCore(Memory<byte> destination)
		{
			int num = _readLength - _readOffset;
			if (num > 0)
			{
				if (destination.Length <= num)
				{
					ReadFromBuffer(destination.Span);
					return destination.Length;
				}
				ReadFromBuffer(destination.Span.Slice(0, num));
				return num;
			}
			_readOffset = (_readLength = 0);
			int num2 = await _stream.ReadAsync(_readBuffer.AsMemory()).ConfigureAwait(continueOnCapturedContext: false);
			if (NetEventSource.IsEnabled)
			{
				Trace($"Received {num2} bytes.", "ReadBufferedAsyncCore");
			}
			_readLength = num2;
			int num3 = Math.Min(num2, destination.Length);
			_readBuffer.AsSpan(0, num3).CopyTo(destination.Span);
			_readOffset = num3;
			return num3;
		}

		private async Task CopyFromBufferAsync(Stream destination, int count, CancellationToken cancellationToken)
		{
			if (NetEventSource.IsEnabled)
			{
				Trace($"Copying {count} bytes to stream.", "CopyFromBufferAsync");
			}
			await destination.WriteAsync(new ReadOnlyMemory<byte>(_readBuffer, _readOffset, count), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			_readOffset += count;
		}

		private Task CopyToUntilEofAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
		{
			if (_readLength - _readOffset <= 0)
			{
				return _stream.CopyToAsync(destination, bufferSize, cancellationToken);
			}
			return CopyToUntilEofWithExistingBufferedDataAsync(destination, cancellationToken);
		}

		private async Task CopyToUntilEofWithExistingBufferedDataAsync(Stream destination, CancellationToken cancellationToken)
		{
			int count = _readLength - _readOffset;
			await CopyFromBufferAsync(destination, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			_readLength = (_readOffset = 0);
			await _stream.CopyToAsync(destination).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task CopyToExactLengthAsync(Stream destination, ulong length, CancellationToken cancellationToken)
		{
			int remaining = _readLength - _readOffset;
			if (remaining > 0)
			{
				if ((ulong)remaining > length)
				{
					remaining = (int)length;
				}
				await CopyFromBufferAsync(destination, remaining, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				length -= (ulong)remaining;
				if (length == 0L)
				{
					return;
				}
			}
			do
			{
				await FillAsync().ConfigureAwait(continueOnCapturedContext: false);
				remaining = (((ulong)_readLength < length) ? _readLength : ((int)length));
				await CopyFromBufferAsync(destination, remaining, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				length -= (ulong)remaining;
			}
			while (length != 0L);
		}

		public void Acquire()
		{
			_inUse = true;
		}

		public void Release()
		{
			_inUse = false;
			if (_currentRequest == null)
			{
				ReturnConnectionToPool();
			}
		}

		private void CompleteResponse()
		{
			_currentRequest = null;
			if (RemainingBuffer.Length != 0)
			{
				if (NetEventSource.IsEnabled)
				{
					Trace("Unexpected data on connection after response read.", "CompleteResponse");
				}
				ConsumeFromRemainingBuffer(RemainingBuffer.Length);
				_connectionClose = true;
			}
			if (!_inUse)
			{
				ReturnConnectionToPool();
			}
		}

		public async Task DrainResponseAsync(HttpResponseMessage response)
		{
			if (_connectionClose)
			{
				throw new HttpRequestException("Authentication failed because the connection could not be reused.");
			}
			HttpContentReadStream httpContentReadStream = (HttpContentReadStream)(await response.Content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false));
			if (httpContentReadStream.NeedsDrain && (!(await httpContentReadStream.DrainAsync(_pool.Settings._maxResponseDrainSize).ConfigureAwait(continueOnCapturedContext: false)) || _connectionClose))
			{
				throw new HttpRequestException("Authentication failed because the connection could not be reused.");
			}
			response.Dispose();
		}

		private void ReturnConnectionToPool()
		{
			if (_connectionClose)
			{
				if (NetEventSource.IsEnabled)
				{
					Trace("Connection will not be reused.", "ReturnConnectionToPool");
				}
				Dispose();
			}
			else
			{
				_pool.ReturnConnection(this);
			}
		}

		private static bool EqualsOrdinal(string left, Span<byte> right)
		{
			if (left.Length != right.Length)
			{
				return false;
			}
			for (int i = 0; i < left.Length; i++)
			{
				if (left[i] != right[i])
				{
					return false;
				}
			}
			return true;
		}

		public sealed override string ToString()
		{
			return string.Format("{0}({1})", "HttpConnection", _pool);
		}

		private static void ThrowInvalidHttpResponse()
		{
			throw new HttpRequestException("The server returned an invalid or unrecognized response.");
		}

		private static void ThrowInvalidHttpResponse(Exception innerException)
		{
			throw new HttpRequestException("The server returned an invalid or unrecognized response.", innerException);
		}

		internal void Trace(string message, [CallerMemberName] string memberName = null)
		{
			NetEventSource.Log.HandlerMessage(_pool?.GetHashCode() ?? 0, GetHashCode(), _currentRequest?.GetHashCode() ?? 0, memberName, ToString() + ": " + message);
		}
	}
	internal static class ConnectHelper
	{
		internal sealed class CertificateCallbackMapper
		{
			public readonly Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> FromHttpClientHandler;
		}

		private sealed class ConnectEventArgs : SocketAsyncEventArgs
		{
			public AsyncTaskMethodBuilder Builder { get; private set; }

			public CancellationToken CancellationToken { get; private set; }

			public void Initialize(CancellationToken cancellationToken)
			{
				CancellationToken = cancellationToken;
				AsyncTaskMethodBuilder builder = default(AsyncTaskMethodBuilder);
				_ = builder.Task;
				Builder = builder;
			}

			public void Clear()
			{
				CancellationToken = default(CancellationToken);
			}

			protected override void OnCompleted(SocketAsyncEventArgs _)
			{
				switch (base.SocketError)
				{
				case SocketError.Success:
					Builder.SetResult();
					return;
				case SocketError.OperationAborted:
				case SocketError.ConnectionAborted:
					if (CancellationToken.IsCancellationRequested)
					{
						Builder.SetException(CancellationHelper.CreateOperationCanceledException(null, CancellationToken));
						return;
					}
					break;
				}
				Builder.SetException(new SocketException((int)base.SocketError));
			}
		}

		private static readonly ConcurrentQueue<ConnectEventArgs>.Segment s_connectEventArgs = new ConcurrentQueue<ConnectEventArgs>.Segment(ConcurrentQueue<ConnectEventArgs>.Segment.RoundUpToPowerOf2(Math.Max(2, Environment.ProcessorCount)));

		public static async ValueTask<(Socket, Stream)> ConnectAsync(string host, int port, CancellationToken cancellationToken)
		{
			if (!s_connectEventArgs.TryDequeue(out var saea))
			{
				saea = new ConnectEventArgs();
			}
			try
			{
				saea.Initialize(cancellationToken);
				saea.RemoteEndPoint = new DnsEndPoint(host, port);
				if (Socket.ConnectAsync(SocketType.Stream, ProtocolType.Tcp, saea))
				{
					using (cancellationToken.Register(delegate(object s)
					{
						Socket.CancelConnectAsync((SocketAsyncEventArgs)s);
					}, saea))
					{
						await saea.Builder.Task.ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				else if (saea.SocketError != SocketError.Success)
				{
					throw new SocketException((int)saea.SocketError);
				}
				Socket connectSocket = saea.ConnectSocket;
				connectSocket.NoDelay = true;
				return (connectSocket, new NetworkStream(connectSocket, ownsSocket: true));
			}
			catch (Exception ex)
			{
				throw CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken) ? CancellationHelper.CreateOperationCanceledException(ex, cancellationToken) : new HttpRequestException(ex.Message, ex);
			}
			finally
			{
				saea.Clear();
				if (!s_connectEventArgs.TryEnqueue(saea))
				{
					saea.Dispose();
				}
			}
		}

		public static ValueTask<SslStream> EstablishSslConnectionAsync(SslClientAuthenticationOptions sslOptions, HttpRequestMessage request, Stream stream, CancellationToken cancellationToken)
		{
			RemoteCertificateValidationCallback remoteCertificateValidationCallback = sslOptions.RemoteCertificateValidationCallback;
			if (remoteCertificateValidationCallback != null && remoteCertificateValidationCallback.Target is CertificateCallbackMapper certificateCallbackMapper)
			{
				sslOptions = sslOptions.ShallowClone();
				Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> localFromHttpClientHandler = certificateCallbackMapper.FromHttpClientHandler;
				HttpRequestMessage localRequest = request;
				sslOptions.RemoteCertificateValidationCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => localFromHttpClientHandler(localRequest, certificate as X509Certificate2, chain, sslPolicyErrors);
			}
			return EstablishSslConnectionAsyncCore(stream, sslOptions, cancellationToken);
		}

		private static async ValueTask<SslStream> EstablishSslConnectionAsyncCore(Stream stream, SslClientAuthenticationOptions sslOptions, CancellationToken cancellationToken)
		{
			SslStream sslStream = new SslStream(stream);
			CancellationTokenRegistration ctr = cancellationToken.Register(delegate(object s)
			{
				((Stream)s).Dispose();
			}, stream);
			try
			{
				await sslStream.AuthenticateAsClientAsync(sslOptions, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				sslStream.Dispose();
				if (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
				{
					throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
				}
				throw new HttpRequestException("The SSL connection could not be established, see inner exception.", ex);
			}
			finally
			{
				ctr.Dispose();
			}
			if (cancellationToken.IsCancellationRequested)
			{
				sslStream.Dispose();
				throw CancellationHelper.CreateOperationCanceledException(null, cancellationToken);
			}
			return sslStream;
		}
	}
	internal static class CookieHelper
	{
		public static void ProcessReceivedCookies(HttpResponseMessage response, CookieContainer cookieContainer)
		{
			if (!response.Headers.TryGetValues(KnownHeaders.SetCookie.Descriptor, out var values))
			{
				return;
			}
			string[] array = (string[])values;
			Uri requestUri = response.RequestMessage.RequestUri;
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					cookieContainer.SetCookies(requestUri, array[i]);
				}
				catch (CookieException)
				{
					if (NetEventSource.IsEnabled)
					{
						NetEventSource.Error(response, "Invalid Set-Cookie '" + array[i] + "' ignored.");
					}
				}
			}
		}
	}
	internal sealed class DecompressionHandler : HttpMessageHandler
	{
		private abstract class DecompressedContent : HttpContent
		{
			private HttpContent _originalContent;

			private bool _contentConsumed;

			public DecompressedContent(HttpContent originalContent)
			{
				_originalContent = originalContent;
				_contentConsumed = false;
				base.Headers.AddHeaders(originalContent.Headers);
				base.Headers.ContentLength = null;
				base.Headers.ContentEncoding.Clear();
				string text = null;
				foreach (string item in originalContent.Headers.ContentEncoding)
				{
					if (text != null)
					{
						base.Headers.ContentEncoding.Add(text);
					}
					text = item;
				}
			}

			protected abstract Stream GetDecompressedStream(Stream originalStream);

			protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
			{
				return SerializeToStreamAsync(stream, context, CancellationToken.None);
			}

			internal override async Task SerializeToStreamAsync(Stream stream, TransportContext context, CancellationToken cancellationToken)
			{
				using Stream decompressedStream = await CreateContentReadStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
				await decompressedStream.CopyToAsync(stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}

			protected override async Task<Stream> CreateContentReadStreamAsync()
			{
				if (_contentConsumed)
				{
					throw new InvalidOperationException("The stream was already consumed. It cannot be read again.");
				}
				_contentConsumed = true;
				Stream stream = _originalContent.TryReadAsStream();
				if (stream == null)
				{
					stream = await _originalContent.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				Stream originalStream = stream;
				return GetDecompressedStream(originalStream);
			}

			protected internal override bool TryComputeLength(out long length)
			{
				length = 0L;
				return false;
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					_originalContent.Dispose();
				}
				base.Dispose(disposing);
			}
		}

		private sealed class GZipDecompressedContent : DecompressedContent
		{
			public GZipDecompressedContent(HttpContent originalContent)
				: base(originalContent)
			{
			}

			protected override Stream GetDecompressedStream(Stream originalStream)
			{
				return new GZipStream(originalStream, CompressionMode.Decompress);
			}
		}

		private sealed class DeflateDecompressedContent : DecompressedContent
		{
			public DeflateDecompressedContent(HttpContent originalContent)
				: base(originalContent)
			{
			}

			protected override Stream GetDecompressedStream(Stream originalStream)
			{
				return new DeflateStream(originalStream, CompressionMode.Decompress);
			}
		}

		private readonly HttpMessageHandler _innerHandler;

		private readonly DecompressionMethods _decompressionMethods;

		private static readonly StringWithQualityHeaderValue s_gzipHeaderValue = new StringWithQualityHeaderValue("gzip");

		private static readonly StringWithQualityHeaderValue s_deflateHeaderValue = new StringWithQualityHeaderValue("deflate");

		internal bool GZipEnabled => (_decompressionMethods & DecompressionMethods.GZip) != 0;

		internal bool DeflateEnabled => (_decompressionMethods & DecompressionMethods.Deflate) != 0;

		public DecompressionHandler(DecompressionMethods decompressionMethods, HttpMessageHandler innerHandler)
		{
			_decompressionMethods = decompressionMethods;
			_innerHandler = innerHandler;
		}

		protected internal override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (GZipEnabled)
			{
				request.Headers.AcceptEncoding.Add(s_gzipHeaderValue);
			}
			if (DeflateEnabled)
			{
				request.Headers.AcceptEncoding.Add(s_deflateHeaderValue);
			}
			HttpResponseMessage httpResponseMessage = await _innerHandler.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			ICollection<string> contentEncoding = httpResponseMessage.Content.Headers.ContentEncoding;
			if (contentEncoding.Count > 0)
			{
				string text = null;
				foreach (string item in contentEncoding)
				{
					text = item;
				}
				if (GZipEnabled && text == "gzip")
				{
					httpResponseMessage.Content = new GZipDecompressedContent(httpResponseMessage.Content);
				}
				else if (DeflateEnabled && text == "deflate")
				{
					httpResponseMessage.Content = new DeflateDecompressedContent(httpResponseMessage.Content);
				}
			}
			return httpResponseMessage;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_innerHandler.Dispose();
			}
			base.Dispose(disposing);
		}
	}
	internal sealed class HttpAuthenticatedConnectionHandler : HttpMessageHandler
	{
		private readonly HttpConnectionPoolManager _poolManager;

		public HttpAuthenticatedConnectionHandler(HttpConnectionPoolManager poolManager)
		{
			_poolManager = poolManager;
		}

		protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return _poolManager.SendAsync(request, doRequestAuth: true, cancellationToken);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_poolManager.Dispose();
			}
			base.Dispose(disposing);
		}
	}
	internal sealed class HttpConnectionWithFinalizer : HttpConnection
	{
		public HttpConnectionWithFinalizer(HttpConnectionPool pool, Socket socket, Stream stream, TransportContext transportContext)
			: base(pool, socket, stream, transportContext)
		{
		}

		~HttpConnectionWithFinalizer()
		{
			Dispose(disposing: false);
		}
	}
	internal sealed class HttpConnectionHandler : HttpMessageHandler
	{
		private readonly HttpConnectionPoolManager _poolManager;

		public HttpConnectionHandler(HttpConnectionPoolManager poolManager)
		{
			_poolManager = poolManager;
		}

		protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return _poolManager.SendAsync(request, doRequestAuth: false, cancellationToken);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_poolManager.Dispose();
			}
			base.Dispose(disposing);
		}
	}
	internal enum HttpConnectionKind : byte
	{
		Http,
		Https,
		Proxy,
		ProxyTunnel,
		SslProxyTunnel,
		ProxyConnect
	}
	internal sealed class HttpConnectionPool : IDisposable
	{
		[StructLayout(LayoutKind.Auto)]
		private readonly struct CachedConnection(HttpConnection connection) : IEquatable<CachedConnection>
		{
			internal readonly HttpConnection _connection = connection;

			internal readonly DateTimeOffset _returnedTime = DateTimeOffset.UtcNow;

			public bool IsUsable(DateTimeOffset now, TimeSpan pooledConnectionLifetime, TimeSpan pooledConnectionIdleTimeout, bool poll = false)
			{
				if (pooledConnectionIdleTimeout != Timeout.InfiniteTimeSpan && now - _returnedTime > pooledConnectionIdleTimeout)
				{
					if (NetEventSource.IsEnabled)
					{
						_connection.Trace($"Connection no longer usable. Idle {now - _returnedTime} > {pooledConnectionIdleTimeout}.", "IsUsable");
					}
					return false;
				}
				if (pooledConnectionLifetime != Timeout.InfiniteTimeSpan && now - _connection.CreationTime > pooledConnectionLifetime)
				{
					if (NetEventSource.IsEnabled)
					{
						_connection.Trace($"Connection no longer usable. Alive {now - _connection.CreationTime} > {pooledConnectionLifetime}.", "IsUsable");
					}
					return false;
				}
				if (poll && _connection.PollRead())
				{
					if (NetEventSource.IsEnabled)
					{
						_connection.Trace("Connection no longer usable. Unexpected data received.", "IsUsable");
					}
					return false;
				}
				return true;
			}

			public bool Equals(CachedConnection other)
			{
				return other._connection == _connection;
			}

			public override bool Equals(object obj)
			{
				if (obj is CachedConnection)
				{
					return Equals((CachedConnection)obj);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return _connection?.GetHashCode() ?? 0;
			}
		}

		private class ConnectionWaiter : TaskCompletionSource<(HttpConnection, HttpResponseMessage)>
		{
			internal readonly HttpConnectionPool _pool;

			private readonly HttpRequestMessage _request;

			internal readonly CancellationToken _cancellationToken;

			internal CancellationTokenRegistration _cancellationTokenRegistration;

			internal ConnectionWaiter _next;

			internal ConnectionWaiter _prev;

			public ConnectionWaiter(HttpConnectionPool pool, HttpRequestMessage request, CancellationToken cancellationToken)
				: base(TaskCreationOptions.RunContinuationsAsynchronously)
			{
				_pool = pool;
				_request = request;
				_cancellationToken = cancellationToken;
			}

			public ValueTask<(HttpConnection, HttpResponseMessage)> CreateConnectionAsync()
			{
				return _pool.CreateConnectionAsync(_request, _cancellationToken);
			}
		}

		private static readonly bool s_isWindows7Or2008R2 = GetIsWindows7Or2008R2();

		private readonly HttpConnectionPoolManager _poolManager;

		private readonly HttpConnectionKind _kind;

		private readonly string _host;

		private readonly int _port;

		private readonly Uri _proxyUri;

		private readonly List<CachedConnection> _idleConnections = new List<CachedConnection>();

		private readonly int _maxConnections;

		private readonly byte[] _hostHeaderValueBytes;

		private readonly SslClientAuthenticationOptions _sslOptions;

		private ConnectionWaiter _waitersHead;

		private ConnectionWaiter _waitersTail;

		private int _associatedConnectionCount;

		private bool _usedSinceLastCleanup = true;

		private bool _disposed;

		public HttpConnectionSettings Settings => _poolManager.Settings;

		public bool IsSecure => _sslOptions != null;

		public HttpConnectionKind Kind => _kind;

		public bool AnyProxyKind => _proxyUri != null;

		public Uri ProxyUri => _proxyUri;

		public ICredentials ProxyCredentials => _poolManager.ProxyCredentials;

		public byte[] HostHeaderValueBytes => _hostHeaderValueBytes;

		public CredentialCache PreAuthCredentials { get; }

		private object SyncObj => _idleConnections;

		public HttpConnectionPool(HttpConnectionPoolManager poolManager, HttpConnectionKind kind, string host, int port, string sslHostName, Uri proxyUri, int maxConnections)
		{
			_poolManager = poolManager;
			_kind = kind;
			_host = host;
			_port = port;
			_proxyUri = proxyUri;
			_maxConnections = maxConnections;
			switch (kind)
			{
			case HttpConnectionKind.Https:
				_sslOptions = ConstructSslOptions(poolManager, sslHostName);
				break;
			case HttpConnectionKind.SslProxyTunnel:
				_sslOptions = ConstructSslOptions(poolManager, sslHostName);
				break;
			}
			if (_host != null)
			{
				string s = ((_port != ((_sslOptions == null) ? 80 : 443)) ? $"{_host}:{_port}" : _host);
				_hostHeaderValueBytes = Encoding.ASCII.GetBytes(s);
			}
			if (_poolManager.Settings._preAuthenticate)
			{
				PreAuthCredentials = new CredentialCache();
			}
		}

		private static SslClientAuthenticationOptions ConstructSslOptions(HttpConnectionPoolManager poolManager, string sslHostName)
		{
			SslClientAuthenticationOptions sslClientAuthenticationOptions = poolManager.Settings._sslOptions?.ShallowClone() ?? new SslClientAuthenticationOptions();
			sslClientAuthenticationOptions.ApplicationProtocols = null;
			sslClientAuthenticationOptions.TargetHost = sslHostName;
			if (s_isWindows7Or2008R2 && sslClientAuthenticationOptions.EnabledSslProtocols == SslProtocols.None)
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Info(poolManager, $"Win7OrWin2K8R2 platform, Changing default TLS protocols to {SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12}");
				}
				sslClientAuthenticationOptions.EnabledSslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12;
			}
			return sslClientAuthenticationOptions;
		}

		private ValueTask<(HttpConnection, HttpResponseMessage)> GetConnectionAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return new ValueTask<(HttpConnection, HttpResponseMessage)>(Task.FromCanceled<(HttpConnection, HttpResponseMessage)>(cancellationToken));
			}
			TimeSpan pooledConnectionLifetime = _poolManager.Settings._pooledConnectionLifetime;
			TimeSpan pooledConnectionIdleTimeout = _poolManager.Settings._pooledConnectionIdleTimeout;
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			List<CachedConnection> idleConnections = _idleConnections;
			HttpConnection connection;
			while (true)
			{
				CachedConnection cachedConnection;
				lock (SyncObj)
				{
					if (idleConnections.Count <= 0)
					{
						if (_associatedConnectionCount < _maxConnections)
						{
							if (NetEventSource.IsEnabled)
							{
								Trace("Creating new connection for pool.", "GetConnectionAsync");
							}
							IncrementConnectionCountNoLock();
							return WaitForCreatedConnectionAsync(CreateConnectionAsync(request, cancellationToken));
						}
						if (NetEventSource.IsEnabled)
						{
							Trace("Limit reached.  Waiting to create new connection.", "GetConnectionAsync");
						}
						ConnectionWaiter connectionWaiter = new ConnectionWaiter(this, request, cancellationToken);
						EnqueueWaiter(connectionWaiter);
						if (cancellationToken.CanBeCanceled)
						{
							connectionWaiter._cancellationTokenRegistration = cancellationToken.Register(delegate(object s)
							{
								ConnectionWaiter connectionWaiter2 = (ConnectionWaiter)s;
								lock (connectionWaiter2._pool.SyncObj)
								{
									if (connectionWaiter2._pool.RemoveWaiterForCancellation(connectionWaiter2))
									{
										connectionWaiter2.TrySetCanceled(connectionWaiter2._cancellationToken);
									}
								}
							}, connectionWaiter);
						}
						return new ValueTask<(HttpConnection, HttpResponseMessage)>(connectionWaiter.Task);
					}
					cachedConnection = idleConnections[idleConnections.Count - 1];
					idleConnections.RemoveAt(idleConnections.Count - 1);
				}
				connection = cachedConnection._connection;
				if (cachedConnection.IsUsable(utcNow, pooledConnectionLifetime, pooledConnectionIdleTimeout) && !connection.EnsureReadAheadAndPollRead())
				{
					break;
				}
				if (NetEventSource.IsEnabled)
				{
					connection.Trace("Found invalid connection in pool.", "GetConnectionAsync");
				}
				connection.Dispose();
			}
			if (NetEventSource.IsEnabled)
			{
				connection.Trace("Found usable connection in pool.", "GetConnectionAsync");
			}
			return new ValueTask<(HttpConnection, HttpResponseMessage)>((connection, null));
		}

		public async Task<HttpResponseMessage> SendWithRetryAsync(HttpRequestMessage request, bool doRequestAuth, CancellationToken cancellationToken)
		{
			HttpResponseMessage httpResponseMessage;
			while (true)
			{
				HttpConnection connection;
				(connection, httpResponseMessage) = await GetConnectionAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (httpResponseMessage != null)
				{
					break;
				}
				bool isNewConnection = connection.IsNewConnection;
				connection.Acquire();
				try
				{
					return await SendWithNtConnectionAuthAsync(connection, request, doRequestAuth, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (HttpRequestException ex) when (!isNewConnection && ex.InnerException is IOException && connection.CanRetry)
				{
				}
				finally
				{
					connection.Release();
				}
			}
			return httpResponseMessage;
		}

		private async Task<HttpResponseMessage> SendWithNtConnectionAuthAsync(HttpConnection connection, HttpRequestMessage request, bool doRequestAuth, CancellationToken cancellationToken)
		{
			if (doRequestAuth && Settings._credentials != null)
			{
				return await AuthenticationHelper.SendWithNtConnectionAuthAsync(request, Settings._credentials, connection, this, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			return await SendWithNtProxyAuthAsync(connection, request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public Task<HttpResponseMessage> SendWithNtProxyAuthAsync(HttpConnection connection, HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (AnyProxyKind && ProxyCredentials != null)
			{
				return AuthenticationHelper.SendWithNtProxyAuthAsync(request, ProxyUri, ProxyCredentials, connection, this, cancellationToken);
			}
			return connection.SendAsync(request, cancellationToken);
		}

		public Task<HttpResponseMessage> SendWithProxyAuthAsync(HttpRequestMessage request, bool doRequestAuth, CancellationToken cancellationToken)
		{
			if ((_kind == HttpConnectionKind.Proxy || _kind == HttpConnectionKind.ProxyConnect) && _poolManager.ProxyCredentials != null)
			{
				return AuthenticationHelper.SendWithProxyAuthAsync(request, _proxyUri, _poolManager.ProxyCredentials, doRequestAuth, this, cancellationToken);
			}
			return SendWithRetryAsync(request, doRequestAuth, cancellationToken);
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, bool doRequestAuth, CancellationToken cancellationToken)
		{
			if (doRequestAuth && Settings._credentials != null)
			{
				return AuthenticationHelper.SendWithRequestAuthAsync(request, Settings._credentials, Settings._preAuthenticate, this, cancellationToken);
			}
			return SendWithProxyAuthAsync(request, doRequestAuth, cancellationToken);
		}

		internal async ValueTask<(HttpConnection, HttpResponseMessage)> CreateConnectionAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			CancellationTokenSource cancellationWithConnectTimeout = null;
			if (Settings._connectTimeout != Timeout.InfiniteTimeSpan)
			{
				cancellationWithConnectTimeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, default(CancellationToken));
				cancellationWithConnectTimeout.CancelAfter(Settings._connectTimeout);
				cancellationToken = cancellationWithConnectTimeout.Token;
			}
			try
			{
				Socket socket = null;
				Stream stream = null;
				switch (_kind)
				{
				case HttpConnectionKind.Http:
				case HttpConnectionKind.Https:
				case HttpConnectionKind.ProxyConnect:
					(socket, stream) = await ConnectHelper.ConnectAsync(_host, _port, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					break;
				case HttpConnectionKind.Proxy:
					(socket, stream) = await ConnectHelper.ConnectAsync(_proxyUri.IdnHost, _proxyUri.Port, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					break;
				case HttpConnectionKind.ProxyTunnel:
				case HttpConnectionKind.SslProxyTunnel:
				{
					HttpResponseMessage httpResponseMessage;
					(stream, httpResponseMessage) = await EstablishProxyTunnel(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (httpResponseMessage != null)
					{
						httpResponseMessage.RequestMessage = request;
						return (null, httpResponseMessage);
					}
					break;
				}
				}
				TransportContext transportContext = null;
				if (_sslOptions != null)
				{
					transportContext = ((SslStream)(stream = await ConnectHelper.EstablishSslConnectionAsync(_sslOptions, request, stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false))).TransportContext;
				}
				HttpConnection item = ((_maxConnections == 2147483647) ? new HttpConnection(this, socket, stream, transportContext) : new HttpConnectionWithFinalizer(this, socket, stream, transportContext));
				return (item, null);
			}
			finally
			{
				cancellationWithConnectTimeout?.Dispose();
			}
		}

		private async ValueTask<(Stream, HttpResponseMessage)> EstablishProxyTunnel(CancellationToken cancellationToken)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Connect, _proxyUri);
			httpRequestMessage.Headers.Host = $"{_host}:{_port}";
			HttpResponseMessage httpResponseMessage = await _poolManager.SendProxyConnectAsync(httpRequestMessage, _proxyUri, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
			{
				return (null, httpResponseMessage);
			}
			return (await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false), null);
		}

		private void EnqueueWaiter(ConnectionWaiter waiter)
		{
			waiter._next = _waitersHead;
			if (_waitersHead != null)
			{
				_waitersHead._prev = waiter;
			}
			else
			{
				_waitersTail = waiter;
			}
			_waitersHead = waiter;
		}

		private ConnectionWaiter DequeueWaiter()
		{
			ConnectionWaiter waitersTail = _waitersTail;
			_waitersTail = waitersTail._prev;
			if (_waitersTail != null)
			{
				_waitersTail._next = null;
			}
			else
			{
				_waitersHead = null;
			}
			waitersTail._next = null;
			waitersTail._prev = null;
			return waitersTail;
		}

		private bool RemoveWaiterForCancellation(ConnectionWaiter waiter)
		{
			bool result = waiter._next != null || waiter._prev != null || _waitersHead == waiter || _waitersTail == waiter;
			if (waiter._next != null)
			{
				waiter._next._prev = waiter._prev;
			}
			if (waiter._prev != null)
			{
				waiter._prev._next = waiter._next;
			}
			if (_waitersHead == waiter && _waitersTail == waiter)
			{
				_waitersHead = (_waitersTail = null);
			}
			else if (_waitersHead == waiter)
			{
				_waitersHead = waiter._next;
			}
			else if (_waitersTail == waiter)
			{
				_waitersTail = waiter._prev;
			}
			waiter._next = null;
			waiter._prev = null;
			return result;
		}

		private async ValueTask<(HttpConnection, HttpResponseMessage)> WaitForCreatedConnectionAsync(ValueTask<(HttpConnection, HttpResponseMessage)> creationTask)
		{
			try
			{
				var (httpConnection, item) = await creationTask.ConfigureAwait(continueOnCapturedContext: false);
				if (httpConnection == null)
				{
					DecrementConnectionCount();
				}
				return (httpConnection, item);
			}
			catch
			{
				DecrementConnectionCount();
				throw;
			}
		}

		public void IncrementConnectionCount()
		{
			lock (SyncObj)
			{
				IncrementConnectionCountNoLock();
			}
		}

		private void IncrementConnectionCountNoLock()
		{
			if (NetEventSource.IsEnabled)
			{
				Trace(null, "IncrementConnectionCountNoLock");
			}
			_usedSinceLastCleanup = true;
			_associatedConnectionCount++;
		}

		public void DecrementConnectionCount()
		{
			if (NetEventSource.IsEnabled)
			{
				Trace(null, "DecrementConnectionCount");
			}
			lock (SyncObj)
			{
				_usedSinceLastCleanup = true;
				if (_waitersHead == null)
				{
					_associatedConnectionCount--;
					return;
				}
				ConnectionWaiter connectionWaiter = DequeueWaiter();
				connectionWaiter._cancellationTokenRegistration.Dispose();
				ValueTask<(HttpConnection, HttpResponseMessage)> valueTask = connectionWaiter.CreateConnectionAsync();
				if (valueTask.IsCompletedSuccessfully)
				{
					connectionWaiter.SetResult(valueTask.Result);
					return;
				}
				valueTask.AsTask().ContinueWith(delegate(Task<(HttpConnection, HttpResponseMessage)> innerConnectionTask, object state)
				{
					ConnectionWaiter connectionWaiter2 = (ConnectionWaiter)state;
					try
					{
						if (innerConnectionTask.GetAwaiter().GetResult().Item2 != null)
						{
							connectionWaiter2._pool.DecrementConnectionCount();
						}
						connectionWaiter2.SetResult(innerConnectionTask.Result);
					}
					catch (Exception exception)
					{
						connectionWaiter2.SetException(exception);
						connectionWaiter2._pool.DecrementConnectionCount();
					}
				}, connectionWaiter, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
			}
		}

		public void ReturnConnection(HttpConnection connection)
		{
			List<CachedConnection> idleConnections = _idleConnections;
			lock (SyncObj)
			{
				_usedSinceLastCleanup = true;
				if (_waitersTail != null && !connection.EnsureReadAheadAndPollRead())
				{
					ConnectionWaiter connectionWaiter = DequeueWaiter();
					connectionWaiter._cancellationTokenRegistration.Dispose();
					if (NetEventSource.IsEnabled)
					{
						connection.Trace("Transferring connection returned to pool.", "ReturnConnection");
					}
					connectionWaiter.SetResult((connection, null));
				}
				else if (_disposed || _poolManager.AvoidStoringConnections)
				{
					if (NetEventSource.IsEnabled)
					{
						connection.Trace("Disposing connection returned to disposed pool.", "ReturnConnection");
					}
					connection.Dispose();
				}
				else
				{
					idleConnections.Add(new CachedConnection(connection));
					if (NetEventSource.IsEnabled)
					{
						connection.Trace("Stored connection in pool.", "ReturnConnection");
					}
				}
			}
		}

		public void Dispose()
		{
			List<CachedConnection> idleConnections = _idleConnections;
			lock (SyncObj)
			{
				if (!_disposed)
				{
					if (NetEventSource.IsEnabled)
					{
						Trace("Disposing pool.", "Dispose");
					}
					_disposed = true;
					idleConnections.ForEach(delegate(CachedConnection c)
					{
						c._connection.Dispose();
					});
					idleConnections.Clear();
				}
			}
		}

		public bool CleanCacheAndDisposeIfUnused()
		{
			TimeSpan pooledConnectionLifetime = _poolManager.Settings._pooledConnectionLifetime;
			TimeSpan pooledConnectionIdleTimeout = _poolManager.Settings._pooledConnectionIdleTimeout;
			List<CachedConnection> idleConnections = _idleConnections;
			List<HttpConnection> list = null;
			bool lockTaken = false;
			try
			{
				if (NetEventSource.IsEnabled)
				{
					Trace("Cleaning pool.", "CleanCacheAndDisposeIfUnused");
				}
				Monitor.Enter(SyncObj, ref lockTaken);
				DateTimeOffset utcNow = DateTimeOffset.UtcNow;
				int i;
				for (i = 0; i < idleConnections.Count && idleConnections[i].IsUsable(utcNow, pooledConnectionLifetime, pooledConnectionIdleTimeout, poll: true); i++)
				{
				}
				if (i < idleConnections.Count)
				{
					list = new List<HttpConnection> { idleConnections[i]._connection };
					int j = i + 1;
					while (j < idleConnections.Count)
					{
						for (; j < idleConnections.Count && !idleConnections[j].IsUsable(utcNow, pooledConnectionLifetime, pooledConnectionIdleTimeout, poll: true); j++)
						{
							list.Add(idleConnections[j]._connection);
						}
						if (j < idleConnections.Count)
						{
							idleConnections[i++] = idleConnections[j++];
						}
					}
					idleConnections.RemoveRange(i, idleConnections.Count - i);
					if (_associatedConnectionCount == 0 && !_usedSinceLastCleanup)
					{
						_disposed = true;
						return true;
					}
				}
				_usedSinceLastCleanup = false;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(SyncObj);
				}
				list?.ForEach(delegate(HttpConnection c)
				{
					c.Dispose();
				});
			}
			return false;
		}

		private static bool GetIsWindows7Or2008R2()
		{
			OperatingSystem oSVersion = Environment.OSVersion;
			if (oSVersion.Platform == PlatformID.Win32NT)
			{
				Version version = oSVersion.Version;
				if (version.Major == 6)
				{
					return version.Minor == 1;
				}
				return false;
			}
			return false;
		}

		public override string ToString()
		{
			return "HttpConnectionPool" + ((!(_proxyUri == null)) ? ((_sslOptions == null) ? $"Proxy {_proxyUri}" : ($"https://{_host}:{_port}/ tunnelled via Proxy {_proxyUri}" + ((_sslOptions.TargetHost != _host) ? (", SSL TargetHost=" + _sslOptions.TargetHost) : null))) : ((_sslOptions == null) ? $"http://{_host}:{_port}" : ($"https://{_host}:{_port}" + ((_sslOptions.TargetHost != _host) ? (", SSL TargetHost=" + _sslOptions.TargetHost) : null))));
		}

		private void Trace(string message, [CallerMemberName] string memberName = null)
		{
			NetEventSource.Log.HandlerMessage(GetHashCode(), 0, 0, memberName, ToString() + ":" + message);
		}
	}
	internal sealed class HttpConnectionPoolManager : IDisposable
	{
		internal readonly struct HttpConnectionKey(HttpConnectionKind kind, string host, int port, string sslHostName, Uri proxyUri) : IEquatable<HttpConnectionKey>
		{
			public readonly HttpConnectionKind Kind = kind;

			public readonly string Host = host;

			public readonly int Port = port;

			public readonly string SslHostName = sslHostName;

			public readonly Uri ProxyUri = proxyUri;

			public override int GetHashCode()
			{
				if (!(SslHostName == Host))
				{
					return HashCode.Combine(Kind, Host, Port, SslHostName, ProxyUri);
				}
				return HashCode.Combine(Kind, Host, Port, ProxyUri);
			}

			public override bool Equals(object obj)
			{
				if (obj != null && obj is HttpConnectionKey)
				{
					return Equals((HttpConnectionKey)obj);
				}
				return false;
			}

			public bool Equals(HttpConnectionKey other)
			{
				if (Kind == other.Kind && Host == other.Host && Port == other.Port && ProxyUri == other.ProxyUri)
				{
					return SslHostName == other.SslHostName;
				}
				return false;
			}
		}

		private readonly TimeSpan _cleanPoolTimeout;

		private readonly ConcurrentDictionary<HttpConnectionKey, HttpConnectionPool> _pools;

		private readonly Timer _cleaningTimer;

		private readonly int _maxConnectionsPerServer;

		private readonly bool _avoidStoringConnections;

		private readonly HttpConnectionSettings _settings;

		private readonly IWebProxy _proxy;

		private readonly ICredentials _proxyCredentials;

		private bool _timerIsRunning;

		private object SyncObj => _pools;

		public HttpConnectionSettings Settings => _settings;

		public ICredentials ProxyCredentials => _proxyCredentials;

		public bool AvoidStoringConnections => _avoidStoringConnections;

		public HttpConnectionPoolManager(HttpConnectionSettings settings)
		{
			_settings = settings;
			_maxConnectionsPerServer = settings._maxConnectionsPerServer;
			_avoidStoringConnections = settings._pooledConnectionIdleTimeout == TimeSpan.Zero || settings._pooledConnectionLifetime == TimeSpan.Zero;
			_pools = new ConcurrentDictionary<HttpConnectionKey, HttpConnectionPool>();
			if (!_avoidStoringConnections)
			{
				if (settings._pooledConnectionIdleTimeout == Timeout.InfiniteTimeSpan)
				{
					_cleanPoolTimeout = TimeSpan.FromSeconds(30.0);
				}
				else
				{
					TimeSpan timeSpan = settings._pooledConnectionIdleTimeout / 4.0;
					_cleanPoolTimeout = ((timeSpan.TotalSeconds >= 1.0) ? timeSpan : TimeSpan.FromSeconds(1.0));
				}
				bool flag = false;
				try
				{
					if (!ExecutionContext.IsFlowSuppressed())
					{
						ExecutionContext.SuppressFlow();
						flag = true;
					}
					_cleaningTimer = new Timer(delegate(object s)
					{
						if (((WeakReference<HttpConnectionPoolManager>)s).TryGetTarget(out var target))
						{
							target.RemoveStalePools();
						}
					}, new WeakReference<HttpConnectionPoolManager>(this), -1, -1);
				}
				finally
				{
					if (flag)
					{
						ExecutionContext.RestoreFlow();
					}
				}
			}
			if (settings._useProxy)
			{
				_proxy = settings._proxy ?? SystemProxyInfo.ConstructSystemProxy();
				if (_proxy != null)
				{
					_proxyCredentials = _proxy.Credentials ?? settings._defaultProxyCredentials;
				}
			}
		}

		private static string ParseHostNameFromHeader(string hostHeader)
		{
			int num = hostHeader.IndexOf(':');
			if (num >= 0)
			{
				int num2 = hostHeader.IndexOf(']');
				if (num2 == -1)
				{
					return hostHeader.Substring(0, num);
				}
				num = hostHeader.LastIndexOf(':');
				if (num > num2)
				{
					return hostHeader.Substring(0, num);
				}
			}
			return hostHeader;
		}

		private static HttpConnectionKey GetConnectionKey(HttpRequestMessage request, Uri proxyUri, bool isProxyConnect)
		{
			Uri requestUri = request.RequestUri;
			if (isProxyConnect)
			{
				return new HttpConnectionKey(HttpConnectionKind.ProxyConnect, requestUri.IdnHost, requestUri.Port, null, proxyUri);
			}
			string text = null;
			if (HttpUtilities.IsSupportedSecureScheme(requestUri.Scheme))
			{
				string host = request.Headers.Host;
				text = ((host == null) ? requestUri.IdnHost : ParseHostNameFromHeader(host));
			}
			if (proxyUri != null)
			{
				if (text == null)
				{
					if (HttpUtilities.IsNonSecureWebSocketScheme(requestUri.Scheme))
					{
						return new HttpConnectionKey(HttpConnectionKind.ProxyTunnel, requestUri.IdnHost, requestUri.Port, null, proxyUri);
					}
					return new HttpConnectionKey(HttpConnectionKind.Proxy, null, 0, null, proxyUri);
				}
				return new HttpConnectionKey(HttpConnectionKind.SslProxyTunnel, requestUri.IdnHost, requestUri.Port, text, proxyUri);
			}
			if (text != null)
			{
				return new HttpConnectionKey(HttpConnectionKind.Https, requestUri.IdnHost, requestUri.Port, text, null);
			}
			return new HttpConnectionKey(HttpConnectionKind.Http, requestUri.IdnHost, requestUri.Port, null, null);
		}

		public Task<HttpResponseMessage> SendAsyncCore(HttpRequestMessage request, Uri proxyUri, bool doRequestAuth, bool isProxyConnect, CancellationToken cancellationToken)
		{
			HttpConnectionKey connectionKey = GetConnectionKey(request, proxyUri, isProxyConnect);
			HttpConnectionPool value;
			while (!_pools.TryGetValue(connectionKey, out value))
			{
				bool flag = connectionKey.Host != null && request.RequestUri.HostNameType == UriHostNameType.IPv6;
				value = new HttpConnectionPool(this, connectionKey.Kind, flag ? ("[" + connectionKey.Host + "]") : connectionKey.Host, connectionKey.Port, connectionKey.SslHostName, connectionKey.ProxyUri, _maxConnectionsPerServer);
				if (_cleaningTimer == null)
				{
					break;
				}
				if (!_pools.TryAdd(connectionKey, value))
				{
					continue;
				}
				lock (SyncObj)
				{
					if (!_timerIsRunning)
					{
						SetCleaningTimer(_cleanPoolTimeout);
					}
				}
				break;
			}
			return value.SendAsync(request, doRequestAuth, cancellationToken);
		}

		public Task<HttpResponseMessage> SendProxyConnectAsync(HttpRequestMessage request, Uri proxyUri, CancellationToken cancellationToken)
		{
			return SendAsyncCore(request, proxyUri, doRequestAuth: false, isProxyConnect: true, cancellationToken);
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, bool doRequestAuth, CancellationToken cancellationToken)
		{
			if (_proxy == null)
			{
				return SendAsyncCore(request, null, doRequestAuth, isProxyConnect: false, cancellationToken);
			}
			Uri uri = null;
			try
			{
				if (!_proxy.IsBypassed(request.RequestUri))
				{
					uri = _proxy.GetProxy(request.RequestUri);
				}
			}
			catch (Exception arg)
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(this, $"Exception from IWebProxy.GetProxy({request.RequestUri}): {arg}");
				}
			}
			if (uri != null && uri.Scheme != "http")
			{
				throw new NotSupportedException("Only the 'http' scheme is allowed for proxies.");
			}
			return SendAsyncCore(request, uri, doRequestAuth, isProxyConnect: false, cancellationToken);
		}

		public void Dispose()
		{
			_cleaningTimer?.Dispose();
			foreach (KeyValuePair<HttpConnectionKey, HttpConnectionPool> pool in _pools)
			{
				pool.Value.Dispose();
			}
			if (_proxy is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}

		private void SetCleaningTimer(TimeSpan timeout)
		{
			try
			{
				_cleaningTimer.Change(timeout, timeout);
				_timerIsRunning = timeout != Timeout.InfiniteTimeSpan;
			}
			catch (ObjectDisposedException)
			{
			}
		}

		private void RemoveStalePools()
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Enter(this);
			}
			foreach (KeyValuePair<HttpConnectionKey, HttpConnectionPool> pool in _pools)
			{
				if (pool.Value.CleanCacheAndDisposeIfUnused())
				{
					_pools.TryRemove(pool.Key, out var _);
				}
			}
			lock (SyncObj)
			{
				if (_pools.IsEmpty)
				{
					SetCleaningTimer(Timeout.InfiniteTimeSpan);
				}
			}
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Exit(this);
			}
		}
	}
	internal sealed class HttpConnectionSettings
	{
		internal DecompressionMethods _automaticDecompression;

		internal bool _useCookies = true;

		internal CookieContainer _cookieContainer;

		internal bool _useProxy = true;

		internal IWebProxy _proxy;

		internal ICredentials _defaultProxyCredentials;

		internal bool _preAuthenticate;

		internal ICredentials _credentials;

		internal bool _allowAutoRedirect = true;

		internal int _maxAutomaticRedirections = 50;

		internal int _maxConnectionsPerServer = 2147483647;

		internal int _maxResponseDrainSize = 1048576;

		internal TimeSpan _maxResponseDrainTime = HttpHandlerDefaults.DefaultResponseDrainTimeout;

		internal int _maxResponseHeadersLength = 64;

		internal TimeSpan _pooledConnectionLifetime = HttpHandlerDefaults.DefaultPooledConnectionLifetime;

		internal TimeSpan _pooledConnectionIdleTimeout = HttpHandlerDefaults.DefaultPooledConnectionIdleTimeout;

		internal TimeSpan _expect100ContinueTimeout = HttpHandlerDefaults.DefaultExpect100ContinueTimeout;

		internal TimeSpan _connectTimeout = HttpHandlerDefaults.DefaultConnectTimeout;

		internal SslClientAuthenticationOptions _sslOptions;

		internal IDictionary<string, object> _properties;

		public HttpConnectionSettings Clone()
		{
			if (_useCookies && _cookieContainer == null)
			{
				_cookieContainer = new CookieContainer();
			}
			return new HttpConnectionSettings
			{
				_allowAutoRedirect = _allowAutoRedirect,
				_automaticDecompression = _automaticDecompression,
				_cookieContainer = _cookieContainer,
				_connectTimeout = _connectTimeout,
				_credentials = _credentials,
				_defaultProxyCredentials = _defaultProxyCredentials,
				_expect100ContinueTimeout = _expect100ContinueTimeout,
				_maxAutomaticRedirections = _maxAutomaticRedirections,
				_maxConnectionsPerServer = _maxConnectionsPerServer,
				_maxResponseDrainSize = _maxResponseDrainSize,
				_maxResponseDrainTime = _maxResponseDrainTime,
				_maxResponseHeadersLength = _maxResponseHeadersLength,
				_pooledConnectionLifetime = _pooledConnectionLifetime,
				_pooledConnectionIdleTimeout = _pooledConnectionIdleTimeout,
				_preAuthenticate = _preAuthenticate,
				_properties = _properties,
				_proxy = _proxy,
				_sslOptions = _sslOptions?.ShallowClone(),
				_useCookies = _useCookies,
				_useProxy = _useProxy
			};
		}
	}
	internal abstract class HttpContentDuplexStream : HttpContentStream
	{
		public sealed override bool CanRead => true;

		public sealed override bool CanWrite => true;

		public HttpContentDuplexStream(HttpConnection connection)
			: base(connection)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Info(this);
			}
		}

		public sealed override void Flush()
		{
			FlushAsync().GetAwaiter().GetResult();
		}

		public sealed override int Read(byte[] buffer, int offset, int count)
		{
			HttpContentStream.ValidateBufferArgs(buffer, offset, count);
			return ReadAsync(new Memory<byte>(buffer, offset, count), CancellationToken.None).GetAwaiter().GetResult();
		}

		public sealed override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			HttpContentStream.ValidateBufferArgs(buffer, offset, count);
			return ReadAsync(new Memory<byte>(buffer, offset, count), cancellationToken).AsTask();
		}

		public sealed override void Write(byte[] buffer, int offset, int count)
		{
			HttpContentStream.ValidateBufferArgs(buffer, offset, count);
			WriteAsync(new Memory<byte>(buffer, offset, count), CancellationToken.None).GetAwaiter().GetResult();
		}

		public sealed override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			HttpContentStream.ValidateBufferArgs(buffer, offset, count);
			return WriteAsync(new ReadOnlyMemory<byte>(buffer, offset, count), cancellationToken).AsTask();
		}

		public sealed override void CopyTo(Stream destination, int bufferSize)
		{
			CopyToAsync(destination, bufferSize, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
	internal abstract class HttpContentStream : Stream
	{
		protected HttpConnection _connection;

		public sealed override bool CanSeek => false;

		public sealed override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public sealed override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public HttpContentStream(HttpConnection connection)
		{
			_connection = connection;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && _connection != null)
			{
				_connection.Dispose();
				_connection = null;
			}
			base.Dispose(disposing);
		}

		public sealed override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return TaskToApm.Begin(ReadAsync(buffer, offset, count, default(CancellationToken)), callback, state);
		}

		public sealed override int EndRead(IAsyncResult asyncResult)
		{
			return TaskToApm.End<int>(asyncResult);
		}

		public sealed override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return TaskToApm.Begin(WriteAsync(buffer, offset, count, default(CancellationToken)), callback, state);
		}

		public sealed override void EndWrite(IAsyncResult asyncResult)
		{
			TaskToApm.End(asyncResult);
		}

		public sealed override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public sealed override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		protected static void ValidateBufferArgs(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if ((uint)offset > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if ((uint)count > buffer.Length - offset)
			{
				throw new ArgumentOutOfRangeException("count");
			}
		}

		protected static void ValidateCopyToArgs(Stream source, Stream destination, int bufferSize)
		{
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize", bufferSize, "Positive number required.");
			}
			if (!destination.CanWrite)
			{
				throw destination.CanRead ? ((SystemException)new NotSupportedException("Stream does not support writing.")) : ((SystemException)new ObjectDisposedException("destination", "Cannot access a closed Stream."));
			}
		}
	}
	internal sealed class HttpEnvironmentProxyCredentials : ICredentials
	{
		private readonly NetworkCredential _httpCred;

		private readonly NetworkCredential _httpsCred;

		private readonly Uri _httpProxy;

		private readonly Uri _httpsProxy;

		public HttpEnvironmentProxyCredentials(Uri httpProxy, NetworkCredential httpCred, Uri httpsProxy, NetworkCredential httpsCred)
		{
			_httpCred = httpCred;
			_httpsCred = httpsCred;
			_httpProxy = httpProxy;
			_httpsProxy = httpsProxy;
		}

		public NetworkCredential GetCredential(Uri uri, string authType)
		{
			if (uri == null)
			{
				return null;
			}
			if (!uri.Equals(_httpProxy))
			{
				if (!uri.Equals(_httpsProxy))
				{
					return null;
				}
				return _httpsCred;
			}
			return _httpCred;
		}

		public static HttpEnvironmentProxyCredentials TryCreate(Uri httpProxy, Uri httpsProxy)
		{
			NetworkCredential networkCredential = null;
			NetworkCredential networkCredential2 = null;
			if (httpProxy != null)
			{
				networkCredential = GetCredentialsFromString(httpProxy.UserInfo);
			}
			if (httpsProxy != null)
			{
				networkCredential2 = GetCredentialsFromString(httpsProxy.UserInfo);
			}
			if (networkCredential == null && networkCredential2 == null)
			{
				return null;
			}
			return new HttpEnvironmentProxyCredentials(httpProxy, networkCredential, httpsProxy, networkCredential2);
		}

		private static NetworkCredential GetCredentialsFromString(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return null;
			}
			value = Uri.UnescapeDataString(value);
			string password = "";
			string domain = null;
			int num = value.IndexOf(':');
			if (num != -1)
			{
				password = value.Substring(num + 1);
				value = value.Substring(0, num);
			}
			num = value.IndexOf('\\');
			if (num != -1)
			{
				domain = value.Substring(0, num);
				value = value.Substring(num + 1);
			}
			return new NetworkCredential(value, password, domain);
		}
	}
	internal sealed class HttpEnvironmentProxy : IWebProxy
	{
		private Uri _httpProxyUri;

		private Uri _httpsProxyUri;

		private string[] _bypass;

		private ICredentials _credentials;

		public ICredentials Credentials
		{
			get
			{
				return _credentials;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public static bool TryCreate(out IWebProxy proxy)
		{
			Uri uri = GetUriFromString(Environment.GetEnvironmentVariable("http_proxy"));
			Uri uri2 = GetUriFromString(Environment.GetEnvironmentVariable("https_proxy")) ?? GetUriFromString(Environment.GetEnvironmentVariable("HTTPS_PROXY"));
			if (uri == null || uri2 == null)
			{
				Uri uri3 = GetUriFromString(Environment.GetEnvironmentVariable("all_proxy")) ?? GetUriFromString(Environment.GetEnvironmentVariable("ALL_PROXY"));
				if (uri == null)
				{
					uri = uri3;
				}
				if (uri2 == null)
				{
					uri2 = uri3;
				}
			}
			if (uri == null && uri2 == null)
			{
				proxy = null;
				return false;
			}
			proxy = new HttpEnvironmentProxy(uri, uri2, Environment.GetEnvironmentVariable("no_proxy"));
			return true;
		}

		private HttpEnvironmentProxy(Uri httpProxy, Uri httpsProxy, string bypassList)
		{
			_httpProxyUri = httpProxy;
			_httpsProxyUri = httpsProxy;
			_credentials = HttpEnvironmentProxyCredentials.TryCreate(httpProxy, httpsProxy);
			if (string.IsNullOrWhiteSpace(bypassList))
			{
				return;
			}
			string[] array = bypassList.Split(',');
			List<string> list = new List<string>(array.Length);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i].Trim();
				if (text.Length > 0)
				{
					list.Add(text);
				}
			}
			if (list.Count > 0)
			{
				_bypass = list.ToArray();
			}
		}

		private static Uri GetUriFromString(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return null;
			}
			if (value.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
			{
				value = value.Substring(7);
			}
			string text = null;
			string text2 = null;
			ushort result = 80;
			string text3 = null;
			int num = value.LastIndexOf('@');
			if (num != -1)
			{
				string text4 = value.Substring(0, num);
				try
				{
					text4 = Uri.UnescapeDataString(text4);
				}
				catch
				{
				}
				value = value.Substring(num + 1);
				num = text4.IndexOf(':');
				if (num == -1)
				{
					text = text4;
				}
				else
				{
					text = text4.Substring(0, num);
					text2 = text4.Substring(num + 1);
				}
			}
			int num2 = value.IndexOf(']');
			num = value.LastIndexOf(':');
			if (num == -1 || (num2 != -1 && num < num2))
			{
				text3 = value;
			}
			else
			{
				text3 = value.Substring(0, num);
				int i;
				for (i = num + 1; i < value.Length && char.IsDigit(value[i]); i++)
				{
				}
				if (!ushort.TryParse(value.AsSpan(num + 1, i - num - 1), out result))
				{
					return null;
				}
			}
			try
			{
				UriBuilder uriBuilder = new UriBuilder("http", text3, result);
				if (text != null)
				{
					uriBuilder.UserName = Uri.EscapeDataString(text);
				}
				if (text2 != null)
				{
					uriBuilder.Password = Uri.EscapeDataString(text2);
				}
				return uriBuilder.Uri;
			}
			catch
			{
			}
			return null;
		}

		private bool IsMatchInBypassList(Uri input)
		{
			if (_bypass != null)
			{
				string[] bypass = _bypass;
				foreach (string text in bypass)
				{
					if (text[0] == '.')
					{
						if (text.Length - 1 == input.Host.Length && string.Compare(text, 1, input.Host, 0, input.Host.Length, StringComparison.OrdinalIgnoreCase) == 0)
						{
							return true;
						}
						if (input.Host.EndsWith(text, StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
					}
					else if (string.Equals(text, input.Host, StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
				}
			}
			return false;
		}

		public Uri GetProxy(Uri uri)
		{
			if (!(uri.Scheme == Uri.UriSchemeHttp))
			{
				return _httpsProxyUri;
			}
			return _httpProxyUri;
		}

		public bool IsBypassed(Uri uri)
		{
			if (!(GetProxy(uri) == null))
			{
				return IsMatchInBypassList(uri);
			}
			return true;
		}
	}
	internal sealed class RedirectHandler : HttpMessageHandler
	{
		private readonly HttpMessageHandler _initialInnerHandler;

		private readonly HttpMessageHandler _redirectInnerHandler;

		private readonly int _maxAutomaticRedirections;

		public RedirectHandler(int maxAutomaticRedirections, HttpMessageHandler initialInnerHandler, HttpMessageHandler redirectInnerHandler)
		{
			_maxAutomaticRedirections = maxAutomaticRedirections;
			_initialInnerHandler = initialInnerHandler;
			_redirectInnerHandler = redirectInnerHandler;
		}

		protected internal override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Enter(this, request, cancellationToken);
			}
			HttpResponseMessage httpResponseMessage = await _initialInnerHandler.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			uint redirectCount = 0u;
			Uri uriForRedirect;
			while ((uriForRedirect = GetUriForRedirect(request.RequestUri, httpResponseMessage)) != null)
			{
				redirectCount++;
				if (redirectCount > _maxAutomaticRedirections)
				{
					if (NetEventSource.IsEnabled)
					{
						NetEventSource.Error(this, $"Exceeded max number of redirects. Redirect from {request.RequestUri} to {uriForRedirect} blocked.");
					}
					break;
				}
				httpResponseMessage.Dispose();
				request.Headers.Authorization = null;
				request.RequestUri = uriForRedirect;
				if (RequestRequiresForceGet(httpResponseMessage.StatusCode, request.Method))
				{
					request.Method = HttpMethod.Get;
					request.Content = null;
					request.Headers.TransferEncodingChunked = false;
				}
				httpResponseMessage = await _redirectInnerHandler.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Exit(this);
			}
			return httpResponseMessage;
		}

		private Uri GetUriForRedirect(Uri requestUri, HttpResponseMessage response)
		{
			HttpStatusCode statusCode = response.StatusCode;
			if ((uint)(statusCode - 300) > 3u && (uint)(statusCode - 307) > 1u)
			{
				return null;
			}
			Uri uri = response.Headers.Location;
			if (uri == null)
			{
				return null;
			}
			if (!uri.IsAbsoluteUri)
			{
				uri = new Uri(requestUri, uri);
			}
			string fragment = requestUri.Fragment;
			if (!string.IsNullOrEmpty(fragment) && string.IsNullOrEmpty(uri.Fragment))
			{
				uri = new UriBuilder(uri)
				{
					Fragment = fragment
				}.Uri;
			}
			if (HttpUtilities.IsSupportedSecureScheme(requestUri.Scheme) && !HttpUtilities.IsSupportedSecureScheme(uri.Scheme))
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(this, $"Insecure https to http redirect from '{requestUri}' to '{uri}' blocked.");
				}
				return null;
			}
			return uri;
		}

		private static bool RequestRequiresForceGet(HttpStatusCode statusCode, HttpMethod requestMethod)
		{
			if ((uint)(statusCode - 300) <= 3u)
			{
				return requestMethod == HttpMethod.Post;
			}
			return false;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_initialInnerHandler.Dispose();
				_redirectInnerHandler.Dispose();
			}
			base.Dispose(disposing);
		}
	}
	public sealed class SocketsHttpHandler : HttpMessageHandler, IMonoHttpClientHandler, IDisposable
	{
		private readonly HttpConnectionSettings _settings = new HttpConnectionSettings();

		private HttpMessageHandler _handler;

		private bool _disposed;

		public DecompressionMethods AutomaticDecompression
		{
			set
			{
				CheckDisposedOrStarted();
				_settings._automaticDecompression = value;
			}
		}

		public bool UseProxy
		{
			set
			{
				CheckDisposedOrStarted();
				_settings._useProxy = value;
			}
		}

		public IWebProxy Proxy
		{
			get
			{
				return _settings._proxy;
			}
			set
			{
				CheckDisposedOrStarted();
				_settings._proxy = value;
			}
		}

		public bool AllowAutoRedirect
		{
			set
			{
				CheckDisposedOrStarted();
				_settings._allowAutoRedirect = value;
			}
		}

		public SslClientAuthenticationOptions SslOptions
		{
			get
			{
				return _settings._sslOptions ?? (_settings._sslOptions = new SslClientAuthenticationOptions());
			}
			set
			{
				CheckDisposedOrStarted();
				_settings._sslOptions = value;
			}
		}

		private void CheckDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException("SocketsHttpHandler");
			}
		}

		private void CheckDisposedOrStarted()
		{
			CheckDisposed();
			if (_handler != null)
			{
				throw new InvalidOperationException("This instance has already started one or more requests. Properties can only be modified before sending the first request.");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				_disposed = true;
				_handler?.Dispose();
			}
			base.Dispose(disposing);
		}

		private HttpMessageHandler SetupHandlerChain()
		{
			HttpConnectionSettings httpConnectionSettings = _settings.Clone();
			HttpConnectionPoolManager poolManager = new HttpConnectionPoolManager(httpConnectionSettings);
			HttpMessageHandler httpMessageHandler = ((httpConnectionSettings._credentials != null) ? ((HttpMessageHandler)new HttpAuthenticatedConnectionHandler(poolManager)) : ((HttpMessageHandler)new HttpConnectionHandler(poolManager)));
			if (httpConnectionSettings._allowAutoRedirect)
			{
				HttpMessageHandler redirectInnerHandler = ((httpConnectionSettings._credentials == null || httpConnectionSettings._credentials is CredentialCache) ? httpMessageHandler : new HttpConnectionHandler(poolManager));
				httpMessageHandler = new RedirectHandler(httpConnectionSettings._maxAutomaticRedirections, httpMessageHandler, redirectInnerHandler);
			}
			if (httpConnectionSettings._automaticDecompression != DecompressionMethods.None)
			{
				httpMessageHandler = new DecompressionHandler(httpConnectionSettings._automaticDecompression, httpMessageHandler);
			}
			if (Interlocked.CompareExchange(ref _handler, httpMessageHandler, null) != null)
			{
				httpMessageHandler.Dispose();
			}
			return _handler;
		}

		protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			CheckDisposed();
			HttpMessageHandler httpMessageHandler = _handler ?? SetupHandlerChain();
			Exception ex = ValidateAndNormalizeRequest(request);
			if (ex != null)
			{
				return Task.FromException<HttpResponseMessage>(ex);
			}
			return httpMessageHandler.SendAsync(request, cancellationToken);
		}

		private Exception ValidateAndNormalizeRequest(HttpRequestMessage request)
		{
			if (request.Version.Major == 0)
			{
				return new NotSupportedException("Request HttpVersion 0.X is not supported.  Use 1.0 or above.");
			}
			if (request.HasHeaders && request.Headers.TransferEncodingChunked == true)
			{
				if (request.Content == null)
				{
					return new HttpRequestException("An error occurred while sending the request.", new InvalidOperationException("'Transfer-Encoding: chunked' header can not be used when content object is not specified."));
				}
				request.Content.Headers.ContentLength = null;
			}
			else if (request.Content != null && !request.Content.Headers.ContentLength.HasValue)
			{
				request.Headers.TransferEncodingChunked = true;
			}
			if (request.Version.Minor == 0 && request.Version.Major == 1 && request.HasHeaders)
			{
				if (request.Headers.TransferEncodingChunked == true)
				{
					return new NotSupportedException("HTTP 1.0 does not support chunking.");
				}
				if (request.Headers.ExpectContinue == true)
				{
					request.Headers.ExpectContinue = false;
				}
			}
			return null;
		}

		Task<HttpResponseMessage> IMonoHttpClientHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return SendAsync(request, cancellationToken);
		}
	}
	internal static class SystemProxyInfo
	{
		public static IWebProxy ConstructSystemProxy()
		{
			if (!HttpEnvironmentProxy.TryCreate(out var proxy))
			{
				return null;
			}
			return proxy;
		}
	}
	public class StreamContent : HttpContent
	{
		private sealed class ReadOnlyStream : DelegatingStream
		{
			public override bool CanWrite => false;

			public override int WriteTimeout
			{
				get
				{
					throw new NotSupportedException("The stream does not support writing.");
				}
				set
				{
					throw new NotSupportedException("The stream does not support writing.");
				}
			}

			public ReadOnlyStream(Stream innerStream)
				: base(innerStream)
			{
			}

			public override void Flush()
			{
				throw new NotSupportedException("The stream does not support writing.");
			}

			public override Task FlushAsync(CancellationToken cancellationToken)
			{
				throw new NotSupportedException("The stream does not support writing.");
			}

			public override void SetLength(long value)
			{
				throw new NotSupportedException("The stream does not support writing.");
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException("The stream does not support writing.");
			}

			public override void Write(ReadOnlySpan<byte> buffer)
			{
				throw new NotSupportedException("The stream does not support writing.");
			}

			public override void WriteByte(byte value)
			{
				throw new NotSupportedException("The stream does not support writing.");
			}

			public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				throw new NotSupportedException("The stream does not support writing.");
			}

			public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
			{
				throw new NotSupportedException("The stream does not support writing.");
			}
		}

		private Stream _content;

		private int _bufferSize;

		private bool _contentConsumed;

		private long _start;

		public StreamContent(Stream content)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			InitializeContent(content, 0);
		}

		public StreamContent(Stream content, int bufferSize)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			InitializeContent(content, bufferSize);
		}

		private void InitializeContent(Stream content, int bufferSize)
		{
			_content = content;
			_bufferSize = bufferSize;
			if (content.CanSeek)
			{
				_start = content.Position;
			}
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Associate(this, content);
			}
		}

		protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
		{
			PrepareContent();
			return StreamToStreamCopy.CopyAsync(_content, stream, _bufferSize, !_content.CanSeek);
		}

		protected internal override bool TryComputeLength(out long length)
		{
			if (_content.CanSeek)
			{
				length = _content.Length - _start;
				return true;
			}
			length = 0L;
			return false;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_content.Dispose();
			}
			base.Dispose(disposing);
		}

		protected override Task<Stream> CreateContentReadStreamAsync()
		{
			return Task.FromResult((Stream)new ReadOnlyStream(_content));
		}

		internal override Stream TryCreateContentReadStream()
		{
			if (!(GetType() == typeof(StreamContent)))
			{
				return null;
			}
			return new ReadOnlyStream(_content);
		}

		private void PrepareContent()
		{
			if (_contentConsumed)
			{
				if (!_content.CanSeek)
				{
					throw new InvalidOperationException("The stream was already consumed. It cannot be read again.");
				}
				_content.Position = _start;
			}
			_contentConsumed = true;
		}
	}
	internal static class StreamToStreamCopy
	{
		public static Task CopyAsync(Stream source, Stream destination, int bufferSize, bool disposeSource, CancellationToken cancellationToken = default(CancellationToken))
		{
			try
			{
				Task task = ((bufferSize == 0) ? source.CopyToAsync(destination, cancellationToken) : source.CopyToAsync(destination, bufferSize, cancellationToken));
				return disposeSource ? DisposeSourceWhenCompleteAsync(task, source) : task;
			}
			catch (Exception exception)
			{
				return Task.FromException(exception);
			}
		}

		private static Task DisposeSourceWhenCompleteAsync(Task task, Stream source)
		{
			switch (task.Status)
			{
			case TaskStatus.RanToCompletion:
				DisposeSource(source);
				return Task.CompletedTask;
			case TaskStatus.Canceled:
			case TaskStatus.Faulted:
				return task;
			default:
				return task.ContinueWith(delegate(Task completed, object innerSource)
				{
					completed.GetAwaiter().GetResult();
					DisposeSource((Stream)innerSource);
				}, source, CancellationToken.None, TaskContinuationOptions.DenyChildAttach | TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
			}
		}

		private static void DisposeSource(Stream source)
		{
			try
			{
				source.Dispose();
			}
			catch (Exception ex)
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(null, ex);
				}
			}
		}
	}
	public class StringContent : ByteArrayContent
	{
		public StringContent(string content)
			: this(content, null, null)
		{
		}

		public StringContent(string content, Encoding encoding, string mediaType)
			: base(GetContentByteArray(content, encoding))
		{
			MediaTypeHeaderValue contentType = new MediaTypeHeaderValue((mediaType == null) ? "text/plain" : mediaType)
			{
				CharSet = ((encoding == null) ? HttpContent.DefaultStringEncoding.WebName : encoding.WebName)
			};
			base.Headers.ContentType = contentType;
		}

		private static byte[] GetContentByteArray(string content, Encoding encoding)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			if (encoding == null)
			{
				encoding = HttpContent.DefaultStringEncoding;
			}
			return encoding.GetBytes(content);
		}

		internal override Stream TryCreateContentReadStream()
		{
			if (!(GetType() == typeof(StringContent)))
			{
				return null;
			}
			return CreateMemoryStreamForByteArray();
		}
	}
	internal interface IMonoHttpClientHandler : IDisposable
	{
		SslClientAuthenticationOptions SslOptions { get; set; }

		DecompressionMethods AutomaticDecompression { set; }

		bool UseProxy { set; }

		IWebProxy Proxy { get; set; }

		bool AllowAutoRedirect { set; }

		Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
	}
}
namespace System.Net.Http.Headers
{
	public class AuthenticationHeaderValue : ICloneable
	{
		private string _scheme;

		private string _parameter;

		public string Scheme => _scheme;

		public string Parameter => _parameter;

		public AuthenticationHeaderValue(string scheme, string parameter)
		{
			HeaderUtilities.CheckValidToken(scheme, "scheme");
			_scheme = scheme;
			_parameter = parameter;
		}

		private AuthenticationHeaderValue(AuthenticationHeaderValue source)
		{
			_scheme = source._scheme;
			_parameter = source._parameter;
		}

		private AuthenticationHeaderValue()
		{
		}

		public override string ToString()
		{
			if (string.IsNullOrEmpty(_parameter))
			{
				return _scheme;
			}
			return _scheme + " " + _parameter;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is AuthenticationHeaderValue authenticationHeaderValue))
			{
				return false;
			}
			if (string.IsNullOrEmpty(_parameter) && string.IsNullOrEmpty(authenticationHeaderValue._parameter))
			{
				return string.Equals(_scheme, authenticationHeaderValue._scheme, StringComparison.OrdinalIgnoreCase);
			}
			if (string.Equals(_scheme, authenticationHeaderValue._scheme, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(_parameter, authenticationHeaderValue._parameter, StringComparison.Ordinal);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_scheme);
			if (!string.IsNullOrEmpty(_parameter))
			{
				num ^= _parameter.GetHashCode();
			}
			return num;
		}

		internal static int GetAuthenticationLength(string input, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex);
			if (tokenLength == 0)
			{
				return 0;
			}
			AuthenticationHeaderValue authenticationHeaderValue = new AuthenticationHeaderValue();
			string text = null;
			switch (tokenLength)
			{
			case 5:
				text = "Basic";
				break;
			case 6:
				text = "Digest";
				break;
			case 4:
				text = "NTLM";
				break;
			case 9:
				text = "Negotiate";
				break;
			}
			authenticationHeaderValue._scheme = ((text != null && string.CompareOrdinal(input, startIndex, text, 0, tokenLength) == 0) ? text : (authenticationHeaderValue._scheme = input.Substring(startIndex, tokenLength)));
			int num = startIndex + tokenLength;
			int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, num);
			num += whitespaceLength;
			if (num == input.Length || input[num] == ',')
			{
				parsedValue = authenticationHeaderValue;
				return num - startIndex;
			}
			if (whitespaceLength == 0)
			{
				return 0;
			}
			int num2 = num;
			int parameterEndIndex = num;
			if (!TrySkipFirstBlob(input, ref num, ref parameterEndIndex))
			{
				return 0;
			}
			if (num < input.Length && !TryGetParametersEndIndex(input, ref num, ref parameterEndIndex))
			{
				return 0;
			}
			authenticationHeaderValue._parameter = input.Substring(num2, parameterEndIndex - num2 + 1);
			parsedValue = authenticationHeaderValue;
			return num - startIndex;
		}

		private static bool TrySkipFirstBlob(string input, ref int current, ref int parameterEndIndex)
		{
			while (current < input.Length && input[current] != ',')
			{
				if (input[current] == '"')
				{
					int length = 0;
					if (HttpRuleParser.GetQuotedStringLength(input, current, out length) != HttpParseResult.Parsed)
					{
						return false;
					}
					current += length;
					parameterEndIndex = current - 1;
				}
				else
				{
					int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, current);
					if (whitespaceLength == 0)
					{
						parameterEndIndex = current;
						current++;
					}
					else
					{
						current += whitespaceLength;
					}
				}
			}
			return true;
		}

		private static bool TryGetParametersEndIndex(string input, ref int parseEndIndex, ref int parameterEndIndex)
		{
			int num = parseEndIndex;
			do
			{
				num++;
				bool separatorFound = false;
				num = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(input, num, skipEmptyValues: true, out separatorFound);
				if (num == input.Length)
				{
					return true;
				}
				int tokenLength = HttpRuleParser.GetTokenLength(input, num);
				if (tokenLength == 0)
				{
					return false;
				}
				num += tokenLength;
				num += HttpRuleParser.GetWhitespaceLength(input, num);
				if (num == input.Length || input[num] != '=')
				{
					return true;
				}
				num++;
				num += HttpRuleParser.GetWhitespaceLength(input, num);
				int valueLength = NameValueHeaderValue.GetValueLength(input, num);
				if (valueLength == 0)
				{
					return false;
				}
				num += valueLength;
				parameterEndIndex = num - 1;
				num = (parseEndIndex = num + HttpRuleParser.GetWhitespaceLength(input, num));
			}
			while (num < input.Length && input[num] == ',');
			return true;
		}

		object ICloneable.Clone()
		{
			return new AuthenticationHeaderValue(this);
		}
	}
	internal abstract class BaseHeaderParser : HttpHeaderParser
	{
		protected BaseHeaderParser(bool supportsMultipleValues)
			: base(supportsMultipleValues)
		{
		}

		protected abstract int GetParsedValueLength(string value, int startIndex, object storeValue, out object parsedValue);

		public sealed override bool TryParseValue(string value, object storeValue, ref int index, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(value) || index == value.Length)
			{
				return base.SupportsMultipleValues;
			}
			bool separatorFound = false;
			int nextNonEmptyOrWhitespaceIndex = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(value, index, base.SupportsMultipleValues, out separatorFound);
			if (separatorFound && !base.SupportsMultipleValues)
			{
				return false;
			}
			if (nextNonEmptyOrWhitespaceIndex == value.Length)
			{
				if (base.SupportsMultipleValues)
				{
					index = nextNonEmptyOrWhitespaceIndex;
				}
				return base.SupportsMultipleValues;
			}
			object parsedValue2 = null;
			int parsedValueLength = GetParsedValueLength(value, nextNonEmptyOrWhitespaceIndex, storeValue, out parsedValue2);
			if (parsedValueLength == 0)
			{
				return false;
			}
			nextNonEmptyOrWhitespaceIndex += parsedValueLength;
			nextNonEmptyOrWhitespaceIndex = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(value, nextNonEmptyOrWhitespaceIndex, base.SupportsMultipleValues, out separatorFound);
			if ((separatorFound && !base.SupportsMultipleValues) || (!separatorFound && nextNonEmptyOrWhitespaceIndex < value.Length))
			{
				return false;
			}
			index = nextNonEmptyOrWhitespaceIndex;
			parsedValue = parsedValue2;
			return true;
		}
	}
	internal class ByteArrayHeaderParser : HttpHeaderParser
	{
		internal static readonly ByteArrayHeaderParser Parser = new ByteArrayHeaderParser();

		private ByteArrayHeaderParser()
			: base(supportsMultipleValues: false)
		{
		}

		public override string ToString(object value)
		{
			return Convert.ToBase64String((byte[])value);
		}

		public override bool TryParseValue(string value, object storeValue, ref int index, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(value) || index == value.Length)
			{
				return false;
			}
			string text = value;
			if (index > 0)
			{
				text = value.Substring(index);
			}
			try
			{
				parsedValue = Convert.FromBase64String(text);
				index = value.Length;
				return true;
			}
			catch (FormatException ex)
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(this, global::SR.Format("Value '{0}' is not a valid Base64 string. Error: {1}", text, ex.Message));
				}
			}
			return false;
		}
	}
	internal class CacheControlHeaderParser : BaseHeaderParser
	{
		internal static readonly CacheControlHeaderParser Parser = new CacheControlHeaderParser();

		private CacheControlHeaderParser()
			: base(supportsMultipleValues: true)
		{
		}

		protected override int GetParsedValueLength(string value, int startIndex, object storeValue, out object parsedValue)
		{
			CacheControlHeaderValue parsedValue2 = storeValue as CacheControlHeaderValue;
			int cacheControlLength = CacheControlHeaderValue.GetCacheControlLength(value, startIndex, parsedValue2, out parsedValue2);
			parsedValue = parsedValue2;
			return cacheControlLength;
		}
	}
	public class CacheControlHeaderValue : ICloneable
	{
		private static readonly HttpHeaderParser s_nameValueListParser = GenericHeaderParser.MultipleValueNameValueParser;

		private static readonly Action<string> s_checkIsValidToken = CheckIsValidToken;

		private bool _noCache;

		private ObjectCollection<string> _noCacheHeaders;

		private bool _noStore;

		private TimeSpan? _maxAge;

		private TimeSpan? _sharedMaxAge;

		private bool _maxStale;

		private TimeSpan? _maxStaleLimit;

		private TimeSpan? _minFresh;

		private bool _noTransform;

		private bool _onlyIfCached;

		private bool _publicField;

		private bool _privateField;

		private ObjectCollection<string> _privateHeaders;

		private bool _mustRevalidate;

		private bool _proxyRevalidate;

		private ObjectCollection<NameValueHeaderValue> _extensions;

		public ICollection<string> NoCacheHeaders
		{
			get
			{
				if (_noCacheHeaders == null)
				{
					_noCacheHeaders = new ObjectCollection<string>(s_checkIsValidToken);
				}
				return _noCacheHeaders;
			}
		}

		public ICollection<string> PrivateHeaders
		{
			get
			{
				if (_privateHeaders == null)
				{
					_privateHeaders = new ObjectCollection<string>(s_checkIsValidToken);
				}
				return _privateHeaders;
			}
		}

		public ICollection<NameValueHeaderValue> Extensions
		{
			get
			{
				if (_extensions == null)
				{
					_extensions = new ObjectCollection<NameValueHeaderValue>();
				}
				return _extensions;
			}
		}

		public CacheControlHeaderValue()
		{
		}

		private CacheControlHeaderValue(CacheControlHeaderValue source)
		{
			_noCache = source._noCache;
			_noStore = source._noStore;
			_maxAge = source._maxAge;
			_sharedMaxAge = source._sharedMaxAge;
			_maxStale = source._maxStale;
			_maxStaleLimit = source._maxStaleLimit;
			_minFresh = source._minFresh;
			_noTransform = source._noTransform;
			_onlyIfCached = source._onlyIfCached;
			_publicField = source._publicField;
			_privateField = source._privateField;
			_mustRevalidate = source._mustRevalidate;
			_proxyRevalidate = source._proxyRevalidate;
			if (source._noCacheHeaders != null)
			{
				foreach (string noCacheHeader in source._noCacheHeaders)
				{
					NoCacheHeaders.Add(noCacheHeader);
				}
			}
			if (source._privateHeaders != null)
			{
				foreach (string privateHeader in source._privateHeaders)
				{
					PrivateHeaders.Add(privateHeader);
				}
			}
			if (source._extensions == null)
			{
				return;
			}
			foreach (NameValueHeaderValue extension in source._extensions)
			{
				Extensions.Add((NameValueHeaderValue)((ICloneable)extension).Clone());
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			AppendValueIfRequired(stringBuilder, _noStore, "no-store");
			AppendValueIfRequired(stringBuilder, _noTransform, "no-transform");
			AppendValueIfRequired(stringBuilder, _onlyIfCached, "only-if-cached");
			AppendValueIfRequired(stringBuilder, _publicField, "public");
			AppendValueIfRequired(stringBuilder, _mustRevalidate, "must-revalidate");
			AppendValueIfRequired(stringBuilder, _proxyRevalidate, "proxy-revalidate");
			if (_noCache)
			{
				AppendValueWithSeparatorIfRequired(stringBuilder, "no-cache");
				if (_noCacheHeaders != null && _noCacheHeaders.Count > 0)
				{
					stringBuilder.Append("=\"");
					AppendValues(stringBuilder, _noCacheHeaders);
					stringBuilder.Append('"');
				}
			}
			if (_maxAge.HasValue)
			{
				AppendValueWithSeparatorIfRequired(stringBuilder, "max-age");
				stringBuilder.Append('=');
				stringBuilder.Append(((int)_maxAge.Value.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo));
			}
			if (_sharedMaxAge.HasValue)
			{
				AppendValueWithSeparatorIfRequired(stringBuilder, "s-maxage");
				stringBuilder.Append('=');
				stringBuilder.Append(((int)_sharedMaxAge.Value.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo));
			}
			if (_maxStale)
			{
				AppendValueWithSeparatorIfRequired(stringBuilder, "max-stale");
				if (_maxStaleLimit.HasValue)
				{
					stringBuilder.Append('=');
					stringBuilder.Append(((int)_maxStaleLimit.Value.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo));
				}
			}
			if (_minFresh.HasValue)
			{
				AppendValueWithSeparatorIfRequired(stringBuilder, "min-fresh");
				stringBuilder.Append('=');
				stringBuilder.Append(((int)_minFresh.Value.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo));
			}
			if (_privateField)
			{
				AppendValueWithSeparatorIfRequired(stringBuilder, "private");
				if (_privateHeaders != null && _privateHeaders.Count > 0)
				{
					stringBuilder.Append("=\"");
					AppendValues(stringBuilder, _privateHeaders);
					stringBuilder.Append('"');
				}
			}
			NameValueHeaderValue.ToString(_extensions, ',', leadingSeparator: false, stringBuilder);
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is CacheControlHeaderValue cacheControlHeaderValue))
			{
				return false;
			}
			if (_noCache == cacheControlHeaderValue._noCache && _noStore == cacheControlHeaderValue._noStore && !(_maxAge != cacheControlHeaderValue._maxAge))
			{
				TimeSpan? sharedMaxAge = _sharedMaxAge;
				TimeSpan? sharedMaxAge2 = cacheControlHeaderValue._sharedMaxAge;
				if (sharedMaxAge.HasValue == sharedMaxAge2.HasValue && (!sharedMaxAge.HasValue || !(sharedMaxAge.GetValueOrDefault() != sharedMaxAge2.GetValueOrDefault())) && _maxStale == cacheControlHeaderValue._maxStale && !(_maxStaleLimit != cacheControlHeaderValue._maxStaleLimit))
				{
					sharedMaxAge = _minFresh;
					sharedMaxAge2 = cacheControlHeaderValue._minFresh;
					if (sharedMaxAge.HasValue == sharedMaxAge2.HasValue && (!sharedMaxAge.HasValue || !(sharedMaxAge.GetValueOrDefault() != sharedMaxAge2.GetValueOrDefault())) && _noTransform == cacheControlHeaderValue._noTransform && _onlyIfCached == cacheControlHeaderValue._onlyIfCached && _publicField == cacheControlHeaderValue._publicField && _privateField == cacheControlHeaderValue._privateField && _mustRevalidate == cacheControlHeaderValue._mustRevalidate && _proxyRevalidate == cacheControlHeaderValue._proxyRevalidate)
					{
						if (!HeaderUtilities.AreEqualCollections(_noCacheHeaders, cacheControlHeaderValue._noCacheHeaders, StringComparer.OrdinalIgnoreCase))
						{
							return false;
						}
						if (!HeaderUtilities.AreEqualCollections(_privateHeaders, cacheControlHeaderValue._privateHeaders, StringComparer.OrdinalIgnoreCase))
						{
							return false;
						}
						if (!HeaderUtilities.AreEqualCollections(_extensions, cacheControlHeaderValue._extensions))
						{
							return false;
						}
						return true;
					}
				}
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = _noCache.GetHashCode() ^ (_noStore.GetHashCode() << 1) ^ (_maxStale.GetHashCode() << 2) ^ (_noTransform.GetHashCode() << 3) ^ (_onlyIfCached.GetHashCode() << 4) ^ (_publicField.GetHashCode() << 5) ^ (_privateField.GetHashCode() << 6) ^ (_mustRevalidate.GetHashCode() << 7) ^ (_proxyRevalidate.GetHashCode() << 8);
			num = num ^ (_maxAge.HasValue ? (_maxAge.Value.GetHashCode() ^ 1) : 0) ^ (_sharedMaxAge.HasValue ? (_sharedMaxAge.Value.GetHashCode() ^ 2) : 0) ^ (_maxStaleLimit.HasValue ? (_maxStaleLimit.Value.GetHashCode() ^ 4) : 0) ^ (_minFresh.HasValue ? (_minFresh.Value.GetHashCode() ^ 8) : 0);
			if (_noCacheHeaders != null && _noCacheHeaders.Count > 0)
			{
				foreach (string noCacheHeader in _noCacheHeaders)
				{
					num ^= StringComparer.OrdinalIgnoreCase.GetHashCode(noCacheHeader);
				}
			}
			if (_privateHeaders != null && _privateHeaders.Count > 0)
			{
				foreach (string privateHeader in _privateHeaders)
				{
					num ^= StringComparer.OrdinalIgnoreCase.GetHashCode(privateHeader);
				}
			}
			if (_extensions != null && _extensions.Count > 0)
			{
				foreach (NameValueHeaderValue extension in _extensions)
				{
					num ^= extension.GetHashCode();
				}
			}
			return num;
		}

		internal static int GetCacheControlLength(string input, int startIndex, CacheControlHeaderValue storeValue, out CacheControlHeaderValue parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int index = startIndex;
			object parsedValue2 = null;
			List<NameValueHeaderValue> list = new List<NameValueHeaderValue>();
			while (index < input.Length)
			{
				if (!s_nameValueListParser.TryParseValue(input, null, ref index, out parsedValue2))
				{
					return 0;
				}
				list.Add(parsedValue2 as NameValueHeaderValue);
			}
			CacheControlHeaderValue cacheControlHeaderValue = storeValue;
			if (cacheControlHeaderValue == null)
			{
				cacheControlHeaderValue = new CacheControlHeaderValue();
			}
			if (!TrySetCacheControlValues(cacheControlHeaderValue, list))
			{
				return 0;
			}
			if (storeValue == null)
			{
				parsedValue = cacheControlHeaderValue;
			}
			return input.Length - startIndex;
		}

		private static bool TrySetCacheControlValues(CacheControlHeaderValue cc, List<NameValueHeaderValue> nameValueList)
		{
			foreach (NameValueHeaderValue nameValue in nameValueList)
			{
				bool flag = true;
				switch (nameValue.Name.ToLowerInvariant())
				{
				case "no-cache":
					flag = TrySetOptionalTokenList(nameValue, ref cc._noCache, ref cc._noCacheHeaders);
					break;
				case "no-store":
					flag = TrySetTokenOnlyValue(nameValue, ref cc._noStore);
					break;
				case "max-age":
					flag = TrySetTimeSpan(nameValue, ref cc._maxAge);
					break;
				case "max-stale":
					flag = nameValue.Value == null || TrySetTimeSpan(nameValue, ref cc._maxStaleLimit);
					if (flag)
					{
						cc._maxStale = true;
					}
					break;
				case "min-fresh":
					flag = TrySetTimeSpan(nameValue, ref cc._minFresh);
					break;
				case "no-transform":
					flag = TrySetTokenOnlyValue(nameValue, ref cc._noTransform);
					break;
				case "only-if-cached":
					flag = TrySetTokenOnlyValue(nameValue, ref cc._onlyIfCached);
					break;
				case "public":
					flag = TrySetTokenOnlyValue(nameValue, ref cc._publicField);
					break;
				case "private":
					flag = TrySetOptionalTokenList(nameValue, ref cc._privateField, ref cc._privateHeaders);
					break;
				case "must-revalidate":
					flag = TrySetTokenOnlyValue(nameValue, ref cc._mustRevalidate);
					break;
				case "proxy-revalidate":
					flag = TrySetTokenOnlyValue(nameValue, ref cc._proxyRevalidate);
					break;
				case "s-maxage":
					flag = TrySetTimeSpan(nameValue, ref cc._sharedMaxAge);
					break;
				default:
					cc.Extensions.Add(nameValue);
					break;
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}

		private static bool TrySetTokenOnlyValue(NameValueHeaderValue nameValue, ref bool boolField)
		{
			if (nameValue.Value != null)
			{
				return false;
			}
			boolField = true;
			return true;
		}

		private static bool TrySetOptionalTokenList(NameValueHeaderValue nameValue, ref bool boolField, ref ObjectCollection<string> destination)
		{
			if (nameValue.Value == null)
			{
				boolField = true;
				return true;
			}
			string value = nameValue.Value;
			if (value.Length < 3 || value[0] != '"' || value[value.Length - 1] != '"')
			{
				return false;
			}
			int num = 1;
			int num2 = value.Length - 1;
			bool separatorFound = false;
			int num3 = ((destination != null) ? destination.Count : 0);
			while (num < num2)
			{
				num = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(value, num, skipEmptyValues: true, out separatorFound);
				if (num == num2)
				{
					break;
				}
				int tokenLength = HttpRuleParser.GetTokenLength(value, num);
				if (tokenLength == 0)
				{
					return false;
				}
				if (destination == null)
				{
					destination = new ObjectCollection<string>(s_checkIsValidToken);
				}
				destination.Add(value.Substring(num, tokenLength));
				num += tokenLength;
			}
			if (destination != null && destination.Count > num3)
			{
				boolField = true;
				return true;
			}
			return false;
		}

		private static bool TrySetTimeSpan(NameValueHeaderValue nameValue, ref TimeSpan? timeSpan)
		{
			if (nameValue.Value == null)
			{
				return false;
			}
			if (!HeaderUtilities.TryParseInt32(nameValue.Value, out var result))
			{
				return false;
			}
			timeSpan = new TimeSpan(0, 0, result);
			return true;
		}

		private static void AppendValueIfRequired(StringBuilder sb, bool appendValue, string value)
		{
			if (appendValue)
			{
				AppendValueWithSeparatorIfRequired(sb, value);
			}
		}

		private static void AppendValueWithSeparatorIfRequired(StringBuilder sb, string value)
		{
			if (sb.Length > 0)
			{
				sb.Append(", ");
			}
			sb.Append(value);
		}

		private static void AppendValues(StringBuilder sb, ObjectCollection<string> values)
		{
			bool flag = true;
			foreach (string value in values)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					sb.Append(", ");
				}
				sb.Append(value);
			}
		}

		private static void CheckIsValidToken(string item)
		{
			HeaderUtilities.CheckValidToken(item, "item");
		}

		object ICloneable.Clone()
		{
			return new CacheControlHeaderValue(this);
		}
	}
	public class ContentDispositionHeaderValue : ICloneable
	{
		private ObjectCollection<NameValueHeaderValue> _parameters;

		private string _dispositionType;

		public ICollection<NameValueHeaderValue> Parameters
		{
			get
			{
				if (_parameters == null)
				{
					_parameters = new ObjectCollection<NameValueHeaderValue>();
				}
				return _parameters;
			}
		}

		public string Name
		{
			set
			{
				SetName("name", value);
			}
		}

		public string FileName
		{
			set
			{
				SetName("filename", value);
			}
		}

		public string FileNameStar
		{
			set
			{
				SetName("filename*", value);
			}
		}

		internal ContentDispositionHeaderValue()
		{
		}

		protected ContentDispositionHeaderValue(ContentDispositionHeaderValue source)
		{
			_dispositionType = source._dispositionType;
			if (source._parameters == null)
			{
				return;
			}
			foreach (NameValueHeaderValue parameter in source._parameters)
			{
				Parameters.Add((NameValueHeaderValue)((ICloneable)parameter).Clone());
			}
		}

		public ContentDispositionHeaderValue(string dispositionType)
		{
			CheckDispositionTypeFormat(dispositionType, "dispositionType");
			_dispositionType = dispositionType;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			stringBuilder.Append(_dispositionType);
			NameValueHeaderValue.ToString(_parameters, ';', leadingSeparator: true, stringBuilder);
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ContentDispositionHeaderValue contentDispositionHeaderValue))
			{
				return false;
			}
			if (string.Equals(_dispositionType, contentDispositionHeaderValue._dispositionType, StringComparison.OrdinalIgnoreCase))
			{
				return HeaderUtilities.AreEqualCollections(_parameters, contentDispositionHeaderValue._parameters);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return StringComparer.OrdinalIgnoreCase.GetHashCode(_dispositionType) ^ NameValueHeaderValue.GetHashCode(_parameters);
		}

		object ICloneable.Clone()
		{
			return new ContentDispositionHeaderValue(this);
		}

		internal static int GetDispositionTypeLength(string input, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			string dispositionType = null;
			int dispositionTypeExpressionLength = GetDispositionTypeExpressionLength(input, startIndex, out dispositionType);
			if (dispositionTypeExpressionLength == 0)
			{
				return 0;
			}
			int num = startIndex + dispositionTypeExpressionLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			ContentDispositionHeaderValue contentDispositionHeaderValue = new ContentDispositionHeaderValue();
			contentDispositionHeaderValue._dispositionType = dispositionType;
			if (num < input.Length && input[num] == ';')
			{
				num++;
				int nameValueListLength = NameValueHeaderValue.GetNameValueListLength(input, num, ';', (ObjectCollection<NameValueHeaderValue>)contentDispositionHeaderValue.Parameters);
				if (nameValueListLength == 0)
				{
					return 0;
				}
				parsedValue = contentDispositionHeaderValue;
				return num + nameValueListLength - startIndex;
			}
			parsedValue = contentDispositionHeaderValue;
			return num - startIndex;
		}

		private static int GetDispositionTypeExpressionLength(string input, int startIndex, out string dispositionType)
		{
			dispositionType = null;
			int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex);
			if (tokenLength == 0)
			{
				return 0;
			}
			dispositionType = input.Substring(startIndex, tokenLength);
			return tokenLength;
		}

		private static void CheckDispositionTypeFormat(string dispositionType, string parameterName)
		{
			if (string.IsNullOrEmpty(dispositionType))
			{
				throw new ArgumentException("The value cannot be null or empty.", parameterName);
			}
			if (GetDispositionTypeExpressionLength(dispositionType, 0, out var dispositionType2) == 0 || dispositionType2.Length != dispositionType.Length)
			{
				throw new FormatException(string.Format(CultureInfo.InvariantCulture, "The format of value '{0}' is invalid.", dispositionType));
			}
		}

		private void SetName(string parameter, string value)
		{
			NameValueHeaderValue nameValueHeaderValue = NameValueHeaderValue.Find(_parameters, parameter);
			if (string.IsNullOrEmpty(value))
			{
				if (nameValueHeaderValue != null)
				{
					_parameters.Remove(nameValueHeaderValue);
				}
				return;
			}
			string empty = string.Empty;
			empty = ((!parameter.EndsWith("*", StringComparison.Ordinal)) ? EncodeAndQuoteMime(value) : HeaderUtilities.Encode5987(value));
			if (nameValueHeaderValue != null)
			{
				nameValueHeaderValue.Value = empty;
			}
			else
			{
				Parameters.Add(new NameValueHeaderValue(parameter, empty));
			}
		}

		private static string EncodeAndQuoteMime(string input)
		{
			string text = input;
			bool flag = false;
			if (IsQuoted(text))
			{
				text = text.Substring(1, text.Length - 2);
				flag = true;
			}
			if (text.IndexOf("\"", 0, StringComparison.Ordinal) >= 0)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The format of value '{0}' is invalid.", input));
			}
			if (HeaderUtilities.ContainsNonAscii(text))
			{
				flag = true;
				text = EncodeMime(text);
			}
			else if (!flag && HttpRuleParser.GetTokenLength(text, 0) != text.Length)
			{
				flag = true;
			}
			if (flag)
			{
				text = "\"" + text + "\"";
			}
			return text;
		}

		private static bool IsQuoted(string value)
		{
			if (value.Length > 1 && value.StartsWith("\"", StringComparison.Ordinal))
			{
				return value.EndsWith("\"", StringComparison.Ordinal);
			}
			return false;
		}

		private static string EncodeMime(string input)
		{
			string text = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
			return "=?utf-8?B?" + text + "?=";
		}
	}
	public class ContentRangeHeaderValue : ICloneable
	{
		private string _unit;

		private long? _from;

		private long? _to;

		private long? _length;

		public bool HasLength => _length.HasValue;

		public bool HasRange => _from.HasValue;

		private ContentRangeHeaderValue()
		{
		}

		private ContentRangeHeaderValue(ContentRangeHeaderValue source)
		{
			_from = source._from;
			_to = source._to;
			_length = source._length;
			_unit = source._unit;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ContentRangeHeaderValue contentRangeHeaderValue))
			{
				return false;
			}
			if (_from == contentRangeHeaderValue._from && _to == contentRangeHeaderValue._to && _length == contentRangeHeaderValue._length)
			{
				return string.Equals(_unit, contentRangeHeaderValue._unit, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_unit);
			if (HasRange)
			{
				num = num ^ _from.GetHashCode() ^ _to.GetHashCode();
			}
			if (HasLength)
			{
				num ^= _length.GetHashCode();
			}
			return num;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			stringBuilder.Append(_unit);
			stringBuilder.Append(' ');
			if (HasRange)
			{
				stringBuilder.Append(_from.Value.ToString(NumberFormatInfo.InvariantInfo));
				stringBuilder.Append('-');
				stringBuilder.Append(_to.Value.ToString(NumberFormatInfo.InvariantInfo));
			}
			else
			{
				stringBuilder.Append('*');
			}
			stringBuilder.Append('/');
			if (HasLength)
			{
				stringBuilder.Append(_length.Value.ToString(NumberFormatInfo.InvariantInfo));
			}
			else
			{
				stringBuilder.Append('*');
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		internal static int GetContentRangeLength(string input, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex);
			if (tokenLength == 0)
			{
				return 0;
			}
			string unit = input.Substring(startIndex, tokenLength);
			int num = startIndex + tokenLength;
			int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, num);
			if (whitespaceLength == 0)
			{
				return 0;
			}
			num += whitespaceLength;
			if (num == input.Length)
			{
				return 0;
			}
			int fromStartIndex = num;
			int fromLength = 0;
			int toStartIndex = 0;
			int toLength = 0;
			if (!TryGetRangeLength(input, ref num, out fromLength, out toStartIndex, out toLength))
			{
				return 0;
			}
			if (num == input.Length || input[num] != '/')
			{
				return 0;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (num == input.Length)
			{
				return 0;
			}
			int lengthStartIndex = num;
			int lengthLength = 0;
			if (!TryGetLengthLength(input, ref num, out lengthLength))
			{
				return 0;
			}
			if (!TryCreateContentRange(input, unit, fromStartIndex, fromLength, toStartIndex, toLength, lengthStartIndex, lengthLength, out parsedValue))
			{
				return 0;
			}
			return num - startIndex;
		}

		private static bool TryGetLengthLength(string input, ref int current, out int lengthLength)
		{
			lengthLength = 0;
			if (input[current] == '*')
			{
				current++;
			}
			else
			{
				lengthLength = HttpRuleParser.GetNumberLength(input, current, allowDecimal: false);
				if (lengthLength == 0 || lengthLength > 19)
				{
					return false;
				}
				current += lengthLength;
			}
			current += HttpRuleParser.GetWhitespaceLength(input, current);
			return true;
		}

		private static bool TryGetRangeLength(string input, ref int current, out int fromLength, out int toStartIndex, out int toLength)
		{
			fromLength = 0;
			toStartIndex = 0;
			toLength = 0;
			if (input[current] == '*')
			{
				current++;
			}
			else
			{
				fromLength = HttpRuleParser.GetNumberLength(input, current, allowDecimal: false);
				if (fromLength == 0 || fromLength > 19)
				{
					return false;
				}
				current += fromLength;
				current += HttpRuleParser.GetWhitespaceLength(input, current);
				if (current == input.Length || input[current] != '-')
				{
					return false;
				}
				current++;
				current += HttpRuleParser.GetWhitespaceLength(input, current);
				if (current == input.Length)
				{
					return false;
				}
				toStartIndex = current;
				toLength = HttpRuleParser.GetNumberLength(input, current, allowDecimal: false);
				if (toLength == 0 || toLength > 19)
				{
					return false;
				}
				current += toLength;
			}
			current += HttpRuleParser.GetWhitespaceLength(input, current);
			return true;
		}

		private static bool TryCreateContentRange(string input, string unit, int fromStartIndex, int fromLength, int toStartIndex, int toLength, int lengthStartIndex, int lengthLength, out object parsedValue)
		{
			parsedValue = null;
			long result = 0L;
			if (fromLength > 0 && !HeaderUtilities.TryParseInt64(input, fromStartIndex, fromLength, out result))
			{
				return false;
			}
			long result2 = 0L;
			if (toLength > 0 && !HeaderUtilities.TryParseInt64(input, toStartIndex, toLength, out result2))
			{
				return false;
			}
			if (fromLength > 0 && toLength > 0 && result > result2)
			{
				return false;
			}
			long result3 = 0L;
			if (lengthLength > 0 && !HeaderUtilities.TryParseInt64(input, lengthStartIndex, lengthLength, out result3))
			{
				return false;
			}
			if (toLength > 0 && lengthLength > 0 && result2 >= result3)
			{
				return false;
			}
			ContentRangeHeaderValue contentRangeHeaderValue = new ContentRangeHeaderValue();
			contentRangeHeaderValue._unit = unit;
			if (fromLength > 0)
			{
				contentRangeHeaderValue._from = result;
				contentRangeHeaderValue._to = result2;
			}
			if (lengthLength > 0)
			{
				contentRangeHeaderValue._length = result3;
			}
			parsedValue = contentRangeHeaderValue;
			return true;
		}

		object ICloneable.Clone()
		{
			return new ContentRangeHeaderValue(this);
		}
	}
	internal class DateHeaderParser : HttpHeaderParser
	{
		internal static readonly DateHeaderParser Parser = new DateHeaderParser();

		private DateHeaderParser()
			: base(supportsMultipleValues: false)
		{
		}

		public override string ToString(object value)
		{
			return HttpRuleParser.DateToString((DateTimeOffset)value);
		}

		public override bool TryParseValue(string value, object storeValue, ref int index, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(value) || index == value.Length)
			{
				return false;
			}
			string input = value;
			if (index > 0)
			{
				input = value.Substring(index);
			}
			if (!HttpRuleParser.TryStringToDate(input, out var result))
			{
				return false;
			}
			index = value.Length;
			parsedValue = result;
			return true;
		}
	}
	public class EntityTagHeaderValue : ICloneable
	{
		private static EntityTagHeaderValue s_any;

		private string _tag;

		private bool _isWeak;

		public static EntityTagHeaderValue Any
		{
			get
			{
				if (s_any == null)
				{
					s_any = new EntityTagHeaderValue();
					s_any._tag = "*";
					s_any._isWeak = false;
				}
				return s_any;
			}
		}

		private EntityTagHeaderValue(EntityTagHeaderValue source)
		{
			_tag = source._tag;
			_isWeak = source._isWeak;
		}

		private EntityTagHeaderValue()
		{
		}

		public override string ToString()
		{
			if (_isWeak)
			{
				return "W/" + _tag;
			}
			return _tag;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is EntityTagHeaderValue entityTagHeaderValue))
			{
				return false;
			}
			if (_isWeak == entityTagHeaderValue._isWeak)
			{
				return string.Equals(_tag, entityTagHeaderValue._tag, StringComparison.Ordinal);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _tag.GetHashCode() ^ _isWeak.GetHashCode();
		}

		internal static int GetEntityTagLength(string input, int startIndex, out EntityTagHeaderValue parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			bool isWeak = false;
			int num = startIndex;
			char c = input[startIndex];
			if (c == '*')
			{
				parsedValue = Any;
				num++;
			}
			else
			{
				if (c == 'W' || c == 'w')
				{
					num++;
					if (num + 2 >= input.Length || input[num] != '/')
					{
						return 0;
					}
					isWeak = true;
					num++;
					num += HttpRuleParser.GetWhitespaceLength(input, num);
				}
				int startIndex2 = num;
				int length = 0;
				if (HttpRuleParser.GetQuotedStringLength(input, num, out length) != HttpParseResult.Parsed)
				{
					return 0;
				}
				parsedValue = new EntityTagHeaderValue();
				if (length == input.Length)
				{
					parsedValue._tag = input;
					parsedValue._isWeak = false;
				}
				else
				{
					parsedValue._tag = input.Substring(startIndex2, length);
					parsedValue._isWeak = isWeak;
				}
				num += length;
			}
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			return num - startIndex;
		}

		object ICloneable.Clone()
		{
			if (this == s_any)
			{
				return s_any;
			}
			return new EntityTagHeaderValue(this);
		}
	}
	internal sealed class GenericHeaderParser : BaseHeaderParser
	{
		private delegate int GetParsedValueLengthDelegate(string value, int startIndex, out object parsedValue);

		internal static readonly GenericHeaderParser HostParser = new GenericHeaderParser(supportsMultipleValues: false, ParseHost, StringComparer.OrdinalIgnoreCase);

		internal static readonly GenericHeaderParser TokenListParser = new GenericHeaderParser(supportsMultipleValues: true, ParseTokenList, StringComparer.OrdinalIgnoreCase);

		internal static readonly GenericHeaderParser SingleValueNameValueWithParametersParser = new GenericHeaderParser(supportsMultipleValues: false, NameValueWithParametersHeaderValue.GetNameValueWithParametersLength);

		internal static readonly GenericHeaderParser MultipleValueNameValueWithParametersParser = new GenericHeaderParser(supportsMultipleValues: true, NameValueWithParametersHeaderValue.GetNameValueWithParametersLength);

		internal static readonly GenericHeaderParser SingleValueNameValueParser = new GenericHeaderParser(supportsMultipleValues: false, ParseNameValue);

		internal static readonly GenericHeaderParser MultipleValueNameValueParser = new GenericHeaderParser(supportsMultipleValues: true, ParseNameValue);

		internal static readonly GenericHeaderParser MailAddressParser = new GenericHeaderParser(supportsMultipleValues: false, ParseMailAddress);

		internal static readonly GenericHeaderParser SingleValueProductParser = new GenericHeaderParser(supportsMultipleValues: false, ParseProduct);

		internal static readonly GenericHeaderParser MultipleValueProductParser = new GenericHeaderParser(supportsMultipleValues: true, ParseProduct);

		internal static readonly GenericHeaderParser RangeConditionParser = new GenericHeaderParser(supportsMultipleValues: false, RangeConditionHeaderValue.GetRangeConditionLength);

		internal static readonly GenericHeaderParser SingleValueAuthenticationParser = new GenericHeaderParser(supportsMultipleValues: false, AuthenticationHeaderValue.GetAuthenticationLength);

		internal static readonly GenericHeaderParser MultipleValueAuthenticationParser = new GenericHeaderParser(supportsMultipleValues: true, AuthenticationHeaderValue.GetAuthenticationLength);

		internal static readonly GenericHeaderParser RangeParser = new GenericHeaderParser(supportsMultipleValues: false, RangeHeaderValue.GetRangeLength);

		internal static readonly GenericHeaderParser RetryConditionParser = new GenericHeaderParser(supportsMultipleValues: false, RetryConditionHeaderValue.GetRetryConditionLength);

		internal static readonly GenericHeaderParser ContentRangeParser = new GenericHeaderParser(supportsMultipleValues: false, ContentRangeHeaderValue.GetContentRangeLength);

		internal static readonly GenericHeaderParser ContentDispositionParser = new GenericHeaderParser(supportsMultipleValues: false, ContentDispositionHeaderValue.GetDispositionTypeLength);

		internal static readonly GenericHeaderParser SingleValueStringWithQualityParser = new GenericHeaderParser(supportsMultipleValues: false, StringWithQualityHeaderValue.GetStringWithQualityLength);

		internal static readonly GenericHeaderParser MultipleValueStringWithQualityParser = new GenericHeaderParser(supportsMultipleValues: true, StringWithQualityHeaderValue.GetStringWithQualityLength);

		internal static readonly GenericHeaderParser SingleValueEntityTagParser = new GenericHeaderParser(supportsMultipleValues: false, ParseSingleEntityTag);

		internal static readonly GenericHeaderParser MultipleValueEntityTagParser = new GenericHeaderParser(supportsMultipleValues: true, ParseMultipleEntityTags);

		internal static readonly GenericHeaderParser SingleValueViaParser = new GenericHeaderParser(supportsMultipleValues: false, ViaHeaderValue.GetViaLength);

		internal static readonly GenericHeaderParser MultipleValueViaParser = new GenericHeaderParser(supportsMultipleValues: true, ViaHeaderValue.GetViaLength);

		internal static readonly GenericHeaderParser SingleValueWarningParser = new GenericHeaderParser(supportsMultipleValues: false, WarningHeaderValue.GetWarningLength);

		internal static readonly GenericHeaderParser MultipleValueWarningParser = new GenericHeaderParser(supportsMultipleValues: true, WarningHeaderValue.GetWarningLength);

		private GetParsedValueLengthDelegate _getParsedValueLength;

		private IEqualityComparer _comparer;

		public override IEqualityComparer Comparer => _comparer;

		private GenericHeaderParser(bool supportsMultipleValues, GetParsedValueLengthDelegate getParsedValueLength)
			: this(supportsMultipleValues, getParsedValueLength, null)
		{
		}

		private GenericHeaderParser(bool supportsMultipleValues, GetParsedValueLengthDelegate getParsedValueLength, IEqualityComparer comparer)
			: base(supportsMultipleValues)
		{
			_getParsedValueLength = getParsedValueLength;
			_comparer = comparer;
		}

		protected override int GetParsedValueLength(string value, int startIndex, object storeValue, out object parsedValue)
		{
			return _getParsedValueLength(value, startIndex, out parsedValue);
		}

		private static int ParseNameValue(string value, int startIndex, out object parsedValue)
		{
			NameValueHeaderValue parsedValue2 = null;
			int nameValueLength = NameValueHeaderValue.GetNameValueLength(value, startIndex, out parsedValue2);
			parsedValue = parsedValue2;
			return nameValueLength;
		}

		private static int ParseProduct(string value, int startIndex, out object parsedValue)
		{
			ProductHeaderValue parsedValue2 = null;
			int productLength = ProductHeaderValue.GetProductLength(value, startIndex, out parsedValue2);
			parsedValue = parsedValue2;
			return productLength;
		}

		private static int ParseSingleEntityTag(string value, int startIndex, out object parsedValue)
		{
			EntityTagHeaderValue parsedValue2 = null;
			parsedValue = null;
			int entityTagLength = EntityTagHeaderValue.GetEntityTagLength(value, startIndex, out parsedValue2);
			if (parsedValue2 == EntityTagHeaderValue.Any)
			{
				return 0;
			}
			parsedValue = parsedValue2;
			return entityTagLength;
		}

		private static int ParseMultipleEntityTags(string value, int startIndex, out object parsedValue)
		{
			EntityTagHeaderValue parsedValue2 = null;
			int entityTagLength = EntityTagHeaderValue.GetEntityTagLength(value, startIndex, out parsedValue2);
			parsedValue = parsedValue2;
			return entityTagLength;
		}

		private static int ParseMailAddress(string value, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (HttpRuleParser.ContainsInvalidNewLine(value, startIndex))
			{
				return 0;
			}
			string text = value.Substring(startIndex);
			if (!HeaderUtilities.IsValidEmailAddress(text))
			{
				return 0;
			}
			parsedValue = text;
			return text.Length;
		}

		private static int ParseHost(string value, int startIndex, out object parsedValue)
		{
			string host = null;
			int hostLength = HttpRuleParser.GetHostLength(value, startIndex, allowToken: false, out host);
			parsedValue = host;
			return hostLength;
		}

		private static int ParseTokenList(string value, int startIndex, out object parsedValue)
		{
			int tokenLength = HttpRuleParser.GetTokenLength(value, startIndex);
			parsedValue = value.Substring(startIndex, tokenLength);
			return tokenLength;
		}
	}
	internal readonly struct HeaderDescriptor : IEquatable<HeaderDescriptor>
	{
		private readonly string _headerName;

		private readonly KnownHeader _knownHeader;

		public string Name => _headerName;

		public HttpHeaderParser Parser => _knownHeader?.Parser;

		public HttpHeaderType HeaderType
		{
			get
			{
				if (_knownHeader != null)
				{
					return _knownHeader.HeaderType;
				}
				return HttpHeaderType.Custom;
			}
		}

		public KnownHeader KnownHeader => _knownHeader;

		public HeaderDescriptor(KnownHeader knownHeader)
		{
			_knownHeader = knownHeader;
			_headerName = knownHeader.Name;
		}

		private HeaderDescriptor(string headerName)
		{
			_headerName = headerName;
			_knownHeader = null;
		}

		public bool Equals(HeaderDescriptor other)
		{
			if (_knownHeader != null)
			{
				return _knownHeader == other._knownHeader;
			}
			return string.Equals(_headerName, other._headerName, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode()
		{
			return _knownHeader?.GetHashCode() ?? StringComparer.OrdinalIgnoreCase.GetHashCode(_headerName);
		}

		public override bool Equals(object obj)
		{
			throw new InvalidOperationException();
		}

		public static bool TryGet(string headerName, out HeaderDescriptor descriptor)
		{
			KnownHeader knownHeader = KnownHeaders.TryGetKnownHeader(headerName);
			if (knownHeader != null)
			{
				descriptor = new HeaderDescriptor(knownHeader);
				return true;
			}
			if (!HttpRuleParser.IsToken(headerName))
			{
				descriptor = default(HeaderDescriptor);
				return false;
			}
			descriptor = new HeaderDescriptor(headerName);
			return true;
		}

		public static bool TryGet(ReadOnlySpan<byte> headerName, out HeaderDescriptor descriptor)
		{
			KnownHeader knownHeader = KnownHeaders.TryGetKnownHeader(headerName);
			if (knownHeader != null)
			{
				descriptor = new HeaderDescriptor(knownHeader);
				return true;
			}
			if (!HttpRuleParser.IsToken(headerName))
			{
				descriptor = default(HeaderDescriptor);
				return false;
			}
			descriptor = new HeaderDescriptor(HttpRuleParser.GetTokenString(headerName));
			return true;
		}

		public HeaderDescriptor AsCustomHeader()
		{
			return new HeaderDescriptor(_knownHeader.Name);
		}

		public string GetHeaderValue(ReadOnlySpan<byte> headerValue)
		{
			if (headerValue.Length == 0)
			{
				return string.Empty;
			}
			if (_knownHeader != null && _knownHeader.KnownValues != null)
			{
				string[] knownValues = _knownHeader.KnownValues;
				for (int i = 0; i < knownValues.Length; i++)
				{
					if (ByteArrayHelpers.EqualsOrdinalAsciiIgnoreCase(knownValues[i], headerValue))
					{
						return knownValues[i];
					}
				}
			}
			return HttpRuleParser.DefaultHttpEncoding.GetString(headerValue);
		}
	}
	internal static class HeaderUtilities
	{
		internal static readonly TransferCodingHeaderValue TransferEncodingChunked = new TransferCodingHeaderValue("chunked");

		internal static readonly NameValueWithParametersHeaderValue ExpectContinue = new NameValueWithParametersHeaderValue("100-continue");

		internal static readonly Action<HttpHeaderValueCollection<string>, string> TokenValidator = ValidateToken;

		private static readonly char[] s_hexUpperChars = new char[16]
		{
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F'
		};

		internal static bool ContainsNonAscii(string input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] > '\u007f')
				{
					return true;
				}
			}
			return false;
		}

		internal static string Encode5987(string input)
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			byte[] array = ArrayPool<byte>.Shared.Rent(Encoding.UTF8.GetMaxByteCount(input.Length));
			int bytes = Encoding.UTF8.GetBytes(input, 0, input.Length, array, 0);
			stringBuilder.Append("utf-8''");
			for (int i = 0; i < bytes; i++)
			{
				byte b = array[i];
				if (b > 127)
				{
					AddHexEscaped(b, stringBuilder);
				}
				else if (!HttpRuleParser.IsTokenChar((char)b) || b == 42 || b == 39 || b == 37)
				{
					AddHexEscaped(b, stringBuilder);
				}
				else
				{
					stringBuilder.Append((char)b);
				}
			}
			Array.Clear(array, 0, bytes);
			ArrayPool<byte>.Shared.Return(array);
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		private static void AddHexEscaped(byte c, StringBuilder destination)
		{
			destination.Append('%');
			destination.Append(s_hexUpperChars[(c & 0xF0) >> 4]);
			destination.Append(s_hexUpperChars[c & 0xF]);
		}

		internal static void CheckValidToken(string value, string parameterName)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("The value cannot be null or empty.", parameterName);
			}
			if (HttpRuleParser.GetTokenLength(value, 0) != value.Length)
			{
				throw new FormatException(string.Format(CultureInfo.InvariantCulture, "The format of value '{0}' is invalid.", value));
			}
		}

		internal static bool AreEqualCollections<T>(ObjectCollection<T> x, ObjectCollection<T> y) where T : class
		{
			return AreEqualCollections(x, y, null);
		}

		internal static bool AreEqualCollections<T>(ObjectCollection<T> x, ObjectCollection<T> y, IEqualityComparer<T> comparer) where T : class
		{
			if (x == null)
			{
				if (y != null)
				{
					return y.Count == 0;
				}
				return true;
			}
			if (y == null)
			{
				return x.Count == 0;
			}
			if (x.Count != y.Count)
			{
				return false;
			}
			if (x.Count == 0)
			{
				return true;
			}
			bool[] array = new bool[x.Count];
			int num = 0;
			foreach (T item in x)
			{
				num = 0;
				bool flag = false;
				foreach (T item2 in y)
				{
					if (!array[num] && ((comparer == null && item.Equals(item2)) || (comparer != null && comparer.Equals(item, item2))))
					{
						array[num] = true;
						flag = true;
						break;
					}
					num++;
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}

		internal static int GetNextNonEmptyOrWhitespaceIndex(string input, int startIndex, bool skipEmptyValues, out bool separatorFound)
		{
			separatorFound = false;
			int num = startIndex + HttpRuleParser.GetWhitespaceLength(input, startIndex);
			if (num == input.Length || input[num] != ',')
			{
				return num;
			}
			separatorFound = true;
			num++;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (skipEmptyValues)
			{
				while (num < input.Length && input[num] == ',')
				{
					num++;
					num += HttpRuleParser.GetWhitespaceLength(input, num);
				}
			}
			return num;
		}

		internal static bool TryParseInt32(string value, out int result)
		{
			return TryParseInt32(value, 0, value.Length, out result);
		}

		internal static bool TryParseInt32(string value, int offset, int length, out int result)
		{
			if (offset < 0 || length < 0 || offset > value.Length - length)
			{
				result = 0;
				return false;
			}
			int num = 0;
			int num2 = offset;
			int num3 = offset + length;
			while (num2 < num3)
			{
				int num4 = value[num2++] - 48;
				if ((uint)num4 > 9u || num > 214748364 || (num == 214748364 && num4 > 7))
				{
					result = 0;
					return false;
				}
				num = num * 10 + num4;
			}
			result = num;
			return true;
		}

		internal static bool TryParseInt64(string value, int offset, int length, out long result)
		{
			if (offset < 0 || length < 0 || offset > value.Length - length)
			{
				result = 0L;
				return false;
			}
			long num = 0L;
			int num2 = offset;
			int num3 = offset + length;
			while (num2 < num3)
			{
				int num4 = value[num2++] - 48;
				if ((uint)num4 > 9u || num > 922337203685477580L || (num == 922337203685477580L && num4 > 7))
				{
					result = 0L;
					return false;
				}
				num = num * 10 + num4;
			}
			result = num;
			return true;
		}

		internal static string DumpHeaders(params HttpHeaders[] headers)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\r\n");
			for (int i = 0; i < headers.Length; i++)
			{
				if (headers[i] == null)
				{
					continue;
				}
				foreach (KeyValuePair<string, IEnumerable<string>> item in headers[i])
				{
					foreach (string item2 in item.Value)
					{
						stringBuilder.Append("  ");
						stringBuilder.Append(item.Key);
						stringBuilder.Append(": ");
						stringBuilder.Append(item2);
						stringBuilder.Append("\r\n");
					}
				}
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}

		internal static bool IsValidEmailAddress(string value)
		{
			try
			{
				MailAddressParser.ParseAddress(value);
				return true;
			}
			catch (FormatException ex)
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(null, global::SR.Format("Value '{0}' is not a valid email address. Error: {1}", value, ex.Message));
				}
			}
			return false;
		}

		private static void ValidateToken(HttpHeaderValueCollection<string> collection, string value)
		{
			CheckValidToken(value, "item");
		}
	}
	public sealed class HttpContentHeaders : HttpHeaders
	{
		private readonly HttpContent _parent;

		private bool _contentLengthSet;

		private HttpHeaderValueCollection<string> _contentEncoding;

		public ContentDispositionHeaderValue ContentDisposition
		{
			get
			{
				return (ContentDispositionHeaderValue)GetParsedValues(KnownHeaders.ContentDisposition.Descriptor);
			}
			set
			{
				SetOrRemoveParsedValue(KnownHeaders.ContentDisposition.Descriptor, value);
			}
		}

		public ICollection<string> ContentEncoding
		{
			get
			{
				if (_contentEncoding == null)
				{
					_contentEncoding = new HttpHeaderValueCollection<string>(KnownHeaders.ContentEncoding.Descriptor, this, HeaderUtilities.TokenValidator);
				}
				return _contentEncoding;
			}
		}

		public long? ContentLength
		{
			get
			{
				object parsedValues = GetParsedValues(KnownHeaders.ContentLength.Descriptor);
				if (!_contentLengthSet && parsedValues == null)
				{
					long? computedOrBufferLength = _parent.GetComputedOrBufferLength();
					if (computedOrBufferLength.HasValue)
					{
						SetParsedValue(KnownHeaders.ContentLength.Descriptor, computedOrBufferLength.Value);
					}
					return computedOrBufferLength;
				}
				if (parsedValues == null)
				{
					return null;
				}
				return (long)parsedValues;
			}
			set
			{
				SetOrRemoveParsedValue(KnownHeaders.ContentLength.Descriptor, value);
				_contentLengthSet = true;
			}
		}

		public MediaTypeHeaderValue ContentType
		{
			get
			{
				return (MediaTypeHeaderValue)GetParsedValues(KnownHeaders.ContentType.Descriptor);
			}
			set
			{
				SetOrRemoveParsedValue(KnownHeaders.ContentType.Descriptor, value);
			}
		}

		public DateTimeOffset? Expires
		{
			set
			{
				SetOrRemoveParsedValue(KnownHeaders.Expires.Descriptor, value);
			}
		}

		internal HttpContentHeaders(HttpContent parent)
			: base(HttpHeaderType.Content | HttpHeaderType.Custom, HttpHeaderType.None)
		{
			_parent = parent;
		}
	}
	internal sealed class HttpGeneralHeaders
	{
		private HttpHeaderValueCollection<string> _connection;

		private HttpHeaderValueCollection<TransferCodingHeaderValue> _transferEncoding;

		private HttpHeaders _parent;

		private bool _transferEncodingChunkedSet;

		private bool _connectionCloseSet;

		public bool? ConnectionClose
		{
			get
			{
				return GetConnectionClose(_parent, this);
			}
			set
			{
				if (value == true)
				{
					_connectionCloseSet = true;
					ConnectionCore.SetSpecialValue();
				}
				else
				{
					_connectionCloseSet = value.HasValue;
					ConnectionCore.RemoveSpecialValue();
				}
			}
		}

		public bool? TransferEncodingChunked
		{
			get
			{
				return GetTransferEncodingChunked(_parent, this);
			}
			set
			{
				if (value == true)
				{
					_transferEncodingChunkedSet = true;
					TransferEncodingCore.SetSpecialValue();
				}
				else
				{
					_transferEncodingChunkedSet = value.HasValue;
					TransferEncodingCore.RemoveSpecialValue();
				}
			}
		}

		private HttpHeaderValueCollection<string> ConnectionCore
		{
			get
			{
				if (_connection == null)
				{
					_connection = new HttpHeaderValueCollection<string>(KnownHeaders.Connection.Descriptor, _parent, "close", HeaderUtilities.TokenValidator);
				}
				return _connection;
			}
		}

		private HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncodingCore
		{
			get
			{
				if (_transferEncoding == null)
				{
					_transferEncoding = new HttpHeaderValueCollection<TransferCodingHeaderValue>(KnownHeaders.TransferEncoding.Descriptor, _parent, HeaderUtilities.TransferEncodingChunked);
				}
				return _transferEncoding;
			}
		}

		internal static bool? GetConnectionClose(HttpHeaders parent, HttpGeneralHeaders headers)
		{
			if (headers?._connection != null)
			{
				if (headers._connection.IsSpecialValueSet)
				{
					return true;
				}
			}
			else if (parent.ContainsParsedValue(KnownHeaders.Connection.Descriptor, "close"))
			{
				return true;
			}
			if (headers != null && headers._connectionCloseSet)
			{
				return false;
			}
			return null;
		}

		internal static bool? GetTransferEncodingChunked(HttpHeaders parent, HttpGeneralHeaders headers)
		{
			if (headers?._transferEncoding != null)
			{
				if (headers._transferEncoding.IsSpecialValueSet)
				{
					return true;
				}
			}
			else if (parent.ContainsParsedValue(KnownHeaders.TransferEncoding.Descriptor, HeaderUtilities.TransferEncodingChunked))
			{
				return true;
			}
			if (headers != null && headers._transferEncodingChunkedSet)
			{
				return false;
			}
			return null;
		}

		internal HttpGeneralHeaders(HttpHeaders parent)
		{
			_parent = parent;
		}

		internal void AddSpecialsFrom(HttpGeneralHeaders sourceHeaders)
		{
			if (!TransferEncodingChunked.HasValue)
			{
				TransferEncodingChunked = sourceHeaders.TransferEncodingChunked;
			}
			if (!ConnectionClose.HasValue)
			{
				ConnectionClose = sourceHeaders.ConnectionClose;
			}
		}
	}
	internal abstract class HttpHeaderParser
	{
		private bool _supportsMultipleValues;

		private string _separator;

		public bool SupportsMultipleValues => _supportsMultipleValues;

		public string Separator => _separator;

		public virtual IEqualityComparer Comparer => null;

		protected HttpHeaderParser(bool supportsMultipleValues)
		{
			_supportsMultipleValues = supportsMultipleValues;
			if (supportsMultipleValues)
			{
				_separator = ", ";
			}
		}

		protected HttpHeaderParser(bool supportsMultipleValues, string separator)
		{
			_supportsMultipleValues = supportsMultipleValues;
			_separator = separator;
		}

		public abstract bool TryParseValue(string value, object storeValue, ref int index, out object parsedValue);

		public object ParseValue(string value, object storeValue, ref int index)
		{
			object parsedValue = null;
			if (!TryParseValue(value, storeValue, ref index, out parsedValue))
			{
				throw new FormatException(string.Format(CultureInfo.InvariantCulture, "The format of value '{0}' is invalid.", (value == null) ? "<null>" : value.Substring(index)));
			}
			return parsedValue;
		}

		public virtual string ToString(object value)
		{
			return value.ToString();
		}
	}
	[Flags]
	internal enum HttpHeaderType : byte
	{
		General = 1,
		Request = 2,
		Response = 4,
		Content = 8,
		Custom = 0x10,
		All = 0x1F,
		None = 0
	}
	public sealed class HttpHeaderValueCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable where T : class
	{
		private HeaderDescriptor _descriptor;

		private HttpHeaders _store;

		private T _specialValue;

		private Action<HttpHeaderValueCollection<T>, T> _validator;

		public int Count => GetCount();

		public bool IsReadOnly => false;

		internal bool IsSpecialValueSet
		{
			get
			{
				if (_specialValue == null)
				{
					return false;
				}
				return _store.ContainsParsedValue(_descriptor, _specialValue);
			}
		}

		internal HttpHeaderValueCollection(HeaderDescriptor descriptor, HttpHeaders store)
			: this(descriptor, store, (T)null, (Action<HttpHeaderValueCollection<T>, T>)null)
		{
		}

		internal HttpHeaderValueCollection(HeaderDescriptor descriptor, HttpHeaders store, Action<HttpHeaderValueCollection<T>, T> validator)
			: this(descriptor, store, (T)null, validator)
		{
		}

		internal HttpHeaderValueCollection(HeaderDescriptor descriptor, HttpHeaders store, T specialValue)
			: this(descriptor, store, specialValue, (Action<HttpHeaderValueCollection<T>, T>)null)
		{
		}

		internal HttpHeaderValueCollection(HeaderDescriptor descriptor, HttpHeaders store, T specialValue, Action<HttpHeaderValueCollection<T>, T> validator)
		{
			_store = store;
			_descriptor = descriptor;
			_specialValue = specialValue;
			_validator = validator;
		}

		public void Add(T item)
		{
			CheckValue(item);
			_store.AddParsedValue(_descriptor, item);
		}

		public void Clear()
		{
			_store.Remove(_descriptor);
		}

		public bool Contains(T item)
		{
			CheckValue(item);
			return _store.ContainsParsedValue(_descriptor, item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0 || arrayIndex > array.Length)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			object parsedValues = _store.GetParsedValues(_descriptor);
			if (parsedValues == null)
			{
				return;
			}
			if (!(parsedValues is List<object> list))
			{
				if (arrayIndex == array.Length)
				{
					throw new ArgumentException("The number of elements is greater than the available space from arrayIndex to the end of the destination array.");
				}
				array[arrayIndex] = parsedValues as T;
			}
			else
			{
				list.CopyTo(array, arrayIndex);
			}
		}

		public bool Remove(T item)
		{
			CheckValue(item);
			return _store.RemoveParsedValue(_descriptor, item);
		}

		public IEnumerator<T> GetEnumerator()
		{
			object parsedValues = _store.GetParsedValues(_descriptor);
			if (parsedValues == null)
			{
				yield break;
			}
			if (!(parsedValues is List<object> list))
			{
				yield return parsedValues as T;
				yield break;
			}
			foreach (object item in list)
			{
				yield return item as T;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override string ToString()
		{
			return _store.GetHeaderString(_descriptor);
		}

		internal void SetSpecialValue()
		{
			if (!_store.ContainsParsedValue(_descriptor, _specialValue))
			{
				_store.AddParsedValue(_descriptor, _specialValue);
			}
		}

		internal void RemoveSpecialValue()
		{
			_store.RemoveParsedValue(_descriptor, _specialValue);
		}

		private void CheckValue(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (_validator != null)
			{
				_validator(this, item);
			}
		}

		private int GetCount()
		{
			object parsedValues = _store.GetParsedValues(_descriptor);
			if (parsedValues == null)
			{
				return 0;
			}
			if (!(parsedValues is List<object> list))
			{
				return 1;
			}
			return list.Count;
		}
	}
	public abstract class HttpHeaders : IEnumerable<KeyValuePair<string, IEnumerable<string>>>, IEnumerable
	{
		private enum StoreLocation
		{
			Raw,
			Invalid,
			Parsed
		}

		private class HeaderStoreItemInfo
		{
			private object _rawValue;

			private object _invalidValue;

			private object _parsedValue;

			internal object RawValue
			{
				get
				{
					return _rawValue;
				}
				set
				{
					_rawValue = value;
				}
			}

			internal object InvalidValue
			{
				get
				{
					return _invalidValue;
				}
				set
				{
					_invalidValue = value;
				}
			}

			internal object ParsedValue
			{
				get
				{
					return _parsedValue;
				}
				set
				{
					_parsedValue = value;
				}
			}

			internal bool IsEmpty
			{
				get
				{
					if (_rawValue == null && _invalidValue == null)
					{
						return _parsedValue == null;
					}
					return false;
				}
			}

			internal bool CanAddValue(HttpHeaderParser parser)
			{
				if (!parser.SupportsMultipleValues)
				{
					if (_invalidValue == null)
					{
						return _parsedValue == null;
					}
					return false;
				}
				return true;
			}

			internal HeaderStoreItemInfo()
			{
			}
		}

		private Dictionary<HeaderDescriptor, HeaderStoreItemInfo> _headerStore;

		private readonly HttpHeaderType _allowedHeaderTypes;

		private readonly HttpHeaderType _treatAsCustomHeaderTypes;

		internal HttpHeaders(HttpHeaderType allowedHeaderTypes, HttpHeaderType treatAsCustomHeaderTypes)
		{
			_allowedHeaderTypes = allowedHeaderTypes;
			_treatAsCustomHeaderTypes = treatAsCustomHeaderTypes;
		}

		public void Add(string name, string value)
		{
			Add(GetHeaderDescriptor(name), value);
		}

		internal void Add(HeaderDescriptor descriptor, string value)
		{
			PrepareHeaderInfoForAdd(descriptor, out var info, out var addToStore);
			ParseAndAddValue(descriptor, info, value);
			if (addToStore && info.ParsedValue != null)
			{
				AddHeaderToStore(descriptor, info);
			}
		}

		public bool TryAddWithoutValidation(string name, string value)
		{
			if (TryGetHeaderDescriptor(name, out var descriptor))
			{
				return TryAddWithoutValidation(descriptor, value);
			}
			return false;
		}

		internal bool TryAddWithoutValidation(HeaderDescriptor descriptor, string value)
		{
			if (value == null)
			{
				value = string.Empty;
			}
			AddValue(GetOrCreateHeaderInfo(descriptor, parseRawValues: false), value, StoreLocation.Raw);
			return true;
		}

		public bool TryAddWithoutValidation(string name, IEnumerable<string> values)
		{
			if (TryGetHeaderDescriptor(name, out var descriptor))
			{
				return TryAddWithoutValidation(descriptor, values);
			}
			return false;
		}

		internal bool TryAddWithoutValidation(HeaderDescriptor descriptor, IEnumerable<string> values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			HeaderStoreItemInfo orCreateHeaderInfo = GetOrCreateHeaderInfo(descriptor, parseRawValues: false);
			foreach (string value in values)
			{
				AddValue(orCreateHeaderInfo, value ?? string.Empty, StoreLocation.Raw);
			}
			return true;
		}

		public void Clear()
		{
			if (_headerStore != null)
			{
				_headerStore.Clear();
			}
		}

		public bool Remove(string name)
		{
			return Remove(GetHeaderDescriptor(name));
		}

		public IEnumerable<string> GetValues(string name)
		{
			return GetValues(GetHeaderDescriptor(name));
		}

		internal IEnumerable<string> GetValues(HeaderDescriptor descriptor)
		{
			if (!TryGetValues(descriptor, out var values))
			{
				throw new InvalidOperationException("The given header was not found.");
			}
			return values;
		}

		public bool TryGetValues(string name, out IEnumerable<string> values)
		{
			if (!TryGetHeaderDescriptor(name, out var descriptor))
			{
				values = null;
				return false;
			}
			return TryGetValues(descriptor, out values);
		}

		internal bool TryGetValues(HeaderDescriptor descriptor, out IEnumerable<string> values)
		{
			if (_headerStore == null)
			{
				values = null;
				return false;
			}
			HeaderStoreItemInfo info = null;
			if (TryGetAndParseHeaderInfo(descriptor, out info))
			{
				values = GetValuesAsStrings(descriptor, info);
				return true;
			}
			values = null;
			return false;
		}

		public override string ToString()
		{
			if (_headerStore == null || _headerStore.Count == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> headerString in GetHeaderStrings())
			{
				stringBuilder.Append(headerString.Key);
				stringBuilder.Append(": ");
				stringBuilder.Append(headerString.Value);
				stringBuilder.Append("\r\n");
			}
			return stringBuilder.ToString();
		}

		internal IEnumerable<KeyValuePair<string, string>> GetHeaderStrings()
		{
			if (_headerStore == null)
			{
				yield break;
			}
			foreach (KeyValuePair<HeaderDescriptor, HeaderStoreItemInfo> item in _headerStore)
			{
				string headerString = GetHeaderString(item.Key, item.Value);
				yield return new KeyValuePair<string, string>(item.Key.Name, headerString);
			}
		}

		internal string GetHeaderString(HeaderDescriptor descriptor, object exclude = null)
		{
			if (!TryGetHeaderInfo(descriptor, out var info))
			{
				return string.Empty;
			}
			return GetHeaderString(descriptor, info, exclude);
		}

		private string GetHeaderString(HeaderDescriptor descriptor, HeaderStoreItemInfo info, object exclude = null)
		{
			string[] valuesAsStrings = GetValuesAsStrings(descriptor, info, exclude);
			if (valuesAsStrings.Length == 1)
			{
				return valuesAsStrings[0];
			}
			string separator = ", ";
			if (descriptor.Parser != null && descriptor.Parser.SupportsMultipleValues)
			{
				separator = descriptor.Parser.Separator;
			}
			return string.Join(separator, valuesAsStrings);
		}

		public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator()
		{
			if (_headerStore == null || _headerStore.Count <= 0)
			{
				return ((IEnumerable<KeyValuePair<string, IEnumerable<string>>>)Array.Empty<KeyValuePair<string, IEnumerable<string>>>()).GetEnumerator();
			}
			return GetEnumeratorCore();
		}

		private IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumeratorCore()
		{
			List<HeaderDescriptor> invalidHeaders = null;
			foreach (KeyValuePair<HeaderDescriptor, HeaderStoreItemInfo> item in _headerStore)
			{
				HeaderDescriptor key = item.Key;
				HeaderStoreItemInfo value = item.Value;
				if (!ParseRawHeaderValues(key, value, removeEmptyHeader: false))
				{
					if (invalidHeaders == null)
					{
						invalidHeaders = new List<HeaderDescriptor>();
					}
					invalidHeaders.Add(key);
				}
				else
				{
					string[] valuesAsStrings = GetValuesAsStrings(key, value);
					yield return new KeyValuePair<string, IEnumerable<string>>(key.Name, valuesAsStrings);
				}
			}
			if (invalidHeaders == null)
			{
				yield break;
			}
			foreach (HeaderDescriptor item2 in invalidHeaders)
			{
				_headerStore.Remove(item2);
			}
		}

		internal IEnumerable<KeyValuePair<HeaderDescriptor, string[]>> GetHeaderDescriptorsAndValues()
		{
			if (_headerStore == null || _headerStore.Count <= 0)
			{
				return Array.Empty<KeyValuePair<HeaderDescriptor, string[]>>();
			}
			return GetHeaderDescriptorsAndValuesCore();
		}

		private IEnumerable<KeyValuePair<HeaderDescriptor, string[]>> GetHeaderDescriptorsAndValuesCore()
		{
			List<HeaderDescriptor> invalidHeaders = null;
			foreach (KeyValuePair<HeaderDescriptor, HeaderStoreItemInfo> item in _headerStore)
			{
				HeaderDescriptor key = item.Key;
				HeaderStoreItemInfo value = item.Value;
				if (!ParseRawHeaderValues(key, value, removeEmptyHeader: false))
				{
					if (invalidHeaders == null)
					{
						invalidHeaders = new List<HeaderDescriptor>();
					}
					invalidHeaders.Add(key);
				}
				else
				{
					string[] valuesAsStrings = GetValuesAsStrings(key, value);
					yield return new KeyValuePair<HeaderDescriptor, string[]>(key, valuesAsStrings);
				}
			}
			if (invalidHeaders == null)
			{
				yield break;
			}
			foreach (HeaderDescriptor item2 in invalidHeaders)
			{
				_headerStore.Remove(item2);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal void AddParsedValue(HeaderDescriptor descriptor, object value)
		{
			AddValue(GetOrCreateHeaderInfo(descriptor, parseRawValues: true), value, StoreLocation.Parsed);
		}

		internal void SetParsedValue(HeaderDescriptor descriptor, object value)
		{
			HeaderStoreItemInfo orCreateHeaderInfo = GetOrCreateHeaderInfo(descriptor, parseRawValues: true);
			orCreateHeaderInfo.InvalidValue = null;
			orCreateHeaderInfo.ParsedValue = null;
			orCreateHeaderInfo.RawValue = null;
			AddValue(orCreateHeaderInfo, value, StoreLocation.Parsed);
		}

		internal void SetOrRemoveParsedValue(HeaderDescriptor descriptor, object value)
		{
			if (value == null)
			{
				Remove(descriptor);
			}
			else
			{
				SetParsedValue(descriptor, value);
			}
		}

		internal bool Remove(HeaderDescriptor descriptor)
		{
			if (_headerStore == null)
			{
				return false;
			}
			return _headerStore.Remove(descriptor);
		}

		internal bool RemoveParsedValue(HeaderDescriptor descriptor, object value)
		{
			if (_headerStore == null)
			{
				return false;
			}
			HeaderStoreItemInfo info = null;
			if (TryGetAndParseHeaderInfo(descriptor, out info))
			{
				bool result = false;
				if (info.ParsedValue == null)
				{
					return false;
				}
				IEqualityComparer comparer = descriptor.Parser.Comparer;
				if (!(info.ParsedValue is List<object> list))
				{
					if (AreEqual(value, info.ParsedValue, comparer))
					{
						info.ParsedValue = null;
						result = true;
					}
				}
				else
				{
					foreach (object item in list)
					{
						if (AreEqual(value, item, comparer))
						{
							result = list.Remove(item);
							break;
						}
					}
					if (list.Count == 0)
					{
						info.ParsedValue = null;
					}
				}
				if (info.IsEmpty)
				{
					Remove(descriptor);
				}
				return result;
			}
			return false;
		}

		internal bool ContainsParsedValue(HeaderDescriptor descriptor, object value)
		{
			if (_headerStore == null)
			{
				return false;
			}
			HeaderStoreItemInfo info = null;
			if (TryGetAndParseHeaderInfo(descriptor, out info))
			{
				if (info.ParsedValue == null)
				{
					return false;
				}
				List<object> list = info.ParsedValue as List<object>;
				IEqualityComparer comparer = descriptor.Parser.Comparer;
				if (list == null)
				{
					return AreEqual(value, info.ParsedValue, comparer);
				}
				foreach (object item in list)
				{
					if (AreEqual(value, item, comparer))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		internal virtual void AddHeaders(HttpHeaders sourceHeaders)
		{
			if (sourceHeaders._headerStore == null)
			{
				return;
			}
			List<HeaderDescriptor> list = null;
			foreach (KeyValuePair<HeaderDescriptor, HeaderStoreItemInfo> item in sourceHeaders._headerStore)
			{
				if (_headerStore != null && _headerStore.ContainsKey(item.Key))
				{
					continue;
				}
				HeaderStoreItemInfo value = item.Value;
				if (!sourceHeaders.ParseRawHeaderValues(item.Key, value, removeEmptyHeader: false))
				{
					if (list == null)
					{
						list = new List<HeaderDescriptor>();
					}
					list.Add(item.Key);
				}
				else
				{
					AddHeaderInfo(item.Key, value);
				}
			}
			if (list == null)
			{
				return;
			}
			foreach (HeaderDescriptor item2 in list)
			{
				sourceHeaders._headerStore.Remove(item2);
			}
		}

		private void AddHeaderInfo(HeaderDescriptor descriptor, HeaderStoreItemInfo sourceInfo)
		{
			HeaderStoreItemInfo headerStoreItemInfo = CreateAndAddHeaderToStore(descriptor);
			if (descriptor.Parser == null)
			{
				headerStoreItemInfo.ParsedValue = CloneStringHeaderInfoValues(sourceInfo.ParsedValue);
				return;
			}
			headerStoreItemInfo.InvalidValue = CloneStringHeaderInfoValues(sourceInfo.InvalidValue);
			if (sourceInfo.ParsedValue == null)
			{
				return;
			}
			if (!(sourceInfo.ParsedValue is List<object> list))
			{
				CloneAndAddValue(headerStoreItemInfo, sourceInfo.ParsedValue);
				return;
			}
			foreach (object item in list)
			{
				CloneAndAddValue(headerStoreItemInfo, item);
			}
		}

		private static void CloneAndAddValue(HeaderStoreItemInfo destinationInfo, object source)
		{
			if (source is ICloneable cloneable)
			{
				AddValue(destinationInfo, cloneable.Clone(), StoreLocation.Parsed);
			}
			else
			{
				AddValue(destinationInfo, source, StoreLocation.Parsed);
			}
		}

		private static object CloneStringHeaderInfoValues(object source)
		{
			if (source == null)
			{
				return null;
			}
			if (!(source is List<object> collection))
			{
				return source;
			}
			return new List<object>(collection);
		}

		private HeaderStoreItemInfo GetOrCreateHeaderInfo(HeaderDescriptor descriptor, bool parseRawValues)
		{
			HeaderStoreItemInfo info = null;
			bool flag = false;
			if (!((!parseRawValues) ? TryGetHeaderInfo(descriptor, out info) : TryGetAndParseHeaderInfo(descriptor, out info)))
			{
				info = CreateAndAddHeaderToStore(descriptor);
			}
			return info;
		}

		private HeaderStoreItemInfo CreateAndAddHeaderToStore(HeaderDescriptor descriptor)
		{
			HeaderStoreItemInfo headerStoreItemInfo = new HeaderStoreItemInfo();
			AddHeaderToStore(descriptor, headerStoreItemInfo);
			return headerStoreItemInfo;
		}

		private void AddHeaderToStore(HeaderDescriptor descriptor, HeaderStoreItemInfo info)
		{
			if (_headerStore == null)
			{
				_headerStore = new Dictionary<HeaderDescriptor, HeaderStoreItemInfo>();
			}
			_headerStore.Add(descriptor, info);
		}

		private bool TryGetHeaderInfo(HeaderDescriptor descriptor, out HeaderStoreItemInfo info)
		{
			if (_headerStore == null)
			{
				info = null;
				return false;
			}
			return _headerStore.TryGetValue(descriptor, out info);
		}

		private bool TryGetAndParseHeaderInfo(HeaderDescriptor key, out HeaderStoreItemInfo info)
		{
			if (TryGetHeaderInfo(key, out info))
			{
				return ParseRawHeaderValues(key, info, removeEmptyHeader: true);
			}
			return false;
		}

		private bool ParseRawHeaderValues(HeaderDescriptor descriptor, HeaderStoreItemInfo info, bool removeEmptyHeader)
		{
			lock (info)
			{
				if (info.RawValue != null)
				{
					if (!(info.RawValue is List<string> rawValues))
					{
						ParseSingleRawHeaderValue(descriptor, info);
					}
					else
					{
						ParseMultipleRawHeaderValues(descriptor, info, rawValues);
					}
					info.RawValue = null;
					if (info.InvalidValue == null && info.ParsedValue == null)
					{
						if (removeEmptyHeader)
						{
							_headerStore.Remove(descriptor);
						}
						return false;
					}
				}
			}
			return true;
		}

		private static void ParseMultipleRawHeaderValues(HeaderDescriptor descriptor, HeaderStoreItemInfo info, List<string> rawValues)
		{
			if (descriptor.Parser == null)
			{
				foreach (string rawValue in rawValues)
				{
					if (!ContainsInvalidNewLine(rawValue, descriptor.Name))
					{
						AddValue(info, rawValue, StoreLocation.Parsed);
					}
				}
				return;
			}
			foreach (string rawValue2 in rawValues)
			{
				if (!TryParseAndAddRawHeaderValue(descriptor, info, rawValue2, addWhenInvalid: true) && NetEventSource.IsEnabled)
				{
					NetEventSource.Log.HeadersInvalidValue(descriptor.Name, rawValue2);
				}
			}
		}

		private static void ParseSingleRawHeaderValue(HeaderDescriptor descriptor, HeaderStoreItemInfo info)
		{
			string text = info.RawValue as string;
			if (descriptor.Parser == null)
			{
				if (!ContainsInvalidNewLine(text, descriptor.Name))
				{
					AddValue(info, text, StoreLocation.Parsed);
				}
			}
			else if (!TryParseAndAddRawHeaderValue(descriptor, info, text, addWhenInvalid: true) && NetEventSource.IsEnabled)
			{
				NetEventSource.Log.HeadersInvalidValue(descriptor.Name, text);
			}
		}

		private static bool TryParseAndAddRawHeaderValue(HeaderDescriptor descriptor, HeaderStoreItemInfo info, string value, bool addWhenInvalid)
		{
			if (!info.CanAddValue(descriptor.Parser))
			{
				if (addWhenInvalid)
				{
					AddValue(info, value ?? string.Empty, StoreLocation.Invalid);
				}
				return false;
			}
			int index = 0;
			object parsedValue = null;
			if (descriptor.Parser.TryParseValue(value, info.ParsedValue, ref index, out parsedValue))
			{
				if (value == null || index == value.Length)
				{
					if (parsedValue != null)
					{
						AddValue(info, parsedValue, StoreLocation.Parsed);
					}
					return true;
				}
				List<object> list = new List<object>();
				if (parsedValue != null)
				{
					list.Add(parsedValue);
				}
				while (index < value.Length)
				{
					if (descriptor.Parser.TryParseValue(value, info.ParsedValue, ref index, out parsedValue))
					{
						if (parsedValue != null)
						{
							list.Add(parsedValue);
						}
						continue;
					}
					if (!ContainsInvalidNewLine(value, descriptor.Name) && addWhenInvalid)
					{
						AddValue(info, value, StoreLocation.Invalid);
					}
					return false;
				}
				foreach (object item in list)
				{
					AddValue(info, item, StoreLocation.Parsed);
				}
				return true;
			}
			if (!ContainsInvalidNewLine(value, descriptor.Name) && addWhenInvalid)
			{
				AddValue(info, value ?? string.Empty, StoreLocation.Invalid);
			}
			return false;
		}

		private static void AddValue(HeaderStoreItemInfo info, object value, StoreLocation location)
		{
			object obj = null;
			switch (location)
			{
			case StoreLocation.Raw:
				obj = info.RawValue;
				AddValueToStoreValue<string>(value, ref obj);
				info.RawValue = obj;
				break;
			case StoreLocation.Invalid:
				obj = info.InvalidValue;
				AddValueToStoreValue<string>(value, ref obj);
				info.InvalidValue = obj;
				break;
			case StoreLocation.Parsed:
				obj = info.ParsedValue;
				AddValueToStoreValue<object>(value, ref obj);
				info.ParsedValue = obj;
				break;
			}
		}

		private static void AddValueToStoreValue<T>(object value, ref object currentStoreValue) where T : class
		{
			if (currentStoreValue == null)
			{
				currentStoreValue = value;
				return;
			}
			List<T> list = currentStoreValue as List<T>;
			if (list == null)
			{
				list = new List<T>(2);
				list.Add(currentStoreValue as T);
				currentStoreValue = list;
			}
			list.Add(value as T);
		}

		internal object GetParsedValues(HeaderDescriptor descriptor)
		{
			HeaderStoreItemInfo info = null;
			if (!TryGetAndParseHeaderInfo(descriptor, out info))
			{
				return null;
			}
			return info.ParsedValue;
		}

		private void PrepareHeaderInfoForAdd(HeaderDescriptor descriptor, out HeaderStoreItemInfo info, out bool addToStore)
		{
			info = null;
			addToStore = false;
			if (!TryGetAndParseHeaderInfo(descriptor, out info))
			{
				info = new HeaderStoreItemInfo();
				addToStore = true;
			}
		}

		private void ParseAndAddValue(HeaderDescriptor descriptor, HeaderStoreItemInfo info, string value)
		{
			if (descriptor.Parser == null)
			{
				CheckInvalidNewLine(value);
				AddValue(info, value ?? string.Empty, StoreLocation.Parsed);
				return;
			}
			if (!info.CanAddValue(descriptor.Parser))
			{
				throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Cannot add value because header '{0}' does not support multiple values.", descriptor.Name));
			}
			int index = 0;
			object obj = descriptor.Parser.ParseValue(value, info.ParsedValue, ref index);
			if (value == null || index == value.Length)
			{
				if (obj != null)
				{
					AddValue(info, obj, StoreLocation.Parsed);
				}
				return;
			}
			List<object> list = new List<object>();
			if (obj != null)
			{
				list.Add(obj);
			}
			while (index < value.Length)
			{
				obj = descriptor.Parser.ParseValue(value, info.ParsedValue, ref index);
				if (obj != null)
				{
					list.Add(obj);
				}
			}
			foreach (object item in list)
			{
				AddValue(info, item, StoreLocation.Parsed);
			}
		}

		private HeaderDescriptor GetHeaderDescriptor(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("The value cannot be null or empty.", "name");
			}
			if (!HeaderDescriptor.TryGet(name, out var descriptor))
			{
				throw new FormatException("The header name format is invalid.");
			}
			if ((descriptor.HeaderType & _allowedHeaderTypes) != HttpHeaderType.None)
			{
				return descriptor;
			}
			if ((descriptor.HeaderType & _treatAsCustomHeaderTypes) != HttpHeaderType.None)
			{
				return descriptor.AsCustomHeader();
			}
			throw new InvalidOperationException("Misused header name. Make sure request headers are used with HttpRequestMessage, response headers with HttpResponseMessage, and content headers with HttpContent objects.");
		}

		private bool TryGetHeaderDescriptor(string name, out HeaderDescriptor descriptor)
		{
			if (string.IsNullOrEmpty(name))
			{
				descriptor = default(HeaderDescriptor);
				return false;
			}
			if (!HeaderDescriptor.TryGet(name, out descriptor))
			{
				return false;
			}
			if ((descriptor.HeaderType & _allowedHeaderTypes) != HttpHeaderType.None)
			{
				return true;
			}
			if ((descriptor.HeaderType & _treatAsCustomHeaderTypes) != HttpHeaderType.None)
			{
				descriptor = descriptor.AsCustomHeader();
				return true;
			}
			return false;
		}

		private static void CheckInvalidNewLine(string value)
		{
			if (value == null || !HttpRuleParser.ContainsInvalidNewLine(value))
			{
				return;
			}
			throw new FormatException("New-line characters in header values must be followed by a white-space character.");
		}

		private static bool ContainsInvalidNewLine(string value, string name)
		{
			if (HttpRuleParser.ContainsInvalidNewLine(value))
			{
				if (NetEventSource.IsEnabled)
				{
					NetEventSource.Error(null, global::SR.Format("Value for header '{0}' contains invalid new-line characters. Value: '{1}'.", name, value));
				}
				return true;
			}
			return false;
		}

		private static string[] GetValuesAsStrings(HeaderDescriptor descriptor, HeaderStoreItemInfo info, object exclude = null)
		{
			int valueCount = GetValueCount(info);
			string[] array;
			if (valueCount > 0)
			{
				array = new string[valueCount];
				int currentIndex = 0;
				ReadStoreValues<string>(array, info.RawValue, null, null, ref currentIndex);
				ReadStoreValues(array, info.ParsedValue, descriptor.Parser, exclude, ref currentIndex);
				ReadStoreValues<string>(array, info.InvalidValue, null, null, ref currentIndex);
				if (currentIndex < valueCount)
				{
					string[] array2 = new string[currentIndex];
					Array.Copy(array, 0, array2, 0, currentIndex);
					array = array2;
				}
			}
			else
			{
				array = Array.Empty<string>();
			}
			return array;
		}

		private static int GetValueCount(HeaderStoreItemInfo info)
		{
			int valueCount = 0;
			UpdateValueCount<string>(info.RawValue, ref valueCount);
			UpdateValueCount<string>(info.InvalidValue, ref valueCount);
			UpdateValueCount<object>(info.ParsedValue, ref valueCount);
			return valueCount;
		}

		private static void UpdateValueCount<T>(object valueStore, ref int valueCount)
		{
			if (valueStore != null)
			{
				if (valueStore is List<T> list)
				{
					valueCount += list.Count;
				}
				else
				{
					valueCount++;
				}
			}
		}

		private static void ReadStoreValues<T>(string[] values, object storeValue, HttpHeaderParser parser, T exclude, ref int currentIndex)
		{
			if (storeValue == null)
			{
				return;
			}
			if (!(storeValue is List<T> list))
			{
				if (ShouldAdd(storeValue, parser, exclude))
				{
					values[currentIndex] = ((parser == null) ? storeValue.ToString() : parser.ToString(storeValue));
					currentIndex++;
				}
				return;
			}
			foreach (T item in list)
			{
				object obj = item;
				if (ShouldAdd(obj, parser, exclude))
				{
					values[currentIndex] = ((parser == null) ? obj.ToString() : parser.ToString(obj));
					currentIndex++;
				}
			}
		}

		private static bool ShouldAdd<T>(object storeValue, HttpHeaderParser parser, T exclude)
		{
			bool result = true;
			if (parser != null && exclude != null)
			{
				result = ((parser.Comparer == null) ? (!exclude.Equals(storeValue)) : (!parser.Comparer.Equals(exclude, storeValue)));
			}
			return result;
		}

		private bool AreEqual(object value, object storeValue, IEqualityComparer comparer)
		{
			return comparer?.Equals(value, storeValue) ?? value.Equals(storeValue);
		}
	}
	public sealed class HttpRequestHeaders : HttpHeaders
	{
		private object[] _specialCollectionsSlots;

		private HttpGeneralHeaders _generalHeaders;

		private bool _expectContinueSet;

		public HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> Accept => GetSpecializedCollection(0, (HttpRequestHeaders thisRef) => new HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue>(KnownHeaders.Accept.Descriptor, thisRef));

		public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptEncoding => GetSpecializedCollection(2, (HttpRequestHeaders thisRef) => new HttpHeaderValueCollection<StringWithQualityHeaderValue>(KnownHeaders.AcceptEncoding.Descriptor, thisRef));

		public AuthenticationHeaderValue Authorization
		{
			get
			{
				return (AuthenticationHeaderValue)GetParsedValues(KnownHeaders.Authorization.Descriptor);
			}
			set
			{
				SetOrRemoveParsedValue(KnownHeaders.Authorization.Descriptor, value);
			}
		}

		public bool? ExpectContinue
		{
			get
			{
				if (ExpectCore.IsSpecialValueSet)
				{
					return true;
				}
				if (_expectContinueSet)
				{
					return false;
				}
				return null;
			}
			set
			{
				if (value == true)
				{
					_expectContinueSet = true;
					ExpectCore.SetSpecialValue();
				}
				else
				{
					_expectContinueSet = value.HasValue;
					ExpectCore.RemoveSpecialValue();
				}
			}
		}

		public string Host
		{
			get
			{
				return (string)GetParsedValues(KnownHeaders.Host.Descriptor);
			}
			set
			{
				if (value == string.Empty)
				{
					value = null;
				}
				string host = null;
				if (value != null && HttpRuleParser.GetHostLength(value, 0, allowToken: false, out host) != value.Length)
				{
					throw new FormatException("The specified value is not a valid 'Host' header string.");
				}
				SetOrRemoveParsedValue(KnownHeaders.Host.Descriptor, value);
			}
		}

		public AuthenticationHeaderValue ProxyAuthorization
		{
			set
			{
				SetOrRemoveParsedValue(KnownHeaders.ProxyAuthorization.Descriptor, value);
			}
		}

		public RangeHeaderValue Range
		{
			set
			{
				SetOrRemoveParsedValue(KnownHeaders.Range.Descriptor, value);
			}
		}

		private HttpHeaderValueCollection<NameValueWithParametersHeaderValue> ExpectCore => GetSpecializedCollection(4, (HttpRequestHeaders thisRef) => new HttpHeaderValueCollection<NameValueWithParametersHeaderValue>(KnownHeaders.Expect.Descriptor, thisRef, HeaderUtilities.ExpectContinue));

		public bool? ConnectionClose
		{
			set
			{
				GeneralHeaders.ConnectionClose = value;
			}
		}

		public bool? TransferEncodingChunked
		{
			get
			{
				return HttpGeneralHeaders.GetTransferEncodingChunked(this, _generalHeaders);
			}
			set
			{
				GeneralHeaders.TransferEncodingChunked = value;
			}
		}

		private HttpGeneralHeaders GeneralHeaders => _generalHeaders ?? (_generalHeaders = new HttpGeneralHeaders(this));

		private T GetSpecializedCollection<T>(int slot, Func<HttpRequestHeaders, T> creationFunc)
		{
			object[] array = _specialCollectionsSlots ?? (_specialCollectionsSlots = new object[9]);
			object obj = array[slot];
			if (obj == null)
			{
				obj = (array[slot] = creationFunc(this));
			}
			return (T)obj;
		}

		internal HttpRequestHeaders()
			: base(HttpHeaderType.General | HttpHeaderType.Request | HttpHeaderType.Custom, HttpHeaderType.Response)
		{
		}

		internal override void AddHeaders(HttpHeaders sourceHeaders)
		{
			base.AddHeaders(sourceHeaders);
			HttpRequestHeaders httpRequestHeaders = sourceHeaders as HttpRequestHeaders;
			if (httpRequestHeaders._generalHeaders != null)
			{
				GeneralHeaders.AddSpecialsFrom(httpRequestHeaders._generalHeaders);
			}
			if (!ExpectContinue.HasValue)
			{
				ExpectContinue = httpRequestHeaders.ExpectContinue;
			}
		}
	}
	public sealed class HttpResponseHeaders : HttpHeaders
	{
		private object[] _specialCollectionsSlots;

		private HttpGeneralHeaders _generalHeaders;

		public Uri Location => (Uri)GetParsedValues(KnownHeaders.Location.Descriptor);

		public HttpHeaderValueCollection<AuthenticationHeaderValue> ProxyAuthenticate => GetSpecializedCollection(1, (HttpResponseHeaders thisRef) => new HttpHeaderValueCollection<AuthenticationHeaderValue>(KnownHeaders.ProxyAuthenticate.Descriptor, thisRef));

		public HttpHeaderValueCollection<AuthenticationHeaderValue> WwwAuthenticate => GetSpecializedCollection(4, (HttpResponseHeaders thisRef) => new HttpHeaderValueCollection<AuthenticationHeaderValue>(KnownHeaders.WWWAuthenticate.Descriptor, thisRef));

		public bool? ConnectionClose => HttpGeneralHeaders.GetConnectionClose(this, _generalHeaders);

		public bool? TransferEncodingChunked => HttpGeneralHeaders.GetTransferEncodingChunked(this, _generalHeaders);

		private HttpGeneralHeaders GeneralHeaders => _generalHeaders ?? (_generalHeaders = new HttpGeneralHeaders(this));

		private T GetSpecializedCollection<T>(int slot, Func<HttpResponseHeaders, T> creationFunc)
		{
			object[] array = _specialCollectionsSlots ?? (_specialCollectionsSlots = new object[5]);
			object obj = array[slot];
			if (obj == null)
			{
				obj = (array[slot] = creationFunc(this));
			}
			return (T)obj;
		}

		internal HttpResponseHeaders()
			: base(HttpHeaderType.General | HttpHeaderType.Response | HttpHeaderType.Custom, HttpHeaderType.Request)
		{
		}

		internal override void AddHeaders(HttpHeaders sourceHeaders)
		{
			base.AddHeaders(sourceHeaders);
			HttpResponseHeaders httpResponseHeaders = sourceHeaders as HttpResponseHeaders;
			if (httpResponseHeaders._generalHeaders != null)
			{
				GeneralHeaders.AddSpecialsFrom(httpResponseHeaders._generalHeaders);
			}
		}
	}
	internal class Int32NumberHeaderParser : BaseHeaderParser
	{
		internal static readonly Int32NumberHeaderParser Parser = new Int32NumberHeaderParser();

		private Int32NumberHeaderParser()
			: base(supportsMultipleValues: false)
		{
		}

		public override string ToString(object value)
		{
			return ((int)value).ToString(NumberFormatInfo.InvariantInfo);
		}

		protected override int GetParsedValueLength(string value, int startIndex, object storeValue, out object parsedValue)
		{
			parsedValue = null;
			int numberLength = HttpRuleParser.GetNumberLength(value, startIndex, allowDecimal: false);
			if (numberLength == 0 || numberLength > 10)
			{
				return 0;
			}
			int result = 0;
			if (!HeaderUtilities.TryParseInt32(value, startIndex, numberLength, out result))
			{
				return 0;
			}
			parsedValue = result;
			return numberLength;
		}
	}
	internal class Int64NumberHeaderParser : BaseHeaderParser
	{
		internal static readonly Int64NumberHeaderParser Parser = new Int64NumberHeaderParser();

		private Int64NumberHeaderParser()
			: base(supportsMultipleValues: false)
		{
		}

		public override string ToString(object value)
		{
			return ((long)value).ToString(NumberFormatInfo.InvariantInfo);
		}

		protected override int GetParsedValueLength(string value, int startIndex, object storeValue, out object parsedValue)
		{
			parsedValue = null;
			int numberLength = HttpRuleParser.GetNumberLength(value, startIndex, allowDecimal: false);
			if (numberLength == 0 || numberLength > 19)
			{
				return 0;
			}
			long result = 0L;
			if (!HeaderUtilities.TryParseInt64(value, startIndex, numberLength, out result))
			{
				return 0;
			}
			parsedValue = result;
			return numberLength;
		}
	}
	internal sealed class KnownHeader
	{
		private readonly string _name;

		private readonly HttpHeaderType _headerType;

		private readonly HttpHeaderParser _parser;

		private readonly string[] _knownValues;

		private readonly byte[] _asciiBytesWithColonSpace;

		public string Name => _name;

		public HttpHeaderParser Parser => _parser;

		public HttpHeaderType HeaderType => _headerType;

		public string[] KnownValues => _knownValues;

		public byte[] AsciiBytesWithColonSpace => _asciiBytesWithColonSpace;

		public HeaderDescriptor Descriptor => new HeaderDescriptor(this);

		public KnownHeader(string name)
			: this(name, HttpHeaderType.Custom, null)
		{
		}

		public KnownHeader(string name, HttpHeaderType headerType, HttpHeaderParser parser, string[] knownValues = null)
		{
			_name = name;
			_headerType = headerType;
			_parser = parser;
			_knownValues = knownValues;
			_asciiBytesWithColonSpace = new byte[name.Length + 2];
			Encoding.ASCII.GetBytes(name, _asciiBytesWithColonSpace);
			_asciiBytesWithColonSpace[_asciiBytesWithColonSpace.Length - 2] = 58;
			_asciiBytesWithColonSpace[_asciiBytesWithColonSpace.Length - 1] = 32;
		}
	}
	internal static class KnownHeaders
	{
		private interface IHeaderNameAccessor
		{
			int Length { get; }

			char this[int index] { get; }
		}

		private readonly struct StringAccessor(string s) : IHeaderNameAccessor
		{
			private readonly string _string = s;

			public int Length => _string.Length;

			public char this[int index] => _string[index];
		}

		private unsafe readonly struct BytePtrAccessor(byte* p, int length) : IHeaderNameAccessor
		{
			private unsafe readonly byte* _p = p;

			private readonly int _length = length;

			public int Length => _length;

			public unsafe char this[int index] => (char)_p[index];
		}

		public static readonly KnownHeader Accept = new KnownHeader("Accept", HttpHeaderType.Request, MediaTypeHeaderParser.MultipleValuesParser);

		public static readonly KnownHeader AcceptCharset = new KnownHeader("Accept-Charset", HttpHeaderType.Request, GenericHeaderParser.MultipleValueStringWithQualityParser);

		public static readonly KnownHeader AcceptEncoding = new KnownHeader("Accept-Encoding", HttpHeaderType.Request, GenericHeaderParser.MultipleValueStringWithQualityParser);

		public static readonly KnownHeader AcceptLanguage = new KnownHeader("Accept-Language", HttpHeaderType.Request, GenericHeaderParser.MultipleValueStringWithQualityParser);

		public static readonly KnownHeader AcceptPatch = new KnownHeader("Accept-Patch");

		public static readonly KnownHeader AcceptRanges = new KnownHeader("Accept-Ranges", HttpHeaderType.Response, GenericHeaderParser.TokenListParser);

		public static readonly KnownHeader AccessControlAllowCredentials = new KnownHeader("Access-Control-Allow-Credentials");

		public static readonly KnownHeader AccessControlAllowHeaders = new KnownHeader("Access-Control-Allow-Headers");

		public static readonly KnownHeader AccessControlAllowMethods = new KnownHeader("Access-Control-Allow-Methods");

		public static readonly KnownHeader AccessControlAllowOrigin = new KnownHeader("Access-Control-Allow-Origin");

		public static readonly KnownHeader AccessControlExposeHeaders = new KnownHeader("Access-Control-Expose-Headers");

		public static readonly KnownHeader AccessControlMaxAge = new KnownHeader("Access-Control-Max-Age");

		public static readonly KnownHeader Age = new KnownHeader("Age", HttpHeaderType.Response, TimeSpanHeaderParser.Parser);

		public static readonly KnownHeader Allow = new KnownHeader("Allow", HttpHeaderType.Content, GenericHeaderParser.TokenListParser);

		public static readonly KnownHeader AltSvc = new KnownHeader("Alt-Svc");

		public static readonly KnownHeader Authorization = new KnownHeader("Authorization", HttpHeaderType.Request, GenericHeaderParser.SingleValueAuthenticationParser);

		public static readonly KnownHeader CacheControl = new KnownHeader("Cache-Control", HttpHeaderType.General, CacheControlHeaderParser.Parser);

		public static readonly KnownHeader Connection = new KnownHeader("Connection", HttpHeaderType.General, GenericHeaderParser.TokenListParser, new string[1] { "close" });

		public static readonly KnownHeader ContentDisposition = new KnownHeader("Content-Disposition", HttpHeaderType.Content, GenericHeaderParser.ContentDispositionParser);

		public static readonly KnownHeader ContentEncoding = new KnownHeader("Content-Encoding", HttpHeaderType.Content, GenericHeaderParser.TokenListParser, new string[2] { "gzip", "deflate" });

		public static readonly KnownHeader ContentLanguage = new KnownHeader("Content-Language", HttpHeaderType.Content, GenericHeaderParser.TokenListParser);

		public static readonly KnownHeader ContentLength = new KnownHeader("Content-Length", HttpHeaderType.Content, Int64NumberHeaderParser.Parser);

		public static readonly KnownHeader ContentLocation = new KnownHeader("Content-Location", HttpHeaderType.Content, UriHeaderParser.RelativeOrAbsoluteUriParser);

		public static readonly KnownHeader ContentMD5 = new KnownHeader("Content-MD5", HttpHeaderType.Content, ByteArrayHeaderParser.Parser);

		public static readonly KnownHeader ContentRange = new KnownHeader("Content-Range", HttpHeaderType.Content, GenericHeaderParser.ContentRangeParser);

		public static readonly KnownHeader ContentSecurityPolicy = new KnownHeader("Content-Security-Policy");

		public static readonly KnownHeader ContentType = new KnownHeader("Content-Type", HttpHeaderType.Content, MediaTypeHeaderParser.SingleValueParser);

		public static readonly KnownHeader Cookie = new KnownHeader("Cookie");

		public static readonly KnownHeader Cookie2 = new KnownHeader("Cookie2");

		public static readonly KnownHeader Date = new KnownHeader("Date", HttpHeaderType.General, DateHeaderParser.Parser);

		public static readonly KnownHeader ETag = new KnownHeader("ETag", HttpHeaderType.Response, GenericHeaderParser.SingleValueEntityTagParser);

		public static readonly KnownHeader Expect = new KnownHeader("Expect", HttpHeaderType.Request, GenericHeaderParser.MultipleValueNameValueWithParametersParser, new string[1] { "100-continue" });

		public static readonly KnownHeader Expires = new KnownHeader("Expires", HttpHeaderType.Content, DateHeaderParser.Parser);

		public static readonly KnownHeader From = new KnownHeader("From", HttpHeaderType.Request, GenericHeaderParser.MailAddressParser);

		public static readonly KnownHeader Host = new KnownHeader("Host", HttpHeaderType.Request, GenericHeaderParser.HostParser);

		public static readonly KnownHeader IfMatch = new KnownHeader("If-Match", HttpHeaderType.Request, GenericHeaderParser.MultipleValueEntityTagParser);

		public static readonly KnownHeader IfModifiedSince = new KnownHeader("If-Modified-Since", HttpHeaderType.Request, DateHeaderParser.Parser);

		public static readonly KnownHeader IfNoneMatch = new KnownHeader("If-None-Match", HttpHeaderType.Request, GenericHeaderParser.MultipleValueEntityTagParser);

		public static readonly KnownHeader IfRange = new KnownHeader("If-Range", HttpHeaderType.Request, GenericHeaderParser.RangeConditionParser);

		public static readonly KnownHeader IfUnmodifiedSince = new KnownHeader("If-Unmodified-Since", HttpHeaderType.Request, DateHeaderParser.Parser);

		public static readonly KnownHeader KeepAlive = new KnownHeader("Keep-Alive");

		public static readonly KnownHeader LastModified = new KnownHeader("Last-Modified", HttpHeaderType.Content, DateHeaderParser.Parser);

		public static readonly KnownHeader Link = new KnownHeader("Link");

		public static readonly KnownHeader Location = new KnownHeader("Location", HttpHeaderType.Response, UriHeaderParser.RelativeOrAbsoluteUriParser);

		public static readonly KnownHeader MaxForwards = new KnownHeader("Max-Forwards", HttpHeaderType.Request, Int32NumberHeaderParser.Parser);

		public static readonly KnownHeader Origin = new KnownHeader("Origin");

		public static readonly KnownHeader P3P = new KnownHeader("P3P");

		public static readonly KnownHeader Pragma = new KnownHeader("Pragma", HttpHeaderType.General, GenericHeaderParser.MultipleValueNameValueParser);

		public static readonly KnownHeader ProxyAuthenticate = new KnownHeader("Proxy-Authenticate", HttpHeaderType.Response, GenericHeaderParser.MultipleValueAuthenticationParser);

		public static readonly KnownHeader ProxyAuthorization = new KnownHeader("Proxy-Authorization", HttpHeaderType.Request, GenericHeaderParser.SingleValueAuthenticationParser);

		public static readonly KnownHeader ProxyConnection = new KnownHeader("Proxy-Connection");

		public static readonly KnownHeader ProxySupport = new KnownHeader("Proxy-Support");

		public static readonly KnownHeader PublicKeyPins = new KnownHeader("Public-Key-Pins");

		public static readonly KnownHeader Range = new KnownHeader("Range", HttpHeaderType.Request, GenericHeaderParser.RangeParser);

		public static readonly KnownHeader Referer = new KnownHeader("Referer", HttpHeaderType.Request, UriHeaderParser.RelativeOrAbsoluteUriParser);

		public static readonly KnownHeader RetryAfter = new KnownHeader("Retry-After", HttpHeaderType.Response, GenericHeaderParser.RetryConditionParser);

		public static readonly KnownHeader SecWebSocketAccept = new KnownHeader("Sec-WebSocket-Accept");

		public static readonly KnownHeader SecWebSocketExtensions = new KnownHeader("Sec-WebSocket-Extensions");

		public static readonly KnownHeader SecWebSocketKey = new KnownHeader("Sec-WebSocket-Key");

		public static readonly KnownHeader SecWebSocketProtocol = new KnownHeader("Sec-WebSocket-Protocol");

		public static readonly KnownHeader SecWebSocketVersion = new KnownHeader("Sec-WebSocket-Version");

		public static readonly KnownHeader Server = new KnownHeader("Server", HttpHeaderType.Response, ProductInfoHeaderParser.MultipleValueParser);

		public static readonly KnownHeader SetCookie = new KnownHeader("Set-Cookie");

		public static readonly KnownHeader SetCookie2 = new KnownHeader("Set-Cookie2");

		public static readonly KnownHeader StrictTransportSecurity = new KnownHeader("Strict-Transport-Security");

		public static readonly KnownHeader TE = new KnownHeader("TE", HttpHeaderType.Request, TransferCodingHeaderParser.MultipleValueWithQualityParser);

		public static readonly KnownHeader TSV = new KnownHeader("TSV");

		public static readonly KnownHeader Trailer = new KnownHeader("Trailer", HttpHeaderType.General, GenericHeaderParser.TokenListParser);

		public static readonly KnownHeader TransferEncoding = new KnownHeader("Transfer-Encoding", HttpHeaderType.General, TransferCodingHeaderParser.MultipleValueParser, new string[1] { "chunked" });

		public static readonly KnownHeader Upgrade = new KnownHeader("Upgrade", HttpHeaderType.General, GenericHeaderParser.MultipleValueProductParser);

		public static readonly KnownHeader UpgradeInsecureRequests = new KnownHeader("Upgrade-Insecure-Requests");

		public static readonly KnownHeader UserAgent = new KnownHeader("User-Agent", HttpHeaderType.Request, ProductInfoHeaderParser.MultipleValueParser);

		public static readonly KnownHeader Vary = new KnownHeader("Vary", HttpHeaderType.Response, GenericHeaderParser.TokenListParser);

		public static readonly KnownHeader Via = new KnownHeader("Via", HttpHeaderType.General, GenericHeaderParser.MultipleValueViaParser);

		public static readonly KnownHeader WWWAuthenticate = new KnownHeader("WWW-Authenticate", HttpHeaderType.Response, GenericHeaderParser.MultipleValueAuthenticationParser);

		public static readonly KnownHeader Warning = new KnownHeader("Warning", HttpHeaderType.General, GenericHeaderParser.MultipleValueWarningParser);

		public static readonly KnownHeader XAspNetVersion = new KnownHeader("X-AspNet-Version");

		public static readonly KnownHeader XContentDuration = new KnownHeader("X-Content-Duration");

		public static readonly KnownHeader XContentTypeOptions = new KnownHeader("X-Content-Type-Options");

		public static readonly KnownHeader XFrameOptions = new KnownHeader("X-Frame-Options");

		public static readonly KnownHeader XMSEdgeRef = new KnownHeader("X-MSEdge-Ref");

		public static readonly KnownHeader XPoweredBy = new KnownHeader("X-Powered-By");

		public static readonly KnownHeader XRequestID = new KnownHeader("X-Request-ID");

		public static readonly KnownHeader XUACompatible = new KnownHeader("X-UA-Compatible");

		private static KnownHeader GetCandidate<T>(T key) where T : struct, IHeaderNameAccessor
		{
			switch (key.Length)
			{
			case 2:
				return TE;
			case 3:
				switch (key[0])
				{
				case 'A':
				case 'a':
					return Age;
				case 'P':
				case 'p':
					return P3P;
				case 'T':
				case 't':
					return TSV;
				case 'V':
				case 'v':
					return Via;
				}
				break;
			case 4:
				switch (key[0])
				{
				case 'D':
				case 'd':
					return Date;
				case 'E':
				case 'e':
					return ETag;
				case 'F':
				case 'f':
					return From;
				case 'H':
				case 'h':
					return Host;
				case 'L':
				case 'l':
					return Link;
				case 'V':
				case 'v':
					return Vary;
				}
				break;
			case 5:
				switch (key[0])
				{
				case 'A':
				case 'a':
					return Allow;
				case 'R':
				case 'r':
					return Range;
				}
				break;
			case 6:
				switch (key[0])
				{
				case 'A':
				case 'a':
					return Accept;
				case 'C':
				case 'c':
					return Cookie;
				case 'E':
				case 'e':
					return Expect;
				case 'O':
				case 'o':
					return Origin;
				case 'P':
				case 'p':
					return Pragma;
				case 'S':
				case 's':
					return Server;
				}
				break;
			case 7:
				switch (key[0])
				{
				case 'A':
				case 'a':
					return AltSvc;
				case 'C':
				case 'c':
					return Cookie2;
				case 'E':
				case 'e':
					return Expires;
				case 'R':
				case 'r':
					return Referer;
				case 'T':
				case 't':
					return Trailer;
				case 'U':
				case 'u':
					return Upgrade;
				case 'W':
				case 'w':
					return Warning;
				}
				break;
			case 8:
				switch (key[3])
				{
				case 'M':
				case 'm':
					return IfMatch;
				case 'R':
				case 'r':
					return IfRange;
				case 'A':
				case 'a':
					return Location;
				}
				break;
			case 10:
				switch (key[0])
				{
				case 'C':
				case 'c':
					return Connection;
				case 'K':
				case 'k':
					return KeepAlive;
				case 'S':
				case 's':
					return SetCookie;
				case 'U':
				case 'u':
					return UserAgent;
				}
				break;
			case 11:
				switch (key[0])
				{
				case 'C':
				case 'c':
					return ContentMD5;
				case 'R':
				case 'r':
					return RetryAfter;
				case 'S':
				case 's':
					return SetCookie2;
				}
				break;
			case 12:
				switch (key[2])
				{
				case 'C':
				case 'c':
					return AcceptPatch;
				case 'N':
				case 'n':
					return ContentType;
				case 'X':
				case 'x':
					return MaxForwards;
				case 'M':
				case 'm':
					return XMSEdgeRef;
				case 'P':
				case 'p':
					return XPoweredBy;
				case 'R':
				case 'r':
					return XRequestID;
				}
				break;
			case 13:
				switch (key[6])
				{
				case '-':
					return AcceptRanges;
				case 'I':
				case 'i':
					return Authorization;
				case 'C':
				case 'c':
					return CacheControl;
				case 'T':
				case 't':
					return ContentRange;
				case 'E':
				case 'e':
					return IfNoneMatch;
				case 'O':
				case 'o':
					return LastModified;
				case 'S':
				case 's':
					return ProxySupport;
				}
				break;
			case 14:
				switch (key[0])
				{
				case 'A':
				case 'a':
					return AcceptCharset;
				case 'C':
				case 'c':
					return ContentLength;
				}
				break;
			case 15:
				switch (key[7])
				{
				case '-':
					return XFrameOptions;
				case 'M':
				case 'm':
					return XUACompatible;
				case 'E':
				case 'e':
					return AcceptEncoding;
				case 'K':
				case 'k':
					return PublicKeyPins;
				case 'L':
				case 'l':
					return AcceptLanguage;
				}
				break;
			case 16:
				switch (key[11])
				{
				case 'O':
				case 'o':
					return ContentEncoding;
				case 'G':
				case 'g':
					return ContentLanguage;
				case 'A':
				case 'a':
					return ContentLocation;
				case 'C':
				case 'c':
					return ProxyConnection;
				case 'I':
				case 'i':
					return WWWAuthenticate;
				case 'R':
				case 'r':
					return XAspNetVersion;
				}
				break;
			case 17:
				switch (key[0])
				{
				case 'I':
				case 'i':
					return IfModifiedSince;
				case 'S':
				case 's':
					return SecWebSocketKey;
				case 'T':
				case 't':
					return TransferEncoding;
				}
				break;
			case 18:
				switch (key[0])
				{
				case 'P':
				case 'p':
					return ProxyAuthenticate;
				case 'X':
				case 'x':
					return XContentDuration;
				}
				break;
			case 19:
				switch (key[0])
				{
				case 'C':
				case 'c':
					return ContentDisposition;
				case 'I':
				case 'i':
					return IfUnmodifiedSince;
				case 'P':
				case 'p':
					return ProxyAuthorization;
				}
				break;
			case 20:
				return SecWebSocketAccept;
			case 21:
				return SecWebSocketVersion;
			case 22:
				switch (key[0])
				{
				case 'A':
				case 'a':
					return AccessControlMaxAge;
				case 'S':
				case 's':
					return SecWebSocketProtocol;
				case 'X':
				case 'x':
					return XContentTypeOptions;
				}
				break;
			case 23:
				return ContentSecurityPolicy;
			case 24:
				return SecWebSocketExtensions;
			case 25:
				switch (key[0])
				{
				case 'S':
				case 's':
					return StrictTransportSecurity;
				case 'U':
				case 'u':
					return UpgradeInsecureRequests;
				}
				break;
			case 27:
				return AccessControlAllowOrigin;
			case 28:
				switch (key[21])
				{
				case 'H':
				case 'h':
					return AccessControlAllowHeaders;
				case 'M':
				case 'm':
					return AccessControlAllowMethods;
				}
				break;
			case 29:
				return AccessControlExposeHeaders;
			case 32:
				return AccessControlAllowCredentials;
			}
			return null;
		}

		internal static KnownHeader TryGetKnownHeader(string name)
		{
			KnownHeader candidate = GetCandidate(new StringAccessor(name));
			if (candidate != null && StringComparer.OrdinalIgnoreCase.Equals(name, candidate.Name))
			{
				return candidate;
			}
			return null;
		}

		internal unsafe static KnownHeader TryGetKnownHeader(ReadOnlySpan<byte> name)
		{
			fixed (byte* reference = &MemoryMarshal.GetReference(name))
			{
				KnownHeader candidate = GetCandidate(new BytePtrAccessor(reference, name.Length));
				if (candidate != null && ByteArrayHelpers.EqualsOrdinalAsciiIgnoreCase(candidate.Name, name))
				{
					return candidate;
				}
			}
			return null;
		}
	}
	internal class MediaTypeHeaderParser : BaseHeaderParser
	{
		private bool _supportsMultipleValues;

		private Func<MediaTypeHeaderValue> _mediaTypeCreator;

		internal static readonly MediaTypeHeaderParser SingleValueParser = new MediaTypeHeaderParser(supportsMultipleValues: false, CreateMediaType);

		internal static readonly MediaTypeHeaderParser SingleValueWithQualityParser = new MediaTypeHeaderParser(supportsMultipleValues: false, CreateMediaTypeWithQuality);

		internal static readonly MediaTypeHeaderParser MultipleValuesParser = new MediaTypeHeaderParser(supportsMultipleValues: true, CreateMediaTypeWithQuality);

		private MediaTypeHeaderParser(bool supportsMultipleValues, Func<MediaTypeHeaderValue> mediaTypeCreator)
			: base(supportsMultipleValues)
		{
			_supportsMultipleValues = supportsMultipleValues;
			_mediaTypeCreator = mediaTypeCreator;
		}

		protected override int GetParsedValueLength(string value, int startIndex, object storeValue, out object parsedValue)
		{
			MediaTypeHeaderValue parsedValue2 = null;
			int mediaTypeLength = MediaTypeHeaderValue.GetMediaTypeLength(value, startIndex, _mediaTypeCreator, out parsedValue2);
			parsedValue = parsedValue2;
			return mediaTypeLength;
		}

		private static MediaTypeHeaderValue CreateMediaType()
		{
			return new MediaTypeHeaderValue();
		}

		private static MediaTypeHeaderValue CreateMediaTypeWithQuality()
		{
			return new MediaTypeWithQualityHeaderValue();
		}
	}
	public class MediaTypeHeaderValue : ICloneable
	{
		private ObjectCollection<NameValueHeaderValue> _parameters;

		private string _mediaType;

		public string CharSet
		{
			get
			{
				return NameValueHeaderValue.Find(_parameters, "charset")?.Value;
			}
			set
			{
				NameValueHeaderValue nameValueHeaderValue = NameValueHeaderValue.Find(_parameters, "charset");
				if (string.IsNullOrEmpty(value))
				{
					if (nameValueHeaderValue != null)
					{
						_parameters.Remove(nameValueHeaderValue);
					}
				}
				else if (nameValueHeaderValue != null)
				{
					nameValueHeaderValue.Value = value;
				}
				else
				{
					Parameters.Add(new NameValueHeaderValue("charset", value));
				}
			}
		}

		public ICollection<NameValueHeaderValue> Parameters
		{
			get
			{
				if (_parameters == null)
				{
					_parameters = new ObjectCollection<NameValueHeaderValue>();
				}
				return _parameters;
			}
		}

		public string MediaType
		{
			get
			{
				return _mediaType;
			}
			set
			{
				CheckMediaTypeFormat(value, "value");
				_mediaType = value;
			}
		}

		internal MediaTypeHeaderValue()
		{
		}

		protected MediaTypeHeaderValue(MediaTypeHeaderValue source)
		{
			_mediaType = source._mediaType;
			if (source._parameters == null)
			{
				return;
			}
			foreach (NameValueHeaderValue parameter in source._parameters)
			{
				Parameters.Add((NameValueHeaderValue)((ICloneable)parameter).Clone());
			}
		}

		public MediaTypeHeaderValue(string mediaType)
		{
			CheckMediaTypeFormat(mediaType, "mediaType");
			_mediaType = mediaType;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			stringBuilder.Append(_mediaType);
			NameValueHeaderValue.ToString(_parameters, ';', leadingSeparator: true, stringBuilder);
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is MediaTypeHeaderValue mediaTypeHeaderValue))
			{
				return false;
			}
			if (string.Equals(_mediaType, mediaTypeHeaderValue._mediaType, StringComparison.OrdinalIgnoreCase))
			{
				return HeaderUtilities.AreEqualCollections(_parameters, mediaTypeHeaderValue._parameters);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return StringComparer.OrdinalIgnoreCase.GetHashCode(_mediaType) ^ NameValueHeaderValue.GetHashCode(_parameters);
		}

		public static MediaTypeHeaderValue Parse(string input)
		{
			int index = 0;
			return (MediaTypeHeaderValue)MediaTypeHeaderParser.SingleValueParser.ParseValue(input, null, ref index);
		}

		internal static int GetMediaTypeLength(string input, int startIndex, Func<MediaTypeHeaderValue> mediaTypeCreator, out MediaTypeHeaderValue parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			string mediaType = null;
			int mediaTypeExpressionLength = GetMediaTypeExpressionLength(input, startIndex, out mediaType);
			if (mediaTypeExpressionLength == 0)
			{
				return 0;
			}
			int num = startIndex + mediaTypeExpressionLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			MediaTypeHeaderValue mediaTypeHeaderValue = null;
			if (num < input.Length && input[num] == ';')
			{
				mediaTypeHeaderValue = mediaTypeCreator();
				mediaTypeHeaderValue._mediaType = mediaType;
				num++;
				int nameValueListLength = NameValueHeaderValue.GetNameValueListLength(input, num, ';', (ObjectCollection<NameValueHeaderValue>)mediaTypeHeaderValue.Parameters);
				if (nameValueListLength == 0)
				{
					return 0;
				}
				parsedValue = mediaTypeHeaderValue;
				return num + nameValueListLength - startIndex;
			}
			mediaTypeHeaderValue = mediaTypeCreator();
			mediaTypeHeaderValue._mediaType = mediaType;
			parsedValue = mediaTypeHeaderValue;
			return num - startIndex;
		}

		private static int GetMediaTypeExpressionLength(string input, int startIndex, out string mediaType)
		{
			mediaType = null;
			int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex);
			if (tokenLength == 0)
			{
				return 0;
			}
			int num = startIndex + tokenLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (num >= input.Length || input[num] != '/')
			{
				return 0;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			int tokenLength2 = HttpRuleParser.GetTokenLength(input, num);
			if (tokenLength2 == 0)
			{
				return 0;
			}
			int num2 = num + tokenLength2 - startIndex;
			if (tokenLength + tokenLength2 + 1 == num2)
			{
				mediaType = input.Substring(startIndex, num2);
			}
			else
			{
				mediaType = input.Substring(startIndex, tokenLength) + "/" + input.Substring(num, tokenLength2);
			}
			return num2;
		}

		private static void CheckMediaTypeFormat(string mediaType, string parameterName)
		{
			if (string.IsNullOrEmpty(mediaType))
			{
				throw new ArgumentException("The value cannot be null or empty.", parameterName);
			}
			if (GetMediaTypeExpressionLength(mediaType, 0, out var mediaType2) == 0 || mediaType2.Length != mediaType.Length)
			{
				throw new FormatException(string.Format(CultureInfo.InvariantCulture, "The format of value '{0}' is invalid.", mediaType));
			}
		}

		object ICloneable.Clone()
		{
			return new MediaTypeHeaderValue(this);
		}
	}
	public sealed class MediaTypeWithQualityHeaderValue : MediaTypeHeaderValue, ICloneable
	{
		internal MediaTypeWithQualityHeaderValue()
		{
		}

		public MediaTypeWithQualityHeaderValue(string mediaType)
			: base(mediaType)
		{
		}

		private MediaTypeWithQualityHeaderValue(MediaTypeWithQualityHeaderValue source)
			: base(source)
		{
		}

		object ICloneable.Clone()
		{
			return new MediaTypeWithQualityHeaderValue(this);
		}
	}
	public class NameValueHeaderValue : ICloneable
	{
		private static readonly Func<NameValueHeaderValue> s_defaultNameValueCreator = CreateNameValue;

		private string _name;

		private string _value;

		public string Name => _name;

		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				CheckValueFormat(value);
				_value = value;
			}
		}

		internal NameValueHeaderValue()
		{
		}

		public NameValueHeaderValue(string name)
			: this(name, null)
		{
		}

		public NameValueHeaderValue(string name, string value)
		{
			CheckNameValueFormat(name, value);
			_name = name;
			_value = value;
		}

		protected NameValueHeaderValue(NameValueHeaderValue source)
		{
			_name = source._name;
			_value = source._value;
		}

		public override int GetHashCode()
		{
			int hashCode = StringComparer.OrdinalIgnoreCase.GetHashCode(_name);
			if (!string.IsNullOrEmpty(_value))
			{
				if (_value[0] == '"')
				{
					return hashCode ^ _value.GetHashCode();
				}
				return hashCode ^ StringComparer.OrdinalIgnoreCase.GetHashCode(_value);
			}
			return hashCode;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is NameValueHeaderValue nameValueHeaderValue))
			{
				return false;
			}
			if (!string.Equals(_name, nameValueHeaderValue._name, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			if (string.IsNullOrEmpty(_value))
			{
				return string.IsNullOrEmpty(nameValueHeaderValue._value);
			}
			if (_value[0] == '"')
			{
				return string.Equals(_value, nameValueHeaderValue._value, StringComparison.Ordinal);
			}
			return string.Equals(_value, nameValueHeaderValue._value, StringComparison.OrdinalIgnoreCase);
		}

		public override string ToString()
		{
			if (!string.IsNullOrEmpty(_value))
			{
				return _name + "=" + _value;
			}
			return _name;
		}

		private void AddToStringBuilder(StringBuilder sb)
		{
			if (GetType() != typeof(NameValueHeaderValue))
			{
				sb.Append(ToString());
				return;
			}
			sb.Append(_name);
			if (!string.IsNullOrEmpty(_value))
			{
				sb.Append('=');
				sb.Append(_value);
			}
		}

		internal static void ToString(ObjectCollection<NameValueHeaderValue> values, char separator, bool leadingSeparator, StringBuilder destination)
		{
			if (values == null || values.Count == 0)
			{
				return;
			}
			foreach (NameValueHeaderValue value in values)
			{
				if (leadingSeparator || destination.Length > 0)
				{
					destination.Append(separator);
					destination.Append(' ');
				}
				value.AddToStringBuilder(destination);
			}
		}

		internal static int GetHashCode(ObjectCollection<NameValueHeaderValue> values)
		{
			if (values == null || values.Count == 0)
			{
				return 0;
			}
			int num = 0;
			foreach (NameValueHeaderValue value in values)
			{
				num ^= value.GetHashCode();
			}
			return num;
		}

		internal static int GetNameValueLength(string input, int startIndex, out NameValueHeaderValue parsedValue)
		{
			return GetNameValueLength(input, startIndex, s_defaultNameValueCreator, out parsedValue);
		}

		internal static int GetNameValueLength(string input, int startIndex, Func<NameValueHeaderValue> nameValueCreator, out NameValueHeaderValue parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex);
			if (tokenLength == 0)
			{
				return 0;
			}
			string name = input.Substring(startIndex, tokenLength);
			int num = startIndex + tokenLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (num == input.Length || input[num] != '=')
			{
				parsedValue = nameValueCreator();
				parsedValue._name = name;
				num += HttpRuleParser.GetWhitespaceLength(input, num);
				return num - startIndex;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			int valueLength = GetValueLength(input, num);
			if (valueLength == 0)
			{
				return 0;
			}
			parsedValue = nameValueCreator();
			parsedValue._name = name;
			parsedValue._value = input.Substring(num, valueLength);
			num += valueLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			return num - startIndex;
		}

		internal static int GetNameValueListLength(string input, int startIndex, char delimiter, ObjectCollection<NameValueHeaderValue> nameValueCollection)
		{
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int num = startIndex + HttpRuleParser.GetWhitespaceLength(input, startIndex);
			while (true)
			{
				NameValueHeaderValue parsedValue = null;
				int nameValueLength = GetNameValueLength(input, num, s_defaultNameValueCreator, out parsedValue);
				if (nameValueLength == 0)
				{
					return 0;
				}
				nameValueCollection.Add(parsedValue);
				num += nameValueLength;
				num += HttpRuleParser.GetWhitespaceLength(input, num);
				if (num == input.Length || input[num] != delimiter)
				{
					break;
				}
				num++;
				num += HttpRuleParser.GetWhitespaceLength(input, num);
			}
			return num - startIndex;
		}

		internal static NameValueHeaderValue Find(ObjectCollection<NameValueHeaderValue> values, string name)
		{
			if (values == null || values.Count == 0)
			{
				return null;
			}
			foreach (NameValueHeaderValue value in values)
			{
				if (string.Equals(value.Name, name, StringComparison.OrdinalIgnoreCase))
				{
					return value;
				}
			}
			return null;
		}

		internal static int GetValueLength(string input, int startIndex)
		{
			if (startIndex >= input.Length)
			{
				return 0;
			}
			int length = HttpRuleParser.GetTokenLength(input, startIndex);
			if (length == 0 && HttpRuleParser.GetQuotedStringLength(input, startIndex, out length) != HttpParseResult.Parsed)
			{
				return 0;
			}
			return length;
		}

		private static void CheckNameValueFormat(string name, string value)
		{
			HeaderUtilities.CheckValidToken(name, "name");
			CheckValueFormat(value);
		}

		private static void CheckValueFormat(string value)
		{
			if (!string.IsNullOrEmpty(value) && GetValueLength(value, 0) != value.Length)
			{
				throw new FormatException(string.Format(CultureInfo.InvariantCulture, "The format of value '{0}' is invalid.", value));
			}
		}

		private static NameValueHeaderValue CreateNameValue()
		{
			return new NameValueHeaderValue();
		}

		object ICloneable.Clone()
		{
			return new NameValueHeaderValue(this);
		}
	}
	public class NameValueWithParametersHeaderValue : NameValueHeaderValue, ICloneable
	{
		private static readonly Func<NameValueHeaderValue> s_nameValueCreator = CreateNameValue;

		private ObjectCollection<NameValueHeaderValue> _parameters;

		public ICollection<NameValueHeaderValue> Parameters
		{
			get
			{
				if (_parameters == null)
				{
					_parameters = new ObjectCollection<NameValueHeaderValue>();
				}
				return _parameters;
			}
		}

		public NameValueWithParametersHeaderValue(string name)
			: base(name)
		{
		}

		internal NameValueWithParametersHeaderValue()
		{
		}

		protected NameValueWithParametersHeaderValue(NameValueWithParametersHeaderValue source)
			: base(source)
		{
			if (source._parameters == null)
			{
				return;
			}
			foreach (NameValueHeaderValue parameter in source._parameters)
			{
				Parameters.Add((NameValueHeaderValue)((ICloneable)parameter).Clone());
			}
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				if (!(obj is NameValueWithParametersHeaderValue nameValueWithParametersHeaderValue))
				{
					return false;
				}
				return HeaderUtilities.AreEqualCollections(_parameters, nameValueWithParametersHeaderValue._parameters);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() ^ NameValueHeaderValue.GetHashCode(_parameters);
		}

		public override string ToString()
		{
			string value = base.ToString();
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			stringBuilder.Append(value);
			NameValueHeaderValue.ToString(_parameters, ';', leadingSeparator: true, stringBuilder);
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		internal static int GetNameValueWithParametersLength(string input, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			NameValueHeaderValue parsedValue2 = null;
			int nameValueLength = NameValueHeaderValue.GetNameValueLength(input, startIndex, s_nameValueCreator, out parsedValue2);
			if (nameValueLength == 0)
			{
				return 0;
			}
			int num = startIndex + nameValueLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			NameValueWithParametersHeaderValue nameValueWithParametersHeaderValue = parsedValue2 as NameValueWithParametersHeaderValue;
			if (num < input.Length && input[num] == ';')
			{
				num++;
				int nameValueListLength = NameValueHeaderValue.GetNameValueListLength(input, num, ';', (ObjectCollection<NameValueHeaderValue>)nameValueWithParametersHeaderValue.Parameters);
				if (nameValueListLength == 0)
				{
					return 0;
				}
				parsedValue = nameValueWithParametersHeaderValue;
				return num + nameValueListLength - startIndex;
			}
			parsedValue = nameValueWithParametersHeaderValue;
			return num - startIndex;
		}

		private static NameValueHeaderValue CreateNameValue()
		{
			return new NameValueWithParametersHeaderValue();
		}

		object ICloneable.Clone()
		{
			return new NameValueWithParametersHeaderValue(this);
		}
	}
	internal sealed class ObjectCollection<T> : Collection<T> where T : class
	{
		private static readonly Action<T> s_defaultValidator = CheckNotNull;

		private readonly Action<T> _validator;

		public ObjectCollection()
			: this(s_defaultValidator)
		{
		}

		public ObjectCollection(Action<T> validator)
			: base((IList<T>)new List<T>())
		{
			_validator = validator;
		}

		public new List<T>.Enumerator GetEnumerator()
		{
			return ((List<T>)base.Items).GetEnumerator();
		}

		protected override void InsertItem(int index, T item)
		{
			_validator(item);
			base.InsertItem(index, item);
		}

		protected override void SetItem(int index, T item)
		{
			_validator(item);
			base.SetItem(index, item);
		}

		private static void CheckNotNull(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
		}
	}
	public class ProductHeaderValue : ICloneable
	{
		private string _name;

		private string _version;

		private ProductHeaderValue(ProductHeaderValue source)
		{
			_name = source._name;
			_version = source._version;
		}

		private ProductHeaderValue()
		{
		}

		public override string ToString()
		{
			if (string.IsNullOrEmpty(_version))
			{
				return _name;
			}
			return _name + "/" + _version;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ProductHeaderValue productHeaderValue))
			{
				return false;
			}
			if (string.Equals(_name, productHeaderValue._name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(_version, productHeaderValue._version, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_name);
			if (!string.IsNullOrEmpty(_version))
			{
				num ^= StringComparer.OrdinalIgnoreCase.GetHashCode(_version);
			}
			return num;
		}

		internal static int GetProductLength(string input, int startIndex, out ProductHeaderValue parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex);
			if (tokenLength == 0)
			{
				return 0;
			}
			ProductHeaderValue productHeaderValue = new ProductHeaderValue();
			productHeaderValue._name = input.Substring(startIndex, tokenLength);
			int num = startIndex + tokenLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (num == input.Length || input[num] != '/')
			{
				parsedValue = productHeaderValue;
				return num - startIndex;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			int tokenLength2 = HttpRuleParser.GetTokenLength(input, num);
			if (tokenLength2 == 0)
			{
				return 0;
			}
			productHeaderValue._version = input.Substring(num, tokenLength2);
			num += tokenLength2;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			parsedValue = productHeaderValue;
			return num - startIndex;
		}

		object ICloneable.Clone()
		{
			return new ProductHeaderValue(this);
		}
	}
	internal class ProductInfoHeaderParser : HttpHeaderParser
	{
		internal static readonly ProductInfoHeaderParser SingleValueParser = new ProductInfoHeaderParser(supportsMultipleValues: false);

		internal static readonly ProductInfoHeaderParser MultipleValueParser = new ProductInfoHeaderParser(supportsMultipleValues: true);

		private ProductInfoHeaderParser(bool supportsMultipleValues)
			: base(supportsMultipleValues, " ")
		{
		}

		public override bool TryParseValue(string value, object storeValue, ref int index, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(value) || index == value.Length)
			{
				return false;
			}
			int num = index + HttpRuleParser.GetWhitespaceLength(value, index);
			if (num == value.Length)
			{
				return false;
			}
			ProductInfoHeaderValue parsedValue2 = null;
			int productInfoLength = ProductInfoHeaderValue.GetProductInfoLength(value, num, out parsedValue2);
			if (productInfoLength == 0)
			{
				return false;
			}
			num += productInfoLength;
			if (num < value.Length)
			{
				char c = value[num - 1];
				if (c != ' ' && c != '\t')
				{
					return false;
				}
			}
			index = num;
			parsedValue = parsedValue2;
			return true;
		}
	}
	public class ProductInfoHeaderValue : ICloneable
	{
		private ProductHeaderValue _product;

		private string _comment;

		private ProductInfoHeaderValue(ProductInfoHeaderValue source)
		{
			_product = source._product;
			_comment = source._comment;
		}

		private ProductInfoHeaderValue()
		{
		}

		public override string ToString()
		{
			if (_product == null)
			{
				return _comment;
			}
			return _product.ToString();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ProductInfoHeaderValue productInfoHeaderValue))
			{
				return false;
			}
			if (_product == null)
			{
				return string.Equals(_comment, productInfoHeaderValue._comment, StringComparison.Ordinal);
			}
			return _product.Equals(productInfoHeaderValue._product);
		}

		public override int GetHashCode()
		{
			if (_product == null)
			{
				return _comment.GetHashCode();
			}
			return _product.GetHashCode();
		}

		internal static int GetProductInfoLength(string input, int startIndex, out ProductInfoHeaderValue parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int num = startIndex;
			string comment = null;
			ProductHeaderValue parsedValue2 = null;
			if (input[num] == '(')
			{
				int length = 0;
				if (HttpRuleParser.GetCommentLength(input, num, out length) != HttpParseResult.Parsed)
				{
					return 0;
				}
				comment = input.Substring(num, length);
				num += length;
				num += HttpRuleParser.GetWhitespaceLength(input, num);
			}
			else
			{
				int productLength = ProductHeaderValue.GetProductLength(input, num, out parsedValue2);
				if (productLength == 0)
				{
					return 0;
				}
				num += productLength;
			}
			parsedValue = new ProductInfoHeaderValue();
			parsedValue._product = parsedValue2;
			parsedValue._comment = comment;
			return num - startIndex;
		}

		object ICloneable.Clone()
		{
			return new ProductInfoHeaderValue(this);
		}
	}
	public class RangeConditionHeaderValue : ICloneable
	{
		private DateTimeOffset? _date;

		private EntityTagHeaderValue _entityTag;

		private RangeConditionHeaderValue(RangeConditionHeaderValue source)
		{
			_entityTag = source._entityTag;
			_date = source._date;
		}

		private RangeConditionHeaderValue()
		{
		}

		public override string ToString()
		{
			if (_entityTag == null)
			{
				return HttpRuleParser.DateToString(_date.Value);
			}
			return _entityTag.ToString();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RangeConditionHeaderValue rangeConditionHeaderValue))
			{
				return false;
			}
			if (_entityTag == null)
			{
				if (rangeConditionHeaderValue._date.HasValue)
				{
					return _date.Value == rangeConditionHeaderValue._date.Value;
				}
				return false;
			}
			return _entityTag.Equals(rangeConditionHeaderValue._entityTag);
		}

		public override int GetHashCode()
		{
			if (_entityTag == null)
			{
				return _date.Value.GetHashCode();
			}
			return _entityTag.GetHashCode();
		}

		internal static int GetRangeConditionLength(string input, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex + 1 >= input.Length)
			{
				return 0;
			}
			int num = startIndex;
			DateTimeOffset result = DateTimeOffset.MinValue;
			EntityTagHeaderValue parsedValue2 = null;
			char c = input[num];
			char c2 = input[num + 1];
			if (c == '"' || ((c == 'w' || c == 'W') && c2 == '/'))
			{
				int entityTagLength = EntityTagHeaderValue.GetEntityTagLength(input, num, out parsedValue2);
				if (entityTagLength == 0)
				{
					return 0;
				}
				num += entityTagLength;
				if (num != input.Length)
				{
					return 0;
				}
			}
			else
			{
				if (!HttpRuleParser.TryStringToDate(input.Substring(num), out result))
				{
					return 0;
				}
				num = input.Length;
			}
			RangeConditionHeaderValue rangeConditionHeaderValue = new RangeConditionHeaderValue();
			if (parsedValue2 == null)
			{
				rangeConditionHeaderValue._date = result;
			}
			else
			{
				rangeConditionHeaderValue._entityTag = parsedValue2;
			}
			parsedValue = rangeConditionHeaderValue;
			return num - startIndex;
		}

		object ICloneable.Clone()
		{
			return new RangeConditionHeaderValue(this);
		}
	}
	public class RangeHeaderValue : ICloneable
	{
		private string _unit;

		private ObjectCollection<RangeItemHeaderValue> _ranges;

		public ICollection<RangeItemHeaderValue> Ranges
		{
			get
			{
				if (_ranges == null)
				{
					_ranges = new ObjectCollection<RangeItemHeaderValue>();
				}
				return _ranges;
			}
		}

		public RangeHeaderValue()
		{
			_unit = "bytes";
		}

		public RangeHeaderValue(long? from, long? to)
		{
			_unit = "bytes";
			Ranges.Add(new RangeItemHeaderValue(from, to));
		}

		private RangeHeaderValue(RangeHeaderValue source)
		{
			_unit = source._unit;
			if (source._ranges == null)
			{
				return;
			}
			foreach (RangeItemHeaderValue range in source._ranges)
			{
				Ranges.Add((RangeItemHeaderValue)((ICloneable)range).Clone());
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			stringBuilder.Append(_unit);
			stringBuilder.Append('=');
			if (_ranges != null)
			{
				bool flag = true;
				foreach (RangeItemHeaderValue range in _ranges)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append(range.From);
					stringBuilder.Append('-');
					stringBuilder.Append(range.To);
				}
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RangeHeaderValue rangeHeaderValue))
			{
				return false;
			}
			if (string.Equals(_unit, rangeHeaderValue._unit, StringComparison.OrdinalIgnoreCase))
			{
				return HeaderUtilities.AreEqualCollections(_ranges, rangeHeaderValue._ranges);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_unit);
			if (_ranges != null)
			{
				foreach (RangeItemHeaderValue range in _ranges)
				{
					num ^= range.GetHashCode();
				}
			}
			return num;
		}

		internal static int GetRangeLength(string input, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex);
			if (tokenLength == 0)
			{
				return 0;
			}
			RangeHeaderValue rangeHeaderValue = new RangeHeaderValue();
			rangeHeaderValue._unit = input.Substring(startIndex, tokenLength);
			int num = startIndex + tokenLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (num == input.Length || input[num] != '=')
			{
				return 0;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			int rangeItemListLength = RangeItemHeaderValue.GetRangeItemListLength(input, num, rangeHeaderValue.Ranges);
			if (rangeItemListLength == 0)
			{
				return 0;
			}
			num += rangeItemListLength;
			parsedValue = rangeHeaderValue;
			return num - startIndex;
		}

		object ICloneable.Clone()
		{
			return new RangeHeaderValue(this);
		}
	}
	public class RangeItemHeaderValue : ICloneable
	{
		private long? _from;

		private long? _to;

		public long? From => _from;

		public long? To => _to;

		public RangeItemHeaderValue(long? from, long? to)
		{
			if (!from.HasValue && !to.HasValue)
			{
				throw new ArgumentException("Invalid range. At least one of the two parameters must not be null.");
			}
			if (from.HasValue && from.Value < 0)
			{
				throw new ArgumentOutOfRangeException("from");
			}
			if (to.HasValue && to.Value < 0)
			{
				throw new ArgumentOutOfRangeException("to");
			}
			if (from.HasValue && to.HasValue && from.Value > to.Value)
			{
				throw new ArgumentOutOfRangeException("from");
			}
			_from = from;
			_to = to;
		}

		private RangeItemHeaderValue(RangeItemHeaderValue source)
		{
			_from = source._from;
			_to = source._to;
		}

		public override string ToString()
		{
			if (!_from.HasValue)
			{
				return "-" + _to.Value.ToString(NumberFormatInfo.InvariantInfo);
			}
			if (!_to.HasValue)
			{
				return _from.Value.ToString(NumberFormatInfo.InvariantInfo) + "-";
			}
			return _from.Value.ToString(NumberFormatInfo.InvariantInfo) + "-" + _to.Value.ToString(NumberFormatInfo.InvariantInfo);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RangeItemHeaderValue rangeItemHeaderValue))
			{
				return false;
			}
			if (_from == rangeItemHeaderValue._from)
			{
				return _to == rangeItemHeaderValue._to;
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (!_from.HasValue)
			{
				return _to.GetHashCode();
			}
			if (!_to.HasValue)
			{
				return _from.GetHashCode();
			}
			return _from.GetHashCode() ^ _to.GetHashCode();
		}

		internal static int GetRangeItemListLength(string input, int startIndex, ICollection<RangeItemHeaderValue> rangeCollection)
		{
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			bool separatorFound = false;
			int nextNonEmptyOrWhitespaceIndex = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(input, startIndex, skipEmptyValues: true, out separatorFound);
			if (nextNonEmptyOrWhitespaceIndex == input.Length)
			{
				return 0;
			}
			RangeItemHeaderValue parsedValue = null;
			do
			{
				int rangeItemLength = GetRangeItemLength(input, nextNonEmptyOrWhitespaceIndex, out parsedValue);
				if (rangeItemLength == 0)
				{
					return 0;
				}
				rangeCollection.Add(parsedValue);
				nextNonEmptyOrWhitespaceIndex += rangeItemLength;
				nextNonEmptyOrWhitespaceIndex = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(input, nextNonEmptyOrWhitespaceIndex, skipEmptyValues: true, out separatorFound);
				if (nextNonEmptyOrWhitespaceIndex < input.Length && !separatorFound)
				{
					return 0;
				}
			}
			while (nextNonEmptyOrWhitespaceIndex != input.Length);
			return nextNonEmptyOrWhitespaceIndex - startIndex;
		}

		internal static int GetRangeItemLength(string input, int startIndex, out RangeItemHeaderValue parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int num = startIndex;
			int offset = num;
			int numberLength = HttpRuleParser.GetNumberLength(input, num, allowDecimal: false);
			if (numberLength > 19)
			{
				return 0;
			}
			num += numberLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (num == input.Length || input[num] != '-')
			{
				return 0;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			int offset2 = num;
			int num2 = 0;
			if (num < input.Length)
			{
				num2 = HttpRuleParser.GetNumberLength(input, num, allowDecimal: false);
				if (num2 > 19)
				{
					return 0;
				}
				num += num2;
				num += HttpRuleParser.GetWhitespaceLength(input, num);
			}
			if (numberLength == 0 && num2 == 0)
			{
				return 0;
			}
			long result = 0L;
			if (numberLength > 0 && !HeaderUtilities.TryParseInt64(input, offset, numberLength, out result))
			{
				return 0;
			}
			long result2 = 0L;
			if (num2 > 0 && !HeaderUtilities.TryParseInt64(input, offset2, num2, out result2))
			{
				return 0;
			}
			if (numberLength > 0 && num2 > 0 && result > result2)
			{
				return 0;
			}
			parsedValue = new RangeItemHeaderValue((numberLength == 0) ? ((long?)null) : new long?(result), (num2 == 0) ? ((long?)null) : new long?(result2));
			return num - startIndex;
		}

		object ICloneable.Clone()
		{
			return new RangeItemHeaderValue(this);
		}
	}
	public class RetryConditionHeaderValue : ICloneable
	{
		private DateTimeOffset? _date;

		private TimeSpan? _delta;

		private RetryConditionHeaderValue(RetryConditionHeaderValue source)
		{
			_delta = source._delta;
			_date = source._date;
		}

		private RetryConditionHeaderValue()
		{
		}

		public override string ToString()
		{
			if (_delta.HasValue)
			{
				return ((int)_delta.Value.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo);
			}
			return HttpRuleParser.DateToString(_date.Value);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RetryConditionHeaderValue retryConditionHeaderValue))
			{
				return false;
			}
			if (_delta.HasValue)
			{
				if (retryConditionHeaderValue._delta.HasValue)
				{
					return _delta.Value == retryConditionHeaderValue._delta.Value;
				}
				return false;
			}
			if (retryConditionHeaderValue._date.HasValue)
			{
				return _date.Value == retryConditionHeaderValue._date.Value;
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (!_delta.HasValue)
			{
				return _date.Value.GetHashCode();
			}
			return _delta.Value.GetHashCode();
		}

		internal static int GetRetryConditionLength(string input, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int num = startIndex;
			DateTimeOffset result = DateTimeOffset.MinValue;
			int result2 = -1;
			char c = input[num];
			if (c >= '0' && c <= '9')
			{
				int offset = num;
				int numberLength = HttpRuleParser.GetNumberLength(input, num, allowDecimal: false);
				if (numberLength == 0 || numberLength > 10)
				{
					return 0;
				}
				num += numberLength;
				num += HttpRuleParser.GetWhitespaceLength(input, num);
				if (num != input.Length)
				{
					return 0;
				}
				if (!HeaderUtilities.TryParseInt32(input, offset, numberLength, out result2))
				{
					return 0;
				}
			}
			else
			{
				if (!HttpRuleParser.TryStringToDate(input.Substring(num), out result))
				{
					return 0;
				}
				num = input.Length;
			}
			RetryConditionHeaderValue retryConditionHeaderValue = new RetryConditionHeaderValue();
			if (result2 == -1)
			{
				retryConditionHeaderValue._date = result;
			}
			else
			{
				retryConditionHeaderValue._delta = new TimeSpan(0, 0, result2);
			}
			parsedValue = retryConditionHeaderValue;
			return num - startIndex;
		}

		object ICloneable.Clone()
		{
			return new RetryConditionHeaderValue(this);
		}
	}
	public class StringWithQualityHeaderValue : ICloneable
	{
		private string _value;

		private double? _quality;

		public StringWithQualityHeaderValue(string value)
		{
			HeaderUtilities.CheckValidToken(value, "value");
			_value = value;
		}

		private StringWithQualityHeaderValue(StringWithQualityHeaderValue source)
		{
			_value = source._value;
			_quality = source._quality;
		}

		private StringWithQualityHeaderValue()
		{
		}

		public override string ToString()
		{
			if (_quality.HasValue)
			{
				return _value + "; q=" + _quality.Value.ToString("0.0##", NumberFormatInfo.InvariantInfo);
			}
			return _value;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is StringWithQualityHeaderValue stringWithQualityHeaderValue))
			{
				return false;
			}
			if (!string.Equals(_value, stringWithQualityHeaderValue._value, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			if (_quality.HasValue)
			{
				if (stringWithQualityHeaderValue._quality.HasValue)
				{
					return _quality.Value == stringWithQualityHeaderValue._quality.Value;
				}
				return false;
			}
			return !stringWithQualityHeaderValue._quality.HasValue;
		}

		public override int GetHashCode()
		{
			int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_value);
			if (_quality.HasValue)
			{
				num ^= _quality.Value.GetHashCode();
			}
			return num;
		}

		internal static int GetStringWithQualityLength(string input, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex);
			if (tokenLength == 0)
			{
				return 0;
			}
			StringWithQualityHeaderValue stringWithQualityHeaderValue = new StringWithQualityHeaderValue();
			stringWithQualityHeaderValue._value = input.Substring(startIndex, tokenLength);
			int num = startIndex + tokenLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (num == input.Length || input[num] != ';')
			{
				parsedValue = stringWithQualityHeaderValue;
				return num - startIndex;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (!TryReadQuality(input, stringWithQualityHeaderValue, ref num))
			{
				return 0;
			}
			parsedValue = stringWithQualityHeaderValue;
			return num - startIndex;
		}

		private static bool TryReadQuality(string input, StringWithQualityHeaderValue result, ref int index)
		{
			int num = index;
			if (num == input.Length || (input[num] != 'q' && input[num] != 'Q'))
			{
				return false;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (num == input.Length || input[num] != '=')
			{
				return false;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			if (num == input.Length)
			{
				return false;
			}
			int numberLength = HttpRuleParser.GetNumberLength(input, num, allowDecimal: true);
			if (numberLength == 0)
			{
				return false;
			}
			double result2 = 0.0;
			if (!double.TryParse(input.Substring(num, numberLength), NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result2))
			{
				return false;
			}
			if (result2 < 0.0 || result2 > 1.0)
			{
				return false;
			}
			result._quality = result2;
			num += numberLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			index = num;
			return true;
		}

		object ICloneable.Clone()
		{
			return new StringWithQualityHeaderValue(this);
		}
	}
	internal class TimeSpanHeaderParser : BaseHeaderParser
	{
		internal static readonly TimeSpanHeaderParser Parser = new TimeSpanHeaderParser();

		private TimeSpanHeaderParser()
			: base(supportsMultipleValues: false)
		{
		}

		public override string ToString(object value)
		{
			return ((int)((TimeSpan)value).TotalSeconds).ToString(NumberFormatInfo.InvariantInfo);
		}

		protected override int GetParsedValueLength(string value, int startIndex, object storeValue, out object parsedValue)
		{
			parsedValue = null;
			int numberLength = HttpRuleParser.GetNumberLength(value, startIndex, allowDecimal: false);
			if (numberLength == 0 || numberLength > 10)
			{
				return 0;
			}
			int result = 0;
			if (!HeaderUtilities.TryParseInt32(value, startIndex, numberLength, out result))
			{
				return 0;
			}
			parsedValue = new TimeSpan(0, 0, result);
			return numberLength;
		}
	}
	internal class TransferCodingHeaderParser : BaseHeaderParser
	{
		private Func<TransferCodingHeaderValue> _transferCodingCreator;

		internal static readonly TransferCodingHeaderParser SingleValueParser = new TransferCodingHeaderParser(supportsMultipleValues: false, CreateTransferCoding);

		internal static readonly TransferCodingHeaderParser MultipleValueParser = new TransferCodingHeaderParser(supportsMultipleValues: true, CreateTransferCoding);

		internal static readonly TransferCodingHeaderParser SingleValueWithQualityParser = new TransferCodingHeaderParser(supportsMultipleValues: false, CreateTransferCodingWithQuality);

		internal static readonly TransferCodingHeaderParser MultipleValueWithQualityParser = new TransferCodingHeaderParser(supportsMultipleValues: true, CreateTransferCodingWithQuality);

		private TransferCodingHeaderParser(bool supportsMultipleValues, Func<TransferCodingHeaderValue> transferCodingCreator)
			: base(supportsMultipleValues)
		{
			_transferCodingCreator = transferCodingCreator;
		}

		protected override int GetParsedValueLength(string value, int startIndex, object storeValue, out object parsedValue)
		{
			TransferCodingHeaderValue parsedValue2 = null;
			int transferCodingLength = TransferCodingHeaderValue.GetTransferCodingLength(value, startIndex, _transferCodingCreator, out parsedValue2);
			parsedValue = parsedValue2;
			return transferCodingLength;
		}

		private static TransferCodingHeaderValue CreateTransferCoding()
		{
			return new TransferCodingHeaderValue();
		}

		private static TransferCodingHeaderValue CreateTransferCodingWithQuality()
		{
			return new TransferCodingWithQualityHeaderValue();
		}
	}
	public class TransferCodingHeaderValue : ICloneable
	{
		private ObjectCollection<NameValueHeaderValue> _parameters;

		private string _value;

		public ICollection<NameValueHeaderValue> Parameters
		{
			get
			{
				if (_parameters == null)
				{
					_parameters = new ObjectCollection<NameValueHeaderValue>();
				}
				return _parameters;
			}
		}

		internal TransferCodingHeaderValue()
		{
		}

		protected TransferCodingHeaderValue(TransferCodingHeaderValue source)
		{
			_value = source._value;
			if (source._parameters == null)
			{
				return;
			}
			foreach (NameValueHeaderValue parameter in source._parameters)
			{
				Parameters.Add((NameValueHeaderValue)((ICloneable)parameter).Clone());
			}
		}

		public TransferCodingHeaderValue(string value)
		{
			HeaderUtilities.CheckValidToken(value, "value");
			_value = value;
		}

		internal static int GetTransferCodingLength(string input, int startIndex, Func<TransferCodingHeaderValue> transferCodingCreator, out TransferCodingHeaderValue parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex);
			if (tokenLength == 0)
			{
				return 0;
			}
			string value = input.Substring(startIndex, tokenLength);
			int num = startIndex + tokenLength;
			num += HttpRuleParser.GetWhitespaceLength(input, num);
			TransferCodingHeaderValue transferCodingHeaderValue = null;
			if (num < input.Length && input[num] == ';')
			{
				transferCodingHeaderValue = transferCodingCreator();
				transferCodingHeaderValue._value = value;
				num++;
				int nameValueListLength = NameValueHeaderValue.GetNameValueListLength(input, num, ';', (ObjectCollection<NameValueHeaderValue>)transferCodingHeaderValue.Parameters);
				if (nameValueListLength == 0)
				{
					return 0;
				}
				parsedValue = transferCodingHeaderValue;
				return num + nameValueListLength - startIndex;
			}
			transferCodingHeaderValue = transferCodingCreator();
			transferCodingHeaderValue._value = value;
			parsedValue = transferCodingHeaderValue;
			return num - startIndex;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			stringBuilder.Append(_value);
			NameValueHeaderValue.ToString(_parameters, ';', leadingSeparator: true, stringBuilder);
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is TransferCodingHeaderValue transferCodingHeaderValue))
			{
				return false;
			}
			if (string.Equals(_value, transferCodingHeaderValue._value, StringComparison.OrdinalIgnoreCase))
			{
				return HeaderUtilities.AreEqualCollections(_parameters, transferCodingHeaderValue._parameters);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return StringComparer.OrdinalIgnoreCase.GetHashCode(_value) ^ NameValueHeaderValue.GetHashCode(_parameters);
		}

		object ICloneable.Clone()
		{
			return new TransferCodingHeaderValue(this);
		}
	}
	public sealed class TransferCodingWithQualityHeaderValue : TransferCodingHeaderValue, ICloneable
	{
		internal TransferCodingWithQualityHeaderValue()
		{
		}

		private TransferCodingWithQualityHeaderValue(TransferCodingWithQualityHeaderValue source)
			: base(source)
		{
		}

		object ICloneable.Clone()
		{
			return new TransferCodingWithQualityHeaderValue(this);
		}
	}
	internal class UriHeaderParser : HttpHeaderParser
	{
		private UriKind _uriKind;

		internal static readonly UriHeaderParser RelativeOrAbsoluteUriParser = new UriHeaderParser((UriKind)300);

		private UriHeaderParser(UriKind uriKind)
			: base(supportsMultipleValues: false)
		{
			_uriKind = uriKind;
		}

		public override bool TryParseValue(string value, object storeValue, ref int index, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(value) || index == value.Length)
			{
				return false;
			}
			string text = value;
			if (index > 0)
			{
				text = value.Substring(index);
			}
			if (!Uri.TryCreate(text, _uriKind, out var result))
			{
				text = DecodeUtf8FromString(text);
				if (!Uri.TryCreate(text, _uriKind, out result))
				{
					return false;
				}
			}
			index = value.Length;
			parsedValue = result;
			return true;
		}

		internal static string DecodeUtf8FromString(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return input;
			}
			bool flag = false;
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] > 'ÿ')
				{
					return input;
				}
				if (input[i] > '\u007f')
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				byte[] array = new byte[input.Length];
				for (int j = 0; j < input.Length; j++)
				{
					if (input[j] > 'ÿ')
					{
						return input;
					}
					array[j] = (byte)input[j];
				}
				try
				{
					return Encoding.GetEncoding("utf-8", EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback).GetString(array, 0, array.Length);
				}
				catch (ArgumentException)
				{
				}
			}
			return input;
		}

		public override string ToString(object value)
		{
			Uri uri = (Uri)value;
			if (uri.IsAbsoluteUri)
			{
				return uri.AbsoluteUri;
			}
			return uri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped);
		}
	}
	public class ViaHeaderValue : ICloneable
	{
		private string _protocolName;

		private string _protocolVersion;

		private string _receivedBy;

		private string _comment;

		private ViaHeaderValue()
		{
		}

		private ViaHeaderValue(ViaHeaderValue source)
		{
			_protocolName = source._protocolName;
			_protocolVersion = source._protocolVersion;
			_receivedBy = source._receivedBy;
			_comment = source._comment;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			if (!string.IsNullOrEmpty(_protocolName))
			{
				stringBuilder.Append(_protocolName);
				stringBuilder.Append('/');
			}
			stringBuilder.Append(_protocolVersion);
			stringBuilder.Append(' ');
			stringBuilder.Append(_receivedBy);
			if (!string.IsNullOrEmpty(_comment))
			{
				stringBuilder.Append(' ');
				stringBuilder.Append(_comment);
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ViaHeaderValue viaHeaderValue))
			{
				return false;
			}
			if (string.Equals(_protocolVersion, viaHeaderValue._protocolVersion, StringComparison.OrdinalIgnoreCase) && string.Equals(_receivedBy, viaHeaderValue._receivedBy, StringComparison.OrdinalIgnoreCase) && string.Equals(_protocolName, viaHeaderValue._protocolName, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(_comment, viaHeaderValue._comment, StringComparison.Ordinal);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_protocolVersion) ^ StringComparer.OrdinalIgnoreCase.GetHashCode(_receivedBy);
			if (!string.IsNullOrEmpty(_protocolName))
			{
				num ^= StringComparer.OrdinalIgnoreCase.GetHashCode(_protocolName);
			}
			if (!string.IsNullOrEmpty(_comment))
			{
				num ^= _comment.GetHashCode();
			}
			return num;
		}

		internal static int GetViaLength(string input, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			string protocolName = null;
			string protocolVersion = null;
			int protocolEndIndex = GetProtocolEndIndex(input, startIndex, out protocolName, out protocolVersion);
			if (protocolEndIndex == startIndex || protocolEndIndex == input.Length)
			{
				return 0;
			}
			string host = null;
			int hostLength = HttpRuleParser.GetHostLength(input, protocolEndIndex, allowToken: true, out host);
			if (hostLength == 0)
			{
				return 0;
			}
			protocolEndIndex += hostLength;
			protocolEndIndex += HttpRuleParser.GetWhitespaceLength(input, protocolEndIndex);
			string comment = null;
			if (protocolEndIndex < input.Length && input[protocolEndIndex] == '(')
			{
				int length = 0;
				if (HttpRuleParser.GetCommentLength(input, protocolEndIndex, out length) != HttpParseResult.Parsed)
				{
					return 0;
				}
				comment = input.Substring(protocolEndIndex, length);
				protocolEndIndex += length;
				protocolEndIndex += HttpRuleParser.GetWhitespaceLength(input, protocolEndIndex);
			}
			ViaHeaderValue viaHeaderValue = new ViaHeaderValue();
			viaHeaderValue._protocolVersion = protocolVersion;
			viaHeaderValue._protocolName = protocolName;
			viaHeaderValue._receivedBy = host;
			viaHeaderValue._comment = comment;
			parsedValue = viaHeaderValue;
			return protocolEndIndex - startIndex;
		}

		private static int GetProtocolEndIndex(string input, int startIndex, out string protocolName, out string protocolVersion)
		{
			protocolName = null;
			protocolVersion = null;
			int startIndex2 = startIndex;
			int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex2);
			if (tokenLength == 0)
			{
				return 0;
			}
			startIndex2 = startIndex + tokenLength;
			int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, startIndex2);
			startIndex2 += whitespaceLength;
			if (startIndex2 == input.Length)
			{
				return 0;
			}
			if (input[startIndex2] == '/')
			{
				protocolName = input.Substring(startIndex, tokenLength);
				startIndex2++;
				startIndex2 += HttpRuleParser.GetWhitespaceLength(input, startIndex2);
				tokenLength = HttpRuleParser.GetTokenLength(input, startIndex2);
				if (tokenLength == 0)
				{
					return 0;
				}
				protocolVersion = input.Substring(startIndex2, tokenLength);
				startIndex2 += tokenLength;
				whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, startIndex2);
				startIndex2 += whitespaceLength;
			}
			else
			{
				protocolVersion = input.Substring(startIndex, tokenLength);
			}
			if (whitespaceLength == 0)
			{
				return 0;
			}
			return startIndex2;
		}

		object ICloneable.Clone()
		{
			return new ViaHeaderValue(this);
		}
	}
	public class WarningHeaderValue : ICloneable
	{
		private int _code;

		private string _agent;

		private string _text;

		private DateTimeOffset? _date;

		private WarningHeaderValue()
		{
		}

		private WarningHeaderValue(WarningHeaderValue source)
		{
			_code = source._code;
			_agent = source._agent;
			_text = source._text;
			_date = source._date;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire();
			stringBuilder.Append(_code.ToString("000", NumberFormatInfo.InvariantInfo));
			stringBuilder.Append(' ');
			stringBuilder.Append(_agent);
			stringBuilder.Append(' ');
			stringBuilder.Append(_text);
			if (_date.HasValue)
			{
				stringBuilder.Append(" \"");
				stringBuilder.Append(HttpRuleParser.DateToString(_date.Value));
				stringBuilder.Append('"');
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is WarningHeaderValue warningHeaderValue))
			{
				return false;
			}
			if (_code != warningHeaderValue._code || !string.Equals(_agent, warningHeaderValue._agent, StringComparison.OrdinalIgnoreCase) || !string.Equals(_text, warningHeaderValue._text, StringComparison.Ordinal))
			{
				return false;
			}
			if (_date.HasValue)
			{
				if (warningHeaderValue._date.HasValue)
				{
					return _date.Value == warningHeaderValue._date.Value;
				}
				return false;
			}
			return !warningHeaderValue._date.HasValue;
		}

		public override int GetHashCode()
		{
			int num = _code.GetHashCode() ^ StringComparer.OrdinalIgnoreCase.GetHashCode(_agent) ^ _text.GetHashCode();
			if (_date.HasValue)
			{
				num ^= _date.Value.GetHashCode();
			}
			return num;
		}

		internal static int GetWarningLength(string input, int startIndex, out object parsedValue)
		{
			parsedValue = null;
			if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
			{
				return 0;
			}
			int current = startIndex;
			if (!TryReadCode(input, ref current, out var code))
			{
				return 0;
			}
			if (!TryReadAgent(input, current, ref current, out var agent))
			{
				return 0;
			}
			int length = 0;
			int startIndex2 = current;
			if (HttpRuleParser.GetQuotedStringLength(input, current, out length) != HttpParseResult.Parsed)
			{
				return 0;
			}
			current += length;
			DateTimeOffset? date = null;
			if (!TryReadDate(input, ref current, out date))
			{
				return 0;
			}
			WarningHeaderValue warningHeaderValue = new WarningHeaderValue();
			warningHeaderValue._code = code;
			warningHeaderValue._agent = agent;
			warningHeaderValue._text = input.Substring(startIndex2, length);
			warningHeaderValue._date = date;
			parsedValue = warningHeaderValue;
			return current - startIndex;
		}

		private static bool TryReadAgent(string input, int startIndex, ref int current, out string agent)
		{
			agent = null;
			int hostLength = HttpRuleParser.GetHostLength(input, startIndex, allowToken: true, out agent);
			if (hostLength == 0)
			{
				return false;
			}
			current += hostLength;
			int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, current);
			current += whitespaceLength;
			if (whitespaceLength == 0 || current == input.Length)
			{
				return false;
			}
			return true;
		}

		private static bool TryReadCode(string input, ref int current, out int code)
		{
			code = 0;
			int numberLength = HttpRuleParser.GetNumberLength(input, current, allowDecimal: false);
			if (numberLength == 0 || numberLength > 3)
			{
				return false;
			}
			if (!HeaderUtilities.TryParseInt32(input, current, numberLength, out code))
			{
				return false;
			}
			current += numberLength;
			int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, current);
			current += whitespaceLength;
			if (whitespaceLength == 0 || current == input.Length)
			{
				return false;
			}
			return true;
		}

		private static bool TryReadDate(string input, ref int current, out DateTimeOffset? date)
		{
			date = null;
			int whitespaceLength = HttpRuleParser.GetWhitespaceLength(input, current);
			current += whitespaceLength;
			if (current < input.Length && input[current] == '"')
			{
				if (whitespaceLength == 0)
				{
					return false;
				}
				current++;
				int num = current;
				while (current < input.Length && input[current] != '"')
				{
					current++;
				}
				if (current == input.Length || current == num)
				{
					return false;
				}
				if (!HttpRuleParser.TryStringToDate(input.Substring(num, current - num), out var result))
				{
					return false;
				}
				date = result;
				current++;
				current += HttpRuleParser.GetWhitespaceLength(input, current);
			}
			return true;
		}

		object ICloneable.Clone()
		{
			return new WarningHeaderValue(this);
		}
	}
}
