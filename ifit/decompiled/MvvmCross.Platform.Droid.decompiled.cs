using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.Lang;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Droid.Views;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.WeakSubscription;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Platform.Droid")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MvvmCross")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework("MonoAndroid,Version=v6.0", FrameworkDisplayName = "Xamarin.Android v6.0 Support")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Platform.Droid
{
	public interface IMvxAndroidGlobals
	{
		string ExecutableNamespace { get; }

		Assembly ExecutableAssembly { get; }

		Context ApplicationContext { get; }
	}
	public class MvxJavaContainer : Java.Lang.Object
	{
		public object Object { get; private set; }

		protected MvxJavaContainer(object theObject)
		{
			Object = theObject;
		}
	}
	public class MvxJavaContainer<T> : MvxJavaContainer
	{
		public new T Object => (T)base.Object;

		public MvxJavaContainer(T theObject)
			: base(theObject)
		{
		}
	}
	public class MvxReplaceableJavaContainer : Java.Lang.Object
	{
		public object Object { get; set; }

		public override string ToString()
		{
			return Object?.ToString() ?? string.Empty;
		}
	}
}
namespace MvvmCross.Platform.Droid.WeakSubscription
{
	public class MvxAndroidTargetEventSubscription<TSource, TEventArgs> : MvxWeakEventSubscription<TSource, TEventArgs> where TSource : class
	{
		public MvxAndroidTargetEventSubscription(TSource source, string sourceEventName, EventHandler<TEventArgs> targetEventHandler)
			: base(source, sourceEventName, targetEventHandler)
		{
		}

		public MvxAndroidTargetEventSubscription(TSource source, EventInfo sourceEventInfo, EventHandler<TEventArgs> targetEventHandler)
			: base(source, sourceEventInfo, targetEventHandler)
		{
		}

		protected override object GetTargetObject()
		{
			object targetObject = base.GetTargetObject();
			if (targetObject is IJavaObject javaObject && javaObject.Handle == IntPtr.Zero)
			{
				return null;
			}
			return targetObject;
		}

		protected override Delegate CreateEventHandler()
		{
			return new EventHandler<TEventArgs>(base.OnSourceEvent);
		}
	}
	public class MvxJavaEventSubscription<TSource> : MvxWeakEventSubscription<TSource> where TSource : class
	{
		public MvxJavaEventSubscription(TSource source, string sourceEventName, EventHandler targetEventHandler)
			: base(source, sourceEventName, targetEventHandler)
		{
		}

		public MvxJavaEventSubscription(TSource source, EventInfo sourceEventInfo, EventHandler targetEventHandler)
			: base(source, sourceEventInfo, targetEventHandler)
		{
		}

		protected override object GetTargetObject()
		{
			object targetObject = base.GetTargetObject();
			if (targetObject is IJavaObject javaObject && javaObject.Handle == IntPtr.Zero)
			{
				return null;
			}
			return targetObject;
		}

		protected override Delegate CreateEventHandler()
		{
			return new EventHandler(base.OnSourceEvent);
		}
	}
	public static class MvxAndroidWeakSubscriptionExtensionMethods
	{
		public static MvxJavaEventSubscription<TSource> WeakSubscribe<TSource>(this TSource source, string eventName, EventHandler eventHandler) where TSource : class
		{
			return new MvxJavaEventSubscription<TSource>(source, eventName, eventHandler);
		}

		public static MvxAndroidTargetEventSubscription<TSource, TEventArgs> WeakSubscribe<TSource, TEventArgs>(this TSource source, string eventName, EventHandler<TEventArgs> eventHandler) where TSource : class
		{
			return new MvxAndroidTargetEventSubscription<TSource, TEventArgs>(source, eventName, eventHandler);
		}
	}
}
namespace MvvmCross.Platform.Droid.Views
{
	public interface IMvxStartActivityForResult
	{
		void MvxInternalStartActivityForResult(Intent intent, int requestCode);
	}
	public class MvxActivityResultParameters
	{
		public int RequestCode { get; private set; }

		public Result ResultCode { get; private set; }

		public Intent Data { get; private set; }

		public MvxActivityResultParameters(int requestCode, Result resultCode, Intent data)
		{
			Data = data;
			ResultCode = resultCode;
			RequestCode = requestCode;
		}
	}
	public abstract class MvxBaseActivityAdapter
	{
		private readonly IMvxEventSourceActivity _eventSource;

		protected Activity Activity => _eventSource as Activity;

		protected MvxBaseActivityAdapter(IMvxEventSourceActivity eventSource)
		{
			_eventSource = eventSource;
			_eventSource.CreateCalled += EventSourceOnCreateCalled;
			_eventSource.CreateWillBeCalled += EventSourceOnCreateWillBeCalled;
			_eventSource.StartCalled += EventSourceOnStartCalled;
			_eventSource.RestartCalled += EventSourceOnRestartCalled;
			_eventSource.ResumeCalled += EventSourceOnResumeCalled;
			_eventSource.PauseCalled += EventSourceOnPauseCalled;
			_eventSource.StopCalled += EventSourceOnStopCalled;
			_eventSource.DestroyCalled += EventSourceOnDestroyCalled;
			_eventSource.DisposeCalled += EventSourceOnDisposeCalled;
			_eventSource.SaveInstanceStateCalled += EventSourceOnSaveInstanceStateCalled;
			_eventSource.NewIntentCalled += EventSourceOnNewIntentCalled;
			_eventSource.ActivityResultCalled += EventSourceOnActivityResultCalled;
			_eventSource.StartActivityForResultCalled += EventSourceOnStartActivityForResultCalled;
		}

		protected virtual void EventSourceOnSaveInstanceStateCalled(object sender, MvxValueEventArgs<Bundle> mvxValueEventArgs)
		{
		}

		protected virtual void EventSourceOnCreateWillBeCalled(object sender, MvxValueEventArgs<Bundle> MvxValueEventArgs)
		{
		}

		protected virtual void EventSourceOnStopCalled(object sender, EventArgs eventArgs)
		{
		}

		protected virtual void EventSourceOnStartCalled(object sender, EventArgs eventArgs)
		{
		}

		protected virtual void EventSourceOnStartActivityForResultCalled(object sender, MvxValueEventArgs<MvxStartActivityForResultParameters> MvxValueEventArgs)
		{
		}

		protected virtual void EventSourceOnResumeCalled(object sender, EventArgs eventArgs)
		{
		}

		protected virtual void EventSourceOnRestartCalled(object sender, EventArgs eventArgs)
		{
		}

		protected virtual void EventSourceOnPauseCalled(object sender, EventArgs eventArgs)
		{
		}

		protected virtual void EventSourceOnNewIntentCalled(object sender, MvxValueEventArgs<Intent> MvxValueEventArgs)
		{
		}

		protected virtual void EventSourceOnDisposeCalled(object sender, EventArgs eventArgs)
		{
		}

		protected virtual void EventSourceOnDestroyCalled(object sender, EventArgs eventArgs)
		{
		}

		protected virtual void EventSourceOnCreateCalled(object sender, MvxValueEventArgs<Bundle> MvxValueEventArgs)
		{
		}

		protected virtual void EventSourceOnActivityResultCalled(object sender, MvxValueEventArgs<MvxActivityResultParameters> MvxValueEventArgs)
		{
		}
	}
	[Register("mvvmcross.platform.droid.views.MvxEventSourceActivity")]
	public abstract class MvxEventSourceActivity : Activity, IMvxEventSourceActivity, IMvxDisposeSource
	{
		public event EventHandler DisposeCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> CreateWillBeCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> CreateCalled;

		public event EventHandler DestroyCalled;

		public event EventHandler<MvxValueEventArgs<Intent>> NewIntentCalled;

		public event EventHandler ResumeCalled;

		public event EventHandler PauseCalled;

		public event EventHandler StartCalled;

		public event EventHandler RestartCalled;

		public event EventHandler StopCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> SaveInstanceStateCalled;

		public event EventHandler<MvxValueEventArgs<MvxStartActivityForResultParameters>> StartActivityForResultCalled;

		public event EventHandler<MvxValueEventArgs<MvxActivityResultParameters>> ActivityResultCalled;

		protected MvxEventSourceActivity()
		{
		}

		protected MvxEventSourceActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected override void OnCreate(Bundle bundle)
		{
			this.CreateWillBeCalled.Raise(this, bundle);
			base.OnCreate(bundle);
			this.CreateCalled.Raise(this, bundle);
		}

		protected override void OnDestroy()
		{
			this.DestroyCalled.Raise(this);
			base.OnDestroy();
		}

		protected override void OnNewIntent(Intent intent)
		{
			base.OnNewIntent(intent);
			this.NewIntentCalled.Raise(this, intent);
		}

		protected override void OnResume()
		{
			base.OnResume();
			this.ResumeCalled.Raise(this);
		}

		protected override void OnPause()
		{
			this.PauseCalled.Raise(this);
			base.OnPause();
		}

		protected override void OnStart()
		{
			base.OnStart();
			this.StartCalled.Raise(this);
		}

		protected override void OnRestart()
		{
			base.OnRestart();
			this.RestartCalled.Raise(this);
		}

		protected override void OnStop()
		{
			this.StopCalled.Raise(this);
			base.OnStop();
		}

		public override void StartActivityForResult(Intent intent, int requestCode)
		{
			this.StartActivityForResultCalled.Raise(this, new MvxStartActivityForResultParameters(intent, requestCode));
			base.StartActivityForResult(intent, requestCode);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			this.ActivityResultCalled.Raise(this, new MvxActivityResultParameters(requestCode, resultCode, data));
			base.OnActivityResult(requestCode, resultCode, data);
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			this.SaveInstanceStateCalled.Raise(this, outState);
			base.OnSaveInstanceState(outState);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.DisposeCalled.Raise(this);
			}
			base.Dispose(disposing);
		}
	}
	[Obsolete("TabActivity is obsolete. Use ViewPager + Indicator or any other Activity with Toolbar support.")]
	[Register("mvvmcross.platform.droid.views.MvxEventSourceTabActivity")]
	public abstract class MvxEventSourceTabActivity : TabActivity, IMvxEventSourceActivity, IMvxDisposeSource
	{
		public event EventHandler DisposeCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> CreateWillBeCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> CreateCalled;

		public event EventHandler DestroyCalled;

		public event EventHandler<MvxValueEventArgs<Intent>> NewIntentCalled;

		public event EventHandler ResumeCalled;

		public event EventHandler PauseCalled;

		public event EventHandler StartCalled;

		public event EventHandler RestartCalled;

		public event EventHandler StopCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> SaveInstanceStateCalled;

		public event EventHandler<MvxValueEventArgs<MvxStartActivityForResultParameters>> StartActivityForResultCalled;

		public event EventHandler<MvxValueEventArgs<MvxActivityResultParameters>> ActivityResultCalled;

		protected override void OnCreate(Bundle bundle)
		{
			this.CreateWillBeCalled.Raise(this, bundle);
			base.OnCreate(bundle);
			this.CreateCalled.Raise(this, bundle);
		}

		protected override void OnDestroy()
		{
			this.DestroyCalled.Raise(this);
			base.OnDestroy();
		}

		protected override void OnNewIntent(Intent intent)
		{
			base.OnNewIntent(intent);
			this.NewIntentCalled.Raise(this, intent);
		}

		protected override void OnResume()
		{
			base.OnResume();
			this.ResumeCalled.Raise(this);
		}

		protected override void OnPause()
		{
			this.PauseCalled.Raise(this);
			base.OnPause();
		}

		protected override void OnStart()
		{
			base.OnStart();
			this.StartCalled.Raise(this);
		}

		protected override void OnRestart()
		{
			base.OnRestart();
			this.RestartCalled.Raise(this);
		}

		protected override void OnStop()
		{
			this.StopCalled.Raise(this);
			base.OnStop();
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			this.SaveInstanceStateCalled.Raise(this, outState);
			base.OnSaveInstanceState(outState);
		}

		public override void StartActivityForResult(Intent intent, int requestCode)
		{
			this.StartActivityForResultCalled.Raise(this, new MvxStartActivityForResultParameters(intent, requestCode));
			base.StartActivityForResult(intent, requestCode);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			this.ActivityResultCalled.Raise(this, new MvxActivityResultParameters(requestCode, resultCode, data));
			base.OnActivityResult(requestCode, resultCode, data);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.DisposeCalled.Raise(this);
			}
			base.Dispose(disposing);
		}
	}
	public interface IMvxEventSourceActivity : IMvxDisposeSource
	{
		event EventHandler<MvxValueEventArgs<Bundle>> CreateWillBeCalled;

		event EventHandler<MvxValueEventArgs<Bundle>> CreateCalled;

		event EventHandler DestroyCalled;

		event EventHandler<MvxValueEventArgs<Intent>> NewIntentCalled;

		event EventHandler ResumeCalled;

		event EventHandler PauseCalled;

		event EventHandler StartCalled;

		event EventHandler RestartCalled;

		event EventHandler StopCalled;

		event EventHandler<MvxValueEventArgs<Bundle>> SaveInstanceStateCalled;

		event EventHandler<MvxValueEventArgs<MvxStartActivityForResultParameters>> StartActivityForResultCalled;

		event EventHandler<MvxValueEventArgs<MvxActivityResultParameters>> ActivityResultCalled;
	}
	public enum MvxIntentRequestCode
	{
		PickFromFile = 30001,
		PickFromCamera
	}
	public class MvxIntentResultEventArgs : EventArgs
	{
		public int RequestCode { get; private set; }

		public Result ResultCode { get; private set; }

		public Intent Data { get; private set; }

		public MvxIntentResultEventArgs(int requestCode, Result resultCode, Intent data)
		{
			Data = data;
			ResultCode = resultCode;
			RequestCode = requestCode;
		}
	}
	public class MvxStartActivityForResultParameters
	{
		public Intent Intent { get; private set; }

		public int RequestCode { get; private set; }

		public MvxStartActivityForResultParameters(Intent intent, int requestCode)
		{
			RequestCode = requestCode;
			Intent = intent;
		}
	}
}
namespace MvvmCross.Platform.Droid.Platform
{
	public interface IMvxAndroidCurrentTopActivity
	{
		Activity Activity { get; }
	}
	public class MvxAndroidTask : MvxMainThreadDispatchingObject
	{
		protected void StartActivity(Intent intent)
		{
			DoOnActivity(delegate(Activity activity)
			{
				activity.StartActivity(intent);
			});
		}

		protected void StartActivityForResult(int requestCode, Intent intent)
		{
			DoOnActivity(delegate(Activity activity)
			{
				if (!(activity is IMvxStartActivityForResult mvxStartActivityForResult))
				{
					MvxTrace.Error("Error - current activity is null or does not support IMvxAndroidView");
				}
				else
				{
					Mvx.Resolve<IMvxIntentResultSource>().Result += OnMvxIntentResultReceived;
					mvxStartActivityForResult.MvxInternalStartActivityForResult(intent, requestCode);
				}
			});
		}

		protected virtual void ProcessMvxIntentResult(MvxIntentResultEventArgs result)
		{
		}

		private void OnMvxIntentResultReceived(object sender, MvxIntentResultEventArgs e)
		{
			MvxTrace.Trace("OnMvxIntentResultReceived in MvxAndroidTask");
			Mvx.Resolve<IMvxIntentResultSource>().Result -= OnMvxIntentResultReceived;
			ProcessMvxIntentResult(e);
		}

		protected void DoOnActivity(Action<Activity> action, bool ensureOnMainThread = true)
		{
			Activity activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
			if (ensureOnMainThread)
			{
				InvokeOnMainThread(delegate
				{
					action(activity);
				});
			}
			else
			{
				action(activity);
			}
		}
	}
	public static class MvxDateTimeExtensionMethods
	{
		private static readonly DateTime UnixZeroUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static DateTime FromMillisecondsUnixTimeToUtc(this long milliseconds)
		{
			DateTime unixZeroUtc = UnixZeroUtc;
			return unixZeroUtc.AddMilliseconds(milliseconds);
		}

		public static DateTime FromUnixTimeToUtc(this long seconds)
		{
			DateTime unixZeroUtc = UnixZeroUtc;
			return unixZeroUtc.AddSeconds(seconds);
		}

		public static DateTime FromUnixTimeToLocal(this long seconds)
		{
			return seconds.FromUnixTimeToUtc().ToLocalTime();
		}

		public static long FromUtcToUnixTime(this DateTime dateTimeUtc)
		{
			return (long)(dateTimeUtc - UnixZeroUtc).TotalSeconds;
		}

		public static long FromLocalToUnixTime(this DateTime dateTimeLocal)
		{
			return dateTimeLocal.ToUniversalTime().FromUtcToUnixTime();
		}
	}
	public class MvxIntentResultSink : IMvxIntentResultSink, IMvxIntentResultSource
	{
		public event EventHandler<MvxIntentResultEventArgs> Result;

		public void OnResult(MvxIntentResultEventArgs result)
		{
			this.Result?.Invoke(this, result);
		}
	}
	public static class MvxJavaDateUtils
	{
		public static DateTime DateTimeFromJava(int year, int month, int dayOfMonth)
		{
			return new DateTime(year, month + 1, dayOfMonth);
		}
	}
	public interface IMvxIntentResultSink
	{
		void OnResult(MvxIntentResultEventArgs result);
	}
	public interface IMvxIntentResultSource
	{
		event EventHandler<MvxIntentResultEventArgs> Result;
	}
}
