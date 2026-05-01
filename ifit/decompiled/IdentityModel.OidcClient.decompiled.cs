using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using IdentityModel.Jwk;
using IdentityModel.OidcClient.Browser;
using IdentityModel.OidcClient.Infrastructure;
using IdentityModel.OidcClient.Results;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("IdentityModel.OidcClient.Tests, PublicKey = 00240000048000009400000006020000002400005253413100040000010001008b4800109486e0cc76fda47b4467e7f3d9e18c2f59233ed35ab7d1000a38a73e436d73a20d02dbcc124ce63a8d93b9a4efb48c0ca922b3a9888d2757d7eb95e4217f3df14fdd393b03f93876777bcb57c824f20c3bb4e9580ed5a54c09d33295d23b096399b8fa32f6201a1062b8b6796b608c79df0ce733350b8dc3a7b7a6cb")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Dominick Baier;Brock Allen")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("RFC8252 compliant and certified OpenID Connect and OAuth 2.0 client library for native applications")]
[assembly: AssemblyFileVersion("3.1.2.0")]
[assembly: AssemblyInformationalVersion("3.1.2+de3c5ee430995d821ac51103b9577ea08cd8bfe9")]
[assembly: AssemblyProduct("IdentityModel.OidcClient")]
[assembly: AssemblyTitle("IdentityModel.OidcClient")]
[assembly: AssemblyVersion("3.0.0.0")]
namespace IdentityModel.OidcClient
{
	internal class AuthorizeClient
	{
		private readonly CryptoHelper _crypto;

		private readonly ILogger<AuthorizeClient> _logger;

		private readonly OidcClientOptions _options;

		public AuthorizeClient(OidcClientOptions options)
		{
			_options = options;
			_logger = options.LoggerFactory.CreateLogger<AuthorizeClient>();
			_crypto = new CryptoHelper(options);
		}

		public async Task<AuthorizeResult> AuthorizeAsync(AuthorizeRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			_logger.LogTrace("AuthorizeAsync");
			if (_options.Browser == null)
			{
				throw new InvalidOperationException("No browser configured.");
			}
			AuthorizeResult result = new AuthorizeResult
			{
				State = CreateAuthorizeState(request.ExtraParameters)
			};
			BrowserOptions browserOptions = new BrowserOptions(result.State.StartUrl, _options.RedirectUri)
			{
				Timeout = TimeSpan.FromSeconds(request.Timeout),
				DisplayMode = request.DisplayMode
			};
			if (_options.ResponseMode == OidcClientOptions.AuthorizeResponseMode.FormPost)
			{
				browserOptions.ResponseMode = OidcClientOptions.AuthorizeResponseMode.FormPost;
			}
			else
			{
				browserOptions.ResponseMode = OidcClientOptions.AuthorizeResponseMode.Redirect;
			}
			BrowserResult browserResult = await _options.Browser.InvokeAsync(browserOptions, cancellationToken);
			if (browserResult.ResultType == BrowserResultType.Success)
			{
				result.Data = browserResult.Response;
				return result;
			}
			result.Error = browserResult.Error ?? browserResult.ResultType.ToString();
			return result;
		}

		public async Task<BrowserResult> EndSessionAsync(LogoutRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			string endSessionEndpoint = _options.ProviderInformation.EndSessionEndpoint;
			if (endSessionEndpoint.IsMissing())
			{
				throw new InvalidOperationException("Discovery document has no end session endpoint");
			}
			BrowserOptions options = new BrowserOptions(CreateEndSessionUrl(endSessionEndpoint, request), _options.PostLogoutRedirectUri ?? string.Empty)
			{
				Timeout = TimeSpan.FromSeconds(request.BrowserTimeout),
				DisplayMode = request.BrowserDisplayMode
			};
			return await _options.Browser.InvokeAsync(options, cancellationToken);
		}

		public AuthorizeState CreateAuthorizeState(IDictionary<string, string> extraParameters = null)
		{
			_logger.LogTrace("CreateAuthorizeStateAsync");
			CryptoHelper.Pkce pkce = _crypto.CreatePkceData();
			AuthorizeState authorizeState = new AuthorizeState
			{
				Nonce = _crypto.CreateNonce(),
				State = _crypto.CreateState(),
				RedirectUri = _options.RedirectUri,
				CodeVerifier = pkce.CodeVerifier
			};
			authorizeState.StartUrl = CreateAuthorizeUrl(authorizeState.State, authorizeState.Nonce, pkce.CodeChallenge, extraParameters);
			_logger.LogDebug(LogSerializer.Serialize(authorizeState));
			return authorizeState;
		}

		internal string CreateAuthorizeUrl(string state, string nonce, string codeChallenge, IDictionary<string, string> extraParameters)
		{
			_logger.LogTrace("CreateAuthorizeUrl");
			Dictionary<string, string> values = CreateAuthorizeParameters(state, nonce, codeChallenge, extraParameters);
			return new RequestUrl(_options.ProviderInformation.AuthorizeEndpoint).Create(values);
		}

		internal string CreateEndSessionUrl(string endpoint, LogoutRequest request)
		{
			_logger.LogTrace("CreateEndSessionUrl");
			return new RequestUrl(endpoint).CreateEndSessionUrl(request.IdTokenHint, _options.PostLogoutRedirectUri);
		}

		internal Dictionary<string, string> CreateAuthorizeParameters(string state, string nonce, string codeChallenge, IDictionary<string, string> extraParameters)
		{
			_logger.LogTrace("CreateAuthorizeParameters");
			string text = null;
			text = _options.Flow switch
			{
				OidcClientOptions.AuthenticationFlow.AuthorizationCode => "code", 
				OidcClientOptions.AuthenticationFlow.Hybrid => "code id_token", 
				_ => throw new ArgumentOutOfRangeException("Flow", "Unsupported authentication flow"), 
			};
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				{ "response_type", text },
				{ "nonce", nonce },
				{ "state", state },
				{ "code_challenge", codeChallenge },
				{ "code_challenge_method", "S256" }
			};
			if (_options.ClientId.IsPresent())
			{
				dictionary.Add("client_id", _options.ClientId);
			}
			if (_options.Scope.IsPresent())
			{
				dictionary.Add("scope", _options.Scope);
			}
			if (_options.RedirectUri.IsPresent())
			{
				dictionary.Add("redirect_uri", _options.RedirectUri);
			}
			if (_options.ResponseMode == OidcClientOptions.AuthorizeResponseMode.FormPost)
			{
				dictionary.Add("response_mode", "form_post");
			}
			if (extraParameters != null)
			{
				foreach (KeyValuePair<string, string> extraParameter in extraParameters)
				{
					if (!string.IsNullOrWhiteSpace(extraParameter.Value))
					{
						if (dictionary.ContainsKey(extraParameter.Key))
						{
							dictionary[extraParameter.Key] = extraParameter.Value;
						}
						else
						{
							dictionary.Add(extraParameter.Key, extraParameter.Value);
						}
					}
				}
			}
			return dictionary;
		}
	}
	public class AuthorizeState
	{
		public string StartUrl { get; set; }

		public string Nonce { get; set; }

		public string State { get; set; }

		public string CodeVerifier { get; set; }

		public string RedirectUri { get; set; }
	}
	internal class CryptoHelper
	{
		internal class Pkce
		{
			public string CodeVerifier { get; set; }

			public string CodeChallenge { get; set; }
		}

		private readonly ILogger _logger;

		private readonly OidcClientOptions _options;

		public CryptoHelper(OidcClientOptions options)
		{
			_options = options;
			_logger = options.LoggerFactory.CreateLogger<CryptoHelper>();
		}

		public HashAlgorithm GetMatchingHashAlgorithm(string signatureAlgorithm)
		{
			_logger.LogTrace("GetMatchingHashAlgorithm");
			_logger.LogDebug("Determining matching hash algorithm for {signatureAlgorithm}", signatureAlgorithm);
			switch (int.Parse(signatureAlgorithm.Substring(signatureAlgorithm.Length - 3)))
			{
			case 256:
				_logger.LogDebug("SHA256");
				return SHA256.Create();
			case 384:
				_logger.LogDebug("SHA384");
				return SHA384.Create();
			case 512:
				_logger.LogDebug("SHA512");
				return SHA512.Create();
			default:
				return null;
			}
		}

		public bool ValidateHash(string data, string hashedData, string signatureAlgorithm)
		{
			_logger.LogTrace("ValidateHash");
			HashAlgorithm matchingHashAlgorithm = GetMatchingHashAlgorithm(signatureAlgorithm);
			if (matchingHashAlgorithm == null)
			{
				_logger.LogError("No appropriate hashing algorithm found.");
			}
			using (matchingHashAlgorithm)
			{
				byte[] sourceArray = matchingHashAlgorithm.ComputeHash(Encoding.ASCII.GetBytes(data));
				int num = matchingHashAlgorithm.HashSize / 8 / 2;
				byte[] array = new byte[matchingHashAlgorithm.HashSize / num];
				Array.Copy(sourceArray, array, matchingHashAlgorithm.HashSize / num);
				string text = Base64Url.Encode(array);
				bool flag = text.Equals(hashedData);
				if (!flag)
				{
					_logger.LogError("data (" + text + ") does not match hash from token (" + hashedData + ")");
				}
				return flag;
			}
		}

		public string CreateState()
		{
			_logger.LogTrace("CreateState");
			return CryptoRandom.CreateUniqueId(16);
		}

		public string CreateNonce()
		{
			_logger.LogTrace("CreateNonce");
			return CryptoRandom.CreateUniqueId(16);
		}

		public Pkce CreatePkceData()
		{
			_logger.LogTrace("CreatePkceData");
			Pkce pkce = new Pkce
			{
				CodeVerifier = CryptoRandom.CreateUniqueId()
			};
			using SHA256 sHA = SHA256.Create();
			byte[] arg = sHA.ComputeHash(Encoding.UTF8.GetBytes(pkce.CodeVerifier));
			pkce.CodeChallenge = Base64Url.Encode(arg);
			return pkce;
		}
	}
	internal class IdentityTokenValidator
	{
		private readonly ILogger _logger;

		private readonly OidcClientOptions _options;

		private readonly Func<CancellationToken, Task> _refreshKeysAsync;

		public IdentityTokenValidator(OidcClientOptions options, Func<CancellationToken, Task> refreshKeysAsync)
		{
			_options = options;
			_logger = options.LoggerFactory.CreateLogger<IdentityTokenValidator>();
			_refreshKeysAsync = refreshKeysAsync;
		}

		public async Task<IdentityTokenValidationResult> ValidateAsync(string identityToken, CancellationToken cancellationToken = default(CancellationToken))
		{
			_logger.LogTrace("Validate");
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			handler.InboundClaimTypeMap.Clear();
			TokenValidationParameters parameters = new TokenValidationParameters
			{
				ValidIssuer = _options.ProviderInformation.IssuerName,
				ValidAudience = _options.ClientId,
				ValidateIssuer = _options.Policy.ValidateTokenIssuerName,
				NameClaimType = "name",
				RoleClaimType = "role",
				ClockSkew = _options.ClockSkew
			};
			JwtSecurityToken jwtSecurityToken;
			try
			{
				jwtSecurityToken = handler.ReadJwtToken(identityToken);
			}
			catch (Exception ex)
			{
				return new IdentityTokenValidationResult
				{
					Error = "Error validating identity token: " + ex.ToString()
				};
			}
			string algorithm = jwtSecurityToken.Header.Alg;
			if (string.Equals(algorithm, "none"))
			{
				if (_options.Policy.RequireIdentityTokenSignature)
				{
					return new IdentityTokenValidationResult
					{
						Error = "Identity token is not singed. Signatures are required by policy"
					};
				}
				_logger.LogInformation("Identity token is not signed. This is allowed by configuration.");
				parameters.RequireSignedTokens = false;
			}
			else if (!_options.Policy.ValidSignatureAlgorithms.Contains(algorithm))
			{
				return new IdentityTokenValidationResult
				{
					Error = "Identity token uses invalid algorithm: " + algorithm
				};
			}
			ClaimsPrincipal user;
			try
			{
				user = ValidateSignature(identityToken, handler, parameters);
			}
			catch (SecurityTokenSignatureKeyNotFoundException ex2)
			{
				if (!_options.RefreshDiscoveryOnSignatureFailure)
				{
					return new IdentityTokenValidationResult
					{
						Error = "Error validating identity token: " + ex2.ToString()
					};
				}
				_logger.LogWarning("Key for validating token signature cannot be found. Refreshing keyset.");
				await _refreshKeysAsync(cancellationToken);
				try
				{
					user = ValidateSignature(identityToken, handler, parameters);
				}
				catch (Exception ex3)
				{
					return new IdentityTokenValidationResult
					{
						Error = "Error validating identity token: " + ex3.ToString()
					};
				}
			}
			catch (Exception ex4)
			{
				return new IdentityTokenValidationResult
				{
					Error = "Error validating identity token: " + ex4.ToString()
				};
			}
			string text = CheckRequiredClaim(user);
			if (text.IsPresent())
			{
				return new IdentityTokenValidationResult
				{
					Error = text
				};
			}
			return new IdentityTokenValidationResult
			{
				User = user,
				SignatureAlgorithm = algorithm
			};
		}

		private ClaimsPrincipal ValidateSignature(string identityToken, JwtSecurityTokenHandler handler, TokenValidationParameters parameters)
		{
			if (parameters.RequireSignedTokens)
			{
				List<SecurityKey> list = new List<SecurityKey>();
				foreach (IdentityModel.Jwk.JsonWebKey key in _options.ProviderInformation.KeySet.Keys)
				{
					if (key.E.IsPresent() && key.N.IsPresent())
					{
						if (key.Use == "sig" || key.Use == null)
						{
							byte[] exponent = Base64Url.Decode(key.E);
							byte[] modulus = Base64Url.Decode(key.N);
							RsaSecurityKey rsaSecurityKey = new RsaSecurityKey(new RSAParameters
							{
								Exponent = exponent,
								Modulus = modulus
							});
							rsaSecurityKey.KeyId = key.Kid;
							list.Add(rsaSecurityKey);
							_logger.LogDebug("Added signing key with kid: {kid}", rsaSecurityKey?.KeyId ?? "not set");
						}
					}
					else if (key.X.IsPresent() && key.Y.IsPresent() && key.Crv.IsPresent())
					{
						ECDsaSecurityKey eCDsaSecurityKey = new ECDsaSecurityKey(ECDsa.Create(new ECParameters
						{
							Curve = GetCurveFromCrvValue(key.Crv),
							Q = new ECPoint
							{
								X = Base64Url.Decode(key.X),
								Y = Base64Url.Decode(key.Y)
							}
						}));
						eCDsaSecurityKey.KeyId = key.Kid;
						list.Add(eCDsaSecurityKey);
					}
					else
					{
						_logger.LogDebug("Signing key with kid: {kid} currently not supported", key.Kid ?? "not set");
					}
				}
				parameters.IssuerSigningKeys = list;
			}
			SecurityToken validatedToken;
			return handler.ValidateToken(identityToken, parameters, out validatedToken);
		}

		private string CheckRequiredClaim(ClaimsPrincipal user)
		{
			foreach (string item in new List<string> { "iss", "sub", "iat", "aud", "exp" })
			{
				if (user.FindFirst(item) == null)
				{
					return item + " claim is missing";
				}
			}
			return null;
		}

		internal static ECCurve GetCurveFromCrvValue(string crv)
		{
			return crv switch
			{
				"P-256" => ECCurve.NamedCurves.nistP256, 
				"P-384" => ECCurve.NamedCurves.nistP384, 
				"P-521" => ECCurve.NamedCurves.nistP521, 
				_ => throw new InvalidOperationException("Unsupported curve type of " + crv), 
			};
		}
	}
	internal static class LoggingExtensions
	{
		[DebuggerStepThrough]
		public static void LogClaims(this ILogger logger, IEnumerable<Claim> claims)
		{
			foreach (Claim claim in claims)
			{
				logger.LogDebug("Claim: " + claim.Type + ": " + claim.Value);
			}
		}

		[DebuggerStepThrough]
		public static void LogClaims(this ILogger logger, ClaimsPrincipal user)
		{
			logger.LogClaims(user.Claims);
		}
	}
	internal static class StringExtensions
	{
		[DebuggerStepThrough]
		public static string EnsureTrailingSlash(this string input)
		{
			if (!input.EndsWith("/"))
			{
				return input + "/";
			}
			return input;
		}

		[DebuggerStepThrough]
		public static bool IsMissing(this string value)
		{
			return string.IsNullOrWhiteSpace(value);
		}

		[DebuggerStepThrough]
		public static bool IsPresent(this string value)
		{
			return !string.IsNullOrWhiteSpace(value);
		}
	}
	public class OidcClient
	{
		private readonly ILogger _logger;

		private readonly AuthorizeClient _authorizeClient;

		private readonly bool useDiscovery;

		private readonly ResponseProcessor _processor;

		public OidcClientOptions Options { get; private set; }

		public OidcClient(OidcClientOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (options.ProviderInformation == null)
			{
				if (options.Authority.IsMissing())
				{
					throw new ArgumentException("No authority specified", "Authority");
				}
				useDiscovery = true;
			}
			Options = options;
			_logger = options.LoggerFactory.CreateLogger<OidcClient>();
			_authorizeClient = new AuthorizeClient(options);
			_processor = new ResponseProcessor(options, EnsureProviderInformationAsync);
		}

		public virtual async Task<LoginResult> LoginAsync(LoginRequest request = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			_logger.LogTrace("LoginAsync");
			_logger.LogInformation("Starting authentication request.");
			if (request == null)
			{
				request = new LoginRequest();
			}
			await EnsureConfigurationAsync(cancellationToken);
			AuthorizeResult authorizeResult = await _authorizeClient.AuthorizeAsync(new AuthorizeRequest
			{
				DisplayMode = request.BrowserDisplayMode,
				Timeout = request.BrowserTimeout,
				ExtraParameters = request.FrontChannelExtraParameters
			}, cancellationToken);
			if (authorizeResult.IsError)
			{
				return new LoginResult(authorizeResult.Error);
			}
			LoginResult obj = await ProcessResponseAsync(authorizeResult.Data, authorizeResult.State, request.BackChannelExtraParameters, cancellationToken);
			if (!obj.IsError)
			{
				_logger.LogInformation("Authentication request success.");
			}
			return obj;
		}

		public virtual async Task<string> PrepareLogoutAsync(LogoutRequest request = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			await EnsureConfigurationAsync(cancellationToken);
			string endSessionEndpoint = Options.ProviderInformation.EndSessionEndpoint;
			if (endSessionEndpoint.IsMissing())
			{
				throw new InvalidOperationException("Discovery document has no end session endpoint");
			}
			return _authorizeClient.CreateEndSessionUrl(endSessionEndpoint, request);
		}

		public virtual async Task<LogoutResult> LogoutAsync(LogoutRequest request = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (request == null)
			{
				request = new LogoutRequest();
			}
			await EnsureConfigurationAsync(cancellationToken);
			BrowserResult browserResult = await _authorizeClient.EndSessionAsync(request, cancellationToken);
			if (browserResult.ResultType != BrowserResultType.Success)
			{
				return new LogoutResult(browserResult.ResultType.ToString())
				{
					Response = browserResult.Response
				};
			}
			return new LogoutResult
			{
				Response = browserResult.Response
			};
		}

		public virtual async Task<AuthorizeState> PrepareLoginAsync(IDictionary<string, string> extraParameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			_logger.LogTrace("PrepareLoginAsync");
			await EnsureConfigurationAsync(cancellationToken);
			return _authorizeClient.CreateAuthorizeState(extraParameters);
		}

		public virtual async Task<LoginResult> ProcessResponseAsync(string data, AuthorizeState state, IDictionary<string, string> extraParameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			_logger.LogTrace("ProcessResponseAsync");
			_logger.LogInformation("Processing response.");
			await EnsureConfigurationAsync(cancellationToken);
			_logger.LogDebug("Authorize response: {response}", data);
			AuthorizeResponse authorizeResponse = new AuthorizeResponse(data);
			if (authorizeResponse.IsError)
			{
				_logger.LogError(authorizeResponse.Error);
				return new LoginResult(authorizeResponse.Error);
			}
			ResponseValidationResult result = await _processor.ProcessResponseAsync(authorizeResponse, state, extraParameters, cancellationToken);
			if (result.IsError)
			{
				_logger.LogError(result.Error);
				return new LoginResult(result.Error);
			}
			IEnumerable<Claim> enumerable = Enumerable.Empty<Claim>();
			if (Options.LoadProfile)
			{
				UserInfoResult userInfoResult = await GetUserInfoAsync(result.TokenResponse.AccessToken, cancellationToken);
				if (userInfoResult.IsError)
				{
					string text = "Error contacting userinfo endpoint: " + userInfoResult.Error;
					_logger.LogError(text);
					return new LoginResult(text);
				}
				enumerable = userInfoResult.Claims;
				Claim claim = enumerable.FirstOrDefault((Claim c) => c.Type == "sub");
				if (claim == null)
				{
					string text2 = "sub claim is missing from userinfo endpoint";
					_logger.LogError(text2);
					return new LoginResult(text2);
				}
				if (!string.Equals(claim.Value, result.User.FindFirst("sub").Value))
				{
					string text3 = "sub claim from userinfo endpoint is different than sub claim from identity token.";
					_logger.LogError(text3);
					return new LoginResult(text3);
				}
			}
			ClaimsPrincipal user = ProcessClaims(result.User, enumerable);
			LoginResult loginResult = new LoginResult
			{
				User = user,
				AccessToken = result.TokenResponse.AccessToken,
				RefreshToken = result.TokenResponse.RefreshToken,
				AccessTokenExpiration = DateTime.Now.AddSeconds(result.TokenResponse.ExpiresIn),
				IdentityToken = result.TokenResponse.IdentityToken,
				AuthenticationTime = DateTime.Now,
				TokenResponse = result.TokenResponse
			};
			if (loginResult.RefreshToken.IsPresent())
			{
				loginResult.RefreshTokenHandler = new RefreshTokenDelegatingHandler(this, loginResult.AccessToken, loginResult.RefreshToken, Options.RefreshTokenInnerHttpHandler);
			}
			return loginResult;
		}

		public virtual async Task<UserInfoResult> GetUserInfoAsync(string accessToken, CancellationToken cancellationToken = default(CancellationToken))
		{
			_logger.LogTrace("GetUserInfoAsync");
			await EnsureConfigurationAsync(cancellationToken);
			if (accessToken.IsMissing())
			{
				throw new ArgumentNullException("accessToken");
			}
			if (!Options.ProviderInformation.SupportsUserInfo)
			{
				throw new InvalidOperationException("No userinfo endpoint specified");
			}
			UserInfoResponse userInfoResponse = await Options.CreateClient().GetUserInfoAsync(new UserInfoRequest
			{
				Address = Options.ProviderInformation.UserInfoEndpoint,
				Token = accessToken
			}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (userInfoResponse.IsError)
			{
				return new UserInfoResult
				{
					Error = userInfoResponse.Error
				};
			}
			return new UserInfoResult
			{
				Claims = userInfoResponse.Claims
			};
		}

		public virtual async Task<RefreshTokenResult> RefreshTokenAsync(string refreshToken, IDictionary<string, string> extraParameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			_logger.LogTrace("RefreshTokenAsync");
			await EnsureConfigurationAsync(cancellationToken);
			TokenResponse response = await Options.CreateClient().RequestRefreshTokenAsync(new RefreshTokenRequest
			{
				Address = Options.ProviderInformation.TokenEndpoint,
				ClientId = Options.ClientId,
				ClientSecret = Options.ClientSecret,
				ClientCredentialStyle = Options.TokenClientCredentialStyle,
				RefreshToken = refreshToken,
				Parameters = (extraParameters ?? new Dictionary<string, string>())
			}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (response.IsError)
			{
				return new RefreshTokenResult
				{
					Error = response.Error
				};
			}
			TokenResponseValidationResult tokenResponseValidationResult = await _processor.ValidateTokenResponseAsync(response, null, Options.Policy.RequireIdentityTokenOnRefreshTokenResponse, cancellationToken);
			if (tokenResponseValidationResult.IsError)
			{
				return new RefreshTokenResult
				{
					Error = tokenResponseValidationResult.Error
				};
			}
			return new RefreshTokenResult
			{
				IdentityToken = response.IdentityToken,
				AccessToken = response.AccessToken,
				RefreshToken = response.RefreshToken,
				ExpiresIn = response.ExpiresIn,
				AccessTokenExpiration = DateTime.Now.AddSeconds(response.ExpiresIn)
			};
		}

		internal async Task EnsureConfigurationAsync(CancellationToken cancellationToken)
		{
			if (Options.Flow == OidcClientOptions.AuthenticationFlow.Hybrid && !Options.Policy.RequireIdentityTokenSignature)
			{
				string message = "Allowing unsigned identity tokens is not allowed for hybrid flow";
				_logger.LogError(message);
				throw new InvalidOperationException(message);
			}
			await EnsureProviderInformationAsync(cancellationToken);
			_logger.LogTrace("Effective options:");
			_logger.LogTrace(LogSerializer.Serialize(Options));
		}

		internal async Task EnsureProviderInformationAsync(CancellationToken cancellationToken)
		{
			_logger.LogTrace("EnsureProviderInformation");
			if (useDiscovery)
			{
				if (!Options.RefreshDiscoveryDocumentForLogin && Options.ProviderInformation != null)
				{
					_logger.LogDebug("Skipping refresh of discovery document.");
					return;
				}
				DiscoveryDocumentResponse discoveryDocumentResponse = await Options.CreateClient().GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
				{
					Address = Options.Authority,
					Policy = Options.Policy.Discovery
				}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (discoveryDocumentResponse.IsError)
				{
					_logger.LogError("Error loading discovery document: {errorType} - {error}", discoveryDocumentResponse.ErrorType.ToString(), discoveryDocumentResponse.Error);
					if (discoveryDocumentResponse.ErrorType == ResponseErrorType.Exception)
					{
						throw new InvalidOperationException("Error loading discovery document: " + discoveryDocumentResponse.Error, discoveryDocumentResponse.Exception);
					}
					throw new InvalidOperationException("Error loading discovery document: " + discoveryDocumentResponse.Error);
				}
				_logger.LogDebug("Successfully loaded discovery document");
				_logger.LogDebug("Loaded keyset from {jwks_uri}", discoveryDocumentResponse.JwksUri);
				_logger.LogDebug("Keyset contains the following kids: {kids}", discoveryDocumentResponse.KeySet.Keys.Select((IdentityModel.Jwk.JsonWebKey k) => k.Kid ?? "unspecified"));
				Options.ProviderInformation = new ProviderInformation
				{
					IssuerName = discoveryDocumentResponse.Issuer,
					KeySet = discoveryDocumentResponse.KeySet,
					AuthorizeEndpoint = discoveryDocumentResponse.AuthorizeEndpoint,
					TokenEndpoint = discoveryDocumentResponse.TokenEndpoint,
					EndSessionEndpoint = discoveryDocumentResponse.EndSessionEndpoint,
					UserInfoEndpoint = discoveryDocumentResponse.UserInfoEndpoint,
					TokenEndPointAuthenticationMethods = discoveryDocumentResponse.TokenEndpointAuthenticationMethodsSupported
				};
			}
			if (Options.ProviderInformation.IssuerName.IsMissing())
			{
				string message = "Issuer name is missing in provider information";
				_logger.LogError(message);
				throw new InvalidOperationException(message);
			}
			if (Options.ProviderInformation.AuthorizeEndpoint.IsMissing())
			{
				string message2 = "Authorize endpoint is missing in provider information";
				_logger.LogError(message2);
				throw new InvalidOperationException(message2);
			}
			if (Options.ProviderInformation.TokenEndpoint.IsMissing())
			{
				string message3 = "Token endpoint is missing in provider information";
				_logger.LogError(message3);
				throw new InvalidOperationException(message3);
			}
			if (Options.ProviderInformation.KeySet == null)
			{
				string message4 = "Key set is missing in provider information";
				_logger.LogError(message4);
				throw new InvalidOperationException(message4);
			}
		}

		internal ClaimsPrincipal ProcessClaims(ClaimsPrincipal user, IEnumerable<Claim> userInfoClaims)
		{
			_logger.LogTrace("ProcessClaims");
			HashSet<Claim> combinedClaims = new HashSet<Claim>(new ClaimComparer(new ClaimComparer.Options
			{
				IgnoreIssuer = true
			}));
			user.Claims.ToList().ForEach(delegate(Claim c)
			{
				combinedClaims.Add(c);
			});
			userInfoClaims.ToList().ForEach(delegate(Claim c)
			{
				combinedClaims.Add(c);
			});
			List<Claim> list = new List<Claim>();
			list = ((!Options.FilterClaims) ? combinedClaims.ToList() : combinedClaims.Where((Claim c) => !Options.FilteredClaims.Contains(c.Type)).ToList());
			return new ClaimsPrincipal(new ClaimsIdentity(list, user.Identity.AuthenticationType, user.Identities.First().NameClaimType, user.Identities.First().RoleClaimType));
		}
	}
	public class OidcClientOptions
	{
		public enum AuthenticationFlow
		{
			AuthorizationCode,
			Hybrid
		}

		public enum AuthorizeResponseMode
		{
			FormPost,
			Redirect
		}

		public string Authority { get; set; }

		public ProviderInformation ProviderInformation { get; set; }

		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		public string Scope { get; set; }

		public string RedirectUri { get; set; }

		public string PostLogoutRedirectUri { get; set; }

		[JsonIgnore]
		public IBrowser Browser { get; set; }

		public TimeSpan BrowserTimeout { get; set; }

		public TimeSpan ClockSkew { get; set; } = TimeSpan.FromMinutes(5.0);

		public bool RefreshDiscoveryDocumentForLogin { get; set; } = true;

		public bool RefreshDiscoveryOnSignatureFailure { get; set; }

		public AuthorizeResponseMode ResponseMode { get; set; } = AuthorizeResponseMode.Redirect;

		public bool LoadProfile { get; set; } = true;

		public bool FilterClaims { get; set; } = true;

		public AuthenticationFlow Flow { get; set; }

		[JsonIgnore]
		public HttpMessageHandler RefreshTokenInnerHttpHandler { get; set; }

		[JsonIgnore]
		public HttpMessageHandler BackchannelHandler { get; set; }

		public TimeSpan BackchannelTimeout { get; set; } = TimeSpan.FromSeconds(30.0);

		public ClientCredentialStyle TokenClientCredentialStyle { get; set; } = ClientCredentialStyle.PostBody;

		public Policy Policy { get; set; } = new Policy();

		[JsonIgnore]
		public ILoggerFactory LoggerFactory { get; } = new LoggerFactory();

		public ICollection<string> FilteredClaims { get; set; } = new HashSet<string> { "iss", "exp", "nbf", "aud", "nonce", "iat", "auth_time", "c_hash", "at_hash" };
	}
	public class Policy
	{
		public DiscoveryPolicy Discovery { get; set; } = new DiscoveryPolicy();

		public bool RequireAuthorizationCodeHash { get; set; } = true;

		public bool RequireAccessTokenHash { get; set; }

		public bool RequireIdentityTokenOnRefreshTokenResponse { get; set; }

		public bool RequireIdentityTokenSignature { get; set; } = true;

		public bool ValidateTokenIssuerName { get; set; } = true;

		public ICollection<string> ValidSignatureAlgorithms { get; set; } = new HashSet<string> { "RS256", "RS384", "RS512", "PS256", "PS384", "PS512", "ES256", "PS384", "PS512" };
	}
	public class ProviderInformation
	{
		public string IssuerName { get; set; }

		public IdentityModel.Jwk.JsonWebKeySet KeySet { get; set; }

		public string TokenEndpoint { get; set; }

		public string AuthorizeEndpoint { get; set; }

		public string EndSessionEndpoint { get; set; }

		public string UserInfoEndpoint { get; set; }

		public IEnumerable<string> TokenEndPointAuthenticationMethods { get; set; } = new string[0];

		public bool SupportsUserInfo => UserInfoEndpoint.IsPresent();

		public bool SupportsEndSession => EndSessionEndpoint.IsPresent();
	}
	public class RefreshTokenDelegatingHandler : DelegatingHandler
	{
		private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

		private readonly OidcClient _oidcClient;

		private string _accessToken;

		private string _refreshToken;

		private bool _disposed;

		public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(5.0);

		public string AccessToken
		{
			get
			{
				if (_lock.Wait(Timeout))
				{
					try
					{
						return _accessToken;
					}
					finally
					{
						_lock.Release();
					}
				}
				return null;
			}
		}

		public string RefreshToken
		{
			get
			{
				if (_lock.Wait(Timeout))
				{
					try
					{
						return _refreshToken;
					}
					finally
					{
						_lock.Release();
					}
				}
				return null;
			}
		}

		public event EventHandler<TokenRefreshedEventArgs> TokenRefreshed = delegate
		{
		};

		public RefreshTokenDelegatingHandler(OidcClient oidcClient, string accessToken, string refreshToken, HttpMessageHandler innerHandler = null)
		{
			_oidcClient = oidcClient ?? throw new ArgumentNullException("oidcClient");
			if (refreshToken.IsMissing())
			{
				throw new ArgumentNullException("refreshToken");
			}
			_refreshToken = refreshToken;
			if (accessToken.IsMissing())
			{
				throw new ArgumentNullException("accessToken");
			}
			_accessToken = accessToken;
			if (innerHandler != null)
			{
				base.InnerHandler = innerHandler;
			}
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if ((await GetAccessTokenAsync(cancellationToken)).IsMissing() && !(await RefreshTokensAsync(cancellationToken)))
			{
				return new HttpResponseMessage(HttpStatusCode.Unauthorized)
				{
					RequestMessage = request
				};
			}
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
			HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (response.StatusCode != HttpStatusCode.Unauthorized)
			{
				return response;
			}
			if (!(await RefreshTokensAsync(cancellationToken)))
			{
				return response;
			}
			response.Dispose();
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
			return await base.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				_disposed = true;
				_lock.Dispose();
			}
			base.Dispose(disposing);
		}

		private async Task<bool> RefreshTokensAsync(CancellationToken cancellationToken)
		{
			string refreshToken = RefreshToken;
			if (refreshToken.IsMissing())
			{
				return false;
			}
			if (await _lock.WaitAsync(Timeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				try
				{
					RefreshTokenResult response = await _oidcClient.RefreshTokenAsync(refreshToken, null, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (!response.IsError)
					{
						_accessToken = response.AccessToken;
						if (!response.RefreshToken.IsMissing())
						{
							_refreshToken = response.RefreshToken;
						}
						Task.Run(delegate
						{
							Delegate[] invocationList = this.TokenRefreshed.GetInvocationList();
							for (int i = 0; i < invocationList.Length; i++)
							{
								EventHandler<TokenRefreshedEventArgs> eventHandler = (EventHandler<TokenRefreshedEventArgs>)invocationList[i];
								try
								{
									eventHandler(this, new TokenRefreshedEventArgs(response.AccessToken, response.RefreshToken, response.ExpiresIn));
								}
								catch
								{
								}
							}
						}).ConfigureAwait(continueOnCapturedContext: false);
						return true;
					}
				}
				finally
				{
					_lock.Release();
				}
			}
			return false;
		}

		private async Task<string> GetAccessTokenAsync(CancellationToken cancellationToken)
		{
			if (await _lock.WaitAsync(Timeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				try
				{
					return _accessToken;
				}
				finally
				{
					_lock.Release();
				}
			}
			return null;
		}
	}
	internal class AuthorizeRequest
	{
		public IDictionary<string, string> ExtraParameters = new Dictionary<string, string>();

		public DisplayMode DisplayMode { get; set; }

		public int Timeout { get; set; } = 300;
	}
	public class LoginRequest
	{
		public DisplayMode BrowserDisplayMode { get; set; }

		public int BrowserTimeout { get; set; } = 300;

		public IDictionary<string, string> FrontChannelExtraParameters { get; set; } = new Dictionary<string, string>();

		public IDictionary<string, string> BackChannelExtraParameters { get; set; } = new Dictionary<string, string>();
	}
	public class LogoutRequest
	{
		public DisplayMode BrowserDisplayMode { get; set; }

		public int BrowserTimeout { get; set; } = 300;

		public string IdTokenHint { get; set; }
	}
	internal class ResponseProcessor
	{
		private readonly OidcClientOptions _options;

		private ILogger<ResponseProcessor> _logger;

		private readonly IdentityTokenValidator _tokenValidator;

		private readonly CryptoHelper _crypto;

		private readonly Func<CancellationToken, Task> _refreshKeysAsync;

		public ResponseProcessor(OidcClientOptions options, Func<CancellationToken, Task> refreshKeysAsync)
		{
			_options = options;
			_refreshKeysAsync = refreshKeysAsync;
			_logger = options.LoggerFactory.CreateLogger<ResponseProcessor>();
			_tokenValidator = new IdentityTokenValidator(options, refreshKeysAsync);
			_crypto = new CryptoHelper(options);
		}

		public async Task<ResponseValidationResult> ProcessResponseAsync(AuthorizeResponse authorizeResponse, AuthorizeState state, IDictionary<string, string> extraParameters, CancellationToken cancellationToken = default(CancellationToken))
		{
			_logger.LogTrace("ProcessResponseAsync");
			if (string.IsNullOrEmpty(authorizeResponse.Code))
			{
				return new ResponseValidationResult("Missing authorization code.");
			}
			if (string.IsNullOrEmpty(authorizeResponse.State))
			{
				return new ResponseValidationResult("Missing state.");
			}
			if (!string.Equals(state.State, authorizeResponse.State, StringComparison.Ordinal))
			{
				return new ResponseValidationResult("Invalid state.");
			}
			return _options.Flow switch
			{
				OidcClientOptions.AuthenticationFlow.AuthorizationCode => await ProcessCodeFlowResponseAsync(authorizeResponse, state, extraParameters, cancellationToken), 
				OidcClientOptions.AuthenticationFlow.Hybrid => await ProcessHybridFlowResponseAsync(authorizeResponse, state, extraParameters, cancellationToken), 
				_ => throw new ArgumentOutOfRangeException("Flow", "Invalid authentication style."), 
			};
		}

		private async Task<ResponseValidationResult> ProcessHybridFlowResponseAsync(AuthorizeResponse authorizeResponse, AuthorizeState state, IDictionary<string, string> extraParameters, CancellationToken cancellationToken)
		{
			_logger.LogTrace("ProcessHybridFlowResponseAsync");
			if (authorizeResponse.IdentityToken.IsMissing())
			{
				return new ResponseValidationResult("Missing identity token.");
			}
			IdentityTokenValidationResult frontChannelValidationResult = await _tokenValidator.ValidateAsync(authorizeResponse.IdentityToken, cancellationToken);
			if (frontChannelValidationResult.IsError)
			{
				return new ResponseValidationResult(frontChannelValidationResult.Error ?? "Identity token validation error.");
			}
			if (!ValidateNonce(state.Nonce, frontChannelValidationResult.User))
			{
				return new ResponseValidationResult("Invalid nonce.");
			}
			Claim claim = frontChannelValidationResult.User.FindFirst("c_hash");
			if (claim == null)
			{
				if (_options.Policy.RequireAuthorizationCodeHash)
				{
					return new ResponseValidationResult("c_hash is missing.");
				}
			}
			else if (!_crypto.ValidateHash(authorizeResponse.Code, claim.Value, frontChannelValidationResult.SignatureAlgorithm))
			{
				return new ResponseValidationResult("Invalid c_hash.");
			}
			TokenResponse tokenResponse = await RedeemCodeAsync(authorizeResponse.Code, state, extraParameters, cancellationToken);
			if (tokenResponse.IsError)
			{
				return new ResponseValidationResult(tokenResponse.Error);
			}
			TokenResponseValidationResult tokenResponseValidationResult = await ValidateTokenResponseAsync(tokenResponse, state, requireIdentityToken: true, cancellationToken);
			if (tokenResponseValidationResult.IsError)
			{
				return new ResponseValidationResult(tokenResponseValidationResult.Error);
			}
			string value = frontChannelValidationResult.User.FindFirst("sub").Value;
			string value2 = tokenResponseValidationResult.IdentityTokenValidationResult.User.FindFirst("sub").Value;
			if (!string.Equals(value, value2, StringComparison.Ordinal))
			{
				return new ResponseValidationResult("Subject on front-channel (" + value + ") does not match subject on back-channel (" + value2 + ").");
			}
			return new ResponseValidationResult
			{
				AuthorizeResponse = authorizeResponse,
				TokenResponse = tokenResponse,
				User = tokenResponseValidationResult.IdentityTokenValidationResult.User
			};
		}

		private async Task<ResponseValidationResult> ProcessCodeFlowResponseAsync(AuthorizeResponse authorizeResponse, AuthorizeState state, IDictionary<string, string> extraParameters, CancellationToken cancellationToken)
		{
			_logger.LogTrace("ProcessCodeFlowResponseAsync");
			TokenResponse tokenResponse = await RedeemCodeAsync(authorizeResponse.Code, state, extraParameters, cancellationToken);
			if (tokenResponse.IsError)
			{
				return new ResponseValidationResult("Error redeeming code: " + (tokenResponse.Error ?? "no error code") + " / " + (tokenResponse.ErrorDescription ?? "no description"));
			}
			TokenResponseValidationResult tokenResponseValidationResult = await ValidateTokenResponseAsync(tokenResponse, state, requireIdentityToken: true, cancellationToken);
			if (tokenResponseValidationResult.IsError)
			{
				return new ResponseValidationResult("Error validating token response: " + tokenResponseValidationResult.Error);
			}
			return new ResponseValidationResult
			{
				AuthorizeResponse = authorizeResponse,
				TokenResponse = tokenResponse,
				User = tokenResponseValidationResult.IdentityTokenValidationResult.User
			};
		}

		internal async Task<TokenResponseValidationResult> ValidateTokenResponseAsync(TokenResponse response, AuthorizeState state, bool requireIdentityToken = true, CancellationToken cancellationToken = default(CancellationToken))
		{
			_logger.LogTrace("ValidateTokenResponse");
			if (response.AccessToken.IsMissing())
			{
				return new TokenResponseValidationResult("Access token is missing on token response.");
			}
			if (requireIdentityToken && response.IdentityToken.IsMissing())
			{
				return new TokenResponseValidationResult("Identity token is missing on token response.");
			}
			if (response.IdentityToken.IsPresent())
			{
				IdentityTokenValidationResult identityTokenValidationResult = await _tokenValidator.ValidateAsync(response.IdentityToken, cancellationToken);
				if (identityTokenValidationResult.IsError)
				{
					return new TokenResponseValidationResult(identityTokenValidationResult.Error ?? "Identity token validation error");
				}
				if (state != null && !ValidateNonce(state.Nonce, identityTokenValidationResult.User))
				{
					return new TokenResponseValidationResult("Invalid nonce.");
				}
				Claim claim = identityTokenValidationResult.User.FindFirst("at_hash");
				if (claim == null)
				{
					if (_options.Policy.RequireAccessTokenHash)
					{
						return new TokenResponseValidationResult("at_hash is missing.");
					}
				}
				else if (!_crypto.ValidateHash(response.AccessToken, claim.Value, identityTokenValidationResult.SignatureAlgorithm))
				{
					return new TokenResponseValidationResult("Invalid access token hash.");
				}
				return new TokenResponseValidationResult(identityTokenValidationResult);
			}
			return new TokenResponseValidationResult((IdentityTokenValidationResult)null);
		}

		private bool ValidateNonce(string nonce, ClaimsPrincipal user)
		{
			_logger.LogTrace("ValidateNonce");
			string text = user.FindFirst("nonce")?.Value ?? "";
			bool flag = string.Equals(nonce, text, StringComparison.Ordinal);
			if (!flag)
			{
				_logger.LogError("nonce (" + nonce + ") does not match nonce from token (" + text + ")");
			}
			return flag;
		}

		private async Task<TokenResponse> RedeemCodeAsync(string code, AuthorizeState state, IDictionary<string, string> extraParameters, CancellationToken cancellationToken)
		{
			_logger.LogTrace("RedeemCodeAsync");
			return await _options.CreateClient().RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
			{
				Address = _options.ProviderInformation.TokenEndpoint,
				ClientId = _options.ClientId,
				ClientSecret = _options.ClientSecret,
				ClientCredentialStyle = _options.TokenClientCredentialStyle,
				Code = code,
				RedirectUri = state.RedirectUri,
				CodeVerifier = state.CodeVerifier,
				Parameters = (extraParameters ?? new Dictionary<string, string>())
			}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
	public class LoginResult : Result
	{
		public virtual ClaimsPrincipal User { get; internal set; }

		public virtual string AccessToken { get; internal set; }

		public virtual string IdentityToken { get; internal set; }

		public virtual string RefreshToken { get; internal set; }

		public virtual DateTime AccessTokenExpiration { get; internal set; }

		public virtual DateTime AuthenticationTime { get; internal set; }

		public virtual DelegatingHandler RefreshTokenHandler { get; internal set; }

		public TokenResponse TokenResponse { get; internal set; }

		public LoginResult()
		{
		}

		public LoginResult(string error)
		{
			Error = error;
		}
	}
	public class LogoutResult : Result
	{
		public string Response { get; set; }

		public LogoutResult()
		{
		}

		public LogoutResult(string error)
		{
			Error = error;
		}
	}
	internal class ResponseValidationResult : Result
	{
		public virtual AuthorizeResponse AuthorizeResponse { get; set; }

		public virtual TokenResponse TokenResponse { get; set; }

		public virtual ClaimsPrincipal User { get; set; }

		public ResponseValidationResult()
		{
		}

		public ResponseValidationResult(string error)
		{
			Error = error;
		}
	}
	public abstract class Result
	{
		public virtual bool IsError => Error.IsPresent();

		public virtual string Error { get; set; }
	}
	public class TokenRefreshedEventArgs : EventArgs
	{
		public string AccessToken { get; }

		public string RefreshToken { get; }

		public int ExpiresIn { get; }

		public TokenRefreshedEventArgs(string accessToken, string refreshToken, int expiresIn)
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
			ExpiresIn = expiresIn;
		}
	}
}
namespace IdentityModel.OidcClient.Results
{
	internal class AuthorizeResult : Result
	{
		public virtual string Data { get; set; }

		public virtual AuthorizeState State { get; set; }
	}
	internal class IdentityTokenValidationResult : Result
	{
		public ClaimsPrincipal User { get; set; }

		public string SignatureAlgorithm { get; set; }
	}
	public class RefreshTokenResult : Result
	{
		public virtual string IdentityToken { get; internal set; }

		public virtual string AccessToken { get; internal set; }

		public virtual string RefreshToken { get; internal set; }

		public virtual int ExpiresIn { get; internal set; }

		public virtual DateTime AccessTokenExpiration { get; internal set; }
	}
	internal class TokenResponseValidationResult : Result
	{
		public virtual IdentityTokenValidationResult IdentityTokenValidationResult { get; set; }

		public TokenResponseValidationResult(string error)
		{
			Error = error;
		}

		public TokenResponseValidationResult(IdentityTokenValidationResult result)
		{
			IdentityTokenValidationResult = result;
		}
	}
	public class UserInfoResult : Result
	{
		public virtual IEnumerable<Claim> Claims { get; internal set; }
	}
}
namespace IdentityModel.OidcClient.Infrastructure
{
	public static class LogSerializer
	{
		public static bool Enabled;

		private static readonly JsonSerializerSettings jsonSettings;

		static LogSerializer()
		{
			Enabled = true;
			jsonSettings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				DateFormatHandling = DateFormatHandling.IsoDateFormat,
				Formatting = Formatting.Indented
			};
			jsonSettings.Converters.Add(new StringEnumConverter());
		}

		public static string Serialize(object logObject)
		{
			if (!Enabled)
			{
				return "Logging has been disabled";
			}
			return JsonConvert.SerializeObject(logObject, jsonSettings);
		}
	}
	internal static class OidcClientOptionsExtensions
	{
		public static HttpClient CreateClient(this OidcClientOptions options)
		{
			HttpClient httpClient = ((options.BackchannelHandler == null) ? new HttpClient() : new HttpClient(options.BackchannelHandler));
			httpClient.Timeout = options.BackchannelTimeout;
			return httpClient;
		}
	}
}
namespace IdentityModel.OidcClient.Browser
{
	public class BrowserOptions
	{
		public string StartUrl { get; }

		public string EndUrl { get; }

		public OidcClientOptions.AuthorizeResponseMode ResponseMode { get; set; }

		public DisplayMode DisplayMode { get; set; }

		public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(5.0);

		public BrowserOptions(string startUrl, string endUrl)
		{
			StartUrl = startUrl;
			EndUrl = endUrl;
		}
	}
	public class BrowserResult : Result
	{
		public BrowserResultType ResultType { get; set; }

		public string Response { get; set; }
	}
	public enum BrowserResultType
	{
		Success,
		HttpError,
		UserCancel,
		Timeout,
		UnknownError
	}
	public enum DisplayMode
	{
		Visible,
		Hidden
	}
	public interface IBrowser
	{
		Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default(CancellationToken));
	}
}
