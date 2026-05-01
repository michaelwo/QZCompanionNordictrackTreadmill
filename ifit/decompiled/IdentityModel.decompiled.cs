using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Internal;
using IdentityModel.Jwk;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Dominick Baier;Brock Allen")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("OpenID Connect & OAuth 2.0 client library")]
[assembly: AssemblyFileVersion("4.1.0.0")]
[assembly: AssemblyInformationalVersion("4.1.0+c3ecdc59cd0eb2f392b40c9ab4539044fa22d989")]
[assembly: AssemblyProduct("IdentityModel")]
[assembly: AssemblyTitle("IdentityModel")]
[assembly: AssemblyVersion("4.1.0.0")]
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
	internal sealed class IsReadOnlyAttribute : Attribute
	{
	}
}
namespace System.Net.Http
{
	public class BasicAuthenticationHeaderValue : AuthenticationHeaderValue
	{
		public BasicAuthenticationHeaderValue(string userName, string password)
			: base("Basic", EncodeCredential(userName, password))
		{
		}

		public static string EncodeCredential(string userName, string password)
		{
			if (string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentNullException("userName");
			}
			if (password == null)
			{
				password = "";
			}
			Encoding uTF = Encoding.UTF8;
			string s = $"{userName}:{password}";
			return Convert.ToBase64String(uTF.GetBytes(s));
		}
	}
	public class BasicAuthenticationOAuthHeaderValue : AuthenticationHeaderValue
	{
		public BasicAuthenticationOAuthHeaderValue(string userName, string password)
			: base("Basic", EncodeCredential(userName, password))
		{
		}

		public static string EncodeCredential(string userName, string password)
		{
			if (string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentNullException("userName");
			}
			if (password == null)
			{
				password = "";
			}
			Encoding uTF = Encoding.UTF8;
			string s = UrlEncode(userName) + ":" + UrlEncode(password);
			return Convert.ToBase64String(uTF.GetBytes(s));
		}

		private static string UrlEncode(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}
			return Uri.EscapeDataString(value).Replace("%20", "+");
		}
	}
}
namespace IdentityModel
{
	public static class Base64Url
	{
		public static string Encode(byte[] arg)
		{
			return Convert.ToBase64String(arg).Split(new char[1] { '=' })[0].Replace('+', '-').Replace('/', '_');
		}

		public static byte[] Decode(string arg)
		{
			string text = arg;
			text = text.Replace('-', '+');
			text = text.Replace('_', '/');
			switch (text.Length % 4)
			{
			case 2:
				text += "==";
				break;
			case 3:
				text += "=";
				break;
			default:
				throw new Exception("Illegal base64url string!");
			case 0:
				break;
			}
			return Convert.FromBase64String(text);
		}
	}
	public class ClaimComparer : EqualityComparer<Claim>
	{
		public class Options
		{
			public bool IgnoreIssuer { get; set; }

			public bool IgnoreValueCase { get; set; }
		}

		private readonly Options _options = new Options();

		public ClaimComparer()
		{
		}

		public ClaimComparer(Options options)
		{
			_options = options ?? throw new ArgumentNullException("options");
		}

		public override bool Equals(Claim x, Claim y)
		{
			if (x == null && y == null)
			{
				return true;
			}
			if (x == null && y != null)
			{
				return false;
			}
			if (x != null && y == null)
			{
				return false;
			}
			StringComparison comparisonType = StringComparison.Ordinal;
			if (_options.IgnoreValueCase)
			{
				comparisonType = StringComparison.OrdinalIgnoreCase;
			}
			bool flag = string.Equals(x.Type, y.Type, StringComparison.OrdinalIgnoreCase) && string.Equals(x.Value, y.Value, comparisonType) && string.Equals(x.ValueType, y.ValueType, StringComparison.Ordinal);
			if (_options.IgnoreIssuer)
			{
				return flag;
			}
			if (flag)
			{
				return string.Equals(x.Issuer, y.Issuer, comparisonType);
			}
			return false;
		}

		public override int GetHashCode(Claim claim)
		{
			if (claim == null)
			{
				return 0;
			}
			int num = claim.Type?.ToLowerInvariant().GetHashCode() ?? (0 ^ claim.ValueType?.GetHashCode()).GetValueOrDefault();
			int num2;
			int num3;
			if (_options.IgnoreValueCase)
			{
				num2 = claim.Value?.ToLowerInvariant().GetHashCode() ?? 0;
				num3 = claim.Issuer?.ToLowerInvariant().GetHashCode() ?? 0;
			}
			else
			{
				num2 = claim.Value?.GetHashCode() ?? 0;
				num3 = claim.Issuer?.GetHashCode() ?? 0;
			}
			if (_options.IgnoreIssuer)
			{
				return num ^ num2;
			}
			return num ^ num2 ^ num3;
		}
	}
	public class CryptoRandom : Random
	{
		public enum OutputFormat
		{
			Base64Url,
			Base64,
			Hex
		}

		private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

		private readonly byte[] _uint32Buffer = new byte[4];

		public static byte[] CreateRandomKey(int length)
		{
			byte[] array = new byte[length];
			Rng.GetBytes(array);
			return array;
		}

		public static string CreateUniqueId(int length = 32, OutputFormat format = OutputFormat.Base64Url)
		{
			byte[] array = CreateRandomKey(length);
			return format switch
			{
				OutputFormat.Base64Url => Base64Url.Encode(array), 
				OutputFormat.Base64 => Convert.ToBase64String(array), 
				OutputFormat.Hex => BitConverter.ToString(array).Replace("-", ""), 
				_ => throw new ArgumentException("Invalid output format", "format"), 
			};
		}

		public CryptoRandom()
		{
		}

		public CryptoRandom(int ignoredSeed)
		{
		}

		public override int Next()
		{
			Rng.GetBytes(_uint32Buffer);
			return BitConverter.ToInt32(_uint32Buffer, 0) & 0x7FFFFFFF;
		}

		public override int Next(int maxValue)
		{
			if (maxValue < 0)
			{
				throw new ArgumentOutOfRangeException("maxValue");
			}
			return Next(0, maxValue);
		}

		public override int Next(int minValue, int maxValue)
		{
			if (minValue > maxValue)
			{
				throw new ArgumentOutOfRangeException("minValue");
			}
			if (minValue == maxValue)
			{
				return minValue;
			}
			long num = maxValue - minValue;
			uint num2;
			long num3;
			long num4;
			do
			{
				Rng.GetBytes(_uint32Buffer);
				num2 = BitConverter.ToUInt32(_uint32Buffer, 0);
				num3 = 4294967296L;
				num4 = num3 % num;
			}
			while (num2 >= num3 - num4);
			return (int)(minValue + num2 % num);
		}

		public override double NextDouble()
		{
			Rng.GetBytes(_uint32Buffer);
			return (double)BitConverter.ToUInt32(_uint32Buffer, 0) / 4294967296.0;
		}

		public override void NextBytes(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			Rng.GetBytes(buffer);
		}
	}
	public static class DateTimeExtensions
	{
		public static long ToEpochTime(this DateTime dateTime)
		{
			return (dateTime.ToUniversalTime().Ticks - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).Ticks) / 10000000;
		}

		public static DateTime ToDateTimeFromEpoch(this long date)
		{
			long value = date * 10000000;
			return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(value);
		}
	}
	public static class Identity
	{
		public static ClaimsIdentity Anonymous => new ClaimsIdentity(new List<Claim>
		{
			new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "")
		});

		public static ClaimsIdentity Create(string authenticationType, params Claim[] claims)
		{
			return new ClaimsIdentity(claims, authenticationType, "name", "role");
		}

		public static ClaimsIdentity CreateFromCertificate(X509Certificate2 certificate, string authenticationType = "X.509", bool includeAllClaims = false)
		{
			List<Claim> list = new List<Claim>();
			string issuer = certificate.Issuer;
			list.Add(new Claim("issuer", issuer));
			string thumbprint = certificate.Thumbprint;
			list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/thumbprint", thumbprint, "http://www.w3.org/2001/XMLSchema#base64Binary", issuer));
			string name = certificate.SubjectName.Name;
			if (name.IsPresent())
			{
				list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/x500distinguishedname", name, "http://www.w3.org/2001/XMLSchema#string", issuer));
			}
			if (includeAllClaims)
			{
				name = certificate.SerialNumber;
				if (name.IsPresent())
				{
					list.Add(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber", name, "http://www.w3.org/2001/XMLSchema#string", issuer));
				}
				name = certificate.GetNameInfo(X509NameType.DnsName, forIssuer: false);
				if (name.IsPresent())
				{
					list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dns", name, "http://www.w3.org/2001/XMLSchema#string", issuer));
				}
				name = certificate.GetNameInfo(X509NameType.SimpleName, forIssuer: false);
				if (name.IsPresent())
				{
					list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", name, "http://www.w3.org/2001/XMLSchema#string", issuer));
				}
				name = certificate.GetNameInfo(X509NameType.EmailName, forIssuer: false);
				if (name.IsPresent())
				{
					list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", name, "http://www.w3.org/2001/XMLSchema#string", issuer));
				}
				name = certificate.GetNameInfo(X509NameType.UpnName, forIssuer: false);
				if (name.IsPresent())
				{
					list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn", name, "http://www.w3.org/2001/XMLSchema#string", issuer));
				}
				name = certificate.GetNameInfo(X509NameType.UrlName, forIssuer: false);
				if (name.IsPresent())
				{
					list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/uri", name, "http://www.w3.org/2001/XMLSchema#string", issuer));
				}
			}
			return new ClaimsIdentity(list, authenticationType);
		}
	}
	public static class JwtClaimTypes
	{
		public const string Subject = "sub";

		public const string Name = "name";

		public const string GivenName = "given_name";

		public const string FamilyName = "family_name";

		public const string MiddleName = "middle_name";

		public const string NickName = "nickname";

		public const string PreferredUserName = "preferred_username";

		public const string Profile = "profile";

		public const string Picture = "picture";

		public const string WebSite = "website";

		public const string Email = "email";

		public const string EmailVerified = "email_verified";

		public const string Gender = "gender";

		public const string BirthDate = "birthdate";

		public const string ZoneInfo = "zoneinfo";

		public const string Locale = "locale";

		public const string PhoneNumber = "phone_number";

		public const string PhoneNumberVerified = "phone_number_verified";

		public const string Address = "address";

		public const string Audience = "aud";

		public const string Issuer = "iss";

		public const string NotBefore = "nbf";

		public const string Expiration = "exp";

		public const string UpdatedAt = "updated_at";

		public const string IssuedAt = "iat";

		public const string AuthenticationMethod = "amr";

		public const string SessionId = "sid";

		public const string AuthenticationContextClassReference = "acr";

		public const string AuthenticationTime = "auth_time";

		public const string AuthorizedParty = "azp";

		public const string AccessTokenHash = "at_hash";

		public const string AuthorizationCodeHash = "c_hash";

		public const string StateHash = "s_hash";

		public const string Nonce = "nonce";

		public const string JwtId = "jti";

		public const string Events = "events";

		public const string ClientId = "client_id";

		public const string Scope = "scope";

		public const string Actor = "act";

		public const string MayAct = "may_act";

		public const string Id = "id";

		public const string IdentityProvider = "idp";

		public const string Role = "role";

		public const string ReferenceTokenId = "reference_token_id";

		public const string Confirmation = "cnf";
	}
	public static class OidcConstants
	{
		public static class AuthorizeRequest
		{
			public const string Scope = "scope";

			public const string ResponseType = "response_type";

			public const string ClientId = "client_id";

			public const string RedirectUri = "redirect_uri";

			public const string State = "state";

			public const string ResponseMode = "response_mode";

			public const string Nonce = "nonce";

			public const string Display = "display";

			public const string Prompt = "prompt";

			public const string MaxAge = "max_age";

			public const string UiLocales = "ui_locales";

			public const string IdTokenHint = "id_token_hint";

			public const string LoginHint = "login_hint";

			public const string AcrValues = "acr_values";

			public const string CodeChallenge = "code_challenge";

			public const string CodeChallengeMethod = "code_challenge_method";

			public const string Request = "request";

			public const string RequestUri = "request_uri";
		}

		public static class AuthorizeErrors
		{
			public const string InvalidRequest = "invalid_request";

			public const string UnauthorizedClient = "unauthorized_client";

			public const string AccessDenied = "access_denied";

			public const string UnsupportedResponseType = "unsupported_response_type";

			public const string InvalidScope = "invalid_scope";

			public const string ServerError = "server_error";

			public const string TemporarilyUnavailable = "temporarily_unavailable";

			public const string InteractionRequired = "interaction_required";

			public const string LoginRequired = "login_required";

			public const string AccountSelectionRequired = "account_selection_required";

			public const string ConsentRequired = "consent_required";

			public const string InvalidRequestUri = "invalid_request_uri";

			public const string InvalidRequestObject = "invalid_request_object";

			public const string RequestNotSupported = "request_not_supported";

			public const string RequestUriNotSupported = "request_uri_not_supported";

			public const string RegistrationNotSupported = "registration_not_supported";
		}

		public static class AuthorizeResponse
		{
			public const string Scope = "scope";

			public const string Code = "code";

			public const string AccessToken = "access_token";

			public const string ExpiresIn = "expires_in";

			public const string TokenType = "token_type";

			public const string RefreshToken = "refresh_token";

			public const string IdentityToken = "id_token";

			public const string State = "state";

			public const string Error = "error";

			public const string ErrorDescription = "error_description";
		}

		public static class DeviceAuthorizationResponse
		{
			public const string DeviceCode = "device_code";

			public const string UserCode = "user_code";

			public const string VerificationUri = "verification_uri";

			public const string VerificationUriComplete = "verification_uri_complete";

			public const string ExpiresIn = "expires_in";

			public const string Interval = "interval";
		}

		public static class EndSessionRequest
		{
			public const string IdTokenHint = "id_token_hint";

			public const string PostLogoutRedirectUri = "post_logout_redirect_uri";

			public const string State = "state";

			public const string Sid = "sid";

			public const string Issuer = "iss";
		}

		public static class TokenRequest
		{
			public const string GrantType = "grant_type";

			public const string RedirectUri = "redirect_uri";

			public const string ClientId = "client_id";

			public const string ClientSecret = "client_secret";

			public const string ClientAssertion = "client_assertion";

			public const string ClientAssertionType = "client_assertion_type";

			public const string Assertion = "assertion";

			public const string Code = "code";

			public const string RefreshToken = "refresh_token";

			public const string Scope = "scope";

			public const string UserName = "username";

			public const string Password = "password";

			public const string CodeVerifier = "code_verifier";

			public const string TokenType = "token_type";

			public const string Algorithm = "alg";

			public const string Key = "key";

			public const string DeviceCode = "device_code";

			public const string Resource = "resource";

			public const string Audience = "audience";

			public const string RequestedTokenType = "requested_token_type";

			public const string SubjectToken = "subject_token";

			public const string SubjectTokenType = "subject_token_type";

			public const string ActorToken = "actor_token";

			public const string ActorTokenType = "actor_token_type";
		}

		public static class TokenRequestTypes
		{
			public const string Bearer = "bearer";

			public const string Pop = "pop";
		}

		public static class TokenErrors
		{
			public const string InvalidRequest = "invalid_request";

			public const string InvalidClient = "invalid_client";

			public const string InvalidGrant = "invalid_grant";

			public const string UnauthorizedClient = "unauthorized_client";

			public const string UnsupportedGrantType = "unsupported_grant_type";

			public const string UnsupportedResponseType = "unsupported_response_type";

			public const string InvalidScope = "invalid_scope";

			public const string AuthorizationPending = "authorization_pending";

			public const string AccessDenied = "access_denied";

			public const string SlowDown = "slow_down";

			public const string ExpiredToken = "expired_token";
		}

		public static class TokenResponse
		{
			public const string AccessToken = "access_token";

			public const string ExpiresIn = "expires_in";

			public const string TokenType = "token_type";

			public const string RefreshToken = "refresh_token";

			public const string IdentityToken = "id_token";

			public const string Error = "error";

			public const string ErrorDescription = "error_description";

			public const string BearerTokenType = "Bearer";

			public const string IssuedTokenType = "issued_token_type";

			public const string Scope = "scope";
		}

		public static class TokenIntrospectionRequest
		{
			public const string Token = "token";

			public const string TokenTypeHint = "token_type_hint";
		}

		public static class RegistrationResponse
		{
			public const string Error = "error";

			public const string ErrorDescription = "error_description";

			public const string ClientId = "client_id";

			public const string ClientSecret = "client_secret";

			public const string RegistrationAccessToken = "registration_access_token";

			public const string RegistrationClientUri = "registration_client_uri";

			public const string ClientIdIssuedAt = "client_id_issued_at";

			public const string ClientSecretExpiresAt = "client_secret_expires_at";
		}

		public static class ClientMetadata
		{
			public const string RedirectUris = "redirect_uris";

			public const string ResponseTypes = "response_types";

			public const string GrantTypes = "grant_types";

			public const string ApplicationType = "application_type";

			public const string Contacts = "contacts";

			public const string ClientName = "client_name";

			public const string LogoUri = "logo_uri";

			public const string ClientUri = "client_uri";

			public const string PolicyUri = "policy_uri";

			public const string TosUri = "tos_uri";

			public const string JwksUri = "jwks_uri";

			public const string Jwks = "jwks";

			public const string SectorIdentifierUri = "sector_identifier_uri";

			public const string SubjectType = "subject_type";

			public const string TokenEndpointAuthenticationMethod = "token_endpoint_auth_method";

			public const string TokenEndpointAuthenticationSigningAlgorithm = "token_endpoint_auth_signing_alg";

			public const string DefaultMaxAge = "default_max_age";

			public const string RequireAuthenticationTime = "require_auth_time";

			public const string DefaultAcrValues = "default_acr_values";

			public const string InitiateLoginUris = "initiate_login_uri";

			public const string RequestUris = "request_uris";

			public const string IdentityTokenSignedResponseAlgorithm = "id_token_signed_response_alg";

			public const string IdentityTokenEncryptedResponseAlgorithm = "id_token_encrypted_response_alg";

			public const string IdentityTokenEncryptedResponseEncryption = "id_token_encrypted_response_enc";

			public const string UserinfoSignedResponseAlgorithm = "userinfo_signed_response_alg";

			public const string UserInfoEncryptedResponseAlgorithm = "userinfo_encrypted_response_alg";

			public const string UserinfoEncryptedResponseEncryption = "userinfo_encrypted_response_enc";

			public const string RequestObjectSigningAlgorithm = "request_object_signing_alg";

			public const string RequestObjectEncryptionAlgorithm = "request_object_encryption_alg";

			public const string RequestObjectEncryptionEncryption = "request_object_encryption_enc";
		}

		public static class TokenTypes
		{
			public const string AccessToken = "access_token";

			public const string IdentityToken = "id_token";

			public const string RefreshToken = "refresh_token";
		}

		public static class TokenTypeIdentifiers
		{
			public const string AccessToken = "urn:ietf:params:oauth:token-type:access_token";

			public const string IdentityToken = "urn:ietf:params:oauth:token-type:id_token";

			public const string RefreshToken = "urn:ietf:params:oauth:token-type:refresh_token";

			public const string Saml11 = "urn:ietf:params:oauth:token-type:saml1";

			public const string Saml2 = "urn:ietf:params:oauth:token-type:saml2";
		}

		public static class AuthenticationSchemes
		{
			public const string AuthorizationHeaderBearer = "Bearer";

			public const string FormPostBearer = "access_token";

			public const string QueryStringBearer = "access_token";

			public const string AuthorizationHeaderPop = "PoP";

			public const string FormPostPop = "pop_access_token";

			public const string QueryStringPop = "pop_access_token";
		}

		public static class GrantTypes
		{
			public const string Password = "password";

			public const string AuthorizationCode = "authorization_code";

			public const string ClientCredentials = "client_credentials";

			public const string RefreshToken = "refresh_token";

			public const string Implicit = "implicit";

			public const string Saml2Bearer = "urn:ietf:params:oauth:grant-type:saml2-bearer";

			public const string JwtBearer = "urn:ietf:params:oauth:grant-type:jwt-bearer";

			public const string DeviceCode = "urn:ietf:params:oauth:grant-type:device_code";

			public const string TokenExchange = "urn:ietf:params:oauth:grant-type:token-exchange";
		}

		public static class ClientAssertionTypes
		{
			public const string JwtBearer = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer";

			public const string SamlBearer = "urn:ietf:params:oauth:client-assertion-type:saml2-bearer";
		}

		public static class ResponseTypes
		{
			public const string Code = "code";

			public const string Token = "token";

			public const string IdToken = "id_token";

			public const string IdTokenToken = "id_token token";

			public const string CodeIdToken = "code id_token";

			public const string CodeToken = "code token";

			public const string CodeIdTokenToken = "code id_token token";
		}

		public static class ResponseModes
		{
			public const string FormPost = "form_post";

			public const string Query = "query";

			public const string Fragment = "fragment";
		}

		public static class DisplayModes
		{
			public const string Page = "page";

			public const string Popup = "popup";

			public const string Touch = "touch";

			public const string Wap = "wap";
		}

		public static class PromptModes
		{
			public const string None = "none";

			public const string Login = "login";

			public const string Consent = "consent";

			public const string SelectAccount = "select_account";
		}

		public static class CodeChallengeMethods
		{
			public const string Plain = "plain";

			public const string Sha256 = "S256";
		}

		public static class ProtectedResourceErrors
		{
			public const string InvalidToken = "invalid_token";

			public const string ExpiredToken = "expired_token";

			public const string InvalidRequest = "invalid_request";

			public const string InsufficientScope = "insufficient_scope";
		}

		public static class EndpointAuthenticationMethods
		{
			public const string PostBody = "client_secret_post";

			public const string BasicAuthentication = "client_secret_basic";

			public const string PrivateKeyJwt = "private_key_jwt";

			public const string TlsClientAuth = "tls_client_auth";

			public const string SelfSignedTlsClientAuth = "self_signed_tls_client_auth";
		}

		public static class AuthenticationMethods
		{
			public const string FacialRecognition = "face";

			public const string FingerprintBiometric = "fpt";

			public const string Geolocation = "geo";

			public const string ProofOfPossessionHardwareSecuredKey = "hwk";

			public const string IrisScanBiometric = "iris";

			public const string KnowledgeBasedAuthentication = "kba";

			public const string MultipleChannelAuthentication = "mca";

			public const string MultiFactorAuthentication = "mfa";

			public const string OneTimePassword = "otp";

			public const string PersonalIdentificationOrPattern = "pin";

			public const string Password = "pwd";

			public const string RiskBasedAuthentication = "rba";

			public const string RetinaScanBiometric = "retina";

			public const string SmartCard = "sc";

			public const string ConfirmationBySms = "sms";

			public const string ProofOfPossessionSoftwareSecuredKey = "swk";

			public const string ConfirmationByTelephone = "tel";

			public const string UserPresenceTest = "user";

			public const string VoiceBiometric = "vbm";

			public const string WindowsIntegratedAuthentication = "wia";
		}

		public static class Algorithms
		{
			public static class Symmetric
			{
				public const string HS256 = "HS256";

				public const string HS384 = "HS284";

				public const string HS512 = "HS512";
			}

			public static class Asymmetric
			{
				public const string RS256 = "RS256";

				public const string RS384 = "RS384";

				public const string RS512 = "RS512";

				public const string ES256 = "ES256";

				public const string ES384 = "ES384";

				public const string ES512 = "ES512";

				public const string PS256 = "PS256";

				public const string PS384 = "PS384";

				public const string PS512 = "PS512";
			}

			public const string None = "none";
		}

		public static class Discovery
		{
			public const string Issuer = "issuer";

			public const string AuthorizationEndpoint = "authorization_endpoint";

			public const string DeviceAuthorizationEndpoint = "device_authorization_endpoint";

			public const string TokenEndpoint = "token_endpoint";

			public const string UserInfoEndpoint = "userinfo_endpoint";

			public const string IntrospectionEndpoint = "introspection_endpoint";

			public const string RevocationEndpoint = "revocation_endpoint";

			public const string DiscoveryEndpoint = ".well-known/openid-configuration";

			public const string JwksUri = "jwks_uri";

			public const string EndSessionEndpoint = "end_session_endpoint";

			public const string CheckSessionIframe = "check_session_iframe";

			public const string RegistrationEndpoint = "registration_endpoint";

			public const string MtlsEndpointAliases = "mtls_endpoint_aliases";

			public const string FrontChannelLogoutSupported = "frontchannel_logout_supported";

			public const string FrontChannelLogoutSessionSupported = "frontchannel_logout_session_supported";

			public const string BackChannelLogoutSupported = "backchannel_logout_supported";

			public const string BackChannelLogoutSessionSupported = "backchannel_logout_session_supported";

			public const string GrantTypesSupported = "grant_types_supported";

			public const string CodeChallengeMethodsSupported = "code_challenge_methods_supported";

			public const string ScopesSupported = "scopes_supported";

			public const string SubjectTypesSupported = "subject_types_supported";

			public const string ResponseModesSupported = "response_modes_supported";

			public const string ResponseTypesSupported = "response_types_supported";

			public const string ClaimsSupported = "claims_supported";

			public const string TokenEndpointAuthenticationMethodsSupported = "token_endpoint_auth_methods_supported";

			public const string ClaimsLocalesSupported = "claims_locales_supported";

			public const string ClaimsParameterSupported = "claims_parameter_supported";

			public const string ClaimTypesSupported = "claim_types_supported";

			public const string DisplayValuesSupported = "display_values_supported";

			public const string AcrValuesSupported = "acr_values_supported";

			public const string IdTokenEncryptionAlgorithmsSupported = "id_token_encryption_alg_values_supported";

			public const string IdTokenEncryptionEncValuesSupported = "id_token_encryption_enc_values_supported";

			public const string IdTokenSigningAlgorithmsSupported = "id_token_signing_alg_values_supported";

			public const string OpPolicyUri = "op_policy_uri";

			public const string OpTosUri = "op_tos_uri";

			public const string RequestObjectEncryptionAlgorithmsSupported = "request_object_encryption_alg_values_supported";

			public const string RequestObjectEncryptionEncValuesSupported = "request_object_encryption_enc_values_supported";

			public const string RequestObjectSigningAlgorithmsSupported = "request_object_signing_alg_values_supported";

			public const string RequestParameterSupported = "request_parameter_supported";

			public const string RequestUriParameterSupported = "request_uri_parameter_supported";

			public const string RequireRequestUriRegistration = "require_request_uri_registration";

			public const string ServiceDocumentation = "service_documentation";

			public const string TokenEndpointAuthSigningAlgorithmsSupported = "token_endpoint_auth_signing_alg_values_supported";

			public const string UILocalesSupported = "ui_locales_supported";

			public const string UserInfoEncryptionAlgorithmsSupported = "userinfo_encryption_alg_values_supported";

			public const string UserInfoEncryptionEncValuesSupported = "userinfo_encryption_enc_values_supported";

			public const string UserInfoSigningAlgorithmsSupported = "userinfo_signing_alg_values_supported";

			public const string TlsClientCertificateBoundAccessTokens = "tls_client_certificate_bound_access_tokens";
		}

		public static class Events
		{
			public const string BackChannelLogout = "http://schemas.openid.net/event/backchannel-logout";
		}

		public static class BackChannelLogoutRequest
		{
			public const string LogoutToken = "logout_token";
		}

		public static class StandardScopes
		{
			public const string OpenId = "openid";

			public const string Profile = "profile";

			public const string Email = "email";

			public const string Address = "address";

			public const string Phone = "phone";

			public const string OfflineAccess = "offline_access";
		}
	}
	public static class Principal
	{
		public static ClaimsPrincipal Anonymous => new ClaimsPrincipal(Identity.Anonymous);

		public static ClaimsPrincipal Create(string authenticationType, params Claim[] claims)
		{
			return new ClaimsPrincipal(Identity.Create(authenticationType, claims));
		}

		public static ClaimsPrincipal CreateFromCertificate(X509Certificate2 certificate, string authenticationType = "X.509", bool includeAllClaims = false)
		{
			return new ClaimsPrincipal(Identity.CreateFromCertificate(certificate, authenticationType, includeAllClaims));
		}
	}
	public static class StringExtensions
	{
		public static string ToSha256(this string input)
		{
			if (input.IsMissing())
			{
				return string.Empty;
			}
			using SHA256 sHA = SHA256.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			return Convert.ToBase64String(sHA.ComputeHash(bytes));
		}

		public static string ToSha512(this string input)
		{
			if (input.IsMissing())
			{
				return string.Empty;
			}
			using SHA512 sHA = SHA512.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			return Convert.ToBase64String(sHA.ComputeHash(bytes));
		}
	}
	public static class TimeConstantComparer
	{
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public static bool IsEqual(string s1, string s2)
		{
			if (s1 == null && s2 == null)
			{
				return true;
			}
			if (s1 == null || s2 == null)
			{
				return false;
			}
			if (s1.Length != s2.Length)
			{
				return false;
			}
			char[] array = s1.ToCharArray();
			char[] array2 = s2.ToCharArray();
			int num = 0;
			for (int i = 0; i < s1.Length; i++)
			{
				num = ((!array[i].Equals(array2[i])) ? (num + 1) : (num + 2));
			}
			return num == s1.Length * 2;
		}
	}
	public static class X509
	{
		public static X509CertificatesLocation CurrentUser => new X509CertificatesLocation(StoreLocation.CurrentUser);

		public static X509CertificatesLocation LocalMachine => new X509CertificatesLocation(StoreLocation.LocalMachine);
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class X509CertificatesFinder
	{
		private readonly StoreLocation _location;

		private readonly StoreName _name;

		private readonly X509FindType _findType;

		public X509CertificatesFinder(StoreLocation location, StoreName name, X509FindType findType)
		{
			_location = location;
			_name = name;
			_findType = findType;
		}

		public IEnumerable<X509Certificate2> Find(object findValue, bool validOnly = true)
		{
			using X509Store x509Store = new X509Store(_name, _location);
			x509Store.Open(OpenFlags.ReadOnly);
			return x509Store.Certificates.Find(_findType, findValue, validOnly).Cast<X509Certificate2>();
		}
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class X509CertificatesLocation
	{
		private readonly StoreLocation _location;

		public X509CertificatesName My => new X509CertificatesName(_location, StoreName.My);

		public X509CertificatesName AddressBook => new X509CertificatesName(_location, StoreName.AddressBook);

		public X509CertificatesName TrustedPeople => new X509CertificatesName(_location, StoreName.TrustedPeople);

		public X509CertificatesName TrustedPublisher => new X509CertificatesName(_location, StoreName.TrustedPublisher);

		public X509CertificatesName CertificateAuthority => new X509CertificatesName(_location, StoreName.CertificateAuthority);

		public X509CertificatesLocation(StoreLocation location)
		{
			_location = location;
		}
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class X509CertificatesName
	{
		private readonly StoreLocation _location;

		private readonly StoreName _name;

		public X509CertificatesFinder Thumbprint => new X509CertificatesFinder(_location, _name, X509FindType.FindByThumbprint);

		public X509CertificatesFinder SubjectDistinguishedName => new X509CertificatesFinder(_location, _name, X509FindType.FindBySubjectDistinguishedName);

		public X509CertificatesFinder SerialNumber => new X509CertificatesFinder(_location, _name, X509FindType.FindBySerialNumber);

		public X509CertificatesFinder IssuerName => new X509CertificatesFinder(_location, _name, X509FindType.FindByIssuerName);

		public X509CertificatesName(StoreLocation location, StoreName name)
		{
			_location = location;
			_name = name;
		}
	}
}
namespace IdentityModel.Jwk
{
	public static class JsonWebAlgorithmsKeyTypes
	{
		public const string EllipticCurve = "EC";

		public const string RSA = "RSA";

		public const string Octet = "oct";
	}
	[JsonObject]
	public class JsonWebKey
	{
		private IList<string> _certificateClauses = new List<string>();

		private IList<string> _keyops = new List<string>();

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "alg", Required = Required.Default)]
		public string Alg { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "crv", Required = Required.Default)]
		public string Crv { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "d", Required = Required.Default)]
		public string D { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "dp", Required = Required.Default)]
		public string DP { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "dq", Required = Required.Default)]
		public string DQ { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "e", Required = Required.Default)]
		public string E { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "k", Required = Required.Default)]
		public string K { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "key_ops", Required = Required.Default)]
		public IList<string> KeyOps
		{
			get
			{
				return _keyops;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("KeyOps");
				}
				foreach (string item in value)
				{
					_keyops.Add(item);
				}
			}
		}

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "kid", Required = Required.Default)]
		public string Kid { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "kty", Required = Required.Default)]
		public string Kty { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "n", Required = Required.Default)]
		public string N { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "oth", Required = Required.Default)]
		public IList<string> Oth { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "p", Required = Required.Default)]
		public string P { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "q", Required = Required.Default)]
		public string Q { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "qi", Required = Required.Default)]
		public string QI { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "use", Required = Required.Default)]
		public string Use { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "x", Required = Required.Default)]
		public string X { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "x5c", Required = Required.Default)]
		public IList<string> X5c
		{
			get
			{
				return _certificateClauses;
			}
			set
			{
				foreach (string item in value)
				{
					_certificateClauses.Add(item);
				}
			}
		}

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "x5t", Required = Required.Default)]
		public string X5t { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "x5t#S256", Required = Required.Default)]
		public string X5tS256 { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "x5u", Required = Required.Default)]
		public string X5u { get; set; }

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "y", Required = Required.Default)]
		public string Y { get; set; }

		public int KeySize
		{
			get
			{
				if (Kty == "RSA")
				{
					return Base64Url.Decode(N).Length * 8;
				}
				if (Kty == "EC")
				{
					return Base64Url.Decode(X).Length * 8;
				}
				if (Kty == "oct")
				{
					return Base64Url.Decode(K).Length * 8;
				}
				return 0;
			}
		}

		public bool HasPrivateKey
		{
			get
			{
				if (Kty == "RSA")
				{
					if (D != null && DP != null && DQ != null && P != null && Q != null)
					{
						return QI != null;
					}
					return false;
				}
				if (Kty == "EC")
				{
					return D != null;
				}
				return false;
			}
		}

		public JsonWebKey()
		{
		}

		public JsonWebKey(string json)
		{
			if (string.IsNullOrWhiteSpace(json))
			{
				throw new ArgumentNullException("json");
			}
			JsonWebKey key = JsonConvert.DeserializeObject<JsonWebKey>(json);
			Copy(key);
		}

		private void Copy(JsonWebKey key)
		{
			Alg = key.Alg;
			Crv = key.Crv;
			D = key.D;
			DP = key.DP;
			DQ = key.DQ;
			E = key.E;
			K = key.K;
			if (key.KeyOps != null)
			{
				_keyops = new List<string>(key.KeyOps);
			}
			Kid = key.Kid;
			Kty = key.Kty;
			N = key.N;
			Oth = key.Oth;
			P = key.P;
			Q = key.Q;
			QI = key.QI;
			Use = key.Use;
			if (key.X5c != null)
			{
				_certificateClauses = new List<string>(key.X5c);
			}
			X5t = key.X5t;
			X5tS256 = key.X5tS256;
			X5u = key.X5u;
			X = key.X;
			Y = key.Y;
		}
	}
	public static class JsonWebKeyParameterNames
	{
		public const string Alg = "alg";

		public const string Crv = "crv";

		public const string D = "d";

		public const string DP = "dp";

		public const string DQ = "dq";

		public const string E = "e";

		public const string K = "k";

		public const string KeyOps = "key_ops";

		public const string Keys = "keys";

		public const string Kid = "kid";

		public const string Kty = "kty";

		public const string N = "n";

		public const string Oth = "oth";

		public const string P = "p";

		public const string Q = "q";

		public const string R = "r";

		public const string T = "t";

		public const string QI = "qi";

		public const string Use = "use";

		public const string X5c = "x5c";

		public const string X5t = "x5t";

		public const string X5tS256 = "x5t#S256";

		public const string X5u = "x5u";

		public const string X = "x";

		public const string Y = "y";
	}
	public class JsonWebKeySet
	{
		private List<JsonWebKey> _keys = new List<JsonWebKey>();

		public IList<JsonWebKey> Keys => _keys;

		public JsonWebKeySet()
		{
		}

		public JsonWebKeySet(string json)
		{
			if (string.IsNullOrWhiteSpace(json))
			{
				throw new ArgumentNullException("json");
			}
			JsonWebKeySet jsonWebKeySet = JsonConvert.DeserializeObject<JsonWebKeySet>(json);
			_keys = jsonWebKeySet._keys;
		}
	}
	public static class JsonWebKeyExtensions
	{
		public static string ToJwkString(this JsonWebKey key)
		{
			string s = JsonConvert.SerializeObject(key);
			return Base64Url.Encode(Encoding.UTF8.GetBytes(s));
		}
	}
}
namespace IdentityModel.Internal
{
	internal class AsyncLazy<T> : Lazy<Task<T>>
	{
		public AsyncLazy(Func<Task<T>> taskFactory)
			: base((Func<Task<T>>)(() => GetTaskAsync(taskFactory).Unwrap()))
		{
		}

		private static async Task<Task<T>> GetTaskAsync(Func<Task<T>> taskFactory)
		{
			if (TaskHelpers.CanFactoryStartNew)
			{
				return Task<Task<T>>.Factory.StartNew(taskFactory).Unwrap();
			}
			await Task.Yield();
			return taskFactory();
		}
	}
	internal static class DictionaryExtensions
	{
		public static void AddOptional(this IDictionary<string, string> parameters, string key, string value)
		{
			if (parameters == null)
			{
				throw new ArgumentNullException("parameters");
			}
			if (value.IsPresent())
			{
				if (parameters.ContainsKey(key))
				{
					throw new InvalidOperationException("Duplicate parameter: " + key);
				}
				parameters.Add(key, value);
			}
		}

		public static void AddRequired(this IDictionary<string, string> parameters, string key, string value, bool allowEmpty = false)
		{
			if (parameters == null)
			{
				throw new ArgumentNullException("parameters");
			}
			if (value.IsPresent())
			{
				if (parameters.ContainsKey(key))
				{
					throw new InvalidOperationException("Duplicate parameter: " + key);
				}
				parameters.Add(key, value);
			}
			else
			{
				if (!allowEmpty)
				{
					throw new ArgumentException("Parameter is required", key);
				}
				parameters.Add(key, "");
			}
		}
	}
	internal static class InternalStringExtensions
	{
		[DebuggerStepThrough]
		public static bool IsMissing(this string value)
		{
			return string.IsNullOrWhiteSpace(value);
		}

		[DebuggerStepThrough]
		public static bool IsPresent(this string value)
		{
			return !value.IsMissing();
		}

		[DebuggerStepThrough]
		public static string EnsureTrailingSlash(this string url)
		{
			if (!url.EndsWith("/"))
			{
				return url + "/";
			}
			return url;
		}

		[DebuggerStepThrough]
		public static string RemoveTrailingSlash(this string url)
		{
			if (url != null && url.EndsWith("/"))
			{
				url = url.Substring(0, url.Length - 1);
			}
			return url;
		}
	}
	internal static class QueryHelpers
	{
		public static string AddQueryString(string uri, string name, string value)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return AddQueryString(uri, new KeyValuePair<string, string>[1]
			{
				new KeyValuePair<string, string>(name, value)
			});
		}

		public static string AddQueryString(string uri, IDictionary<string, string> queryString)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}
			if (queryString == null)
			{
				throw new ArgumentNullException("queryString");
			}
			return AddQueryString(uri, (IEnumerable<KeyValuePair<string, string>>)queryString);
		}

		private static string AddQueryString(string uri, IEnumerable<KeyValuePair<string, string>> queryString)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}
			if (queryString == null)
			{
				throw new ArgumentNullException("queryString");
			}
			int num = uri.IndexOf('#');
			string text = uri;
			string value = "";
			if (num != -1)
			{
				value = uri.Substring(num);
				text = uri.Substring(0, num);
			}
			bool flag = text.IndexOf('?') != -1;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(text);
			foreach (KeyValuePair<string, string> item in queryString)
			{
				if (item.Value != null)
				{
					stringBuilder.Append(flag ? '&' : '?');
					stringBuilder.Append(UrlEncoder.Default.Encode(item.Key));
					stringBuilder.Append('=');
					stringBuilder.Append(UrlEncoder.Default.Encode(item.Value));
					flag = true;
				}
			}
			stringBuilder.Append(value);
			return stringBuilder.ToString();
		}
	}
	public static class TaskHelpers
	{
		public static bool CanConfigureAwaitFalse { get; set; } = true;

		public static bool CanFactoryStartNew { get; set; } = true;

		internal static ConfiguredTaskAwaitable ConfigureAwait(this Task task)
		{
			return task.ConfigureAwait(!CanConfigureAwaitFalse);
		}

		internal static ConfiguredTaskAwaitable<TResult> ConfigureAwait<TResult>(this Task<TResult> task)
		{
			return task.ConfigureAwait(!CanConfigureAwaitFalse);
		}
	}
	public static class ValuesHelper
	{
		public static Dictionary<string, string> ObjectToDictionary(object values)
		{
			if (values == null)
			{
				return null;
			}
			if (values is Dictionary<string, string> result)
			{
				return result;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (PropertyInfo runtimeProperty in values.GetType().GetRuntimeProperties())
			{
				string value = runtimeProperty.GetValue(values) as string;
				if (value.IsPresent())
				{
					dictionary.Add(runtimeProperty.Name, value);
				}
			}
			return dictionary;
		}

		public static Dictionary<string, string> Merge(Dictionary<string, string> explicitValues, Dictionary<string, string> additionalValues = null)
		{
			Dictionary<string, string> result = explicitValues;
			if (additionalValues != null)
			{
				result = explicitValues.Concat(additionalValues.Where((KeyValuePair<string, string> add) => !explicitValues.ContainsKey(add.Key))).ToDictionary((KeyValuePair<string, string> final) => final.Key, (KeyValuePair<string, string> final) => final.Value);
			}
			return result;
		}
	}
}
namespace IdentityModel.Client
{
	public sealed class AuthorityUrlValidationStrategy : IAuthorityValidationStrategy
	{
		public AuthorityValidationResult IsIssuerNameValid(string issuerName, string expectedAuthority)
		{
			if (!Uri.TryCreate(expectedAuthority.RemoveTrailingSlash(), UriKind.Absolute, out var result))
			{
				throw new ArgumentOutOfRangeException("Authority must be a valid URL.", "expectedAuthority");
			}
			if (string.IsNullOrWhiteSpace(issuerName))
			{
				return AuthorityValidationResult.CreateError("Issuer name is missing");
			}
			if (!Uri.TryCreate(issuerName.RemoveTrailingSlash(), UriKind.Absolute, out var result2))
			{
				return AuthorityValidationResult.CreateError("Issuer name is not a valid URL");
			}
			if (result.Equals(result2))
			{
				return AuthorityValidationResult.SuccessResult;
			}
			return AuthorityValidationResult.CreateError("Issuer name does not match authority: " + issuerName);
		}

		public AuthorityValidationResult IsEndpointValid(string endpoint, IEnumerable<string> allowedAuthorities)
		{
			if (string.IsNullOrEmpty(endpoint))
			{
				return AuthorityValidationResult.CreateError("endpoint is empty");
			}
			if (!Uri.TryCreate(endpoint.RemoveTrailingSlash(), UriKind.Absolute, out var result))
			{
				return AuthorityValidationResult.CreateError("Endpoint is not a valid URL");
			}
			foreach (string allowedAuthority in allowedAuthorities)
			{
				if (!Uri.TryCreate(allowedAuthority.RemoveTrailingSlash(), UriKind.Absolute, out var result2))
				{
					throw new ArgumentOutOfRangeException("Authority must be a URL.", "allowedAuthorities");
				}
				string value = result2.ToString();
				if (result.ToString().StartsWith(value, StringComparison.Ordinal))
				{
					return AuthorityValidationResult.SuccessResult;
				}
			}
			return AuthorityValidationResult.CreateError("Endpoint belongs to different authority: " + endpoint);
		}
	}
	public struct AuthorityValidationResult
	{
		public static readonly AuthorityValidationResult SuccessResult = new AuthorityValidationResult(success: true, null);

		public string ErrorMessage { get; }

		public bool Success { get; }

		private AuthorityValidationResult(bool success, string message)
		{
			if (!success && string.IsNullOrEmpty(message))
			{
				throw new ArgumentException("A message must be provided if success=false.", "message");
			}
			ErrorMessage = message;
			Success = success;
		}

		public static AuthorityValidationResult CreateError(string message)
		{
			return new AuthorityValidationResult(success: false, message);
		}

		public override string ToString()
		{
			if (!Success)
			{
				return ErrorMessage;
			}
			return "success";
		}
	}
	public enum BasicAuthenticationHeaderStyle
	{
		Rfc6749,
		Rfc2617
	}
	public enum ClientCredentialStyle
	{
		AuthorizationHeader,
		PostBody
	}
	public class TokenClientOptions : ClientOptions
	{
	}
	public class IntrospectionClientOptions : ClientOptions
	{
	}
	public abstract class ClientOptions
	{
		public string Address { get; set; }

		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		public ClientAssertion ClientAssertion { get; set; } = new ClientAssertion();

		public ClientCredentialStyle ClientCredentialStyle { get; set; } = ClientCredentialStyle.PostBody;

		public BasicAuthenticationHeaderStyle AuthorizationHeaderStyle { get; set; }

		public IDictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
	}
	public class DiscoveryCache : IDiscoveryCache
	{
		private DateTime _nextReload = DateTime.MinValue;

		private AsyncLazy<DiscoveryDocumentResponse> _lazyResponse;

		private readonly DiscoveryPolicy _policy;

		private readonly Func<HttpMessageInvoker> _getHttpClient;

		private readonly string _authority;

		public TimeSpan CacheDuration { get; set; } = TimeSpan.FromHours(24.0);

		public DiscoveryCache(string authority, DiscoveryPolicy policy = null)
		{
			_authority = authority;
			_policy = policy ?? new DiscoveryPolicy();
			_getHttpClient = () => new HttpClient();
		}

		public DiscoveryCache(string authority, Func<HttpMessageInvoker> httpClientFunc, DiscoveryPolicy policy = null)
		{
			_authority = authority;
			_policy = policy ?? new DiscoveryPolicy();
			_getHttpClient = httpClientFunc ?? throw new ArgumentNullException("httpClientFunc");
		}

		public Task<DiscoveryDocumentResponse> GetAsync()
		{
			if (_nextReload <= DateTime.UtcNow)
			{
				Refresh();
			}
			return _lazyResponse.Value;
		}

		public void Refresh()
		{
			_lazyResponse = new AsyncLazy<DiscoveryDocumentResponse>(GetResponseAsync);
		}

		private async Task<DiscoveryDocumentResponse> GetResponseAsync()
		{
			DiscoveryDocumentResponse obj = await _getHttpClient().GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address = _authority,
				Policy = _policy
			}).ConfigureAwait();
			if (obj.IsError)
			{
				Refresh();
				_nextReload = DateTime.MinValue;
			}
			else
			{
				_nextReload = DateTime.UtcNow.Add(CacheDuration);
			}
			return obj;
		}
	}
	public class DiscoveryEndpoint
	{
		public string Authority { get; }

		public string Url { get; }

		public static DiscoveryEndpoint ParseUrl(string input)
		{
			if (!Uri.TryCreate(input, UriKind.Absolute, out var result))
			{
				throw new InvalidOperationException("Malformed URL");
			}
			if (!IsValidScheme(result))
			{
				throw new InvalidOperationException("Malformed URL");
			}
			string text = input.RemoveTrailingSlash();
			if (text.EndsWith(".well-known/openid-configuration", StringComparison.OrdinalIgnoreCase))
			{
				return new DiscoveryEndpoint(text.Substring(0, text.Length - ".well-known/openid-configuration".Length - 1), text);
			}
			return new DiscoveryEndpoint(text, text.EnsureTrailingSlash() + ".well-known/openid-configuration");
		}

		public static bool IsValidScheme(Uri url)
		{
			if (string.Equals(url.Scheme, "http", StringComparison.OrdinalIgnoreCase) || string.Equals(url.Scheme, "https", StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return false;
		}

		public static bool IsSecureScheme(Uri url, DiscoveryPolicy policy)
		{
			if (policy.RequireHttps)
			{
				if (policy.AllowHttpOnLoopback)
				{
					string dnsSafeHost = url.DnsSafeHost;
					foreach (string loopbackAddress in policy.LoopbackAddresses)
					{
						if (string.Equals(dnsSafeHost, loopbackAddress, StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
					}
				}
				return string.Equals(url.Scheme, "https", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		public DiscoveryEndpoint(string authority, string url)
		{
			Authority = authority;
			Url = url;
		}
	}
	public class DiscoveryPolicy
	{
		internal static readonly IAuthorityValidationStrategy DefaultAuthorityValidationStrategy = new StringComparisonAuthorityValidationStrategy();

		public ICollection<string> LoopbackAddresses = new HashSet<string> { "localhost", "127.0.0.1" };

		public string Authority { get; set; }

		public IAuthorityValidationStrategy AuthorityValidationStrategy { get; set; } = DefaultAuthorityValidationStrategy;

		public bool RequireHttps { get; set; } = true;

		public bool AllowHttpOnLoopback { get; set; } = true;

		public bool ValidateIssuerName { get; set; } = true;

		public bool ValidateEndpoints { get; set; } = true;

		public ICollection<string> EndpointValidationExcludeList { get; set; } = new HashSet<string>();

		public ICollection<string> AdditionalEndpointBaseAddresses { get; set; } = new HashSet<string>();

		public bool RequireKeySet { get; set; } = true;
	}
	public static class AuthorizationHeaderExtensions
	{
		public static void SetBasicAuthentication(this HttpClient client, string userName, string password)
		{
			client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(userName, password);
		}

		public static void SetBasicAuthenticationOAuth(this HttpClient client, string userName, string password)
		{
			client.DefaultRequestHeaders.Authorization = new BasicAuthenticationOAuthHeaderValue(userName, password);
		}

		public static void SetToken(this HttpClient client, string scheme, string token)
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);
		}

		public static void SetBearerToken(this HttpClient client, string token)
		{
			client.SetToken("Bearer", token);
		}

		public static void SetBasicAuthentication(this HttpRequestMessage request, string userName, string password)
		{
			request.Headers.Authorization = new BasicAuthenticationHeaderValue(userName, password);
		}

		public static void SetBasicAuthenticationOAuth(this HttpRequestMessage request, string userName, string password)
		{
			request.Headers.Authorization = new BasicAuthenticationOAuthHeaderValue(userName, password);
		}

		public static void SetToken(this HttpRequestMessage request, string scheme, string token)
		{
			request.Headers.Authorization = new AuthenticationHeaderValue(scheme, token);
		}

		public static void SetBearerToken(this HttpRequestMessage request, string token)
		{
			request.SetToken("Bearer", token);
		}
	}
	public static class HttpClientDeviceFlowExtensions
	{
		public static async Task<DeviceAuthorizationResponse> RequestDeviceAuthorizationAsync(this HttpMessageInvoker client, DeviceAuthorizationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest protocolRequest = request.Clone();
			protocolRequest.Parameters.AddOptional("scope", request.Scope);
			protocolRequest.Method = HttpMethod.Post;
			protocolRequest.Prepare();
			HttpResponseMessage httpResponse;
			try
			{
				httpResponse = await client.SendAsync(protocolRequest, cancellationToken).ConfigureAwait();
			}
			catch (Exception ex)
			{
				return ProtocolResponse.FromException<DeviceAuthorizationResponse>(ex);
			}
			return await ProtocolResponse.FromHttpResponseAsync<DeviceAuthorizationResponse>(httpResponse).ConfigureAwait();
		}
	}
	public static class HttpClientDiscoveryExtensions
	{
		public static async Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync(this HttpClient client, string address = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address = address
			}, cancellationToken).ConfigureAwait();
		}

		public static async Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync(this HttpMessageInvoker client, DiscoveryDocumentRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			string input;
			if (request.Address.IsPresent())
			{
				input = request.Address;
			}
			else
			{
				if (!(client is HttpClient))
				{
					throw new ArgumentException("An address is required.");
				}
				input = ((HttpClient)client).BaseAddress.AbsoluteUri;
			}
			DiscoveryEndpoint discoveryEndpoint = DiscoveryEndpoint.ParseUrl(input);
			string authority = discoveryEndpoint.Authority;
			string url = discoveryEndpoint.Url;
			if (request.Policy.Authority.IsMissing())
			{
				request.Policy.Authority = authority;
			}
			string jwkUrl = "";
			if (!DiscoveryEndpoint.IsSecureScheme(new Uri(url), request.Policy))
			{
				return ProtocolResponse.FromException<DiscoveryDocumentResponse>(new InvalidOperationException("HTTPS required"), "Error connecting to " + url + ". HTTPS required.");
			}
			try
			{
				ProtocolRequest protocolRequest = request.Clone();
				protocolRequest.Method = HttpMethod.Get;
				protocolRequest.Prepare();
				protocolRequest.RequestUri = new Uri(url);
				HttpResponseMessage response = await client.SendAsync(protocolRequest, cancellationToken).ConfigureAwait();
				if (response.Content != null)
				{
					await response.Content.ReadAsStringAsync().ConfigureAwait();
				}
				if (!response.IsSuccessStatusCode)
				{
					return await ProtocolResponse.FromHttpResponseAsync<DiscoveryDocumentResponse>(response, "Error connecting to " + url + ": " + response.ReasonPhrase).ConfigureAwait();
				}
				DiscoveryDocumentResponse disco = await ProtocolResponse.FromHttpResponseAsync<DiscoveryDocumentResponse>(response, request.Policy).ConfigureAwait();
				if (disco.IsError)
				{
					return disco;
				}
				try
				{
					jwkUrl = disco.JwksUri;
					if (jwkUrl != null)
					{
						JsonWebKeySetRequest jsonWebKeySetRequest = request.Clone<JsonWebKeySetRequest>();
						jsonWebKeySetRequest.Method = HttpMethod.Get;
						jsonWebKeySetRequest.Address = jwkUrl;
						jsonWebKeySetRequest.Prepare();
						JsonWebKeySetResponse jsonWebKeySetResponse = await client.GetJsonWebKeySetAsync(jsonWebKeySetRequest, cancellationToken).ConfigureAwait();
						if (jsonWebKeySetResponse.IsError)
						{
							return await ProtocolResponse.FromHttpResponseAsync<DiscoveryDocumentResponse>(jsonWebKeySetResponse.HttpResponse, "Error connecting to " + jwkUrl + ": " + jsonWebKeySetResponse.HttpErrorReason).ConfigureAwait();
						}
						disco.KeySet = jsonWebKeySetResponse.KeySet;
					}
					return disco;
				}
				catch (Exception ex)
				{
					return ProtocolResponse.FromException<DiscoveryDocumentResponse>(ex, "Error connecting to " + jwkUrl + ". " + ex.Message + ".");
				}
			}
			catch (Exception ex2)
			{
				return ProtocolResponse.FromException<DiscoveryDocumentResponse>(ex2, "Error connecting to " + url + ". " + ex2.Message + ".");
			}
		}
	}
	public static class HttpClientDynamicRegistrationExtensions
	{
		public static async Task<DynamicClientRegistrationResponse> RegisterClientAsync(this HttpMessageInvoker client, DynamicClientRegistrationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest protocolRequest = request.Clone();
			protocolRequest.Method = HttpMethod.Post;
			protocolRequest.Content = new StringContent(JsonConvert.SerializeObject(request.Document), Encoding.UTF8, "application/json");
			protocolRequest.Prepare();
			if (request.Token.IsPresent())
			{
				protocolRequest.SetBearerToken(request.Token);
			}
			HttpResponseMessage httpResponse;
			try
			{
				httpResponse = await client.SendAsync(protocolRequest, cancellationToken).ConfigureAwait();
			}
			catch (Exception ex)
			{
				return ProtocolResponse.FromException<DynamicClientRegistrationResponse>(ex);
			}
			return await ProtocolResponse.FromHttpResponseAsync<DynamicClientRegistrationResponse>(httpResponse).ConfigureAwait();
		}
	}
	public static class HttpClientJsonWebKeySetExtensions
	{
		public static async Task<JsonWebKeySetResponse> GetJsonWebKeySetAsync(this HttpMessageInvoker client, string address = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await client.GetJsonWebKeySetAsync(new JsonWebKeySetRequest
			{
				Address = address
			}, cancellationToken).ConfigureAwait();
		}

		public static async Task<JsonWebKeySetResponse> GetJsonWebKeySetAsync(this HttpMessageInvoker client, JsonWebKeySetRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest clone = request.Clone();
			clone.Method = HttpMethod.Get;
			clone.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/jwk-set+json"));
			clone.Prepare();
			HttpResponseMessage response;
			try
			{
				response = await client.SendAsync(clone, cancellationToken).ConfigureAwait();
				if (response.Content != null)
				{
					await response.Content.ReadAsStringAsync().ConfigureAwait();
				}
				if (!response.IsSuccessStatusCode)
				{
					return await ProtocolResponse.FromHttpResponseAsync<JsonWebKeySetResponse>(response, "Error connecting to " + clone.RequestUri.AbsoluteUri + ": " + response.ReasonPhrase).ConfigureAwait();
				}
			}
			catch (Exception ex)
			{
				return ProtocolResponse.FromException<JsonWebKeySetResponse>(ex, "Error connecting to " + clone.RequestUri.AbsoluteUri + ". " + ex.Message + ".");
			}
			return await ProtocolResponse.FromHttpResponseAsync<JsonWebKeySetResponse>(response).ConfigureAwait();
		}
	}
	public static class HttpClientTokenIntrospectionExtensions
	{
		public static async Task<TokenIntrospectionResponse> IntrospectTokenAsync(this HttpMessageInvoker client, TokenIntrospectionRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest protocolRequest = request.Clone();
			protocolRequest.Method = HttpMethod.Post;
			protocolRequest.Parameters.AddRequired("token", request.Token);
			protocolRequest.Parameters.AddOptional("token_type_hint", request.TokenTypeHint);
			protocolRequest.Prepare();
			HttpResponseMessage httpResponse;
			try
			{
				httpResponse = await client.SendAsync(protocolRequest, cancellationToken).ConfigureAwait();
			}
			catch (Exception ex)
			{
				return ProtocolResponse.FromException<TokenIntrospectionResponse>(ex);
			}
			return await ProtocolResponse.FromHttpResponseAsync<TokenIntrospectionResponse>(httpResponse).ConfigureAwait();
		}
	}
	public static class HttpClientTokenRequestExtensions
	{
		public static async Task<TokenResponse> RequestClientCredentialsTokenAsync(this HttpMessageInvoker client, ClientCredentialsTokenRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest protocolRequest = request.Clone();
			protocolRequest.Parameters.AddRequired("grant_type", "client_credentials");
			protocolRequest.Parameters.AddOptional("scope", request.Scope);
			return await client.RequestTokenAsync(protocolRequest, cancellationToken).ConfigureAwait();
		}

		public static async Task<TokenResponse> RequestDeviceTokenAsync(this HttpMessageInvoker client, DeviceTokenRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest protocolRequest = request.Clone();
			protocolRequest.Parameters.AddRequired("grant_type", "urn:ietf:params:oauth:grant-type:device_code");
			protocolRequest.Parameters.AddRequired("device_code", request.DeviceCode);
			return await client.RequestTokenAsync(protocolRequest, cancellationToken).ConfigureAwait();
		}

		public static async Task<TokenResponse> RequestPasswordTokenAsync(this HttpMessageInvoker client, PasswordTokenRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest protocolRequest = request.Clone();
			protocolRequest.Parameters.AddRequired("grant_type", "password");
			protocolRequest.Parameters.AddRequired("username", request.UserName);
			protocolRequest.Parameters.AddRequired("password", request.Password, allowEmpty: true);
			protocolRequest.Parameters.AddOptional("scope", request.Scope);
			return await client.RequestTokenAsync(protocolRequest, cancellationToken).ConfigureAwait();
		}

		public static async Task<TokenResponse> RequestAuthorizationCodeTokenAsync(this HttpMessageInvoker client, AuthorizationCodeTokenRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest protocolRequest = request.Clone();
			protocolRequest.Parameters.AddRequired("grant_type", "authorization_code");
			protocolRequest.Parameters.AddRequired("code", request.Code);
			protocolRequest.Parameters.AddRequired("redirect_uri", request.RedirectUri);
			protocolRequest.Parameters.AddOptional("code_verifier", request.CodeVerifier);
			return await client.RequestTokenAsync(protocolRequest, cancellationToken).ConfigureAwait();
		}

		public static async Task<TokenResponse> RequestRefreshTokenAsync(this HttpMessageInvoker client, RefreshTokenRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest protocolRequest = request.Clone();
			protocolRequest.Parameters.AddRequired("grant_type", "refresh_token");
			protocolRequest.Parameters.AddRequired("refresh_token", request.RefreshToken);
			protocolRequest.Parameters.AddOptional("scope", request.Scope);
			return await client.RequestTokenAsync(protocolRequest, cancellationToken).ConfigureAwait();
		}

		public static async Task<TokenResponse> RequestTokenAsync(this HttpMessageInvoker client, TokenRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest protocolRequest = request.Clone();
			if (!protocolRequest.Parameters.ContainsKey("grant_type"))
			{
				protocolRequest.Parameters.AddRequired("grant_type", request.GrantType);
			}
			return await client.RequestTokenAsync(protocolRequest, cancellationToken).ConfigureAwait();
		}

		public static async Task<TokenResponse> RequestTokenRawAsync(this HttpMessageInvoker client, string address, IDictionary<string, string> parameters, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (parameters == null)
			{
				throw new ArgumentNullException("parameters");
			}
			TokenRequest request = new TokenRequest
			{
				Address = address,
				Parameters = parameters
			};
			return await client.RequestTokenAsync(request, cancellationToken).ConfigureAwait();
		}

		internal static async Task<TokenResponse> RequestTokenAsync(this HttpMessageInvoker client, ProtocolRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			request.Prepare();
			request.Method = HttpMethod.Post;
			HttpResponseMessage httpResponse;
			try
			{
				httpResponse = await client.SendAsync(request, cancellationToken).ConfigureAwait();
			}
			catch (Exception ex)
			{
				return ProtocolResponse.FromException<TokenResponse>(ex);
			}
			return await ProtocolResponse.FromHttpResponseAsync<TokenResponse>(httpResponse).ConfigureAwait();
		}
	}
	public static class HttpClientTokenRevocationExtensions
	{
		public static async Task<TokenRevocationResponse> RevokeTokenAsync(this HttpMessageInvoker client, TokenRevocationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			ProtocolRequest protocolRequest = request.Clone();
			protocolRequest.Method = HttpMethod.Post;
			protocolRequest.Parameters.AddRequired("token", request.Token);
			protocolRequest.Parameters.AddOptional("token_type_hint", request.TokenTypeHint);
			protocolRequest.Prepare();
			HttpResponseMessage httpResponse;
			try
			{
				httpResponse = await client.SendAsync(protocolRequest, cancellationToken).ConfigureAwait();
			}
			catch (Exception ex)
			{
				return ProtocolResponse.FromException<TokenRevocationResponse>(ex);
			}
			return await ProtocolResponse.FromHttpResponseAsync<TokenRevocationResponse>(httpResponse).ConfigureAwait();
		}
	}
	public static class HttpClientUserInfoExtensions
	{
		public static async Task<UserInfoResponse> GetUserInfoAsync(this HttpMessageInvoker client, UserInfoRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (request.Token.IsMissing())
			{
				throw new ArgumentNullException("Token");
			}
			ProtocolRequest protocolRequest = request.Clone();
			protocolRequest.Method = HttpMethod.Get;
			protocolRequest.SetBearerToken(request.Token);
			protocolRequest.Prepare();
			HttpResponseMessage httpResponse;
			try
			{
				httpResponse = await client.SendAsync(protocolRequest, cancellationToken).ConfigureAwait();
			}
			catch (Exception ex)
			{
				return ProtocolResponse.FromException<UserInfoResponse>(ex);
			}
			return await ProtocolResponse.FromHttpResponseAsync<UserInfoResponse>(httpResponse).ConfigureAwait();
		}
	}
	public static class JObjectExtensions
	{
		public static IEnumerable<Claim> ToClaims(this JObject json, params string[] excludeKeys)
		{
			List<Claim> list = new List<Claim>();
			List<string> list2 = excludeKeys.ToList();
			foreach (KeyValuePair<string, JToken> item in json)
			{
				if (list2.Contains(item.Key))
				{
					continue;
				}
				if (item.Value is JArray jArray)
				{
					foreach (JToken item2 in jArray)
					{
						list.Add(new Claim(item.Key, Stringify(item2)));
					}
				}
				else
				{
					list.Add(new Claim(item.Key, Stringify(item.Value)));
				}
			}
			return list;
		}

		private static string Stringify(JToken item)
		{
			if (item.Type != JTokenType.String)
			{
				return item.ToString(Formatting.None);
			}
			return item.ToString();
		}

		public static JToken TryGetValue(this JObject json, string name)
		{
			if (json != null && json.TryGetValue(name, StringComparison.OrdinalIgnoreCase, out JToken value))
			{
				return value;
			}
			return null;
		}

		public static int? TryGetInt(this JObject json, string name)
		{
			string text = json.TryGetString(name);
			if (text != null && int.TryParse(text, out var result))
			{
				return result;
			}
			return null;
		}

		public static string TryGetString(this JObject json, string name)
		{
			return json.TryGetValue(name)?.ToString();
		}

		public static bool? TryGetBoolean(this JObject json, string name)
		{
			if (bool.TryParse(json.TryGetString(name), out var result))
			{
				return result;
			}
			return null;
		}

		public static IEnumerable<string> TryGetStringArray(this JObject json, string name)
		{
			List<string> list = new List<string>();
			if (json.TryGetValue(name) is JArray jArray)
			{
				foreach (JToken item in jArray)
				{
					list.Add(item.ToString());
				}
			}
			return list;
		}
	}
	public static class RequestUrlExtensions
	{
		public static string Create(this RequestUrl request, object values)
		{
			return request.Create(ValuesHelper.ObjectToDictionary(values));
		}

		public static string CreateAuthorizeUrl(this RequestUrl request, string clientId, string responseType, string scope = null, string redirectUri = null, string state = null, string nonce = null, string loginHint = null, string acrValues = null, string prompt = null, string responseMode = null, string codeChallenge = null, string codeChallengeMethod = null, string display = null, int? maxAge = null, string uiLocales = null, string idTokenHint = null, object extra = null)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				{ "client_id", clientId },
				{ "response_type", responseType }
			};
			dictionary.AddOptional("scope", scope);
			dictionary.AddOptional("redirect_uri", redirectUri);
			dictionary.AddOptional("state", state);
			dictionary.AddOptional("nonce", nonce);
			dictionary.AddOptional("login_hint", loginHint);
			dictionary.AddOptional("acr_values", acrValues);
			dictionary.AddOptional("prompt", prompt);
			dictionary.AddOptional("response_mode", responseMode);
			dictionary.AddOptional("code_challenge", codeChallenge);
			dictionary.AddOptional("code_challenge_method", codeChallengeMethod);
			dictionary.AddOptional("display", display);
			dictionary.AddOptional("max_age", maxAge?.ToString());
			dictionary.AddOptional("ui_locales", uiLocales);
			dictionary.AddOptional("id_token_hint", idTokenHint);
			return request.Create(ValuesHelper.Merge(dictionary, ValuesHelper.ObjectToDictionary(extra)));
		}

		public static string CreateEndSessionUrl(this RequestUrl request, string idTokenHint = null, string postLogoutRedirectUri = null, string state = null, object extra = null)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.AddOptional("id_token_hint", idTokenHint);
			dictionary.AddOptional("post_logout_redirect_uri", postLogoutRedirectUri);
			dictionary.AddOptional("state", state);
			return request.Create(ValuesHelper.Merge(dictionary, ValuesHelper.ObjectToDictionary(extra)));
		}
	}
	public interface IAuthorityValidationStrategy
	{
		AuthorityValidationResult IsIssuerNameValid(string issuerName, string expectedAuthority);

		AuthorityValidationResult IsEndpointValid(string endpoint, IEnumerable<string> expectedAuthority);
	}
	public interface IDiscoveryCache
	{
		TimeSpan CacheDuration { get; set; }

		Task<DiscoveryDocumentResponse> GetAsync();

		void Refresh();
	}
	public class IntrospectionClient
	{
		private readonly Func<HttpMessageInvoker> _client;

		private readonly IntrospectionClientOptions _options;

		public IntrospectionClient(HttpMessageInvoker client, IntrospectionClientOptions options)
			: this(() => client, options)
		{
		}

		public IntrospectionClient(Func<HttpMessageInvoker> client, IntrospectionClientOptions options)
		{
			_client = client ?? throw new ArgumentNullException("client");
			_options = options ?? throw new ArgumentNullException("options");
		}

		internal void ApplyRequestParameters(TokenIntrospectionRequest request, IDictionary<string, string> parameters)
		{
			request.Address = _options.Address;
			request.ClientId = _options.ClientId;
			request.ClientSecret = _options.ClientSecret;
			request.ClientAssertion = _options.ClientAssertion;
			request.ClientCredentialStyle = _options.ClientCredentialStyle;
			request.AuthorizationHeaderStyle = _options.AuthorizationHeaderStyle;
			request.Parameters = _options.Parameters;
			if (parameters == null)
			{
				return;
			}
			foreach (KeyValuePair<string, string> parameter in parameters)
			{
				request.Parameters.Add(parameter);
			}
		}

		public Task<TokenIntrospectionResponse> Introspect(string token, string tokenTypeHint = null, IDictionary<string, string> parameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			TokenIntrospectionRequest request = new TokenIntrospectionRequest
			{
				Token = token,
				TokenTypeHint = tokenTypeHint
			};
			ApplyRequestParameters(request, parameters);
			return _client().IntrospectTokenAsync(request, cancellationToken);
		}
	}
	public class AuthorizeResponse
	{
		public string Raw { get; }

		public Dictionary<string, string> Values { get; } = new Dictionary<string, string>();

		public string Code => TryGet("code");

		public string AccessToken => TryGet("access_token");

		public string IdentityToken => TryGet("id_token");

		public string Error => TryGet("error");

		public string Scope => TryGet("scope");

		public string TokenType => TryGet("token_type");

		public string State => TryGet("state");

		public string ErrorDescription => TryGet("error_description");

		public bool IsError => Error.IsPresent();

		public int ExpiresIn
		{
			get
			{
				int.TryParse(TryGet("expires_in"), out var result);
				return result;
			}
		}

		public AuthorizeResponse(string raw)
		{
			Raw = raw;
			ParseRaw();
		}

		private void ParseRaw()
		{
			string[] array;
			if (!Raw.Contains("?"))
			{
				array = ((!Raw.Contains("#")) ? new string[2] { "", Raw } : Raw.Split(new char[1] { '#' }));
			}
			else
			{
				array = Raw.Split(new char[1] { '?' });
				int num = array[1].IndexOf('#');
				if (num >= 0)
				{
					array[1] = array[1].Substring(0, num);
				}
			}
			string[] array2 = array[1].Split(new char[1] { '&' });
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(new char[1] { '=' });
				if (array3.Length == 2)
				{
					Values.Add(array3[0], array3[1]);
					continue;
				}
				throw new InvalidOperationException("Malformed callback URL.");
			}
		}

		public string TryGet(string type)
		{
			if (Values.TryGetValue(type, out var value))
			{
				return WebUtility.UrlDecode(value);
			}
			return null;
		}
	}
	public class DeviceAuthorizationRequest : ProtocolRequest
	{
		public string Scope { get; set; }
	}
	public class DeviceAuthorizationResponse : ProtocolResponse
	{
		public string DeviceCode => base.Json.TryGetString("device_code");

		public string UserCode => base.Json.TryGetString("user_code");

		public string VerificationUri => base.Json.TryGetString("verification_uri");

		public string VerificationUriComplete => base.Json.TryGetString("verification_uri_complete");

		public int? ExpiresIn => base.Json.TryGetInt("expires_in");

		public int Interval => base.Json.TryGetInt("interval") ?? 5;

		public string ErrorDescription => base.Json.TryGetString("error_description");
	}
	public class DiscoveryDocumentRequest : ProtocolRequest
	{
		public DiscoveryPolicy Policy { get; set; } = new DiscoveryPolicy();
	}
	public class DiscoveryDocumentResponse : ProtocolResponse
	{
		public DiscoveryPolicy Policy { get; set; }

		public JsonWebKeySet KeySet { get; set; }

		public string Issuer => TryGetString("issuer");

		public string AuthorizeEndpoint => TryGetString("authorization_endpoint");

		public string TokenEndpoint => TryGetString("token_endpoint");

		public string UserInfoEndpoint => TryGetString("userinfo_endpoint");

		public string IntrospectionEndpoint => TryGetString("introspection_endpoint");

		public string RevocationEndpoint => TryGetString("revocation_endpoint");

		public string DeviceAuthorizationEndpoint => TryGetString("device_authorization_endpoint");

		public string JwksUri => TryGetString("jwks_uri");

		public string EndSessionEndpoint => TryGetString("end_session_endpoint");

		public string CheckSessionIframe => TryGetString("check_session_iframe");

		public string RegistrationEndpoint => TryGetString("registration_endpoint");

		public bool? FrontChannelLogoutSupported => TryGetBoolean("frontchannel_logout_supported");

		public bool? FrontChannelLogoutSessionSupported => TryGetBoolean("frontchannel_logout_session_supported");

		public IEnumerable<string> GrantTypesSupported => TryGetStringArray("grant_types_supported");

		public IEnumerable<string> CodeChallengeMethodsSupported => TryGetStringArray("code_challenge_methods_supported");

		public IEnumerable<string> ScopesSupported => TryGetStringArray("scopes_supported");

		public IEnumerable<string> SubjectTypesSupported => TryGetStringArray("subject_types_supported");

		public IEnumerable<string> ResponseModesSupported => TryGetStringArray("response_modes_supported");

		public IEnumerable<string> ResponseTypesSupported => TryGetStringArray("response_types_supported");

		public IEnumerable<string> ClaimsSupported => TryGetStringArray("claims_supported");

		public IEnumerable<string> TokenEndpointAuthenticationMethodsSupported => TryGetStringArray("token_endpoint_auth_methods_supported");

		protected override Task InitializeAsync(object initializationData = null)
		{
			if (!base.HttpResponse.IsSuccessStatusCode)
			{
				base.ErrorMessage = initializationData as string;
				return Task.CompletedTask;
			}
			Policy = (initializationData as DiscoveryPolicy) ?? new DiscoveryPolicy();
			string text = Validate(Policy);
			if (text.IsPresent())
			{
				base.Json = null;
				base.ErrorType = ResponseErrorType.PolicyViolation;
				base.ErrorMessage = text;
			}
			return Task.CompletedTask;
		}

		public JToken TryGetValue(string name)
		{
			return base.Json.TryGetValue(name);
		}

		public string TryGetString(string name)
		{
			return base.Json.TryGetString(name);
		}

		public bool? TryGetBoolean(string name)
		{
			return base.Json.TryGetBoolean(name);
		}

		public IEnumerable<string> TryGetStringArray(string name)
		{
			return base.Json.TryGetStringArray(name);
		}

		private string Validate(DiscoveryPolicy policy)
		{
			if (policy.ValidateIssuerName)
			{
				AuthorityValidationResult authorityValidationResult = (policy.AuthorityValidationStrategy ?? DiscoveryPolicy.DefaultAuthorityValidationStrategy).IsIssuerNameValid(Issuer, policy.Authority);
				if (!authorityValidationResult.Success)
				{
					return authorityValidationResult.ErrorMessage;
				}
			}
			string text = ValidateEndpoints(base.Json, policy);
			if (text.IsPresent())
			{
				return text;
			}
			return string.Empty;
		}

		public bool ValidateIssuerName(string issuer, string authority)
		{
			return DiscoveryPolicy.DefaultAuthorityValidationStrategy.IsIssuerNameValid(issuer, authority).Success;
		}

		public bool ValidateIssuerName(string issuer, string authority, StringComparison nameComparison)
		{
			return new StringComparisonAuthorityValidationStrategy(nameComparison).IsIssuerNameValid(issuer, authority).Success;
		}

		private bool ValidateIssuerName(string issuer, string authority, IAuthorityValidationStrategy validationStrategy)
		{
			return validationStrategy.IsIssuerNameValid(issuer, authority).Success;
		}

		public string ValidateEndpoints(JObject json, DiscoveryPolicy policy)
		{
			HashSet<string> hashSet = new HashSet<string>(policy.AdditionalEndpointBaseAddresses.Select((string e) => new Uri(e).Authority)) { new Uri(policy.Authority).Authority };
			HashSet<string> expectedAuthority = new HashSet<string>(policy.AdditionalEndpointBaseAddresses) { policy.Authority };
			foreach (KeyValuePair<string, JToken> item in json)
			{
				if (!item.Key.EndsWith("endpoint", StringComparison.OrdinalIgnoreCase) && !item.Key.Equals("jwks_uri", StringComparison.OrdinalIgnoreCase) && !item.Key.Equals("check_session_iframe", StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				string text = item.Value.ToString();
				if (!Uri.TryCreate(text, UriKind.Absolute, out var result))
				{
					return "Malformed endpoint: " + text;
				}
				if (!DiscoveryEndpoint.IsValidScheme(result))
				{
					return "Malformed endpoint: " + text;
				}
				if (!DiscoveryEndpoint.IsSecureScheme(result, policy))
				{
					return "Endpoint does not use HTTPS: " + text;
				}
				if (!policy.ValidateEndpoints || policy.EndpointValidationExcludeList.Contains(item.Key))
				{
					continue;
				}
				bool flag = false;
				foreach (string item2 in hashSet)
				{
					if (string.Equals(item2, result.Authority))
					{
						flag = true;
					}
				}
				if (!flag)
				{
					return "Endpoint is on a different host than authority: " + text;
				}
				AuthorityValidationResult authorityValidationResult = (policy.AuthorityValidationStrategy ?? DiscoveryPolicy.DefaultAuthorityValidationStrategy).IsEndpointValid(text, expectedAuthority);
				if (!authorityValidationResult.Success)
				{
					return authorityValidationResult.ErrorMessage;
				}
			}
			if (policy.RequireKeySet && string.IsNullOrWhiteSpace(JwksUri))
			{
				return "Keyset is missing";
			}
			return string.Empty;
		}
	}
	public class DynamicClientRegistrationDocument
	{
		[JsonProperty(PropertyName = "redirect_uris", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public ICollection<string> RedirectUris { get; set; } = new HashSet<string>();

		[JsonProperty(PropertyName = "response_types", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public ICollection<string> ResponseTypes { get; set; } = new HashSet<string>();

		[JsonProperty(PropertyName = "grant_types", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public ICollection<string> GrantTypes { get; set; } = new HashSet<string>();

		[JsonProperty(PropertyName = "application_type", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string ApplicationType { get; set; }

		[JsonProperty(PropertyName = "contacts", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public ICollection<string> Contacts { get; set; } = new HashSet<string>();

		[JsonProperty(PropertyName = "client_name", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string ClientName { get; set; }

		[JsonProperty(PropertyName = "logo_uri", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string LogoUri { get; set; }

		[JsonProperty(PropertyName = "client_uri", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string ClientUri { get; set; }

		[JsonProperty(PropertyName = "policy_uri", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string PolicyUri { get; set; }

		[JsonProperty(PropertyName = "tos_uri", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string TosUri { get; set; }

		[JsonProperty(PropertyName = "jwks_uri", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string JwksUri { get; set; }

		[JsonProperty(PropertyName = "jwks", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public JsonWebKeySet Jwks { get; set; }

		[JsonProperty(PropertyName = "sector_identifier_uri", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string SectorIdentifierUri { get; set; }

		[JsonProperty(PropertyName = "subject_type", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string SubjectType { get; set; }

		[JsonProperty(PropertyName = "id_token_signed_response_alg", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string IdentityTokenSignedResponseAlgorithm { get; set; }

		[JsonProperty(PropertyName = "id_token_encrypted_response_alg", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string IdentityTokenEncryptedResponseAlgorithm { get; set; }

		[JsonProperty(PropertyName = "id_token_encrypted_response_enc", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string IdentityTokenEncryptedResponseEncryption { get; set; }

		[JsonProperty(PropertyName = "userinfo_signed_response_alg", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string UserinfoSignedResponseAlgorithm { get; set; }

		[JsonProperty(PropertyName = "userinfo_encrypted_response_alg", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string UserInfoEncryptedResponseAlgorithm { get; set; }

		[JsonProperty(PropertyName = "userinfo_encrypted_response_enc", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string UserinfoEncryptedResponseEncryption { get; set; }

		[JsonProperty(PropertyName = "request_object_signing_alg", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string RequestObjectSigningAlgorithm { get; set; }

		[JsonProperty(PropertyName = "request_object_encryption_alg", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string RequestObjectEncryptionAlgorithm { get; set; }

		[JsonProperty(PropertyName = "request_object_encryption_enc", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string RequestObjectEncryptionEncryption { get; set; }

		[JsonProperty(PropertyName = "token_endpoint_auth_method", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string TokenEndpointAuthenticationMethod { get; set; }

		[JsonProperty(PropertyName = "token_endpoint_auth_signing_alg", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string TokenEndpointAuthenticationSigningAlgorithm { get; set; }

		[JsonProperty(PropertyName = "default_max_age", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public int DefaultMaxAge { get; set; }

		[JsonProperty(PropertyName = "require_auth_time", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public bool RequireAuthenticationTime { get; set; }

		[JsonProperty(PropertyName = "default_acr_values", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public ICollection<string> DefaultAcrValues { get; set; } = new HashSet<string>();

		[JsonProperty(PropertyName = "initiate_login_uri", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public string InitiateLoginUri { get; set; }

		[JsonProperty(PropertyName = "request_uris", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
		public ICollection<string> RequestUris { get; set; } = new HashSet<string>();

		public bool ShouldSerializeRequestUris()
		{
			return RequestUris.Any();
		}

		public bool ShouldSerializeDefaultAcrValues()
		{
			return DefaultAcrValues.Any();
		}

		public bool ShouldSerializeResponseTypes()
		{
			return ResponseTypes.Any();
		}

		public bool ShouldSerializeGrantTypes()
		{
			return GrantTypes.Any();
		}

		public bool ShouldSerializeContacts()
		{
			return Contacts.Any();
		}
	}
	public class DynamicClientRegistrationRequest : ProtocolRequest
	{
		public string Token { get; set; }

		public DynamicClientRegistrationDocument Document { get; set; }
	}
	public class DynamicClientRegistrationResponse : ProtocolResponse
	{
		public string ErrorDescription => base.Json.TryGetString("error_description");

		public string ClientId => base.Json.TryGetString("client_id");

		public string ClientSecret => base.Json.TryGetString("client_secret");

		public string RegistrationAccessToken => base.Json.TryGetString("registration_access_token");

		public string RegistrationClientUri => base.Json.TryGetString("registration_client_uri");

		public int? ClientIdIssuedAt => base.Json.TryGetInt("client_id_issued_at");

		public int? ClientSecretExpiresAt => base.Json.TryGetInt("client_secret_expires_at");
	}
	public class JsonWebKeySetRequest : ProtocolRequest
	{
	}
	public class JsonWebKeySetResponse : ProtocolResponse
	{
		public JsonWebKeySet KeySet { get; set; }

		protected override Task InitializeAsync(object initializationData = null)
		{
			if (!base.HttpResponse.IsSuccessStatusCode)
			{
				base.ErrorMessage = initializationData as string;
			}
			else
			{
				KeySet = new JsonWebKeySet(base.Raw);
			}
			return Task.CompletedTask;
		}
	}
	public class ProtocolRequest : HttpRequestMessage
	{
		public string Address { get; set; }

		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		public ClientAssertion ClientAssertion { get; set; } = new ClientAssertion();

		public ClientCredentialStyle ClientCredentialStyle { get; set; } = ClientCredentialStyle.PostBody;

		public BasicAuthenticationHeaderStyle AuthorizationHeaderStyle { get; set; }

		public IDictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

		public ProtocolRequest()
		{
			base.Headers.Accept.Clear();
			base.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public ProtocolRequest Clone()
		{
			return Clone<ProtocolRequest>();
		}

		public T Clone<T>() where T : ProtocolRequest, new()
		{
			T val = new T
			{
				RequestUri = base.RequestUri,
				Version = base.Version,
				Method = base.Method,
				Address = Address,
				AuthorizationHeaderStyle = AuthorizationHeaderStyle,
				ClientAssertion = ClientAssertion,
				ClientCredentialStyle = ClientCredentialStyle,
				ClientId = ClientId,
				ClientSecret = ClientSecret,
				Parameters = new Dictionary<string, string>()
			};
			if (Parameters != null)
			{
				foreach (KeyValuePair<string, string> parameter in Parameters)
				{
					val.Parameters.Add(parameter);
				}
			}
			val.Headers.Clear();
			foreach (KeyValuePair<string, IEnumerable<string>> header in base.Headers)
			{
				val.Headers.TryAddWithoutValidation(header.Key, header.Value);
			}
			if (base.Properties != null && base.Properties.Any())
			{
				foreach (KeyValuePair<string, object> property in base.Properties)
				{
					val.Properties.Add(property);
				}
			}
			return val;
		}

		public void Prepare()
		{
			if (ClientId.IsPresent())
			{
				if (ClientCredentialStyle == ClientCredentialStyle.AuthorizationHeader)
				{
					if (AuthorizationHeaderStyle == BasicAuthenticationHeaderStyle.Rfc6749)
					{
						this.SetBasicAuthenticationOAuth(ClientId, ClientSecret ?? "");
					}
					else
					{
						if (AuthorizationHeaderStyle != BasicAuthenticationHeaderStyle.Rfc2617)
						{
							throw new InvalidOperationException("Unsupported basic authentication header style");
						}
						this.SetBasicAuthentication(ClientId, ClientSecret ?? "");
					}
				}
				else
				{
					if (ClientCredentialStyle != ClientCredentialStyle.PostBody)
					{
						throw new InvalidOperationException("Unsupported client credential style");
					}
					Parameters.AddRequired("client_id", ClientId);
					Parameters.AddOptional("client_secret", ClientSecret);
				}
			}
			if (ClientAssertion != null && ClientAssertion.Type != null && ClientAssertion.Value != null)
			{
				Parameters.AddOptional("client_assertion_type", ClientAssertion.Type);
				Parameters.AddOptional("client_assertion", ClientAssertion.Value);
			}
			if (Address.IsPresent())
			{
				base.RequestUri = new Uri(Address);
			}
			if (Parameters.Any())
			{
				base.Content = new FormUrlEncodedContent(Parameters);
			}
		}
	}
	public class ClientAssertion
	{
		public string Type { get; set; }

		public string Value { get; set; }
	}
	public class ProtocolResponse
	{
		public HttpResponseMessage HttpResponse { get; protected set; }

		public string Raw { get; protected set; }

		public JObject Json { get; protected set; }

		public Exception Exception { get; protected set; }

		public bool IsError => Error.IsPresent();

		public ResponseErrorType ErrorType { get; protected set; }

		protected string ErrorMessage { get; set; }

		public HttpStatusCode HttpStatusCode => HttpResponse.StatusCode;

		public string HttpErrorReason => HttpResponse.ReasonPhrase;

		public string Error
		{
			get
			{
				if (ErrorMessage.IsPresent())
				{
					return ErrorMessage;
				}
				if (ErrorType == ResponseErrorType.Http)
				{
					return HttpErrorReason;
				}
				if (ErrorType == ResponseErrorType.Exception)
				{
					return Exception.Message;
				}
				return TryGet("error");
			}
		}

		public static async Task<T> FromHttpResponseAsync<T>(HttpResponseMessage httpResponse, object initializationData = null) where T : ProtocolResponse, new()
		{
			T response = new T
			{
				HttpResponse = httpResponse
			};
			string content = null;
			try
			{
				content = (response.Raw = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait());
			}
			catch
			{
			}
			if (!httpResponse.IsSuccessStatusCode && httpResponse.StatusCode != HttpStatusCode.BadRequest)
			{
				response.ErrorType = ResponseErrorType.Http;
				if (content.IsPresent())
				{
					try
					{
						response.Json = JObject.Parse(content);
					}
					catch
					{
					}
				}
				await response.InitializeAsync(initializationData).ConfigureAwait();
				return response;
			}
			if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
			{
				response.ErrorType = ResponseErrorType.Protocol;
			}
			try
			{
				if (content.IsPresent())
				{
					response.Json = JObject.Parse(content);
				}
			}
			catch (Exception exception)
			{
				response.ErrorType = ResponseErrorType.Exception;
				response.Exception = exception;
			}
			await response.InitializeAsync(initializationData).ConfigureAwait();
			return response;
		}

		public static T FromException<T>(Exception ex, string errorMessage = null) where T : ProtocolResponse, new()
		{
			return new T
			{
				Exception = ex,
				ErrorType = ResponseErrorType.Exception,
				ErrorMessage = errorMessage
			};
		}

		protected virtual Task InitializeAsync(object initializationData = null)
		{
			return Task.CompletedTask;
		}

		public string TryGet(string name)
		{
			return Json.TryGetString(name);
		}
	}
	public enum ResponseErrorType
	{
		None,
		Protocol,
		Http,
		Exception,
		PolicyViolation
	}
	public class TokenIntrospectionRequest : ProtocolRequest
	{
		public string Token { get; set; }

		public string TokenTypeHint { get; set; }
	}
	public class TokenIntrospectionResponse : ProtocolResponse
	{
		public bool IsActive => base.Json.TryGetBoolean("active").Value;

		public IEnumerable<Claim> Claims { get; protected set; }

		protected override Task InitializeAsync(object initializationData = null)
		{
			if (!base.IsError)
			{
				List<Claim> list = base.Json.ToClaims("scope").ToList();
				JToken jToken = base.Json.TryGetValue("scope");
				if (jToken != null)
				{
					if (jToken is JArray jArray)
					{
						foreach (JToken item in jArray)
						{
							list.Add(new Claim("scope", item.ToString()));
						}
					}
					else
					{
						string[] array = jToken.ToString().Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						foreach (string value in array)
						{
							list.Add(new Claim("scope", value));
						}
					}
				}
				Claims = list;
			}
			else
			{
				Claims = Enumerable.Empty<Claim>();
			}
			return Task.CompletedTask;
		}
	}
	public class TokenRequest : ProtocolRequest
	{
		public string GrantType { get; set; }
	}
	public class ClientCredentialsTokenRequest : TokenRequest
	{
		public string Scope { get; set; }
	}
	public class DeviceTokenRequest : TokenRequest
	{
		public string DeviceCode { get; set; }
	}
	public class PasswordTokenRequest : TokenRequest
	{
		public string UserName { get; set; }

		public string Password { get; set; }

		public string Scope { get; set; }
	}
	public class AuthorizationCodeTokenRequest : TokenRequest
	{
		public string Code { get; set; }

		public string RedirectUri { get; set; }

		public string CodeVerifier { get; set; }
	}
	public class RefreshTokenRequest : TokenRequest
	{
		public string RefreshToken { get; set; }

		public string Scope { get; set; }
	}
	public class TokenResponse : ProtocolResponse
	{
		public string AccessToken => TryGet("access_token");

		public string IdentityToken => TryGet("id_token");

		public string TokenType => TryGet("token_type");

		public string RefreshToken => TryGet("refresh_token");

		public string ErrorDescription => TryGet("error_description");

		public int ExpiresIn
		{
			get
			{
				string text = TryGet("expires_in");
				if (text != null && int.TryParse(text, out var result))
				{
					return result;
				}
				return 0;
			}
		}
	}
	public class TokenRevocationRequest : ProtocolRequest
	{
		public string Token { get; set; }

		public string TokenTypeHint { get; set; }
	}
	public class TokenRevocationResponse : ProtocolResponse
	{
	}
	public class UserInfoRequest : ProtocolRequest
	{
		public string Token { get; set; }
	}
	public class UserInfoResponse : ProtocolResponse
	{
		public IEnumerable<Claim> Claims { get; private set; }

		protected override Task InitializeAsync(object initializationData = null)
		{
			if (!base.IsError)
			{
				Claims = base.Json.ToClaims();
			}
			else
			{
				Claims = Enumerable.Empty<Claim>();
			}
			return Task.CompletedTask;
		}
	}
	public class RequestUrl
	{
		private readonly string _baseUrl;

		public RequestUrl(string baseUrl)
		{
			_baseUrl = baseUrl;
		}

		public string Create(object values)
		{
			Dictionary<string, string> dictionary = ValuesHelper.ObjectToDictionary(values);
			if (dictionary == null || !dictionary.Any())
			{
				return _baseUrl;
			}
			return QueryHelpers.AddQueryString(_baseUrl, dictionary);
		}
	}
	public sealed class StringComparisonAuthorityValidationStrategy : IAuthorityValidationStrategy
	{
		private readonly StringComparison _stringComparison;

		public StringComparisonAuthorityValidationStrategy(StringComparison stringComparison = StringComparison.Ordinal)
		{
			_stringComparison = stringComparison;
		}

		public AuthorityValidationResult IsIssuerNameValid(string issuerName, string expectedAuthority)
		{
			if (string.IsNullOrWhiteSpace(issuerName))
			{
				return AuthorityValidationResult.CreateError("Issuer name is missing");
			}
			if (string.Equals(issuerName.RemoveTrailingSlash(), expectedAuthority.RemoveTrailingSlash(), _stringComparison))
			{
				return AuthorityValidationResult.SuccessResult;
			}
			return AuthorityValidationResult.CreateError("Issuer name does not match authority: " + issuerName);
		}

		public AuthorityValidationResult IsEndpointValid(string endpoint, IEnumerable<string> allowedAuthorities)
		{
			if (string.IsNullOrEmpty(endpoint))
			{
				return AuthorityValidationResult.CreateError("endpoint is empty");
			}
			foreach (string allowedAuthority in allowedAuthorities)
			{
				if (endpoint.StartsWith(allowedAuthority, _stringComparison))
				{
					return AuthorityValidationResult.SuccessResult;
				}
			}
			return AuthorityValidationResult.CreateError("Endpoint belongs to different authority: " + endpoint);
		}
	}
	public class TokenClient
	{
		private readonly Func<HttpMessageInvoker> _client;

		private readonly TokenClientOptions _options;

		public TokenClient(HttpMessageInvoker client, TokenClientOptions options)
			: this(() => client, options)
		{
		}

		public TokenClient(Func<HttpMessageInvoker> client, TokenClientOptions options)
		{
			_client = client ?? throw new ArgumentNullException("client");
			_options = options ?? throw new ArgumentNullException("options");
		}

		internal void ApplyRequestParameters(TokenRequest request, IDictionary<string, string> parameters)
		{
			request.Address = _options.Address;
			request.ClientId = _options.ClientId;
			request.ClientSecret = _options.ClientSecret;
			request.ClientAssertion = _options.ClientAssertion;
			request.ClientCredentialStyle = _options.ClientCredentialStyle;
			request.AuthorizationHeaderStyle = _options.AuthorizationHeaderStyle;
			request.Parameters = _options.Parameters;
			if (parameters == null)
			{
				return;
			}
			foreach (KeyValuePair<string, string> parameter in parameters)
			{
				request.Parameters.Add(parameter);
			}
		}

		public Task<TokenResponse> RequestClientCredentialsTokenAsync(string scope = null, IDictionary<string, string> parameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			ClientCredentialsTokenRequest request = new ClientCredentialsTokenRequest
			{
				Scope = scope
			};
			ApplyRequestParameters(request, parameters);
			return _client().RequestClientCredentialsTokenAsync(request, cancellationToken);
		}

		public Task<TokenResponse> RequestDeviceTokenAsync(string deviceCode, IDictionary<string, string> parameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			DeviceTokenRequest request = new DeviceTokenRequest
			{
				DeviceCode = deviceCode
			};
			ApplyRequestParameters(request, parameters);
			return _client().RequestDeviceTokenAsync(request, cancellationToken);
		}

		public Task<TokenResponse> RequestPasswordTokenAsync(string userName, string password = null, string scope = null, IDictionary<string, string> parameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			PasswordTokenRequest request = new PasswordTokenRequest
			{
				UserName = userName,
				Password = password,
				Scope = scope
			};
			ApplyRequestParameters(request, parameters);
			return _client().RequestPasswordTokenAsync(request, cancellationToken);
		}

		public Task<TokenResponse> RequestAuthorizationCodeTokenAsync(string code, string redirectUri, string codeVerifier = null, IDictionary<string, string> parameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			AuthorizationCodeTokenRequest request = new AuthorizationCodeTokenRequest
			{
				Code = code,
				RedirectUri = redirectUri,
				CodeVerifier = codeVerifier
			};
			ApplyRequestParameters(request, parameters);
			return _client().RequestAuthorizationCodeTokenAsync(request, cancellationToken);
		}

		public Task<TokenResponse> RequestRefreshTokenAsync(string refreshToken, string scope = null, IDictionary<string, string> parameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			RefreshTokenRequest request = new RefreshTokenRequest
			{
				RefreshToken = refreshToken,
				Scope = scope
			};
			ApplyRequestParameters(request, parameters);
			return _client().RequestRefreshTokenAsync(request, cancellationToken);
		}

		public Task<TokenResponse> RequestTokenAsync(string grantType, IDictionary<string, string> parameters = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			TokenRequest request = new TokenRequest
			{
				GrantType = grantType
			};
			ApplyRequestParameters(request, parameters);
			return _client().RequestTokenAsync(request, cancellationToken);
		}
	}
}
