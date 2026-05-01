using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Refit;
using iFit.Api.Atlassian.RefitInternalGenerated;
using iFit.Api.Support;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("Atlassian API for posting new issues to Jira")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Api.Atlassian")]
[assembly: AssemblyTitle("iFit.Api.Atlassian")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Api.Atlassian
{
	public interface IAtlassianApiService
	{
		string ProjectId { get; }

		IAtlassianApi Service();
	}
	public class AtlassianApiService : IAtlassianApiService
	{
		public const string FeedbackProjectId = "12000";

		public const string DefaultDebugUrl = "https://https-ifitdev-atlassian-net-3.moesif.net/rest/api/2";

		public const string DefaultUrl = "https://ifitdev.atlassian.net/rest/api/2";

		private const string MoesifAppHeaderKey = "X-Moesif-Application-Id";

		private const string MoesifDebugApplicationId = "eyJhcHAiOiI2NzY6MTkiLCJ2ZXIiOiIyLjAiLCJvcmciOiI2NDA6MzMiLCJpYXQiOjE1NDQyMjcyMDB9.NF__HJyZ_SE_brox4XVD_3q7WzHBU0WA39yU5KwOv7A";

		private IAtlassianApi atlassianApi;

		public string ProjectId { get; private set; }

		public AtlassianApiService(string[] encodedUserName, string[] encodedApiToken, string projectId = "12000", string url = "https://ifitdev.atlassian.net/rest/api/2")
		{
			Initialize(encodedUserName.TransformString(), encodedApiToken.TransformString(), projectId, url);
		}

		public AtlassianApiService(string username, string apiToken, string projectId = "12000", string url = "https://ifitdev.atlassian.net/rest/api/2")
		{
			Initialize(username, apiToken, projectId, url);
		}

		private void Initialize(string username, string apiToken, string projectId, string url)
		{
			ProjectId = projectId;
			HttpClient httpClient = new HttpClient(new AuthenticatedHttpClientHandler((username + ":" + apiToken).Base64Encoding()))
			{
				BaseAddress = new Uri(url)
			};
			if (url == "https://https-ifitdev-atlassian-net-3.moesif.net/rest/api/2")
			{
				httpClient.DefaultRequestHeaders.Add("X-Moesif-Application-Id", "eyJhcHAiOiI2NzY6MTkiLCJ2ZXIiOiIyLjAiLCJvcmciOiI2NDA6MzMiLCJpYXQiOjE1NDQyMjcyMDB9.NF__HJyZ_SE_brox4XVD_3q7WzHBU0WA39yU5KwOv7A");
			}
			atlassianApi = RestService.For<IAtlassianApi>(httpClient);
		}

		public IAtlassianApi Service()
		{
			return atlassianApi;
		}
	}
	public class AuthenticatedHttpClientHandler : NativeMessageHandler
	{
		private readonly string basicAuth;

		public AuthenticatedHttpClientHandler(string basicAuth)
		{
			this.basicAuth = basicAuth;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (!CrossConnectivity.Current.IsConnected)
			{
				throw new ConnectivityException("no internet connection");
			}
			AuthenticationHeaderValue authorization = request.Headers.Authorization;
			if (authorization != null && authorization.Scheme == "Basic")
			{
				request.Headers.Authorization = new AuthenticationHeaderValue(authorization.Scheme, basicAuth);
			}
			return await ((HttpClientHandler)this).SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
	public interface IAtlassianApi
	{
		[Post("/issue")]
		[Headers(new string[] { "Authorization: Basic" })]
		Task<Issue.CreateIssueResponse> CreateIssue([Body] Issue issue, CancellationToken token = default(CancellationToken));
	}
	public class Issue
	{
		public class Project
		{
			[JsonProperty(PropertyName = "id")]
			public string Id { get; set; }
		}

		public class Issuetype
		{
			[JsonProperty(PropertyName = "id")]
			public string Id { get; set; }
		}

		public class IssueFields
		{
			[JsonProperty(PropertyName = "project")]
			public Project Project { get; set; }

			[JsonProperty(PropertyName = "summary")]
			public string Summary { get; set; }

			[JsonProperty(PropertyName = "issuetype")]
			public Issuetype IssueType { get; set; }

			[JsonProperty(PropertyName = "labels")]
			public List<string> Labels { get; set; }

			[JsonProperty(PropertyName = "description")]
			public string Description { get; set; }
		}

		public class CreateIssueResponse
		{
			[JsonProperty(PropertyName = "id")]
			public string Id { get; set; }

			[JsonProperty(PropertyName = "key")]
			public string Key { get; set; }

			[JsonProperty(PropertyName = "self")]
			public string Self { get; set; }
		}

		public const string BugIssueType = "1";

		[JsonProperty(PropertyName = "fields")]
		public IssueFields Fields { get; set; }

		public static async Task<CreateIssueResponse> SendFeedback(IAtlassianApiService apiService, string projectName, string subject, string description, string issueType = "1", IList<string> labels = null, CancellationToken token = default(CancellationToken), IConnectivity connectivity = null)
		{
			if (string.IsNullOrWhiteSpace(projectName))
			{
				throw new ArgumentException("Must provide projectName");
			}
			if (string.IsNullOrWhiteSpace(subject))
			{
				throw new ArgumentException("Must provide subject");
			}
			if (string.IsNullOrWhiteSpace(description))
			{
				throw new ArgumentException("Must provide description");
			}
			if (string.IsNullOrWhiteSpace(issueType))
			{
				throw new ArgumentException("Must provide issue type");
			}
			if (apiService == null)
			{
				throw new ArgumentException("Must provide Atlassian API service");
			}
			if (connectivity == null)
			{
				connectivity = CrossConnectivity.Current;
			}
			if (!connectivity.IsConnected)
			{
				throw new ConnectivityException("Not connected on Atlassian create issue call");
			}
			projectName = Regex.Replace(projectName, " ", "-").ToLower();
			Issue issue = new Issue
			{
				Fields = new IssueFields
				{
					Project = new Project
					{
						Id = apiService.ProjectId
					},
					Summary = subject,
					IssueType = new Issuetype
					{
						Id = issueType
					},
					Labels = new List<string> { projectName },
					Description = description
				}
			};
			if (labels != null && labels.Count > 0)
			{
				issue.Fields.Labels.AddRange(labels);
			}
			return await issue.Create(apiService, token);
		}

		public async Task<CreateIssueResponse> Create(IAtlassianApiService api, CancellationToken token = default(CancellationToken))
		{
			return await api.Service().CreateIssue(this, token);
		}
	}
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	internal class AutoGeneratedIAtlassianApi : IAtlassianApi
	{
		private readonly IRequestBuilder requestBuilder;

		public HttpClient Client { get; protected set; }

		public AutoGeneratedIAtlassianApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		Task<Issue.CreateIssueResponse> IAtlassianApi.CreateIssue(Issue issue, CancellationToken token)
		{
			object[] arg = new object[2] { issue, token };
			return (Task<Issue.CreateIssueResponse>)requestBuilder.BuildRestResultFuncForMethod("CreateIssue", new Type[2]
			{
				typeof(Issue),
				typeof(CancellationToken)
			})(Client, arg);
		}
	}
}
namespace iFit.Api.Atlassian.RefitInternalGenerated
{
	[ExcludeFromCodeCoverage]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
	internal sealed class PreserveAttribute : Attribute
	{
		public bool AllMembers;

		public bool Conditional;
	}
}
