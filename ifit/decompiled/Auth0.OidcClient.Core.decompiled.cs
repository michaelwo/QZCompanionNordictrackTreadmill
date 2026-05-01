using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Auth0.OidcClient.Tokens;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using IdentityModel.OidcClient.Results;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Auth0.OidcClient.Core.UnitTests, PublicKey=002400000480000094000000060200000024000052534131000400000100010029ea30e6e623928cd6fb2ef20ce681b505ba16a96022dff7fe72d6bd4f6c92ade261bae3e2cb016d93ad5b0df960e7c2765c4d60a655ff414eeb2129875558661982be916ccdc5b67c45fbfeab792f666187c3ce61b16f0a8ab16374556e82b1ace5ce0bf7c7722fcb58992154b584c56d3a0169fa9967347b64efc124e154c9")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Auth0.OidcClient.Core")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("3.1.2")]
[assembly: AssemblyInformationalVersion("3.1.2")]
[assembly: AssemblyProduct("Auth0.OidcClient.Core")]
[assembly: AssemblyTitle("Auth0.OidcClient.Core")]
[assembly: AssemblyVersion("3.1.2.0")]
namespace Auth0.OidcClient
{
	public abstract class Auth0ClientBase : IAuth0Client
	{
		private readonly IdTokenRequirements _idTokenRequirements;

		private readonly Auth0ClientOptions _options;

		private readonly string _userAgent;

		private IdentityModel.OidcClient.OidcClient _oidcClient;

		private IdentityModel.OidcClient.OidcClient OidcClient => _oidcClient ?? (_oidcClient = new IdentityModel.OidcClient.OidcClient(CreateOidcClientOptions(_options)));

		protected Auth0ClientBase(Auth0ClientOptions options, string platformName)
		{
			_options = options;
			_idTokenRequirements = new IdTokenRequirements("https://" + _options.Domain + "/", _options.ClientId, options.Leeway, options.MaxAge);
			_userAgent = CreateAgentString(platformName);
		}

		public async Task<LoginResult> LoginAsync(object extraParameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			Dictionary<string, string> dictionary = AppendTelemetry(extraParameters);
			if (_options.MaxAge.HasValue)
			{
				dictionary["max_age"] = _options.MaxAge.Value.TotalSeconds.ToString("0");
			}
			LoginRequest request = new LoginRequest
			{
				FrontChannelExtraParameters = dictionary
			};
			LoginResult result = await OidcClient.LoginAsync(request, cancellationToken);
			if (!result.IsError)
			{
				await _idTokenRequirements.AssertTokenMeetsRequirements(result.IdentityToken);
			}
			return result;
		}

		public async Task<BrowserResultType> LogoutAsync(bool federated = false, object extraParameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			Dictionary<string, string> dictionary = AppendTelemetry(extraParameters);
			dictionary["client_id"] = OidcClient.Options.ClientId;
			dictionary["returnTo"] = OidcClient.Options.PostLogoutRedirectUri;
			string text = new RequestUrl("https://" + _options.Domain + "/v2/logout").Create(dictionary);
			if (federated)
			{
				text += "&federated";
			}
			LogoutRequest logoutRequest = new LogoutRequest();
			BrowserOptions options = new BrowserOptions(text, OidcClient.Options.PostLogoutRedirectUri ?? string.Empty)
			{
				Timeout = TimeSpan.FromSeconds(logoutRequest.BrowserTimeout),
				DisplayMode = logoutRequest.BrowserDisplayMode
			};
			return (await OidcClient.Options.Browser.InvokeAsync(options, cancellationToken)).ResultType;
		}

		public Task<AuthorizeState> PrepareLoginAsync(object extraParameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return OidcClient.PrepareLoginAsync(AppendTelemetry(extraParameters), cancellationToken);
		}

		public Task<LoginResult> ProcessResponseAsync(string data, AuthorizeState state, object extraParameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return OidcClient.ProcessResponseAsync(data, state, AppendTelemetry(extraParameters), cancellationToken);
		}

		public async Task<RefreshTokenResult> RefreshTokenAsync(string refreshToken, object extraParameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			RefreshTokenResult result = await OidcClient.RefreshTokenAsync(refreshToken, AppendTelemetry(extraParameters), cancellationToken);
			if (!result.IsError)
			{
				await _idTokenRequirements.AssertTokenMeetsRequirements(result.IdentityToken);
			}
			return result;
		}

		public Task<UserInfoResult> GetUserInfoAsync(string accessToken)
		{
			return OidcClient.GetUserInfoAsync(accessToken);
		}

		private OidcClientOptions CreateOidcClientOptions(Auth0ClientOptions options)
		{
			List<string> list = options.Scope.Split(new char[1] { ' ' }).ToList();
			if (!list.Contains("openid"))
			{
				list.Insert(0, "openid");
			}
			OidcClientOptions oidcClientOptions = new OidcClientOptions
			{
				Authority = "https://" + options.Domain,
				ClientId = options.ClientId,
				Scope = string.Join(" ", list),
				LoadProfile = options.LoadProfile,
				Browser = options.Browser,
				Flow = OidcClientOptions.AuthenticationFlow.AuthorizationCode,
				ResponseMode = OidcClientOptions.AuthorizeResponseMode.Redirect,
				RedirectUri = (options.RedirectUri ?? ("https://" + _options.Domain + "/mobile")),
				PostLogoutRedirectUri = (options.PostLogoutRedirectUri ?? ("https://" + _options.Domain + "/mobile")),
				ClockSkew = options.Leeway,
				Policy = 
				{
					RequireAuthorizationCodeHash = false,
					RequireAccessTokenHash = false
				}
			};
			if (!string.IsNullOrWhiteSpace(oidcClientOptions.ClientSecret))
			{
				oidcClientOptions.ClientSecret = options.ClientSecret;
			}
			if (options.RefreshTokenMessageHandler != null)
			{
				oidcClientOptions.RefreshTokenInnerHttpHandler = options.RefreshTokenMessageHandler;
			}
			if (options.BackchannelHandler != null)
			{
				oidcClientOptions.BackchannelHandler = options.BackchannelHandler;
			}
			return oidcClientOptions;
		}

		private Dictionary<string, string> AppendTelemetry(object values)
		{
			Dictionary<string, string> dictionary = ObjectToDictionary(values);
			if (_options.EnableTelemetry)
			{
				dictionary.Add("auth0Client", _userAgent);
			}
			return dictionary;
		}

		private string CreateAgentString(string platformName)
		{
			Version version = typeof(Auth0ClientBase).GetTypeInfo().Assembly.GetName().Version;
			string s = $"{{\"name\":\"oidc-net\",\"version\":\"{version.Major}.{version.Minor}.{version.Revision}\",\"env\":{{\"platform\":\"{platformName}\"}}}}";
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
		}

		private Dictionary<string, string> ObjectToDictionary(object values)
		{
			if (values is Dictionary<string, string> result)
			{
				return result;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (values != null)
			{
				foreach (PropertyInfo runtimeProperty in values.GetType().GetRuntimeProperties())
				{
					string value = runtimeProperty.GetValue(values) as string;
					if (!string.IsNullOrEmpty(value))
					{
						dictionary.Add(runtimeProperty.Name, value);
					}
				}
			}
			return dictionary;
		}
	}
	public class Auth0ClientOptions
	{
		public IBrowser Browser { get; set; }

		public string ClientId { get; set; }

		[Obsolete("Client Secrets should not be used in non-confidential clients such as native desktop and mobile apps. This property will be removed in a future release.")]
		public string ClientSecret { get; set; }

		public string Domain { get; set; }

		public bool EnableTelemetry { get; set; } = true;

		public bool LoadProfile { get; set; } = true;

		public string Scope { get; set; } = "openid profile email";

		public HttpMessageHandler RefreshTokenMessageHandler { get; set; }

		public HttpMessageHandler BackchannelHandler { get; set; }

		public string PostLogoutRedirectUri { get; set; }

		public string RedirectUri { get; set; }

		public TimeSpan Leeway { get; set; } = TimeSpan.FromMinutes(5.0);

		public TimeSpan? MaxAge { get; set; }
	}
	public interface IAuth0Client
	{
		Task<LoginResult> LoginAsync(object extraParameters = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<BrowserResultType> LogoutAsync(bool federated = false, object extraParameters = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<AuthorizeState> PrepareLoginAsync(object extraParameters = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<LoginResult> ProcessResponseAsync(string data, AuthorizeState state, object extraParameters = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<RefreshTokenResult> RefreshTokenAsync(string refreshToken, object extraParameters = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<UserInfoResult> GetUserInfoAsync(string accessToken);
	}
}
namespace Auth0.OidcClient.Tokens
{
	internal class AsymmetricSignatureVerifier : ISignatureVerifier
	{
		private readonly IList<JsonWebKey> keys;

		public static async Task<AsymmetricSignatureVerifier> ForJwks(string issuer)
		{
			return new AsymmetricSignatureVerifier((await JsonWebKeys.GetForIssuer(issuer)).Keys);
		}

		public AsymmetricSignatureVerifier(IList<JsonWebKey> keys)
		{
			this.keys = keys;
		}

		public JwtSecurityToken VerifySignature(string token)
		{
			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			JwtSecurityToken jwtSecurityToken;
			try
			{
				jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(token);
			}
			catch (ArgumentException innerException)
			{
				throw new IdTokenValidationException("ID token could not be decoded.", innerException);
			}
			if (jwtSecurityToken.SignatureAlgorithm != "RS256")
			{
				throw new IdTokenValidationException("Signature algorithm of \"" + jwtSecurityToken.Header.Alg + "\" is not supported. Expected the ID token to be signed with \"RS256\".");
			}
			return (JwtSecurityToken)ValidateTokenSignature(token, jwtSecurityTokenHandler, jwtSecurityToken.Header.Kid);
		}

		internal SecurityToken ValidateTokenSignature(string token, JwtSecurityTokenHandler securityTokenHandler, string kid)
		{
			try
			{
				TokenValidationParameters validationParameters = new TokenValidationParameters
				{
					ValidateAudience = false,
					ValidateIssuer = false,
					ValidateActor = false,
					ValidateLifetime = false,
					ValidateTokenReplay = false,
					RequireSignedTokens = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKeys = keys
				};
				securityTokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
				return validatedToken;
			}
			catch (SecurityTokenSignatureKeyNotFoundException)
			{
				throw new IdTokenValidationException("Could not find a public key for Key ID (kid) \"" + kid + "\".");
			}
			catch (SecurityTokenException innerException)
			{
				throw new IdTokenValidationException("Invalid token signature.", innerException);
			}
		}
	}
	internal class IdTokenRequirements
	{
		public string Issuer;

		public string Audience;

		public string Nonce;

		public TimeSpan? MaxAge;

		public TimeSpan Leeway;

		public IdTokenRequirements(string issuer, string audience, TimeSpan leeway, TimeSpan? maxAge = null)
		{
			Issuer = issuer;
			Audience = audience;
			Leeway = leeway;
			MaxAge = maxAge;
		}
	}
	public class IdTokenValidationException : Exception
	{
		public IdTokenValidationException()
		{
		}

		public IdTokenValidationException(string message)
			: base(message)
		{
		}

		public IdTokenValidationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected IdTokenValidationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	internal static class IdTokenValidator
	{
		internal static async Task AssertTokenMeetsRequirements(this IdTokenRequirements required, string rawIDToken, DateTime? pointInTime = null, ISignatureVerifier signatureVerifier = null)
		{
			if (string.IsNullOrWhiteSpace(rawIDToken))
			{
				throw new IdTokenValidationException("ID token is required but missing.");
			}
			JwtSecurityToken token = DecodeToken(rawIDToken);
			if (token.SignatureAlgorithm != "HS256")
			{
				ISignatureVerifier signatureVerifier2 = signatureVerifier;
				if (signatureVerifier2 == null)
				{
					signatureVerifier2 = await AsymmetricSignatureVerifier.ForJwks(required.Issuer);
				}
				signatureVerifier2.VerifySignature(rawIDToken);
			}
			AssertTokenClaimsMeetRequirements(required, token, pointInTime ?? DateTime.Now);
		}

		private static JwtSecurityToken DecodeToken(string rawIDToken)
		{
			try
			{
				return new JwtSecurityTokenHandler().ReadJwtToken(rawIDToken);
			}
			catch (ArgumentException innerException)
			{
				throw new IdTokenValidationException("ID token could not be decoded.", innerException);
			}
		}

		private static void AssertTokenClaimsMeetRequirements(IdTokenRequirements required, JwtSecurityToken token, DateTime pointInTime)
		{
			long intDate = EpochTime.GetIntDate(pointInTime);
			if (string.IsNullOrWhiteSpace(token.Issuer))
			{
				throw new IdTokenValidationException("Issuer (iss) claim must be a string present in the ID token.");
			}
			if (token.Issuer != required.Issuer)
			{
				throw new IdTokenValidationException("Issuer (iss) claim mismatch in the ID token; expected \"" + required.Issuer + "\", found \"" + token.Issuer + "\".");
			}
			if (string.IsNullOrWhiteSpace(token.Subject))
			{
				throw new IdTokenValidationException("Subject (sub) claim must be a string present in the ID token.");
			}
			int num = token.Audiences.Count();
			if (num == 0)
			{
				throw new IdTokenValidationException("Audience (aud) claim must be a string or array of strings present in the ID token.");
			}
			if (!token.Audiences.Contains(required.Audience))
			{
				throw new IdTokenValidationException("Audience (aud) claim mismatch in the ID token; expected \"" + required.Audience + "\" but was not one of \"" + string.Join(", ", token.Audiences) + "\".");
			}
			long? epoch = GetEpoch(token.Claims, "exp");
			if (!epoch.HasValue)
			{
				throw new IdTokenValidationException("Expiration Time (exp) claim must be an integer present in the ID token.");
			}
			if ((double)intDate >= (double?)epoch + required.Leeway.TotalSeconds)
			{
				throw new IdTokenValidationException($"Expiration Time (exp) claim error in the ID token; current time ({intDate}) is after expiration time ({epoch}).");
			}
			if (!GetEpoch(token.Claims, "iat").HasValue)
			{
				throw new IdTokenValidationException("Issued At (iat) claim must be an integer present in the ID token.");
			}
			if (required.Nonce != null)
			{
				if (string.IsNullOrWhiteSpace(token.Payload.Nonce))
				{
					throw new IdTokenValidationException("Nonce (nonce) claim must be a string present in the ID token.");
				}
				if (token.Payload.Nonce != required.Nonce)
				{
					throw new IdTokenValidationException("Nonce (nonce) claim mismatch in the ID token; expected \"" + required.Nonce + "\", found \"" + token.Payload.Nonce + "\".");
				}
			}
			if (num > 1)
			{
				if (string.IsNullOrWhiteSpace(token.Payload.Azp))
				{
					throw new IdTokenValidationException("Authorized Party (azp) claim must be a string present in the ID token when Audiences (aud) claim has multiple values.");
				}
				if (token.Payload.Azp != required.Audience)
				{
					throw new IdTokenValidationException("Authorized Party (azp) claim mismatch in the ID token; expected \"" + required.Audience + "\", found \"" + token.Payload.Azp + "\".");
				}
			}
			if (required.MaxAge.HasValue)
			{
				long? epoch2 = GetEpoch(token.Claims, "auth_time");
				if (!epoch2.HasValue)
				{
					throw new IdTokenValidationException("Authentication Time (auth_time) claim must be an integer present in the ID token when MaxAge specified.");
				}
				long num2 = (long)((double?)epoch2 + required.MaxAge.Value.TotalSeconds + required.Leeway.TotalSeconds).Value;
				if (intDate > num2)
				{
					throw new IdTokenValidationException($"Authentication Time (auth_time) claim in the ID token indicates that too much time has passed since the last end-user authentication. Current time ({intDate}) is after last auth at {num2}.");
				}
			}
		}

		private static long? GetEpoch(IEnumerable<Claim> claims, string claimType)
		{
			Claim claim = claims.FirstOrDefault((Claim t) => t.Type == claimType);
			if (claim == null)
			{
				return null;
			}
			return (long)Convert.ToDouble(claim.Value, CultureInfo.InvariantCulture);
		}
	}
	internal interface ISignatureVerifier
	{
		JwtSecurityToken VerifySignature(string token);
	}
	internal static class JsonWebKeys
	{
		public static async Task<JsonWebKeySet> GetForIssuer(string issuer)
		{
			return (await GetOpenIdConfiguration(new UriBuilder(issuer)
			{
				Path = "/.well-known/openid-configuration"
			}.Uri.OriginalString)).JsonWebKeySet;
		}

		private static Task<OpenIdConnectConfiguration> GetOpenIdConfiguration(string metadataAddress)
		{
			try
			{
				return new ConfigurationManager<OpenIdConnectConfiguration>(metadataAddress, new OpenIdConnectConfigurationRetriever()).GetConfigurationAsync();
			}
			catch (Exception innerException)
			{
				throw new IdTokenValidationException("Unable to retrieve public keys from \"$" + metadataAddress + "\".", innerException);
			}
		}
	}
}
