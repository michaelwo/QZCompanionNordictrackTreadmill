using System;
using System.Buffers;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Refit.Buffers;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyFileVersion("5.1.67.51202")]
[assembly: AssemblyInformationalVersion("5.1.67+02c856d1d7")]
[assembly: InternalsVisibleTo("Refit.Tests, PublicKey=00240000048000009400000006020000002400005253413100040000010001009dc017250415a0d51fddb74de84257c388028f04893673ca5c8f9e7145aea2b11443cb49dd79386d2255179a79ec516466b621f77e43386e711b775f77bb0e4b217f8c208c054e5f515ae33ee76bac1b56cdc20e1c151cf026a9b7f8362f1963825e546e16b360dfc63fe670403c9d6152c24491dd5dfb9ff68fe102ef3e1aed")]
[assembly: InternalsVisibleTo("Refit.HttpClientFactory, PublicKey=00240000048000009400000006020000002400005253413100040000010001009dc017250415a0d51fddb74de84257c388028f04893673ca5c8f9e7145aea2b11443cb49dd79386d2255179a79ec516466b621f77e43386e711b775f77bb0e4b217f8c208c054e5f515ae33ee76bac1b56cdc20e1c151cf026a9b7f8362f1963825e546e16b360dfc63fe670403c9d6152c24491dd5dfb9ff68fe102ef3e1aed")]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyMetadata("CommitHash", "02c856d1d7b3c617dc654dcbc13751dd9425d721")]
[assembly: AssemblyCompany(".NET Foundation and Contributors")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("The automatic type-safe REST library for Xamarin and .NET")]
[assembly: AssemblyProduct("Refit (netstandard2.1)")]
[assembly: AssemblyTitle("Refit")]
[assembly: AssemblyVersion("5.1.0.0")]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
}
[GeneratedCode("Nerdbank.GitVersioning.Tasks", "3.1.74.65439")]
[ExcludeFromCodeCoverage]
internal static class ThisAssembly
{
	internal const string AssemblyVersion = "5.1.0.0";

	internal const string AssemblyFileVersion = "5.1.67.51202";

	internal const string AssemblyInformationalVersion = "5.1.67+02c856d1d7";

	internal const string AssemblyName = "Refit";

	internal const string AssemblyTitle = "Refit";

	internal const string AssemblyConfiguration = "Release";

	internal const string GitCommitId = "02c856d1d7b3c617dc654dcbc13751dd9425d721";

	internal const string PublicKey = "00240000048000009400000006020000002400005253413100040000010001009dc017250415a0d51fddb74de84257c388028f04893673ca5c8f9e7145aea2b11443cb49dd79386d2255179a79ec516466b621f77e43386e711b775f77bb0e4b217f8c208c054e5f515ae33ee76bac1b56cdc20e1c151cf026a9b7f8362f1963825e546e16b360dfc63fe670403c9d6152c24491dd5dfb9ff68fe102ef3e1aed";

	internal const string PublicKeyToken = "2f9b1262776509f5";

	internal const bool IsPublicRelease = true;

	internal const bool IsPrerelease = false;

	internal static readonly DateTime GitCommitDate = new DateTime(637219326000000000L, DateTimeKind.Utc);

	internal const string RootNamespace = "Refit";
}
namespace System.Net.Http
{
	[ExcludeFromCodeCoverage]
	internal class PushStreamContent : HttpContent
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct AsyncVoid
		{
		}

		internal class CompleteTaskOnCloseStream : System.Net.Http.DelegatingStream
		{
			private readonly TaskCompletionSource<bool> _serializeToStreamTask;

			public CompleteTaskOnCloseStream(Stream innerStream, TaskCompletionSource<bool> serializeToStreamTask)
				: base(innerStream)
			{
				_serializeToStreamTask = serializeToStreamTask;
			}

			protected override void Dispose(bool disposing)
			{
				_serializeToStreamTask.TrySetResult(result: true);
			}
		}

		private readonly Func<Stream, HttpContent, TransportContext, Task> _onStreamAvailable;

		public PushStreamContent(Action<Stream, HttpContent, TransportContext> onStreamAvailable)
			: this(Taskify(onStreamAvailable), (MediaTypeHeaderValue)null)
		{
		}

		public PushStreamContent(Func<Stream, HttpContent, TransportContext, Task> onStreamAvailable)
			: this(onStreamAvailable, (MediaTypeHeaderValue)null)
		{
		}

		public PushStreamContent(Action<Stream, HttpContent, TransportContext> onStreamAvailable, string mediaType)
			: this(Taskify(onStreamAvailable), new MediaTypeHeaderValue(mediaType))
		{
		}

		public PushStreamContent(Func<Stream, HttpContent, TransportContext, Task> onStreamAvailable, string mediaType)
			: this(onStreamAvailable, new MediaTypeHeaderValue(mediaType))
		{
		}

		public PushStreamContent(Action<Stream, HttpContent, TransportContext> onStreamAvailable, MediaTypeHeaderValue mediaType)
			: this(Taskify(onStreamAvailable), mediaType)
		{
		}

		public PushStreamContent(Func<Stream, HttpContent, TransportContext, Task> onStreamAvailable, MediaTypeHeaderValue mediaType)
		{
			_onStreamAvailable = onStreamAvailable ?? throw new ArgumentNullException("onStreamAvailable");
			base.Headers.ContentType = mediaType ?? new MediaTypeHeaderValue("application/octet-stream");
		}

		private static Func<Stream, HttpContent, TransportContext, Task> Taskify(Action<Stream, HttpContent, TransportContext> onStreamAvailable)
		{
			if (onStreamAvailable == null)
			{
				throw new ArgumentNullException("onStreamAvailable");
			}
			return delegate(Stream stream, HttpContent content, TransportContext transportContext)
			{
				onStreamAvailable(stream, content, transportContext);
				return Task.FromResult(default(AsyncVoid));
			};
		}

		protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
		{
			TaskCompletionSource<bool> serializeToStreamTask = new TaskCompletionSource<bool>();
			Stream arg = new CompleteTaskOnCloseStream(stream, serializeToStreamTask);
			await _onStreamAvailable(arg, this, context);
			await serializeToStreamTask.Task;
		}

		protected override bool TryComputeLength(out long length)
		{
			length = -1L;
			return false;
		}
	}
	[ExcludeFromCodeCoverage]
	internal abstract class DelegatingStream : Stream
	{
		protected Stream InnerStream { get; private set; }

		public override bool CanRead => InnerStream.CanRead;

		public override bool CanSeek => InnerStream.CanSeek;

		public override bool CanWrite => InnerStream.CanWrite;

		public override long Length => InnerStream.Length;

		public override long Position
		{
			get
			{
				return InnerStream.Position;
			}
			set
			{
				InnerStream.Position = value;
			}
		}

		public override int ReadTimeout
		{
			get
			{
				return InnerStream.ReadTimeout;
			}
			set
			{
				InnerStream.ReadTimeout = value;
			}
		}

		public override bool CanTimeout => InnerStream.CanTimeout;

		public override int WriteTimeout
		{
			get
			{
				return InnerStream.WriteTimeout;
			}
			set
			{
				InnerStream.WriteTimeout = value;
			}
		}

		protected DelegatingStream(Stream innerStream)
		{
			InnerStream = innerStream ?? throw new ArgumentNullException("innerStream");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				InnerStream.Dispose();
			}
			base.Dispose(disposing);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return InnerStream.Seek(offset, origin);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return InnerStream.Read(buffer, offset, count);
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return InnerStream.ReadAsync(buffer, offset, count, cancellationToken);
		}

		public override int ReadByte()
		{
			return InnerStream.ReadByte();
		}

		public override void Flush()
		{
			InnerStream.Flush();
		}

		public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
		{
			return InnerStream.CopyToAsync(destination, bufferSize, cancellationToken);
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return InnerStream.FlushAsync(cancellationToken);
		}

		public override void SetLength(long value)
		{
			InnerStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			InnerStream.Write(buffer, offset, count);
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return InnerStream.WriteAsync(buffer, offset, count, cancellationToken);
		}

		public override void WriteByte(byte value)
		{
			InnerStream.WriteByte(value);
		}
	}
}
namespace System.Collections.Specialized
{
	internal class NameValueCollection : Dictionary<string, string>
	{
		public string[] AllKeys => base.Keys.ToArray();
	}
}
namespace Refit
{
	internal sealed class AnonymousDisposable : IDisposable
	{
		private readonly Action block;

		public AnonymousDisposable(Action block)
		{
			this.block = block;
		}

		public void Dispose()
		{
			block();
		}
	}
	[Serializable]
	public class ApiException : Exception
	{
		public HttpStatusCode StatusCode { get; }

		public string ReasonPhrase { get; }

		public HttpResponseHeaders Headers { get; }

		public HttpMethod HttpMethod { get; }

		public Uri Uri => RequestMessage.RequestUri;

		public HttpRequestMessage RequestMessage { get; }

		public HttpContentHeaders ContentHeaders { get; private set; }

		public string Content { get; private set; }

		public bool HasContent => !string.IsNullOrWhiteSpace(Content);

		public RefitSettings RefitSettings { get; set; }

		protected ApiException(HttpRequestMessage message, HttpMethod httpMethod, HttpStatusCode statusCode, string reasonPhrase, HttpResponseHeaders headers, RefitSettings refitSettings = null)
			: base(CreateMessage(statusCode, reasonPhrase))
		{
			RequestMessage = message;
			HttpMethod = httpMethod;
			StatusCode = statusCode;
			ReasonPhrase = reasonPhrase;
			Headers = headers;
			RefitSettings = refitSettings;
		}

		[Obsolete("Use GetContentAsAsync<T>() instead", false)]
		public T GetContentAs<T>()
		{
			return GetContentAsAsync<T>().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter().GetResult();
		}

		public async Task<T> GetContentAsAsync<T>()
		{
			return (!HasContent) ? default(T) : (await RefitSettings.ContentSerializer.DeserializeAsync<T>(new StringContent(Content)).ConfigureAwait(continueOnCapturedContext: false));
		}

		public static async Task<ApiException> Create(HttpRequestMessage message, HttpMethod httpMethod, HttpResponseMessage response, RefitSettings refitSettings = null)
		{
			ApiException exception = new ApiException(message, httpMethod, response.StatusCode, response.ReasonPhrase, response.Headers, refitSettings);
			if (response.Content == null)
			{
				return exception;
			}
			try
			{
				exception.ContentHeaders = response.Content.Headers;
				ApiException ex = exception;
				ex.Content = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
				if (response.Content.Headers?.ContentType?.MediaType?.Equals("application/problem+json") == true)
				{
					exception = await ValidationApiException.Create(exception).ConfigureAwait(continueOnCapturedContext: false);
				}
				response.Content.Dispose();
			}
			catch
			{
			}
			return exception;
		}

		private static string CreateMessage(HttpStatusCode statusCode, string reasonPhrase)
		{
			return $"Response status code does not indicate success: {(int)statusCode} ({reasonPhrase}).";
		}
	}
	internal static class ApiResponse
	{
		internal static T Create<T, TBody>(HttpResponseMessage resp, object content, ApiException error = null)
		{
			return (T)Activator.CreateInstance(typeof(ApiResponse<TBody>), resp, content, error);
		}
	}
	public sealed class ApiResponse<T> : IApiResponse<T>, IApiResponse, IDisposable
	{
		private readonly HttpResponseMessage response;

		private bool disposed;

		public T Content { get; }

		public HttpResponseHeaders Headers => response.Headers;

		public HttpContentHeaders ContentHeaders => response.Content?.Headers;

		public bool IsSuccessStatusCode => response.IsSuccessStatusCode;

		public string ReasonPhrase => response.ReasonPhrase;

		public HttpRequestMessage RequestMessage => response.RequestMessage;

		public HttpStatusCode StatusCode => response.StatusCode;

		public Version Version => response.Version;

		public ApiException Error { get; private set; }

		public ApiResponse(HttpResponseMessage response, T content, ApiException error = null)
		{
			this.response = response ?? throw new ArgumentNullException("response");
			Error = error;
			Content = content;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		public async Task<ApiResponse<T>> EnsureSuccessStatusCodeAsync()
		{
			if (!IsSuccessStatusCode)
			{
				ApiException obj = await ApiException.Create(response.RequestMessage, response.RequestMessage.Method, response).ConfigureAwait(continueOnCapturedContext: false);
				Dispose();
				throw obj;
			}
			return this;
		}

		private void Dispose(bool disposing)
		{
			if (disposing && !disposed)
			{
				disposed = true;
				response.Dispose();
			}
		}
	}
	public interface IApiResponse<out T> : IApiResponse, IDisposable
	{
		T Content { get; }
	}
	public interface IApiResponse : IDisposable
	{
		HttpResponseHeaders Headers { get; }

		HttpContentHeaders ContentHeaders { get; }

		bool IsSuccessStatusCode { get; }

		string ReasonPhrase { get; }

		HttpRequestMessage RequestMessage { get; }

		HttpStatusCode StatusCode { get; }

		Version Version { get; }

		ApiException Error { get; }
	}
	public abstract class HttpMethodAttribute : Attribute
	{
		public abstract HttpMethod Method { get; }

		public virtual string Path { get; protected set; }

		public HttpMethodAttribute(string path)
		{
			Path = path;
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class GetAttribute : HttpMethodAttribute
	{
		public override HttpMethod Method => HttpMethod.Get;

		public GetAttribute(string path)
			: base(path)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class PostAttribute : HttpMethodAttribute
	{
		public override HttpMethod Method => HttpMethod.Post;

		public PostAttribute(string path)
			: base(path)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class PutAttribute : HttpMethodAttribute
	{
		public override HttpMethod Method => HttpMethod.Put;

		public PutAttribute(string path)
			: base(path)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class DeleteAttribute : HttpMethodAttribute
	{
		public override HttpMethod Method => HttpMethod.Delete;

		public DeleteAttribute(string path)
			: base(path)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class PatchAttribute : HttpMethodAttribute
	{
		public override HttpMethod Method => new HttpMethod("PATCH");

		public PatchAttribute(string path)
			: base(path)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class OptionsAttribute : HttpMethodAttribute
	{
		public override HttpMethod Method => new HttpMethod("OPTIONS");

		public OptionsAttribute(string path)
			: base(path)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class HeadAttribute : HttpMethodAttribute
	{
		public override HttpMethod Method => HttpMethod.Head;

		public HeadAttribute(string path)
			: base(path)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class MultipartAttribute : Attribute
	{
		public string BoundaryText { get; private set; }

		public MultipartAttribute(string boundaryText = "----MyGreatBoundary")
		{
			BoundaryText = boundaryText;
		}
	}
	public enum BodySerializationMethod
	{
		Default,
		[Obsolete("Use BodySerializationMethod.Serialized instead", false)]
		Json,
		UrlEncoded,
		Serialized
	}
	[AttributeUsage(AttributeTargets.Parameter)]
	public class BodyAttribute : Attribute
	{
		public bool? Buffered { get; set; }

		public BodySerializationMethod SerializationMethod { get; protected set; }

		public BodyAttribute()
		{
		}

		public BodyAttribute(bool buffered)
		{
			Buffered = buffered;
		}

		public BodyAttribute(BodySerializationMethod serializationMethod, bool buffered)
		{
			SerializationMethod = serializationMethod;
			Buffered = buffered;
		}

		public BodyAttribute(BodySerializationMethod serializationMethod = BodySerializationMethod.Default)
		{
			SerializationMethod = serializationMethod;
		}
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	public class AliasAsAttribute : Attribute
	{
		public string Name { get; protected set; }

		public AliasAsAttribute(string name)
		{
			Name = name;
		}
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	[Obsolete("Use Refit.StreamPart, Refit.ByteArrayPart, Refit.FileInfoPart or if necessary, inherit from Refit.MultipartItem", false)]
	public class AttachmentNameAttribute : Attribute
	{
		public string Name { get; protected set; }

		public AttachmentNameAttribute(string name)
		{
			Name = name;
		}
	}
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Interface)]
	public class HeadersAttribute : Attribute
	{
		public string[] Headers { get; }

		public HeadersAttribute(params string[] headers)
		{
			Headers = headers ?? new string[0];
		}
	}
	[AttributeUsage(AttributeTargets.Parameter)]
	public class HeaderAttribute : Attribute
	{
		public string Header { get; }

		public HeaderAttribute(string header)
		{
			Header = header;
		}
	}
	[AttributeUsage(AttributeTargets.Parameter)]
	public class AuthorizeAttribute : HeaderAttribute
	{
		public AuthorizeAttribute(string scheme = "Bearer")
			: base("Authorization: " + scheme)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	public class QueryAttribute : Attribute
	{
		private CollectionFormat? collectionFormat;

		public string Delimiter { get; protected set; } = ".";

		public string Prefix { get; protected set; }

		public string Format { get; set; }

		public CollectionFormat CollectionFormat
		{
			get
			{
				return collectionFormat.GetValueOrDefault();
			}
			set
			{
				collectionFormat = value;
			}
		}

		public bool IsCollectionFormatSpecified => collectionFormat.HasValue;

		public QueryAttribute()
		{
		}

		public QueryAttribute(string delimiter)
		{
			Delimiter = delimiter;
		}

		public QueryAttribute(string delimiter, string prefix)
		{
			Delimiter = delimiter;
			Prefix = prefix;
		}

		public QueryAttribute(string delimiter, string prefix, string format)
		{
			Delimiter = delimiter;
			Prefix = prefix;
			Format = format;
		}

		public QueryAttribute(CollectionFormat collectionFormat)
		{
			CollectionFormat = collectionFormat;
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class QueryUriFormatAttribute : Attribute
	{
		public UriFormat UriFormat { get; }

		public QueryUriFormatAttribute(UriFormat uriFormat)
		{
			UriFormat = uriFormat;
		}
	}
	internal class AuthenticatedHttpClientHandler : DelegatingHandler
	{
		private readonly Func<Task<string>> getToken;

		public AuthenticatedHttpClientHandler(Func<Task<string>> getToken, HttpMessageHandler innerHandler = null)
			: base(innerHandler ?? new HttpClientHandler())
		{
			this.getToken = getToken ?? throw new ArgumentNullException("getToken");
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			AuthenticationHeaderValue auth = request.Headers.Authorization;
			if (auth != null)
			{
				string parameter = await getToken().ConfigureAwait(continueOnCapturedContext: false);
				request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, parameter);
			}
			return await base.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
	public class AuthenticatedParameterizedHttpClientHandler : DelegatingHandler
	{
		private readonly Func<HttpRequestMessage, Task<string>> getToken;

		public AuthenticatedParameterizedHttpClientHandler(Func<HttpRequestMessage, Task<string>> getToken, HttpMessageHandler innerHandler = null)
			: base(innerHandler ?? new HttpClientHandler())
		{
			this.getToken = getToken ?? throw new ArgumentNullException("getToken");
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			AuthenticationHeaderValue auth = request.Headers.Authorization;
			if (auth != null)
			{
				string parameter = await getToken(request).ConfigureAwait(continueOnCapturedContext: false);
				request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, parameter);
			}
			return await base.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
	internal class CachedRequestBuilderImplementation<T> : CachedRequestBuilderImplementation, IRequestBuilder<T>, IRequestBuilder
	{
		public CachedRequestBuilderImplementation(IRequestBuilder<T> innerBuilder)
			: base(innerBuilder)
		{
		}
	}
	internal class CachedRequestBuilderImplementation : IRequestBuilder
	{
		private readonly IRequestBuilder innerBuilder;

		private readonly ConcurrentDictionary<string, Func<HttpClient, object[], object>> methodDictionary = new ConcurrentDictionary<string, Func<HttpClient, object[], object>>();

		public CachedRequestBuilderImplementation(IRequestBuilder innerBuilder)
		{
			this.innerBuilder = innerBuilder;
		}

		public Func<HttpClient, object[], object> BuildRestResultFuncForMethod(string methodName, Type[] parameterTypes = null, Type[] genericArgumentTypes = null)
		{
			string cacheKey = GetCacheKey(methodName, parameterTypes, genericArgumentTypes);
			return methodDictionary.GetOrAdd(cacheKey, (string _) => innerBuilder.BuildRestResultFuncForMethod(methodName, parameterTypes, genericArgumentTypes));
		}

		private string GetCacheKey(string methodName, Type[] parameterTypes, Type[] genericArgumentTypes)
		{
			string genericString = GetGenericString(genericArgumentTypes);
			string argumentString = GetArgumentString(parameterTypes);
			return methodName + genericString + "(" + argumentString + ")";
		}

		private string GetArgumentString(Type[] parameterTypes)
		{
			if (parameterTypes == null || parameterTypes.Length == 0)
			{
				return "";
			}
			return string.Join(", ", parameterTypes.Select((Type t) => t.FullName));
		}

		private string GetGenericString(Type[] genericArgumentTypes)
		{
			if (genericArgumentTypes == null || genericArgumentTypes.Length == 0)
			{
				return "";
			}
			return "<" + string.Join(", ", genericArgumentTypes.Select((Type t) => t.FullName)) + ">";
		}
	}
	internal struct CloseGenericMethodKey(MethodInfo openMethodInfo, Type[] types) : IEquatable<CloseGenericMethodKey>
	{
		public MethodInfo OpenMethodInfo { get; } = openMethodInfo;

		public Type[] Types { get; } = types;

		public bool Equals(CloseGenericMethodKey other)
		{
			if (OpenMethodInfo == other.OpenMethodInfo)
			{
				return Enumerable.SequenceEqual(Types, other.Types);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is CloseGenericMethodKey other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 17;
			num = num * 23 + OpenMethodInfo.GetHashCode();
			Type[] types = Types;
			foreach (Type type in types)
			{
				num = num * 23 + type.GetHashCode();
			}
			return num;
		}
	}
	public enum CollectionFormat
	{
		RefitParameterFormatter,
		Csv,
		Ssv,
		Tsv,
		Pipes,
		Multi
	}
	internal class FormValueMultimap : IEnumerable<KeyValuePair<string, string>>, IEnumerable
	{
		private static readonly Dictionary<Type, PropertyInfo[]> PropertyCache = new Dictionary<Type, PropertyInfo[]>();

		private readonly IList<KeyValuePair<string, string>> formEntries = new List<KeyValuePair<string, string>>();

		public IEnumerable<string> Keys => this.Select((KeyValuePair<string, string> it) => it.Key);

		public FormValueMultimap(object source, RefitSettings settings)
		{
			if (source == null)
			{
				return;
			}
			if (source is IDictionary dictionary)
			{
				{
					foreach (object key in dictionary.Keys)
					{
						object obj = dictionary[key];
						if (obj != null)
						{
							Add(key.ToString(), settings.FormUrlEncodedParameterFormatter.Format(obj, null));
						}
					}
					return;
				}
			}
			Type type = source.GetType();
			lock (PropertyCache)
			{
				if (!PropertyCache.ContainsKey(type))
				{
					PropertyCache[type] = GetProperties(type);
				}
				PropertyInfo[] array = PropertyCache[type];
				foreach (PropertyInfo propertyInfo in array)
				{
					object value = propertyInfo.GetValue(source, null);
					if (value == null)
					{
						continue;
					}
					string fieldNameForProperty = GetFieldNameForProperty(propertyInfo);
					QueryAttribute attrib = propertyInfo.GetCustomAttribute<QueryAttribute>(inherit: true);
					if (value is IEnumerable enumerable)
					{
						string text;
						string separator;
						IEnumerable<string> values;
						switch ((attrib != null && attrib.IsCollectionFormatSpecified) ? attrib.CollectionFormat : settings.CollectionFormat)
						{
						case CollectionFormat.Multi:
							foreach (object item in enumerable)
							{
								Add(fieldNameForProperty, settings.FormUrlEncodedParameterFormatter.Format(item, attrib.Format));
							}
							break;
						case CollectionFormat.Csv:
							text = ",";
							goto IL_020d;
						case CollectionFormat.Ssv:
							text = " ";
							goto IL_020d;
						case CollectionFormat.Tsv:
							text = "\t";
							goto IL_020d;
						case CollectionFormat.Pipes:
							text = "|";
							goto IL_020d;
						default:
							{
								Add(fieldNameForProperty, settings.FormUrlEncodedParameterFormatter.Format(value, attrib?.Format));
								break;
							}
							IL_020d:
							separator = text;
							values = from object v in enumerable
								select settings.FormUrlEncodedParameterFormatter.Format(v, attrib.Format);
							Add(fieldNameForProperty, string.Join(separator, values));
							break;
						}
					}
					else
					{
						Add(fieldNameForProperty, settings.FormUrlEncodedParameterFormatter.Format(value, attrib?.Format));
					}
				}
			}
		}

		private void Add(string key, string value)
		{
			formEntries.Add(new KeyValuePair<string, string>(key, value));
		}

		private string GetFieldNameForProperty(PropertyInfo propertyInfo)
		{
			string name = (from a in propertyInfo.GetCustomAttributes<AliasAsAttribute>(inherit: true)
				select a.Name).FirstOrDefault() ?? (from a in propertyInfo.GetCustomAttributes<JsonPropertyAttribute>(inherit: true)
				select a.PropertyName).FirstOrDefault() ?? (from a in propertyInfo.GetCustomAttributes<JsonPropertyNameAttribute>(inherit: true)
				select a.Name).FirstOrDefault() ?? propertyInfo.Name;
			return (from attr in propertyInfo.GetCustomAttributes<QueryAttribute>(inherit: true)
				select string.IsNullOrWhiteSpace(attr.Prefix) ? name : (attr.Prefix + attr.Delimiter + name)).FirstOrDefault() ?? name;
		}

		private PropertyInfo[] GetProperties(Type type)
		{
			return (from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				where p.CanRead && p.GetMethod.IsPublic
				select p).ToArray();
		}

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			return formEntries.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	[Obsolete("Use NewtonsoftJsonContentSerializer instead", false)]
	public class JsonContentSerializer : IContentSerializer
	{
		private readonly Lazy<JsonSerializerSettings> jsonSerializerSettings;

		public JsonContentSerializer()
			: this(null)
		{
		}

		public JsonContentSerializer(JsonSerializerSettings jsonSerializerSettings)
		{
			this.jsonSerializerSettings = new Lazy<JsonSerializerSettings>(() => (jsonSerializerSettings == null) ? ((JsonConvert.DefaultSettings == null) ? new JsonSerializerSettings() : JsonConvert.DefaultSettings()) : jsonSerializerSettings);
		}

		public Task<HttpContent> SerializeAsync<T>(T item)
		{
			return Task.FromResult((HttpContent)new StringContent(JsonConvert.SerializeObject(item, jsonSerializerSettings.Value), Encoding.UTF8, "application/json"));
		}

		public async Task<T> DeserializeAsync<T>(HttpContent content)
		{
			Newtonsoft.Json.JsonSerializer serializer = Newtonsoft.Json.JsonSerializer.Create(jsonSerializerSettings.Value);
			using Stream stream = await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
			using StreamReader reader = new StreamReader(stream);
			using JsonTextReader reader2 = new JsonTextReader(reader);
			return serializer.Deserialize<T>(reader2);
		}
	}
	public abstract class MultipartItem
	{
		public string ContentType { get; }

		public string FileName { get; }

		public MultipartItem(string fileName, string contentType)
		{
			FileName = fileName ?? throw new ArgumentNullException("fileName");
			ContentType = contentType;
		}

		public HttpContent ToContent()
		{
			HttpContent httpContent = CreateContent();
			if (!string.IsNullOrEmpty(ContentType))
			{
				httpContent.Headers.ContentType = new MediaTypeHeaderValue(ContentType);
			}
			return httpContent;
		}

		protected abstract HttpContent CreateContent();
	}
	public class StreamPart : MultipartItem
	{
		public Stream Value { get; }

		public StreamPart(Stream value, string fileName, string contentType = null)
			: base(fileName, contentType)
		{
			Value = value ?? throw new ArgumentNullException("value");
		}

		protected override HttpContent CreateContent()
		{
			return new StreamContent(Value);
		}
	}
	public class ByteArrayPart : MultipartItem
	{
		public byte[] Value { get; }

		public ByteArrayPart(byte[] value, string fileName, string contentType = null)
			: base(fileName, contentType)
		{
			Value = value ?? throw new ArgumentNullException("value");
		}

		protected override HttpContent CreateContent()
		{
			return new ByteArrayContent(Value);
		}
	}
	public class FileInfoPart : MultipartItem
	{
		public FileInfo Value { get; }

		public FileInfoPart(FileInfo value, string fileName, string contentType = null)
			: base(fileName, contentType)
		{
			Value = value ?? throw new ArgumentNullException("value");
		}

		protected override HttpContent CreateContent()
		{
			return new StreamContent(Value.OpenRead());
		}
	}
	public sealed class NewtonsoftJsonContentSerializer : IContentSerializer
	{
		private readonly Lazy<JsonSerializerSettings> jsonSerializerSettings;

		public NewtonsoftJsonContentSerializer()
			: this(null)
		{
		}

		public NewtonsoftJsonContentSerializer(JsonSerializerSettings jsonSerializerSettings)
		{
			this.jsonSerializerSettings = new Lazy<JsonSerializerSettings>(() => jsonSerializerSettings ?? JsonConvert.DefaultSettings?.Invoke() ?? new JsonSerializerSettings());
		}

		public Task<HttpContent> SerializeAsync<T>(T item)
		{
			return Task.FromResult((HttpContent)new StringContent(JsonConvert.SerializeObject(item, jsonSerializerSettings.Value), Encoding.UTF8, "application/json"));
		}

		public async Task<T> DeserializeAsync<T>(HttpContent content)
		{
			Newtonsoft.Json.JsonSerializer serializer = Newtonsoft.Json.JsonSerializer.Create(jsonSerializerSettings.Value);
			using Stream stream = await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
			using StreamReader reader = new StreamReader(stream);
			using JsonTextReader reader2 = new JsonTextReader(reader);
			return serializer.Deserialize<T>(reader2);
		}
	}
	public class ProblemDetails
	{
		public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();

		[Newtonsoft.Json.JsonExtensionData]
		public IDictionary<string, object> Extensions { get; } = new Dictionary<string, object>(StringComparer.Ordinal);

		public string Type { get; set; } = "about:blank";

		public string Title { get; set; }

		public int Status { get; set; }

		public string Detail { get; set; }

		public string Instance { get; set; }
	}
	public class RefitSettings
	{
		private JsonSerializerSettings jsonSerializerSettings;

		public Func<Task<string>> AuthorizationHeaderValueGetter { get; set; }

		public Func<HttpRequestMessage, Task<string>> AuthorizationHeaderValueWithParamGetter { get; set; }

		public Func<HttpMessageHandler> HttpMessageHandlerFactory { get; set; }

		[Obsolete("Set RefitSettings.ContentSerializer = new NewtonsoftJsonContentSerializer(JsonSerializerSettings) instead.", false)]
		public JsonSerializerSettings JsonSerializerSettings
		{
			get
			{
				return jsonSerializerSettings;
			}
			set
			{
				jsonSerializerSettings = value;
				ContentSerializer = new JsonContentSerializer(value);
			}
		}

		public IContentSerializer ContentSerializer { get; set; }

		public IUrlParameterFormatter UrlParameterFormatter { get; set; }

		public IFormUrlEncodedParameterFormatter FormUrlEncodedParameterFormatter { get; set; }

		public CollectionFormat CollectionFormat { get; set; }

		public bool Buffered { get; set; } = true;

		public RefitSettings()
		{
			ContentSerializer = new NewtonsoftJsonContentSerializer();
			UrlParameterFormatter = new DefaultUrlParameterFormatter();
			FormUrlEncodedParameterFormatter = new DefaultFormUrlEncodedParameterFormatter();
		}

		public RefitSettings(IContentSerializer contentSerializer, IUrlParameterFormatter urlParameterFormatter = null, IFormUrlEncodedParameterFormatter formUrlEncodedParameterFormatter = null)
		{
			ContentSerializer = contentSerializer ?? throw new ArgumentNullException("contentSerializer", "The content serializer can't be null");
			UrlParameterFormatter = urlParameterFormatter ?? new DefaultUrlParameterFormatter();
			FormUrlEncodedParameterFormatter = formUrlEncodedParameterFormatter ?? new DefaultFormUrlEncodedParameterFormatter();
		}
	}
	public interface IContentSerializer
	{
		Task<HttpContent> SerializeAsync<T>(T item);

		Task<T> DeserializeAsync<T>(HttpContent content);
	}
	public interface IUrlParameterFormatter
	{
		string Format(object value, ICustomAttributeProvider attributeProvider, Type type);
	}
	public interface IFormUrlEncodedParameterFormatter
	{
		string Format(object value, string formatString);
	}
	public class DefaultUrlParameterFormatter : IUrlParameterFormatter
	{
		private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>> EnumMemberCache = new ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>>();

		public virtual string Format(object parameterValue, ICustomAttributeProvider attributeProvider, Type type)
		{
			string text = attributeProvider.GetCustomAttributes(typeof(QueryAttribute), inherit: true).OfType<QueryAttribute>().FirstOrDefault()?.Format;
			EnumMemberAttribute enumMemberAttribute = null;
			if (parameterValue != null && type.GetTypeInfo().IsEnum)
			{
				enumMemberAttribute = EnumMemberCache.GetOrAdd(type, (Type t) => new ConcurrentDictionary<string, EnumMemberAttribute>()).GetOrAdd(parameterValue.ToString(), (string val) => type.GetMember(val).First().GetCustomAttribute<EnumMemberAttribute>());
			}
			if (parameterValue != null)
			{
				return string.Format(CultureInfo.InvariantCulture, string.IsNullOrWhiteSpace(text) ? "{0}" : ("{0:" + text + "}"), enumMemberAttribute?.Value ?? parameterValue);
			}
			return null;
		}
	}
	public class DefaultFormUrlEncodedParameterFormatter : IFormUrlEncodedParameterFormatter
	{
		private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>> EnumMemberCache = new ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>>();

		public virtual string Format(object parameterValue, string formatString)
		{
			if (parameterValue == null)
			{
				return null;
			}
			Type parameterType = parameterValue.GetType();
			EnumMemberAttribute enumMemberAttribute = null;
			if (parameterType.GetTypeInfo().IsEnum)
			{
				enumMemberAttribute = EnumMemberCache.GetOrAdd(parameterType, (Type t) => new ConcurrentDictionary<string, EnumMemberAttribute>()).GetOrAdd(parameterValue.ToString(), (string val) => parameterType.GetMember(val).First().GetCustomAttribute<EnumMemberAttribute>());
			}
			return string.Format(CultureInfo.InvariantCulture, string.IsNullOrWhiteSpace(formatString) ? "{0}" : ("{0:" + formatString + "}"), enumMemberAttribute?.Value ?? parameterValue);
		}
	}
	public interface IRequestBuilder
	{
		Func<HttpClient, object[], object> BuildRestResultFuncForMethod(string methodName, Type[] parameterTypes = null, Type[] genericArgumentTypes = null);
	}
	public interface IRequestBuilder<T> : IRequestBuilder
	{
	}
	public static class RequestBuilder
	{
		private static readonly IRequestBuilderFactory PlatformRequestBuilderFactory = new RequestBuilderFactory();

		public static IRequestBuilder<T> ForType<T>(RefitSettings settings)
		{
			return PlatformRequestBuilderFactory.Create<T>(settings);
		}

		public static IRequestBuilder<T> ForType<T>()
		{
			return PlatformRequestBuilderFactory.Create<T>(null);
		}

		public static IRequestBuilder ForType(Type refitInterfaceType, RefitSettings settings)
		{
			return PlatformRequestBuilderFactory.Create(refitInterfaceType, settings);
		}

		public static IRequestBuilder ForType(Type refitInterfaceType)
		{
			return PlatformRequestBuilderFactory.Create(refitInterfaceType, null);
		}
	}
	internal interface IRequestBuilderFactory
	{
		IRequestBuilder<T> Create<T>(RefitSettings settings);

		IRequestBuilder Create(Type refitInterfaceType, RefitSettings settings);
	}
	internal class RequestBuilderFactory : IRequestBuilderFactory
	{
		public IRequestBuilder<T> Create<T>(RefitSettings settings = null)
		{
			return new CachedRequestBuilderImplementation<T>(new RequestBuilderImplementation<T>(settings));
		}

		public IRequestBuilder Create(Type refitInterfaceType, RefitSettings settings = null)
		{
			return new CachedRequestBuilderImplementation(new RequestBuilderImplementation(refitInterfaceType, settings));
		}
	}
	internal class RequestBuilderImplementation<TApi> : RequestBuilderImplementation, IRequestBuilder<TApi>, IRequestBuilder
	{
		public RequestBuilderImplementation(RefitSettings refitSettings = null)
			: base(typeof(TApi), refitSettings)
		{
		}
	}
	internal class RequestBuilderImplementation : IRequestBuilder
	{
		private sealed class TaskToObservable<T> : IObservable<T>
		{
			private readonly Func<CancellationToken, Task<T>> taskFactory;

			public TaskToObservable(Func<CancellationToken, Task<T>> taskFactory)
			{
				this.taskFactory = taskFactory;
			}

			public IDisposable Subscribe(IObserver<T> observer)
			{
				CancellationTokenSource cts = new CancellationTokenSource();
				taskFactory(cts.Token).ContinueWith(delegate(Task<T> t)
				{
					if (!cts.IsCancellationRequested)
					{
						ToObservableDone(t, observer);
					}
				}, TaskScheduler.Default);
				return new AnonymousDisposable(cts.Cancel);
			}

			private static void ToObservableDone<TResult>(Task<TResult> task, IObserver<TResult> subject)
			{
				switch (task.Status)
				{
				case TaskStatus.RanToCompletion:
					subject.OnNext(task.Result);
					subject.OnCompleted();
					break;
				case TaskStatus.Faulted:
					subject.OnError(task.Exception.InnerException);
					break;
				case TaskStatus.Canceled:
					subject.OnError(new TaskCanceledException(task));
					break;
				}
			}
		}

		private static readonly ISet<HttpMethod> BodylessMethods = new HashSet<HttpMethod>
		{
			HttpMethod.Get,
			HttpMethod.Head
		};

		private readonly Dictionary<string, List<RestMethodInfo>> interfaceHttpMethods;

		private readonly ConcurrentDictionary<CloseGenericMethodKey, RestMethodInfo> interfaceGenericHttpMethods;

		private readonly IContentSerializer serializer;

		private readonly RefitSettings settings;

		public Type TargetType { get; }

		public RequestBuilderImplementation(Type refitInterfaceType, RefitSettings refitSettings = null)
		{
			Type[] interfaces = refitInterfaceType.GetInterfaces();
			settings = refitSettings ?? new RefitSettings();
			serializer = settings.ContentSerializer;
			interfaceGenericHttpMethods = new ConcurrentDictionary<CloseGenericMethodKey, RestMethodInfo>();
			if (refitInterfaceType == null || !refitInterfaceType.GetTypeInfo().IsInterface)
			{
				throw new ArgumentException("targetInterface must be an Interface");
			}
			TargetType = refitInterfaceType;
			Dictionary<string, List<RestMethodInfo>> methods = new Dictionary<string, List<RestMethodInfo>>();
			AddInterfaceHttpMethods(refitInterfaceType, methods);
			Type[] array = interfaces;
			foreach (Type interfaceType in array)
			{
				AddInterfaceHttpMethods(interfaceType, methods);
			}
			interfaceHttpMethods = methods;
		}

		private void AddInterfaceHttpMethods(Type interfaceType, Dictionary<string, List<RestMethodInfo>> methods)
		{
			MethodInfo[] methods2 = interfaceType.GetMethods();
			foreach (MethodInfo methodInfo in methods2)
			{
				if (methodInfo.GetCustomAttributes(inherit: true).OfType<HttpMethodAttribute>().Any())
				{
					if (!methods.ContainsKey(methodInfo.Name))
					{
						methods.Add(methodInfo.Name, new List<RestMethodInfo>());
					}
					RestMethodInfo item = new RestMethodInfo(interfaceType, methodInfo, settings);
					methods[methodInfo.Name].Add(item);
				}
			}
		}

		private RestMethodInfo FindMatchingRestMethodInfo(string key, Type[] parameterTypes, Type[] genericArgumentTypes)
		{
			if (interfaceHttpMethods.TryGetValue(key, out var value))
			{
				if (parameterTypes == null)
				{
					if (value.Count > 1)
					{
						throw new ArgumentException("MethodName exists more than once, 'parameterTypes' mut be defined");
					}
					return CloseGenericMethodIfNeeded(value[0], genericArgumentTypes);
				}
				Type[] array = genericArgumentTypes;
				bool num = array != null && array.Length != 0;
				IEnumerable<RestMethodInfo> source = value.Where((RestMethodInfo method) => method.MethodInfo.GetParameters().Length == parameterTypes.Count());
				source = ((!num) ? source.Where((RestMethodInfo method) => !method.MethodInfo.IsGenericMethod) : source.Where((RestMethodInfo method) => method.MethodInfo.IsGenericMethod && method.MethodInfo.GetGenericArguments().Length == genericArgumentTypes.Length));
				List<RestMethodInfo> list = source.ToList();
				if (list.Count == 1)
				{
					return CloseGenericMethodIfNeeded(list[0], genericArgumentTypes);
				}
				Type[] second = parameterTypes.ToArray();
				foreach (RestMethodInfo item in list)
				{
					if ((from p in item.MethodInfo.GetParameters()
						select p.ParameterType).SequenceEqual(second))
					{
						return CloseGenericMethodIfNeeded(item, genericArgumentTypes);
					}
				}
				throw new Exception("No suitable Method found...");
			}
			throw new ArgumentException("Method must be defined and have an HTTP Method attribute");
		}

		private RestMethodInfo CloseGenericMethodIfNeeded(RestMethodInfo restMethodInfo, Type[] genericArgumentTypes)
		{
			if (genericArgumentTypes != null)
			{
				return interfaceGenericHttpMethods.GetOrAdd(new CloseGenericMethodKey(restMethodInfo.MethodInfo, genericArgumentTypes), (CloseGenericMethodKey _) => new RestMethodInfo(restMethodInfo.Type, restMethodInfo.MethodInfo.MakeGenericMethod(genericArgumentTypes), restMethodInfo.RefitSettings));
			}
			return restMethodInfo;
		}

		public Func<HttpClient, object[], object> BuildRestResultFuncForMethod(string methodName, Type[] parameterTypes = null, Type[] genericArgumentTypes = null)
		{
			if (!interfaceHttpMethods.ContainsKey(methodName))
			{
				throw new ArgumentException("Method must be defined and have an HTTP Method attribute");
			}
			RestMethodInfo restMethodInfo = FindMatchingRestMethodInfo(methodName, parameterTypes, genericArgumentTypes);
			if (restMethodInfo.ReturnType == typeof(Task))
			{
				return BuildVoidTaskFuncForMethod(restMethodInfo);
			}
			object[] parameters;
			if (restMethodInfo.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
			{
				MethodInfo method = typeof(RequestBuilderImplementation).GetMethod("BuildTaskFuncForMethod", BindingFlags.Instance | BindingFlags.NonPublic);
				MethodInfo methodInfo = method.MakeGenericMethod(restMethodInfo.ReturnResultType, restMethodInfo.DeserializedResultType);
				parameters = new RestMethodInfo[1] { restMethodInfo };
				MulticastDelegate taskFunc = (MulticastDelegate)methodInfo.Invoke(this, parameters);
				return (HttpClient client, object[] args) => taskFunc.DynamicInvoke(client, args);
			}
			MethodInfo method2 = typeof(RequestBuilderImplementation).GetMethod("BuildRxFuncForMethod", BindingFlags.Instance | BindingFlags.NonPublic);
			MethodInfo methodInfo2 = method2.MakeGenericMethod(restMethodInfo.ReturnResultType, restMethodInfo.DeserializedResultType);
			parameters = new RestMethodInfo[1] { restMethodInfo };
			MulticastDelegate rxFunc = (MulticastDelegate)methodInfo2.Invoke(this, parameters);
			return (HttpClient client, object[] args) => rxFunc.DynamicInvoke(client, args);
		}

		private async Task AddMultipartItemAsync(MultipartFormDataContent multiPartContent, string fileName, string parameterName, object itemValue)
		{
			if (itemValue is HttpContent content)
			{
				multiPartContent.Add(content);
				return;
			}
			if (itemValue is MultipartItem multipartItem)
			{
				HttpContent content2 = multipartItem.ToContent();
				multiPartContent.Add(content2, parameterName, string.IsNullOrEmpty(multipartItem.FileName) ? fileName : multipartItem.FileName);
				return;
			}
			if (itemValue is Stream content3)
			{
				StreamContent content4 = new StreamContent(content3);
				multiPartContent.Add(content4, parameterName, fileName);
				return;
			}
			if (itemValue is string content5)
			{
				multiPartContent.Add(new StringContent(content5), parameterName);
				return;
			}
			if (itemValue is FileInfo fileInfo)
			{
				StreamContent content6 = new StreamContent(fileInfo.OpenRead());
				multiPartContent.Add(content6, parameterName, fileInfo.Name);
				return;
			}
			if (itemValue is byte[] content7)
			{
				ByteArrayContent content8 = new ByteArrayContent(content7);
				multiPartContent.Add(content8, parameterName, fileName);
				return;
			}
			Exception innerException;
			try
			{
				multiPartContent.Add(await settings.ContentSerializer.SerializeAsync(itemValue).ConfigureAwait(continueOnCapturedContext: false), parameterName);
				return;
			}
			catch (Exception ex)
			{
				innerException = ex;
			}
			throw new ArgumentException("Unexpected parameter type in a Multipart request. Parameter " + fileName + " is of type " + itemValue.GetType().Name + ", whereas allowed types are String, Stream, FileInfo, Byte array and anything that's JSON serializable", "itemValue", innerException);
		}

		private Func<HttpClient, CancellationToken, object[], Task<T>> BuildCancellableTaskFuncForMethod<T, TBody>(RestMethodInfo restMethod)
		{
			return async delegate(HttpClient client, CancellationToken ct, object[] paramList)
			{
				if (client.BaseAddress == null)
				{
					throw new InvalidOperationException("BaseAddress must be set on the HttpClient instance");
				}
				HttpRequestMessage rq = await BuildRequestFactoryForMethod(restMethod, client.BaseAddress.AbsolutePath, restMethod.CancellationToken != null)(paramList).ConfigureAwait(continueOnCapturedContext: false);
				HttpResponseMessage resp = null;
				HttpContent content = null;
				bool disposeResponse = true;
				try
				{
					resp = await client.SendAsync(rq, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(continueOnCapturedContext: false);
					content = resp.Content ?? new StringContent(string.Empty);
					ApiException e = null;
					disposeResponse = restMethod.ShouldDisposeResponse;
					if (!resp.IsSuccessStatusCode && typeof(T) != typeof(HttpResponseMessage))
					{
						disposeResponse = false;
						e = await ApiException.Create(rq, restMethod.HttpMethod, resp, restMethod.RefitSettings).ConfigureAwait(continueOnCapturedContext: false);
					}
					if (restMethod.IsApiResponse)
					{
						return ApiResponse.Create<T, TBody>(resp, await DeserializeContentAsync<TBody>(resp, content), e);
					}
					if (e != null)
					{
						throw e;
					}
					return await DeserializeContentAsync<T>(resp, content);
				}
				finally
				{
					rq.Dispose();
					if (disposeResponse)
					{
						resp?.Dispose();
						content?.Dispose();
					}
				}
			};
		}

		private async Task<T> DeserializeContentAsync<T>(HttpResponseMessage resp, HttpContent content)
		{
			T result;
			if (typeof(T) == typeof(HttpResponseMessage))
			{
				result = (T)(object)resp;
			}
			else if (!resp.IsSuccessStatusCode)
			{
				result = default(T);
			}
			else if (typeof(T) == typeof(HttpContent))
			{
				result = (T)(object)content;
			}
			else if (typeof(T) == typeof(Stream))
			{
				result = (T)(object)(await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false));
			}
			else if (typeof(T) == typeof(string))
			{
				using Stream stream = await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
				using StreamReader reader = new StreamReader(stream);
				result = (T)(object)(await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false));
			}
			else
			{
				result = await serializer.DeserializeAsync<T>(content);
			}
			return result;
		}

		private List<KeyValuePair<string, object>> BuildQueryMap(object @object, string delimiter = null, RestMethodParameterInfo parameterInfo = null)
		{
			if (@object is IDictionary dictionary)
			{
				return BuildQueryMap(dictionary, delimiter);
			}
			List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
			foreach (PropertyInfo propertyInfo in from p in @object.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
				where p.CanRead && p.GetMethod.IsPublic
				select p)
			{
				object obj = propertyInfo.GetValue(@object);
				if (obj == null || (parameterInfo != null && parameterInfo.IsObjectPropertyParameter && parameterInfo.ParameterProperties.Any((RestMethodParameterProperty x) => x.PropertyInfo == propertyInfo)))
				{
					continue;
				}
				string name = propertyInfo.Name;
				AliasAsAttribute customAttribute = propertyInfo.GetCustomAttribute<AliasAsAttribute>();
				if (customAttribute != null)
				{
					name = customAttribute.Name;
				}
				QueryAttribute customAttribute2 = propertyInfo.GetCustomAttribute<QueryAttribute>();
				if (customAttribute2 != null && customAttribute2.Format != null)
				{
					obj = settings.FormUrlEncodedParameterFormatter.Format(obj, customAttribute2.Format);
				}
				if (!(obj is string) && obj is IEnumerable paramValues)
				{
					foreach (string item in ParseEnumerableQueryParameterValue(paramValues, propertyInfo, propertyInfo.PropertyType, customAttribute2))
					{
						list.Add(new KeyValuePair<string, object>(name, item));
					}
					continue;
				}
				if (DoNotConvertToQueryMap(obj))
				{
					list.Add(new KeyValuePair<string, object>(name, obj));
					continue;
				}
				if (obj is IDictionary dictionary2)
				{
					foreach (KeyValuePair<string, object> item2 in BuildQueryMap(dictionary2, delimiter))
					{
						list.Add(new KeyValuePair<string, object>(name + delimiter + item2.Key, item2.Value));
					}
					continue;
				}
				foreach (KeyValuePair<string, object> item3 in BuildQueryMap(obj, delimiter))
				{
					list.Add(new KeyValuePair<string, object>(name + delimiter + item3.Key, item3.Value));
				}
			}
			return list;
		}

		private List<KeyValuePair<string, object>> BuildQueryMap(IDictionary dictionary, string delimiter = null)
		{
			List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
			foreach (string key in dictionary.Keys)
			{
				object obj = dictionary[key];
				if (obj == null)
				{
					continue;
				}
				if (DoNotConvertToQueryMap(obj))
				{
					list.Add(new KeyValuePair<string, object>(key, obj));
					continue;
				}
				foreach (KeyValuePair<string, object> item in BuildQueryMap(obj, delimiter))
				{
					list.Add(new KeyValuePair<string, object>(key + delimiter + item.Key, item.Value));
				}
			}
			return list;
		}

		private Func<object[], Task<HttpRequestMessage>> BuildRequestFactoryForMethod(RestMethodInfo restMethod, string basePath, bool paramsContainsCancellationToken)
		{
			return async delegate(object[] paramList)
			{
				if (paramsContainsCancellationToken)
				{
					paramList = paramList.Where((object o) => o == null || o.GetType() != typeof(CancellationToken)).ToArray();
				}
				HttpRequestMessage ret = new HttpRequestMessage
				{
					Method = restMethod.HttpMethod
				};
				MultipartFormDataContent multiPartContent = null;
				if (restMethod.IsMultipart)
				{
					multiPartContent = (MultipartFormDataContent)(ret.Content = new MultipartFormDataContent(restMethod.MultipartBoundary));
				}
				string urlTarget = ((basePath == "/") ? string.Empty : basePath) + restMethod.RelativePath;
				List<KeyValuePair<string, string>> queryParamsToAdd = new List<KeyValuePair<string, string>>();
				Dictionary<string, string> headersToAdd = new Dictionary<string, string>(restMethod.Headers);
				RestMethodParameterInfo parameterInfo = null;
				int i;
				for (i = 0; i < paramList.Length; i++)
				{
					object obj = paramList[i];
					if (restMethod.ParameterMap.ContainsKey(i))
					{
						parameterInfo = restMethod.ParameterMap[i];
						if (!parameterInfo.IsObjectPropertyParameter)
						{
							string pattern;
							string replacement;
							if (restMethod.ParameterMap[i].Type == ParameterType.RoundTripping)
							{
								pattern = "{\\*\\*" + restMethod.ParameterMap[i].Name + "}";
								string text = obj as string;
								replacement = string.Join("/", from s in text.Split('/')
									select Uri.EscapeDataString(settings.UrlParameterFormatter.Format(s, restMethod.ParameterInfoMap[i], restMethod.ParameterInfoMap[i].ParameterType) ?? string.Empty));
							}
							else
							{
								pattern = "{" + restMethod.ParameterMap[i].Name + "}";
								replacement = Uri.EscapeDataString(settings.UrlParameterFormatter.Format(obj, restMethod.ParameterInfoMap[i], restMethod.ParameterInfoMap[i].ParameterType) ?? string.Empty);
							}
							urlTarget = Regex.Replace(urlTarget, pattern, replacement, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
							continue;
						}
						foreach (RestMethodParameterProperty parameterProperty in parameterInfo.ParameterProperties)
						{
							object value = parameterProperty.PropertyInfo.GetValue(obj);
							urlTarget = Regex.Replace(urlTarget, "{" + parameterProperty.Name + "}", Uri.EscapeDataString(settings.UrlParameterFormatter.Format(value, parameterProperty.PropertyInfo, parameterProperty.PropertyInfo.PropertyType) ?? string.Empty), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
						}
					}
					if (restMethod.BodyParameterInfo != null && restMethod.BodyParameterInfo.Item3 == i)
					{
						if (obj is HttpContent content)
						{
							ret.Content = content;
						}
						else if (obj is Stream content2)
						{
							ret.Content = new StreamContent(content2);
						}
						else if (restMethod.BodyParameterInfo.Item1 == BodySerializationMethod.Default && obj is string content3)
						{
							ret.Content = new StringContent(content3);
						}
						else
						{
							switch (restMethod.BodyParameterInfo.Item1)
							{
							case BodySerializationMethod.UrlEncoded:
								ret.Content = ((obj is string stringToEscape) ? ((ByteArrayContent)new StringContent(Uri.EscapeDataString(stringToEscape), Encoding.UTF8, "application/x-www-form-urlencoded")) : ((ByteArrayContent)new FormUrlEncodedContent(new FormValueMultimap(obj, settings))));
								break;
							case BodySerializationMethod.Default:
							case BodySerializationMethod.Json:
							case BodySerializationMethod.Serialized:
							{
								HttpContent content4 = await serializer.SerializeAsync(obj).ConfigureAwait(continueOnCapturedContext: false);
								if (!restMethod.BodyParameterInfo.Item2)
								{
									ret.Content = new PushStreamContent(async delegate(Stream stream, HttpContent _, TransportContext __)
									{
										using (stream)
										{
											await content4.CopyToAsync(stream).ConfigureAwait(continueOnCapturedContext: false);
										}
									}, content4.Headers.ContentType);
								}
								else
								{
									ret.Content = content4;
								}
								break;
							}
							}
						}
					}
					else if (restMethod.HeaderParameterMap.ContainsKey(i))
					{
						headersToAdd[restMethod.HeaderParameterMap[i]] = obj?.ToString();
					}
					else if (obj != null)
					{
						QueryAttribute customAttribute = restMethod.ParameterInfoMap[i].GetCustomAttribute<QueryAttribute>();
						if (!restMethod.IsMultipart || (restMethod.ParameterMap.ContainsKey(i) && restMethod.ParameterMap[i].IsObjectPropertyParameter) || customAttribute != null)
						{
							QueryAttribute queryAttribute = customAttribute ?? new QueryAttribute();
							if (DoNotConvertToQueryMap(obj))
							{
								queryParamsToAdd.AddRange(ParseQueryParameter(obj, restMethod.ParameterInfoMap[i], restMethod.QueryParameterMap[i], queryAttribute));
							}
							else
							{
								foreach (KeyValuePair<string, object> item in BuildQueryMap(obj, queryAttribute.Delimiter, parameterInfo))
								{
									string queryPath = ((!string.IsNullOrWhiteSpace(queryAttribute.Prefix)) ? (queryAttribute.Prefix + queryAttribute.Delimiter + item.Key) : item.Key);
									queryParamsToAdd.AddRange(ParseQueryParameter(item.Value, restMethod.ParameterInfoMap[i], queryPath, queryAttribute));
								}
							}
						}
						else
						{
							string itemName;
							string parameterName;
							if (!restMethod.AttachmentNameMap.TryGetValue(i, out var value2))
							{
								itemName = restMethod.QueryParameterMap[i];
								parameterName = itemName;
							}
							else
							{
								itemName = value2.Item1;
								parameterName = value2.Item2;
							}
							object obj2 = obj;
							if (!(obj2 is IEnumerable<object> enumerable))
							{
								await AddMultipartItemAsync(multiPartContent, itemName, parameterName, obj2).ConfigureAwait(continueOnCapturedContext: false);
							}
							else
							{
								foreach (object item2 in enumerable)
								{
									await AddMultipartItemAsync(multiPartContent, itemName, parameterName, item2).ConfigureAwait(continueOnCapturedContext: false);
								}
							}
						}
					}
				}
				if (headersToAdd.Count > 0)
				{
					if (ret.Content == null && !BodylessMethods.Contains(ret.Method))
					{
						ret.Content = new ByteArrayContent(new byte[0]);
					}
					foreach (KeyValuePair<string, string> item3 in headersToAdd)
					{
						SetHeader(ret, item3.Key, item3.Value);
					}
				}
				UriBuilder uriBuilder = new UriBuilder(new Uri(new Uri("http://api"), urlTarget));
				NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uriBuilder.Query ?? "");
				string[] allKeys = nameValueCollection.AllKeys;
				foreach (string text2 in allKeys)
				{
					queryParamsToAdd.Insert(0, new KeyValuePair<string, string>(text2, nameValueCollection[text2]));
				}
				if (queryParamsToAdd.Any())
				{
					IEnumerable<string> values = from x in queryParamsToAdd
						where x.Key != null && x.Value != null
						select Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value);
					uriBuilder.Query = string.Join("&", values);
				}
				else
				{
					uriBuilder.Query = null;
				}
				UriFormat format = restMethod.MethodInfo.GetCustomAttribute<QueryUriFormatAttribute>()?.UriFormat ?? UriFormat.UriEscaped;
				ret.RequestUri = new Uri(uriBuilder.Uri.GetComponents(UriComponents.PathAndQuery, format), UriKind.Relative);
				return ret;
			};
		}

		private IEnumerable<KeyValuePair<string, string>> ParseQueryParameter(object param, ParameterInfo parameterInfo, string queryPath, QueryAttribute queryAttribute)
		{
			if (!(param is string) && param is IEnumerable paramValues)
			{
				foreach (string item in ParseEnumerableQueryParameterValue(paramValues, parameterInfo, parameterInfo.ParameterType, queryAttribute))
				{
					yield return new KeyValuePair<string, string>(queryPath, item);
				}
			}
			else
			{
				yield return new KeyValuePair<string, string>(queryPath, settings.UrlParameterFormatter.Format(param, parameterInfo, parameterInfo.ParameterType));
			}
		}

		private IEnumerable<string> ParseEnumerableQueryParameterValue(IEnumerable paramValues, ICustomAttributeProvider customAttributeProvider, Type type, QueryAttribute queryAttribute)
		{
			object obj;
			switch ((queryAttribute != null && queryAttribute.IsCollectionFormatSpecified) ? queryAttribute.CollectionFormat : settings.CollectionFormat)
			{
			case CollectionFormat.Multi:
				foreach (object paramValue in paramValues)
				{
					yield return settings.UrlParameterFormatter.Format(paramValue, customAttributeProvider, type);
				}
				yield break;
			default:
				obj = ",";
				break;
			case CollectionFormat.Pipes:
				obj = "|";
				break;
			case CollectionFormat.Tsv:
				obj = "\t";
				break;
			case CollectionFormat.Ssv:
				obj = " ";
				break;
			}
			string separator = (string)obj;
			IEnumerable<string> values = from object v in paramValues
				select settings.UrlParameterFormatter.Format(v, customAttributeProvider, type);
			yield return string.Join(separator, values);
		}

		private Func<HttpClient, object[], IObservable<T>> BuildRxFuncForMethod<T, TBody>(RestMethodInfo restMethod)
		{
			Func<HttpClient, CancellationToken, object[], Task<T>> taskFunc = BuildCancellableTaskFuncForMethod<T, TBody>(restMethod);
			return (HttpClient client, object[] paramList) => new TaskToObservable<T>(delegate(CancellationToken ct)
			{
				CancellationToken token = CancellationToken.None;
				if (restMethod.CancellationToken != null)
				{
					token = paramList.OfType<CancellationToken>().FirstOrDefault();
				}
				CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, ct);
				return taskFunc(client, cancellationTokenSource.Token, paramList);
			});
		}

		private Func<HttpClient, object[], Task<T>> BuildTaskFuncForMethod<T, TBody>(RestMethodInfo restMethod)
		{
			Func<HttpClient, CancellationToken, object[], Task<T>> ret = BuildCancellableTaskFuncForMethod<T, TBody>(restMethod);
			return (HttpClient client, object[] paramList) => (restMethod.CancellationToken != null) ? ret(client, paramList.OfType<CancellationToken>().FirstOrDefault(), paramList) : ret(client, CancellationToken.None, paramList);
		}

		private Func<HttpClient, object[], Task> BuildVoidTaskFuncForMethod(RestMethodInfo restMethod)
		{
			return async delegate(HttpClient client, object[] paramList)
			{
				if (client.BaseAddress == null)
				{
					throw new InvalidOperationException("BaseAddress must be set on the HttpClient instance");
				}
				HttpRequestMessage rq = await BuildRequestFactoryForMethod(restMethod, client.BaseAddress.AbsolutePath, restMethod.CancellationToken != null)(paramList).ConfigureAwait(continueOnCapturedContext: false);
				CancellationToken cancellationToken = CancellationToken.None;
				if (restMethod.CancellationToken != null)
				{
					cancellationToken = paramList.OfType<CancellationToken>().FirstOrDefault();
				}
				using HttpResponseMessage resp = await client.SendAsync(rq, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (!resp.IsSuccessStatusCode)
				{
					throw await ApiException.Create(rq, restMethod.HttpMethod, resp, settings).ConfigureAwait(continueOnCapturedContext: false);
				}
			};
		}

		private static bool DoNotConvertToQueryMap(object value)
		{
			if (value == null)
			{
				return false;
			}
			Type type = value.GetType();
			if (ShouldReturn())
			{
				return true;
			}
			if (value is IEnumerable)
			{
				Type ienu = typeof(IEnumerable<>);
				Type type2 = type.GetInterfaces().FirstOrDefault((Type i) => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == ienu);
				if (type2 != null)
				{
					type = type2.GetGenericArguments()[0];
				}
			}
			return ShouldReturn();
			bool ShouldReturn()
			{
				if (!(type == typeof(string)) && !(type == typeof(bool)) && !(type == typeof(char)) && !typeof(IFormattable).IsAssignableFrom(type))
				{
					return type == typeof(Uri);
				}
				return true;
			}
		}

		private static void SetHeader(HttpRequestMessage request, string name, string value)
		{
			if (request.Headers.Any((KeyValuePair<string, IEnumerable<string>> x) => x.Key == name))
			{
				request.Headers.Remove(name);
			}
			if (request.Content != null && request.Content.Headers.Any((KeyValuePair<string, IEnumerable<string>> x) => x.Key == name))
			{
				request.Content.Headers.Remove(name);
			}
			if (value != null && !request.Headers.TryAddWithoutValidation(name, value) && request.Content != null)
			{
				request.Content.Headers.TryAddWithoutValidation(name, value);
			}
		}
	}
	[DebuggerDisplay("{MethodInfo}")]
	public class RestMethodInfo
	{
		private static readonly Regex ParameterRegex = new Regex("{(.*?)}");

		private static readonly HttpMethod PatchMethod = new HttpMethod("PATCH");

		public string Name { get; set; }

		public Type Type { get; set; }

		public MethodInfo MethodInfo { get; set; }

		public HttpMethod HttpMethod { get; set; }

		public string RelativePath { get; set; }

		public bool IsMultipart { get; private set; }

		public string MultipartBoundary { get; private set; }

		public ParameterInfo CancellationToken { get; set; }

		public Dictionary<string, string> Headers { get; set; }

		public Dictionary<int, string> HeaderParameterMap { get; set; }

		public Tuple<BodySerializationMethod, bool, int> BodyParameterInfo { get; set; }

		public Dictionary<int, string> QueryParameterMap { get; set; }

		public Dictionary<int, Tuple<string, string>> AttachmentNameMap { get; set; }

		public Dictionary<int, ParameterInfo> ParameterInfoMap { get; set; }

		public Dictionary<int, RestMethodParameterInfo> ParameterMap { get; set; }

		public Type ReturnType { get; set; }

		public Type ReturnResultType { get; set; }

		public Type DeserializedResultType { get; set; }

		public RefitSettings RefitSettings { get; set; }

		public bool IsApiResponse { get; }

		public bool ShouldDisposeResponse { get; private set; }

		public RestMethodInfo(Type targetInterface, MethodInfo methodInfo, RefitSettings refitSettings = null)
		{
			RefitSettings = refitSettings ?? new RefitSettings();
			Type = targetInterface;
			Name = methodInfo.Name;
			MethodInfo = methodInfo;
			HttpMethodAttribute httpMethodAttribute = methodInfo.GetCustomAttributes(inherit: true).OfType<HttpMethodAttribute>().First();
			HttpMethod = httpMethodAttribute.Method;
			RelativePath = httpMethodAttribute.Path;
			IsMultipart = methodInfo.GetCustomAttributes(inherit: true).OfType<MultipartAttribute>().Any();
			MultipartBoundary = (IsMultipart ? methodInfo.GetCustomAttribute<MultipartAttribute>(inherit: true).BoundaryText : string.Empty);
			VerifyUrlPathIsSane(RelativePath);
			DetermineReturnTypeInfo(methodInfo);
			DetermineIfResponseMustBeDisposed();
			List<ParameterInfo> list = (from p in methodInfo.GetParameters()
				where p.ParameterType != typeof(CancellationToken)
				select p).ToList();
			ParameterInfoMap = list.Select((ParameterInfo parameter, int index) => new { index, parameter }).ToDictionary(x => x.index, x => x.parameter);
			ParameterMap = BuildParameterMap(RelativePath, list);
			BodyParameterInfo = FindBodyParameter(list, IsMultipart, httpMethodAttribute.Method);
			Headers = ParseHeaders(methodInfo);
			HeaderParameterMap = BuildHeaderParameterMap(list);
			AttachmentNameMap = new Dictionary<int, Tuple<string, string>>();
			if (IsMultipart)
			{
				for (int num = 0; num < list.Count; num++)
				{
					if (!ParameterMap.ContainsKey(num) && !HeaderParameterMap.ContainsKey(num))
					{
						string attachmentNameForParameter = GetAttachmentNameForParameter(list[num]);
						if (attachmentNameForParameter != null)
						{
							AttachmentNameMap[num] = Tuple.Create(attachmentNameForParameter, GetUrlNameForParameter(list[num]));
						}
					}
				}
			}
			QueryParameterMap = new Dictionary<int, string>();
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				if (!ParameterMap.ContainsKey(num2) && !HeaderParameterMap.ContainsKey(num2) && (BodyParameterInfo == null || BodyParameterInfo.Item3 != num2))
				{
					QueryParameterMap.Add(num2, GetUrlNameForParameter(list[num2]));
				}
			}
			List<ParameterInfo> list2 = (from p in methodInfo.GetParameters()
				where p.ParameterType == typeof(CancellationToken)
				select p).ToList();
			if (list2.Count > 1)
			{
				throw new ArgumentException("Argument list to method \"" + methodInfo.Name + "\" can only contain a single CancellationToken");
			}
			CancellationToken = list2.FirstOrDefault();
			IsApiResponse = ReturnResultType.GetTypeInfo().IsGenericType && (ReturnResultType.GetGenericTypeDefinition() == typeof(ApiResponse<>) || ReturnResultType.GetGenericTypeDefinition() == typeof(IApiResponse<>) || ReturnResultType == typeof(IApiResponse));
		}

		private PropertyInfo[] GetParameterProperties(ParameterInfo parameter)
		{
			return (from p in parameter.ParameterType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				where p.CanRead && p.GetMethod.IsPublic
				select p).ToArray();
		}

		private void VerifyUrlPathIsSane(string relativePath)
		{
			if (relativePath == "" || (relativePath.StartsWith("/") && relativePath.Split('/').Length != 0))
			{
				return;
			}
			throw new ArgumentException("URL path " + relativePath + " must be of the form '/foo/bar/baz'");
		}

		private Dictionary<int, RestMethodParameterInfo> BuildParameterMap(string relativePath, List<ParameterInfo> parameterInfo)
		{
			Dictionary<int, RestMethodParameterInfo> dictionary = new Dictionary<int, RestMethodParameterInfo>();
			List<Match> list = relativePath.Split('/', '?').SelectMany((string x) => ParameterRegex.Matches(x).Cast<Match>()).ToList();
			if (list.Count > 0)
			{
				Dictionary<string, ParameterInfo> dictionary2 = parameterInfo.ToDictionary((ParameterInfo k) => GetUrlNameForParameter(k).ToLowerInvariant(), (ParameterInfo v) => v);
				Dictionary<string, Tuple<ParameterInfo, PropertyInfo>> dictionary3 = (from i in parameterInfo.Where((ParameterInfo x) => x.ParameterType.GetTypeInfo().IsClass).SelectMany((ParameterInfo x) => from p in GetParameterProperties(x)
						select Tuple.Create(x, p))
					group i by (i.Item1.Name + "." + GetUrlNameForProperty(i.Item2)).ToLowerInvariant()).ToDictionary((IGrouping<string, Tuple<ParameterInfo, PropertyInfo>> k) => k.Key, (IGrouping<string, Tuple<ParameterInfo, PropertyInfo>> v) => v.First());
				foreach (Match item in list)
				{
					string text = item.Groups[1].Value.ToLowerInvariant();
					bool flag = text.StartsWith("**");
					string text2 = ((!flag) ? text : text.Substring(2));
					if (dictionary2.ContainsKey(text2))
					{
						Type parameterType = dictionary2[text2].ParameterType;
						if (flag && parameterType != typeof(string))
						{
							throw new ArgumentException("URL " + relativePath + " has round-tripping parameter " + text + ", but the type of matched method parameter is " + parameterType.FullName + ". It must be a string.");
						}
						ParameterType type = (flag ? ParameterType.RoundTripping : ParameterType.Normal);
						RestMethodParameterInfo restMethodParameterInfo = new RestMethodParameterInfo(text2, dictionary2[text2])
						{
							Type = type
						};
						dictionary.Add(parameterInfo.IndexOf(restMethodParameterInfo.ParameterInfo), restMethodParameterInfo);
						continue;
					}
					if (dictionary3.ContainsKey(text2) && !flag)
					{
						Tuple<ParameterInfo, PropertyInfo> tuple = dictionary3[text2];
						int key = parameterInfo.IndexOf(tuple.Item1);
						if (dictionary.ContainsKey(key))
						{
							if (!dictionary[key].IsObjectPropertyParameter)
							{
								throw new ArgumentException("Parameter " + tuple.Item1.Name + " matches both a parameter and nested parameter on a parameter object");
							}
							dictionary[key].ParameterProperties.Add(new RestMethodParameterProperty(text2, tuple.Item2));
						}
						else
						{
							RestMethodParameterInfo restMethodParameterInfo2 = new RestMethodParameterInfo(isObjectPropertyParameter: true, tuple.Item1);
							restMethodParameterInfo2.ParameterProperties.Add(new RestMethodParameterProperty(text2, tuple.Item2));
							dictionary.Add(parameterInfo.IndexOf(restMethodParameterInfo2.ParameterInfo), restMethodParameterInfo2);
						}
						continue;
					}
					throw new ArgumentException("URL " + relativePath + " has parameter " + text + ", but no method parameter matches");
				}
			}
			return dictionary;
		}

		private string GetUrlNameForParameter(ParameterInfo paramInfo)
		{
			AliasAsAttribute aliasAsAttribute = paramInfo.GetCustomAttributes(inherit: true).OfType<AliasAsAttribute>().FirstOrDefault();
			if (aliasAsAttribute == null)
			{
				return paramInfo.Name;
			}
			return aliasAsAttribute.Name;
		}

		private string GetUrlNameForProperty(PropertyInfo propInfo)
		{
			AliasAsAttribute aliasAsAttribute = propInfo.GetCustomAttributes(inherit: true).OfType<AliasAsAttribute>().FirstOrDefault();
			if (aliasAsAttribute == null)
			{
				return propInfo.Name;
			}
			return aliasAsAttribute.Name;
		}

		private string GetAttachmentNameForParameter(ParameterInfo paramInfo)
		{
			object obj = paramInfo.GetCustomAttributes<AttachmentNameAttribute>(inherit: true).FirstOrDefault()?.Name;
			if (obj == null)
			{
				AliasAsAttribute aliasAsAttribute = paramInfo.GetCustomAttributes<AliasAsAttribute>(inherit: true).FirstOrDefault();
				if (aliasAsAttribute == null)
				{
					return null;
				}
				obj = aliasAsAttribute.Name;
			}
			return (string)obj;
		}

		private Tuple<BodySerializationMethod, bool, int> FindBodyParameter(IList<ParameterInfo> parameterList, bool isMultipart, HttpMethod method)
		{
			var list = (from x in parameterList
				select new
				{
					Parameter = x,
					BodyAttribute = x.GetCustomAttributes(inherit: true).OfType<BodyAttribute>().FirstOrDefault()
				} into x
				where x.BodyAttribute != null
				select x).ToList();
			if (isMultipart)
			{
				if (list.Count > 0)
				{
					throw new ArgumentException("Multipart requests may not contain a Body parameter");
				}
				return null;
			}
			if (list.Count > 1)
			{
				throw new ArgumentException("Only one parameter can be a Body parameter");
			}
			if (list.Count == 1)
			{
				var anon = list[0];
				return Tuple.Create(anon.BodyAttribute.SerializationMethod, anon.BodyAttribute.Buffered ?? RefitSettings.Buffered, parameterList.IndexOf(anon.Parameter));
			}
			if (!method.Equals(HttpMethod.Post) && !method.Equals(HttpMethod.Put) && !method.Equals(PatchMethod))
			{
				return null;
			}
			List<ParameterInfo> list2 = parameterList.Where((ParameterInfo pi) => !pi.ParameterType.GetTypeInfo().IsValueType && pi.ParameterType != typeof(string) && pi.GetCustomAttribute<QueryAttribute>() == null).ToList();
			if (list2.Count > 1)
			{
				throw new ArgumentException("Multiple complex types found. Specify one parameter as the body using BodyAttribute");
			}
			if (list2.Count == 1)
			{
				return Tuple.Create(BodySerializationMethod.Serialized, item2: false, parameterList.IndexOf(list2[0]));
			}
			return null;
		}

		private Dictionary<string, string> ParseHeaders(MethodInfo methodInfo)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			IEnumerable<object> first;
			if (!(methodInfo.DeclaringType != null))
			{
				IEnumerable<object> enumerable = new Attribute[0];
				first = enumerable;
			}
			else
			{
				first = methodInfo.DeclaringType.GetInterfaces().SelectMany((Type i) => i.GetTypeInfo().GetCustomAttributes(inherit: true)).Reverse();
			}
			object[] array2;
			if (!(methodInfo.DeclaringType != null))
			{
				object[] array = new Attribute[0];
				array2 = array;
			}
			else
			{
				array2 = methodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes(inherit: true);
			}
			object[] second = array2;
			foreach (string item in first.Concat(second).Concat(methodInfo.GetCustomAttributes(inherit: true)).OfType<HeadersAttribute>()
				.SelectMany((HeadersAttribute ha) => ha.Headers))
			{
				if (!string.IsNullOrWhiteSpace(item))
				{
					string[] array3 = item.Split(':');
					dictionary[array3[0].Trim()] = ((array3.Length > 1) ? string.Join(":", array3.Skip(1)).Trim() : null);
				}
			}
			return dictionary;
		}

		private Dictionary<int, string> BuildHeaderParameterMap(List<ParameterInfo> parameterList)
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			for (int i = 0; i < parameterList.Count; i++)
			{
				string text = (from ha in parameterList[i].GetCustomAttributes(inherit: true).OfType<HeaderAttribute>()
					select ha.Header).FirstOrDefault();
				if (!string.IsNullOrWhiteSpace(text))
				{
					dictionary[i] = text.Trim();
				}
			}
			return dictionary;
		}

		private void DetermineReturnTypeInfo(MethodInfo methodInfo)
		{
			Type returnType = methodInfo.ReturnType;
			if (returnType.IsGenericType && (methodInfo.ReturnType.GetGenericTypeDefinition() != typeof(Task<>) || methodInfo.ReturnType.GetGenericTypeDefinition() != typeof(IObservable<>)))
			{
				ReturnType = returnType;
				ReturnResultType = returnType.GetGenericArguments()[0];
				if (ReturnResultType.IsGenericType && (ReturnResultType.GetGenericTypeDefinition() == typeof(ApiResponse<>) || ReturnResultType.GetGenericTypeDefinition() == typeof(IApiResponse<>)))
				{
					DeserializedResultType = ReturnResultType.GetGenericArguments()[0];
				}
				else if (ReturnResultType == typeof(IApiResponse))
				{
					DeserializedResultType = typeof(HttpContent);
				}
				else
				{
					DeserializedResultType = ReturnResultType;
				}
			}
			else
			{
				if (!(returnType == typeof(Task)))
				{
					throw new ArgumentException("Method \"" + methodInfo.Name + "\" is invalid. All REST Methods must return either Task<T> or IObservable<T>");
				}
				ReturnType = methodInfo.ReturnType;
				ReturnResultType = typeof(void);
				DeserializedResultType = typeof(void);
			}
		}

		private void DetermineIfResponseMustBeDisposed()
		{
			ShouldDisposeResponse = DeserializedResultType != typeof(HttpResponseMessage) && DeserializedResultType != typeof(HttpContent) && DeserializedResultType != typeof(Stream);
		}
	}
	public class RestMethodParameterInfo
	{
		public string Name { get; set; }

		public ParameterInfo ParameterInfo { get; set; }

		public bool IsObjectPropertyParameter { get; set; }

		public List<RestMethodParameterProperty> ParameterProperties { get; set; } = new List<RestMethodParameterProperty>();

		public ParameterType Type { get; set; }

		public RestMethodParameterInfo(string name, ParameterInfo parameterInfo)
		{
			Name = name;
			ParameterInfo = parameterInfo;
		}

		public RestMethodParameterInfo(bool isObjectPropertyParameter, ParameterInfo parameterInfo)
		{
			IsObjectPropertyParameter = isObjectPropertyParameter;
			ParameterInfo = parameterInfo;
		}
	}
	public class RestMethodParameterProperty
	{
		public string Name { get; set; }

		public PropertyInfo PropertyInfo { get; set; }

		public RestMethodParameterProperty(string name, PropertyInfo propertyInfo)
		{
			Name = name;
			PropertyInfo = propertyInfo;
		}
	}
	public enum ParameterType
	{
		Normal,
		RoundTripping
	}
	public static class RestService
	{
		private static readonly ConcurrentDictionary<Type, Type> TypeMapping = new ConcurrentDictionary<Type, Type>();

		public static T For<T>(HttpClient client, IRequestBuilder<T> builder)
		{
			return (T)For(typeof(T), client, builder);
		}

		public static T For<T>(HttpClient client, RefitSettings settings)
		{
			IRequestBuilder<T> builder = RequestBuilder.ForType<T>(settings);
			return For(client, builder);
		}

		public static T For<T>(HttpClient client)
		{
			return For<T>(client, (RefitSettings)null);
		}

		public static T For<T>(string hostUrl, RefitSettings settings)
		{
			return For<T>(CreateHttpClient(hostUrl, settings), settings);
		}

		public static T For<T>(string hostUrl)
		{
			return For<T>(hostUrl, null);
		}

		public static object For(Type refitInterfaceType, HttpClient client, IRequestBuilder builder)
		{
			return Activator.CreateInstance(TypeMapping.GetOrAdd(refitInterfaceType, GetGeneratedType(refitInterfaceType)), client, builder);
		}

		public static object For(Type refitInterfaceType, HttpClient client, RefitSettings settings)
		{
			IRequestBuilder builder = RequestBuilder.ForType(refitInterfaceType, settings);
			return For(refitInterfaceType, client, builder);
		}

		public static object For(Type refitInterfaceType, HttpClient client)
		{
			return For(refitInterfaceType, client, (RefitSettings)null);
		}

		public static object For(Type refitInterfaceType, string hostUrl, RefitSettings settings)
		{
			HttpClient client = CreateHttpClient(hostUrl, settings);
			return For(refitInterfaceType, client, settings);
		}

		public static object For(Type refitInterfaceType, string hostUrl)
		{
			return For(refitInterfaceType, hostUrl, null);
		}

		public static HttpClient CreateHttpClient(string hostUrl, RefitSettings settings)
		{
			if (string.IsNullOrWhiteSpace(hostUrl))
			{
				throw new ArgumentException("`hostUrl` must not be null or whitespace.", "hostUrl");
			}
			HttpMessageHandler httpMessageHandler = null;
			if (settings != null)
			{
				if (settings.HttpMessageHandlerFactory != null)
				{
					httpMessageHandler = settings.HttpMessageHandlerFactory();
				}
				if (settings.AuthorizationHeaderValueGetter != null)
				{
					httpMessageHandler = new AuthenticatedHttpClientHandler(settings.AuthorizationHeaderValueGetter, httpMessageHandler);
				}
				else if (settings.AuthorizationHeaderValueWithParamGetter != null)
				{
					httpMessageHandler = new AuthenticatedParameterizedHttpClientHandler(settings.AuthorizationHeaderValueWithParamGetter, httpMessageHandler);
				}
			}
			return new HttpClient(httpMessageHandler ?? new HttpClientHandler())
			{
				BaseAddress = new Uri(hostUrl.TrimEnd('/'))
			};
		}

		private static Type GetGeneratedType(Type refitInterfaceType)
		{
			Type type = Type.GetType(UniqueName.ForType(refitInterfaceType));
			if (type == null)
			{
				throw new InvalidOperationException(refitInterfaceType.Name + " doesn't look like a Refit interface. Make sure it has at least one method with a Refit HTTP method attribute and Refit is installed in the project.");
			}
			return type;
		}
	}
	public sealed class SystemTextJsonContentSerializer : IContentSerializer
	{
		private readonly JsonSerializerOptions jsonSerializerOptions;

		public SystemTextJsonContentSerializer()
			: this(new JsonSerializerOptions())
		{
		}

		public SystemTextJsonContentSerializer(JsonSerializerOptions jsonSerializerOptions)
		{
			this.jsonSerializerOptions = jsonSerializerOptions;
		}

		public Task<HttpContent> SerializeAsync<T>(T item)
		{
			using PooledBufferWriter pooledBufferWriter = new PooledBufferWriter();
			System.Text.Json.JsonSerializer.Serialize(new Utf8JsonWriter(pooledBufferWriter), item, jsonSerializerOptions);
			Stream stream = pooledBufferWriter.DetachStream();
			StreamContent streamContent = new StreamContent(stream);
			streamContent.Headers.ContentLength = stream.Length;
			streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json")
			{
				CharSet = Encoding.UTF8.WebName
			};
			return Task.FromResult((HttpContent)streamContent);
		}

		public async Task<T> DeserializeAsync<T>(HttpContent content)
		{
			using Stream stream = await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
			int streamLength;
			try
			{
				streamLength = (int)stream.Length;
			}
			catch (NotSupportedException)
			{
				return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(stream, jsonSerializerOptions).ConfigureAwait(continueOnCapturedContext: false);
			}
			byte[] buffer = ArrayPool<byte>.Shared.Rent(streamLength);
			try
			{
				return Deserialize<T>(buffer, await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(continueOnCapturedContext: false), jsonSerializerOptions);
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(buffer);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static T Deserialize<T>(byte[] buffer, int length, JsonSerializerOptions jsonSerializerOptions)
		{
			ReadOnlySpan<byte> jsonData = new ReadOnlySpan<byte>(buffer, 0, length);
			Utf8JsonReader reader = new Utf8JsonReader(jsonData);
			return System.Text.Json.JsonSerializer.Deserialize<T>(ref reader, jsonSerializerOptions);
		}
	}
	internal class UniqueName
	{
		public static string ForType<T>()
		{
			return ForType(typeof(T));
		}

		public static string ForType(Type refitInterfaceType)
		{
			if (refitInterfaceType.IsNested)
			{
				string text = "AutoGenerated" + refitInterfaceType.DeclaringType.Name + refitInterfaceType.Name;
				return refitInterfaceType.AssemblyQualifiedName.Replace(refitInterfaceType.DeclaringType.FullName + "+" + refitInterfaceType.Name, refitInterfaceType.Namespace + "." + text);
			}
			string text2 = "AutoGenerated" + refitInterfaceType.Name;
			if (refitInterfaceType.Namespace == null)
			{
				text2 = text2 + "." + text2;
			}
			return refitInterfaceType.AssemblyQualifiedName.Replace(refitInterfaceType.Name, text2);
		}
	}
	[Serializable]
	public class ValidationApiException : ApiException
	{
		public new ProblemDetails Content { get; private set; }

		private ValidationApiException(ApiException apiException)
			: base(apiException.RequestMessage, apiException.HttpMethod, apiException.StatusCode, apiException.ReasonPhrase, apiException.Headers, apiException.RefitSettings)
		{
		}

		public static async Task<ValidationApiException> Create(ApiException exception)
		{
			ValidationApiException ex = new ValidationApiException(exception);
			ValidationApiException ex2 = ex;
			ex2.Content = await exception.GetContentAsAsync<ProblemDetails>().ConfigureAwait(continueOnCapturedContext: false);
			return ex;
		}
	}
	public class XmlContentSerializer : IContentSerializer
	{
		private readonly XmlContentSerializerSettings settings;

		private readonly ConcurrentDictionary<Type, XmlSerializer> serializerCache = new ConcurrentDictionary<Type, XmlSerializer>();

		public XmlContentSerializer()
			: this(new XmlContentSerializerSettings())
		{
		}

		public XmlContentSerializer(XmlContentSerializerSettings settings)
		{
			this.settings = settings ?? throw new ArgumentNullException("settings");
		}

		public Task<HttpContent> SerializeAsync<T>(T item)
		{
			XmlSerializer orAdd = serializerCache.GetOrAdd(item.GetType(), (Type t) => new XmlSerializer(t, settings.XmlAttributeOverrides));
			using MemoryStream memoryStream = new MemoryStream();
			using XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings.XmlReaderWriterSettings.WriterSettings);
			Encoding encoding = settings.XmlReaderWriterSettings.WriterSettings?.Encoding ?? Encoding.Unicode;
			orAdd.Serialize(xmlWriter, item, settings.XmlNamespaces);
			return Task.FromResult((HttpContent)new StringContent(encoding.GetString(memoryStream.ToArray()), encoding, "application/xml"));
		}

		public async Task<T> DeserializeAsync<T>(HttpContent content)
		{
			XmlSerializer xmlSerializer = serializerCache.GetOrAdd(typeof(T), (Type t) => new XmlSerializer(t, settings.XmlAttributeOverrides));
			using StringReader input = new StringReader(await content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false));
			using XmlReader xmlReader = XmlReader.Create(input, settings.XmlReaderWriterSettings.ReaderSettings);
			return (T)xmlSerializer.Deserialize(xmlReader);
		}
	}
	public class XmlReaderWriterSettings
	{
		private XmlReaderSettings readerSettings;

		private XmlWriterSettings writerSettings;

		public XmlReaderSettings ReaderSettings
		{
			get
			{
				ApplyOverrideSettings();
				return readerSettings;
			}
			set
			{
				readerSettings = value ?? throw new ArgumentNullException("value");
			}
		}

		public XmlWriterSettings WriterSettings
		{
			get
			{
				ApplyOverrideSettings();
				return writerSettings;
			}
			set
			{
				writerSettings = value ?? throw new ArgumentNullException("value");
			}
		}

		public XmlReaderWriterSettings()
			: this(new XmlReaderSettings(), new XmlWriterSettings())
		{
		}

		public XmlReaderWriterSettings(XmlReaderSettings readerSettings)
			: this(readerSettings, new XmlWriterSettings())
		{
		}

		public XmlReaderWriterSettings(XmlWriterSettings writerSettings)
			: this(new XmlReaderSettings(), writerSettings)
		{
		}

		public XmlReaderWriterSettings(XmlReaderSettings readerSettings, XmlWriterSettings writerSettings)
		{
			ReaderSettings = readerSettings;
			WriterSettings = writerSettings;
		}

		private void ApplyOverrideSettings()
		{
			writerSettings.Async = true;
			readerSettings.Async = true;
		}
	}
	public class XmlContentSerializerSettings
	{
		public XmlReaderWriterSettings XmlReaderWriterSettings { get; set; }

		public XmlSerializerNamespaces XmlNamespaces { get; set; }

		public XmlAttributeOverrides XmlAttributeOverrides { get; set; }

		public XmlContentSerializerSettings()
		{
			XmlReaderWriterSettings = new XmlReaderWriterSettings();
			XmlNamespaces = new XmlSerializerNamespaces(new XmlQualifiedName[1]
			{
				new XmlQualifiedName(string.Empty, string.Empty)
			});
			XmlAttributeOverrides = new XmlAttributeOverrides();
		}
	}
}
namespace Refit.Buffers
{
	internal sealed class PooledBufferWriter : IBufferWriter<byte>, IDisposable
	{
		private sealed class PooledMemoryStream : Stream
		{
			private readonly int length;

			private byte[]? pooledBuffer;

			private int position;

			public override bool CanRead => true;

			public override bool CanSeek => false;

			public override bool CanWrite => false;

			public override long Length => length;

			public override long Position
			{
				get
				{
					return position;
				}
				set
				{
					ThrowNotSupportedException();
				}
			}

			public PooledMemoryStream(PooledBufferWriter writer)
			{
				length = writer.position;
				pooledBuffer = writer.buffer;
			}

			~PooledMemoryStream()
			{
				Dispose(disposing: true);
			}

			public override void Flush()
			{
			}

			public override Task FlushAsync(CancellationToken cancellationToken)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled(cancellationToken);
				}
				return Task.CompletedTask;
			}

			public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled(cancellationToken);
				}
				try
				{
					CopyTo(destination, bufferSize);
					return Task.CompletedTask;
				}
				catch (OperationCanceledException ex)
				{
					return Task.FromCanceled(ex.CancellationToken);
				}
				catch (Exception exception)
				{
					return Task.FromException(exception);
				}
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				if (offset < 0)
				{
					ThrowArgumentOutOfRangeExceptionForNegativeOffset();
				}
				if (count < 0)
				{
					ThrowArgumentOutOfRangeExceptionForNegativeCount();
				}
				if (offset + count > buffer.Length)
				{
					ThrowArgumentOutOfRangeExceptionForEndOfStreamReached();
				}
				if (pooledBuffer == null)
				{
					ThrowObjectDisposedException();
				}
				Span<byte> destination = MemoryExtensions.AsSpan(buffer, offset, count);
				Span<byte> span = MemoryExtensions.AsSpan(pooledBuffer, 0, length);
				Span<byte> span2 = span.Slice(position);
				if (span2.Length <= destination.Length)
				{
					span2.CopyTo(destination);
					position += span2.Length;
					return span2.Length;
				}
				span = span2.Slice(0, destination.Length);
				span.CopyTo(destination);
				position += destination.Length;
				return destination.Length;
			}

			public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled<int>(cancellationToken);
				}
				try
				{
					return Task.FromResult(Read(buffer, offset, count));
				}
				catch (OperationCanceledException ex)
				{
					return Task.FromCanceled<int>(ex.CancellationToken);
				}
				catch (Exception exception)
				{
					return Task.FromException<int>(exception);
				}
			}

			public override int ReadByte()
			{
				if (pooledBuffer == null)
				{
					ThrowObjectDisposedException();
				}
				if (position >= pooledBuffer.Length)
				{
					return -1;
				}
				return pooledBuffer[position++];
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				ThrowNotSupportedException();
				return 0L;
			}

			public override void SetLength(long value)
			{
				ThrowNotSupportedException();
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				ThrowNotSupportedException();
			}

			protected override void Dispose(bool disposing)
			{
				if (pooledBuffer != null)
				{
					GC.SuppressFinalize(this);
					ArrayPool<byte>.Shared.Return(pooledBuffer);
					pooledBuffer = null;
				}
			}

			public override void CopyTo(Stream destination, int bufferSize)
			{
				if (pooledBuffer == null)
				{
					ThrowObjectDisposedException();
				}
				int num = Math.Min(length - position, bufferSize);
				Span<byte> span = MemoryExtensions.AsSpan(pooledBuffer, position, num);
				position += span.Length;
				destination.Write(span);
			}

			public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return new ValueTask<int>(Task.FromCanceled<int>(cancellationToken));
				}
				try
				{
					return new ValueTask<int>(Read(buffer.Span));
				}
				catch (OperationCanceledException ex)
				{
					return new ValueTask<int>(Task.FromCanceled<int>(ex.CancellationToken));
				}
				catch (Exception exception)
				{
					return new ValueTask<int>(Task.FromException<int>(exception));
				}
			}

			public override int Read(Span<byte> buffer)
			{
				if (pooledBuffer == null)
				{
					ThrowObjectDisposedException();
				}
				if (position >= length)
				{
					return 0;
				}
				int num = length - position;
				Span<byte> span = MemoryExtensions.AsSpan(pooledBuffer, position, num);
				int num2 = Math.Min(span.Length, buffer.Length);
				Span<byte> destination = buffer.Slice(0, num2);
				span.CopyTo(destination);
				position += num2;
				return num2;
			}
		}

		public const int DefaultSize = 1024;

		private byte[] buffer;

		private int position;

		public PooledBufferWriter()
		{
			buffer = ArrayPool<byte>.Shared.Rent(1024);
			position = 0;
		}

		public void Advance(int count)
		{
			if (count < 0)
			{
				ThrowArgumentOutOfRangeExceptionForNegativeCount();
			}
			if (position > buffer.Length - count)
			{
				ThrowArgumentOutOfRangeExceptionForAdvancedTooFar();
			}
			position += count;
		}

		public Memory<byte> GetMemory(int sizeHint = 0)
		{
			EnsureFreeCapacity(sizeHint);
			return MemoryExtensions.AsMemory(buffer, position);
		}

		public Span<byte> GetSpan(int sizeHint = 0)
		{
			EnsureFreeCapacity(sizeHint);
			return MemoryExtensions.AsSpan(buffer, position);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void EnsureFreeCapacity(int count)
		{
			if (count < 0)
			{
				ThrowArgumentOutOfRangeExceptionForNegativeCount();
			}
			if (count == 0)
			{
				count = 1;
			}
			int num = buffer.Length;
			int num2 = num - position;
			if (count > num2)
			{
				int num3 = Math.Max(count, num);
				int minimumLength = checked(num + num3);
				byte[] destinationArray = ArrayPool<byte>.Shared.Rent(minimumLength);
				Array.Copy(buffer, destinationArray, position);
				ArrayPool<byte>.Shared.Return(buffer);
				buffer = destinationArray;
			}
		}

		public void Dispose()
		{
			if (buffer != null)
			{
				ArrayPool<byte>.Shared.Return(buffer);
			}
		}

		public Stream DetachStream()
		{
			PooledMemoryStream result = new PooledMemoryStream(this);
			buffer = null;
			return result;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowArgumentOutOfRangeExceptionForNegativeCount()
		{
			throw new ArgumentOutOfRangeException("count", "The count can't be < 0");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowArgumentOutOfRangeExceptionForNegativeOffset()
		{
			throw new ArgumentOutOfRangeException("offset", "The offset can't be < 0");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowArgumentOutOfRangeExceptionForAdvancedTooFar()
		{
			throw new ArgumentOutOfRangeException("count", "Advanced too far");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowArgumentOutOfRangeExceptionForEndOfStreamReached()
		{
			throw new ArgumentException("The end of the stream has been exceeded");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowObjectDisposedException()
		{
			throw new ObjectDisposedException("The stream in use has alreadybeen disposed");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowNotSupportedException()
		{
			throw new NotSupportedException("The stream doesn't support the requested operation");
		}
	}
}
