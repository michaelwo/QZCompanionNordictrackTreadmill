using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using Android.Runtime;
using Java.Math;
using Java.Security;
using Java.Security.Interfaces;
using Java.Security.Spec;
using Javax.Crypto;
using Javax.Crypto.Spec;
using PCLCrypto.Formatters;
using Validation;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: ResourceDesigner("PCLCrypto.Resource", IsApplication = false)]
[assembly: AssemblyFileVersion("1.0.2.15130")]
[assembly: AssemblyInformationalVersion("1.0.2+build.15130.b60fe8a805")]
[assembly: AssemblyTitle("PCLCrypto")]
[assembly: AssemblyProduct("PCLCrypto")]
[assembly: AssemblyCopyright("Copyright © 2014 Andrew Arnott")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: TargetFramework("MonoAndroid,Version=v2.3", FrameworkDisplayName = "Xamarin.Android v2.3 Support")]
[assembly: AssemblyVersion("1.0.0.0")]
internal sealed class ThisAssembly
{
	internal const string AssemblyVersion = "1.0";

	internal const string AssemblyFileVersion = "1.0.2.15130";

	internal const string AssemblyInformationalVersion = "1.0.2+build.15130.b60fe8a805";

	internal const string AssemblyTitle = "PCLCrypto";

	internal const string AssemblyProduct = "PCLCrypto";

	internal const string AssemblyCopyright = "Copyright © 2014 Andrew Arnott";

	private ThisAssembly()
	{
	}
}
namespace PCLCrypto
{
	internal class JavaCryptographicHashMac : CryptographicHash
	{
		protected Mac Algorithm { get; private set; }

		internal JavaCryptographicHashMac(Mac algorithm)
		{
			Requires.NotNull(algorithm, "algorithm");
			Algorithm = algorithm;
		}

		public override void Append(byte[] data)
		{
			Algorithm.Update(data);
		}

		public override byte[] GetValueAndReset()
		{
			byte[] result = Algorithm.DoFinal();
			Algorithm.Reset();
			return result;
		}

		protected override int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			Algorithm.Update(inputBuffer, inputOffset, inputCount);
			if (outputBuffer != null)
			{
				Array.Copy(inputBuffer, inputOffset, outputBuffer, outputOffset, inputCount);
			}
			return inputCount;
		}

		protected override byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			Algorithm.Update(inputBuffer, inputOffset, inputCount);
			if (inputCount == inputBuffer.Length)
			{
				return inputBuffer;
			}
			byte[] array = new byte[inputCount];
			Array.Copy(inputBuffer, inputOffset, array, 0, inputCount);
			return array;
		}
	}
	internal class JavaCryptographicHash : CryptographicHash
	{
		protected MessageDigest Algorithm { get; private set; }

		internal JavaCryptographicHash(MessageDigest algorithm)
		{
			Requires.NotNull(algorithm, "algorithm");
			Algorithm = algorithm;
		}

		public override void Append(byte[] data)
		{
			Algorithm.Update(data);
		}

		public override byte[] GetValueAndReset()
		{
			byte[] result = Algorithm.Digest();
			Algorithm.Reset();
			return result;
		}

		protected override int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			Algorithm.Update(inputBuffer, inputOffset, inputCount);
			if (outputBuffer != null)
			{
				Array.Copy(inputBuffer, inputOffset, outputBuffer, outputOffset, inputCount);
			}
			return inputCount;
		}

		protected override byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			Algorithm.Update(inputBuffer, inputOffset, inputCount);
			if (inputCount == inputBuffer.Length)
			{
				return inputBuffer;
			}
			byte[] array = new byte[inputCount];
			Array.Copy(inputBuffer, inputOffset, array, 0, inputCount);
			return array;
		}
	}
	internal class MacAlgorithmProvider : IMacAlgorithmProvider
	{
		private readonly MacAlgorithm algorithm;

		public MacAlgorithm Algorithm => algorithm;

		public int MacLength
		{
			get
			{
				using Mac mac = GetAlgorithm(Algorithm);
				return mac.MacLength;
			}
		}

		internal MacAlgorithmProvider(MacAlgorithm algorithm)
		{
			this.algorithm = algorithm;
		}

		public CryptographicHash CreateHash(byte[] keyMaterial)
		{
			Requires.NotNull(keyMaterial, "keyMaterial");
			Mac mac = GetAlgorithm(Algorithm);
			mac.Init(GetSecretKey(Algorithm, keyMaterial));
			return new JavaCryptographicHashMac(mac);
		}

		public ICryptographicKey CreateKey(byte[] keyMaterial)
		{
			return new MacCryptographicKey(Algorithm, keyMaterial);
		}

		internal static Mac GetAlgorithm(MacAlgorithm algorithm)
		{
			return Mac.GetInstance(MacAlgorithmProviderFactory.GetAlgorithmName(algorithm));
		}

		internal static SecretKeySpec GetSecretKey(MacAlgorithm algorithm, byte[] keyMaterial)
		{
			string algorithmName = MacAlgorithmProviderFactory.GetAlgorithmName(algorithm);
			return new SecretKeySpec(keyMaterial, algorithmName);
		}
	}
	[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
	public class Resource
	{
		public class Attribute
		{
			static Attribute()
			{
				ResourceIdManager.UpdateIdValues();
			}

			private Attribute()
			{
			}
		}

		public class String
		{
			public static int ApplicationName;

			public static int Hello;

			static String()
			{
				ApplicationName = 2130837505;
				Hello = 2130837504;
				ResourceIdManager.UpdateIdValues();
			}

			private String()
			{
			}
		}

		static Resource()
		{
			ResourceIdManager.UpdateIdValues();
		}
	}
	internal class RsaAsymmetricKeyAlgorithmProvider : IAsymmetricKeyAlgorithmProvider
	{
		private readonly AsymmetricAlgorithm algorithm;

		public AsymmetricAlgorithm Algorithm => algorithm;

		public RsaAsymmetricKeyAlgorithmProvider(AsymmetricAlgorithm algorithm)
		{
			this.algorithm = algorithm;
		}

		public ICryptographicKey CreateKeyPair(int keySize)
		{
			Requires.Range(keySize > 0, "keySize");
			KeyPairGenerator instance = KeyPairGenerator.GetInstance("RSA");
			instance.Initialize(keySize);
			KeyPair keyPair = instance.GenerateKeyPair();
			IRSAPrivateCrtKey iRSAPrivateCrtKey = keyPair.Private.JavaCast<IRSAPrivateCrtKey>();
			RSAParameters parameters = new RSAParameters
			{
				Modulus = iRSAPrivateCrtKey.Modulus.ToByteArray(),
				Exponent = iRSAPrivateCrtKey.PublicExponent.ToByteArray(),
				P = iRSAPrivateCrtKey.PrimeP.ToByteArray(),
				Q = iRSAPrivateCrtKey.PrimeQ.ToByteArray(),
				DP = iRSAPrivateCrtKey.PrimeExponentP.ToByteArray(),
				DQ = iRSAPrivateCrtKey.PrimeExponentQ.ToByteArray(),
				InverseQ = iRSAPrivateCrtKey.CrtCoefficient.ToByteArray(),
				D = iRSAPrivateCrtKey.PrivateExponent.ToByteArray()
			};
			return new RsaCryptographicKey(keyPair.Public, keyPair.Private, parameters, algorithm);
		}

		public ICryptographicKey ImportKeyPair(byte[] keyBlob, CryptographicPrivateKeyBlobType blobType = CryptographicPrivateKeyBlobType.Pkcs8RawPrivateKeyInfo)
		{
			Requires.NotNull(keyBlob, "keyBlob");
			RSAParameters parameters = KeyFormatter.GetFormatter(blobType).Read(keyBlob);
			RSAPrivateKeySpec keySpec = new RSAPrivateKeySpec(new BigInteger(1, parameters.Modulus), new BigInteger(1, parameters.D));
			KeyFactory instance = KeyFactory.GetInstance("RSA");
			IPrivateKey privateKey = instance.GeneratePrivate(keySpec);
			RSAPublicKeySpec keySpec2 = new RSAPublicKeySpec(privateKey.JavaCast<IRSAPrivateKey>().Modulus, new BigInteger(1, parameters.Exponent));
			return new RsaCryptographicKey(instance.GeneratePublic(keySpec2), privateKey, parameters, algorithm);
		}

		public ICryptographicKey ImportPublicKey(byte[] keyBlob, CryptographicPublicKeyBlobType blobType = CryptographicPublicKeyBlobType.X509SubjectPublicKeyInfo)
		{
			Requires.NotNull(keyBlob, "keyBlob");
			RSAParameters parameters = KeyFormatter.GetFormatter(blobType).Read(keyBlob);
			RSAPublicKeySpec keySpec = new RSAPublicKeySpec(new BigInteger(1, parameters.Modulus), new BigInteger(1, parameters.Exponent));
			return new RsaCryptographicKey(KeyFactory.GetInstance("RSA").GeneratePublic(keySpec), parameters, algorithm);
		}
	}
	internal class RsaCryptographicKey : CryptographicKey, ICryptographicKey
	{
		private readonly IRSAPublicKey publicKey;

		private readonly IRSAPrivateKey privateKey;

		private readonly AsymmetricAlgorithm algorithm;

		private readonly RSAParameters parameters;

		public int KeySize => publicKey.Modulus.BitLength();

		internal AsymmetricAlgorithm Algorithm => algorithm;

		internal RsaCryptographicKey(IPublicKey publicKey, RSAParameters parameters, AsymmetricAlgorithm algorithm)
		{
			Requires.NotNull(publicKey, "publicKey");
			this.publicKey = publicKey.JavaCast<IRSAPublicKey>();
			this.parameters = parameters;
			this.algorithm = algorithm;
		}

		internal RsaCryptographicKey(IPublicKey publicKey, IPrivateKey privateKey, RSAParameters parameters, AsymmetricAlgorithm algorithm)
		{
			Requires.NotNull(publicKey, "publicKey");
			Requires.NotNull(privateKey, "privateKey");
			this.publicKey = publicKey.JavaCast<IRSAPublicKey>();
			this.privateKey = privateKey.JavaCast<IRSAPrivateKey>();
			this.parameters = parameters;
			this.algorithm = algorithm;
		}

		public byte[] Export(CryptographicPrivateKeyBlobType blobType)
		{
			Verify.Operation(KeyFormatter.HasPrivateKey(parameters), "Private key not available.");
			return KeyFormatter.GetFormatter(blobType).Write(parameters);
		}

		public byte[] ExportPublicKey(CryptographicPublicKeyBlobType blobType)
		{
			return KeyFormatter.GetFormatter(blobType).Write(parameters, includePrivateKey: false);
		}

		protected internal override byte[] Sign(byte[] data)
		{
			using Signature signature = Signature.GetInstance(GetSignatureName(Algorithm));
			signature.InitSign(privateKey);
			signature.Update(data);
			return signature.Sign();
		}

		protected internal override bool VerifySignature(byte[] data, byte[] signature)
		{
			using Signature signature2 = Signature.GetInstance(GetSignatureName(Algorithm));
			signature2.InitVerify(publicKey);
			signature2.Update(data);
			return signature2.Verify(signature);
		}

		protected internal override byte[] SignHash(byte[] data)
		{
			throw new NotSupportedException();
		}

		protected internal override bool VerifyHash(byte[] data, byte[] signature)
		{
			throw new NotSupportedException();
		}

		protected internal override byte[] Encrypt(byte[] data, byte[] iv)
		{
			using Cipher cipher = Cipher.GetInstance(GetCipherName(Algorithm));
			cipher.Init(Javax.Crypto.CipherMode.EncryptMode, publicKey);
			return cipher.DoFinal(data);
		}

		protected internal override byte[] Decrypt(byte[] data, byte[] iv)
		{
			Verify.Operation(privateKey != null, "Private key missing.");
			using Cipher cipher = Cipher.GetInstance(GetCipherName(Algorithm));
			cipher.Init(Javax.Crypto.CipherMode.DecryptMode, privateKey);
			return cipher.DoFinal(data);
		}

		private static string GetCipherName(AsymmetricAlgorithm algorithm)
		{
			return algorithm switch
			{
				AsymmetricAlgorithm.RsaOaepSha1 => "RSA/ECB/OAEPWithSHA1AndMGF1Padding", 
				AsymmetricAlgorithm.RsaOaepSha256 => "RSA/ECB/OAEPWithSHA-256AndMGF1Padding", 
				AsymmetricAlgorithm.RsaPkcs1 => "RSA/ECB/PKCS1Padding", 
				_ => throw new NotSupportedException(), 
			};
		}

		private static string GetSignatureName(AsymmetricAlgorithm algorithm)
		{
			string hashAlgorithmName = HashAlgorithmProviderFactory.GetHashAlgorithmName(AsymmetricKeyAlgorithmProviderFactory.GetHashAlgorithmEnum(algorithm));
			switch (algorithm)
			{
			case AsymmetricAlgorithm.RsaSignPkcs1Sha1:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha256:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha384:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha512:
				return hashAlgorithmName + "withRSA";
			default:
				throw new NotSupportedException();
			}
		}
	}
	internal class SymmetricCryptographicKey : CryptographicKey, ICryptographicKey, IDisposable
	{
		private class CryptoTransformAdaptor : ICryptoTransform, IDisposable
		{
			private readonly Cipher transform;

			private readonly SymmetricAlgorithm algorithm;

			public bool CanReuseTransform => false;

			public bool CanTransformMultipleBlocks => true;

			public int InputBlockSize => SymmetricKeyAlgorithmProvider.GetBlockSize(algorithm, transform);

			public int OutputBlockSize => transform.GetOutputSize(InputBlockSize);

			internal CryptoTransformAdaptor(SymmetricAlgorithm algorithm, Cipher transform)
			{
				Requires.NotNull(transform, "transform");
				this.algorithm = algorithm;
				this.transform = transform;
			}

			public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
			{
				return transform.Update(inputBuffer, inputOffset, inputCount, outputBuffer, outputOffset);
			}

			public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
			{
				if (!algorithm.IsBlockCipher())
				{
					return transform.Update(inputBuffer, inputOffset, inputCount);
				}
				return transform.DoFinal(inputBuffer, inputOffset, inputCount);
			}

			public void Dispose()
			{
			}
		}

		private readonly SymmetricAlgorithm algorithm;

		private readonly IKey key;

		private Cipher encryptingCipher;

		private Cipher decryptingCipher;

		public int KeySize { get; private set; }

		internal SymmetricCryptographicKey(SymmetricAlgorithm algorithm, byte[] keyMaterial)
		{
			Requires.NotNull(keyMaterial, "keyMaterial");
			if (algorithm == SymmetricAlgorithm.AesCcm)
			{
				throw new NotSupportedException();
			}
			this.algorithm = algorithm;
			key = new SecretKeySpec(keyMaterial, this.algorithm.GetName().GetString());
			KeySize = keyMaterial.Length * 8;
		}

		public byte[] Export(CryptographicPrivateKeyBlobType blobType = CryptographicPrivateKeyBlobType.Pkcs8RawPrivateKeyInfo)
		{
			throw new NotSupportedException();
		}

		public byte[] ExportPublicKey(CryptographicPublicKeyBlobType blobType = CryptographicPublicKeyBlobType.X509SubjectPublicKeyInfo)
		{
			throw new NotSupportedException();
		}

		public void Dispose()
		{
			key.Dispose();
			encryptingCipher.DisposeIfNotNull();
			decryptingCipher.DisposeIfNotNull();
		}

		protected internal override byte[] Encrypt(byte[] data, byte[] iv)
		{
			bool num = algorithm.GetPadding() != SymmetricAlgorithmPadding.None;
			Requires.Argument(iv == null || algorithm.UsesIV(), "iv", "IV supplied but does not apply to this cipher.");
			InitializeCipher(Javax.Crypto.CipherMode.EncryptMode, iv, ref encryptingCipher);
			Requires.Argument(num || IsValidInputSize(data.Length), "data", "Length does not a multiple of block size and no padding is selected.");
			if (!algorithm.IsBlockCipher())
			{
				return encryptingCipher.Update(data);
			}
			return encryptingCipher.DoFinal(data);
		}

		protected internal override byte[] Decrypt(byte[] data, byte[] iv)
		{
			Requires.Argument(iv == null || algorithm.UsesIV(), "iv", "IV supplied but does not apply to this cipher.");
			InitializeCipher(Javax.Crypto.CipherMode.DecryptMode, iv, ref decryptingCipher);
			Requires.Argument(IsValidInputSize(data.Length), "data", "Length does not a multiple of block size and no padding is selected.");
			try
			{
				return algorithm.IsBlockCipher() ? decryptingCipher.DoFinal(data) : decryptingCipher.Update(data);
			}
			catch (IllegalBlockSizeException innerException)
			{
				throw new ArgumentException("Illegal block size.", innerException);
			}
		}

		protected internal override ICryptoTransform CreateEncryptor(byte[] iv)
		{
			InitializeCipher(Javax.Crypto.CipherMode.EncryptMode, iv, ref encryptingCipher);
			return new CryptoTransformAdaptor(algorithm, encryptingCipher);
		}

		protected internal override ICryptoTransform CreateDecryptor(byte[] iv)
		{
			InitializeCipher(Javax.Crypto.CipherMode.DecryptMode, iv, ref decryptingCipher);
			return new CryptoTransformAdaptor(algorithm, decryptingCipher);
		}

		private static string GetPadding(SymmetricAlgorithm algorithm)
		{
			return algorithm.GetPadding() switch
			{
				SymmetricAlgorithmPadding.None => null, 
				SymmetricAlgorithmPadding.PKCS7 => "PKCS7Padding", 
				_ => throw new NotSupportedException(), 
			};
		}

		private byte[] ThisOrDefaultIV(byte[] iv)
		{
			if (iv != null)
			{
				return iv;
			}
			if (!algorithm.UsesIV())
			{
				return null;
			}
			return new byte[(encryptingCipher ?? decryptingCipher).BlockSize];
		}

		private Cipher GetInitializedCipher(Javax.Crypto.CipherMode mode, byte[] iv)
		{
			switch (mode)
			{
			case Javax.Crypto.CipherMode.DecryptMode:
				InitializeCipher(mode, iv, ref decryptingCipher);
				return decryptingCipher;
			case Javax.Crypto.CipherMode.EncryptMode:
				InitializeCipher(mode, iv, ref encryptingCipher);
				return encryptingCipher;
			default:
				throw new ArgumentException();
			}
		}

		private void InitializeCipher(Javax.Crypto.CipherMode mode, byte[] iv, ref Cipher cipher)
		{
			try
			{
				bool flag = false;
				if (cipher == null)
				{
					cipher = Cipher.GetInstance(GetCipherAcquisitionName().ToString());
					flag = true;
				}
				if (algorithm.IsBlockCipher() || flag)
				{
					iv = ThisOrDefaultIV(iv);
					using IvParameterSpec ivParameterSpec = ((iv != null) ? new IvParameterSpec(iv) : null);
					cipher.Init(mode, key, ivParameterSpec);
					return;
				}
			}
			catch (InvalidKeyException ex)
			{
				throw new ArgumentException(ex.Message, ex);
			}
			catch (NoSuchAlgorithmException innerException)
			{
				throw new NotSupportedException("Algorithm not supported.", innerException);
			}
			catch (InvalidAlgorithmParameterException innerException2)
			{
				throw new ArgumentException("Invalid algorithm parameter.", innerException2);
			}
		}

		private StringBuilder GetCipherAcquisitionName()
		{
			StringBuilder stringBuilder = new StringBuilder(algorithm.GetName().GetString());
			if (algorithm.IsBlockCipher())
			{
				stringBuilder.Append("/");
				stringBuilder.Append(algorithm.GetMode());
				stringBuilder.Append("/");
				stringBuilder.Append(GetPadding(algorithm) ?? "NoPadding");
			}
			return stringBuilder;
		}

		private bool IsValidInputSize(int lengthInBytes)
		{
			Cipher cipher = encryptingCipher ?? decryptingCipher;
			int blockSize = SymmetricKeyAlgorithmProvider.GetBlockSize(algorithm, cipher);
			if (lengthInBytes > 0)
			{
				return lengthInBytes % blockSize == 0;
			}
			return false;
		}
	}
	internal class SymmetricKeyAlgorithmProvider : ISymmetricKeyAlgorithmProvider
	{
		private readonly SymmetricAlgorithm algorithm;

		public SymmetricAlgorithm Algorithm => algorithm;

		public int BlockLength
		{
			get
			{
				try
				{
					using Cipher cipher = Cipher.GetInstance(algorithm.GetName().GetString());
					return GetBlockSize(algorithm, cipher);
				}
				catch (NoSuchAlgorithmException innerException)
				{
					throw new NotSupportedException("Algorithm not supported.", innerException);
				}
			}
		}

		public SymmetricKeyAlgorithmProvider(SymmetricAlgorithm algorithm)
		{
			this.algorithm = algorithm;
		}

		public ICryptographicKey CreateSymmetricKey(byte[] keyMaterial)
		{
			Requires.NotNullOrEmpty(keyMaterial, "keyMaterial");
			return new SymmetricCryptographicKey(Algorithm, keyMaterial);
		}

		internal static int GetBlockSize(SymmetricAlgorithm pclAlgorithm, Cipher algorithm)
		{
			Requires.NotNull(algorithm, "algorithm");
			if (algorithm.BlockSize == 0 && pclAlgorithm.GetName() == SymmetricAlgorithmName.Rc4)
			{
				return 1;
			}
			return algorithm.BlockSize;
		}
	}
	internal class AsymmetricKeyAlgorithmProviderFactory : IAsymmetricKeyAlgorithmProviderFactory
	{
		public IAsymmetricKeyAlgorithmProvider OpenAlgorithm(AsymmetricAlgorithm algorithm)
		{
			switch (algorithm)
			{
			case AsymmetricAlgorithm.RsaOaepSha1:
			case AsymmetricAlgorithm.RsaOaepSha256:
			case AsymmetricAlgorithm.RsaOaepSha384:
			case AsymmetricAlgorithm.RsaOaepSha512:
			case AsymmetricAlgorithm.RsaPkcs1:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha1:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha256:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha384:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha512:
			case AsymmetricAlgorithm.RsaSignPssSha1:
			case AsymmetricAlgorithm.RsaSignPssSha256:
			case AsymmetricAlgorithm.RsaSignPssSha384:
			case AsymmetricAlgorithm.RsaSignPssSha512:
				return new RsaAsymmetricKeyAlgorithmProvider(algorithm);
			default:
				throw new NotSupportedException();
			}
		}

		internal static HashAlgorithm GetHashAlgorithmEnum(AsymmetricAlgorithm algorithm)
		{
			switch (algorithm)
			{
			case AsymmetricAlgorithm.DsaSha1:
			case AsymmetricAlgorithm.RsaOaepSha1:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha1:
			case AsymmetricAlgorithm.RsaSignPssSha1:
				return HashAlgorithm.Sha1;
			case AsymmetricAlgorithm.DsaSha256:
			case AsymmetricAlgorithm.EcdsaP256Sha256:
			case AsymmetricAlgorithm.RsaOaepSha256:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha256:
			case AsymmetricAlgorithm.RsaSignPssSha256:
				return HashAlgorithm.Sha256;
			case AsymmetricAlgorithm.EcdsaP384Sha384:
			case AsymmetricAlgorithm.RsaOaepSha384:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha384:
			case AsymmetricAlgorithm.RsaSignPssSha384:
				return HashAlgorithm.Sha384;
			case AsymmetricAlgorithm.EcdsaP521Sha512:
			case AsymmetricAlgorithm.RsaOaepSha512:
			case AsymmetricAlgorithm.RsaSignPkcs1Sha512:
			case AsymmetricAlgorithm.RsaSignPssSha512:
				return HashAlgorithm.Sha512;
			default:
				throw new NotSupportedException();
			}
		}
	}
	internal class CryptographicBuffer : ICryptographicBuffer
	{
		public bool Compare(byte[] object1, byte[] object2)
		{
			return CryptoUtilities.BufferEquals(object1, object2);
		}

		public string ConvertBinaryToString(Encoding encoding, byte[] buffer)
		{
			Requires.NotNull(encoding, "encoding");
			Requires.NotNull(buffer, "buffer");
			return encoding.GetString(buffer, 0, buffer.Length);
		}

		public byte[] ConvertStringToBinary(string value, Encoding encoding)
		{
			Requires.NotNull(value, "value");
			Requires.NotNull(encoding, "encoding");
			return encoding.GetBytes(value);
		}

		public void CopyToByteArray(byte[] buffer, out byte[] value)
		{
			Requires.NotNull(buffer, "buffer");
			value = new byte[buffer.Length];
			Array.Copy(buffer, value, buffer.Length);
		}

		public byte[] CreateFromByteArray(byte[] value)
		{
			Requires.NotNull(value, "value");
			byte[] array = new byte[value.Length];
			Array.Copy(value, array, value.Length);
			return array;
		}

		public byte[] DecodeFromBase64String(string value)
		{
			return Convert.FromBase64String(value);
		}

		public byte[] DecodeFromHexString(string value)
		{
			Requires.NotNull(value, "value");
			Requires.Argument(value.Length % 2 == 0, "value", "Bad length.");
			byte[] array = new byte[value.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
			}
			return array;
		}

		public string EncodeToBase64String(byte[] buffer)
		{
			Requires.NotNull(buffer, "buffer");
			return Convert.ToBase64String(buffer);
		}

		public string EncodeToHexString(byte[] buffer)
		{
			Requires.NotNull(buffer, "buffer");
			StringBuilder stringBuilder = new StringBuilder(buffer.Length * 2);
			for (int i = 0; i < buffer.Length; i++)
			{
				stringBuilder.AppendFormat("{0:x2}", buffer[i]);
			}
			return stringBuilder.ToString();
		}

		public byte[] GenerateRandom(uint length)
		{
			byte[] array = new byte[length];
			NetFxCrypto.RandomNumberGenerator.GetBytes(array);
			return array;
		}

		public uint GenerateRandomNumber()
		{
			byte[] array = new byte[4];
			NetFxCrypto.RandomNumberGenerator.GetBytes(array);
			return BitConverter.ToUInt32(array, 0);
		}
	}
	internal class CryptographicEngine : ICryptographicEngine
	{
		public byte[] Encrypt(ICryptographicKey key, byte[] data, byte[] iv)
		{
			Requires.NotNull(key, "key");
			Requires.NotNull(data, "data");
			return ((CryptographicKey)key).Encrypt(data, iv);
		}

		public ICryptoTransform CreateEncryptor(ICryptographicKey key, byte[] iv)
		{
			Requires.NotNull(key, "key");
			return ((CryptographicKey)key).CreateEncryptor(iv);
		}

		public byte[] Decrypt(ICryptographicKey key, byte[] data, byte[] iv)
		{
			Requires.NotNull(key, "key");
			Requires.NotNull(data, "data");
			return ((CryptographicKey)key).Decrypt(data, iv);
		}

		public ICryptoTransform CreateDecryptor(ICryptographicKey key, byte[] iv)
		{
			Requires.NotNull(key, "key");
			return ((CryptographicKey)key).CreateDecryptor(iv);
		}

		public byte[] Sign(ICryptographicKey key, byte[] data)
		{
			Requires.NotNull(key, "key");
			Requires.NotNull(data, "data");
			return ((CryptographicKey)key).Sign(data);
		}

		public byte[] SignHashedData(ICryptographicKey key, byte[] data)
		{
			Requires.NotNull(key, "key");
			Requires.NotNull(data, "data");
			return ((CryptographicKey)key).SignHash(data);
		}

		public bool VerifySignature(ICryptographicKey key, byte[] data, byte[] signature)
		{
			Requires.NotNull(key, "key");
			Requires.NotNull(data, "data");
			Requires.NotNull(signature, "signature");
			return ((CryptographicKey)key).VerifySignature(data, signature);
		}

		public bool VerifySignatureWithHashInput(ICryptographicKey key, byte[] data, byte[] signature)
		{
			Requires.NotNull(key, "key");
			Requires.NotNull(data, "data");
			Requires.NotNull(signature, "paramName");
			return ((CryptographicKey)key).VerifyHash(data, signature);
		}

		public byte[] DeriveKeyMaterial(ICryptographicKey key, IKeyDerivationParameters parameters, int desiredKeySize)
		{
			byte[] key2 = ((KeyDerivationCryptographicKey)key).Key;
			byte[] kdfGenericBinary = parameters.KdfGenericBinary;
			return new Rfc2898DeriveBytes(key2, kdfGenericBinary, parameters.IterationCount).GetBytes(desiredKeySize);
		}

		internal static string GetHashAlgorithmOID(AsymmetricAlgorithm algorithm)
		{
			return CryptoConfig.MapNameToOID(HashAlgorithmProviderFactory.GetHashAlgorithmName(AsymmetricKeyAlgorithmProviderFactory.GetHashAlgorithmEnum(algorithm)));
		}

		internal static MessageDigest GetHashAlgorithm(AsymmetricAlgorithm algorithm)
		{
			return HashAlgorithmProvider.CreateHashAlgorithm(AsymmetricKeyAlgorithmProviderFactory.GetHashAlgorithmEnum(algorithm));
		}
	}
	internal class CryptographicKey
	{
		protected internal virtual byte[] Sign(byte[] data)
		{
			throw new NotSupportedException();
		}

		protected internal virtual bool VerifySignature(byte[] data, byte[] signature)
		{
			throw new NotSupportedException();
		}

		protected internal virtual byte[] SignHash(byte[] data)
		{
			throw new NotSupportedException();
		}

		protected internal virtual bool VerifyHash(byte[] data, byte[] signature)
		{
			throw new NotSupportedException();
		}

		protected internal virtual byte[] Encrypt(byte[] data, byte[] iv)
		{
			throw new NotSupportedException();
		}

		protected internal virtual byte[] Decrypt(byte[] data, byte[] iv)
		{
			throw new NotSupportedException();
		}

		protected internal virtual ICryptoTransform CreateEncryptor(byte[] iv)
		{
			throw new NotSupportedException();
		}

		protected internal virtual ICryptoTransform CreateDecryptor(byte[] iv)
		{
			throw new NotSupportedException();
		}
	}
	internal class DeriveBytes : IDeriveBytes
	{
		public byte[] GetBytes(string keyMaterial, byte[] salt, int iterations, int countBytes)
		{
			Requires.NotNullOrEmpty(keyMaterial, "keyMaterial");
			Requires.NotNull(salt, "salt");
			Requires.Range(iterations > 0, "iterations");
			Requires.Range(countBytes > 0, "countBytes");
			return new Rfc2898DeriveBytes(keyMaterial, salt, iterations).GetBytes(countBytes);
		}

		public byte[] GetBytes(byte[] keyMaterial, byte[] salt, int iterations, int countBytes)
		{
			Requires.NotNullOrEmpty(keyMaterial, "keyMaterial");
			Requires.NotNull(salt, "salt");
			Requires.Range(iterations > 0, "iterations");
			Requires.Range(countBytes > 0, "countBytes");
			return new Rfc2898DeriveBytes(keyMaterial, salt, iterations).GetBytes(countBytes);
		}
	}
	internal class HashAlgorithmProvider : IHashAlgorithmProvider
	{
		private readonly HashAlgorithm algorithm;

		public HashAlgorithm Algorithm => algorithm;

		public int HashLength
		{
			get
			{
				using MessageDigest messageDigest = CreateHashAlgorithm(Algorithm);
				return messageDigest.DigestLength;
			}
		}

		internal HashAlgorithmProvider(HashAlgorithm algorithm)
		{
			this.algorithm = algorithm;
		}

		public CryptographicHash CreateHash()
		{
			return new JavaCryptographicHash(CreateHashAlgorithm(Algorithm));
		}

		public byte[] HashData(byte[] data)
		{
			Requires.NotNull(data, "data");
			using CryptographicHash cryptographicHash = CreateHash();
			cryptographicHash.Append(data);
			return cryptographicHash.GetValueAndReset();
		}

		internal static MessageDigest CreateHashAlgorithm(HashAlgorithm algorithm)
		{
			return algorithm switch
			{
				HashAlgorithm.Md5 => MessageDigest.GetInstance("MD5"), 
				HashAlgorithm.Sha1 => MessageDigest.GetInstance("SHA1"), 
				HashAlgorithm.Sha256 => MessageDigest.GetInstance("SHA256"), 
				HashAlgorithm.Sha384 => MessageDigest.GetInstance("SHA384"), 
				HashAlgorithm.Sha512 => MessageDigest.GetInstance("SHA512"), 
				_ => throw new NotSupportedException(), 
			};
		}
	}
	internal class KeyDerivationAlgorithmProvider : IKeyDerivationAlgorithmProvider
	{
		private readonly KeyDerivationAlgorithm algorithm;

		public KeyDerivationAlgorithm Algorithm => algorithm;

		internal KeyDerivationAlgorithmProvider(KeyDerivationAlgorithm algorithm)
		{
			this.algorithm = algorithm;
		}

		public ICryptographicKey CreateKey(byte[] keyMaterial)
		{
			return new KeyDerivationCryptographicKey(keyMaterial);
		}
	}
	internal class KeyDerivationAlgorithmProviderFactory : IKeyDerivationAlgorithmProviderFactory
	{
		public IKeyDerivationAlgorithmProvider OpenAlgorithm(KeyDerivationAlgorithm algorithm)
		{
			return new KeyDerivationAlgorithmProvider(algorithm);
		}
	}
	internal class KeyDerivationCryptographicKey : CryptographicKey, ICryptographicKey
	{
		private readonly byte[] key;

		public int KeySize => key.Length * 8;

		internal byte[] Key => key;

		internal KeyDerivationCryptographicKey(byte[] key)
		{
			Requires.NotNull(key, "key");
			this.key = key;
		}

		public byte[] Export(CryptographicPrivateKeyBlobType blobType = CryptographicPrivateKeyBlobType.Pkcs8RawPrivateKeyInfo)
		{
			throw new NotImplementedException();
		}

		public byte[] ExportPublicKey(CryptographicPublicKeyBlobType blobType = CryptographicPublicKeyBlobType.X509SubjectPublicKeyInfo)
		{
			throw new NotImplementedException();
		}
	}
	internal class KeyDerivationParametersFactory : IKeyDerivationParametersFactory
	{
		private class KeyDerivationParameters : IKeyDerivationParameters
		{
			public int IterationCount { get; private set; }

			public byte[] KdfGenericBinary { get; set; }

			internal KeyDerivationParameters(int iterationCount, byte[] kdfGenericBinary)
			{
				Requires.Range(iterationCount > 0, "iterationCount");
				Requires.NotNull(kdfGenericBinary, "kdfGenericBinary");
				IterationCount = iterationCount;
				KdfGenericBinary = kdfGenericBinary;
			}
		}

		public IKeyDerivationParameters BuildForPbkdf2(byte[] pbkdf2Salt, int iterationCount)
		{
			return new KeyDerivationParameters(iterationCount, pbkdf2Salt);
		}

		public IKeyDerivationParameters BuildForSP800108(byte[] label, byte[] context)
		{
			throw new NotSupportedException();
		}

		public IKeyDerivationParameters BuildForSP80056a(byte[] algorithmId, byte[] partyUInfo, byte[] partyVInfo, byte[] suppPubInfo, byte[] suppPrivInfo)
		{
			throw new NotSupportedException();
		}
	}
	internal class MacAlgorithmProviderFactory : IMacAlgorithmProviderFactory
	{
		public IMacAlgorithmProvider OpenAlgorithm(MacAlgorithm algorithm)
		{
			return new MacAlgorithmProvider(algorithm);
		}

		internal static string GetAlgorithmName(MacAlgorithm algorithm)
		{
			return algorithm switch
			{
				MacAlgorithm.AesCmac => "AesCmac", 
				MacAlgorithm.HmacMd5 => "HmacMd5", 
				MacAlgorithm.HmacSha1 => "HmacSha1", 
				MacAlgorithm.HmacSha256 => "HmacSha256", 
				MacAlgorithm.HmacSha384 => "HmacSha384", 
				MacAlgorithm.HmacSha512 => "HmacSha512", 
				_ => throw new ArgumentException(), 
			};
		}
	}
	internal class MacCryptographicKey : CryptographicKey, ICryptographicKey
	{
		private readonly MacAlgorithm algorithm;

		private readonly byte[] key;

		public int KeySize => key.Length;

		internal MacCryptographicKey(MacAlgorithm algorithm, byte[] key)
		{
			Requires.NotNull(key, "key");
			this.algorithm = algorithm;
			this.key = key;
		}

		public byte[] Export(CryptographicPrivateKeyBlobType blobType = CryptographicPrivateKeyBlobType.Pkcs8RawPrivateKeyInfo)
		{
			throw new NotSupportedException();
		}

		public byte[] ExportPublicKey(CryptographicPublicKeyBlobType blobType = CryptographicPublicKeyBlobType.X509SubjectPublicKeyInfo)
		{
			throw new NotSupportedException();
		}

		protected internal override byte[] Sign(byte[] data)
		{
			using Mac mac = MacAlgorithmProvider.GetAlgorithm(algorithm);
			mac.Init(MacAlgorithmProvider.GetSecretKey(algorithm, key));
			return mac.DoFinal(data);
		}

		protected internal override bool VerifySignature(byte[] data, byte[] signature)
		{
			using Mac mac = MacAlgorithmProvider.GetAlgorithm(algorithm);
			mac.Init(MacAlgorithmProvider.GetSecretKey(algorithm, key));
			return CryptoUtilities.BufferEquals(mac.DoFinal(data), signature);
		}
	}
	internal class RandomNumberGenerator : System.Security.Cryptography.RandomNumberGenerator, IRandomNumberGenerator
	{
		private static readonly RNGCryptoServiceProvider RandomSource = new RNGCryptoServiceProvider();

		public override void GetBytes(byte[] buffer)
		{
			RandomSource.GetBytes(buffer);
		}

		public override void GetNonZeroBytes(byte[] data)
		{
			RandomSource.GetNonZeroBytes(data);
		}
	}
	internal class SymmetricKeyAlgorithmProviderFactory : ISymmetricKeyAlgorithmProviderFactory
	{
		public ISymmetricKeyAlgorithmProvider OpenAlgorithm(SymmetricAlgorithm algorithm)
		{
			return new SymmetricKeyAlgorithmProvider(algorithm);
		}
	}
	public enum AsymmetricAlgorithm
	{
		DsaSha1,
		DsaSha256,
		EcdsaP256Sha256,
		EcdsaP384Sha384,
		EcdsaP521Sha512,
		RsaOaepSha1,
		RsaOaepSha256,
		RsaOaepSha384,
		RsaOaepSha512,
		RsaPkcs1,
		RsaSignPkcs1Sha1,
		RsaSignPkcs1Sha256,
		RsaSignPkcs1Sha384,
		RsaSignPkcs1Sha512,
		RsaSignPssSha1,
		RsaSignPssSha256,
		RsaSignPssSha384,
		RsaSignPssSha512
	}
	public abstract class CryptographicHash : ICryptoTransform, IDisposable
	{
		bool ICryptoTransform.CanReuseTransform => CanReuseTransform;

		bool ICryptoTransform.CanTransformMultipleBlocks => CanTransformMultipleBlocks;

		int ICryptoTransform.InputBlockSize => InputBlockSize;

		int ICryptoTransform.OutputBlockSize => OutputBlockSize;

		protected virtual bool CanReuseTransform => false;

		protected virtual bool CanTransformMultipleBlocks => true;

		protected virtual int InputBlockSize => 1;

		protected virtual int OutputBlockSize => 1;

		int ICryptoTransform.TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			return TransformBlock(inputBuffer, inputOffset, inputCount, outputBuffer, outputOffset);
		}

		byte[] ICryptoTransform.TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			return TransformFinalBlock(inputBuffer, inputOffset, inputCount);
		}

		public abstract void Append(byte[] data);

		public abstract byte[] GetValueAndReset();

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		protected abstract int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset);

		protected abstract byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount);
	}
	public enum CryptographicPrivateKeyBlobType
	{
		Pkcs8RawPrivateKeyInfo,
		Pkcs1RsaPrivateKey,
		BCryptPrivateKey,
		Capi1PrivateKey
	}
	public enum CryptographicPublicKeyBlobType
	{
		X509SubjectPublicKeyInfo,
		Pkcs1RsaPublicKey,
		BCryptPublicKey,
		Capi1PublicKey
	}
	public class CryptoStream : Stream
	{
		private readonly Stream chainedStream;

		private readonly ICryptoTransform transform;

		private readonly CryptoStreamMode mode;

		private readonly byte[] inputBuffer;

		private byte[] outputBuffer;

		private int inputBufferSize;

		private int outputBufferSize;

		private int outputBufferIndex;

		public bool HasFlushedFinalBlock { get; private set; }

		public override bool CanRead => mode == CryptoStreamMode.Read;

		public override bool CanSeek => false;

		public override bool CanWrite => mode == CryptoStreamMode.Write;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

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

		public CryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode)
		{
			Requires.NotNull(stream, "stream");
			Requires.NotNull(transform, "transform");
			switch (mode)
			{
			case CryptoStreamMode.Read:
				Requires.Argument(stream.CanRead, "stream", "Stream is not readable.");
				break;
			case CryptoStreamMode.Write:
				Requires.Argument(stream.CanWrite, "stream", "Stream is not writeable.");
				break;
			default:
				Requires.That(false, "mode", "Unsupported mode.");
				break;
			}
			chainedStream = stream;
			this.transform = transform;
			this.mode = mode;
			inputBuffer = new byte[transform.InputBlockSize];
			outputBuffer = new byte[transform.OutputBlockSize];
		}

		public static CryptoStream WriteTo(Stream stream, params ICryptoTransform[] transforms)
		{
			return Chain(stream, CryptoStreamMode.Write, transforms);
		}

		public static CryptoStream ReadFrom(Stream stream, params ICryptoTransform[] transforms)
		{
			return Chain(stream, CryptoStreamMode.Read, transforms);
		}

		public void FlushFinalBlock()
		{
			byte[] array = transform.TransformFinalBlock(inputBuffer, 0, inputBufferSize);
			chainedStream.Write(array, 0, array.Length);
			HasFlushedFinalBlock = true;
			if (chainedStream is CryptoStream cryptoStream)
			{
				if (!cryptoStream.HasFlushedFinalBlock)
				{
					cryptoStream.FlushFinalBlock();
				}
			}
			else
			{
				chainedStream.Flush();
			}
			Array.Clear(inputBuffer, 0, inputBuffer.Length);
			Array.Clear(outputBuffer, 0, outputBuffer.Length);
		}

		public override void Flush()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			Requires.NotNull(buffer, "buffer");
			Requires.Range(offset >= 0, "offset");
			Requires.Range(count >= 0, "count");
			if (!CanRead)
			{
				throw new NotSupportedException();
			}
			int num = 0;
			while (count > 0 && (!HasFlushedFinalBlock || outputBufferSize > 0))
			{
				if (outputBufferSize > 0)
				{
					int num2 = Math.Min(count, outputBufferSize);
					Array.Copy(outputBuffer, outputBufferIndex, buffer, offset, num2);
					count -= num2;
					offset += num2;
					num += num2;
					outputBufferSize -= num2;
					outputBufferIndex = ((outputBufferSize != 0) ? (outputBufferIndex + num2) : 0);
				}
				else
				{
					if (outputBufferSize != 0 || HasFlushedFinalBlock)
					{
						continue;
					}
					if (inputBufferSize == 0 && transform.CanTransformMultipleBlocks)
					{
						int num3 = count / transform.OutputBlockSize;
						if (num3 > 1)
						{
							byte[] array = new byte[num3 * transform.InputBlockSize];
							int num4 = chainedStream.Read(array, 0, array.Length);
							int num5 = num4 / transform.InputBlockSize;
							int num6 = num5 * transform.InputBlockSize;
							if (num5 > 0)
							{
								byte[] array2 = new byte[num5 * transform.OutputBlockSize];
								int num7 = transform.TransformBlock(array, 0, num6, array2, 0);
								Array.Copy(array2, 0, buffer, offset, num7);
								offset += num7;
								count -= num7;
								num += num7;
								Array.Clear(array2, 0, array2.Length);
							}
							int num8 = num4 - num6;
							Array.Copy(array, num6, inputBuffer, 0, num8);
							inputBufferSize += num8;
							Array.Clear(array, 0, array.Length);
						}
					}
					int num9 = inputBuffer.Length - inputBufferSize;
					if (num9 > 0)
					{
						int num10 = chainedStream.Read(inputBuffer, inputBufferSize, num9);
						if (num10 == 0)
						{
							Array.Clear(outputBuffer, 0, outputBuffer.Length);
							outputBuffer = transform.TransformFinalBlock(inputBuffer, 0, inputBufferSize);
							inputBufferSize = 0;
							HasFlushedFinalBlock = true;
							outputBufferSize = outputBuffer.Length;
							Assumes.True(outputBufferIndex == 0);
							continue;
						}
						inputBufferSize += num10;
					}
					if (inputBufferSize == inputBuffer.Length)
					{
						outputBufferSize = transform.TransformBlock(inputBuffer, 0, inputBuffer.Length, outputBuffer, 0);
						inputBufferSize = 0;
					}
				}
			}
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			Requires.NotNull(buffer, "buffer");
			Requires.Range(offset >= 0, "offset");
			Requires.Range(count >= 0, "count");
			if (!CanWrite)
			{
				throw new NotSupportedException();
			}
			while (count > 0)
			{
				if (inputBufferSize == 0 && transform.CanTransformMultipleBlocks)
				{
					int num = count / inputBuffer.Length;
					if (num > 1)
					{
						byte[] array = new byte[transform.OutputBlockSize * num];
						int num2 = num * transform.InputBlockSize;
						int count2 = transform.TransformBlock(buffer, offset, num2, array, 0);
						count -= num2;
						offset += num2;
						chainedStream.Write(array, 0, count2);
						Array.Clear(array, 0, array.Length);
					}
				}
				int num3 = Math.Min(count, inputBuffer.Length - inputBufferSize);
				Array.Copy(buffer, offset, inputBuffer, inputBufferSize, num3);
				count -= num3;
				offset += num3;
				inputBufferSize += num3;
				if (inputBufferSize == inputBuffer.Length)
				{
					int count3 = transform.TransformBlock(inputBuffer, 0, inputBuffer.Length, outputBuffer, 0);
					inputBufferSize = 0;
					chainedStream.Write(outputBuffer, 0, count3);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing)
				{
					if (!HasFlushedFinalBlock)
					{
						FlushFinalBlock();
					}
					chainedStream.Dispose();
					Array.Clear(inputBuffer, 0, inputBuffer.Length);
					Array.Clear(outputBuffer, 0, outputBuffer.Length);
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		private static CryptoStream Chain(Stream stream, CryptoStreamMode cryptoStreamMode, params ICryptoTransform[] transforms)
		{
			Requires.NotNull(stream, "stream");
			Requires.NotNullOrEmpty(transforms, "transforms");
			if (cryptoStreamMode == CryptoStreamMode.Write)
			{
				using (IEnumerator<ICryptoTransform> transforms2 = transforms.Cast<ICryptoTransform>().GetEnumerator())
				{
					return (CryptoStream)ChainWrite(stream, transforms2);
				}
			}
			foreach (ICryptoTransform cryptoTransform in transforms)
			{
				stream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Read);
			}
			return (CryptoStream)stream;
		}

		private static Stream ChainWrite(Stream stream, IEnumerator<ICryptoTransform> transforms)
		{
			Requires.NotNull(stream, "stream");
			Requires.NotNull(transforms, "transforms");
			if (transforms.MoveNext())
			{
				ICryptoTransform current = transforms.Current;
				return new CryptoStream(ChainWrite(stream, transforms), current, CryptoStreamMode.Write);
			}
			return stream;
		}
	}
	public enum CryptoStreamMode
	{
		Read,
		Write
	}
	public enum HashAlgorithm
	{
		Md5,
		Sha1,
		Sha256,
		Sha384,
		Sha512
	}
	public interface IAsymmetricKeyAlgorithmProvider
	{
		AsymmetricAlgorithm Algorithm { get; }

		ICryptographicKey CreateKeyPair(int keySize);

		ICryptographicKey ImportKeyPair(byte[] keyBlob, CryptographicPrivateKeyBlobType blobType = CryptographicPrivateKeyBlobType.Pkcs8RawPrivateKeyInfo);

		ICryptographicKey ImportPublicKey(byte[] keyBlob, CryptographicPublicKeyBlobType blobType = CryptographicPublicKeyBlobType.X509SubjectPublicKeyInfo);
	}
	public interface IAsymmetricKeyAlgorithmProviderFactory
	{
		IAsymmetricKeyAlgorithmProvider OpenAlgorithm(AsymmetricAlgorithm algorithm);
	}
	public interface ICryptographicBuffer
	{
		bool Compare(byte[] object1, byte[] object2);

		string ConvertBinaryToString(Encoding encoding, byte[] buffer);

		byte[] ConvertStringToBinary(string value, Encoding encoding);

		void CopyToByteArray(byte[] buffer, out byte[] value);

		byte[] CreateFromByteArray(byte[] value);

		byte[] DecodeFromBase64String(string value);

		byte[] DecodeFromHexString(string value);

		string EncodeToBase64String(byte[] buffer);

		string EncodeToHexString(byte[] buffer);

		byte[] GenerateRandom(uint length);

		uint GenerateRandomNumber();
	}
	public interface ICryptographicEngine
	{
		byte[] Encrypt(ICryptographicKey key, byte[] data, byte[] iv = null);

		ICryptoTransform CreateEncryptor(ICryptographicKey key, byte[] iv = null);

		byte[] Decrypt(ICryptographicKey key, byte[] data, byte[] iv = null);

		ICryptoTransform CreateDecryptor(ICryptographicKey key, byte[] iv = null);

		byte[] Sign(ICryptographicKey key, byte[] data);

		byte[] SignHashedData(ICryptographicKey key, byte[] data);

		bool VerifySignature(ICryptographicKey key, byte[] data, byte[] signature);

		bool VerifySignatureWithHashInput(ICryptographicKey key, byte[] data, byte[] signature);

		byte[] DeriveKeyMaterial(ICryptographicKey key, IKeyDerivationParameters parameters, int desiredKeySize);
	}
	public interface ICryptographicKey
	{
		int KeySize { get; }

		byte[] Export(CryptographicPrivateKeyBlobType blobType = CryptographicPrivateKeyBlobType.Pkcs8RawPrivateKeyInfo);

		byte[] ExportPublicKey(CryptographicPublicKeyBlobType blobType = CryptographicPublicKeyBlobType.X509SubjectPublicKeyInfo);
	}
	public interface ICryptoTransform : IDisposable
	{
		bool CanReuseTransform { get; }

		bool CanTransformMultipleBlocks { get; }

		int InputBlockSize { get; }

		int OutputBlockSize { get; }

		int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset);

		byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount);
	}
	public interface IDeriveBytes
	{
		byte[] GetBytes(string keyMaterial, byte[] salt, int iterations, int countBytes);

		byte[] GetBytes(byte[] keyMaterial, byte[] salt, int iterations, int countBytes);
	}
	public interface IHashAlgorithmProvider
	{
		HashAlgorithm Algorithm { get; }

		int HashLength { get; }

		CryptographicHash CreateHash();

		byte[] HashData(byte[] data);
	}
	public interface IHashAlgorithmProviderFactory
	{
		IHashAlgorithmProvider OpenAlgorithm(HashAlgorithm algorithm);
	}
	public interface IKeyDerivationAlgorithmProvider
	{
		KeyDerivationAlgorithm Algorithm { get; }

		ICryptographicKey CreateKey(byte[] keyMaterial);
	}
	public interface IKeyDerivationAlgorithmProviderFactory
	{
		IKeyDerivationAlgorithmProvider OpenAlgorithm(KeyDerivationAlgorithm algorithm);
	}
	public interface IKeyDerivationParameters
	{
		int IterationCount { get; }

		byte[] KdfGenericBinary { get; set; }
	}
	public interface IKeyDerivationParametersFactory
	{
		IKeyDerivationParameters BuildForPbkdf2(byte[] pbkdf2Salt, int iterationCount);

		IKeyDerivationParameters BuildForSP800108(byte[] label, byte[] context);

		IKeyDerivationParameters BuildForSP80056a(byte[] algorithmId, byte[] partyUInfo, byte[] partyVInfo, byte[] suppPubInfo, byte[] suppPrivInfo);
	}
	public interface IMacAlgorithmProvider
	{
		MacAlgorithm Algorithm { get; }

		int MacLength { get; }

		CryptographicHash CreateHash(byte[] keyMaterial);

		ICryptographicKey CreateKey(byte[] keyMaterial);
	}
	public interface IMacAlgorithmProviderFactory
	{
		IMacAlgorithmProvider OpenAlgorithm(MacAlgorithm algorithm);
	}
	public interface IRandomNumberGenerator
	{
		void GetBytes(byte[] buffer);
	}
	public interface ISymmetricKeyAlgorithmProvider
	{
		int BlockLength { get; }

		ICryptographicKey CreateSymmetricKey(byte[] keyMaterial);
	}
	public interface ISymmetricKeyAlgorithmProviderFactory
	{
		ISymmetricKeyAlgorithmProvider OpenAlgorithm(SymmetricAlgorithm algorithm);
	}
	public enum KeyDerivationAlgorithm
	{
		Pbkdf2Md5,
		Pbkdf2Sha1,
		Pbkdf2Sha256,
		Pbkdf2Sha384,
		Pbkdf2Sha512,
		Sp800108CtrHmacMd5,
		Sp800108CtrHmacSha1,
		Sp800108CtrHmacSha256,
		Sp800108CtrHmacSha384,
		Sp800108CtrHmacSha512,
		Sp80056aConcatMd5,
		Sp80056aConcatSha1,
		Sp80056aConcatSha256,
		Sp80056aConcatSha384,
		Sp80056aConcatSha512
	}
	public enum MacAlgorithm
	{
		AesCmac,
		HmacMd5,
		HmacSha1,
		HmacSha256,
		HmacSha384,
		HmacSha512
	}
	public static class NetFxCrypto
	{
		private static IRandomNumberGenerator randomNumberGenerator;

		public static IRandomNumberGenerator RandomNumberGenerator
		{
			get
			{
				if (randomNumberGenerator == null)
				{
					randomNumberGenerator = new RandomNumberGenerator();
				}
				return randomNumberGenerator;
			}
		}

		public static IDeriveBytes DeriveBytes => new DeriveBytes();
	}
	public struct RSAParameters
	{
		public byte[] D;

		public byte[] DP;

		public byte[] DQ;

		public byte[] Exponent;

		public byte[] InverseQ;

		public byte[] Modulus;

		public byte[] P;

		public byte[] Q;
	}
	public enum SymmetricAlgorithm
	{
		AesCbc,
		AesCbcPkcs7,
		AesCcm,
		AesEcb,
		AesEcbPkcs7,
		AesGcm,
		DesCbc,
		DesCbcPkcs7,
		DesEcb,
		DesEcbPkcs7,
		Rc2Cbc,
		Rc2CbcPkcs7,
		Rc2Ecb,
		Rc2EcbPkcs7,
		Rc4,
		TripleDesCbc,
		TripleDesCbcPkcs7,
		TripleDesEcb,
		TripleDesEcbPkcs7
	}
	public static class SymmetricAlgorithmExtensions
	{
		public static bool IsBlockCipher(this SymmetricAlgorithm algorithm)
		{
			switch (algorithm)
			{
			case SymmetricAlgorithm.Rc4:
				return false;
			case SymmetricAlgorithm.AesCbc:
			case SymmetricAlgorithm.AesCbcPkcs7:
			case SymmetricAlgorithm.AesCcm:
			case SymmetricAlgorithm.AesEcb:
			case SymmetricAlgorithm.AesEcbPkcs7:
			case SymmetricAlgorithm.AesGcm:
			case SymmetricAlgorithm.DesCbc:
			case SymmetricAlgorithm.DesCbcPkcs7:
			case SymmetricAlgorithm.DesEcb:
			case SymmetricAlgorithm.DesEcbPkcs7:
			case SymmetricAlgorithm.Rc2Cbc:
			case SymmetricAlgorithm.Rc2CbcPkcs7:
			case SymmetricAlgorithm.Rc2Ecb:
			case SymmetricAlgorithm.Rc2EcbPkcs7:
			case SymmetricAlgorithm.TripleDesCbc:
			case SymmetricAlgorithm.TripleDesCbcPkcs7:
			case SymmetricAlgorithm.TripleDesEcb:
			case SymmetricAlgorithm.TripleDesEcbPkcs7:
				return true;
			default:
				throw new ArgumentException();
			}
		}

		public static SymmetricAlgorithmName GetName(this SymmetricAlgorithm algorithm)
		{
			switch (algorithm)
			{
			case SymmetricAlgorithm.AesCbc:
			case SymmetricAlgorithm.AesCbcPkcs7:
			case SymmetricAlgorithm.AesCcm:
			case SymmetricAlgorithm.AesEcb:
			case SymmetricAlgorithm.AesEcbPkcs7:
			case SymmetricAlgorithm.AesGcm:
				return SymmetricAlgorithmName.Aes;
			case SymmetricAlgorithm.DesCbc:
			case SymmetricAlgorithm.DesCbcPkcs7:
			case SymmetricAlgorithm.DesEcb:
			case SymmetricAlgorithm.DesEcbPkcs7:
				return SymmetricAlgorithmName.Des;
			case SymmetricAlgorithm.Rc2Cbc:
			case SymmetricAlgorithm.Rc2CbcPkcs7:
			case SymmetricAlgorithm.Rc2Ecb:
			case SymmetricAlgorithm.Rc2EcbPkcs7:
				return SymmetricAlgorithmName.Rc2;
			case SymmetricAlgorithm.Rc4:
				return SymmetricAlgorithmName.Rc4;
			case SymmetricAlgorithm.TripleDesCbc:
			case SymmetricAlgorithm.TripleDesCbcPkcs7:
			case SymmetricAlgorithm.TripleDesEcb:
			case SymmetricAlgorithm.TripleDesEcbPkcs7:
				return SymmetricAlgorithmName.TripleDes;
			default:
				throw new ArgumentException();
			}
		}

		public static SymmetricAlgorithmMode GetMode(this SymmetricAlgorithm algorithm)
		{
			switch (algorithm)
			{
			case SymmetricAlgorithm.AesCbc:
			case SymmetricAlgorithm.AesCbcPkcs7:
			case SymmetricAlgorithm.DesCbc:
			case SymmetricAlgorithm.DesCbcPkcs7:
			case SymmetricAlgorithm.Rc2Cbc:
			case SymmetricAlgorithm.Rc2CbcPkcs7:
			case SymmetricAlgorithm.TripleDesCbc:
			case SymmetricAlgorithm.TripleDesCbcPkcs7:
				return SymmetricAlgorithmMode.Cbc;
			case SymmetricAlgorithm.AesEcb:
			case SymmetricAlgorithm.AesEcbPkcs7:
			case SymmetricAlgorithm.DesEcb:
			case SymmetricAlgorithm.DesEcbPkcs7:
			case SymmetricAlgorithm.Rc2Ecb:
			case SymmetricAlgorithm.Rc2EcbPkcs7:
			case SymmetricAlgorithm.TripleDesEcb:
			case SymmetricAlgorithm.TripleDesEcbPkcs7:
				return SymmetricAlgorithmMode.Ecb;
			case SymmetricAlgorithm.AesCcm:
				return SymmetricAlgorithmMode.Ccm;
			case SymmetricAlgorithm.AesGcm:
				return SymmetricAlgorithmMode.Gcm;
			default:
				throw new ArgumentException();
			}
		}

		public static SymmetricAlgorithmPadding GetPadding(this SymmetricAlgorithm algorithm)
		{
			switch (algorithm)
			{
			case SymmetricAlgorithm.AesCbc:
			case SymmetricAlgorithm.AesCcm:
			case SymmetricAlgorithm.AesEcb:
			case SymmetricAlgorithm.AesGcm:
			case SymmetricAlgorithm.DesCbc:
			case SymmetricAlgorithm.DesEcb:
			case SymmetricAlgorithm.Rc2Cbc:
			case SymmetricAlgorithm.Rc2Ecb:
			case SymmetricAlgorithm.Rc4:
			case SymmetricAlgorithm.TripleDesCbc:
			case SymmetricAlgorithm.TripleDesEcb:
				return SymmetricAlgorithmPadding.None;
			case SymmetricAlgorithm.AesCbcPkcs7:
			case SymmetricAlgorithm.AesEcbPkcs7:
			case SymmetricAlgorithm.DesCbcPkcs7:
			case SymmetricAlgorithm.DesEcbPkcs7:
			case SymmetricAlgorithm.Rc2CbcPkcs7:
			case SymmetricAlgorithm.Rc2EcbPkcs7:
			case SymmetricAlgorithm.TripleDesCbcPkcs7:
			case SymmetricAlgorithm.TripleDesEcbPkcs7:
				return SymmetricAlgorithmPadding.PKCS7;
			default:
				throw new ArgumentException();
			}
		}

		public static bool UsesIV(this SymmetricAlgorithmMode mode)
		{
			switch (mode)
			{
			case SymmetricAlgorithmMode.Cbc:
			case SymmetricAlgorithmMode.Ccm:
			case SymmetricAlgorithmMode.Gcm:
				return true;
			case SymmetricAlgorithmMode.Ecb:
				return false;
			default:
				throw new ArgumentException();
			}
		}

		public static bool UsesIV(this SymmetricAlgorithm algorithm)
		{
			if (algorithm.IsBlockCipher())
			{
				switch (algorithm.GetMode())
				{
				case SymmetricAlgorithmMode.Cbc:
				case SymmetricAlgorithmMode.Ccm:
				case SymmetricAlgorithmMode.Gcm:
					return true;
				case SymmetricAlgorithmMode.Ecb:
					return false;
				default:
					throw new ArgumentException();
				}
			}
			return false;
		}

		public static string GetString(this SymmetricAlgorithmName algorithm)
		{
			return algorithm switch
			{
				SymmetricAlgorithmName.Aes => "AES", 
				SymmetricAlgorithmName.Des => "DES", 
				SymmetricAlgorithmName.Rc2 => "RC2", 
				SymmetricAlgorithmName.Rc4 => "RC4", 
				SymmetricAlgorithmName.TripleDes => "TRIPLEDES", 
				_ => throw new ArgumentException(), 
			};
		}
	}
	public enum SymmetricAlgorithmMode
	{
		Cbc,
		Ecb,
		Ccm,
		Gcm
	}
	public enum SymmetricAlgorithmName
	{
		Aes,
		Des,
		TripleDes,
		Rc2,
		Rc4
	}
	public enum SymmetricAlgorithmPadding
	{
		None,
		PKCS7
	}
	public static class WinRTCrypto
	{
		private static IAsymmetricKeyAlgorithmProviderFactory asymmetricKeyAlgorithmProvider;

		private static ISymmetricKeyAlgorithmProviderFactory symmetricKeyAlgorithmProvider;

		private static IHashAlgorithmProviderFactory hashAlgorithmProvider;

		private static IMacAlgorithmProviderFactory macAlgorithmProvider;

		private static IKeyDerivationAlgorithmProviderFactory keyDerivationAlgorithmProvider;

		private static IKeyDerivationParametersFactory keyDerivationParametersFactory;

		private static ICryptographicEngine cryptographicEngine;

		private static ICryptographicBuffer cryptographicBuffer;

		public static IAsymmetricKeyAlgorithmProviderFactory AsymmetricKeyAlgorithmProvider
		{
			get
			{
				if (asymmetricKeyAlgorithmProvider == null)
				{
					asymmetricKeyAlgorithmProvider = new AsymmetricKeyAlgorithmProviderFactory();
				}
				return asymmetricKeyAlgorithmProvider;
			}
		}

		public static ISymmetricKeyAlgorithmProviderFactory SymmetricKeyAlgorithmProvider
		{
			get
			{
				if (symmetricKeyAlgorithmProvider == null)
				{
					symmetricKeyAlgorithmProvider = new SymmetricKeyAlgorithmProviderFactory();
				}
				return symmetricKeyAlgorithmProvider;
			}
		}

		public static IHashAlgorithmProviderFactory HashAlgorithmProvider
		{
			get
			{
				if (hashAlgorithmProvider == null)
				{
					hashAlgorithmProvider = new HashAlgorithmProviderFactory();
				}
				return hashAlgorithmProvider;
			}
		}

		public static IMacAlgorithmProviderFactory MacAlgorithmProvider
		{
			get
			{
				if (macAlgorithmProvider == null)
				{
					macAlgorithmProvider = new MacAlgorithmProviderFactory();
				}
				return macAlgorithmProvider;
			}
		}

		public static IKeyDerivationAlgorithmProviderFactory KeyDerivationAlgorithmProvider
		{
			get
			{
				if (keyDerivationAlgorithmProvider == null)
				{
					keyDerivationAlgorithmProvider = new KeyDerivationAlgorithmProviderFactory();
				}
				return keyDerivationAlgorithmProvider;
			}
		}

		public static IKeyDerivationParametersFactory KeyDerivationParameters
		{
			get
			{
				if (keyDerivationParametersFactory == null)
				{
					keyDerivationParametersFactory = new KeyDerivationParametersFactory();
				}
				return keyDerivationParametersFactory;
			}
		}

		public static ICryptographicEngine CryptographicEngine
		{
			get
			{
				if (cryptographicEngine == null)
				{
					cryptographicEngine = new CryptographicEngine();
				}
				return cryptographicEngine;
			}
		}

		public static ICryptographicBuffer CryptographicBuffer
		{
			get
			{
				if (cryptographicBuffer == null)
				{
					cryptographicBuffer = new CryptographicBuffer();
				}
				return cryptographicBuffer;
			}
		}
	}
	public static class WinRTExtensions
	{
		public static ICryptographicKey ImportParameters(this IAsymmetricKeyAlgorithmProvider provider, RSAParameters parameters)
		{
			Requires.NotNull(provider, "provider");
			byte[] keyBlob = KeyFormatter.Pkcs1.Write(parameters);
			if (!KeyFormatter.HasPrivateKey(parameters))
			{
				return provider.ImportPublicKey(keyBlob, CryptographicPublicKeyBlobType.Pkcs1RsaPublicKey);
			}
			return provider.ImportKeyPair(keyBlob, CryptographicPrivateKeyBlobType.Pkcs1RsaPrivateKey);
		}

		public static RSAParameters ExportParameters(this ICryptographicKey key, bool includePrivateParameters)
		{
			Requires.NotNull(key, "key");
			byte[] keyBlob = (includePrivateParameters ? key.Export(CryptographicPrivateKeyBlobType.Pkcs1RsaPrivateKey) : key.ExportPublicKey(CryptographicPublicKeyBlobType.Pkcs1RsaPublicKey));
			return KeyFormatter.Pkcs1.Read(keyBlob);
		}
	}
	internal static class CryptoUtilities
	{
		internal static bool BufferEquals(byte[] buffer1, byte[] buffer2)
		{
			Requires.NotNull(buffer1, "buffer1");
			Requires.NotNull(buffer2, "buffer2");
			if (buffer1.Length != buffer2.Length)
			{
				return false;
			}
			bool flag = false;
			for (int i = 0; i < buffer1.Length; i++)
			{
				flag |= buffer1[i] != buffer2[i];
			}
			return !flag;
		}

		internal static void DisposeIfNotNull(this IDisposable value)
		{
			value?.Dispose();
		}
	}
	internal class HashAlgorithmProviderFactory : IHashAlgorithmProviderFactory
	{
		public IHashAlgorithmProvider OpenAlgorithm(HashAlgorithm algorithm)
		{
			return new HashAlgorithmProvider(algorithm);
		}

		internal static string GetHashAlgorithmName(HashAlgorithm algorithm)
		{
			return algorithm switch
			{
				HashAlgorithm.Md5 => "MD5", 
				HashAlgorithm.Sha1 => "SHA1", 
				HashAlgorithm.Sha256 => "SHA256", 
				HashAlgorithm.Sha384 => "SHA384", 
				HashAlgorithm.Sha512 => "SHA512", 
				_ => throw new NotSupportedException(), 
			};
		}
	}
}
namespace PCLCrypto.Formatters
{
	internal static class Asn
	{
		internal enum BerClass : byte
		{
			Universal = 0,
			Application = 64,
			ContextSpecific = 128,
			Private = 192,
			Mask = 192
		}

		internal enum BerPC : byte
		{
			Primitive = 0,
			Constructed = 32,
			Mask = 32
		}

		internal enum BerTag : byte
		{
			EndOfContent = 0,
			Integer = 2,
			BitString = 3,
			OctetString = 4,
			Null = 5,
			ObjectIdentifier = 6,
			Sequence = 16,
			SetAndSetOf = 17,
			Mask = 31
		}

		internal struct DataElement
		{
			public BerClass Class { get; private set; }

			public BerPC PC { get; private set; }

			public BerTag Tag { get; private set; }

			public byte[] Content { get; private set; }

			public DataElement(BerClass @class, BerPC pc, BerTag tag, byte[] content)
			{
				this = default(DataElement);
				Class = @class;
				PC = pc;
				Tag = tag;
				Content = content;
			}

			public DataElement(BerClass @class, BerPC pc, BerTag tag, params DataElement[] nestedElements)
				: this(@class, pc, tag, WriteAsn1Elements(nestedElements))
			{
			}
		}

		internal static IEnumerable<DataElement> ReadAsn1Elements(this Stream stream)
		{
			Requires.NotNull(stream, "stream");
			while (true)
			{
				int num = stream.ReadByte();
				if (num == -1)
				{
					yield break;
				}
				BerClass berClass = (BerClass)((byte)num & 0xC0);
				BerPC pc = (BerPC)((byte)num & 0x20);
				BerTag tag = (BerTag)((byte)num & 0x1F);
				uint num2 = 0u;
				num = stream.ReadByte();
				if ((num & 0x80) == 128)
				{
					byte b = (byte)(num & 0x7F);
					for (int i = 0; i < b; i++)
					{
						num = stream.ReadByte();
						num2 <<= 8;
						num2 += (uint)num;
					}
				}
				else
				{
					num2 = (uint)num;
				}
				if (num2 > 8192)
				{
					throw new FormatException("Invalid format or length too large.");
				}
				byte[] array = new byte[num2];
				if (stream.Read(array, 0, (int)num2) != num2)
				{
					break;
				}
				yield return new DataElement(berClass, pc, tag, array);
			}
			throw new ArgumentException("Unexpected end of stream.");
		}

		internal static IEnumerable<DataElement> ReadAsn1Elements(byte[] value)
		{
			return new MemoryStream(value).ReadAsn1Elements();
		}

		internal static void WriteAsn1Element(this Stream stream, DataElement element)
		{
			Requires.NotNull(stream, "stream");
			byte value = (byte)((uint)element.Class | (uint)element.PC | (uint)element.Tag);
			stream.WriteByte(value);
			if (element.Content.Length < 128)
			{
				stream.WriteByte((byte)element.Content.Length);
			}
			else
			{
				byte minimumBytesRequiredToRepresent = GetMinimumBytesRequiredToRepresent((uint)element.Content.Length);
				stream.WriteByte((byte)(128 + minimumBytesRequiredToRepresent));
				for (int num = minimumBytesRequiredToRepresent - 1; num >= 0; num--)
				{
					byte value2 = (byte)(0xFF & (element.Content.Length >> 8 * num));
					stream.WriteByte(value2);
				}
			}
			stream.Write(element.Content, 0, element.Content.Length);
		}

		internal static byte[] WriteAsn1Element(DataElement element)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteAsn1Element(element);
			return memoryStream.ToArray();
		}

		internal static byte[] WriteAsn1Elements(params DataElement[] elements)
		{
			MemoryStream memoryStream = new MemoryStream();
			foreach (DataElement element in elements)
			{
				memoryStream.WriteAsn1Element(element);
			}
			return memoryStream.ToArray();
		}

		private static byte GetMinimumBytesRequiredToRepresent(uint value)
		{
			if (value > 16777215)
			{
				return 4;
			}
			if (value > 65535)
			{
				return 3;
			}
			if (value > 255)
			{
				return 2;
			}
			return 1;
		}
	}
	internal class CapiKeyFormatter : KeyFormatter
	{
		private const byte PublicKeyBlobHeader = 6;

		private const byte PrivateKeyBlobHeader = 7;

		private const byte CurrentBlobVersion = 2;

		private const string PublicKeyMagicHeader = "RSA1";

		private const string PrivateKeyMagicHeader = "RSA2";

		private const int KeySpecKeyExchange = 41984;

		internal static bool IsCapiCompatible(RSAParameters parameters)
		{
			if (!KeyFormatter.HasPrivateKey(parameters))
			{
				return true;
			}
			int num = (parameters.Modulus.Length + 1) / 2;
			if (num == parameters.P.Length && num == parameters.Q.Length && num == parameters.DP.Length && num == parameters.DQ.Length && num == parameters.InverseQ.Length)
			{
				return parameters.Modulus.Length == parameters.D.Length;
			}
			return false;
		}

		internal static void VerifyCapiCompatibleParameters(RSAParameters parameters)
		{
			try
			{
				KeyFormatter.VerifyFormat(IsCapiCompatible(parameters), "Private key parameters have lengths that are not supported by CAPI.");
			}
			catch (FormatException ex)
			{
				throw new NotSupportedException(ex.Message, ex);
			}
		}

		protected override RSAParameters ReadCore(Stream stream)
		{
			RSAParameters result = default(RSAParameters);
			BinaryReader binaryReader = new BinaryReader(stream);
			bool flag = binaryReader.ReadByte() switch
			{
				7 => true, 
				6 => false, 
				_ => throw KeyFormatter.FailFormat(), 
			};
			KeyFormatter.VerifyFormat(binaryReader.ReadByte() == 2);
			KeyFormatter.VerifyFormat(binaryReader.ReadInt16() == 0);
			KeyFormatter.VerifyFormat(binaryReader.ReadInt32() == 41984);
			string text = Encoding.UTF8.GetString(binaryReader.ReadBytes(4), 0, 4);
			KeyFormatter.VerifyFormat(flag ? (text == "RSA2") : (text == "RSA1"));
			int num = binaryReader.ReadInt32() / 8;
			result.Exponent = ReadReversed(binaryReader, 4);
			result.Modulus = ReadReversed(binaryReader, num);
			if (flag)
			{
				result.P = ReadReversed(binaryReader, num / 2);
				result.Q = ReadReversed(binaryReader, num / 2);
				result.DP = ReadReversed(binaryReader, num / 2);
				result.DQ = ReadReversed(binaryReader, num / 2);
				result.InverseQ = ReadReversed(binaryReader, num / 2);
				result.D = ReadReversed(binaryReader, num);
			}
			return result;
		}

		protected override void WriteCore(Stream stream, RSAParameters parameters)
		{
			VerifyCapiCompatibleParameters(parameters);
			BinaryWriter binaryWriter = new BinaryWriter(stream);
			int num = ((parameters.Modulus[0] == 0) ? (parameters.Modulus.Length - 1) : parameters.Modulus.Length);
			int value = 8 * num;
			binaryWriter.Write((byte)(KeyFormatter.HasPrivateKey(parameters) ? 7 : 6));
			binaryWriter.Write((byte)2);
			binaryWriter.Write((short)0);
			binaryWriter.Write(41984);
			binaryWriter.Write(Encoding.UTF8.GetBytes(KeyFormatter.HasPrivateKey(parameters) ? "RSA2" : "RSA1"));
			binaryWriter.Write(value);
			byte[] buffer = new byte[4 - parameters.Exponent.Length];
			WriteReversed(binaryWriter, parameters.Exponent);
			binaryWriter.Write(buffer);
			WriteReversed(binaryWriter, parameters.Modulus, num);
			if (KeyFormatter.HasPrivateKey(parameters))
			{
				WriteReversed(binaryWriter, parameters.P, num / 2);
				WriteReversed(binaryWriter, parameters.Q, num / 2);
				WriteReversed(binaryWriter, parameters.DP, num / 2);
				WriteReversed(binaryWriter, parameters.DQ, num / 2);
				WriteReversed(binaryWriter, parameters.InverseQ, num / 2);
				WriteReversed(binaryWriter, parameters.D, num);
			}
			binaryWriter.Flush();
			binaryWriter.Dispose();
		}

		private static byte[] CopyAndReverse(byte[] data)
		{
			byte[] array = new byte[data.Length];
			Array.Copy(data, 0, array, 0, data.Length);
			Array.Reverse((Array)array);
			return array;
		}

		private static void WriteReversed(BinaryWriter writer, byte[] data, int length = -1)
		{
			writer.Write(CopyAndReverse(data), 0, (length < 0) ? data.Length : length);
		}

		private static byte[] ReadReversed(BinaryReader reader, int length)
		{
			byte[] array = reader.ReadBytes(length);
			Array.Reverse((Array)array);
			return array;
		}
	}
	internal abstract class KeyFormatter
	{
		internal static readonly KeyFormatter Pkcs1 = new Pkcs1KeyFormatter();

		internal static readonly KeyFormatter Pkcs1PrependZeros = new Pkcs1KeyFormatter(prependLeadingZeroOnCertainElements: true);

		internal static readonly KeyFormatter Pkcs8 = new Pkcs8KeyFormatter();

		internal static readonly KeyFormatter X509SubjectPublicKeyInfo = new X509SubjectPublicKeyInfoFormatter();

		internal static readonly KeyFormatter Capi = new CapiKeyFormatter();

		protected static readonly byte[] Pkcs1ObjectIdentifier = new byte[8] { 42, 134, 72, 134, 247, 13, 1, 1 };

		protected static readonly byte[] RsaEncryptionObjectIdentifier = new byte[9] { 42, 134, 72, 134, 247, 13, 1, 1, 1 };

		internal static KeyFormatter GetFormatter(CryptographicPrivateKeyBlobType blobType)
		{
			return blobType switch
			{
				CryptographicPrivateKeyBlobType.Pkcs8RawPrivateKeyInfo => Pkcs8, 
				CryptographicPrivateKeyBlobType.Pkcs1RsaPrivateKey => Pkcs1PrependZeros, 
				CryptographicPrivateKeyBlobType.Capi1PrivateKey => Capi, 
				_ => throw new NotSupportedException(), 
			};
		}

		internal static KeyFormatter GetFormatter(CryptographicPublicKeyBlobType blobType)
		{
			return blobType switch
			{
				CryptographicPublicKeyBlobType.X509SubjectPublicKeyInfo => X509SubjectPublicKeyInfo, 
				CryptographicPublicKeyBlobType.Pkcs1RsaPublicKey => Pkcs1PrependZeros, 
				CryptographicPublicKeyBlobType.Capi1PublicKey => Capi, 
				_ => throw new NotSupportedException(), 
			};
		}

		internal void Write(Stream stream, RSAParameters parameters)
		{
			Write(stream, parameters, HasPrivateKey(parameters));
		}

		internal void Write(Stream stream, RSAParameters parameters, bool includePrivateKey)
		{
			Requires.NotNull(stream, "stream");
			Requires.Argument(HasPrivateKey(parameters) || !includePrivateKey, "parameters", "No private key data included.");
			if (!includePrivateKey)
			{
				parameters = PublicKeyFilter(parameters);
			}
			RSAParameters parameters2 = NegotiateSizes(parameters);
			WriteCore(stream, parameters2);
		}

		internal byte[] Write(RSAParameters parameters)
		{
			return Write(parameters, HasPrivateKey(parameters));
		}

		internal byte[] Write(RSAParameters parameters, bool includePrivateKey)
		{
			MemoryStream memoryStream = new MemoryStream();
			Write(memoryStream, parameters, includePrivateKey);
			return memoryStream.ToArray();
		}

		internal RSAParameters Read(Stream stream)
		{
			return NegotiateSizes(ReadCore(stream));
		}

		internal RSAParameters Read(byte[] keyBlob)
		{
			MemoryStream stream = new MemoryStream(keyBlob);
			return Read(stream);
		}

		protected internal static RSAParameters PublicKeyFilter(RSAParameters value)
		{
			return new RSAParameters
			{
				Modulus = value.Modulus,
				Exponent = value.Exponent
			};
		}

		protected internal static RSAParameters NegotiateSizes(RSAParameters parameters)
		{
			if (HasPrivateKey(parameters))
			{
				if (CapiKeyFormatter.IsCapiCompatible(parameters))
				{
					return parameters;
				}
				parameters.Modulus = TrimLeadingZero(parameters.Modulus);
				parameters.D = TrimLeadingZero(parameters.D);
				int num = Math.Max(parameters.Modulus.Length, parameters.D.Length);
				parameters.Modulus = TrimOrPadZeroToLength(parameters.Modulus, num);
				parameters.D = TrimOrPadZeroToLength(parameters.D, num);
				int desiredLength = (num + 1) / 2;
				parameters.P = TrimOrPadZeroToLength(parameters.P, desiredLength);
				parameters.Q = TrimOrPadZeroToLength(parameters.Q, desiredLength);
				parameters.DP = TrimOrPadZeroToLength(parameters.DP, desiredLength);
				parameters.DQ = TrimOrPadZeroToLength(parameters.DQ, desiredLength);
				parameters.InverseQ = TrimOrPadZeroToLength(parameters.InverseQ, desiredLength);
			}
			else
			{
				parameters.Modulus = TrimLeadingZero(parameters.Modulus);
			}
			parameters.Exponent = TrimLeadingZero(parameters.Exponent);
			return parameters;
		}

		protected internal static bool HasPrivateKey(RSAParameters parameters)
		{
			return parameters.P != null;
		}

		protected internal static System.Security.Cryptography.RSAParameters ToPlatformParameters(RSAParameters value)
		{
			return new System.Security.Cryptography.RSAParameters
			{
				D = value.D,
				Q = value.Q,
				P = value.P,
				DP = value.DP,
				DQ = value.DQ,
				Exponent = value.Exponent,
				InverseQ = value.InverseQ,
				Modulus = value.Modulus
			};
		}

		protected internal static RSAParameters ToPCLParameters(System.Security.Cryptography.RSAParameters value)
		{
			return new RSAParameters
			{
				D = value.D,
				Q = value.Q,
				P = value.P,
				DP = value.DP,
				DQ = value.DQ,
				Exponent = value.Exponent,
				InverseQ = value.InverseQ,
				Modulus = value.Modulus
			};
		}

		protected static bool BufferEqual(byte[] buffer1, byte[] buffer2)
		{
			Requires.NotNull(buffer1, "buffer1");
			Requires.NotNull(buffer2, "buffer2");
			if (buffer1.Length != buffer2.Length)
			{
				return false;
			}
			for (int i = 0; i < buffer1.Length; i++)
			{
				if (buffer1[i] != buffer2[i])
				{
					return false;
				}
			}
			return true;
		}

		protected static byte[] TrimLeadingZero(byte[] buffer)
		{
			Requires.NotNull(buffer, "buffer");
			if (buffer.Length != 0 && buffer[0] == 0)
			{
				byte[] array = new byte[buffer.Length - 1];
				Buffer.BlockCopy(buffer, 1, array, 0, array.Length);
				return array;
			}
			return buffer;
		}

		protected static byte[] TrimOrPadZeroToLength(byte[] buffer, int desiredLength)
		{
			Requires.NotNull(buffer, "buffer");
			Requires.Range(desiredLength > 0, "desiredLength");
			if (buffer.Length > desiredLength)
			{
				return TrimLeadingZero(buffer);
			}
			if (buffer.Length < desiredLength)
			{
				return PrependLeadingZero(buffer);
			}
			return buffer;
		}

		protected static byte[] PrependLeadingZero(byte[] buffer, bool alwaysPrependZero = false)
		{
			Requires.NotNull(buffer, "buffer");
			if (buffer[0] != 0 || alwaysPrependZero)
			{
				byte[] array = new byte[buffer.Length + 1];
				Buffer.BlockCopy(buffer, 0, array, 1, buffer.Length);
				return array;
			}
			return buffer;
		}

		protected static void VerifyFormat(bool condition, string message = null)
		{
			if (!condition)
			{
				FailFormat(message);
			}
		}

		protected static Exception FailFormat(string message = null)
		{
			throw new FormatException(message ?? "Unexpected format or unsupported key.");
		}

		protected abstract RSAParameters ReadCore(Stream stream);

		protected abstract void WriteCore(Stream stream, RSAParameters parameters);
	}
	internal class Pkcs1KeyFormatter : KeyFormatter
	{
		private readonly bool prependLeadingZeroOnCertainElements;

		internal Pkcs1KeyFormatter(bool prependLeadingZeroOnCertainElements = false)
		{
			this.prependLeadingZeroOnCertainElements = prependLeadingZeroOnCertainElements;
		}

		protected override RSAParameters ReadCore(Stream stream)
		{
			Asn.DataElement dataElement = stream.ReadAsn1Elements().First();
			KeyFormatter.VerifyFormat(dataElement.Class == Asn.BerClass.Universal && dataElement.PC == Asn.BerPC.Constructed && dataElement.Tag == Asn.BerTag.Sequence);
			stream = new MemoryStream(dataElement.Content);
			List<Asn.DataElement> list = stream.ReadAsn1Elements().ToList();
			switch (list.Count)
			{
			case 2:
				return new RSAParameters
				{
					Modulus = list[0].Content,
					Exponent = list[1].Content
				};
			case 9:
				KeyFormatter.VerifyFormat(list[0].Content.Length == 1 && list[0].Content[0] == 0, "Unsupported version.");
				return new RSAParameters
				{
					Modulus = list[1].Content,
					Exponent = list[2].Content,
					D = list[3].Content,
					P = list[4].Content,
					Q = list[5].Content,
					DP = list[6].Content,
					DQ = list[7].Content,
					InverseQ = list[8].Content
				};
			default:
				throw KeyFormatter.FailFormat();
			}
		}

		protected override void WriteCore(Stream stream, RSAParameters value)
		{
			Requires.NotNull(stream, "stream");
			MemoryStream memoryStream = new MemoryStream();
			if (KeyFormatter.HasPrivateKey(value))
			{
				memoryStream.WriteAsn1Element(new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Integer, new byte[1]));
			}
			memoryStream.WriteAsn1Element(new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Integer, prependLeadingZeroOnCertainElements ? KeyFormatter.PrependLeadingZero(value.Modulus) : value.Modulus));
			memoryStream.WriteAsn1Element(new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Integer, value.Exponent));
			if (KeyFormatter.HasPrivateKey(value))
			{
				memoryStream.WriteAsn1Element(new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Integer, value.D));
				memoryStream.WriteAsn1Element(new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Integer, prependLeadingZeroOnCertainElements ? KeyFormatter.PrependLeadingZero(value.P) : value.P));
				memoryStream.WriteAsn1Element(new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Integer, prependLeadingZeroOnCertainElements ? KeyFormatter.PrependLeadingZero(value.Q) : value.Q));
				memoryStream.WriteAsn1Element(new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Integer, prependLeadingZeroOnCertainElements ? KeyFormatter.PrependLeadingZero(value.DP) : value.DP));
				memoryStream.WriteAsn1Element(new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Integer, value.DQ));
				memoryStream.WriteAsn1Element(new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Integer, prependLeadingZeroOnCertainElements ? KeyFormatter.PrependLeadingZero(value.InverseQ) : value.InverseQ));
			}
			stream.WriteAsn1Element(new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Constructed, Asn.BerTag.Sequence, memoryStream.ToArray()));
		}
	}
	internal class Pkcs8KeyFormatter : KeyFormatter
	{
		protected override RSAParameters ReadCore(Stream stream)
		{
			List<Asn.DataElement> list = Asn.ReadAsn1Elements(stream.ReadAsn1Elements().Single().Content).ToList();
			KeyFormatter.VerifyFormat(list[0].Content.Length == 1 && list[0].Content[0] == 0, "Unrecognized version.");
			KeyFormatter.VerifyFormat(KeyFormatter.BufferEqual(Asn.ReadAsn1Elements(list[1].Content).First().Content, KeyFormatter.RsaEncryptionObjectIdentifier), "Unrecognized object identifier.");
			return KeyFormatter.Pkcs1.Read(list[2].Content);
		}

		protected override void WriteCore(Stream stream, RSAParameters parameters)
		{
			Asn.DataElement element = new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Constructed, Asn.BerTag.Sequence, new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Integer, new byte[1]), new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Constructed, Asn.BerTag.Sequence, new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.ObjectIdentifier, KeyFormatter.RsaEncryptionObjectIdentifier), new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Null, new byte[0])), new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.OctetString, KeyFormatter.Pkcs1PrependZeros.Write(parameters, KeyFormatter.HasPrivateKey(parameters))), new Asn.DataElement(Asn.BerClass.ContextSpecific, Asn.BerPC.Constructed, Asn.BerTag.EndOfContent, new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Constructed, Asn.BerTag.Sequence, new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.ObjectIdentifier, new byte[3] { 85, 29, 15 }), new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Constructed, Asn.BerTag.SetAndSetOf, new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.BitString, new byte[2] { 0, 16 })))));
			stream.WriteAsn1Element(element);
		}
	}
	internal class X509SubjectPublicKeyInfoFormatter : KeyFormatter
	{
		protected override RSAParameters ReadCore(Stream stream)
		{
			Asn.DataElement dataElement = stream.ReadAsn1Elements().First();
			if (dataElement.Class != Asn.BerClass.Universal || dataElement.PC != Asn.BerPC.Constructed || dataElement.Tag != Asn.BerTag.Sequence)
			{
				throw new ArgumentException("Unexpected format.");
			}
			List<Asn.DataElement> list = Asn.ReadAsn1Elements(dataElement.Content).ToList();
			if (list.Count != 2 || list[0].Class != Asn.BerClass.Universal || list[0].PC != Asn.BerPC.Constructed || list[0].Tag != Asn.BerTag.Sequence)
			{
				throw new ArgumentException("Unexpected format.");
			}
			Asn.DataElement dataElement2 = Asn.ReadAsn1Elements(list[0].Content).First();
			if (!KeyFormatter.BufferEqual(KeyFormatter.RsaEncryptionObjectIdentifier, dataElement2.Content))
			{
				throw new ArgumentException("Unexpected algorithm.");
			}
			if (list[1].Class != Asn.BerClass.Universal || list[1].PC != Asn.BerPC.Primitive || list[1].Tag != Asn.BerTag.BitString || list[1].Content[0] != 0)
			{
				throw new ArgumentException("Unexpected format.");
			}
			byte[] keyBlob = KeyFormatter.TrimLeadingZero(list[1].Content);
			return KeyFormatter.PublicKeyFilter(KeyFormatter.Pkcs1.Read(keyBlob));
		}

		protected override void WriteCore(Stream stream, RSAParameters parameters)
		{
			Requires.NotNull(stream, "stream");
			Asn.DataElement element = new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Constructed, Asn.BerTag.Sequence, new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Constructed, Asn.BerTag.Sequence, new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.ObjectIdentifier, KeyFormatter.RsaEncryptionObjectIdentifier), new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.Null, new byte[0])), new Asn.DataElement(Asn.BerClass.Universal, Asn.BerPC.Primitive, Asn.BerTag.BitString, KeyFormatter.PrependLeadingZero(KeyFormatter.Pkcs1PrependZeros.Write(parameters, includePrivateKey: false), alwaysPrependZero: true)));
			stream.WriteAsn1Element(element);
		}
	}
}
