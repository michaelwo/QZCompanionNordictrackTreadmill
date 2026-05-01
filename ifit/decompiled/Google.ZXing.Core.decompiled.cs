using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Runtime;
using Google.ZXing.Common;
using Google.ZXing.Multi;
using Google.ZXing.QRCode;
using Google.ZXing.QRCode.Decoder;
using Google.ZXing.QRCode.Detector;
using Java.Interop;
using Java.Lang;
using Java.Nio.Charset;
using Java.Util;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "com.google.zxing", Managed = "Google.ZXing")]
[assembly: NamespaceMapping(Java = "com.google.zxing.aztec", Managed = "Google.ZXing.Aztec")]
[assembly: NamespaceMapping(Java = "com.google.zxing.aztec.decoder", Managed = "Google.ZXing.Aztec.Decoder")]
[assembly: NamespaceMapping(Java = "com.google.zxing.aztec.detector", Managed = "Google.ZXing.Aztec.Detector")]
[assembly: NamespaceMapping(Java = "com.google.zxing.aztec.encoder", Managed = "Google.ZXing.Aztec.Encoder")]
[assembly: NamespaceMapping(Java = "com.google.zxing.client.result", Managed = "Google.ZXing.Client.Result")]
[assembly: NamespaceMapping(Java = "com.google.zxing.common", Managed = "Google.ZXing.Common")]
[assembly: NamespaceMapping(Java = "com.google.zxing.common.detector", Managed = "Google.ZXing.Common.Detector")]
[assembly: NamespaceMapping(Java = "com.google.zxing.common.reedsolomon", Managed = "Google.ZXing.Common.ReedSolomon")]
[assembly: NamespaceMapping(Java = "com.google.zxing.datamatrix", Managed = "Google.ZXing.DataMatrix")]
[assembly: NamespaceMapping(Java = "com.google.zxing.datamatrix.decoder", Managed = "Google.ZXing.DataMatrix.Decoder")]
[assembly: NamespaceMapping(Java = "com.google.zxing.datamatrix.detector", Managed = "Google.ZXing.DataMatrix.Detector")]
[assembly: NamespaceMapping(Java = "com.google.zxing.datamatrix.encoder", Managed = "Google.ZXing.DataMatrix.Encoder")]
[assembly: NamespaceMapping(Java = "com.google.zxing.maxicode", Managed = "Google.ZXing.MaxiCode")]
[assembly: NamespaceMapping(Java = "com.google.zxing.maxicode.decoder", Managed = "Google.ZXing.MaxiCode.Decoder")]
[assembly: NamespaceMapping(Java = "com.google.zxing.multi", Managed = "Google.ZXing.Multi")]
[assembly: NamespaceMapping(Java = "com.google.zxing.multi.qrcode", Managed = "Google.ZXing.Multi.QRCode")]
[assembly: NamespaceMapping(Java = "com.google.zxing.multi.qrcode.detector", Managed = "Google.ZXing.Multi.QRCode.Detector")]
[assembly: NamespaceMapping(Java = "com.google.zxing.oned", Managed = "Google.ZXing.OneD")]
[assembly: NamespaceMapping(Java = "com.google.zxing.oned.rss", Managed = "Google.ZXing.OneD.RSS")]
[assembly: NamespaceMapping(Java = "com.google.zxing.oned.rss.expanded", Managed = "Google.ZXing.OneD.RSS.Expanded")]
[assembly: NamespaceMapping(Java = "com.google.zxing.oned.rss.expanded.decoders", Managed = "Google.ZXing.OneD.RSS.Expanded.Decoders")]
[assembly: NamespaceMapping(Java = "com.google.zxing.pdf417", Managed = "Google.ZXing.PDF417")]
[assembly: NamespaceMapping(Java = "com.google.zxing.pdf417.decoder", Managed = "Google.ZXing.PDF417.Decoder")]
[assembly: NamespaceMapping(Java = "com.google.zxing.pdf417.decoder.ec", Managed = "Google.ZXing.PDF417.Decoder.EC")]
[assembly: NamespaceMapping(Java = "com.google.zxing.pdf417.detector", Managed = "Google.ZXing.PDF417.Detector")]
[assembly: NamespaceMapping(Java = "com.google.zxing.pdf417.encoder", Managed = "Google.ZXing.PDF417.Encoder")]
[assembly: NamespaceMapping(Java = "com.google.zxing.qrcode", Managed = "Google.ZXing.QRCode")]
[assembly: NamespaceMapping(Java = "com.google.zxing.qrcode.decoder", Managed = "Google.ZXing.QRCode.Decoder")]
[assembly: NamespaceMapping(Java = "com.google.zxing.qrcode.detector", Managed = "Google.ZXing.QRCode.Detector")]
[assembly: NamespaceMapping(Java = "com.google.zxing.qrcode.encoder", Managed = "Google.ZXing.QRCode.Encoder")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("3.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Google.ZXing.Core")]
[assembly: AssemblyTitle("Google.ZXing.Core")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("3.0.0.0")]
[module: UnverifiableCode]
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_google_zxing_mappings;

		private static string[] package_com_google_zxing_aztec_mappings;

		private static string[] package_com_google_zxing_aztec_decoder_mappings;

		private static string[] package_com_google_zxing_aztec_detector_mappings;

		private static string[] package_com_google_zxing_aztec_encoder_mappings;

		private static string[] package_com_google_zxing_client_result_mappings;

		private static string[] package_com_google_zxing_common_mappings;

		private static string[] package_com_google_zxing_common_detector_mappings;

		private static string[] package_com_google_zxing_common_reedsolomon_mappings;

		private static string[] package_com_google_zxing_datamatrix_mappings;

		private static string[] package_com_google_zxing_datamatrix_decoder_mappings;

		private static string[] package_com_google_zxing_datamatrix_detector_mappings;

		private static string[] package_com_google_zxing_datamatrix_encoder_mappings;

		private static string[] package_com_google_zxing_maxicode_mappings;

		private static string[] package_com_google_zxing_maxicode_decoder_mappings;

		private static string[] package_com_google_zxing_multi_mappings;

		private static string[] package_com_google_zxing_multi_qrcode_mappings;

		private static string[] package_com_google_zxing_multi_qrcode_detector_mappings;

		private static string[] package_com_google_zxing_oned_mappings;

		private static string[] package_com_google_zxing_oned_rss_mappings;

		private static string[] package_com_google_zxing_oned_rss_expanded_mappings;

		private static string[] package_com_google_zxing_oned_rss_expanded_decoders_mappings;

		private static string[] package_com_google_zxing_pdf417_mappings;

		private static string[] package_com_google_zxing_pdf417_decoder_mappings;

		private static string[] package_com_google_zxing_pdf417_decoder_ec_mappings;

		private static string[] package_com_google_zxing_pdf417_detector_mappings;

		private static string[] package_com_google_zxing_pdf417_encoder_mappings;

		private static string[] package_com_google_zxing_qrcode_mappings;

		private static string[] package_com_google_zxing_qrcode_decoder_mappings;

		private static string[] package_com_google_zxing_qrcode_detector_mappings;

		private static string[] package_com_google_zxing_qrcode_encoder_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[31]
			{
				"com/google/zxing", "com/google/zxing/aztec", "com/google/zxing/aztec/decoder", "com/google/zxing/aztec/detector", "com/google/zxing/aztec/encoder", "com/google/zxing/client/result", "com/google/zxing/common", "com/google/zxing/common/detector", "com/google/zxing/common/reedsolomon", "com/google/zxing/datamatrix",
				"com/google/zxing/datamatrix/decoder", "com/google/zxing/datamatrix/detector", "com/google/zxing/datamatrix/encoder", "com/google/zxing/maxicode", "com/google/zxing/maxicode/decoder", "com/google/zxing/multi", "com/google/zxing/multi/qrcode", "com/google/zxing/multi/qrcode/detector", "com/google/zxing/oned", "com/google/zxing/oned/rss",
				"com/google/zxing/oned/rss/expanded", "com/google/zxing/oned/rss/expanded/decoders", "com/google/zxing/pdf417", "com/google/zxing/pdf417/decoder", "com/google/zxing/pdf417/decoder/ec", "com/google/zxing/pdf417/detector", "com/google/zxing/pdf417/encoder", "com/google/zxing/qrcode", "com/google/zxing/qrcode/decoder", "com/google/zxing/qrcode/detector",
				"com/google/zxing/qrcode/encoder"
			}, new Converter<string, Type>[31]
			{
				lookup_com_google_zxing_package, lookup_com_google_zxing_aztec_package, lookup_com_google_zxing_aztec_decoder_package, lookup_com_google_zxing_aztec_detector_package, lookup_com_google_zxing_aztec_encoder_package, lookup_com_google_zxing_client_result_package, lookup_com_google_zxing_common_package, lookup_com_google_zxing_common_detector_package, lookup_com_google_zxing_common_reedsolomon_package, lookup_com_google_zxing_datamatrix_package,
				lookup_com_google_zxing_datamatrix_decoder_package, lookup_com_google_zxing_datamatrix_detector_package, lookup_com_google_zxing_datamatrix_encoder_package, lookup_com_google_zxing_maxicode_package, lookup_com_google_zxing_maxicode_decoder_package, lookup_com_google_zxing_multi_package, lookup_com_google_zxing_multi_qrcode_package, lookup_com_google_zxing_multi_qrcode_detector_package, lookup_com_google_zxing_oned_package, lookup_com_google_zxing_oned_rss_package,
				lookup_com_google_zxing_oned_rss_expanded_package, lookup_com_google_zxing_oned_rss_expanded_decoders_package, lookup_com_google_zxing_pdf417_package, lookup_com_google_zxing_pdf417_decoder_package, lookup_com_google_zxing_pdf417_decoder_ec_package, lookup_com_google_zxing_pdf417_detector_package, lookup_com_google_zxing_pdf417_encoder_package, lookup_com_google_zxing_qrcode_package, lookup_com_google_zxing_qrcode_decoder_package, lookup_com_google_zxing_qrcode_detector_package,
				lookup_com_google_zxing_qrcode_encoder_package
			});
		}

		private static Type Lookup(string[] mappings, string javaType)
		{
			string text = TypeManager.LookupTypeMapping(mappings, javaType);
			if (text == null)
			{
				return null;
			}
			return Type.GetType(text);
		}

		private static Type lookup_com_google_zxing_package(string klass)
		{
			if (package_com_google_zxing_mappings == null)
			{
				package_com_google_zxing_mappings = new string[20]
				{
					"com/google/zxing/BarcodeFormat:Google.ZXing.BarcodeFormat", "com/google/zxing/Binarizer:Google.ZXing.Binarizer", "com/google/zxing/BinaryBitmap:Google.ZXing.BinaryBitmap", "com/google/zxing/ChecksumException:Google.ZXing.ChecksumException", "com/google/zxing/DecodeHintType:Google.ZXing.DecodeHintType", "com/google/zxing/Dimension:Google.ZXing.Dimension", "com/google/zxing/EncodeHintType:Google.ZXing.EncodeHintType", "com/google/zxing/FormatException:Google.ZXing.FormatException", "com/google/zxing/InvertedLuminanceSource:Google.ZXing.InvertedLuminanceSource", "com/google/zxing/LuminanceSource:Google.ZXing.LuminanceSource",
					"com/google/zxing/MultiFormatReader:Google.ZXing.MultiFormatReader", "com/google/zxing/MultiFormatWriter:Google.ZXing.MultiFormatWriter", "com/google/zxing/NotFoundException:Google.ZXing.NotFoundException", "com/google/zxing/PlanarYUVLuminanceSource:Google.ZXing.PlanarYUVLuminanceSource", "com/google/zxing/ReaderException:Google.ZXing.ReaderException", "com/google/zxing/Result:Google.ZXing.Result", "com/google/zxing/ResultMetadataType:Google.ZXing.ResultMetadataType", "com/google/zxing/ResultPoint:Google.ZXing.ResultPoint", "com/google/zxing/RGBLuminanceSource:Google.ZXing.RGBLuminanceSource", "com/google/zxing/WriterException:Google.ZXing.WriterException"
				};
			}
			return Lookup(package_com_google_zxing_mappings, klass);
		}

		private static Type lookup_com_google_zxing_aztec_package(string klass)
		{
			if (package_com_google_zxing_aztec_mappings == null)
			{
				package_com_google_zxing_aztec_mappings = new string[3] { "com/google/zxing/aztec/AztecDetectorResult:Google.ZXing.Aztec.AztecDetectorResult", "com/google/zxing/aztec/AztecReader:Google.ZXing.Aztec.AztecReader", "com/google/zxing/aztec/AztecWriter:Google.ZXing.Aztec.AztecWriter" };
			}
			return Lookup(package_com_google_zxing_aztec_mappings, klass);
		}

		private static Type lookup_com_google_zxing_aztec_decoder_package(string klass)
		{
			if (package_com_google_zxing_aztec_decoder_mappings == null)
			{
				package_com_google_zxing_aztec_decoder_mappings = new string[1] { "com/google/zxing/aztec/decoder/Decoder:Google.ZXing.Aztec.Decoder.Decoder" };
			}
			return Lookup(package_com_google_zxing_aztec_decoder_mappings, klass);
		}

		private static Type lookup_com_google_zxing_aztec_detector_package(string klass)
		{
			if (package_com_google_zxing_aztec_detector_mappings == null)
			{
				package_com_google_zxing_aztec_detector_mappings = new string[2] { "com/google/zxing/aztec/detector/Detector:Google.ZXing.Aztec.Detector.Detector", "com/google/zxing/aztec/detector/Detector$Point:Google.ZXing.Aztec.Detector.Detector/Point" };
			}
			return Lookup(package_com_google_zxing_aztec_detector_mappings, klass);
		}

		private static Type lookup_com_google_zxing_aztec_encoder_package(string klass)
		{
			if (package_com_google_zxing_aztec_encoder_mappings == null)
			{
				package_com_google_zxing_aztec_encoder_mappings = new string[7] { "com/google/zxing/aztec/encoder/AztecCode:Google.ZXing.Aztec.Encoder.AztecCode", "com/google/zxing/aztec/encoder/BinaryShiftToken:Google.ZXing.Aztec.Encoder.BinaryShiftToken", "com/google/zxing/aztec/encoder/Encoder:Google.ZXing.Aztec.Encoder.Encoder", "com/google/zxing/aztec/encoder/HighLevelEncoder:Google.ZXing.Aztec.Encoder.HighLevelEncoder", "com/google/zxing/aztec/encoder/SimpleToken:Google.ZXing.Aztec.Encoder.SimpleToken", "com/google/zxing/aztec/encoder/State:Google.ZXing.Aztec.Encoder.State", "com/google/zxing/aztec/encoder/Token:Google.ZXing.Aztec.Encoder.Token" };
			}
			return Lookup(package_com_google_zxing_aztec_encoder_mappings, klass);
		}

		private static Type lookup_com_google_zxing_client_result_package(string klass)
		{
			if (package_com_google_zxing_client_result_mappings == null)
			{
				package_com_google_zxing_client_result_mappings = new string[37]
				{
					"com/google/zxing/client/result/AbstractDoCoMoResultParser:Google.ZXing.Client.Result.AbstractDoCoMoResultParser", "com/google/zxing/client/result/AddressBookAUResultParser:Google.ZXing.Client.Result.AddressBookAUResultParser", "com/google/zxing/client/result/AddressBookDoCoMoResultParser:Google.ZXing.Client.Result.AddressBookDoCoMoResultParser", "com/google/zxing/client/result/AddressBookParsedResult:Google.ZXing.Client.Result.AddressBookParsedResult", "com/google/zxing/client/result/BizcardResultParser:Google.ZXing.Client.Result.BizcardResultParser", "com/google/zxing/client/result/BookmarkDoCoMoResultParser:Google.ZXing.Client.Result.BookmarkDoCoMoResultParser", "com/google/zxing/client/result/CalendarParsedResult:Google.ZXing.Client.Result.CalendarParsedResult", "com/google/zxing/client/result/EmailAddressParsedResult:Google.ZXing.Client.Result.EmailAddressParsedResult", "com/google/zxing/client/result/EmailAddressResultParser:Google.ZXing.Client.Result.EmailAddressResultParser", "com/google/zxing/client/result/EmailDoCoMoResultParser:Google.ZXing.Client.Result.EmailDoCoMoResultParser",
					"com/google/zxing/client/result/ExpandedProductParsedResult:Google.ZXing.Client.Result.ExpandedProductParsedResult", "com/google/zxing/client/result/ExpandedProductResultParser:Google.ZXing.Client.Result.ExpandedProductResultParser", "com/google/zxing/client/result/GeoParsedResult:Google.ZXing.Client.Result.GeoParsedResult", "com/google/zxing/client/result/GeoResultParser:Google.ZXing.Client.Result.GeoResultParser", "com/google/zxing/client/result/ISBNParsedResult:Google.ZXing.Client.Result.ISBNParsedResult", "com/google/zxing/client/result/ISBNResultParser:Google.ZXing.Client.Result.ISBNResultParser", "com/google/zxing/client/result/ParsedResult:Google.ZXing.Client.Result.ParsedResult", "com/google/zxing/client/result/ParsedResultType:Google.ZXing.Client.Result.ParsedResultType", "com/google/zxing/client/result/ProductParsedResult:Google.ZXing.Client.Result.ProductParsedResult", "com/google/zxing/client/result/ProductResultParser:Google.ZXing.Client.Result.ProductResultParser",
					"com/google/zxing/client/result/ResultParser:Google.ZXing.Client.Result.ResultParser", "com/google/zxing/client/result/SMSMMSResultParser:Google.ZXing.Client.Result.SMSMMSResultParser", "com/google/zxing/client/result/SMSParsedResult:Google.ZXing.Client.Result.SMSParsedResult", "com/google/zxing/client/result/SMSTOMMSTOResultParser:Google.ZXing.Client.Result.SMSTOMMSTOResultParser", "com/google/zxing/client/result/SMTPResultParser:Google.ZXing.Client.Result.SMTPResultParser", "com/google/zxing/client/result/TelParsedResult:Google.ZXing.Client.Result.TelParsedResult", "com/google/zxing/client/result/TelResultParser:Google.ZXing.Client.Result.TelResultParser", "com/google/zxing/client/result/TextParsedResult:Google.ZXing.Client.Result.TextParsedResult", "com/google/zxing/client/result/URIParsedResult:Google.ZXing.Client.Result.URIParsedResult", "com/google/zxing/client/result/URIResultParser:Google.ZXing.Client.Result.URIResultParser",
					"com/google/zxing/client/result/URLTOResultParser:Google.ZXing.Client.Result.URLTOResultParser", "com/google/zxing/client/result/VCardResultParser:Google.ZXing.Client.Result.VCardResultParser", "com/google/zxing/client/result/VEventResultParser:Google.ZXing.Client.Result.VEventResultParser", "com/google/zxing/client/result/VINParsedResult:Google.ZXing.Client.Result.VINParsedResult", "com/google/zxing/client/result/VINResultParser:Google.ZXing.Client.Result.VINResultParser", "com/google/zxing/client/result/WifiParsedResult:Google.ZXing.Client.Result.WifiParsedResult", "com/google/zxing/client/result/WifiResultParser:Google.ZXing.Client.Result.WifiResultParser"
				};
			}
			return Lookup(package_com_google_zxing_client_result_mappings, klass);
		}

		private static Type lookup_com_google_zxing_common_package(string klass)
		{
			if (package_com_google_zxing_common_mappings == null)
			{
				package_com_google_zxing_common_mappings = new string[12]
				{
					"com/google/zxing/common/BitArray:Google.ZXing.Common.BitArray", "com/google/zxing/common/BitMatrix:Google.ZXing.Common.BitMatrix", "com/google/zxing/common/BitSource:Google.ZXing.Common.BitSource", "com/google/zxing/common/CharacterSetECI:Google.ZXing.Common.CharacterSetECI", "com/google/zxing/common/DecoderResult:Google.ZXing.Common.DecoderResult", "com/google/zxing/common/DefaultGridSampler:Google.ZXing.Common.DefaultGridSampler", "com/google/zxing/common/DetectorResult:Google.ZXing.Common.DetectorResult", "com/google/zxing/common/GlobalHistogramBinarizer:Google.ZXing.Common.GlobalHistogramBinarizer", "com/google/zxing/common/GridSampler:Google.ZXing.Common.GridSampler", "com/google/zxing/common/HybridBinarizer:Google.ZXing.Common.HybridBinarizer",
					"com/google/zxing/common/PerspectiveTransform:Google.ZXing.Common.PerspectiveTransform", "com/google/zxing/common/StringUtils:Google.ZXing.Common.StringUtils"
				};
			}
			return Lookup(package_com_google_zxing_common_mappings, klass);
		}

		private static Type lookup_com_google_zxing_common_detector_package(string klass)
		{
			if (package_com_google_zxing_common_detector_mappings == null)
			{
				package_com_google_zxing_common_detector_mappings = new string[3] { "com/google/zxing/common/detector/MathUtils:Google.ZXing.Common.Detector.MathUtils", "com/google/zxing/common/detector/MonochromeRectangleDetector:Google.ZXing.Common.Detector.MonochromeRectangleDetector", "com/google/zxing/common/detector/WhiteRectangleDetector:Google.ZXing.Common.Detector.WhiteRectangleDetector" };
			}
			return Lookup(package_com_google_zxing_common_detector_mappings, klass);
		}

		private static Type lookup_com_google_zxing_common_reedsolomon_package(string klass)
		{
			if (package_com_google_zxing_common_reedsolomon_mappings == null)
			{
				package_com_google_zxing_common_reedsolomon_mappings = new string[5] { "com/google/zxing/common/reedsolomon/GenericGF:Google.ZXing.Common.ReedSolomon.GenericGF", "com/google/zxing/common/reedsolomon/GenericGFPoly:Google.ZXing.Common.ReedSolomon.GenericGFPoly", "com/google/zxing/common/reedsolomon/ReedSolomonDecoder:Google.ZXing.Common.ReedSolomon.ReedSolomonDecoder", "com/google/zxing/common/reedsolomon/ReedSolomonEncoder:Google.ZXing.Common.ReedSolomon.ReedSolomonEncoder", "com/google/zxing/common/reedsolomon/ReedSolomonException:Google.ZXing.Common.ReedSolomon.ReedSolomonException" };
			}
			return Lookup(package_com_google_zxing_common_reedsolomon_mappings, klass);
		}

		private static Type lookup_com_google_zxing_datamatrix_package(string klass)
		{
			if (package_com_google_zxing_datamatrix_mappings == null)
			{
				package_com_google_zxing_datamatrix_mappings = new string[2] { "com/google/zxing/datamatrix/DataMatrixReader:Google.ZXing.DataMatrix.DataMatrixReader", "com/google/zxing/datamatrix/DataMatrixWriter:Google.ZXing.DataMatrix.DataMatrixWriter" };
			}
			return Lookup(package_com_google_zxing_datamatrix_mappings, klass);
		}

		private static Type lookup_com_google_zxing_datamatrix_decoder_package(string klass)
		{
			if (package_com_google_zxing_datamatrix_decoder_mappings == null)
			{
				package_com_google_zxing_datamatrix_decoder_mappings = new string[7] { "com/google/zxing/datamatrix/decoder/BitMatrixParser:Google.ZXing.DataMatrix.Decoder.BitMatrixParser", "com/google/zxing/datamatrix/decoder/DataBlock:Google.ZXing.DataMatrix.Decoder.DataBlock", "com/google/zxing/datamatrix/decoder/DecodedBitStreamParser:Google.ZXing.DataMatrix.Decoder.DecodedBitStreamParser", "com/google/zxing/datamatrix/decoder/Decoder:Google.ZXing.DataMatrix.Decoder.Decoder", "com/google/zxing/datamatrix/decoder/Version:Google.ZXing.DataMatrix.Decoder.Version", "com/google/zxing/datamatrix/decoder/Version$ECB:Google.ZXing.DataMatrix.Decoder.Version/ECB", "com/google/zxing/datamatrix/decoder/Version$ECBlocks:Google.ZXing.DataMatrix.Decoder.Version/ECBlocks" };
			}
			return Lookup(package_com_google_zxing_datamatrix_decoder_mappings, klass);
		}

		private static Type lookup_com_google_zxing_datamatrix_detector_package(string klass)
		{
			if (package_com_google_zxing_datamatrix_detector_mappings == null)
			{
				package_com_google_zxing_datamatrix_detector_mappings = new string[1] { "com/google/zxing/datamatrix/detector/Detector:Google.ZXing.DataMatrix.Detector.Detector" };
			}
			return Lookup(package_com_google_zxing_datamatrix_detector_mappings, klass);
		}

		private static Type lookup_com_google_zxing_datamatrix_encoder_package(string klass)
		{
			if (package_com_google_zxing_datamatrix_encoder_mappings == null)
			{
				package_com_google_zxing_datamatrix_encoder_mappings = new string[13]
				{
					"com/google/zxing/datamatrix/encoder/ASCIIEncoder:Google.ZXing.DataMatrix.Encoder.ASCIIEncoder", "com/google/zxing/datamatrix/encoder/Base256Encoder:Google.ZXing.DataMatrix.Encoder.Base256Encoder", "com/google/zxing/datamatrix/encoder/C40Encoder:Google.ZXing.DataMatrix.Encoder.C40Encoder", "com/google/zxing/datamatrix/encoder/DataMatrixSymbolInfo144:Google.ZXing.DataMatrix.Encoder.DataMatrixSymbolInfo144", "com/google/zxing/datamatrix/encoder/DefaultPlacement:Google.ZXing.DataMatrix.Encoder.DefaultPlacement", "com/google/zxing/datamatrix/encoder/EdifactEncoder:Google.ZXing.DataMatrix.Encoder.EdifactEncoder", "com/google/zxing/datamatrix/encoder/EncoderContext:Google.ZXing.DataMatrix.Encoder.EncoderContext", "com/google/zxing/datamatrix/encoder/ErrorCorrection:Google.ZXing.DataMatrix.Encoder.ErrorCorrection", "com/google/zxing/datamatrix/encoder/HighLevelEncoder:Google.ZXing.DataMatrix.Encoder.HighLevelEncoder", "com/google/zxing/datamatrix/encoder/SymbolInfo:Google.ZXing.DataMatrix.Encoder.SymbolInfo",
					"com/google/zxing/datamatrix/encoder/SymbolShapeHint:Google.ZXing.DataMatrix.Encoder.SymbolShapeHint", "com/google/zxing/datamatrix/encoder/TextEncoder:Google.ZXing.DataMatrix.Encoder.TextEncoder", "com/google/zxing/datamatrix/encoder/X12Encoder:Google.ZXing.DataMatrix.Encoder.X12Encoder"
				};
			}
			return Lookup(package_com_google_zxing_datamatrix_encoder_mappings, klass);
		}

		private static Type lookup_com_google_zxing_maxicode_package(string klass)
		{
			if (package_com_google_zxing_maxicode_mappings == null)
			{
				package_com_google_zxing_maxicode_mappings = new string[1] { "com/google/zxing/maxicode/MaxiCodeReader:Google.ZXing.MaxiCode.MaxiCodeReader" };
			}
			return Lookup(package_com_google_zxing_maxicode_mappings, klass);
		}

		private static Type lookup_com_google_zxing_maxicode_decoder_package(string klass)
		{
			if (package_com_google_zxing_maxicode_decoder_mappings == null)
			{
				package_com_google_zxing_maxicode_decoder_mappings = new string[3] { "com/google/zxing/maxicode/decoder/BitMatrixParser:Google.ZXing.MaxiCode.Decoder.BitMatrixParser", "com/google/zxing/maxicode/decoder/DecodedBitStreamParser:Google.ZXing.MaxiCode.Decoder.DecodedBitStreamParser", "com/google/zxing/maxicode/decoder/Decoder:Google.ZXing.MaxiCode.Decoder.Decoder" };
			}
			return Lookup(package_com_google_zxing_maxicode_decoder_mappings, klass);
		}

		private static Type lookup_com_google_zxing_multi_package(string klass)
		{
			if (package_com_google_zxing_multi_mappings == null)
			{
				package_com_google_zxing_multi_mappings = new string[2] { "com/google/zxing/multi/ByQuadrantReader:Google.ZXing.Multi.ByQuadrantReader", "com/google/zxing/multi/GenericMultipleBarcodeReader:Google.ZXing.Multi.GenericMultipleBarcodeReader" };
			}
			return Lookup(package_com_google_zxing_multi_mappings, klass);
		}

		private static Type lookup_com_google_zxing_multi_qrcode_package(string klass)
		{
			if (package_com_google_zxing_multi_qrcode_mappings == null)
			{
				package_com_google_zxing_multi_qrcode_mappings = new string[1] { "com/google/zxing/multi/qrcode/QRCodeMultiReader:Google.ZXing.Multi.QRCode.QRCodeMultiReader" };
			}
			return Lookup(package_com_google_zxing_multi_qrcode_mappings, klass);
		}

		private static Type lookup_com_google_zxing_multi_qrcode_detector_package(string klass)
		{
			if (package_com_google_zxing_multi_qrcode_detector_mappings == null)
			{
				package_com_google_zxing_multi_qrcode_detector_mappings = new string[2] { "com/google/zxing/multi/qrcode/detector/MultiDetector:Google.ZXing.Multi.QRCode.Detector.MultiDetector", "com/google/zxing/multi/qrcode/detector/MultiFinderPatternFinder:Google.ZXing.Multi.QRCode.Detector.MultiFinderPatternFinder" };
			}
			return Lookup(package_com_google_zxing_multi_qrcode_detector_mappings, klass);
		}

		private static Type lookup_com_google_zxing_oned_package(string klass)
		{
			if (package_com_google_zxing_oned_mappings == null)
			{
				package_com_google_zxing_oned_mappings = new string[28]
				{
					"com/google/zxing/oned/CodaBarReader:Google.ZXing.OneD.CodaBarReader", "com/google/zxing/oned/CodaBarWriter:Google.ZXing.OneD.CodaBarWriter", "com/google/zxing/oned/Code128Reader:Google.ZXing.OneD.Code128Reader", "com/google/zxing/oned/Code128Writer:Google.ZXing.OneD.Code128Writer", "com/google/zxing/oned/Code39Reader:Google.ZXing.OneD.Code39Reader", "com/google/zxing/oned/Code39Writer:Google.ZXing.OneD.Code39Writer", "com/google/zxing/oned/Code93Reader:Google.ZXing.OneD.Code93Reader", "com/google/zxing/oned/Code93Writer:Google.ZXing.OneD.Code93Writer", "com/google/zxing/oned/EAN13Reader:Google.ZXing.OneD.EAN13Reader", "com/google/zxing/oned/EAN13Writer:Google.ZXing.OneD.EAN13Writer",
					"com/google/zxing/oned/EAN8Reader:Google.ZXing.OneD.EAN8Reader", "com/google/zxing/oned/EAN8Writer:Google.ZXing.OneD.EAN8Writer", "com/google/zxing/oned/EANManufacturerOrgSupport:Google.ZXing.OneD.EANManufacturerOrgSupport", "com/google/zxing/oned/ITFReader:Google.ZXing.OneD.ITFReader", "com/google/zxing/oned/ITFWriter:Google.ZXing.OneD.ITFWriter", "com/google/zxing/oned/MultiFormatOneDReader:Google.ZXing.OneD.MultiFormatOneDReader", "com/google/zxing/oned/MultiFormatUPCEANReader:Google.ZXing.OneD.MultiFormatUPCEANReader", "com/google/zxing/oned/OneDimensionalCodeWriter:Google.ZXing.OneD.OneDimensionalCodeWriter", "com/google/zxing/oned/OneDReader:Google.ZXing.OneD.OneDReader", "com/google/zxing/oned/UPCAReader:Google.ZXing.OneD.UPCAReader",
					"com/google/zxing/oned/UPCAWriter:Google.ZXing.OneD.UPCAWriter", "com/google/zxing/oned/UPCEANExtension2Support:Google.ZXing.OneD.UPCEANExtension2Support", "com/google/zxing/oned/UPCEANExtension5Support:Google.ZXing.OneD.UPCEANExtension5Support", "com/google/zxing/oned/UPCEANExtensionSupport:Google.ZXing.OneD.UPCEANExtensionSupport", "com/google/zxing/oned/UPCEANReader:Google.ZXing.OneD.UPCEANReader", "com/google/zxing/oned/UPCEANWriter:Google.ZXing.OneD.UPCEANWriter", "com/google/zxing/oned/UPCEReader:Google.ZXing.OneD.UPCEReader", "com/google/zxing/oned/UPCEWriter:Google.ZXing.OneD.UPCEWriter"
				};
			}
			return Lookup(package_com_google_zxing_oned_mappings, klass);
		}

		private static Type lookup_com_google_zxing_oned_rss_package(string klass)
		{
			if (package_com_google_zxing_oned_rss_mappings == null)
			{
				package_com_google_zxing_oned_rss_mappings = new string[6] { "com/google/zxing/oned/rss/AbstractRSSReader:Google.ZXing.OneD.RSS.AbstractRSSReader", "com/google/zxing/oned/rss/DataCharacter:Google.ZXing.OneD.RSS.DataCharacter", "com/google/zxing/oned/rss/FinderPattern:Google.ZXing.OneD.RSS.FinderPattern", "com/google/zxing/oned/rss/Pair:Google.ZXing.OneD.RSS.Pair", "com/google/zxing/oned/rss/RSS14Reader:Google.ZXing.OneD.RSS.RSS14Reader", "com/google/zxing/oned/rss/RSSUtils:Google.ZXing.OneD.RSS.RSSUtils" };
			}
			return Lookup(package_com_google_zxing_oned_rss_mappings, klass);
		}

		private static Type lookup_com_google_zxing_oned_rss_expanded_package(string klass)
		{
			if (package_com_google_zxing_oned_rss_expanded_mappings == null)
			{
				package_com_google_zxing_oned_rss_expanded_mappings = new string[4] { "com/google/zxing/oned/rss/expanded/BitArrayBuilder:Google.ZXing.OneD.RSS.Expanded.BitArrayBuilder", "com/google/zxing/oned/rss/expanded/ExpandedPair:Google.ZXing.OneD.RSS.Expanded.ExpandedPair", "com/google/zxing/oned/rss/expanded/ExpandedRow:Google.ZXing.OneD.RSS.Expanded.ExpandedRow", "com/google/zxing/oned/rss/expanded/RSSExpandedReader:Google.ZXing.OneD.RSS.Expanded.RSSExpandedReader" };
			}
			return Lookup(package_com_google_zxing_oned_rss_expanded_mappings, klass);
		}

		private static Type lookup_com_google_zxing_oned_rss_expanded_decoders_package(string klass)
		{
			if (package_com_google_zxing_oned_rss_expanded_decoders_mappings == null)
			{
				package_com_google_zxing_oned_rss_expanded_decoders_mappings = new string[19]
				{
					"com/google/zxing/oned/rss/expanded/decoders/AbstractExpandedDecoder:Google.ZXing.OneD.RSS.Expanded.Decoders.AbstractExpandedDecoder", "com/google/zxing/oned/rss/expanded/decoders/AI013103decoder:Google.ZXing.OneD.RSS.Expanded.Decoders.AI013103decoder", "com/google/zxing/oned/rss/expanded/decoders/AI01320xDecoder:Google.ZXing.OneD.RSS.Expanded.Decoders.AI01320xDecoder", "com/google/zxing/oned/rss/expanded/decoders/AI01392xDecoder:Google.ZXing.OneD.RSS.Expanded.Decoders.AI01392xDecoder", "com/google/zxing/oned/rss/expanded/decoders/AI01393xDecoder:Google.ZXing.OneD.RSS.Expanded.Decoders.AI01393xDecoder", "com/google/zxing/oned/rss/expanded/decoders/AI013x0x1xDecoder:Google.ZXing.OneD.RSS.Expanded.Decoders.AI013x0x1xDecoder", "com/google/zxing/oned/rss/expanded/decoders/AI013x0xDecoder:Google.ZXing.OneD.RSS.Expanded.Decoders.AI013x0xDecoder", "com/google/zxing/oned/rss/expanded/decoders/AI01AndOtherAIs:Google.ZXing.OneD.RSS.Expanded.Decoders.AI01AndOtherAIs", "com/google/zxing/oned/rss/expanded/decoders/AI01decoder:Google.ZXing.OneD.RSS.Expanded.Decoders.AI01decoder", "com/google/zxing/oned/rss/expanded/decoders/AI01weightDecoder:Google.ZXing.OneD.RSS.Expanded.Decoders.AI01weightDecoder",
					"com/google/zxing/oned/rss/expanded/decoders/AnyAIDecoder:Google.ZXing.OneD.RSS.Expanded.Decoders.AnyAIDecoder", "com/google/zxing/oned/rss/expanded/decoders/BlockParsedResult:Google.ZXing.OneD.RSS.Expanded.Decoders.BlockParsedResult", "com/google/zxing/oned/rss/expanded/decoders/CurrentParsingState:Google.ZXing.OneD.RSS.Expanded.Decoders.CurrentParsingState", "com/google/zxing/oned/rss/expanded/decoders/DecodedChar:Google.ZXing.OneD.RSS.Expanded.Decoders.DecodedChar", "com/google/zxing/oned/rss/expanded/decoders/DecodedInformation:Google.ZXing.OneD.RSS.Expanded.Decoders.DecodedInformation", "com/google/zxing/oned/rss/expanded/decoders/DecodedNumeric:Google.ZXing.OneD.RSS.Expanded.Decoders.DecodedNumeric", "com/google/zxing/oned/rss/expanded/decoders/DecodedObject:Google.ZXing.OneD.RSS.Expanded.Decoders.DecodedObject", "com/google/zxing/oned/rss/expanded/decoders/FieldParser:Google.ZXing.OneD.RSS.Expanded.Decoders.FieldParser", "com/google/zxing/oned/rss/expanded/decoders/GeneralAppIdDecoder:Google.ZXing.OneD.RSS.Expanded.Decoders.GeneralAppIdDecoder"
				};
			}
			return Lookup(package_com_google_zxing_oned_rss_expanded_decoders_mappings, klass);
		}

		private static Type lookup_com_google_zxing_pdf417_package(string klass)
		{
			if (package_com_google_zxing_pdf417_mappings == null)
			{
				package_com_google_zxing_pdf417_mappings = new string[4] { "com/google/zxing/pdf417/PDF417Common:Google.ZXing.PDF417.PDF417Common", "com/google/zxing/pdf417/PDF417Reader:Google.ZXing.PDF417.PDF417Reader", "com/google/zxing/pdf417/PDF417ResultMetadata:Google.ZXing.PDF417.PDF417ResultMetadata", "com/google/zxing/pdf417/PDF417Writer:Google.ZXing.PDF417.PDF417Writer" };
			}
			return Lookup(package_com_google_zxing_pdf417_mappings, klass);
		}

		private static Type lookup_com_google_zxing_pdf417_decoder_package(string klass)
		{
			if (package_com_google_zxing_pdf417_decoder_mappings == null)
			{
				package_com_google_zxing_pdf417_decoder_mappings = new string[10] { "com/google/zxing/pdf417/decoder/BarcodeMetadata:Google.ZXing.PDF417.Decoder.BarcodeMetadata", "com/google/zxing/pdf417/decoder/BarcodeValue:Google.ZXing.PDF417.Decoder.BarcodeValue", "com/google/zxing/pdf417/decoder/BoundingBox:Google.ZXing.PDF417.Decoder.BoundingBox", "com/google/zxing/pdf417/decoder/Codeword:Google.ZXing.PDF417.Decoder.Codeword", "com/google/zxing/pdf417/decoder/DecodedBitStreamParser:Google.ZXing.PDF417.Decoder.DecodedBitStreamParser", "com/google/zxing/pdf417/decoder/DetectionResult:Google.ZXing.PDF417.Decoder.DetectionResult", "com/google/zxing/pdf417/decoder/DetectionResultColumn:Google.ZXing.PDF417.Decoder.DetectionResultColumn", "com/google/zxing/pdf417/decoder/DetectionResultRowIndicatorColumn:Google.ZXing.PDF417.Decoder.DetectionResultRowIndicatorColumn", "com/google/zxing/pdf417/decoder/PDF417CodewordDecoder:Google.ZXing.PDF417.Decoder.PDF417CodewordDecoder", "com/google/zxing/pdf417/decoder/PDF417ScanningDecoder:Google.ZXing.PDF417.Decoder.PDF417ScanningDecoder" };
			}
			return Lookup(package_com_google_zxing_pdf417_decoder_mappings, klass);
		}

		private static Type lookup_com_google_zxing_pdf417_decoder_ec_package(string klass)
		{
			if (package_com_google_zxing_pdf417_decoder_ec_mappings == null)
			{
				package_com_google_zxing_pdf417_decoder_ec_mappings = new string[3] { "com/google/zxing/pdf417/decoder/ec/ErrorCorrection:Google.ZXing.PDF417.Decoder.EC.ErrorCorrection", "com/google/zxing/pdf417/decoder/ec/ModulusGF:Google.ZXing.PDF417.Decoder.EC.ModulusGF", "com/google/zxing/pdf417/decoder/ec/ModulusPoly:Google.ZXing.PDF417.Decoder.EC.ModulusPoly" };
			}
			return Lookup(package_com_google_zxing_pdf417_decoder_ec_mappings, klass);
		}

		private static Type lookup_com_google_zxing_pdf417_detector_package(string klass)
		{
			if (package_com_google_zxing_pdf417_detector_mappings == null)
			{
				package_com_google_zxing_pdf417_detector_mappings = new string[2] { "com/google/zxing/pdf417/detector/Detector:Google.ZXing.PDF417.Detector.Detector", "com/google/zxing/pdf417/detector/PDF417DetectorResult:Google.ZXing.PDF417.Detector.PDF417DetectorResult" };
			}
			return Lookup(package_com_google_zxing_pdf417_detector_mappings, klass);
		}

		private static Type lookup_com_google_zxing_pdf417_encoder_package(string klass)
		{
			if (package_com_google_zxing_pdf417_encoder_mappings == null)
			{
				package_com_google_zxing_pdf417_encoder_mappings = new string[7] { "com/google/zxing/pdf417/encoder/BarcodeMatrix:Google.ZXing.PDF417.Encoder.BarcodeMatrix", "com/google/zxing/pdf417/encoder/BarcodeRow:Google.ZXing.PDF417.Encoder.BarcodeRow", "com/google/zxing/pdf417/encoder/Compaction:Google.ZXing.PDF417.Encoder.Compaction", "com/google/zxing/pdf417/encoder/Dimensions:Google.ZXing.PDF417.Encoder.Dimensions", "com/google/zxing/pdf417/encoder/PDF417:Google.ZXing.PDF417.Encoder.PDF417", "com/google/zxing/pdf417/encoder/PDF417ErrorCorrection:Google.ZXing.PDF417.Encoder.PDF417ErrorCorrection", "com/google/zxing/pdf417/encoder/PDF417HighLevelEncoder:Google.ZXing.PDF417.Encoder.PDF417HighLevelEncoder" };
			}
			return Lookup(package_com_google_zxing_pdf417_encoder_mappings, klass);
		}

		private static Type lookup_com_google_zxing_qrcode_package(string klass)
		{
			if (package_com_google_zxing_qrcode_mappings == null)
			{
				package_com_google_zxing_qrcode_mappings = new string[2] { "com/google/zxing/qrcode/QRCodeReader:Google.ZXing.QRCode.QRCodeReader", "com/google/zxing/qrcode/QRCodeWriter:Google.ZXing.QRCode.QRCodeWriter" };
			}
			return Lookup(package_com_google_zxing_qrcode_mappings, klass);
		}

		private static Type lookup_com_google_zxing_qrcode_decoder_package(string klass)
		{
			if (package_com_google_zxing_qrcode_decoder_mappings == null)
			{
				package_com_google_zxing_qrcode_decoder_mappings = new string[12]
				{
					"com/google/zxing/qrcode/decoder/BitMatrixParser:Google.ZXing.QRCode.Decoder.BitMatrixParser", "com/google/zxing/qrcode/decoder/DataBlock:Google.ZXing.QRCode.Decoder.DataBlock", "com/google/zxing/qrcode/decoder/DataMask:Google.ZXing.QRCode.Decoder.DataMask", "com/google/zxing/qrcode/decoder/DecodedBitStreamParser:Google.ZXing.QRCode.Decoder.DecodedBitStreamParser", "com/google/zxing/qrcode/decoder/Decoder:Google.ZXing.QRCode.Decoder.Decoder", "com/google/zxing/qrcode/decoder/ErrorCorrectionLevel:Google.ZXing.QRCode.Decoder.ErrorCorrectionLevel", "com/google/zxing/qrcode/decoder/FormatInformation:Google.ZXing.QRCode.Decoder.FormatInformation", "com/google/zxing/qrcode/decoder/Mode:Google.ZXing.QRCode.Decoder.Mode", "com/google/zxing/qrcode/decoder/QRCodeDecoderMetaData:Google.ZXing.QRCode.Decoder.QRCodeDecoderMetaData", "com/google/zxing/qrcode/decoder/Version:Google.ZXing.QRCode.Decoder.Version",
					"com/google/zxing/qrcode/decoder/Version$ECB:Google.ZXing.QRCode.Decoder.Version/ECB", "com/google/zxing/qrcode/decoder/Version$ECBlocks:Google.ZXing.QRCode.Decoder.Version/ECBlocks"
				};
			}
			return Lookup(package_com_google_zxing_qrcode_decoder_mappings, klass);
		}

		private static Type lookup_com_google_zxing_qrcode_detector_package(string klass)
		{
			if (package_com_google_zxing_qrcode_detector_mappings == null)
			{
				package_com_google_zxing_qrcode_detector_mappings = new string[6] { "com/google/zxing/qrcode/detector/AlignmentPattern:Google.ZXing.QRCode.Detector.AlignmentPattern", "com/google/zxing/qrcode/detector/AlignmentPatternFinder:Google.ZXing.QRCode.Detector.AlignmentPatternFinder", "com/google/zxing/qrcode/detector/Detector:Google.ZXing.QRCode.Detector.Detector", "com/google/zxing/qrcode/detector/FinderPattern:Google.ZXing.QRCode.Detector.FinderPattern", "com/google/zxing/qrcode/detector/FinderPatternFinder:Google.ZXing.QRCode.Detector.FinderPatternFinder", "com/google/zxing/qrcode/detector/FinderPatternInfo:Google.ZXing.QRCode.Detector.FinderPatternInfo" };
			}
			return Lookup(package_com_google_zxing_qrcode_detector_mappings, klass);
		}

		private static Type lookup_com_google_zxing_qrcode_encoder_package(string klass)
		{
			if (package_com_google_zxing_qrcode_encoder_mappings == null)
			{
				package_com_google_zxing_qrcode_encoder_mappings = new string[6] { "com/google/zxing/qrcode/encoder/BlockPair:Google.ZXing.QRCode.Encoder.BlockPair", "com/google/zxing/qrcode/encoder/ByteMatrix:Google.ZXing.QRCode.Encoder.ByteMatrix", "com/google/zxing/qrcode/encoder/Encoder:Google.ZXing.QRCode.Encoder.Encoder", "com/google/zxing/qrcode/encoder/MaskUtil:Google.ZXing.QRCode.Encoder.MaskUtil", "com/google/zxing/qrcode/encoder/MatrixUtil:Google.ZXing.QRCode.Encoder.MatrixUtil", "com/google/zxing/qrcode/encoder/QRCode:Google.ZXing.QRCode.Encoder.QRCode" };
			}
			return Lookup(package_com_google_zxing_qrcode_encoder_mappings, klass);
		}
	}
}
namespace Google.ZXing
{
	[Register("com/google/zxing/BarcodeFormat", DoNotGenerateAcw = true)]
	public sealed class BarcodeFormat : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/BarcodeFormat", typeof(BarcodeFormat));

		[Register("AZTEC")]
		public static BarcodeFormat Aztec => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("AZTEC.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CODABAR")]
		public static BarcodeFormat Codabar => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("CODABAR.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CODE_128")]
		public static BarcodeFormat Code128 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("CODE_128.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CODE_39")]
		public static BarcodeFormat Code39 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("CODE_39.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CODE_93")]
		public static BarcodeFormat Code93 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("CODE_93.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DATA_MATRIX")]
		public static BarcodeFormat DataMatrix => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("DATA_MATRIX.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EAN_13")]
		public static BarcodeFormat Ean13 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("EAN_13.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EAN_8")]
		public static BarcodeFormat Ean8 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("EAN_8.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ITF")]
		public static BarcodeFormat Itf => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("ITF.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MAXICODE")]
		public static BarcodeFormat Maxicode => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("MAXICODE.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PDF_417")]
		public static BarcodeFormat Pdf417 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("PDF_417.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("QR_CODE")]
		public static BarcodeFormat QrCode => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("QR_CODE.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RSS_14")]
		public static BarcodeFormat Rss14 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("RSS_14.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RSS_EXPANDED")]
		public static BarcodeFormat RssExpanded => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("RSS_EXPANDED.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UPC_A")]
		public static BarcodeFormat UpcA => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("UPC_A.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UPC_E")]
		public static BarcodeFormat UpcE => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("UPC_E.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UPC_EAN_EXTENSION")]
		public static BarcodeFormat UpcEanExtension => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("UPC_EAN_EXTENSION.Lcom/google/zxing/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BarcodeFormat(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/BarcodeFormat;", "")]
		public unsafe static BarcodeFormat ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/BarcodeFormat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/BarcodeFormat;", "")]
		public unsafe static BarcodeFormat[] Values()
		{
			return (BarcodeFormat[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/BarcodeFormat;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(BarcodeFormat));
		}
	}
	[Register("com/google/zxing/Binarizer", DoNotGenerateAcw = true)]
	public abstract class Binarizer : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/Binarizer", typeof(Binarizer));

		private static Delegate cb_getBlackMatrix;

		private static Delegate cb_createBinarizer_Lcom_google_zxing_LuminanceSource_;

		private static Delegate cb_getBlackRow_ILcom_google_zxing_common_BitArray_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract BitMatrix BlackMatrix
		{
			[Register("getBlackMatrix", "()Lcom/google/zxing/common/BitMatrix;", "GetGetBlackMatrixHandler")]
			get;
		}

		public unsafe int Height
		{
			[Register("getHeight", "()I", "GetGetHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getHeight.()I", this, null);
			}
		}

		public unsafe LuminanceSource LuminanceSource
		{
			[Register("getLuminanceSource", "()Lcom/google/zxing/LuminanceSource;", "GetGetLuminanceSourceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LuminanceSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLuminanceSource.()Lcom/google/zxing/LuminanceSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int Width
		{
			[Register("getWidth", "()I", "GetGetWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getWidth.()I", this, null);
			}
		}

		protected Binarizer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/LuminanceSource;)V", "")]
		protected unsafe Binarizer(LuminanceSource source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/LuminanceSource;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/LuminanceSource;)V", this, ptr);
			}
		}

		private static Delegate GetGetBlackMatrixHandler()
		{
			if ((object)cb_getBlackMatrix == null)
			{
				cb_getBlackMatrix = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetBlackMatrix));
			}
			return cb_getBlackMatrix;
		}

		private static IntPtr n_GetBlackMatrix(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Binarizer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BlackMatrix);
		}

		private static Delegate GetCreateBinarizer_Lcom_google_zxing_LuminanceSource_Handler()
		{
			if ((object)cb_createBinarizer_Lcom_google_zxing_LuminanceSource_ == null)
			{
				cb_createBinarizer_Lcom_google_zxing_LuminanceSource_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_CreateBinarizer_Lcom_google_zxing_LuminanceSource_));
			}
			return cb_createBinarizer_Lcom_google_zxing_LuminanceSource_;
		}

		private static IntPtr n_CreateBinarizer_Lcom_google_zxing_LuminanceSource_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Binarizer binarizer = Java.Lang.Object.GetObject<Binarizer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LuminanceSource p = Java.Lang.Object.GetObject<LuminanceSource>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(binarizer.CreateBinarizer(p));
		}

		[Register("createBinarizer", "(Lcom/google/zxing/LuminanceSource;)Lcom/google/zxing/Binarizer;", "GetCreateBinarizer_Lcom_google_zxing_LuminanceSource_Handler")]
		public abstract Binarizer CreateBinarizer(LuminanceSource p0);

		private static Delegate GetGetBlackRow_ILcom_google_zxing_common_BitArray_Handler()
		{
			if ((object)cb_getBlackRow_ILcom_google_zxing_common_BitArray_ == null)
			{
				cb_getBlackRow_ILcom_google_zxing_common_BitArray_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr, IntPtr>(n_GetBlackRow_ILcom_google_zxing_common_BitArray_));
			}
			return cb_getBlackRow_ILcom_google_zxing_common_BitArray_;
		}

		private static IntPtr n_GetBlackRow_ILcom_google_zxing_common_BitArray_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
		{
			Binarizer binarizer = Java.Lang.Object.GetObject<Binarizer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BitArray p1 = Java.Lang.Object.GetObject<BitArray>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(binarizer.GetBlackRow(p0, p1));
		}

		[Register("getBlackRow", "(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", "GetGetBlackRow_ILcom_google_zxing_common_BitArray_Handler")]
		public abstract BitArray GetBlackRow(int p0, BitArray p1);
	}
	[Register("com/google/zxing/Binarizer", DoNotGenerateAcw = true)]
	internal class BinarizerInvoker : Binarizer
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/Binarizer", typeof(BinarizerInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override BitMatrix BlackMatrix
		{
			[Register("getBlackMatrix", "()Lcom/google/zxing/common/BitMatrix;", "GetGetBlackMatrixHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBlackMatrix.()Lcom/google/zxing/common/BitMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public BinarizerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("createBinarizer", "(Lcom/google/zxing/LuminanceSource;)Lcom/google/zxing/Binarizer;", "GetCreateBinarizer_Lcom_google_zxing_LuminanceSource_Handler")]
		public unsafe override Binarizer CreateBinarizer(LuminanceSource p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			Binarizer result = Java.Lang.Object.GetObject<Binarizer>(_members.InstanceMethods.InvokeAbstractObjectMethod("createBinarizer.(Lcom/google/zxing/LuminanceSource;)Lcom/google/zxing/Binarizer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(p0);
			return result;
		}

		[Register("getBlackRow", "(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", "GetGetBlackRow_ILcom_google_zxing_common_BitArray_Handler")]
		public unsafe override BitArray GetBlackRow(int p0, BitArray p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			BitArray result = Java.Lang.Object.GetObject<BitArray>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBlackRow.(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(p1);
			return result;
		}
	}
	[Register("com/google/zxing/BinaryBitmap", DoNotGenerateAcw = true)]
	public sealed class BinaryBitmap : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/BinaryBitmap", typeof(BinaryBitmap));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe BitMatrix BlackMatrix
		{
			[Register("getBlackMatrix", "()Lcom/google/zxing/common/BitMatrix;", "GetGetBlackMatrixHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBlackMatrix.()Lcom/google/zxing/common/BitMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int Height
		{
			[Register("getHeight", "()I", "GetGetHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getHeight.()I", this, null);
			}
		}

		public unsafe bool IsCropSupported
		{
			[Register("isCropSupported", "()Z", "GetIsCropSupportedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCropSupported.()Z", this, null);
			}
		}

		public unsafe bool IsRotateSupported
		{
			[Register("isRotateSupported", "()Z", "GetIsRotateSupportedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isRotateSupported.()Z", this, null);
			}
		}

		public unsafe int Width
		{
			[Register("getWidth", "()I", "GetGetWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getWidth.()I", this, null);
			}
		}

		internal BinaryBitmap(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/Binarizer;)V", "")]
		public unsafe BinaryBitmap(Binarizer binarizer)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(binarizer?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/Binarizer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/Binarizer;)V", this, ptr);
				GC.KeepAlive(binarizer);
			}
		}

		[Register("crop", "(IIII)Lcom/google/zxing/BinaryBitmap;", "")]
		public unsafe BinaryBitmap Crop(int left, int top, int width, int height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(width);
			ptr[3] = new JniArgumentValue(height);
			return Java.Lang.Object.GetObject<BinaryBitmap>(_members.InstanceMethods.InvokeAbstractObjectMethod("crop.(IIII)Lcom/google/zxing/BinaryBitmap;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getBlackRow", "(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", "")]
		public unsafe BitArray GetBlackRow(int y, BitArray row)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(y);
			ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			BitArray result = Java.Lang.Object.GetObject<BitArray>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBlackRow.(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(row);
			return result;
		}

		[Register("rotateCounterClockwise", "()Lcom/google/zxing/BinaryBitmap;", "")]
		public unsafe BinaryBitmap RotateCounterClockwise()
		{
			return Java.Lang.Object.GetObject<BinaryBitmap>(_members.InstanceMethods.InvokeAbstractObjectMethod("rotateCounterClockwise.()Lcom/google/zxing/BinaryBitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("rotateCounterClockwise45", "()Lcom/google/zxing/BinaryBitmap;", "")]
		public unsafe BinaryBitmap RotateCounterClockwise45()
		{
			return Java.Lang.Object.GetObject<BinaryBitmap>(_members.InstanceMethods.InvokeAbstractObjectMethod("rotateCounterClockwise45.()Lcom/google/zxing/BinaryBitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/ChecksumException", DoNotGenerateAcw = true)]
	public sealed class ChecksumException : ReaderException
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/ChecksumException", typeof(ChecksumException));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe static ChecksumException ChecksumInstance
		{
			[Register("getChecksumInstance", "()Lcom/google/zxing/ChecksumException;", "GetGetChecksumInstanceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ChecksumException>(_members.StaticMethods.InvokeObjectMethod("getChecksumInstance.()Lcom/google/zxing/ChecksumException;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ChecksumException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getChecksumInstance", "(Ljava/lang/Throwable;)Lcom/google/zxing/ChecksumException;", "")]
		public unsafe static ChecksumException GetChecksumInstance(Throwable cause)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ChecksumException>(_members.StaticMethods.InvokeObjectMethod("getChecksumInstance.(Ljava/lang/Throwable;)Lcom/google/zxing/ChecksumException;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/DecodeHintType", DoNotGenerateAcw = true)]
	public sealed class DecodeHintType : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/DecodeHintType", typeof(DecodeHintType));

		[Register("ALLOWED_EAN_EXTENSIONS")]
		public static DecodeHintType AllowedEanExtensions => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("ALLOWED_EAN_EXTENSIONS.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ALLOWED_LENGTHS")]
		public static DecodeHintType AllowedLengths => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("ALLOWED_LENGTHS.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ASSUME_CODE_39_CHECK_DIGIT")]
		public static DecodeHintType AssumeCode39CheckDigit => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("ASSUME_CODE_39_CHECK_DIGIT.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ASSUME_GS1")]
		public static DecodeHintType AssumeGs1 => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("ASSUME_GS1.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CHARACTER_SET")]
		public static DecodeHintType CharacterSet => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("CHARACTER_SET.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NEED_RESULT_POINT_CALLBACK")]
		public static DecodeHintType NeedResultPointCallback => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("NEED_RESULT_POINT_CALLBACK.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OTHER")]
		public static DecodeHintType Other => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("OTHER.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("POSSIBLE_FORMATS")]
		public static DecodeHintType PossibleFormats => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("POSSIBLE_FORMATS.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PURE_BARCODE")]
		public static DecodeHintType PureBarcode => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("PURE_BARCODE.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RETURN_CODABAR_START_END")]
		public static DecodeHintType ReturnCodabarStartEnd => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("RETURN_CODABAR_START_END.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TRY_HARDER")]
		public static DecodeHintType TryHarder => Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticFields.GetObjectValue("TRY_HARDER.Lcom/google/zxing/DecodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Class ValueType
		{
			[Register("getValueType", "()Ljava/lang/Class;", "GetGetValueTypeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Class>(_members.InstanceMethods.InvokeAbstractObjectMethod("getValueType.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal DecodeHintType(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/DecodeHintType;", "")]
		public unsafe static DecodeHintType ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<DecodeHintType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/DecodeHintType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/DecodeHintType;", "")]
		public unsafe static DecodeHintType[] Values()
		{
			return (DecodeHintType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/DecodeHintType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(DecodeHintType));
		}
	}
	[Register("com/google/zxing/Dimension", DoNotGenerateAcw = true)]
	public sealed class Dimension : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/Dimension", typeof(Dimension));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Height
		{
			[Register("getHeight", "()I", "GetGetHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getHeight.()I", this, null);
			}
		}

		public unsafe int Width
		{
			[Register("getWidth", "()I", "GetGetWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getWidth.()I", this, null);
			}
		}

		internal Dimension(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe Dimension(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}
	}
	[Register("com/google/zxing/EncodeHintType", DoNotGenerateAcw = true)]
	public sealed class EncodeHintType : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/EncodeHintType", typeof(EncodeHintType));

		[Register("AZTEC_LAYERS")]
		public static EncodeHintType AztecLayers => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("AZTEC_LAYERS.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CHARACTER_SET")]
		public static EncodeHintType CharacterSet => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("CHARACTER_SET.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DATA_MATRIX_SHAPE")]
		public static EncodeHintType DataMatrixShape => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("DATA_MATRIX_SHAPE.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ERROR_CORRECTION")]
		public static EncodeHintType ErrorCorrection => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("ERROR_CORRECTION.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GS1_FORMAT")]
		public static EncodeHintType Gs1Format => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("GS1_FORMAT.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MARGIN")]
		public static EncodeHintType Margin => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("MARGIN.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MAX_SIZE")]
		public static EncodeHintType MaxSize => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("MAX_SIZE.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MIN_SIZE")]
		public static EncodeHintType MinSize => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("MIN_SIZE.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PDF417_COMPACT")]
		public static EncodeHintType Pdf417Compact => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("PDF417_COMPACT.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PDF417_COMPACTION")]
		public static EncodeHintType Pdf417Compaction => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("PDF417_COMPACTION.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PDF417_DIMENSIONS")]
		public static EncodeHintType Pdf417Dimensions => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("PDF417_DIMENSIONS.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("QR_VERSION")]
		public static EncodeHintType QrVersion => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("QR_VERSION.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal EncodeHintType(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/EncodeHintType;", "")]
		public unsafe static EncodeHintType ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/EncodeHintType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/EncodeHintType;", "")]
		public unsafe static EncodeHintType[] Values()
		{
			return (EncodeHintType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/EncodeHintType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(EncodeHintType));
		}
	}
	[Register("com/google/zxing/FormatException", DoNotGenerateAcw = true)]
	public sealed class FormatException : ReaderException
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/FormatException", typeof(FormatException));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe static FormatException FormatInstance
		{
			[Register("getFormatInstance", "()Lcom/google/zxing/FormatException;", "GetGetFormatInstanceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<FormatException>(_members.StaticMethods.InvokeObjectMethod("getFormatInstance.()Lcom/google/zxing/FormatException;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal FormatException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getFormatInstance", "(Ljava/lang/Throwable;)Lcom/google/zxing/FormatException;", "")]
		public unsafe static FormatException GetFormatInstance(Throwable cause)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FormatException>(_members.StaticMethods.InvokeObjectMethod("getFormatInstance.(Ljava/lang/Throwable;)Lcom/google/zxing/FormatException;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/InvertedLuminanceSource", DoNotGenerateAcw = true)]
	public sealed class InvertedLuminanceSource : LuminanceSource
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/InvertedLuminanceSource", typeof(InvertedLuminanceSource));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal InvertedLuminanceSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/LuminanceSource;)V", "")]
		public unsafe InvertedLuminanceSource(LuminanceSource @delegate)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@delegate?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/LuminanceSource;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/LuminanceSource;)V", this, ptr);
				GC.KeepAlive(@delegate);
			}
		}

		[Register("getMatrix", "()[B", "")]
		public unsafe override byte[] GetMatrix()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getMatrix.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("getRow", "(I[B)[B", "")]
		public unsafe override byte[] GetRow(int y, byte[] row)
		{
			IntPtr intPtr = JNIEnv.NewArray(row);
			byte[] result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(y);
				ptr[1] = new JniArgumentValue(intPtr);
				result = (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getRow.(I[B)[B", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
			}
			finally
			{
				if (row != null)
				{
					JNIEnv.CopyArray(intPtr, row);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(row);
			return result;
		}
	}
	[Register("com/google/zxing/Reader", "", "Google.ZXing.IReaderInvoker")]
	public interface IReader : IJavaObject, IDisposable
	{
		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", "GetDecode_Lcom_google_zxing_BinaryBitmap_Handler:Google.ZXing.IReaderInvoker, Google.ZXing.Core")]
		Result Decode(BinaryBitmap p0);

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", "GetDecode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_Handler:Google.ZXing.IReaderInvoker, Google.ZXing.Core")]
		Result Decode(BinaryBitmap p0, IDictionary<DecodeHintType, object> p1);

		[Register("reset", "()V", "GetResetHandler:Google.ZXing.IReaderInvoker, Google.ZXing.Core")]
		void Reset();
	}
	[Register("com/google/zxing/Reader", DoNotGenerateAcw = true)]
	internal class IReaderInvoker : Java.Lang.Object, IReader, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/Reader", typeof(IReaderInvoker));

		private IntPtr class_ref;

		private static Delegate cb_decode_Lcom_google_zxing_BinaryBitmap_;

		private IntPtr id_decode_Lcom_google_zxing_BinaryBitmap_;

		private static Delegate cb_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_;

		private IntPtr id_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_;

		private static Delegate cb_reset;

		private IntPtr id_reset;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IReader GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IReader>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.zxing.Reader"));
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IReaderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDecode_Lcom_google_zxing_BinaryBitmap_Handler()
		{
			if ((object)cb_decode_Lcom_google_zxing_BinaryBitmap_ == null)
			{
				cb_decode_Lcom_google_zxing_BinaryBitmap_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_Decode_Lcom_google_zxing_BinaryBitmap_));
			}
			return cb_decode_Lcom_google_zxing_BinaryBitmap_;
		}

		private static IntPtr n_Decode_Lcom_google_zxing_BinaryBitmap_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IReader reader = Java.Lang.Object.GetObject<IReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BinaryBitmap p = Java.Lang.Object.GetObject<BinaryBitmap>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(reader.Decode(p));
		}

		public unsafe Result Decode(BinaryBitmap p0)
		{
			if (id_decode_Lcom_google_zxing_BinaryBitmap_ == IntPtr.Zero)
			{
				id_decode_Lcom_google_zxing_BinaryBitmap_ = JNIEnv.GetMethodID(class_ref, "decode", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Result>(JNIEnv.CallObjectMethod(base.Handle, id_decode_Lcom_google_zxing_BinaryBitmap_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetDecode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_Handler()
		{
			if ((object)cb_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_ == null)
			{
				cb_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_Decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_));
			}
			return cb_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_;
		}

		private static IntPtr n_Decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IReader reader = Java.Lang.Object.GetObject<IReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BinaryBitmap p = Java.Lang.Object.GetObject<BinaryBitmap>(native_p0, JniHandleOwnership.DoNotTransfer);
			IDictionary<DecodeHintType, object> p2 = JavaDictionary<DecodeHintType, object>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(reader.Decode(p, p2));
		}

		public unsafe Result Decode(BinaryBitmap p0, IDictionary<DecodeHintType, object> p1)
		{
			if (id_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_ == IntPtr.Zero)
			{
				id_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_ = JNIEnv.GetMethodID(class_ref, "decode", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;");
			}
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			Result result = Java.Lang.Object.GetObject<Result>(JNIEnv.CallObjectMethod(base.Handle, id_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetResetHandler()
		{
			if ((object)cb_reset == null)
			{
				cb_reset = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Reset));
			}
			return cb_reset;
		}

		private static void n_Reset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}

		public void Reset()
		{
			if (id_reset == IntPtr.Zero)
			{
				id_reset = JNIEnv.GetMethodID(class_ref, "reset", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_reset);
		}
	}
	[Register("com/google/zxing/ResultPointCallback", "", "Google.ZXing.IResultPointCallbackInvoker")]
	public interface IResultPointCallback : IJavaObject, IDisposable
	{
		[Register("foundPossibleResultPoint", "(Lcom/google/zxing/ResultPoint;)V", "GetFoundPossibleResultPoint_Lcom_google_zxing_ResultPoint_Handler:Google.ZXing.IResultPointCallbackInvoker, Google.ZXing.Core")]
		void FoundPossibleResultPoint(ResultPoint p0);
	}
	[Register("com/google/zxing/ResultPointCallback", DoNotGenerateAcw = true)]
	internal class IResultPointCallbackInvoker : Java.Lang.Object, IResultPointCallback, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/ResultPointCallback", typeof(IResultPointCallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_foundPossibleResultPoint_Lcom_google_zxing_ResultPoint_;

		private IntPtr id_foundPossibleResultPoint_Lcom_google_zxing_ResultPoint_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IResultPointCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IResultPointCallback>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.zxing.ResultPointCallback"));
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IResultPointCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetFoundPossibleResultPoint_Lcom_google_zxing_ResultPoint_Handler()
		{
			if ((object)cb_foundPossibleResultPoint_Lcom_google_zxing_ResultPoint_ == null)
			{
				cb_foundPossibleResultPoint_Lcom_google_zxing_ResultPoint_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_FoundPossibleResultPoint_Lcom_google_zxing_ResultPoint_));
			}
			return cb_foundPossibleResultPoint_Lcom_google_zxing_ResultPoint_;
		}

		private static void n_FoundPossibleResultPoint_Lcom_google_zxing_ResultPoint_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IResultPointCallback resultPointCallback = Java.Lang.Object.GetObject<IResultPointCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ResultPoint p = Java.Lang.Object.GetObject<ResultPoint>(native_p0, JniHandleOwnership.DoNotTransfer);
			resultPointCallback.FoundPossibleResultPoint(p);
		}

		public unsafe void FoundPossibleResultPoint(ResultPoint p0)
		{
			if (id_foundPossibleResultPoint_Lcom_google_zxing_ResultPoint_ == IntPtr.Zero)
			{
				id_foundPossibleResultPoint_Lcom_google_zxing_ResultPoint_ = JNIEnv.GetMethodID(class_ref, "foundPossibleResultPoint", "(Lcom/google/zxing/ResultPoint;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_foundPossibleResultPoint_Lcom_google_zxing_ResultPoint_, ptr);
		}
	}
	[Register("com/google/zxing/Writer", "", "Google.ZXing.IWriterInvoker")]
	public interface IWriter : IJavaObject, IDisposable
	{
		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", "GetEncode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IIHandler:Google.ZXing.IWriterInvoker, Google.ZXing.Core")]
		BitMatrix Encode(string p0, BarcodeFormat p1, int p2, int p3);

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", "GetEncode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_Handler:Google.ZXing.IWriterInvoker, Google.ZXing.Core")]
		BitMatrix Encode(string p0, BarcodeFormat p1, int p2, int p3, IDictionary<EncodeHintType, object> p4);
	}
	[Register("com/google/zxing/Writer", DoNotGenerateAcw = true)]
	internal class IWriterInvoker : Java.Lang.Object, IWriter, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/Writer", typeof(IWriterInvoker));

		private IntPtr class_ref;

		private static Delegate cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_II;

		private IntPtr id_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_II;

		private static Delegate cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_;

		private IntPtr id_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IWriter GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IWriter>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.zxing.Writer"));
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IWriterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetEncode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IIHandler()
		{
			if ((object)cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_II == null)
			{
				cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_II = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, int, int, IntPtr>(n_Encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_II));
			}
			return cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_II;
		}

		private static IntPtr n_Encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_II(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2, int p3)
		{
			IWriter writer = Java.Lang.Object.GetObject<IWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			BarcodeFormat p5 = Java.Lang.Object.GetObject<BarcodeFormat>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(writer.Encode(p4, p5, p2, p3));
		}

		public unsafe BitMatrix Encode(string p0, BarcodeFormat p1, int p2, int p3)
		{
			if (id_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_II == IntPtr.Zero)
			{
				id_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_II = JNIEnv.GetMethodID(class_ref, "encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(p2);
			ptr[3] = new JValue(p3);
			BitMatrix result = Java.Lang.Object.GetObject<BitMatrix>(JNIEnv.CallObjectMethod(base.Handle, id_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_II, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetEncode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_Handler()
		{
			if ((object)cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_ == null)
			{
				cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, int, int, IntPtr, IntPtr>(n_Encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_));
			}
			return cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_;
		}

		private static IntPtr n_Encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2, int p3, IntPtr native_p4)
		{
			IWriter writer = Java.Lang.Object.GetObject<IWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			BarcodeFormat p5 = Java.Lang.Object.GetObject<BarcodeFormat>(native_p1, JniHandleOwnership.DoNotTransfer);
			IDictionary<EncodeHintType, object> p6 = JavaDictionary<EncodeHintType, object>.FromJniHandle(native_p4, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(writer.Encode(p4, p5, p2, p3, p6));
		}

		public unsafe BitMatrix Encode(string p0, BarcodeFormat p1, int p2, int p3, IDictionary<EncodeHintType, object> p4)
		{
			if (id_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_ == IntPtr.Zero)
			{
				id_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_ = JNIEnv.GetMethodID(class_ref, "encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JavaDictionary<EncodeHintType, object>.ToLocalJniHandle(p4);
			JValue* ptr = stackalloc JValue[5];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(p2);
			ptr[3] = new JValue(p3);
			ptr[4] = new JValue(intPtr2);
			BitMatrix result = Java.Lang.Object.GetObject<BitMatrix>(JNIEnv.CallObjectMethod(base.Handle, id_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			return result;
		}
	}
	[Register("com/google/zxing/LuminanceSource", DoNotGenerateAcw = true)]
	public abstract class LuminanceSource : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/LuminanceSource", typeof(LuminanceSource));

		private static Delegate cb_isCropSupported;

		private static Delegate cb_isRotateSupported;

		private static Delegate cb_crop_IIII;

		private static Delegate cb_getMatrix;

		private static Delegate cb_getRow_IarrayB;

		private static Delegate cb_invert;

		private static Delegate cb_rotateCounterClockwise;

		private static Delegate cb_rotateCounterClockwise45;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Height
		{
			[Register("getHeight", "()I", "GetGetHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getHeight.()I", this, null);
			}
		}

		public unsafe virtual bool IsCropSupported
		{
			[Register("isCropSupported", "()Z", "GetIsCropSupportedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCropSupported.()Z", this, null);
			}
		}

		public unsafe virtual bool IsRotateSupported
		{
			[Register("isRotateSupported", "()Z", "GetIsRotateSupportedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRotateSupported.()Z", this, null);
			}
		}

		public unsafe int Width
		{
			[Register("getWidth", "()I", "GetGetWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getWidth.()I", this, null);
			}
		}

		protected LuminanceSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(II)V", "")]
		protected unsafe LuminanceSource(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}

		private static Delegate GetIsCropSupportedHandler()
		{
			if ((object)cb_isCropSupported == null)
			{
				cb_isCropSupported = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsCropSupported));
			}
			return cb_isCropSupported;
		}

		private static bool n_IsCropSupported(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LuminanceSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCropSupported;
		}

		private static Delegate GetIsRotateSupportedHandler()
		{
			if ((object)cb_isRotateSupported == null)
			{
				cb_isRotateSupported = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsRotateSupported));
			}
			return cb_isRotateSupported;
		}

		private static bool n_IsRotateSupported(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LuminanceSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRotateSupported;
		}

		private static Delegate GetCrop_IIIIHandler()
		{
			if ((object)cb_crop_IIII == null)
			{
				cb_crop_IIII = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, int, int, int, IntPtr>(n_Crop_IIII));
			}
			return cb_crop_IIII;
		}

		private static IntPtr n_Crop_IIII(IntPtr jnienv, IntPtr native__this, int left, int top, int width, int height)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LuminanceSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Crop(left, top, width, height));
		}

		[Register("crop", "(IIII)Lcom/google/zxing/LuminanceSource;", "GetCrop_IIIIHandler")]
		public unsafe virtual LuminanceSource Crop(int left, int top, int width, int height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(width);
			ptr[3] = new JniArgumentValue(height);
			return Java.Lang.Object.GetObject<LuminanceSource>(_members.InstanceMethods.InvokeVirtualObjectMethod("crop.(IIII)Lcom/google/zxing/LuminanceSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetMatrixHandler()
		{
			if ((object)cb_getMatrix == null)
			{
				cb_getMatrix = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetMatrix));
			}
			return cb_getMatrix;
		}

		private static IntPtr n_GetMatrix(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<LuminanceSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetMatrix());
		}

		[Register("getMatrix", "()[B", "GetGetMatrixHandler")]
		public abstract byte[] GetMatrix();

		private static Delegate GetGetRow_IarrayBHandler()
		{
			if ((object)cb_getRow_IarrayB == null)
			{
				cb_getRow_IarrayB = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr, IntPtr>(n_GetRow_IarrayB));
			}
			return cb_getRow_IarrayB;
		}

		private static IntPtr n_GetRow_IarrayB(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
		{
			LuminanceSource luminanceSource = Java.Lang.Object.GetObject<LuminanceSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(byte));
			IntPtr result = JNIEnv.NewArray(luminanceSource.GetRow(p0, array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
			return result;
		}

		[Register("getRow", "(I[B)[B", "GetGetRow_IarrayBHandler")]
		public abstract byte[] GetRow(int p0, byte[] p1);

		private static Delegate GetInvertHandler()
		{
			if ((object)cb_invert == null)
			{
				cb_invert = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_Invert));
			}
			return cb_invert;
		}

		private static IntPtr n_Invert(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LuminanceSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Invert());
		}

		[Register("invert", "()Lcom/google/zxing/LuminanceSource;", "GetInvertHandler")]
		public unsafe virtual LuminanceSource Invert()
		{
			return Java.Lang.Object.GetObject<LuminanceSource>(_members.InstanceMethods.InvokeVirtualObjectMethod("invert.()Lcom/google/zxing/LuminanceSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRotateCounterClockwiseHandler()
		{
			if ((object)cb_rotateCounterClockwise == null)
			{
				cb_rotateCounterClockwise = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_RotateCounterClockwise));
			}
			return cb_rotateCounterClockwise;
		}

		private static IntPtr n_RotateCounterClockwise(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LuminanceSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotateCounterClockwise());
		}

		[Register("rotateCounterClockwise", "()Lcom/google/zxing/LuminanceSource;", "GetRotateCounterClockwiseHandler")]
		public unsafe virtual LuminanceSource RotateCounterClockwise()
		{
			return Java.Lang.Object.GetObject<LuminanceSource>(_members.InstanceMethods.InvokeVirtualObjectMethod("rotateCounterClockwise.()Lcom/google/zxing/LuminanceSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRotateCounterClockwise45Handler()
		{
			if ((object)cb_rotateCounterClockwise45 == null)
			{
				cb_rotateCounterClockwise45 = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_RotateCounterClockwise45));
			}
			return cb_rotateCounterClockwise45;
		}

		private static IntPtr n_RotateCounterClockwise45(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LuminanceSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotateCounterClockwise45());
		}

		[Register("rotateCounterClockwise45", "()Lcom/google/zxing/LuminanceSource;", "GetRotateCounterClockwise45Handler")]
		public unsafe virtual LuminanceSource RotateCounterClockwise45()
		{
			return Java.Lang.Object.GetObject<LuminanceSource>(_members.InstanceMethods.InvokeVirtualObjectMethod("rotateCounterClockwise45.()Lcom/google/zxing/LuminanceSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("toString", "()Ljava/lang/String;", "")]
		public unsafe sealed override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/LuminanceSource", DoNotGenerateAcw = true)]
	internal class LuminanceSourceInvoker : LuminanceSource
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/LuminanceSource", typeof(LuminanceSourceInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public LuminanceSourceInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getMatrix", "()[B", "GetGetMatrixHandler")]
		public unsafe override byte[] GetMatrix()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getMatrix.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("getRow", "(I[B)[B", "GetGetRow_IarrayBHandler")]
		public unsafe override byte[] GetRow(int p0, byte[] p1)
		{
			IntPtr intPtr = JNIEnv.NewArray(p1);
			byte[] result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(intPtr);
				result = (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getRow.(I[B)[B", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
			}
			finally
			{
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr, p1);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(p1);
			return result;
		}
	}
	[Register("com/google/zxing/MultiFormatReader", DoNotGenerateAcw = true)]
	public sealed class MultiFormatReader : Java.Lang.Object, IReader, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/MultiFormatReader", typeof(MultiFormatReader));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MultiFormatReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe MultiFormatReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(image);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}

		[Register("decodeWithState", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", "")]
		public unsafe Result DecodeWithState(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeWithState.(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(image);
			return result;
		}

		[Register("reset", "()V", "")]
		public unsafe void Reset()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("reset.()V", this, null);
		}

		[Register("setHints", "(Ljava/util/Map;)V", "")]
		public unsafe void SetHints(IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setHints.(Ljava/util/Map;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(hints);
			}
		}
	}
	[Register("com/google/zxing/MultiFormatWriter", DoNotGenerateAcw = true)]
	public sealed class MultiFormatWriter : Java.Lang.Object, IWriter, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/MultiFormatWriter", typeof(MultiFormatWriter));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MultiFormatWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe MultiFormatWriter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(format);
			return result;
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			IntPtr intPtr2 = JavaDictionary<EncodeHintType, object>.ToLocalJniHandle(hints);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				ptr[4] = new JniArgumentValue(intPtr2);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(format);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/NotFoundException", DoNotGenerateAcw = true)]
	public sealed class NotFoundException : ReaderException
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/NotFoundException", typeof(NotFoundException));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe static NotFoundException NotFoundInstance
		{
			[Register("getNotFoundInstance", "()Lcom/google/zxing/NotFoundException;", "GetGetNotFoundInstanceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<NotFoundException>(_members.StaticMethods.InvokeObjectMethod("getNotFoundInstance.()Lcom/google/zxing/NotFoundException;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal NotFoundException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/PlanarYUVLuminanceSource", DoNotGenerateAcw = true)]
	public sealed class PlanarYUVLuminanceSource : LuminanceSource
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/PlanarYUVLuminanceSource", typeof(PlanarYUVLuminanceSource));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int ThumbnailHeight
		{
			[Register("getThumbnailHeight", "()I", "GetGetThumbnailHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getThumbnailHeight.()I", this, null);
			}
		}

		public unsafe int ThumbnailWidth
		{
			[Register("getThumbnailWidth", "()I", "GetGetThumbnailWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getThumbnailWidth.()I", this, null);
			}
		}

		internal PlanarYUVLuminanceSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "([BIIIIIIZ)V", "")]
		public unsafe PlanarYUVLuminanceSource(byte[] yuvData, int dataWidth, int dataHeight, int left, int top, int width, int height, bool reverseHorizontal)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(yuvData);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(dataWidth);
				ptr[2] = new JniArgumentValue(dataHeight);
				ptr[3] = new JniArgumentValue(left);
				ptr[4] = new JniArgumentValue(top);
				ptr[5] = new JniArgumentValue(width);
				ptr[6] = new JniArgumentValue(height);
				ptr[7] = new JniArgumentValue(reverseHorizontal);
				SetHandle(_members.InstanceMethods.StartCreateInstance("([BIIIIIIZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("([BIIIIIIZ)V", this, ptr);
			}
			finally
			{
				if (yuvData != null)
				{
					JNIEnv.CopyArray(intPtr, yuvData);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(yuvData);
				}
			}
		}

		[Register("getMatrix", "()[B", "")]
		public unsafe override byte[] GetMatrix()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getMatrix.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("getRow", "(I[B)[B", "")]
		public unsafe override byte[] GetRow(int y, byte[] row)
		{
			IntPtr intPtr = JNIEnv.NewArray(row);
			byte[] result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(y);
				ptr[1] = new JniArgumentValue(intPtr);
				result = (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getRow.(I[B)[B", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
			}
			finally
			{
				if (row != null)
				{
					JNIEnv.CopyArray(intPtr, row);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(row);
			return result;
		}

		[Register("renderThumbnail", "()[I", "")]
		public unsafe int[] RenderThumbnail()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("renderThumbnail.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}
	}
	[Register("com/google/zxing/ReaderException", DoNotGenerateAcw = true)]
	public abstract class ReaderException : Java.Lang.Exception
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/ReaderException", typeof(ReaderException));

		[Register("NO_TRACE")]
		protected static IList<StackTraceElement> NoTrace => Android.Runtime.JavaArray<StackTraceElement>.FromJniHandle(_members.StaticFields.GetObjectValue("NO_TRACE.[Ljava/lang/StackTraceElement;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("isStackTrace")]
		protected static bool IsStackTrace => _members.StaticFields.GetBooleanValue("isStackTrace.Z");

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ReaderException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("fillInStackTrace", "()Ljava/lang/Throwable;", "")]
		public unsafe sealed override Throwable FillInStackTrace()
		{
			return Java.Lang.Object.GetObject<Throwable>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("fillInStackTrace.()Ljava/lang/Throwable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/ReaderException", DoNotGenerateAcw = true)]
	internal class ReaderExceptionInvoker : ReaderException
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/ReaderException", typeof(ReaderExceptionInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public ReaderExceptionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/zxing/Result", DoNotGenerateAcw = true)]
	public sealed class Result : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/Result", typeof(Result));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe BarcodeFormat BarcodeFormat
		{
			[Register("getBarcodeFormat", "()Lcom/google/zxing/BarcodeFormat;", "GetGetBarcodeFormatHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BarcodeFormat>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBarcodeFormat.()Lcom/google/zxing/BarcodeFormat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int NumBits
		{
			[Register("getNumBits", "()I", "GetGetNumBitsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getNumBits.()I", this, null);
			}
		}

		public unsafe IDictionary<ResultMetadataType, Java.Lang.Object> ResultMetadata
		{
			[Register("getResultMetadata", "()Ljava/util/Map;", "GetGetResultMetadataHandler")]
			get
			{
				return JavaDictionary<ResultMetadataType, Java.Lang.Object>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getResultMetadata.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Text
		{
			[Register("getText", "()Ljava/lang/String;", "GetGetTextHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe long Timestamp
		{
			[Register("getTimestamp", "()J", "GetGetTimestampHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getTimestamp.()J", this, null);
			}
		}

		internal Result(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;[B[Lcom/google/zxing/ResultPoint;Lcom/google/zxing/BarcodeFormat;)V", "")]
		public unsafe Result(string text, byte[] rawBytes, ResultPoint[] resultPoints, BarcodeFormat format)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(text);
			IntPtr intPtr2 = JNIEnv.NewArray(rawBytes);
			IntPtr intPtr3 = JNIEnv.NewArray(resultPoints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;[B[Lcom/google/zxing/ResultPoint;Lcom/google/zxing/BarcodeFormat;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;[B[Lcom/google/zxing/ResultPoint;Lcom/google/zxing/BarcodeFormat;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (rawBytes != null)
				{
					JNIEnv.CopyArray(intPtr2, rawBytes);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				if (resultPoints != null)
				{
					JNIEnv.CopyArray(intPtr3, resultPoints);
					JNIEnv.DeleteLocalRef(intPtr3);
					GC.KeepAlive(rawBytes);
					GC.KeepAlive(resultPoints);
					GC.KeepAlive(format);
				}
			}
		}

		[Register(".ctor", "(Ljava/lang/String;[B[Lcom/google/zxing/ResultPoint;Lcom/google/zxing/BarcodeFormat;J)V", "")]
		public unsafe Result(string text, byte[] rawBytes, ResultPoint[] resultPoints, BarcodeFormat format, long timestamp)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(text);
			IntPtr intPtr2 = JNIEnv.NewArray(rawBytes);
			IntPtr intPtr3 = JNIEnv.NewArray(resultPoints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(timestamp);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;[B[Lcom/google/zxing/ResultPoint;Lcom/google/zxing/BarcodeFormat;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;[B[Lcom/google/zxing/ResultPoint;Lcom/google/zxing/BarcodeFormat;J)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (rawBytes != null)
				{
					JNIEnv.CopyArray(intPtr2, rawBytes);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				if (resultPoints != null)
				{
					JNIEnv.CopyArray(intPtr3, resultPoints);
					JNIEnv.DeleteLocalRef(intPtr3);
					GC.KeepAlive(rawBytes);
					GC.KeepAlive(resultPoints);
					GC.KeepAlive(format);
				}
			}
		}

		[Register(".ctor", "(Ljava/lang/String;[BI[Lcom/google/zxing/ResultPoint;Lcom/google/zxing/BarcodeFormat;J)V", "")]
		public unsafe Result(string text, byte[] rawBytes, int numBits, ResultPoint[] resultPoints, BarcodeFormat format, long timestamp)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(text);
			IntPtr intPtr2 = JNIEnv.NewArray(rawBytes);
			IntPtr intPtr3 = JNIEnv.NewArray(resultPoints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(numBits);
				ptr[3] = new JniArgumentValue(intPtr3);
				ptr[4] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue(timestamp);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;[BI[Lcom/google/zxing/ResultPoint;Lcom/google/zxing/BarcodeFormat;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;[BI[Lcom/google/zxing/ResultPoint;Lcom/google/zxing/BarcodeFormat;J)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (rawBytes != null)
				{
					JNIEnv.CopyArray(intPtr2, rawBytes);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				if (resultPoints != null)
				{
					JNIEnv.CopyArray(intPtr3, resultPoints);
					JNIEnv.DeleteLocalRef(intPtr3);
					GC.KeepAlive(rawBytes);
					GC.KeepAlive(resultPoints);
					GC.KeepAlive(format);
				}
			}
		}

		[Register("addResultPoints", "([Lcom/google/zxing/ResultPoint;)V", "")]
		public unsafe void AddResultPoints(ResultPoint[] newPoints)
		{
			IntPtr intPtr = JNIEnv.NewArray(newPoints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addResultPoints.([Lcom/google/zxing/ResultPoint;)V", this, ptr);
			}
			finally
			{
				if (newPoints != null)
				{
					JNIEnv.CopyArray(intPtr, newPoints);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(newPoints);
				}
			}
		}

		[Register("getRawBytes", "()[B", "")]
		public unsafe byte[] GetRawBytes()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getRawBytes.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("getResultPoints", "()[Lcom/google/zxing/ResultPoint;", "")]
		public unsafe ResultPoint[] GetResultPoints()
		{
			return (ResultPoint[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getResultPoints.()[Lcom/google/zxing/ResultPoint;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ResultPoint));
		}

		[Register("putAllMetadata", "(Ljava/util/Map;)V", "")]
		public unsafe void PutAllMetadata(IDictionary<ResultMetadataType, Java.Lang.Object> metadata)
		{
			IntPtr intPtr = JavaDictionary<ResultMetadataType, Java.Lang.Object>.ToLocalJniHandle(metadata);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("putAllMetadata.(Ljava/util/Map;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(metadata);
			}
		}

		[Register("putMetadata", "(Lcom/google/zxing/ResultMetadataType;Ljava/lang/Object;)V", "")]
		public unsafe void PutMetadata(ResultMetadataType type, Java.Lang.Object value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("putMetadata.(Lcom/google/zxing/ResultMetadataType;Ljava/lang/Object;)V", this, ptr);
			GC.KeepAlive(type);
			GC.KeepAlive(value);
		}
	}
	[Register("com/google/zxing/ResultMetadataType", DoNotGenerateAcw = true)]
	public sealed class ResultMetadataType : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/ResultMetadataType", typeof(ResultMetadataType));

		[Register("BYTE_SEGMENTS")]
		public static ResultMetadataType ByteSegments => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("BYTE_SEGMENTS.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ERROR_CORRECTION_LEVEL")]
		public static ResultMetadataType ErrorCorrectionLevel => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("ERROR_CORRECTION_LEVEL.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISSUE_NUMBER")]
		public static ResultMetadataType IssueNumber => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("ISSUE_NUMBER.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ORIENTATION")]
		public static ResultMetadataType Orientation => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("ORIENTATION.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OTHER")]
		public static ResultMetadataType Other => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("OTHER.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PDF417_EXTRA_METADATA")]
		public static ResultMetadataType Pdf417ExtraMetadata => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("PDF417_EXTRA_METADATA.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("POSSIBLE_COUNTRY")]
		public static ResultMetadataType PossibleCountry => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("POSSIBLE_COUNTRY.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STRUCTURED_APPEND_PARITY")]
		public static ResultMetadataType StructuredAppendParity => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("STRUCTURED_APPEND_PARITY.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STRUCTURED_APPEND_SEQUENCE")]
		public static ResultMetadataType StructuredAppendSequence => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("STRUCTURED_APPEND_SEQUENCE.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SUGGESTED_PRICE")]
		public static ResultMetadataType SuggestedPrice => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("SUGGESTED_PRICE.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UPC_EAN_EXTENSION")]
		public static ResultMetadataType UpcEanExtension => Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticFields.GetObjectValue("UPC_EAN_EXTENSION.Lcom/google/zxing/ResultMetadataType;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ResultMetadataType(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/ResultMetadataType;", "")]
		public unsafe static ResultMetadataType ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ResultMetadataType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/ResultMetadataType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/ResultMetadataType;", "")]
		public unsafe static ResultMetadataType[] Values()
		{
			return (ResultMetadataType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/ResultMetadataType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ResultMetadataType));
		}
	}
	[Register("com/google/zxing/ResultPoint", DoNotGenerateAcw = true)]
	public class ResultPoint : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/ResultPoint", typeof(ResultPoint));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ResultPoint(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(FF)V", "")]
		public unsafe ResultPoint(float x, float y)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(x);
				ptr[1] = new JniArgumentValue(y);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(FF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(FF)V", this, ptr);
			}
		}

		[Register("distance", "(Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;)F", "")]
		public unsafe static float Distance(ResultPoint pattern1, ResultPoint pattern2)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(pattern1?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(pattern2?.Handle ?? IntPtr.Zero);
			float result = _members.StaticMethods.InvokeSingleMethod("distance.(Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;)F", ptr);
			GC.KeepAlive(pattern1);
			GC.KeepAlive(pattern2);
			return result;
		}

		[Register("equals", "(Ljava/lang/Object;)Z", "")]
		public unsafe sealed override bool Equals(Java.Lang.Object other)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			bool result = _members.InstanceMethods.InvokeNonvirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
			GC.KeepAlive(other);
			return result;
		}

		[Register("getX", "()F", "")]
		public unsafe float GetX()
		{
			return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getX.()F", this, null);
		}

		[Register("getY", "()F", "")]
		public unsafe float GetY()
		{
			return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getY.()F", this, null);
		}

		[Register("hashCode", "()I", "")]
		public unsafe sealed override int GetHashCode()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("hashCode.()I", this, null);
		}

		[Register("orderBestPatterns", "([Lcom/google/zxing/ResultPoint;)V", "")]
		public unsafe static void OrderBestPatterns(ResultPoint[] patterns)
		{
			IntPtr intPtr = JNIEnv.NewArray(patterns);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("orderBestPatterns.([Lcom/google/zxing/ResultPoint;)V", ptr);
			}
			finally
			{
				if (patterns != null)
				{
					JNIEnv.CopyArray(intPtr, patterns);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(patterns);
				}
			}
		}

		[Register("toString", "()Ljava/lang/String;", "")]
		public unsafe sealed override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/RGBLuminanceSource", DoNotGenerateAcw = true)]
	public sealed class RGBLuminanceSource : LuminanceSource
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/RGBLuminanceSource", typeof(RGBLuminanceSource));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal RGBLuminanceSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(II[I)V", "")]
		public unsafe RGBLuminanceSource(int width, int height, int[] pixels)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(pixels);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				ptr[2] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II[I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II[I)V", this, ptr);
			}
			finally
			{
				if (pixels != null)
				{
					JNIEnv.CopyArray(intPtr, pixels);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(pixels);
				}
			}
		}

		[Register("getMatrix", "()[B", "")]
		public unsafe override byte[] GetMatrix()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getMatrix.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("getRow", "(I[B)[B", "")]
		public unsafe override byte[] GetRow(int y, byte[] row)
		{
			IntPtr intPtr = JNIEnv.NewArray(row);
			byte[] result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(y);
				ptr[1] = new JniArgumentValue(intPtr);
				result = (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getRow.(I[B)[B", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
			}
			finally
			{
				if (row != null)
				{
					JNIEnv.CopyArray(intPtr, row);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(row);
			return result;
		}
	}
	[Register("com/google/zxing/WriterException", DoNotGenerateAcw = true)]
	public sealed class WriterException : Java.Lang.Exception
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/WriterException", typeof(WriterException));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal WriterException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe WriterException()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe WriterException(string message)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(Ljava/lang/Throwable;)V", "")]
		public unsafe WriterException(Throwable cause)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Throwable;)V", this, ptr);
			}
		}
	}
}
namespace Google.ZXing.QRCode
{
	[Register("com/google/zxing/qrcode/QRCodeReader", DoNotGenerateAcw = true)]
	public class QRCodeReader : Java.Lang.Object, IReader, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/QRCodeReader", typeof(QRCodeReader));

		private static Delegate cb_decode_Lcom_google_zxing_BinaryBitmap_;

		private static Delegate cb_reset;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected unsafe Google.ZXing.QRCode.Decoder.Decoder Decoder
		{
			[Register("getDecoder", "()Lcom/google/zxing/qrcode/decoder/Decoder;", "GetGetDecoderHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Google.ZXing.QRCode.Decoder.Decoder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDecoder.()Lcom/google/zxing/qrcode/decoder/Decoder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected QRCodeReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe QRCodeReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetDecode_Lcom_google_zxing_BinaryBitmap_Handler()
		{
			if ((object)cb_decode_Lcom_google_zxing_BinaryBitmap_ == null)
			{
				cb_decode_Lcom_google_zxing_BinaryBitmap_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_Decode_Lcom_google_zxing_BinaryBitmap_));
			}
			return cb_decode_Lcom_google_zxing_BinaryBitmap_;
		}

		private static IntPtr n_Decode_Lcom_google_zxing_BinaryBitmap_(IntPtr jnienv, IntPtr native__this, IntPtr native_image)
		{
			QRCodeReader qRCodeReader = Java.Lang.Object.GetObject<QRCodeReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BinaryBitmap image = Java.Lang.Object.GetObject<BinaryBitmap>(native_image, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(qRCodeReader.Decode(image));
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", "GetDecode_Lcom_google_zxing_BinaryBitmap_Handler")]
		public unsafe virtual Result Decode(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeVirtualObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(image);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}

		private static Delegate GetResetHandler()
		{
			if ((object)cb_reset == null)
			{
				cb_reset = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Reset));
			}
			return cb_reset;
		}

		private static void n_Reset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<QRCodeReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}

		[Register("reset", "()V", "GetResetHandler")]
		public unsafe virtual void Reset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
		}
	}
	[Register("com/google/zxing/qrcode/QRCodeWriter", DoNotGenerateAcw = true)]
	public sealed class QRCodeWriter : Java.Lang.Object, IWriter, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/QRCodeWriter", typeof(QRCodeWriter));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal QRCodeWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe QRCodeWriter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(format);
			return result;
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			IntPtr intPtr2 = JavaDictionary<EncodeHintType, object>.ToLocalJniHandle(hints);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				ptr[4] = new JniArgumentValue(intPtr2);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(format);
			GC.KeepAlive(hints);
			return result;
		}
	}
}
namespace Google.ZXing.QRCode.Encoder
{
	[Register("com/google/zxing/qrcode/encoder/BlockPair", DoNotGenerateAcw = true)]
	public sealed class BlockPair : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/encoder/BlockPair", typeof(BlockPair));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BlockPair(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getDataBytes", "()[B", "")]
		public unsafe byte[] GetDataBytes()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getDataBytes.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("getErrorCorrectionBytes", "()[B", "")]
		public unsafe byte[] GetErrorCorrectionBytes()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getErrorCorrectionBytes.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}
	}
	[Register("com/google/zxing/qrcode/encoder/ByteMatrix", DoNotGenerateAcw = true)]
	public sealed class ByteMatrix : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/encoder/ByteMatrix", typeof(ByteMatrix));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Height
		{
			[Register("getHeight", "()I", "GetGetHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getHeight.()I", this, null);
			}
		}

		public unsafe int Width
		{
			[Register("getWidth", "()I", "GetGetWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getWidth.()I", this, null);
			}
		}

		internal ByteMatrix(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe ByteMatrix(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}

		[Register("clear", "(B)V", "")]
		public unsafe void Clear(sbyte value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("clear.(B)V", this, ptr);
		}

		[Register("get", "(II)B", "")]
		public unsafe sbyte Get(int x, int y)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			return _members.InstanceMethods.InvokeAbstractSByteMethod("get.(II)B", this, ptr);
		}

		[Register("getArray", "()[[B", "")]
		public unsafe byte[][] GetArray()
		{
			return (byte[][])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getArray.()[[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte[]));
		}

		[Register("set", "(IIZ)V", "")]
		public unsafe void Set(int x, int y, bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("set.(IIZ)V", this, ptr);
		}

		[Register("set", "(IIB)V", "")]
		public unsafe void Set(int x, int y, sbyte value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("set.(IIB)V", this, ptr);
		}

		[Register("set", "(III)V", "")]
		public unsafe void Set(int x, int y, int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("set.(III)V", this, ptr);
		}
	}
	[Register("com/google/zxing/qrcode/encoder/Encoder", DoNotGenerateAcw = true)]
	public sealed class Encoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/encoder/Encoder", typeof(Encoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Encoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("chooseMode", "(Ljava/lang/String;)Lcom/google/zxing/qrcode/decoder/Mode;", "")]
		public unsafe static Mode ChooseMode(string content)
		{
			IntPtr intPtr = JNIEnv.NewString(content);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Mode>(_members.StaticMethods.InvokeObjectMethod("chooseMode.(Ljava/lang/String;)Lcom/google/zxing/qrcode/decoder/Mode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;)Lcom/google/zxing/qrcode/encoder/QRCode;", "")]
		public unsafe static QRCode Encode(string content, ErrorCorrectionLevel ecLevel)
		{
			IntPtr intPtr = JNIEnv.NewString(content);
			QRCode result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(ecLevel?.Handle ?? IntPtr.Zero);
				result = Java.Lang.Object.GetObject<QRCode>(_members.StaticMethods.InvokeObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;)Lcom/google/zxing/qrcode/encoder/QRCode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(ecLevel);
			return result;
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;Ljava/util/Map;)Lcom/google/zxing/qrcode/encoder/QRCode;", "")]
		public unsafe static QRCode Encode(string content, ErrorCorrectionLevel ecLevel, IDictionary<EncodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewString(content);
			IntPtr intPtr2 = JavaDictionary<EncodeHintType, object>.ToLocalJniHandle(hints);
			QRCode result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(ecLevel?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr2);
				result = Java.Lang.Object.GetObject<QRCode>(_members.StaticMethods.InvokeObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;Ljava/util/Map;)Lcom/google/zxing/qrcode/encoder/QRCode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(ecLevel);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/qrcode/encoder/MaskUtil", DoNotGenerateAcw = true)]
	public sealed class MaskUtil : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/encoder/MaskUtil", typeof(MaskUtil));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MaskUtil(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/qrcode/encoder/MatrixUtil", DoNotGenerateAcw = true)]
	public sealed class MatrixUtil : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/encoder/MatrixUtil", typeof(MatrixUtil));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MatrixUtil(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/qrcode/encoder/QRCode", DoNotGenerateAcw = true)]
	public sealed class QRCode : Java.Lang.Object
	{
		[Register("NUM_MASK_PATTERNS")]
		public const int NumMaskPatterns = 8;

		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/encoder/QRCode", typeof(QRCode));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe ErrorCorrectionLevel ECLevel
		{
			[Register("getECLevel", "()Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", "GetGetECLevelHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.InstanceMethods.InvokeAbstractObjectMethod("getECLevel.()Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setECLevel", "(Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;)V", "GetSetECLevel_Lcom_google_zxing_qrcode_decoder_ErrorCorrectionLevel_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setECLevel.(Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe int MaskPattern
		{
			[Register("getMaskPattern", "()I", "GetGetMaskPatternHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMaskPattern.()I", this, null);
			}
			[Register("setMaskPattern", "(I)V", "GetSetMaskPattern_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setMaskPattern.(I)V", this, ptr);
			}
		}

		public unsafe ByteMatrix Matrix
		{
			[Register("getMatrix", "()Lcom/google/zxing/qrcode/encoder/ByteMatrix;", "GetGetMatrixHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ByteMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMatrix.()Lcom/google/zxing/qrcode/encoder/ByteMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setMatrix", "(Lcom/google/zxing/qrcode/encoder/ByteMatrix;)V", "GetSetMatrix_Lcom_google_zxing_qrcode_encoder_ByteMatrix_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setMatrix.(Lcom/google/zxing/qrcode/encoder/ByteMatrix;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe Mode Mode
		{
			[Register("getMode", "()Lcom/google/zxing/qrcode/decoder/Mode;", "GetGetModeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Mode>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMode.()Lcom/google/zxing/qrcode/decoder/Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setMode", "(Lcom/google/zxing/qrcode/decoder/Mode;)V", "GetSetMode_Lcom_google_zxing_qrcode_decoder_Mode_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setMode.(Lcom/google/zxing/qrcode/decoder/Mode;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe Google.ZXing.QRCode.Decoder.Version Version
		{
			[Register("getVersion", "()Lcom/google/zxing/qrcode/decoder/Version;", "GetGetVersionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Google.ZXing.QRCode.Decoder.Version>(_members.InstanceMethods.InvokeAbstractObjectMethod("getVersion.()Lcom/google/zxing/qrcode/decoder/Version;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setVersion", "(Lcom/google/zxing/qrcode/decoder/Version;)V", "GetSetVersion_Lcom_google_zxing_qrcode_decoder_Version_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setVersion.(Lcom/google/zxing/qrcode/decoder/Version;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		internal QRCode(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe QRCode()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("isValidMaskPattern", "(I)Z", "")]
		public unsafe static bool IsValidMaskPattern(int maskPattern)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(maskPattern);
			return _members.StaticMethods.InvokeBooleanMethod("isValidMaskPattern.(I)Z", ptr);
		}
	}
}
namespace Google.ZXing.QRCode.Detector
{
	[Register("com/google/zxing/qrcode/detector/AlignmentPattern", DoNotGenerateAcw = true)]
	public sealed class AlignmentPattern : ResultPoint
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/detector/AlignmentPattern", typeof(AlignmentPattern));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AlignmentPattern(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/qrcode/detector/AlignmentPatternFinder", DoNotGenerateAcw = true)]
	public sealed class AlignmentPatternFinder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/detector/AlignmentPatternFinder", typeof(AlignmentPatternFinder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AlignmentPatternFinder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/qrcode/detector/Detector", DoNotGenerateAcw = true)]
	public class Detector : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/detector/Detector", typeof(Detector));

		private static Delegate cb_detect;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected unsafe BitMatrix Image
		{
			[Register("getImage", "()Lcom/google/zxing/common/BitMatrix;", "GetGetImageHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getImage.()Lcom/google/zxing/common/BitMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe IResultPointCallback ResultPointCallback
		{
			[Register("getResultPointCallback", "()Lcom/google/zxing/ResultPointCallback;", "GetGetResultPointCallbackHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IResultPointCallback>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getResultPointCallback.()Lcom/google/zxing/ResultPointCallback;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Detector(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;)V", "")]
		public unsafe Detector(BitMatrix image)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", this, ptr);
				GC.KeepAlive(image);
			}
		}

		[Register("calculateModuleSize", "(Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;)F", "")]
		protected unsafe float CalculateModuleSize(ResultPoint topLeft, ResultPoint topRight, ResultPoint bottomLeft)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(topLeft?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(topRight?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(bottomLeft?.Handle ?? IntPtr.Zero);
			float result = _members.InstanceMethods.InvokeNonvirtualSingleMethod("calculateModuleSize.(Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;)F", this, ptr);
			GC.KeepAlive(topLeft);
			GC.KeepAlive(topRight);
			GC.KeepAlive(bottomLeft);
			return result;
		}

		private static Delegate GetDetectHandler()
		{
			if ((object)cb_detect == null)
			{
				cb_detect = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_Detect));
			}
			return cb_detect;
		}

		private static IntPtr n_Detect(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Detector>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Detect());
		}

		[Register("detect", "()Lcom/google/zxing/common/DetectorResult;", "GetDetectHandler")]
		public unsafe virtual DetectorResult Detect()
		{
			return Java.Lang.Object.GetObject<DetectorResult>(_members.InstanceMethods.InvokeVirtualObjectMethod("detect.()Lcom/google/zxing/common/DetectorResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("detect", "(Ljava/util/Map;)Lcom/google/zxing/common/DetectorResult;", "")]
		public unsafe DetectorResult Detect(IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			DetectorResult result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<DetectorResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("detect.(Ljava/util/Map;)Lcom/google/zxing/common/DetectorResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(hints);
			return result;
		}

		[Register("findAlignmentInRegion", "(FIIF)Lcom/google/zxing/qrcode/detector/AlignmentPattern;", "")]
		protected unsafe AlignmentPattern FindAlignmentInRegion(float overallEstModuleSize, int estAlignmentX, int estAlignmentY, float allowanceFactor)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(overallEstModuleSize);
			ptr[1] = new JniArgumentValue(estAlignmentX);
			ptr[2] = new JniArgumentValue(estAlignmentY);
			ptr[3] = new JniArgumentValue(allowanceFactor);
			return Java.Lang.Object.GetObject<AlignmentPattern>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("findAlignmentInRegion.(FIIF)Lcom/google/zxing/qrcode/detector/AlignmentPattern;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("processFinderPatternInfo", "(Lcom/google/zxing/qrcode/detector/FinderPatternInfo;)Lcom/google/zxing/common/DetectorResult;", "")]
		protected unsafe DetectorResult ProcessFinderPatternInfo(FinderPatternInfo info)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			DetectorResult result = Java.Lang.Object.GetObject<DetectorResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("processFinderPatternInfo.(Lcom/google/zxing/qrcode/detector/FinderPatternInfo;)Lcom/google/zxing/common/DetectorResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(info);
			return result;
		}
	}
	[Register("com/google/zxing/qrcode/detector/FinderPattern", DoNotGenerateAcw = true)]
	public sealed class FinderPattern : ResultPoint
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/detector/FinderPattern", typeof(FinderPattern));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe float EstimatedModuleSize
		{
			[Register("getEstimatedModuleSize", "()F", "GetGetEstimatedModuleSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getEstimatedModuleSize.()F", this, null);
			}
		}

		internal FinderPattern(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/qrcode/detector/FinderPatternFinder", DoNotGenerateAcw = true)]
	public class FinderPatternFinder : Java.Lang.Object
	{
		[Register("MAX_MODULES")]
		protected const int MaxModules = 97;

		[Register("MIN_SKIP")]
		protected const int MinSkip = 3;

		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/detector/FinderPatternFinder", typeof(FinderPatternFinder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected unsafe BitMatrix Image
		{
			[Register("getImage", "()Lcom/google/zxing/common/BitMatrix;", "GetGetImageHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getImage.()Lcom/google/zxing/common/BitMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe IList<FinderPattern> PossibleCenters
		{
			[Register("getPossibleCenters", "()Ljava/util/List;", "GetGetPossibleCentersHandler")]
			get
			{
				return JavaList<FinderPattern>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPossibleCenters.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected FinderPatternFinder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;)V", "")]
		public unsafe FinderPatternFinder(BitMatrix image)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", this, ptr);
				GC.KeepAlive(image);
			}
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;Lcom/google/zxing/ResultPointCallback;)V", "")]
		public unsafe FinderPatternFinder(BitMatrix image, IResultPointCallback resultPointCallback)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((resultPointCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)resultPointCallback).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;Lcom/google/zxing/ResultPointCallback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;Lcom/google/zxing/ResultPointCallback;)V", this, ptr);
				GC.KeepAlive(image);
				GC.KeepAlive(resultPointCallback);
			}
		}

		[Register("clearCounts", "([I)V", "")]
		protected unsafe void ClearCounts(int[] counts)
		{
			IntPtr intPtr = JNIEnv.NewArray(counts);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("clearCounts.([I)V", this, ptr);
			}
			finally
			{
				if (counts != null)
				{
					JNIEnv.CopyArray(intPtr, counts);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(counts);
				}
			}
		}

		[Register("foundPatternCross", "([I)Z", "")]
		protected unsafe static bool FoundPatternCross(int[] stateCount)
		{
			IntPtr intPtr = JNIEnv.NewArray(stateCount);
			bool result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = _members.StaticMethods.InvokeBooleanMethod("foundPatternCross.([I)Z", ptr);
			}
			finally
			{
				if (stateCount != null)
				{
					JNIEnv.CopyArray(intPtr, stateCount);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(stateCount);
			return result;
		}

		[Register("foundPatternDiagonal", "([I)Z", "")]
		protected unsafe static bool FoundPatternDiagonal(int[] stateCount)
		{
			IntPtr intPtr = JNIEnv.NewArray(stateCount);
			bool result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = _members.StaticMethods.InvokeBooleanMethod("foundPatternDiagonal.([I)Z", ptr);
			}
			finally
			{
				if (stateCount != null)
				{
					JNIEnv.CopyArray(intPtr, stateCount);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(stateCount);
			return result;
		}

		[Register("handlePossibleCenter", "([III)Z", "")]
		protected unsafe bool HandlePossibleCenter(int[] stateCount, int i, int j)
		{
			IntPtr intPtr = JNIEnv.NewArray(stateCount);
			bool result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(i);
				ptr[2] = new JniArgumentValue(j);
				result = _members.InstanceMethods.InvokeNonvirtualBooleanMethod("handlePossibleCenter.([III)Z", this, ptr);
			}
			finally
			{
				if (stateCount != null)
				{
					JNIEnv.CopyArray(intPtr, stateCount);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(stateCount);
			return result;
		}

		[Obsolete("deprecated")]
		[Register("handlePossibleCenter", "([IIIZ)Z", "")]
		protected unsafe bool HandlePossibleCenter(int[] stateCount, int i, int j, bool pureBarcode)
		{
			IntPtr intPtr = JNIEnv.NewArray(stateCount);
			bool result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(i);
				ptr[2] = new JniArgumentValue(j);
				ptr[3] = new JniArgumentValue(pureBarcode);
				result = _members.InstanceMethods.InvokeNonvirtualBooleanMethod("handlePossibleCenter.([IIIZ)Z", this, ptr);
			}
			finally
			{
				if (stateCount != null)
				{
					JNIEnv.CopyArray(intPtr, stateCount);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(stateCount);
			return result;
		}

		[Register("shiftCounts2", "([I)V", "")]
		protected unsafe void ShiftCounts2(int[] stateCount)
		{
			IntPtr intPtr = JNIEnv.NewArray(stateCount);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("shiftCounts2.([I)V", this, ptr);
			}
			finally
			{
				if (stateCount != null)
				{
					JNIEnv.CopyArray(intPtr, stateCount);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(stateCount);
				}
			}
		}
	}
	[Register("com/google/zxing/qrcode/detector/FinderPatternInfo", DoNotGenerateAcw = true)]
	public sealed class FinderPatternInfo : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/detector/FinderPatternInfo", typeof(FinderPatternInfo));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe FinderPattern BottomLeft
		{
			[Register("getBottomLeft", "()Lcom/google/zxing/qrcode/detector/FinderPattern;", "GetGetBottomLeftHandler")]
			get
			{
				return Java.Lang.Object.GetObject<FinderPattern>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBottomLeft.()Lcom/google/zxing/qrcode/detector/FinderPattern;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe FinderPattern TopLeft
		{
			[Register("getTopLeft", "()Lcom/google/zxing/qrcode/detector/FinderPattern;", "GetGetTopLeftHandler")]
			get
			{
				return Java.Lang.Object.GetObject<FinderPattern>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTopLeft.()Lcom/google/zxing/qrcode/detector/FinderPattern;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe FinderPattern TopRight
		{
			[Register("getTopRight", "()Lcom/google/zxing/qrcode/detector/FinderPattern;", "GetGetTopRightHandler")]
			get
			{
				return Java.Lang.Object.GetObject<FinderPattern>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTopRight.()Lcom/google/zxing/qrcode/detector/FinderPattern;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal FinderPatternInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "([Lcom/google/zxing/qrcode/detector/FinderPattern;)V", "")]
		public unsafe FinderPatternInfo(FinderPattern[] patternCenters)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(patternCenters);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("([Lcom/google/zxing/qrcode/detector/FinderPattern;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("([Lcom/google/zxing/qrcode/detector/FinderPattern;)V", this, ptr);
			}
			finally
			{
				if (patternCenters != null)
				{
					JNIEnv.CopyArray(intPtr, patternCenters);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(patternCenters);
				}
			}
		}
	}
}
namespace Google.ZXing.QRCode.Decoder
{
	[Register("com/google/zxing/qrcode/decoder/BitMatrixParser", DoNotGenerateAcw = true)]
	public sealed class BitMatrixParser : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/BitMatrixParser", typeof(BitMatrixParser));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BitMatrixParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/qrcode/decoder/DataBlock", DoNotGenerateAcw = true)]
	public sealed class DataBlock : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/DataBlock", typeof(DataBlock));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DataBlock(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/qrcode/decoder/DataMask", DoNotGenerateAcw = true)]
	public abstract class DataMask : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/DataMask", typeof(DataMask));

		[Register("DATA_MASK_000")]
		public static DataMask DataMask000 => Java.Lang.Object.GetObject<DataMask>(_members.StaticFields.GetObjectValue("DATA_MASK_000.Lcom/google/zxing/qrcode/decoder/DataMask;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DATA_MASK_001")]
		public static DataMask DataMask001 => Java.Lang.Object.GetObject<DataMask>(_members.StaticFields.GetObjectValue("DATA_MASK_001.Lcom/google/zxing/qrcode/decoder/DataMask;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DATA_MASK_010")]
		public static DataMask DataMask010 => Java.Lang.Object.GetObject<DataMask>(_members.StaticFields.GetObjectValue("DATA_MASK_010.Lcom/google/zxing/qrcode/decoder/DataMask;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DATA_MASK_011")]
		public static DataMask DataMask011 => Java.Lang.Object.GetObject<DataMask>(_members.StaticFields.GetObjectValue("DATA_MASK_011.Lcom/google/zxing/qrcode/decoder/DataMask;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DATA_MASK_100")]
		public static DataMask DataMask100 => Java.Lang.Object.GetObject<DataMask>(_members.StaticFields.GetObjectValue("DATA_MASK_100.Lcom/google/zxing/qrcode/decoder/DataMask;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DATA_MASK_101")]
		public static DataMask DataMask101 => Java.Lang.Object.GetObject<DataMask>(_members.StaticFields.GetObjectValue("DATA_MASK_101.Lcom/google/zxing/qrcode/decoder/DataMask;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DATA_MASK_110")]
		public static DataMask DataMask110 => Java.Lang.Object.GetObject<DataMask>(_members.StaticFields.GetObjectValue("DATA_MASK_110.Lcom/google/zxing/qrcode/decoder/DataMask;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DATA_MASK_111")]
		public static DataMask DataMask111 => Java.Lang.Object.GetObject<DataMask>(_members.StaticFields.GetObjectValue("DATA_MASK_111.Lcom/google/zxing/qrcode/decoder/DataMask;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected DataMask(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Ljava/lang/Enum;", "")]
		public unsafe static Java.Lang.Enum ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Enum>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Ljava/lang/Enum;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/qrcode/decoder/DataMask;", "")]
		public unsafe static DataMask[] Values()
		{
			return (DataMask[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/qrcode/decoder/DataMask;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(DataMask));
		}
	}
	[Register("com/google/zxing/qrcode/decoder/DataMask", DoNotGenerateAcw = true)]
	internal class DataMaskInvoker : DataMask
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/qrcode/decoder/DataMask", typeof(DataMaskInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public DataMaskInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/zxing/qrcode/decoder/DecodedBitStreamParser", DoNotGenerateAcw = true)]
	public sealed class DecodedBitStreamParser : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/DecodedBitStreamParser", typeof(DecodedBitStreamParser));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DecodedBitStreamParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/qrcode/decoder/Decoder", DoNotGenerateAcw = true)]
	public sealed class Decoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/Decoder", typeof(Decoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Decoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Decoder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decode", "([[Z)Lcom/google/zxing/common/DecoderResult;", "")]
		public unsafe DecoderResult Decode(bool[][] image)
		{
			IntPtr intPtr = JNIEnv.NewArray(image);
			DecoderResult result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<DecoderResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.([[Z)Lcom/google/zxing/common/DecoderResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (image != null)
				{
					JNIEnv.CopyArray(intPtr, image);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(image);
			return result;
		}

		[Register("decode", "([[ZLjava/util/Map;)Lcom/google/zxing/common/DecoderResult;", "")]
		public unsafe DecoderResult Decode(bool[][] image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewArray(image);
			IntPtr intPtr2 = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			DecoderResult result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				result = Java.Lang.Object.GetObject<DecoderResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.([[ZLjava/util/Map;)Lcom/google/zxing/common/DecoderResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (image != null)
				{
					JNIEnv.CopyArray(intPtr, image);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/common/BitMatrix;)Lcom/google/zxing/common/DecoderResult;", "")]
		public unsafe DecoderResult Decode(BitMatrix bits)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bits?.Handle ?? IntPtr.Zero);
			DecoderResult result = Java.Lang.Object.GetObject<DecoderResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/common/BitMatrix;)Lcom/google/zxing/common/DecoderResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(bits);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/common/BitMatrix;Ljava/util/Map;)Lcom/google/zxing/common/DecoderResult;", "")]
		public unsafe DecoderResult Decode(BitMatrix bits, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			DecoderResult result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bits?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<DecoderResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/common/BitMatrix;Ljava/util/Map;)Lcom/google/zxing/common/DecoderResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(bits);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/qrcode/decoder/ErrorCorrectionLevel", DoNotGenerateAcw = true)]
	public sealed class ErrorCorrectionLevel : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/ErrorCorrectionLevel", typeof(ErrorCorrectionLevel));

		[Register("H")]
		public static ErrorCorrectionLevel H => Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticFields.GetObjectValue("H.Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("L")]
		public static ErrorCorrectionLevel L => Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticFields.GetObjectValue("L.Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("M")]
		public static ErrorCorrectionLevel M => Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticFields.GetObjectValue("M.Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Q")]
		public static ErrorCorrectionLevel Q => Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticFields.GetObjectValue("Q.Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Bits
		{
			[Register("getBits", "()I", "GetGetBitsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getBits.()I", this, null);
			}
		}

		internal ErrorCorrectionLevel(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("forBits", "(I)Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", "")]
		public unsafe static ErrorCorrectionLevel ForBits(int bits)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bits);
			return Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticMethods.InvokeObjectMethod("forBits.(I)Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", "")]
		public unsafe static ErrorCorrectionLevel ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", "")]
		public unsafe static ErrorCorrectionLevel[] Values()
		{
			return (ErrorCorrectionLevel[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ErrorCorrectionLevel));
		}
	}
	[Register("com/google/zxing/qrcode/decoder/FormatInformation", DoNotGenerateAcw = true)]
	public sealed class FormatInformation : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/FormatInformation", typeof(FormatInformation));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal FormatInformation(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/qrcode/decoder/Mode", DoNotGenerateAcw = true)]
	public sealed class Mode : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/Mode", typeof(Mode));

		[Register("ALPHANUMERIC")]
		public static Mode Alphanumeric => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("ALPHANUMERIC.Lcom/google/zxing/qrcode/decoder/Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("BYTE")]
		public static Mode Byte => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("BYTE.Lcom/google/zxing/qrcode/decoder/Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ECI")]
		public static Mode Eci => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("ECI.Lcom/google/zxing/qrcode/decoder/Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FNC1_FIRST_POSITION")]
		public static Mode Fnc1FirstPosition => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("FNC1_FIRST_POSITION.Lcom/google/zxing/qrcode/decoder/Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FNC1_SECOND_POSITION")]
		public static Mode Fnc1SecondPosition => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("FNC1_SECOND_POSITION.Lcom/google/zxing/qrcode/decoder/Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("HANZI")]
		public static Mode Hanzi => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("HANZI.Lcom/google/zxing/qrcode/decoder/Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("KANJI")]
		public static Mode Kanji => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("KANJI.Lcom/google/zxing/qrcode/decoder/Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NUMERIC")]
		public static Mode Numeric => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("NUMERIC.Lcom/google/zxing/qrcode/decoder/Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STRUCTURED_APPEND")]
		public static Mode StructuredAppend => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("STRUCTURED_APPEND.Lcom/google/zxing/qrcode/decoder/Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TERMINATOR")]
		public static Mode Terminator => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("TERMINATOR.Lcom/google/zxing/qrcode/decoder/Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Bits
		{
			[Register("getBits", "()I", "GetGetBitsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getBits.()I", this, null);
			}
		}

		internal Mode(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("forBits", "(I)Lcom/google/zxing/qrcode/decoder/Mode;", "")]
		public unsafe static Mode ForBits(int bits)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bits);
			return Java.Lang.Object.GetObject<Mode>(_members.StaticMethods.InvokeObjectMethod("forBits.(I)Lcom/google/zxing/qrcode/decoder/Mode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getCharacterCountBits", "(Lcom/google/zxing/qrcode/decoder/Version;)I", "")]
		public unsafe int GetCharacterCountBits(Version version)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(version?.Handle ?? IntPtr.Zero);
			int result = _members.InstanceMethods.InvokeAbstractInt32Method("getCharacterCountBits.(Lcom/google/zxing/qrcode/decoder/Version;)I", this, ptr);
			GC.KeepAlive(version);
			return result;
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/qrcode/decoder/Mode;", "")]
		public unsafe static Mode ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Mode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/qrcode/decoder/Mode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/qrcode/decoder/Mode;", "")]
		public unsafe static Mode[] Values()
		{
			return (Mode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/qrcode/decoder/Mode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Mode));
		}
	}
	[Register("com/google/zxing/qrcode/decoder/QRCodeDecoderMetaData", DoNotGenerateAcw = true)]
	public sealed class QRCodeDecoderMetaData : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/QRCodeDecoderMetaData", typeof(QRCodeDecoderMetaData));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsMirrored
		{
			[Register("isMirrored", "()Z", "GetIsMirroredHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isMirrored.()Z", this, null);
			}
		}

		internal QRCodeDecoderMetaData(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("applyMirroredCorrection", "([Lcom/google/zxing/ResultPoint;)V", "")]
		public unsafe void ApplyMirroredCorrection(ResultPoint[] points)
		{
			IntPtr intPtr = JNIEnv.NewArray(points);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("applyMirroredCorrection.([Lcom/google/zxing/ResultPoint;)V", this, ptr);
			}
			finally
			{
				if (points != null)
				{
					JNIEnv.CopyArray(intPtr, points);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(points);
				}
			}
		}
	}
	[Register("com/google/zxing/qrcode/decoder/Version", DoNotGenerateAcw = true)]
	public sealed class Version : Java.Lang.Object
	{
		[Register("com/google/zxing/qrcode/decoder/Version$ECB", DoNotGenerateAcw = true)]
		public sealed class ECB : Java.Lang.Object
		{
			internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/Version$ECB", typeof(ECB));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe int Count
			{
				[Register("getCount", "()I", "GetGetCountHandler")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractInt32Method("getCount.()I", this, null);
				}
			}

			public unsafe int DataCodewords
			{
				[Register("getDataCodewords", "()I", "GetGetDataCodewordsHandler")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractInt32Method("getDataCodewords.()I", this, null);
				}
			}

			internal ECB(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/google/zxing/qrcode/decoder/Version$ECBlocks", DoNotGenerateAcw = true)]
		public sealed class ECBlocks : Java.Lang.Object
		{
			internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/Version$ECBlocks", typeof(ECBlocks));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe int ECCodewordsPerBlock
			{
				[Register("getECCodewordsPerBlock", "()I", "GetGetECCodewordsPerBlockHandler")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractInt32Method("getECCodewordsPerBlock.()I", this, null);
				}
			}

			public unsafe int NumBlocks
			{
				[Register("getNumBlocks", "()I", "GetGetNumBlocksHandler")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractInt32Method("getNumBlocks.()I", this, null);
				}
			}

			public unsafe int TotalECCodewords
			{
				[Register("getTotalECCodewords", "()I", "GetGetTotalECCodewordsHandler")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractInt32Method("getTotalECCodewords.()I", this, null);
				}
			}

			internal ECBlocks(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("getECBlocks", "()[Lcom/google/zxing/qrcode/decoder/Version$ECB;", "")]
			public unsafe ECB[] GetECBlocks()
			{
				return (ECB[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getECBlocks.()[Lcom/google/zxing/qrcode/decoder/Version$ECB;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ECB));
			}
		}

		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/Version", typeof(Version));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int DimensionForVersion
		{
			[Register("getDimensionForVersion", "()I", "GetGetDimensionForVersionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getDimensionForVersion.()I", this, null);
			}
		}

		public unsafe int TotalCodewords
		{
			[Register("getTotalCodewords", "()I", "GetGetTotalCodewordsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getTotalCodewords.()I", this, null);
			}
		}

		public unsafe int VersionNumber
		{
			[Register("getVersionNumber", "()I", "GetGetVersionNumberHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getVersionNumber.()I", this, null);
			}
		}

		internal Version(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getAlignmentPatternCenters", "()[I", "")]
		public unsafe int[] GetAlignmentPatternCenters()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getAlignmentPatternCenters.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		[Register("getECBlocksForLevel", "(Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;)Lcom/google/zxing/qrcode/decoder/Version$ECBlocks;", "")]
		public unsafe ECBlocks GetECBlocksForLevel(ErrorCorrectionLevel ecLevel)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ecLevel?.Handle ?? IntPtr.Zero);
			ECBlocks result = Java.Lang.Object.GetObject<ECBlocks>(_members.InstanceMethods.InvokeAbstractObjectMethod("getECBlocksForLevel.(Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;)Lcom/google/zxing/qrcode/decoder/Version$ECBlocks;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(ecLevel);
			return result;
		}

		[Register("getProvisionalVersionForDimension", "(I)Lcom/google/zxing/qrcode/decoder/Version;", "")]
		public unsafe static Version GetProvisionalVersionForDimension(int dimension)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dimension);
			return Java.Lang.Object.GetObject<Version>(_members.StaticMethods.InvokeObjectMethod("getProvisionalVersionForDimension.(I)Lcom/google/zxing/qrcode/decoder/Version;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getVersionForNumber", "(I)Lcom/google/zxing/qrcode/decoder/Version;", "")]
		public unsafe static Version GetVersionForNumber(int versionNumber)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(versionNumber);
			return Java.Lang.Object.GetObject<Version>(_members.StaticMethods.InvokeObjectMethod("getVersionForNumber.(I)Lcom/google/zxing/qrcode/decoder/Version;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Google.ZXing.PDF417
{
	[Register("com/google/zxing/pdf417/PDF417Common", DoNotGenerateAcw = true)]
	public sealed class PDF417Common : Java.Lang.Object
	{
		[Register("BARS_IN_MODULE")]
		public const int BarsInModule = 8;

		[Register("MAX_CODEWORDS_IN_BARCODE")]
		public const int MaxCodewordsInBarcode = 928;

		[Register("MAX_ROWS_IN_BARCODE")]
		public const int MaxRowsInBarcode = 90;

		[Register("MIN_ROWS_IN_BARCODE")]
		public const int MinRowsInBarcode = 3;

		[Register("MODULES_IN_CODEWORD")]
		public const int ModulesInCodeword = 17;

		[Register("MODULES_IN_STOP_PATTERN")]
		public const int ModulesInStopPattern = 18;

		[Register("NUMBER_OF_CODEWORDS")]
		public const int NumberOfCodewords = 929;

		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/PDF417Common", typeof(PDF417Common));

		[Register("SYMBOL_TABLE")]
		public static IList<int> SymbolTable => Android.Runtime.JavaArray<int>.FromJniHandle(_members.StaticFields.GetObjectValue("SYMBOL_TABLE.[I").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal PDF417Common(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Obsolete("deprecated")]
		[Register("getBitCountSum", "([I)I", "")]
		public unsafe static int GetBitCountSum(int[] moduleBitCount)
		{
			IntPtr intPtr = JNIEnv.NewArray(moduleBitCount);
			int result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = _members.StaticMethods.InvokeInt32Method("getBitCountSum.([I)I", ptr);
			}
			finally
			{
				if (moduleBitCount != null)
				{
					JNIEnv.CopyArray(intPtr, moduleBitCount);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(moduleBitCount);
			return result;
		}

		[Register("getCodeword", "(I)I", "")]
		public unsafe static int GetCodeword(int symbol)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(symbol);
			return _members.StaticMethods.InvokeInt32Method("getCodeword.(I)I", ptr);
		}

		[Register("toIntArray", "(Ljava/util/Collection;)[I", "")]
		public unsafe static int[] ToIntArray(ICollection<Integer> list)
		{
			IntPtr intPtr = JavaCollection<Integer>.ToLocalJniHandle(list);
			int[] result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = (int[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("toIntArray.(Ljava/util/Collection;)[I", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(list);
			return result;
		}
	}
	[Register("com/google/zxing/pdf417/PDF417Reader", DoNotGenerateAcw = true)]
	public sealed class PDF417Reader : Java.Lang.Object, IReader, IJavaObject, IDisposable, IMultipleBarcodeReader
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/PDF417Reader", typeof(PDF417Reader));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal PDF417Reader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PDF417Reader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(image);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}

		[Register("decodeMultiple", "(Lcom/google/zxing/BinaryBitmap;)[Lcom/google/zxing/Result;", "")]
		public unsafe Result[] DecodeMultiple(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result[] result = (Result[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeMultiple.(Lcom/google/zxing/BinaryBitmap;)[Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Result));
			GC.KeepAlive(image);
			return result;
		}

		[Register("decodeMultiple", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)[Lcom/google/zxing/Result;", "")]
		public unsafe Result[] DecodeMultiple(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result[] result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = (Result[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeMultiple.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)[Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Result));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}

		[Register("reset", "()V", "")]
		public unsafe void Reset()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("reset.()V", this, null);
		}
	}
	[Register("com/google/zxing/pdf417/PDF417ResultMetadata", DoNotGenerateAcw = true)]
	public sealed class PDF417ResultMetadata : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/PDF417ResultMetadata", typeof(PDF417ResultMetadata));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string Addressee
		{
			[Register("getAddressee", "()Ljava/lang/String;", "GetGetAddresseeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getAddressee.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setAddressee", "(Ljava/lang/String;)V", "GetSetAddressee_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setAddressee.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe int Checksum
		{
			[Register("getChecksum", "()I", "GetGetChecksumHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getChecksum.()I", this, null);
			}
			[Register("setChecksum", "(I)V", "GetSetChecksum_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setChecksum.(I)V", this, ptr);
			}
		}

		public unsafe string FileId
		{
			[Register("getFileId", "()Ljava/lang/String;", "GetGetFileIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getFileId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setFileId", "(Ljava/lang/String;)V", "GetSetFileId_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setFileId.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe string FileName
		{
			[Register("getFileName", "()Ljava/lang/String;", "GetGetFileNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getFileName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setFileName", "(Ljava/lang/String;)V", "GetSetFileName_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setFileName.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe long FileSize
		{
			[Register("getFileSize", "()J", "GetGetFileSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getFileSize.()J", this, null);
			}
			[Register("setFileSize", "(J)V", "GetSetFileSize_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setFileSize.(J)V", this, ptr);
			}
		}

		public unsafe bool LastSegment
		{
			[Register("isLastSegment", "()Z", "GetIsLastSegmentHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isLastSegment.()Z", this, null);
			}
			[Register("setLastSegment", "(Z)V", "GetSetLastSegment_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setLastSegment.(Z)V", this, ptr);
			}
		}

		public unsafe int SegmentCount
		{
			[Register("getSegmentCount", "()I", "GetGetSegmentCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getSegmentCount.()I", this, null);
			}
			[Register("setSegmentCount", "(I)V", "GetSetSegmentCount_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setSegmentCount.(I)V", this, ptr);
			}
		}

		public unsafe int SegmentIndex
		{
			[Register("getSegmentIndex", "()I", "GetGetSegmentIndexHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getSegmentIndex.()I", this, null);
			}
			[Register("setSegmentIndex", "(I)V", "GetSetSegmentIndex_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setSegmentIndex.(I)V", this, ptr);
			}
		}

		public unsafe string Sender
		{
			[Register("getSender", "()Ljava/lang/String;", "GetGetSenderHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSender.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setSender", "(Ljava/lang/String;)V", "GetSetSender_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setSender.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe long Timestamp
		{
			[Register("getTimestamp", "()J", "GetGetTimestampHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getTimestamp.()J", this, null);
			}
			[Register("setTimestamp", "(J)V", "GetSetTimestamp_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTimestamp.(J)V", this, ptr);
			}
		}

		internal PDF417ResultMetadata(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PDF417ResultMetadata()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Obsolete("deprecated")]
		[Register("getOptionalData", "()[I", "")]
		public unsafe int[] GetOptionalData()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getOptionalData.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		[Obsolete("deprecated")]
		[Register("setOptionalData", "([I)V", "")]
		public unsafe void SetOptionalData(int[] optionalData)
		{
			IntPtr intPtr = JNIEnv.NewArray(optionalData);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setOptionalData.([I)V", this, ptr);
			}
			finally
			{
				if (optionalData != null)
				{
					JNIEnv.CopyArray(intPtr, optionalData);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(optionalData);
				}
			}
		}
	}
	[Register("com/google/zxing/pdf417/PDF417Writer", DoNotGenerateAcw = true)]
	public sealed class PDF417Writer : Java.Lang.Object, IWriter, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/PDF417Writer", typeof(PDF417Writer));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal PDF417Writer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PDF417Writer()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(format);
			return result;
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			IntPtr intPtr2 = JavaDictionary<EncodeHintType, object>.ToLocalJniHandle(hints);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				ptr[4] = new JniArgumentValue(intPtr2);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(format);
			GC.KeepAlive(hints);
			return result;
		}
	}
}
namespace Google.ZXing.PDF417.Encoder
{
	[Register("com/google/zxing/pdf417/encoder/BarcodeMatrix", DoNotGenerateAcw = true)]
	public sealed class BarcodeMatrix : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/encoder/BarcodeMatrix", typeof(BarcodeMatrix));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BarcodeMatrix(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getMatrix", "()[[B", "")]
		public unsafe byte[][] GetMatrix()
		{
			return (byte[][])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getMatrix.()[[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte[]));
		}

		[Register("getScaledMatrix", "(II)[[B", "")]
		public unsafe byte[][] GetScaledMatrix(int xScale, int yScale)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(xScale);
			ptr[1] = new JniArgumentValue(yScale);
			return (byte[][])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getScaledMatrix.(II)[[B", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte[]));
		}
	}
	[Register("com/google/zxing/pdf417/encoder/BarcodeRow", DoNotGenerateAcw = true)]
	public sealed class BarcodeRow : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/encoder/BarcodeRow", typeof(BarcodeRow));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BarcodeRow(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/encoder/Compaction", DoNotGenerateAcw = true)]
	public sealed class Compaction : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/encoder/Compaction", typeof(Compaction));

		[Register("AUTO")]
		public static Compaction Auto => Java.Lang.Object.GetObject<Compaction>(_members.StaticFields.GetObjectValue("AUTO.Lcom/google/zxing/pdf417/encoder/Compaction;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("BYTE")]
		public static Compaction Byte => Java.Lang.Object.GetObject<Compaction>(_members.StaticFields.GetObjectValue("BYTE.Lcom/google/zxing/pdf417/encoder/Compaction;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NUMERIC")]
		public static Compaction Numeric => Java.Lang.Object.GetObject<Compaction>(_members.StaticFields.GetObjectValue("NUMERIC.Lcom/google/zxing/pdf417/encoder/Compaction;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TEXT")]
		public static Compaction Text => Java.Lang.Object.GetObject<Compaction>(_members.StaticFields.GetObjectValue("TEXT.Lcom/google/zxing/pdf417/encoder/Compaction;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Compaction(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/pdf417/encoder/Compaction;", "")]
		public unsafe static Compaction ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Compaction>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/pdf417/encoder/Compaction;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/pdf417/encoder/Compaction;", "")]
		public unsafe static Compaction[] Values()
		{
			return (Compaction[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/pdf417/encoder/Compaction;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Compaction));
		}
	}
	[Register("com/google/zxing/pdf417/encoder/Dimensions", DoNotGenerateAcw = true)]
	public sealed class Dimensions : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/encoder/Dimensions", typeof(Dimensions));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int MaxCols
		{
			[Register("getMaxCols", "()I", "GetGetMaxColsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMaxCols.()I", this, null);
			}
		}

		public unsafe int MaxRows
		{
			[Register("getMaxRows", "()I", "GetGetMaxRowsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMaxRows.()I", this, null);
			}
		}

		public unsafe int MinCols
		{
			[Register("getMinCols", "()I", "GetGetMinColsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMinCols.()I", this, null);
			}
		}

		public unsafe int MinRows
		{
			[Register("getMinRows", "()I", "GetGetMinRowsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMinRows.()I", this, null);
			}
		}

		internal Dimensions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(IIII)V", "")]
		public unsafe Dimensions(int minCols, int maxCols, int minRows, int maxRows)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(minCols);
				ptr[1] = new JniArgumentValue(maxCols);
				ptr[2] = new JniArgumentValue(minRows);
				ptr[3] = new JniArgumentValue(maxRows);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(IIII)V", this, ptr);
			}
		}
	}
	[Register("com/google/zxing/pdf417/encoder/PDF417", DoNotGenerateAcw = true)]
	public sealed class PDF417 : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/encoder/PDF417", typeof(PDF417));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe BarcodeMatrix BarcodeMatrix
		{
			[Register("getBarcodeMatrix", "()Lcom/google/zxing/pdf417/encoder/BarcodeMatrix;", "GetGetBarcodeMatrixHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BarcodeMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBarcodeMatrix.()Lcom/google/zxing/pdf417/encoder/BarcodeMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal PDF417(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PDF417()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Z)V", "")]
		public unsafe PDF417(bool compact)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(compact);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Z)V", this, ptr);
			}
		}

		[Register("generateBarcodeLogic", "(Ljava/lang/String;I)V", "")]
		public unsafe void GenerateBarcodeLogic(string msg, int errorCorrectionLevel)
		{
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(errorCorrectionLevel);
				_members.InstanceMethods.InvokeAbstractVoidMethod("generateBarcodeLogic.(Ljava/lang/String;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setCompact", "(Z)V", "")]
		public unsafe void SetCompact(bool compact)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(compact);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setCompact.(Z)V", this, ptr);
		}

		[Register("setCompaction", "(Lcom/google/zxing/pdf417/encoder/Compaction;)V", "")]
		public unsafe void SetCompaction(Compaction compaction)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(compaction?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setCompaction.(Lcom/google/zxing/pdf417/encoder/Compaction;)V", this, ptr);
			GC.KeepAlive(compaction);
		}

		[Register("setDimensions", "(IIII)V", "")]
		public unsafe void SetDimensions(int maxCols, int minCols, int maxRows, int minRows)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(maxCols);
			ptr[1] = new JniArgumentValue(minCols);
			ptr[2] = new JniArgumentValue(maxRows);
			ptr[3] = new JniArgumentValue(minRows);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setDimensions.(IIII)V", this, ptr);
		}

		[Register("setEncoding", "(Ljava/nio/charset/Charset;)V", "")]
		public unsafe void SetEncoding(Charset encoding)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(encoding?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setEncoding.(Ljava/nio/charset/Charset;)V", this, ptr);
			GC.KeepAlive(encoding);
		}
	}
	[Register("com/google/zxing/pdf417/encoder/PDF417ErrorCorrection", DoNotGenerateAcw = true)]
	public sealed class PDF417ErrorCorrection : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/encoder/PDF417ErrorCorrection", typeof(PDF417ErrorCorrection));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal PDF417ErrorCorrection(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/encoder/PDF417HighLevelEncoder", DoNotGenerateAcw = true)]
	public sealed class PDF417HighLevelEncoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/encoder/PDF417HighLevelEncoder", typeof(PDF417HighLevelEncoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal PDF417HighLevelEncoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
}
namespace Google.ZXing.PDF417.Detector
{
	[Register("com/google/zxing/pdf417/detector/Detector", DoNotGenerateAcw = true)]
	public sealed class Detector : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/detector/Detector", typeof(Detector));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Detector(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("detect", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;Z)Lcom/google/zxing/pdf417/detector/PDF417DetectorResult;", "")]
		public unsafe static PDF417DetectorResult Detect(BinaryBitmap image, IDictionary<DecodeHintType, object> hints, bool multiple)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			PDF417DetectorResult result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(multiple);
				result = Java.Lang.Object.GetObject<PDF417DetectorResult>(_members.StaticMethods.InvokeObjectMethod("detect.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;Z)Lcom/google/zxing/pdf417/detector/PDF417DetectorResult;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/pdf417/detector/PDF417DetectorResult", DoNotGenerateAcw = true)]
	public sealed class PDF417DetectorResult : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/detector/PDF417DetectorResult", typeof(PDF417DetectorResult));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe BitMatrix Bits
		{
			[Register("getBits", "()Lcom/google/zxing/common/BitMatrix;", "GetGetBitsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBits.()Lcom/google/zxing/common/BitMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<ResultPoint[]> Points
		{
			[Register("getPoints", "()Ljava/util/List;", "GetGetPointsHandler")]
			get
			{
				return JavaList<ResultPoint[]>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getPoints.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal PDF417DetectorResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;Ljava/util/List;)V", "")]
		public unsafe PDF417DetectorResult(BitMatrix bits, IList<ResultPoint[]> points)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaList<ResultPoint[]>.ToLocalJniHandle(points);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bits?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(bits);
				GC.KeepAlive(points);
			}
		}
	}
}
namespace Google.ZXing.PDF417.Decoder
{
	[Register("com/google/zxing/pdf417/decoder/BarcodeMetadata", DoNotGenerateAcw = true)]
	public sealed class BarcodeMetadata : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/BarcodeMetadata", typeof(BarcodeMetadata));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BarcodeMetadata(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/decoder/BarcodeValue", DoNotGenerateAcw = true)]
	public sealed class BarcodeValue : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/BarcodeValue", typeof(BarcodeValue));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BarcodeValue(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/decoder/BoundingBox", DoNotGenerateAcw = true)]
	public sealed class BoundingBox : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/BoundingBox", typeof(BoundingBox));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BoundingBox(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/decoder/Codeword", DoNotGenerateAcw = true)]
	public sealed class Codeword : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/Codeword", typeof(Codeword));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Codeword(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/decoder/DecodedBitStreamParser", DoNotGenerateAcw = true)]
	public sealed class DecodedBitStreamParser : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/DecodedBitStreamParser", typeof(DecodedBitStreamParser));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DecodedBitStreamParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/decoder/DetectionResult", DoNotGenerateAcw = true)]
	public sealed class DetectionResult : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/DetectionResult", typeof(DetectionResult));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DetectionResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/decoder/DetectionResultColumn", DoNotGenerateAcw = true)]
	public class DetectionResultColumn : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/DetectionResultColumn", typeof(DetectionResultColumn));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected DetectionResultColumn(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/decoder/DetectionResultRowIndicatorColumn", DoNotGenerateAcw = true)]
	public sealed class DetectionResultRowIndicatorColumn : DetectionResultColumn
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/DetectionResultRowIndicatorColumn", typeof(DetectionResultRowIndicatorColumn));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DetectionResultRowIndicatorColumn(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("toString", "()Ljava/lang/String;", "")]
		public unsafe override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/pdf417/decoder/PDF417CodewordDecoder", DoNotGenerateAcw = true)]
	public sealed class PDF417CodewordDecoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/PDF417CodewordDecoder", typeof(PDF417CodewordDecoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal PDF417CodewordDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/decoder/PDF417ScanningDecoder", DoNotGenerateAcw = true)]
	public sealed class PDF417ScanningDecoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/PDF417ScanningDecoder", typeof(PDF417ScanningDecoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal PDF417ScanningDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("decode", "(Lcom/google/zxing/common/BitMatrix;Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;II)Lcom/google/zxing/common/DecoderResult;", "")]
		public unsafe static DecoderResult Decode(BitMatrix image, ResultPoint imageTopLeft, ResultPoint imageBottomLeft, ResultPoint imageTopRight, ResultPoint imageBottomRight, int minCodewordWidth, int maxCodewordWidth)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(imageTopLeft?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(imageBottomLeft?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(imageTopRight?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(imageBottomRight?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(minCodewordWidth);
			ptr[6] = new JniArgumentValue(maxCodewordWidth);
			DecoderResult result = Java.Lang.Object.GetObject<DecoderResult>(_members.StaticMethods.InvokeObjectMethod("decode.(Lcom/google/zxing/common/BitMatrix;Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;Lcom/google/zxing/ResultPoint;II)Lcom/google/zxing/common/DecoderResult;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(image);
			GC.KeepAlive(imageTopLeft);
			GC.KeepAlive(imageBottomLeft);
			GC.KeepAlive(imageTopRight);
			GC.KeepAlive(imageBottomRight);
			return result;
		}
	}
}
namespace Google.ZXing.PDF417.Decoder.EC
{
	[Register("com/google/zxing/pdf417/decoder/ec/ErrorCorrection", DoNotGenerateAcw = true)]
	public sealed class ErrorCorrection : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/ec/ErrorCorrection", typeof(ErrorCorrection));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ErrorCorrection(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ErrorCorrection()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decode", "([II[I)I", "")]
		public unsafe int Decode(int[] received, int numECCodewords, int[] erasures)
		{
			IntPtr intPtr = JNIEnv.NewArray(received);
			IntPtr intPtr2 = JNIEnv.NewArray(erasures);
			int result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(numECCodewords);
				ptr[2] = new JniArgumentValue(intPtr2);
				result = _members.InstanceMethods.InvokeAbstractInt32Method("decode.([II[I)I", this, ptr);
			}
			finally
			{
				if (received != null)
				{
					JNIEnv.CopyArray(intPtr, received);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (erasures != null)
				{
					JNIEnv.CopyArray(intPtr2, erasures);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}
			GC.KeepAlive(received);
			GC.KeepAlive(erasures);
			return result;
		}
	}
	[Register("com/google/zxing/pdf417/decoder/ec/ModulusGF", DoNotGenerateAcw = true)]
	public sealed class ModulusGF : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/ec/ModulusGF", typeof(ModulusGF));

		[Register("PDF417_GF")]
		public static ModulusGF Pdf417Gf => Java.Lang.Object.GetObject<ModulusGF>(_members.StaticFields.GetObjectValue("PDF417_GF.Lcom/google/zxing/pdf417/decoder/ec/ModulusGF;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ModulusGF(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/pdf417/decoder/ec/ModulusPoly", DoNotGenerateAcw = true)]
	public sealed class ModulusPoly : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/decoder/ec/ModulusPoly", typeof(ModulusPoly));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ModulusPoly(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
}
namespace Google.ZXing.OneD
{
	[Register("com/google/zxing/oned/CodaBarReader", DoNotGenerateAcw = true)]
	public sealed class CodaBarReader : OneDReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/CodaBarReader", typeof(CodaBarReader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal CodaBarReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CodaBarReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe override Result DecodeRow(int rowNumber, BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(row);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/oned/CodaBarWriter", DoNotGenerateAcw = true)]
	public sealed class CodaBarWriter : OneDimensionalCodeWriter
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/CodaBarWriter", typeof(CodaBarWriter));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal CodaBarWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CodaBarWriter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "")]
		public unsafe override bool[] Encode(string contents)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/oned/Code128Reader", DoNotGenerateAcw = true)]
	public sealed class Code128Reader : OneDReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/Code128Reader", typeof(Code128Reader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Code128Reader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Code128Reader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe override Result DecodeRow(int rowNumber, BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(row);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/oned/Code128Writer", DoNotGenerateAcw = true)]
	public sealed class Code128Writer : OneDimensionalCodeWriter
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/Code128Writer", typeof(Code128Writer));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Code128Writer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Code128Writer()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "")]
		public unsafe override bool[] Encode(string contents)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/oned/Code39Reader", DoNotGenerateAcw = true)]
	public sealed class Code39Reader : OneDReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/Code39Reader", typeof(Code39Reader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Code39Reader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Code39Reader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Z)V", "")]
		public unsafe Code39Reader(bool usingCheckDigit)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(usingCheckDigit);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Z)V", this, ptr);
			}
		}

		[Register(".ctor", "(ZZ)V", "")]
		public unsafe Code39Reader(bool usingCheckDigit, bool extendedMode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(usingCheckDigit);
				ptr[1] = new JniArgumentValue(extendedMode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ZZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ZZ)V", this, ptr);
			}
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe override Result DecodeRow(int rowNumber, BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(row);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/oned/Code39Writer", DoNotGenerateAcw = true)]
	public sealed class Code39Writer : OneDimensionalCodeWriter
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/Code39Writer", typeof(Code39Writer));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Code39Writer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Code39Writer()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "")]
		public unsafe override bool[] Encode(string contents)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/oned/Code93Reader", DoNotGenerateAcw = true)]
	public sealed class Code93Reader : OneDReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/Code93Reader", typeof(Code93Reader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Code93Reader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Code93Reader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe override Result DecodeRow(int rowNumber, BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(row);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/oned/Code93Writer", DoNotGenerateAcw = true)]
	public class Code93Writer : OneDimensionalCodeWriter
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/Code93Writer", typeof(Code93Writer));

		private static Delegate cb_encode_Ljava_lang_String_;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Code93Writer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Code93Writer()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Obsolete("deprecated")]
		[Register("appendPattern", "([ZI[IZ)I", "")]
		protected new unsafe static int AppendPattern(bool[] target, int pos, int[] pattern, bool startColor)
		{
			IntPtr intPtr = JNIEnv.NewArray(target);
			IntPtr intPtr2 = JNIEnv.NewArray(pattern);
			int result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(pos);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue(startColor);
				result = _members.StaticMethods.InvokeInt32Method("appendPattern.([ZI[IZ)I", ptr);
			}
			finally
			{
				if (target != null)
				{
					JNIEnv.CopyArray(intPtr, target);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (pattern != null)
				{
					JNIEnv.CopyArray(intPtr2, pattern);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}
			GC.KeepAlive(target);
			GC.KeepAlive(pattern);
			return result;
		}

		private static Delegate GetEncode_Ljava_lang_String_Handler()
		{
			if ((object)cb_encode_Ljava_lang_String_ == null)
			{
				cb_encode_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_Encode_Ljava_lang_String_));
			}
			return cb_encode_Ljava_lang_String_;
		}

		private static IntPtr n_Encode_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_contents)
		{
			Code93Writer code93Writer = Java.Lang.Object.GetObject<Code93Writer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_contents, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(code93Writer.Encode(p));
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "GetEncode_Ljava_lang_String_Handler")]
		public unsafe override bool[] Encode(string contents)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("encode.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/oned/EAN13Reader", DoNotGenerateAcw = true)]
	public sealed class EAN13Reader : UPCEANReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/EAN13Reader", typeof(EAN13Reader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal EAN13Reader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EAN13Reader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decodeMiddle", "(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", "")]
		protected unsafe override int DecodeMiddle(BitArray row, int[] startRange, StringBuilder resultString)
		{
			IntPtr intPtr = JNIEnv.NewArray(startRange);
			int result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(resultString?.Handle ?? IntPtr.Zero);
				result = _members.InstanceMethods.InvokeAbstractInt32Method("decodeMiddle.(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", this, ptr);
			}
			finally
			{
				if (startRange != null)
				{
					JNIEnv.CopyArray(intPtr, startRange);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(row);
			GC.KeepAlive(startRange);
			GC.KeepAlive(resultString);
			return result;
		}
	}
	[Register("com/google/zxing/oned/EAN13Writer", DoNotGenerateAcw = true)]
	public sealed class EAN13Writer : UPCEANWriter
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/EAN13Writer", typeof(EAN13Writer));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal EAN13Writer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EAN13Writer()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "")]
		public unsafe override bool[] Encode(string contents)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/oned/EAN8Reader", DoNotGenerateAcw = true)]
	public sealed class EAN8Reader : UPCEANReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/EAN8Reader", typeof(EAN8Reader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal EAN8Reader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EAN8Reader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decodeMiddle", "(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", "")]
		protected unsafe override int DecodeMiddle(BitArray row, int[] startRange, StringBuilder result)
		{
			IntPtr intPtr = JNIEnv.NewArray(startRange);
			int result2;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				result2 = _members.InstanceMethods.InvokeAbstractInt32Method("decodeMiddle.(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", this, ptr);
			}
			finally
			{
				if (startRange != null)
				{
					JNIEnv.CopyArray(intPtr, startRange);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(row);
			GC.KeepAlive(startRange);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/oned/EAN8Writer", DoNotGenerateAcw = true)]
	public sealed class EAN8Writer : UPCEANWriter
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/EAN8Writer", typeof(EAN8Writer));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal EAN8Writer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EAN8Writer()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "")]
		public unsafe override bool[] Encode(string contents)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/oned/EANManufacturerOrgSupport", DoNotGenerateAcw = true)]
	public sealed class EANManufacturerOrgSupport : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/EANManufacturerOrgSupport", typeof(EANManufacturerOrgSupport));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal EANManufacturerOrgSupport(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/ITFReader", DoNotGenerateAcw = true)]
	public sealed class ITFReader : OneDReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/ITFReader", typeof(ITFReader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ITFReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ITFReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe override Result DecodeRow(int rowNumber, BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(row);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/oned/ITFWriter", DoNotGenerateAcw = true)]
	public sealed class ITFWriter : OneDimensionalCodeWriter
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/ITFWriter", typeof(ITFWriter));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ITFWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ITFWriter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "")]
		public unsafe override bool[] Encode(string contents)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/oned/MultiFormatOneDReader", DoNotGenerateAcw = true)]
	public sealed class MultiFormatOneDReader : OneDReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/MultiFormatOneDReader", typeof(MultiFormatOneDReader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MultiFormatOneDReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/Map;)V", "")]
		public unsafe MultiFormatOneDReader(IDictionary<DecodeHintType, object> hints)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/Map;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/Map;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(hints);
			}
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe override Result DecodeRow(int rowNumber, BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(row);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/oned/MultiFormatUPCEANReader", DoNotGenerateAcw = true)]
	public sealed class MultiFormatUPCEANReader : OneDReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/MultiFormatUPCEANReader", typeof(MultiFormatUPCEANReader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MultiFormatUPCEANReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/Map;)V", "")]
		public unsafe MultiFormatUPCEANReader(IDictionary<DecodeHintType, object> hints)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/Map;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/Map;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(hints);
			}
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe override Result DecodeRow(int rowNumber, BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(row);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/oned/OneDimensionalCodeWriter", DoNotGenerateAcw = true)]
	public abstract class OneDimensionalCodeWriter : Java.Lang.Object, IWriter, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/OneDimensionalCodeWriter", typeof(OneDimensionalCodeWriter));

		private static Delegate cb_getDefaultMargin;

		private static Delegate cb_encode_Ljava_lang_String_;

		private static Delegate cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int DefaultMargin
		{
			[Register("getDefaultMargin", "()I", "GetGetDefaultMarginHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDefaultMargin.()I", this, null);
			}
		}

		protected OneDimensionalCodeWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OneDimensionalCodeWriter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetDefaultMarginHandler()
		{
			if ((object)cb_getDefaultMargin == null)
			{
				cb_getDefaultMargin = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetDefaultMargin));
			}
			return cb_getDefaultMargin;
		}

		private static int n_GetDefaultMargin(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<OneDimensionalCodeWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultMargin;
		}

		[Register("appendPattern", "([ZI[IZ)I", "")]
		protected unsafe static int AppendPattern(bool[] target, int pos, int[] pattern, bool startColor)
		{
			IntPtr intPtr = JNIEnv.NewArray(target);
			IntPtr intPtr2 = JNIEnv.NewArray(pattern);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(pos);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue(startColor);
				return _members.StaticMethods.InvokeInt32Method("appendPattern.([ZI[IZ)I", ptr);
			}
			finally
			{
				if (target != null)
				{
					JNIEnv.CopyArray(intPtr, target);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (pattern != null)
				{
					JNIEnv.CopyArray(intPtr2, pattern);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}
		}

		private static Delegate GetEncode_Ljava_lang_String_Handler()
		{
			if ((object)cb_encode_Ljava_lang_String_ == null)
			{
				cb_encode_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_Encode_Ljava_lang_String_));
			}
			return cb_encode_Ljava_lang_String_;
		}

		private static IntPtr n_Encode_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			OneDimensionalCodeWriter oneDimensionalCodeWriter = Java.Lang.Object.GetObject<OneDimensionalCodeWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(oneDimensionalCodeWriter.Encode(p));
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "GetEncode_Ljava_lang_String_Handler")]
		public abstract bool[] Encode(string p0);

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetEncode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_Handler()
		{
			if ((object)cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_ == null)
			{
				cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, int, int, IntPtr, IntPtr>(n_Encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_));
			}
			return cb_encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_;
		}

		private static IntPtr n_Encode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_(IntPtr jnienv, IntPtr native__this, IntPtr native_contents, IntPtr native_format, int width, int height, IntPtr native_hints)
		{
			OneDimensionalCodeWriter oneDimensionalCodeWriter = Java.Lang.Object.GetObject<OneDimensionalCodeWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string contents = JNIEnv.GetString(native_contents, JniHandleOwnership.DoNotTransfer);
			BarcodeFormat format = Java.Lang.Object.GetObject<BarcodeFormat>(native_format, JniHandleOwnership.DoNotTransfer);
			IDictionary<EncodeHintType, object> hints = JavaDictionary<EncodeHintType, object>.FromJniHandle(native_hints, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oneDimensionalCodeWriter.Encode(contents, format, width, height, hints));
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", "GetEncode_Ljava_lang_String_Lcom_google_zxing_BarcodeFormat_IILjava_util_Map_Handler")]
		public unsafe virtual BitMatrix Encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			IntPtr intPtr2 = JavaDictionary<EncodeHintType, object>.ToLocalJniHandle(hints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				ptr[4] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeVirtualObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}
	}
	[Register("com/google/zxing/oned/OneDimensionalCodeWriter", DoNotGenerateAcw = true)]
	internal class OneDimensionalCodeWriterInvoker : OneDimensionalCodeWriter
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/oned/OneDimensionalCodeWriter", typeof(OneDimensionalCodeWriterInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public OneDimensionalCodeWriterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "GetEncode_Ljava_lang_String_Handler")]
		public unsafe override bool[] Encode(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/oned/OneDReader", DoNotGenerateAcw = true)]
	public abstract class OneDReader : Java.Lang.Object, IReader, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/OneDReader", typeof(OneDReader));

		private static Delegate cb_decode_Lcom_google_zxing_BinaryBitmap_;

		private static Delegate cb_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_;

		private static Delegate cb_decodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_;

		private static Delegate cb_reset;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OneDReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OneDReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetDecode_Lcom_google_zxing_BinaryBitmap_Handler()
		{
			if ((object)cb_decode_Lcom_google_zxing_BinaryBitmap_ == null)
			{
				cb_decode_Lcom_google_zxing_BinaryBitmap_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_Decode_Lcom_google_zxing_BinaryBitmap_));
			}
			return cb_decode_Lcom_google_zxing_BinaryBitmap_;
		}

		private static IntPtr n_Decode_Lcom_google_zxing_BinaryBitmap_(IntPtr jnienv, IntPtr native__this, IntPtr native_image)
		{
			OneDReader oneDReader = Java.Lang.Object.GetObject<OneDReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BinaryBitmap image = Java.Lang.Object.GetObject<BinaryBitmap>(native_image, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oneDReader.Decode(image));
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", "GetDecode_Lcom_google_zxing_BinaryBitmap_Handler")]
		public unsafe virtual Result Decode(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeVirtualObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetDecode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_Handler()
		{
			if ((object)cb_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_ == null)
			{
				cb_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_Decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_));
			}
			return cb_decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_;
		}

		private static IntPtr n_Decode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_(IntPtr jnienv, IntPtr native__this, IntPtr native_image, IntPtr native_hints)
		{
			OneDReader oneDReader = Java.Lang.Object.GetObject<OneDReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BinaryBitmap image = Java.Lang.Object.GetObject<BinaryBitmap>(native_image, JniHandleOwnership.DoNotTransfer);
			IDictionary<DecodeHintType, object> hints = JavaDictionary<DecodeHintType, object>.FromJniHandle(native_hints, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oneDReader.Decode(image, hints));
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", "GetDecode_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_Handler")]
		public unsafe virtual Result Decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeVirtualObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetDecodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_Handler()
		{
			if ((object)cb_decodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_ == null)
			{
				cb_decodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr>(n_DecodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_));
			}
			return cb_decodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_;
		}

		private static IntPtr n_DecodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
		{
			OneDReader oneDReader = Java.Lang.Object.GetObject<OneDReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BitArray p1 = Java.Lang.Object.GetObject<BitArray>(native_p1, JniHandleOwnership.DoNotTransfer);
			IDictionary<DecodeHintType, object> p2 = JavaDictionary<DecodeHintType, object>.FromJniHandle(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oneDReader.DecodeRow(p0, p1, p2));
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "GetDecodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_Handler")]
		public abstract Result DecodeRow(int p0, BitArray p1, IDictionary<DecodeHintType, object> p2);

		[Register("patternMatchVariance", "([I[IF)F", "")]
		protected unsafe static float PatternMatchVariance(int[] counters, int[] pattern, float maxIndividualVariance)
		{
			IntPtr intPtr = JNIEnv.NewArray(counters);
			IntPtr intPtr2 = JNIEnv.NewArray(pattern);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(maxIndividualVariance);
				return _members.StaticMethods.InvokeSingleMethod("patternMatchVariance.([I[IF)F", ptr);
			}
			finally
			{
				if (counters != null)
				{
					JNIEnv.CopyArray(intPtr, counters);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (pattern != null)
				{
					JNIEnv.CopyArray(intPtr2, pattern);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}
		}

		[Register("recordPattern", "(Lcom/google/zxing/common/BitArray;I[I)V", "")]
		protected unsafe static void RecordPattern(BitArray row, int start, int[] counters)
		{
			IntPtr intPtr = JNIEnv.NewArray(counters);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(start);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("recordPattern.(Lcom/google/zxing/common/BitArray;I[I)V", ptr);
			}
			finally
			{
				if (counters != null)
				{
					JNIEnv.CopyArray(intPtr, counters);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("recordPatternInReverse", "(Lcom/google/zxing/common/BitArray;I[I)V", "")]
		protected unsafe static void RecordPatternInReverse(BitArray row, int start, int[] counters)
		{
			IntPtr intPtr = JNIEnv.NewArray(counters);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(start);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("recordPatternInReverse.(Lcom/google/zxing/common/BitArray;I[I)V", ptr);
			}
			finally
			{
				if (counters != null)
				{
					JNIEnv.CopyArray(intPtr, counters);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static Delegate GetResetHandler()
		{
			if ((object)cb_reset == null)
			{
				cb_reset = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Reset));
			}
			return cb_reset;
		}

		private static void n_Reset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<OneDReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}

		[Register("reset", "()V", "GetResetHandler")]
		public unsafe virtual void Reset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
		}
	}
	[Register("com/google/zxing/oned/OneDReader", DoNotGenerateAcw = true)]
	internal class OneDReaderInvoker : OneDReader
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/oned/OneDReader", typeof(OneDReaderInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public OneDReaderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "GetDecodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_Handler")]
		public unsafe override Result DecodeRow(int p0, BitArray p1, IDictionary<DecodeHintType, object> p2)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(p2);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
			return result;
		}
	}
	[Register("com/google/zxing/oned/UPCAReader", DoNotGenerateAcw = true)]
	public sealed class UPCAReader : UPCEANReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/UPCAReader", typeof(UPCAReader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal UPCAReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UPCAReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decodeMiddle", "(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", "")]
		protected unsafe override int DecodeMiddle(BitArray row, int[] startRange, StringBuilder resultString)
		{
			IntPtr intPtr = JNIEnv.NewArray(startRange);
			int result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(resultString?.Handle ?? IntPtr.Zero);
				result = _members.InstanceMethods.InvokeAbstractInt32Method("decodeMiddle.(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", this, ptr);
			}
			finally
			{
				if (startRange != null)
				{
					JNIEnv.CopyArray(intPtr, startRange);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(row);
			GC.KeepAlive(startRange);
			GC.KeepAlive(resultString);
			return result;
		}
	}
	[Register("com/google/zxing/oned/UPCAWriter", DoNotGenerateAcw = true)]
	public sealed class UPCAWriter : Java.Lang.Object, IWriter, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/UPCAWriter", typeof(UPCAWriter));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal UPCAWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UPCAWriter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(format);
			return result;
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			IntPtr intPtr2 = JavaDictionary<EncodeHintType, object>.ToLocalJniHandle(hints);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				ptr[4] = new JniArgumentValue(intPtr2);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(format);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/oned/UPCEANExtension2Support", DoNotGenerateAcw = true)]
	public sealed class UPCEANExtension2Support : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/UPCEANExtension2Support", typeof(UPCEANExtension2Support));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal UPCEANExtension2Support(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/UPCEANExtension5Support", DoNotGenerateAcw = true)]
	public sealed class UPCEANExtension5Support : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/UPCEANExtension5Support", typeof(UPCEANExtension5Support));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal UPCEANExtension5Support(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/UPCEANExtensionSupport", DoNotGenerateAcw = true)]
	public sealed class UPCEANExtensionSupport : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/UPCEANExtensionSupport", typeof(UPCEANExtensionSupport));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal UPCEANExtensionSupport(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/UPCEANReader", DoNotGenerateAcw = true)]
	public abstract class UPCEANReader : OneDReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/UPCEANReader", typeof(UPCEANReader));

		private static Delegate cb_decodeMiddle_Lcom_google_zxing_common_BitArray_arrayILjava_lang_StringBuilder_;

		private static Delegate cb_decodeRow_ILcom_google_zxing_common_BitArray_arrayILjava_util_Map_;

		private static Delegate cb_decodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected UPCEANReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		protected unsafe UPCEANReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetDecodeMiddle_Lcom_google_zxing_common_BitArray_arrayILjava_lang_StringBuilder_Handler()
		{
			if ((object)cb_decodeMiddle_Lcom_google_zxing_common_BitArray_arrayILjava_lang_StringBuilder_ == null)
			{
				cb_decodeMiddle_Lcom_google_zxing_common_BitArray_arrayILjava_lang_StringBuilder_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int>(n_DecodeMiddle_Lcom_google_zxing_common_BitArray_arrayILjava_lang_StringBuilder_));
			}
			return cb_decodeMiddle_Lcom_google_zxing_common_BitArray_arrayILjava_lang_StringBuilder_;
		}

		private static int n_DecodeMiddle_Lcom_google_zxing_common_BitArray_arrayILjava_lang_StringBuilder_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			UPCEANReader uPCEANReader = Java.Lang.Object.GetObject<UPCEANReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BitArray p = Java.Lang.Object.GetObject<BitArray>(native_p0, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(int));
			StringBuilder p2 = Java.Lang.Object.GetObject<StringBuilder>(native_p2, JniHandleOwnership.DoNotTransfer);
			int result = uPCEANReader.DecodeMiddle(p, array, p2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
			return result;
		}

		[Register("decodeMiddle", "(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", "GetDecodeMiddle_Lcom_google_zxing_common_BitArray_arrayILjava_lang_StringBuilder_Handler")]
		protected abstract int DecodeMiddle(BitArray p0, int[] p1, StringBuilder p2);

		private static Delegate GetDecodeRow_ILcom_google_zxing_common_BitArray_arrayILjava_util_Map_Handler()
		{
			if ((object)cb_decodeRow_ILcom_google_zxing_common_BitArray_arrayILjava_util_Map_ == null)
			{
				cb_decodeRow_ILcom_google_zxing_common_BitArray_arrayILjava_util_Map_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr>(n_DecodeRow_ILcom_google_zxing_common_BitArray_arrayILjava_util_Map_));
			}
			return cb_decodeRow_ILcom_google_zxing_common_BitArray_arrayILjava_util_Map_;
		}

		private static IntPtr n_DecodeRow_ILcom_google_zxing_common_BitArray_arrayILjava_util_Map_(IntPtr jnienv, IntPtr native__this, int rowNumber, IntPtr native_row, IntPtr native_startGuardRange, IntPtr native_hints)
		{
			UPCEANReader uPCEANReader = Java.Lang.Object.GetObject<UPCEANReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BitArray row = Java.Lang.Object.GetObject<BitArray>(native_row, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_startGuardRange, JniHandleOwnership.DoNotTransfer, typeof(int));
			IDictionary<DecodeHintType, object> hints = JavaDictionary<DecodeHintType, object>.FromJniHandle(native_hints, JniHandleOwnership.DoNotTransfer);
			IntPtr result = JNIEnv.ToLocalJniHandle(uPCEANReader.DecodeRow(rowNumber, row, array, hints));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_startGuardRange);
			}
			return result;
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;[ILjava/util/Map;)Lcom/google/zxing/Result;", "GetDecodeRow_ILcom_google_zxing_common_BitArray_arrayILjava_util_Map_Handler")]
		public unsafe virtual Result DecodeRow(int rowNumber, BitArray row, int[] startGuardRange, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewArray(startGuardRange);
			IntPtr intPtr2 = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeVirtualObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;[ILjava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (startGuardRange != null)
				{
					JNIEnv.CopyArray(intPtr, startGuardRange);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		private static Delegate GetDecodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_Handler()
		{
			if ((object)cb_decodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_ == null)
			{
				cb_decodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr>(n_DecodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_));
			}
			return cb_decodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_;
		}

		private static IntPtr n_DecodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_(IntPtr jnienv, IntPtr native__this, int rowNumber, IntPtr native_row, IntPtr native_hints)
		{
			UPCEANReader uPCEANReader = Java.Lang.Object.GetObject<UPCEANReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BitArray p = Java.Lang.Object.GetObject<BitArray>(native_row, JniHandleOwnership.DoNotTransfer);
			IDictionary<DecodeHintType, object> p2 = JavaDictionary<DecodeHintType, object>.FromJniHandle(native_hints, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(uPCEANReader.DecodeRow(rowNumber, p, p2));
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "GetDecodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_Handler")]
		public unsafe override Result DecodeRow(int rowNumber, BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeVirtualObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/oned/UPCEANReader", DoNotGenerateAcw = true)]
	internal class UPCEANReaderInvoker : UPCEANReader
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/oned/UPCEANReader", typeof(UPCEANReaderInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public UPCEANReaderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("decodeMiddle", "(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", "GetDecodeMiddle_Lcom_google_zxing_common_BitArray_arrayILjava_lang_StringBuilder_Handler")]
		protected unsafe override int DecodeMiddle(BitArray p0, int[] p1, StringBuilder p2)
		{
			IntPtr intPtr = JNIEnv.NewArray(p1);
			int result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				result = _members.InstanceMethods.InvokeAbstractInt32Method("decodeMiddle.(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", this, ptr);
			}
			finally
			{
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr, p1);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
			return result;
		}
	}
	[Register("com/google/zxing/oned/UPCEANWriter", DoNotGenerateAcw = true)]
	public abstract class UPCEANWriter : OneDimensionalCodeWriter
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/UPCEANWriter", typeof(UPCEANWriter));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected UPCEANWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UPCEANWriter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/google/zxing/oned/UPCEANWriter", DoNotGenerateAcw = true)]
	internal class UPCEANWriterInvoker : UPCEANWriter
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/oned/UPCEANWriter", typeof(UPCEANWriterInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public UPCEANWriterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "GetEncode_Ljava_lang_String_Handler")]
		public unsafe override bool[] Encode(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/oned/UPCEReader", DoNotGenerateAcw = true)]
	public sealed class UPCEReader : UPCEANReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/UPCEReader", typeof(UPCEReader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal UPCEReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UPCEReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("checkChecksum", "(Ljava/lang/String;)Z", "")]
		protected unsafe bool CheckChecksum(string s)
		{
			IntPtr intPtr = JNIEnv.NewString(s);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("checkChecksum.(Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("convertUPCEtoUPCA", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe static string ConvertUPCEtoUPCA(string upce)
		{
			IntPtr intPtr = JNIEnv.NewString(upce);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("convertUPCEtoUPCA.(Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("decodeEnd", "(Lcom/google/zxing/common/BitArray;I)[I", "")]
		protected unsafe int[] DecodeEnd(BitArray row, int endStart)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(endStart);
			int[] result = (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeEnd.(Lcom/google/zxing/common/BitArray;I)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
			GC.KeepAlive(row);
			return result;
		}

		[Register("decodeMiddle", "(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", "")]
		protected unsafe override int DecodeMiddle(BitArray row, int[] startRange, StringBuilder result)
		{
			IntPtr intPtr = JNIEnv.NewArray(startRange);
			int result2;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				result2 = _members.InstanceMethods.InvokeAbstractInt32Method("decodeMiddle.(Lcom/google/zxing/common/BitArray;[ILjava/lang/StringBuilder;)I", this, ptr);
			}
			finally
			{
				if (startRange != null)
				{
					JNIEnv.CopyArray(intPtr, startRange);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(row);
			GC.KeepAlive(startRange);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/oned/UPCEWriter", DoNotGenerateAcw = true)]
	public sealed class UPCEWriter : UPCEANWriter
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/UPCEWriter", typeof(UPCEWriter));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal UPCEWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UPCEWriter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;)[Z", "")]
		public unsafe override bool[] Encode(string contents)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
}
namespace Google.ZXing.OneD.RSS
{
	[Register("com/google/zxing/oned/rss/AbstractRSSReader", DoNotGenerateAcw = true)]
	public abstract class AbstractRSSReader : OneDReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/AbstractRSSReader", typeof(AbstractRSSReader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected AbstractRSSReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		protected unsafe AbstractRSSReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Obsolete("deprecated")]
		[Register("count", "([I)I", "")]
		protected unsafe static int Count(int[] array)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeInt32Method("count.([I)I", ptr);
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("decrement", "([I[F)V", "")]
		protected unsafe static void Decrement(int[] array, float[] errors)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			IntPtr intPtr2 = JNIEnv.NewArray(errors);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("decrement.([I[F)V", ptr);
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (errors != null)
				{
					JNIEnv.CopyArray(intPtr2, errors);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}
		}

		[Register("getDataCharacterCounters", "()[I", "")]
		protected unsafe int[] GetDataCharacterCounters()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDataCharacterCounters.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		[Register("getDecodeFinderCounters", "()[I", "")]
		protected unsafe int[] GetDecodeFinderCounters()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDecodeFinderCounters.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		[Register("getEvenCounts", "()[I", "")]
		protected unsafe int[] GetEvenCounts()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getEvenCounts.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		[Register("getEvenRoundingErrors", "()[F", "")]
		protected unsafe float[] GetEvenRoundingErrors()
		{
			return (float[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getEvenRoundingErrors.()[F", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(float));
		}

		[Register("getOddCounts", "()[I", "")]
		protected unsafe int[] GetOddCounts()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOddCounts.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		[Register("getOddRoundingErrors", "()[F", "")]
		protected unsafe float[] GetOddRoundingErrors()
		{
			return (float[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOddRoundingErrors.()[F", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(float));
		}

		[Register("increment", "([I[F)V", "")]
		protected unsafe static void Increment(int[] array, float[] errors)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			IntPtr intPtr2 = JNIEnv.NewArray(errors);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("increment.([I[F)V", ptr);
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (errors != null)
				{
					JNIEnv.CopyArray(intPtr2, errors);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}
		}

		[Register("isFinderPattern", "([I)Z", "")]
		protected unsafe static bool IsFinderPattern(int[] counters)
		{
			IntPtr intPtr = JNIEnv.NewArray(counters);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeBooleanMethod("isFinderPattern.([I)Z", ptr);
			}
			finally
			{
				if (counters != null)
				{
					JNIEnv.CopyArray(intPtr, counters);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("parseFinderValue", "([I[[I)I", "")]
		protected unsafe static int ParseFinderValue(int[] counters, int[][] finderPatterns)
		{
			IntPtr intPtr = JNIEnv.NewArray(counters);
			IntPtr intPtr2 = JNIEnv.NewArray(finderPatterns);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return _members.StaticMethods.InvokeInt32Method("parseFinderValue.([I[[I)I", ptr);
			}
			finally
			{
				if (counters != null)
				{
					JNIEnv.CopyArray(intPtr, counters);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (finderPatterns != null)
				{
					JNIEnv.CopyArray(intPtr2, finderPatterns);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}
		}
	}
	[Register("com/google/zxing/oned/rss/AbstractRSSReader", DoNotGenerateAcw = true)]
	internal class AbstractRSSReaderInvoker : AbstractRSSReader
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/oned/rss/AbstractRSSReader", typeof(AbstractRSSReaderInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public AbstractRSSReaderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "GetDecodeRow_ILcom_google_zxing_common_BitArray_Ljava_util_Map_Handler")]
		public unsafe override Result DecodeRow(int p0, BitArray p1, IDictionary<DecodeHintType, object> p2)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(p2);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
			return result;
		}
	}
	[Register("com/google/zxing/oned/rss/DataCharacter", DoNotGenerateAcw = true)]
	public class DataCharacter : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/DataCharacter", typeof(DataCharacter));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int ChecksumPortion
		{
			[Register("getChecksumPortion", "()I", "GetGetChecksumPortionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getChecksumPortion.()I", this, null);
			}
		}

		public unsafe int Value
		{
			[Register("getValue", "()I", "GetGetValueHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getValue.()I", this, null);
			}
		}

		protected DataCharacter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe DataCharacter(int value, int checksumPortion)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(value);
				ptr[1] = new JniArgumentValue(checksumPortion);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}

		[Register("equals", "(Ljava/lang/Object;)Z", "")]
		public unsafe sealed override bool Equals(Java.Lang.Object o)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			bool result = _members.InstanceMethods.InvokeNonvirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
			GC.KeepAlive(o);
			return result;
		}

		[Register("hashCode", "()I", "")]
		public unsafe sealed override int GetHashCode()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("hashCode.()I", this, null);
		}

		[Register("toString", "()Ljava/lang/String;", "")]
		public unsafe sealed override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/oned/rss/FinderPattern", DoNotGenerateAcw = true)]
	public sealed class FinderPattern : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/FinderPattern", typeof(FinderPattern));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Value
		{
			[Register("getValue", "()I", "GetGetValueHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getValue.()I", this, null);
			}
		}

		internal FinderPattern(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(I[IIII)V", "")]
		public unsafe FinderPattern(int value, int[] startEnd, int start, int end, int rowNumber)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(startEnd);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(value);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(start);
				ptr[3] = new JniArgumentValue(end);
				ptr[4] = new JniArgumentValue(rowNumber);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I[IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I[IIII)V", this, ptr);
			}
			finally
			{
				if (startEnd != null)
				{
					JNIEnv.CopyArray(intPtr, startEnd);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(startEnd);
				}
			}
		}

		[Register("getResultPoints", "()[Lcom/google/zxing/ResultPoint;", "")]
		public unsafe ResultPoint[] GetResultPoints()
		{
			return (ResultPoint[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getResultPoints.()[Lcom/google/zxing/ResultPoint;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ResultPoint));
		}

		[Register("getStartEnd", "()[I", "")]
		public unsafe int[] GetStartEnd()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getStartEnd.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}
	}
	[Register("com/google/zxing/oned/rss/Pair", DoNotGenerateAcw = true)]
	public sealed class Pair : DataCharacter
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/Pair", typeof(Pair));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Pair(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/RSS14Reader", DoNotGenerateAcw = true)]
	public sealed class RSS14Reader : AbstractRSSReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/RSS14Reader", typeof(RSS14Reader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal RSS14Reader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe RSS14Reader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe override Result DecodeRow(int rowNumber, BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(row);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/oned/rss/RSSUtils", DoNotGenerateAcw = true)]
	public sealed class RSSUtils : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/RSSUtils", typeof(RSSUtils));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal RSSUtils(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getRSSvalue", "([IIZ)I", "")]
		public unsafe static int GetRSSvalue(int[] widths, int maxWidth, bool noNarrow)
		{
			IntPtr intPtr = JNIEnv.NewArray(widths);
			int result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(maxWidth);
				ptr[2] = new JniArgumentValue(noNarrow);
				result = _members.StaticMethods.InvokeInt32Method("getRSSvalue.([IIZ)I", ptr);
			}
			finally
			{
				if (widths != null)
				{
					JNIEnv.CopyArray(intPtr, widths);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(widths);
			return result;
		}
	}
}
namespace Google.ZXing.OneD.RSS.Expanded
{
	[Register("com/google/zxing/oned/rss/expanded/BitArrayBuilder", DoNotGenerateAcw = true)]
	public sealed class BitArrayBuilder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/BitArrayBuilder", typeof(BitArrayBuilder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BitArrayBuilder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/ExpandedPair", DoNotGenerateAcw = true)]
	public sealed class ExpandedPair : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/ExpandedPair", typeof(ExpandedPair));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ExpandedPair(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("mustBeLast", "()Z", "")]
		public unsafe bool MustBeLast()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("mustBeLast.()Z", this, null);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/ExpandedRow", DoNotGenerateAcw = true)]
	public sealed class ExpandedRow : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/ExpandedRow", typeof(ExpandedRow));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ExpandedRow(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/RSSExpandedReader", DoNotGenerateAcw = true)]
	public sealed class RSSExpandedReader : AbstractRSSReader
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/RSSExpandedReader", typeof(RSSExpandedReader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal RSSExpandedReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe RSSExpandedReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decodeRow", "(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe override Result DecodeRow(int rowNumber, BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(rowNumber);
				ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeRow.(ILcom/google/zxing/common/BitArray;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(row);
			GC.KeepAlive(hints);
			return result;
		}
	}
}
namespace Google.ZXing.OneD.RSS.Expanded.Decoders
{
	[Register("com/google/zxing/oned/rss/expanded/decoders/AbstractExpandedDecoder", DoNotGenerateAcw = true)]
	public abstract class AbstractExpandedDecoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AbstractExpandedDecoder", typeof(AbstractExpandedDecoder));

		private static Delegate cb_parseInformation;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected unsafe GeneralAppIdDecoder GeneralDecoder
		{
			[Register("getGeneralDecoder", "()Lcom/google/zxing/oned/rss/expanded/decoders/GeneralAppIdDecoder;", "GetGetGeneralDecoderHandler")]
			get
			{
				return Java.Lang.Object.GetObject<GeneralAppIdDecoder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getGeneralDecoder.()Lcom/google/zxing/oned/rss/expanded/decoders/GeneralAppIdDecoder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe BitArray Information
		{
			[Register("getInformation", "()Lcom/google/zxing/common/BitArray;", "GetGetInformationHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BitArray>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getInformation.()Lcom/google/zxing/common/BitArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected AbstractExpandedDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("createDecoder", "(Lcom/google/zxing/common/BitArray;)Lcom/google/zxing/oned/rss/expanded/decoders/AbstractExpandedDecoder;", "")]
		public unsafe static AbstractExpandedDecoder CreateDecoder(BitArray information)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(information?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AbstractExpandedDecoder>(_members.StaticMethods.InvokeObjectMethod("createDecoder.(Lcom/google/zxing/common/BitArray;)Lcom/google/zxing/oned/rss/expanded/decoders/AbstractExpandedDecoder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetParseInformationHandler()
		{
			if ((object)cb_parseInformation == null)
			{
				cb_parseInformation = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_ParseInformation));
			}
			return cb_parseInformation;
		}

		private static IntPtr n_ParseInformation(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AbstractExpandedDecoder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParseInformation());
		}

		[Register("parseInformation", "()Ljava/lang/String;", "GetParseInformationHandler")]
		public abstract string ParseInformation();
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AbstractExpandedDecoder", DoNotGenerateAcw = true)]
	internal class AbstractExpandedDecoderInvoker : AbstractExpandedDecoder
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AbstractExpandedDecoder", typeof(AbstractExpandedDecoderInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public AbstractExpandedDecoderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("parseInformation", "()Ljava/lang/String;", "GetParseInformationHandler")]
		public unsafe override string ParseInformation()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("parseInformation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI013103decoder", DoNotGenerateAcw = true)]
	public sealed class AI013103decoder : AI013x0xDecoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI013103decoder", typeof(AI013103decoder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AI013103decoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("addWeightCode", "(Ljava/lang/StringBuilder;I)V", "")]
		protected unsafe override void AddWeightCode(StringBuilder buf, int weight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(buf?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(weight);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addWeightCode.(Ljava/lang/StringBuilder;I)V", this, ptr);
			GC.KeepAlive(buf);
		}

		[Register("checkWeight", "(I)I", "")]
		protected unsafe override int CheckWeight(int weight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(weight);
			return _members.InstanceMethods.InvokeAbstractInt32Method("checkWeight.(I)I", this, ptr);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI01320xDecoder", DoNotGenerateAcw = true)]
	public sealed class AI01320xDecoder : AI013x0xDecoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI01320xDecoder", typeof(AI01320xDecoder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AI01320xDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("addWeightCode", "(Ljava/lang/StringBuilder;I)V", "")]
		protected unsafe override void AddWeightCode(StringBuilder buf, int weight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(buf?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(weight);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addWeightCode.(Ljava/lang/StringBuilder;I)V", this, ptr);
			GC.KeepAlive(buf);
		}

		[Register("checkWeight", "(I)I", "")]
		protected unsafe override int CheckWeight(int weight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(weight);
			return _members.InstanceMethods.InvokeAbstractInt32Method("checkWeight.(I)I", this, ptr);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI01392xDecoder", DoNotGenerateAcw = true)]
	public sealed class AI01392xDecoder : AI01decoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI01392xDecoder", typeof(AI01392xDecoder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AI01392xDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("parseInformation", "()Ljava/lang/String;", "")]
		public unsafe override string ParseInformation()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("parseInformation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI01393xDecoder", DoNotGenerateAcw = true)]
	public sealed class AI01393xDecoder : AI01decoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI01393xDecoder", typeof(AI01393xDecoder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AI01393xDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("parseInformation", "()Ljava/lang/String;", "")]
		public unsafe override string ParseInformation()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("parseInformation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI013x0x1xDecoder", DoNotGenerateAcw = true)]
	public sealed class AI013x0x1xDecoder : AI01weightDecoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI013x0x1xDecoder", typeof(AI013x0x1xDecoder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AI013x0x1xDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("addWeightCode", "(Ljava/lang/StringBuilder;I)V", "")]
		protected unsafe override void AddWeightCode(StringBuilder buf, int weight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(buf?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(weight);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addWeightCode.(Ljava/lang/StringBuilder;I)V", this, ptr);
			GC.KeepAlive(buf);
		}

		[Register("checkWeight", "(I)I", "")]
		protected unsafe override int CheckWeight(int weight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(weight);
			return _members.InstanceMethods.InvokeAbstractInt32Method("checkWeight.(I)I", this, ptr);
		}

		[Register("parseInformation", "()Ljava/lang/String;", "")]
		public unsafe override string ParseInformation()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("parseInformation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI013x0xDecoder", DoNotGenerateAcw = true)]
	public abstract class AI013x0xDecoder : AI01weightDecoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI013x0xDecoder", typeof(AI013x0xDecoder));

		private static Delegate cb_parseInformation;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected AI013x0xDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetParseInformationHandler()
		{
			if ((object)cb_parseInformation == null)
			{
				cb_parseInformation = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_ParseInformation));
			}
			return cb_parseInformation;
		}

		private static IntPtr n_ParseInformation(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AI013x0xDecoder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParseInformation());
		}

		[Register("parseInformation", "()Ljava/lang/String;", "GetParseInformationHandler")]
		public unsafe override string ParseInformation()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("parseInformation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI013x0xDecoder", DoNotGenerateAcw = true)]
	internal class AI013x0xDecoderInvoker : AI013x0xDecoder
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI013x0xDecoder", typeof(AI013x0xDecoderInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public AI013x0xDecoderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("addWeightCode", "(Ljava/lang/StringBuilder;I)V", "GetAddWeightCode_Ljava_lang_StringBuilder_IHandler")]
		protected unsafe override void AddWeightCode(StringBuilder p0, int p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addWeightCode.(Ljava/lang/StringBuilder;I)V", this, ptr);
			GC.KeepAlive(p0);
		}

		[Register("checkWeight", "(I)I", "GetCheckWeight_IHandler")]
		protected unsafe override int CheckWeight(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return _members.InstanceMethods.InvokeAbstractInt32Method("checkWeight.(I)I", this, ptr);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI01AndOtherAIs", DoNotGenerateAcw = true)]
	public sealed class AI01AndOtherAIs : AI01decoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI01AndOtherAIs", typeof(AI01AndOtherAIs));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AI01AndOtherAIs(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("parseInformation", "()Ljava/lang/String;", "")]
		public unsafe override string ParseInformation()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("parseInformation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI01decoder", DoNotGenerateAcw = true)]
	public abstract class AI01decoder : AbstractExpandedDecoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI01decoder", typeof(AI01decoder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected AI01decoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI01decoder", DoNotGenerateAcw = true)]
	internal class AI01decoderInvoker : AI01decoder
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI01decoder", typeof(AI01decoderInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public AI01decoderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("parseInformation", "()Ljava/lang/String;", "GetParseInformationHandler")]
		public unsafe override string ParseInformation()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("parseInformation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI01weightDecoder", DoNotGenerateAcw = true)]
	public abstract class AI01weightDecoder : AI01decoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI01weightDecoder", typeof(AI01weightDecoder));

		private static Delegate cb_addWeightCode_Ljava_lang_StringBuilder_I;

		private static Delegate cb_checkWeight_I;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected AI01weightDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetAddWeightCode_Ljava_lang_StringBuilder_IHandler()
		{
			if ((object)cb_addWeightCode_Ljava_lang_StringBuilder_I == null)
			{
				cb_addWeightCode_Ljava_lang_StringBuilder_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, int>(n_AddWeightCode_Ljava_lang_StringBuilder_I));
			}
			return cb_addWeightCode_Ljava_lang_StringBuilder_I;
		}

		private static void n_AddWeightCode_Ljava_lang_StringBuilder_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			AI01weightDecoder aI01weightDecoder = Java.Lang.Object.GetObject<AI01weightDecoder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			StringBuilder p2 = Java.Lang.Object.GetObject<StringBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
			aI01weightDecoder.AddWeightCode(p2, p1);
		}

		[Register("addWeightCode", "(Ljava/lang/StringBuilder;I)V", "GetAddWeightCode_Ljava_lang_StringBuilder_IHandler")]
		protected abstract void AddWeightCode(StringBuilder p0, int p1);

		private static Delegate GetCheckWeight_IHandler()
		{
			if ((object)cb_checkWeight_I == null)
			{
				cb_checkWeight_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, int>(n_CheckWeight_I));
			}
			return cb_checkWeight_I;
		}

		private static int n_CheckWeight_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			return Java.Lang.Object.GetObject<AI01weightDecoder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckWeight(p0);
		}

		[Register("checkWeight", "(I)I", "GetCheckWeight_IHandler")]
		protected abstract int CheckWeight(int p0);
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AI01weightDecoder", DoNotGenerateAcw = true)]
	internal class AI01weightDecoderInvoker : AI01weightDecoder
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AI01weightDecoder", typeof(AI01weightDecoderInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public AI01weightDecoderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("addWeightCode", "(Ljava/lang/StringBuilder;I)V", "GetAddWeightCode_Ljava_lang_StringBuilder_IHandler")]
		protected unsafe override void AddWeightCode(StringBuilder p0, int p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addWeightCode.(Ljava/lang/StringBuilder;I)V", this, ptr);
			GC.KeepAlive(p0);
		}

		[Register("checkWeight", "(I)I", "GetCheckWeight_IHandler")]
		protected unsafe override int CheckWeight(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return _members.InstanceMethods.InvokeAbstractInt32Method("checkWeight.(I)I", this, ptr);
		}

		[Register("parseInformation", "()Ljava/lang/String;", "GetParseInformationHandler")]
		public unsafe override string ParseInformation()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("parseInformation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/AnyAIDecoder", DoNotGenerateAcw = true)]
	public sealed class AnyAIDecoder : AbstractExpandedDecoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/AnyAIDecoder", typeof(AnyAIDecoder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AnyAIDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("parseInformation", "()Ljava/lang/String;", "")]
		public unsafe override string ParseInformation()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("parseInformation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/BlockParsedResult", DoNotGenerateAcw = true)]
	public sealed class BlockParsedResult : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/BlockParsedResult", typeof(BlockParsedResult));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BlockParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/CurrentParsingState", DoNotGenerateAcw = true)]
	public sealed class CurrentParsingState : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/CurrentParsingState", typeof(CurrentParsingState));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal CurrentParsingState(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/DecodedChar", DoNotGenerateAcw = true)]
	public sealed class DecodedChar : DecodedObject
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/DecodedChar", typeof(DecodedChar));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DecodedChar(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/DecodedInformation", DoNotGenerateAcw = true)]
	public sealed class DecodedInformation : DecodedObject
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/DecodedInformation", typeof(DecodedInformation));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DecodedInformation(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/DecodedNumeric", DoNotGenerateAcw = true)]
	public sealed class DecodedNumeric : DecodedObject
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/DecodedNumeric", typeof(DecodedNumeric));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DecodedNumeric(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/DecodedObject", DoNotGenerateAcw = true)]
	public abstract class DecodedObject : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/DecodedObject", typeof(DecodedObject));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected DecodedObject(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/DecodedObject", DoNotGenerateAcw = true)]
	internal class DecodedObjectInvoker : DecodedObject
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/oned/rss/expanded/decoders/DecodedObject", typeof(DecodedObjectInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public DecodedObjectInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/FieldParser", DoNotGenerateAcw = true)]
	public sealed class FieldParser : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/FieldParser", typeof(FieldParser));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal FieldParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/oned/rss/expanded/decoders/GeneralAppIdDecoder", DoNotGenerateAcw = true)]
	public sealed class GeneralAppIdDecoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/oned/rss/expanded/decoders/GeneralAppIdDecoder", typeof(GeneralAppIdDecoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal GeneralAppIdDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
}
namespace Google.ZXing.Multi
{
	[Register("com/google/zxing/multi/ByQuadrantReader", DoNotGenerateAcw = true)]
	public sealed class ByQuadrantReader : Java.Lang.Object, IReader, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/multi/ByQuadrantReader", typeof(ByQuadrantReader));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ByQuadrantReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/Reader;)V", "")]
		public unsafe ByQuadrantReader(IReader @delegate)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((@delegate == null) ? IntPtr.Zero : ((Java.Lang.Object)@delegate).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/Reader;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/Reader;)V", this, ptr);
				GC.KeepAlive(@delegate);
			}
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(image);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}

		[Register("reset", "()V", "")]
		public unsafe void Reset()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("reset.()V", this, null);
		}
	}
	[Register("com/google/zxing/multi/GenericMultipleBarcodeReader", DoNotGenerateAcw = true)]
	public sealed class GenericMultipleBarcodeReader : Java.Lang.Object, IMultipleBarcodeReader, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/multi/GenericMultipleBarcodeReader", typeof(GenericMultipleBarcodeReader));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal GenericMultipleBarcodeReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/Reader;)V", "")]
		public unsafe GenericMultipleBarcodeReader(IReader @delegate)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((@delegate == null) ? IntPtr.Zero : ((Java.Lang.Object)@delegate).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/Reader;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/Reader;)V", this, ptr);
				GC.KeepAlive(@delegate);
			}
		}

		[Register("decodeMultiple", "(Lcom/google/zxing/BinaryBitmap;)[Lcom/google/zxing/Result;", "")]
		public unsafe Result[] DecodeMultiple(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result[] result = (Result[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeMultiple.(Lcom/google/zxing/BinaryBitmap;)[Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Result));
			GC.KeepAlive(image);
			return result;
		}

		[Register("decodeMultiple", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)[Lcom/google/zxing/Result;", "")]
		public unsafe Result[] DecodeMultiple(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result[] result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = (Result[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeMultiple.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)[Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Result));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/multi/MultipleBarcodeReader", "", "Google.ZXing.Multi.IMultipleBarcodeReaderInvoker")]
	public interface IMultipleBarcodeReader : IJavaObject, IDisposable
	{
		[Register("decodeMultiple", "(Lcom/google/zxing/BinaryBitmap;)[Lcom/google/zxing/Result;", "GetDecodeMultiple_Lcom_google_zxing_BinaryBitmap_Handler:Google.ZXing.Multi.IMultipleBarcodeReaderInvoker, Google.ZXing.Core")]
		Result[] DecodeMultiple(BinaryBitmap p0);

		[Register("decodeMultiple", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)[Lcom/google/zxing/Result;", "GetDecodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_Handler:Google.ZXing.Multi.IMultipleBarcodeReaderInvoker, Google.ZXing.Core")]
		Result[] DecodeMultiple(BinaryBitmap p0, IDictionary<DecodeHintType, object> p1);
	}
	[Register("com/google/zxing/multi/MultipleBarcodeReader", DoNotGenerateAcw = true)]
	internal class IMultipleBarcodeReaderInvoker : Java.Lang.Object, IMultipleBarcodeReader, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/multi/MultipleBarcodeReader", typeof(IMultipleBarcodeReaderInvoker));

		private IntPtr class_ref;

		private static Delegate cb_decodeMultiple_Lcom_google_zxing_BinaryBitmap_;

		private IntPtr id_decodeMultiple_Lcom_google_zxing_BinaryBitmap_;

		private static Delegate cb_decodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_;

		private IntPtr id_decodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IMultipleBarcodeReader GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMultipleBarcodeReader>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.zxing.multi.MultipleBarcodeReader"));
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IMultipleBarcodeReaderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDecodeMultiple_Lcom_google_zxing_BinaryBitmap_Handler()
		{
			if ((object)cb_decodeMultiple_Lcom_google_zxing_BinaryBitmap_ == null)
			{
				cb_decodeMultiple_Lcom_google_zxing_BinaryBitmap_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_DecodeMultiple_Lcom_google_zxing_BinaryBitmap_));
			}
			return cb_decodeMultiple_Lcom_google_zxing_BinaryBitmap_;
		}

		private static IntPtr n_DecodeMultiple_Lcom_google_zxing_BinaryBitmap_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IMultipleBarcodeReader multipleBarcodeReader = Java.Lang.Object.GetObject<IMultipleBarcodeReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BinaryBitmap p = Java.Lang.Object.GetObject<BinaryBitmap>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(multipleBarcodeReader.DecodeMultiple(p));
		}

		public unsafe Result[] DecodeMultiple(BinaryBitmap p0)
		{
			if (id_decodeMultiple_Lcom_google_zxing_BinaryBitmap_ == IntPtr.Zero)
			{
				id_decodeMultiple_Lcom_google_zxing_BinaryBitmap_ = JNIEnv.GetMethodID(class_ref, "decodeMultiple", "(Lcom/google/zxing/BinaryBitmap;)[Lcom/google/zxing/Result;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return (Result[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_decodeMultiple_Lcom_google_zxing_BinaryBitmap_, ptr), JniHandleOwnership.TransferLocalRef, typeof(Result));
		}

		private static Delegate GetDecodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_Handler()
		{
			if ((object)cb_decodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_ == null)
			{
				cb_decodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_DecodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_));
			}
			return cb_decodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_;
		}

		private static IntPtr n_DecodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IMultipleBarcodeReader multipleBarcodeReader = Java.Lang.Object.GetObject<IMultipleBarcodeReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BinaryBitmap p = Java.Lang.Object.GetObject<BinaryBitmap>(native_p0, JniHandleOwnership.DoNotTransfer);
			IDictionary<DecodeHintType, object> p2 = JavaDictionary<DecodeHintType, object>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(multipleBarcodeReader.DecodeMultiple(p, p2));
		}

		public unsafe Result[] DecodeMultiple(BinaryBitmap p0, IDictionary<DecodeHintType, object> p1)
		{
			if (id_decodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_ == IntPtr.Zero)
			{
				id_decodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_ = JNIEnv.GetMethodID(class_ref, "decodeMultiple", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)[Lcom/google/zxing/Result;");
			}
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			Result[] result = (Result[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_decodeMultiple_Lcom_google_zxing_BinaryBitmap_Ljava_util_Map_, ptr), JniHandleOwnership.TransferLocalRef, typeof(Result));
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}
	}
}
namespace Google.ZXing.Multi.QRCode
{
	[Register("com/google/zxing/multi/qrcode/QRCodeMultiReader", DoNotGenerateAcw = true)]
	public sealed class QRCodeMultiReader : QRCodeReader, IMultipleBarcodeReader, IJavaObject, IDisposable
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/multi/qrcode/QRCodeMultiReader", typeof(QRCodeMultiReader));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal QRCodeMultiReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe QRCodeMultiReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decodeMultiple", "(Lcom/google/zxing/BinaryBitmap;)[Lcom/google/zxing/Result;", "")]
		public unsafe Result[] DecodeMultiple(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result[] result = (Result[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeMultiple.(Lcom/google/zxing/BinaryBitmap;)[Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Result));
			GC.KeepAlive(image);
			return result;
		}

		[Register("decodeMultiple", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)[Lcom/google/zxing/Result;", "")]
		public unsafe Result[] DecodeMultiple(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result[] result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = (Result[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("decodeMultiple.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)[Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Result));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}
	}
}
namespace Google.ZXing.Multi.QRCode.Detector
{
	[Register("com/google/zxing/multi/qrcode/detector/MultiDetector", DoNotGenerateAcw = true)]
	public sealed class MultiDetector : Google.ZXing.QRCode.Detector.Detector
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/multi/qrcode/detector/MultiDetector", typeof(MultiDetector));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MultiDetector(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;)V", "")]
		public unsafe MultiDetector(BitMatrix image)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", this, ptr);
				GC.KeepAlive(image);
			}
		}

		[Register("detectMulti", "(Ljava/util/Map;)[Lcom/google/zxing/common/DetectorResult;", "")]
		public unsafe DetectorResult[] DetectMulti(IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			DetectorResult[] result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = (DetectorResult[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("detectMulti.(Ljava/util/Map;)[Lcom/google/zxing/common/DetectorResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(DetectorResult));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(hints);
			return result;
		}
	}
	[Register("com/google/zxing/multi/qrcode/detector/MultiFinderPatternFinder", DoNotGenerateAcw = true)]
	public sealed class MultiFinderPatternFinder : FinderPatternFinder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/multi/qrcode/detector/MultiFinderPatternFinder", typeof(MultiFinderPatternFinder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MultiFinderPatternFinder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("findMulti", "(Ljava/util/Map;)[Lcom/google/zxing/qrcode/detector/FinderPatternInfo;", "")]
		public unsafe FinderPatternInfo[] FindMulti(IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			FinderPatternInfo[] result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = (FinderPatternInfo[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("findMulti.(Ljava/util/Map;)[Lcom/google/zxing/qrcode/detector/FinderPatternInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(FinderPatternInfo));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(hints);
			return result;
		}
	}
}
namespace Google.ZXing.MaxiCode
{
	[Register("com/google/zxing/maxicode/MaxiCodeReader", DoNotGenerateAcw = true)]
	public sealed class MaxiCodeReader : Java.Lang.Object, IReader, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/maxicode/MaxiCodeReader", typeof(MaxiCodeReader));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MaxiCodeReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe MaxiCodeReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(image);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}

		[Register("reset", "()V", "")]
		public unsafe void Reset()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("reset.()V", this, null);
		}
	}
}
namespace Google.ZXing.MaxiCode.Decoder
{
	[Register("com/google/zxing/maxicode/decoder/BitMatrixParser", DoNotGenerateAcw = true)]
	public sealed class BitMatrixParser : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/maxicode/decoder/BitMatrixParser", typeof(BitMatrixParser));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BitMatrixParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/maxicode/decoder/DecodedBitStreamParser", DoNotGenerateAcw = true)]
	public sealed class DecodedBitStreamParser : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/maxicode/decoder/DecodedBitStreamParser", typeof(DecodedBitStreamParser));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DecodedBitStreamParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/maxicode/decoder/Decoder", DoNotGenerateAcw = true)]
	public sealed class Decoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/maxicode/decoder/Decoder", typeof(Decoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Decoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Decoder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decode", "(Lcom/google/zxing/common/BitMatrix;)Lcom/google/zxing/common/DecoderResult;", "")]
		public unsafe DecoderResult Decode(BitMatrix bits)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bits?.Handle ?? IntPtr.Zero);
			DecoderResult result = Java.Lang.Object.GetObject<DecoderResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/common/BitMatrix;)Lcom/google/zxing/common/DecoderResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(bits);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/common/BitMatrix;Ljava/util/Map;)Lcom/google/zxing/common/DecoderResult;", "")]
		public unsafe DecoderResult Decode(BitMatrix bits, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			DecoderResult result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bits?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<DecoderResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/common/BitMatrix;Ljava/util/Map;)Lcom/google/zxing/common/DecoderResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(bits);
			GC.KeepAlive(hints);
			return result;
		}
	}
}
namespace Google.ZXing.DataMatrix
{
	[Register("com/google/zxing/datamatrix/DataMatrixReader", DoNotGenerateAcw = true)]
	public sealed class DataMatrixReader : Java.Lang.Object, IReader, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/DataMatrixReader", typeof(DataMatrixReader));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DataMatrixReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DataMatrixReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(image);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}

		[Register("reset", "()V", "")]
		public unsafe void Reset()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("reset.()V", this, null);
		}
	}
	[Register("com/google/zxing/datamatrix/DataMatrixWriter", DoNotGenerateAcw = true)]
	public sealed class DataMatrixWriter : Java.Lang.Object, IWriter, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/DataMatrixWriter", typeof(DataMatrixWriter));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DataMatrixWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DataMatrixWriter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(format);
			return result;
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			IntPtr intPtr2 = JavaDictionary<EncodeHintType, object>.ToLocalJniHandle(hints);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				ptr[4] = new JniArgumentValue(intPtr2);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(format);
			GC.KeepAlive(hints);
			return result;
		}
	}
}
namespace Google.ZXing.DataMatrix.Encoder
{
	[Register("com/google/zxing/datamatrix/encoder/ASCIIEncoder", DoNotGenerateAcw = true)]
	public sealed class ASCIIEncoder : Java.Lang.Object, IEncoder, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/ASCIIEncoder", typeof(ASCIIEncoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int EncodingMode
		{
			[Register("getEncodingMode", "()I", "GetGetEncodingModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getEncodingMode.()I", this, null);
			}
		}

		internal ASCIIEncoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/Base256Encoder", DoNotGenerateAcw = true)]
	public sealed class Base256Encoder : Java.Lang.Object, IEncoder, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/Base256Encoder", typeof(Base256Encoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int EncodingMode
		{
			[Register("getEncodingMode", "()I", "GetGetEncodingModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getEncodingMode.()I", this, null);
			}
		}

		internal Base256Encoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/C40Encoder", DoNotGenerateAcw = true)]
	public class C40Encoder : Java.Lang.Object, IEncoder, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/C40Encoder", typeof(C40Encoder));

		private static Delegate cb_getEncodingMode;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int EncodingMode
		{
			[Register("getEncodingMode", "()I", "GetGetEncodingModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getEncodingMode.()I", this, null);
			}
		}

		protected C40Encoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetEncodingModeHandler()
		{
			if ((object)cb_getEncodingMode == null)
			{
				cb_getEncodingMode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetEncodingMode));
			}
			return cb_getEncodingMode;
		}

		private static int n_GetEncodingMode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<C40Encoder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EncodingMode;
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/DataMatrixSymbolInfo144", DoNotGenerateAcw = true)]
	public sealed class DataMatrixSymbolInfo144 : SymbolInfo
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/DataMatrixSymbolInfo144", typeof(DataMatrixSymbolInfo144));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DataMatrixSymbolInfo144(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/DefaultPlacement", DoNotGenerateAcw = true)]
	public class DefaultPlacement : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/DefaultPlacement", typeof(DefaultPlacement));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected DefaultPlacement(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/CharSequence;II)V", "")]
		public unsafe DefaultPlacement(ICharSequence codewords, int numcols, int numrows)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = CharSequence.ToLocalJniHandle(codewords);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(numcols);
				ptr[2] = new JniArgumentValue(numrows);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;II)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(codewords);
			}
		}

		[Register(".ctor", "(Ljava/lang/CharSequence;II)V", "")]
		public unsafe DefaultPlacement(string codewords, int numcols, int numrows)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = CharSequence.ToLocalJniHandle(codewords);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(numcols);
				ptr[2] = new JniArgumentValue(numrows);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;II)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getBit", "(II)Z", "")]
		public unsafe bool GetBit(int col, int row)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(col);
			ptr[1] = new JniArgumentValue(row);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getBit.(II)Z", this, ptr);
		}

		[Register("place", "()V", "")]
		public unsafe void Place()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("place.()V", this, null);
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/EdifactEncoder", DoNotGenerateAcw = true)]
	public sealed class EdifactEncoder : Java.Lang.Object, IEncoder, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/EdifactEncoder", typeof(EdifactEncoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int EncodingMode
		{
			[Register("getEncodingMode", "()I", "GetGetEncodingModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getEncodingMode.()I", this, null);
			}
		}

		internal EdifactEncoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/EncoderContext", DoNotGenerateAcw = true)]
	public sealed class EncoderContext : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/EncoderContext", typeof(EncoderContext));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int CodewordCount
		{
			[Register("getCodewordCount", "()I", "GetGetCodewordCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getCodewordCount.()I", this, null);
			}
		}

		public unsafe StringBuilder Codewords
		{
			[Register("getCodewords", "()Ljava/lang/StringBuilder;", "GetGetCodewordsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<StringBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCodewords.()Ljava/lang/StringBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe char Current
		{
			[Register("getCurrent", "()C", "GetGetCurrentHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractCharMethod("getCurrent.()C", this, null);
			}
		}

		public unsafe char CurrentChar
		{
			[Register("getCurrentChar", "()C", "GetGetCurrentCharHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractCharMethod("getCurrentChar.()C", this, null);
			}
		}

		public unsafe bool HasMoreCharacters
		{
			[Register("hasMoreCharacters", "()Z", "GetHasMoreCharactersHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasMoreCharacters.()Z", this, null);
			}
		}

		public unsafe string Message
		{
			[Register("getMessage", "()Ljava/lang/String;", "GetGetMessageHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int NewEncoding
		{
			[Register("getNewEncoding", "()I", "GetGetNewEncodingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getNewEncoding.()I", this, null);
			}
		}

		public unsafe int RemainingCharacters
		{
			[Register("getRemainingCharacters", "()I", "GetGetRemainingCharactersHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getRemainingCharacters.()I", this, null);
			}
		}

		public unsafe SymbolInfo SymbolInfo
		{
			[Register("getSymbolInfo", "()Lcom/google/zxing/datamatrix/encoder/SymbolInfo;", "GetGetSymbolInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<SymbolInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSymbolInfo.()Lcom/google/zxing/datamatrix/encoder/SymbolInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal EncoderContext(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("resetEncoderSignal", "()V", "")]
		public unsafe void ResetEncoderSignal()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("resetEncoderSignal.()V", this, null);
		}

		[Register("resetSymbolInfo", "()V", "")]
		public unsafe void ResetSymbolInfo()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("resetSymbolInfo.()V", this, null);
		}

		[Register("setSizeConstraints", "(Lcom/google/zxing/Dimension;Lcom/google/zxing/Dimension;)V", "")]
		public unsafe void SetSizeConstraints(Dimension minSize, Dimension maxSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(minSize?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(maxSize?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setSizeConstraints.(Lcom/google/zxing/Dimension;Lcom/google/zxing/Dimension;)V", this, ptr);
			GC.KeepAlive(minSize);
			GC.KeepAlive(maxSize);
		}

		[Register("setSkipAtEnd", "(I)V", "")]
		public unsafe void SetSkipAtEnd(int count)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(count);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setSkipAtEnd.(I)V", this, ptr);
		}

		[Register("setSymbolShape", "(Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;)V", "")]
		public unsafe void SetSymbolShape(SymbolShapeHint shape)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(shape?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setSymbolShape.(Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;)V", this, ptr);
			GC.KeepAlive(shape);
		}

		[Register("signalEncoderChange", "(I)V", "")]
		public unsafe void SignalEncoderChange(int encoding)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(encoding);
			_members.InstanceMethods.InvokeAbstractVoidMethod("signalEncoderChange.(I)V", this, ptr);
		}

		[Register("updateSymbolInfo", "()V", "")]
		public unsafe void UpdateSymbolInfo()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("updateSymbolInfo.()V", this, null);
		}

		[Register("updateSymbolInfo", "(I)V", "")]
		public unsafe void UpdateSymbolInfo(int len)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(len);
			_members.InstanceMethods.InvokeAbstractVoidMethod("updateSymbolInfo.(I)V", this, ptr);
		}

		[Register("writeCodeword", "(C)V", "")]
		public unsafe void WriteCodeword(char codeword)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(codeword);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeCodeword.(C)V", this, ptr);
		}

		[Register("writeCodewords", "(Ljava/lang/String;)V", "")]
		public unsafe void WriteCodewords(string codewords)
		{
			IntPtr intPtr = JNIEnv.NewString(codewords);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeCodewords.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/ErrorCorrection", DoNotGenerateAcw = true)]
	public sealed class ErrorCorrection : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/ErrorCorrection", typeof(ErrorCorrection));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ErrorCorrection(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("encodeECC200", "(Ljava/lang/String;Lcom/google/zxing/datamatrix/encoder/SymbolInfo;)Ljava/lang/String;", "")]
		public unsafe static string EncodeECC200(string codewords, SymbolInfo symbolInfo)
		{
			IntPtr intPtr = JNIEnv.NewString(codewords);
			string result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(symbolInfo?.Handle ?? IntPtr.Zero);
				result = JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("encodeECC200.(Ljava/lang/String;Lcom/google/zxing/datamatrix/encoder/SymbolInfo;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(symbolInfo);
			return result;
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/HighLevelEncoder", DoNotGenerateAcw = true)]
	public sealed class HighLevelEncoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/HighLevelEncoder", typeof(HighLevelEncoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal HighLevelEncoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("determineConsecutiveDigitCount", "(Ljava/lang/CharSequence;I)I", "")]
		public unsafe static int DetermineConsecutiveDigitCount(ICharSequence msg, int startpos)
		{
			IntPtr intPtr = CharSequence.ToLocalJniHandle(msg);
			int result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(startpos);
				result = _members.StaticMethods.InvokeInt32Method("determineConsecutiveDigitCount.(Ljava/lang/CharSequence;I)I", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(msg);
			return result;
		}

		public static int DetermineConsecutiveDigitCount(string msg, int startpos)
		{
			Java.Lang.String obj = ((msg == null) ? null : new Java.Lang.String(msg));
			int result = DetermineConsecutiveDigitCount(obj, startpos);
			obj?.Dispose();
			return result;
		}

		[Register("encodeHighLevel", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe static string EncodeHighLevel(string msg)
		{
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("encodeHighLevel.(Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("encodeHighLevel", "(Ljava/lang/String;Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;Lcom/google/zxing/Dimension;Lcom/google/zxing/Dimension;)Ljava/lang/String;", "")]
		public unsafe static string EncodeHighLevel(string msg, SymbolShapeHint shape, Dimension minSize, Dimension maxSize)
		{
			IntPtr intPtr = JNIEnv.NewString(msg);
			string result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(shape?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(minSize?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(maxSize?.Handle ?? IntPtr.Zero);
				result = JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("encodeHighLevel.(Ljava/lang/String;Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;Lcom/google/zxing/Dimension;Lcom/google/zxing/Dimension;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(shape);
			GC.KeepAlive(minSize);
			GC.KeepAlive(maxSize);
			return result;
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/Encoder", "", "Google.ZXing.DataMatrix.Encoder.IEncoderInvoker")]
	public interface IEncoder : IJavaObject, IDisposable
	{
		int EncodingMode
		{
			[Register("getEncodingMode", "()I", "GetGetEncodingModeHandler:Google.ZXing.DataMatrix.Encoder.IEncoderInvoker, Google.ZXing.Core")]
			get;
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/Encoder", DoNotGenerateAcw = true)]
	internal class IEncoderInvoker : Java.Lang.Object, IEncoder, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/datamatrix/encoder/Encoder", typeof(IEncoderInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getEncodingMode;

		private IntPtr id_getEncodingMode;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public int EncodingMode
		{
			get
			{
				if (id_getEncodingMode == IntPtr.Zero)
				{
					id_getEncodingMode = JNIEnv.GetMethodID(class_ref, "getEncodingMode", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_getEncodingMode);
			}
		}

		public static IEncoder GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IEncoder>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.zxing.datamatrix.encoder.Encoder"));
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IEncoderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetEncodingModeHandler()
		{
			if ((object)cb_getEncodingMode == null)
			{
				cb_getEncodingMode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetEncodingMode));
			}
			return cb_getEncodingMode;
		}

		private static int n_GetEncodingMode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IEncoder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EncodingMode;
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/SymbolInfo", DoNotGenerateAcw = true)]
	public class SymbolInfo : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/SymbolInfo", typeof(SymbolInfo));

		private static Delegate cb_getCodewordCount;

		private static Delegate cb_getInterleavedBlockCount;

		private static Delegate cb_getDataLengthForInterleavedBlock_I;

		[Register("matrixHeight")]
		public int MatrixHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("matrixHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matrixHeight.I", this, value);
			}
		}

		[Register("matrixWidth")]
		public int MatrixWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("matrixWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matrixWidth.I", this, value);
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int CodewordCount
		{
			[Register("getCodewordCount", "()I", "GetGetCodewordCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getCodewordCount.()I", this, null);
			}
		}

		public unsafe int DataCapacity
		{
			[Register("getDataCapacity", "()I", "GetGetDataCapacityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getDataCapacity.()I", this, null);
			}
		}

		public unsafe int ErrorCodewords
		{
			[Register("getErrorCodewords", "()I", "GetGetErrorCodewordsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getErrorCodewords.()I", this, null);
			}
		}

		public unsafe virtual int InterleavedBlockCount
		{
			[Register("getInterleavedBlockCount", "()I", "GetGetInterleavedBlockCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getInterleavedBlockCount.()I", this, null);
			}
		}

		public unsafe int SymbolDataHeight
		{
			[Register("getSymbolDataHeight", "()I", "GetGetSymbolDataHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getSymbolDataHeight.()I", this, null);
			}
		}

		public unsafe int SymbolDataWidth
		{
			[Register("getSymbolDataWidth", "()I", "GetGetSymbolDataWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getSymbolDataWidth.()I", this, null);
			}
		}

		public unsafe int SymbolHeight
		{
			[Register("getSymbolHeight", "()I", "GetGetSymbolHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getSymbolHeight.()I", this, null);
			}
		}

		public unsafe int SymbolWidth
		{
			[Register("getSymbolWidth", "()I", "GetGetSymbolWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getSymbolWidth.()I", this, null);
			}
		}

		protected SymbolInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(ZIIIII)V", "")]
		public unsafe SymbolInfo(bool rectangular, int dataCapacity, int errorCodewords, int matrixWidth, int matrixHeight, int dataRegions)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(rectangular);
				ptr[1] = new JniArgumentValue(dataCapacity);
				ptr[2] = new JniArgumentValue(errorCodewords);
				ptr[3] = new JniArgumentValue(matrixWidth);
				ptr[4] = new JniArgumentValue(matrixHeight);
				ptr[5] = new JniArgumentValue(dataRegions);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ZIIIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ZIIIII)V", this, ptr);
			}
		}

		private static Delegate GetGetCodewordCountHandler()
		{
			if ((object)cb_getCodewordCount == null)
			{
				cb_getCodewordCount = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetCodewordCount));
			}
			return cb_getCodewordCount;
		}

		private static int n_GetCodewordCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SymbolInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CodewordCount;
		}

		private static Delegate GetGetInterleavedBlockCountHandler()
		{
			if ((object)cb_getInterleavedBlockCount == null)
			{
				cb_getInterleavedBlockCount = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetInterleavedBlockCount));
			}
			return cb_getInterleavedBlockCount;
		}

		private static int n_GetInterleavedBlockCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SymbolInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InterleavedBlockCount;
		}

		private static Delegate GetGetDataLengthForInterleavedBlock_IHandler()
		{
			if ((object)cb_getDataLengthForInterleavedBlock_I == null)
			{
				cb_getDataLengthForInterleavedBlock_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, int>(n_GetDataLengthForInterleavedBlock_I));
			}
			return cb_getDataLengthForInterleavedBlock_I;
		}

		private static int n_GetDataLengthForInterleavedBlock_I(IntPtr jnienv, IntPtr native__this, int index)
		{
			return Java.Lang.Object.GetObject<SymbolInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDataLengthForInterleavedBlock(index);
		}

		[Register("getDataLengthForInterleavedBlock", "(I)I", "GetGetDataLengthForInterleavedBlock_IHandler")]
		public unsafe virtual int GetDataLengthForInterleavedBlock(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDataLengthForInterleavedBlock.(I)I", this, ptr);
		}

		[Register("getErrorLengthForInterleavedBlock", "(I)I", "")]
		public unsafe int GetErrorLengthForInterleavedBlock(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getErrorLengthForInterleavedBlock.(I)I", this, ptr);
		}

		[Register("lookup", "(I)Lcom/google/zxing/datamatrix/encoder/SymbolInfo;", "")]
		public unsafe static SymbolInfo Lookup(int dataCodewords)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dataCodewords);
			return Java.Lang.Object.GetObject<SymbolInfo>(_members.StaticMethods.InvokeObjectMethod("lookup.(I)Lcom/google/zxing/datamatrix/encoder/SymbolInfo;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("lookup", "(IZZ)Lcom/google/zxing/datamatrix/encoder/SymbolInfo;", "")]
		public unsafe static SymbolInfo Lookup(int dataCodewords, bool allowRectangular, bool fail)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(dataCodewords);
			ptr[1] = new JniArgumentValue(allowRectangular);
			ptr[2] = new JniArgumentValue(fail);
			return Java.Lang.Object.GetObject<SymbolInfo>(_members.StaticMethods.InvokeObjectMethod("lookup.(IZZ)Lcom/google/zxing/datamatrix/encoder/SymbolInfo;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("lookup", "(ILcom/google/zxing/datamatrix/encoder/SymbolShapeHint;)Lcom/google/zxing/datamatrix/encoder/SymbolInfo;", "")]
		public unsafe static SymbolInfo Lookup(int dataCodewords, SymbolShapeHint shape)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dataCodewords);
			ptr[1] = new JniArgumentValue(shape?.Handle ?? IntPtr.Zero);
			SymbolInfo result = Java.Lang.Object.GetObject<SymbolInfo>(_members.StaticMethods.InvokeObjectMethod("lookup.(ILcom/google/zxing/datamatrix/encoder/SymbolShapeHint;)Lcom/google/zxing/datamatrix/encoder/SymbolInfo;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(shape);
			return result;
		}

		[Register("lookup", "(ILcom/google/zxing/datamatrix/encoder/SymbolShapeHint;Lcom/google/zxing/Dimension;Lcom/google/zxing/Dimension;Z)Lcom/google/zxing/datamatrix/encoder/SymbolInfo;", "")]
		public unsafe static SymbolInfo Lookup(int dataCodewords, SymbolShapeHint shape, Dimension minSize, Dimension maxSize, bool fail)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(dataCodewords);
			ptr[1] = new JniArgumentValue(shape?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(minSize?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(maxSize?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(fail);
			SymbolInfo result = Java.Lang.Object.GetObject<SymbolInfo>(_members.StaticMethods.InvokeObjectMethod("lookup.(ILcom/google/zxing/datamatrix/encoder/SymbolShapeHint;Lcom/google/zxing/Dimension;Lcom/google/zxing/Dimension;Z)Lcom/google/zxing/datamatrix/encoder/SymbolInfo;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(shape);
			GC.KeepAlive(minSize);
			GC.KeepAlive(maxSize);
			return result;
		}

		[Register("overrideSymbolSet", "([Lcom/google/zxing/datamatrix/encoder/SymbolInfo;)V", "")]
		public unsafe static void OverrideSymbolSet(SymbolInfo[] @override)
		{
			IntPtr intPtr = JNIEnv.NewArray(@override);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("overrideSymbolSet.([Lcom/google/zxing/datamatrix/encoder/SymbolInfo;)V", ptr);
			}
			finally
			{
				if (@override != null)
				{
					JNIEnv.CopyArray(intPtr, @override);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(@override);
				}
			}
		}

		[Register("toString", "()Ljava/lang/String;", "")]
		public unsafe sealed override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/SymbolShapeHint", DoNotGenerateAcw = true)]
	public sealed class SymbolShapeHint : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/SymbolShapeHint", typeof(SymbolShapeHint));

		[Register("FORCE_NONE")]
		public static SymbolShapeHint ForceNone => Java.Lang.Object.GetObject<SymbolShapeHint>(_members.StaticFields.GetObjectValue("FORCE_NONE.Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FORCE_RECTANGLE")]
		public static SymbolShapeHint ForceRectangle => Java.Lang.Object.GetObject<SymbolShapeHint>(_members.StaticFields.GetObjectValue("FORCE_RECTANGLE.Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FORCE_SQUARE")]
		public static SymbolShapeHint ForceSquare => Java.Lang.Object.GetObject<SymbolShapeHint>(_members.StaticFields.GetObjectValue("FORCE_SQUARE.Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal SymbolShapeHint(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;", "")]
		public unsafe static SymbolShapeHint ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SymbolShapeHint>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;", "")]
		public unsafe static SymbolShapeHint[] Values()
		{
			return (SymbolShapeHint[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/datamatrix/encoder/SymbolShapeHint;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(SymbolShapeHint));
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/TextEncoder", DoNotGenerateAcw = true)]
	public sealed class TextEncoder : C40Encoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/TextEncoder", typeof(TextEncoder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override int EncodingMode
		{
			[Register("getEncodingMode", "()I", "GetGetEncodingModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getEncodingMode.()I", this, null);
			}
		}

		internal TextEncoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/datamatrix/encoder/X12Encoder", DoNotGenerateAcw = true)]
	public sealed class X12Encoder : C40Encoder
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/encoder/X12Encoder", typeof(X12Encoder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override int EncodingMode
		{
			[Register("getEncodingMode", "()I", "GetGetEncodingModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getEncodingMode.()I", this, null);
			}
		}

		internal X12Encoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
}
namespace Google.ZXing.DataMatrix.Detector
{
	[Register("com/google/zxing/datamatrix/detector/Detector", DoNotGenerateAcw = true)]
	public sealed class Detector : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/detector/Detector", typeof(Detector));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Detector(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;)V", "")]
		public unsafe Detector(BitMatrix image)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", this, ptr);
				GC.KeepAlive(image);
			}
		}

		[Register("detect", "()Lcom/google/zxing/common/DetectorResult;", "")]
		public unsafe DetectorResult Detect()
		{
			return Java.Lang.Object.GetObject<DetectorResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("detect.()Lcom/google/zxing/common/DetectorResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Google.ZXing.DataMatrix.Decoder
{
	[Register("com/google/zxing/datamatrix/decoder/BitMatrixParser", DoNotGenerateAcw = true)]
	public sealed class BitMatrixParser : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/decoder/BitMatrixParser", typeof(BitMatrixParser));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BitMatrixParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/datamatrix/decoder/DataBlock", DoNotGenerateAcw = true)]
	public sealed class DataBlock : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/decoder/DataBlock", typeof(DataBlock));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DataBlock(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/datamatrix/decoder/DecodedBitStreamParser", DoNotGenerateAcw = true)]
	public sealed class DecodedBitStreamParser : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/decoder/DecodedBitStreamParser", typeof(DecodedBitStreamParser));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DecodedBitStreamParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/datamatrix/decoder/Decoder", DoNotGenerateAcw = true)]
	public sealed class Decoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/decoder/Decoder", typeof(Decoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Decoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Decoder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decode", "([[Z)Lcom/google/zxing/common/DecoderResult;", "")]
		public unsafe DecoderResult Decode(bool[][] image)
		{
			IntPtr intPtr = JNIEnv.NewArray(image);
			DecoderResult result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<DecoderResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.([[Z)Lcom/google/zxing/common/DecoderResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (image != null)
				{
					JNIEnv.CopyArray(intPtr, image);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(image);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/common/BitMatrix;)Lcom/google/zxing/common/DecoderResult;", "")]
		public unsafe DecoderResult Decode(BitMatrix bits)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bits?.Handle ?? IntPtr.Zero);
			DecoderResult result = Java.Lang.Object.GetObject<DecoderResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/common/BitMatrix;)Lcom/google/zxing/common/DecoderResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(bits);
			return result;
		}
	}
	[Register("com/google/zxing/datamatrix/decoder/Version", DoNotGenerateAcw = true)]
	public sealed class Version : Java.Lang.Object
	{
		[Register("com/google/zxing/datamatrix/decoder/Version$ECB", DoNotGenerateAcw = true)]
		public sealed class ECB : Java.Lang.Object
		{
			internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/decoder/Version$ECB", typeof(ECB));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			internal ECB(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/google/zxing/datamatrix/decoder/Version$ECBlocks", DoNotGenerateAcw = true)]
		public sealed class ECBlocks : Java.Lang.Object
		{
			internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/decoder/Version$ECBlocks", typeof(ECBlocks));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			internal ECBlocks(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/datamatrix/decoder/Version", typeof(Version));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int DataRegionSizeColumns
		{
			[Register("getDataRegionSizeColumns", "()I", "GetGetDataRegionSizeColumnsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getDataRegionSizeColumns.()I", this, null);
			}
		}

		public unsafe int DataRegionSizeRows
		{
			[Register("getDataRegionSizeRows", "()I", "GetGetDataRegionSizeRowsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getDataRegionSizeRows.()I", this, null);
			}
		}

		public unsafe int SymbolSizeColumns
		{
			[Register("getSymbolSizeColumns", "()I", "GetGetSymbolSizeColumnsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getSymbolSizeColumns.()I", this, null);
			}
		}

		public unsafe int SymbolSizeRows
		{
			[Register("getSymbolSizeRows", "()I", "GetGetSymbolSizeRowsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getSymbolSizeRows.()I", this, null);
			}
		}

		public unsafe int TotalCodewords
		{
			[Register("getTotalCodewords", "()I", "GetGetTotalCodewordsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getTotalCodewords.()I", this, null);
			}
		}

		public unsafe int VersionNumber
		{
			[Register("getVersionNumber", "()I", "GetGetVersionNumberHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getVersionNumber.()I", this, null);
			}
		}

		internal Version(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getVersionForDimensions", "(II)Lcom/google/zxing/datamatrix/decoder/Version;", "")]
		public unsafe static Version GetVersionForDimensions(int numRows, int numColumns)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(numRows);
			ptr[1] = new JniArgumentValue(numColumns);
			return Java.Lang.Object.GetObject<Version>(_members.StaticMethods.InvokeObjectMethod("getVersionForDimensions.(II)Lcom/google/zxing/datamatrix/decoder/Version;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Google.ZXing.Common
{
	[Register("com/google/zxing/common/BitArray", DoNotGenerateAcw = true)]
	public sealed class BitArray : Java.Lang.Object, Java.Lang.ICloneable, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/BitArray", typeof(BitArray));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Size
		{
			[Register("getSize", "()I", "GetGetSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getSize.()I", this, null);
			}
		}

		public unsafe int SizeInBytes
		{
			[Register("getSizeInBytes", "()I", "GetGetSizeInBytesHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getSizeInBytes.()I", this, null);
			}
		}

		internal BitArray(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BitArray()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe BitArray(int size)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(size);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		[Register("appendBit", "(Z)V", "")]
		public unsafe void AppendBit(bool bit)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bit);
			_members.InstanceMethods.InvokeAbstractVoidMethod("appendBit.(Z)V", this, ptr);
		}

		[Register("appendBitArray", "(Lcom/google/zxing/common/BitArray;)V", "")]
		public unsafe void AppendBitArray(BitArray other)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("appendBitArray.(Lcom/google/zxing/common/BitArray;)V", this, ptr);
			GC.KeepAlive(other);
		}

		[Register("appendBits", "(II)V", "")]
		public unsafe void AppendBits(int value, int numBits)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(value);
			ptr[1] = new JniArgumentValue(numBits);
			_members.InstanceMethods.InvokeAbstractVoidMethod("appendBits.(II)V", this, ptr);
		}

		[Register("clear", "()V", "")]
		public unsafe void Clear()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
		}

		[Register("clone", "()Lcom/google/zxing/common/BitArray;", "")]
		public new unsafe BitArray Clone()
		{
			return Java.Lang.Object.GetObject<BitArray>(_members.InstanceMethods.InvokeAbstractObjectMethod("clone.()Lcom/google/zxing/common/BitArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("flip", "(I)V", "")]
		public unsafe void Flip(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			_members.InstanceMethods.InvokeAbstractVoidMethod("flip.(I)V", this, ptr);
		}

		[Register("get", "(I)Z", "")]
		public unsafe bool Get(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("get.(I)Z", this, ptr);
		}

		[Register("getBitArray", "()[I", "")]
		public unsafe int[] GetBitArray()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getBitArray.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		[Register("getNextSet", "(I)I", "")]
		public unsafe int GetNextSet(int from)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(from);
			return _members.InstanceMethods.InvokeAbstractInt32Method("getNextSet.(I)I", this, ptr);
		}

		[Register("getNextUnset", "(I)I", "")]
		public unsafe int GetNextUnset(int from)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(from);
			return _members.InstanceMethods.InvokeAbstractInt32Method("getNextUnset.(I)I", this, ptr);
		}

		[Register("isRange", "(IIZ)Z", "")]
		public unsafe bool IsRange(int start, int end, bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(value);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isRange.(IIZ)Z", this, ptr);
		}

		[Register("reverse", "()V", "")]
		public unsafe void Reverse()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("reverse.()V", this, null);
		}

		[Register("set", "(I)V", "")]
		public unsafe void Set(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			_members.InstanceMethods.InvokeAbstractVoidMethod("set.(I)V", this, ptr);
		}

		[Register("setBulk", "(II)V", "")]
		public unsafe void SetBulk(int i, int newBits)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(i);
			ptr[1] = new JniArgumentValue(newBits);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setBulk.(II)V", this, ptr);
		}

		[Register("setRange", "(II)V", "")]
		public unsafe void SetRange(int start, int end)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setRange.(II)V", this, ptr);
		}

		[Register("toBytes", "(I[BII)V", "")]
		public unsafe void ToBytes(int bitOffset, byte[] array, int offset, int numBytes)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(bitOffset);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(offset);
				ptr[3] = new JniArgumentValue(numBytes);
				_members.InstanceMethods.InvokeAbstractVoidMethod("toBytes.(I[BII)V", this, ptr);
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(array);
				}
			}
		}

		[Register("xor", "(Lcom/google/zxing/common/BitArray;)V", "")]
		public unsafe void Xor(BitArray other)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("xor.(Lcom/google/zxing/common/BitArray;)V", this, ptr);
			GC.KeepAlive(other);
		}
	}
	[Register("com/google/zxing/common/BitMatrix", DoNotGenerateAcw = true)]
	public sealed class BitMatrix : Java.Lang.Object, Java.Lang.ICloneable, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/BitMatrix", typeof(BitMatrix));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Height
		{
			[Register("getHeight", "()I", "GetGetHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getHeight.()I", this, null);
			}
		}

		public unsafe int RowSize
		{
			[Register("getRowSize", "()I", "GetGetRowSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getRowSize.()I", this, null);
			}
		}

		public unsafe int Width
		{
			[Register("getWidth", "()I", "GetGetWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getWidth.()I", this, null);
			}
		}

		internal BitMatrix(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe BitMatrix(int dimension)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(dimension);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe BitMatrix(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}

		[Register("clear", "()V", "")]
		public unsafe void Clear()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
		}

		[Register("clone", "()Lcom/google/zxing/common/BitMatrix;", "")]
		public new unsafe BitMatrix Clone()
		{
			return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("clone.()Lcom/google/zxing/common/BitMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("flip", "(II)V", "")]
		public unsafe void Flip(int x, int y)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			_members.InstanceMethods.InvokeAbstractVoidMethod("flip.(II)V", this, ptr);
		}

		[Register("get", "(II)Z", "")]
		public unsafe bool Get(int x, int y)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("get.(II)Z", this, ptr);
		}

		[Register("getBottomRightOnBit", "()[I", "")]
		public unsafe int[] GetBottomRightOnBit()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getBottomRightOnBit.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		[Register("getEnclosingRectangle", "()[I", "")]
		public unsafe int[] GetEnclosingRectangle()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getEnclosingRectangle.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		[Register("getRow", "(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", "")]
		public unsafe BitArray GetRow(int y, BitArray row)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(y);
			ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			BitArray result = Java.Lang.Object.GetObject<BitArray>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRow.(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(row);
			return result;
		}

		[Register("getTopLeftOnBit", "()[I", "")]
		public unsafe int[] GetTopLeftOnBit()
		{
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getTopLeftOnBit.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
		}

		[Register("parse", "([[Z)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe static BitMatrix Parse(bool[][] image)
		{
			IntPtr intPtr = JNIEnv.NewArray(image);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.StaticMethods.InvokeObjectMethod("parse.([[Z)Lcom/google/zxing/common/BitMatrix;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (image != null)
				{
					JNIEnv.CopyArray(intPtr, image);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(image);
			return result;
		}

		[Register("parse", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe static BitMatrix Parse(string stringRepresentation, string setString, string unsetString)
		{
			IntPtr intPtr = JNIEnv.NewString(stringRepresentation);
			IntPtr intPtr2 = JNIEnv.NewString(setString);
			IntPtr intPtr3 = JNIEnv.NewString(unsetString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				return Java.Lang.Object.GetObject<BitMatrix>(_members.StaticMethods.InvokeObjectMethod("parse.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/google/zxing/common/BitMatrix;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
			}
		}

		[Register("rotate180", "()V", "")]
		public unsafe void Rotate180()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("rotate180.()V", this, null);
		}

		[Register("set", "(II)V", "")]
		public unsafe void Set(int x, int y)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			_members.InstanceMethods.InvokeAbstractVoidMethod("set.(II)V", this, ptr);
		}

		[Register("setRegion", "(IIII)V", "")]
		public unsafe void SetRegion(int left, int top, int width, int height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(width);
			ptr[3] = new JniArgumentValue(height);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setRegion.(IIII)V", this, ptr);
		}

		[Register("setRow", "(ILcom/google/zxing/common/BitArray;)V", "")]
		public unsafe void SetRow(int y, BitArray row)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(y);
			ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setRow.(ILcom/google/zxing/common/BitArray;)V", this, ptr);
			GC.KeepAlive(row);
		}

		[Register("toString", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string ToString(string setString, string unsetString)
		{
			IntPtr intPtr = JNIEnv.NewString(setString);
			IntPtr intPtr2 = JNIEnv.NewString(unsetString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Obsolete("deprecated")]
		[Register("toString", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string ToString(string setString, string unsetString, string lineSeparator)
		{
			IntPtr intPtr = JNIEnv.NewString(setString);
			IntPtr intPtr2 = JNIEnv.NewString(unsetString);
			IntPtr intPtr3 = JNIEnv.NewString(lineSeparator);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
			}
		}

		[Register("unset", "(II)V", "")]
		public unsafe void Unset(int x, int y)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			_members.InstanceMethods.InvokeAbstractVoidMethod("unset.(II)V", this, ptr);
		}

		[Register("xor", "(Lcom/google/zxing/common/BitMatrix;)V", "")]
		public unsafe void Xor(BitMatrix mask)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mask?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("xor.(Lcom/google/zxing/common/BitMatrix;)V", this, ptr);
			GC.KeepAlive(mask);
		}
	}
	[Register("com/google/zxing/common/BitSource", DoNotGenerateAcw = true)]
	public sealed class BitSource : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/BitSource", typeof(BitSource));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int BitOffset
		{
			[Register("getBitOffset", "()I", "GetGetBitOffsetHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getBitOffset.()I", this, null);
			}
		}

		public unsafe int ByteOffset
		{
			[Register("getByteOffset", "()I", "GetGetByteOffsetHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getByteOffset.()I", this, null);
			}
		}

		internal BitSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "([B)V", "")]
		public unsafe BitSource(byte[] bytes)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(bytes);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("([B)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("([B)V", this, ptr);
			}
			finally
			{
				if (bytes != null)
				{
					JNIEnv.CopyArray(intPtr, bytes);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(bytes);
				}
			}
		}

		[Register("available", "()I", "")]
		public unsafe int Available()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("available.()I", this, null);
		}

		[Register("readBits", "(I)I", "")]
		public unsafe int ReadBits(int numBits)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(numBits);
			return _members.InstanceMethods.InvokeAbstractInt32Method("readBits.(I)I", this, ptr);
		}
	}
	[Register("com/google/zxing/common/CharacterSetECI", DoNotGenerateAcw = true)]
	public sealed class CharacterSetECI : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/CharacterSetECI", typeof(CharacterSetECI));

		[Register("ASCII")]
		public static CharacterSetECI Ascii => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ASCII.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Big5")]
		public static CharacterSetECI Big5 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("Big5.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Cp1250")]
		public static CharacterSetECI Cp1250 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("Cp1250.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Cp1251")]
		public static CharacterSetECI Cp1251 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("Cp1251.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Cp1252")]
		public static CharacterSetECI Cp1252 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("Cp1252.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Cp1256")]
		public static CharacterSetECI Cp1256 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("Cp1256.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Cp437")]
		public static CharacterSetECI Cp437 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("Cp437.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EUC_KR")]
		public static CharacterSetECI EucKr => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("EUC_KR.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GB18030")]
		public static CharacterSetECI Gb18030 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("GB18030.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_1")]
		public static CharacterSetECI Iso88591 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_1.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_10")]
		public static CharacterSetECI Iso885910 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_10.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_11")]
		public static CharacterSetECI Iso885911 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_11.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_13")]
		public static CharacterSetECI Iso885913 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_13.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_14")]
		public static CharacterSetECI Iso885914 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_14.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_15")]
		public static CharacterSetECI Iso885915 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_15.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_16")]
		public static CharacterSetECI Iso885916 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_16.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_2")]
		public static CharacterSetECI Iso88592 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_2.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_3")]
		public static CharacterSetECI Iso88593 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_3.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_4")]
		public static CharacterSetECI Iso88594 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_4.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_5")]
		public static CharacterSetECI Iso88595 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_5.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_6")]
		public static CharacterSetECI Iso88596 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_6.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_7")]
		public static CharacterSetECI Iso88597 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_7.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_8")]
		public static CharacterSetECI Iso88598 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_8.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISO8859_9")]
		public static CharacterSetECI Iso88599 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("ISO8859_9.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SJIS")]
		public static CharacterSetECI Sjis => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("SJIS.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UTF8")]
		public static CharacterSetECI Utf8 => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("UTF8.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UnicodeBigUnmarked")]
		public static CharacterSetECI UnicodeBigUnmarked => Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticFields.GetObjectValue("UnicodeBigUnmarked.Lcom/google/zxing/common/CharacterSetECI;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Value
		{
			[Register("getValue", "()I", "GetGetValueHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getValue.()I", this, null);
			}
		}

		internal CharacterSetECI(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getCharacterSetECIByName", "(Ljava/lang/String;)Lcom/google/zxing/common/CharacterSetECI;", "")]
		public unsafe static CharacterSetECI GetCharacterSetECIByName(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticMethods.InvokeObjectMethod("getCharacterSetECIByName.(Ljava/lang/String;)Lcom/google/zxing/common/CharacterSetECI;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getCharacterSetECIByValue", "(I)Lcom/google/zxing/common/CharacterSetECI;", "")]
		public unsafe static CharacterSetECI GetCharacterSetECIByValue(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticMethods.InvokeObjectMethod("getCharacterSetECIByValue.(I)Lcom/google/zxing/common/CharacterSetECI;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/common/CharacterSetECI;", "")]
		public unsafe static CharacterSetECI ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<CharacterSetECI>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/common/CharacterSetECI;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/common/CharacterSetECI;", "")]
		public unsafe static CharacterSetECI[] Values()
		{
			return (CharacterSetECI[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/common/CharacterSetECI;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(CharacterSetECI));
		}
	}
	[Register("com/google/zxing/common/DecoderResult", DoNotGenerateAcw = true)]
	public sealed class DecoderResult : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/DecoderResult", typeof(DecoderResult));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe IList<byte[]> ByteSegments
		{
			[Register("getByteSegments", "()Ljava/util/List;", "GetGetByteSegmentsHandler")]
			get
			{
				return JavaList<byte[]>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getByteSegments.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ECLevel
		{
			[Register("getECLevel", "()Ljava/lang/String;", "GetGetECLevelHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getECLevel.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Integer Erasures
		{
			[Register("getErasures", "()Ljava/lang/Integer;", "GetGetErasuresHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getErasures.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setErasures", "(Ljava/lang/Integer;)V", "GetSetErasures_Ljava_lang_Integer_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setErasures.(Ljava/lang/Integer;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe Integer ErrorsCorrected
		{
			[Register("getErrorsCorrected", "()Ljava/lang/Integer;", "GetGetErrorsCorrectedHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getErrorsCorrected.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setErrorsCorrected", "(Ljava/lang/Integer;)V", "GetSetErrorsCorrected_Ljava_lang_Integer_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setErrorsCorrected.(Ljava/lang/Integer;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe bool HasStructuredAppend
		{
			[Register("hasStructuredAppend", "()Z", "GetHasStructuredAppendHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasStructuredAppend.()Z", this, null);
			}
		}

		public unsafe int NumBits
		{
			[Register("getNumBits", "()I", "GetGetNumBitsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getNumBits.()I", this, null);
			}
			[Register("setNumBits", "(I)V", "GetSetNumBits_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setNumBits.(I)V", this, ptr);
			}
		}

		public unsafe Java.Lang.Object Other
		{
			[Register("getOther", "()Ljava/lang/Object;", "GetGetOtherHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getOther.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setOther", "(Ljava/lang/Object;)V", "GetSetOther_Ljava_lang_Object_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setOther.(Ljava/lang/Object;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe int StructuredAppendParity
		{
			[Register("getStructuredAppendParity", "()I", "GetGetStructuredAppendParityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getStructuredAppendParity.()I", this, null);
			}
		}

		public unsafe int StructuredAppendSequenceNumber
		{
			[Register("getStructuredAppendSequenceNumber", "()I", "GetGetStructuredAppendSequenceNumberHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getStructuredAppendSequenceNumber.()I", this, null);
			}
		}

		public unsafe string Text
		{
			[Register("getText", "()Ljava/lang/String;", "GetGetTextHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal DecoderResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "([BLjava/lang/String;Ljava/util/List;Ljava/lang/String;)V", "")]
		public unsafe DecoderResult(byte[] rawBytes, string text, IList<byte[]> byteSegments, string ecLevel)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(rawBytes);
			IntPtr intPtr2 = JNIEnv.NewString(text);
			IntPtr intPtr3 = JavaList<byte[]>.ToLocalJniHandle(byteSegments);
			IntPtr intPtr4 = JNIEnv.NewString(ecLevel);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(intPtr4);
				SetHandle(_members.InstanceMethods.StartCreateInstance("([BLjava/lang/String;Ljava/util/List;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("([BLjava/lang/String;Ljava/util/List;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				if (rawBytes != null)
				{
					JNIEnv.CopyArray(intPtr, rawBytes);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				JNIEnv.DeleteLocalRef(intPtr4);
				GC.KeepAlive(rawBytes);
				GC.KeepAlive(byteSegments);
			}
		}

		[Register(".ctor", "([BLjava/lang/String;Ljava/util/List;Ljava/lang/String;II)V", "")]
		public unsafe DecoderResult(byte[] rawBytes, string text, IList<byte[]> byteSegments, string ecLevel, int saSequence, int saParity)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(rawBytes);
			IntPtr intPtr2 = JNIEnv.NewString(text);
			IntPtr intPtr3 = JavaList<byte[]>.ToLocalJniHandle(byteSegments);
			IntPtr intPtr4 = JNIEnv.NewString(ecLevel);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(intPtr4);
				ptr[4] = new JniArgumentValue(saSequence);
				ptr[5] = new JniArgumentValue(saParity);
				SetHandle(_members.InstanceMethods.StartCreateInstance("([BLjava/lang/String;Ljava/util/List;Ljava/lang/String;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("([BLjava/lang/String;Ljava/util/List;Ljava/lang/String;II)V", this, ptr);
			}
			finally
			{
				if (rawBytes != null)
				{
					JNIEnv.CopyArray(intPtr, rawBytes);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				JNIEnv.DeleteLocalRef(intPtr4);
				GC.KeepAlive(rawBytes);
				GC.KeepAlive(byteSegments);
			}
		}

		[Register("getRawBytes", "()[B", "")]
		public unsafe byte[] GetRawBytes()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getRawBytes.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}
	}
	[Register("com/google/zxing/common/DefaultGridSampler", DoNotGenerateAcw = true)]
	public sealed class DefaultGridSampler : GridSampler
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/DefaultGridSampler", typeof(DefaultGridSampler));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DefaultGridSampler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DefaultGridSampler()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("sampleGrid", "(Lcom/google/zxing/common/BitMatrix;IILcom/google/zxing/common/PerspectiveTransform;)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe override BitMatrix SampleGrid(BitMatrix image, int dimensionX, int dimensionY, PerspectiveTransform transform)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dimensionX);
			ptr[2] = new JniArgumentValue(dimensionY);
			ptr[3] = new JniArgumentValue(transform?.Handle ?? IntPtr.Zero);
			BitMatrix result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("sampleGrid.(Lcom/google/zxing/common/BitMatrix;IILcom/google/zxing/common/PerspectiveTransform;)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(image);
			GC.KeepAlive(transform);
			return result;
		}
	}
	[Register("com/google/zxing/common/DetectorResult", DoNotGenerateAcw = true)]
	public class DetectorResult : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/DetectorResult", typeof(DetectorResult));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe BitMatrix Bits
		{
			[Register("getBits", "()Lcom/google/zxing/common/BitMatrix;", "GetGetBitsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBits.()Lcom/google/zxing/common/BitMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected DetectorResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;[Lcom/google/zxing/ResultPoint;)V", "")]
		public unsafe DetectorResult(BitMatrix bits, ResultPoint[] points)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(points);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bits?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;[Lcom/google/zxing/ResultPoint;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;[Lcom/google/zxing/ResultPoint;)V", this, ptr);
			}
			finally
			{
				if (points != null)
				{
					JNIEnv.CopyArray(intPtr, points);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(bits);
					GC.KeepAlive(points);
				}
			}
		}

		[Register("getPoints", "()[Lcom/google/zxing/ResultPoint;", "")]
		public unsafe ResultPoint[] GetPoints()
		{
			return (ResultPoint[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPoints.()[Lcom/google/zxing/ResultPoint;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ResultPoint));
		}
	}
	[Register("com/google/zxing/common/GlobalHistogramBinarizer", DoNotGenerateAcw = true)]
	public class GlobalHistogramBinarizer : Binarizer
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/GlobalHistogramBinarizer", typeof(GlobalHistogramBinarizer));

		private static Delegate cb_getBlackMatrix;

		private static Delegate cb_createBinarizer_Lcom_google_zxing_LuminanceSource_;

		private static Delegate cb_getBlackRow_ILcom_google_zxing_common_BitArray_;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override BitMatrix BlackMatrix
		{
			[Register("getBlackMatrix", "()Lcom/google/zxing/common/BitMatrix;", "GetGetBlackMatrixHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBlackMatrix.()Lcom/google/zxing/common/BitMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected GlobalHistogramBinarizer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/LuminanceSource;)V", "")]
		public unsafe GlobalHistogramBinarizer(LuminanceSource source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/LuminanceSource;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/LuminanceSource;)V", this, ptr);
				GC.KeepAlive(source);
			}
		}

		private static Delegate GetGetBlackMatrixHandler()
		{
			if ((object)cb_getBlackMatrix == null)
			{
				cb_getBlackMatrix = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetBlackMatrix));
			}
			return cb_getBlackMatrix;
		}

		private static IntPtr n_GetBlackMatrix(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GlobalHistogramBinarizer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BlackMatrix);
		}

		private static Delegate GetCreateBinarizer_Lcom_google_zxing_LuminanceSource_Handler()
		{
			if ((object)cb_createBinarizer_Lcom_google_zxing_LuminanceSource_ == null)
			{
				cb_createBinarizer_Lcom_google_zxing_LuminanceSource_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_CreateBinarizer_Lcom_google_zxing_LuminanceSource_));
			}
			return cb_createBinarizer_Lcom_google_zxing_LuminanceSource_;
		}

		private static IntPtr n_CreateBinarizer_Lcom_google_zxing_LuminanceSource_(IntPtr jnienv, IntPtr native__this, IntPtr native_source)
		{
			GlobalHistogramBinarizer globalHistogramBinarizer = Java.Lang.Object.GetObject<GlobalHistogramBinarizer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LuminanceSource p = Java.Lang.Object.GetObject<LuminanceSource>(native_source, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(globalHistogramBinarizer.CreateBinarizer(p));
		}

		[Register("createBinarizer", "(Lcom/google/zxing/LuminanceSource;)Lcom/google/zxing/Binarizer;", "GetCreateBinarizer_Lcom_google_zxing_LuminanceSource_Handler")]
		public unsafe override Binarizer CreateBinarizer(LuminanceSource source)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			Binarizer result = Java.Lang.Object.GetObject<Binarizer>(_members.InstanceMethods.InvokeVirtualObjectMethod("createBinarizer.(Lcom/google/zxing/LuminanceSource;)Lcom/google/zxing/Binarizer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(source);
			return result;
		}

		private static Delegate GetGetBlackRow_ILcom_google_zxing_common_BitArray_Handler()
		{
			if ((object)cb_getBlackRow_ILcom_google_zxing_common_BitArray_ == null)
			{
				cb_getBlackRow_ILcom_google_zxing_common_BitArray_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr, IntPtr>(n_GetBlackRow_ILcom_google_zxing_common_BitArray_));
			}
			return cb_getBlackRow_ILcom_google_zxing_common_BitArray_;
		}

		private static IntPtr n_GetBlackRow_ILcom_google_zxing_common_BitArray_(IntPtr jnienv, IntPtr native__this, int y, IntPtr native_row)
		{
			GlobalHistogramBinarizer globalHistogramBinarizer = Java.Lang.Object.GetObject<GlobalHistogramBinarizer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BitArray p = Java.Lang.Object.GetObject<BitArray>(native_row, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(globalHistogramBinarizer.GetBlackRow(y, p));
		}

		[Register("getBlackRow", "(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", "GetGetBlackRow_ILcom_google_zxing_common_BitArray_Handler")]
		public unsafe override BitArray GetBlackRow(int y, BitArray row)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(y);
			ptr[1] = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
			BitArray result = Java.Lang.Object.GetObject<BitArray>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBlackRow.(ILcom/google/zxing/common/BitArray;)Lcom/google/zxing/common/BitArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(row);
			return result;
		}
	}
	[Register("com/google/zxing/common/GridSampler", DoNotGenerateAcw = true)]
	public abstract class GridSampler : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/GridSampler", typeof(GridSampler));

		private static Delegate cb_sampleGrid_Lcom_google_zxing_common_BitMatrix_IILcom_google_zxing_common_PerspectiveTransform_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe static GridSampler Instance
		{
			[Register("getInstance", "()Lcom/google/zxing/common/GridSampler;", "GetGetInstanceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<GridSampler>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lcom/google/zxing/common/GridSampler;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected GridSampler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GridSampler()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("checkAndNudgePoints", "(Lcom/google/zxing/common/BitMatrix;[F)V", "")]
		protected unsafe static void CheckAndNudgePoints(BitMatrix image, float[] points)
		{
			IntPtr intPtr = JNIEnv.NewArray(points);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("checkAndNudgePoints.(Lcom/google/zxing/common/BitMatrix;[F)V", ptr);
			}
			finally
			{
				if (points != null)
				{
					JNIEnv.CopyArray(intPtr, points);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static Delegate GetSampleGrid_Lcom_google_zxing_common_BitMatrix_IILcom_google_zxing_common_PerspectiveTransform_Handler()
		{
			if ((object)cb_sampleGrid_Lcom_google_zxing_common_BitMatrix_IILcom_google_zxing_common_PerspectiveTransform_ == null)
			{
				cb_sampleGrid_Lcom_google_zxing_common_BitMatrix_IILcom_google_zxing_common_PerspectiveTransform_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, int, int, IntPtr, IntPtr>(n_SampleGrid_Lcom_google_zxing_common_BitMatrix_IILcom_google_zxing_common_PerspectiveTransform_));
			}
			return cb_sampleGrid_Lcom_google_zxing_common_BitMatrix_IILcom_google_zxing_common_PerspectiveTransform_;
		}

		private static IntPtr n_SampleGrid_Lcom_google_zxing_common_BitMatrix_IILcom_google_zxing_common_PerspectiveTransform_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, IntPtr native_p3)
		{
			GridSampler gridSampler = Java.Lang.Object.GetObject<GridSampler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BitMatrix p3 = Java.Lang.Object.GetObject<BitMatrix>(native_p0, JniHandleOwnership.DoNotTransfer);
			PerspectiveTransform p4 = Java.Lang.Object.GetObject<PerspectiveTransform>(native_p3, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(gridSampler.SampleGrid(p3, p1, p2, p4));
		}

		[Register("sampleGrid", "(Lcom/google/zxing/common/BitMatrix;IILcom/google/zxing/common/PerspectiveTransform;)Lcom/google/zxing/common/BitMatrix;", "GetSampleGrid_Lcom_google_zxing_common_BitMatrix_IILcom_google_zxing_common_PerspectiveTransform_Handler")]
		public abstract BitMatrix SampleGrid(BitMatrix p0, int p1, int p2, PerspectiveTransform p3);

		[Register("setGridSampler", "(Lcom/google/zxing/common/GridSampler;)V", "")]
		public unsafe static void SetGridSampler(GridSampler newGridSampler)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(newGridSampler?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setGridSampler.(Lcom/google/zxing/common/GridSampler;)V", ptr);
		}
	}
	[Register("com/google/zxing/common/GridSampler", DoNotGenerateAcw = true)]
	internal class GridSamplerInvoker : GridSampler
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/common/GridSampler", typeof(GridSamplerInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public GridSamplerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("sampleGrid", "(Lcom/google/zxing/common/BitMatrix;IILcom/google/zxing/common/PerspectiveTransform;)Lcom/google/zxing/common/BitMatrix;", "GetSampleGrid_Lcom_google_zxing_common_BitMatrix_IILcom_google_zxing_common_PerspectiveTransform_Handler")]
		public unsafe override BitMatrix SampleGrid(BitMatrix p0, int p1, int p2, PerspectiveTransform p3)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
			BitMatrix result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("sampleGrid.(Lcom/google/zxing/common/BitMatrix;IILcom/google/zxing/common/PerspectiveTransform;)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(p0);
			GC.KeepAlive(p3);
			return result;
		}
	}
	[Register("com/google/zxing/common/HybridBinarizer", DoNotGenerateAcw = true)]
	public sealed class HybridBinarizer : GlobalHistogramBinarizer
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/HybridBinarizer", typeof(HybridBinarizer));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal HybridBinarizer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/LuminanceSource;)V", "")]
		public unsafe HybridBinarizer(LuminanceSource source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/LuminanceSource;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/LuminanceSource;)V", this, ptr);
				GC.KeepAlive(source);
			}
		}
	}
	[Register("com/google/zxing/common/PerspectiveTransform", DoNotGenerateAcw = true)]
	public sealed class PerspectiveTransform : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/PerspectiveTransform", typeof(PerspectiveTransform));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal PerspectiveTransform(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("quadrilateralToSquare", "(FFFFFFFF)Lcom/google/zxing/common/PerspectiveTransform;", "")]
		public unsafe static PerspectiveTransform QuadrilateralToSquare(float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(x0);
			ptr[1] = new JniArgumentValue(y0);
			ptr[2] = new JniArgumentValue(x1);
			ptr[3] = new JniArgumentValue(y1);
			ptr[4] = new JniArgumentValue(x2);
			ptr[5] = new JniArgumentValue(y2);
			ptr[6] = new JniArgumentValue(x3);
			ptr[7] = new JniArgumentValue(y3);
			return Java.Lang.Object.GetObject<PerspectiveTransform>(_members.StaticMethods.InvokeObjectMethod("quadrilateralToSquare.(FFFFFFFF)Lcom/google/zxing/common/PerspectiveTransform;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("squareToQuadrilateral", "(FFFFFFFF)Lcom/google/zxing/common/PerspectiveTransform;", "")]
		public unsafe static PerspectiveTransform SquareToQuadrilateral(float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(x0);
			ptr[1] = new JniArgumentValue(y0);
			ptr[2] = new JniArgumentValue(x1);
			ptr[3] = new JniArgumentValue(y1);
			ptr[4] = new JniArgumentValue(x2);
			ptr[5] = new JniArgumentValue(y2);
			ptr[6] = new JniArgumentValue(x3);
			ptr[7] = new JniArgumentValue(y3);
			return Java.Lang.Object.GetObject<PerspectiveTransform>(_members.StaticMethods.InvokeObjectMethod("squareToQuadrilateral.(FFFFFFFF)Lcom/google/zxing/common/PerspectiveTransform;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("transformPoints", "([F)V", "")]
		public unsafe void TransformPoints(float[] points)
		{
			IntPtr intPtr = JNIEnv.NewArray(points);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("transformPoints.([F)V", this, ptr);
			}
			finally
			{
				if (points != null)
				{
					JNIEnv.CopyArray(intPtr, points);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(points);
				}
			}
		}

		[Register("transformPoints", "([F[F)V", "")]
		public unsafe void TransformPoints(float[] xValues, float[] yValues)
		{
			IntPtr intPtr = JNIEnv.NewArray(xValues);
			IntPtr intPtr2 = JNIEnv.NewArray(yValues);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeAbstractVoidMethod("transformPoints.([F[F)V", this, ptr);
			}
			finally
			{
				if (xValues != null)
				{
					JNIEnv.CopyArray(intPtr, xValues);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (yValues != null)
				{
					JNIEnv.CopyArray(intPtr2, yValues);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(xValues);
					GC.KeepAlive(yValues);
				}
			}
		}
	}
	[Register("com/google/zxing/common/StringUtils", DoNotGenerateAcw = true)]
	public sealed class StringUtils : Java.Lang.Object
	{
		[Register("GB2312")]
		public const string Gb2312 = "GB2312";

		[Register("SHIFT_JIS")]
		public const string ShiftJis = "SJIS";

		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/StringUtils", typeof(StringUtils));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal StringUtils(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("guessEncoding", "([BLjava/util/Map;)Ljava/lang/String;", "")]
		public unsafe static string GuessEncoding(byte[] bytes, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewArray(bytes);
			IntPtr intPtr2 = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			string result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				result = JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("guessEncoding.([BLjava/util/Map;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (bytes != null)
				{
					JNIEnv.CopyArray(intPtr, bytes);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(bytes);
			GC.KeepAlive(hints);
			return result;
		}
	}
}
namespace Google.ZXing.Common.ReedSolomon
{
	[Register("com/google/zxing/common/reedsolomon/GenericGF", DoNotGenerateAcw = true)]
	public sealed class GenericGF : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/reedsolomon/GenericGF", typeof(GenericGF));

		[Register("AZTEC_DATA_10")]
		public static GenericGF AztecData10 => Java.Lang.Object.GetObject<GenericGF>(_members.StaticFields.GetObjectValue("AZTEC_DATA_10.Lcom/google/zxing/common/reedsolomon/GenericGF;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("AZTEC_DATA_12")]
		public static GenericGF AztecData12 => Java.Lang.Object.GetObject<GenericGF>(_members.StaticFields.GetObjectValue("AZTEC_DATA_12.Lcom/google/zxing/common/reedsolomon/GenericGF;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("AZTEC_DATA_6")]
		public static GenericGF AztecData6 => Java.Lang.Object.GetObject<GenericGF>(_members.StaticFields.GetObjectValue("AZTEC_DATA_6.Lcom/google/zxing/common/reedsolomon/GenericGF;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("AZTEC_DATA_8")]
		public static GenericGF AztecData8 => Java.Lang.Object.GetObject<GenericGF>(_members.StaticFields.GetObjectValue("AZTEC_DATA_8.Lcom/google/zxing/common/reedsolomon/GenericGF;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("AZTEC_PARAM")]
		public static GenericGF AztecParam => Java.Lang.Object.GetObject<GenericGF>(_members.StaticFields.GetObjectValue("AZTEC_PARAM.Lcom/google/zxing/common/reedsolomon/GenericGF;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DATA_MATRIX_FIELD_256")]
		public static GenericGF DataMatrixField256 => Java.Lang.Object.GetObject<GenericGF>(_members.StaticFields.GetObjectValue("DATA_MATRIX_FIELD_256.Lcom/google/zxing/common/reedsolomon/GenericGF;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MAXICODE_FIELD_64")]
		public static GenericGF MaxicodeField64 => Java.Lang.Object.GetObject<GenericGF>(_members.StaticFields.GetObjectValue("MAXICODE_FIELD_64.Lcom/google/zxing/common/reedsolomon/GenericGF;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("QR_CODE_FIELD_256")]
		public static GenericGF QrCodeField256 => Java.Lang.Object.GetObject<GenericGF>(_members.StaticFields.GetObjectValue("QR_CODE_FIELD_256.Lcom/google/zxing/common/reedsolomon/GenericGF;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int GeneratorBase
		{
			[Register("getGeneratorBase", "()I", "GetGetGeneratorBaseHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getGeneratorBase.()I", this, null);
			}
		}

		public unsafe int Size
		{
			[Register("getSize", "()I", "GetGetSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getSize.()I", this, null);
			}
		}

		internal GenericGF(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(III)V", "")]
		public unsafe GenericGF(int primitive, int size, int b)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(primitive);
				ptr[1] = new JniArgumentValue(size);
				ptr[2] = new JniArgumentValue(b);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(III)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(III)V", this, ptr);
			}
		}
	}
	[Register("com/google/zxing/common/reedsolomon/GenericGFPoly", DoNotGenerateAcw = true)]
	public sealed class GenericGFPoly : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/reedsolomon/GenericGFPoly", typeof(GenericGFPoly));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal GenericGFPoly(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/common/reedsolomon/ReedSolomonDecoder", DoNotGenerateAcw = true)]
	public sealed class ReedSolomonDecoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/reedsolomon/ReedSolomonDecoder", typeof(ReedSolomonDecoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ReedSolomonDecoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/reedsolomon/GenericGF;)V", "")]
		public unsafe ReedSolomonDecoder(GenericGF field)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/reedsolomon/GenericGF;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/reedsolomon/GenericGF;)V", this, ptr);
				GC.KeepAlive(field);
			}
		}

		[Register("decode", "([II)V", "")]
		public unsafe void Decode(int[] received, int twoS)
		{
			IntPtr intPtr = JNIEnv.NewArray(received);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(twoS);
				_members.InstanceMethods.InvokeAbstractVoidMethod("decode.([II)V", this, ptr);
			}
			finally
			{
				if (received != null)
				{
					JNIEnv.CopyArray(intPtr, received);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(received);
				}
			}
		}
	}
	[Register("com/google/zxing/common/reedsolomon/ReedSolomonEncoder", DoNotGenerateAcw = true)]
	public sealed class ReedSolomonEncoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/reedsolomon/ReedSolomonEncoder", typeof(ReedSolomonEncoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ReedSolomonEncoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/reedsolomon/GenericGF;)V", "")]
		public unsafe ReedSolomonEncoder(GenericGF field)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(field?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/reedsolomon/GenericGF;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/reedsolomon/GenericGF;)V", this, ptr);
				GC.KeepAlive(field);
			}
		}

		[Register("encode", "([II)V", "")]
		public unsafe void Encode(int[] toEncode, int ecBytes)
		{
			IntPtr intPtr = JNIEnv.NewArray(toEncode);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(ecBytes);
				_members.InstanceMethods.InvokeAbstractVoidMethod("encode.([II)V", this, ptr);
			}
			finally
			{
				if (toEncode != null)
				{
					JNIEnv.CopyArray(intPtr, toEncode);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(toEncode);
				}
			}
		}
	}
	[Register("com/google/zxing/common/reedsolomon/ReedSolomonException", DoNotGenerateAcw = true)]
	public sealed class ReedSolomonException : Java.Lang.Exception
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/reedsolomon/ReedSolomonException", typeof(ReedSolomonException));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ReedSolomonException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe ReedSolomonException(string message)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
}
namespace Google.ZXing.Common.Detector
{
	[Register("com/google/zxing/common/detector/MathUtils", DoNotGenerateAcw = true)]
	public sealed class MathUtils : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/detector/MathUtils", typeof(MathUtils));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MathUtils(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("distance", "(FFFF)F", "")]
		public unsafe static float Distance(float aX, float aY, float bX, float bY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(aX);
			ptr[1] = new JniArgumentValue(aY);
			ptr[2] = new JniArgumentValue(bX);
			ptr[3] = new JniArgumentValue(bY);
			return _members.StaticMethods.InvokeSingleMethod("distance.(FFFF)F", ptr);
		}

		[Register("distance", "(IIII)F", "")]
		public unsafe static float Distance(int aX, int aY, int bX, int bY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(aX);
			ptr[1] = new JniArgumentValue(aY);
			ptr[2] = new JniArgumentValue(bX);
			ptr[3] = new JniArgumentValue(bY);
			return _members.StaticMethods.InvokeSingleMethod("distance.(IIII)F", ptr);
		}

		[Register("round", "(F)I", "")]
		public unsafe static int Round(float d)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(d);
			return _members.StaticMethods.InvokeInt32Method("round.(F)I", ptr);
		}

		[Register("sum", "([I)I", "")]
		public unsafe static int Sum(int[] array)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			int result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = _members.StaticMethods.InvokeInt32Method("sum.([I)I", ptr);
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(array);
			return result;
		}
	}
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/google/zxing/common/detector/MonochromeRectangleDetector", DoNotGenerateAcw = true)]
	public sealed class MonochromeRectangleDetector : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/detector/MonochromeRectangleDetector", typeof(MonochromeRectangleDetector));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MonochromeRectangleDetector(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;)V", "")]
		public unsafe MonochromeRectangleDetector(BitMatrix image)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", this, ptr);
				GC.KeepAlive(image);
			}
		}

		[Register("detect", "()[Lcom/google/zxing/ResultPoint;", "")]
		public unsafe ResultPoint[] Detect()
		{
			return (ResultPoint[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("detect.()[Lcom/google/zxing/ResultPoint;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ResultPoint));
		}
	}
	[Register("com/google/zxing/common/detector/WhiteRectangleDetector", DoNotGenerateAcw = true)]
	public sealed class WhiteRectangleDetector : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/common/detector/WhiteRectangleDetector", typeof(WhiteRectangleDetector));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal WhiteRectangleDetector(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;)V", "")]
		public unsafe WhiteRectangleDetector(BitMatrix image)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", this, ptr);
				GC.KeepAlive(image);
			}
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;III)V", "")]
		public unsafe WhiteRectangleDetector(BitMatrix image, int initSize, int x, int y)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(initSize);
				ptr[2] = new JniArgumentValue(x);
				ptr[3] = new JniArgumentValue(y);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;III)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;III)V", this, ptr);
				GC.KeepAlive(image);
			}
		}

		[Register("detect", "()[Lcom/google/zxing/ResultPoint;", "")]
		public unsafe ResultPoint[] Detect()
		{
			return (ResultPoint[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("detect.()[Lcom/google/zxing/ResultPoint;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ResultPoint));
		}
	}
}
namespace Google.ZXing.Client.Result
{
	[Register("com/google/zxing/client/result/AbstractDoCoMoResultParser", DoNotGenerateAcw = true)]
	public abstract class AbstractDoCoMoResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/AbstractDoCoMoResultParser", typeof(AbstractDoCoMoResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected AbstractDoCoMoResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/client/result/AbstractDoCoMoResultParser", DoNotGenerateAcw = true)]
	internal class AbstractDoCoMoResultParserInvoker : AbstractDoCoMoResultParser
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/client/result/AbstractDoCoMoResultParser", typeof(AbstractDoCoMoResultParserInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public AbstractDoCoMoResultParserInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ParsedResult;", "GetParse_Lcom_google_zxing_Result_Handler")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ParsedResult result = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(p0);
			return result;
		}
	}
	[Register("com/google/zxing/client/result/AddressBookAUResultParser", DoNotGenerateAcw = true)]
	public sealed class AddressBookAUResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/AddressBookAUResultParser", typeof(AddressBookAUResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AddressBookAUResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AddressBookAUResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/AddressBookParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/AddressBookParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/AddressBookDoCoMoResultParser", DoNotGenerateAcw = true)]
	public sealed class AddressBookDoCoMoResultParser : AbstractDoCoMoResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/AddressBookDoCoMoResultParser", typeof(AddressBookDoCoMoResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AddressBookDoCoMoResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AddressBookDoCoMoResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/AddressBookParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/AddressBookParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/AddressBookParsedResult", DoNotGenerateAcw = true)]
	public sealed class AddressBookParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/AddressBookParsedResult", typeof(AddressBookParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string Birthday
		{
			[Register("getBirthday", "()Ljava/lang/String;", "GetGetBirthdayHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getBirthday.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string InstantMessenger
		{
			[Register("getInstantMessenger", "()Ljava/lang/String;", "GetGetInstantMessengerHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getInstantMessenger.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Note
		{
			[Register("getNote", "()Ljava/lang/String;", "GetGetNoteHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getNote.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Org
		{
			[Register("getOrg", "()Ljava/lang/String;", "GetGetOrgHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getOrg.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Pronunciation
		{
			[Register("getPronunciation", "()Ljava/lang/String;", "GetGetPronunciationHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPronunciation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "GetGetTitleHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal AddressBookParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "([Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)V", "")]
		public unsafe AddressBookParsedResult(string[] names, string[] phoneNumbers, string[] phoneTypes, string[] emails, string[] emailTypes, string[] addresses, string[] addressTypes)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(names);
			IntPtr intPtr2 = JNIEnv.NewArray(phoneNumbers);
			IntPtr intPtr3 = JNIEnv.NewArray(phoneTypes);
			IntPtr intPtr4 = JNIEnv.NewArray(emails);
			IntPtr intPtr5 = JNIEnv.NewArray(emailTypes);
			IntPtr intPtr6 = JNIEnv.NewArray(addresses);
			IntPtr intPtr7 = JNIEnv.NewArray(addressTypes);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(intPtr4);
				ptr[4] = new JniArgumentValue(intPtr5);
				ptr[5] = new JniArgumentValue(intPtr6);
				ptr[6] = new JniArgumentValue(intPtr7);
				SetHandle(_members.InstanceMethods.StartCreateInstance("([Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("([Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)V", this, ptr);
				while (true)
				{
					intPtr = (IntPtr)/*Error near IL_00f6: Stack underflow*/;
					*(?*)(nint)/*Error near IL_00fb: Stack underflow*/ = /*Error near IL_00fb: Stack underflow*/;
					SetHandle(_members.InstanceMethods.StartCreateInstance("([Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("([Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;[Ljava/lang/String;)V", this, ptr);
				}
			}
			finally
			{
				if (names != null)
				{
					JNIEnv.CopyArray(intPtr, names);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (phoneNumbers != null)
				{
					JNIEnv.CopyArray(intPtr2, phoneNumbers);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				if (phoneTypes != null)
				{
					JNIEnv.CopyArray(intPtr3, phoneTypes);
					JNIEnv.DeleteLocalRef(intPtr3);
				}
				if (emails != null)
				{
					JNIEnv.CopyArray(intPtr4, emails);
					JNIEnv.DeleteLocalRef(intPtr4);
				}
				if (emailTypes != null)
				{
					JNIEnv.CopyArray(intPtr5, emailTypes);
					JNIEnv.DeleteLocalRef(intPtr5);
				}
				if (addresses != null)
				{
					JNIEnv.CopyArray(intPtr6, addresses);
					JNIEnv.DeleteLocalRef(intPtr6);
				}
				if (addressTypes != null)
				{
					JNIEnv.CopyArray(intPtr7, addressTypes);
					JNIEnv.DeleteLocalRef(intPtr7);
					GC.KeepAlive(names);
					GC.KeepAlive(phoneNumbers);
					GC.KeepAlive(phoneTypes);
					GC.KeepAlive(emails);
					GC.KeepAlive(emailTypes);
					GC.KeepAlive(addresses);
					GC.KeepAlive(addressTypes);
				}
			}
		}

		[Register("getAddressTypes", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetAddressTypes()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getAddressTypes.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getAddresses", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetAddresses()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getAddresses.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getEmailTypes", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetEmailTypes()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getEmailTypes.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getEmails", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetEmails()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getEmails.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getGeo", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetGeo()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getGeo.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getNames", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetNames()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getNames.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getNicknames", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetNicknames()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getNicknames.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getPhoneNumbers", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetPhoneNumbers()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getPhoneNumbers.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getPhoneTypes", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetPhoneTypes()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getPhoneTypes.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getURLs", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetURLs()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getURLs.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}
	}
	[Register("com/google/zxing/client/result/BizcardResultParser", DoNotGenerateAcw = true)]
	public sealed class BizcardResultParser : AbstractDoCoMoResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/BizcardResultParser", typeof(BizcardResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BizcardResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BizcardResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/AddressBookParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/AddressBookParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/BookmarkDoCoMoResultParser", DoNotGenerateAcw = true)]
	public sealed class BookmarkDoCoMoResultParser : AbstractDoCoMoResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/BookmarkDoCoMoResultParser", typeof(BookmarkDoCoMoResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BookmarkDoCoMoResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BookmarkDoCoMoResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/URIParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/URIParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/CalendarParsedResult", DoNotGenerateAcw = true)]
	public sealed class CalendarParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/CalendarParsedResult", typeof(CalendarParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string Description
		{
			[Register("getDescription", "()Ljava/lang/String;", "GetGetDescriptionHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe Date End
		{
			[Register("getEnd", "()Ljava/util/Date;", "GetGetEndHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getEnd.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe long EndTimestamp
		{
			[Register("getEndTimestamp", "()J", "GetGetEndTimestampHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getEndTimestamp.()J", this, null);
			}
		}

		public unsafe bool IsEndAllDay
		{
			[Register("isEndAllDay", "()Z", "GetIsEndAllDayHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isEndAllDay.()Z", this, null);
			}
		}

		public unsafe bool IsStartAllDay
		{
			[Register("isStartAllDay", "()Z", "GetIsStartAllDayHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isStartAllDay.()Z", this, null);
			}
		}

		public unsafe double Latitude
		{
			[Register("getLatitude", "()D", "GetGetLatitudeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractDoubleMethod("getLatitude.()D", this, null);
			}
		}

		public unsafe string Location
		{
			[Register("getLocation", "()Ljava/lang/String;", "GetGetLocationHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getLocation.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe double Longitude
		{
			[Register("getLongitude", "()D", "GetGetLongitudeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractDoubleMethod("getLongitude.()D", this, null);
			}
		}

		public unsafe string Organizer
		{
			[Register("getOrganizer", "()Ljava/lang/String;", "GetGetOrganizerHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getOrganizer.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe Date Start
		{
			[Register("getStart", "()Ljava/util/Date;", "GetGetStartHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeAbstractObjectMethod("getStart.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe long StartTimestamp
		{
			[Register("getStartTimestamp", "()J", "GetGetStartTimestampHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getStartTimestamp.()J", this, null);
			}
		}

		public unsafe string Summary
		{
			[Register("getSummary", "()Ljava/lang/String;", "GetGetSummaryHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSummary.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CalendarParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;DD)V", "")]
		public unsafe CalendarParsedResult(string summary, string startString, string endString, string durationString, string location, string organizer, string[] attendees, string description, double latitude, double longitude)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(summary);
			IntPtr intPtr2 = JNIEnv.NewString(startString);
			IntPtr intPtr3 = JNIEnv.NewString(endString);
			IntPtr intPtr4 = JNIEnv.NewString(durationString);
			IntPtr intPtr5 = JNIEnv.NewString(location);
			IntPtr intPtr6 = JNIEnv.NewString(organizer);
			IntPtr intPtr7 = JNIEnv.NewArray(attendees);
			IntPtr intPtr8 = JNIEnv.NewString(description);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(intPtr4);
				ptr[4] = new JniArgumentValue(intPtr5);
				ptr[5] = new JniArgumentValue(intPtr6);
				ptr[6] = new JniArgumentValue(intPtr7);
				ptr[7] = new JniArgumentValue(intPtr8);
				ptr[8] = new JniArgumentValue(latitude);
				ptr[9] = new JniArgumentValue(longitude);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;DD)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;DD)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				JNIEnv.DeleteLocalRef(intPtr4);
				JNIEnv.DeleteLocalRef(intPtr5);
				JNIEnv.DeleteLocalRef(intPtr6);
				if (attendees != null)
				{
					JNIEnv.CopyArray(intPtr7, attendees);
					JNIEnv.DeleteLocalRef(intPtr7);
				}
				JNIEnv.DeleteLocalRef(intPtr8);
				GC.KeepAlive(attendees);
			}
		}

		[Register("getAttendees", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetAttendees()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getAttendees.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}
	}
	[Register("com/google/zxing/client/result/EmailAddressParsedResult", DoNotGenerateAcw = true)]
	public sealed class EmailAddressParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/EmailAddressParsedResult", typeof(EmailAddressParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string Body
		{
			[Register("getBody", "()Ljava/lang/String;", "GetGetBodyHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getBody.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe string EmailAddress
		{
			[Register("getEmailAddress", "()Ljava/lang/String;", "GetGetEmailAddressHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getEmailAddress.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe string MailtoURI
		{
			[Register("getMailtoURI", "()Ljava/lang/String;", "GetGetMailtoURIHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getMailtoURI.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Subject
		{
			[Register("getSubject", "()Ljava/lang/String;", "GetGetSubjectHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSubject.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal EmailAddressParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getBCCs", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetBCCs()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getBCCs.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getCCs", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetCCs()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getCCs.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getTos", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetTos()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getTos.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}
	}
	[Register("com/google/zxing/client/result/EmailAddressResultParser", DoNotGenerateAcw = true)]
	public sealed class EmailAddressResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/EmailAddressResultParser", typeof(EmailAddressResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal EmailAddressResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EmailAddressResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/EmailAddressParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/EmailAddressParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/EmailDoCoMoResultParser", DoNotGenerateAcw = true)]
	public sealed class EmailDoCoMoResultParser : AbstractDoCoMoResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/EmailDoCoMoResultParser", typeof(EmailDoCoMoResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal EmailDoCoMoResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EmailDoCoMoResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/EmailAddressParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/EmailAddressParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/ExpandedProductParsedResult", DoNotGenerateAcw = true)]
	public sealed class ExpandedProductParsedResult : ParsedResult
	{
		[Register("KILOGRAM")]
		public const string Kilogram = "KG";

		[Register("POUND")]
		public const string Pound = "LB";

		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/ExpandedProductParsedResult", typeof(ExpandedProductParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string BestBeforeDate
		{
			[Register("getBestBeforeDate", "()Ljava/lang/String;", "GetGetBestBeforeDateHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getBestBeforeDate.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ExpirationDate
		{
			[Register("getExpirationDate", "()Ljava/lang/String;", "GetGetExpirationDateHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getExpirationDate.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string LotNumber
		{
			[Register("getLotNumber", "()Ljava/lang/String;", "GetGetLotNumberHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getLotNumber.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string PackagingDate
		{
			[Register("getPackagingDate", "()Ljava/lang/String;", "GetGetPackagingDateHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPackagingDate.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Price
		{
			[Register("getPrice", "()Ljava/lang/String;", "GetGetPriceHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPrice.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string PriceCurrency
		{
			[Register("getPriceCurrency", "()Ljava/lang/String;", "GetGetPriceCurrencyHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPriceCurrency.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string PriceIncrement
		{
			[Register("getPriceIncrement", "()Ljava/lang/String;", "GetGetPriceIncrementHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPriceIncrement.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ProductID
		{
			[Register("getProductID", "()Ljava/lang/String;", "GetGetProductIDHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getProductID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ProductionDate
		{
			[Register("getProductionDate", "()Ljava/lang/String;", "GetGetProductionDateHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getProductionDate.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string RawText
		{
			[Register("getRawText", "()Ljava/lang/String;", "GetGetRawTextHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getRawText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Sscc
		{
			[Register("getSscc", "()Ljava/lang/String;", "GetGetSsccHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSscc.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IDictionary<string, string> UncommonAIs
		{
			[Register("getUncommonAIs", "()Ljava/util/Map;", "GetGetUncommonAIsHandler")]
			get
			{
				return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getUncommonAIs.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Weight
		{
			[Register("getWeight", "()Ljava/lang/String;", "GetGetWeightHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getWeight.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string WeightIncrement
		{
			[Register("getWeightIncrement", "()Ljava/lang/String;", "GetGetWeightIncrementHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getWeightIncrement.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string WeightType
		{
			[Register("getWeightType", "()Ljava/lang/String;", "GetGetWeightTypeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getWeightType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ExpandedProductParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/client/result/ExpandedProductResultParser", DoNotGenerateAcw = true)]
	public sealed class ExpandedProductResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/ExpandedProductResultParser", typeof(ExpandedProductResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ExpandedProductResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ExpandedProductResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ExpandedProductParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ExpandedProductParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/GeoParsedResult", DoNotGenerateAcw = true)]
	public sealed class GeoParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/GeoParsedResult", typeof(GeoParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe double Altitude
		{
			[Register("getAltitude", "()D", "GetGetAltitudeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractDoubleMethod("getAltitude.()D", this, null);
			}
		}

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string GeoURI
		{
			[Register("getGeoURI", "()Ljava/lang/String;", "GetGetGeoURIHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getGeoURI.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe double Latitude
		{
			[Register("getLatitude", "()D", "GetGetLatitudeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractDoubleMethod("getLatitude.()D", this, null);
			}
		}

		public unsafe double Longitude
		{
			[Register("getLongitude", "()D", "GetGetLongitudeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractDoubleMethod("getLongitude.()D", this, null);
			}
		}

		public unsafe string Query
		{
			[Register("getQuery", "()Ljava/lang/String;", "GetGetQueryHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getQuery.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal GeoParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/client/result/GeoResultParser", DoNotGenerateAcw = true)]
	public sealed class GeoResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/GeoResultParser", typeof(GeoResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal GeoResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GeoResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/GeoParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/GeoParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/ISBNParsedResult", DoNotGenerateAcw = true)]
	public sealed class ISBNParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/ISBNParsedResult", typeof(ISBNParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ISBN
		{
			[Register("getISBN", "()Ljava/lang/String;", "GetGetISBNHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getISBN.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ISBNParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/client/result/ISBNResultParser", DoNotGenerateAcw = true)]
	public sealed class ISBNResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/ISBNResultParser", typeof(ISBNResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ISBNResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ISBNResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ISBNParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ISBNParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/ParsedResult", DoNotGenerateAcw = true)]
	public abstract class ParsedResult : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/ParsedResult", typeof(ParsedResult));

		private static Delegate cb_getDisplayResult;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get;
		}

		public unsafe ParsedResultType Type
		{
			[Register("getType", "()Lcom/google/zxing/client/result/ParsedResultType;", "GetGetTypeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ParsedResultType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getType.()Lcom/google/zxing/client/result/ParsedResultType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/client/result/ParsedResultType;)V", "")]
		protected unsafe ParsedResult(ParsedResultType type)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/client/result/ParsedResultType;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/client/result/ParsedResultType;)V", this, ptr);
			}
		}

		private static Delegate GetGetDisplayResultHandler()
		{
			if ((object)cb_getDisplayResult == null)
			{
				cb_getDisplayResult = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetDisplayResult));
			}
			return cb_getDisplayResult;
		}

		private static IntPtr n_GetDisplayResult(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ParsedResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayResult);
		}

		[Register("maybeAppend", "(Ljava/lang/String;Ljava/lang/StringBuilder;)V", "")]
		public unsafe static void MaybeAppend(string value, StringBuilder result)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("maybeAppend.(Ljava/lang/String;Ljava/lang/StringBuilder;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("maybeAppend", "([Ljava/lang/String;Ljava/lang/StringBuilder;)V", "")]
		public unsafe static void MaybeAppend(string[] values, StringBuilder result)
		{
			IntPtr intPtr = JNIEnv.NewArray(values);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("maybeAppend.([Ljava/lang/String;Ljava/lang/StringBuilder;)V", ptr);
			}
			finally
			{
				if (values != null)
				{
					JNIEnv.CopyArray(intPtr, values);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("toString", "()Ljava/lang/String;", "")]
		public unsafe sealed override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/client/result/ParsedResult", DoNotGenerateAcw = true)]
	internal class ParsedResultInvoker : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/client/result/ParsedResult", typeof(ParsedResultInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public ParsedResultInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/zxing/client/result/ParsedResultType", DoNotGenerateAcw = true)]
	public sealed class ParsedResultType : Java.Lang.Enum
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/ParsedResultType", typeof(ParsedResultType));

		[Register("ADDRESSBOOK")]
		public static ParsedResultType Addressbook => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("ADDRESSBOOK.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("CALENDAR")]
		public static ParsedResultType Calendar => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("CALENDAR.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EMAIL_ADDRESS")]
		public static ParsedResultType EmailAddress => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("EMAIL_ADDRESS.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("GEO")]
		public static ParsedResultType Geo => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("GEO.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ISBN")]
		public static ParsedResultType Isbn => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("ISBN.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PRODUCT")]
		public static ParsedResultType Product => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("PRODUCT.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SMS")]
		public static ParsedResultType Sms => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("SMS.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TEL")]
		public static ParsedResultType Tel => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("TEL.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TEXT")]
		public static ParsedResultType Text => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("TEXT.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("URI")]
		public static ParsedResultType Uri => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("URI.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("VIN")]
		public static ParsedResultType Vin => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("VIN.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("WIFI")]
		public static ParsedResultType Wifi => Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticFields.GetObjectValue("WIFI.Lcom/google/zxing/client/result/ParsedResultType;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ParsedResultType(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/client/result/ParsedResultType;", "")]
		public unsafe static ParsedResultType ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ParsedResultType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/client/result/ParsedResultType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/zxing/client/result/ParsedResultType;", "")]
		public unsafe static ParsedResultType[] Values()
		{
			return (ParsedResultType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/client/result/ParsedResultType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ParsedResultType));
		}
	}
	[Register("com/google/zxing/client/result/ProductParsedResult", DoNotGenerateAcw = true)]
	public sealed class ProductParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/ProductParsedResult", typeof(ProductParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string NormalizedProductID
		{
			[Register("getNormalizedProductID", "()Ljava/lang/String;", "GetGetNormalizedProductIDHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getNormalizedProductID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ProductID
		{
			[Register("getProductID", "()Ljava/lang/String;", "GetGetProductIDHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getProductID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ProductParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/client/result/ProductResultParser", DoNotGenerateAcw = true)]
	public sealed class ProductResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/ProductResultParser", typeof(ProductResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ProductResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ProductResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ProductParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ProductParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/ResultParser", DoNotGenerateAcw = true)]
	public abstract class ResultParser : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/ResultParser", typeof(ResultParser));

		private static Delegate cb_parse_Lcom_google_zxing_Result_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("getMassagedText", "(Lcom/google/zxing/Result;)Ljava/lang/String;", "")]
		protected unsafe static string GetMassagedText(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getMassagedText.(Lcom/google/zxing/Result;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("isStringOfDigits", "(Ljava/lang/CharSequence;I)Z", "")]
		protected unsafe static bool IsStringOfDigits(ICharSequence value, int length)
		{
			IntPtr intPtr = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(length);
				return _members.StaticMethods.InvokeBooleanMethod("isStringOfDigits.(Ljava/lang/CharSequence;I)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		protected static bool IsStringOfDigits(string value, int length)
		{
			Java.Lang.String obj = ((value == null) ? null : new Java.Lang.String(value));
			bool result = IsStringOfDigits(obj, length);
			obj?.Dispose();
			return result;
		}

		[Register("isSubstringOfDigits", "(Ljava/lang/CharSequence;II)Z", "")]
		protected unsafe static bool IsSubstringOfDigits(ICharSequence value, int offset, int length)
		{
			IntPtr intPtr = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(offset);
				ptr[2] = new JniArgumentValue(length);
				return _members.StaticMethods.InvokeBooleanMethod("isSubstringOfDigits.(Ljava/lang/CharSequence;II)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		protected static bool IsSubstringOfDigits(string value, int offset, int length)
		{
			Java.Lang.String obj = ((value == null) ? null : new Java.Lang.String(value));
			bool result = IsSubstringOfDigits(obj, offset, length);
			obj?.Dispose();
			return result;
		}

		[Register("maybeAppend", "(Ljava/lang/String;Ljava/lang/StringBuilder;)V", "")]
		protected unsafe static void MaybeAppend(string value, StringBuilder result)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("maybeAppend.(Ljava/lang/String;Ljava/lang/StringBuilder;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("maybeAppend", "([Ljava/lang/String;Ljava/lang/StringBuilder;)V", "")]
		protected unsafe static void MaybeAppend(string[] value, StringBuilder result)
		{
			IntPtr intPtr = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("maybeAppend.([Ljava/lang/String;Ljava/lang/StringBuilder;)V", ptr);
			}
			finally
			{
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr, value);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("maybeWrap", "(Ljava/lang/String;)[Ljava/lang/String;", "")]
		protected unsafe static string[] MaybeWrap(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (string[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("maybeWrap.(Ljava/lang/String;)[Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetParse_Lcom_google_zxing_Result_Handler()
		{
			if ((object)cb_parse_Lcom_google_zxing_Result_ == null)
			{
				cb_parse_Lcom_google_zxing_Result_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_Parse_Lcom_google_zxing_Result_));
			}
			return cb_parse_Lcom_google_zxing_Result_;
		}

		private static IntPtr n_Parse_Lcom_google_zxing_Result_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ResultParser resultParser = Java.Lang.Object.GetObject<ResultParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Google.ZXing.Result p = Java.Lang.Object.GetObject<Google.ZXing.Result>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(resultParser.Parse(p));
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ParsedResult;", "GetParse_Lcom_google_zxing_Result_Handler")]
		public abstract ParsedResult Parse(Google.ZXing.Result p0);

		[Register("parseHexDigit", "(C)I", "")]
		protected unsafe static int ParseHexDigit(char c)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(c);
			return _members.StaticMethods.InvokeInt32Method("parseHexDigit.(C)I", ptr);
		}

		[Register("parseResult", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ParsedResult;", "")]
		public unsafe static ParsedResult ParseResult(Google.ZXing.Result theResult)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(theResult?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ParsedResult>(_members.StaticMethods.InvokeObjectMethod("parseResult.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ParsedResult;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("unescapeBackslash", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		protected unsafe static string UnescapeBackslash(string escaped)
		{
			IntPtr intPtr = JNIEnv.NewString(escaped);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("unescapeBackslash.(Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/zxing/client/result/ResultParser", DoNotGenerateAcw = true)]
	internal class ResultParserInvoker : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/client/result/ResultParser", typeof(ResultParserInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public ResultParserInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ParsedResult;", "GetParse_Lcom_google_zxing_Result_Handler")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ParsedResult result = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/ParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(p0);
			return result;
		}
	}
	[Register("com/google/zxing/client/result/SMSMMSResultParser", DoNotGenerateAcw = true)]
	public sealed class SMSMMSResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/SMSMMSResultParser", typeof(SMSMMSResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal SMSMMSResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SMSMMSResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/SMSParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/SMSParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/SMSParsedResult", DoNotGenerateAcw = true)]
	public sealed class SMSParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/SMSParsedResult", typeof(SMSParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string Body
		{
			[Register("getBody", "()Ljava/lang/String;", "GetGetBodyHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getBody.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string SMSURI
		{
			[Register("getSMSURI", "()Ljava/lang/String;", "GetGetSMSURIHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSMSURI.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Subject
		{
			[Register("getSubject", "()Ljava/lang/String;", "GetGetSubjectHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSubject.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal SMSParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe SMSParsedResult(string number, string via, string subject, string body)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(number);
			IntPtr intPtr2 = JNIEnv.NewString(via);
			IntPtr intPtr3 = JNIEnv.NewString(subject);
			IntPtr intPtr4 = JNIEnv.NewString(body);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(intPtr4);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				JNIEnv.DeleteLocalRef(intPtr4);
			}
		}

		[Register(".ctor", "([Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe SMSParsedResult(string[] numbers, string[] vias, string subject, string body)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(numbers);
			IntPtr intPtr2 = JNIEnv.NewArray(vias);
			IntPtr intPtr3 = JNIEnv.NewString(subject);
			IntPtr intPtr4 = JNIEnv.NewString(body);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(intPtr4);
				SetHandle(_members.InstanceMethods.StartCreateInstance("([Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("([Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				if (numbers != null)
				{
					JNIEnv.CopyArray(intPtr, numbers);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (vias != null)
				{
					JNIEnv.CopyArray(intPtr2, vias);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				JNIEnv.DeleteLocalRef(intPtr3);
				JNIEnv.DeleteLocalRef(intPtr4);
				GC.KeepAlive(numbers);
				GC.KeepAlive(vias);
			}
		}

		[Register("getNumbers", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetNumbers()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getNumbers.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		[Register("getVias", "()[Ljava/lang/String;", "")]
		public unsafe string[] GetVias()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getVias.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}
	}
	[Register("com/google/zxing/client/result/SMSTOMMSTOResultParser", DoNotGenerateAcw = true)]
	public sealed class SMSTOMMSTOResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/SMSTOMMSTOResultParser", typeof(SMSTOMMSTOResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal SMSTOMMSTOResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SMSTOMMSTOResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/SMSParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/SMSParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/SMTPResultParser", DoNotGenerateAcw = true)]
	public sealed class SMTPResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/SMTPResultParser", typeof(SMTPResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal SMTPResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SMTPResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/EmailAddressParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/EmailAddressParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/TelParsedResult", DoNotGenerateAcw = true)]
	public sealed class TelParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/TelParsedResult", typeof(TelParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Number
		{
			[Register("getNumber", "()Ljava/lang/String;", "GetGetNumberHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getNumber.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string TelURI
		{
			[Register("getTelURI", "()Ljava/lang/String;", "GetGetTelURIHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getTelURI.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "GetGetTitleHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal TelParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe TelParsedResult(string number, string telURI, string title)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(number);
			IntPtr intPtr2 = JNIEnv.NewString(telURI);
			IntPtr intPtr3 = JNIEnv.NewString(title);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
			}
		}
	}
	[Register("com/google/zxing/client/result/TelResultParser", DoNotGenerateAcw = true)]
	public sealed class TelResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/TelResultParser", typeof(TelResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal TelResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TelResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/TelParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/TelParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/TextParsedResult", DoNotGenerateAcw = true)]
	public sealed class TextParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/TextParsedResult", typeof(TextParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Language
		{
			[Register("getLanguage", "()Ljava/lang/String;", "GetGetLanguageHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getLanguage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Text
		{
			[Register("getText", "()Ljava/lang/String;", "GetGetTextHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal TextParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe TextParsedResult(string text, string language)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(text);
			IntPtr intPtr2 = JNIEnv.NewString(language);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}
	}
	[Register("com/google/zxing/client/result/URIParsedResult", DoNotGenerateAcw = true)]
	public sealed class URIParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/URIParsedResult", typeof(URIParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsPossiblyMaliciousURI
		{
			[Register("isPossiblyMaliciousURI", "()Z", "GetIsPossiblyMaliciousURIHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isPossiblyMaliciousURI.()Z", this, null);
			}
		}

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "GetGetTitleHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string URI
		{
			[Register("getURI", "()Ljava/lang/String;", "GetGetURIHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getURI.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal URIParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe URIParsedResult(string uri, string title)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(uri);
			IntPtr intPtr2 = JNIEnv.NewString(title);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}
	}
	[Register("com/google/zxing/client/result/URIResultParser", DoNotGenerateAcw = true)]
	public sealed class URIResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/URIResultParser", typeof(URIResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal URIResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe URIResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/URIParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/URIParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/URLTOResultParser", DoNotGenerateAcw = true)]
	public sealed class URLTOResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/URLTOResultParser", typeof(URLTOResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal URLTOResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe URLTOResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/URIParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/URIParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/VCardResultParser", DoNotGenerateAcw = true)]
	public sealed class VCardResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/VCardResultParser", typeof(VCardResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal VCardResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe VCardResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/AddressBookParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/AddressBookParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/VEventResultParser", DoNotGenerateAcw = true)]
	public sealed class VEventResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/VEventResultParser", typeof(VEventResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal VEventResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe VEventResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/CalendarParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/CalendarParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/VINParsedResult", DoNotGenerateAcw = true)]
	public sealed class VINParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/VINParsedResult", typeof(VINParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string CountryCode
		{
			[Register("getCountryCode", "()Ljava/lang/String;", "GetGetCountryCodeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getCountryCode.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int ModelYear
		{
			[Register("getModelYear", "()I", "GetGetModelYearHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getModelYear.()I", this, null);
			}
		}

		public unsafe char PlantCode
		{
			[Register("getPlantCode", "()C", "GetGetPlantCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractCharMethod("getPlantCode.()C", this, null);
			}
		}

		public unsafe string SequentialNumber
		{
			[Register("getSequentialNumber", "()Ljava/lang/String;", "GetGetSequentialNumberHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSequentialNumber.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string VIN
		{
			[Register("getVIN", "()Ljava/lang/String;", "GetGetVINHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getVIN.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string VehicleAttributes
		{
			[Register("getVehicleAttributes", "()Ljava/lang/String;", "GetGetVehicleAttributesHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getVehicleAttributes.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string VehicleDescriptorSection
		{
			[Register("getVehicleDescriptorSection", "()Ljava/lang/String;", "GetGetVehicleDescriptorSectionHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getVehicleDescriptorSection.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string VehicleIdentifierSection
		{
			[Register("getVehicleIdentifierSection", "()Ljava/lang/String;", "GetGetVehicleIdentifierSectionHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getVehicleIdentifierSection.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string WorldManufacturerID
		{
			[Register("getWorldManufacturerID", "()Ljava/lang/String;", "GetGetWorldManufacturerIDHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorldManufacturerID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal VINParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ICLjava/lang/String;)V", "")]
		public unsafe VINParsedResult(string vin, string worldManufacturerID, string vehicleDescriptorSection, string vehicleIdentifierSection, string countryCode, string vehicleAttributes, int modelYear, char plantCode, string sequentialNumber)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(vin);
			IntPtr intPtr2 = JNIEnv.NewString(worldManufacturerID);
			IntPtr intPtr3 = JNIEnv.NewString(vehicleDescriptorSection);
			IntPtr intPtr4 = JNIEnv.NewString(vehicleIdentifierSection);
			IntPtr intPtr5 = JNIEnv.NewString(countryCode);
			IntPtr intPtr6 = JNIEnv.NewString(vehicleAttributes);
			IntPtr intPtr7 = JNIEnv.NewString(sequentialNumber);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(intPtr4);
				ptr[4] = new JniArgumentValue(intPtr5);
				ptr[5] = new JniArgumentValue(intPtr6);
				ptr[6] = new JniArgumentValue(modelYear);
				ptr[7] = new JniArgumentValue(plantCode);
				ptr[8] = new JniArgumentValue(intPtr7);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ICLjava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ICLjava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				JNIEnv.DeleteLocalRef(intPtr4);
				JNIEnv.DeleteLocalRef(intPtr5);
				JNIEnv.DeleteLocalRef(intPtr6);
				JNIEnv.DeleteLocalRef(intPtr7);
			}
		}
	}
	[Register("com/google/zxing/client/result/VINResultParser", DoNotGenerateAcw = true)]
	public sealed class VINResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/VINResultParser", typeof(VINResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal VINResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe VINResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/VINParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/VINParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
	[Register("com/google/zxing/client/result/WifiParsedResult", DoNotGenerateAcw = true)]
	public sealed class WifiParsedResult : ParsedResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/WifiParsedResult", typeof(WifiParsedResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string AnonymousIdentity
		{
			[Register("getAnonymousIdentity", "()Ljava/lang/String;", "GetGetAnonymousIdentityHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getAnonymousIdentity.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string DisplayResult
		{
			[Register("getDisplayResult", "()Ljava/lang/String;", "GetGetDisplayResultHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDisplayResult.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string EapMethod
		{
			[Register("getEapMethod", "()Ljava/lang/String;", "GetGetEapMethodHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getEapMethod.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Identity
		{
			[Register("getIdentity", "()Ljava/lang/String;", "GetGetIdentityHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getIdentity.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsHidden
		{
			[Register("isHidden", "()Z", "GetIsHiddenHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isHidden.()Z", this, null);
			}
		}

		public unsafe string NetworkEncryption
		{
			[Register("getNetworkEncryption", "()Ljava/lang/String;", "GetGetNetworkEncryptionHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getNetworkEncryption.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Password
		{
			[Register("getPassword", "()Ljava/lang/String;", "GetGetPasswordHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPassword.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Phase2Method
		{
			[Register("getPhase2Method", "()Ljava/lang/String;", "GetGetPhase2MethodHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPhase2Method.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Ssid
		{
			[Register("getSsid", "()Ljava/lang/String;", "GetGetSsidHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSsid.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal WifiParsedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe WifiParsedResult(string networkEncryption, string ssid, string password)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(networkEncryption);
			IntPtr intPtr2 = JNIEnv.NewString(ssid);
			IntPtr intPtr3 = JNIEnv.NewString(password);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Z)V", "")]
		public unsafe WifiParsedResult(string networkEncryption, string ssid, string password, bool hidden)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(networkEncryption);
			IntPtr intPtr2 = JNIEnv.NewString(ssid);
			IntPtr intPtr3 = JNIEnv.NewString(password);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(hidden);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Z)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe WifiParsedResult(string networkEncryption, string ssid, string password, bool hidden, string identity, string anonymousIdentity, string eapMethod, string phase2Method)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(networkEncryption);
			IntPtr intPtr2 = JNIEnv.NewString(ssid);
			IntPtr intPtr3 = JNIEnv.NewString(password);
			IntPtr intPtr4 = JNIEnv.NewString(identity);
			IntPtr intPtr5 = JNIEnv.NewString(anonymousIdentity);
			IntPtr intPtr6 = JNIEnv.NewString(eapMethod);
			IntPtr intPtr7 = JNIEnv.NewString(phase2Method);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				ptr[3] = new JniArgumentValue(hidden);
				ptr[4] = new JniArgumentValue(intPtr4);
				ptr[5] = new JniArgumentValue(intPtr5);
				ptr[6] = new JniArgumentValue(intPtr6);
				ptr[7] = new JniArgumentValue(intPtr7);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				JNIEnv.DeleteLocalRef(intPtr4);
				JNIEnv.DeleteLocalRef(intPtr5);
				JNIEnv.DeleteLocalRef(intPtr6);
				JNIEnv.DeleteLocalRef(intPtr7);
			}
		}
	}
	[Register("com/google/zxing/client/result/WifiResultParser", DoNotGenerateAcw = true)]
	public sealed class WifiResultParser : ResultParser
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/client/result/WifiResultParser", typeof(WifiResultParser));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal WifiResultParser(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe WifiResultParser()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/WifiParsedResult;", "")]
		public unsafe override ParsedResult Parse(Google.ZXing.Result result)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
			ParsedResult result2 = Java.Lang.Object.GetObject<ParsedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("parse.(Lcom/google/zxing/Result;)Lcom/google/zxing/client/result/WifiParsedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(result);
			return result2;
		}
	}
}
namespace Google.ZXing.Aztec
{
	[Register("com/google/zxing/aztec/AztecDetectorResult", DoNotGenerateAcw = true)]
	public sealed class AztecDetectorResult : DetectorResult
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/AztecDetectorResult", typeof(AztecDetectorResult));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsCompact
		{
			[Register("isCompact", "()Z", "GetIsCompactHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCompact.()Z", this, null);
			}
		}

		public unsafe int NbDatablocks
		{
			[Register("getNbDatablocks", "()I", "GetGetNbDatablocksHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getNbDatablocks.()I", this, null);
			}
		}

		public unsafe int NbLayers
		{
			[Register("getNbLayers", "()I", "GetGetNbLayersHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getNbLayers.()I", this, null);
			}
		}

		internal AztecDetectorResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;[Lcom/google/zxing/ResultPoint;ZII)V", "")]
		public unsafe AztecDetectorResult(BitMatrix bits, ResultPoint[] points, bool compact, int nbDatablocks, int nbLayers)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(points);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(bits?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(compact);
				ptr[3] = new JniArgumentValue(nbDatablocks);
				ptr[4] = new JniArgumentValue(nbLayers);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;[Lcom/google/zxing/ResultPoint;ZII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;[Lcom/google/zxing/ResultPoint;ZII)V", this, ptr);
			}
			finally
			{
				if (points != null)
				{
					JNIEnv.CopyArray(intPtr, points);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(bits);
					GC.KeepAlive(points);
				}
			}
		}
	}
	[Register("com/google/zxing/aztec/AztecReader", DoNotGenerateAcw = true)]
	public sealed class AztecReader : Java.Lang.Object, IReader, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/AztecReader", typeof(AztecReader));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AztecReader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AztecReader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			Result result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(image);
			return result;
		}

		[Register("decode", "(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", "")]
		public unsafe Result Decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			IntPtr intPtr = JavaDictionary<DecodeHintType, object>.ToLocalJniHandle(hints);
			Result result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/BinaryBitmap;Ljava/util/Map;)Lcom/google/zxing/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(image);
			GC.KeepAlive(hints);
			return result;
		}

		[Register("reset", "()V", "")]
		public unsafe void Reset()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("reset.()V", this, null);
		}
	}
	[Register("com/google/zxing/aztec/AztecWriter", DoNotGenerateAcw = true)]
	public sealed class AztecWriter : Java.Lang.Object, IWriter, IJavaObject, IDisposable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/AztecWriter", typeof(AztecWriter));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AztecWriter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AztecWriter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;II)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(format);
			return result;
		}

		[Register("encode", "(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", "")]
		public unsafe BitMatrix Encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			IntPtr intPtr = JNIEnv.NewString(contents);
			IntPtr intPtr2 = JavaDictionary<EncodeHintType, object>.ToLocalJniHandle(hints);
			BitMatrix result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				ptr[4] = new JniArgumentValue(intPtr2);
				result = Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.(Ljava/lang/String;Lcom/google/zxing/BarcodeFormat;IILjava/util/Map;)Lcom/google/zxing/common/BitMatrix;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			GC.KeepAlive(format);
			GC.KeepAlive(hints);
			return result;
		}
	}
}
namespace Google.ZXing.Aztec.Encoder
{
	[Register("com/google/zxing/aztec/encoder/AztecCode", DoNotGenerateAcw = true)]
	public sealed class AztecCode : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/encoder/AztecCode", typeof(AztecCode));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int CodeWords
		{
			[Register("getCodeWords", "()I", "GetGetCodeWordsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getCodeWords.()I", this, null);
			}
			[Register("setCodeWords", "(I)V", "GetSetCodeWords_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setCodeWords.(I)V", this, ptr);
			}
		}

		public unsafe bool Compact
		{
			[Register("isCompact", "()Z", "GetIsCompactHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCompact.()Z", this, null);
			}
			[Register("setCompact", "(Z)V", "GetSetCompact_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setCompact.(Z)V", this, ptr);
			}
		}

		public unsafe int Layers
		{
			[Register("getLayers", "()I", "GetGetLayersHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getLayers.()I", this, null);
			}
			[Register("setLayers", "(I)V", "GetSetLayers_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setLayers.(I)V", this, ptr);
			}
		}

		public unsafe BitMatrix Matrix
		{
			[Register("getMatrix", "()Lcom/google/zxing/common/BitMatrix;", "GetGetMatrixHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BitMatrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMatrix.()Lcom/google/zxing/common/BitMatrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setMatrix", "(Lcom/google/zxing/common/BitMatrix;)V", "GetSetMatrix_Lcom_google_zxing_common_BitMatrix_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setMatrix.(Lcom/google/zxing/common/BitMatrix;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe int Size
		{
			[Register("getSize", "()I", "GetGetSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getSize.()I", this, null);
			}
			[Register("setSize", "(I)V", "GetSetSize_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setSize.(I)V", this, ptr);
			}
		}

		internal AztecCode(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AztecCode()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/google/zxing/aztec/encoder/BinaryShiftToken", DoNotGenerateAcw = true)]
	public sealed class BinaryShiftToken : Token
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/encoder/BinaryShiftToken", typeof(BinaryShiftToken));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BinaryShiftToken(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("appendTo", "(Lcom/google/zxing/common/BitArray;[B)V", "")]
		public unsafe void AppendTo(BitArray bitArray, byte[] text)
		{
			IntPtr intPtr = JNIEnv.NewArray(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bitArray?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("appendTo.(Lcom/google/zxing/common/BitArray;[B)V", this, ptr);
			}
			finally
			{
				if (text != null)
				{
					JNIEnv.CopyArray(intPtr, text);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(bitArray);
					GC.KeepAlive(text);
				}
			}
		}
	}
	[Register("com/google/zxing/aztec/encoder/Encoder", DoNotGenerateAcw = true)]
	public sealed class Encoder : Java.Lang.Object
	{
		[Register("DEFAULT_AZTEC_LAYERS")]
		public const int DefaultAztecLayers = 0;

		[Register("DEFAULT_EC_PERCENT")]
		public const int DefaultEcPercent = 33;

		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/encoder/Encoder", typeof(Encoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Encoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("encode", "([B)Lcom/google/zxing/aztec/encoder/AztecCode;", "")]
		public unsafe static AztecCode Encode(byte[] data)
		{
			IntPtr intPtr = JNIEnv.NewArray(data);
			AztecCode result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<AztecCode>(_members.StaticMethods.InvokeObjectMethod("encode.([B)Lcom/google/zxing/aztec/encoder/AztecCode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (data != null)
				{
					JNIEnv.CopyArray(intPtr, data);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(data);
			return result;
		}

		[Register("encode", "([BII)Lcom/google/zxing/aztec/encoder/AztecCode;", "")]
		public unsafe static AztecCode Encode(byte[] data, int minECCPercent, int userSpecifiedLayers)
		{
			IntPtr intPtr = JNIEnv.NewArray(data);
			AztecCode result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(minECCPercent);
				ptr[2] = new JniArgumentValue(userSpecifiedLayers);
				result = Java.Lang.Object.GetObject<AztecCode>(_members.StaticMethods.InvokeObjectMethod("encode.([BII)Lcom/google/zxing/aztec/encoder/AztecCode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (data != null)
				{
					JNIEnv.CopyArray(intPtr, data);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(data);
			return result;
		}
	}
	[Register("com/google/zxing/aztec/encoder/HighLevelEncoder", DoNotGenerateAcw = true)]
	public sealed class HighLevelEncoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/encoder/HighLevelEncoder", typeof(HighLevelEncoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal HighLevelEncoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "([B)V", "")]
		public unsafe HighLevelEncoder(byte[] text)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("([B)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("([B)V", this, ptr);
			}
			finally
			{
				if (text != null)
				{
					JNIEnv.CopyArray(intPtr, text);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(text);
				}
			}
		}

		[Register("encode", "()Lcom/google/zxing/common/BitArray;", "")]
		public unsafe BitArray Encode()
		{
			return Java.Lang.Object.GetObject<BitArray>(_members.InstanceMethods.InvokeAbstractObjectMethod("encode.()Lcom/google/zxing/common/BitArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/zxing/aztec/encoder/SimpleToken", DoNotGenerateAcw = true)]
	public sealed class SimpleToken : Token
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/encoder/SimpleToken", typeof(SimpleToken));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal SimpleToken(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/aztec/encoder/State", DoNotGenerateAcw = true)]
	public sealed class State : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/encoder/State", typeof(State));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal State(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/aztec/encoder/Token", DoNotGenerateAcw = true)]
	public abstract class Token : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/encoder/Token", typeof(Token));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Token(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/zxing/aztec/encoder/Token", DoNotGenerateAcw = true)]
	internal class TokenInvoker : Token
	{
		internal new static readonly JniPeerMembers _members = new JniPeerMembers("com/google/zxing/aztec/encoder/Token", typeof(TokenInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public TokenInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
}
namespace Google.ZXing.Aztec.Detector
{
	[Register("com/google/zxing/aztec/detector/Detector", DoNotGenerateAcw = true)]
	public sealed class Detector : Java.Lang.Object
	{
		[Register("com/google/zxing/aztec/detector/Detector$Point", DoNotGenerateAcw = true)]
		public sealed class Point : Java.Lang.Object
		{
			internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/detector/Detector$Point", typeof(Point));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Point(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/detector/Detector", typeof(Detector));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Detector(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/zxing/common/BitMatrix;)V", "")]
		public unsafe Detector(BitMatrix image)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/zxing/common/BitMatrix;)V", this, ptr);
				GC.KeepAlive(image);
			}
		}

		[Register("detect", "()Lcom/google/zxing/aztec/AztecDetectorResult;", "")]
		public unsafe AztecDetectorResult Detect()
		{
			return Java.Lang.Object.GetObject<AztecDetectorResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("detect.()Lcom/google/zxing/aztec/AztecDetectorResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("detect", "(Z)Lcom/google/zxing/aztec/AztecDetectorResult;", "")]
		public unsafe AztecDetectorResult Detect(bool isMirror)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isMirror);
			return Java.Lang.Object.GetObject<AztecDetectorResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("detect.(Z)Lcom/google/zxing/aztec/AztecDetectorResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Google.ZXing.Aztec.Decoder
{
	[Register("com/google/zxing/aztec/decoder/Decoder", DoNotGenerateAcw = true)]
	public sealed class Decoder : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/aztec/decoder/Decoder", typeof(Decoder));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Decoder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Decoder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("decode", "(Lcom/google/zxing/aztec/AztecDetectorResult;)Lcom/google/zxing/common/DecoderResult;", "")]
		public unsafe DecoderResult Decode(AztecDetectorResult detectorResult)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(detectorResult?.Handle ?? IntPtr.Zero);
			DecoderResult result = Java.Lang.Object.GetObject<DecoderResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("decode.(Lcom/google/zxing/aztec/AztecDetectorResult;)Lcom/google/zxing/common/DecoderResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(detectorResult);
			return result;
		}

		[Register("highLevelDecode", "([Z)Ljava/lang/String;", "")]
		public unsafe static string HighLevelDecode(bool[] correctedBits)
		{
			IntPtr intPtr = JNIEnv.NewArray(correctedBits);
			string result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("highLevelDecode.([Z)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (correctedBits != null)
				{
					JNIEnv.CopyArray(intPtr, correctedBits);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(correctedBits);
			return result;
		}
	}
}
