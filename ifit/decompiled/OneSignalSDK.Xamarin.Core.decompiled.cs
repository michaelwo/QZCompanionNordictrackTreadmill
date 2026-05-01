using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyVersion("0.0.0.0")]
namespace Laters
{
	public interface ILater
	{
	}
	public interface ILater<TResult> : ILater
	{
		event Action<TResult> OnComplete;

		TaskAwaiter<TResult> GetAwaiter();
	}
	public class Later<TResult> : BaseLater<TResult>
	{
		public void Complete(TResult result)
		{
			_complete(result);
		}
	}
	public abstract class BaseLater<TResult> : ILater<TResult>, ILater
	{
		private TaskCompletionSource<TResult> _completionSource;

		private bool _isComplete;

		private TResult _result;

		public event Action<TResult> OnComplete
		{
			add
			{
				if (_isComplete)
				{
					_onComplete += value;
				}
				else
				{
					value?.Invoke(_result);
				}
			}
			remove
			{
				_onComplete -= value;
			}
		}

		private event Action<TResult> _onComplete;

		public TaskAwaiter<TResult> GetAwaiter()
		{
			if (_completionSource != null)
			{
				return _completionSource.Task.GetAwaiter();
			}
			_completionSource = new TaskCompletionSource<TResult>();
			if (_isComplete)
			{
				_completionSource.TrySetResult(_result);
			}
			else
			{
				_onComplete += delegate(TResult result)
				{
					_completionSource.TrySetResult(result);
				};
			}
			return _completionSource.Task.GetAwaiter();
		}

		protected void _complete(TResult result)
		{
			if (!_isComplete)
			{
				_result = result;
				Action<TResult> action = this._onComplete;
				this._onComplete = null;
				_isComplete = true;
				action?.Invoke(_result);
			}
		}
	}
}
namespace OneSignalSDK.Xamarin.Core
{
	[Serializable]
	public sealed class DeviceState
	{
		public NotificationPermission notificationPermission;

		public bool areNotificationsEnabled;

		public bool isSubscribed;

		public string userId;

		public string pushToken;

		public bool isPushDisabled;

		public bool isEmailSubscribed;

		public string emailUserId;

		public string emailAddress;

		public bool isSMSSubscribed;

		public string smsNumber;

		public string smsUserId;
	}
	[Serializable]
	public sealed class EmailSubscriptionState
	{
		public string emailUserId;

		public bool isSubscribed;

		public string emailAddress;
	}
	[Serializable]
	public sealed class InAppMessage
	{
		public string messageId;
	}
	[Serializable]
	public sealed class InAppMessageAction
	{
		public string clickName;

		public string clickUrl;

		public bool firstClick;

		public bool closesMessage;
	}
	public class InAppMessageOutcome
	{
		public string name;

		public float weight;

		public bool unique;
	}
	public static class Json
	{
		private sealed class Parser : IDisposable
		{
			private enum TOKEN
			{
				NONE,
				CURLY_OPEN,
				CURLY_CLOSE,
				SQUARED_OPEN,
				SQUARED_CLOSE,
				COLON,
				COMMA,
				STRING,
				NUMBER,
				TRUE,
				FALSE,
				NULL
			}

			private const string WORD_BREAK = "{}[],:\"";

			private StringReader json;

			private char PeekChar => Convert.ToChar(json.Peek());

			private char NextChar => Convert.ToChar(json.Read());

			private string NextWord
			{
				get
				{
					StringBuilder stringBuilder = new StringBuilder();
					while (!IsWordBreak(PeekChar))
					{
						stringBuilder.Append(NextChar);
						if (json.Peek() == -1)
						{
							break;
						}
					}
					return stringBuilder.ToString();
				}
			}

			private TOKEN NextToken
			{
				get
				{
					EatWhitespace();
					if (json.Peek() == -1)
					{
						return TOKEN.NONE;
					}
					switch (PeekChar)
					{
					case '{':
						return TOKEN.CURLY_OPEN;
					case '}':
						json.Read();
						return TOKEN.CURLY_CLOSE;
					case '[':
						return TOKEN.SQUARED_OPEN;
					case ']':
						json.Read();
						return TOKEN.SQUARED_CLOSE;
					case ',':
						json.Read();
						return TOKEN.COMMA;
					case '"':
						return TOKEN.STRING;
					case ':':
						return TOKEN.COLON;
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
						return TOKEN.NUMBER;
					default:
						return NextWord switch
						{
							"false" => TOKEN.FALSE, 
							"true" => TOKEN.TRUE, 
							"null" => TOKEN.NULL, 
							_ => TOKEN.NONE, 
						};
					}
				}
			}

			public static bool IsWordBreak(char c)
			{
				if (!char.IsWhiteSpace(c))
				{
					return "{}[],:\"".IndexOf(c) != -1;
				}
				return true;
			}

			private Parser(string jsonString)
			{
				json = new StringReader(jsonString);
			}

			public static object Parse(string jsonString)
			{
				using Parser parser = new Parser(jsonString);
				return parser.ParseValue();
			}

			public void Dispose()
			{
				json.Dispose();
				json = null;
			}

			private Dictionary<string, object> ParseObject()
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				json.Read();
				while (true)
				{
					switch (NextToken)
					{
					case TOKEN.COMMA:
						continue;
					case TOKEN.NONE:
						return null;
					case TOKEN.CURLY_CLOSE:
						return dictionary;
					}
					string text = ParseString();
					if (text == null)
					{
						return null;
					}
					if (NextToken != TOKEN.COLON)
					{
						return null;
					}
					json.Read();
					dictionary[text] = ParseValue();
				}
			}

			private List<object> ParseArray()
			{
				List<object> list = new List<object>();
				json.Read();
				bool flag = true;
				while (flag)
				{
					TOKEN nextToken = NextToken;
					switch (nextToken)
					{
					case TOKEN.NONE:
						return null;
					case TOKEN.SQUARED_CLOSE:
						flag = false;
						break;
					default:
					{
						object item = ParseByToken(nextToken);
						list.Add(item);
						break;
					}
					case TOKEN.COMMA:
						break;
					}
				}
				return list;
			}

			private object ParseValue()
			{
				TOKEN nextToken = NextToken;
				return ParseByToken(nextToken);
			}

			private object ParseByToken(TOKEN token)
			{
				return token switch
				{
					TOKEN.STRING => ParseString(), 
					TOKEN.NUMBER => ParseNumber(), 
					TOKEN.CURLY_OPEN => ParseObject(), 
					TOKEN.SQUARED_OPEN => ParseArray(), 
					TOKEN.TRUE => true, 
					TOKEN.FALSE => false, 
					TOKEN.NULL => null, 
					_ => null, 
				};
			}

			private string ParseString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				json.Read();
				bool flag = true;
				while (flag)
				{
					if (json.Peek() == -1)
					{
						flag = false;
						break;
					}
					char nextChar = NextChar;
					switch (nextChar)
					{
					case '"':
						flag = false;
						break;
					case '\\':
						if (json.Peek() == -1)
						{
							flag = false;
							break;
						}
						nextChar = NextChar;
						switch (nextChar)
						{
						case '"':
						case '/':
						case '\\':
							stringBuilder.Append(nextChar);
							break;
						case 'b':
							stringBuilder.Append('\b');
							break;
						case 'f':
							stringBuilder.Append('\f');
							break;
						case 'n':
							stringBuilder.Append('\n');
							break;
						case 'r':
							stringBuilder.Append('\r');
							break;
						case 't':
							stringBuilder.Append('\t');
							break;
						case 'u':
						{
							char[] array = new char[4];
							for (int i = 0; i < 4; i++)
							{
								array[i] = NextChar;
							}
							stringBuilder.Append((char)Convert.ToInt32(new string(array), 16));
							break;
						}
						}
						break;
					default:
						stringBuilder.Append(nextChar);
						break;
					}
				}
				return stringBuilder.ToString();
			}

			private object ParseNumber()
			{
				string nextWord = NextWord;
				if (nextWord.IndexOf('.') == -1)
				{
					long.TryParse(nextWord, out var result);
					return result;
				}
				double.TryParse(nextWord, out var result2);
				return result2;
			}

			private void EatWhitespace()
			{
				while (char.IsWhiteSpace(PeekChar))
				{
					json.Read();
					if (json.Peek() == -1)
					{
						break;
					}
				}
			}
		}

		private sealed class Serializer
		{
			private StringBuilder builder;

			private Serializer()
			{
				builder = new StringBuilder();
			}

			public static string Serialize(object obj)
			{
				Serializer serializer = new Serializer();
				serializer.SerializeValue(obj);
				return serializer.builder.ToString();
			}

			private void SerializeValue(object value)
			{
				if (value == null)
				{
					builder.Append("null");
				}
				else if (value is string str)
				{
					SerializeString(str);
				}
				else if (value is bool)
				{
					builder.Append(((bool)value) ? "true" : "false");
				}
				else if (value is IList anArray)
				{
					SerializeArray(anArray);
				}
				else if (value is IDictionary obj)
				{
					SerializeObject(obj);
				}
				else if (value is char)
				{
					SerializeString(new string((char)value, 1));
				}
				else
				{
					SerializeOther(value);
				}
			}

			private void SerializeObject(IDictionary obj)
			{
				bool flag = true;
				builder.Append('{');
				foreach (object key in obj.Keys)
				{
					if (!flag)
					{
						builder.Append(',');
					}
					SerializeString(key.ToString());
					builder.Append(':');
					SerializeValue(obj[key]);
					flag = false;
				}
				builder.Append('}');
			}

			private void SerializeArray(IList anArray)
			{
				builder.Append('[');
				bool flag = true;
				foreach (object item in anArray)
				{
					if (!flag)
					{
						builder.Append(',');
					}
					SerializeValue(item);
					flag = false;
				}
				builder.Append(']');
			}

			private void SerializeString(string str)
			{
				builder.Append('"');
				char[] array = str.ToCharArray();
				char[] array2 = array;
				foreach (char c in array2)
				{
					switch (c)
					{
					case '"':
						builder.Append("\\\"");
						continue;
					case '\\':
						builder.Append("\\\\");
						continue;
					case '\b':
						builder.Append("\\b");
						continue;
					case '\f':
						builder.Append("\\f");
						continue;
					case '\n':
						builder.Append("\\n");
						continue;
					case '\r':
						builder.Append("\\r");
						continue;
					case '\t':
						builder.Append("\\t");
						continue;
					}
					int num = Convert.ToInt32(c);
					if (num >= 32 && num <= 126)
					{
						builder.Append(c);
						continue;
					}
					builder.Append("\\u");
					builder.Append(num.ToString("x4"));
				}
				builder.Append('"');
			}

			private void SerializeOther(object value)
			{
				if (value is float)
				{
					builder.Append(((float)value).ToString("R"));
				}
				else if (value is int || value is uint || value is long || value is sbyte || value is byte || value is short || value is ushort || value is ulong)
				{
					builder.Append(value);
				}
				else if (value is double || value is decimal)
				{
					builder.Append(Convert.ToDouble(value).ToString("R"));
				}
				else
				{
					SerializeString(value.ToString());
				}
			}
		}

		public static object Deserialize(string json)
		{
			if (json == null)
			{
				return null;
			}
			return Parser.Parse(json);
		}

		public static string Serialize(object obj)
		{
			return Serializer.Serialize(obj);
		}
	}
	public enum LogLevel
	{
		NONE,
		FATAL,
		ERROR,
		WARN,
		INFO,
		DEBUG,
		VERBOSE
	}
	public class Notification
	{
		public string title;

		public string body;

		public string sound;

		public string launchUrl;

		public string rawPayload;

		public List<ActionButton> actionButtons;

		public Dictionary<string, object> additionalData;

		public string notificationId;

		public List<Notification> groupedNotifications;

		public BackgroundImageLayout backgroundImageLayout;

		public string groupKey;

		public string groupMessage;

		public string ledColor;

		public int priority;

		public string smallIcon;

		public string largeIcon;

		public string bigPicture;

		public string CollapseId;

		public string fromProjectNumber;

		public string smallIconAccentColor;

		public int lockScreenVisibility;

		public int androidNotificationId;

		public string badge;

		public string badgeIncrement;

		public string category;

		public string threadId;

		public string subtitle;

		public string templateId;

		public string templateName;

		public float relevanceScore;

		public bool mutableContent;

		public bool contentAvailable;

		public string interruptionLevel;
	}
	public class ActionButton
	{
		public string id;

		public string text;

		public string icon;

		public ActionButton(string id, string text, string icon)
		{
			this.id = id;
			this.text = text;
			this.icon = icon;
		}
	}
	public class BackgroundImageLayout
	{
		public string image;

		public string titleTextColor;

		public string bodyTextColor;

		public BackgroundImageLayout(string image, string titleTextColor, string bodyTextColor)
		{
			this.image = image;
			this.titleTextColor = titleTextColor;
			this.bodyTextColor = bodyTextColor;
		}
	}
	public enum NotificationActionType
	{
		Opened,
		ActionTaken
	}
	[Serializable]
	public sealed class NotificationAction
	{
		public string actionID;

		public NotificationActionType type;
	}
	[Serializable]
	public sealed class NotificationOpenedResult
	{
		public NotificationAction action;

		public Notification notification;
	}
	public enum NotificationPermission
	{
		NotDetermined,
		Denied,
		Authorized,
		Provisional,
		Ephemeral
	}
	public class NotificationReceivedEvent
	{
		public Notification notificationReceived;

		public NotificationReceivedEvent(Notification notificationReceived)
		{
			this.notificationReceived = notificationReceived;
		}
	}
	public abstract class OneSignalSDKInternal
	{
		public delegate Notification NotificationWillShowDelegate(Notification notification);

		public delegate void NotificationActionDelegate(NotificationOpenedResult result);

		public delegate void InAppMessageLifecycleDelegate(InAppMessage message);

		public delegate void InAppMessageActionDelegate(InAppMessageAction action);

		public delegate void StateChangeDelegate<in TState>(TState current, TState previous);

		public static OneSignalSDKInternal _default;

		public abstract LogLevel LogLevel { get; set; }

		public abstract LogLevel AlertLevel { get; set; }

		public abstract bool PrivacyConsent { get; set; }

		public abstract bool RequiresPrivacyConsent { get; set; }

		public abstract bool PushEnabled { get; set; }

		public abstract bool InAppMessagesArePaused { get; set; }

		public abstract DeviceState DeviceState { get; }

		public abstract NotificationPermission NotificationPermission { get; }

		public abstract PushSubscriptionState PushSubscriptionState { get; }

		public abstract EmailSubscriptionState EmailSubscriptionState { get; }

		public abstract SMSSubscriptionState SMSSubscriptionState { get; }

		public abstract bool ShareLocation { get; set; }

		public abstract event NotificationWillShowDelegate NotificationWillShow;

		public abstract event NotificationActionDelegate NotificationOpened;

		public abstract event InAppMessageLifecycleDelegate InAppMessageWillDisplay;

		public abstract event InAppMessageLifecycleDelegate InAppMessageDidDisplay;

		public abstract event InAppMessageLifecycleDelegate InAppMessageWillDismiss;

		public abstract event InAppMessageLifecycleDelegate InAppMessageDidDismiss;

		public abstract event InAppMessageActionDelegate InAppMessageTriggeredAction;

		public abstract event StateChangeDelegate<NotificationPermission> NotificationPermissionChanged;

		public abstract event StateChangeDelegate<PushSubscriptionState> PushSubscriptionStateChanged;

		public abstract event StateChangeDelegate<EmailSubscriptionState> EmailSubscriptionStateChanged;

		public abstract event StateChangeDelegate<SMSSubscriptionState> SMSSubscriptionStateChanged;

		public static OneSignalSDKInternal _getDefaultInstance()
		{
			_ = _default;
			return _default;
		}

		public abstract void Initialize(string appId);

		public abstract Task<NotificationPermission> PromptForPushNotificationsWithUserResponse();

		public abstract Task<NotificationPermission> PromptForPushNotificationsWithUserResponse(bool fallbackToSettings);

		public abstract void ClearOneSignalNotifications();

		public abstract Task<bool> PostNotification(Dictionary<string, object> options);

		public abstract void SetTrigger(string key, object value);

		public abstract void SetTriggers(Dictionary<string, object> triggers);

		public abstract void RemoveTrigger(string key);

		public abstract void RemoveTriggers(params string[] keys);

		public abstract object GetTrigger(string key);

		public abstract Dictionary<string, object> GetTriggers();

		public abstract Task<bool> SendTag(string key, string value);

		public abstract Task<bool> SendTags(Dictionary<string, object> tags);

		public abstract Task<Dictionary<string, object>> GetTags();

		public abstract Task<bool> DeleteTag(string key);

		public abstract Task<bool> DeleteTags(params string[] keys);

		public abstract Task<bool> SetExternalUserId(string externalId);

		public abstract Task<bool> SetExternalUserId(string externalId, string authHash = null);

		public abstract Task<bool> SetEmail(string email, string authHash = null);

		public abstract Task<bool> SetSMSNumber(string smsNumber, string authHash = null);

		public abstract Task<bool> RemoveExternalUserId();

		public abstract Task<bool> LogoutEmail();

		public abstract Task<bool> LogoutSMS();

		public abstract void SetLaunchURLsInApp(bool launchInApp);

		public abstract Task<bool> SetLanguage(string languageCode);

		public abstract void PromptLocation();

		public abstract Task<bool> SendOutcome(string name);

		public abstract Task<bool> SendUniqueOutcome(string name);

		public abstract Task<bool> SendOutcomeWithValue(string name, float value);
	}
	public class OutcomeEvent
	{
		public enum OSSession
		{
			DIRECT,
			INDIRECT,
			UNATTRIBUTED,
			DISABLED
		}

		public OSSession session = OSSession.DISABLED;

		public List<string> notificationIds = new List<string>();

		public string name = "";

		public long timestamp;

		public double weight;

		public OutcomeEvent()
		{
		}

		public OutcomeEvent(IReadOnlyDictionary<string, object> outcomeDict)
		{
			if (outcomeDict.ContainsKey("session") && outcomeDict["session"] != null)
			{
				session = _sessionFromString(outcomeDict["session"] as string);
			}
			if (outcomeDict.ContainsKey("notification_ids") && outcomeDict["notification_ids"] != null)
			{
				List<string> list = new List<string>();
				if (outcomeDict["notification_ids"].GetType().Equals(typeof(string)))
				{
					list = new List<string> { Convert.ToString(outcomeDict["notification_ids"] as string) };
				}
				else
				{
					List<object> list2 = outcomeDict["notification_ids"] as List<object>;
					foreach (object item in list2)
					{
						list.Add(item.ToString());
					}
				}
				notificationIds = list;
			}
			if (outcomeDict.ContainsKey("id") && outcomeDict["id"] != null)
			{
				name = outcomeDict["id"] as string;
			}
			if (outcomeDict.ContainsKey("timestamp") && outcomeDict["timestamp"] != null)
			{
				timestamp = (long)outcomeDict["timestamp"];
			}
			if (outcomeDict.ContainsKey("weight") && outcomeDict["weight"] != null)
			{
				weight = double.Parse(Convert.ToString(outcomeDict["weight"]));
			}
		}

		public static OSSession _sessionFromString(string session)
		{
			session = session.ToLower();
			return session switch
			{
				"direct" => OSSession.DIRECT, 
				"indirect" => OSSession.INDIRECT, 
				"unattributed" => OSSession.UNATTRIBUTED, 
				_ => OSSession.DISABLED, 
			};
		}
	}
	[Serializable]
	public sealed class PushSubscriptionState
	{
		public string userId;

		public bool isSubscribed;

		public string pushToken;

		public bool isPushDisabled;
	}
	public class SDKDebug
	{
		public static event Action<object> LogIntercept;

		public static event Action<object> WarnIntercept;

		public static event Action<object> ErrorIntercept;

		public static void Log(string message)
		{
			if (SDKDebug.LogIntercept != null)
			{
				SDKDebug.LogIntercept(message);
			}
		}

		public static void Warn(string message)
		{
			if (SDKDebug.WarnIntercept != null)
			{
				SDKDebug.WarnIntercept(message);
			}
		}

		public static void Error(string message)
		{
			if (SDKDebug.ErrorIntercept != null)
			{
				SDKDebug.ErrorIntercept(message);
			}
		}

		private static string _formatMessage(string message)
		{
			return "[OneSignal] " + message;
		}
	}
	[Serializable]
	public sealed class SMSSubscriptionState
	{
		public string smsUserId;

		public bool isSubscribed;

		public string smsNumber;
	}
}
