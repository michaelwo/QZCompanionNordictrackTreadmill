using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using AndroidX.Browser.CustomTabs;
using IdentityModel.OidcClient.Browser;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("Auth0.OidcClient.AndroidX")]
[assembly: AssemblyProduct("Auth0.OidcClient")]
[assembly: AssemblyFileVersion("3.1.6")]
[assembly: ComVisible(false)]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyVersion("3.1.6.0")]
namespace Auth0.OidcClient;

public class ActivityMediator
{
	public delegate void MessageReceivedEventHandler(string message);

	private static ActivityMediator _instance;

	public static ActivityMediator Instance => _instance ?? (_instance = new ActivityMediator());

	public event MessageReceivedEventHandler ActivityMessageReceived;

	private ActivityMediator()
	{
	}

	public void Send(string response)
	{
		this.ActivityMessageReceived?.Invoke(response);
	}

	public void Cancel()
	{
		Send("UserCancel");
	}
}
public abstract class AndroidBrowserBase : IBrowser
{
	protected Context context;

	protected bool IsNewTask;

	protected AndroidBrowserBase(Context context = null)
	{
		this.context = context;
		IsNewTask = context == null;
	}

	public Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (string.IsNullOrWhiteSpace(options.StartUrl))
		{
			throw new ArgumentException("Missing StartUrl", "options");
		}
		if (string.IsNullOrWhiteSpace(options.EndUrl))
		{
			throw new ArgumentException("Missing EndUrl", "options");
		}
		TaskCompletionSource<BrowserResult> tcs = new TaskCompletionSource<BrowserResult>();
		ActivityMediator.Instance.ActivityMessageReceived += Callback;
		OpenBrowser(Uri.Parse(options.StartUrl), context ?? Application.Context);
		return tcs.Task;
		void Callback(string response)
		{
			ActivityMediator.Instance.ActivityMessageReceived -= Callback;
			bool flag = response == "UserCancel";
			tcs.SetResult(new BrowserResult
			{
				ResultType = (flag ? BrowserResultType.UserCancel : BrowserResultType.Success),
				Response = response
			});
		}
	}

	protected abstract void OpenBrowser(Uri uri, Context context = null);
}
public class Auth0Client : Auth0ClientBase
{
	public Auth0Client(Auth0ClientOptions options)
		: base(options, "xamarin-android")
	{
		options.Browser = options.Browser ?? new AutoSelectBrowser();
		string text = ((options.RedirectUri == null || options.PostLogoutRedirectUri == null) ? GetConventionCallbackUri(options.Domain) : null);
		options.RedirectUri = options.RedirectUri ?? text;
		options.PostLogoutRedirectUri = options.PostLogoutRedirectUri ?? text;
	}

	public Auth0Client(Auth0ClientOptions options, Activity activity)
		: base(options, "xamarin-android")
	{
		options.Browser = options.Browser ?? new AutoSelectBrowser(activity);
		string text = ((options.RedirectUri == null || options.PostLogoutRedirectUri == null) ? (GetActivityIntentCallbackUri(activity) ?? GetConventionCallbackUri(options.Domain)) : null);
		options.RedirectUri = options.RedirectUri ?? text;
		options.PostLogoutRedirectUri = options.PostLogoutRedirectUri ?? text;
	}

	private string GetConventionCallbackUri(string domain)
	{
		return (Application.Context.PackageName + "://" + domain + "/android/" + Application.Context.PackageName + "/callback").ToLower();
	}

	private string GetActivityIntentCallbackUri(Activity activity)
	{
		List<IntentFilterAttribute> list = (from i in Attribute.GetCustomAttributes(activity.GetType(), typeof(IntentFilterAttribute)).OfType<IntentFilterAttribute>()
			where IsActionDefaultBrowsable(i) && HasSchemeHostAndPrefix(i)
			select i).ToList();
		if (list.Count != 1)
		{
			return null;
		}
		string resourcableValue = GetResourcableValue(activity, list[0].DataScheme);
		string resourcableValue2 = GetResourcableValue(activity, list[0].DataHost);
		string resourcableValue3 = GetResourcableValue(activity, list[0].DataPathPrefix);
		return resourcableValue + "://" + resourcableValue2 + resourcableValue3;
	}

	private bool IsActionDefaultBrowsable(IntentFilterAttribute ifa)
	{
		if (ifa.Actions.Contains("android.intent.action.VIEW") && ifa.Categories.Contains("android.intent.category.DEFAULT"))
		{
			return ifa.Categories.Contains("android.intent.category.BROWSABLE");
		}
		return false;
	}

	private bool HasSchemeHostAndPrefix(IntentFilterAttribute ifa)
	{
		if (ifa.DataScheme != null && ifa.DataHost != null)
		{
			return ifa.DataPathPrefix != null;
		}
		return false;
	}

	private string GetResourcableValue(Context context, string value)
	{
		if (!value.StartsWith("@"))
		{
			return value;
		}
		int identifier = context.Resources.GetIdentifier(value, null, context.PackageName);
		if (identifier <= 0)
		{
			return value;
		}
		return context.Resources.GetString(identifier);
	}
}
public class Auth0ClientActivity : Activity
{
	protected override void OnResume()
	{
		base.OnResume();
		ActivityMediator.Instance.Cancel();
	}

	protected override void OnNewIntent(Intent intent)
	{
		base.OnNewIntent(intent);
		ActivityMediator.Instance.Send(intent.DataString);
	}
}
public class AutoSelectBrowser : ChromeCustomTabsBrowser
{
	public AutoSelectBrowser(Context context)
		: base(context)
	{
	}

	internal AutoSelectBrowser()
	{
	}
}
public class ChromeCustomTabsBrowser : AndroidBrowserBase
{
	public ChromeCustomTabsBrowser(Context context = null)
		: base(context)
	{
	}

	protected override void OpenBrowser(Uri uri, Context context = null)
	{
		using CustomTabsIntent.Builder builder = new CustomTabsIntent.Builder();
		using CustomTabsIntent customTabsIntent = builder.Build();
		if (IsNewTask)
		{
			customTabsIntent.Intent.AddFlags(ActivityFlags.NewTask);
		}
		customTabsIntent.LaunchUrl(context, uri);
	}
}
