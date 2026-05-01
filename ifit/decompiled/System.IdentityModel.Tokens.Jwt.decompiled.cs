using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using Microsoft.IdentityModel.JsonWebTokens;
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
[assembly: AssemblyDescription("Includes types that provide support for creating, serializing and validating JSON Web Tokens.")]
[assembly: AssemblyProduct("Microsoft IdentityModel")]
[assembly: AssemblyTitle("System.IdentityModel.Tokens.Jwt")]
[assembly: AssemblyVersion("5.6.0.0")]
namespace System.IdentityModel.Tokens.Jwt;

internal static class ClaimTypeMapping
{
	private static Dictionary<string, string> shortToLongClaimTypeMapping;

	private static IDictionary<string, string> longToShortClaimTypeMapping;

	private static HashSet<string> inboundClaimFilter;

	public static IDictionary<string, string> InboundClaimTypeMap => shortToLongClaimTypeMapping;

	public static IDictionary<string, string> OutboundClaimTypeMap => longToShortClaimTypeMapping;

	public static ISet<string> InboundClaimFilter => inboundClaimFilter;

	static ClaimTypeMapping()
	{
		shortToLongClaimTypeMapping = new Dictionary<string, string>
		{
			{ "actort", "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor" },
			{ "birthdate", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth" },
			{ "email", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress" },
			{ "family_name", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname" },
			{ "gender", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/gender" },
			{ "given_name", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname" },
			{ "nameid", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier" },
			{ "sub", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier" },
			{ "website", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/webpage" },
			{ "unique_name", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" },
			{ "oid", "http://schemas.microsoft.com/identity/claims/objectidentifier" },
			{ "scp", "http://schemas.microsoft.com/identity/claims/scope" },
			{ "tid", "http://schemas.microsoft.com/identity/claims/tenantid" },
			{ "acr", "http://schemas.microsoft.com/claims/authnclassreference" },
			{ "adfs1email", "http://schemas.xmlsoap.org/claims/EmailAddress" },
			{ "adfs1upn", "http://schemas.xmlsoap.org/claims/UPN" },
			{ "amr", "http://schemas.microsoft.com/claims/authnmethodsreferences" },
			{ "authmethod", "http://schemas.microsoft.com/ws/2008/06/identity/claims/authenticationmethod" },
			{ "certapppolicy", "http://schemas.microsoft.com/2012/12/certificatecontext/extension/applicationpolicy" },
			{ "certauthoritykeyidentifier", "http://schemas.microsoft.com/2012/12/certificatecontext/extension/authoritykeyidentifier" },
			{ "certbasicconstraints", "http://schemas.microsoft.com/2012/12/certificatecontext/extension/basicconstraints" },
			{ "certeku", "http://schemas.microsoft.com/2012/12/certificatecontext/extension/eku" },
			{ "certissuer", "http://schemas.microsoft.com/2012/12/certificatecontext/field/issuer" },
			{ "certissuername", "http://schemas.microsoft.com/2012/12/certificatecontext/field/issuername" },
			{ "certkeyusage", "http://schemas.microsoft.com/2012/12/certificatecontext/extension/keyusage" },
			{ "certnotafter", "http://schemas.microsoft.com/2012/12/certificatecontext/field/notafter" },
			{ "certnotbefore", "http://schemas.microsoft.com/2012/12/certificatecontext/field/notbefore" },
			{ "certpolicy", "http://schemas.microsoft.com/2012/12/certificatecontext/extension/certificatepolicy" },
			{ "certpublickey", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/rsa" },
			{ "certrawdata", "http://schemas.microsoft.com/2012/12/certificatecontext/field/rawdata" },
			{ "certserialnumber", "http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber" },
			{ "certsignaturealgorithm", "http://schemas.microsoft.com/2012/12/certificatecontext/field/signaturealgorithm" },
			{ "certsubject", "http://schemas.microsoft.com/2012/12/certificatecontext/field/subject" },
			{ "certsubjectaltname", "http://schemas.microsoft.com/2012/12/certificatecontext/extension/san" },
			{ "certsubjectkeyidentifier", "http://schemas.microsoft.com/2012/12/certificatecontext/extension/subjectkeyidentifier" },
			{ "certsubjectname", "http://schemas.microsoft.com/2012/12/certificatecontext/field/subjectname" },
			{ "certtemplateinformation", "http://schemas.microsoft.com/2012/12/certificatecontext/extension/certificatetemplateinformation" },
			{ "certtemplatename", "http://schemas.microsoft.com/2012/12/certificatecontext/extension/certificatetemplatename" },
			{ "certthumbprint", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/thumbprint" },
			{ "certx509version", "http://schemas.microsoft.com/2012/12/certificatecontext/field/x509version" },
			{ "clientapplication", "http://schemas.microsoft.com/2012/01/requestcontext/claims/x-ms-client-application" },
			{ "clientip", "http://schemas.microsoft.com/2012/01/requestcontext/claims/x-ms-client-ip" },
			{ "clientuseragent", "http://schemas.microsoft.com/2012/01/requestcontext/claims/x-ms-client-user-agent" },
			{ "commonname", "http://schemas.xmlsoap.org/claims/CommonName" },
			{ "denyonlyprimarygroupsid", "http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarygroupsid" },
			{ "denyonlyprimarysid", "http://schemas.microsoft.com/ws/2008/06/identity/claims/denyonlyprimarysid" },
			{ "denyonlysid", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/denyonlysid" },
			{ "devicedispname", "http://schemas.microsoft.com/2012/01/devicecontext/claims/displayname" },
			{ "deviceid", "http://schemas.microsoft.com/2012/01/devicecontext/claims/identifier" },
			{ "deviceismanaged", "http://schemas.microsoft.com/2012/01/devicecontext/claims/ismanaged" },
			{ "deviceostype", "http://schemas.microsoft.com/2012/01/devicecontext/claims/ostype" },
			{ "deviceosver", "http://schemas.microsoft.com/2012/01/devicecontext/claims/osversion" },
			{ "deviceowner", "http://schemas.microsoft.com/2012/01/devicecontext/claims/userowner" },
			{ "deviceregid", "http://schemas.microsoft.com/2012/01/devicecontext/claims/registrationid" },
			{ "endpointpath", "http://schemas.microsoft.com/2012/01/requestcontext/claims/x-ms-endpoint-absolute-path" },
			{ "forwardedclientip", "http://schemas.microsoft.com/2012/01/requestcontext/claims/x-ms-forwarded-client-ip" },
			{ "group", "http://schemas.xmlsoap.org/claims/Group" },
			{ "groupsid", "http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid" },
			{ "idp", "http://schemas.microsoft.com/identity/claims/identityprovider" },
			{ "insidecorporatenetwork", "http://schemas.microsoft.com/ws/2012/01/insidecorporatenetwork" },
			{ "isregistereduser", "http://schemas.microsoft.com/2012/01/devicecontext/claims/isregistereduser" },
			{ "ppid", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/privatepersonalidentifier" },
			{ "primarygroupsid", "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarygroupsid" },
			{ "primarysid", "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid" },
			{ "proxy", "http://schemas.microsoft.com/2012/01/requestcontext/claims/x-ms-proxy" },
			{ "pwdchgurl", "http://schemas.microsoft.com/ws/2012/01/passwordchangeurl" },
			{ "pwdexpdays", "http://schemas.microsoft.com/ws/2012/01/passwordexpirationdays" },
			{ "pwdexptime", "http://schemas.microsoft.com/ws/2012/01/passwordexpirationtime" },
			{ "relyingpartytrustid", "http://schemas.microsoft.com/2012/01/requestcontext/claims/relyingpartytrustid" },
			{ "role", "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" },
			{ "roles", "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" },
			{ "upn", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn" },
			{ "winaccountname", "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsaccountname" }
		};
		longToShortClaimTypeMapping = new Dictionary<string, string>();
		foreach (KeyValuePair<string, string> item in shortToLongClaimTypeMapping)
		{
			if (!longToShortClaimTypeMapping.ContainsKey(item.Value))
			{
				longToShortClaimTypeMapping.Add(item.Value, item.Key);
			}
		}
		inboundClaimFilter = new HashSet<string>();
	}
}
public static class JsonClaimValueTypes
{
	public const string Json = "JSON";

	public const string JsonArray = "JSON_ARRAY";

	public const string JsonNull = "JSON_NULL";
}
public delegate string Serializer(object obj);
public delegate object Deserializer(string obj, Type targetType);
public static class JsonExtensions
{
	private static Serializer _serializer;

	private static Deserializer _deserializer;

	public static Serializer Serializer
	{
		get
		{
			return _serializer;
		}
		set
		{
			if (value == null)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentNullException("value"));
			}
			_serializer = value;
		}
	}

	public static Deserializer Deserializer
	{
		get
		{
			return _deserializer;
		}
		set
		{
			if (value == null)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentNullException("value"));
			}
			_deserializer = value;
		}
	}

	static JsonExtensions()
	{
		_serializer = JsonConvert.SerializeObject;
		_deserializer = JsonConvert.DeserializeObject;
	}

	public static string SerializeToJson(object value)
	{
		return Serializer(value);
	}

	public static T DeserializeFromJson<T>(string jsonString) where T : class
	{
		return Deserializer(jsonString, typeof(T)) as T;
	}

	public static JwtHeader DeserializeJwtHeader(string jsonString)
	{
		return Deserializer(jsonString, typeof(JwtHeader)) as JwtHeader;
	}

	public static JwtPayload DeserializeJwtPayload(string jsonString)
	{
		return Deserializer(jsonString, typeof(JwtPayload)) as JwtPayload;
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

	internal const int JweSegmentCount = 5;

	internal const int JwsSegmentCount = 3;

	internal const int MaxJwtSegmentCount = 5;

	public const string DirectKeyUseAlg = "dir";
}
public class JwtHeader : Dictionary<string, object>
{
	public string Alg
	{
		get
		{
			return GetStandardClaim("alg");
		}
		private set
		{
			base["alg"] = value;
		}
	}

	public string Cty
	{
		get
		{
			return GetStandardClaim("cty");
		}
		private set
		{
			base["cty"] = value;
		}
	}

	public string Enc
	{
		get
		{
			return GetStandardClaim("enc");
		}
		private set
		{
			base["enc"] = value;
		}
	}

	public EncryptingCredentials EncryptingCredentials { get; private set; }

	public string IV => GetStandardClaim("iv");

	public string Kid
	{
		get
		{
			return GetStandardClaim("kid");
		}
		private set
		{
			base["kid"] = value;
		}
	}

	public SigningCredentials SigningCredentials { get; private set; }

	public string Typ
	{
		get
		{
			return GetStandardClaim("typ");
		}
		private set
		{
			base["typ"] = value;
		}
	}

	public string X5t => GetStandardClaim("x5t");

	public string Zip => GetStandardClaim("zip");

	public JwtHeader()
		: base((IEqualityComparer<string>)StringComparer.Ordinal)
	{
		Alg = "none";
	}

	public JwtHeader(SigningCredentials signingCredentials)
		: this(signingCredentials, null)
	{
	}

	public JwtHeader(EncryptingCredentials encryptingCredentials)
		: this(encryptingCredentials, null)
	{
	}

	public JwtHeader(SigningCredentials signingCredentials, IDictionary<string, string> outboundAlgorithmMap)
		: base((IEqualityComparer<string>)StringComparer.Ordinal)
	{
		if (signingCredentials == null)
		{
			base["alg"] = "none";
		}
		else
		{
			if (outboundAlgorithmMap != null && outboundAlgorithmMap.TryGetValue(signingCredentials.Algorithm, out var value))
			{
				Alg = value;
			}
			else
			{
				Alg = signingCredentials.Algorithm;
			}
			if (!string.IsNullOrEmpty(signingCredentials.Key.KeyId))
			{
				Kid = signingCredentials.Key.KeyId;
			}
			if (signingCredentials is X509SigningCredentials x509SigningCredentials)
			{
				base["x5t"] = Base64UrlEncoder.Encode(x509SigningCredentials.Certificate.GetCertHash());
			}
		}
		Typ = "JWT";
		SigningCredentials = signingCredentials;
	}

	public JwtHeader(EncryptingCredentials encryptingCredentials, IDictionary<string, string> outboundAlgorithmMap)
		: base((IEqualityComparer<string>)StringComparer.Ordinal)
	{
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		if (outboundAlgorithmMap != null && outboundAlgorithmMap.TryGetValue(encryptingCredentials.Alg, out var value))
		{
			Alg = value;
		}
		else
		{
			Alg = encryptingCredentials.Alg;
		}
		if (outboundAlgorithmMap != null && outboundAlgorithmMap.TryGetValue(encryptingCredentials.Enc, out value))
		{
			Enc = value;
		}
		else
		{
			Enc = encryptingCredentials.Enc;
		}
		if (!string.IsNullOrEmpty(encryptingCredentials.Key.KeyId))
		{
			Kid = encryptingCredentials.Key.KeyId;
		}
		Typ = "JWT";
		EncryptingCredentials = encryptingCredentials;
	}

	public static JwtHeader Base64UrlDeserialize(string base64UrlEncodedJsonString)
	{
		return JsonExtensions.DeserializeJwtHeader(Base64UrlEncoder.Decode(base64UrlEncodedJsonString));
	}

	public virtual string Base64UrlEncode()
	{
		return Base64UrlEncoder.Encode(SerializeToJson());
	}

	public static JwtHeader Deserialize(string jsonString)
	{
		return JsonExtensions.DeserializeJwtHeader(jsonString);
	}

	internal string GetStandardClaim(string claimType)
	{
		if (TryGetValue(claimType, out var value))
		{
			if (value == null)
			{
				return null;
			}
			if (value is string result)
			{
				return result;
			}
			return JsonExtensions.SerializeToJson(value);
		}
		return null;
	}

	public virtual string SerializeToJson()
	{
		return JsonExtensions.SerializeToJson(this);
	}
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
public class JwtPayload : Dictionary<string, object>
{
	public string Actort => GetStandardClaim("actort");

	public string Acr => GetStandardClaim("acr");

	public IList<string> Amr => GetIListClaims("amr");

	public int? AuthTime => GetIntClaim("auth_time");

	public IList<string> Aud => GetIListClaims("aud");

	public string Azp => GetStandardClaim("azp");

	public string CHash => GetStandardClaim("c_hash");

	public int? Exp => GetIntClaim("exp");

	public string Jti => GetStandardClaim("jti");

	public int? Iat => GetIntClaim("iat");

	public string Iss => GetStandardClaim("iss");

	public int? Nbf => GetIntClaim("nbf");

	public string Nonce => GetStandardClaim("nonce");

	public string Sub => GetStandardClaim("sub");

	public DateTime ValidFrom => GetDateTime("nbf");

	public DateTime ValidTo => GetDateTime("exp");

	public DateTime IssuedAt => GetDateTime("iat");

	public virtual IEnumerable<Claim> Claims
	{
		get
		{
			List<Claim> list = new List<Claim>();
			string text = Iss ?? "LOCAL AUTHORITY";
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, object> current = enumerator.Current;
				if (current.Value == null)
				{
					list.Add(new Claim(current.Key, string.Empty, "JSON_NULL", text, text));
				}
				else if (current.Value is string value)
				{
					list.Add(new Claim(current.Key, value, "http://www.w3.org/2001/XMLSchema#string", text, text));
				}
				else if (current.Value is JToken jtoken)
				{
					AddClaimsFromJToken(list, current.Key, jtoken, text);
				}
				else if (current.Value is IEnumerable<object> enumerable)
				{
					foreach (object item in enumerable)
					{
						if (item is string value2)
						{
							list.Add(new Claim(current.Key, value2, "http://www.w3.org/2001/XMLSchema#string", text, text));
						}
						else if (item is JToken jtoken2)
						{
							AddDefaultClaimFromJToken(list, current.Key, jtoken2, text);
						}
						else if (item is DateTime dateTime)
						{
							list.Add(new Claim(current.Key, dateTime.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture), "http://www.w3.org/2001/XMLSchema#dateTime", text, text));
						}
						else
						{
							list.Add(new Claim(current.Key, JsonConvert.SerializeObject(item), GetClaimValueType(item), text, text));
						}
					}
				}
				else if (current.Value is IDictionary<string, object> dictionary)
				{
					foreach (KeyValuePair<string, object> item2 in dictionary)
					{
						list.Add(new Claim(current.Key, "{" + item2.Key + ":" + JsonConvert.SerializeObject(item2.Value) + "}", GetClaimValueType(item2.Value), text, text));
					}
				}
				else if (current.Value is DateTime dateTime2)
				{
					list.Add(new Claim(current.Key, dateTime2.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture), "http://www.w3.org/2001/XMLSchema#dateTime", text, text));
				}
				else
				{
					list.Add(new Claim(current.Key, JsonConvert.SerializeObject(current.Value), GetClaimValueType(current.Value), text, text));
				}
			}
			return list;
		}
	}

	public JwtPayload()
		: this(null, null, null, null, null)
	{
	}

	public JwtPayload(IEnumerable<Claim> claims)
		: this(null, null, claims, null, null)
	{
	}

	public JwtPayload(string issuer, string audience, IEnumerable<Claim> claims, DateTime? notBefore, DateTime? expires)
		: this(issuer, audience, claims, notBefore, expires, null)
	{
	}

	public JwtPayload(string issuer, string audience, IEnumerable<Claim> claims, DateTime? notBefore, DateTime? expires, DateTime? issuedAt)
		: base((IEqualityComparer<string>)StringComparer.Ordinal)
	{
		if (claims != null)
		{
			AddClaims(claims);
		}
		if (expires.HasValue)
		{
			if (notBefore.HasValue)
			{
				if (notBefore.Value >= expires.Value)
				{
					throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX12401: Expires: '{0}' must be after NotBefore: '{1}'.", expires.Value, notBefore.Value)));
				}
				base["nbf"] = EpochTime.GetIntDate(notBefore.Value.ToUniversalTime());
			}
			base["exp"] = EpochTime.GetIntDate(expires.Value.ToUniversalTime());
		}
		if (issuedAt.HasValue)
		{
			base["iat"] = EpochTime.GetIntDate(issuedAt.Value.ToUniversalTime());
		}
		if (!string.IsNullOrEmpty(issuer))
		{
			base["iss"] = issuer;
		}
		if (!string.IsNullOrEmpty(audience))
		{
			AddClaim(new Claim("aud", audience, "http://www.w3.org/2001/XMLSchema#string"));
		}
	}

	private void AddClaimsFromJToken(List<Claim> claims, string claimType, JToken jtoken, string issuer)
	{
		if (jtoken.Type == JTokenType.Object)
		{
			claims.Add(new Claim(claimType, jtoken.ToString(Newtonsoft.Json.Formatting.None), "JSON", issuer, issuer));
			return;
		}
		if (jtoken.Type == JTokenType.Array)
		{
			foreach (JToken item in jtoken as JArray)
			{
				switch (item.Type)
				{
				case JTokenType.Object:
					claims.Add(new Claim(claimType, item.ToString(Newtonsoft.Json.Formatting.None), "JSON", issuer, issuer));
					break;
				case JTokenType.Array:
					claims.Add(new Claim(claimType, item.ToString(Newtonsoft.Json.Formatting.None), "JSON_ARRAY", issuer, issuer));
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
			if (jValue.Type == JTokenType.String)
			{
				claims.Add(new Claim(claimType, jValue.Value.ToString(), "http://www.w3.org/2001/XMLSchema#string", issuer, issuer));
			}
			else if (jValue.Value is DateTime dateTime)
			{
				claims.Add(new Claim(claimType, dateTime.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture), "http://www.w3.org/2001/XMLSchema#dateTime", issuer, issuer));
			}
			else
			{
				claims.Add(new Claim(claimType, jtoken.ToString(Newtonsoft.Json.Formatting.None), GetClaimValueType(jValue.Value), issuer, issuer));
			}
		}
		else
		{
			claims.Add(new Claim(claimType, jtoken.ToString(Newtonsoft.Json.Formatting.None), GetClaimValueType(jtoken), issuer, issuer));
		}
	}

	public void AddClaim(Claim claim)
	{
		if (claim == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentNullException("claim"));
		}
		AddClaims(new Claim[1] { claim });
	}

	public void AddClaims(IEnumerable<Claim> claims)
	{
		if (claims == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentNullException("claims"));
		}
		foreach (Claim claim in claims)
		{
			if (claim == null)
			{
				continue;
			}
			string type = claim.Type;
			object obj = (claim.ValueType.Equals("http://www.w3.org/2001/XMLSchema#string", StringComparison.Ordinal) ? claim.Value : JwtTokenUtilities.GetClaimValueUsingValueType(claim));
			if (TryGetValue(type, out var value))
			{
				IList<object> list = value as IList<object>;
				if (list == null)
				{
					list = new List<object>();
					list.Add(value);
					base[type] = list;
				}
				list.Add(obj);
			}
			else
			{
				base[type] = obj;
			}
		}
	}

	internal static string GetClaimValueType(object obj)
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

	internal string GetStandardClaim(string claimType)
	{
		if (TryGetValue(claimType, out var value))
		{
			if (value == null)
			{
				return null;
			}
			if (value is string result)
			{
				return result;
			}
			return JsonExtensions.SerializeToJson(value);
		}
		return null;
	}

	internal int? GetIntClaim(string claimType)
	{
		int? result = null;
		if (TryGetValue(claimType, out var value))
		{
			if (value is IList<object> list)
			{
				foreach (object item in list)
				{
					result = null;
					if (item != null)
					{
						try
						{
							result = Convert.ToInt32(Math.Truncate(Convert.ToDouble(item, CultureInfo.InvariantCulture)));
						}
						catch (FormatException)
						{
							result = null;
						}
						catch (InvalidCastException)
						{
							result = null;
						}
						catch (OverflowException)
						{
							result = null;
						}
						if (result.HasValue)
						{
							return result;
						}
					}
				}
			}
			else
			{
				try
				{
					result = Convert.ToInt32(Math.Truncate(Convert.ToDouble(value, CultureInfo.InvariantCulture)));
				}
				catch (FormatException)
				{
					result = null;
				}
				catch (OverflowException)
				{
					result = null;
				}
			}
			return result;
		}
		return result;
	}

	internal IList<string> GetIListClaims(string claimType)
	{
		List<string> list = new List<string>();
		object value = null;
		if (!TryGetValue(claimType, out value))
		{
			return list;
		}
		if (value is string item)
		{
			list.Add(item);
			return list;
		}
		if (value is IEnumerable<object> enumerable)
		{
			foreach (object item2 in enumerable)
			{
				list.Add(item2.ToString());
			}
		}
		else
		{
			list.Add(JsonExtensions.SerializeToJson(value));
		}
		return list;
	}

	private DateTime GetDateTime(string key)
	{
		if (!TryGetValue(key, out var value))
		{
			return DateTime.MinValue;
		}
		try
		{
			if (value is IList<object> list)
			{
				if (list.Count == 0)
				{
					return DateTime.MinValue;
				}
				value = list[0];
			}
			return EpochTime.DateTime(Convert.ToInt64(Math.Truncate(Convert.ToDouble(value, CultureInfo.InvariantCulture))));
		}
		catch (Exception ex)
		{
			if (ex is FormatException || ex is ArgumentException || ex is InvalidCastException)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenException(LogHelper.FormatInvariant("IDX12700: Error found while parsing date time. The '{0}' claim has value '{1}' which is could not be parsed to an integer.", key, value ?? "<null>"), ex));
			}
			if (ex is OverflowException)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenException(LogHelper.FormatInvariant("IDX12701: Error found while parsing date time. The '{0}' claim has value '{1}' does not lie in the valid range.", key, value ?? "<null>"), ex));
			}
			throw;
		}
	}

	public virtual string SerializeToJson()
	{
		return JsonExtensions.SerializeToJson(this);
	}

	public virtual string Base64UrlEncode()
	{
		return Base64UrlEncoder.Encode(SerializeToJson());
	}

	public static JwtPayload Base64UrlDeserialize(string base64UrlEncodedJsonString)
	{
		return JsonExtensions.DeserializeJwtPayload(Base64UrlEncoder.Decode(base64UrlEncodedJsonString));
	}

	public static JwtPayload Deserialize(string jsonString)
	{
		return JsonExtensions.DeserializeJwtPayload(jsonString);
	}
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
public class JwtSecurityToken : SecurityToken
{
	private JwtPayload _payload;

	public string Actor
	{
		get
		{
			if (Payload != null)
			{
				return Payload.Actort;
			}
			return string.Empty;
		}
	}

	public IEnumerable<string> Audiences
	{
		get
		{
			if (Payload != null)
			{
				return Payload.Aud;
			}
			return new List<string>();
		}
	}

	public IEnumerable<Claim> Claims
	{
		get
		{
			if (Payload != null)
			{
				return Payload.Claims;
			}
			return new List<Claim>();
		}
	}

	public virtual string EncodedHeader => Header.Base64UrlEncode();

	public virtual string EncodedPayload
	{
		get
		{
			if (Payload != null)
			{
				return Payload.Base64UrlEncode();
			}
			return string.Empty;
		}
	}

	public JwtHeader Header { get; internal set; }

	public override string Id
	{
		get
		{
			if (Payload != null)
			{
				return Payload.Jti;
			}
			return string.Empty;
		}
	}

	public override string Issuer
	{
		get
		{
			if (Payload != null)
			{
				return Payload.Iss;
			}
			return string.Empty;
		}
	}

	public JwtPayload Payload
	{
		get
		{
			if (InnerToken != null)
			{
				return InnerToken.Payload;
			}
			return _payload;
		}
		internal set
		{
			_payload = value;
		}
	}

	public JwtSecurityToken InnerToken { get; internal set; }

	public string RawAuthenticationTag { get; private set; }

	public string RawCiphertext { get; private set; }

	public string RawData { get; private set; }

	public string RawEncryptedKey { get; private set; }

	public string RawInitializationVector { get; private set; }

	public string RawHeader { get; internal set; }

	public string RawPayload { get; internal set; }

	public string RawSignature { get; internal set; }

	public override SecurityKey SecurityKey => null;

	public string SignatureAlgorithm => Header.Alg;

	public SigningCredentials SigningCredentials => Header.SigningCredentials;

	public EncryptingCredentials EncryptingCredentials => Header.EncryptingCredentials;

	public override SecurityKey SigningKey { get; set; }

	public string Subject
	{
		get
		{
			if (Payload != null)
			{
				return Payload.Sub;
			}
			return string.Empty;
		}
	}

	public override DateTime ValidFrom
	{
		get
		{
			if (Payload != null)
			{
				return Payload.ValidFrom;
			}
			return DateTime.MinValue;
		}
	}

	public override DateTime ValidTo
	{
		get
		{
			if (Payload != null)
			{
				return Payload.ValidTo;
			}
			return DateTime.MinValue;
		}
	}

	public virtual DateTime IssuedAt
	{
		get
		{
			if (Payload != null)
			{
				return Payload.IssuedAt;
			}
			return DateTime.MinValue;
		}
	}

	public JwtSecurityToken(string jwtEncodedString)
	{
		if (string.IsNullOrWhiteSpace(jwtEncodedString))
		{
			throw LogHelper.LogArgumentNullException("jwtEncodedString");
		}
		string[] array = jwtEncodedString.Split(new char[1] { '.' }, 6);
		if (array.Length == 3)
		{
			if (!JwtTokenUtilities.RegexJws.IsMatch(jwtEncodedString))
			{
				throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX12739: JWT: '{0}' has three segments but is not in proper JWS format.", jwtEncodedString)));
			}
		}
		else
		{
			if (array.Length != 5)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX12741: JWT: '{0}' must have three segments (JWS) or five segments (JWE).", jwtEncodedString)));
			}
			if (!JwtTokenUtilities.RegexJwe.IsMatch(jwtEncodedString))
			{
				throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX12740: JWT: '{0}' has five segments but is not in proper JWE format.", jwtEncodedString)));
			}
		}
		Decode(array, jwtEncodedString);
	}

	public JwtSecurityToken(JwtHeader header, JwtPayload payload, string rawHeader, string rawPayload, string rawSignature)
	{
		if (header == null)
		{
			throw LogHelper.LogArgumentNullException("header");
		}
		if (payload == null)
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		if (string.IsNullOrWhiteSpace(rawHeader))
		{
			throw LogHelper.LogArgumentNullException("rawHeader");
		}
		if (string.IsNullOrWhiteSpace(rawPayload))
		{
			throw LogHelper.LogArgumentNullException("rawPayload");
		}
		if (rawSignature == null)
		{
			throw LogHelper.LogArgumentNullException("rawSignature");
		}
		Header = header;
		Payload = payload;
		RawData = rawHeader + "." + rawPayload + "." + rawSignature;
		RawHeader = rawHeader;
		RawPayload = rawPayload;
		RawSignature = rawSignature;
	}

	public JwtSecurityToken(JwtHeader header, JwtSecurityToken innerToken, string rawHeader, string rawEncryptedKey, string rawInitializationVector, string rawCiphertext, string rawAuthenticationTag)
	{
		if (header == null)
		{
			throw LogHelper.LogArgumentNullException("header");
		}
		if (innerToken == null)
		{
			throw LogHelper.LogArgumentNullException("innerToken");
		}
		if (rawEncryptedKey == null)
		{
			throw LogHelper.LogArgumentNullException("rawEncryptedKey");
		}
		if (string.IsNullOrEmpty(rawInitializationVector))
		{
			throw LogHelper.LogArgumentNullException("rawInitializationVector");
		}
		if (string.IsNullOrEmpty(rawCiphertext))
		{
			throw LogHelper.LogArgumentNullException("rawCiphertext");
		}
		if (string.IsNullOrEmpty(rawAuthenticationTag))
		{
			throw LogHelper.LogArgumentNullException("rawAuthenticationTag");
		}
		Header = header;
		InnerToken = innerToken;
		RawData = string.Join(".", rawHeader, rawEncryptedKey, rawInitializationVector, rawCiphertext, rawAuthenticationTag);
		RawHeader = rawHeader;
		RawEncryptedKey = rawEncryptedKey;
		RawInitializationVector = rawInitializationVector;
		RawCiphertext = rawCiphertext;
		RawAuthenticationTag = rawAuthenticationTag;
	}

	public JwtSecurityToken(JwtHeader header, JwtPayload payload)
	{
		if (header == null)
		{
			throw LogHelper.LogArgumentNullException("header");
		}
		if (payload == null)
		{
			throw LogHelper.LogArgumentNullException("payload");
		}
		Header = header;
		Payload = payload;
		RawSignature = string.Empty;
	}

	public JwtSecurityToken(string issuer = null, string audience = null, IEnumerable<Claim> claims = null, DateTime? notBefore = null, DateTime? expires = null, SigningCredentials signingCredentials = null)
	{
		if (expires.HasValue && notBefore.HasValue && notBefore >= expires)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX12401: Expires: '{0}' must be after NotBefore: '{1}'.", expires.Value, notBefore.Value)));
		}
		Payload = new JwtPayload(issuer, audience, claims, notBefore, expires);
		Header = new JwtHeader(signingCredentials);
		RawSignature = string.Empty;
	}

	public override string ToString()
	{
		if (Payload != null)
		{
			return Header.SerializeToJson() + "." + Payload.SerializeToJson();
		}
		return Header.SerializeToJson() + ".";
	}

	internal void Decode(string[] tokenParts, string rawData)
	{
		LogHelper.LogInformation("IDX12716: Decoding token: '{0}' into header, payload and signature.", rawData);
		try
		{
			Header = JwtHeader.Base64UrlDeserialize(tokenParts[0]);
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX12729: Unable to decode the header '{0}' as Base64Url encoded string. jwtEncodedString: '{1}'.", tokenParts[0], rawData), innerException));
		}
		if (tokenParts.Length == 5)
		{
			DecodeJwe(tokenParts);
		}
		else
		{
			DecodeJws(tokenParts);
		}
		RawData = rawData;
	}

	private void DecodeJws(string[] tokenParts)
	{
		if (Header.Cty != null)
		{
			LogHelper.LogVerbose(LogHelper.FormatInvariant("IDX12738: Header.Cty != null, assuming JWS. Cty: '{0}'.", Header.Cty));
		}
		try
		{
			Payload = JwtPayload.Base64UrlDeserialize(tokenParts[1]);
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX12723: Unable to decode the payload '{0}' as Base64Url encoded string. jwtEncodedString: '{1}'.", tokenParts[1], RawData), innerException));
		}
		RawHeader = tokenParts[0];
		RawPayload = tokenParts[1];
		RawSignature = tokenParts[2];
	}

	private void DecodeJwe(string[] tokenParts)
	{
		RawHeader = tokenParts[0];
		RawEncryptedKey = tokenParts[1];
		RawInitializationVector = tokenParts[2];
		RawCiphertext = tokenParts[3];
		RawAuthenticationTag = tokenParts[4];
	}
}
public class JwtSecurityTokenHandler : SecurityTokenHandler
{
	private delegate bool CertMatcher(X509Certificate2 cert);

	private ISet<string> _inboundClaimFilter;

	private IDictionary<string, string> _inboundClaimTypeMap;

	private static string _jsonClaimType;

	private const string _namespace = "http://schemas.xmlsoap.org/ws/2005/05/identity/claimproperties";

	private IDictionary<string, string> _outboundClaimTypeMap;

	private IDictionary<string, string> _outboundAlgorithmMap;

	private static string _shortClaimType;

	private bool _mapInboundClaims = DefaultMapInboundClaims;

	public static IDictionary<string, string> DefaultInboundClaimTypeMap;

	public static bool DefaultMapInboundClaims;

	public static IDictionary<string, string> DefaultOutboundClaimTypeMap;

	public static ISet<string> DefaultInboundClaimFilter;

	public static IDictionary<string, string> DefaultOutboundAlgorithmMap;

	public bool MapInboundClaims
	{
		get
		{
			return _mapInboundClaims;
		}
		set
		{
			if (!_mapInboundClaims && value && _inboundClaimTypeMap.Count == 0)
			{
				_inboundClaimTypeMap = new Dictionary<string, string>(DefaultInboundClaimTypeMap);
			}
			_mapInboundClaims = value;
		}
	}

	public IDictionary<string, string> InboundClaimTypeMap
	{
		get
		{
			return _inboundClaimTypeMap;
		}
		set
		{
			_inboundClaimTypeMap = value ?? throw LogHelper.LogArgumentNullException("value");
		}
	}

	public IDictionary<string, string> OutboundClaimTypeMap
	{
		get
		{
			return _outboundClaimTypeMap;
		}
		set
		{
			if (value == null)
			{
				throw LogHelper.LogArgumentNullException("value");
			}
			_outboundClaimTypeMap = value;
		}
	}

	public IDictionary<string, string> OutboundAlgorithmMap => _outboundAlgorithmMap;

	public ISet<string> InboundClaimFilter
	{
		get
		{
			return _inboundClaimFilter;
		}
		set
		{
			if (value == null)
			{
				throw LogHelper.LogArgumentNullException("value");
			}
			_inboundClaimFilter = value;
		}
	}

	public static string ShortClaimTypeProperty
	{
		get
		{
			return _shortClaimType;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw LogHelper.LogArgumentNullException("value");
			}
			_shortClaimType = value;
		}
	}

	public static string JsonClaimTypeProperty
	{
		get
		{
			return _jsonClaimType;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw LogHelper.LogArgumentNullException("value");
			}
			_jsonClaimType = value;
		}
	}

	public override bool CanValidateToken => true;

	public override bool CanWriteToken => true;

	public override Type TokenType => typeof(JwtSecurityToken);

	static JwtSecurityTokenHandler()
	{
		_jsonClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claimproperties/json_type";
		_shortClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claimproperties/ShortTypeName";
		DefaultInboundClaimTypeMap = ClaimTypeMapping.InboundClaimTypeMap;
		DefaultMapInboundClaims = true;
		DefaultOutboundClaimTypeMap = ClaimTypeMapping.OutboundClaimTypeMap;
		DefaultInboundClaimFilter = ClaimTypeMapping.InboundClaimFilter;
		LogHelper.LogVerbose("Assembly version info: " + typeof(JwtSecurityTokenHandler).AssemblyQualifiedName);
		DefaultOutboundAlgorithmMap = new Dictionary<string, string>
		{
			{ "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha256", "ES256" },
			{ "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha384", "ES384" },
			{ "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha512", "ES512" },
			{ "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256", "HS256" },
			{ "http://www.w3.org/2001/04/xmldsig-more#hmac-sha384", "HS384" },
			{ "http://www.w3.org/2001/04/xmldsig-more#hmac-sha512", "HS512" },
			{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256", "RS256" },
			{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha384", "RS384" },
			{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha512", "RS512" }
		};
	}

	public JwtSecurityTokenHandler()
	{
		if (_mapInboundClaims)
		{
			_inboundClaimTypeMap = new Dictionary<string, string>(DefaultInboundClaimTypeMap);
		}
		else
		{
			_inboundClaimTypeMap = new Dictionary<string, string>();
		}
		_outboundClaimTypeMap = new Dictionary<string, string>(DefaultOutboundClaimTypeMap);
		_inboundClaimFilter = new HashSet<string>(DefaultInboundClaimFilter);
		_outboundAlgorithmMap = new Dictionary<string, string>(DefaultOutboundAlgorithmMap);
	}

	public override bool CanReadToken(string token)
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
		LogHelper.LogInformation("IDX12720: Token string does not match the token formats: JWE (header.encryptedKey.iv.ciphertext.tag) or JWS (header.payload.signature)");
		return false;
	}

	public virtual string CreateEncodedJwt(SecurityTokenDescriptor tokenDescriptor)
	{
		if (tokenDescriptor == null)
		{
			throw LogHelper.LogArgumentNullException("tokenDescriptor");
		}
		return CreateJwtSecurityToken(tokenDescriptor).RawData;
	}

	public virtual string CreateEncodedJwt(string issuer, string audience, ClaimsIdentity subject, DateTime? notBefore, DateTime? expires, DateTime? issuedAt, SigningCredentials signingCredentials)
	{
		return CreateJwtSecurityTokenPrivate(issuer, audience, subject, notBefore, expires, issuedAt, signingCredentials, null).RawData;
	}

	public virtual string CreateEncodedJwt(string issuer, string audience, ClaimsIdentity subject, DateTime? notBefore, DateTime? expires, DateTime? issuedAt, SigningCredentials signingCredentials, EncryptingCredentials encryptingCredentials)
	{
		return CreateJwtSecurityTokenPrivate(issuer, audience, subject, notBefore, expires, issuedAt, signingCredentials, encryptingCredentials).RawData;
	}

	public virtual JwtSecurityToken CreateJwtSecurityToken(SecurityTokenDescriptor tokenDescriptor)
	{
		if (tokenDescriptor == null)
		{
			throw LogHelper.LogArgumentNullException("tokenDescriptor");
		}
		return CreateJwtSecurityTokenPrivate(tokenDescriptor.Issuer, tokenDescriptor.Audience, tokenDescriptor.Subject, tokenDescriptor.NotBefore, tokenDescriptor.Expires, tokenDescriptor.IssuedAt, tokenDescriptor.SigningCredentials, tokenDescriptor.EncryptingCredentials);
	}

	public virtual JwtSecurityToken CreateJwtSecurityToken(string issuer, string audience, ClaimsIdentity subject, DateTime? notBefore, DateTime? expires, DateTime? issuedAt, SigningCredentials signingCredentials, EncryptingCredentials encryptingCredentials)
	{
		return CreateJwtSecurityTokenPrivate(issuer, audience, subject, notBefore, expires, issuedAt, signingCredentials, encryptingCredentials);
	}

	public virtual JwtSecurityToken CreateJwtSecurityToken(string issuer = null, string audience = null, ClaimsIdentity subject = null, DateTime? notBefore = null, DateTime? expires = null, DateTime? issuedAt = null, SigningCredentials signingCredentials = null)
	{
		return CreateJwtSecurityTokenPrivate(issuer, audience, subject, notBefore, expires, issuedAt, signingCredentials, null);
	}

	public override SecurityToken CreateToken(SecurityTokenDescriptor tokenDescriptor)
	{
		if (tokenDescriptor == null)
		{
			throw LogHelper.LogArgumentNullException("tokenDescriptor");
		}
		return CreateJwtSecurityTokenPrivate(tokenDescriptor.Issuer, tokenDescriptor.Audience, tokenDescriptor.Subject, tokenDescriptor.NotBefore, tokenDescriptor.Expires, tokenDescriptor.IssuedAt, tokenDescriptor.SigningCredentials, tokenDescriptor.EncryptingCredentials);
	}

	private JwtSecurityToken CreateJwtSecurityTokenPrivate(string issuer, string audience, ClaimsIdentity subject, DateTime? notBefore, DateTime? expires, DateTime? issuedAt, SigningCredentials signingCredentials, EncryptingCredentials encryptingCredentials)
	{
		if (base.SetDefaultTimesOnTokenCreation && (!expires.HasValue || !issuedAt.HasValue || !notBefore.HasValue))
		{
			DateTime utcNow = DateTime.UtcNow;
			if (!expires.HasValue)
			{
				expires = utcNow + TimeSpan.FromMinutes(base.TokenLifetimeInMinutes);
			}
			if (!issuedAt.HasValue)
			{
				issuedAt = utcNow;
			}
			if (!notBefore.HasValue)
			{
				notBefore = utcNow;
			}
		}
		LogHelper.LogVerbose("IDX12721: Creating JwtSecurityToken: Issuer: '{0}', Audience: '{1}'", audience ?? "null", issuer ?? "null");
		JwtPayload jwtPayload = new JwtPayload(issuer, audience, (subject == null) ? null : OutboundClaimTypeTransform(subject.Claims), notBefore, expires, issuedAt);
		JwtHeader jwtHeader = ((signingCredentials == null) ? new JwtHeader() : new JwtHeader(signingCredentials, OutboundAlgorithmMap));
		if (subject?.Actor != null)
		{
			jwtPayload.AddClaim(new Claim("actort", CreateActorValue(subject.Actor)));
		}
		string text = jwtHeader.Base64UrlEncode();
		string text2 = jwtPayload.Base64UrlEncode();
		string text3 = ((signingCredentials == null) ? string.Empty : JwtTokenUtilities.CreateEncodedSignature(text + "." + text2, signingCredentials));
		LogHelper.LogInformation("IDX12722: Creating security token from the header: '{0}', payload: '{1}' and raw signature: '{2}'.", text, text2, text3);
		if (encryptingCredentials != null)
		{
			return EncryptToken(new JwtSecurityToken(jwtHeader, jwtPayload, text, text2, text3), encryptingCredentials);
		}
		return new JwtSecurityToken(jwtHeader, jwtPayload, text, text2, text3);
	}

	private JwtSecurityToken EncryptToken(JwtSecurityToken innerJwt, EncryptingCredentials encryptingCredentials)
	{
		CryptoProviderFactory cryptoProviderFactory = encryptingCredentials.CryptoProviderFactory ?? encryptingCredentials.Key.CryptoProviderFactory;
		if (cryptoProviderFactory == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException("IDX12733: Unable to obtain a CryptoProviderFactory, both EncryptingCredentials.CryptoProviderFactory and EncryptingCredentials.Key.CrypoProviderFactory are both null."));
		}
		if (encryptingCredentials == null)
		{
			throw LogHelper.LogArgumentNullException("encryptingCredentials");
		}
		if ("dir".Equals(encryptingCredentials.Alg, StringComparison.Ordinal))
		{
			if (!cryptoProviderFactory.IsSupportedAlgorithm(encryptingCredentials.Enc, encryptingCredentials.Key))
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException(LogHelper.FormatInvariant("IDX10615: Encryption failed. No support for: Algorithm: '{0}', SecurityKey: '{1}'.", encryptingCredentials.Enc, encryptingCredentials.Key)));
			}
			JwtHeader jwtHeader = new JwtHeader(encryptingCredentials, OutboundAlgorithmMap);
			AuthenticatedEncryptionProvider authenticatedEncryptionProvider = cryptoProviderFactory.CreateAuthenticatedEncryptionProvider(encryptingCredentials.Key, encryptingCredentials.Enc);
			if (authenticatedEncryptionProvider == null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException("IDX12730: Failed to create the token encryption provider."));
			}
			try
			{
				AuthenticatedEncryptionResult authenticatedEncryptionResult = authenticatedEncryptionProvider.Encrypt(Encoding.UTF8.GetBytes(innerJwt.RawData), Encoding.ASCII.GetBytes(jwtHeader.Base64UrlEncode()));
				return new JwtSecurityToken(jwtHeader, innerJwt, jwtHeader.Base64UrlEncode(), string.Empty, Base64UrlEncoder.Encode(authenticatedEncryptionResult.IV), Base64UrlEncoder.Encode(authenticatedEncryptionResult.Ciphertext), Base64UrlEncoder.Encode(authenticatedEncryptionResult.AuthenticationTag));
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
			throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException("IDX12730: Failed to create the token encryption provider."));
		}
		try
		{
			JwtHeader jwtHeader2 = new JwtHeader(encryptingCredentials, OutboundAlgorithmMap);
			AuthenticatedEncryptionResult authenticatedEncryptionResult2 = authenticatedEncryptionProvider2.Encrypt(Encoding.UTF8.GetBytes(innerJwt.RawData), Encoding.ASCII.GetBytes(jwtHeader2.Base64UrlEncode()));
			return new JwtSecurityToken(jwtHeader2, innerJwt, jwtHeader2.Base64UrlEncode(), Base64UrlEncoder.Encode(inArray), Base64UrlEncoder.Encode(authenticatedEncryptionResult2.IV), Base64UrlEncoder.Encode(authenticatedEncryptionResult2.Ciphertext), Base64UrlEncoder.Encode(authenticatedEncryptionResult2.AuthenticationTag));
		}
		catch (Exception innerException2)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException(LogHelper.FormatInvariant("IDX10616: Encryption failed. EncryptionProvider failed for: Algorithm: '{0}', SecurityKey: '{1}'. See inner exception.", encryptingCredentials.Enc, encryptingCredentials.Key), innerException2));
		}
	}

	private IEnumerable<Claim> OutboundClaimTypeTransform(IEnumerable<Claim> claims)
	{
		foreach (Claim claim in claims)
		{
			string value = null;
			if (_outboundClaimTypeMap.TryGetValue(claim.Type, out value))
			{
				yield return new Claim(value, claim.Value, claim.ValueType, claim.Issuer, claim.OriginalIssuer, claim.Subject);
			}
			else
			{
				yield return claim;
			}
		}
	}

	public JwtSecurityToken ReadJwtToken(string token)
	{
		if (string.IsNullOrEmpty(token))
		{
			throw LogHelper.LogArgumentNullException("token");
		}
		if (token.Length > MaximumTokenSizeInBytes)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10209: Token has length: '{0}' which is larger than the MaximumTokenSizeInBytes: '{1}'.", token.Length, MaximumTokenSizeInBytes)));
		}
		if (!CanReadToken(token))
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX12709: CanReadToken() returned false. JWT is not well formed: '{0}'.\nThe token needs to be in JWS or JWE Compact Serialization Format. (JWS): 'EncodedHeader.EndcodedPayload.EncodedSignature'. (JWE): 'EncodedProtectedHeader.EncodedEncryptedKey.EncodedInitializationVector.EncodedCiphertext.EncodedAuthenticationTag'.", token)));
		}
		JwtSecurityToken jwtSecurityToken = new JwtSecurityToken();
		jwtSecurityToken.Decode(token.Split(new char[1] { '.' }), token);
		return jwtSecurityToken;
	}

	public override SecurityToken ReadToken(string token)
	{
		return ReadJwtToken(token);
	}

	public override SecurityToken ReadToken(XmlReader reader, TokenValidationParameters validationParameters)
	{
		throw new NotImplementedException();
	}

	public override ClaimsPrincipal ValidateToken(string token, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
	{
		if (string.IsNullOrWhiteSpace(token))
		{
			throw LogHelper.LogArgumentNullException("token");
		}
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (token.Length > MaximumTokenSizeInBytes)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10209: Token has length: '{0}' which is larger than the MaximumTokenSizeInBytes: '{1}'.", token.Length, MaximumTokenSizeInBytes)));
		}
		string[] array = token.Split(new char[1] { '.' }, 6);
		if (array.Length != 3 && array.Length != 5)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX12741: JWT: '{0}' must have three segments (JWS) or five segments (JWE).", token)));
		}
		if (array.Length == 5)
		{
			JwtSecurityToken jwtSecurityToken = ReadJwtToken(token);
			string token2 = DecryptToken(jwtSecurityToken, validationParameters);
			JwtSecurityToken jwtToken = (jwtSecurityToken.InnerToken = ValidateSignature(token2, validationParameters));
			validatedToken = jwtSecurityToken;
			return ValidateTokenPayload(jwtToken, validationParameters);
		}
		validatedToken = ValidateSignature(token, validationParameters);
		return ValidateTokenPayload(validatedToken as JwtSecurityToken, validationParameters);
	}

	protected ClaimsPrincipal ValidateTokenPayload(JwtSecurityToken jwtToken, TokenValidationParameters validationParameters)
	{
		DateTime? expires = ((!jwtToken.Payload.Exp.HasValue) ? ((DateTime?)null) : new DateTime?(jwtToken.ValidTo));
		DateTime? notBefore = ((!jwtToken.Payload.Nbf.HasValue) ? ((DateTime?)null) : new DateTime?(jwtToken.ValidFrom));
		ValidateLifetime(notBefore, expires, jwtToken, validationParameters);
		ValidateAudience(jwtToken.Audiences, jwtToken, validationParameters);
		string issuer = ValidateIssuer(jwtToken.Issuer, jwtToken, validationParameters);
		ValidateTokenReplay(expires, jwtToken.RawData, validationParameters);
		if (validationParameters.ValidateActor && !string.IsNullOrWhiteSpace(jwtToken.Actor))
		{
			ValidateToken(jwtToken.Actor, validationParameters.ActorValidationParameters ?? validationParameters, out var _);
		}
		ValidateIssuerSecurityKey(jwtToken.SigningKey, jwtToken, validationParameters);
		JwtTokenUtilities.ValidateTokenType(jwtToken.Header.Typ, validationParameters);
		ClaimsIdentity claimsIdentity = CreateClaimsIdentity(jwtToken, issuer, validationParameters);
		if (validationParameters.SaveSigninToken)
		{
			claimsIdentity.BootstrapContext = jwtToken.RawData;
		}
		LogHelper.LogInformation("IDX10241: Security token validated. token: '{0}'.", jwtToken.RawData);
		return new ClaimsPrincipal(claimsIdentity);
	}

	public override string WriteToken(SecurityToken token)
	{
		if (token == null)
		{
			throw LogHelper.LogArgumentNullException("token");
		}
		if (!(token is JwtSecurityToken { EncodedPayload: var encodedPayload } jwtSecurityToken))
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX12706: '{0}' can only write SecurityTokens of type: '{1}', 'token' type is: '{2}'.", GetType(), typeof(JwtSecurityToken), token.GetType()), "token"));
		}
		string text = string.Empty;
		string empty = string.Empty;
		if (jwtSecurityToken.InnerToken != null)
		{
			if (jwtSecurityToken.SigningCredentials != null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException("IDX12736: JwtSecurityToken.SigningCredentials is not supported when JwtSecurityToken.InnerToken is set."));
			}
			if (jwtSecurityToken.InnerToken.Header.EncryptingCredentials != null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException("IDX12737: EncryptingCredentials set on JwtSecurityToken.InnerToken is not supported."));
			}
			if (jwtSecurityToken.Header.EncryptingCredentials == null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException("IDX12735: If JwtSecurityToken.InnerToken != null, then JwtSecurityToken.Header.EncryptingCredentials must be set."));
			}
			if (jwtSecurityToken.InnerToken.SigningCredentials != null)
			{
				text = JwtTokenUtilities.CreateEncodedSignature(jwtSecurityToken.InnerToken.EncodedHeader + "." + jwtSecurityToken.EncodedPayload, jwtSecurityToken.InnerToken.SigningCredentials);
			}
			return EncryptToken(new JwtSecurityToken(jwtSecurityToken.InnerToken.Header, jwtSecurityToken.InnerToken.Payload, jwtSecurityToken.InnerToken.EncodedHeader, encodedPayload, text), jwtSecurityToken.EncryptingCredentials).RawData;
		}
		JwtHeader jwtHeader = ((jwtSecurityToken.EncryptingCredentials == null) ? jwtSecurityToken.Header : new JwtHeader(jwtSecurityToken.SigningCredentials));
		empty = jwtHeader.Base64UrlEncode();
		if (jwtSecurityToken.SigningCredentials != null)
		{
			text = JwtTokenUtilities.CreateEncodedSignature(empty + "." + encodedPayload, jwtSecurityToken.SigningCredentials);
		}
		if (jwtSecurityToken.EncryptingCredentials != null)
		{
			return EncryptToken(new JwtSecurityToken(jwtHeader, jwtSecurityToken.Payload, empty, encodedPayload, text), jwtSecurityToken.EncryptingCredentials).RawData;
		}
		return empty + "." + encodedPayload + "." + text;
	}

	private bool ValidateSignature(byte[] encodedBytes, byte[] signature, SecurityKey key, string algorithm, TokenValidationParameters validationParameters)
	{
		CryptoProviderFactory cryptoProviderFactory = validationParameters.CryptoProviderFactory ?? key.CryptoProviderFactory;
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

	protected virtual JwtSecurityToken ValidateSignature(string token, TokenValidationParameters validationParameters)
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
			if (!(securityToken is JwtSecurityToken result))
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10506: Signature validation failed. The user defined 'Delegate' specified on TokenValidationParameters did not return a '{0}', but returned a '{1}' when validating token: '{2}'.", typeof(JwtSecurityToken), securityToken.GetType(), token)));
			}
			return result;
		}
		JwtSecurityToken jwtSecurityToken = null;
		if (validationParameters.TokenReader != null)
		{
			SecurityToken securityToken2 = validationParameters.TokenReader(token, validationParameters);
			if (securityToken2 == null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10510: Signature validation failed. The user defined 'Delegate' specified in TokenValidationParameters returned null when reading token: '{0}'.", token)));
			}
			jwtSecurityToken = securityToken2 as JwtSecurityToken;
			if (jwtSecurityToken == null)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10509: Signature validation failed. The user defined 'Delegate' specified in TokenValidationParameters did not return a '{0}', but returned a '{1}' when reading token: '{2}'.", typeof(JwtSecurityToken), securityToken2.GetType(), token)));
			}
		}
		else
		{
			jwtSecurityToken = ReadJwtToken(token);
		}
		byte[] bytes = Encoding.UTF8.GetBytes(jwtSecurityToken.RawHeader + "." + jwtSecurityToken.RawPayload);
		if (string.IsNullOrEmpty(jwtSecurityToken.RawSignature))
		{
			if (validationParameters.RequireSignedTokens)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10504: Unable to validate signature, token does not have a signature: '{0}'.", token)));
			}
			return jwtSecurityToken;
		}
		bool flag = false;
		IEnumerable<SecurityKey> enumerable = null;
		if (validationParameters.IssuerSigningKeyResolver != null)
		{
			enumerable = validationParameters.IssuerSigningKeyResolver(token, jwtSecurityToken, jwtSecurityToken.Header.Kid, validationParameters);
		}
		else
		{
			SecurityKey securityKey = ResolveIssuerSigningKey(token, jwtSecurityToken, validationParameters);
			if (securityKey != null)
			{
				flag = true;
				enumerable = new List<SecurityKey> { securityKey };
			}
		}
		if (enumerable == null)
		{
			enumerable = GetAllSigningKeys(token, jwtSecurityToken, jwtSecurityToken.Header.Kid, validationParameters);
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		bool flag2 = !string.IsNullOrEmpty(jwtSecurityToken.Header.Kid);
		byte[] signature;
		try
		{
			signature = Base64UrlEncoder.DecodeBytes(jwtSecurityToken.RawSignature);
		}
		catch (FormatException innerException)
		{
			throw new SecurityTokenInvalidSignatureException("IDX10508: Signature validation failed. Signature is improperly formatted.", innerException);
		}
		foreach (SecurityKey item in enumerable)
		{
			try
			{
				if (ValidateSignature(bytes, signature, item, jwtSecurityToken.Header.Alg, validationParameters))
				{
					LogHelper.LogInformation("IDX10242: Security token: '{0}' has a valid signature.", token);
					jwtSecurityToken.SigningKey = item;
					return jwtSecurityToken;
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
					flag = jwtSecurityToken.Header.Kid.Equals(item.KeyId, (item is X509SecurityKey) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
				}
			}
		}
		if (flag2)
		{
			if (flag)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10511: Signature validation failed. Keys tried: '{0}'. \nkid: '{1}'. \nExceptions caught:\n '{2}'.\ntoken: '{3}'.", stringBuilder2, jwtSecurityToken.Header.Kid, stringBuilder, jwtSecurityToken)));
			}
			throw LogHelper.LogExceptionMessage(new SecurityTokenSignatureKeyNotFoundException(LogHelper.FormatInvariant("IDX10501: Signature validation failed. Unable to match key: \nkid: '{0}'.\nExceptions caught:\n '{1}'. \ntoken: '{2}'.", jwtSecurityToken.Header.Kid, stringBuilder, jwtSecurityToken)));
		}
		if (stringBuilder2.Length > 0)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSignatureException(LogHelper.FormatInvariant("IDX10503: Signature validation failed. Keys tried: '{0}'.\nExceptions caught:\n '{1}'.\ntoken: '{2}'.", stringBuilder2, stringBuilder, jwtSecurityToken)));
		}
		throw LogHelper.LogExceptionMessage(new SecurityTokenSignatureKeyNotFoundException("IDX10500: Signature validation failed. No security keys were provided to validate the signature."));
	}

	private IEnumerable<SecurityKey> GetAllSigningKeys(string token, JwtSecurityToken securityToken, string kid, TokenValidationParameters validationParameters)
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

	private IEnumerable<SecurityKey> GetAllDecryptionKeys(TokenValidationParameters validationParameters)
	{
		if (validationParameters.TokenDecryptionKey != null)
		{
			yield return validationParameters.TokenDecryptionKey;
		}
		if (validationParameters.TokenDecryptionKeys == null)
		{
			yield break;
		}
		foreach (SecurityKey tokenDecryptionKey in validationParameters.TokenDecryptionKeys)
		{
			yield return tokenDecryptionKey;
		}
	}

	protected virtual ClaimsIdentity CreateClaimsIdentity(JwtSecurityToken jwtToken, string issuer, TokenValidationParameters validationParameters)
	{
		if (jwtToken == null)
		{
			throw LogHelper.LogArgumentNullException("jwtToken");
		}
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		string actualIssuer = issuer;
		if (string.IsNullOrWhiteSpace(issuer))
		{
			LogHelper.LogVerbose("IDX10244: Issuer is null or empty. Using runtime default for creating claims '{0}'.", "LOCAL AUTHORITY");
			actualIssuer = "LOCAL AUTHORITY";
		}
		if (!MapInboundClaims)
		{
			return CreateClaimsIdentityWithoutMapping(jwtToken, actualIssuer, validationParameters);
		}
		return CreateClaimsIdentityWithMapping(jwtToken, actualIssuer, validationParameters);
	}

	private ClaimsIdentity CreateClaimsIdentityWithMapping(JwtSecurityToken jwtToken, string actualIssuer, TokenValidationParameters validationParameters)
	{
		ClaimsIdentity claimsIdentity = validationParameters.CreateClaimsIdentity(jwtToken, actualIssuer);
		foreach (Claim claim2 in jwtToken.Claims)
		{
			if (_inboundClaimFilter.Contains(claim2.Type))
			{
				continue;
			}
			bool flag = true;
			if (!_inboundClaimTypeMap.TryGetValue(claim2.Type, out var value))
			{
				value = claim2.Type;
				flag = false;
			}
			if (value == "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor")
			{
				if (claimsIdentity.Actor != null)
				{
					throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX12710: Only a single 'Actor' is supported. Found second claim of type: '{0}', value: '{1}'", "actort", claim2.Value)));
				}
				if (CanReadToken(claim2.Value))
				{
					JwtSecurityToken jwtToken2 = ReadToken(claim2.Value) as JwtSecurityToken;
					claimsIdentity.Actor = CreateClaimsIdentity(jwtToken2, actualIssuer, validationParameters);
				}
			}
			Claim claim = new Claim(value, claim2.Value, claim2.ValueType, actualIssuer, actualIssuer, claimsIdentity);
			if (claim2.Properties.Count > 0)
			{
				foreach (KeyValuePair<string, string> property in claim2.Properties)
				{
					claim.Properties[property.Key] = property.Value;
				}
			}
			if (flag)
			{
				claim.Properties[ShortClaimTypeProperty] = claim2.Type;
			}
			claimsIdentity.AddClaim(claim);
		}
		return claimsIdentity;
	}

	private ClaimsIdentity CreateClaimsIdentityWithoutMapping(JwtSecurityToken jwtToken, string actualIssuer, TokenValidationParameters validationParameters)
	{
		ClaimsIdentity claimsIdentity = validationParameters.CreateClaimsIdentity(jwtToken, actualIssuer);
		foreach (Claim claim2 in jwtToken.Claims)
		{
			if (_inboundClaimFilter.Contains(claim2.Type))
			{
				continue;
			}
			string type = claim2.Type;
			if (type == "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor")
			{
				if (claimsIdentity.Actor != null)
				{
					throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX12710: Only a single 'Actor' is supported. Found second claim of type: '{0}', value: '{1}'", "actort", claim2.Value)));
				}
				if (CanReadToken(claim2.Value))
				{
					JwtSecurityToken jwtToken2 = ReadToken(claim2.Value) as JwtSecurityToken;
					claimsIdentity.Actor = CreateClaimsIdentity(jwtToken2, actualIssuer, validationParameters);
				}
			}
			Claim claim = new Claim(type, claim2.Value, claim2.ValueType, actualIssuer, actualIssuer, claimsIdentity);
			if (claim2.Properties.Count > 0)
			{
				foreach (KeyValuePair<string, string> property in claim2.Properties)
				{
					claim.Properties[property.Key] = property.Value;
				}
			}
			claimsIdentity.AddClaim(claim);
		}
		return claimsIdentity;
	}

	protected virtual string CreateActorValue(ClaimsIdentity actor)
	{
		if (actor == null)
		{
			throw LogHelper.LogArgumentNullException("actor");
		}
		if (actor.BootstrapContext != null)
		{
			if (actor.BootstrapContext is string result)
			{
				LogHelper.LogVerbose("IDX12713: Creating actor value using actor.BootstrapContext(as string)");
				return result;
			}
			if (actor.BootstrapContext is JwtSecurityToken jwtSecurityToken)
			{
				if (jwtSecurityToken.RawData != null)
				{
					LogHelper.LogVerbose("IDX12714: Creating actor value using actor.BootstrapContext.rawData");
					return jwtSecurityToken.RawData;
				}
				LogHelper.LogVerbose("IDX12715: Creating actor value by writing the JwtSecurityToken created from actor.BootstrapContext");
				return WriteToken(jwtSecurityToken);
			}
			LogHelper.LogVerbose("IDX12711: actor.BootstrapContext is not a string AND actor.BootstrapContext is not a JWT");
		}
		LogHelper.LogVerbose("IDX12712: actor.BootstrapContext is null. Creating the token using actor.Claims.");
		return WriteToken(new JwtSecurityToken(null, null, actor.Claims));
	}

	protected virtual void ValidateAudience(IEnumerable<string> audiences, JwtSecurityToken jwtToken, TokenValidationParameters validationParameters)
	{
		Validators.ValidateAudience(audiences, jwtToken, validationParameters);
	}

	protected virtual void ValidateLifetime(DateTime? notBefore, DateTime? expires, JwtSecurityToken jwtToken, TokenValidationParameters validationParameters)
	{
		Validators.ValidateLifetime(notBefore, expires, jwtToken, validationParameters);
	}

	protected virtual string ValidateIssuer(string issuer, JwtSecurityToken jwtToken, TokenValidationParameters validationParameters)
	{
		return Validators.ValidateIssuer(issuer, jwtToken, validationParameters);
	}

	protected virtual void ValidateTokenReplay(DateTime? expires, string securityToken, TokenValidationParameters validationParameters)
	{
		Validators.ValidateTokenReplay(expires, securityToken, validationParameters);
	}

	protected virtual SecurityKey ResolveIssuerSigningKey(string token, JwtSecurityToken jwtToken, TokenValidationParameters validationParameters)
	{
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (jwtToken == null)
		{
			throw LogHelper.LogArgumentNullException("jwtToken");
		}
		return JwtTokenUtilities.FindKeyMatch(jwtToken.Header.Kid, jwtToken.Header.X5t, validationParameters.IssuerSigningKey, validationParameters.IssuerSigningKeys);
	}

	protected virtual SecurityKey ResolveTokenDecryptionKey(string token, JwtSecurityToken jwtToken, TokenValidationParameters validationParameters)
	{
		if (jwtToken == null)
		{
			throw LogHelper.LogArgumentNullException("jwtToken");
		}
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		return JwtTokenUtilities.FindKeyMatch(jwtToken.Header.Kid, jwtToken.Header.X5t, validationParameters.TokenDecryptionKey, validationParameters.TokenDecryptionKeys);
	}

	private byte[] DecryptToken(JwtSecurityToken jwtToken, CryptoProviderFactory cryptoProviderFactory, SecurityKey key)
	{
		AuthenticatedEncryptionProvider authenticatedEncryptionProvider = cryptoProviderFactory.CreateAuthenticatedEncryptionProvider(key, jwtToken.Header.Enc);
		if (authenticatedEncryptionProvider == null)
		{
			throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10610: Decryption failed. Could not create decryption provider. Key: '{0}', Algorithm: '{1}'.", key, jwtToken.Header.Enc)));
		}
		return authenticatedEncryptionProvider.Decrypt(Base64UrlEncoder.DecodeBytes(jwtToken.RawCiphertext), Encoding.ASCII.GetBytes(jwtToken.RawHeader), Base64UrlEncoder.DecodeBytes(jwtToken.RawInitializationVector), Base64UrlEncoder.DecodeBytes(jwtToken.RawAuthenticationTag));
	}

	protected string DecryptToken(JwtSecurityToken jwtToken, TokenValidationParameters validationParameters)
	{
		if (jwtToken == null)
		{
			throw LogHelper.LogArgumentNullException("jwtToken");
		}
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (string.IsNullOrEmpty(jwtToken.Header.Enc))
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
			if (!cryptoProviderFactory.IsSupportedAlgorithm(jwtToken.Header.Enc, item))
			{
				LogHelper.LogWarning("IDX10611: Decryption failed. Encryption is not supported for: Algorithm: '{0}', SecurityKey: '{1}'.", jwtToken.Header.Enc, item);
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
				goto IL_0101;
			}
			break;
			IL_0101:
			if (item != null)
			{
				stringBuilder2.AppendLine(item.ToString());
			}
		}
		if (!flag && stringBuilder2.Length > 0)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenDecryptionFailedException(LogHelper.FormatInvariant("IDX10603: Decryption failed. Keys tried: '{0}'.\nExceptions caught:\n '{1}'.\ntoken: '{2}'", stringBuilder2, stringBuilder, jwtToken.RawData)));
		}
		if (!flag)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenDecryptionFailedException(LogHelper.FormatInvariant("IDX10609: Decryption failed. No Keys tried: token: '{0}'.", jwtToken.RawData)));
		}
		if (string.IsNullOrEmpty(jwtToken.Header.Zip))
		{
			return Encoding.UTF8.GetString(array);
		}
		try
		{
			return JwtTokenUtilities.DecompressToken(array, jwtToken.Header.Zip);
		}
		catch (Exception inner)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenDecompressionFailedException(LogHelper.FormatInvariant("IDX10679: Failed to decompress using algorithm '{0}'.", jwtToken.Header.Zip), inner));
		}
	}

	private IEnumerable<SecurityKey> GetContentEncryptionKeys(JwtSecurityToken jwtToken, TokenValidationParameters validationParameters)
	{
		IEnumerable<SecurityKey> enumerable = null;
		if (validationParameters.TokenDecryptionKeyResolver != null)
		{
			enumerable = validationParameters.TokenDecryptionKeyResolver(jwtToken.RawData, jwtToken, jwtToken.Header.Kid, validationParameters);
		}
		else
		{
			SecurityKey securityKey = ResolveTokenDecryptionKey(jwtToken.RawData, jwtToken, validationParameters);
			if (securityKey != null)
			{
				enumerable = new List<SecurityKey> { securityKey };
			}
		}
		if (enumerable == null)
		{
			enumerable = GetAllDecryptionKeys(validationParameters);
		}
		if (jwtToken.Header.Alg.Equals("dir", StringComparison.Ordinal))
		{
			return enumerable;
		}
		List<SecurityKey> list = new List<SecurityKey>();
		foreach (SecurityKey item in enumerable)
		{
			if (item.CryptoProviderFactory.IsSupportedAlgorithm(jwtToken.Header.Alg, item))
			{
				byte[] key = item.CryptoProviderFactory.CreateKeyWrapProviderForUnwrap(item, jwtToken.Header.Alg).UnwrapKey(Base64UrlEncoder.DecodeBytes(jwtToken.RawEncryptedKey));
				list.Add(new SymmetricSecurityKey(key));
			}
		}
		return list;
	}

	private byte[] GetSymmetricSecurityKey(SecurityKey key)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (key is SymmetricSecurityKey symmetricSecurityKey)
		{
			return symmetricSecurityKey.Key;
		}
		if (key is JsonWebKey { K: not null } jsonWebKey)
		{
			return Base64UrlEncoder.DecodeBytes(jsonWebKey.K);
		}
		return null;
	}

	protected virtual void ValidateIssuerSecurityKey(SecurityKey key, JwtSecurityToken securityToken, TokenValidationParameters validationParameters)
	{
		Validators.ValidateIssuerSecurityKey(key, securityToken, validationParameters);
	}

	public override void WriteToken(XmlWriter writer, SecurityToken token)
	{
		throw new NotImplementedException();
	}
}
internal static class LogMessages
{
	internal const string IDX12401 = "IDX12401: Expires: '{0}' must be after NotBefore: '{1}'.";

	internal const string IDX12700 = "IDX12700: Error found while parsing date time. The '{0}' claim has value '{1}' which is could not be parsed to an integer.";

	internal const string IDX12701 = "IDX12701: Error found while parsing date time. The '{0}' claim has value '{1}' does not lie in the valid range.";

	internal const string IDX12706 = "IDX12706: '{0}' can only write SecurityTokens of type: '{1}', 'token' type is: '{2}'.";

	internal const string IDX12709 = "IDX12709: CanReadToken() returned false. JWT is not well formed: '{0}'.\nThe token needs to be in JWS or JWE Compact Serialization Format. (JWS): 'EncodedHeader.EndcodedPayload.EncodedSignature'. (JWE): 'EncodedProtectedHeader.EncodedEncryptedKey.EncodedInitializationVector.EncodedCiphertext.EncodedAuthenticationTag'.";

	internal const string IDX12710 = "IDX12710: Only a single 'Actor' is supported. Found second claim of type: '{0}', value: '{1}'";

	internal const string IDX12711 = "IDX12711: actor.BootstrapContext is not a string AND actor.BootstrapContext is not a JWT";

	internal const string IDX12712 = "IDX12712: actor.BootstrapContext is null. Creating the token using actor.Claims.";

	internal const string IDX12713 = "IDX12713: Creating actor value using actor.BootstrapContext(as string)";

	internal const string IDX12714 = "IDX12714: Creating actor value using actor.BootstrapContext.rawData";

	internal const string IDX12715 = "IDX12715: Creating actor value by writing the JwtSecurityToken created from actor.BootstrapContext";

	internal const string IDX12716 = "IDX12716: Decoding token: '{0}' into header, payload and signature.";

	internal const string IDX12720 = "IDX12720: Token string does not match the token formats: JWE (header.encryptedKey.iv.ciphertext.tag) or JWS (header.payload.signature)";

	internal const string IDX12721 = "IDX12721: Creating JwtSecurityToken: Issuer: '{0}', Audience: '{1}'";

	internal const string IDX12722 = "IDX12722: Creating security token from the header: '{0}', payload: '{1}' and raw signature: '{2}'.";

	internal const string IDX12723 = "IDX12723: Unable to decode the payload '{0}' as Base64Url encoded string. jwtEncodedString: '{1}'.";

	internal const string IDX12729 = "IDX12729: Unable to decode the header '{0}' as Base64Url encoded string. jwtEncodedString: '{1}'.";

	internal const string IDX12730 = "IDX12730: Failed to create the token encryption provider.";

	internal const string IDX12733 = "IDX12733: Unable to obtain a CryptoProviderFactory, both EncryptingCredentials.CryptoProviderFactory and EncryptingCredentials.Key.CrypoProviderFactory are both null.";

	internal const string IDX12735 = "IDX12735: If JwtSecurityToken.InnerToken != null, then JwtSecurityToken.Header.EncryptingCredentials must be set.";

	internal const string IDX12736 = "IDX12736: JwtSecurityToken.SigningCredentials is not supported when JwtSecurityToken.InnerToken is set.";

	internal const string IDX12737 = "IDX12737: EncryptingCredentials set on JwtSecurityToken.InnerToken is not supported.";

	internal const string IDX12738 = "IDX12738: Header.Cty != null, assuming JWS. Cty: '{0}'.";

	internal const string IDX12739 = "IDX12739: JWT: '{0}' has three segments but is not in proper JWS format.";

	internal const string IDX12740 = "IDX12740: JWT: '{0}' has five segments but is not in proper JWE format.";

	internal const string IDX12741 = "IDX12741: JWT: '{0}' must have three segments (JWS) or five segments (JWE).";
}
