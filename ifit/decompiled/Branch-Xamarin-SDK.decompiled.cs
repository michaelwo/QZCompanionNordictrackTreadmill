using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v1.2", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Branch-Xamarin-SDK")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Branch-Xamarin-SDK")]
[assembly: AssemblyTitle("Branch-Xamarin-SDK")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace BranchXamarinSDK;

public abstract class Branch
{
	public const string version = "3.0.0";

	protected static Branch branchInstance;

	public static bool Debug;

	protected List<object> callbacksList = new List<object>();

	protected string branchKey { get; set; }

	public static Branch GetInstance()
	{
		if (branchInstance == null)
		{
			throw new BranchException("You must initialize Branch before you can use the Branch object!");
		}
		return branchInstance;
	}

	public virtual void InitSession(IBranchSessionInterface callback)
	{
		callbacksList.Clear();
	}

	public virtual void InitSession(IBranchBUOSessionInterface callback)
	{
		callbacksList.Clear();
	}

	public abstract Dictionary<string, object> GetLastReferringParams();

	public abstract BranchUniversalObject GetLastReferringBranchUniversalObject();

	public abstract BranchLinkProperties GetLastReferringBranchLinkProperties();

	public abstract Dictionary<string, object> GetFirstReferringParams();

	public abstract BranchUniversalObject GetFirstReferringBranchUniversalObject();

	public abstract BranchLinkProperties GetFirstReferringBranchLinkProperties();

	protected abstract void SetDebug();

	public abstract void ResetUserSession();

	public abstract void SetIdentity(string user, IBranchIdentityInterface callback);

	public abstract void Logout(IBranchIdentityInterface callback = null);

	public abstract void GetShortURL(IBranchUrlInterface callback, BranchUniversalObject universalObject, BranchLinkProperties linkProperties);

	public abstract void ShareLink(IBranchLinkShareInterface callback, BranchUniversalObject universalObject, BranchLinkProperties linkProperties, string message);

	public abstract void UserCompletedAction(string action, Dictionary<string, object> metadata = null);

	public abstract void SendEvent(BranchEvent branchEvent);

	public abstract void LoadRewards(IBranchRewardsInterface callback);

	public abstract void RedeemRewards(IBranchRewardsInterface callback, int amount, string bucket = "default");

	public abstract void GetCreditHistory(IBranchRewardsInterface callback, string bucket = "", string afterId = "", int length = 100, bool mostRecentFirst = true);

	public abstract int GetCredits();

	public abstract int GetCreditsForBucket(string bucket);

	public abstract void SetRetryInterval(int retryInterval);

	public abstract void SetMaxRetries(int maxRetries);

	public abstract void SetNetworkTimeout(int timeout);

	public abstract void RegisterView(BranchUniversalObject universalObject);

	public abstract void ListOnSpotlight(BranchUniversalObject universalObject);

	public abstract void SetRequestMetadata(string key, string value);

	public abstract void SetTrackingDisabled(bool value);
}
public static class Constants
{
	public const string SDK_VERSION = "3.0.0";

	public const int URL_TYPE_UNLIMITED = 0;

	public const int URL_TYPE_SINGLE_USE = 1;

	public const string URL_FEATURE_SHARE = "share";

	public const string URL_FEATURE_REFERRAL = "referral";

	public const string URL_FEATURE_INVITE = "invite";

	public const string URL_FEATURE_DEAL = "deal";

	public const string URL_FEATURE_GIFT = "gift";
}
public class BranchException : Exception
{
	public BranchException()
	{
	}

	public BranchException(string message)
		: base(message)
	{
	}

	public BranchException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
public interface IBranchBUOSessionInterface
{
	void InitSessionComplete(BranchUniversalObject buo, BranchLinkProperties blp);

	void SessionRequestError(BranchError error);
}
public interface IBranchIdentityInterface
{
	void IdentitySet(Dictionary<string, object> data);

	void LogoutComplete();

	void IdentityRequestError(BranchError error);
}
public interface IBranchLinkShareInterface
{
	void ChannelSelected(string channel);

	void LinkShareResponse(string sharedLink, string sharedChannel);

	void LinkShareRequestError(BranchError error);
}
public interface IBranchRewardsInterface
{
	void RewardsLoaded();

	void RewardsRedeemed();

	void CreditHistory(List<CreditHistoryEntry> history);

	void RewardsRequestError(BranchError error);
}
public interface IBranchSessionInterface
{
	void InitSessionComplete(Dictionary<string, object> data);

	void SessionRequestError(BranchError error);
}
public interface IBranchUrlInterface
{
	void ReceivedUrl(string uri);

	void UrlRequestError(BranchError error);
}
public class BranchContentMetadata
{
	private Dictionary<string, object> metadata = new Dictionary<string, object>();

	private List<string> imageCaptions = new List<string>();

	private Dictionary<string, string> customMetadata = new Dictionary<string, string>();

	public Dictionary<string, object> Metadata => metadata;

	public BranchContentSchema contentSchema
	{
		get
		{
			if (metadata.ContainsKey("$content_schema"))
			{
				return (BranchContentSchema)Enum.Parse(typeof(BranchContentSchema), metadata["$content_schema"].ToString());
			}
			return BranchContentSchema.NONE;
		}
		set
		{
			AddData("$content_schema", value.ToString());
		}
	}

	public float quantity
	{
		get
		{
			if (metadata.ContainsKey("$quantity"))
			{
				return (float)metadata["$quantity"];
			}
			return 0f;
		}
		set
		{
			AddData("$quantity", value);
		}
	}

	public float price
	{
		get
		{
			if (metadata.ContainsKey("$price"))
			{
				return (float)metadata["$price"];
			}
			return 0f;
		}
		set
		{
			AddData("$price", value);
		}
	}

	public BranchCurrencyType currencyType
	{
		get
		{
			if (metadata.ContainsKey("$currency"))
			{
				return (BranchCurrencyType)Enum.Parse(typeof(BranchCurrencyType), metadata["$currency"].ToString());
			}
			return BranchCurrencyType.NONE;
		}
		set
		{
			AddData("$currency", value.ToString());
		}
	}

	public string sku
	{
		get
		{
			if (metadata.ContainsKey("$sku"))
			{
				return metadata["$sku"].ToString();
			}
			return "";
		}
		set
		{
			AddData("$sku", value.ToString());
		}
	}

	public string productName
	{
		get
		{
			if (metadata.ContainsKey("$product_name"))
			{
				return metadata["$product_name"].ToString();
			}
			return "";
		}
		set
		{
			AddData("$product_name", value.ToString());
		}
	}

	public string productBrand
	{
		get
		{
			if (metadata.ContainsKey("$product_brand"))
			{
				return metadata["$product_brand"].ToString();
			}
			return "";
		}
		set
		{
			AddData("$product_brand", value.ToString());
		}
	}

	public BranchProductCategory productCategory
	{
		get
		{
			if (metadata.ContainsKey("$product_category"))
			{
				return metadata["$product_category"].ToString().parse();
			}
			return BranchProductCategory.NONE;
		}
		set
		{
			AddData("$product_category", value.toString());
		}
	}

	public BranchCondition condition
	{
		get
		{
			if (metadata.ContainsKey("$condition"))
			{
				return (BranchCondition)Enum.Parse(typeof(BranchCondition), metadata["$condition"].ToString());
			}
			return BranchCondition.NONE;
		}
		set
		{
			AddData("$condition", value.ToString());
		}
	}

	public string productVariant
	{
		get
		{
			if (metadata.ContainsKey("$product_variant"))
			{
				return metadata["$product_variant"].ToString();
			}
			return "";
		}
		set
		{
			AddData("$product_variant", value.ToString());
		}
	}

	public float ratingAverage
	{
		get
		{
			if (metadata.ContainsKey("$rating_average"))
			{
				return (float)metadata["$rating_average"];
			}
			return 0f;
		}
		set
		{
			AddData("$rating_average", value);
		}
	}

	public int ratingCount
	{
		get
		{
			if (metadata.ContainsKey("$rating_count"))
			{
				return (int)metadata["$rating_count"];
			}
			return 0;
		}
		set
		{
			AddData("$rating_count", value);
		}
	}

	public float ratingMax
	{
		get
		{
			if (metadata.ContainsKey("$rating_max"))
			{
				return (float)metadata["$rating_max"];
			}
			return 0f;
		}
		set
		{
			AddData("$rating_max", value);
		}
	}

	public string addressStreet
	{
		get
		{
			if (metadata.ContainsKey("$address_street"))
			{
				return metadata["$address_street"].ToString();
			}
			return "";
		}
		set
		{
			AddData("$address_street", value.ToString());
		}
	}

	public string addressCity
	{
		get
		{
			if (metadata.ContainsKey("$address_city"))
			{
				return metadata["$address_city"].ToString();
			}
			return "";
		}
		set
		{
			AddData("$address_city", value.ToString());
		}
	}

	public string addressRegion
	{
		get
		{
			if (metadata.ContainsKey("$address_region"))
			{
				return metadata["$address_region"].ToString();
			}
			return "";
		}
		set
		{
			AddData("$address_region", value.ToString());
		}
	}

	public string addressCountry
	{
		get
		{
			if (metadata.ContainsKey("$address_country"))
			{
				return metadata["$address_country"].ToString();
			}
			return "";
		}
		set
		{
			AddData("$address_country", value.ToString());
		}
	}

	public string addressPostalCode
	{
		get
		{
			if (metadata.ContainsKey("$address_postal_code"))
			{
				return metadata["$address_postal_code"].ToString();
			}
			return "";
		}
		set
		{
			AddData("$address_postal_code", value.ToString());
		}
	}

	public float latitude
	{
		get
		{
			if (metadata.ContainsKey("$latitude"))
			{
				return (float)metadata["$latitude"];
			}
			return 0f;
		}
		set
		{
			AddData("$latitude", value);
		}
	}

	public float longitude
	{
		get
		{
			if (metadata.ContainsKey("$longitude"))
			{
				return (float)metadata["$longitude"];
			}
			return 0f;
		}
		set
		{
			AddData("$longitude", value);
		}
	}

	public void AddImageCaption(string imageCaption)
	{
		imageCaptions.Add(imageCaption);
	}

	public List<string> GetImageCaptions()
	{
		return imageCaptions;
	}

	public void AddCustomMetadata(string key, string value)
	{
		if (!customMetadata.ContainsKey(key))
		{
			customMetadata.Add(key, value);
		}
		else
		{
			customMetadata[key] = value;
		}
	}

	public Dictionary<string, string> GetCustomMetadata()
	{
		return customMetadata;
	}

	public void setAddress(string street, string city, string region, string country, string postalCode)
	{
		addressStreet = street;
		addressCity = city;
		addressRegion = region;
		addressCountry = country;
		addressPostalCode = postalCode;
	}

	public void setLocation(float latitude, float longitude)
	{
		this.latitude = latitude;
		this.longitude = longitude;
	}

	public void setRating(float averageRating, float maximumRating, int ratingCount)
	{
		ratingAverage = averageRating;
		ratingMax = maximumRating;
		this.ratingCount = ratingCount;
	}

	private void AddData(string key, object value)
	{
		if (!metadata.ContainsKey(key))
		{
			metadata.Add(key, value);
		}
		else
		{
			metadata[key] = value;
		}
	}

	public void loadFromJson(string json)
	{
		if (!string.IsNullOrEmpty(json))
		{
			Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
			loadFromDictionary(data);
		}
	}

	public void loadFromDictionary(Dictionary<string, object> data)
	{
		if (data == null)
		{
			return;
		}
		if (data.ContainsKey("$content_schema") && data["$content_schema"] != null)
		{
			contentSchema = (BranchContentSchema)Enum.Parse(typeof(BranchContentSchema), data["$content_schema"].ToString());
			data.Remove("$content_schema");
		}
		if (data.ContainsKey("$quantity") && data["$quantity"] != null)
		{
			quantity = Convert.ToSingle(data["$quantity"]);
			data.Remove("$quantity");
		}
		if (data.ContainsKey("$price") && data["$price"] != null)
		{
			price = Convert.ToSingle(data["$price"]);
			data.Remove("$price");
		}
		if (data.ContainsKey("$currency") && data["$currency"] != null)
		{
			currencyType = (BranchCurrencyType)Enum.Parse(typeof(BranchCurrencyType), data["$currency"].ToString());
			data.Remove("$currency");
		}
		if (data.ContainsKey("$sku") && data["$sku"] != null)
		{
			sku = data["$sku"].ToString();
			data.Remove("$sku");
		}
		if (data.ContainsKey("$product_name") && data["$product_name"] != null)
		{
			productName = data["$product_name"].ToString();
			data.Remove("$product_name");
		}
		if (data.ContainsKey("$product_brand") && data["$product_brand"] != null)
		{
			productBrand = data["$product_brand"].ToString();
			data.Remove("$product_brand");
		}
		if (data.ContainsKey("$product_category") && data["$product_category"] != null)
		{
			productCategory = data["$product_category"].ToString().parse();
			data.Remove("$product_category");
		}
		if (data.ContainsKey("$condition") && data["$condition"] != null)
		{
			condition = (BranchCondition)Enum.Parse(typeof(BranchCondition), data["$condition"].ToString());
			data.Remove("$condition");
		}
		if (data.ContainsKey("$product_variant") && data["$product_variant"] != null)
		{
			productVariant = data["$product_variant"].ToString();
			data.Remove("$product_variant");
		}
		if (data.ContainsKey("$rating_average") && data["$rating_average"] != null)
		{
			ratingAverage = Convert.ToSingle(data["$rating_average"]);
			data.Remove("$rating_average");
		}
		if (data.ContainsKey("$rating_count") && data["$rating_count"] != null)
		{
			ratingCount = Convert.ToInt32(data["$rating_count"]);
			data.Remove("$rating_count");
		}
		if (data.ContainsKey("$rating_max") && data["$rating_max"] != null)
		{
			ratingMax = Convert.ToSingle(data["$rating_max"]);
			data.Remove("$rating_max");
		}
		if (data.ContainsKey("$address_street") && data["$address_street"] != null)
		{
			addressStreet = data["$address_street"].ToString();
			data.Remove("$address_street");
		}
		if (data.ContainsKey("$address_city") && data["$address_city"] != null)
		{
			addressCity = data["$address_city"].ToString();
			data.Remove("$address_city");
		}
		if (data.ContainsKey("$address_region") && data["$address_region"] != null)
		{
			addressRegion = data["$address_region"].ToString();
			data.Remove("$address_region");
		}
		if (data.ContainsKey("$address_country") && data["$address_country"] != null)
		{
			addressCountry = data["$address_country"].ToString();
			data.Remove("$address_country");
		}
		if (data.ContainsKey("$address_postal_code") && data["$address_postal_code"] != null)
		{
			addressPostalCode = data["$address_postal_code"].ToString();
			data.Remove("$address_postal_code");
		}
		if (data.ContainsKey("$latitude") && data["$latitude"] != null)
		{
			latitude = Convert.ToSingle(data["$latitude"]);
			data.Remove("$latitude");
		}
		if (data.ContainsKey("$longitude") && data["$longitude"] != null)
		{
			longitude = Convert.ToSingle(data["$longitude"]);
			data.Remove("$longitude");
		}
		if (data.ContainsKey("$image_captions") && data["$image_captions"] != null)
		{
			if (data["$image_captions"] is List<object> list)
			{
				foreach (object item in list)
				{
					imageCaptions.Add(item.ToString());
				}
			}
			data.Remove("$image_captions");
		}
		foreach (string key in data.Keys)
		{
			customMetadata.Add(key, data[key].ToString());
		}
	}

	public string ToJsonString()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>(metadata);
		if (imageCaptions.Count > 0)
		{
			dictionary.Add("$image_captions", imageCaptions);
		}
		if (customMetadata.Count > 0)
		{
			foreach (string key in customMetadata.Keys)
			{
				dictionary.Add(key, customMetadata[key]);
			}
		}
		return JsonConvert.SerializeObject(dictionary);
	}
}
public enum BranchCurrencyType
{
	AED,
	AFN,
	ALL,
	AMD,
	ANG,
	AOA,
	ARS,
	AUD,
	AWG,
	AZN,
	BAM,
	BBD,
	BDT,
	BGN,
	BHD,
	BIF,
	BMD,
	BND,
	BOB,
	BOV,
	BRL,
	BSD,
	BTN,
	BWP,
	BYN,
	BYR,
	BZD,
	CAD,
	CDF,
	CHE,
	CHF,
	CHW,
	CLF,
	CLP,
	CNY,
	COP,
	COU,
	CRC,
	CUC,
	CUP,
	CVE,
	CZK,
	DJF,
	DKK,
	DOP,
	DZD,
	EGP,
	ERN,
	ETB,
	EUR,
	FJD,
	FKP,
	GBP,
	GEL,
	GHS,
	GIP,
	GMD,
	GNF,
	GTQ,
	GYD,
	HKD,
	HNL,
	HRK,
	HTG,
	HUF,
	IDR,
	ILS,
	INR,
	IQD,
	IRR,
	ISK,
	JMD,
	JOD,
	JPY,
	KES,
	KGS,
	KHR,
	KMF,
	KPW,
	KRW,
	KWD,
	KYD,
	KZT,
	LAK,
	LBP,
	LKR,
	LRD,
	LSL,
	LYD,
	MAD,
	MDL,
	MGA,
	MKD,
	MMK,
	MNT,
	MOP,
	MRO,
	MUR,
	MVR,
	MWK,
	MXN,
	MXV,
	MYR,
	MZN,
	NAD,
	NGN,
	NIO,
	NOK,
	NPR,
	NZD,
	OMR,
	PAB,
	PEN,
	PGK,
	PHP,
	PKR,
	PLN,
	PYG,
	QAR,
	RON,
	RSD,
	RUB,
	RWF,
	SAR,
	SBD,
	SCR,
	SDG,
	SEK,
	SGD,
	SHP,
	SLL,
	SOS,
	SRD,
	SSP,
	STD,
	SYP,
	SZL,
	THB,
	TJS,
	TMT,
	TND,
	TOP,
	TRY,
	TTD,
	TWD,
	TZS,
	UAH,
	UGX,
	USD,
	USN,
	UYI,
	UYU,
	UZS,
	VEF,
	VND,
	VUV,
	WST,
	XAF,
	XAG,
	XAU,
	XBA,
	XBB,
	XBC,
	XBD,
	XCD,
	XDR,
	XFU,
	XOF,
	XPD,
	XPF,
	XPT,
	XSU,
	XTS,
	XUA,
	XXX,
	YER,
	ZAR,
	ZMW,
	NONE
}
public enum BranchEventType
{
	ADD_TO_CART,
	ADD_TO_WISHLIST,
	VIEW_CART,
	INITIATE_PURCHASE,
	ADD_PAYMENT_INFO,
	PURCHASE,
	SPEND_CREDITS,
	SEARCH,
	VIEW_ITEM,
	VIEW_ITEMS,
	RATE,
	SHARE,
	COMPLETE_REGISTRATION,
	COMPLETE_TUTORIAL,
	ACHIEVE_LEVEL,
	UNLOCK_ACHIEVEMENT
}
public enum BranchContentSchema
{
	COMMERCE_AUCTION,
	COMMERCE_BUSINESS,
	COMMERCE_OTHER,
	COMMERCE_PRODUCT,
	COMMERCE_RESTAURANT,
	COMMERCE_SERVICE,
	COMMERCE_TRAVEL_FLIGHT,
	COMMERCE_TRAVEL_HOTEL,
	COMMERCE_TRAVEL_OTHER,
	GAME_STATE,
	MEDIA_IMAGE,
	MEDIA_MIXED,
	MEDIA_MUSIC,
	MEDIA_OTHER,
	MEDIA_VIDEO,
	OTHER,
	TEXT_ARTICLE,
	TEXT_BLOG,
	TEXT_OTHER,
	TEXT_RECIPE,
	TEXT_REVIEW,
	TEXT_SEARCH_RESULTS,
	TEXT_STORY,
	TEXT_TECHNICAL_DOC,
	NONE
}
public enum BranchProductCategory
{
	ANIMALS_AND_PET_SUPPLIES,
	APPAREL_AND_ACCESSORIES,
	ARTS_AND_ENTERTAINMENT,
	BABY_AND_TODDLER,
	BUSINESS_AND_INDUSTRIAL,
	CAMERAS_AND_OPTICS,
	ELECTRONICS,
	FOOD_BEVERAGES_AND_TOBACCO,
	FURNITURE,
	HARDWARE,
	HEALTH_AND_BEAUTY,
	HOME_AND_GARDEN,
	LUGGAGE_AND_BAGS,
	MATURE,
	MEDIA,
	OFFICE_SUPPLIES,
	RELIGIOUS_AND_CEREMONIAL,
	SOFTWARE,
	SPORTING_GOODS,
	TOYS_AND_GAMES,
	VEHICLES_AND_PARTS,
	NONE
}
public enum BranchCondition
{
	OTHER,
	NEW,
	GOOD,
	FAIR,
	POOR,
	USED,
	REFURBISHED,
	EXCELLENT,
	NONE
}
public static class BranchEnumExtensions
{
	public static string toString(this BranchProductCategory category)
	{
		return category switch
		{
			BranchProductCategory.ANIMALS_AND_PET_SUPPLIES => "Animals & Pet Supplies", 
			BranchProductCategory.APPAREL_AND_ACCESSORIES => "Apparel & Accessories", 
			BranchProductCategory.ARTS_AND_ENTERTAINMENT => "Arts & Entertainment", 
			BranchProductCategory.BABY_AND_TODDLER => "Baby & Toddler", 
			BranchProductCategory.BUSINESS_AND_INDUSTRIAL => "Business & Industrial", 
			BranchProductCategory.CAMERAS_AND_OPTICS => "Cameras & Optics", 
			BranchProductCategory.ELECTRONICS => "Electronics", 
			BranchProductCategory.FOOD_BEVERAGES_AND_TOBACCO => "Food, Beverages & Tobacco", 
			BranchProductCategory.FURNITURE => "Furniture", 
			BranchProductCategory.HARDWARE => "Hardware", 
			BranchProductCategory.HEALTH_AND_BEAUTY => "Health & Beauty", 
			BranchProductCategory.HOME_AND_GARDEN => "Home & Garden", 
			BranchProductCategory.LUGGAGE_AND_BAGS => "Luggage & Bags", 
			BranchProductCategory.MATURE => "Mature", 
			BranchProductCategory.MEDIA => "Media", 
			BranchProductCategory.OFFICE_SUPPLIES => "Office Supplies", 
			BranchProductCategory.RELIGIOUS_AND_CEREMONIAL => "Religious & Ceremonial", 
			BranchProductCategory.SOFTWARE => "Software", 
			BranchProductCategory.SPORTING_GOODS => "Sporting Goods", 
			BranchProductCategory.TOYS_AND_GAMES => "Toys & Games", 
			BranchProductCategory.VEHICLES_AND_PARTS => "Vehicles & Parts", 
			_ => "", 
		};
	}

	public static BranchProductCategory parse(this string category)
	{
		if (category.Equals("Animals & Pet Supplies"))
		{
			return BranchProductCategory.ANIMALS_AND_PET_SUPPLIES;
		}
		if (category.Equals("Apparel & Accessories"))
		{
			return BranchProductCategory.APPAREL_AND_ACCESSORIES;
		}
		if (category.Equals("Arts & Entertainment"))
		{
			return BranchProductCategory.ARTS_AND_ENTERTAINMENT;
		}
		if (category.Equals("Baby & Toddler"))
		{
			return BranchProductCategory.BABY_AND_TODDLER;
		}
		if (category.Equals("Business & Industrial"))
		{
			return BranchProductCategory.BUSINESS_AND_INDUSTRIAL;
		}
		if (category.Equals("Cameras & Optics"))
		{
			return BranchProductCategory.CAMERAS_AND_OPTICS;
		}
		if (category.Equals("Electronics"))
		{
			return BranchProductCategory.ELECTRONICS;
		}
		if (category.Equals("Food, Beverages & Tobacco"))
		{
			return BranchProductCategory.FOOD_BEVERAGES_AND_TOBACCO;
		}
		if (category.Equals("Furniture"))
		{
			return BranchProductCategory.FURNITURE;
		}
		if (category.Equals("Hardware"))
		{
			return BranchProductCategory.HARDWARE;
		}
		if (category.Equals("Health & Beauty"))
		{
			return BranchProductCategory.HEALTH_AND_BEAUTY;
		}
		if (category.Equals("Home & Garden"))
		{
			return BranchProductCategory.HOME_AND_GARDEN;
		}
		if (category.Equals("Luggage & Bags"))
		{
			return BranchProductCategory.LUGGAGE_AND_BAGS;
		}
		if (category.Equals("Mature"))
		{
			return BranchProductCategory.MATURE;
		}
		if (category.Equals("Media"))
		{
			return BranchProductCategory.MEDIA;
		}
		if (category.Equals("Office Supplies"))
		{
			return BranchProductCategory.OFFICE_SUPPLIES;
		}
		if (category.Equals("Religious & Ceremonial"))
		{
			return BranchProductCategory.RELIGIOUS_AND_CEREMONIAL;
		}
		if (category.Equals("Software"))
		{
			return BranchProductCategory.SOFTWARE;
		}
		if (category.Equals("Sporting Goods"))
		{
			return BranchProductCategory.SPORTING_GOODS;
		}
		if (category.Equals("Toys & Games"))
		{
			return BranchProductCategory.TOYS_AND_GAMES;
		}
		if (category.Equals("Vehicles & Parts"))
		{
			return BranchProductCategory.VEHICLES_AND_PARTS;
		}
		return BranchProductCategory.NONE;
	}
}
public class BranchError
{
	public string ErrorMessage { get; set; }

	public int ErrorCode { get; set; }

	public BranchError(int code)
	{
		ErrorCode = code;
		ErrorMessage = "Error: " + code;
	}

	public BranchError(string message)
	{
		ErrorCode = -1;
		ErrorMessage = message;
	}

	public BranchError(string message, int code)
	{
		ErrorCode = code;
		ErrorMessage = message;
	}
}
public class BranchEvent
{
	private Dictionary<string, object> data = new Dictionary<string, object>();

	private Dictionary<string, string> customData = new Dictionary<string, string>();

	private List<string> contentItems = new List<string>();

	public BranchEvent(string customEventName)
	{
		AddData("event_name", customEventName);
	}

	public BranchEvent(BranchEventType branchEventType)
	{
		AddData("event_name", branchEventType.ToString());
	}

	public void SetAlias(string alias)
	{
		AddData("customer_event_alias", alias);
	}

	public void SetTransactionID(string transactionID)
	{
		AddData("transaction_id", transactionID);
	}

	public void SetAffiliation(string affiliation)
	{
		AddData("affiliation", affiliation);
	}

	public void SetCoupon(string coupon)
	{
		AddData("coupon", coupon);
	}

	public void SetCurrency(BranchCurrencyType currency)
	{
		AddData("currency", currency.ToString());
	}

	public void SetTax(float tax)
	{
		AddData("tax", tax);
	}

	public void SetRevenue(float revenue)
	{
		AddData("revenue", revenue);
	}

	public void SetDescription(string description)
	{
		AddData("description", description);
	}

	public void SetShipping(float shipping)
	{
		AddData("shipping", shipping);
	}

	public void SetSearchQuery(string searchQuery)
	{
		AddData("search_query", searchQuery);
	}

	public void AddCustomData(string key, string value)
	{
		if (!customData.ContainsKey(key))
		{
			customData.Add(key, value);
		}
		else
		{
			customData[key] = value;
		}
	}

	public void AddContentItem(BranchUniversalObject contentItem)
	{
		contentItems.Add(contentItem.ToJsonString());
	}

	public Dictionary<string, object> ToDictionary()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>(data);
		if (customData.Count > 0)
		{
			dictionary.Add("custom_data", customData);
		}
		if (contentItems.Count > 0)
		{
			dictionary.Add("content_items", contentItems);
		}
		return dictionary;
	}

	public string ToJsonString()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>(data);
		if (customData.Count > 0)
		{
			dictionary.Add("custom_data", customData);
		}
		if (contentItems.Count > 0)
		{
			dictionary.Add("content_items", contentItems);
		}
		return JsonConvert.SerializeObject(dictionary);
	}

	private void AddData(string key, object value)
	{
		if (!data.ContainsKey(key))
		{
			data.Add(key, value);
		}
		else
		{
			data[key] = value;
		}
	}
}
public class BranchLinkProperties
{
	public List<string> tags;

	public string feature;

	public string alias;

	public string channel;

	public string stage;

	public int matchDuration;

	public Dictionary<string, string> controlParams;

	public BranchLinkProperties()
	{
		tags = new List<string>();
		feature = "";
		alias = "";
		channel = "";
		stage = "";
		matchDuration = 0;
		controlParams = new Dictionary<string, string>();
	}

	public BranchLinkProperties(string json)
	{
		tags = new List<string>();
		feature = "";
		alias = "";
		channel = "";
		stage = "";
		matchDuration = 0;
		controlParams = new Dictionary<string, string>();
		loadFromJson(json);
	}

	public BranchLinkProperties(Dictionary<string, object> data)
	{
		tags = new List<string>();
		feature = "";
		alias = "";
		channel = "";
		stage = "";
		matchDuration = 0;
		controlParams = new Dictionary<string, string>();
		loadFromDictionary(data);
	}

	public void loadFromJson(string json)
	{
		if (!string.IsNullOrEmpty(json))
		{
			Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
			loadFromDictionary(data);
		}
	}

	public void loadFromDictionary(Dictionary<string, object> data)
	{
		if (data == null)
		{
			return;
		}
		if (data.ContainsKey("~tags") && data["~tags"] is IList<object> list)
		{
			foreach (object item in list)
			{
				tags.Add(item.ToString());
			}
		}
		if (data.ContainsKey("~feature"))
		{
			feature = data["~feature"].ToString();
		}
		if (data.ContainsKey("~alias"))
		{
			alias = data["~alias"].ToString();
		}
		if (data.ContainsKey("~channel"))
		{
			channel = data["~channel"].ToString();
		}
		if (data.ContainsKey("~stage"))
		{
			stage = data["~stage"].ToString();
		}
		if (data.ContainsKey("~duration") && !string.IsNullOrEmpty(data["~duration"].ToString()))
		{
			matchDuration = Convert.ToInt32(data["~duration"].ToString());
		}
		if (!data.ContainsKey("control_params") || data["control_params"] == null || !(data["control_params"] is IDictionary<string, object> dictionary))
		{
			return;
		}
		foreach (string key in dictionary.Keys)
		{
			controlParams.Add(key, dictionary[key].ToString());
		}
	}

	public Dictionary<string, object> ToDictionary()
	{
		return new Dictionary<string, object>
		{
			{ "~tags", tags },
			{ "~feature", feature },
			{ "~alias", alias },
			{ "~channel", channel },
			{ "~stage", stage },
			{
				"~duration",
				matchDuration.ToString()
			},
			{ "control_params", controlParams }
		};
	}

	public string ToJsonString()
	{
		return JsonConvert.SerializeObject(ToDictionary());
	}
}
public class BranchUniversalObject
{
	public string canonicalIdentifier;

	public string canonicalUrl;

	public string title;

	public string contentDescription;

	public string imageUrl;

	public BranchContentMetadata metadata;

	public int contentIndexMode;

	public int localIndexMode;

	public List<string> keywords;

	public DateTime? expirationDate;

	public BranchUniversalObject()
	{
		Init();
	}

	public BranchUniversalObject(string json)
	{
		Init();
		loadFromJson(json);
	}

	public BranchUniversalObject(Dictionary<string, object> data)
	{
		Init();
		loadFromDictionary(data);
	}

	private void Init()
	{
		canonicalIdentifier = "";
		canonicalUrl = "";
		title = "";
		contentDescription = "";
		imageUrl = "";
		metadata = new BranchContentMetadata();
		contentIndexMode = 0;
		localIndexMode = 0;
		keywords = new List<string>();
		expirationDate = new DateTime(2200, 12, 30);
	}

	public void loadFromJson(string json)
	{
		if (!string.IsNullOrEmpty(json))
		{
			Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
			loadFromDictionary(data);
		}
	}

	public void loadFromDictionary(Dictionary<string, object> data)
	{
		if (data == null)
		{
			return;
		}
		expirationDate = new DateTime(2200, 12, 30);
		if (data.ContainsKey("$canonical_identifier") && data["$canonical_identifier"] != null)
		{
			canonicalIdentifier = data["$canonical_identifier"].ToString();
		}
		if (data.ContainsKey("$canonical_url") && data["$canonical_url"] != null)
		{
			canonicalUrl = data["$canonical_url"].ToString();
		}
		if (data.ContainsKey("$og_title") && data["$og_title"] != null)
		{
			title = data["$og_title"].ToString();
		}
		if (data.ContainsKey("$og_description") && data["$og_description"] != null)
		{
			contentDescription = data["$og_description"].ToString();
		}
		if (data.ContainsKey("$og_image_url") && data["$og_image_url"] != null)
		{
			imageUrl = data["$og_image_url"].ToString();
		}
		if (data.ContainsKey("$publicly_indexable") && !string.IsNullOrEmpty(data["$publicly_indexable"].ToString()))
		{
			contentIndexMode = Convert.ToInt32(data["$publicly_indexable"].ToString());
		}
		if (data.ContainsKey("$locally_indexable") && !string.IsNullOrEmpty(data["$locally_indexable"].ToString()))
		{
			localIndexMode = Convert.ToInt32(data["$locally_indexable"].ToString());
		}
		if (data.ContainsKey("$exp_date") && !string.IsNullOrEmpty(data["$exp_date"].ToString()))
		{
			expirationDate = new DateTime(Convert.ToInt64(data["$exp_date"].ToString()) * 10000);
		}
		if (data.ContainsKey("$keywords") && data["$keywords"] != null && data["$keywords"] is List<object> list)
		{
			foreach (object item in list)
			{
				keywords.Add(item.ToString());
			}
		}
		if (!data.ContainsKey("metadata") || data["metadata"] == null || !(data["metadata"] is Dictionary<string, object> dictionary))
		{
			return;
		}
		if (dictionary.ContainsKey("+clicked_branch_link"))
		{
			if (dictionary["+clicked_branch_link"].ToString().Equals("1"))
			{
				dictionary["+clicked_branch_link"] = "true";
			}
			else
			{
				dictionary["+clicked_branch_link"] = "false";
			}
		}
		metadata.loadFromDictionary(dictionary);
	}

	public Dictionary<string, object> ToDictionary()
	{
		return new Dictionary<string, object>
		{
			{ "$canonical_identifier", canonicalIdentifier },
			{ "$canonical_url", canonicalUrl },
			{ "$og_title", title },
			{ "$og_description", contentDescription },
			{ "$og_image_url", imageUrl },
			{
				"$publicly_indexable",
				contentIndexMode.ToString()
			},
			{
				"$locally_indexable",
				localIndexMode.ToString()
			},
			{
				"$exp_date",
				expirationDate.HasValue ? (expirationDate.Value.Ticks / 10000).ToString() : "0"
			},
			{ "$keywords", keywords },
			{
				"metadata",
				metadata.ToJsonString()
			}
		};
	}

	public string ToJsonString()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{ "$canonical_identifier", canonicalIdentifier },
			{ "$canonical_url", canonicalUrl },
			{ "$og_title", title },
			{ "$og_description", contentDescription },
			{ "$og_image_url", imageUrl },
			{
				"$publicly_indexable",
				contentIndexMode.ToString()
			},
			{
				"$locally_indexable",
				localIndexMode.ToString()
			},
			{
				"$exp_date",
				expirationDate.HasValue ? (expirationDate.Value.Ticks / 10000).ToString() : "0"
			},
			{ "$keywords", keywords },
			{
				"metadata",
				metadata.ToJsonString()
			}
		});
	}
}
public class CreditHistoryEntry
{
	public class Transaction
	{
		public string date;

		public string id;

		public string bucket;

		public int amount;

		public int type;
	}

	public Transaction transaction;

	public string referrer;

	public string referree;
}
