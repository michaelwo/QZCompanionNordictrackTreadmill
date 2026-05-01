using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("ZXing.Net.Mobile.Core")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("redth")]
[assembly: AssemblyTrademark("")]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile259", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyVersion("2.4.1.0")]
namespace ZXing.Mobile;

public class CameraResolution
{
	public int Width { get; set; }

	public int Height { get; set; }
}
public interface IZXingScanner<TOverlayViewType> : IScannerView
{
	TOverlayViewType CustomOverlayView { get; set; }

	bool UseCustomOverlayView { get; set; }

	string TopText { get; set; }

	string BottomText { get; set; }
}
public interface IMobileBarcodeScanner
{
	bool UseCustomOverlay { get; }

	string TopText { get; set; }

	string BottomText { get; set; }

	string CancelButtonText { get; set; }

	string FlashButtonText { get; set; }

	string CameraUnsupportedMessage { get; set; }

	bool IsTorchOn { get; }

	Task<Result> Scan(MobileBarcodeScanningOptions options);

	Task<Result> Scan();

	void ScanContinuously(MobileBarcodeScanningOptions options, Action<Result> scanHandler);

	void ScanContinuously(Action<Result> scanHandler);

	void Cancel();

	void Torch(bool on);

	void AutoFocus();

	void ToggleTorch();

	void PauseAnalysis();

	void ResumeAnalysis();
}
public abstract class MobileBarcodeScannerBase : IMobileBarcodeScanner
{
	public bool UseCustomOverlay { get; set; }

	public string TopText { get; set; }

	public string BottomText { get; set; }

	public string CancelButtonText { get; set; }

	public string FlashButtonText { get; set; }

	public string CameraUnsupportedMessage { get; set; }

	public abstract bool IsTorchOn { get; }

	public MobileBarcodeScannerBase()
	{
		CancelButtonText = "Cancel";
		FlashButtonText = "Flash";
		CameraUnsupportedMessage = "Unable to start Camera for Scanning";
	}

	public abstract Task<Result> Scan(MobileBarcodeScanningOptions options);

	public Task<Result> Scan()
	{
		return Scan(MobileBarcodeScanningOptions.Default);
	}

	public void ScanContinuously(Action<Result> scanHandler)
	{
		ScanContinuously(MobileBarcodeScanningOptions.Default, scanHandler);
	}

	public abstract void ScanContinuously(MobileBarcodeScanningOptions options, Action<Result> scanHandler);

	public abstract void Cancel();

	public abstract void Torch(bool on);

	public abstract void ToggleTorch();

	public abstract void AutoFocus();

	public abstract void PauseAnalysis();

	public abstract void ResumeAnalysis();
}
public class CancelScanRequestEventArgs : EventArgs
{
	public bool Cancel { get; set; }

	public CancelScanRequestEventArgs()
	{
		Cancel = false;
	}
}
public class MobileBarcodeScanningOptions
{
	public delegate CameraResolution CameraResolutionSelectorDelegate(List<CameraResolution> availableResolutions);

	public CameraResolutionSelectorDelegate CameraResolutionSelector { get; set; }

	public List<BarcodeFormat> PossibleFormats { get; set; }

	public bool? TryHarder { get; set; }

	public bool? PureBarcode { get; set; }

	public bool? AutoRotate { get; set; }

	public bool? UseCode39ExtendedMode { get; set; }

	public string CharacterSet { get; set; }

	public bool? TryInverted { get; set; }

	public bool? UseFrontCameraIfAvailable { get; set; }

	public bool? AssumeGS1 { get; set; }

	public bool DisableAutofocus { get; set; }

	public bool UseNativeScanning { get; set; }

	public int DelayBetweenContinuousScans { get; set; }

	public int DelayBetweenAnalyzingFrames { get; set; }

	public int InitialDelayBeforeAnalyzingFrames { get; set; }

	public static MobileBarcodeScanningOptions Default => new MobileBarcodeScanningOptions();

	public MobileBarcodeScanningOptions()
	{
		PossibleFormats = new List<BarcodeFormat>();
		DelayBetweenAnalyzingFrames = 150;
		InitialDelayBeforeAnalyzingFrames = 300;
		DelayBetweenContinuousScans = 1000;
		UseNativeScanning = false;
	}

	public BarcodeReader BuildBarcodeReader()
	{
		BarcodeReader barcodeReader = new BarcodeReader();
		if (TryHarder.HasValue)
		{
			barcodeReader.Options.TryHarder = TryHarder.Value;
		}
		if (PureBarcode.HasValue)
		{
			barcodeReader.Options.PureBarcode = PureBarcode.Value;
		}
		if (AutoRotate.HasValue)
		{
			barcodeReader.AutoRotate = AutoRotate.Value;
		}
		if (UseCode39ExtendedMode.HasValue)
		{
			barcodeReader.Options.UseCode39ExtendedMode = UseCode39ExtendedMode.Value;
		}
		if (!string.IsNullOrEmpty(CharacterSet))
		{
			barcodeReader.Options.CharacterSet = CharacterSet;
		}
		if (TryInverted.HasValue)
		{
			barcodeReader.TryInverted = TryInverted.Value;
		}
		if (AssumeGS1.HasValue)
		{
			barcodeReader.Options.AssumeGS1 = AssumeGS1.Value;
		}
		if (PossibleFormats != null && PossibleFormats.Count > 0)
		{
			barcodeReader.Options.PossibleFormats = new List<BarcodeFormat>();
			foreach (BarcodeFormat possibleFormat in PossibleFormats)
			{
				barcodeReader.Options.PossibleFormats.Add(possibleFormat);
			}
		}
		return barcodeReader;
	}

	public MultiFormatReader BuildMultiFormatReader()
	{
		MultiFormatReader multiFormatReader = new MultiFormatReader();
		Dictionary<DecodeHintType, object> dictionary = new Dictionary<DecodeHintType, object>();
		if (TryHarder.HasValue && TryHarder.Value)
		{
			dictionary.Add(DecodeHintType.TRY_HARDER, TryHarder.Value);
		}
		if (PureBarcode.HasValue && PureBarcode.Value)
		{
			dictionary.Add(DecodeHintType.PURE_BARCODE, PureBarcode.Value);
		}
		if (PossibleFormats != null && PossibleFormats.Count > 0)
		{
			dictionary.Add(DecodeHintType.POSSIBLE_FORMATS, PossibleFormats);
		}
		multiFormatReader.Hints = dictionary;
		return multiFormatReader;
	}

	public CameraResolution GetResolution(List<CameraResolution> availableResolutions)
	{
		CameraResolution result = null;
		CameraResolutionSelectorDelegate cameraResolutionSelector = CameraResolutionSelector;
		if (cameraResolutionSelector != null)
		{
			result = cameraResolutionSelector(availableResolutions);
		}
		return result;
	}
}
public class PerformanceCounter
{
	private static Dictionary<string, Stopwatch> counters = new Dictionary<string, Stopwatch>();

	public static string Start()
	{
		string text = Guid.NewGuid().ToString();
		Stopwatch stopwatch = new Stopwatch();
		counters.Add(text, stopwatch);
		stopwatch.Start();
		return text;
	}

	public static TimeSpan Stop(string guid)
	{
		if (!counters.ContainsKey(guid))
		{
			return TimeSpan.Zero;
		}
		Stopwatch stopwatch = counters[guid];
		stopwatch.Stop();
		counters.Remove(guid);
		return stopwatch.Elapsed;
	}

	public static void Stop(string guid, string msg)
	{
		Stop(guid);
		if (!msg.Contains("{0}"))
		{
			msg += " {0}";
		}
		_ = Debugger.IsAttached;
	}
}
public interface IScannerView
{
	bool IsTorchOn { get; }

	bool IsAnalyzing { get; }

	bool HasTorch { get; }

	void StartScanning(Action<Result> scanResultHandler, MobileBarcodeScanningOptions options = null);

	void StopScanning();

	void PauseAnalysis();

	void ResumeAnalysis();

	void Torch(bool on);

	void AutoFocus();

	void AutoFocus(int x, int y);

	void ToggleTorch();
}
public interface IScannerSessionHost
{
	MobileBarcodeScanningOptions ScanningOptions { get; }
}
