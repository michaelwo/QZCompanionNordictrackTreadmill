using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Microsoft.IdentityModel.KeyVaultExtensions, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9")]
[assembly: InternalsVisibleTo("Microsoft.IdentityModel.Tokens.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9")]
[assembly: AssemblyInformationalVersion("5.6.0.61018232319.2574f3cbc3736db085497b9b241ea5ae338357b9")]
[assembly: AssemblyFileVersion("5.6.0.61018")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: InternalsVisibleTo("Microsoft.IdentityModel.Tokens.Saml, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9")]
[assembly: InternalsVisibleTo("System.IdentityModel.Tokens.Jwt, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9")]
[assembly: InternalsVisibleTo("Microsoft.IdentityModel.JsonWebTokens, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b5fc90e7027f67871e773a8fde8938c81dd402ba65b9201d60593e96c492651e889cc13f1415ebb53fac1131ae0bd333c5ee6021672d9718ea31a8aebd0da0072f25d87dba6fc90ffd598ed4da35e44c398c454307e8e33b8426143daec9f596836f97c8f74750e5975c64e2189f45def46b2a2b1247adc3652bf5c308055da9")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Includes types that provide support for SecurityTokens, Cryptographic operations: Signing, Verifying Signatures, Encryption.")]
[assembly: AssemblyProduct("Microsoft IdentityModel")]
[assembly: AssemblyTitle("Microsoft.IdentityModel.Tokens")]
[assembly: AssemblyVersion("5.6.0.0")]
namespace Microsoft.IdentityModel.Tokens;

internal delegate byte[] SignDelegate(byte[] bytes);
internal delegate bool VerifyDelegate(byte[] bytes, byte[] signature);
internal class AsymmetricAdapter : IDisposable
{
	private RSAEncryptionPadding _rsaEncryptionPadding;

	private bool _disposeCryptoOperators;

	private bool _disposed;

	private SignDelegate SignatureFunction;

	private VerifyDelegate VerifyFunction;

	private object _signRsaLock = new object();

	private object _signEcdsaLock = new object();

	private object _verifyRsaLock = new object();

	private object _verifyEcdsaLock = new object();

	private ECDsaSecurityKey ECDsaSecurityKey { get; set; }

	private HashAlgorithm HashAlgorithm { get; set; }

	private HashAlgorithmName HashAlgorithmName { get; set; }

	private RSASignaturePadding RSASignaturePadding { get; set; }

	private RSA RSA { get; set; }

	internal AsymmetricAdapter(SecurityKey key, string algorithm, HashAlgorithm hashAlgorithm, HashAlgorithmName hashAlgorithmName, bool requirePrivateKey)
		: this(key, algorithm, hashAlgorithm, requirePrivateKey)
	{
		HashAlgorithmName = hashAlgorithmName;
	}

	internal AsymmetricAdapter(SecurityKey key, string algorithm, bool requirePrivateKey)
		: this(key, algorithm, null, requirePrivateKey)
	{
	}

	internal AsymmetricAdapter(SecurityKey key, string algorithm, HashAlgorithm hashAlgorithm, bool requirePrivateKey)
	{
		HashAlgorithm = hashAlgorithm;
		if (key is RsaSecurityKey rsaSecurityKey)
		{
			InitializeUsingRsaSecurityKey(rsaSecurityKey, algorithm);
		}
		else if (key is X509SecurityKey x509SecurityKey)
		{
			InitializeUsingX509SecurityKey(x509SecurityKey, algorithm, requirePrivateKey);
		}
		else if (key is JsonWebKey webKey)
		{
			if (!JsonWebKeyConverter.TryConvertToSecurityKey(webKey, out var key2))
			{
				return;
			}
			if (key2 is RsaSecurityKey rsaSecurityKey2)
			{
				InitializeUsingRsaSecurityKey(rsaSecurityKey2, algorithm);
				return;
			}
			if (key2 is X509SecurityKey x509SecurityKey2)
			{
				InitializeUsingX509SecurityKey(x509SecurityKey2, algorithm, requirePrivateKey);
				return;
			}
			if (!(key2 is ECDsaSecurityKey ecdsaSecurityKey))
			{
				throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10684: Unable to convert the JsonWebKey to an AsymmetricSecurityKey. Algorithm: '{0}', Key: '{1}'.", algorithm, key)));
			}
			InitializeUsingEcdsaSecurityKey(ecdsaSecurityKey);
		}
		else
		{
			if (!(key is ECDsaSecurityKey eCDsaSecurityKey))
			{
				throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10684: Unable to convert the JsonWebKey to an AsymmetricSecurityKey. Algorithm: '{0}', Key: '{1}'.", algorithm, key)));
			}
			ECDsaSecurityKey = eCDsaSecurityKey;
			SignatureFunction = SignWithECDsa;
			VerifyFunction = VerifyWithECDsa;
		}
	}

	private void InitializeUsingRsaSecurityKey(RsaSecurityKey rsaSecurityKey, string algorithm)
	{
		if (rsaSecurityKey.Rsa != null)
		{
			InitializeUsingRsa(rsaSecurityKey.Rsa, algorithm);
			return;
		}
		RSA rSA = RSA.Create();
		rSA.ImportParameters(rsaSecurityKey.Parameters);
		InitializeUsingRsa(rSA, algorithm);
		_disposeCryptoOperators = true;
	}

	private void InitializeUsingX509SecurityKey(X509SecurityKey x509SecurityKey, string algorithm, bool requirePrivateKey)
	{
		if (requirePrivateKey)
		{
			InitializeUsingRsa(x509SecurityKey.PrivateKey as RSA, algorithm);
		}
		else
		{
			InitializeUsingRsa(x509SecurityKey.PublicKey as RSA, algorithm);
		}
	}

	private void InitializeUsingEcdsaSecurityKey(ECDsaSecurityKey ecdsaSecurityKey)
	{
		ECDsaSecurityKey = ecdsaSecurityKey;
		SignatureFunction = SignWithECDsa;
		VerifyFunction = VerifyWithECDsa;
	}

	internal byte[] Decrypt(byte[] data)
	{
		return RSA.Decrypt(data, _rsaEncryptionPadding);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (_disposed)
		{
			return;
		}
		_disposed = true;
		if (disposing && _disposeCryptoOperators)
		{
			if (ECDsaSecurityKey != null)
			{
				ECDsaSecurityKey.ECDsa.Dispose();
			}
			if (RSA != null)
			{
				RSA.Dispose();
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	internal byte[] Encrypt(byte[] data)
	{
		return RSA.Encrypt(data, _rsaEncryptionPadding);
	}

	private void InitializeUsingRsa(RSA rsa, string algorithm)
	{
		if (algorithm.Equals("PS256", StringComparison.Ordinal) || algorithm.Equals("http://www.w3.org/2007/05/xmldsig-more#sha256-rsa-MGF1", StringComparison.Ordinal) || algorithm.Equals("PS384", StringComparison.Ordinal) || algorithm.Equals("http://www.w3.org/2007/05/xmldsig-more#sha384-rsa-MGF1", StringComparison.Ordinal) || algorithm.Equals("PS512", StringComparison.Ordinal) || algorithm.Equals("http://www.w3.org/2007/05/xmldsig-more#sha512-rsa-MGF1", StringComparison.Ordinal))
		{
			RSASignaturePadding = RSASignaturePadding.Pss;
		}
		else
		{
			RSASignaturePadding = RSASignaturePadding.Pkcs1;
		}
		_rsaEncryptionPadding = ((algorithm.Equals("RSA-OAEP", StringComparison.Ordinal) || algorithm.Equals("http://www.w3.org/2001/04/xmlenc#rsa-oaep", StringComparison.Ordinal)) ? RSAEncryptionPadding.OaepSHA1 : RSAEncryptionPadding.Pkcs1);
		RSA = rsa;
		SignatureFunction = SignWithRsa;
		VerifyFunction = VerifyWithRsa;
	}

	internal byte[] Sign(byte[] bytes)
	{
		if (SignatureFunction != null)
		{
			return SignatureFunction(bytes);
		}
		throw LogHelper.LogExceptionMessage(new CryptographicException("IDX10685: Unable to Sign, Internal SignFunction is not available."));
	}

	private byte[] SignWithECDsa(byte[] bytes)
	{
		lock (_signEcdsaLock)
		{
			return ECDsaSecurityKey.ECDsa.SignHash(HashAlgorithm.ComputeHash(bytes));
		}
	}

	private byte[] SignWithRsa(byte[] bytes)
	{
		lock (_signRsaLock)
		{
			return RSA.SignHash(HashAlgorithm.ComputeHash(bytes), HashAlgorithmName, RSASignaturePadding);
		}
	}

	internal bool Verify(byte[] bytes, byte[] signature)
	{
		if (VerifyFunction != null)
		{
			return VerifyFunction(bytes, signature);
		}
		throw LogHelper.LogExceptionMessage(new NotSupportedException("IDX10686: Unable to Verify, Internal VerifyFunction is not available."));
	}

	private bool VerifyWithECDsa(byte[] bytes, byte[] signature)
	{
		lock (_verifyEcdsaLock)
		{
			return ECDsaSecurityKey.ECDsa.VerifyHash(HashAlgorithm.ComputeHash(bytes), signature);
		}
	}

	private bool VerifyWithRsa(byte[] bytes, byte[] signature)
	{
		lock (_verifyRsaLock)
		{
			return RSA.VerifyHash(HashAlgorithm.ComputeHash(bytes), signature, HashAlgorithmName, RSASignaturePadding);
		}
	}
}
public abstract class AsymmetricSecurityKey : SecurityKey
{
	[Obsolete("HasPrivateKey method is deprecated, please use PrivateKeyStatus.")]
	public abstract bool HasPrivateKey { get; }

	public abstract PrivateKeyStatus PrivateKeyStatus { get; }

	public AsymmetricSecurityKey()
	{
	}

	internal AsymmetricSecurityKey(SecurityKey key)
		: base(key)
	{
	}
}
public enum PrivateKeyStatus
{
	Exists,
	DoesNotExist,
	Unknown
}
public class AsymmetricSignatureProvider : SignatureProvider
{
	private bool _disposed;

	private AsymmetricAdapter _asymmetricAdapter;

	private CryptoProviderFactory _cryptoProviderFactory;

	private IReadOnlyDictionary<string, int> _minimumAsymmetricKeySizeInBitsForSigningMap;

	private IReadOnlyDictionary<string, int> _minimumAsymmetricKeySizeInBitsForVerifyingMap;

	public static readonly Dictionary<string, int> DefaultMinimumAsymmetricKeySizeInBitsForSigningMap = new Dictionary<string, int>
	{
		{ "ES256", 256 },
		{ "ES384", 256 },
		{ "ES512", 256 },
		{ "RS256", 2048 },
		{ "RS384", 2048 },
		{ "RS512", 2048 },
		{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256", 2048 },
		{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha384", 2048 },
		{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha512", 2048 },
		{ "PS256", 528 },
		{ "PS384", 784 },
		{ "PS512", 1040 },
		{ "http://www.w3.org/2007/05/xmldsig-more#sha256-rsa-MGF1", 528 },
		{ "http://www.w3.org/2007/05/xmldsig-more#sha384-rsa-MGF1", 784 },
		{ "http://www.w3.org/2007/05/xmldsig-more#sha512-rsa-MGF1", 1040 }
	};

	public static readonly Dictionary<string, int> DefaultMinimumAsymmetricKeySizeInBitsForVerifyingMap = new Dictionary<string, int>
	{
		{ "ES256", 256 },
		{ "ES384", 256 },
		{ "ES512", 256 },
		{ "RS256", 1024 },
		{ "RS384", 1024 },
		{ "RS512", 1024 },
		{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256", 1024 },
		{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha384", 1024 },
		{ "http://www.w3.org/2001/04/xmldsig-more#rsa-sha512", 1024 },
		{ "PS256", 528 },
		{ "PS384", 784 },
		{ "PS512", 1040 },
		{ "http://www.w3.org/2007/05/xmldsig-more#sha256-rsa-MGF1", 528 },
		{ "http://www.w3.org/2007/05/xmldsig-more#sha384-rsa-MGF1", 784 },
		{ "http://www.w3.org/2007/05/xmldsig-more#sha512-rsa-MGF1", 1040 }
	};

	public IReadOnlyDictionary<string, int> MinimumAsymmetricKeySizeInBitsForSigningMap => _minimumAsymmetricKeySizeInBitsForSigningMap;

	public IReadOnlyDictionary<string, int> MinimumAsymmetricKeySizeInBitsForVerifyingMap => _minimumAsymmetricKeySizeInBitsForVerifyingMap;

	internal AsymmetricSignatureProvider(SecurityKey key, string algorithm, CryptoProviderFactory cryptoProviderFactory)
		: this(key, algorithm)
	{
		_cryptoProviderFactory = cryptoProviderFactory;
	}

	internal AsymmetricSignatureProvider(SecurityKey key, string algorithm, bool willCreateSignatures, CryptoProviderFactory cryptoProviderFactory)
		: this(key, algorithm, willCreateSignatures)
	{
		_cryptoProviderFactory = cryptoProviderFactory;
	}

	public AsymmetricSignatureProvider(SecurityKey key, string algorithm)
		: this(key, algorithm, willCreateSignatures: false)
	{
	}

	public AsymmetricSignatureProvider(SecurityKey key, string algorithm, bool willCreateSignatures)
		: base(key, algorithm)
	{
		_cryptoProviderFactory = key.CryptoProviderFactory;
		_minimumAsymmetricKeySizeInBitsForSigningMap = new Dictionary<string, int>(DefaultMinimumAsymmetricKeySizeInBitsForSigningMap);
		_minimumAsymmetricKeySizeInBitsForVerifyingMap = new Dictionary<string, int>(DefaultMinimumAsymmetricKeySizeInBitsForVerifyingMap);
		JsonWebKey jsonWebKey = key as JsonWebKey;
		if (jsonWebKey != null)
		{
			JsonWebKeyConverter.TryConvertToSecurityKey(jsonWebKey, out var _);
		}
		if (willCreateSignatures && FoundPrivateKey(key) == PrivateKeyStatus.DoesNotExist)
		{
			throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10638: Cannot create the SignatureProvider, 'key.HasPrivateKey' is false, cannot create signatures. Key: {0}.", key)));
		}
		if (!_cryptoProviderFactory.IsSupportedAlgorithm(algorithm, key))
		{
			throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10634: Unable to create the SignatureProvider.\nAlgorithm: '{0}', SecurityKey: '{1}'\n is not supported. The list of supported algorithms is available here: https://aka.ms/IdentityModel/supported-algorithms", algorithm ?? "null", key)));
		}
		ValidateAsymmetricSecurityKeySize(key, algorithm, willCreateSignatures);
		_asymmetricAdapter = ResolveAsymmetricAdapter(jsonWebKey?.ConvertedSecurityKey ?? key, algorithm, willCreateSignatures);
		base.WillCreateSignatures = willCreateSignatures;
	}

	private PrivateKeyStatus FoundPrivateKey(SecurityKey key)
	{
		if (key is AsymmetricSecurityKey asymmetricSecurityKey)
		{
			return asymmetricSecurityKey.PrivateKeyStatus;
		}
		if (key is JsonWebKey jsonWebKey)
		{
			if (!jsonWebKey.HasPrivateKey)
			{
				return PrivateKeyStatus.DoesNotExist;
			}
			return PrivateKeyStatus.Exists;
		}
		return PrivateKeyStatus.Unknown;
	}

	protected virtual HashAlgorithmName GetHashAlgorithmName(string algorithm)
	{
		if (string.IsNullOrWhiteSpace(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		switch (algorithm)
		{
		case "ES256":
		case "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha256":
		case "RS256":
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256":
		case "PS256":
		case "http://www.w3.org/2007/05/xmldsig-more#sha256-rsa-MGF1":
			return HashAlgorithmName.SHA256;
		case "ES384":
		case "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha384":
		case "RS384":
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha384":
		case "PS384":
		case "http://www.w3.org/2007/05/xmldsig-more#sha384-rsa-MGF1":
			return HashAlgorithmName.SHA384;
		case "ES512":
		case "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha512":
		case "RS512":
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha512":
		case "PS512":
		case "http://www.w3.org/2007/05/xmldsig-more#sha512-rsa-MGF1":
			return HashAlgorithmName.SHA512;
		default:
			throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("algorithm", LogHelper.FormatInvariant("IDX10652: The algorithm '{0}' is not supported.", algorithm)));
		}
	}

	private AsymmetricAdapter ResolveAsymmetricAdapter(SecurityKey key, string algorithm, bool requirePrivateKey)
	{
		HashAlgorithmName hashAlgorithmName = GetHashAlgorithmName(algorithm);
		return new AsymmetricAdapter(key, algorithm, _cryptoProviderFactory.CreateHashAlgorithm(hashAlgorithmName), hashAlgorithmName, requirePrivateKey);
	}

	public override byte[] Sign(byte[] input)
	{
		if (input == null || input.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("input");
		}
		if (_disposed)
		{
			base.CryptoProviderCache?.TryRemove(this);
			throw LogHelper.LogExceptionMessage(new ObjectDisposedException(GetType().ToString()));
		}
		try
		{
			return _asymmetricAdapter.Sign(input);
		}
		catch
		{
			base.CryptoProviderCache?.TryRemove(this);
			throw;
		}
	}

	public virtual void ValidateAsymmetricSecurityKeySize(SecurityKey key, string algorithm, bool willCreateSignatures)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		int keySize = key.KeySize;
		if (key is AsymmetricSecurityKey asymmetricSecurityKey)
		{
			keySize = asymmetricSecurityKey.KeySize;
		}
		else
		{
			if (!(key is JsonWebKey webKey))
			{
				throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10704: Cannot verify the key size. The SecurityKey is not or cannot be converted to an AsymmetricSecuritKey. SecurityKey: '{0}'.", key)));
			}
			JsonWebKeyConverter.TryConvertToSecurityKey(webKey, out var key2);
			if (key2 is AsymmetricSecurityKey asymmetricSecurityKey2)
			{
				keySize = asymmetricSecurityKey2.KeySize;
			}
			else if (key2 is SymmetricSecurityKey)
			{
				throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10704: Cannot verify the key size. The SecurityKey is not or cannot be converted to an AsymmetricSecuritKey. SecurityKey: '{0}'.", key)));
			}
		}
		if (willCreateSignatures)
		{
			if (MinimumAsymmetricKeySizeInBitsForSigningMap.ContainsKey(algorithm) && keySize < MinimumAsymmetricKeySizeInBitsForSigningMap[algorithm])
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("key.KeySize", LogHelper.FormatInvariant("IDX10630: The '{0}' for signing cannot be smaller than '{1}' bits. KeySize: '{2}'.", key, MinimumAsymmetricKeySizeInBitsForSigningMap[algorithm], keySize)));
			}
		}
		else if (MinimumAsymmetricKeySizeInBitsForVerifyingMap.ContainsKey(algorithm) && keySize < MinimumAsymmetricKeySizeInBitsForVerifyingMap[algorithm])
		{
			throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("key.KeySize", LogHelper.FormatInvariant("IDX10631: The '{0}' for verifying cannot be smaller than '{1}' bits. KeySize: '{2}'.", key, MinimumAsymmetricKeySizeInBitsForVerifyingMap[algorithm], keySize)));
		}
	}

	public override bool Verify(byte[] input, byte[] signature)
	{
		if (input == null || input.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("input");
		}
		if (signature == null || signature.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("signature");
		}
		if (_disposed)
		{
			base.CryptoProviderCache?.TryRemove(this);
			throw LogHelper.LogExceptionMessage(new ObjectDisposedException(GetType().ToString()));
		}
		try
		{
			return _asymmetricAdapter.Verify(input, signature);
		}
		catch
		{
			base.CryptoProviderCache?.TryRemove(this);
			throw;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			_disposed = true;
			if (disposing)
			{
				base.CryptoProviderCache?.TryRemove(this);
				_asymmetricAdapter.Dispose();
			}
		}
	}
}
public static class Base64UrlEncoder
{
	private static char base64PadCharacter = '=';

	private static string doubleBase64PadCharacter = "==";

	private static char base64Character62 = '+';

	private static char base64Character63 = '/';

	private static char base64UrlCharacter62 = '-';

	private static char _base64UrlCharacter63 = '_';

	public static string Encode(string arg)
	{
		if (arg == null)
		{
			throw LogHelper.LogArgumentNullException("arg");
		}
		return Encode(Encoding.UTF8.GetBytes(arg));
	}

	public static string Encode(byte[] inArray, int offset, int length)
	{
		if (inArray == null)
		{
			throw LogHelper.LogArgumentNullException("inArray");
		}
		return Convert.ToBase64String(inArray, offset, length).Split(new char[1] { base64PadCharacter })[0].Replace(base64Character62, base64UrlCharacter62).Replace(base64Character63, _base64UrlCharacter63);
	}

	public static string Encode(byte[] inArray)
	{
		if (inArray == null)
		{
			throw LogHelper.LogArgumentNullException("inArray");
		}
		return Convert.ToBase64String(inArray, 0, inArray.Length).Split(new char[1] { base64PadCharacter })[0].Replace(base64Character62, base64UrlCharacter62).Replace(base64Character63, _base64UrlCharacter63);
	}

	public static byte[] DecodeBytes(string str)
	{
		if (str == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentNullException("str"));
		}
		str = str.Replace(base64UrlCharacter62, base64Character62);
		str = str.Replace(_base64UrlCharacter63, base64Character63);
		switch (str.Length % 4)
		{
		case 2:
			str += doubleBase64PadCharacter;
			break;
		case 3:
			str += base64PadCharacter;
			break;
		default:
			throw LogHelper.LogExceptionMessage(new FormatException(LogHelper.FormatInvariant("IDX10400: Unable to decode: '{0}' as Base64url encoded string.", str)));
		case 0:
			break;
		}
		return Convert.FromBase64String(str);
	}

	public static string Decode(string arg)
	{
		return Encoding.UTF8.GetString(DecodeBytes(arg));
	}
}
public class CompressionAlgorithms
{
	public const string Deflate = "DEF";
}
public class CompressionProviderFactory
{
	private static CompressionProviderFactory _default;

	public static CompressionProviderFactory Default
	{
		get
		{
			return _default;
		}
		set
		{
			_default = value ?? throw LogHelper.LogArgumentNullException("Default");
		}
	}

	public ICompressionProvider CustomCompressionProvider { get; set; }

	static CompressionProviderFactory()
	{
		Default = new CompressionProviderFactory();
	}

	public CompressionProviderFactory()
	{
	}

	public CompressionProviderFactory(CompressionProviderFactory other)
	{
		if (other == null)
		{
			throw LogHelper.LogArgumentNullException("other");
		}
		CustomCompressionProvider = other.CustomCompressionProvider;
	}

	public virtual bool IsSupportedAlgorithm(string algorithm)
	{
		if (CustomCompressionProvider != null && CustomCompressionProvider.IsSupportedAlgorithm(algorithm))
		{
			return true;
		}
		return IsSupportedCompressionAlgorithm(algorithm);
	}

	private bool IsSupportedCompressionAlgorithm(string algorithm)
	{
		return "DEF".Equals(algorithm, StringComparison.Ordinal);
	}

	public ICompressionProvider CreateCompressionProvider(string algorithm)
	{
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (CustomCompressionProvider != null && CustomCompressionProvider.IsSupportedAlgorithm(algorithm))
		{
			return CustomCompressionProvider;
		}
		if (algorithm.Equals("DEF", StringComparison.Ordinal))
		{
			return new DeflateCompressionProvider();
		}
		throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10652: The algorithm '{0}' is not supported.", algorithm)));
	}
}
public abstract class CryptoProviderCache
{
	protected abstract string GetCacheKey(SignatureProvider signatureProvider);

	protected abstract string GetCacheKey(SecurityKey securityKey, string algorithm, string typeofProvider);

	public abstract bool TryAdd(SignatureProvider signatureProvider);

	public abstract bool TryGetSignatureProvider(SecurityKey securityKey, string algorithm, string typeofProvider, bool willCreateSignatures, out SignatureProvider signatureProvider);

	public abstract bool TryRemove(SignatureProvider signatureProvider);
}
public class CryptoProviderFactory
{
	private static CryptoProviderFactory _default;

	private static ConcurrentDictionary<string, string> _typeToAlgorithmMap;

	private static object _cacheLock;

	public static CryptoProviderFactory Default
	{
		get
		{
			return _default;
		}
		set
		{
			_default = value ?? throw LogHelper.LogArgumentNullException("value");
		}
	}

	[DefaultValue(true)]
	public static bool DefaultCacheSignatureProviders { get; set; }

	public CryptoProviderCache CryptoProviderCache { get; } = new InMemoryCryptoProviderCache();

	public ICryptoProvider CustomCryptoProvider { get; set; }

	[DefaultValue(true)]
	public bool CacheSignatureProviders { get; set; } = DefaultCacheSignatureProviders;

	static CryptoProviderFactory()
	{
		_typeToAlgorithmMap = new ConcurrentDictionary<string, string>();
		_cacheLock = new object();
		DefaultCacheSignatureProviders = true;
		Default = new CryptoProviderFactory();
	}

	public CryptoProviderFactory()
	{
	}

	public CryptoProviderFactory(CryptoProviderFactory other)
	{
		if (other == null)
		{
			throw LogHelper.LogArgumentNullException("other");
		}
		CustomCryptoProvider = other.CustomCryptoProvider;
	}

	public virtual AuthenticatedEncryptionProvider CreateAuthenticatedEncryptionProvider(SecurityKey key, string algorithm)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(algorithm, key))
		{
			if (!(CustomCryptoProvider.Create(algorithm, key) is AuthenticatedEncryptionProvider result))
			{
				throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10646: A CustomCryptoProvider was set and returned 'true' for IsSupportedAlgorithm(Algorithm: '{0}', Key: '{1}'), but Create.(algorithm, args) as '{2}' == NULL.", algorithm, key, typeof(AuthenticatedEncryptionProvider))));
			}
			return result;
		}
		if (SupportedAlgorithms.IsSupportedAuthenticatedEncryptionAlgorithm(algorithm, key))
		{
			return new AuthenticatedEncryptionProvider(key, algorithm);
		}
		throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10652: The algorithm '{0}' is not supported.", algorithm), "algorithm"));
	}

	public virtual KeyWrapProvider CreateKeyWrapProvider(SecurityKey key, string algorithm)
	{
		return CreateKeyWrapProvider(key, algorithm, willUnwrap: false);
	}

	private KeyWrapProvider CreateKeyWrapProvider(SecurityKey key, string algorithm, bool willUnwrap)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(algorithm, key, willUnwrap))
		{
			if (!(CustomCryptoProvider.Create(algorithm, key, willUnwrap) is KeyWrapProvider result))
			{
				throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10646: A CustomCryptoProvider was set and returned 'true' for IsSupportedAlgorithm(Algorithm: '{0}', Key: '{1}'), but Create.(algorithm, args) as '{2}' == NULL.", algorithm, key, typeof(SignatureProvider))));
			}
			return result;
		}
		if (key is RsaSecurityKey key2 && SupportedAlgorithms.IsSupportedRsaAlgorithm(algorithm, key2))
		{
			return new RsaKeyWrapProvider(key, algorithm, willUnwrap);
		}
		if (key is X509SecurityKey key3 && SupportedAlgorithms.IsSupportedRsaAlgorithm(algorithm, key3))
		{
			return new RsaKeyWrapProvider(key3, algorithm, willUnwrap);
		}
		if (key is JsonWebKey jsonWebKey)
		{
			if (jsonWebKey.Kty == "RSA" && SupportedAlgorithms.IsSupportedRsaAlgorithm(algorithm, key))
			{
				return new RsaKeyWrapProvider(jsonWebKey, algorithm, willUnwrap);
			}
			if (jsonWebKey.Kty == "oct" && SupportedAlgorithms.IsSupportedSymmetricAlgorithm(algorithm))
			{
				return new SymmetricKeyWrapProvider(jsonWebKey, algorithm);
			}
		}
		if (key is SymmetricSecurityKey key4 && SupportedAlgorithms.IsSupportedSymmetricAlgorithm(algorithm))
		{
			return new SymmetricKeyWrapProvider(key4, algorithm);
		}
		throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10661: Unable to create the KeyWrapProvider.\nKeyWrapAlgorithm: '{0}', SecurityKey: '{1}'\n is not supported.", algorithm, key)));
	}

	public virtual KeyWrapProvider CreateKeyWrapProviderForUnwrap(SecurityKey key, string algorithm)
	{
		return CreateKeyWrapProvider(key, algorithm, willUnwrap: true);
	}

	public virtual SignatureProvider CreateForSigning(SecurityKey key, string algorithm)
	{
		return CreateSignatureProvider(key, algorithm, willCreateSignatures: true);
	}

	public virtual SignatureProvider CreateForVerifying(SecurityKey key, string algorithm)
	{
		return CreateSignatureProvider(key, algorithm, willCreateSignatures: false);
	}

	public virtual HashAlgorithm CreateHashAlgorithm(HashAlgorithmName algorithm)
	{
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(algorithm.Name))
		{
			if (!(CustomCryptoProvider.Create(algorithm.Name) is HashAlgorithm hashAlgorithm))
			{
				throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10647: A CustomCryptoProvider was set and returned 'true' for IsSupportedAlgorithm(Algorithm: '{0}'), but Create.(algorithm, args) as '{1}' == NULL.", algorithm, typeof(HashAlgorithm))));
			}
			_typeToAlgorithmMap[hashAlgorithm.GetType().ToString()] = algorithm.Name;
			return hashAlgorithm;
		}
		if (algorithm == HashAlgorithmName.SHA256)
		{
			return SHA256.Create();
		}
		if (algorithm == HashAlgorithmName.SHA384)
		{
			return SHA384.Create();
		}
		if (algorithm == HashAlgorithmName.SHA512)
		{
			return SHA512.Create();
		}
		throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10640: Algorithm is not supported: '{0}'.", algorithm)));
	}

	public virtual HashAlgorithm CreateHashAlgorithm(string algorithm)
	{
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(algorithm))
		{
			if (!(CustomCryptoProvider.Create(algorithm) is HashAlgorithm hashAlgorithm))
			{
				throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10647: A CustomCryptoProvider was set and returned 'true' for IsSupportedAlgorithm(Algorithm: '{0}'), but Create.(algorithm, args) as '{1}' == NULL.", algorithm, typeof(HashAlgorithm))));
			}
			_typeToAlgorithmMap[hashAlgorithm.GetType().ToString()] = algorithm;
			return hashAlgorithm;
		}
		switch (algorithm)
		{
		case "SHA256":
		case "http://www.w3.org/2001/04/xmlenc#sha256":
			return SHA256.Create();
		case "SHA384":
		case "http://www.w3.org/2001/04/xmldsig-more#sha384":
			return SHA384.Create();
		case "SHA512":
		case "http://www.w3.org/2001/04/xmlenc#sha512":
			return SHA512.Create();
		default:
			throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10640: Algorithm is not supported: '{0}'.", algorithm)));
		}
	}

	public virtual KeyedHashAlgorithm CreateKeyedHashAlgorithm(byte[] keyBytes, string algorithm)
	{
		if (keyBytes == null)
		{
			throw LogHelper.LogArgumentNullException("keyBytes");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(algorithm, keyBytes))
		{
			if (!(CustomCryptoProvider.Create(algorithm, keyBytes) is KeyedHashAlgorithm result))
			{
				throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10647: A CustomCryptoProvider was set and returned 'true' for IsSupportedAlgorithm(Algorithm: '{0}'), but Create.(algorithm, args) as '{1}' == NULL.", algorithm, typeof(KeyedHashAlgorithm))));
			}
			return result;
		}
		switch (algorithm)
		{
		case "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256":
		case "HS256":
			return new HMACSHA256(keyBytes);
		case "http://www.w3.org/2001/04/xmldsig-more#hmac-sha384":
		case "HS384":
			return new HMACSHA384(keyBytes);
		case "http://www.w3.org/2001/04/xmldsig-more#hmac-sha512":
		case "HS512":
			return new HMACSHA512(keyBytes);
		default:
			throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10666: Unable to create KeyedHashAlgorithm for algorithm '{0}'.", algorithm)));
		}
	}

	private SignatureProvider CreateSignatureProvider(SecurityKey key, string algorithm, bool willCreateSignatures)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		SignatureProvider signatureProvider = null;
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(algorithm, key, willCreateSignatures))
		{
			if (!(CustomCryptoProvider.Create(algorithm, key, willCreateSignatures) is SignatureProvider result))
			{
				throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10646: A CustomCryptoProvider was set and returned 'true' for IsSupportedAlgorithm(Algorithm: '{0}', Key: '{1}'), but Create.(algorithm, args) as '{2}' == NULL.", algorithm, key, typeof(SignatureProvider))));
			}
			return result;
		}
		string text = null;
		bool flag = true;
		if (key is AsymmetricSecurityKey)
		{
			text = typeof(AsymmetricSignatureProvider).ToString();
		}
		else if (key is JsonWebKey jsonWebKey)
		{
			try
			{
				if (JsonWebKeyConverter.TryConvertToSecurityKey(jsonWebKey, out var key2))
				{
					if (key2 is AsymmetricSecurityKey)
					{
						text = typeof(AsymmetricSignatureProvider).ToString();
					}
					else if (key2 is SymmetricSecurityKey)
					{
						text = typeof(SymmetricSignatureProvider).ToString();
						flag = false;
					}
				}
				else if (jsonWebKey.Kty == "RSA" || jsonWebKey.Kty == "EC")
				{
					text = typeof(AsymmetricSignatureProvider).ToString();
				}
				else if (jsonWebKey.Kty == "oct")
				{
					text = typeof(SymmetricSignatureProvider).ToString();
					flag = false;
				}
			}
			catch (Exception ex)
			{
				throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10694: JsonWebKeyConverter threw attempting to convert JsonWebKey: '{0}'. Exception: '{1}'.", key, ex), ex));
			}
		}
		else if (key is SymmetricSecurityKey)
		{
			text = typeof(SymmetricSignatureProvider).ToString();
			flag = false;
		}
		if (text == null)
		{
			throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10621: '{0}' supports: '{1}' of types: '{2}' or '{3}'. SecurityKey received was of type '{4}'.", typeof(SymmetricSignatureProvider), typeof(SecurityKey), typeof(AsymmetricSecurityKey), typeof(SymmetricSecurityKey), key.GetType())));
		}
		if (!IsSupportedAlgorithm(algorithm, key))
		{
			throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10634: Unable to create the SignatureProvider.\nAlgorithm: '{0}', SecurityKey: '{1}'\n is not supported. The list of supported algorithms is available here: https://aka.ms/IdentityModel/supported-algorithms", algorithm, key)));
		}
		if (!CacheSignatureProviders)
		{
			signatureProvider = ((!flag) ? ((SignatureProvider)new SymmetricSignatureProvider(key, algorithm, willCreateSignatures)) : ((SignatureProvider)new AsymmetricSignatureProvider(key, algorithm, willCreateSignatures)));
		}
		else
		{
			if (CryptoProviderCache.TryGetSignatureProvider(key, algorithm, text, willCreateSignatures, out signatureProvider))
			{
				return signatureProvider;
			}
			lock (_cacheLock)
			{
				if (CryptoProviderCache.TryGetSignatureProvider(key, algorithm, text, willCreateSignatures, out signatureProvider))
				{
					return signatureProvider;
				}
				signatureProvider = ((!flag) ? ((SignatureProvider)new SymmetricSignatureProvider(key, algorithm, willCreateSignatures)) : ((SignatureProvider)new AsymmetricSignatureProvider(key, algorithm, willCreateSignatures, this)));
				CryptoProviderCache.TryAdd(signatureProvider);
			}
		}
		return signatureProvider;
	}

	public virtual bool IsSupportedAlgorithm(string algorithm)
	{
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(algorithm))
		{
			return true;
		}
		return SupportedAlgorithms.IsSupportedHashAlgorithm(algorithm);
	}

	public virtual bool IsSupportedAlgorithm(string algorithm, SecurityKey key)
	{
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(algorithm, key))
		{
			return true;
		}
		return SupportedAlgorithms.IsSupportedAlgorithm(algorithm, (key is JsonWebKey { ConvertedSecurityKey: not null } jsonWebKey) ? jsonWebKey.ConvertedSecurityKey : key);
	}

	public virtual void ReleaseHashAlgorithm(HashAlgorithm hashAlgorithm)
	{
		if (hashAlgorithm == null)
		{
			throw LogHelper.LogArgumentNullException("hashAlgorithm");
		}
		if (CustomCryptoProvider != null && _typeToAlgorithmMap.TryGetValue(hashAlgorithm.GetType().ToString(), out var value) && CustomCryptoProvider.IsSupportedAlgorithm(value))
		{
			CustomCryptoProvider.Release(hashAlgorithm);
		}
		else
		{
			hashAlgorithm.Dispose();
		}
	}

	public virtual void ReleaseKeyWrapProvider(KeyWrapProvider provider)
	{
		if (provider == null)
		{
			throw LogHelper.LogArgumentNullException("provider");
		}
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(provider.Algorithm))
		{
			CustomCryptoProvider.Release(provider);
		}
		else
		{
			provider.Dispose();
		}
	}

	public virtual void ReleaseRsaKeyWrapProvider(RsaKeyWrapProvider provider)
	{
		if (provider == null)
		{
			throw LogHelper.LogArgumentNullException("provider");
		}
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(provider.Algorithm))
		{
			CustomCryptoProvider.Release(provider);
		}
		else
		{
			provider.Dispose();
		}
	}

	public virtual void ReleaseSignatureProvider(SignatureProvider signatureProvider)
	{
		if (signatureProvider == null)
		{
			throw LogHelper.LogArgumentNullException("signatureProvider");
		}
		if (CustomCryptoProvider != null && CustomCryptoProvider.IsSupportedAlgorithm(signatureProvider.Algorithm))
		{
			CustomCryptoProvider.Release(signatureProvider);
		}
		else if (signatureProvider.CryptoProviderCache == null)
		{
			signatureProvider.Dispose();
		}
	}
}
public static class DateTimeUtil
{
	public static DateTime Add(DateTime time, TimeSpan timespan)
	{
		if (timespan == TimeSpan.Zero)
		{
			return time;
		}
		if (timespan > TimeSpan.Zero && DateTime.MaxValue - time <= timespan)
		{
			return GetMaxValue(time.Kind);
		}
		if (timespan < TimeSpan.Zero && DateTime.MinValue - time >= timespan)
		{
			return GetMinValue(time.Kind);
		}
		return time + timespan;
	}

	public static DateTime GetMaxValue(DateTimeKind kind)
	{
		DateTime maxValue;
		if (kind == DateTimeKind.Unspecified)
		{
			maxValue = DateTime.MaxValue;
			return new DateTime(maxValue.Ticks, DateTimeKind.Utc);
		}
		maxValue = DateTime.MaxValue;
		return new DateTime(maxValue.Ticks, kind);
	}

	public static DateTime GetMinValue(DateTimeKind kind)
	{
		DateTime minValue;
		if (kind == DateTimeKind.Unspecified)
		{
			minValue = DateTime.MinValue;
			return new DateTime(minValue.Ticks, DateTimeKind.Utc);
		}
		minValue = DateTime.MinValue;
		return new DateTime(minValue.Ticks, kind);
	}

	public static DateTime? ToUniversalTime(DateTime? value)
	{
		if (!value.HasValue || value.Value.Kind == DateTimeKind.Utc)
		{
			return value;
		}
		return ToUniversalTime(value.Value);
	}

	public static DateTime ToUniversalTime(DateTime value)
	{
		if (value.Kind == DateTimeKind.Utc)
		{
			return value;
		}
		return value.ToUniversalTime();
	}
}
public class DeflateCompressionProvider : ICompressionProvider
{
	public string Algorithm => "DEF";

	public CompressionLevel CompressionLevel { get; private set; }

	public DeflateCompressionProvider()
	{
	}

	public DeflateCompressionProvider(CompressionLevel compressionLevel)
	{
		CompressionLevel = compressionLevel;
	}

	public byte[] Decompress(byte[] value)
	{
		if (value == null)
		{
			throw LogHelper.LogArgumentNullException("value");
		}
		using MemoryStream stream = new MemoryStream(value);
		using DeflateStream stream2 = new DeflateStream(stream, CompressionMode.Decompress);
		using StreamReader streamReader = new StreamReader(stream2, Encoding.UTF8);
		return Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
	}

	public byte[] Compress(byte[] value)
	{
		if (value == null)
		{
			throw LogHelper.LogArgumentNullException("value");
		}
		using MemoryStream memoryStream = new MemoryStream();
		using (DeflateStream stream = new DeflateStream(memoryStream, CompressionLevel))
		{
			using StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8);
			streamWriter.Write(Encoding.UTF8.GetString(value));
		}
		return memoryStream.ToArray();
	}

	public bool IsSupportedAlgorithm(string algorithm)
	{
		return Algorithm.Equals(algorithm, StringComparison.Ordinal);
	}
}
internal delegate ECDsa CreateECDsaDelegate(JsonWebKey jsonWebKey, bool usePrivateKey);
internal class ECDsaAdapter
{
	private enum KeyBlobMagicNumber : uint
	{
		BCRYPT_ECDSA_PUBLIC_P256_MAGIC = 827540293u,
		BCRYPT_ECDSA_PUBLIC_P384_MAGIC = 861094725u,
		BCRYPT_ECDSA_PUBLIC_P521_MAGIC = 894649157u,
		BCRYPT_ECDSA_PRIVATE_P256_MAGIC = 844317509u,
		BCRYPT_ECDSA_PRIVATE_P384_MAGIC = 877871941u,
		BCRYPT_ECDSA_PRIVATE_P521_MAGIC = 911426373u
	}

	internal readonly CreateECDsaDelegate CreateECDsaFunction;

	internal static ECDsaAdapter Instance;

	static ECDsaAdapter()
	{
		Instance = new ECDsaAdapter();
	}

	internal ECDsaAdapter()
	{
		if (SupportsECParameters())
		{
			CreateECDsaFunction = CreateECDsaUsingECParams;
		}
		else
		{
			CreateECDsaFunction = CreateECDsaUsingCNGKey;
		}
	}

	internal ECDsa CreateECDsa(JsonWebKey jsonWebKey, bool usePrivateKey)
	{
		if (CreateECDsaFunction != null)
		{
			return CreateECDsaFunction(jsonWebKey, usePrivateKey);
		}
		throw LogHelper.LogExceptionMessage(new PlatformNotSupportedException("IDX10690: ECDsa creation is not supported by NETSTANDARD1.4, when running on platforms other than Windows. For more details, see https://aka.ms/IdentityModel/create-ecdsa"));
	}

	private ECDsa CreateECDsaUsingCNGKey(JsonWebKey jsonWebKey, bool usePrivateKey)
	{
		if (jsonWebKey == null)
		{
			throw LogHelper.LogArgumentNullException("jsonWebKey");
		}
		if (jsonWebKey.Crv == null)
		{
			throw LogHelper.LogArgumentNullException("Crv");
		}
		if (jsonWebKey.X == null)
		{
			throw LogHelper.LogArgumentNullException("X");
		}
		if (jsonWebKey.Y == null)
		{
			throw LogHelper.LogArgumentNullException("Y");
		}
		GCHandle gCHandle = default(GCHandle);
		try
		{
			uint magicValue = GetMagicValue(jsonWebKey.Crv, usePrivateKey);
			uint keyByteCount = GetKeyByteCount(jsonWebKey.Crv);
			byte[] array = ((!usePrivateKey) ? new byte[2 * keyByteCount + 2 * Marshal.SizeOf<uint>()] : new byte[3 * keyByteCount + 2 * Marshal.SizeOf<uint>()]);
			gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			IntPtr intPtr = gCHandle.AddrOfPinnedObject();
			byte[] array2 = Base64UrlEncoder.DecodeBytes(jsonWebKey.X);
			if (array2.Length > keyByteCount)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("x.Length", LogHelper.FormatInvariant("IDX10675: The byte count of '{0}' must be less than or equal to '{1}', but was {2}.", "x", keyByteCount, array2.Length)));
			}
			byte[] array3 = Base64UrlEncoder.DecodeBytes(jsonWebKey.Y);
			if (array3.Length > keyByteCount)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("y.Length", LogHelper.FormatInvariant("IDX10675: The byte count of '{0}' must be less than or equal to '{1}', but was {2}.", "y", keyByteCount, array3.Length)));
			}
			Marshal.WriteInt64(intPtr, 0, magicValue);
			Marshal.WriteInt64(intPtr, 4, keyByteCount);
			int num = 8;
			byte[] array4 = array2;
			foreach (byte val in array4)
			{
				Marshal.WriteByte(intPtr, num++, val);
			}
			array4 = array3;
			foreach (byte val2 in array4)
			{
				Marshal.WriteByte(intPtr, num++, val2);
			}
			if (usePrivateKey)
			{
				if (jsonWebKey.D == null)
				{
					throw LogHelper.LogArgumentNullException("D");
				}
				byte[] array5 = Base64UrlEncoder.DecodeBytes(jsonWebKey.D);
				if (array5.Length > keyByteCount)
				{
					throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("d.Length", LogHelper.FormatInvariant("IDX10675: The byte count of '{0}' must be less than or equal to '{1}', but was {2}.", "d", keyByteCount, array5.Length)));
				}
				array4 = array5;
				foreach (byte val3 in array4)
				{
					Marshal.WriteByte(intPtr, num++, val3);
				}
				Marshal.Copy(intPtr, array, 0, array.Length);
				using CngKey key = CngKey.Import(array, CngKeyBlobFormat.EccPrivateBlob);
				return new ECDsaCng(key);
			}
			Marshal.Copy(intPtr, array, 0, array.Length);
			using CngKey key2 = CngKey.Import(array, CngKeyBlobFormat.EccPublicBlob);
			return new ECDsaCng(key2);
		}
		catch (Exception inner)
		{
			throw LogHelper.LogExceptionMessage(new CryptographicException("IDX10689: Unable to create an ECDsa object. See inner exception for more details.", inner));
		}
		finally
		{
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
		}
	}

	private uint GetKeyByteCount(string curveId)
	{
		if (string.IsNullOrEmpty(curveId))
		{
			throw LogHelper.LogArgumentNullException("curveId");
		}
		switch (curveId)
		{
		case "P-256":
			return 32u;
		case "P-384":
			return 48u;
		case "P-512":
		case "P-521":
			return 66u;
		default:
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10645: Elliptical Curve not supported for curveId: '{0}'", curveId)));
		}
	}

	private int GetKeySize(string curveId)
	{
		if (string.IsNullOrEmpty(curveId))
		{
			throw LogHelper.LogArgumentNullException("curveId");
		}
		switch (curveId)
		{
		case "P-256":
			return 256;
		case "P-384":
			return 384;
		case "P-512":
		case "P-521":
			return 521;
		default:
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10645: Elliptical Curve not supported for curveId: '{0}'", curveId)));
		}
	}

	private uint GetMagicValue(string curveId, bool willCreateSignatures)
	{
		if (string.IsNullOrEmpty(curveId))
		{
			throw LogHelper.LogArgumentNullException("curveId");
		}
		switch (curveId)
		{
		case "P-256":
			if (willCreateSignatures)
			{
				return 844317509u;
			}
			return 827540293u;
		case "P-384":
			if (willCreateSignatures)
			{
				return 877871941u;
			}
			return 861094725u;
		case "P-512":
		case "P-521":
			if (willCreateSignatures)
			{
				return 911426373u;
			}
			return 894649157u;
		default:
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10645: Elliptical Curve not supported for curveId: '{0}'", curveId)));
		}
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	private bool SupportsCNGKey()
	{
		try
		{
			_ = CngKeyBlobFormat.EccPrivateBlob;
			return true;
		}
		catch
		{
			return false;
		}
	}

	private ECDsa CreateECDsaUsingECParams(JsonWebKey jsonWebKey, bool usePrivateKey)
	{
		if (jsonWebKey == null)
		{
			throw LogHelper.LogArgumentNullException("jsonWebKey");
		}
		if (jsonWebKey.Crv == null)
		{
			throw LogHelper.LogArgumentNullException("Crv");
		}
		if (jsonWebKey.X == null)
		{
			throw LogHelper.LogArgumentNullException("X");
		}
		if (jsonWebKey.Y == null)
		{
			throw LogHelper.LogArgumentNullException("Y");
		}
		try
		{
			ECParameters parameters = new ECParameters
			{
				Curve = GetNamedECCurve(jsonWebKey.Crv),
				Q = 
				{
					X = Base64UrlEncoder.DecodeBytes(jsonWebKey.X),
					Y = Base64UrlEncoder.DecodeBytes(jsonWebKey.Y)
				}
			};
			if (usePrivateKey)
			{
				if (jsonWebKey.D == null)
				{
					throw LogHelper.LogArgumentNullException("D");
				}
				parameters.D = Base64UrlEncoder.DecodeBytes(jsonWebKey.D);
			}
			return ECDsa.Create(parameters);
		}
		catch (Exception inner)
		{
			throw LogHelper.LogExceptionMessage(new CryptographicException("IDX10689: Unable to create an ECDsa object. See inner exception for more details.", inner));
		}
	}

	private ECCurve GetNamedECCurve(string curveId)
	{
		if (string.IsNullOrEmpty(curveId))
		{
			throw LogHelper.LogArgumentNullException("curveId");
		}
		switch (curveId)
		{
		case "P-256":
			return ECCurve.NamedCurves.nistP256;
		case "P-384":
			return ECCurve.NamedCurves.nistP384;
		case "P-512":
		case "P-521":
			return ECCurve.NamedCurves.nistP521;
		default:
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10645: Elliptical Curve not supported for curveId: '{0}'", curveId)));
		}
	}

	private bool SupportsECParameters()
	{
		try
		{
			LoadECParametersType();
			return true;
		}
		catch
		{
			return false;
		}
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	private void LoadECParametersType()
	{
	}
}
public class ECDsaSecurityKey : AsymmetricSecurityKey
{
	private bool? _hasPrivateKey;

	public ECDsa ECDsa { get; private set; }

	[Obsolete("HasPrivateKey method is deprecated, please use PrivateKeyStatus.")]
	public override bool HasPrivateKey
	{
		get
		{
			if (!_hasPrivateKey.HasValue)
			{
				try
				{
					ECDsa.SignHash(new byte[20]);
					_hasPrivateKey = true;
				}
				catch (CryptographicException)
				{
					_hasPrivateKey = false;
				}
			}
			return _hasPrivateKey.Value;
		}
	}

	public override PrivateKeyStatus PrivateKeyStatus => PrivateKeyStatus.Unknown;

	public override int KeySize => ECDsa.KeySize;

	internal ECDsaSecurityKey(JsonWebKey webKey, bool usePrivateKey)
		: base(webKey)
	{
		ECDsa = ECDsaAdapter.Instance.CreateECDsa(webKey, usePrivateKey);
		webKey.ConvertedSecurityKey = this;
	}

	public ECDsaSecurityKey(ECDsa ecdsa)
	{
		ECDsa = ecdsa ?? throw LogHelper.LogArgumentNullException("ecdsa");
	}
}
public class EncryptingCredentials
{
	private string _alg;

	private string _enc;

	private SecurityKey _key;

	public string Alg
	{
		get
		{
			return _alg;
		}
		private set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw LogHelper.LogArgumentNullException("alg");
			}
			_alg = value;
		}
	}

	public string Enc
	{
		get
		{
			return _enc;
		}
		private set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw LogHelper.LogArgumentNullException("enc");
			}
			_enc = value;
		}
	}

	public CryptoProviderFactory CryptoProviderFactory { get; set; }

	public SecurityKey Key
	{
		get
		{
			return _key;
		}
		private set
		{
			_key = value ?? throw LogHelper.LogArgumentNullException("key");
		}
	}

	protected EncryptingCredentials(X509Certificate2 certificate, string alg, string enc)
	{
		if (certificate == null)
		{
			throw LogHelper.LogArgumentNullException("certificate");
		}
		Key = new X509SecurityKey(certificate);
		Alg = alg;
		Enc = enc;
	}

	public EncryptingCredentials(SecurityKey key, string alg, string enc)
	{
		Key = key;
		Alg = alg;
		Enc = enc;
	}

	public EncryptingCredentials(SymmetricSecurityKey key, string enc)
		: this(key, "none", enc)
	{
	}
}
public class AuthenticatedEncryptionProvider
{
	private struct AuthenticatedKeys
	{
		public SymmetricSecurityKey AesKey;

		public SymmetricSecurityKey HmacKey;
	}

	private AuthenticatedKeys _authenticatedkeys;

	private string _hmacAlgorithm;

	private SymmetricSignatureProvider _symmetricSignatureProvider;

	public string Algorithm { get; private set; }

	public string Context { get; set; }

	public SecurityKey Key { get; private set; }

	public AuthenticatedEncryptionProvider(SecurityKey key, string algorithm)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (string.IsNullOrWhiteSpace(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (!IsSupportedAlgorithm(key, algorithm))
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10668: Unable to create '{0}', algorithm '{1}'; key: '{2}' is not supported.", GetType(), algorithm, key)));
		}
		ValidateKeySize(key, algorithm);
		_authenticatedkeys = GetAlgorithmParameters(key, algorithm);
		_hmacAlgorithm = GetHmacAlgorithm(algorithm);
		_symmetricSignatureProvider = key.CryptoProviderFactory.CreateForSigning(_authenticatedkeys.HmacKey, _hmacAlgorithm) as SymmetricSignatureProvider;
		if (_symmetricSignatureProvider == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10649: Failed to create a SymmetricSignatureProvider for the algorithm '{0}'.", Algorithm)));
		}
		Key = key;
		Algorithm = algorithm;
	}

	public virtual AuthenticatedEncryptionResult Encrypt(byte[] plaintext, byte[] authenticatedData)
	{
		return Encrypt(plaintext, authenticatedData, null);
	}

	public virtual AuthenticatedEncryptionResult Encrypt(byte[] plaintext, byte[] authenticatedData, byte[] iv)
	{
		if (plaintext == null || plaintext.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("plaintext");
		}
		if (authenticatedData == null || authenticatedData.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("authenticatedData");
		}
		Aes aes = Aes.Create();
		aes.Mode = CipherMode.CBC;
		aes.Padding = PaddingMode.PKCS7;
		aes.Key = _authenticatedkeys.AesKey.Key;
		if (iv != null)
		{
			aes.IV = iv;
		}
		byte[] array;
		try
		{
			array = Transform(aes.CreateEncryptor(), plaintext, 0, plaintext.Length);
		}
		catch (Exception ex)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenEncryptionFailedException(LogHelper.FormatInvariant("IDX10654: Decryption failed. Cryptographic operation exception: '{0}'.", ex)));
		}
		byte[] array2 = Utility.ConvertToBigEndian(authenticatedData.Length * 8);
		byte[] array3 = new byte[authenticatedData.Length + aes.IV.Length + array.Length + array2.Length];
		Array.Copy(authenticatedData, 0, array3, 0, authenticatedData.Length);
		Array.Copy(aes.IV, 0, array3, authenticatedData.Length, aes.IV.Length);
		Array.Copy(array, 0, array3, authenticatedData.Length + aes.IV.Length, array.Length);
		Array.Copy(array2, 0, array3, authenticatedData.Length + aes.IV.Length + array.Length, array2.Length);
		byte[] sourceArray = _symmetricSignatureProvider.Sign(array3);
		byte[] array4 = new byte[_authenticatedkeys.HmacKey.Key.Length];
		Array.Copy(sourceArray, array4, array4.Length);
		return new AuthenticatedEncryptionResult(Key, array, aes.IV, array4);
	}

	public virtual byte[] Decrypt(byte[] ciphertext, byte[] authenticatedData, byte[] iv, byte[] authenticationTag)
	{
		if (ciphertext == null || ciphertext.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("ciphertext");
		}
		if (authenticatedData == null || authenticatedData.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("authenticatedData");
		}
		if (iv == null || iv.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("iv");
		}
		if (authenticationTag == null || authenticationTag.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("authenticationTag");
		}
		byte[] array = Utility.ConvertToBigEndian(authenticatedData.Length * 8);
		byte[] array2 = new byte[authenticatedData.Length + iv.Length + ciphertext.Length + array.Length];
		Array.Copy(authenticatedData, 0, array2, 0, authenticatedData.Length);
		Array.Copy(iv, 0, array2, authenticatedData.Length, iv.Length);
		Array.Copy(ciphertext, 0, array2, authenticatedData.Length + iv.Length, ciphertext.Length);
		Array.Copy(array, 0, array2, authenticatedData.Length + iv.Length + ciphertext.Length, array.Length);
		if (!_symmetricSignatureProvider.Verify(array2, authenticationTag, _authenticatedkeys.HmacKey.Key.Length))
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenDecryptionFailedException(LogHelper.FormatInvariant("IDX10650: Failed to verify ciphertext with aad '{0}'; iv '{1}'; and authenticationTag '{2}'.", Base64UrlEncoder.Encode(authenticatedData), Base64UrlEncoder.Encode(iv), Base64UrlEncoder.Encode(authenticationTag))));
		}
		Aes aes = Aes.Create();
		aes.Mode = CipherMode.CBC;
		aes.Padding = PaddingMode.PKCS7;
		aes.Key = _authenticatedkeys.AesKey.Key;
		aes.IV = iv;
		try
		{
			return Transform(aes.CreateDecryptor(), ciphertext, 0, ciphertext.Length);
		}
		catch (Exception ex)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenDecryptionFailedException(LogHelper.FormatInvariant("IDX10654: Decryption failed. Cryptographic operation exception: '{0}'.", ex)));
		}
	}

	protected virtual bool IsSupportedAlgorithm(SecurityKey key, string algorithm)
	{
		return SupportedAlgorithms.IsSupportedAuthenticatedEncryptionAlgorithm(algorithm, key);
	}

	private AuthenticatedKeys GetAlgorithmParameters(SecurityKey key, string algorithm)
	{
		int num = -1;
		if (algorithm.Equals("A256CBC-HS512", StringComparison.Ordinal))
		{
			num = 32;
		}
		else if (algorithm.Equals("A192CBC-HS384", StringComparison.Ordinal))
		{
			num = 24;
		}
		else
		{
			if (!algorithm.Equals("A128CBC-HS256", StringComparison.Ordinal))
			{
				throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10668: Unable to create '{0}', algorithm '{1}'; key: '{2}' is not supported.", GetType(), algorithm, key)));
			}
			num = 16;
		}
		byte[] keyBytes = GetKeyBytes(key);
		byte[] array = new byte[num];
		byte[] array2 = new byte[num];
		Array.Copy(keyBytes, num, array, 0, num);
		Array.Copy(keyBytes, array2, num);
		return new AuthenticatedKeys
		{
			AesKey = new SymmetricSecurityKey(array),
			HmacKey = new SymmetricSecurityKey(array2)
		};
	}

	private static string GetHmacAlgorithm(string algorithm)
	{
		if ("A128CBC-HS256".Equals(algorithm, StringComparison.Ordinal))
		{
			return "HS256";
		}
		if ("A192CBC-HS384".Equals(algorithm, StringComparison.Ordinal))
		{
			return "HS384";
		}
		if ("A256CBC-HS512".Equals(algorithm, StringComparison.Ordinal))
		{
			return "HS512";
		}
		throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10652: The algorithm '{0}' is not supported.", algorithm), "algorithm"));
	}

	protected virtual byte[] GetKeyBytes(SecurityKey key)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (key is SymmetricSecurityKey symmetricSecurityKey)
		{
			return symmetricSecurityKey.Key;
		}
		if (key is JsonWebKey { K: not null, Kty: "oct" } jsonWebKey)
		{
			return Base64UrlEncoder.DecodeBytes(jsonWebKey.K);
		}
		throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10667: Unable to obtain required byte array for KeyHashAlgorithm from SecurityKey: '{0}'.", key)));
	}

	internal static byte[] Transform(ICryptoTransform transform, byte[] input, int inputOffset, int inputLength)
	{
		if (transform.CanTransformMultipleBlocks)
		{
			return transform.TransformFinalBlock(input, inputOffset, inputLength);
		}
		using MemoryStream memoryStream = new MemoryStream();
		using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		cryptoStream.Write(input, inputOffset, inputLength);
		cryptoStream.FlushFinalBlock();
		return memoryStream.ToArray();
	}

	protected virtual void ValidateKeySize(SecurityKey key, string algorithm)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if ("A128CBC-HS256".Equals(algorithm, StringComparison.Ordinal))
		{
			if (key.KeySize < 256)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("key.KeySize", LogHelper.FormatInvariant("IDX10653: The encryption algorithm '{0}' requires a key size of at least '{1}' bits. Key '{2}', is of size: '{3}'.", "A128CBC-HS256", 256, key.KeyId, key.KeySize)));
			}
			return;
		}
		if ("A192CBC-HS384".Equals(algorithm, StringComparison.Ordinal))
		{
			if (key.KeySize >= 384)
			{
				return;
			}
			throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("key.KeySize", LogHelper.FormatInvariant("IDX10653: The encryption algorithm '{0}' requires a key size of at least '{1}' bits. Key '{2}', is of size: '{3}'.", "A192CBC-HS384", 384, key.KeyId, key.KeySize)));
		}
		if ("A256CBC-HS512".Equals(algorithm, StringComparison.Ordinal))
		{
			if (key.KeySize >= 512)
			{
				return;
			}
			throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("key.KeySize", LogHelper.FormatInvariant("IDX10653: The encryption algorithm '{0}' requires a key size of at least '{1}' bits. Key '{2}', is of size: '{3}'.", "A256CBC-HS512", 512, key.KeyId, key.KeySize)));
		}
		throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10652: The algorithm '{0}' is not supported.", algorithm)));
	}
}
public class AuthenticatedEncryptionResult
{
	public SecurityKey Key { get; private set; }

	public byte[] Ciphertext { get; private set; }

	public byte[] IV { get; private set; }

	public byte[] AuthenticationTag { get; private set; }

	public AuthenticatedEncryptionResult(SecurityKey key, byte[] ciphertext, byte[] iv, byte[] authenticationTag)
	{
		Key = key;
		Ciphertext = ciphertext;
		IV = iv;
		AuthenticationTag = authenticationTag;
	}
}
public abstract class KeyWrapProvider : IDisposable
{
	public abstract string Algorithm { get; }

	public abstract string Context { get; set; }

	public abstract SecurityKey Key { get; }

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected abstract void Dispose(bool disposing);

	public abstract byte[] UnwrapKey(byte[] keyBytes);

	public abstract byte[] WrapKey(byte[] keyBytes);
}
public class RsaKeyWrapProvider : KeyWrapProvider
{
	private AsymmetricAdapter _asymmetricAdapter;

	private bool _disposed;

	public override string Algorithm { get; }

	public override string Context { get; set; }

	public override SecurityKey Key { get; }

	public RsaKeyWrapProvider(SecurityKey key, string algorithm, bool willUnwrap)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (!IsSupportedAlgorithm(key, algorithm))
		{
			throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10661: Unable to create the KeyWrapProvider.\nKeyWrapAlgorithm: '{0}', SecurityKey: '{1}'\n is not supported.", algorithm, key)));
		}
		Algorithm = algorithm;
		Key = key;
		_asymmetricAdapter = new AsymmetricAdapter(key, algorithm, willUnwrap);
	}

	protected override void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_asymmetricAdapter.Dispose();
		}
	}

	protected virtual bool IsSupportedAlgorithm(SecurityKey key, string algorithm)
	{
		if (key == null)
		{
			return false;
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			return false;
		}
		if (key.KeySize < 2048)
		{
			return false;
		}
		return SupportedAlgorithms.IsSupportedKeyWrapAlgorithm(algorithm, key);
	}

	public override byte[] UnwrapKey(byte[] keyBytes)
	{
		if (keyBytes == null || keyBytes.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("keyBytes");
		}
		if (_disposed)
		{
			throw LogHelper.LogExceptionMessage(new ObjectDisposedException(GetType().ToString()));
		}
		try
		{
			return _asymmetricAdapter.Decrypt(keyBytes);
		}
		catch (Exception ex)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenKeyWrapException(LogHelper.FormatInvariant("IDX10659: UnwrapKey failed, exception from cryptographic operation: '{0}'", ex)));
		}
	}

	public override byte[] WrapKey(byte[] keyBytes)
	{
		if (keyBytes == null || keyBytes.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("keyBytes");
		}
		if (_disposed)
		{
			throw LogHelper.LogExceptionMessage(new ObjectDisposedException(GetType().ToString()));
		}
		try
		{
			return _asymmetricAdapter.Encrypt(keyBytes);
		}
		catch (Exception ex)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenKeyWrapException(LogHelper.FormatInvariant("IDX10658: WrapKey failed, exception from cryptographic operation: '{0}'", ex)));
		}
	}
}
public class SymmetricKeyWrapProvider : KeyWrapProvider
{
	private static readonly byte[] _defaultIV = new byte[8] { 166, 166, 166, 166, 166, 166, 166, 166 };

	private static readonly int _blockSizeInBits = 64;

	private static readonly int _blockSizeInBytes = _blockSizeInBits >> 3;

	private static object _encryptorLock = new object();

	private static object _decryptorLock = new object();

	private SymmetricAlgorithm _symmetricAlgorithm;

	private ICryptoTransform _symmetricAlgorithmEncryptor;

	private ICryptoTransform _symmetricAlgorithmDecryptor;

	private bool _disposed;

	public override string Algorithm { get; }

	public override string Context { get; set; }

	public override SecurityKey Key { get; }

	public SymmetricKeyWrapProvider(SecurityKey key, string algorithm)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (!IsSupportedAlgorithm(key, algorithm))
		{
			throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10661: Unable to create the KeyWrapProvider.\nKeyWrapAlgorithm: '{0}', SecurityKey: '{1}'\n is not supported.", algorithm, key)));
		}
		Algorithm = algorithm;
		Key = key;
		_symmetricAlgorithm = GetSymmetricAlgorithm(key, algorithm);
		if (_symmetricAlgorithm == null)
		{
			throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10669: Failed to create symmetric algorithm.")));
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			if (_symmetricAlgorithm != null)
			{
				_symmetricAlgorithm.Dispose();
				_symmetricAlgorithm = null;
			}
			_disposed = true;
		}
	}

	private static byte[] GetBytes(ulong i)
	{
		byte[] bytes = BitConverter.GetBytes(i);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse((Array)bytes);
		}
		return bytes;
	}

	protected virtual SymmetricAlgorithm GetSymmetricAlgorithm(SecurityKey key, string algorithm)
	{
		byte[] array = null;
		if (key is SymmetricSecurityKey symmetricSecurityKey)
		{
			array = symmetricSecurityKey.Key;
		}
		else if (key is JsonWebKey { K: not null, Kty: "oct" } jsonWebKey)
		{
			array = Base64UrlEncoder.DecodeBytes(jsonWebKey.K);
		}
		if (array == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10657: The SecurityKey provided for the symmetric key wrap algorithm cannot be converted to byte array. Type is: '{0}'.", key.GetType())));
		}
		ValidateKeySize(array, algorithm);
		try
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.ECB;
			aes.Padding = PaddingMode.None;
			aes.KeySize = array.Length * 8;
			aes.Key = array;
			byte[] array2 = new byte[aes.BlockSize >> 3];
			Utility.Zero(array2);
			aes.IV = array2;
			return aes;
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10663: Failed to create symmetric algorithm with SecurityKey: '{0}', KeyWrapAlgorithm: '{1}'.", key, algorithm), innerException));
		}
	}

	protected virtual bool IsSupportedAlgorithm(SecurityKey key, string algorithm)
	{
		if (key == null)
		{
			return false;
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			return false;
		}
		if (algorithm.Equals("A128KW", StringComparison.Ordinal) || algorithm.Equals("A256KW", StringComparison.Ordinal))
		{
			if (key is SymmetricSecurityKey)
			{
				return true;
			}
			if (key is JsonWebKey { K: not null, Kty: "oct" })
			{
				return true;
			}
		}
		return false;
	}

	public override byte[] UnwrapKey(byte[] keyBytes)
	{
		if (keyBytes == null || keyBytes.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("keyBytes");
		}
		if (keyBytes.Length % 8 != 0)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10664: The length of input must be a multiple of 64 bits. The input size is: '{0}' bits.", keyBytes.Length << 3), "keyBytes"));
		}
		if (_disposed)
		{
			throw LogHelper.LogExceptionMessage(new ObjectDisposedException(GetType().ToString()));
		}
		try
		{
			return UnwrapKeyPrivate(keyBytes, 0, keyBytes.Length);
		}
		catch (Exception ex)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenKeyWrapException(LogHelper.FormatInvariant("IDX10659: UnwrapKey failed, exception from cryptographic operation: '{0}'", ex)));
		}
	}

	private byte[] UnwrapKeyPrivate(byte[] inputBuffer, int inputOffset, int inputCount)
	{
		byte[] array = new byte[_blockSizeInBytes];
		Array.Copy(inputBuffer, inputOffset, array, 0, _blockSizeInBytes);
		int num = inputCount - _blockSizeInBytes >> 3;
		byte[] array2 = new byte[num << 3];
		Array.Copy(inputBuffer, inputOffset + _blockSizeInBytes, array2, 0, inputCount - _blockSizeInBytes);
		if (_symmetricAlgorithmDecryptor == null)
		{
			lock (_decryptorLock)
			{
				if (_symmetricAlgorithmDecryptor == null)
				{
					_symmetricAlgorithmDecryptor = _symmetricAlgorithm.CreateDecryptor();
				}
			}
		}
		byte[] array3 = new byte[16];
		for (int num2 = 5; num2 >= 0; num2--)
		{
			for (int num3 = num; num3 > 0; num3--)
			{
				ulong i = (ulong)(num * num2 + num3);
				Utility.Xor(array, GetBytes(i), 0, inPlace: true);
				Array.Copy(array, array3, _blockSizeInBytes);
				Array.Copy(array2, num3 - 1 << 3, array3, _blockSizeInBytes, _blockSizeInBytes);
				byte[] sourceArray = _symmetricAlgorithmDecryptor.TransformFinalBlock(array3, 0, 16);
				Array.Copy(sourceArray, array, _blockSizeInBytes);
				Array.Copy(sourceArray, _blockSizeInBytes, array2, num3 - 1 << 3, _blockSizeInBytes);
			}
		}
		if (Utility.AreEqual(array, _defaultIV))
		{
			byte[] array4 = new byte[num << 3];
			for (int j = 0; j < num; j++)
			{
				Array.Copy(array2, j << 3, array4, j << 3, 8);
			}
			return array4;
		}
		throw LogHelper.LogExceptionMessage(new InvalidOperationException("IDX10665: Data is not authentic"));
	}

	private void ValidateKeySize(byte[] key, string algorithm)
	{
		if ("A128KW".Equals(algorithm, StringComparison.Ordinal))
		{
			if (key.Length != 16)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("Length", LogHelper.FormatInvariant("IDX10662: The KeyWrap algorithm '{0}' requires a key size of '{1}' bits. Key '{2}', is of size:'{3}'.", "A128KW", 128, Key.KeyId, key.Length << 3)));
			}
			return;
		}
		if ("A256KW".Equals(algorithm, StringComparison.Ordinal))
		{
			if (key.Length != 32)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("Length", LogHelper.FormatInvariant("IDX10662: The KeyWrap algorithm '{0}' requires a key size of '{1}' bits. Key '{2}', is of size:'{3}'.", "A256KW", 256, Key.KeyId, key.Length << 3)));
			}
			return;
		}
		throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("algorithm", LogHelper.FormatInvariant("IDX10652: The algorithm '{0}' is not supported.", algorithm)));
	}

	public override byte[] WrapKey(byte[] keyBytes)
	{
		if (keyBytes == null || keyBytes.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("keyBytes");
		}
		if (keyBytes.Length % 8 != 0)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10664: The length of input must be a multiple of 64 bits. The input size is: '{0}' bits.", keyBytes.Length << 3), "keyBytes"));
		}
		if (_disposed)
		{
			throw LogHelper.LogExceptionMessage(new ObjectDisposedException(GetType().ToString()));
		}
		try
		{
			return WrapKeyPrivate(keyBytes, 0, keyBytes.Length);
		}
		catch (Exception ex)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenKeyWrapException(LogHelper.FormatInvariant("IDX10658: WrapKey failed, exception from cryptographic operation: '{0}'", ex)));
		}
	}

	private byte[] WrapKeyPrivate(byte[] inputBuffer, int inputOffset, int inputCount)
	{
		byte[] array = _defaultIV.Clone() as byte[];
		int num = inputCount >> 3;
		byte[] array2 = new byte[num << 3];
		Array.Copy(inputBuffer, inputOffset, array2, 0, inputCount);
		if (_symmetricAlgorithmEncryptor == null)
		{
			lock (_encryptorLock)
			{
				if (_symmetricAlgorithmEncryptor == null)
				{
					_symmetricAlgorithmEncryptor = _symmetricAlgorithm.CreateEncryptor();
				}
			}
		}
		byte[] array3 = new byte[16];
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < num; j++)
			{
				ulong i2 = (ulong)(num * i + j + 1);
				Array.Copy(array, array3, array.Length);
				Array.Copy(array2, j << 3, array3, 8, 8);
				byte[] sourceArray = _symmetricAlgorithmEncryptor.TransformFinalBlock(array3, 0, 16);
				Array.Copy(sourceArray, array, 8);
				Utility.Xor(array, GetBytes(i2), 0, inPlace: true);
				Array.Copy(sourceArray, 8, array2, j << 3, 8);
			}
		}
		byte[] array4 = new byte[num + 1 << 3];
		Array.Copy(array, array4, array.Length);
		for (int k = 0; k < num; k++)
		{
			Array.Copy(array2, k << 3, array4, k + 1 << 3, 8);
		}
		return array4;
	}
}
public static class EpochTime
{
	public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

	public static long GetIntDate(DateTime datetime)
	{
		DateTime dateTime = datetime;
		if (datetime.Kind != DateTimeKind.Utc)
		{
			dateTime = datetime.ToUniversalTime();
		}
		if (dateTime.ToUniversalTime() <= UnixEpoch)
		{
			return 0L;
		}
		return (long)(dateTime - UnixEpoch).TotalSeconds;
	}

	public static DateTime DateTime(long secondsSinceUnixEpoch)
	{
		if (secondsSinceUnixEpoch <= 0)
		{
			return UnixEpoch;
		}
		double num = secondsSinceUnixEpoch;
		TimeSpan maxValue = TimeSpan.MaxValue;
		if (num > maxValue.TotalSeconds)
		{
			return DateTimeUtil.Add(UnixEpoch, TimeSpan.MaxValue).ToUniversalTime();
		}
		return DateTimeUtil.Add(UnixEpoch, TimeSpan.FromSeconds(secondsSinceUnixEpoch)).ToUniversalTime();
	}
}
public class SecurityTokenCompressionFailedException : SecurityTokenException
{
	public SecurityTokenCompressionFailedException()
		: base("SecurityToken compression failed.")
	{
	}

	public SecurityTokenCompressionFailedException(string message)
		: base(message)
	{
	}

	public SecurityTokenCompressionFailedException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public class SecurityTokenDecompressionFailedException : SecurityTokenException
{
	public SecurityTokenDecompressionFailedException()
		: base("SecurityToken decompression failed.")
	{
	}

	public SecurityTokenDecompressionFailedException(string message)
		: base(message)
	{
	}

	public SecurityTokenDecompressionFailedException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public class SecurityTokenDecryptionFailedException : SecurityTokenException
{
	public SecurityTokenDecryptionFailedException()
	{
	}

	public SecurityTokenDecryptionFailedException(string message)
		: base(message)
	{
	}

	public SecurityTokenDecryptionFailedException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenEncryptionFailedException : SecurityTokenException
{
	public SecurityTokenEncryptionFailedException()
	{
	}

	public SecurityTokenEncryptionFailedException(string message)
		: base(message)
	{
	}

	public SecurityTokenEncryptionFailedException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenEncryptionKeyNotFoundException : SecurityTokenDecryptionFailedException
{
	public SecurityTokenEncryptionKeyNotFoundException()
	{
	}

	public SecurityTokenEncryptionKeyNotFoundException(string message)
		: base(message)
	{
	}

	public SecurityTokenEncryptionKeyNotFoundException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenException : Exception
{
	public SecurityTokenException()
	{
	}

	public SecurityTokenException(string message)
		: base(message)
	{
	}

	public SecurityTokenException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenExpiredException : SecurityTokenValidationException
{
	public DateTime Expires { get; set; }

	public SecurityTokenExpiredException()
		: base("SecurityToken has Expired")
	{
	}

	public SecurityTokenExpiredException(string message)
		: base(message)
	{
	}

	public SecurityTokenExpiredException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public class SecurityTokenInvalidAudienceException : SecurityTokenValidationException
{
	public string InvalidAudience { get; set; }

	public SecurityTokenInvalidAudienceException()
	{
	}

	public SecurityTokenInvalidAudienceException(string message)
		: base(message)
	{
	}

	public SecurityTokenInvalidAudienceException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenInvalidIssuerException : SecurityTokenValidationException
{
	public string InvalidIssuer { get; set; }

	public SecurityTokenInvalidIssuerException()
	{
	}

	public SecurityTokenInvalidIssuerException(string message)
		: base(message)
	{
	}

	public SecurityTokenInvalidIssuerException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenInvalidLifetimeException : SecurityTokenValidationException
{
	public DateTime? NotBefore { get; set; }

	public DateTime? Expires { get; set; }

	public SecurityTokenInvalidLifetimeException()
	{
	}

	public SecurityTokenInvalidLifetimeException(string message)
		: base(message)
	{
	}

	public SecurityTokenInvalidLifetimeException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenInvalidSignatureException : SecurityTokenValidationException
{
	public SecurityTokenInvalidSignatureException()
	{
	}

	public SecurityTokenInvalidSignatureException(string message)
		: base(message)
	{
	}

	public SecurityTokenInvalidSignatureException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenInvalidSigningKeyException : SecurityTokenValidationException
{
	public SecurityKey SigningKey { get; set; }

	public SecurityTokenInvalidSigningKeyException()
		: base("SecurityToken has invalid issuer signing key.")
	{
	}

	public SecurityTokenInvalidSigningKeyException(string message)
		: base(message)
	{
	}

	public SecurityTokenInvalidSigningKeyException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public class SecurityTokenInvalidTypeException : SecurityTokenValidationException
{
	public string InvalidType { get; set; }

	public SecurityTokenInvalidTypeException()
	{
	}

	public SecurityTokenInvalidTypeException(string message)
		: base(message)
	{
	}

	public SecurityTokenInvalidTypeException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenKeyWrapException : SecurityTokenException
{
	public SecurityTokenKeyWrapException()
	{
	}

	public SecurityTokenKeyWrapException(string message)
		: base(message)
	{
	}

	public SecurityTokenKeyWrapException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenNoExpirationException : SecurityTokenValidationException
{
	public SecurityTokenNoExpirationException()
	{
	}

	public SecurityTokenNoExpirationException(string message)
		: base(message)
	{
	}

	public SecurityTokenNoExpirationException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenNotYetValidException : SecurityTokenValidationException
{
	public DateTime NotBefore { get; set; }

	public SecurityTokenNotYetValidException()
		: base("SecurityToken is not yet valid")
	{
	}

	public SecurityTokenNotYetValidException(string message)
		: base(message)
	{
	}

	public SecurityTokenNotYetValidException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public class SecurityTokenReplayAddFailedException : SecurityTokenValidationException
{
	public SecurityTokenReplayAddFailedException()
	{
	}

	public SecurityTokenReplayAddFailedException(string message)
		: base(message)
	{
	}

	public SecurityTokenReplayAddFailedException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenReplayDetectedException : SecurityTokenValidationException
{
	public SecurityTokenReplayDetectedException()
		: base("SecurityToken replay detected")
	{
	}

	public SecurityTokenReplayDetectedException(string message)
		: base(message)
	{
	}

	public SecurityTokenReplayDetectedException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public class SecurityTokenSignatureKeyNotFoundException : SecurityTokenInvalidSignatureException
{
	public SecurityTokenSignatureKeyNotFoundException()
	{
	}

	public SecurityTokenSignatureKeyNotFoundException(string message)
		: base(message)
	{
	}

	public SecurityTokenSignatureKeyNotFoundException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public class SecurityTokenValidationException : SecurityTokenException
{
	public SecurityTokenValidationException()
	{
	}

	public SecurityTokenValidationException(string message)
		: base(message)
	{
	}

	public SecurityTokenValidationException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
public interface ICompressionProvider
{
	string Algorithm { get; }

	bool IsSupportedAlgorithm(string algorithm);

	byte[] Decompress(byte[] value);

	byte[] Compress(byte[] value);
}
public interface ICryptoProvider
{
	bool IsSupportedAlgorithm(string algorithm, params object[] args);

	object Create(string algorithm, params object[] args);

	void Release(object cryptoInstance);
}
public class InMemoryCryptoProviderCache : CryptoProviderCache
{
	private ConcurrentDictionary<string, SignatureProvider> _signingSignatureProviders = new ConcurrentDictionary<string, SignatureProvider>();

	private ConcurrentDictionary<string, SignatureProvider> _verifyingSignatureProviders = new ConcurrentDictionary<string, SignatureProvider>();

	protected override string GetCacheKey(SignatureProvider signatureProvider)
	{
		if (signatureProvider == null)
		{
			throw LogHelper.LogArgumentNullException("signatureProvider");
		}
		return GetCacheKeyPrivate(signatureProvider.Key, signatureProvider.Algorithm, signatureProvider.GetType().ToString());
	}

	protected override string GetCacheKey(SecurityKey securityKey, string algorithm, string typeofProvider)
	{
		if (securityKey == null)
		{
			throw LogHelper.LogArgumentNullException("securityKey");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (string.IsNullOrEmpty(typeofProvider))
		{
			throw LogHelper.LogArgumentNullException("typeofProvider");
		}
		return GetCacheKeyPrivate(securityKey, algorithm, typeofProvider);
	}

	private string GetCacheKeyPrivate(SecurityKey securityKey, string algorithm, string typeofProvider)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0}-{1}-{2}-{3}", securityKey.GetType(), string.IsNullOrEmpty(securityKey.KeyId) ? securityKey.InternalId : securityKey.KeyId, algorithm, typeofProvider);
	}

	public override bool TryAdd(SignatureProvider signatureProvider)
	{
		if (signatureProvider == null)
		{
			throw LogHelper.LogArgumentNullException("signatureProvider");
		}
		string cacheKey = GetCacheKey(signatureProvider);
		if (signatureProvider.WillCreateSignatures)
		{
			if (_signingSignatureProviders.TryAdd(cacheKey, signatureProvider))
			{
				signatureProvider.CryptoProviderCache = this;
				return true;
			}
		}
		else if (_verifyingSignatureProviders.TryAdd(cacheKey, signatureProvider))
		{
			signatureProvider.CryptoProviderCache = this;
			return true;
		}
		return false;
	}

	public override bool TryGetSignatureProvider(SecurityKey securityKey, string algorithm, string typeofProvider, bool willCreateSignatures, out SignatureProvider signatureProvider)
	{
		if (securityKey == null)
		{
			throw LogHelper.LogArgumentNullException("securityKey");
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		if (string.IsNullOrEmpty(typeofProvider))
		{
			throw LogHelper.LogArgumentNullException("typeofProvider");
		}
		string cacheKeyPrivate = GetCacheKeyPrivate(securityKey, algorithm, typeofProvider);
		if (willCreateSignatures)
		{
			return _signingSignatureProviders.TryGetValue(cacheKeyPrivate, out signatureProvider);
		}
		return _verifyingSignatureProviders.TryGetValue(cacheKeyPrivate, out signatureProvider);
	}

	public override bool TryRemove(SignatureProvider signatureProvider)
	{
		if (signatureProvider == null)
		{
			throw LogHelper.LogArgumentNullException("signatureProvider");
		}
		if (signatureProvider.CryptoProviderCache != this)
		{
			return false;
		}
		string cacheKey = GetCacheKey(signatureProvider);
		SignatureProvider value2;
		if (signatureProvider.WillCreateSignatures)
		{
			if (_signingSignatureProviders.TryRemove(cacheKey, out var value))
			{
				value.CryptoProviderCache = null;
				return true;
			}
		}
		else if (_verifyingSignatureProviders.TryRemove(cacheKey, out value2))
		{
			value2.CryptoProviderCache = null;
			return true;
		}
		return false;
	}
}
public interface ISecurityTokenValidator
{
	bool CanValidateToken { get; }

	int MaximumTokenSizeInBytes { get; set; }

	bool CanReadToken(string securityToken);

	ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken);
}
public interface ITokenReplayCache
{
	bool TryAdd(string securityToken, DateTime expiresOn);

	bool TryFind(string securityToken);
}
public static class JsonWebAlgorithmsKeyTypes
{
	public const string EllipticCurve = "EC";

	public const string RSA = "RSA";

	public const string Octet = "oct";
}
[JsonObject]
public class JsonWebKey : SecurityKey
{
	private string _kid;

	[JsonIgnore]
	internal SecurityKey ConvertedSecurityKey { get; set; }

	[JsonExtensionData]
	public virtual IDictionary<string, object> AdditionalData { get; } = new Dictionary<string, object>();

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

	[JsonIgnore]
	public override string KeyId
	{
		get
		{
			return _kid;
		}
		set
		{
			_kid = value;
		}
	}

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "key_ops", Required = Required.Default)]
	public IList<string> KeyOps { get; private set; } = new List<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "kid", Required = Required.Default)]
	public string Kid
	{
		get
		{
			return _kid;
		}
		set
		{
			_kid = value;
		}
	}

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
	public IList<string> X5c { get; private set; } = new List<string>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "x5t", Required = Required.Default)]
	public string X5t { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "x5t#S256", Required = Required.Default)]
	public string X5tS256 { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "x5u", Required = Required.Default)]
	public string X5u { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "y", Required = Required.Default)]
	public string Y { get; set; }

	[JsonIgnore]
	public override int KeySize
	{
		get
		{
			if (Kty == "RSA" && !string.IsNullOrEmpty(N))
			{
				return Base64UrlEncoder.DecodeBytes(N).Length * 8;
			}
			if (Kty == "EC" && !string.IsNullOrEmpty(X))
			{
				return Base64UrlEncoder.DecodeBytes(X).Length * 8;
			}
			if (Kty == "oct" && !string.IsNullOrEmpty(K))
			{
				return Base64UrlEncoder.DecodeBytes(K).Length * 8;
			}
			return 0;
		}
	}

	[JsonIgnore]
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

	public static JsonWebKey Create(string json)
	{
		if (string.IsNullOrEmpty(json))
		{
			throw LogHelper.LogArgumentNullException("json");
		}
		return new JsonWebKey(json);
	}

	public JsonWebKey()
	{
	}

	public JsonWebKey(string json)
	{
		if (string.IsNullOrEmpty(json))
		{
			throw LogHelper.LogArgumentNullException("json");
		}
		try
		{
			LogHelper.LogVerbose("IDX10806: Deserializing json: '{0}' into '{1}'.", json, this);
			JsonConvert.PopulateObject(json, this);
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10805: Error deserializing json: '{0}' into '{1}'.", json, GetType()), innerException));
		}
	}

	public bool ShouldSerializeKeyOps()
	{
		return KeyOps.Count > 0;
	}

	public bool ShouldSerializeX5c()
	{
		return X5c.Count > 0;
	}

	internal RSAParameters CreateRsaParameters()
	{
		if (string.IsNullOrEmpty(N))
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10700: {0} is unable to use 'rsaParameters'. {1} is null.", this, "Modulus")));
		}
		if (string.IsNullOrEmpty(E))
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10700: {0} is unable to use 'rsaParameters'. {1} is null.", this), "Exponent"));
		}
		return new RSAParameters
		{
			Modulus = Base64UrlEncoder.DecodeBytes(N),
			Exponent = Base64UrlEncoder.DecodeBytes(E),
			D = (string.IsNullOrEmpty(D) ? null : Base64UrlEncoder.DecodeBytes(D)),
			P = (string.IsNullOrEmpty(P) ? null : Base64UrlEncoder.DecodeBytes(P)),
			Q = (string.IsNullOrEmpty(Q) ? null : Base64UrlEncoder.DecodeBytes(Q)),
			DP = (string.IsNullOrEmpty(DP) ? null : Base64UrlEncoder.DecodeBytes(DP)),
			DQ = (string.IsNullOrEmpty(DQ) ? null : Base64UrlEncoder.DecodeBytes(DQ)),
			InverseQ = (string.IsNullOrEmpty(QI) ? null : Base64UrlEncoder.DecodeBytes(QI))
		};
	}

	public override string ToString()
	{
		return $"{GetType()}, Use: '{Use}',  Kid: '{Kid}', Kty: '{Kty}', InternalId: '{base.InternalId}'.";
	}
}
public class JsonWebKeyConverter
{
	public static JsonWebKey ConvertFromSecurityKey(SecurityKey key)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (key is RsaSecurityKey key2)
		{
			return ConvertFromRSASecurityKey(key2);
		}
		if (key is SymmetricSecurityKey key3)
		{
			return ConvertFromSymmetricSecurityKey(key3);
		}
		if (key is X509SecurityKey key4)
		{
			return ConvertFromX509SecurityKey(key4);
		}
		throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10674: JsonWebKeyConverter does not support SecurityKey of type: {0}", key.GetType().FullName)));
	}

	public static JsonWebKey ConvertFromRSASecurityKey(RsaSecurityKey key)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		RSAParameters rSAParameters;
		if (key.Rsa != null)
		{
			try
			{
				rSAParameters = key.Rsa.ExportParameters(includePrivateParameters: true);
			}
			catch
			{
				rSAParameters = key.Rsa.ExportParameters(includePrivateParameters: false);
			}
		}
		else
		{
			rSAParameters = key.Parameters;
		}
		return new JsonWebKey
		{
			N = ((rSAParameters.Modulus != null) ? Base64UrlEncoder.Encode(rSAParameters.Modulus) : null),
			E = ((rSAParameters.Exponent != null) ? Base64UrlEncoder.Encode(rSAParameters.Exponent) : null),
			D = ((rSAParameters.D != null) ? Base64UrlEncoder.Encode(rSAParameters.D) : null),
			P = ((rSAParameters.P != null) ? Base64UrlEncoder.Encode(rSAParameters.P) : null),
			Q = ((rSAParameters.Q != null) ? Base64UrlEncoder.Encode(rSAParameters.Q) : null),
			DP = ((rSAParameters.DP != null) ? Base64UrlEncoder.Encode(rSAParameters.DP) : null),
			DQ = ((rSAParameters.DQ != null) ? Base64UrlEncoder.Encode(rSAParameters.DQ) : null),
			QI = ((rSAParameters.InverseQ != null) ? Base64UrlEncoder.Encode(rSAParameters.InverseQ) : null),
			Kty = "RSA",
			Kid = key.KeyId,
			ConvertedSecurityKey = key
		};
	}

	public static JsonWebKey ConvertFromX509SecurityKey(X509SecurityKey key)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		JsonWebKey jsonWebKey = new JsonWebKey
		{
			Kty = "RSA",
			Kid = key.KeyId,
			X5t = key.X5t,
			ConvertedSecurityKey = key
		};
		if (key.Certificate.RawData != null)
		{
			jsonWebKey.X5c.Add(Convert.ToBase64String(key.Certificate.RawData));
		}
		return jsonWebKey;
	}

	public static JsonWebKey ConvertFromSymmetricSecurityKey(SymmetricSecurityKey key)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		return new JsonWebKey
		{
			K = Base64UrlEncoder.Encode(key.Key),
			Kid = key.KeyId,
			Kty = "oct",
			ConvertedSecurityKey = key
		};
	}

	internal static bool TryConvertToSecurityKey(JsonWebKey webKey, out SecurityKey key)
	{
		if (webKey.ConvertedSecurityKey != null)
		{
			key = webKey.ConvertedSecurityKey;
			return true;
		}
		key = null;
		try
		{
			if ("RSA".Equals(webKey.Kty, StringComparison.Ordinal))
			{
				if (TryConvertToX509SecurityKey(webKey, out key))
				{
					return true;
				}
				if (TryCreateToRsaSecurityKey(webKey, out key))
				{
					return true;
				}
			}
			else
			{
				if ("EC".Equals(webKey.Kty, StringComparison.Ordinal))
				{
					return TryConvertToECDsaSecurityKey(webKey, out key);
				}
				if ("oct".Equals(webKey.Kty, StringComparison.Ordinal))
				{
					return TryConvertToSymmetricSecurityKey(webKey, out key);
				}
			}
		}
		catch (Exception ex)
		{
			LogHelper.LogWarning(LogHelper.FormatInvariant("IDX10813: Unable to create a {0} from the properties found in the JsonWebKey: '{1}', Exception '{2}'.", typeof(SecurityKey), webKey, ex));
		}
		LogHelper.LogWarning(LogHelper.FormatInvariant("IDX10812: Unable to create a {0} from the properties found in the JsonWebKey: '{1}'.", typeof(SecurityKey), webKey));
		return false;
	}

	internal static bool TryConvertToSymmetricSecurityKey(JsonWebKey webKey, out SecurityKey key)
	{
		if (webKey.ConvertedSecurityKey is SymmetricSecurityKey)
		{
			key = webKey.ConvertedSecurityKey;
			return true;
		}
		key = null;
		if (string.IsNullOrEmpty(webKey.K))
		{
			return false;
		}
		try
		{
			key = new SymmetricSecurityKey(webKey);
			return true;
		}
		catch (Exception ex)
		{
			LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10813: Unable to create a {0} from the properties found in the JsonWebKey: '{1}', Exception '{2}'.", typeof(SymmetricSecurityKey), webKey, ex), ex));
		}
		return false;
	}

	internal static bool TryConvertToX509SecurityKey(JsonWebKey webKey, out SecurityKey key)
	{
		if (webKey.ConvertedSecurityKey is X509SecurityKey)
		{
			key = webKey.ConvertedSecurityKey;
			return true;
		}
		key = null;
		if (webKey.X5c == null || webKey.X5c.Count == 0)
		{
			return false;
		}
		try
		{
			key = new X509SecurityKey(webKey);
			return true;
		}
		catch (Exception ex)
		{
			LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10813: Unable to create a {0} from the properties found in the JsonWebKey: '{1}', Exception '{2}'.", typeof(X509SecurityKey), webKey, ex), ex));
		}
		return false;
	}

	internal static bool TryCreateToRsaSecurityKey(JsonWebKey webKey, out SecurityKey key)
	{
		if (webKey.ConvertedSecurityKey is RsaSecurityKey)
		{
			key = webKey.ConvertedSecurityKey;
			return true;
		}
		key = null;
		if (string.IsNullOrWhiteSpace(webKey.E) || string.IsNullOrWhiteSpace(webKey.N))
		{
			return false;
		}
		try
		{
			key = new RsaSecurityKey(webKey);
			return true;
		}
		catch (Exception ex)
		{
			LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10813: Unable to create a {0} from the properties found in the JsonWebKey: '{1}', Exception '{2}'.", typeof(RsaSecurityKey), webKey, ex), ex));
		}
		return false;
	}

	internal static bool TryConvertToECDsaSecurityKey(JsonWebKey webKey, out SecurityKey key)
	{
		if (webKey.ConvertedSecurityKey is ECDsaSecurityKey)
		{
			key = webKey.ConvertedSecurityKey;
			return true;
		}
		key = null;
		if (string.IsNullOrEmpty(webKey.Crv) || string.IsNullOrEmpty(webKey.X) || string.IsNullOrEmpty(webKey.Y))
		{
			return false;
		}
		try
		{
			key = new ECDsaSecurityKey(webKey, !string.IsNullOrEmpty(webKey.D));
			return true;
		}
		catch (Exception ex)
		{
			LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10813: Unable to create a {0} from the properties found in the JsonWebKey: '{1}', Exception '{2}'.", typeof(ECDsaSecurityKey), webKey, ex), ex));
		}
		return false;
	}
}
public static class JsonWebKeyECTypes
{
	public const string P256 = "P-256";

	public const string P384 = "P-384";

	public const string P512 = "P-512";

	public const string P521 = "P-521";
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
[JsonObject]
public class JsonWebKeySet
{
	[DefaultValue(true)]
	public static bool DefaultSkipUnresolvedJsonWebKeys = true;

	[JsonExtensionData]
	public virtual IDictionary<string, object> AdditionalData { get; } = new Dictionary<string, object>();

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "keys", Required = Required.Default)]
	public IList<JsonWebKey> Keys { get; private set; } = new List<JsonWebKey>();

	[DefaultValue(true)]
	public bool SkipUnresolvedJsonWebKeys { get; set; } = DefaultSkipUnresolvedJsonWebKeys;

	public static JsonWebKeySet Create(string json)
	{
		if (string.IsNullOrEmpty(json))
		{
			throw LogHelper.LogArgumentNullException("json");
		}
		return new JsonWebKeySet(json);
	}

	public JsonWebKeySet()
	{
	}

	public JsonWebKeySet(string json)
		: this(json, null)
	{
	}

	public JsonWebKeySet(string json, JsonSerializerSettings jsonSerializerSettings)
	{
		if (string.IsNullOrEmpty(json))
		{
			throw LogHelper.LogArgumentNullException("json");
		}
		try
		{
			LogHelper.LogVerbose("IDX10806: Deserializing json: '{0}' into '{1}'.", json, this);
			if (jsonSerializerSettings != null)
			{
				JsonConvert.PopulateObject(json, this, jsonSerializerSettings);
			}
			else
			{
				JsonConvert.PopulateObject(json, this);
			}
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10805: Error deserializing json: '{0}' into '{1}'.", json, GetType()), innerException));
		}
	}

	public IList<SecurityKey> GetSigningKeys()
	{
		List<SecurityKey> list = new List<SecurityKey>();
		foreach (JsonWebKey key4 in Keys)
		{
			if (!string.IsNullOrEmpty(key4.Use) && !key4.Use.Equals("sig", StringComparison.Ordinal))
			{
				LogHelper.LogInformation(LogHelper.FormatInvariant("IDX10808: The 'use' parameter of a JsonWebKey: '{0}' was expected to be 'sig' or empty, but was '{1}'.", key4, key4.Use));
				if (!SkipUnresolvedJsonWebKeys)
				{
					list.Add(key4);
				}
			}
			else if ("RSA".Equals(key4.Kty, StringComparison.Ordinal))
			{
				bool flag = true;
				if ((key4.X5c == null || key4.X5c.Count == 0) && string.IsNullOrEmpty(key4.E) && string.IsNullOrEmpty(key4.N))
				{
					flag = false;
				}
				else
				{
					if (key4.X5c != null && key4.X5c.Count != 0)
					{
						if (JsonWebKeyConverter.TryConvertToX509SecurityKey(key4, out var key))
						{
							list.Add(key);
						}
						else
						{
							flag = false;
						}
					}
					if (!string.IsNullOrEmpty(key4.E) && !string.IsNullOrEmpty(key4.N))
					{
						if (JsonWebKeyConverter.TryCreateToRsaSecurityKey(key4, out var key2))
						{
							list.Add(key2);
						}
						else
						{
							flag = false;
						}
					}
				}
				if (!flag && !SkipUnresolvedJsonWebKeys)
				{
					list.Add(key4);
				}
			}
			else if ("EC".Equals(key4.Kty, StringComparison.Ordinal))
			{
				if (JsonWebKeyConverter.TryConvertToECDsaSecurityKey(key4, out var key3))
				{
					list.Add(key3);
				}
				else if (!SkipUnresolvedJsonWebKeys)
				{
					list.Add(key4);
				}
			}
			else
			{
				LogHelper.LogInformation(LogHelper.FormatInvariant("IDX10810: Unable to convert the JsonWebKey: '{0}' to a X509SecurityKey, RsaSecurityKey or ECDSASecurityKey.", key4));
				if (!SkipUnresolvedJsonWebKeys)
				{
					list.Add(key4);
				}
			}
		}
		return list;
	}
}
public static class JsonWebKeySetParameterNames
{
	public const string Keys = "keys";
}
public static class JsonWebKeyUseNames
{
	public const string Sig = "sig";

	public const string Enc = "enc";
}
internal static class LogMessages
{
	public const string IDX10000 = "IDX10000: The parameter '{0}' cannot be a 'null' or an empty object.";

	public const string IDX10101 = "IDX10101: MaximumTokenSizeInBytes must be greater than zero. value: '{0}'";

	public const string IDX10100 = "IDX10100: ClockSkew must be greater than TimeSpan.Zero. value: '{0}'";

	public const string IDX10102 = "IDX10102: NameClaimType cannot be null or whitespace.";

	public const string IDX10103 = "IDX10103: RoleClaimType cannot be null or whitespace.";

	public const string IDX10104 = "IDX10104: TokenLifetimeInMinutes must be greater than zero. value: '{0}'";

	public const string IDX10204 = "IDX10204: Unable to validate issuer. validationParameters.ValidIssuer is null or whitespace AND validationParameters.ValidIssuers is null.";

	public const string IDX10205 = "IDX10205: Issuer validation failed. Issuer: '{0}'. Did not match: validationParameters.ValidIssuer: '{1}' or validationParameters.ValidIssuers: '{2}'.";

	public const string IDX10207 = "IDX10207: Unable to validate audience. The 'audiences' parameter is null.";

	public const string IDX10208 = "IDX10208: Unable to validate audience. validationParameters.ValidAudience is null or whitespace and validationParameters.ValidAudiences is null.";

	public const string IDX10209 = "IDX10209: Token has length: '{0}' which is larger than the MaximumTokenSizeInBytes: '{1}'.";

	public const string IDX10211 = "IDX10211: Unable to validate issuer. The 'issuer' parameter is null or whitespace";

	public const string IDX10214 = "IDX10214: Audience validation failed. Audiences: '{0}'. Did not match: validationParameters.ValidAudience: '{1}' or validationParameters.ValidAudiences: '{2}'.";

	public const string IDX10222 = "IDX10222: Lifetime validation failed. The token is not yet valid. ValidFrom: '{0}', Current time: '{1}'.";

	public const string IDX10223 = "IDX10223: Lifetime validation failed. The token is expired. ValidTo: '{0}', Current time: '{1}'.";

	public const string IDX10224 = "IDX10224: Lifetime validation failed. The NotBefore: '{0}' is after Expires: '{1}'.";

	public const string IDX10225 = "IDX10225: Lifetime validation failed. The token is missing an Expiration Time. Tokentype: '{0}'.";

	public const string IDX10227 = "IDX10227: TokenValidationParameters.TokenReplayCache is not null, indicating to check for token replay but the security token has no expiration time: token '{0}'.";

	public const string IDX10228 = "IDX10228: The securityToken has previously been validated, securityToken: '{0}'.";

	public const string IDX10229 = "IDX10229: TokenValidationParameters.TokenReplayCache was unable to add the securityToken: '{0}'.";

	public const string IDX10230 = "IDX10230: Lifetime validation failed. Delegate returned false, securitytoken: '{0}'.";

	public const string IDX10231 = "IDX10231: Audience validation failed. Delegate returned false, securitytoken: '{0}'.";

	public const string IDX10232 = "IDX10232: IssuerSigningKey validation failed. Delegate returned false, securityKey: '{0}'.";

	public const string IDX10233 = "IDX10233: ValidateAudience property on ValidationParameters is set to false. Exiting without validating the audience.";

	public const string IDX10234 = "IDX10234: Audience Validated.Audience: '{0}'";

	public const string IDX10235 = "IDX10235: ValidateIssuer property on ValidationParameters is set to false. Exiting without validating the issuer.";

	public const string IDX10236 = "IDX10236: Issuer Validated.Issuer: '{0}'";

	public const string IDX10237 = "IDX10237: ValidateIssuerSigningKey property on ValidationParameters is set to false. Exiting without validating the issuer signing key.";

	public const string IDX10238 = "IDX10238: ValidateLifetime property on ValidationParameters is set to false. Exiting without validating the lifetime.";

	public const string IDX10239 = "IDX10239: Lifetime of the token is valid.";

	public const string IDX10240 = "IDX10240: No token replay is detected.";

	public const string IDX10241 = "IDX10241: Security token validated. token: '{0}'.";

	public const string IDX10242 = "IDX10242: Security token: '{0}' has a valid signature.";

	public const string IDX10243 = "IDX10243: Reading issuer signing keys from validation parameters.";

	public const string IDX10244 = "IDX10244: Issuer is null or empty. Using runtime default for creating claims '{0}'.";

	public const string IDX10245 = "IDX10245: Creating claims identity from the validated token: '{0}'.";

	public const string IDX10246 = "IDX10246: ValidateTokenReplay property on ValidationParameters is set to false. Exiting without validating the token replay.";

	public const string IDX10247 = "IDX10247: The current issuer value in ValidateIssuers property on ValidationParameters is null or empty, skipping it for issuer validation.";

	public const string IDX10248 = "IDX10248: X509SecurityKey validation failed. The associated certificate is not yet valid. ValidFrom (UTC): '{0}', Current time (UTC): '{1}'.";

	public const string IDX10249 = "IDX10249: X509SecurityKey validation failed. The associated certificate has expired. ValidTo (UTC): '{0}', Current time (UTC): '{1}'.";

	public const string IDX10250 = "IDX10250: The associated certificate is valid. ValidFrom (UTC): '{0}', Current time (UTC): '{1}'.";

	public const string IDX10251 = "IDX10251: The associated certificate is valid. ValidTo (UTC): '{0}', Current time (UTC): '{1}'.";

	public const string IDX10252 = "IDX10252: RequireSignedTokens property on ValidationParameters is set to false and the issuer signing key is null. Exiting without validating the issuer signing key.";

	public const string IDX10253 = "IDX10253: RequireSignedTokens property on ValidationParameters is set to true, but the issuer signing key is null.";

	public const string IDX10254 = "IDX10254: '{0}.{1}' failed. The virtual method '{2}.{3}' returned null. If this method was overridden, ensure a valid '{4}' is returned.";

	public const string IDX10255 = "IDX10255: ValidTypes property on ValidationParameters is either null or empty. Exiting without validating the token type.";

	public const string IDX10256 = "IDX10256: Unable to validate the token type. TokenValidationParameters.ValidTypes is set, but the 'typ' header claim is null or empty.";

	public const string IDX10257 = "IDX10257: Token type validation failed. Type: '{0}'. Did not match: validationParameters.TokenTypes: '{1}'.";

	public const string IDX10258 = "IDX10258: Token type validated. Type: '{0}'.";

	public const string IDX10500 = "IDX10500: Signature validation failed. No security keys were provided to validate the signature.";

	public const string IDX10501 = "IDX10501: Signature validation failed. Unable to match key: \nkid: '{0}'.\nExceptions caught:\n '{1}'. \ntoken: '{2}'.";

	public const string IDX10503 = "IDX10503: Signature validation failed. Keys tried: '{0}'.\nExceptions caught:\n '{1}'.\ntoken: '{2}'.";

	public const string IDX10504 = "IDX10504: Unable to validate signature, token does not have a signature: '{0}'.";

	public const string IDX10505 = "IDX10505: Signature validation failed. The user defined 'Delegate' specified on TokenValidationParameters returned null when validating token: '{0}'.";

	public const string IDX10506 = "IDX10506: Signature validation failed. The user defined 'Delegate' specified on TokenValidationParameters did not return a '{0}', but returned a '{1}' when validating token: '{2}'.";

	public const string IDX10507 = "IDX10507: Signature validation failed. ValidateSignature returned null when validating token: '{0}'.";

	public const string IDX10508 = "IDX10508: Signature validation failed. Signature is improperly formatted.";

	public const string IDX10509 = "IDX10509: Signature validation failed. The user defined 'Delegate' specified in TokenValidationParameters did not return a '{0}', but returned a '{1}' when reading token: '{2}'.";

	public const string IDX10510 = "IDX10510: Signature validation failed. The user defined 'Delegate' specified in TokenValidationParameters returned null when reading token: '{0}'.";

	public const string IDX10511 = "IDX10511: Signature validation failed. Keys tried: '{0}'. \nkid: '{1}'. \nExceptions caught:\n '{2}'.\ntoken: '{3}'.";

	public const string IDX10600 = "IDX10600: Decryption failed. There are no security keys for decryption.";

	public const string IDX10601 = "IDX10601: Decryption failed. Unable to match 'kid': '{0}', \ntoken: '{1}'.";

	public const string IDX10603 = "IDX10603: Decryption failed. Keys tried: '{0}'.\nExceptions caught:\n '{1}'.\ntoken: '{2}'";

	public const string IDX10604 = "IDX10604: Decryption failed. Exception: '{0}'.";

	public const string IDX10605 = "IDX10605: Decryption failed. Only 'dir' is currently supported. JWE alg is: '{0}'.";

	public const string IDX10606 = "IDX10606: Decryption failed. To decrypt a JWE there must be 5 parts. 'tokenParts' is of length: '{0}'.";

	public const string IDX10607 = "IDX10607: Decryption skipping key: '{0}', both validationParameters.CryptoProviderFactory and key.CryptoProviderFactory are null.";

	public const string IDX10608 = "IDX10608: Decryption skipping key: '{0}', it is not a '{1}'.";

	public const string IDX10609 = "IDX10609: Decryption failed. No Keys tried: token: '{0}'.";

	public const string IDX10610 = "IDX10610: Decryption failed. Could not create decryption provider. Key: '{0}', Algorithm: '{1}'.";

	public const string IDX10611 = "IDX10611: Decryption failed. Encryption is not supported for: Algorithm: '{0}', SecurityKey: '{1}'.";

	public const string IDX10612 = "IDX10612: Decryption failed. Header.Enc is null or empty, it must be specified.";

	public const string IDX10614 = "IDX10614: Decryption failed. JwtHeader.Base64UrlDeserialize(tokenParts[0]): '{0}'. Inner exception: '{1}'.";

	public const string IDX10615 = "IDX10615: Encryption failed. No support for: Algorithm: '{0}', SecurityKey: '{1}'.";

	public const string IDX10616 = "IDX10616: Encryption failed. EncryptionProvider failed for: Algorithm: '{0}', SecurityKey: '{1}'. See inner exception.";

	public const string IDX10617 = "IDX10617: Encryption failed. Keywrap is only supported for: '{0}', '{1}' and '{2}'. The content encryption specified is: '{3}'.";

	public const string IDX10400 = "IDX10400: Unable to decode: '{0}' as Base64url encoded string.";

	public const string IDX10401 = "IDX10401: Invalid requested key size. Valid key sizes are: 256, 384, and 512.";

	public const string IDX10621 = "IDX10621: '{0}' supports: '{1}' of types: '{2}' or '{3}'. SecurityKey received was of type '{4}'.";

	public const string IDX10622 = "IDX10622: The algorithm: '{0}' requires the SecurityKey.KeySize to be greater than '{1}' bits. KeySize reported: '{2}'.";

	public const string IDX10623 = "IDX10623: Cannot sign data because the KeyedHashAlgorithm is null.";

	public const string IDX10624 = "IDX10624: Cannot verify data because the KeyedHashAlgorithm is null.";

	public const string IDX10627 = "IDX10627: Cannot set the MinimumAsymmetricKeySizeInBitsForVerifying to less than '{0}'.";

	public const string IDX10628 = "IDX10628: Cannot set the MinimumSymmetricKeySizeInBits to less than '{0}'.";

	public const string IDX10630 = "IDX10630: The '{0}' for signing cannot be smaller than '{1}' bits. KeySize: '{2}'.";

	public const string IDX10631 = "IDX10631: The '{0}' for verifying cannot be smaller than '{1}' bits. KeySize: '{2}'.";

	public const string IDX10634 = "IDX10634: Unable to create the SignatureProvider.\nAlgorithm: '{0}', SecurityKey: '{1}'\n is not supported. The list of supported algorithms is available here: https://aka.ms/IdentityModel/supported-algorithms";

	public const string IDX10635 = "IDX10635: Unable to create signature. '{0}' returned a null '{1}'. SecurityKey: '{2}', Algorithm: '{3}'";

	public const string IDX10636 = "IDX10636: CryptoProviderFactory.CreateForVerifying returned null for key: '{0}', signatureAlgorithm: '{1}'.";

	public const string IDX10638 = "IDX10638: Cannot create the SignatureProvider, 'key.HasPrivateKey' is false, cannot create signatures. Key: {0}.";

	public const string IDX10640 = "IDX10640: Algorithm is not supported: '{0}'.";

	public const string IDX10641 = "IDX10641: Key is not supported: '{0}'.";

	public const string IDX10642 = "IDX10642: Creating signature using the input: '{0}'.";

	public const string IDX10643 = "IDX10643: Comparing the signature created over the input with the token signature: '{0}'.";

	public const string IDX10644 = "IDX10644: UnwrapKey failed. Algorithm: '{0}'.";

	public const string IDX10645 = "IDX10645: Elliptical Curve not supported for curveId: '{0}'";

	public const string IDX10646 = "IDX10646: A CustomCryptoProvider was set and returned 'true' for IsSupportedAlgorithm(Algorithm: '{0}', Key: '{1}'), but Create.(algorithm, args) as '{2}' == NULL.";

	public const string IDX10647 = "IDX10647: A CustomCryptoProvider was set and returned 'true' for IsSupportedAlgorithm(Algorithm: '{0}'), but Create.(algorithm, args) as '{1}' == NULL.";

	public const string IDX10648 = "IDX10648: The SecurityKey provided for AuthenticatedEncryption must be a SymmetricSecurityKey. Type is: '{0}'.";

	public const string IDX10649 = "IDX10649: Failed to create a SymmetricSignatureProvider for the algorithm '{0}'.";

	public const string IDX10650 = "IDX10650: Failed to verify ciphertext with aad '{0}'; iv '{1}'; and authenticationTag '{2}'.";

	public const string IDX10651 = "IDX10651: The key length for the algorithm '{0]' cannot be less than '{1}'.";

	public const string IDX10652 = "IDX10652: The algorithm '{0}' is not supported.";

	public const string IDX10653 = "IDX10653: The encryption algorithm '{0}' requires a key size of at least '{1}' bits. Key '{2}', is of size: '{3}'.";

	public const string IDX10654 = "IDX10654: Decryption failed. Cryptographic operation exception: '{0}'.";

	public const string IDX10655 = "IDX10655: 'length' must be greater than 1: '{0}'";

	public const string IDX10656 = "IDX10656: 'length' cannot be greater than signature.Length. length: '{0}', signature.Length: '{1}'.";

	public const string IDX10657 = "IDX10657: The SecurityKey provided for the symmetric key wrap algorithm cannot be converted to byte array. Type is: '{0}'.";

	public const string IDX10658 = "IDX10658: WrapKey failed, exception from cryptographic operation: '{0}'";

	public const string IDX10659 = "IDX10659: UnwrapKey failed, exception from cryptographic operation: '{0}'";

	public const string IDX10660 = "IDX10660: The Key: '{0}' and algorithm: '{1}' pair are not supported.";

	public const string IDX10661 = "IDX10661: Unable to create the KeyWrapProvider.\nKeyWrapAlgorithm: '{0}', SecurityKey: '{1}'\n is not supported.";

	public const string IDX10662 = "IDX10662: The KeyWrap algorithm '{0}' requires a key size of '{1}' bits. Key '{2}', is of size:'{3}'.";

	public const string IDX10663 = "IDX10663: Failed to create symmetric algorithm with SecurityKey: '{0}', KeyWrapAlgorithm: '{1}'.";

	public const string IDX10664 = "IDX10664: The length of input must be a multiple of 64 bits. The input size is: '{0}' bits.";

	public const string IDX10665 = "IDX10665: Data is not authentic";

	public const string IDX10666 = "IDX10666: Unable to create KeyedHashAlgorithm for algorithm '{0}'.";

	public const string IDX10667 = "IDX10667: Unable to obtain required byte array for KeyHashAlgorithm from SecurityKey: '{0}'.";

	public const string IDX10668 = "IDX10668: Unable to create '{0}', algorithm '{1}'; key: '{2}' is not supported.";

	public const string IDX10669 = "IDX10669: Failed to create symmetric algorithm.";

	public const string IDX10670 = "IDX10670: The lengths of the two byte arrays do not match. The first one has: '{0}' bytes, the second one has: '{1}' bytes.";

	public const string IDX10671 = "IDX10671: The ECDsa Key: '{0}' must be '{1}' bits. KeySize: '{2}'.";

	public const string IDX10672 = "IDX10672: GetKeyedHashAlgorithm returned null, key: {0}, algorithm {1}.";

	public const string IDX10673 = "IDX10673: CryptoProviderFactory.GetHashAlgorithm returned null, factory: {0}, algorithm: {1}.";

	public const string IDX10674 = "IDX10674: JsonWebKeyConverter does not support SecurityKey of type: {0}";

	public const string IDX10675 = "IDX10675: The byte count of '{0}' must be less than or equal to '{1}', but was {2}.";

	public const string IDX10677 = "IDX10677: GetKeyedHashAlgorithm threw, key: {0}, algorithm {1}.";

	public const string IDX10678 = "IDX10678: Unable to Sign, provider is not available, Algorithm, Key: '{0}', '{1}'.";

	public const string IDX10679 = "IDX10679: Failed to decompress using algorithm '{0}'.";

	public const string IDX10680 = "IDX10680: Failed to compress using algorithm '{0}'.";

	public const string IDX10681 = "IDX10681: Unable to create the CompressionProvider.\nAlgorithm: '{0}' is not supported.";

	public const string IDX10682 = "IDX10682: Compression algorithm '{0}' is not supported.";

	public const string IDX10684 = "IDX10684: Unable to convert the JsonWebKey to an AsymmetricSecurityKey. Algorithm: '{0}', Key: '{1}'.";

	public const string IDX10685 = "IDX10685: Unable to Sign, Internal SignFunction is not available.";

	public const string IDX10686 = "IDX10686: Unable to Verify, Internal VerifyFunction is not available.";

	public const string IDX10687 = "IDX10687: Unable to create a AsymmetricAdapter. For NET45 or NET451 only types: '{0}' or '{1}' are supported. RSA is of type: '{2}'..";

	public const string IDX10689 = "IDX10689: Unable to create an ECDsa object. See inner exception for more details.";

	public const string IDX10690 = "IDX10690: ECDsa creation is not supported by NETSTANDARD1.4, when running on platforms other than Windows. For more details, see https://aka.ms/IdentityModel/create-ecdsa";

	public const string IDX10692 = "IDX10692: The RSASS-PSS signature algorithm is not available on .NET 4.5 and .NET 4.5.1 targets. The list of supported algorithms is available here: https://aka.ms/IdentityModel/supported-algorithms";

	public const string IDX10693 = "IDX10693: RSACryptoServiceProvider doesn't support the RSASSA-PSS signature algorithm. The list of supported algorithms is available here: https://aka.ms/IdentityModel/supported-algorithms";

	public const string IDX10694 = "IDX10694: JsonWebKeyConverter threw attempting to convert JsonWebKey: '{0}'. Exception: '{1}'.";

	public const string IDX10700 = "IDX10700: {0} is unable to use 'rsaParameters'. {1} is null.";

	public const string IDX10703 = "IDX10703: Cannot create a '{0}', key length is zero.";

	public const string IDX10704 = "IDX10704: Cannot verify the key size. The SecurityKey is not or cannot be converted to an AsymmetricSecuritKey. SecurityKey: '{0}'.";

	public const string IDX10805 = "IDX10805: Error deserializing json: '{0}' into '{1}'.";

	public const string IDX10806 = "IDX10806: Deserializing json: '{0}' into '{1}'.";

	public const string IDX10808 = "IDX10808: The 'use' parameter of a JsonWebKey: '{0}' was expected to be 'sig' or empty, but was '{1}'.";

	public const string IDX10810 = "IDX10810: Unable to convert the JsonWebKey: '{0}' to a X509SecurityKey, RsaSecurityKey or ECDSASecurityKey.";

	public const string IDX10812 = "IDX10812: Unable to create a {0} from the properties found in the JsonWebKey: '{1}'.";

	public const string IDX10813 = "IDX10813: Unable to create a {0} from the properties found in the JsonWebKey: '{1}', Exception '{2}'.";
}
public class RsaSecurityKey : AsymmetricSecurityKey
{
	private bool? _hasPrivateKey;

	private bool _foundPrivateKeyDetermined;

	private PrivateKeyStatus _foundPrivateKey;

	[Obsolete("HasPrivateKey method is deprecated, please use PrivateKeyStatus.")]
	public override bool HasPrivateKey
	{
		get
		{
			if (!_hasPrivateKey.HasValue)
			{
				try
				{
					byte[] data = new byte[20];
					Rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
					_hasPrivateKey = true;
				}
				catch (CryptographicException)
				{
					_hasPrivateKey = false;
				}
			}
			return _hasPrivateKey.Value;
		}
	}

	public override PrivateKeyStatus PrivateKeyStatus
	{
		get
		{
			if (_foundPrivateKeyDetermined)
			{
				return _foundPrivateKey;
			}
			_foundPrivateKeyDetermined = true;
			if (Rsa != null)
			{
				try
				{
					RSAParameters rSAParameters = Rsa.ExportParameters(includePrivateParameters: true);
					if (rSAParameters.D != null && rSAParameters.DP != null && rSAParameters.DQ != null && rSAParameters.P != null && rSAParameters.Q != null && rSAParameters.InverseQ != null)
					{
						_foundPrivateKey = PrivateKeyStatus.Exists;
					}
					else
					{
						_foundPrivateKey = PrivateKeyStatus.DoesNotExist;
					}
				}
				catch (Exception)
				{
					_foundPrivateKey = PrivateKeyStatus.Unknown;
					return _foundPrivateKey;
				}
			}
			else if (Parameters.D != null && Parameters.DP != null && Parameters.DQ != null && Parameters.P != null && Parameters.Q != null && Parameters.InverseQ != null)
			{
				_foundPrivateKey = PrivateKeyStatus.Exists;
			}
			else
			{
				_foundPrivateKey = PrivateKeyStatus.DoesNotExist;
			}
			return _foundPrivateKey;
		}
	}

	public override int KeySize
	{
		get
		{
			if (Rsa != null)
			{
				return Rsa.KeySize;
			}
			if (Parameters.Modulus != null)
			{
				return Parameters.Modulus.Length * 8;
			}
			return 0;
		}
	}

	public RSAParameters Parameters { get; private set; }

	public RSA Rsa { get; private set; }

	internal RsaSecurityKey(JsonWebKey webKey)
		: base(webKey)
	{
		IntializeWithRsaParameters(webKey.CreateRsaParameters());
		webKey.ConvertedSecurityKey = this;
	}

	public RsaSecurityKey(RSAParameters rsaParameters)
	{
		IntializeWithRsaParameters(rsaParameters);
	}

	internal void IntializeWithRsaParameters(RSAParameters rsaParameters)
	{
		if (rsaParameters.Modulus == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10700: {0} is unable to use 'rsaParameters'. {1} is null.", this, "Modulus")));
		}
		if (rsaParameters.Exponent == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10700: {0} is unable to use 'rsaParameters'. {1} is null.", this, "Exponent")));
		}
		_hasPrivateKey = rsaParameters.D != null && rsaParameters.DP != null && rsaParameters.DQ != null && rsaParameters.P != null && rsaParameters.Q != null && rsaParameters.InverseQ != null;
		_foundPrivateKey = ((!_hasPrivateKey.Value) ? PrivateKeyStatus.DoesNotExist : PrivateKeyStatus.Exists);
		_foundPrivateKeyDetermined = true;
		Parameters = rsaParameters;
	}

	public RsaSecurityKey(RSA rsa)
	{
		Rsa = rsa ?? throw LogHelper.LogArgumentNullException("rsa");
	}
}
public static class SecurityAlgorithms
{
	public const string Aes128Encryption = "http://www.w3.org/2001/04/xmlenc#aes128-cbc";

	public const string Aes192Encryption = "http://www.w3.org/2001/04/xmlenc#aes192-cbc";

	public const string Aes256Encryption = "http://www.w3.org/2001/04/xmlenc#aes256-cbc";

	public const string DesEncryption = "http://www.w3.org/2001/04/xmlenc#des-cbc";

	public const string Aes128KeyWrap = "http://www.w3.org/2001/04/xmlenc#kw-aes128";

	public const string Aes192KeyWrap = "http://www.w3.org/2001/04/xmlenc#kw-aes192";

	public const string Aes256KeyWrap = "http://www.w3.org/2001/04/xmlenc#kw-aes256";

	public const string RsaV15KeyWrap = "http://www.w3.org/2001/04/xmlenc#rsa-1_5";

	public const string Ripemd160Digest = "http://www.w3.org/2001/04/xmlenc#ripemd160";

	public const string RsaOaepKeyWrap = "http://www.w3.org/2001/04/xmlenc#rsa-oaep";

	public const string Aes128KW = "A128KW";

	public const string Aes256KW = "A256KW";

	public const string RsaPKCS1 = "RSA1_5";

	public const string RsaOAEP = "RSA-OAEP";

	public const string ExclusiveC14n = "http://www.w3.org/2001/10/xml-exc-c14n#";

	public const string ExclusiveC14nWithComments = "http://www.w3.org/2001/10/xml-exc-c14n#WithComments";

	public const string EnvelopedSignature = "http://www.w3.org/2000/09/xmldsig#enveloped-signature";

	public const string Sha256Digest = "http://www.w3.org/2001/04/xmlenc#sha256";

	public const string Sha384Digest = "http://www.w3.org/2001/04/xmldsig-more#sha384";

	public const string Sha512Digest = "http://www.w3.org/2001/04/xmlenc#sha512";

	public const string Sha256 = "SHA256";

	public const string Sha384 = "SHA384";

	public const string Sha512 = "SHA512";

	public const string EcdsaSha256Signature = "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha256";

	public const string EcdsaSha384Signature = "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha384";

	public const string EcdsaSha512Signature = "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha512";

	public const string HmacSha256Signature = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";

	public const string HmacSha384Signature = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha384";

	public const string HmacSha512Signature = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha512";

	public const string RsaSha256Signature = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";

	public const string RsaSha384Signature = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha384";

	public const string RsaSha512Signature = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha512";

	public const string RsaSsaPssSha256Signature = "http://www.w3.org/2007/05/xmldsig-more#sha256-rsa-MGF1";

	public const string RsaSsaPssSha384Signature = "http://www.w3.org/2007/05/xmldsig-more#sha384-rsa-MGF1";

	public const string RsaSsaPssSha512Signature = "http://www.w3.org/2007/05/xmldsig-more#sha512-rsa-MGF1";

	public const string EcdsaSha256 = "ES256";

	public const string EcdsaSha384 = "ES384";

	public const string EcdsaSha512 = "ES512";

	public const string HmacSha256 = "HS256";

	public const string HmacSha384 = "HS384";

	public const string HmacSha512 = "HS512";

	public const string None = "none";

	public const string RsaSha256 = "RS256";

	public const string RsaSha384 = "RS384";

	public const string RsaSha512 = "RS512";

	public const string RsaSsaPssSha256 = "PS256";

	public const string RsaSsaPssSha384 = "PS384";

	public const string RsaSsaPssSha512 = "PS512";

	public const string Aes128CbcHmacSha256 = "A128CBC-HS256";

	public const string Aes192CbcHmacSha384 = "A192CBC-HS384";

	public const string Aes256CbcHmacSha512 = "A256CBC-HS512";

	internal const string DefaultAsymmetricKeyWrapAlgorithm = "http://www.w3.org/2001/04/xmlenc#rsa-oaep";

	internal const string DefaultSymmetricEncryptionAlgorithm = "A128CBC-HS256";
}
public abstract class SecurityKey
{
	private CryptoProviderFactory _cryptoProviderFactory;

	[JsonIgnore]
	internal string InternalId { get; } = Guid.NewGuid().ToString();

	public abstract int KeySize { get; }

	[JsonIgnore]
	public virtual string KeyId { get; set; }

	[JsonIgnore]
	public CryptoProviderFactory CryptoProviderFactory
	{
		get
		{
			return _cryptoProviderFactory;
		}
		set
		{
			_cryptoProviderFactory = value ?? throw LogHelper.LogArgumentNullException("value");
		}
	}

	internal SecurityKey(SecurityKey key)
	{
		_cryptoProviderFactory = key._cryptoProviderFactory;
		KeyId = key.KeyId;
	}

	public SecurityKey()
	{
		_cryptoProviderFactory = CryptoProviderFactory.Default;
	}

	public override string ToString()
	{
		return $"{GetType()}, KeyId: '{KeyId}', InternalId: '{InternalId}'.";
	}
}
public class SecurityKeyIdentifierClause
{
}
public abstract class SecurityToken
{
	public abstract string Id { get; }

	public abstract string Issuer { get; }

	public abstract SecurityKey SecurityKey { get; }

	public abstract SecurityKey SigningKey { get; set; }

	public abstract DateTime ValidFrom { get; }

	public abstract DateTime ValidTo { get; }
}
public class SecurityTokenDescriptor
{
	public string Audience { get; set; }

	public string CompressionAlgorithm { get; set; }

	public EncryptingCredentials EncryptingCredentials { get; set; }

	public DateTime? Expires { get; set; }

	public string Issuer { get; set; }

	public DateTime? IssuedAt { get; set; }

	public DateTime? NotBefore { get; set; }

	public IDictionary<string, object> Claims { get; set; }

	public IDictionary<string, object> AdditionalHeaderClaims { get; set; }

	public SigningCredentials SigningCredentials { get; set; }

	public ClaimsIdentity Subject { get; set; }
}
public abstract class SecurityTokenHandler : TokenHandler, ISecurityTokenValidator
{
	public virtual bool CanValidateToken => false;

	public virtual bool CanWriteToken => false;

	public abstract Type TokenType { get; }

	public virtual SecurityKeyIdentifierClause CreateSecurityTokenReference(SecurityToken token, bool attached)
	{
		throw new NotImplementedException();
	}

	public virtual SecurityToken CreateToken(SecurityTokenDescriptor tokenDescriptor)
	{
		throw new NotImplementedException();
	}

	public virtual bool CanReadToken(XmlReader reader)
	{
		return false;
	}

	public virtual bool CanReadToken(string tokenString)
	{
		return false;
	}

	public virtual SecurityToken ReadToken(string tokenString)
	{
		return null;
	}

	public virtual SecurityToken ReadToken(XmlReader reader)
	{
		return null;
	}

	public virtual string WriteToken(SecurityToken token)
	{
		return null;
	}

	public abstract void WriteToken(XmlWriter writer, SecurityToken token);

	public abstract SecurityToken ReadToken(XmlReader reader, TokenValidationParameters validationParameters);

	public virtual ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
	{
		throw new NotImplementedException();
	}

	public virtual ClaimsPrincipal ValidateToken(XmlReader reader, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
	{
		throw new NotImplementedException();
	}
}
public abstract class SignatureProvider : IDisposable
{
	public string Algorithm { get; private set; }

	public string Context { get; set; }

	public CryptoProviderCache CryptoProviderCache { get; set; }

	public SecurityKey Key { get; private set; }

	public bool WillCreateSignatures { get; protected set; }

	protected SignatureProvider(SecurityKey key, string algorithm)
	{
		Key = key ?? throw LogHelper.LogArgumentNullException("key");
		if (string.IsNullOrEmpty(algorithm))
		{
			throw LogHelper.LogArgumentNullException("algorithm");
		}
		Algorithm = algorithm;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected abstract void Dispose(bool disposing);

	public abstract byte[] Sign(byte[] input);

	public abstract bool Verify(byte[] input, byte[] signature);
}
public class SigningCredentials
{
	private string _algorithm;

	private string _digest;

	private SecurityKey _key;

	public string Algorithm
	{
		get
		{
			return _algorithm;
		}
		private set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw LogHelper.LogArgumentNullException("algorithm");
			}
			_algorithm = value;
		}
	}

	public string Digest
	{
		get
		{
			return _digest;
		}
		private set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw LogHelper.LogArgumentNullException("digest");
			}
			_digest = value;
		}
	}

	public CryptoProviderFactory CryptoProviderFactory { get; set; }

	public SecurityKey Key
	{
		get
		{
			return _key;
		}
		private set
		{
			_key = value ?? throw LogHelper.LogArgumentNullException("key");
		}
	}

	public string Kid => Key.KeyId;

	protected SigningCredentials(X509Certificate2 certificate)
	{
		if (certificate == null)
		{
			throw LogHelper.LogArgumentNullException("certificate");
		}
		Key = new X509SecurityKey(certificate);
		Algorithm = "RS256";
	}

	protected SigningCredentials(X509Certificate2 certificate, string algorithm)
	{
		if (certificate == null)
		{
			throw LogHelper.LogArgumentNullException("certificate");
		}
		Key = new X509SecurityKey(certificate);
		Algorithm = algorithm;
	}

	public SigningCredentials(SecurityKey key, string algorithm)
	{
		Key = key;
		Algorithm = algorithm;
	}

	public SigningCredentials(SecurityKey key, string algorithm, string digest)
	{
		Key = key;
		Algorithm = algorithm;
		Digest = digest;
	}
}
internal static class SupportedAlgorithms
{
	public static bool IsSupportedAlgorithm(string algorithm, SecurityKey key)
	{
		if (key is RsaSecurityKey)
		{
			return IsSupportedRsaAlgorithm(algorithm, key);
		}
		if (key is X509SecurityKey x509SecurityKey)
		{
			if (!(x509SecurityKey.PublicKey is RSA))
			{
				return false;
			}
			return IsSupportedRsaAlgorithm(algorithm, key);
		}
		if (key is JsonWebKey jsonWebKey)
		{
			if ("RSA".Equals(jsonWebKey.Kty, StringComparison.Ordinal))
			{
				return IsSupportedRsaAlgorithm(algorithm, key);
			}
			if ("EC".Equals(jsonWebKey.Kty, StringComparison.Ordinal))
			{
				return IsSupportedEcdsaAlgorithm(algorithm);
			}
			if ("oct".Equals(jsonWebKey.Kty, StringComparison.Ordinal))
			{
				return IsSupportedSymmetricAlgorithm(algorithm);
			}
			return false;
		}
		if (key is ECDsaSecurityKey)
		{
			return IsSupportedEcdsaAlgorithm(algorithm);
		}
		if (key is SymmetricSecurityKey)
		{
			return IsSupportedSymmetricAlgorithm(algorithm);
		}
		return false;
	}

	internal static bool IsSupportedAuthenticatedEncryptionAlgorithm(string algorithm, SecurityKey key)
	{
		if (key == null)
		{
			return false;
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			return false;
		}
		if (!algorithm.Equals("A128CBC-HS256", StringComparison.Ordinal) && !algorithm.Equals("A192CBC-HS384", StringComparison.Ordinal) && !algorithm.Equals("A256CBC-HS512", StringComparison.Ordinal))
		{
			return false;
		}
		if (key is SymmetricSecurityKey)
		{
			return true;
		}
		if (key is JsonWebKey jsonWebKey)
		{
			if (jsonWebKey.K != null)
			{
				return jsonWebKey.Kty == "oct";
			}
			return false;
		}
		return false;
	}

	private static bool IsSupportedEcdsaAlgorithm(string algorithm)
	{
		switch (algorithm)
		{
		case "ES256":
		case "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha256":
		case "ES384":
		case "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha384":
		case "ES512":
		case "http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha512":
			return true;
		default:
			return false;
		}
	}

	internal static bool IsSupportedHashAlgorithm(string algorithm)
	{
		switch (algorithm)
		{
		case "SHA256":
		case "http://www.w3.org/2001/04/xmlenc#sha256":
		case "SHA384":
		case "http://www.w3.org/2001/04/xmldsig-more#sha384":
		case "SHA512":
		case "http://www.w3.org/2001/04/xmlenc#sha512":
			return true;
		default:
			return false;
		}
	}

	internal static bool IsSupportedKeyWrapAlgorithm(string algorithm, SecurityKey key)
	{
		if (key == null)
		{
			return false;
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			return false;
		}
		if (algorithm.Equals("RSA1_5", StringComparison.Ordinal) || algorithm.Equals("RSA-OAEP", StringComparison.Ordinal) || algorithm.Equals("http://www.w3.org/2001/04/xmlenc#rsa-oaep", StringComparison.Ordinal))
		{
			if (key is RsaSecurityKey)
			{
				return true;
			}
			if (key is X509SecurityKey)
			{
				return true;
			}
			if (key is JsonWebKey { Kty: "RSA" })
			{
				return true;
			}
		}
		return false;
	}

	internal static bool IsSupportedRsaAlgorithm(string algorithm, SecurityKey key)
	{
		switch (algorithm)
		{
		case "RS256":
		case "RS384":
		case "RS512":
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256":
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha384":
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha512":
		case "RSA-OAEP":
		case "RSA1_5":
		case "http://www.w3.org/2001/04/xmlenc#rsa-oaep":
			return true;
		case "PS256":
		case "PS384":
		case "PS512":
		case "http://www.w3.org/2007/05/xmldsig-more#sha256-rsa-MGF1":
		case "http://www.w3.org/2007/05/xmldsig-more#sha384-rsa-MGF1":
		case "http://www.w3.org/2007/05/xmldsig-more#sha512-rsa-MGF1":
			return IsSupportedRsaPss(key);
		default:
			return false;
		}
	}

	private static bool IsSupportedRsaPss(SecurityKey key)
	{
		if (key is RsaSecurityKey rsaSecurityKey && rsaSecurityKey.Rsa is RSACryptoServiceProvider)
		{
			LogHelper.LogInformation("IDX10693: RSACryptoServiceProvider doesn't support the RSASSA-PSS signature algorithm. The list of supported algorithms is available here: https://aka.ms/IdentityModel/supported-algorithms");
			return false;
		}
		if (key is X509SecurityKey x509SecurityKey && x509SecurityKey.PublicKey is RSACryptoServiceProvider)
		{
			LogHelper.LogInformation("IDX10693: RSACryptoServiceProvider doesn't support the RSASSA-PSS signature algorithm. The list of supported algorithms is available here: https://aka.ms/IdentityModel/supported-algorithms");
			return false;
		}
		return true;
	}

	internal static bool IsSupportedSymmetricAlgorithm(string algorithm)
	{
		switch (algorithm)
		{
		case "A128CBC-HS256":
		case "A192CBC-HS384":
		case "A256CBC-HS512":
		case "A128KW":
		case "A256KW":
		case "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256":
		case "http://www.w3.org/2001/04/xmldsig-more#hmac-sha384":
		case "http://www.w3.org/2001/04/xmldsig-more#hmac-sha512":
		case "HS256":
		case "HS384":
		case "HS512":
			return true;
		default:
			return false;
		}
	}
}
public class SymmetricSecurityKey : SecurityKey
{
	private int _keySize;

	private byte[] _key;

	public override int KeySize => _keySize;

	public virtual byte[] Key => _key.CloneByteArray();

	internal SymmetricSecurityKey(JsonWebKey webKey)
		: base(webKey)
	{
		if (string.IsNullOrEmpty(webKey.K))
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10703: Cannot create a '{0}', key length is zero.", typeof(SymmetricSecurityKey))));
		}
		_key = Base64UrlEncoder.DecodeBytes(webKey.K);
		_keySize = _key.Length * 8;
		webKey.ConvertedSecurityKey = this;
	}

	public SymmetricSecurityKey(byte[] key)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (key.Length == 0)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10703: Cannot create a '{0}', key length is zero.", typeof(SymmetricSecurityKey))));
		}
		_key = key.CloneByteArray();
		_keySize = _key.Length * 8;
	}
}
public class SymmetricSignatureProvider : SignatureProvider
{
	private bool _disposed;

	private KeyedHashAlgorithm _keyedHash;

	private object _signLock = new object();

	private object _verifyLock = new object();

	public static readonly int DefaultMinimumSymmetricKeySizeInBits = 128;

	private int _minimumSymmetricKeySizeInBits = DefaultMinimumSymmetricKeySizeInBits;

	public int MinimumSymmetricKeySizeInBits
	{
		get
		{
			return _minimumSymmetricKeySizeInBits;
		}
		set
		{
			if (value < DefaultMinimumSymmetricKeySizeInBits)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("value", LogHelper.FormatInvariant("IDX10628: Cannot set the MinimumSymmetricKeySizeInBits to less than '{0}'.", DefaultMinimumSymmetricKeySizeInBits)));
			}
			_minimumSymmetricKeySizeInBits = value;
		}
	}

	private KeyedHashAlgorithm KeyedHashAlgorithm
	{
		get
		{
			if (_keyedHash == null)
			{
				try
				{
					_keyedHash = GetKeyedHashAlgorithm(GetKeyBytes(base.Key), base.Algorithm);
				}
				catch (Exception innerException)
				{
					throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10677: GetKeyedHashAlgorithm threw, key: {0}, algorithm {1}.", base.Key, base.Algorithm ?? "null"), innerException));
				}
			}
			return _keyedHash;
		}
	}

	public SymmetricSignatureProvider(SecurityKey key, string algorithm)
		: this(key, algorithm, willCreateSignatures: true)
	{
	}

	public SymmetricSignatureProvider(SecurityKey key, string algorithm, bool willCreateSignatures)
		: base(key, algorithm)
	{
		if (!key.CryptoProviderFactory.IsSupportedAlgorithm(algorithm, key))
		{
			throw LogHelper.LogExceptionMessage(new NotSupportedException(LogHelper.FormatInvariant("IDX10634: Unable to create the SignatureProvider.\nAlgorithm: '{0}', SecurityKey: '{1}'\n is not supported. The list of supported algorithms is available here: https://aka.ms/IdentityModel/supported-algorithms", algorithm ?? "null", key)));
		}
		if (key.KeySize < MinimumSymmetricKeySizeInBits)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("KeySize", LogHelper.FormatInvariant("IDX10603: Decryption failed. Keys tried: '{0}'.\nExceptions caught:\n '{1}'.\ntoken: '{2}'", algorithm ?? "null", MinimumSymmetricKeySizeInBits, key.KeySize)));
		}
		base.WillCreateSignatures = willCreateSignatures;
	}

	protected virtual byte[] GetKeyBytes(SecurityKey key)
	{
		if (key == null)
		{
			throw LogHelper.LogArgumentNullException("key");
		}
		if (key is SymmetricSecurityKey symmetricSecurityKey)
		{
			return symmetricSecurityKey.Key;
		}
		if (key is JsonWebKey { K: not null, Kty: "oct" } jsonWebKey)
		{
			return Base64UrlEncoder.DecodeBytes(jsonWebKey.K);
		}
		throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10667: Unable to obtain required byte array for KeyHashAlgorithm from SecurityKey: '{0}'.", key)));
	}

	protected virtual KeyedHashAlgorithm GetKeyedHashAlgorithm(byte[] keyBytes, string algorithm)
	{
		if (_keyedHash == null)
		{
			try
			{
				_keyedHash = base.Key.CryptoProviderFactory.CreateKeyedHashAlgorithm(keyBytes, algorithm);
			}
			catch (Exception innerException)
			{
				throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX10677: GetKeyedHashAlgorithm threw, key: {0}, algorithm {1}.", base.Key, algorithm ?? "null"), innerException));
			}
		}
		return _keyedHash;
	}

	public override byte[] Sign(byte[] input)
	{
		if (input == null || input.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("input");
		}
		if (_disposed)
		{
			base.CryptoProviderCache?.TryRemove(this);
			throw LogHelper.LogExceptionMessage(new ObjectDisposedException(typeof(SymmetricSignatureProvider).ToString()));
		}
		LogHelper.LogInformation("IDX10642: Creating signature using the input: '{0}'.", input);
		try
		{
			lock (_signLock)
			{
				return KeyedHashAlgorithm.ComputeHash(input);
			}
		}
		catch
		{
			base.CryptoProviderCache?.TryRemove(this);
			throw;
		}
	}

	public override bool Verify(byte[] input, byte[] signature)
	{
		if (input == null || input.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("input");
		}
		if (signature == null || signature.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("signature");
		}
		if (_disposed)
		{
			base.CryptoProviderCache?.TryRemove(this);
			throw LogHelper.LogExceptionMessage(new ObjectDisposedException(typeof(SymmetricSignatureProvider).ToString()));
		}
		LogHelper.LogInformation("IDX10643: Comparing the signature created over the input with the token signature: '{0}'.", input);
		try
		{
			lock (_verifyLock)
			{
				return Utility.AreEqual(signature, KeyedHashAlgorithm.ComputeHash(input));
			}
		}
		catch
		{
			base.CryptoProviderCache?.TryRemove(this);
			throw;
		}
	}

	public bool Verify(byte[] input, byte[] signature, int length)
	{
		if (input == null || input.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("input");
		}
		if (signature == null || signature.Length == 0)
		{
			throw LogHelper.LogArgumentNullException("signature");
		}
		if (length < 1)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX10655: 'length' must be greater than 1: '{0}'", length)));
		}
		if (_disposed)
		{
			base.CryptoProviderCache?.TryRemove(this);
			throw LogHelper.LogExceptionMessage(new ObjectDisposedException(typeof(SymmetricSignatureProvider).ToString()));
		}
		LogHelper.LogInformation("IDX10643: Comparing the signature created over the input with the token signature: '{0}'.", input);
		try
		{
			lock (_verifyLock)
			{
				return Utility.AreEqual(signature, KeyedHashAlgorithm.ComputeHash(input), length);
			}
		}
		catch
		{
			base.CryptoProviderCache?.TryRemove(this);
			throw;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			_disposed = true;
			base.CryptoProviderCache?.TryRemove(this);
			if (disposing && _keyedHash != null)
			{
				_keyedHash.Dispose();
				_keyedHash = null;
			}
		}
	}
}
public class TokenContext
{
	public Guid ActivityId { get; set; } = Guid.Empty;

	public bool CaptureLogs { get; set; }

	public ICollection<string> Logs { get; private set; } = new Collection<string>();

	public TokenContext()
	{
	}

	public TokenContext(Guid activityId)
	{
		ActivityId = activityId;
	}
}
public abstract class TokenHandler
{
	private int _defaultTokenLifetimeInMinutes = DefaultTokenLifetimeInMinutes;

	private int _maximumTokenSizeInBytes = 256000;

	public static readonly int DefaultTokenLifetimeInMinutes = 60;

	public virtual int MaximumTokenSizeInBytes
	{
		get
		{
			return _maximumTokenSizeInBytes;
		}
		set
		{
			if (value < 1)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("value", LogHelper.FormatInvariant("IDX10101: MaximumTokenSizeInBytes must be greater than zero. value: '{0}'", value)));
			}
			_maximumTokenSizeInBytes = value;
		}
	}

	[DefaultValue(true)]
	public bool SetDefaultTimesOnTokenCreation { get; set; } = true;

	public int TokenLifetimeInMinutes
	{
		get
		{
			return _defaultTokenLifetimeInMinutes;
		}
		set
		{
			if (value < 1)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("value", LogHelper.FormatInvariant("IDX10104: TokenLifetimeInMinutes must be greater than zero. value: '{0}'", value)));
			}
			_defaultTokenLifetimeInMinutes = value;
		}
	}
}
public delegate bool AudienceValidator(IEnumerable<string> audiences, SecurityToken securityToken, TokenValidationParameters validationParameters);
public delegate IEnumerable<SecurityKey> IssuerSigningKeyResolver(string token, SecurityToken securityToken, string kid, TokenValidationParameters validationParameters);
public delegate bool IssuerSigningKeyValidator(SecurityKey securityKey, SecurityToken securityToken, TokenValidationParameters validationParameters);
public delegate string IssuerValidator(string issuer, SecurityToken securityToken, TokenValidationParameters validationParameters);
public delegate bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters);
public delegate bool TokenReplayValidator(DateTime? expirationTime, string securityToken, TokenValidationParameters validationParameters);
public delegate SecurityToken SignatureValidator(string token, TokenValidationParameters validationParameters);
public delegate SecurityToken TokenReader(string token, TokenValidationParameters validationParameters);
public delegate IEnumerable<SecurityKey> TokenDecryptionKeyResolver(string token, SecurityToken securityToken, string kid, TokenValidationParameters validationParameters);
public class TokenValidationParameters
{
	private string _authenticationType;

	private TimeSpan _clockSkew = DefaultClockSkew;

	private string _nameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

	private string _roleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

	public static readonly string DefaultAuthenticationType = "AuthenticationTypes.Federation";

	public static readonly TimeSpan DefaultClockSkew = TimeSpan.FromSeconds(300.0);

	public const int DefaultMaximumTokenSizeInBytes = 256000;

	public TokenValidationParameters ActorValidationParameters { get; set; }

	public AudienceValidator AudienceValidator { get; set; }

	public string AuthenticationType
	{
		get
		{
			return _authenticationType;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw LogHelper.LogExceptionMessage(new ArgumentNullException("AuthenticationType"));
			}
			_authenticationType = value;
		}
	}

	[DefaultValue(300)]
	public TimeSpan ClockSkew
	{
		get
		{
			return _clockSkew;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("value", LogHelper.FormatInvariant("IDX10100: ClockSkew must be greater than TimeSpan.Zero. value: '{0}'", value)));
			}
			_clockSkew = value;
		}
	}

	public CryptoProviderFactory CryptoProviderFactory { get; set; }

	public IssuerSigningKeyValidator IssuerSigningKeyValidator { get; set; }

	public SecurityKey IssuerSigningKey { get; set; }

	public IssuerSigningKeyResolver IssuerSigningKeyResolver { get; set; }

	public IEnumerable<SecurityKey> IssuerSigningKeys { get; set; }

	public IssuerValidator IssuerValidator { get; set; }

	public LifetimeValidator LifetimeValidator { get; set; }

	public string NameClaimType
	{
		get
		{
			return _nameClaimType;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("value", "IDX10102: NameClaimType cannot be null or whitespace."));
			}
			_nameClaimType = value;
		}
	}

	public string RoleClaimType
	{
		get
		{
			return _roleClaimType;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("value", "IDX10103: RoleClaimType cannot be null or whitespace."));
			}
			_roleClaimType = value;
		}
	}

	public Func<SecurityToken, string, string> NameClaimTypeRetriever { get; set; }

	public IDictionary<string, object> PropertyBag { get; set; }

	[DefaultValue(true)]
	public bool RequireAudience { get; set; }

	[DefaultValue(true)]
	public bool RequireExpirationTime { get; set; }

	[DefaultValue(true)]
	public bool RequireSignedTokens { get; set; }

	public Func<SecurityToken, string, string> RoleClaimTypeRetriever { get; set; }

	[DefaultValue(false)]
	public bool SaveSigninToken { get; set; }

	public SignatureValidator SignatureValidator { get; set; }

	public SecurityKey TokenDecryptionKey { get; set; }

	public TokenDecryptionKeyResolver TokenDecryptionKeyResolver { get; set; }

	public IEnumerable<SecurityKey> TokenDecryptionKeys { get; set; }

	public TokenReader TokenReader { get; set; }

	public ITokenReplayCache TokenReplayCache { get; set; }

	public TokenReplayValidator TokenReplayValidator { get; set; }

	[DefaultValue(false)]
	public bool ValidateActor { get; set; }

	[DefaultValue(true)]
	public bool ValidateAudience { get; set; }

	[DefaultValue(true)]
	public bool ValidateIssuer { get; set; }

	[DefaultValue(true)]
	public bool ValidateLifetime { get; set; }

	[DefaultValue(false)]
	public bool ValidateIssuerSigningKey { get; set; }

	[DefaultValue(false)]
	public bool ValidateTokenReplay { get; set; }

	public string ValidAudience { get; set; }

	public IEnumerable<string> ValidAudiences { get; set; }

	public string ValidIssuer { get; set; }

	public IEnumerable<string> ValidIssuers { get; set; }

	public IEnumerable<string> ValidTypes { get; set; }

	protected TokenValidationParameters(TokenValidationParameters other)
	{
		if (other == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentNullException("other"));
		}
		ActorValidationParameters = other.ActorValidationParameters?.Clone();
		AudienceValidator = other.AudienceValidator;
		_authenticationType = other._authenticationType;
		ClockSkew = other.ClockSkew;
		CryptoProviderFactory = other.CryptoProviderFactory;
		IssuerSigningKey = other.IssuerSigningKey;
		IssuerSigningKeyResolver = other.IssuerSigningKeyResolver;
		IssuerSigningKeys = other.IssuerSigningKeys;
		IssuerSigningKeyValidator = other.IssuerSigningKeyValidator;
		IssuerValidator = other.IssuerValidator;
		LifetimeValidator = other.LifetimeValidator;
		TokenReplayValidator = other.TokenReplayValidator;
		NameClaimType = other.NameClaimType;
		NameClaimTypeRetriever = other.NameClaimTypeRetriever;
		PropertyBag = other.PropertyBag;
		RequireAudience = other.RequireAudience;
		RequireExpirationTime = other.RequireExpirationTime;
		RequireSignedTokens = other.RequireSignedTokens;
		RoleClaimType = other.RoleClaimType;
		RoleClaimTypeRetriever = other.RoleClaimTypeRetriever;
		SaveSigninToken = other.SaveSigninToken;
		SignatureValidator = other.SignatureValidator;
		TokenDecryptionKey = other.TokenDecryptionKey;
		TokenDecryptionKeyResolver = other.TokenDecryptionKeyResolver;
		TokenDecryptionKeys = other.TokenDecryptionKeys;
		TokenReader = other.TokenReader;
		TokenReplayCache = other.TokenReplayCache;
		ValidateActor = other.ValidateActor;
		ValidateAudience = other.ValidateAudience;
		ValidateIssuer = other.ValidateIssuer;
		ValidateIssuerSigningKey = other.ValidateIssuerSigningKey;
		ValidateLifetime = other.ValidateLifetime;
		ValidateTokenReplay = other.ValidateTokenReplay;
		ValidAudience = other.ValidAudience;
		ValidAudiences = other.ValidAudiences;
		ValidIssuer = other.ValidIssuer;
		ValidIssuers = other.ValidIssuers;
	}

	public TokenValidationParameters()
	{
		RequireExpirationTime = true;
		RequireSignedTokens = true;
		RequireAudience = true;
		SaveSigninToken = false;
		ValidateActor = false;
		ValidateAudience = true;
		ValidateIssuer = true;
		ValidateIssuerSigningKey = false;
		ValidateLifetime = true;
		ValidateTokenReplay = false;
	}

	public virtual TokenValidationParameters Clone()
	{
		return new TokenValidationParameters(this);
	}

	public virtual ClaimsIdentity CreateClaimsIdentity(SecurityToken securityToken, string issuer)
	{
		string text = null;
		text = ((NameClaimTypeRetriever == null) ? NameClaimType : NameClaimTypeRetriever(securityToken, issuer));
		string text2 = null;
		text2 = ((RoleClaimTypeRetriever == null) ? RoleClaimType : RoleClaimTypeRetriever(securityToken, issuer));
		LogHelper.LogInformation("IDX10245: Creating claims identity from the validated token: '{0}'.", securityToken);
		return new ClaimsIdentity(AuthenticationType ?? DefaultAuthenticationType, text ?? "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", text2 ?? "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
	}
}
public static class UniqueId
{
	private const int RandomSaltSize = 16;

	private const string NcNamePrefix = "_";

	private const string UuidUriPrefix = "urn:uuid:";

	private static readonly string reusableUuid = GetRandomUuid();

	private static readonly string optimizedNcNamePrefix = "_" + reusableUuid + "-";

	public static string CreateUniqueId()
	{
		return optimizedNcNamePrefix + GetNextId();
	}

	public static string CreateUniqueId(string prefix)
	{
		if (string.IsNullOrEmpty(prefix))
		{
			throw LogHelper.LogArgumentNullException("prefix");
		}
		return prefix + reusableUuid + "-" + GetNextId();
	}

	public static string CreateRandomId()
	{
		return "_" + GetRandomUuid();
	}

	public static string CreateRandomId(string prefix)
	{
		if (string.IsNullOrEmpty(prefix))
		{
			throw LogHelper.LogArgumentNullException("prefix");
		}
		return prefix + GetRandomUuid();
	}

	public static Uri CreateRandomUri()
	{
		return new Uri("urn:uuid:" + GetRandomUuid());
	}

	private static string GetNextId()
	{
		RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
		byte[] array = new byte[16];
		randomNumberGenerator.GetBytes(array);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.AppendFormat("{0:X2}", array[i]);
		}
		return stringBuilder.ToString();
	}

	private static string GetRandomUuid()
	{
		return Guid.NewGuid().ToString("D");
	}
}
public static class Utility
{
	public const string Empty = "empty";

	public const string Null = "null";

	public static byte[] CloneByteArray(this byte[] src)
	{
		return (byte[])src.Clone();
	}

	internal static string SerializeAsSingleCommaDelimitedString(IEnumerable<string> strings)
	{
		if (strings == null)
		{
			return "null";
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		foreach (string @string in strings)
		{
			if (flag)
			{
				stringBuilder.AppendFormat("{0}", @string ?? "null");
				flag = false;
			}
			else
			{
				stringBuilder.AppendFormat(", {0}", @string ?? "null");
			}
		}
		if (flag)
		{
			return "empty";
		}
		return stringBuilder.ToString();
	}

	public static bool IsHttps(string address)
	{
		if (string.IsNullOrEmpty(address))
		{
			return false;
		}
		try
		{
			new Uri(address);
			return IsHttps(new Uri(address));
		}
		catch (UriFormatException)
		{
			return false;
		}
	}

	public static bool IsHttps(Uri uri)
	{
		if (uri == null)
		{
			return false;
		}
		return uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static bool AreEqual(byte[] a, byte[] b)
	{
		byte[] array = new byte[32]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
			20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
			30, 31
		};
		byte[] array2 = new byte[32]
		{
			31, 30, 29, 28, 27, 26, 25, 24, 23, 22,
			21, 20, 19, 18, 17, 16, 15, 14, 13, 12,
			11, 10, 9, 8, 7, 6, 5, 4, 3, 2,
			1, 0
		};
		int num = 0;
		byte[] array3;
		byte[] array4;
		if (a == null || b == null || a.Length != b.Length)
		{
			array3 = array;
			array4 = array2;
		}
		else
		{
			array3 = a;
			array4 = b;
		}
		for (int i = 0; i < array3.Length; i++)
		{
			num |= array3[i] ^ array4[i];
		}
		return num == 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	internal static bool AreEqual(byte[] a, byte[] b, int length)
	{
		byte[] array = new byte[32]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
			20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
			30, 31
		};
		byte[] array2 = new byte[32]
		{
			31, 30, 29, 28, 27, 26, 25, 24, 23, 22,
			21, 20, 19, 18, 17, 16, 15, 14, 13, 12,
			11, 10, 9, 8, 7, 6, 5, 4, 3, 2,
			1, 0
		};
		int num = 0;
		int num2 = 0;
		byte[] array3;
		byte[] array4;
		if (a == null || b == null || a.Length < length || b.Length < length)
		{
			array3 = array;
			array4 = array2;
			num2 = array3.Length;
		}
		else
		{
			array3 = a;
			array4 = b;
			num2 = length;
		}
		for (int i = 0; i < num2; i++)
		{
			num |= array3[i] ^ array4[i];
		}
		return num == 0;
	}

	internal static byte[] ConvertToBigEndian(long i)
	{
		byte[] bytes = BitConverter.GetBytes(i);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse((Array)bytes);
		}
		return bytes;
	}

	internal static byte[] Xor(byte[] a, byte[] b, int offset, bool inPlace)
	{
		if (inPlace)
		{
			for (int i = 0; i < a.Length; i++)
			{
				a[i] ^= b[offset + i];
			}
			return a;
		}
		byte[] array = new byte[a.Length];
		for (int j = 0; j < a.Length; j++)
		{
			array[j] = (byte)(a[j] ^ b[offset + j]);
		}
		return array;
	}

	internal static void Zero(byte[] byteArray)
	{
		for (int i = 0; i < byteArray.Length; i++)
		{
			byteArray[i] = 0;
		}
	}
}
public static class Validators
{
	public static void ValidateAudience(IEnumerable<string> audiences, SecurityToken securityToken, TokenValidationParameters validationParameters)
	{
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (!validationParameters.ValidateAudience)
		{
			LogHelper.LogWarning("IDX10233: ValidateAudience property on ValidationParameters is set to false. Exiting without validating the audience.");
			return;
		}
		if (validationParameters.AudienceValidator != null)
		{
			if (!validationParameters.AudienceValidator(audiences, securityToken, validationParameters))
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidAudienceException(LogHelper.FormatInvariant("IDX10231: Audience validation failed. Delegate returned false, securitytoken: '{0}'.", securityToken))
				{
					InvalidAudience = Utility.SerializeAsSingleCommaDelimitedString(audiences)
				});
			}
			return;
		}
		if (audiences == null)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidAudienceException("IDX10207: Unable to validate audience. The 'audiences' parameter is null.")
			{
				InvalidAudience = null
			});
		}
		if (string.IsNullOrWhiteSpace(validationParameters.ValidAudience) && validationParameters.ValidAudiences == null)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidAudienceException("IDX10208: Unable to validate audience. validationParameters.ValidAudience is null or whitespace and validationParameters.ValidAudiences is null.")
			{
				InvalidAudience = Utility.SerializeAsSingleCommaDelimitedString(audiences)
			});
		}
		foreach (string audience in audiences)
		{
			if (string.IsNullOrWhiteSpace(audience))
			{
				continue;
			}
			if (validationParameters.ValidAudiences != null)
			{
				foreach (string validAudience in validationParameters.ValidAudiences)
				{
					if (string.Equals(audience, validAudience, StringComparison.Ordinal))
					{
						LogHelper.LogInformation("IDX10234: Audience Validated.Audience: '{0}'", audience);
						return;
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(validationParameters.ValidAudience) && string.Equals(audience, validationParameters.ValidAudience, StringComparison.Ordinal))
			{
				LogHelper.LogInformation("IDX10234: Audience Validated.Audience: '{0}'", audience);
				return;
			}
		}
		throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidAudienceException(LogHelper.FormatInvariant("IDX10214: Audience validation failed. Audiences: '{0}'. Did not match: validationParameters.ValidAudience: '{1}' or validationParameters.ValidAudiences: '{2}'.", Utility.SerializeAsSingleCommaDelimitedString(audiences), validationParameters.ValidAudience ?? "null", Utility.SerializeAsSingleCommaDelimitedString(validationParameters.ValidAudiences)))
		{
			InvalidAudience = Utility.SerializeAsSingleCommaDelimitedString(audiences)
		});
	}

	public static string ValidateIssuer(string issuer, SecurityToken securityToken, TokenValidationParameters validationParameters)
	{
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (!validationParameters.ValidateIssuer)
		{
			LogHelper.LogInformation("IDX10235: ValidateIssuer property on ValidationParameters is set to false. Exiting without validating the issuer.");
			return issuer;
		}
		if (validationParameters.IssuerValidator != null)
		{
			return validationParameters.IssuerValidator(issuer, securityToken, validationParameters);
		}
		if (string.IsNullOrWhiteSpace(issuer))
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidIssuerException("IDX10211: Unable to validate issuer. The 'issuer' parameter is null or whitespace")
			{
				InvalidIssuer = issuer
			});
		}
		if (string.IsNullOrWhiteSpace(validationParameters.ValidIssuer) && validationParameters.ValidIssuers == null)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidIssuerException("IDX10204: Unable to validate issuer. validationParameters.ValidIssuer is null or whitespace AND validationParameters.ValidIssuers is null.")
			{
				InvalidIssuer = issuer
			});
		}
		if (string.Equals(validationParameters.ValidIssuer, issuer, StringComparison.Ordinal))
		{
			LogHelper.LogInformation("IDX10236: Issuer Validated.Issuer: '{0}'", issuer);
			return issuer;
		}
		if (validationParameters.ValidIssuers != null)
		{
			foreach (string validIssuer in validationParameters.ValidIssuers)
			{
				if (string.IsNullOrEmpty(validIssuer))
				{
					LogHelper.LogInformation("IDX10235: ValidateIssuer property on ValidationParameters is set to false. Exiting without validating the issuer.");
				}
				else if (string.Equals(validIssuer, issuer, StringComparison.Ordinal))
				{
					LogHelper.LogInformation("IDX10236: Issuer Validated.Issuer: '{0}'", issuer);
					return issuer;
				}
			}
		}
		throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidIssuerException(LogHelper.FormatInvariant("IDX10205: Issuer validation failed. Issuer: '{0}'. Did not match: validationParameters.ValidIssuer: '{1}' or validationParameters.ValidIssuers: '{2}'.", issuer, validationParameters.ValidIssuer ?? "null", Utility.SerializeAsSingleCommaDelimitedString(validationParameters.ValidIssuers)))
		{
			InvalidIssuer = issuer
		});
	}

	public static void ValidateIssuerSecurityKey(SecurityKey securityKey, SecurityToken securityToken, TokenValidationParameters validationParameters)
	{
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (!validationParameters.ValidateIssuerSigningKey)
		{
			LogHelper.LogInformation("IDX10237: ValidateIssuerSigningKey property on ValidationParameters is set to false. Exiting without validating the issuer signing key.");
			return;
		}
		if (validationParameters.IssuerSigningKeyValidator != null && !validationParameters.IssuerSigningKeyValidator(securityKey, securityToken, validationParameters))
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSigningKeyException(LogHelper.FormatInvariant("IDX10232: IssuerSigningKey validation failed. Delegate returned false, securityKey: '{0}'.", securityKey))
			{
				SigningKey = securityKey
			});
		}
		if (!validationParameters.RequireSignedTokens && securityKey == null)
		{
			LogHelper.LogInformation("IDX10252: RequireSignedTokens property on ValidationParameters is set to false and the issuer signing key is null. Exiting without validating the issuer signing key.");
			return;
		}
		if (securityKey == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentNullException("securityKey", "IDX10253: RequireSignedTokens property on ValidationParameters is set to true, but the issuer signing key is null."));
		}
		if (securityToken == null)
		{
			throw LogHelper.LogArgumentNullException("securityToken");
		}
		X509Certificate2 x509Certificate;
		if ((x509Certificate = (securityKey as X509SecurityKey)?.Certificate) != null)
		{
			DateTime utcNow = DateTime.UtcNow;
			DateTime dateTime = x509Certificate.NotBefore.ToUniversalTime();
			DateTime dateTime2 = x509Certificate.NotAfter.ToUniversalTime();
			if (dateTime > DateTimeUtil.Add(utcNow, validationParameters.ClockSkew))
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSigningKeyException(LogHelper.FormatInvariant("IDX10248: X509SecurityKey validation failed. The associated certificate is not yet valid. ValidFrom (UTC): '{0}', Current time (UTC): '{1}'.", dateTime, utcNow)));
			}
			LogHelper.LogInformation("IDX10250: The associated certificate is valid. ValidFrom (UTC): '{0}', Current time (UTC): '{1}'.", dateTime, utcNow);
			if (dateTime2 < DateTimeUtil.Add(utcNow, validationParameters.ClockSkew.Negate()))
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidSigningKeyException(LogHelper.FormatInvariant("IDX10249: X509SecurityKey validation failed. The associated certificate has expired. ValidTo (UTC): '{0}', Current time (UTC): '{1}'.", dateTime2, utcNow)));
			}
			LogHelper.LogInformation("IDX10251: The associated certificate is valid. ValidTo (UTC): '{0}', Current time (UTC): '{1}'.", dateTime2, utcNow);
		}
	}

	public static void ValidateLifetime(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
	{
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (!validationParameters.ValidateLifetime)
		{
			LogHelper.LogInformation("IDX10238: ValidateLifetime property on ValidationParameters is set to false. Exiting without validating the lifetime.");
			return;
		}
		if (validationParameters.LifetimeValidator != null)
		{
			if (validationParameters.LifetimeValidator(notBefore, expires, securityToken, validationParameters))
			{
				return;
			}
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidLifetimeException(LogHelper.FormatInvariant("IDX10230: Lifetime validation failed. Delegate returned false, securitytoken: '{0}'.", securityToken))
			{
				NotBefore = notBefore,
				Expires = expires
			});
		}
		if (!expires.HasValue && validationParameters.RequireExpirationTime)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenNoExpirationException(LogHelper.FormatInvariant("IDX10225: Lifetime validation failed. The token is missing an Expiration Time. Tokentype: '{0}'.", (securityToken == null) ? "null" : securityToken.GetType().ToString())));
		}
		if (notBefore.HasValue && expires.HasValue && notBefore.Value > expires.Value)
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidLifetimeException(LogHelper.FormatInvariant("IDX10224: Lifetime validation failed. The NotBefore: '{0}' is after Expires: '{1}'.", notBefore.Value, expires.Value))
			{
				NotBefore = notBefore,
				Expires = expires
			});
		}
		DateTime utcNow = DateTime.UtcNow;
		if (notBefore.HasValue && notBefore.Value > DateTimeUtil.Add(utcNow, validationParameters.ClockSkew))
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenNotYetValidException(LogHelper.FormatInvariant("IDX10222: Lifetime validation failed. The token is not yet valid. ValidFrom: '{0}', Current time: '{1}'.", notBefore.Value, utcNow))
			{
				NotBefore = notBefore.Value
			});
		}
		if (expires.HasValue && expires.Value < DateTimeUtil.Add(utcNow, validationParameters.ClockSkew.Negate()))
		{
			throw LogHelper.LogExceptionMessage(new SecurityTokenExpiredException(LogHelper.FormatInvariant("IDX10223: Lifetime validation failed. The token is expired. ValidTo: '{0}', Current time: '{1}'.", expires.Value, utcNow))
			{
				Expires = expires.Value
			});
		}
		LogHelper.LogInformation("IDX10239: Lifetime of the token is valid.");
	}

	public static void ValidateTokenReplay(DateTime? expirationTime, string securityToken, TokenValidationParameters validationParameters)
	{
		if (string.IsNullOrWhiteSpace(securityToken))
		{
			throw LogHelper.LogArgumentNullException("securityToken");
		}
		if (validationParameters == null)
		{
			throw LogHelper.LogArgumentNullException("validationParameters");
		}
		if (!validationParameters.ValidateTokenReplay)
		{
			LogHelper.LogInformation("IDX10246: ValidateTokenReplay property on ValidationParameters is set to false. Exiting without validating the token replay.");
			return;
		}
		if (validationParameters.TokenReplayValidator != null)
		{
			if (validationParameters.TokenReplayValidator(expirationTime, securityToken, validationParameters))
			{
				return;
			}
			throw LogHelper.LogExceptionMessage(new SecurityTokenReplayDetectedException(LogHelper.FormatInvariant("IDX10228: The securityToken has previously been validated, securityToken: '{0}'.", securityToken)));
		}
		if (validationParameters.TokenReplayCache != null)
		{
			if (!expirationTime.HasValue)
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenNoExpirationException(LogHelper.FormatInvariant("IDX10227: TokenValidationParameters.TokenReplayCache is not null, indicating to check for token replay but the security token has no expiration time: token '{0}'.", securityToken)));
			}
			if (validationParameters.TokenReplayCache.TryFind(securityToken))
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenReplayDetectedException(LogHelper.FormatInvariant("IDX10228: The securityToken has previously been validated, securityToken: '{0}'.", securityToken)));
			}
			if (!validationParameters.TokenReplayCache.TryAdd(securityToken, expirationTime.Value))
			{
				throw LogHelper.LogExceptionMessage(new SecurityTokenReplayAddFailedException(LogHelper.FormatInvariant("IDX10229: TokenValidationParameters.TokenReplayCache was unable to add the securityToken: '{0}'.", securityToken)));
			}
		}
		LogHelper.LogInformation("IDX10240: No token replay is detected.");
	}

	public static void ValidateTokenReplay(string securityToken, DateTime? expirationTime, TokenValidationParameters validationParameters)
	{
		ValidateTokenReplay(expirationTime, securityToken, validationParameters);
	}
}
public class X509EncryptingCredentials : EncryptingCredentials
{
	public X509Certificate2 Certificate { get; private set; }

	public X509EncryptingCredentials(X509Certificate2 certificate)
		: this(certificate, "http://www.w3.org/2001/04/xmlenc#rsa-oaep", "A128CBC-HS256")
	{
	}

	public X509EncryptingCredentials(X509Certificate2 certificate, string keyWrapAlgorithm, string dataEncryptionAlgorithm)
		: base(certificate, keyWrapAlgorithm, dataEncryptionAlgorithm)
	{
		Certificate = certificate;
	}
}
public class X509SecurityKey : AsymmetricSecurityKey
{
	private AsymmetricAlgorithm _privateKey;

	private bool _privateKeyAvailabilityDetermined;

	private AsymmetricAlgorithm _publicKey;

	private object _thisLock = new object();

	public override int KeySize => PublicKey.KeySize;

	public string X5t { get; }

	public AsymmetricAlgorithm PrivateKey
	{
		get
		{
			if (!_privateKeyAvailabilityDetermined)
			{
				lock (ThisLock)
				{
					if (!_privateKeyAvailabilityDetermined)
					{
						_privateKey = Certificate.GetRSAPrivateKey();
						_privateKeyAvailabilityDetermined = true;
					}
				}
			}
			return _privateKey;
		}
	}

	public AsymmetricAlgorithm PublicKey
	{
		get
		{
			if (_publicKey == null)
			{
				lock (ThisLock)
				{
					if (_publicKey == null)
					{
						_publicKey = Certificate.GetRSAPublicKey();
					}
				}
			}
			return _publicKey;
		}
	}

	private object ThisLock => _thisLock;

	[Obsolete("HasPrivateKey method is deprecated, please use PrivateKeyStatus.")]
	public override bool HasPrivateKey => PrivateKey != null;

	public override PrivateKeyStatus PrivateKeyStatus
	{
		get
		{
			if (PrivateKey != null)
			{
				return PrivateKeyStatus.Exists;
			}
			return PrivateKeyStatus.DoesNotExist;
		}
	}

	public X509Certificate2 Certificate { get; private set; }

	internal X509SecurityKey(JsonWebKey webKey)
		: base(webKey)
	{
		Certificate = new X509Certificate2(Convert.FromBase64String(webKey.X5c[0]));
		X5t = Base64UrlEncoder.Encode(Certificate.GetCertHash());
		webKey.ConvertedSecurityKey = this;
	}

	public X509SecurityKey(X509Certificate2 certificate)
	{
		Certificate = certificate ?? throw LogHelper.LogArgumentNullException("certificate");
		KeyId = certificate.Thumbprint;
		X5t = Base64UrlEncoder.Encode(certificate.GetCertHash());
	}

	public X509SecurityKey(X509Certificate2 certificate, string keyId)
	{
		Certificate = certificate ?? throw LogHelper.LogArgumentNullException("certificate");
		if (string.IsNullOrEmpty(keyId))
		{
			throw LogHelper.LogArgumentNullException("keyId");
		}
		KeyId = keyId;
		X5t = Base64UrlEncoder.Encode(certificate.GetCertHash());
	}

	public override bool Equals(object obj)
	{
		if (!(obj is X509SecurityKey x509SecurityKey))
		{
			return false;
		}
		return x509SecurityKey.Certificate.Thumbprint.ToString() == Certificate.Thumbprint.ToString();
	}

	public override int GetHashCode()
	{
		return Certificate.GetHashCode();
	}
}
public class X509SigningCredentials : SigningCredentials
{
	public X509Certificate2 Certificate { get; private set; }

	public X509SigningCredentials(X509Certificate2 certificate)
		: base(certificate)
	{
		Certificate = certificate;
	}

	public X509SigningCredentials(X509Certificate2 certificate, string algorithm)
		: base(certificate, algorithm)
	{
		Certificate = certificate;
	}
}
