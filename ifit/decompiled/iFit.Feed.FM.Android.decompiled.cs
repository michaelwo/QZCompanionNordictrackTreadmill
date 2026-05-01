using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Net;
using Android.Runtime;
using Android.Widget;
using Com.Google.Android.Exoplayer2;
using Com.Google.Android.Exoplayer2.Source;
using Com.Google.Android.Exoplayer2.Trackselection;
using FM.Feed.Android.Playersdk.Models;
using Java.Interop;
using Java.Lang;
using Java.Util;
using Kotlin.Jvm.Internal;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "fm.feed.android.playersdk", Managed = "FM.Feed.Android.Playersdk")]
[assembly: NamespaceMapping(Java = "fm.feed.android.playersdk.models", Managed = "FM.Feed.Android.Playersdk.Models")]
[assembly: NamespaceMapping(Java = "fm.feed.android.playersdk.models.webservice", Managed = "FM.Feed.Android.Playersdk.Models.Webservice")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("iFIT")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("Feed FM Android bindings library")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Feed.FM.Android")]
[assembly: AssemblyTitle("iFit.Feed.FM.Android")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate float _JniMarshal_PP_F(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPF_V(IntPtr jnienv, IntPtr klass, float p0);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPILJ_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, long p2);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLFF_V(IntPtr jnienv, IntPtr klass, IntPtr p0, float p1, float p2);
internal delegate void _JniMarshal_PPLIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3);
internal delegate void _JniMarshal_PPLIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
internal delegate void _JniMarshal_PPZI_V(IntPtr jnienv, IntPtr klass, bool p0, int p1);
namespace System.Runtime.Versioning
{
	[Conditional("NEVER")]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event, AllowMultiple = true, Inherited = false)]
	internal sealed class SupportedOSPlatformAttribute : Attribute
	{
		public SupportedOSPlatformAttribute(string platformName)
		{
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[0], new Converter<string, Type>[0]);
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
	}
}
namespace FM.Feed.Android.Playersdk
{
	[Register("fm/feed/android/playersdk/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("FLAVOR")]
		public const string Flavor = "exoDefault";

		[Register("LIBRARY_PACKAGE_NAME")]
		public const string LibraryPackageName = "fm.feed.android.playersdk";

		[Register("VERSION_NAME")]
		public const string VersionName = "6.1.6";

		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/BuildConfig", typeof(BuildConfig));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BuildConfig(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BuildConfig()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("fm/feed/android/playersdk/FeedAudioPlayer", DoNotGenerateAcw = true)]
	public sealed class FeedAudioPlayer : Java.Lang.Object
	{
		[Register("fm/feed/android/playersdk/FeedAudioPlayer$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/FeedAudioPlayer$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe Context Context
			{
				[Register("getContext", "()Landroid/content/Context;", "")]
				get
				{
					return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", "")]
			public unsafe Builder(Context context, string token, string secret)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.NewString(token);
				IntPtr intPtr2 = JNIEnv.NewString(secret);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(context);
				}
			}

			[Register("build", "()Lfm/feed/android/playersdk/FeedAudioPlayer;", "")]
			public unsafe FeedAudioPlayer Build()
			{
				return Java.Lang.Object.GetObject<FeedAudioPlayer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("build.()Lfm/feed/android/playersdk/FeedAudioPlayer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setAvailabilityListener", "(Lfm/feed/android/playersdk/AvailabilityListener;)Lfm/feed/android/playersdk/FeedAudioPlayer$Builder;", "")]
			public unsafe Builder SetAvailabilityListener(IAvailabilityListener availabilityListener)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((availabilityListener == null) ? IntPtr.Zero : ((Java.Lang.Object)availabilityListener).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setAvailabilityListener.(Lfm/feed/android/playersdk/AvailabilityListener;)Lfm/feed/android/playersdk/FeedAudioPlayer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(availabilityListener);
				}
			}

			[Register("setClientId", "(Ljava/lang/String;)Lfm/feed/android/playersdk/FeedAudioPlayer$Builder;", "")]
			public unsafe Builder SetClientId(string clientId)
			{
				IntPtr intPtr = JNIEnv.NewString(clientId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setClientId.(Ljava/lang/String;)Lfm/feed/android/playersdk/FeedAudioPlayer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setCreateNewClientId", "(Z)Lfm/feed/android/playersdk/FeedAudioPlayer$Builder;", "")]
			public unsafe Builder SetCreateNewClientId(bool createNewClientId)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(createNewClientId);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setCreateNewClientId.(Z)Lfm/feed/android/playersdk/FeedAudioPlayer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setMockLocation", "(Lfm/feed/android/playersdk/MockLocations;)Lfm/feed/android/playersdk/FeedAudioPlayer$Builder;", "")]
			public unsafe Builder SetMockLocation(MockLocations location)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(location?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setMockLocation.(Lfm/feed/android/playersdk/MockLocations;)Lfm/feed/android/playersdk/FeedAudioPlayer$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(location);
				}
			}
		}

		[Register("fm/feed/android/playersdk/FeedAudioPlayer$ConnectionStateMonitor", DoNotGenerateAcw = true)]
		public sealed class ConnectionStateMonitor : ConnectivityManager.NetworkCallback
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/FeedAudioPlayer$ConnectionStateMonitor", typeof(ConnectionStateMonitor));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal ConnectionStateMonitor(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lfm/feed/android/playersdk/FeedAudioPlayer;)V", "")]
			public unsafe ConnectionStateMonitor(FeedAudioPlayer __self)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				string constructorSignature = "(L" + JNIEnv.GetJniName(GetType().DeclaringType) + ";)V";
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(__self?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance(constructorSignature, GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance(constructorSignature, this, ptr);
				}
				finally
				{
					GC.KeepAlive(__self);
				}
			}

			[Register("disable", "(Landroid/content/Context;)V", "")]
			public unsafe void Disable(Context context)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("disable.(Landroid/content/Context;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(context);
				}
			}

			[Register("enable", "(Landroid/content/Context;)V", "")]
			public unsafe void Enable(Context context)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("enable.(Landroid/content/Context;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(context);
				}
			}
		}

		[Register("fm/feed/android/playersdk/FeedAudioPlayer$MusicSource", DoNotGenerateAcw = true)]
		public sealed class MusicSource : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/FeedAudioPlayer$MusicSource", typeof(MusicSource));

			[Register("ON_DEMAND")]
			public static MusicSource OnDemand => Java.Lang.Object.GetObject<MusicSource>(_members.StaticFields.GetObjectValue("ON_DEMAND.Lfm/feed/android/playersdk/FeedAudioPlayer$MusicSource;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("STATION")]
			public static MusicSource Station => Java.Lang.Object.GetObject<MusicSource>(_members.StaticFields.GetObjectValue("STATION.Lfm/feed/android/playersdk/FeedAudioPlayer$MusicSource;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal MusicSource(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lfm/feed/android/playersdk/FeedAudioPlayer$MusicSource;", "")]
			public unsafe static MusicSource ValueOf(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<MusicSource>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lfm/feed/android/playersdk/FeedAudioPlayer$MusicSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lfm/feed/android/playersdk/FeedAudioPlayer$MusicSource;", "")]
			public unsafe static MusicSource[] Values()
			{
				return (MusicSource[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lfm/feed/android/playersdk/FeedAudioPlayer$MusicSource;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(MusicSource));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/FeedAudioPlayer", typeof(FeedAudioPlayer));

		private WeakReference weak_implementor_AddAudioFocusListener;

		private WeakReference weak_implementor_AddAvailabilityListener;

		private WeakReference weak_implementor_AddLikeStatusChangeListener;

		private WeakReference weak_implementor_AddMusicQueuedListener;

		private WeakReference weak_implementor_AddOutOfMusicListener;

		private WeakReference weak_implementor_AddPlayListener;

		private WeakReference weak_implementor_AddSkipListener;

		private WeakReference weak_implementor_AddStateListener;

		private WeakReference weak_implementor_AddStationChangedListener;

		private WeakReference weak_implementor_AddUnhandledErrorListener;

		private WeakReference weak_implementor___SetMSessionUpdateListener;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Station ActiveStation
		{
			[Register("getActiveStation", "()Lfm/feed/android/playersdk/models/Station;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Station>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getActiveStation.()Lfm/feed/android/playersdk/models/Station;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Bitmap ArtWork
		{
			[Register("getArtWork", "()Landroid/graphics/Bitmap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getArtWork.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool BIsSkipping
		{
			[Register("getBIsSkipping", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getBIsSkipping.()Z", this, null);
			}
			[Register("setBIsSkipping", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setBIsSkipping.(Z)V", this, ptr);
			}
		}

		public unsafe bool BIsUpdatingSession
		{
			[Register("getBIsUpdatingSession", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getBIsUpdatingSession.()Z", this, null);
			}
			[Register("setBIsUpdatingSession", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setBIsUpdatingSession.(Z)V", this, ptr);
			}
		}

		public unsafe string ClientId
		{
			[Register("getClientId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getClientId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Play CurrentPlay
		{
			[Register("getCurrentPlay", "()Lfm/feed/android/playersdk/models/Play;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Play>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCurrentPlay.()Lfm/feed/android/playersdk/models/Play;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float CurrentPlayDuration
		{
			[Register("getCurrentPlayDuration", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getCurrentPlayDuration.()F", this, null);
			}
		}

		public unsafe float CurrentPlaybackTime
		{
			[Register("getCurrentPlaybackTime", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getCurrentPlaybackTime.()F", this, null);
			}
		}

		public unsafe static bool DisableAudioFocus
		{
			[Register("getDisableAudioFocus", "()Z", "")]
			get
			{
				return _members.StaticMethods.InvokeBooleanMethod("getDisableAudioFocus.()Z", null);
			}
			[Register("setDisableAudioFocus", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.StaticMethods.InvokeVoidMethod("setDisableAudioFocus.(Z)V", ptr);
			}
		}

		public unsafe StationList LocalOfflineStationList
		{
			[Register("getLocalOfflineStationList", "()Lfm/feed/android/playersdk/models/StationList;", "")]
			get
			{
				return Java.Lang.Object.GetObject<StationList>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLocalOfflineStationList.()Lfm/feed/android/playersdk/models/StationList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ISessionUpdateListener MSessionUpdateListener
		{
			[Register("getMSessionUpdateListener", "()Lfm/feed/android/playersdk/SessionUpdateListener;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ISessionUpdateListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getMSessionUpdateListener.()Lfm/feed/android/playersdk/SessionUpdateListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setMSessionUpdateListener", "(Lfm/feed/android/playersdk/SessionUpdateListener;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMSessionUpdateListener.(Lfm/feed/android/playersdk/SessionUpdateListener;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe int MaxBitrate
		{
			[Register("getMaxBitrate", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getMaxBitrate.()I", this, null);
			}
			[Register("setMaxBitrate", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMaxBitrate.(I)V", this, ptr);
			}
		}

		public unsafe NotificationStyle NotificationStyle
		{
			[Register("getNotificationStyle", "()Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
			get
			{
				return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNotificationStyle.()Lfm/feed/android/playersdk/models/NotificationStyle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setNotificationStyle", "(Lfm/feed/android/playersdk/models/NotificationStyle;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setNotificationStyle.(Lfm/feed/android/playersdk/models/NotificationStyle;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe long OfflineStorageUsed
		{
			[Register("getOfflineStorageUsed", "()J", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt64Method("getOfflineStorageUsed.()J", this, null);
			}
		}

		public unsafe PendingIntent PendingIntent
		{
			[Register("getPendingIntent", "()Landroid/app/PendingIntent;", "")]
			get
			{
				return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPendingIntent.()Landroid/app/PendingIntent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPendingIntent", "(Landroid/app/PendingIntent;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPendingIntent.(Landroid/app/PendingIntent;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe IList<Play> PlayHistory
		{
			[Register("getPlayHistory", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<FM.Feed.Android.Playersdk.Models.Play>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPlayHistory.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe PlayList.Editor PlayQueueEditor
		{
			[Register("getPlayQueueEditor", "()Lfm/feed/android/playersdk/models/PlayList$Editor;", "")]
			get
			{
				return Java.Lang.Object.GetObject<PlayList.Editor>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPlayQueueEditor.()Lfm/feed/android/playersdk/models/PlayList$Editor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe StationList RemoteOfflineStationList
		{
			[Register("getRemoteOfflineStationList", "()Lfm/feed/android/playersdk/models/StationList;", "")]
			get
			{
				return Java.Lang.Object.GetObject<StationList>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getRemoteOfflineStationList.()Lfm/feed/android/playersdk/models/StationList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Float SecondsOfCrossfade
		{
			[Register("getSecondsOfCrossfade", "()Ljava/lang/Float;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Float>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSecondsOfCrossfade.()Ljava/lang/Float;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setSecondsOfCrossfade", "(Ljava/lang/Float;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setSecondsOfCrossfade.(Ljava/lang/Float;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe State State
		{
			[Register("getState", "()Lfm/feed/android/playersdk/State;", "")]
			get
			{
				return Java.Lang.Object.GetObject<State>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getState.()Lfm/feed/android/playersdk/State;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe StationList StationList
		{
			[Register("getStationList", "()Lfm/feed/android/playersdk/models/StationList;", "")]
			get
			{
				return Java.Lang.Object.GetObject<StationList>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getStationList.()Lfm/feed/android/playersdk/models/StationList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal FeedAudioPlayer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe FeedAudioPlayer(Context context, string token, string secret)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(token);
			IntPtr intPtr2 = JNIEnv.NewString(secret);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lfm/feed/android/playersdk/AvailabilityListener;)V", "")]
		public unsafe FeedAudioPlayer(Context context, string token, string secret, IAvailabilityListener availabilityListener)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(token);
			IntPtr intPtr2 = JNIEnv.NewString(secret);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue((availabilityListener == null) ? IntPtr.Zero : ((Java.Lang.Object)availabilityListener).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lfm/feed/android/playersdk/AvailabilityListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lfm/feed/android/playersdk/AvailabilityListener;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
				GC.KeepAlive(availabilityListener);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lfm/feed/android/playersdk/AvailabilityListener;Lfm/feed/android/playersdk/MockLocations;)V", "")]
		public unsafe FeedAudioPlayer(Context context, string token, string secret, IAvailabilityListener availabilityListener, MockLocations mockLocation)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(token);
			IntPtr intPtr2 = JNIEnv.NewString(secret);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue((availabilityListener == null) ? IntPtr.Zero : ((Java.Lang.Object)availabilityListener).Handle);
				ptr[4] = new JniArgumentValue(mockLocation?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lfm/feed/android/playersdk/AvailabilityListener;Lfm/feed/android/playersdk/MockLocations;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lfm/feed/android/playersdk/AvailabilityListener;Lfm/feed/android/playersdk/MockLocations;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
				GC.KeepAlive(availabilityListener);
				GC.KeepAlive(mockLocation);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lfm/feed/android/playersdk/AvailabilityListener;Ljava/lang/String;ZLfm/feed/android/playersdk/MockLocations;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe FeedAudioPlayer(Context mContext, string token, string secret, IAvailabilityListener availabilityListener, string exportedClientId, bool createNewClientId, MockLocations location, DefaultConstructorMarker _constructor_marker)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(token);
			IntPtr intPtr2 = JNIEnv.NewString(secret);
			IntPtr intPtr3 = JNIEnv.NewString(exportedClientId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
				*ptr = new JniArgumentValue(mContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue((availabilityListener == null) ? IntPtr.Zero : ((Java.Lang.Object)availabilityListener).Handle);
				ptr[4] = new JniArgumentValue(intPtr3);
				ptr[5] = new JniArgumentValue(createNewClientId);
				ptr[6] = new JniArgumentValue(location?.Handle ?? IntPtr.Zero);
				ptr[7] = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lfm/feed/android/playersdk/AvailabilityListener;Ljava/lang/String;ZLfm/feed/android/playersdk/MockLocations;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lfm/feed/android/playersdk/AvailabilityListener;Ljava/lang/String;ZLfm/feed/android/playersdk/MockLocations;Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				JNIEnv.DeleteLocalRef(intPtr3);
				GC.KeepAlive(mContext);
				GC.KeepAlive(availabilityListener);
				GC.KeepAlive(location);
				GC.KeepAlive(_constructor_marker);
			}
		}

		[Register("addAudioFocusListener", "(Lfm/feed/android/playersdk/AudioFocusListener;)V", "")]
		public unsafe void AddAudioFocusListener(IAudioFocusListener audioFocusListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((audioFocusListener == null) ? IntPtr.Zero : ((Java.Lang.Object)audioFocusListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addAudioFocusListener.(Lfm/feed/android/playersdk/AudioFocusListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(audioFocusListener);
			}
		}

		[Register("addAvailabilityListener", "(Lfm/feed/android/playersdk/AvailabilityListener;)V", "")]
		public unsafe void AddAvailabilityListener(IAvailabilityListener eventListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((eventListener == null) ? IntPtr.Zero : ((Java.Lang.Object)eventListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addAvailabilityListener.(Lfm/feed/android/playersdk/AvailabilityListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(eventListener);
			}
		}

		[Register("addLikeStatusChangeListener", "(Lfm/feed/android/playersdk/LikeStatusChangeListener;)V", "")]
		public unsafe void AddLikeStatusChangeListener(ILikeStatusChangeListener likeStatusChangeListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((likeStatusChangeListener == null) ? IntPtr.Zero : ((Java.Lang.Object)likeStatusChangeListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addLikeStatusChangeListener.(Lfm/feed/android/playersdk/LikeStatusChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(likeStatusChangeListener);
			}
		}

		[Register("addMusicQueuedListener", "(Lfm/feed/android/playersdk/MusicQueuedListener;)V", "")]
		public unsafe void AddMusicQueuedListener(IMusicQueuedListener musicQueuedListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((musicQueuedListener == null) ? IntPtr.Zero : ((Java.Lang.Object)musicQueuedListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addMusicQueuedListener.(Lfm/feed/android/playersdk/MusicQueuedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(musicQueuedListener);
			}
		}

		[Register("addOutOfMusicListener", "(Lfm/feed/android/playersdk/OutOfMusicListener;)V", "")]
		public unsafe void AddOutOfMusicListener(IOutOfMusicListener outOfMusicListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((outOfMusicListener == null) ? IntPtr.Zero : ((Java.Lang.Object)outOfMusicListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addOutOfMusicListener.(Lfm/feed/android/playersdk/OutOfMusicListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(outOfMusicListener);
			}
		}

		[Register("addPlayListener", "(Lfm/feed/android/playersdk/PlayListener;)V", "")]
		public unsafe void AddPlayListener(IPlayListener playListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((playListener == null) ? IntPtr.Zero : ((Java.Lang.Object)playListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addPlayListener.(Lfm/feed/android/playersdk/PlayListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(playListener);
			}
		}

		[Register("addSkipListener", "(Lfm/feed/android/playersdk/SkipListener;)V", "")]
		public unsafe void AddSkipListener(ISkipListener eventListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((eventListener == null) ? IntPtr.Zero : ((Java.Lang.Object)eventListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addSkipListener.(Lfm/feed/android/playersdk/SkipListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(eventListener);
			}
		}

		[Register("addStateListener", "(Lfm/feed/android/playersdk/StateListener;)V", "")]
		public unsafe void AddStateListener(IStateListener stateListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((stateListener == null) ? IntPtr.Zero : ((Java.Lang.Object)stateListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addStateListener.(Lfm/feed/android/playersdk/StateListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(stateListener);
			}
		}

		[Register("addStationChangedListener", "(Lfm/feed/android/playersdk/StationChangedListener;)V", "")]
		public unsafe void AddStationChangedListener(IStationChangedListener stationChangedListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((stationChangedListener == null) ? IntPtr.Zero : ((Java.Lang.Object)stationChangedListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addStationChangedListener.(Lfm/feed/android/playersdk/StationChangedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(stationChangedListener);
			}
		}

		[Register("addUnhandledErrorListener", "(Lfm/feed/android/playersdk/UnhandledErrorListener;)V", "")]
		public unsafe void AddUnhandledErrorListener(IUnhandledErrorListener eventListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((eventListener == null) ? IntPtr.Zero : ((Java.Lang.Object)eventListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addUnhandledErrorListener.(Lfm/feed/android/playersdk/UnhandledErrorListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(eventListener);
			}
		}

		[Register("canSeek", "()Z", "")]
		public unsafe bool CanSeek()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("canSeek.()Z", this, null);
		}

		[Register("canSkip", "()Z", "")]
		public unsafe bool CanSkip()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("canSkip.()Z", this, null);
		}

		[Register("createNewClientId", "(Lfm/feed/android/playersdk/ClientIdListener;)V", "")]
		public unsafe void CreateNewClientId(IClientIdListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("createNewClientId.(Lfm/feed/android/playersdk/ClientIdListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("deleteAllOfflineStations", "()V", "")]
		public unsafe void DeleteAllOfflineStations()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("deleteAllOfflineStations.()V", this, null);
		}

		[Register("deleteOfflineStation", "(Lfm/feed/android/playersdk/models/Station;)V", "")]
		public unsafe void DeleteOfflineStation(Station station)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(station?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("deleteOfflineStation.(Lfm/feed/android/playersdk/models/Station;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(station);
			}
		}

		[Register("destroyInstance", "()V", "")]
		public unsafe void DestroyInstance()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("destroyInstance.()V", this, null);
		}

		[Register("dislike", "()V", "")]
		public unsafe void Dislike()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("dislike.()V", this, null);
		}

		[Register("dislike", "(Lfm/feed/android/playersdk/models/AudioFile;)V", "")]
		public unsafe void Dislike(AudioFile audioFile)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(audioFile?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("dislike.(Lfm/feed/android/playersdk/models/AudioFile;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(audioFile);
			}
		}

		[Register("downloadAndSync", "(Lfm/feed/android/playersdk/models/Station;Lfm/feed/android/playersdk/StationDownloadListener;)V", "")]
		public unsafe void DownloadAndSync(Station station, IStationDownloadListener downloadListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(station?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((downloadListener == null) ? IntPtr.Zero : ((Java.Lang.Object)downloadListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("downloadAndSync.(Lfm/feed/android/playersdk/models/Station;Lfm/feed/android/playersdk/StationDownloadListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(station);
				GC.KeepAlive(downloadListener);
			}
		}

		[Register("downloadAndSync", "(ILfm/feed/android/playersdk/models/Station;Lfm/feed/android/playersdk/StationDownloadListener;)V", "")]
		public unsafe void DownloadAndSync(int targetMins, Station station, IStationDownloadListener downloadListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(targetMins);
				ptr[1] = new JniArgumentValue(station?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((downloadListener == null) ? IntPtr.Zero : ((Java.Lang.Object)downloadListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("downloadAndSync.(ILfm/feed/android/playersdk/models/Station;Lfm/feed/android/playersdk/StationDownloadListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(station);
				GC.KeepAlive(downloadListener);
			}
		}

		[Register("like", "()V", "")]
		public unsafe void Like()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("like.()V", this, null);
		}

		[Register("like", "(Lfm/feed/android/playersdk/models/AudioFile;)V", "")]
		public unsafe void Like(AudioFile audioFile)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(audioFile?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("like.(Lfm/feed/android/playersdk/models/AudioFile;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(audioFile);
			}
		}

		[Register("logEvent", "(Ljava/lang/String;)V", "")]
		public unsafe void LogEvent(string e)
		{
			IntPtr intPtr = JNIEnv.NewString(e);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logEvent.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("logEvent", "(Ljava/lang/String;Ljava/lang/Object;)V", "")]
		public unsafe void LogEvent(string e, Java.Lang.Object @params)
		{
			IntPtr intPtr = JNIEnv.NewString(e);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("logEvent.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@params);
			}
		}

		[Register("maxSeekableLengthInSeconds", "()Ljava/lang/Float;", "")]
		public unsafe Float MaxSeekableLengthInSeconds()
		{
			return Java.Lang.Object.GetObject<Float>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("maxSeekableLengthInSeconds.()Ljava/lang/Float;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("pause", "()V", "")]
		public unsafe void Pause()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("pause.()V", this, null);
		}

		[Register("play", "()V", "")]
		public unsafe void Play()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("play.()V", this, null);
		}

		[Register("play", "(Lfm/feed/android/playersdk/models/AudioFile;)V", "")]
		public unsafe void Play(AudioFile audioFile)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(audioFile?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("play.(Lfm/feed/android/playersdk/models/AudioFile;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(audioFile);
			}
		}

		[Register("play", "(Lfm/feed/android/playersdk/models/AudioFile;Z)V", "")]
		public unsafe void Play(AudioFile audioFile, bool withCrossfade)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(audioFile?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(withCrossfade);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("play.(Lfm/feed/android/playersdk/models/AudioFile;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(audioFile);
			}
		}

		[Register("play", "(Lfm/feed/android/playersdk/models/Station;)V", "")]
		public unsafe void Play(Station station)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(station?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("play.(Lfm/feed/android/playersdk/models/Station;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(station);
			}
		}

		[Register("play", "(Lfm/feed/android/playersdk/models/Station;Z)V", "")]
		public unsafe void Play(Station station, bool withCrossfade)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(station?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(withCrossfade);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("play.(Lfm/feed/android/playersdk/models/Station;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(station);
			}
		}

		[Register("play", "(Ljava/util/List;)V", "")]
		public unsafe void Play(IList<AudioFile> audioFiles)
		{
			IntPtr intPtr = JavaList<AudioFile>.ToLocalJniHandle(audioFiles);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("play.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(audioFiles);
			}
		}

		[Register("play", "(Ljava/util/List;Z)V", "")]
		public unsafe void Play(IList<AudioFile> audioFiles, bool withCrossfade)
		{
			IntPtr intPtr = JavaList<AudioFile>.ToLocalJniHandle(audioFiles);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(withCrossfade);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("play.(Ljava/util/List;Z)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(audioFiles);
			}
		}

		[Register("prepareStations", "(Ljava/util/List;)V", "")]
		public unsafe void PrepareStations(IList<Station> stations)
		{
			IntPtr intPtr = JavaList<Station>.ToLocalJniHandle(stations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("prepareStations.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(stations);
			}
		}

		[Register("prepareStations", "(Ljava/util/List;Lfm/feed/android/playersdk/CachePreparedListener;)V", "")]
		public unsafe void PrepareStations(IList<Station> stations, ICachePreparedListener listener)
		{
			IntPtr intPtr = JavaList<Station>.ToLocalJniHandle(stations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("prepareStations.(Ljava/util/List;Lfm/feed/android/playersdk/CachePreparedListener;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(stations);
				GC.KeepAlive(listener);
			}
		}

		[Register("prepareToPlay", "(Lfm/feed/android/playersdk/models/AudioFile;)V", "")]
		public unsafe void PrepareToPlay(AudioFile audioFile)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(audioFile?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("prepareToPlay.(Lfm/feed/android/playersdk/models/AudioFile;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(audioFile);
			}
		}

		[Register("prepareToPlay", "(Lfm/feed/android/playersdk/models/AudioFile;Lfm/feed/android/playersdk/MusicQueuedListener;)V", "")]
		public unsafe void PrepareToPlay(AudioFile audioFile, IMusicQueuedListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(audioFile?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("prepareToPlay.(Lfm/feed/android/playersdk/models/AudioFile;Lfm/feed/android/playersdk/MusicQueuedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(audioFile);
				GC.KeepAlive(listener);
			}
		}

		[Register("prepareToPlay", "(Lfm/feed/android/playersdk/models/Station;Lfm/feed/android/playersdk/MusicQueuedListener;)V", "")]
		public unsafe void PrepareToPlay(Station station, IMusicQueuedListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(station?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("prepareToPlay.(Lfm/feed/android/playersdk/models/Station;Lfm/feed/android/playersdk/MusicQueuedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(station);
				GC.KeepAlive(listener);
			}
		}

		[Register("removeAudioFocusListener", "(Lfm/feed/android/playersdk/AudioFocusListener;)V", "")]
		public unsafe void RemoveAudioFocusListener(IAudioFocusListener audioFocusListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((audioFocusListener == null) ? IntPtr.Zero : ((Java.Lang.Object)audioFocusListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeAudioFocusListener.(Lfm/feed/android/playersdk/AudioFocusListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(audioFocusListener);
			}
		}

		[Register("removeLikeStatusChangeListener", "(Lfm/feed/android/playersdk/LikeStatusChangeListener;)V", "")]
		public unsafe void RemoveLikeStatusChangeListener(ILikeStatusChangeListener likeStatusChangeListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((likeStatusChangeListener == null) ? IntPtr.Zero : ((Java.Lang.Object)likeStatusChangeListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeLikeStatusChangeListener.(Lfm/feed/android/playersdk/LikeStatusChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(likeStatusChangeListener);
			}
		}

		[Register("removeMusicQueuedListener", "(Lfm/feed/android/playersdk/MusicQueuedListener;)V", "")]
		public unsafe void RemoveMusicQueuedListener(IMusicQueuedListener musicQueuedListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((musicQueuedListener == null) ? IntPtr.Zero : ((Java.Lang.Object)musicQueuedListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeMusicQueuedListener.(Lfm/feed/android/playersdk/MusicQueuedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(musicQueuedListener);
			}
		}

		[Register("removeOutOfMusicListener", "(Lfm/feed/android/playersdk/OutOfMusicListener;)V", "")]
		public unsafe void RemoveOutOfMusicListener(IOutOfMusicListener outOfMusicListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((outOfMusicListener == null) ? IntPtr.Zero : ((Java.Lang.Object)outOfMusicListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeOutOfMusicListener.(Lfm/feed/android/playersdk/OutOfMusicListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(outOfMusicListener);
			}
		}

		[Register("removePlayListener", "(Lfm/feed/android/playersdk/PlayListener;)V", "")]
		public unsafe void RemovePlayListener(IPlayListener playListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((playListener == null) ? IntPtr.Zero : ((Java.Lang.Object)playListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removePlayListener.(Lfm/feed/android/playersdk/PlayListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(playListener);
			}
		}

		[Register("removeSkipListener", "(Lfm/feed/android/playersdk/SkipListener;)V", "")]
		public unsafe void RemoveSkipListener(ISkipListener eventListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((eventListener == null) ? IntPtr.Zero : ((Java.Lang.Object)eventListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeSkipListener.(Lfm/feed/android/playersdk/SkipListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(eventListener);
			}
		}

		[Register("removeStateListener", "(Lfm/feed/android/playersdk/StateListener;)V", "")]
		public unsafe void RemoveStateListener(IStateListener stateListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((stateListener == null) ? IntPtr.Zero : ((Java.Lang.Object)stateListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeStateListener.(Lfm/feed/android/playersdk/StateListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(stateListener);
			}
		}

		[Register("removeStationChangedListener", "(Lfm/feed/android/playersdk/StationChangedListener;)V", "")]
		public unsafe void RemoveStationChangedListener(IStationChangedListener stationChangedListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((stationChangedListener == null) ? IntPtr.Zero : ((Java.Lang.Object)stationChangedListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeStationChangedListener.(Lfm/feed/android/playersdk/StationChangedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(stationChangedListener);
			}
		}

		[Register("removeUnhandledErrorListener", "(Lfm/feed/android/playersdk/UnhandledErrorListener;)V", "")]
		public unsafe void RemoveUnhandledErrorListener(IUnhandledErrorListener eventListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((eventListener == null) ? IntPtr.Zero : ((Java.Lang.Object)eventListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeUnhandledErrorListener.(Lfm/feed/android/playersdk/UnhandledErrorListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(eventListener);
			}
		}

		[Register("seek", "(F)V", "")]
		public unsafe void Seek(float position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("seek.(F)V", this, ptr);
		}

		[Register("seekCurrentStationBy", "(F)V", "")]
		public unsafe void SeekCurrentStationBy(float seconds)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(seconds);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("seekCurrentStationBy.(F)V", this, ptr);
		}

		[Register("setActiveStation", "(Lfm/feed/android/playersdk/models/Station;Z)V", "")]
		public unsafe void SetActiveStation(Station station, bool withCrossfade)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(station?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(withCrossfade);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setActiveStation.(Lfm/feed/android/playersdk/models/Station;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(station);
			}
		}

		[Register("setActiveStation", "(Lfm/feed/android/playersdk/models/Station;ZF)V", "")]
		public unsafe void SetActiveStation(Station station, bool withCrossfade, float advanceBy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(station?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(withCrossfade);
				ptr[2] = new JniArgumentValue(advanceBy);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setActiveStation.(Lfm/feed/android/playersdk/models/Station;ZF)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(station);
			}
		}

		[Register("setBaseUrl", "(Ljava/lang/String;)V", "")]
		public unsafe static void SetBaseUrl(string url)
		{
			IntPtr intPtr = JNIEnv.NewString(url);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("setBaseUrl.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setClientId", "(Ljava/lang/String;)Z", "")]
		public unsafe bool SetClientId(string exportedClientId)
		{
			IntPtr intPtr = JNIEnv.NewString(exportedClientId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("setClientId.(Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setPlayer", "(Lfm/feed/android/playersdk/MixingAudioPlayer;)V", "")]
		public unsafe void SetPlayer(IMixingAudioPlayer player)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((player == null) ? IntPtr.Zero : ((Java.Lang.Object)player).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPlayer.(Lfm/feed/android/playersdk/MixingAudioPlayer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(player);
			}
		}

		[Register("setVolume", "(F)V", "")]
		public unsafe void SetVolume(float volume)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(volume);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setVolume.(F)V", this, ptr);
		}

		[Register("skip", "()V", "")]
		public unsafe void Skip()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("skip.()V", this, null);
		}

		[Register("skip", "(Lfm/feed/android/playersdk/SkipListener;)V", "")]
		public unsafe void Skip(ISkipListener skipListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((skipListener == null) ? IntPtr.Zero : ((Java.Lang.Object)skipListener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("skip.(Lfm/feed/android/playersdk/SkipListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(skipListener);
			}
		}

		[Register("stop", "()V", "")]
		public unsafe void Stop()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("stop.()V", this, null);
		}

		[Register("submitLogsForRemoteDebuggingWithLabel", "(Ljava/lang/String;)V", "")]
		public unsafe void SubmitLogsForRemoteDebuggingWithLabel(string msg)
		{
			IntPtr intPtr = JNIEnv.NewString(msg);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("submitLogsForRemoteDebuggingWithLabel.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("switchToDefaultPlayer", "()V", "")]
		public unsafe void SwitchToDefaultPlayer()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("switchToDefaultPlayer.()V", this, null);
		}

		[Register("unlike", "()V", "")]
		public unsafe void Unlike()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("unlike.()V", this, null);
		}

		[Register("unlike", "(Lfm/feed/android/playersdk/models/AudioFile;)V", "")]
		public unsafe void Unlike(AudioFile audioFile)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(audioFile?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("unlike.(Lfm/feed/android/playersdk/models/AudioFile;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(audioFile);
			}
		}

		[Register("updateSession", "(Lfm/feed/android/playersdk/SessionUpdateListener;)V", "")]
		public unsafe void UpdateSession(ISessionUpdateListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("updateSession.(Lfm/feed/android/playersdk/SessionUpdateListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private IAudioFocusListenerImplementor __CreateIAudioFocusListenerImplementor()
		{
			return new IAudioFocusListenerImplementor(this);
		}

		private IAvailabilityListenerImplementor __CreateIAvailabilityListenerImplementor()
		{
			return new IAvailabilityListenerImplementor(this);
		}

		private ILikeStatusChangeListenerImplementor __CreateILikeStatusChangeListenerImplementor()
		{
			return new ILikeStatusChangeListenerImplementor(this);
		}

		private IMusicQueuedListenerImplementor __CreateIMusicQueuedListenerImplementor()
		{
			return new IMusicQueuedListenerImplementor(this);
		}

		private IOutOfMusicListenerImplementor __CreateIOutOfMusicListenerImplementor()
		{
			return new IOutOfMusicListenerImplementor(this);
		}

		private IPlayListenerImplementor __CreateIPlayListenerImplementor()
		{
			return new IPlayListenerImplementor(this);
		}

		private ISkipListenerImplementor __CreateISkipListenerImplementor()
		{
			return new ISkipListenerImplementor(this);
		}

		private IStateListenerImplementor __CreateIStateListenerImplementor()
		{
			return new IStateListenerImplementor(this);
		}

		private IStationChangedListenerImplementor __CreateIStationChangedListenerImplementor()
		{
			return new IStationChangedListenerImplementor(this);
		}

		private IUnhandledErrorListenerImplementor __CreateIUnhandledErrorListenerImplementor()
		{
			return new IUnhandledErrorListenerImplementor(this);
		}

		private ISessionUpdateListenerImplementor __CreateISessionUpdateListenerImplementor()
		{
			return new ISessionUpdateListenerImplementor(this);
		}
	}
	[Register("fm/feed/android/playersdk/FeedException", DoNotGenerateAcw = true)]
	public sealed class FeedException : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/FeedException", typeof(FeedException));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal FeedException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Exception;)V", "")]
		public unsafe FeedException(Java.Lang.Exception wrappedException)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(wrappedException?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Exception;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Exception;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(wrappedException);
			}
		}

		[Register("toString", "()Ljava/lang/String;", "")]
		public unsafe override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("fm/feed/android/playersdk/FeedPlayerService", DoNotGenerateAcw = true)]
	public sealed class FeedPlayerService : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/FeedPlayerService", typeof(FeedPlayerService));

		[Register("INSTANCE")]
		public static FeedPlayerService Instance => Java.Lang.Object.GetObject<FeedPlayerService>(_members.StaticFields.GetObjectValue("INSTANCE.Lfm/feed/android/playersdk/FeedPlayerService;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal FeedPlayerService(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getInstance", "()Lfm/feed/android/playersdk/FeedAudioPlayer;", "")]
		public unsafe static FeedAudioPlayer GetInstance()
		{
			return Java.Lang.Object.GetObject<FeedAudioPlayer>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lfm/feed/android/playersdk/FeedAudioPlayer;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getInstance", "(Lfm/feed/android/playersdk/AvailabilityListener;)V", "")]
		public unsafe static void GetInstance(IAvailabilityListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.StaticMethods.InvokeVoidMethod("getInstance.(Lfm/feed/android/playersdk/AvailabilityListener;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("initialize", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void Initialize(Context context, string token, string secret)
		{
			IntPtr intPtr = JNIEnv.NewString(token);
			IntPtr intPtr2 = JNIEnv.NewString(secret);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("initialize.(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
			}
		}

		[Register("initialize", "(Lfm/feed/android/playersdk/FeedAudioPlayer$Builder;)V", "")]
		public unsafe static void Initialize(FeedAudioPlayer.Builder builder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("initialize.(Lfm/feed/android/playersdk/FeedAudioPlayer$Builder;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(builder);
			}
		}
	}
	[Register("fm/feed/android/playersdk/FeedSimulcastStreamer", DoNotGenerateAcw = true)]
	public sealed class FeedSimulcastStreamer : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/FeedSimulcastStreamer", typeof(FeedSimulcastStreamer));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Context Context
		{
			[Register("getContext", "()Landroid/content/Context;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Play CurrentItem
		{
			[Register("getCurrentItem", "()Lfm/feed/android/playersdk/models/Play;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Play>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCurrentItem.()Lfm/feed/android/playersdk/models/Play;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setCurrentItem", "(Lfm/feed/android/playersdk/models/Play;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCurrentItem.(Lfm/feed/android/playersdk/models/Play;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe float CurrentTime
		{
			[Register("getCurrentTime", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getCurrentTime.()F", this, null);
			}
		}

		public unsafe SimulcastPlaybackState State
		{
			[Register("getState", "()Lfm/feed/android/playersdk/SimulcastPlaybackState;", "")]
			get
			{
				return Java.Lang.Object.GetObject<SimulcastPlaybackState>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getState.()Lfm/feed/android/playersdk/SimulcastPlaybackState;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setState", "(Lfm/feed/android/playersdk/SimulcastPlaybackState;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setState.(Lfm/feed/android/playersdk/SimulcastPlaybackState;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe float Volume
		{
			[Register("getVolume", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getVolume.()F", this, null);
			}
			[Register("setVolume", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setVolume.(F)V", this, ptr);
			}
		}

		internal FeedSimulcastStreamer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Lfm/feed/android/playersdk/SimulcastEventListener;)V", "")]
		public unsafe FeedSimulcastStreamer(Context context, string token, ISimulcastEventListener eventListener)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(token);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((eventListener == null) ? IntPtr.Zero : ((Java.Lang.Object)eventListener).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Lfm/feed/android/playersdk/SimulcastEventListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Lfm/feed/android/playersdk/SimulcastEventListener;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(eventListener);
			}
		}

		[Register("connect", "()V", "")]
		public unsafe void Connect()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("connect.()V", this, null);
		}

		[Register("disconnect", "()V", "")]
		public unsafe void Disconnect()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("disconnect.()V", this, null);
		}
	}
	[Register("fm/feed/android/playersdk/FMLog", DoNotGenerateAcw = true)]
	public sealed class FMLog : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/FMLog", typeof(FMLog));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe static LogLevel LogLevel
		{
			[Register("getLogLevel", "()Lfm/feed/android/playersdk/LogLevel;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LogLevel>(_members.StaticMethods.InvokeObjectMethod("getLogLevel.()Lfm/feed/android/playersdk/LogLevel;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLogLevel", "(Lfm/feed/android/playersdk/LogLevel;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.StaticMethods.InvokeVoidMethod("setLogLevel.(Lfm/feed/android/playersdk/LogLevel;)V", ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string Tag
		{
			[Register("getTag", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTag.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal FMLog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe FMLog(string tag)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("d", "(Ljava/lang/Object;Ljava/lang/Throwable;)V", "")]
		public unsafe void D(Java.Lang.Object obj, Throwable ex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(ex?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("d.(Ljava/lang/Object;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(ex);
			}
		}

		[Register("e", "(Ljava/lang/Object;Ljava/lang/Throwable;)V", "")]
		public unsafe void E(Java.Lang.Object obj, Throwable ex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(ex?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("e.(Ljava/lang/Object;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(ex);
			}
		}

		[Register("i", "(Ljava/lang/Object;Ljava/lang/Throwable;)V", "")]
		public unsafe void I(Java.Lang.Object obj, Throwable ex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(ex?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("i.(Ljava/lang/Object;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(ex);
			}
		}

		[Register("v", "(Ljava/lang/Object;Ljava/lang/Throwable;)V", "")]
		public unsafe void V(Java.Lang.Object obj, Throwable ex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(ex?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("v.(Ljava/lang/Object;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(ex);
			}
		}

		[Register("w", "(Ljava/lang/Object;Ljava/lang/Throwable;)V", "")]
		public unsafe void W(Java.Lang.Object obj, Throwable ex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(ex?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("w.(Ljava/lang/Object;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(ex);
			}
		}

		[Register("wtf", "(Ljava/lang/Object;Ljava/lang/Throwable;)V", "")]
		public unsafe void Wtf(Java.Lang.Object obj, Throwable ex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(ex?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("wtf.(Ljava/lang/Object;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(ex);
			}
		}
	}
	[Register("fm/feed/android/playersdk/AudioFocusListener", "", "FM.Feed.Android.Playersdk.IAudioFocusListenerInvoker")]
	public interface IAudioFocusListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("musicPausedDueToAudioFocusLost", "(Z)V", "GetMusicPausedDueToAudioFocusLost_ZHandler:FM.Feed.Android.Playersdk.IAudioFocusListenerInvoker, iFit.Feed.FM.Android")]
		void MusicPausedDueToAudioFocusLost(bool isFocusAbandoned);

		[Register("musicWillBeResumedDueToAudioFocusGain", "()V", "GetMusicWillBeResumedDueToAudioFocusGainHandler:FM.Feed.Android.Playersdk.IAudioFocusListenerInvoker, iFit.Feed.FM.Android")]
		void MusicWillBeResumedDueToAudioFocusGain();

		[Register("volumeChangedDueToTransientLossOrGain", "(F)V", "GetVolumeChangedDueToTransientLossOrGain_FHandler:FM.Feed.Android.Playersdk.IAudioFocusListenerInvoker, iFit.Feed.FM.Android")]
		void VolumeChangedDueToTransientLossOrGain(float volume);
	}
	[Register("fm/feed/android/playersdk/AudioFocusListener", DoNotGenerateAcw = true)]
	internal class IAudioFocusListenerInvoker : Java.Lang.Object, IAudioFocusListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/AudioFocusListener", typeof(IAudioFocusListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_musicPausedDueToAudioFocusLost_Z;

		private IntPtr id_musicPausedDueToAudioFocusLost_Z;

		private static Delegate cb_musicWillBeResumedDueToAudioFocusGain;

		private IntPtr id_musicWillBeResumedDueToAudioFocusGain;

		private static Delegate cb_volumeChangedDueToTransientLossOrGain_F;

		private IntPtr id_volumeChangedDueToTransientLossOrGain_F;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IAudioFocusListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IAudioFocusListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.AudioFocusListener'.");
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

		public IAudioFocusListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetMusicPausedDueToAudioFocusLost_ZHandler()
		{
			if ((object)cb_musicPausedDueToAudioFocusLost_Z == null)
			{
				cb_musicPausedDueToAudioFocusLost_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_MusicPausedDueToAudioFocusLost_Z));
			}
			return cb_musicPausedDueToAudioFocusLost_Z;
		}

		private static void n_MusicPausedDueToAudioFocusLost_Z(IntPtr jnienv, IntPtr native__this, bool isFocusAbandoned)
		{
			IAudioFocusListener audioFocusListener = Java.Lang.Object.GetObject<IAudioFocusListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			audioFocusListener.MusicPausedDueToAudioFocusLost(isFocusAbandoned);
		}

		public unsafe void MusicPausedDueToAudioFocusLost(bool isFocusAbandoned)
		{
			if (id_musicPausedDueToAudioFocusLost_Z == IntPtr.Zero)
			{
				id_musicPausedDueToAudioFocusLost_Z = JNIEnv.GetMethodID(class_ref, "musicPausedDueToAudioFocusLost", "(Z)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(isFocusAbandoned);
			JNIEnv.CallVoidMethod(base.Handle, id_musicPausedDueToAudioFocusLost_Z, ptr);
		}

		private static Delegate GetMusicWillBeResumedDueToAudioFocusGainHandler()
		{
			if ((object)cb_musicWillBeResumedDueToAudioFocusGain == null)
			{
				cb_musicWillBeResumedDueToAudioFocusGain = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_MusicWillBeResumedDueToAudioFocusGain));
			}
			return cb_musicWillBeResumedDueToAudioFocusGain;
		}

		private static void n_MusicWillBeResumedDueToAudioFocusGain(IntPtr jnienv, IntPtr native__this)
		{
			IAudioFocusListener audioFocusListener = Java.Lang.Object.GetObject<IAudioFocusListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			audioFocusListener.MusicWillBeResumedDueToAudioFocusGain();
		}

		public void MusicWillBeResumedDueToAudioFocusGain()
		{
			if (id_musicWillBeResumedDueToAudioFocusGain == IntPtr.Zero)
			{
				id_musicWillBeResumedDueToAudioFocusGain = JNIEnv.GetMethodID(class_ref, "musicWillBeResumedDueToAudioFocusGain", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_musicWillBeResumedDueToAudioFocusGain);
		}

		private static Delegate GetVolumeChangedDueToTransientLossOrGain_FHandler()
		{
			if ((object)cb_volumeChangedDueToTransientLossOrGain_F == null)
			{
				cb_volumeChangedDueToTransientLossOrGain_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_VolumeChangedDueToTransientLossOrGain_F));
			}
			return cb_volumeChangedDueToTransientLossOrGain_F;
		}

		private static void n_VolumeChangedDueToTransientLossOrGain_F(IntPtr jnienv, IntPtr native__this, float volume)
		{
			IAudioFocusListener audioFocusListener = Java.Lang.Object.GetObject<IAudioFocusListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			audioFocusListener.VolumeChangedDueToTransientLossOrGain(volume);
		}

		public unsafe void VolumeChangedDueToTransientLossOrGain(float volume)
		{
			if (id_volumeChangedDueToTransientLossOrGain_F == IntPtr.Zero)
			{
				id_volumeChangedDueToTransientLossOrGain_F = JNIEnv.GetMethodID(class_ref, "volumeChangedDueToTransientLossOrGain", "(F)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(volume);
			JNIEnv.CallVoidMethod(base.Handle, id_volumeChangedDueToTransientLossOrGain_F, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/AudioFocusListenerImplementor")]
	internal sealed class IAudioFocusListenerImplementor : Java.Lang.Object, IAudioFocusListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IAudioFocusListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/AudioFocusListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void MusicPausedDueToAudioFocusLost(bool isFocusAbandoned)
		{
		}

		public void MusicWillBeResumedDueToAudioFocusGain()
		{
		}

		public void VolumeChangedDueToTransientLossOrGain(float volume)
		{
		}

		internal static bool __IsEmpty(IAudioFocusListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/AvailabilityListener", "", "FM.Feed.Android.Playersdk.IAvailabilityListenerInvoker")]
	public interface IAvailabilityListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onPlayerAvailable", "(Lfm/feed/android/playersdk/FeedAudioPlayer;)V", "GetOnPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_Handler:FM.Feed.Android.Playersdk.IAvailabilityListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayerAvailable(FeedAudioPlayer player);

		[Register("onPlayerUnavailable", "(Ljava/lang/Exception;)V", "GetOnPlayerUnavailable_Ljava_lang_Exception_Handler:FM.Feed.Android.Playersdk.IAvailabilityListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayerUnavailable(Java.Lang.Exception e);
	}
	[Register("fm/feed/android/playersdk/AvailabilityListener", DoNotGenerateAcw = true)]
	internal class IAvailabilityListenerInvoker : Java.Lang.Object, IAvailabilityListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/AvailabilityListener", typeof(IAvailabilityListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_;

		private IntPtr id_onPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_;

		private static Delegate cb_onPlayerUnavailable_Ljava_lang_Exception_;

		private IntPtr id_onPlayerUnavailable_Ljava_lang_Exception_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IAvailabilityListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IAvailabilityListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.AvailabilityListener'.");
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

		public IAvailabilityListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_Handler()
		{
			if ((object)cb_onPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_ == null)
			{
				cb_onPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_));
			}
			return cb_onPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_;
		}

		private static void n_OnPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_(IntPtr jnienv, IntPtr native__this, IntPtr native_player)
		{
			IAvailabilityListener availabilityListener = Java.Lang.Object.GetObject<IAvailabilityListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FeedAudioPlayer player = Java.Lang.Object.GetObject<FeedAudioPlayer>(native_player, JniHandleOwnership.DoNotTransfer);
			availabilityListener.OnPlayerAvailable(player);
		}

		public unsafe void OnPlayerAvailable(FeedAudioPlayer player)
		{
			if (id_onPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_ == IntPtr.Zero)
			{
				id_onPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_ = JNIEnv.GetMethodID(class_ref, "onPlayerAvailable", "(Lfm/feed/android/playersdk/FeedAudioPlayer;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(player?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayerAvailable_Lfm_feed_android_playersdk_FeedAudioPlayer_, ptr);
		}

		private static Delegate GetOnPlayerUnavailable_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_onPlayerUnavailable_Ljava_lang_Exception_ == null)
			{
				cb_onPlayerUnavailable_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlayerUnavailable_Ljava_lang_Exception_));
			}
			return cb_onPlayerUnavailable_Ljava_lang_Exception_;
		}

		private static void n_OnPlayerUnavailable_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_e)
		{
			IAvailabilityListener availabilityListener = Java.Lang.Object.GetObject<IAvailabilityListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception e = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_e, JniHandleOwnership.DoNotTransfer);
			availabilityListener.OnPlayerUnavailable(e);
		}

		public unsafe void OnPlayerUnavailable(Java.Lang.Exception e)
		{
			if (id_onPlayerUnavailable_Ljava_lang_Exception_ == IntPtr.Zero)
			{
				id_onPlayerUnavailable_Ljava_lang_Exception_ = JNIEnv.GetMethodID(class_ref, "onPlayerUnavailable", "(Ljava/lang/Exception;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(e?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayerUnavailable_Ljava_lang_Exception_, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/AvailabilityListenerImplementor")]
	internal sealed class IAvailabilityListenerImplementor : Java.Lang.Object, IAvailabilityListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IAvailabilityListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/AvailabilityListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnPlayerAvailable(FeedAudioPlayer player)
		{
		}

		public void OnPlayerUnavailable(Java.Lang.Exception e)
		{
		}

		internal static bool __IsEmpty(IAvailabilityListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/CacheMediaListener", "", "FM.Feed.Android.Playersdk.ICacheMediaListenerInvoker")]
	public interface ICacheMediaListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCacheTransferEnded", "()V", "GetOnCacheTransferEndedHandler:FM.Feed.Android.Playersdk.ICacheMediaListenerInvoker, iFit.Feed.FM.Android")]
		void OnCacheTransferEnded();
	}
	[Register("fm/feed/android/playersdk/CacheMediaListener", DoNotGenerateAcw = true)]
	internal class ICacheMediaListenerInvoker : Java.Lang.Object, ICacheMediaListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/CacheMediaListener", typeof(ICacheMediaListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onCacheTransferEnded;

		private IntPtr id_onCacheTransferEnded;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ICacheMediaListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICacheMediaListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.CacheMediaListener'.");
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

		public ICacheMediaListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnCacheTransferEndedHandler()
		{
			if ((object)cb_onCacheTransferEnded == null)
			{
				cb_onCacheTransferEnded = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCacheTransferEnded));
			}
			return cb_onCacheTransferEnded;
		}

		private static void n_OnCacheTransferEnded(IntPtr jnienv, IntPtr native__this)
		{
			ICacheMediaListener cacheMediaListener = Java.Lang.Object.GetObject<ICacheMediaListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			cacheMediaListener.OnCacheTransferEnded();
		}

		public void OnCacheTransferEnded()
		{
			if (id_onCacheTransferEnded == IntPtr.Zero)
			{
				id_onCacheTransferEnded = JNIEnv.GetMethodID(class_ref, "onCacheTransferEnded", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onCacheTransferEnded);
		}
	}
	[Register("mono/fm/feed/android/playersdk/CacheMediaListenerImplementor")]
	internal sealed class ICacheMediaListenerImplementor : Java.Lang.Object, ICacheMediaListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public ICacheMediaListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/CacheMediaListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnCacheTransferEnded()
		{
		}

		internal static bool __IsEmpty(ICacheMediaListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/CachePreparedListener", "", "FM.Feed.Android.Playersdk.ICachePreparedListenerInvoker")]
	public interface ICachePreparedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCachePrepared", "(Z)V", "GetOnCachePrepared_ZHandler:FM.Feed.Android.Playersdk.ICachePreparedListenerInvoker, iFit.Feed.FM.Android")]
		void OnCachePrepared(bool isSuccess);
	}
	[Register("fm/feed/android/playersdk/CachePreparedListener", DoNotGenerateAcw = true)]
	internal class ICachePreparedListenerInvoker : Java.Lang.Object, ICachePreparedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/CachePreparedListener", typeof(ICachePreparedListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onCachePrepared_Z;

		private IntPtr id_onCachePrepared_Z;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ICachePreparedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICachePreparedListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.CachePreparedListener'.");
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

		public ICachePreparedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnCachePrepared_ZHandler()
		{
			if ((object)cb_onCachePrepared_Z == null)
			{
				cb_onCachePrepared_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnCachePrepared_Z));
			}
			return cb_onCachePrepared_Z;
		}

		private static void n_OnCachePrepared_Z(IntPtr jnienv, IntPtr native__this, bool isSuccess)
		{
			ICachePreparedListener cachePreparedListener = Java.Lang.Object.GetObject<ICachePreparedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			cachePreparedListener.OnCachePrepared(isSuccess);
		}

		public unsafe void OnCachePrepared(bool isSuccess)
		{
			if (id_onCachePrepared_Z == IntPtr.Zero)
			{
				id_onCachePrepared_Z = JNIEnv.GetMethodID(class_ref, "onCachePrepared", "(Z)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(isSuccess);
			JNIEnv.CallVoidMethod(base.Handle, id_onCachePrepared_Z, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/CachePreparedListenerImplementor")]
	internal sealed class ICachePreparedListenerImplementor : Java.Lang.Object, ICachePreparedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public ICachePreparedListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/CachePreparedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnCachePrepared(bool isSuccess)
		{
		}

		internal static bool __IsEmpty(ICachePreparedListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/ClientIdListener", "", "FM.Feed.Android.Playersdk.IClientIdListenerInvoker")]
	public interface IClientIdListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onClientId", "(Ljava/lang/String;)V", "GetOnClientId_Ljava_lang_String_Handler:FM.Feed.Android.Playersdk.IClientIdListenerInvoker, iFit.Feed.FM.Android")]
		void OnClientId(string clientId);

		[Register("onError", "()V", "GetOnErrorHandler:FM.Feed.Android.Playersdk.IClientIdListenerInvoker, iFit.Feed.FM.Android")]
		void OnError();
	}
	[Register("fm/feed/android/playersdk/ClientIdListener", DoNotGenerateAcw = true)]
	internal class IClientIdListenerInvoker : Java.Lang.Object, IClientIdListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/ClientIdListener", typeof(IClientIdListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onClientId_Ljava_lang_String_;

		private IntPtr id_onClientId_Ljava_lang_String_;

		private static Delegate cb_onError;

		private IntPtr id_onError;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IClientIdListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IClientIdListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.ClientIdListener'.");
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

		public IClientIdListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnClientId_Ljava_lang_String_Handler()
		{
			if ((object)cb_onClientId_Ljava_lang_String_ == null)
			{
				cb_onClientId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnClientId_Ljava_lang_String_));
			}
			return cb_onClientId_Ljava_lang_String_;
		}

		private static void n_OnClientId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_clientId)
		{
			IClientIdListener clientIdListener = Java.Lang.Object.GetObject<IClientIdListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string clientId = JNIEnv.GetString(native_clientId, JniHandleOwnership.DoNotTransfer);
			clientIdListener.OnClientId(clientId);
		}

		public unsafe void OnClientId(string clientId)
		{
			if (id_onClientId_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onClientId_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onClientId", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(clientId);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onClientId_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnErrorHandler()
		{
			if ((object)cb_onError == null)
			{
				cb_onError = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnError));
			}
			return cb_onError;
		}

		private static void n_OnError(IntPtr jnienv, IntPtr native__this)
		{
			IClientIdListener clientIdListener = Java.Lang.Object.GetObject<IClientIdListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			clientIdListener.OnError();
		}

		public void OnError()
		{
			if (id_onError == IntPtr.Zero)
			{
				id_onError = JNIEnv.GetMethodID(class_ref, "onError", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onError);
		}
	}
	[Register("mono/fm/feed/android/playersdk/ClientIdListenerImplementor")]
	internal sealed class IClientIdListenerImplementor : Java.Lang.Object, IClientIdListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IClientIdListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/ClientIdListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnClientId(string clientId)
		{
		}

		public void OnError()
		{
		}

		internal static bool __IsEmpty(IClientIdListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/LikeStatusChangeListener", "", "FM.Feed.Android.Playersdk.ILikeStatusChangeListenerInvoker")]
	public interface ILikeStatusChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onLikeStatusChanged", "(Lfm/feed/android/playersdk/models/AudioFile;)V", "GetOnLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_Handler:FM.Feed.Android.Playersdk.ILikeStatusChangeListenerInvoker, iFit.Feed.FM.Android")]
		void OnLikeStatusChanged(AudioFile audioFile);
	}
	[Register("fm/feed/android/playersdk/LikeStatusChangeListener", DoNotGenerateAcw = true)]
	internal class ILikeStatusChangeListenerInvoker : Java.Lang.Object, ILikeStatusChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/LikeStatusChangeListener", typeof(ILikeStatusChangeListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_;

		private IntPtr id_onLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ILikeStatusChangeListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILikeStatusChangeListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.LikeStatusChangeListener'.");
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

		public ILikeStatusChangeListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_Handler()
		{
			if ((object)cb_onLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_ == null)
			{
				cb_onLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_));
			}
			return cb_onLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_;
		}

		private static void n_OnLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_(IntPtr jnienv, IntPtr native__this, IntPtr native_audioFile)
		{
			ILikeStatusChangeListener likeStatusChangeListener = Java.Lang.Object.GetObject<ILikeStatusChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AudioFile audioFile = Java.Lang.Object.GetObject<AudioFile>(native_audioFile, JniHandleOwnership.DoNotTransfer);
			likeStatusChangeListener.OnLikeStatusChanged(audioFile);
		}

		public unsafe void OnLikeStatusChanged(AudioFile audioFile)
		{
			if (id_onLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_ == IntPtr.Zero)
			{
				id_onLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_ = JNIEnv.GetMethodID(class_ref, "onLikeStatusChanged", "(Lfm/feed/android/playersdk/models/AudioFile;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(audioFile?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onLikeStatusChanged_Lfm_feed_android_playersdk_models_AudioFile_, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/LikeStatusChangeListenerImplementor")]
	internal sealed class ILikeStatusChangeListenerImplementor : Java.Lang.Object, ILikeStatusChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public ILikeStatusChangeListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/LikeStatusChangeListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnLikeStatusChanged(AudioFile audioFile)
		{
		}

		internal static bool __IsEmpty(ILikeStatusChangeListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/MixingAudioPlayer$EventListener", "", "FM.Feed.Android.Playersdk.IMixingAudioPlayerEventListenerInvoker")]
	public interface IMixingAudioPlayerEventListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onPlayFailedToPrepare", "(Lfm/feed/android/playersdk/models/Play;Ljava/lang/Exception;)V", "GetOnPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_Handler:FM.Feed.Android.Playersdk.IMixingAudioPlayerEventListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayFailedToPrepare(Play play, Java.Lang.Exception error);

		[Register("onPlayItemBeganPlayback", "(ILfm/feed/android/playersdk/models/Play;J)V", "GetOnPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_JHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerEventListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayItemBeganPlayback(int waitingTime, Play play, long bufferingTime);

		[Register("onPlayItemFinishedPlayback", "(Lfm/feed/android/playersdk/models/Play;ILjava/lang/Exception;)V", "GetOnPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_Handler:FM.Feed.Android.Playersdk.IMixingAudioPlayerEventListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayItemFinishedPlayback(Play play, int reason, Java.Lang.Exception error);

		[Register("onPlayItemReadyForPlayback", "(Lfm/feed/android/playersdk/models/Play;)V", "GetOnPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_Handler:FM.Feed.Android.Playersdk.IMixingAudioPlayerEventListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayItemReadyForPlayback(Play play);

		[Register("onPlayerStateChanged", "(Lfm/feed/android/playersdk/State;)V", "GetOnPlayerStateChanged_Lfm_feed_android_playersdk_State_Handler:FM.Feed.Android.Playersdk.IMixingAudioPlayerEventListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayerStateChanged(State playerState);

		[Register("onProgressUpdate", "(Lfm/feed/android/playersdk/models/Play;FF)V", "GetOnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FFHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerEventListenerInvoker, iFit.Feed.FM.Android")]
		void OnProgressUpdate(Play play, float elapsedTime, float duration);
	}
	[Register("fm/feed/android/playersdk/MixingAudioPlayer$EventListener", DoNotGenerateAcw = true)]
	internal class IMixingAudioPlayerEventListenerInvoker : Java.Lang.Object, IMixingAudioPlayerEventListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/MixingAudioPlayer$EventListener", typeof(IMixingAudioPlayerEventListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_;

		private IntPtr id_onPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_;

		private static Delegate cb_onPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_J;

		private IntPtr id_onPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_J;

		private static Delegate cb_onPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_;

		private IntPtr id_onPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_;

		private static Delegate cb_onPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_;

		private IntPtr id_onPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_;

		private static Delegate cb_onPlayerStateChanged_Lfm_feed_android_playersdk_State_;

		private IntPtr id_onPlayerStateChanged_Lfm_feed_android_playersdk_State_;

		private static Delegate cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF;

		private IntPtr id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IMixingAudioPlayerEventListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMixingAudioPlayerEventListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.MixingAudioPlayer.EventListener'.");
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

		public IMixingAudioPlayerEventListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_onPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_ == null)
			{
				cb_onPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_));
			}
			return cb_onPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_;
		}

		private static void n_OnPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_play, IntPtr native_error)
		{
			IMixingAudioPlayerEventListener mixingAudioPlayerEventListener = Java.Lang.Object.GetObject<IMixingAudioPlayerEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play play = Java.Lang.Object.GetObject<Play>(native_play, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception error = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_error, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayerEventListener.OnPlayFailedToPrepare(play, error);
		}

		public unsafe void OnPlayFailedToPrepare(Play play, Java.Lang.Exception error)
		{
			if (id_onPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_ == IntPtr.Zero)
			{
				id_onPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_ = JNIEnv.GetMethodID(class_ref, "onPlayFailedToPrepare", "(Lfm/feed/android/playersdk/models/Play;Ljava/lang/Exception;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(play?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(error?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayFailedToPrepare_Lfm_feed_android_playersdk_models_Play_Ljava_lang_Exception_, ptr);
		}

		private static Delegate GetOnPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_JHandler()
		{
			if ((object)cb_onPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_J == null)
			{
				cb_onPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_J = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPILJ_V(n_OnPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_J));
			}
			return cb_onPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_J;
		}

		private static void n_OnPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_J(IntPtr jnienv, IntPtr native__this, int waitingTime, IntPtr native_play, long bufferingTime)
		{
			IMixingAudioPlayerEventListener mixingAudioPlayerEventListener = Java.Lang.Object.GetObject<IMixingAudioPlayerEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play play = Java.Lang.Object.GetObject<Play>(native_play, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayerEventListener.OnPlayItemBeganPlayback(waitingTime, play, bufferingTime);
		}

		public unsafe void OnPlayItemBeganPlayback(int waitingTime, Play play, long bufferingTime)
		{
			if (id_onPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_J == IntPtr.Zero)
			{
				id_onPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_J = JNIEnv.GetMethodID(class_ref, "onPlayItemBeganPlayback", "(ILfm/feed/android/playersdk/models/Play;J)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(waitingTime);
			ptr[1] = new JValue(play?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(bufferingTime);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayItemBeganPlayback_ILfm_feed_android_playersdk_models_Play_J, ptr);
		}

		private static Delegate GetOnPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_Handler()
		{
			if ((object)cb_onPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_ == null)
			{
				cb_onPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_OnPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_));
			}
			return cb_onPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_;
		}

		private static void n_OnPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_play, int reason, IntPtr native_error)
		{
			IMixingAudioPlayerEventListener mixingAudioPlayerEventListener = Java.Lang.Object.GetObject<IMixingAudioPlayerEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play play = Java.Lang.Object.GetObject<Play>(native_play, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception error = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_error, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayerEventListener.OnPlayItemFinishedPlayback(play, reason, error);
		}

		public unsafe void OnPlayItemFinishedPlayback(Play play, int reason, Java.Lang.Exception error)
		{
			if (id_onPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_ == IntPtr.Zero)
			{
				id_onPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_ = JNIEnv.GetMethodID(class_ref, "onPlayItemFinishedPlayback", "(Lfm/feed/android/playersdk/models/Play;ILjava/lang/Exception;)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(play?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(reason);
			ptr[2] = new JValue(error?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayItemFinishedPlayback_Lfm_feed_android_playersdk_models_Play_ILjava_lang_Exception_, ptr);
		}

		private static Delegate GetOnPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_Handler()
		{
			if ((object)cb_onPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_ == null)
			{
				cb_onPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_));
			}
			return cb_onPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_;
		}

		private static void n_OnPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_(IntPtr jnienv, IntPtr native__this, IntPtr native_play)
		{
			IMixingAudioPlayerEventListener mixingAudioPlayerEventListener = Java.Lang.Object.GetObject<IMixingAudioPlayerEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play play = Java.Lang.Object.GetObject<Play>(native_play, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayerEventListener.OnPlayItemReadyForPlayback(play);
		}

		public unsafe void OnPlayItemReadyForPlayback(Play play)
		{
			if (id_onPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_ == IntPtr.Zero)
			{
				id_onPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_ = JNIEnv.GetMethodID(class_ref, "onPlayItemReadyForPlayback", "(Lfm/feed/android/playersdk/models/Play;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(play?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayItemReadyForPlayback_Lfm_feed_android_playersdk_models_Play_, ptr);
		}

		private static Delegate GetOnPlayerStateChanged_Lfm_feed_android_playersdk_State_Handler()
		{
			if ((object)cb_onPlayerStateChanged_Lfm_feed_android_playersdk_State_ == null)
			{
				cb_onPlayerStateChanged_Lfm_feed_android_playersdk_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlayerStateChanged_Lfm_feed_android_playersdk_State_));
			}
			return cb_onPlayerStateChanged_Lfm_feed_android_playersdk_State_;
		}

		private static void n_OnPlayerStateChanged_Lfm_feed_android_playersdk_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_playerState)
		{
			IMixingAudioPlayerEventListener mixingAudioPlayerEventListener = Java.Lang.Object.GetObject<IMixingAudioPlayerEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State playerState = Java.Lang.Object.GetObject<State>(native_playerState, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayerEventListener.OnPlayerStateChanged(playerState);
		}

		public unsafe void OnPlayerStateChanged(State playerState)
		{
			if (id_onPlayerStateChanged_Lfm_feed_android_playersdk_State_ == IntPtr.Zero)
			{
				id_onPlayerStateChanged_Lfm_feed_android_playersdk_State_ = JNIEnv.GetMethodID(class_ref, "onPlayerStateChanged", "(Lfm/feed/android/playersdk/State;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(playerState?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayerStateChanged_Lfm_feed_android_playersdk_State_, ptr);
		}

		private static Delegate GetOnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FFHandler()
		{
			if ((object)cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF == null)
			{
				cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLFF_V(n_OnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF));
			}
			return cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF;
		}

		private static void n_OnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF(IntPtr jnienv, IntPtr native__this, IntPtr native_play, float elapsedTime, float duration)
		{
			IMixingAudioPlayerEventListener mixingAudioPlayerEventListener = Java.Lang.Object.GetObject<IMixingAudioPlayerEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play play = Java.Lang.Object.GetObject<Play>(native_play, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayerEventListener.OnProgressUpdate(play, elapsedTime, duration);
		}

		public unsafe void OnProgressUpdate(Play play, float elapsedTime, float duration)
		{
			if (id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF == IntPtr.Zero)
			{
				id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF = JNIEnv.GetMethodID(class_ref, "onProgressUpdate", "(Lfm/feed/android/playersdk/models/Play;FF)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(play?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(elapsedTime);
			ptr[2] = new JValue(duration);
			JNIEnv.CallVoidMethod(base.Handle, id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/MixingAudioPlayer_EventListenerImplementor")]
	internal sealed class IMixingAudioPlayerEventListenerImplementor : Java.Lang.Object, IMixingAudioPlayerEventListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IMixingAudioPlayerEventListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/MixingAudioPlayer_EventListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnPlayFailedToPrepare(Play play, Java.Lang.Exception error)
		{
		}

		public void OnPlayItemBeganPlayback(int waitingTime, Play play, long bufferingTime)
		{
		}

		public void OnPlayItemFinishedPlayback(Play play, int reason, Java.Lang.Exception error)
		{
		}

		public void OnPlayItemReadyForPlayback(Play play)
		{
		}

		public void OnPlayerStateChanged(State playerState)
		{
		}

		public void OnProgressUpdate(Play play, float elapsedTime, float duration)
		{
		}

		internal static bool __IsEmpty(IMixingAudioPlayerEventListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/MixingAudioPlayer", DoNotGenerateAcw = true)]
	public abstract class MixingAudioPlayer : Java.Lang.Object
	{
		[Register("PLAY_COMPLETION_ERROR")]
		public const int PlayCompletionError = 3;

		[Register("PLAY_COMPLETION_FLUSHED")]
		public const int PlayCompletionFlushed = 2;

		[Register("PLAY_COMPLETION_REACHED_END")]
		public const int PlayCompletionReachedEnd = 0;

		[Register("PLAY_COMPLETION_SKIPPED")]
		public const int PlayCompletionSkipped = 1;

		internal MixingAudioPlayer()
		{
		}
	}
	[Register("fm/feed/android/playersdk/MixingAudioPlayer", DoNotGenerateAcw = true)]
	[Obsolete("Use the 'MixingAudioPlayer' type. This type will be removed in a future release.", true)]
	public abstract class MixingAudioPlayerConsts : MixingAudioPlayer
	{
		private MixingAudioPlayerConsts()
		{
		}
	}
	[Register("fm/feed/android/playersdk/MixingAudioPlayer", "", "FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker")]
	public interface IMixingAudioPlayer : IJavaObject, IDisposable, IJavaPeerable
	{
		bool BTrimmingEnabled
		{
			[Register("getBTrimmingEnabled", "()Z", "GetGetBTrimmingEnabledHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			get;
			[Register("setBTrimmingEnabled", "(Z)V", "GetSetBTrimmingEnabled_ZHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			set;
		}

		Play CurrentPlay
		{
			[Register("getCurrentPlay", "()Lfm/feed/android/playersdk/models/Play;", "GetGetCurrentPlayHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			get;
		}

		float CurrentPlayDuration
		{
			[Register("getCurrentPlayDuration", "()F", "GetGetCurrentPlayDurationHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			get;
		}

		float CurrentPlayTime
		{
			[Register("getCurrentPlayTime", "()F", "GetGetCurrentPlayTimeHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			get;
		}

		float FadeDuration
		{
			[Register("getFadeDuration", "()F", "GetGetFadeDurationHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			get;
			[Register("setFadeDuration", "(F)V", "GetSetFadeDuration_FHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			set;
		}

		IMixingAudioPlayerEventListener MEventListener
		{
			[Register("getMEventListener", "()Lfm/feed/android/playersdk/MixingAudioPlayer$EventListener;", "GetGetMEventListenerHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			get;
			[Register("setMEventListener", "(Lfm/feed/android/playersdk/MixingAudioPlayer$EventListener;)V", "GetSetMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_Handler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			set;
		}

		State State
		{
			[Register("getState", "()Lfm/feed/android/playersdk/State;", "GetGetStateHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			get;
			[Register("setState", "(Lfm/feed/android/playersdk/State;)V", "GetSetState_Lfm_feed_android_playersdk_State_Handler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			set;
		}

		float Volume
		{
			[Register("getVolume", "()F", "GetGetVolumeHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			get;
			[Register("setVolume", "(F)V", "GetSetVolume_FHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
			set;
		}

		[Register("addAudioAsset", "(Lfm/feed/android/playersdk/models/Play;)V", "GetAddAudioAsset_Lfm_feed_android_playersdk_models_Play_Handler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void AddAudioAsset(Play play);

		[Register("cacheMedia", "(Ljava/lang/String;ILfm/feed/android/playersdk/CacheMediaListener;)V", "GetCacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_Handler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void CacheMedia(string url, int maxCache, ICacheMediaListener listener);

		[Register("destroy", "()V", "GetDestroyHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void Destroy();

		[Register("flush", "()V", "GetFlushHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void Flush();

		[Register("flushAndIncludeCurrent", "(Z)V", "GetFlushAndIncludeCurrent_ZHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void FlushAndIncludeCurrent(bool bTrue);

		[Register("maxSeekableLengthInSeconds", "()F", "GetMaxSeekableLengthInSecondsHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		float MaxSeekableLengthInSeconds();

		[Register("pause", "()V", "GetPauseHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void Pause();

		[Register("play", "()V", "GetPlayHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void Play();

		[Register("prepareTrack", "(Lfm/feed/android/playersdk/models/Play;)V", "GetPrepareTrack_Lfm_feed_android_playersdk_models_Play_Handler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void PrepareTrack(Play file);

		[Register("seekTo", "(F)V", "GetSeekTo_FHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void SeekTo(float seconds);

		[Register("skip", "()V", "GetSkipHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void Skip();

		[Register("skipWithCrossFade", "()V", "GetSkipWithCrossFadeHandler:FM.Feed.Android.Playersdk.IMixingAudioPlayerInvoker, iFit.Feed.FM.Android")]
		void SkipWithCrossFade();
	}
	[Register("fm/feed/android/playersdk/MixingAudioPlayer", DoNotGenerateAcw = true)]
	internal class IMixingAudioPlayerInvoker : Java.Lang.Object, IMixingAudioPlayer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/MixingAudioPlayer", typeof(IMixingAudioPlayerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getBTrimmingEnabled;

		private static Delegate cb_setBTrimmingEnabled_Z;

		private IntPtr id_getBTrimmingEnabled;

		private IntPtr id_setBTrimmingEnabled_Z;

		private static Delegate cb_getCurrentPlay;

		private IntPtr id_getCurrentPlay;

		private static Delegate cb_getCurrentPlayDuration;

		private IntPtr id_getCurrentPlayDuration;

		private static Delegate cb_getCurrentPlayTime;

		private IntPtr id_getCurrentPlayTime;

		private static Delegate cb_getFadeDuration;

		private static Delegate cb_setFadeDuration_F;

		private IntPtr id_getFadeDuration;

		private IntPtr id_setFadeDuration_F;

		private static Delegate cb_getMEventListener;

		private static Delegate cb_setMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_;

		private IntPtr id_getMEventListener;

		private IntPtr id_setMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_;

		private static Delegate cb_getState;

		private static Delegate cb_setState_Lfm_feed_android_playersdk_State_;

		private IntPtr id_getState;

		private IntPtr id_setState_Lfm_feed_android_playersdk_State_;

		private static Delegate cb_getVolume;

		private static Delegate cb_setVolume_F;

		private IntPtr id_getVolume;

		private IntPtr id_setVolume_F;

		private static Delegate cb_addAudioAsset_Lfm_feed_android_playersdk_models_Play_;

		private IntPtr id_addAudioAsset_Lfm_feed_android_playersdk_models_Play_;

		private static Delegate cb_cacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_;

		private IntPtr id_cacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_;

		private static Delegate cb_destroy;

		private IntPtr id_destroy;

		private static Delegate cb_flush;

		private IntPtr id_flush;

		private static Delegate cb_flushAndIncludeCurrent_Z;

		private IntPtr id_flushAndIncludeCurrent_Z;

		private static Delegate cb_maxSeekableLengthInSeconds;

		private IntPtr id_maxSeekableLengthInSeconds;

		private static Delegate cb_pause;

		private IntPtr id_pause;

		private static Delegate cb_play;

		private IntPtr id_play;

		private static Delegate cb_prepareTrack_Lfm_feed_android_playersdk_models_Play_;

		private IntPtr id_prepareTrack_Lfm_feed_android_playersdk_models_Play_;

		private static Delegate cb_seekTo_F;

		private IntPtr id_seekTo_F;

		private static Delegate cb_skip;

		private IntPtr id_skip;

		private static Delegate cb_skipWithCrossFade;

		private IntPtr id_skipWithCrossFade;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool BTrimmingEnabled
		{
			get
			{
				if (id_getBTrimmingEnabled == IntPtr.Zero)
				{
					id_getBTrimmingEnabled = JNIEnv.GetMethodID(class_ref, "getBTrimmingEnabled", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_getBTrimmingEnabled);
			}
			set
			{
				if (id_setBTrimmingEnabled_Z == IntPtr.Zero)
				{
					id_setBTrimmingEnabled_Z = JNIEnv.GetMethodID(class_ref, "setBTrimmingEnabled", "(Z)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(value);
				JNIEnv.CallVoidMethod(base.Handle, id_setBTrimmingEnabled_Z, ptr);
			}
		}

		public Play CurrentPlay
		{
			get
			{
				if (id_getCurrentPlay == IntPtr.Zero)
				{
					id_getCurrentPlay = JNIEnv.GetMethodID(class_ref, "getCurrentPlay", "()Lfm/feed/android/playersdk/models/Play;");
				}
				return Java.Lang.Object.GetObject<Play>(JNIEnv.CallObjectMethod(base.Handle, id_getCurrentPlay), JniHandleOwnership.TransferLocalRef);
			}
		}

		public float CurrentPlayDuration
		{
			get
			{
				if (id_getCurrentPlayDuration == IntPtr.Zero)
				{
					id_getCurrentPlayDuration = JNIEnv.GetMethodID(class_ref, "getCurrentPlayDuration", "()F");
				}
				return JNIEnv.CallFloatMethod(base.Handle, id_getCurrentPlayDuration);
			}
		}

		public float CurrentPlayTime
		{
			get
			{
				if (id_getCurrentPlayTime == IntPtr.Zero)
				{
					id_getCurrentPlayTime = JNIEnv.GetMethodID(class_ref, "getCurrentPlayTime", "()F");
				}
				return JNIEnv.CallFloatMethod(base.Handle, id_getCurrentPlayTime);
			}
		}

		public unsafe float FadeDuration
		{
			get
			{
				if (id_getFadeDuration == IntPtr.Zero)
				{
					id_getFadeDuration = JNIEnv.GetMethodID(class_ref, "getFadeDuration", "()F");
				}
				return JNIEnv.CallFloatMethod(base.Handle, id_getFadeDuration);
			}
			set
			{
				if (id_setFadeDuration_F == IntPtr.Zero)
				{
					id_setFadeDuration_F = JNIEnv.GetMethodID(class_ref, "setFadeDuration", "(F)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(value);
				JNIEnv.CallVoidMethod(base.Handle, id_setFadeDuration_F, ptr);
			}
		}

		public unsafe IMixingAudioPlayerEventListener MEventListener
		{
			get
			{
				if (id_getMEventListener == IntPtr.Zero)
				{
					id_getMEventListener = JNIEnv.GetMethodID(class_ref, "getMEventListener", "()Lfm/feed/android/playersdk/MixingAudioPlayer$EventListener;");
				}
				return Java.Lang.Object.GetObject<IMixingAudioPlayerEventListener>(JNIEnv.CallObjectMethod(base.Handle, id_getMEventListener), JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				if (id_setMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_ == IntPtr.Zero)
				{
					id_setMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_ = JNIEnv.GetMethodID(class_ref, "setMEventListener", "(Lfm/feed/android/playersdk/MixingAudioPlayer$EventListener;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				JNIEnv.CallVoidMethod(base.Handle, id_setMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_, ptr);
			}
		}

		public unsafe State State
		{
			get
			{
				if (id_getState == IntPtr.Zero)
				{
					id_getState = JNIEnv.GetMethodID(class_ref, "getState", "()Lfm/feed/android/playersdk/State;");
				}
				return Java.Lang.Object.GetObject<State>(JNIEnv.CallObjectMethod(base.Handle, id_getState), JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				if (id_setState_Lfm_feed_android_playersdk_State_ == IntPtr.Zero)
				{
					id_setState_Lfm_feed_android_playersdk_State_ = JNIEnv.GetMethodID(class_ref, "setState", "(Lfm/feed/android/playersdk/State;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(value?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_setState_Lfm_feed_android_playersdk_State_, ptr);
			}
		}

		public unsafe float Volume
		{
			get
			{
				if (id_getVolume == IntPtr.Zero)
				{
					id_getVolume = JNIEnv.GetMethodID(class_ref, "getVolume", "()F");
				}
				return JNIEnv.CallFloatMethod(base.Handle, id_getVolume);
			}
			set
			{
				if (id_setVolume_F == IntPtr.Zero)
				{
					id_setVolume_F = JNIEnv.GetMethodID(class_ref, "setVolume", "(F)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(value);
				JNIEnv.CallVoidMethod(base.Handle, id_setVolume_F, ptr);
			}
		}

		public static IMixingAudioPlayer GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMixingAudioPlayer>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.MixingAudioPlayer'.");
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

		public IMixingAudioPlayerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetBTrimmingEnabledHandler()
		{
			if ((object)cb_getBTrimmingEnabled == null)
			{
				cb_getBTrimmingEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetBTrimmingEnabled));
			}
			return cb_getBTrimmingEnabled;
		}

		private static bool n_GetBTrimmingEnabled(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return mixingAudioPlayer.BTrimmingEnabled;
		}

		private static Delegate GetSetBTrimmingEnabled_ZHandler()
		{
			if ((object)cb_setBTrimmingEnabled_Z == null)
			{
				cb_setBTrimmingEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetBTrimmingEnabled_Z));
			}
			return cb_setBTrimmingEnabled_Z;
		}

		private static void n_SetBTrimmingEnabled_Z(IntPtr jnienv, IntPtr native__this, bool value)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.BTrimmingEnabled = value;
		}

		private static Delegate GetGetCurrentPlayHandler()
		{
			if ((object)cb_getCurrentPlay == null)
			{
				cb_getCurrentPlay = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCurrentPlay));
			}
			return cb_getCurrentPlay;
		}

		private static IntPtr n_GetCurrentPlay(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(mixingAudioPlayer.CurrentPlay);
		}

		private static Delegate GetGetCurrentPlayDurationHandler()
		{
			if ((object)cb_getCurrentPlayDuration == null)
			{
				cb_getCurrentPlayDuration = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetCurrentPlayDuration));
			}
			return cb_getCurrentPlayDuration;
		}

		private static float n_GetCurrentPlayDuration(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return mixingAudioPlayer.CurrentPlayDuration;
		}

		private static Delegate GetGetCurrentPlayTimeHandler()
		{
			if ((object)cb_getCurrentPlayTime == null)
			{
				cb_getCurrentPlayTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetCurrentPlayTime));
			}
			return cb_getCurrentPlayTime;
		}

		private static float n_GetCurrentPlayTime(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return mixingAudioPlayer.CurrentPlayTime;
		}

		private static Delegate GetGetFadeDurationHandler()
		{
			if ((object)cb_getFadeDuration == null)
			{
				cb_getFadeDuration = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetFadeDuration));
			}
			return cb_getFadeDuration;
		}

		private static float n_GetFadeDuration(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return mixingAudioPlayer.FadeDuration;
		}

		private static Delegate GetSetFadeDuration_FHandler()
		{
			if ((object)cb_setFadeDuration_F == null)
			{
				cb_setFadeDuration_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetFadeDuration_F));
			}
			return cb_setFadeDuration_F;
		}

		private static void n_SetFadeDuration_F(IntPtr jnienv, IntPtr native__this, float value)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.FadeDuration = value;
		}

		private static Delegate GetGetMEventListenerHandler()
		{
			if ((object)cb_getMEventListener == null)
			{
				cb_getMEventListener = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMEventListener));
			}
			return cb_getMEventListener;
		}

		private static IntPtr n_GetMEventListener(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(mixingAudioPlayer.MEventListener);
		}

		private static Delegate GetSetMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_Handler()
		{
			if ((object)cb_setMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_ == null)
			{
				cb_setMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_));
			}
			return cb_setMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_;
		}

		private static void n_SetMEventListener_Lfm_feed_android_playersdk_MixingAudioPlayer_EventListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMixingAudioPlayerEventListener mEventListener = Java.Lang.Object.GetObject<IMixingAudioPlayerEventListener>(native_value, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.MEventListener = mEventListener;
		}

		private static Delegate GetGetStateHandler()
		{
			if ((object)cb_getState == null)
			{
				cb_getState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetState));
			}
			return cb_getState;
		}

		private static IntPtr n_GetState(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(mixingAudioPlayer.State);
		}

		private static Delegate GetSetState_Lfm_feed_android_playersdk_State_Handler()
		{
			if ((object)cb_setState_Lfm_feed_android_playersdk_State_ == null)
			{
				cb_setState_Lfm_feed_android_playersdk_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetState_Lfm_feed_android_playersdk_State_));
			}
			return cb_setState_Lfm_feed_android_playersdk_State_;
		}

		private static void n_SetState_Lfm_feed_android_playersdk_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_value, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.State = state;
		}

		private static Delegate GetGetVolumeHandler()
		{
			if ((object)cb_getVolume == null)
			{
				cb_getVolume = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetVolume));
			}
			return cb_getVolume;
		}

		private static float n_GetVolume(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return mixingAudioPlayer.Volume;
		}

		private static Delegate GetSetVolume_FHandler()
		{
			if ((object)cb_setVolume_F == null)
			{
				cb_setVolume_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetVolume_F));
			}
			return cb_setVolume_F;
		}

		private static void n_SetVolume_F(IntPtr jnienv, IntPtr native__this, float value)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.Volume = value;
		}

		private static Delegate GetAddAudioAsset_Lfm_feed_android_playersdk_models_Play_Handler()
		{
			if ((object)cb_addAudioAsset_Lfm_feed_android_playersdk_models_Play_ == null)
			{
				cb_addAudioAsset_Lfm_feed_android_playersdk_models_Play_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddAudioAsset_Lfm_feed_android_playersdk_models_Play_));
			}
			return cb_addAudioAsset_Lfm_feed_android_playersdk_models_Play_;
		}

		private static void n_AddAudioAsset_Lfm_feed_android_playersdk_models_Play_(IntPtr jnienv, IntPtr native__this, IntPtr native_play)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play play = Java.Lang.Object.GetObject<Play>(native_play, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.AddAudioAsset(play);
		}

		public unsafe void AddAudioAsset(Play play)
		{
			if (id_addAudioAsset_Lfm_feed_android_playersdk_models_Play_ == IntPtr.Zero)
			{
				id_addAudioAsset_Lfm_feed_android_playersdk_models_Play_ = JNIEnv.GetMethodID(class_ref, "addAudioAsset", "(Lfm/feed/android/playersdk/models/Play;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(play?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_addAudioAsset_Lfm_feed_android_playersdk_models_Play_, ptr);
		}

		private static Delegate GetCacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_Handler()
		{
			if ((object)cb_cacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_ == null)
			{
				cb_cacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_CacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_));
			}
			return cb_cacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_;
		}

		private static void n_CacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_url, int maxCache, IntPtr native_listener)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string url = JNIEnv.GetString(native_url, JniHandleOwnership.DoNotTransfer);
			ICacheMediaListener listener = Java.Lang.Object.GetObject<ICacheMediaListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.CacheMedia(url, maxCache, listener);
		}

		public unsafe void CacheMedia(string url, int maxCache, ICacheMediaListener listener)
		{
			if (id_cacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_ == IntPtr.Zero)
			{
				id_cacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_ = JNIEnv.GetMethodID(class_ref, "cacheMedia", "(Ljava/lang/String;ILfm/feed/android/playersdk/CacheMediaListener;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(url);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(maxCache);
			ptr[2] = new JValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_cacheMedia_Ljava_lang_String_ILfm_feed_android_playersdk_CacheMediaListener_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetDestroyHandler()
		{
			if ((object)cb_destroy == null)
			{
				cb_destroy = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Destroy));
			}
			return cb_destroy;
		}

		private static void n_Destroy(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.Destroy();
		}

		public void Destroy()
		{
			if (id_destroy == IntPtr.Zero)
			{
				id_destroy = JNIEnv.GetMethodID(class_ref, "destroy", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_destroy);
		}

		private static Delegate GetFlushHandler()
		{
			if ((object)cb_flush == null)
			{
				cb_flush = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Flush));
			}
			return cb_flush;
		}

		private static void n_Flush(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.Flush();
		}

		public void Flush()
		{
			if (id_flush == IntPtr.Zero)
			{
				id_flush = JNIEnv.GetMethodID(class_ref, "flush", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_flush);
		}

		private static Delegate GetFlushAndIncludeCurrent_ZHandler()
		{
			if ((object)cb_flushAndIncludeCurrent_Z == null)
			{
				cb_flushAndIncludeCurrent_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_FlushAndIncludeCurrent_Z));
			}
			return cb_flushAndIncludeCurrent_Z;
		}

		private static void n_FlushAndIncludeCurrent_Z(IntPtr jnienv, IntPtr native__this, bool bTrue)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.FlushAndIncludeCurrent(bTrue);
		}

		public unsafe void FlushAndIncludeCurrent(bool bTrue)
		{
			if (id_flushAndIncludeCurrent_Z == IntPtr.Zero)
			{
				id_flushAndIncludeCurrent_Z = JNIEnv.GetMethodID(class_ref, "flushAndIncludeCurrent", "(Z)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(bTrue);
			JNIEnv.CallVoidMethod(base.Handle, id_flushAndIncludeCurrent_Z, ptr);
		}

		private static Delegate GetMaxSeekableLengthInSecondsHandler()
		{
			if ((object)cb_maxSeekableLengthInSeconds == null)
			{
				cb_maxSeekableLengthInSeconds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_MaxSeekableLengthInSeconds));
			}
			return cb_maxSeekableLengthInSeconds;
		}

		private static float n_MaxSeekableLengthInSeconds(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return mixingAudioPlayer.MaxSeekableLengthInSeconds();
		}

		public float MaxSeekableLengthInSeconds()
		{
			if (id_maxSeekableLengthInSeconds == IntPtr.Zero)
			{
				id_maxSeekableLengthInSeconds = JNIEnv.GetMethodID(class_ref, "maxSeekableLengthInSeconds", "()F");
			}
			return JNIEnv.CallFloatMethod(base.Handle, id_maxSeekableLengthInSeconds);
		}

		private static Delegate GetPauseHandler()
		{
			if ((object)cb_pause == null)
			{
				cb_pause = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Pause));
			}
			return cb_pause;
		}

		private static void n_Pause(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.Pause();
		}

		public void Pause()
		{
			if (id_pause == IntPtr.Zero)
			{
				id_pause = JNIEnv.GetMethodID(class_ref, "pause", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_pause);
		}

		private static Delegate GetPlayHandler()
		{
			if ((object)cb_play == null)
			{
				cb_play = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Play));
			}
			return cb_play;
		}

		private static void n_Play(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.Play();
		}

		public void Play()
		{
			if (id_play == IntPtr.Zero)
			{
				id_play = JNIEnv.GetMethodID(class_ref, "play", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_play);
		}

		private static Delegate GetPrepareTrack_Lfm_feed_android_playersdk_models_Play_Handler()
		{
			if ((object)cb_prepareTrack_Lfm_feed_android_playersdk_models_Play_ == null)
			{
				cb_prepareTrack_Lfm_feed_android_playersdk_models_Play_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PrepareTrack_Lfm_feed_android_playersdk_models_Play_));
			}
			return cb_prepareTrack_Lfm_feed_android_playersdk_models_Play_;
		}

		private static void n_PrepareTrack_Lfm_feed_android_playersdk_models_Play_(IntPtr jnienv, IntPtr native__this, IntPtr native_file)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play file = Java.Lang.Object.GetObject<Play>(native_file, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.PrepareTrack(file);
		}

		public unsafe void PrepareTrack(Play file)
		{
			if (id_prepareTrack_Lfm_feed_android_playersdk_models_Play_ == IntPtr.Zero)
			{
				id_prepareTrack_Lfm_feed_android_playersdk_models_Play_ = JNIEnv.GetMethodID(class_ref, "prepareTrack", "(Lfm/feed/android/playersdk/models/Play;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(file?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_prepareTrack_Lfm_feed_android_playersdk_models_Play_, ptr);
		}

		private static Delegate GetSeekTo_FHandler()
		{
			if ((object)cb_seekTo_F == null)
			{
				cb_seekTo_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SeekTo_F));
			}
			return cb_seekTo_F;
		}

		private static void n_SeekTo_F(IntPtr jnienv, IntPtr native__this, float seconds)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.SeekTo(seconds);
		}

		public unsafe void SeekTo(float seconds)
		{
			if (id_seekTo_F == IntPtr.Zero)
			{
				id_seekTo_F = JNIEnv.GetMethodID(class_ref, "seekTo", "(F)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(seconds);
			JNIEnv.CallVoidMethod(base.Handle, id_seekTo_F, ptr);
		}

		private static Delegate GetSkipHandler()
		{
			if ((object)cb_skip == null)
			{
				cb_skip = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Skip));
			}
			return cb_skip;
		}

		private static void n_Skip(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.Skip();
		}

		public void Skip()
		{
			if (id_skip == IntPtr.Zero)
			{
				id_skip = JNIEnv.GetMethodID(class_ref, "skip", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_skip);
		}

		private static Delegate GetSkipWithCrossFadeHandler()
		{
			if ((object)cb_skipWithCrossFade == null)
			{
				cb_skipWithCrossFade = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SkipWithCrossFade));
			}
			return cb_skipWithCrossFade;
		}

		private static void n_SkipWithCrossFade(IntPtr jnienv, IntPtr native__this)
		{
			IMixingAudioPlayer mixingAudioPlayer = Java.Lang.Object.GetObject<IMixingAudioPlayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			mixingAudioPlayer.SkipWithCrossFade();
		}

		public void SkipWithCrossFade()
		{
			if (id_skipWithCrossFade == IntPtr.Zero)
			{
				id_skipWithCrossFade = JNIEnv.GetMethodID(class_ref, "skipWithCrossFade", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_skipWithCrossFade);
		}
	}
	[Register("fm/feed/android/playersdk/MusicQueuedListener", "", "FM.Feed.Android.Playersdk.IMusicQueuedListenerInvoker")]
	public interface IMusicQueuedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onMusicQueued", "()V", "GetOnMusicQueuedHandler:FM.Feed.Android.Playersdk.IMusicQueuedListenerInvoker, iFit.Feed.FM.Android")]
		void OnMusicQueued();
	}
	[Register("fm/feed/android/playersdk/MusicQueuedListener", DoNotGenerateAcw = true)]
	internal class IMusicQueuedListenerInvoker : Java.Lang.Object, IMusicQueuedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/MusicQueuedListener", typeof(IMusicQueuedListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onMusicQueued;

		private IntPtr id_onMusicQueued;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IMusicQueuedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMusicQueuedListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.MusicQueuedListener'.");
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

		public IMusicQueuedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnMusicQueuedHandler()
		{
			if ((object)cb_onMusicQueued == null)
			{
				cb_onMusicQueued = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnMusicQueued));
			}
			return cb_onMusicQueued;
		}

		private static void n_OnMusicQueued(IntPtr jnienv, IntPtr native__this)
		{
			IMusicQueuedListener musicQueuedListener = Java.Lang.Object.GetObject<IMusicQueuedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			musicQueuedListener.OnMusicQueued();
		}

		public void OnMusicQueued()
		{
			if (id_onMusicQueued == IntPtr.Zero)
			{
				id_onMusicQueued = JNIEnv.GetMethodID(class_ref, "onMusicQueued", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onMusicQueued);
		}
	}
	[Register("mono/fm/feed/android/playersdk/MusicQueuedListenerImplementor")]
	internal sealed class IMusicQueuedListenerImplementor : Java.Lang.Object, IMusicQueuedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IMusicQueuedListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/MusicQueuedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnMusicQueued()
		{
		}

		internal static bool __IsEmpty(IMusicQueuedListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/OutOfMusicListener", "", "FM.Feed.Android.Playersdk.IOutOfMusicListenerInvoker")]
	public interface IOutOfMusicListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onOutOfMusic", "()V", "GetOnOutOfMusicHandler:FM.Feed.Android.Playersdk.IOutOfMusicListenerInvoker, iFit.Feed.FM.Android")]
		void OnOutOfMusic();
	}
	[Register("fm/feed/android/playersdk/OutOfMusicListener", DoNotGenerateAcw = true)]
	internal class IOutOfMusicListenerInvoker : Java.Lang.Object, IOutOfMusicListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/OutOfMusicListener", typeof(IOutOfMusicListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onOutOfMusic;

		private IntPtr id_onOutOfMusic;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOutOfMusicListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOutOfMusicListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.OutOfMusicListener'.");
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

		public IOutOfMusicListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnOutOfMusicHandler()
		{
			if ((object)cb_onOutOfMusic == null)
			{
				cb_onOutOfMusic = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnOutOfMusic));
			}
			return cb_onOutOfMusic;
		}

		private static void n_OnOutOfMusic(IntPtr jnienv, IntPtr native__this)
		{
			IOutOfMusicListener outOfMusicListener = Java.Lang.Object.GetObject<IOutOfMusicListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			outOfMusicListener.OnOutOfMusic();
		}

		public void OnOutOfMusic()
		{
			if (id_onOutOfMusic == IntPtr.Zero)
			{
				id_onOutOfMusic = JNIEnv.GetMethodID(class_ref, "onOutOfMusic", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onOutOfMusic);
		}
	}
	[Register("mono/fm/feed/android/playersdk/OutOfMusicListenerImplementor")]
	internal sealed class IOutOfMusicListenerImplementor : Java.Lang.Object, IOutOfMusicListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IOutOfMusicListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/OutOfMusicListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnOutOfMusic()
		{
		}

		internal static bool __IsEmpty(IOutOfMusicListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/PlayListener", "", "FM.Feed.Android.Playersdk.IPlayListenerInvoker")]
	public interface IPlayListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onPlayStarted", "(Lfm/feed/android/playersdk/models/Play;)V", "GetOnPlayStarted_Lfm_feed_android_playersdk_models_Play_Handler:FM.Feed.Android.Playersdk.IPlayListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayStarted(Play play);

		[Register("onProgressUpdate", "(Lfm/feed/android/playersdk/models/Play;FF)V", "GetOnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FFHandler:FM.Feed.Android.Playersdk.IPlayListenerInvoker, iFit.Feed.FM.Android")]
		void OnProgressUpdate(Play play, float elapsedTime, float duration);

		[Register("onSkipStatusChanged", "(Z)V", "GetOnSkipStatusChanged_ZHandler:FM.Feed.Android.Playersdk.IPlayListenerInvoker, iFit.Feed.FM.Android")]
		void OnSkipStatusChanged(bool status);
	}
	[Register("fm/feed/android/playersdk/PlayListener", DoNotGenerateAcw = true)]
	internal class IPlayListenerInvoker : Java.Lang.Object, IPlayListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/PlayListener", typeof(IPlayListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onPlayStarted_Lfm_feed_android_playersdk_models_Play_;

		private IntPtr id_onPlayStarted_Lfm_feed_android_playersdk_models_Play_;

		private static Delegate cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF;

		private IntPtr id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF;

		private static Delegate cb_onSkipStatusChanged_Z;

		private IntPtr id_onSkipStatusChanged_Z;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IPlayListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPlayListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.PlayListener'.");
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

		public IPlayListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnPlayStarted_Lfm_feed_android_playersdk_models_Play_Handler()
		{
			if ((object)cb_onPlayStarted_Lfm_feed_android_playersdk_models_Play_ == null)
			{
				cb_onPlayStarted_Lfm_feed_android_playersdk_models_Play_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlayStarted_Lfm_feed_android_playersdk_models_Play_));
			}
			return cb_onPlayStarted_Lfm_feed_android_playersdk_models_Play_;
		}

		private static void n_OnPlayStarted_Lfm_feed_android_playersdk_models_Play_(IntPtr jnienv, IntPtr native__this, IntPtr native_play)
		{
			IPlayListener playListener = Java.Lang.Object.GetObject<IPlayListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play play = Java.Lang.Object.GetObject<Play>(native_play, JniHandleOwnership.DoNotTransfer);
			playListener.OnPlayStarted(play);
		}

		public unsafe void OnPlayStarted(Play play)
		{
			if (id_onPlayStarted_Lfm_feed_android_playersdk_models_Play_ == IntPtr.Zero)
			{
				id_onPlayStarted_Lfm_feed_android_playersdk_models_Play_ = JNIEnv.GetMethodID(class_ref, "onPlayStarted", "(Lfm/feed/android/playersdk/models/Play;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(play?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayStarted_Lfm_feed_android_playersdk_models_Play_, ptr);
		}

		private static Delegate GetOnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FFHandler()
		{
			if ((object)cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF == null)
			{
				cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLFF_V(n_OnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF));
			}
			return cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF;
		}

		private static void n_OnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF(IntPtr jnienv, IntPtr native__this, IntPtr native_play, float elapsedTime, float duration)
		{
			IPlayListener playListener = Java.Lang.Object.GetObject<IPlayListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play play = Java.Lang.Object.GetObject<Play>(native_play, JniHandleOwnership.DoNotTransfer);
			playListener.OnProgressUpdate(play, elapsedTime, duration);
		}

		public unsafe void OnProgressUpdate(Play play, float elapsedTime, float duration)
		{
			if (id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF == IntPtr.Zero)
			{
				id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF = JNIEnv.GetMethodID(class_ref, "onProgressUpdate", "(Lfm/feed/android/playersdk/models/Play;FF)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(play?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(elapsedTime);
			ptr[2] = new JValue(duration);
			JNIEnv.CallVoidMethod(base.Handle, id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF, ptr);
		}

		private static Delegate GetOnSkipStatusChanged_ZHandler()
		{
			if ((object)cb_onSkipStatusChanged_Z == null)
			{
				cb_onSkipStatusChanged_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnSkipStatusChanged_Z));
			}
			return cb_onSkipStatusChanged_Z;
		}

		private static void n_OnSkipStatusChanged_Z(IntPtr jnienv, IntPtr native__this, bool status)
		{
			IPlayListener playListener = Java.Lang.Object.GetObject<IPlayListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			playListener.OnSkipStatusChanged(status);
		}

		public unsafe void OnSkipStatusChanged(bool status)
		{
			if (id_onSkipStatusChanged_Z == IntPtr.Zero)
			{
				id_onSkipStatusChanged_Z = JNIEnv.GetMethodID(class_ref, "onSkipStatusChanged", "(Z)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(status);
			JNIEnv.CallVoidMethod(base.Handle, id_onSkipStatusChanged_Z, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/PlayListenerImplementor")]
	internal sealed class IPlayListenerImplementor : Java.Lang.Object, IPlayListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IPlayListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/PlayListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnPlayStarted(Play play)
		{
		}

		public void OnProgressUpdate(Play play, float elapsedTime, float duration)
		{
		}

		public void OnSkipStatusChanged(bool status)
		{
		}

		internal static bool __IsEmpty(IPlayListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/SessionUpdateListener", "", "FM.Feed.Android.Playersdk.ISessionUpdateListenerInvoker")]
	public interface ISessionUpdateListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onUpdatedSessionAvailable", "()V", "GetOnUpdatedSessionAvailableHandler:FM.Feed.Android.Playersdk.ISessionUpdateListenerInvoker, iFit.Feed.FM.Android")]
		void OnUpdatedSessionAvailable();
	}
	[Register("fm/feed/android/playersdk/SessionUpdateListener", DoNotGenerateAcw = true)]
	internal class ISessionUpdateListenerInvoker : Java.Lang.Object, ISessionUpdateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/SessionUpdateListener", typeof(ISessionUpdateListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onUpdatedSessionAvailable;

		private IntPtr id_onUpdatedSessionAvailable;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ISessionUpdateListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISessionUpdateListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.SessionUpdateListener'.");
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

		public ISessionUpdateListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnUpdatedSessionAvailableHandler()
		{
			if ((object)cb_onUpdatedSessionAvailable == null)
			{
				cb_onUpdatedSessionAvailable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnUpdatedSessionAvailable));
			}
			return cb_onUpdatedSessionAvailable;
		}

		private static void n_OnUpdatedSessionAvailable(IntPtr jnienv, IntPtr native__this)
		{
			ISessionUpdateListener sessionUpdateListener = Java.Lang.Object.GetObject<ISessionUpdateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			sessionUpdateListener.OnUpdatedSessionAvailable();
		}

		public void OnUpdatedSessionAvailable()
		{
			if (id_onUpdatedSessionAvailable == IntPtr.Zero)
			{
				id_onUpdatedSessionAvailable = JNIEnv.GetMethodID(class_ref, "onUpdatedSessionAvailable", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onUpdatedSessionAvailable);
		}
	}
	[Register("mono/fm/feed/android/playersdk/SessionUpdateListenerImplementor")]
	internal sealed class ISessionUpdateListenerImplementor : Java.Lang.Object, ISessionUpdateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public ISessionUpdateListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/SessionUpdateListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnUpdatedSessionAvailable()
		{
		}

		internal static bool __IsEmpty(ISessionUpdateListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/SimulcastEventListener", "", "FM.Feed.Android.Playersdk.ISimulcastEventListenerInvoker")]
	public interface ISimulcastEventListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onPlayItemBeganPlayback", "(Lfm/feed/android/playersdk/models/Play;)V", "GetOnPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_Handler:FM.Feed.Android.Playersdk.ISimulcastEventListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayItemBeganPlayback(Play play);

		[Register("onPlayerError", "(Ljava/lang/Exception;)V", "GetOnPlayerError_Ljava_lang_Exception_Handler:FM.Feed.Android.Playersdk.ISimulcastEventListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayerError(Java.Lang.Exception error);

		[Register("onPlayerStateChanged", "(Lfm/feed/android/playersdk/SimulcastPlaybackState;)V", "GetOnPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_Handler:FM.Feed.Android.Playersdk.ISimulcastEventListenerInvoker, iFit.Feed.FM.Android")]
		void OnPlayerStateChanged(SimulcastPlaybackState playerState);

		[Register("onProgressUpdate", "(Lfm/feed/android/playersdk/models/Play;FF)V", "GetOnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FFHandler:FM.Feed.Android.Playersdk.ISimulcastEventListenerInvoker, iFit.Feed.FM.Android")]
		void OnProgressUpdate(Play play, float elapsedTime, float duration);
	}
	[Register("fm/feed/android/playersdk/SimulcastEventListener", DoNotGenerateAcw = true)]
	internal class ISimulcastEventListenerInvoker : Java.Lang.Object, ISimulcastEventListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/SimulcastEventListener", typeof(ISimulcastEventListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_;

		private IntPtr id_onPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_;

		private static Delegate cb_onPlayerError_Ljava_lang_Exception_;

		private IntPtr id_onPlayerError_Ljava_lang_Exception_;

		private static Delegate cb_onPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_;

		private IntPtr id_onPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_;

		private static Delegate cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF;

		private IntPtr id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ISimulcastEventListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISimulcastEventListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.SimulcastEventListener'.");
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

		public ISimulcastEventListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_Handler()
		{
			if ((object)cb_onPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_ == null)
			{
				cb_onPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_));
			}
			return cb_onPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_;
		}

		private static void n_OnPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_(IntPtr jnienv, IntPtr native__this, IntPtr native_play)
		{
			ISimulcastEventListener simulcastEventListener = Java.Lang.Object.GetObject<ISimulcastEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play play = Java.Lang.Object.GetObject<Play>(native_play, JniHandleOwnership.DoNotTransfer);
			simulcastEventListener.OnPlayItemBeganPlayback(play);
		}

		public unsafe void OnPlayItemBeganPlayback(Play play)
		{
			if (id_onPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_ == IntPtr.Zero)
			{
				id_onPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_ = JNIEnv.GetMethodID(class_ref, "onPlayItemBeganPlayback", "(Lfm/feed/android/playersdk/models/Play;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(play?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayItemBeganPlayback_Lfm_feed_android_playersdk_models_Play_, ptr);
		}

		private static Delegate GetOnPlayerError_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_onPlayerError_Ljava_lang_Exception_ == null)
			{
				cb_onPlayerError_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlayerError_Ljava_lang_Exception_));
			}
			return cb_onPlayerError_Ljava_lang_Exception_;
		}

		private static void n_OnPlayerError_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_error)
		{
			ISimulcastEventListener simulcastEventListener = Java.Lang.Object.GetObject<ISimulcastEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception error = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_error, JniHandleOwnership.DoNotTransfer);
			simulcastEventListener.OnPlayerError(error);
		}

		public unsafe void OnPlayerError(Java.Lang.Exception error)
		{
			if (id_onPlayerError_Ljava_lang_Exception_ == IntPtr.Zero)
			{
				id_onPlayerError_Ljava_lang_Exception_ = JNIEnv.GetMethodID(class_ref, "onPlayerError", "(Ljava/lang/Exception;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(error?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayerError_Ljava_lang_Exception_, ptr);
		}

		private static Delegate GetOnPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_Handler()
		{
			if ((object)cb_onPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_ == null)
			{
				cb_onPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_));
			}
			return cb_onPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_;
		}

		private static void n_OnPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_(IntPtr jnienv, IntPtr native__this, IntPtr native_playerState)
		{
			ISimulcastEventListener simulcastEventListener = Java.Lang.Object.GetObject<ISimulcastEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SimulcastPlaybackState playerState = Java.Lang.Object.GetObject<SimulcastPlaybackState>(native_playerState, JniHandleOwnership.DoNotTransfer);
			simulcastEventListener.OnPlayerStateChanged(playerState);
		}

		public unsafe void OnPlayerStateChanged(SimulcastPlaybackState playerState)
		{
			if (id_onPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_ == IntPtr.Zero)
			{
				id_onPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_ = JNIEnv.GetMethodID(class_ref, "onPlayerStateChanged", "(Lfm/feed/android/playersdk/SimulcastPlaybackState;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(playerState?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onPlayerStateChanged_Lfm_feed_android_playersdk_SimulcastPlaybackState_, ptr);
		}

		private static Delegate GetOnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FFHandler()
		{
			if ((object)cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF == null)
			{
				cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLFF_V(n_OnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF));
			}
			return cb_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF;
		}

		private static void n_OnProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF(IntPtr jnienv, IntPtr native__this, IntPtr native_play, float elapsedTime, float duration)
		{
			ISimulcastEventListener simulcastEventListener = Java.Lang.Object.GetObject<ISimulcastEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Play play = Java.Lang.Object.GetObject<Play>(native_play, JniHandleOwnership.DoNotTransfer);
			simulcastEventListener.OnProgressUpdate(play, elapsedTime, duration);
		}

		public unsafe void OnProgressUpdate(Play play, float elapsedTime, float duration)
		{
			if (id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF == IntPtr.Zero)
			{
				id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF = JNIEnv.GetMethodID(class_ref, "onProgressUpdate", "(Lfm/feed/android/playersdk/models/Play;FF)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(play?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(elapsedTime);
			ptr[2] = new JValue(duration);
			JNIEnv.CallVoidMethod(base.Handle, id_onProgressUpdate_Lfm_feed_android_playersdk_models_Play_FF, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/SimulcastEventListenerImplementor")]
	internal sealed class ISimulcastEventListenerImplementor : Java.Lang.Object, ISimulcastEventListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public ISimulcastEventListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/SimulcastEventListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnPlayItemBeganPlayback(Play play)
		{
		}

		public void OnPlayerError(Java.Lang.Exception error)
		{
		}

		public void OnPlayerStateChanged(SimulcastPlaybackState playerState)
		{
		}

		public void OnProgressUpdate(Play play, float elapsedTime, float duration)
		{
		}

		internal static bool __IsEmpty(ISimulcastEventListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/SkipListener", "", "FM.Feed.Android.Playersdk.ISkipListenerInvoker")]
	public interface ISkipListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("requestCompleted", "(Z)V", "GetRequestCompleted_ZHandler:FM.Feed.Android.Playersdk.ISkipListenerInvoker, iFit.Feed.FM.Android")]
		void RequestCompleted(bool isSuccess);
	}
	[Register("fm/feed/android/playersdk/SkipListener", DoNotGenerateAcw = true)]
	internal class ISkipListenerInvoker : Java.Lang.Object, ISkipListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/SkipListener", typeof(ISkipListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_requestCompleted_Z;

		private IntPtr id_requestCompleted_Z;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ISkipListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISkipListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.SkipListener'.");
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

		public ISkipListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetRequestCompleted_ZHandler()
		{
			if ((object)cb_requestCompleted_Z == null)
			{
				cb_requestCompleted_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_RequestCompleted_Z));
			}
			return cb_requestCompleted_Z;
		}

		private static void n_RequestCompleted_Z(IntPtr jnienv, IntPtr native__this, bool isSuccess)
		{
			ISkipListener skipListener = Java.Lang.Object.GetObject<ISkipListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			skipListener.RequestCompleted(isSuccess);
		}

		public unsafe void RequestCompleted(bool isSuccess)
		{
			if (id_requestCompleted_Z == IntPtr.Zero)
			{
				id_requestCompleted_Z = JNIEnv.GetMethodID(class_ref, "requestCompleted", "(Z)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(isSuccess);
			JNIEnv.CallVoidMethod(base.Handle, id_requestCompleted_Z, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/SkipListenerImplementor")]
	internal sealed class ISkipListenerImplementor : Java.Lang.Object, ISkipListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public ISkipListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/SkipListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void RequestCompleted(bool isSuccess)
		{
		}

		internal static bool __IsEmpty(ISkipListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/StateListener", "", "FM.Feed.Android.Playersdk.IStateListenerInvoker")]
	public interface IStateListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onStateChanged", "(Lfm/feed/android/playersdk/State;)V", "GetOnStateChanged_Lfm_feed_android_playersdk_State_Handler:FM.Feed.Android.Playersdk.IStateListenerInvoker, iFit.Feed.FM.Android")]
		void OnStateChanged(State state);
	}
	[Register("fm/feed/android/playersdk/StateListener", DoNotGenerateAcw = true)]
	internal class IStateListenerInvoker : Java.Lang.Object, IStateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/StateListener", typeof(IStateListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onStateChanged_Lfm_feed_android_playersdk_State_;

		private IntPtr id_onStateChanged_Lfm_feed_android_playersdk_State_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IStateListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IStateListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.StateListener'.");
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

		public IStateListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnStateChanged_Lfm_feed_android_playersdk_State_Handler()
		{
			if ((object)cb_onStateChanged_Lfm_feed_android_playersdk_State_ == null)
			{
				cb_onStateChanged_Lfm_feed_android_playersdk_State_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnStateChanged_Lfm_feed_android_playersdk_State_));
			}
			return cb_onStateChanged_Lfm_feed_android_playersdk_State_;
		}

		private static void n_OnStateChanged_Lfm_feed_android_playersdk_State_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			IStateListener stateListener = Java.Lang.Object.GetObject<IStateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
			stateListener.OnStateChanged(state);
		}

		public unsafe void OnStateChanged(State state)
		{
			if (id_onStateChanged_Lfm_feed_android_playersdk_State_ == IntPtr.Zero)
			{
				id_onStateChanged_Lfm_feed_android_playersdk_State_ = JNIEnv.GetMethodID(class_ref, "onStateChanged", "(Lfm/feed/android/playersdk/State;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(state?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onStateChanged_Lfm_feed_android_playersdk_State_, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/StateListenerImplementor")]
	internal sealed class IStateListenerImplementor : Java.Lang.Object, IStateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IStateListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/StateListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnStateChanged(State state)
		{
		}

		internal static bool __IsEmpty(IStateListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/StationChangedListener", "", "FM.Feed.Android.Playersdk.IStationChangedListenerInvoker")]
	public interface IStationChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onStationChanged", "(Lfm/feed/android/playersdk/models/Station;)V", "GetOnStationChanged_Lfm_feed_android_playersdk_models_Station_Handler:FM.Feed.Android.Playersdk.IStationChangedListenerInvoker, iFit.Feed.FM.Android")]
		void OnStationChanged(Station station);
	}
	[Register("fm/feed/android/playersdk/StationChangedListener", DoNotGenerateAcw = true)]
	internal class IStationChangedListenerInvoker : Java.Lang.Object, IStationChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/StationChangedListener", typeof(IStationChangedListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onStationChanged_Lfm_feed_android_playersdk_models_Station_;

		private IntPtr id_onStationChanged_Lfm_feed_android_playersdk_models_Station_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IStationChangedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IStationChangedListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.StationChangedListener'.");
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

		public IStationChangedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnStationChanged_Lfm_feed_android_playersdk_models_Station_Handler()
		{
			if ((object)cb_onStationChanged_Lfm_feed_android_playersdk_models_Station_ == null)
			{
				cb_onStationChanged_Lfm_feed_android_playersdk_models_Station_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnStationChanged_Lfm_feed_android_playersdk_models_Station_));
			}
			return cb_onStationChanged_Lfm_feed_android_playersdk_models_Station_;
		}

		private static void n_OnStationChanged_Lfm_feed_android_playersdk_models_Station_(IntPtr jnienv, IntPtr native__this, IntPtr native_station)
		{
			IStationChangedListener stationChangedListener = Java.Lang.Object.GetObject<IStationChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Station station = Java.Lang.Object.GetObject<Station>(native_station, JniHandleOwnership.DoNotTransfer);
			stationChangedListener.OnStationChanged(station);
		}

		public unsafe void OnStationChanged(Station station)
		{
			if (id_onStationChanged_Lfm_feed_android_playersdk_models_Station_ == IntPtr.Zero)
			{
				id_onStationChanged_Lfm_feed_android_playersdk_models_Station_ = JNIEnv.GetMethodID(class_ref, "onStationChanged", "(Lfm/feed/android/playersdk/models/Station;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(station?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onStationChanged_Lfm_feed_android_playersdk_models_Station_, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/StationChangedListenerImplementor")]
	internal sealed class IStationChangedListenerImplementor : Java.Lang.Object, IStationChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IStationChangedListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/StationChangedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnStationChanged(Station station)
		{
		}

		internal static bool __IsEmpty(IStationChangedListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/StationDownloadListener", "", "FM.Feed.Android.Playersdk.IStationDownloadListenerInvoker")]
	public interface IStationDownloadListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onDownloadProgress", "(Lfm/feed/android/playersdk/models/Station;III)V", "GetOnDownloadProgress_Lfm_feed_android_playersdk_models_Station_IIIHandler:FM.Feed.Android.Playersdk.IStationDownloadListenerInvoker, iFit.Feed.FM.Android")]
		void OnDownloadProgress(Station station, int totalDownloads, int pendingDownloads, int interruptedDownloads);
	}
	[Register("fm/feed/android/playersdk/StationDownloadListener", DoNotGenerateAcw = true)]
	internal class IStationDownloadListenerInvoker : Java.Lang.Object, IStationDownloadListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/StationDownloadListener", typeof(IStationDownloadListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onDownloadProgress_Lfm_feed_android_playersdk_models_Station_III;

		private IntPtr id_onDownloadProgress_Lfm_feed_android_playersdk_models_Station_III;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IStationDownloadListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IStationDownloadListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.StationDownloadListener'.");
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

		public IStationDownloadListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnDownloadProgress_Lfm_feed_android_playersdk_models_Station_IIIHandler()
		{
			if ((object)cb_onDownloadProgress_Lfm_feed_android_playersdk_models_Station_III == null)
			{
				cb_onDownloadProgress_Lfm_feed_android_playersdk_models_Station_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIII_V(n_OnDownloadProgress_Lfm_feed_android_playersdk_models_Station_III));
			}
			return cb_onDownloadProgress_Lfm_feed_android_playersdk_models_Station_III;
		}

		private static void n_OnDownloadProgress_Lfm_feed_android_playersdk_models_Station_III(IntPtr jnienv, IntPtr native__this, IntPtr native_station, int totalDownloads, int pendingDownloads, int interruptedDownloads)
		{
			IStationDownloadListener stationDownloadListener = Java.Lang.Object.GetObject<IStationDownloadListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Station station = Java.Lang.Object.GetObject<Station>(native_station, JniHandleOwnership.DoNotTransfer);
			stationDownloadListener.OnDownloadProgress(station, totalDownloads, pendingDownloads, interruptedDownloads);
		}

		public unsafe void OnDownloadProgress(Station station, int totalDownloads, int pendingDownloads, int interruptedDownloads)
		{
			if (id_onDownloadProgress_Lfm_feed_android_playersdk_models_Station_III == IntPtr.Zero)
			{
				id_onDownloadProgress_Lfm_feed_android_playersdk_models_Station_III = JNIEnv.GetMethodID(class_ref, "onDownloadProgress", "(Lfm/feed/android/playersdk/models/Station;III)V");
			}
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(station?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(totalDownloads);
			ptr[2] = new JValue(pendingDownloads);
			ptr[3] = new JValue(interruptedDownloads);
			JNIEnv.CallVoidMethod(base.Handle, id_onDownloadProgress_Lfm_feed_android_playersdk_models_Station_III, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/StationDownloadListenerImplementor")]
	internal sealed class IStationDownloadListenerImplementor : Java.Lang.Object, IStationDownloadListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IStationDownloadListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/StationDownloadListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnDownloadProgress(Station station, int totalDownloads, int pendingDownloads, int interruptedDownloads)
		{
		}

		internal static bool __IsEmpty(IStationDownloadListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/UnhandledErrorListener", "", "FM.Feed.Android.Playersdk.IUnhandledErrorListenerInvoker")]
	public interface IUnhandledErrorListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onUnhandledError", "(Lfm/feed/android/playersdk/FeedException;)V", "GetOnUnhandledError_Lfm_feed_android_playersdk_FeedException_Handler:FM.Feed.Android.Playersdk.IUnhandledErrorListenerInvoker, iFit.Feed.FM.Android")]
		void OnUnhandledError(FeedException error);
	}
	[Register("fm/feed/android/playersdk/UnhandledErrorListener", DoNotGenerateAcw = true)]
	internal class IUnhandledErrorListenerInvoker : Java.Lang.Object, IUnhandledErrorListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/UnhandledErrorListener", typeof(IUnhandledErrorListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onUnhandledError_Lfm_feed_android_playersdk_FeedException_;

		private IntPtr id_onUnhandledError_Lfm_feed_android_playersdk_FeedException_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IUnhandledErrorListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IUnhandledErrorListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.UnhandledErrorListener'.");
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

		public IUnhandledErrorListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnUnhandledError_Lfm_feed_android_playersdk_FeedException_Handler()
		{
			if ((object)cb_onUnhandledError_Lfm_feed_android_playersdk_FeedException_ == null)
			{
				cb_onUnhandledError_Lfm_feed_android_playersdk_FeedException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnUnhandledError_Lfm_feed_android_playersdk_FeedException_));
			}
			return cb_onUnhandledError_Lfm_feed_android_playersdk_FeedException_;
		}

		private static void n_OnUnhandledError_Lfm_feed_android_playersdk_FeedException_(IntPtr jnienv, IntPtr native__this, IntPtr native_error)
		{
			IUnhandledErrorListener unhandledErrorListener = Java.Lang.Object.GetObject<IUnhandledErrorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FeedException error = Java.Lang.Object.GetObject<FeedException>(native_error, JniHandleOwnership.DoNotTransfer);
			unhandledErrorListener.OnUnhandledError(error);
		}

		public unsafe void OnUnhandledError(FeedException error)
		{
			if (id_onUnhandledError_Lfm_feed_android_playersdk_FeedException_ == IntPtr.Zero)
			{
				id_onUnhandledError_Lfm_feed_android_playersdk_FeedException_ = JNIEnv.GetMethodID(class_ref, "onUnhandledError", "(Lfm/feed/android/playersdk/FeedException;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(error?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onUnhandledError_Lfm_feed_android_playersdk_FeedException_, ptr);
		}
	}
	[Register("mono/fm/feed/android/playersdk/UnhandledErrorListenerImplementor")]
	internal sealed class IUnhandledErrorListenerImplementor : Java.Lang.Object, IUnhandledErrorListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public IUnhandledErrorListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/UnhandledErrorListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnUnhandledError(FeedException error)
		{
		}

		internal static bool __IsEmpty(IUnhandledErrorListenerImplementor value)
		{
			return true;
		}
	}
	[Register("fm/feed/android/playersdk/LogLevel", DoNotGenerateAcw = true)]
	public sealed class LogLevel : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/LogLevel", typeof(LogLevel));

		[Register("ASSERT")]
		public static LogLevel Assert => Java.Lang.Object.GetObject<LogLevel>(_members.StaticFields.GetObjectValue("ASSERT.Lfm/feed/android/playersdk/LogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DEBUG")]
		public static LogLevel Debug => Java.Lang.Object.GetObject<LogLevel>(_members.StaticFields.GetObjectValue("DEBUG.Lfm/feed/android/playersdk/LogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ERROR")]
		public static LogLevel Error => Java.Lang.Object.GetObject<LogLevel>(_members.StaticFields.GetObjectValue("ERROR.Lfm/feed/android/playersdk/LogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INFO")]
		public static LogLevel Info => Java.Lang.Object.GetObject<LogLevel>(_members.StaticFields.GetObjectValue("INFO.Lfm/feed/android/playersdk/LogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NONE")]
		public static LogLevel None => Java.Lang.Object.GetObject<LogLevel>(_members.StaticFields.GetObjectValue("NONE.Lfm/feed/android/playersdk/LogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("VERBOSE")]
		public static LogLevel Verbose => Java.Lang.Object.GetObject<LogLevel>(_members.StaticFields.GetObjectValue("VERBOSE.Lfm/feed/android/playersdk/LogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("WARN")]
		public static LogLevel Warn => Java.Lang.Object.GetObject<LogLevel>(_members.StaticFields.GetObjectValue("WARN.Lfm/feed/android/playersdk/LogLevel;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal LogLevel(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lfm/feed/android/playersdk/LogLevel;", "")]
		public unsafe static LogLevel ValueOf(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LogLevel>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lfm/feed/android/playersdk/LogLevel;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lfm/feed/android/playersdk/LogLevel;", "")]
		public unsafe static LogLevel[] Values()
		{
			return (LogLevel[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lfm/feed/android/playersdk/LogLevel;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(LogLevel));
		}
	}
	[Register("fm/feed/android/playersdk/MockLocations", DoNotGenerateAcw = true)]
	public sealed class MockLocations : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/MockLocations", typeof(MockLocations));

		[Register("EU")]
		public static MockLocations Eu => Java.Lang.Object.GetObject<MockLocations>(_members.StaticFields.GetObjectValue("EU.Lfm/feed/android/playersdk/MockLocations;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("US")]
		public static MockLocations Us => Java.Lang.Object.GetObject<MockLocations>(_members.StaticFields.GetObjectValue("US.Lfm/feed/android/playersdk/MockLocations;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal MockLocations(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lfm/feed/android/playersdk/MockLocations;", "")]
		public unsafe static MockLocations ValueOf(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<MockLocations>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lfm/feed/android/playersdk/MockLocations;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lfm/feed/android/playersdk/MockLocations;", "")]
		public unsafe static MockLocations[] Values()
		{
			return (MockLocations[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lfm/feed/android/playersdk/MockLocations;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(MockLocations));
		}
	}
	[Register("fm/feed/android/playersdk/PlayerError", DoNotGenerateAcw = true)]
	public sealed class PlayerError : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/PlayerError", typeof(PlayerError));

		[Register("INVALID_CREDENTIALS")]
		public static PlayerError InvalidCredentials => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("INVALID_CREDENTIALS.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INVALID_SERVER_RESPONSE")]
		public static PlayerError InvalidServerResponse => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("INVALID_SERVER_RESPONSE.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NO_NETWORK")]
		public static PlayerError NoNetwork => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("NO_NETWORK.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RETROFIT_NULL_REQ_FAIL")]
		public static PlayerError RetrofitNullReqFail => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("RETROFIT_NULL_REQ_FAIL.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RETROFIT_NULL_REQ_SUCCESS")]
		public static PlayerError RetrofitNullReqSuccess => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("RETROFIT_NULL_REQ_SUCCESS.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RETROFIT_UNKNOWN")]
		public static PlayerError RetrofitUnknown => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("RETROFIT_UNKNOWN.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RUNTIME_ERROR")]
		public static PlayerError RuntimeError => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("RUNTIME_ERROR.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TUNE_IO_EXCEPTION")]
		public static PlayerError TuneIoException => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("TUNE_IO_EXCEPTION.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TUNE_MEDIA_PLAYER_ILLEGAL_STATE")]
		public static PlayerError TuneMediaPlayerIllegalState => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("TUNE_MEDIA_PLAYER_ILLEGAL_STATE.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TUNE_UNKNOWN")]
		public static PlayerError TuneUnknown => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("TUNE_UNKNOWN.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNKNOWN")]
		public static PlayerError Unknown => Java.Lang.Object.GetObject<PlayerError>(_members.StaticFields.GetObjectValue("UNKNOWN.Lfm/feed/android/playersdk/PlayerError;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int Code
		{
			[Register("getCode", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getCode.()I", this, null);
			}
		}

		public unsafe string Message
		{
			[Register("getMessage", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal PlayerError(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lfm/feed/android/playersdk/PlayerError;", "")]
		public unsafe static PlayerError ValueOf(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<PlayerError>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lfm/feed/android/playersdk/PlayerError;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lfm/feed/android/playersdk/PlayerError;", "")]
		public unsafe static PlayerError[] Values()
		{
			return (PlayerError[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lfm/feed/android/playersdk/PlayerError;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(PlayerError));
		}
	}
	[Register("fm/feed/android/playersdk/PlayerProxy", DoNotGenerateAcw = true)]
	public sealed class PlayerProxy : Java.Lang.Object, IPlayerEventListener, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("fm/feed/android/playersdk/PlayerProxy$ExoEventListener", "", "FM.Feed.Android.Playersdk.PlayerProxy/IExoEventListenerInvoker")]
		public interface IExoEventListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onLoadingChanged", "(Z)V", "GetOnLoadingChanged_ZHandler:FM.Feed.Android.Playersdk.PlayerProxy/IExoEventListenerInvoker, iFit.Feed.FM.Android")]
			void OnLoadingChanged(bool isLoading);

			[Register("onPlayerError", "(Lcom/google/android/exoplayer2/ExoPlaybackException;)V", "GetOnPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_Handler:FM.Feed.Android.Playersdk.PlayerProxy/IExoEventListenerInvoker, iFit.Feed.FM.Android")]
			void OnPlayerError(ExoPlaybackException error);

			[Register("onPlayerStateChanged", "(ZI)V", "GetOnPlayerStateChanged_ZIHandler:FM.Feed.Android.Playersdk.PlayerProxy/IExoEventListenerInvoker, iFit.Feed.FM.Android")]
			void OnPlayerStateChanged(bool playWhenReady, int playbackState);

			[Register("onSeekProcessed", "()V", "GetOnSeekProcessedHandler:FM.Feed.Android.Playersdk.PlayerProxy/IExoEventListenerInvoker, iFit.Feed.FM.Android")]
			void OnSeekProcessed();
		}

		[Register("fm/feed/android/playersdk/PlayerProxy$ExoEventListener", DoNotGenerateAcw = true)]
		internal class IExoEventListenerInvoker : Java.Lang.Object, IExoEventListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/PlayerProxy$ExoEventListener", typeof(IExoEventListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onLoadingChanged_Z;

			private IntPtr id_onLoadingChanged_Z;

			private static Delegate cb_onPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_;

			private IntPtr id_onPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_;

			private static Delegate cb_onPlayerStateChanged_ZI;

			private IntPtr id_onPlayerStateChanged_ZI;

			private static Delegate cb_onSeekProcessed;

			private IntPtr id_onSeekProcessed;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IExoEventListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IExoEventListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.PlayerProxy.ExoEventListener'.");
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

			public IExoEventListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnLoadingChanged_ZHandler()
			{
				if ((object)cb_onLoadingChanged_Z == null)
				{
					cb_onLoadingChanged_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnLoadingChanged_Z));
				}
				return cb_onLoadingChanged_Z;
			}

			private static void n_OnLoadingChanged_Z(IntPtr jnienv, IntPtr native__this, bool isLoading)
			{
				IExoEventListener exoEventListener = Java.Lang.Object.GetObject<IExoEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				exoEventListener.OnLoadingChanged(isLoading);
			}

			public unsafe void OnLoadingChanged(bool isLoading)
			{
				if (id_onLoadingChanged_Z == IntPtr.Zero)
				{
					id_onLoadingChanged_Z = JNIEnv.GetMethodID(class_ref, "onLoadingChanged", "(Z)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(isLoading);
				JNIEnv.CallVoidMethod(base.Handle, id_onLoadingChanged_Z, ptr);
			}

			private static Delegate GetOnPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_Handler()
			{
				if ((object)cb_onPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_ == null)
				{
					cb_onPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_));
				}
				return cb_onPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_;
			}

			private static void n_OnPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_(IntPtr jnienv, IntPtr native__this, IntPtr native_error)
			{
				IExoEventListener exoEventListener = Java.Lang.Object.GetObject<IExoEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ExoPlaybackException error = Java.Lang.Object.GetObject<ExoPlaybackException>(native_error, JniHandleOwnership.DoNotTransfer);
				exoEventListener.OnPlayerError(error);
			}

			public unsafe void OnPlayerError(ExoPlaybackException error)
			{
				if (id_onPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_ == IntPtr.Zero)
				{
					id_onPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_ = JNIEnv.GetMethodID(class_ref, "onPlayerError", "(Lcom/google/android/exoplayer2/ExoPlaybackException;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(error?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_, ptr);
			}

			private static Delegate GetOnPlayerStateChanged_ZIHandler()
			{
				if ((object)cb_onPlayerStateChanged_ZI == null)
				{
					cb_onPlayerStateChanged_ZI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZI_V(n_OnPlayerStateChanged_ZI));
				}
				return cb_onPlayerStateChanged_ZI;
			}

			private static void n_OnPlayerStateChanged_ZI(IntPtr jnienv, IntPtr native__this, bool playWhenReady, int playbackState)
			{
				IExoEventListener exoEventListener = Java.Lang.Object.GetObject<IExoEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				exoEventListener.OnPlayerStateChanged(playWhenReady, playbackState);
			}

			public unsafe void OnPlayerStateChanged(bool playWhenReady, int playbackState)
			{
				if (id_onPlayerStateChanged_ZI == IntPtr.Zero)
				{
					id_onPlayerStateChanged_ZI = JNIEnv.GetMethodID(class_ref, "onPlayerStateChanged", "(ZI)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(playWhenReady);
				ptr[1] = new JValue(playbackState);
				JNIEnv.CallVoidMethod(base.Handle, id_onPlayerStateChanged_ZI, ptr);
			}

			private static Delegate GetOnSeekProcessedHandler()
			{
				if ((object)cb_onSeekProcessed == null)
				{
					cb_onSeekProcessed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnSeekProcessed));
				}
				return cb_onSeekProcessed;
			}

			private static void n_OnSeekProcessed(IntPtr jnienv, IntPtr native__this)
			{
				IExoEventListener exoEventListener = Java.Lang.Object.GetObject<IExoEventListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				exoEventListener.OnSeekProcessed();
			}

			public void OnSeekProcessed()
			{
				if (id_onSeekProcessed == IntPtr.Zero)
				{
					id_onSeekProcessed = JNIEnv.GetMethodID(class_ref, "onSeekProcessed", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onSeekProcessed);
			}
		}

		[Register("mono/fm/feed/android/playersdk/PlayerProxy_ExoEventListenerImplementor")]
		internal sealed class IExoEventListenerImplementor : Java.Lang.Object, IExoEventListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public IExoEventListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/PlayerProxy_ExoEventListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnLoadingChanged(bool isLoading)
			{
			}

			public void OnPlayerError(ExoPlaybackException error)
			{
			}

			public void OnPlayerStateChanged(bool playWhenReady, int playbackState)
			{
			}

			public void OnSeekProcessed()
			{
			}

			internal static bool __IsEmpty(IExoEventListenerImplementor value)
			{
				return true;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/PlayerProxy", typeof(PlayerProxy));

		private WeakReference weak_implementor___SetEventListener;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe IExoEventListener EventListener
		{
			[Register("getEventListener", "()Lfm/feed/android/playersdk/PlayerProxy$ExoEventListener;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IExoEventListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getEventListener.()Lfm/feed/android/playersdk/PlayerProxy$ExoEventListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setEventListener", "(Lfm/feed/android/playersdk/PlayerProxy$ExoEventListener;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setEventListener.(Lfm/feed/android/playersdk/PlayerProxy$ExoEventListener;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe IPlayerEventListener ExoListener
		{
			[Register("getExoListener", "()Lcom/google/android/exoplayer2/Player$EventListener;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IPlayerEventListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getExoListener.()Lcom/google/android/exoplayer2/Player$EventListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal PlayerProxy(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lfm/feed/android/playersdk/PlayerProxy$ExoEventListener;)V", "")]
		public unsafe PlayerProxy(IExoEventListener nListener)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((nListener == null) ? IntPtr.Zero : ((Java.Lang.Object)nListener).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lfm/feed/android/playersdk/PlayerProxy$ExoEventListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lfm/feed/android/playersdk/PlayerProxy$ExoEventListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(nListener);
			}
		}

		[Register("onLoadingChanged", "(Z)V", "")]
		public unsafe void OnLoadingChanged(bool isLoading)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isLoading);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onLoadingChanged.(Z)V", this, ptr);
		}

		[Register("onPlaybackParametersChanged", "(Lcom/google/android/exoplayer2/PlaybackParameters;)V", "")]
		public unsafe void OnPlaybackParametersChanged(PlaybackParameters playbackParameters)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(playbackParameters?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onPlaybackParametersChanged.(Lcom/google/android/exoplayer2/PlaybackParameters;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(playbackParameters);
			}
		}

		[Register("onPlayerError", "(Lcom/google/android/exoplayer2/ExoPlaybackException;)V", "")]
		public unsafe void OnPlayerError(ExoPlaybackException error)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(error?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onPlayerError.(Lcom/google/android/exoplayer2/ExoPlaybackException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(error);
			}
		}

		[Register("onPlayerStateChanged", "(ZI)V", "")]
		public unsafe void OnPlayerStateChanged(bool playWhenReady, [GeneratedEnum] PlaybackState playbackState)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(playWhenReady);
			ptr[1] = new JniArgumentValue((int)playbackState);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onPlayerStateChanged.(ZI)V", this, ptr);
		}

		[Register("onPositionDiscontinuity", "(I)V", "")]
		public unsafe void OnPositionDiscontinuity([GeneratedEnum] DiscontinuityReason reason)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)reason);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onPositionDiscontinuity.(I)V", this, ptr);
		}

		[Register("onRepeatModeChanged", "(I)V", "")]
		public unsafe void OnRepeatModeChanged([GeneratedEnum] RepeatMode repeatMode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)repeatMode);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onRepeatModeChanged.(I)V", this, ptr);
		}

		[Register("onSeekProcessed", "()V", "")]
		public unsafe void OnSeekProcessed()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("onSeekProcessed.()V", this, null);
		}

		[Register("onShuffleModeEnabledChanged", "(Z)V", "")]
		public unsafe void OnShuffleModeEnabledChanged(bool shuffleModeEnabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(shuffleModeEnabled);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onShuffleModeEnabledChanged.(Z)V", this, ptr);
		}

		[Register("onTracksChanged", "(Lcom/google/android/exoplayer2/source/TrackGroupArray;Lcom/google/android/exoplayer2/trackselection/TrackSelectionArray;)V", "")]
		public unsafe void OnTracksChanged(TrackGroupArray trackGroups, TrackSelectionArray trackSelections)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(trackGroups?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(trackSelections?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onTracksChanged.(Lcom/google/android/exoplayer2/source/TrackGroupArray;Lcom/google/android/exoplayer2/trackselection/TrackSelectionArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(trackGroups);
				GC.KeepAlive(trackSelections);
			}
		}

		private IExoEventListenerImplementor __CreateIExoEventListenerImplementor()
		{
			return new IExoEventListenerImplementor(this);
		}
	}
	[Register("fm/feed/android/playersdk/SimulcastPlaybackState", DoNotGenerateAcw = true)]
	public sealed class SimulcastPlaybackState : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/SimulcastPlaybackState", typeof(SimulcastPlaybackState));

		[Register("Available")]
		public static SimulcastPlaybackState Available => Java.Lang.Object.GetObject<SimulcastPlaybackState>(_members.StaticFields.GetObjectValue("Available.Lfm/feed/android/playersdk/SimulcastPlaybackState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Idle")]
		public static SimulcastPlaybackState Idle => Java.Lang.Object.GetObject<SimulcastPlaybackState>(_members.StaticFields.GetObjectValue("Idle.Lfm/feed/android/playersdk/SimulcastPlaybackState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Playing")]
		public static SimulcastPlaybackState Playing => Java.Lang.Object.GetObject<SimulcastPlaybackState>(_members.StaticFields.GetObjectValue("Playing.Lfm/feed/android/playersdk/SimulcastPlaybackState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Stalled")]
		public static SimulcastPlaybackState Stalled => Java.Lang.Object.GetObject<SimulcastPlaybackState>(_members.StaticFields.GetObjectValue("Stalled.Lfm/feed/android/playersdk/SimulcastPlaybackState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Stopped")]
		public static SimulcastPlaybackState Stopped => Java.Lang.Object.GetObject<SimulcastPlaybackState>(_members.StaticFields.GetObjectValue("Stopped.Lfm/feed/android/playersdk/SimulcastPlaybackState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Unavailable")]
		public static SimulcastPlaybackState Unavailable => Java.Lang.Object.GetObject<SimulcastPlaybackState>(_members.StaticFields.GetObjectValue("Unavailable.Lfm/feed/android/playersdk/SimulcastPlaybackState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Unintialized")]
		public static SimulcastPlaybackState Unintialized => Java.Lang.Object.GetObject<SimulcastPlaybackState>(_members.StaticFields.GetObjectValue("Unintialized.Lfm/feed/android/playersdk/SimulcastPlaybackState;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal SimulcastPlaybackState(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lfm/feed/android/playersdk/SimulcastPlaybackState;", "")]
		public unsafe static SimulcastPlaybackState ValueOf(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SimulcastPlaybackState>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lfm/feed/android/playersdk/SimulcastPlaybackState;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lfm/feed/android/playersdk/SimulcastPlaybackState;", "")]
		public unsafe static SimulcastPlaybackState[] Values()
		{
			return (SimulcastPlaybackState[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lfm/feed/android/playersdk/SimulcastPlaybackState;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(SimulcastPlaybackState));
		}
	}
	[Register("fm/feed/android/playersdk/State", DoNotGenerateAcw = true)]
	public sealed class State : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/State", typeof(State));

		[Register("AVAILABLE_OFFLINE_ONLY")]
		public static State AvailableOfflineOnly => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("AVAILABLE_OFFLINE_ONLY.Lfm/feed/android/playersdk/State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PAUSED")]
		public static State Paused => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("PAUSED.Lfm/feed/android/playersdk/State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PLAYING")]
		public static State Playing => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("PLAYING.Lfm/feed/android/playersdk/State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("READY_TO_PLAY")]
		public static State ReadyToPlay => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("READY_TO_PLAY.Lfm/feed/android/playersdk/State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STALLED")]
		public static State Stalled => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("STALLED.Lfm/feed/android/playersdk/State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNAVAILABLE")]
		public static State Unavailable => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("UNAVAILABLE.Lfm/feed/android/playersdk/State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNINITIALIZED")]
		public static State Uninitialized => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("UNINITIALIZED.Lfm/feed/android/playersdk/State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("WAITING_FOR_ITEM")]
		public static State WaitingForItem => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("WAITING_FOR_ITEM.Lfm/feed/android/playersdk/State;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal State(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lfm/feed/android/playersdk/State;", "")]
		public unsafe static State ValueOf(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<State>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lfm/feed/android/playersdk/State;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lfm/feed/android/playersdk/State;", "")]
		public unsafe static State[] Values()
		{
			return (State[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lfm/feed/android/playersdk/State;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(State));
		}
	}
}
namespace FM.Feed.Android.Playersdk.Models
{
	[Register("fm/feed/android/playersdk/models/Artist", DoNotGenerateAcw = true)]
	public sealed class Artist : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/Artist", typeof(Artist));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Integer Id
		{
			[Register("getId", "()Ljava/lang/Integer;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getId.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Name
		{
			[Register("getName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setName", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setName.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		internal Artist(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Integer;)V", "")]
		public unsafe Artist(Integer id)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Integer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Integer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(id);
			}
		}
	}
	[Register("fm/feed/android/playersdk/models/AudioFile", DoNotGenerateAcw = true)]
	public sealed class AudioFile : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/AudioFile", typeof(AudioFile));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Artist Artist
		{
			[Register("getArtist", "()Lfm/feed/android/playersdk/models/Artist;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Artist>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getArtist.()Lfm/feed/android/playersdk/models/Artist;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setArtist", "(Lfm/feed/android/playersdk/models/Artist;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setArtist.(Lfm/feed/android/playersdk/models/Artist;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string Bitrate
		{
			[Register("getBitrate", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBitrate.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setBitrate", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setBitrate.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe bool CanCache
		{
			[Register("getCanCache", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getCanCache.()Z", this, null);
			}
		}

		public unsafe bool CanSeek
		{
			[Register("getCanSeek", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getCanSeek.()Z", this, null);
			}
		}

		public unsafe string Codec
		{
			[Register("getCodec", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCodec.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setCodec", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCodec.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe float DurationInSeconds
		{
			[Register("getDurationInSeconds", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getDurationInSeconds.()F", this, null);
			}
			[Register("setDurationInSeconds", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDurationInSeconds.(F)V", this, ptr);
			}
		}

		public unsafe float EndTrim
		{
			[Register("getEndTrim", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getEndTrim.()F", this, null);
			}
		}

		public unsafe string Id
		{
			[Register("getId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsDisliked
		{
			[Register("isDisliked", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isDisliked.()Z", this, null);
			}
		}

		public unsafe bool IsLiked
		{
			[Register("isLiked", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isLiked.()Z", this, null);
			}
		}

		public unsafe IDictionary<string, Java.Lang.Object> Metadata
		{
			[Register("getMetadata", "()Ljava/util/Map;", "")]
			get
			{
				return JavaDictionary<string, Java.Lang.Object>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getMetadata.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setMetadata", "(Ljava/util/Map;)V", "")]
			set
			{
				IntPtr intPtr = JavaDictionary<string, Java.Lang.Object>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMetadata.(Ljava/util/Map;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Release Release
		{
			[Register("getRelease", "()Lfm/feed/android/playersdk/models/Release;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Release>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getRelease.()Lfm/feed/android/playersdk/models/Release;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setRelease", "(Lfm/feed/android/playersdk/models/Release;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setRelease.(Lfm/feed/android/playersdk/models/Release;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe float ReplayGain
		{
			[Register("getReplayGain", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getReplayGain.()F", this, null);
			}
			[Register("setReplayGain", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setReplayGain.(F)V", this, ptr);
			}
		}

		public unsafe float StartTrim
		{
			[Register("getStartTrim", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getStartTrim.()F", this, null);
			}
			[Register("setStartTrim", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setStartTrim.(F)V", this, ptr);
			}
		}

		public unsafe Track Track
		{
			[Register("getTrack", "()Lfm/feed/android/playersdk/models/Track;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Track>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTrack.()Lfm/feed/android/playersdk/models/Track;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTrack", "(Lfm/feed/android/playersdk/models/Track;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setTrack.(Lfm/feed/android/playersdk/models/Track;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string Url
		{
			[Register("getUrl", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setUrl", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setUrl.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		internal AudioFile(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe AudioFile(string id)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setDisliked", "()V", "")]
		public unsafe void SetDisliked()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDisliked.()V", this, null);
		}

		[Register("setLiked", "()V", "")]
		public unsafe void SetLiked()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLiked.()V", this, null);
		}

		[Register("setUnliked", "()V", "")]
		public unsafe void SetUnliked()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setUnliked.()V", this, null);
		}
	}
	[Register("fm/feed/android/playersdk/models/CacheInfo", DoNotGenerateAcw = true)]
	public sealed class CacheInfo : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/CacheInfo", typeof(CacheInfo));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int CacheSize
		{
			[Register("getCacheSize", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getCacheSize.()I", this, null);
			}
			[Register("setCacheSize", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCacheSize.(I)V", this, ptr);
			}
		}

		public unsafe int FileSize
		{
			[Register("getFileSize", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getFileSize.()I", this, null);
			}
			[Register("setFileSize", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setFileSize.(I)V", this, ptr);
			}
		}

		public unsafe string Url
		{
			[Register("getUrl", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setUrl", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setUrl.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		internal CacheInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CacheInfo()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("fm/feed/android/playersdk/models/NotificationStyle", DoNotGenerateAcw = true)]
	public sealed class NotificationStyle : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/NotificationStyle", typeof(NotificationStyle));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe RemoteViews BigContentView
		{
			[Register("getBigContentView", "()Landroid/widget/RemoteViews;", "")]
			get
			{
				return Java.Lang.Object.GetObject<RemoteViews>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBigContentView.()Landroid/widget/RemoteViews;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe RemoteViews ContentView
		{
			[Register("getContentView", "()Landroid/widget/RemoteViews;", "")]
			get
			{
				return Java.Lang.Object.GetObject<RemoteViews>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContentView.()Landroid/widget/RemoteViews;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool HasBigContentView
		{
			[Register("hasBigContentView", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasBigContentView.()Z", this, null);
			}
		}

		public unsafe bool HasContentView
		{
			[Register("hasContentView", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasContentView.()Z", this, null);
			}
		}

		public unsafe int ThumbsDownIcon
		{
			[Register("getThumbsDownIcon", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getThumbsDownIcon.()I", this, null);
			}
		}

		public unsafe int ThumbsDownSelectedIcon
		{
			[Register("getThumbsDownSelectedIcon", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getThumbsDownSelectedIcon.()I", this, null);
			}
		}

		public unsafe int ThumbsUpIcon
		{
			[Register("getThumbsUpIcon", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getThumbsUpIcon.()I", this, null);
			}
		}

		public unsafe int ThumbsUpSelectedIcon
		{
			[Register("getThumbsUpSelectedIcon", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getThumbsUpSelectedIcon.()I", this, null);
			}
		}

		internal NotificationStyle(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NotificationStyle()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("setArtistTextId", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetArtistTextId(int artistTextId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(artistTextId);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setArtistTextId.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setBigContentView", "(Ljava/lang/String;I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetBigContentView(string packageName, int bigContentViewId)
		{
			IntPtr intPtr = JNIEnv.NewString(packageName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(bigContentViewId);
				return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setBigContentView.(Ljava/lang/String;I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setCancelButtonId", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetCancelButtonId(int cancelButtonId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cancelButtonId);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setCancelButtonId.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setCancelIcon", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetCancelIcon(int cancelIcon)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cancelIcon);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setCancelIcon.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setColor", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setColor.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setContentView", "(Ljava/lang/String;I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetContentView(string packageName, int contentViewId)
		{
			IntPtr intPtr = JNIEnv.NewString(packageName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(contentViewId);
				return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setContentView.(Ljava/lang/String;I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setDislikeButtonId", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetDislikeButtonId(int dislikeButtonId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dislikeButtonId);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setDislikeButtonId.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setLikeButtonId", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetLikeButtonId(int likeButtonId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(likeButtonId);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setLikeButtonId.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setMediaImageId", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetMediaImageId(int mediaImageId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mediaImageId);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setMediaImageId.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setPauseIcon", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetPauseIcon(int pauseIcon)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(pauseIcon);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setPauseIcon.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setPlayIcon", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetPlayIcon(int playIcon)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(playIcon);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setPlayIcon.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setPlayPauseButtonId", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetPlayPauseButtonId(int playPauseButtonId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(playPauseButtonId);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setPlayPauseButtonId.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setProgressId", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetProgressId(int progressId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(progressId);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setProgressId.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setReleaseTextId", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetReleaseTextId(int releaseTextId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(releaseTextId);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setReleaseTextId.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setSkipButtonId", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetSkipButtonId(int skipButtonId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(skipButtonId);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setSkipButtonId.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setSkipIcon", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetSkipIcon(int skipIcon)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(skipIcon);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setSkipIcon.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setSmallIcon", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetSmallIcon(int smallIcon)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(smallIcon);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setSmallIcon.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setThumbsDownIcons", "(II)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetThumbsDownIcons(int thumbsDownIcon, int thumbsDownSelectedIcon)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(thumbsDownIcon);
			ptr[1] = new JniArgumentValue(thumbsDownSelectedIcon);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setThumbsDownIcons.(II)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setThumbsUpIcons", "(II)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetThumbsUpIcons(int thumbsUpIcon, int thumbsUpSelectedIcon)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(thumbsUpIcon);
			ptr[1] = new JniArgumentValue(thumbsUpSelectedIcon);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setThumbsUpIcons.(II)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setTrackTextId", "(I)Lfm/feed/android/playersdk/models/NotificationStyle;", "")]
		public unsafe NotificationStyle SetTrackTextId(int trackTextId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(trackTextId);
			return Java.Lang.Object.GetObject<NotificationStyle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setTrackTextId.(I)Lfm/feed/android/playersdk/models/NotificationStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("fm/feed/android/playersdk/models/Play", DoNotGenerateAcw = true)]
	public sealed class Play : Java.Lang.Object
	{
		[Register("fm/feed/android/playersdk/models/Play$LikeState", DoNotGenerateAcw = true)]
		public sealed class LikeState : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/Play$LikeState", typeof(LikeState));

			[Register("DISLIKED")]
			public static LikeState Disliked => Java.Lang.Object.GetObject<LikeState>(_members.StaticFields.GetObjectValue("DISLIKED.Lfm/feed/android/playersdk/models/Play$LikeState;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("LIKED")]
			public static LikeState Liked => Java.Lang.Object.GetObject<LikeState>(_members.StaticFields.GetObjectValue("LIKED.Lfm/feed/android/playersdk/models/Play$LikeState;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NONE")]
			public static LikeState None => Java.Lang.Object.GetObject<LikeState>(_members.StaticFields.GetObjectValue("NONE.Lfm/feed/android/playersdk/models/Play$LikeState;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal LikeState(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lfm/feed/android/playersdk/models/Play$LikeState;", "")]
			public unsafe static LikeState ValueOf(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<LikeState>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lfm/feed/android/playersdk/models/Play$LikeState;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lfm/feed/android/playersdk/models/Play$LikeState;", "")]
			public unsafe static LikeState[] Values()
			{
				return (LikeState[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lfm/feed/android/playersdk/models/Play$LikeState;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(LikeState));
			}
		}

		[Register("fm/feed/android/playersdk/models/Play$WhenMappings", DoNotGenerateAcw = true)]
		public sealed class WhenMappings : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/Play$WhenMappings", typeof(WhenMappings));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal WhenMappings(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/Play", typeof(Play));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe AudioFile AudioFile
		{
			[Register("getAudioFile", "()Lfm/feed/android/playersdk/models/AudioFile;", "")]
			get
			{
				return Java.Lang.Object.GetObject<AudioFile>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAudioFile.()Lfm/feed/android/playersdk/models/AudioFile;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setAudioFile", "(Lfm/feed/android/playersdk/models/AudioFile;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setAudioFile.(Lfm/feed/android/playersdk/models/AudioFile;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe float ElapsedSeconds
		{
			[Register("getElapsedSeconds", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getElapsedSeconds.()F", this, null);
			}
			[Register("setElapsedSeconds", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setElapsedSeconds.(F)V", this, ptr);
			}
		}

		public unsafe string Id
		{
			[Register("getId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setId", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setId.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe Float Start
		{
			[Register("getStart", "()Ljava/lang/Float;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Float>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getStart.()Ljava/lang/Float;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setStart", "(Ljava/lang/Float;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setStart.(Ljava/lang/Float;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Station Station
		{
			[Register("getStation", "()Lfm/feed/android/playersdk/models/Station;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Station>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getStation.()Lfm/feed/android/playersdk/models/Station;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setStation", "(Lfm/feed/android/playersdk/models/Station;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setStation.(Lfm/feed/android/playersdk/models/Station;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		internal Play(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe Play(string id)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getLikeState", "()Lfm/feed/android/playersdk/models/Play$LikeState;", "")]
		public unsafe LikeState GetLikeState()
		{
			return Java.Lang.Object.GetObject<LikeState>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLikeState.()Lfm/feed/android/playersdk/models/Play$LikeState;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setLikeState", "(Lfm/feed/android/playersdk/models/Play$LikeState;)V", "")]
		public unsafe void SetLikeState(LikeState likeState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(likeState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLikeState.(Lfm/feed/android/playersdk/models/Play$LikeState;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(likeState);
			}
		}
	}
	[Register("fm/feed/android/playersdk/models/PlayList", DoNotGenerateAcw = true)]
	public sealed class PlayList : Java.Lang.Object
	{
		[Register("fm/feed/android/playersdk/models/PlayList$Editor", DoNotGenerateAcw = true)]
		public sealed class Editor : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/PlayList$Editor", typeof(Editor));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Editor(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lfm/feed/android/playersdk/models/PlayList;)V", "")]
			public unsafe Editor(PlayList __self)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				string constructorSignature = "(L" + JNIEnv.GetJniName(GetType().DeclaringType) + ";)V";
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(__self?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance(constructorSignature, GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance(constructorSignature, this, ptr);
				}
				finally
				{
					GC.KeepAlive(__self);
				}
			}

			[Register("addToPlayList", "(Lfm/feed/android/playersdk/models/AudioFile;)V", "")]
			public unsafe void AddToPlayList(AudioFile file)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("addToPlayList.(Lfm/feed/android/playersdk/models/AudioFile;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(file);
				}
			}

			[Register("addToPlayList", "(Ljava/util/List;)V", "")]
			public unsafe void AddToPlayList(IList<AudioFile> activePlayList)
			{
				IntPtr intPtr = JavaList<AudioFile>.ToLocalJniHandle(activePlayList);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("addToPlayList.(Ljava/util/List;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(activePlayList);
				}
			}

			[Register("clearPlayList", "()V", "")]
			public unsafe void ClearPlayList()
			{
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("clearPlayList.()V", this, null);
			}

			[Register("moveItemToIndex", "(Lfm/feed/android/playersdk/models/AudioFile;I)V", "")]
			public unsafe void MoveItemToIndex(AudioFile audioFile, int pos)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(audioFile?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(pos);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("moveItemToIndex.(Lfm/feed/android/playersdk/models/AudioFile;I)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(audioFile);
				}
			}

			[Register("removeFromPlaylist", "(Lfm/feed/android/playersdk/models/AudioFile;)V", "")]
			public unsafe void RemoveFromPlaylist(AudioFile audioFile)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(audioFile?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeFromPlaylist.(Lfm/feed/android/playersdk/models/AudioFile;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(audioFile);
				}
			}

			[Register("shufflePlaylist", "()V", "")]
			public unsafe void ShufflePlaylist()
			{
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("shufflePlaylist.()V", this, null);
			}

			[Register("viewCurrentPlayList", "()Ljava/util/List;", "")]
			public unsafe IList<AudioFile> ViewCurrentPlayList()
			{
				return JavaList<AudioFile>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("viewCurrentPlayList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("fm/feed/android/playersdk/models/PlayList$PlayListListener", "", "FM.Feed.Android.Playersdk.Models.PlayList/IPlayListListenerInvoker")]
		public interface IPlayListListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onPlaylistChanged", "()V", "GetOnPlaylistChangedHandler:FM.Feed.Android.Playersdk.Models.PlayList/IPlayListListenerInvoker, iFit.Feed.FM.Android")]
			void OnPlaylistChanged();
		}

		[Register("fm/feed/android/playersdk/models/PlayList$PlayListListener", DoNotGenerateAcw = true)]
		internal class IPlayListListenerInvoker : Java.Lang.Object, IPlayListListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/PlayList$PlayListListener", typeof(IPlayListListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onPlaylistChanged;

			private IntPtr id_onPlaylistChanged;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IPlayListListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IPlayListListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'fm.feed.android.playersdk.models.PlayList.PlayListListener'.");
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

			public IPlayListListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnPlaylistChangedHandler()
			{
				if ((object)cb_onPlaylistChanged == null)
				{
					cb_onPlaylistChanged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnPlaylistChanged));
				}
				return cb_onPlaylistChanged;
			}

			private static void n_OnPlaylistChanged(IntPtr jnienv, IntPtr native__this)
			{
				IPlayListListener playListListener = Java.Lang.Object.GetObject<IPlayListListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				playListListener.OnPlaylistChanged();
			}

			public void OnPlaylistChanged()
			{
				if (id_onPlaylistChanged == IntPtr.Zero)
				{
					id_onPlaylistChanged = JNIEnv.GetMethodID(class_ref, "onPlaylistChanged", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onPlaylistChanged);
			}
		}

		[Register("mono/fm/feed/android/playersdk/models/PlayList_PlayListListenerImplementor")]
		internal sealed class IPlayListListenerImplementor : Java.Lang.Object, IPlayListListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public IPlayListListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/fm/feed/android/playersdk/models/PlayList_PlayListListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnPlaylistChanged()
			{
			}

			internal static bool __IsEmpty(IPlayListListenerImplementor value)
			{
				return true;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/PlayList", typeof(PlayList));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string Description
		{
			[Register("getDescription", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDescription", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDescription.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe string Id
		{
			[Register("getId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setId", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setId.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe bool IsEmpty
		{
			[Register("isEmpty", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isEmpty.()Z", this, null);
			}
		}

		public unsafe bool IsNotEmpty
		{
			[Register("isNotEmpty", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isNotEmpty.()Z", this, null);
			}
		}

		public unsafe IPlayListListener Listener
		{
			[Register("getListener", "()Lfm/feed/android/playersdk/models/PlayList$PlayListListener;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IPlayListListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getListener.()Lfm/feed/android/playersdk/models/PlayList$PlayListListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setListener", "(Lfm/feed/android/playersdk/models/PlayList$PlayListListener;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setListener.(Lfm/feed/android/playersdk/models/PlayList$PlayListListener;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string Name
		{
			[Register("getName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setName", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setName.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		internal PlayList(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PlayList()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("first", "()Lfm/feed/android/playersdk/models/AudioFile;", "")]
		public unsafe AudioFile First()
		{
			return Java.Lang.Object.GetObject<AudioFile>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("first.()Lfm/feed/android/playersdk/models/AudioFile;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("toList", "()Ljava/util/List;", "")]
		public unsafe IList<AudioFile> ToList()
		{
			return JavaList<AudioFile>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("fm/feed/android/playersdk/models/Release", DoNotGenerateAcw = true)]
	public sealed class Release : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/Release", typeof(Release));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Integer Id
		{
			[Register("getId", "()Ljava/lang/Integer;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getId.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTitle", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setTitle.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		internal Release(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Integer;)V", "")]
		public unsafe Release(Integer id)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Integer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Integer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(id);
			}
		}
	}
	[Register("fm/feed/android/playersdk/models/Session", DoNotGenerateAcw = true)]
	public sealed class Session : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/Session", typeof(Session));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string ClientId
		{
			[Register("getClientId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getClientId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setClientId", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setClientId.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe bool IsAvailable
		{
			[Register("isAvailable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isAvailable.()Z", this, null);
			}
		}

		public unsafe bool LogEverything
		{
			[Register("getLogEverything", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getLogEverything.()Z", this, null);
			}
			[Register("setLogEverything", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLogEverything.(Z)V", this, ptr);
			}
		}

		public unsafe bool LoggingEnabled
		{
			[Register("getLoggingEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getLoggingEnabled.()Z", this, null);
			}
			[Register("setLoggingEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLoggingEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe string Message
		{
			[Register("getMessage", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setMessage", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMessage.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		internal Session(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Session()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("fm/feed/android/playersdk/models/Station", DoNotGenerateAcw = true)]
	public sealed class Station : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/Station", typeof(Station));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe IList<AudioFile> AudioFiles
		{
			[Register("getAudioFiles", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<AudioFile>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAudioFiles.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setAudioFiles", "(Ljava/util/List;)V", "")]
			set
			{
				IntPtr intPtr = JavaList<AudioFile>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setAudioFiles.(Ljava/util/List;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string CastUrl
		{
			[Register("getCastUrl", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCastUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setCastUrl", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCastUrl.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe Date Expiry
		{
			[Register("getExpiry", "()Ljava/util/Date;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getExpiry.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setExpiry", "(Ljava/util/Date;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setExpiry.(Ljava/util/Date;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe bool HasNewMusic
		{
			[Register("hasNewMusic", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasNewMusic.()Z", this, null);
			}
		}

		public unsafe Integer Id
		{
			[Register("getId", "()Ljava/lang/Integer;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getId.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsOnDemand
		{
			[Register("isOnDemand", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isOnDemand.()Z", this, null);
			}
		}

		public unsafe bool IsTypeOffline
		{
			[Register("isTypeOffline", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isTypeOffline.()Z", this, null);
			}
		}

		public unsafe Date LastPlayStart
		{
			[Register("getLastPlayStart", "()Ljava/util/Date;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLastPlayStart.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLastPlayStart", "(Ljava/util/Date;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLastPlayStart.(Ljava/util/Date;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Date LastUpdated
		{
			[Register("getLastUpdated", "()Ljava/util/Date;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Date>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLastUpdated.()Ljava/util/Date;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Name
		{
			[Register("getName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setName", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setName.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe IDictionary<string, Java.Lang.Object> Options
		{
			[Register("getOptions", "()Ljava/util/Map;", "")]
			get
			{
				return JavaDictionary<string, Java.Lang.Object>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOptions.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float PreGain
		{
			[Register("getPreGain", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getPreGain.()F", this, null);
			}
			[Register("setPreGain", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPreGain.(F)V", this, ptr);
			}
		}

		internal Station(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Integer;)V", "")]
		public unsafe Station(Integer id)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Integer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Integer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(id);
			}
		}

		[Register("containsOption", "(Ljava/lang/String;)Z", "")]
		public unsafe bool ContainsOption(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("containsOption.(Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getOption", "(Ljava/lang/String;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object GetOption(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOption.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("isSinglePlay", "()Ljava/lang/Boolean;", "")]
		public unsafe Java.Lang.Boolean IsSinglePlay()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("isSinglePlay.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setOfflineType", "(Z)V", "")]
		public unsafe void SetOfflineType(bool flag)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(flag);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOfflineType.(Z)V", this, ptr);
		}

		[Register("setSinglePlay", "(Ljava/lang/Boolean;)V", "")]
		public unsafe void SetSinglePlay(Java.Lang.Boolean _set___)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(_set___?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setSinglePlay.(Ljava/lang/Boolean;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(_set___);
			}
		}
	}
	[Register("fm/feed/android/playersdk/models/StationList", DoNotGenerateAcw = true)]
	public class StationList : LinkedList
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/StationList", typeof(StationList));

		private static Delegate cb_contains_Lfm_feed_android_playersdk_models_Station_;

		private static Delegate cb_getSize;

		private static Delegate cb_indexOf_Lfm_feed_android_playersdk_models_Station_;

		private static Delegate cb_lastIndexOf_Lfm_feed_android_playersdk_models_Station_;

		private static Delegate cb_remove_Lfm_feed_android_playersdk_models_Station_;

		private static Delegate cb_removeAt_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected StationList(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe StationList()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetContains_Lfm_feed_android_playersdk_models_Station_Handler()
		{
			if ((object)cb_contains_Lfm_feed_android_playersdk_models_Station_ == null)
			{
				cb_contains_Lfm_feed_android_playersdk_models_Station_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Contains_Lfm_feed_android_playersdk_models_Station_));
			}
			return cb_contains_Lfm_feed_android_playersdk_models_Station_;
		}

		private static bool n_Contains_Lfm_feed_android_playersdk_models_Station_(IntPtr jnienv, IntPtr native__this, IntPtr native_element)
		{
			StationList stationList = Java.Lang.Object.GetObject<StationList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Station element = Java.Lang.Object.GetObject<Station>(native_element, JniHandleOwnership.DoNotTransfer);
			return stationList.Contains(element);
		}

		[Register("contains", "(Lfm/feed/android/playersdk/models/Station;)Z", "GetContains_Lfm_feed_android_playersdk_models_Station_Handler")]
		public unsafe virtual bool Contains(Station element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("contains.(Lfm/feed/android/playersdk/models/Station;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		[Register("contains", "(Ljava/lang/Object;)Z", "")]
		public unsafe sealed override bool Contains(Java.Lang.Object element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("contains.(Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		[Register("getAllStationsWithOption", "(Ljava/lang/String;)Lfm/feed/android/playersdk/models/StationList;", "")]
		public unsafe StationList GetAllStationsWithOption(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<StationList>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAllStationsWithOption.(Ljava/lang/String;)Lfm/feed/android/playersdk/models/StationList;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getAllStationsWithOption", "(Ljava/lang/String;Ljava/lang/Object;)Lfm/feed/android/playersdk/models/StationList;", "")]
		public unsafe StationList GetAllStationsWithOption(string key, Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<StationList>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAllStationsWithOption.(Ljava/lang/String;Ljava/lang/Object;)Lfm/feed/android/playersdk/models/StationList;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("getAllStationsWithOptions", "(Ljava/util/Map;)Lfm/feed/android/playersdk/models/StationList;", "")]
		public unsafe StationList GetAllStationsWithOptions(IDictionary<string, Java.Lang.Object> options)
		{
			IntPtr intPtr = JavaDictionary<string, Java.Lang.Object>.ToLocalJniHandle(options);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<StationList>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getAllStationsWithOptions.(Ljava/util/Map;)Lfm/feed/android/playersdk/models/StationList;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(options);
			}
		}

		private static Delegate GetGetSizeHandler()
		{
			if ((object)cb_getSize == null)
			{
				cb_getSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSize));
			}
			return cb_getSize;
		}

		private static int n_GetSize(IntPtr jnienv, IntPtr native__this)
		{
			StationList stationList = Java.Lang.Object.GetObject<StationList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return stationList.GetSize();
		}

		[Register("getSize", "()I", "GetGetSizeHandler")]
		public unsafe virtual int GetSize()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSize.()I", this, null);
		}

		[Register("getStationWithName", "(Ljava/lang/String;)Lfm/feed/android/playersdk/models/Station;", "")]
		public unsafe Station GetStationWithName(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Station>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getStationWithName.(Ljava/lang/String;)Lfm/feed/android/playersdk/models/Station;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getStationWithOption", "(Ljava/lang/String;)Lfm/feed/android/playersdk/models/Station;", "")]
		public unsafe Station GetStationWithOption(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Station>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getStationWithOption.(Ljava/lang/String;)Lfm/feed/android/playersdk/models/Station;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getStationWithOption", "(Ljava/lang/String;Ljava/lang/Object;)Lfm/feed/android/playersdk/models/Station;", "")]
		public unsafe Station GetStationWithOption(string key, Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Station>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getStationWithOption.(Ljava/lang/String;Ljava/lang/Object;)Lfm/feed/android/playersdk/models/Station;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("getStationWithOptions", "(Ljava/util/Map;)Lfm/feed/android/playersdk/models/Station;", "")]
		public unsafe Station GetStationWithOptions(IDictionary<string, Java.Lang.Object> options)
		{
			IntPtr intPtr = JavaDictionary<string, Java.Lang.Object>.ToLocalJniHandle(options);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Station>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getStationWithOptions.(Ljava/util/Map;)Lfm/feed/android/playersdk/models/Station;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(options);
			}
		}

		private static Delegate GetIndexOf_Lfm_feed_android_playersdk_models_Station_Handler()
		{
			if ((object)cb_indexOf_Lfm_feed_android_playersdk_models_Station_ == null)
			{
				cb_indexOf_Lfm_feed_android_playersdk_models_Station_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_IndexOf_Lfm_feed_android_playersdk_models_Station_));
			}
			return cb_indexOf_Lfm_feed_android_playersdk_models_Station_;
		}

		private static int n_IndexOf_Lfm_feed_android_playersdk_models_Station_(IntPtr jnienv, IntPtr native__this, IntPtr native_element)
		{
			StationList stationList = Java.Lang.Object.GetObject<StationList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Station element = Java.Lang.Object.GetObject<Station>(native_element, JniHandleOwnership.DoNotTransfer);
			return stationList.IndexOf(element);
		}

		[Register("indexOf", "(Lfm/feed/android/playersdk/models/Station;)I", "GetIndexOf_Lfm_feed_android_playersdk_models_Station_Handler")]
		public unsafe virtual int IndexOf(Station element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("indexOf.(Lfm/feed/android/playersdk/models/Station;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		[Register("indexOf", "(Ljava/lang/Object;)I", "")]
		public unsafe sealed override int IndexOf(Java.Lang.Object element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("indexOf.(Ljava/lang/Object;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		private static Delegate GetLastIndexOf_Lfm_feed_android_playersdk_models_Station_Handler()
		{
			if ((object)cb_lastIndexOf_Lfm_feed_android_playersdk_models_Station_ == null)
			{
				cb_lastIndexOf_Lfm_feed_android_playersdk_models_Station_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_LastIndexOf_Lfm_feed_android_playersdk_models_Station_));
			}
			return cb_lastIndexOf_Lfm_feed_android_playersdk_models_Station_;
		}

		private static int n_LastIndexOf_Lfm_feed_android_playersdk_models_Station_(IntPtr jnienv, IntPtr native__this, IntPtr native_element)
		{
			StationList stationList = Java.Lang.Object.GetObject<StationList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Station element = Java.Lang.Object.GetObject<Station>(native_element, JniHandleOwnership.DoNotTransfer);
			return stationList.LastIndexOf(element);
		}

		[Register("lastIndexOf", "(Lfm/feed/android/playersdk/models/Station;)I", "GetLastIndexOf_Lfm_feed_android_playersdk_models_Station_Handler")]
		public unsafe virtual int LastIndexOf(Station element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("lastIndexOf.(Lfm/feed/android/playersdk/models/Station;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		[Register("lastIndexOf", "(Ljava/lang/Object;)I", "")]
		public unsafe sealed override int LastIndexOf(Java.Lang.Object element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("lastIndexOf.(Ljava/lang/Object;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		private static Delegate GetRemove_Lfm_feed_android_playersdk_models_Station_Handler()
		{
			if ((object)cb_remove_Lfm_feed_android_playersdk_models_Station_ == null)
			{
				cb_remove_Lfm_feed_android_playersdk_models_Station_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Remove_Lfm_feed_android_playersdk_models_Station_));
			}
			return cb_remove_Lfm_feed_android_playersdk_models_Station_;
		}

		private static bool n_Remove_Lfm_feed_android_playersdk_models_Station_(IntPtr jnienv, IntPtr native__this, IntPtr native_element)
		{
			StationList stationList = Java.Lang.Object.GetObject<StationList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Station element = Java.Lang.Object.GetObject<Station>(native_element, JniHandleOwnership.DoNotTransfer);
			return stationList.Remove(element);
		}

		[Register("remove", "(Lfm/feed/android/playersdk/models/Station;)Z", "GetRemove_Lfm_feed_android_playersdk_models_Station_Handler")]
		public unsafe virtual bool Remove(Station element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("remove.(Lfm/feed/android/playersdk/models/Station;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		[Register("remove", "(I)Lfm/feed/android/playersdk/models/Station;", "")]
		public unsafe sealed override Java.Lang.Object Remove(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("remove.(I)Lfm/feed/android/playersdk/models/Station;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("remove", "(Ljava/lang/Object;)Z", "")]
		public unsafe sealed override bool Remove(Java.Lang.Object element)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("remove.(Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(element);
			}
		}

		private static Delegate GetRemoveAt_IHandler()
		{
			if ((object)cb_removeAt_I == null)
			{
				cb_removeAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_RemoveAt_I));
			}
			return cb_removeAt_I;
		}

		private static IntPtr n_RemoveAt_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			StationList stationList = Java.Lang.Object.GetObject<StationList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(stationList.RemoveAt(p0));
		}

		[Register("removeAt", "(I)Lfm/feed/android/playersdk/models/Station;", "GetRemoveAt_IHandler")]
		public unsafe virtual Station RemoveAt(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<Station>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeAt.(I)Lfm/feed/android/playersdk/models/Station;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("size", "()I", "")]
		public unsafe sealed override int Size()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("size.()I", this, null);
		}
	}
	[Register("fm/feed/android/playersdk/models/Track", DoNotGenerateAcw = true)]
	public sealed class Track : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/Track", typeof(Track));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Integer Id
		{
			[Register("getId", "()Ljava/lang/Integer;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getId.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTitle", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setTitle.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		internal Track(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Integer;)V", "")]
		public unsafe Track(Integer id)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Integer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Integer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(id);
			}
		}
	}
}
namespace FM.Feed.Android.Playersdk.Models.Webservice
{
	[Register("fm/feed/android/playersdk/models/webservice/ClientResponse", DoNotGenerateAcw = true)]
	public class ClientResponse : FeedFMResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/ClientResponse", typeof(ClientResponse));

		private static Delegate cb_getClientId;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string ClientId
		{
			[Register("getClientId", "()Ljava/lang/String;", "GetGetClientIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getClientId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ClientResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ClientResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetClientIdHandler()
		{
			if ((object)cb_getClientId == null)
			{
				cb_getClientId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetClientId));
			}
			return cb_getClientId;
		}

		private static IntPtr n_GetClientId(IntPtr jnienv, IntPtr native__this)
		{
			ClientResponse clientResponse = Java.Lang.Object.GetObject<ClientResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(clientResponse.ClientId);
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/FeedFMConnectivityError", DoNotGenerateAcw = true)]
	public class FeedFMConnectivityError : FeedFMError
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/FeedFMConnectivityError", typeof(FeedFMConnectivityError));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected FeedFMConnectivityError(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FeedFMConnectivityError()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/FeedFMError", DoNotGenerateAcw = true)]
	public class FeedFMError : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/FeedFMError", typeof(FeedFMError));

		private static Delegate cb_getApiError;

		private static Delegate cb_getCode;

		private static Delegate cb_setCode_I;

		private static Delegate cb_isApiError;

		private static Delegate cb_isPlayerError;

		private static Delegate cb_getPlayerError;

		private static Delegate cb_getStatus;

		private static Delegate cb_setStatus_I;

		private static Delegate cb_getType;

		private static Delegate cb_setMessage_Ljava_lang_String_;

		private static Delegate cb_toString;

		private static Delegate cb_updateErrorType;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual Java.Lang.Enum ApiError
		{
			[Register("getApiError", "()Ljava/lang/Enum;", "GetGetApiErrorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Enum>(_members.InstanceMethods.InvokeVirtualObjectMethod("getApiError.()Ljava/lang/Enum;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int Code
		{
			[Register("getCode", "()I", "GetGetCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getCode.()I", this, null);
			}
			[Register("setCode", "(I)V", "GetSetCode_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCode.(I)V", this, ptr);
			}
		}

		public unsafe virtual bool IsApiError
		{
			[Register("isApiError", "()Z", "GetIsApiErrorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isApiError.()Z", this, null);
			}
		}

		public unsafe virtual bool IsPlayerError
		{
			[Register("isPlayerError", "()Z", "GetIsPlayerErrorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPlayerError.()Z", this, null);
			}
		}

		public unsafe virtual PlayerError PlayerError
		{
			[Register("getPlayerError", "()Lfm/feed/android/playersdk/PlayerError;", "GetGetPlayerErrorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<PlayerError>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPlayerError.()Lfm/feed/android/playersdk/PlayerError;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int Status
		{
			[Register("getStatus", "()I", "GetGetStatusHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getStatus.()I", this, null);
			}
			[Register("setStatus", "(I)V", "GetSetStatus_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStatus.(I)V", this, ptr);
			}
		}

		public unsafe virtual Java.Lang.Enum Type
		{
			[Register("getType", "()Ljava/lang/Enum;", "GetGetTypeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Enum>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Ljava/lang/Enum;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected FeedFMError(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Enum;)V", "")]
		public unsafe FeedFMError(Java.Lang.Enum errorEnum)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(errorEnum?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Enum;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Enum;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(errorEnum);
			}
		}

		[Register(".ctor", "(Lfm/feed/android/playersdk/PlayerError;)V", "")]
		public unsafe FeedFMError(PlayerError errorEnum)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(errorEnum?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lfm/feed/android/playersdk/PlayerError;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lfm/feed/android/playersdk/PlayerError;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(errorEnum);
			}
		}

		[Register(".ctor", "(ILjava/lang/String;I)V", "")]
		public unsafe FeedFMError(int code, string message, int status)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(code);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(status);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/lang/String;I)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILjava/lang/String;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetApiErrorHandler()
		{
			if ((object)cb_getApiError == null)
			{
				cb_getApiError = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetApiError));
			}
			return cb_getApiError;
		}

		private static IntPtr n_GetApiError(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(feedFMError.ApiError);
		}

		private static Delegate GetGetCodeHandler()
		{
			if ((object)cb_getCode == null)
			{
				cb_getCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCode));
			}
			return cb_getCode;
		}

		private static int n_GetCode(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return feedFMError.Code;
		}

		private static Delegate GetSetCode_IHandler()
		{
			if ((object)cb_setCode_I == null)
			{
				cb_setCode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetCode_I));
			}
			return cb_setCode_I;
		}

		private static void n_SetCode_I(IntPtr jnienv, IntPtr native__this, int code)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			feedFMError.Code = code;
		}

		private static Delegate GetIsApiErrorHandler()
		{
			if ((object)cb_isApiError == null)
			{
				cb_isApiError = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsApiError));
			}
			return cb_isApiError;
		}

		private static bool n_IsApiError(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return feedFMError.IsApiError;
		}

		private static Delegate GetIsPlayerErrorHandler()
		{
			if ((object)cb_isPlayerError == null)
			{
				cb_isPlayerError = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPlayerError));
			}
			return cb_isPlayerError;
		}

		private static bool n_IsPlayerError(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return feedFMError.IsPlayerError;
		}

		private static Delegate GetGetPlayerErrorHandler()
		{
			if ((object)cb_getPlayerError == null)
			{
				cb_getPlayerError = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPlayerError));
			}
			return cb_getPlayerError;
		}

		private static IntPtr n_GetPlayerError(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(feedFMError.PlayerError);
		}

		private static Delegate GetGetStatusHandler()
		{
			if ((object)cb_getStatus == null)
			{
				cb_getStatus = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetStatus));
			}
			return cb_getStatus;
		}

		private static int n_GetStatus(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return feedFMError.Status;
		}

		private static Delegate GetSetStatus_IHandler()
		{
			if ((object)cb_setStatus_I == null)
			{
				cb_setStatus_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetStatus_I));
			}
			return cb_setStatus_I;
		}

		private static void n_SetStatus_I(IntPtr jnienv, IntPtr native__this, int status)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			feedFMError.Status = status;
		}

		private static Delegate GetGetTypeHandler()
		{
			if ((object)cb_getType == null)
			{
				cb_getType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetType));
			}
			return cb_getType;
		}

		private static IntPtr n_GetType(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(feedFMError.Type);
		}

		private static Delegate GetSetMessage_Ljava_lang_String_Handler()
		{
			if ((object)cb_setMessage_Ljava_lang_String_ == null)
			{
				cb_setMessage_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetMessage_Ljava_lang_String_));
			}
			return cb_setMessage_Ljava_lang_String_;
		}

		private static void n_SetMessage_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_message)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string message = JNIEnv.GetString(native_message, JniHandleOwnership.DoNotTransfer);
			feedFMError.SetMessage(message);
		}

		[Register("setMessage", "(Ljava/lang/String;)V", "GetSetMessage_Ljava_lang_String_Handler")]
		public unsafe virtual void SetMessage(string message)
		{
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMessage.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetToStringHandler()
		{
			if ((object)cb_toString == null)
			{
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(feedFMError.ToString());
		}

		[Register("toString", "()Ljava/lang/String;", "GetToStringHandler")]
		public unsafe override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetUpdateErrorTypeHandler()
		{
			if ((object)cb_updateErrorType == null)
			{
				cb_updateErrorType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_UpdateErrorType));
			}
			return cb_updateErrorType;
		}

		private static void n_UpdateErrorType(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMError feedFMError = Java.Lang.Object.GetObject<FeedFMError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			feedFMError.UpdateErrorType();
		}

		[Register("updateErrorType", "()V", "GetUpdateErrorTypeHandler")]
		public unsafe virtual void UpdateErrorType()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateErrorType.()V", this, null);
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/FeedFMResponse", DoNotGenerateAcw = true)]
	public class FeedFMResponse : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/FeedFMResponse", typeof(FeedFMResponse));

		private static Delegate cb_getError;

		private static Delegate cb_isSuccess;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual FeedFMError Error
		{
			[Register("getError", "()Lfm/feed/android/playersdk/models/webservice/FeedFMError;", "GetGetErrorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<FeedFMError>(_members.InstanceMethods.InvokeVirtualObjectMethod("getError.()Lfm/feed/android/playersdk/models/webservice/FeedFMError;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsSuccess
		{
			[Register("isSuccess", "()Z", "GetIsSuccessHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSuccess.()Z", this, null);
			}
		}

		protected FeedFMResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FeedFMResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetErrorHandler()
		{
			if ((object)cb_getError == null)
			{
				cb_getError = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetError));
			}
			return cb_getError;
		}

		private static IntPtr n_GetError(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMResponse feedFMResponse = Java.Lang.Object.GetObject<FeedFMResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(feedFMResponse.Error);
		}

		private static Delegate GetIsSuccessHandler()
		{
			if ((object)cb_isSuccess == null)
			{
				cb_isSuccess = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSuccess));
			}
			return cb_isSuccess;
		}

		private static bool n_IsSuccess(IntPtr jnienv, IntPtr native__this)
		{
			FeedFMResponse feedFMResponse = Java.Lang.Object.GetObject<FeedFMResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return feedFMResponse.IsSuccess;
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/FeedFMUnkownRetrofitError", DoNotGenerateAcw = true)]
	public class FeedFMUnkownRetrofitError : FeedFMError
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/FeedFMUnkownRetrofitError", typeof(FeedFMUnkownRetrofitError));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected FeedFMUnkownRetrofitError(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FeedFMUnkownRetrofitError()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/PlacementResponse", DoNotGenerateAcw = true)]
	public class PlacementResponse : FeedFMResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/PlacementResponse", typeof(PlacementResponse));

		private static Delegate cb_getPlacement;

		private static Delegate cb_getStations;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual Java.Lang.Object Placement
		{
			[Register("getPlacement", "()Ljava/lang/Object;", "GetGetPlacementHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPlacement.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<Station> Stations
		{
			[Register("getStations", "()Ljava/util/List;", "GetGetStationsHandler")]
			get
			{
				return JavaList<Station>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getStations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected PlacementResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PlacementResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetPlacementHandler()
		{
			if ((object)cb_getPlacement == null)
			{
				cb_getPlacement = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPlacement));
			}
			return cb_getPlacement;
		}

		private static IntPtr n_GetPlacement(IntPtr jnienv, IntPtr native__this)
		{
			PlacementResponse placementResponse = Java.Lang.Object.GetObject<PlacementResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(placementResponse.Placement);
		}

		private static Delegate GetGetStationsHandler()
		{
			if ((object)cb_getStations == null)
			{
				cb_getStations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStations));
			}
			return cb_getStations;
		}

		private static IntPtr n_GetStations(IntPtr jnienv, IntPtr native__this)
		{
			PlacementResponse placementResponse = Java.Lang.Object.GetObject<PlacementResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<Station>.ToLocalJniHandle(placementResponse.Stations);
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/PlayResponse", DoNotGenerateAcw = true)]
	public class PlayResponse : FeedFMResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/PlayResponse", typeof(PlayResponse));

		private static Delegate cb_getPlay;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual Play Play
		{
			[Register("getPlay", "()Lfm/feed/android/playersdk/models/Play;", "GetGetPlayHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Play>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPlay.()Lfm/feed/android/playersdk/models/Play;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected PlayResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PlayResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetPlayHandler()
		{
			if ((object)cb_getPlay == null)
			{
				cb_getPlay = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPlay));
			}
			return cb_getPlay;
		}

		private static IntPtr n_GetPlay(IntPtr jnienv, IntPtr native__this)
		{
			PlayResponse playResponse = Java.Lang.Object.GetObject<PlayResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(playResponse.Play);
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/PlayStartResponse", DoNotGenerateAcw = true)]
	public class PlayStartResponse : FeedFMResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/PlayStartResponse", typeof(PlayStartResponse));

		private static Delegate cb_canSkip;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected PlayStartResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PlayStartResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCanSkipHandler()
		{
			if ((object)cb_canSkip == null)
			{
				cb_canSkip = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_CanSkip));
			}
			return cb_canSkip;
		}

		private static bool n_CanSkip(IntPtr jnienv, IntPtr native__this)
		{
			PlayStartResponse playStartResponse = Java.Lang.Object.GetObject<PlayStartResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return playStartResponse.CanSkip();
		}

		[Register("canSkip", "()Z", "GetCanSkipHandler")]
		public unsafe virtual bool CanSkip()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("canSkip.()Z", this, null);
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/PrepareCacheResponse", DoNotGenerateAcw = true)]
	public class PrepareCacheResponse : FeedFMResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/PrepareCacheResponse", typeof(PrepareCacheResponse));

		private static Delegate cb_getCacheInfoList;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<CacheInfo> CacheInfoList
		{
			[Register("getCacheInfoList", "()Ljava/util/List;", "GetGetCacheInfoListHandler")]
			get
			{
				return JavaList<CacheInfo>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getCacheInfoList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected PrepareCacheResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PrepareCacheResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetCacheInfoListHandler()
		{
			if ((object)cb_getCacheInfoList == null)
			{
				cb_getCacheInfoList = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCacheInfoList));
			}
			return cb_getCacheInfoList;
		}

		private static IntPtr n_GetCacheInfoList(IntPtr jnienv, IntPtr native__this)
		{
			PrepareCacheResponse prepareCacheResponse = Java.Lang.Object.GetObject<PrepareCacheResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<CacheInfo>.ToLocalJniHandle(prepareCacheResponse.CacheInfoList);
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/SessionResponse", DoNotGenerateAcw = true)]
	public class SessionResponse : FeedFMResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/SessionResponse", typeof(SessionResponse));

		private static Delegate cb_getOfflinePlacement;

		private static Delegate cb_getPlacement;

		private static Delegate cb_getRemoteOfflineStations;

		private static Delegate cb_getSession;

		private static Delegate cb_getStations;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual Java.Lang.Object OfflinePlacement
		{
			[Register("getOfflinePlacement", "()Ljava/lang/Object;", "GetGetOfflinePlacementHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOfflinePlacement.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Java.Lang.Object Placement
		{
			[Register("getPlacement", "()Ljava/lang/Object;", "GetGetPlacementHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPlacement.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<Station> RemoteOfflineStations
		{
			[Register("getRemoteOfflineStations", "()Ljava/util/List;", "GetGetRemoteOfflineStationsHandler")]
			get
			{
				return JavaList<Station>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getRemoteOfflineStations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Session Session
		{
			[Register("getSession", "()Lfm/feed/android/playersdk/models/Session;", "GetGetSessionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Session>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSession.()Lfm/feed/android/playersdk/models/Session;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<Station> Stations
		{
			[Register("getStations", "()Ljava/util/List;", "GetGetStationsHandler")]
			get
			{
				return JavaList<Station>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getStations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected SessionResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SessionResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetOfflinePlacementHandler()
		{
			if ((object)cb_getOfflinePlacement == null)
			{
				cb_getOfflinePlacement = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOfflinePlacement));
			}
			return cb_getOfflinePlacement;
		}

		private static IntPtr n_GetOfflinePlacement(IntPtr jnienv, IntPtr native__this)
		{
			SessionResponse sessionResponse = Java.Lang.Object.GetObject<SessionResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sessionResponse.OfflinePlacement);
		}

		private static Delegate GetGetPlacementHandler()
		{
			if ((object)cb_getPlacement == null)
			{
				cb_getPlacement = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPlacement));
			}
			return cb_getPlacement;
		}

		private static IntPtr n_GetPlacement(IntPtr jnienv, IntPtr native__this)
		{
			SessionResponse sessionResponse = Java.Lang.Object.GetObject<SessionResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sessionResponse.Placement);
		}

		private static Delegate GetGetRemoteOfflineStationsHandler()
		{
			if ((object)cb_getRemoteOfflineStations == null)
			{
				cb_getRemoteOfflineStations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRemoteOfflineStations));
			}
			return cb_getRemoteOfflineStations;
		}

		private static IntPtr n_GetRemoteOfflineStations(IntPtr jnienv, IntPtr native__this)
		{
			SessionResponse sessionResponse = Java.Lang.Object.GetObject<SessionResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<Station>.ToLocalJniHandle(sessionResponse.RemoteOfflineStations);
		}

		private static Delegate GetGetSessionHandler()
		{
			if ((object)cb_getSession == null)
			{
				cb_getSession = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSession));
			}
			return cb_getSession;
		}

		private static IntPtr n_GetSession(IntPtr jnienv, IntPtr native__this)
		{
			SessionResponse sessionResponse = Java.Lang.Object.GetObject<SessionResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sessionResponse.Session);
		}

		private static Delegate GetGetStationsHandler()
		{
			if ((object)cb_getStations == null)
			{
				cb_getStations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStations));
			}
			return cb_getStations;
		}

		private static IntPtr n_GetStations(IntPtr jnienv, IntPtr native__this)
		{
			SessionResponse sessionResponse = Java.Lang.Object.GetObject<SessionResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<Station>.ToLocalJniHandle(sessionResponse.Stations);
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/SimulcastConnectResponse", DoNotGenerateAcw = true)]
	public class SimulcastConnectResponse : FeedFMResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/SimulcastConnectResponse", typeof(SimulcastConnectResponse));

		private static Delegate cb_getClientId;

		private static Delegate cb_getMetadataUrl;

		private static Delegate cb_getStreamUrl;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string ClientId
		{
			[Register("getClientId", "()Ljava/lang/String;", "GetGetClientIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getClientId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string MetadataUrl
		{
			[Register("getMetadataUrl", "()Ljava/lang/String;", "GetGetMetadataUrlHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMetadataUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string StreamUrl
		{
			[Register("getStreamUrl", "()Ljava/lang/String;", "GetGetStreamUrlHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getStreamUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected SimulcastConnectResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SimulcastConnectResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetClientIdHandler()
		{
			if ((object)cb_getClientId == null)
			{
				cb_getClientId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetClientId));
			}
			return cb_getClientId;
		}

		private static IntPtr n_GetClientId(IntPtr jnienv, IntPtr native__this)
		{
			SimulcastConnectResponse simulcastConnectResponse = Java.Lang.Object.GetObject<SimulcastConnectResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(simulcastConnectResponse.ClientId);
		}

		private static Delegate GetGetMetadataUrlHandler()
		{
			if ((object)cb_getMetadataUrl == null)
			{
				cb_getMetadataUrl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMetadataUrl));
			}
			return cb_getMetadataUrl;
		}

		private static IntPtr n_GetMetadataUrl(IntPtr jnienv, IntPtr native__this)
		{
			SimulcastConnectResponse simulcastConnectResponse = Java.Lang.Object.GetObject<SimulcastConnectResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(simulcastConnectResponse.MetadataUrl);
		}

		private static Delegate GetGetStreamUrlHandler()
		{
			if ((object)cb_getStreamUrl == null)
			{
				cb_getStreamUrl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStreamUrl));
			}
			return cb_getStreamUrl;
		}

		private static IntPtr n_GetStreamUrl(IntPtr jnienv, IntPtr native__this)
		{
			SimulcastConnectResponse simulcastConnectResponse = Java.Lang.Object.GetObject<SimulcastConnectResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(simulcastConnectResponse.StreamUrl);
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/SimulcastPlayResponse", DoNotGenerateAcw = true)]
	public class SimulcastPlayResponse : FeedFMResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/SimulcastPlayResponse", typeof(SimulcastPlayResponse));

		private static Delegate cb_getElapsedSeconds;

		private static Delegate cb_getPlay;

		private static Delegate cb_getState;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual float ElapsedSeconds
		{
			[Register("getElapsedSeconds", "()F", "GetGetElapsedSecondsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getElapsedSeconds.()F", this, null);
			}
		}

		public unsafe virtual Play Play
		{
			[Register("getPlay", "()Lfm/feed/android/playersdk/models/Play;", "GetGetPlayHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Play>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPlay.()Lfm/feed/android/playersdk/models/Play;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string State
		{
			[Register("getState", "()Ljava/lang/String;", "GetGetStateHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getState.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected SimulcastPlayResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SimulcastPlayResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetElapsedSecondsHandler()
		{
			if ((object)cb_getElapsedSeconds == null)
			{
				cb_getElapsedSeconds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetElapsedSeconds));
			}
			return cb_getElapsedSeconds;
		}

		private static float n_GetElapsedSeconds(IntPtr jnienv, IntPtr native__this)
		{
			SimulcastPlayResponse simulcastPlayResponse = Java.Lang.Object.GetObject<SimulcastPlayResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return simulcastPlayResponse.ElapsedSeconds;
		}

		private static Delegate GetGetPlayHandler()
		{
			if ((object)cb_getPlay == null)
			{
				cb_getPlay = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPlay));
			}
			return cb_getPlay;
		}

		private static IntPtr n_GetPlay(IntPtr jnienv, IntPtr native__this)
		{
			SimulcastPlayResponse simulcastPlayResponse = Java.Lang.Object.GetObject<SimulcastPlayResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(simulcastPlayResponse.Play);
		}

		private static Delegate GetGetStateHandler()
		{
			if ((object)cb_getState == null)
			{
				cb_getState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetState));
			}
			return cb_getState;
		}

		private static IntPtr n_GetState(IntPtr jnienv, IntPtr native__this)
		{
			SimulcastPlayResponse simulcastPlayResponse = Java.Lang.Object.GetObject<SimulcastPlayResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(simulcastPlayResponse.State);
		}
	}
	[Register("fm/feed/android/playersdk/models/webservice/SyncResponse", DoNotGenerateAcw = true)]
	public class SyncResponse : FeedFMResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("fm/feed/android/playersdk/models/webservice/SyncResponse", typeof(SyncResponse));

		private static Delegate cb_getAudioFileList;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<AudioFile> AudioFileList
		{
			[Register("getAudioFileList", "()Ljava/util/List;", "GetGetAudioFileListHandler")]
			get
			{
				return JavaList<AudioFile>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getAudioFileList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected SyncResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SyncResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetAudioFileListHandler()
		{
			if ((object)cb_getAudioFileList == null)
			{
				cb_getAudioFileList = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAudioFileList));
			}
			return cb_getAudioFileList;
		}

		private static IntPtr n_GetAudioFileList(IntPtr jnienv, IntPtr native__this)
		{
			SyncResponse syncResponse = Java.Lang.Object.GetObject<SyncResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<AudioFile>.ToLocalJniHandle(syncResponse.AudioFileList);
		}
	}
}
