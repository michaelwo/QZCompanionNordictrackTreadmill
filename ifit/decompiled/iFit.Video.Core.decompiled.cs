using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Akavache.Sqlite3;
using iFit.Video.ClosedCaptions;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("iFit Video")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Video.Core")]
[assembly: AssemblyTitle("iFit.Video.Core")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Video
{
	[Preserve]
	public static class LinkerPreserve
	{
		static LinkerPreserve()
		{
			throw new Exception(typeof(SQLitePersistentBlobCache).FullName);
		}
	}
	public class PreserveAttribute : Attribute
	{
	}
	public enum AudioSourceChange
	{
		Unplugged,
		PluggedIn
	}
	public enum AudioSourceChangeOption
	{
		Pause,
		Play
	}
	public enum DataSourceType
	{
		Default,
		Cronet
	}
	public enum HlsSupported
	{
		Unknown,
		Supported,
		NotSupported
	}
	public enum LoadControlType
	{
		Default,
		Drip
	}
	public enum PauseResumeBehavior
	{
		ResumeFromPauseTime,
		ResumeLiveStreamTime
	}
	public enum PlaybackType
	{
		Unknown,
		Fixed,
		Hls
	}
	[Flags]
	public enum PlayerType
	{
		None = -2147483648,
		Audio = 1,
		Video = 2,
		Both = 3
	}
	public enum VideoQuality
	{
		[Obsolete("Deprecated, please use specified resolution.")]
		Low = 0,
		[Obsolete("Deprecated, please use specified resolution.")]
		Medium = 1,
		[Obsolete("Deprecated, please use specified resolution.")]
		High = 2,
		[Obsolete("Deprecated, please use specified resolution.")]
		Auto = 3,
		Resolution270P = 100,
		Resolution360P = 101,
		Resolution540P = 102,
		Resolution720P = 103,
		Resolution1080P = 104
	}
	public enum VideoStutterReason
	{
		PeriodTransition,
		Seek,
		SeekAdjustment,
		AdInsertion,
		Internal
	}
	public class IfitVideoException : Exception
	{
		public IfitVideoException()
		{
		}

		public IfitVideoException(string message)
			: base(message)
		{
		}
	}
	public class MediaServicesWereResetException : Exception
	{
	}
	public interface ICombinedAudioVideoPlayer : IDisposable
	{
		bool IsLoading { get; }

		bool IsBuffering { get; }

		double BufferSecondsRemaining { get; }

		bool VideoFailedToLoad { get; }

		IObservable<Exception> VideoErrorOccured { get; }

		IObservable<bool> VideoPlaybackCompleted { get; }

		IObservable<bool> WhenIsLoadingChanged { get; }

		IObservable<bool> WhenIsBufferingChanged { get; }

		IObservable<double> WhenVideoPositionSecondsChanged { get; }

		IObservable<string> WhenVideoResolutionChanged { get; }

		IObservable<bool> WhenVideoPlaybackInterrupted { get; }

		IObservable<AudioSourceChange> WhenAudioSourceChanged { get; }

		AudioSourceChangeOption AudioSourceConnectedOption { get; set; }

		AudioSourceChangeOption AudioSourceDisconnectedOption { get; set; }

		ClosedCaptionLanguage SelectedClosedCaptionsLanguage { get; }

		double BufferedSeconds { get; }

		double VideoPositionSeconds { get; }

		double LastVideoPositionSeconds { get; }

		double AudioPosition { get; }

		int VideoRenderedOutputBufferCount { get; }

		int VideoSkippedOutputBufferCount { get; }

		int VideoDroppedBufferCount { get; }

		int VideoMaxConsecutiveDroppedBufferCount { get; }

		int VideoStutteredPeriodTransitionCount { get; }

		int VideoStutteredSeekCount { get; }

		int VideoStutteredSeekAdjustmentCount { get; }

		int VideoStutteredAdInsertionCount { get; }

		int VideoStutteredInternalCount { get; }

		int VideoStutteredUnknownCount { get; }

		SettingsInfo CurrentSettingsInfo { get; }

		int AudioRenderedOutputBufferCount { get; }

		int AudioSkippedOutputBufferCount { get; }

		int AudioDroppedBufferCount { get; }

		int AudioMaxConsecutiveDroppedBufferCount { get; }

		float VideoVolume { get; set; }

		float AudioVolume { get; set; }

		PlaybackType SelectedPlaybackType { get; }

		VideoQuality SelectedVideoQuality { get; }

		PauseResumeBehavior ResumeBehavior { get; }

		event EventHandler<string> OnNewCaptionString;

		event EventHandler<ClosedCaptionLanguage> OnClosedCaptionsLanguageChanged;

		Task StartLoadDirectSource(string directVideoUri, string audioUri = null);

		Task StartLoadStream(string streamVideoUri, PlaybackType playbackType, string audioUri = null);

		Task StartLoadVodSource(string vodUri, PlaybackType playbackType, string audioUri = null);

		void Play(PlayerType playerType = PlayerType.Both);

		void Pause(PlayerType playerType = PlayerType.Both);

		void Stop(PlayerType playerType = PlayerType.Both);

		void SeekTo(double seconds, PlayerType playerType = PlayerType.Both, bool forceSeek = false);

		bool IsReadyToPlay();

		void ApplicationPaused();

		Task ApplicationResumed();

		void RecoverVideo(int seconds);

		string GetVideoString();

		void OnVideoStuttered(VideoStutterReason stutterReason);
	}
	public interface IVideoQualitySettings
	{
		VideoQuality VideoQuality { get; }

		DataSourceType DataSourceType { get; }

		LoadControlType LoadControlType { get; }

		SettingsInfo LiveSettings { get; }

		SettingsInfo VodSettings { get; }

		int LiveStreamSecondsBehindEdge { get; }

		bool ViewportOrientationMayChange { get; }

		void ClearQualitySettings();
	}
	public static class ResolutionUtils
	{
		public static string GetVideoResolution(int height)
		{
			if (height >= 1080)
			{
				return "1080p";
			}
			if (height >= 720)
			{
				return "720p";
			}
			if (height >= 480)
			{
				return "480p";
			}
			if (height >= 360)
			{
				return "360p";
			}
			if (height >= 240)
			{
				return "240p";
			}
			return "144p";
		}
	}
	public class SettingsInfo
	{
		public int MinBufferMs { get; set; }

		public int MaxBufferMs { get; set; }

		public int PlaybackBufferMs { get; set; }

		public int PlaybackBufferAfterRebufferMs { get; set; }

		public int PreferredForwardBufferSeconds { get; set; }

		public int InitialBitrateEstimate { get; set; }

		public int MinDurationForQualityIncreaseMs { get; set; }

		public int MaxDurationForQualityDecreaseMs { get; set; }

		public int MinDurationToRetainAfterDiscardMs { get; set; }

		public float BandwidthFraction { get; set; }

		public float BufferedFractionToLiveEdgeForQualityIncrease { get; set; }

		public bool AllowVideoNonSeamlessAdaptiveness { get; set; }

		public bool AllowBufferingWhilePaused { get; set; }

		public override string ToString()
		{
			return $"LoadControl Props: MinBufferMs {MinBufferMs}, MaxBufferMs {MaxBufferMs}, PlaybackBufferMs {PlaybackBufferMs}, PlaybackBufferAfterRebufferMs {PlaybackBufferAfterRebufferMs}, PreferredForwardBufferSeconds {PreferredForwardBufferSeconds}" + Environment.NewLine + $"AdaptiveTrackSelection.Factory Props: InitialBitrateEstimate {InitialBitrateEstimate}, MinDurationForQualityIncreaseMs {MinDurationForQualityIncreaseMs}, MaxDurationForQualityDecreaseMs {MaxDurationForQualityDecreaseMs}, MinDurationToRetainAfterDiscardMs {MinDurationToRetainAfterDiscardMs}, BandwidthFraction {BandwidthFraction}, BufferedFractionToLiveEdgeForQualityIncrease {BufferedFractionToLiveEdgeForQualityIncrease}, AllowVideoNonSeamlessAdaptiveness {AllowVideoNonSeamlessAdaptiveness}";
		}
	}
	public static class VideoQualityMapper
	{
		public static VideoQuality MapToNewQuality(this VideoQuality oldOne)
		{
			return oldOne switch
			{
				VideoQuality.Auto => VideoQuality.Resolution1080P, 
				VideoQuality.High => VideoQuality.Resolution540P, 
				VideoQuality.Medium => VideoQuality.Resolution360P, 
				VideoQuality.Low => VideoQuality.Resolution270P, 
				_ => oldOne, 
			};
		}
	}
}
namespace iFit.Video.ClosedCaptions
{
	public class ClosedCaptionLanguage
	{
		public string Name { get; }

		public string LanguageCode { get; }

		public ClosedCaptionLanguage(string name, string languageCode)
		{
			Name = name;
			LanguageCode = languageCode;
		}
	}
	public interface IClosedCaptionsPreferredLanguage
	{
		ClosedCaptionLanguage PreferredLanguage { get; set; }
	}
}
