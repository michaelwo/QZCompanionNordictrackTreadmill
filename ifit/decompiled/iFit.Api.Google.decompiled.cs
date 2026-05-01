using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akavache;
using GeoCoordinatePortable;
using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Plugin.Connectivity.Abstractions;
using Refit;
using iFit.Api.Google.RefitInternalGenerated;
using iFit.Api.Support;
using iFit.Collections;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("Google APIs for Directions, StreetViews, etc")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Api.Google")]
[assembly: AssemblyTitle("iFit.Api.Google")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Api.Google
{
	public class AuthenticatedHttpClientHandler : NativeMessageHandler
	{
		private readonly IConnectivity connectivity;

		private readonly string clientId;

		private readonly string apiKey;

		public AuthenticatedHttpClientHandler(string clientId, string apiKey, IConnectivity connectivity)
		{
			this.clientId = clientId;
			this.apiKey = apiKey;
			this.connectivity = connectivity;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (!connectivity.IsConnected)
			{
				throw new ConnectivityException("no internet connection");
			}
			AuthenticationHeaderValue authorization = request.Headers.Authorization;
			if (authorization != null && authorization.Scheme == "Signed")
			{
				string uriString = SignUrl(request.RequestUri.AbsoluteUri, clientId, apiKey);
				request.RequestUri = new Uri(uriString);
			}
			return await ((HttpClientHandler)this).SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public static string SignUrl(string url, string clientId, string keyString)
		{
			url = url + "&client=" + clientId;
			UTF8Encoding uTF8Encoding = new UTF8Encoding();
			byte[] key = Convert.FromBase64String(keyString.Replace("-", "+").Replace("_", "/"));
			Uri uri = new Uri(url);
			byte[] bytes = uTF8Encoding.GetBytes(uri.LocalPath + uri.Query);
			HMac hMac = new HMac(new Sha1Digest());
			hMac.Init(new KeyParameter(key));
			hMac.BlockUpdate(bytes, 0, bytes.Length);
			byte[] array = new byte[hMac.GetMacSize()];
			hMac.DoFinal(array, 0);
			string text = Convert.ToBase64String(array).Replace("+", "-").Replace("/", "_");
			return uri.Scheme + "://" + uri.Host + uri.LocalPath + uri.Query + "&signature=" + text;
		}
	}
	public class BaseGoogleDataObject
	{
		public enum ResponseStatusType
		{
			[EnumMember(Value = "ok")]
			Ok,
			[EnumMember(Value = "zero_results")]
			ZeroResults,
			[EnumMember(Value = "over_query_limit")]
			OverQueryLimit,
			[EnumMember(Value = "request_denied")]
			RequestDenied,
			[EnumMember(Value = "invalid_request")]
			InvalidRequest,
			[EnumMember(Value = "unknown_error")]
			UnknownError
		}
	}
	public class Directions : BaseGoogleDataObject
	{
		public enum ModeType
		{
			Driving,
			Walking,
			Bicycling,
			Transit
		}

		public class Route
		{
			public List<Leg> Legs { get; set; }

			public string Summary { get; set; }
		}

		public class Leg
		{
			public List<DirectionsResult> Steps { get; set; }
		}

		public class DirectionsResult
		{
			public DistanceItem Distance { get; set; }

			public LatLng StartLocation { get; set; }

			public LatLng EndLocation { get; set; }

			public Polyline Polyline { get; set; }
		}

		public class DistanceItem
		{
			public int Value { get; set; }
		}

		[JsonConverter(typeof(StringEnumConverter))]
		public ResponseStatusType Status { get; set; }

		public List<Route> Routes { get; set; }

		public static async Task<Directions> Get(IGoogleApiService api, string origin, string destination, ModeType mode = ModeType.Walking, CancellationToken token = default(CancellationToken))
		{
			return await api.Cache.GetOrFetchObject(origin + "_" + destination, async () => await api.Service.Directions(origin, destination, mode.ToString().ToLower(), token), DateTime.Now.AddDays(2.0));
		}

		public static List<LatLng> GetRouteFromDirections(Directions directions)
		{
			List<LatLng> list = new List<LatLng>();
			directions.Routes.DoForEach(delegate(Route route)
			{
				route.Legs.DoForEach(delegate(Leg leg)
				{
					leg.Steps.DoForEach(delegate(DirectionsResult step)
					{
						list.AddRange(step.Polyline.PolylinePoints);
					}, ignoreNulls: true);
				}, ignoreNulls: true);
			}, ignoreNulls: true);
			return list;
		}
	}
	public class Elevations : BaseGoogleDataObject
	{
		public class ElevationResults
		{
			public double Elevation { get; set; }

			public LatLng Location { get; set; }

			public double Resolution { get; set; }
		}

		public List<ElevationResults> Results { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public ResponseStatusType Status { get; set; }

		public static async Task<Elevations> GetFromPoints(IGoogleApiService api, List<LatLng> points, CancellationToken token = default(CancellationToken))
		{
			string locations = "enc:" + Polyline.Encode(points);
			return await api.Service.ElevationsAtPoints(locations, token);
		}

		public static async Task<Elevations> GetSampled(IGoogleApiService api, List<LatLng> points, double sampleDistance, CancellationToken token = default(CancellationToken))
		{
			int samples = (int)Math.Round(Polyline.PolylineMeters(points) / sampleDistance);
			string path = "enc:" + Polyline.Encode(points);
			return await api.Service.ElevationsSampledAlongPath(path, samples, token);
		}
	}
	public class Geocode : BaseGoogleDataObject
	{
		public class GeocodeResults
		{
			public List<AddressComponent> AddressComponents { get; set; }

			public string FormattedAddress { get; set; }

			public Geometry Geometry { get; set; }

			public List<string> Types { get; set; }
		}

		public class Geometry
		{
			public enum GeoLocationType
			{
				[EnumMember(Value = "ROOFTOP")]
				Rooftop,
				[EnumMember(Value = "RANGE_INTERPOLATED")]
				RangeInterpolated,
				[EnumMember(Value = "GEOMETRIC_CENTER")]
				GeometricCenter,
				[EnumMember(Value = "APPROXIMATE")]
				Approximate
			}

			[JsonConverter(typeof(StringEnumConverter))]
			public GeoLocationType LocationType { get; set; }

			public LatLng Location { get; set; }
		}

		public class AddressComponent
		{
			public string LongName { get; set; }

			public string ShortName { get; set; }

			public List<string> Types { get; set; }
		}

		[JsonConverter(typeof(StringEnumConverter))]
		public ResponseStatusType Status { get; set; }

		public List<GeocodeResults> Results { get; set; }

		public static async Task<Geocode> Get(IGoogleApiService api, string address, CancellationToken token = default(CancellationToken))
		{
			return await api.Service.Geocode(address, token);
		}

		public static async Task<Geocode> ReverseGet(IGoogleApiService api, string latlng, CancellationToken token = default(CancellationToken))
		{
			return await api.Service.ReverseGeocode(latlng, token);
		}

		public static async Task<Geocode> ReverseGetByPlaceId(IGoogleApiService api, string placeId, CancellationToken token = default(CancellationToken))
		{
			return await api.Service.ReverseGeocodeForPlaceId(placeId, token);
		}
	}
	public interface IGoogleApiService
	{
		IBlobCache Cache { get; set; }

		IGoogleApi Service { get; }

		string StandardKey { get; }
	}
	public class GoogleApiService : IGoogleApiService
	{
		public const string ClientId = "gme-iconfitness";

		public string[] ApiSecret = new string[4] { "IyJlWRriy", "lKCw1Dqg3", "Il75kQUOJ", "9" };

		public string[] ApiKey = new string[3] { "@H{`RxCph09sQ", "rQ;ZOpaPs[hJJ", "z6p\\@::YQBt[p" };

		private readonly IGoogleApi googleApi;

		public string StandardKey { get; private set; }

		public IBlobCache Cache { get; set; }

		public IGoogleApi Service => googleApi;

		public GoogleApiService(IBlobCache cache, IConnectivity connectivity, string clientId = "gme-iconfitness", string apiSecret = null, string standardKey = null)
		{
			Cache = cache;
			apiSecret = apiSecret ?? ApiSecret.TransformString();
			StandardKey = standardKey ?? ApiKey.TransformString();
			RefitSettings settings = new RefitSettings
			{
				ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
				{
					ContractResolver = new SnakeCasePropertyNamesContractResolver(),
					NullValueHandling = NullValueHandling.Ignore
				})
			};
			HttpClient client = new HttpClient(new AuthenticatedHttpClientHandler(clientId, apiSecret, connectivity))
			{
				BaseAddress = new Uri("https://maps.googleapis.com/maps/api")
			};
			googleApi = RestService.For<IGoogleApi>(client, settings);
		}
	}
	public interface IGoogleApi
	{
		[Get("/streetview")]
		[Headers(new string[] { "Authorization: Signed" })]
		Task<HttpResponseMessage> StreetView(string size, string location, double heading, CancellationToken token = default(CancellationToken));

		[Get("/directions/json")]
		[Headers(new string[] { "Authorization: Signed" })]
		Task<Directions> Directions(string origin, string destination, string mode, CancellationToken token = default(CancellationToken));

		[Get("/elevation/json")]
		[Headers(new string[] { "Authorization: Signed" })]
		Task<Elevations> ElevationsAtPoints(string locations, CancellationToken token = default(CancellationToken));

		[Get("/elevation/json")]
		[Headers(new string[] { "Authorization: Signed" })]
		Task<Elevations> ElevationsSampledAlongPath(string path, int samples, CancellationToken token = default(CancellationToken));

		[Get("/geocode/json")]
		[Headers(new string[] { "Authorization: Signed" })]
		Task<Geocode> Geocode(string address, CancellationToken token = default(CancellationToken));

		[Get("/geocode/json")]
		[Headers(new string[] { "Authorization: Signed" })]
		Task<Geocode> ReverseGeocode(string latlng, CancellationToken token = default(CancellationToken));

		[Get("/geocode/json")]
		[Headers(new string[] { "Authorization: Signed" })]
		Task<Geocode> ReverseGeocodeForPlaceId(string place_id, CancellationToken token = default(CancellationToken));

		[Get("/place/autocomplete/json")]
		Task<PlaceAutoComplete> PlacesAutoComplete(string key, string input, string types = "geocode", string languages = "en", CancellationToken token = default(CancellationToken));
	}
	public class LatLng : GeoCoordinate
	{
		private string _id;

		public string Id => _id ?? (_id = Guid.NewGuid().ToString());

		public double Lat
		{
			get
			{
				return base.Latitude;
			}
			set
			{
				base.Latitude = value;
			}
		}

		public double Lng
		{
			get
			{
				return base.Longitude;
			}
			set
			{
				base.Longitude = value;
			}
		}

		public bool SnappedToRoad { get; set; }

		public LatLng()
		{
		}

		public LatLng(double latitude, double longitude, bool snappedToRoad = false)
			: base(latitude, longitude)
		{
			SnappedToRoad = snappedToRoad;
		}

		public LatLng Copy()
		{
			if (base.IsUnknown)
			{
				return new LatLng();
			}
			return new LatLng(Lat, Lng);
		}

		public void ExplicitlySetId(string id)
		{
			_id = id;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0},{1}", base.Latitude, base.Longitude);
		}

		public bool Equals(LatLng p)
		{
			return Id.Equals(p?.Id);
		}

		public static bool operator ==(LatLng p1, LatLng p2)
		{
			if ((object)p1 == p2)
			{
				return true;
			}
			if ((object)p1 == null || (object)p2 == null)
			{
				return false;
			}
			return p1.Equals(p2);
		}

		public static bool operator !=(LatLng p1, LatLng p2)
		{
			return !(p1 == p2);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			return Id.Equals((obj as LatLng)?.Id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
	public class LatLngAtDistance
	{
		public LatLng LatLng { get; set; }

		public double Meters { get; set; }

		public LatLngAtDistance(double meters, LatLng latlng)
		{
			LatLng = latlng;
			Meters = meters;
		}
	}
	public class PlaceAutoComplete : BaseGoogleDataObject
	{
		public class Prediction
		{
			public class SubstringMatch
			{
				public int Length { get; set; }

				public int Offset { get; set; }
			}

			public class Term
			{
				public int Offset { get; set; }

				public string Value { get; set; }
			}

			public string Description { get; set; }

			public string Id { get; set; }

			public string PlaceId { get; set; }

			public string Reference { get; set; }

			public List<SubstringMatch> MatchedSubstrings { get; set; }

			public List<Term> Terms { get; set; }

			public List<string> Types { get; set; }
		}

		[JsonConverter(typeof(StringEnumConverter))]
		public ResponseStatusType Status { get; set; }

		public List<Prediction> Predictions { get; set; }

		public static async Task<PlaceAutoComplete> Get(IGoogleApiService api, string input, CancellationToken token = default(CancellationToken))
		{
			return await api.Service.PlacesAutoComplete(api.StandardKey, input);
		}
	}
	public class Polyline
	{
		private List<LatLng> _points;

		public string Points { get; set; }

		public List<LatLng> PolylinePoints
		{
			get
			{
				if (_points != null)
				{
					return _points;
				}
				_points = Decode(Points);
				return _points;
			}
		}

		public static double PolylineMeters(IList<LatLng> points)
		{
			double num = 0.0;
			if (points.Count <= 1)
			{
				return num;
			}
			for (int i = 0; i < points.Count - 1; i++)
			{
				num += points[i].GetDistanceTo(points[i + 1]);
			}
			return num;
		}

		public static List<LatLng> Decode(string encodedPoints)
		{
			if (string.IsNullOrEmpty(encodedPoints))
			{
				throw new ArgumentNullException("encodedPoints");
			}
			char[] array = encodedPoints.ToCharArray();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			List<LatLng> list = new List<LatLng>();
			while (num < array.Length)
			{
				int num4 = 0;
				int num5 = 0;
				int num6;
				do
				{
					num6 = array[num++] - 63;
					num4 |= (num6 & 0x1F) << num5;
					num5 += 5;
				}
				while (num6 >= 32 && num < array.Length);
				if (num >= array.Length)
				{
					break;
				}
				num2 += (((num4 & 1) == 1) ? (~(num4 >> 1)) : (num4 >> 1));
				num4 = 0;
				num5 = 0;
				do
				{
					num6 = array[num++] - 63;
					num4 |= (num6 & 0x1F) << num5;
					num5 += 5;
				}
				while (num6 >= 32 && num < array.Length);
				if (num >= array.Length && num6 >= 32)
				{
					break;
				}
				num3 += (((num4 & 1) == 1) ? (~(num4 >> 1)) : (num4 >> 1));
				double latitude = Convert.ToDouble(num2) / 100000.0;
				double longitude = Convert.ToDouble(num3) / 100000.0;
				list.Add(new LatLng(latitude, longitude));
			}
			return list;
		}

		public static string Encode(IEnumerable<LatLng> points)
		{
			StringBuilder str = new StringBuilder();
			Action<int> action = delegate(int diff)
			{
				int num5 = diff << 1;
				if (diff < 0)
				{
					num5 = ~num5;
				}
				int num6;
				for (num6 = num5; num6 >= 32; num6 >>= 5)
				{
					str.Append((char)((0x20 | (num6 & 0x1F)) + 63));
				}
				str.Append((char)(num6 + 63));
			};
			int num = 0;
			int num2 = 0;
			foreach (LatLng point in points)
			{
				int num3 = (int)Math.Round(point.Latitude * 100000.0);
				int num4 = (int)Math.Round(point.Longitude * 100000.0);
				action(num3 - num);
				action(num4 - num2);
				num = num3;
				num2 = num4;
			}
			return str.ToString();
		}
	}
	public class PolylineBounds
	{
		public const double LatMin = -89.9999999;

		public const double LatMax = 89.9999999;

		public const double LngMin = -179.9999999;

		public const double LngMax = 179.9999999;

		public LatLng NorthWest { get; private set; } = new LatLng();

		public LatLng SouthEast { get; private set; } = new LatLng();

		public LatLng CenterPoint { get; private set; } = new LatLng();

		public double North { get; set; } = -89.9999999;

		public double South { get; set; } = 89.9999999;

		public double East { get; set; } = -179.9999999;

		public double West { get; set; } = 179.9999999;

		public PolylineBounds()
		{
		}

		public PolylineBounds(LatLng corner, LatLng oppositeCorner)
		{
			List<LatLng> list = new List<LatLng>();
			list.AddIfNotNull(corner);
			list.AddIfNotNull(oppositeCorner);
			Update(list);
		}

		public PolylineBounds(LatLng northWest, LatLng northEast, LatLng southWest, LatLng southEast)
		{
			List<LatLng> list = new List<LatLng>();
			list.AddIfNotNull(northWest);
			list.AddIfNotNull(northEast);
			list.AddIfNotNull(southEast);
			list.AddIfNotNull(southWest);
			Update(list);
		}

		public PolylineBounds(List<LatLng> route)
		{
			Update(route);
		}

		public PolylineBounds(Polyline route)
		{
			Update(route?.PolylinePoints);
		}

		public void UpdateBounds(Polyline route)
		{
			Update(route?.PolylinePoints);
		}

		public void UpdateBounds(IList<LatLng> route)
		{
			Update(route);
		}

		public void UpdateBounds(LatLng point)
		{
			List<LatLng> list = new List<LatLng>();
			list.AddIfNotNull(NorthWest);
			list.AddIfNotNull(SouthEast);
			list.AddIfNotNull(point);
			Update(list);
		}

		private void Update(IList<LatLng> route)
		{
			List<LatLng> list = route?.Where((LatLng x) => x != null && !x.IsUnknown)?.ToList();
			if (list != null && list.Count >= 1)
			{
				North = -89.9999999;
				South = 89.9999999;
				East = -179.9999999;
				West = 179.9999999;
				List<double> source = (from x in list
					select x.Lng into x
					where !double.IsNaN(x)
					select x).ToList();
				List<double> source2 = (from x in list
					select x.Lat into x
					where !double.IsNaN(x)
					select x).ToList();
				North = source2.Max();
				South = source2.Min();
				East = source.Max();
				West = source.Min();
				NorthWest.Lat = North;
				NorthWest.Lng = West;
				SouthEast.Lat = South;
				SouthEast.Lng = East;
				CenterPoint.Lat = (North + South) / 2.0;
				CenterPoint.Lng = (East + West) / 2.0;
			}
		}
	}
	public static class StreetView
	{
		public static async Task<byte[]> Get(IGoogleApiService api, int width, int height, double lat, double lng, double heading, CancellationToken token = default(CancellationToken))
		{
			string size = $"{width}x{height}";
			string location = $"{lat},{lng}";
			token.ThrowIfCancellationRequested();
			return await (await api.Service.StreetView(size, location, heading, token)).Content.ReadAsByteArrayAsync();
		}
	}
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	internal class AutoGeneratedIGoogleApi : IGoogleApi
	{
		private readonly IRequestBuilder requestBuilder;

		public HttpClient Client { get; protected set; }

		public AutoGeneratedIGoogleApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		Task<HttpResponseMessage> IGoogleApi.StreetView(string size, string location, double heading, CancellationToken token)
		{
			object[] arg = new object[4] { size, location, heading, token };
			return (Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("StreetView", new Type[4]
			{
				typeof(string),
				typeof(string),
				typeof(double),
				typeof(CancellationToken)
			})(Client, arg);
		}

		Task<Directions> IGoogleApi.Directions(string origin, string destination, string mode, CancellationToken token)
		{
			object[] arg = new object[4] { origin, destination, mode, token };
			return (Task<Directions>)requestBuilder.BuildRestResultFuncForMethod("Directions", new Type[4]
			{
				typeof(string),
				typeof(string),
				typeof(string),
				typeof(CancellationToken)
			})(Client, arg);
		}

		Task<Elevations> IGoogleApi.ElevationsAtPoints(string locations, CancellationToken token)
		{
			object[] arg = new object[2] { locations, token };
			return (Task<Elevations>)requestBuilder.BuildRestResultFuncForMethod("ElevationsAtPoints", new Type[2]
			{
				typeof(string),
				typeof(CancellationToken)
			})(Client, arg);
		}

		Task<Elevations> IGoogleApi.ElevationsSampledAlongPath(string path, int samples, CancellationToken token)
		{
			object[] arg = new object[3] { path, samples, token };
			return (Task<Elevations>)requestBuilder.BuildRestResultFuncForMethod("ElevationsSampledAlongPath", new Type[3]
			{
				typeof(string),
				typeof(int),
				typeof(CancellationToken)
			})(Client, arg);
		}

		Task<Geocode> IGoogleApi.Geocode(string address, CancellationToken token)
		{
			object[] arg = new object[2] { address, token };
			return (Task<Geocode>)requestBuilder.BuildRestResultFuncForMethod("Geocode", new Type[2]
			{
				typeof(string),
				typeof(CancellationToken)
			})(Client, arg);
		}

		Task<Geocode> IGoogleApi.ReverseGeocode(string latlng, CancellationToken token)
		{
			object[] arg = new object[2] { latlng, token };
			return (Task<Geocode>)requestBuilder.BuildRestResultFuncForMethod("ReverseGeocode", new Type[2]
			{
				typeof(string),
				typeof(CancellationToken)
			})(Client, arg);
		}

		Task<Geocode> IGoogleApi.ReverseGeocodeForPlaceId(string place_id, CancellationToken token)
		{
			object[] arg = new object[2] { place_id, token };
			return (Task<Geocode>)requestBuilder.BuildRestResultFuncForMethod("ReverseGeocodeForPlaceId", new Type[2]
			{
				typeof(string),
				typeof(CancellationToken)
			})(Client, arg);
		}

		Task<PlaceAutoComplete> IGoogleApi.PlacesAutoComplete(string key, string input, string types, string languages, CancellationToken token)
		{
			object[] arg = new object[5] { key, input, types, languages, token };
			return (Task<PlaceAutoComplete>)requestBuilder.BuildRestResultFuncForMethod("PlacesAutoComplete", new Type[5]
			{
				typeof(string),
				typeof(string),
				typeof(string),
				typeof(string),
				typeof(CancellationToken)
			})(Client, arg);
		}
	}
}
namespace iFit.Api.Google.RefitInternalGenerated
{
	[ExcludeFromCodeCoverage]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
	internal sealed class PreserveAttribute : Attribute
	{
		public bool AllMembers;

		public bool Conditional;
	}
}
