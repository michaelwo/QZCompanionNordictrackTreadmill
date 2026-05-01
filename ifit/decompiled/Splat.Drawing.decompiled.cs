using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyFileVersion("9.3.11.38370")]
[assembly: AssemblyInformationalVersion("9.3.11+e295f3dabc")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: InternalsVisibleTo("Splat.Tests")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany(".NET Foundation and Contributors")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright (c) .NET Foundation and Contributors")]
[assembly: AssemblyDescription("A library to make things cross-platform that should be")]
[assembly: AssemblyProduct("Splat.Drawing (MonoAndroid90)")]
[assembly: AssemblyTitle("Splat.Drawing")]
[assembly: AssemblyVersion("9.3.0.0")]
[assembly: TypeForwardedTo(typeof(System.Drawing.Color))]
[assembly: TypeForwardedTo(typeof(KnownColor))]
[assembly: TypeForwardedTo(typeof(System.Drawing.Point))]
[assembly: TypeForwardedTo(typeof(System.Drawing.PointF))]
[assembly: TypeForwardedTo(typeof(Rectangle))]
[assembly: TypeForwardedTo(typeof(RectangleF))]
[assembly: TypeForwardedTo(typeof(Size))]
[assembly: TypeForwardedTo(typeof(SizeF))]
internal static class ThisAssembly
{
	internal const string AssemblyVersion = "9.3.0.0";

	internal const string AssemblyFileVersion = "9.3.11.38370";

	internal const string AssemblyInformationalVersion = "9.3.11+e295f3dabc";

	internal const string AssemblyName = "Splat.Drawing";

	internal const string AssemblyTitle = "Splat.Drawing";

	internal const string AssemblyConfiguration = "Release";

	internal const string GitCommitId = "e295f3dabc73fc95025b863dfd8954ed848da634";

	internal static readonly DateTime GitCommitDate = new DateTime(637149457450000000L, DateTimeKind.Utc);

	internal const string RootNamespace = "Splat";
}
namespace Splat;

public static class BitmapLoader
{
	private static IBitmapLoader _Current = Locator.Current.GetService<IBitmapLoader>();

	public static IBitmapLoader Current
	{
		get
		{
			return _Current ?? throw new BitmapLoaderException("Could not find a default bitmap loader. This should never happen, your dependency resolver is broken");
		}
		set
		{
			_Current = value;
		}
	}
}
[Serializable]
public class BitmapLoaderException : Exception
{
	public BitmapLoaderException()
	{
	}

	public BitmapLoaderException(string message)
		: base(message)
	{
	}

	public BitmapLoaderException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected BitmapLoaderException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
public enum CompressedBitmapFormat
{
	Png,
	Jpeg
}
public interface IBitmap : IDisposable
{
	float Width { get; }

	float Height { get; }

	Task Save(CompressedBitmapFormat format, float quality, Stream target);
}
public interface IBitmapLoader
{
	Task<IBitmap> Load(Stream sourceStream, float? desiredWidth, float? desiredHeight);

	Task<IBitmap> LoadFromResource(string source, float? desiredWidth, float? desiredHeight);

	IBitmap Create(float width, float height);
}
public enum KnownColor
{
	ActiveBorder = 1,
	ActiveCaption,
	ActiveCaptionText,
	AppWorkspace,
	Control,
	ControlDark,
	ControlDarkDark,
	ControlLight,
	ControlLightLight,
	ControlText,
	Desktop,
	GrayText,
	Highlight,
	HighlightText,
	HotTrack,
	InactiveBorder,
	InactiveCaption,
	InactiveCaptionText,
	Info,
	InfoText,
	Menu,
	MenuText,
	ScrollBar,
	Window,
	WindowFrame,
	WindowText,
	Transparent,
	AliceBlue,
	AntiqueWhite,
	Aqua,
	Aquamarine,
	Azure,
	Beige,
	Bisque,
	Black,
	BlanchedAlmond,
	Blue,
	BlueViolet,
	Brown,
	BurlyWood,
	CadetBlue,
	Chartreuse,
	Chocolate,
	Coral,
	CornflowerBlue,
	Cornsilk,
	Crimson,
	Cyan,
	DarkBlue,
	DarkCyan,
	DarkGoldenrod,
	DarkGray,
	DarkGreen,
	DarkKhaki,
	DarkMagenta,
	DarkOliveGreen,
	DarkOrange,
	DarkOrchid,
	DarkRed,
	DarkSalmon,
	DarkSeaGreen,
	DarkSlateBlue,
	DarkSlateGray,
	DarkTurquoise,
	DarkViolet,
	DeepPink,
	DeepSkyBlue,
	DimGray,
	DodgerBlue,
	Firebrick,
	FloralWhite,
	ForestGreen,
	Fuchsia,
	Gainsboro,
	GhostWhite,
	Gold,
	Goldenrod,
	Gray,
	Green,
	GreenYellow,
	Honeydew,
	HotPink,
	IndianRed,
	Indigo,
	Ivory,
	Khaki,
	Lavender,
	LavenderBlush,
	LawnGreen,
	LemonChiffon,
	LightBlue,
	LightCoral,
	LightCyan,
	LightGoldenrodYellow,
	LightGray,
	LightGreen,
	LightPink,
	LightSalmon,
	LightSeaGreen,
	LightSkyBlue,
	LightSlateGray,
	LightSteelBlue,
	LightYellow,
	Lime,
	LimeGreen,
	Linen,
	Magenta,
	Maroon,
	MediumAquamarine,
	MediumBlue,
	MediumOrchid,
	MediumPurple,
	MediumSeaGreen,
	MediumSlateBlue,
	MediumSpringGreen,
	MediumTurquoise,
	MediumVioletRed,
	MidnightBlue,
	MintCream,
	MistyRose,
	Moccasin,
	NavajoWhite,
	Navy,
	OldLace,
	Olive,
	OliveDrab,
	Orange,
	OrangeRed,
	Orchid,
	PaleGoldenrod,
	PaleGreen,
	PaleTurquoise,
	PaleVioletRed,
	PapayaWhip,
	PeachPuff,
	Peru,
	Pink,
	Plum,
	PowderBlue,
	Purple,
	Red,
	RosyBrown,
	RoyalBlue,
	SaddleBrown,
	Salmon,
	SandyBrown,
	SeaGreen,
	SeaShell,
	Sienna,
	Silver,
	SkyBlue,
	SlateBlue,
	SlateGray,
	Snow,
	SpringGreen,
	SteelBlue,
	Tan,
	Teal,
	Thistle,
	Tomato,
	Turquoise,
	Violet,
	Wheat,
	White,
	WhiteSmoke,
	Yellow,
	YellowGreen,
	ButtonFace,
	ButtonHighlight,
	ButtonShadow,
	GradientActiveCaption,
	GradientInactiveCaption,
	MenuBar,
	MenuHighlight
}
internal class KnownColors
{
	internal static uint[] ArgbValues;

	private KnownColors()
	{
	}

	static KnownColors()
	{
		ArgbValues = new uint[168]
		{
			0u, 4292137160u, 4278211811u, 4294967295u, 4286611584u, 4293716440u, 4289505433u, 4285624164u, 4294045666u, 4294967295u,
			4278190080u, 4278210200u, 4289505433u, 4281428677u, 4294967295u, 4278190208u, 4292137160u, 4286224095u, 4292404472u, 4294967265u,
			4278190080u, 4294967295u, 4278190080u, 4292137160u, 4294967295u, 4278190080u, 4278190080u, 16777215u, 4293982463u, 4294634455u,
			4278255615u, 4286578644u, 4293984255u, 4294309340u, 4294960324u, 4278190080u, 4294962125u, 4278190335u, 4287245282u, 4289014314u,
			4292786311u, 4284456608u, 4286578432u, 4291979550u, 4294934352u, 4284782061u, 4294965468u, 4292613180u, 4278255615u, 4278190219u,
			4278225803u, 4290283019u, 4289309097u, 4278215680u, 4290623339u, 4287299723u, 4283788079u, 4294937600u, 4288230092u, 4287299584u,
			4293498490u, 4287609995u, 4282924427u, 4281290575u, 4278243025u, 4287889619u, 4294907027u, 4278239231u, 4285098345u, 4280193279u,
			4289864226u, 4294966000u, 4280453922u, 4294902015u, 4292664540u, 4294506751u, 4294956800u, 4292519200u, 4286611584u, 4278222848u,
			4289593135u, 4293984240u, 4294928820u, 4291648604u, 4283105410u, 4294967280u, 4293977740u, 4293322490u, 4294963445u, 4286381056u,
			4294965965u, 4289583334u, 4293951616u, 4292935679u, 4294638290u, 4292072403u, 4287688336u, 4294948545u, 4294942842u, 4280332970u,
			4287090426u, 4286023833u, 4289774814u, 4294967264u, 4278255360u, 4281519410u, 4294635750u, 4294902015u, 4286578688u, 4284927402u,
			4278190285u, 4290401747u, 4287852763u, 4282168177u, 4286277870u, 4278254234u, 4282962380u, 4291237253u, 4279834992u, 4294311930u,
			4294960353u, 4294960309u, 4294958765u, 4278190208u, 4294833638u, 4286611456u, 4285238819u, 4294944000u, 4294919424u, 4292505814u,
			4293847210u, 4288215960u, 4289720046u, 4292571283u, 4294963157u, 4294957753u, 4291659071u, 4294951115u, 4292714717u, 4289781990u,
			4286578816u, 4294901760u, 4290547599u, 4282477025u, 4287317267u, 4294606962u, 4294222944u, 4281240407u, 4294964718u, 4288696877u,
			4290822336u, 4287090411u, 4285160141u, 4285563024u, 4294966010u, 4278255487u, 4282811060u, 4291998860u, 4278222976u, 4292394968u,
			4294927175u, 4282441936u, 4293821166u, 4294303411u, 4294967295u, 4294309365u, 4294967040u, 4288335154u
		};
	}

	public static SplatColor FromKnownColor(KnownColor kc)
	{
		return SplatColor.FromKnownColor(kc);
	}

	public static string GetName(short kc)
	{
		return kc switch
		{
			1 => "ActiveBorder", 
			2 => "ActiveCaption", 
			3 => "ActiveCaptionText", 
			4 => "AppWorkspace", 
			5 => "Control", 
			6 => "ControlDark", 
			7 => "ControlDarkDark", 
			8 => "ControlLight", 
			9 => "ControlLightLight", 
			10 => "ControlText", 
			11 => "Desktop", 
			12 => "GrayText", 
			13 => "Highlight", 
			14 => "HighlightText", 
			15 => "HotTrack", 
			16 => "InactiveBorder", 
			17 => "InactiveCaption", 
			18 => "InactiveCaptionText", 
			19 => "Info", 
			20 => "InfoText", 
			21 => "Menu", 
			22 => "MenuText", 
			23 => "ScrollBar", 
			24 => "Window", 
			25 => "WindowFrame", 
			26 => "WindowText", 
			27 => "Transparent", 
			28 => "AliceBlue", 
			29 => "AntiqueWhite", 
			30 => "Aqua", 
			31 => "Aquamarine", 
			32 => "Azure", 
			33 => "Beige", 
			34 => "Bisque", 
			35 => "Black", 
			36 => "BlanchedAlmond", 
			37 => "Blue", 
			38 => "BlueViolet", 
			39 => "Brown", 
			40 => "BurlyWood", 
			41 => "CadetBlue", 
			42 => "Chartreuse", 
			43 => "Chocolate", 
			44 => "Coral", 
			45 => "CornflowerBlue", 
			46 => "Cornsilk", 
			47 => "Crimson", 
			48 => "Cyan", 
			49 => "DarkBlue", 
			50 => "DarkCyan", 
			51 => "DarkGoldenrod", 
			52 => "DarkGray", 
			53 => "DarkGreen", 
			54 => "DarkKhaki", 
			55 => "DarkMagenta", 
			56 => "DarkOliveGreen", 
			57 => "DarkOrange", 
			58 => "DarkOrchid", 
			59 => "DarkRed", 
			60 => "DarkSalmon", 
			61 => "DarkSeaGreen", 
			62 => "DarkSlateBlue", 
			63 => "DarkSlateGray", 
			64 => "DarkTurquoise", 
			65 => "DarkViolet", 
			66 => "DeepPink", 
			67 => "DeepSkyBlue", 
			68 => "DimGray", 
			69 => "DodgerBlue", 
			70 => "Firebrick", 
			71 => "FloralWhite", 
			72 => "ForestGreen", 
			73 => "Fuchsia", 
			74 => "Gainsboro", 
			75 => "GhostWhite", 
			76 => "Gold", 
			77 => "Goldenrod", 
			78 => "Gray", 
			79 => "Green", 
			80 => "GreenYellow", 
			81 => "Honeydew", 
			82 => "HotPink", 
			83 => "IndianRed", 
			84 => "Indigo", 
			85 => "Ivory", 
			86 => "Khaki", 
			87 => "Lavender", 
			88 => "LavenderBlush", 
			89 => "LawnGreen", 
			90 => "LemonChiffon", 
			91 => "LightBlue", 
			92 => "LightCoral", 
			93 => "LightCyan", 
			94 => "LightGoldenrodYellow", 
			95 => "LightGray", 
			96 => "LightGreen", 
			97 => "LightPink", 
			98 => "LightSalmon", 
			99 => "LightSeaGreen", 
			100 => "LightSkyBlue", 
			101 => "LightSlateGray", 
			102 => "LightSteelBlue", 
			103 => "LightYellow", 
			104 => "Lime", 
			105 => "LimeGreen", 
			106 => "Linen", 
			107 => "Magenta", 
			108 => "Maroon", 
			109 => "MediumAquamarine", 
			110 => "MediumBlue", 
			111 => "MediumOrchid", 
			112 => "MediumPurple", 
			113 => "MediumSeaGreen", 
			114 => "MediumSlateBlue", 
			115 => "MediumSpringGreen", 
			116 => "MediumTurquoise", 
			117 => "MediumVioletRed", 
			118 => "MidnightBlue", 
			119 => "MintCream", 
			120 => "MistyRose", 
			121 => "Moccasin", 
			122 => "NavajoWhite", 
			123 => "Navy", 
			124 => "OldLace", 
			125 => "Olive", 
			126 => "OliveDrab", 
			127 => "Orange", 
			128 => "OrangeRed", 
			129 => "Orchid", 
			130 => "PaleGoldenrod", 
			131 => "PaleGreen", 
			132 => "PaleTurquoise", 
			133 => "PaleVioletRed", 
			134 => "PapayaWhip", 
			135 => "PeachPuff", 
			136 => "Peru", 
			137 => "Pink", 
			138 => "Plum", 
			139 => "PowderBlue", 
			140 => "Purple", 
			141 => "Red", 
			142 => "RosyBrown", 
			143 => "RoyalBlue", 
			144 => "SaddleBrown", 
			145 => "Salmon", 
			146 => "SandyBrown", 
			147 => "SeaGreen", 
			148 => "SeaShell", 
			149 => "Sienna", 
			150 => "Silver", 
			151 => "SkyBlue", 
			152 => "SlateBlue", 
			153 => "SlateGray", 
			154 => "Snow", 
			155 => "SpringGreen", 
			156 => "SteelBlue", 
			157 => "Tan", 
			158 => "Teal", 
			159 => "Thistle", 
			160 => "Tomato", 
			161 => "Turquoise", 
			162 => "Violet", 
			163 => "Wheat", 
			164 => "White", 
			165 => "WhiteSmoke", 
			166 => "Yellow", 
			167 => "YellowGreen", 
			_ => string.Empty, 
		};
	}

	public static string GetName(KnownColor kc)
	{
		return GetName((short)kc);
	}

	public static SplatColor FindColorMatch(SplatColor c)
	{
		uint num = (uint)c.ToArgb();
		for (int i = 27; i < 167; i++)
		{
			if (num == ArgbValues[i])
			{
				return FromKnownColor((KnownColor)i);
			}
		}
		return SplatColor.Empty;
	}

	public static void Update(int knownColor, int color)
	{
		ArgbValues[knownColor] = (uint)color;
	}
}
[DataContract]
public struct SplatColor(long value, short state, short knownColor, string name) : IEquatable<SplatColor>
{
	[Flags]
	internal enum ColorType : short
	{
		Empty = 0,
		Known = 1,
		ARGB = 2,
		Named = 4,
		System = 8
	}

	private long _value = value;

	private short _state = state;

	private short _knownColor = knownColor;

	private string _name = name;

	public static SplatColor Empty { get; }

	public bool IsEmpty => _state == 0;

	public byte A => (byte)(Value >> 24);

	public byte R => (byte)(Value >> 16);

	public byte G => (byte)(Value >> 8);

	public byte B => (byte)Value;

	public string Name
	{
		get
		{
			if (_name == null)
			{
				if (IsNamedColor)
				{
					_name = KnownColors.GetName(_knownColor);
				}
				else
				{
					_name = $"{ToArgb():x}";
				}
			}
			return _name;
		}
	}

	public bool IsKnownColor => (_state & 1) != 0;

	public bool IsSystemColor => (_state & 8) != 0;

	public bool IsNamedColor => (_state & 5) != 0;

	[DataMember]
	internal long Value
	{
		get
		{
			if (_value == 0L && IsKnownColor)
			{
				_value = KnownColors.FromKnownColor((KnownColor)_knownColor).ToArgb() & 0xFFFFFFFFu;
			}
			return _value;
		}
		set
		{
			_value = value;
		}
	}

	public static SplatColor Transparent => KnownColors.FromKnownColor(KnownColor.Transparent);

	public static SplatColor AliceBlue => KnownColors.FromKnownColor(KnownColor.AliceBlue);

	public static SplatColor AntiqueWhite => KnownColors.FromKnownColor(KnownColor.AntiqueWhite);

	public static SplatColor Aqua => KnownColors.FromKnownColor(KnownColor.Aqua);

	public static SplatColor Aquamarine => KnownColors.FromKnownColor(KnownColor.Aquamarine);

	public static SplatColor Azure => KnownColors.FromKnownColor(KnownColor.Azure);

	public static SplatColor Beige => KnownColors.FromKnownColor(KnownColor.Beige);

	public static SplatColor Bisque => KnownColors.FromKnownColor(KnownColor.Bisque);

	public static SplatColor Black => KnownColors.FromKnownColor(KnownColor.Black);

	public static SplatColor BlanchedAlmond => KnownColors.FromKnownColor(KnownColor.BlanchedAlmond);

	public static SplatColor Blue => KnownColors.FromKnownColor(KnownColor.Blue);

	public static SplatColor BlueViolet => KnownColors.FromKnownColor(KnownColor.BlueViolet);

	public static SplatColor Brown => KnownColors.FromKnownColor(KnownColor.Brown);

	public static SplatColor BurlyWood => KnownColors.FromKnownColor(KnownColor.BurlyWood);

	public static SplatColor CadetBlue => KnownColors.FromKnownColor(KnownColor.CadetBlue);

	public static SplatColor Chartreuse => KnownColors.FromKnownColor(KnownColor.Chartreuse);

	public static SplatColor Chocolate => KnownColors.FromKnownColor(KnownColor.Chocolate);

	public static SplatColor Coral => KnownColors.FromKnownColor(KnownColor.Coral);

	public static SplatColor CornflowerBlue => KnownColors.FromKnownColor(KnownColor.CornflowerBlue);

	public static SplatColor Cornsilk => KnownColors.FromKnownColor(KnownColor.Cornsilk);

	public static SplatColor Crimson => KnownColors.FromKnownColor(KnownColor.Crimson);

	public static SplatColor Cyan => KnownColors.FromKnownColor(KnownColor.Cyan);

	public static SplatColor DarkBlue => KnownColors.FromKnownColor(KnownColor.DarkBlue);

	public static SplatColor DarkCyan => KnownColors.FromKnownColor(KnownColor.DarkCyan);

	public static SplatColor DarkGoldenrod => KnownColors.FromKnownColor(KnownColor.DarkGoldenrod);

	public static SplatColor DarkGray => KnownColors.FromKnownColor(KnownColor.DarkGray);

	public static SplatColor DarkGreen => KnownColors.FromKnownColor(KnownColor.DarkGreen);

	public static SplatColor DarkKhaki => KnownColors.FromKnownColor(KnownColor.DarkKhaki);

	public static SplatColor DarkMagenta => KnownColors.FromKnownColor(KnownColor.DarkMagenta);

	public static SplatColor DarkOliveGreen => KnownColors.FromKnownColor(KnownColor.DarkOliveGreen);

	public static SplatColor DarkOrange => KnownColors.FromKnownColor(KnownColor.DarkOrange);

	public static SplatColor DarkOrchid => KnownColors.FromKnownColor(KnownColor.DarkOrchid);

	public static SplatColor DarkRed => KnownColors.FromKnownColor(KnownColor.DarkRed);

	public static SplatColor DarkSalmon => KnownColors.FromKnownColor(KnownColor.DarkSalmon);

	public static SplatColor DarkSeaGreen => KnownColors.FromKnownColor(KnownColor.DarkSeaGreen);

	public static SplatColor DarkSlateBlue => KnownColors.FromKnownColor(KnownColor.DarkSlateBlue);

	public static SplatColor DarkSlateGray => KnownColors.FromKnownColor(KnownColor.DarkSlateGray);

	public static SplatColor DarkTurquoise => KnownColors.FromKnownColor(KnownColor.DarkTurquoise);

	public static SplatColor DarkViolet => KnownColors.FromKnownColor(KnownColor.DarkViolet);

	public static SplatColor DeepPink => KnownColors.FromKnownColor(KnownColor.DeepPink);

	public static SplatColor DeepSkyBlue => KnownColors.FromKnownColor(KnownColor.DeepSkyBlue);

	public static SplatColor DimGray => KnownColors.FromKnownColor(KnownColor.DimGray);

	public static SplatColor DodgerBlue => KnownColors.FromKnownColor(KnownColor.DodgerBlue);

	public static SplatColor Firebrick => KnownColors.FromKnownColor(KnownColor.Firebrick);

	public static SplatColor FloralWhite => KnownColors.FromKnownColor(KnownColor.FloralWhite);

	public static SplatColor ForestGreen => KnownColors.FromKnownColor(KnownColor.ForestGreen);

	public static SplatColor Fuchsia => KnownColors.FromKnownColor(KnownColor.Fuchsia);

	public static SplatColor Gainsboro => KnownColors.FromKnownColor(KnownColor.Gainsboro);

	public static SplatColor GhostWhite => KnownColors.FromKnownColor(KnownColor.GhostWhite);

	public static SplatColor Gold => KnownColors.FromKnownColor(KnownColor.Gold);

	public static SplatColor Goldenrod => KnownColors.FromKnownColor(KnownColor.Goldenrod);

	public static SplatColor Gray => KnownColors.FromKnownColor(KnownColor.Gray);

	public static SplatColor Green => KnownColors.FromKnownColor(KnownColor.Green);

	public static SplatColor GreenYellow => KnownColors.FromKnownColor(KnownColor.GreenYellow);

	public static SplatColor Honeydew => KnownColors.FromKnownColor(KnownColor.Honeydew);

	public static SplatColor HotPink => KnownColors.FromKnownColor(KnownColor.HotPink);

	public static SplatColor IndianRed => KnownColors.FromKnownColor(KnownColor.IndianRed);

	public static SplatColor Indigo => KnownColors.FromKnownColor(KnownColor.Indigo);

	public static SplatColor Ivory => KnownColors.FromKnownColor(KnownColor.Ivory);

	public static SplatColor Khaki => KnownColors.FromKnownColor(KnownColor.Khaki);

	public static SplatColor Lavender => KnownColors.FromKnownColor(KnownColor.Lavender);

	public static SplatColor LavenderBlush => KnownColors.FromKnownColor(KnownColor.LavenderBlush);

	public static SplatColor LawnGreen => KnownColors.FromKnownColor(KnownColor.LawnGreen);

	public static SplatColor LemonChiffon => KnownColors.FromKnownColor(KnownColor.LemonChiffon);

	public static SplatColor LightBlue => KnownColors.FromKnownColor(KnownColor.LightBlue);

	public static SplatColor LightCoral => KnownColors.FromKnownColor(KnownColor.LightCoral);

	public static SplatColor LightCyan => KnownColors.FromKnownColor(KnownColor.LightCyan);

	public static SplatColor LightGoldenrodYellow => KnownColors.FromKnownColor(KnownColor.LightGoldenrodYellow);

	public static SplatColor LightGreen => KnownColors.FromKnownColor(KnownColor.LightGreen);

	public static SplatColor LightGray => KnownColors.FromKnownColor(KnownColor.LightGray);

	public static SplatColor LightPink => KnownColors.FromKnownColor(KnownColor.LightPink);

	public static SplatColor LightSalmon => KnownColors.FromKnownColor(KnownColor.LightSalmon);

	public static SplatColor LightSeaGreen => KnownColors.FromKnownColor(KnownColor.LightSeaGreen);

	public static SplatColor LightSkyBlue => KnownColors.FromKnownColor(KnownColor.LightSkyBlue);

	public static SplatColor LightSlateGray => KnownColors.FromKnownColor(KnownColor.LightSlateGray);

	public static SplatColor LightSteelBlue => KnownColors.FromKnownColor(KnownColor.LightSteelBlue);

	public static SplatColor LightYellow => KnownColors.FromKnownColor(KnownColor.LightYellow);

	public static SplatColor Lime => KnownColors.FromKnownColor(KnownColor.Lime);

	public static SplatColor LimeGreen => KnownColors.FromKnownColor(KnownColor.LimeGreen);

	public static SplatColor Linen => KnownColors.FromKnownColor(KnownColor.Linen);

	public static SplatColor Magenta => KnownColors.FromKnownColor(KnownColor.Magenta);

	public static SplatColor Maroon => KnownColors.FromKnownColor(KnownColor.Maroon);

	public static SplatColor MediumAquamarine => KnownColors.FromKnownColor(KnownColor.MediumAquamarine);

	public static SplatColor MediumBlue => KnownColors.FromKnownColor(KnownColor.MediumBlue);

	public static SplatColor MediumOrchid => KnownColors.FromKnownColor(KnownColor.MediumOrchid);

	public static SplatColor MediumPurple => KnownColors.FromKnownColor(KnownColor.MediumPurple);

	public static SplatColor MediumSeaGreen => KnownColors.FromKnownColor(KnownColor.MediumSeaGreen);

	public static SplatColor MediumSlateBlue => KnownColors.FromKnownColor(KnownColor.MediumSlateBlue);

	public static SplatColor MediumSpringGreen => KnownColors.FromKnownColor(KnownColor.MediumSpringGreen);

	public static SplatColor MediumTurquoise => KnownColors.FromKnownColor(KnownColor.MediumTurquoise);

	public static SplatColor MediumVioletRed => KnownColors.FromKnownColor(KnownColor.MediumVioletRed);

	public static SplatColor MidnightBlue => KnownColors.FromKnownColor(KnownColor.MidnightBlue);

	public static SplatColor MintCream => KnownColors.FromKnownColor(KnownColor.MintCream);

	public static SplatColor MistyRose => KnownColors.FromKnownColor(KnownColor.MistyRose);

	public static SplatColor Moccasin => KnownColors.FromKnownColor(KnownColor.Moccasin);

	public static SplatColor NavajoWhite => KnownColors.FromKnownColor(KnownColor.NavajoWhite);

	public static SplatColor Navy => KnownColors.FromKnownColor(KnownColor.Navy);

	public static SplatColor OldLace => KnownColors.FromKnownColor(KnownColor.OldLace);

	public static SplatColor Olive => KnownColors.FromKnownColor(KnownColor.Olive);

	public static SplatColor OliveDrab => KnownColors.FromKnownColor(KnownColor.OliveDrab);

	public static SplatColor Orange => KnownColors.FromKnownColor(KnownColor.Orange);

	public static SplatColor OrangeRed => KnownColors.FromKnownColor(KnownColor.OrangeRed);

	public static SplatColor Orchid => KnownColors.FromKnownColor(KnownColor.Orchid);

	public static SplatColor PaleGoldenrod => KnownColors.FromKnownColor(KnownColor.PaleGoldenrod);

	public static SplatColor PaleGreen => KnownColors.FromKnownColor(KnownColor.PaleGreen);

	public static SplatColor PaleTurquoise => KnownColors.FromKnownColor(KnownColor.PaleTurquoise);

	public static SplatColor PaleVioletRed => KnownColors.FromKnownColor(KnownColor.PaleVioletRed);

	public static SplatColor PapayaWhip => KnownColors.FromKnownColor(KnownColor.PapayaWhip);

	public static SplatColor PeachPuff => KnownColors.FromKnownColor(KnownColor.PeachPuff);

	public static SplatColor Peru => KnownColors.FromKnownColor(KnownColor.Peru);

	public static SplatColor Pink => KnownColors.FromKnownColor(KnownColor.Pink);

	public static SplatColor Plum => KnownColors.FromKnownColor(KnownColor.Plum);

	public static SplatColor PowderBlue => KnownColors.FromKnownColor(KnownColor.PowderBlue);

	public static SplatColor Purple => KnownColors.FromKnownColor(KnownColor.Purple);

	public static SplatColor Red => KnownColors.FromKnownColor(KnownColor.Red);

	public static SplatColor RosyBrown => KnownColors.FromKnownColor(KnownColor.RosyBrown);

	public static SplatColor RoyalBlue => KnownColors.FromKnownColor(KnownColor.RoyalBlue);

	public static SplatColor SaddleBrown => KnownColors.FromKnownColor(KnownColor.SaddleBrown);

	public static SplatColor Salmon => KnownColors.FromKnownColor(KnownColor.Salmon);

	public static SplatColor SandyBrown => KnownColors.FromKnownColor(KnownColor.SandyBrown);

	public static SplatColor SeaGreen => KnownColors.FromKnownColor(KnownColor.SeaGreen);

	public static SplatColor SeaShell => KnownColors.FromKnownColor(KnownColor.SeaShell);

	public static SplatColor Sienna => KnownColors.FromKnownColor(KnownColor.Sienna);

	public static SplatColor Silver => KnownColors.FromKnownColor(KnownColor.Silver);

	public static SplatColor SkyBlue => KnownColors.FromKnownColor(KnownColor.SkyBlue);

	public static SplatColor SlateBlue => KnownColors.FromKnownColor(KnownColor.SlateBlue);

	public static SplatColor SlateGray => KnownColors.FromKnownColor(KnownColor.SlateGray);

	public static SplatColor Snow => KnownColors.FromKnownColor(KnownColor.Snow);

	public static SplatColor SpringGreen => KnownColors.FromKnownColor(KnownColor.SpringGreen);

	public static SplatColor SteelBlue => KnownColors.FromKnownColor(KnownColor.SteelBlue);

	public static SplatColor Tan => KnownColors.FromKnownColor(KnownColor.Tan);

	public static SplatColor Teal => KnownColors.FromKnownColor(KnownColor.Teal);

	public static SplatColor Thistle => KnownColors.FromKnownColor(KnownColor.Thistle);

	public static SplatColor Tomato => KnownColors.FromKnownColor(KnownColor.Tomato);

	public static SplatColor Turquoise => KnownColors.FromKnownColor(KnownColor.Turquoise);

	public static SplatColor Violet => KnownColors.FromKnownColor(KnownColor.Violet);

	public static SplatColor Wheat => KnownColors.FromKnownColor(KnownColor.Wheat);

	public static SplatColor White => KnownColors.FromKnownColor(KnownColor.White);

	public static SplatColor WhiteSmoke => KnownColors.FromKnownColor(KnownColor.WhiteSmoke);

	public static SplatColor Yellow => KnownColors.FromKnownColor(KnownColor.Yellow);

	public static SplatColor YellowGreen => KnownColors.FromKnownColor(KnownColor.YellowGreen);

	public static bool operator ==(SplatColor left, SplatColor right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SplatColor left, SplatColor right)
	{
		return !(left == right);
	}

	public static SplatColor FromArgb(int red, int green, int blue)
	{
		return FromArgb(255, red, green, blue);
	}

	public static SplatColor FromArgb(int alpha, int red, int green, int blue)
	{
		CheckARGBValues(alpha, red, green, blue);
		return new SplatColor
		{
			_state = 2,
			Value = (alpha << 24) + (red << 16) + (green << 8) + blue
		};
	}

	public static SplatColor FromArgb(int alpha, SplatColor baseColor)
	{
		return FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);
	}

	public static SplatColor FromArgb(int argb)
	{
		return FromArgb((argb >> 24) & 0xFF, (argb >> 16) & 0xFF, (argb >> 8) & 0xFF, argb & 0xFF);
	}

	public static SplatColor FromKnownColor(KnownColor color)
	{
		short num = (short)color;
		SplatColor result;
		if (num <= 0 || num >= KnownColors.ArgbValues.Length)
		{
			result = FromArgb(0, 0, 0, 0);
			result._state |= 4;
		}
		else
		{
			result = Empty;
			result._state = 7;
			if (num < 27 || num > 169)
			{
				result._state |= 8;
			}
			result.Value = KnownColors.ArgbValues[num];
		}
		result._knownColor = num;
		return result;
	}

	public static SplatColor FromName(string name)
	{
		try
		{
			return FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), name, ignoreCase: true));
		}
		catch (Exception exception)
		{
			LogHost.Default.Debug(exception, "Unable to parse the known colour name.");
			SplatColor result = FromArgb(0, 0, 0, 0);
			result._name = name;
			result._state |= 4;
			return result;
		}
	}

	public float GetBrightness()
	{
		byte b = Math.Min(R, Math.Min(G, B));
		return (float)(Math.Max(R, Math.Max(G, B)) + b) / 510f;
	}

	public float GetSaturation()
	{
		byte b = Math.Min(R, Math.Min(G, B));
		byte b2 = Math.Max(R, Math.Max(G, B));
		if (b2 == b)
		{
			return 0f;
		}
		int num = b2 + b;
		if (num > 255)
		{
			num = 510 - num;
		}
		return (float)(b2 - b) / (float)num;
	}

	public int ToArgb()
	{
		return (int)Value;
	}

	public float GetHue()
	{
		int r = R;
		int g = G;
		int b = B;
		byte b2 = (byte)Math.Min(r, Math.Min(g, b));
		byte b3 = (byte)Math.Max(r, Math.Max(g, b));
		if (b3 == b2)
		{
			return 0f;
		}
		float num = b3 - b2;
		float num2 = (float)(b3 - r) / num;
		float num3 = (float)(b3 - g) / num;
		float num4 = (float)(b3 - b) / num;
		float num5 = 0f;
		if (r == b3)
		{
			num5 = 60f * (6f + num4 - num3);
		}
		if (g == b3)
		{
			num5 = 60f * (2f + num2 - num4);
		}
		if (b == b3)
		{
			num5 = 60f * (4f + num3 - num2);
		}
		if (num5 > 360f)
		{
			num5 -= 360f;
		}
		return num5;
	}

	public KnownColor ToKnownColor()
	{
		return (KnownColor)_knownColor;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is SplatColor))
		{
			return false;
		}
		return Equals((SplatColor)obj);
	}

	public bool Equals(SplatColor other)
	{
		if (Value != other.Value)
		{
			return false;
		}
		if (IsNamedColor != other.IsNamedColor)
		{
			return false;
		}
		if (IsSystemColor != other.IsSystemColor)
		{
			return false;
		}
		if (IsEmpty != other.IsEmpty)
		{
			return false;
		}
		if (IsNamedColor && Name != other.Name)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = (int)(Value ^ (Value >> 32) ^ _state ^ (_knownColor >> 16));
		if (IsNamedColor)
		{
			num ^= StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
		}
		return num;
	}

	public override string ToString()
	{
		if (IsEmpty)
		{
			return "SplatColor [Empty]";
		}
		if (IsNamedColor)
		{
			return "SplatColor [" + Name + "]";
		}
		return $"SplatColor [A={A}, R={R}, G={G}, B={B}]";
	}

	private static void CheckRGBValues(int red, int green, int blue)
	{
		if (red > 255 || red < 0)
		{
			throw CreateColorArgumentException(red, "red");
		}
		if (green > 255 || green < 0)
		{
			throw CreateColorArgumentException(green, "green");
		}
		if (blue > 255 || blue < 0)
		{
			throw CreateColorArgumentException(blue, "blue");
		}
	}

	private static ArgumentException CreateColorArgumentException(int value, string color)
	{
		return new ArgumentException($"'{value}' is not a valid value for '{color}'. '{color}' should be greater or equal to 0 and less than or equal to 255.");
	}

	private static void CheckARGBValues(int alpha, int red, int green, int blue)
	{
		if (alpha > 255 || alpha < 0)
		{
			throw CreateColorArgumentException(alpha, "alpha");
		}
		CheckRGBValues(red, green, blue);
	}
}
public class DefaultPlatformModeDetector : IPlatformModeDetector
{
	private const string XamlDesignPropertiesType = "System.ComponentModel.DesignerProperties, System.Windows, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e";

	private const string XamlControlBorderType = "System.Windows.Controls.Border, System.Windows, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e";

	private const string XamlDesignPropertiesDesignModeMethodName = "GetIsInDesignMode";

	private const string WpfDesignerPropertiesType = "System.ComponentModel.DesignerProperties, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";

	private const string WpfDesignerPropertiesDesignModeMethod = "GetIsInDesignMode";

	private const string WpfDependencyPropertyType = "System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";

	private const string WinFormsDesignerPropertiesType = "Windows.ApplicationModel.DesignMode, Windows, ContentType=WindowsRuntime";

	private const string WinFormsDesignerPropertiesDesignModeMethod = "DesignModeEnabled";

	private static bool? _cachedInDesignModeResult;

	public bool? InDesignMode()
	{
		if (_cachedInDesignModeResult.HasValue)
		{
			return _cachedInDesignModeResult.Value;
		}
		Type type = Type.GetType("System.ComponentModel.DesignerProperties, System.Windows, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", throwOnError: false);
		if (type != null)
		{
			MethodInfo method = type.GetMethod("GetIsInDesignMode");
			Type type2 = Type.GetType("System.Windows.Controls.Border, System.Windows, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", throwOnError: false);
			if (type2 != null)
			{
				_cachedInDesignModeResult = (bool)method.Invoke(null, new object[1] { Activator.CreateInstance(type2) });
			}
		}
		else if ((type = Type.GetType("System.ComponentModel.DesignerProperties, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", throwOnError: false)) != null)
		{
			MethodInfo method2 = type.GetMethod("GetIsInDesignMode");
			Type type3 = Type.GetType("System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", throwOnError: false);
			if (type3 != null)
			{
				_cachedInDesignModeResult = (bool)method2.Invoke(null, new object[1] { Activator.CreateInstance(type3) });
			}
		}
		else if ((type = Type.GetType("Windows.ApplicationModel.DesignMode, Windows, ContentType=WindowsRuntime", throwOnError: false)) != null)
		{
			_cachedInDesignModeResult = (bool)type.GetProperty("DesignModeEnabled").GetMethod.Invoke(null, null);
		}
		else
		{
			string[] source = new string[2] { "BLEND.EXE", "XDESPROC.EXE" };
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			if (entryAssembly != null)
			{
				string exeName = new FileInfo(entryAssembly.Location).Name;
				if (source.Any((string x) => x.IndexOf(exeName, StringComparison.InvariantCultureIgnoreCase) != -1))
				{
					_cachedInDesignModeResult = true;
				}
			}
		}
		_cachedInDesignModeResult = false;
		return _cachedInDesignModeResult;
	}
}
public interface IPlatformModeDetector
{
	bool? InDesignMode();
}
public static class PlatformModeDetector
{
	private static bool? cachedInDesignModeResult;

	private static IPlatformModeDetector Current { get; set; }

	static PlatformModeDetector()
	{
		Current = new DefaultPlatformModeDetector();
	}

	public static void OverrideModeDetector(IPlatformModeDetector modeDetector)
	{
		Current = modeDetector;
		cachedInDesignModeResult = null;
	}

	public static bool InDesignMode()
	{
		if (cachedInDesignModeResult.HasValue)
		{
			return cachedInDesignModeResult.Value;
		}
		if (Current != null)
		{
			cachedInDesignModeResult = Current.InDesignMode();
			if (cachedInDesignModeResult.HasValue)
			{
				return cachedInDesignModeResult.Value;
			}
		}
		return cachedInDesignModeResult == true;
	}
}
public static class ServiceLocationDrawingInitialization
{
	public static void RegisterPlatformBitmapLoader(this IMutableDependencyResolver resolver)
	{
		if (resolver == null)
		{
			throw new ArgumentNullException("resolver");
		}
		if (!resolver.HasRegistration(typeof(IBitmapLoader)))
		{
			resolver.RegisterLazySingleton(() => new PlatformBitmapLoader(), typeof(IBitmapLoader));
		}
	}
}
internal sealed class AndroidBitmap : IBitmap, IDisposable
{
	private Bitmap _inner;

	public float Width => _inner.Width;

	public float Height => _inner.Height;

	internal Bitmap Inner => _inner;

	public AndroidBitmap(Bitmap inner)
	{
		_inner = inner;
	}

	public Task Save(CompressedBitmapFormat format, float quality, Stream target)
	{
		Bitmap.CompressFormat fmt = ((format == CompressedBitmapFormat.Jpeg) ? Bitmap.CompressFormat.Jpeg : Bitmap.CompressFormat.Png);
		return Task.Run(() => _inner.Compress(fmt, (int)(quality * 100f), target));
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _inner, null)?.Dispose();
	}
}
public static class BitmapMixins
{
	public static Drawable ToNative(this IBitmap value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (value is AndroidBitmap)
		{
			return new BitmapDrawable(Application.Context.Resources, ((AndroidBitmap)value).Inner);
		}
		return ((DrawableBitmap)value).Inner;
	}

	public static IBitmap FromNative(this Bitmap value, bool copy = false)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (copy)
		{
			return new AndroidBitmap(value.Copy(value.GetConfig(), isMutable: true));
		}
		return new AndroidBitmap(value);
	}

	public static IBitmap FromNative(this Drawable value)
	{
		return new DrawableBitmap(value);
	}
}
internal sealed class DrawableBitmap : IBitmap, IDisposable
{
	private Drawable _inner;

	public float Width => Inner.IntrinsicWidth;

	public float Height => Inner.IntrinsicHeight;

	internal Drawable Inner => _inner;

	public DrawableBitmap(Drawable inner)
	{
		_inner = inner;
	}

	public Task Save(CompressedBitmapFormat format, float quality, Stream target)
	{
		throw new NotSupportedException("You can't save resources");
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _inner, null)?.Dispose();
	}
}
public class PlatformBitmapLoader : IBitmapLoader
{
	private readonly Dictionary<string, int> _drawableList;

	public PlatformBitmapLoader()
	{
		_drawableList = GetDrawableList();
	}

	public async Task<IBitmap> Load(Stream sourceStream, float? desiredWidth, float? desiredHeight)
	{
		if (sourceStream == null)
		{
			throw new ArgumentNullException("sourceStream");
		}
		sourceStream.Position = 0L;
		Bitmap bitmap;
		if (!desiredWidth.HasValue)
		{
			bitmap = await Task.Run(() => BitmapFactory.DecodeStream(sourceStream)).ConfigureAwait(continueOnCapturedContext: false);
		}
		else
		{
			BitmapFactory.Options opts = new BitmapFactory.Options
			{
				OutWidth = (int)desiredWidth.Value,
				OutHeight = (int)desiredHeight.Value
			};
			Rect noPadding = new Rect(0, 0, 0, 0);
			bitmap = await Task.Run(() => BitmapFactory.DecodeStream(sourceStream, noPadding, opts)).ConfigureAwait(continueOnCapturedContext: true);
		}
		if (bitmap == null)
		{
			throw new IOException("Failed to load bitmap from source stream");
		}
		return bitmap.FromNative();
	}

	public Task<IBitmap> LoadFromResource(string source, float? desiredWidth, float? desiredHeight)
	{
		if (_drawableList == null)
		{
			throw new InvalidOperationException("No resources found in any of the drawable folders.");
		}
		Resources res = Application.Context.Resources;
		Resources.Theme theme = Application.Context.Theme;
		int id = 0;
		if (int.TryParse(source, out id))
		{
			return Task.Run((Func<IBitmap>)(() => new DrawableBitmap(res.GetDrawable(id, theme))));
		}
		if (_drawableList.ContainsKey(source))
		{
			return Task.Run((Func<IBitmap>)(() => new DrawableBitmap(res.GetDrawable(_drawableList[source], theme))));
		}
		string key = System.IO.Path.GetFileNameWithoutExtension(source);
		if (_drawableList.ContainsKey(key))
		{
			return Task.Run((Func<IBitmap>)(() => new DrawableBitmap(res.GetDrawable(_drawableList[key], theme))));
		}
		throw new ArgumentException("Either pass in an integer ID cast to a string, or the name of a drawable resource");
	}

	public IBitmap Create(float width, float height)
	{
		return Bitmap.CreateBitmap((int)width, (int)height, Bitmap.Config.Argb8888).FromNative();
	}

	internal static Dictionary<string, int> GetDrawableList(IFullLogger log)
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		return GetDrawableList(log, assemblies);
	}

	internal static Dictionary<string, int> GetDrawableList(IFullLogger log, Assembly[] assemblies)
	{
		Type[] drawableTypes = (from x in assemblies.SelectMany((Assembly a) => GetTypesFromAssembly(a, log))
			where x.Name == "Resource" && x.GetNestedType("Drawable") != null
			select x.GetNestedType("Drawable")).ToArray();
		if (log != null)
		{
			log.Debug(() => "DrawableList. Got " + drawableTypes.Length + " types.");
			Type[] array = drawableTypes;
			foreach (Type drawableType in array)
			{
				log.Debug(() => "DrawableList Type: " + drawableType.Name);
			}
		}
		Dictionary<string, int> result = (from x in drawableTypes.SelectMany((Type x) => x.GetFields())
			where x.FieldType == typeof(int) && x.IsLiteral
			select x).ToDictionary((FieldInfo k) => k.Name, (FieldInfo v) => (int)v.GetRawConstantValue());
		if (log != null)
		{
			log.Debug(() => "DrawableList. Got " + result.Count + " items.");
			foreach (KeyValuePair<string, int> keyValuePair in result)
			{
				log.Debug(() => "DrawableList Item: " + keyValuePair.Key);
			}
		}
		return result;
	}

	internal static Type[] GetTypesFromAssembly(Assembly assembly, IFullLogger log)
	{
		try
		{
			return assembly.GetTypes();
		}
		catch (ReflectionTypeLoadException ex)
		{
			if (log != null)
			{
				log.Warn(ex, "Exception while detecting drawing types.");
				Exception[] loaderExceptions = ex.LoaderExceptions;
				foreach (Exception exception in loaderExceptions)
				{
					log.Warn(exception, "Inner Exception for detecting drawing types.");
				}
			}
			return (ex.Types != null) ? ex.Types.Where((Type x) => x != null).ToArray() : Array.Empty<Type>();
		}
	}

	private Dictionary<string, int> GetDrawableList()
	{
		return GetDrawableList(Locator.Current.GetService<ILogManager>().GetLogger(typeof(PlatformBitmapLoader)));
	}
}
public static class ColorExtensions
{
	public static Android.Graphics.Color ToNative(this System.Drawing.Color other)
	{
		return new Android.Graphics.Color(other.R, other.G, other.B, other.A);
	}

	public static System.Drawing.Color FromNative(this Android.Graphics.Color other)
	{
		return System.Drawing.Color.FromArgb(other.A, other.R, other.G, other.B);
	}
}
public static class SplatColorExtensions
{
	public static Android.Graphics.Color ToNative(this SplatColor value)
	{
		return new Android.Graphics.Color(value.R, value.G, value.B, value.A);
	}

	public static SplatColor FromNative(this Android.Graphics.Color value)
	{
		return SplatColor.FromArgb(value.A, value.R, value.G, value.B);
	}
}
public static class PointExtensions
{
	public static Android.Graphics.Point ToNative(this System.Drawing.Point value)
	{
		return new Android.Graphics.Point(value.X, value.Y);
	}

	public static Android.Graphics.PointF ToNative(this System.Drawing.PointF value)
	{
		return new Android.Graphics.PointF(value.X, value.Y);
	}

	public static System.Drawing.Point FromNative(this Android.Graphics.Point value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		return new System.Drawing.Point(value.X, value.Y);
	}

	public static System.Drawing.PointF FromNative(this Android.Graphics.PointF value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		return new System.Drawing.PointF(value.X, value.Y);
	}
}
public static class RectExtensions
{
	public static Rect ToNative(this Rectangle value)
	{
		return new Rect(value.X, value.Y, value.X + value.Width, value.Y + value.Height);
	}

	public static RectF ToNative(this RectangleF value)
	{
		return new RectF(value.X, value.Y, value.X + value.Width, value.Y + value.Height);
	}

	public static Rectangle FromNative(this Rect value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		return new Rectangle(value.Left, value.Top, value.Width(), value.Height());
	}

	public static RectangleF FromNative(this RectF value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		return new RectangleF(value.Left, value.Top, value.Width(), value.Height());
	}
}
