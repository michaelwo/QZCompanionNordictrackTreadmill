using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Akavache.Sqlite3;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Com.Google.Android.Exoplayer2;
using Com.Google.Android.Exoplayer2.Analytics;
using Com.Google.Android.Exoplayer2.Decoder;
using Com.Google.Android.Exoplayer2.Ext.Cronet;
using Com.Google.Android.Exoplayer2.Extractor;
using Com.Google.Android.Exoplayer2.Metadata;
using Com.Google.Android.Exoplayer2.Source;
using Com.Google.Android.Exoplayer2.Source.Hls;
using Com.Google.Android.Exoplayer2.Text;
using Com.Google.Android.Exoplayer2.Trackselection;
using Com.Google.Android.Exoplayer2.Upstream;
using Com.Google.Android.Exoplayer2.Util;
using Com.Google.Android.Exoplayer2.Video;
using Java.Interop;
using Java.Lang;
using Java.Util;
using Java.Util.Concurrent;
using MvvmCross.Platform.Core;
using iFit.Logger;
using iFit.Video.ClosedCaptions;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework("MonoAndroid,Version=v10.0", FrameworkDisplayName = "Xamarin.Android v10.0 Support")]
[assembly: AssemblyVersion("0.0.0.0")]
namespace iFit.Video.Android;

public class CombinedAudioVideoPlayer : ICombinedAudioVideoPlayer, IDisposable
{
	[BroadcastReceiver]
	private class HeadsetPlugUnplugReceiver : BroadcastReceiver
	{
		private Subject<AudioSourceChange> whenAudioSourceChanged;

		public HeadsetPlugUnplugReceiver()
		{
		}

		public HeadsetPlugUnplugReceiver(Subject<AudioSourceChange> whenAudioSourceChanged)
		{
			this.whenAudioSourceChanged = whenAudioSourceChanged;
		}

		public override void OnReceive(Context context, Intent intent)
		{
			switch (intent.Action)
			{
			case "android.intent.action.HEADSET_PLUG":
			{
				int num = (int)(intent.Extras?.Get("state") ?? ((Java.Lang.Object)0));
				AudioSourceChange value = ((num == 1) ? AudioSourceChange.PluggedIn : AudioSourceChange.Unplugged);
				whenAudioSourceChanged.OnNext(value);
				break;
			}
			case "android.media.AUDIO_BECOMING_NOISY":
				whenAudioSourceChanged.OnNext(AudioSourceChange.Unplugged);
				break;
			}
		}
	}

	private const string Tag = "Video";

	private const bool ResetPosition = false;

	private AudioPlayerEventListener audioPlayerEventListener;

	private VideoPlayerEventListener internalPlayerEventListener;

	private VideoListener internalVideoListener;

	private readonly IMvxMainThreadDispatcher dispatcher;

	private ILoadControlFactory loadControlFactory;

	private readonly IAdaptiveTrackSelectionFactory adaptiveTrackSelectionFactory;

	private readonly IVideoQualitySettings videoQualitySettings;

	private readonly SemaphoreSlim playerCleanupSs = new SemaphoreSlim(1, 1);

	private readonly IBandwidthMeterEventListener externalBandwidthMeterEventListener;

	private readonly IPlayerEventListener externalPlayerEventListener;

	private readonly IMediaSourceEventListener externalMediaSourceEventListener;

	private readonly IVideoListener externalVideoListener;

	private readonly IClosedCaptionsPreferredLanguage closedCaptionsPreferredLanguage;

	private IDisposable periodicVideoCheckSub;

	private IDisposable videoPositionSecondsTimer;

	private IDisposable whenAudioSourceChangedSub;

	private DefaultRenderersFactory renderersFactory;

	private DefaultAllocator videoAllocator;

	private DefaultAllocator audioAllocator;

	private DefaultLoadControl videoLoadControl;

	private DefaultLoadControl audioLoadControl;

	private HeadsetPlugUnplugReceiver headsetPlugUnplugReceiver;

	private readonly SimpleCaptionListener captionListener;

	private EventLogger eventLogger;

	private bool isDisposed;

	private bool isApplicationPaused;

	private double recoverVideoTime;

	private int currentVideoHeight;

	private string directVideoUri;

	private string audioUri;

	private TaskCompletionSource<int> videoPlayerCreationTcs;

	private TaskCompletionSource<int> audioPlayerCreationTcs;

	private readonly Handler mainLooperHandler = new Handler(Looper.MainLooper);

	private double _lastVideoPositionSeconds;

	private readonly Subject<SimpleExoPlayer> _whenVideoPlayerChanged = new Subject<SimpleExoPlayer>();

	private readonly Subject<bool> _whenIsLoadingChanged = new Subject<bool>();

	private readonly Subject<bool> _whenIsBufferingChanged = new Subject<bool>();

	private readonly Subject<double> _whenVideoPositionSecondsChanged = new Subject<double>();

	private readonly Subject<string> _whenVideoResolutionChanged = new Subject<string>();

	private readonly Subject<AudioSourceChange> _whenAudioSourceChanged = new Subject<AudioSourceChange>();

	private bool _isLoading;

	private bool _isBuffering;

	private float _videoVolume = 1f;

	private float _audioVolume = 1f;

	private RepeatMode _repeatMode;

	public SimpleExoPlayer VideoPlayer { get; private set; }

	public SimpleExoPlayer AudioPlayer { get; private set; }

	public CustomTrackSelector videoTrackSelector { get; private set; }

	public DefaultTrackSelector audioTrackSelector { get; private set; }

	internal DefaultBandwidthMeter BandWidthMeter { get; private set; }

	public PauseResumeBehavior ResumeBehavior { get; set; }

	public bool ForceSingleTrackFromAdaptive { get; private set; }

	public PlaybackType SelectedPlaybackType { get; private set; } = PlaybackType.Fixed;

	public VideoQuality SelectedVideoQuality { get; }

	public SettingsInfo CurrentSettingsInfo { get; private set; }

	public double BufferedSeconds => ((double?)VideoPlayer?.BufferedPosition / 1000.0).GetValueOrDefault();

	public double VideoPositionSeconds => (double)(VideoPlayer?.CurrentPosition).GetValueOrDefault() / 1000.0;

	public double LastVideoPositionSeconds => _lastVideoPositionSeconds;

	public double AudioPosition => (double)(AudioPlayer?.CurrentPosition).GetValueOrDefault() / 1000.0;

	public IObservable<SimpleExoPlayer> WhenVideoPlayerChanged => _whenVideoPlayerChanged;

	public bool VideoFailedToLoad { get; private set; }

	public IObservable<System.Exception> VideoErrorOccured
	{
		get
		{
			if (internalPlayerEventListener != null)
			{
				return internalPlayerEventListener.VideoErrorOccured;
			}
			iFit.Logger.Log.Warn("Video", "internalPlayerEventListener is null. You can't get VideoErrorOccured observable.");
			return null;
		}
	}

	public IObservable<bool> VideoPlaybackCompleted
	{
		get
		{
			if (internalPlayerEventListener != null)
			{
				return internalPlayerEventListener.VideoPlaybackCompleted;
			}
			iFit.Logger.Log.Warn("Video", "internalPlayerEventListener is null. You can't get VideoPlaybackCompleted observable.");
			return null;
		}
	}

	public IObservable<bool> WhenIsLoadingChanged => _whenIsLoadingChanged;

	public IObservable<bool> WhenIsBufferingChanged => _whenIsBufferingChanged;

	public IObservable<double> WhenVideoPositionSecondsChanged => _whenVideoPositionSecondsChanged;

	public IObservable<string> WhenVideoResolutionChanged => _whenVideoResolutionChanged;

	public IObservable<AudioSourceChange> WhenAudioSourceChanged => _whenAudioSourceChanged;

	public AudioSourceChangeOption AudioSourceConnectedOption { get; set; }

	public AudioSourceChangeOption AudioSourceDisconnectedOption { get; set; }

	public IExoTrackSelectionFactory TrackSelectionFactory { get; private set; }

	public IObservable<bool> WhenVideoPlaybackInterrupted => null;

	public bool IsLoading
	{
		get
		{
			return _isLoading;
		}
		set
		{
			if (value != _isLoading)
			{
				iFit.Logger.Log.Trace("Video", $"IsLoading=>{value} BufferSecRemaining={BufferSecondsRemaining} PlaybackState={VideoPlayer?.PlaybackState}");
				_isLoading = value;
				_whenIsLoadingChanged.OnNext(_isLoading);
			}
		}
	}

	public bool IsBuffering
	{
		get
		{
			return _isBuffering;
		}
		set
		{
			if (value != _isBuffering)
			{
				iFit.Logger.Log.Trace("Video", $"IsBuffering=>{value}");
				_isBuffering = value;
				_whenIsBufferingChanged.OnNext(_isBuffering);
			}
		}
	}

	public double BufferSecondsRemaining => BufferedSeconds - VideoPositionSeconds;

	public float VideoVolume
	{
		get
		{
			return _videoVolume;
		}
		set
		{
			_videoVolume = value;
			dispatcher.RequestMainThreadAction(delegate
			{
				if (VideoPlayer != null)
				{
					VideoPlayer.Volume = _videoVolume;
				}
			});
		}
	}

	public float AudioVolume
	{
		get
		{
			return _audioVolume;
		}
		set
		{
			_audioVolume = value;
			dispatcher.RequestMainThreadAction(delegate
			{
				if (AudioPlayer != null)
				{
					AudioPlayer.Volume = _audioVolume;
				}
			});
		}
	}

	public RepeatMode RepeatMode
	{
		get
		{
			return _repeatMode;
		}
		set
		{
			_repeatMode = value;
			dispatcher.RequestMainThreadAction(delegate
			{
				if (VideoPlayer != null)
				{
					VideoPlayer.RepeatMode = _repeatMode;
				}
			});
		}
	}

	public ClosedCaptionLanguage SelectedClosedCaptionsLanguage => videoTrackSelector.SelectedClosedCaptionsLanguage;

	public int VideoRenderedOutputBufferCount => (VideoPlayer?.VideoDecoderCounters?.RenderedOutputBufferCount).GetValueOrDefault();

	public int VideoSkippedOutputBufferCount => (VideoPlayer?.VideoDecoderCounters?.SkippedOutputBufferCount).GetValueOrDefault();

	public int VideoDroppedBufferCount => (VideoPlayer?.VideoDecoderCounters?.DroppedBufferCount).GetValueOrDefault();

	public int VideoMaxConsecutiveDroppedBufferCount => (VideoPlayer?.VideoDecoderCounters?.MaxConsecutiveDroppedBufferCount).GetValueOrDefault();

	public int VideoStutteredPeriodTransitionCount { get; private set; }

	public int VideoStutteredSeekCount { get; private set; }

	public int VideoStutteredSeekAdjustmentCount { get; private set; }

	public int VideoStutteredAdInsertionCount { get; private set; }

	public int VideoStutteredInternalCount { get; private set; }

	public int VideoStutteredUnknownCount { get; private set; }

	public int AudioRenderedOutputBufferCount => (VideoPlayer?.AudioDecoderCounters?.RenderedOutputBufferCount).GetValueOrDefault();

	public int AudioSkippedOutputBufferCount => (VideoPlayer?.AudioDecoderCounters?.SkippedOutputBufferCount).GetValueOrDefault();

	public int AudioDroppedBufferCount => (VideoPlayer?.AudioDecoderCounters?.DroppedBufferCount).GetValueOrDefault();

	public int AudioMaxConsecutiveDroppedBufferCount => (VideoPlayer?.AudioDecoderCounters?.MaxConsecutiveDroppedBufferCount).GetValueOrDefault();

	public event EventHandler<string> OnNewCaptionString
	{
		add
		{
			captionListener.OnNewCaptionString += value;
		}
		remove
		{
			captionListener.OnNewCaptionString -= value;
		}
	}

	public event EventHandler<ClosedCaptionLanguage> OnClosedCaptionsLanguageChanged
	{
		add
		{
			videoTrackSelector.OnClosedCaptionsLanguageChanged += value;
		}
		remove
		{
			videoTrackSelector.OnClosedCaptionsLanguageChanged -= value;
		}
	}

	private bool ShouldActOnVideoPlayer(PlayerType playerType)
	{
		if (playerType.HasFlag(PlayerType.Video))
		{
			return VideoPlayer != null;
		}
		return false;
	}

	private bool ShouldActOnAudioPlayer(PlayerType playerType)
	{
		if (playerType.HasFlag(PlayerType.Audio))
		{
			return AudioPlayer != null;
		}
		return false;
	}

	public CombinedAudioVideoPlayer(IMvxMainThreadDispatcher dispatcher, ILoadControlFactory loadControlFactory, IAdaptiveTrackSelectionFactory adaptiveTrackSelectionFactory, IVideoQualitySettings videoQualitySettings, IBandwidthMeterEventListener externalBandwidthMeterEventListener = null, IMediaSourceEventListener externalMediaSourceEventListener = null, IPlayerEventListener externalPlayerEventListener = null, IVideoListener externalVideoListener = null, IClosedCaptionsPreferredLanguage closedCaptionsPreferredLanguage = null, IExoplayerAdvancedSettings exoplayerAdvancedSettings = null)
	{
		iFit.Logger.Log.Trace("Video", "Creating new video player instance");
		this.dispatcher = dispatcher;
		this.loadControlFactory = loadControlFactory;
		this.adaptiveTrackSelectionFactory = adaptiveTrackSelectionFactory;
		this.videoQualitySettings = videoQualitySettings;
		this.externalBandwidthMeterEventListener = externalBandwidthMeterEventListener;
		this.externalMediaSourceEventListener = externalMediaSourceEventListener;
		this.externalPlayerEventListener = externalPlayerEventListener;
		this.externalVideoListener = externalVideoListener;
		this.closedCaptionsPreferredLanguage = closedCaptionsPreferredLanguage;
		SelectedVideoQuality = videoQualitySettings.VideoQuality.MapToNewQuality();
		internalPlayerEventListener = new VideoPlayerEventListener(this);
		audioPlayerEventListener = new AudioPlayerEventListener();
		internalVideoListener = new VideoListener(this);
		captionListener = new SimpleCaptionListener();
		renderersFactory = new InterceptSubtitlesRenderersFactory(Application.Context, captionListener);
		SetupExperimentalFeatures(exoplayerAdvancedSettings, renderersFactory);
		CurrentSettingsInfo = videoQualitySettings.VodSettings;
		iFit.Logger.Log.Trace("Video", $"CombinedAudioVideoPlayer.CurrentSettingsInfo changed: {CurrentSettingsInfo}");
		TryToRecreateVideoPlayer();
	}

	public bool IsReadyToPlay()
	{
		if (VideoPlayer == null)
		{
			iFit.Logger.Log.Trace("Video", "VideoPlayer is null - Try to Re-create VideoPlayer");
			TryToRecreateVideoPlayer();
		}
		SimpleExoPlayer videoPlayer = VideoPlayer;
		if (videoPlayer == null)
		{
			return false;
		}
		return videoPlayer.PlaybackState == PlaybackState.Ready;
	}

	private void TryToRecreateVideoPlayer()
	{
		CreateVideoPlayer();
		CreateAudioPlayer();
	}

	private void SetupExperimentalFeatures(IExoplayerAdvancedSettings exoplayerAdvancedSettings, DefaultRenderersFactory renderersFactory)
	{
		if (exoplayerAdvancedSettings != null)
		{
			if (exoplayerAdvancedSettings.IsEnableAsyncInputBufferQueueing)
			{
				renderersFactory.ExperimentalSetAsynchronousBufferQueueingEnabled(enabled: true);
			}
			if (exoplayerAdvancedSettings.IsEnableAsyncQueueingSynchronizationWorkaround)
			{
				renderersFactory.ExperimentalSetForceAsyncQueueingSynchronizationWorkaround(enabled: true);
			}
			if (exoplayerAdvancedSettings.IsEnableAsyncInputBufferQueueing && exoplayerAdvancedSettings.IsEnableSynchronizingCodecInteractionsToAsyncInputBufferQueueing)
			{
				renderersFactory.ExperimentalSetSynchronizeCodecInteractionsWithQueueingEnabled(enabled: true);
			}
		}
	}

	public void ApplicationPaused()
	{
		iFit.Logger.Log.Trace("Video", "Received " + GetType().Name + ".ApplicationPaused() call, scheduling action on main thread");
		isApplicationPaused = true;
		dispatcher.RequestMainThreadAction(delegate
		{
			if (isDisposed)
			{
				iFit.Logger.Log.Trace("Video", "Cancelling ApplicationPaused() main thread action since this object is already disposed");
			}
			else
			{
				iFit.Logger.Log.Trace("Video", "Starting ApplicationPaused() main thread action");
				Pause();
				recoverVideoTime = ((double?)VideoPlayer?.CurrentPosition / 1000.0).GetValueOrDefault();
				playerCleanupSs.Wait();
				ReleaseAndCleanupAudioPlayer();
				ReleaseAndCleanupVideoPlayer();
				playerCleanupSs.Release();
			}
		});
	}

	public async Task ApplicationResumed()
	{
		if (isApplicationPaused)
		{
			isApplicationPaused = false;
			TryToRecreateVideoPlayer();
			SeekTo(recoverVideoTime, PlayerType.Both, forceSeek: true);
			if (!string.IsNullOrWhiteSpace(directVideoUri))
			{
				await StartLoadDirectSource(directVideoUri, audioUri);
			}
		}
	}

	public string GetVideoString()
	{
		return internalVideoListener?.GetDebugString();
	}

	public void OnVideoStuttered(VideoStutterReason stutterReason)
	{
		switch (stutterReason)
		{
		case VideoStutterReason.PeriodTransition:
			VideoStutteredPeriodTransitionCount++;
			break;
		case VideoStutterReason.Seek:
			VideoStutteredSeekCount++;
			break;
		case VideoStutterReason.SeekAdjustment:
			VideoStutteredSeekAdjustmentCount++;
			break;
		case VideoStutterReason.AdInsertion:
			VideoStutteredAdInsertionCount++;
			break;
		case VideoStutterReason.Internal:
			VideoStutteredInternalCount++;
			break;
		default:
			VideoStutteredUnknownCount++;
			break;
		}
	}

	private void ReleaseAndCleanupAudioPlayer()
	{
		ReleaseAndCleanupPlayer(AudioPlayer, new IPlayerEventListener[1] { audioPlayerEventListener });
		AudioPlayer = null;
	}

	private void ReleaseAndCleanupVideoPlayer()
	{
		ReleaseAndCleanupPlayer(VideoPlayer, new IPlayerEventListener[2] { externalPlayerEventListener, internalPlayerEventListener }, new IVideoListener[2] { externalVideoListener, internalVideoListener });
		VideoPlayer = null;
	}

	private void ReleaseAndCleanupPlayer(SimpleExoPlayer player, IPlayerEventListener[] playerEventListeners = null, IVideoListener[] videoListeners = null)
	{
		try
		{
			if (player != null)
			{
				ReleaseAndCleanupPlayerEventListeners(player, playerEventListeners);
				ReleaseAndCleanupVideoListeners(player, videoListeners);
				if (eventLogger != null)
				{
					player.RemoveAnalyticsListener(eventLogger);
				}
				player.PlayWhenReady = false;
				player.Release();
				player.DisposeSafe();
			}
		}
		catch (System.Exception exception)
		{
			iFit.Logger.Log.Error("Video", "Error cleaning up player", exception);
			throw;
		}
	}

	private static void ReleaseAndCleanupPlayerEventListeners(SimpleExoPlayer player, IPlayerEventListener[] playerEventListeners)
	{
		if (playerEventListeners == null)
		{
			return;
		}
		foreach (IPlayerEventListener playerEventListener in playerEventListeners)
		{
			if (playerEventListener != null && playerEventListener.Handle != IntPtr.Zero)
			{
				player.RemoveListener(playerEventListener);
			}
		}
	}

	private static void ReleaseAndCleanupVideoListeners(SimpleExoPlayer player, IVideoListener[] videoListeners)
	{
		if (videoListeners == null)
		{
			return;
		}
		foreach (IVideoListener videoListener in videoListeners)
		{
			if (videoListener != null && videoListener.Handle != IntPtr.Zero)
			{
				player.RemoveVideoListener(videoListener);
			}
		}
	}

	private void CreateVideoPlayer()
	{
		videoPlayerCreationTcs = new TaskCompletionSource<int>();
		DefaultBandwidthMeter.Builder builder = new DefaultBandwidthMeter.Builder(Application.Context);
		if (CurrentSettingsInfo.InitialBitrateEstimate > 0)
		{
			builder.SetInitialBitrateEstimate(CurrentSettingsInfo.InitialBitrateEstimate);
		}
		BandWidthMeter = builder.Build();
		if (externalBandwidthMeterEventListener != null)
		{
			BandWidthMeter.AddEventListener(mainLooperHandler, externalBandwidthMeterEventListener);
		}
		AnalyticsCollector analyticsCollector = new AnalyticsCollector(IClock.Default);
		DefaultExtractorsFactory extractorsFactory = new DefaultExtractorsFactory();
		DefaultMediaSourceFactory mediaSourceFactory = new DefaultMediaSourceFactory(Application.Context, extractorsFactory);
		TrackSelectionFactory = adaptiveTrackSelectionFactory.CreateAdaptiveTrackSelectionFactory();
		(int, int) resolutionValues = GetResolutionValues(SelectedVideoQuality);
		videoTrackSelector = new CustomTrackSelector(Application.Context, TrackSelectionFactory);
		videoTrackSelector.SetParameters(videoTrackSelector.BuildUponParameters().SetMaxVideoSize(resolutionValues.Item1, resolutionValues.Item2).SetAllowVideoNonSeamlessAdaptiveness(CurrentSettingsInfo.AllowVideoNonSeamlessAdaptiveness)
			.SetViewportSize(videoTrackSelector.GetParameters().ViewportWidth, videoTrackSelector.GetParameters().ViewportHeight, videoQualitySettings.ViewportOrientationMayChange));
		videoAllocator = new DefaultAllocator(trimOnReset: true, 65536);
		videoLoadControl = loadControlFactory.CreateVideoLoadControl(videoAllocator);
		dispatcher.RequestMainThreadAction(delegate
		{
			if (!isDisposed)
			{
				VideoPlayer = new SimpleExoPlayer.Builder(Application.Context, renderersFactory, videoTrackSelector, mediaSourceFactory, videoLoadControl, BandWidthMeter, analyticsCollector).Build();
				videoPlayerCreationTcs.SetResult(0);
				InitEventListeners();
				VideoPlayer.RepeatMode = RepeatMode;
				periodicVideoCheckSub?.Dispose();
				periodicVideoCheckSub = Observable.Interval(TimeSpan.FromSeconds(1.0)).Subscribe(delegate
				{
					DoPeriodicVideoCheck();
				});
				_whenVideoPlayerChanged.OnNext(VideoPlayer);
				CreateVideoPositionTimer();
			}
		});
	}

	private void InitEventListeners()
	{
		if (externalPlayerEventListener != null)
		{
			VideoPlayer.AddListener(externalPlayerEventListener);
		}
		if (externalVideoListener != null)
		{
			VideoPlayer.AddVideoListener(externalVideoListener);
		}
		if (videoTrackSelector != null)
		{
			eventLogger = new CustomEventLogger(videoTrackSelector, this);
			VideoPlayer.AddAnalyticsListener(eventLogger);
		}
	}

	private void DoPeriodicVideoCheck()
	{
		dispatcher.RequestMainThreadAction(delegate
		{
			int valueOrDefault = (internalVideoListener?.VideoFormat?.Height).GetValueOrDefault();
			if (currentVideoHeight != valueOrDefault)
			{
				currentVideoHeight = valueOrDefault;
				_whenVideoResolutionChanged.OnNext(ResolutionUtils.GetVideoResolution(currentVideoHeight));
			}
			UpdateIsLoading();
		});
	}

	private void CreateVideoPositionTimer()
	{
		videoPositionSecondsTimer?.Dispose();
		videoPositionSecondsTimer = Observable.Interval(TimeSpan.FromMilliseconds(500.0)).Subscribe(delegate
		{
			dispatcher.RequestMainThreadAction(delegate
			{
				double videoPositionSeconds = VideoPositionSeconds;
				if (!(_lastVideoPositionSeconds >= videoPositionSeconds))
				{
					_lastVideoPositionSeconds = videoPositionSeconds;
					_whenVideoPositionSecondsChanged.OnNext(videoPositionSeconds);
				}
			});
		}, delegate(System.Exception ex)
		{
			iFit.Logger.Log.Error("Video", "Video position subscription error", ex);
		});
	}

	private void CreateAudioPlayer()
	{
		audioPlayerCreationTcs = new TaskCompletionSource<int>();
		audioAllocator = new DefaultAllocator(trimOnReset: true, 65536);
		audioTrackSelector = new DefaultTrackSelector(Application.Context);
		audioLoadControl = loadControlFactory.CreateAudioLoadControl(audioAllocator);
		DefaultBandwidthMeter singletonInstance = DefaultBandwidthMeter.GetSingletonInstance(Application.Context);
		AnalyticsCollector analyticsCollector = new AnalyticsCollector(IClock.Default);
		DefaultExtractorsFactory extractorsFactory = new DefaultExtractorsFactory();
		DefaultMediaSourceFactory mediaSourceFactory = new DefaultMediaSourceFactory(Application.Context, extractorsFactory);
		dispatcher.RequestMainThreadAction(delegate
		{
			if (!isDisposed)
			{
				AudioPlayer = new SimpleExoPlayer.Builder(Application.Context, renderersFactory, audioTrackSelector, mediaSourceFactory, audioLoadControl, BandWidthMeter, analyticsCollector).Build();
				audioPlayerCreationTcs.SetResult(0);
				if (headsetPlugUnplugReceiver == null)
				{
					headsetPlugUnplugReceiver = new HeadsetPlugUnplugReceiver(_whenAudioSourceChanged);
					IntentFilter intentFilter = new IntentFilter();
					intentFilter.AddAction("android.media.AUDIO_BECOMING_NOISY");
					intentFilter.AddAction("android.intent.action.HEADSET_PLUG");
					Application.Context.RegisterReceiver(headsetPlugUnplugReceiver, intentFilter);
					whenAudioSourceChangedSub = WhenAudioSourceChanged.Subscribe(OnHeadsetPlugUnplug);
				}
			}
		});
	}

	private void OnHeadsetPlugUnplug(AudioSourceChange change)
	{
		if (change == AudioSourceChange.PluggedIn)
		{
			if (AudioSourceConnectedOption == AudioSourceChangeOption.Pause)
			{
				Pause();
			}
		}
		else if (AudioSourceDisconnectedOption == AudioSourceChangeOption.Pause)
		{
			Pause();
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (isDisposed)
		{
			return;
		}
		iFit.Logger.Log.Trace("Video", "Dispose() called. Setting isDisposed = true and scheduling final clean-up on main thread");
		isDisposed = true;
		if (!disposing)
		{
			return;
		}
		dispatcher.RequestMainThreadAction(delegate
		{
			iFit.Logger.Log.Trace("Video", "Starting " + GetType().Name + ".Dispose() main thread action");
			videoPositionSecondsTimer?.Dispose();
			videoPositionSecondsTimer = null;
			renderersFactory = renderersFactory?.DisposeSafe();
			periodicVideoCheckSub?.Dispose();
			periodicVideoCheckSub = null;
			whenAudioSourceChangedSub?.Dispose();
			whenAudioSourceChangedSub = null;
			if (headsetPlugUnplugReceiver != null)
			{
				Application.Context.UnregisterReceiver(headsetPlugUnplugReceiver);
				headsetPlugUnplugReceiver = null;
			}
			playerCleanupSs.Wait();
			Stop();
			if (AudioPlayer != null)
			{
				ReleaseAndCleanupAudioPlayer();
				audioLoadControl?.DisposeSafe();
				audioAllocator = videoAllocator?.DisposeSafe();
				audioTrackSelector?.DisposeSafe();
			}
			if (VideoPlayer != null)
			{
				ReleaseAndCleanupVideoPlayer();
				videoLoadControl?.DisposeSafe();
				videoAllocator = videoAllocator?.DisposeSafe();
				videoTrackSelector?.DisposeSafe();
			}
			audioPlayerEventListener = audioPlayerEventListener?.DisposeSafe();
			internalPlayerEventListener = internalPlayerEventListener?.DisposeSafe();
			internalVideoListener = internalVideoListener?.DisposeSafe();
			loadControlFactory = null;
			playerCleanupSs.Release();
		});
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public Task StartLoadVodSource(string vodUri, PlaybackType playbackType, string audioUri = null)
	{
		iFit.Logger.Log.Trace("Video", "CombinedAudioVideoPlayer VOD source: " + vodUri);
		CurrentSettingsInfo = videoQualitySettings.VodSettings;
		iFit.Logger.Log.Trace("Video", $"CombinedAudioVideoPlayer.CurrentSettingsInfo changed: {CurrentSettingsInfo}");
		return StartLoadSource(vodUri, playbackType, audioUri, isLive: false);
	}

	public async Task StartLoadDirectSource(string directVideoUri, string audioUri = null)
	{
		try
		{
			SelectedPlaybackType = PlaybackType.Fixed;
			this.audioUri = audioUri;
			this.directVideoUri = directVideoUri;
			CurrentSettingsInfo = videoQualitySettings.VodSettings;
			iFit.Logger.Log.Trace("Video", $"CombinedAudioVideoPlayer.CurrentSettingsInfo changed: {CurrentSettingsInfo}");
			iFit.Logger.Log.Trace("Video", "StartLoadFixedStreamVideo for video path: " + directVideoUri);
			IMediaSource mediaSource = LoadFixedStream(directVideoUri);
			await StartLoadSource(mediaSource, audioUri, isLive: false);
			VideoFailedToLoad = false;
		}
		catch (System.Exception exception)
		{
			iFit.Logger.Log.Error("Video", "Exception when trying to load audio/video sources", exception);
			VideoFailedToLoad = true;
		}
	}

	public Task StartLoadStream(string streamVideoUri, PlaybackType playbackType, string audioUri = null)
	{
		iFit.Logger.Log.Trace("Video", "StartLoadStream for video with video url " + streamVideoUri);
		ResumeBehavior = PauseResumeBehavior.ResumeLiveStreamTime;
		CurrentSettingsInfo = videoQualitySettings.LiveSettings ?? videoQualitySettings.VodSettings;
		iFit.Logger.Log.Trace("Video", $"CombinedAudioVideoPlayer.CurrentSettingsInfo changed: {CurrentSettingsInfo}");
		return StartLoadSource(streamVideoUri, playbackType, audioUri, isLive: true);
	}

	private Task StartLoadSource(string videoUri, PlaybackType playbackType, string audioUri, bool isLive)
	{
		SelectedPlaybackType = playbackType;
		this.audioUri = audioUri;
		MediaItem mediaItem = CreateMediaItem(videoUri);
		IMediaSource mediaSource = new HlsMediaSource.Factory(new DefaultDataSourceFactory(Application.Context, BandWidthMeter, BuildStreamingDataSourceFactory(BandWidthMeter, "shire"))).CreateMediaSource(mediaItem);
		if (playbackType == PlaybackType.Fixed)
		{
			ForceSingleTrackFromAdaptive = true;
		}
		return StartLoadSource(mediaSource, audioUri, isLive);
	}

	private async Task StartLoadSource(IMediaSource mediaSource, string audioUri, bool isLive)
	{
		await Task.WhenAll(StartLoadAudio(audioUri), PrepareVideo(mediaSource));
		SetUpClosedCaptions(isLive);
	}

	private async Task PrepareVideo(IMediaSource mediaSource)
	{
		if (externalMediaSourceEventListener != null)
		{
			mediaSource.AddEventListener(mainLooperHandler, externalMediaSourceEventListener);
		}
		await videoPlayerCreationTcs.Task;
		dispatcher.RequestMainThreadAction(delegate
		{
			if (!isDisposed)
			{
				VideoPlayer.Volume = VideoVolume;
				VideoPlayer.AddListener(internalPlayerEventListener);
				VideoPlayer.AddVideoListener(internalVideoListener);
				VideoPlayer.SetMediaSource(mediaSource, resetPosition: false);
				VideoPlayer.Prepare();
			}
		});
	}

	private void SetUpClosedCaptions(bool isLiveStream)
	{
		ClosedCaptionLanguage preferredClosedCaptionLanguage = closedCaptionsPreferredLanguage?.PreferredLanguage;
		videoTrackSelector.Configure(preferredClosedCaptionLanguage, isLiveStream);
	}

	private IMediaSource LoadFixedStream(string fixedStreamUrl)
	{
		DefaultDataSourceFactory dataSourceFactory = new DefaultDataSourceFactory(Application.Context, "shire");
		DefaultExtractorsFactory extractorsFactory = new DefaultExtractorsFactory();
		MediaItem mediaItem = CreateMediaItem(fixedStreamUrl);
		iFit.Logger.Log.Trace("Video", $"Loaded built-in fixed media source with video quality {SelectedVideoQuality} from url {fixedStreamUrl}");
		return new ProgressiveMediaSource.Factory(dataSourceFactory, extractorsFactory).CreateMediaSource(mediaItem);
	}

	private IDataSourceFactory BuildStreamingDataSourceFactory(ITransferListener transferListener, string userAgent)
	{
		IDataSourceFactory dataSourceFactory = null;
		DataSourceType dataSourceType = videoQualitySettings.DataSourceType;
		dataSourceFactory = ((dataSourceType != DataSourceType.Cronet) ? ((IDataSourceFactory)CreateDefaultFactory()) : ((IDataSourceFactory)new CronetDataSource.Factory(new CronetEngineWrapper(Application.Context), Executors.NewSingleThreadExecutor()).SetTransferListener(transferListener).SetFallbackFactory(CreateDefaultFactory())));
		iFit.Logger.Log.Trace("Video", "Video Data Source is " + dataSourceFactory?.GetType()?.FullName);
		return dataSourceFactory;
		DefaultHttpDataSource.Factory CreateDefaultFactory()
		{
			return new DefaultHttpDataSource.Factory().SetUserAgent(userAgent).SetTransferListener(transferListener);
		}
	}

	private async Task StartLoadAudio(string audioUri)
	{
		iFit.Logger.Log.Trace("Video", "StartLoadSource for audio");
		if (string.IsNullOrWhiteSpace(audioUri))
		{
			return;
		}
		MediaItem mediaItem = CreateMediaItem(audioUri);
		DefaultDataSourceFactory dataSourceFactory = new DefaultDataSourceFactory(Application.Context, "wolf");
		DefaultExtractorsFactory extractorsFactory = new DefaultExtractorsFactory();
		IMediaSource audioSource = new ProgressiveMediaSource.Factory(dataSourceFactory, extractorsFactory).CreateMediaSource(mediaItem);
		await audioPlayerCreationTcs.Task;
		dispatcher.RequestMainThreadAction(delegate
		{
			if (!isDisposed)
			{
				AudioPlayer.Volume = AudioVolume;
				AudioPlayer.AddListener(audioPlayerEventListener);
				AudioPlayer.SetMediaSource(audioSource, resetPosition: false);
				AudioPlayer.Prepare();
			}
		});
	}

	private void UpdateIsLoading()
	{
		bool flag = BufferSecondsRemaining < TimeSpan.FromMilliseconds(CurrentSettingsInfo.PlaybackBufferAfterRebufferMs).TotalSeconds;
		SimpleExoPlayer videoPlayer = VideoPlayer;
		int num;
		if (videoPlayer == null || videoPlayer.PlaybackState != PlaybackState.Idle)
		{
			SimpleExoPlayer videoPlayer2 = VideoPlayer;
			num = ((videoPlayer2 != null && videoPlayer2.PlaybackState == PlaybackState.Buffering) ? 1 : 0);
		}
		else
		{
			num = 1;
		}
		bool flag2 = (byte)num != 0;
		IsLoading = flag && flag2;
	}

	public void Play(PlayerType playerType = PlayerType.Both)
	{
		iFit.Logger.Log.Trace("Video", "Play audio/video player");
		CheckAndInvokeOnMainThread(ShouldActOnVideoPlayer(playerType), delegate
		{
			if (ResumeBehavior == PauseResumeBehavior.ResumeLiveStreamTime && !VideoPlayer.PlayWhenReady)
			{
				VideoPlayer.SeekToDefaultPosition();
			}
			VideoPlayer.PlayWhenReady = true;
		});
		CheckAndInvokeOnMainThread(ShouldActOnAudioPlayer(playerType), delegate
		{
			AudioPlayer.PlayWhenReady = true;
		});
	}

	public void Pause(PlayerType playerType = PlayerType.Both)
	{
		iFit.Logger.Log.Trace("Video", "Pause audio/video player");
		dispatcher.RequestMainThreadAction(delegate
		{
			if (playerType.HasFlag(PlayerType.Video) && VideoPlayer != null)
			{
				VideoPlayer.PlayWhenReady = false;
			}
			if (playerType.HasFlag(PlayerType.Audio) && AudioPlayer != null)
			{
				AudioPlayer.PlayWhenReady = false;
			}
		});
	}

	public void Stop(PlayerType playerType = PlayerType.Both)
	{
		Pause(playerType);
		iFit.Logger.Log.Trace("Video", $"CombinedAudioVideoPlayer Stop: {playerType}");
		CheckAndInvokeOnMainThread(ShouldActOnVideoPlayer(playerType), delegate
		{
			VideoPlayer?.Stop(true);
		});
		CheckAndInvokeOnMainThread(ShouldActOnAudioPlayer(playerType), delegate
		{
			AudioPlayer?.Stop(true);
		});
	}

	public void SeekTo(double seconds, PlayerType playerType = PlayerType.Both, bool forceSeek = false)
	{
		long seekMilliSeconds = (long)(seconds * 1000.0);
		if (VideoPlayer != null && (forceSeek || (System.Math.Abs(seekMilliSeconds - VideoPlayer.CurrentPosition) > 1000 && seconds >= LastVideoPositionSeconds)))
		{
			iFit.Logger.Log.Trace("Video", $"Seek audio/video player - forced {forceSeek}");
			CheckAndInvokeOnMainThread(ShouldActOnVideoPlayer(playerType), delegate
			{
				VideoPlayer.SeekTo(seekMilliSeconds);
			});
			CheckAndInvokeOnMainThread(ShouldActOnAudioPlayer(playerType), delegate
			{
				AudioPlayer.SeekTo(seekMilliSeconds);
			});
		}
		else
		{
			iFit.Logger.Log.Trace("Video", $"Seek audio/video player - FAILED with seconds: {seconds}");
		}
	}

	public void RecoverVideo(int seconds)
	{
		WhenVideoPositionSecondsChanged.Where((double _) => !IsLoading && !VideoFailedToLoad).Take(1).Subscribe(delegate
		{
			SeekTo(seconds, PlayerType.Video, forceSeek: true);
		});
	}

	private void CheckAndInvokeOnMainThread(bool shouldInvokeAction, Action action)
	{
		if (shouldInvokeAction)
		{
			dispatcher.RequestMainThreadAction(action);
		}
	}

	private MediaItem CreateMediaItem(string uriString)
	{
		Uri uri = Uri.Parse(uriString);
		int num = videoQualitySettings.LiveStreamSecondsBehindEdge * 1000;
		return new MediaItem.Builder().SetUri(uri).SetLiveTargetOffsetMs(num).Build();
	}

	private (int Width, int Height) GetResolutionValues(VideoQuality videoQuality)
	{
		Resources system = Resources.System;
		bool flag = system == null || !(system.Configuration?.Orientation).HasValue || Resources.System.Configuration.Orientation == Orientation.Landscape;
		(int, int) result = videoQuality switch
		{
			VideoQuality.Resolution270P => (480, 270), 
			VideoQuality.Resolution360P => (640, 360), 
			VideoQuality.Resolution540P => (960, 540), 
			VideoQuality.Resolution720P => (1280, 720), 
			_ => (3000, 2000), 
		};
		if (!flag)
		{
			return (Width: result.Item2, Height: result.Item1);
		}
		return result;
	}
}
public class CustomTrackSelector : DefaultTrackSelector
{
	private const string ClosedCaptionsLogTag = "ClosedCaptions";

	private bool? isCurrentVideoLiveStream;

	private ClosedCaptionLanguage preferredClosedCaptionLanguage;

	private ClosedCaptionLanguage selectedClosedCaptionsLanguage;

	public ClosedCaptionLanguage SelectedClosedCaptionsLanguage
	{
		get
		{
			return selectedClosedCaptionsLanguage;
		}
		private set
		{
			selectedClosedCaptionsLanguage = value;
			this.OnClosedCaptionsLanguageChanged?.Invoke(this, selectedClosedCaptionsLanguage);
		}
	}

	public event EventHandler<ClosedCaptionLanguage> OnClosedCaptionsLanguageChanged;

	public CustomTrackSelector(Context context, IExoTrackSelectionFactory adaptiveFactory)
		: base(context, adaptiveFactory)
	{
	}

	public void Configure(ClosedCaptionLanguage preferredClosedCaptionLanguage, bool isCurrentVideoLiveStream)
	{
		this.preferredClosedCaptionLanguage = preferredClosedCaptionLanguage;
		this.isCurrentVideoLiveStream = isCurrentVideoLiveStream;
	}

	protected override Pair SelectTextTrack(TrackGroupArray groups, int[][] formatSupport, Parameters @params, string selectedAudioLanguage)
	{
		if (!isCurrentVideoLiveStream.HasValue || !isCurrentVideoLiveStream.Value)
		{
			if (preferredClosedCaptionLanguage == null)
			{
				iFit.Logger.Log.Trace("ClosedCaptions", "CustomTrackSelector preferred language is null");
				SelectedClosedCaptionsLanguage = null;
				return null;
			}
			iFit.Logger.Log.Trace("ClosedCaptions", "CustomTrackSelector trying to find CC for preferred language name \"" + preferredClosedCaptionLanguage.Name + "\", code \"" + preferredClosedCaptionLanguage.LanguageCode + "\"");
			for (int i = 0; i < groups.Length; i++)
			{
				TrackGroup trackGroup = groups.Get(i);
				int[] trackFormatSupport = formatSupport[i];
				Pair textTrackPairForPreferredLanguage = GetTextTrackPairForPreferredLanguage(trackGroup, trackFormatSupport, preferredClosedCaptionLanguage, @params, selectedAudioLanguage);
				if (textTrackPairForPreferredLanguage != null)
				{
					SelectedClosedCaptionsLanguage = preferredClosedCaptionLanguage;
					return textTrackPairForPreferredLanguage;
				}
			}
			iFit.Logger.Log.Trace("ClosedCaptions", "CustomTrackSelector couldn't find CC for \"" + preferredClosedCaptionLanguage.Name + "\", code \"" + preferredClosedCaptionLanguage.LanguageCode + "\"");
			SelectedClosedCaptionsLanguage = null;
			return null;
		}
		SelectedClosedCaptionsLanguage = null;
		return base.SelectTextTrack(groups, formatSupport, @params, selectedAudioLanguage);
	}

	private Pair GetTextTrackPairForPreferredLanguage(TrackGroup trackGroup, int[] trackFormatSupport, ClosedCaptionLanguage preferredLanguage, Parameters @params, string selectedAudioLanguage)
	{
		Pair result = null;
		for (int i = 0; i < trackGroup.Length; i++)
		{
			if (!DefaultTrackSelector.IsSupported(trackFormatSupport[i], allowExceedsCapabilities: false))
			{
				continue;
			}
			Format format = trackGroup.GetFormat(i);
			if (format.Language != null && !(format.Language == "und"))
			{
				Locale locale = Locale.ForLanguageTag(format.Language);
				string iSO3Language = locale.ISO3Language;
				iFit.Logger.Log.Trace("ClosedCaptions", "CustomTrackSelector contains CC for : " + format.Label + " raw code " + format.Language + " ISO3 code \"" + iSO3Language + "\"");
				if (preferredLanguage.LanguageCode == iSO3Language)
				{
					ExoTrackSelectionDefinition a = new ExoTrackSelectionDefinition(trackGroup, i);
					TextTrackScore b = new TextTrackScore(format, @params, trackFormatSupport[i], selectedAudioLanguage);
					iFit.Logger.Log.Trace("ClosedCaptions", "CustomTrackSelector selected language \"" + iSO3Language + "\" for closed captions");
					result = Pair.Create(a, b);
				}
			}
		}
		return result;
	}
}
public class DripLoadControl : DefaultLoadControl
{
	public new class Builder
	{
		private DefaultAllocator allocator;

		private int minBufferMs;

		private int maxBufferMs;

		private int bufferForPlaybackMs;

		private int bufferForPlaybackAfterRebufferMs;

		private int targetBufferBytes;

		private bool prioritizeTimeOverSizeThresholds;

		private int backBufferDurationMs;

		private bool retainBackBufferFromKeyframe;

		private bool buildCalled;

		public Builder()
		{
			minBufferMs = 50000;
			maxBufferMs = 50000;
			bufferForPlaybackMs = 2500;
			bufferForPlaybackAfterRebufferMs = 5000;
			targetBufferBytes = -1;
			prioritizeTimeOverSizeThresholds = false;
			backBufferDurationMs = 0;
			retainBackBufferFromKeyframe = false;
		}

		public DefaultLoadControl CreateDripLoadControl()
		{
			if (buildCalled)
			{
				throw new IllegalStateException("Attempting to create load control after build has been called!");
			}
			buildCalled = true;
			if (allocator == null)
			{
				allocator = new DefaultAllocator(trimOnReset: true, 65536);
			}
			return new DripLoadControl(allocator, minBufferMs, maxBufferMs, bufferForPlaybackMs, bufferForPlaybackAfterRebufferMs, targetBufferBytes, prioritizeTimeOverSizeThresholds, backBufferDurationMs, retainBackBufferFromKeyframe);
		}

		public Builder SetAllocator(DefaultAllocator allocator)
		{
			if (buildCalled)
			{
				throw new IllegalStateException("Attempting to set allocator after build has been called!");
			}
			this.allocator = allocator;
			return this;
		}

		public Builder SetBufferDurationsMs(int minBufferMs, int maxBufferMs, int bufferForPlaybackMs, int bufferForPlaybackAfterRebufferMs)
		{
			if (buildCalled)
			{
				throw new IllegalStateException("Attempting to set buffer durations after build has been called!");
			}
			this.bufferForPlaybackMs = System.Math.Max(bufferForPlaybackMs, 0);
			this.bufferForPlaybackAfterRebufferMs = System.Math.Max(bufferForPlaybackAfterRebufferMs, 0);
			this.minBufferMs = System.Math.Max(minBufferMs, System.Math.Max(this.bufferForPlaybackMs, this.bufferForPlaybackAfterRebufferMs));
			this.maxBufferMs = System.Math.Max(maxBufferMs, minBufferMs);
			return this;
		}

		public Builder SetPrioritizeTimeOverSizeThresholds(bool prioritizeTimeOverSizeThresholds)
		{
			this.prioritizeTimeOverSizeThresholds = prioritizeTimeOverSizeThresholds;
			return this;
		}
	}

	private const int AboveHighWatermark = 0;

	private const int BetweenWatermarks = 1;

	private const int BelowLowWatermark = 2;

	private long minBufferUs;

	private long maxBufferUs;

	private int targetBufferBytes;

	private bool isBuffering;

	private bool prioritizeTimeOverSizeThresholds;

	public DripLoadControl(DefaultAllocator allocator, int minBufferMs, int maxBufferMs, int bufferForPlaybackMs, int bufferForPlaybackAfterRebufferMs, int targetBufferBytes, bool prioritizeTimeOverSizeThresholds, int backBufferDurationMs, bool retainBackBufferFromKeyframe)
		: base(allocator, minBufferMs, maxBufferMs, bufferForPlaybackMs, bufferForPlaybackAfterRebufferMs, targetBufferBytes, prioritizeTimeOverSizeThresholds, backBufferDurationMs, retainBackBufferFromKeyframe)
	{
		minBufferUs = C.MsToUs(minBufferMs);
		maxBufferUs = C.MsToUs(maxBufferMs);
		this.targetBufferBytes = targetBufferBytes;
		this.prioritizeTimeOverSizeThresholds = prioritizeTimeOverSizeThresholds;
	}

	public override bool ShouldContinueLoading(long playbackPositionUs, long bufferedDurationUs, float playbackSpeed)
	{
		long num = minBufferUs;
		if (playbackSpeed > 1f)
		{
			long mediaDurationForPlayoutDuration = Util.GetMediaDurationForPlayoutDuration(num, playbackSpeed);
			num = System.Math.Min(mediaDurationForPlayoutDuration, maxBufferUs);
		}
		num = System.Math.Max(num, 500000L);
		ComputeIsBuffering(bufferedDurationUs, num);
		return isBuffering;
	}

	private void ComputeIsBuffering(long bufferedDurationUs, long minBufferUs)
	{
		bool flag = Allocator.TotalBytesAllocated >= targetBufferBytes;
		isBuffering = GetBufferTimeState(bufferedDurationUs, minBufferUs) switch
		{
			2 => true, 
			1 => prioritizeTimeOverSizeThresholds || !flag, 
			_ => false, 
		};
	}

	private int GetBufferTimeState(long bufferedDurationUs, long minBufferUs)
	{
		if (bufferedDurationUs <= maxBufferUs)
		{
			if (bufferedDurationUs >= minBufferUs)
			{
				return 1;
			}
			return 2;
		}
		return 0;
	}
}
public class AdaptiveTrackSelectionFactory : IAdaptiveTrackSelectionFactory
{
	private readonly IVideoQualitySettings videoQualitySettings;

	public AdaptiveTrackSelectionFactory(IVideoQualitySettings videoQualitySettings)
	{
		this.videoQualitySettings = videoQualitySettings;
	}

	public IExoTrackSelectionFactory CreateAdaptiveTrackSelectionFactory()
	{
		return new AdaptiveTrackSelection.Factory(videoQualitySettings.VodSettings.MinDurationForQualityIncreaseMs, videoQualitySettings.VodSettings.MaxDurationForQualityDecreaseMs, videoQualitySettings.VodSettings.MinDurationToRetainAfterDiscardMs, videoQualitySettings.VodSettings.BandwidthFraction, videoQualitySettings.VodSettings.BufferedFractionToLiveEdgeForQualityIncrease, IClock.Default);
	}
}
public interface IAdaptiveTrackSelectionFactory
{
	IExoTrackSelectionFactory CreateAdaptiveTrackSelectionFactory();
}
public interface ILoadControlFactory
{
	DefaultLoadControl CreateVideoLoadControl(DefaultAllocator allocator = null);

	DefaultLoadControl CreateAudioLoadControl(DefaultAllocator allocator = null);
}
public class InterceptSubtitlesRenderersFactory : DefaultRenderersFactory
{
	private readonly ITextOutput textOutput;

	public InterceptSubtitlesRenderersFactory(Context context, ITextOutput textOutput)
		: base(context)
	{
		this.textOutput = textOutput;
	}

	protected override void BuildTextRenderers(Context context, ITextOutput output, Looper outputLooper, [GeneratedEnum] ExtensionRendererMode extensionRendererMode, IList<IRenderer> @out)
	{
		@out.Add(new TextRenderer(textOutput, outputLooper));
	}
}
public class LoadControlFactory : ILoadControlFactory
{
	private const bool ShouldPrioritizeBufferTimeOverSize = true;

	public const int IndividualAllocationSize = 65536;

	private readonly IVideoQualitySettings qualitySettings;

	public LoadControlFactory(IVideoQualitySettings qualitySettings)
	{
		this.qualitySettings = qualitySettings;
	}

	public DefaultLoadControl CreateAudioLoadControl(DefaultAllocator allocator = null)
	{
		return CreateLoadControlFromAllocator(allocator);
	}

	public DefaultLoadControl CreateVideoLoadControl(DefaultAllocator allocator = null)
	{
		return CreateLoadControlFromAllocator(allocator);
	}

	private DefaultLoadControl CreateLoadControlFromAllocator(DefaultAllocator allocator)
	{
		if (allocator == null)
		{
			allocator = new DefaultAllocator(trimOnReset: true, 65536);
		}
		LoadControlType loadControlType = qualitySettings.LoadControlType;
		DefaultLoadControl defaultLoadControl = ((loadControlType != LoadControlType.Drip) ? GetDefaultLoadControl(allocator) : GetDripLoadControl(allocator));
		DefaultLoadControl defaultLoadControl2 = defaultLoadControl;
		iFit.Logger.Log.Trace("Video", "Load Control type is: " + defaultLoadControl2?.GetType()?.FullName);
		return defaultLoadControl2;
	}

	private DefaultLoadControl GetDefaultLoadControl(DefaultAllocator allocator)
	{
		return new DefaultLoadControl.Builder().SetAllocator(allocator).SetBufferDurationsMs(qualitySettings.VodSettings.MinBufferMs, qualitySettings.VodSettings.MaxBufferMs, qualitySettings.VodSettings.PlaybackBufferMs, qualitySettings.VodSettings.PlaybackBufferAfterRebufferMs).Build();
	}

	private DefaultLoadControl GetDripLoadControl(DefaultAllocator allocator)
	{
		return new DripLoadControl.Builder().SetAllocator(allocator).SetBufferDurationsMs(qualitySettings.VodSettings.MinBufferMs, qualitySettings.VodSettings.MaxBufferMs, qualitySettings.VodSettings.PlaybackBufferMs, qualitySettings.VodSettings.PlaybackBufferAfterRebufferMs).SetPrioritizeTimeOverSizeThresholds(prioritizeTimeOverSizeThresholds: true)
			.CreateDripLoadControl();
	}
}
public interface IExoplayerAdvancedSettings
{
	bool IsEnableAsyncInputBufferQueueing { get; set; }

	bool IsEnableAsyncQueueingSynchronizationWorkaround { get; set; }

	bool IsEnableSynchronizingCodecInteractionsToAsyncInputBufferQueueing { get; set; }
}
public static class JavaExtensions
{
	public static T DisposeSafe<T>(this T obj) where T : Java.Lang.Object
	{
		if (obj == null || obj.Handle == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			obj.Dispose();
		}
		catch
		{
		}
		return null;
	}
}
public abstract class BasePlayerEventListener : Java.Lang.Object, IPlayerEventListener, IJavaObject, IDisposable, IJavaPeerable
{
	public void OnEvents(IPlayer player, PlayerEvents events)
	{
	}

	public void OnExperimentalOffloadSchedulingEnabledChanged(bool offloadSchedulingEnabled)
	{
	}

	public void OnExperimentalSleepingForOffloadChanged(bool sleepingForOffload)
	{
	}

	public abstract void OnIsLoadingChanged(bool isLoading);

	public void OnIsPlayingChanged(bool isPlaying)
	{
	}

	[Obsolete("deprecated")]
	public void OnLoadingChanged(bool isLoading)
	{
	}

	public void OnMediaItemTransition(MediaItem mediaItem, MediaItemTransitionReason reason)
	{
	}

	public abstract void OnPlayWhenReadyChanged(bool playWhenReady, PlayWhenReadyChangeReason reason);

	public void OnPlaybackParametersChanged(PlaybackParameters playbackParameters)
	{
	}

	public abstract void OnPlaybackStateChanged(PlaybackState state);

	public void OnPlaybackSuppressionReasonChanged(PlaybackSuppressionReason playbackSuppressionReason)
	{
	}

	public abstract void OnPlayerError(ExoPlaybackException error);

	[Obsolete("deprecated")]
	public void OnPlayerStateChanged(bool playWhenReady, PlaybackState playbackState)
	{
	}

	public void OnPositionDiscontinuity(DiscontinuityReason reason)
	{
	}

	public void OnRepeatModeChanged(RepeatMode repeatMode)
	{
	}

	[Obsolete("deprecated")]
	public void OnSeekProcessed()
	{
	}

	public void OnShuffleModeEnabledChanged(bool shuffleModeEnabled)
	{
	}

	public void OnStaticMetadataChanged(IList<Metadata> metadataList)
	{
	}

	public void OnTimelineChanged(Timeline timeline, TimelineChangeReason reason)
	{
	}

	[Obsolete("deprecated")]
	public void OnTimelineChanged(Timeline timeline, Java.Lang.Object manifest, TimelineChangeReason reason)
	{
	}

	public virtual void OnTracksChanged(TrackGroupArray trackGroups, TrackSelectionArray trackSelections)
	{
	}
}
public class AudioPlayerEventListener : BasePlayerEventListener
{
	private const string Tag = "Audio";

	public override void OnIsLoadingChanged(bool isLoading)
	{
		iFit.Logger.Log.Trace("Audio", $"Audio player loading changed, Is Loading: {isLoading}");
	}

	public override void OnPlayWhenReadyChanged(bool playWhenReady, PlayWhenReadyChangeReason reason)
	{
		iFit.Logger.Log.Trace("Audio", $"Audio player playWhenReady changed: playWhenReady={playWhenReady}, playWhenReadyChangeReason={reason}");
	}

	public override void OnPlaybackStateChanged(PlaybackState state)
	{
		iFit.Logger.Log.Trace("Audio", $"Audio player playback state changed: playbackState={state}");
	}

	public override void OnPlayerError(ExoPlaybackException error)
	{
		iFit.Logger.Log.Trace("Audio", $"Audio player error: {error}");
	}
}
public class CustomEventLogger : EventLogger
{
	private readonly ICombinedAudioVideoPlayer combinedAudioVideoPlayer;

	public CustomEventLogger(MappingTrackSelector trackSelector, ICombinedAudioVideoPlayer combinedAudioVideoPlayer)
		: base(trackSelector)
	{
		this.combinedAudioVideoPlayer = combinedAudioVideoPlayer;
	}

	public CustomEventLogger(MappingTrackSelector trackSelector, string tag, ICombinedAudioVideoPlayer combinedAudioVideoPlayer)
		: base(trackSelector, tag)
	{
		this.combinedAudioVideoPlayer = combinedAudioVideoPlayer;
	}

	public override void OnPositionDiscontinuity(AnalyticsListenerEventTime eventTime, DiscontinuityReason reason)
	{
		base.OnPositionDiscontinuity(eventTime, reason);
		VideoStutterReason stutterReason = reason switch
		{
			DiscontinuityReason.PeriodTransition => VideoStutterReason.PeriodTransition, 
			DiscontinuityReason.Seek => VideoStutterReason.Seek, 
			DiscontinuityReason.SeekAdjustment => VideoStutterReason.SeekAdjustment, 
			DiscontinuityReason.AdInsertion => VideoStutterReason.AdInsertion, 
			DiscontinuityReason.Internal => VideoStutterReason.Internal, 
			_ => throw new ArgumentOutOfRangeException("reason", reason, null), 
		};
		combinedAudioVideoPlayer.OnVideoStuttered(stutterReason);
	}
}
public class SimpleCaptionListener : Java.Lang.Object, ITextOutput, IJavaObject, IDisposable, IJavaPeerable
{
	public event EventHandler<string> OnNewCaptionString;

	public void OnCues(IList<Cue> cues)
	{
		if (cues.Count > 0)
		{
			this.OnNewCaptionString?.Invoke(this, cues.First().Text.ToString());
		}
	}
}
public class VideoListener : Java.Lang.Object, IVideoListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly CombinedAudioVideoPlayer avPlayer;

	public Format VideoFormat { get; private set; }

	public VideoListener(CombinedAudioVideoPlayer player)
	{
		avPlayer = player;
	}

	public void OnRenderedFirstFrame()
	{
	}

	public void OnSurfaceSizeChanged(int width, int height)
	{
	}

	public void OnVideoSizeChanged(int width, int height, int unappliedRotationDegrees, float pixelWidthHeightRatio)
	{
		VideoFormat = avPlayer?.VideoPlayer?.VideoFormat;
	}

	public string GetDebugString()
	{
		return GetPlayerStateString() + "\n" + GetVideoString() + "\nvp->" + GetAudioString(avPlayer.VideoPlayer) + "\nap->" + GetAudioString(avPlayer.AudioPlayer);
	}

	private string GetPlayerStateString()
	{
		return $"playWhenReady:{avPlayer?.VideoPlayer?.PlayWhenReady} playbackState:{avPlayer?.VideoPlayer?.PlaybackState} window:{avPlayer?.VideoPlayer?.CurrentWindowIndex}";
	}

	private string GetVideoString()
	{
		Format videoFormat = VideoFormat;
		DecoderCounters decoderCounters = avPlayer?.VideoPlayer?.VideoDecoderCounters;
		if (videoFormat == null || decoderCounters == null)
		{
			return string.Empty;
		}
		long? num = avPlayer.BandWidthMeter?.BitrateEstimate;
		return $"{videoFormat.SampleMimeType}(id:{videoFormat.Id} r:{videoFormat.Width}x{videoFormat.Height} bre:{num}\n\t{GetDecoderCountersBufferCountString(decoderCounters)})";
	}

	private string GetAudioString(SimpleExoPlayer player)
	{
		Format format = player?.AudioFormat;
		DecoderCounters decoderCounters = player?.AudioDecoderCounters;
		if (format == null || decoderCounters == null)
		{
			return string.Empty;
		}
		return $"{format.SampleMimeType} (id:{format.Id} hz:{format.SampleRate} ch:{format.ChannelCount}\n\t{GetDecoderCountersBufferCountString(decoderCounters)})";
	}

	private string GetDecoderCountersBufferCountString(DecoderCounters counters)
	{
		if (counters == null)
		{
			return string.Empty;
		}
		counters.EnsureUpdated();
		return $" sib:{counters.SkippedInputBufferCount} sb:{counters.SkippedOutputBufferCount} rb:{counters.RenderedOutputBufferCount} db:{counters.DroppedBufferCount} mcdb:{counters.MaxConsecutiveDroppedBufferCount} dk:{counters.DroppedToKeyframeCount} fpo:{GetVideoFrameProcessingOffsetAverageString(counters.TotalVideoFrameProcessingOffsetUs, counters.VideoFrameProcessingOffsetCount)}";
	}

	private string GetVideoFrameProcessingOffsetAverageString(long totalOffsetUs, int frameCount)
	{
		if (frameCount == 0)
		{
			return "N/A";
		}
		return ((long)((double)totalOffsetUs / (double)frameCount)).ToString();
	}
}
public class VideoPlayerEventListener : BasePlayerEventListener
{
	private const string Tag = "Video";

	private readonly Subject<System.Exception> _videoErrorOccured = new Subject<System.Exception>();

	private readonly Subject<bool> _videoPlaybackCompleted = new Subject<bool>();

	private readonly CombinedAudioVideoPlayer avPlayer;

	public IObservable<System.Exception> VideoErrorOccured => _videoErrorOccured;

	public IObservable<bool> VideoPlaybackCompleted => _videoPlaybackCompleted;

	public VideoPlayerEventListener(CombinedAudioVideoPlayer avPlayer)
	{
		this.avPlayer = avPlayer;
	}

	public override void OnIsLoadingChanged(bool isLoading)
	{
		iFit.Logger.Log.Trace("Video", $"Video player loading changed, Is Loading: {isLoading}");
	}

	public override void OnPlayWhenReadyChanged(bool playWhenReady, PlayWhenReadyChangeReason reason)
	{
		iFit.Logger.Log.Trace("Video", $"Video playWhenReady changed: playWhenReady={playWhenReady} playWhenReadyChangeReason={reason}");
	}

	public override void OnPlaybackStateChanged(PlaybackState state)
	{
		iFit.Logger.Log.Trace("Video", $"Video playback state changed: state={state}");
		avPlayer.IsBuffering = state == PlaybackState.Buffering;
		if (state == PlaybackState.Ended)
		{
			_videoPlaybackCompleted.OnNext(value: true);
		}
	}

	public override void OnPlayerError(ExoPlaybackException error)
	{
		iFit.Logger.Log.Error("Video", "Video player error", error);
		_videoErrorOccured.OnNext(error);
	}

	public override void OnTracksChanged(TrackGroupArray trackGroups, TrackSelectionArray trackSelections)
	{
		if (!avPlayer.ForceSingleTrackFromAdaptive)
		{
			return;
		}
		CustomTrackSelector videoTrackSelector = avPlayer.videoTrackSelector;
		int num = -1;
		TrackGroupArray trackGroupArray = null;
		MappingTrackSelector.MappedTrackInfo mappedTrackInfo = videoTrackSelector?.CurrentMappedTrackInfo;
		for (int i = 0; i < mappedTrackInfo?.RendererCount; i++)
		{
			TrackType rendererType = mappedTrackInfo.GetRendererType(i);
			if (rendererType == TrackType.Video)
			{
				num = i;
				trackGroupArray = mappedTrackInfo.GetTrackGroups(i);
				break;
			}
		}
		TrackGroup trackGroup = null;
		for (int j = 0; j < trackGroupArray?.Length; j++)
		{
			TrackGroup trackGroup2 = trackGroupArray.Get(j);
			if (MimeTypes.IsVideo((trackGroup2?.GetFormat(0))?.SampleMimeType))
			{
				trackGroup = trackGroup2;
				break;
			}
		}
		if (videoTrackSelector != null)
		{
			if (num > -1 && trackGroupArray != null && trackGroup != null)
			{
				int trackIndexForQuality = TrackSelectionUtils.GetTrackIndexForQuality(trackGroup, avPlayer.SelectedVideoQuality);
				DefaultTrackSelector.SelectionOverride selectionOverride = new DefaultTrackSelector.SelectionOverride(num, trackIndexForQuality);
				videoTrackSelector.SetParameters(videoTrackSelector.BuildUponParameters().SetSelectionOverride(num, trackGroupArray, selectionOverride));
			}
			else
			{
				DefaultTrackSelector.Parameters parameters = videoTrackSelector.GetParameters();
				parameters.ForceLowestBitrate = true;
				videoTrackSelector.SetParameters(parameters);
			}
		}
	}
}
public static class TrackSelectionUtils
{
	private const int PreferredHeight270P = 270;

	private const int PreferredHeight360P = 360;

	private const int PreferredHeight540P = 540;

	private const int PreferredHeight720P = 720;

	private const int PreferredHeight1080P = 1080;

	private static int GetTrackIndexForHeight(TrackGroup videoTracks, int height)
	{
		if (videoTracks.Length < 1)
		{
			return -1;
		}
		for (int i = 0; i < videoTracks.Length; i++)
		{
			Format format = videoTracks.GetFormat(i);
			if (format.Height == height)
			{
				return i;
			}
		}
		List<int> list = new List<int>();
		for (int j = 0; j < videoTracks.Length; j++)
		{
			list.Add(j);
		}
		list.Sort(delegate(int a, int b)
		{
			Format format4 = videoTracks.GetFormat(a);
			Format format5 = videoTracks.GetFormat(b);
			return format4.Height - format5.Height;
		});
		if (height < videoTracks.GetFormat(list[0]).Height)
		{
			return list[0];
		}
		for (int num = 0; num < list.Count; num++)
		{
			if (num == list.Count - 1)
			{
				return num;
			}
			Format format2 = videoTracks.GetFormat(list[num]);
			Format format3 = videoTracks.GetFormat(list[num + 1]);
			if (height > format2.Height && height < format3.Height)
			{
				return list[num];
			}
		}
		return list[0];
	}

	public static int GetTrackIndexForQuality(TrackGroup videoTracks, VideoQuality quality)
	{
		return GetTrackIndexForHeight(videoTracks, quality switch
		{
			VideoQuality.Resolution270P => 270, 
			VideoQuality.Resolution360P => 360, 
			VideoQuality.Resolution540P => 540, 
			VideoQuality.Resolution720P => 720, 
			VideoQuality.Resolution1080P => 1080, 
			_ => 1080, 
		});
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
