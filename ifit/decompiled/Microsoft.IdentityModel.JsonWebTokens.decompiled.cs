using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
[assembly: InternalsVisibleTo("Microsoft.IdentityModel.JsonWebTokens.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9")]
[assembly: InternalsVisibleTo("System.IdentityModel.Tokens.Jwt, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Includes types that provide support for creating, serializing and validating JSON Web Tokens.")]
[assembly: AssemblyProduct("Microsoft IdentityModel")]
[assembly: AssemblyTitle("Microsoft.IdentityModel.JsonWebTokens")]
[assembly: AssemblyVersion("5.6.0.0")]
namespace Microsoft.IdentityModel.JsonWebTokens;

public static class JsonClaimValueTypes
{
	public const string Json = "JSON";

	public const string JsonArray = "JSON_ARRAY";

	public const string JsonNull = "JSON_NULL";
}
public class JsonWebToken : SecurityToken
{
	public string Actor => Payload.Value<string>("actort") ?? string.Empty;

	public string Alg => Header.Value<string>("alg") ?? string.Empty;

	public IEnumerable<string> Audiences
	{
		get
		{
			JToken value;
			if ((value = Payload.GetValue("aud", StringComparison.Ordinal)) != null)
			{
				if (object.Equals(JTokenType.String, value.Type))
				{
					return new List<string> { value.ToObject<string>() };
				}
				if (object.Equals(JTokenType.Array, value.Type))
				{
					return value.ToObject<List<string>>();
				}
			}
			return Enumerable.Empty<string>();
		}
	}

	public string AuthenticationTag { get; private set; }

	public string Ciphertext { get; private set; }

	public virtual IEnumerable<Claim> Claims
	{
		get
		{
			if (InnerToken != null)
			{
				return InnerToken.Claims;
			}
			if (!Payload.HasValues)
			{
				return Enumerable.Empty<Claim>();
			}
			List<Claim> list = new List<Claim>();
			string text = Issuer ?? "LOCAL AUTHORITY";
			foreach (KeyValuePair<string, JToken> item in Payload)
			{
				if (item.Value == null)
				{
					list.Add(new Claim(item.Key, string.Empty, "JSON_NULL", text, text));
					continue;
				}
				if (object.Equals(JTokenType.String, item.Value.Type))
				{
					string value = item.Value.ToObject<string>();
					list.Add(new Claim(item.Key, value, "http://www.w3.org/2001/XMLSchema#string", text, text));
					continue;
				}
				JToken value2 = item.Value;
				if (value2 != null)
				{
					AddClaimsFromJToken(list, item.Key, value2, text);
				}
			}
			return list;
		}
	}

	public string Cty => Header.Value<string>("cty") ?? string.Empty;

	public string Enc => Header.Value<string>("enc") ?? string.Empty;

	public string EncryptedKey { get; private set; }

	internal JObject Header { get; private set; } = new JObject();

	public override string Id => Payload.Value<string>("jti") ?? string.Empty;

	public string InitializationVector { get; private set; }

	public JsonWebToken InnerToken { get; internal set; }

	public DateTime IssuedAt => JwtTokenUtilities.GetDateTime("iat", Payload);

	public override string Issuer => Payload.Value<string>("iss") ?? string.Empty;

	public string Kid => Header.Value<string>("kid") ?? string.Empty;

	internal JObject Payload { get; private set; } = new JObject();

	public string EncodedHeader { get; internal set; }

	public string EncodedPayload { get; internal set; }

	public string EncodedSignature { get; internal set; }

	public string EncodedToken { get; private set; }

	public override SecurityKey SecurityKey { get; }

	public override SecurityKey SigningKey { get; set; }

	public string Subject => Payload.Value<string>("sub") ?? string.Empty;

	public string Typ => Header.Value<string>("typ") ?? string.Empty;

	public override DateTime ValidFrom => JwtTokenUtilities.GetDateTime("nbf", Payload);

	public override DateTime ValidTo => JwtTokenUtilities.GetDateTime("exp", Payload);

	public string X5t => Header.Value<string>("x5t") ?? string.Empty;

	public string Zip => Header.Value<string>("zip") ?? string.Empty;

	public JsonWebToken(string jwtEncodedString)
	{
		if (string.IsNullOrEmpty(jwtEncodedString))
		{
			throw new ArgumentNullException("jwtEncodedString");
		}
		int num = 1;
		int num2 = -1;
		while ((num2 = jwtEncodedString.IndexOf('.', num2 + 1)) != -1)
		{
			num++;
			if (num >= 3)
			{
				break;
			}
		}
		if (num == 3 || num == 5)
		{
			string[] tokenParts = jwtEncodedString.Split(new char[1] { '.' });
			Decode(tokenParts, jwtEncodedString);
			return;
		}
		throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14100: JWT is not well formed: '{0}'.\nThe token needs to be in JWS or JWE Compact Serialization Format. (JWS): 'EncodedHeader.EndcodedPayload.EncodedSignature'. (JWE): 'EncodedProtectedHeader.EncodedEncryptedKey.EncodedInitializationVector.EncodedCiphertext.EncodedAuthenticationTag'.", jwtEncodedString)));
	}

	public JsonWebToken(string header, string payload)
	{
		if (string.IsNullOrEmpty(header))
		{
			throw LogHelper.LogArgumentNullException("header");
		}
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		try
		{
			Header = JObject.Parse(header);
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14301: Unable to parse the header into a JSON object. \nHeader: '{0}'.", header), innerException));
		}
		try
		{
			Payload = JObject.Parse(payload);
		}
		catch (Exception innerException2)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14302: Unable to parse the payload into a JSON object. \nPayload: '{0}'.", payload), innerException2));
		}
	}

	private void Decode(string[] tokenParts, string rawData)
	{
		LogHelper.LogInformation("IDX14106: Decoding token: '{0}' into header, payload and signature.", rawData);
		if (!JsonWebTokenManager.RawHeaderToJObjectCache.TryGetValue(tokenParts[0], out var value))
		{
			try
			{
				Header = JObject.Parse(Base64UrlEncoder.Decode(tokenParts[0]));
				JsonWebTokenManager.RawHeaderToJObjectCache.TryAdd(tokenParts[0], Header);
			}
			catch (Exception innerException)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14102: Unable to decode the header '{0}' as Base64Url encoded string. jwtEncodedString: '{1}'.", tokenParts[0], rawData), innerException));
			}
		}
		else
		{
			Header = value;
		}
		if (tokenParts.Length == 5)
		{
			DecodeJwe(tokenParts);
		}
		else
		{
			DecodeJws(tokenParts);
		}
		EncodedToken = rawData;
	}

	private void AddClaimsFromJToken(List<Claim> claims, string claimType, JToken jtoken, string issuer)
	{
		if (object.Equals(JTokenType.Object, jtoken.Type))
		{
			claims.Add(new Claim(claimType, jtoken.ToString(Formatting.None), "JSON", issuer, issuer));
			return;
		}
		if (object.Equals(JTokenType.Array, jtoken.Type))
		{
			foreach (JToken item in jtoken as JArray)
			{
				switch (item.Type)
				{
				case JTokenType.Object:
					claims.Add(new Claim(claimType, item.ToString(Formatting.None), "JSON", issuer, issuer));
					break;
				case JTokenType.Array:
					claims.Add(new Claim(claimType, item.ToString(Formatting.None), "JSON_ARRAY", issuer, issuer));
					break;
				default:
					AddDefaultClaimFromJToken(claims, claimType, item, issuer);
					break;
				}
			}
			return;
		}
		AddDefaultClaimFromJToken(claims, claimType, jtoken, issuer);
	}

	private void AddDefaultClaimFromJToken(List<Claim> claims, string claimType, JToken jtoken, string issuer)
	{
		if (jtoken is JValue jValue)
		{
			if (object.Equals(JTokenType.String, jValue.Type))
			{
				claims.Add(new Claim(claimType, jValue.Value.ToString(), "http://www.w3.org/2001/XMLSchema#string", issuer, issuer));
			}
			else if (jValue.Value is DateTime dateTime)
			{
				claims.Add(new Claim(claimType, dateTime.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture), "http://www.w3.org/2001/XMLSchema#dateTime", issuer, issuer));
			}
			else
			{
				claims.Add(new Claim(claimType, jtoken.ToString(Formatting.None), GetClaimValueType(jValue.Value), issuer, issuer));
			}
		}
		else
		{
			claims.Add(new Claim(claimType, jtoken.ToString(Formatting.None), GetClaimValueType(jtoken), issuer, issuer));
		}
	}

	private void DecodeJwe(string[] tokenParts)
	{
		EncodedHeader = tokenParts[0];
		EncryptedKey = tokenParts[1];
		InitializationVector = tokenParts[2];
		Ciphertext = tokenParts[3];
		AuthenticationTag = tokenParts[4];
	}

	private void DecodeJws(string[] tokenParts)
	{
		if (Cty != string.Empty)
		{
			LogHelper.LogVerbose(LogHelper.FormatInvariant("IDX14105: Header.Cty != null, assuming JWS. Cty: '{0}'.", Payload.Value<string>("cty")));
		}
		try
		{
			Payload = JObject.Parse(Base64UrlEncoder.Decode(tokenParts[1]));
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14101: Unable to decode the payload '{0}' as Base64Url encoded string. jwtEncodedString: '{1}'.", tokenParts[1], EncodedToken), innerException));
		}
		EncodedHeader = tokenParts[0];
		EncodedPayload = tokenParts[1];
		EncodedSignature = tokenParts[2];
	}

	private static string GetClaimValueType(object obj)
	{
		if (obj == null)
		{
			return "JSON_NULL";
		}
		Type type = obj.GetType();
		if (type == typeof(string))
		{
			return "http://www.w3.org/2001/XMLSchema#string";
		}
		if (type == typeof(int))
		{
			return "http://www.w3.org/2001/XMLSchema#integer";
		}
		if (type == typeof(bool))
		{
			return "http://www.w3.org/2001/XMLSchema#boolean";
		}
		if (type == typeof(double))
		{
			return "http://www.w3.org/2001/XMLSchema#double";
		}
		if (type == typeof(long))
		{
			long num = (long)obj;
			if (num >= -2147483648 && num <= 2147483647)
			{
				return "http://www.w3.org/2001/XMLSchema#integer";
			}
			return "http://www.w3.org/2001/XMLSchema#integer64";
		}
		if (type == typeof(DateTime))
		{
			return "http://www.w3.org/2001/XMLSchema#dateTime";
		}
		if (type == typeof(JObject))
		{
			return "JSON";
		}
		if (type == typeof(JArray))
		{
			return "JSON_ARRAY";
		}
		return type.ToString();
	}

	public Claim GetClaim(string key)
	{
		string text = Issuer ?? "LOCAL AUTHORITY";
		if (!Payload.TryGetValue(key, out JToken value))
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14304: Claim with name '{0}' does not exist in the payload.", key)));
		}
		if (value.Type == JTokenType.Null)
		{
			return new Claim(key, string.Empty, "JSON_NULL", text, text);
		}
		if (object.Equals(JTokenType.Object, value.Type))
		{
			return new Claim(key, value.ToString(Formatting.None), "JSON", text, text);
		}
		if (object.Equals(JTokenType.Array, value.Type))
		{
			return new Claim(key, value.ToString(Formatting.None), "JSON_ARRAY", text, text);
		}
		if (value is JValue jValue)
		{
			if (object.Equals(JTokenType.String, jValue.Type))
			{
				return new Claim(key, jValue.Value.ToString(), "http://www.w3.org/2001/XMLSchema#string", text, text);
			}
			if (jValue.Value is DateTime dateTime)
			{
				return new Claim(key, dateTime.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture), "http://www.w3.org/2001/XMLSchema#dateTime", text, text);
			}
			return new Claim(key, value.ToString(Formatting.None), GetClaimValueType(jValue.Value), text, text);
		}
		return new Claim(key, value.ToString(Formatting.None), GetClaimValueType(value), text, text);
	}

	public T GetPayloadValue<T>(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (typeof(T).Equals(typeof(Claim)))
		{
			return (T)(object)GetClaim(key);
		}
		if (!Payload.TryGetValue(key, out JToken value))
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14304: Claim with name '{0}' does not exist in the payload.", key)));
		}
		try
		{
			return value.ToObject<T>();
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14305: Unable to convert the '{0}' claim to the following type: '{1}'. Claim type was: '{2}'.", key, typeof(T), value.Type), innerException));
		}
	}

	public bool TryGetClaim(string key, out Claim value)
	{
		string text = Issuer ?? "LOCAL AUTHORITY";
		if (!Payload.TryGetValue(key, out JToken value2))
		{
			value = null;
			return false;
		}
		if (value2.Type == JTokenType.Null)
		{
			value = new Claim(key, string.Empty, "JSON_NULL", text, text);
		}
		else if (object.Equals(JTokenType.Object, value2.Type))
		{
			value = new Claim(key, value2.ToString(Formatting.None), "JSON", text, text);
		}
		else if (object.Equals(JTokenType.Array, value2.Type))
		{
			value = new Claim(key, value2.ToString(Formatting.None), "JSON_ARRAY", text, text);
		}
		else if (value2 is JValue jValue)
		{
			if (object.Equals(JTokenType.String, jValue.Type))
			{
				value = new Claim(key, jValue.Value.ToString(), "http://www.w3.org/2001/XMLSchema#string", text, text);
			}
			else if (jValue.Value is DateTime dateTime)
			{
				value = new Claim(key, dateTime.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture), "http://www.w3.org/2001/XMLSchema#dateTime", text);
			}
			else
			{
				value = new Claim(key, value2.ToString(Formatting.None), GetClaimValueType(jValue.Value), text, text);
			}
		}
		else
		{
			value = new Claim(key, value2.ToString(Formatting.None), GetClaimValueType(value2), text, text);
		}
		return true;
	}

	public bool TryGetPayloadValue<T>(string key, out T value)
	{
		if (string.IsNullOrEmpty(key))
		{
			value = default(T);
			return false;
		}
		if (typeof(T).Equals(typeof(Claim)))
		{
			Claim value2;
			bool result = TryGetClaim(key, out value2);
			value = (T)(object)value2;
			return result;
		}
		if (!Payload.TryGetValue(key, out JToken value3))
		{
			value = default(T);
			return false;
		}
		try
		{
			value = value3.ToObject<T>();
		}
		catch (Exception)
		{
			value = default(T);
			return false;
		}
		return true;
	}

	public T GetHeaderValue<T>(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (!Header.TryGetValue(key, out JToken value))
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14303: Claim with name '{0}' does not exist in the header.", key)));
		}
		try
		{
			return value.ToObject<T>();
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14305: Unable to convert the '{0}' claim to the following type: '{1}'. Claim type was: '{2}'.", key, typeof(T), value.Type), innerException));
		}
	}

	public bool TryGetHeaderValue<T>(string key, out T value)
	{
		if (string.IsNullOrEmpty(key))
		{
			value = default(T);
			return false;
		}
		if (!Header.TryGetValue(key, out JToken value2))
		{
			value = default(T);
			return false;
		}
		try
		{
			value = value2.ToObject<T>();
		}
		catch (Exception)
		{
			value = default(T);
			return false;
		}
		return true;
	}
}
public class JsonWebTokenHandler : TokenHandler
{
	private List<string> _defaultHeaderParameters = new List<string> { "alg", "kid", "x5t", "enc", "zip" };

	public const string Base64UrlEncodedUnsignedJWSHeader = "eyJhbGciOiJub25lIn0";

	public Type TokenType => typeof(JsonWebToken);

	public virtual bool CanValidateToken => true;

	public virtual bool CanReadToken(string token)
	{
		if (string.IsNullOrWhiteSpace(token))
		{
			return false;
		}
		if (token.Length > MaximumTokenSizeInBytes)
		{
			LogHelper.LogInformation("IDX10209: Token has length: '{0}' which is larger than the MaximumTokenSizeInBytes: '{1}'.", token.Length, MaximumTokenSizeInBytes);
			return false;
		}
		string[] array = token.Split(new char[1] { '.' }, 6);
		if (array.Length == 3)
		{
			return JwtTokenUtilities.RegexJws.IsMatch(token);
		}
		if (array.Length == 5)
		{
			return JwtTokenUtilities.RegexJwe.IsMatch(token);
		}
		LogHelper.LogInformation("IDX14107: Token string does not match the token formats: JWE (header.encryptedKey.iv.ciphertext.tag) or JWS (header.payload.signature)");
		return false;
	}

	private JObject CreateDefaultJWEHeader(EncryptingCredentials encryptingCredentials, string compressionAlgorithm)
	{
		JObject jObject = new JObject();
		jObject.Add("alg", encryptingCredentials.Alg);
		jObject.Add("enc", encryptingCredentials.Enc);
		if (!string.IsNullOrEmpty(encryptingCredentials.Key.KeyId))
		{
			jObject.Add("kid", encryptingCredentials.Key.KeyId);
		}
		if (!string.IsNullOrEmpty(compressionAlgorithm))
		{
			jObject.Add("zip", compressionAlgorithm);
		}
		jObject.Add("typ", "JWT");
		return jObject;
	}

	private JObject CreateDefaultJWSHeader(SigningCredentials signingCredentials)
	{
		JObject jObject = new JObject { { "alg", signingCredentials.Algorithm } };
		if (signingCredentials.Key.KeyId != null)
		{
			jObject.Add("kid", signingCredentials.Key.KeyId);
		}
		jObject.Add("typ", "JWT");
		if (signingCredentials.Key is X509SecurityKey x509SecurityKey)
		{
			jObject["x5t"] = x509SecurityKey.X5t;
		}
		return jObject;
	}

	public virtual string CreateToken(string payload)
	{
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		return CreateTokenPrivate(JObject.Parse(payload), null, null, null, null);
	}

	public virtual string CreateToken(string payload, IDictionary<string, object> additionalHeaderClaims)
	{
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		if (additionalHeaderClaims == null)
		{
			throw LogHelper.LogArgumentNullException("additionalHeaderClaims");
		}
		return CreateTokenPrivate(JObject.Parse(payload), null, null, null, additionalHeaderClaims);
	}

	public virtual string CreateToken(string payload, SigningCredentials signingCredentials)
	{
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		if (signingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("signingCredentials");
		}
		return CreateTokenPrivate(JObject.Parse(payload), signingCredentials, null, null, null);
	}

	public virtual string CreateToken(string payload, SigningCredentials signingCredentials, IDictionary<string, object> additionalHeaderClaims)
	{
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		if (signingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("signingCredentials");
		}
		if (additionalHeaderClaims == null)
		{
			throw LogHelper.LogArgumentNullException("additionalHeaderClaims");
		}
		return CreateTokenPrivate(JObject.Parse(payload), signingCredentials, null, null, additionalHeaderClaims);
	}

	public virtual string CreateToken(SecurityTokenDescriptor tokenDescriptor)
	{
		if (tokenDescriptor == null)
		{
			throw LogHelper.LogArgumentNullException("tokenDescriptor");
		}
		if ((tokenDescriptor.Subject == null || !tokenDescriptor.Subject.Claims.Any()) && (tokenDescriptor.Claims == null || !tokenDescriptor.Claims.Any()))
		{
			LogHelper.LogWarning("IDX14114: Both '{0}.{1}' and '{0}.{2}' are null or empty.", "SecurityTokenDescriptor", "Subject", "Claims");
		}
		JObject jObject = ((tokenDescriptor.Subject == null) ? new JObject() : JObject.FromObject(JwtTokenUtilities.CreateDictionaryFromClaims(tokenDescriptor.Subject.Claims)));
		if (tokenDescriptor.Claims != null && tokenDescriptor.Claims.Count > 0)
		{
			jObject.Merge(JObject.FromObject(tokenDescriptor.Claims), new JsonMergeSettings
			{
				MergeArrayHandling = MergeArrayHandling.Replace
			});
		}
		if (tokenDescriptor.Audience != null)
		{
			if (jObject.Property("aud") != null)
			{
				LogHelper.LogInformation(LogHelper.FormatInvariant("IDX14113: A duplicate value for 'SecurityTokenDescriptor.{0}' exists in 'SecurityTokenDescriptor.Claims'. \nThe value of 'SecurityTokenDescriptor.{0}' is used.", "Audience"));
			}
			jObject["aud"] = tokenDescriptor.Audience;
		}
		if (tokenDescriptor.Expires.HasValue)
		{
			if (jObject.Property("exp") != null)
			{
				LogHelper.LogInformation(LogHelper.FormatInvariant("IDX14113: A duplicate value for 'SecurityTokenDescriptor.{0}' exists in 'SecurityTokenDescriptor.Claims'. \nThe value of 'SecurityTokenDescriptor.{0}' is used.", "Expires"));
			}
			jObject["exp"] = EpochTime.GetIntDate(tokenDescriptor.Expires.Value);
		}
		if (tokenDescriptor.Issuer != null)
		{
			if (jObject.Property("iss") != null)
			{
				LogHelper.LogInformation(LogHelper.FormatInvariant("IDX14113: A duplicate value for 'SecurityTokenDescriptor.{0}' exists in 'SecurityTokenDescriptor.Claims'. \nThe value of 'SecurityTokenDescriptor.{0}' is used.", "Issuer"));
			}
			jObject["iss"] = tokenDescriptor.Issuer;
		}
		if (tokenDescriptor.IssuedAt.HasValue)
		{
			if (jObject.Property("iat") != null)
			{
				LogHelper.LogInformation(LogHelper.FormatInvariant("IDX14113: A duplicate value for 'SecurityTokenDescriptor.{0}' exists in 'SecurityTokenDescriptor.Claims'. \nThe value of 'SecurityTokenDescriptor.{0}' is used.", "IssuedAt"));
			}
			jObject["iat"] = EpochTime.GetIntDate(tokenDescriptor.IssuedAt.Value);
		}
		if (tokenDescriptor.NotBefore.HasValue)
		{
			if (jObject.Property("nbf") != null)
			{
				LogHelper.LogInformation(LogHelper.FormatInvariant("IDX14113: A duplicate value for 'SecurityTokenDescriptor.{0}' exists in 'SecurityTokenDescriptor.Claims'. \nThe value of 'SecurityTokenDescriptor.{0}' is used.", "NotBefore"));
			}
			jObject["nbf"] = EpochTime.GetIntDate(tokenDescriptor.NotBefore.Value);
		}
		return CreateTokenPrivate(jObject, tokenDescriptor.SigningCredentials, tokenDescriptor.EncryptingCredentials, tokenDescriptor.CompressionAlgorithm, tokenDescriptor.AdditionalHeaderClaims);
	}

	public virtual string CreateToken(string payload, EncryptingCredentials encryptingCredentials)
	{
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		return CreateTokenPrivate(JObject.Parse(payload), null, encryptingCredentials, null, null);
	}

	public virtual string CreateToken(string payload, SigningCredentials signingCredentials, EncryptingCredentials encryptingCredentials)
	{
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		if (signingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("signingCredentials");
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		return CreateTokenPrivate(JObject.Parse(payload), signingCredentials, encryptingCredentials, null, null);
	}

	public virtual string CreateToken(string payload, SigningCredentials signingCredentials, EncryptingCredentials encryptingCredentials, IDictionary<string, object> additionalHeaderClaims)
	{
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		if (signingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("signingCredentials");
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		if (additionalHeaderClaims == null)
		{
			throw LogHelper.LogArgumentNullException("additionalHeaderClaims");
		}
		return CreateTokenPrivate(JObject.Parse(payload), signingCredentials, encryptingCredentials, null, additionalHeaderClaims);
	}

	public virtual string CreateToken(string payload, EncryptingCredentials encryptingCredentials, string compressionAlgorithm)
	{
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		if (string.IsNullOrEmpty(compressionAlgorithm))
		{
			throw LogHelper.LogArgumentNullException("compressionAlgorithm");
		}
		return CreateTokenPrivate(JObject.Parse(payload), null, encryptingCredentials, compressionAlgorithm, null);
	}

	public virtual string CreateToken(string payload, SigningCredentials signingCredentials, EncryptingCredentials encryptingCredentials, string compressionAlgorithm)
	{
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		if (signingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("signingCredentials");
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		if (string.IsNullOrEmpty(compressionAlgorithm))
		{
			throw LogHelper.LogArgumentNullException("compressionAlgorithm");
		}
		return CreateTokenPrivate(JObject.Parse(payload), signingCredentials, encryptingCredentials, compressionAlgorithm, null);
	}

	public virtual string CreateToken(string payload, SigningCredentials signingCredentials, EncryptingCredentials encryptingCredentials, string compressionAlgorithm, IDictionary<string, object> additionalHeaderClaims)
	{
		if (string.IsNullOrEmpty(payload))
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		if (signingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("signingCredentials");
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		if (string.IsNullOrEmpty(compressionAlgorithm))
		{
			throw LogHelper.LogArgumentNullException("compressionAlgorithm");
		}
		if (additionalHeaderClaims == null)
		{
			throw LogHelper.LogArgumentNullException("additionalHeaderClaims");
		}
		return CreateTokenPrivate(JObject.Parse(payload), signingCredentials, encryptingCredentials, compressionAlgorithm, additionalHeaderClaims);
	}

	private string CreateTokenPrivate(JObject payload, SigningCredentials signingCredentials, EncryptingCredentials encryptingCredentials, string compressionAlgorithm, IDictionary<string, object> additionalHeaderClaims)
	{
		if (additionalHeaderClaims != null && additionalHeaderClaims.Count > 0 && additionalHeaderClaims.Keys.Intersect(_defaultHeaderParameters, StringComparer.OrdinalIgnoreCase).Any())
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenException(LogHelper.FormatInvariant("IDX14116: ''{0}' cannot contain the following claims: '{1}'. These values are added by default (if necessary) during security token creation.", "additionalHeaderClaims", string.Join(", ", _defaultHeaderParameters))));
		}
		string value = "eyJhbGciOiJub25lIn0";
		if ((additionalHeaderClaims == null || additionalHeaderClaims.Count == 0) && signingCredentials != null && !JsonWebTokenManager.KeyToHeaderCache.TryGetValue(JsonWebTokenManager.GetHeaderCacheKey(signingCredentials), out value))
		{
			JObject jObject = CreateDefaultJWSHeader(signingCredentials);
			value = Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(jObject.ToString(Formatting.None)));
			JsonWebTokenManager.KeyToHeaderCache.TryAdd(JsonWebTokenManager.GetHeaderCacheKey(signingCredentials), value);
		}
		else if (additionalHeaderClaims != null && additionalHeaderClaims.Count != 0)
		{
			JObject jObject2 = ((signingCredentials == null) ? new JObject { { "alg", "none" } } : CreateDefaultJWSHeader(signingCredentials));
			if (encryptingCredentials == null)
			{
				jObject2.Merge(JObject.FromObject(additionalHeaderClaims));
			}
			value = Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(jObject2.ToString(Formatting.None)));
		}
		if (base.SetDefaultTimesOnTokenCreation)
		{
			long intDate = EpochTime.GetIntDate(DateTime.UtcNow);
			if (!payload.TryGetValue("exp", out JToken value2))
			{
				payload.Add("exp", (double)intDate + TimeSpan.FromMinutes(base.TokenLifetimeInMinutes).TotalSeconds);
			}
			if (!payload.TryGetValue("iat", out value2))
			{
				payload.Add("iat", intDate);
			}
			if (!payload.TryGetValue("nbf", out value2))
			{
				payload.Add("nbf", intDate);
			}
		}
		string text = Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(payload.ToString(Formatting.None)));
		string text2 = value + "." + text;
		string text3 = ((signingCredentials == null) ? string.Empty : JwtTokenUtilities.CreateEncodedSignature(text2, signingCredentials));
		if (encryptingCredentials != null)
		{
			return EncryptTokenPrivate(text2 + "." + text3, encryptingCredentials, compressionAlgorithm, additionalHeaderClaims);
		}
		return text2 + "." + text3;
	}

	private byte[] CompressToken(string token, string compressionAlgorithm)
	{
		if (token == null)
		{
			throw LogHelper.LogArgumentNullException("token");
		}
		if (string.IsNullOrEmpty(compressionAlgorithm))
		{
			throw LogHelper.LogArgumentNullException("compressionAlgorithm");
		}
		if (!CompressionProviderFactory.Default.IsSupportedAlgorithm(compressionAlgorithm))
		{
			throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10682: Compression algorithm '{0}' is not supported.", compressionAlgorithm)));
		}
		return CompressionProviderFactory.Default.CreateCompressionProvider(compressionAlgorithm).Compress(Encoding.UTF8.GetBytes(token)) ?? throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10680: Failed to compress using algorithm '{0}'.", compressionAlgorithm)));
	}

	protected virtual ClaimsIdentity CreateClaimsIdentity(JsonWebToken jwtToken, TokenValidationParameters validationParameters)
	{
		if (jwtToken == null)
		{
			throw LogHelper.LogArgumentNullException("jwtToken");
		}
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		string text = jwtToken.Issuer;
		if (string.IsNullOrWhiteSpace(text))
		{
			LogHelper.LogVerbose("IDX10244: Issuer is null or empty. Using runtime default for creating claims '{0}'.", "LOCAL AUTHORITY");
			text = "LOCAL AUTHORITY";
		}
		return CreateClaimsIdentity(jwtToken, validationParameters, text);
	}

	private ClaimsIdentity CreateClaimsIdentity(JsonWebToken jwtToken, TokenValidationParameters validationParameters, string actualIssuer)
	{
		ClaimsIdentity claimsIdentity = validationParameters.CreateClaimsIdentity(jwtToken, actualIssuer);
		foreach (Claim claim2 in jwtToken.Claims)
		{
			string type = claim2.Type;
			if (type == "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor")
			{
				if (claimsIdentity.Actor != null)
				{
					throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX14112: Only a single 'Actor' is supported. Found second claim of type: '{0}', value: '{1}'", "actort", claim2.Value)));
				}
				if (CanReadToken(claim2.Value))
				{
					JsonWebToken jwtToken2 = ReadToken(claim2.Value) as JsonWebToken;
					claimsIdentity.Actor = CreateClaimsIdentity(jwtToken2, validationParameters, actualIssuer);
				}
			}
			if (claim2.Properties.Count == 0)
			{
				claimsIdentity.AddClaim(new Claim(type, claim2.Value, claim2.ValueType, actualIssuer, actualIssuer, claimsIdentity));
				continue;
			}
			Claim claim = new Claim(type, claim2.Value, claim2.ValueType, actualIssuer, actualIssuer, claimsIdentity);
			foreach (KeyValuePair<string, string> property in claim2.Properties)
			{
				claim.Properties[property.Key] = property.Value;
			}
			claimsIdentity.AddClaim(claim);
		}
		return claimsIdentity;
	}

	protected string DecryptToken(JsonWebToken jwtToken, TokenValidationParameters validationParameters)
	{
		if (jwtToken == null)
		{
			throw LogHelper.LogArgumentNullException("jwtToken");
		}
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (string.IsNullOrEmpty(jwtToken.Enc))
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenException(LogHelper.FormatInvariant("IDX10612: Decryption failed. Header.Enc is null or empty, it must be specified.")));
		}
		IEnumerable<SecurityKey> contentEncryptionKeys = GetContentEncryptionKeys(jwtToken, validationParameters);
		bool flag = false;
		byte[] array = null;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		foreach (SecurityKey item in contentEncryptionKeys)
		{
			CryptoProviderFactory cryptoProviderFactory = validationParameters.CryptoProviderFactory ?? item.CryptoProviderFactory;
			if (cryptoProviderFactory == null)
			{
				LogHelper.LogWarning("IDX10607: Decryption skipping key: '{0}', both validationParameters.CryptoProviderFactory and key.CryptoProviderFactory are null.", item);
				continue;
			}
			if (!cryptoProviderFactory.IsSupportedAlgorithm(jwtToken.Enc, item))
			{
				LogHelper.LogWarning("IDX10611: Decryption failed. Encryption is not supported for: Algorithm: '{0}', SecurityKey: '{1}'.", jwtToken.Enc, item);
				continue;
			}
			try
			{
				array = DecryptToken(jwtToken, cryptoProviderFactory, item);
				flag = true;
			}
			catch (Exception ex)
			{
				stringBuilder.AppendLine(ex.ToString());
				goto IL_00f2;
			}
			break;
			IL_00f2:
			if (item != null)
			{
				stringBuilder2.AppendLine(item.ToString());
			}
		}
		if (!flag && stringBuilder2.Length > 0)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenDecryptionFailedException(LogHelper.FormatInvariant("IDX10603: Decryption failed. Keys tried: '{0}'.\nExceptions caught:\n '{1}'.\ntoken: '{2}'", stringBuilder2, stringBuilder, jwtToken.EncodedToken)));
		}
		if (!flag)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenDecryptionFailedException(LogHelper.FormatInvariant("IDX10609: Decryption failed. No Keys tried: token: '{0}'.", jwtToken.EncodedToken)));
		}
		if (string.IsNullOrEmpty(jwtToken.Zip))
		{
			return Encoding.UTF8.GetString(array);
		}
		try
		{
			return JwtTokenUtilities.DecompressToken(array, jwtToken.Zip);
		}
		catch (Exception inner)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenDecompressionFailedException(LogHelper.FormatInvariant("IDX10679: Failed to decompress using algorithm '{0}'.", jwtToken.Zip), inner));
		}
	}

	private byte[] DecryptToken(JsonWebToken jwtToken, CryptoProviderFactory cryptoProviderFactory, SecurityKey key)
	{
		AuthenticatedEncryptionProvider authenticatedEncryptionProvider = cryptoProviderFactory.CreateAuthenticatedEncryptionProvider(key, jwtToken.Enc);
		if (authenticatedEncryptionProvider == null)
		{
			throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10610: Decryption failed. Could not create decryption provider. Key: '{0}', Algorithm: '{1}'.", key, jwtToken.Enc)));
		}
		return authenticatedEncryptionProvider.Decrypt(Base64UrlEncoder.DecodeBytes(jwtToken.Ciphertext), Encoding.ASCII.GetBytes(jwtToken.EncodedHeader), Base64UrlEncoder.DecodeBytes(jwtToken.InitializationVector), Base64UrlEncoder.DecodeBytes(jwtToken.AuthenticationTag));
	}

	public string EncryptToken(string innerJwt, EncryptingCredentials encryptingCredentials)
	{
		if (string.IsNullOrEmpty(innerJwt))
		{
			throw LogHelper.LogArgumentNullException("innerJwt");
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		return EncryptTokenPrivate(innerJwt, encryptingCredentials, null, null);
	}

	public string EncryptToken(string innerJwt, EncryptingCredentials encryptingCredentials, IDictionary<string, object> additionalHeaderClaims)
	{
		if (string.IsNullOrEmpty(innerJwt))
		{
			throw LogHelper.LogArgumentNullException("innerJwt");
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		if (additionalHeaderClaims == null)
		{
			throw LogHelper.LogArgumentNullException("additionalHeaderClaims");
		}
		return EncryptTokenPrivate(innerJwt, encryptingCredentials, null, additionalHeaderClaims);
	}

	public string EncryptToken(string innerJwt, EncryptingCredentials encryptingCredentials, string algorithm)
	{
		if (string.IsNullOrEmpty(innerJwt))
		{
			throw LogHelper.LogArgumentNullException("innerJwt");
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		return EncryptTokenPrivate(innerJwt, encryptingCredentials, algorithm, null);
	}

	public string EncryptToken(string innerJwt, EncryptingCredentials encryptingCredentials, string algorithm, IDictionary<string, object> additionalHeaderClaims)
	{
		if (string.IsNullOrEmpty(innerJwt))
		{
			throw LogHelper.LogArgumentNullException("innerJwt");
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (additionalHeaderClaims == null)
		{
			throw LogHelper.LogArgumentNullException("additionalHeaderClaims");
		}
		return EncryptTokenPrivate(innerJwt, encryptingCredentials, algorithm, additionalHeaderClaims);
	}

	private string EncryptTokenPrivate(string innerJwt, EncryptingCredentials encryptingCredentials, string compressionAlgorithm, IDictionary<string, object> additionalHeaderClaims)
	{
		CryptoProviderFactory cryptoProviderFactory = encryptingCredentials.CryptoProviderFactory ?? encryptingCredentials.Key.CryptoProviderFactory;
		if (cryptoProviderFactory == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException("IDX14104: Unable to obtain a CryptoProviderFactory, EncryptingCredentials.CryptoProviderFactory and EncryptingCredentials.Key.CrypoProviderFactory are both null."));
		}
		if ("dir".Equals(encryptingCredentials.Alg, StringComparison.Ordinal))
		{
			if (!cryptoProviderFactory.IsSupportedAlgorithm(encryptingCredentials.Enc, encryptingCredentials.Key))
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException(LogHelper.FormatInvariant("IDX10615: Encryption failed. No support for: Algorithm: '{0}', SecurityKey: '{1}'.", encryptingCredentials.Enc, encryptingCredentials.Key)));
			}
			JObject jObject = CreateDefaultJWEHeader(encryptingCredentials, compressionAlgorithm);
			if (additionalHeaderClaims != null)
			{
				jObject.Merge(JObject.FromObject(additionalHeaderClaims));
			}
			AuthenticatedEncryptionProvider authenticatedEncryptionProvider = cryptoProviderFactory.CreateAuthenticatedEncryptionProvider(encryptingCredentials.Key, encryptingCredentials.Enc);
			if (authenticatedEncryptionProvider == null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException("IDX14103: Failed to create the token encryption provider."));
			}
			byte[] plaintext;
			if (!string.IsNullOrEmpty(compressionAlgorithm))
			{
				try
				{
					plaintext = CompressToken(innerJwt, compressionAlgorithm);
				}
				catch (Exception inner)
				{
					throw LogHelper.LogExceptionMessage(new SecurityTokenCompressionFailedException(LogHelper.FormatInvariant("IDX10680: Failed to compress using algorithm '{0}'.", compressionAlgorithm), inner));
				}
			}
			else
			{
				plaintext = Encoding.UTF8.GetBytes(innerJwt);
			}
			try
			{
				string text = Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(jObject.ToString(Formatting.None)));
				AuthenticatedEncryptionResult authenticatedEncryptionResult = authenticatedEncryptionProvider.Encrypt(plaintext, Encoding.ASCII.GetBytes(text));
				return string.Join(".", text, string.Empty, Base64UrlEncoder.Encode(authenticatedEncryptionResult.IV), Base64UrlEncoder.Encode(authenticatedEncryptionResult.Ciphertext), Base64UrlEncoder.Encode(authenticatedEncryptionResult.AuthenticationTag));
			}
			catch (Exception innerException)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException(LogHelper.FormatInvariant("IDX10616: Encryption failed. EncryptionProvider failed for: Algorithm: '{0}', SecurityKey: '{1}'. See inner exception.", encryptingCredentials.Enc, encryptingCredentials.Key), innerException));
			}
		}
		if (!cryptoProviderFactory.IsSupportedAlgorithm(encryptingCredentials.Alg, encryptingCredentials.Key))
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException(LogHelper.FormatInvariant("IDX10615: Encryption failed. No support for: Algorithm: '{0}', SecurityKey: '{1}'.", encryptingCredentials.Alg, encryptingCredentials.Key)));
		}
		SymmetricSecurityKey symmetricSecurityKey = null;
		if ("A128CBC-HS256".Equals(encryptingCredentials.Enc, StringComparison.Ordinal))
		{
			symmetricSecurityKey = new SymmetricSecurityKey(JwtTokenUtilities.GenerateKeyBytes(256));
		}
		else if ("A192CBC-HS384".Equals(encryptingCredentials.Enc, StringComparison.Ordinal))
		{
			symmetricSecurityKey = new SymmetricSecurityKey(JwtTokenUtilities.GenerateKeyBytes(384));
		}
		else
		{
			if (!"A256CBC-HS512".Equals(encryptingCredentials.Enc, StringComparison.Ordinal))
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException(LogHelper.FormatInvariant("IDX10617: Encryption failed. Keywrap is only supported for: '{0}', '{1}' and '{2}'. The content encryption specified is: '{3}'.", "A128CBC-HS256", "A192CBC-HS384", "A256CBC-HS512", encryptingCredentials.Enc)));
			}
			symmetricSecurityKey = new SymmetricSecurityKey(JwtTokenUtilities.GenerateKeyBytes(512));
		}
		byte[] inArray = cryptoProviderFactory.CreateKeyWrapProvider(encryptingCredentials.Key, encryptingCredentials.Alg).WrapKey(symmetricSecurityKey.Key);
		AuthenticatedEncryptionProvider authenticatedEncryptionProvider2 = cryptoProviderFactory.CreateAuthenticatedEncryptionProvider(symmetricSecurityKey, encryptingCredentials.Enc);
		if (authenticatedEncryptionProvider2 == null)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException("IDX14103: Failed to create the token encryption provider."));
		}
		JObject jObject2 = CreateDefaultJWEHeader(encryptingCredentials, compressionAlgorithm);
		if (additionalHeaderClaims != null)
		{
			jObject2.Merge(JObject.FromObject(additionalHeaderClaims));
		}
		byte[] plaintext2;
		if (!string.IsNullOrEmpty(compressionAlgorithm))
		{
			try
			{
				plaintext2 = CompressToken(innerJwt, compressionAlgorithm);
			}
			catch (Exception inner2)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenCompressionFailedException(LogHelper.FormatInvariant("IDX10680: Failed to compress using algorithm '{0}'.", compressionAlgorithm), inner2));
			}
		}
		else
		{
			plaintext2 = Encoding.UTF8.GetBytes(innerJwt);
		}
		try
		{
			string text2 = Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(jObject2.ToString(Formatting.None)));
			AuthenticatedEncryptionResult authenticatedEncryptionResult2 = authenticatedEncryptionProvider2.Encrypt(plaintext2, Encoding.ASCII.GetBytes(text2));
			return string.Join(".", text2, Base64UrlEncoder.Encode(inArray), Base64UrlEncoder.Encode(authenticatedEncryptionResult2.IV), Base64UrlEncoder.Encode(authenticatedEncryptionResult2.Ciphertext), Base64UrlEncoder.Encode(authenticatedEncryptionResult2.AuthenticationTag));
		}
		catch (Exception innerException2)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException(LogHelper.FormatInvariant("IDX10616: Encryption failed. EncryptionProvider failed for: Algorithm: '{0}', SecurityKey: '{1}'. See inner exception.", encryptingCredentials.Enc, encryptingCredentials.Key), innerException2));
		}
	}

	private IEnumerable<SecurityKey> GetAllSigningKeys(string token, TokenValidationParameters validationParameters)
	{
		LogHelper.LogInformation("IDX10243: Reading issuer signing keys from validation parameters.");
		if (validationParameters.IssuerSigningKey != null)
		{
			yield return validationParameters.IssuerSigningKey;
		}
		if (validationParameters.IssuerSigningKeys == null)
		{
			yield break;
		}
		foreach (SecurityKey issuerSigningKey in validationParameters.IssuerSigningKeys)
		{
			yield return issuerSigningKey;
		}
	}

	private IEnumerable<SecurityKey> GetContentEncryptionKeys(JsonWebToken jwtToken, TokenValidationParameters validationParameters)
	{
		IEnumerable<SecurityKey> enumerable = null;
		if (validationParameters.TokenDecryptionKeyResolver != null)
		{
			enumerable = validationParameters.TokenDecryptionKeyResolver(jwtToken.EncodedToken, jwtToken, jwtToken.Kid, validationParameters);
		}
		else
		{
			SecurityKey securityKey = ResolveTokenDecryptionKey(jwtToken.EncodedToken, jwtToken, validationParameters);
			if (securityKey != null)
			{
				enumerable = new List<SecurityKey> { securityKey };
			}
		}
		if (enumerable == null)
		{
			enumerable = JwtTokenUtilities.GetAllDecryptionKeys(validationParameters);
		}
		if (jwtToken.Alg.Equals("dir", StringComparison.Ordinal))
		{
			return enumerable;
		}
		List<SecurityKey> list = new List<SecurityKey>();
		foreach (SecurityKey item in enumerable)
		{
			if (item.CryptoProviderFactory.IsSupportedAlgorithm(jwtToken.Alg, item))
			{
				byte[] key = item.CryptoProviderFactory.CreateKeyWrapProviderForUnwrap(item, jwtToken.Alg).UnwrapKey(Base64UrlEncoder.DecodeBytes(jwtToken.EncryptedKey));
				list.Add(new SymmetricSecurityKey(key));
			}
		}
		return list;
	}

	internal virtual SecurityKey ResolveIssuerSigningKey(JsonWebToken jwtToken, TokenValidationParameters validationParameters)
	{
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (jwtToken == null)
		{
			throw LogHelper.LogArgumentNullException("jwtToken");
		}
		if (!string.IsNullOrEmpty(jwtToken.Kid))
		{
			string kid = jwtToken.Kid;
			if (validationParameters.IssuerSigningKey != null && string.Equals(validationParameters.IssuerSigningKey.KeyId, kid, (validationParameters.IssuerSigningKey is X509SecurityKey) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
			{
				return validationParameters.IssuerSigningKey;
			}
			if (validationParameters.IssuerSigningKeys != null)
			{
				foreach (SecurityKey issuerSigningKey in validationParameters.IssuerSigningKeys)
				{
					if (issuerSigningKey != null && string.Equals(issuerSigningKey.KeyId, kid, (issuerSigningKey is X509SecurityKey) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
					{
						return issuerSigningKey;
					}
				}
			}
		}
		if (!string.IsNullOrEmpty(jwtToken.X5t))
		{
			string x5t = jwtToken.X5t;
			if (validationParameters.IssuerSigningKey != null)
			{
				if (string.Equals(validationParameters.IssuerSigningKey.KeyId, x5t, (validationParameters.IssuerSigningKey is X509SecurityKey) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
				{
					return validationParameters.IssuerSigningKey;
				}
				if (validationParameters.IssuerSigningKey is X509SecurityKey x509SecurityKey && string.Equals(x509SecurityKey.X5t, x5t, StringComparison.OrdinalIgnoreCase))
				{
					return validationParameters.IssuerSigningKey;
				}
			}
			if (validationParameters.IssuerSigningKeys != null)
			{
				foreach (SecurityKey issuerSigningKey2 in validationParameters.IssuerSigningKeys)
				{
					if (issuerSigningKey2 != null && string.Equals(issuerSigningKey2.KeyId, x5t, (issuerSigningKey2 is X509SecurityKey) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
					{
						return issuerSigningKey2;
					}
				}
			}
		}
		return null;
	}

	protected virtual SecurityKey ResolveTokenDecryptionKey(string token, JsonWebToken jwtToken, TokenValidationParameters validationParameters)
	{
		if (jwtToken == null)
		{
			throw LogHelper.LogArgumentNullException("jwtToken");
		}
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		return JwtTokenUtilities.FindKeyMatch(jwtToken.Kid, jwtToken.X5t, validationParameters.TokenDecryptionKey, validationParameters.TokenDecryptionKeys);
	}

	public virtual JsonWebToken ReadJsonWebToken(string token)
	{
		if (string.IsNullOrEmpty(token))
		{
			throw LogHelper.LogArgumentNullException("token");
		}
		if (token.Length > MaximumTokenSizeInBytes)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10209: Token has length: '{0}' which is larger than the MaximumTokenSizeInBytes: '{1}'.", token.Length, MaximumTokenSizeInBytes)));
		}
		return new JsonWebToken(token);
	}

	public virtual SecurityToken ReadToken(string token)
	{
		return ReadJsonWebToken(token);
	}

	public virtual TokenValidationResult ValidateToken(string token, TokenValidationParameters validationParameters)
	{
		if (string.IsNullOrEmpty(token))
		{
			return new TokenValidationResult
			{
				Exception = LogHelper.LogArgumentNullException("token")
			};
		}
		if (validationParameters == null)
		{
			return new TokenValidationResult
			{
				Exception = LogHelper.LogArgumentNullException("validationParameters")
			};
		}
		if (token.Length > MaximumTokenSizeInBytes)
		{
			TokenValidationResult tokenValidationResult = new TokenValidationResult();
			tokenValidationResult.Exception = LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10209: Token has length: '{0}' which is larger than the MaximumTokenSizeInBytes: '{1}'.", token.Length, MaximumTokenSizeInBytes)));
			return tokenValidationResult;
		}
		string[] array = token.Split(new char[1] { '.' }, 6);
		if (array.Length != 3 && array.Length != 5)
		{
			TokenValidationResult tokenValidationResult = new TokenValidationResult();
			tokenValidationResult.Exception = LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX14111: JWT: '{0}' must have three segments (JWS) or five segments (JWE).", token)));
			return tokenValidationResult;
		}
		try
		{
			if (array.Length == 5)
			{
				JsonWebToken jsonWebToken = new JsonWebToken(token);
				string token2 = DecryptToken(jsonWebToken, validationParameters);
				JsonWebToken jsonWebToken2 = (jsonWebToken.InnerToken = ValidateSignature(token2, validationParameters));
				TokenValidationResult tokenValidationResult2 = ValidateTokenPayload(jsonWebToken2, validationParameters);
				return new TokenValidationResult
				{
					SecurityToken = jsonWebToken,
					ClaimsIdentity = tokenValidationResult2.ClaimsIdentity,
					IsValid = true
				};
			}
			JsonWebToken jsonWebToken4 = ValidateSignature(token, validationParameters);
			return ValidateTokenPayload(jsonWebToken4, validationParameters);
		}
		catch (Exception exception)
		{
			return new TokenValidationResult
			{
				Exception = exception
			};
		}
	}

	private TokenValidationResult ValidateTokenPayload(JsonWebToken jsonWebToken, TokenValidationParameters validationParameters)
	{
		_ = jsonWebToken.ValidTo;
		DateTime? dateTime = jsonWebToken.ValidTo;
		_ = jsonWebToken.ValidFrom;
		Validators.ValidateLifetime(jsonWebToken.ValidFrom, dateTime, jsonWebToken, validationParameters);
		Validators.ValidateAudience(jsonWebToken.Audiences, jsonWebToken, validationParameters);
		string actualIssuer = Validators.ValidateIssuer(jsonWebToken.Issuer, jsonWebToken, validationParameters);
		Validators.ValidateTokenReplay(dateTime, jsonWebToken.EncodedToken, validationParameters);
		if (validationParameters.ValidateActor && !string.IsNullOrWhiteSpace(jsonWebToken.Actor))
		{
			ValidateToken(jsonWebToken.Actor, validationParameters.ActorValidationParameters ?? validationParameters);
		}
		Validators.ValidateIssuerSecurityKey(jsonWebToken.SigningKey, jsonWebToken, validationParameters);
		JwtTokenUtilities.ValidateTokenType(jsonWebToken.Typ, validationParameters);
		return new TokenValidationResult
		{
			SecurityToken = jsonWebToken,
			ClaimsIdentity = CreateClaimsIdentity(jsonWebToken, validationParameters, actualIssuer),
			IsValid = true
		};
	}

	private JsonWebToken ValidateSignature(string token, TokenValidationParameters validationParameters)
	{
		if (string.IsNullOrWhiteSpace(token))
		{
			throw LogHelper.LogArgumentNullException("token");
		}
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (validationParameters.SignatureValidator != null)
		{
			SecurityToken securityToken = validationParameters.SignatureValidator(token, validationParameters);
			if (securityToken == null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10505: Signature validation failed. The user defined 'Delegate' specified on TokenValidationParameters returned null when validating token: '{0}'.", token)));
			}
			JsonWebToken jsonWebToken = securityToken as JsonWebToken;
			if (jsonWebToken == null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10506: Signature validation failed. The user defined 'Delegate' specified on TokenValidationParameters did not return a '{0}', but returned a '{1}' when validating token: '{2}'.", typeof(JsonWebToken), jsonWebToken.GetType(), token)));
			}
			return jsonWebToken;
		}
		JsonWebToken jsonWebToken2 = null;
		if (validationParameters.TokenReader != null)
		{
			SecurityToken securityToken2 = validationParameters.TokenReader(token, validationParameters);
			if (securityToken2 == null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10510: Signature validation failed. The user defined 'Delegate' specified in TokenValidationParameters returned null when reading token: '{0}'.", token)));
			}
			jsonWebToken2 = securityToken2 as JsonWebToken;
			if (jsonWebToken2 == null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10509: Signature validation failed. The user defined 'Delegate' specified in TokenValidationParameters did not return a '{0}', but returned a '{1}' when reading token: '{2}'.", typeof(JsonWebToken), securityToken2.GetType(), token)));
			}
		}
		else
		{
			jsonWebToken2 = new JsonWebToken(token);
		}
		byte[] bytes = Encoding.UTF8.GetBytes(jsonWebToken2.EncodedHeader + "." + jsonWebToken2.EncodedPayload);
		if (string.IsNullOrEmpty(jsonWebToken2.EncodedSignature))
		{
			if (validationParameters.RequireSignedTokens)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10504: Unable to validate signature, token does not have a signature: '{0}'.", token)));
			}
			return jsonWebToken2;
		}
		bool flag = false;
		IEnumerable<SecurityKey> enumerable = null;
		if (validationParameters.IssuerSigningKeyResolver != null)
		{
			enumerable = validationParameters.IssuerSigningKeyResolver(token, jsonWebToken2, jsonWebToken2.Kid, validationParameters);
		}
		else
		{
			SecurityKey securityKey = ResolveIssuerSigningKey(jsonWebToken2, validationParameters);
			if (securityKey != null)
			{
				flag = true;
				enumerable = new List<SecurityKey> { securityKey };
			}
		}
		if (enumerable == null)
		{
			enumerable = GetAllSigningKeys(token, validationParameters);
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		bool flag2 = !string.IsNullOrEmpty(jsonWebToken2.Kid);
		byte[] signature;
		try
		{
			signature = Base64UrlEncoder.DecodeBytes(jsonWebToken2.EncodedSignature);
		}
		catch (FormatException innerException)
		{
			throw new SecurityTokenInvalidSignatureException("IDX10508: Signature validation failed. Signature is improperly formatted.", innerException);
		}
		foreach (SecurityKey item in enumerable)
		{
			try
			{
				if (ValidateSignature(bytes, signature, item, jsonWebToken2.Alg, validationParameters))
				{
					LogHelper.LogInformation("IDX10242: Security token: '{0}' has a valid signature.", token);
					jsonWebToken2.SigningKey = item;
					return jsonWebToken2;
				}
			}
			catch (Exception ex)
			{
				stringBuilder.AppendLine(ex.ToString());
			}
			if (item != null)
			{
				stringBuilder2.AppendLine(item.ToString() + " , KeyId: " + item.KeyId);
				if (flag2 && !flag && item.KeyId != null)
				{
					flag = jsonWebToken2.Kid.Equals(item.KeyId, (item is X509SecurityKey) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
				}
			}
		}
		if (flag2)
		{
			if (flag)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10511: Signature validation failed. Keys tried: '{0}'. \nkid: '{1}'. \nExceptions caught:\n '{2}'.\ntoken: '{3}'.", stringBuilder2, jsonWebToken2.Kid, stringBuilder, jsonWebToken2)));
			}
			throw LogHelper.LogExceptionMessage(new SecurityTokenSignatureKeyNotFoundException(LogHelper.FormatInvariant("IDX10501: Signature validation failed. Unable to match key: \nkid: '{0}'.\nExceptions caught:\n '{1}'. \ntoken: '{2}'.", jsonWebToken2.Kid, stringBuilder, jsonWebToken2)));
		}
		if (stringBuilder2.Length > 0)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10503: Signature validation failed. Keys tried: '{0}'.\nExceptions caught:\n '{1}'.\ntoken: '{2}'.", stringBuilder2, stringBuilder, jsonWebToken2)));
		}
		throw LogHelper.LogExceptionMessage(new SecurityTokenSignatureKeyNotFoundException("IDX10500: Signature validation failed. No security keys were provided to validate the signature."));
	}

	private bool ValidateSignature(byte[] encodedBytes, byte[] signature, SecurityKey key, string algorithm, TokenValidationParameters validationParameters)
	{
		CryptoProviderFactory cryptoProviderFactory = validationParameters.CryptoProviderFactory ?? key.CryptoProviderFactory;
		if (!cryptoProviderFactory.IsSupportedAlgorithm(algorithm, key))
		{
			LogHelper.LogInformation("IDX14000: Signing JWT is not supported for: Algorithm: '{0}', SecurityKey: '{1}'.", algorithm, key);
			return false;
		}
		SignatureProvider signatureProvider = cryptoProviderFactory.CreateForVerifying(key, algorithm);
		if (signatureProvider == null)
		{
			throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10647: A CustomCryptoProvider was set and returned 'true' for IsSupportedAlgorithm(Algorithm: '{0}'), but Create.(algorithm, args) as '{1}' == NULL.", (key == null) ? "Null" : key.ToString(), (algorithm == null) ? "Null" : algorithm)));
		}
		try
		{
			return signatureProvider.Verify(encodedBytes, signature);
		}
		finally
		{
			cryptoProviderFactory.ReleaseSignatureProvider(signatureProvider);
		}
	}
}
internal static class JsonWebTokenManager
{
	internal static ConcurrentDictionary<string, string> KeyToHeaderCache = new ConcurrentDictionary<string, string>();

	internal static ConcurrentDictionary<string, JObject> RawHeaderToJObjectCache = new ConcurrentDictionary<string, JObject>();

	internal static string GetHeaderCacheKey(SecurityKey securityKey, string algorithm)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0}-{1}-{2}", securityKey.GetType(), securityKey.KeyId, algorithm);
	}

	internal static string GetHeaderCacheKey(SigningCredentials signingCredentials)
	{
		if (signingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("signingCredentials");
		}
		return GetHeaderCacheKey(signingCredentials.Key, signingCredentials.Algorithm);
	}
}
public static class JwtConstants
{
	public const string HeaderType = "JWT";

	public const string HeaderTypeAlt = "http://openid.net/specs/jwt/1.0";

	public const string TokenType = "JWT";

	public const string TokenTypeAlt = "urn:ietf:params:oauth:token-type:jwt";

	public const string JsonCompactSerializationRegex = "^[A-Za-z0-9-_]+\\.[A-Za-z0-9-_]+\\.[A-Za-z0-9-_]*$";

	public const string JweCompactSerializationRegex = "^[A-Za-z0-9-_]+\\.[A-Za-z0-9-_]*\\.[A-Za-z0-9-_]+\\.[A-Za-z0-9-_]+\\.[A-Za-z0-9-_]+$";

	public const int JweSegmentCount = 5;

	public const int JwsSegmentCount = 3;

	public const int MaxJwtSegmentCount = 5;

	public const string DirectKeyUseAlg = "dir";
}
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct JwtHeaderParameterNames
{
	public const string Alg = "alg";

	public const string Cty = "cty";

	public const string Enc = "enc";

	public const string IV = "iv";

	public const string Jku = "jku";

	public const string Jwk = "jwk";

	public const string Kid = "kid";

	public const string Typ = "typ";

	public const string X5c = "x5c";

	public const string X5t = "x5t";

	public const string X5u = "x5u";

	public const string Zip = "zip";
}
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct JwtRegisteredClaimNames
{
	public const string Actort = "actort";

	public const string Acr = "acr";

	public const string Amr = "amr";

	public const string Aud = "aud";

	public const string AuthTime = "auth_time";

	public const string Azp = "azp";

	public const string Birthdate = "birthdate";

	public const string CHash = "c_hash";

	public const string AtHash = "at_hash";

	public const string Email = "email";

	public const string Exp = "exp";

	public const string Gender = "gender";

	public const string FamilyName = "family_name";

	public const string GivenName = "given_name";

	public const string Iat = "iat";

	public const string Iss = "iss";

	public const string Jti = "jti";

	public const string NameId = "nameid";

	public const string Nonce = "nonce";

	public const string Nbf = "nbf";

	public const string Prn = "prn";

	public const string Sid = "sid";

	public const string Sub = "sub";

	public const string Typ = "typ";

	public const string UniqueName = "unique_name";

	public const string Website = "website";
}
public class JwtTokenUtilities
{
	public static Regex RegexJws = new Regex("^[A-Za-z0-9-_]+\\.[A-Za-z0-9-_]+\\.[A-Za-z0-9-_]*$", RegexOptions.Compiled | RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(100.0));

	public static Regex RegexJwe = new Regex("^[A-Za-z0-9-_]+\\.[A-Za-z0-9-_]*\\.[A-Za-z0-9-_]+\\.[A-Za-z0-9-_]+\\.[A-Za-z0-9-_]+$", RegexOptions.Compiled | RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(100.0));

	internal static Dictionary<string, object> CreateDictionaryFromClaims(IEnumerable<Claim> claims)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (claims == null)
		{
			return dictionary;
		}
		foreach (Claim claim in claims)
		{
			if (claim == null)
			{
				continue;
			}
			string type = claim.Type;
			object obj = (claim.ValueType.Equals("http://www.w3.org/2001/XMLSchema#string", StringComparison.Ordinal) ? claim.Value : GetClaimValueUsingValueType(claim));
			if (dictionary.TryGetValue(type, out var value))
			{
				IList<object> list = value as IList<object>;
				if (list == null)
				{
					list = new List<object>();
					list.Add(value);
					dictionary[type] = list;
				}
				list.Add(obj);
			}
			else
			{
				dictionary[type] = obj;
			}
		}
		return dictionary;
	}

	public static string CreateEncodedSignature(string input, SigningCredentials signingCredentials)
	{
		if (input == null)
		{
			throw LogHelper.LogArgumentNullException("input");
		}
		if (signingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("signingCredentials");
		}
		CryptoProviderFactory cryptoProviderFactory = signingCredentials.CryptoProviderFactory ?? signingCredentials.Key.CryptoProviderFactory;
		SignatureProvider signatureProvider = cryptoProviderFactory.CreateForSigning(signingCredentials.Key, signingCredentials.Algorithm);
		if (signatureProvider == null)
		{
			throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10636: CryptoProviderFactory.CreateForVerifying returned null for key: '{0}', signatureAlgorithm: '{1}'.", (signingCredentials.Key == null) ? "Null" : signingCredentials.Key.ToString(), signingCredentials.Algorithm ?? "Null")));
		}
		try
		{
			LogHelper.LogVerbose("IDX14200: Creating raw signature using the signature credentials.");
			return Base64UrlEncoder.Encode(signatureProvider.Sign(Encoding.UTF8.GetBytes(input)));
		}
		finally
		{
			cryptoProviderFactory.ReleaseSignatureProvider(signatureProvider);
		}
	}

	internal static string DecompressToken(byte[] tokenBytes, string algorithm)
	{
		if (tokenBytes == null)
		{
			throw LogHelper.LogArgumentNullException("tokenBytes");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (!CompressionProviderFactory.Default.IsSupportedAlgorithm(algorithm))
		{
			throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10682: Compression algorithm '{0}' is not supported.", algorithm)));
		}
		byte[] array = CompressionProviderFactory.Default.CreateCompressionProvider(algorithm).Decompress(tokenBytes);
		if (array == null)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenDecompressionFailedException(LogHelper.FormatInvariant("IDX10679: Failed to decompress using algorithm '{0}'.", algorithm)));
		}
		return Encoding.UTF8.GetString(array);
	}

	internal static SecurityKey FindKeyMatch(string kid, string x5t, SecurityKey securityKey, IEnumerable<SecurityKey> keys)
	{
		if (keys == null && securityKey == null)
		{
			return null;
		}
		if (securityKey is X509SecurityKey x509SecurityKey)
		{
			if (string.Equals(x5t, x509SecurityKey.X5t, StringComparison.OrdinalIgnoreCase) || string.Equals(x5t, x509SecurityKey.KeyId, StringComparison.OrdinalIgnoreCase) || string.Equals(kid, x509SecurityKey.X5t, StringComparison.OrdinalIgnoreCase) || string.Equals(kid, x509SecurityKey.KeyId, StringComparison.OrdinalIgnoreCase))
			{
				return securityKey;
			}
		}
		else if (string.Equals(securityKey?.KeyId, kid, StringComparison.Ordinal))
		{
			return securityKey;
		}
		if (keys != null)
		{
			foreach (SecurityKey key in keys)
			{
				if (key is X509SecurityKey x509SecurityKey2)
				{
					if (string.Equals(x5t, x509SecurityKey2.X5t, StringComparison.OrdinalIgnoreCase) || string.Equals(x5t, x509SecurityKey2.KeyId, StringComparison.OrdinalIgnoreCase) || string.Equals(kid, x509SecurityKey2.X5t, StringComparison.OrdinalIgnoreCase) || string.Equals(kid, x509SecurityKey2.KeyId, StringComparison.OrdinalIgnoreCase))
					{
						return key;
					}
				}
				else if (string.Equals(key?.KeyId, kid, StringComparison.Ordinal))
				{
					return key;
				}
			}
		}
		return null;
	}

	public static byte[] GenerateKeyBytes(int sizeInBits)
	{
		byte[] array = null;
		if (sizeInBits != 256 && sizeInBits != 384 && sizeInBits != 512)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException("IDX10401: Invalid requested key size. Valid key sizes are: 256, 384, and 512.", "sizeInBits"));
		}
		Aes aes = Aes.Create();
		int num = sizeInBits >> 4;
		array = new byte[num << 1];
		aes.KeySize = sizeInBits >> 1;
		aes.GenerateKey();
		Array.Copy(aes.Key, array, num);
		aes.GenerateKey();
		Array.Copy(aes.Key, 0, array, num, num);
		return array;
	}

	public static IEnumerable<SecurityKey> GetAllDecryptionKeys(TokenValidationParameters validationParameters)
	{
		Collection<SecurityKey> collection = new Collection<SecurityKey>();
		if (validationParameters.TokenDecryptionKey != null)
		{
			collection.Add(validationParameters.TokenDecryptionKey);
		}
		if (validationParameters.TokenDecryptionKeys != null)
		{
			foreach (SecurityKey tokenDecryptionKey in validationParameters.TokenDecryptionKeys)
			{
				collection.Add(tokenDecryptionKey);
			}
		}
		return collection;
	}

	internal static object GetClaimValueUsingValueType(Claim claim)
	{
		if (claim.ValueType == "http://www.w3.org/2001/XMLSchema#boolean" && bool.TryParse(claim.Value, out var result))
		{
			return result;
		}
		if (claim.ValueType == "http://www.w3.org/2001/XMLSchema#double" && double.TryParse(claim.Value, out var result2))
		{
			return result2;
		}
		if ((claim.ValueType == "http://www.w3.org/2001/XMLSchema#integer" || claim.ValueType == "http://www.w3.org/2001/XMLSchema#integer32") && int.TryParse(claim.Value, out var result3))
		{
			return result3;
		}
		if (claim.ValueType == "http://www.w3.org/2001/XMLSchema#integer64" && long.TryParse(claim.Value, out var result4))
		{
			return result4;
		}
		if (claim.ValueType == "http://www.w3.org/2001/XMLSchema#dateTime" && DateTime.TryParse(claim.Value, out var result5))
		{
			return result5;
		}
		if (claim.ValueType == "JSON")
		{
			return JObject.Parse(claim.Value);
		}
		if (claim.ValueType == "JSON_ARRAY")
		{
			return JArray.Parse(claim.Value);
		}
		if (claim.ValueType == "JSON_NULL")
		{
			return string.Empty;
		}
		return claim.Value;
	}

	internal static DateTime GetDateTime(string key, JObject payload)
	{
		if (!payload.TryGetValue(key, out JToken value))
		{
			return DateTime.MinValue;
		}
		return EpochTime.DateTime(Convert.ToInt64(Math.Truncate(Convert.ToDouble(ParseTimeValue(value, key), CultureInfo.InvariantCulture))));
	}

	private static long ParseTimeValue(JToken jToken, string claimName)
	{
		if (jToken.Type == JTokenType.Integer || jToken.Type == JTokenType.Float)
		{
			return (long)jToken;
		}
		if (jToken.Type == JTokenType.String)
		{
			if (long.TryParse((string?)jToken, out var result))
			{
				return result;
			}
			if (float.TryParse((string?)jToken, out var result2))
			{
				return (long)result2;
			}
			if (double.TryParse((string?)jToken, out var result3))
			{
				return (long)result3;
			}
		}
		throw LogHelper.LogExceptionMessage(new FormatException(LogHelper.FormatInvariant("IDX14300: Could not parse '{0}' : '{1}' as a '{2}'.", claimName, jToken.ToString(), typeof(long))));
	}

	internal static void ValidateTokenType(string type, TokenValidationParameters validationParameters)
	{
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (validationParameters.ValidTypes == null || validationParameters.ValidTypes.Count() == 0)
		{
			LogHelper.LogInformation("IDX10255: ValidTypes property on ValidationParameters is either null or empty. Exiting without validating the token type.");
			return;
		}
		if (string.IsNullOrEmpty(type))
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidTypeException("IDX10256: Unable to validate the token type. TokenValidationParameters.ValidTypes is set, but the 'typ' header claim is null or empty.")
			{
				InvalidType = null
			});
		}
		if (!validationParameters.ValidTypes.Contains(type, StringComparer.Ordinal))
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidTypeException(LogHelper.FormatInvariant("IDX10257: Token type validation failed. Type: '{0}'. Did not match: validationParameters.TokenTypes: '{1}'.", type, Utility.SerializeAsSingleCommaDelimitedString(validationParameters.ValidTypes)))
			{
				InvalidType = type
			});
		}
		LogHelper.LogInformation("IDX10258: Token type validated. Type: '{0}'.", type);
	}
}
internal static class LogMessages
{
	internal const string IDX14000 = "IDX14000: Signing JWT is not supported for: Algorithm: '{0}', SecurityKey: '{1}'.";

	internal const string IDX14100 = "IDX14100: JWT is not well formed: '{0}'.\nThe token needs to be in JWS or JWE Compact Serialization Format. (JWS): 'EncodedHeader.EndcodedPayload.EncodedSignature'. (JWE): 'EncodedProtectedHeader.EncodedEncryptedKey.EncodedInitializationVector.EncodedCiphertext.EncodedAuthenticationTag'.";

	internal const string IDX14101 = "IDX14101: Unable to decode the payload '{0}' as Base64Url encoded string. jwtEncodedString: '{1}'.";

	internal const string IDX14102 = "IDX14102: Unable to decode the header '{0}' as Base64Url encoded string. jwtEncodedString: '{1}'.";

	internal const string IDX14103 = "IDX14103: Failed to create the token encryption provider.";

	internal const string IDX14104 = "IDX14104: Unable to obtain a CryptoProviderFactory, EncryptingCredentials.CryptoProviderFactory and EncryptingCredentials.Key.CrypoProviderFactory are both null.";

	internal const string IDX14105 = "IDX14105: Header.Cty != null, assuming JWS. Cty: '{0}'.";

	internal const string IDX14106 = "IDX14106: Decoding token: '{0}' into header, payload and signature.";

	internal const string IDX14107 = "IDX14107: Token string does not match the token formats: JWE (header.encryptedKey.iv.ciphertext.tag) or JWS (header.payload.signature)";

	internal const string IDX14111 = "IDX14111: JWT: '{0}' must have three segments (JWS) or five segments (JWE).";

	internal const string IDX14112 = "IDX14112: Only a single 'Actor' is supported. Found second claim of type: '{0}', value: '{1}'";

	internal const string IDX14113 = "IDX14113: A duplicate value for 'SecurityTokenDescriptor.{0}' exists in 'SecurityTokenDescriptor.Claims'. \nThe value of 'SecurityTokenDescriptor.{0}' is used.";

	internal const string IDX14114 = "IDX14114: Both '{0}.{1}' and '{0}.{2}' are null or empty.";

	internal const string IDX14116 = "IDX14116: ''{0}' cannot contain the following claims: '{1}'. These values are added by default (if necessary) during security token creation.";

	internal const string IDX14200 = "IDX14200: Creating raw signature using the signature credentials.";

	internal const string IDX14300 = "IDX14300: Could not parse '{0}' : '{1}' as a '{2}'.";

	internal const string IDX14301 = "IDX14301: Unable to parse the header into a JSON object. \nHeader: '{0}'.";

	internal const string IDX14302 = "IDX14302: Unable to parse the payload into a JSON object. \nPayload: '{0}'.";

	internal const string IDX14303 = "IDX14303: Claim with name '{0}' does not exist in the header.";

	internal const string IDX14304 = "IDX14304: Claim with name '{0}' does not exist in the payload.";

	internal const string IDX14305 = "IDX14305: Unable to convert the '{0}' claim to the following type: '{1}'. Claim type was: '{2}'.";
}
public class TokenValidationResult
{
	public ClaimsIdentity ClaimsIdentity { get; set; }

	public Exception Exception { get; set; }

	public string Issuer { get; set; }

	public bool IsValid { get; set; }

	public SecurityToken SecurityToken { get; set; }

	public TokenContext TokenContext { get; set; }

	public string TokenType { get; set; }
}
