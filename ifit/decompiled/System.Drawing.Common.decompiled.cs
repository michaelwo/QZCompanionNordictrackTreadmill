using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Globalization;
using System.Numerics.Hashing;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("System.Drawing.Common")]
[assembly: AssemblyDescription("System.Drawing.Common")]
[assembly: AssemblyDefaultAlias("System.Drawing.Common")]
[assembly: AssemblyCompany("Mono development team")]
[assembly: AssemblyProduct("Mono Common Language Infrastructure")]
[assembly: AssemblyCopyright("(c) Various Mono authors")]
[assembly: AssemblyInformationalVersion("4.0.0.0")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: AssemblyVersion("4.0.0.0")]
internal static class SR
{
	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			return string.Format(CultureInfo.InvariantCulture, resourceFormat, args);
		}
		return resourceFormat;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		return string.Format(CultureInfo.InvariantCulture, resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		return string.Format(CultureInfo.InvariantCulture, resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		return string.Format(CultureInfo.InvariantCulture, resourceFormat, p1, p2, p3);
	}
}
namespace System.Numerics.Hashing
{
	internal static class HashHelpers
	{
		public static int Combine(int h1, int h2)
		{
			return (((h1 << 5) | (h1 >>> 27)) + h1) ^ h2;
		}
	}
}
namespace System.Drawing
{
	internal static class ColorTable
	{
		private static readonly Lazy<Dictionary<string, Color>> s_colorConstants = new Lazy<Dictionary<string, Color>>(GetColors);

		internal static Dictionary<string, Color> Colors => s_colorConstants.Value;

		private static Dictionary<string, Color> GetColors()
		{
			Dictionary<string, Color> dictionary = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase);
			FillConstants(dictionary, typeof(Color));
			FillConstants(dictionary, typeof(SystemColors));
			return dictionary;
		}

		private static void FillConstants(Dictionary<string, Color> colors, Type enumType)
		{
			PropertyInfo[] properties = enumType.GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.PropertyType == typeof(Color))
				{
					colors[propertyInfo.Name] = (Color)propertyInfo.GetValue(null, null);
				}
			}
		}

		internal static bool TryGetNamedColor(string name, out Color result)
		{
			return Colors.TryGetValue(name, out result);
		}
	}
	[TypeForwardedFrom("Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065")]
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
	internal static class KnownColorTable
	{
		private static int[] s_colorTable;

		private static string[] s_colorNameTable;

		private static void EnsureColorTable()
		{
			if (s_colorTable == null)
			{
				InitColorTable();
			}
		}

		private static void InitColorTable()
		{
			int[] array = new int[175];
			UpdateSystemColors(array);
			array[27] = 16777215;
			array[28] = -984833;
			array[29] = -332841;
			array[30] = -16711681;
			array[31] = -8388652;
			array[32] = -983041;
			array[33] = -657956;
			array[34] = -6972;
			array[35] = -16777216;
			array[36] = -5171;
			array[37] = -16776961;
			array[38] = -7722014;
			array[39] = -5952982;
			array[40] = -2180985;
			array[41] = -10510688;
			array[42] = -8388864;
			array[43] = -2987746;
			array[44] = -32944;
			array[45] = -10185235;
			array[46] = -1828;
			array[47] = -2354116;
			array[48] = -16711681;
			array[49] = -16777077;
			array[50] = -16741493;
			array[51] = -4684277;
			array[52] = -5658199;
			array[53] = -16751616;
			array[54] = -4343957;
			array[55] = -7667573;
			array[56] = -11179217;
			array[57] = -29696;
			array[58] = -6737204;
			array[59] = -7667712;
			array[60] = -1468806;
			array[61] = -7357301;
			array[62] = -12042869;
			array[63] = -13676721;
			array[64] = -16724271;
			array[65] = -7077677;
			array[66] = -60269;
			array[67] = -16728065;
			array[68] = -9868951;
			array[69] = -14774017;
			array[70] = -5103070;
			array[71] = -1296;
			array[72] = -14513374;
			array[73] = -65281;
			array[74] = -2302756;
			array[75] = -460545;
			array[76] = -10496;
			array[77] = -2448096;
			array[78] = -8355712;
			array[79] = -16744448;
			array[80] = -5374161;
			array[81] = -983056;
			array[82] = -38476;
			array[83] = -3318692;
			array[84] = -11861886;
			array[85] = -16;
			array[86] = -989556;
			array[87] = -1644806;
			array[88] = -3851;
			array[89] = -8586240;
			array[90] = -1331;
			array[91] = -5383962;
			array[92] = -1015680;
			array[93] = -2031617;
			array[94] = -329006;
			array[95] = -2894893;
			array[96] = -7278960;
			array[97] = -18751;
			array[98] = -24454;
			array[99] = -14634326;
			array[100] = -7876870;
			array[101] = -8943463;
			array[102] = -5192482;
			array[103] = -32;
			array[104] = -16711936;
			array[105] = -13447886;
			array[106] = -331546;
			array[107] = -65281;
			array[108] = -8388608;
			array[109] = -10039894;
			array[110] = -16777011;
			array[111] = -4565549;
			array[112] = -7114533;
			array[113] = -12799119;
			array[114] = -8689426;
			array[115] = -16713062;
			array[116] = -12004916;
			array[117] = -3730043;
			array[118] = -15132304;
			array[119] = -655366;
			array[120] = -6943;
			array[121] = -6987;
			array[122] = -8531;
			array[123] = -16777088;
			array[124] = -133658;
			array[125] = -8355840;
			array[126] = -9728477;
			array[127] = -23296;
			array[128] = -47872;
			array[129] = -2461482;
			array[130] = -1120086;
			array[131] = -6751336;
			array[132] = -5247250;
			array[133] = -2396013;
			array[134] = -4139;
			array[135] = -9543;
			array[136] = -3308225;
			array[137] = -16181;
			array[138] = -2252579;
			array[139] = -5185306;
			array[140] = -8388480;
			array[141] = -65536;
			array[142] = -4419697;
			array[143] = -12490271;
			array[144] = -7650029;
			array[145] = -360334;
			array[146] = -744352;
			array[147] = -13726889;
			array[148] = -2578;
			array[149] = -6270419;
			array[150] = -4144960;
			array[151] = -7876885;
			array[152] = -9807155;
			array[153] = -9404272;
			array[154] = -1286;
			array[155] = -16711809;
			array[156] = -12156236;
			array[157] = -2968436;
			array[158] = -16744320;
			array[159] = -2572328;
			array[160] = -40121;
			array[161] = -12525360;
			array[162] = -1146130;
			array[163] = -663885;
			array[164] = -1;
			array[165] = -657931;
			array[166] = -256;
			array[167] = -6632142;
			s_colorTable = array;
		}

		private static void EnsureColorNameTable()
		{
			if (s_colorNameTable == null)
			{
				InitColorNameTable();
			}
		}

		private static void InitColorNameTable()
		{
			string[] array = new string[175];
			array[1] = "ActiveBorder";
			array[2] = "ActiveCaption";
			array[3] = "ActiveCaptionText";
			array[4] = "AppWorkspace";
			array[168] = "ButtonFace";
			array[169] = "ButtonHighlight";
			array[170] = "ButtonShadow";
			array[5] = "Control";
			array[6] = "ControlDark";
			array[7] = "ControlDarkDark";
			array[8] = "ControlLight";
			array[9] = "ControlLightLight";
			array[10] = "ControlText";
			array[11] = "Desktop";
			array[171] = "GradientActiveCaption";
			array[172] = "GradientInactiveCaption";
			array[12] = "GrayText";
			array[13] = "Highlight";
			array[14] = "HighlightText";
			array[15] = "HotTrack";
			array[16] = "InactiveBorder";
			array[17] = "InactiveCaption";
			array[18] = "InactiveCaptionText";
			array[19] = "Info";
			array[20] = "InfoText";
			array[21] = "Menu";
			array[173] = "MenuBar";
			array[174] = "MenuHighlight";
			array[22] = "MenuText";
			array[23] = "ScrollBar";
			array[24] = "Window";
			array[25] = "WindowFrame";
			array[26] = "WindowText";
			array[27] = "Transparent";
			array[28] = "AliceBlue";
			array[29] = "AntiqueWhite";
			array[30] = "Aqua";
			array[31] = "Aquamarine";
			array[32] = "Azure";
			array[33] = "Beige";
			array[34] = "Bisque";
			array[35] = "Black";
			array[36] = "BlanchedAlmond";
			array[37] = "Blue";
			array[38] = "BlueViolet";
			array[39] = "Brown";
			array[40] = "BurlyWood";
			array[41] = "CadetBlue";
			array[42] = "Chartreuse";
			array[43] = "Chocolate";
			array[44] = "Coral";
			array[45] = "CornflowerBlue";
			array[46] = "Cornsilk";
			array[47] = "Crimson";
			array[48] = "Cyan";
			array[49] = "DarkBlue";
			array[50] = "DarkCyan";
			array[51] = "DarkGoldenrod";
			array[52] = "DarkGray";
			array[53] = "DarkGreen";
			array[54] = "DarkKhaki";
			array[55] = "DarkMagenta";
			array[56] = "DarkOliveGreen";
			array[57] = "DarkOrange";
			array[58] = "DarkOrchid";
			array[59] = "DarkRed";
			array[60] = "DarkSalmon";
			array[61] = "DarkSeaGreen";
			array[62] = "DarkSlateBlue";
			array[63] = "DarkSlateGray";
			array[64] = "DarkTurquoise";
			array[65] = "DarkViolet";
			array[66] = "DeepPink";
			array[67] = "DeepSkyBlue";
			array[68] = "DimGray";
			array[69] = "DodgerBlue";
			array[70] = "Firebrick";
			array[71] = "FloralWhite";
			array[72] = "ForestGreen";
			array[73] = "Fuchsia";
			array[74] = "Gainsboro";
			array[75] = "GhostWhite";
			array[76] = "Gold";
			array[77] = "Goldenrod";
			array[78] = "Gray";
			array[79] = "Green";
			array[80] = "GreenYellow";
			array[81] = "Honeydew";
			array[82] = "HotPink";
			array[83] = "IndianRed";
			array[84] = "Indigo";
			array[85] = "Ivory";
			array[86] = "Khaki";
			array[87] = "Lavender";
			array[88] = "LavenderBlush";
			array[89] = "LawnGreen";
			array[90] = "LemonChiffon";
			array[91] = "LightBlue";
			array[92] = "LightCoral";
			array[93] = "LightCyan";
			array[94] = "LightGoldenrodYellow";
			array[95] = "LightGray";
			array[96] = "LightGreen";
			array[97] = "LightPink";
			array[98] = "LightSalmon";
			array[99] = "LightSeaGreen";
			array[100] = "LightSkyBlue";
			array[101] = "LightSlateGray";
			array[102] = "LightSteelBlue";
			array[103] = "LightYellow";
			array[104] = "Lime";
			array[105] = "LimeGreen";
			array[106] = "Linen";
			array[107] = "Magenta";
			array[108] = "Maroon";
			array[109] = "MediumAquamarine";
			array[110] = "MediumBlue";
			array[111] = "MediumOrchid";
			array[112] = "MediumPurple";
			array[113] = "MediumSeaGreen";
			array[114] = "MediumSlateBlue";
			array[115] = "MediumSpringGreen";
			array[116] = "MediumTurquoise";
			array[117] = "MediumVioletRed";
			array[118] = "MidnightBlue";
			array[119] = "MintCream";
			array[120] = "MistyRose";
			array[121] = "Moccasin";
			array[122] = "NavajoWhite";
			array[123] = "Navy";
			array[124] = "OldLace";
			array[125] = "Olive";
			array[126] = "OliveDrab";
			array[127] = "Orange";
			array[128] = "OrangeRed";
			array[129] = "Orchid";
			array[130] = "PaleGoldenrod";
			array[131] = "PaleGreen";
			array[132] = "PaleTurquoise";
			array[133] = "PaleVioletRed";
			array[134] = "PapayaWhip";
			array[135] = "PeachPuff";
			array[136] = "Peru";
			array[137] = "Pink";
			array[138] = "Plum";
			array[139] = "PowderBlue";
			array[140] = "Purple";
			array[141] = "Red";
			array[142] = "RosyBrown";
			array[143] = "RoyalBlue";
			array[144] = "SaddleBrown";
			array[145] = "Salmon";
			array[146] = "SandyBrown";
			array[147] = "SeaGreen";
			array[148] = "SeaShell";
			array[149] = "Sienna";
			array[150] = "Silver";
			array[151] = "SkyBlue";
			array[152] = "SlateBlue";
			array[153] = "SlateGray";
			array[154] = "Snow";
			array[155] = "SpringGreen";
			array[156] = "SteelBlue";
			array[157] = "Tan";
			array[158] = "Teal";
			array[159] = "Thistle";
			array[160] = "Tomato";
			array[161] = "Turquoise";
			array[162] = "Violet";
			array[163] = "Wheat";
			array[164] = "White";
			array[165] = "WhiteSmoke";
			array[166] = "Yellow";
			array[167] = "YellowGreen";
			s_colorNameTable = array;
		}

		public static int KnownColorToArgb(KnownColor color)
		{
			EnsureColorTable();
			return s_colorTable[(int)color];
		}

		public static string KnownColorToName(KnownColor color)
		{
			EnsureColorNameTable();
			return s_colorNameTable[(int)color];
		}

		private static void UpdateSystemColors(int[] colorTable)
		{
			colorTable[1] = -2830136;
			colorTable[2] = -16755485;
			colorTable[3] = -1;
			colorTable[4] = -8355712;
			colorTable[168] = -986896;
			colorTable[169] = -1;
			colorTable[170] = -6250336;
			colorTable[5] = -1250856;
			colorTable[6] = -5461863;
			colorTable[7] = -9343132;
			colorTable[8] = -921630;
			colorTable[9] = -1;
			colorTable[10] = -16777216;
			colorTable[11] = -16757096;
			colorTable[171] = -4599318;
			colorTable[172] = -2628366;
			colorTable[12] = -5461863;
			colorTable[13] = -13538619;
			colorTable[14] = -1;
			colorTable[15] = -16777088;
			colorTable[16] = -2830136;
			colorTable[17] = -8743201;
			colorTable[18] = -2562824;
			colorTable[19] = -31;
			colorTable[20] = -16777216;
			colorTable[21] = -1;
			colorTable[173] = -986896;
			colorTable[174] = -13395457;
			colorTable[22] = -16777216;
			colorTable[23] = -2830136;
			colorTable[24] = -1;
			colorTable[25] = -16777216;
			colorTable[26] = -16777216;
		}
	}
	public class SizeFConverter : TypeConverter
	{
		private static readonly string[] s_propertySort = new string[2] { "Width", "Height" };

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string text)
			{
				string text2 = text.Trim();
				if (text2.Length == 0)
				{
					return null;
				}
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}
				char separator = culture.TextInfo.ListSeparator[0];
				string[] array = text2.Split(separator);
				float[] array2 = new float[array.Length];
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(float));
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = (float)converter.ConvertFromString(context, culture, array[i]);
				}
				if (array2.Length == 2)
				{
					return new SizeF(array2[0], array2[1]);
				}
				throw new ArgumentException(global::SR.Format("Text \"{0}\" cannot be parsed. The expected text format is \"{1}\".", text2, "Width,Height"));
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (destinationType == typeof(string) && value is SizeF sizeF)
			{
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}
				string separator = culture.TextInfo.ListSeparator + " ";
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(float));
				string[] array = new string[2];
				int num = 0;
				array[num++] = converter.ConvertToString(context, culture, sizeF.Width);
				array[num++] = converter.ConvertToString(context, culture, sizeF.Height);
				return string.Join(separator, array);
			}
			if (destinationType == typeof(InstanceDescriptor) && value is SizeF sizeF2)
			{
				ConstructorInfo constructor = typeof(SizeF).GetConstructor(new Type[2]
				{
					typeof(float),
					typeof(float)
				});
				if (constructor != null)
				{
					return new InstanceDescriptor(constructor, new object[2] { sizeF2.Width, sizeF2.Height });
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	public class ColorConverter : TypeConverter
	{
		private class ColorComparer : IComparer
		{
			public int Compare(object left, object right)
			{
				Color color = (Color)left;
				Color color2 = (Color)right;
				return string.Compare(color.Name, color2.Name, ignoreCase: false, CultureInfo.InvariantCulture);
			}
		}

		private static string ColorConstantsLock = "colorConstants";

		private static Hashtable colorConstants;

		private static string SystemColorConstantsLock = "systemColorConstants";

		private static Hashtable systemColorConstants;

		private static string ValuesLock = "values";

		private static StandardValuesCollection values;

		private static Hashtable Colors
		{
			get
			{
				if (colorConstants == null)
				{
					lock (ColorConstantsLock)
					{
						if (colorConstants == null)
						{
							Hashtable hash = new Hashtable(StringComparer.OrdinalIgnoreCase);
							FillConstants(hash, typeof(Color));
							colorConstants = hash;
						}
					}
				}
				return colorConstants;
			}
		}

		private static Hashtable SystemColors
		{
			get
			{
				if (systemColorConstants == null)
				{
					lock (SystemColorConstantsLock)
					{
						if (systemColorConstants == null)
						{
							Hashtable hash = new Hashtable(StringComparer.OrdinalIgnoreCase);
							FillConstants(hash, typeof(SystemColors));
							systemColorConstants = hash;
						}
					}
				}
				return systemColorConstants;
			}
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		internal static object GetNamedColor(string name)
		{
			object obj = null;
			obj = Colors[name];
			if (obj != null)
			{
				return obj;
			}
			return SystemColors[name];
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string text)
			{
				object obj = null;
				string text2 = text.Trim();
				if (text2.Length == 0)
				{
					obj = Color.Empty;
				}
				else
				{
					obj = GetNamedColor(text2);
					if (obj == null)
					{
						if (culture == null)
						{
							culture = CultureInfo.CurrentCulture;
						}
						char c = culture.TextInfo.ListSeparator[0];
						bool flag = true;
						TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
						if (text2.IndexOf(c) == -1)
						{
							if (text2.Length >= 2 && (text2[0] == '\'' || text2[0] == '"') && text2[0] == text2[text2.Length - 1])
							{
								obj = Color.FromName(text2.Substring(1, text2.Length - 2));
								flag = false;
							}
							else if ((text2.Length == 7 && text2[0] == '#') || (text2.Length == 8 && (text2.StartsWith("0x") || text2.StartsWith("0X"))) || (text2.Length == 8 && (text2.StartsWith("&h") || text2.StartsWith("&H"))))
							{
								obj = Color.FromArgb(-16777216 | (int)converter.ConvertFromString(context, culture, text2));
							}
						}
						if (obj == null)
						{
							string[] array = text2.Split(new char[1] { c });
							int[] array2 = new int[array.Length];
							for (int i = 0; i < array2.Length; i++)
							{
								array2[i] = (int)converter.ConvertFromString(context, culture, array[i]);
							}
							switch (array2.Length)
							{
							case 1:
								obj = Color.FromArgb(array2[0]);
								break;
							case 3:
								obj = Color.FromArgb(array2[0], array2[1], array2[2]);
								break;
							case 4:
								obj = Color.FromArgb(array2[0], array2[1], array2[2], array2[3]);
								break;
							}
							flag = true;
						}
						if (obj != null && flag)
						{
							int num = ((Color)obj).ToArgb();
							foreach (Color value2 in Colors.Values)
							{
								if (value2.ToArgb() == num)
								{
									obj = value2;
									break;
								}
							}
						}
					}
					if (obj == null)
					{
						throw new ArgumentException(global::SR.Format("Color '{0}' is not valid.", text2));
					}
				}
				return obj;
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (value is Color)
			{
				if (destinationType == typeof(string))
				{
					Color color = (Color)value;
					if (color == Color.Empty)
					{
						return string.Empty;
					}
					if (color.IsKnownColor)
					{
						return color.Name;
					}
					if (color.IsNamedColor)
					{
						return "'" + color.Name + "'";
					}
					if (culture == null)
					{
						culture = CultureInfo.CurrentCulture;
					}
					string separator = culture.TextInfo.ListSeparator + " ";
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
					int num = 0;
					string[] array;
					if (color.A < 255)
					{
						array = new string[4];
						array[num++] = converter.ConvertToString(context, culture, color.A);
					}
					else
					{
						array = new string[3];
					}
					array[num++] = converter.ConvertToString(context, culture, color.R);
					array[num++] = converter.ConvertToString(context, culture, color.G);
					array[num++] = converter.ConvertToString(context, culture, color.B);
					return string.Join(separator, array);
				}
				if (destinationType == typeof(InstanceDescriptor))
				{
					MemberInfo memberInfo = null;
					object[] arguments = null;
					Color color2 = (Color)value;
					if (color2.IsEmpty)
					{
						memberInfo = typeof(Color).GetField("Empty");
					}
					else if (color2.IsSystemColor)
					{
						memberInfo = typeof(SystemColors).GetProperty(color2.Name);
					}
					else if (color2.IsKnownColor)
					{
						memberInfo = typeof(Color).GetProperty(color2.Name);
					}
					else if (color2.A != 255)
					{
						memberInfo = typeof(Color).GetMethod("FromArgb", new Type[4]
						{
							typeof(int),
							typeof(int),
							typeof(int),
							typeof(int)
						});
						arguments = new object[4] { color2.A, color2.R, color2.G, color2.B };
					}
					else if (color2.IsNamedColor)
					{
						memberInfo = typeof(Color).GetMethod("FromName", new Type[1] { typeof(string) });
						arguments = new object[1] { color2.Name };
					}
					else
					{
						memberInfo = typeof(Color).GetMethod("FromArgb", new Type[3]
						{
							typeof(int),
							typeof(int),
							typeof(int)
						});
						arguments = new object[3] { color2.R, color2.G, color2.B };
					}
					if (memberInfo != null)
					{
						return new InstanceDescriptor(memberInfo, arguments);
					}
					return null;
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		private static void FillConstants(Hashtable hash, Type enumType)
		{
			MethodAttributes methodAttributes = MethodAttributes.Public | MethodAttributes.Static;
			PropertyInfo[] properties = enumType.GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.PropertyType == typeof(Color))
				{
					MethodInfo getMethod = propertyInfo.GetGetMethod();
					if (getMethod != null && (getMethod.Attributes & methodAttributes) == methodAttributes)
					{
						object[] index = null;
						hash[propertyInfo.Name] = propertyInfo.GetValue(null, index);
					}
				}
			}
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			if (values == null)
			{
				lock (ValuesLock)
				{
					if (values == null)
					{
						ArrayList arrayList = new ArrayList();
						arrayList.AddRange(Colors.Values);
						arrayList.AddRange(SystemColors.Values);
						int num = arrayList.Count;
						for (int i = 0; i < num - 1; i++)
						{
							for (int j = i + 1; j < num; j++)
							{
								if (arrayList[i].Equals(arrayList[j]))
								{
									arrayList.RemoveAt(j);
									num--;
									j--;
								}
							}
						}
						arrayList.Sort(0, arrayList.Count, new ColorComparer());
						values = new StandardValuesCollection(arrayList.ToArray());
					}
				}
			}
			return values;
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
	public class PointConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string text)
			{
				string text2 = text.Trim();
				if (text2.Length == 0)
				{
					return null;
				}
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}
				char c = culture.TextInfo.ListSeparator[0];
				string[] array = text2.Split(new char[1] { c });
				int[] array2 = new int[array.Length];
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = (int)converter.ConvertFromString(context, culture, array[i]);
				}
				if (array2.Length == 2)
				{
					return new Point(array2[0], array2[1]);
				}
				throw new ArgumentException(global::SR.Format("Text \"{0}\" cannot be parsed. The expected text format is \"{1}\".", text2, "x, y"));
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (value is Point)
			{
				if (destinationType == typeof(string))
				{
					Point point = (Point)value;
					if (culture == null)
					{
						culture = CultureInfo.CurrentCulture;
					}
					string separator = culture.TextInfo.ListSeparator + " ";
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
					string[] array = new string[2];
					int num = 0;
					array[num++] = converter.ConvertToString(context, culture, point.X);
					array[num++] = converter.ConvertToString(context, culture, point.Y);
					return string.Join(separator, array);
				}
				if (destinationType == typeof(InstanceDescriptor))
				{
					Point point2 = (Point)value;
					ConstructorInfo constructor = typeof(Point).GetConstructor(new Type[2]
					{
						typeof(int),
						typeof(int)
					});
					if (constructor != null)
					{
						return new InstanceDescriptor(constructor, new object[2] { point2.X, point2.Y });
					}
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	public class RectangleConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string text)
			{
				string text2 = text.Trim();
				if (text2.Length == 0)
				{
					return null;
				}
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}
				char c = culture.TextInfo.ListSeparator[0];
				string[] array = text2.Split(new char[1] { c });
				int[] array2 = new int[array.Length];
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = (int)converter.ConvertFromString(context, culture, array[i]);
				}
				if (array2.Length == 4)
				{
					return new Rectangle(array2[0], array2[1], array2[2], array2[3]);
				}
				throw new ArgumentException(global::SR.Format("Text \"{0}\" cannot be parsed. The expected text format is \"{1}\".", "text", text2, "x, y, width, height"));
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (value is Rectangle)
			{
				if (destinationType == typeof(string))
				{
					Rectangle rectangle = (Rectangle)value;
					if (culture == null)
					{
						culture = CultureInfo.CurrentCulture;
					}
					string separator = culture.TextInfo.ListSeparator + " ";
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
					string[] array = new string[4];
					int num = 0;
					array[num++] = converter.ConvertToString(context, culture, rectangle.X);
					array[num++] = converter.ConvertToString(context, culture, rectangle.Y);
					array[num++] = converter.ConvertToString(context, culture, rectangle.Width);
					array[num++] = converter.ConvertToString(context, culture, rectangle.Height);
					return string.Join(separator, array);
				}
				if (destinationType == typeof(InstanceDescriptor))
				{
					Rectangle rectangle2 = (Rectangle)value;
					ConstructorInfo constructor = typeof(Rectangle).GetConstructor(new Type[4]
					{
						typeof(int),
						typeof(int),
						typeof(int),
						typeof(int)
					});
					if (constructor != null)
					{
						return new InstanceDescriptor(constructor, new object[4] { rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height });
					}
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	public class SizeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string text)
			{
				string text2 = text.Trim();
				if (text2.Length == 0)
				{
					return null;
				}
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}
				char c = culture.TextInfo.ListSeparator[0];
				string[] array = text2.Split(new char[1] { c });
				int[] array2 = new int[array.Length];
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = (int)converter.ConvertFromString(context, culture, array[i]);
				}
				if (array2.Length == 2)
				{
					return new Size(array2[0], array2[1]);
				}
				throw new ArgumentException(global::SR.Format("Text \"{0}\" cannot be parsed. The expected text format is \"{1}\".", text2, "Width,Height"));
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (value is Size)
			{
				if (destinationType == typeof(string))
				{
					Size size = (Size)value;
					if (culture == null)
					{
						culture = CultureInfo.CurrentCulture;
					}
					string separator = culture.TextInfo.ListSeparator + " ";
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
					string[] array = new string[2];
					int num = 0;
					array[num++] = converter.ConvertToString(context, culture, size.Width);
					array[num++] = converter.ConvertToString(context, culture, size.Height);
					return string.Join(separator, array);
				}
				if (destinationType == typeof(InstanceDescriptor))
				{
					Size size2 = (Size)value;
					ConstructorInfo constructor = typeof(Size).GetConstructor(new Type[2]
					{
						typeof(int),
						typeof(int)
					});
					if (constructor != null)
					{
						return new InstanceDescriptor(constructor, new object[2] { size2.Width, size2.Height });
					}
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	[TypeForwardedFrom("Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065")]
	public static class SystemColors
	{
	}
	[Serializable]
	[DebuggerDisplay("{NameAndARGBValue}")]
	[TypeForwardedFrom("Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065")]
	[TypeConverter(typeof(ColorConverter))]
	public readonly struct Color : IEquatable<Color>
	{
		public static readonly Color Empty;

		private const short StateKnownColorValid = 1;

		private const short StateARGBValueValid = 2;

		private const short StateValueMask = 2;

		private const short StateNameValid = 8;

		private const long NotDefinedValue = 0L;

		private const int ARGBAlphaShift = 24;

		private const int ARGBRedShift = 16;

		private const int ARGBGreenShift = 8;

		private const int ARGBBlueShift = 0;

		private readonly string name;

		private readonly long value;

		private readonly short knownColor;

		private readonly short state;

		public static Color Transparent => new Color(KnownColor.Transparent);

		public static Color AliceBlue => new Color(KnownColor.AliceBlue);

		public static Color AntiqueWhite => new Color(KnownColor.AntiqueWhite);

		public static Color Aqua => new Color(KnownColor.Aqua);

		public static Color Aquamarine => new Color(KnownColor.Aquamarine);

		public static Color Azure => new Color(KnownColor.Azure);

		public static Color Beige => new Color(KnownColor.Beige);

		public static Color Bisque => new Color(KnownColor.Bisque);

		public static Color Black => new Color(KnownColor.Black);

		public static Color BlanchedAlmond => new Color(KnownColor.BlanchedAlmond);

		public static Color Blue => new Color(KnownColor.Blue);

		public static Color BlueViolet => new Color(KnownColor.BlueViolet);

		public static Color Brown => new Color(KnownColor.Brown);

		public static Color BurlyWood => new Color(KnownColor.BurlyWood);

		public static Color CadetBlue => new Color(KnownColor.CadetBlue);

		public static Color Chartreuse => new Color(KnownColor.Chartreuse);

		public static Color Chocolate => new Color(KnownColor.Chocolate);

		public static Color Coral => new Color(KnownColor.Coral);

		public static Color CornflowerBlue => new Color(KnownColor.CornflowerBlue);

		public static Color Cornsilk => new Color(KnownColor.Cornsilk);

		public static Color Crimson => new Color(KnownColor.Crimson);

		public static Color Cyan => new Color(KnownColor.Cyan);

		public static Color DarkBlue => new Color(KnownColor.DarkBlue);

		public static Color DarkCyan => new Color(KnownColor.DarkCyan);

		public static Color DarkGoldenrod => new Color(KnownColor.DarkGoldenrod);

		public static Color DarkGray => new Color(KnownColor.DarkGray);

		public static Color DarkGreen => new Color(KnownColor.DarkGreen);

		public static Color DarkKhaki => new Color(KnownColor.DarkKhaki);

		public static Color DarkMagenta => new Color(KnownColor.DarkMagenta);

		public static Color DarkOliveGreen => new Color(KnownColor.DarkOliveGreen);

		public static Color DarkOrange => new Color(KnownColor.DarkOrange);

		public static Color DarkOrchid => new Color(KnownColor.DarkOrchid);

		public static Color DarkRed => new Color(KnownColor.DarkRed);

		public static Color DarkSalmon => new Color(KnownColor.DarkSalmon);

		public static Color DarkSeaGreen => new Color(KnownColor.DarkSeaGreen);

		public static Color DarkSlateBlue => new Color(KnownColor.DarkSlateBlue);

		public static Color DarkSlateGray => new Color(KnownColor.DarkSlateGray);

		public static Color DarkTurquoise => new Color(KnownColor.DarkTurquoise);

		public static Color DarkViolet => new Color(KnownColor.DarkViolet);

		public static Color DeepPink => new Color(KnownColor.DeepPink);

		public static Color DeepSkyBlue => new Color(KnownColor.DeepSkyBlue);

		public static Color DimGray => new Color(KnownColor.DimGray);

		public static Color DodgerBlue => new Color(KnownColor.DodgerBlue);

		public static Color Firebrick => new Color(KnownColor.Firebrick);

		public static Color FloralWhite => new Color(KnownColor.FloralWhite);

		public static Color ForestGreen => new Color(KnownColor.ForestGreen);

		public static Color Fuchsia => new Color(KnownColor.Fuchsia);

		public static Color Gainsboro => new Color(KnownColor.Gainsboro);

		public static Color GhostWhite => new Color(KnownColor.GhostWhite);

		public static Color Gold => new Color(KnownColor.Gold);

		public static Color Goldenrod => new Color(KnownColor.Goldenrod);

		public static Color Gray => new Color(KnownColor.Gray);

		public static Color Green => new Color(KnownColor.Green);

		public static Color GreenYellow => new Color(KnownColor.GreenYellow);

		public static Color Honeydew => new Color(KnownColor.Honeydew);

		public static Color HotPink => new Color(KnownColor.HotPink);

		public static Color IndianRed => new Color(KnownColor.IndianRed);

		public static Color Indigo => new Color(KnownColor.Indigo);

		public static Color Ivory => new Color(KnownColor.Ivory);

		public static Color Khaki => new Color(KnownColor.Khaki);

		public static Color Lavender => new Color(KnownColor.Lavender);

		public static Color LavenderBlush => new Color(KnownColor.LavenderBlush);

		public static Color LawnGreen => new Color(KnownColor.LawnGreen);

		public static Color LemonChiffon => new Color(KnownColor.LemonChiffon);

		public static Color LightBlue => new Color(KnownColor.LightBlue);

		public static Color LightCoral => new Color(KnownColor.LightCoral);

		public static Color LightCyan => new Color(KnownColor.LightCyan);

		public static Color LightGoldenrodYellow => new Color(KnownColor.LightGoldenrodYellow);

		public static Color LightGreen => new Color(KnownColor.LightGreen);

		public static Color LightGray => new Color(KnownColor.LightGray);

		public static Color LightPink => new Color(KnownColor.LightPink);

		public static Color LightSalmon => new Color(KnownColor.LightSalmon);

		public static Color LightSeaGreen => new Color(KnownColor.LightSeaGreen);

		public static Color LightSkyBlue => new Color(KnownColor.LightSkyBlue);

		public static Color LightSlateGray => new Color(KnownColor.LightSlateGray);

		public static Color LightSteelBlue => new Color(KnownColor.LightSteelBlue);

		public static Color LightYellow => new Color(KnownColor.LightYellow);

		public static Color Lime => new Color(KnownColor.Lime);

		public static Color LimeGreen => new Color(KnownColor.LimeGreen);

		public static Color Linen => new Color(KnownColor.Linen);

		public static Color Magenta => new Color(KnownColor.Magenta);

		public static Color Maroon => new Color(KnownColor.Maroon);

		public static Color MediumAquamarine => new Color(KnownColor.MediumAquamarine);

		public static Color MediumBlue => new Color(KnownColor.MediumBlue);

		public static Color MediumOrchid => new Color(KnownColor.MediumOrchid);

		public static Color MediumPurple => new Color(KnownColor.MediumPurple);

		public static Color MediumSeaGreen => new Color(KnownColor.MediumSeaGreen);

		public static Color MediumSlateBlue => new Color(KnownColor.MediumSlateBlue);

		public static Color MediumSpringGreen => new Color(KnownColor.MediumSpringGreen);

		public static Color MediumTurquoise => new Color(KnownColor.MediumTurquoise);

		public static Color MediumVioletRed => new Color(KnownColor.MediumVioletRed);

		public static Color MidnightBlue => new Color(KnownColor.MidnightBlue);

		public static Color MintCream => new Color(KnownColor.MintCream);

		public static Color MistyRose => new Color(KnownColor.MistyRose);

		public static Color Moccasin => new Color(KnownColor.Moccasin);

		public static Color NavajoWhite => new Color(KnownColor.NavajoWhite);

		public static Color Navy => new Color(KnownColor.Navy);

		public static Color OldLace => new Color(KnownColor.OldLace);

		public static Color Olive => new Color(KnownColor.Olive);

		public static Color OliveDrab => new Color(KnownColor.OliveDrab);

		public static Color Orange => new Color(KnownColor.Orange);

		public static Color OrangeRed => new Color(KnownColor.OrangeRed);

		public static Color Orchid => new Color(KnownColor.Orchid);

		public static Color PaleGoldenrod => new Color(KnownColor.PaleGoldenrod);

		public static Color PaleGreen => new Color(KnownColor.PaleGreen);

		public static Color PaleTurquoise => new Color(KnownColor.PaleTurquoise);

		public static Color PaleVioletRed => new Color(KnownColor.PaleVioletRed);

		public static Color PapayaWhip => new Color(KnownColor.PapayaWhip);

		public static Color PeachPuff => new Color(KnownColor.PeachPuff);

		public static Color Peru => new Color(KnownColor.Peru);

		public static Color Pink => new Color(KnownColor.Pink);

		public static Color Plum => new Color(KnownColor.Plum);

		public static Color PowderBlue => new Color(KnownColor.PowderBlue);

		public static Color Purple => new Color(KnownColor.Purple);

		public static Color Red => new Color(KnownColor.Red);

		public static Color RosyBrown => new Color(KnownColor.RosyBrown);

		public static Color RoyalBlue => new Color(KnownColor.RoyalBlue);

		public static Color SaddleBrown => new Color(KnownColor.SaddleBrown);

		public static Color Salmon => new Color(KnownColor.Salmon);

		public static Color SandyBrown => new Color(KnownColor.SandyBrown);

		public static Color SeaGreen => new Color(KnownColor.SeaGreen);

		public static Color SeaShell => new Color(KnownColor.SeaShell);

		public static Color Sienna => new Color(KnownColor.Sienna);

		public static Color Silver => new Color(KnownColor.Silver);

		public static Color SkyBlue => new Color(KnownColor.SkyBlue);

		public static Color SlateBlue => new Color(KnownColor.SlateBlue);

		public static Color SlateGray => new Color(KnownColor.SlateGray);

		public static Color Snow => new Color(KnownColor.Snow);

		public static Color SpringGreen => new Color(KnownColor.SpringGreen);

		public static Color SteelBlue => new Color(KnownColor.SteelBlue);

		public static Color Tan => new Color(KnownColor.Tan);

		public static Color Teal => new Color(KnownColor.Teal);

		public static Color Thistle => new Color(KnownColor.Thistle);

		public static Color Tomato => new Color(KnownColor.Tomato);

		public static Color Turquoise => new Color(KnownColor.Turquoise);

		public static Color Violet => new Color(KnownColor.Violet);

		public static Color Wheat => new Color(KnownColor.Wheat);

		public static Color White => new Color(KnownColor.White);

		public static Color WhiteSmoke => new Color(KnownColor.WhiteSmoke);

		public static Color Yellow => new Color(KnownColor.Yellow);

		public static Color YellowGreen => new Color(KnownColor.YellowGreen);

		public byte R => (byte)((Value >> 16) & 0xFF);

		public byte G => (byte)((Value >> 8) & 0xFF);

		public byte B => (byte)(Value & 0xFF);

		public byte A => (byte)((Value >> 24) & 0xFF);

		public bool IsKnownColor => (state & 1) != 0;

		public bool IsEmpty => state == 0;

		public bool IsNamedColor
		{
			get
			{
				if ((state & 8) == 0)
				{
					return IsKnownColor;
				}
				return true;
			}
		}

		public bool IsSystemColor
		{
			get
			{
				if (IsKnownColor)
				{
					if (knownColor > 26)
					{
						return knownColor > 167;
					}
					return true;
				}
				return false;
			}
		}

		private string NameAndARGBValue => $"{{Name={Name}, ARGB=({A}, {R}, {G}, {B})}}";

		public string Name
		{
			get
			{
				if ((state & 8) != 0)
				{
					return name;
				}
				if (IsKnownColor)
				{
					return KnownColorTable.KnownColorToName((KnownColor)knownColor);
				}
				return Convert.ToString(value, 16);
			}
		}

		private long Value
		{
			get
			{
				if ((state & 2) != 0)
				{
					return value;
				}
				if (IsKnownColor)
				{
					return KnownColorTable.KnownColorToArgb((KnownColor)knownColor);
				}
				return 0L;
			}
		}

		internal Color(KnownColor knownColor)
		{
			value = 0L;
			state = 1;
			name = null;
			this.knownColor = (short)knownColor;
		}

		private Color(long value, short state, string name, KnownColor knownColor)
		{
			this.value = value;
			this.state = state;
			this.name = name;
			this.knownColor = (short)knownColor;
		}

		private static void CheckByte(int value, string name)
		{
			if (value < 0 || value > 255)
			{
				throw new ArgumentException(global::SR.Format("Value of '{1}' is not valid for '{0}'. '{0}' should be greater than or equal to {2} and less than or equal to {3}.", name, value, 0, 255));
			}
		}

		private static long MakeArgb(byte alpha, byte red, byte green, byte blue)
		{
			return (long)(uint)((red << 16) | (green << 8) | blue | (alpha << 24)) & 0xFFFFFFFFL;
		}

		public static Color FromArgb(int argb)
		{
			return new Color(argb & 0xFFFFFFFFu, 2, null, (KnownColor)0);
		}

		public static Color FromArgb(int alpha, int red, int green, int blue)
		{
			CheckByte(alpha, "alpha");
			CheckByte(red, "red");
			CheckByte(green, "green");
			CheckByte(blue, "blue");
			return new Color(MakeArgb((byte)alpha, (byte)red, (byte)green, (byte)blue), 2, null, (KnownColor)0);
		}

		public static Color FromArgb(int alpha, Color baseColor)
		{
			CheckByte(alpha, "alpha");
			return new Color(MakeArgb((byte)alpha, baseColor.R, baseColor.G, baseColor.B), 2, null, (KnownColor)0);
		}

		public static Color FromArgb(int red, int green, int blue)
		{
			return FromArgb(255, red, green, blue);
		}

		public static Color FromKnownColor(KnownColor color)
		{
			if (color > (KnownColor)0 && color <= KnownColor.MenuHighlight)
			{
				return new Color(color);
			}
			return FromName(color.ToString());
		}

		public static Color FromName(string name)
		{
			if (ColorTable.TryGetNamedColor(name, out var result))
			{
				return result;
			}
			return new Color(0L, 8, name, (KnownColor)0);
		}

		public float GetBrightness()
		{
			float num = (float)(int)R / 255f;
			float num2 = (float)(int)G / 255f;
			float num3 = (float)(int)B / 255f;
			float num4 = num;
			float num5 = num;
			if (num2 > num4)
			{
				num4 = num2;
			}
			else if (num2 < num5)
			{
				num5 = num2;
			}
			if (num3 > num4)
			{
				num4 = num3;
			}
			else if (num3 < num5)
			{
				num5 = num3;
			}
			return (num4 + num5) / 2f;
		}

		public float GetHue()
		{
			if (R == G && G == B)
			{
				return 0f;
			}
			float num = (float)(int)R / 255f;
			float num2 = (float)(int)G / 255f;
			float num3 = (float)(int)B / 255f;
			float num4 = num;
			float num5 = num;
			if (num2 > num4)
			{
				num4 = num2;
			}
			else if (num2 < num5)
			{
				num5 = num2;
			}
			if (num3 > num4)
			{
				num4 = num3;
			}
			else if (num3 < num5)
			{
				num5 = num3;
			}
			float num6 = num4 - num5;
			float num7 = ((num == num4) ? ((num2 - num3) / num6) : ((num2 != num4) ? (4f + (num - num2) / num6) : (2f + (num3 - num) / num6)));
			num7 *= 60f;
			if (num7 < 0f)
			{
				num7 += 360f;
			}
			return num7;
		}

		public float GetSaturation()
		{
			float num = (float)(int)R / 255f;
			float num2 = (float)(int)G / 255f;
			float num3 = (float)(int)B / 255f;
			float result = 0f;
			float num4 = num;
			float num5 = num;
			if (num2 > num4)
			{
				num4 = num2;
			}
			else if (num2 < num5)
			{
				num5 = num2;
			}
			if (num3 > num4)
			{
				num4 = num3;
			}
			else if (num3 < num5)
			{
				num5 = num3;
			}
			if (num4 != num5)
			{
				result = ((!((double)((num4 + num5) / 2f) <= 0.5)) ? ((num4 - num5) / (2f - num4 - num5)) : ((num4 - num5) / (num4 + num5)));
			}
			return result;
		}

		public int ToArgb()
		{
			return (int)Value;
		}

		public KnownColor ToKnownColor()
		{
			return (KnownColor)knownColor;
		}

		public override string ToString()
		{
			if ((state & 8) != 0 || (state & 1) != 0)
			{
				return "Color [" + Name + "]";
			}
			if ((state & 2) != 0)
			{
				return "Color [A=" + A + ", R=" + R + ", G=" + G + ", B=" + B + "]";
			}
			return "Color [Empty]";
		}

		public static bool operator ==(Color left, Color right)
		{
			if (left.value == right.value && left.state == right.state && left.knownColor == right.knownColor)
			{
				return left.name == right.name;
			}
			return false;
		}

		public static bool operator !=(Color left, Color right)
		{
			return !(left == right);
		}

		public override bool Equals(object obj)
		{
			if (obj is Color)
			{
				return Equals((Color)obj);
			}
			return false;
		}

		public bool Equals(Color other)
		{
			return this == other;
		}

		public override int GetHashCode()
		{
			if ((name != null) & !IsKnownColor)
			{
				return name.GetHashCode();
			}
			return System.Numerics.Hashing.HashHelpers.Combine(System.Numerics.Hashing.HashHelpers.Combine(value.GetHashCode(), state.GetHashCode()), knownColor.GetHashCode());
		}

		static Color()
		{
		}
	}
	[Serializable]
	[TypeForwardedFrom("Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065")]
	[TypeConverter(typeof(PointConverter))]
	public struct Point : IEquatable<Point>
	{
		public static readonly Point Empty;

		private int x;

		private int y;

		[Browsable(false)]
		public bool IsEmpty
		{
			get
			{
				if (x == 0)
				{
					return y == 0;
				}
				return false;
			}
		}

		public int X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public int Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public Point(Size sz)
		{
			x = sz.Width;
			y = sz.Height;
		}

		public Point(int dw)
		{
			x = LowInt16(dw);
			y = HighInt16(dw);
		}

		public static implicit operator PointF(Point p)
		{
			return new PointF(p.X, p.Y);
		}

		public static explicit operator Size(Point p)
		{
			return new Size(p.X, p.Y);
		}

		public static Point operator +(Point pt, Size sz)
		{
			return Add(pt, sz);
		}

		public static Point operator -(Point pt, Size sz)
		{
			return Subtract(pt, sz);
		}

		public static bool operator ==(Point left, Point right)
		{
			if (left.X == right.X)
			{
				return left.Y == right.Y;
			}
			return false;
		}

		public static bool operator !=(Point left, Point right)
		{
			return !(left == right);
		}

		public static Point Add(Point pt, Size sz)
		{
			return new Point(pt.X + sz.Width, pt.Y + sz.Height);
		}

		public static Point Subtract(Point pt, Size sz)
		{
			return new Point(pt.X - sz.Width, pt.Y - sz.Height);
		}

		public static Point Ceiling(PointF value)
		{
			return new Point((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y));
		}

		public static Point Truncate(PointF value)
		{
			return new Point((int)value.X, (int)value.Y);
		}

		public static Point Round(PointF value)
		{
			return new Point((int)Math.Round(value.X), (int)Math.Round(value.Y));
		}

		public override bool Equals(object obj)
		{
			if (obj is Point)
			{
				return Equals((Point)obj);
			}
			return false;
		}

		public bool Equals(Point other)
		{
			return this == other;
		}

		public override int GetHashCode()
		{
			return System.Numerics.Hashing.HashHelpers.Combine(X, Y);
		}

		public void Offset(int dx, int dy)
		{
			X += dx;
			Y += dy;
		}

		public void Offset(Point p)
		{
			Offset(p.X, p.Y);
		}

		public override string ToString()
		{
			return "{X=" + X + ",Y=" + Y + "}";
		}

		private static short HighInt16(int n)
		{
			return (short)((n >> 16) & 0xFFFF);
		}

		private static short LowInt16(int n)
		{
			return (short)(n & 0xFFFF);
		}

		static Point()
		{
		}
	}
	[Serializable]
	[TypeForwardedFrom("Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065")]
	public struct PointF(float x, float y) : IEquatable<PointF>
	{
		public static readonly PointF Empty;

		private float x = x;

		private float y = y;

		[Browsable(false)]
		public bool IsEmpty
		{
			get
			{
				if (x == 0f)
				{
					return y == 0f;
				}
				return false;
			}
		}

		public float X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public float Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public static PointF operator +(PointF pt, Size sz)
		{
			return Add(pt, sz);
		}

		public static PointF operator -(PointF pt, Size sz)
		{
			return Subtract(pt, sz);
		}

		public static PointF operator +(PointF pt, SizeF sz)
		{
			return Add(pt, sz);
		}

		public static PointF operator -(PointF pt, SizeF sz)
		{
			return Subtract(pt, sz);
		}

		public static bool operator ==(PointF left, PointF right)
		{
			if (left.X == right.X)
			{
				return left.Y == right.Y;
			}
			return false;
		}

		public static bool operator !=(PointF left, PointF right)
		{
			return !(left == right);
		}

		public static PointF Add(PointF pt, Size sz)
		{
			return new PointF(pt.X + (float)sz.Width, pt.Y + (float)sz.Height);
		}

		public static PointF Subtract(PointF pt, Size sz)
		{
			return new PointF(pt.X - (float)sz.Width, pt.Y - (float)sz.Height);
		}

		public static PointF Add(PointF pt, SizeF sz)
		{
			return new PointF(pt.X + sz.Width, pt.Y + sz.Height);
		}

		public static PointF Subtract(PointF pt, SizeF sz)
		{
			return new PointF(pt.X - sz.Width, pt.Y - sz.Height);
		}

		public override bool Equals(object obj)
		{
			if (obj is PointF)
			{
				return Equals((PointF)obj);
			}
			return false;
		}

		public bool Equals(PointF other)
		{
			return this == other;
		}

		public override int GetHashCode()
		{
			return System.Numerics.Hashing.HashHelpers.Combine(X.GetHashCode(), Y.GetHashCode());
		}

		public override string ToString()
		{
			return "{X=" + x + ", Y=" + y + "}";
		}
	}
	[Serializable]
	[TypeForwardedFrom("Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065")]
	[TypeConverter(typeof(RectangleConverter))]
	public struct Rectangle : IEquatable<Rectangle>
	{
		public static readonly Rectangle Empty;

		private int x;

		private int y;

		private int width;

		private int height;

		[Browsable(false)]
		public Point Location
		{
			get
			{
				return new Point(X, Y);
			}
			set
			{
				X = value.X;
				Y = value.Y;
			}
		}

		[Browsable(false)]
		public Size Size
		{
			get
			{
				return new Size(Width, Height);
			}
			set
			{
				Width = value.Width;
				Height = value.Height;
			}
		}

		public int X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public int Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public int Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}

		public int Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}

		[Browsable(false)]
		public int Left => X;

		[Browsable(false)]
		public int Top => Y;

		[Browsable(false)]
		public int Right => X + Width;

		[Browsable(false)]
		public int Bottom => Y + Height;

		[Browsable(false)]
		public bool IsEmpty
		{
			get
			{
				if (height == 0 && width == 0 && x == 0)
				{
					return y == 0;
				}
				return false;
			}
		}

		public Rectangle(int x, int y, int width, int height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public Rectangle(Point location, Size size)
		{
			x = location.X;
			y = location.Y;
			width = size.Width;
			height = size.Height;
		}

		public static Rectangle FromLTRB(int left, int top, int right, int bottom)
		{
			return new Rectangle(left, top, right - left, bottom - top);
		}

		public override bool Equals(object obj)
		{
			if (obj is Rectangle)
			{
				return Equals((Rectangle)obj);
			}
			return false;
		}

		public bool Equals(Rectangle other)
		{
			return this == other;
		}

		public static bool operator ==(Rectangle left, Rectangle right)
		{
			if (left.X == right.X && left.Y == right.Y && left.Width == right.Width)
			{
				return left.Height == right.Height;
			}
			return false;
		}

		public static bool operator !=(Rectangle left, Rectangle right)
		{
			return !(left == right);
		}

		public static Rectangle Ceiling(RectangleF value)
		{
			return new Rectangle((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y), (int)Math.Ceiling(value.Width), (int)Math.Ceiling(value.Height));
		}

		public static Rectangle Truncate(RectangleF value)
		{
			return new Rectangle((int)value.X, (int)value.Y, (int)value.Width, (int)value.Height);
		}

		public static Rectangle Round(RectangleF value)
		{
			return new Rectangle((int)Math.Round(value.X), (int)Math.Round(value.Y), (int)Math.Round(value.Width), (int)Math.Round(value.Height));
		}

		public bool Contains(int x, int y)
		{
			if (X <= x && x < X + Width && Y <= y)
			{
				return y < Y + Height;
			}
			return false;
		}

		public bool Contains(Point pt)
		{
			return Contains(pt.X, pt.Y);
		}

		public bool Contains(Rectangle rect)
		{
			if (X <= rect.X && rect.X + rect.Width <= X + Width && Y <= rect.Y)
			{
				return rect.Y + rect.Height <= Y + Height;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return System.Numerics.Hashing.HashHelpers.Combine(System.Numerics.Hashing.HashHelpers.Combine(System.Numerics.Hashing.HashHelpers.Combine(X, Y), Width), Height);
		}

		public void Inflate(int width, int height)
		{
			X -= width;
			Y -= height;
			Width += 2 * width;
			Height += 2 * height;
		}

		public void Inflate(Size size)
		{
			Inflate(size.Width, size.Height);
		}

		public static Rectangle Inflate(Rectangle rect, int x, int y)
		{
			Rectangle result = rect;
			result.Inflate(x, y);
			return result;
		}

		public void Intersect(Rectangle rect)
		{
			Rectangle rectangle = Intersect(rect, this);
			X = rectangle.X;
			Y = rectangle.Y;
			Width = rectangle.Width;
			Height = rectangle.Height;
		}

		public static Rectangle Intersect(Rectangle a, Rectangle b)
		{
			int num = Math.Max(a.X, b.X);
			int num2 = Math.Min(a.X + a.Width, b.X + b.Width);
			int num3 = Math.Max(a.Y, b.Y);
			int num4 = Math.Min(a.Y + a.Height, b.Y + b.Height);
			if (num2 >= num && num4 >= num3)
			{
				return new Rectangle(num, num3, num2 - num, num4 - num3);
			}
			return Empty;
		}

		public bool IntersectsWith(Rectangle rect)
		{
			if (rect.X < X + Width && X < rect.X + rect.Width && rect.Y < Y + Height)
			{
				return Y < rect.Y + rect.Height;
			}
			return false;
		}

		public static Rectangle Union(Rectangle a, Rectangle b)
		{
			int num = Math.Min(a.X, b.X);
			int num2 = Math.Max(a.X + a.Width, b.X + b.Width);
			int num3 = Math.Min(a.Y, b.Y);
			int num4 = Math.Max(a.Y + a.Height, b.Y + b.Height);
			return new Rectangle(num, num3, num2 - num, num4 - num3);
		}

		public void Offset(Point pos)
		{
			Offset(pos.X, pos.Y);
		}

		public void Offset(int x, int y)
		{
			X += x;
			Y += y;
		}

		public override string ToString()
		{
			return "{X=" + X + ",Y=" + Y + ",Width=" + Width + ",Height=" + Height + "}";
		}

		static Rectangle()
		{
		}
	}
	[Serializable]
	[TypeForwardedFrom("Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065")]
	public struct RectangleF : IEquatable<RectangleF>
	{
		public static readonly RectangleF Empty;

		private float x;

		private float y;

		private float width;

		private float height;

		[Browsable(false)]
		public PointF Location
		{
			get
			{
				return new PointF(X, Y);
			}
			set
			{
				X = value.X;
				Y = value.Y;
			}
		}

		[Browsable(false)]
		public SizeF Size
		{
			get
			{
				return new SizeF(Width, Height);
			}
			set
			{
				Width = value.Width;
				Height = value.Height;
			}
		}

		public float X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public float Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public float Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}

		public float Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}

		[Browsable(false)]
		public float Left => X;

		[Browsable(false)]
		public float Top => Y;

		[Browsable(false)]
		public float Right => X + Width;

		[Browsable(false)]
		public float Bottom => Y + Height;

		[Browsable(false)]
		public bool IsEmpty
		{
			get
			{
				if (!(Width <= 0f))
				{
					return Height <= 0f;
				}
				return true;
			}
		}

		public RectangleF(float x, float y, float width, float height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public RectangleF(PointF location, SizeF size)
		{
			x = location.X;
			y = location.Y;
			width = size.Width;
			height = size.Height;
		}

		public static RectangleF FromLTRB(float left, float top, float right, float bottom)
		{
			return new RectangleF(left, top, right - left, bottom - top);
		}

		public override bool Equals(object obj)
		{
			if (obj is RectangleF)
			{
				return Equals((RectangleF)obj);
			}
			return false;
		}

		public bool Equals(RectangleF other)
		{
			return this == other;
		}

		public static bool operator ==(RectangleF left, RectangleF right)
		{
			if (left.X == right.X && left.Y == right.Y && left.Width == right.Width)
			{
				return left.Height == right.Height;
			}
			return false;
		}

		public static bool operator !=(RectangleF left, RectangleF right)
		{
			return !(left == right);
		}

		public bool Contains(float x, float y)
		{
			if (X <= x && x < X + Width && Y <= y)
			{
				return y < Y + Height;
			}
			return false;
		}

		public bool Contains(PointF pt)
		{
			return Contains(pt.X, pt.Y);
		}

		public bool Contains(RectangleF rect)
		{
			if (X <= rect.X && rect.X + rect.Width <= X + Width && Y <= rect.Y)
			{
				return rect.Y + rect.Height <= Y + Height;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return System.Numerics.Hashing.HashHelpers.Combine(System.Numerics.Hashing.HashHelpers.Combine(System.Numerics.Hashing.HashHelpers.Combine(X.GetHashCode(), Y.GetHashCode()), Width.GetHashCode()), Height.GetHashCode());
		}

		public void Inflate(float x, float y)
		{
			X -= x;
			Y -= y;
			Width += 2f * x;
			Height += 2f * y;
		}

		public void Inflate(SizeF size)
		{
			Inflate(size.Width, size.Height);
		}

		public static RectangleF Inflate(RectangleF rect, float x, float y)
		{
			RectangleF result = rect;
			result.Inflate(x, y);
			return result;
		}

		public void Intersect(RectangleF rect)
		{
			RectangleF rectangleF = Intersect(rect, this);
			X = rectangleF.X;
			Y = rectangleF.Y;
			Width = rectangleF.Width;
			Height = rectangleF.Height;
		}

		public static RectangleF Intersect(RectangleF a, RectangleF b)
		{
			float num = Math.Max(a.X, b.X);
			float num2 = Math.Min(a.X + a.Width, b.X + b.Width);
			float num3 = Math.Max(a.Y, b.Y);
			float num4 = Math.Min(a.Y + a.Height, b.Y + b.Height);
			if (num2 >= num && num4 >= num3)
			{
				return new RectangleF(num, num3, num2 - num, num4 - num3);
			}
			return Empty;
		}

		public bool IntersectsWith(RectangleF rect)
		{
			if (rect.X < X + Width && X < rect.X + rect.Width && rect.Y < Y + Height)
			{
				return Y < rect.Y + rect.Height;
			}
			return false;
		}

		public static RectangleF Union(RectangleF a, RectangleF b)
		{
			float num = Math.Min(a.X, b.X);
			float num2 = Math.Max(a.X + a.Width, b.X + b.Width);
			float num3 = Math.Min(a.Y, b.Y);
			float num4 = Math.Max(a.Y + a.Height, b.Y + b.Height);
			return new RectangleF(num, num3, num2 - num, num4 - num3);
		}

		public void Offset(PointF pos)
		{
			Offset(pos.X, pos.Y);
		}

		public void Offset(float x, float y)
		{
			X += x;
			Y += y;
		}

		public static implicit operator RectangleF(Rectangle r)
		{
			return new RectangleF(r.X, r.Y, r.Width, r.Height);
		}

		public override string ToString()
		{
			return "{X=" + X + ",Y=" + Y + ",Width=" + Width + ",Height=" + Height + "}";
		}

		static RectangleF()
		{
		}
	}
	[Serializable]
	[TypeForwardedFrom("Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065")]
	[TypeConverter(typeof(SizeConverter))]
	public struct Size : IEquatable<Size>
	{
		public static readonly Size Empty;

		private int width;

		private int height;

		[Browsable(false)]
		public bool IsEmpty
		{
			get
			{
				if (width == 0)
				{
					return height == 0;
				}
				return false;
			}
		}

		public int Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}

		public int Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}

		public Size(Point pt)
		{
			width = pt.X;
			height = pt.Y;
		}

		public Size(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public static implicit operator SizeF(Size p)
		{
			return new SizeF(p.Width, p.Height);
		}

		public static Size operator +(Size sz1, Size sz2)
		{
			return Add(sz1, sz2);
		}

		public static Size operator -(Size sz1, Size sz2)
		{
			return Subtract(sz1, sz2);
		}

		public static Size operator *(int left, Size right)
		{
			return Multiply(right, left);
		}

		public static Size operator *(Size left, int right)
		{
			return Multiply(left, right);
		}

		public static Size operator /(Size left, int right)
		{
			return new Size(left.width / right, left.height / right);
		}

		public static SizeF operator *(float left, Size right)
		{
			return Multiply(right, left);
		}

		public static SizeF operator *(Size left, float right)
		{
			return Multiply(left, right);
		}

		public static SizeF operator /(Size left, float right)
		{
			return new SizeF((float)left.width / right, (float)left.height / right);
		}

		public static bool operator ==(Size sz1, Size sz2)
		{
			if (sz1.Width == sz2.Width)
			{
				return sz1.Height == sz2.Height;
			}
			return false;
		}

		public static bool operator !=(Size sz1, Size sz2)
		{
			return !(sz1 == sz2);
		}

		public static explicit operator Point(Size size)
		{
			return new Point(size.Width, size.Height);
		}

		public static Size Add(Size sz1, Size sz2)
		{
			return new Size(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
		}

		public static Size Ceiling(SizeF value)
		{
			return new Size((int)Math.Ceiling(value.Width), (int)Math.Ceiling(value.Height));
		}

		public static Size Subtract(Size sz1, Size sz2)
		{
			return new Size(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
		}

		public static Size Truncate(SizeF value)
		{
			return new Size((int)value.Width, (int)value.Height);
		}

		public static Size Round(SizeF value)
		{
			return new Size((int)Math.Round(value.Width), (int)Math.Round(value.Height));
		}

		public override bool Equals(object obj)
		{
			if (obj is Size)
			{
				return Equals((Size)obj);
			}
			return false;
		}

		public bool Equals(Size other)
		{
			return this == other;
		}

		public override int GetHashCode()
		{
			return System.Numerics.Hashing.HashHelpers.Combine(Width, Height);
		}

		public override string ToString()
		{
			return "{Width=" + width + ", Height=" + height + "}";
		}

		private static Size Multiply(Size size, int multiplier)
		{
			return new Size(size.width * multiplier, size.height * multiplier);
		}

		private static SizeF Multiply(Size size, float multiplier)
		{
			return new SizeF((float)size.width * multiplier, (float)size.height * multiplier);
		}

		static Size()
		{
		}
	}
	[Serializable]
	[TypeForwardedFrom("Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065")]
	[TypeConverter(typeof(SizeFConverter))]
	public struct SizeF : IEquatable<SizeF>
	{
		public static readonly SizeF Empty;

		private float width;

		private float height;

		[Browsable(false)]
		public bool IsEmpty
		{
			get
			{
				if (width == 0f)
				{
					return height == 0f;
				}
				return false;
			}
		}

		public float Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}

		public float Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}

		public SizeF(SizeF size)
		{
			width = size.width;
			height = size.height;
		}

		public SizeF(PointF pt)
		{
			width = pt.X;
			height = pt.Y;
		}

		public SizeF(float width, float height)
		{
			this.width = width;
			this.height = height;
		}

		public static SizeF operator +(SizeF sz1, SizeF sz2)
		{
			return Add(sz1, sz2);
		}

		public static SizeF operator -(SizeF sz1, SizeF sz2)
		{
			return Subtract(sz1, sz2);
		}

		public static SizeF operator *(float left, SizeF right)
		{
			return Multiply(right, left);
		}

		public static SizeF operator *(SizeF left, float right)
		{
			return Multiply(left, right);
		}

		public static SizeF operator /(SizeF left, float right)
		{
			return new SizeF(left.width / right, left.height / right);
		}

		public static bool operator ==(SizeF sz1, SizeF sz2)
		{
			if (sz1.Width == sz2.Width)
			{
				return sz1.Height == sz2.Height;
			}
			return false;
		}

		public static bool operator !=(SizeF sz1, SizeF sz2)
		{
			return !(sz1 == sz2);
		}

		public static explicit operator PointF(SizeF size)
		{
			return new PointF(size.Width, size.Height);
		}

		public static SizeF Add(SizeF sz1, SizeF sz2)
		{
			return new SizeF(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
		}

		public static SizeF Subtract(SizeF sz1, SizeF sz2)
		{
			return new SizeF(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
		}

		public override bool Equals(object obj)
		{
			if (obj is SizeF)
			{
				return Equals((SizeF)obj);
			}
			return false;
		}

		public bool Equals(SizeF other)
		{
			return this == other;
		}

		public override int GetHashCode()
		{
			return System.Numerics.Hashing.HashHelpers.Combine(Width.GetHashCode(), Height.GetHashCode());
		}

		public PointF ToPointF()
		{
			return (PointF)this;
		}

		public Size ToSize()
		{
			return Size.Truncate(this);
		}

		public override string ToString()
		{
			return "{Width=" + width + ", Height=" + height + "}";
		}

		private static SizeF Multiply(SizeF size, float multiplier)
		{
			return new SizeF(size.width * multiplier, size.height * multiplier);
		}

		static SizeF()
		{
		}
	}
}
