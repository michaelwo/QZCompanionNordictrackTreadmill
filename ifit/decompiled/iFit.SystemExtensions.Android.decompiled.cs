using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.Net.Wifi;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.Core.Content;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyVersion("0.0.0.0")]
namespace iFit.Extensions.Android;

public static class ColorExtensions
{
	public static global::Android.Graphics.Color ToNativeBrush(this System.Drawing.Color color)
	{
		return global::Android.Graphics.Color.Argb(color.A, color.R, color.G, color.B);
	}

	public static string ToRgb(this System.Drawing.Color color)
	{
		string name = color.Name;
		return name.Substring(2, 6);
	}

	public static string ToRgbStr(this System.Drawing.Color color)
	{
		return "#" + color.ToRgb();
	}
}
public static class ContextExtensions
{
	public static void SafelyUnregisterReceiver(this Context context, BroadcastReceiver receiver)
	{
		try
		{
			context?.UnregisterReceiver(receiver);
		}
		catch (System.Exception)
		{
		}
	}

	public static bool TryResolveActivity(this Context context, Intent intent, out IList<ResolveInfo> resultingPackages)
	{
		try
		{
			resultingPackages = context?.PackageManager?.QueryIntentActivities(intent, (PackageInfoFlags)0);
			return (resultingPackages?.Count).GetValueOrDefault() != 0;
		}
		catch (System.Exception)
		{
		}
		resultingPackages = null;
		return false;
	}

	public static global::Android.Graphics.Color GetColorCompat(this Context context, int resId)
	{
		return new global::Android.Graphics.Color(context.GetColorIntCompat(resId));
	}

	public static int GetColorIntCompat(this Context context, int resId)
	{
		return ContextCompat.GetColor(context, resId);
	}

	public static float GetFloat(this Resources res, int resId)
	{
		TypedValue typedValue = new TypedValue();
		res.GetValue(resId, typedValue, resolveRefs: true);
		return typedValue.Float;
	}
}
public static class JavaExtensions
{
	public static T DisposeSafe<T>(this T obj) where T : Java.Lang.Object
	{
		try
		{
			if (obj == null || obj.Handle == IntPtr.Zero)
			{
				return null;
			}
			obj.Dispose();
		}
		catch
		{
		}
		return null;
	}
}
public static class ViewExtensions
{
	public static bool ContainsTouch(this View view, MotionEvent e)
	{
		if ((float)view.GetAbsoluteLeft() > e.RawX || (float)view.GetAbsoluteRight() < e.RawX)
		{
			return false;
		}
		if ((float)view.GetAbsoluteTop() > e.RawY || (float)view.GetAbsoluteBottom() < e.RawY)
		{
			return false;
		}
		return true;
	}

	public static bool ContainsStartAndEndTouch(this View view, MotionEvent start, MotionEvent end)
	{
		if (view.ContainsTouch(start))
		{
			return view.ContainsTouch(end);
		}
		return false;
	}

	public static int GetAbsoluteBottom(this View view)
	{
		if (view == null)
		{
			return -2147483648;
		}
		int[] array = new int[2];
		view.GetLocationOnScreen(array);
		return array[1] + view.Height;
	}

	public static int GetAbsoluteTop(this View view)
	{
		if (view == null)
		{
			return -2147483648;
		}
		int[] array = new int[2];
		view.GetLocationOnScreen(array);
		return array[1];
	}

	public static int GetAbsoluteLeft(this View view)
	{
		if (view == null)
		{
			return -2147483648;
		}
		int[] array = new int[2];
		view.GetLocationOnScreen(array);
		return array[0];
	}

	public static int GetAbsoluteRight(this View view)
	{
		if (view == null)
		{
			return -2147483648;
		}
		int[] array = new int[2];
		view.GetLocationOnScreen(array);
		return array[0] + view.Width;
	}

	public static void SetTextIfChanged(this TextView textView, string text)
	{
		if (text != null && textView != null && !text.Equals(textView.Text))
		{
			textView.Text = text;
		}
	}

	public static void DismissKeyboard(this Activity activity)
	{
		if (activity?.CurrentFocus?.WindowToken != null)
		{
			activity.GetSystemService("input_method").JavaCast<InputMethodManager>()?.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, HideSoftInputFlags.None);
		}
	}

	public static bool TouchesRepresentClick(this View view, MotionEvent start, MotionEvent end)
	{
		if (start == null || end == null || start.ActionMasked != MotionEventActions.Down || end.ActionMasked != MotionEventActions.Up)
		{
			return false;
		}
		int scaledTouchSlop = ViewConfiguration.Get(Application.Context).ScaledTouchSlop;
		float num = System.Math.Abs(end.RawX - start.RawX);
		float num2 = System.Math.Abs(end.RawY - start.RawY);
		double num3 = System.Math.Sqrt(num * num + num2 * num2);
		return num3 < (double)scaledTouchSlop;
	}
}
public static class WifiExtensions
{
	public static bool EqualAndPopulatedSsids(this WifiConfiguration wifiConf, string otherSsid)
	{
		if (wifiConf == null || string.IsNullOrWhiteSpace(wifiConf?.Ssid))
		{
			return false;
		}
		if (!string.IsNullOrWhiteSpace(wifiConf.Ssid.Replace("\"", "")) && wifiConf.Ssid.Replace("\"", "").Equals(otherSsid.Replace("\"", "")))
		{
			return true;
		}
		return false;
	}
}
