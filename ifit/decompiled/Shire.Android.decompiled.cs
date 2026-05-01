using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Akavache;
using Akavache.Sqlite3;
using Android.Animation;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Gms.Common;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Net;
using Android.Net.Wifi;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Text.Style;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Views.InputMethods;
using Android.Webkit;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.CardView.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.PercentLayout.Widget;
using Auth0.OidcClient;
using Com.Airbnb.Lottie;
using Com.Launchdarkly.Sdk;
using Com.Launchdarkly.Sdk.Android;
using Com.Routethis.Androidsdk;
using FM.Feed.Android.Playersdk;
using FM.Feed.Android.Playersdk.Models;
using Firebase.Analytics;
using Google.Ads.Identifier;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.TextField;
using IdentityModel.OidcClient;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Lang.Reflect;
using Java.Net;
using Java.Util;
using Java.Util.Concurrent;
using Java.Util.Zip;
using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Diagnostics;
using MQTTnet.Extensions.ManagedClient;
using MathNet.Numerics;
using Microsoft.CodeAnalysis;
using MikePhil.Charting.Animation;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Components;
using MikePhil.Charting.Data;
using MikePhil.Charting.Formatter;
using MikePhil.Charting.Interfaces.Dataprovider;
using MikePhil.Charting.Interfaces.Datasets;
using MikePhil.Charting.Renderer;
using MikePhil.Charting.Util;
using Mindscape.Raygun4Net;
using Mindscape.Raygun4Net.Messages;
using ModernHttpClient;
using MoreLinq;
using MvvmCross.Binding.Attributes;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Binders;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Core.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V4.EventSource;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Droid.Views;
using MvvmCross.Platform.IoC;
using NO.Nordicsemi.Android.Dfu;
using Newtonsoft.Json;
using Plugin.Connectivity.Abstractions;
using Plugin.DeviceInfo;
using Shire.Android.Controls;
using Shire.Android.Dialogs;
using Shire.Android.Services;
using Shire.Android.ShireMvx.MvxBaseModified;
using Shire.Android.Util;
using Shire.Android.Util.Apple;
using Shire.Android.Util.Auth0;
using Shire.Android.Util.Facebook;
using Shire.Android.Util.Twitter;
using Shire.Core.Analytics;
using Shire.Core.Api.Branch;
using Shire.Core.Api.Facebook;
using Shire.Core.Ble.Headphone;
using Shire.Core.BuiltIn.UpdateCheck;
using Shire.Core.Charts;
using Shire.Core.Culture;
using Shire.Core.Extensions;
using Shire.Core.Interfaces;
using Shire.Core.LaunchDarkly;
using Shire.Core.Maps;
using Shire.Core.Mqtt;
using Shire.Core.Music;
using Shire.Core.Music.FeedFm;
using Shire.Core.Resources;
using Shire.Core.Services;
using Shire.Core.Services.Culture;
using Shire.Core.Services.Login;
using Shire.Core.Services.Update;
using Shire.Core.Services.Update.Ble;
using Shire.Core.Services.Update.Firmware;
using Shire.Core.ShireMvx;
using Shire.Core.ShireMvx.PresentationHints;
using Shire.Core.Source.Util.SystemResources;
using Shire.Core.Util;
using Shire.Core.Util.Apple;
using Shire.Core.Util.Auth0;
using Shire.Core.Util.Extensions;
using Shire.Core.Util.Facebook;
using Shire.Core.Util.Hardware;
using Shire.Core.Util.Share;
using Shire.Core.Util.Twitter;
using Shire.Core.WebView;
using Shire.Core.Wifi;
using Sindarin.Ble.Android.Connection;
using Sindarin.Core;
using Sindarin.Core.Ble;
using Sindarin.Core.Ble.Connection;
using Sindarin.Core.Ble.Service;
using Sindarin.Core.Console;
using Sindarin.Core.DataObjects;
using Sindarin.Core.Util;
using Sindarin.Usb.Android.Util;
using Splat;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Share.Model;
using Xamarin.Facebook.Share.Widget;
using iFit.Api;
using iFit.Api.DataObjects;
using iFit.Api.Environments;
using iFit.Api.Google;
using iFit.Api.Support;
using iFit.Api.Util;
using iFit.Aws.Android;
using iFit.Collections;
using iFit.CrashReporter;
using iFit.CrashReporter.Util;
using iFit.Extensions.Android;
using iFit.Files;
using iFit.Logger;
using iFit.Mathematics;
using iFit.Raygun;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: ResourceDesigner("Shire.Android.Resource", IsApplication = false)]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyVersion("0.0.0.0")]
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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
}
namespace iFit.Raygun.Android
{
	public abstract class BaseRaygunClient : IRaygunClient
	{
		private const string Tag = "RaygunClient";

		private readonly Subject<RaygunMessageEventArgs> _onRaygunError = new Subject<RaygunMessageEventArgs>();

		protected RaygunClient client => RaygunClient.Current;

		public IObservable<RaygunMessageEventArgs> OnRaygunError => _onRaygunError;

		public abstract string FullAppVersion { get; }

		public abstract void SetupAndAttachPulse(string clientId);

		public void Initialize(string clientId)
		{
			if (client != null)
			{
				client.SendingMessage -= ClientOnSendingMessage;
			}
			iFit.Logger.Log.Trace("RaygunClient", "Initializing Raygun");
			SetupAndAttachPulse(clientId);
			if (client != null)
			{
				client.ApplicationVersion = FullAppVersion;
				client.SendingMessage += ClientOnSendingMessage;
			}
		}

		public void UpdateUserInfo(string username, string fullName, string email)
		{
			if (client != null)
			{
				iFit.Logger.Log.Trace("RaygunClient", "Updating raygun user");
				client.UserInfo = new RaygunIdentifierMessage(username ?? string.Empty)
				{
					IsAnonymous = string.IsNullOrWhiteSpace(username),
					FullName = (fullName ?? string.Empty),
					Email = (email ?? string.Empty)
				};
			}
		}

		public void SendInBackground(System.Exception exception, IList<string> tags, IDictionary customData)
		{
			if (client != null)
			{
				client.SendInBackground(exception, tags, customData);
			}
		}

		protected virtual void ClientOnSendingMessage(object sender, RaygunSendingMessageEventArgs e)
		{
			RaygunMessageDetails raygunMessageDetails = e?.Message?.Details;
			if (raygunMessageDetails != null)
			{
				RaygunMessageEventArgs value = new RaygunMessageEventArgs
				{
					Tags = (raygunMessageDetails.Tags ?? new List<string>()),
					UserCustomData = (raygunMessageDetails.UserCustomData ?? new Dictionary<string, object>()),
					OccurredOn = (e?.Message?.OccurredOn ?? DateTime.UtcNow),
					ClassName = raygunMessageDetails.Error?.ClassName,
					Message = raygunMessageDetails.Error?.Message,
					StackTrace = raygunMessageDetails.Error?.StackTrace?.Select((RaygunErrorStackTraceLineMessage line) => line?.Raw).ToList()
				};
				_onRaygunError.OnNext(value);
			}
		}
	}
}
namespace iFit.NetworkDiagnostics
{
	public class NetworkDiagnostics : INetworkDiagnostics
	{
		private class RouteThisWrapper : Java.Lang.Object, IRouteThisAnalysisHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private const int TimeoutInMs = 20000;

			private readonly Timer timeoutTimer;

			private bool disposed;

			public event EventHandler AnalysisComplete;

			public event EventHandler<MvxValueEventArgs<NetworkDiagnosticsError>> AnalysisError;

			public event EventHandler<System.ComponentModel.ProgressChangedEventArgs> Progress;

			public RouteThisWrapper()
			{
				timeoutTimer = new Timer(delegate
				{
					this.AnalysisError?.Invoke(this, new MvxValueEventArgs<NetworkDiagnosticsError>(NetworkDiagnosticsError.Timeout));
				}, null, 20000, -1);
			}

			private void ResetTimer()
			{
				timeoutTimer.Change(20000, -1);
			}

			public void OnAnalysisStarted()
			{
				ResetTimer();
				iFit.Logger.Log.Trace("NetworkDiagnostics", "Starting network analysis.");
			}

			public void OnAnalysisComplete()
			{
				ResetTimer();
			}

			public void OnAnalysisProgress(float progress, int timeElapsed)
			{
				ResetTimer();
				int progressPercentage = (int)(progress * 100f);
				this.Progress?.Invoke(this, new System.ComponentModel.ProgressChangedEventArgs(progressPercentage, timeElapsed));
			}

			public void OnDataPersisted()
			{
				timeoutTimer.Change(-1, -1);
				iFit.Logger.Log.Trace("NetworkDiagnostics", "Network analysis finished.");
				this.AnalysisComplete?.Invoke(this, EventArgs.Empty);
			}

			public void OnErrorAnalysisAlreadyRunning()
			{
				this.AnalysisError?.Invoke(this, new MvxValueEventArgs<NetworkDiagnosticsError>(NetworkDiagnosticsError.AlreadyStarted));
			}

			public void OnErrorInvalidApiKey()
			{
				this.AnalysisError?.Invoke(this, new MvxValueEventArgs<NetworkDiagnosticsError>(NetworkDiagnosticsError.InvalidApiKey));
			}

			public void OnErrorNoInternetConnection()
			{
				this.AnalysisError?.Invoke(this, new MvxValueEventArgs<NetworkDiagnosticsError>(NetworkDiagnosticsError.NoInternetConnection));
			}

			public void OnErrorNoWifi()
			{
				this.AnalysisError?.Invoke(this, new MvxValueEventArgs<NetworkDiagnosticsError>(NetworkDiagnosticsError.NoWifi));
			}

			public bool OnLocationServicesDisabled()
			{
				iFit.Logger.Log.Warn("NetworkDiagnostics", "Location services disabled, network diagnostics results will not be fully accurate.");
				return false;
			}

			public bool OnMissingLocationPermission()
			{
				iFit.Logger.Log.Warn("NetworkDiagnostics", "Missing permissions for location services, network diagnostics results will not be fully accurate.");
				return false;
			}

			public void OnWarningBatterySaverOn()
			{
				this.AnalysisError?.Invoke(this, new MvxValueEventArgs<NetworkDiagnosticsError>(NetworkDiagnosticsError.BatterySaver));
			}

			protected override void Dispose(bool disposing)
			{
				if (!disposed)
				{
					if (disposing)
					{
						timeoutTimer.Dispose();
					}
					disposed = true;
				}
				base.Dispose(disposing);
			}
		}

		private const string LogTag = "NetworkDiagnostics";

		private readonly RouteThisApi routeThisApi;

		private RouteThisWrapper callbackWrapper;

		private bool isCancelled;

		public NetworkDiagnostics(Context context, IAppVersionService appVersionService, IHardwareInfo hardwareInfo, IConsoleInfo consoleInfo, User user, bool isBuiltIn)
		{
			string p = new string[3] { "03403`53,e7b", "6/6157/cac1/", ":417ee41fb`f" }.TransformString();
			routeThisApi = RouteThisApi.GetInstance(context, p);
			if (user != null)
			{
				routeThisApi.SetUsername(user.Username);
				routeThisApi.SetEmail(user.Email);
				routeThisApi.SetName(user.Firstname, user.Lastname);
			}
			else
			{
				string username = consoleInfo?.SerialNumber.ToString() ?? "<unknown>";
				routeThisApi.SetUsername(username);
			}
			InitializeStatus(appVersionService, hardwareInfo, consoleInfo, isBuiltIn);
		}

		public async Task<string> RunAnalysis(IProgress<int> progress, CancellationToken cancellationToken)
		{
			isCancelled = false;
			TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
			cancellationToken.Register(delegate
			{
				routeThisApi.Destroy();
				isCancelled = true;
				iFit.Logger.Log.Trace("NetworkDiagnostics", "Cancelling network diagnostics operation.");
			});
			if (callbackWrapper == null)
			{
				callbackWrapper = new RouteThisWrapper();
			}
			callbackWrapper.Progress += delegate(object s, System.ComponentModel.ProgressChangedEventArgs e)
			{
				progress.Report(e.ProgressPercentage);
			};
			callbackWrapper.AnalysisError += delegate(object s, MvxValueEventArgs<NetworkDiagnosticsError> e)
			{
				iFit.Logger.Log.Trace("NetworkDiagnostics", $"Network diagnosics failed with error: {e.Value}");
				if (e.Value == NetworkDiagnosticsError.Timeout)
				{
					routeThisApi.Destroy();
				}
				tcs.TrySetException(new NetworkDiagnosticsException(e.Value));
			};
			callbackWrapper.AnalysisComplete += delegate
			{
				if (isCancelled)
				{
					tcs.TrySetException(new TaskCanceledException());
				}
				else
				{
					string selfHelpUrl = routeThisApi.SelfHelpUrl;
					tcs.TrySetResult(selfHelpUrl);
				}
			};
			routeThisApi.RunAnalysis(callbackWrapper);
			return await tcs.Task;
		}

		public void IdentifierOverride(string identifier)
		{
			routeThisApi.SetUsername(identifier);
		}

		public string GetUserDashboardURL()
		{
			string userId = routeThisApi.UserId;
			return "https://api.routethis.com/dashboard/index.html#analysis-details/" + userId;
		}

		private void InitializeStatus(IAppVersionService appVersionService, IHardwareInfo hardwareInfo, IConsoleInfo consoleInfo, bool isBuiltIn)
		{
			Dictionary<string, string> data = new Dictionary<string, string>();
			if (consoleInfo != null)
			{
				data.Add("isBuiltIn", isBuiltIn.ToString());
				if (hardwareInfo != null)
				{
					data.Add("platform", hardwareInfo.OperatingSystem);
					data.Add("deviceCategory", hardwareInfo.IsTablet ? "tablet" : "phone");
					data.Add("OS", hardwareInfo.OperatingSystemVersion);
				}
				if (appVersionService != null)
				{
					data.Add("appVersion", appVersionService.MainAppVersionInfo.FullAppVersion);
					if (appVersionService.SupplementalVersionInfo.Count > 0)
					{
						appVersionService.SupplementalVersionInfo.DoForEach(delegate(KeyValuePair<string, VersionInfo> tuple)
						{
							data.Add(tuple.Key, tuple.Value.FullAppVersion);
						});
					}
				}
				data.Add("modelNumber", consoleInfo.ModelNumber.ToString());
				data.Add("partNumber", consoleInfo.PartNumber.ToString());
				data.Add("isClubUnit", consoleInfo.IsClub.ToString());
				data.Add("softwareVersion", consoleInfo.SoftwareVersion.ToString());
				data.Add("hardwareVersion", consoleInfo.HardwareVersion.ToString());
				data.Add("firmwareVersion", consoleInfo.FirmwareVersion);
				data.Add("brainboardSerialNumber", consoleInfo.BrainboardSerialNumber);
				data.Add("serialNumber", consoleInfo.SerialNumber.ToString());
				data.Add("manufacturerId", consoleInfo.ManufacturerId.ToString());
				data.Add("consoleName", consoleInfo.Name);
				data.Add("masterLibraryVersion", consoleInfo.MasterLibraryVersion.ToString());
				data.Add("masterLibraryBuild", consoleInfo.MasterLibraryBuild.ToString());
				data.Add("maxKph", consoleInfo.MaxKph.ToString());
				data.Add("minKph", consoleInfo.MinKph.ToString());
				data.Add("maxIncline", consoleInfo.MaxIncline.ToString());
				data.Add("minIncline", consoleInfo.MinIncline.ToString());
				data.Add("maxResistanceLevel", consoleInfo.MaxResistanceLevel.ToString());
				data.Add("maxWeight", consoleInfo.MaxWeight.ToString());
				data.Add("canSetKph", consoleInfo.CanSetKph.ToString());
				data.Add("canSetActivationLock", consoleInfo.CanSetActivationLock.ToString());
				data.Add("canSetIncline", consoleInfo.CanSetIncline.ToString());
				data.Add("canSetResistance", consoleInfo.CanSetResistance.ToString());
				data.Add("machineType", consoleInfo.MachineType.ToString());
			}
			routeThisApi.AddStatusObject("DeviceInformation", JsonConvert.SerializeObject(data));
		}
	}
}
namespace iFit.CrashReporter.Android
{
	public class WaitingUncaughtExceptionHandler : Java.Lang.Object, Java.Lang.Thread.IUncaughtExceptionHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		private const string Tag = "CrashReporter";

		private readonly Java.Lang.Thread.IUncaughtExceptionHandler defaultHandler;

		public WaitingUncaughtExceptionHandler()
		{
			defaultHandler = Java.Lang.Thread.DefaultUncaughtExceptionHandler;
		}

		public void UncaughtException(Java.Lang.Thread t, Throwable e)
		{
			Task.Run(() => DelayBeforeTerminating(t, e));
		}

		private async Task DelayBeforeTerminating(Java.Lang.Thread t, Throwable e)
		{
			iFit.Logger.Log.Trace("CrashReporter", "Delaying app termination to allow us to more reliably persist crashes");
			await Task.Delay(TimeSpan.FromSeconds(1.0));
			try
			{
				Task onCrashPersisted = CrashReporterUtil.Instance.PersistenceLockReleased();
				Task task = Task.Delay(TimeSpan.FromSeconds(5.0));
				if (await Task.WhenAny(onCrashPersisted, task) == onCrashPersisted)
				{
					iFit.Logger.Log.Trace("CrashReporter", "Crash was persisted successfully");
					if (Mvx.TryResolve<ILastGoodStateReporter>(out var service))
					{
						service.ClearCache();
					}
				}
				else
				{
					iFit.Logger.Log.Error("CrashReporter", "Crash failed to persist due to timeout");
				}
			}
			finally
			{
				if (defaultHandler != null)
				{
					defaultHandler.UncaughtException(t, e);
				}
				else
				{
					JavaSystem.Exit(0);
				}
			}
		}
	}
}
namespace Shire.Core.Converters
{
	public class ObjectNullVisibilityConverter : IMvxValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value == null) ? ViewStates.Invisible : ViewStates.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
namespace Shire.Android
{
	[GeneratedCode("Xamarin.Android.Build.Tasks", "13.2.2.120")]
	public class Resource
	{
		public class Fraction
		{
			public static int dashboard_tile_start_button_size;

			public static int loading_circle_max_inset;

			public static int loading_circle_min_inset;

			public static int loading_circle_size;

			static Fraction()
			{
				dashboard_tile_start_button_size = 2131361792;
				loading_circle_max_inset = 2131361793;
				loading_circle_min_inset = 2131361794;
				loading_circle_size = 2131361795;
				ResourceIdManager.UpdateIdValues();
			}

			private Fraction()
			{
			}
		}

		public class Animation
		{
			public static int abc_fade_in;

			public static int abc_fade_out;

			public static int abc_grow_fade_in_from_bottom;

			public static int abc_popup_enter;

			public static int abc_popup_exit;

			public static int abc_shrink_fade_out_from_bottom;

			public static int abc_slide_in_bottom;

			public static int abc_slide_in_top;

			public static int abc_slide_out_bottom;

			public static int abc_slide_out_top;

			public static int abc_tooltip_enter;

			public static int abc_tooltip_exit;

			public static int BluetoothPulse;

			public static int btn_checkbox_to_checked_box_inner_merged_animation;

			public static int btn_checkbox_to_checked_box_outer_merged_animation;

			public static int btn_checkbox_to_checked_icon_null_animation;

			public static int btn_checkbox_to_unchecked_box_inner_merged_animation;

			public static int btn_checkbox_to_unchecked_check_path_merged_animation;

			public static int btn_checkbox_to_unchecked_icon_null_animation;

			public static int btn_radio_to_off_mtrl_dot_group_animation;

			public static int btn_radio_to_off_mtrl_ring_outer_animation;

			public static int btn_radio_to_off_mtrl_ring_outer_path_animation;

			public static int btn_radio_to_on_mtrl_dot_group_animation;

			public static int btn_radio_to_on_mtrl_ring_outer_animation;

			public static int btn_radio_to_on_mtrl_ring_outer_path_animation;

			public static int design_bottom_sheet_slide_in;

			public static int design_bottom_sheet_slide_out;

			public static int design_snackbar_in;

			public static int design_snackbar_out;

			static Animation()
			{
				abc_fade_in = 2130771968;
				abc_fade_out = 2130771969;
				abc_grow_fade_in_from_bottom = 2130771970;
				abc_popup_enter = 2130771971;
				abc_popup_exit = 2130771972;
				abc_shrink_fade_out_from_bottom = 2130771973;
				abc_slide_in_bottom = 2130771974;
				abc_slide_in_top = 2130771975;
				abc_slide_out_bottom = 2130771976;
				abc_slide_out_top = 2130771977;
				abc_tooltip_enter = 2130771978;
				abc_tooltip_exit = 2130771979;
				BluetoothPulse = 2130771980;
				btn_checkbox_to_checked_box_inner_merged_animation = 2130771981;
				btn_checkbox_to_checked_box_outer_merged_animation = 2130771982;
				btn_checkbox_to_checked_icon_null_animation = 2130771983;
				btn_checkbox_to_unchecked_box_inner_merged_animation = 2130771984;
				btn_checkbox_to_unchecked_check_path_merged_animation = 2130771985;
				btn_checkbox_to_unchecked_icon_null_animation = 2130771986;
				btn_radio_to_off_mtrl_dot_group_animation = 2130771987;
				btn_radio_to_off_mtrl_ring_outer_animation = 2130771988;
				btn_radio_to_off_mtrl_ring_outer_path_animation = 2130771989;
				btn_radio_to_on_mtrl_dot_group_animation = 2130771990;
				btn_radio_to_on_mtrl_ring_outer_animation = 2130771991;
				btn_radio_to_on_mtrl_ring_outer_path_animation = 2130771992;
				design_bottom_sheet_slide_in = 2130771993;
				design_bottom_sheet_slide_out = 2130771994;
				design_snackbar_in = 2130771995;
				design_snackbar_out = 2130771996;
				ResourceIdManager.UpdateIdValues();
			}

			private Animation()
			{
			}
		}

		public class Animator
		{
			public static int design_appbar_state_list_animator;

			public static int design_fab_hide_motion_spec;

			public static int design_fab_show_motion_spec;

			public static int LowerLeftIndicatorDot;

			public static int LowerRightIndicatorDot;

			public static int mtrl_btn_state_list_anim;

			public static int mtrl_btn_unelevated_state_list_anim;

			public static int mtrl_chip_state_list_anim;

			public static int mtrl_fab_hide_motion_spec;

			public static int mtrl_fab_show_motion_spec;

			public static int mtrl_fab_transformation_sheet_collapse_spec;

			public static int mtrl_fab_transformation_sheet_expand_spec;

			public static int UpperLeftIndicatorDot;

			public static int UpperRightIndicatorDot;

			static Animator()
			{
				design_appbar_state_list_animator = 2130837504;
				design_fab_hide_motion_spec = 2130837505;
				design_fab_show_motion_spec = 2130837506;
				LowerLeftIndicatorDot = 2130837507;
				LowerRightIndicatorDot = 2130837508;
				mtrl_btn_state_list_anim = 2130837509;
				mtrl_btn_unelevated_state_list_anim = 2130837510;
				mtrl_chip_state_list_anim = 2130837511;
				mtrl_fab_hide_motion_spec = 2130837512;
				mtrl_fab_show_motion_spec = 2130837513;
				mtrl_fab_transformation_sheet_collapse_spec = 2130837514;
				mtrl_fab_transformation_sheet_expand_spec = 2130837515;
				UpperLeftIndicatorDot = 2130837516;
				UpperRightIndicatorDot = 2130837517;
				ResourceIdManager.UpdateIdValues();
			}

			private Animator()
			{
			}
		}

		public class Array
		{
			public static int exo_playback_speeds;

			public static int exo_speed_multiplied_by_100;

			static Array()
			{
				exo_playback_speeds = 2130903040;
				exo_speed_multiplied_by_100 = 2130903041;
				ResourceIdManager.UpdateIdValues();
			}

			private Array()
			{
			}
		}

		public class Attribute
		{
			public static int actionBarDivider;

			public static int actionBarItemBackground;

			public static int actionBarPopupTheme;

			public static int actionBarSize;

			public static int actionBarSplitStyle;

			public static int actionBarStyle;

			public static int actionBarTabBarStyle;

			public static int actionBarTabStyle;

			public static int actionBarTabTextStyle;

			public static int actionBarTheme;

			public static int actionBarWidgetTheme;

			public static int actionButtonStyle;

			public static int actionDropDownStyle;

			public static int actionLayout;

			public static int actionMenuTextAppearance;

			public static int actionMenuTextColor;

			public static int actionModeBackground;

			public static int actionModeCloseButtonStyle;

			public static int actionModeCloseContentDescription;

			public static int actionModeCloseDrawable;

			public static int actionModeCopyDrawable;

			public static int actionModeCutDrawable;

			public static int actionModeFindDrawable;

			public static int actionModePasteDrawable;

			public static int actionModePopupWindowStyle;

			public static int actionModeSelectAllDrawable;

			public static int actionModeShareDrawable;

			public static int actionModeSplitBackground;

			public static int actionModeStyle;

			public static int actionModeTheme;

			public static int actionModeWebSearchDrawable;

			public static int actionOverflowButtonStyle;

			public static int actionOverflowMenuStyle;

			public static int actionProviderClass;

			public static int actionViewClass;

			public static int activityAction;

			public static int activityChooserViewStyle;

			public static int activityName;

			public static int ad_marker_color;

			public static int ad_marker_width;

			public static int alertDialogButtonGroupStyle;

			public static int alertDialogCenterButtons;

			public static int alertDialogStyle;

			public static int alertDialogTheme;

			public static int allowStacking;

			public static int alpha;

			public static int alphabeticModifiers;

			public static int alwaysExpand;

			public static int ambientEnabled;

			public static int angle;

			public static int animation_enabled;

			public static int arrowHeadLength;

			public static int arrowShaftLength;

			public static int autoCompleteTextViewStyle;

			public static int autoPlay;

			public static int autoSizeMaxTextSize;

			public static int autoSizeMinTextSize;

			public static int autoSizePresetSizes;

			public static int autoSizeStepGranularity;

			public static int autoSizeTextType;

			public static int auto_show;

			public static int background;

			public static int backgroundRingColor;

			public static int backgroundSplit;

			public static int backgroundStacked;

			public static int backgroundTint;

			public static int backgroundTintMode;

			public static int barLeftOfLabel;

			public static int barLength;

			public static int bar_gravity;

			public static int bar_height;

			public static int behavior_autoHide;

			public static int behavior_fitToContents;

			public static int behavior_hideable;

			public static int behavior_overlapTop;

			public static int behavior_peekHeight;

			public static int behavior_skipCollapsed;

			public static int borderlessButtonStyle;

			public static int borderWidth;

			public static int bottomAppBarStyle;

			public static int bottomNavigationStyle;

			public static int bottomSheetDialogTheme;

			public static int bottomSheetStyle;

			public static int boxBackgroundColor;

			public static int boxBackgroundMode;

			public static int boxCollapsedPaddingTop;

			public static int boxCornerRadiusBottomEnd;

			public static int boxCornerRadiusBottomStart;

			public static int boxCornerRadiusTopEnd;

			public static int boxCornerRadiusTopStart;

			public static int boxStrokeColor;

			public static int boxStrokeWidth;

			public static int buffered_color;

			public static int buttonBarButtonStyle;

			public static int buttonBarNegativeButtonStyle;

			public static int buttonBarNeutralButtonStyle;

			public static int buttonBarPositiveButtonStyle;

			public static int buttonBarStyle;

			public static int buttonCompat;

			public static int buttonGravity;

			public static int buttonIconDimen;

			public static int buttonPanelSideLayout;

			public static int buttonSize;

			public static int buttonStyle;

			public static int buttonStyleSmall;

			public static int buttonTint;

			public static int buttonTintMode;

			public static int cameraBearing;

			public static int cameraMaxZoomPreference;

			public static int cameraMinZoomPreference;

			public static int cameraTargetLat;

			public static int cameraTargetLng;

			public static int cameraTilt;

			public static int cameraZoom;

			public static int cardBackgroundColor;

			public static int cardCornerRadius;

			public static int cardElevation;

			public static int cardMaxElevation;

			public static int cardPreventCornerOverlap;

			public static int cardUseCompatPadding;

			public static int cardViewStyle;

			public static int checkboxStyle;

			public static int checkedChip;

			public static int checkedIcon;

			public static int checkedIconEnabled;

			public static int checkedIconVisible;

			public static int checkedTextViewStyle;

			public static int chipBackgroundColor;

			public static int chipCornerRadius;

			public static int chipEndPadding;

			public static int chipGroupStyle;

			public static int chipIcon;

			public static int chipIconEnabled;

			public static int chipIconSize;

			public static int chipIconTint;

			public static int chipIconVisible;

			public static int chipMinHeight;

			public static int chipSpacing;

			public static int chipSpacingHorizontal;

			public static int chipSpacingVertical;

			public static int chipStandaloneStyle;

			public static int chipStartPadding;

			public static int chipStrokeColor;

			public static int chipStrokeWidth;

			public static int chipStyle;

			public static int circleCrop;

			public static int civ_border_color;

			public static int civ_border_overlay;

			public static int civ_border_width;

			public static int civ_fill_color;

			public static int clearTop;

			public static int closeIcon;

			public static int closeIconEnabled;

			public static int closeIconEndPadding;

			public static int closeIconSize;

			public static int closeIconStartPadding;

			public static int closeIconTint;

			public static int closeIconVisible;

			public static int closeItemLayout;

			public static int collapseContentDescription;

			public static int collapsedTitleGravity;

			public static int collapsedTitleTextAppearance;

			public static int collapseIcon;

			public static int color;

			public static int colorAccent;

			public static int colorBackgroundFloating;

			public static int colorButtonNormal;

			public static int colorControlActivated;

			public static int colorControlHighlight;

			public static int colorControlNormal;

			public static int colorError;

			public static int colorPrimary;

			public static int colorPrimaryDark;

			public static int colorScheme;

			public static int colorSecondary;

			public static int colorSwitchThumbNormal;

			public static int commitIcon;

			public static int com_facebook_auxiliary_view_position;

			public static int com_facebook_confirm_logout;

			public static int com_facebook_foreground_color;

			public static int com_facebook_horizontal_alignment;

			public static int com_facebook_is_cropped;

			public static int com_facebook_login_button_radius;

			public static int com_facebook_login_button_transparency;

			public static int com_facebook_login_text;

			public static int com_facebook_logout_text;

			public static int com_facebook_object_id;

			public static int com_facebook_object_type;

			public static int com_facebook_preset_size;

			public static int com_facebook_style;

			public static int com_facebook_tooltip_mode;

			public static int ConnectedNoInternet;

			public static int ConnectedStrong;

			public static int ConnectedStrongest;

			public static int ConnectedStrongestLocked;

			public static int ConnectedStrongLocked;

			public static int ConnectedWeak;

			public static int ConnectedWeakest;

			public static int ConnectedWeakLocked;

			public static int containerBackground;

			public static int containerPadding;

			public static int contentDescription;

			public static int contentInsetEnd;

			public static int contentInsetEndWithActions;

			public static int contentInsetLeft;

			public static int contentInsetRight;

			public static int contentInsetStart;

			public static int contentInsetStartWithNavigation;

			public static int contentPadding;

			public static int contentPaddingBottom;

			public static int contentPaddingLeft;

			public static int contentPaddingRight;

			public static int contentPaddingTop;

			public static int contentScrim;

			public static int controlBackground;

			public static int controller_layout_id;

			public static int coordinatorLayoutStyle;

			public static int cornerRadius;

			public static int counterEnabled;

			public static int counterMaxLength;

			public static int counterOverflowTextAppearance;

			public static int counterTextAppearance;

			public static int cropByteArray;

			public static int customNavigationLayout;

			public static int defaultQueryHint;

			public static int defaultResource;

			public static int default_artwork;

			public static int dialogCornerRadius;

			public static int dialogPreferredPadding;

			public static int dialogTheme;

			public static int Disabled;

			public static int displayOptions;

			public static int divider;

			public static int dividerHorizontal;

			public static int dividerPadding;

			public static int dividerVertical;

			public static int dotTint;

			public static int drawableBottomCompat;

			public static int drawableEndCompat;

			public static int drawableLeftCompat;

			public static int drawableRightCompat;

			public static int drawableSize;

			public static int drawableStartCompat;

			public static int drawableTint;

			public static int drawableTintMode;

			public static int drawableTopCompat;

			public static int drawerArrowStyle;

			public static int drawerLayoutStyle;

			public static int dropdownListPreferredItemHeight;

			public static int dropDownListViewStyle;

			public static int editTextBackground;

			public static int editTextColor;

			public static int editTextStyle;

			public static int elevation;

			public static int EnabledNotConnected;

			public static int enforceMaterialTheme;

			public static int enforceTextAppearance;

			public static int errorEnabled;

			public static int errorTextAppearance;

			public static int error_view_layout_resource;

			public static int expandActivityOverflowButtonDrawable;

			public static int expanded;

			public static int expandedTitleGravity;

			public static int expandedTitleMargin;

			public static int expandedTitleMarginBottom;

			public static int expandedTitleMarginEnd;

			public static int expandedTitleMarginStart;

			public static int expandedTitleMarginTop;

			public static int expandedTitleTextAppearance;

			public static int fabAlignmentMode;

			public static int fabCradleMargin;

			public static int fabCradleRoundedCornerRadius;

			public static int fabCradleVerticalOffset;

			public static int fabCustomSize;

			public static int fabSize;

			public static int fastforward_increment;

			public static int fastScrollEnabled;

			public static int fastScrollHorizontalThumbDrawable;

			public static int fastScrollHorizontalTrackDrawable;

			public static int fastScrollVerticalThumbDrawable;

			public static int fastScrollVerticalTrackDrawable;

			public static int finishPrimaryWithSecondary;

			public static int finishSecondaryWithPrimary;

			public static int firstBaselineToTopHeight;

			public static int floatingActionButtonStyle;

			public static int font;

			public static int fontFamily;

			public static int fontProviderAuthority;

			public static int fontProviderCerts;

			public static int fontProviderFetchStrategy;

			public static int fontProviderFetchTimeout;

			public static int fontProviderPackage;

			public static int fontProviderQuery;

			public static int fontProviderSystemFontFamily;

			public static int fontStyle;

			public static int fontVariationSettings;

			public static int fontWeight;

			public static int foregroundInsidePadding;

			public static int foregroundRingColor;

			public static int gapBetweenBars;

			public static int goIcon;

			public static int headerLayout;

			public static int height;

			public static int helperText;

			public static int helperTextEnabled;

			public static int helperTextTextAppearance;

			public static int hideMotionSpec;

			public static int hideOnContentScroll;

			public static int hideOnScroll;

			public static int hide_during_ads;

			public static int hide_on_touch;

			public static int hintAnimationEnabled;

			public static int hintEnabled;

			public static int hintTextAppearance;

			public static int homeAsUpIndicator;

			public static int homeLayout;

			public static int hoveredFocusedTranslationZ;

			public static int icon;

			public static int iconEndPadding;

			public static int iconGravity;

			public static int iconifiedByDefault;

			public static int iconPadding;

			public static int iconSize;

			public static int iconStartPadding;

			public static int iconTint;

			public static int iconTintMode;

			public static int imageAspectRatio;

			public static int imageAspectRatioAdjust;

			public static int imageButtonStyle;

			public static int indeterminateProgressStyle;

			public static int initialActivityCount;

			public static int insetForeground;

			public static int isLightTheme;

			public static int itemBackground;

			public static int itemHorizontalPadding;

			public static int itemHorizontalTranslationEnabled;

			public static int itemIconPadding;

			public static int itemIconSize;

			public static int itemIconTint;

			public static int itemPadding;

			public static int itemSpacing;

			public static int itemTextAppearance;

			public static int itemTextAppearanceActive;

			public static int itemTextAppearanceInactive;

			public static int itemTextColor;

			public static int keep_content_on_player_reset;

			public static int keylines;

			public static int labelVisibilityMode;

			public static int lastBaselineToBottomHeight;

			public static int latLngBoundsNorthEastLatitude;

			public static int latLngBoundsNorthEastLongitude;

			public static int latLngBoundsSouthWestLatitude;

			public static int latLngBoundsSouthWestLongitude;

			public static int layout;

			public static int layoutManager;

			public static int layout_anchor;

			public static int layout_anchorGravity;

			public static int layout_aspectRatio;

			public static int layout_behavior;

			public static int layout_collapseMode;

			public static int layout_collapseParallaxMultiplier;

			public static int layout_dodgeInsetEdges;

			public static int layout_heightPercent;

			public static int layout_insetEdge;

			public static int layout_keyline;

			public static int layout_marginBottomPercent;

			public static int layout_marginEndPercent;

			public static int layout_marginLeftPercent;

			public static int layout_marginPercent;

			public static int layout_marginRightPercent;

			public static int layout_marginStartPercent;

			public static int layout_marginTopPercent;

			public static int layout_scrollFlags;

			public static int layout_scrollInterpolator;

			public static int layout_widthPercent;

			public static int liftOnScroll;

			public static int lineHeight;

			public static int lineSpacing;

			public static int listChoiceBackgroundIndicator;

			public static int listChoiceIndicatorMultipleAnimated;

			public static int listChoiceIndicatorSingleAnimated;

			public static int listDividerAlertDialog;

			public static int listItemLayout;

			public static int listLayout;

			public static int listMenuViewStyle;

			public static int listPopupWindowStyle;

			public static int listPreferredItemHeight;

			public static int listPreferredItemHeightLarge;

			public static int listPreferredItemHeightSmall;

			public static int listPreferredItemPaddingEnd;

			public static int listPreferredItemPaddingLeft;

			public static int listPreferredItemPaddingRight;

			public static int listPreferredItemPaddingStart;

			public static int liteMode;

			public static int logo;

			public static int logoDescription;

			public static int lottieAnimationViewStyle;

			public static int lottie_autoPlay;

			public static int lottie_cacheComposition;

			public static int lottie_colorFilter;

			public static int lottie_enableMergePathsForKitKatAndAbove;

			public static int lottie_fallbackRes;

			public static int lottie_fileName;

			public static int lottie_ignoreDisabledSystemAnimations;

			public static int lottie_imageAssetsFolder;

			public static int lottie_loop;

			public static int lottie_progress;

			public static int lottie_rawRes;

			public static int lottie_renderMode;

			public static int lottie_repeatCount;

			public static int lottie_repeatMode;

			public static int lottie_scale;

			public static int lottie_speed;

			public static int lottie_url;

			public static int lStar;

			public static int mapType;

			public static int materialButtonStyle;

			public static int materialCardViewStyle;

			public static int maxActionInlineWidth;

			public static int maxButtonHeight;

			public static int maxImageSize;

			public static int measureWithLargestChild;

			public static int menu;

			public static int multiChoiceItemLayout;

			public static int MvxBind;

			public static int MvxDropDownItemTemplate;

			public static int MvxGroupItemTemplate;

			public static int MvxItemTemplate;

			public static int MvxLang;

			public static int MvxSource;

			public static int MvxTemplate;

			public static int navigationContentDescription;

			public static int navigationIcon;

			public static int navigationMode;

			public static int navigationViewStyle;

			public static int nestedScrollViewStyle;

			public static int numericModifiers;

			public static int overlapAnchor;

			public static int paddingBottomNoButtons;

			public static int paddingEnd;

			public static int paddingStart;

			public static int paddingTopNoTitle;

			public static int panelBackground;

			public static int panelMenuListTheme;

			public static int panelMenuListWidth;

			public static int passwordToggleContentDescription;

			public static int passwordToggleDrawable;

			public static int passwordToggleEnabled;

			public static int passwordToggleTint;

			public static int passwordToggleTintMode;

			public static int placeholderActivityName;

			public static int played_ad_marker_color;

			public static int played_color;

			public static int player_layout_id;

			public static int popupMenuStyle;

			public static int popupTheme;

			public static int popupWindowStyle;

			public static int preserveIconSpacing;

			public static int pressedTranslationZ;

			public static int primaryActivityName;

			public static int progressBarPadding;

			public static int progressBarStyle;

			public static int queryBackground;

			public static int queryHint;

			public static int queryPatterns;

			public static int radioButtonStyle;

			public static int ratingBarCustomStyle;

			public static int ratingBarMarginStart;

			public static int ratingBarStyle;

			public static int ratingBarStyleIndicator;

			public static int ratingBarStyleSmall;

			public static int recyclerViewStyle;

			public static int repeat_toggle_modes;

			public static int resize_mode;

			public static int reverseLayout;

			public static int rewind_increment;

			public static int rippleColor;

			public static int scopeUris;

			public static int scrimAnimationDuration;

			public static int scrimBackground;

			public static int scrimVisibleHeightTrigger;

			public static int scrubber_color;

			public static int scrubber_disabled_size;

			public static int scrubber_dragged_size;

			public static int scrubber_drawable;

			public static int scrubber_enabled_size;

			public static int searchHintIcon;

			public static int searchIcon;

			public static int searchViewStyle;

			public static int secondaryActivityAction;

			public static int secondaryActivityName;

			public static int seekBarStyle;

			public static int selectableItemBackground;

			public static int selectableItemBackgroundBorderless;

			public static int shortcutMatchRequired;

			public static int showAsAction;

			public static int showDividers;

			public static int showLoadingAnimation;

			public static int showMotionSpec;

			public static int showText;

			public static int showTitle;

			public static int show_buffering;

			public static int show_fastforward_button;

			public static int show_next_button;

			public static int show_previous_button;

			public static int show_rewind_button;

			public static int show_shuffle_button;

			public static int show_subtitle_button;

			public static int show_timeout;

			public static int show_vr_button;

			public static int shutter_background_color;

			public static int singleChoiceItemLayout;

			public static int singleColorMode;

			public static int singleLine;

			public static int singleSelection;

			public static int snackbarButtonStyle;

			public static int snackbarStyle;

			public static int spanCount;

			public static int spinBars;

			public static int spinnerDropDownItemStyle;

			public static int spinnerStyle;

			public static int splitLayoutDirection;

			public static int splitMinSmallestWidth;

			public static int splitMinWidth;

			public static int splitRatio;

			public static int splitTrack;

			public static int srcCompat;

			public static int stackFromEnd;

			public static int state_above_anchor;

			public static int state_collapsed;

			public static int state_collapsible;

			public static int state_liftable;

			public static int state_lifted;

			public static int statusBarBackground;

			public static int statusBarScrim;

			public static int strokeColor;

			public static int strokeWidth;

			public static int subMenuArrow;

			public static int submitBackground;

			public static int subtitle;

			public static int subtitleTextAppearance;

			public static int subtitleTextColor;

			public static int subtitleTextStyle;

			public static int suggestionRowLayout;

			public static int surface_type;

			public static int swipeRefreshLayoutProgressSpinnerBackgroundColor;

			public static int switchMinWidth;

			public static int switchPadding;

			public static int switchStyle;

			public static int switchTextAppearance;

			public static int tabBackground;

			public static int tabContentStart;

			public static int tabGravity;

			public static int tabIconTint;

			public static int tabIconTintMode;

			public static int tabIndicator;

			public static int tabIndicatorAnimationDuration;

			public static int tabIndicatorColor;

			public static int tabIndicatorFullWidth;

			public static int tabIndicatorGravity;

			public static int tabIndicatorHeight;

			public static int tabInlineLabel;

			public static int tabMaxWidth;

			public static int tabMinWidth;

			public static int tabMode;

			public static int tabPadding;

			public static int tabPaddingBottom;

			public static int tabPaddingEnd;

			public static int tabPaddingStart;

			public static int tabPaddingTop;

			public static int tabRippleColor;

			public static int tabSelectedTextColor;

			public static int tabStyle;

			public static int tabTextAppearance;

			public static int tabTextColor;

			public static int tabUnboundedRipple;

			public static int textAllCaps;

			public static int textAppearanceBody1;

			public static int textAppearanceBody2;

			public static int textAppearanceButton;

			public static int textAppearanceCaption;

			public static int textAppearanceHeadline1;

			public static int textAppearanceHeadline2;

			public static int textAppearanceHeadline3;

			public static int textAppearanceHeadline4;

			public static int textAppearanceHeadline5;

			public static int textAppearanceHeadline6;

			public static int textAppearanceLargePopupMenu;

			public static int textAppearanceListItem;

			public static int textAppearanceListItemSecondary;

			public static int textAppearanceListItemSmall;

			public static int textAppearanceOverline;

			public static int textAppearancePopupMenuHeader;

			public static int textAppearanceSearchResultSubtitle;

			public static int textAppearanceSearchResultTitle;

			public static int textAppearanceSmallPopupMenu;

			public static int textAppearanceSubtitle1;

			public static int textAppearanceSubtitle2;

			public static int textColorAlertDialogListItem;

			public static int textColorSearchUrl;

			public static int textEndPadding;

			public static int textInputStyle;

			public static int textLocale;

			public static int textStartPadding;

			public static int theme;

			public static int thickness;

			public static int thumbTextPadding;

			public static int thumbTint;

			public static int thumbTintMode;

			public static int tickMark;

			public static int tickMarkTint;

			public static int tickMarkTintMode;

			public static int time_bar_min_update_interval;

			public static int tint;

			public static int tintMode;

			public static int title;

			public static int titleEnabled;

			public static int titleMargin;

			public static int titleMarginBottom;

			public static int titleMarginEnd;

			public static int titleMargins;

			public static int titleMarginStart;

			public static int titleMarginTop;

			public static int titleTextAppearance;

			public static int titleTextColor;

			public static int titleTextStyle;

			public static int toolbarId;

			public static int toolbarNavigationButtonStyle;

			public static int toolbarStyle;

			public static int tooltipForegroundColor;

			public static int tooltipFrameBackground;

			public static int tooltipText;

			public static int touch_target_height;

			public static int track;

			public static int trackTint;

			public static int trackTintMode;

			public static int ttcIndex;

			public static int typeface;

			public static int uiCompass;

			public static int uiMapToolbar;

			public static int uiRotateGestures;

			public static int uiScrollGestures;

			public static int uiScrollGesturesDuringRotateOrZoom;

			public static int uiTiltGestures;

			public static int uiZoomControls;

			public static int uiZoomGestures;

			public static int Unknown;

			public static int unplayed_color;

			public static int useCompatPadding;

			public static int useViewLifecycle;

			public static int use_artwork;

			public static int use_controller;

			public static int use_sensor_rotation;

			public static int viewInflaterClass;

			public static int voiceIcon;

			public static int windowActionBar;

			public static int windowActionBarOverlay;

			public static int windowActionModeOverlay;

			public static int windowFixedHeightMajor;

			public static int windowFixedHeightMinor;

			public static int windowFixedWidthMajor;

			public static int windowFixedWidthMinor;

			public static int windowMinWidthMajor;

			public static int windowMinWidthMinor;

			public static int windowNoTitle;

			public static int zOrderOnTop;

			static Attribute()
			{
				actionBarDivider = 2130968594;
				actionBarItemBackground = 2130968595;
				actionBarPopupTheme = 2130968596;
				actionBarSize = 2130968597;
				actionBarSplitStyle = 2130968598;
				actionBarStyle = 2130968599;
				actionBarTabBarStyle = 2130968600;
				actionBarTabStyle = 2130968601;
				actionBarTabTextStyle = 2130968602;
				actionBarTheme = 2130968603;
				actionBarWidgetTheme = 2130968604;
				actionButtonStyle = 2130968605;
				actionDropDownStyle = 2130968606;
				actionLayout = 2130968607;
				actionMenuTextAppearance = 2130968608;
				actionMenuTextColor = 2130968609;
				actionModeBackground = 2130968610;
				actionModeCloseButtonStyle = 2130968611;
				actionModeCloseContentDescription = 2130968612;
				actionModeCloseDrawable = 2130968613;
				actionModeCopyDrawable = 2130968614;
				actionModeCutDrawable = 2130968615;
				actionModeFindDrawable = 2130968616;
				actionModePasteDrawable = 2130968617;
				actionModePopupWindowStyle = 2130968618;
				actionModeSelectAllDrawable = 2130968619;
				actionModeShareDrawable = 2130968620;
				actionModeSplitBackground = 2130968621;
				actionModeStyle = 2130968622;
				actionModeTheme = 2130968623;
				actionModeWebSearchDrawable = 2130968624;
				actionOverflowButtonStyle = 2130968625;
				actionOverflowMenuStyle = 2130968626;
				actionProviderClass = 2130968627;
				actionViewClass = 2130968628;
				activityAction = 2130968629;
				activityChooserViewStyle = 2130968630;
				activityName = 2130968631;
				ad_marker_color = 2130968632;
				ad_marker_width = 2130968633;
				alertDialogButtonGroupStyle = 2130968634;
				alertDialogCenterButtons = 2130968635;
				alertDialogStyle = 2130968636;
				alertDialogTheme = 2130968637;
				allowStacking = 2130968638;
				alpha = 2130968639;
				alphabeticModifiers = 2130968640;
				alwaysExpand = 2130968641;
				ambientEnabled = 2130968642;
				angle = 2130968643;
				animation_enabled = 2130968644;
				arrowHeadLength = 2130968645;
				arrowShaftLength = 2130968646;
				autoCompleteTextViewStyle = 2130968647;
				autoPlay = 2130968648;
				autoSizeMaxTextSize = 2130968649;
				autoSizeMinTextSize = 2130968650;
				autoSizePresetSizes = 2130968651;
				autoSizeStepGranularity = 2130968652;
				autoSizeTextType = 2130968653;
				auto_show = 2130968654;
				background = 2130968655;
				backgroundRingColor = 2130968656;
				backgroundSplit = 2130968657;
				backgroundStacked = 2130968658;
				backgroundTint = 2130968659;
				backgroundTintMode = 2130968660;
				barLeftOfLabel = 2130968661;
				barLength = 2130968662;
				bar_gravity = 2130968663;
				bar_height = 2130968664;
				behavior_autoHide = 2130968665;
				behavior_fitToContents = 2130968666;
				behavior_hideable = 2130968667;
				behavior_overlapTop = 2130968668;
				behavior_peekHeight = 2130968669;
				behavior_skipCollapsed = 2130968670;
				borderlessButtonStyle = 2130968672;
				borderWidth = 2130968671;
				bottomAppBarStyle = 2130968673;
				bottomNavigationStyle = 2130968674;
				bottomSheetDialogTheme = 2130968675;
				bottomSheetStyle = 2130968676;
				boxBackgroundColor = 2130968677;
				boxBackgroundMode = 2130968678;
				boxCollapsedPaddingTop = 2130968679;
				boxCornerRadiusBottomEnd = 2130968680;
				boxCornerRadiusBottomStart = 2130968681;
				boxCornerRadiusTopEnd = 2130968682;
				boxCornerRadiusTopStart = 2130968683;
				boxStrokeColor = 2130968684;
				boxStrokeWidth = 2130968685;
				buffered_color = 2130968686;
				buttonBarButtonStyle = 2130968687;
				buttonBarNegativeButtonStyle = 2130968688;
				buttonBarNeutralButtonStyle = 2130968689;
				buttonBarPositiveButtonStyle = 2130968690;
				buttonBarStyle = 2130968691;
				buttonCompat = 2130968692;
				buttonGravity = 2130968693;
				buttonIconDimen = 2130968694;
				buttonPanelSideLayout = 2130968695;
				buttonSize = 2130968696;
				buttonStyle = 2130968697;
				buttonStyleSmall = 2130968698;
				buttonTint = 2130968699;
				buttonTintMode = 2130968700;
				cameraBearing = 2130968701;
				cameraMaxZoomPreference = 2130968702;
				cameraMinZoomPreference = 2130968703;
				cameraTargetLat = 2130968704;
				cameraTargetLng = 2130968705;
				cameraTilt = 2130968706;
				cameraZoom = 2130968707;
				cardBackgroundColor = 2130968708;
				cardCornerRadius = 2130968709;
				cardElevation = 2130968710;
				cardMaxElevation = 2130968711;
				cardPreventCornerOverlap = 2130968712;
				cardUseCompatPadding = 2130968713;
				cardViewStyle = 2130968714;
				checkboxStyle = 2130968715;
				checkedChip = 2130968716;
				checkedIcon = 2130968717;
				checkedIconEnabled = 2130968718;
				checkedIconVisible = 2130968719;
				checkedTextViewStyle = 2130968720;
				chipBackgroundColor = 2130968721;
				chipCornerRadius = 2130968722;
				chipEndPadding = 2130968723;
				chipGroupStyle = 2130968724;
				chipIcon = 2130968725;
				chipIconEnabled = 2130968726;
				chipIconSize = 2130968727;
				chipIconTint = 2130968728;
				chipIconVisible = 2130968729;
				chipMinHeight = 2130968730;
				chipSpacing = 2130968731;
				chipSpacingHorizontal = 2130968732;
				chipSpacingVertical = 2130968733;
				chipStandaloneStyle = 2130968734;
				chipStartPadding = 2130968735;
				chipStrokeColor = 2130968736;
				chipStrokeWidth = 2130968737;
				chipStyle = 2130968738;
				circleCrop = 2130968739;
				civ_border_color = 2130968740;
				civ_border_overlay = 2130968741;
				civ_border_width = 2130968742;
				civ_fill_color = 2130968743;
				clearTop = 2130968744;
				closeIcon = 2130968745;
				closeIconEnabled = 2130968746;
				closeIconEndPadding = 2130968747;
				closeIconSize = 2130968748;
				closeIconStartPadding = 2130968749;
				closeIconTint = 2130968750;
				closeIconVisible = 2130968751;
				closeItemLayout = 2130968752;
				collapseContentDescription = 2130968753;
				collapsedTitleGravity = 2130968755;
				collapsedTitleTextAppearance = 2130968756;
				collapseIcon = 2130968754;
				color = 2130968757;
				colorAccent = 2130968758;
				colorBackgroundFloating = 2130968759;
				colorButtonNormal = 2130968760;
				colorControlActivated = 2130968761;
				colorControlHighlight = 2130968762;
				colorControlNormal = 2130968763;
				colorError = 2130968764;
				colorPrimary = 2130968765;
				colorPrimaryDark = 2130968766;
				colorScheme = 2130968767;
				colorSecondary = 2130968768;
				colorSwitchThumbNormal = 2130968769;
				commitIcon = 2130968784;
				com_facebook_auxiliary_view_position = 2130968770;
				com_facebook_confirm_logout = 2130968771;
				com_facebook_foreground_color = 2130968772;
				com_facebook_horizontal_alignment = 2130968773;
				com_facebook_is_cropped = 2130968774;
				com_facebook_login_button_radius = 2130968775;
				com_facebook_login_button_transparency = 2130968776;
				com_facebook_login_text = 2130968777;
				com_facebook_logout_text = 2130968778;
				com_facebook_object_id = 2130968779;
				com_facebook_object_type = 2130968780;
				com_facebook_preset_size = 2130968781;
				com_facebook_style = 2130968782;
				com_facebook_tooltip_mode = 2130968783;
				ConnectedNoInternet = 2130968576;
				ConnectedStrong = 2130968577;
				ConnectedStrongest = 2130968579;
				ConnectedStrongestLocked = 2130968580;
				ConnectedStrongLocked = 2130968578;
				ConnectedWeak = 2130968581;
				ConnectedWeakest = 2130968583;
				ConnectedWeakLocked = 2130968582;
				containerBackground = 2130968785;
				containerPadding = 2130968786;
				contentDescription = 2130968787;
				contentInsetEnd = 2130968788;
				contentInsetEndWithActions = 2130968789;
				contentInsetLeft = 2130968790;
				contentInsetRight = 2130968791;
				contentInsetStart = 2130968792;
				contentInsetStartWithNavigation = 2130968793;
				contentPadding = 2130968794;
				contentPaddingBottom = 2130968795;
				contentPaddingLeft = 2130968796;
				contentPaddingRight = 2130968797;
				contentPaddingTop = 2130968798;
				contentScrim = 2130968799;
				controlBackground = 2130968800;
				controller_layout_id = 2130968801;
				coordinatorLayoutStyle = 2130968802;
				cornerRadius = 2130968803;
				counterEnabled = 2130968804;
				counterMaxLength = 2130968805;
				counterOverflowTextAppearance = 2130968806;
				counterTextAppearance = 2130968807;
				cropByteArray = 2130968808;
				customNavigationLayout = 2130968809;
				defaultQueryHint = 2130968810;
				defaultResource = 2130968811;
				default_artwork = 2130968812;
				dialogCornerRadius = 2130968813;
				dialogPreferredPadding = 2130968814;
				dialogTheme = 2130968815;
				Disabled = 2130968584;
				displayOptions = 2130968816;
				divider = 2130968817;
				dividerHorizontal = 2130968818;
				dividerPadding = 2130968819;
				dividerVertical = 2130968820;
				dotTint = 2130968821;
				drawableBottomCompat = 2130968822;
				drawableEndCompat = 2130968823;
				drawableLeftCompat = 2130968824;
				drawableRightCompat = 2130968825;
				drawableSize = 2130968826;
				drawableStartCompat = 2130968827;
				drawableTint = 2130968828;
				drawableTintMode = 2130968829;
				drawableTopCompat = 2130968830;
				drawerArrowStyle = 2130968831;
				drawerLayoutStyle = 2130968832;
				dropdownListPreferredItemHeight = 2130968834;
				dropDownListViewStyle = 2130968833;
				editTextBackground = 2130968835;
				editTextColor = 2130968836;
				editTextStyle = 2130968837;
				elevation = 2130968838;
				EnabledNotConnected = 2130968585;
				enforceMaterialTheme = 2130968839;
				enforceTextAppearance = 2130968840;
				errorEnabled = 2130968841;
				errorTextAppearance = 2130968842;
				error_view_layout_resource = 2130968843;
				expandActivityOverflowButtonDrawable = 2130968844;
				expanded = 2130968845;
				expandedTitleGravity = 2130968846;
				expandedTitleMargin = 2130968847;
				expandedTitleMarginBottom = 2130968848;
				expandedTitleMarginEnd = 2130968849;
				expandedTitleMarginStart = 2130968850;
				expandedTitleMarginTop = 2130968851;
				expandedTitleTextAppearance = 2130968852;
				fabAlignmentMode = 2130968853;
				fabCradleMargin = 2130968854;
				fabCradleRoundedCornerRadius = 2130968855;
				fabCradleVerticalOffset = 2130968856;
				fabCustomSize = 2130968857;
				fabSize = 2130968858;
				fastforward_increment = 2130968864;
				fastScrollEnabled = 2130968859;
				fastScrollHorizontalThumbDrawable = 2130968860;
				fastScrollHorizontalTrackDrawable = 2130968861;
				fastScrollVerticalThumbDrawable = 2130968862;
				fastScrollVerticalTrackDrawable = 2130968863;
				finishPrimaryWithSecondary = 2130968865;
				finishSecondaryWithPrimary = 2130968866;
				firstBaselineToTopHeight = 2130968867;
				floatingActionButtonStyle = 2130968868;
				font = 2130968869;
				fontFamily = 2130968870;
				fontProviderAuthority = 2130968871;
				fontProviderCerts = 2130968872;
				fontProviderFetchStrategy = 2130968873;
				fontProviderFetchTimeout = 2130968874;
				fontProviderPackage = 2130968875;
				fontProviderQuery = 2130968876;
				fontProviderSystemFontFamily = 2130968877;
				fontStyle = 2130968878;
				fontVariationSettings = 2130968879;
				fontWeight = 2130968880;
				foregroundInsidePadding = 2130968881;
				foregroundRingColor = 2130968882;
				gapBetweenBars = 2130968883;
				goIcon = 2130968884;
				headerLayout = 2130968885;
				height = 2130968886;
				helperText = 2130968887;
				helperTextEnabled = 2130968888;
				helperTextTextAppearance = 2130968889;
				hideMotionSpec = 2130968890;
				hideOnContentScroll = 2130968891;
				hideOnScroll = 2130968892;
				hide_during_ads = 2130968893;
				hide_on_touch = 2130968894;
				hintAnimationEnabled = 2130968895;
				hintEnabled = 2130968896;
				hintTextAppearance = 2130968897;
				homeAsUpIndicator = 2130968898;
				homeLayout = 2130968899;
				hoveredFocusedTranslationZ = 2130968900;
				icon = 2130968901;
				iconEndPadding = 2130968902;
				iconGravity = 2130968903;
				iconifiedByDefault = 2130968909;
				iconPadding = 2130968904;
				iconSize = 2130968905;
				iconStartPadding = 2130968906;
				iconTint = 2130968907;
				iconTintMode = 2130968908;
				imageAspectRatio = 2130968910;
				imageAspectRatioAdjust = 2130968911;
				imageButtonStyle = 2130968912;
				indeterminateProgressStyle = 2130968913;
				initialActivityCount = 2130968914;
				insetForeground = 2130968915;
				isLightTheme = 2130968916;
				itemBackground = 2130968917;
				itemHorizontalPadding = 2130968918;
				itemHorizontalTranslationEnabled = 2130968919;
				itemIconPadding = 2130968920;
				itemIconSize = 2130968921;
				itemIconTint = 2130968922;
				itemPadding = 2130968923;
				itemSpacing = 2130968924;
				itemTextAppearance = 2130968925;
				itemTextAppearanceActive = 2130968926;
				itemTextAppearanceInactive = 2130968927;
				itemTextColor = 2130968928;
				keep_content_on_player_reset = 2130968929;
				keylines = 2130968930;
				labelVisibilityMode = 2130968932;
				lastBaselineToBottomHeight = 2130968933;
				latLngBoundsNorthEastLatitude = 2130968934;
				latLngBoundsNorthEastLongitude = 2130968935;
				latLngBoundsSouthWestLatitude = 2130968936;
				latLngBoundsSouthWestLongitude = 2130968937;
				layout = 2130968938;
				layoutManager = 2130968939;
				layout_anchor = 2130968940;
				layout_anchorGravity = 2130968941;
				layout_aspectRatio = 2130968942;
				layout_behavior = 2130968943;
				layout_collapseMode = 2130968944;
				layout_collapseParallaxMultiplier = 2130968945;
				layout_dodgeInsetEdges = 2130968946;
				layout_heightPercent = 2130968947;
				layout_insetEdge = 2130968948;
				layout_keyline = 2130968949;
				layout_marginBottomPercent = 2130968950;
				layout_marginEndPercent = 2130968951;
				layout_marginLeftPercent = 2130968952;
				layout_marginPercent = 2130968953;
				layout_marginRightPercent = 2130968954;
				layout_marginStartPercent = 2130968955;
				layout_marginTopPercent = 2130968956;
				layout_scrollFlags = 2130968957;
				layout_scrollInterpolator = 2130968958;
				layout_widthPercent = 2130968959;
				liftOnScroll = 2130968960;
				lineHeight = 2130968961;
				lineSpacing = 2130968962;
				listChoiceBackgroundIndicator = 2130968963;
				listChoiceIndicatorMultipleAnimated = 2130968964;
				listChoiceIndicatorSingleAnimated = 2130968965;
				listDividerAlertDialog = 2130968966;
				listItemLayout = 2130968967;
				listLayout = 2130968968;
				listMenuViewStyle = 2130968969;
				listPopupWindowStyle = 2130968970;
				listPreferredItemHeight = 2130968971;
				listPreferredItemHeightLarge = 2130968972;
				listPreferredItemHeightSmall = 2130968973;
				listPreferredItemPaddingEnd = 2130968974;
				listPreferredItemPaddingLeft = 2130968975;
				listPreferredItemPaddingRight = 2130968976;
				listPreferredItemPaddingStart = 2130968977;
				liteMode = 2130968978;
				logo = 2130968979;
				logoDescription = 2130968980;
				lottieAnimationViewStyle = 2130968981;
				lottie_autoPlay = 2130968982;
				lottie_cacheComposition = 2130968983;
				lottie_colorFilter = 2130968984;
				lottie_enableMergePathsForKitKatAndAbove = 2130968985;
				lottie_fallbackRes = 2130968986;
				lottie_fileName = 2130968987;
				lottie_ignoreDisabledSystemAnimations = 2130968988;
				lottie_imageAssetsFolder = 2130968989;
				lottie_loop = 2130968990;
				lottie_progress = 2130968991;
				lottie_rawRes = 2130968992;
				lottie_renderMode = 2130968993;
				lottie_repeatCount = 2130968994;
				lottie_repeatMode = 2130968995;
				lottie_scale = 2130968996;
				lottie_speed = 2130968997;
				lottie_url = 2130968998;
				lStar = 2130968931;
				mapType = 2130968999;
				materialButtonStyle = 2130969000;
				materialCardViewStyle = 2130969001;
				maxActionInlineWidth = 2130969002;
				maxButtonHeight = 2130969003;
				maxImageSize = 2130969004;
				measureWithLargestChild = 2130969005;
				menu = 2130969006;
				multiChoiceItemLayout = 2130969007;
				MvxBind = 2130968586;
				MvxDropDownItemTemplate = 2130968587;
				MvxGroupItemTemplate = 2130968588;
				MvxItemTemplate = 2130968589;
				MvxLang = 2130968590;
				MvxSource = 2130968591;
				MvxTemplate = 2130968592;
				navigationContentDescription = 2130969008;
				navigationIcon = 2130969009;
				navigationMode = 2130969010;
				navigationViewStyle = 2130969011;
				nestedScrollViewStyle = 2130969012;
				numericModifiers = 2130969013;
				overlapAnchor = 2130969014;
				paddingBottomNoButtons = 2130969015;
				paddingEnd = 2130969016;
				paddingStart = 2130969017;
				paddingTopNoTitle = 2130969018;
				panelBackground = 2130969019;
				panelMenuListTheme = 2130969020;
				panelMenuListWidth = 2130969021;
				passwordToggleContentDescription = 2130969022;
				passwordToggleDrawable = 2130969023;
				passwordToggleEnabled = 2130969024;
				passwordToggleTint = 2130969025;
				passwordToggleTintMode = 2130969026;
				placeholderActivityName = 2130969027;
				played_ad_marker_color = 2130969028;
				played_color = 2130969029;
				player_layout_id = 2130969030;
				popupMenuStyle = 2130969031;
				popupTheme = 2130969032;
				popupWindowStyle = 2130969033;
				preserveIconSpacing = 2130969034;
				pressedTranslationZ = 2130969035;
				primaryActivityName = 2130969036;
				progressBarPadding = 2130969037;
				progressBarStyle = 2130969038;
				queryBackground = 2130969039;
				queryHint = 2130969040;
				queryPatterns = 2130969041;
				radioButtonStyle = 2130969042;
				ratingBarCustomStyle = 2130969043;
				ratingBarMarginStart = 2130969044;
				ratingBarStyle = 2130969045;
				ratingBarStyleIndicator = 2130969046;
				ratingBarStyleSmall = 2130969047;
				recyclerViewStyle = 2130969048;
				repeat_toggle_modes = 2130969049;
				resize_mode = 2130969050;
				reverseLayout = 2130969051;
				rewind_increment = 2130969052;
				rippleColor = 2130969053;
				scopeUris = 2130969054;
				scrimAnimationDuration = 2130969055;
				scrimBackground = 2130969056;
				scrimVisibleHeightTrigger = 2130969057;
				scrubber_color = 2130969058;
				scrubber_disabled_size = 2130969059;
				scrubber_dragged_size = 2130969060;
				scrubber_drawable = 2130969061;
				scrubber_enabled_size = 2130969062;
				searchHintIcon = 2130969063;
				searchIcon = 2130969064;
				searchViewStyle = 2130969065;
				secondaryActivityAction = 2130969066;
				secondaryActivityName = 2130969067;
				seekBarStyle = 2130969068;
				selectableItemBackground = 2130969069;
				selectableItemBackgroundBorderless = 2130969070;
				shortcutMatchRequired = 2130969071;
				showAsAction = 2130969072;
				showDividers = 2130969073;
				showLoadingAnimation = 2130969074;
				showMotionSpec = 2130969075;
				showText = 2130969076;
				showTitle = 2130969077;
				show_buffering = 2130969078;
				show_fastforward_button = 2130969079;
				show_next_button = 2130969080;
				show_previous_button = 2130969081;
				show_rewind_button = 2130969082;
				show_shuffle_button = 2130969083;
				show_subtitle_button = 2130969084;
				show_timeout = 2130969085;
				show_vr_button = 2130969086;
				shutter_background_color = 2130969087;
				singleChoiceItemLayout = 2130969088;
				singleColorMode = 2130969089;
				singleLine = 2130969090;
				singleSelection = 2130969091;
				snackbarButtonStyle = 2130969092;
				snackbarStyle = 2130969093;
				spanCount = 2130969094;
				spinBars = 2130969095;
				spinnerDropDownItemStyle = 2130969096;
				spinnerStyle = 2130969097;
				splitLayoutDirection = 2130969098;
				splitMinSmallestWidth = 2130969099;
				splitMinWidth = 2130969100;
				splitRatio = 2130969101;
				splitTrack = 2130969102;
				srcCompat = 2130969103;
				stackFromEnd = 2130969104;
				state_above_anchor = 2130969105;
				state_collapsed = 2130969106;
				state_collapsible = 2130969107;
				state_liftable = 2130969108;
				state_lifted = 2130969109;
				statusBarBackground = 2130969110;
				statusBarScrim = 2130969111;
				strokeColor = 2130969112;
				strokeWidth = 2130969113;
				subMenuArrow = 2130969114;
				submitBackground = 2130969115;
				subtitle = 2130969116;
				subtitleTextAppearance = 2130969117;
				subtitleTextColor = 2130969118;
				subtitleTextStyle = 2130969119;
				suggestionRowLayout = 2130969120;
				surface_type = 2130969121;
				swipeRefreshLayoutProgressSpinnerBackgroundColor = 2130969122;
				switchMinWidth = 2130969123;
				switchPadding = 2130969124;
				switchStyle = 2130969125;
				switchTextAppearance = 2130969126;
				tabBackground = 2130969127;
				tabContentStart = 2130969128;
				tabGravity = 2130969129;
				tabIconTint = 2130969130;
				tabIconTintMode = 2130969131;
				tabIndicator = 2130969132;
				tabIndicatorAnimationDuration = 2130969133;
				tabIndicatorColor = 2130969134;
				tabIndicatorFullWidth = 2130969135;
				tabIndicatorGravity = 2130969136;
				tabIndicatorHeight = 2130969137;
				tabInlineLabel = 2130969138;
				tabMaxWidth = 2130969139;
				tabMinWidth = 2130969140;
				tabMode = 2130969141;
				tabPadding = 2130969142;
				tabPaddingBottom = 2130969143;
				tabPaddingEnd = 2130969144;
				tabPaddingStart = 2130969145;
				tabPaddingTop = 2130969146;
				tabRippleColor = 2130969147;
				tabSelectedTextColor = 2130969148;
				tabStyle = 2130969149;
				tabTextAppearance = 2130969150;
				tabTextColor = 2130969151;
				tabUnboundedRipple = 2130969152;
				textAllCaps = 2130969153;
				textAppearanceBody1 = 2130969154;
				textAppearanceBody2 = 2130969155;
				textAppearanceButton = 2130969156;
				textAppearanceCaption = 2130969157;
				textAppearanceHeadline1 = 2130969158;
				textAppearanceHeadline2 = 2130969159;
				textAppearanceHeadline3 = 2130969160;
				textAppearanceHeadline4 = 2130969161;
				textAppearanceHeadline5 = 2130969162;
				textAppearanceHeadline6 = 2130969163;
				textAppearanceLargePopupMenu = 2130969164;
				textAppearanceListItem = 2130969165;
				textAppearanceListItemSecondary = 2130969166;
				textAppearanceListItemSmall = 2130969167;
				textAppearanceOverline = 2130969168;
				textAppearancePopupMenuHeader = 2130969169;
				textAppearanceSearchResultSubtitle = 2130969170;
				textAppearanceSearchResultTitle = 2130969171;
				textAppearanceSmallPopupMenu = 2130969172;
				textAppearanceSubtitle1 = 2130969173;
				textAppearanceSubtitle2 = 2130969174;
				textColorAlertDialogListItem = 2130969175;
				textColorSearchUrl = 2130969176;
				textEndPadding = 2130969177;
				textInputStyle = 2130969178;
				textLocale = 2130969179;
				textStartPadding = 2130969180;
				theme = 2130969181;
				thickness = 2130969182;
				thumbTextPadding = 2130969183;
				thumbTint = 2130969184;
				thumbTintMode = 2130969185;
				tickMark = 2130969186;
				tickMarkTint = 2130969187;
				tickMarkTintMode = 2130969188;
				time_bar_min_update_interval = 2130969189;
				tint = 2130969190;
				tintMode = 2130969191;
				title = 2130969192;
				titleEnabled = 2130969193;
				titleMargin = 2130969194;
				titleMarginBottom = 2130969195;
				titleMarginEnd = 2130969196;
				titleMargins = 2130969199;
				titleMarginStart = 2130969197;
				titleMarginTop = 2130969198;
				titleTextAppearance = 2130969200;
				titleTextColor = 2130969201;
				titleTextStyle = 2130969202;
				toolbarId = 2130969203;
				toolbarNavigationButtonStyle = 2130969204;
				toolbarStyle = 2130969205;
				tooltipForegroundColor = 2130969206;
				tooltipFrameBackground = 2130969207;
				tooltipText = 2130969208;
				touch_target_height = 2130969209;
				track = 2130969210;
				trackTint = 2130969211;
				trackTintMode = 2130969212;
				ttcIndex = 2130969213;
				typeface = 2130969214;
				uiCompass = 2130969215;
				uiMapToolbar = 2130969216;
				uiRotateGestures = 2130969217;
				uiScrollGestures = 2130969218;
				uiScrollGesturesDuringRotateOrZoom = 2130969219;
				uiTiltGestures = 2130969220;
				uiZoomControls = 2130969221;
				uiZoomGestures = 2130969222;
				Unknown = 2130968593;
				unplayed_color = 2130969223;
				useCompatPadding = 2130969224;
				useViewLifecycle = 2130969225;
				use_artwork = 2130969226;
				use_controller = 2130969227;
				use_sensor_rotation = 2130969228;
				viewInflaterClass = 2130969229;
				voiceIcon = 2130969230;
				windowActionBar = 2130969231;
				windowActionBarOverlay = 2130969232;
				windowActionModeOverlay = 2130969233;
				windowFixedHeightMajor = 2130969234;
				windowFixedHeightMinor = 2130969235;
				windowFixedWidthMajor = 2130969236;
				windowFixedWidthMinor = 2130969237;
				windowMinWidthMajor = 2130969238;
				windowMinWidthMinor = 2130969239;
				windowNoTitle = 2130969240;
				zOrderOnTop = 2130969241;
				ResourceIdManager.UpdateIdValues();
			}

			private Attribute()
			{
			}
		}

		public class Boolean
		{
			public static int abc_action_bar_embed_tabs;

			public static int abc_config_actionMenuItemAllCaps;

			public static int dashboard_time_stat_visible;

			public static int mtrl_btn_textappearance_all_caps;

			static Boolean()
			{
				abc_action_bar_embed_tabs = 2131034112;
				abc_config_actionMenuItemAllCaps = 2131034113;
				dashboard_time_stat_visible = 2131034114;
				mtrl_btn_textappearance_all_caps = 2131034115;
				ResourceIdManager.UpdateIdValues();
			}

			private Boolean()
			{
			}
		}

		public class Color
		{
			public static int abc_background_cache_hint_selector_material_dark;

			public static int abc_background_cache_hint_selector_material_light;

			public static int abc_btn_colored_borderless_text_material;

			public static int abc_btn_colored_text_material;

			public static int abc_color_highlight_material;

			public static int abc_decor_view_status_guard;

			public static int abc_decor_view_status_guard_light;

			public static int abc_hint_foreground_material_dark;

			public static int abc_hint_foreground_material_light;

			public static int abc_primary_text_disable_only_material_dark;

			public static int abc_primary_text_disable_only_material_light;

			public static int abc_primary_text_material_dark;

			public static int abc_primary_text_material_light;

			public static int abc_search_url_text;

			public static int abc_search_url_text_normal;

			public static int abc_search_url_text_pressed;

			public static int abc_search_url_text_selected;

			public static int abc_secondary_text_material_dark;

			public static int abc_secondary_text_material_light;

			public static int abc_tint_btn_checkable;

			public static int abc_tint_default;

			public static int abc_tint_edittext;

			public static int abc_tint_seek_thumb;

			public static int abc_tint_spinner;

			public static int abc_tint_switch_track;

			public static int accent_material_dark;

			public static int accent_material_light;

			public static int androidx_core_ripple_material_light;

			public static int androidx_core_secondary_text_default_material_light;

			public static int background_floating_material_dark;

			public static int background_floating_material_light;

			public static int background_material_dark;

			public static int background_material_light;

			public static int black;

			public static int bright_foreground_disabled_material_dark;

			public static int bright_foreground_disabled_material_light;

			public static int bright_foreground_inverse_material_dark;

			public static int bright_foreground_inverse_material_light;

			public static int bright_foreground_material_dark;

			public static int bright_foreground_material_light;

			public static int browser_actions_bg_grey;

			public static int browser_actions_divider_color;

			public static int browser_actions_text_color;

			public static int browser_actions_title_color;

			public static int button_material_dark;

			public static int button_material_light;

			public static int cardview_dark_background;

			public static int cardview_light_background;

			public static int cardview_shadow_end_color;

			public static int cardview_shadow_start_color;

			public static int common_google_signin_btn_text_dark;

			public static int common_google_signin_btn_text_dark_default;

			public static int common_google_signin_btn_text_dark_disabled;

			public static int common_google_signin_btn_text_dark_focused;

			public static int common_google_signin_btn_text_dark_pressed;

			public static int common_google_signin_btn_text_light;

			public static int common_google_signin_btn_text_light_default;

			public static int common_google_signin_btn_text_light_disabled;

			public static int common_google_signin_btn_text_light_focused;

			public static int common_google_signin_btn_text_light_pressed;

			public static int common_google_signin_btn_tint;

			public static int com_facebook_blue;

			public static int com_facebook_button_background_color;

			public static int com_facebook_button_background_color_disabled;

			public static int com_facebook_button_background_color_pressed;

			public static int com_facebook_button_send_background_color;

			public static int com_facebook_button_send_background_color_pressed;

			public static int com_facebook_button_text_color;

			public static int com_facebook_device_auth_text;

			public static int com_facebook_likeboxcountview_border_color;

			public static int com_facebook_likeboxcountview_text_color;

			public static int com_facebook_likeview_text_color;

			public static int com_facebook_messenger_blue;

			public static int com_facebook_primary_button_disabled_text_color;

			public static int com_facebook_primary_button_pressed_text_color;

			public static int com_facebook_primary_button_text_color;

			public static int com_facebook_send_button_text_color;

			public static int com_smart_login_code;

			public static int darker_gray;

			public static int dashboard_manual_text;

			public static int dashboard_tile_background;

			public static int dashboard_tile_metric_background;

			public static int dashboard_tile_metric_icon_tint;

			public static int dashboard_tile_nonpremium_overlay;

			public static int dashboard_tile_scrim_first_overlay;

			public static int dashboard_tile_scrim_second_overlay_bottom;

			public static int dashboard_tile_scrim_second_overlay_top;

			public static int dashboard_tile_text;

			public static int dashboard_tile_text_shadow;

			public static int default_background_ring_color;

			public static int default_foreground_ring_color;

			public static int design_bottom_navigation_shadow_color;

			public static int design_default_color_primary;

			public static int design_default_color_primary_dark;

			public static int design_error;

			public static int design_fab_shadow_end_color;

			public static int design_fab_shadow_mid_color;

			public static int design_fab_shadow_start_color;

			public static int design_fab_stroke_end_inner_color;

			public static int design_fab_stroke_end_outer_color;

			public static int design_fab_stroke_top_inner_color;

			public static int design_fab_stroke_top_outer_color;

			public static int design_snackbar_background_color;

			public static int design_tint_password_toggle;

			public static int dim_foreground_disabled_material_dark;

			public static int dim_foreground_disabled_material_light;

			public static int dim_foreground_material_dark;

			public static int dim_foreground_material_light;

			public static int error_color_material_dark;

			public static int error_color_material_light;

			public static int exo_black_opacity_60;

			public static int exo_black_opacity_70;

			public static int exo_bottom_bar_background;

			public static int exo_edit_mode_background_color;

			public static int exo_error_message_background_color;

			public static int exo_styled_error_message_background;

			public static int exo_white;

			public static int exo_white_opacity_70;

			public static int favorites_tile_description;

			public static int foreground_material_dark;

			public static int foreground_material_light;

			public static int full_screen_webview_network_error_text_color;

			public static int highlighted_text_material_dark;

			public static int highlighted_text_material_light;

			public static int loading_lower_left;

			public static int loading_lower_right;

			public static int loading_upper_left;

			public static int loading_upper_right;

			public static int log_screen_share_button;

			public static int log_screen_share_button_selector;

			public static int log_screen_share_tint;

			public static int map_tile_button;

			public static int material_blue_grey_800;

			public static int material_blue_grey_900;

			public static int material_blue_grey_950;

			public static int material_deep_teal_200;

			public static int material_deep_teal_500;

			public static int material_grey_100;

			public static int material_grey_300;

			public static int material_grey_50;

			public static int material_grey_600;

			public static int material_grey_800;

			public static int material_grey_850;

			public static int material_grey_900;

			public static int mtrl_bottom_nav_colored_item_tint;

			public static int mtrl_bottom_nav_item_tint;

			public static int mtrl_btn_bg_color_disabled;

			public static int mtrl_btn_bg_color_selector;

			public static int mtrl_btn_ripple_color;

			public static int mtrl_btn_stroke_color_selector;

			public static int mtrl_btn_text_btn_ripple_color;

			public static int mtrl_btn_text_color_disabled;

			public static int mtrl_btn_text_color_selector;

			public static int mtrl_btn_transparent_bg_color;

			public static int mtrl_chip_background_color;

			public static int mtrl_chip_close_icon_tint;

			public static int mtrl_chip_ripple_color;

			public static int mtrl_chip_text_color;

			public static int mtrl_fab_ripple_color;

			public static int mtrl_scrim_color;

			public static int mtrl_tabs_colored_ripple_color;

			public static int mtrl_tabs_icon_color_selector;

			public static int mtrl_tabs_icon_color_selector_colored;

			public static int mtrl_tabs_legacy_text_color_selector;

			public static int mtrl_tabs_ripple_color;

			public static int mtrl_textinput_default_box_stroke_color;

			public static int mtrl_textinput_disabled_color;

			public static int mtrl_textinput_filled_box_default_background_color;

			public static int mtrl_textinput_hovered_box_stroke_color;

			public static int mtrl_text_btn_text_color_selector;

			public static int notification_action_color_filter;

			public static int notification_icon_bg_color;

			public static int notification_material_background_media_default_color;

			public static int primary_dark_material_dark;

			public static int primary_dark_material_light;

			public static int primary_material_dark;

			public static int primary_material_light;

			public static int primary_text_default_material_dark;

			public static int primary_text_default_material_light;

			public static int primary_text_disabled_material_dark;

			public static int primary_text_disabled_material_light;

			public static int rating_container_text_color;

			public static int ripple_material_dark;

			public static int ripple_material_light;

			public static int secondary_text_default_material_dark;

			public static int secondary_text_default_material_light;

			public static int secondary_text_disabled_material_dark;

			public static int secondary_text_disabled_material_light;

			public static int switch_thumb_disabled_material_dark;

			public static int switch_thumb_disabled_material_light;

			public static int switch_thumb_material_dark;

			public static int switch_thumb_material_light;

			public static int switch_thumb_normal_material_dark;

			public static int switch_thumb_normal_material_light;

			public static int tooltip_background_dark;

			public static int tooltip_background_light;

			public static int transparent;

			public static int white;

			public static int wifi_icon_tint;

			static Color()
			{
				abc_background_cache_hint_selector_material_dark = 2131099648;
				abc_background_cache_hint_selector_material_light = 2131099649;
				abc_btn_colored_borderless_text_material = 2131099650;
				abc_btn_colored_text_material = 2131099651;
				abc_color_highlight_material = 2131099652;
				abc_decor_view_status_guard = 2131099653;
				abc_decor_view_status_guard_light = 2131099654;
				abc_hint_foreground_material_dark = 2131099655;
				abc_hint_foreground_material_light = 2131099656;
				abc_primary_text_disable_only_material_dark = 2131099657;
				abc_primary_text_disable_only_material_light = 2131099658;
				abc_primary_text_material_dark = 2131099659;
				abc_primary_text_material_light = 2131099660;
				abc_search_url_text = 2131099661;
				abc_search_url_text_normal = 2131099662;
				abc_search_url_text_pressed = 2131099663;
				abc_search_url_text_selected = 2131099664;
				abc_secondary_text_material_dark = 2131099665;
				abc_secondary_text_material_light = 2131099666;
				abc_tint_btn_checkable = 2131099667;
				abc_tint_default = 2131099668;
				abc_tint_edittext = 2131099669;
				abc_tint_seek_thumb = 2131099670;
				abc_tint_spinner = 2131099671;
				abc_tint_switch_track = 2131099672;
				accent_material_dark = 2131099673;
				accent_material_light = 2131099674;
				androidx_core_ripple_material_light = 2131099675;
				androidx_core_secondary_text_default_material_light = 2131099676;
				background_floating_material_dark = 2131099677;
				background_floating_material_light = 2131099678;
				background_material_dark = 2131099679;
				background_material_light = 2131099680;
				black = 2131099681;
				bright_foreground_disabled_material_dark = 2131099682;
				bright_foreground_disabled_material_light = 2131099683;
				bright_foreground_inverse_material_dark = 2131099684;
				bright_foreground_inverse_material_light = 2131099685;
				bright_foreground_material_dark = 2131099686;
				bright_foreground_material_light = 2131099687;
				browser_actions_bg_grey = 2131099688;
				browser_actions_divider_color = 2131099689;
				browser_actions_text_color = 2131099690;
				browser_actions_title_color = 2131099691;
				button_material_dark = 2131099692;
				button_material_light = 2131099693;
				cardview_dark_background = 2131099694;
				cardview_light_background = 2131099695;
				cardview_shadow_end_color = 2131099696;
				cardview_shadow_start_color = 2131099697;
				common_google_signin_btn_text_dark = 2131099715;
				common_google_signin_btn_text_dark_default = 2131099716;
				common_google_signin_btn_text_dark_disabled = 2131099717;
				common_google_signin_btn_text_dark_focused = 2131099718;
				common_google_signin_btn_text_dark_pressed = 2131099719;
				common_google_signin_btn_text_light = 2131099720;
				common_google_signin_btn_text_light_default = 2131099721;
				common_google_signin_btn_text_light_disabled = 2131099722;
				common_google_signin_btn_text_light_focused = 2131099723;
				common_google_signin_btn_text_light_pressed = 2131099724;
				common_google_signin_btn_tint = 2131099725;
				com_facebook_blue = 2131099698;
				com_facebook_button_background_color = 2131099699;
				com_facebook_button_background_color_disabled = 2131099700;
				com_facebook_button_background_color_pressed = 2131099701;
				com_facebook_button_send_background_color = 2131099702;
				com_facebook_button_send_background_color_pressed = 2131099703;
				com_facebook_button_text_color = 2131099704;
				com_facebook_device_auth_text = 2131099705;
				com_facebook_likeboxcountview_border_color = 2131099706;
				com_facebook_likeboxcountview_text_color = 2131099707;
				com_facebook_likeview_text_color = 2131099708;
				com_facebook_messenger_blue = 2131099709;
				com_facebook_primary_button_disabled_text_color = 2131099710;
				com_facebook_primary_button_pressed_text_color = 2131099711;
				com_facebook_primary_button_text_color = 2131099712;
				com_facebook_send_button_text_color = 2131099713;
				com_smart_login_code = 2131099714;
				darker_gray = 2131099726;
				dashboard_manual_text = 2131099727;
				dashboard_tile_background = 2131099728;
				dashboard_tile_metric_background = 2131099729;
				dashboard_tile_metric_icon_tint = 2131099730;
				dashboard_tile_nonpremium_overlay = 2131099731;
				dashboard_tile_scrim_first_overlay = 2131099732;
				dashboard_tile_scrim_second_overlay_bottom = 2131099733;
				dashboard_tile_scrim_second_overlay_top = 2131099734;
				dashboard_tile_text = 2131099735;
				dashboard_tile_text_shadow = 2131099736;
				default_background_ring_color = 2131099737;
				default_foreground_ring_color = 2131099738;
				design_bottom_navigation_shadow_color = 2131099739;
				design_default_color_primary = 2131099740;
				design_default_color_primary_dark = 2131099741;
				design_error = 2131099742;
				design_fab_shadow_end_color = 2131099743;
				design_fab_shadow_mid_color = 2131099744;
				design_fab_shadow_start_color = 2131099745;
				design_fab_stroke_end_inner_color = 2131099746;
				design_fab_stroke_end_outer_color = 2131099747;
				design_fab_stroke_top_inner_color = 2131099748;
				design_fab_stroke_top_outer_color = 2131099749;
				design_snackbar_background_color = 2131099750;
				design_tint_password_toggle = 2131099751;
				dim_foreground_disabled_material_dark = 2131099752;
				dim_foreground_disabled_material_light = 2131099753;
				dim_foreground_material_dark = 2131099754;
				dim_foreground_material_light = 2131099755;
				error_color_material_dark = 2131099756;
				error_color_material_light = 2131099757;
				exo_black_opacity_60 = 2131099758;
				exo_black_opacity_70 = 2131099759;
				exo_bottom_bar_background = 2131099760;
				exo_edit_mode_background_color = 2131099761;
				exo_error_message_background_color = 2131099762;
				exo_styled_error_message_background = 2131099763;
				exo_white = 2131099764;
				exo_white_opacity_70 = 2131099765;
				favorites_tile_description = 2131099766;
				foreground_material_dark = 2131099767;
				foreground_material_light = 2131099768;
				full_screen_webview_network_error_text_color = 2131099769;
				highlighted_text_material_dark = 2131099770;
				highlighted_text_material_light = 2131099771;
				loading_lower_left = 2131099772;
				loading_lower_right = 2131099773;
				loading_upper_left = 2131099774;
				loading_upper_right = 2131099775;
				log_screen_share_button = 2131099776;
				log_screen_share_button_selector = 2131099777;
				log_screen_share_tint = 2131099778;
				map_tile_button = 2131099779;
				material_blue_grey_800 = 2131099780;
				material_blue_grey_900 = 2131099781;
				material_blue_grey_950 = 2131099782;
				material_deep_teal_200 = 2131099783;
				material_deep_teal_500 = 2131099784;
				material_grey_100 = 2131099785;
				material_grey_300 = 2131099786;
				material_grey_50 = 2131099787;
				material_grey_600 = 2131099788;
				material_grey_800 = 2131099789;
				material_grey_850 = 2131099790;
				material_grey_900 = 2131099791;
				mtrl_bottom_nav_colored_item_tint = 2131099792;
				mtrl_bottom_nav_item_tint = 2131099793;
				mtrl_btn_bg_color_disabled = 2131099794;
				mtrl_btn_bg_color_selector = 2131099795;
				mtrl_btn_ripple_color = 2131099796;
				mtrl_btn_stroke_color_selector = 2131099797;
				mtrl_btn_text_btn_ripple_color = 2131099798;
				mtrl_btn_text_color_disabled = 2131099799;
				mtrl_btn_text_color_selector = 2131099800;
				mtrl_btn_transparent_bg_color = 2131099801;
				mtrl_chip_background_color = 2131099802;
				mtrl_chip_close_icon_tint = 2131099803;
				mtrl_chip_ripple_color = 2131099804;
				mtrl_chip_text_color = 2131099805;
				mtrl_fab_ripple_color = 2131099806;
				mtrl_scrim_color = 2131099807;
				mtrl_tabs_colored_ripple_color = 2131099808;
				mtrl_tabs_icon_color_selector = 2131099809;
				mtrl_tabs_icon_color_selector_colored = 2131099810;
				mtrl_tabs_legacy_text_color_selector = 2131099811;
				mtrl_tabs_ripple_color = 2131099812;
				mtrl_textinput_default_box_stroke_color = 2131099814;
				mtrl_textinput_disabled_color = 2131099815;
				mtrl_textinput_filled_box_default_background_color = 2131099816;
				mtrl_textinput_hovered_box_stroke_color = 2131099817;
				mtrl_text_btn_text_color_selector = 2131099813;
				notification_action_color_filter = 2131099818;
				notification_icon_bg_color = 2131099819;
				notification_material_background_media_default_color = 2131099820;
				primary_dark_material_dark = 2131099821;
				primary_dark_material_light = 2131099822;
				primary_material_dark = 2131099823;
				primary_material_light = 2131099824;
				primary_text_default_material_dark = 2131099825;
				primary_text_default_material_light = 2131099826;
				primary_text_disabled_material_dark = 2131099827;
				primary_text_disabled_material_light = 2131099828;
				rating_container_text_color = 2131099829;
				ripple_material_dark = 2131099830;
				ripple_material_light = 2131099831;
				secondary_text_default_material_dark = 2131099832;
				secondary_text_default_material_light = 2131099833;
				secondary_text_disabled_material_dark = 2131099834;
				secondary_text_disabled_material_light = 2131099835;
				switch_thumb_disabled_material_dark = 2131099836;
				switch_thumb_disabled_material_light = 2131099837;
				switch_thumb_material_dark = 2131099838;
				switch_thumb_material_light = 2131099839;
				switch_thumb_normal_material_dark = 2131099840;
				switch_thumb_normal_material_light = 2131099841;
				tooltip_background_dark = 2131099842;
				tooltip_background_light = 2131099843;
				transparent = 2131099844;
				white = 2131099845;
				wifi_icon_tint = 2131099846;
				ResourceIdManager.UpdateIdValues();
			}

			private Color()
			{
			}
		}

		public class Dimension
		{
			public static int abc_action_bar_content_inset_material;

			public static int abc_action_bar_content_inset_with_nav;

			public static int abc_action_bar_default_height_material;

			public static int abc_action_bar_default_padding_end_material;

			public static int abc_action_bar_default_padding_start_material;

			public static int abc_action_bar_elevation_material;

			public static int abc_action_bar_icon_vertical_padding_material;

			public static int abc_action_bar_overflow_padding_end_material;

			public static int abc_action_bar_overflow_padding_start_material;

			public static int abc_action_bar_stacked_max_height;

			public static int abc_action_bar_stacked_tab_max_width;

			public static int abc_action_bar_subtitle_bottom_margin_material;

			public static int abc_action_bar_subtitle_top_margin_material;

			public static int abc_action_button_min_height_material;

			public static int abc_action_button_min_width_material;

			public static int abc_action_button_min_width_overflow_material;

			public static int abc_alert_dialog_button_bar_height;

			public static int abc_alert_dialog_button_dimen;

			public static int abc_button_inset_horizontal_material;

			public static int abc_button_inset_vertical_material;

			public static int abc_button_padding_horizontal_material;

			public static int abc_button_padding_vertical_material;

			public static int abc_cascading_menus_min_smallest_width;

			public static int abc_config_prefDialogWidth;

			public static int abc_control_corner_material;

			public static int abc_control_inset_material;

			public static int abc_control_padding_material;

			public static int abc_dialog_corner_radius_material;

			public static int abc_dialog_fixed_height_major;

			public static int abc_dialog_fixed_height_minor;

			public static int abc_dialog_fixed_width_major;

			public static int abc_dialog_fixed_width_minor;

			public static int abc_dialog_list_padding_bottom_no_buttons;

			public static int abc_dialog_list_padding_top_no_title;

			public static int abc_dialog_min_width_major;

			public static int abc_dialog_min_width_minor;

			public static int abc_dialog_padding_material;

			public static int abc_dialog_padding_top_material;

			public static int abc_dialog_title_divider_material;

			public static int abc_disabled_alpha_material_dark;

			public static int abc_disabled_alpha_material_light;

			public static int abc_dropdownitem_icon_width;

			public static int abc_dropdownitem_text_padding_left;

			public static int abc_dropdownitem_text_padding_right;

			public static int abc_edit_text_inset_bottom_material;

			public static int abc_edit_text_inset_horizontal_material;

			public static int abc_edit_text_inset_top_material;

			public static int abc_floating_window_z;

			public static int abc_list_item_height_large_material;

			public static int abc_list_item_height_material;

			public static int abc_list_item_height_small_material;

			public static int abc_list_item_padding_horizontal_material;

			public static int abc_panel_menu_list_width;

			public static int abc_progress_bar_height_material;

			public static int abc_search_view_preferred_height;

			public static int abc_search_view_preferred_width;

			public static int abc_seekbar_track_background_height_material;

			public static int abc_seekbar_track_progress_height_material;

			public static int abc_select_dialog_padding_start_material;

			public static int abc_star_big;

			public static int abc_star_medium;

			public static int abc_star_small;

			public static int abc_switch_padding;

			public static int abc_text_size_body_1_material;

			public static int abc_text_size_body_2_material;

			public static int abc_text_size_button_material;

			public static int abc_text_size_caption_material;

			public static int abc_text_size_display_1_material;

			public static int abc_text_size_display_2_material;

			public static int abc_text_size_display_3_material;

			public static int abc_text_size_display_4_material;

			public static int abc_text_size_headline_material;

			public static int abc_text_size_large_material;

			public static int abc_text_size_medium_material;

			public static int abc_text_size_menu_header_material;

			public static int abc_text_size_menu_material;

			public static int abc_text_size_small_material;

			public static int abc_text_size_subhead_material;

			public static int abc_text_size_subtitle_material_toolbar;

			public static int abc_text_size_title_material;

			public static int abc_text_size_title_material_toolbar;

			public static int browser_actions_context_menu_max_width;

			public static int browser_actions_context_menu_min_padding;

			public static int buffering_loading_size;

			public static int cardview_compat_inset_shadow;

			public static int cardview_default_elevation;

			public static int cardview_default_radius;

			public static int compat_button_inset_horizontal_material;

			public static int compat_button_inset_vertical_material;

			public static int compat_button_padding_horizontal_material;

			public static int compat_button_padding_vertical_material;

			public static int compat_control_corner_material;

			public static int compat_notification_large_icon_max_height;

			public static int compat_notification_large_icon_max_width;

			public static int com_facebook_auth_dialog_corner_radius;

			public static int com_facebook_auth_dialog_corner_radius_oversized;

			public static int com_facebook_button_corner_radius;

			public static int com_facebook_button_login_corner_radius;

			public static int com_facebook_likeboxcountview_border_radius;

			public static int com_facebook_likeboxcountview_border_width;

			public static int com_facebook_likeboxcountview_caret_height;

			public static int com_facebook_likeboxcountview_caret_width;

			public static int com_facebook_likeboxcountview_text_padding;

			public static int com_facebook_likeboxcountview_text_size;

			public static int com_facebook_likeview_edge_padding;

			public static int com_facebook_likeview_internal_padding;

			public static int com_facebook_likeview_text_size;

			public static int com_facebook_profilepictureview_preset_size_large;

			public static int com_facebook_profilepictureview_preset_size_normal;

			public static int com_facebook_profilepictureview_preset_size_small;

			public static int dashboard_tile_card_corner_radius;

			public static int dashboard_tile_card_elevation;

			public static int dashboard_tile_content_bottom_margin;

			public static int dashboard_tile_content_left_margin;

			public static int dashboard_tile_content_padding;

			public static int dashboard_tile_content_top_margin;

			public static int dashboard_tile_metric_background_radius;

			public static int dashboard_tile_metric_icon;

			public static int dashboard_tile_metric_icon_small;

			public static int dashboard_tile_metric_label_margin;

			public static int dashboard_tile_metric_spacing;

			public static int dashboard_tile_metric_unit_start_margin;

			public static int dashboard_tile_metric_unit_text;

			public static int dashboard_tile_metric_unit_text_small;

			public static int dashboard_tile_metric_unit_text_spacing;

			public static int dashboard_tile_metric_value_start_margin;

			public static int dashboard_tile_metric_value_text;

			public static int dashboard_tile_metric_value_text_small;

			public static int dashboard_tile_metric_value_text_spacing;

			public static int dashboard_tile_start_button_diameter;

			public static int dashboard_tile_start_letter_spacing;

			public static int dashboard_tile_start_text;

			public static int dashboard_tile_title_text;

			public static int dashboard_tile_title_text_small;

			public static int dashboard_tile_title_top_margin;

			public static int dashboard_tile_type_text;

			public static int dashboard_tile_workout_type_size;

			public static int dashboard_tile_wotd_type_size;

			public static int dashboard_title_letter_spacing;

			public static int def_drawer_elevation;

			public static int design_appbar_elevation;

			public static int design_bottom_navigation_active_item_max_width;

			public static int design_bottom_navigation_active_item_min_width;

			public static int design_bottom_navigation_active_text_size;

			public static int design_bottom_navigation_elevation;

			public static int design_bottom_navigation_height;

			public static int design_bottom_navigation_icon_size;

			public static int design_bottom_navigation_item_max_width;

			public static int design_bottom_navigation_item_min_width;

			public static int design_bottom_navigation_margin;

			public static int design_bottom_navigation_shadow_height;

			public static int design_bottom_navigation_text_size;

			public static int design_bottom_sheet_modal_elevation;

			public static int design_bottom_sheet_peek_height_min;

			public static int design_fab_border_width;

			public static int design_fab_elevation;

			public static int design_fab_image_size;

			public static int design_fab_size_mini;

			public static int design_fab_size_normal;

			public static int design_fab_translation_z_hovered_focused;

			public static int design_fab_translation_z_pressed;

			public static int design_navigation_elevation;

			public static int design_navigation_icon_padding;

			public static int design_navigation_icon_size;

			public static int design_navigation_item_horizontal_padding;

			public static int design_navigation_item_icon_padding;

			public static int design_navigation_max_width;

			public static int design_navigation_padding_bottom;

			public static int design_navigation_separator_vertical_padding;

			public static int design_snackbar_action_inline_max_width;

			public static int design_snackbar_background_corner_radius;

			public static int design_snackbar_elevation;

			public static int design_snackbar_extra_spacing_horizontal;

			public static int design_snackbar_max_width;

			public static int design_snackbar_min_width;

			public static int design_snackbar_padding_horizontal;

			public static int design_snackbar_padding_vertical;

			public static int design_snackbar_padding_vertical_2lines;

			public static int design_snackbar_text_size;

			public static int design_tab_max_width;

			public static int design_tab_scrollable_min_width;

			public static int design_tab_text_size;

			public static int design_tab_text_size_2line;

			public static int design_textinput_caption_translate_y;

			public static int disabled_alpha_material_dark;

			public static int disabled_alpha_material_light;

			public static int draw_map_button_radius;

			public static int exo_error_message_height;

			public static int exo_error_message_margin_bottom;

			public static int exo_error_message_text_padding_horizontal;

			public static int exo_error_message_text_padding_vertical;

			public static int exo_error_message_text_size;

			public static int exo_icon_horizontal_margin;

			public static int exo_icon_padding;

			public static int exo_icon_padding_bottom;

			public static int exo_icon_size;

			public static int exo_icon_text_size;

			public static int exo_media_button_height;

			public static int exo_media_button_width;

			public static int exo_settings_height;

			public static int exo_settings_icon_size;

			public static int exo_settings_main_text_size;

			public static int exo_settings_offset;

			public static int exo_settings_sub_text_size;

			public static int exo_settings_text_height;

			public static int exo_setting_width;

			public static int exo_small_icon_height;

			public static int exo_small_icon_horizontal_margin;

			public static int exo_small_icon_padding_horizontal;

			public static int exo_small_icon_padding_vertical;

			public static int exo_small_icon_width;

			public static int exo_styled_bottom_bar_height;

			public static int exo_styled_bottom_bar_margin_top;

			public static int exo_styled_bottom_bar_time_padding;

			public static int exo_styled_controls_padding;

			public static int exo_styled_minimal_controls_margin_bottom;

			public static int exo_styled_progress_bar_height;

			public static int exo_styled_progress_dragged_thumb_size;

			public static int exo_styled_progress_enabled_thumb_size;

			public static int exo_styled_progress_layout_height;

			public static int exo_styled_progress_margin_bottom;

			public static int exo_styled_progress_touch_target_height;

			public static int fastscroll_default_thickness;

			public static int fastscroll_margin;

			public static int fastscroll_minimum_range;

			public static int favorites_tile_description_text;

			public static int favorites_tile_description_text_width;

			public static int favorites_tile_description_top_margin;

			public static int favorites_tile_title_text;

			public static int full_screen_webview_error_text_size;

			public static int full_screen_webview_native_loader_phone;

			public static int full_screen_webview_native_loader_tablet;

			public static int full_screen_webview_network_error_image_width;

			public static int highlight_alpha_material_colored;

			public static int highlight_alpha_material_dark;

			public static int highlight_alpha_material_light;

			public static int hint_alpha_material_dark;

			public static int hint_alpha_material_light;

			public static int hint_pressed_alpha_material_dark;

			public static int hint_pressed_alpha_material_light;

			public static int item_touch_helper_max_drag_scroll_per_frame;

			public static int item_touch_helper_swipe_escape_max_velocity;

			public static int item_touch_helper_swipe_escape_velocity;

			public static int library_tile_description_margin_top;

			public static int library_tile_description_text;

			public static int library_tile_description_width;

			public static int library_tile_padding_bottom;

			public static int library_tile_padding_left;

			public static int library_tile_padding_right;

			public static int library_tile_padding_top;

			public static int library_tile_title_line_spacing;

			public static int library_tile_title_text;

			public static int library_tile_title_width;

			public static int loading_accessories_size;

			public static int loading_base_size;

			public static int loading_circle_max;

			public static int loading_circle_min;

			public static int manual_tile_manual_label_textSize;

			public static int manual_tile_padding_top;

			public static int manual_tile_start_label_margin_top;

			public static int manual_tile_start_label_textSize;

			public static int map_tile_description_line_spacing;

			public static int map_tile_description_margin_top;

			public static int map_tile_description_text;

			public static int map_tile_description_width;

			public static int map_tile_padding_bottom;

			public static int map_tile_padding_left;

			public static int map_tile_padding_right;

			public static int map_tile_padding_top;

			public static int map_tile_start_button_letter_spacing;

			public static int map_tile_start_button_padding_horizontal;

			public static int map_tile_start_button_padding_vertical;

			public static int map_tile_start_button_text;

			public static int map_tile_title_line_spacing;

			public static int map_tile_title_text;

			public static int map_tile_title_width;

			public static int mtrl_bottomappbar_fabOffsetEndMode;

			public static int mtrl_bottomappbar_fab_cradle_margin;

			public static int mtrl_bottomappbar_fab_cradle_rounded_corner_radius;

			public static int mtrl_bottomappbar_fab_cradle_vertical_offset;

			public static int mtrl_bottomappbar_height;

			public static int mtrl_btn_corner_radius;

			public static int mtrl_btn_dialog_btn_min_width;

			public static int mtrl_btn_disabled_elevation;

			public static int mtrl_btn_disabled_z;

			public static int mtrl_btn_elevation;

			public static int mtrl_btn_focused_z;

			public static int mtrl_btn_hovered_z;

			public static int mtrl_btn_icon_btn_padding_left;

			public static int mtrl_btn_icon_padding;

			public static int mtrl_btn_inset;

			public static int mtrl_btn_letter_spacing;

			public static int mtrl_btn_padding_bottom;

			public static int mtrl_btn_padding_left;

			public static int mtrl_btn_padding_right;

			public static int mtrl_btn_padding_top;

			public static int mtrl_btn_pressed_z;

			public static int mtrl_btn_stroke_size;

			public static int mtrl_btn_text_btn_icon_padding;

			public static int mtrl_btn_text_btn_padding_left;

			public static int mtrl_btn_text_btn_padding_right;

			public static int mtrl_btn_text_size;

			public static int mtrl_btn_z;

			public static int mtrl_card_elevation;

			public static int mtrl_card_spacing;

			public static int mtrl_chip_pressed_translation_z;

			public static int mtrl_chip_text_size;

			public static int mtrl_fab_elevation;

			public static int mtrl_fab_translation_z_hovered_focused;

			public static int mtrl_fab_translation_z_pressed;

			public static int mtrl_navigation_elevation;

			public static int mtrl_navigation_item_horizontal_padding;

			public static int mtrl_navigation_item_icon_padding;

			public static int mtrl_snackbar_background_corner_radius;

			public static int mtrl_snackbar_margin;

			public static int mtrl_textinput_box_bottom_offset;

			public static int mtrl_textinput_box_corner_radius_medium;

			public static int mtrl_textinput_box_corner_radius_small;

			public static int mtrl_textinput_box_label_cutout_padding;

			public static int mtrl_textinput_box_padding_end;

			public static int mtrl_textinput_box_stroke_width_default;

			public static int mtrl_textinput_box_stroke_width_focused;

			public static int mtrl_textinput_outline_box_expanded_padding;

			public static int mtrl_toolbar_default_height;

			public static int notification_action_icon_size;

			public static int notification_action_text_size;

			public static int notification_big_circle_margin;

			public static int notification_content_margin_start;

			public static int notification_large_icon_height;

			public static int notification_large_icon_width;

			public static int notification_main_column_padding_top;

			public static int notification_media_narrow_margin;

			public static int notification_right_icon_size;

			public static int notification_right_side_padding_top;

			public static int notification_small_icon_background_padding;

			public static int notification_small_icon_size_as_large;

			public static int notification_subtext_size;

			public static int notification_top_pad;

			public static int notification_top_pad_large_text;

			public static int rating_container_text_size;

			public static int summary_activity_share_button_padding;

			public static int summary_activity_share_center_button_marginRight;

			public static int summary_activity_share_container_height;

			public static int summary_activity_share_container_marginTop;

			public static int summary_activity_share_container_width;

			public static int summary_activity_share_facebook_button_marginLeft;

			public static int summary_activity_share_facebook_button_marginTop;

			public static int summary_activity_share_google_button_marginLeft;

			public static int summary_activity_share_google_button_marginTop;

			public static int summary_activity_share_margin_right;

			public static int summary_activity_share_twitter_button_marginLeft;

			public static int summary_activity_share_twitter_button_marginTop;

			public static int tooltip_corner_radius;

			public static int tooltip_horizontal_padding;

			public static int tooltip_margin;

			public static int tooltip_precise_anchor_extra_offset;

			public static int tooltip_precise_anchor_threshold;

			public static int tooltip_vertical_padding;

			public static int tooltip_y_offset_non_touch;

			public static int tooltip_y_offset_touch;

			public static int twitter_cancel_margin;

			public static int twitter_cancel_padding;

			public static int twitter_cancel_textSize;

			public static int twitter_dialog_width;

			public static int twitter_title_margin;

			public static int twitter_title_padding;

			public static int twitter_title_textSize;

			public static int twitter_webview_height;

			public static int webview_dialog_cancel_margin;

			public static int webview_dialog_cancel_padding;

			public static int webview_dialog_cancel_textSize;

			public static int webview_dialog_title_margin;

			public static int webview_dialog_title_padding;

			public static int webview_dialog_title_textSize;

			public static int webview_dialog_webview_height;

			public static int webview_dialog_width;

			static Dimension()
			{
				abc_action_bar_content_inset_material = 2131165184;
				abc_action_bar_content_inset_with_nav = 2131165185;
				abc_action_bar_default_height_material = 2131165186;
				abc_action_bar_default_padding_end_material = 2131165187;
				abc_action_bar_default_padding_start_material = 2131165188;
				abc_action_bar_elevation_material = 2131165189;
				abc_action_bar_icon_vertical_padding_material = 2131165190;
				abc_action_bar_overflow_padding_end_material = 2131165191;
				abc_action_bar_overflow_padding_start_material = 2131165192;
				abc_action_bar_stacked_max_height = 2131165193;
				abc_action_bar_stacked_tab_max_width = 2131165194;
				abc_action_bar_subtitle_bottom_margin_material = 2131165195;
				abc_action_bar_subtitle_top_margin_material = 2131165196;
				abc_action_button_min_height_material = 2131165197;
				abc_action_button_min_width_material = 2131165198;
				abc_action_button_min_width_overflow_material = 2131165199;
				abc_alert_dialog_button_bar_height = 2131165200;
				abc_alert_dialog_button_dimen = 2131165201;
				abc_button_inset_horizontal_material = 2131165202;
				abc_button_inset_vertical_material = 2131165203;
				abc_button_padding_horizontal_material = 2131165204;
				abc_button_padding_vertical_material = 2131165205;
				abc_cascading_menus_min_smallest_width = 2131165206;
				abc_config_prefDialogWidth = 2131165207;
				abc_control_corner_material = 2131165208;
				abc_control_inset_material = 2131165209;
				abc_control_padding_material = 2131165210;
				abc_dialog_corner_radius_material = 2131165211;
				abc_dialog_fixed_height_major = 2131165212;
				abc_dialog_fixed_height_minor = 2131165213;
				abc_dialog_fixed_width_major = 2131165214;
				abc_dialog_fixed_width_minor = 2131165215;
				abc_dialog_list_padding_bottom_no_buttons = 2131165216;
				abc_dialog_list_padding_top_no_title = 2131165217;
				abc_dialog_min_width_major = 2131165218;
				abc_dialog_min_width_minor = 2131165219;
				abc_dialog_padding_material = 2131165220;
				abc_dialog_padding_top_material = 2131165221;
				abc_dialog_title_divider_material = 2131165222;
				abc_disabled_alpha_material_dark = 2131165223;
				abc_disabled_alpha_material_light = 2131165224;
				abc_dropdownitem_icon_width = 2131165225;
				abc_dropdownitem_text_padding_left = 2131165226;
				abc_dropdownitem_text_padding_right = 2131165227;
				abc_edit_text_inset_bottom_material = 2131165228;
				abc_edit_text_inset_horizontal_material = 2131165229;
				abc_edit_text_inset_top_material = 2131165230;
				abc_floating_window_z = 2131165231;
				abc_list_item_height_large_material = 2131165232;
				abc_list_item_height_material = 2131165233;
				abc_list_item_height_small_material = 2131165234;
				abc_list_item_padding_horizontal_material = 2131165235;
				abc_panel_menu_list_width = 2131165236;
				abc_progress_bar_height_material = 2131165237;
				abc_search_view_preferred_height = 2131165238;
				abc_search_view_preferred_width = 2131165239;
				abc_seekbar_track_background_height_material = 2131165240;
				abc_seekbar_track_progress_height_material = 2131165241;
				abc_select_dialog_padding_start_material = 2131165242;
				abc_star_big = 2131165243;
				abc_star_medium = 2131165244;
				abc_star_small = 2131165245;
				abc_switch_padding = 2131165246;
				abc_text_size_body_1_material = 2131165247;
				abc_text_size_body_2_material = 2131165248;
				abc_text_size_button_material = 2131165249;
				abc_text_size_caption_material = 2131165250;
				abc_text_size_display_1_material = 2131165251;
				abc_text_size_display_2_material = 2131165252;
				abc_text_size_display_3_material = 2131165253;
				abc_text_size_display_4_material = 2131165254;
				abc_text_size_headline_material = 2131165255;
				abc_text_size_large_material = 2131165256;
				abc_text_size_medium_material = 2131165257;
				abc_text_size_menu_header_material = 2131165258;
				abc_text_size_menu_material = 2131165259;
				abc_text_size_small_material = 2131165260;
				abc_text_size_subhead_material = 2131165261;
				abc_text_size_subtitle_material_toolbar = 2131165262;
				abc_text_size_title_material = 2131165263;
				abc_text_size_title_material_toolbar = 2131165264;
				browser_actions_context_menu_max_width = 2131165265;
				browser_actions_context_menu_min_padding = 2131165266;
				buffering_loading_size = 2131165267;
				cardview_compat_inset_shadow = 2131165268;
				cardview_default_elevation = 2131165269;
				cardview_default_radius = 2131165270;
				compat_button_inset_horizontal_material = 2131165287;
				compat_button_inset_vertical_material = 2131165288;
				compat_button_padding_horizontal_material = 2131165289;
				compat_button_padding_vertical_material = 2131165290;
				compat_control_corner_material = 2131165291;
				compat_notification_large_icon_max_height = 2131165292;
				compat_notification_large_icon_max_width = 2131165293;
				com_facebook_auth_dialog_corner_radius = 2131165271;
				com_facebook_auth_dialog_corner_radius_oversized = 2131165272;
				com_facebook_button_corner_radius = 2131165273;
				com_facebook_button_login_corner_radius = 2131165274;
				com_facebook_likeboxcountview_border_radius = 2131165275;
				com_facebook_likeboxcountview_border_width = 2131165276;
				com_facebook_likeboxcountview_caret_height = 2131165277;
				com_facebook_likeboxcountview_caret_width = 2131165278;
				com_facebook_likeboxcountview_text_padding = 2131165279;
				com_facebook_likeboxcountview_text_size = 2131165280;
				com_facebook_likeview_edge_padding = 2131165281;
				com_facebook_likeview_internal_padding = 2131165282;
				com_facebook_likeview_text_size = 2131165283;
				com_facebook_profilepictureview_preset_size_large = 2131165284;
				com_facebook_profilepictureview_preset_size_normal = 2131165285;
				com_facebook_profilepictureview_preset_size_small = 2131165286;
				dashboard_tile_card_corner_radius = 2131165294;
				dashboard_tile_card_elevation = 2131165295;
				dashboard_tile_content_bottom_margin = 2131165296;
				dashboard_tile_content_left_margin = 2131165297;
				dashboard_tile_content_padding = 2131165298;
				dashboard_tile_content_top_margin = 2131165299;
				dashboard_tile_metric_background_radius = 2131165300;
				dashboard_tile_metric_icon = 2131165301;
				dashboard_tile_metric_icon_small = 2131165302;
				dashboard_tile_metric_label_margin = 2131165303;
				dashboard_tile_metric_spacing = 2131165304;
				dashboard_tile_metric_unit_start_margin = 2131165305;
				dashboard_tile_metric_unit_text = 2131165306;
				dashboard_tile_metric_unit_text_small = 2131165307;
				dashboard_tile_metric_unit_text_spacing = 2131165308;
				dashboard_tile_metric_value_start_margin = 2131165309;
				dashboard_tile_metric_value_text = 2131165310;
				dashboard_tile_metric_value_text_small = 2131165311;
				dashboard_tile_metric_value_text_spacing = 2131165312;
				dashboard_tile_start_button_diameter = 2131165313;
				dashboard_tile_start_letter_spacing = 2131165314;
				dashboard_tile_start_text = 2131165315;
				dashboard_tile_title_text = 2131165316;
				dashboard_tile_title_text_small = 2131165317;
				dashboard_tile_title_top_margin = 2131165318;
				dashboard_tile_type_text = 2131165319;
				dashboard_tile_workout_type_size = 2131165320;
				dashboard_tile_wotd_type_size = 2131165321;
				dashboard_title_letter_spacing = 2131165322;
				def_drawer_elevation = 2131165323;
				design_appbar_elevation = 2131165324;
				design_bottom_navigation_active_item_max_width = 2131165325;
				design_bottom_navigation_active_item_min_width = 2131165326;
				design_bottom_navigation_active_text_size = 2131165327;
				design_bottom_navigation_elevation = 2131165328;
				design_bottom_navigation_height = 2131165329;
				design_bottom_navigation_icon_size = 2131165330;
				design_bottom_navigation_item_max_width = 2131165331;
				design_bottom_navigation_item_min_width = 2131165332;
				design_bottom_navigation_margin = 2131165333;
				design_bottom_navigation_shadow_height = 2131165334;
				design_bottom_navigation_text_size = 2131165335;
				design_bottom_sheet_modal_elevation = 2131165336;
				design_bottom_sheet_peek_height_min = 2131165337;
				design_fab_border_width = 2131165338;
				design_fab_elevation = 2131165339;
				design_fab_image_size = 2131165340;
				design_fab_size_mini = 2131165341;
				design_fab_size_normal = 2131165342;
				design_fab_translation_z_hovered_focused = 2131165343;
				design_fab_translation_z_pressed = 2131165344;
				design_navigation_elevation = 2131165345;
				design_navigation_icon_padding = 2131165346;
				design_navigation_icon_size = 2131165347;
				design_navigation_item_horizontal_padding = 2131165348;
				design_navigation_item_icon_padding = 2131165349;
				design_navigation_max_width = 2131165350;
				design_navigation_padding_bottom = 2131165351;
				design_navigation_separator_vertical_padding = 2131165352;
				design_snackbar_action_inline_max_width = 2131165353;
				design_snackbar_background_corner_radius = 2131165354;
				design_snackbar_elevation = 2131165355;
				design_snackbar_extra_spacing_horizontal = 2131165356;
				design_snackbar_max_width = 2131165357;
				design_snackbar_min_width = 2131165358;
				design_snackbar_padding_horizontal = 2131165359;
				design_snackbar_padding_vertical = 2131165360;
				design_snackbar_padding_vertical_2lines = 2131165361;
				design_snackbar_text_size = 2131165362;
				design_tab_max_width = 2131165363;
				design_tab_scrollable_min_width = 2131165364;
				design_tab_text_size = 2131165365;
				design_tab_text_size_2line = 2131165366;
				design_textinput_caption_translate_y = 2131165367;
				disabled_alpha_material_dark = 2131165368;
				disabled_alpha_material_light = 2131165369;
				draw_map_button_radius = 2131165370;
				exo_error_message_height = 2131165371;
				exo_error_message_margin_bottom = 2131165372;
				exo_error_message_text_padding_horizontal = 2131165373;
				exo_error_message_text_padding_vertical = 2131165374;
				exo_error_message_text_size = 2131165375;
				exo_icon_horizontal_margin = 2131165376;
				exo_icon_padding = 2131165377;
				exo_icon_padding_bottom = 2131165378;
				exo_icon_size = 2131165379;
				exo_icon_text_size = 2131165380;
				exo_media_button_height = 2131165381;
				exo_media_button_width = 2131165382;
				exo_settings_height = 2131165384;
				exo_settings_icon_size = 2131165385;
				exo_settings_main_text_size = 2131165386;
				exo_settings_offset = 2131165387;
				exo_settings_sub_text_size = 2131165388;
				exo_settings_text_height = 2131165389;
				exo_setting_width = 2131165383;
				exo_small_icon_height = 2131165390;
				exo_small_icon_horizontal_margin = 2131165391;
				exo_small_icon_padding_horizontal = 2131165392;
				exo_small_icon_padding_vertical = 2131165393;
				exo_small_icon_width = 2131165394;
				exo_styled_bottom_bar_height = 2131165395;
				exo_styled_bottom_bar_margin_top = 2131165396;
				exo_styled_bottom_bar_time_padding = 2131165397;
				exo_styled_controls_padding = 2131165398;
				exo_styled_minimal_controls_margin_bottom = 2131165399;
				exo_styled_progress_bar_height = 2131165400;
				exo_styled_progress_dragged_thumb_size = 2131165401;
				exo_styled_progress_enabled_thumb_size = 2131165402;
				exo_styled_progress_layout_height = 2131165403;
				exo_styled_progress_margin_bottom = 2131165404;
				exo_styled_progress_touch_target_height = 2131165405;
				fastscroll_default_thickness = 2131165406;
				fastscroll_margin = 2131165407;
				fastscroll_minimum_range = 2131165408;
				favorites_tile_description_text = 2131165409;
				favorites_tile_description_text_width = 2131165410;
				favorites_tile_description_top_margin = 2131165411;
				favorites_tile_title_text = 2131165412;
				full_screen_webview_error_text_size = 2131165413;
				full_screen_webview_native_loader_phone = 2131165414;
				full_screen_webview_native_loader_tablet = 2131165415;
				full_screen_webview_network_error_image_width = 2131165416;
				highlight_alpha_material_colored = 2131165417;
				highlight_alpha_material_dark = 2131165418;
				highlight_alpha_material_light = 2131165419;
				hint_alpha_material_dark = 2131165420;
				hint_alpha_material_light = 2131165421;
				hint_pressed_alpha_material_dark = 2131165422;
				hint_pressed_alpha_material_light = 2131165423;
				item_touch_helper_max_drag_scroll_per_frame = 2131165424;
				item_touch_helper_swipe_escape_max_velocity = 2131165425;
				item_touch_helper_swipe_escape_velocity = 2131165426;
				library_tile_description_margin_top = 2131165427;
				library_tile_description_text = 2131165428;
				library_tile_description_width = 2131165429;
				library_tile_padding_bottom = 2131165430;
				library_tile_padding_left = 2131165431;
				library_tile_padding_right = 2131165432;
				library_tile_padding_top = 2131165433;
				library_tile_title_line_spacing = 2131165434;
				library_tile_title_text = 2131165435;
				library_tile_title_width = 2131165436;
				loading_accessories_size = 2131165437;
				loading_base_size = 2131165438;
				loading_circle_max = 2131165439;
				loading_circle_min = 2131165440;
				manual_tile_manual_label_textSize = 2131165441;
				manual_tile_padding_top = 2131165442;
				manual_tile_start_label_margin_top = 2131165443;
				manual_tile_start_label_textSize = 2131165444;
				map_tile_description_line_spacing = 2131165445;
				map_tile_description_margin_top = 2131165446;
				map_tile_description_text = 2131165447;
				map_tile_description_width = 2131165448;
				map_tile_padding_bottom = 2131165449;
				map_tile_padding_left = 2131165450;
				map_tile_padding_right = 2131165451;
				map_tile_padding_top = 2131165452;
				map_tile_start_button_letter_spacing = 2131165453;
				map_tile_start_button_padding_horizontal = 2131165454;
				map_tile_start_button_padding_vertical = 2131165455;
				map_tile_start_button_text = 2131165456;
				map_tile_title_line_spacing = 2131165457;
				map_tile_title_text = 2131165458;
				map_tile_title_width = 2131165459;
				mtrl_bottomappbar_fabOffsetEndMode = 2131165460;
				mtrl_bottomappbar_fab_cradle_margin = 2131165461;
				mtrl_bottomappbar_fab_cradle_rounded_corner_radius = 2131165462;
				mtrl_bottomappbar_fab_cradle_vertical_offset = 2131165463;
				mtrl_bottomappbar_height = 2131165464;
				mtrl_btn_corner_radius = 2131165465;
				mtrl_btn_dialog_btn_min_width = 2131165466;
				mtrl_btn_disabled_elevation = 2131165467;
				mtrl_btn_disabled_z = 2131165468;
				mtrl_btn_elevation = 2131165469;
				mtrl_btn_focused_z = 2131165470;
				mtrl_btn_hovered_z = 2131165471;
				mtrl_btn_icon_btn_padding_left = 2131165472;
				mtrl_btn_icon_padding = 2131165473;
				mtrl_btn_inset = 2131165474;
				mtrl_btn_letter_spacing = 2131165475;
				mtrl_btn_padding_bottom = 2131165476;
				mtrl_btn_padding_left = 2131165477;
				mtrl_btn_padding_right = 2131165478;
				mtrl_btn_padding_top = 2131165479;
				mtrl_btn_pressed_z = 2131165480;
				mtrl_btn_stroke_size = 2131165481;
				mtrl_btn_text_btn_icon_padding = 2131165482;
				mtrl_btn_text_btn_padding_left = 2131165483;
				mtrl_btn_text_btn_padding_right = 2131165484;
				mtrl_btn_text_size = 2131165485;
				mtrl_btn_z = 2131165486;
				mtrl_card_elevation = 2131165487;
				mtrl_card_spacing = 2131165488;
				mtrl_chip_pressed_translation_z = 2131165489;
				mtrl_chip_text_size = 2131165490;
				mtrl_fab_elevation = 2131165491;
				mtrl_fab_translation_z_hovered_focused = 2131165492;
				mtrl_fab_translation_z_pressed = 2131165493;
				mtrl_navigation_elevation = 2131165494;
				mtrl_navigation_item_horizontal_padding = 2131165495;
				mtrl_navigation_item_icon_padding = 2131165496;
				mtrl_snackbar_background_corner_radius = 2131165497;
				mtrl_snackbar_margin = 2131165498;
				mtrl_textinput_box_bottom_offset = 2131165499;
				mtrl_textinput_box_corner_radius_medium = 2131165500;
				mtrl_textinput_box_corner_radius_small = 2131165501;
				mtrl_textinput_box_label_cutout_padding = 2131165502;
				mtrl_textinput_box_padding_end = 2131165503;
				mtrl_textinput_box_stroke_width_default = 2131165504;
				mtrl_textinput_box_stroke_width_focused = 2131165505;
				mtrl_textinput_outline_box_expanded_padding = 2131165506;
				mtrl_toolbar_default_height = 2131165507;
				notification_action_icon_size = 2131165508;
				notification_action_text_size = 2131165509;
				notification_big_circle_margin = 2131165510;
				notification_content_margin_start = 2131165511;
				notification_large_icon_height = 2131165512;
				notification_large_icon_width = 2131165513;
				notification_main_column_padding_top = 2131165514;
				notification_media_narrow_margin = 2131165515;
				notification_right_icon_size = 2131165516;
				notification_right_side_padding_top = 2131165517;
				notification_small_icon_background_padding = 2131165518;
				notification_small_icon_size_as_large = 2131165519;
				notification_subtext_size = 2131165520;
				notification_top_pad = 2131165521;
				notification_top_pad_large_text = 2131165522;
				rating_container_text_size = 2131165523;
				summary_activity_share_button_padding = 2131165524;
				summary_activity_share_center_button_marginRight = 2131165525;
				summary_activity_share_container_height = 2131165526;
				summary_activity_share_container_marginTop = 2131165527;
				summary_activity_share_container_width = 2131165528;
				summary_activity_share_facebook_button_marginLeft = 2131165529;
				summary_activity_share_facebook_button_marginTop = 2131165530;
				summary_activity_share_google_button_marginLeft = 2131165531;
				summary_activity_share_google_button_marginTop = 2131165532;
				summary_activity_share_margin_right = 2131165533;
				summary_activity_share_twitter_button_marginLeft = 2131165534;
				summary_activity_share_twitter_button_marginTop = 2131165535;
				tooltip_corner_radius = 2131165536;
				tooltip_horizontal_padding = 2131165537;
				tooltip_margin = 2131165538;
				tooltip_precise_anchor_extra_offset = 2131165539;
				tooltip_precise_anchor_threshold = 2131165540;
				tooltip_vertical_padding = 2131165541;
				tooltip_y_offset_non_touch = 2131165542;
				tooltip_y_offset_touch = 2131165543;
				twitter_cancel_margin = 2131165544;
				twitter_cancel_padding = 2131165545;
				twitter_cancel_textSize = 2131165546;
				twitter_dialog_width = 2131165547;
				twitter_title_margin = 2131165548;
				twitter_title_padding = 2131165549;
				twitter_title_textSize = 2131165550;
				twitter_webview_height = 2131165551;
				webview_dialog_cancel_margin = 2131165552;
				webview_dialog_cancel_padding = 2131165553;
				webview_dialog_cancel_textSize = 2131165554;
				webview_dialog_title_margin = 2131165555;
				webview_dialog_title_padding = 2131165556;
				webview_dialog_title_textSize = 2131165557;
				webview_dialog_webview_height = 2131165558;
				webview_dialog_width = 2131165559;
				ResourceIdManager.UpdateIdValues();
			}

			private Dimension()
			{
			}
		}

		public class Drawable
		{
			public static int abc_ab_share_pack_mtrl_alpha;

			public static int abc_action_bar_item_background_material;

			public static int abc_btn_borderless_material;

			public static int abc_btn_check_material;

			public static int abc_btn_check_material_anim;

			public static int abc_btn_check_to_on_mtrl_000;

			public static int abc_btn_check_to_on_mtrl_015;

			public static int abc_btn_colored_material;

			public static int abc_btn_default_mtrl_shape;

			public static int abc_btn_radio_material;

			public static int abc_btn_radio_material_anim;

			public static int abc_btn_radio_to_on_mtrl_000;

			public static int abc_btn_radio_to_on_mtrl_015;

			public static int abc_btn_switch_to_on_mtrl_00001;

			public static int abc_btn_switch_to_on_mtrl_00012;

			public static int abc_cab_background_internal_bg;

			public static int abc_cab_background_top_material;

			public static int abc_cab_background_top_mtrl_alpha;

			public static int abc_control_background_material;

			public static int abc_dialog_material_background;

			public static int abc_edit_text_material;

			public static int abc_ic_ab_back_material;

			public static int abc_ic_arrow_drop_right_black_24dp;

			public static int abc_ic_clear_material;

			public static int abc_ic_commit_search_api_mtrl_alpha;

			public static int abc_ic_go_search_api_material;

			public static int abc_ic_menu_copy_mtrl_am_alpha;

			public static int abc_ic_menu_cut_mtrl_alpha;

			public static int abc_ic_menu_overflow_material;

			public static int abc_ic_menu_paste_mtrl_am_alpha;

			public static int abc_ic_menu_selectall_mtrl_alpha;

			public static int abc_ic_menu_share_mtrl_alpha;

			public static int abc_ic_search_api_material;

			public static int abc_ic_voice_search_api_material;

			public static int abc_item_background_holo_dark;

			public static int abc_item_background_holo_light;

			public static int abc_list_divider_material;

			public static int abc_list_divider_mtrl_alpha;

			public static int abc_list_focused_holo;

			public static int abc_list_longpressed_holo;

			public static int abc_list_pressed_holo_dark;

			public static int abc_list_pressed_holo_light;

			public static int abc_list_selector_background_transition_holo_dark;

			public static int abc_list_selector_background_transition_holo_light;

			public static int abc_list_selector_disabled_holo_dark;

			public static int abc_list_selector_disabled_holo_light;

			public static int abc_list_selector_holo_dark;

			public static int abc_list_selector_holo_light;

			public static int abc_menu_hardkey_panel_mtrl_mult;

			public static int abc_popup_background_mtrl_mult;

			public static int abc_ratingbar_indicator_material;

			public static int abc_ratingbar_material;

			public static int abc_ratingbar_small_material;

			public static int abc_scrubber_control_off_mtrl_alpha;

			public static int abc_scrubber_control_to_pressed_mtrl_000;

			public static int abc_scrubber_control_to_pressed_mtrl_005;

			public static int abc_scrubber_primary_mtrl_alpha;

			public static int abc_scrubber_track_mtrl_alpha;

			public static int abc_seekbar_thumb_material;

			public static int abc_seekbar_tick_mark_material;

			public static int abc_seekbar_track_material;

			public static int abc_spinner_mtrl_am_alpha;

			public static int abc_spinner_textfield_background_material;

			public static int abc_star_black_48dp;

			public static int abc_star_half_black_48dp;

			public static int abc_switch_thumb_material;

			public static int abc_switch_track_mtrl_alpha;

			public static int abc_tab_indicator_material;

			public static int abc_tab_indicator_mtrl_alpha;

			public static int abc_textfield_activated_mtrl_alpha;

			public static int abc_textfield_default_mtrl_alpha;

			public static int abc_textfield_search_activated_mtrl_alpha;

			public static int abc_textfield_search_default_mtrl_alpha;

			public static int abc_textfield_search_material;

			public static int abc_text_cursor_material;

			public static int abc_text_select_handle_left_mtrl;

			public static int abc_text_select_handle_middle_mtrl;

			public static int abc_text_select_handle_right_mtrl;

			public static int abc_vector_test;

			public static int avd_hide_password;

			public static int avd_show_password;

			public static int bg_share_workout;

			public static int btn_checkbox_checked_mtrl;

			public static int btn_checkbox_checked_to_unchecked_mtrl_animation;

			public static int btn_checkbox_unchecked_mtrl;

			public static int btn_checkbox_unchecked_to_checked_mtrl_animation;

			public static int btn_radio_off_mtrl;

			public static int btn_radio_off_to_on_mtrl_animation;

			public static int btn_radio_on_mtrl;

			public static int btn_radio_on_to_off_mtrl_animation;

			public static int btn_share;

			public static int common_full_open_on_phone;

			public static int common_google_signin_btn_icon_dark;

			public static int common_google_signin_btn_icon_dark_focused;

			public static int common_google_signin_btn_icon_dark_normal;

			public static int common_google_signin_btn_icon_dark_normal_background;

			public static int common_google_signin_btn_icon_disabled;

			public static int common_google_signin_btn_icon_light;

			public static int common_google_signin_btn_icon_light_focused;

			public static int common_google_signin_btn_icon_light_normal;

			public static int common_google_signin_btn_icon_light_normal_background;

			public static int common_google_signin_btn_text_dark;

			public static int common_google_signin_btn_text_dark_focused;

			public static int common_google_signin_btn_text_dark_normal;

			public static int common_google_signin_btn_text_dark_normal_background;

			public static int common_google_signin_btn_text_disabled;

			public static int common_google_signin_btn_text_light;

			public static int common_google_signin_btn_text_light_focused;

			public static int common_google_signin_btn_text_light_normal;

			public static int common_google_signin_btn_text_light_normal_background;

			public static int com_facebook_auth_dialog_background;

			public static int com_facebook_auth_dialog_cancel_background;

			public static int com_facebook_auth_dialog_header_background;

			public static int com_facebook_button_background;

			public static int com_facebook_button_icon;

			public static int com_facebook_button_like_background;

			public static int com_facebook_button_like_icon_selected;

			public static int com_facebook_button_send_background;

			public static int com_facebook_button_send_icon_blue;

			public static int com_facebook_button_send_icon_white;

			public static int com_facebook_close;

			public static int com_facebook_favicon_blue;

			public static int com_facebook_profile_picture_blank_portrait;

			public static int com_facebook_profile_picture_blank_square;

			public static int com_facebook_send_button_icon;

			public static int com_facebook_tooltip_black_background;

			public static int com_facebook_tooltip_black_bottomnub;

			public static int com_facebook_tooltip_black_topnub;

			public static int com_facebook_tooltip_black_xout;

			public static int com_facebook_tooltip_blue_background;

			public static int com_facebook_tooltip_blue_bottomnub;

			public static int com_facebook_tooltip_blue_topnub;

			public static int com_facebook_tooltip_blue_xout;

			public static int DashboardStartButton;

			public static int dashboard_tile_scrim;

			public static int design_bottom_navigation_item_background;

			public static int design_fab_background;

			public static int design_ic_visibility;

			public static int design_ic_visibility_off;

			public static int design_password_eye;

			public static int design_snackbar_background;

			public static int draw_map_button;

			public static int exo_controls_fastforward;

			public static int exo_controls_fullscreen_enter;

			public static int exo_controls_fullscreen_exit;

			public static int exo_controls_next;

			public static int exo_controls_pause;

			public static int exo_controls_play;

			public static int exo_controls_previous;

			public static int exo_controls_repeat_all;

			public static int exo_controls_repeat_off;

			public static int exo_controls_repeat_one;

			public static int exo_controls_rewind;

			public static int exo_controls_shuffle_off;

			public static int exo_controls_shuffle_on;

			public static int exo_controls_vr;

			public static int exo_edit_mode_logo;

			public static int exo_icon_circular_play;

			public static int exo_icon_fastforward;

			public static int exo_icon_fullscreen_enter;

			public static int exo_icon_fullscreen_exit;

			public static int exo_icon_next;

			public static int exo_icon_pause;

			public static int exo_icon_play;

			public static int exo_icon_previous;

			public static int exo_icon_repeat_all;

			public static int exo_icon_repeat_off;

			public static int exo_icon_repeat_one;

			public static int exo_icon_rewind;

			public static int exo_icon_shuffle_off;

			public static int exo_icon_shuffle_on;

			public static int exo_icon_stop;

			public static int exo_icon_vr;

			public static int exo_ic_audiotrack;

			public static int exo_ic_check;

			public static int exo_ic_chevron_left;

			public static int exo_ic_chevron_right;

			public static int exo_ic_default_album_image;

			public static int exo_ic_forward;

			public static int exo_ic_fullscreen_enter;

			public static int exo_ic_fullscreen_exit;

			public static int exo_ic_pause_circle_filled;

			public static int exo_ic_play_circle_filled;

			public static int exo_ic_rewind;

			public static int exo_ic_settings;

			public static int exo_ic_skip_next;

			public static int exo_ic_skip_previous;

			public static int exo_ic_speed;

			public static int exo_ic_subtitle_off;

			public static int exo_ic_subtitle_on;

			public static int exo_notification_fastforward;

			public static int exo_notification_next;

			public static int exo_notification_pause;

			public static int exo_notification_play;

			public static int exo_notification_previous;

			public static int exo_notification_rewind;

			public static int exo_notification_small_icon;

			public static int exo_notification_stop;

			public static int exo_rounded_rectangle;

			public static int exo_styled_controls_audiotrack;

			public static int exo_styled_controls_check;

			public static int exo_styled_controls_fastforward;

			public static int exo_styled_controls_fullscreen_enter;

			public static int exo_styled_controls_fullscreen_exit;

			public static int exo_styled_controls_next;

			public static int exo_styled_controls_overflow_hide;

			public static int exo_styled_controls_overflow_show;

			public static int exo_styled_controls_pause;

			public static int exo_styled_controls_play;

			public static int exo_styled_controls_previous;

			public static int exo_styled_controls_repeat_all;

			public static int exo_styled_controls_repeat_off;

			public static int exo_styled_controls_repeat_one;

			public static int exo_styled_controls_rewind;

			public static int exo_styled_controls_settings;

			public static int exo_styled_controls_shuffle_off;

			public static int exo_styled_controls_shuffle_on;

			public static int exo_styled_controls_speed;

			public static int exo_styled_controls_subtitle_off;

			public static int exo_styled_controls_subtitle_on;

			public static int exo_styled_controls_vr;

			public static int googleg_disabled_color_18;

			public static int googleg_standard_color_18;

			public static int IcBluetooth;

			public static int IcBluetoothConnected;

			public static int IcCaloriesWhite;

			public static int IcCloseX;

			public static int IcDistanceWhite;

			public static int IcShareDialogClose;

			public static int IcShareFacebook;

			public static int IcShareFacebookPressed;

			public static int IcShareGoogle;

			public static int IcShareGooglePressed;

			public static int IcShareTwitter;

			public static int IcShareTwitterPressed;

			public static int IcStopwatchWhite;

			public static int ic_action_notify_cancel;

			public static int ic_mtrl_chip_checked_black;

			public static int ic_mtrl_chip_checked_circle;

			public static int ic_mtrl_chip_close_circle;

			public static int ic_stat_notify_dfu;

			public static int LoadingIndicatorDot;

			public static int log_screen_share_button;

			public static int MapTile;

			public static int messenger_bubble_large_blue;

			public static int messenger_bubble_large_white;

			public static int messenger_bubble_small_blue;

			public static int messenger_bubble_small_white;

			public static int messenger_button_blue_bg_round;

			public static int messenger_button_blue_bg_selector;

			public static int messenger_button_send_round_shadow;

			public static int messenger_button_white_bg_round;

			public static int messenger_button_white_bg_selector;

			public static int mtrl_snackbar_background;

			public static int mtrl_tabs_default_indicator;

			public static int navigation_empty_icon;

			public static int notification_action_background;

			public static int notification_bg;

			public static int notification_bg_low;

			public static int notification_bg_low_normal;

			public static int notification_bg_low_pressed;

			public static int notification_bg_normal;

			public static int notification_bg_normal_pressed;

			public static int notification_icon_background;

			public static int notification_template_icon_bg;

			public static int notification_template_icon_low_bg;

			public static int notification_tile_bg;

			public static int notify_panel_notification_icon_bg;

			public static int SelectableItemBackground;

			public static int ShareFacebookSelector;

			public static int ShareGoogleSelector;

			public static int ShareTwitterSelector;

			public static int tooltip_frame_dark;

			public static int tooltip_frame_light;

			public static int WifiConnectedStrong;

			public static int WifiConnectedStrongest;

			public static int WifiConnectedWeak;

			public static int WifiConnectedWeakest;

			public static int WifiDisabled;

			public static int WifiEnabledNotConnected;

			public static int WifiImageButtonSelector;

			public static int wifi_disabled;

			public static int wifi_not_connected;

			public static int wifi_oval;

			public static int wifi_signal_2;

			public static int wifi_signal_3;

			public static int wifi_signal_4;

			public static int wifi_signal_5;

			static Drawable()
			{
				abc_ab_share_pack_mtrl_alpha = 2131230726;
				abc_action_bar_item_background_material = 2131230727;
				abc_btn_borderless_material = 2131230728;
				abc_btn_check_material = 2131230729;
				abc_btn_check_material_anim = 2131230730;
				abc_btn_check_to_on_mtrl_000 = 2131230731;
				abc_btn_check_to_on_mtrl_015 = 2131230732;
				abc_btn_colored_material = 2131230733;
				abc_btn_default_mtrl_shape = 2131230734;
				abc_btn_radio_material = 2131230735;
				abc_btn_radio_material_anim = 2131230736;
				abc_btn_radio_to_on_mtrl_000 = 2131230737;
				abc_btn_radio_to_on_mtrl_015 = 2131230738;
				abc_btn_switch_to_on_mtrl_00001 = 2131230739;
				abc_btn_switch_to_on_mtrl_00012 = 2131230740;
				abc_cab_background_internal_bg = 2131230741;
				abc_cab_background_top_material = 2131230742;
				abc_cab_background_top_mtrl_alpha = 2131230743;
				abc_control_background_material = 2131230744;
				abc_dialog_material_background = 2131230745;
				abc_edit_text_material = 2131230746;
				abc_ic_ab_back_material = 2131230747;
				abc_ic_arrow_drop_right_black_24dp = 2131230748;
				abc_ic_clear_material = 2131230749;
				abc_ic_commit_search_api_mtrl_alpha = 2131230750;
				abc_ic_go_search_api_material = 2131230751;
				abc_ic_menu_copy_mtrl_am_alpha = 2131230752;
				abc_ic_menu_cut_mtrl_alpha = 2131230753;
				abc_ic_menu_overflow_material = 2131230754;
				abc_ic_menu_paste_mtrl_am_alpha = 2131230755;
				abc_ic_menu_selectall_mtrl_alpha = 2131230756;
				abc_ic_menu_share_mtrl_alpha = 2131230757;
				abc_ic_search_api_material = 2131230758;
				abc_ic_voice_search_api_material = 2131230759;
				abc_item_background_holo_dark = 2131230760;
				abc_item_background_holo_light = 2131230761;
				abc_list_divider_material = 2131230762;
				abc_list_divider_mtrl_alpha = 2131230763;
				abc_list_focused_holo = 2131230764;
				abc_list_longpressed_holo = 2131230765;
				abc_list_pressed_holo_dark = 2131230766;
				abc_list_pressed_holo_light = 2131230767;
				abc_list_selector_background_transition_holo_dark = 2131230768;
				abc_list_selector_background_transition_holo_light = 2131230769;
				abc_list_selector_disabled_holo_dark = 2131230770;
				abc_list_selector_disabled_holo_light = 2131230771;
				abc_list_selector_holo_dark = 2131230772;
				abc_list_selector_holo_light = 2131230773;
				abc_menu_hardkey_panel_mtrl_mult = 2131230774;
				abc_popup_background_mtrl_mult = 2131230775;
				abc_ratingbar_indicator_material = 2131230776;
				abc_ratingbar_material = 2131230777;
				abc_ratingbar_small_material = 2131230778;
				abc_scrubber_control_off_mtrl_alpha = 2131230779;
				abc_scrubber_control_to_pressed_mtrl_000 = 2131230780;
				abc_scrubber_control_to_pressed_mtrl_005 = 2131230781;
				abc_scrubber_primary_mtrl_alpha = 2131230782;
				abc_scrubber_track_mtrl_alpha = 2131230783;
				abc_seekbar_thumb_material = 2131230784;
				abc_seekbar_tick_mark_material = 2131230785;
				abc_seekbar_track_material = 2131230786;
				abc_spinner_mtrl_am_alpha = 2131230787;
				abc_spinner_textfield_background_material = 2131230788;
				abc_star_black_48dp = 2131230789;
				abc_star_half_black_48dp = 2131230790;
				abc_switch_thumb_material = 2131230791;
				abc_switch_track_mtrl_alpha = 2131230792;
				abc_tab_indicator_material = 2131230793;
				abc_tab_indicator_mtrl_alpha = 2131230794;
				abc_textfield_activated_mtrl_alpha = 2131230799;
				abc_textfield_default_mtrl_alpha = 2131230800;
				abc_textfield_search_activated_mtrl_alpha = 2131230801;
				abc_textfield_search_default_mtrl_alpha = 2131230802;
				abc_textfield_search_material = 2131230803;
				abc_text_cursor_material = 2131230795;
				abc_text_select_handle_left_mtrl = 2131230796;
				abc_text_select_handle_middle_mtrl = 2131230797;
				abc_text_select_handle_right_mtrl = 2131230798;
				abc_vector_test = 2131230804;
				avd_hide_password = 2131230805;
				avd_show_password = 2131230806;
				bg_share_workout = 2131230807;
				btn_checkbox_checked_mtrl = 2131230808;
				btn_checkbox_checked_to_unchecked_mtrl_animation = 2131230809;
				btn_checkbox_unchecked_mtrl = 2131230810;
				btn_checkbox_unchecked_to_checked_mtrl_animation = 2131230811;
				btn_radio_off_mtrl = 2131230812;
				btn_radio_off_to_on_mtrl_animation = 2131230813;
				btn_radio_on_mtrl = 2131230814;
				btn_radio_on_to_off_mtrl_animation = 2131230815;
				btn_share = 2131230816;
				common_full_open_on_phone = 2131230840;
				common_google_signin_btn_icon_dark = 2131230841;
				common_google_signin_btn_icon_dark_focused = 2131230842;
				common_google_signin_btn_icon_dark_normal = 2131230843;
				common_google_signin_btn_icon_dark_normal_background = 2131230844;
				common_google_signin_btn_icon_disabled = 2131230845;
				common_google_signin_btn_icon_light = 2131230846;
				common_google_signin_btn_icon_light_focused = 2131230847;
				common_google_signin_btn_icon_light_normal = 2131230848;
				common_google_signin_btn_icon_light_normal_background = 2131230849;
				common_google_signin_btn_text_dark = 2131230850;
				common_google_signin_btn_text_dark_focused = 2131230851;
				common_google_signin_btn_text_dark_normal = 2131230852;
				common_google_signin_btn_text_dark_normal_background = 2131230853;
				common_google_signin_btn_text_disabled = 2131230854;
				common_google_signin_btn_text_light = 2131230855;
				common_google_signin_btn_text_light_focused = 2131230856;
				common_google_signin_btn_text_light_normal = 2131230857;
				common_google_signin_btn_text_light_normal_background = 2131230858;
				com_facebook_auth_dialog_background = 2131230817;
				com_facebook_auth_dialog_cancel_background = 2131230818;
				com_facebook_auth_dialog_header_background = 2131230819;
				com_facebook_button_background = 2131230820;
				com_facebook_button_icon = 2131230821;
				com_facebook_button_like_background = 2131230822;
				com_facebook_button_like_icon_selected = 2131230823;
				com_facebook_button_send_background = 2131230824;
				com_facebook_button_send_icon_blue = 2131230825;
				com_facebook_button_send_icon_white = 2131230826;
				com_facebook_close = 2131230827;
				com_facebook_favicon_blue = 2131230828;
				com_facebook_profile_picture_blank_portrait = 2131230829;
				com_facebook_profile_picture_blank_square = 2131230830;
				com_facebook_send_button_icon = 2131230831;
				com_facebook_tooltip_black_background = 2131230832;
				com_facebook_tooltip_black_bottomnub = 2131230833;
				com_facebook_tooltip_black_topnub = 2131230834;
				com_facebook_tooltip_black_xout = 2131230835;
				com_facebook_tooltip_blue_background = 2131230836;
				com_facebook_tooltip_blue_bottomnub = 2131230837;
				com_facebook_tooltip_blue_topnub = 2131230838;
				com_facebook_tooltip_blue_xout = 2131230839;
				DashboardStartButton = 2131230860;
				dashboard_tile_scrim = 2131230859;
				design_bottom_navigation_item_background = 2131230861;
				design_fab_background = 2131230862;
				design_ic_visibility = 2131230863;
				design_ic_visibility_off = 2131230864;
				design_password_eye = 2131230865;
				design_snackbar_background = 2131230866;
				draw_map_button = 2131230867;
				exo_controls_fastforward = 2131230868;
				exo_controls_fullscreen_enter = 2131230869;
				exo_controls_fullscreen_exit = 2131230870;
				exo_controls_next = 2131230871;
				exo_controls_pause = 2131230872;
				exo_controls_play = 2131230873;
				exo_controls_previous = 2131230874;
				exo_controls_repeat_all = 2131230875;
				exo_controls_repeat_off = 2131230876;
				exo_controls_repeat_one = 2131230877;
				exo_controls_rewind = 2131230878;
				exo_controls_shuffle_off = 2131230879;
				exo_controls_shuffle_on = 2131230880;
				exo_controls_vr = 2131230881;
				exo_edit_mode_logo = 2131230882;
				exo_icon_circular_play = 2131230900;
				exo_icon_fastforward = 2131230901;
				exo_icon_fullscreen_enter = 2131230902;
				exo_icon_fullscreen_exit = 2131230903;
				exo_icon_next = 2131230904;
				exo_icon_pause = 2131230905;
				exo_icon_play = 2131230906;
				exo_icon_previous = 2131230907;
				exo_icon_repeat_all = 2131230908;
				exo_icon_repeat_off = 2131230909;
				exo_icon_repeat_one = 2131230910;
				exo_icon_rewind = 2131230911;
				exo_icon_shuffle_off = 2131230912;
				exo_icon_shuffle_on = 2131230913;
				exo_icon_stop = 2131230914;
				exo_icon_vr = 2131230915;
				exo_ic_audiotrack = 2131230883;
				exo_ic_check = 2131230884;
				exo_ic_chevron_left = 2131230885;
				exo_ic_chevron_right = 2131230886;
				exo_ic_default_album_image = 2131230887;
				exo_ic_forward = 2131230888;
				exo_ic_fullscreen_enter = 2131230889;
				exo_ic_fullscreen_exit = 2131230890;
				exo_ic_pause_circle_filled = 2131230891;
				exo_ic_play_circle_filled = 2131230892;
				exo_ic_rewind = 2131230893;
				exo_ic_settings = 2131230894;
				exo_ic_skip_next = 2131230895;
				exo_ic_skip_previous = 2131230896;
				exo_ic_speed = 2131230897;
				exo_ic_subtitle_off = 2131230898;
				exo_ic_subtitle_on = 2131230899;
				exo_notification_fastforward = 2131230916;
				exo_notification_next = 2131230917;
				exo_notification_pause = 2131230918;
				exo_notification_play = 2131230919;
				exo_notification_previous = 2131230920;
				exo_notification_rewind = 2131230921;
				exo_notification_small_icon = 2131230922;
				exo_notification_stop = 2131230923;
				exo_rounded_rectangle = 2131230924;
				exo_styled_controls_audiotrack = 2131230925;
				exo_styled_controls_check = 2131230926;
				exo_styled_controls_fastforward = 2131230927;
				exo_styled_controls_fullscreen_enter = 2131230928;
				exo_styled_controls_fullscreen_exit = 2131230929;
				exo_styled_controls_next = 2131230930;
				exo_styled_controls_overflow_hide = 2131230931;
				exo_styled_controls_overflow_show = 2131230932;
				exo_styled_controls_pause = 2131230933;
				exo_styled_controls_play = 2131230934;
				exo_styled_controls_previous = 2131230935;
				exo_styled_controls_repeat_all = 2131230936;
				exo_styled_controls_repeat_off = 2131230937;
				exo_styled_controls_repeat_one = 2131230938;
				exo_styled_controls_rewind = 2131230939;
				exo_styled_controls_settings = 2131230940;
				exo_styled_controls_shuffle_off = 2131230941;
				exo_styled_controls_shuffle_on = 2131230942;
				exo_styled_controls_speed = 2131230943;
				exo_styled_controls_subtitle_off = 2131230944;
				exo_styled_controls_subtitle_on = 2131230945;
				exo_styled_controls_vr = 2131230946;
				googleg_disabled_color_18 = 2131230947;
				googleg_standard_color_18 = 2131230948;
				IcBluetooth = 2131230954;
				IcBluetoothConnected = 2131230955;
				IcCaloriesWhite = 2131230956;
				IcCloseX = 2131230957;
				IcDistanceWhite = 2131230958;
				IcShareDialogClose = 2131230959;
				IcShareFacebook = 2131230960;
				IcShareFacebookPressed = 2131230961;
				IcShareGoogle = 2131230962;
				IcShareGooglePressed = 2131230963;
				IcShareTwitter = 2131230964;
				IcShareTwitterPressed = 2131230965;
				IcStopwatchWhite = 2131230966;
				ic_action_notify_cancel = 2131230949;
				ic_mtrl_chip_checked_black = 2131230950;
				ic_mtrl_chip_checked_circle = 2131230951;
				ic_mtrl_chip_close_circle = 2131230952;
				ic_stat_notify_dfu = 2131230953;
				LoadingIndicatorDot = 2131230967;
				log_screen_share_button = 2131230968;
				MapTile = 2131230969;
				messenger_bubble_large_blue = 2131230970;
				messenger_bubble_large_white = 2131230971;
				messenger_bubble_small_blue = 2131230972;
				messenger_bubble_small_white = 2131230973;
				messenger_button_blue_bg_round = 2131230974;
				messenger_button_blue_bg_selector = 2131230975;
				messenger_button_send_round_shadow = 2131230976;
				messenger_button_white_bg_round = 2131230977;
				messenger_button_white_bg_selector = 2131230978;
				mtrl_snackbar_background = 2131230979;
				mtrl_tabs_default_indicator = 2131230980;
				navigation_empty_icon = 2131230981;
				notification_action_background = 2131230982;
				notification_bg = 2131230983;
				notification_bg_low = 2131230984;
				notification_bg_low_normal = 2131230985;
				notification_bg_low_pressed = 2131230986;
				notification_bg_normal = 2131230987;
				notification_bg_normal_pressed = 2131230988;
				notification_icon_background = 2131230989;
				notification_template_icon_bg = 2131230990;
				notification_template_icon_low_bg = 2131230991;
				notification_tile_bg = 2131230992;
				notify_panel_notification_icon_bg = 2131230993;
				SelectableItemBackground = 2131230994;
				ShareFacebookSelector = 2131230995;
				ShareGoogleSelector = 2131230996;
				ShareTwitterSelector = 2131230997;
				tooltip_frame_dark = 2131230998;
				tooltip_frame_light = 2131230999;
				WifiConnectedStrong = 2131231007;
				WifiConnectedStrongest = 2131231008;
				WifiConnectedWeak = 2131231009;
				WifiConnectedWeakest = 2131231010;
				WifiDisabled = 2131231011;
				WifiEnabledNotConnected = 2131231012;
				WifiImageButtonSelector = 2131231013;
				wifi_disabled = 2131231000;
				wifi_not_connected = 2131231001;
				wifi_oval = 2131231002;
				wifi_signal_2 = 2131231003;
				wifi_signal_3 = 2131231004;
				wifi_signal_4 = 2131231005;
				wifi_signal_5 = 2131231006;
				ResourceIdManager.UpdateIdValues();
			}

			private Drawable()
			{
			}
		}

		public class Font
		{
			public static int roboto_medium_numbers;

			static Font()
			{
				roboto_medium_numbers = 2131296256;
				ResourceIdManager.UpdateIdValues();
			}

			private Font()
			{
			}
		}

		public class Id
		{
			public static int accessibility_action_clickable_span;

			public static int accessibility_custom_action_0;

			public static int accessibility_custom_action_1;

			public static int accessibility_custom_action_10;

			public static int accessibility_custom_action_11;

			public static int accessibility_custom_action_12;

			public static int accessibility_custom_action_13;

			public static int accessibility_custom_action_14;

			public static int accessibility_custom_action_15;

			public static int accessibility_custom_action_16;

			public static int accessibility_custom_action_17;

			public static int accessibility_custom_action_18;

			public static int accessibility_custom_action_19;

			public static int accessibility_custom_action_2;

			public static int accessibility_custom_action_20;

			public static int accessibility_custom_action_21;

			public static int accessibility_custom_action_22;

			public static int accessibility_custom_action_23;

			public static int accessibility_custom_action_24;

			public static int accessibility_custom_action_25;

			public static int accessibility_custom_action_26;

			public static int accessibility_custom_action_27;

			public static int accessibility_custom_action_28;

			public static int accessibility_custom_action_29;

			public static int accessibility_custom_action_3;

			public static int accessibility_custom_action_30;

			public static int accessibility_custom_action_31;

			public static int accessibility_custom_action_4;

			public static int accessibility_custom_action_5;

			public static int accessibility_custom_action_6;

			public static int accessibility_custom_action_7;

			public static int accessibility_custom_action_8;

			public static int accessibility_custom_action_9;

			public static int action0;

			public static int actions;

			public static int action_bar;

			public static int action_bar_activity_content;

			public static int action_bar_container;

			public static int action_bar_root;

			public static int action_bar_spinner;

			public static int action_bar_subtitle;

			public static int action_bar_title;

			public static int action_container;

			public static int action_context_bar;

			public static int action_divider;

			public static int action_image;

			public static int action_menu_divider;

			public static int action_menu_presenter;

			public static int action_mode_bar;

			public static int action_mode_bar_stub;

			public static int action_mode_close_button;

			public static int action_text;

			public static int activity_chooser_view_content;

			public static int add;

			public static int adjust_height;

			public static int adjust_width;

			public static int alertTitle;

			public static int all;

			public static int ALT;

			public static int always;

			public static int androidx_window_activity_scope;

			public static int async;

			public static int auto;

			public static int automatic;

			public static int beginning;

			public static int blocking;

			public static int bottom;

			public static int box_count;

			public static int browser_actions_header_text;

			public static int browser_actions_menu_items;

			public static int browser_actions_menu_item_icon;

			public static int browser_actions_menu_item_text;

			public static int browser_actions_menu_view;

			public static int button;

			public static int buttonPanel;

			public static int cancel_action;

			public static int cancel_button;

			public static int center;

			public static int center_horizontal;

			public static int center_vertical;

			public static int checkbox;

			public static int @checked;

			public static int chronometer;

			public static int clip_horizontal;

			public static int clip_vertical;

			public static int closeButton;

			public static int collapseActionView;

			public static int com_facebook_body_frame;

			public static int com_facebook_button_xout;

			public static int com_facebook_device_auth_instructions;

			public static int com_facebook_fragment_container;

			public static int com_facebook_login_fragment_progress_bar;

			public static int com_facebook_smart_instructions_0;

			public static int com_facebook_smart_instructions_or;

			public static int com_facebook_tooltip_bubble_view_bottom_pointer;

			public static int com_facebook_tooltip_bubble_view_text_body;

			public static int com_facebook_tooltip_bubble_view_top_pointer;

			public static int confirmation_code;

			public static int container;

			public static int content;

			public static int contentPanel;

			public static int coordinator;

			public static int CTRL;

			public static int custom;

			public static int customPanel;

			public static int dark;

			public static int dashboard_content_container;

			public static int dashboard_manual_label;

			public static int dashboard_start_label;

			public static int dashboard_tile_background;

			public static int dashboard_tile_calorie_icon;

			public static int dashboard_tile_calorie_unit;

			public static int dashboard_tile_calorie_value;

			public static int dashboard_tile_distance_icon;

			public static int dashboard_tile_distance_unit;

			public static int dashboard_tile_distance_value;

			public static int dashboard_tile_metrics;

			public static int dashboard_tile_nonpremium_overlay;

			public static int dashboard_tile_start_button;

			public static int dashboard_tile_time_icon;

			public static int dashboard_tile_time_value;

			public static int dashboard_tile_title;

			public static int dashboard_tile_type;

			public static int dashboard_time_container;

			public static int decor_content_parent;

			public static int default_activity_button;

			public static int design_bottom_sheet;

			public static int design_menu_item_action_area;

			public static int design_menu_item_action_area_stub;

			public static int design_menu_item_text;

			public static int design_navigation_view;

			public static int dialogCancelButton;

			public static int dialogTitle;

			public static int dialogWebView;

			public static int dialog_button;

			public static int disableHome;

			public static int display_always;

			public static int edit_query;

			public static int end;

			public static int end_padder;

			public static int enterAlways;

			public static int enterAlwaysCollapsed;

			public static int exitUntilCollapsed;

			public static int exo_ad_overlay;

			public static int exo_artwork;

			public static int exo_audio_track;

			public static int exo_basic_controls;

			public static int exo_bottom_bar;

			public static int exo_buffering;

			public static int exo_center_controls;

			public static int exo_check;

			public static int exo_content_frame;

			public static int exo_controller;

			public static int exo_controller_placeholder;

			public static int exo_controls_background;

			public static int exo_duration;

			public static int exo_error_message;

			public static int exo_extra_controls;

			public static int exo_extra_controls_scroll_view;

			public static int exo_ffwd;

			public static int exo_ffwd_with_amount;

			public static int exo_fullscreen;

			public static int exo_icon;

			public static int exo_main_text;

			public static int exo_minimal_controls;

			public static int exo_minimal_fullscreen;

			public static int exo_next;

			public static int exo_overflow_hide;

			public static int exo_overflow_show;

			public static int exo_overlay;

			public static int exo_pause;

			public static int exo_play;

			public static int exo_playback_speed;

			public static int exo_play_pause;

			public static int exo_position;

			public static int exo_prev;

			public static int exo_progress;

			public static int exo_progress_placeholder;

			public static int exo_repeat_toggle;

			public static int exo_rew;

			public static int exo_rew_with_amount;

			public static int exo_settings;

			public static int exo_settings_listview;

			public static int exo_shuffle;

			public static int exo_shutter;

			public static int exo_subtitle;

			public static int exo_subtitles;

			public static int exo_sub_text;

			public static int exo_text;

			public static int exo_time;

			public static int exo_track_selection_view;

			public static int exo_vr;

			public static int expanded_menu;

			public static int expand_activities_button;

			public static int favorites_tile_background;

			public static int favorites_tile_description;

			public static int favorites_tile_nonpremium_overlay;

			public static int favorites_tile_title;

			public static int fill;

			public static int filled;

			public static int fill_horizontal;

			public static int fill_vertical;

			public static int fit;

			public static int @fixed;

			public static int fixed_height;

			public static int fixed_width;

			public static int forever;

			public static int FUNCTION;

			public static int georgia_regular;

			public static int ghost_view;

			public static int ghost_view_holder;

			public static int group_divider;

			public static int hardware;

			public static int home;

			public static int homeAsUp;

			public static int hybrid;

			public static int icon;

			public static int icon_group;

			public static int icon_only;

			public static int ifRoom;

			public static int image;

			public static int info;

			public static int inline;

			public static int italic;

			public static int item_touch_helper_previous_elevation;

			public static int labeled;

			public static int large;

			public static int largeLabel;

			public static int league_gothic_regular;

			public static int left;

			public static int library_tile_background;

			public static int library_tile_description;

			public static int library_tile_nonpremium_overlay;

			public static int library_tile_title;

			public static int light;

			public static int line1;

			public static int line3;

			public static int listMode;

			public static int list_item;

			public static int locale;

			public static int log_screen_share_button;

			public static int lottie_layer_name;

			public static int ltr;

			public static int manual_text_container;

			public static int map_fragment;

			public static int map_tile_background;

			public static int map_tile_description;

			public static int map_tile_start_button;

			public static int map_tile_title;

			public static int martines10;

			public static int martines11;

			public static int masked;

			public static int media_actions;

			public static int media_controller_compat_view_tag;

			public static int message;

			public static int messenger_send_button;

			public static int META;

			public static int middle;

			public static int mini;

			public static int mtrl_child_content_container;

			public static int mtrl_internal_children_alpha_tag;

			public static int multiply;

			public static int MvvmCrossTagId;

			public static int MvxBindingTagUnique;

			public static int navigation_header_container;

			public static int never;

			public static int never_display;

			public static int none;

			public static int normal;

			public static int notification_background;

			public static int notification_main_column;

			public static int notification_main_column_container;

			public static int off;

			public static int on;

			public static int one;

			public static int open_graph;

			public static int outline;

			public static int page;

			public static int parallax;

			public static int parentPanel;

			public static int parent_matrix;

			public static int pin;

			public static int progress_bar;

			public static int progress_circular;

			public static int progress_horizontal;

			public static int proxima_black;

			public static int proxima_bold;

			public static int proxima_extraBold;

			public static int proxima_light;

			public static int proxima_lightItalic;

			public static int proxima_regular;

			public static int proxima_regularItalic;

			public static int proxima_semiBold;

			public static int proxima_semiBoldItalic;

			public static int proxima_thin;

			public static int radio;

			public static int rating_layout;

			public static int restart;

			public static int reverse;

			public static int right;

			public static int right_icon;

			public static int right_side;

			public static int roboto_regular;

			public static int rtl;

			public static int satellite;

			public static int save_non_transition_alpha;

			public static int save_overlay_view;

			public static int screen;

			public static int scroll;

			public static int scrollable;

			public static int scrollIndicatorDown;

			public static int scrollIndicatorUp;

			public static int scrollView;

			public static int search_badge;

			public static int search_bar;

			public static int search_button;

			public static int search_close_btn;

			public static int search_edit_frame;

			public static int search_go_btn;

			public static int search_mag_icon;

			public static int search_plate;

			public static int search_src_text;

			public static int search_voice_btn;

			public static int selected;

			public static int select_dialog_listview;

			public static int shareAnchor;

			public static int shareContainer;

			public static int shareFacebookButton;

			public static int shareTwitterButton;

			public static int SHIFT;

			public static int shortcut;

			public static int showCustom;

			public static int showHome;

			public static int showTitle;

			public static int small;

			public static int smallLabel;

			public static int snackbar_action;

			public static int snackbar_text;

			public static int snap;

			public static int snapMargins;

			public static int software;

			public static int spacer;

			public static int spherical_gl_surface_view;

			public static int split_action_bar;

			public static int src_atop;

			public static int src_in;

			public static int src_over;

			public static int standard;

			public static int start;

			public static int status_bar_latest_event_content;

			public static int stretch;

			public static int submenuarrow;

			public static int submit_area;

			public static int surface_view;

			public static int SYM;

			public static int tabMode;

			public static int tag_accessibility_actions;

			public static int tag_accessibility_clickable_spans;

			public static int tag_accessibility_heading;

			public static int tag_accessibility_pane_title;

			public static int tag_on_apply_window_listener;

			public static int tag_on_receive_content_listener;

			public static int tag_on_receive_content_mime_types;

			public static int tag_screen_reader_focusable;

			public static int tag_state_description;

			public static int tag_transition_group;

			public static int tag_unhandled_key_event_manager;

			public static int tag_unhandled_key_listeners;

			public static int tag_window_insets_animation_callback;

			public static int terrain;

			public static int text;

			public static int text2;

			public static int textinput_counter;

			public static int textinput_error;

			public static int textinput_helper_text;

			public static int textSpacerNoButtons;

			public static int textSpacerNoTitle;

			public static int textStart;

			public static int texture_view;

			public static int text_input_password_toggle;

			public static int time;

			public static int title;

			public static int titleDividerNoCustom;

			public static int title_template;

			public static int top;

			public static int topPanel;

			public static int touch_outside;

			public static int transition_current_scene;

			public static int transition_layout_save;

			public static int transition_position;

			public static int transition_scene_layoutid_cache;

			public static int transition_transform;

			public static int twitterCancelButton;

			public static int twitterDialogTitle;

			public static int twitterWebView;

			public static int @unchecked;

			public static int uniform;

			public static int unknown;

			public static int unlabeled;

			public static int up;

			public static int useLogo;

			public static int video_decoder_gl_surface_view;

			public static int view_offset_helper;

			public static int view_tree_lifecycle_owner;

			public static int view_tree_saved_state_registry_owner;

			public static int view_tree_view_model_store_owner;

			public static int visible;

			public static int when_playing;

			public static int wide;

			public static int withText;

			public static int workout_rating_label;

			public static int wrap_content;

			public static int zoom;

			static Id()
			{
				accessibility_action_clickable_span = 2131427336;
				accessibility_custom_action_0 = 2131427337;
				accessibility_custom_action_1 = 2131427338;
				accessibility_custom_action_10 = 2131427339;
				accessibility_custom_action_11 = 2131427340;
				accessibility_custom_action_12 = 2131427341;
				accessibility_custom_action_13 = 2131427342;
				accessibility_custom_action_14 = 2131427343;
				accessibility_custom_action_15 = 2131427344;
				accessibility_custom_action_16 = 2131427345;
				accessibility_custom_action_17 = 2131427346;
				accessibility_custom_action_18 = 2131427347;
				accessibility_custom_action_19 = 2131427348;
				accessibility_custom_action_2 = 2131427349;
				accessibility_custom_action_20 = 2131427350;
				accessibility_custom_action_21 = 2131427351;
				accessibility_custom_action_22 = 2131427352;
				accessibility_custom_action_23 = 2131427353;
				accessibility_custom_action_24 = 2131427354;
				accessibility_custom_action_25 = 2131427355;
				accessibility_custom_action_26 = 2131427356;
				accessibility_custom_action_27 = 2131427357;
				accessibility_custom_action_28 = 2131427358;
				accessibility_custom_action_29 = 2131427359;
				accessibility_custom_action_3 = 2131427360;
				accessibility_custom_action_30 = 2131427361;
				accessibility_custom_action_31 = 2131427362;
				accessibility_custom_action_4 = 2131427363;
				accessibility_custom_action_5 = 2131427364;
				accessibility_custom_action_6 = 2131427365;
				accessibility_custom_action_7 = 2131427366;
				accessibility_custom_action_8 = 2131427367;
				accessibility_custom_action_9 = 2131427368;
				action0 = 2131427369;
				actions = 2131427387;
				action_bar = 2131427370;
				action_bar_activity_content = 2131427371;
				action_bar_container = 2131427372;
				action_bar_root = 2131427373;
				action_bar_spinner = 2131427374;
				action_bar_subtitle = 2131427375;
				action_bar_title = 2131427376;
				action_container = 2131427377;
				action_context_bar = 2131427378;
				action_divider = 2131427379;
				action_image = 2131427380;
				action_menu_divider = 2131427381;
				action_menu_presenter = 2131427382;
				action_mode_bar = 2131427383;
				action_mode_bar_stub = 2131427384;
				action_mode_close_button = 2131427385;
				action_text = 2131427386;
				activity_chooser_view_content = 2131427388;
				add = 2131427389;
				adjust_height = 2131427390;
				adjust_width = 2131427391;
				alertTitle = 2131427392;
				all = 2131427393;
				ALT = 2131427328;
				always = 2131427394;
				androidx_window_activity_scope = 2131427395;
				async = 2131427396;
				auto = 2131427397;
				automatic = 2131427398;
				beginning = 2131427399;
				blocking = 2131427400;
				bottom = 2131427401;
				box_count = 2131427402;
				browser_actions_header_text = 2131427403;
				browser_actions_menu_items = 2131427406;
				browser_actions_menu_item_icon = 2131427404;
				browser_actions_menu_item_text = 2131427405;
				browser_actions_menu_view = 2131427407;
				button = 2131427408;
				buttonPanel = 2131427409;
				cancel_action = 2131427410;
				cancel_button = 2131427411;
				center = 2131427412;
				center_horizontal = 2131427413;
				center_vertical = 2131427414;
				checkbox = 2131427415;
				@checked = 2131427416;
				chronometer = 2131427417;
				clip_horizontal = 2131427418;
				clip_vertical = 2131427419;
				closeButton = 2131427420;
				collapseActionView = 2131427421;
				com_facebook_body_frame = 2131427422;
				com_facebook_button_xout = 2131427423;
				com_facebook_device_auth_instructions = 2131427424;
				com_facebook_fragment_container = 2131427425;
				com_facebook_login_fragment_progress_bar = 2131427426;
				com_facebook_smart_instructions_0 = 2131427427;
				com_facebook_smart_instructions_or = 2131427428;
				com_facebook_tooltip_bubble_view_bottom_pointer = 2131427429;
				com_facebook_tooltip_bubble_view_text_body = 2131427430;
				com_facebook_tooltip_bubble_view_top_pointer = 2131427431;
				confirmation_code = 2131427432;
				container = 2131427433;
				content = 2131427434;
				contentPanel = 2131427435;
				coordinator = 2131427436;
				CTRL = 2131427329;
				custom = 2131427437;
				customPanel = 2131427438;
				dark = 2131427439;
				dashboard_content_container = 2131427440;
				dashboard_manual_label = 2131427441;
				dashboard_start_label = 2131427442;
				dashboard_tile_background = 2131427443;
				dashboard_tile_calorie_icon = 2131427444;
				dashboard_tile_calorie_unit = 2131427445;
				dashboard_tile_calorie_value = 2131427446;
				dashboard_tile_distance_icon = 2131427447;
				dashboard_tile_distance_unit = 2131427448;
				dashboard_tile_distance_value = 2131427449;
				dashboard_tile_metrics = 2131427450;
				dashboard_tile_nonpremium_overlay = 2131427451;
				dashboard_tile_start_button = 2131427452;
				dashboard_tile_time_icon = 2131427453;
				dashboard_tile_time_value = 2131427454;
				dashboard_tile_title = 2131427455;
				dashboard_tile_type = 2131427456;
				dashboard_time_container = 2131427457;
				decor_content_parent = 2131427458;
				default_activity_button = 2131427459;
				design_bottom_sheet = 2131427460;
				design_menu_item_action_area = 2131427461;
				design_menu_item_action_area_stub = 2131427462;
				design_menu_item_text = 2131427463;
				design_navigation_view = 2131427464;
				dialogCancelButton = 2131427465;
				dialogTitle = 2131427466;
				dialogWebView = 2131427467;
				dialog_button = 2131427468;
				disableHome = 2131427469;
				display_always = 2131427470;
				edit_query = 2131427471;
				end = 2131427472;
				end_padder = 2131427473;
				enterAlways = 2131427474;
				enterAlwaysCollapsed = 2131427475;
				exitUntilCollapsed = 2131427476;
				exo_ad_overlay = 2131427477;
				exo_artwork = 2131427478;
				exo_audio_track = 2131427479;
				exo_basic_controls = 2131427480;
				exo_bottom_bar = 2131427481;
				exo_buffering = 2131427482;
				exo_center_controls = 2131427483;
				exo_check = 2131427484;
				exo_content_frame = 2131427485;
				exo_controller = 2131427486;
				exo_controller_placeholder = 2131427487;
				exo_controls_background = 2131427488;
				exo_duration = 2131427489;
				exo_error_message = 2131427490;
				exo_extra_controls = 2131427491;
				exo_extra_controls_scroll_view = 2131427492;
				exo_ffwd = 2131427493;
				exo_ffwd_with_amount = 2131427494;
				exo_fullscreen = 2131427495;
				exo_icon = 2131427496;
				exo_main_text = 2131427497;
				exo_minimal_controls = 2131427498;
				exo_minimal_fullscreen = 2131427499;
				exo_next = 2131427500;
				exo_overflow_hide = 2131427501;
				exo_overflow_show = 2131427502;
				exo_overlay = 2131427503;
				exo_pause = 2131427504;
				exo_play = 2131427505;
				exo_playback_speed = 2131427507;
				exo_play_pause = 2131427506;
				exo_position = 2131427508;
				exo_prev = 2131427509;
				exo_progress = 2131427510;
				exo_progress_placeholder = 2131427511;
				exo_repeat_toggle = 2131427512;
				exo_rew = 2131427513;
				exo_rew_with_amount = 2131427514;
				exo_settings = 2131427515;
				exo_settings_listview = 2131427516;
				exo_shuffle = 2131427517;
				exo_shutter = 2131427518;
				exo_subtitle = 2131427520;
				exo_subtitles = 2131427521;
				exo_sub_text = 2131427519;
				exo_text = 2131427522;
				exo_time = 2131427523;
				exo_track_selection_view = 2131427524;
				exo_vr = 2131427525;
				expanded_menu = 2131427527;
				expand_activities_button = 2131427526;
				favorites_tile_background = 2131427528;
				favorites_tile_description = 2131427529;
				favorites_tile_nonpremium_overlay = 2131427530;
				favorites_tile_title = 2131427531;
				fill = 2131427532;
				filled = 2131427535;
				fill_horizontal = 2131427533;
				fill_vertical = 2131427534;
				fit = 2131427536;
				@fixed = 2131427537;
				fixed_height = 2131427538;
				fixed_width = 2131427539;
				forever = 2131427540;
				FUNCTION = 2131427330;
				georgia_regular = 2131427541;
				ghost_view = 2131427542;
				ghost_view_holder = 2131427543;
				group_divider = 2131427544;
				hardware = 2131427545;
				home = 2131427546;
				homeAsUp = 2131427547;
				hybrid = 2131427548;
				icon = 2131427549;
				icon_group = 2131427550;
				icon_only = 2131427551;
				ifRoom = 2131427552;
				image = 2131427553;
				info = 2131427554;
				inline = 2131427555;
				italic = 2131427556;
				item_touch_helper_previous_elevation = 2131427557;
				labeled = 2131427558;
				large = 2131427559;
				largeLabel = 2131427560;
				league_gothic_regular = 2131427561;
				left = 2131427562;
				library_tile_background = 2131427563;
				library_tile_description = 2131427564;
				library_tile_nonpremium_overlay = 2131427565;
				library_tile_title = 2131427566;
				light = 2131427567;
				line1 = 2131427568;
				line3 = 2131427569;
				listMode = 2131427570;
				list_item = 2131427571;
				locale = 2131427572;
				log_screen_share_button = 2131427573;
				lottie_layer_name = 2131427574;
				ltr = 2131427575;
				manual_text_container = 2131427576;
				map_fragment = 2131427577;
				map_tile_background = 2131427578;
				map_tile_description = 2131427579;
				map_tile_start_button = 2131427580;
				map_tile_title = 2131427581;
				martines10 = 2131427582;
				martines11 = 2131427583;
				masked = 2131427584;
				media_actions = 2131427585;
				media_controller_compat_view_tag = 2131427586;
				message = 2131427587;
				messenger_send_button = 2131427588;
				META = 2131427331;
				middle = 2131427589;
				mini = 2131427590;
				mtrl_child_content_container = 2131427591;
				mtrl_internal_children_alpha_tag = 2131427592;
				multiply = 2131427593;
				MvvmCrossTagId = 2131427332;
				MvxBindingTagUnique = 2131427333;
				navigation_header_container = 2131427594;
				never = 2131427595;
				never_display = 2131427596;
				none = 2131427597;
				normal = 2131427598;
				notification_background = 2131427599;
				notification_main_column = 2131427600;
				notification_main_column_container = 2131427601;
				off = 2131427602;
				on = 2131427603;
				one = 2131427604;
				open_graph = 2131427605;
				outline = 2131427606;
				page = 2131427607;
				parallax = 2131427608;
				parentPanel = 2131427609;
				parent_matrix = 2131427610;
				pin = 2131427611;
				progress_bar = 2131427612;
				progress_circular = 2131427613;
				progress_horizontal = 2131427614;
				proxima_black = 2131427615;
				proxima_bold = 2131427616;
				proxima_extraBold = 2131427617;
				proxima_light = 2131427618;
				proxima_lightItalic = 2131427619;
				proxima_regular = 2131427620;
				proxima_regularItalic = 2131427621;
				proxima_semiBold = 2131427622;
				proxima_semiBoldItalic = 2131427623;
				proxima_thin = 2131427624;
				radio = 2131427625;
				rating_layout = 2131427626;
				restart = 2131427627;
				reverse = 2131427628;
				right = 2131427629;
				right_icon = 2131427630;
				right_side = 2131427631;
				roboto_regular = 2131427632;
				rtl = 2131427633;
				satellite = 2131427634;
				save_non_transition_alpha = 2131427635;
				save_overlay_view = 2131427636;
				screen = 2131427637;
				scroll = 2131427638;
				scrollable = 2131427642;
				scrollIndicatorDown = 2131427639;
				scrollIndicatorUp = 2131427640;
				scrollView = 2131427641;
				search_badge = 2131427643;
				search_bar = 2131427644;
				search_button = 2131427645;
				search_close_btn = 2131427646;
				search_edit_frame = 2131427647;
				search_go_btn = 2131427648;
				search_mag_icon = 2131427649;
				search_plate = 2131427650;
				search_src_text = 2131427651;
				search_voice_btn = 2131427652;
				selected = 2131427654;
				select_dialog_listview = 2131427653;
				shareAnchor = 2131427655;
				shareContainer = 2131427656;
				shareFacebookButton = 2131427657;
				shareTwitterButton = 2131427658;
				SHIFT = 2131427334;
				shortcut = 2131427659;
				showCustom = 2131427660;
				showHome = 2131427661;
				showTitle = 2131427662;
				small = 2131427663;
				smallLabel = 2131427664;
				snackbar_action = 2131427665;
				snackbar_text = 2131427666;
				snap = 2131427667;
				snapMargins = 2131427668;
				software = 2131427669;
				spacer = 2131427670;
				spherical_gl_surface_view = 2131427671;
				split_action_bar = 2131427672;
				src_atop = 2131427673;
				src_in = 2131427674;
				src_over = 2131427675;
				standard = 2131427676;
				start = 2131427677;
				status_bar_latest_event_content = 2131427678;
				stretch = 2131427679;
				submenuarrow = 2131427680;
				submit_area = 2131427681;
				surface_view = 2131427682;
				SYM = 2131427335;
				tabMode = 2131427683;
				tag_accessibility_actions = 2131427684;
				tag_accessibility_clickable_spans = 2131427685;
				tag_accessibility_heading = 2131427686;
				tag_accessibility_pane_title = 2131427687;
				tag_on_apply_window_listener = 2131427688;
				tag_on_receive_content_listener = 2131427689;
				tag_on_receive_content_mime_types = 2131427690;
				tag_screen_reader_focusable = 2131427691;
				tag_state_description = 2131427692;
				tag_transition_group = 2131427693;
				tag_unhandled_key_event_manager = 2131427694;
				tag_unhandled_key_listeners = 2131427695;
				tag_window_insets_animation_callback = 2131427696;
				terrain = 2131427697;
				text = 2131427698;
				text2 = 2131427699;
				textinput_counter = 2131427704;
				textinput_error = 2131427705;
				textinput_helper_text = 2131427706;
				textSpacerNoButtons = 2131427700;
				textSpacerNoTitle = 2131427701;
				textStart = 2131427702;
				texture_view = 2131427707;
				text_input_password_toggle = 2131427703;
				time = 2131427708;
				title = 2131427709;
				titleDividerNoCustom = 2131427710;
				title_template = 2131427711;
				top = 2131427712;
				topPanel = 2131427713;
				touch_outside = 2131427714;
				transition_current_scene = 2131427715;
				transition_layout_save = 2131427716;
				transition_position = 2131427717;
				transition_scene_layoutid_cache = 2131427718;
				transition_transform = 2131427719;
				twitterCancelButton = 2131427720;
				twitterDialogTitle = 2131427721;
				twitterWebView = 2131427722;
				@unchecked = 2131427723;
				uniform = 2131427724;
				unknown = 2131427725;
				unlabeled = 2131427726;
				up = 2131427727;
				useLogo = 2131427728;
				video_decoder_gl_surface_view = 2131427729;
				view_offset_helper = 2131427730;
				view_tree_lifecycle_owner = 2131427731;
				view_tree_saved_state_registry_owner = 2131427732;
				view_tree_view_model_store_owner = 2131427733;
				visible = 2131427734;
				when_playing = 2131427735;
				wide = 2131427736;
				withText = 2131427737;
				workout_rating_label = 2131427738;
				wrap_content = 2131427739;
				zoom = 2131427740;
				ResourceIdManager.UpdateIdValues();
			}

			private Id()
			{
			}
		}

		public class Integer
		{
			public static int abc_config_activityDefaultDur;

			public static int abc_config_activityShortDur;

			public static int app_bar_elevation_anim_duration;

			public static int bottom_sheet_slide_duration;

			public static int cancel_button_image_alpha;

			public static int config_tooltipAnimTime;

			public static int design_snackbar_text_max_lines;

			public static int design_tab_indicator_anim_duration_ms;

			public static int exo_media_button_opacity_percentage_disabled;

			public static int exo_media_button_opacity_percentage_enabled;

			public static int google_play_services_version;

			public static int hide_password_duration;

			public static int loading_animation_segment_duration;

			public static int loading_animation_segment_gap_duration;

			public static int mtrl_btn_anim_delay_ms;

			public static int mtrl_btn_anim_duration_ms;

			public static int mtrl_chip_anim_duration;

			public static int mtrl_tab_indicator_anim_duration_ms;

			public static int show_password_duration;

			public static int status_bar_notification_info_maxnum;

			static Integer()
			{
				abc_config_activityDefaultDur = 2131492864;
				abc_config_activityShortDur = 2131492865;
				app_bar_elevation_anim_duration = 2131492866;
				bottom_sheet_slide_duration = 2131492867;
				cancel_button_image_alpha = 2131492868;
				config_tooltipAnimTime = 2131492869;
				design_snackbar_text_max_lines = 2131492870;
				design_tab_indicator_anim_duration_ms = 2131492871;
				exo_media_button_opacity_percentage_disabled = 2131492872;
				exo_media_button_opacity_percentage_enabled = 2131492873;
				google_play_services_version = 2131492874;
				hide_password_duration = 2131492875;
				loading_animation_segment_duration = 2131492876;
				loading_animation_segment_gap_duration = 2131492877;
				mtrl_btn_anim_delay_ms = 2131492878;
				mtrl_btn_anim_duration_ms = 2131492879;
				mtrl_chip_anim_duration = 2131492880;
				mtrl_tab_indicator_anim_duration_ms = 2131492881;
				show_password_duration = 2131492882;
				status_bar_notification_info_maxnum = 2131492883;
				ResourceIdManager.UpdateIdValues();
			}

			private Integer()
			{
			}
		}

		public class Interpolator
		{
			public static int btn_checkbox_checked_mtrl_animation_interpolator_0;

			public static int btn_checkbox_checked_mtrl_animation_interpolator_1;

			public static int btn_checkbox_unchecked_mtrl_animation_interpolator_0;

			public static int btn_checkbox_unchecked_mtrl_animation_interpolator_1;

			public static int btn_radio_to_off_mtrl_animation_interpolator_0;

			public static int btn_radio_to_on_mtrl_animation_interpolator_0;

			public static int fast_out_slow_in;

			public static int mtrl_fast_out_linear_in;

			public static int mtrl_fast_out_slow_in;

			public static int mtrl_linear;

			public static int mtrl_linear_out_slow_in;

			static Interpolator()
			{
				btn_checkbox_checked_mtrl_animation_interpolator_0 = 2131558400;
				btn_checkbox_checked_mtrl_animation_interpolator_1 = 2131558401;
				btn_checkbox_unchecked_mtrl_animation_interpolator_0 = 2131558402;
				btn_checkbox_unchecked_mtrl_animation_interpolator_1 = 2131558403;
				btn_radio_to_off_mtrl_animation_interpolator_0 = 2131558404;
				btn_radio_to_on_mtrl_animation_interpolator_0 = 2131558405;
				fast_out_slow_in = 2131558406;
				mtrl_fast_out_linear_in = 2131558407;
				mtrl_fast_out_slow_in = 2131558408;
				mtrl_linear = 2131558409;
				mtrl_linear_out_slow_in = 2131558410;
				ResourceIdManager.UpdateIdValues();
			}

			private Interpolator()
			{
			}
		}

		public class Layout
		{
			public static int abc_action_bar_title_item;

			public static int abc_action_bar_up_container;

			public static int abc_action_menu_item_layout;

			public static int abc_action_menu_layout;

			public static int abc_action_mode_bar;

			public static int abc_action_mode_close_item_material;

			public static int abc_activity_chooser_view;

			public static int abc_activity_chooser_view_list_item;

			public static int abc_alert_dialog_button_bar_material;

			public static int abc_alert_dialog_material;

			public static int abc_alert_dialog_title_material;

			public static int abc_cascading_menu_item_layout;

			public static int abc_dialog_title_material;

			public static int abc_expanded_menu_layout;

			public static int abc_list_menu_item_checkbox;

			public static int abc_list_menu_item_icon;

			public static int abc_list_menu_item_layout;

			public static int abc_list_menu_item_radio;

			public static int abc_popup_menu_header_item_layout;

			public static int abc_popup_menu_item_layout;

			public static int abc_screen_content_include;

			public static int abc_screen_simple;

			public static int abc_screen_simple_overlay_action_mode;

			public static int abc_screen_toolbar;

			public static int abc_search_dropdown_item_icons_2line;

			public static int abc_search_view;

			public static int abc_select_dialog_material;

			public static int abc_tooltip;

			public static int browser_actions_context_menu_page;

			public static int browser_actions_context_menu_row;

			public static int component_dashboard_tile_metrics;

			public static int com_facebook_activity_layout;

			public static int com_facebook_device_auth_dialog_fragment;

			public static int com_facebook_login_fragment;

			public static int com_facebook_smart_device_dialog_fragment;

			public static int com_facebook_tooltip_bubble;

			public static int custom_dialog;

			public static int DashboardTile;

			public static int design_bottom_navigation_item;

			public static int design_bottom_sheet_dialog;

			public static int design_layout_snackbar;

			public static int design_layout_snackbar_include;

			public static int design_layout_tab_icon;

			public static int design_layout_tab_text;

			public static int design_menu_item_action_area;

			public static int design_navigation_item;

			public static int design_navigation_item_header;

			public static int design_navigation_item_separator;

			public static int design_navigation_item_subheader;

			public static int design_navigation_menu;

			public static int design_navigation_menu_item;

			public static int design_text_input_password_icon;

			public static int exo_list_divider;

			public static int exo_player_control_view;

			public static int exo_player_view;

			public static int exo_styled_player_control_ffwd_button;

			public static int exo_styled_player_control_rewind_button;

			public static int exo_styled_player_control_view;

			public static int exo_styled_player_view;

			public static int exo_styled_settings_list;

			public static int exo_styled_settings_list_item;

			public static int exo_styled_sub_settings_list_item;

			public static int exo_track_selection_dialog;

			public static int FavoritesTile;

			public static int LibraryTile;

			public static int ManualWorkoutTile;

			public static int MapTile;

			public static int MapViewControl;

			public static int messenger_button_send_blue_large;

			public static int messenger_button_send_blue_round;

			public static int messenger_button_send_blue_small;

			public static int messenger_button_send_white_large;

			public static int messenger_button_send_white_round;

			public static int messenger_button_send_white_small;

			public static int mtrl_layout_snackbar;

			public static int mtrl_layout_snackbar_include;

			public static int notification_action;

			public static int notification_action_tombstone;

			public static int notification_media_action;

			public static int notification_media_cancel_action;

			public static int notification_template_big_media;

			public static int notification_template_big_media_custom;

			public static int notification_template_big_media_narrow;

			public static int notification_template_big_media_narrow_custom;

			public static int notification_template_custom_big;

			public static int notification_template_icon_group;

			public static int notification_template_lines_media;

			public static int notification_template_media;

			public static int notification_template_media_custom;

			public static int notification_template_part_chronometer;

			public static int notification_template_part_time;

			public static int RatingControl;

			public static int select_dialog_item_material;

			public static int select_dialog_multichoice_material;

			public static int select_dialog_singlechoice_material;

			public static int ShareWorkout;

			public static int support_simple_spinner_dropdown_item;

			public static int TwitterDialog;

			public static int WebViewDialog;

			static Layout()
			{
				abc_action_bar_title_item = 2131623936;
				abc_action_bar_up_container = 2131623937;
				abc_action_menu_item_layout = 2131623938;
				abc_action_menu_layout = 2131623939;
				abc_action_mode_bar = 2131623940;
				abc_action_mode_close_item_material = 2131623941;
				abc_activity_chooser_view = 2131623942;
				abc_activity_chooser_view_list_item = 2131623943;
				abc_alert_dialog_button_bar_material = 2131623944;
				abc_alert_dialog_material = 2131623945;
				abc_alert_dialog_title_material = 2131623946;
				abc_cascading_menu_item_layout = 2131623947;
				abc_dialog_title_material = 2131623948;
				abc_expanded_menu_layout = 2131623949;
				abc_list_menu_item_checkbox = 2131623950;
				abc_list_menu_item_icon = 2131623951;
				abc_list_menu_item_layout = 2131623952;
				abc_list_menu_item_radio = 2131623953;
				abc_popup_menu_header_item_layout = 2131623954;
				abc_popup_menu_item_layout = 2131623955;
				abc_screen_content_include = 2131623956;
				abc_screen_simple = 2131623957;
				abc_screen_simple_overlay_action_mode = 2131623958;
				abc_screen_toolbar = 2131623959;
				abc_search_dropdown_item_icons_2line = 2131623960;
				abc_search_view = 2131623961;
				abc_select_dialog_material = 2131623962;
				abc_tooltip = 2131623963;
				browser_actions_context_menu_page = 2131623964;
				browser_actions_context_menu_row = 2131623965;
				component_dashboard_tile_metrics = 2131623971;
				com_facebook_activity_layout = 2131623966;
				com_facebook_device_auth_dialog_fragment = 2131623967;
				com_facebook_login_fragment = 2131623968;
				com_facebook_smart_device_dialog_fragment = 2131623969;
				com_facebook_tooltip_bubble = 2131623970;
				custom_dialog = 2131623972;
				DashboardTile = 2131623973;
				design_bottom_navigation_item = 2131623974;
				design_bottom_sheet_dialog = 2131623975;
				design_layout_snackbar = 2131623976;
				design_layout_snackbar_include = 2131623977;
				design_layout_tab_icon = 2131623978;
				design_layout_tab_text = 2131623979;
				design_menu_item_action_area = 2131623980;
				design_navigation_item = 2131623981;
				design_navigation_item_header = 2131623982;
				design_navigation_item_separator = 2131623983;
				design_navigation_item_subheader = 2131623984;
				design_navigation_menu = 2131623985;
				design_navigation_menu_item = 2131623986;
				design_text_input_password_icon = 2131623987;
				exo_list_divider = 2131623988;
				exo_player_control_view = 2131623989;
				exo_player_view = 2131623990;
				exo_styled_player_control_ffwd_button = 2131623991;
				exo_styled_player_control_rewind_button = 2131623992;
				exo_styled_player_control_view = 2131623993;
				exo_styled_player_view = 2131623994;
				exo_styled_settings_list = 2131623995;
				exo_styled_settings_list_item = 2131623996;
				exo_styled_sub_settings_list_item = 2131623997;
				exo_track_selection_dialog = 2131623998;
				FavoritesTile = 2131623999;
				LibraryTile = 2131624000;
				ManualWorkoutTile = 2131624001;
				MapTile = 2131624002;
				MapViewControl = 2131624003;
				messenger_button_send_blue_large = 2131624004;
				messenger_button_send_blue_round = 2131624005;
				messenger_button_send_blue_small = 2131624006;
				messenger_button_send_white_large = 2131624007;
				messenger_button_send_white_round = 2131624008;
				messenger_button_send_white_small = 2131624009;
				mtrl_layout_snackbar = 2131624010;
				mtrl_layout_snackbar_include = 2131624011;
				notification_action = 2131624012;
				notification_action_tombstone = 2131624013;
				notification_media_action = 2131624014;
				notification_media_cancel_action = 2131624015;
				notification_template_big_media = 2131624016;
				notification_template_big_media_custom = 2131624017;
				notification_template_big_media_narrow = 2131624018;
				notification_template_big_media_narrow_custom = 2131624019;
				notification_template_custom_big = 2131624020;
				notification_template_icon_group = 2131624021;
				notification_template_lines_media = 2131624022;
				notification_template_media = 2131624023;
				notification_template_media_custom = 2131624024;
				notification_template_part_chronometer = 2131624025;
				notification_template_part_time = 2131624026;
				RatingControl = 2131624027;
				select_dialog_item_material = 2131624028;
				select_dialog_multichoice_material = 2131624029;
				select_dialog_singlechoice_material = 2131624030;
				ShareWorkout = 2131624031;
				support_simple_spinner_dropdown_item = 2131624032;
				TwitterDialog = 2131624033;
				WebViewDialog = 2131624034;
				ResourceIdManager.UpdateIdValues();
			}

			private Layout()
			{
			}
		}

		public class Raw
		{
			public static int firebase_common_keep;

			public static int georgia_regular;

			public static int keep_cronet_api;

			public static int league_gothic_regular;

			public static int martines10;

			public static int martines11;

			public static int proxima_black;

			public static int proxima_bold;

			public static int proxima_extra_bold;

			public static int proxima_light;

			public static int proxima_light_italic;

			public static int proxima_regular;

			public static int proxima_regular_italic;

			public static int proxima_semibold;

			public static int proxima_semibold_italic;

			public static int proxima_thin;

			public static int roboto_regular;

			static Raw()
			{
				firebase_common_keep = 2131755008;
				georgia_regular = 2131755009;
				keep_cronet_api = 2131755010;
				league_gothic_regular = 2131755011;
				martines10 = 2131755012;
				martines11 = 2131755013;
				proxima_black = 2131755014;
				proxima_bold = 2131755015;
				proxima_extra_bold = 2131755016;
				proxima_light = 2131755017;
				proxima_light_italic = 2131755018;
				proxima_regular = 2131755019;
				proxima_regular_italic = 2131755020;
				proxima_semibold = 2131755021;
				proxima_semibold_italic = 2131755022;
				proxima_thin = 2131755023;
				roboto_regular = 2131755024;
				ResourceIdManager.UpdateIdValues();
			}

			private Raw()
			{
			}
		}

		public class Plurals
		{
			public static int exo_controls_fastforward_by_amount_description;

			public static int exo_controls_rewind_by_amount_description;

			static Plurals()
			{
				exo_controls_fastforward_by_amount_description = 2131689472;
				exo_controls_rewind_by_amount_description = 2131689473;
				ResourceIdManager.UpdateIdValues();
			}

			private Plurals()
			{
			}
		}

		public class String
		{
			public static int abc_action_bar_home_description;

			public static int abc_action_bar_up_description;

			public static int abc_action_menu_overflow_description;

			public static int abc_action_mode_done;

			public static int abc_activitychooserview_choose_application;

			public static int abc_activity_chooser_view_see_all;

			public static int abc_capital_off;

			public static int abc_capital_on;

			public static int abc_menu_alt_shortcut_label;

			public static int abc_menu_ctrl_shortcut_label;

			public static int abc_menu_delete_shortcut_label;

			public static int abc_menu_enter_shortcut_label;

			public static int abc_menu_function_shortcut_label;

			public static int abc_menu_meta_shortcut_label;

			public static int abc_menu_shift_shortcut_label;

			public static int abc_menu_space_shortcut_label;

			public static int abc_menu_sym_shortcut_label;

			public static int abc_prepend_shortcut_label;

			public static int abc_searchview_description_clear;

			public static int abc_searchview_description_query;

			public static int abc_searchview_description_search;

			public static int abc_searchview_description_submit;

			public static int abc_searchview_description_voice;

			public static int abc_search_hint;

			public static int abc_shareactionprovider_share_with;

			public static int abc_shareactionprovider_share_with_application;

			public static int abc_toolbar_collapse_description;

			public static int appbar_scrolling_view_behavior;

			public static int ApplicationName;

			public static int app_name;

			public static int bottom_sheet_behavior;

			public static int character_counter_content_description;

			public static int character_counter_pattern;

			public static int common_google_play_services_enable_button;

			public static int common_google_play_services_enable_text;

			public static int common_google_play_services_enable_title;

			public static int common_google_play_services_install_button;

			public static int common_google_play_services_install_text;

			public static int common_google_play_services_install_title;

			public static int common_google_play_services_notification_channel_name;

			public static int common_google_play_services_notification_ticker;

			public static int common_google_play_services_unknown_issue;

			public static int common_google_play_services_unsupported_text;

			public static int common_google_play_services_update_button;

			public static int common_google_play_services_update_text;

			public static int common_google_play_services_update_title;

			public static int common_google_play_services_updating_text;

			public static int common_google_play_services_wear_update_text;

			public static int common_open_on_phone;

			public static int common_signin_button_text;

			public static int common_signin_button_text_long;

			public static int com_facebook_device_auth_instructions;

			public static int com_facebook_image_download_unknown_error;

			public static int com_facebook_internet_permission_error_message;

			public static int com_facebook_internet_permission_error_title;

			public static int com_facebook_like_button_liked;

			public static int com_facebook_like_button_not_liked;

			public static int com_facebook_loading;

			public static int com_facebook_loginview_cancel_action;

			public static int com_facebook_loginview_logged_in_as;

			public static int com_facebook_loginview_logged_in_using_facebook;

			public static int com_facebook_loginview_log_in_button;

			public static int com_facebook_loginview_log_in_button_continue;

			public static int com_facebook_loginview_log_in_button_long;

			public static int com_facebook_loginview_log_out_action;

			public static int com_facebook_loginview_log_out_button;

			public static int com_facebook_send_button_text;

			public static int com_facebook_share_button_text;

			public static int com_facebook_smart_device_instructions;

			public static int com_facebook_smart_device_instructions_or;

			public static int com_facebook_smart_login_confirmation_cancel;

			public static int com_facebook_smart_login_confirmation_continue_as;

			public static int com_facebook_smart_login_confirmation_title;

			public static int com_facebook_tooltip_default;

			public static int copy_toast_msg;

			public static int CronetProviderClassName;

			public static int dfu_action_abort;

			public static int dfu_channel_description;

			public static int dfu_channel_name;

			public static int dfu_status_aborted;

			public static int dfu_status_aborted_msg;

			public static int dfu_status_aborting;

			public static int dfu_status_completed;

			public static int dfu_status_completed_msg;

			public static int dfu_status_connecting;

			public static int dfu_status_connecting_msg;

			public static int dfu_status_disconnecting;

			public static int dfu_status_disconnecting_msg;

			public static int dfu_status_error;

			public static int dfu_status_error_msg;

			public static int dfu_status_foreground_content;

			public static int dfu_status_foreground_title;

			public static int dfu_status_initializing;

			public static int dfu_status_starting;

			public static int dfu_status_starting_msg;

			public static int dfu_status_switching_to_dfu;

			public static int dfu_status_switching_to_dfu_msg;

			public static int dfu_status_uploading;

			public static int dfu_status_uploading_msg;

			public static int dfu_status_uploading_part;

			public static int dfu_status_validating;

			public static int dfu_status_validating_msg;

			public static int dfu_unknown_name;

			public static int exo_controls_cc_disabled_description;

			public static int exo_controls_cc_enabled_description;

			public static int exo_controls_custom_playback_speed;

			public static int exo_controls_fastforward_description;

			public static int exo_controls_fullscreen_enter_description;

			public static int exo_controls_fullscreen_exit_description;

			public static int exo_controls_hide;

			public static int exo_controls_next_description;

			public static int exo_controls_overflow_hide_description;

			public static int exo_controls_overflow_show_description;

			public static int exo_controls_pause_description;

			public static int exo_controls_playback_speed;

			public static int exo_controls_playback_speed_normal;

			public static int exo_controls_play_description;

			public static int exo_controls_previous_description;

			public static int exo_controls_repeat_all_description;

			public static int exo_controls_repeat_off_description;

			public static int exo_controls_repeat_one_description;

			public static int exo_controls_rewind_description;

			public static int exo_controls_seek_bar_description;

			public static int exo_controls_settings_description;

			public static int exo_controls_show;

			public static int exo_controls_shuffle_off_description;

			public static int exo_controls_shuffle_on_description;

			public static int exo_controls_stop_description;

			public static int exo_controls_time_placeholder;

			public static int exo_controls_vr_description;

			public static int exo_download_completed;

			public static int exo_download_description;

			public static int exo_download_downloading;

			public static int exo_download_failed;

			public static int exo_download_notification_channel_name;

			public static int exo_download_removing;

			public static int exo_item_list;

			public static int exo_track_bitrate;

			public static int exo_track_mono;

			public static int exo_track_resolution;

			public static int exo_track_role_alternate;

			public static int exo_track_role_closed_captions;

			public static int exo_track_role_commentary;

			public static int exo_track_role_supplementary;

			public static int exo_track_selection_auto;

			public static int exo_track_selection_none;

			public static int exo_track_selection_title_audio;

			public static int exo_track_selection_title_text;

			public static int exo_track_selection_title_video;

			public static int exo_track_stereo;

			public static int exo_track_surround;

			public static int exo_track_surround_5_point_1;

			public static int exo_track_surround_7_point_1;

			public static int exo_track_unknown;

			public static int fab_transformation_scrim_behavior;

			public static int fab_transformation_sheet_behavior;

			public static int fallback_menu_item_copy_link;

			public static int fallback_menu_item_open_in_browser;

			public static int fallback_menu_item_share_link;

			public static int hello;

			public static int Hello;

			public static int hide_bottom_view_on_scroll_behavior;

			public static int library_name;

			public static int messenger_send_button_text;

			public static int mtrl_chip_close_icon_content_description;

			public static int password_toggle_content_description;

			public static int path_password_eye;

			public static int path_password_eye_mask_strike_through;

			public static int path_password_eye_mask_visible;

			public static int path_password_strike_through;

			public static int search_menu_title;

			public static int status_bar_notification_info_overflow;

			static String()
			{
				abc_action_bar_home_description = 2131820547;
				abc_action_bar_up_description = 2131820548;
				abc_action_menu_overflow_description = 2131820549;
				abc_action_mode_done = 2131820550;
				abc_activitychooserview_choose_application = 2131820552;
				abc_activity_chooser_view_see_all = 2131820551;
				abc_capital_off = 2131820553;
				abc_capital_on = 2131820554;
				abc_menu_alt_shortcut_label = 2131820555;
				abc_menu_ctrl_shortcut_label = 2131820556;
				abc_menu_delete_shortcut_label = 2131820557;
				abc_menu_enter_shortcut_label = 2131820558;
				abc_menu_function_shortcut_label = 2131820559;
				abc_menu_meta_shortcut_label = 2131820560;
				abc_menu_shift_shortcut_label = 2131820561;
				abc_menu_space_shortcut_label = 2131820562;
				abc_menu_sym_shortcut_label = 2131820563;
				abc_prepend_shortcut_label = 2131820564;
				abc_searchview_description_clear = 2131820566;
				abc_searchview_description_query = 2131820567;
				abc_searchview_description_search = 2131820568;
				abc_searchview_description_submit = 2131820569;
				abc_searchview_description_voice = 2131820570;
				abc_search_hint = 2131820565;
				abc_shareactionprovider_share_with = 2131820571;
				abc_shareactionprovider_share_with_application = 2131820572;
				abc_toolbar_collapse_description = 2131820573;
				appbar_scrolling_view_behavior = 2131820575;
				ApplicationName = 2131820544;
				app_name = 2131820574;
				bottom_sheet_behavior = 2131820576;
				character_counter_content_description = 2131820577;
				character_counter_pattern = 2131820578;
				common_google_play_services_enable_button = 2131820602;
				common_google_play_services_enable_text = 2131820603;
				common_google_play_services_enable_title = 2131820604;
				common_google_play_services_install_button = 2131820605;
				common_google_play_services_install_text = 2131820606;
				common_google_play_services_install_title = 2131820607;
				common_google_play_services_notification_channel_name = 2131820608;
				common_google_play_services_notification_ticker = 2131820609;
				common_google_play_services_unknown_issue = 2131820610;
				common_google_play_services_unsupported_text = 2131820611;
				common_google_play_services_update_button = 2131820612;
				common_google_play_services_update_text = 2131820613;
				common_google_play_services_update_title = 2131820614;
				common_google_play_services_updating_text = 2131820615;
				common_google_play_services_wear_update_text = 2131820616;
				common_open_on_phone = 2131820617;
				common_signin_button_text = 2131820618;
				common_signin_button_text_long = 2131820619;
				com_facebook_device_auth_instructions = 2131820579;
				com_facebook_image_download_unknown_error = 2131820580;
				com_facebook_internet_permission_error_message = 2131820581;
				com_facebook_internet_permission_error_title = 2131820582;
				com_facebook_like_button_liked = 2131820583;
				com_facebook_like_button_not_liked = 2131820584;
				com_facebook_loading = 2131820585;
				com_facebook_loginview_cancel_action = 2131820586;
				com_facebook_loginview_logged_in_as = 2131820592;
				com_facebook_loginview_logged_in_using_facebook = 2131820593;
				com_facebook_loginview_log_in_button = 2131820587;
				com_facebook_loginview_log_in_button_continue = 2131820588;
				com_facebook_loginview_log_in_button_long = 2131820589;
				com_facebook_loginview_log_out_action = 2131820590;
				com_facebook_loginview_log_out_button = 2131820591;
				com_facebook_send_button_text = 2131820594;
				com_facebook_share_button_text = 2131820595;
				com_facebook_smart_device_instructions = 2131820596;
				com_facebook_smart_device_instructions_or = 2131820597;
				com_facebook_smart_login_confirmation_cancel = 2131820598;
				com_facebook_smart_login_confirmation_continue_as = 2131820599;
				com_facebook_smart_login_confirmation_title = 2131820600;
				com_facebook_tooltip_default = 2131820601;
				copy_toast_msg = 2131820620;
				CronetProviderClassName = 2131820545;
				dfu_action_abort = 2131820621;
				dfu_channel_description = 2131820622;
				dfu_channel_name = 2131820623;
				dfu_status_aborted = 2131820624;
				dfu_status_aborted_msg = 2131820625;
				dfu_status_aborting = 2131820626;
				dfu_status_completed = 2131820627;
				dfu_status_completed_msg = 2131820628;
				dfu_status_connecting = 2131820629;
				dfu_status_connecting_msg = 2131820630;
				dfu_status_disconnecting = 2131820631;
				dfu_status_disconnecting_msg = 2131820632;
				dfu_status_error = 2131820633;
				dfu_status_error_msg = 2131820634;
				dfu_status_foreground_content = 2131820635;
				dfu_status_foreground_title = 2131820636;
				dfu_status_initializing = 2131820637;
				dfu_status_starting = 2131820638;
				dfu_status_starting_msg = 2131820639;
				dfu_status_switching_to_dfu = 2131820640;
				dfu_status_switching_to_dfu_msg = 2131820641;
				dfu_status_uploading = 2131820642;
				dfu_status_uploading_msg = 2131820643;
				dfu_status_uploading_part = 2131820644;
				dfu_status_validating = 2131820645;
				dfu_status_validating_msg = 2131820646;
				dfu_unknown_name = 2131820647;
				exo_controls_cc_disabled_description = 2131820648;
				exo_controls_cc_enabled_description = 2131820649;
				exo_controls_custom_playback_speed = 2131820650;
				exo_controls_fastforward_description = 2131820651;
				exo_controls_fullscreen_enter_description = 2131820652;
				exo_controls_fullscreen_exit_description = 2131820653;
				exo_controls_hide = 2131820654;
				exo_controls_next_description = 2131820655;
				exo_controls_overflow_hide_description = 2131820656;
				exo_controls_overflow_show_description = 2131820657;
				exo_controls_pause_description = 2131820658;
				exo_controls_playback_speed = 2131820660;
				exo_controls_playback_speed_normal = 2131820661;
				exo_controls_play_description = 2131820659;
				exo_controls_previous_description = 2131820662;
				exo_controls_repeat_all_description = 2131820663;
				exo_controls_repeat_off_description = 2131820664;
				exo_controls_repeat_one_description = 2131820665;
				exo_controls_rewind_description = 2131820666;
				exo_controls_seek_bar_description = 2131820667;
				exo_controls_settings_description = 2131820668;
				exo_controls_show = 2131820669;
				exo_controls_shuffle_off_description = 2131820670;
				exo_controls_shuffle_on_description = 2131820671;
				exo_controls_stop_description = 2131820672;
				exo_controls_time_placeholder = 2131820673;
				exo_controls_vr_description = 2131820674;
				exo_download_completed = 2131820675;
				exo_download_description = 2131820676;
				exo_download_downloading = 2131820677;
				exo_download_failed = 2131820678;
				exo_download_notification_channel_name = 2131820679;
				exo_download_removing = 2131820680;
				exo_item_list = 2131820681;
				exo_track_bitrate = 2131820682;
				exo_track_mono = 2131820683;
				exo_track_resolution = 2131820684;
				exo_track_role_alternate = 2131820685;
				exo_track_role_closed_captions = 2131820686;
				exo_track_role_commentary = 2131820687;
				exo_track_role_supplementary = 2131820688;
				exo_track_selection_auto = 2131820689;
				exo_track_selection_none = 2131820690;
				exo_track_selection_title_audio = 2131820691;
				exo_track_selection_title_text = 2131820692;
				exo_track_selection_title_video = 2131820693;
				exo_track_stereo = 2131820694;
				exo_track_surround = 2131820695;
				exo_track_surround_5_point_1 = 2131820696;
				exo_track_surround_7_point_1 = 2131820697;
				exo_track_unknown = 2131820698;
				fab_transformation_scrim_behavior = 2131820699;
				fab_transformation_sheet_behavior = 2131820700;
				fallback_menu_item_copy_link = 2131820701;
				fallback_menu_item_open_in_browser = 2131820702;
				fallback_menu_item_share_link = 2131820703;
				hello = 2131820704;
				Hello = 2131820546;
				hide_bottom_view_on_scroll_behavior = 2131820705;
				library_name = 2131820706;
				messenger_send_button_text = 2131820707;
				mtrl_chip_close_icon_content_description = 2131820708;
				password_toggle_content_description = 2131820709;
				path_password_eye = 2131820710;
				path_password_eye_mask_strike_through = 2131820711;
				path_password_eye_mask_visible = 2131820712;
				path_password_strike_through = 2131820713;
				search_menu_title = 2131820714;
				status_bar_notification_info_overflow = 2131820715;
				ResourceIdManager.UpdateIdValues();
			}

			private String()
			{
			}
		}

		public class Style
		{
			public static int AlertDialog_AppCompat;

			public static int AlertDialog_AppCompat_Light;

			public static int Animation_AppCompat_Dialog;

			public static int Animation_AppCompat_DropDownUp;

			public static int Animation_AppCompat_Tooltip;

			public static int Animation_Design_BottomSheetDialog;

			public static int Base_AlertDialog_AppCompat;

			public static int Base_AlertDialog_AppCompat_Light;

			public static int Base_Animation_AppCompat_Dialog;

			public static int Base_Animation_AppCompat_DropDownUp;

			public static int Base_Animation_AppCompat_Tooltip;

			public static int Base_CardView;

			public static int Base_DialogWindowTitleBackground_AppCompat;

			public static int Base_DialogWindowTitle_AppCompat;

			public static int Base_TextAppearance_AppCompat;

			public static int Base_TextAppearance_AppCompat_Body1;

			public static int Base_TextAppearance_AppCompat_Body2;

			public static int Base_TextAppearance_AppCompat_Button;

			public static int Base_TextAppearance_AppCompat_Caption;

			public static int Base_TextAppearance_AppCompat_Display1;

			public static int Base_TextAppearance_AppCompat_Display2;

			public static int Base_TextAppearance_AppCompat_Display3;

			public static int Base_TextAppearance_AppCompat_Display4;

			public static int Base_TextAppearance_AppCompat_Headline;

			public static int Base_TextAppearance_AppCompat_Inverse;

			public static int Base_TextAppearance_AppCompat_Large;

			public static int Base_TextAppearance_AppCompat_Large_Inverse;

			public static int Base_TextAppearance_AppCompat_Light_Widget_PopupMenu_Large;

			public static int Base_TextAppearance_AppCompat_Light_Widget_PopupMenu_Small;

			public static int Base_TextAppearance_AppCompat_Medium;

			public static int Base_TextAppearance_AppCompat_Medium_Inverse;

			public static int Base_TextAppearance_AppCompat_Menu;

			public static int Base_TextAppearance_AppCompat_SearchResult;

			public static int Base_TextAppearance_AppCompat_SearchResult_Subtitle;

			public static int Base_TextAppearance_AppCompat_SearchResult_Title;

			public static int Base_TextAppearance_AppCompat_Small;

			public static int Base_TextAppearance_AppCompat_Small_Inverse;

			public static int Base_TextAppearance_AppCompat_Subhead;

			public static int Base_TextAppearance_AppCompat_Subhead_Inverse;

			public static int Base_TextAppearance_AppCompat_Title;

			public static int Base_TextAppearance_AppCompat_Title_Inverse;

			public static int Base_TextAppearance_AppCompat_Tooltip;

			public static int Base_TextAppearance_AppCompat_Widget_ActionBar_Menu;

			public static int Base_TextAppearance_AppCompat_Widget_ActionBar_Subtitle;

			public static int Base_TextAppearance_AppCompat_Widget_ActionBar_Subtitle_Inverse;

			public static int Base_TextAppearance_AppCompat_Widget_ActionBar_Title;

			public static int Base_TextAppearance_AppCompat_Widget_ActionBar_Title_Inverse;

			public static int Base_TextAppearance_AppCompat_Widget_ActionMode_Subtitle;

			public static int Base_TextAppearance_AppCompat_Widget_ActionMode_Title;

			public static int Base_TextAppearance_AppCompat_Widget_Button;

			public static int Base_TextAppearance_AppCompat_Widget_Button_Borderless_Colored;

			public static int Base_TextAppearance_AppCompat_Widget_Button_Colored;

			public static int Base_TextAppearance_AppCompat_Widget_Button_Inverse;

			public static int Base_TextAppearance_AppCompat_Widget_DropDownItem;

			public static int Base_TextAppearance_AppCompat_Widget_PopupMenu_Header;

			public static int Base_TextAppearance_AppCompat_Widget_PopupMenu_Large;

			public static int Base_TextAppearance_AppCompat_Widget_PopupMenu_Small;

			public static int Base_TextAppearance_AppCompat_Widget_Switch;

			public static int Base_TextAppearance_AppCompat_Widget_TextView_SpinnerItem;

			public static int Base_TextAppearance_Widget_AppCompat_ExpandedMenu_Item;

			public static int Base_TextAppearance_Widget_AppCompat_Toolbar_Subtitle;

			public static int Base_TextAppearance_Widget_AppCompat_Toolbar_Title;

			public static int Base_ThemeOverlay_AppCompat;

			public static int Base_ThemeOverlay_AppCompat_ActionBar;

			public static int Base_ThemeOverlay_AppCompat_Dark;

			public static int Base_ThemeOverlay_AppCompat_Dark_ActionBar;

			public static int Base_ThemeOverlay_AppCompat_Dialog;

			public static int Base_ThemeOverlay_AppCompat_Dialog_Alert;

			public static int Base_ThemeOverlay_AppCompat_Light;

			public static int Base_ThemeOverlay_MaterialComponents_Dialog;

			public static int Base_ThemeOverlay_MaterialComponents_Dialog_Alert;

			public static int Base_Theme_AppCompat;

			public static int Base_Theme_AppCompat_CompactMenu;

			public static int Base_Theme_AppCompat_Dialog;

			public static int Base_Theme_AppCompat_DialogWhenLarge;

			public static int Base_Theme_AppCompat_Dialog_Alert;

			public static int Base_Theme_AppCompat_Dialog_FixedSize;

			public static int Base_Theme_AppCompat_Dialog_MinWidth;

			public static int Base_Theme_AppCompat_Light;

			public static int Base_Theme_AppCompat_Light_DarkActionBar;

			public static int Base_Theme_AppCompat_Light_Dialog;

			public static int Base_Theme_AppCompat_Light_DialogWhenLarge;

			public static int Base_Theme_AppCompat_Light_Dialog_Alert;

			public static int Base_Theme_AppCompat_Light_Dialog_FixedSize;

			public static int Base_Theme_AppCompat_Light_Dialog_MinWidth;

			public static int Base_Theme_MaterialComponents;

			public static int Base_Theme_MaterialComponents_Bridge;

			public static int Base_Theme_MaterialComponents_CompactMenu;

			public static int Base_Theme_MaterialComponents_Dialog;

			public static int Base_Theme_MaterialComponents_DialogWhenLarge;

			public static int Base_Theme_MaterialComponents_Dialog_Alert;

			public static int Base_Theme_MaterialComponents_Dialog_FixedSize;

			public static int Base_Theme_MaterialComponents_Dialog_MinWidth;

			public static int Base_Theme_MaterialComponents_Light;

			public static int Base_Theme_MaterialComponents_Light_Bridge;

			public static int Base_Theme_MaterialComponents_Light_DarkActionBar;

			public static int Base_Theme_MaterialComponents_Light_DarkActionBar_Bridge;

			public static int Base_Theme_MaterialComponents_Light_Dialog;

			public static int Base_Theme_MaterialComponents_Light_DialogWhenLarge;

			public static int Base_Theme_MaterialComponents_Light_Dialog_Alert;

			public static int Base_Theme_MaterialComponents_Light_Dialog_FixedSize;

			public static int Base_Theme_MaterialComponents_Light_Dialog_MinWidth;

			public static int Base_V14_ThemeOverlay_MaterialComponents_Dialog;

			public static int Base_V14_ThemeOverlay_MaterialComponents_Dialog_Alert;

			public static int Base_V14_Theme_MaterialComponents;

			public static int Base_V14_Theme_MaterialComponents_Bridge;

			public static int Base_V14_Theme_MaterialComponents_Dialog;

			public static int Base_V14_Theme_MaterialComponents_Light;

			public static int Base_V14_Theme_MaterialComponents_Light_Bridge;

			public static int Base_V14_Theme_MaterialComponents_Light_DarkActionBar_Bridge;

			public static int Base_V14_Theme_MaterialComponents_Light_Dialog;

			public static int Base_V21_ThemeOverlay_AppCompat_Dialog;

			public static int Base_V21_Theme_AppCompat;

			public static int Base_V21_Theme_AppCompat_Dialog;

			public static int Base_V21_Theme_AppCompat_Light;

			public static int Base_V21_Theme_AppCompat_Light_Dialog;

			public static int Base_V22_Theme_AppCompat;

			public static int Base_V22_Theme_AppCompat_Light;

			public static int Base_V23_Theme_AppCompat;

			public static int Base_V23_Theme_AppCompat_Light;

			public static int Base_V26_Theme_AppCompat;

			public static int Base_V26_Theme_AppCompat_Light;

			public static int Base_V26_Widget_AppCompat_Toolbar;

			public static int Base_V28_Theme_AppCompat;

			public static int Base_V28_Theme_AppCompat_Light;

			public static int Base_V7_ThemeOverlay_AppCompat_Dialog;

			public static int Base_V7_Theme_AppCompat;

			public static int Base_V7_Theme_AppCompat_Dialog;

			public static int Base_V7_Theme_AppCompat_Light;

			public static int Base_V7_Theme_AppCompat_Light_Dialog;

			public static int Base_V7_Widget_AppCompat_AutoCompleteTextView;

			public static int Base_V7_Widget_AppCompat_EditText;

			public static int Base_V7_Widget_AppCompat_Toolbar;

			public static int Base_Widget_AppCompat_ActionBar;

			public static int Base_Widget_AppCompat_ActionBar_Solid;

			public static int Base_Widget_AppCompat_ActionBar_TabBar;

			public static int Base_Widget_AppCompat_ActionBar_TabText;

			public static int Base_Widget_AppCompat_ActionBar_TabView;

			public static int Base_Widget_AppCompat_ActionButton;

			public static int Base_Widget_AppCompat_ActionButton_CloseMode;

			public static int Base_Widget_AppCompat_ActionButton_Overflow;

			public static int Base_Widget_AppCompat_ActionMode;

			public static int Base_Widget_AppCompat_ActivityChooserView;

			public static int Base_Widget_AppCompat_AutoCompleteTextView;

			public static int Base_Widget_AppCompat_Button;

			public static int Base_Widget_AppCompat_ButtonBar;

			public static int Base_Widget_AppCompat_ButtonBar_AlertDialog;

			public static int Base_Widget_AppCompat_Button_Borderless;

			public static int Base_Widget_AppCompat_Button_Borderless_Colored;

			public static int Base_Widget_AppCompat_Button_ButtonBar_AlertDialog;

			public static int Base_Widget_AppCompat_Button_Colored;

			public static int Base_Widget_AppCompat_Button_Small;

			public static int Base_Widget_AppCompat_CompoundButton_CheckBox;

			public static int Base_Widget_AppCompat_CompoundButton_RadioButton;

			public static int Base_Widget_AppCompat_CompoundButton_Switch;

			public static int Base_Widget_AppCompat_DrawerArrowToggle;

			public static int Base_Widget_AppCompat_DrawerArrowToggle_Common;

			public static int Base_Widget_AppCompat_DropDownItem_Spinner;

			public static int Base_Widget_AppCompat_EditText;

			public static int Base_Widget_AppCompat_ImageButton;

			public static int Base_Widget_AppCompat_Light_ActionBar;

			public static int Base_Widget_AppCompat_Light_ActionBar_Solid;

			public static int Base_Widget_AppCompat_Light_ActionBar_TabBar;

			public static int Base_Widget_AppCompat_Light_ActionBar_TabText;

			public static int Base_Widget_AppCompat_Light_ActionBar_TabText_Inverse;

			public static int Base_Widget_AppCompat_Light_ActionBar_TabView;

			public static int Base_Widget_AppCompat_Light_PopupMenu;

			public static int Base_Widget_AppCompat_Light_PopupMenu_Overflow;

			public static int Base_Widget_AppCompat_ListMenuView;

			public static int Base_Widget_AppCompat_ListPopupWindow;

			public static int Base_Widget_AppCompat_ListView;

			public static int Base_Widget_AppCompat_ListView_DropDown;

			public static int Base_Widget_AppCompat_ListView_Menu;

			public static int Base_Widget_AppCompat_PopupMenu;

			public static int Base_Widget_AppCompat_PopupMenu_Overflow;

			public static int Base_Widget_AppCompat_PopupWindow;

			public static int Base_Widget_AppCompat_ProgressBar;

			public static int Base_Widget_AppCompat_ProgressBar_Horizontal;

			public static int Base_Widget_AppCompat_RatingBar;

			public static int Base_Widget_AppCompat_RatingBar_Indicator;

			public static int Base_Widget_AppCompat_RatingBar_Small;

			public static int Base_Widget_AppCompat_SearchView;

			public static int Base_Widget_AppCompat_SearchView_ActionBar;

			public static int Base_Widget_AppCompat_SeekBar;

			public static int Base_Widget_AppCompat_SeekBar_Discrete;

			public static int Base_Widget_AppCompat_Spinner;

			public static int Base_Widget_AppCompat_Spinner_Underlined;

			public static int Base_Widget_AppCompat_TextView;

			public static int Base_Widget_AppCompat_TextView_SpinnerItem;

			public static int Base_Widget_AppCompat_Toolbar;

			public static int Base_Widget_AppCompat_Toolbar_Button_Navigation;

			public static int Base_Widget_Design_TabLayout;

			public static int Base_Widget_MaterialComponents_Chip;

			public static int Base_Widget_MaterialComponents_TextInputEditText;

			public static int Base_Widget_MaterialComponents_TextInputLayout;

			public static int CardView;

			public static int CardView_Dark;

			public static int CardView_Light;

			public static int com_facebook_activity_theme;

			public static int com_facebook_auth_dialog;

			public static int com_facebook_auth_dialog_instructions_textview;

			public static int com_facebook_button;

			public static int com_facebook_button_like;

			public static int com_facebook_button_send;

			public static int com_facebook_button_share;

			public static int com_facebook_loginview_default_style;

			public static int DashboardMetricIcon;

			public static int DashboardMetricUnitText;

			public static int DashboardMetricValueText;

			public static int DashboardTileStartButton;

			public static int ExoMediaButton;

			public static int ExoMediaButton_FastForward;

			public static int ExoMediaButton_Next;

			public static int ExoMediaButton_Pause;

			public static int ExoMediaButton_Play;

			public static int ExoMediaButton_Previous;

			public static int ExoMediaButton_Rewind;

			public static int ExoMediaButton_VR;

			public static int ExoStyledControls;

			public static int ExoStyledControls_Button;

			public static int ExoStyledControls_ButtonText;

			public static int ExoStyledControls_Button_Bottom;

			public static int ExoStyledControls_Button_Bottom_AudioTrack;

			public static int ExoStyledControls_Button_Bottom_CC;

			public static int ExoStyledControls_Button_Bottom_FullScreen;

			public static int ExoStyledControls_Button_Bottom_OverflowHide;

			public static int ExoStyledControls_Button_Bottom_OverflowShow;

			public static int ExoStyledControls_Button_Bottom_PlaybackSpeed;

			public static int ExoStyledControls_Button_Bottom_RepeatToggle;

			public static int ExoStyledControls_Button_Bottom_Settings;

			public static int ExoStyledControls_Button_Bottom_Shuffle;

			public static int ExoStyledControls_Button_Bottom_VR;

			public static int ExoStyledControls_Button_Center;

			public static int ExoStyledControls_Button_Center_FfwdWithAmount;

			public static int ExoStyledControls_Button_Center_Next;

			public static int ExoStyledControls_Button_Center_PlayPause;

			public static int ExoStyledControls_Button_Center_Previous;

			public static int ExoStyledControls_Button_Center_RewWithAmount;

			public static int ExoStyledControls_TimeBar;

			public static int ExoStyledControls_TimeText;

			public static int ExoStyledControls_TimeText_Duration;

			public static int ExoStyledControls_TimeText_Position;

			public static int ExoStyledControls_TimeText_Separator;

			public static int FavoritesTileDescription;

			public static int FavoritesTileTitle;

			public static int LibraryTileDescription;

			public static int LibraryTileTitle;

			public static int MapTileDescription;

			public static int MapTileStartButton;

			public static int MapTileTitle;

			public static int MessengerButton;

			public static int MessengerButtonText;

			public static int MessengerButtonText_Blue;

			public static int MessengerButtonText_Blue_Large;

			public static int MessengerButtonText_Blue_Small;

			public static int MessengerButtonText_White;

			public static int MessengerButtonText_White_Large;

			public static int MessengerButtonText_White_Small;

			public static int MessengerButton_Blue;

			public static int MessengerButton_Blue_Large;

			public static int MessengerButton_Blue_Small;

			public static int MessengerButton_White;

			public static int MessengerButton_White_Large;

			public static int MessengerButton_White_Small;

			public static int Platform_AppCompat;

			public static int Platform_AppCompat_Light;

			public static int Platform_MaterialComponents;

			public static int Platform_MaterialComponents_Dialog;

			public static int Platform_MaterialComponents_Light;

			public static int Platform_MaterialComponents_Light_Dialog;

			public static int Platform_ThemeOverlay_AppCompat;

			public static int Platform_ThemeOverlay_AppCompat_Dark;

			public static int Platform_ThemeOverlay_AppCompat_Light;

			public static int Platform_V21_AppCompat;

			public static int Platform_V21_AppCompat_Light;

			public static int Platform_V25_AppCompat;

			public static int Platform_V25_AppCompat_Light;

			public static int Platform_Widget_AppCompat_Spinner;

			public static int RtlOverlay_DialogWindowTitle_AppCompat;

			public static int RtlOverlay_Widget_AppCompat_ActionBar_TitleItem;

			public static int RtlOverlay_Widget_AppCompat_DialogTitle_Icon;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem_InternalGroup;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem_Shortcut;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem_SubmenuArrow;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem_Text;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem_Title;

			public static int RtlOverlay_Widget_AppCompat_SearchView_MagIcon;

			public static int RtlOverlay_Widget_AppCompat_Search_DropDown;

			public static int RtlOverlay_Widget_AppCompat_Search_DropDown_Icon1;

			public static int RtlOverlay_Widget_AppCompat_Search_DropDown_Icon2;

			public static int RtlOverlay_Widget_AppCompat_Search_DropDown_Query;

			public static int RtlOverlay_Widget_AppCompat_Search_DropDown_Text;

			public static int RtlUnderlay_Widget_AppCompat_ActionButton;

			public static int RtlUnderlay_Widget_AppCompat_ActionButton_Overflow;

			public static int TextAppearance_AppCompat;

			public static int TextAppearance_AppCompat_Body1;

			public static int TextAppearance_AppCompat_Body2;

			public static int TextAppearance_AppCompat_Button;

			public static int TextAppearance_AppCompat_Caption;

			public static int TextAppearance_AppCompat_Display1;

			public static int TextAppearance_AppCompat_Display2;

			public static int TextAppearance_AppCompat_Display3;

			public static int TextAppearance_AppCompat_Display4;

			public static int TextAppearance_AppCompat_Headline;

			public static int TextAppearance_AppCompat_Inverse;

			public static int TextAppearance_AppCompat_Large;

			public static int TextAppearance_AppCompat_Large_Inverse;

			public static int TextAppearance_AppCompat_Light_SearchResult_Subtitle;

			public static int TextAppearance_AppCompat_Light_SearchResult_Title;

			public static int TextAppearance_AppCompat_Light_Widget_PopupMenu_Large;

			public static int TextAppearance_AppCompat_Light_Widget_PopupMenu_Small;

			public static int TextAppearance_AppCompat_Medium;

			public static int TextAppearance_AppCompat_Medium_Inverse;

			public static int TextAppearance_AppCompat_Menu;

			public static int TextAppearance_AppCompat_SearchResult_Subtitle;

			public static int TextAppearance_AppCompat_SearchResult_Title;

			public static int TextAppearance_AppCompat_Small;

			public static int TextAppearance_AppCompat_Small_Inverse;

			public static int TextAppearance_AppCompat_Subhead;

			public static int TextAppearance_AppCompat_Subhead_Inverse;

			public static int TextAppearance_AppCompat_Title;

			public static int TextAppearance_AppCompat_Title_Inverse;

			public static int TextAppearance_AppCompat_Tooltip;

			public static int TextAppearance_AppCompat_Widget_ActionBar_Menu;

			public static int TextAppearance_AppCompat_Widget_ActionBar_Subtitle;

			public static int TextAppearance_AppCompat_Widget_ActionBar_Subtitle_Inverse;

			public static int TextAppearance_AppCompat_Widget_ActionBar_Title;

			public static int TextAppearance_AppCompat_Widget_ActionBar_Title_Inverse;

			public static int TextAppearance_AppCompat_Widget_ActionMode_Subtitle;

			public static int TextAppearance_AppCompat_Widget_ActionMode_Subtitle_Inverse;

			public static int TextAppearance_AppCompat_Widget_ActionMode_Title;

			public static int TextAppearance_AppCompat_Widget_ActionMode_Title_Inverse;

			public static int TextAppearance_AppCompat_Widget_Button;

			public static int TextAppearance_AppCompat_Widget_Button_Borderless_Colored;

			public static int TextAppearance_AppCompat_Widget_Button_Colored;

			public static int TextAppearance_AppCompat_Widget_Button_Inverse;

			public static int TextAppearance_AppCompat_Widget_DropDownItem;

			public static int TextAppearance_AppCompat_Widget_PopupMenu_Header;

			public static int TextAppearance_AppCompat_Widget_PopupMenu_Large;

			public static int TextAppearance_AppCompat_Widget_PopupMenu_Small;

			public static int TextAppearance_AppCompat_Widget_Switch;

			public static int TextAppearance_AppCompat_Widget_TextView_SpinnerItem;

			public static int TextAppearance_Compat_Notification;

			public static int TextAppearance_Compat_Notification_Info;

			public static int TextAppearance_Compat_Notification_Info_Media;

			public static int TextAppearance_Compat_Notification_Line2;

			public static int TextAppearance_Compat_Notification_Line2_Media;

			public static int TextAppearance_Compat_Notification_Media;

			public static int TextAppearance_Compat_Notification_Time;

			public static int TextAppearance_Compat_Notification_Time_Media;

			public static int TextAppearance_Compat_Notification_Title;

			public static int TextAppearance_Compat_Notification_Title_Media;

			public static int TextAppearance_Design_CollapsingToolbar_Expanded;

			public static int TextAppearance_Design_Counter;

			public static int TextAppearance_Design_Counter_Overflow;

			public static int TextAppearance_Design_Error;

			public static int TextAppearance_Design_HelperText;

			public static int TextAppearance_Design_Hint;

			public static int TextAppearance_Design_Snackbar_Message;

			public static int TextAppearance_Design_Tab;

			public static int TextAppearance_MaterialComponents_Body1;

			public static int TextAppearance_MaterialComponents_Body2;

			public static int TextAppearance_MaterialComponents_Button;

			public static int TextAppearance_MaterialComponents_Caption;

			public static int TextAppearance_MaterialComponents_Chip;

			public static int TextAppearance_MaterialComponents_Headline1;

			public static int TextAppearance_MaterialComponents_Headline2;

			public static int TextAppearance_MaterialComponents_Headline3;

			public static int TextAppearance_MaterialComponents_Headline4;

			public static int TextAppearance_MaterialComponents_Headline5;

			public static int TextAppearance_MaterialComponents_Headline6;

			public static int TextAppearance_MaterialComponents_Overline;

			public static int TextAppearance_MaterialComponents_Subtitle1;

			public static int TextAppearance_MaterialComponents_Subtitle2;

			public static int TextAppearance_MaterialComponents_Tab;

			public static int TextAppearance_Widget_AppCompat_ExpandedMenu_Item;

			public static int TextAppearance_Widget_AppCompat_Toolbar_Subtitle;

			public static int TextAppearance_Widget_AppCompat_Toolbar_Title;

			public static int ThemeOverlay_AppCompat;

			public static int ThemeOverlay_AppCompat_ActionBar;

			public static int ThemeOverlay_AppCompat_Dark;

			public static int ThemeOverlay_AppCompat_Dark_ActionBar;

			public static int ThemeOverlay_AppCompat_DayNight;

			public static int ThemeOverlay_AppCompat_DayNight_ActionBar;

			public static int ThemeOverlay_AppCompat_Dialog;

			public static int ThemeOverlay_AppCompat_Dialog_Alert;

			public static int ThemeOverlay_AppCompat_Light;

			public static int ThemeOverlay_MaterialComponents;

			public static int ThemeOverlay_MaterialComponents_ActionBar;

			public static int ThemeOverlay_MaterialComponents_Dark;

			public static int ThemeOverlay_MaterialComponents_Dark_ActionBar;

			public static int ThemeOverlay_MaterialComponents_Dialog;

			public static int ThemeOverlay_MaterialComponents_Dialog_Alert;

			public static int ThemeOverlay_MaterialComponents_Light;

			public static int ThemeOverlay_MaterialComponents_TextInputEditText;

			public static int ThemeOverlay_MaterialComponents_TextInputEditText_FilledBox;

			public static int ThemeOverlay_MaterialComponents_TextInputEditText_FilledBox_Dense;

			public static int ThemeOverlay_MaterialComponents_TextInputEditText_OutlinedBox;

			public static int ThemeOverlay_MaterialComponents_TextInputEditText_OutlinedBox_Dense;

			public static int Theme_AppCompat;

			public static int Theme_AppCompat_CompactMenu;

			public static int Theme_AppCompat_DayNight;

			public static int Theme_AppCompat_DayNight_DarkActionBar;

			public static int Theme_AppCompat_DayNight_Dialog;

			public static int Theme_AppCompat_DayNight_DialogWhenLarge;

			public static int Theme_AppCompat_DayNight_Dialog_Alert;

			public static int Theme_AppCompat_DayNight_Dialog_MinWidth;

			public static int Theme_AppCompat_DayNight_NoActionBar;

			public static int Theme_AppCompat_Dialog;

			public static int Theme_AppCompat_DialogWhenLarge;

			public static int Theme_AppCompat_Dialog_Alert;

			public static int Theme_AppCompat_Dialog_MinWidth;

			public static int Theme_AppCompat_Empty;

			public static int Theme_AppCompat_Light;

			public static int Theme_AppCompat_Light_DarkActionBar;

			public static int Theme_AppCompat_Light_Dialog;

			public static int Theme_AppCompat_Light_DialogWhenLarge;

			public static int Theme_AppCompat_Light_Dialog_Alert;

			public static int Theme_AppCompat_Light_Dialog_MinWidth;

			public static int Theme_AppCompat_Light_NoActionBar;

			public static int Theme_AppCompat_NoActionBar;

			public static int Theme_Design;

			public static int Theme_Design_BottomSheetDialog;

			public static int Theme_Design_Light;

			public static int Theme_Design_Light_BottomSheetDialog;

			public static int Theme_Design_Light_NoActionBar;

			public static int Theme_Design_NoActionBar;

			public static int Theme_MaterialComponents;

			public static int Theme_MaterialComponents_BottomSheetDialog;

			public static int Theme_MaterialComponents_Bridge;

			public static int Theme_MaterialComponents_CompactMenu;

			public static int Theme_MaterialComponents_Dialog;

			public static int Theme_MaterialComponents_DialogWhenLarge;

			public static int Theme_MaterialComponents_Dialog_Alert;

			public static int Theme_MaterialComponents_Dialog_MinWidth;

			public static int Theme_MaterialComponents_Light;

			public static int Theme_MaterialComponents_Light_BottomSheetDialog;

			public static int Theme_MaterialComponents_Light_Bridge;

			public static int Theme_MaterialComponents_Light_DarkActionBar;

			public static int Theme_MaterialComponents_Light_DarkActionBar_Bridge;

			public static int Theme_MaterialComponents_Light_Dialog;

			public static int Theme_MaterialComponents_Light_DialogWhenLarge;

			public static int Theme_MaterialComponents_Light_Dialog_Alert;

			public static int Theme_MaterialComponents_Light_Dialog_MinWidth;

			public static int Theme_MaterialComponents_Light_NoActionBar;

			public static int Theme_MaterialComponents_Light_NoActionBar_Bridge;

			public static int Theme_MaterialComponents_NoActionBar;

			public static int Theme_MaterialComponents_NoActionBar_Bridge;

			public static int tooltip_bubble_text;

			public static int Widget_AppCompat_ActionBar;

			public static int Widget_AppCompat_ActionBar_Solid;

			public static int Widget_AppCompat_ActionBar_TabBar;

			public static int Widget_AppCompat_ActionBar_TabText;

			public static int Widget_AppCompat_ActionBar_TabView;

			public static int Widget_AppCompat_ActionButton;

			public static int Widget_AppCompat_ActionButton_CloseMode;

			public static int Widget_AppCompat_ActionButton_Overflow;

			public static int Widget_AppCompat_ActionMode;

			public static int Widget_AppCompat_ActivityChooserView;

			public static int Widget_AppCompat_AutoCompleteTextView;

			public static int Widget_AppCompat_Button;

			public static int Widget_AppCompat_ButtonBar;

			public static int Widget_AppCompat_ButtonBar_AlertDialog;

			public static int Widget_AppCompat_Button_Borderless;

			public static int Widget_AppCompat_Button_Borderless_Colored;

			public static int Widget_AppCompat_Button_ButtonBar_AlertDialog;

			public static int Widget_AppCompat_Button_Colored;

			public static int Widget_AppCompat_Button_Small;

			public static int Widget_AppCompat_CompoundButton_CheckBox;

			public static int Widget_AppCompat_CompoundButton_RadioButton;

			public static int Widget_AppCompat_CompoundButton_Switch;

			public static int Widget_AppCompat_DrawerArrowToggle;

			public static int Widget_AppCompat_DropDownItem_Spinner;

			public static int Widget_AppCompat_EditText;

			public static int Widget_AppCompat_ImageButton;

			public static int Widget_AppCompat_Light_ActionBar;

			public static int Widget_AppCompat_Light_ActionBar_Solid;

			public static int Widget_AppCompat_Light_ActionBar_Solid_Inverse;

			public static int Widget_AppCompat_Light_ActionBar_TabBar;

			public static int Widget_AppCompat_Light_ActionBar_TabBar_Inverse;

			public static int Widget_AppCompat_Light_ActionBar_TabText;

			public static int Widget_AppCompat_Light_ActionBar_TabText_Inverse;

			public static int Widget_AppCompat_Light_ActionBar_TabView;

			public static int Widget_AppCompat_Light_ActionBar_TabView_Inverse;

			public static int Widget_AppCompat_Light_ActionButton;

			public static int Widget_AppCompat_Light_ActionButton_CloseMode;

			public static int Widget_AppCompat_Light_ActionButton_Overflow;

			public static int Widget_AppCompat_Light_ActionMode_Inverse;

			public static int Widget_AppCompat_Light_ActivityChooserView;

			public static int Widget_AppCompat_Light_AutoCompleteTextView;

			public static int Widget_AppCompat_Light_DropDownItem_Spinner;

			public static int Widget_AppCompat_Light_ListPopupWindow;

			public static int Widget_AppCompat_Light_ListView_DropDown;

			public static int Widget_AppCompat_Light_PopupMenu;

			public static int Widget_AppCompat_Light_PopupMenu_Overflow;

			public static int Widget_AppCompat_Light_SearchView;

			public static int Widget_AppCompat_Light_Spinner_DropDown_ActionBar;

			public static int Widget_AppCompat_ListMenuView;

			public static int Widget_AppCompat_ListPopupWindow;

			public static int Widget_AppCompat_ListView;

			public static int Widget_AppCompat_ListView_DropDown;

			public static int Widget_AppCompat_ListView_Menu;

			public static int Widget_AppCompat_PopupMenu;

			public static int Widget_AppCompat_PopupMenu_Overflow;

			public static int Widget_AppCompat_PopupWindow;

			public static int Widget_AppCompat_ProgressBar;

			public static int Widget_AppCompat_ProgressBar_Horizontal;

			public static int Widget_AppCompat_RatingBar;

			public static int Widget_AppCompat_RatingBar_Indicator;

			public static int Widget_AppCompat_RatingBar_Small;

			public static int Widget_AppCompat_SearchView;

			public static int Widget_AppCompat_SearchView_ActionBar;

			public static int Widget_AppCompat_SeekBar;

			public static int Widget_AppCompat_SeekBar_Discrete;

			public static int Widget_AppCompat_Spinner;

			public static int Widget_AppCompat_Spinner_DropDown;

			public static int Widget_AppCompat_Spinner_DropDown_ActionBar;

			public static int Widget_AppCompat_Spinner_Underlined;

			public static int Widget_AppCompat_TextView;

			public static int Widget_AppCompat_TextView_SpinnerItem;

			public static int Widget_AppCompat_Toolbar;

			public static int Widget_AppCompat_Toolbar_Button_Navigation;

			public static int Widget_Compat_NotificationActionContainer;

			public static int Widget_Compat_NotificationActionText;

			public static int Widget_Design_AppBarLayout;

			public static int Widget_Design_BottomNavigationView;

			public static int Widget_Design_BottomSheet_Modal;

			public static int Widget_Design_CollapsingToolbar;

			public static int Widget_Design_FloatingActionButton;

			public static int Widget_Design_NavigationView;

			public static int Widget_Design_ScrimInsetsFrameLayout;

			public static int Widget_Design_Snackbar;

			public static int Widget_Design_TabLayout;

			public static int Widget_Design_TextInputLayout;

			public static int Widget_MaterialComponents_BottomAppBar;

			public static int Widget_MaterialComponents_BottomAppBar_Colored;

			public static int Widget_MaterialComponents_BottomNavigationView;

			public static int Widget_MaterialComponents_BottomNavigationView_Colored;

			public static int Widget_MaterialComponents_BottomSheet_Modal;

			public static int Widget_MaterialComponents_Button;

			public static int Widget_MaterialComponents_Button_Icon;

			public static int Widget_MaterialComponents_Button_OutlinedButton;

			public static int Widget_MaterialComponents_Button_OutlinedButton_Icon;

			public static int Widget_MaterialComponents_Button_TextButton;

			public static int Widget_MaterialComponents_Button_TextButton_Dialog;

			public static int Widget_MaterialComponents_Button_TextButton_Dialog_Icon;

			public static int Widget_MaterialComponents_Button_TextButton_Icon;

			public static int Widget_MaterialComponents_Button_UnelevatedButton;

			public static int Widget_MaterialComponents_Button_UnelevatedButton_Icon;

			public static int Widget_MaterialComponents_CardView;

			public static int Widget_MaterialComponents_ChipGroup;

			public static int Widget_MaterialComponents_Chip_Action;

			public static int Widget_MaterialComponents_Chip_Choice;

			public static int Widget_MaterialComponents_Chip_Entry;

			public static int Widget_MaterialComponents_Chip_Filter;

			public static int Widget_MaterialComponents_FloatingActionButton;

			public static int Widget_MaterialComponents_NavigationView;

			public static int Widget_MaterialComponents_Snackbar;

			public static int Widget_MaterialComponents_Snackbar_FullWidth;

			public static int Widget_MaterialComponents_TabLayout;

			public static int Widget_MaterialComponents_TabLayout_Colored;

			public static int Widget_MaterialComponents_TextInputEditText_FilledBox;

			public static int Widget_MaterialComponents_TextInputEditText_FilledBox_Dense;

			public static int Widget_MaterialComponents_TextInputEditText_OutlinedBox;

			public static int Widget_MaterialComponents_TextInputEditText_OutlinedBox_Dense;

			public static int Widget_MaterialComponents_TextInputLayout_FilledBox;

			public static int Widget_MaterialComponents_TextInputLayout_FilledBox_Dense;

			public static int Widget_MaterialComponents_TextInputLayout_OutlinedBox;

			public static int Widget_MaterialComponents_TextInputLayout_OutlinedBox_Dense;

			public static int Widget_MaterialComponents_Toolbar;

			public static int Widget_Support_CoordinatorLayout;

			public static int WrappedLayout;

			static Style()
			{
				AlertDialog_AppCompat = 2131886080;
				AlertDialog_AppCompat_Light = 2131886081;
				Animation_AppCompat_Dialog = 2131886082;
				Animation_AppCompat_DropDownUp = 2131886083;
				Animation_AppCompat_Tooltip = 2131886084;
				Animation_Design_BottomSheetDialog = 2131886085;
				Base_AlertDialog_AppCompat = 2131886086;
				Base_AlertDialog_AppCompat_Light = 2131886087;
				Base_Animation_AppCompat_Dialog = 2131886088;
				Base_Animation_AppCompat_DropDownUp = 2131886089;
				Base_Animation_AppCompat_Tooltip = 2131886090;
				Base_CardView = 2131886091;
				Base_DialogWindowTitleBackground_AppCompat = 2131886093;
				Base_DialogWindowTitle_AppCompat = 2131886092;
				Base_TextAppearance_AppCompat = 2131886094;
				Base_TextAppearance_AppCompat_Body1 = 2131886095;
				Base_TextAppearance_AppCompat_Body2 = 2131886096;
				Base_TextAppearance_AppCompat_Button = 2131886097;
				Base_TextAppearance_AppCompat_Caption = 2131886098;
				Base_TextAppearance_AppCompat_Display1 = 2131886099;
				Base_TextAppearance_AppCompat_Display2 = 2131886100;
				Base_TextAppearance_AppCompat_Display3 = 2131886101;
				Base_TextAppearance_AppCompat_Display4 = 2131886102;
				Base_TextAppearance_AppCompat_Headline = 2131886103;
				Base_TextAppearance_AppCompat_Inverse = 2131886104;
				Base_TextAppearance_AppCompat_Large = 2131886105;
				Base_TextAppearance_AppCompat_Large_Inverse = 2131886106;
				Base_TextAppearance_AppCompat_Light_Widget_PopupMenu_Large = 2131886107;
				Base_TextAppearance_AppCompat_Light_Widget_PopupMenu_Small = 2131886108;
				Base_TextAppearance_AppCompat_Medium = 2131886109;
				Base_TextAppearance_AppCompat_Medium_Inverse = 2131886110;
				Base_TextAppearance_AppCompat_Menu = 2131886111;
				Base_TextAppearance_AppCompat_SearchResult = 2131886112;
				Base_TextAppearance_AppCompat_SearchResult_Subtitle = 2131886113;
				Base_TextAppearance_AppCompat_SearchResult_Title = 2131886114;
				Base_TextAppearance_AppCompat_Small = 2131886115;
				Base_TextAppearance_AppCompat_Small_Inverse = 2131886116;
				Base_TextAppearance_AppCompat_Subhead = 2131886117;
				Base_TextAppearance_AppCompat_Subhead_Inverse = 2131886118;
				Base_TextAppearance_AppCompat_Title = 2131886119;
				Base_TextAppearance_AppCompat_Title_Inverse = 2131886120;
				Base_TextAppearance_AppCompat_Tooltip = 2131886121;
				Base_TextAppearance_AppCompat_Widget_ActionBar_Menu = 2131886122;
				Base_TextAppearance_AppCompat_Widget_ActionBar_Subtitle = 2131886123;
				Base_TextAppearance_AppCompat_Widget_ActionBar_Subtitle_Inverse = 2131886124;
				Base_TextAppearance_AppCompat_Widget_ActionBar_Title = 2131886125;
				Base_TextAppearance_AppCompat_Widget_ActionBar_Title_Inverse = 2131886126;
				Base_TextAppearance_AppCompat_Widget_ActionMode_Subtitle = 2131886127;
				Base_TextAppearance_AppCompat_Widget_ActionMode_Title = 2131886128;
				Base_TextAppearance_AppCompat_Widget_Button = 2131886129;
				Base_TextAppearance_AppCompat_Widget_Button_Borderless_Colored = 2131886130;
				Base_TextAppearance_AppCompat_Widget_Button_Colored = 2131886131;
				Base_TextAppearance_AppCompat_Widget_Button_Inverse = 2131886132;
				Base_TextAppearance_AppCompat_Widget_DropDownItem = 2131886133;
				Base_TextAppearance_AppCompat_Widget_PopupMenu_Header = 2131886134;
				Base_TextAppearance_AppCompat_Widget_PopupMenu_Large = 2131886135;
				Base_TextAppearance_AppCompat_Widget_PopupMenu_Small = 2131886136;
				Base_TextAppearance_AppCompat_Widget_Switch = 2131886137;
				Base_TextAppearance_AppCompat_Widget_TextView_SpinnerItem = 2131886138;
				Base_TextAppearance_Widget_AppCompat_ExpandedMenu_Item = 2131886139;
				Base_TextAppearance_Widget_AppCompat_Toolbar_Subtitle = 2131886140;
				Base_TextAppearance_Widget_AppCompat_Toolbar_Title = 2131886141;
				Base_ThemeOverlay_AppCompat = 2131886173;
				Base_ThemeOverlay_AppCompat_ActionBar = 2131886174;
				Base_ThemeOverlay_AppCompat_Dark = 2131886175;
				Base_ThemeOverlay_AppCompat_Dark_ActionBar = 2131886176;
				Base_ThemeOverlay_AppCompat_Dialog = 2131886177;
				Base_ThemeOverlay_AppCompat_Dialog_Alert = 2131886178;
				Base_ThemeOverlay_AppCompat_Light = 2131886179;
				Base_ThemeOverlay_MaterialComponents_Dialog = 2131886180;
				Base_ThemeOverlay_MaterialComponents_Dialog_Alert = 2131886181;
				Base_Theme_AppCompat = 2131886142;
				Base_Theme_AppCompat_CompactMenu = 2131886143;
				Base_Theme_AppCompat_Dialog = 2131886144;
				Base_Theme_AppCompat_DialogWhenLarge = 2131886148;
				Base_Theme_AppCompat_Dialog_Alert = 2131886145;
				Base_Theme_AppCompat_Dialog_FixedSize = 2131886146;
				Base_Theme_AppCompat_Dialog_MinWidth = 2131886147;
				Base_Theme_AppCompat_Light = 2131886149;
				Base_Theme_AppCompat_Light_DarkActionBar = 2131886150;
				Base_Theme_AppCompat_Light_Dialog = 2131886151;
				Base_Theme_AppCompat_Light_DialogWhenLarge = 2131886155;
				Base_Theme_AppCompat_Light_Dialog_Alert = 2131886152;
				Base_Theme_AppCompat_Light_Dialog_FixedSize = 2131886153;
				Base_Theme_AppCompat_Light_Dialog_MinWidth = 2131886154;
				Base_Theme_MaterialComponents = 2131886156;
				Base_Theme_MaterialComponents_Bridge = 2131886157;
				Base_Theme_MaterialComponents_CompactMenu = 2131886158;
				Base_Theme_MaterialComponents_Dialog = 2131886159;
				Base_Theme_MaterialComponents_DialogWhenLarge = 2131886163;
				Base_Theme_MaterialComponents_Dialog_Alert = 2131886160;
				Base_Theme_MaterialComponents_Dialog_FixedSize = 2131886161;
				Base_Theme_MaterialComponents_Dialog_MinWidth = 2131886162;
				Base_Theme_MaterialComponents_Light = 2131886164;
				Base_Theme_MaterialComponents_Light_Bridge = 2131886165;
				Base_Theme_MaterialComponents_Light_DarkActionBar = 2131886166;
				Base_Theme_MaterialComponents_Light_DarkActionBar_Bridge = 2131886167;
				Base_Theme_MaterialComponents_Light_Dialog = 2131886168;
				Base_Theme_MaterialComponents_Light_DialogWhenLarge = 2131886172;
				Base_Theme_MaterialComponents_Light_Dialog_Alert = 2131886169;
				Base_Theme_MaterialComponents_Light_Dialog_FixedSize = 2131886170;
				Base_Theme_MaterialComponents_Light_Dialog_MinWidth = 2131886171;
				Base_V14_ThemeOverlay_MaterialComponents_Dialog = 2131886189;
				Base_V14_ThemeOverlay_MaterialComponents_Dialog_Alert = 2131886190;
				Base_V14_Theme_MaterialComponents = 2131886182;
				Base_V14_Theme_MaterialComponents_Bridge = 2131886183;
				Base_V14_Theme_MaterialComponents_Dialog = 2131886184;
				Base_V14_Theme_MaterialComponents_Light = 2131886185;
				Base_V14_Theme_MaterialComponents_Light_Bridge = 2131886186;
				Base_V14_Theme_MaterialComponents_Light_DarkActionBar_Bridge = 2131886187;
				Base_V14_Theme_MaterialComponents_Light_Dialog = 2131886188;
				Base_V21_ThemeOverlay_AppCompat_Dialog = 2131886195;
				Base_V21_Theme_AppCompat = 2131886191;
				Base_V21_Theme_AppCompat_Dialog = 2131886192;
				Base_V21_Theme_AppCompat_Light = 2131886193;
				Base_V21_Theme_AppCompat_Light_Dialog = 2131886194;
				Base_V22_Theme_AppCompat = 2131886196;
				Base_V22_Theme_AppCompat_Light = 2131886197;
				Base_V23_Theme_AppCompat = 2131886198;
				Base_V23_Theme_AppCompat_Light = 2131886199;
				Base_V26_Theme_AppCompat = 2131886200;
				Base_V26_Theme_AppCompat_Light = 2131886201;
				Base_V26_Widget_AppCompat_Toolbar = 2131886202;
				Base_V28_Theme_AppCompat = 2131886203;
				Base_V28_Theme_AppCompat_Light = 2131886204;
				Base_V7_ThemeOverlay_AppCompat_Dialog = 2131886209;
				Base_V7_Theme_AppCompat = 2131886205;
				Base_V7_Theme_AppCompat_Dialog = 2131886206;
				Base_V7_Theme_AppCompat_Light = 2131886207;
				Base_V7_Theme_AppCompat_Light_Dialog = 2131886208;
				Base_V7_Widget_AppCompat_AutoCompleteTextView = 2131886210;
				Base_V7_Widget_AppCompat_EditText = 2131886211;
				Base_V7_Widget_AppCompat_Toolbar = 2131886212;
				Base_Widget_AppCompat_ActionBar = 2131886213;
				Base_Widget_AppCompat_ActionBar_Solid = 2131886214;
				Base_Widget_AppCompat_ActionBar_TabBar = 2131886215;
				Base_Widget_AppCompat_ActionBar_TabText = 2131886216;
				Base_Widget_AppCompat_ActionBar_TabView = 2131886217;
				Base_Widget_AppCompat_ActionButton = 2131886218;
				Base_Widget_AppCompat_ActionButton_CloseMode = 2131886219;
				Base_Widget_AppCompat_ActionButton_Overflow = 2131886220;
				Base_Widget_AppCompat_ActionMode = 2131886221;
				Base_Widget_AppCompat_ActivityChooserView = 2131886222;
				Base_Widget_AppCompat_AutoCompleteTextView = 2131886223;
				Base_Widget_AppCompat_Button = 2131886224;
				Base_Widget_AppCompat_ButtonBar = 2131886230;
				Base_Widget_AppCompat_ButtonBar_AlertDialog = 2131886231;
				Base_Widget_AppCompat_Button_Borderless = 2131886225;
				Base_Widget_AppCompat_Button_Borderless_Colored = 2131886226;
				Base_Widget_AppCompat_Button_ButtonBar_AlertDialog = 2131886227;
				Base_Widget_AppCompat_Button_Colored = 2131886228;
				Base_Widget_AppCompat_Button_Small = 2131886229;
				Base_Widget_AppCompat_CompoundButton_CheckBox = 2131886232;
				Base_Widget_AppCompat_CompoundButton_RadioButton = 2131886233;
				Base_Widget_AppCompat_CompoundButton_Switch = 2131886234;
				Base_Widget_AppCompat_DrawerArrowToggle = 2131886235;
				Base_Widget_AppCompat_DrawerArrowToggle_Common = 2131886236;
				Base_Widget_AppCompat_DropDownItem_Spinner = 2131886237;
				Base_Widget_AppCompat_EditText = 2131886238;
				Base_Widget_AppCompat_ImageButton = 2131886239;
				Base_Widget_AppCompat_Light_ActionBar = 2131886240;
				Base_Widget_AppCompat_Light_ActionBar_Solid = 2131886241;
				Base_Widget_AppCompat_Light_ActionBar_TabBar = 2131886242;
				Base_Widget_AppCompat_Light_ActionBar_TabText = 2131886243;
				Base_Widget_AppCompat_Light_ActionBar_TabText_Inverse = 2131886244;
				Base_Widget_AppCompat_Light_ActionBar_TabView = 2131886245;
				Base_Widget_AppCompat_Light_PopupMenu = 2131886246;
				Base_Widget_AppCompat_Light_PopupMenu_Overflow = 2131886247;
				Base_Widget_AppCompat_ListMenuView = 2131886248;
				Base_Widget_AppCompat_ListPopupWindow = 2131886249;
				Base_Widget_AppCompat_ListView = 2131886250;
				Base_Widget_AppCompat_ListView_DropDown = 2131886251;
				Base_Widget_AppCompat_ListView_Menu = 2131886252;
				Base_Widget_AppCompat_PopupMenu = 2131886253;
				Base_Widget_AppCompat_PopupMenu_Overflow = 2131886254;
				Base_Widget_AppCompat_PopupWindow = 2131886255;
				Base_Widget_AppCompat_ProgressBar = 2131886256;
				Base_Widget_AppCompat_ProgressBar_Horizontal = 2131886257;
				Base_Widget_AppCompat_RatingBar = 2131886258;
				Base_Widget_AppCompat_RatingBar_Indicator = 2131886259;
				Base_Widget_AppCompat_RatingBar_Small = 2131886260;
				Base_Widget_AppCompat_SearchView = 2131886261;
				Base_Widget_AppCompat_SearchView_ActionBar = 2131886262;
				Base_Widget_AppCompat_SeekBar = 2131886263;
				Base_Widget_AppCompat_SeekBar_Discrete = 2131886264;
				Base_Widget_AppCompat_Spinner = 2131886265;
				Base_Widget_AppCompat_Spinner_Underlined = 2131886266;
				Base_Widget_AppCompat_TextView = 2131886267;
				Base_Widget_AppCompat_TextView_SpinnerItem = 2131886268;
				Base_Widget_AppCompat_Toolbar = 2131886269;
				Base_Widget_AppCompat_Toolbar_Button_Navigation = 2131886270;
				Base_Widget_Design_TabLayout = 2131886271;
				Base_Widget_MaterialComponents_Chip = 2131886272;
				Base_Widget_MaterialComponents_TextInputEditText = 2131886273;
				Base_Widget_MaterialComponents_TextInputLayout = 2131886274;
				CardView = 2131886275;
				CardView_Dark = 2131886276;
				CardView_Light = 2131886277;
				com_facebook_activity_theme = 2131886644;
				com_facebook_auth_dialog = 2131886645;
				com_facebook_auth_dialog_instructions_textview = 2131886646;
				com_facebook_button = 2131886647;
				com_facebook_button_like = 2131886648;
				com_facebook_button_send = 2131886649;
				com_facebook_button_share = 2131886650;
				com_facebook_loginview_default_style = 2131886651;
				DashboardMetricIcon = 2131886278;
				DashboardMetricUnitText = 2131886279;
				DashboardMetricValueText = 2131886280;
				DashboardTileStartButton = 2131886281;
				ExoMediaButton = 2131886282;
				ExoMediaButton_FastForward = 2131886283;
				ExoMediaButton_Next = 2131886284;
				ExoMediaButton_Pause = 2131886285;
				ExoMediaButton_Play = 2131886286;
				ExoMediaButton_Previous = 2131886287;
				ExoMediaButton_Rewind = 2131886288;
				ExoMediaButton_VR = 2131886289;
				ExoStyledControls = 2131886290;
				ExoStyledControls_Button = 2131886291;
				ExoStyledControls_ButtonText = 2131886309;
				ExoStyledControls_Button_Bottom = 2131886292;
				ExoStyledControls_Button_Bottom_AudioTrack = 2131886293;
				ExoStyledControls_Button_Bottom_CC = 2131886294;
				ExoStyledControls_Button_Bottom_FullScreen = 2131886295;
				ExoStyledControls_Button_Bottom_OverflowHide = 2131886296;
				ExoStyledControls_Button_Bottom_OverflowShow = 2131886297;
				ExoStyledControls_Button_Bottom_PlaybackSpeed = 2131886298;
				ExoStyledControls_Button_Bottom_RepeatToggle = 2131886299;
				ExoStyledControls_Button_Bottom_Settings = 2131886300;
				ExoStyledControls_Button_Bottom_Shuffle = 2131886301;
				ExoStyledControls_Button_Bottom_VR = 2131886302;
				ExoStyledControls_Button_Center = 2131886303;
				ExoStyledControls_Button_Center_FfwdWithAmount = 2131886304;
				ExoStyledControls_Button_Center_Next = 2131886305;
				ExoStyledControls_Button_Center_PlayPause = 2131886306;
				ExoStyledControls_Button_Center_Previous = 2131886307;
				ExoStyledControls_Button_Center_RewWithAmount = 2131886308;
				ExoStyledControls_TimeBar = 2131886310;
				ExoStyledControls_TimeText = 2131886311;
				ExoStyledControls_TimeText_Duration = 2131886312;
				ExoStyledControls_TimeText_Position = 2131886313;
				ExoStyledControls_TimeText_Separator = 2131886314;
				FavoritesTileDescription = 2131886315;
				FavoritesTileTitle = 2131886316;
				LibraryTileDescription = 2131886317;
				LibraryTileTitle = 2131886318;
				MapTileDescription = 2131886319;
				MapTileStartButton = 2131886320;
				MapTileTitle = 2131886321;
				MessengerButton = 2131886322;
				MessengerButtonText = 2131886329;
				MessengerButtonText_Blue = 2131886330;
				MessengerButtonText_Blue_Large = 2131886331;
				MessengerButtonText_Blue_Small = 2131886332;
				MessengerButtonText_White = 2131886333;
				MessengerButtonText_White_Large = 2131886334;
				MessengerButtonText_White_Small = 2131886335;
				MessengerButton_Blue = 2131886323;
				MessengerButton_Blue_Large = 2131886324;
				MessengerButton_Blue_Small = 2131886325;
				MessengerButton_White = 2131886326;
				MessengerButton_White_Large = 2131886327;
				MessengerButton_White_Small = 2131886328;
				Platform_AppCompat = 2131886336;
				Platform_AppCompat_Light = 2131886337;
				Platform_MaterialComponents = 2131886338;
				Platform_MaterialComponents_Dialog = 2131886339;
				Platform_MaterialComponents_Light = 2131886340;
				Platform_MaterialComponents_Light_Dialog = 2131886341;
				Platform_ThemeOverlay_AppCompat = 2131886342;
				Platform_ThemeOverlay_AppCompat_Dark = 2131886343;
				Platform_ThemeOverlay_AppCompat_Light = 2131886344;
				Platform_V21_AppCompat = 2131886345;
				Platform_V21_AppCompat_Light = 2131886346;
				Platform_V25_AppCompat = 2131886347;
				Platform_V25_AppCompat_Light = 2131886348;
				Platform_Widget_AppCompat_Spinner = 2131886349;
				RtlOverlay_DialogWindowTitle_AppCompat = 2131886350;
				RtlOverlay_Widget_AppCompat_ActionBar_TitleItem = 2131886351;
				RtlOverlay_Widget_AppCompat_DialogTitle_Icon = 2131886352;
				RtlOverlay_Widget_AppCompat_PopupMenuItem = 2131886353;
				RtlOverlay_Widget_AppCompat_PopupMenuItem_InternalGroup = 2131886354;
				RtlOverlay_Widget_AppCompat_PopupMenuItem_Shortcut = 2131886355;
				RtlOverlay_Widget_AppCompat_PopupMenuItem_SubmenuArrow = 2131886356;
				RtlOverlay_Widget_AppCompat_PopupMenuItem_Text = 2131886357;
				RtlOverlay_Widget_AppCompat_PopupMenuItem_Title = 2131886358;
				RtlOverlay_Widget_AppCompat_SearchView_MagIcon = 2131886364;
				RtlOverlay_Widget_AppCompat_Search_DropDown = 2131886359;
				RtlOverlay_Widget_AppCompat_Search_DropDown_Icon1 = 2131886360;
				RtlOverlay_Widget_AppCompat_Search_DropDown_Icon2 = 2131886361;
				RtlOverlay_Widget_AppCompat_Search_DropDown_Query = 2131886362;
				RtlOverlay_Widget_AppCompat_Search_DropDown_Text = 2131886363;
				RtlUnderlay_Widget_AppCompat_ActionButton = 2131886365;
				RtlUnderlay_Widget_AppCompat_ActionButton_Overflow = 2131886366;
				TextAppearance_AppCompat = 2131886367;
				TextAppearance_AppCompat_Body1 = 2131886368;
				TextAppearance_AppCompat_Body2 = 2131886369;
				TextAppearance_AppCompat_Button = 2131886370;
				TextAppearance_AppCompat_Caption = 2131886371;
				TextAppearance_AppCompat_Display1 = 2131886372;
				TextAppearance_AppCompat_Display2 = 2131886373;
				TextAppearance_AppCompat_Display3 = 2131886374;
				TextAppearance_AppCompat_Display4 = 2131886375;
				TextAppearance_AppCompat_Headline = 2131886376;
				TextAppearance_AppCompat_Inverse = 2131886377;
				TextAppearance_AppCompat_Large = 2131886378;
				TextAppearance_AppCompat_Large_Inverse = 2131886379;
				TextAppearance_AppCompat_Light_SearchResult_Subtitle = 2131886380;
				TextAppearance_AppCompat_Light_SearchResult_Title = 2131886381;
				TextAppearance_AppCompat_Light_Widget_PopupMenu_Large = 2131886382;
				TextAppearance_AppCompat_Light_Widget_PopupMenu_Small = 2131886383;
				TextAppearance_AppCompat_Medium = 2131886384;
				TextAppearance_AppCompat_Medium_Inverse = 2131886385;
				TextAppearance_AppCompat_Menu = 2131886386;
				TextAppearance_AppCompat_SearchResult_Subtitle = 2131886387;
				TextAppearance_AppCompat_SearchResult_Title = 2131886388;
				TextAppearance_AppCompat_Small = 2131886389;
				TextAppearance_AppCompat_Small_Inverse = 2131886390;
				TextAppearance_AppCompat_Subhead = 2131886391;
				TextAppearance_AppCompat_Subhead_Inverse = 2131886392;
				TextAppearance_AppCompat_Title = 2131886393;
				TextAppearance_AppCompat_Title_Inverse = 2131886394;
				TextAppearance_AppCompat_Tooltip = 2131886395;
				TextAppearance_AppCompat_Widget_ActionBar_Menu = 2131886396;
				TextAppearance_AppCompat_Widget_ActionBar_Subtitle = 2131886397;
				TextAppearance_AppCompat_Widget_ActionBar_Subtitle_Inverse = 2131886398;
				TextAppearance_AppCompat_Widget_ActionBar_Title = 2131886399;
				TextAppearance_AppCompat_Widget_ActionBar_Title_Inverse = 2131886400;
				TextAppearance_AppCompat_Widget_ActionMode_Subtitle = 2131886401;
				TextAppearance_AppCompat_Widget_ActionMode_Subtitle_Inverse = 2131886402;
				TextAppearance_AppCompat_Widget_ActionMode_Title = 2131886403;
				TextAppearance_AppCompat_Widget_ActionMode_Title_Inverse = 2131886404;
				TextAppearance_AppCompat_Widget_Button = 2131886405;
				TextAppearance_AppCompat_Widget_Button_Borderless_Colored = 2131886406;
				TextAppearance_AppCompat_Widget_Button_Colored = 2131886407;
				TextAppearance_AppCompat_Widget_Button_Inverse = 2131886408;
				TextAppearance_AppCompat_Widget_DropDownItem = 2131886409;
				TextAppearance_AppCompat_Widget_PopupMenu_Header = 2131886410;
				TextAppearance_AppCompat_Widget_PopupMenu_Large = 2131886411;
				TextAppearance_AppCompat_Widget_PopupMenu_Small = 2131886412;
				TextAppearance_AppCompat_Widget_Switch = 2131886413;
				TextAppearance_AppCompat_Widget_TextView_SpinnerItem = 2131886414;
				TextAppearance_Compat_Notification = 2131886415;
				TextAppearance_Compat_Notification_Info = 2131886416;
				TextAppearance_Compat_Notification_Info_Media = 2131886417;
				TextAppearance_Compat_Notification_Line2 = 2131886418;
				TextAppearance_Compat_Notification_Line2_Media = 2131886419;
				TextAppearance_Compat_Notification_Media = 2131886420;
				TextAppearance_Compat_Notification_Time = 2131886421;
				TextAppearance_Compat_Notification_Time_Media = 2131886422;
				TextAppearance_Compat_Notification_Title = 2131886423;
				TextAppearance_Compat_Notification_Title_Media = 2131886424;
				TextAppearance_Design_CollapsingToolbar_Expanded = 2131886425;
				TextAppearance_Design_Counter = 2131886426;
				TextAppearance_Design_Counter_Overflow = 2131886427;
				TextAppearance_Design_Error = 2131886428;
				TextAppearance_Design_HelperText = 2131886429;
				TextAppearance_Design_Hint = 2131886430;
				TextAppearance_Design_Snackbar_Message = 2131886431;
				TextAppearance_Design_Tab = 2131886432;
				TextAppearance_MaterialComponents_Body1 = 2131886433;
				TextAppearance_MaterialComponents_Body2 = 2131886434;
				TextAppearance_MaterialComponents_Button = 2131886435;
				TextAppearance_MaterialComponents_Caption = 2131886436;
				TextAppearance_MaterialComponents_Chip = 2131886437;
				TextAppearance_MaterialComponents_Headline1 = 2131886438;
				TextAppearance_MaterialComponents_Headline2 = 2131886439;
				TextAppearance_MaterialComponents_Headline3 = 2131886440;
				TextAppearance_MaterialComponents_Headline4 = 2131886441;
				TextAppearance_MaterialComponents_Headline5 = 2131886442;
				TextAppearance_MaterialComponents_Headline6 = 2131886443;
				TextAppearance_MaterialComponents_Overline = 2131886444;
				TextAppearance_MaterialComponents_Subtitle1 = 2131886445;
				TextAppearance_MaterialComponents_Subtitle2 = 2131886446;
				TextAppearance_MaterialComponents_Tab = 2131886447;
				TextAppearance_Widget_AppCompat_ExpandedMenu_Item = 2131886448;
				TextAppearance_Widget_AppCompat_Toolbar_Subtitle = 2131886449;
				TextAppearance_Widget_AppCompat_Toolbar_Title = 2131886450;
				ThemeOverlay_AppCompat = 2131886500;
				ThemeOverlay_AppCompat_ActionBar = 2131886501;
				ThemeOverlay_AppCompat_Dark = 2131886502;
				ThemeOverlay_AppCompat_Dark_ActionBar = 2131886503;
				ThemeOverlay_AppCompat_DayNight = 2131886504;
				ThemeOverlay_AppCompat_DayNight_ActionBar = 2131886505;
				ThemeOverlay_AppCompat_Dialog = 2131886506;
				ThemeOverlay_AppCompat_Dialog_Alert = 2131886507;
				ThemeOverlay_AppCompat_Light = 2131886508;
				ThemeOverlay_MaterialComponents = 2131886509;
				ThemeOverlay_MaterialComponents_ActionBar = 2131886510;
				ThemeOverlay_MaterialComponents_Dark = 2131886511;
				ThemeOverlay_MaterialComponents_Dark_ActionBar = 2131886512;
				ThemeOverlay_MaterialComponents_Dialog = 2131886513;
				ThemeOverlay_MaterialComponents_Dialog_Alert = 2131886514;
				ThemeOverlay_MaterialComponents_Light = 2131886515;
				ThemeOverlay_MaterialComponents_TextInputEditText = 2131886516;
				ThemeOverlay_MaterialComponents_TextInputEditText_FilledBox = 2131886517;
				ThemeOverlay_MaterialComponents_TextInputEditText_FilledBox_Dense = 2131886518;
				ThemeOverlay_MaterialComponents_TextInputEditText_OutlinedBox = 2131886519;
				ThemeOverlay_MaterialComponents_TextInputEditText_OutlinedBox_Dense = 2131886520;
				Theme_AppCompat = 2131886451;
				Theme_AppCompat_CompactMenu = 2131886452;
				Theme_AppCompat_DayNight = 2131886453;
				Theme_AppCompat_DayNight_DarkActionBar = 2131886454;
				Theme_AppCompat_DayNight_Dialog = 2131886455;
				Theme_AppCompat_DayNight_DialogWhenLarge = 2131886458;
				Theme_AppCompat_DayNight_Dialog_Alert = 2131886456;
				Theme_AppCompat_DayNight_Dialog_MinWidth = 2131886457;
				Theme_AppCompat_DayNight_NoActionBar = 2131886459;
				Theme_AppCompat_Dialog = 2131886460;
				Theme_AppCompat_DialogWhenLarge = 2131886463;
				Theme_AppCompat_Dialog_Alert = 2131886461;
				Theme_AppCompat_Dialog_MinWidth = 2131886462;
				Theme_AppCompat_Empty = 2131886464;
				Theme_AppCompat_Light = 2131886465;
				Theme_AppCompat_Light_DarkActionBar = 2131886466;
				Theme_AppCompat_Light_Dialog = 2131886467;
				Theme_AppCompat_Light_DialogWhenLarge = 2131886470;
				Theme_AppCompat_Light_Dialog_Alert = 2131886468;
				Theme_AppCompat_Light_Dialog_MinWidth = 2131886469;
				Theme_AppCompat_Light_NoActionBar = 2131886471;
				Theme_AppCompat_NoActionBar = 2131886472;
				Theme_Design = 2131886473;
				Theme_Design_BottomSheetDialog = 2131886474;
				Theme_Design_Light = 2131886475;
				Theme_Design_Light_BottomSheetDialog = 2131886476;
				Theme_Design_Light_NoActionBar = 2131886477;
				Theme_Design_NoActionBar = 2131886478;
				Theme_MaterialComponents = 2131886479;
				Theme_MaterialComponents_BottomSheetDialog = 2131886480;
				Theme_MaterialComponents_Bridge = 2131886481;
				Theme_MaterialComponents_CompactMenu = 2131886482;
				Theme_MaterialComponents_Dialog = 2131886483;
				Theme_MaterialComponents_DialogWhenLarge = 2131886486;
				Theme_MaterialComponents_Dialog_Alert = 2131886484;
				Theme_MaterialComponents_Dialog_MinWidth = 2131886485;
				Theme_MaterialComponents_Light = 2131886487;
				Theme_MaterialComponents_Light_BottomSheetDialog = 2131886488;
				Theme_MaterialComponents_Light_Bridge = 2131886489;
				Theme_MaterialComponents_Light_DarkActionBar = 2131886490;
				Theme_MaterialComponents_Light_DarkActionBar_Bridge = 2131886491;
				Theme_MaterialComponents_Light_Dialog = 2131886492;
				Theme_MaterialComponents_Light_DialogWhenLarge = 2131886495;
				Theme_MaterialComponents_Light_Dialog_Alert = 2131886493;
				Theme_MaterialComponents_Light_Dialog_MinWidth = 2131886494;
				Theme_MaterialComponents_Light_NoActionBar = 2131886496;
				Theme_MaterialComponents_Light_NoActionBar_Bridge = 2131886497;
				Theme_MaterialComponents_NoActionBar = 2131886498;
				Theme_MaterialComponents_NoActionBar_Bridge = 2131886499;
				tooltip_bubble_text = 2131886652;
				Widget_AppCompat_ActionBar = 2131886521;
				Widget_AppCompat_ActionBar_Solid = 2131886522;
				Widget_AppCompat_ActionBar_TabBar = 2131886523;
				Widget_AppCompat_ActionBar_TabText = 2131886524;
				Widget_AppCompat_ActionBar_TabView = 2131886525;
				Widget_AppCompat_ActionButton = 2131886526;
				Widget_AppCompat_ActionButton_CloseMode = 2131886527;
				Widget_AppCompat_ActionButton_Overflow = 2131886528;
				Widget_AppCompat_ActionMode = 2131886529;
				Widget_AppCompat_ActivityChooserView = 2131886530;
				Widget_AppCompat_AutoCompleteTextView = 2131886531;
				Widget_AppCompat_Button = 2131886532;
				Widget_AppCompat_ButtonBar = 2131886538;
				Widget_AppCompat_ButtonBar_AlertDialog = 2131886539;
				Widget_AppCompat_Button_Borderless = 2131886533;
				Widget_AppCompat_Button_Borderless_Colored = 2131886534;
				Widget_AppCompat_Button_ButtonBar_AlertDialog = 2131886535;
				Widget_AppCompat_Button_Colored = 2131886536;
				Widget_AppCompat_Button_Small = 2131886537;
				Widget_AppCompat_CompoundButton_CheckBox = 2131886540;
				Widget_AppCompat_CompoundButton_RadioButton = 2131886541;
				Widget_AppCompat_CompoundButton_Switch = 2131886542;
				Widget_AppCompat_DrawerArrowToggle = 2131886543;
				Widget_AppCompat_DropDownItem_Spinner = 2131886544;
				Widget_AppCompat_EditText = 2131886545;
				Widget_AppCompat_ImageButton = 2131886546;
				Widget_AppCompat_Light_ActionBar = 2131886547;
				Widget_AppCompat_Light_ActionBar_Solid = 2131886548;
				Widget_AppCompat_Light_ActionBar_Solid_Inverse = 2131886549;
				Widget_AppCompat_Light_ActionBar_TabBar = 2131886550;
				Widget_AppCompat_Light_ActionBar_TabBar_Inverse = 2131886551;
				Widget_AppCompat_Light_ActionBar_TabText = 2131886552;
				Widget_AppCompat_Light_ActionBar_TabText_Inverse = 2131886553;
				Widget_AppCompat_Light_ActionBar_TabView = 2131886554;
				Widget_AppCompat_Light_ActionBar_TabView_Inverse = 2131886555;
				Widget_AppCompat_Light_ActionButton = 2131886556;
				Widget_AppCompat_Light_ActionButton_CloseMode = 2131886557;
				Widget_AppCompat_Light_ActionButton_Overflow = 2131886558;
				Widget_AppCompat_Light_ActionMode_Inverse = 2131886559;
				Widget_AppCompat_Light_ActivityChooserView = 2131886560;
				Widget_AppCompat_Light_AutoCompleteTextView = 2131886561;
				Widget_AppCompat_Light_DropDownItem_Spinner = 2131886562;
				Widget_AppCompat_Light_ListPopupWindow = 2131886563;
				Widget_AppCompat_Light_ListView_DropDown = 2131886564;
				Widget_AppCompat_Light_PopupMenu = 2131886565;
				Widget_AppCompat_Light_PopupMenu_Overflow = 2131886566;
				Widget_AppCompat_Light_SearchView = 2131886567;
				Widget_AppCompat_Light_Spinner_DropDown_ActionBar = 2131886568;
				Widget_AppCompat_ListMenuView = 2131886569;
				Widget_AppCompat_ListPopupWindow = 2131886570;
				Widget_AppCompat_ListView = 2131886571;
				Widget_AppCompat_ListView_DropDown = 2131886572;
				Widget_AppCompat_ListView_Menu = 2131886573;
				Widget_AppCompat_PopupMenu = 2131886574;
				Widget_AppCompat_PopupMenu_Overflow = 2131886575;
				Widget_AppCompat_PopupWindow = 2131886576;
				Widget_AppCompat_ProgressBar = 2131886577;
				Widget_AppCompat_ProgressBar_Horizontal = 2131886578;
				Widget_AppCompat_RatingBar = 2131886579;
				Widget_AppCompat_RatingBar_Indicator = 2131886580;
				Widget_AppCompat_RatingBar_Small = 2131886581;
				Widget_AppCompat_SearchView = 2131886582;
				Widget_AppCompat_SearchView_ActionBar = 2131886583;
				Widget_AppCompat_SeekBar = 2131886584;
				Widget_AppCompat_SeekBar_Discrete = 2131886585;
				Widget_AppCompat_Spinner = 2131886586;
				Widget_AppCompat_Spinner_DropDown = 2131886587;
				Widget_AppCompat_Spinner_DropDown_ActionBar = 2131886588;
				Widget_AppCompat_Spinner_Underlined = 2131886589;
				Widget_AppCompat_TextView = 2131886590;
				Widget_AppCompat_TextView_SpinnerItem = 2131886591;
				Widget_AppCompat_Toolbar = 2131886592;
				Widget_AppCompat_Toolbar_Button_Navigation = 2131886593;
				Widget_Compat_NotificationActionContainer = 2131886594;
				Widget_Compat_NotificationActionText = 2131886595;
				Widget_Design_AppBarLayout = 2131886596;
				Widget_Design_BottomNavigationView = 2131886597;
				Widget_Design_BottomSheet_Modal = 2131886598;
				Widget_Design_CollapsingToolbar = 2131886599;
				Widget_Design_FloatingActionButton = 2131886600;
				Widget_Design_NavigationView = 2131886601;
				Widget_Design_ScrimInsetsFrameLayout = 2131886602;
				Widget_Design_Snackbar = 2131886603;
				Widget_Design_TabLayout = 2131886604;
				Widget_Design_TextInputLayout = 2131886605;
				Widget_MaterialComponents_BottomAppBar = 2131886606;
				Widget_MaterialComponents_BottomAppBar_Colored = 2131886607;
				Widget_MaterialComponents_BottomNavigationView = 2131886608;
				Widget_MaterialComponents_BottomNavigationView_Colored = 2131886609;
				Widget_MaterialComponents_BottomSheet_Modal = 2131886610;
				Widget_MaterialComponents_Button = 2131886611;
				Widget_MaterialComponents_Button_Icon = 2131886612;
				Widget_MaterialComponents_Button_OutlinedButton = 2131886613;
				Widget_MaterialComponents_Button_OutlinedButton_Icon = 2131886614;
				Widget_MaterialComponents_Button_TextButton = 2131886615;
				Widget_MaterialComponents_Button_TextButton_Dialog = 2131886616;
				Widget_MaterialComponents_Button_TextButton_Dialog_Icon = 2131886617;
				Widget_MaterialComponents_Button_TextButton_Icon = 2131886618;
				Widget_MaterialComponents_Button_UnelevatedButton = 2131886619;
				Widget_MaterialComponents_Button_UnelevatedButton_Icon = 2131886620;
				Widget_MaterialComponents_CardView = 2131886621;
				Widget_MaterialComponents_ChipGroup = 2131886626;
				Widget_MaterialComponents_Chip_Action = 2131886622;
				Widget_MaterialComponents_Chip_Choice = 2131886623;
				Widget_MaterialComponents_Chip_Entry = 2131886624;
				Widget_MaterialComponents_Chip_Filter = 2131886625;
				Widget_MaterialComponents_FloatingActionButton = 2131886627;
				Widget_MaterialComponents_NavigationView = 2131886628;
				Widget_MaterialComponents_Snackbar = 2131886629;
				Widget_MaterialComponents_Snackbar_FullWidth = 2131886630;
				Widget_MaterialComponents_TabLayout = 2131886631;
				Widget_MaterialComponents_TabLayout_Colored = 2131886632;
				Widget_MaterialComponents_TextInputEditText_FilledBox = 2131886633;
				Widget_MaterialComponents_TextInputEditText_FilledBox_Dense = 2131886634;
				Widget_MaterialComponents_TextInputEditText_OutlinedBox = 2131886635;
				Widget_MaterialComponents_TextInputEditText_OutlinedBox_Dense = 2131886636;
				Widget_MaterialComponents_TextInputLayout_FilledBox = 2131886637;
				Widget_MaterialComponents_TextInputLayout_FilledBox_Dense = 2131886638;
				Widget_MaterialComponents_TextInputLayout_OutlinedBox = 2131886639;
				Widget_MaterialComponents_TextInputLayout_OutlinedBox_Dense = 2131886640;
				Widget_MaterialComponents_Toolbar = 2131886641;
				Widget_Support_CoordinatorLayout = 2131886642;
				WrappedLayout = 2131886643;
				ResourceIdManager.UpdateIdValues();
			}

			private Style()
			{
			}
		}

		public class Styleable
		{
			public static int[] ActionBar;

			public static int[] ActionBarLayout;

			public static int ActionBarLayout_android_layout_gravity;

			public static int ActionBar_background;

			public static int ActionBar_backgroundSplit;

			public static int ActionBar_backgroundStacked;

			public static int ActionBar_contentInsetEnd;

			public static int ActionBar_contentInsetEndWithActions;

			public static int ActionBar_contentInsetLeft;

			public static int ActionBar_contentInsetRight;

			public static int ActionBar_contentInsetStart;

			public static int ActionBar_contentInsetStartWithNavigation;

			public static int ActionBar_customNavigationLayout;

			public static int ActionBar_displayOptions;

			public static int ActionBar_divider;

			public static int ActionBar_elevation;

			public static int ActionBar_height;

			public static int ActionBar_hideOnContentScroll;

			public static int ActionBar_homeAsUpIndicator;

			public static int ActionBar_homeLayout;

			public static int ActionBar_icon;

			public static int ActionBar_indeterminateProgressStyle;

			public static int ActionBar_itemPadding;

			public static int ActionBar_logo;

			public static int ActionBar_navigationMode;

			public static int ActionBar_popupTheme;

			public static int ActionBar_progressBarPadding;

			public static int ActionBar_progressBarStyle;

			public static int ActionBar_subtitle;

			public static int ActionBar_subtitleTextStyle;

			public static int ActionBar_title;

			public static int ActionBar_titleTextStyle;

			public static int[] ActionMenuItemView;

			public static int ActionMenuItemView_android_minWidth;

			public static int[] ActionMenuView;

			public static int[] ActionMode;

			public static int ActionMode_background;

			public static int ActionMode_backgroundSplit;

			public static int ActionMode_closeItemLayout;

			public static int ActionMode_height;

			public static int ActionMode_subtitleTextStyle;

			public static int ActionMode_titleTextStyle;

			public static int[] ActivityChooserView;

			public static int ActivityChooserView_expandActivityOverflowButtonDrawable;

			public static int ActivityChooserView_initialActivityCount;

			public static int[] ActivityFilter;

			public static int ActivityFilter_activityAction;

			public static int ActivityFilter_activityName;

			public static int[] ActivityRule;

			public static int ActivityRule_alwaysExpand;

			public static int[] AlertDialog;

			public static int AlertDialog_android_layout;

			public static int AlertDialog_buttonIconDimen;

			public static int AlertDialog_buttonPanelSideLayout;

			public static int AlertDialog_listItemLayout;

			public static int AlertDialog_listLayout;

			public static int AlertDialog_multiChoiceItemLayout;

			public static int AlertDialog_showTitle;

			public static int AlertDialog_singleChoiceItemLayout;

			public static int[] AnimatedStateListDrawableCompat;

			public static int AnimatedStateListDrawableCompat_android_constantSize;

			public static int AnimatedStateListDrawableCompat_android_dither;

			public static int AnimatedStateListDrawableCompat_android_enterFadeDuration;

			public static int AnimatedStateListDrawableCompat_android_exitFadeDuration;

			public static int AnimatedStateListDrawableCompat_android_variablePadding;

			public static int AnimatedStateListDrawableCompat_android_visible;

			public static int[] AnimatedStateListDrawableItem;

			public static int AnimatedStateListDrawableItem_android_drawable;

			public static int AnimatedStateListDrawableItem_android_id;

			public static int[] AnimatedStateListDrawableTransition;

			public static int AnimatedStateListDrawableTransition_android_drawable;

			public static int AnimatedStateListDrawableTransition_android_fromId;

			public static int AnimatedStateListDrawableTransition_android_reversible;

			public static int AnimatedStateListDrawableTransition_android_toId;

			public static int[] AppBarLayout;

			public static int[] AppBarLayoutStates;

			public static int AppBarLayoutStates_state_collapsed;

			public static int AppBarLayoutStates_state_collapsible;

			public static int AppBarLayoutStates_state_liftable;

			public static int AppBarLayoutStates_state_lifted;

			public static int AppBarLayout_android_background;

			public static int AppBarLayout_android_keyboardNavigationCluster;

			public static int AppBarLayout_android_touchscreenBlocksFocus;

			public static int AppBarLayout_elevation;

			public static int AppBarLayout_expanded;

			public static int[] AppBarLayout_Layout;

			public static int AppBarLayout_Layout_layout_scrollFlags;

			public static int AppBarLayout_Layout_layout_scrollInterpolator;

			public static int AppBarLayout_liftOnScroll;

			public static int[] AppCompatImageView;

			public static int AppCompatImageView_android_src;

			public static int AppCompatImageView_srcCompat;

			public static int AppCompatImageView_tint;

			public static int AppCompatImageView_tintMode;

			public static int[] AppCompatSeekBar;

			public static int AppCompatSeekBar_android_thumb;

			public static int AppCompatSeekBar_tickMark;

			public static int AppCompatSeekBar_tickMarkTint;

			public static int AppCompatSeekBar_tickMarkTintMode;

			public static int[] AppCompatTextHelper;

			public static int AppCompatTextHelper_android_drawableBottom;

			public static int AppCompatTextHelper_android_drawableEnd;

			public static int AppCompatTextHelper_android_drawableLeft;

			public static int AppCompatTextHelper_android_drawableRight;

			public static int AppCompatTextHelper_android_drawableStart;

			public static int AppCompatTextHelper_android_drawableTop;

			public static int AppCompatTextHelper_android_textAppearance;

			public static int[] AppCompatTextView;

			public static int AppCompatTextView_android_textAppearance;

			public static int AppCompatTextView_autoSizeMaxTextSize;

			public static int AppCompatTextView_autoSizeMinTextSize;

			public static int AppCompatTextView_autoSizePresetSizes;

			public static int AppCompatTextView_autoSizeStepGranularity;

			public static int AppCompatTextView_autoSizeTextType;

			public static int AppCompatTextView_drawableBottomCompat;

			public static int AppCompatTextView_drawableEndCompat;

			public static int AppCompatTextView_drawableLeftCompat;

			public static int AppCompatTextView_drawableRightCompat;

			public static int AppCompatTextView_drawableStartCompat;

			public static int AppCompatTextView_drawableTint;

			public static int AppCompatTextView_drawableTintMode;

			public static int AppCompatTextView_drawableTopCompat;

			public static int AppCompatTextView_firstBaselineToTopHeight;

			public static int AppCompatTextView_fontFamily;

			public static int AppCompatTextView_fontVariationSettings;

			public static int AppCompatTextView_lastBaselineToBottomHeight;

			public static int AppCompatTextView_lineHeight;

			public static int AppCompatTextView_textAllCaps;

			public static int AppCompatTextView_textLocale;

			public static int[] AppCompatTheme;

			public static int AppCompatTheme_actionBarDivider;

			public static int AppCompatTheme_actionBarItemBackground;

			public static int AppCompatTheme_actionBarPopupTheme;

			public static int AppCompatTheme_actionBarSize;

			public static int AppCompatTheme_actionBarSplitStyle;

			public static int AppCompatTheme_actionBarStyle;

			public static int AppCompatTheme_actionBarTabBarStyle;

			public static int AppCompatTheme_actionBarTabStyle;

			public static int AppCompatTheme_actionBarTabTextStyle;

			public static int AppCompatTheme_actionBarTheme;

			public static int AppCompatTheme_actionBarWidgetTheme;

			public static int AppCompatTheme_actionButtonStyle;

			public static int AppCompatTheme_actionDropDownStyle;

			public static int AppCompatTheme_actionMenuTextAppearance;

			public static int AppCompatTheme_actionMenuTextColor;

			public static int AppCompatTheme_actionModeBackground;

			public static int AppCompatTheme_actionModeCloseButtonStyle;

			public static int AppCompatTheme_actionModeCloseContentDescription;

			public static int AppCompatTheme_actionModeCloseDrawable;

			public static int AppCompatTheme_actionModeCopyDrawable;

			public static int AppCompatTheme_actionModeCutDrawable;

			public static int AppCompatTheme_actionModeFindDrawable;

			public static int AppCompatTheme_actionModePasteDrawable;

			public static int AppCompatTheme_actionModePopupWindowStyle;

			public static int AppCompatTheme_actionModeSelectAllDrawable;

			public static int AppCompatTheme_actionModeShareDrawable;

			public static int AppCompatTheme_actionModeSplitBackground;

			public static int AppCompatTheme_actionModeStyle;

			public static int AppCompatTheme_actionModeTheme;

			public static int AppCompatTheme_actionModeWebSearchDrawable;

			public static int AppCompatTheme_actionOverflowButtonStyle;

			public static int AppCompatTheme_actionOverflowMenuStyle;

			public static int AppCompatTheme_activityChooserViewStyle;

			public static int AppCompatTheme_alertDialogButtonGroupStyle;

			public static int AppCompatTheme_alertDialogCenterButtons;

			public static int AppCompatTheme_alertDialogStyle;

			public static int AppCompatTheme_alertDialogTheme;

			public static int AppCompatTheme_android_windowAnimationStyle;

			public static int AppCompatTheme_android_windowIsFloating;

			public static int AppCompatTheme_autoCompleteTextViewStyle;

			public static int AppCompatTheme_borderlessButtonStyle;

			public static int AppCompatTheme_buttonBarButtonStyle;

			public static int AppCompatTheme_buttonBarNegativeButtonStyle;

			public static int AppCompatTheme_buttonBarNeutralButtonStyle;

			public static int AppCompatTheme_buttonBarPositiveButtonStyle;

			public static int AppCompatTheme_buttonBarStyle;

			public static int AppCompatTheme_buttonStyle;

			public static int AppCompatTheme_buttonStyleSmall;

			public static int AppCompatTheme_checkboxStyle;

			public static int AppCompatTheme_checkedTextViewStyle;

			public static int AppCompatTheme_colorAccent;

			public static int AppCompatTheme_colorBackgroundFloating;

			public static int AppCompatTheme_colorButtonNormal;

			public static int AppCompatTheme_colorControlActivated;

			public static int AppCompatTheme_colorControlHighlight;

			public static int AppCompatTheme_colorControlNormal;

			public static int AppCompatTheme_colorError;

			public static int AppCompatTheme_colorPrimary;

			public static int AppCompatTheme_colorPrimaryDark;

			public static int AppCompatTheme_colorSwitchThumbNormal;

			public static int AppCompatTheme_controlBackground;

			public static int AppCompatTheme_dialogCornerRadius;

			public static int AppCompatTheme_dialogPreferredPadding;

			public static int AppCompatTheme_dialogTheme;

			public static int AppCompatTheme_dividerHorizontal;

			public static int AppCompatTheme_dividerVertical;

			public static int AppCompatTheme_dropdownListPreferredItemHeight;

			public static int AppCompatTheme_dropDownListViewStyle;

			public static int AppCompatTheme_editTextBackground;

			public static int AppCompatTheme_editTextColor;

			public static int AppCompatTheme_editTextStyle;

			public static int AppCompatTheme_homeAsUpIndicator;

			public static int AppCompatTheme_imageButtonStyle;

			public static int AppCompatTheme_listChoiceBackgroundIndicator;

			public static int AppCompatTheme_listChoiceIndicatorMultipleAnimated;

			public static int AppCompatTheme_listChoiceIndicatorSingleAnimated;

			public static int AppCompatTheme_listDividerAlertDialog;

			public static int AppCompatTheme_listMenuViewStyle;

			public static int AppCompatTheme_listPopupWindowStyle;

			public static int AppCompatTheme_listPreferredItemHeight;

			public static int AppCompatTheme_listPreferredItemHeightLarge;

			public static int AppCompatTheme_listPreferredItemHeightSmall;

			public static int AppCompatTheme_listPreferredItemPaddingEnd;

			public static int AppCompatTheme_listPreferredItemPaddingLeft;

			public static int AppCompatTheme_listPreferredItemPaddingRight;

			public static int AppCompatTheme_listPreferredItemPaddingStart;

			public static int AppCompatTheme_panelBackground;

			public static int AppCompatTheme_panelMenuListTheme;

			public static int AppCompatTheme_panelMenuListWidth;

			public static int AppCompatTheme_popupMenuStyle;

			public static int AppCompatTheme_popupWindowStyle;

			public static int AppCompatTheme_radioButtonStyle;

			public static int AppCompatTheme_ratingBarStyle;

			public static int AppCompatTheme_ratingBarStyleIndicator;

			public static int AppCompatTheme_ratingBarStyleSmall;

			public static int AppCompatTheme_searchViewStyle;

			public static int AppCompatTheme_seekBarStyle;

			public static int AppCompatTheme_selectableItemBackground;

			public static int AppCompatTheme_selectableItemBackgroundBorderless;

			public static int AppCompatTheme_spinnerDropDownItemStyle;

			public static int AppCompatTheme_spinnerStyle;

			public static int AppCompatTheme_switchStyle;

			public static int AppCompatTheme_textAppearanceLargePopupMenu;

			public static int AppCompatTheme_textAppearanceListItem;

			public static int AppCompatTheme_textAppearanceListItemSecondary;

			public static int AppCompatTheme_textAppearanceListItemSmall;

			public static int AppCompatTheme_textAppearancePopupMenuHeader;

			public static int AppCompatTheme_textAppearanceSearchResultSubtitle;

			public static int AppCompatTheme_textAppearanceSearchResultTitle;

			public static int AppCompatTheme_textAppearanceSmallPopupMenu;

			public static int AppCompatTheme_textColorAlertDialogListItem;

			public static int AppCompatTheme_textColorSearchUrl;

			public static int AppCompatTheme_toolbarNavigationButtonStyle;

			public static int AppCompatTheme_toolbarStyle;

			public static int AppCompatTheme_tooltipForegroundColor;

			public static int AppCompatTheme_tooltipFrameBackground;

			public static int AppCompatTheme_viewInflaterClass;

			public static int AppCompatTheme_windowActionBar;

			public static int AppCompatTheme_windowActionBarOverlay;

			public static int AppCompatTheme_windowActionModeOverlay;

			public static int AppCompatTheme_windowFixedHeightMajor;

			public static int AppCompatTheme_windowFixedHeightMinor;

			public static int AppCompatTheme_windowFixedWidthMajor;

			public static int AppCompatTheme_windowFixedWidthMinor;

			public static int AppCompatTheme_windowMinWidthMajor;

			public static int AppCompatTheme_windowMinWidthMinor;

			public static int AppCompatTheme_windowNoTitle;

			public static int[] AspectRatioFrameLayout;

			public static int AspectRatioFrameLayout_resize_mode;

			public static int[] BetterImageView;

			public static int BetterImageView_cropByteArray;

			public static int BetterImageView_defaultResource;

			public static int BetterImageView_showLoadingAnimation;

			public static int[] BottomAppBar;

			public static int BottomAppBar_backgroundTint;

			public static int BottomAppBar_fabAlignmentMode;

			public static int BottomAppBar_fabCradleMargin;

			public static int BottomAppBar_fabCradleRoundedCornerRadius;

			public static int BottomAppBar_fabCradleVerticalOffset;

			public static int BottomAppBar_hideOnScroll;

			public static int[] BottomNavigationView;

			public static int BottomNavigationView_elevation;

			public static int BottomNavigationView_itemBackground;

			public static int BottomNavigationView_itemHorizontalTranslationEnabled;

			public static int BottomNavigationView_itemIconSize;

			public static int BottomNavigationView_itemIconTint;

			public static int BottomNavigationView_itemTextAppearanceActive;

			public static int BottomNavigationView_itemTextAppearanceInactive;

			public static int BottomNavigationView_itemTextColor;

			public static int BottomNavigationView_labelVisibilityMode;

			public static int BottomNavigationView_menu;

			public static int[] BottomSheetBehavior_Layout;

			public static int BottomSheetBehavior_Layout_behavior_fitToContents;

			public static int BottomSheetBehavior_Layout_behavior_hideable;

			public static int BottomSheetBehavior_Layout_behavior_peekHeight;

			public static int BottomSheetBehavior_Layout_behavior_skipCollapsed;

			public static int[] ButtonBarLayout;

			public static int ButtonBarLayout_allowStacking;

			public static int[] Capability;

			public static int Capability_queryPatterns;

			public static int Capability_shortcutMatchRequired;

			public static int[] CardView;

			public static int CardView_android_minHeight;

			public static int CardView_android_minWidth;

			public static int CardView_cardBackgroundColor;

			public static int CardView_cardCornerRadius;

			public static int CardView_cardElevation;

			public static int CardView_cardMaxElevation;

			public static int CardView_cardPreventCornerOverlap;

			public static int CardView_cardUseCompatPadding;

			public static int CardView_contentPadding;

			public static int CardView_contentPaddingBottom;

			public static int CardView_contentPaddingLeft;

			public static int CardView_contentPaddingRight;

			public static int CardView_contentPaddingTop;

			public static int[] Chip;

			public static int[] ChipGroup;

			public static int ChipGroup_checkedChip;

			public static int ChipGroup_chipSpacing;

			public static int ChipGroup_chipSpacingHorizontal;

			public static int ChipGroup_chipSpacingVertical;

			public static int ChipGroup_singleLine;

			public static int ChipGroup_singleSelection;

			public static int Chip_android_checkable;

			public static int Chip_android_ellipsize;

			public static int Chip_android_maxWidth;

			public static int Chip_android_text;

			public static int Chip_android_textAppearance;

			public static int Chip_checkedIcon;

			public static int Chip_checkedIconEnabled;

			public static int Chip_checkedIconVisible;

			public static int Chip_chipBackgroundColor;

			public static int Chip_chipCornerRadius;

			public static int Chip_chipEndPadding;

			public static int Chip_chipIcon;

			public static int Chip_chipIconEnabled;

			public static int Chip_chipIconSize;

			public static int Chip_chipIconTint;

			public static int Chip_chipIconVisible;

			public static int Chip_chipMinHeight;

			public static int Chip_chipStartPadding;

			public static int Chip_chipStrokeColor;

			public static int Chip_chipStrokeWidth;

			public static int Chip_closeIcon;

			public static int Chip_closeIconEnabled;

			public static int Chip_closeIconEndPadding;

			public static int Chip_closeIconSize;

			public static int Chip_closeIconStartPadding;

			public static int Chip_closeIconTint;

			public static int Chip_closeIconVisible;

			public static int Chip_hideMotionSpec;

			public static int Chip_iconEndPadding;

			public static int Chip_iconStartPadding;

			public static int Chip_rippleColor;

			public static int Chip_showMotionSpec;

			public static int Chip_textEndPadding;

			public static int Chip_textStartPadding;

			public static int[] CircleImageView;

			public static int CircleImageView_civ_border_color;

			public static int CircleImageView_civ_border_overlay;

			public static int CircleImageView_civ_border_width;

			public static int CircleImageView_civ_fill_color;

			public static int[] CircularLoadingView;

			public static int CircularLoadingView_autoPlay;

			public static int CircularLoadingView_backgroundRingColor;

			public static int CircularLoadingView_foregroundRingColor;

			public static int CircularLoadingView_singleColorMode;

			public static int[] CollapsingToolbarLayout;

			public static int CollapsingToolbarLayout_collapsedTitleGravity;

			public static int CollapsingToolbarLayout_collapsedTitleTextAppearance;

			public static int CollapsingToolbarLayout_contentScrim;

			public static int CollapsingToolbarLayout_expandedTitleGravity;

			public static int CollapsingToolbarLayout_expandedTitleMargin;

			public static int CollapsingToolbarLayout_expandedTitleMarginBottom;

			public static int CollapsingToolbarLayout_expandedTitleMarginEnd;

			public static int CollapsingToolbarLayout_expandedTitleMarginStart;

			public static int CollapsingToolbarLayout_expandedTitleMarginTop;

			public static int CollapsingToolbarLayout_expandedTitleTextAppearance;

			public static int[] CollapsingToolbarLayout_Layout;

			public static int CollapsingToolbarLayout_Layout_layout_collapseMode;

			public static int CollapsingToolbarLayout_Layout_layout_collapseParallaxMultiplier;

			public static int CollapsingToolbarLayout_scrimAnimationDuration;

			public static int CollapsingToolbarLayout_scrimVisibleHeightTrigger;

			public static int CollapsingToolbarLayout_statusBarScrim;

			public static int CollapsingToolbarLayout_title;

			public static int CollapsingToolbarLayout_titleEnabled;

			public static int CollapsingToolbarLayout_toolbarId;

			public static int[] ColorStateListItem;

			public static int ColorStateListItem_alpha;

			public static int ColorStateListItem_android_alpha;

			public static int ColorStateListItem_android_color;

			public static int ColorStateListItem_android_lStar;

			public static int ColorStateListItem_lStar;

			public static int[] CompoundButton;

			public static int CompoundButton_android_button;

			public static int CompoundButton_buttonCompat;

			public static int CompoundButton_buttonTint;

			public static int CompoundButton_buttonTintMode;

			public static int[] com_facebook_like_view;

			public static int com_facebook_like_view_com_facebook_auxiliary_view_position;

			public static int com_facebook_like_view_com_facebook_foreground_color;

			public static int com_facebook_like_view_com_facebook_horizontal_alignment;

			public static int com_facebook_like_view_com_facebook_object_id;

			public static int com_facebook_like_view_com_facebook_object_type;

			public static int com_facebook_like_view_com_facebook_style;

			public static int[] com_facebook_login_view;

			public static int com_facebook_login_view_com_facebook_confirm_logout;

			public static int com_facebook_login_view_com_facebook_login_button_radius;

			public static int com_facebook_login_view_com_facebook_login_button_transparency;

			public static int com_facebook_login_view_com_facebook_login_text;

			public static int com_facebook_login_view_com_facebook_logout_text;

			public static int com_facebook_login_view_com_facebook_tooltip_mode;

			public static int[] com_facebook_profile_picture_view;

			public static int com_facebook_profile_picture_view_com_facebook_is_cropped;

			public static int com_facebook_profile_picture_view_com_facebook_preset_size;

			public static int[] CoordinatorLayout;

			public static int CoordinatorLayout_keylines;

			public static int[] CoordinatorLayout_Layout;

			public static int CoordinatorLayout_Layout_android_layout_gravity;

			public static int CoordinatorLayout_Layout_layout_anchor;

			public static int CoordinatorLayout_Layout_layout_anchorGravity;

			public static int CoordinatorLayout_Layout_layout_behavior;

			public static int CoordinatorLayout_Layout_layout_dodgeInsetEdges;

			public static int CoordinatorLayout_Layout_layout_insetEdge;

			public static int CoordinatorLayout_Layout_layout_keyline;

			public static int CoordinatorLayout_statusBarBackground;

			public static int[] DefaultTimeBar;

			public static int DefaultTimeBar_ad_marker_color;

			public static int DefaultTimeBar_ad_marker_width;

			public static int DefaultTimeBar_bar_gravity;

			public static int DefaultTimeBar_bar_height;

			public static int DefaultTimeBar_buffered_color;

			public static int DefaultTimeBar_played_ad_marker_color;

			public static int DefaultTimeBar_played_color;

			public static int DefaultTimeBar_scrubber_color;

			public static int DefaultTimeBar_scrubber_disabled_size;

			public static int DefaultTimeBar_scrubber_dragged_size;

			public static int DefaultTimeBar_scrubber_drawable;

			public static int DefaultTimeBar_scrubber_enabled_size;

			public static int DefaultTimeBar_touch_target_height;

			public static int DefaultTimeBar_unplayed_color;

			public static int[] DesignTheme;

			public static int DesignTheme_bottomSheetDialogTheme;

			public static int DesignTheme_bottomSheetStyle;

			public static int[] DrawerArrowToggle;

			public static int DrawerArrowToggle_arrowHeadLength;

			public static int DrawerArrowToggle_arrowShaftLength;

			public static int DrawerArrowToggle_barLength;

			public static int DrawerArrowToggle_color;

			public static int DrawerArrowToggle_drawableSize;

			public static int DrawerArrowToggle_gapBetweenBars;

			public static int DrawerArrowToggle_spinBars;

			public static int DrawerArrowToggle_thickness;

			public static int[] DrawerLayout;

			public static int DrawerLayout_elevation;

			public static int[] FloatingActionButton;

			public static int FloatingActionButton_backgroundTint;

			public static int FloatingActionButton_backgroundTintMode;

			public static int[] FloatingActionButton_Behavior_Layout;

			public static int FloatingActionButton_Behavior_Layout_behavior_autoHide;

			public static int FloatingActionButton_borderWidth;

			public static int FloatingActionButton_elevation;

			public static int FloatingActionButton_fabCustomSize;

			public static int FloatingActionButton_fabSize;

			public static int FloatingActionButton_hideMotionSpec;

			public static int FloatingActionButton_hoveredFocusedTranslationZ;

			public static int FloatingActionButton_maxImageSize;

			public static int FloatingActionButton_pressedTranslationZ;

			public static int FloatingActionButton_rippleColor;

			public static int FloatingActionButton_showMotionSpec;

			public static int FloatingActionButton_useCompatPadding;

			public static int[] FlowLayout;

			public static int FlowLayout_itemSpacing;

			public static int FlowLayout_lineSpacing;

			public static int[] FontFamily;

			public static int[] FontFamilyFont;

			public static int FontFamilyFont_android_font;

			public static int FontFamilyFont_android_fontStyle;

			public static int FontFamilyFont_android_fontVariationSettings;

			public static int FontFamilyFont_android_fontWeight;

			public static int FontFamilyFont_android_ttcIndex;

			public static int FontFamilyFont_font;

			public static int FontFamilyFont_fontStyle;

			public static int FontFamilyFont_fontVariationSettings;

			public static int FontFamilyFont_fontWeight;

			public static int FontFamilyFont_ttcIndex;

			public static int FontFamily_fontProviderAuthority;

			public static int FontFamily_fontProviderCerts;

			public static int FontFamily_fontProviderFetchStrategy;

			public static int FontFamily_fontProviderFetchTimeout;

			public static int FontFamily_fontProviderPackage;

			public static int FontFamily_fontProviderQuery;

			public static int FontFamily_fontProviderSystemFontFamily;

			public static int[] ForegroundLinearLayout;

			public static int ForegroundLinearLayout_android_foreground;

			public static int ForegroundLinearLayout_android_foregroundGravity;

			public static int ForegroundLinearLayout_foregroundInsidePadding;

			public static int[] GradientColor;

			public static int[] GradientColorItem;

			public static int GradientColorItem_android_color;

			public static int GradientColorItem_android_offset;

			public static int GradientColor_android_centerColor;

			public static int GradientColor_android_centerX;

			public static int GradientColor_android_centerY;

			public static int GradientColor_android_endColor;

			public static int GradientColor_android_endX;

			public static int GradientColor_android_endY;

			public static int GradientColor_android_gradientRadius;

			public static int GradientColor_android_startColor;

			public static int GradientColor_android_startX;

			public static int GradientColor_android_startY;

			public static int GradientColor_android_tileMode;

			public static int GradientColor_android_type;

			public static int[] IfitButton;

			public static int IfitButton_typeface;

			public static int[] IfitEditTextView;

			public static int IfitEditTextView_typeface;

			public static int[] IfitTextView;

			public static int IfitTextView_typeface;

			public static int[] LinearLayoutCompat;

			public static int LinearLayoutCompat_android_baselineAligned;

			public static int LinearLayoutCompat_android_baselineAlignedChildIndex;

			public static int LinearLayoutCompat_android_gravity;

			public static int LinearLayoutCompat_android_orientation;

			public static int LinearLayoutCompat_android_weightSum;

			public static int LinearLayoutCompat_divider;

			public static int LinearLayoutCompat_dividerPadding;

			public static int[] LinearLayoutCompat_Layout;

			public static int LinearLayoutCompat_Layout_android_layout_gravity;

			public static int LinearLayoutCompat_Layout_android_layout_height;

			public static int LinearLayoutCompat_Layout_android_layout_weight;

			public static int LinearLayoutCompat_Layout_android_layout_width;

			public static int LinearLayoutCompat_measureWithLargestChild;

			public static int LinearLayoutCompat_showDividers;

			public static int[] ListPopupWindow;

			public static int ListPopupWindow_android_dropDownHorizontalOffset;

			public static int ListPopupWindow_android_dropDownVerticalOffset;

			public static int[] LoadingImageView;

			public static int LoadingImageView_circleCrop;

			public static int LoadingImageView_imageAspectRatio;

			public static int LoadingImageView_imageAspectRatioAdjust;

			public static int[] LoadingIndicatorDot;

			public static int LoadingIndicatorDot_dotTint;

			public static int[] LottieAnimationView;

			public static int LottieAnimationView_lottie_autoPlay;

			public static int LottieAnimationView_lottie_cacheComposition;

			public static int LottieAnimationView_lottie_colorFilter;

			public static int LottieAnimationView_lottie_enableMergePathsForKitKatAndAbove;

			public static int LottieAnimationView_lottie_fallbackRes;

			public static int LottieAnimationView_lottie_fileName;

			public static int LottieAnimationView_lottie_ignoreDisabledSystemAnimations;

			public static int LottieAnimationView_lottie_imageAssetsFolder;

			public static int LottieAnimationView_lottie_loop;

			public static int LottieAnimationView_lottie_progress;

			public static int LottieAnimationView_lottie_rawRes;

			public static int LottieAnimationView_lottie_renderMode;

			public static int LottieAnimationView_lottie_repeatCount;

			public static int LottieAnimationView_lottie_repeatMode;

			public static int LottieAnimationView_lottie_scale;

			public static int LottieAnimationView_lottie_speed;

			public static int LottieAnimationView_lottie_url;

			public static int[] MapAttrs;

			public static int MapAttrs_ambientEnabled;

			public static int MapAttrs_cameraBearing;

			public static int MapAttrs_cameraMaxZoomPreference;

			public static int MapAttrs_cameraMinZoomPreference;

			public static int MapAttrs_cameraTargetLat;

			public static int MapAttrs_cameraTargetLng;

			public static int MapAttrs_cameraTilt;

			public static int MapAttrs_cameraZoom;

			public static int MapAttrs_latLngBoundsNorthEastLatitude;

			public static int MapAttrs_latLngBoundsNorthEastLongitude;

			public static int MapAttrs_latLngBoundsSouthWestLatitude;

			public static int MapAttrs_latLngBoundsSouthWestLongitude;

			public static int MapAttrs_liteMode;

			public static int MapAttrs_mapType;

			public static int MapAttrs_uiCompass;

			public static int MapAttrs_uiMapToolbar;

			public static int MapAttrs_uiRotateGestures;

			public static int MapAttrs_uiScrollGestures;

			public static int MapAttrs_uiScrollGesturesDuringRotateOrZoom;

			public static int MapAttrs_uiTiltGestures;

			public static int MapAttrs_uiZoomControls;

			public static int MapAttrs_uiZoomGestures;

			public static int MapAttrs_useViewLifecycle;

			public static int MapAttrs_zOrderOnTop;

			public static int[] MaterialButton;

			public static int MaterialButton_android_insetBottom;

			public static int MaterialButton_android_insetLeft;

			public static int MaterialButton_android_insetRight;

			public static int MaterialButton_android_insetTop;

			public static int MaterialButton_backgroundTint;

			public static int MaterialButton_backgroundTintMode;

			public static int MaterialButton_cornerRadius;

			public static int MaterialButton_icon;

			public static int MaterialButton_iconGravity;

			public static int MaterialButton_iconPadding;

			public static int MaterialButton_iconSize;

			public static int MaterialButton_iconTint;

			public static int MaterialButton_iconTintMode;

			public static int MaterialButton_rippleColor;

			public static int MaterialButton_strokeColor;

			public static int MaterialButton_strokeWidth;

			public static int[] MaterialCardView;

			public static int MaterialCardView_strokeColor;

			public static int MaterialCardView_strokeWidth;

			public static int[] MaterialComponentsTheme;

			public static int MaterialComponentsTheme_bottomSheetDialogTheme;

			public static int MaterialComponentsTheme_bottomSheetStyle;

			public static int MaterialComponentsTheme_chipGroupStyle;

			public static int MaterialComponentsTheme_chipStandaloneStyle;

			public static int MaterialComponentsTheme_chipStyle;

			public static int MaterialComponentsTheme_colorAccent;

			public static int MaterialComponentsTheme_colorBackgroundFloating;

			public static int MaterialComponentsTheme_colorPrimary;

			public static int MaterialComponentsTheme_colorPrimaryDark;

			public static int MaterialComponentsTheme_colorSecondary;

			public static int MaterialComponentsTheme_editTextStyle;

			public static int MaterialComponentsTheme_floatingActionButtonStyle;

			public static int MaterialComponentsTheme_materialButtonStyle;

			public static int MaterialComponentsTheme_materialCardViewStyle;

			public static int MaterialComponentsTheme_navigationViewStyle;

			public static int MaterialComponentsTheme_scrimBackground;

			public static int MaterialComponentsTheme_snackbarButtonStyle;

			public static int MaterialComponentsTheme_tabStyle;

			public static int MaterialComponentsTheme_textAppearanceBody1;

			public static int MaterialComponentsTheme_textAppearanceBody2;

			public static int MaterialComponentsTheme_textAppearanceButton;

			public static int MaterialComponentsTheme_textAppearanceCaption;

			public static int MaterialComponentsTheme_textAppearanceHeadline1;

			public static int MaterialComponentsTheme_textAppearanceHeadline2;

			public static int MaterialComponentsTheme_textAppearanceHeadline3;

			public static int MaterialComponentsTheme_textAppearanceHeadline4;

			public static int MaterialComponentsTheme_textAppearanceHeadline5;

			public static int MaterialComponentsTheme_textAppearanceHeadline6;

			public static int MaterialComponentsTheme_textAppearanceOverline;

			public static int MaterialComponentsTheme_textAppearanceSubtitle1;

			public static int MaterialComponentsTheme_textAppearanceSubtitle2;

			public static int MaterialComponentsTheme_textInputStyle;

			public static int[] MenuGroup;

			public static int MenuGroup_android_checkableBehavior;

			public static int MenuGroup_android_enabled;

			public static int MenuGroup_android_id;

			public static int MenuGroup_android_menuCategory;

			public static int MenuGroup_android_orderInCategory;

			public static int MenuGroup_android_visible;

			public static int[] MenuItem;

			public static int MenuItem_actionLayout;

			public static int MenuItem_actionProviderClass;

			public static int MenuItem_actionViewClass;

			public static int MenuItem_alphabeticModifiers;

			public static int MenuItem_android_alphabeticShortcut;

			public static int MenuItem_android_checkable;

			public static int MenuItem_android_checked;

			public static int MenuItem_android_enabled;

			public static int MenuItem_android_icon;

			public static int MenuItem_android_id;

			public static int MenuItem_android_menuCategory;

			public static int MenuItem_android_numericShortcut;

			public static int MenuItem_android_onClick;

			public static int MenuItem_android_orderInCategory;

			public static int MenuItem_android_title;

			public static int MenuItem_android_titleCondensed;

			public static int MenuItem_android_visible;

			public static int MenuItem_contentDescription;

			public static int MenuItem_iconTint;

			public static int MenuItem_iconTintMode;

			public static int MenuItem_numericModifiers;

			public static int MenuItem_showAsAction;

			public static int MenuItem_tooltipText;

			public static int[] MenuView;

			public static int MenuView_android_headerBackground;

			public static int MenuView_android_horizontalDivider;

			public static int MenuView_android_itemBackground;

			public static int MenuView_android_itemIconDisabledAlpha;

			public static int MenuView_android_itemTextAppearance;

			public static int MenuView_android_verticalDivider;

			public static int MenuView_android_windowAnimationStyle;

			public static int MenuView_preserveIconSpacing;

			public static int MenuView_subMenuArrow;

			public static int[] MvxBinding;

			public static int MvxBinding_MvxBind;

			public static int MvxBinding_MvxLang;

			public static int[] MvxControl;

			public static int MvxControl_MvxTemplate;

			public static int[] MvxExpandableListView;

			public static int MvxExpandableListView_MvxGroupItemTemplate;

			public static int[] MvxImageView;

			public static int MvxImageView_MvxSource;

			public static int[] MvxListView;

			public static int MvxListView_MvxDropDownItemTemplate;

			public static int MvxListView_MvxItemTemplate;

			public static int[] NavigationView;

			public static int NavigationView_android_background;

			public static int NavigationView_android_fitsSystemWindows;

			public static int NavigationView_android_maxWidth;

			public static int NavigationView_elevation;

			public static int NavigationView_headerLayout;

			public static int NavigationView_itemBackground;

			public static int NavigationView_itemHorizontalPadding;

			public static int NavigationView_itemIconPadding;

			public static int NavigationView_itemIconTint;

			public static int NavigationView_itemTextAppearance;

			public static int NavigationView_itemTextColor;

			public static int NavigationView_menu;

			public static int[] PercentLayout_Layout;

			public static int PercentLayout_Layout_layout_aspectRatio;

			public static int PercentLayout_Layout_layout_heightPercent;

			public static int PercentLayout_Layout_layout_marginBottomPercent;

			public static int PercentLayout_Layout_layout_marginEndPercent;

			public static int PercentLayout_Layout_layout_marginLeftPercent;

			public static int PercentLayout_Layout_layout_marginPercent;

			public static int PercentLayout_Layout_layout_marginRightPercent;

			public static int PercentLayout_Layout_layout_marginStartPercent;

			public static int PercentLayout_Layout_layout_marginTopPercent;

			public static int PercentLayout_Layout_layout_widthPercent;

			public static int[] PlayerControlView;

			public static int PlayerControlView_ad_marker_color;

			public static int PlayerControlView_ad_marker_width;

			public static int PlayerControlView_bar_gravity;

			public static int PlayerControlView_bar_height;

			public static int PlayerControlView_buffered_color;

			public static int PlayerControlView_controller_layout_id;

			public static int PlayerControlView_fastforward_increment;

			public static int PlayerControlView_played_ad_marker_color;

			public static int PlayerControlView_played_color;

			public static int PlayerControlView_repeat_toggle_modes;

			public static int PlayerControlView_rewind_increment;

			public static int PlayerControlView_scrubber_color;

			public static int PlayerControlView_scrubber_disabled_size;

			public static int PlayerControlView_scrubber_dragged_size;

			public static int PlayerControlView_scrubber_drawable;

			public static int PlayerControlView_scrubber_enabled_size;

			public static int PlayerControlView_show_fastforward_button;

			public static int PlayerControlView_show_next_button;

			public static int PlayerControlView_show_previous_button;

			public static int PlayerControlView_show_rewind_button;

			public static int PlayerControlView_show_shuffle_button;

			public static int PlayerControlView_show_timeout;

			public static int PlayerControlView_time_bar_min_update_interval;

			public static int PlayerControlView_touch_target_height;

			public static int PlayerControlView_unplayed_color;

			public static int[] PlayerView;

			public static int PlayerView_ad_marker_color;

			public static int PlayerView_ad_marker_width;

			public static int PlayerView_auto_show;

			public static int PlayerView_bar_height;

			public static int PlayerView_buffered_color;

			public static int PlayerView_controller_layout_id;

			public static int PlayerView_default_artwork;

			public static int PlayerView_fastforward_increment;

			public static int PlayerView_hide_during_ads;

			public static int PlayerView_hide_on_touch;

			public static int PlayerView_keep_content_on_player_reset;

			public static int PlayerView_played_ad_marker_color;

			public static int PlayerView_played_color;

			public static int PlayerView_player_layout_id;

			public static int PlayerView_repeat_toggle_modes;

			public static int PlayerView_resize_mode;

			public static int PlayerView_rewind_increment;

			public static int PlayerView_scrubber_color;

			public static int PlayerView_scrubber_disabled_size;

			public static int PlayerView_scrubber_dragged_size;

			public static int PlayerView_scrubber_drawable;

			public static int PlayerView_scrubber_enabled_size;

			public static int PlayerView_show_buffering;

			public static int PlayerView_show_shuffle_button;

			public static int PlayerView_show_timeout;

			public static int PlayerView_shutter_background_color;

			public static int PlayerView_surface_type;

			public static int PlayerView_time_bar_min_update_interval;

			public static int PlayerView_touch_target_height;

			public static int PlayerView_unplayed_color;

			public static int PlayerView_use_artwork;

			public static int PlayerView_use_controller;

			public static int PlayerView_use_sensor_rotation;

			public static int[] PopupWindow;

			public static int[] PopupWindowBackgroundState;

			public static int PopupWindowBackgroundState_state_above_anchor;

			public static int PopupWindow_android_popupAnimationStyle;

			public static int PopupWindow_android_popupBackground;

			public static int PopupWindow_overlapAnchor;

			public static int[] PreLoginAngleBackgroundView;

			public static int PreLoginAngleBackgroundView_android_colorBackground;

			public static int PreLoginAngleBackgroundView_angle;

			public static int[] RatingControl;

			public static int RatingControl_android_textColor;

			public static int RatingControl_android_textSize;

			public static int RatingControl_barLeftOfLabel;

			public static int RatingControl_containerBackground;

			public static int RatingControl_containerPadding;

			public static int RatingControl_ratingBarCustomStyle;

			public static int RatingControl_ratingBarMarginStart;

			public static int RatingControl_typeface;

			public static int[] RecycleListView;

			public static int RecycleListView_paddingBottomNoButtons;

			public static int RecycleListView_paddingTopNoTitle;

			public static int[] RecyclerView;

			public static int RecyclerView_android_clipToPadding;

			public static int RecyclerView_android_descendantFocusability;

			public static int RecyclerView_android_orientation;

			public static int RecyclerView_fastScrollEnabled;

			public static int RecyclerView_fastScrollHorizontalThumbDrawable;

			public static int RecyclerView_fastScrollHorizontalTrackDrawable;

			public static int RecyclerView_fastScrollVerticalThumbDrawable;

			public static int RecyclerView_fastScrollVerticalTrackDrawable;

			public static int RecyclerView_layoutManager;

			public static int RecyclerView_reverseLayout;

			public static int RecyclerView_spanCount;

			public static int RecyclerView_stackFromEnd;

			public static int[] ScrimInsetsFrameLayout;

			public static int ScrimInsetsFrameLayout_insetForeground;

			public static int[] ScrollingViewBehavior_Layout;

			public static int ScrollingViewBehavior_Layout_behavior_overlapTop;

			public static int[] SearchView;

			public static int SearchView_android_focusable;

			public static int SearchView_android_imeOptions;

			public static int SearchView_android_inputType;

			public static int SearchView_android_maxWidth;

			public static int SearchView_closeIcon;

			public static int SearchView_commitIcon;

			public static int SearchView_defaultQueryHint;

			public static int SearchView_goIcon;

			public static int SearchView_iconifiedByDefault;

			public static int SearchView_layout;

			public static int SearchView_queryBackground;

			public static int SearchView_queryHint;

			public static int SearchView_searchHintIcon;

			public static int SearchView_searchIcon;

			public static int SearchView_submitBackground;

			public static int SearchView_suggestionRowLayout;

			public static int SearchView_voiceIcon;

			public static int[] ShireWKWebView;

			public static int ShireWKWebView_error_view_layout_resource;

			public static int[] SignInButton;

			public static int SignInButton_buttonSize;

			public static int SignInButton_colorScheme;

			public static int SignInButton_scopeUris;

			public static int[] Snackbar;

			public static int[] SnackbarLayout;

			public static int SnackbarLayout_android_maxWidth;

			public static int SnackbarLayout_elevation;

			public static int SnackbarLayout_maxActionInlineWidth;

			public static int Snackbar_snackbarButtonStyle;

			public static int Snackbar_snackbarStyle;

			public static int[] Spinner;

			public static int Spinner_android_dropDownWidth;

			public static int Spinner_android_entries;

			public static int Spinner_android_popupBackground;

			public static int Spinner_android_prompt;

			public static int Spinner_popupTheme;

			public static int[] SplitPairFilter;

			public static int SplitPairFilter_primaryActivityName;

			public static int SplitPairFilter_secondaryActivityAction;

			public static int SplitPairFilter_secondaryActivityName;

			public static int[] SplitPairRule;

			public static int SplitPairRule_clearTop;

			public static int SplitPairRule_finishPrimaryWithSecondary;

			public static int SplitPairRule_finishSecondaryWithPrimary;

			public static int SplitPairRule_splitLayoutDirection;

			public static int SplitPairRule_splitMinSmallestWidth;

			public static int SplitPairRule_splitMinWidth;

			public static int SplitPairRule_splitRatio;

			public static int[] SplitPlaceholderRule;

			public static int SplitPlaceholderRule_placeholderActivityName;

			public static int SplitPlaceholderRule_splitLayoutDirection;

			public static int SplitPlaceholderRule_splitMinSmallestWidth;

			public static int SplitPlaceholderRule_splitMinWidth;

			public static int SplitPlaceholderRule_splitRatio;

			public static int[] StateListDrawable;

			public static int[] StateListDrawableItem;

			public static int StateListDrawableItem_android_drawable;

			public static int StateListDrawable_android_constantSize;

			public static int StateListDrawable_android_dither;

			public static int StateListDrawable_android_enterFadeDuration;

			public static int StateListDrawable_android_exitFadeDuration;

			public static int StateListDrawable_android_variablePadding;

			public static int StateListDrawable_android_visible;

			public static int[] StyledPlayerControlView;

			public static int StyledPlayerControlView_ad_marker_color;

			public static int StyledPlayerControlView_ad_marker_width;

			public static int StyledPlayerControlView_animation_enabled;

			public static int StyledPlayerControlView_bar_gravity;

			public static int StyledPlayerControlView_bar_height;

			public static int StyledPlayerControlView_buffered_color;

			public static int StyledPlayerControlView_controller_layout_id;

			public static int StyledPlayerControlView_fastforward_increment;

			public static int StyledPlayerControlView_played_ad_marker_color;

			public static int StyledPlayerControlView_played_color;

			public static int StyledPlayerControlView_repeat_toggle_modes;

			public static int StyledPlayerControlView_rewind_increment;

			public static int StyledPlayerControlView_scrubber_color;

			public static int StyledPlayerControlView_scrubber_disabled_size;

			public static int StyledPlayerControlView_scrubber_dragged_size;

			public static int StyledPlayerControlView_scrubber_drawable;

			public static int StyledPlayerControlView_scrubber_enabled_size;

			public static int StyledPlayerControlView_show_fastforward_button;

			public static int StyledPlayerControlView_show_next_button;

			public static int StyledPlayerControlView_show_previous_button;

			public static int StyledPlayerControlView_show_rewind_button;

			public static int StyledPlayerControlView_show_shuffle_button;

			public static int StyledPlayerControlView_show_subtitle_button;

			public static int StyledPlayerControlView_show_timeout;

			public static int StyledPlayerControlView_show_vr_button;

			public static int StyledPlayerControlView_time_bar_min_update_interval;

			public static int StyledPlayerControlView_touch_target_height;

			public static int StyledPlayerControlView_unplayed_color;

			public static int[] StyledPlayerView;

			public static int StyledPlayerView_ad_marker_color;

			public static int StyledPlayerView_ad_marker_width;

			public static int StyledPlayerView_animation_enabled;

			public static int StyledPlayerView_auto_show;

			public static int StyledPlayerView_bar_gravity;

			public static int StyledPlayerView_bar_height;

			public static int StyledPlayerView_buffered_color;

			public static int StyledPlayerView_controller_layout_id;

			public static int StyledPlayerView_default_artwork;

			public static int StyledPlayerView_fastforward_increment;

			public static int StyledPlayerView_hide_during_ads;

			public static int StyledPlayerView_hide_on_touch;

			public static int StyledPlayerView_keep_content_on_player_reset;

			public static int StyledPlayerView_played_ad_marker_color;

			public static int StyledPlayerView_played_color;

			public static int StyledPlayerView_player_layout_id;

			public static int StyledPlayerView_repeat_toggle_modes;

			public static int StyledPlayerView_resize_mode;

			public static int StyledPlayerView_rewind_increment;

			public static int StyledPlayerView_scrubber_color;

			public static int StyledPlayerView_scrubber_disabled_size;

			public static int StyledPlayerView_scrubber_dragged_size;

			public static int StyledPlayerView_scrubber_drawable;

			public static int StyledPlayerView_scrubber_enabled_size;

			public static int StyledPlayerView_show_buffering;

			public static int StyledPlayerView_show_shuffle_button;

			public static int StyledPlayerView_show_subtitle_button;

			public static int StyledPlayerView_show_timeout;

			public static int StyledPlayerView_show_vr_button;

			public static int StyledPlayerView_shutter_background_color;

			public static int StyledPlayerView_surface_type;

			public static int StyledPlayerView_time_bar_min_update_interval;

			public static int StyledPlayerView_touch_target_height;

			public static int StyledPlayerView_unplayed_color;

			public static int StyledPlayerView_use_artwork;

			public static int StyledPlayerView_use_controller;

			public static int StyledPlayerView_use_sensor_rotation;

			public static int[] SwipeRefreshLayout;

			public static int SwipeRefreshLayout_swipeRefreshLayoutProgressSpinnerBackgroundColor;

			public static int[] SwitchCompat;

			public static int SwitchCompat_android_textOff;

			public static int SwitchCompat_android_textOn;

			public static int SwitchCompat_android_thumb;

			public static int SwitchCompat_showText;

			public static int SwitchCompat_splitTrack;

			public static int SwitchCompat_switchMinWidth;

			public static int SwitchCompat_switchPadding;

			public static int SwitchCompat_switchTextAppearance;

			public static int SwitchCompat_thumbTextPadding;

			public static int SwitchCompat_thumbTint;

			public static int SwitchCompat_thumbTintMode;

			public static int SwitchCompat_track;

			public static int SwitchCompat_trackTint;

			public static int SwitchCompat_trackTintMode;

			public static int[] TabItem;

			public static int TabItem_android_icon;

			public static int TabItem_android_layout;

			public static int TabItem_android_text;

			public static int[] TabLayout;

			public static int TabLayout_tabBackground;

			public static int TabLayout_tabContentStart;

			public static int TabLayout_tabGravity;

			public static int TabLayout_tabIconTint;

			public static int TabLayout_tabIconTintMode;

			public static int TabLayout_tabIndicator;

			public static int TabLayout_tabIndicatorAnimationDuration;

			public static int TabLayout_tabIndicatorColor;

			public static int TabLayout_tabIndicatorFullWidth;

			public static int TabLayout_tabIndicatorGravity;

			public static int TabLayout_tabIndicatorHeight;

			public static int TabLayout_tabInlineLabel;

			public static int TabLayout_tabMaxWidth;

			public static int TabLayout_tabMinWidth;

			public static int TabLayout_tabMode;

			public static int TabLayout_tabPadding;

			public static int TabLayout_tabPaddingBottom;

			public static int TabLayout_tabPaddingEnd;

			public static int TabLayout_tabPaddingStart;

			public static int TabLayout_tabPaddingTop;

			public static int TabLayout_tabRippleColor;

			public static int TabLayout_tabSelectedTextColor;

			public static int TabLayout_tabTextAppearance;

			public static int TabLayout_tabTextColor;

			public static int TabLayout_tabUnboundedRipple;

			public static int[] TextAppearance;

			public static int TextAppearance_android_fontFamily;

			public static int TextAppearance_android_shadowColor;

			public static int TextAppearance_android_shadowDx;

			public static int TextAppearance_android_shadowDy;

			public static int TextAppearance_android_shadowRadius;

			public static int TextAppearance_android_textColor;

			public static int TextAppearance_android_textColorHint;

			public static int TextAppearance_android_textColorLink;

			public static int TextAppearance_android_textFontWeight;

			public static int TextAppearance_android_textSize;

			public static int TextAppearance_android_textStyle;

			public static int TextAppearance_android_typeface;

			public static int TextAppearance_fontFamily;

			public static int TextAppearance_fontVariationSettings;

			public static int TextAppearance_textAllCaps;

			public static int TextAppearance_textLocale;

			public static int[] TextInputLayout;

			public static int TextInputLayout_android_hint;

			public static int TextInputLayout_android_textColorHint;

			public static int TextInputLayout_boxBackgroundColor;

			public static int TextInputLayout_boxBackgroundMode;

			public static int TextInputLayout_boxCollapsedPaddingTop;

			public static int TextInputLayout_boxCornerRadiusBottomEnd;

			public static int TextInputLayout_boxCornerRadiusBottomStart;

			public static int TextInputLayout_boxCornerRadiusTopEnd;

			public static int TextInputLayout_boxCornerRadiusTopStart;

			public static int TextInputLayout_boxStrokeColor;

			public static int TextInputLayout_boxStrokeWidth;

			public static int TextInputLayout_counterEnabled;

			public static int TextInputLayout_counterMaxLength;

			public static int TextInputLayout_counterOverflowTextAppearance;

			public static int TextInputLayout_counterTextAppearance;

			public static int TextInputLayout_errorEnabled;

			public static int TextInputLayout_errorTextAppearance;

			public static int TextInputLayout_helperText;

			public static int TextInputLayout_helperTextEnabled;

			public static int TextInputLayout_helperTextTextAppearance;

			public static int TextInputLayout_hintAnimationEnabled;

			public static int TextInputLayout_hintEnabled;

			public static int TextInputLayout_hintTextAppearance;

			public static int TextInputLayout_passwordToggleContentDescription;

			public static int TextInputLayout_passwordToggleDrawable;

			public static int TextInputLayout_passwordToggleEnabled;

			public static int TextInputLayout_passwordToggleTint;

			public static int TextInputLayout_passwordToggleTintMode;

			public static int[] ThemeEnforcement;

			public static int ThemeEnforcement_android_textAppearance;

			public static int ThemeEnforcement_enforceMaterialTheme;

			public static int ThemeEnforcement_enforceTextAppearance;

			public static int[] Toolbar;

			public static int Toolbar_android_gravity;

			public static int Toolbar_android_minHeight;

			public static int Toolbar_buttonGravity;

			public static int Toolbar_collapseContentDescription;

			public static int Toolbar_collapseIcon;

			public static int Toolbar_contentInsetEnd;

			public static int Toolbar_contentInsetEndWithActions;

			public static int Toolbar_contentInsetLeft;

			public static int Toolbar_contentInsetRight;

			public static int Toolbar_contentInsetStart;

			public static int Toolbar_contentInsetStartWithNavigation;

			public static int Toolbar_logo;

			public static int Toolbar_logoDescription;

			public static int Toolbar_maxButtonHeight;

			public static int Toolbar_menu;

			public static int Toolbar_navigationContentDescription;

			public static int Toolbar_navigationIcon;

			public static int Toolbar_popupTheme;

			public static int Toolbar_subtitle;

			public static int Toolbar_subtitleTextAppearance;

			public static int Toolbar_subtitleTextColor;

			public static int Toolbar_title;

			public static int Toolbar_titleMargin;

			public static int Toolbar_titleMarginBottom;

			public static int Toolbar_titleMarginEnd;

			public static int Toolbar_titleMargins;

			public static int Toolbar_titleMarginStart;

			public static int Toolbar_titleMarginTop;

			public static int Toolbar_titleTextAppearance;

			public static int Toolbar_titleTextColor;

			public static int[] View;

			public static int[] ViewBackgroundHelper;

			public static int ViewBackgroundHelper_android_background;

			public static int ViewBackgroundHelper_backgroundTint;

			public static int ViewBackgroundHelper_backgroundTintMode;

			public static int[] ViewStubCompat;

			public static int ViewStubCompat_android_id;

			public static int ViewStubCompat_android_inflatedId;

			public static int ViewStubCompat_android_layout;

			public static int View_android_focusable;

			public static int View_android_theme;

			public static int View_paddingEnd;

			public static int View_paddingStart;

			public static int View_theme;

			public static int[] WifiImageButton;

			public static int WifiImageButton_ConnectedNoInternet;

			public static int WifiImageButton_ConnectedStrong;

			public static int WifiImageButton_ConnectedStrongest;

			public static int WifiImageButton_ConnectedStrongestLocked;

			public static int WifiImageButton_ConnectedStrongLocked;

			public static int WifiImageButton_ConnectedWeak;

			public static int WifiImageButton_ConnectedWeakest;

			public static int WifiImageButton_ConnectedWeakLocked;

			public static int WifiImageButton_Disabled;

			public static int WifiImageButton_EnabledNotConnected;

			public static int WifiImageButton_Unknown;

			static Styleable()
			{
				ActionBar = new int[29]
				{
					2130968655, 2130968657, 2130968658, 2130968788, 2130968789, 2130968790, 2130968791, 2130968792, 2130968793, 2130968809,
					2130968816, 2130968817, 2130968838, 2130968886, 2130968891, 2130968898, 2130968899, 2130968901, 2130968913, 2130968923,
					2130968979, 2130969010, 2130969032, 2130969037, 2130969038, 2130969116, 2130969119, 2130969192, 2130969202
				};
				ActionBarLayout = new int[1] { 16842931 };
				ActionBarLayout_android_layout_gravity = 0;
				ActionBar_background = 0;
				ActionBar_backgroundSplit = 1;
				ActionBar_backgroundStacked = 2;
				ActionBar_contentInsetEnd = 3;
				ActionBar_contentInsetEndWithActions = 4;
				ActionBar_contentInsetLeft = 5;
				ActionBar_contentInsetRight = 6;
				ActionBar_contentInsetStart = 7;
				ActionBar_contentInsetStartWithNavigation = 8;
				ActionBar_customNavigationLayout = 9;
				ActionBar_displayOptions = 10;
				ActionBar_divider = 11;
				ActionBar_elevation = 12;
				ActionBar_height = 13;
				ActionBar_hideOnContentScroll = 14;
				ActionBar_homeAsUpIndicator = 15;
				ActionBar_homeLayout = 16;
				ActionBar_icon = 17;
				ActionBar_indeterminateProgressStyle = 18;
				ActionBar_itemPadding = 19;
				ActionBar_logo = 20;
				ActionBar_navigationMode = 21;
				ActionBar_popupTheme = 22;
				ActionBar_progressBarPadding = 23;
				ActionBar_progressBarStyle = 24;
				ActionBar_subtitle = 25;
				ActionBar_subtitleTextStyle = 26;
				ActionBar_title = 27;
				ActionBar_titleTextStyle = 28;
				ActionMenuItemView = new int[1] { 16843071 };
				ActionMenuItemView_android_minWidth = 0;
				ActionMenuView = new int[1] { -1 };
				ActionMode = new int[6] { 2130968655, 2130968657, 2130968752, 2130968886, 2130969119, 2130969202 };
				ActionMode_background = 0;
				ActionMode_backgroundSplit = 1;
				ActionMode_closeItemLayout = 2;
				ActionMode_height = 3;
				ActionMode_subtitleTextStyle = 4;
				ActionMode_titleTextStyle = 5;
				ActivityChooserView = new int[2] { 2130968844, 2130968914 };
				ActivityChooserView_expandActivityOverflowButtonDrawable = 0;
				ActivityChooserView_initialActivityCount = 1;
				ActivityFilter = new int[2] { 2130968629, 2130968631 };
				ActivityFilter_activityAction = 0;
				ActivityFilter_activityName = 1;
				ActivityRule = new int[1] { 2130968641 };
				ActivityRule_alwaysExpand = 0;
				AlertDialog = new int[8] { 16842994, 2130968694, 2130968695, 2130968967, 2130968968, 2130969007, 2130969077, 2130969088 };
				AlertDialog_android_layout = 0;
				AlertDialog_buttonIconDimen = 1;
				AlertDialog_buttonPanelSideLayout = 2;
				AlertDialog_listItemLayout = 3;
				AlertDialog_listLayout = 4;
				AlertDialog_multiChoiceItemLayout = 5;
				AlertDialog_showTitle = 6;
				AlertDialog_singleChoiceItemLayout = 7;
				AnimatedStateListDrawableCompat = new int[6] { 16843036, 16843156, 16843157, 16843158, 16843532, 16843533 };
				AnimatedStateListDrawableCompat_android_constantSize = 3;
				AnimatedStateListDrawableCompat_android_dither = 0;
				AnimatedStateListDrawableCompat_android_enterFadeDuration = 4;
				AnimatedStateListDrawableCompat_android_exitFadeDuration = 5;
				AnimatedStateListDrawableCompat_android_variablePadding = 2;
				AnimatedStateListDrawableCompat_android_visible = 1;
				AnimatedStateListDrawableItem = new int[2] { 16842960, 16843161 };
				AnimatedStateListDrawableItem_android_drawable = 1;
				AnimatedStateListDrawableItem_android_id = 0;
				AnimatedStateListDrawableTransition = new int[4] { 16843161, 16843849, 16843850, 16843851 };
				AnimatedStateListDrawableTransition_android_drawable = 0;
				AnimatedStateListDrawableTransition_android_fromId = 2;
				AnimatedStateListDrawableTransition_android_reversible = 3;
				AnimatedStateListDrawableTransition_android_toId = 1;
				AppBarLayout = new int[6] { 16842964, 16843919, 16844096, 2130968838, 2130968845, 2130968960 };
				AppBarLayoutStates = new int[4] { 2130969106, 2130969107, 2130969108, 2130969109 };
				AppBarLayoutStates_state_collapsed = 0;
				AppBarLayoutStates_state_collapsible = 1;
				AppBarLayoutStates_state_liftable = 2;
				AppBarLayoutStates_state_lifted = 3;
				AppBarLayout_android_background = 0;
				AppBarLayout_android_keyboardNavigationCluster = 2;
				AppBarLayout_android_touchscreenBlocksFocus = 1;
				AppBarLayout_elevation = 3;
				AppBarLayout_expanded = 4;
				AppBarLayout_Layout = new int[2] { 2130968957, 2130968958 };
				AppBarLayout_Layout_layout_scrollFlags = 0;
				AppBarLayout_Layout_layout_scrollInterpolator = 1;
				AppBarLayout_liftOnScroll = 5;
				AppCompatImageView = new int[4] { 16843033, 2130969103, 2130969190, 2130969191 };
				AppCompatImageView_android_src = 0;
				AppCompatImageView_srcCompat = 1;
				AppCompatImageView_tint = 2;
				AppCompatImageView_tintMode = 3;
				AppCompatSeekBar = new int[4] { 16843074, 2130969186, 2130969187, 2130969188 };
				AppCompatSeekBar_android_thumb = 0;
				AppCompatSeekBar_tickMark = 1;
				AppCompatSeekBar_tickMarkTint = 2;
				AppCompatSeekBar_tickMarkTintMode = 3;
				AppCompatTextHelper = new int[7] { 16842804, 16843117, 16843118, 16843119, 16843120, 16843666, 16843667 };
				AppCompatTextHelper_android_drawableBottom = 2;
				AppCompatTextHelper_android_drawableEnd = 6;
				AppCompatTextHelper_android_drawableLeft = 3;
				AppCompatTextHelper_android_drawableRight = 4;
				AppCompatTextHelper_android_drawableStart = 5;
				AppCompatTextHelper_android_drawableTop = 1;
				AppCompatTextHelper_android_textAppearance = 0;
				AppCompatTextView = new int[21]
				{
					16842804, 2130968649, 2130968650, 2130968651, 2130968652, 2130968653, 2130968822, 2130968823, 2130968824, 2130968825,
					2130968827, 2130968828, 2130968829, 2130968830, 2130968867, 2130968870, 2130968879, 2130968933, 2130968961, 2130969153,
					2130969179
				};
				AppCompatTextView_android_textAppearance = 0;
				AppCompatTextView_autoSizeMaxTextSize = 1;
				AppCompatTextView_autoSizeMinTextSize = 2;
				AppCompatTextView_autoSizePresetSizes = 3;
				AppCompatTextView_autoSizeStepGranularity = 4;
				AppCompatTextView_autoSizeTextType = 5;
				AppCompatTextView_drawableBottomCompat = 6;
				AppCompatTextView_drawableEndCompat = 7;
				AppCompatTextView_drawableLeftCompat = 8;
				AppCompatTextView_drawableRightCompat = 9;
				AppCompatTextView_drawableStartCompat = 10;
				AppCompatTextView_drawableTint = 11;
				AppCompatTextView_drawableTintMode = 12;
				AppCompatTextView_drawableTopCompat = 13;
				AppCompatTextView_firstBaselineToTopHeight = 14;
				AppCompatTextView_fontFamily = 15;
				AppCompatTextView_fontVariationSettings = 16;
				AppCompatTextView_lastBaselineToBottomHeight = 17;
				AppCompatTextView_lineHeight = 18;
				AppCompatTextView_textAllCaps = 19;
				AppCompatTextView_textLocale = 20;
				AppCompatTheme = new int[127]
				{
					16842839, 16842926, 2130968594, 2130968595, 2130968596, 2130968597, 2130968598, 2130968599, 2130968600, 2130968601,
					2130968602, 2130968603, 2130968604, 2130968605, 2130968606, 2130968608, 2130968609, 2130968610, 2130968611, 2130968612,
					2130968613, 2130968614, 2130968615, 2130968616, 2130968617, 2130968618, 2130968619, 2130968620, 2130968621, 2130968622,
					2130968623, 2130968624, 2130968625, 2130968626, 2130968630, 2130968634, 2130968635, 2130968636, 2130968637, 2130968647,
					2130968672, 2130968687, 2130968688, 2130968689, 2130968690, 2130968691, 2130968697, 2130968698, 2130968715, 2130968720,
					2130968758, 2130968759, 2130968760, 2130968761, 2130968762, 2130968763, 2130968764, 2130968765, 2130968766, 2130968769,
					2130968800, 2130968813, 2130968814, 2130968815, 2130968818, 2130968820, 2130968833, 2130968834, 2130968835, 2130968836,
					2130968837, 2130968898, 2130968912, 2130968963, 2130968964, 2130968965, 2130968966, 2130968969, 2130968970, 2130968971,
					2130968972, 2130968973, 2130968974, 2130968975, 2130968976, 2130968977, 2130969019, 2130969020, 2130969021, 2130969031,
					2130969033, 2130969042, 2130969045, 2130969046, 2130969047, 2130969065, 2130969068, 2130969069, 2130969070, 2130969096,
					2130969097, 2130969125, 2130969164, 2130969165, 2130969166, 2130969167, 2130969169, 2130969170, 2130969171, 2130969172,
					2130969175, 2130969176, 2130969204, 2130969205, 2130969206, 2130969207, 2130969229, 2130969231, 2130969232, 2130969233,
					2130969234, 2130969235, 2130969236, 2130969237, 2130969238, 2130969239, 2130969240
				};
				AppCompatTheme_actionBarDivider = 2;
				AppCompatTheme_actionBarItemBackground = 3;
				AppCompatTheme_actionBarPopupTheme = 4;
				AppCompatTheme_actionBarSize = 5;
				AppCompatTheme_actionBarSplitStyle = 6;
				AppCompatTheme_actionBarStyle = 7;
				AppCompatTheme_actionBarTabBarStyle = 8;
				AppCompatTheme_actionBarTabStyle = 9;
				AppCompatTheme_actionBarTabTextStyle = 10;
				AppCompatTheme_actionBarTheme = 11;
				AppCompatTheme_actionBarWidgetTheme = 12;
				AppCompatTheme_actionButtonStyle = 13;
				AppCompatTheme_actionDropDownStyle = 14;
				AppCompatTheme_actionMenuTextAppearance = 15;
				AppCompatTheme_actionMenuTextColor = 16;
				AppCompatTheme_actionModeBackground = 17;
				AppCompatTheme_actionModeCloseButtonStyle = 18;
				AppCompatTheme_actionModeCloseContentDescription = 19;
				AppCompatTheme_actionModeCloseDrawable = 20;
				AppCompatTheme_actionModeCopyDrawable = 21;
				AppCompatTheme_actionModeCutDrawable = 22;
				AppCompatTheme_actionModeFindDrawable = 23;
				AppCompatTheme_actionModePasteDrawable = 24;
				AppCompatTheme_actionModePopupWindowStyle = 25;
				AppCompatTheme_actionModeSelectAllDrawable = 26;
				AppCompatTheme_actionModeShareDrawable = 27;
				AppCompatTheme_actionModeSplitBackground = 28;
				AppCompatTheme_actionModeStyle = 29;
				AppCompatTheme_actionModeTheme = 30;
				AppCompatTheme_actionModeWebSearchDrawable = 31;
				AppCompatTheme_actionOverflowButtonStyle = 32;
				AppCompatTheme_actionOverflowMenuStyle = 33;
				AppCompatTheme_activityChooserViewStyle = 34;
				AppCompatTheme_alertDialogButtonGroupStyle = 35;
				AppCompatTheme_alertDialogCenterButtons = 36;
				AppCompatTheme_alertDialogStyle = 37;
				AppCompatTheme_alertDialogTheme = 38;
				AppCompatTheme_android_windowAnimationStyle = 1;
				AppCompatTheme_android_windowIsFloating = 0;
				AppCompatTheme_autoCompleteTextViewStyle = 39;
				AppCompatTheme_borderlessButtonStyle = 40;
				AppCompatTheme_buttonBarButtonStyle = 41;
				AppCompatTheme_buttonBarNegativeButtonStyle = 42;
				AppCompatTheme_buttonBarNeutralButtonStyle = 43;
				AppCompatTheme_buttonBarPositiveButtonStyle = 44;
				AppCompatTheme_buttonBarStyle = 45;
				AppCompatTheme_buttonStyle = 46;
				AppCompatTheme_buttonStyleSmall = 47;
				AppCompatTheme_checkboxStyle = 48;
				AppCompatTheme_checkedTextViewStyle = 49;
				AppCompatTheme_colorAccent = 50;
				AppCompatTheme_colorBackgroundFloating = 51;
				AppCompatTheme_colorButtonNormal = 52;
				AppCompatTheme_colorControlActivated = 53;
				AppCompatTheme_colorControlHighlight = 54;
				AppCompatTheme_colorControlNormal = 55;
				AppCompatTheme_colorError = 56;
				AppCompatTheme_colorPrimary = 57;
				AppCompatTheme_colorPrimaryDark = 58;
				AppCompatTheme_colorSwitchThumbNormal = 59;
				AppCompatTheme_controlBackground = 60;
				AppCompatTheme_dialogCornerRadius = 61;
				AppCompatTheme_dialogPreferredPadding = 62;
				AppCompatTheme_dialogTheme = 63;
				AppCompatTheme_dividerHorizontal = 64;
				AppCompatTheme_dividerVertical = 65;
				AppCompatTheme_dropdownListPreferredItemHeight = 67;
				AppCompatTheme_dropDownListViewStyle = 66;
				AppCompatTheme_editTextBackground = 68;
				AppCompatTheme_editTextColor = 69;
				AppCompatTheme_editTextStyle = 70;
				AppCompatTheme_homeAsUpIndicator = 71;
				AppCompatTheme_imageButtonStyle = 72;
				AppCompatTheme_listChoiceBackgroundIndicator = 73;
				AppCompatTheme_listChoiceIndicatorMultipleAnimated = 74;
				AppCompatTheme_listChoiceIndicatorSingleAnimated = 75;
				AppCompatTheme_listDividerAlertDialog = 76;
				AppCompatTheme_listMenuViewStyle = 77;
				AppCompatTheme_listPopupWindowStyle = 78;
				AppCompatTheme_listPreferredItemHeight = 79;
				AppCompatTheme_listPreferredItemHeightLarge = 80;
				AppCompatTheme_listPreferredItemHeightSmall = 81;
				AppCompatTheme_listPreferredItemPaddingEnd = 82;
				AppCompatTheme_listPreferredItemPaddingLeft = 83;
				AppCompatTheme_listPreferredItemPaddingRight = 84;
				AppCompatTheme_listPreferredItemPaddingStart = 85;
				AppCompatTheme_panelBackground = 86;
				AppCompatTheme_panelMenuListTheme = 87;
				AppCompatTheme_panelMenuListWidth = 88;
				AppCompatTheme_popupMenuStyle = 89;
				AppCompatTheme_popupWindowStyle = 90;
				AppCompatTheme_radioButtonStyle = 91;
				AppCompatTheme_ratingBarStyle = 92;
				AppCompatTheme_ratingBarStyleIndicator = 93;
				AppCompatTheme_ratingBarStyleSmall = 94;
				AppCompatTheme_searchViewStyle = 95;
				AppCompatTheme_seekBarStyle = 96;
				AppCompatTheme_selectableItemBackground = 97;
				AppCompatTheme_selectableItemBackgroundBorderless = 98;
				AppCompatTheme_spinnerDropDownItemStyle = 99;
				AppCompatTheme_spinnerStyle = 100;
				AppCompatTheme_switchStyle = 101;
				AppCompatTheme_textAppearanceLargePopupMenu = 102;
				AppCompatTheme_textAppearanceListItem = 103;
				AppCompatTheme_textAppearanceListItemSecondary = 104;
				AppCompatTheme_textAppearanceListItemSmall = 105;
				AppCompatTheme_textAppearancePopupMenuHeader = 106;
				AppCompatTheme_textAppearanceSearchResultSubtitle = 107;
				AppCompatTheme_textAppearanceSearchResultTitle = 108;
				AppCompatTheme_textAppearanceSmallPopupMenu = 109;
				AppCompatTheme_textColorAlertDialogListItem = 110;
				AppCompatTheme_textColorSearchUrl = 111;
				AppCompatTheme_toolbarNavigationButtonStyle = 112;
				AppCompatTheme_toolbarStyle = 113;
				AppCompatTheme_tooltipForegroundColor = 114;
				AppCompatTheme_tooltipFrameBackground = 115;
				AppCompatTheme_viewInflaterClass = 116;
				AppCompatTheme_windowActionBar = 117;
				AppCompatTheme_windowActionBarOverlay = 118;
				AppCompatTheme_windowActionModeOverlay = 119;
				AppCompatTheme_windowFixedHeightMajor = 120;
				AppCompatTheme_windowFixedHeightMinor = 121;
				AppCompatTheme_windowFixedWidthMajor = 122;
				AppCompatTheme_windowFixedWidthMinor = 123;
				AppCompatTheme_windowMinWidthMajor = 124;
				AppCompatTheme_windowMinWidthMinor = 125;
				AppCompatTheme_windowNoTitle = 126;
				AspectRatioFrameLayout = new int[1] { 2130969050 };
				AspectRatioFrameLayout_resize_mode = 0;
				BetterImageView = new int[3] { 2130968808, 2130968811, 2130969074 };
				BetterImageView_cropByteArray = 0;
				BetterImageView_defaultResource = 1;
				BetterImageView_showLoadingAnimation = 2;
				BottomAppBar = new int[6] { 2130968659, 2130968853, 2130968854, 2130968855, 2130968856, 2130968892 };
				BottomAppBar_backgroundTint = 0;
				BottomAppBar_fabAlignmentMode = 1;
				BottomAppBar_fabCradleMargin = 2;
				BottomAppBar_fabCradleRoundedCornerRadius = 3;
				BottomAppBar_fabCradleVerticalOffset = 4;
				BottomAppBar_hideOnScroll = 5;
				BottomNavigationView = new int[10] { 2130968838, 2130968917, 2130968919, 2130968921, 2130968922, 2130968926, 2130968927, 2130968928, 2130968932, 2130969006 };
				BottomNavigationView_elevation = 0;
				BottomNavigationView_itemBackground = 1;
				BottomNavigationView_itemHorizontalTranslationEnabled = 2;
				BottomNavigationView_itemIconSize = 3;
				BottomNavigationView_itemIconTint = 4;
				BottomNavigationView_itemTextAppearanceActive = 5;
				BottomNavigationView_itemTextAppearanceInactive = 6;
				BottomNavigationView_itemTextColor = 7;
				BottomNavigationView_labelVisibilityMode = 8;
				BottomNavigationView_menu = 9;
				BottomSheetBehavior_Layout = new int[4] { 2130968666, 2130968667, 2130968669, 2130968670 };
				BottomSheetBehavior_Layout_behavior_fitToContents = 0;
				BottomSheetBehavior_Layout_behavior_hideable = 1;
				BottomSheetBehavior_Layout_behavior_peekHeight = 2;
				BottomSheetBehavior_Layout_behavior_skipCollapsed = 3;
				ButtonBarLayout = new int[1] { 2130968638 };
				ButtonBarLayout_allowStacking = 0;
				Capability = new int[2] { 2130969041, 2130969071 };
				Capability_queryPatterns = 0;
				Capability_shortcutMatchRequired = 1;
				CardView = new int[13]
				{
					16843071, 16843072, 2130968708, 2130968709, 2130968710, 2130968711, 2130968712, 2130968713, 2130968794, 2130968795,
					2130968796, 2130968797, 2130968798
				};
				CardView_android_minHeight = 1;
				CardView_android_minWidth = 0;
				CardView_cardBackgroundColor = 2;
				CardView_cardCornerRadius = 3;
				CardView_cardElevation = 4;
				CardView_cardMaxElevation = 5;
				CardView_cardPreventCornerOverlap = 6;
				CardView_cardUseCompatPadding = 7;
				CardView_contentPadding = 8;
				CardView_contentPaddingBottom = 9;
				CardView_contentPaddingLeft = 10;
				CardView_contentPaddingRight = 11;
				CardView_contentPaddingTop = 12;
				Chip = new int[34]
				{
					16842804, 16842923, 16843039, 16843087, 16843237, 2130968717, 2130968718, 2130968719, 2130968721, 2130968722,
					2130968723, 2130968725, 2130968726, 2130968727, 2130968728, 2130968729, 2130968730, 2130968735, 2130968736, 2130968737,
					2130968745, 2130968746, 2130968747, 2130968748, 2130968749, 2130968750, 2130968751, 2130968890, 2130968902, 2130968906,
					2130969053, 2130969075, 2130969177, 2130969180
				};
				ChipGroup = new int[6] { 2130968716, 2130968731, 2130968732, 2130968733, 2130969090, 2130969091 };
				ChipGroup_checkedChip = 0;
				ChipGroup_chipSpacing = 1;
				ChipGroup_chipSpacingHorizontal = 2;
				ChipGroup_chipSpacingVertical = 3;
				ChipGroup_singleLine = 4;
				ChipGroup_singleSelection = 5;
				Chip_android_checkable = 4;
				Chip_android_ellipsize = 1;
				Chip_android_maxWidth = 2;
				Chip_android_text = 3;
				Chip_android_textAppearance = 0;
				Chip_checkedIcon = 5;
				Chip_checkedIconEnabled = 6;
				Chip_checkedIconVisible = 7;
				Chip_chipBackgroundColor = 8;
				Chip_chipCornerRadius = 9;
				Chip_chipEndPadding = 10;
				Chip_chipIcon = 11;
				Chip_chipIconEnabled = 12;
				Chip_chipIconSize = 13;
				Chip_chipIconTint = 14;
				Chip_chipIconVisible = 15;
				Chip_chipMinHeight = 16;
				Chip_chipStartPadding = 17;
				Chip_chipStrokeColor = 18;
				Chip_chipStrokeWidth = 19;
				Chip_closeIcon = 20;
				Chip_closeIconEnabled = 21;
				Chip_closeIconEndPadding = 22;
				Chip_closeIconSize = 23;
				Chip_closeIconStartPadding = 24;
				Chip_closeIconTint = 25;
				Chip_closeIconVisible = 26;
				Chip_hideMotionSpec = 27;
				Chip_iconEndPadding = 28;
				Chip_iconStartPadding = 29;
				Chip_rippleColor = 30;
				Chip_showMotionSpec = 31;
				Chip_textEndPadding = 32;
				Chip_textStartPadding = 33;
				CircleImageView = new int[4] { 2130968740, 2130968741, 2130968742, 2130968743 };
				CircleImageView_civ_border_color = 0;
				CircleImageView_civ_border_overlay = 1;
				CircleImageView_civ_border_width = 2;
				CircleImageView_civ_fill_color = 3;
				CircularLoadingView = new int[4] { 2130968648, 2130968656, 2130968882, 2130969089 };
				CircularLoadingView_autoPlay = 0;
				CircularLoadingView_backgroundRingColor = 1;
				CircularLoadingView_foregroundRingColor = 2;
				CircularLoadingView_singleColorMode = 3;
				CollapsingToolbarLayout = new int[16]
				{
					2130968755, 2130968756, 2130968799, 2130968846, 2130968847, 2130968848, 2130968849, 2130968850, 2130968851, 2130968852,
					2130969055, 2130969057, 2130969111, 2130969192, 2130969193, 2130969203
				};
				CollapsingToolbarLayout_collapsedTitleGravity = 0;
				CollapsingToolbarLayout_collapsedTitleTextAppearance = 1;
				CollapsingToolbarLayout_contentScrim = 2;
				CollapsingToolbarLayout_expandedTitleGravity = 3;
				CollapsingToolbarLayout_expandedTitleMargin = 4;
				CollapsingToolbarLayout_expandedTitleMarginBottom = 5;
				CollapsingToolbarLayout_expandedTitleMarginEnd = 6;
				CollapsingToolbarLayout_expandedTitleMarginStart = 7;
				CollapsingToolbarLayout_expandedTitleMarginTop = 8;
				CollapsingToolbarLayout_expandedTitleTextAppearance = 9;
				CollapsingToolbarLayout_Layout = new int[2] { 2130968944, 2130968945 };
				CollapsingToolbarLayout_Layout_layout_collapseMode = 0;
				CollapsingToolbarLayout_Layout_layout_collapseParallaxMultiplier = 1;
				CollapsingToolbarLayout_scrimAnimationDuration = 10;
				CollapsingToolbarLayout_scrimVisibleHeightTrigger = 11;
				CollapsingToolbarLayout_statusBarScrim = 12;
				CollapsingToolbarLayout_title = 13;
				CollapsingToolbarLayout_titleEnabled = 14;
				CollapsingToolbarLayout_toolbarId = 15;
				ColorStateListItem = new int[5] { 16843173, 16843551, 16844359, 2130968639, 2130968931 };
				ColorStateListItem_alpha = 3;
				ColorStateListItem_android_alpha = 1;
				ColorStateListItem_android_color = 0;
				ColorStateListItem_android_lStar = 2;
				ColorStateListItem_lStar = 4;
				CompoundButton = new int[4] { 16843015, 2130968692, 2130968699, 2130968700 };
				CompoundButton_android_button = 0;
				CompoundButton_buttonCompat = 1;
				CompoundButton_buttonTint = 2;
				CompoundButton_buttonTintMode = 3;
				com_facebook_like_view = new int[6] { 2130968770, 2130968772, 2130968773, 2130968779, 2130968780, 2130968782 };
				com_facebook_like_view_com_facebook_auxiliary_view_position = 0;
				com_facebook_like_view_com_facebook_foreground_color = 1;
				com_facebook_like_view_com_facebook_horizontal_alignment = 2;
				com_facebook_like_view_com_facebook_object_id = 3;
				com_facebook_like_view_com_facebook_object_type = 4;
				com_facebook_like_view_com_facebook_style = 5;
				com_facebook_login_view = new int[6] { 2130968771, 2130968775, 2130968776, 2130968777, 2130968778, 2130968783 };
				com_facebook_login_view_com_facebook_confirm_logout = 0;
				com_facebook_login_view_com_facebook_login_button_radius = 1;
				com_facebook_login_view_com_facebook_login_button_transparency = 2;
				com_facebook_login_view_com_facebook_login_text = 3;
				com_facebook_login_view_com_facebook_logout_text = 4;
				com_facebook_login_view_com_facebook_tooltip_mode = 5;
				com_facebook_profile_picture_view = new int[2] { 2130968774, 2130968781 };
				com_facebook_profile_picture_view_com_facebook_is_cropped = 0;
				com_facebook_profile_picture_view_com_facebook_preset_size = 1;
				CoordinatorLayout = new int[2] { 2130968930, 2130969110 };
				CoordinatorLayout_keylines = 0;
				CoordinatorLayout_Layout = new int[7] { 16842931, 2130968940, 2130968941, 2130968943, 2130968946, 2130968948, 2130968949 };
				CoordinatorLayout_Layout_android_layout_gravity = 0;
				CoordinatorLayout_Layout_layout_anchor = 1;
				CoordinatorLayout_Layout_layout_anchorGravity = 2;
				CoordinatorLayout_Layout_layout_behavior = 3;
				CoordinatorLayout_Layout_layout_dodgeInsetEdges = 4;
				CoordinatorLayout_Layout_layout_insetEdge = 5;
				CoordinatorLayout_Layout_layout_keyline = 6;
				CoordinatorLayout_statusBarBackground = 1;
				DefaultTimeBar = new int[14]
				{
					2130968632, 2130968633, 2130968663, 2130968664, 2130968686, 2130969028, 2130969029, 2130969058, 2130969059, 2130969060,
					2130969061, 2130969062, 2130969209, 2130969223
				};
				DefaultTimeBar_ad_marker_color = 0;
				DefaultTimeBar_ad_marker_width = 1;
				DefaultTimeBar_bar_gravity = 2;
				DefaultTimeBar_bar_height = 3;
				DefaultTimeBar_buffered_color = 4;
				DefaultTimeBar_played_ad_marker_color = 5;
				DefaultTimeBar_played_color = 6;
				DefaultTimeBar_scrubber_color = 7;
				DefaultTimeBar_scrubber_disabled_size = 8;
				DefaultTimeBar_scrubber_dragged_size = 9;
				DefaultTimeBar_scrubber_drawable = 10;
				DefaultTimeBar_scrubber_enabled_size = 11;
				DefaultTimeBar_touch_target_height = 12;
				DefaultTimeBar_unplayed_color = 13;
				DesignTheme = new int[2] { 2130968675, 2130968676 };
				DesignTheme_bottomSheetDialogTheme = 0;
				DesignTheme_bottomSheetStyle = 1;
				DrawerArrowToggle = new int[8] { 2130968645, 2130968646, 2130968662, 2130968757, 2130968826, 2130968883, 2130969095, 2130969182 };
				DrawerArrowToggle_arrowHeadLength = 0;
				DrawerArrowToggle_arrowShaftLength = 1;
				DrawerArrowToggle_barLength = 2;
				DrawerArrowToggle_color = 3;
				DrawerArrowToggle_drawableSize = 4;
				DrawerArrowToggle_gapBetweenBars = 5;
				DrawerArrowToggle_spinBars = 6;
				DrawerArrowToggle_thickness = 7;
				DrawerLayout = new int[1] { 2130968838 };
				DrawerLayout_elevation = 0;
				FloatingActionButton = new int[13]
				{
					2130968659, 2130968660, 2130968671, 2130968838, 2130968857, 2130968858, 2130968890, 2130968900, 2130969004, 2130969035,
					2130969053, 2130969075, 2130969224
				};
				FloatingActionButton_backgroundTint = 0;
				FloatingActionButton_backgroundTintMode = 1;
				FloatingActionButton_Behavior_Layout = new int[1] { 2130968665 };
				FloatingActionButton_Behavior_Layout_behavior_autoHide = 0;
				FloatingActionButton_borderWidth = 2;
				FloatingActionButton_elevation = 3;
				FloatingActionButton_fabCustomSize = 4;
				FloatingActionButton_fabSize = 5;
				FloatingActionButton_hideMotionSpec = 6;
				FloatingActionButton_hoveredFocusedTranslationZ = 7;
				FloatingActionButton_maxImageSize = 8;
				FloatingActionButton_pressedTranslationZ = 9;
				FloatingActionButton_rippleColor = 10;
				FloatingActionButton_showMotionSpec = 11;
				FloatingActionButton_useCompatPadding = 12;
				FlowLayout = new int[2] { 2130968924, 2130968962 };
				FlowLayout_itemSpacing = 0;
				FlowLayout_lineSpacing = 1;
				FontFamily = new int[7] { 2130968871, 2130968872, 2130968873, 2130968874, 2130968875, 2130968876, 2130968877 };
				FontFamilyFont = new int[10] { 16844082, 16844083, 16844095, 16844143, 16844144, 2130968869, 2130968878, 2130968879, 2130968880, 2130969213 };
				FontFamilyFont_android_font = 0;
				FontFamilyFont_android_fontStyle = 2;
				FontFamilyFont_android_fontVariationSettings = 4;
				FontFamilyFont_android_fontWeight = 1;
				FontFamilyFont_android_ttcIndex = 3;
				FontFamilyFont_font = 5;
				FontFamilyFont_fontStyle = 6;
				FontFamilyFont_fontVariationSettings = 7;
				FontFamilyFont_fontWeight = 8;
				FontFamilyFont_ttcIndex = 9;
				FontFamily_fontProviderAuthority = 0;
				FontFamily_fontProviderCerts = 1;
				FontFamily_fontProviderFetchStrategy = 2;
				FontFamily_fontProviderFetchTimeout = 3;
				FontFamily_fontProviderPackage = 4;
				FontFamily_fontProviderQuery = 5;
				FontFamily_fontProviderSystemFontFamily = 6;
				ForegroundLinearLayout = new int[3] { 16843017, 16843264, 2130968881 };
				ForegroundLinearLayout_android_foreground = 0;
				ForegroundLinearLayout_android_foregroundGravity = 1;
				ForegroundLinearLayout_foregroundInsidePadding = 2;
				GradientColor = new int[12]
				{
					16843165, 16843166, 16843169, 16843170, 16843171, 16843172, 16843265, 16843275, 16844048, 16844049,
					16844050, 16844051
				};
				GradientColorItem = new int[2] { 16843173, 16844052 };
				GradientColorItem_android_color = 0;
				GradientColorItem_android_offset = 1;
				GradientColor_android_centerColor = 7;
				GradientColor_android_centerX = 3;
				GradientColor_android_centerY = 4;
				GradientColor_android_endColor = 1;
				GradientColor_android_endX = 10;
				GradientColor_android_endY = 11;
				GradientColor_android_gradientRadius = 5;
				GradientColor_android_startColor = 0;
				GradientColor_android_startX = 8;
				GradientColor_android_startY = 9;
				GradientColor_android_tileMode = 6;
				GradientColor_android_type = 2;
				IfitButton = new int[1] { 2130969214 };
				IfitButton_typeface = 0;
				IfitEditTextView = new int[1] { 2130969214 };
				IfitEditTextView_typeface = 0;
				IfitTextView = new int[1] { 2130969214 };
				IfitTextView_typeface = 0;
				LinearLayoutCompat = new int[9] { 16842927, 16842948, 16843046, 16843047, 16843048, 2130968817, 2130968819, 2130969005, 2130969073 };
				LinearLayoutCompat_android_baselineAligned = 2;
				LinearLayoutCompat_android_baselineAlignedChildIndex = 3;
				LinearLayoutCompat_android_gravity = 0;
				LinearLayoutCompat_android_orientation = 1;
				LinearLayoutCompat_android_weightSum = 4;
				LinearLayoutCompat_divider = 5;
				LinearLayoutCompat_dividerPadding = 6;
				LinearLayoutCompat_Layout = new int[4] { 16842931, 16842996, 16842997, 16843137 };
				LinearLayoutCompat_Layout_android_layout_gravity = 0;
				LinearLayoutCompat_Layout_android_layout_height = 2;
				LinearLayoutCompat_Layout_android_layout_weight = 3;
				LinearLayoutCompat_Layout_android_layout_width = 1;
				LinearLayoutCompat_measureWithLargestChild = 7;
				LinearLayoutCompat_showDividers = 8;
				ListPopupWindow = new int[2] { 16843436, 16843437 };
				ListPopupWindow_android_dropDownHorizontalOffset = 0;
				ListPopupWindow_android_dropDownVerticalOffset = 1;
				LoadingImageView = new int[3] { 2130968739, 2130968910, 2130968911 };
				LoadingImageView_circleCrop = 0;
				LoadingImageView_imageAspectRatio = 1;
				LoadingImageView_imageAspectRatioAdjust = 2;
				LoadingIndicatorDot = new int[1] { 2130968821 };
				LoadingIndicatorDot_dotTint = 0;
				LottieAnimationView = new int[17]
				{
					2130968982, 2130968983, 2130968984, 2130968985, 2130968986, 2130968987, 2130968988, 2130968989, 2130968990, 2130968991,
					2130968992, 2130968993, 2130968994, 2130968995, 2130968996, 2130968997, 2130968998
				};
				LottieAnimationView_lottie_autoPlay = 0;
				LottieAnimationView_lottie_cacheComposition = 1;
				LottieAnimationView_lottie_colorFilter = 2;
				LottieAnimationView_lottie_enableMergePathsForKitKatAndAbove = 3;
				LottieAnimationView_lottie_fallbackRes = 4;
				LottieAnimationView_lottie_fileName = 5;
				LottieAnimationView_lottie_ignoreDisabledSystemAnimations = 6;
				LottieAnimationView_lottie_imageAssetsFolder = 7;
				LottieAnimationView_lottie_loop = 8;
				LottieAnimationView_lottie_progress = 9;
				LottieAnimationView_lottie_rawRes = 10;
				LottieAnimationView_lottie_renderMode = 11;
				LottieAnimationView_lottie_repeatCount = 12;
				LottieAnimationView_lottie_repeatMode = 13;
				LottieAnimationView_lottie_scale = 14;
				LottieAnimationView_lottie_speed = 15;
				LottieAnimationView_lottie_url = 16;
				MapAttrs = new int[24]
				{
					2130968642, 2130968701, 2130968702, 2130968703, 2130968704, 2130968705, 2130968706, 2130968707, 2130968934, 2130968935,
					2130968936, 2130968937, 2130968978, 2130968999, 2130969215, 2130969216, 2130969217, 2130969218, 2130969219, 2130969220,
					2130969221, 2130969222, 2130969225, 2130969241
				};
				MapAttrs_ambientEnabled = 0;
				MapAttrs_cameraBearing = 1;
				MapAttrs_cameraMaxZoomPreference = 2;
				MapAttrs_cameraMinZoomPreference = 3;
				MapAttrs_cameraTargetLat = 4;
				MapAttrs_cameraTargetLng = 5;
				MapAttrs_cameraTilt = 6;
				MapAttrs_cameraZoom = 7;
				MapAttrs_latLngBoundsNorthEastLatitude = 8;
				MapAttrs_latLngBoundsNorthEastLongitude = 9;
				MapAttrs_latLngBoundsSouthWestLatitude = 10;
				MapAttrs_latLngBoundsSouthWestLongitude = 11;
				MapAttrs_liteMode = 12;
				MapAttrs_mapType = 13;
				MapAttrs_uiCompass = 14;
				MapAttrs_uiMapToolbar = 15;
				MapAttrs_uiRotateGestures = 16;
				MapAttrs_uiScrollGestures = 17;
				MapAttrs_uiScrollGesturesDuringRotateOrZoom = 18;
				MapAttrs_uiTiltGestures = 19;
				MapAttrs_uiZoomControls = 20;
				MapAttrs_uiZoomGestures = 21;
				MapAttrs_useViewLifecycle = 22;
				MapAttrs_zOrderOnTop = 23;
				MaterialButton = new int[16]
				{
					16843191, 16843192, 16843193, 16843194, 2130968659, 2130968660, 2130968803, 2130968901, 2130968903, 2130968904,
					2130968905, 2130968907, 2130968908, 2130969053, 2130969112, 2130969113
				};
				MaterialButton_android_insetBottom = 3;
				MaterialButton_android_insetLeft = 0;
				MaterialButton_android_insetRight = 1;
				MaterialButton_android_insetTop = 2;
				MaterialButton_backgroundTint = 4;
				MaterialButton_backgroundTintMode = 5;
				MaterialButton_cornerRadius = 6;
				MaterialButton_icon = 7;
				MaterialButton_iconGravity = 8;
				MaterialButton_iconPadding = 9;
				MaterialButton_iconSize = 10;
				MaterialButton_iconTint = 11;
				MaterialButton_iconTintMode = 12;
				MaterialButton_rippleColor = 13;
				MaterialButton_strokeColor = 14;
				MaterialButton_strokeWidth = 15;
				MaterialCardView = new int[2] { 2130969112, 2130969113 };
				MaterialCardView_strokeColor = 0;
				MaterialCardView_strokeWidth = 1;
				MaterialComponentsTheme = new int[32]
				{
					2130968675, 2130968676, 2130968724, 2130968734, 2130968738, 2130968758, 2130968759, 2130968765, 2130968766, 2130968768,
					2130968837, 2130968868, 2130969000, 2130969001, 2130969011, 2130969056, 2130969092, 2130969149, 2130969154, 2130969155,
					2130969156, 2130969157, 2130969158, 2130969159, 2130969160, 2130969161, 2130969162, 2130969163, 2130969168, 2130969173,
					2130969174, 2130969178
				};
				MaterialComponentsTheme_bottomSheetDialogTheme = 0;
				MaterialComponentsTheme_bottomSheetStyle = 1;
				MaterialComponentsTheme_chipGroupStyle = 2;
				MaterialComponentsTheme_chipStandaloneStyle = 3;
				MaterialComponentsTheme_chipStyle = 4;
				MaterialComponentsTheme_colorAccent = 5;
				MaterialComponentsTheme_colorBackgroundFloating = 6;
				MaterialComponentsTheme_colorPrimary = 7;
				MaterialComponentsTheme_colorPrimaryDark = 8;
				MaterialComponentsTheme_colorSecondary = 9;
				MaterialComponentsTheme_editTextStyle = 10;
				MaterialComponentsTheme_floatingActionButtonStyle = 11;
				MaterialComponentsTheme_materialButtonStyle = 12;
				MaterialComponentsTheme_materialCardViewStyle = 13;
				MaterialComponentsTheme_navigationViewStyle = 14;
				MaterialComponentsTheme_scrimBackground = 15;
				MaterialComponentsTheme_snackbarButtonStyle = 16;
				MaterialComponentsTheme_tabStyle = 17;
				MaterialComponentsTheme_textAppearanceBody1 = 18;
				MaterialComponentsTheme_textAppearanceBody2 = 19;
				MaterialComponentsTheme_textAppearanceButton = 20;
				MaterialComponentsTheme_textAppearanceCaption = 21;
				MaterialComponentsTheme_textAppearanceHeadline1 = 22;
				MaterialComponentsTheme_textAppearanceHeadline2 = 23;
				MaterialComponentsTheme_textAppearanceHeadline3 = 24;
				MaterialComponentsTheme_textAppearanceHeadline4 = 25;
				MaterialComponentsTheme_textAppearanceHeadline5 = 26;
				MaterialComponentsTheme_textAppearanceHeadline6 = 27;
				MaterialComponentsTheme_textAppearanceOverline = 28;
				MaterialComponentsTheme_textAppearanceSubtitle1 = 29;
				MaterialComponentsTheme_textAppearanceSubtitle2 = 30;
				MaterialComponentsTheme_textInputStyle = 31;
				MenuGroup = new int[6] { 16842766, 16842960, 16843156, 16843230, 16843231, 16843232 };
				MenuGroup_android_checkableBehavior = 5;
				MenuGroup_android_enabled = 0;
				MenuGroup_android_id = 1;
				MenuGroup_android_menuCategory = 3;
				MenuGroup_android_orderInCategory = 4;
				MenuGroup_android_visible = 2;
				MenuItem = new int[23]
				{
					16842754, 16842766, 16842960, 16843014, 16843156, 16843230, 16843231, 16843233, 16843234, 16843235,
					16843236, 16843237, 16843375, 2130968607, 2130968627, 2130968628, 2130968640, 2130968787, 2130968907, 2130968908,
					2130969013, 2130969072, 2130969208
				};
				MenuItem_actionLayout = 13;
				MenuItem_actionProviderClass = 14;
				MenuItem_actionViewClass = 15;
				MenuItem_alphabeticModifiers = 16;
				MenuItem_android_alphabeticShortcut = 9;
				MenuItem_android_checkable = 11;
				MenuItem_android_checked = 3;
				MenuItem_android_enabled = 1;
				MenuItem_android_icon = 0;
				MenuItem_android_id = 2;
				MenuItem_android_menuCategory = 5;
				MenuItem_android_numericShortcut = 10;
				MenuItem_android_onClick = 12;
				MenuItem_android_orderInCategory = 6;
				MenuItem_android_title = 7;
				MenuItem_android_titleCondensed = 8;
				MenuItem_android_visible = 4;
				MenuItem_contentDescription = 17;
				MenuItem_iconTint = 18;
				MenuItem_iconTintMode = 19;
				MenuItem_numericModifiers = 20;
				MenuItem_showAsAction = 21;
				MenuItem_tooltipText = 22;
				MenuView = new int[9] { 16842926, 16843052, 16843053, 16843054, 16843055, 16843056, 16843057, 2130969034, 2130969114 };
				MenuView_android_headerBackground = 4;
				MenuView_android_horizontalDivider = 2;
				MenuView_android_itemBackground = 5;
				MenuView_android_itemIconDisabledAlpha = 6;
				MenuView_android_itemTextAppearance = 1;
				MenuView_android_verticalDivider = 3;
				MenuView_android_windowAnimationStyle = 0;
				MenuView_preserveIconSpacing = 7;
				MenuView_subMenuArrow = 8;
				MvxBinding = new int[2] { 2130968586, 2130968590 };
				MvxBinding_MvxBind = 0;
				MvxBinding_MvxLang = 1;
				MvxControl = new int[1] { 2130968592 };
				MvxControl_MvxTemplate = 0;
				MvxExpandableListView = new int[1] { 2130968588 };
				MvxExpandableListView_MvxGroupItemTemplate = 0;
				MvxImageView = new int[1] { 2130968591 };
				MvxImageView_MvxSource = 0;
				MvxListView = new int[2] { 2130968587, 2130968589 };
				MvxListView_MvxDropDownItemTemplate = 0;
				MvxListView_MvxItemTemplate = 1;
				NavigationView = new int[12]
				{
					16842964, 16842973, 16843039, 2130968838, 2130968885, 2130968917, 2130968918, 2130968920, 2130968922, 2130968925,
					2130968928, 2130969006
				};
				NavigationView_android_background = 0;
				NavigationView_android_fitsSystemWindows = 1;
				NavigationView_android_maxWidth = 2;
				NavigationView_elevation = 3;
				NavigationView_headerLayout = 4;
				NavigationView_itemBackground = 5;
				NavigationView_itemHorizontalPadding = 6;
				NavigationView_itemIconPadding = 7;
				NavigationView_itemIconTint = 8;
				NavigationView_itemTextAppearance = 9;
				NavigationView_itemTextColor = 10;
				NavigationView_menu = 11;
				PercentLayout_Layout = new int[10] { 2130968942, 2130968947, 2130968950, 2130968951, 2130968952, 2130968953, 2130968954, 2130968955, 2130968956, 2130968959 };
				PercentLayout_Layout_layout_aspectRatio = 0;
				PercentLayout_Layout_layout_heightPercent = 1;
				PercentLayout_Layout_layout_marginBottomPercent = 2;
				PercentLayout_Layout_layout_marginEndPercent = 3;
				PercentLayout_Layout_layout_marginLeftPercent = 4;
				PercentLayout_Layout_layout_marginPercent = 5;
				PercentLayout_Layout_layout_marginRightPercent = 6;
				PercentLayout_Layout_layout_marginStartPercent = 7;
				PercentLayout_Layout_layout_marginTopPercent = 8;
				PercentLayout_Layout_layout_widthPercent = 9;
				PlayerControlView = new int[25]
				{
					2130968632, 2130968633, 2130968663, 2130968664, 2130968686, 2130968801, 2130968864, 2130969028, 2130969029, 2130969049,
					2130969052, 2130969058, 2130969059, 2130969060, 2130969061, 2130969062, 2130969079, 2130969080, 2130969081, 2130969082,
					2130969083, 2130969085, 2130969189, 2130969209, 2130969223
				};
				PlayerControlView_ad_marker_color = 0;
				PlayerControlView_ad_marker_width = 1;
				PlayerControlView_bar_gravity = 2;
				PlayerControlView_bar_height = 3;
				PlayerControlView_buffered_color = 4;
				PlayerControlView_controller_layout_id = 5;
				PlayerControlView_fastforward_increment = 6;
				PlayerControlView_played_ad_marker_color = 7;
				PlayerControlView_played_color = 8;
				PlayerControlView_repeat_toggle_modes = 9;
				PlayerControlView_rewind_increment = 10;
				PlayerControlView_scrubber_color = 11;
				PlayerControlView_scrubber_disabled_size = 12;
				PlayerControlView_scrubber_dragged_size = 13;
				PlayerControlView_scrubber_drawable = 14;
				PlayerControlView_scrubber_enabled_size = 15;
				PlayerControlView_show_fastforward_button = 16;
				PlayerControlView_show_next_button = 17;
				PlayerControlView_show_previous_button = 18;
				PlayerControlView_show_rewind_button = 19;
				PlayerControlView_show_shuffle_button = 20;
				PlayerControlView_show_timeout = 21;
				PlayerControlView_time_bar_min_update_interval = 22;
				PlayerControlView_touch_target_height = 23;
				PlayerControlView_unplayed_color = 24;
				PlayerView = new int[33]
				{
					2130968632, 2130968633, 2130968654, 2130968664, 2130968686, 2130968801, 2130968812, 2130968864, 2130968893, 2130968894,
					2130968929, 2130969028, 2130969029, 2130969030, 2130969049, 2130969050, 2130969052, 2130969058, 2130969059, 2130969060,
					2130969061, 2130969062, 2130969078, 2130969083, 2130969085, 2130969087, 2130969121, 2130969189, 2130969209, 2130969223,
					2130969226, 2130969227, 2130969228
				};
				PlayerView_ad_marker_color = 0;
				PlayerView_ad_marker_width = 1;
				PlayerView_auto_show = 2;
				PlayerView_bar_height = 3;
				PlayerView_buffered_color = 4;
				PlayerView_controller_layout_id = 5;
				PlayerView_default_artwork = 6;
				PlayerView_fastforward_increment = 7;
				PlayerView_hide_during_ads = 8;
				PlayerView_hide_on_touch = 9;
				PlayerView_keep_content_on_player_reset = 10;
				PlayerView_played_ad_marker_color = 11;
				PlayerView_played_color = 12;
				PlayerView_player_layout_id = 13;
				PlayerView_repeat_toggle_modes = 14;
				PlayerView_resize_mode = 15;
				PlayerView_rewind_increment = 16;
				PlayerView_scrubber_color = 17;
				PlayerView_scrubber_disabled_size = 18;
				PlayerView_scrubber_dragged_size = 19;
				PlayerView_scrubber_drawable = 20;
				PlayerView_scrubber_enabled_size = 21;
				PlayerView_show_buffering = 22;
				PlayerView_show_shuffle_button = 23;
				PlayerView_show_timeout = 24;
				PlayerView_shutter_background_color = 25;
				PlayerView_surface_type = 26;
				PlayerView_time_bar_min_update_interval = 27;
				PlayerView_touch_target_height = 28;
				PlayerView_unplayed_color = 29;
				PlayerView_use_artwork = 30;
				PlayerView_use_controller = 31;
				PlayerView_use_sensor_rotation = 32;
				PopupWindow = new int[3] { 16843126, 16843465, 2130969014 };
				PopupWindowBackgroundState = new int[1] { 2130969105 };
				PopupWindowBackgroundState_state_above_anchor = 0;
				PopupWindow_android_popupAnimationStyle = 1;
				PopupWindow_android_popupBackground = 0;
				PopupWindow_overlapAnchor = 2;
				PreLoginAngleBackgroundView = new int[2] { 16842801, 2130968643 };
				PreLoginAngleBackgroundView_android_colorBackground = 0;
				PreLoginAngleBackgroundView_angle = 1;
				RatingControl = new int[8] { 16842901, 16842904, 2130968661, 2130968785, 2130968786, 2130969043, 2130969044, 2130969214 };
				RatingControl_android_textColor = 1;
				RatingControl_android_textSize = 0;
				RatingControl_barLeftOfLabel = 2;
				RatingControl_containerBackground = 3;
				RatingControl_containerPadding = 4;
				RatingControl_ratingBarCustomStyle = 5;
				RatingControl_ratingBarMarginStart = 6;
				RatingControl_typeface = 7;
				RecycleListView = new int[2] { 2130969015, 2130969018 };
				RecycleListView_paddingBottomNoButtons = 0;
				RecycleListView_paddingTopNoTitle = 1;
				RecyclerView = new int[12]
				{
					16842948, 16842987, 16842993, 2130968859, 2130968860, 2130968861, 2130968862, 2130968863, 2130968939, 2130969051,
					2130969094, 2130969104
				};
				RecyclerView_android_clipToPadding = 1;
				RecyclerView_android_descendantFocusability = 2;
				RecyclerView_android_orientation = 0;
				RecyclerView_fastScrollEnabled = 3;
				RecyclerView_fastScrollHorizontalThumbDrawable = 4;
				RecyclerView_fastScrollHorizontalTrackDrawable = 5;
				RecyclerView_fastScrollVerticalThumbDrawable = 6;
				RecyclerView_fastScrollVerticalTrackDrawable = 7;
				RecyclerView_layoutManager = 8;
				RecyclerView_reverseLayout = 9;
				RecyclerView_spanCount = 10;
				RecyclerView_stackFromEnd = 11;
				ScrimInsetsFrameLayout = new int[1] { 2130968915 };
				ScrimInsetsFrameLayout_insetForeground = 0;
				ScrollingViewBehavior_Layout = new int[1] { 2130968668 };
				ScrollingViewBehavior_Layout_behavior_overlapTop = 0;
				SearchView = new int[17]
				{
					16842970, 16843039, 16843296, 16843364, 2130968745, 2130968784, 2130968810, 2130968884, 2130968909, 2130968938,
					2130969039, 2130969040, 2130969063, 2130969064, 2130969115, 2130969120, 2130969230
				};
				SearchView_android_focusable = 0;
				SearchView_android_imeOptions = 3;
				SearchView_android_inputType = 2;
				SearchView_android_maxWidth = 1;
				SearchView_closeIcon = 4;
				SearchView_commitIcon = 5;
				SearchView_defaultQueryHint = 6;
				SearchView_goIcon = 7;
				SearchView_iconifiedByDefault = 8;
				SearchView_layout = 9;
				SearchView_queryBackground = 10;
				SearchView_queryHint = 11;
				SearchView_searchHintIcon = 12;
				SearchView_searchIcon = 13;
				SearchView_submitBackground = 14;
				SearchView_suggestionRowLayout = 15;
				SearchView_voiceIcon = 16;
				ShireWKWebView = new int[1] { 2130968843 };
				ShireWKWebView_error_view_layout_resource = 0;
				SignInButton = new int[3] { 2130968696, 2130968767, 2130969054 };
				SignInButton_buttonSize = 0;
				SignInButton_colorScheme = 1;
				SignInButton_scopeUris = 2;
				Snackbar = new int[2] { 2130969092, 2130969093 };
				SnackbarLayout = new int[3] { 16843039, 2130968838, 2130969002 };
				SnackbarLayout_android_maxWidth = 0;
				SnackbarLayout_elevation = 1;
				SnackbarLayout_maxActionInlineWidth = 2;
				Snackbar_snackbarButtonStyle = 0;
				Snackbar_snackbarStyle = 1;
				Spinner = new int[5] { 16842930, 16843126, 16843131, 16843362, 2130969032 };
				Spinner_android_dropDownWidth = 3;
				Spinner_android_entries = 0;
				Spinner_android_popupBackground = 1;
				Spinner_android_prompt = 2;
				Spinner_popupTheme = 4;
				SplitPairFilter = new int[3] { 2130969036, 2130969066, 2130969067 };
				SplitPairFilter_primaryActivityName = 0;
				SplitPairFilter_secondaryActivityAction = 1;
				SplitPairFilter_secondaryActivityName = 2;
				SplitPairRule = new int[7] { 2130968744, 2130968865, 2130968866, 2130969098, 2130969099, 2130969100, 2130969101 };
				SplitPairRule_clearTop = 0;
				SplitPairRule_finishPrimaryWithSecondary = 1;
				SplitPairRule_finishSecondaryWithPrimary = 2;
				SplitPairRule_splitLayoutDirection = 3;
				SplitPairRule_splitMinSmallestWidth = 4;
				SplitPairRule_splitMinWidth = 5;
				SplitPairRule_splitRatio = 6;
				SplitPlaceholderRule = new int[5] { 2130969027, 2130969098, 2130969099, 2130969100, 2130969101 };
				SplitPlaceholderRule_placeholderActivityName = 0;
				SplitPlaceholderRule_splitLayoutDirection = 1;
				SplitPlaceholderRule_splitMinSmallestWidth = 2;
				SplitPlaceholderRule_splitMinWidth = 3;
				SplitPlaceholderRule_splitRatio = 4;
				StateListDrawable = new int[6] { 16843036, 16843156, 16843157, 16843158, 16843532, 16843533 };
				StateListDrawableItem = new int[1] { 16843161 };
				StateListDrawableItem_android_drawable = 0;
				StateListDrawable_android_constantSize = 3;
				StateListDrawable_android_dither = 0;
				StateListDrawable_android_enterFadeDuration = 4;
				StateListDrawable_android_exitFadeDuration = 5;
				StateListDrawable_android_variablePadding = 2;
				StateListDrawable_android_visible = 1;
				StyledPlayerControlView = new int[28]
				{
					2130968632, 2130968633, 2130968644, 2130968663, 2130968664, 2130968686, 2130968801, 2130968864, 2130969028, 2130969029,
					2130969049, 2130969052, 2130969058, 2130969059, 2130969060, 2130969061, 2130969062, 2130969079, 2130969080, 2130969081,
					2130969082, 2130969083, 2130969084, 2130969085, 2130969086, 2130969189, 2130969209, 2130969223
				};
				StyledPlayerControlView_ad_marker_color = 0;
				StyledPlayerControlView_ad_marker_width = 1;
				StyledPlayerControlView_animation_enabled = 2;
				StyledPlayerControlView_bar_gravity = 3;
				StyledPlayerControlView_bar_height = 4;
				StyledPlayerControlView_buffered_color = 5;
				StyledPlayerControlView_controller_layout_id = 6;
				StyledPlayerControlView_fastforward_increment = 7;
				StyledPlayerControlView_played_ad_marker_color = 8;
				StyledPlayerControlView_played_color = 9;
				StyledPlayerControlView_repeat_toggle_modes = 10;
				StyledPlayerControlView_rewind_increment = 11;
				StyledPlayerControlView_scrubber_color = 12;
				StyledPlayerControlView_scrubber_disabled_size = 13;
				StyledPlayerControlView_scrubber_dragged_size = 14;
				StyledPlayerControlView_scrubber_drawable = 15;
				StyledPlayerControlView_scrubber_enabled_size = 16;
				StyledPlayerControlView_show_fastforward_button = 17;
				StyledPlayerControlView_show_next_button = 18;
				StyledPlayerControlView_show_previous_button = 19;
				StyledPlayerControlView_show_rewind_button = 20;
				StyledPlayerControlView_show_shuffle_button = 21;
				StyledPlayerControlView_show_subtitle_button = 22;
				StyledPlayerControlView_show_timeout = 23;
				StyledPlayerControlView_show_vr_button = 24;
				StyledPlayerControlView_time_bar_min_update_interval = 25;
				StyledPlayerControlView_touch_target_height = 26;
				StyledPlayerControlView_unplayed_color = 27;
				StyledPlayerView = new int[37]
				{
					2130968632, 2130968633, 2130968644, 2130968654, 2130968663, 2130968664, 2130968686, 2130968801, 2130968812, 2130968864,
					2130968893, 2130968894, 2130968929, 2130969028, 2130969029, 2130969030, 2130969049, 2130969050, 2130969052, 2130969058,
					2130969059, 2130969060, 2130969061, 2130969062, 2130969078, 2130969083, 2130969084, 2130969085, 2130969086, 2130969087,
					2130969121, 2130969189, 2130969209, 2130969223, 2130969226, 2130969227, 2130969228
				};
				StyledPlayerView_ad_marker_color = 0;
				StyledPlayerView_ad_marker_width = 1;
				StyledPlayerView_animation_enabled = 2;
				StyledPlayerView_auto_show = 3;
				StyledPlayerView_bar_gravity = 4;
				StyledPlayerView_bar_height = 5;
				StyledPlayerView_buffered_color = 6;
				StyledPlayerView_controller_layout_id = 7;
				StyledPlayerView_default_artwork = 8;
				StyledPlayerView_fastforward_increment = 9;
				StyledPlayerView_hide_during_ads = 10;
				StyledPlayerView_hide_on_touch = 11;
				StyledPlayerView_keep_content_on_player_reset = 12;
				StyledPlayerView_played_ad_marker_color = 13;
				StyledPlayerView_played_color = 14;
				StyledPlayerView_player_layout_id = 15;
				StyledPlayerView_repeat_toggle_modes = 16;
				StyledPlayerView_resize_mode = 17;
				StyledPlayerView_rewind_increment = 18;
				StyledPlayerView_scrubber_color = 19;
				StyledPlayerView_scrubber_disabled_size = 20;
				StyledPlayerView_scrubber_dragged_size = 21;
				StyledPlayerView_scrubber_drawable = 22;
				StyledPlayerView_scrubber_enabled_size = 23;
				StyledPlayerView_show_buffering = 24;
				StyledPlayerView_show_shuffle_button = 25;
				StyledPlayerView_show_subtitle_button = 26;
				StyledPlayerView_show_timeout = 27;
				StyledPlayerView_show_vr_button = 28;
				StyledPlayerView_shutter_background_color = 29;
				StyledPlayerView_surface_type = 30;
				StyledPlayerView_time_bar_min_update_interval = 31;
				StyledPlayerView_touch_target_height = 32;
				StyledPlayerView_unplayed_color = 33;
				StyledPlayerView_use_artwork = 34;
				StyledPlayerView_use_controller = 35;
				StyledPlayerView_use_sensor_rotation = 36;
				SwipeRefreshLayout = new int[1] { 2130969122 };
				SwipeRefreshLayout_swipeRefreshLayoutProgressSpinnerBackgroundColor = 0;
				SwitchCompat = new int[14]
				{
					16843044, 16843045, 16843074, 2130969076, 2130969102, 2130969123, 2130969124, 2130969126, 2130969183, 2130969184,
					2130969185, 2130969210, 2130969211, 2130969212
				};
				SwitchCompat_android_textOff = 1;
				SwitchCompat_android_textOn = 0;
				SwitchCompat_android_thumb = 2;
				SwitchCompat_showText = 3;
				SwitchCompat_splitTrack = 4;
				SwitchCompat_switchMinWidth = 5;
				SwitchCompat_switchPadding = 6;
				SwitchCompat_switchTextAppearance = 7;
				SwitchCompat_thumbTextPadding = 8;
				SwitchCompat_thumbTint = 9;
				SwitchCompat_thumbTintMode = 10;
				SwitchCompat_track = 11;
				SwitchCompat_trackTint = 12;
				SwitchCompat_trackTintMode = 13;
				TabItem = new int[3] { 16842754, 16842994, 16843087 };
				TabItem_android_icon = 0;
				TabItem_android_layout = 1;
				TabItem_android_text = 2;
				TabLayout = new int[25]
				{
					2130969127, 2130969128, 2130969129, 2130969130, 2130969131, 2130969132, 2130969133, 2130969134, 2130969135, 2130969136,
					2130969137, 2130969138, 2130969139, 2130969140, 2130969141, 2130969142, 2130969143, 2130969144, 2130969145, 2130969146,
					2130969147, 2130969148, 2130969150, 2130969151, 2130969152
				};
				TabLayout_tabBackground = 0;
				TabLayout_tabContentStart = 1;
				TabLayout_tabGravity = 2;
				TabLayout_tabIconTint = 3;
				TabLayout_tabIconTintMode = 4;
				TabLayout_tabIndicator = 5;
				TabLayout_tabIndicatorAnimationDuration = 6;
				TabLayout_tabIndicatorColor = 7;
				TabLayout_tabIndicatorFullWidth = 8;
				TabLayout_tabIndicatorGravity = 9;
				TabLayout_tabIndicatorHeight = 10;
				TabLayout_tabInlineLabel = 11;
				TabLayout_tabMaxWidth = 12;
				TabLayout_tabMinWidth = 13;
				TabLayout_tabMode = 14;
				TabLayout_tabPadding = 15;
				TabLayout_tabPaddingBottom = 16;
				TabLayout_tabPaddingEnd = 17;
				TabLayout_tabPaddingStart = 18;
				TabLayout_tabPaddingTop = 19;
				TabLayout_tabRippleColor = 20;
				TabLayout_tabSelectedTextColor = 21;
				TabLayout_tabTextAppearance = 22;
				TabLayout_tabTextColor = 23;
				TabLayout_tabUnboundedRipple = 24;
				TextAppearance = new int[16]
				{
					16842901, 16842902, 16842903, 16842904, 16842906, 16842907, 16843105, 16843106, 16843107, 16843108,
					16843692, 16844165, 2130968870, 2130968879, 2130969153, 2130969179
				};
				TextAppearance_android_fontFamily = 10;
				TextAppearance_android_shadowColor = 6;
				TextAppearance_android_shadowDx = 7;
				TextAppearance_android_shadowDy = 8;
				TextAppearance_android_shadowRadius = 9;
				TextAppearance_android_textColor = 3;
				TextAppearance_android_textColorHint = 4;
				TextAppearance_android_textColorLink = 5;
				TextAppearance_android_textFontWeight = 11;
				TextAppearance_android_textSize = 0;
				TextAppearance_android_textStyle = 2;
				TextAppearance_android_typeface = 1;
				TextAppearance_fontFamily = 12;
				TextAppearance_fontVariationSettings = 13;
				TextAppearance_textAllCaps = 14;
				TextAppearance_textLocale = 15;
				TextInputLayout = new int[28]
				{
					16842906, 16843088, 2130968677, 2130968678, 2130968679, 2130968680, 2130968681, 2130968682, 2130968683, 2130968684,
					2130968685, 2130968804, 2130968805, 2130968806, 2130968807, 2130968841, 2130968842, 2130968887, 2130968888, 2130968889,
					2130968895, 2130968896, 2130968897, 2130969022, 2130969023, 2130969024, 2130969025, 2130969026
				};
				TextInputLayout_android_hint = 1;
				TextInputLayout_android_textColorHint = 0;
				TextInputLayout_boxBackgroundColor = 2;
				TextInputLayout_boxBackgroundMode = 3;
				TextInputLayout_boxCollapsedPaddingTop = 4;
				TextInputLayout_boxCornerRadiusBottomEnd = 5;
				TextInputLayout_boxCornerRadiusBottomStart = 6;
				TextInputLayout_boxCornerRadiusTopEnd = 7;
				TextInputLayout_boxCornerRadiusTopStart = 8;
				TextInputLayout_boxStrokeColor = 9;
				TextInputLayout_boxStrokeWidth = 10;
				TextInputLayout_counterEnabled = 11;
				TextInputLayout_counterMaxLength = 12;
				TextInputLayout_counterOverflowTextAppearance = 13;
				TextInputLayout_counterTextAppearance = 14;
				TextInputLayout_errorEnabled = 15;
				TextInputLayout_errorTextAppearance = 16;
				TextInputLayout_helperText = 17;
				TextInputLayout_helperTextEnabled = 18;
				TextInputLayout_helperTextTextAppearance = 19;
				TextInputLayout_hintAnimationEnabled = 20;
				TextInputLayout_hintEnabled = 21;
				TextInputLayout_hintTextAppearance = 22;
				TextInputLayout_passwordToggleContentDescription = 23;
				TextInputLayout_passwordToggleDrawable = 24;
				TextInputLayout_passwordToggleEnabled = 25;
				TextInputLayout_passwordToggleTint = 26;
				TextInputLayout_passwordToggleTintMode = 27;
				ThemeEnforcement = new int[3] { 16842804, 2130968839, 2130968840 };
				ThemeEnforcement_android_textAppearance = 0;
				ThemeEnforcement_enforceMaterialTheme = 1;
				ThemeEnforcement_enforceTextAppearance = 2;
				Toolbar = new int[30]
				{
					16842927, 16843072, 2130968693, 2130968753, 2130968754, 2130968788, 2130968789, 2130968790, 2130968791, 2130968792,
					2130968793, 2130968979, 2130968980, 2130969003, 2130969006, 2130969008, 2130969009, 2130969032, 2130969116, 2130969117,
					2130969118, 2130969192, 2130969194, 2130969195, 2130969196, 2130969197, 2130969198, 2130969199, 2130969200, 2130969201
				};
				Toolbar_android_gravity = 0;
				Toolbar_android_minHeight = 1;
				Toolbar_buttonGravity = 2;
				Toolbar_collapseContentDescription = 3;
				Toolbar_collapseIcon = 4;
				Toolbar_contentInsetEnd = 5;
				Toolbar_contentInsetEndWithActions = 6;
				Toolbar_contentInsetLeft = 7;
				Toolbar_contentInsetRight = 8;
				Toolbar_contentInsetStart = 9;
				Toolbar_contentInsetStartWithNavigation = 10;
				Toolbar_logo = 11;
				Toolbar_logoDescription = 12;
				Toolbar_maxButtonHeight = 13;
				Toolbar_menu = 14;
				Toolbar_navigationContentDescription = 15;
				Toolbar_navigationIcon = 16;
				Toolbar_popupTheme = 17;
				Toolbar_subtitle = 18;
				Toolbar_subtitleTextAppearance = 19;
				Toolbar_subtitleTextColor = 20;
				Toolbar_title = 21;
				Toolbar_titleMargin = 22;
				Toolbar_titleMarginBottom = 23;
				Toolbar_titleMarginEnd = 24;
				Toolbar_titleMargins = 27;
				Toolbar_titleMarginStart = 25;
				Toolbar_titleMarginTop = 26;
				Toolbar_titleTextAppearance = 28;
				Toolbar_titleTextColor = 29;
				View = new int[5] { 16842752, 16842970, 2130969016, 2130969017, 2130969181 };
				ViewBackgroundHelper = new int[3] { 16842964, 2130968659, 2130968660 };
				ViewBackgroundHelper_android_background = 0;
				ViewBackgroundHelper_backgroundTint = 1;
				ViewBackgroundHelper_backgroundTintMode = 2;
				ViewStubCompat = new int[3] { 16842960, 16842994, 16842995 };
				ViewStubCompat_android_id = 0;
				ViewStubCompat_android_inflatedId = 2;
				ViewStubCompat_android_layout = 1;
				View_android_focusable = 1;
				View_android_theme = 0;
				View_paddingEnd = 2;
				View_paddingStart = 3;
				View_theme = 4;
				WifiImageButton = new int[11]
				{
					2130968576, 2130968577, 2130968578, 2130968579, 2130968580, 2130968581, 2130968582, 2130968583, 2130968584, 2130968585,
					2130968593
				};
				WifiImageButton_ConnectedNoInternet = 0;
				WifiImageButton_ConnectedStrong = 1;
				WifiImageButton_ConnectedStrongest = 3;
				WifiImageButton_ConnectedStrongestLocked = 4;
				WifiImageButton_ConnectedStrongLocked = 2;
				WifiImageButton_ConnectedWeak = 5;
				WifiImageButton_ConnectedWeakest = 7;
				WifiImageButton_ConnectedWeakLocked = 6;
				WifiImageButton_Disabled = 8;
				WifiImageButton_EnabledNotConnected = 9;
				WifiImageButton_Unknown = 10;
				ResourceIdManager.UpdateIdValues();
			}

			private Styleable()
			{
			}
		}

		public class Xml
		{
			public static int image_share_filepaths;

			public static int xamarin_essentials_fileprovider_file_paths;

			static Xml()
			{
				image_share_filepaths = 2132017152;
				xamarin_essentials_fileprovider_file_paths = 2132017153;
				ResourceIdManager.UpdateIdValues();
			}

			private Xml()
			{
			}
		}

		static Resource()
		{
			ResourceIdManager.UpdateIdValues();
		}
	}
	public class iFitPercentFormatter : Java.Lang.Object, IAxisValueFormatter, IJavaObject, IDisposable
	{
		private readonly string formatString;

		public iFitPercentFormatter(int precision = 0)
		{
			formatString = "{0:N" + precision + "}%";
		}

		public string GetFormattedValue(float value, AxisBase axis)
		{
			return string.Format(formatString, value * 100f);
		}
	}
	public class IfitLinkText : ClickableSpan
	{
		private readonly ICommand clickCommand;

		private readonly SplatColor linkColor;

		private readonly bool underlined;

		private readonly bool bold;

		public IfitLinkText(ICommand clickCommand, SplatColor linkColor, bool underlined = false, bool bold = false)
		{
			this.clickCommand = clickCommand;
			this.linkColor = linkColor;
			this.underlined = underlined;
			this.bold = bold;
		}

		public override void UpdateDrawState(TextPaint ds)
		{
			base.UpdateDrawState(ds);
			ds.Color = linkColor.ToNative();
			ds.UnderlineText = underlined;
			ds.FakeBoldText = bold;
		}

		public override void OnClick(View widget)
		{
			if (clickCommand.CanExecute(null))
			{
				clickCommand.Execute(null);
			}
		}

		public static void SetLinkText(ICommand clickCommand, IfitTextView view, SplatColor linkColor, string text, int linkStartIndex = 0, int linkEndIndex = -1, bool underlined = false)
		{
			if (linkEndIndex == -1)
			{
				linkEndIndex = text.Length;
			}
			SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(text);
			IfitLinkText what = (clickCommand.CanExecute(null) ? new IfitLinkText(clickCommand, linkColor, underlined) : new IfitLinkText(clickCommand, SplatColor.FromArgb(view.TextColors?.DefaultColor ?? 0), underlined: false, bold: true));
			spannableStringBuilder.SetSpan(what, linkStartIndex, linkEndIndex, SpanTypes.ExclusiveExclusive);
			view.TextFormatted = spannableStringBuilder;
			view.MovementMethod = new LinkMovementMethod();
		}

		public static void SetMultipleLinksText(List<MultipleLinksText> multipleLinksText, IfitTextView view, SplatColor linkColor, string text, bool underlined = false)
		{
			SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(text);
			foreach (MultipleLinksText item in multipleLinksText)
			{
				IfitLinkText what = new IfitLinkText(item.command, linkColor, underlined);
				spannableStringBuilder.SetSpan(what, item.startIndex, item.endIndex, SpanTypes.ExclusiveExclusive);
			}
			view.TextFormatted = spannableStringBuilder;
			view.MovementMethod = new LinkMovementMethod();
		}
	}
	public class MultipleLinksText
	{
		public ICommand command { get; }

		public int startIndex { get; }

		public int endIndex { get; }

		public MultipleLinksText(ICommand command, int startIndex, int endIndex)
		{
			this.command = command;
			this.startIndex = startIndex;
			this.endIndex = endIndex;
		}
	}
	public class IfitTypeface
	{
		public enum Type
		{
			ProximaRegular,
			ProximaBold,
			ProximaExtraBold,
			ProximaLightItalic,
			RobotoRegular,
			ProximaSemibold,
			ProximaBlack,
			ProximaThin,
			ProximaLight,
			GeorgiaRegular,
			Martines11,
			Martines10,
			ProximaRegularItalic,
			ProximaSemiboldItalic,
			LeagueGothicRegular
		}

		private static readonly Dictionary<Type, Typeface> Typefaces = new Dictionary<Type, Typeface>();

		private static string _outputDir;

		public static void Init(Context context)
		{
			_outputDir = $"{context.CacheDir}/tmp/";
			CreateFromResource(Type.ProximaRegular, Resource.Raw.proxima_regular);
			CreateFromResource(Type.ProximaBold, Resource.Raw.proxima_bold);
			CreateFromResource(Type.ProximaExtraBold, Resource.Raw.proxima_extra_bold);
			CreateFromResource(Type.ProximaLightItalic, Resource.Raw.proxima_light_italic);
			CreateFromResource(Type.RobotoRegular, Resource.Raw.roboto_regular);
			CreateFromResource(Type.ProximaSemibold, Resource.Raw.proxima_semibold);
			CreateFromResource(Type.ProximaBlack, Resource.Raw.proxima_black);
			CreateFromResource(Type.ProximaThin, Resource.Raw.proxima_thin);
			CreateFromResource(Type.ProximaLight, Resource.Raw.proxima_light);
			CreateFromResource(Type.GeorgiaRegular, Resource.Raw.georgia_regular);
			CreateFromResource(Type.Martines11, Resource.Raw.martines11);
			CreateFromResource(Type.Martines10, Resource.Raw.martines10);
			CreateFromResource(Type.ProximaRegularItalic, Resource.Raw.proxima_regular_italic);
			CreateFromResource(Type.ProximaSemiboldItalic, Resource.Raw.proxima_semibold_italic);
			CreateFromResource(Type.LeagueGothicRegular, Resource.Raw.league_gothic_regular);
		}

		private static void CreateFromResource(Type type, int rawRes)
		{
			string text = _outputDir + type.ToString() + ".raw";
			if (!System.IO.File.Exists(text) && !Typefaces.ContainsKey(type))
			{
				CreateCachedFont(rawRes, _outputDir, text);
			}
			if (Typefaces.ContainsKey(type))
			{
				return;
			}
			try
			{
				Typeface value = Typeface.CreateFromFile(text);
				Typefaces[type] = value;
			}
			catch (System.Exception)
			{
				CreateCachedFont(rawRes, _outputDir, text);
			}
		}

		private static void CreateCachedFont(int rawRes, string outputDir, string outputPath)
		{
			using Stream stream = Application.Context.Resources.OpenRawResource(rawRes);
			if (!Directory.Exists(outputDir))
			{
				Directory.CreateDirectory(outputDir);
			}
			using FileStream destination = System.IO.File.Create(outputPath);
			stream.CopyTo(destination);
		}

		public static Typeface GetCustomTypeface(Type type)
		{
			if (!Typefaces.TryGetValue(type, out var value))
			{
				CreateFromResource(Type.ProximaRegular, Resource.Raw.proxima_regular);
				return Typefaces[Type.ProximaRegular];
			}
			return value;
		}
	}
	public static class TypeFaceExtensions
	{
		public static Typeface GetTypeface(this IfitTypeface.Type ifitTypeFace)
		{
			return IfitTypeface.GetCustomTypeface(ifitTypeFace);
		}
	}
	[Preserve]
	public static class LinkerPreserve
	{
		static LinkerPreserve()
		{
			throw new System.Exception(typeof(SQLitePersistentBlobCache).FullName);
		}
	}
	public class PreserveAttribute : Attribute
	{
	}
}
namespace Shire.Android.RefitInternalGenerated
{
	[ExcludeFromCodeCoverage]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
	internal sealed class PreserveAttribute : Attribute
	{
		public bool AllMembers;

		public bool Conditional;
	}
}
namespace Shire.Android.ShireMvx
{
	[AttributeUsage(AttributeTargets.Class)]
	public class FragmentPresentationAttribute : Attribute
	{
		public Type ParentType { get; }

		public int FrameResourceId { get; }

		public bool AddToBackStack { get; }

		public FragmentPresentationAttribute(Type parentType, int frameResourceId, bool addToBackStack = true)
		{
			ParentType = parentType;
			FrameResourceId = frameResourceId;
			AddToBackStack = addToBackStack;
		}
	}
	public abstract class ShireActivity : ShireMvxFragmentActivity, IShowMessage, IMvxBindingContextOwner, IShowAlertMessage
	{
		private const string Tag = "ShireActvity";

		public const string ExtraTargetFragmentView = "ExtraTargetFragmentView";

		public const string ExtraTargetFragmentViewModel = "ExtraTargetFragmentViewModel";

		public const string ExtraParentFragmentViewModel = "ExtraParentFragmentViewModel";

		public const string ExtraTargetFragmentViewModelParameters = "ExtraTargetFragmentViewModelParameters";

		public const string ExtraTargetDialogFragmentView = "ExtraTargetDialogFragmentView";

		public const string ExtraTargetDialogFragmentViewModel = "ExtraTargetDialogFragmentViewModel";

		protected ConcurrentDictionary<Type, ShireDialogFragment> vmTypeToFragment = new ConcurrentDictionary<Type, ShireDialogFragment>();

		protected readonly ReplaySubject<ShireFragment> targetFragmentChanged = new ReplaySubject<ShireFragment>();

		protected readonly ReplaySubject<ShireDialogFragment> targetDialogFragmentChanged = new ReplaySubject<ShireDialogFragment>();

		protected IDisposable whenTargetFragmentChanged;

		protected IDisposable whenTargetDialogFragmentChanged;

		protected ShireDialogFragment visibleDialogFragment;

		private IMvxViewModelLoader viewModelLoader;

		protected bool isCleanedUp;

		protected bool isPaused;

		private const StatusBarVisibility hiddenSystemUiVisibility = (StatusBarVisibility)5894;

		private readonly object removeDialogFragmentLock = new object();

		protected ShireBaseViewModel baseViewModel => base.ViewModel as ShireBaseViewModel;

		protected abstract int LayoutResId { get; }

		protected abstract Assembly viewAssembly { get; }

		protected abstract Assembly viewModelAssembly { get; }

		protected abstract string AlertAcknowledgeString { get; }

		protected bool IsCurrentlyDisplaying => baseViewModel.IsVisible;

		protected virtual bool KeepScreenOn => false;

		public event EventHandler OnMessageShown;

		public ShireActivity(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		public ShireActivity()
		{
		}

		private void SetKeepScreenOn(bool enabled)
		{
			if (enabled)
			{
				((Activity)(object)this).Window.AddFlags(WindowManagerFlags.KeepScreenOn);
			}
			else
			{
				((Activity)(object)this).Window.ClearFlags(WindowManagerFlags.KeepScreenOn);
			}
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			Mvx.TryResolve<IMvxViewModelLoader>(out viewModelLoader);
			if (LayoutResId > 0)
			{
				((Activity)(object)this).SetContentView(LayoutResId);
			}
			WatchFragments();
			WatchDialogFragments();
			SetupView();
		}

		protected virtual void SetupView()
		{
		}

		protected override void OnResume()
		{
			base.OnResume();
			if (!isCleanedUp)
			{
				isPaused = false;
				if (baseViewModel != null)
				{
					baseViewModel.IsVisible = true;
				}
				if (KeepScreenOn)
				{
					SetKeepScreenOn(enabled: true);
				}
			}
		}

		protected override void OnPause()
		{
			base.OnPause();
			isPaused = true;
			if (baseViewModel != null)
			{
				baseViewModel.IsVisible = false;
			}
			if (KeepScreenOn)
			{
				SetKeepScreenOn(enabled: false);
			}
		}

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();
			if (base.DataContext is ShireBaseViewModel shireBaseViewModel)
			{
				shireBaseViewModel.View = new WeakReference<IMvxView>(this);
			}
		}

		public void RegisterDialogFragment(Type type, ShireDialogFragment dialogFragment)
		{
			vmTypeToFragment[type] = dialogFragment;
		}

		private void WatchFragments()
		{
			whenTargetFragmentChanged = targetFragmentChanged.Subscribe(AddFragment);
			string text = ((Activity)(object)this).Intent?.Extras?.GetString("ExtraTargetFragmentViewModel");
			string text2 = ((Activity)(object)this).Intent?.Extras?.GetString("ExtraTargetFragmentView");
			string parentViewModel = ((Activity)(object)this).Intent?.Extras?.GetString("ExtraParentFragmentViewModel");
			if (text != null && text2 != null)
			{
				CreateTargetFragment(text2, text, parentViewModel, CreateParametersBundleFromIntent());
			}
		}

		private void WatchDialogFragments()
		{
			whenTargetDialogFragmentChanged = targetDialogFragmentChanged.Subscribe(AddDialogFragment);
			string text = ((Activity)(object)this).Intent?.Extras?.GetString("ExtraTargetDialogFragmentViewModel");
			string text2 = ((Activity)(object)this).Intent?.Extras?.GetString("ExtraTargetDialogFragmentView");
			string parentViewModel = ((Activity)(object)this).Intent?.Extras?.GetString("ExtraParentFragmentViewModel");
			if (text != null && text2 != null)
			{
				CreateTargetDialogFragment(text2, text, parentViewModel, CreateParametersBundleFromIntent());
			}
		}

		protected IMvxBundle CreateParametersBundleFromIntent()
		{
			string value = ((Activity)(object)this).Intent?.Extras?.GetString("ExtraTargetFragmentViewModelParameters");
			if (string.IsNullOrWhiteSpace(value))
			{
				return null;
			}
			try
			{
				Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
				return new MvxBundle(data);
			}
			catch
			{
				return null;
			}
		}

		public virtual void CreateTargetFragment(string view, IMvxViewModel viewModel)
		{
			Type type = viewAssembly.GetType(view);
			if (Activator.CreateInstance(type) is ShireFragment shireFragment)
			{
				shireFragment.ViewModel = viewModel;
				targetFragmentChanged.OnNext(shireFragment);
			}
		}

		public virtual void CreateTargetFragment(string view, string viewModel, string parentViewModel, IMvxBundle parameters)
		{
			Type type = viewAssembly.GetType(view);
			Type type2 = viewModelAssembly.GetType(viewModel);
			ShireFragment shireFragment = Activator.CreateInstance(type) as ShireFragment;
			MvxViewModelRequest request = new MvxViewModelRequest(type2, parameters, null, null);
			try
			{
				if (shireFragment != null)
				{
					shireFragment.ViewModel = viewModelLoader.LoadViewModel(request, null);
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("ShireActvity", "CreateTargetFragment -> viewModelLoader was not resolved correctly", exception);
			}
			if (parentViewModel != null && shireFragment != null && shireFragment.ViewModel is ShireBaseViewModel shireBaseViewModel)
			{
				shireBaseViewModel.ParentType = viewModelAssembly.GetType(parentViewModel);
			}
			targetFragmentChanged.OnNext(shireFragment);
		}

		public void CreateTargetDialogFragment(string view, string viewModel, string parentViewModel, IMvxBundle parameters, object arbitraryData = null)
		{
			Type type = viewAssembly.GetType(view);
			Type type2 = viewModelAssembly.GetType(viewModel);
			ShireDialogFragment shireDialogFragment = Activator.CreateInstance(type) as ShireDialogFragment;
			MvxViewModelRequest request = new MvxViewModelRequest(type2, parameters, null, null);
			try
			{
				if (shireDialogFragment != null)
				{
					shireDialogFragment.ViewModel = viewModelLoader.LoadViewModel(request, null);
					if (shireDialogFragment.ViewModel is ShireBaseViewModel shireBaseViewModel)
					{
						shireBaseViewModel.ArbitraryData = arbitraryData;
						shireBaseViewModel.InitWithArbitraryData();
					}
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("ShireActvity", "CreateTargetDialogFragment -> viewModelLoader was not resolved correctly", exception);
			}
			if (parentViewModel != null && shireDialogFragment != null && shireDialogFragment.ViewModel is ShireBaseViewModel shireBaseViewModel2)
			{
				shireBaseViewModel2.ParentType = viewModelAssembly.GetType(parentViewModel);
			}
			targetDialogFragmentChanged.OnNext(shireDialogFragment);
		}

		public void ReplaceDialogFragmentContent(string view, string viewModel, string parentViewModel, IMvxBundle parameters, object arbitraryData = null)
		{
			Type type = viewAssembly.GetType(view);
			Type type2 = viewModelAssembly.GetType(viewModel);
			ShireFragment shireFragment = Activator.CreateInstance(type) as ShireFragment;
			MvxViewModelRequest request = new MvxViewModelRequest(type2, parameters, null, null);
			try
			{
				if (shireFragment != null)
				{
					shireFragment.ViewModel = viewModelLoader.LoadViewModel(request, null);
					if (shireFragment.ViewModel is ShireBaseViewModel shireBaseViewModel)
					{
						shireBaseViewModel.ArbitraryData = arbitraryData;
						shireBaseViewModel.InitWithArbitraryData();
					}
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("ShireActvity", "ReplaceDialogFragmentContent -> viewModelLoader was not resolved correctly", exception);
			}
			if (parentViewModel != null)
			{
				if (shireFragment != null && shireFragment.ViewModel is ShireBaseViewModel shireBaseViewModel2)
				{
					Type type3 = viewModelAssembly.GetType(parentViewModel);
					shireBaseViewModel2.ParentType = type3;
				}
				AndroidX.Fragment.App.Fragment fragment = SupportFragmentManager?.FindFragmentByTag(ShireDialogFragmentUtil.GetTag(parentViewModel));
				(fragment as ShireDialogFragment)?.DialogFragmentContentChanged(shireFragment);
			}
		}

		protected virtual void AddFragment(ShireFragment fragment)
		{
			FragmentPresentationAttribute customAttribute = fragment.GetType().GetCustomAttribute<FragmentPresentationAttribute>();
			if (customAttribute != null)
			{
				int frameResourceId = customAttribute.FrameResourceId;
				AndroidX.Fragment.App.FragmentTransaction fragmentTransaction = SupportFragmentManager.BeginTransaction().Add(frameResourceId, fragment);
				if (customAttribute.AddToBackStack)
				{
					fragmentTransaction.AddToBackStack(fragment.GetType().ToString());
				}
				fragmentTransaction.Commit();
			}
		}

		public virtual void AddDialogFragment(ShireDialogFragment dialogFragment)
		{
			if (dialogFragment?.ViewModel != null && !isPaused)
			{
				AndroidX.Fragment.App.FragmentTransaction transaction = SupportFragmentManager.BeginTransaction();
				vmTypeToFragment[dialogFragment.ViewModel.GetType()] = dialogFragment;
				dialogFragment.Show(transaction, dialogFragment.GetTag());
			}
		}

		public virtual void CloseFragment(IMvxViewModel fragmentViewModel)
		{
			SupportFragmentManager.PopBackStackImmediate();
		}

		public virtual void CloseDialogFragment(IMvxViewModel viewModel)
		{
			if (vmTypeToFragment.ContainsKey(viewModel.GetType()))
			{
				RemoveDialogFragment(vmTypeToFragment[viewModel.GetType()]);
			}
		}

		private void RemoveDialogFragment(ShireDialogFragment dFrag)
		{
			lock (removeDialogFragmentLock)
			{
				if (dFrag?.ViewModel != null && vmTypeToFragment.ContainsKey(dFrag.ViewModel.GetType()))
				{
					vmTypeToFragment.TryRemove(dFrag.ViewModel.GetType(), out var _);
					dFrag.DismissAllowingStateLoss();
					DialogClosed(dFrag);
				}
			}
		}

		public void CloseAllDialogs()
		{
			vmTypeToFragment.Select((KeyValuePair<Type, ShireDialogFragment> x) => x.Value).ToList().ForEach(RemoveDialogFragment);
		}

		protected virtual void DialogClosed(ShireDialogFragment dialogFragment)
		{
		}

		public virtual void ShowMessage(string message)
		{
			try
			{
				((Activity)(object)this).RunOnUiThread((Action)delegate
				{
					Toast.MakeText((Context)(object)this, message, ToastLength.Long).Show();
				});
			}
			catch
			{
			}
			Task.Run(async delegate
			{
				await Task.Delay(3500);
				this.OnMessageShown?.Invoke(this, EventArgs.Empty);
			});
		}

		public void ShowAlertMessage(string message)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder((Context)(object)this);
			builder.SetMessage(message);
			builder.SetCancelable(cancelable: true);
			builder.SetPositiveButton(AlertAcknowledgeString, delegate
			{
			});
			builder.Create().Show();
		}

		public void RemoveAllSystemUi()
		{
			if (((Activity)(object)this).Window?.DecorView != null)
			{
				((Activity)(object)this).Window.DecorView.SystemUiVisibility = (StatusBarVisibility)5894;
			}
		}

		public bool IsSystemUiRemoved()
		{
			StatusBarVisibility systemUiVisibility = ((Activity)(object)this).Window.DecorView.SystemUiVisibility;
			return systemUiVisibility == (StatusBarVisibility)5894;
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
		}

		public override void OnRestoreInstanceState(Bundle savedInstanceState, PersistableBundle persistentState)
		{
			((Activity)(object)this).OnRestoreInstanceState(savedInstanceState, persistentState);
		}

		protected sealed override void OnDestroy()
		{
			base.OnDestroy();
			if (!isCleanedUp)
			{
				base.BindingContext?.ClearAllBindings();
				whenTargetFragmentChanged?.Dispose();
				targetFragmentChanged?.Dispose();
				targetDialogFragmentChanged?.Dispose();
				whenTargetFragmentChanged?.Dispose();
				whenTargetDialogFragmentChanged?.Dispose();
				CleanUp();
				isCleanedUp = true;
				baseViewModel?.Dispose();
				vmTypeToFragment?.Clear();
				base.ViewModel = null;
				GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true, compacting: true);
				GC.WaitForPendingFinalizers();
			}
		}

		protected abstract void CleanUp();

		protected sealed override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
	public class ShireAndroidLifetimeMonitor : MvxLifetimeMonitor, IMvxAndroidActivityLifetimeListener, IMvxAndroidCurrentTopActivity
	{
		private int _createdActivityCount;

		private Activity _activity;

		public Activity Activity
		{
			get
			{
				return _activity;
			}
			private set
			{
				if (_activity != value)
				{
					_activity = value;
					this.OnActivityChanged?.Invoke(this, value);
				}
			}
		}

		public event EventHandler<Activity> OnActivityChanged;

		public virtual void OnCreate(Activity activity)
		{
			_createdActivityCount++;
			if (_createdActivityCount == 1)
			{
				FireLifetimeChange(MvxLifetimeEvent.ActivatedFromDisk);
			}
			Activity = activity;
		}

		public virtual void OnStart(Activity activity)
		{
			Activity = activity;
		}

		public virtual void OnRestart(Activity activity)
		{
			Activity = activity;
		}

		public virtual void OnResume(Activity activity)
		{
			Activity = activity;
		}

		public virtual void OnPause(Activity activity)
		{
		}

		public virtual void OnStop(Activity activity)
		{
		}

		public virtual void OnDestroy(Activity activity)
		{
			if (Activity == activity)
			{
				Activity = null;
			}
			_createdActivityCount--;
			if (_createdActivityCount == 0)
			{
				FireLifetimeChange(MvxLifetimeEvent.Closing);
			}
		}

		public virtual void OnViewNewIntent(Activity activity)
		{
			Activity = activity;
		}
	}
	public abstract class ShireDialogFragment : MvxDialogFragment, IShowMessage, IMvxBindingContextOwner
	{
		private ShireActivity shireActivity;

		private View view;

		private bool isCleanedUp;

		protected abstract int LayoutId { get; }

		protected ShireBaseViewModel baseViewModel => ViewModel as ShireBaseViewModel;

		protected bool Visibility
		{
			get
			{
				if (baseViewModel != null)
				{
					return baseViewModel.IsVisible;
				}
				return false;
			}
			set
			{
				if (baseViewModel != null && baseViewModel.IsVisible != value)
				{
					iFit.Logger.Log.Trace("Navigation", $"Setting dialog visibility to: {value} for: {GetType().FullName}");
					baseViewModel.IsVisible = value;
				}
			}
		}

		public override IMvxViewModel ViewModel
		{
			get
			{
				return base.ViewModel;
			}
			set
			{
				if (base.ViewModel != value)
				{
					base.ViewModel = value;
				}
			}
		}

		public event EventHandler OnMessageShown;

		public ShireDialogFragment(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		public ShireDialogFragment()
		{
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);
			Dialog.RequestWindowFeature(1);
			shireActivity = base.Activity as ShireActivity;
			ShireActivity obj = shireActivity;
			if (obj != null && obj.IsSystemUiRemoved())
			{
				Dialog.Window.SetFlags(WindowManagerFlags.NotFocusable, WindowManagerFlags.NotFocusable);
				Dialog.Window.DecorView.SystemUiVisibility = ((Activity)(object)base.Activity).Window.DecorView.SystemUiVisibility;
			}
			view = this.BindingInflate(LayoutId, null);
			return view;
		}

		public virtual void DialogFragmentContentChanged(ShireFragment fragment)
		{
		}

		public virtual void ShowMessage(string message)
		{
			Toast.MakeText(((Context)(object)base.Activity).ApplicationContext, message, ToastLength.Long).Show();
			Task.Run(async delegate
			{
				await Task.Delay(3500);
				this.OnMessageShown?.Invoke(this, EventArgs.Empty);
			});
		}

		public void InputBox(string prompt, string title, string defaultValue, Action<string> action)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder((Context)(object)base.Activity);
			builder.SetTitle(title);
			builder.SetMessage(prompt);
			builder.SetCancelable(cancelable: true);
			EditText textView = new EditText((Context)(object)base.Activity);
			ViewGroup.LayoutParams layoutParams = new ViewGroup.LayoutParams(100, 100);
			layoutParams.Height = -1;
			layoutParams.Width = -1;
			textView.SetPadding(20, 10, 20, 10);
			textView.LayoutParameters = layoutParams;
			textView.Text = defaultValue;
			builder.SetView(textView);
			builder.SetPositiveButton("OK", delegate
			{
				action(textView.Text);
			});
			builder.SetNegativeButton("Cancel", delegate
			{
			});
			builder.Create().Show();
		}

		public override void OnCancel(IDialogInterface dialog)
		{
			if (baseViewModel != null)
			{
				baseViewModel.CloseViewModel.Execute();
			}
		}

		public override void OnResume()
		{
			base.OnResume();
			Visibility = true;
		}

		public override void OnPause()
		{
			base.OnPause();
			Visibility = false;
		}

		public sealed override void OnDestroyView()
		{
			base.OnDestroyView();
			try
			{
				Dismiss();
			}
			catch (IllegalStateException)
			{
				iFit.Logger.Log.Trace("MvxTrace", "Activity for Fragment was destroyed before fragment was destroyed.");
			}
			view?.Dispose();
			view = null;
		}

		public sealed override void OnDestroy()
		{
			base.OnDestroy();
			if (!isCleanedUp)
			{
				base.BindingContext?.ClearAllBindings();
				CleanUp();
				isCleanedUp = true;
				baseViewModel?.Dispose();
				ViewModel = null;
				shireActivity = null;
			}
		}

		protected abstract void CleanUp();

		protected sealed override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
	public static class ShireDialogFragmentUtil
	{
		public const string DialogFragmentTagFormat = "dialog_fragment_{0}";

		public static string GetTag(string vmName)
		{
			string arg = vmName.Split(new char[1] { '.' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
			return $"dialog_fragment_{arg}";
		}

		public static string GetTag(this ShireDialogFragment frag)
		{
			if (frag.ViewModel == null)
			{
				return GetTag(frag.GetType().FullName + "Model");
			}
			return GetTag(frag.ViewModel.GetType().FullName);
		}
	}
	public abstract class ShireFragment : MvxFragment, IShowMessage, IMvxBindingContextOwner
	{
		private bool isCleanedUp;

		protected bool IsCleanedUp => isCleanedUp;

		protected abstract int LayoutId { get; }

		protected ShireBaseViewModel baseViewModel => ViewModel as ShireBaseViewModel;

		public event EventHandler OnMessageShown;

		public ShireFragment(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		public ShireFragment()
		{
		}

		public override void OnViewModelSet()
		{
			base.OnViewModelSet();
		}

		public virtual void ShowMessage(string message)
		{
			Toast.MakeText(((Context)(object)base.Activity).ApplicationContext, message, ToastLength.Long).Show();
			Task.Run(async delegate
			{
				await Task.Delay(3500);
				this.OnMessageShown?.Invoke(this, EventArgs.Empty);
			});
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);
			return this.BindingInflate(LayoutId, container, attachToParent: false);
		}

		public override void OnResume()
		{
			base.OnResume();
			if (baseViewModel != null)
			{
				baseViewModel.IsVisible = true;
			}
		}

		public override void OnPause()
		{
			base.OnPause();
			if (baseViewModel != null)
			{
				baseViewModel.IsVisible = false;
			}
		}

		public sealed override void OnDestroyView()
		{
			base.OnDestroyView();
		}

		public sealed override void OnDestroy()
		{
			base.OnDestroy();
			if (!isCleanedUp)
			{
				base.BindingContext?.ClearAllBindings();
				CleanUp();
				isCleanedUp = true;
				baseViewModel?.Dispose();
				ViewModel = null;
			}
		}

		protected abstract void CleanUp();

		protected sealed override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
	public abstract class ShirePresenter : MvxAndroidViewPresenter, IDialogPresenter
	{
		private class DialogPresentationRequest
		{
			public string DialogViewModelTypeName { get; set; }

			public IMvxBundle Bundle { get; set; }

			public object ArbitraryData { get; set; }
		}

		private const string BleScanningName = "BleScanning";

		private const string BleFoundName = "BleFoundViewModel";

		private const string RestartDialogName = "RestartDialogViewModel";

		private const string FanVolumeName = "FanVolumeDialogViewModel";

		private const string AccountSelectionName = "AccountSelectionViewModel";

		private const string ScreenSaverName = "ScreenSaverDialogViewModel";

		protected readonly IViewTypeLookup viewTypeLookup;

		protected readonly ValidPresenterRequestHelper dialogViewModelRequestHelper;

		protected readonly ValidPresenterRequestHelper viewModelRequestHelper;

		private IAppLifecycleService appLifecycleService;

		private readonly ConcurrentQueue<DialogPresentationRequest> dialogQueue = new ConcurrentQueue<DialogPresentationRequest>();

		private string currentDialogViewModelName;

		protected Assembly ViewModelAssembly { get; private set; }

		public ShireBaseViewModel CurrentMainViewModel => (base.Activity as ShireActivity)?.ViewModel as ShireBaseViewModel;

		protected ShirePresenter(IViewTypeLookup viewTypeLookup, Assembly viewModelAssembly)
		{
			this.viewTypeLookup = viewTypeLookup;
			ViewModelAssembly = viewModelAssembly;
			dialogViewModelRequestHelper = new ValidPresenterRequestHelper(viewModelAssembly);
			viewModelRequestHelper = new ValidPresenterRequestHelper(viewModelAssembly);
		}

		public void ShowDialog<TDialogViewModel>(IMvxBundle init = null, bool showSafely = false, object arbitraryData = null, bool animated = true)
		{
			ShowDialog(typeof(TDialogViewModel).FullName, init, showSafely, arbitraryData, animated);
		}

		public void ShowDialog<TDialogViewModel, TInit>(TInit init, bool showSafely = false, object arbitraryData = null, bool animated = true)
		{
			MvxBundle init2 = new MvxBundle(init.ToSimplePropertyDictionary());
			ShowDialog<TDialogViewModel>(init2, showSafely, arbitraryData, animated);
		}

		public void ShowDialog(string dialogFragmentViewModel, IMvxBundle init = null, bool showSafely = false, object arbitraryData = null, bool animated = true)
		{
			IAppLifecycleService obj = appLifecycleService;
			if (obj != null && obj.IsAppInBackground)
			{
				EnqueueDialog(dialogFragmentViewModel, init, arbitraryData);
				iFit.Logger.Log.Trace("Navigation", "ShirePresenter.ShowDialog()- we are backgrounded, enqueuing dialog " + dialogFragmentViewModel + " for later");
				return;
			}
			ShireActivity baseActivity = base.Activity as ShireActivity;
			if (showSafely && currentDialogViewModelName != null)
			{
				if (AttemptingToShowMultipleDialogs(dialogFragmentViewModel))
				{
					iFit.Logger.Log.Trace("Navigation", "ShirePresenter.ShowDialog() - cancelled. A dialog - " + dialogFragmentViewModel + ". Attempt to show multiple dialogs");
					return;
				}
				EnqueueDialog(dialogFragmentViewModel, init, arbitraryData);
				iFit.Logger.Log.Trace("Navigation", "ShirePresenter.ShowDialog()- cancelled. A dialog - " + currentDialogViewModelName + " - is already visible, enqueuing dialog " + dialogFragmentViewModel);
				return;
			}
			MvxSingleton<IMvxMainThreadDispatcher>.Instance.RequestMainThreadAction(delegate
			{
				iFit.Logger.Log.Trace("Navigation", "ShirePresenter.ShowDialog(), Showing dialog " + dialogFragmentViewModel);
				Type type = ViewModelAssembly.GetType(dialogFragmentViewModel);
				string fullName = viewTypeLookup.GetDialogFragmentType(type).FullName;
				dialogViewModelRequestHelper.UpdateLastShown(type);
				baseActivity?.CreateTargetDialogFragment(fullName, dialogFragmentViewModel, null, init, arbitraryData);
				currentDialogViewModelName = dialogFragmentViewModel;
			});
		}

		public void ShowToast(string message, double duration = 2000.0)
		{
			base.Activity.RunOnUiThread(delegate
			{
				Toast.MakeText(base.Activity, message, (duration >= 2000.0) ? ToastLength.Long : ToastLength.Short)?.Show();
			});
		}

		private bool AttemptingToShowMultipleDialogs(string dialogViewModelTypeName)
		{
			string value = "BleScanning".ToLower();
			string value2 = "BleFoundViewModel".ToLower();
			string value3 = "RestartDialogViewModel".ToLower();
			string value4 = "FanVolumeDialogViewModel".ToLower();
			bool flag = dialogViewModelTypeName.ToLower().Contains(value) || dialogViewModelTypeName.ToLower().Contains(value2);
			bool flag2 = currentDialogViewModelName.ToLower().Contains(value) || currentDialogViewModelName.ToLower().Contains(value2);
			bool flag3 = dialogViewModelTypeName.ToLower().Contains(value4);
			bool flag4 = dialogViewModelTypeName.ToLower().Contains(value3);
			return (flag && flag2) || flag3 || flag4;
		}

		private void EnqueueDialog(string dialogViewModelTypeName, IMvxBundle init, object arbitraryData)
		{
			DialogPresentationRequest item = new DialogPresentationRequest
			{
				DialogViewModelTypeName = dialogViewModelTypeName,
				Bundle = init,
				ArbitraryData = arbitraryData
			};
			dialogQueue.Enqueue(item);
		}

		protected void ProcessDialogQueue(string closedViewModelName)
		{
			if (closedViewModelName == currentDialogViewModelName)
			{
				currentDialogViewModelName = null;
			}
			if (currentDialogViewModelName == null && dialogQueue.Count > 0)
			{
				IAppLifecycleService obj = appLifecycleService;
				if ((obj == null || !obj.IsAppInBackground) && dialogQueue.TryDequeue(out var result) && result != null)
				{
					ShowDialog(result.DialogViewModelTypeName, result.Bundle, showSafely: true, result.ArbitraryData);
				}
			}
		}

		public bool IsDialogShown<TDialogViewModel>()
		{
			return IsDialogShown(typeof(TDialogViewModel).FullName);
		}

		public bool IsDialogShown(string dialogFragmentViewModel)
		{
			AndroidX.Fragment.App.Fragment fragment = ((!(base.Activity is ShireMvxFragmentActivity shireMvxFragmentActivity)) ? null : shireMvxFragmentActivity.SupportFragmentManager?.FindFragmentByTag(ShireDialogFragmentUtil.GetTag(dialogFragmentViewModel)));
			Type type = ViewModelAssembly.GetType(dialogFragmentViewModel);
			return fragment != null || dialogViewModelRequestHelper.WasRecentlyShown(type);
		}

		public TDialogViewModel CurrentDialogViewModel<TDialogViewModel>() where TDialogViewModel : ShireBaseViewModel
		{
			string fullName = typeof(TDialogViewModel).FullName;
			return (((!(base.Activity is ShireMvxFragmentActivity shireMvxFragmentActivity)) ? null : shireMvxFragmentActivity.SupportFragmentManager?.FindFragmentByTag(ShireDialogFragmentUtil.GetTag(fullName))) as ShireDialogFragment)?.ViewModel as TDialogViewModel;
		}

		public override void Show(MvxViewModelRequest request)
		{
			bool? flag = request?.PresentationValues?.ContainsKey("replaceDialogContent");
			if (flag.HasValue && flag != true && viewModelRequestHelper.WasRecentlyShown(request))
			{
				iFit.Logger.Log.Trace("Navigation", "ShirePresenter.Show() - cancelled for view model: " + request.ViewModelType.Name + " cancelled. Since it was recently Shown.");
				return;
			}
			string text = JsonConvert.SerializeObject(request);
			if (request?.ViewModelType?.ToString().Contains("MyProfileViewModel") == true)
			{
				text = Regex.Replace(text, "\"ParameterValues\":{.+?}", "\"ParameterValues\":{sensitive information hidden}");
			}
			iFit.Logger.Log.Trace("Navigation", "ShirePresenter.Show(), Navigating with request data " + text);
			if (request.ViewModelType != (base.Activity as ShireActivity)?.ViewModel?.GetType())
			{
				iFit.Logger.Log.Trace("Navigation", "ShirePresenter.Show(), Navigating from: " + (base.Activity as ShireActivity)?.ViewModel?.GetType().Name + " to: " + request.ViewModelType.Name + ", closing all dialogs.");
				if (currentDialogViewModelName == null || (currentDialogViewModelName != "ScreenSaverDialogViewModel" && request.ViewModelType.Name != "AccountSelectionViewModel"))
				{
					CloseDialogs();
				}
				else
				{
					currentDialogViewModelName = null;
				}
			}
			viewModelRequestHelper.UpdateLastShown(request);
			if (request != null && request.PresentationValues?.ContainsKey("childViewModel") == true)
			{
				string text2 = request.PresentationValues["childViewModel"];
				Type type = ViewModelAssembly.GetType(text2);
				string text3 = viewTypeLookup?.GetFragmentType(type).FullName;
				Type type2 = viewTypeLookup?.GetActivityType(request.ViewModelType);
				if (base.Activity != null && base.Activity.GetType() == type2)
				{
					if (base.Activity is ShireActivity shireActivity)
					{
						shireActivity.CreateTargetFragment(text3, text2, request?.ViewModelType?.FullName, new MvxBundle(request.ParameterValues));
					}
					return;
				}
				Intent intent = CreateIntentForRequest(request);
				intent.PutExtra("ExtraTargetFragmentViewModel", text2);
				intent.PutExtra("ExtraTargetFragmentView", text3);
				intent.PutExtra("ExtraParentFragmentViewModel", request?.ViewModelType?.FullName);
				intent.PutExtra("ExtraTargetFragmentViewModelParameters", JsonConvert.SerializeObject(request.ParameterValues));
				ShowActivity(request, intent);
			}
			else if (request != null && request.PresentationValues?.ContainsKey("dialogViewModel") == true)
			{
				string text4 = request.PresentationValues["dialogViewModel"];
				Type type3 = ViewModelAssembly.GetType(text4);
				string fullName = viewTypeLookup.GetDialogFragmentType(type3).FullName;
				Type activityType = viewTypeLookup.GetActivityType(request.ViewModelType);
				if (base.Activity != null && base.Activity.GetType() == activityType)
				{
					ShireActivity shireActivity2 = base.Activity as ShireActivity;
					if (request != null && request.PresentationValues?.ContainsKey("replaceDialogContent") == false)
					{
						shireActivity2?.CreateTargetDialogFragment(fullName, text4, request?.ViewModelType?.FullName, new MvxBundle(request.ParameterValues));
						return;
					}
					string text5 = request.PresentationValues["replaceDialogContent"];
					Type type4 = ViewModelAssembly.GetType(text5);
					string fullName2 = viewTypeLookup.GetFragmentType(type4).FullName;
					shireActivity2?.ReplaceDialogFragmentContent(fullName2, text5, type3.FullName, new MvxBundle(request.ParameterValues));
				}
				else
				{
					Intent intent2 = CreateIntentForRequest(request);
					intent2.PutExtra("ExtraTargetDialogFragmentViewModel", text4);
					intent2.PutExtra("ExtraTargetDialogFragmentView", fullName);
					intent2.PutExtra("ExtraParentFragmentViewModel", request.ViewModelType?.FullName);
					intent2.PutExtra("ExtraTargetFragmentViewModelParameters", JsonConvert.SerializeObject(request.ParameterValues));
					ShowActivity(request, intent2);
				}
			}
			else if (request != null && request.PresentationValues?.ContainsKey("dismissChildren") == true)
			{
				if (base.Activity is IDismissible dismissible)
				{
					dismissible.Dismiss();
				}
			}
			else if (request != null && request.PresentationValues?.ContainsKey("clearAllButRequested") == true)
			{
				ClearAllAndShowActivity(request);
			}
			else
			{
				base.Show(request);
			}
		}

		public void RegisterLifecycleListeners(IAppLifecycleService appLifecycleService)
		{
			this.appLifecycleService = appLifecycleService;
			this.appLifecycleService.AppStateChanged -= CheckForWaitingDialog;
			this.appLifecycleService.AppStateChanged += CheckForWaitingDialog;
		}

		private void CheckForWaitingDialog(object sender, AppStateEventArgs e)
		{
			if (dialogQueue != null && !dialogQueue.IsEmpty && (e == null || e.CurrentState != AppLifecycleService.AppState.Background))
			{
				iFit.Logger.Log.Trace("ShirePresenter", $"Dialogs waiting in queue: {dialogQueue.Count}");
				Task.Run(async delegate
				{
					await Task.Delay(TimeSpan.FromSeconds(1.0));
					iFit.Logger.Log.Trace("ShirePresenter", "Processing dialog queue after delay...");
					ProcessDialogQueue(null);
				});
			}
		}

		private void ClearAllAndShowActivity(MvxViewModelRequest request)
		{
			Intent intent = CreateIntentForRequest(request);
			ShowActivity(request, intent);
		}

		private void CloseDialogs()
		{
			iFit.Logger.Log.Trace("Navigation", "ShirePresenter.CloseDialogs(), Current dialog ViewModel name: " + currentDialogViewModelName);
			currentDialogViewModelName = null;
			dialogQueue.Clear();
			(base.Activity as ShireActivity)?.CloseAllDialogs();
		}

		private void ShowActivity(MvxViewModelRequest request, Intent intent)
		{
			bool flag = request != null && request.PresentationValues?.ContainsKey("clearAllButRequested") == true;
			if (flag)
			{
				intent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
			}
			base.Show(intent);
			base.Activity?.Finish();
			if (flag)
			{
				iFit.Logger.Log.Trace("Navigation", "ShirePresenter.ShowActivity(), clear all but requested view model: " + request.ViewModelType.Name);
				base.Activity?.OverridePendingTransition(17432576, 17432577);
			}
		}

		public override void ChangePresentation(MvxPresentationHint hint)
		{
			if (hint is ClearDialogsPresentationHint)
			{
				CloseDialogs();
			}
			else
			{
				base.ChangePresentation(hint);
			}
		}

		public override void Close(IMvxViewModel viewModel)
		{
			try
			{
				ShireActivity shireActivity = base.Activity as ShireActivity;
				Type type = viewModel.GetType();
				iFit.Logger.Log.Trace("Navigation", "ShirePresenter.Close(), closing view model " + type.FullName);
				Type fragmentType = viewTypeLookup.GetFragmentType(type);
				if (fragmentType != null)
				{
					shireActivity?.CloseFragment(viewModel);
					ProcessDialogQueue(type.FullName);
					return;
				}
				Type dialogFragmentType = viewTypeLookup.GetDialogFragmentType(type);
				if (dialogFragmentType != null)
				{
					shireActivity?.CloseDialogFragment(viewModel);
					ProcessDialogQueue(type.FullName);
					return;
				}
				IMvxView target = null;
				if ((viewModel as ShireBaseViewModel)?.View?.TryGetTarget(out target) == true)
				{
					if (target is ShireActivity shireActivity2)
					{
						((Activity)(object)shireActivity2).Finish();
					}
					else
					{
						base.Close(viewModel);
					}
				}
				else
				{
					base.Close(viewModel);
				}
				ProcessDialogQueue(type.FullName);
			}
			catch (ObjectDisposedException)
			{
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Navigation", "ShirePresenter.Close(), Failed to Close " + viewModel?.GetType()?.Name, exception);
			}
		}

		private void _CloseActivity(ShireActivity activity)
		{
			((Activity)(object)activity).Finish();
		}
	}
	public interface IViewTypeLookup
	{
		IDictionary<Type, Type> ViewTypeMapping { get; }

		Type GetFragmentType(Type viewModelType);

		Type GetActivityType(Type viewModelType);

		Type GetViewModelType(Type viewModelType);

		Type GetDialogFragmentType(Type viewModelType);
	}
	public class ViewTypeLookup : ViewLookupBase, IViewTypeLookup
	{
		private readonly IDictionary<string, Type> fragmentLookup = new Dictionary<string, Type>();

		private readonly IDictionary<string, Type> activityLookup = new Dictionary<string, Type>();

		private readonly IDictionary<string, Type> viewModelLookup = new Dictionary<string, Type>();

		private readonly IDictionary<string, Type> dialogFragmentLookup = new Dictionary<string, Type>();

		private readonly IDictionary<string, Type> viewMappings = new Dictionary<string, Type>();

		public IDictionary<Type, Type> ViewTypeMapping { get; protected set; } = new Dictionary<Type, Type>();

		public ViewTypeLookup(Assembly viewAssembly, Assembly viewModelAssembly)
		{
			IDeviceInformation deviceInformation = Mvx.Resolve<IDeviceInformation>();
			IEnumerable<Type> enumerable = from type in viewAssembly.ExceptionSafeGetTypes()
				where !type.IsAbstract && !type.IsInterface && typeof(ShireFragment).IsAssignableFrom(type) && type.Name.EndsWith("View", StringComparison.Ordinal)
				select type;
			IEnumerable<Type> enumerable2 = from type in viewAssembly.ExceptionSafeGetTypes()
				where !type.IsAbstract && !type.IsInterface && typeof(ShireActivity).IsAssignableFrom(type) && type.Name.EndsWith("View", StringComparison.Ordinal)
				select type;
			IEnumerable<Type> enumerable3 = from type in viewModelAssembly.ExceptionSafeGetTypes()
				where !type.IsAbstract && !type.IsInterface && typeof(ShireBaseViewModel).IsAssignableFrom(type) && type.Name.EndsWith("ViewModel", StringComparison.Ordinal)
				select type;
			IEnumerable<Type> enumerable4 = from type in viewAssembly.ExceptionSafeGetTypes()
				where !type.IsAbstract && !type.IsInterface && typeof(ShireDialogFragment).IsAssignableFrom(type) && type.Name.EndsWith("View", StringComparison.Ordinal)
				select type;
			foreach (Type item in enumerable)
			{
				PlatformAttribute customAttribute = item.GetCustomAttribute<PlatformAttribute>();
				if (customAttribute != null)
				{
					if (ShouldRegisterItem(customAttribute, deviceInformation.IsTablet))
					{
						fragmentLookup.Add(GetStrippedName(customAttribute.VMType), item);
						ViewTypeMapping.Add(customAttribute.VMType, item);
					}
				}
				else
				{
					fragmentLookup.Add(GetStrippedName(item), item);
				}
			}
			foreach (Type item2 in enumerable2)
			{
				PlatformAttribute customAttribute2 = item2.GetCustomAttribute<PlatformAttribute>();
				if (customAttribute2 != null)
				{
					if (ShouldRegisterItem(customAttribute2, deviceInformation.IsTablet))
					{
						activityLookup.Add(GetStrippedName(customAttribute2.VMType), item2);
						ViewTypeMapping.Add(customAttribute2.VMType, item2);
					}
				}
				else
				{
					activityLookup.Add(GetStrippedName(item2), item2);
				}
			}
			foreach (Type item3 in enumerable3)
			{
				PlatformAttribute customAttribute3 = item3.GetCustomAttribute<PlatformAttribute>();
				if (customAttribute3 != null)
				{
					if (ShouldRegisterItem(customAttribute3, deviceInformation.IsTablet))
					{
						viewModelLookup.Add(GetStrippedName(item3), item3);
					}
				}
				else
				{
					viewModelLookup.Add(GetStrippedName(item3), item3);
				}
			}
			foreach (Type item4 in enumerable4)
			{
				PlatformAttribute customAttribute4 = item4.GetCustomAttribute<PlatformAttribute>();
				if (customAttribute4 != null)
				{
					if (ShouldRegisterItem(customAttribute4, deviceInformation.IsTablet))
					{
						dialogFragmentLookup.Add(GetStrippedName(customAttribute4.VMType), item4);
						ViewTypeMapping.Add(customAttribute4.VMType, item4);
					}
				}
				else
				{
					dialogFragmentLookup.Add(GetStrippedName(item4), item4);
				}
			}
		}

		public Type GetFragmentType(Type type)
		{
			return GetItem(fragmentLookup, type);
		}

		public Type GetActivityType(Type type)
		{
			return GetItem(activityLookup, type);
		}

		public Type GetViewModelType(Type type)
		{
			return GetItem(viewModelLookup, type);
		}

		public Type GetDialogFragmentType(Type type)
		{
			return GetItem(dialogFragmentLookup, type);
		}

		private Type GetItem(IDictionary<string, Type> lookup, Type type)
		{
			string strippedName = GetStrippedName(type);
			if (!lookup.ContainsKey(strippedName))
			{
				return null;
			}
			return lookup[strippedName];
		}
	}
}
namespace Shire.Android.ShireMvx.MvxBaseModified
{
	[Register("shire.android.shiremvx.mvxbasemodified.ShireMvxActivity")]
	public abstract class ShireMvxActivity : MvxEventSourceActivity, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner
	{
		public object DataContext
		{
			get
			{
				return BindingContext.DataContext;
			}
			set
			{
				BindingContext.DataContext = value;
			}
		}

		public IMvxViewModel ViewModel
		{
			get
			{
				return DataContext as IMvxViewModel;
			}
			set
			{
				DataContext = value;
				OnViewModelSet();
			}
		}

		public IMvxBindingContext BindingContext { get; set; }

		protected ShireMvxActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected ShireMvxActivity()
		{
			BindingContext = new MvxAndroidBindingContext(this, this);
			this.AddEventListeners();
		}

		public void MvxInternalStartActivityForResult(Intent intent, int requestCode)
		{
			StartActivityForResult(intent, requestCode);
		}

		public override void SetContentView(int layoutResId)
		{
			View contentView = this.BindingInflate(layoutResId, null);
			SetContentView(contentView);
		}

		protected virtual void OnViewModelSet()
		{
		}

		protected override void AttachBaseContext(Context @base)
		{
			if (this is IMvxAndroidSplashScreenActivity)
			{
				base.AttachBaseContext(@base);
			}
			else
			{
				base.AttachBaseContext(ShireMvxContextWrapper.Wrap(@base, this));
			}
		}
	}
	public abstract class MvxActivity<TViewModel> : ShireMvxActivity, IMvxAndroidView<TViewModel>, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
	{
		public new TViewModel ViewModel
		{
			get
			{
				return (TViewModel)base.ViewModel;
			}
			set
			{
				base.ViewModel = value;
			}
		}
	}
	[Register("shire.android.shiremvx.mvxbasemodified.ShireMvxContextWrapper")]
	public class ShireMvxContextWrapper : ContextWrapper
	{
		private LayoutInflater _inflater;

		private readonly IMvxBindingContextOwner _bindingContextOwner;

		public static ContextWrapper Wrap(Context @base, IMvxBindingContextOwner bindingContextOwner)
		{
			return new ShireMvxContextWrapper(@base, bindingContextOwner);
		}

		protected ShireMvxContextWrapper(Context context, IMvxBindingContextOwner bindingContextOwner)
			: base(context)
		{
			if (bindingContextOwner == null)
			{
				throw new InvalidOperationException("Wrapper can only be set on IMvxBindingContextOwner");
			}
			_bindingContextOwner = bindingContextOwner;
		}

		public override Java.Lang.Object GetSystemService(string name)
		{
			if (string.Equals(name, "layout_inflater", StringComparison.InvariantCulture))
			{
				if (_inflater == null)
				{
					_inflater = new ShireMvxLayoutInflater(LayoutInflater.From(BaseContext), this, null, cloned: false);
				}
				return _inflater;
			}
			return base.GetSystemService(name);
		}
	}
	[Register("shire.android.shiremvx.mvxbasemodified.ShireMvxFragmentActivity")]
	public class ShireMvxFragmentActivity : MvxEventSourceFragmentActivity, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner
	{
		public object DataContext
		{
			get
			{
				return BindingContext.DataContext;
			}
			set
			{
				BindingContext.DataContext = value;
			}
		}

		public IMvxViewModel ViewModel
		{
			get
			{
				return DataContext as IMvxViewModel;
			}
			set
			{
				DataContext = value;
				OnViewModelSet();
			}
		}

		public IMvxBindingContext BindingContext { get; set; }

		protected ShireMvxFragmentActivity()
		{
			BindingContext = new MvxAndroidBindingContext((Context)(object)this, this);
			this.AddEventListeners();
		}

		protected ShireMvxFragmentActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public void MvxInternalStartActivityForResult(Intent intent, int requestCode)
		{
			StartActivityForResult(intent, requestCode);
		}

		protected virtual void OnViewModelSet()
		{
		}

		public override void SetContentView(int layoutResId)
		{
			View contentView = this.BindingInflate(layoutResId, null);
			((Activity)(object)this).SetContentView(contentView);
		}

		protected override void AttachBaseContext(Context @base)
		{
			((ContextWrapper)(object)this).AttachBaseContext((Context)ShireMvxContextWrapper.Wrap(@base, this));
		}
	}
	public abstract class ShireMvxFragmentActivity<TViewModel> : ShireMvxFragmentActivity, IMvxAndroidView<TViewModel>, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
	{
		public new TViewModel ViewModel
		{
			get
			{
				return (TViewModel)base.ViewModel;
			}
			set
			{
				base.ViewModel = value;
			}
		}
	}
	[Register("shire.android.shiremvx.mvxbasemodified.ShireMvxLayoutInflater")]
	public class ShireMvxLayoutInflater : LayoutInflater
	{
		public class MvxBindingVisitor
		{
			private static readonly Java.Lang.Boolean TheTruth = Java.Lang.Boolean.True;

			public IMvxLayoutInflaterHolderFactory? Factory { get; set; }

			public View? OnViewCreated(View? view, Context? context, IAttributeSet? attrs)
			{
				if (Factory != null && view != null && view.GetTag(Resource.Id.MvvmCrossTagId) != TheTruth)
				{
					view = Factory.BindCreatedView(view, context, attrs);
					view.SetTag(Resource.Id.MvvmCrossTagId, TheTruth);
				}
				return view;
			}
		}

		private class ConstructorArgs
		{
			public Java.Lang.Object[] constructorArgs { get; set; }

			public Java.Lang.Object? lastContext { get; set; }
		}

		private class DelegateFactory2 : IMvxLayoutInflaterFactory
		{
			private const string DelegateFactory2Tag = "DelegateFactory2";

			private readonly IFactory2 _factory;

			private readonly MvxBindingVisitor _factoryPlaceholder;

			public DelegateFactory2(IFactory2 factoryToWrap, MvxBindingVisitor binder)
			{
				_factory = factoryToWrap;
				_factoryPlaceholder = binder;
			}

			public View? OnCreateView(View? parent, string name, Context context, IAttributeSet attrs)
			{
				if (Debug)
				{
					Mvx.TaggedTrace("DelegateFactory2", "OnCreateView ... {name}", name);
				}
				return _factoryPlaceholder.OnViewCreated(_factory.OnCreateView(parent, name, context, attrs), context, attrs);
			}
		}

		private class DelegateFactory1 : IMvxLayoutInflaterFactory
		{
			private const string DelegateFactory1Tag = "DelegateFactory1";

			private readonly IFactory _factory;

			private readonly MvxBindingVisitor _factoryPlaceholder;

			public DelegateFactory1(IFactory factoryToWrap, MvxBindingVisitor bindingVisitor)
			{
				_factory = factoryToWrap;
				_factoryPlaceholder = bindingVisitor;
			}

			public View? OnCreateView(View? parent, string name, Context context, IAttributeSet attrs)
			{
				if (Debug)
				{
					Mvx.TaggedTrace("DelegateFactory1", "OnCreateView ... {name}", name);
				}
				return _factoryPlaceholder.OnViewCreated(_factory.OnCreateView(name, context, attrs), context, attrs);
			}
		}

		private class PrivateFactoryWrapper2 : Java.Lang.Object, IFactory2, IFactory, IJavaObject, IDisposable, IJavaPeerable
		{
			private const string PrivateFactoryWrapper2Tag = "PrivateFactoryWrapper2";

			private readonly IFactory2 _factory2;

			private readonly MvxBindingVisitor _bindingVisitor;

			private readonly ShireMvxLayoutInflater _inflater;

			internal PrivateFactoryWrapper2(IFactory2 factory2, ShireMvxLayoutInflater inflater, MvxBindingVisitor bindingVisitor)
			{
				_factory2 = factory2;
				_inflater = inflater;
				_bindingVisitor = bindingVisitor;
			}

			[Preserve]
			public PrivateFactoryWrapper2(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			public View? OnCreateView(string name, Context context, IAttributeSet attrs)
			{
				if (Debug)
				{
					Mvx.TaggedTrace("PrivateFactoryWrapper2", "OnCreateView 2 ... {name}", "PrivateFactoryWrapper2", name);
				}
				return _bindingVisitor.OnViewCreated(_factory2.OnCreateView(name, context, attrs), context, attrs);
			}

			public View? OnCreateView(View? parent, string name, Context context, IAttributeSet attrs)
			{
				if (Debug)
				{
					Mvx.TaggedTrace("PrivateFactoryWrapper2", "OnCreateView 3 ... {name}", name);
				}
				return _bindingVisitor.OnViewCreated(_inflater.CreateCustomViewInternal(parent, _factory2.OnCreateView(parent, name, context, attrs), name, context, attrs), context, attrs);
			}
		}

		private const string Tag = "ShireMvxLayoutInflater";

		private static readonly BuildVersionCodes Sdk = Build.VERSION.SdkInt;

		private static readonly string[] ClassPrefixList = new string[3] { "android.widget.", "android.webkit.", "android.app." };

		private readonly MvxBindingVisitor _bindingVisitor;

		private IMvxAndroidViewFactory? _androidViewFactory;

		private IMvxLayoutInflaterHolderFactoryFactory? _layoutInflaterHolderFactoryFactory;

		private Field? _constructorArgs;

		private bool _setPrivateFactory;

		public static bool Debug { get; set; }

		protected IMvxAndroidViewFactory? AndroidViewFactory
		{
			get
			{
				if (_androidViewFactory != null)
				{
					return _androidViewFactory;
				}
				try
				{
					if (Mvx.TryResolve<IMvxAndroidViewFactory>(out var service))
					{
						_androidViewFactory = service;
					}
					else
					{
						Mvx.TaggedError("ShireMvxLayoutInflater", "Could not resolve IMvxAndroidViewFactory");
					}
				}
				catch (System.Exception ex)
				{
					Mvx.TaggedError("ShireMvxLayoutInflater", "Could not resolve IMvxAndroidViewFactory: {0}", ex);
					return null;
				}
				return _androidViewFactory;
			}
		}

		protected IMvxLayoutInflaterHolderFactoryFactory? FactoryFactory
		{
			get
			{
				if (_layoutInflaterHolderFactoryFactory != null)
				{
					return _layoutInflaterHolderFactoryFactory;
				}
				try
				{
					if (Mvx.TryResolve<IMvxLayoutInflaterHolderFactoryFactory>(out var service))
					{
						_layoutInflaterHolderFactoryFactory = service;
					}
					else
					{
						Mvx.TaggedError("ShireMvxLayoutInflater", "Could not resolve IMvxAndroidViewFactory");
					}
				}
				catch (Java.Lang.Exception ex)
				{
					Mvx.TaggedError("ShireMvxLayoutInflater", "Could not resolve IMvxLayoutInflaterHolderFactoryFactory: {0}", ex);
				}
				return _layoutInflaterHolderFactoryFactory;
			}
		}

		public ShireMvxLayoutInflater(Context context)
			: base(context)
		{
			_bindingVisitor = new MvxBindingVisitor();
			SetupLayoutFactories(cloned: false);
		}

		public ShireMvxLayoutInflater(LayoutInflater original, Context? newContext, MvxBindingVisitor? bindingVisitor, bool cloned)
			: base(original, newContext)
		{
			_bindingVisitor = bindingVisitor ?? new MvxBindingVisitor();
			SetupLayoutFactories(cloned);
		}

		[Preserve]
		public ShireMvxLayoutInflater(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
			_bindingVisitor = new MvxBindingVisitor();
			SetupLayoutFactories(cloned: false);
		}

		public override LayoutInflater CloneInContext(Context? newContext)
		{
			return new ShireMvxLayoutInflater(this, newContext, _bindingVisitor, cloned: true);
		}

		public override View? Inflate(int resource, ViewGroup? root, bool attachToRoot)
		{
			SetPrivateFactoryInternal();
			IMvxLayoutInflaterHolderFactory factory = _bindingVisitor.Factory;
			try
			{
				IMvxLayoutInflaterHolderFactory mvxLayoutInflaterHolderFactory = null;
				IMvxAndroidBindingContext mvxAndroidBindingContext = MvxAndroidBindingContextHelpers.Current();
				if (mvxAndroidBindingContext != null)
				{
					mvxLayoutInflaterHolderFactory = FactoryFactory?.Create(mvxAndroidBindingContext.DataContext);
					if (mvxLayoutInflaterHolderFactory != null)
					{
						_bindingVisitor.Factory = mvxLayoutInflaterHolderFactory;
					}
				}
				View view = base.Inflate(resource, root, attachToRoot);
				if (mvxAndroidBindingContext != null && mvxLayoutInflaterHolderFactory != null)
				{
					mvxAndroidBindingContext.RegisterBindingsWithClearKey(view, mvxLayoutInflaterHolderFactory.CreatedBindings);
				}
				return view;
			}
			finally
			{
				_bindingVisitor.Factory = factory;
			}
		}

		protected override View? OnCreateView(View? parent, string? name, IAttributeSet? attrs)
		{
			if (Debug)
			{
				Mvx.TaggedTrace("ShireMvxLayoutInflater", "OnCreateView 3 ... {name}", name);
			}
			return _bindingVisitor.OnViewCreated(base.OnCreateView(parent, name, attrs), Context, attrs);
		}

		protected override View? OnCreateView(string? name, IAttributeSet? attrs)
		{
			if (Debug)
			{
				Mvx.TaggedTrace("ShireMvxLayoutInflater", "OnCreateView 2 ... {name}", name);
			}
			View view = null;
			if (name != null && Context != null && attrs != null)
			{
				view = AndroidViewFactory?.CreateView(null, name, Context, attrs);
			}
			if (view == null)
			{
				view = PhoneLayoutInflaterOnCreateView(name, attrs) ?? base.OnCreateView(name, attrs);
			}
			return _bindingVisitor.OnViewCreated(view, Context, attrs);
		}

		public override View? OnCreateView(Context viewContext, View? parent, string name, IAttributeSet? attrs)
		{
			if (Debug)
			{
				Mvx.TaggedTrace("ShireMvxLayoutInflater", "OnCreateView 4 ... {name}", name);
			}
			return _bindingVisitor.OnViewCreated(base.OnCreateView(viewContext, parent, name, attrs), viewContext, attrs);
		}

		private View? PhoneLayoutInflaterOnCreateView(string? name, IAttributeSet? attrs)
		{
			if (Debug)
			{
				Mvx.TaggedTrace("ShireMvxLayoutInflater", "PhoneLayoutInflaterOnCreateView ... {name}", name);
			}
			string[] classPrefixList = ClassPrefixList;
			foreach (string prefix in classPrefixList)
			{
				try
				{
					return CreateView(name, prefix, attrs);
				}
				catch (ClassNotFoundException)
				{
				}
			}
			return null;
		}

		[Export]
		public void setFactory(IFactory factory)
		{
			if (!(factory is ShireMvxLayoutInflaterCompat.FactoryWrapper))
			{
				base.Factory = new ShireMvxLayoutInflaterCompat.FactoryWrapper(new DelegateFactory1(factory, _bindingVisitor));
			}
			else
			{
				base.Factory = factory;
			}
		}

		[Export]
		public void setFactory2(IFactory2 factory2)
		{
			if (!(factory2 is ShireMvxLayoutInflaterCompat.FactoryWrapper2))
			{
				base.Factory2 = new ShireMvxLayoutInflaterCompat.FactoryWrapper2(new DelegateFactory2(factory2, _bindingVisitor));
			}
			else
			{
				base.Factory2 = factory2;
			}
		}

		private void SetupLayoutFactories(bool cloned)
		{
			if (cloned)
			{
				return;
			}
			if (Sdk > BuildVersionCodes.Honeycomb)
			{
				if (base.Factory2 != null && !(base.Factory2 is ShireMvxLayoutInflaterCompat.FactoryWrapper2))
				{
					ShireMvxLayoutInflaterCompat.SetFactory(this, new DelegateFactory2(base.Factory2, _bindingVisitor));
				}
			}
			else if (base.Factory != null && !(base.Factory is ShireMvxLayoutInflaterCompat.FactoryWrapper))
			{
				ShireMvxLayoutInflaterCompat.SetFactory(this, new DelegateFactory1(base.Factory, _bindingVisitor));
			}
		}

		private void SetPrivateFactoryInternal()
		{
			if (_setPrivateFactory || Build.VERSION.SdkInt < BuildVersionCodes.Honeycomb)
			{
				return;
			}
			if (!(Context is IFactory2))
			{
				_setPrivateFactory = true;
				return;
			}
			try
			{
				Class obj = Class.FromType(typeof(LayoutInflater));
				Method method = obj.GetMethod("setPrivateFactory", Class.FromType(typeof(IFactory2)));
				method.Accessible = true;
				method.Invoke(this, new PrivateFactoryWrapper2((IFactory2)Context, this, _bindingVisitor));
			}
			catch (Java.Lang.Exception ex)
			{
				Mvx.TaggedWarning("ShireMvxLayoutInflater", "Cannot invoke LayoutInflater.setPrivateFactory :\n{0}", ex.StackTrace);
			}
			_setPrivateFactory = true;
		}

		internal View? CreateCustomViewInternal(View? parent, View? view, string name, Context viewContext, IAttributeSet attrs)
		{
			if (Debug)
			{
				Mvx.TaggedTrace("ShireMvxLayoutInflater", "CreateCustomViewInternal ... {name}", name);
			}
			if (view == null && !string.IsNullOrWhiteSpace(name) && name.IndexOf('.', StringComparison.InvariantCulture) > -1)
			{
				if (!name.StartsWith("com.android.internal.", StringComparison.InvariantCulture))
				{
					view = AndroidViewFactory?.CreateView(parent, name, viewContext, attrs);
				}
				if (view == null)
				{
					ConstructorArgs constructorArgs = GetConstructorArgs(viewContext);
					try
					{
						view = CreateViewCompat(viewContext, name, attrs);
					}
					catch (ClassNotFoundException)
					{
					}
					finally
					{
						RestoreConstructorArgs(constructorArgs.constructorArgs, constructorArgs.lastContext);
					}
				}
			}
			return view;
		}

		private ConstructorArgs GetConstructorArgs(Context viewContext)
		{
			if (Build.VERSION.SdkInt > BuildVersionCodes.P)
			{
				return new ConstructorArgs
				{
					constructorArgs = null,
					lastContext = null
				};
			}
			if (_constructorArgs == null)
			{
				Class obj = Class.FromType(typeof(LayoutInflater));
				_constructorArgs = obj.GetDeclaredField("mConstructorArgs");
				_constructorArgs.Accessible = true;
			}
			Java.Lang.Object[] array = (Java.Lang.Object[])_constructorArgs.Get(this);
			Java.Lang.Object lastContext = array[0];
			if (array != null)
			{
				array[0] = viewContext;
				_constructorArgs.Set(this, array);
			}
			return new ConstructorArgs
			{
				constructorArgs = array,
				lastContext = lastContext
			};
		}

		private void RestoreConstructorArgs(Java.Lang.Object[] constructorArgsArr, Java.Lang.Object? lastContext)
		{
			if (Build.VERSION.SdkInt <= BuildVersionCodes.P && constructorArgsArr != null && lastContext != null)
			{
				constructorArgsArr[0] = lastContext;
				_constructorArgs?.Set(this, constructorArgsArr);
			}
		}

		private View? CreateViewCompat(Context viewContext, string name, IAttributeSet attrs)
		{
			if (Build.VERSION.SdkInt > BuildVersionCodes.P)
			{
				return CreateView(viewContext, name, null, attrs);
			}
			return CreateView(name, null, attrs);
		}
	}
	public static class ShireMvxLayoutInflaterCompat
	{
		internal class FactoryWrapper : Java.Lang.Object, LayoutInflater.IFactory, IJavaObject, IDisposable, IJavaPeerable
		{
			protected readonly IMvxLayoutInflaterFactory DelegateFactory;

			[Preserve]
			public FactoryWrapper(IntPtr handle, JniHandleOwnership ownership)
				: base(handle, ownership)
			{
			}

			public FactoryWrapper(IMvxLayoutInflaterFactory delegateFactory)
			{
				DelegateFactory = delegateFactory;
			}

			public View? OnCreateView(string name, Context context, IAttributeSet attrs)
			{
				return DelegateFactory.OnCreateView(null, name, context, attrs);
			}
		}

		internal class FactoryWrapper2 : FactoryWrapper, LayoutInflater.IFactory2, LayoutInflater.IFactory, IJavaObject, IDisposable, IJavaPeerable
		{
			[Preserve]
			public FactoryWrapper2(IntPtr handle, JniHandleOwnership ownership)
				: base(handle, ownership)
			{
			}

			public FactoryWrapper2(IMvxLayoutInflaterFactory delegateFactory)
				: base(delegateFactory)
			{
			}

			public View? OnCreateView(View? parent, string name, Context context, IAttributeSet attrs)
			{
				return DelegateFactory.OnCreateView(parent, name, context, attrs);
			}
		}

		private static readonly BuildVersionCodes Sdk = Build.VERSION.SdkInt;

		private static Field? _layoutInflaterFactory2Field;

		private static bool _checkedField;

		public static void SetFactory(LayoutInflater layoutInflater, IMvxLayoutInflaterFactory? factory)
		{
			if (Sdk >= BuildVersionCodes.Lollipop)
			{
				layoutInflater.Factory2 = ((factory != null) ? new FactoryWrapper2(factory) : null);
			}
			else if (Sdk >= BuildVersionCodes.Honeycomb)
			{
				FactoryWrapper2 factoryWrapper = (FactoryWrapper2)(layoutInflater.Factory2 = ((factory != null) ? new FactoryWrapper2(factory) : null));
				LayoutInflater.IFactory factory3 = layoutInflater.Factory;
				LayoutInflater.IFactory2 factory4 = factory3 as LayoutInflater.IFactory2;
				ForceSetFactory2(layoutInflater, factory4 ?? factoryWrapper);
			}
			else
			{
				layoutInflater.Factory = ((factory != null) ? new FactoryWrapper(factory) : null);
			}
		}

		private static void ForceSetFactory2(LayoutInflater inflater, LayoutInflater.IFactory2? factory)
		{
			if (!_checkedField)
			{
				try
				{
					Class obj = Class.FromType(typeof(LayoutInflater));
					_layoutInflaterFactory2Field = obj.GetDeclaredField("mFactory2");
					_layoutInflaterFactory2Field.Accessible = true;
				}
				catch (NoSuchFieldException)
				{
					Mvx.TaggedError("ShireMvxLayoutInflaterCompat", "ForceSetFactory2 Could not find field 'mFactory2' on class {0}; inflation may have unexpected results.", Class.FromType(typeof(LayoutInflater)).Name);
				}
				_checkedField = true;
			}
			if (_layoutInflaterFactory2Field != null && factory != null)
			{
				try
				{
					_layoutInflaterFactory2Field.Set(inflater, (Java.Lang.Object)factory);
				}
				catch (IllegalAccessException)
				{
					Mvx.TaggedError("ShireMvxLayoutInflaterCompat", "ForceSetFactory2 could not set the Factory2 on LayoutInflater {0} ; inflation may have unexpected results.", inflater.ToString());
				}
			}
		}
	}
}
namespace Shire.Android.Services
{
	public class AppLauncher : AppLauncherBase
	{
		public override void LaunchApp(LaunchableApp app)
		{
			string text = ActionStringFromApplicationValue(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				LaunchApp(text);
			}
		}

		public override void LaunchApp(string action)
		{
			Activity activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
			Intent intent = new Intent();
			intent.SetAction(action);
			intent.AddCategory("android.intent.category.DEFAULT");
			intent.AddFlags(ActivityFlags.NewTask);
			activity.ApplicationContext.StartActivity(intent);
		}

		public AppLauncher()
		{
			base.ApplicationActions = new Dictionary<LaunchableApp, string>
			{
				{
					LaunchableApp.WifiSettings,
					"android.settings.WIFI_SETTINGS"
				},
				{
					LaunchableApp.EruUpdate,
					"com.ifit.eru.UPDATE"
				},
				{
					LaunchableApp.Settings,
					"android.settings.SETTINGS"
				},
				{
					LaunchableApp.BleSettings,
					"android.settings.BLUETOOTH_SETTINGS"
				}
			};
		}
	}
	public class AppLinkingService : AppLinkingServiceBase
	{
		private static object instanceLock = new object();

		private static AppLinkingService _instance;

		public const string DeepLinkIntentKey = "DeepLinkIntentKey";

		public static AppLinkingService Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (_instance == null)
					{
						_instance = new AppLinkingService();
					}
				}
				return _instance;
			}
		}

		protected AppLinkingService()
		{
		}

		public override bool OpenLinkUrl(string destUrlString, string fallbackUrlString = null)
		{
			bool result = base.OpenLinkUrl(destUrlString, fallbackUrlString);
			if (destUrlString.Equals(base.ExternalUriString, StringComparison.OrdinalIgnoreCase))
			{
				base.ExternalUriString = null;
			}
			return result;
		}

		protected override bool ShouldOpenFallback(string destUrl)
		{
			global::Android.Net.Uri uri = global::Android.Net.Uri.Parse(destUrl);
			Intent intent = new Intent("android.intent.action.VIEW", uri);
			IList<ResolveInfo> list = Application.Context.PackageManager.QueryIntentActivities(intent, (PackageInfoFlags)0);
			return list.Count == 0;
		}
	}
	public class AppVersionService : IAppVersionService
	{
		protected const string Tag = "AppVersionService";

		public VersionInfo MainAppVersionInfo { get; }

		public Dictionary<string, VersionInfo> SupplementalVersionInfo { get; }

		public AppVersionService()
		{
			MainAppVersionInfo = GetVersionInfo(Application.Context.PackageName);
			SupplementalVersionInfo = new Dictionary<string, VersionInfo>();
		}

		protected VersionInfo GetVersionInfo(string packageName)
		{
			try
			{
				PackageInfo packageInfo = Application.Context.PackageManager.GetPackageInfo(packageName, (PackageInfoFlags)0);
				ApplicationInfo applicationInfo = Application.Context.PackageManager.GetApplicationInfo(packageName, PackageInfoFlags.MetaData);
				string branch = applicationInfo.MetaData.GetString("com.ifit.wolf.branch", null);
				return new VersionInfo(packageInfo.VersionName, packageInfo.VersionCode, branch);
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Trace("AppVersionService", "Failed to retrieve package info for: " + packageName, exception);
			}
			return null;
		}
	}
	public class BleRadioStatusService : IBleRadioStatusService, IDisposable
	{
		private readonly Subject<bool> _whenBluetoothRadioEnabledChanged = new Subject<bool>();

		private readonly RxBroadcastReceiver broadcastReceiver;

		private readonly IDisposable broadcastSub;

		private IDisposable cycleRadioSub;

		protected bool isCyclingRadio;

		public IObservable<bool> WhenBluetoothRadioEnabledChanged => _whenBluetoothRadioEnabledChanged;

		public BleRadioStatusService()
		{
			broadcastReceiver = new RxBroadcastReceiver(new IntentFilter("android.bluetooth.adapter.action.STATE_CHANGED"));
			broadcastSub = broadcastReceiver.WhenBroadcastReceived.Subscribe(OnReceive);
			broadcastReceiver.StartListening(Application.Context);
		}

		public bool IsBluetoothRadioEnabled()
		{
			BluetoothAdapter defaultAdapter = BluetoothAdapter.DefaultAdapter;
			if (defaultAdapter == null)
			{
				iFit.Logger.Log.Error("Ble", "Default Bluetooth Adapter was null");
				return false;
			}
			bool isEnabled = defaultAdapter.IsEnabled;
			iFit.Logger.Log.Trace("Ble", $"IsBluetoothRadioEnabled (): returning {isEnabled}");
			return isEnabled;
		}

		public virtual void RequestEnableBluetooth(bool notifyIfCannotEnable, string currentScreen = null, Action onCancel = null)
		{
			string text = string.Format("RequestEnableBluetooth called{0}", (currentScreen == null) ? string.Empty : (" in " + currentScreen));
			iFit.Logger.Log.Trace("Ble", text);
			if (!isCyclingRadio)
			{
				CycleBluetoothRadio();
			}
		}

		public bool CheckAndRequestBluetooth(bool notifyIfCannotEnable, string currentScreen = null, Action onCancel = null)
		{
			if (IsBluetoothRadioEnabled())
			{
				return true;
			}
			RequestEnableBluetooth(notifyIfCannotEnable, currentScreen, onCancel);
			return false;
		}

		public void CycleBluetoothRadio()
		{
			iFit.Logger.Log.Trace("Ble", "Cycling BLE radio");
			BluetoothAdapter defaultAdapter = BluetoothAdapter.DefaultAdapter;
			if (defaultAdapter == null)
			{
				iFit.Logger.Log.Error("Ble", "Could not cycle BLE radio, adapter was null");
				return;
			}
			isCyclingRadio = true;
			cycleRadioSub = WhenBluetoothRadioEnabledChanged.Where((bool isOn) => !isOn).Take(1).Delay(TimeSpan.FromMilliseconds(300.0))
				.Timeout(TimeSpan.FromSeconds(10.0))
				.Subscribe(CycleRadioReenable, CycleRadioError);
			defaultAdapter.Disable();
		}

		public void EnableBleRadio()
		{
			BluetoothAdapter defaultAdapter = BluetoothAdapter.DefaultAdapter;
			if (defaultAdapter == null)
			{
				iFit.Logger.Log.Error("Ble", "Default Bluetooth Adapter was null");
				return;
			}
			if (defaultAdapter.IsEnabled)
			{
				iFit.Logger.Log.Trace("Ble", "Not enabling Bluetooth because it is already enabled");
				return;
			}
			iFit.Logger.Log.Trace("Ble", "Enabling Bluetooth");
			defaultAdapter.Enable();
		}

		public void DisableBleRadio()
		{
			BluetoothAdapter defaultAdapter = BluetoothAdapter.DefaultAdapter;
			if (defaultAdapter == null)
			{
				iFit.Logger.Log.Error("Ble", "Default Bluetooth Adapter was null");
				return;
			}
			if (!defaultAdapter.IsEnabled)
			{
				iFit.Logger.Log.Trace("Ble", "Not disabling Bluetooth because it is already disabled");
				return;
			}
			iFit.Logger.Log.Trace("Ble", "Disabling Bluetooth");
			defaultAdapter.Disable();
		}

		private void CycleRadioReenable(bool _)
		{
			cycleRadioSub?.Dispose();
			cycleRadioSub = null;
			isCyclingRadio = false;
			EnableBleRadio();
		}

		private void CycleRadioError(System.Exception ex)
		{
			iFit.Logger.Log.Error("Ble", "Exception cycling BLE radio", ex);
			CycleRadioReenable(_: true);
		}

		public void Dispose()
		{
			_whenBluetoothRadioEnabledChanged.Dispose();
			broadcastSub?.Dispose();
			cycleRadioSub?.Dispose();
			broadcastReceiver?.StopListening(Application.Context);
		}

		private void OnReceive(Intent intent)
		{
			if (intent.Action == "android.bluetooth.adapter.action.STATE_CHANGED")
			{
				global::Android.Bluetooth.State intExtra = (global::Android.Bluetooth.State)intent.GetIntExtra("android.bluetooth.adapter.extra.STATE", -2147483648);
				if (intExtra == global::Android.Bluetooth.State.On || intExtra == global::Android.Bluetooth.State.Off)
				{
					bool value = intExtra == global::Android.Bluetooth.State.On;
					_whenBluetoothRadioEnabledChanged.OnNext(value);
				}
			}
		}
	}
	public class BranchApiService : BranchApiServiceBase
	{
		protected override HttpClient GetHttpClient(System.Uri apiUri)
		{
			return new HttpClient(new NativeMessageHandler())
			{
				BaseAddress = apiUri
			};
		}
	}
	public class ClearCookiesService : IClearCookiesService
	{
		void IClearCookiesService.ClearCookies()
		{
			global::Android.Webkit.CookieManager.Instance?.RemoveAllCookies(null);
			global::Android.Webkit.CookieManager.Instance?.Flush();
		}
	}
	public abstract class WifiService : BaseWifiService
	{
		private const string Tag = "Wifi";

		private const int MaxSignalStrength = 6;

		private const int ScanTimeoutSeconds = 35;

		private const double EnablingTimeoutSeconds = 3.0;

		private readonly WifiManager wifiMan;

		private readonly Context context;

		private readonly WifiNetworkInfo DefaultWifiNetworkInfo = new WifiNetworkInfo();

		private int wifiNetworkId = -1;

		private IDisposable signalStrengthTimer;

		private RxBroadcastReceiver enabledChangeBR;

		private RxBroadcastReceiver networkStateChangeBR;

		private RxBroadcastReceiver networkChangeBR;

		private IDisposable enablingTimeoutListener;

		private bool showingEnablingTimeout;

		private DateTime enablingStartTime;

		private readonly Dictionary<NetworkInfo.DetailedState, WifiNetworkState> DetailStateToNetworkStateDic = new Dictionary<NetworkInfo.DetailedState, WifiNetworkState>
		{
			{
				NetworkInfo.DetailedState.Authenticating,
				WifiNetworkState.Authenticating
			},
			{
				NetworkInfo.DetailedState.Blocked,
				WifiNetworkState.Blocked
			},
			{
				NetworkInfo.DetailedState.CaptivePortalCheck,
				WifiNetworkState.CaptivePortalCheck
			},
			{
				NetworkInfo.DetailedState.Connected,
				WifiNetworkState.Connected
			},
			{
				NetworkInfo.DetailedState.Connecting,
				WifiNetworkState.Connecting
			},
			{
				NetworkInfo.DetailedState.Disconnected,
				WifiNetworkState.Disconnected
			},
			{
				NetworkInfo.DetailedState.Disconnecting,
				WifiNetworkState.Disconnecting
			},
			{
				NetworkInfo.DetailedState.Failed,
				WifiNetworkState.Failed
			},
			{
				NetworkInfo.DetailedState.Idle,
				WifiNetworkState.Idle
			},
			{
				NetworkInfo.DetailedState.ObtainingIpaddr,
				WifiNetworkState.ObtainingIpaddr
			},
			{
				NetworkInfo.DetailedState.Scanning,
				WifiNetworkState.Scanning
			},
			{
				NetworkInfo.DetailedState.Suspended,
				WifiNetworkState.Suspended
			},
			{
				NetworkInfo.DetailedState.VerifyingPoorLink,
				WifiNetworkState.VerifyingPoorLink
			}
		};

		public override bool IsWifiEnabled => wifiMan?.IsWifiEnabled == true;

		public override WifiNetworkInfo ActiveNetworkInfo => GetUpdatedActiveConnection();

		public WifiService(IConnectivity connectivity, IIfitApiService ifitApi, WifiManager wifi, Context appContext)
			: base(connectivity, ifitApi)
		{
			wifiMan = wifi;
			context = appContext;
			if (wifiMan.ConnectionInfo != null && wifiMan.ConnectionInfo.NetworkId != -1)
			{
				base.CurrentSignalStrength = WifiManager.CalculateSignalLevel(wifiMan.ConnectionInfo.Rssi, 6);
			}
			StartWifiEnabledChange();
			StartListeningForNetworkStatusChange();
			StartListeningForNetworkChanged();
			StartConnectionStrengthUpdater();
			GetUpdatedActiveConnection();
		}

		private void StartWifiEnabledChange()
		{
			IntentFilter intentFilter = new IntentFilter();
			intentFilter.AddAction("android.net.wifi.WIFI_STATE_CHANGED");
			enabledChangeBR = new RxBroadcastReceiver(intentFilter);
			enabledChangeBR.WhenBroadcastReceived.ObserveOn(NewThreadScheduler.Default).Subscribe(OnEnabledStateUpdate);
			SetEnabledState(WifiEnabledState.Unknown);
			enabledChangeBR.StartListening(context);
		}

		private void OnEnabledStateUpdate(Intent intent)
		{
			if (!"android.net.wifi.WIFI_STATE_CHANGED".Equals(intent.Action))
			{
				iFit.Logger.Log.Trace("Wifi", "Could not update Enabled State");
				return;
			}
			switch ((WifiState)intent.GetIntExtra("wifi_state", 4))
			{
			case WifiState.Enabled:
				SetEnabledState(WifiEnabledState.Enabled);
				break;
			case WifiState.Enabling:
				SetEnabledState(WifiEnabledState.Enabling);
				break;
			case WifiState.Disabled:
				SetEnabledState(WifiEnabledState.Disabled);
				break;
			case WifiState.Disabling:
				SetEnabledState(WifiEnabledState.Disabling);
				break;
			default:
				SetEnabledState(WifiEnabledState.Unknown);
				break;
			}
		}

		private void SetEnabledState(WifiEnabledState state)
		{
			base.EnabledState = state;
			iFit.Logger.Log.Trace("Wifi", $"Enabled State Set to {base.EnabledState}");
			_whenEnabledChanged.OnNext(base.EnabledState);
			enablingTimeoutListener?.Dispose();
			if (state == WifiEnabledState.Enabling)
			{
				enablingStartTime = DateTime.UtcNow;
				enablingTimeoutListener = Observable.Timer(TimeSpan.FromSeconds(3.0)).Subscribe(delegate
				{
					OnEnablingTimedOut();
				});
			}
			else
			{
				DismissEnablingTimeoutDialogIfShowing();
			}
		}

		private void OnEnablingTimedOut()
		{
			showingEnablingTimeout = true;
			ShowRestartDialog();
			if (Mvx.TryResolve<ICoreAnalytics>(out var service))
			{
				service.HandledStuckEnablingWifiError();
			}
		}

		protected abstract void ShowRestartDialog();

		protected abstract void HideRestartDialog();

		private void StartListeningForNetworkStatusChange()
		{
			IntentFilter intentFilter = new IntentFilter();
			intentFilter.AddAction("android.net.wifi.STATE_CHANGE");
			intentFilter.AddAction("android.net.wifi.supplicant.CONNECTION_CHANGE");
			intentFilter.AddAction("android.net.wifi.supplicant.STATE_CHANGE");
			networkStateChangeBR = new RxBroadcastReceiver(intentFilter);
			networkStateChangeBR.WhenBroadcastReceived.ObserveOn(NewThreadScheduler.Default).Subscribe(OnWifiNetworkStatusChanged);
			networkStateChangeBR.StartListening(context);
		}

		private void OnWifiNetworkStatusChanged(Intent intent)
		{
			string action = intent.Action;
			NetworkInfo.DetailedState detailedState = null;
			if ("android.net.wifi.STATE_CHANGE".Equals(action))
			{
				NetworkInfo networkInfo = (NetworkInfo)intent.GetParcelableExtra("networkInfo");
				if (networkInfo != null)
				{
					detailedState = networkInfo.GetDetailedState();
				}
			}
			if ("android.net.wifi.supplicant.CONNECTION_CHANGE".Equals(action) && intent.GetBooleanExtra("connected", defaultValue: false))
			{
				detailedState = NetworkInfo.DetailedState.Connected;
			}
			if ("android.net.wifi.supplicant.STATE_CHANGE".Equals(action))
			{
				detailedState = WifiInfo.GetDetailedStateOf((SupplicantState)intent.GetParcelableExtra("newState"));
			}
			int intExtra = intent.GetIntExtra("supplicantError", -1);
			if (1 == intExtra)
			{
				iFit.Logger.Log.Trace("Wifi", "Attempted to connect but Authentication Failed");
				SetConnectionState(WifiNetworkState.AuthenticationFailed);
				wifiMan.RemoveNetwork(wifiNetworkId);
				wifiMan.SaveConfiguration();
			}
			if (detailedState != null)
			{
				SetConnectionState(ChangeState(detailedState));
			}
			else
			{
				iFit.Logger.Log.Trace("Wifi", "No Update for Wifi State Change");
			}
		}

		private void DismissEnablingTimeoutDialogIfShowing()
		{
			if (showingEnablingTimeout)
			{
				showingEnablingTimeout = false;
				HideRestartDialog();
				DateTime utcNow = DateTime.UtcNow;
				double totalSeconds = (utcNow - enablingStartTime).TotalSeconds;
				if (Mvx.TryResolve<ICoreAnalytics>(out var service))
				{
					service.HandledWifiEnabledSlowlyError(totalSeconds);
				}
			}
		}

		private WifiNetworkState ChangeState(NetworkInfo.DetailedState detailedState)
		{
			if (DetailStateToNetworkStateDic.ContainsKey(detailedState))
			{
				return DetailStateToNetworkStateDic[detailedState];
			}
			return WifiNetworkState.Unknown;
		}

		private void SetConnectionState(WifiNetworkState state)
		{
			if (base.NetworkState != state)
			{
				base.NetworkState = state;
				iFit.Logger.Log.Trace("Wifi", $"Wifi Network State Changed => {base.NetworkState}");
				enablingTimeoutListener?.Dispose();
				DismissEnablingTimeoutDialogIfShowing();
				_whenNetworkStateChanged.OnNext(base.NetworkState);
			}
		}

		private void StartListeningForNetworkChanged()
		{
			IntentFilter intentFilter = new IntentFilter();
			intentFilter.AddAction("android.net.conn.CONNECTIVITY_CHANGE");
			networkChangeBR = new RxBroadcastReceiver(intentFilter);
			networkChangeBR.WhenBroadcastReceived.ObserveOn(NewThreadScheduler.Default).Subscribe(OnNetworkChanged);
			networkChangeBR.StartListening(context);
		}

		private void OnNetworkChanged(Intent intent)
		{
			string action = intent.Action;
			if ("android.net.conn.CONNECTIVITY_CHANGE".Equals(action))
			{
				WifiNetworkInfo activeNetworkInfo = ActiveNetworkInfo;
				iFit.Logger.Log.Trace("Wifi", $"Network Changed To => {activeNetworkInfo} MAC Address={wifiMan.ConnectionInfo?.BSSID}");
				_whenNetworkChanged.OnNext(activeNetworkInfo);
			}
		}

		private void StartConnectionStrengthUpdater()
		{
			signalStrengthTimer = Observable.Timer(TimeSpan.FromSeconds(5.0)).Repeat().Subscribe(OnNetworkStrengthUpdate);
		}

		private void OnNetworkStrengthUpdate(long x)
		{
			if (wifiMan?.ConnectionInfo != null && wifiMan.ConnectionInfo.NetworkId != -1)
			{
				int num = WifiManager.CalculateSignalLevel(wifiMan.ConnectionInfo.Rssi, 6);
				if (base.CurrentSignalStrength != num)
				{
					base.CurrentSignalStrength = num;
					_whenSignalStrengthChanged.OnNext(base.CurrentSignalStrength);
				}
			}
		}

		private WifiNetworkInfo GetUpdatedActiveConnection()
		{
			WifiNetworkInfo network = DefaultWifiNetworkInfo;
			try
			{
				(from x in wifiMan?.ConfiguredNetworks?.ExcludingNulls()
					where x.EqualAndPopulatedSsids(wifiMan.ConnectionInfo?.SSID)
					orderby x.Priority descending
					select x).Take(1).DoForEach(delegate(WifiConfiguration x)
				{
					network = new WifiNetworkInfo(x.HiddenSSID, x.Ssid, GetSecurityType(x), wifiMan.ConnectionInfo.Rssi);
				});
			}
			catch (System.Exception)
			{
			}
			return network;
		}

		public override void DisableConfiguredNetworks()
		{
			try
			{
				wifiMan.Disconnect();
				wifiMan.ConfiguredNetworks.DoForEach(delegate(WifiConfiguration x)
				{
					wifiMan.DisableNetwork(x.NetworkId);
				});
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Trace("Wifi", "DisableConfiguredNetworks Failed", exception);
			}
		}

		public override void RemoveConfiguredNetworks()
		{
			try
			{
				wifiMan.Disconnect();
				wifiMan.ConfiguredNetworks?.DoForEach(delegate(WifiConfiguration x)
				{
					try
					{
						bool flag = wifiMan.RemoveNetwork(x.NetworkId);
						iFit.Logger.Log.Trace("Wifi", string.Format("Network {0} ({1}) was {2}successfully removed.", x.NetworkId, x.Ssid ?? "<null ssid>", flag ? string.Empty : "not "));
					}
					catch (System.Exception exception2)
					{
						iFit.Logger.Log.Error("Wifi", string.Format("{0} had error forgetting network: {1}", "RemoveConfiguredNetworks", x.NetworkId), exception2);
					}
				}, ignoreNulls: true);
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Wifi", "RemoveConfiguredNetworks Failed", exception);
			}
		}

		public override Task<List<WifiNetworkInfo>> GetNetworks()
		{
			return GetNetworkInfoAsync();
		}

		private Task<List<WifiNetworkInfo>> GetNetworkInfoAsync()
		{
			TaskCompletionSource<List<WifiNetworkInfo>> tcs = new TaskCompletionSource<List<WifiNetworkInfo>>();
			IntentFilter intentFilter = new IntentFilter();
			intentFilter.AddAction("android.net.wifi.SCAN_RESULTS");
			RxBroadcastReceiver onScanReady = new RxBroadcastReceiver(intentFilter);
			onScanReady.WhenBroadcastReceived.Timeout(TimeSpan.FromSeconds(35.0)).Take(1).Subscribe(delegate(Intent intent)
			{
				OnListOfNetworksReady(intent, tcs, onScanReady);
			}, delegate(System.Exception ex)
			{
				tcs.TrySetException(ex);
				onScanReady.StopListening(context);
				onScanReady.Dispose();
			});
			onScanReady.StartListening(context);
			wifiMan.StartScan();
			return tcs.Task;
		}

		private void OnListOfNetworksReady(Intent intent, TaskCompletionSource<List<WifiNetworkInfo>> tcs, RxBroadcastReceiver onScanReady)
		{
			string action = intent.Action;
			if (!"android.net.wifi.SCAN_RESULTS".Equals(action))
			{
				tcs.TrySetResult(null);
				return;
			}
			List<WifiNetworkInfo> networks = new List<WifiNetworkInfo>();
			iFit.Logger.Log.Trace("Wifi", "Scanning for networks...");
			(from x in wifiMan.ScanResults
				where !string.IsNullOrWhiteSpace(x.Ssid)
				group x by x.Ssid into x
				select x.OrderByDescending((ScanResult y) => y.Level).FirstOrDefault() into x
				where x != null && x.Level != -1
				select x).DoForEach(delegate(ScanResult x)
			{
				WifiNetworkInfo.SecurityType securityType = GetSecurityType(x.Capabilities);
				bool hidden = string.IsNullOrWhiteSpace(x.Ssid);
				networks.Add(new WifiNetworkInfo(hidden, x.Ssid, securityType, x.Level));
				iFit.Logger.Log.Trace("Wifi", $"Network found: {networks.Last()}");
				if (securityType == WifiNetworkInfo.SecurityType.Unsupported)
				{
					iFit.Logger.Log.Warn("Wifi", "SSID " + x?.Ssid + " has unsupported security capabilities: " + x?.Capabilities);
				}
			});
			tcs.TrySetResult(networks);
			onScanReady?.StopListening(context);
			onScanReady?.Dispose();
		}

		private WifiNetworkInfo.SecurityType GetSecurityType(WifiConfiguration config)
		{
			if (config.AllowedKeyManagement.Get(2) || config.AllowedKeyManagement.Get(3))
			{
				return WifiNetworkInfo.SecurityType.WpaEnt;
			}
			if (config.AllowedKeyManagement.Get(1))
			{
				return WifiNetworkInfo.SecurityType.WpaWpa2;
			}
			if (config.AllowedGroupCiphers.Get(0) || config.AllowedGroupCiphers.Get(1))
			{
				return WifiNetworkInfo.SecurityType.Wep;
			}
			if (config.AllowedKeyManagement.Get(0))
			{
				return WifiNetworkInfo.SecurityType.None;
			}
			return WifiNetworkInfo.SecurityType.Unsupported;
		}

		public override WifiNetworkInfo.SecurityType GetSecurityType(string sr)
		{
			try
			{
				if (sr.Contains("WPA"))
				{
					if (sr.Contains("EAP") || sr.Contains("ENT"))
					{
						return WifiNetworkInfo.SecurityType.WpaEnt;
					}
					return WifiNetworkInfo.SecurityType.WpaWpa2;
				}
				if (sr.Contains("WEP"))
				{
					return WifiNetworkInfo.SecurityType.Wep;
				}
				if (sr.Contains("ESS") || sr.Contains("NONE"))
				{
					return WifiNetworkInfo.SecurityType.None;
				}
			}
			catch (System.Exception ex)
			{
				iFit.Logger.Log.Trace("Wifi", "Exception determining network security type: " + ex.Message);
			}
			return WifiNetworkInfo.SecurityType.Unsupported;
		}

		public override void TurnWifiOn()
		{
			if (wifiMan.WifiState != WifiState.Disabled && wifiMan.WifiState != WifiState.Disabling)
			{
				return;
			}
			iFit.Logger.Log.Trace("Wifi", "Enabling Wifi");
			wifiMan.SetWifiEnabled(enabled: true);
			IDisposable onWifiConnected = null;
			onWifiConnected = base.WhenNetworkStateChanged.Subscribe(delegate
			{
				if (wifiMan.WifiState != WifiState.Disabled && wifiMan.WifiState != WifiState.Disabling)
				{
					wifiMan.StartScan();
					onWifiConnected?.Dispose();
				}
			});
		}

		public override void TurnWifiOff()
		{
			iFit.Logger.Log.Trace("Wifi", "Disabling Wifi");
			wifiMan.SetWifiEnabled(enabled: false);
		}

		public override Task<WifiConnectionResults> ConnectToNetwork(WifiNetworkInfo wifiInfo)
		{
			TaskCompletionSource<WifiConnectionResults> tcs = new TaskCompletionSource<WifiConnectionResults>();
			wifiNetworkId = GetNetworkId(wifiInfo);
			DisableConfiguredNetworks();
			if (ActiveNetworkInfo.Ssid.Replace("\"", "").Equals(wifiInfo.Ssid.Replace("\"", "")))
			{
				tcs.TrySetResult(WifiConnectionResults.Success);
				return tcs.Task;
			}
			if (wifiNetworkId == -1)
			{
				iFit.Logger.Log.Trace("Wifi", $"Network id was -1 failed to find network => {wifiInfo}");
				tcs.TrySetResult(WifiConnectionResults.NetworkNotFoundError);
			}
			else
			{
				IDisposable connectedListener = null;
				IDisposable timeoutListener = null;
				connectedListener = base.WhenNetworkStateChanged.SkipWhile((WifiNetworkState state) => state == WifiNetworkState.Connected).Subscribe(delegate(WifiNetworkState state)
				{
					OnConnectingToNetworkStateChange(state, tcs, connectedListener, timeoutListener, wifiInfo);
				});
				timeoutListener = Observable.Timer((wifiInfo.Security == WifiNetworkInfo.SecurityType.WpaEnt) ? TimeSpan.FromSeconds(45.0) : TimeSpan.FromSeconds(25.0)).Subscribe(delegate
				{
					OnConnectingTimedOut(tcs, connectedListener, timeoutListener, wifiInfo);
				});
				wifiMan.Disconnect();
				wifiMan.EnableNetwork(wifiNetworkId, attemptConnect: true);
				wifiMan.Reconnect();
				wifiMan.SaveConfiguration();
			}
			return tcs.Task;
		}

		private void OnConnectingToNetworkStateChange(WifiNetworkState state, TaskCompletionSource<WifiConnectionResults> tcs, IDisposable connectedListener, IDisposable timeoutListener, WifiNetworkInfo wifiInfo)
		{
			switch (state)
			{
			case WifiNetworkState.AuthenticationFailed:
				tcs.TrySetResult(WifiConnectionResults.AuthenticationError);
				iFit.Logger.Log.Trace("Wifi", $"When Connecting Network Authentication Error => {wifiInfo}");
				DisableConfiguredNetworks();
				connectedListener?.Dispose();
				timeoutListener?.Dispose();
				break;
			case WifiNetworkState.Failed:
				tcs.TrySetResult(WifiConnectionResults.UnknownError);
				iFit.Logger.Log.Trace("Wifi", $"When Connecting Network Connection Unknown Error => {wifiInfo}");
				DisableConfiguredNetworks();
				connectedListener?.Dispose();
				timeoutListener?.Dispose();
				break;
			case WifiNetworkState.Connected:
				tcs.TrySetResult(WifiConnectionResults.Success);
				iFit.Logger.Log.Trace("Wifi", $"Network Successfully Connected To => {wifiInfo}");
				connectedListener?.Dispose();
				timeoutListener?.Dispose();
				break;
			}
		}

		private void OnConnectingTimedOut(TaskCompletionSource<WifiConnectionResults> tcs, IDisposable connectedListener, IDisposable timeoutListener, WifiNetworkInfo wifiInfo)
		{
			tcs.TrySetResult(WifiConnectionResults.TimeoutError);
			iFit.Logger.Log.Trace("Wifi", $"Timeout when connecting to => {wifiInfo}");
			connectedListener?.Dispose();
			timeoutListener?.Dispose();
		}

		private int GetNetworkId(WifiNetworkInfo wifiInfo)
		{
			string text = "\"" + wifiInfo.Ssid + "\"";
			WifiConfiguration config = SetupWifiConfig(wifiInfo);
			int num = wifiMan?.AddNetwork(config) ?? (-1);
			if (num == -1)
			{
				IList<WifiConfiguration> list = wifiMan?.ConfiguredNetworks;
				if (list != null)
				{
					foreach (WifiConfiguration item in list)
					{
						if (item.Ssid == text)
						{
							num = item.NetworkId;
							break;
						}
					}
				}
			}
			return num;
		}

		private WifiConfiguration SetupWifiConfig(WifiNetworkInfo wifiInfo)
		{
			WifiConfiguration wifiConfiguration = new WifiConfiguration
			{
				Ssid = "\"" + wifiInfo.Ssid + "\"",
				HiddenSSID = wifiInfo.IsHidden
			};
			switch (wifiInfo.Security)
			{
			case WifiNetworkInfo.SecurityType.None:
				wifiConfiguration.AllowedKeyManagement.Set(0);
				wifiConfiguration.AllowedProtocols.Set(0);
				wifiConfiguration.AllowedAuthAlgorithms.Clear();
				wifiConfiguration.AllowedPairwiseCiphers.Set(2);
				wifiConfiguration.AllowedPairwiseCiphers.Set(1);
				wifiConfiguration.AllowedGroupCiphers.Set(0);
				wifiConfiguration.AllowedGroupCiphers.Set(1);
				wifiConfiguration.AllowedGroupCiphers.Set(3);
				wifiConfiguration.AllowedGroupCiphers.Set(2);
				break;
			case WifiNetworkInfo.SecurityType.WpaEnt:
			{
				WifiEnterpriseConfig enterpriseConfig = new WifiEnterpriseConfig
				{
					Identity = wifiInfo.EnterpiseIdentity,
					Password = wifiInfo.Password,
					EapMethod = WifiEapMethod.Peap
				};
				wifiConfiguration.EnterpriseConfig = enterpriseConfig;
				wifiConfiguration.AllowedKeyManagement.Set(3);
				wifiConfiguration.AllowedKeyManagement.Set(2);
				wifiConfiguration.AllowedGroupCiphers.Set(3);
				wifiConfiguration.AllowedPairwiseCiphers.Set(2);
				break;
			}
			case WifiNetworkInfo.SecurityType.Wep:
				wifiConfiguration.WepTxKeyIndex = 0;
				wifiConfiguration.AllowedKeyManagement.Set(0);
				wifiConfiguration.AllowedGroupCiphers.Set(0);
				wifiConfiguration.AllowedProtocols.Set(1);
				wifiConfiguration.AllowedAuthAlgorithms.Set(1);
				wifiConfiguration.AllowedAuthAlgorithms.Set(0);
				wifiConfiguration.AllowedPairwiseCiphers.Set(2);
				wifiConfiguration.AllowedProtocols.Set(0);
				wifiConfiguration.AllowedPairwiseCiphers.Set(1);
				wifiConfiguration.AllowedGroupCiphers.Set(1);
				if (GetHexKey(wifiInfo.Password))
				{
					wifiConfiguration.WepKeys[0] = wifiInfo.Password;
				}
				else
				{
					wifiConfiguration.WepKeys[0] = "\"" + wifiInfo.Password + "\"";
				}
				wifiConfiguration.WepTxKeyIndex = 0;
				break;
			case WifiNetworkInfo.SecurityType.WpaWpa2:
				wifiConfiguration.AllowedGroupCiphers.Set(2);
				wifiConfiguration.AllowedGroupCiphers.Set(3);
				wifiConfiguration.AllowedPairwiseCiphers.Set(1);
				wifiConfiguration.AllowedPairwiseCiphers.Set(2);
				wifiConfiguration.AllowedProtocols.Set(1);
				wifiConfiguration.AllowedKeyManagement.Set(1);
				wifiConfiguration.AllowedProtocols.Set(0);
				wifiConfiguration.AllowedGroupCiphers.Set(0);
				wifiConfiguration.AllowedGroupCiphers.Set(1);
				wifiConfiguration.PreSharedKey = "\"" + wifiInfo.Password + "\"";
				break;
			default:
				iFit.Logger.Log.Trace("Wifi", $"Unsupported WiFi Security Type. => {wifiInfo.Security}");
				break;
			}
			return wifiConfiguration;
		}

		private bool GetHexKey(string s)
		{
			if (s == null)
			{
				return false;
			}
			int length = s.Length;
			if (length != 10 && length != 26 && length != 58)
			{
				return false;
			}
			for (int i = 0; i < length; i++)
			{
				char c = s[i];
				if ((c < '0' || c > '9') && (c < 'a' || c > 'f') && (c < 'A' || c > 'F'))
				{
					return false;
				}
			}
			return true;
		}

		public override void RefreshConnectivityState()
		{
			if (context.GetSystemService("connectivity") is ConnectivityManager { ActiveNetworkInfo: { } activeNetworkInfo })
			{
				SetConnectionState(ChangeState(activeNetworkInfo.GetDetailedState()));
			}
		}

		public override void SaveConfiguration()
		{
			wifiMan?.SaveConfiguration();
		}

		public override void Dispose()
		{
			signalStrengthTimer?.Dispose();
			enabledChangeBR?.StopListening(context);
			enabledChangeBR?.Dispose();
			networkStateChangeBR?.StopListening(context);
			networkStateChangeBR?.Dispose();
			networkChangeBR?.StopListening(context);
			networkChangeBR?.Dispose();
			enablingTimeoutListener?.Dispose();
		}
	}
}
namespace Shire.Android.Services.Update
{
	public class AndroidBleFirmwareUpdater : DfuListener, IBleFirmwareUpdater, IDisposable
	{
		private readonly Subject<UpdateState> _updateState = new Subject<UpdateState>();

		private readonly Subject<int> _updateProgress = new Subject<int>();

		private readonly DfuScanner scanner;

		private readonly IFirmware firmware;

		private readonly Context context;

		private DfuServiceController updateController;

		private TaskCompletionSource<bool> tcs;

		private IDisposable progressTimeoutSub;

		private bool uploadStarted;

		private int progress;

		public IObservable<UpdateState> WhenUpdateStateChange => _updateState;

		public IObservable<int> WhenUpdateProgressChange => _updateProgress;

		public AndroidBleFirmwareUpdater(DfuScanner scanner, IFirmware firmware, Context context)
		{
			this.scanner = scanner;
			this.firmware = firmware;
			this.context = context;
		}

		public AndroidBleFirmwareUpdater(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public async Task Update(IBleDevice device)
		{
			if (device == null)
			{
				throw new BleFirmwareException("Device is null");
			}
			await device.Disconnect();
			await Update(device.PlatformDevice.NativeDevice as BluetoothDevice, firmware.HexPath, firmware.DatPath);
		}

		public async Task Update(string desiredPairKey)
		{
			IBleDevice bleDevice = await scanner.ScanForDfuDeviceWithPairKey(desiredPairKey);
			if (bleDevice == null)
			{
				throw new BleFirmwareException("Could not find device");
			}
			await Update(bleDevice.PlatformDevice.NativeDevice as BluetoothDevice, firmware.HexPath, firmware.DatPath);
		}

		public async Task Update(BluetoothDevice device, string hexPath, string datPath)
		{
			progress = 0;
			_updateProgress.OnNext(0);
			_updateState.OnNext(UpdateState.EnablingDfu);
			tcs = new TaskCompletionSource<bool>();
			Java.IO.File file = new Java.IO.File(hexPath);
			Java.IO.File file2 = new Java.IO.File(datPath);
			string text = FileSystem.Current.LocalStorage.Path + "/.wolfUpdating/dfu.zip";
			FileStream fileStream = new FileStream(text, FileMode.Create);
			ZipOutputStream zipOutputStream = new ZipOutputStream(fileStream);
			addToZip(zipOutputStream, file, "application.hex");
			addToZip(zipOutputStream, file2, "application.dat");
			zipOutputStream.Close();
			DfuStarter.SetDfuListener(context, this);
			if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
			{
				DfuServiceInitiator.CreateDfuNotificationChannel(context);
			}
			updateController = DfuStarter.StartDfu(context, device, text);
			if (!(await tcs.Task))
			{
				throw new BleFirmwareException("Failed to update");
			}
		}

		private void addToZip(ZipOutputStream output, Java.IO.File file, string name)
		{
			ZipEntry e = new ZipEntry(name);
			FileInputStream fileInputStream = new FileInputStream(file);
			output.PutNextEntry(e);
			Pipe(fileInputStream, output);
			output.CloseEntry();
			fileInputStream.Close();
		}

		private void Pipe(InputStream input, OutputStream output)
		{
			byte[] b = new byte[512];
			for (int num = input.Read(b); num != -1; num = input.Read(b))
			{
				output.Write(b, 0, num);
			}
			output.Flush();
		}

		public override void OnStateChanged(DfuState state)
		{
			iFit.Logger.Log.Trace("Updating", $"Nordic DFU Service broadcasted new state: {state}");
			if (state == DfuState.DfuCompleted)
			{
				progressTimeoutSub?.Dispose();
				tcs?.TrySetResult(result: true);
			}
			else if (state == DfuState.Error || state == DfuState.DfuAborted)
			{
				progressTimeoutSub?.Dispose();
				tcs?.TrySetResult(result: false);
			}
		}

		public override void OnUploadProgressChanged(int progress)
		{
			if (!uploadStarted && progress > 0)
			{
				uploadStarted = true;
				_updateState.OnNext(UpdateState.Transfering);
			}
			if (progress != this.progress)
			{
				this.progress = progress;
				_updateProgress.OnNext(progress);
			}
			progressTimeoutSub?.Dispose();
			progressTimeoutSub = Observable.Timer(TimeSpan.FromSeconds(30.0)).Take(1).SubscribeWithErrorLogging(delegate
			{
				tcs?.TrySetResult(result: false);
			});
		}
	}
	public class BleFirmwareUpdaterFactory : IBleFirmwareUpdaterFactory
	{
		private readonly Context context;

		public BleFirmwareUpdaterFactory(Context context)
		{
			this.context = context;
		}

		public IBleFirmwareUpdater CreateUpdater(DfuScanner scanner, IFirmware firmware)
		{
			return new AndroidBleFirmwareUpdater(scanner, firmware, context);
		}
	}
}
namespace Shire.Android.Services.Login
{
	public class AndroidThirdPartyLoginService : ThirdPartyLoginService<FacebookLoginUtil, Auth0LoginUtil, AppleLoginUtil>
	{
		public AndroidThirdPartyLoginService(IIfitApiService api, IFacebookLoginUtil facebookUtil, IAuth0LoginUtil auth0Util, IAppleLoginUtil appleUtil)
			: base(api, (FacebookLoginUtil)facebookUtil, (Auth0LoginUtil)auth0Util, (AppleLoginUtil)appleUtil)
		{
		}

		public void Initialize(AndroidX.Fragment.App.Fragment fragment)
		{
			base.FacebookUtil?.Initialize(fragment);
		}

		public void Initialize(Activity activity)
		{
			base.FacebookUtil?.Initialize(activity);
		}

		public void OnResult(int requestCode, int resultCode, Intent data)
		{
			base.FacebookUtil?.CallbackManager.OnActivityResult(requestCode, resultCode, data);
		}
	}
}
namespace Shire.Android.Util
{
	public class AndroidMainThreadSchedulerService : IMainThreadSchedulerService
	{
		public IScheduler Scheduler => new HandlerScheduler(new Handler(Looper.MainLooper), Looper.MainLooper.Thread.Id);
	}
	public class HandlerScheduler : IScheduler, IEnableLogger
	{
		private readonly Handler handler;

		private readonly long looperId;

		public DateTimeOffset Now => DateTimeOffset.Now;

		public HandlerScheduler(Handler handler, long? threadIdAssociatedWithHandler)
		{
			this.handler = handler;
			looperId = threadIdAssociatedWithHandler ?? (-1);
		}

		public IDisposable Schedule<TState>(TState state, Func<IScheduler, TState, IDisposable> action)
		{
			bool isCancelled = false;
			SerialDisposable innerDisp = new SerialDisposable
			{
				Disposable = Disposable.Empty
			};
			if (looperId > 0 && looperId == Java.Lang.Thread.CurrentThread().Id)
			{
				return action(this, state);
			}
			handler.Post(delegate
			{
				if (!isCancelled)
				{
					innerDisp.Disposable = action(this, state);
				}
			});
			return new CompositeDisposable(Disposable.Create(delegate
			{
				isCancelled = true;
			}), innerDisp);
		}

		public IDisposable Schedule<TState>(TState state, TimeSpan dueTime, Func<IScheduler, TState, IDisposable> action)
		{
			bool isCancelled = false;
			SerialDisposable innerDisp = new SerialDisposable
			{
				Disposable = Disposable.Empty
			};
			handler.PostDelayed(delegate
			{
				if (!isCancelled)
				{
					innerDisp.Disposable = action(this, state);
				}
			}, dueTime.Ticks / 10 / 1000);
			return new CompositeDisposable(Disposable.Create(delegate
			{
				isCancelled = true;
			}), innerDisp);
		}

		public IDisposable Schedule<TState>(TState state, DateTimeOffset dueTime, Func<IScheduler, TState, IDisposable> action)
		{
			if (dueTime <= Now)
			{
				return Schedule(state, action);
			}
			return Schedule(state, dueTime - Now, action);
		}
	}
	public class AndroidRunnable : Java.Lang.Object, IRunnable, IJavaObject, IDisposable, IJavaPeerable
	{
		private readonly Action action;

		public AndroidRunnable(Action action)
		{
			this.action = action;
		}

		public void Run()
		{
			action?.Invoke();
		}
	}
	public static class Automation
	{
		private const string Tag = "Automation";

		private const string MobileBucket = "ifit-mobile";

		public static readonly string[] S3KeyObfuscated = new string[4] { "@JH@SH", "PWCHKJ", "SL46PI", "IP" };

		public static readonly string[] S3SecretObfuscated = new string[4] { "JDjW3@rW5EOfe", "Is1-zWEw`Jgta", "ImM,0U4PORtmj", "V" };

		public static string SendAutomationScreenshot(Activity activity, string folder, string fileName)
		{
			if (string.IsNullOrWhiteSpace(folder))
			{
				iFit.Logger.Log.Error("Automation", "ERROR: did not take screenshot, folder not passed in");
				return "ERROR: did not take screenshot, folder not passed in";
			}
			if (string.IsNullOrWhiteSpace(fileName))
			{
				iFit.Logger.Log.Error("Automation", "ERROR: did not take screenshot, fileName not passed in");
				return "ERROR: did not take screenshot, fileName not passed in";
			}
			string text = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/iFit Core/Screenshots/";
			string text2 = System.IO.Path.Combine(text, "temp.png");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			View rootView = activity.Window.DecorView.RootView;
			rootView.DrawingCacheEnabled = true;
			Bitmap bitmap = Bitmap.CreateBitmap(rootView.DrawingCache);
			rootView.DrawingCacheEnabled = false;
			using (FileStream fileStream = new FileStream(text2, FileMode.Create, FileAccess.Write))
			{
				try
				{
					bitmap.Compress(Bitmap.CompressFormat.Png, 100, fileStream);
					fileStream.Flush();
					fileStream.Close();
				}
				catch (System.IO.IOException ex)
				{
					string text3 = "Automation failed to write screenshot to file: " + ex.Message;
					iFit.Logger.Log.Error("Automation", text3);
					return text3;
				}
			}
			DoS3Upload(activity, text2, folder + "/automation/", fileName, "image/png");
			return "https://ifit-mobile.s3.amazonaws.com/" + folder + "/automation/" + fileName;
		}

		private static void DoS3Upload(Context activity, string fileToUploadPath, string basePath, string fileName, string contentType)
		{
			if (!string.IsNullOrEmpty(fileToUploadPath))
			{
				Intent intent = new Intent(activity, typeof(AwsS3IntentService));
				Bundle bundle = new Bundle();
				bundle.PutString("saved_file_path", fileToUploadPath);
				bundle.PutString("bucket_name", "ifit-mobile");
				bundle.PutString("base_path", basePath);
				bundle.PutString("file_name", fileName);
				bundle.PutString("content_type", contentType);
				bundle.PutStringArray("s3key", S3KeyObfuscated);
				bundle.PutStringArray("s3secret", S3SecretObfuscated);
				intent.PutExtra("s3Bundle", bundle);
				activity.StartService(intent);
			}
		}
	}
	public static class DeviceInfo
	{
		public enum DeviceAttrs
		{
			Board,
			BootLoader,
			Brand,
			CpuAbi,
			CpuAbi2,
			Device,
			Display,
			FingerPrint,
			Hardware,
			Host,
			Id,
			Manufacturer,
			Model,
			Product,
			Radio,
			Serial,
			Tags,
			Time,
			User
		}

		private const double SmallSamsungSize = 22.0;

		private const double LargeSamsungSize = 32.0;

		private static readonly List<(string manufacturer, string model)> KnownArgonManufacturerAndProductIds = new List<(string, string)>
		{
			("alps", "J1002"),
			("alps", "k3201"),
			("alps", "k2102"),
			("alps", "k2103"),
			("ICON", "argon"),
			("alps", "argon"),
			("alps", "tb8163p3_64_bsp"),
			("ICON", "argon2"),
			("ICON", "argon3")
		};

		private static readonly List<(string manufacturer, string model)> KnownClassicManufacturerAndProductIds = new List<(string, string)>
		{
			("NEXELL", "AOSP on Drone"),
			("NEXELL", "AOSP on avn_ref")
		};

		private static readonly List<(string manufacturer, string model)> KnownBCMManufacturerAndProductIds = new List<(string, string)> { ("intel", "byt_t_crv2") };

		private static readonly List<string> KnownBrands = new List<string> { "iFit Embedded" };

		private static readonly List<(string manufacturer, string model)> KnownStrengthMirrorManufacturerAndProductIds = new List<(string, string)>
		{
			("ICON", "MP21-Argon2-Mirror"),
			("ICON", "MP32-Argon2-Mirror"),
			("ICON", "MP32-Argon2-Mirror-Headless")
		};

		private static readonly List<(string manufacturer, string model)> KnownBuiltInManufacturerAndProductIds = KnownArgonManufacturerAndProductIds.Concat(KnownClassicManufacturerAndProductIds).Concat(KnownBCMManufacturerAndProductIds).Concat(KnownStrengthMirrorManufacturerAndProductIds)
			.ToList();

		public static bool IsStrengthMirrorUnit => KnownStrengthMirrorManufacturerAndProductIds.Any(((string manufacturer, string model) x) => x.manufacturer.Equals(GetManufacturer(), StringComparison.InvariantCultureIgnoreCase) && x.model.Equals(GetModel(), StringComparison.InvariantCultureIgnoreCase));

		public static BuiltInType BuiltInType
		{
			get
			{
				if (!IsBuiltIn())
				{
					return BuiltInType.NA;
				}
				if (KnownArgonManufacturerAndProductIds.Any(((string manufacturer, string model) x) => x.manufacturer == GetManufacturer() && x.model == GetModel()))
				{
					if (Mvx.TryResolve<IDeviceInformation>(out var service))
					{
						double displaySizeInches = service.DisplaySizeInches;
						if (displaySizeInches.AlmostEqual(22.0) || displaySizeInches.AlmostEqual(32.0))
						{
							return BuiltInType.SamsungArgon;
						}
						return BuiltInType.MTKArgon;
					}
					return BuiltInType.Argon;
				}
				if (KnownBCMManufacturerAndProductIds.Any(((string manufacturer, string model) x) => x.manufacturer == GetManufacturer() && x.model == GetModel()))
				{
					return BuiltInType.BCM;
				}
				return BuiltInType.Classic;
			}
		}

		public static string GetDeviceInfo(DeviceAttrs type)
		{
			return type switch
			{
				DeviceAttrs.Board => Build.Board, 
				DeviceAttrs.BootLoader => Build.Bootloader, 
				DeviceAttrs.Brand => Build.Brand, 
				DeviceAttrs.CpuAbi => Build.CpuAbi, 
				DeviceAttrs.CpuAbi2 => Build.CpuAbi2, 
				DeviceAttrs.Device => Build.Device, 
				DeviceAttrs.Display => Build.Display, 
				DeviceAttrs.FingerPrint => Build.Fingerprint, 
				DeviceAttrs.Hardware => Build.Hardware, 
				DeviceAttrs.Host => Build.Host, 
				DeviceAttrs.Id => Build.Id, 
				DeviceAttrs.Manufacturer => Build.Manufacturer, 
				DeviceAttrs.Model => Build.Model, 
				DeviceAttrs.Product => Build.Product, 
				DeviceAttrs.Radio => Build.Radio, 
				DeviceAttrs.Serial => Build.Serial, 
				DeviceAttrs.Tags => Build.Tags, 
				DeviceAttrs.Time => Build.Time.ToString(), 
				DeviceAttrs.User => Build.User, 
				_ => "Type Not Found", 
			};
		}

		public static string GetManufacturer()
		{
			return GetDeviceInfo(DeviceAttrs.Manufacturer);
		}

		public static string GetDisplay()
		{
			return GetDeviceInfo(DeviceAttrs.Display);
		}

		public static string GetModel()
		{
			return GetDeviceInfo(DeviceAttrs.Model);
		}

		public static string GetProduct()
		{
			return GetDeviceInfo(DeviceAttrs.Product);
		}

		public static string GetBoard()
		{
			return GetDeviceInfo(DeviceAttrs.Board);
		}

		private static string GetBrand()
		{
			return GetDeviceInfo(DeviceAttrs.Brand);
		}

		public static bool IsBuiltIn()
		{
			if (KnownBrands.Any((string x) => x.Equals(GetBrand(), StringComparison.InvariantCultureIgnoreCase)))
			{
				return true;
			}
			return KnownBuiltInManufacturerAndProductIds.Any(((string manufacturer, string model) x) => x.manufacturer.Equals(GetManufacturer(), StringComparison.InvariantCultureIgnoreCase) && x.model.Equals(GetModel(), StringComparison.InvariantCultureIgnoreCase));
		}
	}
	public class DialogFragmentPlacementKeyboardUtil : IDisposable
	{
		private View decorView;

		private View contentView;

		private global::Android.Views.Window window;

		private bool disposed;

		public DialogFragmentPlacementKeyboardUtil(Activity activity, View content, global::Android.Views.Window dialogWindow)
		{
			window = dialogWindow;
			decorView = activity.Window.DecorView;
			contentView = content;
		}

		public void Enable()
		{
			if (decorView != null)
			{
				decorView.ViewTreeObserver.GlobalLayout += OnGlobalLayout;
			}
		}

		public void Disable()
		{
			if (decorView != null)
			{
				decorView.ViewTreeObserver.GlobalLayout -= OnGlobalLayout;
			}
		}

		public void OnGlobalLayout(object sender, EventArgs e)
		{
			if (!disposed && decorView != null && window != null && contentView != null)
			{
				Rect rect = new Rect();
				decorView.GetWindowVisibleDisplayFrame(rect);
				WindowManagerLayoutParams attributes = window.Attributes;
				attributes.SoftInputMode = SoftInput.AdjustResize;
				int bottom = rect.Bottom;
				int height = contentView.Height;
				if (height <= bottom)
				{
					attributes.Y = (int)((float)(bottom - height) / 2f);
				}
				else
				{
					attributes.Y = 0;
				}
				attributes.Gravity = (GravityFlags)49;
				window.Attributes = attributes;
			}
		}

		public void Dispose()
		{
			if (!disposed)
			{
				Disable();
				window = null;
				decorView = null;
				contentView = null;
				disposed = true;
			}
		}
	}
	public interface IActivityResultCallback
	{
		void OnActivityResult(int requestCode, global::Android.App.Result resultCode, Intent data);
	}
	public static class iFitAnrErrorUtil
	{
		public static void AnrErrorGroupingKey(object sender, RaygunCustomGroupingKeyEventArgs e)
		{
			if (e.Exception is iFitAnrError)
			{
				object arg = e.Message.Details.UserCustomData["viewmodel"];
				e.CustomGroupingKey = $"ANR {arg}";
			}
		}
	}
	public static class ImageUtil
	{
		private const string Tag = "Images";

		public static int GetImageResourceFromName(Context context, string imageName)
		{
			if (imageName == null)
			{
				return 0;
			}
			string packageName = context.PackageName;
			return context.Resources.GetIdentifier(imageName.ToLower(), "drawable", packageName);
		}

		public static byte[] BitmapToBytesArr(Bitmap bm)
		{
			using MemoryStream memoryStream = new MemoryStream();
			bm.Compress(Bitmap.CompressFormat.Png, 0, memoryStream);
			return memoryStream.ToArray();
		}

		public static byte[] DrawableToBytesArr(Resources resources, int drawable)
		{
			return BitmapToBytesArr(BitmapFactory.DecodeResource(resources, drawable));
		}

		public static async Task<Bitmap> DownloadImage(string url, int reqWidth, int reqHeight)
		{
			_ = 1;
			try
			{
				byte[] array = await DownloadImageBytes(url, reqWidth, reqHeight);
				if (array == null || array.Length == 0)
				{
					iFit.Logger.Log.Trace("Images", "Null or empty byte array in download image");
					return null;
				}
				return await BitmapFactory.DecodeByteArrayAsync(array, 0, array.Length);
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Images", "Exception downloading or decoding image", exception);
				return null;
			}
		}

		private static async Task<byte[]> DownloadImageBytes(string uri, int reqWidth, int reqHeight)
		{
			if (!System.Uri.TryCreate(uri, UriKind.Absolute, out var imageUri))
			{
				throw new ArgumentException("Invalid Uri.", "uri");
			}
			IBlobCacheService blobCacheService = Mvx.Resolve<IBlobCacheService>();
			IBlobCache cache = blobCacheService.LocalMachine;
			HttpClient client = Mvx.Resolve<IIfitApiService>().Client;
			DateTimeOffset exp = DateTimeOffset.Now.AddDays(90.0);
			string oldKey = imageUri.AbsoluteUri;
			await cache.InvalidateObject<byte[]>(oldKey);
			string key = $"{oldKey}_{reqWidth}x{reqHeight}";
			return await cache.GetOrFetchObject(key, func, exp);
			async Task<byte[]> func()
			{
				return await Fetch(client, imageUri.AbsoluteUri, reqWidth, reqHeight);
			}
		}

		private static async Task<byte[]> Fetch(HttpClient client, string url, int reqWidth, int reqHeight)
		{
			byte[] array = await client.GetByteArrayAsync(url);
			Bitmap bitmap = await ScaleByteArray(array, reqWidth, reqHeight, maintainAspectRatio: true);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Compress(Bitmap.CompressFormat.Png, 0, memoryStream);
				array = memoryStream.ToArray();
			}
			bitmap.Recycle();
			return array;
		}

		public static async Task<Bitmap> ScaleByteArray(byte[] bytes, int reqWidth, int reqHeight, bool maintainAspectRatio = false)
		{
			BitmapFactory.Options options = await GetBitmapOptionsOfByteArray(bytes);
			if (maintainAspectRatio)
			{
				int outWidth = options.OutWidth;
				int outHeight = options.OutHeight;
				double num = ((reqWidth > reqHeight) ? ((double)reqWidth / (double)outWidth) : ((double)reqHeight / (double)outHeight));
				reqWidth = (int)System.Math.Round(num * (double)outWidth);
				reqHeight = (int)System.Math.Round(num * (double)outHeight);
			}
			UpdateBitmapOptions(options, reqWidth, reqHeight);
			if (bytes == null || bytes.Length == 0)
			{
				iFit.Logger.Log.Trace("Images", "Null or empty byte array scaling");
				return null;
			}
			try
			{
				Bitmap bitmap = await BitmapFactory.DecodeByteArrayAsync(bytes, 0, bytes.Length, options);
				if (bitmap == null)
				{
					iFit.Logger.Log.Error("Images", "ScaleByteArray DecodeByteArray failed, 1st 32 bytes='" + new string((from b in bytes.Take(32)
						select (char)b).ToArray()) + "'");
					return null;
				}
				Bitmap bitmap2 = Bitmap.CreateScaledBitmap(bitmap, reqWidth, reqHeight, filter: true);
				if (bitmap != bitmap2)
				{
					bitmap.Recycle();
				}
				return bitmap2;
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Images", "Exception scaling byte array", exception);
				return null;
			}
		}

		public static async Task<Bitmap> ScaleByteArrayWithCrop(byte[] bytes, int reqWidth, int reqHeight)
		{
			BitmapFactory.Options options = await GetBitmapOptionsOfByteArray(bytes);
			int outWidth = options.OutWidth;
			int outHeight = options.OutHeight;
			double num = ((reqWidth > reqHeight) ? ((double)reqWidth / (double)outWidth) : ((double)reqHeight / (double)outHeight));
			int scaledWidth = (int)System.Math.Round(num * (double)outWidth);
			int scaledHeight = (int)System.Math.Round(num * (double)outHeight);
			UpdateBitmapOptions(options, scaledWidth, scaledHeight);
			if (bytes == null || bytes.Length == 0)
			{
				iFit.Logger.Log.Trace("Images", "Null or empty byte array scaling and cropping");
				return null;
			}
			try
			{
				Bitmap bitmap = await BitmapFactory.DecodeByteArrayAsync(bytes, 0, bytes.Length, options);
				Bitmap bitmap2 = Bitmap.CreateScaledBitmap(bitmap, scaledWidth, scaledHeight, filter: true);
				if (bitmap != bitmap2)
				{
					bitmap.Recycle();
				}
				Bitmap bitmap3 = Bitmap.CreateBitmap(bitmap2, 0, 0, reqWidth, reqHeight);
				if (bitmap2 != bitmap3)
				{
					bitmap2.Recycle();
				}
				return bitmap3;
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Images", "Exception decoding downloaded image", exception);
				return null;
			}
		}

		public static async Task<Bitmap> ScaleResource(Resources res, int resourceId, int reqWidth, int reqHeight)
		{
			BitmapFactory.Options options = await GetBitmapOptionsOfResource(res, resourceId);
			UpdateBitmapOptions(options, reqWidth, reqHeight);
			return await BitmapFactory.DecodeResourceAsync(res, resourceId, options);
		}

		private static void UpdateBitmapOptions(BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			options.InSampleSize = CalculateInSampleSize(options.OutWidth, options.OutHeight, reqWidth, reqHeight);
			options.InJustDecodeBounds = false;
			options.InPreferredConfig = Bitmap.Config.Rgb565;
		}

		private static int CalculateInSampleSize(int origWidth, int origHeight, int reqWidth, int reqHeight)
		{
			double num = 1.0;
			if (origHeight > reqHeight || origWidth > reqWidth)
			{
				int num2 = origHeight / 2;
				int num3 = origWidth / 2;
				while ((double)num2 / num > (double)reqHeight && (double)num3 / num > (double)reqWidth)
				{
					num *= 2.0;
				}
			}
			return (int)num;
		}

		private static async Task<BitmapFactory.Options> GetBitmapOptionsOfResource(Resources res, int resourceId)
		{
			BitmapFactory.Options options = new BitmapFactory.Options
			{
				InJustDecodeBounds = true
			};
			await BitmapFactory.DecodeResourceAsync(res, resourceId, options);
			return options;
		}

		private static async Task<BitmapFactory.Options> GetBitmapOptionsOfByteArray(byte[] bytes)
		{
			BitmapFactory.Options options = new BitmapFactory.Options
			{
				InJustDecodeBounds = true
			};
			if (bytes == null || bytes.Length == 0)
			{
				iFit.Logger.Log.Trace("Images", "Null or empty byte array getting bitmap options");
				return options;
			}
			try
			{
				await BitmapFactory.DecodeByteArrayAsync(bytes, 0, bytes.Length, options);
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Images", "Exception getting bitmap options", exception);
			}
			return options;
		}
	}
	public static class IntentConveter
	{
		public static Intent CreateExplicitFromImplicitIntent(Context context, Intent implicitIntent)
		{
			PackageManager packageManager = context.PackageManager;
			IList<ResolveInfo> list = packageManager.QueryIntentServices(implicitIntent, (PackageInfoFlags)0);
			if (list == null || list.Count != 1)
			{
				return null;
			}
			ResolveInfo resolveInfo = list[0];
			string packageName = resolveInfo.ServiceInfo.PackageName;
			string name = resolveInfo.ServiceInfo.Name;
			ComponentName component = new ComponentName(packageName, name);
			Intent intent = new Intent(implicitIntent);
			intent.SetComponent(component);
			return intent;
		}
	}
	public class NativeExceptionUtil : ExceptionExtensions.INativeExceptionUtil
	{
		public bool NativeRelatesTo<TException>(System.Exception ex) where TException : System.Exception
		{
			for (Throwable throwable = (ex as Throwable)?.Cause; throwable != null; throwable = throwable?.Cause)
			{
				if (throwable is TException)
				{
					return true;
				}
			}
			return false;
		}
	}
}
namespace Shire.Android.Util.Twitter
{
	public class TwitterShareProvider : ITwitterShareProvider, IShareProvider, IActivityResultCallback
	{
		private const int TwitterShareRequestCode = 909099;

		private const string TweetUrl = "https://twitter.com/share?via=ifit&text=";

		private TaskCompletionSource<ShareResult> taskCompletionSource;

		public Activity Activity { get; set; }

		public Task<ShareResult> Share(string message, string uri)
		{
			taskCompletionSource?.SetCanceled();
			taskCompletionSource = new TaskCompletionSource<ShareResult>();
			string s = message;
			if (!string.IsNullOrEmpty(uri))
			{
				s = message + " " + uri;
			}
			string text = "https://twitter.com/share?via=ifit&text=" + URLEncoder.Encode(s, "UTF-8");
			Intent intent = new Intent("android.intent.action.VIEW", global::Android.Net.Uri.Parse(text));
			if (Activity.TryResolveActivity(intent, out var resultingPackages))
			{
				ResolveInfo resolveInfo = resultingPackages.FirstOrDefault((ResolveInfo x) => x.ActivityInfo.PackageName.StartsWith("com.twitter", StringComparison.InvariantCultureIgnoreCase));
				if (resolveInfo != null)
				{
					intent.SetPackage(resolveInfo.ActivityInfo.PackageName);
					Activity.StartActivityForResult(intent, 909099);
					return taskCompletionSource.Task;
				}
			}
			TwitterShareDialogFragment twitterShareDialogFragment = TwitterShareDialogFragment.Create(text);
			twitterShareDialogFragment.CancelClick = (EventHandler)Delegate.Combine(twitterShareDialogFragment.CancelClick, (EventHandler)delegate
			{
				OnActivityResult(909099, global::Android.App.Result.Canceled, null);
			});
			((IWebViewClientCallbackListener)twitterShareDialogFragment).RequestCodeForCallback = 909099;
			((IWebViewClientCallbackListener)twitterShareDialogFragment).CallbackListener = this;
			twitterShareDialogFragment.Show(Activity.FragmentManager, "Twitter");
			return taskCompletionSource.Task;
		}

		public void OnActivityResult(int requestCode, global::Android.App.Result resultCode, Intent data)
		{
			if (requestCode == 909099)
			{
				taskCompletionSource?.SetResult((resultCode != global::Android.App.Result.Ok) ? ShareResult.Undefined : ShareResult.Success);
				taskCompletionSource = null;
			}
		}
	}
	public interface IWebViewClientCallbackListener
	{
		IActivityResultCallback CallbackListener { set; }

		int RequestCodeForCallback { set; }
	}
}
namespace Shire.Android.Util.SystemResources
{
	public class SystemResources : Shire.Core.Source.Util.SystemResources.SystemResources
	{
		public override ulong InternalFreeDiskSpace => (ulong)global::Android.OS.Environment.RootDirectory.UsableSpace;

		public override ulong InternalTotalDiskSpace => (ulong)global::Android.OS.Environment.RootDirectory.TotalSpace;

		public override ulong ExternalFreeDiskSpace => (ulong)global::Android.OS.Environment.ExternalStorageDirectory.UsableSpace;

		public override ulong ExternalTotalDiskSpace => (ulong)global::Android.OS.Environment.ExternalStorageDirectory.TotalSpace;
	}
}
namespace Shire.Android.Util.Share
{
	public class AndroidSocialShareUtil : SocialShareUtil
	{
		private Activity _activity;

		public Activity Activity
		{
			get
			{
				return _activity;
			}
			set
			{
				_activity = value;
				((FacebookShareProvider)facebookShare).Activity = value;
				((TwitterShareProvider)twitterShare).Activity = value;
			}
		}

		public AndroidSocialShareUtil(IFacebookShareProvider facebookShare, ITwitterShareProvider twitterShare)
			: base(facebookShare, twitterShare)
		{
		}

		public void OnActivityResult(int requestCode, global::Android.App.Result resultCode, Intent data)
		{
			foreach (IShareProvider value in shareMapping.Values)
			{
				if (value is IActivityResultCallback activityResultCallback)
				{
					activityResultCallback.OnActivityResult(requestCode, resultCode, data);
				}
			}
		}
	}
}
namespace Shire.Android.Util.Hardware
{
	public class HardwareInfo : BaseHardwareInfo, IHardwareInfo, IDevice
	{
		private const string LogTag = "HardwareInfo";

		private const int AdaptiveStreamVideoMinimumHardwareBuildNumber = 20170525;

		private readonly Context applicationContext;

		public override int BuildNumber
		{
			get
			{
				int result = 0;
				Regex regex = new Regex("[0-9]{10}|[0-9]{8}");
				Match match = regex.Match(Build.VERSION.Incremental);
				if (match.Success)
				{
					int.TryParse(match.Value, out result);
				}
				return result;
			}
		}

		public override bool SupportsAdaptiveStreaming
		{
			get
			{
				if ((DeviceInfo.BuiltInType != BuiltInType.BCM && DeviceInfo.BuiltInType != BuiltInType.NA) || Build.VERSION.SdkInt <= BuildVersionCodes.JellyBean)
				{
					if (DeviceInfo.BuiltInType != BuiltInType.BCM && DeviceInfo.BuiltInType != BuiltInType.NA)
					{
						return BuildNumber >= 20170525;
					}
					return false;
				}
				return true;
			}
		}

		public override bool IsAndroid => true;

		public override bool IsIos => false;

		public override string OperatingSystem => "Android";

		public override string OperatingSystemVersion => Build.VERSION.Release;

		public override string AndroidOsIncrementalVersion => Build.VERSION.Incremental;

		public override string AnalyticsDeviceId { get; }

		public HardwareInfo(Context applicationContext)
		{
			this.applicationContext = applicationContext;
			AnalyticsDeviceId = Settings.Secure.GetString(applicationContext.ContentResolver, "android_id");
		}

		public override async Task<string> GetAdvertisingId()
		{
			if (DeviceInfo.IsBuiltIn())
			{
				return null;
			}
			try
			{
				return await Task.Run(() => AdvertisingIdClient.GetAdvertisingIdInfo(applicationContext).Id);
			}
			catch (Java.IO.IOException)
			{
			}
			catch (System.IO.IOException)
			{
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Fatal("HardwareInfo", "Caught an unknown exception while trying to get AdvertisingId", exception);
			}
			return null;
		}
	}
}
namespace Shire.Android.Util.Google
{
	public static class GmsAvailability
	{
		public static bool IsGooglePlayServicesAvailable(Context context)
		{
			GoogleApiAvailability instance = GoogleApiAvailability.Instance;
			int num = instance.IsGooglePlayServicesAvailable(context);
			return num == 0;
		}
	}
}
namespace Shire.Android.Util.Facebook
{
	public class FacebookLoginUtil : Java.Lang.Object, IFacebookLoginUtil
	{
		private class FacebookLoginCallback : Java.Lang.Object, IFacebookCallback, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly TaskCompletionSource<string> completionSource;

			public FacebookLoginCallback(TaskCompletionSource<string> completionSource)
			{
				this.completionSource = completionSource;
			}

			public void OnSuccess(Java.Lang.Object result)
			{
				if (result is Xamarin.Facebook.Login.LoginResult loginResult)
				{
					IEnumerable<string> source = FacebookLoginPermissions.ReadPermissions.Except(loginResult.RecentlyDeniedPermissions);
					if (source.Contains(FacebookLoginPermissions.PublicProfilePermission))
					{
						completionSource.TrySetResult(loginResult.AccessToken.Token);
					}
					else
					{
						completionSource.TrySetResult(null);
					}
				}
			}

			public void OnCancel()
			{
				completionSource.TrySetResult(null);
			}

			public void OnError(FacebookException exception)
			{
				completionSource.TrySetException(exception);
			}
		}

		private Activity activity;

		private AndroidX.Fragment.App.Fragment fragment;

		private readonly IFacebookGraphAPI facebookApi;

		public ICallbackManager CallbackManager { get; private set; }

		public FacebookLoginUtil(IFacebookGraphAPI facebookApi)
		{
			this.facebookApi = facebookApi;
		}

		public void Initialize(AndroidX.Fragment.App.Fragment fragment)
		{
			this.fragment = fragment;
			InitializeCallBackManager();
		}

		public void Initialize(Activity activity)
		{
			this.activity = activity;
			InitializeCallBackManager();
		}

		private void InitializeCallBackManager()
		{
			CallbackManager = CallbackManagerFactory.Create();
		}

		public Task<string> LoginWithReadPermissions()
		{
			LoginManager.Instance.LogOut();
			TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
			LoginManager instance = LoginManager.Instance;
			instance.RegisterCallback(CallbackManager, new FacebookLoginCallback(taskCompletionSource));
			string[] permissions = FacebookLoginPermissions.ReadPermissions.ToArray();
			if (activity != null)
			{
				instance.LogInWithReadPermissions(activity, permissions);
			}
			else
			{
				instance.LogInWithReadPermissions(fragment, permissions);
			}
			return taskCompletionSource.Task;
		}

		public async Task<User> GetUserInfoFromFacebook(User user, string accessToken)
		{
			string text = accessToken;
			string text2 = text;
			if (text2 == null)
			{
				text2 = await LoginWithReadPermissions();
			}
			accessToken = text2;
			user.Facebook = accessToken;
			return await FacebookUserInfoUtil.PopulateInfoFromFacebook(facebookApi, user);
		}

		public void CleanUp()
		{
			Dispose();
			if (CallbackManager != null)
			{
				LoginManager.Instance.RegisterCallback(CallbackManager, null);
				CallbackManager.Dispose();
				CallbackManager = null;
			}
			fragment = null;
			activity = null;
		}
	}
	public class FacebookShareProvider : Java.Lang.Object, IFacebookShareProvider, IShareProvider, IActivityResultCallback, IFacebookCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private const string LogTag = "Sharing";

		private readonly ICallbackManager callbackManager = CallbackManagerFactory.Create();

		private TaskCompletionSource<ShareResult> taskCompletionSource;

		private Activity _activity;

		public Activity Activity
		{
			get
			{
				return _activity;
			}
			set
			{
				_activity = value;
			}
		}

		public Task<ShareResult> Share(string message, string uri)
		{
			taskCompletionSource?.TrySetCanceled();
			taskCompletionSource = new TaskCompletionSource<ShareResult>();
			ShareLinkContent.Builder builder = new ShareLinkContent.Builder();
			builder.SetContentUrl(global::Android.Net.Uri.Parse(uri));
			builder.SetQuote(message);
			ShareLinkContent content = builder.Build();
			ShareDialog shareDialog = new ShareDialog(_activity);
			shareDialog.RegisterCallback(callbackManager, this);
			shareDialog.Show(content);
			return taskCompletionSource.Task;
		}

		public void OnCancel()
		{
			taskCompletionSource?.SetResult(ShareResult.Cancelled);
			taskCompletionSource = null;
		}

		public void OnError(FacebookException error)
		{
			iFit.Logger.Log.Error("Sharing", "Facebook error: " + error);
			taskCompletionSource?.SetResult(ShareResult.Failed);
			taskCompletionSource = null;
		}

		public void OnSuccess(Java.Lang.Object result)
		{
			taskCompletionSource?.SetResult(ShareResult.Success);
			taskCompletionSource = null;
		}

		public void OnActivityResult(int requestCode, global::Android.App.Result resultCode, Intent data)
		{
			if (FacebookSdk.IsFacebookRequestCode(requestCode))
			{
				callbackManager.OnActivityResult(requestCode, (int)resultCode, data);
			}
		}
	}
}
namespace Shire.Android.Util.Extensions
{
	public static class TextViewExtensions
	{
		public static double GetRequiredHeight(this TextView textView, Context context, double widthDp, string text = null)
		{
			if (textView == null)
			{
				throw new ArgumentNullException("textView");
			}
			if (string.IsNullOrEmpty(textView?.Text) && string.IsNullOrEmpty(text))
			{
				throw new ArgumentException("Null/Empty Parameters Not Allowed");
			}
			if (widthDp.AlmostEqual(0.0))
			{
				throw new ArgumentNullException("Width greater than 0 required");
			}
			string text2 = text ?? textView.Text;
			TextView textView2 = new TextView(context);
			textView2.SetTypeface(textView.Typeface, textView.Typeface.Style);
			textView2.SetText(text2, TextView.BufferType.Spannable);
			textView2.SetTextSize(ComplexUnitType.Fraction, textView.TextSize);
			int widthMeasureSpec = View.MeasureSpec.MakeMeasureSpec((int)System.Math.Ceiling(widthDp), MeasureSpecMode.AtMost);
			int heightMeasureSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
			textView2.Measure(widthMeasureSpec, heightMeasureSpec);
			return textView2.MeasuredHeight;
		}
	}
}
namespace Shire.Android.Util.Auth0
{
	public class Auth0LoginUtil : IAuth0LoginUtil
	{
		protected const string Tag = "Auth0LoginUtil";

		private Auth0Client client;

		public async Task<Auth0Response> Login(Auth0InitializationData data)
		{
			Auth0Response response = new Auth0Response();
			Auth0ClientOptions auth0ClientOptions = new Auth0ClientOptions
			{
				Domain = data.Domain,
				ClientId = data.ClientId,
				Scope = (data.Scope ?? "")
			};
			auth0ClientOptions.RedirectUri = data.RedirectUri;
			client = new Auth0Client(auth0ClientOptions);
			IdentityModel.OidcClient.LoginResult loginResult = await client.LoginAsync(data.ExtraParameters);
			if (loginResult.IsError)
			{
				iFit.Logger.Log.Error("Auth0LoginUtil", "An error occurred during login: " + loginResult.Error);
				response.Error = loginResult.Error;
			}
			else
			{
				_ = loginResult.AccessTokenExpiration;
				response.AccessTokenExpiresIn = (loginResult.AccessTokenExpiration - DateTime.Now).TotalSeconds.ToString("F0");
				response.AccessToken = loginResult.AccessToken;
				response.IdentityToken = loginResult.IdentityToken;
				response.RefreshToken = loginResult.RefreshToken;
				if (loginResult.User?.Claims != null)
				{
					response.Nickname = loginResult.User.FindFirst((Claim c) => c.Type == "nickname")?.Value;
					response.Name = loginResult.User.FindFirst((Claim c) => c.Type == "name")?.Value;
					response.Picture = loginResult.User.FindFirst((Claim c) => c.Type == "picture")?.Value;
					response.Email = loginResult.User.FindFirst((Claim c) => c.Type == "email")?.Value;
				}
			}
			return response;
		}
	}
}
namespace Shire.Android.Util.Apple
{
	public class AppleLoginUtil : IAppleLoginUtil
	{
		protected const string Tag = "AppleLoginUtil";

		public bool IsLoginEnabled => false;

		public async Task<AppleResponse> Login()
		{
			return await Task.FromResult<AppleResponse>(null);
		}
	}
}
namespace Shire.Android.Mqtt
{
	public class AndroidMqttPipe : IMqttPipe
	{
		private IManagedMqttClient Client;

		public override bool IsConnected => Client?.IsConnected ?? false;

		public AndroidMqttPipe(IFeatureFlagManager featureFlagManager)
			: base(featureFlagManager)
		{
		}

		public override async Task InitializeClientAndConnect(MqttClientConfigs configs)
		{
			iFit.Logger.Log.Trace("mqtt", $"Android Mqtt Pipe initializing and connecting - Verbose Mode : {base.VerboseOutput}");
			if (Client != null)
			{
				await Close().ConfigureAwait(continueOnCapturedContext: false);
			}
			ManagedMqttClientOptions managedMqttClientOptions = new ManagedMqttClientOptionsBuilder().WithAutoReconnectDelay(TimeSpan.FromSeconds(10.0)).WithClientOptions(new MqttClientOptionsBuilder().WithClientId(configs.ClientId).WithWebSocketServer(configs.WebSocketServer).WithTls()
				.Build()).Build();
			managedMqttClientOptions.ConnectionCheckInterval = TimeSpan.FromSeconds(5.0);
			MqttNetLogger mqttNetLogger = new MqttNetLogger();
			mqttNetLogger.LogMessagePublished -= LogMessagePublished;
			mqttNetLogger.LogMessagePublished += LogMessagePublished;
			Client = new MqttFactory().CreateManagedMqttClient(mqttNetLogger);
			SubscribeToClientEvents();
			MqttClientWebSocketOptions mqttClientWebSocketOptions = managedMqttClientOptions.ClientOptions.ChannelOptions as MqttClientWebSocketOptions;
			mqttClientWebSocketOptions.RequestHeaders = configs.CustomHeaders;
			base.HasEverSuccessfullyConnected = false;
			try
			{
				await Client.StartAsync(managedMqttClientOptions).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Fatal("mqtt", "ERROR connecting Android mqtt Pipe", exception);
			}
		}

		public override async Task PutRecord(string topic, string payload)
		{
			MqttApplicationMessage applicationMessage = new MqttApplicationMessageBuilder().WithPayload(payload).WithTopic(topic).Build();
			try
			{
				if (Client.IsConnected)
				{
					base.RecordCounter++;
					if (base.ShouldLogPayload)
					{
						LogVerboseTrace("Publishing Payload : " + payload);
						base.RecordCounter = 0;
					}
					await Client.PublishAsync(applicationMessage).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					LogVerboseError("ERROR: NOT publishing MQTT payload. Client is NOT connected.");
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("mqtt", "ERROR Publishing MQTT payload", exception);
			}
		}

		public override async Task Close()
		{
			try
			{
				iFit.Logger.Log.Trace("mqtt", "Disconnecting and disposing mqtt client");
				await DisposeClient().ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("mqtt", "ERROR disconnecting mqtt client", exception);
			}
		}

		private async Task DisposeClient()
		{
			if (Client != null)
			{
				await Client.StopAsync().ConfigureAwait(continueOnCapturedContext: false);
				Client.Dispose();
				Client = null;
			}
		}

		private void SubscribeToClientEvents()
		{
			Client.ConnectedHandler = new MqttClientConnectedHandlerDelegate((Func<MqttClientConnectedEventArgs, Task>)HandleConnectedAsync);
			Client.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate((Func<MqttClientDisconnectedEventArgs, Task>)HandleDisconnectedAsync);
			Client.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate((Func<ManagedProcessFailedEventArgs, Task>)HandleConnectingFailedAsync);
			Client.ApplicationMessageProcessedHandler = new ApplicationMessageProcessedHandlerDelegate((Func<ApplicationMessageProcessedEventArgs, Task>)HandleApplicationMessageProcessedAsync);
			Client.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate((Func<MqttApplicationMessageReceivedEventArgs, Task>)HandleApplicationMessageReceivedAsync);
			Client.SynchronizingSubscriptionsFailedHandler = new SynchronizingSubscriptionsFailedHandlerDelegate((Func<ManagedProcessFailedEventArgs, Task>)HandleSynchronizingSubscriptionsFailedAsync);
		}

		private Task HandleConnectedAsync(MqttClientConnectedEventArgs e)
		{
			base.HasEverSuccessfullyConnected = true;
			LogVerboseTrace($"IMqttPipe: connected -- AuthenticateResult : {e?.AuthenticateResult}");
			return Task.CompletedTask;
		}

		private Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs e)
		{
			if (e?.Exception == null)
			{
				LogVerboseTrace($"IMqttPipe: disconnected -- was connected : {e?.ClientWasConnected}");
			}
			else
			{
				iFit.Logger.Log.Error("mqtt", $"IMqttPipe: disconnected with exception -- was connected : {e?.ClientWasConnected} exception : {e?.Exception}");
			}
			return Task.CompletedTask;
		}

		private Task HandleConnectingFailedAsync(ManagedProcessFailedEventArgs eventArgs)
		{
			iFit.Logger.Log.Error("mqtt", "Connecting failed " + eventArgs?.Exception?.Message);
			return Task.CompletedTask;
		}

		private void LogMessagePublished(object sender, MqttNetLogMessagePublishedEventArgs e)
		{
			LogVerboseTrace($"Message published : {e?.LogMessage}");
		}

		private Task HandleSynchronizingSubscriptionsFailedAsync(ManagedProcessFailedEventArgs eventArgs)
		{
			LogVerboseTrace("Synchronizing Subscriptions Failed : " + eventArgs?.Exception?.Message);
			return Task.CompletedTask;
		}

		private Task HandleApplicationMessageProcessedAsync(ApplicationMessageProcessedEventArgs eventArgs)
		{
			LogVerboseTrace($"Application Message Processed : {eventArgs?.ApplicationMessage?.ApplicationMessage?.Topic} - Size: {eventArgs?.ApplicationMessage?.ApplicationMessage?.Payload?.Length} bytes - success : {eventArgs?.HasSucceeded}");
			if (eventArgs != null && eventArgs.HasFailed)
			{
				LogVerboseTrace($"Application Message Processed failed : {eventArgs?.Exception}");
			}
			return Task.CompletedTask;
		}

		private Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
		{
			LogVerboseTrace($"Application Message Received : {eventArgs?.ApplicationMessage}");
			return Task.CompletedTask;
		}
	}
}
namespace Shire.Android.Music
{
	public class LockScreenMediaSettingsAndroid : ILockScreenMediaSettings
	{
		public IObservable<LockScreenMediaType> WhenLockScreenNowPlayingUpdated { get; }

		public IObservable<LockScreenMediaType> WhenLockScreenControlUpdated { get; }

		public void SetNowPlayingInfo(LockScreenMediaInfo lockScreenMediaInfo, LockScreenMediaType lockScreenMediaType, bool updateCurrentControl)
		{
		}

		public void ClearNowPlayingInfo()
		{
		}

		public void UpdateLockScreenSettings(ConsoleState state, IAudioService audioService, bool workoutHasFeedFmMix)
		{
			AudioTrack audioTrack = audioService?.ActiveTrack;
			if (state == ConsoleState.WarmUp || (state == ConsoleState.CoolDown && audioTrack != null && workoutHasFeedFmMix))
			{
				SetNowPlayingInfo(audioTrack?.ToLockScreenMediaInfo(), LockScreenMediaType.Music, updateCurrentControl: true);
			}
			else if (state == ConsoleState.WorkoutResults)
			{
				ClearNowPlayingInfo();
			}
		}
	}
}
namespace Shire.Android.Music.FeedFm
{
	public class FeedFmServiceAndroid : FeedFmService
	{
		private class FeedFmPlayerAvailabilityListener : Java.Lang.Object, IAvailabilityListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly FeedFmServiceAndroid feedFmService;

			public FeedFmPlayerAvailabilityListener(FeedFmServiceAndroid feedFmService)
			{
				this.feedFmService = feedFmService;
			}

			public void OnPlayerAvailable(FeedAudioPlayer p0)
			{
				if (feedFmService == null)
				{
					iFit.Logger.Log.Error("Audio", "Cannot call OnPlayerAvailable with a null feedFmService");
				}
				else
				{
					feedFmService.playerAvailable.OnNext(p0.ClientId);
				}
			}

			public void OnPlayerUnavailable(Java.Lang.Exception p0)
			{
				feedFmService.playerAvailable.OnError(p0);
			}
		}

		private class FeedFmPlayListener : Java.Lang.Object, IPlayListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly FeedFmServiceAndroid feedFmService;

			public FeedFmPlayListener(FeedFmServiceAndroid feedFmService)
			{
				this.feedFmService = feedFmService;
			}

			public void OnPlayStarted(Play p0)
			{
				feedFmService?.HandlePlayStarted(p0);
			}

			public void OnProgressUpdate(Play p0, float p1, float p2)
			{
			}

			public void OnSkipStatusChanged(bool status)
			{
				feedFmService.skipStatusChanged?.OnNext(status);
				iFit.Logger.Log.Debug("Audio", string.Format("{0}: {1}", "OnSkipStatusChanged", status));
			}
		}

		private class FeedFmSkipListener : Java.Lang.Object, ISkipListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly FeedFmServiceAndroid feedFmService;

			public FeedFmSkipListener(FeedFmServiceAndroid feedFmService)
			{
				this.feedFmService = feedFmService;
			}

			public void RequestCompleted(bool p0)
			{
				feedFmService.skipCompleted.OnNext(p0);
				string text = (p0 ? "Song skipped" : "Skip limit reached");
				iFit.Logger.Log.Info("Audio", text ?? "");
			}
		}

		private class FeedFmPlayerStateListener : Java.Lang.Object, IStateListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly FeedFmServiceAndroid feedFmService;

			public FeedFmPlayerStateListener(FeedFmServiceAndroid feedFmService)
			{
				this.feedFmService = feedFmService;
			}

			public void OnStateChanged(FM.Feed.Android.Playersdk.State state)
			{
				if (feedFmService == null)
				{
					iFit.Logger.Log.Error("Audio", "Cannot call HandleStateChanged on a null FeedFmService");
				}
				else
				{
					feedFmService.HandleStateChanged(state);
				}
			}
		}

		private class FeedFmMusicQueuedListener : Java.Lang.Object, IMusicQueuedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly FeedFmServiceAndroid feedFmService;

			public FeedFmMusicQueuedListener(FeedFmServiceAndroid feedFmService)
			{
				this.feedFmService = feedFmService;
			}

			public void OnMusicQueued()
			{
				feedFmService.instantPlaybackReady.OnNext(value: true);
				iFit.Logger.Log.Info("Audio", "Music is queued and ready to play");
			}
		}

		private class FeedFmStationChangedListener : Java.Lang.Object, IStationChangedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly FeedFmServiceAndroid feedFmService;

			public FeedFmStationChangedListener(FeedFmServiceAndroid feedFmService)
			{
				this.feedFmService = feedFmService;
			}

			public void OnStationChanged(Station p0)
			{
				feedFmService?.HandleStationChanged(p0);
			}
		}

		private class FeedFmUnhandledErrorListener : Java.Lang.Object, IUnhandledErrorListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly FeedFmServiceAndroid feedFmService;

			public FeedFmUnhandledErrorListener(FeedFmServiceAndroid feedFmService)
			{
				this.feedFmService = feedFmService;
			}

			public void OnUnhandledError(FeedException p0)
			{
				string text = p0.ToString();
				iFit.Logger.Log.Error("Audio", "FeedException: " + p0.Message + ", " + text, p0);
				AudioServiceUnhandledError audioServiceUnhandledError = AudioServiceUnhandledError.FromAndroidException(p0);
				audioServiceUnhandledError.IsKnownError = IsFeedFmErrorKnownIssue(text);
				feedFmService.unhandledErrorOccurred.OnNext(audioServiceUnhandledError);
				if (!audioServiceUnhandledError.IsKnownError)
				{
					SendRaygunReport(p0);
				}
			}

			private bool IsFeedFmErrorKnownIssue(string exceptionString)
			{
				string[] source = new string[7] { "504 Gateway Time-out", "failed to connect to feed.fm", "No address associated with hostname", "SSL handshake timed out", "timeout", "This song has started playback already or been invalidated", "You have exceeded normal request limits and are being throttled" };
				bool flag = source.Any((string filteredString) => exceptionString.Contains(filteredString));
				bool flag2 = exceptionString.Contains("null Error") && exceptionString.Contains("This song has started playback already or been invalidated") && exceptionString.Contains("403");
				bool flag3 = exceptionString.Contains("null Error") && exceptionString.Contains("Either no songs match requested format/bitrate or this clients play history makes immediate playback of any available song violate DMCA restrictions") && exceptionString.Contains("200");
				return flag2 || flag3 || flag;
			}

			private async Task SendRaygunReport(FeedException exception)
			{
				if (Mvx.TryResolve<ICrashReporter>(out var service))
				{
					service.ReportError(exception.GetType().ToString() + ": " + exception.Message, exception, null);
				}
			}
		}

		private class FeedFmOutOfMusicListener : Java.Lang.Object, IOutOfMusicListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly FeedFmServiceAndroid feedFmService;

			public FeedFmOutOfMusicListener(FeedFmServiceAndroid feedFmService)
			{
				this.feedFmService = feedFmService;
			}

			public void OnOutOfMusic()
			{
				feedFmService.stationOutOfMusic.OnNext(value: true);
				iFit.Logger.Log.Info("Audio", "Current audio station is out of music. Station: " + feedFmService?.ActiveStation?.DisplayName);
			}

			private async Task SendManualRaygunReport(FeedFmOutOfMusicException exception)
			{
				if (Mvx.TryResolve<ICrashReporter>(out var service))
				{
					await service.ReportError(new List<string> { "FeedFmOutOfMusicTag" }, exception.Message, exception, includeLogFiles: true, isManualLog: true);
				}
			}
		}

		private class FeedFmOutOfMusicException : System.Exception
		{
			public override string Message => "FeedFM had an out-of-music event occur";
		}

		private enum RequestedPauseOrPlay
		{
			Pause,
			Play
		}

		private static bool hasInitializedAnyFeedFmServiceAndroid;

		private const float CrossfadePlayerVolumeResetDelayMs = 200f;

		private FeedAudioPlayer player;

		private IConnectivity connectivity;

		private IPlayListener playListener;

		private IAvailabilityListener availabilityListener;

		private ISkipListener skipListener;

		private IStateListener stateListener;

		private IMusicQueuedListener musicQueuedListener;

		private IStationChangedListener stationChangedListener;

		private IUnhandledErrorListener unhandledErrorListener;

		private IOutOfMusicListener outOfMusicListener;

		private RequestedPauseOrPlay? lastRequestedPauseOrPlay;

		private bool inMutedFakePauseState;

		private bool trackChangeOccurredInMutedFakePauseState;

		private ConcurrentDictionary<Station, AudioPlayerStation> metadataCache = new ConcurrentDictionary<Station, AudioPlayerStation>();

		public override string ClientId => player?.ClientId;

		public override bool CanSkip => player.CanSkip();

		public override List<AudioPlayerStation> Stations => player?.StationList.ConvertToList().Select(GetMetadata).ToList();

		public override AudioTrack ActiveTrack => player?.CurrentPlay?.ToAudioTrack();

		public override AudioPlayerStation ActiveStation => GetMetadata(player?.ActiveStation);

		public override List<AudioTrack> PlayHistory
		{
			get
			{
				List<AudioTrack> list = new List<AudioTrack>();
				if (player?.PlayHistory == null)
				{
					return list;
				}
				list.AddRange(from track in player.PlayHistory
					where track != null
					select track.ToAudioTrack());
				return list;
			}
		}

		public string LastRequestedStationId { get; private set; }

		public float? LastSetVolume { get; private set; }

		private bool LastRequestedStationCurrentlySet
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(LastRequestedStationId) && player?.ActiveStation != null)
				{
					AudioPlayerStation metadata = GetMetadata(player.ActiveStation);
					if (metadata == null)
					{
						return false;
					}
					return metadata.Id?.Equals(LastRequestedStationId, StringComparison.OrdinalIgnoreCase) == true;
				}
				return false;
			}
		}

		private static void SetHasInitializedAnyFeedFmServiceAndroid()
		{
			hasInitializedAnyFeedFmServiceAndroid = true;
		}

		public FeedFmServiceAndroid(IIfitApiService ifitApiService, ILockScreenMediaSettings lockScreenMediaSettings, IFeedFmAvailabilityService feedFmAvailabilityService, IConnectivity connectivity, ICurrentConsoleService currentConsoleService, IWifiService wifiService)
			: base(ifitApiService, lockScreenMediaSettings, feedFmAvailabilityService, currentConsoleService, wifiService)
		{
			this.connectivity = connectivity;
		}

		public sealed override void Init(string clientId = null)
		{
			Context applicationContext = Application.Context.ApplicationContext;
			Application application = applicationContext as Application;
			if (application == null)
			{
				return;
			}
			if (!connectivity.IsConnected)
			{
				connectivity.ConnectivityChanged -= ConnectivityChanged;
				connectivity.ConnectivityChanged += ConnectivityChanged;
				return;
			}
			SetHasInitializedAnyFeedFmServiceAndroid();
			base.Init(clientId);
			RunOnMainThread(delegate
			{
				DisposePlayer();
				Tuple<string, string> tuple = ifitApiService.Environment.EnvironmentType.FeedFMMobileCredentials();
				FeedAudioPlayer.Builder builder = new FeedAudioPlayer.Builder(application, tuple.Item1, tuple.Item2);
				if (string.IsNullOrEmpty(clientId))
				{
					builder.SetCreateNewClientId(createNewClientId: true);
				}
				else
				{
					builder.SetCreateNewClientId(createNewClientId: false);
					builder.SetClientId(clientId);
				}
				try
				{
					player = builder.Build();
				}
				catch (System.Exception exception)
				{
					iFit.Logger.Log.Error("Audio", "Error occurred trying to build player.", exception);
					return;
				}
				if (player == null)
				{
					iFit.Logger.Log.Error("Audio", "Could not build FeedAudioPlayer");
				}
				else
				{
					if (player != null)
					{
						AudioPlayerStation metadata = GetMetadata(player.ActiveStation);
						player.SecondsOfCrossfade = new Float(metadata?.CrossfadeSeconds ?? 1f);
					}
					SetVolume(0f);
					AddListeners();
					iFit.Logger.Log.Info("Audio", "Player created with clientId: " + ClientId);
				}
			});
		}

		private void ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
		{
			if (connectivity.IsConnected)
			{
				connectivity.ConnectivityChanged -= ConnectivityChanged;
				Init();
			}
		}

		private void RunOnMainThread(Action action)
		{
			new Handler(Looper.MainLooper).Post(action);
		}

		public override void Play()
		{
			if (player == null)
			{
				iFit.Logger.Log.Info("Audio", "Cannot call Play on a null player");
				return;
			}
			if (inMutedFakePauseState)
			{
				inMutedFakePauseState = false;
				if (player.CurrentPlay != null)
				{
					playStarted?.OnNext(player.CurrentPlay.ToAudioTrack());
				}
				playerStateChanged.OnNext(MusicState.Playing);
			}
			if (!feedFmAvailabilityService.IsFeedFmFeatureEnabledForDevice())
			{
				iFit.Logger.Log.Error("Audio", "Ignoring attempt to play disabled FeedFM music");
				return;
			}
			lastRequestedPauseOrPlay = RequestedPauseOrPlay.Play;
			base.PauseTypeChanged.OnNext(PauseMusicType.None);
			if (!LastRequestedStationCurrentlySet)
			{
				iFit.Logger.Log.Info("Audio", "Could not start FeedFM playback. LastRequestedStationId is " + (LastRequestedStationId ?? "<null>") + ", current active station is " + (player?.ActiveStation?.ToString() ?? "<null>") + ".");
			}
			else
			{
				CallPlayerPlay();
			}
		}

		private void CallPlayerPlay()
		{
			base.PauseTypeChanged.OnNext(PauseMusicType.None);
			RunOnMainThread(delegate
			{
				player?.Play();
			});
		}

		public override bool ChangeToStationWithId(string id, float startAt)
		{
			if (string.IsNullOrEmpty(id))
			{
				iFit.Logger.Log.Info("Audio", "id is required. Station change canceled.");
				return false;
			}
			if (player == null)
			{
				iFit.Logger.Log.Info("Audio", "player is not set up. Station change canceled.");
				return false;
			}
			Station station = null;
			try
			{
				station = player.StationList.GetStationWithOption("id", id) ?? player.StationList.GetStationWithOption("internalName", id);
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Audio", "Could not find available native station with ID or name: " + id + ".", exception);
			}
			if (station != null)
			{
				LastRequestedStationId = id;
				AudioPlayerStation metadata = GetMetadata(player.ActiveStation);
				if (metadata != null && metadata.Id?.Equals(id, StringComparison.OrdinalIgnoreCase) == true)
				{
					iFit.Logger.Log.Info("Audio", string.Format("Player's current {0} already {1}: {2}", "ActiveStation", id, player.ActiveStation));
					return false;
				}
				iFit.Logger.Log.Info("Audio", "Found station with id: " + id + ", calling SetActiveStation...");
				ChangeStation(station, startAt);
				return true;
			}
			iFit.Logger.Log.Info("Audio", "Could not find matching station " + id + ". List:");
			iFit.Logger.Log.Info("Audio", JsonConvert.SerializeObject(Stations));
			return false;
		}

		private void ChangeStation(Station station, float startAt)
		{
			startAt = startAt.Clamp(0f, 3.4028235E+38f);
			iFit.Logger.Log.Info("Audio", string.Format("Changing Feed.fm station to ${0} with {1} value of: {2}", station?.Name, "startAt", startAt));
			AudioPlayerStation metadata = GetMetadata(station);
			if (player != null)
			{
				player.SecondsOfCrossfade = Float.ValueOf(metadata?.CrossfadeSeconds ?? 1f);
				player.SetActiveStation(station, withCrossfade: true, startAt);
			}
		}

		public override Task<bool> QueueStationWithId(string stationId, float startAt, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Task.FromResult(ChangeToStationWithId(stationId, startAt));
		}

		public override void Pause(PauseMusicType pauseMusicType = PauseMusicType.PausedManually)
		{
			if (player == null)
			{
				iFit.Logger.Log.Info("Audio", "Cannot call Pause on a null player");
			}
			else if (base.ShouldMutePlayerRatherThanPause)
			{
				inMutedFakePauseState = true;
				SetVolume(0f);
				base.PauseTypeChanged.OnNext(pauseMusicType);
				playerStateChanged.OnNext(MusicState.PausedManually);
				iFit.Logger.Log.Info("Audio", "Called Pause but ShouldMutePlayerRatherThanPause is true. Muting rather than pausing.");
			}
			else
			{
				lastRequestedPauseOrPlay = RequestedPauseOrPlay.Pause;
				base.PauseTypeChanged.OnNext(pauseMusicType);
				iFit.Logger.Log.Info("Audio", $"Setting PauseType to {pauseMusicType}");
				RunOnMainThread(delegate
				{
					player?.Pause();
				});
			}
		}

		public override void SetVolume(float volume)
		{
			if (player == null)
			{
				iFit.Logger.Log.Info("Audio", "Cannot call SetVolume on a null player");
				return;
			}
			if (inMutedFakePauseState && base.ShouldMutePlayerRatherThanPause)
			{
				volume = 0f;
			}
			SetPlayerVolumeOnMainThread(volume);
		}

		private void SetPlayerVolumeOnMainThread(float volume)
		{
			RunOnMainThread(delegate
			{
				if (player != null)
				{
					LastSetVolume = volume.Clamp(0f, 1f);
					player.SetVolume(LastSetVolume.Value);
				}
			});
		}

		public override void Like()
		{
			iFit.Logger.Log.Info("Audio", "Like () method invoked");
		}

		public override void Dislike()
		{
			iFit.Logger.Log.Info("Audio", "Dislike () method invoked");
		}

		public override void Seek()
		{
			iFit.Logger.Log.Info("Audio", "Seek () method invoked");
		}

		public override void Skip()
		{
			RunOnMainThread(delegate
			{
				if (CanSkip)
				{
					skipRequested.OnNext(value: true);
					player?.Skip();
				}
				else
				{
					iFit.Logger.Log.Error("Audio", "Player is out of skips");
				}
			});
		}

		public override void Unlike()
		{
			iFit.Logger.Log.Info("Audio", "Unlike () method invoked");
		}

		public override void UpdateSession()
		{
			iFit.Logger.Log.Info("Audio", "UpdateSession () method invoked");
		}

		public override void Stop()
		{
			if (player != null)
			{
				player?.Stop();
				lastRequestedPauseOrPlay = null;
			}
		}

		private AudioPlayerStation GetMetadata(Station nativeStation)
		{
			if (nativeStation != null)
			{
				return metadataCache?.GetOrAdd(nativeStation, (Station station) => station.ParseMetadata());
			}
			return null;
		}

		private void AddListeners()
		{
			if (player == null)
			{
				iFit.Logger.Log.Info("Audio", "Not adding listeners because player is null");
				return;
			}
			DisposeListeners();
			playListener = new FeedFmPlayListener(this);
			skipListener = new FeedFmSkipListener(this);
			stateListener = new FeedFmPlayerStateListener(this);
			musicQueuedListener = new FeedFmMusicQueuedListener(this);
			stationChangedListener = new FeedFmStationChangedListener(this);
			unhandledErrorListener = new FeedFmUnhandledErrorListener(this);
			outOfMusicListener = new FeedFmOutOfMusicListener(this);
			availabilityListener = new FeedFmPlayerAvailabilityListener(this);
			player.AddPlayListener(playListener);
			player.AddSkipListener(skipListener);
			player.AddStateListener(stateListener);
			player.AddMusicQueuedListener(musicQueuedListener);
			player.AddStationChangedListener(stationChangedListener);
			player.AddUnhandledErrorListener(unhandledErrorListener);
			player.AddOutOfMusicListener(outOfMusicListener);
			player.AddAvailabilityListener(availabilityListener);
		}

		private void HandleStationChanged(Station station)
		{
			AudioPlayerStation metadata = GetMetadata(station);
			stationChanged?.OnNext(metadata);
			iFit.Logger.Log.Info("Audio", "Station changed to " + (metadata?.ToString() ?? "<null>"));
		}

		private void HandlePlayStarted(Play play)
		{
			AudioTrack audioTrack = play?.ToAudioTrack();
			playStarted.OnNext(audioTrack);
			iFit.Logger.Log.Debug("Audio", audioTrack?.ToString() ?? "null");
			Task.Run((Func<Task>)ForceCrossfadedVolumeResetIfNecessary);
		}

		private void HandleStateChanged(FM.Feed.Android.Playersdk.State state)
		{
			if (base.IsDisposed)
			{
				return;
			}
			if (state == null)
			{
				iFit.Logger.Log.Error("Audio", "Called HandleStateChanged, but state was null.");
				return;
			}
			MusicState musicState = state.ToPlayerState(base.PauseTypeChanged.Value);
			iFit.Logger.Log.Trace("Audio", $"PlayerState: {musicState}");
			base.ActiveState = musicState;
			iFit.Logger.Log.Trace("Audio", string.Format("{0} updated to: {1}", "ActiveState", base.ActiveState));
			if (state == FM.Feed.Android.Playersdk.State.Playing && lastRequestedPauseOrPlay == RequestedPauseOrPlay.Pause)
			{
				iFit.Logger.Log.Trace("Audio", "Called HandleStateChanged, but state was null.");
				player?.Pause();
			}
		}

		private async Task ForceCrossfadedVolumeResetIfNecessary()
		{
			AudioPlayerStation activeStation = ActiveStation;
			if (activeStation == null || !activeStation.FirstPlay)
			{
				return;
			}
			if (trackChangeOccurredInMutedFakePauseState && !inMutedFakePauseState)
			{
				if (LastSetVolume.HasValue && LastSetVolume.Value > 0f)
				{
					iFit.Logger.Log.Trace("Audio", "Track change occurred after having resumed into a different song than the one playing when the service was pause-muted.");
					iFit.Logger.Log.Trace("Audio", $"Forcing a volume reset on the player after {200f} ms.");
					iFit.Logger.Log.Trace("Audio", "See https://ifitdev.atlassian.net/browse/JAM-1134 for more details.");
					float last = LastSetVolume.Value;
					await Task.Delay(TimeSpan.FromMilliseconds(200.0));
					SetVolume(0f);
					await Task.Delay(TimeSpan.FromMilliseconds(200.0));
					SetVolume(last);
				}
				trackChangeOccurredInMutedFakePauseState = false;
			}
			if (inMutedFakePauseState)
			{
				trackChangeOccurredInMutedFakePauseState = true;
				iFit.Logger.Log.Trace("Audio", "Track change occurred while in muted fake pause state.");
			}
		}

		private void DisposeListeners()
		{
			skipListener?.Dispose();
			skipListener = null;
			playListener?.Dispose();
			playListener = null;
			stateListener?.Dispose();
			stateListener = null;
			musicQueuedListener?.Dispose();
			musicQueuedListener = null;
			stationChangedListener?.Dispose();
			stationChangedListener = null;
			unhandledErrorListener?.Dispose();
			unhandledErrorListener = null;
			outOfMusicListener?.Dispose();
			outOfMusicListener = null;
			availabilityListener?.Dispose();
			availabilityListener = null;
		}

		private void DisposePlayer()
		{
			DisposeListeners();
			player?.DestroyInstance();
			player?.Dispose();
			player = null;
			lastRequestedPauseOrPlay = null;
			inMutedFakePauseState = false;
			trackChangeOccurredInMutedFakePauseState = false;
			iFit.Logger.Log.Info("Audio", "Player destroyed and disposed");
		}

		public override void Dispose()
		{
			metadataCache?.Clear();
			metadataCache = null;
			if (connectivity != null)
			{
				connectivity.ConnectivityChanged -= ConnectivityChanged;
				connectivity = null;
			}
			RunOnMainThread(DisposePlayer);
			base.Dispose();
		}
	}
	public static class FeedFmExtensions
	{
		public static AudioTrack ToAudioTrack(this Play play)
		{
			return new AudioTrack
			{
				Album = play.AudioFile.Release.Title,
				Artist = play.AudioFile.Artist.Name,
				Title = play.AudioFile.Track.Title,
				TrackDuration = TimeSpan.FromSeconds(play.AudioFile.DurationInSeconds)
			};
		}

		public static AudioPlayerStation ParseMetadata(this Station feedFmStation)
		{
			try
			{
				return new AudioPlayerStation
				{
					Id = GetIdFromMetadata(feedFmStation),
					DisplayName = TryParseMetadataString(feedFmStation.Options, "displayName"),
					SortOrder = TryParseMetadataString(feedFmStation.Options, "sortOrder"),
					IsDomestic = TryParseMetadataBool(feedFmStation.Options, "isDomestic"),
					IsProduction = TryParseMetadataBool(feedFmStation.Options, "isProduction"),
					IsSelectableStation = TryParseMetadataBool(feedFmStation.Options, "isSelectableStation"),
					Genres = TryParseMetadataStringList(feedFmStation.Options, "genres"),
					TranslatedNames = TryParseMetadataStringDict(feedFmStation.Options, "translatedNames"),
					OverridesUserPreference = TryParseMetadataBool(feedFmStation.Options, "overridesUserPreference"),
					CrossfadeSeconds = TryParseMetadataFloat(feedFmStation.Options, "crossfade_seconds", 1f),
					FirstPlay = (feedFmStation.IsSinglePlay() == Java.Lang.Boolean.True),
					HasListened = (feedFmStation.LastPlayStart != null),
					TFSTrainerId = TryParseMetadataString(feedFmStation.Options, "tfsTrainerId")
				};
			}
			catch (System.Exception ex)
			{
				iFit.Logger.Log.Error("Audio", ex.GetType().Name + " occurred in FeedFmExtensions.ParseMetadata", ex);
			}
			return null;
		}

		private static string GetIdFromMetadata(Station feedFmStation)
		{
			return TryParseMetadataString(feedFmStation.Options, "internalName") ?? TryParseMetadataStringFromArray(feedFmStation.Options, "id") ?? TryParseMetadataString(feedFmStation.Options, "id");
		}

		private static string TryParseMetadataString(IDictionary<string, Java.Lang.Object> nativeOptions, string key)
		{
			try
			{
				if (key != null && nativeOptions != null && nativeOptions.ContainsKey(key))
				{
					return nativeOptions[key].ToString();
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Audio", "Error in TryParseMetadataString for key " + (key ?? "<null>"), exception);
			}
			return null;
		}

		private static string TryParseMetadataStringFromArray(IDictionary<string, Java.Lang.Object> nativeOptions, string key)
		{
			try
			{
				if (key != null && nativeOptions != null && nativeOptions.ContainsKey(key) && nativeOptions[key] is JavaList javaList && javaList.Size() > 0)
				{
					return javaList[0].ToString();
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Audio", "Error in TryParseMetadataString for key " + (key ?? "<null>"), exception);
			}
			return null;
		}

		private static float TryParseMetadataFloat(IDictionary<string, Java.Lang.Object> nativeOptions, string key, float defaultValue = 0f)
		{
			try
			{
				if (key != null && nativeOptions != null && nativeOptions.ContainsKey(key))
				{
					string s = nativeOptions[key].ToString();
					if (float.TryParse(s, out var result))
					{
						return result;
					}
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Audio", "Error in TryParseMetadataFloat for key " + (key ?? "<null>"), exception);
			}
			return defaultValue;
		}

		private static bool TryParseMetadataBool(IDictionary<string, Java.Lang.Object> nativeOptions, string key)
		{
			try
			{
				if (key != null && nativeOptions != null && nativeOptions.ContainsKey(key) && bool.TryParse(nativeOptions[key].ToString(), out var result))
				{
					return result;
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Audio", "Error in TryParseMetadataBool for key " + (key ?? "<null>"), exception);
			}
			return false;
		}

		private static List<string> TryParseMetadataStringList(IDictionary<string, Java.Lang.Object> nativeOptions, string key)
		{
			try
			{
				if (key != null && nativeOptions != null && nativeOptions.ContainsKey(key) && nativeOptions[key] is JavaList javaList)
				{
					int num = javaList.Size();
					List<string> list = new List<string>(num);
					for (int i = 0; i < num; i++)
					{
						list.Add(javaList[i].ToString());
					}
					return list;
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Audio", "Error in TryParseMetadataStringList for key " + (key ?? "<null>"), exception);
			}
			return null;
		}

		private static Dictionary<string, string> TryParseMetadataStringDict(IDictionary<string, Java.Lang.Object> nativeOptions, string key)
		{
			try
			{
				if (key != null && nativeOptions != null && nativeOptions.ContainsKey(key) && nativeOptions[key] is AbstractMap abstractMap)
				{
					int num = abstractMap.Size();
					Dictionary<string, string> dictionary = new Dictionary<string, string>(num);
					for (int i = 0; i < num; i++)
					{
						string text = abstractMap.KeySet()?.ElementAt(i)?.ToString();
						string value = abstractMap.Values()?.ElementAt(i)?.ToString();
						if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(value))
						{
							dictionary[text] = value;
						}
					}
					return dictionary;
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Audio", "Error in TryParseMetadataStringDict for key " + (key ?? "<null>"), exception);
			}
			return null;
		}

		public static List<Station> ConvertToList(this StationList stationList)
		{
			List<Station> list = new List<Station>(stationList.Size());
			for (int i = 0; i < stationList.Size(); i++)
			{
				list.Add((Station)stationList.Get(i));
			}
			return list;
		}

		public static MusicState ToPlayerState(this FM.Feed.Android.Playersdk.State feedFmState, PauseMusicType pauseType)
		{
			if (feedFmState == FM.Feed.Android.Playersdk.State.AvailableOfflineOnly)
			{
				return MusicState.AvailableOfflineOnly;
			}
			if (feedFmState == FM.Feed.Android.Playersdk.State.Paused)
			{
				switch (pauseType)
				{
				case PauseMusicType.None:
				case PauseMusicType.PausedManually:
					return MusicState.PausedManually;
				case PauseMusicType.PausedForMusicRegion:
					return MusicState.PausedForMusicRegion;
				case PauseMusicType.PausedDisabled:
					return MusicState.PausedDisabled;
				}
			}
			if (feedFmState == FM.Feed.Android.Playersdk.State.Playing)
			{
				return MusicState.Playing;
			}
			if (feedFmState == FM.Feed.Android.Playersdk.State.ReadyToPlay)
			{
				return MusicState.Ready;
			}
			if (feedFmState == FM.Feed.Android.Playersdk.State.Stalled)
			{
				return MusicState.Stalled;
			}
			if (feedFmState == FM.Feed.Android.Playersdk.State.Unavailable)
			{
				return MusicState.Unavailable;
			}
			if (feedFmState == FM.Feed.Android.Playersdk.State.Uninitialized)
			{
				return MusicState.Uninitialized;
			}
			if (feedFmState == FM.Feed.Android.Playersdk.State.WaitingForItem)
			{
				return MusicState.Waiting;
			}
			throw new ArgumentOutOfRangeException("feedFmState", feedFmState, "Unknown PlayerState");
		}
	}
}
namespace Shire.Android.LaunchDarkly
{
	public sealed class LaunchDarklyClientAndroid : BaseLaunchDarklyClient
	{
		private class WolfLDStatusListener : Java.Lang.Object, ILDStatusListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly LaunchDarklyClientAndroid client;

			public WolfLDStatusListener(LaunchDarklyClientAndroid client)
			{
				this.client = client;
			}

			public void OnConnectionModeChanged(IConnectionInformation p0)
			{
				client.launchDarklyConnectionModeChanged.OnNext(p0.ConnectionMode.ToLaunchDarklyConnectionMode());
				client.LaunchDarklyConnectionChanged.OnNext(client.IsOnline());
				client.userSynced.OnNext(new LaunchDarklySyncState(client.IsUserUpdated ? LaunchDarklySyncStatus.Synced : LaunchDarklySyncStatus.InProgress));
				iFit.Logger.Log.Trace("FeatureFlags", $"LaunchDarkly connection mode changed to {p0.ConnectionMode}");
			}

			public void OnInternalFailure(LDFailure p0)
			{
				iFit.Logger.Log.Error("FeatureFlags", "LaunchDarkly failure: " + p0.Message, p0);
				System.Exception error = new System.Exception(p0.Message, p0);
				client.userSynced.OnNext(new LaunchDarklySyncState(LaunchDarklySyncStatus.Broken, error));
			}
		}

		private LDClient client;

		private WolfLDStatusListener wolfLdStatusListener;

		private readonly Subject<LaunchDarklyConnectionMode> launchDarklyConnectionModeChanged = new Subject<LaunchDarklyConnectionMode>();

		private bool IsUserUpdated => ldCurrentUserId == ifitApiService.CurrentlyAuthenticatedUserId;

		public LaunchDarklyClientAndroid(IIfitApiService ifitApiService, Application application, IAppVersionService appVersionService, IDeviceInformation deviceInformation, IHardwareInfo hardwareInfo, ICurrentConsoleService currentConsoleService, ICoreAnalytics analytics, string anonymousUserId)
			: base(analytics, ifitApiService, appVersionService, deviceInformation, hardwareInfo, currentConsoleService, anonymousUserId)
		{
			InitializeUser(application);
		}

		private async Task InitializeUser(Application application)
		{
			userSynced.OnNext(new LaunchDarklySyncState(LaunchDarklySyncStatus.InProgress));
			LDConfig config = new LDConfig.Builder().MobileKey(ldPrimaryEnvironment.LaunchDarklyMobileKey()).SecondaryMobileKeys(secondaryMobileKeys).Build();
			client = LDClient.Init(application, config, await GetCurrentLaunchDarklyUser(), 0);
			RegisterListeners();
			try
			{
				await WaitForRequiredFlags();
			}
			catch (System.Exception ex)
			{
				iFit.Logger.Log.Trace("FeatureFlags", "LaunchDarkly Initialization caught an exception", ex);
				userSynced.OnNext(new LaunchDarklySyncState(LaunchDarklySyncStatus.Broken, ex));
			}
		}

		private void RegisterListeners()
		{
			iFit.Logger.Log.Trace("FeatureFlags", "Registering LaunchDarkly Status listener");
			wolfLdStatusListener = new WolfLDStatusListener(this);
			client.RegisterStatusListener(wolfLdStatusListener);
		}

		private void UnRegisterListeners()
		{
			iFit.Logger.Log.Trace("FeatureFlags", "Unregistering LaunchDarkly Status listener");
			if (wolfLdStatusListener != null)
			{
				client.UnregisterStatusListener(wolfLdStatusListener);
				wolfLdStatusListener.Dispose();
				wolfLdStatusListener = null;
			}
		}

		protected override void UpdateClientForMobileKey(string keyName)
		{
			UnRegisterListeners();
			client = LDClient.GetForMobileKey(keyName);
			RegisterListeners();
		}

		public override bool IsOnline()
		{
			return !client.IsOffline;
		}

		public override void SetOnline()
		{
			client.SetOnline();
		}

		public override void SetOffline()
		{
			client.SetOffline();
		}

		public override void Flush()
		{
			client.Flush();
		}

		public override bool GetBool(string key, bool defaultValue)
		{
			try
			{
				return client.BoolVariation(key, defaultValue);
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("FeatureFlags", "Caught exception while attempting to get flag " + key + " from LD", exception);
				analytics.HandledFeatureFlagError(key, exception);
				return defaultValue;
			}
		}

		public override double GetDouble(string key, double defaultValue)
		{
			try
			{
				return client.DoubleVariation(key, defaultValue);
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("FeatureFlags", "Caught exception while attempting to get flag " + key + " from LD", exception);
				analytics.HandledFeatureFlagError(key, exception);
				return defaultValue;
			}
		}

		public override int GetInt(string key, int defaultValue)
		{
			try
			{
				return client.IntVariation(key, defaultValue);
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("FeatureFlags", "Caught exception while attempting to get flag " + key + " from LD", exception);
				analytics.HandledFeatureFlagError(key, exception);
				return defaultValue;
			}
		}

		public override string GetString(string key, string defaultValue)
		{
			try
			{
				EvaluationDetail evaluationDetail = client.StringVariationDetail(key, defaultValue);
				return (string)evaluationDetail.Value;
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("FeatureFlags", "Caught exception while attempting to get flag " + key + " from LD", exception);
				analytics.HandledFeatureFlagError(key, exception);
				return defaultValue;
			}
		}

		public override async Task UpdateUser()
		{
			userSynced.OnNext(new LaunchDarklySyncState(LaunchDarklySyncStatus.InProgress));
			LDUser user = await GetCurrentLaunchDarklyUser();
			IFuture future = client.Identify(user);
			await QueueGetThenNotifyUserSynced(future);
		}

		private async Task<LDUser> GetCurrentLaunchDarklyUser()
		{
			User user = ifitApiService?.CurrentlyAuthenticatedUser;
			LDUser.Builder ldBuilder = ((user != null) ? new LDUser.Builder(user.Id).Name(user.Username).Anonymous(anonymous: false).Email(user.Email)
				.Country(user.Country)
				.Avatar(user.ImageUrl)
				.FirstName(user.Firstname)
				.LastName(user.Lastname) : new LDUser.Builder(anonymousUserId ?? string.Empty).Anonymous(anonymous: true));
			ConsoleType value = currentConsoleService.CurrentConsoleType ?? currentConsoleService.LastKnownConsoleType;
			ldBuilder.Custom("equipmentType", value.ToLegalString());
			ldBuilder.Custom("IsTablet", deviceInfo.IsTablet.ToString());
			ldBuilder.Custom("IsClub", currentConsoleService.Console?.ConsoleInfo?.IsClub.ToString() ?? "");
			ldBuilder.Custom("IsEmbedded", deviceInfo.IsBuiltIn.ToString());
			iFit.Logger.Log.Trace("FeatureFlags", $"Passing {deviceInfo.SoftwareNumber} to LaunchDarkly as softwareNumber");
			ldBuilder.Custom("softwareNumber", deviceInfo.SoftwareNumber.ToString());
			ldBuilder.Custom("appVersion", appVersionService.MainAppVersionInfo.AppVersion);
			ldBuilder.Custom("deviceName", deviceInfo.DeviceName);
			ldBuilder.Custom("operatingSystem", hardwareInfo.OperatingSystem);
			ldBuilder.Custom("osIncrementalVersion", hardwareInfo.AndroidOsIncrementalVersion);
			iFit.Logger.Log.Trace("FeatureFlags", "Android OS incremental version is " + hardwareInfo.AndroidOsIncrementalVersion);
			if (Mvx.TryResolve<IConsoleUpdateInfo>(out var service))
			{
				Guid guid = (await service.GetInfo()).Guid;
				if (guid != Guid.Empty)
				{
					ldBuilder.Custom("uuid", guid.ToString());
					iFit.Logger.Log.Info("FeatureFlags", "Console UUID is " + guid.ToString());
				}
				else
				{
					iFit.Logger.Log.Error("FeatureFlags", "Unable to find console UUID to send to LaunchDarkly.");
				}
			}
			return ldBuilder.Build();
		}

		private async Task QueueGetThenNotifyUserSynced(IFuture future)
		{
			try
			{
				future.Get();
				ldCurrentUserId = ifitApiService.CurrentlyAuthenticatedUserId;
				await WaitForRequiredFlags();
			}
			catch (System.Exception ex)
			{
				iFit.Logger.Log.Trace("FeatureFlags", "LaunchDarkly user sync caught an exception", ex);
				userSynced.OnNext(new LaunchDarklySyncState(LaunchDarklySyncStatus.Broken, ex));
			}
		}

		public override bool AreFlagsAvailable()
		{
			return client.IsInitialized;
		}

		protected override void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				if (disposing)
				{
					client?.Close();
					client?.Dispose();
					client = null;
				}
				base.Dispose(disposing);
			}
		}
	}
	public enum LaunchDarklyConnectionMode
	{
		Offline,
		Polling,
		Shutdown,
		Streaming,
		BackgroundDisabled,
		BackgroundPolling,
		SetOffline
	}
	public static class LaunchDarklyExtensions
	{
		public static LaunchDarklyConnectionMode ToLaunchDarklyConnectionMode(this ConnectionInformationConnectionMode connectionInformation)
		{
			if (connectionInformation == ConnectionInformationConnectionMode.BackgroundDisabled)
			{
				return LaunchDarklyConnectionMode.BackgroundDisabled;
			}
			if (connectionInformation == ConnectionInformationConnectionMode.BackgroundPolling)
			{
				return LaunchDarklyConnectionMode.BackgroundPolling;
			}
			if (connectionInformation == ConnectionInformationConnectionMode.Offline)
			{
				return LaunchDarklyConnectionMode.Offline;
			}
			if (connectionInformation == ConnectionInformationConnectionMode.Polling)
			{
				return LaunchDarklyConnectionMode.Polling;
			}
			if (connectionInformation == ConnectionInformationConnectionMode.Shutdown)
			{
				return LaunchDarklyConnectionMode.Shutdown;
			}
			if (connectionInformation == ConnectionInformationConnectionMode.Streaming)
			{
				return LaunchDarklyConnectionMode.Streaming;
			}
			if (connectionInformation == ConnectionInformationConnectionMode.SetOffline)
			{
				return LaunchDarklyConnectionMode.SetOffline;
			}
			throw new ArgumentOutOfRangeException("connectionInformation", connectionInformation, "Unknown LaunchDarklyConnectionMode");
		}
	}
}
namespace Shire.Android.Ipc
{
	public abstract class BaseIpcMethod
	{
		private readonly IpcObject ipcObj;

		public abstract bool ShouldKillProcessWhenDone { get; }

		protected BaseIpcMethod(IpcObject ipcObject)
		{
			ipcObj = ipcObject;
		}

		public async Task<IpcObject> Execute()
		{
			if (!DeserializeDataJson(ipcObj.Data))
			{
				ipcObj.Data = "";
				ipcObj.Error = "Failed to deserialize";
				return ipcObj;
			}
			return await Execute(ipcObj);
		}

		protected abstract bool DeserializeDataJson(string json);

		protected abstract Task<IpcObject> Execute(IpcObject ipcObject);
	}
	public class IpcException : System.Exception
	{
		public IpcException(string msg)
			: base(msg)
		{
		}
	}
	public class IpcClient : Java.Lang.Object, IServiceConnection, IJavaObject, IDisposable, IJavaPeerable
	{
		protected const int IpcTimeoutTimeMs = 5000;

		protected readonly Context context;

		protected Intent intent;

		private Messenger messenger;

		private TaskCompletionSource<bool> connectTcs;

		public bool IsConnected { get; private set; }

		public IpcClient(Context context, Intent intent)
		{
			this.context = context;
			this.intent = intent;
		}

		public virtual void RefreshIntent()
		{
		}

		public Task<bool> Connect()
		{
			iFit.Logger.Log.Trace("Ipc", GetType().Name + " - IpcClient.Connect() was called");
			connectTcs = new TaskCompletionSource<bool>();
			if (intent == null)
			{
				iFit.Logger.Log.Trace("Ipc", "IpcClient intent is NULL. Refreshing the intent to remote IpcService");
				RefreshIntent();
			}
			if (intent == null)
			{
				iFit.Logger.Log.Trace("Ipc", "Eru/Admin app does not exist. Should allow User to login.");
				connectTcs.TrySetResult(result: true);
				return connectTcs.Task;
			}
			try
			{
				if (IsConnected)
				{
					iFit.Logger.Log.Trace("Ipc", GetType().Name + " - Already connected to eru");
					connectTcs.TrySetResult(result: true);
				}
				else if (context == null || !context.ApplicationContext.BindService(intent, this, Bind.AutoCreate))
				{
					connectTcs.TrySetResult(result: false);
				}
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Trace("Ipc", "{GetType ().Name} - Error binding to Eru service", exception);
				connectTcs.TrySetResult(result: false);
			}
			return connectTcs.Task;
		}

		public void Disconnect()
		{
			IsConnected = false;
			context?.UnbindService(this);
		}

		protected async Task<T> ExecuteRemoteMethod<T>(string methodName, object data = null)
		{
			bool flag = !IsConnected;
			bool flag2 = flag;
			if (flag2)
			{
				flag2 = !(await Connect().ConfigureAwait(continueOnCapturedContext: false));
			}
			if (flag2)
			{
				throw new IpcException("Could not connect to service");
			}
			try
			{
				IpcObject ipcObject = new IpcObject(methodName, data ?? "");
				Task<IpcObject> ipcTask = ExecuteRemoteMethodInternal(ipcObject);
				Task task = Task.Delay(5000);
				await Task.WhenAny(ipcTask, task).ConfigureAwait(continueOnCapturedContext: false);
				if (ipcTask.IsCompleted)
				{
					return JsonConvert.DeserializeObject<T>(ipcTask.Result.Data);
				}
			}
			catch (System.Exception arg)
			{
				throw new IpcException($"Caught exception while running remote procedure call {methodName}: {arg}");
			}
			throw new IpcException("Timed out waiting for remote procedure call " + methodName);
		}

		protected Task<IpcObject> ExecuteRemoteMethodInternal(IpcObject ipcObject)
		{
			IpcClientHandler ipcClientHandler = new IpcClientHandler();
			if (ipcObject == null)
			{
				iFit.Logger.Log.Trace("Ipc", GetType().Name + " - ipcObject is null, returning");
				ipcClientHandler.Tcs.TrySetResult(null);
			}
			else if (!IsConnected || messenger == null)
			{
				iFit.Logger.Log.Trace("Ipc", GetType().Name + " - Not connected to Eru, exiting");
				ipcObject.Data = "";
				ipcObject.Error = "Not connected to service";
				ipcClientHandler.Tcs.TrySetResult(ipcObject);
			}
			else
			{
				try
				{
					Message message = IpcMessageHelper.CreateMessage(ipcObject, new Messenger(ipcClientHandler));
					messenger.Send(message);
				}
				catch (System.Exception exception)
				{
					iFit.Logger.Log.Trace("Ipc", "{GetType ().Name} - Error sending message to Eru", exception);
					ipcObject.Data = "";
					ipcObject.Error = "Exception while sending message";
					ipcClientHandler.Tcs.TrySetResult(ipcObject);
				}
			}
			return ipcClientHandler.Tcs.Task;
		}

		public void OnServiceConnected(ComponentName name, IBinder service)
		{
			iFit.Logger.Log.Trace("Ipc", GetType().Name + " - Connected to Eru");
			IsConnected = true;
			messenger = new Messenger(service);
			connectTcs?.TrySetResult(result: true);
		}

		public void OnServiceDisconnected(ComponentName name)
		{
			iFit.Logger.Log.Trace("Ipc", GetType().Name + " - Disconnected from Eru");
			IsConnected = false;
			messenger = null;
		}
	}
	public class IpcClientHandler : Handler
	{
		public TaskCompletionSource<IpcObject> Tcs { get; private set; }

		public IpcClientHandler()
			: base(Looper.MainLooper)
		{
			Tcs = new TaskCompletionSource<IpcObject>();
		}

		public override void HandleMessage(Message msg)
		{
			string text = msg.Data.GetString("IpcDataKey");
			IpcObject result = null;
			if (text != null)
			{
				try
				{
					result = IpcObject.Deserialize(text);
				}
				catch (System.Exception)
				{
				}
			}
			Tcs.TrySetResult(result);
		}
	}
	public class IpcHandler : Handler
	{
		private readonly IpcMethodHandler ipcMethodHandler;

		public IpcHandler()
		{
			ipcMethodHandler = new IpcMethodHandler();
		}

		public static Messenger GetMessenger()
		{
			return new Messenger(new IpcHandler());
		}

		public override void HandleMessage(Message msg)
		{
			iFit.Logger.Log.Trace("Ipc", "Ipc Message received by IpcHandler");
			try
			{
				ProcessMessage(msg);
			}
			catch (System.Exception)
			{
			}
		}

		protected async Task ProcessMessage(Message msg)
		{
			iFit.Logger.Log.Trace("Ipc", "IpcHandler beginning to process message");
			bool shouldKillProcress = false;
			Messenger replyMesseger = msg.ReplyTo;
			try
			{
				IpcObject ipcObject = IpcMessageHelper.GetIpcObjectFromMessage(msg);
				if (ipcObject == null)
				{
					iFit.Logger.Log.Trace("Ipc", "IpcObject extracted from message is NULL");
					ipcObject = new IpcObject("Error", "")
					{
						Id = -1L,
						Data = "",
						Error = "Could not deserialize IpcObject"
					};
				}
				else
				{
					iFit.Logger.Log.Trace("Ipc", "IpcObject was extracted. Method being called is: " + ipcObject.Name);
					try
					{
						ipcObject = await ipcMethodHandler.HandleMethodCall(ipcObject);
						iFit.Logger.Log.Trace("Ipc", "IpcMethod execution complete");
						shouldKillProcress = ipcMethodHandler.ShouldKillProcess(ipcObject);
					}
					catch (System.Exception ex)
					{
						iFit.Logger.Log.Warn("Ipc", "Exception while executing IpcMethod: " + ex);
						ipcObject.Data = "";
						ipcObject.Error = ex.ToString();
					}
				}
				iFit.Logger.Log.Trace("Ipc", "IpcHandler about to reply to IpcClient");
				replyMesseger?.Send(IpcMessageHelper.CreateMessage(ipcObject));
			}
			catch (System.Exception)
			{
			}
			if (shouldKillProcress)
			{
				iFit.Logger.Log.Trace("Ipc", "IpcHandler is about to kill the process");
				global::Android.OS.Process.KillProcess(global::Android.OS.Process.MyPid());
			}
		}
	}
	public static class IpcMessageHelper
	{
		public const string DataKey = "IpcDataKey";

		public static Message CreateMessage(IpcObject ipcObject, Messenger messenger = null)
		{
			Bundle bundle = new Bundle();
			bundle.PutString("IpcDataKey", ipcObject.Serialize());
			Message message = Message.Obtain();
			message.Data = bundle;
			if (messenger != null)
			{
				message.ReplyTo = messenger;
			}
			return message;
		}

		public static IpcObject GetIpcObjectFromMessage(Message msg)
		{
			string text = msg.Data.GetString("IpcDataKey", "");
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}
			try
			{
				return IpcObject.Deserialize(text);
			}
			catch (System.Exception)
			{
				return null;
			}
		}
	}
	[AttributeUsage(AttributeTargets.Class)]
	public class IpcMethodAttribute : Attribute
	{
	}
	public class IpcMethodHandler
	{
		private static bool initialized;

		private static readonly Dictionary<string, Type> ipcMethods = new Dictionary<string, Type>();

		public void Init()
		{
			if (initialized)
			{
				return;
			}
			try
			{
				GetAllAssemblies().ForEach(delegate(Assembly asm)
				{
					FilterIpcMethodsFromTypes(GetAllTypesFromAssembly(asm)).ForEach(delegate(Type type)
					{
						ipcMethods[type.Name] = type;
					});
				});
				initialized = true;
			}
			catch (System.Exception)
			{
			}
		}

		private List<Assembly> GetAllAssemblies()
		{
			List<Assembly> list = new List<Assembly>();
			try
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				if (assemblies != null && assemblies.Length != 0)
				{
					list.AddRange(assemblies);
				}
			}
			catch (System.Exception)
			{
			}
			return list;
		}

		private List<Type> GetAllTypesFromAssembly(Assembly assembly)
		{
			List<Type> list = new List<Type>();
			try
			{
				Type[] types = assembly.GetTypes();
				list.AddRange(types);
			}
			catch (System.Exception)
			{
			}
			return list;
		}

		private List<Type> FilterIpcMethodsFromTypes(IEnumerable<Type> types)
		{
			List<Type> list = new List<Type>();
			try
			{
				IEnumerable<Type> collection = types.Where((Type x) => ContainsIpcConstuctor(x) && ContainsIpcAttribute(x));
				list.AddRange(collection);
			}
			catch (System.Exception)
			{
			}
			return list;
		}

		private bool ContainsIpcConstuctor(Type type)
		{
			try
			{
				return type.GetConstructor(new Type[1] { typeof(IpcObject) }) != null;
			}
			catch (System.Exception)
			{
			}
			return false;
		}

		private bool ContainsIpcAttribute(Type type)
		{
			try
			{
				return type.CustomAttributes.Any((CustomAttributeData x) => x.AttributeType == typeof(IpcMethodAttribute));
			}
			catch (System.Exception)
			{
			}
			return false;
		}

		public bool ShouldKillProcess(IpcObject ipcObject)
		{
			try
			{
				return GetMethod(ipcMethods[ipcObject.Name], ipcObject).ShouldKillProcessWhenDone;
			}
			catch (System.Exception)
			{
			}
			return false;
		}

		public async Task<IpcObject> HandleMethodCall(IpcObject ipcObject)
		{
			if (!initialized)
			{
				Init();
			}
			if (!string.IsNullOrWhiteSpace(ipcObject.Name) && ipcMethods.ContainsKey(ipcObject.Name))
			{
				ipcObject = await ExecuteMethod(ipcMethods[ipcObject.Name], ipcObject);
			}
			else
			{
				ipcObject.Data = "";
				ipcObject.Error = "Method not found";
			}
			return ipcObject;
		}

		private async Task<IpcObject> ExecuteMethod(Type type, IpcObject ipcObject)
		{
			try
			{
				BaseIpcMethod method = GetMethod(type, ipcObject);
				ipcObject = await method.Execute();
			}
			catch (System.Exception ex)
			{
				ipcObject.Data = "";
				ipcObject.Error = ex.ToString();
			}
			return ipcObject;
		}

		private BaseIpcMethod GetMethod(Type type, IpcObject ipcObject)
		{
			return type.GetConstructor(new Type[1] { typeof(IpcObject) })?.Invoke(new object[1] { ipcObject }) as BaseIpcMethod;
		}
	}
	public class IpcObject
	{
		private static long nextId;

		public long Id { get; set; }

		public string Name { get; set; }

		public string Data { get; set; }

		public string Error { get; set; }

		public IpcObject(string name, object data)
		{
			Id = nextId++;
			Name = name;
			Data = JsonConvert.SerializeObject(data);
			Error = string.Empty;
		}

		public string Serialize()
		{
			return $"{{\"Id\":{Id},\"Name\":\"{Name}\",\"Data\":{Data},\"Error\":{JsonConvert.SerializeObject(Error)}}}";
		}

		public static IpcObject Deserialize(string json)
		{
			return JsonConvert.DeserializeObject<IpcObject>(json);
		}
	}
	public abstract class IpcService : global::Android.App.Service
	{
		private readonly Messenger messenger;

		protected IpcService()
		{
			iFit.Logger.Log.Trace("Ipc", "IpcService constructor called");
			messenger = IpcHandler.GetMessenger();
		}

		public override IBinder OnBind(Intent intent)
		{
			return messenger.Binder;
		}
	}
}
namespace Shire.Android.Dialogs
{
	public class TwitterShareDialogFragment : global::Android.App.DialogFragment, IWebViewClientCallback, IWebViewClientCallbackListener
	{
		private const string ExtraTitle = "Twitter:ExtraTitle";

		private const string ExtraUrl = "Twitter:ExtraUrl";

		private const string ExtraCancelText = "Twitter:ExtraCancel";

		private DialogFragmentPlacementKeyboardUtil keyboardUtil;

		public EventHandler CancelClick;

		public IfitTextView CancelButton { get; private set; }

		public IActivityResultCallback CallbackListener { private get; set; }

		public int RequestCodeForCallback { private get; set; }

		protected TwitterShareDialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public TwitterShareDialogFragment()
		{
		}

		public static TwitterShareDialogFragment Create(string url, string title = null, string cancelText = null)
		{
			if (title == null)
			{
				title = AppStrings.share_with_twitter;
			}
			if (cancelText == null)
			{
				cancelText = AppStrings.twitter_dialog_done.ToUpperInvariant();
			}
			TwitterShareDialogFragment twitterShareDialogFragment = new TwitterShareDialogFragment();
			Bundle bundle = new Bundle();
			bundle.PutString("Twitter:ExtraUrl", url);
			bundle.PutString("Twitter:ExtraTitle", title);
			bundle.PutString("Twitter:ExtraCancel", cancelText);
			twitterShareDialogFragment.Arguments = bundle;
			return twitterShareDialogFragment;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			Dialog.RequestWindowFeature(1);
			global::Android.Views.Window window = Dialog.Window;
			window.SetGravity(GravityFlags.Center);
			return inflater.Inflate(Resource.Layout.TwitterDialog, container, attachToRoot: false);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			view.Post(SetLayoutDimens);
			string text = base.Arguments.GetString("Twitter:ExtraTitle");
			string url = base.Arguments.GetString("Twitter:ExtraUrl");
			string text2 = base.Arguments.GetString("Twitter:ExtraCancel");
			WebView webView = view.FindViewById<WebView>(Resource.Id.twitterWebView);
			webView.Settings.JavaScriptEnabled = true;
			webView.LoadUrl(url);
			webView.SetWebViewClient(new SharingWebViewClient(this));
			IfitTextView ifitTextView = view.FindViewById<IfitTextView>(Resource.Id.twitterDialogTitle);
			ifitTextView.Text = text;
			CancelButton = view.FindViewById<IfitTextView>(Resource.Id.twitterCancelButton);
			CancelButton.Text = text2;
			CancelButton.Click -= Finish;
			CancelButton.Click += Finish;
			keyboardUtil = new DialogFragmentPlacementKeyboardUtil(base.Activity, View, Dialog.Window);
			keyboardUtil.Enable();
		}

		private void SetLayoutDimens()
		{
			int dimensionPixelSize = base.Resources.GetDimensionPixelSize(Resource.Dimension.twitter_dialog_width);
			Dialog.Window.SetLayout(dimensionPixelSize, -2);
		}

		public override void OnCancel(IDialogInterface dialog)
		{
			base.OnCancel(dialog);
			CallbackListener.OnActivityResult(RequestCodeForCallback, global::Android.App.Result.Canceled, null);
			Finish(this, null);
		}

		private void Finish(object sender, EventArgs e)
		{
			CancelClick?.Invoke(sender, e);
			DismissAllowingStateLoss();
		}

		public override void OnDestroyView()
		{
			base.OnDestroyView();
			keyboardUtil?.Disable();
		}

		public void SetWebViewResult(global::Android.App.Result result)
		{
			CallbackListener.OnActivityResult(RequestCodeForCallback, result, null);
			if (result == global::Android.App.Result.Ok)
			{
				DismissAllowingStateLoss();
			}
		}
	}
	internal interface IWebViewClientCallback
	{
		void SetWebViewResult(global::Android.App.Result result);
	}
	internal class SharingWebViewClient : WebViewClient
	{
		private readonly IWebViewClientCallback callback;

		public SharingWebViewClient(IWebViewClientCallback callback)
		{
			this.callback = callback;
		}

		[Obsolete]
		public override bool ShouldOverrideUrlLoading(WebView view, string url)
		{
			if (url.Contains("latest_status_id="))
			{
				callback.SetWebViewResult(global::Android.App.Result.Ok);
			}
			return false;
		}

		[Obsolete]
		public override void OnReceivedError(WebView view, ClientError errorCode, string description, string failingUrl)
		{
			callback.SetWebViewResult(global::Android.App.Result.Canceled);
		}
	}
	public class WebViewDialogFragment : global::Android.App.DialogFragment
	{
		private string url;

		private string title;

		private string cancelText;

		private WebView.WebViewTransport transport;

		private Message transportMessage;

		public IfitTextView TitleText;

		public EventHandler CancelClick;

		public WebView WebView { get; private set; }

		public IfitTextView CancelButton { get; private set; }

		protected WebViewDialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public WebViewDialogFragment()
		{
		}

		public static WebViewDialogFragment Create(string url, string title = null, string cancelText = null)
		{
			if (title == null)
			{
				title = string.Empty;
			}
			if (cancelText == null)
			{
				cancelText = AppStrings.cancel.ToUpperInvariant();
			}
			WebViewDialogFragment webViewDialogFragment = new WebViewDialogFragment();
			webViewDialogFragment.url = url;
			webViewDialogFragment.title = title;
			webViewDialogFragment.cancelText = cancelText;
			return webViewDialogFragment;
		}

		public static WebViewDialogFragment Create(Message message, string title = null, string cancelText = null)
		{
			if (title == null)
			{
				title = string.Empty;
			}
			if (cancelText == null)
			{
				cancelText = AppStrings.cancel.ToUpperInvariant();
			}
			WebViewDialogFragment webViewDialogFragment = new WebViewDialogFragment();
			webViewDialogFragment.transportMessage = message;
			webViewDialogFragment.transport = (WebView.WebViewTransport)message.Obj;
			webViewDialogFragment.url = null;
			webViewDialogFragment.title = title;
			webViewDialogFragment.cancelText = cancelText;
			return webViewDialogFragment;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			Dialog.RequestWindowFeature(1);
			global::Android.Views.Window window = Dialog.Window;
			window.SetGravity(GravityFlags.Center);
			return inflater.Inflate(Resource.Layout.WebViewDialog, container, attachToRoot: false);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			view.Post(SetLayoutDimens);
			WebView = view.FindViewById<WebView>(Resource.Id.dialogWebView);
			WebView.SetWebViewClient(new DialogWebViewClient(this));
			if (url != null)
			{
				WebView.LoadUrl(url);
			}
			else
			{
				transport.WebView = WebView;
				transportMessage.SendToTarget();
			}
			TitleText = view.FindViewById<IfitTextView>(Resource.Id.dialogTitle);
			TitleText.Text = title;
			CancelButton = view.FindViewById<IfitTextView>(Resource.Id.dialogCancelButton);
			CancelButton.Text = cancelText;
			CancelButton.Click -= Finish;
			CancelButton.Click += Finish;
		}

		private void SetLayoutDimens()
		{
			int dimensionPixelSize = base.Resources.GetDimensionPixelSize(Resource.Dimension.webview_dialog_width);
			Dialog.Window.SetLayout(dimensionPixelSize, -2);
		}

		public override void OnCancel(IDialogInterface dialog)
		{
			base.OnCancel(dialog);
			CancelButton.Click -= Finish;
			Finish(this, null);
		}

		private void Finish(object sender, EventArgs e)
		{
			CancelClick?.Invoke(sender, e);
			DismissAllowingStateLoss();
		}

		public override void OnDestroyView()
		{
			base.OnDestroyView();
		}
	}
	internal class DialogWebViewClient : WebViewClient
	{
		private WebViewDialogFragment dialog;

		public DialogWebViewClient(WebViewDialogFragment frag)
		{
			dialog = frag;
		}

		public override void OnPageFinished(WebView view, string url)
		{
			if (string.IsNullOrEmpty(dialog.TitleText.Text))
			{
				dialog.TitleText.Text = view.Title;
			}
			base.OnPageFinished(view, url);
		}
	}
}
namespace Shire.Android.Culture
{
	public class Culture : ICulture
	{
		protected static readonly string CultureLogTag = "Culture";

		private const string ChinaNameFormat = "{1} {0}";

		private const string DefaultNameFormat = "{0} {1}";

		private readonly Dictionary<string, string> cultureToNameFormatDictionary = new Dictionary<string, string>
		{
			{
				Locale.China.Language,
				"{1} {0}"
			},
			{
				Locale.English.Language,
				"{0} {1}"
			}
		};

		private readonly Dictionary<string, NameValidator> cultureToNameValidatorDictionary = new Dictionary<string, NameValidator>
		{
			{
				Locale.China.Language,
				NameValidators.ChinaNameValidator
			},
			{
				Locale.English.Language,
				NameValidators.DefaultNameValidator
			}
		};

		public CultureInfo CurrentCultureInfo()
		{
			CultureInfo cultureInfo = null;
			string text = "en";
			Locale locale = Locale.Default;
			text = AndroidToDotnetLanguage(locale.ToString().Replace("_", "-"));
			try
			{
				cultureInfo = new CultureInfo(text);
			}
			catch (CultureNotFoundException ex)
			{
				string text2 = ToDotnetFallbackLanguage(new PlatformCulture(text));
				try
				{
					iFit.Logger.Log.Info(CultureLogTag, "ERROR - netLanguage " + text + " failed, trying " + text2 + " (" + ex.Message + ")");
					cultureInfo = new CultureInfo(text2);
				}
				catch (CultureNotFoundException ex2)
				{
					iFit.Logger.Log.Info(CultureLogTag, "ERROR - fallback " + text2 + " failed, using 'en' " + text2 + " (" + ex2.Message + ")");
					cultureInfo = new CultureInfo("en");
				}
			}
			if (cultureInfo.Calendar is ThaiBuddhistCalendar || cultureInfo.Calendar is UmAlQuraCalendar)
			{
				iFit.Logger.Log.Info(CultureLogTag, $"ERROR - detected {cultureInfo.Calendar} calendar, switching to 'en' culture instead");
				cultureInfo = CultureInfo.GetCultureInfo("en");
			}
			return cultureInfo;
		}

		public bool ValidCultureCode(string cultureCode)
		{
			switch (cultureCode)
			{
			case "zh":
			case "fr":
			case "en":
			case "de":
			case "es":
			case "te":
				return true;
			default:
				return false;
			}
		}

		public CultureInfo SetLocale(string cultureCode)
		{
			if (!ValidCultureCode(cultureCode))
			{
				return CurrentCultureInfo();
			}
			CultureInfo cultureInfo = CurrentCultureInfo();
			if (cultureCode != "")
			{
				try
				{
					cultureInfo = new CultureInfo(cultureCode);
				}
				catch (System.Exception exception)
				{
					iFit.Logger.Log.Error(CultureLogTag, "An error occurred returning CultureInfo with language \"" + (cultureCode ?? "null") + "\"", exception);
				}
			}
			System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
			System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
			return cultureInfo;
		}

		private static string AndroidToDotnetLanguage(string androidLanguage)
		{
			iFit.Logger.Log.Info(CultureLogTag, "android Language:" + androidLanguage);
			string text = androidLanguage;
			if (!(androidLanguage == "ms-BN"))
			{
				switch (androidLanguage)
				{
				case "ms-MY":
				case "ms-SG":
					break;
				case "in-ID":
					text = "id-ID";
					goto IL_0071;
				case "gsw-CH":
					text = "de-CH";
					goto IL_0071;
				default:
					goto IL_0071;
				}
			}
			text = "ms";
			goto IL_0071;
			IL_0071:
			iFit.Logger.Log.Info(CultureLogTag, ".NET Language/Locale:" + text);
			return text;
		}

		private static string ToDotnetFallbackLanguage(PlatformCulture platCulture)
		{
			iFit.Logger.Log.Info(CultureLogTag, ".NET Fallback Language:" + platCulture.LanguageCode);
			string text = platCulture.LanguageCode;
			string languageCode = platCulture.LanguageCode;
			if (languageCode == "gsw")
			{
				text = "de-CH";
			}
			iFit.Logger.Log.Info(CultureLogTag, ".NET Fallback Language/Locale:" + text + " (application-specific)");
			return text;
		}

		public string GetFormattedName(string firstName, string lastName)
		{
			CultureInfo cultureInfo = CurrentCultureInfo();
			if (cultureToNameFormatDictionary.TryGetValue(cultureInfo.TwoLetterISOLanguageName, out var value))
			{
				return string.Format(value, firstName, lastName);
			}
			return $"{firstName} {lastName}";
		}

		public NameValidator GetNameValidator()
		{
			CultureInfo cultureInfo = CurrentCultureInfo();
			if (cultureToNameValidatorDictionary.TryGetValue(cultureInfo.TwoLetterISOLanguageName, out var value))
			{
				return value;
			}
			return NameValidators.DefaultNameValidator;
		}

		public string GetFormattedInitials(string firstName, string lastName)
		{
			string formattedName = GetFormattedName(firstName, lastName);
			string[] array = formattedName.Split(' ');
			if (array.Length == 2 && !string.IsNullOrEmpty(array[0]) && !string.IsNullOrEmpty(array[1]))
			{
				string nextTextElement = StringInfo.GetNextTextElement(array[0].ToUpper());
				string nextTextElement2 = StringInfo.GetNextTextElement(array[1].ToUpper());
				return nextTextElement + nextTextElement2;
			}
			return string.Empty;
		}
	}
}
namespace Shire.Android.Converters
{
	[MvxUnconventional]
	public class BoolToIntConverter : MvxValueConverter<bool, int>
	{
		private int OnTrue { get; set; }

		private int OnFalse { get; set; }

		public BoolToIntConverter(int onTrue, int onFalse)
		{
			OnTrue = onTrue;
			OnFalse = onFalse;
		}

		protected override int Convert(bool value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!value)
			{
				return OnFalse;
			}
			return OnTrue;
		}
	}
	public class DoubleToStringConverter : MvxValueConverter<double, string>
	{
		private string FormatStr { get; set; }

		public DoubleToStringConverter(string formatStr)
		{
			FormatStr = formatStr;
		}

		protected override string Convert(double value, Type targetType, object parameter, CultureInfo culture)
		{
			return value.ToString(FormatStr);
		}
	}
	[MvxUnconventional]
	public class IntToDrawableConverter : MvxValueConverter<int, Drawable>
	{
		private readonly Context context;

		public IntToDrawableConverter(Context context)
		{
			this.context = context;
		}

		protected override Drawable Convert(int value, Type targetType, object parameter, CultureInfo culture)
		{
			return context.GetDrawable(value);
		}
	}
	[MvxUnconventional]
	public class StringToDrawableConverter : MvxValueConverter<string, int>, IDisposable
	{
		private Context Context { get; set; }

		public StringToDrawableConverter(Context context)
		{
			Context = context;
		}

		protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
		{
			return Shire.Android.Util.ImageUtil.GetImageResourceFromName(Context, value);
		}

		public void Dispose()
		{
			Context = null;
		}
	}
	public class StringToImageResourceIdValueConverter : MvxValueConverter<string, int>
	{
		private readonly Context context;

		public StringToImageResourceIdValueConverter(Context context)
		{
			this.context = context;
		}

		protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
		{
			return Shire.Android.Util.ImageUtil.GetImageResourceFromName(context, value);
		}
	}
	public class VisibilityGoneValueConverter : MvxValueConverter<bool, ViewStates>
	{
		private readonly bool isReversed;

		public VisibilityGoneValueConverter(bool isReversed = false)
		{
			this.isReversed = isReversed;
		}

		protected override ViewStates Convert(bool value, Type targetType, object parameter, CultureInfo culture)
		{
			if (isReversed)
			{
				if (!value)
				{
					return ViewStates.Visible;
				}
				return ViewStates.Gone;
			}
			if (!value)
			{
				return ViewStates.Gone;
			}
			return ViewStates.Visible;
		}

		protected override bool ConvertBack(ViewStates value, Type targetType, object parameter, CultureInfo culture)
		{
			if (isReversed)
			{
				return value == ViewStates.Gone;
			}
			return value == ViewStates.Visible;
		}
	}
	public class VisibilityInvisibleValueConverter : MvxValueConverter<bool, ViewStates>
	{
		private readonly bool isReversed;

		public VisibilityInvisibleValueConverter(bool isReversed = false)
		{
			this.isReversed = isReversed;
		}

		protected override ViewStates Convert(bool value, Type targetType, object parameter, CultureInfo culture)
		{
			if (isReversed)
			{
				if (!value)
				{
					return ViewStates.Visible;
				}
				return ViewStates.Invisible;
			}
			if (!value)
			{
				return ViewStates.Invisible;
			}
			return ViewStates.Visible;
		}

		protected override bool ConvertBack(ViewStates value, Type targetType, object parameter, CultureInfo culture)
		{
			if (isReversed)
			{
				return value == ViewStates.Invisible;
			}
			return value == ViewStates.Visible;
		}
	}
}
namespace Shire.Android.Controls
{
	public class BasicImageView : ImageView
	{
		private int _resourceId;

		private Color _tintColor;

		public int ResourceId
		{
			get
			{
				return _resourceId;
			}
			set
			{
				if (_resourceId != value)
				{
					_resourceId = value;
					SetImageResource(_resourceId);
				}
			}
		}

		public Color TintColor
		{
			get
			{
				return _tintColor;
			}
			set
			{
				_tintColor = value;
				SetColorFilter(_tintColor, PorterDuff.Mode.SrcIn);
			}
		}

		public BasicImageView(IntPtr ptr, JniHandleOwnership transfer)
			: base(ptr, transfer)
		{
		}

		public BasicImageView(Context context)
			: base(context)
		{
		}

		public BasicImageView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		public BasicImageView(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
		}
	}
	public class BetterImageView : ImageView
	{
		private new const string Tag = "BetterImageView";

		private string _imageUrl;

		private byte[] _byteArray;

		private int defaultResourceId = Resource.Id.none;

		private int _resourceId = Resource.Id.none;

		private int _errorResourceId = Resource.Id.none;

		private Bitmap _bitmap;

		private Color _tintColor;

		private bool sourceWasUpdatedDuringAnimation;

		private bool showLoadingAnimation;

		private bool cropByteArray;

		private bool disposing;

		private bool hasImage;

		private ObjectAnimator animator;

		private CancellationTokenSource cancellationSource;

		public string ImageUrl
		{
			get
			{
				return _imageUrl;
			}
			set
			{
				string imageUrl = _imageUrl;
				if (imageUrl == null || !imageUrl.Equals(value))
				{
					_imageUrl = value;
					if (cancellationSource != null)
					{
						cancellationSource.Cancel();
						cancellationSource = null;
					}
					if (string.IsNullOrWhiteSpace(_imageUrl))
					{
						ClearImage();
					}
					else if (animator?.IsRunning == true)
					{
						sourceWasUpdatedDuringAnimation = true;
					}
					else
					{
						CheckPendingImages();
					}
				}
			}
		}

		public byte[] ByteArray
		{
			get
			{
				return _byteArray;
			}
			set
			{
				SetByteArray(value);
				CheckPendingImages();
			}
		}

		public int ResourceId
		{
			get
			{
				return _resourceId;
			}
			set
			{
				if (_resourceId != value)
				{
					_resourceId = value;
					if (_resourceId <= 0 || _resourceId == Resource.Id.none)
					{
						ClearImage();
					}
					else if (animator?.IsRunning == true)
					{
						sourceWasUpdatedDuringAnimation = true;
					}
					else
					{
						CheckPendingImages();
					}
				}
			}
		}

		public int ErrorResourceId
		{
			get
			{
				return _errorResourceId;
			}
			set
			{
				if (_errorResourceId != value)
				{
					_errorResourceId = value;
				}
			}
		}

		public Bitmap ImageBitmap
		{
			get
			{
				return _bitmap;
			}
			set
			{
				if (_bitmap != value)
				{
					_bitmap = value;
					if (_bitmap == null)
					{
						ClearImage();
					}
					else if (animator?.IsRunning == true)
					{
						sourceWasUpdatedDuringAnimation = true;
					}
					else
					{
						CheckPendingImages();
					}
				}
			}
		}

		public Func<Bitmap, Task<Bitmap>> Mask { get; set; }

		public Color TintColor
		{
			get
			{
				return _tintColor;
			}
			set
			{
				_tintColor = value;
				SetColorFilter(_tintColor, PorterDuff.Mode.SrcIn);
			}
		}

		public BetterImageView(IntPtr ptr, JniHandleOwnership transfer)
			: base(ptr, transfer)
		{
		}

		public BetterImageView(Context context)
			: base(context)
		{
			Init(context, null);
		}

		public BetterImageView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Init(context, attrs);
		}

		public BetterImageView(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Init(context, attrs);
		}

		private void Init(Context context, IAttributeSet attrs)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.BetterImageView);
			showLoadingAnimation = typedArray.GetBoolean(Resource.Styleable.BetterImageView_showLoadingAnimation, defValue: false);
			defaultResourceId = typedArray.GetResourceId(Resource.Styleable.BetterImageView_defaultResource, Resource.Id.none);
			cropByteArray = typedArray.GetBoolean(Resource.Styleable.BetterImageView_cropByteArray, defValue: false);
			typedArray.Recycle();
			CheckPendingImages();
		}

		protected override void OnDraw(Canvas canvas)
		{
			if (hasImage)
			{
				base.OnDraw(canvas);
			}
		}

		protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged(w, h, oldw, oldh);
			CheckPendingImages();
		}

		public async Task SetBytesAndAnimate(byte[] bytes, Action animationHandler)
		{
			SetByteArray(bytes);
			await CompletelySetPendingImage();
			animationHandler?.Invoke();
		}

		private void SetByteArray(byte[] bytes)
		{
			if (bytes != null)
			{
				byte[] byteArray = _byteArray;
				if (byteArray != null && Enumerable.SequenceEqual(byteArray, bytes))
				{
					return;
				}
			}
			_byteArray = bytes;
			if (_byteArray == null || _byteArray.Length == 0)
			{
				ClearImage();
			}
			else if (animator?.IsRunning == true)
			{
				sourceWasUpdatedDuringAnimation = true;
			}
		}

		private void CheckPendingImages()
		{
			Task.Run(() => SetPendingImage());
		}

		private async Task CompletelySetPendingImage()
		{
			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			await Task.Run(() => SetPendingImage(tcs));
			await tcs.Task;
		}

		private async Task SetPendingImage(TaskCompletionSource<object> tcs = null)
		{
			try
			{
				Bitmap bitmap = null;
				bool fromDefaultResource = false;
				CancellationTokenSource imageSource = null;
				if (disposing)
				{
					tcs?.TrySetResult(null);
					return;
				}
				if (base.MeasuredWidth > 0 && base.MeasuredHeight > 0)
				{
					if (!string.IsNullOrEmpty(ImageUrl))
					{
						cancellationSource?.Cancel();
						imageSource = new CancellationTokenSource();
						cancellationSource = imageSource;
						bitmap = await Shire.Android.Util.ImageUtil.DownloadImage(ImageUrl, base.MeasuredWidth, base.MeasuredHeight);
						_byteArray = null;
						_resourceId = Resource.Id.none;
						defaultResourceId = Resource.Id.none;
					}
					else
					{
						byte[] byteArray = ByteArray;
						if (byteArray != null && byteArray.Length != 0)
						{
							if (cropByteArray)
							{
								bitmap = await Shire.Android.Util.ImageUtil.ScaleByteArrayWithCrop(ByteArray, base.MeasuredWidth, base.MeasuredHeight);
							}
							else
							{
								bitmap = await Shire.Android.Util.ImageUtil.ScaleByteArray(ByteArray, base.MeasuredWidth, base.MeasuredHeight, maintainAspectRatio: true);
							}
							_imageUrl = null;
							_resourceId = Resource.Id.none;
							defaultResourceId = Resource.Id.none;
						}
						else if (ResourceId != Resource.Id.none)
						{
							bitmap = await Shire.Android.Util.ImageUtil.ScaleResource(Resources, ResourceId, base.MeasuredWidth, base.MeasuredHeight);
							_byteArray = null;
							_imageUrl = null;
							defaultResourceId = Resource.Id.none;
						}
						else if (_bitmap != null)
						{
							bitmap = _bitmap;
							_bitmap = null;
							_imageUrl = null;
							_byteArray = null;
							_resourceId = Resource.Id.none;
							defaultResourceId = Resource.Id.none;
						}
						else if (defaultResourceId != Resource.Id.none)
						{
							bitmap = await Shire.Android.Util.ImageUtil.ScaleResource(Resources, defaultResourceId, base.MeasuredWidth, base.MeasuredHeight);
							fromDefaultResource = true;
						}
						else
						{
							global::Android.Util.Log.Error("BetterImageView", "SetPendingImage no url, bytes, or resource specified.");
						}
					}
					if (bitmap == null)
					{
						global::Android.Util.Log.Error("BetterImageView", "SetPendingImage unable to make bitmap, content will not be set.");
					}
				}
				if (disposing)
				{
					tcs?.TrySetResult(null);
					return;
				}
				if (bitmap != null)
				{
					if (Mask != null && (imageSource?.IsCancellationRequested ?? false))
					{
						bitmap = await Mask(bitmap);
					}
					Post(delegate
					{
						CancellationTokenSource cancellationTokenSource = imageSource;
						if (cancellationTokenSource != null && cancellationTokenSource.IsCancellationRequested)
						{
							bitmap.Recycle();
							tcs?.TrySetResult(null);
						}
						else
						{
							ApplyBitmap(bitmap, fromDefaultResource, tcs);
						}
					});
					return;
				}
			}
			catch (TaskCanceledException)
			{
			}
			catch (System.Exception ex2)
			{
				global::Android.Util.Log.Error("BetterImageView", "Failed to load image", ex2);
				if (ex2?.InnerException != null)
				{
					global::Android.Util.Log.Error("BetterImageView", "Failed to load image with InnerException", ex2.InnerException);
				}
				try
				{
					if (_errorResourceId > 0 && _errorResourceId != Resource.Id.none)
					{
						Bitmap bitmap2 = await Shire.Android.Util.ImageUtil.ScaleResource(Resources, _errorResourceId, base.MeasuredWidth, base.MeasuredHeight);
						if (bitmap2 != null)
						{
							Post(delegate
							{
								ApplyBitmap(bitmap2, fromDefaultResource: false, tcs);
							});
							return;
						}
					}
				}
				catch (System.Exception ex3)
				{
					global::Android.Util.Log.Error("BetterImageView", "Failed to load error image", ex3);
				}
			}
			tcs?.TrySetResult(null);
		}

		private void ApplyBitmap(Bitmap bitmap, bool fromDefaultResource = false, TaskCompletionSource<object> tcs = null)
		{
			try
			{
				if (!disposing && (!fromDefaultResource || !hasImage))
				{
					hasImage = true;
					RecycleAndDisposeDrawables();
					SetImageBitmap(bitmap);
					RunAnimation();
				}
			}
			catch (ObjectDisposedException)
			{
			}
			finally
			{
				tcs?.TrySetResult(null);
				bitmap?.Dispose();
				bitmap = null;
			}
		}

		private void RecycleAndDisposeDrawables()
		{
			if (Drawable is TransitionDrawable transitionDrawable)
			{
				for (int i = 0; i < transitionDrawable.NumberOfLayers; i++)
				{
					Drawable drawable = transitionDrawable.GetDrawable(i);
					if (drawable is BitmapDrawable bitmapDrawable)
					{
						bitmapDrawable.Bitmap?.Recycle();
					}
					drawable?.Dispose();
				}
			}
			else if (Drawable is BitmapDrawable bitmapDrawable2)
			{
				bitmapDrawable2.Bitmap?.Recycle();
			}
			Drawable?.Dispose();
		}

		private void RunAnimation()
		{
			try
			{
				if (animator?.IsRunning == true)
				{
					return;
				}
			}
			catch (ObjectDisposedException)
			{
			}
			if (!showLoadingAnimation || animator != null)
			{
				return;
			}
			AlphaSatColorMatrixEvaluator evaluator = new AlphaSatColorMatrixEvaluator();
			ColorMatrixColorFilter filter = new ColorMatrixColorFilter(evaluator.ColorMatrix);
			Drawable?.SetColorFilter(filter);
			animator = ObjectAnimator.OfObject(filter, "colorMatrix", evaluator, evaluator.ColorMatrix, evaluator.ColorMatrix);
			animator.Update += delegate
			{
				if (!disposing)
				{
					Drawable?.SetColorFilter(filter);
				}
			};
			animator.AnimationEnd += delegate
			{
				evaluator?.Dispose();
				filter?.Dispose();
				if (sourceWasUpdatedDuringAnimation)
				{
					sourceWasUpdatedDuringAnimation = false;
					CheckPendingImages();
				}
				if (!disposing)
				{
					Drawable?.SetColorFilter(null);
				}
			};
			animator.SetDuration(1000L);
			animator.Start();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			this.disposing = true;
		}

		private void ClearImage()
		{
			(Drawable as BitmapDrawable)?.Bitmap?.Recycle();
			Drawable?.Dispose();
			SetImageResource(0);
			hasImage = false;
		}

		protected override void OnDetachedFromWindow()
		{
			base.OnDetachedFromWindow();
			animator?.End();
			animator?.RemoveAllListeners();
			animator?.Dispose();
			animator = null;
			ClearImage();
			_byteArray = null;
			_imageUrl = null;
			Dispose();
		}
	}
	internal class AlphaSatColorMatrixEvaluator : Java.Lang.Object, ITypeEvaluator, IJavaObject, IDisposable, IJavaPeerable
	{
		private readonly ColorMatrix colorMatrix = new ColorMatrix();

		private readonly float[] elements = new float[20];

		public ColorMatrix ColorMatrix => colorMatrix;

		public AlphaSatColorMatrixEvaluator(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		public AlphaSatColorMatrixEvaluator()
		{
		}

		public Java.Lang.Object Evaluate(float fraction, Java.Lang.Object startValue, Java.Lang.Object endValue)
		{
			float val = fraction * 3f;
			float num = System.Math.Min(val, 2f) / 2f;
			elements[19] = (float)System.Math.Round(num * 255f);
			float num2 = (float)System.Math.Round((1f - System.Math.Min(val, 2.5f) / 2.5f) * 100f);
			elements[4] = (elements[9] = (elements[14] = 0f - num2));
			float num3 = 1f - System.Math.Max(0.2f, fraction);
			float num4 = 0.213f * num3;
			float num5 = 0.715f * num3;
			float num6 = 0.072f * num3;
			elements[0] = num4 + fraction;
			elements[1] = num5;
			elements[2] = num6;
			elements[5] = num4;
			elements[6] = num5 + fraction;
			elements[7] = num6;
			elements[10] = num4;
			elements[11] = num5;
			elements[12] = num6 + fraction;
			colorMatrix.Set(elements);
			return colorMatrix;
		}
	}
	public class CircleImageView : ImageView
	{
		private new const string Tag = "CircleImageView";

		private new readonly ScaleType ScaleType = ScaleType.CenterCrop;

		private readonly Bitmap.Config BitmapConfig = Bitmap.Config.Argb8888;

		private const int ColorDrawableDimension = 2;

		private const int DefaultBorderWidth = 0;

		private static readonly int DefaultBorderColor = Color.Black.ToArgb();

		private static readonly int DefaultFillColor = Color.Transparent.ToArgb();

		private const bool DefaultBorderOverlay = false;

		private readonly RectF drawableRect = new RectF();

		private readonly RectF borderRect = new RectF();

		private readonly Matrix shaderMatrix = new Matrix();

		private readonly Paint bitmapPaint = new Paint();

		private readonly Paint borderPaint = new Paint();

		private readonly Paint fillPaint = new Paint();

		private int borderColor = DefaultBorderColor;

		private int borderWidth;

		private int fillColor = DefaultFillColor;

		private Bitmap bitmap;

		private BitmapShader bitmapShader;

		private int bitmapWidth;

		private int bitmapHeight;

		private float drawableRadius;

		private float borderRadius;

		private ColorFilter colorFilter;

		private bool isReady;

		private bool isSetupPending;

		private bool hasBorderOverlay;

		private bool disableCircularTransformation;

		public IBitmap Image
		{
			get
			{
				return null;
			}
			set
			{
				if (value != null)
				{
					SetImageDrawable(value.ToNative());
				}
			}
		}

		public override ColorFilter ColorFilter => colorFilter;

		public CircleImageView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public CircleImageView(Context context)
			: base(context)
		{
			Init();
		}

		public CircleImageView(Context context, IAttributeSet attrs)
			: this(context, attrs, 0)
		{
		}

		public CircleImageView(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.CircleImageView, defStyle, 0);
			try
			{
				borderWidth = typedArray.GetDimensionPixelSize(Resource.Styleable.CircleImageView_civ_border_width, 0);
				borderColor = typedArray.GetColor(Resource.Styleable.CircleImageView_civ_border_color, DefaultBorderColor);
				hasBorderOverlay = typedArray.GetBoolean(Resource.Styleable.CircleImageView_civ_border_overlay, defValue: false);
				fillColor = typedArray.GetColor(Resource.Styleable.CircleImageView_civ_fill_color, DefaultFillColor);
			}
			finally
			{
				typedArray?.Recycle();
			}
			Init();
		}

		private void Init()
		{
			SetScaleType(ScaleType);
			isReady = true;
			if (isSetupPending)
			{
				Setup();
				isSetupPending = false;
			}
		}

		public override ScaleType GetScaleType()
		{
			return ScaleType;
		}

		public override void SetScaleType(ScaleType scaleType)
		{
			if (scaleType != ScaleType)
			{
				throw new ArgumentException($"ScaleType {scaleType} not supported.");
			}
		}

		public override void SetAdjustViewBounds(bool adjustViewBounds)
		{
			if (adjustViewBounds)
			{
				throw new ArgumentException("adjustViewBounds not supported.");
			}
		}

		protected override void OnDraw(Canvas canvas)
		{
			if (disableCircularTransformation)
			{
				base.OnDraw(canvas);
			}
			else if (bitmap != null)
			{
				if (fillColor != (int)Color.Transparent)
				{
					canvas.DrawCircle(drawableRect.CenterX(), drawableRect.CenterY(), drawableRadius, fillPaint);
				}
				canvas.DrawCircle(drawableRect.CenterX(), drawableRect.CenterY(), drawableRadius, bitmapPaint);
				if (borderWidth > 0)
				{
					canvas.DrawCircle(borderRect.CenterX(), borderRect.CenterY(), borderRadius, borderPaint);
				}
			}
		}

		protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged(w, h, oldw, oldh);
			Setup();
		}

		public override void SetPadding(int left, int top, int right, int bottom)
		{
			base.SetPadding(left, top, right, bottom);
			Setup();
		}

		public override void SetPaddingRelative(int start, int top, int end, int bottom)
		{
			base.SetPaddingRelative(start, top, end, bottom);
			Setup();
		}

		public int GetBorderColor()
		{
			return borderColor;
		}

		public void SetBorderColor(int borderColor)
		{
			if (this.borderColor != borderColor)
			{
				this.borderColor = borderColor;
				borderPaint.Color = new Color(borderColor);
				Invalidate();
			}
		}

		public void SetBorderColorResource(int borderColorRes)
		{
			SetBorderColor(base.Context.GetColorIntCompat(borderColorRes));
		}

		public int GetFillColor()
		{
			return fillColor;
		}

		public void SetFillColor(int fillColor)
		{
			if (this.fillColor != fillColor)
			{
				this.fillColor = fillColor;
				fillPaint.Color = new Color(fillColor);
				Invalidate();
			}
		}

		public void SetFillColorResource(int fillColorRes)
		{
			SetFillColor(base.Context.GetColorIntCompat(fillColorRes));
		}

		public int GetBorderWidth()
		{
			return borderWidth;
		}

		public void SetBorderWidth(int borderWidth)
		{
			if (this.borderWidth != borderWidth)
			{
				this.borderWidth = borderWidth;
				Setup();
			}
		}

		public bool IsBorderOverlay()
		{
			return hasBorderOverlay;
		}

		public void SetBorderOverlay(bool borderOverlay)
		{
			if (borderOverlay != hasBorderOverlay)
			{
				hasBorderOverlay = borderOverlay;
				Setup();
			}
		}

		public bool IsDisableCircularTransformation()
		{
			return disableCircularTransformation;
		}

		public void SetDisableCircularTransformation(bool disableCircularTransformation)
		{
			if (this.disableCircularTransformation != disableCircularTransformation)
			{
				this.disableCircularTransformation = disableCircularTransformation;
				InitializeBitmap();
			}
		}

		public override void SetImageBitmap(Bitmap bm)
		{
			base.SetImageBitmap(bm);
			InitializeBitmap();
		}

		public override void SetImageDrawable(Drawable drawable)
		{
			base.SetImageDrawable(drawable);
			InitializeBitmap();
		}

		public override void SetImageResource(int resId)
		{
			base.SetImageResource(resId);
			InitializeBitmap();
		}

		public override void SetImageURI(global::Android.Net.Uri uri)
		{
			base.SetImageURI(uri);
			InitializeBitmap();
		}

		public override void SetColorFilter(ColorFilter cf)
		{
			if (cf != colorFilter)
			{
				colorFilter = cf;
				ApplyColorFilter();
				Invalidate();
			}
		}

		private void ApplyColorFilter()
		{
			if (bitmapPaint != null)
			{
				bitmapPaint.SetColorFilter(colorFilter);
			}
		}

		private Bitmap GetBitmapFromDrawable(Drawable drawable)
		{
			if (drawable == null)
			{
				return null;
			}
			if (drawable is BitmapDrawable)
			{
				return ((BitmapDrawable)drawable).Bitmap;
			}
			try
			{
				Bitmap bitmap = ((!(drawable is ColorDrawable)) ? Bitmap.CreateBitmap(drawable.IntrinsicWidth, drawable.IntrinsicHeight, BitmapConfig) : Bitmap.CreateBitmap(2, 2, BitmapConfig));
				Canvas canvas = new Canvas(bitmap);
				drawable.SetBounds(0, 0, canvas.Width, canvas.Height);
				drawable.Draw(canvas);
				return this.bitmap;
			}
			catch (System.Exception ex)
			{
				global::Android.Util.Log.Error("CircleImageView", "Failed to draw CircleImageView", ex);
				return null;
			}
		}

		private void InitializeBitmap()
		{
			if (disableCircularTransformation)
			{
				bitmap = null;
			}
			else
			{
				bitmap = GetBitmapFromDrawable(Drawable);
			}
			Setup();
		}

		private void Setup()
		{
			if (!isReady)
			{
				isSetupPending = true;
			}
			else
			{
				if (base.Width == 0 && base.Height == 0)
				{
					return;
				}
				if (bitmap == null)
				{
					Invalidate();
					return;
				}
				bitmapShader = new BitmapShader(bitmap, Shader.TileMode.Clamp, Shader.TileMode.Clamp);
				bitmapPaint.AntiAlias = true;
				bitmapPaint.SetShader(bitmapShader);
				borderPaint.SetStyle(Paint.Style.Stroke);
				borderPaint.AntiAlias = true;
				borderPaint.Color = new Color(borderColor);
				borderPaint.StrokeWidth = borderWidth;
				fillPaint.SetStyle(Paint.Style.Fill);
				fillPaint.AntiAlias = true;
				fillPaint.Color = new Color(fillColor);
				bitmapHeight = bitmap.Height;
				bitmapWidth = bitmap.Width;
				borderRect.Set(CalculateBounds());
				borderRadius = System.Math.Min((borderRect.Height() - (float)borderWidth) / 2f, (borderRect.Width() - (float)borderWidth) / 2f);
				drawableRect.Set(borderRect);
				if (!hasBorderOverlay && borderWidth > 0)
				{
					drawableRect.Inset((float)borderWidth - 1f, (float)borderWidth - 1f);
				}
				drawableRadius = System.Math.Min(drawableRect.Height() / 2f, drawableRect.Width() / 2f);
				ApplyColorFilter();
				UpdateShaderMatrix();
				Invalidate();
			}
		}

		private RectF CalculateBounds()
		{
			int num = base.Width - PaddingLeft - PaddingRight;
			int num2 = base.Height - PaddingTop - PaddingBottom;
			int num3 = System.Math.Min(num, num2);
			float num4 = (float)PaddingLeft + (float)(num - num3) / 2f;
			float num5 = (float)PaddingTop + (float)(num2 - num3) / 2f;
			return new RectF(num4, num5, num4 + (float)num3, num5 + (float)num3);
		}

		private void UpdateShaderMatrix()
		{
			float num = 0f;
			float num2 = 0f;
			shaderMatrix.Set(null);
			float num3;
			if ((float)bitmapWidth * drawableRect.Height() > drawableRect.Width() * (float)bitmapHeight)
			{
				num3 = drawableRect.Height() / (float)bitmapHeight;
				num = (drawableRect.Width() - (float)bitmapWidth * num3) * 0.5f;
			}
			else
			{
				num3 = drawableRect.Width() / (float)bitmapWidth;
				num2 = (drawableRect.Height() - (float)bitmapHeight * num3) * 0.5f;
			}
			shaderMatrix.SetScale(num3, num3);
			shaderMatrix.PostTranslate((float)(int)(num + 0.5f) + drawableRect.Left, (float)(int)(num2 + 0.5f) + drawableRect.Top);
			bitmapShader.SetLocalMatrix(shaderMatrix);
		}
	}
	public class CircularLoadingView : View
	{
		private float backgroundRotation;

		private float backgroundSweepAngle;

		private float foregroundRotation;

		private float foregroundSweepAngle;

		private RectF ovalSpace;

		private bool autoPlay = true;

		private bool singleColorMode;

		private Color? foregroundRingColor;

		private Color? backgroundRingColor;

		private Paint backgroundPaint;

		private Paint foregroundPaint;

		private ValueAnimator backgroundAnimator;

		private ValueAnimator foregroundAnimator;

		public bool AutoPlay
		{
			get
			{
				return autoPlay;
			}
			set
			{
				autoPlay = value;
			}
		}

		public bool SingleColorMode
		{
			get
			{
				return singleColorMode;
			}
			set
			{
				singleColorMode = value;
			}
		}

		public Color? ForegroundRingColor
		{
			get
			{
				return foregroundRingColor;
			}
			set
			{
				foregroundRingColor = value;
				if (foregroundPaint != null && foregroundRingColor.HasValue)
				{
					foregroundPaint.Color = foregroundRingColor.Value;
				}
			}
		}

		public Color? BackgroundRingColor
		{
			get
			{
				return backgroundRingColor;
			}
			set
			{
				backgroundRingColor = value;
				if (backgroundPaint != null && backgroundRingColor.HasValue)
				{
					backgroundPaint.Color = backgroundRingColor.Value;
				}
			}
		}

		private float lineThickness => (float)System.Math.Min(base.Width, base.Height) / 8f;

		private long duration => 1500L;

		public override ViewStates Visibility
		{
			get
			{
				return base.Visibility;
			}
			set
			{
				base.Visibility = value;
				if (value == ViewStates.Gone || value == ViewStates.Invisible)
				{
					Stop();
				}
				else if (autoPlay)
				{
					Play();
				}
			}
		}

		protected CircularLoadingView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public CircularLoadingView(Context context)
			: base(context)
		{
			Init(context, null);
		}

		public CircularLoadingView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Init(context, attrs);
		}

		public CircularLoadingView(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(context, attrs, defStyleAttr)
		{
			Init(context, attrs);
		}

		public CircularLoadingView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
			: base(context, attrs, defStyleAttr, defStyleRes)
		{
			Init(context, attrs);
		}

		private void Init(Context context, IAttributeSet attrs)
		{
			if (attrs != null)
			{
				TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.CircularLoadingView);
				try
				{
					foregroundRingColor = typedArray.GetColor(Resource.Styleable.CircularLoadingView_foregroundRingColor, context.GetColorCompat(Resource.Color.default_foreground_ring_color));
					backgroundRingColor = typedArray.GetColor(Resource.Styleable.CircularLoadingView_backgroundRingColor, context.GetColorCompat(Resource.Color.default_background_ring_color));
					singleColorMode = typedArray.GetBoolean(Resource.Styleable.CircularLoadingView_singleColorMode, defValue: false);
					autoPlay = typedArray.GetBoolean(Resource.Styleable.CircularLoadingView_autoPlay, defValue: true);
				}
				finally
				{
					typedArray?.Recycle();
				}
			}
			if (!foregroundRingColor.HasValue)
			{
				foregroundRingColor = context.GetColorCompat(Resource.Color.default_foreground_ring_color);
			}
			if (!backgroundRingColor.HasValue)
			{
				backgroundRingColor = context.GetColorCompat(Resource.Color.default_background_ring_color);
			}
			ovalSpace = new RectF();
			backgroundPaint = new Paint
			{
				StrokeCap = Paint.Cap.Round,
				StrokeWidth = lineThickness,
				AntiAlias = true,
				Color = backgroundRingColor.Value
			};
			backgroundPaint.SetStyle(Paint.Style.Stroke);
			foregroundPaint = new Paint
			{
				StrokeCap = Paint.Cap.Round,
				StrokeWidth = lineThickness,
				AntiAlias = true,
				Color = foregroundRingColor.Value
			};
			foregroundPaint.SetStyle(Paint.Style.Stroke);
			Background = null;
			if (AutoPlay && Visibility == ViewStates.Visible)
			{
				Play();
			}
		}

		protected override void OnDraw(Canvas canvas)
		{
			ovalSpace.Set(lineThickness, lineThickness, (float)base.Width - lineThickness, (float)base.Height - lineThickness);
			foregroundPaint.StrokeWidth = lineThickness;
			backgroundPaint.StrokeWidth = lineThickness;
			if (!SingleColorMode)
			{
				canvas.DrawArc(ovalSpace, backgroundRotation, backgroundSweepAngle, useCenter: false, backgroundPaint);
			}
			canvas.DrawArc(ovalSpace, foregroundRotation, foregroundSweepAngle, useCenter: false, foregroundPaint);
		}

		public void Play()
		{
			DisposeAnimations();
			if (!SingleColorMode)
			{
				CreateBackRingAnimation();
			}
			CreateFrontRingAnimation();
		}

		public void Stop()
		{
			DisposeAnimations();
		}

		private void CreateBackRingAnimation()
		{
			PropertyValuesHolder propertyValuesHolder = PropertyValuesHolder.OfFloat("sweepAngle", 0f, -65f, -130f, -195f, -270f, -270f, 0f);
			PropertyValuesHolder propertyValuesHolder2 = PropertyValuesHolder.OfFloat("rotation", 270f, 630f, 990f);
			ValueAnimator valueAnimator = new ValueAnimator();
			valueAnimator.SetValues(propertyValuesHolder, propertyValuesHolder2);
			valueAnimator.SetDuration(duration);
			valueAnimator.SetInterpolator(new LinearInterpolator());
			valueAnimator.RepeatCount = -1;
			valueAnimator.Update += BackgroundAnimatorOnUpdate;
			valueAnimator.Start();
			backgroundAnimator = valueAnimator;
		}

		private void CreateFrontRingAnimation()
		{
			PropertyValuesHolder propertyValuesHolder = PropertyValuesHolder.OfFloat("sweepAngle", 0f, -130f, -270f, 0f);
			PropertyValuesHolder propertyValuesHolder2 = PropertyValuesHolder.OfFloat("rotation", 270f, 630f, 990f);
			ValueAnimator valueAnimator = new ValueAnimator();
			valueAnimator.SetValues(propertyValuesHolder, propertyValuesHolder2);
			valueAnimator.SetDuration(duration);
			valueAnimator.SetInterpolator(new LinearInterpolator());
			valueAnimator.RepeatCount = -1;
			valueAnimator.Update += ForegroundAnimatorOnUpdate;
			valueAnimator.Start();
			foregroundAnimator = valueAnimator;
		}

		private void BackgroundAnimatorOnUpdate(object sender, ValueAnimator.AnimatorUpdateEventArgs e)
		{
			if (e?.Animation != null)
			{
				backgroundSweepAngle = (float)(e.Animation.GetAnimatedValue("sweepAngle") ?? ((Java.Lang.Object)0));
				backgroundRotation = (float)(e.Animation.GetAnimatedValue("rotation") ?? ((Java.Lang.Object)0));
			}
		}

		private void ForegroundAnimatorOnUpdate(object sender, ValueAnimator.AnimatorUpdateEventArgs e)
		{
			if (e?.Animation != null)
			{
				foregroundSweepAngle = (float)(e.Animation.GetAnimatedValue("sweepAngle") ?? ((Java.Lang.Object)0));
				foregroundRotation = (float)(e.Animation.GetAnimatedValue("rotation") ?? ((Java.Lang.Object)0));
				PostInvalidateOnAnimation();
			}
		}

		private void DisposeAnimations()
		{
			if (backgroundAnimator != null)
			{
				backgroundAnimator.Update -= BackgroundAnimatorOnUpdate;
				backgroundAnimator.Dispose();
				backgroundAnimator = null;
			}
			if (foregroundAnimator != null)
			{
				foregroundAnimator.Update -= ForegroundAnimatorOnUpdate;
				foregroundAnimator.Dispose();
				foregroundAnimator = null;
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				backgroundPaint?.Dispose();
				backgroundPaint = backgroundPaint?.DisposeSafe();
				foregroundPaint = foregroundPaint?.DisposeSafe();
				DisposeAnimations();
			}
		}
	}
	public abstract class BaseTile : CardView, IMvxBindingContextOwner
	{
		protected new const string Tag = "Tile";

		protected View nonpremiumOverlay;

		protected BetterImageView background;

		private string _backgroundUrl;

		private string _workoutTileCategory;

		private int backgroundResourceId = Resource.Id.none;

		private string _backgroundResourceName;

		private int errorBackgroundResourceId = Resource.Id.none;

		private string _errorBackgroundResourceName;

		public IMvxBindingContext BindingContext { get; set; }

		public string BackgroundUrl
		{
			get
			{
				return _backgroundUrl;
			}
			set
			{
				_backgroundUrl = value;
				iFit.Logger.Log.Trace("Tile", "Loading Dashboard tile image from " + _backgroundUrl);
				background.ImageUrl = _backgroundUrl;
			}
		}

		public string WorkoutTileCategory
		{
			get
			{
				return _workoutTileCategory;
			}
			set
			{
				_workoutTileCategory = value;
				base.ContentDescription = _workoutTileCategory;
			}
		}

		public string BackgroundResourceName
		{
			get
			{
				return _backgroundResourceName;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					_backgroundResourceName = value;
					backgroundResourceId = Shire.Android.Util.ImageUtil.GetImageResourceFromName(base.Context, _backgroundResourceName);
					background.ResourceId = backgroundResourceId;
				}
			}
		}

		public string ErrorBackgroundResourceName
		{
			get
			{
				return _errorBackgroundResourceName;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					_errorBackgroundResourceName = value;
					errorBackgroundResourceId = Shire.Android.Util.ImageUtil.GetImageResourceFromName(base.Context, _errorBackgroundResourceName);
					background.ErrorResourceId = errorBackgroundResourceId;
				}
			}
		}

		public bool NonPremium
		{
			get
			{
				return nonpremiumOverlay.Visibility == ViewStates.Visible;
			}
			set
			{
				if (nonpremiumOverlay != null)
				{
					nonpremiumOverlay.Visibility = ((!value) ? ViewStates.Gone : ViewStates.Visible);
				}
			}
		}

		public virtual void PrepareForOffscreen()
		{
			background.ImageUrl = null;
			background.ResourceId = Resource.Id.none;
		}

		public virtual void PrepareForOnscreen()
		{
			if (backgroundResourceId != Resource.Id.none)
			{
				background.ResourceId = backgroundResourceId;
			}
			if (_backgroundUrl != null)
			{
				background.ImageUrl = _backgroundUrl;
			}
		}

		public BaseTile(Context context)
			: base(context)
		{
			Initialize();
		}

		public BaseTile(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Initialize();
		}

		protected BaseTile(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Initialize();
		}

		private void Initialize()
		{
			this.CreateBindingContext();
			SetBackgroundColor(base.Context.GetColorCompat(Resource.Color.dashboard_tile_background));
		}

		protected override void OnDetachedFromWindow()
		{
			base.OnDetachedFromWindow();
			Dispose(disposing: true);
		}

		protected override void Dispose(bool disposing)
		{
			nonpremiumOverlay?.Dispose();
			background?.Dispose();
			base.Dispose(disposing);
		}
	}
	public class DashboardTile : BaseTile
	{
		private TextView tileType;

		private TextView tileTitle;

		private TextView calorieValue;

		private TextView calorieUnit;

		private ImageView calorieIcon;

		private TextView timeValue;

		private ImageView timeIcon;

		private TextView distanceValue;

		private TextView distanceUnit;

		private ImageView distanceIcon;

		private IfitButton startButton;

		private LinearLayout timeLayout;

		public LinearLayout DashboardMetricsContainer { get; private set; }

		public string Type
		{
			get
			{
				return tileType.Text;
			}
			set
			{
				tileType.Text = value;
			}
		}

		public Color TypeColor
		{
			get
			{
				return default(Color);
			}
			set
			{
				tileType.SetTextColor(value);
			}
		}

		public string Title
		{
			get
			{
				return tileTitle.Text;
			}
			set
			{
				tileTitle.Text = value;
			}
		}

		public Color TitleColor
		{
			get
			{
				return default(Color);
			}
			set
			{
				tileTitle.SetTextColor(value);
			}
		}

		public string Calories
		{
			get
			{
				return calorieValue.Text;
			}
			set
			{
				calorieValue.Text = value;
			}
		}

		public string CalorieUnit
		{
			get
			{
				return calorieUnit.Text;
			}
			set
			{
				calorieUnit.Text = value;
			}
		}

		public string Time
		{
			get
			{
				return timeValue.Text;
			}
			set
			{
				timeValue.Text = value;
			}
		}

		public string Distance
		{
			get
			{
				return distanceValue.Text;
			}
			set
			{
				distanceValue.Text = value;
			}
		}

		public string DistanceUnit
		{
			get
			{
				return distanceUnit.Text;
			}
			set
			{
				distanceUnit.Text = value;
			}
		}

		public string StartButton
		{
			get
			{
				return startButton.Text;
			}
			set
			{
				startButton.Text = value;
			}
		}

		public Button Start => startButton;

		public bool LargeTile
		{
			get
			{
				return startButton.Visibility == ViewStates.Visible;
			}
			set
			{
				bool flag = value;
				startButton.Visibility = ((!flag) ? ViewStates.Gone : ViewStates.Visible);
				ViewStates viewStates = ((!Resources.GetBoolean(Resource.Boolean.dashboard_time_stat_visible)) ? ViewStates.Gone : ViewStates.Visible);
				timeLayout.Visibility = ((!flag) ? viewStates : ViewStates.Visible);
				int id = (flag ? Resource.Dimension.dashboard_tile_title_text : Resource.Dimension.dashboard_tile_title_text_small);
				int id2 = (flag ? Resource.Dimension.dashboard_tile_wotd_type_size : Resource.Dimension.dashboard_tile_workout_type_size);
				int id3 = (flag ? Resource.Dimension.dashboard_tile_metric_value_text : Resource.Dimension.dashboard_tile_metric_value_text_small);
				int id4 = (flag ? Resource.Dimension.dashboard_tile_metric_unit_text : Resource.Dimension.dashboard_tile_metric_unit_text_small);
				float dimension = Resources.GetDimension(id);
				float dimension2 = Resources.GetDimension(id2);
				float dimension3 = Resources.GetDimension(id3);
				float dimension4 = Resources.GetDimension(id4);
				tileTitle.SetTextSize(ComplexUnitType.Fraction, dimension);
				tileType.SetTextSize(ComplexUnitType.Fraction, dimension2);
				TextView[] array = new TextView[3] { calorieValue, timeValue, distanceValue };
				TextView[] array2 = array;
				foreach (TextView textView in array2)
				{
					textView.SetTextSize(ComplexUnitType.Fraction, dimension3);
				}
				TextView[] array3 = new TextView[2] { calorieUnit, distanceUnit };
				TextView[] array4 = array3;
				foreach (TextView textView2 in array4)
				{
					textView2.SetTextSize(ComplexUnitType.Fraction, dimension4);
				}
				calorieIcon.LayoutParameters = GetIconLayoutParameters(flag);
				timeIcon.LayoutParameters = GetIconLayoutParameters(flag);
				distanceIcon.LayoutParameters = GetIconLayoutParameters(flag);
			}
		}

		private LinearLayout.LayoutParams GetIconLayoutParameters(bool isLarge)
		{
			int dimensionPixelSize = Resources.GetDimensionPixelSize(isLarge ? Resource.Dimension.dashboard_tile_metric_icon : Resource.Dimension.dashboard_tile_metric_icon_small);
			return new LinearLayout.LayoutParams(dimensionPixelSize, dimensionPixelSize)
			{
				Gravity = GravityFlags.Center
			};
		}

		public DashboardTile(Context context)
			: base(context)
		{
			Initialize(context);
		}

		public DashboardTile(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Initialize(context);
		}

		public DashboardTile(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Initialize(context);
		}

		private void Initialize(Context context)
		{
			View view = LayoutInflater.From(context).Inflate(Resource.Layout.DashboardTile, this, attachToRoot: true);
			nonpremiumOverlay = view.FindViewById<View>(Resource.Id.dashboard_tile_nonpremium_overlay);
			background = view.FindViewById<BetterImageView>(Resource.Id.dashboard_tile_background);
			tileType = view.FindViewById<TextView>(Resource.Id.dashboard_tile_type);
			tileTitle = view.FindViewById<TextView>(Resource.Id.dashboard_tile_title);
			calorieValue = view.FindViewById<TextView>(Resource.Id.dashboard_tile_calorie_value);
			calorieUnit = view.FindViewById<TextView>(Resource.Id.dashboard_tile_calorie_unit);
			calorieIcon = view.FindViewById<ImageView>(Resource.Id.dashboard_tile_calorie_icon);
			timeValue = view.FindViewById<TextView>(Resource.Id.dashboard_tile_time_value);
			timeIcon = view.FindViewById<ImageView>(Resource.Id.dashboard_tile_time_icon);
			distanceValue = view.FindViewById<TextView>(Resource.Id.dashboard_tile_distance_value);
			distanceUnit = view.FindViewById<TextView>(Resource.Id.dashboard_tile_distance_unit);
			distanceIcon = view.FindViewById<ImageView>(Resource.Id.dashboard_tile_distance_icon);
			startButton = view.FindViewById<IfitButton>(Resource.Id.dashboard_tile_start_button);
			timeLayout = view.FindViewById<LinearLayout>(Resource.Id.dashboard_time_container);
			DashboardMetricsContainer = view.FindViewById<LinearLayout>(Resource.Id.dashboard_tile_metrics);
			LargeTile = false;
		}

		protected override void OnDetachedFromWindow()
		{
			base.OnDetachedFromWindow();
			Dispose(disposing: true);
		}

		protected override void Dispose(bool disposing)
		{
			tileType?.Dispose();
			tileTitle?.Dispose();
			calorieValue?.Dispose();
			calorieUnit?.Dispose();
			calorieIcon?.Dispose();
			timeValue?.Dispose();
			timeIcon?.Dispose();
			distanceValue?.Dispose();
			distanceUnit?.Dispose();
			distanceIcon?.Dispose();
			startButton?.Dispose();
			base.Dispose(disposing);
		}
	}
	public class FavoritesTile : BaseTile
	{
		private IfitTextView title;

		private IfitTextView description;

		public string Title
		{
			get
			{
				return title.Text;
			}
			set
			{
				title.Text = value;
			}
		}

		public string Description
		{
			get
			{
				return description.Text;
			}
			set
			{
				description.Text = value;
			}
		}

		public FavoritesTile(Context context)
			: base(context)
		{
			Initialize(context);
		}

		public FavoritesTile(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Initialize(context);
		}

		public FavoritesTile(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Initialize(context);
		}

		private void Initialize(Context context)
		{
			View view = LayoutInflater.From(context).Inflate(Resource.Layout.FavoritesTile, this, attachToRoot: true);
			nonpremiumOverlay = view.FindViewById<View>(Resource.Id.favorites_tile_nonpremium_overlay);
			background = view.FindViewById<BetterImageView>(Resource.Id.favorites_tile_background);
			title = view.FindViewById<IfitTextView>(Resource.Id.favorites_tile_title);
			description = view.FindViewById<IfitTextView>(Resource.Id.favorites_tile_description);
			base.BindingContext = new MvxAndroidBindingContext(base.Context, (IMvxLayoutInflaterHolder)base.Context);
		}

		protected override void Dispose(bool disposing)
		{
			title?.Dispose();
			description?.Dispose();
			base.Dispose(disposing);
		}
	}
	public class LibraryTile : BaseTile
	{
		private TextView title;

		private TextView description;

		public string Title
		{
			get
			{
				return title.Text;
			}
			set
			{
				title.Text = value;
			}
		}

		public string Description
		{
			get
			{
				return description.Text;
			}
			set
			{
				description.Text = value;
			}
		}

		public Typeface TitleFont
		{
			set
			{
				title.SetTypeface(value, TypefaceStyle.Normal);
			}
		}

		public Typeface DescriptionFont
		{
			set
			{
				description.SetTypeface(value, TypefaceStyle.Normal);
			}
		}

		public LibraryTile(Context context)
			: base(context)
		{
			Initialize(context);
		}

		public LibraryTile(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Initialize(context);
		}

		public LibraryTile(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Initialize(context);
		}

		private void Initialize(Context context)
		{
			View view = LayoutInflater.From(context).Inflate(Resource.Layout.LibraryTile, this, attachToRoot: true);
			nonpremiumOverlay = view.FindViewById<View>(Resource.Id.library_tile_nonpremium_overlay);
			background = view.FindViewById<BetterImageView>(Resource.Id.library_tile_background);
			title = view.FindViewById<TextView>(Resource.Id.library_tile_title);
			description = view.FindViewById<TextView>(Resource.Id.library_tile_description);
			base.BindingContext = new MvxAndroidBindingContext(base.Context, (IMvxLayoutInflaterHolder)base.Context);
		}
	}
	public class ManualWorkoutTile : BaseTile
	{
		public IfitTextView manualLabel;

		public IfitTextView startLabel;

		public LinearLayout TextContainer { get; set; }

		public string ManualText
		{
			get
			{
				return manualLabel.Text;
			}
			set
			{
				manualLabel.Text = value;
			}
		}

		public string StartText
		{
			get
			{
				return startLabel.Text;
			}
			set
			{
				startLabel.Text = value;
			}
		}

		public Color TitleColor
		{
			get
			{
				return default(Color);
			}
			set
			{
				manualLabel.SetTextColor(value);
				startLabel.SetTextColor(value);
			}
		}

		public ManualWorkoutTile(Context context)
			: base(context)
		{
			Initialize(context);
		}

		public ManualWorkoutTile(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Initialize(context);
		}

		public ManualWorkoutTile(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Initialize(context);
		}

		private void Initialize(Context context)
		{
			View view = LayoutInflater.From(context).Inflate(Resource.Layout.ManualWorkoutTile, this, attachToRoot: true);
			background = view.FindViewById<BetterImageView>(Resource.Id.dashboard_tile_background);
			manualLabel = view.FindViewById<IfitTextView>(Resource.Id.dashboard_manual_label);
			startLabel = view.FindViewById<IfitTextView>(Resource.Id.dashboard_start_label);
			TextContainer = view.FindViewById<LinearLayout>(Resource.Id.manual_text_container);
		}

		protected override void Dispose(bool disposing)
		{
			manualLabel?.Dispose();
			startLabel?.Dispose();
			TextContainer?.Dispose();
			base.Dispose(disposing);
		}
	}
	public class MapTile : BaseTile
	{
		private TextView title;

		private TextView description;

		private IfitButton startButton;

		public string Title
		{
			get
			{
				return title.Text;
			}
			set
			{
				title.Text = value;
			}
		}

		public string Description
		{
			get
			{
				return description.Text;
			}
			set
			{
				description.Text = value;
			}
		}

		public string ButtonText
		{
			get
			{
				return startButton.Text;
			}
			set
			{
				startButton.Text = value;
			}
		}

		public Button Start => startButton;

		public MapTile(Context context)
			: base(context)
		{
			Initialize(context);
		}

		public MapTile(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Initialize(context);
		}

		public MapTile(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Initialize(context);
		}

		private void Initialize(Context context)
		{
			View view = LayoutInflater.From(context).Inflate(Resource.Layout.MapTile, this, attachToRoot: true);
			background = view.FindViewById<BetterImageView>(Resource.Id.map_tile_background);
			title = view.FindViewById<IfitTextView>(Resource.Id.map_tile_title);
			description = view.FindViewById<IfitTextView>(Resource.Id.map_tile_description);
			startButton = view.FindViewById<IfitButton>(Resource.Id.map_tile_start_button);
		}

		protected override void Dispose(bool disposing)
		{
			title?.Dispose();
			description?.Dispose();
			startButton?.Dispose();
			base.Dispose(disposing);
		}
	}
	public class ProgramTile : BaseTile
	{
		private TextView tileType;

		private TextView tileTitle;

		public string Type
		{
			get
			{
				return tileType.Text;
			}
			set
			{
				tileType.Text = value;
			}
		}

		public Color TypeColor
		{
			get
			{
				return default(Color);
			}
			set
			{
				tileType.SetTextColor(value);
			}
		}

		public string Title
		{
			get
			{
				return tileTitle.Text;
			}
			set
			{
				tileTitle.Text = value;
			}
		}

		public Color TitleColor
		{
			get
			{
				return default(Color);
			}
			set
			{
				tileTitle.SetTextColor(value);
			}
		}

		public bool LargeTile
		{
			get
			{
				return false;
			}
			set
			{
				bool flag = value;
				int id = (flag ? Resource.Dimension.dashboard_tile_title_text : Resource.Dimension.dashboard_tile_title_text_small);
				int id2 = (flag ? Resource.Dimension.dashboard_tile_wotd_type_size : Resource.Dimension.dashboard_tile_workout_type_size);
				float dimension = Resources.GetDimension(id);
				float dimension2 = Resources.GetDimension(id2);
				tileTitle.SetTextSize(ComplexUnitType.Fraction, dimension);
				tileType.SetTextSize(ComplexUnitType.Fraction, dimension2);
			}
		}

		public ProgramTile(Context context)
			: base(context)
		{
			Initialize(context);
		}

		public ProgramTile(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Initialize(context);
		}

		public ProgramTile(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Initialize(context);
		}

		private void Initialize(Context context)
		{
			View view = LayoutInflater.From(context).Inflate(Resource.Layout.DashboardTile, this, attachToRoot: true);
			nonpremiumOverlay = view.FindViewById<View>(Resource.Id.dashboard_tile_nonpremium_overlay);
			background = view.FindViewById<BetterImageView>(Resource.Id.dashboard_tile_background);
			tileType = view.FindViewById<TextView>(Resource.Id.dashboard_tile_type);
			tileTitle = view.FindViewById<TextView>(Resource.Id.dashboard_tile_title);
			view.FindViewById<LinearLayout>(Resource.Id.dashboard_tile_metrics).Visibility = ViewStates.Gone;
			view.FindViewById<Button>(Resource.Id.dashboard_tile_start_button).Visibility = ViewStates.Gone;
			LargeTile = false;
		}

		protected override void Dispose(bool disposing)
		{
			tileType?.Dispose();
			tileTitle?.Dispose();
			base.Dispose(disposing);
		}
	}
	public class FixedMvxListView : MvxListView
	{
		public FixedMvxListView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		public FixedMvxListView(Context context, IAttributeSet attrs, IMvxAdapter adapter)
			: base(context, attrs, adapter)
		{
		}

		protected FixedMvxListView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			int heightMeasureSpec2 = MeasureSpec.MakeMeasureSpec(536870911, MeasureSpecMode.AtMost);
			base.OnMeasure(widthMeasureSpec, heightMeasureSpec2);
			LayoutParams layoutParameters = LayoutParameters;
			layoutParameters.Height = base.MeasuredHeight;
		}
	}
	public interface IControlLifeCycle
	{
		void OnCreate(Bundle bundle);

		void OnResume();

		void OnPause();

		void OnLowMemory();

		void OnDestroy();

		void OnSaveInstanceState(Bundle outState);

		void OnTrimMemory(TrimMemory level);
	}
	public class IfitButton : AppCompatButton
	{
		public IfitButton(IntPtr ptr, JniHandleOwnership transfer)
			: base(ptr, transfer)
		{
		}

		public IfitButton(Context context)
			: base(context)
		{
			ApplyAttributes(context);
		}

		public IfitButton(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			ApplyAttributes(context, attrs);
		}

		public IfitButton(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			ApplyAttributes(context, attrs);
		}

		public void ApplyAttributes(Context context, IAttributeSet attrs = null)
		{
			Typeface customTypeface = IfitTypeface.GetCustomTypeface(IfitTypeface.Type.ProximaRegular);
			if (context != null && attrs != null)
			{
				TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.IfitButton);
				IfitTypeface.Type ifitTypeFace = (IfitTypeface.Type)typedArray.GetInt(Resource.Styleable.IfitButton_typeface, 0);
				customTypeface = ifitTypeFace.GetTypeface();
				typedArray.Recycle();
			}
			SetCustomTypeface(customTypeface);
		}

		public void SetCustomTypeface(Typeface typeface)
		{
			if (!IsInEditMode)
			{
				SetTypeface(typeface, TypefaceStyle.Normal);
			}
		}
	}
	public class IfitEditTextView : AppCompatEditText
	{
		public IfitEditTextView(IntPtr ptr, JniHandleOwnership transfer)
			: base(ptr, transfer)
		{
		}

		public IfitEditTextView(Context context)
			: base(context)
		{
			ApplyAttributes(context);
		}

		public IfitEditTextView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			ApplyAttributes(context, attrs);
		}

		public IfitEditTextView(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			ApplyAttributes(context, attrs);
		}

		public void ApplyAttributes(Context context, IAttributeSet attrs = null)
		{
			Typeface customTypeface = IfitTypeface.GetCustomTypeface(IfitTypeface.Type.ProximaRegular);
			if (context != null && attrs != null)
			{
				TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.IfitEditTextView);
				IfitTypeface.Type ifitTypeFace = (IfitTypeface.Type)typedArray.GetInt(Resource.Styleable.IfitEditTextView_typeface, 0);
				customTypeface = ifitTypeFace.GetTypeface();
				typedArray.Recycle();
			}
			SetCustomTypeface(customTypeface);
		}

		public void SetCustomTypeface(Typeface typeface)
		{
			if (!IsInEditMode)
			{
				SetTypeface(typeface, TypefaceStyle.Normal);
			}
		}
	}
	public class IfitImageButton : ImageButton
	{
		private int _imageResource;

		public int ImageResource
		{
			get
			{
				return _imageResource;
			}
			set
			{
				SetImageResource(value);
			}
		}

		public IfitImageButton(IntPtr ptr, JniHandleOwnership transfer)
			: base(ptr, transfer)
		{
		}

		public IfitImageButton(Context context)
			: base(context)
		{
		}

		public IfitImageButton(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		public IfitImageButton(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
		}

		public override void SetImageResource(int resId)
		{
			_imageResource = resId;
			base.SetImageResource(resId);
		}
	}
	public class IfitTextInputLayout : TextInputLayout
	{
		private class IfitTextInputEditText : IfitEditTextView
		{
			public IfitTextInputEditText(IntPtr ptr, JniHandleOwnership transfer)
				: base(ptr, transfer)
			{
			}

			public IfitTextInputEditText(Context context, IAttributeSet attrs)
				: base(context, attrs)
			{
			}

			public override IInputConnection OnCreateInputConnection(EditorInfo outAttrs)
			{
				IInputConnection inputConnection = base.OnCreateInputConnection(outAttrs);
				if (inputConnection != null && outAttrs.HintText == null)
				{
					IViewParent parent = base.Parent;
					while (parent is View)
					{
						if (parent is TextInputLayout)
						{
							outAttrs.HintText = new Java.Lang.String((parent as TextInputLayout).Hint);
							break;
						}
						parent = parent.Parent;
					}
				}
				return inputConnection;
			}
		}

		public IfitTextInputLayout(IntPtr ptr, JniHandleOwnership transfer)
			: base(ptr, transfer)
		{
		}

		public IfitTextInputLayout(Context context)
			: base(context)
		{
			Init(context, null);
		}

		public IfitTextInputLayout(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Init(context, attrs);
		}

		public IfitTextInputLayout(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Init(context, attrs);
		}

		private void Init(Context context, IAttributeSet attrs)
		{
			AddView(new IfitTextInputEditText(context, attrs));
		}
	}
	public class IfitTextView : TextView
	{
		public ICharSequence SpannableText
		{
			get
			{
				return base.TextFormatted;
			}
			set
			{
				Post(delegate
				{
					SetText(value, BufferType.Spannable);
				});
			}
		}

		public IfitTextView(IntPtr ptr, JniHandleOwnership transfer)
			: base(ptr, transfer)
		{
		}

		public IfitTextView(Context context)
			: base(context)
		{
			ApplyAttributes(context);
		}

		public IfitTextView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			ApplyAttributes(context, attrs);
		}

		public IfitTextView(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			ApplyAttributes(context, attrs);
		}

		public void ApplyAttributes(Context context, IAttributeSet attrs = null)
		{
			Typeface customTypeface = IfitTypeface.GetCustomTypeface(IfitTypeface.Type.ProximaRegular);
			if (context != null && attrs != null)
			{
				TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.IfitTextView);
				IfitTypeface.Type ifitTypeFace = (IfitTypeface.Type)typedArray.GetInt(Resource.Styleable.IfitTextView_typeface, 0);
				customTypeface = ifitTypeFace.GetTypeface();
				typedArray.Recycle();
			}
			if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
			{
				SetAutoSizeTextTypeWithDefaults(AutoSizeTextType.None);
			}
			SetCustomTypeface(customTypeface);
		}

		public void SetCustomTypeface(Typeface typeface)
		{
			if (!IsInEditMode)
			{
				SetTypeface(typeface, TypefaceStyle.Normal);
			}
		}
	}
	public class LoadingIndicatorDot : View
	{
		public LoadingIndicatorDot(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public LoadingIndicatorDot(Context context)
			: base(context)
		{
			Initialize(null);
		}

		public LoadingIndicatorDot(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Initialize(attrs);
		}

		public LoadingIndicatorDot(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Initialize(attrs);
		}

		private void Initialize(IAttributeSet attrs)
		{
			if (attrs != null)
			{
				TypedArray typedArray = base.Context.ObtainStyledAttributes(attrs, Resource.Styleable.LoadingIndicatorDot);
				int resourceId = typedArray.GetResourceId(Resource.Styleable.LoadingIndicatorDot_dotTint, Resource.Color.loading_upper_left);
				Color colorCompat = base.Context.GetColorCompat(resourceId);
				SetColor(colorCompat);
			}
		}

		public void SetColor(int color)
		{
			Background.SetColorFilter(new Color(color), PorterDuff.Mode.Multiply);
		}

		[Export]
		public float getLeftMarginPercent()
		{
			PercentRelativeLayout.LayoutParams layoutParams = (PercentRelativeLayout.LayoutParams)LayoutParameters;
			return layoutParams.PercentLayoutInfo.LeftMarginPercent;
		}

		[Export]
		public void setLeftMarginPercent(float marginPercent)
		{
			PercentRelativeLayout.LayoutParams layoutParams = (PercentRelativeLayout.LayoutParams)LayoutParameters;
			layoutParams.PercentLayoutInfo.LeftMarginPercent = marginPercent;
			RequestLayout();
		}

		[Export]
		public float getTopMarginPercent()
		{
			PercentRelativeLayout.LayoutParams layoutParams = (PercentRelativeLayout.LayoutParams)LayoutParameters;
			return layoutParams.PercentLayoutInfo.TopMarginPercent;
		}

		[Export]
		public void setTopMarginPercent(float marginPercent)
		{
			PercentRelativeLayout.LayoutParams layoutParams = (PercentRelativeLayout.LayoutParams)LayoutParameters;
			layoutParams.PercentLayoutInfo.TopMarginPercent = marginPercent;
			RequestLayout();
		}
	}
	public abstract class BaseAndroidMapView : RelativeLayout, IControlLifeCycle
	{
		public abstract Shire.Core.Maps.IMap Map { get; }

		protected abstract int MapLayout { get; }

		public abstract void OnCreate(Bundle bundle);

		public abstract void OnResume();

		public abstract void OnPause();

		public abstract void OnLowMemory();

		public abstract void OnTrimMemory(TrimMemory level);

		public abstract void OnSaveInstanceState(Bundle outState);

		public virtual void OnDestroy()
		{
			Map?.Dispose();
		}

		protected BaseAndroidMapView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected BaseAndroidMapView(Context context)
			: base(context)
		{
			Init();
		}

		protected BaseAndroidMapView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Init();
		}

		protected BaseAndroidMapView(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(context, attrs, defStyleAttr)
		{
			Init();
		}

		protected BaseAndroidMapView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
			: base(context, attrs, defStyleAttr, defStyleRes)
		{
			Init();
		}

		protected abstract void Init();
	}
	internal class GmsMap : MapBase
	{
		private GoogleMap googleMap;

		private global::Android.Gms.Maps.Model.Polyline routePoly;

		public void SetMap(GoogleMap googleMap)
		{
			this.googleMap = googleMap;
			googleMap.SetPadding(base.MapPadding.Left - base.MapPadding.Bottom, base.MapPadding.Top - base.MapPadding.Bottom, base.MapPadding.Right - base.MapPadding.Bottom, 0);
			UpdateMapDisplayType(CurrentMapType);
		}

		protected override void UpdateMapDisplayType(MapType mapType)
		{
			int mapTypeToChange = -1;
			switch (mapType)
			{
			case MapType.Normal:
				mapTypeToChange = 1;
				break;
			case MapType.Satellite:
				mapTypeToChange = 2;
				break;
			case MapType.Terrain:
				mapTypeToChange = 3;
				break;
			}
			if (googleMap != null && googleMap.MapType != mapTypeToChange)
			{
				InvokeOnMainThread(delegate
				{
					googleMap.MapType = mapTypeToChange;
				});
			}
		}

		protected override void UpdateIsEditable(bool isEditable)
		{
			if (googleMap != null)
			{
				InvokeOnMainThread(delegate
				{
					googleMap.UiSettings.ScrollGesturesEnabled = isEditable;
					googleMap.UiSettings.ZoomGesturesEnabled = isEditable;
				});
			}
		}

		protected override void UpdateZoomLevel(float zoomLevel)
		{
			InvokeOnMainThread(delegate
			{
				if (base.MapMovementAnimates)
				{
					googleMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(new global::Android.Gms.Maps.Model.LatLng(base.MapCenter.Lat, base.MapCenter.Lng), base.ZoomLevel));
				}
				else
				{
					googleMap.CameraPosition.Zoom = zoomLevel;
				}
			});
		}

		protected override void UpdateMapCenter(iFit.Api.Google.LatLng mapCenter)
		{
			InvokeOnMainThread(delegate
			{
				if (base.MapMovementAnimates)
				{
					googleMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(new global::Android.Gms.Maps.Model.LatLng(mapCenter.Lat, mapCenter.Lng), base.ZoomLevel));
				}
				else
				{
					googleMap.CameraPosition.Target = new global::Android.Gms.Maps.Model.LatLng(mapCenter.Lat, mapCenter.Lng);
				}
			});
		}

		protected override Shire.Core.Maps.IMarker AddMarkerNative(iFit.Api.Google.LatLng point, byte[] iconBytes, bool isVisible)
		{
			return new GmsMarker(googleMap, point, isVisible);
		}

		protected override void UpdateRouteLineWidth(float routeLineWidth)
		{
			if (routePoly != null)
			{
				routePoly.Width = routeLineWidth;
			}
		}

		protected override void UpdateRouteColor(SplatColor routeColor)
		{
			if (routePoly != null)
			{
				routePoly.Color = routeColor.ToArgb();
			}
		}

		public override void SetZoomLevelFromRoute()
		{
			if (base.RoutePoints.Count < 2)
			{
				return;
			}
			base.RouteBounds.UpdateBounds(base.RoutePoints);
			if (base.RouteBounds.NorthWest.IsUnknown && base.RouteBounds.SouthEast.IsUnknown)
			{
				return;
			}
			LatLngBounds.Builder builder = new LatLngBounds.Builder();
			builder.Include(new global::Android.Gms.Maps.Model.LatLng(base.RouteBounds.NorthWest.Lat, base.RouteBounds.NorthWest.Lng));
			builder.Include(new global::Android.Gms.Maps.Model.LatLng(base.RouteBounds.SouthEast.Lat, base.RouteBounds.SouthEast.Lng));
			CameraUpdate update = CameraUpdateFactory.NewLatLngBounds(builder.Build(), base.MapPadding.Bottom);
			InvokeOnMainThread(delegate
			{
				if (base.MapMovementAnimates)
				{
					googleMap.AnimateCamera(update);
				}
				else
				{
					googleMap.MoveCamera(update);
				}
			});
		}

		public override void AddManyRoutePoints(List<iFit.Api.Google.LatLng> points)
		{
			AddNoSnapRoutePoints(points);
		}

		private void AddNoSnapRoutePoints(IEnumerable<iFit.Api.Google.LatLng> points)
		{
			InvokeOnMainThread(delegate
			{
				if (routePoly != null)
				{
					IList<global::Android.Gms.Maps.Model.LatLng> pollyPnts = routePoly.Points;
					points.ForEach(delegate(iFit.Api.Google.LatLng point)
					{
						pollyPnts.Add(new global::Android.Gms.Maps.Model.LatLng(point.Lat, point.Lng));
					});
					routePoly.Points = pollyPnts;
				}
			});
		}

		public override void AddNoSnapRoutePoint(iFit.Api.Google.LatLng point)
		{
			AddNoSnapRoutePoints(new iFit.Api.Google.LatLng[1] { point });
		}

		protected override void SetRouteNative(IEnumerable<iFit.Api.Google.LatLng> route)
		{
			InvokeOnMainThread(delegate
			{
				if (routePoly != null)
				{
					routePoly.Points = (from x in route.ToList()
						select new global::Android.Gms.Maps.Model.LatLng(x.Lat, x.Lng)).ToList();
				}
			});
		}

		protected override void ClearRouteNative()
		{
			InvokeOnMainThread(delegate
			{
				if (routePoly != null)
				{
					routePoly.Points = new List<global::Android.Gms.Maps.Model.LatLng>();
				}
			});
		}

		public override void Initialized()
		{
			InvokeOnMainThread(delegate
			{
				routePoly = googleMap.AddPolyline(new PolylineOptions().InvokeWidth(base.RouteLineWidth).InvokeColor(base.RouteColor.ToArgb()).Geodesic(geodesic: true));
			});
			UpdateMapDisplayType(CurrentMapType);
			base.Initialized();
		}
	}
	public class GmsMapContainer : BaseAndroidMapView, IOnMapReadyCallback, IJavaObject, IDisposable, IJavaPeerable, GoogleMap.IOnMapClickListener, GoogleMap.IOnMapLoadedCallback, GoogleMap.IOnMarkerClickListener
	{
		private GoogleMap googleMap;

		private MapFragment mapFragment;

		private bool hasLoaded;

		public override Shire.Core.Maps.IMap Map { get; } = new GmsMap();

		protected override int MapLayout => Resource.Layout.MapViewControl;

		public string DrawMapErrorText { get; set; }

		public GmsMapContainer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public GmsMapContainer(Context context)
			: base(context)
		{
		}

		public GmsMapContainer(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		public GmsMapContainer(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(context, attrs, defStyleAttr)
		{
		}

		public GmsMapContainer(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
			: base(context, attrs, defStyleAttr, defStyleRes)
		{
		}

		protected override void Init()
		{
			View view = LayoutInflater.From(base.Context).Inflate(MapLayout, this, attachToRoot: true);
			FrameLayout frameLayout = view.FindViewById<FrameLayout>(Resource.Id.map_fragment);
			int containerViewId = Resource.Id.map_fragment;
			if (frameLayout != null)
			{
				System.Random random = new System.Random();
				containerViewId = (frameLayout.Id = random.Next(1, 100001));
			}
			mapFragment = new MapFragment();
			global::Android.App.FragmentTransaction fragmentTransaction = ((Activity)base.Context).FragmentManager.BeginTransaction();
			fragmentTransaction.Replace(containerViewId, mapFragment);
			fragmentTransaction.Commit();
			mapFragment.GetMapAsync(this);
		}

		public void OnMapLoaded()
		{
			hasLoaded = true;
			googleMap.SetOnMapClickListener(this);
			googleMap.SetOnMarkerClickListener(this);
			Map.Initialized();
		}

		public void OnMapReady(GoogleMap googleMap)
		{
			this.googleMap = googleMap;
			googleMap.SetIndoorEnabled(enabled: false);
			googleMap.UiSettings.MapToolbarEnabled = false;
			googleMap.UiSettings.ZoomControlsEnabled = false;
			googleMap.UiSettings.RotateGesturesEnabled = false;
			googleMap.UiSettings.TiltGesturesEnabled = false;
			googleMap.UiSettings.ScrollGesturesEnabled = Map.MapIsEditable;
			googleMap.UiSettings.ZoomGesturesEnabled = Map.MapIsEditable;
			googleMap.SetOnMapLoadedCallback(this);
			((GmsMap)Map).SetMap(googleMap);
		}

		public void OnMapClick(global::Android.Gms.Maps.Model.LatLng point)
		{
			iFit.Api.Google.LatLng point2 = new iFit.Api.Google.LatLng(point.Latitude, point.Longitude, Map.RoadSnapOn);
			Map.OnMapClickedInvoker(new MapClickedEventArgs(point2));
		}

		public override void OnCreate(Bundle bundle)
		{
			if (hasLoaded)
			{
				mapFragment?.OnCreate(bundle);
			}
		}

		public override void OnResume()
		{
			if (hasLoaded)
			{
				mapFragment?.OnResume();
			}
		}

		public override void OnPause()
		{
			if (hasLoaded)
			{
				mapFragment?.OnPause();
			}
		}

		public override void OnLowMemory()
		{
			if (hasLoaded)
			{
				mapFragment?.OnLowMemory();
			}
		}

		public override void OnTrimMemory(TrimMemory level)
		{
			if (hasLoaded)
			{
				mapFragment?.OnTrimMemory(level);
			}
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (hasLoaded)
			{
				mapFragment?.Dispose();
			}
		}

		public override void OnSaveInstanceState(Bundle outState)
		{
			if (hasLoaded)
			{
				mapFragment?.OnSaveInstanceState(outState);
			}
		}

		public bool OnMarkerClick(Marker marker)
		{
			if (Map.IsStartMarker(marker.Position.Latitude, marker.Position.Longitude))
			{
				Task.Run(async delegate
				{
					try
					{
						await Map.CloseRouteLoop();
					}
					catch (MaxWorkoutDistanceExceededException)
					{
						Context context = base.Context;
						Activity activity = context as Activity;
						if (activity != null)
						{
							activity.RunOnUiThread(delegate
							{
								Toast.MakeText(activity, DrawMapErrorText, ToastLength.Long).Show();
							});
						}
					}
				});
			}
			return true;
		}
	}
	public class GmsMarker : MarkerBase
	{
		public Marker Marker { get; private set; }

		public GmsMarker(GoogleMap map, iFit.Api.Google.LatLng location, bool isVisible)
		{
			GmsMarker gmsMarker = this;
			_location = location;
			_isVisible = isVisible;
			MarkerOptions opts = new MarkerOptions();
			opts.SetTitle(base.Id);
			opts.Visible(visible: false);
			opts.SetPosition(new global::Android.Gms.Maps.Model.LatLng(_location.Lat, _location.Lng));
			InvokeOnMainThread(delegate
			{
				gmsMarker.Marker = map.AddMarker(opts);
			});
		}

		public override async Task SetIcon(byte[] image, float xAnchor, float yAnchor)
		{
			if (image == null || image.Length == 0)
			{
				iFit.Logger.Log.Trace("Images", "Null or empty byte array setting GMS icon");
				return;
			}
			try
			{
				Bitmap bitmap = await BitmapFactory.DecodeByteArrayAsync(image, 0, image.Length);
				InvokeOnMainThread(delegate
				{
					Marker.SetIcon(BitmapDescriptorFactory.FromBitmap(bitmap));
					Marker.SetAnchor(xAnchor, yAnchor);
					Marker.Visible = _isVisible;
				});
			}
			catch (System.Exception exception)
			{
				iFit.Logger.Log.Error("Images", "Error decoding GmsMarker", exception);
			}
		}

		protected override void UpdateLocationNative()
		{
			InvokeOnMainThread(delegate
			{
				Marker.Position = new global::Android.Gms.Maps.Model.LatLng(base.Location.Lat, base.Location.Lng);
			});
		}

		protected override void UpdateVisibilityNative()
		{
			InvokeOnMainThread(delegate
			{
				Marker.Visible = base.IsVisible;
			});
		}

		protected override void UpdateDraggabilityNative()
		{
			InvokeOnMainThread(delegate
			{
				Marker.Draggable = base.IsDraggable;
			});
		}

		public override void RemoveMarkerNative()
		{
			InvokeOnMainThread(Marker.Remove);
		}
	}
	public static class MvxBindingHelpers
	{
		public static string ClickEvent(this View view)
		{
			return "Click";
		}

		public static string ItemClickEvent(this AdapterView view)
		{
			return "ItemClick";
		}

		public static string FocusChangedEvent(this View view)
		{
			return "FocusChanged";
		}

		public static string ItemClickEvent(this AutoCompleteTextView view)
		{
			return "ItemClick";
		}

		public static string Text(this View view)
		{
			return "Text";
		}

		public static string BindDrawableName(this MvxImageView imageView)
		{
			return "DrawableName";
		}
	}
	public class MvxHeaderSupportListView : ListView
	{
		private int headerCount;

		private bool _itemClickOverloaded;

		private bool _itemLongClickOverloaded;

		private ICommand _itemClick;

		private ICommand _itemLongClick;

		public new IMvxAdapter Adapter
		{
			get
			{
				return ((base.Adapter as HeaderViewListAdapter)?.WrappedAdapter ?? base.Adapter) as IMvxAdapter;
			}
			set
			{
				IMvxAdapter adapter = Adapter;
				if (adapter != value)
				{
					if (value != null && adapter != null)
					{
						value.ItemsSource = adapter.ItemsSource;
						value.ItemTemplateId = adapter.ItemTemplateId;
					}
					base.Adapter = value;
					if (adapter != null)
					{
						adapter.ItemsSource = null;
					}
				}
			}
		}

		[MvxSetToNullAfterBinding]
		public IEnumerable ItemsSource
		{
			get
			{
				return Adapter.ItemsSource;
			}
			set
			{
				Adapter.ItemsSource = value;
			}
		}

		public int ItemTemplateId
		{
			get
			{
				return Adapter.ItemTemplateId;
			}
			set
			{
				Adapter.ItemTemplateId = value;
			}
		}

		public new ICommand ItemClick
		{
			get
			{
				return _itemClick;
			}
			set
			{
				_itemClick = value;
				if (_itemClick != null)
				{
					EnsureItemClickOverloaded();
				}
			}
		}

		public new ICommand ItemLongClick
		{
			get
			{
				return _itemLongClick;
			}
			set
			{
				_itemLongClick = value;
				if (_itemLongClick != null)
				{
					EnsureItemLongClickOverloaded();
				}
			}
		}

		public MvxHeaderSupportListView(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapter(context))
		{
		}

		public MvxHeaderSupportListView(Context context, IAttributeSet attrs, IMvxAdapter adapter)
			: base(context, attrs)
		{
			if (adapter != null)
			{
				int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
				adapter.ItemTemplateId = itemTemplateId;
				Adapter = adapter;
			}
		}

		protected MvxHeaderSupportListView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public override void AddHeaderView(View v)
		{
			headerCount++;
			base.AddHeaderView(v);
		}

		private void EnsureItemClickOverloaded()
		{
			if (!_itemClickOverloaded)
			{
				_itemClickOverloaded = true;
				base.ItemClick += OnItemClick;
			}
		}

		private void EnsureItemLongClickOverloaded()
		{
			if (!_itemLongClickOverloaded)
			{
				_itemLongClickOverloaded = true;
				base.ItemLongClick += OnItemLongClick;
			}
		}

		protected virtual void ExecuteCommandOnItem(ICommand command, int position)
		{
			if (command != null)
			{
				object rawItem = Adapter.GetRawItem(position - headerCount);
				if (rawItem != null && command.CanExecute(rawItem))
				{
					command.Execute(rawItem);
				}
			}
		}

		private void OnItemClick(object sender, ItemClickEventArgs e)
		{
			ExecuteCommandOnItem(ItemClick, e.Position);
		}

		private void OnItemLongClick(object sender, ItemLongClickEventArgs e)
		{
			ExecuteCommandOnItem(ItemLongClick, e.Position);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				base.ItemLongClick -= OnItemLongClick;
				base.ItemClick -= OnItemClick;
			}
			base.Dispose(disposing);
		}
	}
	public class NoPaddingTextView : IfitTextView
	{
		private readonly Paint paint = new Paint();

		private readonly Rect bounds = new Rect();

		public NoPaddingTextView(IntPtr ptr, JniHandleOwnership transfer)
			: base(ptr, transfer)
		{
		}

		public NoPaddingTextView(Context context)
			: base(context)
		{
		}

		public NoPaddingTextView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		public NoPaddingTextView(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
		}

		public override void SetTypeface(Typeface tf, TypefaceStyle style)
		{
			paint.SetTypeface(tf);
		}

		protected override void OnDraw(Canvas canvas)
		{
			string text = base.Text;
			CalculateTextParams();
			int left = bounds.Left;
			int bottom = bounds.Bottom;
			bounds.Offset(-bounds.Left, -bounds.Top);
			paint.AntiAlias = true;
			paint.Color = new Color(base.CurrentTextColor);
			canvas.DrawText(text, -left, bounds.Bottom - bottom, paint);
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
			CalculateTextParams();
			SetMeasuredDimension(bounds.Width() + 1, -bounds.Top + bounds.Bottom);
		}

		private void CalculateTextParams()
		{
			string text = base.Text;
			int length = text.Length;
			paint.TextSize = TextSize;
			paint.GetTextBounds(text, 0, length, bounds);
			if (length == 0)
			{
				bounds.Right = bounds.Left;
			}
		}
	}
	public class RatingControl : LinearLayout
	{
		private IfitTextView ratingLabel;

		private RatingBar ratingBar;

		private LinearLayout layout;

		protected virtual int LayoutResource => Resource.Layout.RatingControl;

		public RatingBar RatingBar => ratingBar;

		public IfitTextView RatingLabel => ratingLabel;

		public RatingControl(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public RatingControl(Context context)
			: base(context)
		{
			Init(context);
		}

		public RatingControl(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Init(context, attrs);
		}

		public RatingControl(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(context, attrs, defStyleAttr)
		{
			Init(context, attrs, defStyleAttr);
		}

		private void Init(Context context, IAttributeSet attrs = null, int? defaultStyle = null)
		{
			View view = LayoutInflater.FromContext(base.Context).Inflate(LayoutResource, this, attachToRoot: true);
			ratingLabel = view.FindViewById<IfitTextView>(Resource.Id.workout_rating_label);
			layout = view.FindViewById<LinearLayout>(Resource.Id.rating_layout);
			if (context != null && attrs != null)
			{
				TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.RatingControl);
				SetLabelAttributes(typedArray);
				CreateAndSetRatingBarStyles(context, attrs, typedArray);
				SetLayoutAttributes(typedArray);
				typedArray.Recycle();
			}
		}

		private void SetLabelAttributes(TypedArray attributes)
		{
			Typeface customTypeface = IfitTypeface.GetCustomTypeface(IfitTypeface.Type.ProximaRegular);
			IfitTypeface.Type ifitTypeFace = (IfitTypeface.Type)attributes.GetInt(Resource.Styleable.RatingControl_typeface, 0);
			customTypeface = ifitTypeFace.GetTypeface();
			ratingLabel.SetTypeface(customTypeface, TypefaceStyle.Normal);
			Color color = attributes.GetColor(Resource.Styleable.RatingControl_android_textColor, base.Context.GetColorCompat(Resource.Color.rating_container_text_color));
			ratingLabel.SetTextColor(color);
			int dimensionPixelSize = attributes.GetDimensionPixelSize(Resource.Styleable.RatingControl_android_textSize, Resource.Dimension.rating_container_text_size);
			ratingLabel.SetTextSize(ComplexUnitType.Fraction, dimensionPixelSize);
		}

		private void CreateAndSetRatingBarStyles(Context context, IAttributeSet attrs, TypedArray attributes)
		{
			int resourceId = attributes.GetResourceId(Resource.Styleable.RatingControl_ratingBarCustomStyle, Resource.Attribute.ratingBarStyleSmall);
			ratingBar = new RatingBar(context, attrs, Resource.Styleable.RatingControl_ratingBarCustomStyle, resourceId);
			int marginStart = (int)attributes.GetDimension(Resource.Styleable.RatingControl_ratingBarMarginStart, 0f);
			LayoutParams layoutParameters = new LayoutParams(-2, -2)
			{
				MarginStart = marginStart,
				Gravity = GravityFlags.CenterVertical
			};
			ratingBar.LayoutParameters = layoutParameters;
			if (attributes.GetBoolean(Resource.Styleable.RatingControl_barLeftOfLabel, defValue: false))
			{
				layout.AddView(ratingBar, 0);
			}
			else
			{
				layout.AddView(ratingBar);
			}
		}

		private void SetLayoutAttributes(TypedArray attributes)
		{
			Drawable drawable = attributes.GetDrawable(Resource.Styleable.RatingControl_containerBackground);
			if (drawable != null)
			{
				layout.Background = drawable;
			}
			int num = (int)attributes.GetDimension(Resource.Styleable.RatingControl_containerPadding, 0f);
			if (layout.LayoutParameters is LayoutParams)
			{
				layout.SetPadding(num, num, num, num);
			}
		}
	}
	public class ShareWorkout : RelativeLayout
	{
		protected virtual int LayoutResource => Resource.Layout.ShareWorkout;

		public FloatingActionButton ShareButton { get; set; }

		public RelativeLayout ShareContainer { get; set; }

		public ImageButton CloseButton { get; set; }

		public ImageButton ShareFacebookButton { get; set; }

		public ImageButton ShareTwitterButton { get; set; }

		public bool ShowShareContainer
		{
			get
			{
				return ShareContainer.Visibility == ViewStates.Visible;
			}
			set
			{
				ShareContainer.Visibility = ((!value) ? ViewStates.Gone : ViewStates.Visible);
				ShareButton.Visibility = (value ? ViewStates.Gone : ViewStates.Visible);
			}
		}

		public ShareWorkout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public ShareWorkout(Context context)
			: base(context)
		{
			Init();
		}

		public ShareWorkout(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Init();
		}

		public ShareWorkout(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(context, attrs, defStyleAttr)
		{
			Init();
		}

		private void Init()
		{
			View view = LayoutInflater.FromContext(base.Context).Inflate(LayoutResource, this, attachToRoot: true);
			ShareButton = view.FindViewById<FloatingActionButton>(Resource.Id.log_screen_share_button);
			ShareButton.BackgroundTintList = ContextCompat.GetColorStateList(base.Context as Activity, Resource.Color.log_screen_share_button_selector);
			ShareContainer = view.FindViewById<RelativeLayout>(Resource.Id.shareContainer);
			CloseButton = view.FindViewById<ImageButton>(Resource.Id.closeButton);
			ShareFacebookButton = view.FindViewById<ImageButton>(Resource.Id.shareFacebookButton);
			ShareTwitterButton = view.FindViewById<ImageButton>(Resource.Id.shareTwitterButton);
		}
	}
	public class ShireLottieAnimationView : LottieAnimationView
	{
		public Dictionary<int, Tuple<float, float>> AnimationDictionary { get; } = new Dictionary<int, Tuple<float, float>>();

		public int CurrentAnimationSequence { get; set; }

		public ShireLottieAnimationView(Context context)
			: base(context)
		{
		}

		public ShireLottieAnimationView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		public ShireLottieAnimationView(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
		}

		public void AddInterval(int animationSequence, float fromInverval, float toInterval)
		{
			AnimationDictionary.Add(animationSequence, new Tuple<float, float>(fromInverval, toInterval));
		}

		public void PlayAnimation(int sequence, bool loop = true, bool continueWithLastStop = false)
		{
			if (!continueWithLastStop)
			{
				Progress = AnimationDictionary[sequence].Item1;
				SetMinProgress(AnimationDictionary[sequence].Item1);
			}
			RepeatCount = ((!loop) ? 1 : (-1));
			SetMaxProgress(AnimationDictionary[sequence].Item2);
			if (!IsAnimating)
			{
				ResumeAnimation();
			}
			CurrentAnimationSequence = sequence;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				RemoveAllAnimatorListeners();
				RemoveAllUpdateListeners();
				RemoveAllLottieOnCompositionLoadedListener();
			}
			base.Dispose(disposing);
		}
	}
}
namespace Shire.Android.Controls.WebViews
{
	public class RendererCrashWebClient : ShireWebClient
	{
		private static bool shouldHandleRenderProcessGone = true;

		public static void EnableHandlingRenderProcessGone()
		{
			shouldHandleRenderProcessGone = true;
		}

		public RendererCrashWebClient(Context context, Action OnStartLoading, Action OnErrorLoading, Action OnFinishLoading, Action<HttpStatusCode> OnHttpError, Guid id)
			: base(context, OnStartLoading, OnErrorLoading, OnFinishLoading, OnHttpError, id)
		{
		}

		public override bool OnRenderProcessGone(WebView view, RenderProcessGoneDetail detail)
		{
			base.OnRenderProcessGone(view, detail);
			ShireWebView shireWebView = view as ShireWebView;
			if (!shouldHandleRenderProcessGone)
			{
				iFit.Logger.Log.Info(base.LogTag, "Ignored additional OnRenderProcessGone call for url " + view?.Url + " since it is already being handled.");
				return true;
			}
			if (shireWebView?.Delegate == null)
			{
				iFit.Logger.Log.Info(base.LogTag, "Ignored additional OnRenderProcessGone call since ShireWebView.Delegate is null");
				return true;
			}
			shireWebView.CurrentState = WebViewState.Unknown | WebViewState.Errored;
			shouldHandleRenderProcessGone = false;
			LogRenderProcessError(detail, shireWebView);
			string text = shireWebView.Url ?? "chrome://crash";
			HandleError(text, text, onErrorLoading);
			return true;
		}

		private void LogRenderProcessError(RenderProcessGoneDetail detail, ShireWebView webView)
		{
			try
			{
				if (detail == null)
				{
					iFit.Logger.Log.Error(base.LogTag, "Unable to log WebView Render error as RenderProcessGoneDetail is null: " + webView?.Url);
					return;
				}
				bool flag = detail.DidCrash();
				string name = System.Enum.GetName(typeof(RendererPriority), detail.RendererPriorityAtExit());
				string message = "A WebView renderer process that may be shared across multiple WebViews encountered a fatal error. Delegate of type " + webView?.Delegate?.GetType().Name + " will handle error. App will restart. " + $"didCrash=({flag}), rendererPriority=({name}), url=({webView?.Url})";
				throw new RaygunException(message);
			}
			catch (RaygunException exception)
			{
				iFit.Logger.Log.Fatal(base.LogTag, "WebView Render Process Gone", exception);
			}
			catch (System.Exception exception2)
			{
				iFit.Logger.Log.Error(base.LogTag, "Unable to log WebView Render error: " + webView?.Url, exception2);
			}
		}
	}
	public class ShireWebChromeClient : WebChromeClient
	{
		private const string CallJsNotDefined = "callJavaScript is not defined";

		private Context context;

		private ViewGroup container;

		private List<WebView> openedWindows = new List<WebView>();

		private WebView.WebViewTransport transport;

		private Action onJavascriptNotDefined;

		private bool isDisposed;

		public Activity Activity { get; set; }

		public bool OpenNewWindowsModally { get; set; }

		public ShireWebChromeClient(Context context, ViewGroup container, Action onJavascriptNotDefined)
		{
			this.context = context;
			this.container = container;
			this.onJavascriptNotDefined = onJavascriptNotDefined;
		}

		public override bool OnCreateWindow(WebView view, bool isDialog, bool isUserGesture, Message resultMsg)
		{
			iFit.Logger.Log.Trace("WebView", "Webview [url: " + view.Url + "] is creating a new window.");
			if (OpenNewWindowsModally)
			{
				WebViewDialogFragment webViewDialogFragment = WebViewDialogFragment.Create(resultMsg);
				webViewDialogFragment.Show(Activity.FragmentManager, "webviewpopupdlg");
			}
			else
			{
				ShireWebView shireWebView = new ShireWebView(context);
				openedWindows.Add(shireWebView);
				shireWebView.SetWebChromeClient(this);
				shireWebView.LayoutParameters = new FrameLayout.LayoutParams(-1, -1);
				container.AddView(shireWebView);
				transport = (WebView.WebViewTransport)resultMsg.Obj;
				transport.WebView = shireWebView;
				resultMsg.SendToTarget();
				view.ScrollTo(0, 0);
			}
			return true;
		}

		public void CloseWebView()
		{
			OnCloseWindow(null);
		}

		public override void OnCloseWindow(WebView window)
		{
			if (window != null)
			{
				iFit.Logger.Log.Trace("WebView", "Closing a window opened by a webview");
				CloseWindow(window);
				openedWindows.Remove((ShireWebView)window);
				return;
			}
			foreach (WebView openedWindow in openedWindows)
			{
				CloseWindow(openedWindow);
			}
			iFit.Logger.Log.Trace("WebView", $"Closing {openedWindows.Count} windows opened by a webview");
			openedWindows.Clear();
		}

		private void CloseWindow(WebView window)
		{
			window.StopLoading();
			window.LoadUrl("about:blank");
			container?.RemoveView(window);
			window.SetWebChromeClient(null);
			window.Dispose();
		}

		public override bool OnConsoleMessage(ConsoleMessage consoleMessage)
		{
			Task.Run(async delegate
			{
				ConsoleMessage.MessageLevel messageLevel = consoleMessage.InvokeMessageLevel();
				string json = consoleMessage.Message();
				json = JsonObfuscator.PrepareJsonForLogging(json, "\\\"", "\\\": \\\"", "[a-zA-Z0-9]*", "\\\"");
				if (messageLevel == ConsoleMessage.MessageLevel.Error)
				{
					iFit.Logger.Log.Error("WebView", "Console Error: " + json);
				}
				else
				{
					if (json != null && json.Contains("activitylog"))
					{
						json = ((json.Length > 2000) ? (json.Remove(2000) + "...") : json);
					}
					iFit.Logger.Log.Trace("WebView", $"Console {messageLevel}: {json}");
				}
				if (json.Contains("callJavaScript is not defined"))
				{
					onJavascriptNotDefined();
				}
			});
			return true;
		}

		protected override void Dispose(bool disposing)
		{
			if (isDisposed)
			{
				return;
			}
			if (disposing)
			{
				if (transport != null)
				{
					transport.WebView = null;
					transport?.Dispose();
					transport = null;
				}
				OnCloseWindow(null);
				openedWindows = null;
				container = null;
				context = null;
				onJavascriptNotDefined = null;
			}
			base.Dispose(disposing);
			isDisposed = true;
		}
	}
	public class ShireWebClient : WebViewClient
	{
		private Action onStartLoading;

		protected Action onErrorLoading;

		private Action onFinishLoading;

		private Action<HttpStatusCode> onHttpError;

		private Handler mainHandler;

		private bool hasError;

		private bool isDisposed;

		private Guid webViewId;

		protected string LogTag => GetType().Name;

		public bool StrictResourceErrorNotifications { get; set; }

		public ShireWebClient(Context context, Action OnStartLoading, Action OnErrorLoading, Action OnFinishLoading, Action<HttpStatusCode> OnHttpError, Guid id)
		{
			onStartLoading = OnStartLoading;
			onErrorLoading = OnErrorLoading;
			onFinishLoading = OnFinishLoading;
			onHttpError = OnHttpError;
			mainHandler = new Handler(context.MainLooper);
			webViewId = id;
		}

		public override void OnPageStarted(WebView view, string url, Bitmap favicon)
		{
			if (!isDisposed)
			{
				base.OnPageStarted(view, url, favicon);
				iFit.Logger.Log.Trace("WebView:" + webViewId.ToString(), "OnPageStarted for URL: " + url);
				hasError = false;
				if (onStartLoading != null)
				{
					mainHandler?.Post(onStartLoading);
				}
			}
		}

		public override void OnPageFinished(WebView view, string url)
		{
			if (!isDisposed)
			{
				base.OnPageFinished(view, url);
				iFit.Logger.Log.Trace("WebView:" + webViewId.ToString(), "OnPageFinished for URL: " + url);
				if (!hasError && onFinishLoading != null)
				{
					mainHandler?.Post(onFinishLoading);
				}
			}
		}

		public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
		{
			if (!isDisposed)
			{
				base.OnReceivedError(view, request, error);
				iFit.Logger.Log.Trace("WebView:" + webViewId.ToString(), $"OnReceivedError: [Request.URL: {request.Url}] [Error: {error.Description}]");
				HandleError(view?.Url, request?.Url?.ToString(), onErrorLoading);
			}
		}

		public override void OnReceivedHttpError(WebView view, IWebResourceRequest request, WebResourceResponse errorResponse)
		{
			if (!isDisposed)
			{
				base.OnReceivedHttpError(view, request, errorResponse);
				iFit.Logger.Log.Trace("WebView:" + webViewId.ToString(), $"OnReceivedHTTPError: [Error: {errorResponse.StatusCode}] [Request.URL: {request.Url}]");
				HandleError(view?.Url, request?.Url?.ToString(), delegate
				{
					onHttpError?.Invoke((HttpStatusCode)errorResponse.StatusCode);
				});
			}
		}

		protected void HandleError(string viewUrl, string failingUrl, Action onConfirmedFailure)
		{
			if (ShouldContinueWithFailureHandling(viewUrl, failingUrl))
			{
				hasError = true;
				if (onConfirmedFailure != null)
				{
					mainHandler?.Post(onConfirmedFailure);
				}
			}
		}

		private bool ShouldContinueWithFailureHandling(string viewUrl, string failingUrl)
		{
			iFit.Logger.Log.Trace("WebView:" + webViewId.ToString(), "ShouldContinueWithFailureHandling: [ViewURL: " + viewUrl + "] [FailingURL: " + failingUrl + "]");
			if (!StrictResourceErrorNotifications)
			{
				if (!string.IsNullOrWhiteSpace(viewUrl))
				{
					return viewUrl.Equals(failingUrl);
				}
				return false;
			}
			return true;
		}

		protected override void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				if (disposing)
				{
					onErrorLoading = null;
					onStartLoading = null;
					onFinishLoading = null;
					mainHandler?.Dispose();
					mainHandler = null;
				}
				base.Dispose(disposing);
				isDisposed = true;
			}
		}

		public override bool ShouldOverrideUrlLoading(WebView view, string url)
		{
			if (!ShouldProceedDeepLink(view, url))
			{
				return base.ShouldOverrideUrlLoading(view, url);
			}
			return true;
		}

		private bool ShouldProceedDeepLink(WebView view, string url)
		{
			if (url.Contains("ifitcom.app.link") && Mvx.TryResolve<IBranchService>(out var service))
			{
				IBranchConfigService branchConfigService = Mvx.Resolve<IBranchConfigService>();
				string apiKey = branchConfigService.GetApiKey();
				string appLinkUrl = service?.ResolveBranchLink(url, apiKey, "Android").Result;
				iFit.Logger.Log.Trace("WebView", "Deep link clicked within webview");
				AppLinkingService.Instance.HandleExternalLinkRequest(appLinkUrl);
				return true;
			}
			return false;
		}
	}
	public class ShireWebView : WebView, IAndroidWebView, IWebView, IDisposable, View.IOnTouchListener, IJavaObject, IJavaPeerable
	{
		public class OnOverScrolledEventArgs : EventArgs
		{
			public int ScrollX { get; set; }

			public int ScrollY { get; set; }

			public bool ClampedX { get; set; }

			public bool ClampedY { get; set; }

			public OnOverScrolledEventArgs(int scrollX, int scrollY, bool clampedX, bool clampedY)
			{
				ScrollX = scrollX;
				ScrollY = scrollY;
				ClampedX = clampedX;
				ClampedY = clampedY;
			}
		}

		private WebViewState _currentState = WebViewState.Unknown;

		private Func<IWebView, bool> _shouldFlush;

		private bool isDisposed;

		private ShireLottieAnimationView preloadingAnimationView;

		private ImageButton CloseButton;

		private RelativeLayout InnerLayout;

		private ShireWebChromeClient MyChromeClient;

		private ShireWebClient WebViewClientCopy;

		private Guid webViewId = Guid.NewGuid();

		private bool _isReadyToCommunicate;

		public IJavascriptBridge Bridge { get; set; }

		public IWebViewNavigationDelegate DidNavigateDelegate { get; set; }

		public IWebViewDelegate Delegate { get; private set; }

		public WebViewState CurrentState
		{
			get
			{
				return _currentState;
			}
			set
			{
				if (_currentState != value)
				{
					_currentState = value;
					DidNavigateDelegate?.WebViewStateChanged(_currentState);
				}
			}
		}

		public bool ViewHasSuperview => this?.Parent != null;

		public bool IsFlushable
		{
			get
			{
				try
				{
					return isDisposed || !ViewHasSuperview;
				}
				catch
				{
					return true;
				}
			}
		}

		public Func<IWebView, bool> ShouldFlush
		{
			get
			{
				if (_shouldFlush == null)
				{
					return (IWebView _) => true;
				}
				return _shouldFlush;
			}
			set
			{
				_shouldFlush = value;
			}
		}

		public bool ShowLoadingIndicator
		{
			get
			{
				RelativeLayout innerLayout = InnerLayout;
				if (innerLayout == null)
				{
					return false;
				}
				return innerLayout.Visibility == ViewStates.Visible;
			}
			set
			{
				SetInnerViewStates(value, value);
			}
		}

		public override WebChromeClient WebChromeClient => MyChromeClient;

		public bool StrictResourceErrorNotifications
		{
			get
			{
				return WebViewClientCopy?.StrictResourceErrorNotifications ?? false;
			}
			set
			{
				if (WebViewClientCopy != null)
				{
					WebViewClientCopy.StrictResourceErrorNotifications = value;
				}
			}
		}

		public bool IsReadyToCommunicate
		{
			get
			{
				return _isReadyToCommunicate;
			}
			set
			{
				if (_isReadyToCommunicate != value)
				{
					_isReadyToCommunicate = value;
					if (DidNavigateDelegate != null)
					{
						DidNavigateDelegate.IsReadyToCommunicate = _isReadyToCommunicate;
					}
				}
			}
		}

		public bool HideLoadingViewWhenWebViewIsReady { get; set; } = true;

		public bool IsLoaded => CurrentState == WebViewState.Loaded;

		public event EventHandler<OnOverScrolledEventArgs> OnOverScrolledEvent;

		public ShireWebView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public ShireWebView(Context context)
			: base(context)
		{
			preloadingAnimationView = new ShireLottieAnimationView(context);
			Initialize(context);
		}

		public ShireWebView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			preloadingAnimationView = new ShireLottieAnimationView(context, attrs);
			Initialize(context);
		}

		public ShireWebView(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			preloadingAnimationView = new ShireLottieAnimationView(context, attrs, defStyle);
			Initialize(context);
		}

		private void Initialize(Context context)
		{
			WebViewClientCopy = CreateWebClient(context);
			SetWebViewClient(WebViewClientCopy);
			Settings.JavaScriptEnabled = true;
			Settings.JavaScriptCanOpenWindowsAutomatically = true;
			Settings.SetSupportMultipleWindows(support: true);
			Settings.DomStorageEnabled = true;
			Bridge = new JavascriptBridge
			{
				CallJavascript = CallJavascript
			};
			AddJavascriptInterface(this, "Android");
			SetInnerViews(context);
			LongClickable = true;
			base.LongClick -= OnLongClick;
			base.LongClick += OnLongClick;
			MyChromeClient = new ShireWebChromeClient(context, this, OnErrorLoading);
			SetWebChromeClient(MyChromeClient);
		}

		private ShireWebClient CreateWebClient(Context context)
		{
			if (Mvx.TryResolve<IFeatureFlagManager>(out var service) && service.IsFeatureEnabled(FeatureFlags.WebviewRendererCrashReporting))
			{
				return new RendererCrashWebClient(context, OnStartLoading, OnErrorLoading, OnFinishLoading, OnHttpError, webViewId);
			}
			return new ShireWebClient(context, OnStartLoading, OnErrorLoading, OnFinishLoading, OnHttpError, webViewId);
		}

		private void SetInnerViews(Context context)
		{
			InnerLayout = new RelativeLayout(context);
			InnerLayout.SetBackgroundColor(Color.White);
			InnerLayout.LayoutParameters = new FrameLayout.LayoutParams(-1, -1);
			InnerLayout.Clickable = true;
			AddView(InnerLayout);
			float dimension = Resources.GetDimension(Resource.Dimension.full_screen_webview_native_loader_phone);
			if (Mvx.TryResolve<IDeviceInformation>(out var service) && service.IsTablet)
			{
				dimension = Resources.GetDimension(Resource.Dimension.full_screen_webview_native_loader_tablet);
			}
			RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams((int)dimension, (int)dimension);
			layoutParams.AddRule(LayoutRules.CenterInParent);
			preloadingAnimationView.LayoutParameters = layoutParams;
			preloadingAnimationView.Loop(loop: true);
			preloadingAnimationView.SetAnimation("loader_ring.json");
			preloadingAnimationView.EnableMergePathsForKitKatAndAbove(enable: true);
			InnerLayout.AddView(preloadingAnimationView);
			CloseButton = new ImageButton(context);
			CloseButton.SetImageResource(Resource.Drawable.IcCloseX);
			CloseButton.SetBackgroundColor(Color.Transparent);
			FrameLayout.LayoutParams layoutParams2 = new FrameLayout.LayoutParams(-2, -2);
			CloseButton.SetPadding(8, 8, 8, 8);
			CloseButton.SetBackgroundColor(Color.Argb(102, 0, 0, 0));
			layoutParams2.Height = 43;
			layoutParams2.Width = 43;
			AddView(CloseButton, layoutParams2);
			CloseButton.Visibility = ViewStates.Invisible;
			CloseButton.Click -= CloseButtonClick;
			CloseButton.Click += CloseButtonClick;
		}

		private void CloseButtonClick(object sender, EventArgs e)
		{
			MyChromeClient?.CloseWebView();
			CloseButton.Visibility = ViewStates.Invisible;
		}

		private void OnLongClick(object sender, LongClickEventArgs e)
		{
		}

		public void SetScrollEnabled(bool isScrollEnabled)
		{
			SetOnTouchListener(isScrollEnabled ? null : this);
		}

		public void ToggleOnLongClick(bool enabled)
		{
			base.LongClick -= OnLongClick;
			if (enabled)
			{
				base.LongClick += OnLongClick;
			}
		}

		public override void AddView(View child)
		{
			if (!isDisposed)
			{
				base.AddView(child);
				BringChildToFront(CloseButton);
			}
		}

		public void ChangeCacheMode(bool shouldCacheWebPages = true)
		{
			if (!isDisposed)
			{
				Settings.CacheMode = (shouldCacheWebPages ? CacheModes.Default : CacheModes.NoCache);
			}
		}

		public void EnableChromeDebugging(bool enable = false)
		{
			if (!isDisposed && enable && Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
			{
				WebView.SetWebContentsDebuggingEnabled(enabled: true);
			}
		}

		private void WebViewIsReady(IDictionary<string, string> configs = null)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (configs != null)
			{
				if (configs.TryGetValue("keys", out var value))
				{
					dictionary["keys"] = value;
				}
				if (configs.TryGetValue("echo", out var value2))
				{
					dictionary["echo"] = value2;
				}
			}
			iFit.Logger.Log.Trace("WebView", "WebviewIsReady with InitializationParameters: " + JsonConvert.SerializeObject(dictionary));
			IsReadyToCommunicate = true;
			if (CurrentState != WebViewState.Loading)
			{
				SetInnerViewStates(loadingAnimationVisible: false, innerLayoutVisible: false);
			}
			DidNavigateDelegate?.WebViewIsReady(dictionary);
		}

		[Export]
		[JavascriptInterface]
		public void callNative(string json)
		{
			if (!isDisposed)
			{
				if (json.Contains("popupWillOpen"))
				{
					PopupWillOpen();
				}
				else if (Bridge == null)
				{
					iFit.Logger.Log.Trace("WebView", "Ignoring call to " + json + " - bridge null");
				}
				else
				{
					Bridge?.HandleMessage(json);
				}
			}
		}

		private void PopupWillOpen()
		{
			if (isDisposed)
			{
				return;
			}
			MvxSingleton<IMvxMainThreadDispatcher>.Instance.RequestMainThreadAction(delegate
			{
				ImageButton closeButton = CloseButton;
				if (closeButton != null && closeButton.Visibility == ViewStates.Invisible)
				{
					CloseButton.Visibility = ViewStates.Visible;
				}
			});
		}

		private void CallJavascript(JavascriptBridgeCallLog javascriptCallLog)
		{
			if (!isDisposed)
			{
				javascriptCallLog.LogMessage = JsonObfuscator.PrepareJsonForLogging(javascriptCallLog.LogMessage);
				if (javascriptCallLog.LogMessage.Length > 2000)
				{
					javascriptCallLog.ShortenLog(2000);
				}
				iFit.Logger.Log.Debug("WebView:" + webViewId.ToString(), "CallJavascript: " + javascriptCallLog.LogMessage);
				MvxSingleton<IMvxMainThreadDispatcher>.Instance.RequestMainThreadAction(delegate
				{
					EvaluateJavascript(javascriptCallLog.Javascript, null);
				});
			}
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				global::Android.Util.Log.Debug("WebView", string.Format("ShireWebView Dispose called, url = {0}, isDisposed = {1}, disposing = {2}", Url ?? "<null>", isDisposed, disposing));
				if (isDisposed)
				{
					return;
				}
				CurrentState = WebViewState.Disposed;
				if (disposing)
				{
					MvxSingleton<IMvxMainThreadDispatcher>.Instance.RequestMainThreadAction(delegate
					{
						SetWebViewClient(null);
					});
					DidNavigateDelegate = null;
					ShouldFlush = null;
					MyChromeClient?.Dispose();
					MyChromeClient = null;
					SetWebChromeClient(null);
					Bridge?.Dispose();
					Bridge = null;
					WebViewClientCopy?.Dispose();
					WebViewClientCopy = null;
					SetWebViewClient(null);
					base.LongClick -= OnLongClick;
					if (preloadingAnimationView != null)
					{
						InnerLayout?.RemoveView(preloadingAnimationView);
					}
					preloadingAnimationView?.Dispose();
					preloadingAnimationView = null;
					CloseButton.Click -= CloseButtonClick;
					if (CloseButton != null)
					{
						RemoveView(CloseButton);
					}
					CloseButton?.Dispose();
					CloseButton = null;
					if (InnerLayout != null)
					{
						RemoveView(InnerLayout);
					}
					InnerLayout?.Dispose();
					InnerLayout = null;
					Delegate = null;
					ClearHistory();
					ClearCache(includeDiskFiles: false);
					LoadUrl("about:blank");
					OnPause();
					RemoveAllViews();
					DestroyDrawingCache();
					Destroy();
				}
				base.Dispose(disposing);
				isDisposed = true;
			}
			catch (ObjectDisposedException)
			{
				global::Android.Util.Log.Error("WebView", "ShireWebView -  already disposed on disposal.");
			}
		}

		public override void LoadUrl(string url)
		{
			if (isDisposed)
			{
				return;
			}
			url = url.Trim();
			if (Url == url)
			{
				return;
			}
			if (Mvx.TryResolve<IConnectivity>(out var service) && Mvx.TryResolve<IMvxMainThreadDispatcher>(out var service2) && service.IsConnected && !string.IsNullOrWhiteSpace(url))
			{
				Bridge?.Expose("WebViewIsReady", WebViewIsReady);
				service2.RequestMainThreadAction(delegate
				{
					base.LoadUrl(url);
				});
			}
			else
			{
				OnErrorLoading();
			}
		}

		private void OnStartLoading()
		{
			if (!isDisposed && CurrentState != WebViewState.Loading)
			{
				CurrentState = WebViewState.Loading;
				SetInnerViewStates(loadingAnimationVisible: true, innerLayoutVisible: true);
			}
		}

		private void OnFinishLoading()
		{
			if (!isDisposed && CurrentState != WebViewState.Loaded)
			{
				CurrentState = WebViewState.Loaded;
				if (IsReadyToCommunicate || !HideLoadingViewWhenWebViewIsReady)
				{
					SetInnerViewStates(loadingAnimationVisible: false, innerLayoutVisible: false);
				}
				DidNavigateDelegate?.WebViewFinishedNavigating();
			}
		}

		public void OnErrorLoading()
		{
			if (!isDisposed && CurrentState != WebViewState.Errored)
			{
				if (CurrentState == (WebViewState.Unknown | WebViewState.Errored))
				{
					Delegate?.OnWebViewRenderProcessGone();
					return;
				}
				CurrentState = WebViewState.Errored;
				SetInnerViewStates(loadingAnimationVisible: false, innerLayoutVisible: true);
				DidNavigateDelegate?.WebViewErrorLoading();
				Delegate?.WebViewErrorLoading();
			}
		}

		public void ForceShowLoadingAnimation()
		{
			if (!isDisposed && CurrentState != WebViewState.Loaded)
			{
				SetInnerViewStates(loadingAnimationVisible: true, innerLayoutVisible: true);
			}
		}

		private void SetInnerViewStates(bool loadingAnimationVisible, bool innerLayoutVisible)
		{
			MvxSingleton<IMvxMainThreadDispatcher>.Instance.RequestMainThreadAction(delegate
			{
				if (preloadingAnimationView != null)
				{
					if (loadingAnimationVisible)
					{
						preloadingAnimationView.Visibility = ViewStates.Visible;
						preloadingAnimationView.ResumeAnimation();
					}
					else
					{
						preloadingAnimationView.Visibility = ViewStates.Gone;
						preloadingAnimationView.PauseAnimation();
					}
				}
				if (InnerLayout != null)
				{
					InnerLayout.Visibility = ((!innerLayoutVisible) ? ViewStates.Gone : ViewStates.Visible);
				}
			});
		}

		private void OnHttpError(HttpStatusCode statusCode)
		{
			if (!isDisposed)
			{
				global::Android.Util.Log.Error("WebView", string.Format("Android webview at \"{0}\" received response with status: {1}", Url ?? "<null>", statusCode));
				if (statusCode.IsConsideredErrorStatus())
				{
					DidNavigateDelegate?.WebViewErrorCodeResponse(statusCode);
				}
			}
		}

		public override void SetBackgroundColor(Color color)
		{
			base.SetBackgroundColor(color);
			InnerLayout?.SetBackgroundColor(color);
		}

		protected override void OnOverScrolled(int scrollX, int scrollY, bool clampedX, bool clampedY)
		{
			base.OnOverScrolled(scrollX, scrollY, clampedX, clampedY);
			this.OnOverScrolledEvent?.Invoke(this, new OnOverScrolledEventArgs(scrollX, scrollY, clampedX, clampedY));
		}

		public bool OnTouch(View v, MotionEvent e)
		{
			return e.Action == MotionEventActions.Move;
		}
	}
}
namespace Shire.Android.Controls.Toolbar
{
	public class BluetoothButton : ImageButton
	{
		private DeviceState _bluetoothButtonState;

		public DeviceState BluetoothButtonState
		{
			get
			{
				return _bluetoothButtonState;
			}
			set
			{
				if (value != _bluetoothButtonState)
				{
					_bluetoothButtonState = value;
					Post(UpdateBluetoothButtonState);
				}
			}
		}

		private void UpdateBluetoothButtonState()
		{
			ClearAnimation();
			switch (_bluetoothButtonState)
			{
			case DeviceState.Disconnected:
				SetImageResource(Resource.Drawable.IcBluetooth);
				break;
			case DeviceState.Connected:
				SetImageResource(Resource.Drawable.IcBluetoothConnected);
				break;
			case DeviceState.Connecting:
			{
				SetImageResource(Resource.Drawable.IcBluetooth);
				Animation animation = AnimationUtils.LoadAnimation(base.Context, Resource.Animation.BluetoothPulse);
				StartAnimation(animation);
				break;
			}
			default:
				throw new ArgumentOutOfRangeException("Please add support for " + _bluetoothButtonState);
			}
		}

		public BluetoothButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public BluetoothButton(Context context)
			: base(context)
		{
			Init();
		}

		public BluetoothButton(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Init();
		}

		public BluetoothButton(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(context, attrs, defStyleAttr)
		{
			Init();
		}

		public BluetoothButton(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
			: base(context, attrs, defStyleAttr, defStyleRes)
		{
			Init();
		}

		private void Init()
		{
			SetBackgroundResource(Resource.Drawable.SelectableItemBackground);
			BluetoothButtonState = DeviceState.Connecting;
		}
	}
}
namespace Shire.Android.Controls.PreLogin
{
	public class AngleBackgroundView : View
	{
		private global::Android.Graphics.Path path;

		private Paint backgroundPaint;

		private float _angleSlope;

		public float AngleSlope
		{
			get
			{
				return _angleSlope;
			}
			set
			{
				_angleSlope = value;
				Invalidate();
			}
		}

		public Color AngleBackground
		{
			get
			{
				return backgroundPaint.Color;
			}
			set
			{
				backgroundPaint.Color = value;
				Invalidate();
			}
		}

		public AngleBackgroundView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public AngleBackgroundView(Context context)
			: base(context)
		{
			Init(context, null);
		}

		public AngleBackgroundView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Init(context, attrs);
		}

		public AngleBackgroundView(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(context, attrs, defStyleAttr)
		{
			Init(context, attrs);
		}

		private void Init(Context context, IAttributeSet attrs)
		{
			path = new global::Android.Graphics.Path();
			backgroundPaint = new Paint();
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.PreLoginAngleBackgroundView);
			try
			{
				AngleSlope = typedArray.GetFloat(Resource.Styleable.PreLoginAngleBackgroundView_angle, 0f);
				Color color = typedArray.GetColor(Resource.Styleable.PreLoginAngleBackgroundView_android_colorBackground, Color.White);
				backgroundPaint.AntiAlias = true;
				AngleBackground = color;
			}
			finally
			{
				typedArray?.Recycle();
			}
		}

		protected override void OnDraw(Canvas canvas)
		{
			base.OnDraw(canvas);
			float x = AngleSlope * (float)base.Height;
			path.Reset();
			path.MoveTo(x, 0f);
			path.LineTo(0f, base.Height);
			path.LineTo(base.Width, base.Height);
			path.LineTo(base.Width, 0f);
			path.LineTo(x, 0f);
			path.Close();
			canvas.DrawPath(path, backgroundPaint);
		}
	}
}
namespace Shire.Android.Controls.Charts
{
	public class BackgroundLimitLine : LimitLine
	{
		public Color BackgroundColor { get; set; }

		public Color BorderColor { get; set; }

		public float PaddingVertical { get; set; }

		public float PaddingHorizontal { get; set; }

		public BackgroundLimitLine(float limit)
			: base(limit)
		{
		}

		public BackgroundLimitLine(float limit, string label)
			: base(limit, label)
		{
		}
	}
	public class BackgroundLimitLineYAxisRenderer : YAxisRenderer
	{
		private Paint BackgroundPaint { get; set; }

		public BackgroundLimitLineYAxisRenderer(ViewPortHandler viewPortHandler, YAxis yAxis, Transformer trans)
			: base(viewPortHandler, yAxis, trans)
		{
			BackgroundPaint = new Paint();
			BackgroundPaint.SetStyle(Paint.Style.Fill);
		}

		public override void RenderLimitLines(Canvas canvas)
		{
			IList<LimitLine> limitLines = base.MYAxis.LimitLines;
			if (limitLines == null || limitLines.Count <= 0)
			{
				return;
			}
			float[] array = new float[2];
			global::Android.Graphics.Path path = new global::Android.Graphics.Path();
			foreach (LimitLine item in limitLines)
			{
				if (!item.Enabled)
				{
					continue;
				}
				base.MLimitLinePaint.SetStyle(Paint.Style.Stroke);
				base.MLimitLinePaint.Color = new Color(item.LineColor);
				base.MLimitLinePaint.StrokeWidth = item.LineWidth;
				base.MLimitLinePaint.SetPathEffect(item.DashPathEffect);
				array[1] = item.Limit;
				base.MTrans.PointValuesToPixel(array);
				path.MoveTo(base.MViewPortHandler.ContentLeft(), array[1]);
				path.LineTo(base.MViewPortHandler.ContentRight(), array[1]);
				canvas.DrawPath(path, base.MLimitLinePaint);
				path.Reset();
				string label = item.Label;
				if (string.IsNullOrEmpty(label))
				{
					continue;
				}
				BackgroundLimitLine backgroundLimitLine = item as BackgroundLimitLine;
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				if (backgroundLimitLine != null)
				{
					BackgroundPaint.Color = backgroundLimitLine.BackgroundColor;
					num = Utils.ConvertDpToPixel(backgroundLimitLine.PaddingHorizontal);
					num2 = num * 2f;
					num3 = Utils.ConvertDpToPixel(backgroundLimitLine.PaddingVertical);
					num4 = num3 * 2f;
					num5 = base.MLimitLinePaint.MeasureText(label);
				}
				base.MLimitLinePaint.SetStyle(item.TextStyle);
				base.MLimitLinePaint.SetPathEffect(null);
				base.MLimitLinePaint.Color = new Color(item.TextColor);
				base.MLimitLinePaint.SetTypeface(item.Typeface);
				base.MLimitLinePaint.StrokeWidth = 0.5f;
				base.MLimitLinePaint.TextSize = item.TextSize;
				float num6 = Utils.CalcTextHeight(base.MLimitLinePaint, label);
				float num7 = Utils.ConvertDpToPixel(4f) + item.XOffset;
				float num8 = item.LineWidth + num6 + item.YOffset;
				LimitLine.LimitLabelPosition labelPosition = item.LabelPosition;
				if (labelPosition == LimitLine.LimitLabelPosition.RightTop)
				{
					base.MLimitLinePaint.TextAlign = Paint.Align.Right;
					float num9 = base.MViewPortHandler.ContentRight() - num7;
					float num10 = array[1] - num8 + num6;
					if (backgroundLimitLine != null)
					{
						canvas.DrawRect(num9 - num5 - num2, num10 - num6 - num4, num9, num10, BackgroundPaint);
					}
					canvas.DrawText(label, num9 - num, num10 - num3, base.MLimitLinePaint);
				}
				else if (labelPosition == LimitLine.LimitLabelPosition.RightBottom)
				{
					base.MLimitLinePaint.TextAlign = Paint.Align.Right;
					float num11 = base.MViewPortHandler.ContentRight() - num7;
					float num12 = array[1] + num8;
					if (backgroundLimitLine != null)
					{
						canvas.DrawRect(num11 - num5 - num2, num12 - num6, num11, num12 + num4, BackgroundPaint);
					}
					canvas.DrawText(label, num11 - num, num12 + num3, base.MLimitLinePaint);
				}
				else if (labelPosition == LimitLine.LimitLabelPosition.LeftTop)
				{
					base.MLimitLinePaint.TextAlign = Paint.Align.Left;
					float num13 = base.MViewPortHandler.ContentLeft() + num7;
					float num14 = array[1] - num8 + num6;
					if (backgroundLimitLine != null)
					{
						canvas.DrawRect(num13, num14 - num6 - num4, num13 + num5 + num2, num14, BackgroundPaint);
					}
					canvas.DrawText(label, num13 + num, num14 - num3, base.MLimitLinePaint);
				}
				else
				{
					base.MLimitLinePaint.TextAlign = Paint.Align.Left;
					float num15 = base.MViewPortHandler.OffsetLeft() + num7;
					float num16 = array[1] + num8;
					if (backgroundLimitLine != null)
					{
						canvas.DrawRect(num15, num16 - num6, num15 + num5 + num2, num16 + num4, BackgroundPaint);
					}
					canvas.DrawText(label, num15 + num, num16 + num3, base.MLimitLinePaint);
				}
			}
		}
	}
	public class BaseLineChart : BaseLineChartController<ChartMetric>
	{
		private const int UpdateDelayMs = 1000;

		private bool isUpdatingChart;

		private IDisposable updateAndInvalidateChartSub;

		private bool isDisposing;

		private LineData chartData;

		private LimitLine currentLine;

		private Entry currentEntry = new Entry(0f, 0f);

		private Entry currentEntry2 = new Entry(0f, 0f);

		private Entry currentEntry3 = new Entry(0f, 0f);

		private Entry currentEntry4 = new Entry(0f, 0f);

		private Entry currentEntry5 = new Entry(0f, 0f);

		private Entry currentEntry6 = new Entry(0f, 0f);

		private bool _shouldBeInvalidatingChart;

		private Tuple<double, double> _current;

		private Tuple<double, double> _current2;

		private Tuple<double, double> _current3;

		private Tuple<double, double> _current4;

		private Tuple<double, double> _current5;

		private Tuple<double, double> _current6;

		private bool _showLeftAxis;

		private bool _showRightAxis;

		public LineChart LineChart { get; protected set; }

		public bool ShouldBeInvalidatingChart
		{
			get
			{
				return _shouldBeInvalidatingChart;
			}
			set
			{
				_shouldBeInvalidatingChart = value;
				if (_shouldBeInvalidatingChart)
				{
					StartUpdating();
				}
				else
				{
					StopUpdating();
				}
			}
		}

		public Color CurrentLimitLineColor { get; set; } = Color.Gray;

		public Tuple<double, double> Current1
		{
			get
			{
				return _current;
			}
			set
			{
				_current = value;
				currentEntry.SetX((int)_current.Item1);
				currentEntry.SetY((float)(base.CurrentMetric.Scaler?.ScaleValue(_current.Item2) ?? _current.Item2));
			}
		}

		public Tuple<double, double> Current2
		{
			get
			{
				return _current2;
			}
			set
			{
				_current2 = value;
				currentEntry2.SetX((int)_current2.Item1);
				currentEntry2.SetY((float)(base.CurrentMetric2.Scaler?.ScaleValue(_current2.Item2) ?? _current2.Item2));
			}
		}

		public Tuple<double, double> Current3
		{
			get
			{
				return _current3;
			}
			set
			{
				_current3 = value;
				currentEntry3.SetX((int)_current3.Item1);
				currentEntry3.SetY((float)(base.CurrentMetric3.Scaler?.ScaleValue(_current3.Item2) ?? _current3.Item2));
			}
		}

		public Tuple<double, double> Current4
		{
			get
			{
				return _current4;
			}
			set
			{
				_current4 = value;
				currentEntry4.SetX((int)_current4.Item1);
				currentEntry4.SetY((float)(base.CurrentMetric4.Scaler?.ScaleValue(_current4.Item2) ?? _current4.Item2));
			}
		}

		public Tuple<double, double> Current5
		{
			get
			{
				return _current5;
			}
			set
			{
				_current5 = value;
				currentEntry5.SetX((int)_current5.Item1);
				currentEntry5.SetY((float)(base.CurrentMetric5.Scaler?.ScaleValue(_current5.Item2) ?? _current5.Item2));
			}
		}

		public Tuple<double, double> Current6
		{
			get
			{
				return _current6;
			}
			set
			{
				_current6 = value;
				currentEntry6.SetX((int)_current6.Item1);
				currentEntry6.SetY((float)(base.CurrentMetric6.Scaler?.ScaleValue(_current6.Item2) ?? _current6.Item2));
			}
		}

		public double MaxXValue { get; set; }

		public bool ShowLeftAxis
		{
			get
			{
				return _showLeftAxis;
			}
			set
			{
				_showLeftAxis = value;
				LineChart.AxisLeft.SetDrawLabels(value);
			}
		}

		public bool ShowRightAxis
		{
			get
			{
				return _showRightAxis;
			}
			set
			{
				_showRightAxis = value;
				LineChart.AxisRight.SetDrawLabels(value);
			}
		}

		public XAxisValueFormatter XAxisFormatter
		{
			get
			{
				return LineChart.XAxis.ValueFormatter as XAxisValueFormatter;
			}
			set
			{
				LineChart.XAxis.ValueFormatter = value;
			}
		}

		public BaseLineChart(Context context)
		{
			LineChart = new LineChart(context);
			StyleChart();
			base.CurrentMetric.DataSet = new LineDataSet(new Entry[1] { currentEntry }, "Current");
			base.CurrentMetric2.DataSet = new LineDataSet(new Entry[1] { currentEntry2 }, "Current2");
			base.CurrentMetric3.DataSet = new LineDataSet(new Entry[1] { currentEntry3 }, "Current3");
			base.CurrentMetric4.DataSet = new LineDataSet(new Entry[1] { currentEntry4 }, "Current4");
			base.CurrentMetric5.DataSet = new LineDataSet(new Entry[1] { currentEntry5 }, "Current5");
			base.CurrentMetric6.DataSet = new LineDataSet(new Entry[1] { currentEntry6 }, "Current6");
		}

		public override void Dispose()
		{
			isDisposing = true;
			base.Dispose();
			updateAndInvalidateChartSub?.Dispose();
			updateAndInvalidateChartSub = null;
			chartData?.Dispose();
			chartData = null;
			currentLine?.Dispose();
			currentLine = null;
			currentEntry?.Dispose();
			currentEntry = null;
			currentEntry2?.Dispose();
			currentEntry2 = null;
			currentEntry3?.Dispose();
			currentEntry3 = null;
			currentEntry4?.Dispose();
			currentEntry4 = null;
			currentEntry5?.Dispose();
			currentEntry5 = null;
			currentEntry6?.Dispose();
			currentEntry6 = null;
			LineChart.Dispose();
			LineChart = null;
		}

		public void ApplyFillGradient(LineDataSet dataSet, Drawable gradient)
		{
			dataSet.SetColor(Color.Transparent, Color.Transparent.A);
			dataSet.FillDrawable = gradient;
			dataSet.FillFormatter = new CustomChartFillFormatter();
			dataSet.SetDrawFilled(filled: true);
		}

		public void AddLimitLine(YAxis.AxisDependency axis, LimitLine line)
		{
			if (axis == YAxis.AxisDependency.Left)
			{
				LineChart.AxisLeft.AddLimitLine(line);
			}
			else
			{
				LineChart.AxisRight.AddLimitLine(line);
			}
		}

		public void RemoveLimitLine(YAxis.AxisDependency axis, LimitLine line)
		{
			if (axis == YAxis.AxisDependency.Left)
			{
				LineChart.AxisLeft.RemoveLimitLine(line);
			}
			else
			{
				LineChart.AxisRight.RemoveLimitLine(line);
			}
		}

		public override void AdjustXAxisMaxValue(double newIndex)
		{
			if (base.AddLabelsEnabled && newIndex >= (double)(LineChart.XAxis.AxisMaximum * 0.75f))
			{
				if (newIndex - (double)LineChart.XAxis.AxisMaximum <= 5.0)
				{
					LineChart.XAxis.AxisMaximum += 5f;
				}
				else
				{
					LineChart.XAxis.AxisMaximum = (float)(newIndex * 1.3333333333333333);
				}
			}
		}

		private void StyleChart()
		{
			LineChart.Description = null;
			LineChart.Legend.Enabled = false;
			LineChart.XAxis.SetDrawLimitLinesBehindData(enabled: true);
			LineChart.SetDrawBorders(enabled: false);
			LineChart.XAxis.SetDrawGridLines(enabled: false);
			LineChart.XAxis.Position = XAxis.XAxisPosition.Bottom;
			LineChart.AxisLeft.SetDrawAxisLine(enabled: false);
			LineChart.AxisLeft.SetDrawGridLines(enabled: false);
			LineChart.AxisLeft.SetDrawZeroLine(mDrawZeroLine: false);
			LineChart.AxisRight.SetDrawAxisLine(enabled: false);
			LineChart.AxisRight.SetDrawTopYLabelEntry(enabled: false);
			LineChart.AxisRight.SetDrawGridLines(enabled: false);
			LineChart.AxisRight.SetDrawZeroLine(mDrawZeroLine: false);
			LineChart.AxisRight.SetDrawLimitLinesBehindData(enabled: false);
		}

		public void ClearCustomStyleActions()
		{
			ChartMetric[] array = metrics;
			foreach (ChartMetric chartMetric in array)
			{
				chartMetric.CustomStyleMetric = null;
			}
		}

		public override void InitializeChartView()
		{
			base.CurrentMetric.StyleMetric();
			base.CurrentMetric2.StyleMetric();
			base.CurrentMetric3.StyleMetric();
			base.CurrentMetric4.StyleMetric();
			base.CurrentMetric5.StyleMetric();
			base.CurrentMetric6.StyleMetric();
			List<ILineDataSet> list = new List<ILineDataSet>();
			for (int num = metrics.Length - 1; num >= 0; num--)
			{
				ChartMetric chartMetric = metrics[num];
				if (chartMetric.DataSet != null && chartMetric.ShowMetric)
				{
					if (chartMetric.DataSet.IsDrawFilledEnabled)
					{
						list.Insert(0, chartMetric.DataSet);
					}
					else
					{
						list.Add(chartMetric.DataSet);
					}
				}
			}
			chartData = new LineData(list);
			SetLeftAxisRange();
			SetRightAxisRange();
			SetXAxisRange();
			if (base.LeftAxisIsPercent)
			{
				LineChart.AxisLeft.ValueFormatter = new iFitPercentFormatter();
			}
			if (base.RightAxisIsPercent)
			{
				LineChart.AxisRight.ValueFormatter = new iFitPercentFormatter();
			}
			LineChart.Data = chartData;
		}

		public void StartUpdating()
		{
			updateAndInvalidateChartSub?.Dispose();
			updateAndInvalidateChartSub = Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000.0)).SubscribeWithErrorLogging(delegate
			{
				Task.Run((Func<Task>)ApplyChangesAndUpdate);
			});
		}

		public void StopUpdating()
		{
			updateAndInvalidateChartSub?.Dispose();
			updateAndInvalidateChartSub = null;
		}

		protected override void SetLeftAxisRange()
		{
			LineChart.AxisLeft.SetDrawLabels(ShowLeftAxis);
			LineChart.AxisLeft.SetDrawTopYLabelEntry(ShowLeftAxis);
			if (base.LeftAxisMax.HasValue && base.LeftAxisMin.HasValue)
			{
				LineChart.AxisLeft.SetAxisMaxValue(base.LeftAxisIsPercent ? (base.LeftAxisMax.Value / 100f) : base.LeftAxisMax.Value);
				LineChart.AxisLeft.SetAxisMinValue(base.LeftAxisIsPercent ? (base.LeftAxisMin.Value / 100f) : base.LeftAxisMin.Value);
			}
		}

		protected override void SetRightAxisRange()
		{
			LineChart.AxisRight.SetDrawLabels(ShowRightAxis);
			if (base.RightAxisMax.HasValue && base.RightAxisMin.HasValue)
			{
				LineChart.AxisRight.SetAxisMaxValue(base.RightAxisIsPercent ? (base.RightAxisMax.Value / 100f) : base.RightAxisMax.Value);
				LineChart.AxisRight.SetAxisMinValue(base.RightAxisIsPercent ? (base.RightAxisMin.Value / 100f) : base.RightAxisMin.Value);
				LineChart.AxisRight.SetLabelCount(7, force: true);
			}
		}

		private void SetXAxisRange()
		{
			LineChart.XAxis.SetAxisMaxValue((float)MaxXValue);
			LineChart.XAxis.SetAxisMinValue(0f);
		}

		public async Task ApplyChangesAndUpdate()
		{
			if (!DoRefresh || isUpdatingChart || LineChart == null || metrics == null)
			{
				return;
			}
			isUpdatingChart = true;
			try
			{
				await Task.WhenAll(metrics.Select((ChartMetric m) => m?.ApplyDataChanges())).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (RuntimeException exception)
			{
				iFit.Logger.Log.Debug("Charting", "Caught a RuntimeException while updating chart", exception);
			}
			if (ShouldBeInvalidatingChart)
			{
				if (LineChart?.Context is Activity activity)
				{
					activity.RunOnUiThread(UpdateAndInvalidateChart);
				}
				else
				{
					isUpdatingChart = false;
				}
			}
			else
			{
				isUpdatingChart = false;
			}
		}

		private void UpdateAndInvalidateChart()
		{
			if (ShouldBeInvalidatingChart)
			{
				if (Current1 != null)
				{
					DrawCurrentLimitLine((int)Current1.Item1);
				}
				LineChart?.NotifyDataSetChanged();
				LineChart?.Invalidate();
			}
			isUpdatingChart = false;
		}

		private void DrawCurrentLimitLine(int xPosition)
		{
			if (!isDisposing && LineChart != null)
			{
				if (currentLine != null)
				{
					LineChart.XAxis.RemoveLimitLine(currentLine);
					currentLine.Dispose();
				}
				currentLine = new LimitLine(xPosition)
				{
					LineColor = CurrentLimitLineColor
				};
				LineChart.XAxis.AddLimitLine(currentLine);
			}
		}
	}
	public class ChartMetric : BaseChartMetric
	{
		private BaseLineChart chartController;

		private YAxis.AxisDependency _axis;

		public LineDataSet DataSet { get; set; }

		public YAxis.AxisDependency Axis
		{
			get
			{
				return _axis;
			}
			set
			{
				_axis = value;
				if (DataSet != null)
				{
					DataSet.AxisDependency = _axis;
				}
			}
		}

		public Action<LineDataSet> CustomStyleMetric { get; set; }

		public Action<LineDataSet> LineDataSetUpdated { get; set; }

		public ChartMetric(DataSetId id, BaseLineChart chartController)
			: base(id)
		{
			this.chartController = chartController;
			base.ThreadConsolidator = new DataThreadConsolidator(this);
		}

		public override void Dispose()
		{
			chartController = null;
			DataSet?.Dispose();
			DataSet = null;
			Axis?.Dispose();
			Axis = null;
			CustomStyleMetric = null;
			base.ThreadConsolidator?.Dispose();
			base.ThreadConsolidator = null;
			base.Dispose();
		}

		public override void AdjustXAxisMaxValue(double newIndex)
		{
			chartController.AdjustXAxisMaxValue(newIndex);
		}

		public override async Task ApplyDataChanges()
		{
			if (base.ThreadConsolidator is DataThreadConsolidator dataThreadConsolidator)
			{
				await dataThreadConsolidator.ApplyDataChanges(DataSet);
			}
			LineDataSetUpdated?.Invoke(DataSet);
			DataSet?.NotifyDataSetChanged();
		}

		protected override void InitializeMetricDataSet()
		{
			if (DataSet != null)
			{
				chartController.LineChart.Data?.RemoveDataSet(DataSet);
			}
			if (metric != null)
			{
				DataSet = new StrokeCapJoinLineDataSet(metric.ToList().ConvertAll((Tuple<double, double> x) => new Entry((int)x.Item1, (float)(base.Scaler?.ScaleValue(x.Item2) ?? x.Item2))), base.Label)
				{
					AxisDependency = Axis
				};
				CustomStyleMetric?.Invoke(DataSet);
			}
			if (base.ShowMetric)
			{
				chartController.LineChart.Data?.AddDataSet(DataSet);
			}
			chartController.LineChart.NotifyDataSetChanged();
		}

		protected override void SetShowMetric(bool value)
		{
			if (_showMetric != value)
			{
				_showMetric = value;
				if (DataSet != null)
				{
					DataSet.Visible = value;
				}
			}
		}

		public void StyleMetric()
		{
			if (DataSet != null)
			{
				CustomStyleMetric?.Invoke(DataSet);
			}
		}
	}
	public class CustomChartFillFormatter : Java.Lang.Object, IFillFormatter, IJavaObject, IDisposable
	{
		public float GetFillLinePosition(ILineDataSet dataSet, ILineDataProvider dataProvider)
		{
			return dataProvider.YChartMin;
		}
	}
	public class DataThreadConsolidator(ChartMetric parent) : BaseDataThreadConsolidator(parent)
	{
		private ConcurrentBag<Entry> entryObjectPool = new ConcurrentBag<Entry>();

		public async Task ApplyDataChanges(LineDataSet set)
		{
			if (set != null)
			{
				if (RemoveList.Count > 0)
				{
					await ProcessRemoveData(set).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (AddList.Count > 0)
				{
					await ProcessAddData(set).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (ReplaceList.Count > 0)
				{
					await ProcessReplaceData(set).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}

		private async Task ProcessAddData(LineDataSet set)
		{
			await dataProcessingLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			await dataIntegrityLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			List<Tuple<double, double>> list = new List<Tuple<double, double>>(AddList);
			AddList.Clear();
			dataIntegrityLock.Release();
			foreach (Tuple<double, double> item in list)
			{
				parent.AdjustXAxisMaxValue(item.Item1);
				set.AddEntryOrdered(new Entry((int)item.Item1, (float)(base.Scaler?.ScaleValue(item.Item2) ?? item.Item2)));
			}
			dataProcessingLock.Release();
		}

		private async Task ProcessRemoveData(LineDataSet set)
		{
			await dataProcessingLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			await dataIntegrityLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			List<Tuple<double, double>> processList = new List<Tuple<double, double>>(RemoveList);
			RemoveList.Clear();
			dataIntegrityLock.Release();
			TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
			dispatcher.RequestMainThreadAction(delegate
			{
				foreach (Tuple<double, double> item in processList)
				{
					((IDataSet)set).RemoveEntryByXValue((float)(int)item.Item1);
				}
				tcs.SetResult(result: true);
			});
			await tcs.Task;
			dataProcessingLock.Release();
		}

		private async Task ProcessReplaceData(LineDataSet set)
		{
			await dataProcessingLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			await dataIntegrityLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			List<ReplaceDataContainer> replace = new List<ReplaceDataContainer>(ReplaceList);
			ReplaceList.Clear();
			dataIntegrityLock.Release();
			TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
			dispatcher.RequestMainThreadAction(delegate
			{
				if (entryObjectPool != null)
				{
					foreach (ReplaceDataContainer item in replace)
					{
						foreach (Tuple<double, double> oldDatum in item.OldData)
						{
							Entry entry = set.GetEntryForXValue((int)oldDatum.Item1, 0f / 0f) as Entry;
							set.RemoveEntry(entry);
							entryObjectPool.Add(entry);
						}
						foreach (Tuple<double, double> newDatum in item.NewData)
						{
							parent.AdjustXAxisMaxValue(newDatum.Item1);
							if (entryObjectPool.TryTake(out var result))
							{
								result.SetX((int)newDatum.Item1);
								result.SetY((float)(base.Scaler?.ScaleValue(newDatum.Item2) ?? newDatum.Item2));
								set.AddEntryOrdered(result);
							}
							else
							{
								set.AddEntryOrdered(new Entry((int)newDatum.Item1, (float)(base.Scaler?.ScaleValue(newDatum.Item2) ?? newDatum.Item2)));
							}
						}
					}
					tcs.SetResult(result: true);
				}
			});
			await tcs.Task;
			dataProcessingLock.Release();
		}

		public override void Dispose()
		{
			entryObjectPool.Clear();
			entryObjectPool = null;
			base.Dispose();
		}
	}
	public class StrokeCapJoinLineChartRenderer : LineChartRenderer
	{
		public StrokeCapJoinLineChartRenderer(ILineDataProvider chart, ChartAnimator animator, ViewPortHandler viewPortHandler)
			: base(chart, animator, viewPortHandler)
		{
		}

		protected override void DrawDataSet(Canvas canvas, ILineDataSet lineDataSet)
		{
			StrokeCapJoinLineDataSet strokeCapJoinLineDataSet = lineDataSet as StrokeCapJoinLineDataSet;
			base.MRenderPaint.StrokeCap = ((strokeCapJoinLineDataSet != null) ? strokeCapJoinLineDataSet.StrokeCap : Paint.Cap.Butt);
			base.MRenderPaint.StrokeJoin = ((strokeCapJoinLineDataSet != null) ? strokeCapJoinLineDataSet.StrokeJoin : Paint.Join.Miter);
			try
			{
				base.DrawDataSet(canvas, lineDataSet);
			}
			catch (IndexOutOfBoundsException ex)
			{
				iFit.Logger.Log.Trace("Charting", "Error drawing chart: " + ex.Message);
			}
		}
	}
	public class StrokeCapJoinLineDataSet : LineDataSet
	{
		public Paint.Cap StrokeCap { get; set; } = Paint.Cap.Butt;

		public Paint.Join StrokeJoin { get; set; } = Paint.Join.Miter;

		public StrokeCapJoinLineDataSet(IList<Entry> p0, string p1)
			: base(p0, p1)
		{
		}
	}
	public class XAxisValueFormatter : Java.Lang.Object, IAxisValueFormatter, IJavaObject, IDisposable
	{
		private readonly IChartLabelUtil chartLabelUtil;

		public bool IsMetric { get; set; }

		public XAxisValueFormatter(IChartLabelUtil chartLabelUtil)
		{
			this.chartLabelUtil = chartLabelUtil;
		}

		public string GetFormattedValue(float value, AxisBase axis)
		{
			return chartLabelUtil.ResolveLabel((long)value, IsMetric);
		}
	}
}
namespace Shire.Android.BuiltIn.UpdateCheck
{
	public class ConsoleUpdatePool : IConsoleUpdatePool
	{
		private const string prodLdMobileKey = "mob-0f62dc51-03af-4483-bec9-7b89f0863caf";

		private const string testLdMobileKey = "mob-a6143a25-bb8c-44f4-b291-3bd7e0f19f36";

		private const string UpdatePoolAttributeKey = "updatePool";

		private const string OSVersionAttributeKey = "osVersion";

		private const string SoftwareNumberAttributeKey = "softwareNumber";

		private Application application;

		public ConsoleUpdatePool(Application application)
		{
			this.application = application;
		}

		public async Task Send(UpdateInfo updateInfo, string osVersion = "", int softwareNumber = -1, bool testEnvironment = false)
		{
			string mobileKey = (testEnvironment ? "mob-a6143a25-bb8c-44f4-b291-3bd7e0f19f36" : "mob-0f62dc51-03af-4483-bec9-7b89f0863caf");
			LDConfig config = new LDConfig.Builder().MobileKey(mobileKey).Build();
			LDUser user = new LDUser.Builder(updateInfo.Guid.ToString("D")).Custom("updatePool", updateInfo.Pool.ToString()).Custom("osVersion", osVersion).Custom("softwareNumber", $"{softwareNumber}")
				.Build();
			IFuture self = LDClient.Init(application, config, user);
			await self.GetAsync();
		}
	}
}
namespace Shire.Android.Ble
{
	public static class BleUtils
	{
		public static BondState GetCurrentBondState(this BluetoothDevice device)
		{
			return device.BondState switch
			{
				Bond.Bonded => BondState.Bonded, 
				Bond.Bonding => BondState.Bonding, 
				_ => BondState.Unbonded, 
			};
		}
	}
	public class ScannerFlags : IScannerFlags
	{
		private readonly IFeatureFlagManager featureFlagManager;

		public ScannerFlags(IFeatureFlagManager featureFlagManager)
		{
			this.featureFlagManager = featureFlagManager;
		}

		public bool IsBondedHrMonitorEnabled()
		{
			return featureFlagManager.IsFeatureEnabled(FeatureFlags.BondedHrMonitorEnabled);
		}
	}
}
namespace Shire.Android.Ble.Headphone
{
	public class Headphone : HeadphoneBase
	{
		public MajorDeviceClass? BluetoothMajorDeviceClass { get; }

		public DeviceClass? BluetoothDeviceClass { get; }

		public bool HasAudioService { get; }

		public Headphone(BluetoothDevice device, int rssi = 0)
			: base(new System.Text.StringBuilder(device.Name).ToString(), new System.Text.StringBuilder(device.Address).ToString(), rssi)
		{
			BluetoothMajorDeviceClass = device.BluetoothClass?.MajorDeviceClass;
			BluetoothDeviceClass = device.BluetoothClass?.DeviceClass;
			HasAudioService = device.BluetoothClass?.HasService(ServiceClass.Audio) ?? false;
		}

		public override string ToString()
		{
			return "{Headphone \"" + base.Name + "\" [" + base.Address + "]}";
		}
	}
	public class HeadphoneConnectionHelper : HeadphoneConnectionHelperBase
	{
		private readonly IPersistentBluetoothDevices persistentBluetoothDevices;

		private static ProfileProxyService profileProxyService;

		private readonly BluetoothAdapter adapter;

		private readonly Context context;

		private readonly Task initialProfileProxyServiceWait;

		private RxBroadcastReceiver broadcastReceiver;

		private RxBroadcastReceiver connectedBroadcastReceiver;

		private RxBroadcastReceiver disconnectedBroadcastReceiver;

		private IDisposable broadcastReceiverSub;

		private IDisposable connectedBroadcastReceiverSub;

		private IDisposable disconnectedBroadcastReceiverSub;

		private IDisposable onBondStateChangedSub;

		private IDisposable onConnectionStateConnectedSub;

		private CancellationTokenSource unbondCanceller;

		private Subject<Headphone> onBondStateChange = new Subject<Headphone>();

		private Subject<Headphone> onConnectionStateChanged = new Subject<Headphone>();

		private bool wasPreviouslyConnected;

		public override bool DoesConnectingDuringPlaybackStopBuffering => Build.VERSION.SdkInt <= BuildVersionCodes.LollipopMr1;

		public override event EventHandler ScanEnded;

		protected HeadphoneConnectionHelper(Context context, IHeadphoneScanner scanner, IBleRadioStatusService bleRadioStatusService, HeadphoneDeviceFilterBase filter, ICoreAnalytics coreAnalytics, IPersistentBluetoothDevices persistentBluetoothDevices)
			: base(scanner, bleRadioStatusService, filter, coreAnalytics)
		{
			this.context = context;
			this.persistentBluetoothDevices = persistentBluetoothDevices;
			adapter = BluetoothAdapter.DefaultAdapter;
			if (adapter == null)
			{
				iFit.Logger.Log.Error("HeadphoneConnectionHelper", "Device is incapable of Bluetooth");
				return;
			}
			scanner.Ended += OnScannerEnded;
			if (profileProxyService == null)
			{
				profileProxyService = new ProfileProxyService();
			}
			profileProxyService.Init(adapter, context);
			initialProfileProxyServiceWait = profileProxyService.WaitForProxies();
			wasPreviouslyConnected = IsConnected();
			_OnConnected.OnNext(wasPreviouslyConnected);
			CreateConnectedBroadcastReceiver();
			CreateDisconnectedBroadcastReceiver();
		}

		public sealed override bool IsConnected()
		{
			BluetoothAdapter bluetoothAdapter = adapter;
			if (bluetoothAdapter == null || bluetoothAdapter.GetProfileConnectionState(ProfileType.A2dp) != ProfileState.Connected)
			{
				BluetoothAdapter bluetoothAdapter2 = adapter;
				if (bluetoothAdapter2 == null)
				{
					return false;
				}
				return bluetoothAdapter2.GetProfileConnectionState(ProfileType.Headset) == ProfileState.Connected;
			}
			return true;
		}

		protected override bool IsReceivingBroadcasts()
		{
			return broadcastReceiver != null;
		}

		protected sealed override ConnectionState GetConnectionState(IHeadphone headphone)
		{
			using (BluetoothDevice bluetoothDevice = GetBluetoothDevice(headphone))
			{
				if (bluetoothDevice == null)
				{
					iFit.Logger.Log.Error("HeadphoneConnectionHelper", string.Format("{0} could not get BluetoothDevice for {1}", "GetConnectionState", headphone));
					return ConnectionState.Disconnected;
				}
				ProfileState? profileState = profileProxyService.A2dp?.GetConnectionState(bluetoothDevice);
				ProfileState? profileState2 = profileProxyService.Headset?.GetConnectionState(bluetoothDevice);
				if (profileState == ProfileState.Connected || profileState2 == ProfileState.Connected)
				{
					return ConnectionState.Connected;
				}
				if (profileState == ProfileState.Connecting || profileState2 == ProfileState.Connecting)
				{
					return ConnectionState.Connecting;
				}
			}
			return ConnectionState.Disconnected;
		}

		private BluetoothDevice GetBluetoothDevice(IHeadphone headphone)
		{
			if (headphone == null)
			{
				iFit.Logger.Log.Error("HeadphoneConnectionHelper", "GetBluetoothDevice called with null headphone.");
				return null;
			}
			try
			{
				return adapter.GetRemoteDevice(headphone.Address);
			}
			catch (System.Exception ex)
			{
				iFit.Logger.Log.Error("HeadphoneConnectionHelper", ex.GetType().Name + " in GetBluetoothDevice: ", ex);
			}
			return null;
		}

		public override BondState GetCurrentBondState(IHeadphone headphone)
		{
			using BluetoothDevice bluetoothDevice = GetBluetoothDevice(headphone);
			if (bluetoothDevice == null)
			{
				iFit.Logger.Log.Error("HeadphoneConnectionHelper", string.Format("{0} could not get BluetoothDevice for {1}", "GetCurrentBondState", headphone));
				return BondState.Unbonded;
			}
			return bluetoothDevice.GetCurrentBondState();
		}

		protected override async Task DoStart()
		{
			iFit.Logger.Log.Trace("HeadphoneConnectionHelper", "HeadphoneConnectionHelper Bluetooth Adapter State: " + adapter.State);
			await initialProfileProxyServiceWait.ConfigureAwait(continueOnCapturedContext: false);
			CreateBroadcastReceiver();
			onBondStateChangedSub?.Dispose();
			onBondStateChangedSub = onBondStateChange.Subscribe(OnBondStateChanged);
			onConnectionStateConnectedSub?.Dispose();
			onConnectionStateConnectedSub = onConnectionStateChanged.Subscribe(OnConnectionStateChanged);
		}

		private void CreateConnectedBroadcastReceiver()
		{
			IntentFilter intentFilter = new IntentFilter("android.bluetooth.a2dp.profile.action.CONNECTION_STATE_CHANGED");
			intentFilter.AddAction("android.bluetooth.headset.profile.action.CONNECTION_STATE_CHANGED");
			connectedBroadcastReceiver = new RxBroadcastReceiver(intentFilter);
			connectedBroadcastReceiverSub = connectedBroadcastReceiver.WhenBroadcastReceived.Subscribe(OnConnectedBroadcastReceived);
			connectedBroadcastReceiver.StartListening(context);
		}

		private void CreateDisconnectedBroadcastReceiver()
		{
			IntentFilter intentFilter = new IntentFilter("android.bluetooth.device.action.ACL_DISCONNECTED");
			disconnectedBroadcastReceiver = new RxBroadcastReceiver(intentFilter);
			disconnectedBroadcastReceiverSub = disconnectedBroadcastReceiver.WhenBroadcastReceived.Subscribe(OnDisconnectedBroadcastReceived);
			disconnectedBroadcastReceiver.StartListening(context);
		}

		private void CreateBroadcastReceiver()
		{
			CleanUpBroadcastReceiver();
			IntentFilter intentFilter = new IntentFilter("android.bluetooth.device.action.BOND_STATE_CHANGED");
			intentFilter.AddAction("android.bluetooth.a2dp.profile.action.CONNECTION_STATE_CHANGED");
			intentFilter.AddAction("android.bluetooth.headset.profile.action.CONNECTION_STATE_CHANGED");
			broadcastReceiver = new RxBroadcastReceiver(intentFilter);
			broadcastReceiverSub = broadcastReceiver.WhenBroadcastReceived.Subscribe(OnBroadcastReceived);
			broadcastReceiver.StartListening(context);
		}

		protected override void PopulateBondedDevices()
		{
			List<BluetoothDevice> list = adapter?.BondedDevices?.ToList();
			if (list == null)
			{
				return;
			}
			foreach (BluetoothDevice item in list)
			{
				Headphone headphone = new Headphone(item);
				if (Filter.IsDeviceValid(headphone))
				{
					iFit.Logger.Log.Info("HeadphoneConnectionHelper", string.Format("{0} found bonded device: {1}", "PopulateBondedDevices", headphone));
				}
				else
				{
					if (persistentBluetoothDevices.IsBondedDeviceAnHrm(headphone.Id))
					{
						iFit.Logger.Log.Trace("HeadphoneConnectionHelper", $"Bluetooth bonded device not a heart rate monitor, not adding to list: {headphone}" + $" DeviceClass={item?.BluetoothClass?.DeviceClass}");
						continue;
					}
					iFit.Logger.Log.Warn("HeadphoneConnectionHelper", $"Bluetooth bonded device not a valid headphone: {headphone}" + $" DeviceClass={item?.BluetoothClass?.DeviceClass}");
				}
				_onDeviceFound.OnNext(headphone);
			}
			list.TryDisposeAll();
		}

		protected override async Task<bool> TryConnect(IHeadphone headphone, bool retry)
		{
			using (BluetoothDevice device = GetBluetoothDevice(headphone))
			{
				if (device == null)
				{
					iFit.Logger.Log.Error("HeadphoneConnectionHelper", string.Format("{0} could not get BluetoothDevice for {1}", "TryConnect", headphone));
					return true;
				}
				if (TryConnect(profileProxyService.A2dp, device) || TryConnect(profileProxyService.Headset, device))
				{
					await BondThenConnect(headphone, bond: false, retry).ConfigureAwait(continueOnCapturedContext: false);
					return true;
				}
			}
			return false;
		}

		protected override bool CreateBond(IHeadphone headphone)
		{
			using BluetoothDevice bluetoothDevice = GetBluetoothDevice(headphone);
			if (bluetoothDevice == null)
			{
				iFit.Logger.Log.Error("HeadphoneConnectionHelper", string.Format("{0} could not get BluetoothDevice for {1}", "CreateBond", headphone));
			}
			return bluetoothDevice?.CreateBond() ?? false;
		}

		protected override IObservable<Guid> GetBondingHeadphoneIds()
		{
			return (from x in onBondStateChange
				where GetCurrentBondState(x) != BondState.Bonding
				select x.Id).AsObservable();
		}

		protected override IObservable<IHeadphone> GetConnectingHeadphones()
		{
			return onConnectionStateChanged.AsObservable();
		}

		protected override async Task Bounce()
		{
			if (!Mvx.TryResolve<IBleRadioStatusService>(out var service))
			{
				iFit.Logger.Log.Error("HeadphoneConnectionHelper", "IBleRadioStatusService not found, not cycling");
				return;
			}
			if (!(service is BleRadioStatusService bleRadioStatusService))
			{
				iFit.Logger.Log.Error("HeadphoneConnectionHelper", $"IBleRadioStatusService is {service.GetType()}, required {typeof(BleRadioStatusService)}, not cycling");
				return;
			}
			iFit.Logger.Log.Trace("HeadphoneConnectionHelper", "Cycling Bluetooth Radio");
			Task<bool> task = bleRadioStatusService.WhenBluetoothRadioEnabledChanged.Where((bool isEnabled) => isEnabled).Timeout(TimeSpan.FromSeconds(30.0)).FirstAsync()
				.ToTask();
			bleRadioStatusService.CycleBluetoothRadio();
			try
			{
				await task.ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (TimeoutException exception)
			{
				iFit.Logger.Log.Error("HeadphoneConnectionHelper", "Bluetooth radio not re-enabled!", exception);
				return;
			}
			await profileProxyService.WaitForProxies().ConfigureAwait(continueOnCapturedContext: false);
		}

		private static bool TryConnect<T>(T profile, BluetoothDevice device) where T : Java.Lang.Object, IBluetoothProfile
		{
			Method method = profile?.Class?.GetDeclaredMethod("connect", device.Class);
			iFit.Logger.Log.Trace("HeadphoneConnectionHelper", $"Connecting with {profile} to {device}");
			Java.Lang.Object obj = method?.Invoke(profile, device);
			return obj == Java.Lang.Boolean.True;
		}

		public override async Task<bool> UnbondWithDevice(IHeadphone headphone)
		{
			using (BluetoothDevice device = GetBluetoothDevice(headphone))
			{
				unbondCanceller?.Cancel();
				unbondCanceller?.Dispose();
				unbondCanceller = new CancellationTokenSource();
				try
				{
					await BleDeviceUnbondHelper.RemoveBond(context, device, unbondCanceller.Token);
				}
				finally
				{
					unbondCanceller?.Dispose();
					unbondCanceller = null;
				}
			}
			return true;
		}

		protected override IEnumerable<IHeadphone> GetBondedHeadphones()
		{
			if (adapter == null)
			{
				iFit.Logger.Log.Error("HeadphoneConnectionHelper", "UnbondWithAllDevices - Bluetooth is not supported on this hardware platform");
				return new IHeadphone[0];
			}
			if (!IsReceivingBroadcasts())
			{
				CreateBroadcastReceiver();
			}
			List<BluetoothDevice> list = adapter.BondedDevices?.ToList();
			List<Headphone> result = list?.Select((BluetoothDevice x) => new Headphone(x))?.ToList();
			list.TryDisposeAll();
			return result;
		}

		protected override void DisposeCancellersAndCleanupBroadcastReceiver()
		{
			base.DisposeCancellersAndCleanupBroadcastReceiver();
			unbondCanceller?.Dispose();
			unbondCanceller = null;
			CleanUpBroadcastReceiver();
		}

		public override void Stop()
		{
			base.Stop();
			unbondCanceller?.Cancel();
			DisposeCancellersAndCleanupBroadcastReceiver();
		}

		public override void Dispose()
		{
			Scanner.Ended -= OnScannerEnded;
			onBondStateChange?.Dispose();
			onBondStateChange = null;
			onConnectionStateChanged?.Dispose();
			onConnectionStateChanged = null;
			connectedBroadcastReceiverSub?.Dispose();
			connectedBroadcastReceiverSub = null;
			connectedBroadcastReceiver?.Dispose();
			connectedBroadcastReceiver = null;
			disconnectedBroadcastReceiverSub?.Dispose();
			disconnectedBroadcastReceiverSub = null;
			disconnectedBroadcastReceiver?.Dispose();
			disconnectedBroadcastReceiver = null;
			DisposeCancellersAndCleanupBroadcastReceiver();
			base.Dispose();
		}

		private void CleanUpBroadcastReceiver()
		{
			broadcastReceiverSub?.Dispose();
			broadcastReceiverSub = null;
			broadcastReceiver?.Dispose();
			broadcastReceiver = null;
			onBondStateChangedSub?.Dispose();
			onBondStateChangedSub = null;
			onConnectionStateConnectedSub?.Dispose();
			onConnectionStateConnectedSub = null;
		}

		private void OnScannerEnded(object sender, EventArgs args)
		{
			ScanEnded?.Invoke(sender, args);
		}

		private void OnBondStateChanged(Headphone headphone)
		{
			_onStateChanged.OnNext(headphone.Id);
		}

		private void OnConnectionStateChanged(Headphone headphone)
		{
			_onStateChanged.OnNext(headphone.Id);
		}

		private void OnBroadcastReceived(Intent intent)
		{
			string action = intent.Action;
			if (!(intent.GetParcelableExtra("android.bluetooth.device.extra.DEVICE") is BluetoothDevice device))
			{
				iFit.Logger.Log.Error("HeadphoneConnectionHelper", "OnBroadcastReceived could not parse BluetoothDevice from intent");
				return;
			}
			Headphone value = new Headphone(device);
			switch (action)
			{
			case "android.bluetooth.device.action.BOND_STATE_CHANGED":
				onBondStateChange?.OnNext(value);
				break;
			case "android.bluetooth.a2dp.profile.action.CONNECTION_STATE_CHANGED":
			case "android.bluetooth.headset.profile.action.CONNECTION_STATE_CHANGED":
				onConnectionStateChanged?.OnNext(value);
				break;
			}
		}

		private void OnConnectedBroadcastReceived(Intent intent)
		{
			global::Android.Bluetooth.State intExtra = (global::Android.Bluetooth.State)intent.GetIntExtra("android.bluetooth.profile.extra.STATE", -2147483648);
			bool flag = IsConnected();
			switch (intExtra)
			{
			case global::Android.Bluetooth.State.Connected:
				flag = true;
				break;
			case global::Android.Bluetooth.State.Disconnected:
				flag = false;
				break;
			}
			if (flag != wasPreviouslyConnected)
			{
				wasPreviouslyConnected = flag;
				_OnConnected.OnNext(flag);
			}
		}

		private void OnDisconnectedBroadcastReceived(Intent intent)
		{
			if (intent.Action == "android.bluetooth.device.action.ACL_DISCONNECTED")
			{
				_OnConnected.OnNext(value: false);
			}
		}
	}
	public class HeadphoneDeviceFilter : HeadphoneDeviceFilterBase
	{
		protected override bool IsAudioDevice(IHeadphone headphone)
		{
			if (!(headphone is Headphone { BluetoothMajorDeviceClass: var bluetoothMajorDeviceClass, BluetoothDeviceClass: var bluetoothDeviceClass } headphone2))
			{
				return false;
			}
			if (IsAudioVideoLoudspeakerValid() && bluetoothMajorDeviceClass == MajorDeviceClass.AudioVideo)
			{
				return true;
			}
			switch (bluetoothDeviceClass)
			{
			case DeviceClass.AudioVideoWearableHeadset:
			case DeviceClass.AudioVideoHeadphones:
				return true;
			default:
			{
				string headphoneName = headphone2.Name;
				if (Build.VERSION.SdkInt <= BuildVersionCodes.N && !string.IsNullOrEmpty(headphoneName) && HeadphoneConnectionHelperBase.AllowedHeadphoneNamesIgnoringCase.Any((string allowedName) => headphoneName.Contains(allowedName, StringComparison.OrdinalIgnoreCase)))
				{
					return true;
				}
				if (headphone2.HasAudioService || bluetoothMajorDeviceClass == MajorDeviceClass.AudioVideo)
				{
					iFit.Logger.Log.Trace("Headphone", $"HeadphoneDeviceFilter rejecting {headphone2}" + $" HasAudioService={headphone2.HasAudioService}" + $" MajorClass={bluetoothMajorDeviceClass}" + $" DeviceClass={bluetoothDeviceClass}");
				}
				return false;
			}
			}
		}
	}
	public class HeadphoneScanner : HeadphoneScannerBase
	{
		private readonly TimeSpan rescanDueTime = TimeSpan.FromSeconds(40.0);

		private readonly Context context;

		private RxBroadcastReceiver scannerReceiver;

		private IDisposable onDeviceFoundSub;

		private IDisposable rescanSub;

		private readonly BluetoothAdapter adapter;

		public HeadphoneScanner(Context context)
		{
			this.context = context;
			adapter = BluetoothAdapter.DefaultAdapter;
		}

		protected override void ScanNative()
		{
			BluetoothAdapter bluetoothAdapter = adapter;
			if (bluetoothAdapter == null || bluetoothAdapter.State != global::Android.Bluetooth.State.On)
			{
				iFit.Logger.Log.Trace("Headphone", "Bluetooth Adapter State not State.On: " + adapter?.State.ToString() + ". Returning and not scanning.");
				return;
			}
			if (adapter.IsDiscovering)
			{
				adapter.CancelDiscovery();
			}
			DisposeScannerReceiver();
			RegisterScannerReceiver();
			onDeviceFoundSub = scannerReceiver.WhenBroadcastReceived.Subscribe(OnBroadcastReceived);
			adapter.StartDiscovery();
			StartRescanTimer();
		}

		protected override void StopScanNative()
		{
			BluetoothAdapter bluetoothAdapter = adapter;
			if (bluetoothAdapter != null && bluetoothAdapter.State == global::Android.Bluetooth.State.On)
			{
				adapter.CancelDiscovery();
				DisposeScannerReceiver();
			}
		}

		private void OnBroadcastReceived(Intent intent)
		{
			if (intent.Action == "android.bluetooth.device.action.FOUND")
			{
				if (intent.GetParcelableExtra("android.bluetooth.device.extra.DEVICE") is BluetoothDevice device)
				{
					short shortExtra = intent.GetShortExtra("android.bluetooth.device.extra.RSSI", 0);
					Headphone device2 = new Headphone(device, shortExtra);
					OnDeviceFound(device2);
					RestartRescanTimer();
				}
			}
			else if (intent.Action == "android.bluetooth.adapter.action.DISCOVERY_FINISHED")
			{
				iFit.Logger.Log.Trace("Headphone", "HeadphoneScanner discovery finished");
				InvokeEnded();
				adapter.StartDiscovery();
				RestartRescanTimer();
			}
		}

		private void RegisterScannerReceiver()
		{
			IntentFilter intentFilter = new IntentFilter("android.bluetooth.device.action.FOUND");
			intentFilter.AddAction("android.bluetooth.adapter.action.DISCOVERY_FINISHED");
			scannerReceiver = new RxBroadcastReceiver(intentFilter);
			scannerReceiver.StartListening(context);
		}

		private void StartRescanTimer()
		{
			rescanSub = Observable.Timer(rescanDueTime).SubscribeWithErrorLogging(delegate
			{
				iFit.Logger.Log.Trace("Headphone", $"Discovery did not find or finish for {rescanDueTime}, restarting scan.");
				InvokeEnded();
				ScanNative();
			});
		}

		private void RestartRescanTimer()
		{
			CancelRescanTimer();
			StartRescanTimer();
		}

		public override void Dispose()
		{
			base.Dispose();
			DisposeScannerReceiver();
		}

		private void DisposeScannerReceiver()
		{
			CancelRescanTimer();
			onDeviceFoundSub?.Dispose();
			onDeviceFoundSub = null;
			if (scannerReceiver != null)
			{
				scannerReceiver.Dispose();
				scannerReceiver = null;
			}
		}

		private void CancelRescanTimer()
		{
			rescanSub?.Dispose();
			rescanSub = null;
		}
	}
	public class ProfileProxyService : IDisposable
	{
		private class BluetoothProfileServiceListener : Java.Lang.Object, IBluetoothProfileServiceListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private Subject<IBluetoothProfile> _onServiceConnected = new Subject<IBluetoothProfile>();

			private Subject<ProfileType> _onServiceDisconnected = new Subject<ProfileType>();

			public IObservable<IBluetoothProfile> WhenServiceConnected => _onServiceConnected;

			public IObservable<ProfileType> WhenServiceDisconnected => _onServiceDisconnected;

			public void OnServiceConnected([GeneratedEnum] ProfileType profile, IBluetoothProfile proxy)
			{
				iFit.Logger.Log.Trace("Headphone", $"OnServiceConnected {profile} {proxy}");
				if (profile == ProfileType.A2dp || profile == ProfileType.Headset)
				{
					_onServiceConnected.OnNext(proxy);
				}
			}

			public void OnServiceDisconnected([GeneratedEnum] ProfileType profile)
			{
				iFit.Logger.Log.Trace("Headphone", $"OnServiceDisconnected {profile}");
				if (profile == ProfileType.A2dp || profile == ProfileType.Headset)
				{
					_onServiceDisconnected.OnNext(profile);
				}
			}

			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
				if (disposing)
				{
					_onServiceConnected?.Dispose();
					_onServiceConnected = null;
					_onServiceDisconnected?.Dispose();
					_onServiceDisconnected = null;
				}
			}
		}

		private BluetoothAdapter adapter;

		private Context context;

		private BluetoothProfileServiceListener listener;

		private IDisposable connectedSub;

		private IDisposable disconnectedSub;

		private bool didHeadsetTimeout;

		private readonly TimeSpan headsetTimeoutSpan = TimeSpan.FromSeconds(3.0);

		public BluetoothA2dp A2dp { get; private set; }

		public BluetoothHeadset Headset { get; private set; }

		public void Init(BluetoothAdapter newAdapter, Context newContext)
		{
			if (context == newContext && newAdapter == adapter)
			{
				iFit.Logger.Log.Trace("Headphone", "Context and Adapter have not changed.");
				return;
			}
			A2dp = null;
			Headset = null;
			adapter = newAdapter;
			context = newContext;
			if (adapter == null)
			{
				iFit.Logger.Log.Warn("Headphone", $"Adapter is null: {adapter}.");
			}
			if (context == null)
			{
				iFit.Logger.Log.Warn("Headphone", $"Context is null: {context}.");
			}
			listener?.Dispose();
			listener = new BluetoothProfileServiceListener();
			connectedSub = listener.WhenServiceConnected.SubscribeWithErrorLogging(OnProfileProxyConnected);
			disconnectedSub = listener.WhenServiceDisconnected.SubscribeWithErrorLogging(OnProfileProxyDisconnected);
			adapter.GetProfileProxy(context, listener, ProfileType.A2dp);
			adapter.GetProfileProxy(context, listener, ProfileType.Headset);
			iFit.Logger.Log.Trace("Headphone", $"ProfileProxyService Init finished. A2dp: {A2dp}; Headset: {Headset};");
		}

		public async Task WaitForProxies()
		{
			BluetoothAdapter bluetoothAdapter = adapter;
			if (bluetoothAdapter == null || bluetoothAdapter.State != global::Android.Bluetooth.State.On)
			{
				iFit.Logger.Log.Trace("Headphone", "Bluetooth Adapter State not State.On: " + adapter?.State.ToString() + ". Returning and not waiting for proxies.");
				return;
			}
			iFit.Logger.Log.Trace("Headphone", $"WaitForProxies - currently have: {A2dp} {Headset}");
			BluetoothA2dp a2dp = A2dp;
			BluetoothA2dp bluetoothA2dp = a2dp;
			if (bluetoothA2dp == null)
			{
				bluetoothA2dp = await listener.WhenServiceConnected.OfType<BluetoothA2dp>().FirstAsync().ToTask()
					.ConfigureAwait(continueOnCapturedContext: true);
			}
			A2dp = bluetoothA2dp;
			if (!didHeadsetTimeout)
			{
				try
				{
					iFit.Logger.Log.Trace("Headphone", $"WaitForProxies - trying to get Headset {Headset}. A2dp is currently {A2dp}");
					BluetoothHeadset headset = Headset;
					BluetoothHeadset bluetoothHeadset = headset;
					if (bluetoothHeadset == null)
					{
						bluetoothHeadset = await listener.WhenServiceConnected.OfType<BluetoothHeadset>().FirstAsync().Timeout(headsetTimeoutSpan)
							.ToTask()
							.ConfigureAwait(continueOnCapturedContext: true);
					}
					Headset = bluetoothHeadset;
				}
				catch (TimeoutException arg)
				{
					iFit.Logger.Log.Trace("Headphone", $"WaitForProxies - Timeout waiting for BluetoothHeadset proxy: {arg}");
					didHeadsetTimeout = true;
				}
			}
			iFit.Logger.Log.Trace("Headphone", string.Format("WaitForProxies - done. {0}: {1}. {2}: {3}", "A2dp", A2dp, "Headset", Headset));
		}

		private void OnProfileProxyConnected(IBluetoothProfile proxy)
		{
			if (!(proxy is BluetoothA2dp a2dp))
			{
				if (proxy is BluetoothHeadset headset)
				{
					Headset = headset;
				}
			}
			else
			{
				A2dp = a2dp;
			}
		}

		private void OnProfileProxyDisconnected(ProfileType profileType)
		{
			switch (profileType)
			{
			case ProfileType.A2dp:
				A2dp = null;
				break;
			case ProfileType.Headset:
				Headset = null;
				break;
			}
		}

		public void Dispose()
		{
			connectedSub?.Dispose();
			connectedSub = null;
			disconnectedSub?.Dispose();
			disconnectedSub = null;
			listener?.Dispose();
			listener = null;
		}
	}
}
namespace Shire.Android.Analytics
{
	public class GoogleAnalytics : IGoogleAnalytics
	{
		private readonly FirebaseAnalytics firebaseAnalytics;

		public bool TrackWithWebViewLags => Build.VERSION.SdkInt <= BuildVersionCodes.N;

		public GoogleAnalytics(Context context)
		{
			firebaseAnalytics = FirebaseAnalytics.GetInstance(context);
		}

		public void SetEnabled(bool isEnabled)
		{
			firebaseAnalytics.SetAnalyticsCollectionEnabled(isEnabled);
		}

		public void SetUserId(string id)
		{
			firebaseAnalytics.SetUserId(id);
		}

		public void SetUserProperty(string name, string value)
		{
			GoogleAnalyticsUtils.ValidateUserPropertyName(name);
			value = GoogleAnalyticsUtils.NormalizeUserPropertyValue(value);
			firebaseAnalytics.SetUserProperty(name, value);
		}

		public void Track(string eventName, IDictionary<string, object> properties = null, bool throwIfInvalid = true)
		{
			Bundle bundle = ((properties == null || properties.Count == 0) ? null : new Bundle(properties.Count));
			PutEntries(properties, bundle, throwIfInvalid);
			firebaseAnalytics.LogEvent(eventName, bundle);
		}

		private void PutEntries(IDictionary<string, object> properties, Bundle bundle, bool throwIfInvalid)
		{
			IDictionary<string, object> dictionary = GoogleAnalyticsUtils.NormalizeProperties(properties, throwIfInvalid);
			foreach (var (text2, obj2) in dictionary)
			{
				if (!(obj2 is string value))
				{
					if (!(obj2 is long value2))
					{
						if (obj2 is double value3)
						{
							bundle.PutDouble(text2, value3);
							continue;
						}
						iFit.Logger.Log.Error("Analytics", string.Format("{0}:{1} invalid value type for key '{2}': '{3}'", "GoogleAnalytics", "PutEntries", text2, obj2));
					}
					else
					{
						bundle.PutLong(text2, value2);
					}
				}
				else
				{
					bundle.PutString(text2, value);
				}
			}
		}
	}
}
