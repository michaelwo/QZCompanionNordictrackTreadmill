#define TRACE
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Lang;
using Java.Util;
using Mindscape.Raygun4Net.Builders;
using Mindscape.Raygun4Net.Messages;
using Mindscape.Raygun4Net.Reflection;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: ResourceDesigner("Mindscape.Raygun4Net.Xamarin.Android.Resource", IsApplication = false)]
[assembly: AssemblyTitle("Raygun4Net.Xamarin.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Raygun")]
[assembly: AssemblyProduct("Raygun4Net")]
[assembly: AssemblyCopyright("Copyright © Raygun 2013-2018")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: UsesPermission("android.permission.INTERNET")]
[assembly: UsesPermission("android.permission.ACCESS_NETWORK_STATE")]
[assembly: InternalsVisibleTo("Mindscape.Raygun4Net.Xamarin.Android.Tests")]
[assembly: AssemblyFileVersion("5.7.1.0")]
[assembly: TargetFramework("MonoAndroid,Version=v8.1", FrameworkDisplayName = "Xamarin.Android v8.1 Support")]
[assembly: AssemblyVersion("5.7.1.0")]
namespace Mindscape.Raygun4Net
{
	internal class PulseEventBatch
	{
		private List<PendingEvent> _pendingEvents = new List<PendingEvent>();

		private DateTime _lastUpdate;

		private readonly RaygunClient _raygunClient;

		private readonly RaygunIdentifierMessage _userInfo;

		private bool _locked;

		public bool IsLocked => _locked;

		public RaygunIdentifierMessage UserInfo => _userInfo;

		public int PendingEventCount => _pendingEvents.Count;

		public IEnumerable<PendingEvent> PendingEvents
		{
			get
			{
				foreach (PendingEvent pendingEvent in _pendingEvents)
				{
					yield return pendingEvent;
				}
			}
		}

		public PulseEventBatch(RaygunClient raygunClient)
		{
			_raygunClient = raygunClient;
			_userInfo = _raygunClient.UserInfo;
			_lastUpdate = DateTime.UtcNow;
			new System.Threading.Thread(CheckTime).Start();
		}

		private void CheckTime()
		{
			do
			{
				System.Threading.Thread.Sleep(1500);
			}
			while (!((DateTime.UtcNow - _lastUpdate).TotalSeconds > 1.0) || _pendingEvents.Count <= 0);
			Done();
		}

		public void Add(PendingEvent pendingEvent)
		{
			if (!_locked)
			{
				_lastUpdate = DateTime.UtcNow;
				_pendingEvents.Add(pendingEvent);
				if (_pendingEvents.Count >= 50)
				{
					Done();
				}
			}
		}

		public void Done()
		{
			if (!_locked)
			{
				_locked = true;
				_raygunClient.Send(this);
			}
		}
	}
	internal class PendingEvent
	{
		private readonly RaygunPulseEventType _eventType;

		private readonly string _name;

		private readonly long _milliseconds;

		private readonly DateTime _timestamp;

		private readonly string _sessionId;

		public RaygunPulseEventType EventType => _eventType;

		public string Name => _name;

		public long Duration => _milliseconds;

		public DateTime Timestamp => _timestamp;

		public string SessionId => _sessionId;

		public PendingEvent(RaygunPulseEventType eventType, string name, long milliseconds, string sessionId)
		{
			_eventType = eventType;
			_name = name;
			_milliseconds = milliseconds;
			_timestamp = DateTime.UtcNow - TimeSpan.FromMilliseconds(milliseconds);
			_sessionId = sessionId;
		}
	}
	public abstract class RaygunClientBase
	{
		protected internal const string SentKey = "AlreadySentByRaygun";

		private bool _handlingRecursiveErrorSending;

		private bool _handlingRecursiveGrouping;

		public virtual string User { get; set; }

		public virtual RaygunIdentifierMessage UserInfo { get; set; }

		public string ContextId { get; set; }

		public string ApplicationVersion { get; set; }

		public event EventHandler<RaygunSendingMessageEventArgs> SendingMessage;

		public event EventHandler<RaygunCustomGroupingKeyEventArgs> CustomGroupingKey;

		protected virtual bool CanSend(System.Exception exception)
		{
			if (exception != null && exception.Data != null && exception.Data.Contains("AlreadySentByRaygun"))
			{
				return false.Equals(exception.Data["AlreadySentByRaygun"]);
			}
			return true;
		}

		protected void FlagAsSent(System.Exception exception)
		{
			if (exception == null || exception.Data == null)
			{
				return;
			}
			try
			{
				Type[] genericArguments = exception.Data.GetType().GetGenericArguments();
				if (genericArguments.Length == 0 || genericArguments[0].IsAssignableFrom(typeof(string)))
				{
					exception.Data["AlreadySentByRaygun"] = true;
				}
			}
			catch (System.Exception)
			{
			}
		}

		protected bool OnSendingMessage(RaygunMessage raygunMessage)
		{
			bool result = true;
			if (!_handlingRecursiveErrorSending)
			{
				EventHandler<RaygunSendingMessageEventArgs> eventHandler = this.SendingMessage;
				if (eventHandler != null)
				{
					RaygunSendingMessageEventArgs e = new RaygunSendingMessageEventArgs(raygunMessage);
					try
					{
						eventHandler(this, e);
					}
					catch (System.Exception exception)
					{
						_handlingRecursiveErrorSending = true;
						Send(exception);
						_handlingRecursiveErrorSending = false;
					}
					result = !e.Cancel;
				}
			}
			return result;
		}

		protected string OnCustomGroupingKey(System.Exception exception, RaygunMessage message)
		{
			string result = null;
			if (!_handlingRecursiveGrouping)
			{
				EventHandler<RaygunCustomGroupingKeyEventArgs> eventHandler = this.CustomGroupingKey;
				if (eventHandler != null)
				{
					RaygunCustomGroupingKeyEventArgs e = new RaygunCustomGroupingKeyEventArgs(exception, message);
					try
					{
						eventHandler(this, e);
					}
					catch (System.Exception exception2)
					{
						_handlingRecursiveGrouping = true;
						Send(exception2);
						_handlingRecursiveGrouping = false;
					}
					result = e.CustomGroupingKey;
				}
			}
			return result;
		}

		public abstract void Send(System.Exception exception);

		public abstract void Send(RaygunMessage raygunMessage);
	}
	public class RaygunCustomGroupingKeyEventArgs : EventArgs
	{
		public System.Exception Exception { get; private set; }

		public RaygunMessage Message { get; private set; }

		public string CustomGroupingKey { get; set; }

		public RaygunCustomGroupingKeyEventArgs(System.Exception exception, RaygunMessage message)
		{
			Exception = exception;
			Message = message;
		}
	}
	public class RaygunSendingMessageEventArgs : CancelEventArgs
	{
		public RaygunMessage Message { get; private set; }

		public RaygunSendingMessageEventArgs(RaygunMessage message)
		{
			Message = message;
		}
	}
	[GeneratedCode("simple-json", "1.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class JsonArray : List<object>
	{
		public JsonArray()
		{
		}

		public JsonArray(int capacity)
			: base(capacity)
		{
		}

		public override string ToString()
		{
			return SimpleJson.SerializeObject(this) ?? string.Empty;
		}
	}
	[GeneratedCode("simple-json", "1.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class JsonObject : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
	{
		private readonly Dictionary<string, object> _members;

		public object this[int index] => GetAtIndex(_members, index);

		public ICollection<string> Keys => _members.Keys;

		public ICollection<object> Values => _members.Values;

		public object this[string key]
		{
			get
			{
				return _members[key];
			}
			set
			{
				_members[key] = value;
			}
		}

		public int Count => _members.Count;

		public bool IsReadOnly => false;

		public JsonObject()
		{
			_members = new Dictionary<string, object>();
		}

		public JsonObject(IEqualityComparer<string> comparer)
		{
			_members = new Dictionary<string, object>(comparer);
		}

		internal static object GetAtIndex(IDictionary<string, object> obj, int index)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (index >= obj.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int num = 0;
			foreach (KeyValuePair<string, object> item in obj)
			{
				if (num++ == index)
				{
					return item.Value;
				}
			}
			return null;
		}

		public void Add(string key, object value)
		{
			_members.Add(key, value);
		}

		public bool ContainsKey(string key)
		{
			return _members.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return _members.Remove(key);
		}

		public bool TryGetValue(string key, out object value)
		{
			return _members.TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<string, object> item)
		{
			_members.Add(item.Key, item.Value);
		}

		public void Clear()
		{
			_members.Clear();
		}

		public bool Contains(KeyValuePair<string, object> item)
		{
			if (_members.ContainsKey(item.Key))
			{
				return _members[item.Key] == item.Value;
			}
			return false;
		}

		public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num = Count;
			using IEnumerator<KeyValuePair<string, object>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, object> current = enumerator.Current;
				array[arrayIndex++] = current;
				if (--num <= 0)
				{
					break;
				}
			}
		}

		public bool Remove(KeyValuePair<string, object> item)
		{
			return _members.Remove(item.Key);
		}

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return _members.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _members.GetEnumerator();
		}

		public override string ToString()
		{
			return SimpleJson.SerializeObject(this);
		}
	}
	[GeneratedCode("simple-json", "1.0.0")]
	public static class SimpleJson
	{
		private const int TOKEN_NONE = 0;

		private const int TOKEN_CURLY_OPEN = 1;

		private const int TOKEN_CURLY_CLOSE = 2;

		private const int TOKEN_SQUARED_OPEN = 3;

		private const int TOKEN_SQUARED_CLOSE = 4;

		private const int TOKEN_COLON = 5;

		private const int TOKEN_COMMA = 6;

		private const int TOKEN_STRING = 7;

		private const int TOKEN_NUMBER = 8;

		private const int TOKEN_TRUE = 9;

		private const int TOKEN_FALSE = 10;

		private const int TOKEN_NULL = 11;

		private const int BUILDER_CAPACITY = 2000;

		private static readonly char[] EscapeTable;

		private static readonly char[] EscapeCharacters;

		private static readonly string EscapeCharactersString;

		public const string CYCLIC_MESSAGE = "[Circular reference detected, object not serialized]";

		private static IJsonSerializerStrategy _currentJsonSerializerStrategy;

		private static PocoJsonSerializerStrategy _pocoJsonSerializerStrategy;

		public static IJsonSerializerStrategy CurrentJsonSerializerStrategy
		{
			get
			{
				return _currentJsonSerializerStrategy ?? (_currentJsonSerializerStrategy = PocoJsonSerializerStrategy);
			}
			set
			{
				_currentJsonSerializerStrategy = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static PocoJsonSerializerStrategy PocoJsonSerializerStrategy => _pocoJsonSerializerStrategy ?? (_pocoJsonSerializerStrategy = new PocoJsonSerializerStrategy());

		static SimpleJson()
		{
			EscapeCharacters = new char[7] { '"', '\\', '\b', '\f', '\n', '\r', '\t' };
			EscapeCharactersString = new string(EscapeCharacters);
			EscapeTable = new char[93];
			EscapeTable[34] = '"';
			EscapeTable[92] = '\\';
			EscapeTable[8] = 'b';
			EscapeTable[12] = 'f';
			EscapeTable[10] = 'n';
			EscapeTable[13] = 'r';
			EscapeTable[9] = 't';
		}

		public static object DeserializeObject(string json)
		{
			if (TryDeserializeObject(json, out var obj))
			{
				return obj;
			}
			throw new SerializationException("Invalid JSON string");
		}

		public static bool TryDeserializeObject(string json, out object obj)
		{
			bool success = true;
			if (json != null)
			{
				char[] json2 = json.ToCharArray();
				int index = 0;
				obj = ParseValue(json2, ref index, ref success);
			}
			else
			{
				obj = null;
			}
			return success;
		}

		public static object DeserializeObject(string json, Type type, IJsonSerializerStrategy jsonSerializerStrategy)
		{
			object obj = DeserializeObject(json);
			if (!(type == null) && (obj == null || !ReflectionUtils.IsAssignableFrom(obj.GetType(), type)))
			{
				return (jsonSerializerStrategy ?? CurrentJsonSerializerStrategy).DeserializeObject(obj, type);
			}
			return obj;
		}

		public static object DeserializeObject(string json, Type type)
		{
			return DeserializeObject(json, type, null);
		}

		public static T DeserializeObject<T>(string json, IJsonSerializerStrategy jsonSerializerStrategy)
		{
			return (T)DeserializeObject(json, typeof(T), jsonSerializerStrategy);
		}

		public static T DeserializeObject<T>(string json)
		{
			return (T)DeserializeObject(json, typeof(T), null);
		}

		public static string SerializeObject(object json, IJsonSerializerStrategy jsonSerializerStrategy)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(2000);
			if (!SerializeValue(jsonSerializerStrategy, json, stringBuilder))
			{
				return null;
			}
			return stringBuilder.ToString();
		}

		public static string SerializeObject(object json)
		{
			return SerializeObject(json, CurrentJsonSerializerStrategy);
		}

		public static string EscapeToJavascriptString(string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
			{
				return jsonString;
			}
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			int num = 0;
			while (num < jsonString.Length)
			{
				char c = jsonString[num++];
				if (c == '\\')
				{
					if (jsonString.Length - num >= 2)
					{
						switch (jsonString[num])
						{
						case '\\':
							stringBuilder.Append('\\');
							num++;
							break;
						case '"':
							stringBuilder.Append("\"");
							num++;
							break;
						case 't':
							stringBuilder.Append('\t');
							num++;
							break;
						case 'b':
							stringBuilder.Append('\b');
							num++;
							break;
						case 'n':
							stringBuilder.Append('\n');
							num++;
							break;
						case 'r':
							stringBuilder.Append('\r');
							num++;
							break;
						}
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		private static IDictionary<string, object> ParseObject(char[] json, ref int index, ref bool success)
		{
			IDictionary<string, object> dictionary = new JsonObject();
			NextToken(json, ref index);
			bool flag = false;
			while (!flag)
			{
				switch (LookAhead(json, index))
				{
				case 0:
					success = false;
					return null;
				case 6:
					NextToken(json, ref index);
					continue;
				case 2:
					NextToken(json, ref index);
					return dictionary;
				}
				string key = ParseString(json, ref index, ref success);
				if (!success)
				{
					success = false;
					return null;
				}
				int num = NextToken(json, ref index);
				if (num != 5)
				{
					success = false;
					return null;
				}
				object value = ParseValue(json, ref index, ref success);
				if (!success)
				{
					success = false;
					return null;
				}
				dictionary[key] = value;
			}
			return dictionary;
		}

		private static JsonArray ParseArray(char[] json, ref int index, ref bool success)
		{
			JsonArray jsonArray = new JsonArray();
			NextToken(json, ref index);
			bool flag = false;
			while (!flag)
			{
				switch (LookAhead(json, index))
				{
				case 0:
					success = false;
					return null;
				case 6:
					NextToken(json, ref index);
					continue;
				case 4:
					break;
				default:
				{
					object item = ParseValue(json, ref index, ref success);
					if (!success)
					{
						return null;
					}
					jsonArray.Add(item);
					continue;
				}
				}
				NextToken(json, ref index);
				break;
			}
			return jsonArray;
		}

		private static object ParseValue(char[] json, ref int index, ref bool success)
		{
			switch (LookAhead(json, index))
			{
			case 7:
				return ParseString(json, ref index, ref success);
			case 8:
				return ParseNumber(json, ref index, ref success);
			case 1:
				return ParseObject(json, ref index, ref success);
			case 3:
				return ParseArray(json, ref index, ref success);
			case 9:
				NextToken(json, ref index);
				return true;
			case 10:
				NextToken(json, ref index);
				return false;
			case 11:
				NextToken(json, ref index);
				return null;
			default:
				success = false;
				return null;
			}
		}

		private static string ParseString(char[] json, ref int index, ref bool success)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(2000);
			EatWhitespace(json, ref index);
			char c = json[index++];
			bool flag = false;
			while (!flag && index != json.Length)
			{
				c = json[index++];
				switch (c)
				{
				case '"':
					flag = true;
					break;
				case '\\':
				{
					if (index == json.Length)
					{
						break;
					}
					switch (json[index++])
					{
					case '"':
						stringBuilder.Append('"');
						continue;
					case '\\':
						stringBuilder.Append('\\');
						continue;
					case '/':
						stringBuilder.Append('/');
						continue;
					case 'b':
						stringBuilder.Append('\b');
						continue;
					case 'f':
						stringBuilder.Append('\f');
						continue;
					case 'n':
						stringBuilder.Append('\n');
						continue;
					case 'r':
						stringBuilder.Append('\r');
						continue;
					case 't':
						stringBuilder.Append('\t');
						continue;
					case 'u':
						break;
					default:
						continue;
					}
					if (json.Length - index < 4)
					{
						break;
					}
					if (!(success = uint.TryParse(new string(json, index, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result)))
					{
						return "";
					}
					if (55296 <= result && result <= 56319)
					{
						index += 4;
						if (json.Length - index < 6 || !(new string(json, index, 2) == "\\u") || !uint.TryParse(new string(json, index + 2, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result2) || 56320 > result2 || result2 > 57343)
						{
							success = false;
							return "";
						}
						stringBuilder.Append((char)result);
						stringBuilder.Append((char)result2);
						index += 6;
					}
					else
					{
						stringBuilder.Append(ConvertFromUtf32((int)result));
						index += 4;
					}
					continue;
				}
				default:
					stringBuilder.Append(c);
					continue;
				}
				break;
			}
			if (!flag)
			{
				success = false;
				return null;
			}
			return stringBuilder.ToString();
		}

		private static string ConvertFromUtf32(int utf32)
		{
			if (utf32 < 0 || utf32 > 1114111)
			{
				throw new ArgumentOutOfRangeException("utf32", "The argument must be from 0 to 0x10FFFF.");
			}
			if (55296 <= utf32 && utf32 <= 57343)
			{
				throw new ArgumentOutOfRangeException("utf32", "The argument must not be in surrogate pair range.");
			}
			if (utf32 < 65536)
			{
				return new string((char)utf32, 1);
			}
			utf32 -= 65536;
			return new string(new char[2]
			{
				(char)((utf32 >> 10) + 55296),
				(char)(utf32 % 1024 + 56320)
			});
		}

		private static object ParseNumber(char[] json, ref int index, ref bool success)
		{
			EatWhitespace(json, ref index);
			int lastIndexOfNumber = GetLastIndexOfNumber(json, index);
			int length = lastIndexOfNumber - index + 1;
			string text = new string(json, index, length);
			object result2;
			if (text.IndexOf(".", StringComparison.OrdinalIgnoreCase) != -1 || text.IndexOf("e", StringComparison.OrdinalIgnoreCase) != -1)
			{
				success = double.TryParse(new string(json, index, length), NumberStyles.Any, CultureInfo.InvariantCulture, out var result);
				result2 = result;
			}
			else
			{
				success = long.TryParse(new string(json, index, length), NumberStyles.Any, CultureInfo.InvariantCulture, out var result3);
				result2 = result3;
			}
			index = lastIndexOfNumber + 1;
			return result2;
		}

		private static int GetLastIndexOfNumber(char[] json, int index)
		{
			int i;
			for (i = index; i < json.Length && "0123456789+-.eE".IndexOf(json[i]) != -1; i++)
			{
			}
			return i - 1;
		}

		private static void EatWhitespace(char[] json, ref int index)
		{
			while (index < json.Length && " \t\n\r\b\f".IndexOf(json[index]) != -1)
			{
				index++;
			}
		}

		private static int LookAhead(char[] json, int index)
		{
			int index2 = index;
			return NextToken(json, ref index2);
		}

		private static int NextToken(char[] json, ref int index)
		{
			EatWhitespace(json, ref index);
			if (index == json.Length)
			{
				return 0;
			}
			char c = json[index];
			index++;
			switch (c)
			{
			case '{':
				return 1;
			case '}':
				return 2;
			case '[':
				return 3;
			case ']':
				return 4;
			case ',':
				return 6;
			case '"':
				return 7;
			case '-':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return 8;
			case ':':
				return 5;
			default:
			{
				index--;
				int num = json.Length - index;
				if (num >= 5 && json[index] == 'f' && json[index + 1] == 'a' && json[index + 2] == 'l' && json[index + 3] == 's' && json[index + 4] == 'e')
				{
					index += 5;
					return 10;
				}
				if (num >= 4 && json[index] == 't' && json[index + 1] == 'r' && json[index + 2] == 'u' && json[index + 3] == 'e')
				{
					index += 4;
					return 9;
				}
				if (num >= 4 && json[index] == 'n' && json[index + 1] == 'u' && json[index + 2] == 'l' && json[index + 3] == 'l')
				{
					index += 4;
					return 11;
				}
				return 0;
			}
			}
		}

		private static bool SerializeValue(IJsonSerializerStrategy jsonSerializerStrategy, object value, System.Text.StringBuilder builder)
		{
			return SerializeValue(jsonSerializerStrategy, value, builder, new Stack<object>());
		}

		private static bool SerializeValue(IJsonSerializerStrategy jsonSerializerStrategy, object value, System.Text.StringBuilder builder, Stack<object> visited)
		{
			if (value == null)
			{
				return false;
			}
			if (visited.Contains(value))
			{
				return SerializeString("[Circular reference detected, object not serialized]", builder);
			}
			visited.Push(value);
			bool flag = true;
			if (value is string aString)
			{
				flag = SerializeString(aString, builder);
			}
			else if (value.GetType().IsArray)
			{
				flag = SerializeArray(jsonSerializerStrategy, value as IEnumerable, builder, visited);
			}
			else if (value is IDictionary dictionary)
			{
				flag = SerializeObject(jsonSerializerStrategy, dictionary.Keys, dictionary.Values, builder, visited);
			}
			else if (value is IDictionary<string, object> dictionary2)
			{
				flag = SerializeObject(jsonSerializerStrategy, dictionary2.Keys, dictionary2.Values, builder, visited);
			}
			else if (value is IDictionary<string, string> dictionary3)
			{
				flag = SerializeObject(jsonSerializerStrategy, dictionary3.Keys, dictionary3.Values, builder, visited);
			}
			else if (value is IEnumerable anArray)
			{
				flag = SerializeArray(jsonSerializerStrategy, anArray, builder, visited);
			}
			else if (IsNumeric(value))
			{
				flag = SerializeNumber(value, builder);
			}
			else if (value is bool)
			{
				builder.Append(((bool)value) ? "true" : "false");
			}
			else if (value == null)
			{
				builder.Append("null");
			}
			else
			{
				flag = jsonSerializerStrategy.TrySerializeNonPrimitiveObject(value, out var output);
				if (flag)
				{
					SerializeValue(jsonSerializerStrategy, output, builder, visited);
				}
			}
			if (visited.Count > 0)
			{
				visited.Pop();
			}
			return flag;
		}

		private static bool SerializeObject(IJsonSerializerStrategy jsonSerializerStrategy, IEnumerable keys, IEnumerable values, System.Text.StringBuilder builder, Stack<object> visited)
		{
			builder.Append("{");
			IEnumerator enumerator = keys.GetEnumerator();
			IEnumerator enumerator2 = values.GetEnumerator();
			bool flag = true;
			while (enumerator.MoveNext() && enumerator2.MoveNext())
			{
				object current = enumerator.Current;
				object current2 = enumerator2.Current;
				if (current2 != null)
				{
					if (!flag)
					{
						builder.Append(",");
					}
					if (current is string aString)
					{
						SerializeString(aString, builder);
					}
					else if (current != null)
					{
						SerializeString(current.ToString(), builder);
					}
					else if (!SerializeValue(jsonSerializerStrategy, current2, builder, visited))
					{
						return false;
					}
					builder.Append(":");
					if (!SerializeValue(jsonSerializerStrategy, current2, builder, visited))
					{
						return false;
					}
					flag = false;
				}
			}
			builder.Append("}");
			return true;
		}

		private static bool SerializeArray(IJsonSerializerStrategy jsonSerializerStrategy, IEnumerable anArray, System.Text.StringBuilder builder, Stack<object> visited)
		{
			builder.Append("[");
			bool flag = true;
			foreach (object item in anArray)
			{
				if (!flag)
				{
					builder.Append(",");
				}
				if (item == null)
				{
					builder.Append("null");
				}
				else if (!SerializeValue(jsonSerializerStrategy, item, builder, visited))
				{
					return false;
				}
				flag = false;
			}
			builder.Append("]");
			return true;
		}

		private static bool SerializeString(string aString, System.Text.StringBuilder builder)
		{
			builder.Append('"');
			int num = 0;
			char[] array = aString.ToCharArray();
			char[] array2 = new char[4];
			for (int i = 0; i < array.Length; i++)
			{
				char c = array[i];
				if (c >= EscapeTable.Length || EscapeTable[(uint)c] == '\0')
				{
					if (char.IsControl(c))
					{
						if (num > 0)
						{
							builder.Append(array, i - num, num);
							num = 0;
						}
						IntToHex(c, array2);
						builder.Append("\\u");
						builder.Append(array2);
					}
					else
					{
						num++;
					}
				}
				else
				{
					if (num > 0)
					{
						builder.Append(array, i - num, num);
						num = 0;
					}
					builder.Append('\\');
					builder.Append(EscapeTable[(uint)c]);
				}
			}
			if (num > 0)
			{
				builder.Append(array, array.Length - num, num);
			}
			builder.Append('"');
			return true;
		}

		private static void IntToHex(int intValue, char[] hex)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = intValue % 16;
				if (num < 10)
				{
					hex[3 - i] = (char)(48 + num);
				}
				else
				{
					hex[3 - i] = (char)(65 + (num - 10));
				}
				intValue >>= 4;
			}
		}

		private static bool SerializeNumber(object number, System.Text.StringBuilder builder)
		{
			if (number is long)
			{
				builder.Append(((long)number).ToString(CultureInfo.InvariantCulture));
			}
			else if (number is ulong)
			{
				builder.Append(((ulong)number).ToString(CultureInfo.InvariantCulture));
			}
			else if (number is int)
			{
				builder.Append(((int)number).ToString(CultureInfo.InvariantCulture));
			}
			else if (number is uint)
			{
				builder.Append(((uint)number).ToString(CultureInfo.InvariantCulture));
			}
			else if (number is decimal)
			{
				builder.Append(((decimal)number).ToString(CultureInfo.InvariantCulture));
			}
			else if (number is float)
			{
				builder.Append(((float)number).ToString(CultureInfo.InvariantCulture));
			}
			else
			{
				builder.Append(Convert.ToDouble(number, CultureInfo.InvariantCulture).ToString("r", CultureInfo.InvariantCulture));
			}
			return true;
		}

		private static bool IsNumeric(object value)
		{
			if (value is sbyte)
			{
				return true;
			}
			if (value is byte)
			{
				return true;
			}
			if (value is short)
			{
				return true;
			}
			if (value is ushort)
			{
				return true;
			}
			if (value is int)
			{
				return true;
			}
			if (value is uint)
			{
				return true;
			}
			if (value is long)
			{
				return true;
			}
			if (value is ulong)
			{
				return true;
			}
			if (value is float)
			{
				return true;
			}
			if (value is double)
			{
				return true;
			}
			if (value is decimal)
			{
				return true;
			}
			return false;
		}
	}
	[GeneratedCode("simple-json", "1.0.0")]
	public interface IJsonSerializerStrategy
	{
		bool TrySerializeNonPrimitiveObject(object input, out object output);

		object DeserializeObject(object value, Type type);
	}
	[GeneratedCode("simple-json", "1.0.0")]
	public class PocoJsonSerializerStrategy : IJsonSerializerStrategy
	{
		internal IDictionary<Type, ReflectionUtils.ConstructorDelegate> ConstructorCache;

		internal IDictionary<Type, IDictionary<string, ReflectionUtils.GetDelegate>> GetCache;

		internal IDictionary<Type, IDictionary<string, KeyValuePair<Type, ReflectionUtils.SetDelegate>>> SetCache;

		internal static readonly Type[] EmptyTypes = new Type[0];

		internal static readonly Type[] ArrayConstructorParameterTypes = new Type[1] { typeof(int) };

		private static readonly string[] Iso8601Format = new string[3] { "yyyy-MM-dd\\THH:mm:ss.FFFFFFF\\Z", "yyyy-MM-dd\\THH:mm:ss\\Z", "yyyy-MM-dd\\THH:mm:ssK" };

		public PocoJsonSerializerStrategy()
		{
			ConstructorCache = new ReflectionUtils.ThreadSafeDictionary<Type, ReflectionUtils.ConstructorDelegate>(ContructorDelegateFactory);
			GetCache = new ReflectionUtils.ThreadSafeDictionary<Type, IDictionary<string, ReflectionUtils.GetDelegate>>(GetterValueFactory);
			SetCache = new ReflectionUtils.ThreadSafeDictionary<Type, IDictionary<string, KeyValuePair<Type, ReflectionUtils.SetDelegate>>>(SetterValueFactory);
		}

		protected virtual string MapClrMemberNameToJsonFieldName(string clrPropertyName)
		{
			return clrPropertyName;
		}

		internal virtual ReflectionUtils.ConstructorDelegate ContructorDelegateFactory(Type key)
		{
			return ReflectionUtils.GetContructor(key, key.IsArray ? ArrayConstructorParameterTypes : EmptyTypes);
		}

		internal virtual IDictionary<string, ReflectionUtils.GetDelegate> GetterValueFactory(Type type)
		{
			IDictionary<string, ReflectionUtils.GetDelegate> dictionary = new Dictionary<string, ReflectionUtils.GetDelegate>();
			foreach (PropertyInfo property in ReflectionUtils.GetProperties(type))
			{
				if (property.CanRead)
				{
					MethodInfo getterMethodInfo = ReflectionUtils.GetGetterMethodInfo(property);
					if (!getterMethodInfo.IsStatic && getterMethodInfo.IsPublic)
					{
						dictionary[MapClrMemberNameToJsonFieldName(property.Name)] = ReflectionUtils.GetGetMethod(property);
					}
				}
			}
			foreach (FieldInfo field in ReflectionUtils.GetFields(type))
			{
				if (!field.IsStatic && field.IsPublic)
				{
					dictionary[MapClrMemberNameToJsonFieldName(field.Name)] = ReflectionUtils.GetGetMethod(field);
				}
			}
			return dictionary;
		}

		internal virtual IDictionary<string, KeyValuePair<Type, ReflectionUtils.SetDelegate>> SetterValueFactory(Type type)
		{
			IDictionary<string, KeyValuePair<Type, ReflectionUtils.SetDelegate>> dictionary = new Dictionary<string, KeyValuePair<Type, ReflectionUtils.SetDelegate>>();
			foreach (PropertyInfo property in ReflectionUtils.GetProperties(type))
			{
				if (property.CanWrite)
				{
					MethodInfo setterMethodInfo = ReflectionUtils.GetSetterMethodInfo(property);
					if (!setterMethodInfo.IsStatic && setterMethodInfo.IsPublic)
					{
						dictionary[MapClrMemberNameToJsonFieldName(property.Name)] = new KeyValuePair<Type, ReflectionUtils.SetDelegate>(property.PropertyType, ReflectionUtils.GetSetMethod(property));
					}
				}
			}
			foreach (FieldInfo field in ReflectionUtils.GetFields(type))
			{
				if (!field.IsInitOnly && !field.IsStatic && field.IsPublic)
				{
					dictionary[MapClrMemberNameToJsonFieldName(field.Name)] = new KeyValuePair<Type, ReflectionUtils.SetDelegate>(field.FieldType, ReflectionUtils.GetSetMethod(field));
				}
			}
			return dictionary;
		}

		public virtual bool TrySerializeNonPrimitiveObject(object input, out object output)
		{
			if (!TrySerializeKnownTypes(input, out output))
			{
				return TrySerializeUnknownTypes(input, out output);
			}
			return true;
		}

		public virtual object DeserializeObject(object value, Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			string text = value as string;
			if (type == typeof(Guid) && string.IsNullOrEmpty(text))
			{
				return default(Guid);
			}
			if (value == null)
			{
				return null;
			}
			object obj = null;
			if (text != null)
			{
				if (text.Length != 0)
				{
					if (type == typeof(DateTime) || (ReflectionUtils.IsNullableType(type) && Nullable.GetUnderlyingType(type) == typeof(DateTime)))
					{
						return DateTime.ParseExact(text, Iso8601Format, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
					}
					if (type == typeof(DateTimeOffset) || (ReflectionUtils.IsNullableType(type) && Nullable.GetUnderlyingType(type) == typeof(DateTimeOffset)))
					{
						return DateTimeOffset.ParseExact(text, Iso8601Format, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
					}
					if (type == typeof(Guid) || (ReflectionUtils.IsNullableType(type) && Nullable.GetUnderlyingType(type) == typeof(Guid)))
					{
						return new Guid(text);
					}
					if (type == typeof(System.Uri))
					{
						if (System.Uri.IsWellFormedUriString(text, UriKind.RelativeOrAbsolute) && System.Uri.TryCreate(text, UriKind.RelativeOrAbsolute, out var result))
						{
							return result;
						}
						return null;
					}
					if (type == typeof(string))
					{
						return text;
					}
					return Convert.ChangeType(text, type, CultureInfo.InvariantCulture);
				}
				obj = ((type == typeof(Guid)) ? ((object)default(Guid)) : ((!ReflectionUtils.IsNullableType(type) || !(Nullable.GetUnderlyingType(type) == typeof(Guid))) ? text : null));
				if (!ReflectionUtils.IsNullableType(type) && Nullable.GetUnderlyingType(type) == typeof(Guid))
				{
					return text;
				}
			}
			else if (value is bool)
			{
				return value;
			}
			bool flag = value is long;
			bool flag2 = value is double;
			if ((flag && type == typeof(long)) || (flag2 && type == typeof(double)))
			{
				return value;
			}
			if ((flag2 && type != typeof(double)) || (flag && type != typeof(long)))
			{
				obj = ((type == typeof(int) || type == typeof(long) || type == typeof(double) || type == typeof(float) || type == typeof(bool) || type == typeof(decimal) || type == typeof(byte) || type == typeof(short)) ? Convert.ChangeType(value, type, CultureInfo.InvariantCulture) : value);
				if (ReflectionUtils.IsNullableType(type))
				{
					return ReflectionUtils.ToNullableType(obj, type);
				}
				return obj;
			}
			if (value is IDictionary<string, object> dictionary)
			{
				IDictionary<string, object> dictionary2 = dictionary;
				if (ReflectionUtils.IsTypeDictionary(type))
				{
					Type[] genericTypeArguments = ReflectionUtils.GetGenericTypeArguments(type);
					Type type2 = genericTypeArguments[0];
					Type type3 = genericTypeArguments[1];
					Type key = typeof(Dictionary<, >).MakeGenericType(type2, type3);
					IDictionary dictionary3 = (IDictionary)ConstructorCache[key]();
					foreach (KeyValuePair<string, object> item in dictionary2)
					{
						dictionary3.Add(item.Key, DeserializeObject(item.Value, type3));
					}
					obj = dictionary3;
				}
				else if (type == typeof(object))
				{
					obj = value;
				}
				else
				{
					obj = ConstructorCache[type]();
					foreach (KeyValuePair<string, KeyValuePair<Type, ReflectionUtils.SetDelegate>> item2 in SetCache[type])
					{
						if (dictionary2.TryGetValue(item2.Key, out var value2))
						{
							value2 = DeserializeObject(value2, item2.Value.Key);
							item2.Value.Value(obj, value2);
						}
					}
				}
			}
			else if (value is IList<object> list)
			{
				IList<object> list2 = list;
				System.Collections.IList list3 = null;
				if (type.IsArray)
				{
					list3 = (System.Collections.IList)ConstructorCache[type](list2.Count);
					int num = 0;
					foreach (object item3 in list2)
					{
						list3[num++] = DeserializeObject(item3, type.GetElementType());
					}
				}
				else if (ReflectionUtils.IsTypeGenericeCollectionInterface(type) || ReflectionUtils.IsAssignableFrom(typeof(System.Collections.IList), type))
				{
					Type genericListElementType = ReflectionUtils.GetGenericListElementType(type);
					list3 = (System.Collections.IList)(ConstructorCache[type] ?? ConstructorCache[typeof(List<>).MakeGenericType(genericListElementType)])(list2.Count);
					foreach (object item4 in list2)
					{
						list3.Add(DeserializeObject(item4, genericListElementType));
					}
				}
				obj = list3;
			}
			return obj;
		}

		protected virtual object SerializeEnum(System.Enum p)
		{
			return Convert.ToDouble(p, CultureInfo.InvariantCulture);
		}

		protected virtual bool TrySerializeKnownTypes(object input, out object output)
		{
			bool result = true;
			if (input is DateTime)
			{
				output = ((DateTime)input).ToUniversalTime().ToString(Iso8601Format[0], CultureInfo.InvariantCulture);
			}
			else if (input is DateTimeOffset)
			{
				output = ((DateTimeOffset)input).ToUniversalTime().ToString(Iso8601Format[0], CultureInfo.InvariantCulture);
			}
			else if (input is Guid)
			{
				output = ((Guid)input).ToString("D");
			}
			else if (input is System.Uri)
			{
				output = input.ToString();
			}
			else if (input is Type)
			{
				output = ((Type)input).AssemblyQualifiedName;
			}
			else if (input is System.Enum p)
			{
				output = SerializeEnum(p);
			}
			else
			{
				result = false;
				output = null;
			}
			return result;
		}

		protected virtual bool TrySerializeUnknownTypes(object input, out object output)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			output = null;
			Type type = input.GetType();
			if (type.FullName == null)
			{
				return false;
			}
			IDictionary<string, object> dictionary = new JsonObject();
			foreach (KeyValuePair<string, ReflectionUtils.GetDelegate> item in GetCache[type])
			{
				if (item.Value != null)
				{
					dictionary.Add(MapClrMemberNameToJsonFieldName(item.Key), item.Value(input));
				}
			}
			output = dictionary;
			return true;
		}
	}
	internal class Pulse : Java.Lang.Object, Application.IActivityLifecycleCallbacks, IJavaObject, IDisposable
	{
		private static RaygunClient _raygunClient;

		private static Pulse _pulse;

		private static Activity _mainActivity;

		private static Activity _currentActivity;

		private static readonly Stopwatch _timer = new Stopwatch();

		internal static void Attach(RaygunClient raygunClient, Activity mainActivity)
		{
			if (_pulse == null && raygunClient != null && mainActivity != null && mainActivity.Application != null)
			{
				_raygunClient = raygunClient;
				_mainActivity = mainActivity;
				_pulse = new Pulse();
				_mainActivity.Application.RegisterActivityLifecycleCallbacks(_pulse);
				_raygunClient.EnsurePulseSessionStarted();
				_currentActivity = _mainActivity;
				_timer.Start();
			}
		}

		internal static void Detach()
		{
			if (_pulse != null && _mainActivity != null && _mainActivity.Application != null)
			{
				_mainActivity.Application.UnregisterActivityLifecycleCallbacks(_pulse);
				_mainActivity = null;
				_currentActivity = null;
				_pulse = null;
				_raygunClient = null;
			}
		}

		internal static void SendRemainingActivity()
		{
			if (_pulse != null)
			{
				if (_timer.IsRunning && _currentActivity != null)
				{
					_timer.Stop();
					string activityName = GetActivityName(_currentActivity);
					_raygunClient.SendPulseTimingEventNow(RaygunPulseEventType.ViewLoaded, activityName, _timer.ElapsedMilliseconds);
				}
				_raygunClient.EnsurePulseSessionEnded();
			}
		}

		public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
		{
			if (_currentActivity == null)
			{
				_raygunClient.EnsurePulseSessionStarted();
			}
			if (activity != _currentActivity)
			{
				_currentActivity = activity;
				_timer.Restart();
			}
		}

		public void OnActivityStarted(Activity activity)
		{
			if (_currentActivity == null)
			{
				_raygunClient.EnsurePulseSessionStarted();
			}
			if (activity != _currentActivity)
			{
				_currentActivity = activity;
				_timer.Restart();
			}
		}

		public void OnActivityResumed(Activity activity)
		{
			if (_currentActivity == null)
			{
				_raygunClient.EnsurePulseSessionStarted();
			}
			string activityName = GetActivityName(activity);
			long milliseconds = 0L;
			if (activity == _currentActivity)
			{
				_timer.Stop();
				milliseconds = _timer.ElapsedMilliseconds;
			}
			_currentActivity = activity;
			_raygunClient.SendPulseTimingEvent(RaygunPulseEventType.ViewLoaded, activityName, milliseconds);
		}

		public void OnActivityPaused(Activity activity)
		{
		}

		public void OnActivityStopped(Activity activity)
		{
			if (activity == _currentActivity)
			{
				_currentActivity = null;
				_raygunClient.EnsurePulseSessionEnded();
			}
		}

		public void OnActivityDestroyed(Activity activity)
		{
		}

		public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
		{
		}

		private static string GetActivityName(Activity activity)
		{
			return activity.GetType().Name;
		}
	}
	public class RaygunClient : RaygunClientBase
	{
		private const string RaygunSharedPrefsFile = "io.raygun.pref";

		private const string RaygunUserIdentifierDefaultsKey = "io.raygun.identifier";

		private static readonly object _batchLock = new object();

		private static bool _exceptionHandlersSet;

		private readonly string _apiKey;

		private readonly List<Type> _wrapperExceptions = new List<Type>();

		private string _sessionId;

		private string _user;

		private RaygunIdentifierMessage _userInfo;

		private PulseEventBatch _activeBatch;

		private RaygunFileManager _fileManager;

		public static RaygunClient Current { get; private set; }

		internal static Context Context => Application.Context;

		public int MaxReportsStoredOnDevice { get; set; }

		private string DeviceId
		{
			get
			{
				try
				{
					return Settings.Secure.GetString(Context.ContentResolver, "android_id");
				}
				catch (System.Exception ex)
				{
					RaygunLogger.Warning($"Failed to get device id: {ex.Message}");
				}
				return null;
			}
		}

		public override string User
		{
			get
			{
				return _user;
			}
			set
			{
				SetUserInfo(value);
			}
		}

		public override RaygunIdentifierMessage UserInfo
		{
			get
			{
				return _userInfo;
			}
			set
			{
				SetUserInfo(value);
			}
		}

		private bool HasInternetConnection
		{
			get
			{
				if (Context != null)
				{
					ConnectivityManager connectivityManager = (ConnectivityManager)Context.GetSystemService("connectivity");
					if (connectivityManager != null)
					{
						return connectivityManager.ActiveNetworkInfo?.IsConnected ?? false;
					}
				}
				return false;
			}
		}

		private void SetUserInfo(string identifier)
		{
			if (string.IsNullOrEmpty(identifier) || string.IsNullOrWhiteSpace(identifier))
			{
				SetUserInfo(GetAnonymousUserInfo());
			}
			else
			{
				SetUserInfo(new RaygunIdentifierMessage(identifier));
			}
		}

		private void SetUserInfo(RaygunIdentifierMessage userInfo)
		{
			if (_activeBatch != null)
			{
				_activeBatch.Done();
			}
			if (string.IsNullOrWhiteSpace(userInfo?.Identifier) || string.IsNullOrEmpty(userInfo.Identifier))
			{
				userInfo = GetAnonymousUserInfo();
			}
			if (_userInfo != null && _userInfo.Identifier != userInfo.Identifier && !_userInfo.IsAnonymous)
			{
				if (!string.IsNullOrEmpty(_sessionId))
				{
					SendPulseSessionEventNow(RaygunPulseSessionEventType.SessionEnd);
					_userInfo = userInfo;
					_user = userInfo.Identifier;
					SendPulseSessionEventNow(RaygunPulseSessionEventType.SessionStart);
				}
			}
			else
			{
				_userInfo = userInfo;
				_user = userInfo.Identifier;
			}
		}

		private RaygunIdentifierMessage GetAnonymousUserInfo()
		{
			return new RaygunIdentifierMessage(GetAnonymousIdentifier())
			{
				IsAnonymous = true,
				UUID = DeviceId
			};
		}

		private string GetAnonymousIdentifier()
		{
			string text = null;
			ISharedPreferences sharedPreferences = Context.GetSharedPreferences("io.raygun.pref", FileCreationMode.Private);
			if (sharedPreferences.Contains("io.raygun.identifier"))
			{
				text = sharedPreferences.GetString("io.raygun.identifier", null);
			}
			if (string.IsNullOrEmpty(text))
			{
				string deviceId = DeviceId;
				text = ((!string.IsNullOrWhiteSpace(deviceId)) ? deviceId : Guid.NewGuid().ToString());
				ISharedPreferencesEditor sharedPreferencesEditor = sharedPreferences.Edit();
				sharedPreferencesEditor.PutString("io.raygun.identifier", text);
				sharedPreferencesEditor.Commit();
			}
			return text;
		}

		private string GetVersion()
		{
			string text = base.ApplicationVersion;
			if (string.IsNullOrWhiteSpace(text))
			{
				try
				{
					Context context = Context;
					PackageInfo packageInfo = context.PackageManager.GetPackageInfo(context.PackageName, (PackageInfoFlags)0);
					text = packageInfo.VersionCode + " / " + packageInfo.VersionName;
				}
				catch (System.Exception ex)
				{
					RaygunLogger.Warning($"Error retrieving package version {ex.Message}");
				}
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "Not supplied";
			}
			return text;
		}

		public RaygunClient(string apiKey)
		{
			_apiKey = apiKey;
			_fileManager = new RaygunFileManager();
			_fileManager.Intialise();
			MaxReportsStoredOnDevice = 64;
			_user = (_userInfo = GetAnonymousUserInfo()).Identifier;
			_wrapperExceptions.Add(typeof(TargetInvocationException));
			_wrapperExceptions.Add(typeof(AggregateException));
			base.SendingMessage += RaygunClient_SendingMessage;
			try
			{
				string arg = new AssemblyName(GetType().Assembly.FullName).Version.ToString();
				RaygunLogger.Debug($"Configuring Raygun ({arg})");
			}
			catch
			{
			}
		}

		private bool ValidateApiKey()
		{
			if (string.IsNullOrEmpty(_apiKey))
			{
				RaygunLogger.Error("ApiKey has not been provided, exception will not be logged");
				return false;
			}
			return true;
		}

		public static void Attach(string apiKey)
		{
			Attach(apiKey, null);
		}

		public static void Attach(string apiKey, string user)
		{
			Detach();
			RaygunClient raygunClient = Initialize(apiKey);
			if (user != null)
			{
				raygunClient.User = user;
			}
			SetUnhandledExceptionHandlers();
			raygunClient.SendAllStoredCrashReports();
		}

		public static RaygunClient Initialize(string apiKey)
		{
			if (Current == null)
			{
				Current = new RaygunClient(apiKey);
			}
			return Current;
		}

		public RaygunClient AttachCrashReporting()
		{
			RaygunLogger.Debug("Enabling Crash Reporting");
			DetachCrashReporting();
			SetUnhandledExceptionHandlers();
			return this;
		}

		public RaygunClient AttachPulse(Activity mainActivity)
		{
			RaygunLogger.Debug("Enabling Real User Monitoring");
			Pulse.Attach(this, mainActivity);
			return this;
		}

		public static void Detach()
		{
			RemoveUnhandledExceptionHandlers();
		}

		public static void DetachCrashReporting()
		{
			RemoveUnhandledExceptionHandlers();
		}

		public static void DetachPulse()
		{
			Pulse.Detach();
		}

		private static void SetUnhandledExceptionHandlers()
		{
			if (!_exceptionHandlersSet)
			{
				_exceptionHandlersSet = true;
				RaygunLogger.Debug("Adding exception handlers");
				AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
				TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
				AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
			}
		}

		private static void RemoveUnhandledExceptionHandlers()
		{
			if (_exceptionHandlersSet)
			{
				_exceptionHandlersSet = false;
				RaygunLogger.Debug("Removing exception handlers");
				AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
				TaskScheduler.UnobservedTaskException -= TaskScheduler_UnobservedTaskException;
				AndroidEnvironment.UnhandledExceptionRaiser -= AndroidEnvironment_UnhandledExceptionRaiser;
			}
		}

		private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			if (e.Exception != null)
			{
				Current.Send(e.Exception);
			}
			if (RaygunSettings.Settings.SetUnobservedTaskExceptionsAsObserved)
			{
				e.SetObserved();
			}
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			if (e.ExceptionObject is System.Exception)
			{
				Current.Send(e.ExceptionObject as System.Exception, new List<string> { "UnhandledException" });
				Pulse.SendRemainingActivity();
			}
		}

		private static void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
		{
			if (e.Exception != null)
			{
				Current.Send(e.Exception, new List<string> { "UnhandledException" });
				Pulse.SendRemainingActivity();
			}
		}

		public void AddWrapperExceptions(params Type[] wrapperExceptions)
		{
			foreach (Type item in wrapperExceptions)
			{
				if (!_wrapperExceptions.Contains(item))
				{
					_wrapperExceptions.Add(item);
				}
			}
		}

		public void RemoveWrapperExceptions(params Type[] wrapperExceptions)
		{
			foreach (Type item in wrapperExceptions)
			{
				_wrapperExceptions.Remove(item);
			}
		}

		public override void Send(System.Exception exception)
		{
			Send(exception, null, null);
		}

		public void Send(System.Exception exception, IList<string> tags)
		{
			Send(exception, tags, null);
		}

		public void Send(System.Exception exception, IList<string> tags, IDictionary userCustomData)
		{
			if (CanSend(exception))
			{
				StripAndSend(exception, tags, userCustomData);
				FlagAsSent(exception);
			}
			else
			{
				RaygunLogger.Debug("Not sending exception");
			}
		}

		public void SendInBackground(System.Exception exception)
		{
			SendInBackground(exception, null, null);
		}

		public void SendInBackground(System.Exception exception, IList<string> tags)
		{
			SendInBackground(exception, tags, null);
		}

		public void SendInBackground(System.Exception exception, IList<string> tags, IDictionary userCustomData)
		{
			if (CanSend(exception))
			{
				ThreadPool.QueueUserWorkItem(delegate
				{
					StripAndSend(exception, tags, userCustomData);
				});
				FlagAsSent(exception);
			}
			else
			{
				RaygunLogger.Debug("Not sending exception in background");
			}
		}

		public void SendInBackground(RaygunMessage raygunMessage)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				Send(raygunMessage);
			});
		}

		private void SendAllStoredCrashReports()
		{
			if (!HasInternetConnection)
			{
				RaygunLogger.Debug("Not sending stored crash reports due to no internet connection");
				return;
			}
			List<RaygunFile> reports = _fileManager.GetAllStoredCrashReports();
			RaygunLogger.Debug($"Attempting to send {reports.Count} stored crash report(s)");
			if (reports.Count == 0)
			{
				return;
			}
			try
			{
				Task.Run(async delegate
				{
					using HttpClient client = new HttpClient();
					foreach (RaygunFile item in reports)
					{
						await SendStoredReportAsync(client, item);
					}
				}).ContinueWith(delegate(Task t)
				{
					if (t.IsFaulted)
					{
						RaygunLogger.Error("Fault occurred when sending stored reports - clearing stored reports");
						try
						{
							_fileManager.RemoveFiles(reports);
						}
						catch (System.Exception ex2)
						{
							RaygunLogger.Error("Failed to remove stored report due to error: " + ex2.Message);
						}
					}
					t.Exception.Handle(delegate(System.Exception e)
					{
						RaygunLogger.Error("Error occurred while sending stored reports: " + e.Message);
						return true;
					});
				});
			}
			catch (System.Exception ex)
			{
				RaygunLogger.Error("Failed to send stored reports due to error: " + ex.Message);
			}
		}

		private async Task SendStoredReportAsync(HttpClient client, RaygunFile report)
		{
			try
			{
				RaygunLogger.Verbose("Sending JSON -------------------------------");
				RaygunLogger.Verbose(report.Data);
				RaygunLogger.Verbose("--------------------------------------------");
				HttpContent httpContent = new StringContent(report.Data, Encoding.UTF8, "application/json");
				httpContent.Headers.Add("X-ApiKey", _apiKey);
				HttpStatusCode statusCode = (await client.PostAsync(RaygunSettings.Settings.ApiEndpoint, httpContent)).StatusCode;
				RaygunLogger.LogResponseStatusCode((int)statusCode);
				if (statusCode == HttpStatusCode.Accepted)
				{
					_fileManager.RemoveFile(report.Path);
				}
			}
			catch (System.Exception ex)
			{
				RaygunLogger.Error("Failed to send stored crash report due to error: " + ex.Message);
			}
		}

		protected RaygunMessage BuildMessage(System.Exception exception, IList<string> tags, IDictionary userCustomData)
		{
			JNIEnv.ExceptionClear();
			RaygunMessage raygunMessage = RaygunMessageBuilder.New.SetEnvironmentDetails().SetMachineName("Unknown").SetExceptionDetails(exception)
				.SetClientDetails()
				.SetVersion(GetVersion())
				.SetTags(tags)
				.SetUserCustomData(userCustomData)
				.SetUser(UserInfo)
				.Build();
			string text = OnCustomGroupingKey(exception, raygunMessage);
			if (!string.IsNullOrEmpty(text))
			{
				raygunMessage.Details.GroupingKey = text;
			}
			return raygunMessage;
		}

		private void StripAndSend(System.Exception exception, IList<string> tags, IDictionary userCustomData)
		{
			foreach (System.Exception item in StripWrapperExceptions(exception))
			{
				Send(BuildMessage(item, tags, userCustomData));
			}
		}

		protected IEnumerable<System.Exception> StripWrapperExceptions(System.Exception exception)
		{
			if (exception != null && _wrapperExceptions.Any((Type wrapperException) => exception.GetType() == wrapperException && exception.InnerException != null))
			{
				if (exception is AggregateException ex)
				{
					foreach (System.Exception innerException in ex.InnerExceptions)
					{
						foreach (System.Exception item in StripWrapperExceptions(innerException))
						{
							yield return item;
						}
					}
					yield break;
				}
				foreach (System.Exception item2 in StripWrapperExceptions(exception.InnerException))
				{
					yield return item2;
				}
			}
			else
			{
				yield return exception;
			}
		}

		public override void Send(RaygunMessage raygunMessage)
		{
			if (!ValidateApiKey())
			{
				RaygunLogger.Error("Failed to send due to invalid API key");
				return;
			}
			if (!OnSendingMessage(raygunMessage))
			{
				RaygunLogger.Debug("Sending message cancelled");
				return;
			}
			if (!HasInternetConnection)
			{
				string text = _fileManager.SaveCrashReport(raygunMessage, MaxReportsStoredOnDevice);
				if (!string.IsNullOrEmpty(text))
				{
					RaygunLogger.Debug("Saved crash report to: " + text);
				}
				return;
			}
			try
			{
				string message = SimpleJson.SerializeObject(raygunMessage);
				int num = SendMessage(message);
				RaygunLogger.LogResponseStatusCode(num);
				if (num == 429)
				{
					string text2 = _fileManager.SaveCrashReport(raygunMessage, MaxReportsStoredOnDevice);
					if (!string.IsNullOrEmpty(text2))
					{
						RaygunLogger.Debug("Saved crash report to: " + text2);
					}
				}
			}
			catch (System.Exception ex)
			{
				RaygunLogger.Error($"Error Logging Exception to Raygun API due to {ex.Message}");
				string text3 = _fileManager.SaveCrashReport(raygunMessage, MaxReportsStoredOnDevice);
				if (!string.IsNullOrEmpty(text3))
				{
					RaygunLogger.Debug("Saved crash report to: " + text3);
				}
			}
		}

		internal int SendMessage(string message)
		{
			RaygunLogger.Verbose("Sending JSON -------------------------------");
			RaygunLogger.Verbose(message);
			RaygunLogger.Verbose("--------------------------------------------");
			using (WebClient webClient = new WebClient())
			{
				webClient.Headers.Add("X-ApiKey", _apiKey);
				webClient.Headers.Add("content-type", "application/json; charset=utf-8");
				webClient.Encoding = Encoding.UTF8;
				try
				{
					webClient.UploadString(RaygunSettings.Settings.ApiEndpoint, message);
				}
				catch (System.Exception ex)
				{
					RaygunLogger.Error($"Error Logging Exception to Raygun.io {ex.Message}");
					if (ex.GetType().Name == "WebException")
					{
						return (int)((HttpWebResponse)((WebException)ex).Response).StatusCode;
					}
				}
			}
			return 202;
		}

		private void RaygunClient_SendingMessage(object sender, RaygunSendingMessageEventArgs e)
		{
			if (e.Message == null || e.Message.Details == null || e.Message.Details.Error == null)
			{
				return;
			}
			RaygunErrorStackTraceLineMessage[] stackTrace = e.Message.Details.Error.StackTrace;
			if (stackTrace == null || stackTrace.Length <= 1)
			{
				return;
			}
			string raw = stackTrace[0].Raw;
			if (raw == null || (!raw.Contains("--- End of managed exception stack trace ---") && !raw.Contains("--- End of managed " + e.Message.Details.Error.ClassName + " stack trace ---")))
			{
				return;
			}
			foreach (RaygunErrorStackTraceLineMessage item in stackTrace.Skip(1))
			{
				if (item.Raw != null && !item.Raw.StartsWith("at ") && item.Raw.Contains("JavaProxyThrowable"))
				{
					e.Cancel = true;
					break;
				}
			}
		}

		private string GenerateNewSessionId()
		{
			return Guid.NewGuid().ToString();
		}

		public void EnsurePulseSessionStarted()
		{
			if (string.IsNullOrEmpty(_sessionId))
			{
				SendPulseSessionEventNow(RaygunPulseSessionEventType.SessionStart);
			}
		}

		public void EnsurePulseSessionEnded()
		{
			if (!string.IsNullOrEmpty(_sessionId))
			{
				SendPulseSessionEventNow(RaygunPulseSessionEventType.SessionEnd);
			}
		}

		private RaygunPulseMessage BuildPulseMessage(RaygunPulseSessionEventType type)
		{
			RaygunPulseMessage raygunPulseMessage = new RaygunPulseMessage();
			RaygunPulseDataMessage raygunPulseDataMessage = new RaygunPulseDataMessage();
			raygunPulseDataMessage.Timestamp = DateTime.UtcNow;
			raygunPulseDataMessage.Version = GetVersion();
			raygunPulseDataMessage.OS = "Android";
			raygunPulseDataMessage.OSVersion = Build.VERSION.Release;
			raygunPulseDataMessage.Platform = $"{Build.Manufacturer} {Build.Model}";
			raygunPulseDataMessage.User = UserInfo;
			raygunPulseMessage.EventData = new RaygunPulseDataMessage[1] { raygunPulseDataMessage };
			switch (type)
			{
			case RaygunPulseSessionEventType.SessionStart:
				raygunPulseDataMessage.Type = "session_start";
				break;
			case RaygunPulseSessionEventType.SessionEnd:
				raygunPulseDataMessage.Type = "session_end";
				break;
			}
			raygunPulseDataMessage.SessionId = _sessionId;
			return raygunPulseMessage;
		}

		internal void SendPulseSessionEventNow(RaygunPulseSessionEventType type)
		{
			if (type == RaygunPulseSessionEventType.SessionStart)
			{
				_sessionId = GenerateNewSessionId();
			}
			RaygunPulseMessage raygunPulseMessage = BuildPulseMessage(type);
			Send(raygunPulseMessage);
			if (type == RaygunPulseSessionEventType.SessionEnd)
			{
				_sessionId = null;
			}
		}

		internal void SendPulseSessionEvent(RaygunPulseSessionEventType type)
		{
			if (type == RaygunPulseSessionEventType.SessionStart)
			{
				_sessionId = GenerateNewSessionId();
			}
			RaygunPulseMessage message = BuildPulseMessage(type);
			ThreadPool.QueueUserWorkItem(delegate
			{
				Send(message);
			});
			if (type == RaygunPulseSessionEventType.SessionEnd)
			{
				_sessionId = null;
			}
		}

		internal void SendPulseTimingEventNow(RaygunPulseEventType eventType, string name, long milliseconds)
		{
			SendPulseTimingEventCore(eventType, name, milliseconds);
		}

		public void SendPulseTimingEvent(RaygunPulseEventType eventType, string name, long milliseconds)
		{
			lock (_batchLock)
			{
				try
				{
					if (_activeBatch == null)
					{
						_activeBatch = new PulseEventBatch(this);
					}
					if (_activeBatch != null && !_activeBatch.IsLocked)
					{
						EnsurePulseSessionStarted();
						PendingEvent pendingEvent = new PendingEvent(eventType, name, milliseconds, _sessionId);
						_activeBatch.Add(pendingEvent);
					}
					else
					{
						ThreadPool.QueueUserWorkItem(delegate
						{
							SendPulseTimingEventCore(eventType, name, milliseconds);
						});
					}
				}
				catch (System.Exception ex)
				{
					RaygunLogger.Error($"Error sending pulse timing event to Raygun: {ex.Message}");
				}
			}
		}

		internal void Send(PulseEventBatch batch)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				SendCore(batch);
			});
			_activeBatch = null;
		}

		private void SendCore(PulseEventBatch batch)
		{
			try
			{
				EnsurePulseSessionStarted();
				string version = GetVersion();
				string oS = "Android";
				string release = Build.VERSION.Release;
				string platform = $"{Build.Manufacturer} {Build.Model}";
				RaygunPulseMessage raygunPulseMessage = new RaygunPulseMessage();
				RaygunLogger.Debug("BatchSize: " + batch.PendingEventCount);
				RaygunPulseDataMessage[] array = new RaygunPulseDataMessage[batch.PendingEventCount];
				int num = 0;
				foreach (PendingEvent pendingEvent in batch.PendingEvents)
				{
					RaygunPulseDataMessage raygunPulseDataMessage = new RaygunPulseDataMessage();
					raygunPulseDataMessage.SessionId = pendingEvent.SessionId;
					raygunPulseDataMessage.Timestamp = pendingEvent.Timestamp;
					raygunPulseDataMessage.Version = version;
					raygunPulseDataMessage.OS = oS;
					raygunPulseDataMessage.OSVersion = release;
					raygunPulseDataMessage.Platform = platform;
					raygunPulseDataMessage.Type = "mobile_event_timing";
					raygunPulseDataMessage.User = batch.UserInfo;
					string type = ((pendingEvent.EventType == RaygunPulseEventType.ViewLoaded) ? "p" : "n");
					RaygunPulseData raygunPulseData = new RaygunPulseData
					{
						Name = pendingEvent.Name,
						Timing = new RaygunPulseTimingMessage
						{
							Type = type,
							Duration = pendingEvent.Duration
						}
					};
					string data = SimpleJson.SerializeObject(new RaygunPulseData[1] { raygunPulseData });
					raygunPulseDataMessage.Data = data;
					array[num] = raygunPulseDataMessage;
					num++;
				}
				raygunPulseMessage.EventData = array;
				Send(raygunPulseMessage);
			}
			catch (System.Exception ex)
			{
				RaygunLogger.Error($"Error sending pulse event batch to Raygun: {ex.Message}");
			}
		}

		private void SendPulseTimingEventCore(RaygunPulseEventType eventType, string name, long milliseconds)
		{
			EnsurePulseSessionStarted();
			RaygunPulseMessage raygunPulseMessage = new RaygunPulseMessage();
			RaygunPulseDataMessage raygunPulseDataMessage = new RaygunPulseDataMessage();
			raygunPulseDataMessage.SessionId = _sessionId;
			raygunPulseDataMessage.Timestamp = DateTime.UtcNow - TimeSpan.FromMilliseconds(milliseconds);
			raygunPulseDataMessage.Version = GetVersion();
			raygunPulseDataMessage.OS = "Android";
			raygunPulseDataMessage.OSVersion = Build.VERSION.Release;
			raygunPulseDataMessage.Platform = $"{Build.Manufacturer} {Build.Model}";
			raygunPulseDataMessage.Type = "mobile_event_timing";
			raygunPulseDataMessage.User = UserInfo;
			string type = ((eventType == RaygunPulseEventType.ViewLoaded) ? "p" : "n");
			RaygunPulseData raygunPulseData = new RaygunPulseData
			{
				Name = name,
				Timing = new RaygunPulseTimingMessage
				{
					Type = type,
					Duration = milliseconds
				}
			};
			string data = SimpleJson.SerializeObject(new RaygunPulseData[1] { raygunPulseData });
			raygunPulseDataMessage.Data = data;
			raygunPulseMessage.EventData = new RaygunPulseDataMessage[1] { raygunPulseDataMessage };
			Send(raygunPulseMessage);
		}

		private void Send(RaygunPulseMessage raygunPulseMessage)
		{
			if (ValidateApiKey())
			{
				string text = null;
				try
				{
					text = SimpleJson.SerializeObject(raygunPulseMessage);
				}
				catch (System.Exception ex)
				{
					RaygunLogger.Error($"Error serializing message {ex.Message}");
				}
				if (text != null)
				{
					SendPulseMessage(text);
				}
			}
		}

		private bool SendPulseMessage(string message)
		{
			using (WebClient webClient = new WebClient())
			{
				webClient.Headers.Add("X-ApiKey", _apiKey);
				webClient.Headers.Add("content-type", "application/json; charset=utf-8");
				webClient.Encoding = Encoding.UTF8;
				try
				{
					webClient.UploadString(RaygunSettings.Settings.PulseEndpoint, message);
				}
				catch (System.Exception ex)
				{
					RaygunLogger.Error($"Error Logging Pulse message to Raygun.io {ex.Message}");
					return false;
				}
			}
			return true;
		}
	}
	public class RaygunMessageBuilder : IRaygunMessageBuilder
	{
		private readonly RaygunMessage _raygunMessage;

		public static RaygunMessageBuilder New => new RaygunMessageBuilder();

		private RaygunMessageBuilder()
		{
			_raygunMessage = new RaygunMessage();
		}

		public RaygunMessage Build()
		{
			return _raygunMessage;
		}

		public IRaygunMessageBuilder SetMachineName(string machineName)
		{
			_raygunMessage.Details.MachineName = machineName;
			return this;
		}

		public IRaygunMessageBuilder SetEnvironmentDetails()
		{
			_raygunMessage.Details.Environment = RaygunEnvironmentMessageBuilder.Build();
			return this;
		}

		public IRaygunMessageBuilder SetExceptionDetails(System.Exception exception)
		{
			if (exception != null)
			{
				_raygunMessage.Details.Error = RaygunErrorMessageBuilder.Build(exception);
			}
			return this;
		}

		public IRaygunMessageBuilder SetClientDetails()
		{
			_raygunMessage.Details.Client = new RaygunClientMessage();
			return this;
		}

		public IRaygunMessageBuilder SetUserCustomData(IDictionary userCustomData)
		{
			_raygunMessage.Details.UserCustomData = userCustomData;
			return this;
		}

		public IRaygunMessageBuilder SetTags(IList<string> tags)
		{
			_raygunMessage.Details.Tags = tags;
			return this;
		}

		public IRaygunMessageBuilder SetUser(RaygunIdentifierMessage user)
		{
			_raygunMessage.Details.User = user;
			return this;
		}

		public IRaygunMessageBuilder SetVersion(string version)
		{
			if (string.IsNullOrWhiteSpace(version))
			{
				try
				{
					Context context = RaygunClient.Context;
					PackageInfo packageInfo = context.PackageManager.GetPackageInfo(context.PackageName, (PackageInfoFlags)0);
					version = packageInfo.VersionCode + " / " + packageInfo.VersionName;
				}
				catch (System.Exception ex)
				{
					RaygunLogger.Debug($"Error retrieving package version {ex.Message}");
				}
			}
			if (string.IsNullOrWhiteSpace(version))
			{
				version = "Not supplied";
			}
			_raygunMessage.Details.Version = version;
			return this;
		}

		public IRaygunMessageBuilder SetTimeStamp(DateTime? currentTime)
		{
			if (currentTime.HasValue)
			{
				_raygunMessage.OccurredOn = currentTime.Value;
			}
			return this;
		}
	}
	public enum RaygunPulseEventType
	{
		ViewLoaded,
		NetworkCall
	}
	internal enum RaygunPulseSessionEventType
	{
		SessionStart,
		SessionEnd
	}
	public class RaygunSettings
	{
		private static RaygunSettings settings;

		private const string DefaultApiEndPoint = "https://api.raygun.io/entries";

		private const string DefaultPulseEndPoint = "https://api.raygun.io/events";

		public static RaygunSettings Settings
		{
			get
			{
				object obj = settings;
				if (obj == null)
				{
					obj = new RaygunSettings
					{
						ApiEndpoint = new System.Uri("https://api.raygun.io/entries"),
						PulseEndpoint = new System.Uri("https://api.raygun.io/events")
					};
					settings = (RaygunSettings)obj;
				}
				return (RaygunSettings)obj;
			}
		}

		public System.Uri ApiEndpoint { get; set; }

		public System.Uri PulseEndpoint { get; set; }

		public bool SetUnobservedTaskExceptionsAsObserved { get; set; }
	}
	public interface IRaygunMessageBuilder
	{
		RaygunMessage Build();

		IRaygunMessageBuilder SetMachineName(string machineName);

		IRaygunMessageBuilder SetExceptionDetails(System.Exception exception);

		IRaygunMessageBuilder SetClientDetails();

		IRaygunMessageBuilder SetEnvironmentDetails();

		IRaygunMessageBuilder SetVersion(string version);

		IRaygunMessageBuilder SetUserCustomData(IDictionary userCustomData);

		IRaygunMessageBuilder SetTags(IList<string> tags);

		IRaygunMessageBuilder SetUser(RaygunIdentifierMessage user);

		IRaygunMessageBuilder SetTimeStamp(DateTime? currentTime);
	}
	public class RaygunLogger
	{
		private static string TAG = "Raygun";

		public static void Debug(string message)
		{
			Log.Debug(TAG, message);
		}

		public static void Info(string message)
		{
			Log.Info(TAG, message);
		}

		public static void Warning(string message)
		{
			Log.Warn(TAG, message);
		}

		public static void Error(string message)
		{
			Log.Error(TAG, message);
		}

		public static void Verbose(string message)
		{
			Log.Verbose(TAG, message);
		}

		public static void LogResponseStatusCode(int statusCode)
		{
			switch (statusCode)
			{
			case 202:
				Debug(RaygunResponseStatusCodeConverter.ToString(statusCode));
				break;
			case 400:
			case 403:
			case 413:
			case 429:
				Error(RaygunResponseStatusCodeConverter.ToString(statusCode));
				break;
			default:
				Debug(RaygunResponseStatusCodeConverter.ToString(statusCode));
				break;
			}
		}
	}
	public class RaygunFileManager
	{
		public const int MAX_STORED_REPORTS_UPPER_LIMIT = 64;

		private const string RAYGUN_DIRECTORY = "RaygunIO";

		private int currentFileCounter;

		public void Intialise()
		{
			try
			{
				string crashReportDirectory = GetCrashReportDirectory();
				if (!Directory.Exists(crashReportDirectory))
				{
					Directory.CreateDirectory(crashReportDirectory);
				}
			}
			catch (System.Exception ex)
			{
				RaygunLogger.Error("Failed to initialise file manager due to error: " + ex.Message);
			}
		}

		public string SaveCrashReport(RaygunMessage crashReport, int maxReportsStored)
		{
			try
			{
				if (IsFileLimitReached(System.Math.Min(maxReportsStored, 64)))
				{
					RaygunLogger.Warning("Failed to store crash report - Reached max crash reports stored on device");
					return null;
				}
				string data = SimpleJson.SerializeObject(crashReport);
				string uniqueAcendingJsonName = GetUniqueAcendingJsonName();
				return StoreCrashReport(uniqueAcendingJsonName, data);
			}
			catch (System.Exception ex)
			{
				RaygunLogger.Error($"Failed to store crash report - Error saving message to isolated storage {ex.Message}");
			}
			return null;
		}

		private string StoreCrashReport(string fileName, string data)
		{
			string text = Path.Combine(GetCrashReportDirectory(), fileName);
			using FileStream fileStream = File.Create(text);
			byte[] bytes = Encoding.ASCII.GetBytes(data);
			fileStream.Write(bytes, 0, bytes.Length);
			return text;
		}

		public List<RaygunFile> GetAllStoredCrashReports()
		{
			List<RaygunFile> list = new List<RaygunFile>();
			try
			{
				string[] files = Directory.GetFiles(GetCrashReportDirectory());
				foreach (string path in files)
				{
					string filePath = Path.Combine(GetCrashReportDirectory(), path);
					RaygunFile raygunFile = ReadCrashReportFromDisk(filePath);
					if (raygunFile != null && raygunFile.Data != null)
					{
						list.Add(raygunFile);
					}
				}
			}
			catch (System.Exception ex)
			{
				RaygunLogger.Error($"Error sending stored messages to Raygun.io {ex.Message}");
			}
			return list;
		}

		private RaygunFile ReadCrashReportFromDisk(string filePath)
		{
			if (filePath == null || !File.Exists(filePath))
			{
				return null;
			}
			RaygunFile raygunFile = new RaygunFile(filePath);
			using StreamReader streamReader = new StreamReader(filePath);
			raygunFile.Data = streamReader.ReadToEnd();
			return raygunFile;
		}

		public void RemoveFile(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				RaygunLogger.Debug("Failed to remove file - Invalid file path");
				return;
			}
			if (!File.Exists(filePath))
			{
				RaygunLogger.Debug("Failed to remove file - File does not exist");
				return;
			}
			try
			{
				File.Delete(filePath);
			}
			catch (System.Exception ex)
			{
				RaygunLogger.Error("Failed to remove file - Due to error: " + ex.Message);
			}
		}

		public void RemoveFiles(List<RaygunFile> files)
		{
			foreach (RaygunFile file in files)
			{
				if (file != null)
				{
					RemoveFile(file.Path);
				}
			}
		}

		private bool IsFileLimitReached(int maxCount)
		{
			return NumberOfCrashReportsOnDisk() >= maxCount;
		}

		private int NumberOfCrashReportsOnDisk()
		{
			return Directory.GetFiles(GetCrashReportDirectory()).Length;
		}

		private string GetCrashReportDirectory()
		{
			return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "RaygunIO");
		}

		private string GetUniqueAcendingJsonName()
		{
			return $"{DateTime.UtcNow.Ticks}-{currentFileCounter++}-{Guid.NewGuid().ToString()}.json";
		}
	}
	public class RaygunFile
	{
		public string Path { get; set; }

		public string Data { get; set; }

		public RaygunFile(string path)
		{
			Path = path;
		}
	}
	public enum RaygunResponseStatusCode
	{
		Accepted = 202,
		BadMessage = 400,
		InvalidApiKey = 403,
		LargePayload = 413,
		RateLimited = 429
	}
	public class RaygunResponseStatusCodeConverter
	{
		public static string ToString(int statusCode)
		{
			return statusCode switch
			{
				202 => "Request succeeded", 
				400 => "Bad message - could not parse the provided JSON. Check all fields are present, especially both occurredOn (ISO 8601 DateTime) and details { } at the top level", 
				403 => "Invalid API Key - The value specified in the header X-ApiKey did not match with an application in Raygun", 
				413 => "Request entity too large - The maximum size of a JSON payload is 128KB", 
				429 => "Too Many Requests - Plan limit exceeded for month or plan expired", 
				_ => "Response status code: " + statusCode, 
			};
		}
	}
}
namespace Mindscape.Raygun4Net.Xamarin.Android
{
	[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
	public class Resource
	{
		public class Attribute
		{
			static Attribute()
			{
				ResourceIdManager.UpdateIdValues();
			}

			private Attribute()
			{
			}
		}

		public class String
		{
			public static int library_name;

			static String()
			{
				library_name = 2130837504;
				ResourceIdManager.UpdateIdValues();
			}

			private String()
			{
			}
		}

		static Resource()
		{
			ResourceIdManager.UpdateIdValues();
		}
	}
}
namespace Mindscape.Raygun4Net.Reflection
{
	[GeneratedCode("reflection-utils", "1.0.0")]
	internal class ReflectionUtils
	{
		public delegate object GetDelegate(object source);

		public delegate void SetDelegate(object source, object value);

		public delegate object ConstructorDelegate(params object[] args);

		public delegate TValue ThreadSafeDictionaryValueFactory<TKey, TValue>(TKey key);

		private static class Assigner<T>
		{
			public static T Assign(ref T left, T right)
			{
				return left = right;
			}
		}

		public sealed class ThreadSafeDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
		{
			private readonly object _lock = new object();

			private readonly ThreadSafeDictionaryValueFactory<TKey, TValue> _valueFactory;

			private Dictionary<TKey, TValue> _dictionary;

			public ICollection<TKey> Keys => _dictionary.Keys;

			public ICollection<TValue> Values => _dictionary.Values;

			public TValue this[TKey key]
			{
				get
				{
					return Get(key);
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			public int Count => _dictionary.Count;

			public bool IsReadOnly
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public ThreadSafeDictionary(ThreadSafeDictionaryValueFactory<TKey, TValue> valueFactory)
			{
				_valueFactory = valueFactory;
			}

			private TValue Get(TKey key)
			{
				if (_dictionary == null)
				{
					return AddValue(key);
				}
				if (!_dictionary.TryGetValue(key, out var value))
				{
					return AddValue(key);
				}
				return value;
			}

			private TValue AddValue(TKey key)
			{
				TValue val = _valueFactory(key);
				lock (_lock)
				{
					if (_dictionary == null)
					{
						_dictionary = new Dictionary<TKey, TValue>();
						_dictionary[key] = val;
					}
					else
					{
						if (_dictionary.TryGetValue(key, out var value))
						{
							return value;
						}
						Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(_dictionary);
						dictionary[key] = val;
						_dictionary = dictionary;
					}
				}
				return val;
			}

			public void Add(TKey key, TValue value)
			{
				throw new NotImplementedException();
			}

			public bool ContainsKey(TKey key)
			{
				return _dictionary.ContainsKey(key);
			}

			public bool Remove(TKey key)
			{
				throw new NotImplementedException();
			}

			public bool TryGetValue(TKey key, out TValue value)
			{
				value = this[key];
				return true;
			}

			public void Add(KeyValuePair<TKey, TValue> item)
			{
				throw new NotImplementedException();
			}

			public void Clear()
			{
				throw new NotImplementedException();
			}

			public bool Contains(KeyValuePair<TKey, TValue> item)
			{
				throw new NotImplementedException();
			}

			public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			public bool Remove(KeyValuePair<TKey, TValue> item)
			{
				throw new NotImplementedException();
			}

			public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
			{
				return _dictionary.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return _dictionary.GetEnumerator();
			}
		}

		private static readonly object[] EmptyObjects = new object[0];

		public static Type GetTypeInfo(Type type)
		{
			return type;
		}

		public static Attribute GetAttribute(MemberInfo info, Type type)
		{
			if (info == null || type == null || !Attribute.IsDefined(info, type))
			{
				return null;
			}
			return Attribute.GetCustomAttribute(info, type);
		}

		public static Type GetGenericListElementType(Type type)
		{
			foreach (Type item in (IEnumerable<Type>)type.GetInterfaces())
			{
				if (IsTypeGeneric(item) && item.GetGenericTypeDefinition() == typeof(IList<>))
				{
					return GetGenericTypeArguments(item)[0];
				}
			}
			return GetGenericTypeArguments(type)[0];
		}

		public static Attribute GetAttribute(Type objectType, Type attributeType)
		{
			if (objectType == null || attributeType == null || !Attribute.IsDefined(objectType, attributeType))
			{
				return null;
			}
			return Attribute.GetCustomAttribute(objectType, attributeType);
		}

		public static Type[] GetGenericTypeArguments(Type type)
		{
			return type.GetGenericArguments();
		}

		public static bool IsTypeGeneric(Type type)
		{
			return GetTypeInfo(type).IsGenericType;
		}

		public static bool IsTypeGenericeCollectionInterface(Type type)
		{
			if (!IsTypeGeneric(type))
			{
				return false;
			}
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			if (!(genericTypeDefinition == typeof(IList<>)) && !(genericTypeDefinition == typeof(ICollection<>)))
			{
				return genericTypeDefinition == typeof(IEnumerable<>);
			}
			return true;
		}

		public static bool IsAssignableFrom(Type type1, Type type2)
		{
			return GetTypeInfo(type1).IsAssignableFrom(GetTypeInfo(type2));
		}

		public static bool IsTypeDictionary(Type type)
		{
			if (typeof(IDictionary).IsAssignableFrom(type))
			{
				return true;
			}
			if (!GetTypeInfo(type).IsGenericType)
			{
				return false;
			}
			return type.GetGenericTypeDefinition() == typeof(IDictionary<, >);
		}

		public static bool IsNullableType(Type type)
		{
			if (GetTypeInfo(type).IsGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(Nullable<>);
			}
			return false;
		}

		public static object ToNullableType(object obj, Type nullableType)
		{
			if (obj != null)
			{
				return Convert.ChangeType(obj, Nullable.GetUnderlyingType(nullableType), CultureInfo.InvariantCulture);
			}
			return null;
		}

		public static bool IsValueType(Type type)
		{
			return GetTypeInfo(type).IsValueType;
		}

		public static IEnumerable<ConstructorInfo> GetConstructors(Type type)
		{
			return type.GetConstructors();
		}

		public static ConstructorInfo GetConstructorInfo(Type type, params Type[] argsType)
		{
			foreach (ConstructorInfo constructor in GetConstructors(type))
			{
				ParameterInfo[] parameters = constructor.GetParameters();
				if (argsType.Length != parameters.Length)
				{
					continue;
				}
				int num = 0;
				bool flag = true;
				ParameterInfo[] parameters2 = constructor.GetParameters();
				for (int i = 0; i < parameters2.Length; i++)
				{
					if (parameters2[i].ParameterType != argsType[num])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return constructor;
				}
			}
			return null;
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type)
		{
			return type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		public static IEnumerable<FieldInfo> GetFields(Type type)
		{
			return type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		public static MethodInfo GetGetterMethodInfo(PropertyInfo propertyInfo)
		{
			return propertyInfo.GetGetMethod(nonPublic: true);
		}

		public static MethodInfo GetSetterMethodInfo(PropertyInfo propertyInfo)
		{
			return propertyInfo.GetSetMethod(nonPublic: true);
		}

		public static ConstructorDelegate GetContructor(ConstructorInfo constructorInfo)
		{
			return GetConstructorByExpression(constructorInfo);
		}

		public static ConstructorDelegate GetContructor(Type type, params Type[] argsType)
		{
			return GetConstructorByExpression(type, argsType);
		}

		public static ConstructorDelegate GetConstructorByReflection(ConstructorInfo constructorInfo)
		{
			return (object[] args) => constructorInfo.Invoke(args);
		}

		public static ConstructorDelegate GetConstructorByReflection(Type type, params Type[] argsType)
		{
			ConstructorInfo constructorInfo = GetConstructorInfo(type, argsType);
			if (!(constructorInfo == null))
			{
				return GetConstructorByReflection(constructorInfo);
			}
			return null;
		}

		public static ConstructorDelegate GetConstructorByExpression(ConstructorInfo constructorInfo)
		{
			ParameterInfo[] parameters = constructorInfo.GetParameters();
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object[]), "args");
			Expression[] array = new Expression[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				Expression index = Expression.Constant(i);
				Type parameterType = parameters[i].ParameterType;
				Expression expression = Expression.Convert(Expression.ArrayIndex(parameterExpression, index), parameterType);
				array[i] = expression;
			}
			Expression<Func<object[], object>> expression2 = Expression.Lambda<Func<object[], object>>(Expression.New(constructorInfo, array), new ParameterExpression[1] { parameterExpression });
			Func<object[], object> compiledLambda = expression2.Compile();
			return (object[] args) => compiledLambda(args);
		}

		public static ConstructorDelegate GetConstructorByExpression(Type type, params Type[] argsType)
		{
			ConstructorInfo constructorInfo = GetConstructorInfo(type, argsType);
			if (!(constructorInfo == null))
			{
				return GetConstructorByExpression(constructorInfo);
			}
			return null;
		}

		public static GetDelegate GetGetMethod(PropertyInfo propertyInfo)
		{
			return GetGetMethodByExpression(propertyInfo);
		}

		public static GetDelegate GetGetMethod(FieldInfo fieldInfo)
		{
			return GetGetMethodByExpression(fieldInfo);
		}

		public static GetDelegate GetGetMethodByReflection(PropertyInfo propertyInfo)
		{
			MethodInfo methodInfo = GetGetterMethodInfo(propertyInfo);
			return (object source) => methodInfo.Invoke(source, EmptyObjects);
		}

		public static GetDelegate GetGetMethodByReflection(FieldInfo fieldInfo)
		{
			return (object source) => fieldInfo.GetValue(source);
		}

		public static GetDelegate GetGetMethodByExpression(PropertyInfo propertyInfo)
		{
			try
			{
				MethodInfo getterMethodInfo = GetGetterMethodInfo(propertyInfo);
				ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
				UnaryExpression instance = ((!IsValueType(propertyInfo.DeclaringType)) ? Expression.TypeAs(parameterExpression, propertyInfo.DeclaringType) : Expression.Convert(parameterExpression, propertyInfo.DeclaringType));
				Func<object, object> compiled = Expression.Lambda<Func<object, object>>(Expression.TypeAs(Expression.Call(instance, getterMethodInfo), typeof(object)), new ParameterExpression[1] { parameterExpression }).Compile();
				return delegate(object source)
				{
					try
					{
						return compiled(source);
					}
					catch (System.Exception ex3)
					{
						return ex3.GetType().FullName + ": " + ex3.Message;
					}
				};
			}
			catch (System.Exception ex)
			{
				System.Exception ex2 = ex;
				System.Exception e = ex2;
				return (object source) => e.GetType().FullName + ": " + e.Message;
			}
		}

		public static GetDelegate GetGetMethodByExpression(FieldInfo fieldInfo)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
			MemberExpression expression = Expression.Field(Expression.Convert(parameterExpression, fieldInfo.DeclaringType), fieldInfo);
			GetDelegate compiled = Expression.Lambda<GetDelegate>(Expression.Convert(expression, typeof(object)), new ParameterExpression[1] { parameterExpression }).Compile();
			return (object source) => compiled(source);
		}

		public static SetDelegate GetSetMethod(PropertyInfo propertyInfo)
		{
			return GetSetMethodByExpression(propertyInfo);
		}

		public static SetDelegate GetSetMethod(FieldInfo fieldInfo)
		{
			return GetSetMethodByExpression(fieldInfo);
		}

		public static SetDelegate GetSetMethodByReflection(PropertyInfo propertyInfo)
		{
			MethodInfo methodInfo = GetSetterMethodInfo(propertyInfo);
			return delegate(object source, object value)
			{
				methodInfo.Invoke(source, new object[1] { value });
			};
		}

		public static SetDelegate GetSetMethodByReflection(FieldInfo fieldInfo)
		{
			return delegate(object source, object value)
			{
				fieldInfo.SetValue(source, value);
			};
		}

		public static SetDelegate GetSetMethodByExpression(PropertyInfo propertyInfo)
		{
			MethodInfo setterMethodInfo = GetSetterMethodInfo(propertyInfo);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "value");
			UnaryExpression instance = ((!IsValueType(propertyInfo.DeclaringType)) ? Expression.TypeAs(parameterExpression, propertyInfo.DeclaringType) : Expression.Convert(parameterExpression, propertyInfo.DeclaringType));
			UnaryExpression unaryExpression = ((!IsValueType(propertyInfo.PropertyType)) ? Expression.TypeAs(parameterExpression2, propertyInfo.PropertyType) : Expression.Convert(parameterExpression2, propertyInfo.PropertyType));
			Action<object, object> compiled = Expression.Lambda<Action<object, object>>(Expression.Call(instance, setterMethodInfo, unaryExpression), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
			return delegate(object source, object val)
			{
				compiled(source, val);
			};
		}

		public static SetDelegate GetSetMethodByExpression(FieldInfo fieldInfo)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "value");
			Action<object, object> compiled = Expression.Lambda<Action<object, object>>(Assign(Expression.Field(Expression.Convert(parameterExpression, fieldInfo.DeclaringType), fieldInfo), Expression.Convert(parameterExpression2, fieldInfo.FieldType)), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
			return delegate(object source, object val)
			{
				compiled(source, val);
			};
		}

		public static BinaryExpression Assign(Expression left, Expression right)
		{
			MethodInfo method = typeof(Assigner<>).MakeGenericType(left.Type).GetMethod("Assign");
			return Expression.Add(left, right, method);
		}
	}
}
namespace Mindscape.Raygun4Net.Builders
{
	public abstract class RaygunErrorMessageBuilderBase
	{
		protected static string FormatTypeName(Type type, bool fullName)
		{
			string text = (fullName ? type.FullName : type.Name);
			if (!type.IsGenericType)
			{
				return text;
			}
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append(text.Substring(0, text.IndexOf("`")));
			stringBuilder.Append("<");
			Type[] genericArguments = type.GetGenericArguments();
			foreach (Type type2 in genericArguments)
			{
				stringBuilder.Append(FormatTypeName(type2, fullName: false)).Append(",");
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder.Append(">");
			return stringBuilder.ToString();
		}

		protected static string GenerateMethodName(MethodBase method)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append(method.Name);
			bool flag = true;
			if (method is MethodInfo && method.IsGenericMethod)
			{
				Type[] genericArguments = method.GetGenericArguments();
				stringBuilder.Append("[");
				for (int i = 0; i < genericArguments.Length; i++)
				{
					if (!flag)
					{
						stringBuilder.Append(",");
					}
					else
					{
						flag = false;
					}
					stringBuilder.Append(genericArguments[i].Name);
				}
				stringBuilder.Append("]");
			}
			stringBuilder.Append("(");
			ParameterInfo[] parameters = method.GetParameters();
			flag = true;
			for (int j = 0; j < parameters.Length; j++)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				else
				{
					flag = false;
				}
				string text = "<UnknownType>";
				if (parameters[j].ParameterType != null)
				{
					text = parameters[j].ParameterType.Name;
				}
				stringBuilder.Append(text + " " + parameters[j].Name);
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
	}
	public class RaygunEnvironmentMessageBuilder
	{
		public static RaygunEnvironmentMessage Build()
		{
			RaygunEnvironmentMessage raygunEnvironmentMessage = new RaygunEnvironmentMessage();
			try
			{
				DisplayMetrics displayMetrics = Resources.System.DisplayMetrics;
				raygunEnvironmentMessage.WindowBoundsWidth = displayMetrics.WidthPixels;
				raygunEnvironmentMessage.WindowBoundsHeight = displayMetrics.HeightPixels;
			}
			catch (System.Exception ex)
			{
				Trace.WriteLine($"Error retrieving screen dimensions: {ex.Message}");
			}
			try
			{
				Java.Util.TimeZone timeZone = Java.Util.TimeZone.Default;
				Date date = new Date();
				raygunEnvironmentMessage.UtcOffset = (double)timeZone.GetOffset(date.Time) / 3600000.0;
				raygunEnvironmentMessage.Locale = CultureInfo.CurrentCulture.DisplayName;
			}
			catch (System.Exception ex2)
			{
				Trace.WriteLine($"Error retrieving time and locale: {ex2.Message}");
			}
			try
			{
				Context context = RaygunClient.Context;
				if (context != null)
				{
					IWindowManager windowManager = context.GetSystemService("window").JavaCast<IWindowManager>();
					if (windowManager != null)
					{
						Display defaultDisplay = windowManager.DefaultDisplay;
						if (defaultDisplay != null)
						{
							switch (defaultDisplay.Rotation)
							{
							case SurfaceOrientation.Rotation0:
								raygunEnvironmentMessage.CurrentOrientation = "Rotation 0 (Portrait)";
								break;
							case SurfaceOrientation.Rotation180:
								raygunEnvironmentMessage.CurrentOrientation = "Rotation 180 (Upside down)";
								break;
							case SurfaceOrientation.Rotation270:
								raygunEnvironmentMessage.CurrentOrientation = "Rotation 270 (Landscape right)";
								break;
							case SurfaceOrientation.Rotation90:
								raygunEnvironmentMessage.CurrentOrientation = "Rotation 90 (Landscape left)";
								break;
							}
						}
					}
				}
			}
			catch (System.Exception ex3)
			{
				Trace.WriteLine($"Error retrieving orientation: {ex3.Message}");
			}
			try
			{
				Runtime runtime = Runtime.GetRuntime();
				raygunEnvironmentMessage.TotalPhysicalMemory = (ulong)runtime.TotalMemory();
				raygunEnvironmentMessage.AvailablePhysicalMemory = (ulong)runtime.FreeMemory();
				raygunEnvironmentMessage.OSVersion = Android.OS.Build.VERSION.Sdk;
				raygunEnvironmentMessage.ProcessorCount = runtime.AvailableProcessors();
				raygunEnvironmentMessage.Architecture = Android.OS.Build.CpuAbi;
				raygunEnvironmentMessage.Model = $"{Android.OS.Build.Model} / {Android.OS.Build.Brand}";
				raygunEnvironmentMessage.DeviceManufacturer = Android.OS.Build.Manufacturer;
			}
			catch (System.Exception ex4)
			{
				Trace.WriteLine($"Error retrieving device info: {ex4.Message}");
			}
			return raygunEnvironmentMessage;
		}
	}
	public class RaygunErrorMessageBuilder : RaygunErrorMessageBuilderBase
	{
		public static RaygunErrorMessage Build(System.Exception exception)
		{
			RaygunErrorMessage raygunErrorMessage = new RaygunErrorMessage();
			Type type = exception.GetType();
			raygunErrorMessage.Message = exception.Message;
			raygunErrorMessage.ClassName = RaygunErrorMessageBuilderBase.FormatTypeName(type, fullName: true);
			raygunErrorMessage.StackTrace = BuildStackTrace(exception);
			raygunErrorMessage.Data = exception.Data;
			if (exception is AggregateException { InnerExceptions: not null } ex)
			{
				raygunErrorMessage.InnerErrors = new RaygunErrorMessage[ex.InnerExceptions.Count];
				int num = 0;
				foreach (System.Exception innerException in ex.InnerExceptions)
				{
					raygunErrorMessage.InnerErrors[num] = Build(innerException);
					num++;
				}
			}
			else if (exception.InnerException != null)
			{
				raygunErrorMessage.InnerError = Build(exception.InnerException);
			}
			return raygunErrorMessage;
		}

		private static RaygunErrorStackTraceLineMessage[] BuildStackTrace(System.Exception exception)
		{
			List<RaygunErrorStackTraceLineMessage> list = new List<RaygunErrorStackTraceLineMessage>();
			string stackTrace = exception.StackTrace;
			if (string.IsNullOrWhiteSpace(stackTrace))
			{
				return list.ToArray();
			}
			try
			{
				string[] array = stackTrace.Split('\n');
				for (int i = 0; i < array.Length; i++)
				{
					RaygunErrorStackTraceLineMessage raygunErrorStackTraceLineMessage = ParseStackTraceLine(array[i]);
					if (raygunErrorStackTraceLineMessage != null)
					{
						list.Add(raygunErrorStackTraceLineMessage);
					}
				}
				if (list.Count > 0)
				{
					return list.ToArray();
				}
			}
			catch
			{
			}
			StackFrame[] frames = new StackTrace(exception, fNeedFileInfo: true).GetFrames();
			if (frames == null || frames.Length == 0)
			{
				return list.ToArray();
			}
			StackFrame[] array2 = frames;
			foreach (StackFrame stackFrame in array2)
			{
				MethodBase method = stackFrame.GetMethod();
				if (method != null)
				{
					int num = stackFrame.GetFileLineNumber();
					if (num == 0)
					{
						num = stackFrame.GetILOffset();
					}
					string methodName = RaygunErrorMessageBuilderBase.GenerateMethodName(method);
					string fileName = stackFrame.GetFileName();
					string className = ((method.ReflectedType != null) ? method.ReflectedType.FullName : "(unknown)");
					RaygunErrorStackTraceLineMessage item = new RaygunErrorStackTraceLineMessage
					{
						FileName = fileName,
						LineNumber = num,
						MethodName = methodName,
						ClassName = className
					};
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		internal static RaygunErrorStackTraceLineMessage ParseStackTraceLine(string stackTraceLine)
		{
			try
			{
				int? lineNumber = null;
				string text = null;
				string text2 = null;
				string text3 = null;
				string text4 = stackTraceLine.Trim();
				bool flag = false;
				int num = text4.LastIndexOf(":");
				if (num > 0)
				{
					flag = text4.EndsWith(")", StringComparison.Ordinal);
					int val = (flag ? (text4.Length - num - 2) : (text4.Length - num - 1));
					if (int.TryParse(text4.Substring(num + 1, System.Math.Max(0, val)), out var result))
					{
						lineNumber = result;
						text4 = text4.Substring(0, num);
					}
					else
					{
						flag = false;
					}
				}
				int num2 = 0;
				if (flag)
				{
					num = (num = text4.LastIndexOf("(", StringComparison.Ordinal));
					num2 = 1;
				}
				if (!flag || num < 0)
				{
					num = text4.LastIndexOf(" in ", StringComparison.Ordinal);
					num2 = 4;
				}
				if (num > 0)
				{
					text = text4.Substring(num + num2);
					if ("<filename unknown>".Equals(text, StringComparison.Ordinal))
					{
						text = null;
					}
					text4 = text4.Substring(0, num);
				}
				if (!text4.StartsWith("at (wrapper", StringComparison.Ordinal) && text4.StartsWith("at ", StringComparison.Ordinal))
				{
					string text5 = "";
					int num3 = text4.LastIndexOf("(", StringComparison.Ordinal);
					if (num3 > 0)
					{
						int num4 = text4.IndexOf("[0x", StringComparison.Ordinal) - 1;
						if (num4 < 0)
						{
							num4 = text4.IndexOf("<0x", StringComparison.Ordinal) - 1;
							if (num4 < 0)
							{
								num4 = text4.Length - 1;
							}
						}
						text5 = text4.Substring(num3, num4 - num3 + 1).Trim();
					}
					else
					{
						num3 = text4.Length;
					}
					int num5 = text4.IndexOf("<", StringComparison.Ordinal) + 1;
					int num6 = num5;
					int num7 = 0;
					if (num5 > 0 && num5 < num3)
					{
						num6 = text4.IndexOf(">", num5, StringComparison.Ordinal) - 1;
						num7 = 2;
					}
					if (num6 - num5 <= 0)
					{
						num5 = text4.LastIndexOf("..", num3, StringComparison.Ordinal) + 1;
						num6 = num3 - 1;
						num7 = 1;
					}
					if (num5 <= 0)
					{
						num5 = text4.LastIndexOf(".", num3, StringComparison.Ordinal) + 1;
						num6 = num3 - 1;
						num7 = 1;
					}
					if (num5 > 0)
					{
						text2 = text4.Substring(num5, num6 - num5 + 1).Trim();
						text2 += text5;
						text4 = text4.Substring(0, num5 - num7);
					}
					num = text4.IndexOf("at ", StringComparison.Ordinal);
					if (num >= 0)
					{
						text3 = text4.Substring(num + 3);
					}
				}
				if (lineNumber.HasValue || !string.IsNullOrWhiteSpace(text2) || !string.IsNullOrWhiteSpace(text) || !string.IsNullOrWhiteSpace(text3))
				{
					return new RaygunErrorStackTraceLineMessage
					{
						FileName = text,
						LineNumber = lineNumber,
						MethodName = text2,
						ClassName = text3,
						Raw = stackTraceLine.Trim()
					};
				}
				if (!string.IsNullOrWhiteSpace(stackTraceLine))
				{
					return new RaygunErrorStackTraceLineMessage
					{
						Raw = stackTraceLine.Trim()
					};
				}
			}
			catch
			{
				if (!string.IsNullOrWhiteSpace(stackTraceLine))
				{
					return new RaygunErrorStackTraceLineMessage
					{
						Raw = stackTraceLine.Trim()
					};
				}
			}
			return null;
		}
	}
}
namespace Mindscape.Raygun4Net.Messages
{
	public class RaygunErrorMessage
	{
		public RaygunErrorMessage InnerError { get; set; }

		public RaygunErrorMessage[] InnerErrors { get; set; }

		public IDictionary Data { get; set; }

		public string ClassName { get; set; }

		public string Message { get; set; }

		public RaygunErrorStackTraceLineMessage[] StackTrace { get; set; }

		public override string ToString()
		{
			return $"[RaygunErrorMessage: InnerError={InnerError}, InnerErrors={InnerErrors}, Data={Data}, ClassName={ClassName}, Message={Message}, StackTrace={StackTrace}]";
		}
	}
	public class RaygunMessageDetails
	{
		public string MachineName { get; set; }

		public string GroupingKey { get; set; }

		public string Version { get; set; }

		public RaygunErrorMessage Error { get; set; }

		public RaygunEnvironmentMessage Environment { get; set; }

		public RaygunClientMessage Client { get; set; }

		public IList<string> Tags { get; set; }

		public IDictionary UserCustomData { get; set; }

		public RaygunIdentifierMessage User { get; set; }

		public override string ToString()
		{
			return $"[RaygunMessageDetails: MachineName={MachineName}, Version={Version}, Error={Error}, Environment={Environment}, Client={Client}, Tags={Tags}, UserCustomData={UserCustomData}, User={User}]";
		}
	}
	public class RaygunErrorStackTraceLineMessage
	{
		public int? LineNumber { get; set; }

		public string ClassName { get; set; }

		public string FileName { get; set; }

		public string MethodName { get; set; }

		public string Raw { get; set; }

		public override string ToString()
		{
			return $"[RaygunErrorStackTraceLineMessage: LineNumber={LineNumber}, ClassName={ClassName}, FileName={FileName}, MethodName={MethodName}, Raw={Raw}]";
		}
	}
	public class RaygunMessage
	{
		public DateTime OccurredOn { get; set; }

		public RaygunMessageDetails Details { get; set; }

		public RaygunMessage()
		{
			OccurredOn = DateTime.UtcNow;
			Details = new RaygunMessageDetails();
		}

		public override string ToString()
		{
			return $"[RaygunMessage: OccurredOn={OccurredOn}, Details={Details}]";
		}
	}
	public class RaygunEnvironmentMessage
	{
		public int ProcessorCount { get; set; }

		public string OSVersion { get; set; }

		public double WindowBoundsWidth { get; set; }

		public double WindowBoundsHeight { get; set; }

		public string CurrentOrientation { get; set; }

		public string Architecture { get; set; }

		public string Model { get; set; }

		public ulong TotalPhysicalMemory { get; set; }

		public ulong AvailablePhysicalMemory { get; set; }

		public string DeviceManufacturer { get; set; }

		public double UtcOffset { get; set; }

		public string Locale { get; set; }

		public override string ToString()
		{
			return $"[RaygunEnvironmentMessage: ProcessorCount={ProcessorCount}, OSVersion={OSVersion}, WindowBoundsWidth={WindowBoundsWidth}, WindowBoundsHeight={WindowBoundsHeight}, CurrentOrientation={CurrentOrientation}, Architecture={Architecture}, Mode={Model}, TotalPhysicalMemory={TotalPhysicalMemory}, AvailablePhysicalMemory={AvailablePhysicalMemory}, DeviceManufacturer={DeviceManufacturer}, UtcOffset={UtcOffset}, Locale={Locale}]";
		}
	}
	public class RaygunPulseData
	{
		public string Name { get; set; }

		public RaygunPulseTimingMessage Timing { get; set; }
	}
	public class RaygunPulseDataMessage
	{
		public string SessionId { get; set; }

		public DateTime Timestamp { get; set; }

		public string Type { get; set; }

		public RaygunIdentifierMessage User { get; set; }

		public string Version { get; set; }

		public string OS { get; set; }

		public string OSVersion { get; set; }

		public string Platform { get; set; }

		public string Data { get; set; }
	}
	public class RaygunPulseMessage
	{
		public RaygunPulseDataMessage[] EventData { get; set; }
	}
	public class RaygunPulseTimingMessage
	{
		public string Type { get; set; }

		public decimal Duration { get; set; }
	}
	public class RaygunIdentifierMessage
	{
		public string Identifier { get; set; }

		public bool IsAnonymous { get; set; }

		public string Email { get; set; }

		public string FullName { get; set; }

		public string FirstName { get; set; }

		public string UUID { get; set; }

		public RaygunIdentifierMessage(string user)
		{
			Identifier = user;
		}

		public override string ToString()
		{
			return $"[RaygunIdentifierMessage: Identifier={Identifier}, IsAnonymous={IsAnonymous}, Email={Email}, FullName={FullName}, FirstName={FirstName}, UUID={UUID}]";
		}
	}
	public class RaygunClientMessage
	{
		public string Name { get; set; }

		public string Version { get; set; }

		public string ClientUrl { get; set; }

		public RaygunClientMessage()
		{
			Name = "Raygun4Net.Xamarin.Android";
			Version = new AssemblyName(GetType().Assembly.FullName).Version.ToString();
			ClientUrl = "https://github.com/MindscapeHQ/raygun4net";
		}

		public override string ToString()
		{
			return $"[RaygunClientMessage: Name={Name}, Version={Version}, ClientUrl={ClientUrl}]";
		}
	}
}
