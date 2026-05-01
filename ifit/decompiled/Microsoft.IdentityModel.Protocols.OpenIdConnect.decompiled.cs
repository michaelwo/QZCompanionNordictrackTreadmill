using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyInformationalVersion("5.6.0.61018232319.2574f3cbc3736db085497b9b241ea5ae338357b9")]
[assembly: AssemblyFileVersion("5.6.0.61018")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Includes types that provide support for OpenIdConnect protocol.")]
[assembly: AssemblyProduct("Microsoft IdentityModel")]
[assembly: AssemblyTitle("Microsoft.IdentityModel.Protocols.OpenIdConnect")]
[assembly: AssemblyVersion("5.6.0.0")]
namespace Microsoft.IdentityModel.Protocols.OpenIdConnect;

public static class ActiveDirectoryOpenIdConnectEndpoints
{
	public const string Authorize = "oauth2/authorize";

	public const string Logout = "oauth2/logout";

	public const string Token = "oauth2/token";
}
[JsonObject]
public class OpenIdConnectConfiguration
{
	[JsonExtensionData]
	public virtual IDictionary<string, object> AdditionalData { get; } = new Dictionary<string, object>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "acr_values_supported", Required = Required.Default)]
	public ICollection<string> AcrValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "authorization_endpoint", Required = Required.Default)]
	public string AuthorizationEndpoint { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "check_session_iframe", Required = Required.Default)]
	public string CheckSessionIframe { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "claims_supported", Required = Required.Default)]
	public ICollection<string> ClaimsSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "claims_locales_supported", Required = Required.Default)]
	public ICollection<string> ClaimsLocalesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "claims_parameter_supported", Required = Required.Default)]
	public bool ClaimsParameterSupported { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "claim_types_supported", Required = Required.Default)]
	public ICollection<string> ClaimTypesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "display_values_supported", Required = Required.Default)]
	public ICollection<string> DisplayValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "end_session_endpoint", Required = Required.Default)]
	public string EndSessionEndpoint { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "frontchannel_logout_session_supported", Required = Required.Default)]
	public string FrontchannelLogoutSessionSupported { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "frontchannel_logout_supported", Required = Required.Default)]
	public string FrontchannelLogoutSupported { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "grant_types_supported", Required = Required.Default)]
	public ICollection<string> GrantTypesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "http_logout_supported", Required = Required.Default)]
	public bool HttpLogoutSupported { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "id_token_encryption_alg_values_supported", Required = Required.Default)]
	public ICollection<string> IdTokenEncryptionAlgValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "id_token_encryption_enc_values_supported", Required = Required.Default)]
	public ICollection<string> IdTokenEncryptionEncValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "id_token_signing_alg_values_supported", Required = Required.Default)]
	public ICollection<string> IdTokenSigningAlgValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "issuer", Required = Required.Default)]
	public string Issuer { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "jwks_uri", Required = Required.Default)]
	public string JwksUri { get; set; }

	public JsonWebKeySet JsonWebKeySet { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "logout_session_supported", Required = Required.Default)]
	public bool LogoutSessionSupported { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "op_policy_uri", Required = Required.Default)]
	public string OpPolicyUri { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "op_tos_uri", Required = Required.Default)]
	public string OpTosUri { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "registration_endpoint", Required = Required.Default)]
	public string RegistrationEndpoint { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "request_object_encryption_alg_values_supported", Required = Required.Default)]
	public ICollection<string> RequestObjectEncryptionAlgValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "request_object_encryption_enc_values_supported", Required = Required.Default)]
	public ICollection<string> RequestObjectEncryptionEncValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "request_object_signing_alg_values_supported", Required = Required.Default)]
	public ICollection<string> RequestObjectSigningAlgValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "request_parameter_supported", Required = Required.Default)]
	public bool RequestParameterSupported { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "request_uri_parameter_supported", Required = Required.Default)]
	public bool RequestUriParameterSupported { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "require_request_uri_registration", Required = Required.Default)]
	public bool RequireRequestUriRegistration { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_modes_supported", Required = Required.Default)]
	public ICollection<string> ResponseModesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_types_supported", Required = Required.Default)]
	public ICollection<string> ResponseTypesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "service_documentation", Required = Required.Default)]
	public string ServiceDocumentation { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "scopes_supported", Required = Required.Default)]
	public ICollection<string> ScopesSupported { get; } = new Collection<string>();

	[JsonIgnore]
	public ICollection<SecurityKey> SigningKeys { get; } = new Collection<SecurityKey>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "subject_types_supported", Required = Required.Default)]
	public ICollection<string> SubjectTypesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "token_endpoint", Required = Required.Default)]
	public string TokenEndpoint { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "token_endpoint_auth_methods_supported", Required = Required.Default)]
	public ICollection<string> TokenEndpointAuthMethodsSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "token_endpoint_auth_signing_alg_values_supported", Required = Required.Default)]
	public ICollection<string> TokenEndpointAuthSigningAlgValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "ui_locales_supported", Required = Required.Default)]
	public ICollection<string> UILocalesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "userinfo_endpoint", Required = Required.Default)]
	public string UserInfoEndpoint { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "userinfo_encryption_alg_values_supported", Required = Required.Default)]
	public ICollection<string> UserInfoEndpointEncryptionAlgValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "userinfo_encryption_enc_values_supported", Required = Required.Default)]
	public ICollection<string> UserInfoEndpointEncryptionEncValuesSupported { get; } = new Collection<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "userinfo_signing_alg_values_supported", Required = Required.Default)]
	public ICollection<string> UserInfoEndpointSigningAlgValuesSupported { get; } = new Collection<string>();

	public static OpenIdConnectConfiguration Create(string json)
	{
		if (string.IsNullOrEmpty(json))
		{
			throw LogHelper.LogArgumentNullException("json");
		}
		LogHelper.LogVerbose("IDX21808: Deserializing json into OpenIdConnectConfiguration object: '{0}'.", json);
		return new OpenIdConnectConfiguration(json);
	}

	public static string Write(OpenIdConnectConfiguration configuration)
	{
		if (configuration == null)
		{
			throw LogHelper.LogArgumentNullException("configuration");
		}
		LogHelper.LogVerbose("IDX21809: Serializing OpenIdConfiguration object to json string.");
		return JsonConvert.SerializeObject(configuration);
	}

	public OpenIdConnectConfiguration()
	{
	}

	public OpenIdConnectConfiguration(string json)
	{
		if (string.IsNullOrEmpty(json))
		{
			throw LogHelper.LogArgumentNullException("json");
		}
		try
		{
			LogHelper.LogVerbose("IDX21806: Deserializing json string into json web keys.", json, this);
			JsonConvert.PopulateObject(json, this);
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX21815: Error deserializing json: '{0}' into '{1}'.", json, GetType()), innerException));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeAcrValuesSupported()
	{
		return AcrValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeClaimsSupported()
	{
		return ClaimsSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeClaimsLocalesSupported()
	{
		return ClaimsLocalesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeClaimTypesSupported()
	{
		return ClaimTypesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeDisplayValuesSupported()
	{
		return DisplayValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeGrantTypesSupported()
	{
		return GrantTypesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeIdTokenEncryptionAlgValuesSupported()
	{
		return IdTokenEncryptionAlgValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeIdTokenEncryptionEncValuesSupported()
	{
		return IdTokenEncryptionEncValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeIdTokenSigningAlgValuesSupported()
	{
		return IdTokenSigningAlgValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeRequestObjectEncryptionAlgValuesSupported()
	{
		return RequestObjectEncryptionAlgValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeRequestObjectEncryptionEncValuesSupported()
	{
		return RequestObjectEncryptionEncValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeRequestObjectSigningAlgValuesSupported()
	{
		return RequestObjectSigningAlgValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeResponseModesSupported()
	{
		return ResponseModesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeResponseTypesSupported()
	{
		return ResponseTypesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeSigningKeys()
	{
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeScopesSupported()
	{
		return ScopesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeSubjectTypesSupported()
	{
		return SubjectTypesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeTokenEndpointAuthMethodsSupported()
	{
		return TokenEndpointAuthMethodsSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeTokenEndpointAuthSigningAlgValuesSupported()
	{
		return TokenEndpointAuthSigningAlgValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeUILocalesSupported()
	{
		return UILocalesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeUserInfoEndpointEncryptionAlgValuesSupported()
	{
		return UserInfoEndpointEncryptionAlgValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeUserInfoEndpointEncryptionEncValuesSupported()
	{
		return UserInfoEndpointEncryptionEncValuesSupported.Count > 0;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeUserInfoEndpointSigningAlgValuesSupported()
	{
		return UserInfoEndpointSigningAlgValuesSupported.Count > 0;
	}
}
public class OpenIdConnectConfigurationRetriever : IConfigurationRetriever<OpenIdConnectConfiguration>
{
	public static Task<OpenIdConnectConfiguration> GetAsync(string address, CancellationToken cancel)
	{
		return GetAsync(address, new HttpDocumentRetriever(), cancel);
	}

	public static Task<OpenIdConnectConfiguration> GetAsync(string address, HttpClient httpClient, CancellationToken cancel)
	{
		return GetAsync(address, new HttpDocumentRetriever(httpClient), cancel);
	}

	Task<OpenIdConnectConfiguration> IConfigurationRetriever<OpenIdConnectConfiguration>.GetConfigurationAsync(string address, IDocumentRetriever retriever, CancellationToken cancel)
	{
		return GetAsync(address, retriever, cancel);
	}

	public static async Task<OpenIdConnectConfiguration> GetAsync(string address, IDocumentRetriever retriever, CancellationToken cancel)
	{
		if (string.IsNullOrWhiteSpace(address))
		{
			throw LogHelper.LogArgumentNullException("address");
		}
		if (retriever == null)
		{
			throw LogHelper.LogArgumentNullException("retriever");
		}
		string text = await retriever.GetDocumentAsync(address, cancel).ConfigureAwait(continueOnCapturedContext: false);
		LogHelper.LogVerbose("IDX21811: Deserializing the string: '{0}' obtained from metadata endpoint into openIdConnectConfiguration object.", text);
		OpenIdConnectConfiguration openIdConnectConfiguration = JsonConvert.DeserializeObject<OpenIdConnectConfiguration>(text);
		if (!string.IsNullOrEmpty(openIdConnectConfiguration.JwksUri))
		{
			LogHelper.LogVerbose("IDX21812: Retrieving json web keys from: '{0}'.", openIdConnectConfiguration.JwksUri);
			string value = await retriever.GetDocumentAsync(openIdConnectConfiguration.JwksUri, cancel).ConfigureAwait(continueOnCapturedContext: false);
			LogHelper.LogVerbose("IDX21813: Deserializing json web keys: '{0}'.", openIdConnectConfiguration.JwksUri);
			openIdConnectConfiguration.JsonWebKeySet = JsonConvert.DeserializeObject<JsonWebKeySet>(value);
			foreach (SecurityKey signingKey in openIdConnectConfiguration.JsonWebKeySet.GetSigningKeys())
			{
				openIdConnectConfiguration.SigningKeys.Add(signingKey);
			}
		}
		return openIdConnectConfiguration;
	}
}
public class OpenIdConnectProtocolException : Exception
{
	public OpenIdConnectProtocolException()
	{
	}

	public OpenIdConnectProtocolException(string message)
		: base(message)
	{
	}

	public OpenIdConnectProtocolException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class OpenIdConnectProtocolInvalidAtHashException : OpenIdConnectProtocolException
{
	public OpenIdConnectProtocolInvalidAtHashException()
	{
	}

	public OpenIdConnectProtocolInvalidAtHashException(string message)
		: base(message)
	{
	}

	public OpenIdConnectProtocolInvalidAtHashException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class OpenIdConnectProtocolInvalidCHashException : OpenIdConnectProtocolException
{
	public OpenIdConnectProtocolInvalidCHashException()
	{
	}

	public OpenIdConnectProtocolInvalidCHashException(string message)
		: base(message)
	{
	}

	public OpenIdConnectProtocolInvalidCHashException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class OpenIdConnectProtocolInvalidNonceException : OpenIdConnectProtocolException
{
	public OpenIdConnectProtocolInvalidNonceException()
	{
	}

	public OpenIdConnectProtocolInvalidNonceException(string message)
		: base(message)
	{
	}

	public OpenIdConnectProtocolInvalidNonceException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class OpenIdConnectProtocolInvalidStateException : OpenIdConnectProtocolException
{
	public OpenIdConnectProtocolInvalidStateException()
	{
	}

	public OpenIdConnectProtocolInvalidStateException(string message)
		: base(message)
	{
	}

	public OpenIdConnectProtocolInvalidStateException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
internal static class LogMessages
{
	internal const string IDX21105 = "IDX21105: NonceLifetime must be greater than zero. value: '{0}'";

	internal const string IDX21106 = "IDX21106: Error in deserializing to json: '{0}'";

	internal const string IDX21300 = "IDX21300: The hash claim: '{0}' in the id_token did not validate with against: '{1}', algorithm: '{2}'.";

	internal const string IDX21301 = "IDX21301: The algorithm: '{0}' specified in the jwt header could not be used to create a '{1}'. See inner exception for details.";

	internal const string IDX21302 = "IDX21302: The algorithm: '{0}' specified in the jwt header is not supported.";

	internal const string IDX21303 = "IDX21303: Validating hash of OIDC protocol message. Expected: '{0}'.";

	internal const string IDX21304 = "IDX21304: Validating 'c_hash' using id_token and code.";

	internal const string IDX21305 = "IDX21305: OpenIdConnectProtocolValidationContext.ProtocolMessage.Code is null, there is no 'code' in the OpenIdConnect Response to validate.";

	internal const string IDX21306 = "IDX21306: The 'c_hash' claim was not a string in the 'id_token', but a 'code' was in the OpenIdConnectMessage, 'id_token': '{0}'.";

	internal const string IDX21307 = "IDX21307: The 'c_hash' claim was not found in the id_token, but a 'code' was in the OpenIdConnectMessage, id_token: '{0}'";

	internal const string IDX21308 = "IDX21308: 'Azp' claim exists in the 'id_token' but 'ciient_id' is null. Cannot validate the 'azp' claim.";

	internal const string IDX21309 = "IDX21309: Validating 'at_hash' using id_token and access_token.";

	internal const string IDX21310 = "IDX21310: OpenIdConnectProtocolValidationContext.ProtocolMessage.AccessToken is null, there is no 'token' in the OpenIdConnect Response to validate.";

	internal const string IDX21311 = "IDX21311: The 'at_hash' claim was not a string in the 'id_token', but an 'access_token' was in the OpenIdConnectMessage, 'id_token': '{0}'.";

	internal const string IDX21312 = "IDX21312: The 'at_hash' claim was not found in the 'id_token', but a 'access_token' was in the OpenIdConnectMessage, 'id_token': '{0}'.";

	internal const string IDX21313 = "IDX21313: The id_token: '{0}' is not valid. Delegate threw exception, see inner exception for more details.";

	internal const string IDX21314 = "IDX21314: OpenIdConnectProtocol requires the jwt token to have an '{0}' claim. The jwt did not contain an '{0}' claim, jwt: '{1}'.";

	internal const string IDX21315 = "IDX21315: RequireAcr is 'true' (default is 'false') but jwt.PayLoad.Acr is 'null or whitespace', jwt: '{0}'.";

	internal const string IDX21316 = "IDX21316: RequireAmr is 'true' (default is 'false') but jwt.PayLoad.Amr is 'null or whitespace', jwt: '{0}'.";

	internal const string IDX21317 = "IDX21317: RequireAuthTime is 'true' (default is 'false') but jwt.PayLoad.AuthTime is 'null or whitespace', jwt: '{0}'.";

	internal const string IDX21318 = "IDX21318: RequireAzp is 'true' (default is 'false') but jwt.PayLoad.Azp is 'null or whitespace', jwt: '{0}'.";

	internal const string IDX21319 = "IDX21319: Validating the nonce claim found in the id_token.";

	internal const string IDX21320 = "IDX21320: RequireNonce is '{0}'. OpenIdConnectProtocolValidationContext.Nonce and OpenIdConnectProtocol.ValidatedIdToken.Nonce are both null or empty. The nonce cannot be validated. If you don't need to check the nonce, set OpenIdConnectProtocolValidator.RequireNonce to 'false'.";

	internal const string IDX21321 = "IDX21321: The 'nonce' found in the jwt token did not match the expected nonce.\nexpected: '{0}'\nfound in jwt: '{1}'.\njwt: '{2}'.";

	internal const string IDX21322 = "IDX21322: RequireNonce is false, validationContext.Nonce is null and there is no 'nonce' in the OpenIdConnect Response to validate.";

	internal const string IDX21323 = "IDX21323: RequireNonce is '{0}'. OpenIdConnectProtocolValidationContext.Nonce was null, OpenIdConnectProtocol.ValidatedIdToken.Payload.Nonce was not null. The nonce cannot be validated. If you don't need to check the nonce, set OpenIdConnectProtocolValidator.RequireNonce to 'false'. Note if a 'nonce' is found it will be evaluated.";

	internal const string IDX21324 = "IDX21324: The 'nonce' has expired: '{0}'. Time from 'nonce': '{1}', Current Time: '{2}'. NonceLifetime is: '{3}'.";

	internal const string IDX21325 = "IDX21325: The 'nonce' did not contain a timestamp: '{0}'.\nFormat expected is: <epochtime>.<noncedata>.";

	internal const string IDX21326 = "IDX21326: The 'nonce' timestamp could not be converted to a positive integer (greater than 0).\ntimestamp: '{0}'\nnonce: '{1}'.";

	internal const string IDX21327 = "IDX21327: The 'nonce' timestamp: '{0}', could not be converted to a DateTime using DateTime.FromBinary({0}).\nThe value must be between: '{1}' and '{2}'.";

	internal const string IDX21328 = "IDX21328: Generating nonce for openIdConnect message.";

	internal const string IDX21329 = "IDX21329: RequireState is '{0}' but the OpenIdConnectProtocolValidationContext.State is null. State cannot be validated.";

	internal const string IDX21330 = "IDX21330: RequireState is '{0}', the OpenIdConnect Request contained 'state', but the Response does not contain 'state'.";

	internal const string IDX21331 = "IDX21331: The 'state' parameter in the message: '{0}', does not equal the 'state' in the context: '{1}'.";

	internal const string IDX21332 = "IDX21332: OpenIdConnectProtocolValidationContext.ValidatedIdToken is null. There is no 'id_token' to validate against.";

	internal const string IDX21333 = "IDX21333: OpenIdConnectProtocolValidationContext.ProtocolMessage is null, there is no OpenIdConnect Response to validate.";

	internal const string IDX21334 = "IDX21334: Both 'id_token' and 'code' are null in OpenIdConnectProtocolValidationContext.ProtocolMessage received from Authorization Endpoint. Cannot process the message.";

	internal const string IDX21335 = "IDX21335: 'refresh_token' cannot be present in a response message received from Authorization Endpoint.";

	internal const string IDX21336 = "IDX21336: Both 'id_token' and 'access_token' should be present in OpenIdConnectProtocolValidationContext.ProtocolMessage received from Token Endpoint. Cannot process the message.";

	internal const string IDX21337 = "IDX21337: OpenIdConnectProtocolValidationContext.UserInfoEndpointResponse is null or empty, there is no OpenIdConnect Response to validate.";

	internal const string IDX21338 = "IDX21338: Subject claim present in 'id_token': '{0}' does not match the claim received from UserInfo Endpoint: '{1}'.";

	internal const string IDX21339 = "IDX21339: The 'id_token' contains multiple audiences but 'azp' claim is missing.";

	internal const string IDX21340 = "IDX21340: The 'id_token' contains 'azp' claim but its value is not equal to Client Id. 'azp': '{0}'. clientId: '{1}'.";

	internal const string IDX21341 = "IDX21341: 'RequireState' = false, OpenIdConnectProtocolValidationContext.State is null and there is no 'state' in the OpenIdConnect response to validate.";

	internal const string IDX21342 = "IDX21342: 'RequireStateValidation' = false, not validating the state.";

	internal const string IDX21343 = "IDX21343: Unable to parse response from UserInfo endpoint: '{0}'";

	internal const string IDX21345 = "IDX21345: OpenIdConnectProtocolValidationContext.UserInfoEndpointResponse does not contain a 'sub' claim, cannot validate.";

	internal const string IDX21346 = "IDX21346: OpenIdConnectProtocolValidationContext.ValidatedIdToken does not contain a 'sub' claim, cannot validate.";

	internal const string IDX21347 = "IDX21347: Validating the 'c_hash' failed, see inner exception.";

	internal const string IDX21348 = "IDX21348: Validating the 'at_hash' failed, see inner exception.";

	internal const string IDX21349 = "IDX21349: RequireNonce is '{0}'. OpenIdConnectProtocolValidationContext.Nonce was not null, OpenIdConnectProtocol.ValidatedIdToken.Payload.Nonce was null or empty. The nonce cannot be validated. If you don't need to check the nonce, set OpenIdConnectProtocolValidator.RequireNonce to 'false'. Note if a 'nonce' is found it will be evaluated.";

	internal const string IDX21350 = "IDX21350: The algorithm specified in the jwt header is null or empty.";

	internal const string IDX21806 = "IDX21806: Deserializing json string into json web keys.";

	internal const string IDX21808 = "IDX21808: Deserializing json into OpenIdConnectConfiguration object: '{0}'.";

	internal const string IDX21809 = "IDX21809: Serializing OpenIdConfiguration object to json string.";

	internal const string IDX21811 = "IDX21811: Deserializing the string: '{0}' obtained from metadata endpoint into openIdConnectConfiguration object.";

	internal const string IDX21812 = "IDX21812: Retrieving json web keys from: '{0}'.";

	internal const string IDX21813 = "IDX21813: Deserializing json web keys: '{0}'.";

	internal const string IDX21815 = "IDX21815: Error deserializing json: '{0}' into '{1}'.";
}
public static class OpenIdConnectGrantTypes
{
	public const string AuthorizationCode = "authorization_code";

	public const string RefreshToken = "refresh_token";

	public const string Password = "password";

	public const string ClientCredentials = "client_credentials";
}
public class OpenIdConnectMessage : AuthenticationProtocolMessage
{
	public string AuthorizationEndpoint { get; set; }

	public string AccessToken
	{
		get
		{
			return GetParameter("access_token");
		}
		set
		{
			SetParameter("access_token", value);
		}
	}

	public string AcrValues
	{
		get
		{
			return GetParameter("acr_values");
		}
		set
		{
			SetParameter("acr_values", value);
		}
	}

	public string ClaimsLocales
	{
		get
		{
			return GetParameter("claims_locales");
		}
		set
		{
			SetParameter("claims_locales", value);
		}
	}

	public string ClientAssertion
	{
		get
		{
			return GetParameter("client_assertion");
		}
		set
		{
			SetParameter("client_assertion", value);
		}
	}

	public string ClientAssertionType
	{
		get
		{
			return GetParameter("client_assertion_type");
		}
		set
		{
			SetParameter("client_assertion_type", value);
		}
	}

	public string ClientId
	{
		get
		{
			return GetParameter("client_id");
		}
		set
		{
			SetParameter("client_id", value);
		}
	}

	public string ClientSecret
	{
		get
		{
			return GetParameter("client_secret");
		}
		set
		{
			SetParameter("client_secret", value);
		}
	}

	public string Code
	{
		get
		{
			return GetParameter("code");
		}
		set
		{
			SetParameter("code", value);
		}
	}

	public string Display
	{
		get
		{
			return GetParameter("display");
		}
		set
		{
			SetParameter("display", value);
		}
	}

	public string DomainHint
	{
		get
		{
			return GetParameter("domain_hint");
		}
		set
		{
			SetParameter("domain_hint", value);
		}
	}

	public bool EnableTelemetryParameters { get; set; } = EnableTelemetryParametersByDefault;

	public static bool EnableTelemetryParametersByDefault { get; set; } = true;

	public string Error
	{
		get
		{
			return GetParameter("error");
		}
		set
		{
			SetParameter("error", value);
		}
	}

	public string ErrorDescription
	{
		get
		{
			return GetParameter("error_description");
		}
		set
		{
			SetParameter("error_description", value);
		}
	}

	public string ErrorUri
	{
		get
		{
			return GetParameter("error_uri");
		}
		set
		{
			SetParameter("error_uri", value);
		}
	}

	public string ExpiresIn
	{
		get
		{
			return GetParameter("expires_in");
		}
		set
		{
			SetParameter("expires_in", value);
		}
	}

	public string GrantType
	{
		get
		{
			return GetParameter("grant_type");
		}
		set
		{
			SetParameter("grant_type", value);
		}
	}

	public string IdToken
	{
		get
		{
			return GetParameter("id_token");
		}
		set
		{
			SetParameter("id_token", value);
		}
	}

	public string IdTokenHint
	{
		get
		{
			return GetParameter("id_token_hint");
		}
		set
		{
			SetParameter("id_token_hint", value);
		}
	}

	public string IdentityProvider
	{
		get
		{
			return GetParameter("identity_provider");
		}
		set
		{
			SetParameter("identity_provider", value);
		}
	}

	public string Iss
	{
		get
		{
			return GetParameter("iss");
		}
		set
		{
			SetParameter("iss", value);
		}
	}

	public string LoginHint
	{
		get
		{
			return GetParameter("login_hint");
		}
		set
		{
			SetParameter("login_hint", value);
		}
	}

	public string MaxAge
	{
		get
		{
			return GetParameter("max_age");
		}
		set
		{
			SetParameter("max_age", value);
		}
	}

	public string Nonce
	{
		get
		{
			return GetParameter("nonce");
		}
		set
		{
			SetParameter("nonce", value);
		}
	}

	public string Password
	{
		get
		{
			return GetParameter("password");
		}
		set
		{
			SetParameter("password", value);
		}
	}

	public string PostLogoutRedirectUri
	{
		get
		{
			return GetParameter("post_logout_redirect_uri");
		}
		set
		{
			SetParameter("post_logout_redirect_uri", value);
		}
	}

	public string Prompt
	{
		get
		{
			return GetParameter("prompt");
		}
		set
		{
			SetParameter("prompt", value);
		}
	}

	public string RedirectUri
	{
		get
		{
			return GetParameter("redirect_uri");
		}
		set
		{
			SetParameter("redirect_uri", value);
		}
	}

	public string RefreshToken
	{
		get
		{
			return GetParameter("refresh_token");
		}
		set
		{
			SetParameter("refresh_token", value);
		}
	}

	public OpenIdConnectRequestType RequestType { get; set; }

	public string RequestUri
	{
		get
		{
			return GetParameter("request_uri");
		}
		set
		{
			SetParameter("request_uri", value);
		}
	}

	public string ResponseMode
	{
		get
		{
			return GetParameter("response_mode");
		}
		set
		{
			SetParameter("response_mode", value);
		}
	}

	public string ResponseType
	{
		get
		{
			return GetParameter("response_type");
		}
		set
		{
			SetParameter("response_type", value);
		}
	}

	public string Resource
	{
		get
		{
			return GetParameter("resource");
		}
		set
		{
			SetParameter("resource", value);
		}
	}

	public string Scope
	{
		get
		{
			return GetParameter("scope");
		}
		set
		{
			SetParameter("scope", value);
		}
	}

	public string SessionState
	{
		get
		{
			return GetParameter("session_state");
		}
		set
		{
			SetParameter("session_state", value);
		}
	}

	public string Sid
	{
		get
		{
			return GetParameter("sid");
		}
		set
		{
			SetParameter("sid", value);
		}
	}

	public string SkuTelemetryValue { get; set; } = "ID_NETSTANDARD2_0";

	public string State
	{
		get
		{
			return GetParameter("state");
		}
		set
		{
			SetParameter("state", value);
		}
	}

	public string TargetLinkUri
	{
		get
		{
			return GetParameter("target_link_uri");
		}
		set
		{
			SetParameter("target_link_uri", value);
		}
	}

	public string TokenEndpoint { get; set; }

	public string TokenType
	{
		get
		{
			return GetParameter("token_type");
		}
		set
		{
			SetParameter("token_type", value);
		}
	}

	public string UiLocales
	{
		get
		{
			return GetParameter("ui_locales");
		}
		set
		{
			SetParameter("ui_locales", value);
		}
	}

	public string UserId
	{
		get
		{
			return GetParameter("user_id");
		}
		set
		{
			SetParameter("user_id", value);
		}
	}

	public string Username
	{
		get
		{
			return GetParameter("username");
		}
		set
		{
			SetParameter("username", value);
		}
	}

	public OpenIdConnectMessage()
	{
	}

	public OpenIdConnectMessage(string json)
	{
		if (string.IsNullOrEmpty(json))
		{
			throw LogHelper.LogArgumentNullException("json");
		}
		try
		{
			SetJsonParameters(JObject.Parse(json));
		}
		catch
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX21106: Error in deserializing to json: '{0}'", json)));
		}
	}

	protected OpenIdConnectMessage(OpenIdConnectMessage other)
	{
		if (other == null)
		{
			throw LogHelper.LogArgumentNullException("other");
		}
		foreach (KeyValuePair<string, string> parameter in other.Parameters)
		{
			SetParameter(parameter.Key, parameter.Value);
		}
		AuthorizationEndpoint = other.AuthorizationEndpoint;
		base.IssuerAddress = other.IssuerAddress;
		RequestType = other.RequestType;
		TokenEndpoint = other.TokenEndpoint;
		EnableTelemetryParameters = other.EnableTelemetryParameters;
	}

	public OpenIdConnectMessage(NameValueCollection nameValueCollection)
	{
		if (nameValueCollection == null)
		{
			throw LogHelper.LogArgumentNullException("nameValueCollection");
		}
		string[] allKeys = nameValueCollection.AllKeys;
		foreach (string text in allKeys)
		{
			if (text != null)
			{
				SetParameter(text, nameValueCollection[text]);
			}
		}
	}

	public OpenIdConnectMessage(IEnumerable<KeyValuePair<string, string[]>> parameters)
	{
		if (parameters == null)
		{
			throw LogHelper.LogArgumentNullException("parameters");
		}
		foreach (KeyValuePair<string, string[]> parameter in parameters)
		{
			if (parameter.Value == null || string.IsNullOrWhiteSpace(parameter.Key))
			{
				continue;
			}
			string[] value = parameter.Value;
			foreach (string text in value)
			{
				if (text != null)
				{
					SetParameter(parameter.Key, text);
					break;
				}
			}
		}
	}

	public OpenIdConnectMessage(JObject json)
	{
		SetJsonParameters(json);
	}

	private void SetJsonParameters(JObject json)
	{
		if (json == null)
		{
			throw LogHelper.LogArgumentNullException("json");
		}
		foreach (KeyValuePair<string, JToken> item in json)
		{
			if (json.TryGetValue(item.Key, out JToken value))
			{
				SetParameter(item.Key, value.ToString());
			}
		}
	}

	public virtual OpenIdConnectMessage Clone()
	{
		return new OpenIdConnectMessage(this);
	}

	public virtual string CreateAuthenticationRequestUrl()
	{
		OpenIdConnectMessage openIdConnectMessage = Clone();
		openIdConnectMessage.RequestType = OpenIdConnectRequestType.Authentication;
		EnsureTelemetryValues(openIdConnectMessage);
		return openIdConnectMessage.BuildRedirectUrl();
	}

	public virtual string CreateLogoutRequestUrl()
	{
		OpenIdConnectMessage openIdConnectMessage = Clone();
		openIdConnectMessage.RequestType = OpenIdConnectRequestType.Logout;
		EnsureTelemetryValues(openIdConnectMessage);
		return openIdConnectMessage.BuildRedirectUrl();
	}

	private void EnsureTelemetryValues(OpenIdConnectMessage clonedMessage)
	{
		if (EnableTelemetryParameters)
		{
			clonedMessage.SetParameter("x-client-SKU", SkuTelemetryValue);
			clonedMessage.SetParameter("x-client-ver", typeof(OpenIdConnectMessage).GetTypeInfo().Assembly.GetName().Version.ToString());
		}
	}
}
public static class OpenIdConnectParameterNames
{
	public const string AccessToken = "access_token";

	public const string AcrValues = "acr_values";

	public const string ClaimsLocales = "claims_locales";

	public const string ClientAssertion = "client_assertion";

	public const string ClientAssertionType = "client_assertion_type";

	public const string ClientId = "client_id";

	public const string ClientSecret = "client_secret";

	public const string Code = "code";

	public const string Display = "display";

	public const string DomainHint = "domain_hint";

	public const string Error = "error";

	public const string ErrorDescription = "error_description";

	public const string ErrorUri = "error_uri";

	public const string ExpiresIn = "expires_in";

	public const string GrantType = "grant_type";

	public const string Iss = "iss";

	public const string IdToken = "id_token";

	public const string IdTokenHint = "id_token_hint";

	public const string IdentityProvider = "identity_provider";

	public const string LoginHint = "login_hint";

	public const string MaxAge = "max_age";

	public const string Nonce = "nonce";

	public const string Password = "password";

	public const string PostLogoutRedirectUri = "post_logout_redirect_uri";

	public const string Prompt = "prompt";

	public const string RedirectUri = "redirect_uri";

	public const string RefreshToken = "refresh_token";

	public const string RequestUri = "request_uri";

	public const string Resource = "resource";

	public const string ResponseMode = "response_mode";

	public const string ResponseType = "response_type";

	public const string Scope = "scope";

	public const string SkuTelemetry = "x-client-SKU";

	public const string SessionState = "session_state";

	public const string Sid = "sid";

	public const string State = "state";

	public const string TargetLinkUri = "target_link_uri";

	public const string TokenType = "token_type";

	public const string UiLocales = "ui_locales";

	public const string UserId = "user_id";

	public const string Username = "username";

	public const string VersionTelemetry = "x-client-ver";
}
public static class OpenIdConnectPrompt
{
	public const string None = "none";

	public const string Login = "login";

	public const string Consent = "consent";

	public const string SelectAccount = "select_account";
}
public class OpenIdConnectProtocolValidationContext
{
	public string ClientId { get; set; }

	public string Nonce { get; set; }

	public OpenIdConnectMessage ProtocolMessage { get; set; }

	public string State { get; set; }

	public string UserInfoEndpointResponse { get; set; }

	public JwtSecurityToken ValidatedIdToken { get; set; }
}
public delegate void IdTokenValidator(JwtSecurityToken idToken, OpenIdConnectProtocolValidationContext context);
public class OpenIdConnectProtocolValidator
{
	private IDictionary<string, string> _hashAlgorithmMap = new Dictionary<string, string>
	{
		{ "ES256", "SHA256" },
		{ "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha256", "SHA256" },
		{ "HS256", "SHA256" },
		{ "RS256", "SHA256" },
		{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256", "SHA256" },
		{ "PS256", "SHA256" },
		{ "ES384", "SHA384" },
		{ "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha384", "SHA384" },
		{ "HS384", "SHA384" },
		{ "RS384", "SHA384" },
		{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha384", "SHA384" },
		{ "PS384", "SHA384" },
		{ "ES512", "SHA512" },
		{ "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha512", "SHA512" },
		{ "HS512", "SHA512" },
		{ "RS512", "SHA512" },
		{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha512", "SHA512" },
		{ "PS512", "SHA512" }
	};

	private TimeSpan _nonceLifetime = DefaultNonceLifetime;

	private CryptoProviderFactory _cryptoProviderFactory;

	public static readonly TimeSpan DefaultNonceLifetime = TimeSpan.FromMinutes(60.0);

	public IDictionary<string, string> HashAlgorithmMap => _hashAlgorithmMap;

	public TimeSpan NonceLifetime
	{
		get
		{
			return _nonceLifetime;
		}
		set
		{
			if (value <= TimeSpan.Zero)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("value", LogHelper.FormatInvariant("IDX21105: NonceLifetime must be greater than zero. value: '{0}'", value)));
			}
			_nonceLifetime = value;
		}
	}

	[DefaultValue(false)]
	public bool RequireAcr { get; set; }

	[DefaultValue(false)]
	public bool RequireAmr { get; set; }

	[DefaultValue(false)]
	public bool RequireAuthTime { get; set; }

	[DefaultValue(false)]
	public bool RequireAzp { get; set; }

	[DefaultValue(true)]
	public bool RequireNonce { get; set; }

	[DefaultValue(true)]
	public bool RequireState { get; set; }

	[DefaultValue(true)]
	public bool RequireStateValidation { get; set; }

	[DefaultValue(true)]
	public bool RequireSub { get; set; } = RequireSubByDefault;

	public static bool RequireSubByDefault { get; set; } = true;

	[DefaultValue(true)]
	public bool RequireTimeStampInNonce { get; set; }

	public IdTokenValidator IdTokenValidator { get; set; }

	public CryptoProviderFactory CryptoProviderFactory
	{
		get
		{
			return _cryptoProviderFactory;
		}
		set
		{
			if (value == null)
			{
				throw LogHelper.LogArgumentNullException("value");
			}
			_cryptoProviderFactory = value;
		}
	}

	public OpenIdConnectProtocolValidator()
	{
		RequireAcr = false;
		RequireAmr = false;
		RequireAuthTime = false;
		RequireAzp = false;
		RequireNonce = true;
		RequireState = true;
		RequireTimeStampInNonce = true;
		RequireStateValidation = true;
		_cryptoProviderFactory = new CryptoProviderFactory(CryptoProviderFactory.Default);
	}

	public virtual string GenerateNonce()
	{
		LogHelper.LogVerbose("IDX21328: Generating nonce for openIdConnect message.");
		string text = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString() + Guid.NewGuid().ToString()));
		if (RequireTimeStampInNonce)
		{
			return DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture) + "." + text;
		}
		return text;
	}

	public virtual void ValidateAuthenticationResponse(OpenIdConnectProtocolValidationContext validationContext)
	{
		if (validationContext == null)
		{
			throw LogHelper.LogArgumentNullException("validationContext");
		}
		if (validationContext.ProtocolMessage == null)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21333: OpenIdConnectProtocolValidationContext.ProtocolMessage is null, there is no OpenIdConnect Response to validate."));
		}
		if (string.IsNullOrEmpty(validationContext.ProtocolMessage.IdToken))
		{
			if (string.IsNullOrEmpty(validationContext.ProtocolMessage.Code))
			{
				throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21334: Both 'id_token' and 'code' are null in OpenIdConnectProtocolValidationContext.ProtocolMessage received from Authorization Endpoint. Cannot process the message."));
			}
			ValidateState(validationContext);
			return;
		}
		if (validationContext.ValidatedIdToken == null)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21332: OpenIdConnectProtocolValidationContext.ValidatedIdToken is null. There is no 'id_token' to validate against."));
		}
		if (!string.IsNullOrEmpty(validationContext.ProtocolMessage.RefreshToken))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21335: 'refresh_token' cannot be present in a response message received from Authorization Endpoint."));
		}
		ValidateState(validationContext);
		ValidateIdToken(validationContext);
		ValidateNonce(validationContext);
		ValidateCHash(validationContext);
		ValidateAtHash(validationContext);
	}

	public virtual void ValidateTokenResponse(OpenIdConnectProtocolValidationContext validationContext)
	{
		if (validationContext == null)
		{
			throw LogHelper.LogArgumentNullException("validationContext");
		}
		if (validationContext.ProtocolMessage == null)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21333: OpenIdConnectProtocolValidationContext.ProtocolMessage is null, there is no OpenIdConnect Response to validate."));
		}
		if (string.IsNullOrEmpty(validationContext.ProtocolMessage.IdToken) || string.IsNullOrEmpty(validationContext.ProtocolMessage.AccessToken))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21336: Both 'id_token' and 'access_token' should be present in OpenIdConnectProtocolValidationContext.ProtocolMessage received from Token Endpoint. Cannot process the message."));
		}
		if (validationContext.ValidatedIdToken == null)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21332: OpenIdConnectProtocolValidationContext.ValidatedIdToken is null. There is no 'id_token' to validate against."));
		}
		ValidateIdToken(validationContext);
		ValidateNonce(validationContext);
		if (validationContext.ValidatedIdToken.Payload.TryGetValue("at_hash", out var _))
		{
			ValidateAtHash(validationContext);
		}
	}

	public virtual void ValidateUserInfoResponse(OpenIdConnectProtocolValidationContext validationContext)
	{
		if (validationContext == null)
		{
			throw LogHelper.LogArgumentNullException("validationContext");
		}
		if (string.IsNullOrEmpty(validationContext.UserInfoEndpointResponse))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21337: OpenIdConnectProtocolValidationContext.UserInfoEndpointResponse is null or empty, there is no OpenIdConnect Response to validate."));
		}
		if (validationContext.ValidatedIdToken == null)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21332: OpenIdConnectProtocolValidationContext.ValidatedIdToken is null. There is no 'id_token' to validate against."));
		}
		string empty = string.Empty;
		try
		{
			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			empty = ((!jwtSecurityTokenHandler.CanReadToken(validationContext.UserInfoEndpointResponse)) ? JwtPayload.Deserialize(validationContext.UserInfoEndpointResponse).Sub : (jwtSecurityTokenHandler.ReadToken(validationContext.UserInfoEndpointResponse) as JwtSecurityToken).Payload.Sub);
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21343: Unable to parse response from UserInfo endpoint: '{0}'", validationContext.UserInfoEndpointResponse), innerException));
		}
		if (string.IsNullOrEmpty(empty))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21345: OpenIdConnectProtocolValidationContext.UserInfoEndpointResponse does not contain a 'sub' claim, cannot validate."));
		}
		if (string.IsNullOrEmpty(validationContext.ValidatedIdToken.Payload.Sub))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21346: OpenIdConnectProtocolValidationContext.ValidatedIdToken does not contain a 'sub' claim, cannot validate."));
		}
		if (!string.Equals(validationContext.ValidatedIdToken.Payload.Sub, empty, StringComparison.Ordinal))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21338: Subject claim present in 'id_token': '{0}' does not match the claim received from UserInfo Endpoint: '{1}'.", validationContext.ValidatedIdToken.Payload.Sub, empty)));
		}
	}

	protected virtual void ValidateIdToken(OpenIdConnectProtocolValidationContext validationContext)
	{
		if (validationContext == null)
		{
			throw LogHelper.LogArgumentNullException("validationContext");
		}
		if (validationContext.ValidatedIdToken == null)
		{
			throw LogHelper.LogArgumentNullException("validationContext.ValidatedIdToken");
		}
		if (IdTokenValidator != null)
		{
			try
			{
				IdTokenValidator(validationContext.ValidatedIdToken, validationContext);
				return;
			}
			catch (Exception innerException)
			{
				throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21313: The id_token: '{0}' is not valid. Delegate threw exception, see inner exception for more details.", validationContext.ValidatedIdToken), innerException));
			}
		}
		JwtSecurityToken validatedIdToken = validationContext.ValidatedIdToken;
		if (validatedIdToken.Payload.Aud.Count == 0)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21314: OpenIdConnectProtocol requires the jwt token to have an '{0}' claim. The jwt did not contain an '{0}' claim, jwt: '{1}'.", "aud".ToLowerInvariant(), validatedIdToken)));
		}
		if (!validatedIdToken.Payload.Exp.HasValue)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21314: OpenIdConnectProtocol requires the jwt token to have an '{0}' claim. The jwt did not contain an '{0}' claim, jwt: '{1}'.", "exp".ToLowerInvariant(), validatedIdToken)));
		}
		if (!validatedIdToken.Payload.Iat.HasValue)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21314: OpenIdConnectProtocol requires the jwt token to have an '{0}' claim. The jwt did not contain an '{0}' claim, jwt: '{1}'.", "iat".ToLowerInvariant(), validatedIdToken)));
		}
		if (validatedIdToken.Payload.Iss == null)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21314: OpenIdConnectProtocol requires the jwt token to have an '{0}' claim. The jwt did not contain an '{0}' claim, jwt: '{1}'.", "iss".ToLowerInvariant(), validatedIdToken)));
		}
		if (RequireSub && string.IsNullOrWhiteSpace(validatedIdToken.Payload.Sub))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21314: OpenIdConnectProtocol requires the jwt token to have an '{0}' claim. The jwt did not contain an '{0}' claim, jwt: '{1}'.", "sub".ToLowerInvariant(), validatedIdToken)));
		}
		if (RequireAcr && string.IsNullOrWhiteSpace(validatedIdToken.Payload.Acr))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21315: RequireAcr is 'true' (default is 'false') but jwt.PayLoad.Acr is 'null or whitespace', jwt: '{0}'.", validatedIdToken)));
		}
		if (RequireAmr && validatedIdToken.Payload.Amr.Count == 0)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21316: RequireAmr is 'true' (default is 'false') but jwt.PayLoad.Amr is 'null or whitespace', jwt: '{0}'.", validatedIdToken)));
		}
		if (RequireAuthTime && !validatedIdToken.Payload.AuthTime.HasValue)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21317: RequireAuthTime is 'true' (default is 'false') but jwt.PayLoad.AuthTime is 'null or whitespace', jwt: '{0}'.", validatedIdToken)));
		}
		if (RequireAzp && string.IsNullOrWhiteSpace(validatedIdToken.Payload.Azp))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21318: RequireAzp is 'true' (default is 'false') but jwt.PayLoad.Azp is 'null or whitespace', jwt: '{0}'.", validatedIdToken)));
		}
		if (validatedIdToken.Payload.Aud.Count > 1 && string.IsNullOrEmpty(validatedIdToken.Payload.Azp))
		{
			LogHelper.LogWarning("IDX21339: The 'id_token' contains multiple audiences but 'azp' claim is missing.");
		}
		if (!string.IsNullOrEmpty(validatedIdToken.Payload.Azp))
		{
			if (string.IsNullOrEmpty(validationContext.ClientId))
			{
				throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21308: 'Azp' claim exists in the 'id_token' but 'ciient_id' is null. Cannot validate the 'azp' claim."));
			}
			if (!string.Equals(validatedIdToken.Payload.Azp, validationContext.ClientId, StringComparison.Ordinal))
			{
				throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21340: The 'id_token' contains 'azp' claim but its value is not equal to Client Id. 'azp': '{0}'. clientId: '{1}'.", validatedIdToken.Payload.Azp, validationContext.ClientId)));
			}
		}
	}

	public virtual HashAlgorithm GetHashAlgorithm(string algorithm)
	{
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21350: The algorithm specified in the jwt header is null or empty."));
		}
		try
		{
			if (!HashAlgorithmMap.TryGetValue(algorithm, out var value))
			{
				value = algorithm;
			}
			return CryptoProviderFactory.CreateHashAlgorithm(value);
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21301: The algorithm: '{0}' specified in the jwt header could not be used to create a '{1}'. See inner exception for details.", algorithm, typeof(HashAlgorithm)), innerException));
		}
	}

	private void ValidateHash(string expectedValue, string hashItem, string algorithm)
	{
		LogHelper.LogInformation("IDX21303: Validating hash of OIDC protocol message. Expected: '{0}'.", expectedValue);
		HashAlgorithm hashAlgorithm = null;
		try
		{
			hashAlgorithm = GetHashAlgorithm(algorithm);
			CheckHash(hashAlgorithm, expectedValue, hashItem, algorithm);
		}
		finally
		{
			CryptoProviderFactory.ReleaseHashAlgorithm(hashAlgorithm);
		}
	}

	private void CheckHash(HashAlgorithm hashAlgorithm, string expectedValue, string hashItem, string algorithm)
	{
		byte[] array = hashAlgorithm.ComputeHash(Encoding.ASCII.GetBytes(hashItem));
		string b = Base64UrlEncoder.Encode(array, 0, array.Length / 2);
		if (!string.Equals(expectedValue, b, StringComparison.Ordinal))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException(LogHelper.FormatInvariant("IDX21300: The hash claim: '{0}' in the id_token did not validate with against: '{1}', algorithm: '{2}'.", expectedValue, hashItem, algorithm)));
		}
	}

	protected virtual void ValidateCHash(OpenIdConnectProtocolValidationContext validationContext)
	{
		LogHelper.LogVerbose("IDX21304: Validating 'c_hash' using id_token and code.");
		if (validationContext == null)
		{
			throw LogHelper.LogArgumentNullException("validationContext");
		}
		if (validationContext.ValidatedIdToken == null)
		{
			throw LogHelper.LogArgumentNullException("ValidatedIdToken");
		}
		if (validationContext.ProtocolMessage == null)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21333: OpenIdConnectProtocolValidationContext.ProtocolMessage is null, there is no OpenIdConnect Response to validate."));
		}
		if (string.IsNullOrEmpty(validationContext.ProtocolMessage.Code))
		{
			LogHelper.LogInformation("IDX21305: OpenIdConnectProtocolValidationContext.ProtocolMessage.Code is null, there is no 'code' in the OpenIdConnect Response to validate.");
			return;
		}
		if (!validationContext.ValidatedIdToken.Payload.TryGetValue("c_hash", out var value))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidCHashException(LogHelper.FormatInvariant("IDX21307: The 'c_hash' claim was not found in the id_token, but a 'code' was in the OpenIdConnectMessage, id_token: '{0}'", validationContext.ValidatedIdToken)));
		}
		if (!(value is string expectedValue))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidCHashException(LogHelper.FormatInvariant("IDX21306: The 'c_hash' claim was not a string in the 'id_token', but a 'code' was in the OpenIdConnectMessage, 'id_token': '{0}'.", validationContext.ValidatedIdToken)));
		}
		try
		{
			ValidateHash(expectedValue, validationContext.ProtocolMessage.Code, validationContext.ValidatedIdToken.Header.Alg);
		}
		catch (OpenIdConnectProtocolException innerException)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidCHashException("IDX21347: Validating the 'c_hash' failed, see inner exception.", innerException));
		}
	}

	protected virtual void ValidateAtHash(OpenIdConnectProtocolValidationContext validationContext)
	{
		LogHelper.LogVerbose("IDX21309: Validating 'at_hash' using id_token and access_token.");
		if (validationContext == null)
		{
			throw LogHelper.LogArgumentNullException("validationContext");
		}
		if (validationContext.ValidatedIdToken == null)
		{
			throw LogHelper.LogArgumentNullException("validationContext.ValidatedIdToken");
		}
		if (validationContext.ProtocolMessage == null)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21333: OpenIdConnectProtocolValidationContext.ProtocolMessage is null, there is no OpenIdConnect Response to validate."));
		}
		if (string.IsNullOrEmpty(validationContext.ProtocolMessage.AccessToken))
		{
			LogHelper.LogInformation("IDX21310: OpenIdConnectProtocolValidationContext.ProtocolMessage.AccessToken is null, there is no 'token' in the OpenIdConnect Response to validate.");
			return;
		}
		if (!validationContext.ValidatedIdToken.Payload.TryGetValue("at_hash", out var value))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidAtHashException(LogHelper.FormatInvariant("IDX21312: The 'at_hash' claim was not found in the 'id_token', but a 'access_token' was in the OpenIdConnectMessage, 'id_token': '{0}'.", validationContext.ValidatedIdToken)));
		}
		if (!(value is string expectedValue))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidAtHashException(LogHelper.FormatInvariant("IDX21311: The 'at_hash' claim was not a string in the 'id_token', but an 'access_token' was in the OpenIdConnectMessage, 'id_token': '{0}'.", validationContext.ValidatedIdToken)));
		}
		try
		{
			ValidateHash(expectedValue, validationContext.ProtocolMessage.AccessToken, validationContext.ValidatedIdToken.Header.Alg);
		}
		catch (OpenIdConnectProtocolException innerException)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidAtHashException("IDX21348: Validating the 'at_hash' failed, see inner exception.", innerException));
		}
	}

	protected virtual void ValidateNonce(OpenIdConnectProtocolValidationContext validationContext)
	{
		LogHelper.LogVerbose("IDX21319: Validating the nonce claim found in the id_token.");
		if (validationContext == null)
		{
			throw LogHelper.LogArgumentNullException("validationContext");
		}
		if (validationContext.ValidatedIdToken == null)
		{
			throw LogHelper.LogArgumentNullException("ValidatedIdToken");
		}
		string nonce = validationContext.ValidatedIdToken.Payload.Nonce;
		if (!RequireNonce && string.IsNullOrEmpty(validationContext.Nonce) && string.IsNullOrEmpty(nonce))
		{
			LogHelper.LogInformation("IDX21322: RequireNonce is false, validationContext.Nonce is null and there is no 'nonce' in the OpenIdConnect Response to validate.");
			return;
		}
		if (string.IsNullOrEmpty(validationContext.Nonce) && string.IsNullOrEmpty(nonce))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidNonceException(LogHelper.FormatInvariant("IDX21320: RequireNonce is '{0}'. OpenIdConnectProtocolValidationContext.Nonce and OpenIdConnectProtocol.ValidatedIdToken.Nonce are both null or empty. The nonce cannot be validated. If you don't need to check the nonce, set OpenIdConnectProtocolValidator.RequireNonce to 'false'.", RequireNonce)));
		}
		if (string.IsNullOrEmpty(validationContext.Nonce))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidNonceException(LogHelper.FormatInvariant("IDX21323: RequireNonce is '{0}'. OpenIdConnectProtocolValidationContext.Nonce was null, OpenIdConnectProtocol.ValidatedIdToken.Payload.Nonce was not null. The nonce cannot be validated. If you don't need to check the nonce, set OpenIdConnectProtocolValidator.RequireNonce to 'false'. Note if a 'nonce' is found it will be evaluated.", RequireNonce)));
		}
		if (string.IsNullOrEmpty(nonce))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidNonceException(LogHelper.FormatInvariant("IDX21349: RequireNonce is '{0}'. OpenIdConnectProtocolValidationContext.Nonce was not null, OpenIdConnectProtocol.ValidatedIdToken.Payload.Nonce was null or empty. The nonce cannot be validated. If you don't need to check the nonce, set OpenIdConnectProtocolValidator.RequireNonce to 'false'. Note if a 'nonce' is found it will be evaluated.", RequireNonce)));
		}
		if (!string.Equals(nonce, validationContext.Nonce, StringComparison.Ordinal))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidNonceException(LogHelper.FormatInvariant("IDX21321: The 'nonce' found in the jwt token did not match the expected nonce.\nexpected: '{0}'\nfound in jwt: '{1}'.\njwt: '{2}'.", validationContext.Nonce, nonce, validationContext.ValidatedIdToken)));
		}
		if (RequireTimeStampInNonce)
		{
			int num = nonce.IndexOf('.');
			if (num == -1)
			{
				throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidNonceException(LogHelper.FormatInvariant("IDX21325: The 'nonce' did not contain a timestamp: '{0}'.\nFormat expected is: <epochtime>.<noncedata>.", nonce)));
			}
			string text = nonce.Substring(0, num);
			DateTime dateTime = new DateTime(1979, 1, 1);
			long num2 = -1L;
			try
			{
				num2 = Convert.ToInt64(text, CultureInfo.InvariantCulture);
			}
			catch (Exception innerException)
			{
				throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidNonceException(LogHelper.FormatInvariant("IDX21326: The 'nonce' timestamp could not be converted to a positive integer (greater than 0).\ntimestamp: '{0}'\nnonce: '{1}'.", text, nonce), innerException));
			}
			if (num2 <= 0)
			{
				throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidNonceException(LogHelper.FormatInvariant("IDX21326: The 'nonce' timestamp could not be converted to a positive integer (greater than 0).\ntimestamp: '{0}'\nnonce: '{1}'.", text, nonce)));
			}
			try
			{
				dateTime = DateTime.FromBinary(num2);
			}
			catch (Exception innerException2)
			{
				object[] obj = new object[3] { text, null, null };
				DateTime minValue = DateTime.MinValue;
				obj[1] = minValue.Ticks.ToString(CultureInfo.InvariantCulture);
				minValue = DateTime.MaxValue;
				obj[2] = minValue.Ticks.ToString(CultureInfo.InvariantCulture);
				throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidNonceException(LogHelper.FormatInvariant("IDX21327: The 'nonce' timestamp: '{0}', could not be converted to a DateTime using DateTime.FromBinary({0}).\nThe value must be between: '{1}' and '{2}'.", obj), innerException2));
			}
			DateTime utcNow = DateTime.UtcNow;
			if (dateTime + NonceLifetime < utcNow)
			{
				throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidNonceException(LogHelper.FormatInvariant("IDX21324: The 'nonce' has expired: '{0}'. Time from 'nonce': '{1}', Current Time: '{2}'. NonceLifetime is: '{3}'.", nonce, dateTime.ToString(CultureInfo.InvariantCulture), utcNow.ToString(CultureInfo.InvariantCulture), NonceLifetime.ToString("c", CultureInfo.InvariantCulture))));
			}
		}
	}

	protected virtual void ValidateState(OpenIdConnectProtocolValidationContext validationContext)
	{
		if (!RequireStateValidation)
		{
			LogHelper.LogVerbose("IDX21342: 'RequireStateValidation' = false, not validating the state.");
			return;
		}
		if (validationContext == null)
		{
			throw LogHelper.LogArgumentNullException("validationContext");
		}
		if (validationContext.ProtocolMessage == null)
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolException("IDX21333: OpenIdConnectProtocolValidationContext.ProtocolMessage is null, there is no OpenIdConnect Response to validate."));
		}
		if (!RequireState && string.IsNullOrEmpty(validationContext.State) && string.IsNullOrEmpty(validationContext.ProtocolMessage.State))
		{
			LogHelper.LogInformation("IDX21341: 'RequireState' = false, OpenIdConnectProtocolValidationContext.State is null and there is no 'state' in the OpenIdConnect response to validate.");
			return;
		}
		if (string.IsNullOrEmpty(validationContext.State))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidStateException(LogHelper.FormatInvariant("IDX21329: RequireState is '{0}' but the OpenIdConnectProtocolValidationContext.State is null. State cannot be validated.", RequireState)));
		}
		if (string.IsNullOrEmpty(validationContext.ProtocolMessage.State))
		{
			throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidStateException(LogHelper.FormatInvariant("IDX21330: RequireState is '{0}', the OpenIdConnect Request contained 'state', but the Response does not contain 'state'.", RequireState.ToString())));
		}
		if (string.Equals(validationContext.State, validationContext.ProtocolMessage.State, StringComparison.Ordinal))
		{
			return;
		}
		throw LogHelper.LogExceptionMessage(new OpenIdConnectProtocolInvalidStateException(LogHelper.FormatInvariant("IDX21331: The 'state' parameter in the message: '{0}', does not equal the 'state' in the context: '{1}'.", validationContext.State, validationContext.ProtocolMessage.State)));
	}
}
public enum OpenIdConnectRequestType
{
	Authentication,
	Logout,
	Token
}
public static class OpenIdConnectResponseMode
{
	public const string Query = "query";

	public const string FormPost = "form_post";

	public const string Fragment = "fragment";
}
public static class OpenIdConnectResponseType
{
	public const string Code = "code";

	public const string CodeIdToken = "code id_token";

	public const string CodeIdTokenToken = "code id_token token";

	public const string CodeToken = "code token";

	public const string IdToken = "id_token";

	public const string IdTokenToken = "id_token token";

	public const string None = "none";

	public const string Token = "token";
}
public static class OpenIdConnectScope
{
	public const string Email = "email";

	public const string OfflineAccess = "offline_access";

	public const string OpenId = "openid";

	public const string OpenIdProfile = "openid profile";

	public const string UserImpersonation = "user_impersonation";
}
public static class OpenIdConnectSessionProperties
{
	public const string CheckSessionIFrame = ".checkSessionIFrame";

	public const string RedirectUri = ".redirect_uri";

	public const string SessionState = ".sessionState";
}
public static class OpenIdProviderMetadataNames
{
	public const string AcrValuesSupported = "acr_values_supported";

	public const string AuthorizationEndpoint = "authorization_endpoint";

	public const string CheckSessionIframe = "check_session_iframe";

	public const string ClaimsLocalesSupported = "claims_locales_supported";

	public const string ClaimsParameterSupported = "claims_parameter_supported";

	public const string ClaimsSupported = "claims_supported";

	public const string ClaimTypesSupported = "claim_types_supported";

	public const string Discovery = ".well-known/openid-configuration";

	public const string DisplayValuesSupported = "display_values_supported";

	public const string EndSessionEndpoint = "end_session_endpoint";

	public const string FrontchannelLogoutSessionSupported = "frontchannel_logout_session_supported";

	public const string FrontchannelLogoutSupported = "frontchannel_logout_supported";

	public const string HttpLogoutSupported = "http_logout_supported";

	public const string GrantTypesSupported = "grant_types_supported";

	public const string IdTokenEncryptionAlgValuesSupported = "id_token_encryption_alg_values_supported";

	public const string IdTokenEncryptionEncValuesSupported = "id_token_encryption_enc_values_supported";

	public const string IdTokenSigningAlgValuesSupported = "id_token_signing_alg_values_supported";

	public const string JwksUri = "jwks_uri";

	public const string Issuer = "issuer";

	public const string LogoutSessionSupported = "logout_session_supported";

	public const string MicrosoftMultiRefreshToken = "microsoft_multi_refresh_token";

	public const string OpPolicyUri = "op_policy_uri";

	public const string OpTosUri = "op_tos_uri";

	public const string RegistrationEndpoint = "registration_endpoint";

	public const string RequestObjectEncryptionAlgValuesSupported = "request_object_encryption_alg_values_supported";

	public const string RequestObjectEncryptionEncValuesSupported = "request_object_encryption_enc_values_supported";

	public const string RequestObjectSigningAlgValuesSupported = "request_object_signing_alg_values_supported";

	public const string RequestParameterSupported = "request_parameter_supported";

	public const string RequestUriParameterSupported = "request_uri_parameter_supported";

	public const string RequireRequestUriRegistration = "require_request_uri_registration";

	public const string ResponseModesSupported = "response_modes_supported";

	public const string ResponseTypesSupported = "response_types_supported";

	public const string ServiceDocumentation = "service_documentation";

	public const string ScopesSupported = "scopes_supported";

	public const string SubjectTypesSupported = "subject_types_supported";

	public const string TokenEndpoint = "token_endpoint";

	public const string TokenEndpointAuthMethodsSupported = "token_endpoint_auth_methods_supported";

	public const string TokenEndpointAuthSigningAlgValuesSupported = "token_endpoint_auth_signing_alg_values_supported";

	public const string UILocalesSupported = "ui_locales_supported";

	public const string UserInfoEndpoint = "userinfo_endpoint";

	public const string UserInfoEncryptionAlgValuesSupported = "userinfo_encryption_alg_values_supported";

	public const string UserInfoEncryptionEncValuesSupported = "userinfo_encryption_enc_values_supported";

	public const string UserInfoSigningAlgValuesSupported = "userinfo_signing_alg_values_supported";
}
