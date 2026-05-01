using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework("MonoAndroid,Version=v4.4", FrameworkDisplayName = "Xamarin.Android v4.4 Support")]
[assembly: AssemblyCompany("James Montemagno")]
[assembly: AssemblyConfiguration("release")]
[assembly: AssemblyCopyright("Copyright 2018")]
[assembly: AssemblyDescription("\r\n      Provides a simple solution for getting access to the current Activity of the application when developing a Plugin for Xamarin.\r\n      This will lay down a base \"application\" class for developers in their Android application with boilerplate code to get them started.\r\n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0.0")]
[assembly: AssemblyProduct("Plugin.CurrentActivity (MonoAndroid44)")]
[assembly: AssemblyTitle("Plugin.CurrentActivity")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Plugin.CurrentActivity;

public enum ActivityEvent
{
	Created,
	Resumed,
	Paused,
	Destroyed,
	SaveInstanceState,
	Started,
	Stopped
}
public class ActivityEventArgs : EventArgs
{
	public ActivityEvent Event { get; }

	public Activity Activity { get; }

	internal ActivityEventArgs(Activity activity, ActivityEvent ev)
	{
		Event = ev;
		Activity = activity;
	}
}
public class CrossCurrentActivity
{
	private static Lazy<ICurrentActivity> implementation = new Lazy<ICurrentActivity>(() => CreateCurrentActivity(), LazyThreadSafetyMode.PublicationOnly);

	public static ICurrentActivity Current => implementation.Value ?? throw NotImplementedInReferenceAssembly();

	private static ICurrentActivity CreateCurrentActivity()
	{
		return new CurrentActivityImplementation();
	}

	internal static System.Exception NotImplementedInReferenceAssembly()
	{
		return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
	}
}
[Preserve(AllMembers = true)]
public class CurrentActivityImplementation : ICurrentActivity
{
	private ActivityLifecycleContextListener lifecycleListener;

	public Activity Activity
	{
		get
		{
			return lifecycleListener?.Activity;
		}
		set
		{
			if (lifecycleListener == null)
			{
				Init(value, null);
			}
		}
	}

	public Context AppContext => Application.Context;

	public event EventHandler<ActivityEventArgs> ActivityStateChanged;

	internal void RaiseStateChanged(Activity activity, ActivityEvent ev)
	{
		this.ActivityStateChanged?.Invoke(this, new ActivityEventArgs(activity, ev));
	}

	public void Init(Application application)
	{
		if (lifecycleListener == null)
		{
			lifecycleListener = new ActivityLifecycleContextListener();
			application.RegisterActivityLifecycleCallbacks(lifecycleListener);
		}
	}

	public void Init(Activity activity, Bundle bundle)
	{
		Init(activity.Application);
		lifecycleListener.Activity = activity;
	}
}
[Preserve(AllMembers = true)]
internal class ActivityLifecycleContextListener : Java.Lang.Object, Application.IActivityLifecycleCallbacks, IJavaObject, IDisposable
{
	private WeakReference<Activity> currentActivity = new WeakReference<Activity>(null);

	public Context Context => Activity ?? Application.Context;

	public Activity Activity
	{
		get
		{
			if (!currentActivity.TryGetTarget(out var target))
			{
				return null;
			}
			return target;
		}
		set
		{
			currentActivity.SetTarget(value);
		}
	}

	private CurrentActivityImplementation Current => (CurrentActivityImplementation)CrossCurrentActivity.Current;

	public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
	{
		Activity = activity;
		Current.RaiseStateChanged(activity, ActivityEvent.Created);
	}

	public void OnActivityDestroyed(Activity activity)
	{
		Current.RaiseStateChanged(activity, ActivityEvent.Destroyed);
	}

	public void OnActivityPaused(Activity activity)
	{
		Activity = activity;
		Current.RaiseStateChanged(activity, ActivityEvent.Paused);
	}

	public void OnActivityResumed(Activity activity)
	{
		Activity = activity;
		Current.RaiseStateChanged(activity, ActivityEvent.Resumed);
	}

	public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
	{
		Current.RaiseStateChanged(activity, ActivityEvent.SaveInstanceState);
	}

	public void OnActivityStarted(Activity activity)
	{
		Current.RaiseStateChanged(activity, ActivityEvent.Started);
	}

	public void OnActivityStopped(Activity activity)
	{
		Current.RaiseStateChanged(activity, ActivityEvent.Stopped);
	}
}
public interface ICurrentActivity
{
	Activity Activity { get; set; }

	Context AppContext { get; }

	event EventHandler<ActivityEventArgs> ActivityStateChanged;

	void Init(Application application);

	void Init(Activity activity, Bundle bundle);
}
