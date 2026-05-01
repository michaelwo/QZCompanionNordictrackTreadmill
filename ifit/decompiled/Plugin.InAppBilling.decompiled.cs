using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.BillingClient.Api;
using Android.Content;
using Android.Runtime;
using Xamarin.Essentials;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: ResourceDesigner("Plugin.InAppBilling.Resource", IsApplication = false)]
[assembly: TargetFramework("MonoAndroid,Version=v10.0", FrameworkDisplayName = "Xamarin.Android v10.0 Support")]
[assembly: AssemblyCompany("James Montemagno")]
[assembly: AssemblyConfiguration("release")]
[assembly: AssemblyCopyright("Copyright 2022")]
[assembly: AssemblyDescription("\r\n      .NET MAUI, Xamarin, and Windows Plugin to In-App Billing. Get item information, purchase items, and restore purchases with a cross-platform API.\r\n      Read the full documenation on the projects page.\r\n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0.0+871c5fae7a27d9c6d60f32d868a7b03602f3a482")]
[assembly: AssemblyProduct("Plugin.InAppBilling (MonoAndroid10.0)")]
[assembly: AssemblyTitle("Plugin.InAppBilling")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/jamesmontemagno/InAppBillingPlugin")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Plugin.InAppBilling;

public class CrossInAppBilling
{
	private static Lazy<IInAppBilling> implementation = new Lazy<IInAppBilling>(() => CreateInAppBilling(), LazyThreadSafetyMode.PublicationOnly);

	public static bool IsSupported
	{
		get
		{
			if (implementation.Value != null)
			{
				return true;
			}
			return false;
		}
	}

	public static IInAppBilling Current => implementation.Value ?? throw NotImplementedInReferenceAssembly();

	private static IInAppBilling CreateInAppBilling()
	{
		return new InAppBillingImplementation();
	}

	internal static Exception NotImplementedInReferenceAssembly()
	{
		return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
	}

	public static void Dispose()
	{
		if (implementation != null && implementation.IsValueCreated)
		{
			implementation.Value.Dispose();
			implementation = new Lazy<IInAppBilling>(() => CreateInAppBilling(), LazyThreadSafetyMode.PublicationOnly);
		}
	}
}
public abstract class BaseInAppBilling : IInAppBilling, IDisposable
{
	private bool disposed;

	public virtual Storefront Storefront { get; }

	public virtual bool CanMakePayments { get; } = true;

	public virtual string ReceiptData { get; } = string.Empty;

	public virtual bool IsConnected { get; set; } = true;

	public abstract bool InTestingMode { get; set; }

	public virtual Task<bool> ConnectAsync(bool enablePendingPurchases = true)
	{
		return Task.FromResult(result: true);
	}

	public virtual Task DisconnectAsync()
	{
		return Task.CompletedTask;
	}

	public abstract Task<IEnumerable<InAppBillingProduct>> GetProductInfoAsync(ItemType itemType, params string[] productIds);

	public abstract Task<IEnumerable<InAppBillingPurchase>> GetPurchasesAsync(ItemType itemType);

	public virtual Task<IEnumerable<InAppBillingPurchase>> GetPurchasesHistoryAsync(ItemType itemType)
	{
		return Task.FromResult((IEnumerable<InAppBillingPurchase>)new List<InAppBillingPurchase>());
	}

	public abstract Task<InAppBillingPurchase> PurchaseAsync(string productId, ItemType itemType, string obfuscatedAccountId = null, string obfuscatedProfileId = null);

	public abstract Task<InAppBillingPurchase> UpgradePurchasedSubscriptionAsync(string newProductId, string purchaseTokenOfOriginalSubscription, SubscriptionProrationMode prorationMode = SubscriptionProrationMode.ImmediateWithTimeProration);

	public abstract Task<bool> ConsumePurchaseAsync(string productId, string transactionIdentifier);

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~BaseInAppBilling()
	{
		Dispose(disposing: false);
	}

	public virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			disposed = true;
		}
	}

	public virtual Task<IEnumerable<(string Id, bool Success)>> FinalizePurchaseAsync(params string[] transactionIdentifier)
	{
		return Task.FromResult(new List<(string, bool)>().AsEnumerable());
	}

	public virtual Task<IEnumerable<(string Id, bool Success)>> FinalizePurchaseOfProductAsync(params string[] productIds)
	{
		return Task.FromResult(new List<(string, bool)>().AsEnumerable());
	}

	public virtual void PresentCodeRedemption()
	{
	}
}
public enum ConsumptionState
{
	NoYetConsumed,
	Consumed
}
[AttributeUsage(AttributeTargets.All)]
[EditorBrowsable(EditorBrowsableState.Never)]
internal sealed class PreserveAttribute : Attribute
{
	public bool AllMembers;

	public bool Conditional;

	public PreserveAttribute(bool allMembers, bool conditional)
	{
		AllMembers = allMembers;
		Conditional = conditional;
	}

	public PreserveAttribute()
	{
	}
}
[Preserve(AllMembers = true)]
public interface IInAppBilling : IDisposable
{
	bool IsConnected { get; set; }

	bool InTestingMode { get; set; }

	Storefront Storefront { get; }

	string ReceiptData { get; }

	bool CanMakePayments { get; }

	Task<IEnumerable<(string Id, bool Success)>> FinalizePurchaseAsync(params string[] transactionIdentifier);

	Task<IEnumerable<(string Id, bool Success)>> FinalizePurchaseOfProductAsync(params string[] productIds);

	Task<bool> ConnectAsync(bool enablePendingPurchases = true);

	Task DisconnectAsync();

	Task<IEnumerable<InAppBillingProduct>> GetProductInfoAsync(ItemType itemType, params string[] productIds);

	Task<IEnumerable<InAppBillingPurchase>> GetPurchasesAsync(ItemType itemType);

	Task<IEnumerable<InAppBillingPurchase>> GetPurchasesHistoryAsync(ItemType itemType);

	Task<InAppBillingPurchase> PurchaseAsync(string productId, ItemType itemType, string obfuscatedAccountId = null, string obfuscatedProfileId = null);

	Task<InAppBillingPurchase> UpgradePurchasedSubscriptionAsync(string newProductId, string purchaseTokenOfOriginalSubscription, SubscriptionProrationMode prorationMode = SubscriptionProrationMode.ImmediateWithTimeProration);

	Task<bool> ConsumePurchaseAsync(string productId, string transactionIdentifier);

	void PresentCodeRedemption();
}
[Preserve(AllMembers = true)]
public interface IInAppBillingVerifyPurchase
{
	Task<bool> VerifyPurchase(string signedData, string signature, string productId = null, string transactionId = null);
}
public enum PurchaseError
{
	BillingUnavailable,
	DeveloperError,
	ItemUnavailable,
	GeneralError,
	UserCancelled,
	AppStoreUnavailable,
	PaymentNotAllowed,
	PaymentInvalid,
	InvalidProduct,
	ProductRequestFailed,
	RestoreFailed,
	ServiceUnavailable,
	AlreadyOwned,
	NotOwned,
	FeatureNotSupported,
	ServiceDisconnected,
	ServiceTimeout,
	AppleTermsConditionsChanged
}
public class InAppBillingPurchaseException : Exception
{
	public PurchaseError PurchaseError { get; }

	public InAppBillingPurchaseException(PurchaseError error, Exception ex)
		: base("Unable to process purchase.", ex)
	{
		PurchaseError = error;
	}

	public InAppBillingPurchaseException(PurchaseError error)
		: base("Unable to process purchase.")
	{
		PurchaseError = error;
	}

	public InAppBillingPurchaseException(PurchaseError error, string message)
		: base(message)
	{
		PurchaseError = error;
	}
}
[Preserve(AllMembers = true)]
public class InAppBillingProductAppleExtras
{
	public string SubscriptionGroupId { get; set; }

	public SubscriptionPeriod SubscriptionPeriod { get; set; }

	public bool IsFamilyShareable { get; set; }

	public InAppBillingProductDiscount IntroductoryOffer { get; set; }

	public List<InAppBillingProductDiscount> Discounts { get; set; }
}
[Preserve(AllMembers = true)]
public class InAppBillingProductWindowsExtras
{
	public string FormattedBasePrice { get; set; }

	public Uri ImageUri { get; set; }

	public bool IsOnSale { get; set; }

	public DateTimeOffset SaleEndDate { get; set; }

	public string Tag { get; set; }

	public bool IsConsumable { get; set; }

	public bool IsDurable { get; set; }

	public IEnumerable<string> Keywords { get; set; }
}
[Preserve(AllMembers = true)]
public class InAppBillingProductAndroidExtras
{
	public string SubscriptionPeriod { get; set; }

	public string FreeTrialPeriod { get; set; }

	public string IconUrl { get; set; }

	public string LocalizedIntroductoryPrice { get; set; }

	public int IntroductoryPriceCycles { get; set; }

	public string IntroductoryPricePeriod { get; set; }

	public long MicrosIntroductoryPrice { get; set; }

	public string OriginalPrice { get; set; }

	public long MicrosOriginalPriceAmount { get; set; }
}
[Preserve(AllMembers = true)]
public class InAppBillingProduct
{
	public string Name { get; set; }

	public string Description { get; set; }

	public string ProductId { get; set; }

	public string LocalizedPrice { get; set; }

	public string CurrencyCode { get; set; }

	public long MicrosPrice { get; set; }

	public InAppBillingProductAppleExtras AppleExtras { get; set; }

	public InAppBillingProductAndroidExtras AndroidExtras { get; set; }

	public InAppBillingProductWindowsExtras WindowsExtras { get; set; }
}
[Preserve(AllMembers = true)]
public class InAppBillingProductDiscount
{
	public string Id { get; set; } = string.Empty;

	public ProductDiscountType Type { get; set; } = ProductDiscountType.Unknown;

	public double Price { get; set; }

	public string LocalizedPrice { get; set; } = string.Empty;

	public string CurrencyCode { get; set; } = string.Empty;

	public PaymentMode PaymentMode { get; set; } = PaymentMode.Unknown;

	public int NumberOfPeriods { get; set; }

	public SubscriptionPeriod SubscriptionPeriod { get; set; } = SubscriptionPeriod.Unknown;
}
public enum PaymentMode
{
	FreeTrial,
	PayUpFront,
	PayAsYouGo,
	Unknown
}
public enum SubscriptionPeriod
{
	Day,
	Month,
	Week,
	Year,
	Unknown
}
public enum ProductDiscountType
{
	Introductory,
	Subscription,
	Unknown
}
[Preserve(AllMembers = true)]
public class InAppBillingPurchaseComparer : IEqualityComparer<InAppBillingPurchase>
{
	public bool Equals(InAppBillingPurchase x, InAppBillingPurchase y)
	{
		return x.Equals(y);
	}

	public int GetHashCode(InAppBillingPurchase x)
	{
		return x.GetHashCode();
	}
}
[Preserve(AllMembers = true)]
public class InAppBillingPurchase : IEquatable<InAppBillingPurchase>
{
	public string Id { get; set; }

	public string TransactionIdentifier { get; set; }

	public DateTime TransactionDateUtc { get; set; }

	public string ProductId { get; set; }

	public int Quantity { get; set; } = 1;

	public IList<string> ProductIds { get; set; }

	public bool AutoRenewing { get; set; }

	public string PurchaseToken { get; set; }

	public PurchaseState State { get; set; }

	public ConsumptionState ConsumptionState { get; set; }

	public bool? IsAcknowledged { get; set; }

	public string ObfuscatedAccountId { get; set; }

	public string ObfuscatedProfileId { get; set; }

	public string ApplicationUsername { get; set; }

	public string Payload { get; set; }

	public string OriginalJson { get; set; }

	public string Signature { get; set; }

	public static bool operator ==(InAppBillingPurchase left, InAppBillingPurchase right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(InAppBillingPurchase left, InAppBillingPurchase right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (obj is InAppBillingPurchase other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(InAppBillingPurchase other)
	{
		string id = Id;
		DateTime transactionDateUtc = TransactionDateUtc;
		bool? isAcknowledged = IsAcknowledged;
		string productId = ProductId;
		bool autoRenewing = AutoRenewing;
		string purchaseToken = PurchaseToken;
		PurchaseState state = State;
		string payload = Payload;
		string obfuscatedAccountId = ObfuscatedAccountId;
		string obfuscatedProfileId = ObfuscatedProfileId;
		int quantity = Quantity;
		IList<string> productIds = ProductIds;
		string originalJson = OriginalJson;
		string signature = Signature;
		string id2 = other.Id;
		DateTime transactionDateUtc2 = other.TransactionDateUtc;
		bool? isAcknowledged2 = other.IsAcknowledged;
		string productId2 = other.ProductId;
		bool autoRenewing2 = other.AutoRenewing;
		string purchaseToken2 = other.PurchaseToken;
		PurchaseState state2 = other.State;
		string payload2 = other.Payload;
		string obfuscatedAccountId2 = other.ObfuscatedAccountId;
		string obfuscatedProfileId2 = other.ObfuscatedProfileId;
		int quantity2 = other.Quantity;
		IList<string> productIds2 = other.ProductIds;
		string originalJson2 = other.OriginalJson;
		string signature2 = other.Signature;
		if (id == id2 && transactionDateUtc == transactionDateUtc2 && isAcknowledged == isAcknowledged2 && productId == productId2 && autoRenewing == autoRenewing2 && purchaseToken == purchaseToken2 && state == state2 && payload == payload2 && obfuscatedAccountId == obfuscatedAccountId2 && obfuscatedProfileId == obfuscatedProfileId2 && quantity == quantity2 && productIds == productIds2 && originalJson == originalJson2)
		{
			return signature == signature2;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (Id, TransactionDateUtc, IsAcknowledged, ProductId, AutoRenewing, PurchaseToken, State, Payload, ObfuscatedAccountId, ObfuscatedProfileId, Quantity, ProductIds, OriginalJson, Signature).GetHashCode();
	}

	public override string ToString()
	{
		return string.Format("{0}:{1}| {2}:{3} | {4}:{5} | {6}:{7} | {8}:{9} | {10}:{11}  | {12}:{13}  | {14}:{15}  | {16}:{17}  | {18}:{19}", "ProductId", ProductId, "IsAcknowledged", IsAcknowledged, "AutoRenewing", AutoRenewing, "State", State, "Id", Id, "ObfuscatedAccountId", ObfuscatedAccountId, "ObfuscatedProfileId", ObfuscatedProfileId, "Signature", Signature, "OriginalJson", OriginalJson, "Quantity", Quantity);
	}
}
public enum ItemType
{
	InAppPurchase,
	InAppPurchaseConsumable,
	Subscription
}
public enum SubscriptionProrationMode
{
	ImmediateWithTimeProration = 1,
	ImmediateAndChargeProratedPrice,
	ImmediateWithoutProration,
	Deferred,
	ImmediateAndChargeFullPrice
}
public enum PurchaseState
{
	Purchased,
	Canceled,
	Purchasing,
	Failed,
	Restored,
	Deferred,
	PaymentPending,
	Unknown
}
public class Storefront
{
	public string Id { get; set; }

	public string CountryCode { get; set; }
}
internal static class Converters
{
	internal static InAppBillingPurchase ToIABPurchase(this Purchase purchase)
	{
		InAppBillingPurchase inAppBillingPurchase = new InAppBillingPurchase
		{
			AutoRenewing = purchase.IsAutoRenewing,
			ConsumptionState = ConsumptionState.NoYetConsumed,
			Id = purchase.OrderId,
			OriginalJson = purchase.OriginalJson,
			Signature = purchase.Signature,
			IsAcknowledged = purchase.IsAcknowledged,
			Payload = purchase.DeveloperPayload,
			ProductId = purchase.Skus.FirstOrDefault(),
			Quantity = purchase.Quantity,
			ProductIds = purchase.Skus,
			PurchaseToken = purchase.PurchaseToken,
			TransactionDateUtc = DateTimeOffset.FromUnixTimeMilliseconds(purchase.PurchaseTime).DateTime,
			ObfuscatedAccountId = purchase.AccountIdentifiers?.ObfuscatedAccountId,
			ObfuscatedProfileId = purchase.AccountIdentifiers?.ObfuscatedProfileId,
			TransactionIdentifier = purchase.PurchaseToken
		};
		InAppBillingPurchase inAppBillingPurchase2 = inAppBillingPurchase;
		inAppBillingPurchase2.State = purchase.PurchaseState switch
		{
			Android.BillingClient.Api.PurchaseState.Pending => PurchaseState.PaymentPending, 
			Android.BillingClient.Api.PurchaseState.Purchased => PurchaseState.Purchased, 
			_ => PurchaseState.Unknown, 
		};
		return inAppBillingPurchase;
	}

	internal static InAppBillingPurchase ToIABPurchase(this PurchaseHistoryRecord purchase)
	{
		return new InAppBillingPurchase
		{
			ConsumptionState = ConsumptionState.NoYetConsumed,
			OriginalJson = purchase.OriginalJson,
			Signature = purchase.Signature,
			Payload = purchase.DeveloperPayload,
			ProductId = purchase.Skus.FirstOrDefault(),
			Quantity = purchase.Quantity,
			ProductIds = purchase.Skus,
			PurchaseToken = purchase.PurchaseToken,
			TransactionDateUtc = DateTimeOffset.FromUnixTimeMilliseconds(purchase.PurchaseTime).DateTime,
			State = PurchaseState.Unknown,
			TransactionIdentifier = purchase.PurchaseToken
		};
	}

	internal static InAppBillingProduct ToIAPProduct(this SkuDetails product)
	{
		return new InAppBillingProduct
		{
			Name = product.Title,
			Description = product.Description,
			CurrencyCode = product.PriceCurrencyCode,
			LocalizedPrice = product.Price,
			ProductId = product.Sku,
			MicrosPrice = product.PriceAmountMicros,
			AndroidExtras = new InAppBillingProductAndroidExtras
			{
				SubscriptionPeriod = product.SubscriptionPeriod,
				LocalizedIntroductoryPrice = product.IntroductoryPrice,
				MicrosIntroductoryPrice = product.IntroductoryPriceAmountMicros,
				FreeTrialPeriod = product.FreeTrialPeriod,
				IconUrl = product.IconUrl,
				IntroductoryPriceCycles = product.IntroductoryPriceCycles,
				IntroductoryPricePeriod = product.IntroductoryPricePeriod,
				MicrosOriginalPriceAmount = product.OriginalPriceAmountMicros,
				OriginalPrice = product.OriginalPrice
			}
		};
	}
}
[Preserve(AllMembers = true)]
public class InAppBillingImplementation : BaseInAppBilling
{
	private TaskCompletionSource<(BillingResult billingResult, IList<Purchase> purchases)> tcsPurchase;

	private TaskCompletionSource<bool> tcsConnect;

	public static Action<BillingResult, List<InAppBillingPurchase>> OnAndroidPurchasesUpdated { get; set; }

	private Activity Activity => Platform.CurrentActivity ?? throw new NullReferenceException("Current Activity is null, ensure that the MainActivity.cs file is configuring Xamarin.Essentials in your source code so the In App Billing can use it.");

	private Context Context => Application.Context;

	private BillingClient BillingClient { get; set; }

	private BillingClient.Builder BillingClientBuilder { get; set; }

	public override bool IsConnected { get; set; }

	public override bool InTestingMode { get; set; }

	public override Task<bool> ConnectAsync(bool enablePendingPurchases = true)
	{
		tcsPurchase?.TrySetCanceled();
		tcsPurchase = null;
		tcsConnect?.TrySetCanceled();
		tcsConnect = new TaskCompletionSource<bool>();
		BillingClientBuilder = BillingClient.NewBuilder(Context);
		BillingClientBuilder.SetListener(OnPurchasesUpdated);
		if (enablePendingPurchases)
		{
			BillingClient = BillingClientBuilder.EnablePendingPurchases().Build();
		}
		else
		{
			BillingClient = BillingClientBuilder.Build();
		}
		BillingClient.StartConnection(OnSetupFinished, OnDisconnected);
		return tcsConnect.Task;
		void OnDisconnected()
		{
			IsConnected = false;
		}
		void OnSetupFinished(BillingResult billingResult)
		{
			Console.WriteLine($"Billing Setup Finished : {billingResult.ResponseCode} - {billingResult.DebugMessage}");
			IsConnected = billingResult.ResponseCode == BillingResponseCode.Ok;
			tcsConnect?.TrySetResult(IsConnected);
		}
	}

	public void OnPurchasesUpdated(BillingResult billingResult, IList<Purchase> purchases)
	{
		tcsPurchase?.TrySetResult((billingResult, purchases));
		if (OnAndroidPurchasesUpdated != null)
		{
			OnAndroidPurchasesUpdated?.Invoke(billingResult, purchases?.Select((Purchase p) => p.ToIABPurchase())?.ToList());
		}
	}

	public override Task DisconnectAsync()
	{
		try
		{
			BillingClientBuilder?.Dispose();
			BillingClientBuilder = null;
			BillingClient?.EndConnection();
			BillingClient?.Dispose();
			BillingClient = null;
			IsConnected = false;
		}
		catch (Exception)
		{
		}
		return Task.CompletedTask;
	}

	public override async Task<IEnumerable<InAppBillingProduct>> GetProductInfoAsync(ItemType itemType, params string[] productIds)
	{
		if (BillingClient == null || !IsConnected)
		{
			throw new InAppBillingPurchaseException(PurchaseError.ServiceUnavailable, "You are not connected to the Google Play App store.");
		}
		string text = itemType switch
		{
			ItemType.InAppPurchase => "inapp", 
			ItemType.InAppPurchaseConsumable => "inapp", 
			_ => "subs", 
		};
		if (text == "subs")
		{
			BillingResult result = BillingClient.IsFeatureSupported("subscriptions");
			ParseBillingResult(result);
		}
		SkuDetailsParams skuDetailsParams = SkuDetailsParams.NewBuilder().SetType(text).SetSkusList(productIds)
			.Build();
		QuerySkuDetailsResult querySkuDetailsResult = await BillingClient.QuerySkuDetailsAsync(skuDetailsParams);
		ParseBillingResult(querySkuDetailsResult?.Result);
		return querySkuDetailsResult.SkuDetails.Select((SkuDetails product) => product.ToIAPProduct());
	}

	public override Task<IEnumerable<InAppBillingPurchase>> GetPurchasesAsync(ItemType itemType)
	{
		if (BillingClient == null)
		{
			throw new InAppBillingPurchaseException(PurchaseError.ServiceUnavailable, "You are not connected to the Google Play App store.");
		}
		Purchase.PurchasesResult purchasesResult = BillingClient.QueryPurchases(itemType switch
		{
			ItemType.InAppPurchase => "inapp", 
			ItemType.InAppPurchaseConsumable => "inapp", 
			_ => "subs", 
		});
		ParseBillingResult(purchasesResult.BillingResult);
		return Task.FromResult(purchasesResult.PurchasesList.Select((Purchase p) => p.ToIABPurchase()));
	}

	public override async Task<IEnumerable<InAppBillingPurchase>> GetPurchasesHistoryAsync(ItemType itemType)
	{
		if (BillingClient == null)
		{
			throw new InAppBillingPurchaseException(PurchaseError.ServiceUnavailable, "You are not connected to the Google Play App store.");
		}
		return (await BillingClient.QueryPurchaseHistoryAsync(itemType switch
		{
			ItemType.InAppPurchase => "inapp", 
			ItemType.InAppPurchaseConsumable => "inapp", 
			_ => "subs", 
		}))?.PurchaseHistoryRecords?.Select((PurchaseHistoryRecord p) => p.ToIABPurchase()) ?? new List<InAppBillingPurchase>();
	}

	public override async Task<InAppBillingPurchase> UpgradePurchasedSubscriptionAsync(string newProductId, string purchaseTokenOfOriginalSubscription, SubscriptionProrationMode prorationMode = SubscriptionProrationMode.ImmediateWithTimeProration)
	{
		if (BillingClient == null || !IsConnected)
		{
			throw new InAppBillingPurchaseException(PurchaseError.ServiceUnavailable, "You are not connected to the Google Play App store.");
		}
		if (tcsPurchase?.Task != null && !tcsPurchase.Task.IsCompleted)
		{
			return null;
		}
		return await UpgradePurchasedSubscriptionInternalAsync(newProductId, purchaseTokenOfOriginalSubscription, prorationMode);
	}

	private async Task<InAppBillingPurchase> UpgradePurchasedSubscriptionInternalAsync(string newProductId, string purchaseTokenOfOriginalSubscription, SubscriptionProrationMode prorationMode)
	{
		string itemType = "subs";
		if (tcsPurchase?.Task != null && !tcsPurchase.Task.IsCompleted)
		{
			return null;
		}
		SkuDetailsParams skuDetailsParams = SkuDetailsParams.NewBuilder().SetType(itemType).SetSkusList(new List<string> { newProductId })
			.Build();
		QuerySkuDetailsResult querySkuDetailsResult = await BillingClient.QuerySkuDetailsAsync(skuDetailsParams);
		ParseBillingResult(querySkuDetailsResult?.Result);
		SkuDetails skuDetails = querySkuDetailsResult?.SkuDetails.FirstOrDefault();
		if (skuDetails == null)
		{
			throw new ArgumentException(newProductId + " does not exist");
		}
		BillingFlowParams.SubscriptionUpdateParams subscriptionUpdateParams = BillingFlowParams.SubscriptionUpdateParams.NewBuilder().SetOldSkuPurchaseToken(purchaseTokenOfOriginalSubscription).SetReplaceSkusProrationMode((int)prorationMode)
			.Build();
		BillingFlowParams p = BillingFlowParams.NewBuilder().SetSkuDetails(skuDetails).SetSubscriptionUpdateParams(subscriptionUpdateParams)
			.Build();
		tcsPurchase = new TaskCompletionSource<(BillingResult, IList<Purchase>)>();
		BillingResult result = BillingClient.LaunchBillingFlow(Activity, p);
		ParseBillingResult(result);
		(BillingResult, IList<Purchase>) tuple = await tcsPurchase.Task;
		ParseBillingResult(tuple.Item1);
		Purchase purchase = tuple.Item2?.FirstOrDefault((Purchase purchase2) => purchase2.Skus.Contains(newProductId));
		if (purchase == null)
		{
			return (await GetPurchasesAsync((!(itemType == "inapp")) ? ItemType.Subscription : ItemType.InAppPurchase)).FirstOrDefault((InAppBillingPurchase inAppBillingPurchase) => inAppBillingPurchase.ProductId == newProductId);
		}
		return purchase.ToIABPurchase();
	}

	public override async Task<InAppBillingPurchase> PurchaseAsync(string productId, ItemType itemType, string obfuscatedAccountId = null, string obfuscatedProfileId = null)
	{
		if (BillingClient == null || !IsConnected)
		{
			throw new InAppBillingPurchaseException(PurchaseError.ServiceUnavailable, "You are not connected to the Google Play App store.");
		}
		if (tcsPurchase?.Task != null && !tcsPurchase.Task.IsCompleted)
		{
			return null;
		}
		switch (itemType)
		{
		case ItemType.InAppPurchase:
		case ItemType.InAppPurchaseConsumable:
			return await PurchaseAsync(productId, "inapp", obfuscatedAccountId, obfuscatedProfileId);
		case ItemType.Subscription:
		{
			BillingResult result = BillingClient.IsFeatureSupported("subscriptions");
			ParseBillingResult(result);
			return await PurchaseAsync(productId, "subs", obfuscatedAccountId, obfuscatedProfileId);
		}
		default:
			return null;
		}
	}

	private async Task<InAppBillingPurchase> PurchaseAsync(string productSku, string itemType, string obfuscatedAccountId = null, string obfuscatedProfileId = null)
	{
		SkuDetailsParams skuDetailsParams = SkuDetailsParams.NewBuilder().SetType(itemType).SetSkusList(new List<string> { productSku })
			.Build();
		QuerySkuDetailsResult querySkuDetailsResult = await BillingClient.QuerySkuDetailsAsync(skuDetailsParams);
		ParseBillingResult(querySkuDetailsResult?.Result);
		SkuDetails skuDetails = querySkuDetailsResult.SkuDetails.FirstOrDefault();
		if (skuDetails == null)
		{
			throw new ArgumentException(productSku + " does not exist");
		}
		BillingFlowParams.Builder builder = BillingFlowParams.NewBuilder().SetSkuDetails(skuDetails);
		if (!string.IsNullOrWhiteSpace(obfuscatedAccountId))
		{
			builder.SetObfuscatedAccountId(obfuscatedAccountId);
		}
		if (!string.IsNullOrWhiteSpace(obfuscatedProfileId))
		{
			builder.SetObfuscatedProfileId(obfuscatedProfileId);
		}
		BillingFlowParams p = builder.Build();
		tcsPurchase = new TaskCompletionSource<(BillingResult, IList<Purchase>)>();
		BillingResult result = BillingClient.LaunchBillingFlow(Activity, p);
		ParseBillingResult(result);
		(BillingResult, IList<Purchase>) tuple = await tcsPurchase.Task;
		ParseBillingResult(tuple.Item1);
		Purchase purchase = tuple.Item2?.FirstOrDefault((Purchase purchase2) => purchase2.Skus.Contains(productSku));
		if (purchase == null)
		{
			return (await GetPurchasesAsync((!(itemType == "inapp")) ? ItemType.Subscription : ItemType.InAppPurchase)).FirstOrDefault((InAppBillingPurchase inAppBillingPurchase) => inAppBillingPurchase.ProductId == productSku);
		}
		return purchase.ToIABPurchase();
	}

	public override async Task<IEnumerable<(string Id, bool Success)>> FinalizePurchaseAsync(params string[] transactionIdentifier)
	{
		if (BillingClient == null || !IsConnected)
		{
			throw new InAppBillingPurchaseException(PurchaseError.ServiceUnavailable, "You are not connected to the Google Play App store.");
		}
		List<(string Id, bool Success)> items = new List<(string, bool)>();
		foreach (string t in transactionIdentifier)
		{
			AcknowledgePurchaseParams acknowledgePurchaseParams = AcknowledgePurchaseParams.NewBuilder().SetPurchaseToken(t).Build();
			items.Add((t, ParseBillingResult(await BillingClient.AcknowledgePurchaseAsync(acknowledgePurchaseParams))));
		}
		return items;
	}

	public override async Task<bool> ConsumePurchaseAsync(string productId, string transactionIdentifier)
	{
		if (BillingClient == null || !IsConnected)
		{
			throw new InAppBillingPurchaseException(PurchaseError.ServiceUnavailable, "You are not connected to the Google Play App store.");
		}
		ConsumeParams consumeParams = ConsumeParams.NewBuilder().SetPurchaseToken(transactionIdentifier).Build();
		return ParseBillingResult((await BillingClient.ConsumeAsync(consumeParams)).BillingResult);
	}

	private bool ParseBillingResult(BillingResult result)
	{
		if (result == null)
		{
			throw new InAppBillingPurchaseException(PurchaseError.GeneralError);
		}
		return result.ResponseCode switch
		{
			BillingResponseCode.Ok => true, 
			BillingResponseCode.UserCancelled => throw new InAppBillingPurchaseException(PurchaseError.UserCancelled), 
			BillingResponseCode.ServiceUnavailable => throw new InAppBillingPurchaseException(PurchaseError.ServiceUnavailable), 
			BillingResponseCode.ServiceDisconnected => throw new InAppBillingPurchaseException(PurchaseError.ServiceDisconnected), 
			BillingResponseCode.ServiceTimeout => throw new InAppBillingPurchaseException(PurchaseError.ServiceTimeout), 
			BillingResponseCode.BillingUnavailable => throw new InAppBillingPurchaseException(PurchaseError.BillingUnavailable), 
			BillingResponseCode.ItemNotOwned => throw new InAppBillingPurchaseException(PurchaseError.NotOwned), 
			BillingResponseCode.DeveloperError => throw new InAppBillingPurchaseException(PurchaseError.DeveloperError), 
			BillingResponseCode.Error => throw new InAppBillingPurchaseException(PurchaseError.GeneralError), 
			BillingResponseCode.FeatureNotSupported => throw new InAppBillingPurchaseException(PurchaseError.FeatureNotSupported), 
			BillingResponseCode.ItemAlreadyOwned => throw new InAppBillingPurchaseException(PurchaseError.AlreadyOwned), 
			BillingResponseCode.ItemUnavailable => throw new InAppBillingPurchaseException(PurchaseError.ItemUnavailable), 
			_ => false, 
		};
	}
}
[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
public class Resource
{
	public class Attribute
	{
		public static int alpha;

		public static int font;

		public static int fontProviderAuthority;

		public static int fontProviderCerts;

		public static int fontProviderFetchStrategy;

		public static int fontProviderFetchTimeout;

		public static int fontProviderPackage;

		public static int fontProviderQuery;

		public static int fontStyle;

		public static int fontVariationSettings;

		public static int fontWeight;

		public static int ttcIndex;

		static Attribute()
		{
			alpha = 2130771968;
			font = 2130771969;
			fontProviderAuthority = 2130771970;
			fontProviderCerts = 2130771971;
			fontProviderFetchStrategy = 2130771972;
			fontProviderFetchTimeout = 2130771973;
			fontProviderPackage = 2130771974;
			fontProviderQuery = 2130771975;
			fontStyle = 2130771976;
			fontVariationSettings = 2130771977;
			fontWeight = 2130771978;
			ttcIndex = 2130771979;
			ResourceIdManager.UpdateIdValues();
		}

		private Attribute()
		{
		}
	}

	public class Color
	{
		public static int androidx_core_ripple_material_light;

		public static int androidx_core_secondary_text_default_material_light;

		public static int browser_actions_bg_grey;

		public static int browser_actions_divider_color;

		public static int browser_actions_text_color;

		public static int browser_actions_title_color;

		public static int notification_action_color_filter;

		public static int notification_icon_bg_color;

		static Color()
		{
			androidx_core_ripple_material_light = 2130837504;
			androidx_core_secondary_text_default_material_light = 2130837505;
			browser_actions_bg_grey = 2130837506;
			browser_actions_divider_color = 2130837507;
			browser_actions_text_color = 2130837508;
			browser_actions_title_color = 2130837509;
			notification_action_color_filter = 2130837510;
			notification_icon_bg_color = 2130837511;
			ResourceIdManager.UpdateIdValues();
		}

		private Color()
		{
		}
	}

	public class Dimension
	{
		public static int browser_actions_context_menu_max_width;

		public static int browser_actions_context_menu_min_padding;

		public static int compat_button_inset_horizontal_material;

		public static int compat_button_inset_vertical_material;

		public static int compat_button_padding_horizontal_material;

		public static int compat_button_padding_vertical_material;

		public static int compat_control_corner_material;

		public static int compat_notification_large_icon_max_height;

		public static int compat_notification_large_icon_max_width;

		public static int notification_action_icon_size;

		public static int notification_action_text_size;

		public static int notification_big_circle_margin;

		public static int notification_content_margin_start;

		public static int notification_large_icon_height;

		public static int notification_large_icon_width;

		public static int notification_main_column_padding_top;

		public static int notification_media_narrow_margin;

		public static int notification_right_icon_size;

		public static int notification_right_side_padding_top;

		public static int notification_small_icon_background_padding;

		public static int notification_small_icon_size_as_large;

		public static int notification_subtext_size;

		public static int notification_top_pad;

		public static int notification_top_pad_large_text;

		static Dimension()
		{
			browser_actions_context_menu_max_width = 2130903040;
			browser_actions_context_menu_min_padding = 2130903041;
			compat_button_inset_horizontal_material = 2130903042;
			compat_button_inset_vertical_material = 2130903043;
			compat_button_padding_horizontal_material = 2130903044;
			compat_button_padding_vertical_material = 2130903045;
			compat_control_corner_material = 2130903046;
			compat_notification_large_icon_max_height = 2130903047;
			compat_notification_large_icon_max_width = 2130903048;
			notification_action_icon_size = 2130903049;
			notification_action_text_size = 2130903050;
			notification_big_circle_margin = 2130903051;
			notification_content_margin_start = 2130903052;
			notification_large_icon_height = 2130903053;
			notification_large_icon_width = 2130903054;
			notification_main_column_padding_top = 2130903055;
			notification_media_narrow_margin = 2130903056;
			notification_right_icon_size = 2130903057;
			notification_right_side_padding_top = 2130903058;
			notification_small_icon_background_padding = 2130903059;
			notification_small_icon_size_as_large = 2130903060;
			notification_subtext_size = 2130903061;
			notification_top_pad = 2130903062;
			notification_top_pad_large_text = 2130903063;
			ResourceIdManager.UpdateIdValues();
		}

		private Dimension()
		{
		}
	}

	public class Drawable
	{
		public static int notification_action_background;

		public static int notification_bg;

		public static int notification_bg_low;

		public static int notification_bg_low_normal;

		public static int notification_bg_low_pressed;

		public static int notification_bg_normal;

		public static int notification_bg_normal_pressed;

		public static int notification_icon_background;

		public static int notification_template_icon_bg;

		public static int notification_template_icon_low_bg;

		public static int notification_tile_bg;

		public static int notify_panel_notification_icon_bg;

		static Drawable()
		{
			notification_action_background = 2130968576;
			notification_bg = 2130968577;
			notification_bg_low = 2130968578;
			notification_bg_low_normal = 2130968579;
			notification_bg_low_pressed = 2130968580;
			notification_bg_normal = 2130968581;
			notification_bg_normal_pressed = 2130968582;
			notification_icon_background = 2130968583;
			notification_template_icon_bg = 2130968584;
			notification_template_icon_low_bg = 2130968585;
			notification_tile_bg = 2130968586;
			notify_panel_notification_icon_bg = 2130968587;
			ResourceIdManager.UpdateIdValues();
		}

		private Drawable()
		{
		}
	}

	public class Id
	{
		public static int accessibility_action_clickable_span;

		public static int accessibility_custom_action_0;

		public static int accessibility_custom_action_1;

		public static int accessibility_custom_action_10;

		public static int accessibility_custom_action_11;

		public static int accessibility_custom_action_12;

		public static int accessibility_custom_action_13;

		public static int accessibility_custom_action_14;

		public static int accessibility_custom_action_15;

		public static int accessibility_custom_action_16;

		public static int accessibility_custom_action_17;

		public static int accessibility_custom_action_18;

		public static int accessibility_custom_action_19;

		public static int accessibility_custom_action_2;

		public static int accessibility_custom_action_20;

		public static int accessibility_custom_action_21;

		public static int accessibility_custom_action_22;

		public static int accessibility_custom_action_23;

		public static int accessibility_custom_action_24;

		public static int accessibility_custom_action_25;

		public static int accessibility_custom_action_26;

		public static int accessibility_custom_action_27;

		public static int accessibility_custom_action_28;

		public static int accessibility_custom_action_29;

		public static int accessibility_custom_action_3;

		public static int accessibility_custom_action_30;

		public static int accessibility_custom_action_31;

		public static int accessibility_custom_action_4;

		public static int accessibility_custom_action_5;

		public static int accessibility_custom_action_6;

		public static int accessibility_custom_action_7;

		public static int accessibility_custom_action_8;

		public static int accessibility_custom_action_9;

		public static int actions;

		public static int action_container;

		public static int action_divider;

		public static int action_image;

		public static int action_text;

		public static int async;

		public static int blocking;

		public static int browser_actions_header_text;

		public static int browser_actions_menu_items;

		public static int browser_actions_menu_item_icon;

		public static int browser_actions_menu_item_text;

		public static int browser_actions_menu_view;

		public static int chronometer;

		public static int dialog_button;

		public static int forever;

		public static int icon;

		public static int icon_group;

		public static int info;

		public static int italic;

		public static int line1;

		public static int line3;

		public static int normal;

		public static int notification_background;

		public static int notification_main_column;

		public static int notification_main_column_container;

		public static int right_icon;

		public static int right_side;

		public static int tag_accessibility_actions;

		public static int tag_accessibility_clickable_spans;

		public static int tag_accessibility_heading;

		public static int tag_accessibility_pane_title;

		public static int tag_screen_reader_focusable;

		public static int tag_transition_group;

		public static int tag_unhandled_key_event_manager;

		public static int tag_unhandled_key_listeners;

		public static int text;

		public static int text2;

		public static int time;

		public static int title;

		static Id()
		{
			accessibility_action_clickable_span = 2131034112;
			accessibility_custom_action_0 = 2131034113;
			accessibility_custom_action_1 = 2131034114;
			accessibility_custom_action_10 = 2131034115;
			accessibility_custom_action_11 = 2131034116;
			accessibility_custom_action_12 = 2131034117;
			accessibility_custom_action_13 = 2131034118;
			accessibility_custom_action_14 = 2131034119;
			accessibility_custom_action_15 = 2131034120;
			accessibility_custom_action_16 = 2131034121;
			accessibility_custom_action_17 = 2131034122;
			accessibility_custom_action_18 = 2131034123;
			accessibility_custom_action_19 = 2131034124;
			accessibility_custom_action_2 = 2131034125;
			accessibility_custom_action_20 = 2131034126;
			accessibility_custom_action_21 = 2131034127;
			accessibility_custom_action_22 = 2131034128;
			accessibility_custom_action_23 = 2131034129;
			accessibility_custom_action_24 = 2131034130;
			accessibility_custom_action_25 = 2131034131;
			accessibility_custom_action_26 = 2131034132;
			accessibility_custom_action_27 = 2131034133;
			accessibility_custom_action_28 = 2131034134;
			accessibility_custom_action_29 = 2131034135;
			accessibility_custom_action_3 = 2131034136;
			accessibility_custom_action_30 = 2131034137;
			accessibility_custom_action_31 = 2131034138;
			accessibility_custom_action_4 = 2131034139;
			accessibility_custom_action_5 = 2131034140;
			accessibility_custom_action_6 = 2131034141;
			accessibility_custom_action_7 = 2131034142;
			accessibility_custom_action_8 = 2131034143;
			accessibility_custom_action_9 = 2131034144;
			actions = 2131034149;
			action_container = 2131034145;
			action_divider = 2131034146;
			action_image = 2131034147;
			action_text = 2131034148;
			async = 2131034150;
			blocking = 2131034151;
			browser_actions_header_text = 2131034152;
			browser_actions_menu_items = 2131034155;
			browser_actions_menu_item_icon = 2131034153;
			browser_actions_menu_item_text = 2131034154;
			browser_actions_menu_view = 2131034156;
			chronometer = 2131034157;
			dialog_button = 2131034158;
			forever = 2131034159;
			icon = 2131034160;
			icon_group = 2131034161;
			info = 2131034162;
			italic = 2131034163;
			line1 = 2131034164;
			line3 = 2131034165;
			normal = 2131034166;
			notification_background = 2131034167;
			notification_main_column = 2131034168;
			notification_main_column_container = 2131034169;
			right_icon = 2131034170;
			right_side = 2131034171;
			tag_accessibility_actions = 2131034172;
			tag_accessibility_clickable_spans = 2131034173;
			tag_accessibility_heading = 2131034174;
			tag_accessibility_pane_title = 2131034175;
			tag_screen_reader_focusable = 2131034176;
			tag_transition_group = 2131034177;
			tag_unhandled_key_event_manager = 2131034178;
			tag_unhandled_key_listeners = 2131034179;
			text = 2131034180;
			text2 = 2131034181;
			time = 2131034182;
			title = 2131034183;
			ResourceIdManager.UpdateIdValues();
		}

		private Id()
		{
		}
	}

	public class Integer
	{
		public static int status_bar_notification_info_maxnum;

		static Integer()
		{
			status_bar_notification_info_maxnum = 2131099648;
			ResourceIdManager.UpdateIdValues();
		}

		private Integer()
		{
		}
	}

	public class Layout
	{
		public static int browser_actions_context_menu_page;

		public static int browser_actions_context_menu_row;

		public static int custom_dialog;

		public static int notification_action;

		public static int notification_action_tombstone;

		public static int notification_template_custom_big;

		public static int notification_template_icon_group;

		public static int notification_template_part_chronometer;

		public static int notification_template_part_time;

		static Layout()
		{
			browser_actions_context_menu_page = 2131165184;
			browser_actions_context_menu_row = 2131165185;
			custom_dialog = 2131165186;
			notification_action = 2131165187;
			notification_action_tombstone = 2131165188;
			notification_template_custom_big = 2131165189;
			notification_template_icon_group = 2131165190;
			notification_template_part_chronometer = 2131165191;
			notification_template_part_time = 2131165192;
			ResourceIdManager.UpdateIdValues();
		}

		private Layout()
		{
		}
	}

	public class String
	{
		public static int copy_toast_msg;

		public static int fallback_menu_item_copy_link;

		public static int fallback_menu_item_open_in_browser;

		public static int fallback_menu_item_share_link;

		public static int status_bar_notification_info_overflow;

		static String()
		{
			copy_toast_msg = 2131230720;
			fallback_menu_item_copy_link = 2131230721;
			fallback_menu_item_open_in_browser = 2131230722;
			fallback_menu_item_share_link = 2131230723;
			status_bar_notification_info_overflow = 2131230724;
			ResourceIdManager.UpdateIdValues();
		}

		private String()
		{
		}
	}

	public class Style
	{
		public static int TextAppearance_Compat_Notification;

		public static int TextAppearance_Compat_Notification_Info;

		public static int TextAppearance_Compat_Notification_Line2;

		public static int TextAppearance_Compat_Notification_Time;

		public static int TextAppearance_Compat_Notification_Title;

		public static int Widget_Compat_NotificationActionContainer;

		public static int Widget_Compat_NotificationActionText;

		static Style()
		{
			TextAppearance_Compat_Notification = 2131296256;
			TextAppearance_Compat_Notification_Info = 2131296257;
			TextAppearance_Compat_Notification_Line2 = 2131296258;
			TextAppearance_Compat_Notification_Time = 2131296259;
			TextAppearance_Compat_Notification_Title = 2131296260;
			Widget_Compat_NotificationActionContainer = 2131296261;
			Widget_Compat_NotificationActionText = 2131296262;
			ResourceIdManager.UpdateIdValues();
		}

		private Style()
		{
		}
	}

	public class Styleable
	{
		public static int[] ColorStateListItem;

		public static int ColorStateListItem_alpha;

		public static int ColorStateListItem_android_alpha;

		public static int ColorStateListItem_android_color;

		public static int[] FontFamily;

		public static int[] FontFamilyFont;

		public static int FontFamilyFont_android_font;

		public static int FontFamilyFont_android_fontStyle;

		public static int FontFamilyFont_android_fontVariationSettings;

		public static int FontFamilyFont_android_fontWeight;

		public static int FontFamilyFont_android_ttcIndex;

		public static int FontFamilyFont_font;

		public static int FontFamilyFont_fontStyle;

		public static int FontFamilyFont_fontVariationSettings;

		public static int FontFamilyFont_fontWeight;

		public static int FontFamilyFont_ttcIndex;

		public static int FontFamily_fontProviderAuthority;

		public static int FontFamily_fontProviderCerts;

		public static int FontFamily_fontProviderFetchStrategy;

		public static int FontFamily_fontProviderFetchTimeout;

		public static int FontFamily_fontProviderPackage;

		public static int FontFamily_fontProviderQuery;

		public static int[] GradientColor;

		public static int[] GradientColorItem;

		public static int GradientColorItem_android_color;

		public static int GradientColorItem_android_offset;

		public static int GradientColor_android_centerColor;

		public static int GradientColor_android_centerX;

		public static int GradientColor_android_centerY;

		public static int GradientColor_android_endColor;

		public static int GradientColor_android_endX;

		public static int GradientColor_android_endY;

		public static int GradientColor_android_gradientRadius;

		public static int GradientColor_android_startColor;

		public static int GradientColor_android_startX;

		public static int GradientColor_android_startY;

		public static int GradientColor_android_tileMode;

		public static int GradientColor_android_type;

		static Styleable()
		{
			ColorStateListItem = new int[3] { 16843173, 16843551, 2130771968 };
			ColorStateListItem_alpha = 2;
			ColorStateListItem_android_alpha = 1;
			ColorStateListItem_android_color = 0;
			FontFamily = new int[6] { 2130771970, 2130771971, 2130771972, 2130771973, 2130771974, 2130771975 };
			FontFamilyFont = new int[10] { 16844082, 16844083, 16844095, 16844143, 16844144, 2130771969, 2130771976, 2130771977, 2130771978, 2130771979 };
			FontFamilyFont_android_font = 0;
			FontFamilyFont_android_fontStyle = 2;
			FontFamilyFont_android_fontVariationSettings = 4;
			FontFamilyFont_android_fontWeight = 1;
			FontFamilyFont_android_ttcIndex = 3;
			FontFamilyFont_font = 5;
			FontFamilyFont_fontStyle = 6;
			FontFamilyFont_fontVariationSettings = 7;
			FontFamilyFont_fontWeight = 8;
			FontFamilyFont_ttcIndex = 9;
			FontFamily_fontProviderAuthority = 0;
			FontFamily_fontProviderCerts = 1;
			FontFamily_fontProviderFetchStrategy = 2;
			FontFamily_fontProviderFetchTimeout = 3;
			FontFamily_fontProviderPackage = 4;
			FontFamily_fontProviderQuery = 5;
			GradientColor = new int[12]
			{
				16843165, 16843166, 16843169, 16843170, 16843171, 16843172, 16843265, 16843275, 16844048, 16844049,
				16844050, 16844051
			};
			GradientColorItem = new int[2] { 16843173, 16844052 };
			GradientColorItem_android_color = 0;
			GradientColorItem_android_offset = 1;
			GradientColor_android_centerColor = 7;
			GradientColor_android_centerX = 3;
			GradientColor_android_centerY = 4;
			GradientColor_android_endColor = 1;
			GradientColor_android_endX = 10;
			GradientColor_android_endY = 11;
			GradientColor_android_gradientRadius = 5;
			GradientColor_android_startColor = 0;
			GradientColor_android_startX = 8;
			GradientColor_android_startY = 9;
			GradientColor_android_tileMode = 6;
			GradientColor_android_type = 2;
			ResourceIdManager.UpdateIdValues();
		}

		private Styleable()
		{
		}
	}

	public class Xml
	{
		public static int image_share_filepaths;

		public static int xamarin_essentials_fileprovider_file_paths;

		static Xml()
		{
			image_share_filepaths = 2131427328;
			xamarin_essentials_fileprovider_file_paths = 2131427329;
			ResourceIdManager.UpdateIdValues();
		}

		private Xml()
		{
		}
	}

	static Resource()
	{
		ResourceIdManager.UpdateIdValues();
	}
}
