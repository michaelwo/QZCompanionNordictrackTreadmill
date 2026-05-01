using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using ApxLabs.FastAndroidCamera;
using Java.Lang;
using ZXing.Common;
using ZXing.Mobile;
using ZXing.Mobile.CameraAccess;
using ZXing.Net.Mobile.Android;
using ZXing.Rendering;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: AssemblyTitle("ZXing.Net.Mobile.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("redth")]
[assembly: AssemblyTrademark("")]
[assembly: ResourceDesigner("ZXing.Mobile.Resource", IsApplication = false)]
[assembly: UsesPermission("android.permission.CAMERA")]
[assembly: TargetFramework("MonoAndroid,Version=v4.0.3", FrameworkDisplayName = "Xamarin.Android v4.0.3 Support")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("2.4.1.0")]
[module: UnverifiableCode]
namespace ZXing.Net.Mobile.Android
{
	public static class PermissionsHandler
	{
		private static TaskCompletionSource<bool> requestCompletion = null;

		public static Task PermissionRequestTask => requestCompletion?.Task ?? Task.CompletedTask;

		public static bool NeedsPermissionRequest(Context context)
		{
			List<string> list = new List<string>();
			string[] requiredPermissions = ZxingActivity.RequiredPermissions;
			foreach (string permission in requiredPermissions)
			{
				if (IsPermissionInManifest(context, permission) && !IsPermissionGranted(context, permission))
				{
					return true;
				}
			}
			return false;
		}

		public static Task<bool> RequestPermissionsAsync(Activity activity)
		{
			if (requestCompletion != null && !requestCompletion.Task.IsCompleted)
			{
				return requestCompletion.Task;
			}
			List<string> list = new List<string>();
			string[] requiredPermissions = ZxingActivity.RequiredPermissions;
			foreach (string text in requiredPermissions)
			{
				if (IsPermissionInManifest(activity, text) && !IsPermissionGranted(activity, text))
				{
					list.Add(text);
				}
			}
			if (list.Any())
			{
				DoRequestPermissions(activity, list.ToArray(), 101);
				requestCompletion = new TaskCompletionSource<bool>();
				return requestCompletion.Task;
			}
			return Task.FromResult(result: true);
		}

		public static void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			if (requestCompletion == null || requestCompletion.Task.IsCompleted)
			{
				return;
			}
			bool result = true;
			foreach (Permission permission in grantResults)
			{
				if (permission == Permission.Denied)
				{
					result = false;
					break;
				}
			}
			requestCompletion.TrySetResult(result);
		}

		internal static bool IsPermissionInManifest(Context context, string permission)
		{
			try
			{
				PackageInfo packageInfo = context.PackageManager.GetPackageInfo(context.PackageName, PackageInfoFlags.Permissions);
				return packageInfo.RequestedPermissions.Contains(permission);
			}
			catch
			{
			}
			return false;
		}

		internal static bool IsPermissionGranted(Context context, string permission)
		{
			return ContextCompat.CheckSelfPermission(context, permission) == Permission.Granted;
		}

		internal static bool DoRequestPermissions(Activity activity, string[] permissions, int requestCode)
		{
			List<string> list = new List<string>();
			foreach (string text in permissions)
			{
				if (ContextCompat.CheckSelfPermission(activity, text) != Permission.Granted)
				{
					list.Add(text);
				}
			}
			if (list.Any())
			{
				ActivityCompat.RequestPermissions(activity, list.ToArray(), requestCode);
				return true;
			}
			return false;
		}

		internal static bool CheckCameraPermissions(Context context, bool throwOnError = true)
		{
			return CheckPermissions(context, "android.permission.CAMERA", throwOnError);
		}

		internal static bool CheckTorchPermissions(Context context, bool throwOnError = true)
		{
			return CheckPermissions(context, "android.permission.FLASHLIGHT", throwOnError);
		}

		internal static bool CheckPermissions(Context context, string permission, bool throwOnError = true)
		{
			bool result = true;
			string guid = PerformanceCounter.Start();
			Log.Debug("ZXing.Net.Mobile", "Checking " + permission + "...");
			if (!IsPermissionInManifest(context, permission) || !IsPermissionGranted(context, permission))
			{
				result = false;
				if (throwOnError)
				{
					string text = "ZXing.Net.Mobile requires: " + permission + ", but was not found in your AndroidManifest.xml file.";
					Log.Error("ZXing.Net.Mobile", text);
					throw new UnauthorizedAccessException(text);
				}
			}
			PerformanceCounter.Stop(guid, "CheckPermissions took {0}ms");
			return result;
		}
	}
}
namespace ZXing.Mobile
{
	public class ActivityLifecycleContextListener : Java.Lang.Object, Application.IActivityLifecycleCallbacks, IJavaObject, IDisposable
	{
		private Activity currentActivity = null;

		public Context Context => currentActivity ?? Application.Context;

		public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
		{
		}

		public void OnActivityDestroyed(Activity activity)
		{
		}

		public void OnActivityPaused(Activity activity)
		{
		}

		public void OnActivityResumed(Activity activity)
		{
			currentActivity = activity;
		}

		public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
		{
		}

		public void OnActivityStarted(Activity activity)
		{
		}

		public void OnActivityStopped(Activity activity)
		{
		}
	}
	public class BitmapRenderer : IBarcodeRenderer<Bitmap>
	{
		public Color Foreground { get; set; }

		public Color Background { get; set; }

		public BitmapRenderer()
		{
			Foreground = Color.Black;
			Background = Color.White;
		}

		public Bitmap Render(BitMatrix matrix, BarcodeFormat format, string content)
		{
			return Render(matrix, format, content, new EncodingOptions());
		}

		public Bitmap Render(BitMatrix matrix, BarcodeFormat format, string content, EncodingOptions options)
		{
			int width = matrix.Width;
			int height = matrix.Height;
			int[] array = new int[width * height];
			int num = 0;
			int num2 = Foreground.ToArgb();
			int num3 = Background.ToArgb();
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					array[num] = (matrix[j, i] ? num2 : num3);
					num++;
				}
			}
			Bitmap bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
			bitmap.SetPixels(array, 0, width, 0, 0, width, height);
			return bitmap;
		}
	}
	public class BarcodeWriter : BarcodeWriter<Bitmap>, IBarcodeWriter
	{
		public BarcodeWriter()
		{
			base.Renderer = new BitmapRenderer();
		}
	}
	public class MobileBarcodeScanner : MobileBarcodeScannerBase
	{
		public const string TAG = "ZXing.Net.Mobile";

		private static ActivityLifecycleContextListener lifecycleListener;

		private bool torch = false;

		public View CustomOverlay { get; set; }

		public override bool IsTorchOn => torch;

		public static void Initialize(Application app)
		{
			BuildVersionCodes sdkInt = Build.VERSION.SdkInt;
			if (sdkInt >= BuildVersionCodes.IceCreamSandwich)
			{
				lifecycleListener = new ActivityLifecycleContextListener();
				app.RegisterActivityLifecycleCallbacks(lifecycleListener);
			}
		}

		public static void Uninitialize(Application app)
		{
			BuildVersionCodes sdkInt = Build.VERSION.SdkInt;
			if (sdkInt >= BuildVersionCodes.IceCreamSandwich)
			{
				app.UnregisterActivityLifecycleCallbacks(lifecycleListener);
			}
		}

		private Context GetContext(Context context)
		{
			if (context != null)
			{
				return context;
			}
			BuildVersionCodes sdkInt = Build.VERSION.SdkInt;
			if (sdkInt >= BuildVersionCodes.IceCreamSandwich)
			{
				return lifecycleListener.Context;
			}
			return Application.Context;
		}

		public override void ScanContinuously(MobileBarcodeScanningOptions options, Action<Result> scanHandler)
		{
			ScanContinuously(null, options, scanHandler);
		}

		public void ScanContinuously(Context context, MobileBarcodeScanningOptions options, Action<Result> scanHandler)
		{
			Context context2 = GetContext(context);
			Intent intent = new Intent(context2, typeof(ZxingActivity));
			intent.AddFlags(ActivityFlags.NewTask);
			ZxingActivity.UseCustomOverlayView = base.UseCustomOverlay;
			ZxingActivity.CustomOverlayView = CustomOverlay;
			ZxingActivity.ScanningOptions = options;
			ZxingActivity.ScanContinuously = true;
			ZxingActivity.TopText = base.TopText;
			ZxingActivity.BottomText = base.BottomText;
			ZxingActivity.ScanCompletedHandler = delegate(Result result)
			{
				if (scanHandler != null)
				{
					scanHandler(result);
				}
			};
			context2.StartActivity(intent);
		}

		public override Task<Result> Scan(MobileBarcodeScanningOptions options)
		{
			return Scan(null, options);
		}

		public Task<Result> Scan(Context context, MobileBarcodeScanningOptions options)
		{
			Context ctx = GetContext(context);
			return Task.Factory.StartNew(delegate
			{
				ManualResetEvent waitScanResetEvent = new ManualResetEvent(initialState: false);
				Intent intent = new Intent(ctx, typeof(ZxingActivity));
				intent.AddFlags(ActivityFlags.NewTask);
				ZxingActivity.UseCustomOverlayView = base.UseCustomOverlay;
				ZxingActivity.CustomOverlayView = CustomOverlay;
				ZxingActivity.ScanningOptions = options;
				ZxingActivity.ScanContinuously = false;
				ZxingActivity.TopText = base.TopText;
				ZxingActivity.BottomText = base.BottomText;
				Result scanResult = null;
				ZxingActivity.CanceledHandler = delegate
				{
					waitScanResetEvent.Set();
				};
				ZxingActivity.ScanCompletedHandler = delegate(Result result)
				{
					scanResult = result;
					waitScanResetEvent.Set();
				};
				ctx.StartActivity(intent);
				waitScanResetEvent.WaitOne();
				return scanResult;
			});
		}

		public override void Cancel()
		{
			ZxingActivity.RequestCancel();
		}

		public override void AutoFocus()
		{
			ZxingActivity.RequestAutoFocus();
		}

		public override void Torch(bool on)
		{
			torch = on;
			ZxingActivity.RequestTorch(on);
		}

		public override void ToggleTorch()
		{
			Torch(!torch);
		}

		public override void PauseAnalysis()
		{
			ZxingActivity.RequestPauseAnalysis();
		}

		public override void ResumeAnalysis()
		{
			ZxingActivity.RequestResumeAnalysis();
		}

		internal static void LogDebug(string format, params object[] args)
		{
			Log.Debug("ZXING", format, args);
		}

		internal static void LogError(string format, params object[] args)
		{
			Log.Error("ZXING", format, args);
		}

		internal static void LogInfo(string format, params object[] args)
		{
			Log.Info("ZXING", format, args);
		}

		internal static void LogWarn(string format, params object[] args)
		{
			Log.Warn("ZXING", format, args);
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

		public class Id
		{
			public static int contentFrame;

			static Id()
			{
				contentFrame = 2130903040;
				ResourceIdManager.UpdateIdValues();
			}

			private Id()
			{
			}
		}

		public class Layout
		{
			public static int zxingscanneractivitylayout;

			public static int zxingscannerfragmentlayout;

			static Layout()
			{
				zxingscanneractivitylayout = 2130837504;
				zxingscannerfragmentlayout = 2130837505;
				ResourceIdManager.UpdateIdValues();
			}

			private Layout()
			{
			}
		}

		static Resource()
		{
			ResourceIdManager.UpdateIdValues();
		}
	}
	[Activity(Label = "Scanner", ConfigurationChanges = (ConfigChanges.KeyboardHidden | ConfigChanges.Orientation | ConfigChanges.ScreenLayout))]
	public class ZxingActivity : FragmentActivity
	{
		public static readonly string[] RequiredPermissions = new string[2] { "android.permission.CAMERA", "android.permission.FLASHLIGHT" };

		public static Action<Result> ScanCompletedHandler;

		public static Action CanceledHandler;

		public static Action CancelRequestedHandler;

		public static Action<bool> TorchRequestedHandler;

		public static Action AutoFocusRequestedHandler;

		public static Action PauseAnalysisHandler;

		public static Action ResumeAnalysisHandler;

		private ZXingScannerFragment scannerFragment;

		public static View CustomOverlayView { get; set; }

		public static bool UseCustomOverlayView { get; set; }

		public static MobileBarcodeScanningOptions ScanningOptions { get; set; }

		public static string TopText { get; set; }

		public static string BottomText { get; set; }

		public static bool ScanContinuously { get; set; }

		public static void RequestCancel()
		{
			CancelRequestedHandler?.Invoke();
		}

		public static void RequestTorch(bool torchOn)
		{
			TorchRequestedHandler?.Invoke(torchOn);
		}

		public static void RequestAutoFocus()
		{
			AutoFocusRequestedHandler?.Invoke();
		}

		public static void RequestPauseAnalysis()
		{
			PauseAnalysisHandler?.Invoke();
		}

		public static void RequestResumeAnalysis()
		{
			ResumeAnalysisHandler?.Invoke();
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			((Activity)(object)this).RequestWindowFeature(WindowFeatures.NoTitle);
			((Activity)(object)this).Window.AddFlags(WindowManagerFlags.Fullscreen);
			((Activity)(object)this).Window.AddFlags(WindowManagerFlags.KeepScreenOn);
			if (ScanningOptions.AutoRotate.HasValue && !ScanningOptions.AutoRotate.Value)
			{
				((Activity)(object)this).RequestedOrientation = ScreenOrientation.Nosensor;
			}
			((Activity)(object)this).SetContentView(Resource.Layout.zxingscanneractivitylayout);
			scannerFragment = new ZXingScannerFragment();
			scannerFragment.CustomOverlayView = CustomOverlayView;
			scannerFragment.UseCustomOverlayView = UseCustomOverlayView;
			scannerFragment.TopText = TopText;
			scannerFragment.BottomText = BottomText;
			SupportFragmentManager.BeginTransaction().Replace(Resource.Id.contentFrame, scannerFragment, "ZXINGFRAGMENT").Commit();
			CancelRequestedHandler = CancelScan;
			AutoFocusRequestedHandler = AutoFocus;
			TorchRequestedHandler = SetTorch;
			PauseAnalysisHandler = scannerFragment.PauseAnalysis;
			ResumeAnalysisHandler = scannerFragment.ResumeAnalysis;
		}

		protected override void OnResume()
		{
			((Activity)(object)this).OnResume();
			if (PermissionsHandler.NeedsPermissionRequest((Context)(object)this))
			{
				PermissionsHandler.RequestPermissionsAsync((Activity)(object)this);
			}
			else
			{
				StartScanning();
			}
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		private void StartScanning()
		{
			scannerFragment.StartScanning(delegate(Result result)
			{
				ScanCompletedHandler?.Invoke(result);
				if (!ScanContinuously)
				{
					((Activity)(object)this).Finish();
				}
			}, ScanningOptions);
		}

		public override void OnConfigurationChanged(Configuration newConfig)
		{
			((Activity)(object)this).OnConfigurationChanged(newConfig);
			Log.Debug("ZXing.Net.Mobile", "Configuration Changed");
		}

		public void SetTorch(bool on)
		{
			scannerFragment.Torch(on);
		}

		public void AutoFocus()
		{
			scannerFragment.AutoFocus();
		}

		public void CancelScan()
		{
			((Activity)(object)this).Finish();
			CanceledHandler?.Invoke();
		}

		public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
		{
			switch (keyCode)
			{
			case Keycode.Back:
				CancelScan();
				break;
			case Keycode.Focus:
				return true;
			}
			return ((Activity)(object)this).OnKeyDown(keyCode, e);
		}
	}
	public class ZxingOverlayView : View
	{
		private int[] SCANNER_ALPHA = new int[8] { 0, 64, 128, 192, 255, 192, 128, 64 };

		private const long ANIMATION_DELAY = 80L;

		private const int CURRENT_POINT_OPACITY = 160;

		private const int MAX_RESULT_POINTS = 20;

		private const int POINT_SIZE = 6;

		private Paint paint;

		private Bitmap resultBitmap;

		private Color maskColor;

		private Color resultColor;

		private Color frameColor;

		private Color laserColor;

		private int scannerAlpha;

		private List<ResultPoint> possibleResultPoints;

		public string TopText { get; set; }

		public string BottomText { get; set; }

		public ZxingOverlayView(Context context)
			: base(context)
		{
			paint = new Paint(PaintFlags.AntiAlias);
			maskColor = Color.Gray;
			resultColor = Color.Red;
			frameColor = Color.Black;
			laserColor = Color.Red;
			scannerAlpha = 0;
			possibleResultPoints = new List<ResultPoint>(5);
			SetBackgroundColor(Color.Transparent);
		}

		private Rect GetFramingRect(Canvas canvas)
		{
			int num = canvas.Width * 15 / 16;
			int num2 = canvas.Height * 4 / 10;
			int num3 = (canvas.Width - num) / 2;
			int num4 = (canvas.Height - num2) / 2;
			return new Rect(num3, num4, num3 + num, num4 + num2);
		}

		protected override void OnDraw(Canvas canvas)
		{
			float density = base.Context.Resources.DisplayMetrics.Density;
			Rect framingRect = GetFramingRect(canvas);
			if (framingRect != null)
			{
				int width = canvas.Width;
				int height = canvas.Height;
				paint.Color = ((resultBitmap != null) ? resultColor : maskColor);
				paint.Alpha = 100;
				canvas.DrawRect(0f, 0f, width, framingRect.Top, paint);
				canvas.DrawRect(0f, framingRect.Bottom + 1, width, height, paint);
				TextPaint textPaint = new TextPaint();
				textPaint.Color = Color.White;
				textPaint.TextSize = 16f * density;
				StaticLayout staticLayout = new StaticLayout(TopText, textPaint, canvas.Width, Layout.Alignment.AlignCenter, 1f, 0f, includepad: false);
				canvas.Save();
				Rect bounds = new Rect();
				textPaint.GetTextBounds(TopText, 0, TopText.Length, bounds);
				canvas.Translate(0f, framingRect.Top / 2 - staticLayout.Height / 2);
				staticLayout.Draw(canvas);
				canvas.Restore();
				StaticLayout staticLayout2 = new StaticLayout(BottomText, textPaint, canvas.Width, Layout.Alignment.AlignCenter, 1f, 0f, includepad: false);
				canvas.Save();
				Rect bounds2 = new Rect();
				textPaint.GetTextBounds(BottomText, 0, BottomText.Length, bounds2);
				canvas.Translate(0f, framingRect.Bottom + (canvas.Height - framingRect.Bottom) / 2 - staticLayout2.Height / 2);
				staticLayout2.Draw(canvas);
				canvas.Restore();
				if (resultBitmap != null)
				{
					paint.Alpha = 160;
					canvas.DrawBitmap(resultBitmap, null, new RectF(framingRect.Left, framingRect.Top, framingRect.Right, framingRect.Bottom), paint);
				}
				else
				{
					paint.Color = frameColor;
					paint.Color = laserColor;
					paint.Alpha = SCANNER_ALPHA[scannerAlpha];
					scannerAlpha = (scannerAlpha + 1) % SCANNER_ALPHA.Length;
					int num = framingRect.Height() / 2 + framingRect.Top;
					canvas.DrawRect(0f, num - 1, width, num + 2, paint);
					PostInvalidateDelayed(80L, framingRect.Left - 6, framingRect.Top - 6, framingRect.Right + 6, framingRect.Bottom + 6);
				}
				base.OnDraw(canvas);
			}
		}

		public void DrawResultBitmap(Bitmap barcode)
		{
			resultBitmap = barcode;
			Invalidate();
		}

		public void AddPossibleResultPoint(ResultPoint point)
		{
			List<ResultPoint> list = possibleResultPoints;
			lock (list)
			{
				list.Add(point);
				int count = list.Count;
				if (count > 20)
				{
					list.RemoveRange(0, count - 10);
				}
			}
		}
	}
	public class ZXingScannerFragment : AndroidX.Fragment.App.Fragment, IZXingScanner<View>, IScannerView
	{
		private FrameLayout frame;

		private ZXingSurfaceView scanner;

		private ZxingOverlayView zxingOverlay;

		private Action<Result> scanCallback;

		public View CustomOverlayView { get; set; }

		public bool UseCustomOverlayView { get; set; }

		public MobileBarcodeScanningOptions ScanningOptions { get; set; }

		public string TopText { get; set; }

		public string BottomText { get; set; }

		public bool IsTorchOn => scanner?.IsTorchOn ?? false;

		public bool IsAnalyzing => scanner?.IsAnalyzing ?? false;

		public bool HasTorch => scanner?.HasTorch ?? false;

		public ZXingScannerFragment()
		{
			UseCustomOverlayView = false;
		}

		public override View OnCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle bundle)
		{
			frame = (FrameLayout)layoutInflater.Inflate(Resource.Layout.zxingscannerfragmentlayout, viewGroup, attachToRoot: false);
			LinearLayout.LayoutParams childLayoutParams = getChildLayoutParams();
			try
			{
				scanner = new ZXingSurfaceView((Context)(object)base.Activity, ScanningOptions);
				frame.AddView(scanner, childLayoutParams);
				if (!UseCustomOverlayView)
				{
					zxingOverlay = new ZxingOverlayView((Context)(object)base.Activity);
					zxingOverlay.TopText = TopText ?? "";
					zxingOverlay.BottomText = BottomText ?? "";
					frame.AddView(zxingOverlay, childLayoutParams);
				}
				else if (CustomOverlayView != null)
				{
					frame.AddView(CustomOverlayView, childLayoutParams);
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Create Surface View Failed: " + ex);
			}
			Log.Debug("ZXing.Net.Mobile", "ZXingScannerFragment->OnResume exit");
			return frame;
		}

		public override void OnStart()
		{
			base.OnStart();
			if (frame.ChildCount == 0)
			{
				LinearLayout.LayoutParams childLayoutParams = getChildLayoutParams();
				frame.AddView(scanner, childLayoutParams);
				if (!UseCustomOverlayView)
				{
					frame.AddView(zxingOverlay, childLayoutParams);
				}
				else if (CustomOverlayView != null)
				{
					frame.AddView(CustomOverlayView, childLayoutParams);
				}
			}
		}

		public override void OnStop()
		{
			if (scanner != null)
			{
				scanner.StopScanning();
				frame.RemoveView(scanner);
			}
			if (!UseCustomOverlayView)
			{
				frame.RemoveView(zxingOverlay);
			}
			else if (CustomOverlayView != null)
			{
				frame.RemoveView(CustomOverlayView);
			}
			base.OnStop();
		}

		private LinearLayout.LayoutParams getChildLayoutParams()
		{
			LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(-1, -1);
			layoutParams.Weight = 1f;
			return layoutParams;
		}

		public void Torch(bool on)
		{
			scanner?.Torch(on);
		}

		public void AutoFocus()
		{
			scanner?.AutoFocus();
		}

		public void AutoFocus(int x, int y)
		{
			scanner?.AutoFocus(x, y);
		}

		public void StartScanning(Action<Result> scanResultHandler, MobileBarcodeScanningOptions options = null)
		{
			ScanningOptions = options;
			scanCallback = scanResultHandler;
			if (scanner != null)
			{
				scan();
			}
		}

		private void scan()
		{
			scanner?.StartScanning(scanCallback, ScanningOptions);
		}

		public void StopScanning()
		{
			scanner?.StopScanning();
		}

		public void PauseAnalysis()
		{
			scanner?.PauseAnalysis();
		}

		public void ResumeAnalysis()
		{
			scanner?.ResumeAnalysis();
		}

		public void ToggleTorch()
		{
			scanner?.ToggleTorch();
		}
	}
	public class ZXingSurfaceView : SurfaceView, ISurfaceHolderCallback, IJavaObject, IDisposable, IScannerView, IScannerSessionHost
	{
		private bool addedHolderCallback = false;

		private CameraAnalyzer _cameraAnalyzer;

		public MobileBarcodeScanningOptions ScanningOptions { get; set; }

		public bool IsTorchOn => _cameraAnalyzer.Torch.IsEnabled;

		public bool IsAnalyzing => _cameraAnalyzer.IsAnalyzing;

		public bool HasTorch => _cameraAnalyzer.Torch.IsSupported;

		public ZXingSurfaceView(Context context, MobileBarcodeScanningOptions options)
			: base(context)
		{
			ScanningOptions = options ?? new MobileBarcodeScanningOptions();
			Init();
		}

		protected ZXingSurfaceView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
			Init();
		}

		private void Init()
		{
			if (_cameraAnalyzer == null)
			{
				_cameraAnalyzer = new CameraAnalyzer(this, this);
			}
			_cameraAnalyzer.ResumeAnalysis();
			if (!addedHolderCallback)
			{
				Holder.AddCallback(this);
				Holder.SetType(SurfaceType.PushBuffers);
				addedHolderCallback = true;
			}
		}

		public async void SurfaceCreated(ISurfaceHolder holder)
		{
			await PermissionsHandler.PermissionRequestTask;
			_cameraAnalyzer.SetupCamera();
		}

		public async void SurfaceChanged(ISurfaceHolder holder, Format format, int wx, int hx)
		{
			await PermissionsHandler.PermissionRequestTask;
			_cameraAnalyzer.RefreshCamera();
		}

		public async void SurfaceDestroyed(ISurfaceHolder holder)
		{
			await PermissionsHandler.PermissionRequestTask;
			try
			{
				if (addedHolderCallback)
				{
					Holder.RemoveCallback(this);
					addedHolderCallback = false;
				}
			}
			catch
			{
			}
			_cameraAnalyzer.ShutdownCamera();
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			bool result = base.OnTouchEvent(e);
			switch (e.Action)
			{
			case MotionEventActions.Down:
				return true;
			case MotionEventActions.Up:
			{
				float x = e.GetX();
				float y = e.GetY();
				AutoFocus((int)x, (int)y);
				break;
			}
			}
			return result;
		}

		public void AutoFocus()
		{
			_cameraAnalyzer.AutoFocus();
		}

		public void AutoFocus(int x, int y)
		{
			_cameraAnalyzer.AutoFocus(x, y);
		}

		public void StartScanning(Action<Result> scanResultCallback, MobileBarcodeScanningOptions options = null)
		{
			ScanningOptions = options ?? MobileBarcodeScanningOptions.Default;
			_cameraAnalyzer.BarcodeFound += delegate(object sender, Result result)
			{
				scanResultCallback?.Invoke(result);
			};
			_cameraAnalyzer.ResumeAnalysis();
		}

		public void StopScanning()
		{
			_cameraAnalyzer.ShutdownCamera();
		}

		public void PauseAnalysis()
		{
			_cameraAnalyzer.PauseAnalysis();
		}

		public void ResumeAnalysis()
		{
			_cameraAnalyzer.ResumeAnalysis();
		}

		public void Torch(bool on)
		{
			if (on)
			{
				_cameraAnalyzer.Torch.TurnOn();
			}
			else
			{
				_cameraAnalyzer.Torch.TurnOff();
			}
		}

		public void ToggleTorch()
		{
			_cameraAnalyzer.Torch.Toggle();
		}

		protected override void OnAttachedToWindow()
		{
			base.OnAttachedToWindow();
			Init();
		}

		protected override void OnWindowVisibilityChanged(ViewStates visibility)
		{
			base.OnWindowVisibilityChanged(visibility);
			if (visibility == ViewStates.Visible)
			{
				Init();
			}
		}

		public override async void OnWindowFocusChanged(bool hasWindowFocus)
		{
			base.OnWindowFocusChanged(hasWindowFocus);
			if (hasWindowFocus)
			{
				await PermissionsHandler.PermissionRequestTask;
				_cameraAnalyzer.RefreshCamera();
			}
		}
	}
	public static class FastJavaArrayEx
	{
		public unsafe static void BlockCopyTo(this FastJavaByteArray self, int sourceIndex, byte[] array, int arrayIndex, int length)
		{
			Marshal.Copy(new IntPtr(self.Raw + sourceIndex), array, arrayIndex, System.Math.Min(length, System.Math.Min(self.Count, array.Length - arrayIndex)));
		}
	}
	public sealed class FastJavaByteArrayYUVLuminanceSource : BaseLuminanceSource
	{
		private readonly FastJavaByteArray _yuv;

		private readonly int _dataWidth;

		private readonly int _dataHeight;

		private readonly int _left;

		private readonly int _top;

		public override byte[] Matrix
		{
			get
			{
				int num = Width;
				int num2 = Height;
				int num3 = num * num2;
				byte[] array = new byte[num3];
				int num4 = _top * _dataWidth + _left;
				if (num == _dataWidth)
				{
					_yuv.BlockCopyTo(num4, array, 0, num3);
					return array;
				}
				for (int i = 0; i < num2; i++)
				{
					int arrayIndex = i * num;
					_yuv.BlockCopyTo(num4, array, arrayIndex, num);
					num4 += _dataWidth;
				}
				return array;
			}
		}

		public override bool CropSupported => true;

		public FastJavaByteArrayYUVLuminanceSource(FastJavaByteArray yuv, int dataWidth, int dataHeight, int left, int top, int width, int height)
			: base(width, height)
		{
			if (left < 0)
			{
				throw new ArgumentException("Negative value", "left");
			}
			if (top < 0)
			{
				throw new ArgumentException("Negative value", "top");
			}
			if (width < 0)
			{
				throw new ArgumentException("Negative value", "width");
			}
			if (height < 0)
			{
				throw new ArgumentException("Negative value", "height");
			}
			if (left + width > dataWidth || top + height > dataHeight)
			{
				throw new ArgumentException("Crop rectangle does not fit within image data.");
			}
			_yuv = yuv;
			_dataWidth = dataWidth;
			_dataHeight = dataHeight;
			_left = left;
			_top = top;
		}

		public override byte[] getRow(int y, byte[] row)
		{
			if (y < 0 || y >= Height)
			{
				throw new ArgumentException("Requested row is outside the image: " + y, "y");
			}
			int num = Width;
			if (row == null || row.Length < num)
			{
				row = new byte[num];
			}
			int sourceIndex = (y + _top) * _dataWidth + _left;
			_yuv.BlockCopyTo(sourceIndex, row, 0, num);
			return row;
		}

		public override LuminanceSource crop(int left, int top, int width, int height)
		{
			return new FastJavaByteArrayYUVLuminanceSource(_yuv, _dataWidth, _dataHeight, _left + left, _top + top, width, height);
		}

		protected override LuminanceSource CreateLuminanceSource(byte[] newLuminances, int width, int height)
		{
			return new PlanarYUVLuminanceSource(newLuminances, width, height, 0, 0, width, height, reverseHoriz: false);
		}
	}
}
namespace ZXing.Mobile.CameraAccess
{
	public class CameraAnalyzer
	{
		private readonly CameraController _cameraController;

		private readonly CameraEventsListener _cameraEventListener;

		private Task _processingTask;

		private DateTime _lastPreviewAnalysis = DateTime.UtcNow;

		private bool _wasScanned;

		private IScannerSessionHost _scannerHost;

		public Torch Torch { get; }

		public bool IsAnalyzing { get; private set; }

		private bool CanAnalyzeFrame
		{
			get
			{
				if (!IsAnalyzing)
				{
					return false;
				}
				if (_processingTask != null && !_processingTask.IsCompleted)
				{
					return false;
				}
				double totalMilliseconds = (DateTime.UtcNow - _lastPreviewAnalysis).TotalMilliseconds;
				if (totalMilliseconds < (double)_scannerHost.ScanningOptions.DelayBetweenAnalyzingFrames)
				{
					return false;
				}
				if (_wasScanned && totalMilliseconds < (double)_scannerHost.ScanningOptions.DelayBetweenContinuousScans)
				{
					return false;
				}
				return true;
			}
		}

		public event EventHandler<Result> BarcodeFound;

		public CameraAnalyzer(SurfaceView surfaceView, IScannerSessionHost scannerHost)
		{
			_scannerHost = scannerHost;
			_cameraEventListener = new CameraEventsListener();
			_cameraController = new CameraController(surfaceView, _cameraEventListener, scannerHost);
			Torch = new Torch(_cameraController, surfaceView.Context);
		}

		public void PauseAnalysis()
		{
			IsAnalyzing = false;
		}

		public void ResumeAnalysis()
		{
			IsAnalyzing = true;
		}

		public void ShutdownCamera()
		{
			IsAnalyzing = false;
			_cameraEventListener.OnPreviewFrameReady -= HandleOnPreviewFrameReady;
			_cameraController.ShutdownCamera();
		}

		public void SetupCamera()
		{
			_cameraEventListener.OnPreviewFrameReady += HandleOnPreviewFrameReady;
			_cameraController.SetupCamera();
		}

		public void AutoFocus()
		{
			_cameraController.AutoFocus();
		}

		public void AutoFocus(int x, int y)
		{
			_cameraController.AutoFocus(x, y);
		}

		public void RefreshCamera()
		{
			_cameraController.RefreshCamera();
		}

		private void HandleOnPreviewFrameReady(object sender, FastJavaByteArray fastArray)
		{
			if (!CanAnalyzeFrame)
			{
				return;
			}
			_wasScanned = false;
			_lastPreviewAnalysis = DateTime.UtcNow;
			_processingTask = Task.Run(delegate
			{
				try
				{
					DecodeFrame(fastArray);
				}
				catch (System.Exception value)
				{
					Console.WriteLine(value);
				}
			}).ContinueWith(delegate(Task task)
			{
				if (task.IsFaulted)
				{
					Log.Debug("ZXing.Net.Mobile", "DecodeFrame exception occurs");
				}
			}, TaskContinuationOptions.OnlyOnFaulted);
		}

		private void DecodeFrame(FastJavaByteArray fastArray)
		{
			Camera.Parameters parameters = _cameraController.Camera.GetParameters();
			int width = parameters.PreviewSize.Width;
			int height = parameters.PreviewSize.Height;
			BarcodeReader barcodeReader = _scannerHost.ScanningOptions.BuildBarcodeReader();
			bool flag = false;
			int num = width;
			int num2 = height;
			int lastCameraDisplayOrientationDegree = _cameraController.LastCameraDisplayOrientationDegree;
			if (lastCameraDisplayOrientationDegree == 90 || lastCameraDisplayOrientationDegree == 270)
			{
				flag = true;
				num = height;
				num2 = width;
			}
			Result result = null;
			string guid = PerformanceCounter.Start();
			LuminanceSource luminanceSource = new FastJavaByteArrayYUVLuminanceSource(fastArray, width, height, 0, 0, width, height);
			if (flag)
			{
				luminanceSource = luminanceSource.rotateCounterClockwise();
			}
			result = barcodeReader.Decode(luminanceSource);
			fastArray.Dispose();
			fastArray = null;
			PerformanceCounter.Stop(guid, "Decode Time: {0} ms (width: " + width + ", height: " + height + ", degrees: " + lastCameraDisplayOrientationDegree + ", rotate: " + flag.ToString() + ")");
			if (result != null)
			{
				Log.Debug("ZXing.Net.Mobile", "Barcode Found");
				_wasScanned = true;
				this.BarcodeFound?.Invoke(this, result);
			}
		}
	}
	public class CameraController
	{
		private readonly Context _context;

		private readonly ISurfaceHolder _holder;

		private readonly SurfaceView _surfaceView;

		private readonly CameraEventsListener _cameraEventListener;

		private int _cameraId;

		private IScannerSessionHost _scannerHost;

		public Camera Camera { get; private set; }

		public int LastCameraDisplayOrientationDegree { get; private set; }

		public CameraController(SurfaceView surfaceView, CameraEventsListener cameraEventListener, IScannerSessionHost scannerHost)
		{
			_context = surfaceView.Context;
			_holder = surfaceView.Holder;
			_surfaceView = surfaceView;
			_cameraEventListener = cameraEventListener;
			_scannerHost = scannerHost;
		}

		public void RefreshCamera()
		{
			if (_holder == null)
			{
				return;
			}
			ApplyCameraSettings();
			try
			{
				Camera.SetPreviewDisplay(_holder);
				Camera.StartPreview();
			}
			catch (System.Exception ex)
			{
				Log.Debug("ZXing.Net.Mobile", ex.ToString());
			}
		}

		public void SetupCamera()
		{
			if (Camera != null)
			{
				return;
			}
			PermissionsHandler.CheckCameraPermissions(_context);
			string guid = PerformanceCounter.Start();
			OpenCamera();
			PerformanceCounter.Stop(guid, "Setup Camera took {0}ms");
			if (Camera == null)
			{
				return;
			}
			guid = PerformanceCounter.Start();
			ApplyCameraSettings();
			try
			{
				Camera.SetPreviewDisplay(_holder);
				Camera.Parameters parameters = Camera.GetParameters();
				Camera.Size previewSize = parameters.PreviewSize;
				int bitsPerPixel = ImageFormat.GetBitsPerPixel(parameters.PreviewFormat);
				int length = previewSize.Width * previewSize.Height * bitsPerPixel / 8;
				for (uint num = 0u; num < 5; num++)
				{
					using FastJavaByteArray callbackBuffer = new FastJavaByteArray(length);
					Camera.AddCallbackBuffer(callbackBuffer);
				}
				Camera.StartPreview();
				Camera.SetNonMarshalingPreviewCallback(_cameraEventListener);
			}
			catch (System.Exception ex)
			{
				Log.Debug("ZXing.Net.Mobile", ex.ToString());
				return;
			}
			finally
			{
				PerformanceCounter.Stop(guid, "Setup Camera Parameters took {0}ms");
			}
			string focusMode = Camera.GetParameters().FocusMode;
			if (focusMode == "auto" || focusMode == "macro")
			{
				AutoFocus();
			}
		}

		public void AutoFocus()
		{
			AutoFocus(0, 0, useCoordinates: false);
		}

		public void AutoFocus(int x, int y)
		{
			int x2 = x / _surfaceView.Width * 2000 - 1000;
			int y2 = y / _surfaceView.Height * 2000 - 1000;
			AutoFocus(x2, y2, useCoordinates: true);
		}

		public void ShutdownCamera()
		{
			if (Camera == null)
			{
				return;
			}
			string guid = PerformanceCounter.Start();
			try
			{
				try
				{
					Camera.SetPreviewDisplay(null);
					Camera.StopPreview();
					Camera.SetNonMarshalingPreviewCallback(null);
				}
				catch (System.Exception ex)
				{
					Log.Error("ZXing.Net.Mobile", ex.ToString());
				}
				Camera.Release();
				Camera = null;
			}
			catch (System.Exception ex2)
			{
				Log.Error("ZXing.Net.Mobile", ex2.ToString());
			}
			PerformanceCounter.Stop(guid, "Shutdown camera took {0}ms");
		}

		private void OpenCamera()
		{
			try
			{
				BuildVersionCodes sdkInt = Build.VERSION.SdkInt;
				if (sdkInt >= BuildVersionCodes.Gingerbread)
				{
					Log.Debug("ZXing.Net.Mobile", "Checking Number of cameras...");
					int numberOfCameras = Camera.NumberOfCameras;
					Camera.CameraInfo cameraInfo = new Camera.CameraInfo();
					bool flag = false;
					Log.Debug("ZXing.Net.Mobile", "Found " + numberOfCameras + " cameras...");
					CameraFacing cameraFacing = CameraFacing.Back;
					if (_scannerHost.ScanningOptions.UseFrontCameraIfAvailable.HasValue && _scannerHost.ScanningOptions.UseFrontCameraIfAvailable.Value)
					{
						cameraFacing = CameraFacing.Front;
					}
					for (int i = 0; i < numberOfCameras; i++)
					{
						Camera.GetCameraInfo(i, cameraInfo);
						if (cameraInfo.Facing == cameraFacing)
						{
							Log.Debug("ZXing.Net.Mobile", string.Concat("Found ", cameraFacing, " Camera, opening..."));
							Camera = Camera.Open(i);
							_cameraId = i;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Log.Debug("ZXing.Net.Mobile", string.Concat("Finding ", cameraFacing, " camera failed, opening camera 0..."));
						Camera = Camera.Open(0);
						_cameraId = 0;
					}
				}
				else
				{
					Camera = Camera.Open();
				}
			}
			catch (System.Exception ex)
			{
				ShutdownCamera();
				MobileBarcodeScanner.LogError("Setup Error: {0}", ex);
			}
		}

		private void ApplyCameraSettings()
		{
			if (Camera == null)
			{
				OpenCamera();
			}
			if (Camera == null)
			{
				return;
			}
			Camera.Parameters parameters = Camera.GetParameters();
			parameters.PreviewFormat = ImageFormatType.Nv21;
			IList<string> supportedFocusModes = parameters.SupportedFocusModes;
			if (_scannerHost.ScanningOptions.DisableAutofocus)
			{
				parameters.FocusMode = "fixed";
			}
			else if (Build.VERSION.SdkInt >= BuildVersionCodes.IceCreamSandwich && supportedFocusModes.Contains("continuous-picture"))
			{
				parameters.FocusMode = "continuous-picture";
			}
			else if (supportedFocusModes.Contains("continuous-video"))
			{
				parameters.FocusMode = "continuous-video";
			}
			else if (supportedFocusModes.Contains("auto"))
			{
				parameters.FocusMode = "auto";
			}
			else if (supportedFocusModes.Contains("fixed"))
			{
				parameters.FocusMode = "fixed";
			}
			int[] array = parameters.SupportedPreviewFpsRange.FirstOrDefault();
			if (array != null)
			{
				foreach (int[] item in parameters.SupportedPreviewFpsRange)
				{
					if (item[0] <= array[0] && item[1] > array[1])
					{
						array = item;
					}
				}
				parameters.SetPreviewFpsRange(array[0], array[1]);
			}
			CameraResolution cameraResolution = null;
			IList<Camera.Size> supportedPreviewSizes = parameters.SupportedPreviewSizes;
			if (supportedPreviewSizes != null)
			{
				IEnumerable<CameraResolution> source = supportedPreviewSizes.Select((Camera.Size sps) => new CameraResolution
				{
					Width = sps.Width,
					Height = sps.Height
				});
				cameraResolution = _scannerHost.ScanningOptions.GetResolution(source.ToList());
				if (cameraResolution == null)
				{
					foreach (Camera.Size item2 in supportedPreviewSizes)
					{
						if (item2.Width >= 640 && item2.Width <= 1000 && item2.Height >= 360 && item2.Height <= 1000)
						{
							cameraResolution = new CameraResolution
							{
								Width = item2.Width,
								Height = item2.Height
							};
							break;
						}
					}
				}
			}
			if (Build.Model.Contains("Glass"))
			{
				cameraResolution = new CameraResolution
				{
					Width = 640,
					Height = 360
				};
				parameters.SetPreviewFpsRange(30000, 30000);
			}
			if (cameraResolution != null)
			{
				Log.Debug("ZXing.Net.Mobile", "Selected Resolution: " + cameraResolution.Width + "x" + cameraResolution.Height);
				parameters.SetPreviewSize(cameraResolution.Width, cameraResolution.Height);
			}
			Camera.SetParameters(parameters);
			SetCameraDisplayOrientation();
		}

		private void AutoFocus(int x, int y, bool useCoordinates)
		{
			if (Camera == null)
			{
				return;
			}
			if (_scannerHost.ScanningOptions.DisableAutofocus)
			{
				Log.Debug("ZXing.Net.Mobile", "AutoFocus Disabled");
				return;
			}
			Camera.Parameters parameters = Camera.GetParameters();
			Log.Debug("ZXing.Net.Mobile", "AutoFocus Requested");
			Camera.CancelAutoFocus();
			try
			{
				if (useCoordinates && parameters.SupportedFocusModes.Contains("auto"))
				{
					x -= 10;
					y -= 10;
					if (x >= 1000)
					{
						x = 980;
					}
					if (x < -1000)
					{
						x = -1000;
					}
					if (y >= 1000)
					{
						y = 980;
					}
					if (y < -1000)
					{
						y = -1000;
					}
					parameters.FocusMode = "auto";
					parameters.FocusAreas = new List<Camera.Area>
					{
						new Camera.Area(new Rect(x, y, x + 20, y + 20), 1000)
					};
					Camera.SetParameters(parameters);
				}
				Camera.AutoFocus(_cameraEventListener);
			}
			catch (System.Exception ex)
			{
				Log.Debug("ZXing.Net.Mobile", "AutoFocus Failed: {0}", ex);
			}
		}

		private void SetCameraDisplayOrientation()
		{
			int num = (LastCameraDisplayOrientationDegree = GetCameraDisplayOrientation());
			Log.Debug("ZXing.Net.Mobile", "Changing Camera Orientation to: " + num);
			try
			{
				Camera.SetDisplayOrientation(num);
			}
			catch (System.Exception ex)
			{
				Log.Error("ZXing.Net.Mobile", ex.ToString());
			}
		}

		private int GetCameraDisplayOrientation()
		{
			IWindowManager windowManager = _context.GetSystemService("window").JavaCast<IWindowManager>();
			Display defaultDisplay = windowManager.DefaultDisplay;
			int num = defaultDisplay.Rotation switch
			{
				SurfaceOrientation.Rotation0 => 0, 
				SurfaceOrientation.Rotation90 => 90, 
				SurfaceOrientation.Rotation180 => 180, 
				SurfaceOrientation.Rotation270 => 270, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			Camera.CameraInfo cameraInfo = new Camera.CameraInfo();
			Camera.GetCameraInfo(_cameraId, cameraInfo);
			if (cameraInfo.Facing == CameraFacing.Front)
			{
				int num2 = (cameraInfo.Orientation + num) % 360;
				return (360 - num2) % 360;
			}
			return (cameraInfo.Orientation - num + 360) % 360;
		}
	}
	public class CameraEventsListener : Java.Lang.Object, INonMarshalingPreviewCallback, IJavaObject, IDisposable, Camera.IAutoFocusCallback
	{
		public event EventHandler<FastJavaByteArray> OnPreviewFrameReady;

		public void OnPreviewFrame(IntPtr data, Camera camera)
		{
			using FastJavaByteArray fastJavaByteArray = new FastJavaByteArray(data);
			this.OnPreviewFrameReady?.Invoke(this, fastJavaByteArray);
			camera.AddCallbackBuffer(fastJavaByteArray);
		}

		public void OnAutoFocus(bool success, Camera camera)
		{
			Log.Debug("ZXing.Net.Mobile", "AutoFocus {0}", success ? "Succeeded" : "Failed");
		}
	}
	public class Torch
	{
		private readonly CameraController _cameraController;

		private readonly Context _context;

		private bool? _hasTorch;

		public bool IsSupported
		{
			get
			{
				if (_hasTorch.HasValue)
				{
					return _hasTorch.Value;
				}
				if (!_context.PackageManager.HasSystemFeature("android.hardware.camera.flash"))
				{
					Log.Info("ZXing.Net.Mobile", "Flash not supported on this device");
					return false;
				}
				if (_cameraController.Camera == null)
				{
					Log.Info("ZXing.Net.Mobile", "Run camera first");
					return false;
				}
				Camera.Parameters parameters = _cameraController.Camera.GetParameters();
				IList<string> supportedFlashModes = parameters.SupportedFlashModes;
				if (supportedFlashModes != null && (supportedFlashModes.Contains("torch") || supportedFlashModes.Contains("on")))
				{
					_hasTorch = PermissionsHandler.CheckTorchPermissions(_context, throwOnError: false);
				}
				return _hasTorch.HasValue && _hasTorch.Value;
			}
		}

		public bool IsEnabled { get; private set; }

		public Torch(CameraController cameraController, Context context)
		{
			_cameraController = cameraController;
			_context = context;
		}

		public void TurnOn()
		{
			Enable(state: true);
		}

		public void TurnOff()
		{
			Enable(state: false);
		}

		public void Toggle()
		{
			Enable(!IsEnabled);
		}

		private void Enable(bool state)
		{
			if (!IsSupported || IsEnabled == state)
			{
				return;
			}
			if (_cameraController.Camera == null)
			{
				Log.Info("ZXing.Net.Mobile", "NULL Camera, cannot toggle torch");
				return;
			}
			Camera.Parameters parameters = _cameraController.Camera.GetParameters();
			IList<string> supportedFlashModes = parameters.SupportedFlashModes;
			string text = string.Empty;
			if (state)
			{
				if (supportedFlashModes.Contains("torch"))
				{
					text = "torch";
				}
				else if (supportedFlashModes.Contains("on"))
				{
					text = "on";
				}
			}
			else if (supportedFlashModes != null && supportedFlashModes.Contains("off"))
			{
				text = "off";
			}
			if (!string.IsNullOrEmpty(text))
			{
				parameters.FlashMode = text;
				_cameraController.Camera.SetParameters(parameters);
				IsEnabled = state;
			}
		}
	}
}
